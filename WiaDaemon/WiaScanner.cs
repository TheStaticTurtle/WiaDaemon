using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using WIA;
using WiaDaemon;

namespace NetExplorerClient {
	
	public enum WiaError : uint {
		// https://docs.microsoft.com/en-us/windows/win32/wia/-wia-error-codes
		General                  = 0x80210001,
		PaperJam                 = 0x80210002,
		PaperEmpty               = 0x80210003,
		PaperProblem             = 0x80210004,
		Offline                  = 0x80210005,
		Busy                     = 0x80210006,
		WarmingUp                = 0x80210007,
		UserIntervention         = 0x80210008,
		ItemDeleted              = 0x80210009,
		DeviceCommunication      = 0x8021000A,
		InvalidCommand           = 0x8021000B,
		IncorrectHardwareSetting = 0x8021000C,
		DeviceLocked             = 0x8021000D,
		ExceptionInDriver        = 0x8021000E,
		InvalidDriverResponse    = 0x8021000F,
		
		NoDeviceAvailable             = 0x80210015,
		CoverOpen                     = 0x80210016,
		LampOff                       = 0x80210017,
		MultiFeed                     = 0x80210020,
		MaximumPrinterEndorserCounter = 0x80210021,
		
			
		YourError = 0x80210067
			
		//Destination = 18                     <Unknown>                 <Unknown>
		//NetworkReservationFailed = 19
		//WIAStatusEndOfMedia = 1
	}
	public enum WiaDeviceInfoProp {
		// https://msdn.microsoft.com/en-us/library/windows/desktop/ms630313(v=vs.85).aspx
		DeviceId     = 2,
		Manufacturer = 3,
		Description  = 4,
		Type         = 5,
		Port         = 6,
		Name         = 7,
		Server       = 8,
		RemoteDevId  = 9,
		UiClassId    = 10,
	}
	public enum WiaPageSize {
		// http://www.papersizes.org/a-paper-sizes.htm
		A4,     // 210 x 297 mm
		Letter, // 216 x 279 mm
		Legal,  // 216 x 356 mm
	}
	public enum WiaScanQuality {
		Final
	}
	public enum WiaDocumentSource {
		Feeder  = 1,
		Flatbed = 2
	}
	public enum WiaDpsDocumentHandlingSelect : uint {
		Feeder  = 0x00000001,
		Flatbed = 0x00000002,
	}
	public enum WiaDpsDocumentHandlingStatus : uint {
		DuplexerReady  = 0x00000000,
		FeedReady      = 0x00000001,
		FlatbedCovered = 0x00000002,
		FlatbedReady   = 0x00000003,
		PaperJammed    = 0x00000004
	}
	public static class WiaFormat {
		// https://docs.microsoft.com/en-us/previous-versions/windows/desktop/wiaaut/-wiaaut-consts-formatid
		public const string Bmp  = "{B96B3CAB-0728-11D3-9D7B-0000F81EF32E}";
		public const string Png  = "{B96B3CAF-0728-11D3-9D7B-0000F81EF32E}";
		public const string Gif  = "{B96B3CB0-0728-11D3-9D7B-0000F81EF32E}";
		public const string Jpeg = "{B96B3CAE-0728-11D3-9D7B-0000F81EF32E}";
		public const string Tiff = "{B96B3CB1-0728-11D3-9D7B-0000F81EF32E}";
	}
	public static class WiaProperty {
		public const string ScanColorMode               = "6146";
		public const string HorizontalScanResolutionDpi = "6147";
		public const string VerticalScanResolutionDpi   = "6148";
		public const string HorizontalScanStartPixel    = "6149";
		public const string VerticalScanStartPixel      = "6150";
		public const string HorizontalScanSizePixels    = "6151";
		public const string VerticalScanSizePixels      = "6152";
		public const string ScanBrightnessPercents      = "6154";
		public const string ScanContrastPercents        = "6155";
		public const string PagesId                     = "3096";
		public const string SourceSelectId              = "3088";
		
		
		public const uint WiaReservedForNewProps       = 1024;
		public const uint WiaDipFirst                  = 2;
		public const uint WiaDpaFirst                  = WiaDipFirst + WiaReservedForNewProps;
		public const uint WiaDpcFirst                  = WiaDpaFirst + WiaReservedForNewProps;
		public const uint WiaDpsFirst                  = WiaDpcFirst + WiaReservedForNewProps;
		public const uint WiaDpsDocumentHandlingStatus = WiaDpsFirst + 13;
		public const uint WiaDpsDocumentHandlingSelect = WiaDpsFirst + 14;
	}

