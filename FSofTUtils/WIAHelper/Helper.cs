using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using WIA;

namespace FSofTUtils.WIAHelper {
   public class Helper {

      // https://docs.microsoft.com/de-de/windows/win32/wia/-wia-wia-property-constant-definitions?redirectedfrom=MSDN
      // https://docs.microsoft.com/de-de/windows/win32/wia/-wia-wiaitempropscanneritem
      // https://github.com/tpn/winddk-8.1/blob/master/Include/um/WiaDef.h
      // https://github.com/tpn/winsdk-7/blob/master/v7.1A/Include/WiaDef.h

      public const double MM2THOUSANDTHSOFINCH = 2.54 / 100;


      /// <summary>
      /// Papiergrößen zu den Konstanen WIA_PAGE_A4 ... WIA_PAGE_DIN_4B in 1000tel Zoll
      /// </summary>
      public static (int, int)[] PaperSize = {
                                         (  8267 , 11692 ),
                                         (  8500 , 11000 ),
                                         (     0 ,     0 ),
                                         (  8500 , 14000 ),
                                         ( 11000 , 17000 ),
                                         (  5500 ,  8500 ),
                                         (  3543 ,  2165 ),
                                         ( 33110 , 46811 ),
                                         ( 23385 , 33110 ),
                                         ( 16535 , 23385 ),
                                         ( 11692 , 16535 ),
                                         (  5826 ,  8267 ),
                                         (  4133 ,  5826 ),
                                         (  2913 ,  4133 ),
                                         (  2047 ,  2913 ),
                                         (  1456 ,  2047 ),
                                         (  1023 ,  1456 ),
                                         ( 39370 , 55669 ),
                                         ( 27834 , 39370 ),
                                         ( 19685 , 27834 ),
                                         ( 13897 , 19685 ),
                                         (  9842 , 13897 ),
                                         (  6929 ,  9842 ),
                                         (  4921 ,  6929 ),
                                         (  3464 ,  4921 ),
                                         (  2440 ,  3464 ),
                                         (  1732 ,  2440 ),
                                         (  1220 ,  1732 ),
                                         ( 36102 , 51062 ),
                                         ( 25511 , 36102 ),
                                         ( 18031 , 25511 ),
                                         ( 12755 , 18031 ),
                                         (  9015 , 12755 ),
                                         (  6377 ,  9015 ),
                                         (  4488 ,  6377 ),
                                         (  3188 ,  4488 ),
                                         (  2244 ,  3188 ),
                                         (  1574 ,  2244 ),
                                         (  1102 ,  1574 ),
                                         ( 40551 , 57322 ),
                                         ( 28661 , 40551 ),
                                         ( 20275 , 28661 ),
                                         ( 14330 , 20275 ),
                                         ( 10118 , 14330 ),
                                         (  7165 , 10118 ),
                                         (  5039 ,  7165 ),
                                         (  3582 ,  5039 ),
                                         (  2519 ,  3582 ),
                                         (  1771 ,  2519 ),
                                         (  1259 ,  1771 ),
                                         ( 46811 , 66220 ),
                                         ( 66220 , 93622 ),
                                         ( 55669 , 78740 ),
                                         ( 78740 ,111338 ) };



      /// <summary>
      /// Umrechnung mm in 1000tel Zoll
      /// </summary>
      /// <param name="mm"></param>
      /// <returns></returns>
      public static int mm2ThousandthsOfInch(double mm) {
         return (int)(mm * MM2THOUSANDTHSOFINCH);
      }

      /// <summary>
      /// Umrechnung 1000tel Zoll in mm
      /// </summary>
      /// <param name="v"></param>
      /// <returns></returns>
      public static double ThousandthsOfInch2mm(int v) {
         return v / MM2THOUSANDTHSOFINCH;
      }

      /// <summary>
      /// liefert alle vorhandenen Property-Namen
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static List<string> GetPropertynames(IProperties properties) {
         List<string> names = new List<string>();
         foreach (Property p in properties)
            names.Add(p.Name);
         return names;
      }

      static object getPropValue(Property prop) {
         if (prop == null)
            return null;
         return prop.get_Value();
      }

      static void setPropValue(Property prop, object value) {
         if (prop != null)
            prop.set_Value(ref value);
      }

      public static bool ExistsProp(IProperties properties, int id) {
         object index = id.ToString();
         return properties.Exists(ref index);
      }


      /// <summary>
      /// Modify a WIA property
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="propName"></param>
      /// <param name="propValue"></param>
      public static void SetProperty(IProperties properties, object propName, object propValue) {
         setPropValue(properties.get_Item(ref propName), propValue);
      }

      public static object GetProperty(IProperties properties, object propName) {
         return getPropValue(properties.get_Item(ref propName));
      }

      public static int? GetPropertyAsInt(IProperties properties, object propName) {
         object propValue = GetProperty(properties, propName);
         if (propValue != null)
            return Convert.ToInt32(propValue);
         return null;
      }

