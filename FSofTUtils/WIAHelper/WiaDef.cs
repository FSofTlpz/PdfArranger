namespace FSofTUtils.WIAHelper {
   
   /// <summary>
   /// einige Konstanten aus wiadef.h
   /// </summary>
   public class WiaDef {

      //
      // WIA property ID and string constants
      //

      public const int WIA_DIP_DEV_ID = 2; // 0x2
      public const string WIA_DIP_DEV_ID_STR = "Unique Device ID";

      public const int WIA_DIP_VEND_DESC = 3; // 0x3
      public const string WIA_DIP_VEND_DESC_STR = "Manufacturer";

      public const int WIA_DIP_DEV_DESC = 4; // 0x4
      public const string WIA_DIP_DEV_DESC_STR = "Description";

      public const int WIA_DIP_DEV_TYPE = 5; // 0x5
      public const string WIA_DIP_DEV_TYPE_STR = "Type";

      public const int WIA_DIP_PORT_NAME = 6; // 0x6
      public const string WIA_DIP_PORT_NAME_STR = "Port";

      public const int WIA_DIP_DEV_NAME = 7; // 0x7
      public const string WIA_DIP_DEV_NAME_STR = "Name";

      public const int WIA_DIP_SERVER_NAME = 8; // 0x8
      public const string WIA_DIP_SERVER_NAME_STR = "Server";

      public const int WIA_DIP_REMOTE_DEV_ID = 9; // 0x9
      public const string WIA_DIP_REMOTE_DEV_ID_STR = "Remote Device ID";

      public const int WIA_DIP_UI_CLSID = 10; // 0xa
      public const string WIA_DIP_UI_CLSID_STR = "UI Class ID";

      public const int WIA_DIP_HW_CONFIG = 11; // 0xb
      public const string WIA_DIP_HW_CONFIG_STR = "Hardware Configuration";

      public const int WIA_DIP_BAUDRATE = 12; // 0xc
      public const string WIA_DIP_BAUDRATE_STR = "BaudRate";

      public const int WIA_DIP_STI_GEN_CAPABILITIES = 13; // 0xd
      public const string WIA_DIP_STI_GEN_CAPABILITIES_STR = "STI Generic Capabilities";

      public const int WIA_DIP_WIA_VERSION = 14; // 0xe
      public const string WIA_DIP_WIA_VERSION_STR = "WIA Version";

      public const int WIA_DIP_DRIVER_VERSION = 15; // 0xf
      public const string WIA_DIP_DRIVER_VERSION_STR = "Driver Version";

      public const int WIA_DIP_PNP_ID = 16; // 0x10
      public const string WIA_DIP_PNP_ID_STR = "PnP ID String";

      public const int WIA_DIP_STI_DRIVER_VERSION = 17; // 0x11
      public const string WIA_DIP_STI_DRIVER_VERSION_STR = "STI Driver Version";

      public const int WIA_DPA_FIRMWARE_VERSION = 1026; // 0x402
      public const string WIA_DPA_FIRMWARE_VERSION_STR = "Firmware Version";

      public const int WIA_DPA_CONNECT_STATUS = 1027; // 0x403
      public const string WIA_DPA_CONNECT_STATUS_STR = "Connect Status";

      public const int WIA_DPA_DEVICE_TIME = 1028; // 0x404
      public const string WIA_DPA_DEVICE_TIME_STR = "Device Time";

      public const int WIA_DPC_PICTURES_TAKEN = 2050; // 0x802
      public const string WIA_DPC_PICTURES_TAKEN_STR = "Pictures Taken";

      public const int WIA_DPC_PICTURES_REMAINING = 2051; // 0x803
      public const string WIA_DPC_PICTURES_REMAINING_STR = "Pictures Remaining";

      public const int WIA_DPC_EXPOSURE_MODE = 2052; // 0x804
      public const string WIA_DPC_EXPOSURE_MODE_STR = "Exposure Mode";

      public const int WIA_DPC_EXPOSURE_COMP = 2053; // 0x805
      public const string WIA_DPC_EXPOSURE_COMP_STR = "Exposure Compensation";

      public const int WIA_DPC_EXPOSURE_TIME = 2054; // 0x806
      public const string WIA_DPC_EXPOSURE_TIME_STR = "Exposure Time";

      public const int WIA_DPC_FNUMBER = 2055; // 0x807
      public const string WIA_DPC_FNUMBER_STR = "F Number";

      public const int WIA_DPC_FLASH_MODE = 2056; // 0x808
      public const string WIA_DPC_FLASH_MODE_STR = "Flash Mode";

      public const int WIA_DPC_FOCUS_MODE = 2057; // 0x809
      public const string WIA_DPC_FOCUS_MODE_STR = "Focus Mode";

      public const int WIA_DPC_FOCUS_MANUAL_DIST = 2058; // 0x80a
      public const string WIA_DPC_FOCUS_MANUAL_DIST_STR = "Focus Manual Dist";

      public const int WIA_DPC_ZOOM_POSITION = 2059; // 0x80b
      public const string WIA_DPC_ZOOM_POSITION_STR = "Zoom Position";

      public const int WIA_DPC_PAN_POSITION = 2060; // 0x80c
      public const string WIA_DPC_PAN_POSITION_STR = "Pan Position";

      public const int WIA_DPC_TILT_POSITION = 2061; // 0x80d
      public const string WIA_DPC_TILT_POSITION_STR = "Tilt Position";

      public const int WIA_DPC_TIMER_MODE = 2062; // 0x80e
      public const string WIA_DPC_TIMER_MODE_STR = "Timer Mode";

      public const int WIA_DPC_TIMER_VALUE = 2063; // 0x80f
      public const string WIA_DPC_TIMER_VALUE_STR = "Timer Value";

      public const int WIA_DPC_POWER_MODE = 2064; // 0x810
      public const string WIA_DPC_POWER_MODE_STR = "Power Mode";

      public const int WIA_DPC_BATTERY_STATUS = 2065; // 0x811
      public const string WIA_DPC_BATTERY_STATUS_STR = "Battery Status";

      public const int WIA_DPC_THUMB_WIDTH = 2066; // 0x812
      public const string WIA_DPC_THUMB_WIDTH_STR = "Thumbnail Width";

      public const int WIA_DPC_THUMB_HEIGHT = 2067; // 0x813
      public const string WIA_DPC_THUMB_HEIGHT_STR = "Thumbnail Height";

      public const int WIA_DPC_PICT_WIDTH = 2068; // 0x814
      public const string WIA_DPC_PICT_WIDTH_STR = "Picture Width";

      public const int WIA_DPC_PICT_HEIGHT = 2069; // 0x815
      public const string WIA_DPC_PICT_HEIGHT_STR = "Picture Height";

      public const int WIA_DPC_DIMENSION = 2070; // 0x816
      public const string WIA_DPC_DIMENSION_STR = "Dimension";

      public const int WIA_DPC_COMPRESSION_SETTING = 2071; // 0x817
      public const string WIA_DPC_COMPRESSION_SETTING_STR = "Compression Setting";

      public const int WIA_DPC_FOCUS_METERING = 2072; // 0x818
      public const string WIA_DPC_FOCUS_METERING_STR = "Focus Metering Mode";

      public const int WIA_DPC_TIMELAPSE_INTERVAL = 2073; // 0x819
      public const string WIA_DPC_TIMELAPSE_INTERVAL_STR = "Timelapse Interva=";

      public const int WIA_DPC_TIMELAPSE_NUMBER = 2074; // 0x81a
      public const string WIA_DPC_TIMELAPSE_NUMBER_STR = "Timelapse Number";

      public const int WIA_DPC_BURST_INTERVAL = 2075; // 0x81b
      public const string WIA_DPC_BURST_INTERVAL_STR = "Burst Interva=";

      public const int WIA_DPC_BURST_NUMBER = 2076; // 0x81c
      public const string WIA_DPC_BURST_NUMBER_STR = "Burst Number";

      public const int WIA_DPC_EFFECT_MODE = 2077; // 0x81d
      public const string WIA_DPC_EFFECT_MODE_STR = "Effect Mode";

      public const int WIA_DPC_DIGITAL_ZOOM = 2078; // 0x81e
      public const string WIA_DPC_DIGITAL_ZOOM_STR = "Digital Zoom";

      public const int WIA_DPC_SHARPNESS = 2079; // 0x81f
      public const string WIA_DPC_SHARPNESS_STR = "Sharpness";

      public const int WIA_DPC_CONTRAST = 2080; // 0x820
      public const string WIA_DPC_CONTRAST_STR = "Contrast";

      public const int WIA_DPC_CAPTURE_MODE = 2081; // 0x821
      public const string WIA_DPC_CAPTURE_MODE_STR = "Capture Mode";

      public const int WIA_DPC_CAPTURE_DELAY = 2082; // 0x822
      public const string WIA_DPC_CAPTURE_DELAY_STR = "Capture Delay";

      public const int WIA_DPC_EXPOSURE_INDEX = 2083; // 0x823
      public const string WIA_DPC_EXPOSURE_INDEX_STR = "Exposure Index";

      public const int WIA_DPC_EXPOSURE_METERING_MODE = 2084; // 0x824
      public const string WIA_DPC_EXPOSURE_METERING_MODE_STR = "Exposure Metering Mode";

      public const int WIA_DPC_FOCUS_METERING_MODE = 2085; // 0x825
      public const string WIA_DPC_FOCUS_METERING_MODE_STR = "Focus Metering Mode";

      public const int WIA_DPC_FOCUS_DISTANCE = 2086; // 0x826
      public const string WIA_DPC_FOCUS_DISTANCE_STR = "Focus Distance";

      public const int WIA_DPC_FOCAL_LENGTH = 2087; // 0x827
      public const string WIA_DPC_FOCAL_LENGTH_STR = "Focus Length";

      public const int WIA_DPC_RGB_GAIN = 2088; // 0x828
      public const string WIA_DPC_RGB_GAIN_STR = "RGB Gain";

      public const int WIA_DPC_WHITE_BALANCE = 2089; // 0x829
      public const string WIA_DPC_WHITE_BALANCE_STR = "White Balance";

      public const int WIA_DPC_UPLOAD_URL = 2090; // 0x82a
      public const string WIA_DPC_UPLOAD_URL_STR = "Upload UR=";

      public const int WIA_DPC_ARTIST = 2091; // 0x82b
      public const string WIA_DPC_ARTIST_STR = "Artist";

      public const int WIA_DPC_COPYRIGHT_INFO = 2092; // 0x82c
      public const string WIA_DPC_COPYRIGHT_INFO_STR = "Copyright Info";

      public const int WIA_DPS_HORIZONTAL_BED_SIZE = 3074; // 0xc02
      public const string WIA_DPS_HORIZONTAL_BED_SIZE_STR = "Horizontal Bed Size";

      public const int WIA_DPS_VERTICAL_BED_SIZE = 3075; // 0xc03
      public const string WIA_DPS_VERTICAL_BED_SIZE_STR = "Vertical Bed Size";

      public const int WIA_DPS_HORIZONTAL_SHEET_FEED_SIZE = 3076; // 0xc04
      public const string WIA_DPS_HORIZONTAL_SHEET_FEED_SIZE_STR = "Horizontal Sheet Feed Size";

      public const int WIA_DPS_VERTICAL_SHEET_FEED_SIZE = 3077; // 0xc05
      public const string WIA_DPS_VERTICAL_SHEET_FEED_SIZE_STR = "Vertical Sheet Feed Size";

      public const int WIA_DPS_SHEET_FEEDER_REGISTRATION = 3078; // 0xc06
      public const string WIA_DPS_SHEET_FEEDER_REGISTRATION_STR = "Sheet Feeder Registration";

      public const int WIA_DPS_HORIZONTAL_BED_REGISTRATION = 3079; // 0xc07
      public const string WIA_DPS_HORIZONTAL_BED_REGISTRATION_STR = "Horizontal Bed Registration";

      public const int WIA_DPS_VERTICAL_BED_REGISTRATION = 3080; // 0xc08
      public const string WIA_DPS_VERTICAL_BED_REGISTRATION_STR = "Vertical Bed Registration";

      public const int WIA_DPS_PLATEN_COLOR = 3081; // 0xc09
      public const string WIA_DPS_PLATEN_COLOR_STR = "Platen Color";

      public const int WIA_DPS_PAD_COLOR = 3082; // 0xc0a
      public const string WIA_DPS_PAD_COLOR_STR = "Pad Color";

      public const int WIA_DPS_FILTER_SELECT = 3083; // 0xc0b
      public const string WIA_DPS_FILTER_SELECT_STR = "Filter Select";

      public const int WIA_DPS_DITHER_SELECT = 3084; // 0xc0c
      public const string WIA_DPS_DITHER_SELECT_STR = "Dither Select";

      public const int WIA_DPS_DITHER_PATTERN_DATA = 3085; // 0xc0d
      public const string WIA_DPS_DITHER_PATTERN_DATA_STR = "Dither Pattern Data";

      public const int WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES = 3086; // 0xc0e
      public const string WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES_STR = "Document Handling Capabilities";

      public const int WIA_DPS_DOCUMENT_HANDLING_STATUS = 3087; // 0xc0f
      public const string WIA_DPS_DOCUMENT_HANDLING_STATUS_STR = "Document Handling Status";

      public const int WIA_DPS_DOCUMENT_HANDLING_SELECT = 3088; // 0xc10
      public const string WIA_DPS_DOCUMENT_HANDLING_SELECT_STR = "Document Handling Select";

      public const int WIA_DPS_DOCUMENT_HANDLING_CAPACITY = 3089; // 0xc11
      public const string WIA_DPS_DOCUMENT_HANDLING_CAPACITY_STR = "Document Handling Capacity";

      public const int WIA_DPS_OPTICAL_XRES = 3090; // 0xc12
      public const string WIA_DPS_OPTICAL_XRES_STR = "Horizontal Optical Resolution";

      public const int WIA_DPS_OPTICAL_YRES = 3091; // 0xc13
      public const string WIA_DPS_OPTICAL_YRES_STR = "Vertical Optical Resolution";

      public const int WIA_DPS_ENDORSER_CHARACTERS = 3092; // 0xc14, superseded by WIA_IPS_PRINTER_ENDORSER_VALID_CHARACTERS
      public const string WIA_DPS_ENDORSER_CHARACTERS_STR = "Endorser Characters";

      public const int WIA_DPS_ENDORSER_STRING = 3093; // 0xc15, superseded by WIA_IPS_PRINTER_ENDORSER_STRING
      public const string WIA_DPS_ENDORSER_STRING_STR = "Endorser String";

      public const int WIA_DPS_SCAN_AHEAD_PAGES = 3094; // 0xc16, superseded by WIA_IPS_SCAN_AHEAD
      public const string WIA_DPS_SCAN_AHEAD_PAGES_STR = "Scan Ahead Pages";

      public const int WIA_DPS_MAX_SCAN_TIME = 3095; // 0xc17
      public const string WIA_DPS_MAX_SCAN_TIME_STR = "Max Scan Time";

      public const int WIA_DPS_PAGES = 3096; // 0xc18
      public const string WIA_DPS_PAGES_STR = "Pages";

      public const int WIA_DPS_PAGE_SIZE = 3097; // 0xc19
      public const string WIA_DPS_PAGE_SIZE_STR = "Page Size";

      public const int WIA_DPS_PAGE_WIDTH = 3098; // 0xc1a
      public const string WIA_DPS_PAGE_WIDTH_STR = "Page Width";

      public const int WIA_DPS_PAGE_HEIGHT = 3099; // 0xc1b
      public const string WIA_DPS_PAGE_HEIGHT_STR = "Page Height";

      public const int WIA_DPS_PREVIEW = 3100; // 0xc1c
      public const string WIA_DPS_PREVIEW_STR = "Preview";

      public const int WIA_DPS_TRANSPARENCY = 3101; // 0xc1d
      public const string WIA_DPS_TRANSPARENCY_STR = "Transparency Adapter";

      public const int WIA_DPS_TRANSPARENCY_SELECT = 3102; // 0xc1e
      public const string WIA_DPS_TRANSPARENCY_SELECT_STR = "Transparency Adapter Select";

      public const int WIA_DPS_SHOW_PREVIEW_CONTROL = 3103; // 0xc1f
      public const string WIA_DPS_SHOW_PREVIEW_CONTROL_STR = "Show preview contro=";

      public const int WIA_DPS_MIN_HORIZONTAL_SHEET_FEED_SIZE = 3104; // 0xc20
      public const string WIA_DPS_MIN_HORIZONTAL_SHEET_FEED_SIZE_STR = "Minimum Horizontal Sheet Feed Size";

      public const int WIA_DPS_MIN_VERTICAL_SHEET_FEED_SIZE = 3105; // 0xc21
      public const string WIA_DPS_MIN_VERTICAL_SHEET_FEED_SIZE_STR = "Minimum Vertical Sheet Feed Size";

      public const int WIA_DPS_TRANSPARENCY_CAPABILITIES = 3106; // 0xc22
      public const string WIA_DPS_TRANSPARENCY_CAPABILITIES_STR = "Transparency Adapter Capabilities";

      public const int WIA_DPS_TRANSPARENCY_STATUS = 3107; // 0xc23
      public const string WIA_DPS_TRANSPARENCY_STATUS_STR = "Transparency Adapter Status";

      public const int WIA_DPF_MOUNT_POINT = 3330; // 0xd02
      public const string WIA_DPF_MOUNT_POINT_STR = "Directory mount point";

      public const int WIA_DPV_LAST_PICTURE_TAKEN = 3586; // 0xe02
      public const string WIA_DPV_LAST_PICTURE_TAKEN_STR = "Last Picture Taken";

      public const int WIA_DPV_IMAGES_DIRECTORY = 3587; // 0xe03
      public const string WIA_DPV_IMAGES_DIRECTORY_STR = "Images Directory";

      public const int WIA_DPV_DSHOW_DEVICE_PATH = 3588; // 0xe04
      public const string WIA_DPV_DSHOW_DEVICE_PATH_STR = "Directshow Device Path";

      public const int WIA_IPA_ITEM_NAME = 4098; // 0x1002
      public const string WIA_IPA_ITEM_NAME_STR = "Item Name";

      public const int WIA_IPA_FULL_ITEM_NAME = 4099; // 0x1003
      public const string WIA_IPA_FULL_ITEM_NAME_STR = "Full Item Name";

      public const int WIA_IPA_ITEM_TIME = 4100; // 0x1004
      public const string WIA_IPA_ITEM_TIME_STR = "Item Time Stamp";

      public const int WIA_IPA_ITEM_FLAGS = 4101; // 0x1005
      public const string WIA_IPA_ITEM_FLAGS_STR = "Item Flags";

      public const int WIA_IPA_ACCESS_RIGHTS = 4102; // 0x1006
      public const string WIA_IPA_ACCESS_RIGHTS_STR = "Access Rights";

      public const int WIA_IPA_DATATYPE = 4103; // 0x1007
      public const string WIA_IPA_DATATYPE_STR = "Data Type";

      public const int WIA_IPA_DEPTH = 4104; // 0x1008
      public const string WIA_IPA_DEPTH_STR = "Bits Per Pixel";

      public const int WIA_IPA_PREFERRED_FORMAT = 4105; // 0x1009
      public const string WIA_IPA_PREFERRED_FORMAT_STR = "Preferred Format";

      public const int WIA_IPA_FORMAT = 4106; // 0x100a
      public const string WIA_IPA_FORMAT_STR = "Format";

      public const int WIA_IPA_COMPRESSION = 4107; // 0x100b
      public const string WIA_IPA_COMPRESSION_STR = "Compression";

      public const int WIA_IPA_TYMED = 4108; // 0x100c
      public const string WIA_IPA_TYMED_STR = "Media Type";

      public const int WIA_IPA_CHANNELS_PER_PIXEL = 4109; // 0x100d
      public const string WIA_IPA_CHANNELS_PER_PIXEL_STR = "Channels Per Pixe=";

      public const int WIA_IPA_BITS_PER_CHANNEL = 4110; // 0x100e
      public const string WIA_IPA_BITS_PER_CHANNEL_STR = "Bits Per Channe=";

      public const int WIA_IPA_PLANAR = 4111; // 0x100f
      public const string WIA_IPA_PLANAR_STR = "Planar";

      public const int WIA_IPA_PIXELS_PER_LINE = 4112; // 0x1010
      public const string WIA_IPA_PIXELS_PER_LINE_STR = "Pixels Per Line";

      public const int WIA_IPA_BYTES_PER_LINE = 4113; // 0x1011
      public const string WIA_IPA_BYTES_PER_LINE_STR = "Bytes Per Line";

      public const int WIA_IPA_NUMBER_OF_LINES = 4114; // 0x1012
      public const string WIA_IPA_NUMBER_OF_LINES_STR = "Number of Lines";

      public const int WIA_IPA_GAMMA_CURVES = 4115; // 0x1013
      public const string WIA_IPA_GAMMA_CURVES_STR = "Gamma Curves";

      public const int WIA_IPA_ITEM_SIZE = 4116; // 0x1014
      public const string WIA_IPA_ITEM_SIZE_STR = "Item Size";

      public const int WIA_IPA_COLOR_PROFILE = 4117; // 0x1015
      public const string WIA_IPA_COLOR_PROFILE_STR = "Color Profiles";

      public const int WIA_IPA_MIN_BUFFER_SIZE = 4118; // 0x1016
      public const string WIA_IPA_MIN_BUFFER_SIZE_STR = "Buffer Size";

      public const int WIA_IPA_BUFFER_SIZE = 4118; // 0x1016
      public const string WIA_IPA_BUFFER_SIZE_STR = "Buffer Size";

      public const int WIA_IPA_REGION_TYPE = 4119; // 0x1017
      public const string WIA_IPA_REGION_TYPE_STR = "Region Type";

      public const int WIA_IPA_ICM_PROFILE_NAME = 4120; // 0x1018
      public const string WIA_IPA_ICM_PROFILE_NAME_STR = "Color Profile Name";

      public const int WIA_IPA_APP_COLOR_MAPPING = 4121; // 0x1019
      public const string WIA_IPA_APP_COLOR_MAPPING_STR = "Application Applies Color Mapping";

      public const int WIA_IPA_PROP_STREAM_COMPAT_ID = 4122; // 0x101a
      public const string WIA_IPA_PROP_STREAM_COMPAT_ID_STR = "Stream Compatibility ID";

      public const int WIA_IPA_FILENAME_EXTENSION = 4123; // 0x101b
      public const string WIA_IPA_FILENAME_EXTENSION_STR = "Filename extension";

      public const int WIA_IPA_SUPPRESS_PROPERTY_PAGE = 4124; // 0x101c
      public const string WIA_IPA_SUPPRESS_PROPERTY_PAGE_STR = "Suppress a property page";

      public const int WIA_IPC_THUMBNAIL = 5122; // 0x1402
      public const string WIA_IPC_THUMBNAIL_STR = "Thumbnail Data";

      public const int WIA_IPC_THUMB_WIDTH = 5123; // 0x1403
      public const string WIA_IPC_THUMB_WIDTH_STR = "Thumbnail Width";

      public const int WIA_IPC_THUMB_HEIGHT = 5124; // 0x1404
      public const string WIA_IPC_THUMB_HEIGHT_STR = "Thumbnail Height";

      public const int WIA_IPC_AUDIO_AVAILABLE = 5125; // 0x1405
      public const string WIA_IPC_AUDIO_AVAILABLE_STR = "Audio Available";

      public const int WIA_IPC_AUDIO_DATA_FORMAT = 5126; // 0x1406
      public const string WIA_IPC_AUDIO_DATA_FORMAT_STR = "Audio Format";

      public const int WIA_IPC_AUDIO_DATA = 5127; // 0x1407
      public const string WIA_IPC_AUDIO_DATA_STR = "Audio Data";

      public const int WIA_IPC_NUM_PICT_PER_ROW = 5128; // 0x1408
      public const string WIA_IPC_NUM_PICT_PER_ROW_STR = "Pictures per Row";

      public const int WIA_IPC_SEQUENCE = 5129; // 0x1409
      public const string WIA_IPC_SEQUENCE_STR = "Sequence Number";

      public const int WIA_IPC_TIMEDELAY = 5130; // 0x140a
      public const string WIA_IPC_TIMEDELAY_STR = "Time Delay";

      /// <summary>
      /// ScannerPictureCurIntent
      /// <para>Contains the current intent settings. The minidriver creates and maintains this property.</para>
      /// <para>Required for all acquisition enabled items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM. It is not supported for WIA_CATEGORY_FINISHED_FILE or WIA_CATEGORY_FOLDER items.</para>
      /// <para>The driver uses these to preset item properties based on an application's intended use of the image. This might include, for example, maximum quality, minimum size, and so on.</para>
      /// <para>The driver chooses the bit depth, in dots per inch, and other settings that it determines are appropriate for the selected intent. It is up to the application to read the current settings to determine which properties were changed. An application sets this property to auto-set the WIA properties for specific acquisition intent. This property is required for all scanners.</para>
      /// <para>An application sets this property to auto-set the WIA properties for specific acquisition intent</para>
      /// <para>The flags can be combined with a bitwise OR operator, but an image cannot be both grayscale and color.</para>
      /// <para>This property is required for all scanners.</para>
      /// <para>The following table contains the image-type flags and their definitions. These flags are used to set which type of image is intended: color, grayscale, and so on.</para>
      /// <para>WIA_INTENT_NONE	Default value. No intent is specified.</para>
      /// <para>WIA_INTENT_IMAGE_TYPE_COLOR	The application intends to prepare the device for a color scan.</para>
      /// <para>WIA_INTENT_IMAGE_TYPE_GRAYSCALE	The application intends to prepare the device for a grayscale scan.</para>
      /// <para>WIA_INTENT_IMAGE_TYPE_TEXT	The application intends to prepare the device for scanning text.</para>
      /// <para>WIA_INTENT_IMAGE_TYPE_MASK	Mask for all of the image-type flags.</para>
      /// <para>The following table contains the quality and size flags and their definitions. These flags are used to set which level of quality is intended.</para>
      /// <para>WIA_INTENT_MINIMIZE_SIZE	The application intends to prepare the device for scanning an image that result's in a small scan.</para>
      /// <para>WIA_INTENT_MAXIMIZE_QUALITY	The application intends to prepare the device for scanning a high-quality image.</para>
      /// <para>WIA_INTENT_SIZE_MASK	This flag is a mask for all of the size/quality flags.</para>
      /// <para>WIA_INTENT_BEST_PREVIEW	The application intends to prepare the device for scanning a preview.</para>
      /// </summary>
      public const int WIA_IPS_CUR_INTENT = 6146; // 0x1802
      public const string WIA_IPS_CUR_INTENT_STR = "Current Intent";

      /// <summary>
      /// ScannerPictureXres
      /// <para>Contains the current horizontal resolution, in pixels per inch, for the device. An application sets this property to set the horizontal resolution. The minidriver creates and maintains this property.</para>
      /// <para>If the device can be set to only a single value, create a WIA_PROP_LIST type and place the valid value in it. This is also a case where one resolution setting depends on another resolution. (The vertical resolution can depend on the horizontal resolution.)</para>
      /// <para>Required for all acquisition enabled items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, WIA_CATEGORY_FINISHED_FILE, and WIA_CATEGORY_FILM. It is not supported for WIA_CATEGORY_FOLDER items.</para>
      /// </summary>
      public const int WIA_IPS_XRES = 6147; // 0x1803
      public const string WIA_IPS_XRES_STR = "Horizontal Resolution";

      /// <summary>
      /// ScannerPictureYres
      /// <para>Contains the current vertical resolution, in pixels per inch, for the device. An application sets this property to set the vertical resolution. The minidriver creates and maintains this property.</para>
      /// <para>If the device can be set to only a single value, create a WIA_PROP_LIST type and place the valid value in it. This is also a case where one resolution setting depends on another resolution. (The horizontal resolution can depend on the vertical resolution.)</para>
      /// <para>Required for all acquisition enabled items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, WIA_CATEGORY_FINISHED_FILE, and WIA_CATEGORY_FILM. It is not supported for WIA_CATEGORY_FOLDER items.</para>
      /// </summary>
      public const int WIA_IPS_YRES = 6148; // 0x1804
      public const string WIA_IPS_YRES_STR = "Vertical Resolution";

      /// <summary>
      /// ScannerPictureXpos
      /// <para>Contains the x coordinate, in pixels, of the upper-left corner of the selected image. An application sets this property to mark the upper-left corner of the selection area. The minidriver creates and maintains this property.</para>
      /// <para>Required for all acquisition enabled items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, WIA_CATEGORY_FINISHED_FILE, and WIA_CATEGORY_FILM. It is not supported for WIA_CATEGORY_FOLDER items.</para>
      /// </summary>
      public const int WIA_IPS_XPOS = 6149; // 0x1805
      public const string WIA_IPS_XPOS_STR = "Horizontal Start Position";

      /// <summary>
      /// ScannerPictureYpos
      /// <para>Current y coordinate, in pixels, of the upper-left corner of the selected image. An application sets this property to mark the upper-left corner of the selection area. The minidriver creates and maintains this property.</para>
      /// <para>Required for all acquisition enabled items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, WIA_CATEGORY_FINISHED_FILE, and WIA_CATEGORY_FILM. It is not supported for WIA_CATEGORY_FOLDER items.</para>
      /// </summary>
      public const int WIA_IPS_YPOS = 6150; // 0x1806
      public const string WIA_IPS_YPOS_STR = "Vertical Start Position";

      /// <summary>
      /// ScannerPictureXextent
      /// <para>Contains the current width, in pixels, of the selected image to acquire. An application sets this property to mark the width of a selection area to acquire. This property must agree with the WIA_IPA_PIXELS_PER_LINE property. The minidriver creates and maintains this property.</para>
      /// <para>Required for all acquisition enabled items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM.</para>
      /// </summary>
      public const int WIA_IPS_XEXTENT = 6151; // 0x1807
      public const string WIA_IPS_XEXTENT_STR = "Horizontal Extent";

      /// <summary>
      /// ScannerPictureYextent
      /// <para>Contains the current height, in pixels, of the selected image to acquire. An application sets this property to mark the height of a selection area. This property must be agree with the value of the WIA_IPA_PIXELS_PER_LINE property. The minidriver creates and maintains this property.</para>
      /// <para>Required for all acquisition enabled items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM.</para>
      /// </summary>
      public const int WIA_IPS_YEXTENT = 6152; // 0x1808
      public const string WIA_IPS_YEXTENT_STR = "Vertical Extent";

      /// <summary>
      /// ScannerPicturePhotometricInterp
      /// <para>Contains the current setting for white and black pixels. The minidriver creates and maintains this property.</para>
      /// <para>An application reads this value to determine the value of WHITE or BLACK (depending on what the application is doing).</para>
      /// <para>Required for all acquisition enabled or stored items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, WIA_CATEGORY_FINISHED_FILE, and WIA_CATEGORY_FILM. It is not supported for WIA_CATEGORY_FOLDER items.</para>
      /// <para>The following table has the two constants that are valid with this property.</para>
      /// <para>WIA_PHOTO_WHITE_0	WHITE is 0, and BLACK is 1.</para>
      /// <para>WIA_PHOTO_WHITE_1	WHITE is 1, and BLACK is 0.</para>
      /// </summary>
      public const int WIA_IPS_PHOTOMETRIC_INTERP = 6153; // 0x1809
      public const string WIA_IPS_PHOTOMETRIC_INTERP_STR = "Photometric Interpretation";

      /// <summary>
      /// ScannerPictureBrightness
      /// <para>The image brightness values available within the scanner.</para>
      /// <para>Contains the current hardware brightness setting for the device. An application sets this property to the hardware's brightness value. The minidriver creates and maintains this property.</para>
      /// <para>Values should be mapped in a range from -1000 through 1000, where 1000 corresponds to the maximum brightness, 0 corresponds to normal brightness, and -1000 corresponds to the minimum brightness.</para>
      /// <para>Required for all items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM. Optional, but recommended, for WIA_CATEGORY_FINISHED_FILE items supporting previews.</para>
      /// </summary>
      public const int WIA_IPS_BRIGHTNESS = 6154; // 0x180a
      public const string WIA_IPS_BRIGHTNESS_STR = "Brightness";

      /// <summary>
      /// ScannerPictureContrast
      /// <para>Contains the current hardware contrast setting for a device. An application sets this property to the hardware's contrast value. The minidriver creates and maintains this property.</para>
      /// <para>Values should be mapped in a range from -1000 through 1000, where -1000 corresponds to the minimum contrast, 0 corresponds to normal contrast, and 1000 corresponds to the maximum contrast.</para>
      /// <para>Required for all items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM. Optional, but recommended, for WIA_CATEGORY_FINISHED_FILE items supporting previews.</para>
      /// </summary>
      public const int WIA_IPS_CONTRAST = 6155; // 0x180b
      public const string WIA_IPS_CONTRAST_STR = "Contrast";

      /// <summary>
      /// ScannerPictureOrientation
      /// <para>Specifies the current orientation of the documents to be scanned. The minidriver creates and maintains this property.</para>
      /// <para>An application sets this property to define the original orientation of a page or image to be acquired. For information on how to use WIA_IPS_ORIENTATION, see WIA_IPS_PAGE_SIZE.</para>
      /// <para>WIA_IPS_ORIENTATION refers to the position of the document to be scanned on the scanner bed or feeder. It is the orientation of the document relative to the direction of the scan. WIA_IPS_ROTATION refers to rotation that is applied to the image after it is scanned, just before the image is transferred to the application.</para>
      /// <para>The following table has the four constants that are valid with this property.</para>
      /// <para>PORTRAIT	0 degrees.</para>
      /// <para>LANDSCAPE	90-degree counter-clockwise rotation, relative to the PORTRAIT orientation.</para>
      /// <para>ROT180	180-degree counter-clockwise rotation, relative to the PORTRAIT orientation.</para>
      /// <para>ROT270	270-degree counter-clockwise rotation, relative to the PORTRAIT orientation.</para>
      /// </summary>
      public const int WIA_IPS_ORIENTATION = 6156; // 0x180c
      public const string WIA_IPS_ORIENTATION_STR = "Orientation";

      /// <summary>
      /// ScannerPictureRotation (Optional)
      /// <para>Contains the current rotation setting, if it is implemented. The minidriver creates and maintains this property.</para>
      /// <para>An application sets this property to inform the driver how much (if at all) to rotate the image before the driver returns it to the application.</para>
      /// <para>WIA_IPS_ORIENTATION refers to the position of the document to be scanned on the scanner bed or feeder. It is the orientation of the document relative to the direction of the scan. WIA_IPS_ROTATION refers to rotation that is applied to the image after it is scanned, just before the image is transferred to the application.</para>
      /// <para>The WIA minidriver is responsible for rotating the image data before sending it back to the application. The application is responsible for checking the image headers to see the newly rotated values.</para>
      /// <para>Considerable confusion exists about resolving the effect of rotation on the current image's selection area (which is defined by the WIA_IPS_XPOS, WIA_IPS_YPOS, WIA_IPS_XEXTENT and WIA_IPS_YEXTENT properties).</para>
      /// <para>Selection area refers to the selected area on the physical scanner bed that an image is be acquired from. WIA_IPS_ROTATION does not modify the selection area. The driver applies a counterclockwise rotation according to WIA_IPS_ROTATION only after the driver has acquired the appropriate selection area. WIA_IPS_ROTATION does affect the dimensions of the output image, so these dimensions must be reflected in the resulting image's data header.</para>
      /// <para>Optional for all acquisition enabled items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM.</para>
      /// <para>The following rotation constants are defined.</para>
      /// <para>PORTRAIT	The driver will not rotate the image.</para>
      /// <para>LANDSCAPE	The driver rotates the image 90 degrees counterclockwise.</para>
      /// <para>ROT180	The driver rotates the image 180 degrees counterclockwise.</para>
      /// <para>ROT270	The driver rotates the image 270 degrees counterclockwise.</para>
      /// </summary>
      public const int WIA_IPS_ROTATION = 6157; // 0x180d
      public const string WIA_IPS_ROTATION_STR = "Rotation";

      /// <summary>
      /// ScannerPictureMirror
      /// <para>Reserved for future use and is not implemented at this time.</para>
      /// </summary>
      public const int WIA_IPS_MIRROR = 6158; // 0x180e
      public const string WIA_IPS_MIRROR_STR = "Mirror";

      /// <summary>
      /// ScannerPictureThreshold
      /// <para>Specifies the grayscale value that determines whether a pixel will be converted to white or black when an image is converted to monochromatic. Pixels above the threshold become white. Pixels below the threshold become white.</para>
      /// <para>This property is required for acquisition items that support 1-bpp scans and that have the WIA_IPA_DATATYPE property set to WIA_DATA_THRESHOLD.</para>
      /// </summary>
      public const int WIA_IPS_THRESHOLD = 6159; // 0x180f
      public const string WIA_IPS_THRESHOLD_STR = "Threshold";

      /// <summary>
      /// ScannerPictureInvert
      /// <para>Reserved for future use and is not implemented at this time.</para>
      /// </summary>
      public const int WIA_IPS_INVERT = 6160; // 0x1810
      public const string WIA_IPS_INVERT_STR = "Invert";

      /// <summary>
      /// ScannerPictureWarmUpTime
      /// <para>Specifies the maximum warm-up time, in milliseconds, that the device needs before starting the scanning operation. The minidriver creates and maintains this property.</para>
      /// <para>An application can read this property to determine the maximum warm-up time for this device. It can then present a "waiting for the device to warm up" dialog box, to let the user know that a wait or pause might occur before anything happens.</para>
      /// <para>This property is required for all acquisition enabled items; that is, items in the categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM.</para>
      /// </summary>
      public const int WIA_IPS_WARM_UP_TIME = 6161; // 0x1811
      public const string WIA_IPS_WARM_UP_TIME_STR = "Lamp Warm up Time";

      //
      // New properties, property names and values specific to WIA 2.0 (introduced in Windows Vista):
      //

      public const int WIA_DPS_USER_NAME = 3112; // 0xc28
      public const string WIA_DPS_USER_NAME_STR = "User Name";

      public const int WIA_DPS_SERVICE_ID = 3113; // 0xc29
      public const string WIA_DPS_SERVICE_ID_STR = "Service ID";

      public const int WIA_DPS_DEVICE_ID = 3114; // 0xc2a
      public const string WIA_DPS_DEVICE_ID_STR = "Device ID";

      public const int WIA_DPS_GLOBAL_IDENTITY = 3115; // 0xc2b
      public const string WIA_DPS_GLOBAL_IDENTITY_STR = "Global Identity";

      public const int WIA_DPS_SCAN_AVAILABLE_ITEM = 3116; // 0xc2c
      public const string WIA_DPS_SCAN_AVAILABLE_ITEM_STR = "Scan Available Item";

      /// <summary>
      /// ScannerPictureDeskewX (optional)
      /// <para>Contains the number of pixels in the x-direction from WIA_IPS_XPOS to the x-coordinate of the uppermost corner of the image to be deskewed. Hence, it describes, in conjunction with WIA_IPS_DESKEW_Y, where the two upper corners of the skewed image are located within the bounding rectangle defined by WIA_IPS_XPOS, WIA_IPS_YPOS, WIA_IPS_XEXTENT and WIA_IPS_YEXTENT. his property is implemented by the scanner driver if it supports deskewing.</para>
      /// <para>The valid values for WIA_IPS_DESKEW_X must be between 0 and (WIA_IPS_XEXTENT - 1). A value of 0 means that no deskew should be performed.</para>
      /// <para>This property is optional for items of the categories WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, and WIA_CATEGORY_FILM; and it is not available for WIA_CATEGORY_FINISHED_FILE or WIA_CATEGORY_FOLDER items.</para>
      /// </summary>
      public const int WIA_IPS_DESKEW_X = 6162; // 0x1812
      public const string WIA_IPS_DESKEW_X_STR = "DeskewX";

      /// <summary>
      /// ScannerPictureDeskewY (optional)
      /// <para>Contains the number of pixels in the y-direction from WIA_IPS_YPOS to the y-coordinate of the leftmost corner of the image to be deskewed. Hence, it describes, in conjunction with WIA_IPS_DESKEW_X, where the two upper corners of the skewed image are located within the bounding rectangle defined by WIA_IPS_XPOS, WIA_IPS_YPOS, WIA_IPS_XEXTENT and WIA_IPS_YEXTENT. This property is implemented by the scanner driver if it supports deskewing.</para>
      /// <para>The valid values for WIA_IPS_DESKEW_Y must be between 0 and (WIA_IPS_YEXTENT - 1). A value of 0 means that no deskew should be performed.</para>
      /// <para>This property is optional for items of the categories WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, and WIA_CATEGORY_FILM; and it is not available for WIA_CATEGORY_FINISHED_FILE or WIA_CATEGORY_FOLDER items.</para>
      /// </summary>
      public const int WIA_IPS_DESKEW_Y = 6163; // 0x1813
      public const string WIA_IPS_DESKEW_Y_STR = "DeskewY";

      /// <summary>
      /// ScannerPictureSegmentation
      /// <para>Specifies whether the application should use the driver's segmentation filter for multi-region scanning. WIA_IPS_SEGMENTATION must be implemented for WIA_CATEGORY_FLATBED and WIA_CATEGORY_FILM items if they support either the creation of child items with a segmentation filter or if the driver itself creates child items for fixed frames.</para>
      /// <para>The following table has the two constants that are valid with this property.</para>
      /// <para>WIA_USE_SEGMENTATION_FILTER	The application should use the segmentation filter for multi-region scanning.</para>
      /// <para>WIA_DONT_USE_SEGMENTATION_FILTER	The driver creates the child items itself for multi-region scanning. This is usually the case if the scanner uses fixed frames for this purpose.</para>
      /// <para>It is possible for a driver to come with a segmentation filter, but still have WIA_IPS_SEGMENTATION set to WIA_DONT_USE_SEGMENTATION_FILTER for one of its items (such as, the WIA_CATEGORY_FILM item). This could be the case if the scanner uses fixed frames for film scanning, but not for regular scanning from WIA_CATEGORY_FLATBED items.</para>
      /// </summary>
      public const int WIA_IPS_SEGMENTATION = 6164; // 0x1814
      public const string WIA_IPS_SEGMENTATION_STR = "Segmentation";

      public const string WIA_SEGMENTATION_FILTER_STR = "SegmentationFilter";
      public const string WIA_IMAGEPROC_FILTER_STR = "ImageProcessingFilter";

      /// <summary>
      /// ScannerPictureMaxHorizontalSize
      /// <para>Specifies the maximum width, in thousandths of an inch, that is scanned in the horizontal (X) axis at the current resolution. This may be the width of the sheet feeder or the scanning bed, according to the type of item.</para>
      /// </summary>
      public const int WIA_IPS_MAX_HORIZONTAL_SIZE = 6165; // 0x1815
      public const string WIA_IPS_MAX_HORIZONTAL_SIZE_STR = "Maximum Horizontal Scan Size";

      /// <summary>
      /// ScannerPictureMaxVerticalSize
      /// <para>Specifies the maximum height, in thousandths of an inch, that is scanned in the vertical (Y) axis at the current resolution. This may be the height of the sheet feeder or the scanning bed, according to the type of item.</para>
      /// </summary>
      public const int WIA_IPS_MAX_VERTICAL_SIZE = 6166; // 0x1816
      public const string WIA_IPS_MAX_VERTICAL_SIZE_STR = "Maximum Vertical Scan Size";

      /// <summary>
      /// ScannerPictureMinHorizontalSize
      /// <para>Specifies the minimum width, in thousandths of an inch, that is scanned in the horizontal (X) axis at the current resolution.</para>
      /// </summary>
      public const int WIA_IPS_MIN_HORIZONTAL_SIZE = 6167; // 0x1817
      public const string WIA_IPS_MIN_HORIZONTAL_SIZE_STR = "Minimum Horizontal Scan Size";

      /// <summary>
      /// ScannerPictureMinVerticalSize
      /// <para>Specifies the minimum height, in thousandths of an inch, that is scanned in the vertical (Y) axis at the current resolution.</para>
      /// </summary>
      public const int WIA_IPS_MIN_VERTICAL_SIZE = 6168; // 0x1818
      public const string WIA_IPS_MIN_VERTICAL_SIZE_STR = "Minimum Vertical Scan Size";

      /// <summary>
      /// ScannerPictureTransferCapabilities
      /// <para>Specifies whether the driver is capable of transferring multiple child items in single transfer call.</para>
      /// <para>The only possible value for this property is WIA_TRANSFER_CHILDREN_SINGLE_SCAN. If this flag is set, then the driver is capable of transfering multiple child items in single transfer call. If the flag is not set, the WIA Service will walk through the child items recursively and then transfer each of those items.</para>
      /// </summary>
      public const int WIA_IPS_TRANSFER_CAPABILITIES = 6169; // 0x1819
      public const string WIA_IPS_TRANSFER_CAPABILITIES_STR = "Transfer Capabilities";

      /// <summary>
      /// ScannerPictureSheetFeederRegistration
      /// <para>Contains the registration, or alignment and edge detection, for documents that are placed on the flatbed. The minidriver creates and maintains this property. This property indicates how the sheet is horizontally positioned on the scanning head of a handheld or sheet-fed scanner. The property is used to predict where across the scan head a document is placed.</para>
      /// <para>For scanners that support more than one scan head, this property is relative to the topmost scan head. This property is mandatory for sheet-fed, scroll-fed, and handheld scanners.</para>
      /// <para>The following table has the three constants that are valid with this property.</para>
      /// <para>LEFT_JUSTIFIED	The sheet is positioned to the left with respect to the scanning head.</para>
      /// <para>CENTERED	The sheet is centered on the scanning head.</para>
      /// <para>RIGHT_JUSTIFIED	The sheet is positioned to the right with respect to the scanning head.</para>
      /// </summary>
      public const int WIA_IPS_SHEET_FEEDER_REGISTRATION = 3078; // 0xc06
      public const string WIA_IPS_SHEET_FEEDER_REGISTRATION_STR = "Sheet Feeder Registration";

      /// <summary>
      /// ScannerPictureDocumentHandlingSelect
      /// <para>Contains the current scanner acquisition source and mode. The minidriver creates and maintains this property.</para>
      /// <para>An application reads this property to determine the current acquisition source of the scanner or to write this property to set the source and mode of the scanner. In addition, applications use this property to enable and disable duplexer functionality.</para>
      /// <para>The following table has the constants that are valid with this property.</para>
      /// <para>DUPLEX	Scan using duplexer operations. Scan both document sides using common settings configured for the feeder item (WIA_CATEGORY_FEEDER). DUPLEX and ADVANCE_DUPLEX cannot both be set.</para>
      /// <para>ADVANCED_DUPLEX	Scan using individual settings configured for each child feeder item (WIA_CATEGORY_FEEDER_FRONT and WIA_CATEGORY_FEEDER_BACK). DUPLEX and ADVANCE_DUPLEX cannot both be set.</para>
      /// <para>FRONT_FIRST	Scan the front of the document first. This value is valid when DUPLEX or ADVANCED_DUPLEX is set.</para>
      /// <para>BACK_FIRST	Scan the back of the document first. This value is valid when DUPLEX or ADVANCED_DUPLEX is set.</para>
      /// <para>FRONT_ONLY	Scan the front only.</para>
      /// <para>BACK_ONLY	Scan the back only. This value is valid when DUPLEX or ADVANCED_DUPLEX is set.</para>
      /// </summary>
      public const int WIA_IPS_DOCUMENT_HANDLING_SELECT = 3088; // 0xc10
      public const string WIA_IPS_DOCUMENT_HANDLING_SELECT_STR = "Document Handling Select";

      /// <summary>
      /// ScannerPictureOpticalXres
      /// <para>Horizontal Optical Resolution. Highest supported horizontal optical resolution in DPI. This property is a single value. This is not a list of all resolutions that can be generated by the device. Rather, this is the resolution of the device's optics. The minidriver creates and maintains this property. This property is required for all items.</para>
      /// </summary>
      public const int WIA_IPS_OPTICAL_XRES = 3090; // 0xc12
      public const string WIA_IPS_OPTICAL_XRES_STR = "Horizontal Optical Resolution";

      /// <summary>
      /// ScannerPictureOpticalYres
      /// <para>Vertical Optical Resolution. Highest supported vertical optical resolution in DPI. This property is a single value. This is not a list of all resolutions that are generated by the device. Rather, this is the resolution of the device's optics. The minidriver creates and maintains this property. This property is required for all items.</para>
      /// </summary>
      public const int WIA_IPS_OPTICAL_YRES = 3091; // 0xc13
      public const string WIA_IPS_OPTICAL_YRES_STR = "Vertical Optical Resolution";

      /// <summary>
      /// ScannerPicturePages
      /// <para>Contains the current number of pages to be acquired from an automatic document feeder. The minidriver creates and maintains this property.</para>
      /// <para>Valid values: This is zero through the maximum number of pages that the scanner can scan. The value is ALL_PAGES (= 0) if the scanner can scan continuously.</para>
      /// <para>An application reads this property to determine the document feeder's page capacity. The application also sets this property to the number of pages it is going to scan.</para>
      /// <para>If duplex mode is enabled (WIA_IPS_DOCUMENT_HANDLING_SELECT is set to FEEDER | DUPLEX | ADVANCED_DUPLEX), WIA_IPS_PAGES is still equal to the number of pages to scan.</para>
      /// <para>One sheet of paper will automatically contain two pages if DUPLEX is enabled, even if the back side of the page is blank.</para>
      /// <para>Setting WIA_IPS_PAGES to 1 causes a scanner to process one side of the page. We recommend that, if a scanner is unable to scan only one side of a page while in duplex mode, you change the WIA_IPS_PAGES value for the Inc member of the Range member of the WIA_PROPERTY_INFO structure to 2. This value signals the application that it must request pages in multiples of two. A value of ALL_PAGES (= 0) means that all pages that are currently loaded into the document feeder are to be scanned.</para>
      /// </summary>
      public const int WIA_IPS_PAGES = 3096; // 0xc18
      public const string WIA_IPS_PAGES_STR = "Pages";

      /// <summary>
      /// ScannerPicturePageSize
      /// <para>Contains the size of the page that is currently set to be scanned. An application sets this property to select the dimensions of the page to scan. The minidriver creates and maintains this property.</para>
      /// <para>For the constants that can be used with this property, see WIA 2.0 Page Size Constants. Note these non-fixed sizes, in particular:</para>
      /// <para>WIA_PAGE_CUSTOM	Defined by the values of the WIA_IPS_PAGE_HEIGHT and WIA_IPS_PAGE_WIDTH properties.</para>
      /// <para>WIA_PAGE_AUTO	Page size is automatically determined by the device.</para>
      /// <para>WIA_PAGE_CUSTOM_BASE	A custom page size whose dimensions are already known to the application and the device driver.</para>
      /// <para>The value of the WIA_IPS_ORIENTATION property determines the orientation of the currently selected page. The WIA_IPS_PAGE_WIDTH and WIA_IPS_PAGE_HEIGHT properties report the page's dimensions, in thousandths of an inch. These properties must be in agreement with WIA_IPS_XEXTENT and WIA_IPS_YEXTENT, which contain the page's dimensions in pixels.</para>
      /// <para>Valid values of type WIA_PROP_LIST depend on valid settings of the WIA_IPS_ORIENTATION property. If, for example, the device cannot scan landscape-oriented documents with a WIA_PAGE_A4 setting, WIA_PAGE_A4 is not a valid value for the WIA_IPS_PAGE_SIZE property when WIA_IPS_ORIENTATION is set to LANDSCAPE.</para>
      /// <para>If an application sets WIA_IPS_PAGE_SIZE to any value other than the three in the table above, the minidriver should adjust the values of WIA_IPS_PAGE_WIDTH and WIA_IPS_PAGE_HEIGHT to the page's dimensions in thousandths of an inch. It should also adjust the values of WIA_IPS_XEXTENT and WIA_IPS_YEXTENT to the page's dimensions in pixels.</para>
      /// <para>If an extent setting (WIA_IPS_XEXTENT or WIA_IPS_YEXTENT) is changed to a value that does not match the current page size setting, the minidriver should change the value of the WIA_IPS_PAGE_SIZE property to WIA_PAGE_CUSTOM. The minidriver should also modify WIA_IPS_PAGE_WIDTH or WIA_IPS_PAGE_HEIGHT in accordance with the new extent setting.</para>
      /// <para>If WIA_IPS_ORIENTATION is set to LANDSCAPE, the extent settings will be exchanged relative to their usual values. For example, if an application sets WIA_IPS_PAGE_SIZE to WIA_PAGE_A4, the minidriver sets WIA_IPS_PAGE_WIDTH to 11692 and WIA_IPS_PAGE_HEIGHT to 8267. (The minidriver should also adjust WIA_IPS_XEXTENT and WIA_IPS_YEXTENT accordingly.)</para>
      /// <para>If WIA_IPS_PAGE_SIZE is set to WIA_PAGE_CUSTOM, the orientation setting is not used to determine the extent dimensions of the page to be scanned.</para>
      /// <para>The minidriver is responsible for ensuring that the WIA_IPS_ORIENTATION property is in agreement with the current selection area. If an application changes the value of WIA_IPS_ORIENTATION to one that is invalid for the currently selected page size, the minidriver should change the value of WIA_IPS_PAGE_SIZE to a page size that is supported by the new orientation value.</para>
      /// <para>If an application sets the WIA_IPS_PAGE_SIZE property to WIA_PAGE_CUSTOM, the current selection area is not affected. The WIA minidriver should obtain the current image layout, starting from the current settings of the WIA_IPS_XPOS and WIA_IPS_YPOS properties. If the page size setting results in a selection area that is outside the scanner's bed, the minidriver must automatically adjust the values of the WIA_IPS_XPOS and WIA_IPS_YPOS properties to valid settings. If the WIA_IPS_PAGE_SIZE and WIA_IPS_ORIENTATION properties are set at the same time, and they are invalid when applied in combination, the minidriver should fail the application's settings by returning an error in the IWiaMiniDrv::drvValidateItemProperties.</para>
      /// </summary>
      public const int WIA_IPS_PAGE_SIZE = 3097; // 0xc19
      public const string WIA_IPS_PAGE_SIZE_STR = "Page Size";

      /// <summary>
      /// ScannerPicturePageWidth
      /// <para>Contains the width of the current page selected, in thousandths of an inch. An application reads this property to determine the physical dimensions of the page being scanned. If the extent settings are different from known page sizes, this property reports the width of the page whose WIA_IPS_PAGE_SIZE property is set to WIA_PAGE_CUSTOM. WIA_IPS_PAGE_WIDTH must be in sync with the value of WIA_IPS_XEXTENT, which reports the width, in pixels, of the page to be scanned. The minidriver creates and maintains this property.</para>
      /// <para>This property is required for WIA_CATEGORY_FEEDER items.</para>
      /// </summary>
      public const int WIA_IPS_PAGE_WIDTH = 3098; // 0xc1a
      public const string WIA_IPS_PAGE_WIDTH_STR = "Page Width";

      /// <summary>
      /// ScannerPicturePageHeight
      /// <para>Contains the height, in thousandths of an inch, of the currently selected page. The minidriver creates and maintains the WIA_IPS_PAGE_HEIGHT property. An application reads this property to determine the physical dimensions of the page being scanned. If the extent settings are different from the known page sizes, this property reports the height of the page whose WIA_IPS_PAGE_SIZE property is set to WIA_PAGE_CUSTOM (which is a value of the WIA_IPS_PAGE_SIZE property). WIA_IPS_PAGE_HEIGHT must be in sync with WIA_IPS_XEXTENT, which reports the height, in pixels, of the page to be scanned.</para>
      /// <para>This property is required for WIA_CATEGORY_FEEDER items.</para>
      /// </summary>
      public const int WIA_IPS_PAGE_HEIGHT = 3099; // 0xc1b
      public const string WIA_IPS_PAGE_HEIGHT_STR = "Page Height";

      /// <summary>
      /// ScannerPicturePreview
      /// <para>Indicates the preview mode for a device. An application sets this property to place the device into a preview mode.</para>
      /// <para>This property is required for the WIA_CATEGORY_FLATBED and WIA_CATEGORY_FILM items, optional for the WIA_CATEGORY_FEEDER item.</para>
      /// <para>The following table has the constants that are valid with this property.</para>
      /// <para>WIA_FINAL_SCAN	The application will perform a final scan.</para>
      /// <para>WIA_PREVIEW_SCAN	The application will perform a preview scan.</para>
      /// </summary>
      public const int WIA_IPS_PREVIEW = 3100; // 0xc1c
      public const string WIA_IPS_PREVIEW_STR = "Preview";

      /// <summary>
      /// ScannerPictureShowPreviewControl
      /// <para>Indicates whether an item needs a preview control displayed to the user. The minidriver creates and maintains this property.</para>
      /// <para>Optional for all transfer enabled items. This is usually just items of the categories WIA_ITEM_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FILM, and WIA_CATEGORY_FINISHED_FILE.</para>
      /// <para>The following table has the constants that are valid with this property.</para>
      /// <para>WIA_SHOW_PREVIEW_CONTROL	Show a preview control to the user, because this device can perform a preview.</para>
      /// <para>WIA_DONT_SHOW_PREVIEW_CONTROL	Do not show a preview control to the user, because this device cannot perform a preview.</para>
      /// </summary>
      public const int WIA_IPS_SHOW_PREVIEW_CONTROL = 3103; // 0xc1f
      public const string WIA_IPS_SHOW_PREVIEW_CONTROL_STR = "Show preview contro=";

      /// <summary>
      /// ScannerPictureFilmScanMode
      /// <para>Enables configuration of the current film scan.</para>
      /// <para>This property is required for the WIA_CATEGORY_FILM item.</para>
      /// <para>The following table has the constants that are valid with this property.</para>
      /// <para>WIA_FILM_COLOR_SLIDE	Scan for a color slide.</para>
      /// <para>WIA_FILM_COLOR_NEGATIVE	Scan for a color negative.</para>
      /// <para>WIA_FILM_BW_NEGATIVE	Scan for a black and white negative.</para>
      /// </summary>
      public const int WIA_IPS_FILM_SCAN_MODE = 3104; // 0xc20
      public const string WIA_IPS_FILM_SCAN_MODE_STR = "Film Scan Mode";

      /// <summary>
      /// ScannerPictureLamp (Optional)
      /// <para>Turns the scanner lamp on or off.</para>
      /// <para>Optional for the WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, and WIA_CATEGORY_FILM items and recommended for WIA_CATEGORY_FILM.</para>
      /// <para>The following table has the constants that are valid with this property.</para>
      /// <para>WIA_LAMP_ON	Turn on the lamp.</para>
      /// <para>WIA_LAMP_OFF	Turn off the lamp.</para>
      /// </summary>
      public const int WIA_IPS_LAMP = 3105; // 0xc21
      public const string WIA_IPS_LAMP_STR = "Lamp";

      /// <summary>
      /// ScannerPictureLampAutoOff (Optional)
      /// <para>Sets the maximum time to keep the lamp on when the scanner is not being used.</para>
      /// <para>Optional for the WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, and WIA_CATEGORY_FILM items and recommended for WIA_CATEGORY_FILM.</para>
      /// <para>Valid Values: 0 - 0xFFF seconds</para>
      /// </summary>
      public const int WIA_IPS_LAMP_AUTO_OFF = 3106; // 0xc22
      public const string WIA_IPS_LAMP_AUTO_OFF_STR = "Lamp Auto Off";

      /// <summary>
      /// ScannerPictureAutoDeskew (Optional)
      /// <para>Schaltet automatisches Deskew ein oder aus. Nur für WIA_CATEGORY_FEEDER optional.</para>
      /// <para><see cref="WIA_AUTO_DESKEW_ON"/></para>
      /// <para><see cref="WIA_AUTO_DESKEW_OFF"/></para>
      /// </summary>
      public const int WIA_IPS_AUTO_DESKEW = 3107; // 0xc23
      public const string WIA_IPS_AUTO_DESKEW_STR = "Automatic Deskew";

      /// <summary>
      /// ScannerPictureSupportsChildItemCreation
      /// <para>Specifies whether the application (or the filters) can create child items under the current item.</para>
      /// <para>Optional for all transfer enabled item categories: WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FILM and even WIA_CATEGORY_FOLDER. (If the storage won't support upload of new items then this property should be either unsupported or supported with the FALSE value.)</para>
      /// <para>Items supporting WIA_IPS_SEGMENTATION and WIA_USE_SEGMENTATION_FILTER must also support WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION and have it set to TRUE.</para>
      /// <para>Valid Values: TRUE and FALSE</para>
      /// </summary>
      public const int WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION = 3108; // 0xc24
      public const string WIA_IPS_SUPPORTS_CHILD_ITEM_CREATION_STR = "Supports Child Item Creation";

      /// <summary>
      /// ScannerPictureXscaling (optional)
      /// <para>Sets the horizontal scaling, as a percentage, that may be applied to scanned images within the scanner device or its driver.</para>
      /// <para>This property is optional for all acquisition enabled items; that is, items of types WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM.</para>
      /// <para>Values can be from 1 to maximum VT_I4 (0xFFFF). For example, 100 means no scaling, 050 means scaling down to 50% of the orignal size, and 200 means scaling up to 200% of the original size.</para>
      /// </summary>
      public const int WIA_IPS_XSCALING = 3109; // 0xc25
      public const string WIA_IPS_XSCALING_STR = "Horizontal Scaling";

      /// <summary>
      /// ScannerPictureYscaling (optional)
      /// <para>Sets the vertical scaling, as a percentage, that may be applied to scanned images within the scanner device or its driver.</para>
      /// <para>This property is optional for all acquisition enabled items; that is, items of types WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM.</para>
      /// <para>Values can be from 1 to maximum VT_I4 (0xFFFF). For example, 100 means no scaling, 050 means scaling down to 50% of the orignal size, and 200 means scaling up to 200% of the original size.</para>
      /// </summary>
      public const int WIA_IPS_YSCALING = 3110; // 0xc26
      public const string WIA_IPS_YSCALING_STR = "Vertical Scaling";

      /// <summary>
      /// ScannerPicturePreviewType
      /// <para>Specifies whether the existing preview image can be updated during an image preview (in response to a change in the WIA_IPA_DATATYPE or WIA_IPA_DEPTH properties).</para>
      /// <para>This property is optional for all acquisition enabled items that support preview scans; that is, WIA_IPS_PREVIEW is supported with WIA_PREVIEW_SCAN. This includes items of types WIA_CATEGORY_FLATBED, WIA_CATEGORY_FEEDER, WIA_CATEGORY_FEEDER_FRONT, WIA_CATEGORY_FEEDER_BACK, and WIA_CATEGORY_FILM.</para>
      /// <para>The following table has the constants that are valid with this property.</para>
      /// <para>WIA_ADVANCED_PREVIEW	Updating the existing image is possible.</para>
      /// <para>WIA_BASIC_PREVIEW	Another preview scan must be executed because updating the existing image is not possible.</para>
      /// </summary>
      public const int WIA_IPS_PREVIEW_TYPE = 3111; // 0xc27
      public const string WIA_IPS_PREVIEW_TYPE_STR = "Preview Type";

      public const int WIA_IPA_ITEM_CATEGORY = 4125; // 0x101d
      public const string WIA_IPA_ITEM_CATEGORY_STR = "Item Category";

      /// <summary>
      /// Specifies the number of bytes to upload for the item.
      /// </summary>
      public const int WIA_IPA_UPLOAD_ITEM_SIZE = 4126; // 0x101e
      public const string WIA_IPA_UPLOAD_ITEM_SIZE_STR = "Upload Item Size";

      /// <summary>
      /// Specifies how many items are stored in the WIA_CATEGORY_FOLDER item.
      /// </summary>
      public const int WIA_IPA_ITEMS_STORED = 4127; // 0x101f
      public const string WIA_IPA_ITEMS_STORED_STR = "Items Stored";

      public const int WIA_IPA_RAW_BITS_PER_CHANNEL = 4128; // 0x1020
      public const string WIA_IPA_RAW_BITS_PER_CHANNEL_STR = "Raw Bits Per Channe=";

      /// <summary>
      /// ScannerPictureFilmNodeName
      /// <para>Enables specification of a particular film scanning attachment when there is more than one.</para>
      /// <para>This property is required for the WIA_CATEGORY_FILM items when there are multiple film scan items. If the device supports only one root scanner film item then this property is optional.</para>
      /// <para>Allowed values: The BSTR should be in the form of @ResourceBinary,-<ResourceID> to allow localization as this string would be exposed to the user through the film scanning UI.</para>
      /// </summary>
      public const int WIA_IPS_FILM_NODE_NAME = 4129; // 0x1021
      public const string WIA_IPS_FILM_NODE_NAME_STR = "Film Node Name";

      public const int WIA_IPS_PRINTER_ENDORSER = 4130; // 0x1022
      public const string WIA_IPS_PRINTER_ENDORSER_STR = "Printer/Endorser";

      public const int WIA_IPS_PRINTER_ENDORSER_ORDER = 4131; // 0x1023
      public const string WIA_IPS_PRINTER_ENDORSER_ORDER_STR = "Printer/Endorser Order";

      public const int WIA_IPS_PRINTER_ENDORSER_COUNTER = 4132; // 0x1024
      public const string WIA_IPS_PRINTER_ENDORSER_COUNTER_STR = "Printer/Endorser Counter";

      public const int WIA_IPS_PRINTER_ENDORSER_STEP = 4133; // 0x1025
      public const string WIA_IPS_PRINTER_ENDORSER_STEP_STR = "Printer/Endorser Step";

      public const int WIA_IPS_PRINTER_ENDORSER_XOFFSET = 4134; // 0x1026
      public const string WIA_IPS_PRINTER_ENDORSER_XOFFSET_STR = "Printer/Endorser Horizontal Offset";

      public const int WIA_IPS_PRINTER_ENDORSER_YOFFSET = 4135; // 0x1027
      public const string WIA_IPS_PRINTER_ENDORSER_YOFFSET_STR = "Printer/Endorser Vertical Offset";

      public const int WIA_IPS_PRINTER_ENDORSER_NUM_LINES = 4136; // 0x1028
      public const string WIA_IPS_PRINTER_ENDORSER_NUM_LINES_STR = "Printer/Endorser Lines";

      public const int WIA_IPS_PRINTER_ENDORSER_STRING = 4137; // 0x1029
      public const string WIA_IPS_PRINTER_ENDORSER_STRING_STR = "Printer/Endorser String";

      public const int WIA_IPS_PRINTER_ENDORSER_VALID_CHARACTERS = 4138; // 0x102a
      public const string WIA_IPS_PRINTER_ENDORSER_VALID_CHARACTERS_STR = "Printer/Endorser Valid Characters";

      public const int WIA_IPS_PRINTER_ENDORSER_VALID_FORMAT_SPECIFIERS = 4139; // 0x102b
      public const string WIA_IPS_PRINTER_ENDORSER_VALID_FORMAT_SPECIFIERS_STR = "Printer/Endorser Valid Format Specifiers";

      public const int WIA_IPS_PRINTER_ENDORSER_TEXT_UPLOAD = 4140; // 0x102c
      public const string WIA_IPS_PRINTER_ENDORSER_TEXT_UPLOAD_STR = "Printer/Endorser Text Upload";

      public const int WIA_IPS_PRINTER_ENDORSER_TEXT_DOWNLOAD = 4141; // 0x102d
      public const string WIA_IPS_PRINTER_ENDORSER_TEXT_DOWNLOAD_STR = "Printer/Endorser Text Download";

      public const int WIA_IPS_PRINTER_ENDORSER_GRAPHICS = 4142; // 0x102e
      public const string WIA_IPS_PRINTER_ENDORSER_GRAPHICS_STR = "Printer/Endorser Graphics";

      public const int WIA_IPS_PRINTER_ENDORSER_GRAPHICS_POSITION = 4143; // 0x102f
      public const string WIA_IPS_PRINTER_ENDORSER_GRAPHICS_POSITION_STR = "Printer/Endorser Graphics Position";

      public const int WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MIN_WIDTH = 4144; // 0x1030
      public const string WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MIN_WIDTH_STR = "Printer/Endorser Graphics Minimum Width";

      public const int WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MAX_WIDTH = 4145; // 0x1031
      public const string WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MAX_WIDTH_STR = "Printer/Endorser Graphics Maximum Width";

      public const int WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MIN_HEIGHT = 4146; // 0x1032
      public const string WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MIN_HEIGHT_STR = "Printer/Endorser Graphics Minimum Height";

      public const int WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MAX_HEIGHT = 4147; // 0x1033
      public const string WIA_IPS_PRINTER_ENDORSER_GRAPHICS_MAX_HEIGHT_STR = "Printer/Endorser Graphics Maximum Height";

      public const int WIA_IPS_PRINTER_ENDORSER_GRAPHICS_UPLOAD = 4148; // 0x1034
      public const string WIA_IPS_PRINTER_ENDORSER_GRAPHICS_UPLOAD_STR = "Printer/Endorser Graphics Upload";

      public const int WIA_IPS_PRINTER_ENDORSER_GRAPHICS_DOWNLOAD = 4149; // 0x1035
      public const string WIA_IPS_PRINTER_ENDORSER_GRAPHICS_DOWNLOAD_STR = "Printer/Endorser Graphics Download";

      public const int WIA_IPS_BARCODE_READER = 4150; // 0x1036
      public const string WIA_IPS_BARCODE_READER_STR = "Barcode Reader";

      public const int WIA_IPS_MAXIMUM_BARCODES_PER_PAGE = 4151; // 0x1037
      public const string WIA_IPS_MAXIMUM_BARCODES_PER_PAGE_STR = "Maximum Barcodes Per Page";

      public const int WIA_IPS_BARCODE_SEARCH_DIRECTION = 4152; // 0x1038
      public const string WIA_IPS_BARCODE_SEARCH_DIRECTION_STR = "Barcode Search Direction";

      public const int WIA_IPS_MAXIMUM_BARCODE_SEARCH_RETRIES = 4153; // 0x1039
      public const string WIA_IPS_MAXIMUM_BARCODE_SEARCH_RETRIES_STR = "Barcode Search Retries";

      public const int WIA_IPS_BARCODE_SEARCH_TIMEOUT = 4154; // 0x103a
      public const string WIA_IPS_BARCODE_SEARCH_TIMEOUT_STR = "Barcode Search Timeout";

      public const int WIA_IPS_SUPPORTED_BARCODE_TYPES = 4155; // 0x103b
      public const string WIA_IPS_SUPPORTED_BARCODE_TYPES_STR = "Supported Barcode Types";

      public const int WIA_IPS_ENABLED_BARCODE_TYPES = 4156; // 0x103c
      public const string WIA_IPS_ENABLED_BARCODE_TYPES_STR = "Enabled Barcode Types";

      public const int WIA_IPS_PATCH_CODE_READER = 4157; // 0x103d
      public const string WIA_IPS_PATCH_CODE_READER_STR = "Patch Code Reader";

      public const int WIA_IPS_SUPPORTED_PATCH_CODE_TYPES = 4162; // 0x1042
      public const string WIA_IPS_SUPPORTED_PATCH_CODE_TYPES_STR = "Supported Patch Code Types";

      public const int WIA_IPS_ENABLED_PATCH_CODE_TYPES = 4163; // 0x1043
      public const string WIA_IPS_ENABLED_PATCH_CODE_TYPES_STR = "Enabled Path Code Types";

      public const int WIA_IPS_MICR_READER = 4164; // 0x1044
      public const string WIA_IPS_MICR_READER_STR = "MICR Reader";

      public const int WIA_IPS_JOB_SEPARATORS = 4165; // 0x1045
      public const string WIA_IPS_JOB_SEPARATORS_STR = "Job Separators";

      public const int WIA_IPS_LONG_DOCUMENT = 4166; // 0x1046
      public const string WIA_IPS_LONG_DOCUMENT_STR = "Long Document";

      public const int WIA_IPS_BLANK_PAGES = 4167; // 0x1047
      public const string WIA_IPS_BLANK_PAGES_STR = "Blank Pages";

      public const int WIA_IPS_MULTI_FEED = 4168; // 0x1048
      public const string WIA_IPS_MULTI_FEED_STR = "Multi-Feed";

      public const int WIA_IPS_MULTI_FEED_SENSITIVITY = 4169; // 0x1049
      public const string WIA_IPS_MULTI_FEED_SENSITIVITY_STR = "Multi-Feed Sensitivity";

      public const int WIA_IPS_AUTO_CROP = 4170; // 0x104a
      public const string WIA_IPS_AUTO_CROP_STR = "Auto-Crop";

      public const int WIA_IPS_OVER_SCAN = 4171; // 0x104b
      public const string WIA_IPS_OVER_SCAN_STR = "Overscan";

      public const int WIA_IPS_OVER_SCAN_LEFT = 4172; // 0x104c
      public const string WIA_IPS_OVER_SCAN_LEFT_STR = "Overscan Left";

      public const int WIA_IPS_OVER_SCAN_RIGHT = 4173; // 0x104d
      public const string WIA_IPS_OVER_SCAN_RIGHT_STR = "Overscan Right";

      public const int WIA_IPS_OVER_SCAN_TOP = 4174; // 0x104e
      public const string WIA_IPS_OVER_SCAN_TOP_STR = "Overscan Top";

      public const int WIA_IPS_OVER_SCAN_BOTTOM = 4175; // 0x104f
      public const string WIA_IPS_OVER_SCAN_BOTTOM_STR = "Overscan Bottom";

      public const int WIA_IPS_COLOR_DROP = 4176; // 0x1050
      public const string WIA_IPS_COLOR_DROP_STR = "Color Drop";

      public const int WIA_IPS_COLOR_DROP_RED = 4177; // 0x1051
      public const string WIA_IPS_COLOR_DROP_RED_STR = "Color Drop Red";

      public const int WIA_IPS_COLOR_DROP_GREEN = 4178; // 0x1052
      public const string WIA_IPS_COLOR_DROP_GREEN_STR = "Color Drop Green";

      public const int WIA_IPS_COLOR_DROP_BLUE = 4179; // 0x1053
      public const string WIA_IPS_COLOR_DROP_BLUE_STR = "Color Drop Blue";

      public const int WIA_IPS_SCAN_AHEAD = 4180; // 0x1054
      public const string WIA_IPS_SCAN_AHEAD_STR = "Scan Ahead";

      public const int WIA_IPS_SCAN_AHEAD_CAPACITY = 4181; // 0x1055
      public const string WIA_IPS_SCAN_AHEAD_CAPACITY_STR = "Scan Ahead Capacity";

      public const int WIA_IPS_FEEDER_CONTROL = 4182; // 0x1056
      public const string WIA_IPS_FEEDER_CONTROL_STR = "Feeder Contro=";

      public const int WIA_IPS_PRINTER_ENDORSER_PADDING = 4183; // 0x1057
      public const string WIA_IPS_PRINTER_ENDORSER_PADDING_STR = "Printer/Endorser Padding";

      public const int WIA_IPS_PRINTER_ENDORSER_FONT_TYPE = 4184; // 0x1058
      public const string WIA_IPS_PRINTER_ENDORSER_FONT_TYPE_STR = "Printer/Endorser Font Type";

      public const int WIA_IPS_ALARM = 4185; // 0x1059
      public const string WIA_IPS_ALARM_STR = "Alarm";

      public const int WIA_IPS_PRINTER_ENDORSER_INK = 4186; // 0x105A
      public const string WIA_IPS_PRINTER_ENDORSER_INK_STR = "Printer/Endorser Ink";

      public const int WIA_IPS_PRINTER_ENDORSER_CHARACTER_ROTATION = 4187; // 0x105B
      public const string WIA_IPS_PRINTER_ENDORSER_CHARACTER_ROTATION_STR = "Printer/Endorser Character Rotation";

      public const int WIA_IPS_PRINTER_ENDORSER_MAX_CHARACTERS = 4188; // 0x105C
      public const string WIA_IPS_PRINTER_ENDORSER_MAX_CHARACTERS_STR = "Printer/Endorser Maximum Characters";

      public const int WIA_IPS_PRINTER_ENDORSER_MAX_GRAPHICS = 4189; // 0x105D
      public const string WIA_IPS_PRINTER_ENDORSER_MAX_GRAPHICS_STR = "Printer/Endorser Maximum Graphics";

      public const int WIA_IPS_PRINTER_ENDORSER_COUNTER_DIGITS = 4190; // 0x105E
      public const string WIA_IPS_PRINTER_ENDORSER_COUNTER_DIGITS_STR = "Printer/Endorser Counter Digits";

      public const int WIA_IPS_COLOR_DROP_MULTI = 4191; // 0x105F
      public const string WIA_IPS_COLOR_DROP_MULTI_STR = "Color Drop Multiple";

      public const int WIA_IPS_BLANK_PAGES_SENSITIVITY = 4192; // 0x1060
      public const string WIA_IPS_BLANK_PAGES_SENSITIVITY_STR = "Blank Pages Sensitivity";

      public const int WIA_IPS_MULTI_FEED_DETECT_METHOD = 4193; // 0x1061
      public const string WIA_IPS_MULTI_FEED_DETECT_METHOD_STR = "Multi-Feed Detection Method";


      //
      // WIA_IPS_TRANSFER_CAPABILITIES flags:
      //

      public const int WIA_TRANSFER_CHILDREN_SINGLE_SCAN = 0x00000001;

      //
      // WIA_IPS_SEGMENTATION_FILTER constants
      //

      /// <summary>
      /// The application should use the segmentation filter for multi-region scanning.
      /// </summary>
      public const int WIA_USE_SEGMENTATION_FILTER = 0;
      /// <summary>
      /// The driver creates the child items itself for multi-region scanning. This is usually the case if the scanner uses fixed frames for this purpose.
      /// </summary>
      public const int WIA_DONT_USE_SEGMENTATION_FILTER = 1;

      //
      // WIA_IPS_FILM_SCAN_MODE constants
      //

      /// <summary>
      /// Scan for a color slide.
      /// </summary>
      public const int WIA_FILM_COLOR_SLIDE = 0;
      /// <summary>
      /// Scan for a color negative.
      /// </summary>
      public const int WIA_FILM_COLOR_NEGATIVE = 1;
      /// <summary>
      /// Scan for a black and white negative.
      /// </summary>
      public const int WIA_FILM_BW_NEGATIVE = 2;

      //
      // WIA_IPS_LAMP constants
      //

      /// <summary>
      /// Turn on the lamp.
      /// </summary>
      public const int WIA_LAMP_ON = 0;
      /// <summary>
      /// Turn off the lamp.
      /// </summary>
      public const int WIA_LAMP_OFF = 1;

      //
      // WIA_IPS_AUTO_DESKEW constants
      //

      /// <summary>
      /// Turn on automatic deskew.
      /// </summary>
      public const int WIA_AUTO_DESKEW_ON = 0;
      /// <summary>
      /// Turn off automatic deskew.
      /// </summary>
      public const int WIA_AUTO_DESKEW_OFF = 1;

      //
      // WIA_IPS_PREVIEW_TYPE constants
      //
      /// <summary>
      /// Updating the existing image is possible.
      /// </summary>
      public const int WIA_ADVANCED_PREVIEW = 0;
      /// <summary>
      /// Another preview scan must be executed because updating the existing image is not possible.
      /// </summary>
      public const int WIA_BASIC_PREVIEW = 1;

      //
      // WIA_IPS_PRINTER_ENDORSER constants
      //

      public const int WIA_PRINTER_ENDORSER_DISABLED = 0;
      public const int WIA_PRINTER_ENDORSER_AUTO = 1;
      public const int WIA_PRINTER_ENDORSER_FLATBED = 2;
      public const int WIA_PRINTER_ENDORSER_FEEDER_FRONT = 3;
      public const int WIA_PRINTER_ENDORSER_FEEDER_BACK = 4;
      public const int WIA_PRINTER_ENDORSER_FEEDER_DUPLEX = 5;
      public const int WIA_PRINTER_ENDORSER_DIGITAL = 6;

      //
      // WIA_IPS_PRINTER_ENDORSER_ORDER constants
      //

      public const int WIA_PRINTER_ENDORSER_BEFORE_SCAN = 0;
      public const int WIA_PRINTER_ENDORSER_AFTER_SCAN = 1;

      //
      // WIA_IPS_PRINTER_ENDORSER_VALID_FORMAT_SPECIFIERS constants
      //

      public const int WIA_PRINT_DATE = 0; //L"$DATE$"
      public const int WIA_PRINT_YEAR = 1; //L"$YEAR$"
      public const int WIA_PRINT_MONTH = 2; //L"$MONTH$"
      public const int WIA_PRINT_DAY = 3; //L"$DAY$"
      public const int WIA_PRINT_WEEK_DAY = 4; //L"$WEEK_DAY$"
      public const int WIA_PRINT_TIME_24H = 5; //L"$TIME$"
      public const int WIA_PRINT_TIME_12H = 6; //L"$TIME_12H$"
      public const int WIA_PRINT_HOUR_24H = 7; //L"$HOUR_24H$"
      public const int WIA_PRINT_HOUR_12H = 8; //L"$HOUR_12H$"
      public const int WIA_PRINT_AM_PM = 9; //L"$AM_PM$"
      public const int WIA_PRINT_MINUTE = 10; //L"$MINUTE$"
      public const int WIA_PRINT_SECOND = 11; //L"$SECOND$"
      public const int WIA_PRINT_PAGE_COUNT = 12; //L"$PAGE_COUNT$"
      public const int WIA_PRINT_IMAGE = 13; //L"$IMAGE$"
      public const int WIA_PRINT_MILLISECOND = 14; //L"$MSECOND$"
      public const int WIA_PRINT_MONTH_NAME = 15; //L"$MONTH_NAME$"
      public const int WIA_PRINT_MONTH_SHORT = 16; //L"$MONTH_SHORT$"
      public const int WIA_PRINT_WEEK_DAY_SHORT = 17; //L"$WEEK_DAY_SHORT$"

      //
      // WIA_IPS_PRINTER_ENDORSER_GRAPHICS_POSITION constants
      //

      public const int WIA_PRINTER_ENDORSER_GRAPHICS_LEFT = 0;
      public const int WIA_PRINTER_ENDORSER_GRAPHICS_RIGHT = 1;
      public const int WIA_PRINTER_ENDORSER_GRAPHICS_TOP = 2;
      public const int WIA_PRINTER_ENDORSER_GRAPHICS_BOTTOM = 3;
      public const int WIA_PRINTER_ENDORSER_GRAPHICS_TOP_LEFT = 4;
      public const int WIA_PRINTER_ENDORSER_GRAPHICS_TOP_RIGHT = 5;
      public const int WIA_PRINTER_ENDORSER_GRAPHICS_BOTTOM_LEFT = 6;
      public const int WIA_PRINTER_ENDORSER_GRAPHICS_BOTTOM_RIGHT = 7;
      public const int WIA_PRINTER_ENDORSER_GRAPHICS_BACKGROUND = 8;
      public const int WIA_PRINTER_ENDORSER_GRAPHICS_DEVICE_DEFAULT = 9;

      //
      // WIA_IPS_BARCODE_READER constants
      //

      public const int WIA_BARCODE_READER_DISABLED = 0;
      public const int WIA_BARCODE_READER_AUTO = 1;
      public const int WIA_BARCODE_READER_FLATBED = 2;
      public const int WIA_BARCODE_READER_FEEDER_FRONT = 3;
      public const int WIA_BARCODE_READER_FEEDER_BACK = 4;
      public const int WIA_BARCODE_READER_FEEDER_DUPLEX = 5;

      //
      // The WIA_IPS_BARCODE_SEARCH_DIRECTION constants
      //

      public const int WIA_BARCODE_HORIZONTAL_SEARCH = 0;
      public const int WIA_BARCODE_VERTICAL_SEARCH = 1;
      public const int WIA_BARCODE_HORIZONTAL_VERTICAL_SEARCH = 2;
      public const int WIA_BARCODE_VERTICAL_HORIZONTAL_SEARCH = 3;
      public const int WIA_BARCODE_AUTO_SEARCH = 4;

      //
      // WIA_IPS_SUPPORTED_BARCODE_TYPES constants
      //

      public const int WIA_BARCODE_UPCA = 0;
      public const int WIA_BARCODE_UPCE = 1;
      public const int WIA_BARCODE_CODABAR = 2;
      public const int WIA_BARCODE_NONINTERLEAVED_2OF5 = 3;
      public const int WIA_BARCODE_INTERLEAVED_2OF5 = 4;
      public const int WIA_BARCODE_CODE39 = 5;
      public const int WIA_BARCODE_CODE39_MOD43 = 6;
      public const int WIA_BARCODE_CODE39_FULLASCII = 7;
      public const int WIA_BARCODE_CODE93 = 8;
      public const int WIA_BARCODE_CODE128 = 9;
      public const int WIA_BARCODE_CODE128A = 10;
      public const int WIA_BARCODE_CODE128B = 11;
      public const int WIA_BARCODE_CODE128C = 12;
      public const int WIA_BARCODE_GS1128 = 13;
      public const int WIA_BARCODE_GS1DATABAR = 14;
      public const int WIA_BARCODE_ITF14 = 15;
      public const int WIA_BARCODE_EAN8 = 16;
      public const int WIA_BARCODE_EAN13 = 17;
      public const int WIA_BARCODE_POSTNETA = 18;
      public const int WIA_BARCODE_POSTNETB = 19;
      public const int WIA_BARCODE_POSTNETC = 20;
      public const int WIA_BARCODE_POSTNET_DPBC = 21;
      public const int WIA_BARCODE_PLANET = 22;
      public const int WIA_BARCODE_INTELLIGENT_MAIL = 23;
      public const int WIA_BARCODE_POSTBAR = 24;
      public const int WIA_BARCODE_RM4SCC = 25;
      public const int WIA_BARCODE_HIGH_CAPACITY_COLOR = 26;
      public const int WIA_BARCODE_MAXICODE = 27;
      public const int WIA_BARCODE_PDF417 = 28;
      public const int WIA_BARCODE_CPCBINARY = 29;
      public const int WIA_BARCODE_FIM = 30;
      public const int WIA_BARCODE_PHARMACODE = 31;
      public const int WIA_BARCODE_PLESSEY = 32;
      public const int WIA_BARCODE_MSI = 33;
      public const int WIA_BARCODE_JAN = 34;
      public const int WIA_BARCODE_TELEPEN = 35;
      public const int WIA_BARCODE_AZTEC = 36;
      public const int WIA_BARCODE_SMALLAZTEC = 37;
      public const int WIA_BARCODE_DATAMATRIX = 38;
      public const int WIA_BARCODE_DATASTRIP = 39;
      public const int WIA_BARCODE_EZCODE = 40;
      public const int WIA_BARCODE_QRCODE = 41;
      public const int WIA_BARCODE_SHOTCODE = 42;
      public const int WIA_BARCODE_SPARQCODE = 43;
      public const int WIA_BARCODE_CUSTOMBASE = 0x8000;

      //
      // WIA_IPS_PATH_CODE_READER constants
      //

      public const int WIA_PATCH_CODE_READER_DISABLED = 0;
      public const int WIA_PATCH_CODE_READER_AUTO = 1;
      public const int WIA_PATCH_CODE_READER_FLATBED = 2;
      public const int WIA_PATCH_CODE_READER_FEEDER_FRONT = 3;
      public const int WIA_PATCH_CODE_READER_FEEDER_BACK = 4;
      public const int WIA_PATCH_CODE_READER_FEEDER_DUPLEX = 5;

      //
      // WIA_IPS_SUPPORTED_PATCH_CODE_TYPES constants
      //

      public const int WIA_PATCH_CODE_UNKNOWN = 0;
      public const int WIA_PATCH_CODE_1 = 1;
      public const int WIA_PATCH_CODE_2 = 2;
      public const int WIA_PATCH_CODE_3 = 3;
      public const int WIA_PATCH_CODE_4 = 4;
      public const int WIA_PATCH_CODE_T = 5;
      public const int WIA_PATCH_CODE_6 = 6;
      public const int WIA_PATCH_CODE_7 = 7;
      public const int WIA_PATCH_CODE_8 = 8;
      public const int WIA_PATCH_CODE_9 = 9;
      public const int WIA_PATCH_CODE_10 = 10;
      public const int WIA_PATCH_CODE_11 = 11;
      public const int WIA_PATCH_CODE_12 = 12;
      public const int WIA_PATCH_CODE_13 = 13;
      public const int WIA_PATCH_CODE_14 = 14;
      public const int WIA_PATCH_CODE_CUSTOM_BASE = 0x8000;

      //
      // WIA_IPS_MICR_READER constants
      //

      public const int WIA_MICR_READER_DISABLED = 0;
      public const int WIA_MICR_READER_AUTO = 1;
      public const int WIA_MICR_READER_FLATBED = 2;
      public const int WIA_MICR_READER_FEEDER_FRONT = 3;
      public const int WIA_MICR_READER_FEEDER_BACK = 4;
      public const int WIA_MICR_READER_FEEDER_DUPLEX = 5;

      //
      // WIA_IPS_JOB_SEPARATORS constants
      //

      public const int WIA_SEPARATOR_DISABLED = 0;
      public const int WIA_SEPARATOR_DETECT_SCAN_CONTINUE = 1;
      public const int WIA_SEPARATOR_DETECT_SCAN_STOP = 2;
      public const int WIA_SEPARATOR_DETECT_NOSCAN_CONTINUE = 3;
      public const int WIA_SEPARATOR_DETECT_NOSCAN_STOP = 4;

      //
      // WIA_IPS_LONG_DOCUMENT constants
      //

      public const int WIA_LONG_DOCUMENT_DISABLED = 0;
      public const int WIA_LONG_DOCUMENT_ENABLED = 1;
      public const int WIA_LONG_DOCUMENT_SPLIT = 2;

      //
      // WIA_IPS_BLANK_PAGES constants
      //

      public const int WIA_BLANK_PAGE_DETECTION_DISABLED = 0;
      public const int WIA_BLANK_PAGE_DISCARD = 1;
      public const int WIA_BLANK_PAGE_JOB_SEPARATOR = 2;

      //
      // WIA_IPS_MULTI_FEED constants
      //

      public const int WIA_MULTI_FEED_DETECT_DISABLED = 0;
      public const int WIA_MULTI_FEED_DETECT_STOP_ERROR = 1;
      public const int WIA_MULTI_FEED_DETECT_STOP_SUCCESS = 2;
      public const int WIA_MULTI_FEED_DETECT_CONTINUE = 3;

      //
      // WIA_IPS_MULTI_FEED_DETECT_METHOD constants
      //

      public const int WIA_MULTI_FEED_DETECT_METHOD_LENGTH = 0;
      public const int WIA_MULTI_FEED_DETECT_METHOD_OVERLAP = 1;

      //
      // WIA_IPS_AUTO_CROP constants
      //

      public const int WIA_AUTO_CROP_DISABLED = 0;
      public const int WIA_AUTO_CROP_SINGLE = 1;
      public const int WIA_AUTO_CROP_MULTI = 2;

      //
      // WIA_IPS_OVER_SCAN constants
      //

      public const int WIA_OVER_SCAN_DISABLED = 0;
      public const int WIA_OVER_SCAN_TOP_BOTTOM = 1;
      public const int WIA_OVER_SCAN_LEFT_RIGHT = 2;
      public const int WIA_OVER_SCAN_ALL = 3;

      //
      // WIA_IPS_COLOR_DROP constants
      //

      public const int WIA_COLOR_DROP_DISABLED = 0;
      public const int WIA_COLOR_DROP_RED = 1;
      public const int WIA_COLOR_DROP_GREEN = 2;
      public const int WIA_COLOR_DROP_BLUE = 3;
      public const int WIA_COLOR_DROP_RGB = 4;

      //
      // WIA_IPS_SCAN_AHEAD constants
      //

      public const int WIA_SCAN_AHEAD_DISABLED = 0;
      public const int WIA_SCAN_AHEAD_ENABLED = 1;

      //
      // WIA_IPS_FEEDER_CONTROL constants
      //

      public const int WIA_FEEDER_CONTROL_AUTO = 0;
      public const int WIA_FEEDER_CONTROL_MANUAL = 1;

      //
      // WIA_IPS_PRINTER_ENDORSER_PADDING constants
      //

      public const int WIA_PRINT_PADDING_NONE = 0;
      public const int WIA_PRINT_PADDING_ZERO = 1;
      public const int WIA_PRINT_PADDING_BLANK = 2;

      //
      // WIA_IPS_PRINTER_ENDORSER_FONT_TYPE constants
      //

      public const int WIA_PRINT_FONT_NORMAL = 0;
      public const int WIA_PRINT_FONT_BOLD = 1;
      public const int WIA_PRINT_FONT_EXTRA_BOLD = 2;
      public const int WIA_PRINT_FONT_ITALIC_BOLD = 3;
      public const int WIA_PRINT_FONT_ITALIC_EXTRA_BOLD = 4;
      public const int WIA_PRINT_FONT_ITALIC = 5;
      public const int WIA_PRINT_FONT_SMALL = 6;
      public const int WIA_PRINT_FONT_SMALL_BOLD = 7;
      public const int WIA_PRINT_FONT_SMALL_EXTRA_BOLD = 8;
      public const int WIA_PRINT_FONT_SMALL_ITALIC_BOLD = 9;
      public const int WIA_PRINT_FONT_SMALL_ITALIC_EXTRA_BOLD = 10;
      public const int WIA_PRINT_FONT_SMALL_ITALIC = 11;
      public const int WIA_PRINT_FONT_LARGE = 12;
      public const int WIA_PRINT_FONT_LARGE_BOLD = 13;
      public const int WIA_PRINT_FONT_LARGE_EXTRA_BOLD = 14;
      public const int WIA_PRINT_FONT_LARGE_ITALIC_BOLD = 15;
      public const int WIA_PRINT_FONT_LARGE_ITALIC_EXTRA_BOLD = 16;
      public const int WIA_PRINT_FONT_LARGE_ITALIC = 17;

      //
      // WIA_IPS_ALARM constants
      //

      public const int WIA_ALARM_NONE = 0;
      public const int WIA_ALARM_BEEP1 = 1;
      public const int WIA_ALARM_BEEP2 = 2;
      public const int WIA_ALARM_BEEP3 = 3;
      public const int WIA_ALARM_BEEP4 = 4;
      public const int WIA_ALARM_BEEP5 = 5;
      public const int WIA_ALARM_BEEP6 = 6;
      public const int WIA_ALARM_BEEP7 = 7;
      public const int WIA_ALARM_BEEP8 = 8;
      public const int WIA_ALARM_BEEP9 = 9;
      public const int WIA_ALARM_BEEP10 = 10;
      //
      // WIA TYMED constants
      //

      public const int TYMED_CALLBACK = 128;
      public const int TYMED_MULTIPAGE_FILE = 256;
      public const int TYMED_MULTIPAGE_CALLBACK = 512;

      //
      // IWiaDataCallback and IWiaMiniDrvCallBack message ID constants
      //

      public const int IT_MSG_DATA_HEADER = 0x0001;
      public const int IT_MSG_DATA = 0x0002;
      public const int IT_MSG_STATUS = 0x0003;
      public const int IT_MSG_TERMINATION = 0x0004;
      public const int IT_MSG_NEW_PAGE = 0x0005;
      public const int IT_MSG_FILE_PREVIEW_DATA = 0x0006;
      public const int IT_MSG_FILE_PREVIEW_DATA_HEADER = 0x0007;

      //
      // IWiaDataCallback and IWiaMiniDrvCallBack status flag constants
      //

      public const int IT_STATUS_TRANSFER_FROM_DEVICE = 0x0001;
      public const int IT_STATUS_PROCESSING_DATA = 0x0002;
      public const int IT_STATUS_TRANSFER_TO_CLIENT = 0x0004;
      public const int IT_STATUS_MASK = 0x0007; // any status value that doesn't
                                         // fit the mask is an HRESULT
                                         //
                                         // IWiaTransfer flags
                                         //

      public const int WIA_TRANSFER_ACQUIRE_CHILDREN = 0x0001;

      //
      // IWiaTransferCallback Message types
      //

      public const int WIA_TRANSFER_MSG_STATUS = 0x00001;
      public const int WIA_TRANSFER_MSG_END_OF_STREAM = 0x00002;
      public const int WIA_TRANSFER_MSG_END_OF_TRANSFER = 0x00003;
      public const int WIA_TRANSFER_MSG_DEVICE_STATUS = 0x00005;
      public const int WIA_TRANSFER_MSG_NEW_PAGE = 0x00006;

      //
      // IWiaEventCallback code constants
      //

      public const int WIA_MAJOR_EVENT_DEVICE_CONNECT = 0x01;
      public const int WIA_MAJOR_EVENT_DEVICE_DISCONNECT = 0x02;
      public const int WIA_MAJOR_EVENT_PICTURE_TAKEN = 0x03;
      public const int WIA_MAJOR_EVENT_PICTURE_DELETED = 0x04;

      //
      // WIA device connection status constants
      //

      public const int WIA_DEVICE_NOT_CONNECTED = 0;
      public const int WIA_DEVICE_CONNECTED = 1;

      //
      // EnumDeviceCapabilities and drvGetCapabilities flags
      //

      public const int WIA_DEVICE_COMMANDS = 1;
      public const int WIA_DEVICE_EVENTS = 2;

      //
      // EnumDeviceInfo Flags
      //

      public const int WIA_DEVINFO_ENUM_ALL = 0x0000000F;
      public const int WIA_DEVINFO_ENUM_LOCAL = 0x00000010;


      //
      // WIA item type constants
      //

      public const int WiaItemTypeFree = 0x00000000;
      public const int WiaItemTypeImage = 0x00000001;
      public const int WiaItemTypeFile = 0x00000002;
      public const int WiaItemTypeFolder = 0x00000004;
      public const int WiaItemTypeRoot = 0x00000008;
      public const int WiaItemTypeAnalyze = 0x00000010;
      public const int WiaItemTypeAudio = 0x00000020;
      public const int WiaItemTypeDevice = 0x00000040;
      public const int WiaItemTypeDeleted = 0x00000080;
      public const int WiaItemTypeDisconnected = 0x00000100;
      public const int WiaItemTypeHPanorama = 0x00000200;
      public const int WiaItemTypeVPanorama = 0x00000400;
      public const int WiaItemTypeBurst = 0x00000800;
      public const int WiaItemTypeStorage = 0x00001000;
      public const int WiaItemTypeTransfer = 0x00002000;
      public const int WiaItemTypeGenerated = 0x00004000;
      public const int WiaItemTypeHasAttachments = 0x00008000;
      public const int WiaItemTypeVideo = 0x00010000;
      public const uint WiaItemTypeRemoved = 0x80000000;
      //
      // =0x00020000; is reserved for the TWAIN-WIA Compatiblity Layer
      //
      public const int WiaItemTypeDocument = 0x00040000;
      public const int WiaItemTypeProgrammableDataSource = 0x00080000;
      public const uint WiaItemTypeMask = 0x800FFFFF;

      //
      // Maximum device specific item context
      //

      public const int WIA_MAX_CTX_SIZE = 0x01000000;

      //
      // WIA property access flag constants
      //

      public const int WIA_PROP_READ = 0x01;
      public const int WIA_PROP_WRITE = 0x02;
      public const int WIA_PROP_RW = (WIA_PROP_READ | WIA_PROP_WRITE);
      public const int WIA_PROP_SYNC_REQUIRED = 0x04;

      public const int WIA_PROP_NONE = 0x08;
      public const int WIA_PROP_RANGE = 0x10;
      public const int WIA_PROP_LIST = 0x20;
      public const int WIA_PROP_FLAG = 0x40;

      public const int WIA_PROP_CACHEABLE = 0x10000;

      //
      // IWiaItem2 CreateChildItem flag constants
      //

      public const int COPY_PARENT_PROPERTY_VALUES = 0x40000000;

      //
      // WIA item access flag constants
      //

      public const int WIA_ITEM_CAN_BE_DELETED = 0x80;
      public const int WIA_ITEM_READ = WIA_PROP_READ;
      public const int WIA_ITEM_WRITE = WIA_PROP_WRITE;
      public const int WIA_ITEM_RD = (WIA_ITEM_READ | WIA_ITEM_CAN_BE_DELETED);
      public const int WIA_ITEM_RWD = (WIA_ITEM_READ | WIA_ITEM_WRITE | WIA_ITEM_CAN_BE_DELETED);

      //
      // WIA property container constants
      //

      public const int WIA_RANGE_MIN = 0;
      public const int WIA_RANGE_NOM = 1;
      public const int WIA_RANGE_MAX = 2;
      public const int WIA_RANGE_STEP = 3;
      public const int WIA_RANGE_NUM_ELEMS = 4;

      public const int WIA_LIST_COUNT = 0;
      public const int WIA_LIST_NOM = 1;
      public const int WIA_LIST_VALUES = 2;
      public const int WIA_LIST_NUM_ELEMS = 2;

      public const int WIA_FLAG_NOM = 0;
      public const int WIA_FLAG_VALUES = 1;
      public const int WIA_FLAG_NUM_ELEMS = 2;
      //
      // Microsoft defined WIA property offset constants
      //

      public const int WIA_DIP_FIRST = 2;
      public const int WIA_IPA_FIRST = 4098;
      public const int WIA_DPF_FIRST = 3330;
      public const int WIA_IPS_FIRST = 6146;
      public const int WIA_DPS_FIRST = 3074;
      public const int WIA_IPC_FIRST = 5122;
      public const int WIA_NUM_IPC = 9;
      public const int WIA_RESERVED_FOR_NEW_PROPS = 1024;

      //
      // WIA_DPC_WHITE_BALANCE constants
      //

      public const int WHITEBALANCE_MANUAL = 1;
      public const int WHITEBALANCE_AUTO = 2;
      public const int WHITEBALANCE_ONEPUSH_AUTO = 3;
      public const int WHITEBALANCE_DAYLIGHT = 4;
      public const int WHITEBALANCE_FLORESCENT = 5;
      public const int WHITEBALANCE_TUNGSTEN = 6;
      public const int WHITEBALANCE_FLASH = 7;

      //
      // WIA_DPC_FOCUS_MODE constants
      //

      public const int FOCUSMODE_MANUAL = 1;
      public const int FOCUSMODE_AUTO = 2;
      public const int FOCUSMODE_MACROAUTO = 3;

      //
      // WIA_DPC_EXPOSURE_METERING_MODE constants
      //

      public const int EXPOSUREMETERING_AVERAGE = 1;
      public const int EXPOSUREMETERING_CENTERWEIGHT = 2;
      public const int EXPOSUREMETERING_MULTISPOT = 3;
      public const int EXPOSUREMETERING_CENTERSPOT = 4;

      //
      // WIA_DPC_FLASH_MODE constants
      //

      public const int FLASHMODE_AUTO = 1;
      public const int FLASHMODE_OFF = 2;
      public const int FLASHMODE_FILL = 3;
      public const int FLASHMODE_REDEYE_AUTO = 4;
      public const int FLASHMODE_REDEYE_FILL = 5;
      public const int FLASHMODE_EXTERNALSYNC = 6;

      //
      // WIA_DPC_EXPOSURE_MODE constants
      //

      public const int EXPOSUREMODE_MANUAL = 1;
      public const int EXPOSUREMODE_AUTO = 2;
      public const int EXPOSUREMODE_APERTURE_PRIORITY = 3;
      public const int EXPOSUREMODE_SHUTTER_PRIORITY = 4;
      public const int EXPOSUREMODE_PROGRAM_CREATIVE = 5;
      public const int EXPOSUREMODE_PROGRAM_ACTION = 6;
      public const int EXPOSUREMODE_PORTRAIT = 7;

      //
      // WIA_DPC_CAPTURE_MODE constants
      //

      public const int CAPTUREMODE_NORMAL = 1;
      public const int CAPTUREMODE_BURST = 2;
      public const int CAPTUREMODE_TIMELAPSE = 3;

      //
      // WIA_DPC_EFFECT_MODE constants
      //

      public const int EFFECTMODE_STANDARD = 1;
      public const int EFFECTMODE_BW = 2;
      public const int EFFECTMODE_SEPIA = 3;

      //
      // WIA_DPC_FOCUS_METERING_MODE constants
      //

      public const int FOCUSMETERING_CENTERSPOT = 1;
      public const int FOCUSMETERING_MULTISPOT = 2;

      //
      // WIA_DPC_POWER_MODE constants
      //

      public const int POWERMODE_LINE = 1;
      public const int POWERMODE_BATTERY = 2;

      //
      // WIA_DPS_SHEET_FEEDER_REGISTRATION and
      // WIA_DPS_HORIZONTAL_BED_REGISTRATION constants
      //

      /// <summary>
      /// The sheet is positioned to the left with respect to the scanning head.
      /// </summary>
      public const int LEFT_JUSTIFIED = 0;
      /// <summary>
      /// The sheet is centered on the scanning head.
      /// </summary>
      public const int CENTERED = 1;
      /// <summary>
      /// The sheet is positioned to the right with respect to the scanning head.
      /// </summary>
      public const int RIGHT_JUSTIFIED = 2;

      //
      // WIA_DPS_VERTICAL_BED_REGISTRATION constants
      //

      public const int TOP_JUSTIFIED = 0;
      //public const int CENTERED = 1;
      public const int BOTTOM_JUSTIFIED = 2;

      //
      // WIA_IPS_ORIENTATION and WIA_IPS_ROTATION constants
      //

      /// <summary>
      /// 0 degrees. / The driver will not rotate the image.
      /// </summary>
      public const int PORTRAIT = 0;
      public const int LANSCAPE = 1;
      /// <summary>
      /// 90-degree counter-clockwise rotation, relative to the PORTRAIT orientation. / The driver rotates the image 90 degrees counterclockwise.
      /// </summary>
      public const int LANDSCAPE = LANSCAPE;
      /// <summary>
      /// 180-degree counter-clockwise rotation, relative to the PORTRAIT orientation. / The driver rotates the image 180 degrees counterclockwise.
      /// </summary>
      public const int ROT180 = 2;
      /// <summary>
      /// 270-degree counter-clockwise rotation, relative to the PORTRAIT orientation. / The driver rotates the image 270 degrees counterclockwise.
      /// </summary>
      public const int ROT270 = 3;


      //
      // WIA_IPS_MIRROR flags
      //

      public const int MIRRORED = 0x01;

      //
      // WIA_DPS_DOCUMENT_HANDLING_CAPABILITIES flags
      //

      public const int FEED = 0x01;
      public const int FLAT = 0x02;
      public const int DUP = 0x04;
      public const int DETECT_FLAT = 0x08;
      public const int DETECT_SCAN = 0x10;
      public const int DETECT_FEED = 0x20;
      public const int DETECT_DUP = 0x40;
      public const int DETECT_FEED_AVAIL = 0x80;
      public const int DETECT_DUP_AVAIL = 0x100;
      public const int FILM_TPA = 0x200;
      public const int DETECT_FILM_TPA = 0x400;
      public const int STOR = 0x800;
      public const int DETECT_STOR = 0x1000;
      public const int ADVANCED_DUP = 0x2000;
      public const int AUTO_SOURCE = 0x8000;
      public const int IMPRINTER = 0x10000;
      public const int ENDORSER = 0x20000;
      public const int BARCODE_READER = 0x40000;
      public const int PATCH_CODE_READER = 0x80000;
      public const int MICR_READER = 0x100000;

      //
      // WIA_DPS_DOCUMENT_HANDLING_STATUS flags
      //

      public const int FEED_READY = 0x01;
      public const int FLAT_READY = 0x02;
      public const int DUP_READY = 0x04;
      public const int FLAT_COVER_UP = 0x08;
      public const int PATH_COVER_UP = 0x10;
      public const int PAPER_JAM = 0x20;
      public const int FILM_TPA_READY = 0x40;
      public const int STORAGE_READY = 0x80;
      public const int STORAGE_FULL = 0x100;
      public const int MULTIPLE_FEED = 0x200;
      public const int DEVICE_ATTENTION = 0x400;
      public const int LAMP_ERR = 0x800;
      public const int IMPRINTER_READY = 0x1000;
      public const int ENDORSER_READY = 0x2000;
      public const int BARCODE_READER_READY = 0x4000;
      public const int PATCH_CODE_READER_READY = 0x8000;
      public const int MICR_READER_READY = 0x10000;

      //
      // WIA_DPS_DOCUMENT_HANDLING_SELECT flags
      //

      public const int FEEDER = 0x001;
      public const int FLATBED = 0x002;
      /// <summary>
      /// Scan using duplexer operations. Scan both document sides using common settings configured for the feeder item (WIA_CATEGORY_FEEDER). DUPLEX and ADVANCE_DUPLEX cannot both be set.
      /// </summary>
      public const int DUPLEX = 0x004;
      /// <summary>
      /// Scan the front of the document first. This value is valid when DUPLEX or ADVANCED_DUPLEX is set.
      /// </summary>
      public const int FRONT_FIRST = 0x008;
      /// <summary>
      /// Scan the back of the document first. This value is valid when DUPLEX or ADVANCED_DUPLEX is set.
      /// </summary>
      public const int BACK_FIRST = 0x010;
      /// <summary>
      /// Scan the front only.
      /// </summary>
      public const int FRONT_ONLY = 0x020;
      /// <summary>
      /// Scan the back only. This value is valid when DUPLEX or ADVANCED_DUPLEX is set.
      /// </summary>
      public const int BACK_ONLY = 0x040;
      public const int NEXT_PAGE = 0x080;
      public const int PREFEED = 0x100;
      public const int AUTO_ADVANCE = 0x200;
      //
      // New WIA_IPS_DOCUMENT_HANDLING_SELECT flag
      //
      /// <summary>
      /// Scan using individual settings configured for each child feeder item (WIA_CATEGORY_FEEDER_FRONT and WIA_CATEGORY_FEEDER_BACK). DUPLEX and ADVANCE_DUPLEX cannot both be set.
      /// </summary>
      public const int ADVANCED_DUPLEX = 0x400;

      //
      // WIA_DPS_TRANSPARENCY / WIA_DPS_TRANSPARENCY_STATUS flags
      //

      public const int LIGHT_SOURCE_PRESENT_DETECT = 0x01;
      public const int LIGHT_SOURCE_PRESENT = 0x02;
      public const int LIGHT_SOURCE_DETECT_READY = 0x04;
      public const int LIGHT_SOURCE_READY = 0x08;

      //
      // WIA_DPS_TRANSPARENCY_CAPABILITIES
      //

      public const int TRANSPARENCY_DYNAMIC_FRAME_SUPPORT = 0x01;
      public const int TRANSPARENCY_STATIC_FRAME_SUPPORT = 0x02;

      //
      // WIA_DPS_TRANSPARENCY_SELECT flags
      //

      public const int LIGHT_SOURCE_SELECT = 0x001; // currently not used
      public const int LIGHT_SOURCE_POSITIVE = 0x002;
      public const int LIGHT_SOURCE_NEGATIVE = 0x004;

      //
      // WIA_DPS_SCAN_AHEAD_PAGES constants
      //
      // WIA_DPS_SCAN_AHEAD_PAGES is superseded in WIA 2.0 by WIA_IPS_SCAN_AHEAD
      //

      public const int WIA_SCAN_AHEAD_ALL = 0;

      //
      // WIA_DPS_PAGES constants
      //

      public const int ALL_PAGES = 0;

      //
      // WIA_DPS_PREVIEW constants
      //
      /// <summary>
      /// The application will perform a final scan.
      /// </summary>
      public const int WIA_FINAL_SCAN = 0;
      /// <summary>
      /// The application will perform a preview scan.
      /// </summary>
      public const int WIA_PREVIEW_SCAN = 1;

      //
      // WIA_DPS_SHOW_PREVIEW_CONTROL constants
      //

      /// <summary>
      /// Show a preview control to the user, because this device can perform a preview.
      /// </summary>
      public const int WIA_SHOW_PREVIEW_CONTROL = 0;
      /// <summary>
      /// Do not show a preview control to the user, because this device cannot perform a preview.
      /// </summary>
      public const int WIA_DONT_SHOW_PREVIEW_CONTROL = 1;

      //
      // Predefined strings for WIA_DPS_ENDORSER_STRING
      //
      // WIA_DPS_ENDORSER_STRING is superseded in WIA 2.0 by WIA_IPS_PRINTER_ENDORSER_STRING and these
      // constant values are replaced by the WIA_IPS_PRINTER_ENDORSER_VALID_FORMAT_SPECIFIERS constants
      //

      public const string WIA_ENDORSER_TOK_DATE = "$DATE$";
      public const string WIA_ENDORSER_TOK_TIME = "$TIME$";
      public const string WIA_ENDORSER_TOK_PAGE_COUNT = "$PAGE_COUNT$";
      public const string WIA_ENDORSER_TOK_DAY = "$DAY$";
      public const string WIA_ENDORSER_TOK_MONTH = "$MONTH$";
      public const string WIA_ENDORSER_TOK_YEAR = "$YEAR$";

      //
      // WIA_DPS_PAGE_SIZE/WIA_IPS_PAGE_SIZE constants
      // Dimensions are defined as (WIDTH x HEIGHT) in 1/1000ths of an inch
      //

      public const int WIA_PAGE_A4 = 0; //  8267 x 11692
      public const int WIA_PAGE_LETTER = 1; //  8500 x 11000
      /// <summary>
      /// Defined by the values of the WIA_IPS_PAGE_HEIGHT and WIA_IPS_PAGE_WIDTH properties.
      /// </summary>
      public const int WIA_PAGE_CUSTOM = 2; // (current extent settings)

      public const int WIA_PAGE_USLEGAL = 3; //  8500 x 14000
      public const int WIA_PAGE_USLETTER = WIA_PAGE_LETTER;
      public const int WIA_PAGE_USLEDGER = 4; // 11000 x 17000
      public const int WIA_PAGE_USSTATEMENT = 5; //  5500 x  8500
      public const int WIA_PAGE_BUSINESSCARD = 6; //  3543 x  2165

      //
      // ISO A page size constants
      //

      public const int WIA_PAGE_ISO_A0 = 7; // 33110 x 46811
      public const int WIA_PAGE_ISO_A1 = 8; // 23385 x 33110
      public const int WIA_PAGE_ISO_A2 = 9; // 16535 x 23385
      public const int WIA_PAGE_ISO_A3 = 10; // 11692 x 16535
      public const int WIA_PAGE_ISO_A4 = WIA_PAGE_A4;
      public const int WIA_PAGE_ISO_A5 = 11; //  5826 x  8267
      public const int WIA_PAGE_ISO_A6 = 12; //  4133 x  5826
      public const int WIA_PAGE_ISO_A7 = 13; //  2913 x  4133
      public const int WIA_PAGE_ISO_A8 = 14; //  2047 x  2913
      public const int WIA_PAGE_ISO_A9 = 15; //  1456 x  2047
      public const int WIA_PAGE_ISO_A10 = 16; //  1023 x  1456

      //
      // ISO B page size constants
      //

      public const int WIA_PAGE_ISO_B0 = 17; //  39370 x 55669
      public const int WIA_PAGE_ISO_B1 = 18; //  27834 x 39370
      public const int WIA_PAGE_ISO_B2 = 19; //  19685 x 27834
      public const int WIA_PAGE_ISO_B3 = 20; //  13897 x 19685
      public const int WIA_PAGE_ISO_B4 = 21; //   9842 x 13897
      public const int WIA_PAGE_ISO_B5 = 22; //   6929 x  9842
      public const int WIA_PAGE_ISO_B6 = 23; //   4921 x  6929
      public const int WIA_PAGE_ISO_B7 = 24; //   3464 x  4921
      public const int WIA_PAGE_ISO_B8 = 25; //   2440 x  3464
      public const int WIA_PAGE_ISO_B9 = 26; //   1732 x  2440
      public const int WIA_PAGE_ISO_B10 = 27; //   1220 x  1732

      //
      // ISO C page size constants
      //

      public const int WIA_PAGE_ISO_C0 = 28; //  36102 x 51062
      public const int WIA_PAGE_ISO_C1 = 29; //  25511 x 36102
      public const int WIA_PAGE_ISO_C2 = 30; //  18031 x 25511
      public const int WIA_PAGE_ISO_C3 = 31; //  12755 x 18031
      public const int WIA_PAGE_ISO_C4 = 32; //   9015 x 12755 (unfolded)
      public const int WIA_PAGE_ISO_C5 = 33; //   6377 x  9015 (folded once)
      public const int WIA_PAGE_ISO_C6 = 34; //   4488 x  6377 (folded twice)
      public const int WIA_PAGE_ISO_C7 = 35; //   3188 x  4488
      public const int WIA_PAGE_ISO_C8 = 36; //   2244 x  3188
      public const int WIA_PAGE_ISO_C9 = 37; //   1574 x  2244
      public const int WIA_PAGE_ISO_C10 = 38; //   1102 x  1574

      //
      // JIS B page size constants
      //

      public const int WIA_PAGE_JIS_B0 = 39; //  40551 x 57322
      public const int WIA_PAGE_JIS_B1 = 40; //  28661 x 40551
      public const int WIA_PAGE_JIS_B2 = 41; //  20275 x 28661
      public const int WIA_PAGE_JIS_B3 = 42; //  14330 x 20275
      public const int WIA_PAGE_JIS_B4 = 43; //  10118 x 14330
      public const int WIA_PAGE_JIS_B5 = 44; //   7165 x 10118
      public const int WIA_PAGE_JIS_B6 = 45; //   5039 x  7165
      public const int WIA_PAGE_JIS_B7 = 46; //   3582 x  5039
      public const int WIA_PAGE_JIS_B8 = 47; //   2519 x  3582
      public const int WIA_PAGE_JIS_B9 = 48; //   1771 x  2519
      public const int WIA_PAGE_JIS_B10 = 49; //   1259 x  1771

      //
      // JIS A page size constants
      //

      public const int WIA_PAGE_JIS_2A = 50; //  46811 x 66220
      public const int WIA_PAGE_JIS_4A = 51; //  66220 x  93622

      //
      // DIN B page size constants
      //

      public const int WIA_PAGE_DIN_2B = 52; //  55669 x 78740
      public const int WIA_PAGE_DIN_4B = 53; //  78740 x 111338

      //
      // Additional WIA_IPS_PAGE_SIZE constants:
      //
      /// <summary>
      /// Page size is automatically determined by the device.
      /// </summary>
      public const int WIA_PAGE_AUTO = 100;
      /// <summary>
      /// A custom page size whose dimensions are already known to the application and the device driver.
      /// </summary>
      public const int WIA_PAGE_CUSTOM_BASE = 0x8000;


      //
      // WIA_IPA_COMPRESSION constants
      //

      public const int WIA_COMPRESSION_NONE = 0;
      public const int WIA_COMPRESSION_BI_RLE4 = 1;
      public const int WIA_COMPRESSION_BI_RLE8 = 2;
      public const int WIA_COMPRESSION_G3 = 3;
      public const int WIA_COMPRESSION_G4 = 4;
      public const int WIA_COMPRESSION_JPEG = 5;
      public const int WIA_COMPRESSION_JBIG = 6;
      public const int WIA_COMPRESSION_JPEG2K = 7;
      public const int WIA_COMPRESSION_PNG = 8;
      public const int WIA_COMPRESSION_AUTO = 100;

      //
      // WIA_IPA_PLANAR constants
      //

      public const int WIA_PACKED_PIXEL = 0;
      public const int WIA_PLANAR = 1;

      //
      // WIA_IPA_DATATYPE constants
      //

      public const int WIA_DATA_THRESHOLD = 0;
      public const int WIA_DATA_DITHER = 1;
      public const int WIA_DATA_GRAYSCALE = 2;
      public const int WIA_DATA_COLOR = 3;
      public const int WIA_DATA_COLOR_THRESHOLD = 4;
      public const int WIA_DATA_COLOR_DITHER = 5;
      public const int WIA_DATA_RAW_RGB = 6;
      public const int WIA_DATA_RAW_BGR = 7;
      public const int WIA_DATA_RAW_YUV = 8;
      public const int WIA_DATA_RAW_YUVK = 9;
      public const int WIA_DATA_RAW_CMY = 10;
      public const int WIA_DATA_RAW_CMYK = 11;
      public const int WIA_DATA_AUTO = 100;

      //
      // WIA_IPS_PHOTOMETRIC_INTERP constants
      //

      /// <summary>
      /// WHITE is 1, and BLACK is 0.
      /// </summary>
      public const int WIA_PHOTO_WHITE_1 = 0; // white is 1, black is 0
      /// <summary>
      /// WHITE is 0, and BLACK is 1.
      /// </summary>
      public const int WIA_PHOTO_WHITE_0 = 1; // white is 0, black is 1

      //
      // WIA_IPA_SUPPRESS_PROPERTY_PAGE flags
      //

      public const int WIA_PROPPAGE_SCANNER_ITEM_GENERAL = 0x00000001;
      public const int WIA_PROPPAGE_CAMERA_ITEM_GENERAL = 0x00000002;
      public const int WIA_PROPPAGE_DEVICE_GENERAL = 0x00000004;

      //
      // WIA_IPS_CUR_INTENT flags
      //
      /// <summary>
      /// Default value. No intent is specified.
      /// </summary>
      public const int WIA_INTENT_NONE = 0x00000000;
      /// <summary>
      /// The application intends to prepare the device for a color scan.
      /// </summary>
      public const int WIA_INTENT_IMAGE_TYPE_COLOR = 0x00000001;
      /// <summary>
      /// The application intends to prepare the device for a grayscale scan.
      /// </summary>
      public const int WIA_INTENT_IMAGE_TYPE_GRAYSCALE = 0x00000002;
      /// <summary>
      /// The application intends to prepare the device for scanning text.
      /// </summary>
      public const int WIA_INTENT_IMAGE_TYPE_TEXT = 0x00000004;
      /// <summary>
      /// Mask for all of the image-type flags.
      /// </summary>
      public const int WIA_INTENT_IMAGE_TYPE_MASK = 0x0000000F;

      /// <summary>
      /// The application intends to prepare the device for scanning an image that result's in a small scan.
      /// </summary>
      public const int WIA_INTENT_MINIMIZE_SIZE = 0x00010000;
      /// <summary>
      /// The application intends to prepare the device for scanning a high-quality image.
      /// </summary>
      public const int WIA_INTENT_MAXIMIZE_QUALITY = 0x00020000;
      /// <summary>
      /// This flag is a mask for all of the size/quality flags.
      /// </summary>
      public const int WIA_INTENT_BEST_PREVIEW = 0x00040000;
      /// <summary>
      /// The application intends to prepare the device for scanning a preview.
      /// </summary>
      public const int WIA_INTENT_SIZE_MASK = 0x000F0000;

      //
      // Global WIA device information property arrays
      //

      public const int WIA_NUM_DIP = 16;

   }
}
