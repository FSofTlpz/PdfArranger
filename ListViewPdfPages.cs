﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;

namespace PdfArranger {
   public partial class ListViewPdfPages : UserControl {

      const double imageSizeFactor = 1.189;

      /// <summary>
      /// Basisgröße für <see cref="ImageSizeStep"/>==0
      /// </summary>
      const int baseImageSize = 32;

      /// <summary>
      /// akt. Größe für ImageList BaseImageSize.Width * ImageSizeFactor ^ ImageSizeStep -> 1 (0) ... 7,983 (12)
      /// </summary>
      public uint ImageSizeStep { get; protected set; } = 4;

      /// <summary>
      /// zum Speichern einmal berechneter Bildgrößen
      /// </summary>
      Dictionary<int, ImageList> imagelists = new Dictionary<int, ImageList>();

      /// <summary>
      /// Anzahl der markierten Items
      /// </summary>
      public int SelectedCount {
         get {
            return listView1.SelectedIndices.Count;
         }
      }


      //List<ListViewItem> listViewItemCache;



      // Sorts ListViewItem objects by index.
      private class ListViewIndexComparer : System.Collections.IComparer {
         public int Compare(object x, object y) {
            return ((ListViewItem)x).Index - ((ListViewItem)y).Index;
         }
      }

      class PageData {

         /// <summary>
         /// Pseudodatei für Bilder
         /// </summary>
         public const string IMAGEPSEUDOFILE = "*IMG*";

         /// <summary>
         /// Seitennummer in der PDF-Datei (1 ... ) (!)
         /// </summary>
         public int PageNo {
            get;
            protected set;
         }

         public int FileKey {
            get;
            protected set;
         }

         public string Filename {
            get => PdfFileWrapper.PdfFile(FileKey);
         }

         public string Password {
            get => PdfFileWrapper.PdfPassword(FileKey);
         }

         public ListViewItem ListviewItem {
            get; set;
         }

         public bool SourceIsImage {
            get => Image != null;
         }

         public Image Image {
            get;
            protected set;
         }

         /// <summary>
         /// Bildgröße in mm (oder <see cref="SizeF.Empty"/>)
         /// </summary>
         public SizeF ImageSize = SizeF.Empty;

         /// <summary>
         /// Seitengröße in mm (oder <see cref="RectangleF.Empty"/>)
         /// </summary>
         public RectangleF PageSize = RectangleF.Empty;

         static int imgpseudopage = 1;


         PdfFileWrapper.PageRotationType _rotation;

         public PdfFileWrapper.PageRotationType Rotation {
            get => _rotation;
            set {
               if (_rotation != value) {
                  if (ListviewItem != null) {
                     Image img = ListviewItem.ImageList.Images[ListviewItem.ImageIndex];

                     RotateImage(img, PdfFileWrapper.RotationDiff(value, _rotation));

                     ListviewItem.ImageList.Images[ListviewItem.ImageIndex] = img;
                  }
                  _rotation = value;
               }
            }
         }


         public PageData(int pageno, string filename, string password, PdfFileWrapper.PageRotationType rotation = PdfFileWrapper.PageRotationType.None, ListViewItem lvi = null) {
            if (pageno < 1)
               throw new ArgumentException("Seitennummer >= 1!");
            Rotation = rotation;
            PageNo = pageno;
            FileKey = PdfFileWrapper.RegisterFile(filename, password);
            ListviewItem = lvi;
         }

         public PageData(Image img, SizeF imagesize, PdfFileWrapper.PageRotationType rotation = PdfFileWrapper.PageRotationType.None, ListViewItem lvi = null) {
            Rotation = rotation;
            PageNo = imgpseudopage++;
            FileKey = PdfFileWrapper.RegisterFile(IMAGEPSEUDOFILE, "");
            ListviewItem = lvi;
            Image = img;
            ImageSize = imagesize;
         }

         public PageData(PageData pd) {
            Rotation = pd.Rotation;
            PageNo = pd.PageNo;
            FileKey = pd.FileKey;
            ListviewItem = pd.ListviewItem != null ? pd.ListviewItem.Clone() as ListViewItem : null;
            if (pd.SourceIsImage)
               Image = imgCopy(pd.Image);
            ImageSize = new SizeF(pd.ImageSize);
         }

         public static void RotateImage(Image img, PdfFileWrapper.PageRotationType rotation) {
            if (img != null &&
                rotation != PdfFileWrapper.PageRotationType.None) {
               switch (rotation) {
                  case PdfFileWrapper.PageRotationType.Left90:
                     img.RotateFlip(RotateFlipType.Rotate270FlipNone);
                     break;

                  case PdfFileWrapper.PageRotationType.Right90:
                     img.RotateFlip(RotateFlipType.Rotate90FlipNone);
                     break;

                  case PdfFileWrapper.PageRotationType.Right180:
                     img.RotateFlip(RotateFlipType.Rotate180FlipNone);
                     break;
               }
            }
         }

         public void AddRotation(PdfFileWrapper.PageRotationType rotation) {
            Rotation = PdfFileWrapper.RotationAdd(Rotation, rotation);
         }

         public override string ToString() {
            return string.Format("Filename={0}, FileKey={1}, Page={2}", Filename, FileKey, PageNo);
         }
      }

      class DragDropData {

         public ListViewPdfPages SourceListViewPdfPages { get; }

         public ListView SourceListView {
            get;
            protected set;
         }

         public ListView.SelectedIndexCollection IndexCollection { get; }

         public DragDropData(ListViewPdfPages src) {
            SourceListViewPdfPages = src;
            SourceListView = src.listView1;
            IndexCollection = SourceListView.SelectedIndices;
         }

      }

      public class PageInfo {

         public string Filename {
            get;
            protected set;
         }

         /// <summary>
         /// Seitennummer in der PDF-Datei (1 ... ) (!)
         /// </summary>
         public int PageNo {
            get;
            protected set;
         }

