
namespace DataRadio_configurator
{
    partial class Radio_Program
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
            this.CFG_serialPort = new System.IO.Ports.SerialPort(this.components);
            this.bWrite = new System.Windows.Forms.Button();
            this.bErase = new System.Windows.Forms.Button();
            this.lbDefault = new System.Windows.Forms.Label();
            this.TxFreq = new System.Windows.Forms.TextBox();
            this.bLoad = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.RxFreq = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTxPwr = new System.Windows.Forms.ComboBox();
            this.cbChannel = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbWrDefault = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UsrChannel = new System.Windows.Forms.GroupBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tbStatus = new System.Windows.Forms.TextBox();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbRxEN = new System.Windows.Forms.CheckBox();
            this.cbTxEN = new System.Windows.Forms.CheckBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.bSubmit = new System.Windows.Forms.Button();
            this.Ch_no_CB = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbEOT = new System.Windows.Forms.RadioButton();
            this.rbTCAS = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.UsrChannel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // bWrite
            // 
            this.bWrite.Location = new System.Drawing.Point(111, 43);
            this.bWrite.Name = "bWrite";
            this.bWrite.Size = new System.Drawing.Size(112, 23);
            this.bWrite.TabIndex = 0;
            this.bWrite.Text = "Write";
            this.bWrite.UseVisualStyleBackColor = true;
            this.bWrite.Click += new System.EventHandler(this.bWrite_Click);
            // 
            // bErase
            // 
            this.bErase.Location = new System.Drawing.Point(111, 72);
            this.bErase.Name = "bErase";
            this.bErase.Size = new System.Drawing.Size(112, 23);
            this.bErase.TabIndex = 1;
            this.bErase.Text = "Erase";
            this.bErase.UseVisualStyleBackColor = true;
            this.bErase.Click += new System.EventHandler(this.bFErase_Click);
            // 
            // lbDefault
            // 
            this.lbDefault.AutoSize = true;
            this.lbDefault.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDefault.Location = new System.Drawing.Point(36, 50);
            this.lbDefault.MaximumSize = new System.Drawing.Size(100, 0);
            this.lbDefault.Name = "lbDefault";
            this.lbDefault.Size = new System.Drawing.Size(63, 38);
            this.lbDefault.TabIndex = 2;
            this.lbDefault.Text = "Default Sector";
            this.lbDefault.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TxFreq
            // 
            this.TxFreq.Location = new System.Drawing.Point(124, 19);
            this.TxFreq.Name = "TxFreq";
            this.TxFreq.Size = new System.Drawing.Size(100, 20);
            this.TxFreq.TabIndex = 3;
            this.TxFreq.Text = "416.8";
            // 
            // bLoad
            // 
            this.bLoad.Location = new System.Drawing.Point(124, 145);
            this.bLoad.Name = "bLoad";
            this.bLoad.Size = new System.Drawing.Size(75, 23);
            this.bLoad.TabIndex = 4;
            this.bLoad.Text = "Load";
            this.bLoad.UseVisualStyleBackColor = true;
            this.bLoad.Click += new System.EventHandler(this.bLoad_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Tx Freq";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Rx Freq";
            // 
            // RxFreq
            // 
            this.RxFreq.Location = new System.Drawing.Point(124, 56);
            this.RxFreq.Name = "RxFreq";
            this.RxFreq.Size = new System.Drawing.Size(100, 20);
            this.RxFreq.TabIndex = 7;
            this.RxFreq.Text = "416.8";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(230, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(29, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "MHz";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(230, 59);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "MHz";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(178, 96);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(18, 13);
            this.label6.TabIndex = 13;
            this.label6.Text = "W";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(66, 96);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Tx Power";
            // 
            // cbTxPwr
            // 
            this.cbTxPwr.FormattingEnabled = true;
            this.cbTxPwr.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbTxPwr.Location = new System.Drawing.Point(124, 93);
            this.cbTxPwr.Name = "cbTxPwr";
            this.cbTxPwr.Size = new System.Drawing.Size(48, 21);
            this.cbTxPwr.TabIndex = 14;
            // 
            // cbChannel
            // 
            this.cbChannel.FormattingEnabled = true;
            this.cbChannel.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.cbChannel.Location = new System.Drawing.Point(272, 93);
            this.cbChannel.Name = "cbChannel";
            this.cbChannel.Size = new System.Drawing.Size(48, 21);
            this.cbChannel.TabIndex = 17;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(214, 96);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 15;
            this.label9.Text = "Channel";
            // 
            // cbWrDefault
            // 
            this.cbWrDefault.AutoSize = true;
            this.cbWrDefault.Location = new System.Drawing.Point(129, 113);
            this.cbWrDefault.Name = "cbWrDefault";
            this.cbWrDefault.Size = new System.Drawing.Size(88, 17);
            this.cbWrDefault.TabIndex = 18;
            this.cbWrDefault.Text = "Write Default";
            this.cbWrDefault.UseVisualStyleBackColor = true;
            this.cbWrDefault.CheckedChanged += new System.EventHandler(this.cbWrDefault_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbDefault);
            this.groupBox1.Controls.Add(this.cbWrDefault);
            this.groupBox1.Controls.Add(this.bWrite);
            this.groupBox1.Controls.Add(this.bErase);
            this.groupBox1.Location = new System.Drawing.Point(514, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(262, 200);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Reserved Channel";
            // 
            // UsrChannel
            // 
            this.UsrChannel.Controls.Add(this.rbTCAS);
            this.UsrChannel.Controls.Add(this.rbEOT);
            this.UsrChannel.Controls.Add(this.TxFreq);
            this.UsrChannel.Controls.Add(this.bLoad);
            this.UsrChannel.Controls.Add(this.cbChannel);
            this.UsrChannel.Controls.Add(this.label2);
            this.UsrChannel.Controls.Add(this.label9);
            this.UsrChannel.Controls.Add(this.RxFreq);
            this.UsrChannel.Controls.Add(this.cbTxPwr);
            this.UsrChannel.Controls.Add(this.label3);
            this.UsrChannel.Controls.Add(this.label6);
            this.UsrChannel.Controls.Add(this.label4);
            this.UsrChannel.Controls.Add(this.label7);
            this.UsrChannel.Controls.Add(this.label5);
            this.UsrChannel.Location = new System.Drawing.Point(28, 3);
            this.UsrChannel.Name = "UsrChannel";
            this.UsrChannel.Size = new System.Drawing.Size(466, 200);
            this.UsrChannel.TabIndex = 21;
            this.UsrChannel.TabStop = false;
            this.UsrChannel.Text = "User Channels";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // tbStatus
            // 
            this.tbStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbStatus.Location = new System.Drawing.Point(0, 0);
            this.tbStatus.Multiline = true;
            this.tbStatus.Name = "tbStatus";
            this.tbStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbStatus.Size = new System.Drawing.Size(882, 144);
            this.tbStatus.TabIndex = 26;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox3);
            this.splitContainer1.Panel1.Controls.Add(this.UsrChannel);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel1.Controls.Add(this.groupBox2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tbStatus);
            this.splitContainer1.Size = new System.Drawing.Size(882, 516);
            this.splitContainer1.SplitterDistance = 368;
            this.splitContainer1.TabIndex = 27;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbRxEN);
            this.groupBox3.Controls.Add(this.cbTxEN);
            this.groupBox3.Location = new System.Drawing.Point(514, 209);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(262, 128);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Reserved Channel";
            // 
            // cbRxEN
            // 
            this.cbRxEN.AutoSize = true;
            this.cbRxEN.Location = new System.Drawing.Point(25, 54);
            this.cbRxEN.Name = "cbRxEN";
            this.cbRxEN.Size = new System.Drawing.Size(75, 17);
            this.cbRxEN.TabIndex = 19;
            this.cbRxEN.Text = "Rx Enable";
            this.cbRxEN.UseVisualStyleBackColor = true;
            this.cbRxEN.CheckedChanged += new System.EventHandler(this.cbRxEN_CheckedChanged);
            // 
            // cbTxEN
            // 
            this.cbTxEN.AutoSize = true;
            this.cbTxEN.Location = new System.Drawing.Point(25, 31);
            this.cbTxEN.Name = "cbTxEN";
            this.cbTxEN.Size = new System.Drawing.Size(74, 17);
            this.cbTxEN.TabIndex = 18;
            this.cbTxEN.Text = "Tx Enable";
            this.cbTxEN.UseVisualStyleBackColor = true;
            this.cbTxEN.CheckedChanged += new System.EventHandler(this.cbTxEN_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.bSubmit);
            this.groupBox2.Controls.Add(this.Ch_no_CB);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(28, 209);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(466, 128);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Select Channel";
            // 
            // bSubmit
            // 
            this.bSubmit.Location = new System.Drawing.Point(131, 73);
            this.bSubmit.Name = "bSubmit";
            this.bSubmit.Size = new System.Drawing.Size(75, 23);
            this.bSubmit.TabIndex = 24;
            this.bSubmit.Text = "Submit";
            this.bSubmit.UseVisualStyleBackColor = true;
            this.bSubmit.Click += new System.EventHandler(this.bSubmit_Click);
            // 
            // Ch_no_CB
            // 
            this.Ch_no_CB.FormattingEnabled = true;
            this.Ch_no_CB.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10"});
            this.Ch_no_CB.Location = new System.Drawing.Point(105, 19);
            this.Ch_no_CB.Name = "Ch_no_CB";
            this.Ch_no_CB.Size = new System.Drawing.Size(121, 21);
            this.Ch_no_CB.TabIndex = 22;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(36, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Channel No";
            // 
            // rbEOT
            // 
            this.rbEOT.AutoSize = true;
            this.rbEOT.Location = new System.Drawing.Point(368, 21);
            this.rbEOT.Name = "rbEOT";
            this.rbEOT.Size = new System.Drawing.Size(47, 17);
            this.rbEOT.TabIndex = 18;
            this.rbEOT.Text = "EOT";
            this.rbEOT.UseVisualStyleBackColor = true;
            // 
            // rbTCAS
            // 
            this.rbTCAS.AutoSize = true;
            this.rbTCAS.Checked = true;
            this.rbTCAS.Location = new System.Drawing.Point(368, 43);
            this.rbTCAS.Name = "rbTCAS";
            this.rbTCAS.Size = new System.Drawing.Size(53, 17);
            this.rbTCAS.TabIndex = 19;
            this.rbTCAS.TabStop = true;
            this.rbTCAS.Text = "TCAS";
            this.rbTCAS.UseVisualStyleBackColor = true;
            // 
            // Radio_Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 516);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Radio_Program";
            this.Text = "Configure Radio";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Radio_Program_FormClosed);
            this.Load += new System.EventHandler(this.Radio_Program_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.UsrChannel.ResumeLayout(false);
            this.UsrChannel.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.IO.Ports.SerialPort CFG_serialPort;
        private System.Windows.Forms.Button bWrite;
        private System.Windows.Forms.Button bErase;
        private System.Windows.Forms.Label lbDefault;
        private System.Windows.Forms.TextBox TxFreq;
        private System.Windows.Forms.Button bLoad;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox RxFreq;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTxPwr;
        private System.Windows.Forms.ComboBox cbChannel;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox cbWrDefault;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox UsrChannel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox tbStatus;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Button bSubmit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox Ch_no_CB;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox cbTxEN;
        private System.Windows.Forms.CheckBox cbRxEN;
        private System.Windows.Forms.RadioButton rbTCAS;
        private System.Windows.Forms.RadioButton rbEOT;
    }
}