	public class WiaException : Exception {
		public WiaException() { }
		public WiaException(string message) : base(message) { }
		public WiaException(string message, Exception inner) : base(message, inner) { }
	}
	
	public static class WiaScanner {
		
		public static List<DeviceInfo> GetDevices() {
			var devices = new List<DeviceInfo>();
			try {
				var deviceManager = new DeviceManager();

				foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos) {
					if(deviceInfo.Type != WiaDeviceType.ScannerDeviceType) continue;
					devices.Add(deviceInfo);
				}
			}
			catch (COMException e) {
				ThrowPrettyWiaException(e);
			}

			return devices;
		}
		public static Device GetDeviceFromName(string name) {
			try {
				var deviceManager = new DeviceManager();
			
				foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos) {
					if(deviceInfo.Type != WiaDeviceType.ScannerDeviceType) continue;
					if (name == deviceInfo.Properties.get_Item("Name").get_Value().ToString()) {
						return deviceInfo.Connect();
					}
				}
			}
			catch (COMException e) {
				ThrowPrettyWiaException(e);
			}
			return null;
		}
		public static Device GetDeviceFromUuid(string uuid) {
			try {
				var deviceManager = new DeviceManager();
			
				foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos) {
					if(deviceInfo.Type != WiaDeviceType.ScannerDeviceType) continue;
					if (uuid == deviceInfo.Properties.get_Item("Unique Device ID").get_Value().ToString()) {
						return deviceInfo.Connect();
					}
				}
			}
			catch (COMException e) {
				ThrowPrettyWiaException(e);
			}
			return null;
		}
		public static Device GetFirstDevice() {
			try {
				var deviceManager = new DeviceManager();
			
				foreach (DeviceInfo deviceInfo in deviceManager.DeviceInfos) {
					if(deviceInfo.Type != WiaDeviceType.ScannerDeviceType) continue;
					return deviceInfo.Connect();
				}
			}
			catch (COMException e) {
				ThrowPrettyWiaException(e);
			}
			return null;
		}
		public static Device GetDeviceFromDialog() {
			try {
				ICommonDialog dialog = new CommonDialog();
				return dialog.ShowSelectDevice(WiaDeviceType.ScannerDeviceType, true);
			}
			catch (COMException e) {
				ThrowPrettyWiaException(e);
				return null;
			}
		}

		
		private static void SetWiaProperty(IProperties properties, object propName, object propValue) {
			try {
				Property prop = properties.get_Item(ref propName);
				prop.set_Value(ref propValue);
			}
			catch (COMException e) {
				ThrowPrettyWiaException(e);
			}
		}

		private static void AdjustScannerSettings(IItem scanner, WiaScanQuality quality, WiaPageSize size, int brightnessPercents = 0, int contrastPercents = 0, int colorMode = 1)  {
			int dpi;
			int widthPixels;
			int heightPixels;
			switch (quality)
			{
				case WiaScanQuality.Final:
					dpi = 300;
					break;
				default:
					throw new Exception("Unknown WiaScanQuality: " + quality.ToString());
			}
			switch (size)
			{
				case WiaPageSize.A4:
					widthPixels  = (int)(8.3f  * dpi);
					heightPixels = (int)(11.7f * dpi);
					break;
				case WiaPageSize.Letter:
					widthPixels  = (int)(8.5f * dpi);
					heightPixels = (int)(11f  * dpi);
					break;
				case WiaPageSize.Legal:
					widthPixels  = (int)(8.5f * dpi);
					heightPixels = (int)(14f  * dpi);
					break;
				default:
					throw new Exception("Unknown WiaPageSize: " + size.ToString());
			}

			AdjustScannerSettings(scanner, dpi, 0, 0, widthPixels, heightPixels, brightnessPercents, contrastPercents, colorMode);
		}
		private static void AdjustScannerSettings(IItem scanner, int scanResolutionDpi, int scanStartLeftPixel, int scanStartTopPixel, int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode) {
			SetWiaProperty(scanner.Properties, WiaProperty.HorizontalScanResolutionDpi, scanResolutionDpi);
			SetWiaProperty(scanner.Properties, WiaProperty.VerticalScanResolutionDpi,   scanResolutionDpi);
			SetWiaProperty(scanner.Properties, WiaProperty.HorizontalScanStartPixel,    scanStartLeftPixel);
			SetWiaProperty(scanner.Properties, WiaProperty.VerticalScanStartPixel,      scanStartTopPixel);
			SetWiaProperty(scanner.Properties, WiaProperty.HorizontalScanSizePixels,    scanWidthPixels);
			SetWiaProperty(scanner.Properties, WiaProperty.VerticalScanSizePixels,      scanHeightPixels);
			SetWiaProperty(scanner.Properties, WiaProperty.ScanBrightnessPercents,      brightnessPercents);
			SetWiaProperty(scanner.Properties, WiaProperty.ScanContrastPercents,        contrastPercents);
			SetWiaProperty(scanner.Properties, WiaProperty.ScanColorMode,               colorMode);
		}
		
		public static void ScanOne(Device            device,
							       Utils.File        output_path,
								   WiaScanQuality    quality        = WiaScanQuality.Final,
								   WiaPageSize       pageSize       = WiaPageSize.A4,
								   WiaDocumentSource documentSource = WiaDocumentSource.Feeder,
								   String            wiaFormat      = WiaFormat.Bmp) {
			try {
				SetWiaProperty(device.Properties, WiaProperty.PagesId,        1);
				SetWiaProperty(device.Properties, WiaProperty.SourceSelectId, documentSource);
			
				Item item = device.Items[1];
			
				AdjustScannerSettings(item, quality, pageSize);
				
			
				//ICommonDialog wiaCommonDialog = new CommonDialog();
				//ImageFile     image           = wiaCommonDialog.ShowTransfer(item, wiaFormat);
				ImageFile     image           = item.Transfer(wiaFormat);
				
				image.SaveFile(output_path.FullPath);
			}
			catch (COMException e) {
				ThrowPrettyWiaException(e);
			}
		}

		private static void ThrowPrettyWiaException(COMException err) {
			if (!Enum.IsDefined(typeof(WiaError), (uint)err.HResult)) {
				throw new WiaException($"Unknown error, verify that the scanner is plugged in and started ({err.HResult}");
			}
			var error = (WiaError)err.HResult;

			switch (error) { 
				default:
				case WiaError.General:
					throw new WiaException("Unknown error, verify that the scanner is plugged in and started");
					
				case WiaError.PaperJam:
					throw new WiaException("Paper jam detected, please verify that nothing is stuck inside the scanner");
					
				case WiaError.PaperEmpty:
					throw new WiaException("There are no documents in the scanner.");
					
				case WiaError.PaperProblem:
					throw new WiaException("An unspecified problem occurred with the scanner's document feeder.");
					
				case WiaError.Offline:
					throw new WiaException("The scanner is offline. Make sure the device is powered on and connected to the PC.");
					
				case WiaError.Busy:
					throw new WiaException("Scanner is busy");
					
				case WiaError.WarmingUp:
					throw new WiaException("Please wait a few seconds, the scanner is warming up");
					
				case WiaError.UserIntervention:
					throw new WiaException("There is a problem with the scanner. Make sure that the it is turned on, online, and any cables are properly connected.");
					
				case WiaError.ItemDeleted:
					throw new WiaException("The WIA device was deleted. It's no longer available.");

				case WiaError.DeviceCommunication:
					throw new WiaException("Communication with the scanner failed. Make sure that the device is powered on and connected to the PC. If the problem persists, disconnect and reconnect the device. (DeviceCommunication)");
					
				case WiaError.InvalidCommand:
					throw new WiaException("Communication with the scanner failed. Make sure that the device is powered on and connected to the PC. If the problem persists, disconnect and reconnect the device. (InvalidCommand)");
					
				case WiaError.IncorrectHardwareSetting:
					throw new WiaException("Communication with the scanner failed. Make sure that the device is powered on and connected to the PC. If the problem persists, disconnect and reconnect the device. (IncorrectHardwareSetting)");
					
				case WiaError.DeviceLocked:
					throw new WiaException("The scanner is locked. Close any apps that are using this device or wait for it to finish and then try again.");
					
				case WiaError.ExceptionInDriver:
					throw new WiaException("Error while communicating with the scanner (ExceptionInDriver)");
					
				case WiaError.InvalidDriverResponse:
					throw new WiaException("Error while communicating with the scanner (InvalidDriverResponse)");
			
				case WiaError.CoverOpen:
					throw new WiaException("The cover of the scanner is open");
					
				case WiaError.NoDeviceAvailable:
					throw new WiaException("No scanner device was found. Make sure the device is online, connected to the PC."); //, and has the correct driver installed on the PC
					
				case WiaError.LampOff:
					throw new WiaException("The scanner's lamp is off.");

				case WiaError.YourError:
					throw new WiaException("User error");
					
				case WiaError.MaximumPrinterEndorserCounter:
					throw new WiaException("A scan job was interrupted because an Imprinter/Endorser item reached the maximum valid value for WIA_IPS_PRINTER_ENDORSER_COUNTER, and was reset to 0.");
					
				case WiaError.MultiFeed:
					throw new WiaException("A scan error occurred because of a multiple page feed condition.");
			}
		}
	}
}