      public static string GetPropertyAsString(IProperties properties, object propName) {
         object propValue = GetProperty(properties, propName);
         return propValue != null ? Convert.ToString(propValue) : null;
      }

      public static int GetPropertyAsIntAndList(IProperties properties, string propName, int propId, out List<int> list) {
         list = new List<int>();
         if (ExistsProp(properties, propId)) {
            object propname = propName;
            Property prop = properties.get_Item(ref propname);
            if (prop != null) {
               if (prop.SubType == WiaSubType.ListSubType) {
                  for (int i = 0; i < prop.SubTypeValues.Count; i++)
                     list.Add(Convert.ToInt32(prop.SubTypeValues.get_Item(i + 1)));
               }
               return Convert.ToInt32(prop.get_Value());
            }
         }
         return 0;
      }

      public static int GetPropertyAsIntAndRange(IProperties properties, string propName, int propId, out int min, out int max, out int step) {
         min = max = step = 0;
         if (ExistsProp(properties, propId)) {
            object propname = propName;
            Property prop = properties.get_Item(ref propname);
            if (prop != null) {
               if (prop.SubType == WiaSubType.RangeSubType) {
                  min = prop.SubTypeMin;
                  max = prop.SubTypeMax;
                  step = prop.SubTypeStep;
               }
               return Convert.ToInt32(prop.get_Value());
            }
         }
         return 0;
      }

      #region Scanner-Infos

      /// <summary>
      /// maximum width, in thousandths of an inch, that is scanned in the horizontal (X) axis at the current resolution
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static int GetScannerPictureMaxHorizontalSize(IProperties properties) {
         int? v = ExistsProp(properties, WiaDef.WIA_IPS_MAX_HORIZONTAL_SIZE) ?
                           GetPropertyAsInt(properties, WiaDef.WIA_IPS_MAX_HORIZONTAL_SIZE_STR) :
                           null;
         return v == null ? 0 : v.Value;
      }

      /// <summary>
      /// maximum height, in thousandths of an inch, that is scanned in the vertical (Y) axis at the current resolution
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static int GetScannerPictureMaxVerticalSize(IProperties properties) {
         int? v = ExistsProp(properties, WiaDef.WIA_IPS_MAX_VERTICAL_SIZE) ?
                        GetPropertyAsInt(properties, WiaDef.WIA_IPS_MAX_VERTICAL_SIZE_STR) :
                        null;
         return v == null ? 0 : v.Value;
      }

      /// <summary>
      /// minimum width, in thousandths of an inch, that is scanned in the horizontal (X) axis at the current resolution
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static int GetScannerPictureMinHorizontalSize(IProperties properties) {
         int? v = ExistsProp(properties, WiaDef.WIA_IPS_MIN_HORIZONTAL_SIZE) ?
                        GetPropertyAsInt(properties, WiaDef.WIA_IPS_MIN_HORIZONTAL_SIZE_STR) :
                        null;
         return v == null ? 0 : v.Value;
      }

      /// <summary>
      /// minimum height, in thousandths of an inch, that is scanned in the vertical (Y) axis at the current resolution
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static int GetScannerPictureMinVerticalSize(IProperties properties) {
         int? v = ExistsProp(properties, WiaDef.WIA_IPS_MIN_VERTICAL_SIZE) ?
                        GetPropertyAsInt(properties, WiaDef.WIA_IPS_MIN_VERTICAL_SIZE_STR) :
                        null;
         return v == null ? 0 : v.Value;
      }

      /// <summary>
      /// Highest supported horizontal optical resolution in DPI
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static int GetScannerPictureOpticalXres(IProperties properties) {
         int? v = ExistsProp(properties, WiaDef.WIA_IPS_OPTICAL_XRES) ?
                        GetPropertyAsInt(properties, WiaDef.WIA_IPS_OPTICAL_XRES_STR) :
                        null;
         return v == null ? 0 : v.Value;
      }

      /// <summary>
      /// Highest supported vertical optical resolution in DPI
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static int GetScannerPictureOpticalYres(IProperties properties) {
         int? v = ExistsProp(properties, WiaDef.WIA_IPS_OPTICAL_YRES) ?
                        GetPropertyAsInt(properties, WiaDef.WIA_IPS_OPTICAL_YRES_STR) :
                        null;
         return v == null ? 0 : v.Value;
      }

      /// <summary>
      /// Contains the height, in thousandths of an inch, of the currently selected page.
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static int GetScannerPicturePageHeight(IProperties properties) {
         int? v = ExistsProp(properties, WiaDef.WIA_IPS_PAGE_HEIGHT) ?
                        GetPropertyAsInt(properties, WiaDef.WIA_IPS_PAGE_HEIGHT_STR) :
                        null;
         return v == null ? 0 : v.Value;
      }

      /// <summary>
      /// Contains the width of the current page selected, in thousandths of an inch.
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static int GetScannerPicturePageWidth(IProperties properties) {
         int? v = ExistsProp(properties, WiaDef.WIA_IPS_PAGE_WIDTH) ?
                        GetPropertyAsInt(properties, WiaDef.WIA_IPS_PAGE_WIDTH_STR) :
                        null;
         return v == null ? 0 : v.Value;
      }

