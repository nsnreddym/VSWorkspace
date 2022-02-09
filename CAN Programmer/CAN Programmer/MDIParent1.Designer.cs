namespace CAN_Programmer
{
    partial class MDIParent1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MDIParent1));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.StripStatusPort = new System.Windows.Forms.ToolStripStatusLabel();
            this.StripStatusBaud = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.databaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.downloadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eraseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.softwareToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uploadToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.versionRequestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.diagnosisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deviceResetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.displayTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.audioTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.TsUpld = new System.Windows.Forms.ToolStripButton();
            this.TsDwnld = new System.Windows.Forms.ToolStripButton();
            this.TsStatus = new System.Windows.Forms.ToolStripButton();
            this.TsErase = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.TsExprtPDF = new System.Windows.Forms.ToolStripButton();
            this.TsExprtExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.TsRst = new System.Windows.Forms.ToolStripButton();
            this.TsDspTst = new System.Windows.Forms.ToolStripButton();
            this.TsAudTst = new System.Windows.Forms.ToolStripButton();
            this.TsNWTst = new System.Windows.Forms.ToolStripButton();
            this.DataPort = new System.IO.Ports.SerialPort(this.components);
            this.statusStrip.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StripStatusPort,
            this.StripStatusBaud});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // StripStatusPort
            // 
            this.StripStatusPort.Name = "StripStatusPort";
            this.StripStatusPort.Size = new System.Drawing.Size(13, 17);
            this.StripStatusPort.Text = "0";
            // 
            // StripStatusBaud
            // 
            this.StripStatusBaud.Name = "StripStatusBaud";
            this.StripStatusBaud.Size = new System.Drawing.Size(13, 17);
            this.StripStatusBaud.Text = "0";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(30, 30);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.databaseToolStripMenuItem,
            this.softwareToolStripMenuItem,
            this.diagnosisToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 6;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // databaseToolStripMenuItem
            // 
            this.databaseToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadToolStripMenuItem,
            this.downloadToolStripMenuItem,
            this.statusToolStripMenuItem,
            this.eraseToolStripMenuItem});
            this.databaseToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.databaseToolStripMenuItem.Name = "databaseToolStripMenuItem";
            this.databaseToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.databaseToolStripMenuItem.Text = "Database";
            // 
            // uploadToolStripMenuItem
            // 
            this.uploadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("uploadToolStripMenuItem.Image")));
            this.uploadToolStripMenuItem.Name = "uploadToolStripMenuItem";
            this.uploadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.U)));
            this.uploadToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.uploadToolStripMenuItem.Text = "Upload";
            this.uploadToolStripMenuItem.Click += new System.EventHandler(this.uploadToolStripMenuItem_Click);
            // 
            // downloadToolStripMenuItem
            // 
            this.downloadToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("downloadToolStripMenuItem.Image")));
            this.downloadToolStripMenuItem.Name = "downloadToolStripMenuItem";
            this.downloadToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.D)));
            this.downloadToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.downloadToolStripMenuItem.Text = "Download";
            // 
            // statusToolStripMenuItem
            // 
            this.statusToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("statusToolStripMenuItem.Image")));
            this.statusToolStripMenuItem.Name = "statusToolStripMenuItem";
            this.statusToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.S)));
            this.statusToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.statusToolStripMenuItem.Text = "Status";
            this.statusToolStripMenuItem.Click += new System.EventHandler(this.statusToolStripMenuItem_Click);
            // 
            // eraseToolStripMenuItem
            // 
            this.eraseToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("eraseToolStripMenuItem.Image")));
            this.eraseToolStripMenuItem.Name = "eraseToolStripMenuItem";
            this.eraseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.E)));
            this.eraseToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.eraseToolStripMenuItem.Text = "Erase";
            this.eraseToolStripMenuItem.Click += new System.EventHandler(this.eraseToolStripMenuItem_Click);
            // 
            // softwareToolStripMenuItem
            // 
            this.softwareToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uploadToolStripMenuItem1,
            this.versionRequestToolStripMenuItem});
            this.softwareToolStripMenuItem.Name = "softwareToolStripMenuItem";
            this.softwareToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.softwareToolStripMenuItem.Text = "Software";
            // 
            // uploadToolStripMenuItem1
            // 
            this.uploadToolStripMenuItem1.Image = ((System.Drawing.Image)(resources.GetObject("uploadToolStripMenuItem1.Image")));
            this.uploadToolStripMenuItem1.Name = "uploadToolStripMenuItem1";
            this.uploadToolStripMenuItem1.Size = new System.Drawing.Size(169, 36);
            this.uploadToolStripMenuItem1.Text = "Upload";
            this.uploadToolStripMenuItem1.Click += new System.EventHandler(this.uploadToolStripMenuItem1_Click);
            // 
            // versionRequestToolStripMenuItem
            // 
            this.versionRequestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("versionRequestToolStripMenuItem.Image")));
            this.versionRequestToolStripMenuItem.Name = "versionRequestToolStripMenuItem";
            this.versionRequestToolStripMenuItem.Size = new System.Drawing.Size(169, 36);
            this.versionRequestToolStripMenuItem.Text = "Version request";
            // 
            // diagnosisToolStripMenuItem
            // 
            this.diagnosisToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deviceResetToolStripMenuItem,
            this.displayTestToolStripMenuItem,
            this.audioTestToolStripMenuItem,
            this.networkTestToolStripMenuItem});
            this.diagnosisToolStripMenuItem.Name = "diagnosisToolStripMenuItem";
            this.diagnosisToolStripMenuItem.Size = new System.Drawing.Size(70, 20);
            this.diagnosisToolStripMenuItem.Text = "Diagnosis";
            // 
            // deviceResetToolStripMenuItem
            // 
            this.deviceResetToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deviceResetToolStripMenuItem.Image")));
            this.deviceResetToolStripMenuItem.Name = "deviceResetToolStripMenuItem";
            this.deviceResetToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.deviceResetToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.deviceResetToolStripMenuItem.Text = "Device Reset";
            this.deviceResetToolStripMenuItem.Click += new System.EventHandler(this.deviceResetToolStripMenuItem_Click);
            // 
            // displayTestToolStripMenuItem
            // 
            this.displayTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("displayTestToolStripMenuItem.Image")));
            this.displayTestToolStripMenuItem.Name = "displayTestToolStripMenuItem";
            this.displayTestToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F9;
            this.displayTestToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.displayTestToolStripMenuItem.Text = "Display Test";
            this.displayTestToolStripMenuItem.Click += new System.EventHandler(this.displayTestToolStripMenuItem_Click);
            // 
            // audioTestToolStripMenuItem
            // 
            this.audioTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("audioTestToolStripMenuItem.Image")));
            this.audioTestToolStripMenuItem.Name = "audioTestToolStripMenuItem";
            this.audioTestToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.audioTestToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.audioTestToolStripMenuItem.Text = "Audio Test";
            this.audioTestToolStripMenuItem.Click += new System.EventHandler(this.audioTestToolStripMenuItem_Click);
            // 
            // networkTestToolStripMenuItem
            // 
            this.networkTestToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("networkTestToolStripMenuItem.Image")));
            this.networkTestToolStripMenuItem.Name = "networkTestToolStripMenuItem";
            this.networkTestToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.networkTestToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.networkTestToolStripMenuItem.Text = "Network test";
            this.networkTestToolStripMenuItem.Click += new System.EventHandler(this.networkTestToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.comPortToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // comPortToolStripMenuItem
            // 
            this.comPortToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("comPortToolStripMenuItem.Image")));
            this.comPortToolStripMenuItem.Name = "comPortToolStripMenuItem";
            this.comPortToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.comPortToolStripMenuItem.Text = "Com Port";
            this.comPortToolStripMenuItem.Click += new System.EventHandler(this.comPortToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.aboutToolStripMenuItem.Text = "About";
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TsUpld,
            this.TsDwnld,
            this.TsStatus,
            this.TsErase,
            this.toolStripSeparator1,
            this.TsExprtPDF,
            this.TsExprtExcel,
            this.toolStripSeparator3,
            this.TsRst,
            this.TsDspTst,
            this.TsAudTst,
            this.TsNWTst});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 39);
            this.toolStrip1.TabIndex = 8;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // TsUpld
            // 
            this.TsUpld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsUpld.Image = ((System.Drawing.Image)(resources.GetObject("TsUpld.Image")));
            this.TsUpld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsUpld.Name = "TsUpld";
            this.TsUpld.Size = new System.Drawing.Size(36, 36);
            this.TsUpld.Text = "DataBaseUpload";
            this.TsUpld.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.TsUpld.Click += new System.EventHandler(this.TsUpld_Click);
            // 
            // TsDwnld
            // 
            this.TsDwnld.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsDwnld.Image = ((System.Drawing.Image)(resources.GetObject("TsDwnld.Image")));
            this.TsDwnld.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsDwnld.Name = "TsDwnld";
            this.TsDwnld.Size = new System.Drawing.Size(36, 36);
            this.TsDwnld.Text = "DataBaseDownload";
            // 
            // TsStatus
            // 
            this.TsStatus.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsStatus.Image = ((System.Drawing.Image)(resources.GetObject("TsStatus.Image")));
            this.TsStatus.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsStatus.Name = "TsStatus";
            this.TsStatus.Size = new System.Drawing.Size(36, 36);
            this.TsStatus.Text = "DataBase Status";
            this.TsStatus.Click += new System.EventHandler(this.TsStatus_Click);
            // 
            // TsErase
            // 
            this.TsErase.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsErase.Image = ((System.Drawing.Image)(resources.GetObject("TsErase.Image")));
            this.TsErase.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsErase.Name = "TsErase";
            this.TsErase.Size = new System.Drawing.Size(36, 36);
            this.TsErase.Text = "DataBase Erase";
            this.TsErase.Click += new System.EventHandler(this.TsErase_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // TsExprtPDF
            // 
            this.TsExprtPDF.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsExprtPDF.Image = ((System.Drawing.Image)(resources.GetObject("TsExprtPDF.Image")));
            this.TsExprtPDF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsExprtPDF.Name = "TsExprtPDF";
            this.TsExprtPDF.Size = new System.Drawing.Size(36, 36);
            this.TsExprtPDF.Text = "toolStripButton12";
            this.TsExprtPDF.Visible = false;
            // 
            // TsExprtExcel
            // 
            this.TsExprtExcel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsExprtExcel.Image = ((System.Drawing.Image)(resources.GetObject("TsExprtExcel.Image")));
            this.TsExprtExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsExprtExcel.Name = "TsExprtExcel";
            this.TsExprtExcel.Size = new System.Drawing.Size(36, 36);
            this.TsExprtExcel.Text = "toolStripButton11";
            this.TsExprtExcel.Visible = false;
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // TsRst
            // 
            this.TsRst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsRst.Image = ((System.Drawing.Image)(resources.GetObject("TsRst.Image")));
            this.TsRst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsRst.Name = "TsRst";
            this.TsRst.Size = new System.Drawing.Size(36, 36);
            this.TsRst.Text = "Device Reset";
            this.TsRst.Click += new System.EventHandler(this.TsRst_Click);
            // 
            // TsDspTst
            // 
            this.TsDspTst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsDspTst.Image = ((System.Drawing.Image)(resources.GetObject("TsDspTst.Image")));
            this.TsDspTst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsDspTst.Name = "TsDspTst";
            this.TsDspTst.Size = new System.Drawing.Size(36, 36);
            this.TsDspTst.Text = "Display Test";
            this.TsDspTst.Click += new System.EventHandler(this.TsDspTst_Click);
            // 
            // TsAudTst
            // 
            this.TsAudTst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsAudTst.Image = ((System.Drawing.Image)(resources.GetObject("TsAudTst.Image")));
            this.TsAudTst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsAudTst.Name = "TsAudTst";
            this.TsAudTst.Size = new System.Drawing.Size(36, 36);
            this.TsAudTst.Text = "Audio Test";
            this.TsAudTst.Click += new System.EventHandler(this.TsAudTst_Click);
            // 
            // TsNWTst
            // 
            this.TsNWTst.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.TsNWTst.Image = ((System.Drawing.Image)(resources.GetObject("TsNWTst.Image")));
            this.TsNWTst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TsNWTst.Name = "TsNWTst";
            this.TsNWTst.Size = new System.Drawing.Size(36, 36);
            this.TsNWTst.Text = "Network Test";
            this.TsNWTst.Click += new System.EventHandler(this.TsNWTst_Click);
            // 
            // MDIParent1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MDIParent1";
            this.Text = "CAN Programmer";
            this.Load += new System.EventHandler(this.MDIParent1_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
        private System.Windows.Forms.StatusStrip statusStrip;
        public System.Windows.Forms.ToolStripStatusLabel StripStatusPort;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem databaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem downloadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem statusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eraseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem softwareToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uploadToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem versionRequestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem diagnosisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deviceResetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem displayTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem audioTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem comPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton TsUpld;
        private System.Windows.Forms.ToolStripButton TsDwnld;
        private System.Windows.Forms.ToolStripButton TsStatus;
        private System.Windows.Forms.ToolStripButton TsErase;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton TsExprtPDF;
        private System.Windows.Forms.ToolStripButton TsExprtExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton TsRst;
        private System.Windows.Forms.ToolStripButton TsDspTst;
        private System.Windows.Forms.ToolStripButton TsAudTst;
        private System.Windows.Forms.ToolStripButton TsNWTst;
        private System.IO.Ports.SerialPort DataPort;
        public System.Windows.Forms.ToolStripStatusLabel StripStatusBaud;
    }
}



