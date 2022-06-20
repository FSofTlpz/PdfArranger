//#define USE_PDFSHARP
#define USE_ITEXT7
using Ghostscript.NET;
#if USE_PDFSHARP
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
#else
#if USE_ITEXT7
using iText.IO.Image;
using iText.Kernel.Exceptions;
using iText.Kernel.Pdf;
using iText.Kernel.Pdf.Xobject;
using iText.Layout;
#endif
#endif
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;

namespace PdfArranger {

   /// <summary>
   /// beinhaltet die eigentliche Arbeit mit PDF-Dateien
   /// </summary>
   public class PdfFileWrapper : IDisposable {

      public class PasswordProviderArgs {
         /// <summary>
         /// für diese Datei
         /// </summary>
         public string Filename {
            get;
            protected set;
         }

         /// <summary>
         /// Passwort das geliefert wird
         /// </summary>
         public string Password;

         /// <summary>
         /// bei true Abbruch der Passwort-Abfrage
         /// </summary>
         public bool Abort;

         public PasswordProviderArgs(string filename, string password) {
            Filename = filename;
            Password = password;
            Abort = false;
         }

      }

      /// <summary>
      /// delegate für eine Funktion um ein Passwort anzufordern
      /// </summary>
      public delegate void PasswordProvider(PasswordProviderArgs args);

      public class PageItem {

         public int FileID {
            get;
            protected set;
         }

         /// <summary>
         /// Seitennummer, 1...
         /// </summary>
         public int PageNo {
            get;
            protected set;
         }

         public bool IsImagefile {
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


         public PageRotationType PageRotationType {
            get;
            protected set;
         }

         public PageItem(int fileid, int pageno, PageRotationType rotation) {
            FileID = fileid;
            PageNo = pageno;
            PageRotationType = rotation;
            Image = null;
         }

         public PageItem(Image image, PageRotationType rotation, SizeF imagesize) {
            FileID = -1;
            PageNo = -1;
            PageRotationType = rotation;
            Image = image;
            ImageSize = imagesize;
         }

         public override string ToString() {
            return string.Format("ID {0}, PageNo {1}, Rotation {2}", FileID, PageNo, PageRotationType);
         }

      }


      /// <summary>
      /// ID der PDF-Datei
      /// </summary>
      public int FileID {
         get;
         protected set;
      }

      /// <summary>
      /// Dateiname
      /// </summary>
      public string Filename {
         get => pdffiles4id[FileID];
      }

      /// <summary>
      /// Passwort der Datei
      /// </summary>
      public string Password {
         get => pdfpasswords4id[FileID];
         protected set => pdfpasswords4id[FileID] = value;
      }

      /// <summary>
      /// Standard-Seitengröße (in mm)
      /// </summary>
      public RectangleF PdfDefaultPageSize { get; protected set; }
      /// <summary>
      /// Anzahl der Seiten des Dokumentes
      /// </summary>
      public int PdfGetNumberOfPages { get; protected set; }
      /// <summary>
      /// PDF-Version des Dokumentes
      /// </summary>
      public string PdfVersion { get; protected set; }
      /// <summary>
      /// Author des Dokumentes
      /// </summary>
      public string PdfAuthor { get; protected set; }
      public string PdfCreator { get; protected set; }
      public string PdfKeywords { get; protected set; }
      public string PdfProducer { get; protected set; }
      /// <summary>
      /// Thema des Dokumentes
      /// </summary>
      public string PdfSubject { get; protected set; }
      /// <summary>
      /// Titel des Dokumentes
      /// </summary>
      public string PdfTitle { get; protected set; }
      /// <summary>
      /// Größe aller Seiten (in mm)
      /// </summary>
      public List<RectangleF> PdfPageSizes { get; protected set; }


      public enum PageRotationType {
         /// <summary>
         /// 0°
         /// </summary>
         None,
         /// <summary>
         /// -90°
         /// </summary>
         Left90,
         /// <summary>
         /// 90°
         /// </summary>
         Right90,
         /// <summary>
         /// 180°
         /// </summary>
         Right180
      }

