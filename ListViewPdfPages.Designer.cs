﻿
namespace PdfArranger {
   partial class ListViewPdfPages {
      /// <summary> 
      /// Erforderliche Designervariable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Verwendete Ressourcen bereinigen.
      /// </summary>
      /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null)) {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Vom Komponenten-Designer generierter Code

      /// <summary> 
      /// Erforderliche Methode für die Designerunterstützung. 
      /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
      /// </summary>
      private void InitializeComponent() {
         this.listView1 = new System.Windows.Forms.ListView();
         this.SuspendLayout();
         // 
         // listView1
         // 
         this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.listView1.HideSelection = false;
         this.listView1.Location = new System.Drawing.Point(0, 0);
         this.listView1.Name = "listView1";
         this.listView1.ShowItemToolTips = true;
         this.listView1.Size = new System.Drawing.Size(289, 359);
         this.listView1.TabIndex = 0;
         this.listView1.UseCompatibleStateImageBehavior = false;
         this.listView1.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listView1_ItemSelectionChanged);
         this.listView1.VirtualItemsSelectionRangeChanged += new System.Windows.Forms.ListViewVirtualItemsSelectionRangeChangedEventHandler(this.listView1_VirtualItemsSelectionRangeChanged);
         // 
         // ListViewPdfPages
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.listView1);
         this.Name = "ListViewPdfPages";
         this.Size = new System.Drawing.Size(289, 359);
         this.BackColorChanged += new System.EventHandler(this.ListViewPdfPages_BackColorChanged);
         this.ForeColorChanged += new System.EventHandler(this.ListViewPdfPages_ForeColorChanged);
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.ListView listView1;
   }
}