      /// <summary>
      /// maximum warm-up time, in milliseconds, that the device needs before starting the scanning operation
      /// </summary>
      /// <param name="properties"></param>
      /// <returns></returns>
      public static int GetScannerPictureWarmUpTime(IProperties properties) {
         int? v = ExistsProp(properties, WiaDef.WIA_IPS_WARM_UP_TIME) ?
                        GetPropertyAsInt(properties, WiaDef.WIA_IPS_WARM_UP_TIME_STR) :
                        null;
         return v == null ? 0 : v.Value;
      }

      /// <summary>
      /// current horizontal resolution, in pixels per inch
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="list">verfügbare Werte</param>
      /// <returns></returns>
      public static int GetScannerPictureXres(IProperties properties, out List<int> list) {
         return GetPropertyAsIntAndList(properties, WiaDef.WIA_IPS_XRES_STR, WiaDef.WIA_IPS_XRES, out list);
      }

      /// <summary>
      /// current vertical resolution, in pixels per inch
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="list">verfügbare Werte</param>
      /// <returns></returns>
      public static int GetScannerPictureYres(IProperties properties, out List<int> list) {
         return GetPropertyAsIntAndList(properties, WiaDef.WIA_IPS_YRES_STR, WiaDef.WIA_IPS_YRES, out list);
      }

      /// <summary>
      /// x coordinate, in pixels, of the upper-left corner of the selected image
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="min">Min.</param>
      /// <param name="max">Max.</param>
      /// <param name="step">Schrittweite</param>
      /// <returns></returns>
      public static int GetScannerPictureXpos(IProperties properties, out int min, out int max, out int step) {
         return GetPropertyAsIntAndRange(properties, WiaDef.WIA_IPS_XPOS_STR, WiaDef.WIA_IPS_XPOS, out min, out max, out step);
      }

      /// <summary>
      /// y coordinate, in pixels, of the upper-left corner of the selected image
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="min">Min.</param>
      /// <param name="max">Max.</param>
      /// <param name="step">Schrittweite</param>
      /// <returns></returns>
      public static int GetScannerPictureYpos(IProperties properties, out int min, out int max, out int step) {
         return GetPropertyAsIntAndRange(properties, WiaDef.WIA_IPS_YPOS_STR, WiaDef.WIA_IPS_YPOS, out min, out max, out step);
      }

      /// <summary>
      /// current width, in pixels, of the selected image to acquire
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="min">Min.</param>
      /// <param name="max">Max.</param>
      /// <param name="step">Schrittweite</param>
      /// <returns></returns>
      public static int GetScannerPictureXextent(IProperties properties, out int min, out int max, out int step) {
         return GetPropertyAsIntAndRange(properties, WiaDef.WIA_IPS_XEXTENT_STR, WiaDef.WIA_IPS_XEXTENT, out min, out max, out step);
      }

      /// <summary>
      /// current height, in pixels, of the selected image to acquire
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="min">Min.</param>
      /// <param name="max">Max.</param>
      /// <param name="step">Schrittweite</param>
      /// <returns></returns>
      public static int GetScannerPictureYextent(IProperties properties, out int min, out int max, out int step) {
         return GetPropertyAsIntAndRange(properties, WiaDef.WIA_IPS_YEXTENT_STR, WiaDef.WIA_IPS_YEXTENT, out min, out max, out step);
      }

      /// <summary>
      /// current hardware brightness setting
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="min">Min.</param>
      /// <param name="max">Max.</param>
      /// <param name="step">Schrittweite</param>
      /// <returns></returns>
      public static int GetScannerPictureBrightness(IProperties properties, out int min, out int max, out int step) {
         return GetPropertyAsIntAndRange(properties, WiaDef.WIA_IPS_BRIGHTNESS_STR, WiaDef.WIA_IPS_BRIGHTNESS, out min, out max, out step);
      }

      /// <summary>
      /// current hardware contrast setting
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="min">Min.</param>
      /// <param name="max">Max.</param>
      /// <param name="step">Schrittweite</param>
      /// <returns></returns>
      public static int GetScannerPictureContrast(IProperties properties, out int min, out int max, out int step) {
         return GetPropertyAsIntAndRange(properties, WiaDef.WIA_IPS_CONTRAST_STR, WiaDef.WIA_IPS_CONTRAST, out min, out max, out step);
      }

      public static int GetScannerPictureCurIntent(IProperties properties, out int min, out int max, out int step) {
         return GetPropertyAsIntAndRange(properties, WiaDef.WIA_IPS_CUR_INTENT_STR, WiaDef.WIA_IPS_CUR_INTENT, out min, out max, out step);
      }

      #endregion


