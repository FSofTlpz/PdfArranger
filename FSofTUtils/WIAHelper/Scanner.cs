using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;

namespace FSofTUtils.WIAHelper {
   public class Scanner {

      //FSofTUtils.WIAHelper.Scanner.ImageType

      /* Das Koordinatensystem des Scanbereiches hat links oben für die Vorlage den Koordinatenursprung. Das entspricht der Ecke rechts oben auf der Glasplatte.
       * 
       * 
       * Scanner-Probleme
       * 
       * Flachbettscanner HP LJ M176
       * 
       *    Die scheinbar verwendbare Glasfläche (218mm x 303mm) ist etwas größer als die vom Scanner gelieferte max. Größe des Scannbereiches (216mm x 297mm).
       *    Der reale Scannbereich (213mm x 293mm) ist sogar noch etwas kleiner.
       *    Diese Daten liefert der Scanner leider nicht.
       *    
       *    Für einen Scanbereich 216mm x 297mm bei 200 dpi wird ein Bild mit 1700x2338 Pixeln geliefert -> 215,9mm x 296,926mm
       *    Es wird aber nur der Bereich 213mm x 293mm gescannt. Zusätzlich enthält das Bild rechts und unten einen schmalen weißen Rand, 
       *    so dass (nur) formal die richtige Größe erreicht wird.
       *    
       *    Die "Maske" auf der Glasscheibe müßte oben und links etwa 2mm und rechts und unten etwa 3mm zusätzlich von der Glasscheibe verdecken um einen
       *    sauberen "Anschlag" für die Scannvorlage zu haben.
       * 
       * A4: 210mm x 297mm
       *    Da der reale Scannbereich nur 293mm hoch ist, kann der Scanner streng genommen ein A4-Blatt nicht komplett scannen!
       *    Legt man ein A4-Blatt an die Maske oben bündig an, fehlen außerdem die oberen etwa 2mm des Blattes.
       */



      /// <summary>
      /// Bildtyp
      /// </summary>
      [Serializable]
      public enum ImageType {
         Nothing,
         Color,
         Grayscale,
         Text
      }

      /// <summary>
      /// erweiterter Bildtyp
      /// </summary>
      public enum ImageTypeExt {
         Nothing,
         MinSize,
         MaxQuality,
         BestPreview,
      }

      /// <summary>
      /// vordefinierte Scanbereiche
      /// </summary>
      public enum PaperSize {
         /// <summary>
         /// gesamter Scannerbereich
         /// </summary>
         FullArea,

         A0,
         A1,
         A2,
         A3,
         A4,
         A5,
         A6,
         A7,
         A8,
         A9,
         A10,

         B0,
         B1,
         B2,
         B3,
         B4,
         B5,
         B6,
         B7,
         B8,
         B9,
         B10,

         C0,
         C1,
         C2,
         C3,
         C4,
         C5,
         C6,
         C7,
         C8,
         C9,
         C10,

         D0,
         D1,
         D2,
         D3,
         D4,
         D5,
         D6,
         D7,

         // amerikanisch:

         Invoice,
         Executive,
         Legal,
         LetterA,
         Ledger_TabloidB,
         BroadsheetC,
         BroadsheetD,
         BroadsheetE,
         BroadsheetF,

      }
      public class PaperFormat {

         public readonly PaperSize PaperSize;

         public readonly double Width;

         public readonly double Height;


         public PaperFormat(PaperSize papersize, double width, double height) {
            PaperSize = papersize;
            Width = width;
            Height = height;
         }

         public override string ToString() {
            return PaperSize.ToString() + " (" + Width + "x" + Height + ")";
         }
      }


      WIA.Item scannerItem;
      WIA.Device device;

      /// <summary>
      /// Scannerbereich links (in mm)
      /// </summary>
      public double AreaLeft { get; protected set; }

      /// <summary>
      /// Scannerbereich oben (in mm)
      /// </summary>
      public double AreaTop { get; protected set; }

      /// <summary>
      /// Scannerbereich rechts (in mm)
      /// </summary>
      public double AreaRigth { get; protected set; }

      /// <summary>
      /// Scannerbereich unten (in mm)
      /// </summary>
      public double AreaBottom { get; protected set; }

