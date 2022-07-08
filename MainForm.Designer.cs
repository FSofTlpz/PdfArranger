
namespace PdfArranger {
   partial class MainForm {
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

      #region Vom Windows Form-Designer generierter Code

      /// <summary>
      /// Erforderliche Methode für die Designerunterstützung.
      /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
      /// </summary>
      private void InitializeComponent() {
         System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
         this.menuStrip1 = new System.Windows.Forms.MenuStrip();
         this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_LoadFileInPageView = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_ScanPage = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_NewPageView = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_SavePageView = new System.Windows.Forms.ToolStripMenuItem();
         this.bearbeitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_RotateLeft = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_RotateRight = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_Remove = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
         this.ToolStripMenuItem_PageView = new System.Windows.Forms.ToolStripMenuItem();
         this.fensterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_Icon = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_Cascade = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_Vertical = new System.Windows.Forms.ToolStripMenuItem();
         this.ToolStripMenuItem_Horizontal = new System.Windows.Forms.ToolStripMenuItem();
         this.toolStripSeparatorBeforeWins = new System.Windows.Forms.ToolStripSeparator();
         this.toolStrip1 = new System.Windows.Forms.ToolStrip();
         this.toolStripButton_new = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton_Save = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton_Copy = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton_Paste = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton_RotateLeft = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton_RotateRight = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton_Remove = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton_PageView = new System.Windows.Forms.ToolStripButton();
         this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
         this.toolStripButton_scan = new System.Windows.Forms.ToolStripButton();
         this.toolStripButton_ShowScanProps = new System.Windows.Forms.ToolStripButton();
         this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
         this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
         this.menuStrip1.SuspendLayout();
         this.toolStrip1.SuspendLayout();
         this.SuspendLayout();
         // 
         // menuStrip1
         // 
         this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dateiToolStripMenuItem,
            this.bearbeitenToolStripMenuItem,
            this.fensterToolStripMenuItem});
         this.menuStrip1.Location = new System.Drawing.Point(0, 0);
         this.menuStrip1.MdiWindowListItem = this.fensterToolStripMenuItem;
         this.menuStrip1.Name = "menuStrip1";
         this.menuStrip1.Size = new System.Drawing.Size(614, 24);
         this.menuStrip1.TabIndex = 8;
         this.menuStrip1.Text = "menuStrip1";
         // 
         // dateiToolStripMenuItem
         // 
         this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_LoadFileInPageView,
            this.ToolStripMenuItem_ScanPage,
            this.ToolStripMenuItem_NewPageView,
            this.ToolStripMenuItem_SavePageView});
         this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
         this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
         this.dateiToolStripMenuItem.Text = "&Datei";
         // 
         // ToolStripMenuItem_LoadFileInPageView
         // 
         this.ToolStripMenuItem_LoadFileInPageView.Image = global::PdfArranger.Properties.Resources.open;
         this.ToolStripMenuItem_LoadFileInPageView.Name = "ToolStripMenuItem_LoadFileInPageView";
         this.ToolStripMenuItem_LoadFileInPageView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
         this.ToolStripMenuItem_LoadFileInPageView.Size = new System.Drawing.Size(348, 22);
         this.ToolStripMenuItem_LoadFileInPageView.Text = "PDF-Datei in PDF-Seitenmappe &importieren";
         this.ToolStripMenuItem_LoadFileInPageView.Click += new System.EventHandler(this.ToolStripMenuItem_LoadFileInPageView_Click);
         // 
         // ToolStripMenuItem_ScanPage
         // 
         this.ToolStripMenuItem_ScanPage.Image = global::PdfArranger.Properties.Resources.scan;
         this.ToolStripMenuItem_ScanPage.Name = "ToolStripMenuItem_ScanPage";
         this.ToolStripMenuItem_ScanPage.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
         this.ToolStripMenuItem_ScanPage.Size = new System.Drawing.Size(348, 22);
         this.ToolStripMenuItem_ScanPage.Text = "Seite scannen und einfügen";
         this.ToolStripMenuItem_ScanPage.Click += new System.EventHandler(this.ToolStripMenuItem_ScanPage_Click);
         // 
         // ToolStripMenuItem_NewPageView
         // 
         this.ToolStripMenuItem_NewPageView.Image = global::PdfArranger.Properties.Resources.newpage;
         this.ToolStripMenuItem_NewPageView.Name = "ToolStripMenuItem_NewPageView";
         this.ToolStripMenuItem_NewPageView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
         this.ToolStripMenuItem_NewPageView.Size = new System.Drawing.Size(348, 22);
         this.ToolStripMenuItem_NewPageView.Text = "&neue PDF-Seitenmappe anlegen";
         this.ToolStripMenuItem_NewPageView.Click += new System.EventHandler(this.ToolStripMenuItem_NewPageView_Click);
         // 
         // ToolStripMenuItem_SavePageView
         // 
         this.ToolStripMenuItem_SavePageView.Image = global::PdfArranger.Properties.Resources.save;
         this.ToolStripMenuItem_SavePageView.Name = "ToolStripMenuItem_SavePageView";
         this.ToolStripMenuItem_SavePageView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
         this.ToolStripMenuItem_SavePageView.Size = new System.Drawing.Size(348, 22);
         this.ToolStripMenuItem_SavePageView.Text = "PDF-Seitenmappe als PDF-Datei &speichern";
         this.ToolStripMenuItem_SavePageView.Click += new System.EventHandler(this.ToolStripMenuItem_SavePageView_Click);
         // 
         // bearbeitenToolStripMenuItem
         // 
         this.bearbeitenToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_RotateLeft,
            this.ToolStripMenuItem_RotateRight,
            this.ToolStripMenuItem_Remove,
            this.toolStripSeparator3,
            this.ToolStripMenuItem_PageView});
         this.bearbeitenToolStripMenuItem.Name = "bearbeitenToolStripMenuItem";
         this.bearbeitenToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
         this.bearbeitenToolStripMenuItem.Text = "&Bearbeiten";
         // 
         // ToolStripMenuItem_RotateLeft
         // 
         this.ToolStripMenuItem_RotateLeft.Image = global::PdfArranger.Properties.Resources.arrow_rotate_anticlockwise;
         this.ToolStripMenuItem_RotateLeft.Name = "ToolStripMenuItem_RotateLeft";
         this.ToolStripMenuItem_RotateLeft.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Left)));
         this.ToolStripMenuItem_RotateLeft.Size = new System.Drawing.Size(327, 22);
         this.ToolStripMenuItem_RotateLeft.Text = "markierte Seiten nach &links drehen";
         this.ToolStripMenuItem_RotateLeft.Click += new System.EventHandler(this.ToolStripMenuItem_RotateLeft_Click);
         // 
         // ToolStripMenuItem_RotateRight
         // 
         this.ToolStripMenuItem_RotateRight.Image = global::PdfArranger.Properties.Resources.arrow_rotate_clockwise;
         this.ToolStripMenuItem_RotateRight.Name = "ToolStripMenuItem_RotateRight";
         this.ToolStripMenuItem_RotateRight.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Right)));
         this.ToolStripMenuItem_RotateRight.Size = new System.Drawing.Size(327, 22);
         this.ToolStripMenuItem_RotateRight.Text = "markierte Seiten nach &rechts drehen";
         this.ToolStripMenuItem_RotateRight.Click += new System.EventHandler(this.ToolStripMenuItem_RotateRight_Click);
         // 
         // ToolStripMenuItem_Remove
         // 
         this.ToolStripMenuItem_Remove.Image = global::PdfArranger.Properties.Resources.remove;
         this.ToolStripMenuItem_Remove.Name = "ToolStripMenuItem_Remove";
         this.ToolStripMenuItem_Remove.ShortcutKeys = System.Windows.Forms.Keys.Delete;
         this.ToolStripMenuItem_Remove.Size = new System.Drawing.Size(327, 22);
         this.ToolStripMenuItem_Remove.Text = "markierte Seiten &entfernen";
         this.ToolStripMenuItem_Remove.Click += new System.EventHandler(this.ToolStripMenuItem_Remove_Click);
         // 
         // toolStripSeparator3
         // 
         this.toolStripSeparator3.Name = "toolStripSeparator3";
         this.toolStripSeparator3.Size = new System.Drawing.Size(324, 6);
         // 
         // ToolStripMenuItem_PageView
         // 
         this.ToolStripMenuItem_PageView.Name = "ToolStripMenuItem_PageView";
         this.ToolStripMenuItem_PageView.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
         this.ToolStripMenuItem_PageView.Size = new System.Drawing.Size(327, 22);
         this.ToolStripMenuItem_PageView.Text = "Seiten&ansicht";
         this.ToolStripMenuItem_PageView.Click += new System.EventHandler(this.ToolStripMenuItem_PageView_Click);
         // 
         // fensterToolStripMenuItem
         // 
         this.fensterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Icon,
            this.ToolStripMenuItem_Cascade,
            this.ToolStripMenuItem_Vertical,
            this.ToolStripMenuItem_Horizontal,
            this.toolStripSeparatorBeforeWins});
         this.fensterToolStripMenuItem.Name = "fensterToolStripMenuItem";
         this.fensterToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
         this.fensterToolStripMenuItem.Text = "&Fenster";
         // 
         // ToolStripMenuItem_Icon
         // 
         this.ToolStripMenuItem_Icon.Name = "ToolStripMenuItem_Icon";
         this.ToolStripMenuItem_Icon.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.M)));
         this.ToolStripMenuItem_Icon.Size = new System.Drawing.Size(246, 22);
         this.ToolStripMenuItem_Icon.Text = "minimiert anordnen";
         this.ToolStripMenuItem_Icon.Click += new System.EventHandler(this.ToolStripMenuItem_Icon_Click);
         // 
         // ToolStripMenuItem_Cascade
         // 
         this.ToolStripMenuItem_Cascade.Name = "ToolStripMenuItem_Cascade";
         this.ToolStripMenuItem_Cascade.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.K)));
         this.ToolStripMenuItem_Cascade.Size = new System.Drawing.Size(246, 22);
         this.ToolStripMenuItem_Cascade.Text = "kaskadiert anordnen";
         this.ToolStripMenuItem_Cascade.Click += new System.EventHandler(this.ToolStripMenuItem_Cascade_Click);
         // 
         // ToolStripMenuItem_Vertical
         // 
         this.ToolStripMenuItem_Vertical.Name = "ToolStripMenuItem_Vertical";
         this.ToolStripMenuItem_Vertical.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.N)));
         this.ToolStripMenuItem_Vertical.Size = new System.Drawing.Size(246, 22);
         this.ToolStripMenuItem_Vertical.Text = "nebeneinander anordnen";
         this.ToolStripMenuItem_Vertical.Click += new System.EventHandler(this.ToolStripMenuItem_Vertical_Click);
         // 
         // ToolStripMenuItem_Horizontal
         // 
         this.ToolStripMenuItem_Horizontal.Name = "ToolStripMenuItem_Horizontal";
         this.ToolStripMenuItem_Horizontal.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
         this.ToolStripMenuItem_Horizontal.Size = new System.Drawing.Size(246, 22);
         this.ToolStripMenuItem_Horizontal.Text = "untereinander anordnen";
         this.ToolStripMenuItem_Horizontal.Click += new System.EventHandler(this.ToolStripMenuItem_Horizontal_Click);
         // 
         // toolStripSeparatorBeforeWins
         // 
         this.toolStripSeparatorBeforeWins.Name = "toolStripSeparatorBeforeWins";
         this.toolStripSeparatorBeforeWins.Size = new System.Drawing.Size(243, 6);
         // 
         // toolStrip1
         // 
         this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
         this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton_new,
            this.toolStripButton_Save,
            this.toolStripSeparator2,
            this.toolStripButton_Copy,
            this.toolStripButton_Paste,
            this.toolStripSeparator5,
            this.toolStripButton_RotateLeft,
            this.toolStripButton_RotateRight,
            this.toolStripSeparator1,
            this.toolStripButton_Remove,
            this.toolStripButton_PageView,
            this.toolStripSeparator4,
            this.toolStripButton_scan,
            this.toolStripButton_ShowScanProps});
         this.toolStrip1.Location = new System.Drawing.Point(0, 24);
         this.toolStrip1.Name = "toolStrip1";
         this.toolStrip1.Size = new System.Drawing.Size(614, 27);
         this.toolStrip1.TabIndex = 9;
         // 
         // toolStripButton_new
         // 
         this.toolStripButton_new.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_new.Image = global::PdfArranger.Properties.Resources.newpage;
         this.toolStripButton_new.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_new.Name = "toolStripButton_new";
         this.toolStripButton_new.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_new.Text = "neue PDF-Seitenmappe anlegen";
         this.toolStripButton_new.Click += new System.EventHandler(this.toolStripButton_new_Click);
         // 
         // toolStripButton_Save
         // 
         this.toolStripButton_Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_Save.Image = global::PdfArranger.Properties.Resources.save;
         this.toolStripButton_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_Save.Name = "toolStripButton_Save";
         this.toolStripButton_Save.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_Save.Text = "speichern";
         this.toolStripButton_Save.Click += new System.EventHandler(this.toolStripButton_Save_Click);
         // 
         // toolStripSeparator2
         // 
         this.toolStripSeparator2.Name = "toolStripSeparator2";
         this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
         // 
         // toolStripButton_Copy
         // 
         this.toolStripButton_Copy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_Copy.Image = global::PdfArranger.Properties.Resources.copy;
         this.toolStripButton_Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_Copy.Name = "toolStripButton_Copy";
         this.toolStripButton_Copy.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_Copy.Text = "Seite als Bild in die Zwischenablage kopieren";
         this.toolStripButton_Copy.Click += new System.EventHandler(this.toolStripButton_Copy_Click);
         // 
         // toolStripButton_Paste
         // 
         this.toolStripButton_Paste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_Paste.Image = global::PdfArranger.Properties.Resources.paste;
         this.toolStripButton_Paste.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_Paste.Name = "toolStripButton_Paste";
         this.toolStripButton_Paste.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_Paste.Text = "Bild der Zwischenablage als Seite anhängen";
         this.toolStripButton_Paste.Click += new System.EventHandler(this.toolStripButton_Paste_Click);
         // 
         // toolStripSeparator5
         // 
         this.toolStripSeparator5.Name = "toolStripSeparator5";
         this.toolStripSeparator5.Size = new System.Drawing.Size(6, 27);
         // 
         // toolStripButton_RotateLeft
         // 
         this.toolStripButton_RotateLeft.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_RotateLeft.Image = global::PdfArranger.Properties.Resources.arrow_rotate_anticlockwise;
         this.toolStripButton_RotateLeft.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_RotateLeft.Name = "toolStripButton_RotateLeft";
         this.toolStripButton_RotateLeft.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_RotateLeft.Text = "nach links drehen";
         this.toolStripButton_RotateLeft.Click += new System.EventHandler(this.toolStripButton_RotateLeft_Click);
         // 
         // toolStripButton_RotateRight
         // 
         this.toolStripButton_RotateRight.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_RotateRight.Image = global::PdfArranger.Properties.Resources.arrow_rotate_clockwise;
         this.toolStripButton_RotateRight.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_RotateRight.Name = "toolStripButton_RotateRight";
         this.toolStripButton_RotateRight.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_RotateRight.Text = "nach rechts drehen";
         this.toolStripButton_RotateRight.Click += new System.EventHandler(this.toolStripButton_RotateRight_Click);
         // 
         // toolStripSeparator1
         // 
         this.toolStripSeparator1.Name = "toolStripSeparator1";
         this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
         // 
         // toolStripButton_Remove
         // 
         this.toolStripButton_Remove.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_Remove.Image = global::PdfArranger.Properties.Resources.remove;
         this.toolStripButton_Remove.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_Remove.Name = "toolStripButton_Remove";
         this.toolStripButton_Remove.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_Remove.Text = "markierte Seiten entfernen";
         this.toolStripButton_Remove.Click += new System.EventHandler(this.toolStripButton_Remove_Click);
         // 
         // toolStripButton_PageView
         // 
         this.toolStripButton_PageView.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_PageView.Image = global::PdfArranger.Properties.Resources.zoom;
         this.toolStripButton_PageView.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_PageView.Name = "toolStripButton_PageView";
         this.toolStripButton_PageView.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_PageView.Text = "Seitenansicht";
         this.toolStripButton_PageView.Click += new System.EventHandler(this.toolStripButton_PageView_Click);
         // 
         // toolStripSeparator4
         // 
         this.toolStripSeparator4.Name = "toolStripSeparator4";
         this.toolStripSeparator4.Size = new System.Drawing.Size(6, 27);
         // 
         // toolStripButton_scan
         // 
         this.toolStripButton_scan.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_scan.Image = global::PdfArranger.Properties.Resources.scan;
         this.toolStripButton_scan.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_scan.Name = "toolStripButton_scan";
         this.toolStripButton_scan.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_scan.Text = "Seite scannen";
         this.toolStripButton_scan.Click += new System.EventHandler(this.toolStripButton_Scan_Click);
         // 
         // toolStripButton_ShowScanProps
         // 
         this.toolStripButton_ShowScanProps.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
         this.toolStripButton_ShowScanProps.Image = global::PdfArranger.Properties.Resources.scanprops;
         this.toolStripButton_ShowScanProps.ImageTransparentColor = System.Drawing.Color.Magenta;
         this.toolStripButton_ShowScanProps.Name = "toolStripButton_ShowScanProps";
         this.toolStripButton_ShowScanProps.Size = new System.Drawing.Size(24, 24);
         this.toolStripButton_ShowScanProps.Text = "Scannereigenschaften";
         this.toolStripButton_ShowScanProps.Click += new System.EventHandler(this.toolStripButton_ShowScanProps_Click);
         // 
         // openFileDialog1
         // 
         this.openFileDialog1.DefaultExt = "pdf";
         this.openFileDialog1.Filter = "PDF-Dateien|*.pdf";
         this.openFileDialog1.Title = "PDF-Datei öffnen";
         // 
         // saveFileDialog1
         // 
         this.saveFileDialog1.DefaultExt = "pdf";
         this.saveFileDialog1.Filter = "PDF-Datei|*.pdf";
         // 
         // MainForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(614, 564);
         this.Controls.Add(this.toolStrip1);
         this.Controls.Add(this.menuStrip1);
         this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
         this.IsMdiContainer = true;
         this.MainMenuStrip = this.menuStrip1;
         this.Name = "MainForm";
         this.Text = "Form1";
         this.Activated += new System.EventHandler(this.MainForm_Activated);
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
         this.Load += new System.EventHandler(this.MainForm_Load);
         this.Shown += new System.EventHandler(this.MainForm_Shown);
         this.menuStrip1.ResumeLayout(false);
         this.menuStrip1.PerformLayout();
         this.toolStrip1.ResumeLayout(false);
         this.toolStrip1.PerformLayout();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private System.Windows.Forms.MenuStrip menuStrip1;
      private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem fensterToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Icon;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Cascade;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Horizontal;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Vertical;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparatorBeforeWins;
      private System.Windows.Forms.ToolStrip toolStrip1;
      private System.Windows.Forms.ToolStripButton toolStripButton_RotateLeft;
      private System.Windows.Forms.ToolStripButton toolStripButton_RotateRight;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
      private System.Windows.Forms.ToolStripButton toolStripButton_PageView;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
      private System.Windows.Forms.ToolStripButton toolStripButton_Save;
      private System.Windows.Forms.ToolStripButton toolStripButton_Remove;
      private System.Windows.Forms.OpenFileDialog openFileDialog1;
      private System.Windows.Forms.SaveFileDialog saveFileDialog1;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_LoadFileInPageView;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_NewPageView;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_SavePageView;
      private System.Windows.Forms.ToolStripMenuItem bearbeitenToolStripMenuItem;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_RotateLeft;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_RotateRight;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Remove;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_PageView;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
      private System.Windows.Forms.ToolStripButton toolStripButton_scan;
      private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_ScanPage;
      private System.Windows.Forms.ToolStripButton toolStripButton_ShowScanProps;
      private System.Windows.Forms.ToolStripButton toolStripButton_new;
      private System.Windows.Forms.ToolStripButton toolStripButton_Paste;
      private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
      private System.Windows.Forms.ToolStripButton toolStripButton_Copy;
   }
}