      /// <summary>
      /// The image brightness values available within the scanner.
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="grayscale"></param>
      /// <param name="preview"></param>
      public static void SetScannerPictureCurIntent(IProperties properties, bool grayscale = false, bool preview = false) {
         int intent = grayscale ? WiaDef.WIA_INTENT_IMAGE_TYPE_GRAYSCALE : WiaDef.WIA_INTENT_IMAGE_TYPE_COLOR;
         if (preview)
            intent |= WiaDef.WIA_INTENT_BEST_PREVIEW;
         SetProperty(properties, WiaDef.WIA_IPS_CUR_INTENT_STR, intent);
      }

      /// <summary>
      /// Contains the current hardware contrast setting for a device.
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="brightness">-1000 .. 1000</param>
      public static void SetScannerPictureBrightness(IProperties properties, int brightness) {
         brightness = Math.Min(Math.Max(-1000, brightness), 1000);
         SetProperty(properties, WiaDef.WIA_IPS_BRIGHTNESS_STR, brightness);
      }

      /// <summary>
      /// 
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="contrast">-1000 .. 1000</param>
      public static void SetScannerPictureContrast(IProperties properties, int contrast) {
         contrast = Math.Min(Math.Max(-1000, contrast), 1000);
         SetProperty(properties, WiaDef.WIA_IPS_CONTRAST_STR, contrast);
      }

      /// <summary>
      /// Indicates the preview mode for a device. An application sets this property to place the device into a preview mode.
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="yes"></param>
      public static void SetScannerPicturePreview(IProperties properties, bool yes) {
         SetProperty(properties, WiaDef.WIA_IPS_PREVIEW_STR, yes ? WiaDef.WIA_PREVIEW_SCAN : WiaDef.WIA_FINAL_SCAN);
      }

      /// <summary>
      /// Specifies the current orientation of the documents to be scanned
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="degree">0°, 90°, 180°, 270°</param>
      public static void SetScannerPictureOrientation(IProperties properties, int degree) {
         if (!(degree == 0 || degree == 90 || degree == 180 || degree == 270))
            degree = 0;
         SetProperty(properties, WiaDef.WIA_IPS_ORIENTATION_STR, degree);
      }

      /// <summary>
      /// size of the page that is currently set to be scanned
      /// <para>Es können alle WIA_PAGE_Konstanen mit vordef. Größen verwendet werden. Außerdem:</para>
      /// <para>WIA_PAGE_CUSTOM	Defined by the values of the WIA_IPS_PAGE_HEIGHT and WIA_IPS_PAGE_WIDTH properties.</para>
      /// <para>WIA_PAGE_AUTO	Page size is automatically determined by the device.</para>
      /// <para>WIA_PAGE_CUSTOM_BASE	A custom page size whose dimensions are already known to the application and the device driver.</para>
      /// <para>Die Ecke links-oben ist dann i.A. (0,0). Die Größe in Pixel ergibt sich aus der Auflösung.</para>
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="size"></param>
      public static void SetScannerPicturePageSize(IProperties properties, int size) {
         SetProperty(properties, WiaDef.WIA_IPS_PAGE_SIZE_STR, size);
      }

      #region X-Values für Scannbereich in Pixel (!) bzw. Prozent

      /// <summary>
      /// current width, in pixels
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="ext"></param>
      public static void SetScannerPictureXextent(IProperties properties, int ext) {
         SetProperty(properties, WiaDef.WIA_IPS_XEXTENT_STR, ext);
      }

      /// <summary>
      /// x coordinate, in pixels, of the upper-left corner
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="pos"></param>
      public static void SetScannerPictureXpos(IProperties properties, int pos) {
         SetProperty(properties, WiaDef.WIA_IPS_XPOS_STR, pos);
      }

      /// <summary>
      /// current horizontal resolution, in pixels per inch
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="dpi"></param>
      public static void SetScannerPictureXres(IProperties properties, int dpi) {
         SetProperty(properties, WiaDef.WIA_IPS_XRES_STR, dpi);
      }

      /// <summary>
      /// horizontal scaling, as a percentage
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="scale"></param>
      public static void SetScannerPictureXscaling(IProperties properties, int scale) {
         SetProperty(properties, WiaDef.WIA_IPS_XSCALING_STR, scale);
      }

      #endregion

      #region Y-Values für Scannbereich in Pixel (!) bzw. Prozent

      /// <summary>
      /// current height, in pixels
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="ext"></param>
      public static void SetScannerPictureYextent(IProperties properties, int ext) {
         SetProperty(properties, WiaDef.WIA_IPS_YEXTENT_STR, ext);
      }

      /// <summary>
      /// y coordinate, in pixels, of the upper-left corner
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="pos"></param>
      public static void SetScannerPictureYpos(IProperties properties, int pos) {
         SetProperty(properties, WiaDef.WIA_IPS_YPOS_STR, pos);
      }

      /// <summary>
      /// current vertical resolution, in pixels per inch
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="dpi"></param>
      public static void SetScannerPictureYres(IProperties properties, int dpi) {
         SetProperty(properties, WiaDef.WIA_IPS_YRES_STR, dpi);
      }

