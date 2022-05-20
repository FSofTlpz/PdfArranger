
namespace PdfArranger {
   partial class PdfViewForm {
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
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfViewForm));
         this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
         this.statusStrip1 = new System.Windows.Forms.StatusStrip();
         this.toolStripStatusLabel_Pages = new System.Windows.Forms.ToolStripStatusLabel();
         this.listViewPdfPages1 = new PdfArranger.ListViewPdfPages();
         this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
         this.ToolStripMenuItemShowPage = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
         this.toolStripContainer1.ContentPanel.SuspendLayout();
         this.toolStripContainer1.SuspendLayout();
         this.statusStrip1.SuspendLayout();
         this.contextMenuStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // toolStripContainer1
         // 
         // 
         // toolStripContainer1.BottomToolStripPanel
         // 
         this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
         // 
         // toolStripContainer1.ContentPanel
         // 
         this.toolStripContainer1.ContentPanel.Controls.Add(this.listViewPdfPages1);
         this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(613, 587);
         this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
         this.toolStripContainer1.Name = "toolStripContainer1";
         this.toolStripContainer1.Size = new System.Drawing.Size(613, 634);
         this.toolStripContainer1.TabIndex = 0;
         this.toolStripContainer1.Text = "toolStripContainer1";
         // 
         // statusStrip1
         // 
         this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
         this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_Pages});
         this.statusStrip1.Location = new System.Drawing.Point(0, 0);
         this.statusStrip1.Name = "statusStrip1";
         this.statusStrip1.Size = new System.Drawing.Size(613, 22);
         this.statusStrip1.TabIndex = 0;
         // 
         // toolStripStatusLabel_Pages
         // 
         this.toolStripStatusLabel_Pages.Name = "toolStripStatusLabel_Pages";
         this.toolStripStatusLabel_Pages.Size = new System.Drawing.Size(48, 17);
         this.toolStripStatusLabel_Pages.Text = "0 Seiten";
         // 
         // listViewPdfPages1
         // 
         this.listViewPdfPages1.AllowDrop = true;
         this.listViewPdfPages1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listViewPdfPages1.Location = new System.Drawing.Point(0, 0);
         this.listViewPdfPages1.Name = "listViewPdfPages1";
         this.listViewPdfPages1.Size = new System.Drawing.Size(613, 587);
         this.listViewPdfPages1.TabIndex = 0;
         // 
         // contextMenuStrip1
         // 
         this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItemShowPage});
         this.contextMenuStrip1.Name = "contextMenuStrip1";
         this.contextMenuStrip1.Size = new System.Drawing.Size(181, 48);
         this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
         // 
         // ToolStripMenuItemShowPage
         // 
         this.ToolStripMenuItemShowPage.Image = global::PdfArranger.Properties.Resources.zoom;
         this.ToolStripMenuItemShowPage.Name = "ToolStripMenuItemShowPage";
         this.ToolStripMenuItemShowPage.Size = new System.Drawing.Size(180, 22);
         this.ToolStripMenuItemShowPage.Text = "Seitenanzeige";
         this.ToolStripMenuItemShowPage.Click += new System.EventHandler(this.ToolStripMenuItemShowPage_Click);
         // 
         // PdfViewForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(613, 634);
         this.ContextMenuStrip = this.contextMenuStrip1;
         this.Controls.Add(this.toolStripContainer1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.Name = "PdfViewForm";
         this.Text = "PdfViewForm";
         this.Load += new System.EventHandler(this.PdfViewForm_Load);
         this.Shown += new System.EventHandler(this.PdfViewForm_Shown);
         this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
         this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
         this.toolStripContainer1.ContentPanel.ResumeLayout(false);
         this.toolStripContainer1.ResumeLayout(false);
         this.toolStripContainer1.PerformLayout();
         this.statusStrip1.ResumeLayout(false);
         this.statusStrip1.PerformLayout();
         this.contextMenuStrip1.ResumeLayout(false);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ToolStripContainer toolStripContainer1;
      private ListViewPdfPages listViewPdfPages1;
      private System.Windows.Forms.StatusStrip statusStrip1;
      private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_Pages;
      private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemShowPage;
   }
}