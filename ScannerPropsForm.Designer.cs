namespace PdfArranger {
   partial class ScannerPropsForm {
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
         this.button_Scanner = new System.Windows.Forms.Button();
         this.groupBox1 = new System.Windows.Forms.GroupBox();
         this.radioButton_BlackWhite = new System.Windows.Forms.RadioButton();
         this.radioButton_Grayscale = new System.Windows.Forms.RadioButton();
         this.radioButton_Color = new System.Windows.Forms.RadioButton();
         this.groupBox2 = new System.Windows.Forms.GroupBox();
         this.numericUpDown_JPGQuali = new System.Windows.Forms.NumericUpDown();
         this.label5 = new System.Windows.Forms.Label();
         this.radioButton_BMP = new System.Windows.Forms.RadioButton();
         this.radioButton_TIF = new System.Windows.Forms.RadioButton();
         this.radioButton_PNG = new System.Windows.Forms.RadioButton();
         this.radioButton_JPG = new System.Windows.Forms.RadioButton();
         this.comboBox_DPI = new System.Windows.Forms.ComboBox();
         this.label1 = new System.Windows.Forms.Label();
         this.comboBox_PaperSize = new System.Windows.Forms.ComboBox();
         this.label2 = new System.Windows.Forms.Label();
         this.numericUpDown_Brightness = new System.Windows.Forms.NumericUpDown();
         this.numericUpDown_Contrast = new System.Windows.Forms.NumericUpDown();
         this.label3 = new System.Windows.Forms.Label();
         this.label4 = new System.Windows.Forms.Label();
         this.panel1 = new System.Windows.Forms.Panel();
         this.groupBox1.SuspendLayout();
         this.groupBox2.SuspendLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_JPGQuali)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Brightness)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Contrast)).BeginInit();
         this.SuspendLayout();
         // 
         // button_Scanner
         // 
         this.button_Scanner.Location = new System.Drawing.Point(12, 12);
         this.button_Scanner.Name = "button_Scanner";
         this.button_Scanner.Size = new System.Drawing.Size(349, 23);
         this.button_Scanner.TabIndex = 0;
         this.button_Scanner.Text = "button1";
         this.button_Scanner.UseVisualStyleBackColor = true;
         this.button_Scanner.Click += new System.EventHandler(this.button_Scanner_Click);
         // 
         // groupBox1
         // 
         this.groupBox1.Controls.Add(this.radioButton_BlackWhite);
         this.groupBox1.Controls.Add(this.radioButton_Grayscale);
         this.groupBox1.Controls.Add(this.radioButton_Color);
         this.groupBox1.Location = new System.Drawing.Point(15, 41);
         this.groupBox1.Name = "groupBox1";
         this.groupBox1.Size = new System.Drawing.Size(124, 96);
         this.groupBox1.TabIndex = 1;
         this.groupBox1.TabStop = false;
         this.groupBox1.Text = "&Bildtyp";
         // 
         // radioButton_BlackWhite
         // 
         this.radioButton_BlackWhite.AutoSize = true;
         this.radioButton_BlackWhite.Location = new System.Drawing.Point(7, 66);
         this.radioButton_BlackWhite.Name = "radioButton_BlackWhite";
         this.radioButton_BlackWhite.Size = new System.Drawing.Size(98, 17);
         this.radioButton_BlackWhite.TabIndex = 2;
         this.radioButton_BlackWhite.Text = "Schwarz-Weiss";
         this.radioButton_BlackWhite.UseVisualStyleBackColor = true;
         // 
         // radioButton_Grayscale
         // 
         this.radioButton_Grayscale.AutoSize = true;
         this.radioButton_Grayscale.ForeColor = System.Drawing.Color.Gray;
         this.radioButton_Grayscale.Location = new System.Drawing.Point(7, 43);
         this.radioButton_Grayscale.Name = "radioButton_Grayscale";
         this.radioButton_Grayscale.Size = new System.Drawing.Size(77, 17);
         this.radioButton_Grayscale.TabIndex = 1;
         this.radioButton_Grayscale.Text = "Graustufen";
         this.radioButton_Grayscale.UseVisualStyleBackColor = true;
         // 
         // radioButton_Color
         // 
         this.radioButton_Color.AutoSize = true;
         this.radioButton_Color.Checked = true;
         this.radioButton_Color.ForeColor = System.Drawing.Color.Red;
         this.radioButton_Color.Location = new System.Drawing.Point(7, 20);
         this.radioButton_Color.Name = "radioButton_Color";
         this.radioButton_Color.Size = new System.Drawing.Size(52, 17);
         this.radioButton_Color.TabIndex = 0;
         this.radioButton_Color.TabStop = true;
         this.radioButton_Color.Text = "Farbe";
         this.radioButton_Color.UseVisualStyleBackColor = true;
         // 
         // groupBox2
         // 
         this.groupBox2.Controls.Add(this.numericUpDown_JPGQuali);
         this.groupBox2.Controls.Add(this.label5);
         this.groupBox2.Controls.Add(this.radioButton_BMP);
         this.groupBox2.Controls.Add(this.radioButton_TIF);
         this.groupBox2.Controls.Add(this.radioButton_PNG);
         this.groupBox2.Controls.Add(this.radioButton_JPG);
         this.groupBox2.Location = new System.Drawing.Point(171, 41);
         this.groupBox2.Name = "groupBox2";
         this.groupBox2.Size = new System.Drawing.Size(190, 116);
         this.groupBox2.TabIndex = 2;
         this.groupBox2.TabStop = false;
         this.groupBox2.Text = "&Dateityp";
         // 
         // numericUpDown_JPGQuali
         // 
         this.numericUpDown_JPGQuali.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
         this.numericUpDown_JPGQuali.Location = new System.Drawing.Point(118, 20);
         this.numericUpDown_JPGQuali.Name = "numericUpDown_JPGQuali";
         this.numericUpDown_JPGQuali.Size = new System.Drawing.Size(54, 20);
         this.numericUpDown_JPGQuali.TabIndex = 2;
         this.numericUpDown_JPGQuali.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(69, 22);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(43, 13);
         this.label5.TabIndex = 1;
         this.label5.Text = "&Qualität";
         // 
         // radioButton_BMP
         // 
         this.radioButton_BMP.AutoSize = true;
         this.radioButton_BMP.Location = new System.Drawing.Point(6, 89);
         this.radioButton_BMP.Name = "radioButton_BMP";
         this.radioButton_BMP.Size = new System.Drawing.Size(48, 17);
         this.radioButton_BMP.TabIndex = 5;
         this.radioButton_BMP.Text = "B&MP";
         this.radioButton_BMP.UseVisualStyleBackColor = true;
         // 
         // radioButton_TIF
         // 
         this.radioButton_TIF.AutoSize = true;
         this.radioButton_TIF.Location = new System.Drawing.Point(6, 66);
         this.radioButton_TIF.Name = "radioButton_TIF";
         this.radioButton_TIF.Size = new System.Drawing.Size(41, 17);
         this.radioButton_TIF.TabIndex = 4;
         this.radioButton_TIF.Text = "&TIF";
         this.radioButton_TIF.UseVisualStyleBackColor = true;
         // 
         // radioButton_PNG
         // 
         this.radioButton_PNG.AutoSize = true;
         this.radioButton_PNG.Location = new System.Drawing.Point(6, 43);
         this.radioButton_PNG.Name = "radioButton_PNG";
         this.radioButton_PNG.Size = new System.Drawing.Size(48, 17);
         this.radioButton_PNG.TabIndex = 3;
         this.radioButton_PNG.Text = "&PNG";
         this.radioButton_PNG.UseVisualStyleBackColor = true;
         // 
         // radioButton_JPG
         // 
         this.radioButton_JPG.AutoSize = true;
         this.radioButton_JPG.Checked = true;
         this.radioButton_JPG.Location = new System.Drawing.Point(6, 20);
         this.radioButton_JPG.Name = "radioButton_JPG";
         this.radioButton_JPG.Size = new System.Drawing.Size(45, 17);
         this.radioButton_JPG.TabIndex = 0;
         this.radioButton_JPG.TabStop = true;
         this.radioButton_JPG.Text = "&JPG";
         this.radioButton_JPG.UseVisualStyleBackColor = true;
         this.radioButton_JPG.CheckedChanged += new System.EventHandler(this.radioButton_JPG_CheckedChanged);
         // 
         // comboBox_DPI
         // 
         this.comboBox_DPI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_DPI.FormattingEnabled = true;
         this.comboBox_DPI.Location = new System.Drawing.Point(266, 175);
         this.comboBox_DPI.Name = "comboBox_DPI";
         this.comboBox_DPI.Size = new System.Drawing.Size(95, 21);
         this.comboBox_DPI.TabIndex = 8;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(230, 178);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(21, 13);
         this.label1.TabIndex = 7;
         this.label1.Text = "&dpi";
         // 
         // comboBox_PaperSize
         // 
         this.comboBox_PaperSize.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         this.comboBox_PaperSize.FormattingEnabled = true;
         this.comboBox_PaperSize.Location = new System.Drawing.Point(102, 240);
         this.comboBox_PaperSize.Name = "comboBox_PaperSize";
         this.comboBox_PaperSize.Size = new System.Drawing.Size(259, 21);
         this.comboBox_PaperSize.TabIndex = 10;
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(19, 243);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(67, 13);
         this.label2.TabIndex = 9;
         this.label2.Text = "&Scanbereich";
         // 
         // numericUpDown_Brightness
         // 
         this.numericUpDown_Brightness.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
         this.numericUpDown_Brightness.Location = new System.Drawing.Point(102, 176);
         this.numericUpDown_Brightness.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this.numericUpDown_Brightness.Name = "numericUpDown_Brightness";
         this.numericUpDown_Brightness.Size = new System.Drawing.Size(54, 20);
         this.numericUpDown_Brightness.TabIndex = 4;
         this.numericUpDown_Brightness.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // numericUpDown_Contrast
         // 
         this.numericUpDown_Contrast.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
         this.numericUpDown_Contrast.Location = new System.Drawing.Point(102, 207);
         this.numericUpDown_Contrast.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
         this.numericUpDown_Contrast.Name = "numericUpDown_Contrast";
         this.numericUpDown_Contrast.Size = new System.Drawing.Size(54, 20);
         this.numericUpDown_Contrast.TabIndex = 6;
         this.numericUpDown_Contrast.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(19, 178);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(50, 13);
         this.label3.TabIndex = 3;
         this.label3.Text = "&Helligkeit";
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(19, 209);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(46, 13);
         this.label4.TabIndex = 5;
         this.label4.Text = "&Kontrast";
         // 
         // panel1
         // 
         this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
         this.panel1.Location = new System.Drawing.Point(0, 0);
         this.panel1.Name = "panel1";
         this.panel1.Size = new System.Drawing.Size(378, 280);
         this.panel1.TabIndex = 11;
         // 
         // ScannerPropsForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(378, 280);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.numericUpDown_Contrast);
         this.Controls.Add(this.numericUpDown_Brightness);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.comboBox_PaperSize);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.comboBox_DPI);
         this.Controls.Add(this.groupBox2);
         this.Controls.Add(this.groupBox1);
         this.Controls.Add(this.button_Scanner);
         this.Controls.Add(this.panel1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
         this.Name = "ScannerPropsForm";
         this.ShowInTaskbar = false;
         this.Text = "Scannereigenschaften";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ScannerPropsForm_FormClosing);
         this.Load += new System.EventHandler(this.ScannerPropsForm_Load);
         this.groupBox1.ResumeLayout(false);
         this.groupBox1.PerformLayout();
         this.groupBox2.ResumeLayout(false);
         this.groupBox2.PerformLayout();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_JPGQuali)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Brightness)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.numericUpDown_Contrast)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button_Scanner;
      private System.Windows.Forms.GroupBox groupBox1;
      private System.Windows.Forms.GroupBox groupBox2;
      private System.Windows.Forms.ComboBox comboBox_DPI;
      private System.Windows.Forms.Label label1;
      private System.Windows.Forms.ComboBox comboBox_PaperSize;
      private System.Windows.Forms.Label label2;
      private System.Windows.Forms.NumericUpDown numericUpDown_Brightness;
      private System.Windows.Forms.NumericUpDown numericUpDown_Contrast;
      private System.Windows.Forms.Label label3;
      private System.Windows.Forms.Label label4;
      private System.Windows.Forms.RadioButton radioButton_BlackWhite;
      private System.Windows.Forms.RadioButton radioButton_Grayscale;
      private System.Windows.Forms.RadioButton radioButton_Color;
      private System.Windows.Forms.RadioButton radioButton_BMP;
      private System.Windows.Forms.RadioButton radioButton_TIF;
      private System.Windows.Forms.RadioButton radioButton_PNG;
      private System.Windows.Forms.RadioButton radioButton_JPG;
      private System.Windows.Forms.NumericUpDown numericUpDown_JPGQuali;
      private System.Windows.Forms.Label label5;
      private System.Windows.Forms.Panel panel1;
   }
}