      // bekannte Permissions einer PDF-Datei
      const long PERMISSION_PRINT = 1 << 2;
      const long PERMISSION_MODIFY = 1 << 3;
      const long PERMISSION_COPY = 1 << 4;
      const long PERMISSION_ANNOTATE = 1 << 5;
      const long PERMISSION_FILLFORMS = 1 << 8;
      const long PERMISSION_EXTRACT = 1 << 9;
      const long PERMISSION_ASSEMBLE = 1 << 10;
      const long PERMISSION_PRINTHIGHRES = 1 << 11;

      PasswordProvider passwordProvider;

      /// <summary>
      /// Dateiname zum Datei-Key
      /// </summary>
      static Dictionary<int, string> pdffiles4id = new Dictionary<int, string>();

      /// <summary>
      /// Passwort zum Datei-Key
      /// </summary>
      static Dictionary<int, string> pdfpasswords4id = new Dictionary<int, string>();

      /// <summary>
      /// eindeutige Datei-ID
      /// </summary>
      static int pdffileid = 1;

      #region static-Daten für Ghostscript

      static Ghostscript.NET.Rasterizer.GhostscriptRasterizer ghostscriptRasterizer = null;

      static GhostscriptVersionInfo gvi;

      static bool ghostscriptRasterizerIsOpen = false;

      static string actualGhostscriptFile;

      #endregion


      static PdfFileWrapper() {
         // Init. Ghostscript
         if (ghostscriptRasterizer == null)
            ghostscriptRasterizer = new Ghostscript.NET.Rasterizer.GhostscriptRasterizer();
         gvi = new GhostscriptVersionInfo(new Version(0, 0, 0),
                                          Path.Combine(Directory.GetCurrentDirectory(), System.Environment.Is64BitProcess ? "gsdll64.dll" : "gsdll32.dll"),
                                          string.Empty,
                                          GhostscriptLicense.GPL);
         ghostscriptRasterizerIsOpen = false;

         AppDomain.CurrentDomain.ProcessExit += CurrentDomain_ProcessExit;
      }

      public PdfFileWrapper(string filename, PasswordProvider passwordProvider, string password = null) {
         FileID = RegisterFile(filename, password);
         this.passwordProvider = passwordProvider;
         PdfPageSizes = new List<RectangleF>();
      }

      #region File-ID-Funktionen

      public static int RegisterFile(string filename, string password) {
         int id = GetFileID(filename);
         if (id < 0) {
            id = ++pdffileid;
            pdffiles4id.Add(id, filename);
            pdfpasswords4id.Add(id, password);
         } else
            pdfpasswords4id[id] = password;     // ev. neu
         return id;
      }

      /// <summary>
      /// liefert die Datei-ID
      /// </summary>
      /// <param name="filename"></param>
      /// <returns></returns>
      public static int GetFileID(string filename) {
         foreach (var item in pdffiles4id)
            if (item.Value == filename)
               return item.Key;
         return -1;
      }

      public static string PdfFile(int id) {
         return pdffiles4id[id];
      }

      public static string PdfPassword(int id) {
         return pdfpasswords4id[id];
      }

      #endregion

      /// <summary>
      /// Falls <see cref="Password"/> nicht korrekt ist, wird es abgfragt und korrigiert. Wenn true geliefert wird ist <see cref="Password"/> korrekt gesetzt.
      /// </summary>
      /// <returns></returns>
      public bool PasswordIsRight() {
         return checkAndSetPassword(passwordProvider);
      }

      /// <summary>
      /// für Aufräumarbeiten der static-Elemente
      /// </summary>
      /// <param name="sender"></param>
      /// <param name="e"></param>
      private static void CurrentDomain_ProcessExit(object sender, EventArgs e) {
         ghostscriptRasterizerClose();
         ghostscriptRasterizer.Dispose();
      }

      #region static-Funktionen um auf Ghostscript zuzugreifen