      /// <summary>
      /// Scannerbereich Breite (in mm)
      /// </summary>
      public double AreaWidth {
         get => AreaRigth - AreaLeft;
      }

      /// <summary>
      /// Scannerbereich Höhe (in mm)
      /// </summary>
      public double AreaHeight {
         get => AreaBottom - AreaTop;
      }

      /// <summary>
      /// Liste der möglichen Scannerauflösungen
      /// </summary>
      public List<int> Dpi { get; protected set; }


      Scanner(WIA.Device device) {
         this.device = device;
         scannerItem = device?.Items[1] ??            // NOT zero based!
                       throw new Exception("Interner Fehler beim Scanner-Device.");
         readInfos();
      }

      /// <summary>
      /// liefert die Listen der vorhandenen Scanner-ID's und Namen
      /// </summary>
      /// <param name="namelist"></param>
      /// <returns></returns>
      public static List<string> GetScannerList(out List<string> namelist) {
         List<string> idlist = new List<string>();
         namelist = new List<string>();

         // Create a DeviceManager instance
         WIA.DeviceManager deviceManager = new WIA.DeviceManager();

         // Loop through the list of devices
         for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++) {   // NOT zero based
            // Skip the device if it's not a scanner
            if (deviceManager.DeviceInfos[i].Type != WIA.WiaDeviceType.ScannerDeviceType)
               continue;
            idlist.Add(deviceManager.DeviceInfos[i].DeviceID);
            WIA.Property p = deviceManager.DeviceInfos[i].Properties["Name"];
            object value = p?.get_Value();
            namelist.Add(value?.ToString() ?? "?");
         }
         return idlist;
      }

      /// <summary>
      /// liefert (verbindet) den Scanner (<see cref="WIA.Device"/>) mit dem Index (i.A. 0 oder kleiner als 0)
      /// </summary>
      /// <param name="idx">wenn kleiner als 0, dann mit Auswahldialog</param>
      /// <returns>null, wenn erfolglos</returns>
      public static Scanner Connect(int idx = -1) {
         if (idx >= 0) {
            WIA.DeviceInfo di = getScannerDeviceInfo(idx);
            WIA.Device device = di?.Connect() ?? null;
            return device != null ? new Scanner(device) : null;
         } else {
            WIA.CommonDialog dialog = new WIA.CommonDialog();
            WIA.Device device = dialog.ShowSelectDevice(DeviceType: WIA.WiaDeviceType.ScannerDeviceType,
                                                         AlwaysSelectDevice: true);
            return device != null ? new Scanner(device) : null;
         }
      }

