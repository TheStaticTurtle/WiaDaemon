using System;
using NetExplorerClient;

namespace WiaDaemon {
	public class WiaScannerManager {
		public enum WiaScannerStatus {
			NoDeviceSelected,
			Disconnected,
			Ready,
			Errored,
		}
		
		string deviceUUID = null;

		public void ChangeUuid(string newUuid) {
			deviceUUID = newUuid;
		}

		public WiaScannerStatus GetScannerStatus() {
			if (deviceUUID == null) return WiaScannerStatus.NoDeviceSelected;
			
			WIA.Device device = WiaScanner.GetDeviceFromUuid(deviceUUID);
			if (device == null) return WiaScannerStatus.Disconnected;
			
			return WiaScannerStatus.Ready;
		}
		
		
		public WIA.Device GetDevice() {
			return WiaScanner.GetDeviceFromUuid(deviceUUID);
		}
	}
}