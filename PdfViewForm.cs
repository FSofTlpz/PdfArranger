using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PdfArranger {
   public partial class PdfViewForm : Form {

      const int DPI4SHOWPAGE = 300;

      static int newDocument = 0;

      AppData appData;


      public event EventHandler<ListViewPdfPages.PageInfoEventArgs> OnItemDoubleClick;

      public event EventHandler OnCountChanged;

      public event EventHandler OnSelectedCountChanged;


      public string Filename {
         get;
         set;
      }

      public ListViewPdfPages PdfPages {
         get => listViewPdfPages1;
      }

      public Dictionary<string, List<int>> Info4Pages() {
         return listViewPdfPages1.GetInfo4Pages();
      }


      public PdfViewForm(AppData appData) {
         InitializeComponent();
         newDocument++;
         this.appData = appData;
      }

      private void PdfViewForm_Load(object sender, EventArgs e) {
         Text = "PDF-Seitensammlung " + newDocument + (string.IsNullOrEmpty(Filename) ?
                           "" :
                           ", " + Path.GetFileName(Filename));
         listViewPdfPages1.SetAppData(appData);
      }

      private void PdfViewForm_Shown(object sender, EventArgs e) {
         listViewPdfPages1.OnItemCountChanged += ListViewPdfPages1_OnItemCountChanged;
         listViewPdfPages1.OnItemSelectionChanged += ListViewPdfPages1_OnItemSelectionChanged;
         listViewPdfPages1.OnItemDoubleClick += ListViewPdfPages1_OnItemDoubleClick;
         listViewPdfPages1.OnNewItemsDrop += ListViewPdfPages1_OnNewItemsDrop;

         if (!string.IsNullOrEmpty(Filename)) {
            listViewPdfPages1.AppendPdfFile(Filename);
         }
      }

      private void PdfViewForm_FormClosing(object sender, FormClosingEventArgs e) {
         PdfPages.RemoveAllItems();
      }

      private void ListViewPdfPages1_OnItemSelectionChanged(object sender, EventArgs e) {
         OnSelectedCountChanged?.Invoke(this, EventArgs.Empty);
      }

      private void ListViewPdfPages1_OnNewItemsDrop(object sender, EventArgs e) {
         Activate();
      }

      private void ListViewPdfPages1_OnItemDoubleClick(object sender, ListViewPdfPages.PageInfoEventArgs e) {
         OnItemDoubleClick?.Invoke(this, e);
      }

      private void ListViewPdfPages1_OnItemCountChanged(object sender, EventArgs e) {
         toolStripStatusLabel_Pages.Text = listViewPdfPages1.Count + " Seite" + (listViewPdfPages1.Count != 1 ? "n" : "");
         OnCountChanged?.Invoke(this, EventArgs.Empty);
      }

      /// <summary>
      /// macht ein bestimmtes Item sichtbar
      /// </summary>
      /// <param name="idx"></param>
      public void EnsureVisible(int idx) {
         if (0 <= idx && idx < listViewPdfPages1.Count)
            listViewPdfPages1.EnsureVisible(idx);
      }

      /// <summary>
      /// zeigt alle ausgewälten Seiten in einem eigenen <see cref="PageViewForm"/> an
      /// </summary>
      /// <param name="dpi"></param>
      public void ShowSelectedPages(int dpi) {
         ListViewPdfPages.PageInfo[] pi = listViewPdfPages1.GetInfo4SelectedItems();
         if (pi != null && pi.Length > 0) {
            Image[] img = listViewPdfPages1.GetImage4SelectedItems(dpi);
            for (int i = 0; i < pi.Length; i++) {
               PageViewForm form = new PageViewForm() {
                  MasterForm = this,
                  //WindowState = FormWindowState.Maximized,
               };
               form.Show(this);

               //pi[i].

               showPage(form, pi[i].PageNo, pi[i].Filename, pi[i].PageSize, img[i], dpi);
            }
         }
      }

      /// <summary>
      /// für den Aufruf von einem <see cref="PageViewForm"/> aus (ändert die angezeigte Seite)
      /// </summary>
      /// <param name="form"></param>
      /// <param name="delta"></param>
      /// <param name="dpi"></param>
      public void ShowPageNew(PageViewForm form, int delta, int dpi) {
         if (form != null) {
            int idx;
            switch (delta) {
               case int.MinValue:   // Sonderfall "1. Seite"
                  idx = 0;
                  break;

               case int.MaxValue:   // Sonderfall "letzte Seite"
                  idx = listViewPdfPages1.Count - 1;
                  break;

               default:
                  idx = listViewPdfPages1.GetIdx4Page(form.Filename, form.PageIdx);
                  if (idx >= 0)
                     idx += delta;
                  break;
            }

            if (0 <= idx && idx < listViewPdfPages1.Count) {
               Image img = listViewPdfPages1.GetImage4Page(idx, dpi);
               if (img != null) {
                  ListViewPdfPages.PageInfo pi = listViewPdfPages1.GetInfo4Page(idx);
                  if (pi != null)
                     showPage(form, pi.PageNo, pi.Filename, pi.PageSize, img, dpi);
               }
            }
         }
      }

      /// <summary>
      /// zeigt die Seite mit dem Index in einem neuen <see cref="PageViewForm"/> an
      /// </summary>
      /// <param name="idx"></param>
      /// <param name="dpi"></param>
      public void ShowOnePage(int idx, int dpi) {
         Image img = listViewPdfPages1.GetImage4Page(idx, dpi);
         if (img != null) {
            ListViewPdfPages.PageInfo pi = listViewPdfPages1.GetInfo4Page(idx);
            if (pi != null) {
               PageViewForm form = new PageViewForm() {
                  MasterForm = this,
                  //WindowState = FormWindowState.Maximized,
               };
               form.Show(this);
               showPage(form, pi.PageNo, pi.Filename, pi.PageSize, img, dpi);
            }
         }
      }

      void showPage(PageViewForm form, int pageidx, string filename, SizeF orgpagesize, Image img, int dpi) {
         form.ShowPage(pageidx, filename, orgpagesize, img, dpi);
      }

      /// <summary>
      /// Seitenindex für den das Kontextmenü aufgerufen wurde
      /// </summary>
      int contextmenu4idx = -1;

      private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e) {
         if (listViewPdfPages1.Count > 0) {
            contextmenu4idx = listViewPdfPages1.GetItemIdx4Point(listViewPdfPages1.PointToClient(MousePosition));
            if (contextmenu4idx >= 0) {
               e.Cancel = false;
               return;
            }
         }
         e.Cancel = true;
      }

      private void ToolStripMenuItemShowPage_Click(object sender, EventArgs e) {
         ShowOnePage(contextmenu4idx, DPI4SHOWPAGE);
      }
   }
}
