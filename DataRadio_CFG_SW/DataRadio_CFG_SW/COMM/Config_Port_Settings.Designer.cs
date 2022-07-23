
namespace DataRadio_CFG_SW.COMM
{
    partial class Config_Port_Settings
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Portsel_CB = new System.Windows.Forms.ComboBox();
            this.Bdsel_CB = new System.Windows.Forms.ComboBox();
            this.RawFlashAccess = new System.Windows.Forms.CheckBox();
            this.RSSI_LEN = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbfname = new System.Windows.Forms.TextBox();
            this.pCfgBrowse = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Portsel_DB = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Bdsel_DB = new System.Windows.Forms.ComboBox();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.label1.Location = new System.Drawing.Point(16, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(123, 311);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Cursor = System.Windows.Forms.Cursors.Cross;
            this.label2.Location = new System.Drawing.Point(16, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BaudRate";
            // 
            // Portsel_CB
            // 
            this.Portsel_CB.FormattingEnabled = true;
            this.Portsel_CB.Location = new System.Drawing.Point(75, 27);
            this.Portsel_CB.Name = "Portsel_CB";
            this.Portsel_CB.Size = new System.Drawing.Size(121, 21);
            this.Portsel_CB.TabIndex = 4;
            // 
            // Bdsel_CB
            // 
            this.Bdsel_CB.FormattingEnabled = true;
            this.Bdsel_CB.Items.AddRange(new object[] {
            "100",
            "300",
            "600",
            "1200",
            "4800",
            "9600",
            "19200",
            "57600",
            "115200"});
            this.Bdsel_CB.Location = new System.Drawing.Point(75, 60);
            this.Bdsel_CB.Name = "Bdsel_CB";
            this.Bdsel_CB.Size = new System.Drawing.Size(121, 21);
            this.Bdsel_CB.TabIndex = 5;
            // 
            // RawFlashAccess
            // 
            this.RawFlashAccess.AutoSize = true;
            this.RawFlashAccess.Location = new System.Drawing.Point(263, 31);
            this.RawFlashAccess.Name = "RawFlashAccess";
            this.RawFlashAccess.Size = new System.Drawing.Size(114, 17);
            this.RawFlashAccess.TabIndex = 6;
            this.RawFlashAccess.Text = "Raw Flash Access";
            this.RawFlashAccess.UseVisualStyleBackColor = true;
            // 
            // RSSI_LEN
            // 
            this.RSSI_LEN.AutoSize = true;
            this.RSSI_LEN.Location = new System.Drawing.Point(263, 54);
            this.RSSI_LEN.Name = "RSSI_LEN";
            this.RSSI_LEN.Size = new System.Drawing.Size(117, 17);
            this.RSSI_LEN.TabIndex = 7;
            this.RSSI_LEN.Text = "RSSI Latch Enable";
            this.RSSI_LEN.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 101);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(95, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Power Config File: ";
            // 
            // tbfname
            // 
            this.tbfname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbfname.Location = new System.Drawing.Point(117, 98);
            this.tbfname.Name = "tbfname";
            this.tbfname.Size = new System.Drawing.Size(307, 20);
            this.tbfname.TabIndex = 11;
            // 
            // pCfgBrowse
            // 
            this.pCfgBrowse.Location = new System.Drawing.Point(430, 96);
            this.pCfgBrowse.Name = "pCfgBrowse";
            this.pCfgBrowse.Size = new System.Drawing.Size(75, 23);
            this.pCfgBrowse.TabIndex = 12;
            this.pCfgBrowse.Text = "Browse";
            this.pCfgBrowse.UseVisualStyleBackColor = true;
            this.pCfgBrowse.Click += new System.EventHandler(this.pCfgBrowse_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.RSSI_LEN);
            this.groupBox3.Controls.Add(this.Portsel_CB);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.Bdsel_CB);
            this.groupBox3.Controls.Add(this.RawFlashAccess);
            this.groupBox3.Controls.Add(this.pCfgBrowse);
            this.groupBox3.Controls.Add(this.tbfname);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Location = new System.Drawing.Point(2, 3);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(530, 140);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Configuration Port Settings";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Portsel_DB);
            this.groupBox1.Controls.Add(this.Bdsel_DB);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(2, 149);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(271, 115);
            this.groupBox1.TabIndex = 14;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Data Port Settings";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Cursor = System.Windows.Forms.Cursors.Cross;
            this.label4.Location = new System.Drawing.Point(16, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "COM Port";
            // 
            // Portsel_DB
            // 
            this.Portsel_DB.FormattingEnabled = true;
            this.Portsel_DB.Location = new System.Drawing.Point(75, 19);
            this.Portsel_DB.Name = "Portsel_DB";
            this.Portsel_DB.Size = new System.Drawing.Size(121, 21);
            this.Portsel_DB.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Cursor = System.Windows.Forms.Cursors.Cross;
            this.label5.Location = new System.Drawing.Point(16, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "BaudRate";
            // 
            // Bdsel_DB
            // 
            this.Bdsel_DB.FormattingEnabled = true;
            this.Bdsel_DB.Items.AddRange(new object[] {
            "100",
            "300",
            "600",
            "1200",
            "4800",
            "9600",
            "19200",
            "57600",
            "115200"});
            this.Bdsel_DB.Location = new System.Drawing.Point(75, 52);
            this.Bdsel_DB.Name = "Bdsel_DB";
            this.Bdsel_DB.Size = new System.Drawing.Size(121, 21);
            this.Bdsel_DB.TabIndex = 18;
            // 
            // Config_Port_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 401);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Name = "Config_Port_Settings";
            this.Text = "Config_Port_Settings";
            this.Load += new System.EventHandler(this.Config_Port_Settings_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Portsel_CB;
        private System.Windows.Forms.ComboBox Bdsel_CB;
        private System.Windows.Forms.CheckBox RawFlashAccess;
        private System.Windows.Forms.CheckBox RSSI_LEN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbfname;
        private System.Windows.Forms.Button pCfgBrowse;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox Portsel_DB;
        private System.Windows.Forms.ComboBox Bdsel_DB;
        private System.Windows.Forms.Label label5;
    }
}