      /// <summary>
      /// liefert die <see cref="WIA.DeviceInfo"/> des Scanners mit dem vorgegebenen Index (i.A. 0)
      /// </summary>
      /// <param name="no"></param>
      /// <returns></returns>
      static WIA.DeviceInfo getScannerDeviceInfo(int no) {
         // Create a DeviceManager instance
         WIA.DeviceManager deviceManager = new WIA.DeviceManager();

         //deviceManager.RegisterEvent(WIA.EventID.wiaEventDeviceDisconnected);
         //deviceManager.OnEvent += DeviceManager_OnEvent;

         // Loop through the list of devices
         for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++) {   // NOT zero based
            // Skip the device if it's not a scanner
            if (deviceManager.DeviceInfos[i].Type != WIA.WiaDeviceType.ScannerDeviceType)
               continue;

            if (no-- == 0)
               return deviceManager.DeviceInfos[i];
         }
         return null;
      }

      //private static void DeviceManager_OnEvent(string EventID, string DeviceID, string ItemID) {
      //}

      static int mm2Pixel(double mm, int resolution) {
         return (int)Math.Round(mm / 25.4 * resolution);
      }

      void readInfos() {
         int actualdpix = WIAHelper.Helper.GetScannerPictureXres(scannerItem.Properties, out List<int> dpix);
         int actualdpiy = WIAHelper.Helper.GetScannerPictureYres(scannerItem.Properties, out List<int> dpiy);
         int actualxextent = WIAHelper.Helper.GetScannerPictureXextent(scannerItem.Properties, out int minx, out int maxx, out int stepx);
         int actualyextent = WIAHelper.Helper.GetScannerPictureYextent(scannerItem.Properties, out int miny, out int maxy, out int stepy);
         int actualstartx = WIAHelper.Helper.GetScannerPictureXpos(scannerItem.Properties, out int minposx, out int maxposx, out int stepposx);
         int actualstarty = WIAHelper.Helper.GetScannerPictureXpos(scannerItem.Properties, out int minposy, out int maxposy, out int stepposy);

         AreaLeft = minposx * 25.4 / actualdpix;
         AreaTop = minposy * 25.4 / actualdpiy;
         AreaRigth = maxx * 25.4 / actualdpix;
         AreaBottom = maxy * 25.4 / actualdpiy;

         Dpi = new List<int>();
         foreach (int item in dpix) {
            if (dpiy.Contains(item))   // nur gemeinsame Werte
               Dpi.Add(item);
         }
      }

      /// <summary>
      /// setzt die Scanner-Eigenschaften
      /// </summary>
      /// <param name="resolution">Auflösung</param>
      /// <param name="left">linker Rand mm</param>
      /// <param name="top">oberer Rand mm</param>
      /// <param name="width">Breite in mm</param>
      /// <param name="height">Höhe in mm</param>
      /// <param name="imgtype">i.A. Farbe, Graustufen oder Text</param>
      /// <param name="imgtypeext"></param>
      /// <param name="brightness">Helligkeit -1 .. 1</param>
      /// <param name="contrast">Kontrast -1 .. 1</param>
      public void SetProperties(int resolution,
                                double left, double top, double width, double height,
                                ImageType imgtype = ImageType.Color,
                                ImageTypeExt imgtypeext = ImageTypeExt.Nothing,
                                double brightness = 0,
                                double contrast = 0) {

         int intent = 0;
         switch (imgtype) {
            case ImageType.Color: intent = WIAHelper.WiaDef.WIA_INTENT_IMAGE_TYPE_COLOR; break;
            case ImageType.Grayscale: intent = WIAHelper.WiaDef.WIA_INTENT_IMAGE_TYPE_GRAYSCALE; break;
            case ImageType.Text: intent = WIAHelper.WiaDef.WIA_INTENT_IMAGE_TYPE_TEXT; break;
         }
         switch (imgtypeext) {
            case ImageTypeExt.MaxQuality: intent |= WIAHelper.WiaDef.WIA_INTENT_MAXIMIZE_QUALITY; break;
            case ImageTypeExt.MinSize: intent |= WIAHelper.WiaDef.WIA_INTENT_MINIMIZE_SIZE; break;
            case ImageTypeExt.BestPreview: intent |= WIAHelper.WiaDef.WIA_INTENT_BEST_PREVIEW; break;
         }

         WIAHelper.Helper.SetStandardProps(scannerItem,
                                           resolution,
                                           mm2Pixel(left, resolution),
                                           mm2Pixel(top, resolution),
                                           mm2Pixel(width, resolution),
                                           mm2Pixel(height, resolution),
                                           intent,
                                           brightness, contrast);
      }

      /// <summary>
      /// setzt die Scanner-Eigenschaften
      /// </summary>
      /// <param name="resolution">Auflösung</param>
      /// <param name="left">linker Rand</param>
      /// <param name="top">oberer Rand</param>
      /// <param name="paperformat">Papierformat</param>
      /// <param name="portrait">Hoch- oder Querformat</param>
      /// <param name="imgtype">i.A. Farbe, Graustufen oder Text</param>
      /// <param name="imgtypeext"></param>
      /// <param name="brightness">Helligkeit -1 .. 1</param>
      /// <param name="contrast">Kontrast -1 .. 1</param>
      public void SetProperties(int resolution,
                                double left, double top,
                                PaperSize paperformat,
                                bool portrait,
                                ImageType imgtype = ImageType.Color,
                                ImageTypeExt imgtypeext = ImageTypeExt.Nothing,
                                double brightness = 0,
                                double contrast = 0) {
         GetPaperSize(paperformat, out double widthmm, out double heightmm);
         if (!portrait) {
            double tmp = widthmm;
            widthmm = heightmm;
            heightmm = tmp;
         }
         SetProperties(resolution, left, top, widthmm, heightmm, imgtype, imgtypeext, brightness, contrast);
      }

      /// <summary>
      /// liefert die Papiergröße in mm (Portrait)
      /// </summary>
      /// <param name="imageSize"></param>
      /// <param name="width"></param>
      /// <param name="height"></param>
      public void GetPaperSize(PaperSize imageSize, out double width, out double height) {
         switch (imageSize) {
            case PaperSize.A0: width = 841; height = 1189; break;
            case PaperSize.A1: width = 594; height = 841; break;
            case PaperSize.A2: width = 420; height = 594; break;
            case PaperSize.A3: width = 297; height = 420; break;
            case PaperSize.A4: width = 210; height = 297; break;
            case PaperSize.A5: width = 148; height = 210; break;
            case PaperSize.A6: width = 105; height = 148; break;
            case PaperSize.A7: width = 74; height = 105; break;
            case PaperSize.A8: width = 52; height = 74; break;
            case PaperSize.A9: width = 37; height = 52; break;
            case PaperSize.A10: width = 26; height = 37; break;

            case PaperSize.B0: width = 1000; height = 1414; break;
            case PaperSize.B1: width = 707; height = 1000; break;
            case PaperSize.B2: width = 500; height = 707; break;
            case PaperSize.B3: width = 353; height = 500; break;
            case PaperSize.B4: width = 250; height = 353; break;
            case PaperSize.B5: width = 176; height = 250; break;
            case PaperSize.B6: width = 125; height = 176; break;
            case PaperSize.B7: width = 88; height = 125; break;
            case PaperSize.B8: width = 62; height = 88; break;
            case PaperSize.B9: width = 44; height = 62; break;
            case PaperSize.B10: width = 31; height = 44; break;

            case PaperSize.C0: width = 917; height = 1297; break;
            case PaperSize.C1: width = 648; height = 917; break;
            case PaperSize.C2: width = 458; height = 648; break;
            case PaperSize.C3: width = 324; height = 458; break;
            case PaperSize.C4: width = 229; height = 324; break;
            case PaperSize.C5: width = 162; height = 229; break;
            case PaperSize.C6: width = 114; height = 162; break;
            case PaperSize.C7: width = 81; height = 114; break;
            case PaperSize.C8: width = 57; height = 81; break;
            case PaperSize.C9: width = 40; height = 57; break;
            case PaperSize.C10: width = 28; height = 40; break;

            case PaperSize.D0: width = 771; height = 1091; break;
            case PaperSize.D1: width = 545; height = 771; break;
            case PaperSize.D2: width = 385; height = 545; break;
            case PaperSize.D3: width = 272; height = 385; break;
            case PaperSize.D4: width = 192; height = 272; break;
            case PaperSize.D5: width = 136; height = 192; break;
            case PaperSize.D6: width = 96; height = 136; break;
            case PaperSize.D7: width = 68; height = 96; break;

            case PaperSize.Invoice: width = 5.5 * 25.4; height = 8.5 * 25.4; break;
            case PaperSize.Executive: width = 7.25 * 25.4; height = 10.5 * 25.4; break;
            case PaperSize.Legal: width = 8.5 * 25.4; height = 14 * 25.4; break;
            case PaperSize.LetterA: width = 8.5 * 25.4; height = 11 * 25.4; break;
            case PaperSize.Ledger_TabloidB: width = 11 * 25.4; height = 17 * 25.4; break;
            case PaperSize.BroadsheetC: width = 17 * 25.4; height = 22 * 25.4; break;
            case PaperSize.BroadsheetD: width = 22 * 25.4; height = 34 * 25.4; break;
            case PaperSize.BroadsheetE: width = 34 * 25.4; height = 44 * 25.4; break;
            case PaperSize.BroadsheetF: width = 28 * 25.4; height = 40 * 25.4; break;

            default: width = AreaWidth; height = AreaHeight; break;
         }
      }

      public List<PaperFormat> GetValidPaperFormats() {
         List<PaperFormat> lst = new List<PaperFormat>();
         Array allenums = Enum.GetValues(typeof(PaperSize));
         Array.Sort(allenums); // garantiert sortiert

         double areawidth = Math.Round(AreaWidth);    // runden auf volle mm !
         double areaheigth = Math.Round(AreaHeight);

         foreach (PaperSize papersize in allenums) {
            GetPaperSize(papersize, out double width, out double height); // Portrait-Maße, d.h. width < height
            if (width <= areawidth && height <= areaheigth)
               lst.Add(new PaperFormat(papersize, width, height));
            if (width <= areaheigth && height <= areawidth)
               lst.Add(new PaperFormat(papersize, height, width));
         }
         return lst;
      }

      /// <summary>
      /// liefert die akt. eingestellten Eigenschaften
      /// </summary>
      /// <param name="left"></param>
      /// <param name="top"></param>
      /// <param name="width"></param>
      /// <param name="height"></param>
      /// <param name="imgtype"></param>
      /// <param name="imgtypeext"></param>
      /// <param name="brightness"></param>
      /// <param name="contrast"></param>
      /// <param name="dpi"></param>
      /// <returns>Liste der möglichen Auflösungen</returns>
      public List<int> GetProperties(out int left, out int top, out int width, out int height,
                                     out ImageType imgtype,
                                     out ImageTypeExt imgtypeext,
                                     out double brightness,
                                     out double contrast,
                                     out int dpi) {
         int min, max, step;
         left = WIAHelper.Helper.GetScannerPictureXpos(scannerItem.Properties, out min, out max, out step);
         top = WIAHelper.Helper.GetScannerPictureYpos(scannerItem.Properties, out min, out max, out step);
         width = WIAHelper.Helper.GetScannerPictureXextent(scannerItem.Properties, out min, out max, out step);
         height = WIAHelper.Helper.GetScannerPictureYextent(scannerItem.Properties, out min, out max, out step);

         int intent = WIAHelper.Helper.GetScannerPictureCurIntent(scannerItem.Properties, out min, out max, out step);

         imgtype = ImageType.Nothing;
         if ((intent & WIAHelper.WiaDef.WIA_INTENT_IMAGE_TYPE_COLOR) != 0)
            imgtype = ImageType.Color;
         else if ((intent & WIAHelper.WiaDef.WIA_INTENT_IMAGE_TYPE_GRAYSCALE) != 0)
            imgtype = ImageType.Grayscale;
         else if ((intent & WIAHelper.WiaDef.WIA_INTENT_IMAGE_TYPE_TEXT) != 0)
            imgtype = ImageType.Text;

         imgtypeext = ImageTypeExt.Nothing;
         if ((intent & WIAHelper.WiaDef.WIA_INTENT_MINIMIZE_SIZE) != 0)
            imgtypeext = ImageTypeExt.MinSize;
         else if ((intent & WIAHelper.WiaDef.WIA_INTENT_MAXIMIZE_QUALITY) != 0)
            imgtypeext = ImageTypeExt.MaxQuality;
         else if ((intent & WIAHelper.WiaDef.WIA_INTENT_BEST_PREVIEW) != 0)
            imgtypeext = ImageTypeExt.BestPreview;

         brightness = WIAHelper.Helper.GetScannerPictureBrightness(scannerItem.Properties, out min, out max, out step);
         contrast = WIAHelper.Helper.GetScannerPictureContrast(scannerItem.Properties, out min, out max, out step);

         dpi = WIAHelper.Helper.GetScannerPictureXres(scannerItem.Properties, out List<int> dpilst);
         return dpilst;
      }

      /// <summary>
      /// liefert ein Bild vom Scanner als Bitmap
      /// <para>Das Bitmap hat das Pixelformat <see cref="PixelFormat.Format32bppArgb"/>, <see cref="PixelFormat.Format8bppIndexed"/> bzw. <see cref="PixelFormat.Format1bppIndexed"/> und 
      /// das Format <see cref="ImageFormat.MemoryBmp"/>.</para>
      /// </summary>
      /// <param name="withcanceldlg"></param>
      /// <param name="dpix">Auflösung horizontal</param>
      /// <param name="dpiy">Auflösung vertikal</param>
      /// <returns></returns>
      public Bitmap GetImage(bool withcanceldlg = true, float dpix = 0, float dpiy = 0) {
         WIA.CommonDialog dialog = withcanceldlg ? new WIA.CommonDialog() : null;
         WIA.ImageFile img = dialog != null ?
                                 dialog.ShowTransfer(scannerItem) as WIA.ImageFile :
                                 scannerItem.Transfer() as WIA.ImageFile;
         return img != null ? WIAHelper.Helper.ToBitmap(img, dpix, dpiy) : null;
      }

      public string Name() {
         return WIAHelper.Helper.GetPropertyAsString(device.Properties, "Name");
      }

   }
}
