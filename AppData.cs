using FSofTUtils;
using System;

namespace PdfArranger {
   public class AppData {

      PersistentDataXml data;

      public uint ImageSizeStep {
         get => data.Get(nameof(ImageSizeStep), 4U);
         set => data.Set(nameof(ImageSizeStep), value);
      }

      public string ScannerName {
         get => data.Get(nameof(ScannerName), "");
         set => data.Set(nameof(ScannerName), value);
      }

      public uint ScannerDpi {
         get => data.Get(nameof(ScannerDpi), 300U);
         set => data.Set(nameof(ScannerDpi), Math.Max(0, value));
      }

      public double ScannerContrast {
         get => data.Get(nameof(ScannerContrast), 0);
         set => data.Set(nameof(ScannerContrast), Math.Max(-1.0, Math.Min(value, 1.0)));
      }

      public double ScannerBrightness {
         get => data.Get(nameof(ScannerBrightness), 0);
         set => data.Set(nameof(ScannerBrightness), Math.Max(-1.0, Math.Min(value, 1.0)));
      }

      public string ScannerImageType {
         get => data.Get(nameof(ScannerImageType), "");
         set => data.Set(nameof(ScannerImageType), value);
      }

      public string ScannerPaperSize {
         get => data.Get(nameof(ScannerPaperSize), "");
         set => data.Set(nameof(ScannerPaperSize), value);
      }

      public string ScannerFiletype {
         get => data.Get(nameof(ScannerFiletype), "");
         set => data.Set(nameof(ScannerFiletype), value);
      }

      public int ScannerQuali {
         get => data.Get(nameof(ScannerQuali), 0);
         set => data.Set(nameof(ScannerQuali), Math.Max(0, Math.Min(value, 100)));
      }

      public double ScannerDeltaX {
         get => data.Get(nameof(ScannerDeltaX), 0);
         set => data.Set(nameof(ScannerDeltaX), value);
      }

      public double ScannerDeltaY {
         get => data.Get(nameof(ScannerDeltaY), 0);
         set => data.Set(nameof(ScannerDeltaY), value);
      }



      public AppData(string name, bool local = false) {
         data = new PersistentDataXml(name, local);
      }

      public void Save() {
         data.Save();
      }

      public void Reload() {
         data = data.Load();
      }

   }
}
