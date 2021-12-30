namespace Spectrum_test
{
    partial class Settings
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
            this.IPadd = new System.Windows.Forms.GroupBox();
            this.bCancel = new System.Windows.Forms.Button();
            this.bSave = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tSWP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbSpan = new System.Windows.Forms.ComboBox();
            this.cbFreq = new System.Windows.Forms.ComboBox();
            this.cbSWT = new System.Windows.Forms.ComboBox();
            this.cbVBW = new System.Windows.Forms.ComboBox();
            this.cbRBW = new System.Windows.Forms.ComboBox();
            this.ip1 = new System.Windows.Forms.TextBox();
            this.tVBW = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tSpan = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tFreq = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tREF = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tSWT = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tRBW = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.IPadd.SuspendLayout();
            this.SuspendLayout();
            // 
            // IPadd
            // 
            this.IPadd.AutoSize = true;
            this.IPadd.BackColor = System.Drawing.SystemColors.Control;
            this.IPadd.Controls.Add(this.bCancel);
            this.IPadd.Controls.Add(this.bSave);
            this.IPadd.Controls.Add(this.label2);
            this.IPadd.Controls.Add(this.tSWP);
            this.IPadd.Controls.Add(this.label3);
            this.IPadd.Controls.Add(this.cbSpan);
            this.IPadd.Controls.Add(this.cbFreq);
            this.IPadd.Controls.Add(this.cbSWT);
            this.IPadd.Controls.Add(this.cbVBW);
            this.IPadd.Controls.Add(this.cbRBW);
            this.IPadd.Controls.Add(this.ip1);
            this.IPadd.Controls.Add(this.tVBW);
            this.IPadd.Controls.Add(this.label4);
            this.IPadd.Controls.Add(this.tSpan);
            this.IPadd.Controls.Add(this.label12);
            this.IPadd.Controls.Add(this.tFreq);
            this.IPadd.Controls.Add(this.label10);
            this.IPadd.Controls.Add(this.label7);
            this.IPadd.Controls.Add(this.tREF);
            this.IPadd.Controls.Add(this.label8);
            this.IPadd.Controls.Add(this.tSWT);
            this.IPadd.Controls.Add(this.label6);
            this.IPadd.Controls.Add(this.tRBW);
            this.IPadd.Controls.Add(this.label1);
            this.IPadd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.IPadd.Location = new System.Drawing.Point(0, 0);
            this.IPadd.Name = "IPadd";
            this.IPadd.Size = new System.Drawing.Size(1470, 450);
            this.IPadd.TabIndex = 9;
            this.IPadd.TabStop = false;
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(179, 289);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(88, 29);
            this.bCancel.TabIndex = 1;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(66, 289);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(88, 29);
            this.bSave.TabIndex = 35;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 33;
            this.label2.Text = "Device IP";
            // 
            // tSWP
            // 
            this.tSWP.Location = new System.Drawing.Point(66, 237);
            this.tSWP.Name = "tSWP";
            this.tSWP.Size = new System.Drawing.Size(76, 26);
            this.tSWP.TabIndex = 32;
            this.tSWP.Text = "3601";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 20);
            this.label3.TabIndex = 31;
            this.label3.Text = "SWP";
            // 
            // cbSpan
            // 
            this.cbSpan.FormattingEnabled = true;
            this.cbSpan.Items.AddRange(new object[] {
            "MHz",
            "KHz",
            "Hz"});
            this.cbSpan.Location = new System.Drawing.Point(392, 148);
            this.cbSpan.Name = "cbSpan";
            this.cbSpan.Size = new System.Drawing.Size(69, 28);
            this.cbSpan.TabIndex = 28;
            // 
            // cbFreq
            // 
            this.cbFreq.FormattingEnabled = true;
            this.cbFreq.Items.AddRange(new object[] {
            "MHz",
            "KHz",
            "Hz"});
            this.cbFreq.Location = new System.Drawing.Point(160, 148);
            this.cbFreq.Name = "cbFreq";
            this.cbFreq.Size = new System.Drawing.Size(69, 28);
            this.cbFreq.TabIndex = 27;
            // 
            // cbSWT
            // 
            this.cbSWT.FormattingEnabled = true;
            this.cbSWT.Items.AddRange(new object[] {
            "ms",
            "s"});
            this.cbSWT.Location = new System.Drawing.Point(160, 193);
            this.cbSWT.Name = "cbSWT";
            this.cbSWT.Size = new System.Drawing.Size(69, 28);
            this.cbSWT.TabIndex = 26;
            // 
            // cbVBW
            // 
            this.cbVBW.FormattingEnabled = true;
            this.cbVBW.Items.AddRange(new object[] {
            "MHz",
            "KHz",
            "Hz"});
            this.cbVBW.Location = new System.Drawing.Point(392, 106);
            this.cbVBW.Name = "cbVBW";
            this.cbVBW.Size = new System.Drawing.Size(69, 28);
            this.cbVBW.TabIndex = 25;
            // 
            // cbRBW
            // 
            this.cbRBW.FormattingEnabled = true;
            this.cbRBW.Items.AddRange(new object[] {
            "MHz",
            "KHz",
            "Hz"});
            this.cbRBW.Location = new System.Drawing.Point(160, 106);
            this.cbRBW.Name = "cbRBW";
            this.cbRBW.Size = new System.Drawing.Size(69, 28);
            this.cbRBW.TabIndex = 24;
            // 
            // ip1
            // 
            this.ip1.Location = new System.Drawing.Point(104, 42);
            this.ip1.MaxLength = 15;
            this.ip1.Name = "ip1";
            this.ip1.Size = new System.Drawing.Size(188, 26);
            this.ip1.TabIndex = 34;
            this.ip1.Text = "192.168.255.200";
            this.ip1.WordWrap = false;
            // 
            // tVBW
            // 
            this.tVBW.Location = new System.Drawing.Point(298, 106);
            this.tVBW.Name = "tVBW";
            this.tVBW.Size = new System.Drawing.Size(88, 26);
            this.tVBW.TabIndex = 21;
            this.tVBW.Text = "30";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(245, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 20);
            this.label4.TabIndex = 20;
            this.label4.Text = "VBW";
            // 
            // tSpan
            // 
            this.tSpan.Location = new System.Drawing.Point(298, 148);
            this.tSpan.Name = "tSpan";
            this.tSpan.Size = new System.Drawing.Size(88, 26);
            this.tSpan.TabIndex = 18;
            this.tSpan.Text = "0";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(245, 151);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(47, 20);
            this.label12.TabIndex = 17;
            this.label12.Text = "Span";
            // 
            // tFreq
            // 
            this.tFreq.Location = new System.Drawing.Point(66, 148);
            this.tFreq.Name = "tFreq";
            this.tFreq.Size = new System.Drawing.Size(88, 26);
            this.tFreq.TabIndex = 15;
            this.tFreq.Text = "416.8";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 151);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 20);
            this.label10.TabIndex = 14;
            this.label10.Text = "Freq";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(392, 196);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 20);
            this.label7.TabIndex = 13;
            this.label7.Text = "dB";
            // 
            // tREF
            // 
            this.tREF.Location = new System.Drawing.Point(298, 193);
            this.tREF.Name = "tREF";
            this.tREF.Size = new System.Drawing.Size(88, 26);
            this.tREF.TabIndex = 12;
            this.tREF.Text = "-10";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(245, 196);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 20);
            this.label8.TabIndex = 11;
            this.label8.Text = "REF";
            // 
            // tSWT
            // 
            this.tSWT.Location = new System.Drawing.Point(66, 193);
            this.tSWT.Name = "tSWT";
            this.tSWT.Size = new System.Drawing.Size(88, 26);
            this.tSWT.TabIndex = 9;
            this.tSWT.Text = "60";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "SWT";
            // 
            // tRBW
            // 
            this.tRBW.Location = new System.Drawing.Point(66, 106);
            this.tRBW.Name = "tRBW";
            this.tRBW.Size = new System.Drawing.Size(88, 26);
            this.tRBW.TabIndex = 3;
            this.tRBW.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 20);
            this.label1.TabIndex = 2;
            this.label1.Text = "RBW";
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1470, 450);
            this.Controls.Add(this.IPadd);
            this.Name = "Settings";
            this.Text = "Settings";
            this.Load += new System.EventHandler(this.Settings_Load);
            this.IPadd.ResumeLayout(false);
            this.IPadd.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox IPadd;
        private System.Windows.Forms.TextBox tSWP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbSpan;
        private System.Windows.Forms.ComboBox cbFreq;
        private System.Windows.Forms.ComboBox cbSWT;
        private System.Windows.Forms.ComboBox cbVBW;
        private System.Windows.Forms.ComboBox cbRBW;
        private System.Windows.Forms.TextBox ip1;
        private System.Windows.Forms.TextBox tVBW;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tSpan;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tFreq;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tREF;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tSWT;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tRBW;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bSave;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bCancel;
    }
}