         public SizeF PageSize {
            get;
            protected set;
         }

         public PageInfo(string filename, int pageno, SizeF pageSize) {
            if (pageno < 1)
               throw new ArgumentException("Seitennummer >= 1!");
            Filename = filename;
            PageNo = pageno;
            PageSize = pageSize;
         }

         public override string ToString() {
            return string.Format("Page {0}, Filename {1}", PageNo, Filename);
         }
      }


      List<PageData> dataCache = new List<PageData>();

      /// <summary>
      /// Anzahl der Seiten
      /// </summary>
      public int Count {
         get => listView1.Items.Count;
      }

      AppData appData;


      #region Events

      /// <summary>
      /// Die Anzahl der Items hat sich geändert.
      /// </summary>
      public event EventHandler<EventArgs> OnItemCountChanged;

      /// <summary>
      /// Die Liste der ausgewählten Items hat sich geändert.
      /// </summary>
      public event EventHandler<EventArgs> OnItemSelectionChanged;

      public class PageInfoEventArgs : EventArgs {

         public PageInfo PageInfo { get; private set; }

         public PageInfoEventArgs(PageInfo pageInfo) {
            PageInfo = pageInfo;
         }
      }

      /// <summary>
      /// Auf ein Item wurde doppelt geklickt.
      /// </summary>
      public event EventHandler<PageInfoEventArgs> OnItemDoubleClick;

      /// <summary>
      /// Es wurden zusätzliche Items per Drag&Drop hinzugefügt.
      /// </summary>
      public event EventHandler<EventArgs> OnNewItemsDrop;

      #endregion


      public ListViewPdfPages() {
         InitializeComponent();

         listView1.View = View.LargeIcon;
         listView1.Scrollable = true;

         listView1.AutoArrange = true;
         listView1.Sorting = SortOrder.None;
         listView1.ListViewItemSorter = new ListViewIndexComparer();

         listView1.VirtualMode = true;
         listView1.VirtualListSize = 0;

         listView1.DragEnter += ListView1_DragEnter;
         listView1.DragLeave += ListView1_DragLeave;
         listView1.DragOver += ListView1_DragOver;
         listView1.DragDrop += ListView1_DragDrop;
         listView1.ItemDrag += ListView1_ItemDrag;
         listView1.AllowDrop = true;

         listView1.MouseDoubleClick += ListView1_MouseDoubleClick;
         listView1.KeyDown += ListView1_KeyDown;

         listView1.RetrieveVirtualItem += ListView1_RetrieveVirtualItem;

         listView1.MouseWheel += ListView1_MouseWheel;

         listView1.BackColor = BackColor;
         listView1.ForeColor = ForeColor;
      }

      public void SetAppData(AppData appData) {
         this.appData = appData;
         ImageSizeStep = appData.ImageSizeStep;
         ChangeImageSize(0);
      }

      #region public-Funktionen