      /// <summary>
      /// vertical scaling, as a percentage
      /// </summary>
      /// <param name="properties"></param>
      /// <param name="scale"></param>
      public static void SetScannerPictureYscaling(IProperties properties, int scale) {
         SetProperty(properties, WiaDef.WIA_IPS_YSCALING_STR, scale);
      }

      #endregion

      /// <summary>
      /// zum einfachen Setzen der Standardeigenschaften
      /// </summary>
      /// <param name="scannner"></param>
      /// <param name="resolution">dpi</param>
      /// <param name="left">pixel</param>
      /// <param name="top">pixel</param>
      /// <param name="width">pixel</param>
      /// <param name="height">pixel</param>
      /// <param name="grayscale">Farbe oder Graustufen</param>
      /// <param name="brightness">Helligkeit -1 .. 1</param>
      /// <param name="contrast">Kontrast -1 .. 1</param>
      public static void SetStandardProps(IItem scannner,
                                          int resolution,
                                          int left, int top, int width, int height,
                                          bool grayscale = false,
                                          double brightness = 0,
                                          double contrast = 0) {
         SetScannerPictureXres(scannner.Properties, resolution);
         SetScannerPictureYres(scannner.Properties, resolution);

         SetScannerPictureXpos(scannner.Properties, left);
         SetScannerPictureYpos(scannner.Properties, top);

         SetScannerPictureXextent(scannner.Properties, width);
         SetScannerPictureYextent(scannner.Properties, height);

         //SetScannerPictureXscaling(scannner.Properties, 100);
         //SetScannerPictureYscaling(scannner.Properties, 100);

         brightness = 1000 * Math.Max(-1, Math.Min(brightness, 1));
         SetScannerPictureBrightness(scannner.Properties, (int)brightness);

         contrast = 1000 * Math.Max(-1, Math.Min(contrast, 1));
         SetScannerPictureContrast(scannner.Properties, (int)contrast);

         SetScannerPictureCurIntent(scannner.Properties, grayscale);

         //SetProperty(scannner.Properties, WiaDef.WIA_IPA_FORMAT_STR, FormatID.wiaFormatBMP); // Nur die möglichen verwenden!

      }

      /// <summary>
      /// zum einfachen Setzen der Standardeigenschaften
      /// </summary>
      /// <param name="scannner"></param>
      /// <param name="resolution">dpi</param>
      /// <param name="left">pixel</param>
      /// <param name="top">pixel</param>
      /// <param name="width">pixel</param>
      /// <param name="height">pixel</param>
      /// <param name="intent">Farbe oder Graustufen</param>
      /// <param name="brightness">Helligkeit -1 .. 1</param>
      /// <param name="contrast">Kontrast -1 .. 1</param>
      public static void SetStandardProps(IItem scannner,
                                          int resolution,
                                          int left, int top, int width, int height,
                                          int intent = 1, // color
                                          double brightness = 0,
                                          double contrast = 0) {
         SetScannerPictureXres(scannner.Properties, resolution);
         SetScannerPictureYres(scannner.Properties, resolution);

         GetScannerPictureXpos(scannner.Properties, out int minpx, out int maxpx, out int steppx);
         GetScannerPictureYpos(scannner.Properties, out int minpy, out int maxpy, out int steppy);
         left = Math.Max(minpx, Math.Min(left, maxpx));
         top = Math.Max(minpy, Math.Min(top, maxpy));
         left = minpx + steppx * ((left - minpx) / steppx);
         top = minpy + steppy * ((top - minpy) / steppy);
         SetScannerPictureXpos(scannner.Properties, left);
         SetScannerPictureYpos(scannner.Properties, top);

         GetScannerPictureXextent(scannner.Properties, out int minx, out int maxx, out int stepx);
         GetScannerPictureYextent(scannner.Properties, out int miny, out int maxy, out int stepy);
         width = Math.Max(minx, Math.Min(width, maxx));
         height = Math.Max(miny, Math.Min(height, maxy));
         width = minx + stepx * ((width - minx) / stepx);
         height = miny + stepy * ((height - miny) / stepy);
         SetScannerPictureXextent(scannner.Properties, width);
         SetScannerPictureYextent(scannner.Properties, height);

         brightness = 1000 * Math.Max(-1, Math.Min(brightness, 1));
         SetScannerPictureBrightness(scannner.Properties, (int)brightness);

         contrast = 1000 * Math.Max(-1, Math.Min(contrast, 1));
         SetScannerPictureContrast(scannner.Properties, (int)contrast);

         SetProperty(scannner.Properties, WiaDef.WIA_IPS_CUR_INTENT_STR, intent);

         switch (intent & WiaDef.WIA_INTENT_IMAGE_TYPE_MASK) {
            case WiaDef.WIA_INTENT_IMAGE_TYPE_COLOR:
               SetProperty(scannner.Properties, WiaDef.WIA_IPA_DEPTH_STR, 24);
               break;

            case WiaDef.WIA_INTENT_IMAGE_TYPE_GRAYSCALE:
               SetProperty(scannner.Properties, WiaDef.WIA_IPA_DEPTH_STR, 8);
               break;

            case WiaDef.WIA_INTENT_IMAGE_TYPE_TEXT:
               SetProperty(scannner.Properties, WiaDef.WIA_IPA_DEPTH_STR, 1);
               break;
         }

      }

