
namespace PdfArranger {
   partial class PdfPasswordForm {
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
         this.button_OK = new System.Windows.Forms.Button();
         this.button_Cancel = new System.Windows.Forms.Button();
         this.textBox_PW = new System.Windows.Forms.TextBox();
         this.checkBox_PWVisible = new System.Windows.Forms.CheckBox();
         this.textBox_File = new System.Windows.Forms.TextBox();
         this.SuspendLayout();
         // 
         // button_OK
         // 
         this.button_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
         this.button_OK.Location = new System.Drawing.Point(291, 49);
         this.button_OK.Name = "button_OK";
         this.button_OK.Size = new System.Drawing.Size(75, 23);
         this.button_OK.TabIndex = 1;
         this.button_OK.Text = "OK";
         this.button_OK.UseVisualStyleBackColor = true;
         // 
         // button_Cancel
         // 
         this.button_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
         this.button_Cancel.Location = new System.Drawing.Point(291, 89);
         this.button_Cancel.Name = "button_Cancel";
         this.button_Cancel.Size = new System.Drawing.Size(75, 23);
         this.button_Cancel.TabIndex = 3;
         this.button_Cancel.Text = "Abbruch";
         this.button_Cancel.UseVisualStyleBackColor = true;
         // 
         // textBox_PW
         // 
         this.textBox_PW.Location = new System.Drawing.Point(12, 51);
         this.textBox_PW.Name = "textBox_PW";
         this.textBox_PW.PasswordChar = '*';
         this.textBox_PW.Size = new System.Drawing.Size(249, 20);
         this.textBox_PW.TabIndex = 0;
         // 
         // checkBox_PWVisible
         // 
         this.checkBox_PWVisible.AutoSize = true;
         this.checkBox_PWVisible.Location = new System.Drawing.Point(12, 93);
         this.checkBox_PWVisible.Name = "checkBox_PWVisible";
         this.checkBox_PWVisible.Size = new System.Drawing.Size(156, 17);
         this.checkBox_PWVisible.TabIndex = 2;
         this.checkBox_PWVisible.Text = "Passwort sichtbar eingeben";
         this.checkBox_PWVisible.UseVisualStyleBackColor = true;
         this.checkBox_PWVisible.CheckedChanged += new System.EventHandler(this.checkBox_PWVisible_CheckedChanged);
         // 
         // textBox_File
         // 
         this.textBox_File.Location = new System.Drawing.Point(12, 12);
         this.textBox_File.Name = "textBox_File";
         this.textBox_File.ReadOnly = true;
         this.textBox_File.Size = new System.Drawing.Size(354, 20);
         this.textBox_File.TabIndex = 4;
         // 
         // PdfPasswordForm
         // 
         this.AcceptButton = this.button_OK;
         this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.CancelButton = this.button_Cancel;
         this.ClientSize = new System.Drawing.Size(388, 127);
         this.ControlBox = false;
         this.Controls.Add(this.textBox_File);
         this.Controls.Add(this.checkBox_PWVisible);
         this.Controls.Add(this.textBox_PW);
         this.Controls.Add(this.button_Cancel);
         this.Controls.Add(this.button_OK);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
         this.Name = "PdfPasswordForm";
         this.Text = "Passwort";
         this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PdfPasswordForm_FormClosing);
         this.Load += new System.EventHandler(this.PdfPasswordForm_Load);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private System.Windows.Forms.Button button_OK;
      private System.Windows.Forms.Button button_Cancel;
      private System.Windows.Forms.TextBox textBox_PW;
      private System.Windows.Forms.CheckBox checkBox_PWVisible;
      private System.Windows.Forms.TextBox textBox_File;
   }
}