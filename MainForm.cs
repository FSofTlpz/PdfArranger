using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace PdfArranger {
   public partial class MainForm : Form {

      ScannerPropsForm scannerPropsForm;


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
      }

      private void MainForm_Shown(object sender, EventArgs e) {
         string[] args = Environment.GetCommandLineArgs();
         for (int i = 1; i < args.Length; i++)
            openPdf(args[i]);
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

      void saveActualPdfView() {
         if (ActiveMdiChild != null && ActiveMdiChild is PdfViewForm) {
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
                  else
                     (ActiveMdiChild as PdfViewForm).PdfPages.Save(saveFileDialog1.FileName);
               }
            } catch (Exception ex) {
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
            form.Show();
            Cursor = cur;
         } catch (Exception ex) {
            Cursor = cur;
            MessageBox.Show(ex.Message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
         }
      }

      private void Form_OnItemDoubleClick(object sender, ListViewPdfPages.PageInfoEventArgs e) {
         showSelectedPage();
      }

      void showSelectedPage() {
         if (ActiveMdiChild != null && ActiveMdiChild is PdfViewForm) {
            (ActiveMdiChild as PdfViewForm).ShowSelectedPages(300);
         }
      }

      void showScannerPropsForm(bool on) {
         if (Array.Find(OwnedForms, (form) => { return form.Equals(scannerPropsForm); }) == null) // Ex. nicht mehr in der Auflistung?
            scannerPropsForm = null;

         if (on) {
            if (scannerPropsForm != null) {
               scannerPropsForm.Visible = true;
            } else {
               scannerPropsForm = new ScannerPropsForm();
               scannerPropsForm.Show(this);

            }
            scannerPropsForm.Activate();
         } else {
            if (scannerPropsForm != null) {
               scannerPropsForm.Visible = false;
            }
         }
      }

      #region ToolStripButtons

      private void toolStripButton_RotateLeft_Click(object sender, EventArgs e) {
         if (ActiveMdiChild != null && ActiveMdiChild is PdfViewForm) {
            (ActiveMdiChild as PdfViewForm).PdfPages.RotateSelectedItems(-90);
         }
      }

      private void toolStripButton_RotateRight_Click(object sender, EventArgs e) {
         if (ActiveMdiChild != null && ActiveMdiChild is PdfViewForm) {
            (ActiveMdiChild as PdfViewForm).PdfPages.RotateSelectedItems(90);
         }
      }

      private void toolStripButton_PageView_Click(object sender, EventArgs e) {
         showSelectedPage();
      }

      private void toolStripButton_Save_Click(object sender, EventArgs e) {
         saveActualPdfView();
      }

      private void toolStripButton_Remove_Click(object sender, EventArgs e) {
         if (ActiveMdiChild != null && ActiveMdiChild is PdfViewForm) {
            (ActiveMdiChild as PdfViewForm).PdfPages.RemoveSelectedItems();
         }
      }

      private void toolStripButton_Scan_Click(object sender, EventArgs e) {
         if (ActiveMdiChild != null && ActiveMdiChild is PdfViewForm) {
            if (scannerPropsForm == null ||
                (scannerPropsForm != null && !scannerPropsForm.ScannerIsInit))
               showScannerPropsForm(true);

            if (scannerPropsForm != null &&
                scannerPropsForm.ScannerIsInit) {
               Image img = scannerPropsForm.GetImage(out float width, out float height);
               if (img != null) 
                  (ActiveMdiChild as PdfViewForm).PdfPages.AppendImage(img, new SizeF(width, height));
            }
         }
      }

      private void toolStripButton_ShowScanProps_Click(object sender, EventArgs e) {
         showScannerPropsForm(toolStripButton_ShowScanProps.Checked);
      }

      #endregion

      #region ToolStripMenuItems

      private void ToolStripMenuItem_LoadFileInPageView_Click(object sender, EventArgs e) {
         openPdfView();
      }

      private void ToolStripMenuItem_NewPageView_Click(object sender, EventArgs e) {
         openPdf(null);
      }

      private void ToolStripMenuItem_SavePageView_Click(object sender, EventArgs e) {
         saveActualPdfView();
      }

      private void ToolStripMenuItem_Icon_Click(object sender, EventArgs e) {
         foreach (var mdi in MdiChildren)
            mdi.WindowState = FormWindowState.Minimized;
         LayoutMdi(MdiLayout.ArrangeIcons);
      }

      private void ToolStripMenuItem_Cascade_Click(object sender, EventArgs e) {
         LayoutMdi(MdiLayout.Cascade);
      }

      private void ToolStripMenuItem_Horizontal_Click(object sender, EventArgs e) {
         LayoutMdi(MdiLayout.TileHorizontal);
      }

      private void ToolStripMenuItem_Vertical_Click(object sender, EventArgs e) {
         LayoutMdi(MdiLayout.TileVertical);
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
   }
}
