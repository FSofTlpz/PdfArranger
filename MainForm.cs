using FSofTUtils.WIAHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PdfArranger {
   public partial class MainForm : Form {

      /*
       * 
       * CTRL + Mouse-Wheel      Zoom
       */

      /// <summary>
      /// liefert die akt. <see cref="PdfViewForm"/> oder null
      /// </summary>
      PdfViewForm actualPdfViewForm {
         get {
            return (ActiveMdiChild != null &&
                    ActiveMdiChild is PdfViewForm &&
                    ActiveMdiChild.IsHandleCreated) ?
                   ActiveMdiChild as PdfViewForm :
                   null;
         }
      }

      readonly int stdDPI = 300;

      readonly int stdPanelScannersideboardWidth = 0;

      AppData appData;


      public MainForm() {
         InitializeComponent();

         DragEnter += MainForm_DragEnter;
         //DragLeave += MainForm_DragLeave;
         //DragOver += MainForm_DragOver;
         DragDrop += MainForm_DragDrop;
         AllowDrop = true;

         stdPanelScannersideboardWidth = panelScannersideboard.Width;
      }

      private void MainForm_Load(object sender, EventArgs e) {
         string title = "";
         Assembly a = Assembly.GetExecutingAssembly();
         object[] o = a.GetCustomAttributes(false);
         for (int i = 0; i < o.Length; i++)
            if (o[i].GetType() == typeof(AssemblyTitleAttribute))
               title = ((AssemblyTitleAttribute)(o[i])).Title;
         for (int i = 0; i < o.Length; i++)
            if (o[i].GetType() == typeof(AssemblyInformationalVersionAttribute))
               title += ", Version " + ((AssemblyInformationalVersionAttribute)(o[i])).InformationalVersion;
         for (int i = 0; i < o.Length; i++)
            if (o[i].GetType() == typeof(AssemblyCopyrightAttribute))
               title += ", " + ((AssemblyCopyrightAttribute)(o[i])).Copyright;
         Text = title;

         AddClipboardViewer();

         appData = new AppData("FSofT\\PdfArranger");

         startScannerSideboard();
      }

      private void MainForm_Shown(object sender, EventArgs e) {
         string[] args = Environment.GetCommandLineArgs();
         for (int i = 1; i < args.Length; i++)
            openPdf(args[i]);
         adjustMenuAndToolbar();
      }

      private void MainForm_Activated(object sender, EventArgs e) {
         adjustMenuAndToolbar();
      }

      private void MainForm_DragEnter(object sender, DragEventArgs e) {
         if (e.Data.GetDataPresent(DataFormats.FileDrop))
            e.Effect = DragDropEffects.Link;
         else
            e.Effect = DragDropEffects.None;
      }

      private void MainForm_DragDrop(object sender, DragEventArgs e) {
         string[] filename = (string[])e.Data.GetData(DataFormats.FileDrop, false);
         for (int i = 0; i < filename.Length; i++) {
            if (Path.GetExtension(filename[i]).ToUpper() == ".PDF" &&
                File.Exists(filename[i])) {
               openPdf(filename[i]);
            }
         }
      }

      private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
         RemoveClipboardViewer();
         saveScannerStatus();
         appData.Save();
      }

      void saveActualPdfView() {
         if (actualPdfViewForm != null) {
            Cursor orgcursor = Cursor;
            try {
               if (saveFileDialog1.ShowDialog() == DialogResult.OK) {
                  // alle akt. verwendeten PDF's ermitteln
                  List<string> actualUsedFiles = new List<string>();
                  foreach (var mdiform in MdiChildren) {
                     foreach (var item in (mdiform as PdfViewForm).Info4Pages()) {
                        string file = item.Key;
                        if (!actualUsedFiles.Contains(file))
                           actualUsedFiles.Add(file);
                     }
                  }

                  if (actualUsedFiles.Contains(saveFileDialog1.FileName))
                     MessageBox.Show("Die Datei '" + saveFileDialog1.FileName + "' wird noch verwendet und kann nicht überschrieben werden.",
                                     "Info",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Exclamation);
                  else {
                     Cursor = Cursors.WaitCursor;
                     actualPdfViewForm?.PdfPages.Save(saveFileDialog1.FileName);
                     Cursor = orgcursor;
                  }
               }
            } catch (Exception ex) {
               Cursor = orgcursor;
               MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
         }
      }

      void openPdfView() {
         if (openFileDialog1.ShowDialog() == DialogResult.OK)
            openPdf(openFileDialog1.FileName);
      }

      void openPdf(string filename) {
         if (!string.IsNullOrEmpty(filename))
            if (!Path.IsPathRooted(filename))
               filename = Path.GetFullPath(filename);
         Cursor cur = Cursor;
         Cursor = Cursors.WaitCursor;
         try {
            PdfViewForm form = new PdfViewForm(appData) {
               Filename = filename,
               MdiParent = this,
            };
            form.OnItemDoubleClick += Form_OnItemDoubleClick;
            form.OnCountChanged += Form_OnCountChanged;
            form.OnSelectedCountChanged += Form_OnSelectedCountChanged;
            form.FormClosed += Form_FormClosed;
            form.Activated += Form_Activated;
            form.Show();
            Cursor = cur;
         } catch (Exception ex) {
            Cursor = cur;
            MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void Form_Activated(object sender, EventArgs e) {
         adjustMenuAndToolbar();
      }

      private void Form_FormClosed(object sender, FormClosedEventArgs e) {
         adjustMenuAndToolbar(sender as PdfViewForm);
      }

      private void Form_OnSelectedCountChanged(object sender, EventArgs e) {
         adjustMenuAndToolbar();
      }

      private void Form_OnCountChanged(object sender, EventArgs e) {
         adjustMenuAndToolbar();
      }

      private void Form_OnItemDoubleClick(object sender, ListViewPdfPages.PageInfoEventArgs e) {
         showSelectedPage();
      }

      void showSelectedPage() {
         actualPdfViewForm?.ShowSelectedPages(stdDPI);
      }

      private void ScannerPropsForm_OnInitChanged(object sender, EventArgs e) {
         adjustMenuAndToolbar();
      }

      void adjustMenuAndToolbar(PdfViewForm closingform = null) {
         int mdichilds = MdiChildren.Length - (closingform != null ? 1 : 0);

         toolStripButton_scan.Enabled =
         ToolStripMenuItem_ScanPage.Enabled = ScannerIsInit; // && mdichilds > 0;

         toolStripButton_Save.Enabled =
         ToolStripMenuItem_SavePageView.Enabled = closingform != null ?
                                                      false :
                                                      actualPdfViewForm?.PdfPages.Count > 0;

         toolStripButton_Paste.Enabled = closingform != null ?
                                                      false :
                                                      actualPdfViewForm != null && Clipboard.ContainsImage();

         toolStripButton_PageView.Enabled =
         ToolStripMenuItem_PageView.Enabled =
         toolStripButton_Remove.Enabled =
         ToolStripMenuItem_Remove.Enabled =
         toolStripButton_RotateRight.Enabled =
         ToolStripMenuItem_RotateRight.Enabled =
         toolStripButton_RotateLeft.Enabled =
         ToolStripMenuItem_RotateLeft.Enabled =
         toolStripButton_Copy.Enabled = closingform != null ?
                                                      false :
                                                      actualPdfViewForm?.PdfPages.SelectedCount > 0;

         toolStripButton_zoomin.Enabled =
         toolStripButton_zoomout.Enabled =
         ToolStripMenuItem_MarkAllPages.Enabled =
         toolStripButton_Copy.Enabled = closingform == null;

         ToolStripMenuItem_Icon.Enabled =
         ToolStripMenuItem_Cascade.Enabled =
         ToolStripMenuItem_Horizontal.Enabled =
         ToolStripMenuItem_Vertical.Enabled = mdichilds > 0;
      }

      #region ToolStripButtons

      private void toolStripButton_RotateLeft_Click(object sender, EventArgs e) {
         actualPdfViewForm?.PdfPages.RotateSelectedItems(-90);
      }

      private void toolStripButton_RotateRight_Click(object sender, EventArgs e) {
         actualPdfViewForm?.PdfPages.RotateSelectedItems(90);
      }

      private void toolStripButton_PageView_Click(object sender, EventArgs e) {
         showSelectedPage();
      }

      private void toolStripButton_new_Click(object sender, EventArgs e) {
         openPdf(null);
         adjustMenuAndToolbar();
      }

      private void toolStripButton_Save_Click(object sender, EventArgs e) {
         saveActualPdfView();
      }

      private void toolStripButton_Remove_Click(object sender, EventArgs e) {
         actualPdfViewForm?.PdfPages.RemoveSelectedItems();
         adjustMenuAndToolbar();
      }

      private void toolStripButton_Scan_Click(object sender, EventArgs e) {
         if (actualPdfViewForm == null)
            toolStripButton_new_Click(null, EventArgs.Empty);

         if (actualPdfViewForm != null) {
            if (ScannerIsInit) {
               Image img = GetImageFromScanner(out double width, out double height);
               if (img != null && actualPdfViewForm != null) {
                  actualPdfViewForm.PdfPages.AppendImage(img, new SizeF((float)width, (float)height));
                  actualPdfViewForm.PdfPages.EnsureVisible(actualPdfViewForm.PdfPages.Count - 1);        // neue Seite anzeigen
               }
            }
            adjustMenuAndToolbar();
         }
      }

      private void toolStripButton_Copy_Click(object sender, EventArgs e) {
         int[] selectedidx = actualPdfViewForm.PdfPages.GetSelectedItemsIdx();
         if (selectedidx.Length > 0) {
            ListViewPdfPages.PageInfo pi = actualPdfViewForm.PdfPages.GetInfo4SelectedItems()[0];
            Image imgresult = null;
            List<Image> imglst = actualPdfViewForm.PdfPages.GetAllImagesInPage(selectedidx[0]);
            if (imglst.Count > 0) {
               foreach (Image img in imglst) {  // Eingebettetes Bild für ganze Seite? Dann das Originalbild verwenden.
                  float w = img.Width / img.HorizontalResolution * 25.4F;
                  float h = img.Height / img.VerticalResolution * 25.4F;
                  if (Math.Abs(pi.PageSize.Width - w) < 0.1 &&          // 0.1mm Diff. erlaubt
                      Math.Abs(pi.PageSize.Height - h) < 0.1) {
                     imgresult = img;
                     break;
                  }
               }
            } else {
               imgresult = actualPdfViewForm.PdfPages.GetImage4Page(selectedidx[0], stdDPI);
            }
            if (imgresult != null)
               Clipboard.SetImage(imgresult);
         }
      }

      private void toolStripButton_Paste_Click(object sender, EventArgs e) {
         Image img = Clipboard.GetImage();
         if (img != null && actualPdfViewForm != null)
            actualPdfViewForm.PdfPages.AppendImage(img);
      }

      private void toolStripButton_zoomin_Click(object sender, EventArgs e) {
         actualPdfViewForm?.PdfPages.ChangeImageSize(1);
      }

      private void toolStripButton_zoomout_Click(object sender, EventArgs e) {
         actualPdfViewForm?.PdfPages.ChangeImageSize(-1);
      }

      #endregion

      #region ToolStripMenuItems

      private void ToolStripMenuItem_LoadFileInPageView_Click(object sender, EventArgs e) {
         openPdfView();
         adjustMenuAndToolbar();
      }

      private void ToolStripMenuItem_NewPageView_Click(object sender, EventArgs e) {
         toolStripButton_new_Click(null, null);
      }

      private void ToolStripMenuItem_SavePageView_Click(object sender, EventArgs e) {
         saveActualPdfView();
      }

      private void ToolStripMenuItem_Icon_Click(object sender, EventArgs e) {
         foreach (var mdi in MdiChildren)
            mdi.WindowState = FormWindowState.Minimized;
         LayoutMdi(MdiLayout.ArrangeIcons);
         adjustMenuAndToolbar();
      }

      private void ToolStripMenuItem_Cascade_Click(object sender, EventArgs e) {
         LayoutMdi(MdiLayout.Cascade);
         adjustMenuAndToolbar();
      }

      private void ToolStripMenuItem_Horizontal_Click(object sender, EventArgs e) {
         LayoutMdi(MdiLayout.TileHorizontal);
         adjustMenuAndToolbar();
      }

      private void ToolStripMenuItem_Vertical_Click(object sender, EventArgs e) {
         LayoutMdi(MdiLayout.TileVertical);
         adjustMenuAndToolbar();
      }

      //private void ToolStripMenuItemWindow_Click(object sender, EventArgs e) {
      //   PdfViewForm pdfform = getPdfViewForm4MenuItem(sender as ToolStripMenuItem);
      //   if (pdfform != null)
      //      pdfform.Activate();
      //}

      private void ToolStripMenuItem_RotateLeft_Click(object sender, EventArgs e) {
         toolStripButton_RotateLeft_Click(null, null);
      }

      private void ToolStripMenuItem_RotateRight_Click(object sender, EventArgs e) {
         toolStripButton_RotateRight_Click(null, null);
      }

      private void ToolStripMenuItem_Remove_Click(object sender, EventArgs e) {
         toolStripButton_Remove_Click(null, null);
      }

      private void ToolStripMenuItem_PageView_Click(object sender, EventArgs e) {
         showSelectedPage();
      }

      private void ToolStripMenuItem_ScanPage_Click(object sender, EventArgs e) {
         toolStripButton_Scan_Click(null, null);
      }
      private void ToolStripMenuItem_MarkAllPages_Click(object sender, EventArgs e) {
         actualPdfViewForm?.PdfPages.SelectAllItems();
      }

      #endregion

      #region ClipboardViewer (native)

      void OnClipboardChanged() {
         Debug.WriteLine(">>> OnClipboardChanged");
         adjustMenuAndToolbar();
      }

      IntPtr hWndNextViewer = IntPtr.Zero;

      void AddClipboardViewer() {
         if (hWndNextViewer == IntPtr.Zero)
            hWndNextViewer = SetClipboardViewer(Handle);
      }

      void RemoveClipboardViewer() {
         ChangeClipboardChain(Handle, hWndNextViewer);
      }

      /// <summary>
      /// Adds the specified window to the chain of clipboard viewers. Clipboard viewer windows receive a WM_DRAWCLIPBOARD message 
      /// whenever the content of the clipboard changes. This function is used for backward compatibility with earlier versions of Windows.
      /// </summary>
      /// <param name="hWndNewViewer">A handle to the window to be added to the clipboard chain.</param>
      /// <returns>If the function succeeds, the return value identifies the next window in the clipboard viewer chain. 
      /// If an error occurs or there are no other windows in the clipboard viewer chain, the return value is NULL. 
      /// To get extended error information, call GetLastError.</returns>
      [DllImport("User32.dll", CharSet = CharSet.Auto)]
      public static extern IntPtr SetClipboardViewer(IntPtr hWndNewViewer);

      /// <summary>
      /// Removes a specified window from the chain of clipboard viewers.
      /// </summary>
      /// <param name="hWndRemove"></param>
      /// <param name="hWndNewNext"></param>
      /// <returns></returns>
      [DllImport("User32.dll", CharSet = CharSet.Auto)]
      public static extern bool ChangeClipboardChain(IntPtr hWndRemove, IntPtr hWndNewNext);

      /// <summary>
      /// Sends the specified message to a window or windows. The SendMessage function calls the window procedure for the specified window 
      /// and does not return until the window procedure has processed the message.
      /// </summary>
      /// <param name="hwnd"></param>
      /// <param name="wMsg"></param>
      /// <param name="wParam"></param>
      /// <param name="lParam"></param>
      /// <returns></returns>
      [DllImport("user32.dll", CharSet = CharSet.Auto)]
      public static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);

      protected override void WndProc(ref Message m) {
         const int WM_DRAWCLIPBOARD = 0x0308;      /* Sent to the first window in the clipboard viewer chain when the content of the clipboard changes. 
                                                      This enables a clipboard viewer window to display the new content of the clipboard. */
         const int WM_CHANGECBCHAIN = 0x030D;      // Sent to the first window in the clipboard viewer chain when a window is being removed from the chain.

         switch (m.Msg) {
            case WM_DRAWCLIPBOARD:
               OnClipboardChanged();
               SendMessage(hWndNextViewer, m.Msg, m.WParam, m.LParam);
               break;

            case WM_CHANGECBCHAIN:
               if (m.WParam == hWndNextViewer)
                  hWndNextViewer = m.LParam;
               else
                  SendMessage(hWndNextViewer, m.Msg, m.WParam, m.LParam);
               break;

            default:
               base.WndProc(ref m);
               break;
         }
      }

      #endregion

      #region Scannerconfiguration

      /// <summary>
      /// Kann ein Scanner verwendet werden?
      /// </summary>
      public bool ScannerIsInit {
         get => scanner != null;
      }

      Scanner scanner;

      List<PaperSizeItem> papersizelist = new List<PaperSizeItem>();

      List<int> dpilist = new List<int>();

      string ScannerName {
         get => scanner != null ? button_Scanner.Text : "";
         set => button_Scanner.Text = value;
      }

      int Dpi {
         get => scanner != null ? dpilist[comboBox_DPI.SelectedIndex] : 0;
         set {
            if (scanner != null) {
               for (int i = 0; i < dpilist.Count; i++) {
                  if (dpilist[i] == value) {
                     comboBox_DPI.SelectedIndex = i;
                     break;
                  }
               }
            }
         }
      }

      PaperSizeItem PaperSize {
         get => scanner != null ? papersizelist[comboBox_PaperSize.SelectedIndex] : null;
         set {
            if (scanner != null) {
               for (int i = 0; i < papersizelist.Count; i++) {
                  if (papersizelist[i].PaperSize == value.PaperSize &&
                      papersizelist[i].Portrait == value.Portrait) {
                     comboBox_PaperSize.SelectedIndex = i;
                     break;
                  }
               }
            }
         }
      }

      Scanner.ImageType ImageType {
         get {
            if (scanner != null) {
               if (radioButton_Color.Checked)
                  return Scanner.ImageType.Color;
               if (radioButton_Grayscale.Checked)
                  return Scanner.ImageType.Grayscale;
               if (radioButton_BlackWhite.Checked)
                  return Scanner.ImageType.Text;
            }
            return Scanner.ImageType.Nothing;
         }
         set {
            switch (value) {
               case Scanner.ImageType.Nothing:
               case Scanner.ImageType.Color: radioButton_Color.Checked = true; break;
               case Scanner.ImageType.Grayscale: radioButton_Grayscale.Checked = true; break;
               case Scanner.ImageType.Text: radioButton_BlackWhite.Checked = true; break;
            }
         }
      }

      /// <summary>
      /// -1 .. +1
      /// </summary>
      double Brightness {
         get => scanner != null ? (double)numericUpDown_Brightness.Value / 100 : 0;
         set {
            numericUpDown_Brightness.Value = (int)(value * 100);
         }
      }

      /// <summary>
      /// -1 .. +1
      /// </summary>
      double Contrast {
         get => scanner != null ? (double)numericUpDown_Contrast.Value / 100 : 0;
         set {
            numericUpDown_Contrast.Value = (int)(value * 100);
         }
      }

      string Filetype {
         get {
            if (radioButton_BMP.Checked)
               return "BMP";
            if (radioButton_JPG.Checked)
               return "JPG";
            if (radioButton_PNG.Checked)
               return "PNG";
            if (radioButton_TIF.Checked)
               return "TIF";
            return null;
         }
         set {
            if (value == "BMP")
               radioButton_BMP.Checked = true;
            if (value == "JPG")
               radioButton_JPG.Checked = true;
            if (value == "PNG")
               radioButton_PNG.Checked = true;
            if (value == "TIF")
               radioButton_TIF.Checked = true;
         }
      }

      int Quali {
         get => (int)numericUpDown_JPGQuali.Value;
         set => numericUpDown_JPGQuali.Value = value;
      }

      double DeltaX {
         get => (double)numericUpDown_DeltaX.Value;
         set => numericUpDown_DeltaX.Value = (decimal)value;
      }

      double DeltaY {
         get => (double)numericUpDown_DeltaY.Value;
         set => numericUpDown_DeltaY.Value = (decimal)value;
      }


      public class PaperSizeItem {

         public Scanner.PaperSize PaperSize {
            get;
            protected set;
         }

         public bool Portrait {
            get;
            protected set;
         }


         public PaperSizeItem(Scanner.PaperSize papersize, bool portrait) {
            PaperSize = papersize;
            Portrait = portrait;
         }

         override public string ToString() {
            return PaperSize.ToString() + " " + Portrait;
         }
      }


      void startScannerSideboard() {
         numericUpDown_JPGQuali.Value = 90;
         radioButton_JPG_CheckedChanged(null, null);
         init4Scanner(null);
         loadScannerStatus();
      }

      void scannerDataChanged() {
         saveScannerStatus();
         adjustMenuAndToolbar();
      }

      void init4Scanner(Scanner scanner) {
         comboBox_DPI.Items.Clear();
         comboBox_PaperSize.Items.Clear();
         papersizelist.Clear();
         dpilist.Clear();

         if (scanner != null) {

            comboBox_PaperSize.Enabled =
            comboBox_DPI.Enabled =
            groupBox1.Enabled =
            groupBox2.Enabled =
            numericUpDown_Brightness.Enabled =
            numericUpDown_Contrast.Enabled =
            numericUpDown_DeltaX.Enabled =
            numericUpDown_DeltaY.Enabled = true;

            ScannerName = scanner.Name();

            if (scanner != null) {

               bool error = false;
               try {
                  List<int> dpilst = scanner.GetProperties(out int left,
                                                           out int top,
                                                           out int widthpixel,
                                                           out int heightpixel,
                                                           out Scanner.ImageType imgtype,
                                                           out Scanner.ImageTypeExt imgtypeext,
                                                           out double brightness,
                                                           out double contrast,
                                                           out int dpi);
                  foreach (var item in dpilst) {
                     dpilist.Add(item);
                     comboBox_DPI.Items.Add(item);
                  }
                  Dpi = dpi;

                  ImageType = imgtype;

                  foreach (var item in scanner.GetValidPaperFormats()) {
                     comboBox_PaperSize.Items.Add(string.Format("{0}, {1}, {2:0} mm x {3:0} mm",
                                                                item.PaperSize.ToString(),
                                                                item.Width < item.Height ? "Hochformat" : "Querformat",
                                                                item.Width,
                                                                item.Height));
                     papersizelist.Add(new PaperSizeItem(item.PaperSize, item.Width < item.Height));
                  }

                  PaperSizeItem psi = getPaperSizeItem((int)Math.Round(widthpixel / 25.4), (int)Math.Round(heightpixel / 25.4));
                  if (psi != null)
                     PaperSize = psi;
                  else
                     PaperSize = papersizelist[0];

                  Brightness = brightness;
                  Contrast = contrast;
                  Filetype = "JPG";

                  numericUpDown_JPGQuali.Enabled = false;

               } catch (COMException ex) {
                  showError(ErrorCodes.GetErrorText((uint)ex.ErrorCode));
                  error = true;
               } catch (Exception ex) {
                  showError(ex.Message);
                  error = true;
               } finally {
                  if (error) {
                     scanner = null;
                     init4Scanner(scanner);
                     scannerDataChanged();
                  }
               }
            }

         } else {

            comboBox_PaperSize.Enabled =
            comboBox_DPI.Enabled =
            groupBox1.Enabled =
            groupBox2.Enabled =
            numericUpDown_Brightness.Enabled =
            numericUpDown_Contrast.Enabled =
            numericUpDown_DeltaX.Enabled =
            numericUpDown_DeltaY.Enabled = false;
            ScannerName = "Scannerauswahl";

         }
      }

      PaperSizeItem getPaperSizeItem(int widthmm, int heightmm) {
         foreach (var item in scanner.GetValidPaperFormats()) {
            if (item.Width == widthmm &&
                item.Height == heightmm)
               return new PaperSizeItem(item.PaperSize, item.Width < item.Height);
         }
         return null;
      }

      private void button_Scanner_Click(object sender, EventArgs e) {
         Scanner oldscanner = scanner;
         try {
            scanner = Scanner.Connect(-1);
            init4Scanner(scanner);
         } catch (COMException ex) {
            showError(ErrorCodes.GetErrorText((uint)ex.ErrorCode));
         } catch (Exception ex) {
            showError(ex.Message);
         }
         if ((oldscanner != null) != (scanner != null))
            scannerDataChanged();
      }

      private void radioButton_JPG_CheckedChanged(object sender, EventArgs e) {
         numericUpDown_JPGQuali.Enabled = radioButton_JPG.Checked;
      }

      void showError(string message) {
         MessageBox.Show(message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      public Bitmap GetImageFromScanner(out double widthmm, out double heightmm) {
         widthmm = heightmm = 0;
         if (scanner == null)
            return null;

         bool error = false;
         try {

            scanner.GetPaperSize(PaperSize.PaperSize, out double w, out double h);
            widthmm = w;
            heightmm = h;
            if (!PaperSize.Portrait) {
               double tmp = widthmm;
               widthmm = heightmm;
               heightmm = tmp;
            }

            scanner.SetProperties(Dpi,
                                  (double)numericUpDown_DeltaX.Value, (double)numericUpDown_DeltaY.Value,
                                  PaperSize.PaperSize,
                                  PaperSize.Portrait,
                                  ImageType,
                                  Scanner.ImageTypeExt.Nothing,
                                  Brightness,
                                  Contrast);
            Bitmap scanbm = scanner.GetImage(true, Dpi, Dpi);

            //// reale Größe ermitteln
            //w = 25.4 * scanbm.Width / scanbm.HorizontalResolution;
            //h = 25.4 * scanbm.Height / scanbm.VerticalResolution;

            return convertBitmap(scanbm,
                                 radioButton_JPG.Checked ? ImageFormat.Jpeg :
                                    radioButton_PNG.Checked ? ImageFormat.Png :
                                    radioButton_TIF.Checked ? ImageFormat.Tiff :
                                    ImageFormat.Bmp,
                                 (int)numericUpDown_JPGQuali.Value);

         } catch (COMException ex) {
            showError(ErrorCodes.GetErrorText((uint)ex.ErrorCode));
            error = true;
         } catch (Exception ex) {
            showError(ex.Message);
            error = true;
         } finally {
            if (error) {
               scanner = null;
               init4Scanner(scanner);
               scannerDataChanged();
            }
         }
         return null;
      }

      static Bitmap convertBitmap(Bitmap bm, ImageFormat format, int jpegquali = 90) {
         if (bm != null) {
            MemoryStream ms = new MemoryStream();

            if (!format.Equals(ImageFormat.Jpeg))
               bm.Save(ms, format);
            else {

               // Create an Encoder object based on the GUID for the Quality parameter category.
               System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
               // Create an EncoderParameters object. In this case, there is only one
               // EncoderParameter object in the array.
               EncoderParameters myEncoderParameters = new EncoderParameters(1);
               // Save the bitmap with quality level ...
               EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, Convert.ToInt32(jpegquali));
               myEncoderParameters.Param[0] = myEncoderParameter;
               // Get an ImageCodecInfo object that represents the JPEG codec.
               ImageCodecInfo myImageCodecInfo = null;
               ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
               for (int j = 0; j < encoders.Length; j++)
                  if (encoders[j].MimeType == "image/jpeg")
                     myImageCodecInfo = encoders[j];
               if (myImageCodecInfo != null)
                  bm.Save(ms, myImageCodecInfo, myEncoderParameters);
            }

            if (ms.Length > 0)
               return new Bitmap(ms);
         }
         return null;
      }

      void saveScannerStatus() {
         if (appData != null) {
            appData.ScannerName = ScannerName;
            appData.ScannerDpi = (uint)Dpi;
            appData.ScannerContrast = Contrast;
            appData.ScannerBrightness = Brightness;
            appData.ScannerImageType = ImageType.ToString();
            appData.ScannerPaperSize = PaperSize != null ? PaperSize.ToString() : "";
            appData.ScannerFiletype = Filetype;
            appData.ScannerQuali = Quali;
            appData.ScannerDeltaX = DeltaX;
            appData.ScannerDeltaY = DeltaY;
         }
      }

      void loadScannerStatus() {
         if (appData != null) {

            Cursor orgcursor = Cursor;
            Scanner oldscanner = scanner;
            try {
               Cursor = Cursors.WaitCursor;
               if (!string.IsNullOrEmpty(appData.ScannerName)) {
                  scanner = getScanner4Name(appData.ScannerName);
                  if (scanner != null) {
                     init4Scanner(scanner);

                     foreach (var item in Enum.GetValues(typeof(Scanner.ImageType))) {
                        if (item.ToString() == appData.ScannerImageType) {
                           ImageType = (Scanner.ImageType)item;
                           break;
                        }
                     }

                     int dpi = (int)appData.ScannerDpi;
                     if (dpi > 0)
                        Dpi = dpi;

                     string[] papersize = appData.ScannerPaperSize.Split(' ');
                     if (papersize.Length == 2) {
                        bool portrait = Convert.ToBoolean(papersize[1]);
                        foreach (var item in Enum.GetValues(typeof(Scanner.PaperSize))) {
                           if (item.ToString() == papersize[0]) {
                              PaperSize = new PaperSizeItem((Scanner.PaperSize)item, portrait);
                              break;
                           }
                        }
                     }

                     double contrast = appData.ScannerContrast;
                     if (-1 <= contrast && contrast <= 1)
                        Contrast = contrast;

                     double brightness = appData.ScannerBrightness;
                     if (-1 <= brightness && brightness <= 1)
                        Brightness = brightness;

                     Filetype = appData.ScannerFiletype;

                     double quali = appData.ScannerQuali;
                     if (0 < quali && quali <= 100)
                        Quali = (int)quali;

                     DeltaX = appData.ScannerDeltaX;
                     DeltaY = appData.ScannerDeltaY;

                  }
               }
            } catch (Exception ex) {
               Cursor = orgcursor;
               showError(ex.Message);
            }
            Cursor = orgcursor;

            if ((oldscanner != null) != (scanner != null))
               scannerDataChanged();
         }
      }

      Scanner getScanner4Name(string name) {
         Scanner.GetScannerList(out List<string> names);
         for (int i = 0; i < names.Count; i++) {
            if (names[i] == name) {
               return Scanner.Connect(i);
            }
         }
         return null;
      }

      private void buttonScannerSideboard_Click(object sender, EventArgs e) {
         Button btn = (sender as Button);
         panelScannersideboard.Width = panelScannersideboard.Width > btn.Width ?
                                          btn.Width :
                                          stdPanelScannersideboardWidth;
         btn.Image = btn.Width < panelScannersideboard.Width ?
                        Properties.Resources.TriangleRight :
                        Properties.Resources.TriangleLeft;
      }

      #endregion

   }
}