      /// <summary>
      /// liefert ein Bitmap mit <see cref="PixelFormat.Format32bppArgb"/>, <see cref="PixelFormat.Format8bppIndexed"/> bzw. <see cref="PixelFormat.Format1bppIndexed"/> für das <see cref="ImageFile"/>
      /// <para>Das Bitmap hat das Format <see cref="ImageFormat.MemoryBmp"/>!</para>
      /// </summary>
      /// <param name="image"></param>
      /// <param name="dpix">Auflösung horizontal</param>
      /// <param name="dpiy">Auflösung vertikal</param>
      /// <returns></returns>
      public static Bitmap ToBitmap(ImageFile image, float dpix = 0, float dpiy = 0) {
         Bitmap result;

         byte[] data = (byte[])image.FileData.get_BinaryData();
         using (MemoryStream stream = new MemoryStream(data)) {
            using (Image scannedImage = Image.FromStream(stream)) {
               result = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
               if (dpix > 0 && dpiy > 0)
                  result.SetResolution(dpix, dpiy);
               using (Graphics g = Graphics.FromImage(result)) {
                  g.Clear(Color.Transparent);
                  g.PageUnit = GraphicsUnit.Pixel;
                  g.DrawImage(scannedImage, new Rectangle(0, 0, image.Width, image.Height));
               }

               Bitmap tmp;
               switch (image.PixelDepth) {
                  case 8:
                     tmp = result.Clone(new Rectangle(0, 0, result.Width, result.Height), PixelFormat.Format8bppIndexed);
                     result.Dispose();
                     result = tmp;
                     break;

                  case 1:
                     tmp = result.Clone(new Rectangle(0, 0, result.Width, result.Height), PixelFormat.Format1bppIndexed);
                     result.Dispose();
                     result = tmp;
                     break;
               }
            }
         }
         return result;
      }

