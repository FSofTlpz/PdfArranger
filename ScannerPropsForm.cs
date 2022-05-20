using FSofTUtils.WIAHelper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace PdfArranger {
   public partial class ScannerPropsForm : Form {

      public bool ScannerIsInit {
         get => scanner != null;
      }

      Scanner scanner;

      List<PaperSizeItem> papersizelist = new List<PaperSizeItem>();

      List<int> dpilist = new List<int>();


      public string ScannerName {
         get => scanner != null ? button_Scanner.Text : "";
         set => button_Scanner.Text = value;
      }

      public int Dpi {
         get => scanner != null ? dpilist[comboBox_DPI.SelectedIndex] : 0;
         set {
            if (scanner != null) {
               for (int i = 0; i < dpilist.Count; i++) {
                  if (dpilist[i] == value) {
                     comboBox_DPI.SelectedIndex = i;
                     break;
                  }
               }
            }
         }
      }

      public PaperSizeItem PaperSize {
         get => scanner != null ? papersizelist[comboBox_PaperSize.SelectedIndex] : null;
         set {
            if (scanner != null) {
               for (int i = 0; i < papersizelist.Count; i++) {
                  if (papersizelist[i].PaperSize == value.PaperSize &&
                      papersizelist[i].Portrait == value.Portrait) {
                     comboBox_PaperSize.SelectedIndex = i;
                     break;
                  }
               }
            }
         }
      }

      public Scanner.ImageType ImageType {
         get {
            if (scanner != null) {
               if (radioButton_Color.Checked)
                  return Scanner.ImageType.Color;
               if (radioButton_Grayscale.Checked)
                  return Scanner.ImageType.Grayscale;
               if (radioButton_BlackWhite.Checked)
                  return Scanner.ImageType.Text;
            }
            return Scanner.ImageType.Nothing;
         }
         set {
            switch (value) {
               case Scanner.ImageType.Nothing:
               case Scanner.ImageType.Color: radioButton_Color.Checked = true; break;
               case Scanner.ImageType.Grayscale: radioButton_Grayscale.Checked = true; break;
               case Scanner.ImageType.Text: radioButton_BlackWhite.Checked = true; break;
            }
         }
      }

      public double Brightness {
         get => scanner != null ? (double)numericUpDown_Brightness.Value / 100 : 0;
         set {
            numericUpDown_Brightness.Value = (int)(value * 100);
         }
      }

      public double Contrast {
         get => scanner != null ? (double)numericUpDown_Contrast.Value / 100 : 0;
         set {
            numericUpDown_Contrast.Value = (int)(value * 100);
         }
      }


      public class PaperSizeItem {

         public Scanner.PaperSize PaperSize {
            get;
            protected set;
         }

         public bool Portrait {
            get;
            protected set;
         }


         public PaperSizeItem(Scanner.PaperSize papersize, bool portrait) {
            PaperSize = papersize;
            Portrait = portrait;
         }

         override public string ToString() {
            return PaperSize.ToString() + ", Portrait " + Portrait;
         }
      }


      public ScannerPropsForm() {
         InitializeComponent();
      }

      private void ScannerPropsForm_Load(object sender, EventArgs e) {
         numericUpDown_JPGQuali.Value = 90;
         radioButton_JPG_CheckedChanged(null, null);
         init4Scanner(null);
      }

      private void ScannerPropsForm_FormClosing(object sender, FormClosingEventArgs e) {

      }

      void init4Scanner(Scanner scanner) {
         comboBox_DPI.Items.Clear();
         comboBox_PaperSize.Items.Clear();
         papersizelist.Clear();
         dpilist.Clear();

         if (scanner != null) {

            comboBox_PaperSize.Enabled =
            comboBox_DPI.Enabled =
            groupBox1.Enabled =
            groupBox2.Enabled =
            numericUpDown_Brightness.Enabled =
            numericUpDown_Contrast.Enabled = true;

            ScannerName = scanner.Name();

            if (scanner != null) {

               bool error = false;
               try {
                  List<int> dpilst = scanner.GetProperties(out int left,
                                                           out int top,
                                                           out int widthpixel,
                                                           out int heightpixel,
                                                           out Scanner.ImageType imgtype,
                                                           out Scanner.ImageTypeExt imgtypeext,
                                                           out double brightness,
                                                           out double contrast,
                                                           out int dpi);
                  foreach (var item in dpilst) {
                     dpilist.Add(item);
                     comboBox_DPI.Items.Add(item);
                  }
                  Dpi = dpi;

                  ImageType = imgtype;

                  foreach (var item in scanner.GetValidPaperFormats()) {
                     comboBox_PaperSize.Items.Add(string.Format("{0}, {1}, {2:0} mm x {3:0} mm",
                                                                item.PaperSize.ToString(),
                                                                item.Width < item.Height ? "Hochformat" : "Querformat",
                                                                item.Width,
                                                                item.Height));
                     papersizelist.Add(new PaperSizeItem(item.PaperSize, item.Width < item.Height));
                  }

                  PaperSizeItem psi = getPaperSizeItem((int)Math.Round(widthpixel / 25.4), (int)Math.Round(heightpixel / 25.4));
                  if (psi != null)
                     PaperSize = psi;

                  Brightness = brightness;
                  Contrast = contrast;

                  radioButton_PNG.Checked = true;
                  numericUpDown_JPGQuali.Enabled = false;

               } catch (COMException ex) {
                  showError(ErrorCodes.GetErrorText((uint)ex.ErrorCode));
                  error = true;
               } catch (Exception ex) {
                  showError(ex.Message);
                  error = true;
               } finally {
                  if (error) {
                     scanner = null;
                     init4Scanner(scanner);
                  }
               }
            }

         } else {

            comboBox_PaperSize.Enabled =
            comboBox_DPI.Enabled =
            groupBox1.Enabled =
            groupBox2.Enabled =
            numericUpDown_Brightness.Enabled =
            numericUpDown_Contrast.Enabled = false;
            ScannerName = "Scannerauswahl";

         }
      }

      PaperSizeItem getPaperSizeItem(int widthmm, int heightmm) {
         foreach (var item in scanner.GetValidPaperFormats()) {
            if (item.Width == widthmm &&
                item.Height == heightmm)
               return new PaperSizeItem(item.PaperSize, item.Width < item.Height);
         }
         return null;
      }

      private void button_Scanner_Click(object sender, EventArgs e) {
         try {
            scanner = Scanner.Connect(-1);
            init4Scanner(scanner);
         } catch (COMException ex) {
            showError(ErrorCodes.GetErrorText((uint)ex.ErrorCode));
         } catch (Exception ex) {
            showError(ex.Message);
         }
      }

      private void radioButton_JPG_CheckedChanged(object sender, EventArgs e) {
         numericUpDown_JPGQuali.Enabled = radioButton_JPG.Checked;
      }

      void showError(string message) {
         MessageBox.Show(message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      public Bitmap GetImage(out float widthmm, out float heightmm) {
         widthmm = heightmm = 0;
         if (scanner == null)
            return null;

         bool error = false;
         try {

            scanner.GetPaperSize(PaperSize.PaperSize, out double w, out double h);
            widthmm = (float)w;
            heightmm = (float)h;
            if (!PaperSize.Portrait) {
               float tmp = widthmm;
               widthmm = heightmm;
               heightmm = tmp;
            }

            scanner.SetProperties(Dpi,
                                  PaperSize.PaperSize,
                                  PaperSize.Portrait,
                                  ImageType,
                                  Scanner.ImageTypeExt.Nothing,
                                  Brightness,
                                  Contrast);
            Bitmap scanbm = scanner.GetImage(true);
            return convertBitmap(scanbm,
                                 radioButton_JPG.Checked ? ImageFormat.Jpeg :
                                    radioButton_PNG.Checked ? ImageFormat.Png :
                                    radioButton_TIF.Checked ? ImageFormat.Tiff :
                                    ImageFormat.Bmp,
                                 (int)numericUpDown_JPGQuali.Value);

         } catch (COMException ex) {
            showError(ErrorCodes.GetErrorText((uint)ex.ErrorCode));
            error = true;
         } catch (Exception ex) {
            showError(ex.Message);
            error = true;
         } finally {
            if (error) {
               scanner = null;
               init4Scanner(scanner);
            }
         }
         return null;
      }

      static Bitmap convertBitmap(Bitmap bm, ImageFormat format, int jpegquali = 90) {
         if (bm != null) {
            MemoryStream ms = new MemoryStream();

            if (!format.Equals(ImageFormat.Jpeg))
               bm.Save(ms, format);
            else {

               // Create an Encoder object based on the GUID for the Quality parameter category.
               System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
               // Create an EncoderParameters object. In this case, there is only one
               // EncoderParameter object in the array.
               EncoderParameters myEncoderParameters = new EncoderParameters(1);
               // Save the bitmap with quality level ...
               EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, Convert.ToInt32(jpegquali));
               myEncoderParameters.Param[0] = myEncoderParameter;
               // Get an ImageCodecInfo object that represents the JPEG codec.
               ImageCodecInfo myImageCodecInfo = null;
               ImageCodecInfo[] encoders = ImageCodecInfo.GetImageEncoders();
               for (int j = 0; j < encoders.Length; j++)
                  if (encoders[j].MimeType == "image/jpeg")
                     myImageCodecInfo = encoders[j];
               if (myImageCodecInfo != null)
                  bm.Save(ms, myImageCodecInfo, myEncoderParameters);
            }

            if (ms.Length > 0)
               return new Bitmap(ms);
         }
         return null;
      }

   }
}
