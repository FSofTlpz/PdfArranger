using System;
using System.Drawing;
using System.Windows.Forms;

namespace PdfArranger {
   public partial class PageViewForm : Form {

      public PdfViewForm MasterForm {
         get;
         set;
      }

      Image Image {
         get => pictureBox1.Image;
         set => pictureBox1.Image = value;
      }

      public int PageIdx {
         get;
         protected set;
      }

      public string Filename {
         get;
         protected set;
      }

      int lastdpi = -1;


      public PageViewForm() {
         InitializeComponent();
         KeyUp += PageViewForm_KeyUp;
      }

      protected override void OnShown(EventArgs e) {
         base.OnShown(e);
         //ShowPage(PageIdx, Filename, Image);
      }

      /// <summary>
      /// zeigt ein Bild an
      /// <para>Alle anderen Parameter dienen nur der Information.</para>
      /// </summary>
      /// <param name="pageidx">Seitenindex in der Datei (nicht der Auflistung!)</param>
      /// <param name="filename">Datei aus der die Seite stammt</param>
      /// <param name="img"></param>
      /// <param name="dpi"></param>
      public void ShowPage(int pageidx, string filename, Image img, int dpi) {
         Image = img;
         PageIdx = pageidx;
         Filename = filename;
         Text = "Seite " + (PageIdx + 1) + ", " + Filename;
         lastdpi = dpi;

         // Client-Area max.
         //int maxclientheight = SystemInformation.VirtualScreen.Height - (Size.Height - ClientSize.Height);
         //int maxclientwidth = SystemInformation.VirtualScreen.Width - (Size.Width - ClientSize.Width);
         if (Image != null) {
            Screen actualScreen = Screen.FromControl(Owner);
            Rectangle screenarea = actualScreen.Bounds;
            int maxclientheight = screenarea.Height - (Size.Height - ClientSize.Height);
            int maxclientwidth = screenarea.Width - (Size.Width - ClientSize.Width);
            if ((float)maxclientwidth / maxclientheight > (float)Image.Width / Image.Height) { // max. Höhe verwenden
               ClientSize = new Size((int)(maxclientheight * (float)Image.Width / Image.Height), maxclientheight);
               Top = 0;
            } else {
               ClientSize = new Size(maxclientwidth, (int)(maxclientwidth * (float)Image.Height / Image.Width));
               Left = screenarea.Left;
            }
         }
      }

      private void PageViewForm_KeyUp(object sender, KeyEventArgs e) {
         switch (e.KeyCode) {
            case Keys.Escape:
               Close();
               break;

            case Keys.Left:
               ToolStripMenuItemPageUp_Click(null, null);
               break;

            case Keys.Right:
               ToolStripMenuItemPageDown_Click(null, null);
               break;

            case Keys.PageUp:
               ToolStripMenuItemPagesUp_Click(null, null);
               break;

            case Keys.PageDown:
               ToolStripMenuItemPagesDown_Click(null, null);
               break;

            case Keys.Home:
               ToolStripMenuItemFirstPage_Click(null, null);
               break;

            case Keys.End:
               ToolStripMenuItemLastPage_Click(null, null);
               break;
         }
      }

      void changePageIdx(int delta) {
         if (!MasterForm.IsDisposed &&
             MasterForm.IsHandleCreated) {
            Cursor cursor = MasterForm.Cursor;
            Cursor = Cursors.WaitCursor;
            MasterForm.ShowPageNew(this, delta, lastdpi);
            Cursor = cursor;
         }
      }

      private void ToolStripMenuItemFirstPage_Click(object sender, EventArgs e) {
         changePageIdx(int.MinValue);
      }

      private void ToolStripMenuItemPageUp_Click(object sender, EventArgs e) {
         changePageIdx(-1);
      }

      private void ToolStripMenuItemPagesUp_Click(object sender, EventArgs e) {
         changePageIdx(-10);
      }

      private void ToolStripMenuItemPageDown_Click(object sender, EventArgs e) {
         changePageIdx(1);
      }

      private void ToolStripMenuItemPagesDown_Click(object sender, EventArgs e) {
         changePageIdx(10);
      }

      private void ToolStripMenuItemLastPage_Click(object sender, EventArgs e) {
         changePageIdx(int.MaxValue);    // Sonderfall "letzte Seite"
      }

   }
}
