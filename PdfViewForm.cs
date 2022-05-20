﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PdfArranger {
   public partial class PdfViewForm : Form {

      static int newDocument = 0;

      public event EventHandler<ListViewPdfPages.PageInfoEventArgs> OnItemDoubleClick;


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


      public PdfViewForm() {
         InitializeComponent();
         newDocument++;
      }

      private void PdfViewForm_Load(object sender, EventArgs e) {
         Text = "PDF-Seitensammlung " + newDocument + (string.IsNullOrEmpty(Filename) ?
                           "" :
                           ", " + Path.GetFileName(Filename));
      }

      private void PdfViewForm_Shown(object sender, EventArgs e) {
         listViewPdfPages1.OnItemCountChanged += ListViewPdfPages1_OnItemCountChanged;
         listViewPdfPages1.OnItemDoubleClick += ListViewPdfPages1_OnItemDoubleClick;
         listViewPdfPages1.OnNewItemsDrop += ListViewPdfPages1_OnNewItemsDrop;

         if (!string.IsNullOrEmpty(Filename)) {
            listViewPdfPages1.AppendPdfFile(Filename);
         }
      }

      private void ListViewPdfPages1_OnNewItemsDrop(object sender, EventArgs e) {
         Activate();
      }

      private void ListViewPdfPages1_OnItemDoubleClick(object sender, ListViewPdfPages.PageInfoEventArgs e) {
         OnItemDoubleClick?.Invoke(this, e);
      }

      private void ListViewPdfPages1_OnItemCountChanged(object sender, EventArgs e) {
         toolStripStatusLabel_Pages.Text = listViewPdfPages1.Count + " Seite" + (listViewPdfPages1.Count != 1 ? "n" : "");
      }

      /// <summary>
      /// zeigt alle ausgewälten Seiten in einem eigenen <see cref="PageViewForm"/> an
      /// </summary>
      /// <param name="dpi"></param>
      public void ShowSelectedPages(int dpi = 300) {
         ListViewPdfPages.PageInfo[] pi = listViewPdfPages1.GetInfo4SelectedItems();
         if (pi != null && pi.Length > 0) {
            Image[] img = listViewPdfPages1.GetImage4SelectedItems(dpi);
            for (int i = 0; i < pi.Length; i++) {
               PageViewForm form = new PageViewForm() {
                  MasterForm = this,
                  //WindowState = FormWindowState.Maximized,
               };
               form.Show(this);
               showPage(form, pi[i].PageNo, pi[i].Filename, img[i], dpi);
            }
         }
      }

      /// <summary>
      /// für den Aufruf von einem <see cref="PageViewForm"/> aus (ändert die angezeigte Seite)
      /// </summary>
      /// <param name="form"></param>
      /// <param name="idx"></param>
      /// <param name="dpi"></param>
      public void ShowPageNew(PageViewForm form, int idx, int dpi) {
         // Sonderfall "letzte Seite"
         if (idx == int.MaxValue)
            idx = listViewPdfPages1.Count - 1;

         Image img = listViewPdfPages1.GetImage4Page(idx, dpi);
         if (img != null) {
            ListViewPdfPages.PageInfo pi = listViewPdfPages1.GetInfo4Page(idx);
            if (pi != null)
               showPage(form, pi.PageNo, pi.Filename, img, dpi);
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
               showPage(form, pi.PageNo, pi.Filename, img, dpi);
            }
         }
      }

      void showPage(PageViewForm form, int pageidx, string filename, Image img, int dpi) {
         form.ShowPage(pageidx, filename, img, dpi);
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
         ShowOnePage(contextmenu4idx, 300);
      }
   }
}