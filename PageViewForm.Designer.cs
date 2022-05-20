
namespace PdfArranger {
   partial class PageViewForm {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.components = new System.ComponentModel.Container();
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageViewForm));
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.ToolStripMenuItemFirstPage = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItemPagesUp = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItemPagesDown = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItemLastPage = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItemPageDown = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItemPageUp = new System.Windows.Forms.ToolStripMenuItem();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.contextMenuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // pictureBox1
         // 
         this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.pictureBox1.Location = new System.Drawing.Point(0, 0);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(540, 642);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         // 
         // contextMenuStrip1
         // 
         this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemFirstPage,
            this.ToolStripMenuItemPageUp,
            this.ToolStripMenuItemPagesUp,
            this.ToolStripMenuItemPageDown,
            this.ToolStripMenuItemPagesDown,
            this.ToolStripMenuItemLastPage});
         this.contextMenuStrip1.Name = "contextMenuStrip1";
         this.contextMenuStrip1.Size = new System.Drawing.Size(157, 136);
         // 
         // ToolStripMenuItemFirstPage
         // 
         this.ToolStripMenuItemFirstPage.Name = "ToolStripMenuItemFirstPage";
         this.ToolStripMenuItemFirstPage.Size = new System.Drawing.Size(156, 22);
         this.ToolStripMenuItemFirstPage.Text = "zur 1. Seite";
         this.ToolStripMenuItemFirstPage.Click += new System.EventHandler(this.ToolStripMenuItemFirstPage_Click);
         // 
         // ToolStripMenuItemPagesUp
         // 
         this.ToolStripMenuItemPagesUp.Name = "ToolStripMenuItemPagesUp";
         this.ToolStripMenuItemPagesUp.Size = new System.Drawing.Size(156, 22);
         this.ToolStripMenuItemPagesUp.Text = "10 Seiten vor";
         this.ToolStripMenuItemPagesUp.Click += new System.EventHandler(this.ToolStripMenuItemPagesUp_Click);
         // 
         // ToolStripMenuItemPagesDown
         // 
         this.ToolStripMenuItemPagesDown.Name = "ToolStripMenuItemPagesDown";
         this.ToolStripMenuItemPagesDown.Size = new System.Drawing.Size(156, 22);
         this.ToolStripMenuItemPagesDown.Text = "10 Seiten weiter";
         this.ToolStripMenuItemPagesDown.Click += new System.EventHandler(this.ToolStripMenuItemPagesDown_Click);
         // 
         // ToolStripMenuItemLastPage
         // 
         this.ToolStripMenuItemLastPage.Name = "ToolStripMenuItemLastPage";
         this.ToolStripMenuItemLastPage.Size = new System.Drawing.Size(156, 22);
         this.ToolStripMenuItemLastPage.Text = "zur letzten Seite";
         this.ToolStripMenuItemLastPage.Click += new System.EventHandler(this.ToolStripMenuItemLastPage_Click);
         // 
         // ToolStripMenuItemPageDown
         // 
         this.ToolStripMenuItemPageDown.Name = "ToolStripMenuItemPageDown";
         this.ToolStripMenuItemPageDown.Size = new System.Drawing.Size(156, 22);
         this.ToolStripMenuItemPageDown.Text = "1 Seite weiter";
         this.ToolStripMenuItemPageDown.Click += new System.EventHandler(this.ToolStripMenuItemPageDown_Click);
         // 
         // ToolStripMenuItemPageUp
         // 
         this.ToolStripMenuItemPageUp.Name = "ToolStripMenuItemPageUp";
         this.ToolStripMenuItemPageUp.Size = new System.Drawing.Size(156, 22);
         this.ToolStripMenuItemPageUp.Text = "1 Seite vor";
         this.ToolStripMenuItemPageUp.Click += new System.EventHandler(this.ToolStripMenuItemPageUp_Click);
         // 
         // PageViewForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(540, 642);
         this.ContextMenuStrip = this.contextMenuStrip1;
         this.Controls.Add(this.pictureBox1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.MinimizeBox = false;
         this.Name = "PageViewForm";
         this.Text = "PageViewForm";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.contextMenuStrip1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.PictureBox pictureBox1;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemFirstPage;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPagesUp;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPagesDown;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemLastPage;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPageUp;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemPageDown;
   }
}