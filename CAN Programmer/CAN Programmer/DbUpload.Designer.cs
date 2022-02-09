namespace CAN_Programmer
{
    partial class DbUpload
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
            this.DataPort = new System.IO.Ports.SerialPort(this.components);
            this.LFilesState = new DevComponents.DotNetBar.LabelX();
            this.CBID = new System.Windows.Forms.ComboBox();
            this.CBClass = new System.Windows.Forms.ComboBox();
            this.LabelX6 = new DevComponents.DotNetBar.LabelX();
            this.LabelX5 = new DevComponents.DotNetBar.LabelX();
            this.LBlkStatus = new DevComponents.DotNetBar.LabelX();
            this.LabelX4 = new DevComponents.DotNetBar.LabelX();
            this.LFname = new DevComponents.DotNetBar.LabelX();
            this.LabelX3 = new DevComponents.DotNetBar.LabelX();
            this.LabelX2 = new DevComponents.DotNetBar.LabelX();
            this.TBFnames = new DevComponents.DotNetBar.Controls.TextBoxX();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.OpenFile = new System.Windows.Forms.OpenFileDialog();
            this.PBar1 = new System.Windows.Forms.ProgressBar();
            this.PBar2 = new System.Windows.Forms.ProgressBar();
            this.BBrowse = new System.Windows.Forms.Button();
            this.BUpdate = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // DataPort
            // 
            this.DataPort.ReadTimeout = 5;
            // 
            // LFilesState
            // 
            // 
            // 
            // 
            this.LFilesState.BackgroundStyle.Class = "";
            this.LFilesState.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LFilesState.Location = new System.Drawing.Point(130, 216);
            this.LFilesState.Name = "LFilesState";
            this.LFilesState.Size = new System.Drawing.Size(517, 23);
            this.LFilesState.TabIndex = 35;
            this.LFilesState.Text = "File Name";
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
            this.CBID.Location = new System.Drawing.Point(653, 37);
            this.CBID.Name = "CBID";
            this.CBID.Size = new System.Drawing.Size(80, 21);
            this.CBID.TabIndex = 34;
            // 
            // CBClass
            // 
            this.CBClass.FormattingEnabled = true;
            this.CBClass.Items.AddRange(new object[] {
            "MMI",
            "CC"});
            this.CBClass.Location = new System.Drawing.Point(514, 37);
            this.CBClass.Name = "CBClass";
            this.CBClass.Size = new System.Drawing.Size(80, 21);
            this.CBClass.TabIndex = 33;
            this.CBClass.SelectedIndexChanged += new System.EventHandler(this.CBClass_SelectedIndexChanged);
            // 
            // LabelX6
            // 
            // 
            // 
            // 
            this.LabelX6.BackgroundStyle.Class = "";
            this.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX6.Location = new System.Drawing.Point(628, 37);
            this.LabelX6.Name = "LabelX6";
            this.LabelX6.Size = new System.Drawing.Size(19, 23);
            this.LabelX6.TabIndex = 32;
            this.LabelX6.Text = "ID";
            // 
            // LabelX5
            // 
            // 
            // 
            // 
            this.LabelX5.BackgroundStyle.Class = "";
            this.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX5.Location = new System.Drawing.Point(475, 37);
            this.LabelX5.Name = "LabelX5";
            this.LabelX5.Size = new System.Drawing.Size(33, 23);
            this.LabelX5.TabIndex = 31;
            this.LabelX5.Text = "Class";
            // 
            // LBlkStatus
            // 
            // 
            // 
            // 
            this.LBlkStatus.BackgroundStyle.Class = "";
            this.LBlkStatus.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LBlkStatus.Location = new System.Drawing.Point(130, 164);
            this.LBlkStatus.Name = "LBlkStatus";
            this.LBlkStatus.Size = new System.Drawing.Size(517, 23);
            this.LBlkStatus.TabIndex = 28;
            this.LBlkStatus.Text = "File Name";
            // 
            // LabelX4
            // 
            // 
            // 
            // 
            this.LabelX4.BackgroundStyle.Class = "";
            this.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX4.Location = new System.Drawing.Point(63, 135);
            this.LabelX4.Name = "LabelX4";
            this.LabelX4.Size = new System.Drawing.Size(61, 23);
            this.LabelX4.TabIndex = 27;
            this.LabelX4.Text = "File Name";
            // 
            // LFname
            // 
            // 
            // 
            // 
            this.LFname.BackgroundStyle.Class = "";
            this.LFname.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LFname.Location = new System.Drawing.Point(130, 135);
            this.LFname.Name = "LFname";
            this.LFname.Size = new System.Drawing.Size(517, 23);
            this.LFname.TabIndex = 26;
            this.LFname.Text = "File Status";
            // 
            // LabelX3
            // 
            // 
            // 
            // 
            this.LabelX3.BackgroundStyle.Class = "";
            this.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX3.Location = new System.Drawing.Point(42, 245);
            this.LabelX3.Name = "LabelX3";
            this.LabelX3.Size = new System.Drawing.Size(82, 23);
            this.LabelX3.TabIndex = 25;
            this.LabelX3.Text = "Over all Status";
            // 
            // LabelX2
            // 
            // 
            // 
            // 
            this.LabelX2.BackgroundStyle.Class = "";
            this.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX2.Location = new System.Drawing.Point(63, 187);
            this.LabelX2.Name = "LabelX2";
            this.LabelX2.Size = new System.Drawing.Size(61, 23);
            this.LabelX2.TabIndex = 24;
            this.LabelX2.Text = "File Status";
            // 
            // TBFnames
            // 
            // 
            // 
            // 
            this.TBFnames.Border.Class = "TextBoxBorder";
            this.TBFnames.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.TBFnames.Enabled = false;
            this.TBFnames.Location = new System.Drawing.Point(85, 67);
            this.TBFnames.Name = "TBFnames";
            this.TBFnames.Size = new System.Drawing.Size(255, 20);
            this.TBFnames.TabIndex = 21;
            // 
            // LabelX1
            // 
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.Class = "";
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.Location = new System.Drawing.Point(85, 37);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(92, 23);
            this.LabelX1.TabIndex = 20;
            this.LabelX1.Text = "Browse for files";
            // 
            // OpenFile
            // 
            this.OpenFile.FileName = "OpenFile";
            this.OpenFile.Multiselect = true;
            // 
            // PBar1
            // 
            this.PBar1.Location = new System.Drawing.Point(130, 193);
            this.PBar1.Name = "PBar1";
            this.PBar1.Size = new System.Drawing.Size(350, 17);
            this.PBar1.TabIndex = 66;
            // 
            // PBar2
            // 
            this.PBar2.Location = new System.Drawing.Point(130, 251);
            this.PBar2.Name = "PBar2";
            this.PBar2.Size = new System.Drawing.Size(350, 17);
            this.PBar2.TabIndex = 67;
            // 
            // BBrowse
            // 
            this.BBrowse.Location = new System.Drawing.Point(346, 64);
            this.BBrowse.Name = "BBrowse";
            this.BBrowse.Size = new System.Drawing.Size(75, 23);
            this.BBrowse.TabIndex = 68;
            this.BBrowse.Text = "Browse";
            this.BBrowse.UseVisualStyleBackColor = true;
            this.BBrowse.Click += new System.EventHandler(this.BBrowse_Click);
            // 
            // BUpdate
            // 
            this.BUpdate.Location = new System.Drawing.Point(130, 286);
            this.BUpdate.Name = "BUpdate";
            this.BUpdate.Size = new System.Drawing.Size(75, 23);
            this.BUpdate.TabIndex = 69;
            this.BUpdate.Text = "Upload";
            this.BUpdate.UseVisualStyleBackColor = true;
            this.BUpdate.Click += new System.EventHandler(this.BUpdate_Click);
            // 
            // BCancel
            // 
            this.BCancel.Location = new System.Drawing.Point(211, 286);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(75, 23);
            this.BCancel.TabIndex = 70;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // DbUpload
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 354);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.BUpdate);
            this.Controls.Add(this.BBrowse);
            this.Controls.Add(this.PBar2);
            this.Controls.Add(this.PBar1);
            this.Controls.Add(this.LFilesState);
            this.Controls.Add(this.CBID);
            this.Controls.Add(this.CBClass);
            this.Controls.Add(this.LabelX6);
            this.Controls.Add(this.LabelX5);
            this.Controls.Add(this.LBlkStatus);
            this.Controls.Add(this.LabelX4);
            this.Controls.Add(this.LFname);
            this.Controls.Add(this.LabelX3);
            this.Controls.Add(this.LabelX2);
            this.Controls.Add(this.TBFnames);
            this.Controls.Add(this.LabelX1);
            this.Name = "DbUpload";
            this.Text = "DbUpload";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DbUpload_FormClosing);
            this.Load += new System.EventHandler(this.DbUpload_Load);
            this.ResumeLayout(false);

        }

        private void DbUpload_FormClosed(object sender, System.Windows.Forms.FormClosedEventArgs e)
        {
            throw new System.NotImplementedException();
        }

        #endregion

        internal System.IO.Ports.SerialPort DataPort;
        internal DevComponents.DotNetBar.LabelX LFilesState;
        internal System.Windows.Forms.ComboBox CBID;
        internal System.Windows.Forms.ComboBox CBClass;
        internal DevComponents.DotNetBar.LabelX LabelX6;
        internal DevComponents.DotNetBar.LabelX LabelX5;
        internal DevComponents.DotNetBar.LabelX LBlkStatus;
        internal DevComponents.DotNetBar.LabelX LabelX4;
        internal DevComponents.DotNetBar.LabelX LFname;
        internal DevComponents.DotNetBar.LabelX LabelX3;
        internal DevComponents.DotNetBar.LabelX LabelX2;
        internal DevComponents.DotNetBar.Controls.TextBoxX TBFnames;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal System.Windows.Forms.OpenFileDialog OpenFile;
        private System.Windows.Forms.ProgressBar PBar1;
        private System.Windows.Forms.ProgressBar PBar2;
        private System.Windows.Forms.Button BBrowse;
        private System.Windows.Forms.Button BUpdate;
        private System.Windows.Forms.Button BCancel;
    }
}