      static bool ghostscriptRasterizerOpen(string pdffile, string password, GhostscriptVersionInfo gvi) {
         if (pdffile != actualGhostscriptFile ||
             !ghostscriptRasterizerIsOpen) {
            if (ghostscriptRasterizerIsOpen)
               ghostscriptRasterizerClose();

            if (!string.IsNullOrEmpty(password))
               ghostscriptRasterizer.CustomSwitches.Add("-sPDFPassword=" + password);

            ghostscriptRasterizer.Open(pdffile, gvi, false);
            ghostscriptRasterizerIsOpen = true;
            actualGhostscriptFile = pdffile;
         }
         return ghostscriptRasterizerIsOpen;
      }

      static void ghostscriptRasterizerClose() {
         if (ghostscriptRasterizerIsOpen) {
            ghostscriptRasterizer.Close();
            ghostscriptRasterizer.CustomSwitches.Clear();
            ghostscriptRasterizerIsOpen = false;
            actualGhostscriptFile = "";
         }
      }

      static void ghostscriptRasterizerClose4(string pdffile) {
         if (ghostscriptRasterizerIsOpen &&
             pdffile == actualGhostscriptFile) {
            ghostscriptRasterizer.Close();
            ghostscriptRasterizer.CustomSwitches.Clear();
            ghostscriptRasterizerIsOpen = false;
            actualGhostscriptFile = "";
         }
      }

      static Image ghostscriptGetPageImage(string pdffile, string password, int page = -1, int dpi = 300) {
         try {
            ghostscriptRasterizerOpen(pdffile, password, gvi);
            if (ghostscriptRasterizerIsOpen) {
               if (0 <= page && page < ghostscriptRasterizer.PageCount)
                  return ghostscriptRasterizer.GetPage(dpi, page + 1);
            }
         } catch {
         }
         return null;
      }

      #endregion


      /// <summary>
      /// liefert die Seitenanzahl der Datei
      /// <para>Es wird von Ghostscript verwendet.</para>
      /// </summary>
      /// <returns></returns>
      public int PageCount() {
         ghostscriptRasterizerOpen(Filename, Password, gvi);
         return ghostscriptRasterizerIsOpen ?
                     ghostscriptRasterizer.PageCount :
                     -1;
      }

      /// <summary>
      /// liefert eine Liste von Bildern für den Seitenbereich
      /// </summary>
      /// <param name="pagefrom"></param>
      /// <param name="pageto"></param>
      /// <param name="dpi"></param>
      /// <returns></returns>
      public List<Image> GetPageImages(int pagefrom, int pageto, int dpi = 300) {
         List<Image> imgList = new List<Image>();
         for (int p = pagefrom; p <= pageto; p++)
            imgList.Add(ghostscriptGetPageImage(Filename, Password, p, dpi));
         return imgList;
      }

      /// <summary>
      /// liefert eine Liste von Bildern für die Liste der Seitennummern
      /// </summary>
      /// <param name="pages"></param>
      /// <param name="dpi"></param>
      /// <returns></returns>
      public List<Image> GetPageImages(IList<int> pages, int dpi = 300) {
         List<Image> imgList = new List<Image>();
         foreach (int p in pages)
            imgList.Add(ghostscriptGetPageImage(Filename, Password, p, dpi));
         return imgList;
      }

      /// <summary>
      /// liefert das Bild einer Seite in der gewünschten Auflösung
      /// <para>Das Bild wird von Ghostscript geliefert.</para>
      /// </summary>
      /// <param name="page"></param>
      /// <param name="dpi"></param>
      /// <returns></returns>
      public Image GetPageImage(int page = -1, int dpi = 300) {
         return ghostscriptGetPageImage(Filename, Password, page, dpi);
      }

      public void WritePagesToFile(IList<PageItem> pages, string destfile = null) {
         if (string.IsNullOrEmpty(destfile))
            destfile = Filename;

         ghostscriptRasterizerClose4(Filename);
#if USE_PDFSHARP
         pdfSharpWrite2File(pages, destfile);
#else
#if USE_ITEXT7
         pdfIText7pWrite2File(pages, destfile);
#endif
#endif
      }


#if USE_PDFSHARP

      #region PdfSharp-Funktionen

      PdfDocument pdfSharpDocument;

      bool pdfSharpIsOpen4PageRead = false;

