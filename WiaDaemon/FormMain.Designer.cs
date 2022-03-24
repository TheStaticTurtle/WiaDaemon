using System.ComponentModel;

namespace WiaDaemon {
	partial class FormMain {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if (disposing && (components != null)) {
				components.Dispose();
			}

			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
			this.groupBoxStatus           = new System.Windows.Forms.GroupBox();
			this.tableLayoutPanel1        = new System.Windows.Forms.TableLayoutPanel();
			this.labelDriver              = new System.Windows.Forms.Label();
			this.labelPort                = new System.Windows.Forms.Label();
			this.labelDeviceID            = new System.Windows.Forms.Label();
			this.labelName                = new System.Windows.Forms.Label();
			this.labelStatus              = new System.Windows.Forms.Label();
			this.label4                   = new System.Windows.Forms.Label();
			this.label1                   = new System.Windows.Forms.Label();
			this.label5                   = new System.Windows.Forms.Label();
			this.label3                   = new System.Windows.Forms.Label();
			this.label2                   = new System.Windows.Forms.Label();
			this.textBoxSelectDevice      = new System.Windows.Forms.TextBox();
			this.buttonSelectDevice       = new System.Windows.Forms.Button();
			this.buttonSelectOutputFolder = new System.Windows.Forms.Button();
			this.textBoxOutputFolder      = new System.Windows.Forms.TextBox();
			this.lable6                   = new System.Windows.Forms.Label();
			this.folderBrowserDialog1     = new System.Windows.Forms.FolderBrowserDialog();
			this.timer1                   = new System.Windows.Forms.Timer(this.components);
			this.notifyIcon1              = new System.Windows.Forms.NotifyIcon(this.components);
			this.contextMenuStrip1        = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.toolStripMenuItemExit    = new System.Windows.Forms.ToolStripMenuItem();
			this.groupBoxStatus.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBoxStatus
			// 
			this.groupBoxStatus.Anchor   = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.groupBoxStatus.AutoSize = true;
			this.groupBoxStatus.Controls.Add(this.tableLayoutPanel1);
			this.groupBoxStatus.Location = new System.Drawing.Point(12, 69);
			this.groupBoxStatus.Name     = "groupBoxStatus";
			this.groupBoxStatus.Size     = new System.Drawing.Size(589, 113);
			this.groupBoxStatus.TabIndex = 0;
			this.groupBoxStatus.TabStop  = false;
			this.groupBoxStatus.Text     = "Status";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 2;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.labelDriver,   1, 4);
			this.tableLayoutPanel1.Controls.Add(this.labelPort,     1, 3);
			this.tableLayoutPanel1.Controls.Add(this.labelDeviceID, 1, 2);
			this.tableLayoutPanel1.Controls.Add(this.labelName,     1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelStatus,   1, 0);
			this.tableLayoutPanel1.Controls.Add(this.label4,        0, 1);
			this.tableLayoutPanel1.Controls.Add(this.label1,        0, 0);
			this.tableLayoutPanel1.Controls.Add(this.label5,        0, 4);
			this.tableLayoutPanel1.Controls.Add(this.label3,        0, 3);
			this.tableLayoutPanel1.Controls.Add(this.label2,        0, 2);
			this.tableLayoutPanel1.Dock     = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
			this.tableLayoutPanel1.Name     = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 6;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size     = new System.Drawing.Size(583, 94);
			this.tableLayoutPanel1.TabIndex = 0;
			// 
			// labelDriver
			// 
			this.labelDriver.AutoSize  = true;
			this.labelDriver.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.labelDriver.Location  = new System.Drawing.Point(104, 68);
			this.labelDriver.Name      = "labelDriver";
			this.labelDriver.Padding   = new System.Windows.Forms.Padding(2);
			this.labelDriver.Size      = new System.Drawing.Size(476, 17);
			this.labelDriver.TabIndex  = 9;
			this.labelDriver.Text      = "-";
			this.labelDriver.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelPort
			// 
			this.labelPort.AutoSize  = true;
			this.labelPort.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.labelPort.Location  = new System.Drawing.Point(104, 51);
			this.labelPort.Name      = "labelPort";
			this.labelPort.Padding   = new System.Windows.Forms.Padding(2);
			this.labelPort.Size      = new System.Drawing.Size(476, 17);
			this.labelPort.TabIndex  = 8;
			this.labelPort.Text      = "-";
			this.labelPort.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelDeviceID
			// 
			this.labelDeviceID.AutoSize  = true;
			this.labelDeviceID.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.labelDeviceID.Location  = new System.Drawing.Point(104, 34);
			this.labelDeviceID.Name      = "labelDeviceID";
			this.labelDeviceID.Padding   = new System.Windows.Forms.Padding(2);
			this.labelDeviceID.Size      = new System.Drawing.Size(476, 17);
			this.labelDeviceID.TabIndex  = 7;
			this.labelDeviceID.Text      = "-";
			this.labelDeviceID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelName
			// 
			this.labelName.AutoSize  = true;
			this.labelName.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.labelName.Location  = new System.Drawing.Point(104, 17);
			this.labelName.Name      = "labelName";
			this.labelName.Padding   = new System.Windows.Forms.Padding(2);
			this.labelName.Size      = new System.Drawing.Size(476, 17);
			this.labelName.TabIndex  = 6;
			this.labelName.Text      = "-";
			this.labelName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// labelStatus
			// 
			this.labelStatus.AutoSize  = true;
			this.labelStatus.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.labelStatus.Location  = new System.Drawing.Point(104, 0);
			this.labelStatus.Name      = "labelStatus";
			this.labelStatus.Padding   = new System.Windows.Forms.Padding(2);
			this.labelStatus.Size      = new System.Drawing.Size(476, 17);
			this.labelStatus.TabIndex  = 5;
			this.labelStatus.Text      = "No";
			this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.AutoSize  = true;
			this.label4.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.label4.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label4.Location  = new System.Drawing.Point(3, 17);
			this.label4.Name      = "label4";
			this.label4.Padding   = new System.Windows.Forms.Padding(2);
			this.label4.Size      = new System.Drawing.Size(95, 17);
			this.label4.TabIndex  = 3;
			this.label4.Text      = "Name:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label1
			// 
			this.label1.AutoSize  = true;
			this.label1.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.label1.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label1.Location  = new System.Drawing.Point(3, 0);
			this.label1.Name      = "label1";
			this.label1.Padding   = new System.Windows.Forms.Padding(2);
			this.label1.Size      = new System.Drawing.Size(95, 17);
			this.label1.TabIndex  = 0;
			this.label1.Text      = "Connected:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.AutoSize  = true;
			this.label5.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.label5.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label5.Location  = new System.Drawing.Point(3, 68);
			this.label5.Name      = "label5";
			this.label5.Padding   = new System.Windows.Forms.Padding(2);
			this.label5.Size      = new System.Drawing.Size(95, 17);
			this.label5.TabIndex  = 4;
			this.label5.Text      = "Driver Version:";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label3
			// 
			this.label3.AutoSize  = true;
			this.label3.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.label3.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label3.Location  = new System.Drawing.Point(3, 51);
			this.label3.Name      = "label3";
			this.label3.Padding   = new System.Windows.Forms.Padding(2);
			this.label3.Size      = new System.Drawing.Size(95, 17);
			this.label3.TabIndex  = 2;
			this.label3.Text      = "Port:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label2
			// 
			this.label2.AutoSize  = true;
			this.label2.Dock      = System.Windows.Forms.DockStyle.Fill;
			this.label2.Font      = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
			this.label2.Location  = new System.Drawing.Point(3, 34);
			this.label2.Name      = "label2";
			this.label2.Padding   = new System.Windows.Forms.Padding(2);
			this.label2.Size      = new System.Drawing.Size(95, 17);
			this.label2.TabIndex  = 1;
			this.label2.Text      = "DeviceID:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// textBoxSelectDevice
			// 
			this.textBoxSelectDevice.Anchor   = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxSelectDevice.Location = new System.Drawing.Point(114, 14);
			this.textBoxSelectDevice.Name     = "textBoxSelectDevice";
			this.textBoxSelectDevice.ReadOnly = true;
			this.textBoxSelectDevice.Size     = new System.Drawing.Size(487, 20);
			this.textBoxSelectDevice.TabIndex = 1;
			// 
			// buttonSelectDevice
			// 
			this.buttonSelectDevice.Location                =  new System.Drawing.Point(12, 12);
			this.buttonSelectDevice.Name                    =  "buttonSelectDevice";
			this.buttonSelectDevice.Size                    =  new System.Drawing.Size(96, 23);
			this.buttonSelectDevice.TabIndex                =  2;
			this.buttonSelectDevice.Text                    =  "Select device";
			this.buttonSelectDevice.UseVisualStyleBackColor =  true;
			this.buttonSelectDevice.Click                   += new System.EventHandler(this.buttonSelectDevice_Click);
			// 
			// buttonSelectOutputFolder
			// 
			this.buttonSelectOutputFolder.Anchor                  =  ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonSelectOutputFolder.Location                =  new System.Drawing.Point(567, 40);
			this.buttonSelectOutputFolder.Name                    =  "buttonSelectOutputFolder";
			this.buttonSelectOutputFolder.Size                    =  new System.Drawing.Size(34, 23);
			this.buttonSelectOutputFolder.TabIndex                =  3;
			this.buttonSelectOutputFolder.Text                    =  "...";
			this.buttonSelectOutputFolder.UseVisualStyleBackColor =  true;
			this.buttonSelectOutputFolder.Click                   += new System.EventHandler(this.buttonSelectOutputFolder_Click);
			// 
			// textBoxOutputFolder
			// 
			this.textBoxOutputFolder.Anchor   = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
			this.textBoxOutputFolder.Location = new System.Drawing.Point(114, 42);
			this.textBoxOutputFolder.Name     = "textBoxOutputFolder";
			this.textBoxOutputFolder.Size     = new System.Drawing.Size(447, 20);
			this.textBoxOutputFolder.TabIndex = 4;
			// 
			// lable6
			// 
			this.lable6.Location  = new System.Drawing.Point(12, 42);
			this.lable6.Name      = "lable6";
			this.lable6.Size      = new System.Drawing.Size(96, 20);
			this.lable6.TabIndex  = 5;
			this.lable6.Text      = "Output folder";
			this.lable6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// timer1
			// 
			this.timer1.Enabled  =  true;
			this.timer1.Interval =  1000;
			this.timer1.Tick     += new System.EventHandler(this.timer1_Tick);
			// 
			// notifyIcon1
			// 
			this.notifyIcon1.ContextMenuStrip =  this.contextMenuStrip1;
			this.notifyIcon1.Icon             =  ((System.Drawing.Icon) (resources.GetObject("notifyIcon1.Icon")));
			this.notifyIcon1.Text             =  "WiaDaemon";
			this.notifyIcon1.Visible          =  true;
			this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.toolStripMenuItemExit});
			this.contextMenuStrip1.Name            = "contextMenuStrip1";
			this.contextMenuStrip1.ShowImageMargin = false;
			this.contextMenuStrip1.Size            = new System.Drawing.Size(128, 48);
			// 
			// toolStripMenuItemExit
			// 
			this.toolStripMenuItemExit.Name  =  "toolStripMenuItemExit";
			this.toolStripMenuItemExit.Size  =  new System.Drawing.Size(127, 22);
			this.toolStripMenuItemExit.Text  =  "Exit";
			this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode       = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize          = new System.Drawing.Size(613, 186);
			this.Controls.Add(this.lable6);
			this.Controls.Add(this.textBoxOutputFolder);
			this.Controls.Add(this.buttonSelectOutputFolder);
			this.Controls.Add(this.buttonSelectDevice);
			this.Controls.Add(this.textBoxSelectDevice);
			this.Controls.Add(this.groupBoxStatus);
			this.Icon        =  ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
			this.MaximumSize =  new System.Drawing.Size(65000, 225);
			this.Name        =  "FormMain";
			this.Text        =  "WiaDaemon - Status";
			this.Closing     += new System.ComponentModel.CancelEventHandler(this.FormConfig_closing);
			this.Load        += new System.EventHandler(this.FormConfig_Load);
			this.groupBoxStatus.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();
		}

		private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;

		private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;

		private System.Windows.Forms.NotifyIcon notifyIcon1;

		private System.Windows.Forms.Timer timer1;

		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;

		private System.Windows.Forms.Button  buttonSelectOutputFolder;
		private System.Windows.Forms.TextBox textBoxOutputFolder;
		private System.Windows.Forms.Label   lable6;

		private System.Windows.Forms.Label   labelStatus;
		private System.Windows.Forms.Label   labelName;
		private System.Windows.Forms.Label   labelDeviceID;
		private System.Windows.Forms.Label   labelPort;
		private System.Windows.Forms.Label   labelDriver;
		private System.Windows.Forms.TextBox textBoxSelectDevice;
		private System.Windows.Forms.Button  buttonSelectDevice;

		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;

		private System.Windows.Forms.Label label2;

		private System.Windows.Forms.Label label1;

		private System.Windows.Forms.GroupBox         groupBoxStatus;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;

		#endregion
	}
}