using System;
using System.IO;
using System.Windows.Forms;

namespace PdfArranger {
   public partial class PdfPasswordForm : Form {

      public string Password {
         get; set;
      }

      public string PdfFile {
         get; set;
      }


      public PdfPasswordForm() {
         InitializeComponent();
      }

      private void PdfPasswordForm_Load(object sender, EventArgs e) {
         textBox_PW.Text = Password;
         checkBox_PWVisible.Checked = false;
         if (!string.IsNullOrEmpty(PdfFile))
            Text += " für '" + Path.GetFileName(PdfFile) + "'";
         textBox_File.Text = PdfFile;
      }

      private void checkBox_PWVisible_CheckedChanged(object sender, EventArgs e) {
         CheckBox cb = sender as CheckBox;
         textBox_PW.PasswordChar = cb.Checked ? '\0' : '*';
      }

      private void PdfPasswordForm_FormClosing(object sender, FormClosingEventArgs e) {
         Password = textBox_PW.Text;
      }
   }
}
