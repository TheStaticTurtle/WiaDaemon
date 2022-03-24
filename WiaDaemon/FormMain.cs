using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NetExplorerClient;
using WIA;
using WiaDaemon.Properties;

namespace WiaDaemon {
	public partial class FormMain : Form {
		WiaScannerManager t = null;
		
		public FormMain() {
			InitializeComponent();
		}
		
		private void FormConfig_Load(object sender, EventArgs e) {
			textBoxOutputFolder.Text = Utils.FormatEnvironment(Settings.Default.OutputFolder);
			textBoxSelectDevice.Text = Settings.Default.ScannerDeviceID;
			t                        = new WiaScannerManager();
			t.ChangeUuid(Settings.Default.ScannerDeviceID.Split(new[]{" @ "}, StringSplitOptions.None)[1]);
			labelStatus.Text = t.GetScannerStatus().ToString();
		}
		
		private void FormConfig_closing(object sender, CancelEventArgs e) {
			if (this.Visible) {
				this.Visible = false;
				e.Cancel     = true;
			}
		}

		private void buttonSelectDevice_Click(object sender, EventArgs e) {
			WIA.Device device = WiaScanner.GetDeviceFromDialog();
			if (device != null) {
				string uuid = device.Properties.get_Item("Unique Device ID").get_Value() as string;
				string name = device.Properties.get_Item("Name").get_Value() as string;
				Settings.Default.ScannerDeviceID = $"{name} @ {uuid}";
				Settings.Default.Save();
				Settings.Default.Upgrade();
				textBoxSelectDevice.Text = Settings.Default.ScannerDeviceID;
			}
		}

		private void buttonSelectOutputFolder_Click(object sender, EventArgs e) {
			var dialog = folderBrowserDialog1.ShowDialog();
			if (dialog == DialogResult.OK) {
				textBoxOutputFolder.Text      = folderBrowserDialog1.SelectedPath;
				Settings.Default.OutputFolder = folderBrowserDialog1.SelectedPath;
				Settings.Default.Save();
				Settings.Default.Upgrade();
			}
		}

		private void timer1_Tick(object sender, EventArgs e) {
			WiaScannerManager.WiaScannerStatus scannerStatus = t.GetScannerStatus();
			labelStatus.Text = scannerStatus.ToString();
			if (scannerStatus == WiaScannerManager.WiaScannerStatus.Ready) {
				try {
					Device device = t.GetDevice();

					labelName.Text = device.Properties.get_Item("Name").get_Value() as string;
					labelDeviceID.Text = device.Properties.get_Item("Unique Device ID").get_Value() as string;
					labelPort.Text = device.Properties.get_Item("Port").get_Value() as string;
					labelDriver.Text = device.Properties.get_Item("Driver Version").get_Value() as string;

					String path = Path.Combine(Settings.Default.OutputFolder, DateTime.Now.ToString("Scan_dd-MM-yyyy_HH-mm-ss.ffff"));
					Utils.File outFile = new Utils.File(path+".png");
					WiaScanner.ScanOne(
									   device,
									   outFile,
									   WiaScanQuality.Final,
									   WiaPageSize.A4,
									   wiaFormat: WiaFormat.Png);

					Utils.OpenWithDefaultProgram(outFile.FullPath);
				}
				catch (WiaException err) {
					if(err.Message.Contains("There are no documents in the scanner")) return;
					if(err.Message.Contains("Scanner is busy")) return;
					timer1.Enabled = false;
					MessageBox.Show(err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					timer1.Enabled = true;
				} catch (Exception err) {
					timer1.Enabled = false;
					MessageBox.Show($"Unknown error:\n{err.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					timer1.Enabled = true;
				}
			}
		}

		private void toolStripMenuItemExit_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e) {
			this.Visible = true;
		}
	}
}