      bool pdfSharpOpen(PasswordProvider passwordProvider) {
         if (!pdfSharpIsOpen4PageRead) {
            bool tryagain = false;
            string password = Password;
            internalPasswordProvider = passwordProvider;
            do {
               try {
                  pdfSharpDocument = PdfReaderExt.Open(Filename, password, PdfDocumentOpenMode.ReadOnly, pdfSharpPasswordProvider);
               } catch (Exception ex) {
                  if (ex.Message == PdfReaderExt.UnknownEncryption) {   // -> Versuch einfach weiter zu machen
                     password = null;
                     if (!tryagain)
                        tryagain = true;
                  } else
                     throw new Exception(ex.Message);
               }
            } while (tryagain);
            pdfSharpIsOpen4PageRead = pdfSharpDocument != null;
         }
         return pdfSharpIsOpen4PageRead;
      }

      void pdfSharpClose() {
         if (pdfSharpDocument != null) {
            pdfSharpDocument.Close();
            pdfSharpDocument.Dispose();
            pdfSharpDocument = null;
         }
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="src"></param>
      /// <param name="pageno">1, ..</param>
      /// <param name="rotation"></param>
      /// <returns></returns>
      PdfPage pdfSharpAddPage(PdfFileWrapper src, int pageno, PageRotationType rotation) {
         if (src.pdfSharpOpen(passwordProvider)) {

            PdfPage page = src.pdfSharpDocument.Pages[pageno - 1];
            if (rotation != PageRotationType.None) {
               switch (rotation) {
                  case PageRotationType.Left90:
                     page.Rotate = 270;
                     break;

                  case PageRotationType.Right90:
                     page.Rotate = 90;
                     break;

                  case PageRotationType.Right180:
                     page.Rotate = 180;
                     break;
               }
            }

            if (pdfSharpDocument == null)
               pdfSharpDocument = new PdfDocument();

            return pdfSharpDocument.AddPage(page);

         } else
            throw new Exception("Die Seite " + pageno + " der Datei '" + src.Filename + "' konnte nicht gelesen werden.");
      }

      void pdfSharpWrite2File(IList<PageItem> pages, string destfile) {
         Dictionary<int, PdfFileWrapper> input = new Dictionary<int, PdfFileWrapper>();

         pdfSharpDocument = new PdfDocument();
         for (int i = 0; i < pages.Count; i++) {
            PdfFileWrapper inp = null;
            if (input.ContainsKey(pages[i].FileID))
               inp = input[pages[i].FileID];
            else {
               inp = new PdfFileWrapper(pdffiles4id[pages[i].FileID], passwordProvider, pdfpasswords4id[pages[i].FileID]);
               input.Add(pages[i].FileID, inp);
            }

            pdfSharpAddPage(inp, pages[i].PageNo, pages[i].PageRotationType);

         }
         pdfSharpDocument.Save(destfile);
         pdfSharpClose();

         foreach (var item in input) {
            item.Value.pdfSharpClose();
         }
      }

      void pdfSharpPasswordProvider(PdfPasswordProviderArgs args) {
         PasswordProviderArgs newargs = new PasswordProviderArgs() {
            Password = args.Password,
            Abort = args.Abort,
         };

         internalPasswordProvider?.Invoke(newargs);

         args.Password = newargs.Password;
         args.Abort = newargs.Abort;
      }

      #endregion

#endif

#if USE_ITEXT7

      PdfDocument pdfIText7Document;

      bool pdfIText7IsOpen4PageRead = false;

      void pdfIText7pWrite2File(IList<PageItem> pages, string destfile) {
         Dictionary<int, PdfFileWrapper> input = new Dictionary<int, PdfFileWrapper>();

         using (PdfWriter pdfWriter = new PdfWriter(destfile)) {
            pdfIText7Document = new PdfDocument(pdfWriter);

            try {
               for (int i = 0; i < pages.Count; i++) {
                  if (pages[i].IsImagefile) {
                     iText.Kernel.Geom.PageSize pagesize = iText.Kernel.Geom.PageSize.A4; // Dummy
                     if (pages[i].ImageSize != SizeF.Empty)
                        pagesize = new iText.Kernel.Geom.PageSize(UserUnits4mm(pages[i].ImageSize.Width),
                                                                  UserUnits4mm(pages[i].ImageSize.Height));
                     pdfIText7AddPage(pages[i].Image,
                                      pages[i].PageRotationType,
                                      pagesize);
                  } else {
                     PdfFileWrapper inp = null;
                     if (input.ContainsKey(pages[i].FileID))
                        inp = input[pages[i].FileID];
                     else {
                        inp = new PdfFileWrapper(pdffiles4id[pages[i].FileID], passwordProvider, pdfpasswords4id[pages[i].FileID]);
                        input.Add(pages[i].FileID, inp);
                     }
                     pdfIText7AddPage(inp,
                                      pages[i].PageNo,
                                      pages[i].PageRotationType);
                  }
               }
            } catch (Exception ex) {

            } finally {
               pdfIText7Document.Close();
               pdfIText7Document = null;

               foreach (var item in input) {
                  item.Value.pdfIText7Close();
               }
            }
         }
      }

      bool pdfIText7Open4Read(PasswordProvider passwordProvider) {
         if (!pdfIText7IsOpen4PageRead) {
            (bool, PdfDocument) result = checkAndSetPassword(passwordProvider, true);
            pdfIText7IsOpen4PageRead = result.Item1;
            pdfIText7Document = result.Item2;
         }
         return pdfIText7IsOpen4PageRead;
      }

      int getUserUnit(PdfPage page) {
         // 1 inch = 25.4 mm = 72 user units
         PdfDictionary pageDict = page.GetPdfObject();
         PdfNumber userUnit = pageDict?.GetAsNumber(PdfName.UserUnit);
         return userUnit != null ?
                     (int)userUnit.GetValue() :
                     72;                        // wenn nicht def. dann default
      }

      //byte[] image2ByteArray(Image img) {
      //   using (MemoryStream mStream = new MemoryStream()) {
      //      img.Save(mStream, System.Drawing.Imaging.ImageFormat.Bmp);
      //      return mStream.ToArray();
      //   }
      //}


      /// <summary>
      /// ermittelt einige allgemeine Infos zum Dokument und die Seitengrößen
      /// </summary>
      /// <param name="orgpageno"></param>
      /// <returns></returns>
      public void ReadPdfInfos() {
         PdfPageSizes = new List<RectangleF>();
         if (pdfIText7Open4Read(passwordProvider)) {
            iText.Kernel.Geom.PageSize dps = pdfIText7Document.GetDefaultPageSize();
            PdfDefaultPageSize = new RectangleF(Mm4UserUnits(dps.GetLeft()),
                                                Mm4UserUnits(dps.GetTop()),
                                                Mm4UserUnits(dps.GetWidth()),
                                                Mm4UserUnits(dps.GetHeight()));

            PdfGetNumberOfPages = pdfIText7Document.GetNumberOfPages();
            PdfVersion = pdfIText7Document.GetPdfVersion().ToString();
            PdfDocumentInfo pdi = pdfIText7Document.GetDocumentInfo();
            PdfAuthor = pdi.GetAuthor();
            PdfCreator = pdi.GetCreator();
            PdfKeywords = pdi.GetKeywords();
            PdfProducer = pdi.GetProducer();
            PdfSubject = pdi.GetSubject();
            PdfTitle = pdi.GetTitle();

            for (int i = 1; i <= PdfGetNumberOfPages; i++)
               PdfPageSizes.Add(getPageSize(pdfIText7Document.GetPage(i)));

            pdfIText7Close();
         }
      }

      /// <summary>
      /// liefert die Seitengröße (in mm)
      /// </summary>
      /// <param name="page"></param>
      /// <returns></returns>
      RectangleF getPageSize(PdfPage page) {
         //iText.Kernel.Geom.Rectangle cb = page.GetCropBox();
         //iText.Kernel.Geom.Rectangle mb = page.GetMediaBox();
         iText.Kernel.Geom.Rectangle size = page.GetPageSize();
         int userUnit = getUserUnit(page);
         return new RectangleF(Mm4UserUnits(size.GetLeft(), userUnit),
                               Mm4UserUnits(size.GetTop(), userUnit),
                               Mm4UserUnits(size.GetWidth(), userUnit),
                               Mm4UserUnits(size.GetHeight(), userUnit));
      }


      /// <summary>
      /// PDF aus einer PDF-Datei übernehmen
      /// </summary>
      /// <param name="src"></param>
      /// <param name="orgpageno"></param>
      /// <param name="rotation"></param>
      /// <returns></returns>
      /// <exception cref="Exception"></exception>
      PdfPage pdfIText7AddPage(PdfFileWrapper src, int orgpageno, PageRotationType rotation) {
         if (src.pdfIText7Open4Read(passwordProvider)) {
            IList<PdfPage> pagelist;
            PdfPage page = null;
            bool trygraphic = false;

            try {

               pagelist = src.pdfIText7Document.CopyPagesTo(orgpageno, orgpageno, pdfIText7Document); // Seitenbereich von ... bis ... wird kopiert
               page = pagelist[0];
               PdfPageSizes.Add(getPageSize(page));

            } catch (BadPasswordException ex) {
               trygraphic = true;
            }

            if (trygraphic) {
               PdfPage orgpage = src.pdfIText7Document.GetPage(orgpageno);

               //iText.Kernel.Geom.Rectangle pagesize = orgpage.GetPageSize();
               // orgpage.GetPageSizeWithRotation();
               // orgpage.GetMediaBox();
               // orgpage.GetTrimBox();
               // int rot = orgpage.GetRotation();

               //double userunit = getUserUnit(orgpage);
               //double h = pagesize.GetHeight() / userunit;     // Höhe in Zoll
               //double w = pagesize.GetWidth() / userunit;      // Breite in Zoll

               PdfFormXObject pageCopy = orgpage.CopyAsFormXObject(pdfIText7Document);
               iText.Layout.Element.Image image = new iText.Layout.Element.Image(pageCopy);
               image.SetMargins(0, 0, 0, 0);
               image.SetFixedPosition(pdfIText7Document.GetNumberOfPages() + 1, 0, 0);
               //image.ScaleAbsolute(100, 200)

               Document document2 = new Document(pdfIText7Document);
               document2.SetMargins(0, 0, 0, 0);
               document2.Add(image);

               page = document2.GetPdfDocument().GetPage(1);
               PdfPageSizes.Add(getPageSize(page));
            }

            if (rotation != PageRotationType.None) {
               int rot = page.GetRotation();

               switch (rotation) {
                  case PageRotationType.Left90:
                     rot -= 90;
                     break;

                  case PageRotationType.Right90:
                     rot += 90;
                     break;

                  case PageRotationType.Right180:
                     rot += 180;
                     break;
               }
               while (rot >= 360)
                  rot -= 360;
               while (rot < 0)
                  rot += 360;
               page.SetRotation(rot);
            }

            return page;

         } else
            throw new Exception("Die Seite " + orgpageno + " der Datei '" + src.Filename + "' konnte nicht gelesen werden.");
      }

      /// <summary>
      /// Bild als PDF-Seite speichern
      /// </summary>
      /// <param name="img"></param>
      /// <param name="rotation"></param>
      /// <param name="pagesize"></param>
      /// <returns></returns>
      /// <exception cref="Exception"></exception>
      PdfPage pdfIText7AddPage(Image img, PageRotationType rotation, iText.Kernel.Geom.PageSize pagesize) {
         /*
static iText.Kernel.Geom.PageSize X = new iText.Kernel.Geom.PageSize(w, h)
   A0         2384, 3370
   A1         1684, 2384
   A2         1190, 1684
   A3         842, 1190
   A4         595, 842
   A5         420, 595
   A6         298, 420
   A7         210, 298
   A8         148, 210
   A9         105, 547
   A10        74, 105
   B0         2834, 4008
   B1         2004, 2834
   B2         1417, 2004
   B3         1000, 1417
   B4         708, 1000
   B5         498, 708
   B6         354, 498
   B7         249, 354
   B8         175, 249
   B9         124, 175
   B10        88, 124
   LETTER     612, 792
   LEGAL      612, 1008
   TABLOID    792, 1224
   LEDGER     1224, 792
   EXECUTIVE  522, 756
   Default    = A4
          */

         MemoryStream memoryStream = new MemoryStream();

         if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
            img.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);
         else
            img.Save(memoryStream, img.RawFormat);

         memoryStream.Position = 0;
         ImageData imageData = null;
         if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Png) ||
             img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.MemoryBmp))
            imageData = ImageDataFactory.CreatePng(memoryStream.ToArray());
         else if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Jpeg))
            imageData = ImageDataFactory.CreateJpeg(memoryStream.ToArray());
         else if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Bmp))
            imageData = ImageDataFactory.CreateBmp(memoryStream.ToArray(), true);
         else if (img.RawFormat.Equals(System.Drawing.Imaging.ImageFormat.Tiff))
            imageData = ImageDataFactory.CreateTiff(memoryStream.ToArray(), true, 0, true);
         else
            throw new Exception("Ungültiges Bildformat");

         //iText.Kernel.Geom.PageSize pagesize = iText.Kernel.Geom.PageSize.A4; // als Standard immer eine A4-Seite
         // beliebig: mm umrechnen in points (72 je Zoll):
         //    iText.Kernel.Geom.PageSize ps = new iText.Kernel.Geom.PageSize(new iText.Kernel.Geom.Rectangle(210 / 25.4F * 72, 297 / 25.4F * 72));

         float pageheight = pagesize.GetHeight();
         float pagewidth = pagesize.GetWidth();

         iText.Layout.Element.Image image = new iText.Layout.Element.Image(imageData);
         image.SetMargins(0, 0, 0, 0);
         image.ScaleToFit(pagewidth, pageheight);
         image.SetFixedPosition(pdfIText7Document.GetNumberOfPages() + 1,
                                (pagewidth - image.GetImageScaledWidth()) / 2,
                                (pageheight - image.GetImageScaledHeight()) / 2);   // Position links-unten! -> zentriert

         Document document2 = new Document(pdfIText7Document, pagesize);
         document2.SetMargins(0, 0, 0, 0);
         document2.Add(image);
         PdfPage page = document2.GetPdfDocument().GetPage(1);

         if (rotation != PageRotationType.None) {
            int rot = page.GetRotation();

            switch (rotation) {
               case PageRotationType.Left90:
                  rot -= 90;
                  break;

               case PageRotationType.Right90:
                  rot += 90;
                  break;

               case PageRotationType.Right180:
                  rot += 180;
                  break;
            }
            while (rot >= 360)
               rot -= 360;
            while (rot < 0)
               rot += 360;
            page.SetRotation(rot);
         }
         PdfPageSizes.Add(getPageSize(page));

         return page;
      }

      void pdfIText7Close() {
         if (pdfIText7Document != null) {
            pdfIText7Document.Close();
            // nicht mehr nötig:
            //pdfIText7Document.GetWriter().Close();
            //pdfIText7Document.GetWriter().Dispose();
            pdfIText7Document = null;
         }
      }

      /// <summary>
      /// <para>liefert true, wenn kein Passwort benötigt wird, das richtige Passwort registriert war oder das richtige Passwort eingegeben wurde</para>
      /// <para>Ein fehlendes/falsches Passwort führt zur Abfrage des Passwortes bzw. zu einer Exception.</para>
      /// </summary>
      /// <param name="passwordProvider"></param>
      /// <param name="getdocument"></param>
      /// <returns></returns>
      (bool, PdfDocument) checkAndSetPassword(PasswordProvider passwordProvider, bool getdocument) {
         bool result = true;
         PdfDocument doc = null;
         bool tryagain = false;
         do {
            PdfReader pdfReader = null;
            result = true;
            tryagain = false;

            try {

               if (string.IsNullOrEmpty(Password)) {
                  pdfReader = new PdfReader(Filename);
                  doc = new PdfDocument(pdfReader);

                  if (pdfReader.IsEncrypted()) {
                     long perm = pdfReader.GetPermissions();

                  }

               } else {
                  ReaderProperties readerProperties = new ReaderProperties();
                  readerProperties.SetPassword(Encoding.UTF8.GetBytes(Password));
                  pdfReader = new PdfReader(Filename, readerProperties);
                  doc = new PdfDocument(pdfReader);
                  tryagain = false;
               }

            } catch (BadPasswordException ex) {

               if (passwordProvider != null) // sonst zwecklos
                  tryagain = true;
               else
                  throw new Exception(ex.Message);

            } catch (Exception ex) {

               throw new Exception(ex.Message);

            } finally {
               if (tryagain ||
                   !getdocument) {
                  if (doc != null) {
                     if (!doc.IsClosed())
                        doc.Close();
                  }
                  doc = null;
                  if (pdfReader != null &&
                      !pdfReader.IsCloseStream())
                     pdfReader.Close();
               }
            }

            if (tryagain &&
                passwordProvider != null) {           // Passwortabfrage
               PasswordProviderArgs pa = new PasswordProviderArgs(Filename, Password);
               passwordProvider(pa);
               if (!pa.Abort)
                  Password = pa.Password;
               else {
                  result = false;
                  break;
               }
            }

         } while (tryagain);

         return (result, doc);
      }

      bool checkAndSetPassword(PasswordProvider passwordProvider) {
         (bool, PdfDocument) result;
         try {
            result = checkAndSetPassword(passwordProvider, false);
         } catch {
            return false;
         }
         return result.Item1;
      }

