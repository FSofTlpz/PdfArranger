namespace FSofTUtils.WIAHelper {
   public class ErrorCodes {
      /* https://docs.microsoft.com/en-us/windows/win32/wia/-wia-error-codes

       */

      public static string GetErrorText(uint code) {
         switch (code) {
            case WIA_ERROR_BUSY: return "The device is busy. Close any apps that are using this device or wait for it to finish and then try again.";
            case WIA_ERROR_COVER_OPEN: return "One or more of the device’s cover is open.";
            case WIA_ERROR_DEVICE_COMMUNICATION: return "Communication with the WIA device failed. Make sure that the device is powered on and connected to the PC. If the problem persists, disconnect and reconnect the device.";
            case WIA_ERROR_DEVICE_LOCKED: return "The device is locked. Close any apps that are using this device or wait for it to finish and then try again.";
            case WIA_ERROR_EXCEPTION_IN_DRIVER: return "The device driver threw an exception.";
            case WIA_ERROR_GENERAL_ERROR: return "An unknown error has occurred with the WIA device.";
            case WIA_ERROR_INCORRECT_HARDWARE_SETTING: return "There is an incorrect setting on the WIA device.";
            case WIA_ERROR_INVALID_COMMAND: return "The device doesn't support this command.";
            case WIA_ERROR_INVALID_DRIVER_RESPONSE: return "The response from the driver is invalid.";
            case WIA_ERROR_ITEM_DELETED: return "The WIA device was deleted. It's no longer available.";
            case WIA_ERROR_LAMP_OFF: return "The scanner's lamp is off.";
            case WIA_ERROR_MAXIMUM_PRINTER_ENDORSER_COUNTER: return "A scan job was interrupted because an Imprinter/Endorser item reached the maximum valid value for WIA_IPS_PRINTER_ENDORSER_COUNTER, and was reset to 0. This feature is available with Windows 8 and later versions of Windows.";
            case WIA_ERROR_MULTI_FEED: return "A scan error occurred because of a multiple page feed condition. This feature is available with Windows 8 and later versions of Windows.";
            case WIA_ERROR_OFFLINE: return "The device is offline. Make sure the device is powered on and connected to the PC.";
            case WIA_ERROR_PAPER_EMPTY: return "There are no documents in the document feeder.";
            case WIA_ERROR_PAPER_JAM: return "Paper is jammed in the scanner's document feeder.";
            case WIA_ERROR_PAPER_PROBLEM: return "An unspecified problem occurred with the scanner's document feeder.";
            case WIA_ERROR_WARMING_UP: return "The device is warming up.";
            case WIA_ERROR_USER_INTERVENTION: return "There is a problem with the WIA device. Make sure that the device is turned on, online, and any cables are properly connected.";
            case WIA_S_NO_DEVICE_AVAILABLE: return "No scanner device was found. Make sure the device is online, connected to the PC, and has the correct driver installed on the PC.";
            default: return "Unknown error (0x" + code.ToString("x8") + ")";
         }
      }

      /// <summary>
      /// The device is busy.Close any apps that are using this device or wait for it to finish and then try again.
      /// </summary>
      public const uint WIA_ERROR_BUSY = 0x80210006;
      /// <summary>
      /// One or more of the device’s cover is open.
      /// </summary>
      public const uint WIA_ERROR_COVER_OPEN = 0x80210016;
      /// <summary>
      /// Communication with the WIA device failed.Make sure that the device is powered on and connected to the PC.If the problem persists, disconnect and reconnect the device.
      /// </summary>
      public const uint WIA_ERROR_DEVICE_COMMUNICATION = 0x8021000A;
      /// <summary>
      /// The device is locked.Close any apps that are using this device or wait for it to finish and then try again.
      /// </summary>
      public const uint WIA_ERROR_DEVICE_LOCKED = 0x8021000D;
      /// <summary>
      /// The device driver threw an exception.
      /// </summary>
      public const uint WIA_ERROR_EXCEPTION_IN_DRIVER = 0x8021000E;
      /// <summary>
      /// An unknown error has occurred with the WIA device.
      /// </summary>
      public const uint WIA_ERROR_GENERAL_ERROR = 0x80210001;
      /// <summary>
      /// There is an incorrect setting on the WIA device.
      /// </summary>
      public const uint WIA_ERROR_INCORRECT_HARDWARE_SETTING = 0x8021000C;
      /// <summary>
      /// The device doesn't support this command.
      /// </summary>
      public const uint WIA_ERROR_INVALID_COMMAND = 0x8021000B;
      /// <summary>
      /// The response from the driver is invalid.
      /// </summary>
      public const uint WIA_ERROR_INVALID_DRIVER_RESPONSE = 0x8021000F;
      /// <summary>
      /// The WIA device was deleted.It's no longer available.
      /// </summary>
      public const uint WIA_ERROR_ITEM_DELETED = 0x80210009;
      /// <summary>
      /// The scanner's lamp is off.
      /// </summary>
      public const uint WIA_ERROR_LAMP_OFF = 0x80210017;
      /// <summary>
      /// A scan job was interrupted because an Imprinter/Endorser item reached the maximum valid value for WIA_IPS_PRINTER_ENDORSER_COUNTER, and was reset to 0. This feature is available with Windows 8 and later versions of Windows.
      /// </summary>
      public const uint WIA_ERROR_MAXIMUM_PRINTER_ENDORSER_COUNTER = 0x80210021;
      /// <summary>
      /// A scan error occurred because of a multiple page feed condition.This feature is available with Windows 8 and later versions of Windows.
      /// </summary>
      public const uint WIA_ERROR_MULTI_FEED = 0x80210020;
      /// <summary>
      /// The device is offline.Make sure the device is powered on and connected to the PC.
      /// </summary>
      public const uint WIA_ERROR_OFFLINE = 0x80210005;
      /// <summary>
      /// There are no documents in the document feeder.
      /// </summary>
      public const uint WIA_ERROR_PAPER_EMPTY = 0x80210003;
      /// <summary>
      /// Paper is jammed in the scanner's document feeder.
      /// </summary>
      public const uint WIA_ERROR_PAPER_JAM = 0x80210002;
      /// <summary>
      /// An unspecified problem occurred with the scanner's document feeder.
      /// </summary>
      public const uint WIA_ERROR_PAPER_PROBLEM = 0x80210004;
      /// <summary>
      /// The device is warming up.
      /// </summary>
      public const uint WIA_ERROR_WARMING_UP = 0x80210007;
      /// <summary>
      /// There is a problem with the WIA device.Make sure that the device is turned on, online, and any cables are properly connected.
      /// </summary>
      public const uint WIA_ERROR_USER_INTERVENTION = 0x80210008;
      /// <summary>
      /// No scanner device was found.Make sure the device is online, connected to the PC, and has the correct driver installed on the PC.
      /// </summary>
      public const uint WIA_S_NO_DEVICE_AVAILABLE = 0x80210015;

   }
}
