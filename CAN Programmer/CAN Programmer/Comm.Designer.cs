namespace CAN_Programmer
{
    partial class Comm
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
            this.CBPorts = new System.Windows.Forms.ComboBox();
            this.LabelX5 = new DevComponents.DotNetBar.LabelX();
            this.LabelX4 = new DevComponents.DotNetBar.LabelX();
            this.CDataBits = new System.Windows.Forms.ComboBox();
            this.LabelX3 = new DevComponents.DotNetBar.LabelX();
            this.CParity = new System.Windows.Forms.ComboBox();
            this.LabelX2 = new DevComponents.DotNetBar.LabelX();
            this.CStopBits = new System.Windows.Forms.ComboBox();
            this.LabelX1 = new DevComponents.DotNetBar.LabelX();
            this.CBaudRates = new System.Windows.Forms.ComboBox();
            this.BSave = new System.Windows.Forms.Button();
            this.BCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CBPorts
            // 
            this.CBPorts.FormattingEnabled = true;
            this.CBPorts.Location = new System.Drawing.Point(162, 24);
            this.CBPorts.Name = "CBPorts";
            this.CBPorts.Size = new System.Drawing.Size(121, 21);
            this.CBPorts.TabIndex = 23;
            // 
            // LabelX5
            // 
            // 
            // 
            // 
            this.LabelX5.BackgroundStyle.Class = "";
            this.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX5.Location = new System.Drawing.Point(81, 22);
            this.LabelX5.Name = "LabelX5";
            this.LabelX5.Size = new System.Drawing.Size(75, 23);
            this.LabelX5.TabIndex = 22;
            this.LabelX5.Text = "COM Port";
            // 
            // LabelX4
            // 
            // 
            // 
            // 
            this.LabelX4.BackgroundStyle.Class = "";
            this.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX4.Location = new System.Drawing.Point(81, 179);
            this.LabelX4.Name = "LabelX4";
            this.LabelX4.Size = new System.Drawing.Size(75, 23);
            this.LabelX4.TabIndex = 19;
            this.LabelX4.Text = "DataBits";
            // 
            // CDataBits
            // 
            this.CDataBits.FormattingEnabled = true;
            this.CDataBits.Items.AddRange(new object[] {
            "8",
            "9"});
            this.CDataBits.Location = new System.Drawing.Point(162, 181);
            this.CDataBits.Name = "CDataBits";
            this.CDataBits.Size = new System.Drawing.Size(121, 21);
            this.CDataBits.TabIndex = 18;
            // 
            // LabelX3
            // 
            // 
            // 
            // 
            this.LabelX3.BackgroundStyle.Class = "";
            this.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX3.Location = new System.Drawing.Point(81, 137);
            this.LabelX3.Name = "LabelX3";
            this.LabelX3.Size = new System.Drawing.Size(75, 23);
            this.LabelX3.TabIndex = 17;
            this.LabelX3.Text = "Parity";
            // 
            // CParity
            // 
            this.CParity.FormattingEnabled = true;
            this.CParity.Items.AddRange(new object[] {
            "No",
            "Even",
            "Odd"});
            this.CParity.Location = new System.Drawing.Point(162, 139);
            this.CParity.Name = "CParity";
            this.CParity.Size = new System.Drawing.Size(121, 21);
            this.CParity.TabIndex = 16;
            // 
            // LabelX2
            // 
            // 
            // 
            // 
            this.LabelX2.BackgroundStyle.Class = "";
            this.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX2.Location = new System.Drawing.Point(81, 99);
            this.LabelX2.Name = "LabelX2";
            this.LabelX2.Size = new System.Drawing.Size(75, 23);
            this.LabelX2.TabIndex = 15;
            this.LabelX2.Text = "StopBits";
            // 
            // CStopBits
            // 
            this.CStopBits.FormattingEnabled = true;
            this.CStopBits.Items.AddRange(new object[] {
            "1",
            "2"});
            this.CStopBits.Location = new System.Drawing.Point(162, 101);
            this.CStopBits.Name = "CStopBits";
            this.CStopBits.Size = new System.Drawing.Size(121, 21);
            this.CStopBits.TabIndex = 14;
            // 
            // LabelX1
            // 
            // 
            // 
            // 
            this.LabelX1.BackgroundStyle.Class = "";
            this.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.LabelX1.Location = new System.Drawing.Point(81, 63);
            this.LabelX1.Name = "LabelX1";
            this.LabelX1.Size = new System.Drawing.Size(75, 23);
            this.LabelX1.TabIndex = 13;
            this.LabelX1.Text = "Baudrate";
            // 
            // CBaudRates
            // 
            this.CBaudRates.FormattingEnabled = true;
            this.CBaudRates.Location = new System.Drawing.Point(162, 65);
            this.CBaudRates.Name = "CBaudRates";
            this.CBaudRates.Size = new System.Drawing.Size(121, 21);
            this.CBaudRates.TabIndex = 12;
            // 
            // BSave
            // 
            this.BSave.Location = new System.Drawing.Point(115, 221);
            this.BSave.Name = "BSave";
            this.BSave.Size = new System.Drawing.Size(75, 26);
            this.BSave.TabIndex = 24;
            this.BSave.Text = "Save";
            this.BSave.UseVisualStyleBackColor = true;
            this.BSave.Click += new System.EventHandler(this.BSave_Click);
            // 
            // BCancel
            // 
            this.BCancel.Location = new System.Drawing.Point(226, 221);
            this.BCancel.Name = "BCancel";
            this.BCancel.Size = new System.Drawing.Size(75, 26);
            this.BCancel.TabIndex = 25;
            this.BCancel.Text = "Cancel";
            this.BCancel.UseVisualStyleBackColor = true;
            this.BCancel.Click += new System.EventHandler(this.BCancel_Click);
            // 
            // Comm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 275);
            this.Controls.Add(this.BCancel);
            this.Controls.Add(this.BSave);
            this.Controls.Add(this.CBPorts);
            this.Controls.Add(this.LabelX5);
            this.Controls.Add(this.LabelX4);
            this.Controls.Add(this.CDataBits);
            this.Controls.Add(this.LabelX3);
            this.Controls.Add(this.CParity);
            this.Controls.Add(this.LabelX2);
            this.Controls.Add(this.CStopBits);
            this.Controls.Add(this.LabelX1);
            this.Controls.Add(this.CBaudRates);
            this.Name = "Comm";
            this.Text = "Comm";
            this.Load += new System.EventHandler(this.Comm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.ComboBox CBPorts;
        internal DevComponents.DotNetBar.LabelX LabelX5;
        internal DevComponents.DotNetBar.LabelX LabelX4;
        internal System.Windows.Forms.ComboBox CDataBits;
        internal DevComponents.DotNetBar.LabelX LabelX3;
        internal System.Windows.Forms.ComboBox CParity;
        internal DevComponents.DotNetBar.LabelX LabelX2;
        internal System.Windows.Forms.ComboBox CStopBits;
        internal DevComponents.DotNetBar.LabelX LabelX1;
        internal System.Windows.Forms.ComboBox CBaudRates;
        private System.Windows.Forms.Button BSave;
        private System.Windows.Forms.Button BCancel;
    }
}