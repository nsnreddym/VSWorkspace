namespace CAN_Programmer
{
    partial class SWUpload
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
            this.BBrowse = new System.Windows.Forms.Button();
            this.CBID = new System.Windows.Forms.ComboBox();
            this.CBClass = new System.Windows.Forms.ComboBox();
            this.LabelX6 = new DevComponents.DotNetBar.LabelX();
            this.LabelX5 = new DevComponents.DotNetBar.LabelX();
            this.TBFnames = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.BCancel = new System.Windows.Forms.Button();
            this.BUpdate = new System.Windows.Forms.Button();
            this.PBar1 = new System.Windows.Forms.ProgressBar();
            this.LBlkStatus = new DevComponents.DotNetBar.LabelX();
            this.LabelX3 = new DevComponents.DotNetBar.LabelX();
            this.BReboot = new System.Windows.Forms.Button();
            this.DataPort = new System.IO.Ports.SerialPort(this.components);
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // BBrowse
            // 
            this.BBrowse.Location = new System.Drawing.Point(315, 49);
            this.BBrowse.Name = "BBrowse";
            this.BBrowse.Size = new System.Drawing.Size(75, 23);
            this.BBrowse.TabIndex = 75;
            this.BBrowse.Text = "Browse";
            this.BBrowse.UseVisualStyleBackColor = true;
            this.BBrowse.Click += new System.EventHandler(this.BBrowse_Click);
            // 
            // CBID
            // 
            this.CBID.FormattingEnabled = true;
            this.CBID.Items.AddRange(new object[] {
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
            "16",
            "17",
            "18",
            "19",
            "20",
            "21",
            "BroadCast"});
            this.CBID.Location = new System.Drawing.Point(622, 22);
            this.CBID.Name = "CBID";
            this.CBID.Size = new System.Drawing.Size(80, 21);
            this.CBID.TabIndex = 74;
            // 
            // CBClass
            // 
            this.CBClass.FormattingEnabled = true;
            this.CBClass.Items.AddRange(new object[] {
            "MMI",
            "CC"});
            this.CBClass.Location = new System.Drawing.Point(483, 22);
            this.CBClass.Name = "CBClass";
            this.CBClass.Size = new System.Drawing.Size(80, 21);
            this.CBClass.TabIndex = 73;
            // 
            // LabelX6
            // 
            // 
            // 
            // 
            this.LabelX6.BackgroundStyle.Class = "";
            this.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX6.Location = new System.Drawing.Point(597, 22);
            this.LabelX6.Name = "LabelX6";
            this.LabelX6.Size = new System.Drawing.Size(19, 23);
            this.LabelX6.TabIndex = 72;
            this.LabelX6.Text = "ID";
            // 
            // LabelX5
            // 
            // 
            // 
            // 
            this.LabelX5.BackgroundStyle.Class = "";
            this.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX5.Location = new System.Drawing.Point(444, 22);
            this.LabelX5.Name = "LabelX5";
            this.LabelX5.Size = new System.Drawing.Size(33, 23);
            this.LabelX5.TabIndex = 71;
            this.LabelX5.Text = "Class";
            // 
            // TBFnames
            // 
            // 
            // 
            // 
            this.TBFnames.Border.Class = "TextBoxBorder";
            this.TBFnames.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TBFnames.Enabled = false;
            this.TBFnames.Location = new System.Drawing.Point(54, 52);
            this.TBFnames.Name = "TBFnames";
            this.TBFnames.Size = new System.Drawing.Size(255, 20);
            this.TBFnames.TabIndex = 70;
            // 
            // LabelX1
            // 
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.Class = "";
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.Location = new System.Drawing.Point(54, 22);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(92, 23);
            this.LabelX1.TabIndex = 69;
            this.LabelX1.Text = "Browse for files";
            // 
            // BCancel
            // 
            this.BCancel.Location = new System.Drawing.Point(226, 166);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(75, 23);
            this.BCancel.TabIndex = 80;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // BUpdate
            // 
            this.BUpdate.Location = new System.Drawing.Point(145, 166);
            this.BUpdate.Name = "BUpdate";
            this.BUpdate.Size = new System.Drawing.Size(75, 23);
            this.BUpdate.TabIndex = 79;
            this.BUpdate.Text = "Upload";
            this.BUpdate.UseVisualStyleBackColor = true;
            this.BUpdate.Click += new System.EventHandler(this.BUpdate_Click);
            // 
            // PBar1
            // 
            this.PBar1.Location = new System.Drawing.Point(145, 131);
            this.PBar1.Name = "PBar1";
            this.PBar1.Size = new System.Drawing.Size(350, 17);
            this.PBar1.TabIndex = 78;
            // 
            // LBlkStatus
            // 
            // 
            // 
            // 
            this.LBlkStatus.BackgroundStyle.Class = "";
            this.LBlkStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBlkStatus.Location = new System.Drawing.Point(145, 96);
            this.LBlkStatus.Name = "LBlkStatus";
            this.LBlkStatus.Size = new System.Drawing.Size(517, 23);
            this.LBlkStatus.TabIndex = 77;
            this.LBlkStatus.Text = "File Name";
            // 
            // LabelX3
            // 
            // 
            // 
            // 
            this.LabelX3.BackgroundStyle.Class = "";
            this.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX3.Location = new System.Drawing.Point(57, 125);
            this.LabelX3.Name = "LabelX3";
            this.LabelX3.Size = new System.Drawing.Size(82, 23);
            this.LabelX3.TabIndex = 76;
            this.LabelX3.Text = "Over all Status";
            // 
            // BReboot
            // 
            this.BReboot.Location = new System.Drawing.Point(315, 166);
            this.BReboot.Name = "BReboot";
            this.BReboot.Size = new System.Drawing.Size(75, 23);
            this.BReboot.TabIndex = 81;
            this.BReboot.Text = "Reboot";
            this.BReboot.UseVisualStyleBackColor = true;
            this.BReboot.Click += new System.EventHandler(this.BReboot_Click);
            // 
            // DataPort
            // 
            this.DataPort.ReadTimeout = 5;
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "OpenFile";
            // 
            // SWUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 311);
            this.Controls.Add(this.BReboot);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.BUpdate);
            this.Controls.Add(this.PBar1);
            this.Controls.Add(this.LBlkStatus);
            this.Controls.Add(this.LabelX3);
            this.Controls.Add(this.BBrowse);
            this.Controls.Add(this.CBID);
            this.Controls.Add(this.CBClass);
            this.Controls.Add(this.LabelX6);
            this.Controls.Add(this.LabelX5);
            this.Controls.Add(this.TBFnames);
            this.Controls.Add(this.LabelX1);
            this.Name = "SWUpload";
            this.Text = "SWUpload";
            this.Load += new System.EventHandler(this.SWUpload_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BBrowse;
        internal System.Windows.Forms.ComboBox CBID;
        internal System.Windows.Forms.ComboBox CBClass;
        internal DevComponents.DotNetBar.LabelX LabelX6;
        internal DevComponents.DotNetBar.LabelX LabelX5;
        internal DevComponents.DotNetBar.Controls.TextBoxX TBFnames;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        private System.Windows.Forms.Button BCancel;
        private System.Windows.Forms.Button BUpdate;
        private System.Windows.Forms.ProgressBar PBar1;
        internal DevComponents.DotNetBar.LabelX LBlkStatus;
        internal DevComponents.DotNetBar.LabelX LabelX3;
        private System.Windows.Forms.Button BReboot;
        internal System.IO.Ports.SerialPort DataPort;
        internal System.Windows.Forms.OpenFileDialog OpenFile;
    }
}