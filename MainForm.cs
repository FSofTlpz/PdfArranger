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

      ScannerPropsForm scannerPropsForm;

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

      /// <summary>
      /// Ist der Scanner konfiguriert?
      /// </summary>
      bool scannerIsConfigurated {
         get {
            return scannerPropsForm != null && scannerPropsForm.ScannerIsInit;
         }
      }

      int stdDPI = 300;


      public MainForm() {
         InitializeComponent();

         DragEnter += MainForm_DragEnter;
         //DragLeave += MainForm_DragLeave;
         //DragOver += MainForm_DragOver;
         DragDrop += MainForm_DragDrop;
         AllowDrop = true;
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
            PdfViewForm form = new PdfViewForm() {
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

      /// <summary>
      /// Form sichtbar machen (ev. erst erzeugen) oder unsichtbar machen
      /// </summary>
      /// <param name="on"></param>
      void showScannerPropsForm(bool on) {
         if (Array.Find(OwnedForms, (form) => { return form.Equals(scannerPropsForm); }) == null) // Ex. nicht mehr in der Auflistung?
            scannerPropsForm = null;

         if (on) {
            if (scannerPropsForm != null) {
               scannerPropsForm.Visible = true;
            } else {
               scannerPropsForm = new ScannerPropsForm();
               scannerPropsForm.OnInitChanged += ScannerPropsForm_OnInitChanged;
               scannerPropsForm.Show(this);

            }
            scannerPropsForm.Activate();
         } else {
            if (scannerPropsForm != null) {
               scannerPropsForm.Visible = false;
            }
         }
      }

      private void ScannerPropsForm_OnInitChanged(object sender, EventArgs e) {
         adjustMenuAndToolbar();
      }

      void adjustMenuAndToolbar(PdfViewForm closingform = null) {
         int mdichilds = MdiChildren.Length - (closingform != null ? 1 : 0);

         toolStripButton_scan.Enabled =
         ToolStripMenuItem_ScanPage.Enabled = scannerIsConfigurated &&
                                              mdichilds > 0;

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
         if (actualPdfViewForm != null) {
            if (!scannerIsConfigurated)
               showScannerPropsForm(true);

            if (scannerIsConfigurated) {
               Image img = scannerPropsForm.GetImage(out double width, out double height);
               if (img != null && actualPdfViewForm != null) {
                  actualPdfViewForm.PdfPages.AppendImage(img, new SizeF((float)width, (float)height));
                  actualPdfViewForm.PdfPages.EnsureVisible(actualPdfViewForm.PdfPages.Count - 1);        // neue Seite anzeigen
               }
            }
            adjustMenuAndToolbar();
         }
      }

      private void toolStripButton_ShowScanProps_Click(object sender, EventArgs e) {
         showScannerPropsForm(true);
         adjustMenuAndToolbar();
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
         if (img != null && actualPdfViewForm != null) {
            actualPdfViewForm.PdfPages.AppendImage(img);


            //// Create an Encoder object based on the GUID for the Quality parameter category.
            //Encoder myEncoder = Encoder.Quality;
            //// Create an EncoderParameters object. In this case, there is only one EncoderParameter object in the array.
            //EncoderParameters myEncoderParameters = new EncoderParameters(1);
            //// Save the bitmap with quality level ...
            //EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 90L);
            //myEncoderParameters.Param[0] = myEncoderParameter;

            //// Get an ImageCodecInfo object that represents the JPEG codec.
            //ImageCodecInfo jpgEncoder = null;
            //ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
            //for (int j = 0; j < encoders.Length; j++)
            //   if (encoders[j].MimeType == "image/jpeg") {
            //      jpgEncoder = encoders[j];
            //      break;
            //   }

            //if (jpgEncoder != null) {
            //   img.Save("t2.jpg", jpgEncoder, myEncoderParameters);


            //   MemoryStream ms = new MemoryStream();
            //   img.Save(ms, jpgEncoder, myEncoderParameters);
            //   ms.Position = 0;
            //   Bitmap bm = new Bitmap(ms);
            //   actualPdfViewForm.PdfPages.AppendImage(bm);
            //}



         }
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

   }
}