#endif

      /// <summary>
      /// mm in Units umrechnen (1 Zoll = 72 user units)
      /// </summary>
      /// <param name="mm"></param>
      /// <returns></returns>
      public static float UserUnits4mm(float mm) {
         return UserUnits4mm(mm, 72);
      }

      public static float UserUnits4mm(float mm, int userunits) {
         return mm / 25.4F * userunits;
      }

      public static float Mm4UserUnits(float units) {
         return Mm4UserUnits(units, 72);
      }

      public static float Mm4UserUnits(float units, int userunits) {
         return 25.4F * units / userunits;
      }

      public static int Rotation2Degree(PageRotationType rot) {
         switch (rot) {
            case PageRotationType.Left90: return -90;
            case PageRotationType.Right90: return 90;
            case PageRotationType.Right180: return 180;
         }
         return 0;
      }

      public static PageRotationType Degree2Rotation(int degree) {
         while (degree > 180)
            degree -= 360;
         while (degree < -90)
            degree += 360;
         switch (degree) {
            case -90: return PageRotationType.Left90;
            case 90: return PageRotationType.Right90;
            case 180: return PageRotationType.Right180;
         }
         return PageRotationType.None;
      }

      public static PageRotationType RotationDiff(PageRotationType rot1, PageRotationType rot2) {
         return Degree2Rotation(Rotation2Degree(rot1) - Rotation2Degree(rot2));
      }

      public static PageRotationType RotationAdd(PageRotationType rot1, PageRotationType rot2) {
         return Degree2Rotation(Rotation2Degree(rot1) + Rotation2Degree(rot2));
      }


      #region Implementierung der IDisposable-Schnittstelle

      /// <summary>
      /// true, wenn schon ein Dispose() erfolgte
      /// </summary>
      private bool _isdisposed = false;

      /// <summary>
      /// kann expliziet für das Objekt aufgerufen werden um interne Ressourcen frei zu geben
      /// </summary>
      public void Dispose() {
         Dispose(true);
         GC.SuppressFinalize(this);
      }

      /// <summary>
      /// überschreibt die Standard-Methode
      /// <para></para>
      /// </summary>
      /// <param name="notfromfinalizer">falls, wenn intern vom Finalizer aufgerufen</param>
      protected virtual void Dispose(bool notfromfinalizer) {
         if (!this._isdisposed) {            // bisher noch kein Dispose erfolgt
            if (notfromfinalizer) {          // nur dann alle managed Ressourcen freigeben

#if USE_PDFSHARP
               pdfSharpClose();
#else
#if USE_ITEXT7

#endif
#endif

            }
            // jetzt immer alle unmanaged Ressourcen freigeben (z.B. Win32)

            _isdisposed = true;        // Kennung setzen, dass Dispose erfolgt ist
         }
      }

      #endregion

      public override string ToString() {
         return string.Format("Filename={0}, Open={1}", Filename, ghostscriptRasterizerIsOpen);
      }

   }
}
