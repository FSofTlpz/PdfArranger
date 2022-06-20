using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
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
         actualPdfViewForm?.ShowSelectedPages(300);
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

         toolStripButton_PageView.Enabled =
         ToolStripMenuItem_PageView.Enabled =
         toolStripButton_Remove.Enabled =
         ToolStripMenuItem_Remove.Enabled =
         toolStripButton_RotateRight.Enabled =
         ToolStripMenuItem_RotateRight.Enabled =
         toolStripButton_RotateLeft.Enabled =
         ToolStripMenuItem_RotateLeft.Enabled = closingform != null ?
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

   }
}
