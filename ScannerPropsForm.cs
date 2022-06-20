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


      public event EventHandler OnInitChanged;


      /// <summary>
      /// Kann ein Scanner verwendet werden?
      /// </summary>
      public bool ScannerIsInit {
         get => scanner != null;
      }

      Scanner scanner;

      List<PaperSizeItem> papersizelist = new List<PaperSizeItem>();

      List<int> dpilist = new List<int>();


      string ScannerName {
         get => scanner != null ? button_Scanner.Text : "";
         set => button_Scanner.Text = value;
      }

      int Dpi {
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

      PaperSizeItem PaperSize {
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

      Scanner.ImageType ImageType {
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

      /// <summary>
      /// -1 .. +1
      /// </summary>
      double Brightness {
         get => scanner != null ? (double)numericUpDown_Brightness.Value / 100 : 0;
         set {
            numericUpDown_Brightness.Value = (int)(value * 100);
         }
      }

      /// <summary>
      /// -1 .. +1
      /// </summary>
      double Contrast {
         get => scanner != null ? (double)numericUpDown_Contrast.Value / 100 : 0;
         set {
            numericUpDown_Contrast.Value = (int)(value * 100);
         }
      }

      string Filetype {
         get {
            if (radioButton_BMP.Checked)
               return "BMP";
            if (radioButton_JPG.Checked)
               return "JPG";
            if (radioButton_PNG.Checked)
               return "PNG";
            if (radioButton_TIF.Checked)
               return "TIF";
            return null;
         }
         set {
            if (value == "BMP")
               radioButton_BMP.Checked = true;
            if (value == "JPG")
               radioButton_JPG.Checked = true;
            if (value == "PNG")
               radioButton_PNG.Checked = true;
            if (value == "TIF")
               radioButton_TIF.Checked = true;
         }
      }

      int Quali {
         get => (int)numericUpDown_JPGQuali.Value;
         set => numericUpDown_JPGQuali.Value = value;
      }

      double DeltaX {
         get => (double)numericUpDown_DeltaX.Value;
         set => numericUpDown_DeltaX.Value = (decimal)value;
      }

      double DeltaY {
         get => (double)numericUpDown_DeltaY.Value;
         set => numericUpDown_DeltaY.Value = (decimal)value;
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
            return PaperSize.ToString() + " " + Portrait;
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

      private void ScannerPropsForm_Shown(object sender, EventArgs e) {
         loadStatus();
      }

      private void ScannerPropsForm_FormClosing(object sender, FormClosingEventArgs e) {
         saveStatus();
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
            numericUpDown_Contrast.Enabled =
            numericUpDown_DeltaX.Enabled =
            numericUpDown_DeltaY.Enabled = true;

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
                  else
                     PaperSize = papersizelist[0];

                  Brightness = brightness;
                  Contrast = contrast;
                  Filetype = "JPG";

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
                     OnInitChanged?.Invoke(this, EventArgs.Empty);
                  }
               }
            }

         } else {

            comboBox_PaperSize.Enabled =
            comboBox_DPI.Enabled =
            groupBox1.Enabled =
            groupBox2.Enabled =
            numericUpDown_Brightness.Enabled =
            numericUpDown_Contrast.Enabled =
            numericUpDown_DeltaX.Enabled =
            numericUpDown_DeltaY.Enabled = false;
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
         Scanner oldscanner = scanner;
         try {
            scanner = Scanner.Connect(-1);
            init4Scanner(scanner);
         } catch (COMException ex) {
            showError(ErrorCodes.GetErrorText((uint)ex.ErrorCode));
         } catch (Exception ex) {
            showError(ex.Message);
         }
         if ((oldscanner != null) != (scanner != null))
            OnInitChanged?.Invoke(this, EventArgs.Empty);
      }

      private void radioButton_JPG_CheckedChanged(object sender, EventArgs e) {
         numericUpDown_JPGQuali.Enabled = radioButton_JPG.Checked;
      }

      void showError(string message) {
         MessageBox.Show(message, "Fehler", MessageBoxButtons.OK, MessageBoxIcon.Error);
      }

      public Bitmap GetImage(out double widthmm, out double heightmm) {
         widthmm = heightmm = 0;
         if (scanner == null)
            return null;

         bool error = false;
         try {

            scanner.GetPaperSize(PaperSize.PaperSize, out double w, out double h);
            widthmm = w;
            heightmm = h;
            if (!PaperSize.Portrait) {
               double tmp = widthmm;
               widthmm = heightmm;
               heightmm = tmp;
            }

            scanner.SetProperties(Dpi,
                                  (double)numericUpDown_DeltaX.Value, (double)numericUpDown_DeltaY.Value,
                                  PaperSize.PaperSize,
                                  PaperSize.Portrait,
                                  ImageType,
                                  Scanner.ImageTypeExt.Nothing,
                                  Brightness,
                                  Contrast);
            Bitmap scanbm = scanner.GetImage(true, Dpi, Dpi);

            //// reale Größe ermitteln
            //w = 25.4 * scanbm.Width / scanbm.HorizontalResolution;
            //h = 25.4 * scanbm.Height / scanbm.VerticalResolution;

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
               OnInitChanged?.Invoke(this, EventArgs.Empty);
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

      private void button_end_Click(object sender, EventArgs e) {
         Visible = false;
         saveStatus();
      }

      void saveStatus() {
         Properties.Settings.Default.ScannerName = ScannerName;
         Properties.Settings.Default.ScannerDpi = (uint)Dpi;
         Properties.Settings.Default.ScannerContrast = Contrast;
         Properties.Settings.Default.ScannerBrightness = Brightness;
         Properties.Settings.Default.ScannerImageType = ImageType.ToString();
         Properties.Settings.Default.ScannerPaperSize = PaperSize != null ? PaperSize.ToString() : "";
         Properties.Settings.Default.ScannerFiletype = Filetype;
         Properties.Settings.Default.ScannerQuali = Quali;
         Properties.Settings.Default.ScannerDeltaX = DeltaX;
         Properties.Settings.Default.ScannerDeltaY = DeltaY;
         Properties.Settings.Default.Save();
      }

      void loadStatus() {
         Cursor orgcursor = Cursor;
         Scanner oldscanner = scanner;
         try {
            Cursor = Cursors.WaitCursor;
            Properties.Settings.Default.Reload();
            if (!string.IsNullOrEmpty(Properties.Settings.Default.ScannerName)) {
               scanner = getScanner4Name(Properties.Settings.Default.ScannerName);
               if (scanner != null) {
                  init4Scanner(scanner);

                  foreach (var item in Enum.GetValues(typeof(Scanner.ImageType))) {
                     if (item.ToString() == Properties.Settings.Default.ScannerImageType) {
                        ImageType = (Scanner.ImageType)item;
                        break;
                     }
                  }

                  int dpi = (int)Properties.Settings.Default.ScannerDpi;
                  if (dpi > 0)
                     Dpi = dpi;

                  string[] papersize = Properties.Settings.Default.ScannerPaperSize.Split(' ');
                  if (papersize.Length == 2) {
                     bool portrait = Convert.ToBoolean(papersize[1]);
                     foreach (var item in Enum.GetValues(typeof(Scanner.PaperSize))) {
                        if (item.ToString() == papersize[0]) {
                           PaperSize = new PaperSizeItem((Scanner.PaperSize)item, portrait);
                           break;
                        }
                     }
                  }

                  double contrast = Properties.Settings.Default.ScannerContrast;
                  if (-1 <= contrast && contrast <= 1)
                     Contrast = contrast;

                  double brightness = Properties.Settings.Default.ScannerBrightness;
                  if (-1 <= brightness && brightness <= 1)
                     Brightness = brightness;

                  Filetype = Properties.Settings.Default.ScannerFiletype;

                  double quali = Properties.Settings.Default.ScannerQuali;
                  if (0 < quali && quali <= 100)
                     Quali = (int)quali;

                  DeltaX = Properties.Settings.Default.ScannerDeltaX;
                  DeltaY = Properties.Settings.Default.ScannerDeltaY;

               }
            }
         } catch (Exception ex) {
            Cursor = orgcursor;
            showError(ex.Message);
         }
         Cursor = orgcursor;

         if ((oldscanner != null) != (scanner != null))
            OnInitChanged?.Invoke(this, EventArgs.Empty);
      }

      Scanner getScanner4Name(string name) {
         Scanner.GetScannerList(out List<string> names);
         for (int i = 0; i < names.Count; i++) {
            if (names[i] == name) {
               return Scanner.Connect(i);
            }
         }
         return null;
      }

   }
}