      /// <summary>
      /// die Seiten der Pdf-Datei werden eingefügt oder angehängt
      /// </summary>
      /// <param name="pdffile"></param>
      /// <param name="listindex"></param>
      /// <returns>Anzahl der Seiten</returns>
      public int AppendPdfFile(string pdffile, int listindex = -1) {
         string password = null;
         //password = "OWW08SCSx";

         int id = PdfFileWrapper.RegisterFile(pdffile, password);
         PdfFileWrapper pdf = new PdfFileWrapper(pdffile, MyPasswordProvider, password);
         if (!pdf.PasswordIsRight())
            return 0;
         password = PdfFileWrapper.PdfPassword(id); // ev. geändert

         Cursor cur = Cursor;
         int pagecount = 0;
         try {
            pdf.ReadPdfInfos();
            pagecount = pdf.PageCount();
            pdf.UsedPagesAdd(pagecount);

            if (dataCache == null)
               dataCache = new List<PageData>();

            PageData[] pd = new PageData[pagecount];
            for (int i = 0; i < pd.Length; i++) {
               pd[i] = new PageData(i + 1, pdffile, password, PdfFileWrapper.PageRotationType.None) {
                  PageSize = pdf.PdfPageSizes[i],
               };
            }

            Cursor = Cursors.WaitCursor;
            if (0 <= listindex && listindex < dataCache.Count)
               dataCache.InsertRange(listindex, pd);
            else
               dataCache.AddRange(pd);
            Cursor = cur;

            listView1.VirtualListSize += pagecount;
            OnItemCountChanged?.Invoke(this, new EventArgs());

         } catch (Exception ex) {
            Cursor = cur;
            MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         return pagecount;
      }

      /// <summary>
      /// Ein Bild wird als PDF-Seite in der Größe des Bildes eingefügt.
      /// </summary>
      /// <param name="imgfile">Dateiname der Bilddatei</param>
      /// <param name="listindex">Position der Seite (oder anhängen)</param>
      /// <returns></returns>
      public int AppendImgFile(string imgfile, int listindex = -1) {
         try {
            using (Bitmap bm = new Bitmap(imgfile)) {
               AppendImage(bm, listindex);
            }
         } catch (Exception ex) {
            MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
         return 1;
      }

      /// <summary>
      /// Es wird eine Kopie des Bildes erzeugt und als PDF-Seite in der Größe des Bildes eingefügt.
      /// </summary>
      /// <param name="image">Bild</param>
      /// <param name="listindex">Position der Seite (oder anhängen)</param>
      public void AppendImage(Image image, int listindex = -1) {
         float resolution = Math.Max(image.HorizontalResolution, image.VerticalResolution);      // nicht immer sinvoll (?)
         SizeF pagesize = resolution > 70 ? new SizeF(image.Width / resolution * 25.4F,
                                                      image.Height / resolution * 25.4F) :
                                            SizeF.Empty;
         AppendImage(image, pagesize, listindex);
      }

      /// <summary>
      /// Es wird eine Kopie des Bildes erzeugt und als PDF-Seite eingefügt.
      /// </summary>
      /// <param name="image">Bild</param>
      /// <param name="pagesize">Größe der Seite (und des Bildes) in Zoll</param>
      /// <param name="listindex">Position der Seite (oder anhängen)</param>
      public void AppendImage(Image image, SizeF pagesize, int listindex = -1) {
         Cursor cur = Cursor;

         if (dataCache == null)
            dataCache = new List<PageData>();

         try {

            Bitmap bm = imgCopy(image);
            if (bm.RawFormat.Equals(ImageFormat.Bmp) ||
                bm.RawFormat.Equals(ImageFormat.MemoryBmp))
               bm = AsJPEG(bm, 90);

            PageData[] pd = new PageData[] {
                                    new PageData(bm,
                                                 pagesize,
                                                 PdfFileWrapper.PageRotationType.None) {
                                                      PageSize = new RectangleF(0, 0, pagesize.Width, pagesize.Height),
                                                 }
            };

            Cursor = Cursors.WaitCursor;
            if (0 <= listindex && listindex < dataCache.Count)
               dataCache.InsertRange(listindex, pd);
            else
               dataCache.AddRange(pd);
            Cursor = cur;

            listView1.VirtualListSize += pd.Length;
            OnItemCountChanged?.Invoke(this, new EventArgs());

         } catch (Exception ex) {
            Cursor = cur;
            MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      /// <summary>
      /// dreht die markierten Seiten -90°, 90° oder 180°
      /// </summary>
      /// <param name="degree"></param>
      public void RotateSelectedItems(int degree) {
         PdfFileWrapper.PageRotationType rotation = PdfFileWrapper.PageRotationType.None;
         switch (degree) {
            case -90:
               rotation = PdfFileWrapper.PageRotationType.Left90;
               break;

            case 90:
               rotation = PdfFileWrapper.PageRotationType.Right90;
               break;

            case 180:
               rotation = PdfFileWrapper.PageRotationType.Right180;
               break;
         }

         if (rotation != PdfFileWrapper.PageRotationType.None) {
            for (int i = 0; i < SelectedCount; i++) {
               dataCache[listView1.SelectedIndices[i]].AddRotation(rotation);
            }
            listView1.Refresh();
         }
      }

      /// <summary>
      /// liefert ein Bild für die Seite des ersten ausgewählten Items (oder null)
      /// </summary>
      /// <param name="dpi"></param>
      /// <returns></returns>
      public Image GetImage4FirstSelectedItem(int dpi) {
         if (SelectedCount > 0)
            return GetImage4Page(listView1.SelectedIndices[0], dpi);
         return null;
      }

      /// <summary>
      /// liefert für jede ausgewählte Seite ein Bild (oder null)
      /// </summary>
      /// <param name="dpi"></param>
      /// <returns></returns>
      public Image[] GetImage4SelectedItems(int dpi) {
         Image[] images = null;
         if (SelectedCount > 0) {
            images = new Image[SelectedCount];
            for (int i = 0; i < SelectedCount; i++)
               images[i] = GetImage4Page(listView1.SelectedIndices[i], dpi);
         }
         return images;
      }

      /// <summary>
      /// liefert die Indexe aller ausgewählten Items
      /// </summary>
      /// <returns></returns>
      public int[] GetSelectedItemsIdx() {
         int[] result = new int[listView1.SelectedIndices.Count];
         listView1.SelectedIndices.CopyTo(result, 0);
         return result;
      }

      /// <summary>
      /// liefert ein Bild der gewünschten Seite
      /// </summary>
      /// <param name="itemidx">Index in der akt. Auflistung</param>
      /// <param name="dpi">Auflösung des Bildes</param>
      /// <returns></returns>
      public Image GetImage4Page(int itemidx, int dpi) {
         if (0 <= itemidx && itemidx < dataCache.Count) {
            Image img = null;
            if (dataCache[itemidx].Filename == PageData.IMAGEPSEUDOFILE)  // (noch) keine PDF-Seite, sondern ein Bild (gescannt oder importiert)
               img = imgCopy(dataCache[itemidx].Image);
            else {
               PageData pd = dataCache[itemidx];
               img = new PdfFileWrapper(pd.Filename,
                                        MyPasswordProvider,
                                        pd.Password).GetPageImage(pd.PageNo, dpi);
            }

            PageData.RotateImage(img, dataCache[itemidx].Rotation);
            return img;
         }
         return null;
      }

      /// <summary>
      /// liefert alle Bilder einer Seite
      /// </summary>
      /// <param name="idx"></param>
      /// <returns></returns>
      public List<Image> GetAllImagesInPage(int idx) {
         if (dataCache[idx].Filename == PageData.IMAGEPSEUDOFILE)  // (noch) keine PDF-Seite, sondern ein Bild (gescannt oder importiert)
            return new List<Image>() {
                              imgCopy(dataCache[idx].Image)
            };
         else {
            PageData pd = dataCache[idx];
            PdfFileWrapper pdf = new PdfFileWrapper(PdfFileWrapper.PdfFile(pd.FileKey), MyPasswordProvider, PdfFileWrapper.PdfPassword(pd.FileKey));
            if (pdf.PasswordIsRight())
               return pdf.GetImages4Page(pd.PageNo + 1);
         }
         return null;
      }

      /// <summary>
      /// liefert Infos zu den akt. markierten Seiten
      /// </summary>
      /// <returns></returns>
      public PageInfo[] GetInfo4SelectedItems() {
         if (SelectedCount > 0) {
            PageInfo[] pi = new PageInfo[SelectedCount];
            for (int i = 0; i < SelectedCount; i++)
               pi[i] = GetInfo4Page(listView1.SelectedIndices[i]);
            return pi;
         }
         return new PageInfo[0];
      }

      /// <summary>
      /// liefert Infos für eine Seite
      /// </summary>
      /// <param name="itemidx">Index des Elementes im LisView</param>
      /// <returns></returns>
      public PageInfo GetInfo4Page(int itemidx) {
         return 0 <= itemidx && itemidx < dataCache.Count ?
                        new PageInfo(dataCache[itemidx].Filename,
                                     dataCache[itemidx].PageNo,
                                     new SizeF(dataCache[itemidx].PageSize.Width, dataCache[itemidx].PageSize.Height)) :
                        null;
      }

      /// <summary>
      /// liefert eine Sammlung aller verwendeten Dateien mit ihren jeweiligen Seitennummern (0-basiert)
      /// </summary>
      /// <returns></returns>
      public Dictionary<string, List<int>> GetInfo4Pages() {
         Dictionary<string, List<int>> info = new Dictionary<string, List<int>>();
         foreach (PageData pd in dataCache) {
            if (info.TryGetValue(pd.Filename, out List<int> pages))
               pages.Add(pd.PageNo);
            else
               info.Add(pd.Filename, new List<int>() { pd.PageNo });
         }
         return info;
      }

      /// <summary>
      /// akt. markierte Seiten entfernen
      /// </summary>
      public void RemoveSelectedItems() {
         if (SelectedCount > 0) {
            int[] idx = new int[SelectedCount];
            listView1.SelectedIndices.CopyTo(idx, 0);
            Array.Sort(idx);

            for (int i = idx.Length - 1; i >= 0; i--) {
               PdfFileWrapper.UsedPagesDecrement(dataCache[idx[i]].FileKey);
               dataCache.RemoveAt(idx[i]);
               listView1.VirtualListSize--;
            }
            listView1.SelectedIndices.Clear();
            OnItemCountChanged?.Invoke(this, new EventArgs());
         }
      }

      /// <summary>
      /// alle Seiten entfernen
      /// </summary>
      public void RemoveAllItems() {
         foreach (PageData item in dataCache)
            PdfFileWrapper.UsedPagesDecrement(item.FileKey);
         listView1.Clear();
         OnItemCountChanged?.Invoke(this, new EventArgs());
      }

      /// <summary>
      /// liefert den akt. Index dieser Seite
      /// </summary>
      /// <param name="filename"></param>
      /// <param name="pageno"></param>
      /// <returns>negativ wenn nicht gefunden</returns>
      public int GetIdx4Page(string filename, int pageno) {
         for (int i = 0; i < dataCache.Count; i++)
            if (dataCache[i].PageNo == pageno &&
                dataCache[i].Filename == filename)
               return i;
         return -1;
      }

      /// <summary>
      /// macht ein bestimmtes Item sichtbar
      /// </summary>
      /// <param name="idx"></param>
      public void EnsureVisible(int idx) {
         if (0 <= idx && idx < listView1.Items.Count)
            listView1.Items[idx].EnsureVisible();
      }

      /// <summary>
      /// lesen und speichern der Seiten mit PdfSharp
      /// <para>ACHTUNG: Exceptions beachten!</para>
      /// </summary>
      /// <param name="destfile"></param>
      public void Save(string destfile) {
         if (dataCache.Count > 0) {

            using (PdfFileWrapper pdfFileOutput = new PdfFileWrapper(destfile, MyPasswordProvider)) {
               try {
                  List<PdfFileWrapper.PageItem> pages = new List<PdfFileWrapper.PageItem>();
                  for (int i = 0; i < dataCache.Count; i++) {
                     PageData pd = dataCache[i];
                     if (pd.SourceIsImage)
                        pages.Add(new PdfFileWrapper.PageItem(pd.Image,
                                                              pd.Rotation,
                                                              pd.ImageSize));
                     else
                        pages.Add(new PdfFileWrapper.PageItem(pd.FileKey,
                                                              pd.PageNo,
                                                              pd.Rotation));
                  }

                  pdfFileOutput.WritePagesToFile(pages);

               } catch (Exception ex) {
                  throw new Exception(ex.Message); // weiterleiten
               }
            }
         }
      }

      public void MyPasswordProvider(PdfFileWrapper.PasswordProviderArgs args) {
         PdfPasswordForm form = new PdfPasswordForm() {
            Password = args.Password == null ? "" : args.Password,
            PdfFile = args.Filename,
         };
         if (form.ShowDialog() == DialogResult.OK)
            args.Password = form.Password;
         else
            args.Abort = true;
      }

      /// <summary>
      /// liefert den Itemindex oder -1 an dieser Pos.
      /// </summary>
      /// <param name="pt"></param>
      /// <returns></returns>
      public int GetItemIdx4Point(Point pt) {
         ListViewHitTestInfo hit = listView1.HitTest(pt);
         if (hit != null && hit.Item != null)
            return hit.Item.Index;
         return -1;
      }

      /// <summary>
      /// erzeugt ein JPEG mit der vorgegebenen Qualität
      /// </summary>
      /// <param name="img"></param>
      /// <param name="quali">0 .. 100</param>
      /// <returns></returns>
      public static Bitmap AsJPEG(Image img, int quali) {
         quali = Math.Max(0, Math.Min(quali, 100));

         // Create an Encoder object based on the GUID for the Quality parameter category.
         Encoder myEncoder = Encoder.Quality;
         // Create an EncoderParameters object. In this case, there is only one EncoderParameter object in the array.
         EncoderParameters myEncoderParameters = new EncoderParameters(1);
         // Save the bitmap with quality level ...
         EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, quali);
         myEncoderParameters.Param[0] = myEncoderParameter;

         // Get an ImageCodecInfo object that represents the JPEG codec.
         ImageCodecInfo jpgEncoder = null;
         foreach (ImageCodecInfo enc in ImageCodecInfo.GetImageEncoders()) {
            if (Equals(enc.FormatID, ImageFormat.Jpeg.Guid)) {
               jpgEncoder = enc;
               break;
            }
         }

         if (jpgEncoder != null) {
            MemoryStream ms = new MemoryStream();
            img.Save(ms, jpgEncoder, myEncoderParameters);
            ms.Position = 0;
            return new Bitmap(ms);
         }
         return null;
      }

      /// <summary>
      /// vergrößert bzw. verkleinert die Seitenanzeige
      /// </summary>
      /// <param name="stepdelta"></param>
      /// <returns>true, wenn verändert</returns>
      public bool ChangeImageSize(int stepdelta) {
         if (0 <= (ImageSizeStep + stepdelta) && (ImageSizeStep + stepdelta) <= 12) {
            int width = (int)(baseImageSize * Math.Pow(imageSizeFactor, ImageSizeStep + stepdelta));
            if (width <= 256) {     // Max. Größe für eine ImageList !
               ImageSizeStep = (uint)((int)ImageSizeStep + stepdelta);
               appData.ImageSizeStep = ImageSizeStep;
               changeImageSize(new Size(width, width));
               return true;
            }
         }
         if (stepdelta > 0)
            MessageBox.Show("Max. Größe erreicht.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         else 
            MessageBox.Show("Min. Größe erreicht.", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
         return false;
      }

      /// <summary>
      /// markiert alle Seiten
      /// </summary>
      /// <returns>Seitenanzahl</returns>
      public int SelectAllItems() {
         for (int i = 0; i < listView1.Items.Count; i++)
            listView1.Items[i].Selected = true;
         return listView1.Items.Count;
      }

      #endregion

      #region ListView Drag & Drop

      // NICHT verwenden:
      //    lv.InsertionMark.AppearsAfterItem
      //    lv.InsertionMark.Index
      // dafür:
      int insertionMarkIndex = -1;
      bool insertionMarkAppearsAfterItem = false;
      int preventDragOverItemIdx = -1;
      bool preventDragOverAppearsAfterItem = false;

      private void ListView1_ItemDrag(object sender, ItemDragEventArgs e) {
         ListView lv = sender as ListView;
         insertionMarkIndex = -1;
         lv.InsertionMark.Index = -1; // NICHT anzeigen

         lv.DoDragDrop(new DragDropData(this), DragDropEffects.Move); // | DragDropEffects.Scroll);
      }

      private void ListView1_DragEnter(object sender, DragEventArgs e) {
         if (e.Data.GetDataPresent(typeof(DragDropData)) ||
             e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = e.AllowedEffect;
      }

      private void ListView1_DragLeave(object sender, EventArgs e) {
         ListView lv = sender as ListView;
         if (insertionMarkIndex >= 0) {
            insertionMarkIndex = -1;
            lv.Refresh();
         }
      }

      Size listViewItemSize(ListView lv) {
         if (0 < dataCache.Count) {
            Rectangle rect1 = lv.GetItemRect(0, ItemBoundsPortion.Entire);
            int width = rect1.Width;
            int height = rect1.Height;

            if (1 < dataCache.Count) {
               Rectangle rect2 = lv.GetItemRect(1, ItemBoundsPortion.Entire);
               if (rect1.Top == rect2.Top) {
                  width = rect2.Left - rect1.Left;
                  int columns = ClientSize.Width / width;
                  if (columns < dataCache.Count) {
                     Rectangle rect3 = lv.GetItemRect(columns, ItemBoundsPortion.Entire);
                     height = rect3.Top - rect1.Top;
                  }
               } else
                  height = rect2.Top - rect1.Top;
            }
            return new Size(width, height);
         }
         return Size.Empty;
      }

      int nearestItemIndex4Point(ListView lv, Point pt, out Size itemSize) {
         int idx = -1;
         itemSize = Size.Empty;
         if (0 < dataCache.Count) {
            itemSize = listViewItemSize(lv);
            int originY = lv.GetItemRect(0, ItemBoundsPortion.Entire).Location.Y;
            int columns = ClientSize.Width / itemSize.Width;

            int col = pt.X / itemSize.Width;
            if (col >= columns)
               col = columns - 1;
            int row = (pt.Y - originY) / itemSize.Height;

            idx = (row * columns) + col;
            while (idx >= dataCache.Count)
               idx -= columns;
         }
         return idx;
      }

      private void ListView1_DragOver(object sender, DragEventArgs e) {
         ListView lv = sender as ListView;
         Point targetPoint = lv.PointToClient(new Point(e.X, e.Y));

         if (lv.Items.Count > 0) {
            insertionMarkIndex = nearestItemIndex4Point(lv, targetPoint, out Size itemSize);
            if (insertionMarkIndex >= 0) {
               Rectangle itemBounds = lv.GetItemRect(insertionMarkIndex);
               insertionMarkAppearsAfterItem = targetPoint.X > itemBounds.Left + (itemBounds.Width / 2);

               // ev. scrollen
               int scrolldestIndex = insertionMarkIndex;
               if (targetPoint.Y < itemSize.Height / 2)
                  scrolldestIndex -= ClientSize.Width / itemSize.Width;
               else if (ClientSize.Height - itemSize.Height / 2 < targetPoint.Y)
                  scrolldestIndex += ClientSize.Width / itemSize.Width;
               scrolldestIndex = Math.Max(0, Math.Min(scrolldestIndex, dataCache.Count - 1));

               lv.EnsureVisible(scrolldestIndex);

            }
         } else {
            insertionMarkIndex = 0;
            insertionMarkAppearsAfterItem = false;
         }

         //Debug.WriteLine("targetIndex={0}, insertionMarkAppearsAfterItem={1}", targetIndex, insertionMarkAppearsAfterItem);

         if (preventDragOverItemIdx != insertionMarkIndex ||
             preventDragOverAppearsAfterItem != insertionMarkAppearsAfterItem) {
            preventDragOverItemIdx = insertionMarkIndex;
            preventDragOverAppearsAfterItem = insertionMarkAppearsAfterItem;

            lv.Refresh();
            if (insertionMarkIndex >= 0) {
               using (Graphics g = lv.CreateGraphics()) {
                  Rectangle rect = lv.Items.Count > 0 ?
                                       lv.GetItemRect(insertionMarkIndex) :
                                       new Rectangle(new Point(0, 0), lv.LargeImageList.ImageSize);   // Die Bildgröße ist zwar etwas kleiner als die Itemgröße, ...
                  drawInsertionMark(g, insertionMarkAppearsAfterItem ? rect.Right : rect.Left, rect.Top, rect.Bottom);
               }
            }
         }
      }

      private void ListView1_DragDrop(object sender, DragEventArgs e) {
         ListView lv = sender as ListView;

         // Retrieve the index of the insertion mark;
         int targetIndex = insertionMarkIndex; // listView1.InsertionMark.Index;

         // If the insertion mark is not visible, exit the method.
         if (targetIndex == -1)
            return;

         // https://docs.microsoft.com/en-us/dotnet/api/system.windows.forms.listviewinsertionmark?view=net-5.0
         /* ...
          * Use the ListView.ListViewItemCollection.Insert method to insert a clone of the dragged item into the ListView.Items collection at the stored insertion index.
          * Use the ListView.ListViewItemCollection.Remove method to remove the original copy of the dragged item.
          * ...
          * To ensure that the items are displayed in the same order as their index values, you must set the ListView.ListViewItemSorter property to an implementation of the IComparer 
          * interface that sorts items by index value. For more information, see the Example section.
          */

         if (insertionMarkAppearsAfterItem)
            targetIndex++;

         if (e.Data.GetDataPresent(typeof(DragDropData))) {
            Cursor cur = Cursor;

            DragDropData ddd = e.Data.GetData(typeof(DragDropData)) as DragDropData;
            bool isListInternal = ddd.SourceListViewPdfPages.Equals(this);    // kommt von der gleichen Liste (sonst andere)
            ListView.SelectedIndexCollection draggedItemsIdx = ddd.IndexCollection;
            ListView src = ddd.SourceListView;
            List<int> newIndexes = new List<int>();

            if (draggedItemsIdx != null &&
                draggedItemsIdx.Count > 0 &&
                src != null) {
               List<PageData> draggedItems = new List<PageData>();
               foreach (int idx in draggedItemsIdx)
                  draggedItems.Add(src.Items[idx].Tag as PageData);

               for (int i = 0; i < draggedItems.Count; i++) {
                  PageData pdold = draggedItems[i];

                  PageData pdnew;
                  if (!isListInternal) {     // kommt von einer anderen Liste
                     //pdnew = new PageData(pdold.PageNo, pdold.Filename, pdold.Password, PdfFileWrapper.PageRotationType.None);
                     pdnew = new PageData(pdold);
                     createListViewItem4Page(pdnew);
                  } else                     // kommt aus der eigenen Liste
                     pdnew = new PageData(pdold);

                  pdnew.ListviewItem.Tag = pdnew;
                  newIndexes.Add(targetIndex);
                  dataCache.Insert(targetIndex++, pdnew);
                  lv.VirtualListSize++;

                  int oldidx = ddd.SourceListViewPdfPages.dataCache.IndexOf(pdold);
                  ddd.SourceListViewPdfPages.dataCache.RemoveAt(oldidx);
                  if (isListInternal && oldidx < targetIndex)
                     targetIndex--;
                  ddd.SourceListView.VirtualListSize--;

                  if (!isListInternal) {    // kommt von einer anderen Liste
                     OnItemCountChanged?.Invoke(this, new EventArgs());
                     ddd.SourceListViewPdfPages.OnItemCountChanged?.Invoke(this, new EventArgs());
                  } else {
                     for (int j = 0; j < newIndexes.Count; j++)
                        if (oldidx <= newIndexes[j])
                           newIndexes[j]--;
                  }

                  //ListViewItem draggedItem = draggedItems[i];
                  //listViewItemCache.Insert(targetIndex++, draggedItem.Clone() as ListViewItem);
                  //lv.VirtualListSize++;
                  //listViewItemCache.Remove(draggedItem);
                  //lv.VirtualListSize--;
               }
               src.SelectedIndices.Clear();

               foreach (int idx in newIndexes)
                  lv.SelectedIndices.Add(idx);

               if (!isListInternal)
                  OnNewItemsDrop?.Invoke(this, new EventArgs());
            }

            Cursor = cur;

         } else if (e.Data.GetDataPresent(DataFormats.FileDrop)) {

            string[] filename = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            for (int i = 0; i < filename.Length; i++) {
               if (File.Exists(filename[i])) {
                  string filext = Path.GetExtension(filename[i]).ToUpper();
                  if (filext == ".PDF") { // Datei einfügen
                     targetIndex += AppendPdfFile(filename[i], targetIndex);
                  } else if (filext == ".BMP" ||
                             filext == ".TIF" ||
                             filext == ".PNG" ||
                             filext == ".JPG" ||
                             filext == ".JPEG") {
                     targetIndex += AppendImgFile(filename[i],
                                                  targetIndex);
                  }
               }
            }
            OnNewItemsDrop?.Invoke(this, new EventArgs());
         }
      }


      void drawInsertionMark(Graphics g, int x, int top, int bottom) {
         g.FillPolygon(new SolidBrush(Color.FromArgb(120, 255, 0, 0)),
                       new Point[] {
                              new Point(x+6, top),
                              new Point(x-6, top),
                              new Point(x-2, top+4),
                              new Point(x-2, bottom-4),
                              new Point(x-6, bottom),
                              new Point(x+6, bottom),
                              new Point(x+2, bottom-4),
                              new Point(x+2, top+4),
                           });
      }

      #endregion

      /// <summary>
      /// Occurs when the ListView is in virtual mode and requires a ListViewItem.
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private void ListView1_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e) {
         if (dataCache[e.ItemIndex].ListviewItem == null)
            createListViewItem4Page(e.ItemIndex);

         e.Item = dataCache[e.ItemIndex].ListviewItem;
      }

      ///// <summary>
      ///// the ListView determines that a new range of items is needed.
      ///// </summary>
      ///// <param name="sender"></param>
      ///// <param name="e"></param>
      //private void listView1_CacheVirtualItems(object sender, CacheVirtualItemsEventArgs e) {
      //}

      ///// <summary>
      ///// Occurs when the ListView is in virtual mode and a search is taking place.
      ///// </summary>
      ///// <param name="sender"></param>
      ///// <param name="e"></param>
      //private void listView1_SearchForVirtualItem(object sender, SearchForVirtualItemEventArgs e) {
      //   //We've gotten a search request. In this example, finding the item is easy since it's just the square of its index.  We'll take the square root and round.

      //   //double x = 0;
      //   //if (Double.TryParse(e.Text, out x)) //check if this is a valid search
      //   //{
      //   //   x = Math.Sqrt(x);
      //   //   x = Math.Round(x);
      //   //   e.Index = (int)x;
      //   //}

      //   // If e.Index is not set, the search returns null.
      //   // Note that this only handles simple searches over the entire list, ignoring any other settings.  Handling Direction, StartIndex,
      //   // and the other properties of SearchForVirtualItemEventArgs is up to this handler.
      //}

      /// <summary>
      /// erzeugt eine echte Kopie des Bildes als <see cref="System.Drawing.Imaging.ImageFormat.MemoryBmp"/> (!) mit dem gleichen Pixelformat und
      /// der gleichen Auflösung
      /// <para>(Clone() hält dagegen immer noch GDI-Ressourcen offen)</para>
      /// </summary>
      /// <param name="img"></param>
      /// <returns></returns>
      static Bitmap imgCopy(Image img) {
         //return img.Clone() as Bitmap;

         if (img is Bitmap) {
            Bitmap bmp = (Bitmap)img;
            return bmp.Clone(new Rectangle(0, 0, img.Width, img.Height), img.PixelFormat);      // DIESES Clone() fkt. hoffentlich korrekt.
         }

         Bitmap bm = new Bitmap(img.Width, img.Height, img.PixelFormat);
         bm.SetResolution(img.HorizontalResolution, img.VerticalResolution);
         using (Graphics g = Graphics.FromImage(bm)) {
            g.DrawImageUnscaled(img, 0, 0);
         }
         return bm;
      }

      string getImageKey(string pdffile, int pageno) {
         return PdfFileWrapper.GetFileID(pdffile).ToString() + "#" + pageno.ToString();
      }

      void registerImage(Image img, int pageno, PdfFileWrapper.PageRotationType rotation) {
         string imgkey = getImageKey(PageData.IMAGEPSEUDOFILE, pageno);

         ImageList il = listView1.LargeImageList;
         if (il != null) {
            if (il.Images.ContainsKey(imgkey)) {
               //il.Images.RemoveByKey(imgkey);
               // Wird ein Image gelöscht, stimmt der Bezug des Index in den ListViewItem möglicherweise nicht mehr. Deshalb müßten alle höheren ListViewItem.ImageIndex korrigiert werden.
               int keyidx = il.Images.IndexOfKey(imgkey);
               il.Images.RemoveAt(keyidx);
               for (int i = 0; i < dataCache.Count; i++)
                  if (dataCache[i].ListviewItem != null &&
                      dataCache[i].ListviewItem.ImageIndex >= keyidx)
                     dataCache[i].ListviewItem.ImageIndex--;
            }

            Bitmap bm = new Bitmap(listView1.LargeImageList.ImageSize.Width, listView1.LargeImageList.ImageSize.Height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(listView1.BackColor);
            RectangleF destRect;
            if (img.Width > img.Height) { // landscape
               float h = (float)img.Height / img.Width * bm.Height;
               destRect = new RectangleF(0,
                                         (bm.Height - h) / 2F,
                                         bm.Width,
                                         h);
            } else { // portrait
               float w = (float)img.Width / img.Height * bm.Width;
               destRect = new RectangleF((bm.Width - w) / 2F,
                                         0,
                                         w,
                                         bm.Height);
            }
            g.DrawImage(img, destRect);
            g.Flush();
            g.Dispose();

            PageData.RotateImage(bm, rotation); // ev. noch drehen

            il.Images.Add(imgkey, bm);
         }

      }

      /// <summary>
      /// registriert das Seiten-Image für die Seite der PDF-Datei
      /// </summary>
      /// <param name="pdffile"></param>
      /// <param name="pageno"></param>
      void registerImage(string pdffile, string password, int pageno, PdfFileWrapper.PageRotationType rotation) {
         string imgkey = getImageKey(pdffile, pageno);

         ImageList il = listView1.LargeImageList;
         if (il != null) {
            if (il.Images.ContainsKey(imgkey)) {
               //il.Images.RemoveByKey(imgkey);
               // Wird ein Image gelöscht, stimmt der Bezug des Index in den ListViewItem möglicherweise nicht mehr. Deshalb müßten alle höheren ListViewItem.ImageIndex korrigiert werden.
               int keyidx = il.Images.IndexOfKey(imgkey);
               il.Images.RemoveAt(keyidx);
               for (int i = 0; i < dataCache.Count; i++)
                  if (dataCache[i].ListviewItem != null &&
                      dataCache[i].ListviewItem.ImageIndex >= keyidx)
                     dataCache[i].ListviewItem.ImageIndex--;
            }

            Image img = new PdfFileWrapper(pdffile, MyPasswordProvider, password).GetPageImage(pageno, 50);
            Bitmap bm = new Bitmap(listView1.LargeImageList.ImageSize.Width, listView1.LargeImageList.ImageSize.Height);
            Graphics g = Graphics.FromImage(bm);
            g.Clear(listView1.BackColor);
            RectangleF destRect;
            if (img.Width > img.Height) { // landscape
               float h = (float)img.Height / img.Width * bm.Height;
               destRect = new RectangleF(0,
                                         (bm.Height - h) / 2F,
                                         bm.Width,
                                         h);
            } else { // portrait
               float w = (float)img.Width / img.Height * bm.Width;
               destRect = new RectangleF((bm.Width - w) / 2F,
                                         0,
                                         w,
                                         bm.Height);
            }
            g.DrawImage(img, destRect);
            g.Flush();
            g.Dispose();

            PageData.RotateImage(bm, rotation); // ev. noch drehen

            il.Images.Add(imgkey, bm);
         }
      }

      void createListViewItem4Page(int idx) {
         createListViewItem4Page(dataCache[idx]);
      }

      void createListViewItem4Page(PageData pd) {
         ListViewItem lvi = pd.SourceIsImage ?
                                 createListViewItem4Page(pd.Image, pd.PageNo, pd.Rotation) :
                                 createListViewItem4Page(pd.Filename, pd.Password, pd.PageNo, pd.Rotation);
         lvi.ToolTipText = "Seite " + pd.PageNo + ", " + pd.Filename;
         lvi.Tag = pd;
         pd.ListviewItem = lvi;
      }

      ListViewItem createListViewItem4Page(string pdffile, string password, int pageno, PdfFileWrapper.PageRotationType rotation) {
         registerImage(pdffile, password, pageno, rotation);

         ListViewItem lvi = new ListViewItem() {
            BackColor = Color.LightGreen,
            //ImageKey = imgkey,   // fkt. NICHT im VirtualMode !!!!!
            ImageIndex = listView1.LargeImageList.Images.IndexOfKey(getImageKey(pdffile, pageno)),
            Text = "Seite " + pageno,
         };

         return lvi;
      }

      ListViewItem createListViewItem4Page(Image img, int pageno, PdfFileWrapper.PageRotationType rotation) {
         registerImage(img, pageno, rotation);

         ListViewItem lvi = new ListViewItem() {
            BackColor = Color.LightYellow,
            ImageIndex = listView1.LargeImageList.Images.IndexOfKey(getImageKey(PageData.IMAGEPSEUDOFILE, pageno)),
            Text = "Seite " + pageno,
         };

         return lvi;
      }

      private void ListViewPdfPages_BackColorChanged(object sender, EventArgs e) {
         listView1.BackColor = BackColor;
      }

      private void ListViewPdfPages_ForeColorChanged(object sender, EventArgs e) {
         listView1.ForeColor = ForeColor;
      }

      private void ListView1_MouseWheel(object sender, MouseEventArgs e) {
         if ((ModifierKeys & Keys.Control) == Keys.Control)
            if (e.Delta != 0)
               ChangeImageSize(e.Delta > 0 ? 1 : -1);
      }

      private void ListView1_SelectedIndexChanged(object sender, EventArgs e) {
         //Debug.WriteLine(">>> SelectedIndexChanged: " + (sender as ListView).SelectedIndices.Count + ", " + x());
      }

      private void listView1_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e) {
         //Debug.WriteLine(">>> ItemSelectionChanged: " + (sender as ListView).SelectedIndices.Count);
         OnItemSelectionChanged?.Invoke(this, new EventArgs());
      }

      private void listView1_VirtualItemsSelectionRangeChanged(object sender, ListViewVirtualItemsSelectionRangeChangedEventArgs e) {
         //Debug.WriteLine(">>> VirtualItemsSelectionRangeChanged: " + (sender as ListView).SelectedIndices.Count);
         OnItemSelectionChanged?.Invoke(this, new EventArgs());
      }

      private void ListView1_KeyDown(object sender, KeyEventArgs e) {
         if (e.KeyCode == Keys.Enter) {
            if (SelectedCount > 0) {
               e.Handled = true;
               PageData pd = dataCache[listView1.SelectedIndices[0]];
               OnItemDoubleClick?.Invoke(this, new PageInfoEventArgs(new PageInfo(pd.Filename, pd.PageNo, new SizeF(pd.PageSize.Width, pd.PageSize.Height))));
            }
         }
      }

      private void ListView1_MouseDoubleClick(object sender, MouseEventArgs e) {
         int idx = GetItemIdx4Point(e.Location);
         if (idx >= 0) {
            PageData pd = dataCache[idx];
            OnItemDoubleClick?.Invoke(this, new PageInfoEventArgs(new PageInfo(pd.Filename, pd.PageNo, new SizeF(pd.PageSize.Width, pd.PageSize.Height))));
         }
      }

      /// <summary>
      /// Leider muss die gesamte Imageliste dann neu erzeugt werden.
      /// </summary>
      /// <param name="newSize"></param>
      void changeImageSize(Size newSize) {
         ImageList il;
         if (!imagelists.TryGetValue(newSize.Width, out il)) {
            il = new ImageList() {
               ImageSize = newSize,
               ColorDepth = ColorDepth.Depth32Bit,
            };
            imagelists.Add(newSize.Width, il);
         }
         foreach (var item in dataCache) {
            item.ListviewItem = null;
         }
         listView1.LargeImageList = il;
         listView1.Refresh();

         //listView1.LargeImageList = new ImageList() {
         //   ImageSize = newSize,
         //   ColorDepth = ColorDepth.Depth32Bit,
         //};
         //foreach (var item in dataCache) {
         //   item.ListviewItem = null;
         //}
         //listView1.Refresh();
      }

   }
}
