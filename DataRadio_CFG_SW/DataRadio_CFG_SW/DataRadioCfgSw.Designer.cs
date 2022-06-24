namespace DataRadio_CFG_SW
{
    partial class DataRadioCfgSw
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DataRadioCfgSw));
            this.ribbon1 = new System.Windows.Forms.Ribbon();
            this.ChannelsTab = new System.Windows.Forms.RibbonTab();
            this.rpLink = new System.Windows.Forms.RibbonPanel();
            this.bComPort = new System.Windows.Forms.RibbonButton();
            this.ribbonButton2 = new System.Windows.Forms.RibbonButton();
            this.ribbonSeparator1 = new System.Windows.Forms.RibbonSeparator();
            this.ribbonLabel1 = new System.Windows.Forms.RibbonLabel();
            this.bComStatus = new System.Windows.Forms.RibbonButton();
            this.rpChannel = new System.Windows.Forms.RibbonPanel();
            this.Prg_ch = new System.Windows.Forms.RibbonButton();
            this.Read_Ch = new System.Windows.Forms.RibbonButton();
            this.Factory_Reset = new System.Windows.Forms.RibbonButton();
            this.rpMemory = new System.Windows.Forms.RibbonPanel();
            this.ribbonLabel2 = new System.Windows.Forms.RibbonLabel();
            this.bFlashRead = new System.Windows.Forms.RibbonButton();
            this.rpStatus = new System.Windows.Forms.RibbonPanel();
            this.rbRxSynth = new System.Windows.Forms.RibbonButton();
            this.rbTxSynth = new System.Windows.Forms.RibbonButton();
            this.rbRSSI = new System.Windows.Forms.RibbonLabel();
            this.rbTxPwr = new System.Windows.Forms.RibbonLabel();
            this.SettingsTab = new System.Windows.Forms.RibbonTab();
            this.ribbonPanel1 = new System.Windows.Forms.RibbonPanel();
            this.Settings = new System.Windows.Forms.RibbonButton();
            this.ribbonButtonList1 = new System.Windows.Forms.RibbonButtonList();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.COM_SL = new System.Windows.Forms.ToolStripStatusLabel();
            this.PortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Baudrate_SL = new System.Windows.Forms.ToolStripStatusLabel();
            this.BaudValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.Status_Pbar = new System.Windows.Forms.ToolStripProgressBar();
            this.ribbonPanel3 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel6 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel7 = new System.Windows.Forms.RibbonPanel();
            this.ribbonPanel5 = new System.Windows.Forms.RibbonPanel();
            this.cbSector = new System.Windows.Forms.ComboBox();
            this.ribbonDescriptionMenuItem1 = new System.Windows.Forms.RibbonDescriptionMenuItem();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon1
            // 
            this.ribbon1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ribbon1.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.Minimized = false;
            this.ribbon1.Name = "ribbon1";
            // 
            // 
            // 
            this.ribbon1.OrbDropDown.BorderRoundness = 8;
            this.ribbon1.OrbDropDown.Enabled = false;
            this.ribbon1.OrbDropDown.Location = new System.Drawing.Point(0, 0);
            this.ribbon1.OrbDropDown.Name = "";
            this.ribbon1.OrbDropDown.Size = new System.Drawing.Size(527, 72);
            this.ribbon1.OrbDropDown.TabIndex = 0;
            this.ribbon1.OrbVisible = false;
            // 
            // 
            // 
            this.ribbon1.QuickAccessToolbar.Visible = false;
            this.ribbon1.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
            this.ribbon1.Size = new System.Drawing.Size(800, 154);
            this.ribbon1.TabIndex = 0;
            this.ribbon1.Tabs.Add(this.ChannelsTab);
            this.ribbon1.Tabs.Add(this.SettingsTab);
            this.ribbon1.Text = "ribbon1";
            this.ribbon1.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
            // 
            // ChannelsTab
            // 
            this.ChannelsTab.Name = "ChannelsTab";
            this.ChannelsTab.Panels.Add(this.rpLink);
            this.ChannelsTab.Panels.Add(this.rpChannel);
            this.ChannelsTab.Panels.Add(this.rpMemory);
            this.ChannelsTab.Panels.Add(this.rpStatus);
            this.ChannelsTab.Text = "Channels";
            // 
            // rpLink
            // 
            this.rpLink.Items.Add(this.bComPort);
            this.rpLink.Items.Add(this.ribbonSeparator1);
            this.rpLink.Items.Add(this.ribbonLabel1);
            this.rpLink.Items.Add(this.bComStatus);
            this.rpLink.Name = "rpLink";
            this.rpLink.Tag = "";
            this.rpLink.Text = "Link";
            // 
            // bComPort
            // 
            this.bComPort.DropDownItems.Add(this.ribbonButton2);
            this.bComPort.Image = global::DataRadio_CFG_SW.Properties.Resources.Start;
            this.bComPort.LargeImage = global::DataRadio_CFG_SW.Properties.Resources.Start;
            this.bComPort.Name = "bComPort";
            this.bComPort.SmallImage = global::DataRadio_CFG_SW.Properties.Resources.Start;
            this.bComPort.Text = "Open";
            this.bComPort.DoubleClick += new System.EventHandler(this.bComPort_DoubleClick);
            this.bComPort.Click += new System.EventHandler(this.bComPort_Click);
            // 
            // ribbonButton2
            // 
            this.ribbonButton2.Image = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.Image")));
            this.ribbonButton2.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.LargeImage")));
            this.ribbonButton2.Name = "ribbonButton2";
            this.ribbonButton2.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonButton2.SmallImage")));
            this.ribbonButton2.Text = "ribbonButton2";
            // 
            // ribbonSeparator1
            // 
            this.ribbonSeparator1.Name = "ribbonSeparator1";
            // 
            // ribbonLabel1
            // 
            this.ribbonLabel1.Name = "ribbonLabel1";
            this.ribbonLabel1.Text = "Status";
            // 
            // bComStatus
            // 
            this.bComStatus.Image = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.bComStatus.LargeImage = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.bComStatus.Name = "bComStatus";
            this.bComStatus.SmallImage = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.bComStatus.Text = "IDLE";
            // 
            // rpChannel
            // 
            this.rpChannel.Items.Add(this.Prg_ch);
            this.rpChannel.Items.Add(this.Read_Ch);
            this.rpChannel.Items.Add(this.Factory_Reset);
            this.rpChannel.Name = "rpChannel";
            this.rpChannel.Text = "Channels";
            // 
            // Prg_ch
            // 
            this.Prg_ch.Image = global::DataRadio_CFG_SW.Properties.Resources.Upload;
            this.Prg_ch.LargeImage = global::DataRadio_CFG_SW.Properties.Resources.Upload;
            this.Prg_ch.Name = "Prg_ch";
            this.Prg_ch.SmallImage = global::DataRadio_CFG_SW.Properties.Resources.Upload;
            this.Prg_ch.Text = "Program";
            this.Prg_ch.Value = "";
            this.Prg_ch.Click += new System.EventHandler(this.Prg_ch_Click);
            // 
            // Read_Ch
            // 
            this.Read_Ch.Image = global::DataRadio_CFG_SW.Properties.Resources.Download;
            this.Read_Ch.LargeImage = global::DataRadio_CFG_SW.Properties.Resources.Download;
            this.Read_Ch.Name = "Read_Ch";
            this.Read_Ch.SmallImage = global::DataRadio_CFG_SW.Properties.Resources.Download;
            this.Read_Ch.Text = "Read";
            this.Read_Ch.Value = "";
            this.Read_Ch.Click += new System.EventHandler(this.Read_Ch_Click);
            // 
            // Factory_Reset
            // 
            this.Factory_Reset.Image = global::DataRadio_CFG_SW.Properties.Resources.ButtonReload;
            this.Factory_Reset.LargeImage = global::DataRadio_CFG_SW.Properties.Resources.ButtonReload;
            this.Factory_Reset.Name = "Factory_Reset";
            this.Factory_Reset.SmallImage = global::DataRadio_CFG_SW.Properties.Resources.ButtonReload;
            this.Factory_Reset.Text = "Default";
            this.Factory_Reset.Click += new System.EventHandler(this.Factory_Reset_Click);
            // 
            // rpMemory
            // 
            this.rpMemory.Items.Add(this.ribbonLabel2);
            this.rpMemory.Items.Add(this.bFlashRead);
            this.rpMemory.Name = "rpMemory";
            this.rpMemory.Text = "Memory";
            // 
            // ribbonLabel2
            // 
            this.ribbonLabel2.Name = "ribbonLabel2";
            this.ribbonLabel2.Text = "Sector";
            // 
            // bFlashRead
            // 
            this.bFlashRead.Image = global::DataRadio_CFG_SW.Properties.Resources.memory;
            this.bFlashRead.LargeImage = global::DataRadio_CFG_SW.Properties.Resources.memory;
            this.bFlashRead.Name = "bFlashRead";
            this.bFlashRead.SmallImage = global::DataRadio_CFG_SW.Properties.Resources.memory;
            this.bFlashRead.Text = "Read";
            this.bFlashRead.Click += new System.EventHandler(this.FlashRead_Click);
            // 
            // rpStatus
            // 
            this.rpStatus.Items.Add(this.rbRxSynth);
            this.rpStatus.Items.Add(this.rbTxSynth);
            this.rpStatus.Items.Add(this.rbRSSI);
            this.rpStatus.Items.Add(this.rbTxPwr);
            this.rpStatus.Name = "rpStatus";
            this.rpStatus.Text = "Status";
            // 
            // rbRxSynth
            // 
            this.rbRxSynth.Image = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.rbRxSynth.LargeImage = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.rbRxSynth.Name = "rbRxSynth";
            this.rbRxSynth.SmallImage = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.rbRxSynth.Text = "Synth-Rx";
            // 
            // rbTxSynth
            // 
            this.rbTxSynth.Image = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.rbTxSynth.LargeImage = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.rbTxSynth.Name = "rbTxSynth";
            this.rbTxSynth.SmallImage = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.rbTxSynth.Text = "Synth-Tx";
            // 
            // rbRSSI
            // 
            this.rbRSSI.Name = "rbRSSI";
            this.rbRSSI.Text = "RSSI:  0 dBm";
            // 
            // rbTxPwr
            // 
            this.rbTxPwr.Name = "rbTxPwr";
            this.rbTxPwr.Text = "Tx-Power:  0 W";
            // 
            // SettingsTab
            // 
            this.SettingsTab.Name = "SettingsTab";
            this.SettingsTab.Panels.Add(this.ribbonPanel1);
            this.SettingsTab.Text = "Settings";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.Items.Add(this.Settings);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Text = "Load & Read";
            // 
            // Settings
            // 
            this.Settings.Image = global::DataRadio_CFG_SW.Properties.Resources.settings;
            this.Settings.LargeImage = global::DataRadio_CFG_SW.Properties.Resources.settings;
            this.Settings.Name = "Settings";
            this.Settings.SmallImage = global::DataRadio_CFG_SW.Properties.Resources.settings;
            this.Settings.Text = "Settings";
            this.Settings.Click += new System.EventHandler(this.Settings_Click);
            // 
            // ribbonButtonList1
            // 
            this.ribbonButtonList1.ButtonsSizeMode = System.Windows.Forms.RibbonElementSizeMode.Large;
            this.ribbonButtonList1.FlowToBottom = false;
            this.ribbonButtonList1.ItemsSizeInDropwDownMode = new System.Drawing.Size(7, 5);
            this.ribbonButtonList1.Name = "ribbonButtonList1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COM_SL,
            this.PortStatus,
            this.Baudrate_SL,
            this.BaudValue,
            this.Status_Pbar});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 5;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // COM_SL
            // 
            this.COM_SL.Name = "COM_SL";
            this.COM_SL.Size = new System.Drawing.Size(66, 17);
            this.COM_SL.Text = "COM Port: ";
            // 
            // PortStatus
            // 
            this.PortStatus.Name = "PortStatus";
            this.PortStatus.Size = new System.Drawing.Size(0, 17);
            // 
            // Baudrate_SL
            // 
            this.Baudrate_SL.Name = "Baudrate_SL";
            this.Baudrate_SL.Size = new System.Drawing.Size(54, 17);
            this.Baudrate_SL.Text = "Baudrate";
            // 
            // BaudValue
            // 
            this.BaudValue.Name = "BaudValue";
            this.BaudValue.Size = new System.Drawing.Size(0, 17);
            // 
            // Status_Pbar
            // 
            this.Status_Pbar.Name = "Status_Pbar";
            this.Status_Pbar.Size = new System.Drawing.Size(100, 16);
            // 
            // ribbonPanel3
            // 
            this.ribbonPanel3.Name = "ribbonPanel3";
            this.ribbonPanel3.Text = "Access";
            // 
            // ribbonPanel6
            // 
            this.ribbonPanel6.Name = "ribbonPanel6";
            this.ribbonPanel6.Text = "Access";
            // 
            // ribbonPanel7
            // 
            this.ribbonPanel7.Name = "ribbonPanel7";
            this.ribbonPanel7.Text = "Access";
            // 
            // ribbonPanel5
            // 
            this.ribbonPanel5.Name = "ribbonPanel5";
            this.ribbonPanel5.Text = "Access";
            // 
            // cbSector
            // 
            this.cbSector.FormattingEnabled = true;
            this.cbSector.Items.AddRange(new object[] {
            "0",
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            "11",
            "12",
            "13",
            "14",
            "15",
            "16"});
            this.cbSector.Location = new System.Drawing.Point(372, 106);
            this.cbSector.Name = "cbSector";
            this.cbSector.Size = new System.Drawing.Size(46, 21);
            this.cbSector.TabIndex = 7;
            // 
            // ribbonDescriptionMenuItem1
            // 
            this.ribbonDescriptionMenuItem1.DescriptionBounds = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.ribbonDescriptionMenuItem1.DropDownArrowDirection = System.Windows.Forms.RibbonArrowDirection.Left;
            this.ribbonDescriptionMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.Image")));
            this.ribbonDescriptionMenuItem1.LargeImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.LargeImage")));
            this.ribbonDescriptionMenuItem1.Name = "ribbonDescriptionMenuItem1";
            this.ribbonDescriptionMenuItem1.SmallImage = ((System.Drawing.Image)(resources.GetObject("ribbonDescriptionMenuItem1.SmallImage")));
            this.ribbonDescriptionMenuItem1.Text = "ribbonDescriptionMenuItem1";
            // 
            // DataRadioCfgSw
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.cbSector);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.ribbon1);
            this.IsMdiContainer = true;
            this.KeyPreview = true;
            this.Name = "DataRadioCfgSw";
            this.Text = "DataRadioCfgSw";
            this.Load += new System.EventHandler(this.DataRadioCfgSw_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion

        private System.Windows.Forms.Ribbon ribbon1;
        private System.Windows.Forms.RibbonTab SettingsTab;
        private System.Windows.Forms.RibbonPanel ribbonPanel1;
        private System.Windows.Forms.RibbonButton Settings;
        private System.Windows.Forms.RibbonTab ChannelsTab;
        private System.Windows.Forms.RibbonPanel rpChannel;
        private System.Windows.Forms.RibbonButton Prg_ch;
        private System.Windows.Forms.RibbonButtonList ribbonButtonList1;
        private System.Windows.Forms.RibbonButton Read_Ch;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel COM_SL;
        private System.Windows.Forms.ToolStripStatusLabel PortStatus;
        private System.Windows.Forms.ToolStripStatusLabel Baudrate_SL;
        private System.Windows.Forms.ToolStripStatusLabel BaudValue;
        private System.Windows.Forms.ToolStripProgressBar Status_Pbar;
        private System.Windows.Forms.RibbonPanel rpMemory;
        private System.Windows.Forms.RibbonButton bFlashRead;
        private System.Windows.Forms.RibbonPanel rpLink;
        private System.Windows.Forms.RibbonPanel ribbonPanel3;
        private System.Windows.Forms.RibbonPanel ribbonPanel6;
        private System.Windows.Forms.RibbonPanel ribbonPanel7;
        private System.Windows.Forms.RibbonPanel ribbonPanel5;
        private System.Windows.Forms.RibbonButton bComPort;
        private System.Windows.Forms.RibbonButton ribbonButton2;
        private System.Windows.Forms.RibbonLabel ribbonLabel1;
        private System.Windows.Forms.RibbonSeparator ribbonSeparator1;
        private System.Windows.Forms.RibbonDescriptionMenuItem ribbonDescriptionMenuItem1;
        private System.Windows.Forms.RibbonButton bComStatus;
        private System.Windows.Forms.RibbonLabel ribbonLabel2;
        private System.Windows.Forms.ComboBox cbSector;
        private System.Windows.Forms.RibbonButton Factory_Reset;
        private System.Windows.Forms.RibbonPanel rpStatus;
        private System.Windows.Forms.RibbonButton rbRxSynth;
        private System.Windows.Forms.RibbonButton rbTxSynth;
        private System.Windows.Forms.RibbonLabel rbRSSI;
        private System.Windows.Forms.RibbonLabel rbTxPwr;
    }
}