      public static void ShowProps4Debug(IProperties props) {
         foreach (Property p in props) {
            WiaSubType subtype = p.SubType;     // FlagSubType, ListSubType, RangeSubType, UnspecifiedSubType

            object def = null;
            if (subtype != WiaSubType.UnspecifiedSubType && !
                p.IsVector)
               try {
                  def = p.SubTypeDefault;
               } catch {
                  def = null;
               }

            Debug.Write((p.IsReadOnly ? "RO" : "RW") + " " +
                        p.Name + "|" +
                        p.PropertyID + "='" +
                        p.get_Value().ToString() + "'" +
                        " Subtype=" + subtype.ToString());

            if (def != null)
               Debug.Write(" Default=" + (def == null ? "-" : def.ToString()));

            switch (subtype) {
               case WiaSubType.UnspecifiedSubType:
                  Debug.WriteLine("");
                  break;

               case WiaSubType.RangeSubType:
                  int step = p.SubTypeStep;
                  int min = p.SubTypeMin;
                  int max = p.SubTypeMax;
                  Debug.WriteLine(" Step=" + step +
                                  " MinMax=" + min + ".." + max
                                  );

                  break;

               case WiaSubType.ListSubType:
                  Debug.Write(" IsVector=" + p.IsVector +
                              " Vector=" + p.SubTypeValues.Count + ":"
                              );
                  for (int i = 0; i < p.SubTypeValues.Count; i++) {
                     object v = p.SubTypeValues.get_Item(i + 1);
                     Debug.Write("[" + v.ToString() + "]");
                  }
                  Debug.WriteLine("");
                  break;

               case WiaSubType.FlagSubType:
                  Debug.Write(" IsVector=" + p.IsVector +
                              " Vector=" + p.SubTypeValues.Count + ":"
                              );
                  for (int i = 0; i < p.SubTypeValues.Count; i++) {
                     object v = p.SubTypeValues.get_Item(i + 1);
                     Debug.Write("[" + v.ToString() + "]");
                  }
                  Debug.WriteLine("");
                  break;
            }

         }
         /*
            Item Name: Scan; RO=True                                               
            Full Item Name: 0000\Root\Scan; RO=True                                
            Item Flags: 532483; RO=True                                            
            Color Profile Name: sRGB Color Space Profile.icm; RO=False             
            Access Rights: 3; RO=True                                              
            Compression: 0; RO=False                                               
            Data Type: 3; RO=False                                                 
            Bits Per Pixel: 24; RO=False                                           
            Channels Per Pixel: 3; RO=True                                         
            Bits Per Channel: 8; RO=True                                           
            Planar: 0; RO=True                                                     
            Current Intent: 0; RO=False                                            Current Intent: 1; RO=False
            Horizontal Resolution: 200; RO=False                                   Horizontal Resolution: 300; RO=False
            Vertical Resolution: 200; RO=False                                     Vertical Resolution: 300; RO=False
            Horizontal Start Position: 0; RO=False                                 Horizontal Start Position: 0; RO=False
            Vertical Start Position: 0; RO=False                                   Vertical Start Position: 0; RO=False
            Horizontal Extent: 1700; RO=False                                      Horizontal Extent: 2480; RO=False
            Vertical Extent: 2338; RO=False                                        Vertical Extent: 3507; RO=False
            Pixels Per Line: 1700; RO=True                                         Pixels Per Line: 2480; RO=True
            Number of Lines: 2338; RO=True                                         Number of Lines: 3507; RO=True
            Bytes Per Line: 0; RO=True                                             Bytes Per Line: 7440; RO=True
            Item Size: 0; RO=True                                                  
            Buffer Size: 262144; RO=True                                           
            Photometric Interpretation: 0; RO=False                                
            Brightness: 0; RO=False                                                
            Contrast: 0; RO=False                                                  
            Threshold: 195; RO=False                                               
            Orientation: 0; RO=False                                               
            Media Type: 2; RO=False                                                
            Preferred Format: {B96B3CAB-0728-11D3-9D7B-0000F81EF32E}; RO=True      
            Format: {B96B3CAB-0728-11D3-9D7B-0000F81EF32E}; RO=False

               public const string wiaFormatBMP  = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
               public const string wiaFormatPNG  = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
               public const string wiaFormatGIF  = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
               public const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
               public const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";

          
            Device:
            RO User Name|3112='STINNER2021\puf' Subtype=UnspecifiedSubType
            RO Item Name|4098='Root' Subtype=UnspecifiedSubType
            RO Full Item Name|4099='0000\Root' Subtype=UnspecifiedSubType
            RO Item Flags|4101='76' Subtype=UnspecifiedSubType
            RW Unique Device ID|2='{6BDD1FC6-810F-11D0-BEC7-08002BE2092F}\0000' Subtype=UnspecifiedSubType
            RO Manufacturer|3='Hewlett-Packard' Subtype=UnspecifiedSubType
            RO Description|4='HP LJ M176 Scan' Subtype=UnspecifiedSubType
            RO Type|5='65538' Subtype=UnspecifiedSubType
            RO Port|6='\\.\Usbscan0' Subtype=UnspecifiedSubType
            RO Name|7='HP LJ M176 Scan' Subtype=UnspecifiedSubType
            RW Server|8='local' Subtype=UnspecifiedSubType
            RW Remote Device ID|9='' Subtype=UnspecifiedSubType
            RO UI Class ID|10='{4DB1AD10-3391-11D2-9A33-00C04FA36145}' Subtype=UnspecifiedSubType
            RO Hardware Configuration|11='0' Subtype=UnspecifiedSubType
            RO BaudRate|12='' Subtype=UnspecifiedSubType
            RO STI Generic Capabilities|13='48' Subtype=UnspecifiedSubType
            RO WIA Version|14='2.0' Subtype=UnspecifiedSubType
            RO Driver Version|15='1.0.0.1' Subtype=UnspecifiedSubType
            RO PnP ID String|16='\\?\usb#vid_03f0&pid_242a&mi_00#6&b27fce6&0&0000#{6bdd1fc6-810f-11d0-bec7-08002be2092f}' Subtype=UnspecifiedSubType
            RO STI Driver Version|17='3' Subtype=UnspecifiedSubType
            RO Item Category|4125='{F193526F-59B8-4A26-9888-E16E4F97CE10}' Subtype=UnspecifiedSubType
            RO Document Handling Capabilities|3086='2' Subtype=UnspecifiedSubType
            RO Document Handling Status|3087='2' Subtype=UnspecifiedSubType
            RO Access Rights|4102='3' Subtype=UnspecifiedSubType
            RO Firmware Version|1026='1.0.na' Subtype=UnspecifiedSubType
            RW Private Content Type|38920='0' Subtype=RangeSubType Default=0 Step=1 MinMax=0..3
            RO Horizontal Bed Size|3074='8500' Subtype=UnspecifiedSubType
            RO Vertical Bed Size|3075='11690' Subtype=UnspecifiedSubType
            RO Horizontal Optical Resolution|3090='1200' Subtype=UnspecifiedSubType
            RO Vertical Optical Resolution|3091='1200' Subtype=UnspecifiedSubType
            RW Preview|3100='0' Subtype=ListSubType Default=0 IsVector=False Vector=2:[0][1]
            RO Max Scan Time|3095='3600000' Subtype=UnspecifiedSubType
          
          */
      }
      /*
         Item Name: Scan; RO=True                                               
         Full Item Name: 0000\Root\Scan; RO=True                                
         Item Flags: 532483; RO=True                                            
         Color Profile Name: sRGB Color Space Profile.icm; RO=False             
         Access Rights: 3; RO=True                                              
         Compression: 0; RO=False                                               
         Data Type: 3; RO=False                                                 
         Bits Per Pixel: 24; RO=False                                           
         Channels Per Pixel: 3; RO=True                                         
         Bits Per Channel: 8; RO=True                                           
         Planar: 0; RO=True                                                     
         Current Intent: 0; RO=False                                            Current Intent: 1; RO=False
         Horizontal Resolution: 200; RO=False                                   Horizontal Resolution: 300; RO=False
         Vertical Resolution: 200; RO=False                                     Vertical Resolution: 300; RO=False
         Horizontal Start Position: 0; RO=False                                 Horizontal Start Position: 0; RO=False
         Vertical Start Position: 0; RO=False                                   Vertical Start Position: 0; RO=False
         Horizontal Extent: 1700; RO=False                                      Horizontal Extent: 2480; RO=False
         Vertical Extent: 2338; RO=False                                        Vertical Extent: 3507; RO=False
         Pixels Per Line: 1700; RO=True                                         Pixels Per Line: 2480; RO=True
         Number of Lines: 2338; RO=True                                         Number of Lines: 3507; RO=True
         Bytes Per Line: 0; RO=True                                             Bytes Per Line: 7440; RO=True
         Item Size: 0; RO=True                                                  
         Buffer Size: 262144; RO=True                                           
         Photometric Interpretation: 0; RO=False                                
         Brightness: 0; RO=False                                                
         Contrast: 0; RO=False                                                  
         Threshold: 195; RO=False                                               
         Orientation: 0; RO=False                                               
         Media Type: 2; RO=False                                                
         Preferred Format: {B96B3CAB-0728-11D3-9D7B-0000F81EF32E}; RO=True      
         Format: {B96B3CAB-0728-11D3-9D7B-0000F81EF32E}; RO=False

            public const string wiaFormatBMP  = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
            public const string wiaFormatPNG  = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
            public const string wiaFormatGIF  = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
            public const string wiaFormatJPEG = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
            public const string wiaFormatTIFF = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";

       
         Device:
         RO User Name|3112='STINNER2021\puf' Subtype=UnspecifiedSubType
         RO Item Name|4098='Root' Subtype=UnspecifiedSubType
         RO Full Item Name|4099='0000\Root' Subtype=UnspecifiedSubType
         RO Item Flags|4101='76' Subtype=UnspecifiedSubType
         RW Unique Device ID|2='{6BDD1FC6-810F-11D0-BEC7-08002BE2092F}\0000' Subtype=UnspecifiedSubType
         RO Manufacturer|3='Hewlett-Packard' Subtype=UnspecifiedSubType
         RO Description|4='HP LJ M176 Scan' Subtype=UnspecifiedSubType
         RO Type|5='65538' Subtype=UnspecifiedSubType
         RO Port|6='\\.\Usbscan0' Subtype=UnspecifiedSubType
         RO Name|7='HP LJ M176 Scan' Subtype=UnspecifiedSubType
         RW Server|8='local' Subtype=UnspecifiedSubType
         RW Remote Device ID|9='' Subtype=UnspecifiedSubType
         RO UI Class ID|10='{4DB1AD10-3391-11D2-9A33-00C04FA36145}' Subtype=UnspecifiedSubType
         RO Hardware Configuration|11='0' Subtype=UnspecifiedSubType
         RO BaudRate|12='' Subtype=UnspecifiedSubType
         RO STI Generic Capabilities|13='48' Subtype=UnspecifiedSubType
         RO WIA Version|14='2.0' Subtype=UnspecifiedSubType
         RO Driver Version|15='1.0.0.1' Subtype=UnspecifiedSubType
         RO PnP ID String|16='\\?\usb#vid_03f0&pid_242a&mi_00#6&b27fce6&0&0000#{6bdd1fc6-810f-11d0-bec7-08002be2092f}' Subtype=UnspecifiedSubType
         RO STI Driver Version|17='3' Subtype=UnspecifiedSubType
         RO Item Category|4125='{F193526F-59B8-4A26-9888-E16E4F97CE10}' Subtype=UnspecifiedSubType
         RO Document Handling Capabilities|3086='2' Subtype=UnspecifiedSubType
         RO Document Handling Status|3087='2' Subtype=UnspecifiedSubType
         RO Access Rights|4102='3' Subtype=UnspecifiedSubType
         RO Firmware Version|1026='1.0.na' Subtype=UnspecifiedSubType
         RW Private Content Type|38920='0' Subtype=RangeSubType Default=0 Step=1 MinMax=0..3
         RO Horizontal Bed Size|3074='8500' Subtype=UnspecifiedSubType
         RO Vertical Bed Size|3075='11690' Subtype=UnspecifiedSubType
         RO Horizontal Optical Resolution|3090='1200' Subtype=UnspecifiedSubType
         RO Vertical Optical Resolution|3091='1200' Subtype=UnspecifiedSubType
         RW Preview|3100='0' Subtype=ListSubType Default=0 IsVector=False Vector=2:[0][1]
         RO Max Scan Time|3095='3600000' Subtype=UnspecifiedSubType
      
       */

   }
}
