namespace CAN_Programmer
{
    partial class FlashErase
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
            this.CBID = new System.Windows.Forms.ComboBox();
            this.CBClass = new System.Windows.Forms.ComboBox();
            this.LabelX6 = new DevComponents.DotNetBar.LabelX();
            this.LabelX5 = new DevComponents.DotNetBar.LabelX();
            this.LStatus = new System.Windows.Forms.Label();
            this.PBar1 = new System.Windows.Forms.ProgressBar();
            this.BUpdate = new System.Windows.Forms.Button();
            this.DataPort = new System.IO.Ports.SerialPort(this.components);
            this.SuspendLayout();
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
            "18"});
            this.CBID.Location = new System.Drawing.Point(224, 12);
            this.CBID.Name = "CBID";
            this.CBID.Size = new System.Drawing.Size(80, 21);
            this.CBID.TabIndex = 28;
            // 
            // CBClass
            // 
            this.CBClass.FormattingEnabled = true;
            this.CBClass.Items.AddRange(new object[] {
            "MMI",
            "CC"});
            this.CBClass.Location = new System.Drawing.Point(85, 12);
            this.CBClass.Name = "CBClass";
            this.CBClass.Size = new System.Drawing.Size(80, 21);
            this.CBClass.TabIndex = 27;
            // 
            // LabelX6
            // 
            // 
            // 
            // 
            this.LabelX6.BackgroundStyle.Class = "";
            this.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX6.Location = new System.Drawing.Point(199, 12);
            this.LabelX6.Name = "LabelX6";
            this.LabelX6.Size = new System.Drawing.Size(19, 23);
            this.LabelX6.TabIndex = 26;
            this.LabelX6.Text = "ID";
            // 
            // LabelX5
            // 
            // 
            // 
            // 
            this.LabelX5.BackgroundStyle.Class = "";
            this.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX5.Location = new System.Drawing.Point(46, 12);
            this.LabelX5.Name = "LabelX5";
            this.LabelX5.Size = new System.Drawing.Size(33, 23);
            this.LabelX5.TabIndex = 25;
            this.LabelX5.Text = "Class";
            // 
            // LStatus
            // 
            this.LStatus.AutoSize = true;
            this.LStatus.Location = new System.Drawing.Point(43, 117);
            this.LStatus.Name = "LStatus";
            this.LStatus.Size = new System.Drawing.Size(111, 13);
            this.LStatus.TabIndex = 23;
            this.LStatus.Text = "Erasing Please Wait...";
            // 
            // PBar1
            // 
            this.PBar1.Location = new System.Drawing.Point(46, 133);
            this.PBar1.Name = "PBar1";
            this.PBar1.Size = new System.Drawing.Size(350, 17);
            this.PBar1.TabIndex = 67;
            // 
            // BUpdate
            // 
            this.BUpdate.Location = new System.Drawing.Point(46, 60);
            this.BUpdate.Name = "BUpdate";
            this.BUpdate.Size = new System.Drawing.Size(75, 23);
            this.BUpdate.TabIndex = 69;
            this.BUpdate.Text = "Start";
            this.BUpdate.UseVisualStyleBackColor = true;
            this.BUpdate.Click += new System.EventHandler(this.BUpdate_Click);
            // 
            // FlashErase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(794, 355);
            this.Controls.Add(this.BUpdate);
            this.Controls.Add(this.PBar1);
            this.Controls.Add(this.CBID);
            this.Controls.Add(this.CBClass);
            this.Controls.Add(this.LabelX6);
            this.Controls.Add(this.LabelX5);
            this.Controls.Add(this.LStatus);
            this.Name = "FlashErase";
            this.Text = "FlashErase";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FlashErase_FormClosing);
            this.Load += new System.EventHandler(this.FlashErase_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        internal System.Windows.Forms.ComboBox CBID;
        internal System.Windows.Forms.ComboBox CBClass;
        internal DevComponents.DotNetBar.LabelX LabelX6;
        internal DevComponents.DotNetBar.LabelX LabelX5;
        internal System.Windows.Forms.Label LStatus;
        private System.Windows.Forms.ProgressBar PBar1;
        private System.Windows.Forms.Button BUpdate;
        private System.IO.Ports.SerialPort DataPort;
    }
}