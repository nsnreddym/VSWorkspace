namespace DataRadio_CFG_SW
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bPCh = new System.Windows.Forms.Button();
            this.bRCh = new System.Windows.Forms.Button();
            this.ReadMem = new System.Windows.Forms.Button();
            this.FactorySettings = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.ChannelTabs = new System.Windows.Forms.TabControl();
            this.pbCOMState = new System.Windows.Forms.PictureBox();
            this.cbSector = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbCOMState)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Status";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbSector);
            this.panel1.Controls.Add(this.bPCh);
            this.panel1.Controls.Add(this.bRCh);
            this.panel1.Controls.Add(this.ReadMem);
            this.panel1.Controls.Add(this.FactorySettings);
            this.panel1.Controls.Add(this.pbCOMState);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(785, 34);
            this.panel1.TabIndex = 3;
            // 
            // bPCh
            // 
            this.bPCh.Location = new System.Drawing.Point(216, 6);
            this.bPCh.Name = "bPCh";
            this.bPCh.Size = new System.Drawing.Size(106, 23);
            this.bPCh.TabIndex = 5;
            this.bPCh.Text = "Prog Channels";
            this.bPCh.UseVisualStyleBackColor = true;
            this.bPCh.Click += new System.EventHandler(this.bPCh_Click);
            // 
            // bRCh
            // 
            this.bRCh.Location = new System.Drawing.Point(104, 6);
            this.bRCh.Name = "bRCh";
            this.bRCh.Size = new System.Drawing.Size(106, 23);
            this.bRCh.TabIndex = 4;
            this.bRCh.Text = "Read Channels";
            this.bRCh.UseVisualStyleBackColor = true;
            this.bRCh.Click += new System.EventHandler(this.bRCh_Click);
            // 
            // ReadMem
            // 
            this.ReadMem.Location = new System.Drawing.Point(564, 6);
            this.ReadMem.Name = "ReadMem";
            this.ReadMem.Size = new System.Drawing.Size(106, 23);
            this.ReadMem.TabIndex = 3;
            this.ReadMem.Text = "Read Memory";
            this.ReadMem.UseVisualStyleBackColor = true;
            this.ReadMem.Click += new System.EventHandler(this.ReadMem_Click);
            // 
            // FactorySettings
            // 
            this.FactorySettings.Location = new System.Drawing.Point(676, 6);
            this.FactorySettings.Name = "FactorySettings";
            this.FactorySettings.Size = new System.Drawing.Size(106, 23);
            this.FactorySettings.TabIndex = 2;
            this.FactorySettings.Text = "Factory Settings";
            this.FactorySettings.UseVisualStyleBackColor = true;
            this.FactorySettings.Click += new System.EventHandler(this.FactorySettings_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.ChannelTabs);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 43);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(794, 404);
            this.panel2.TabIndex = 4;
            // 
            // ChannelTabs
            // 
            this.ChannelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ChannelTabs.Location = new System.Drawing.Point(0, 0);
            this.ChannelTabs.Name = "ChannelTabs";
            this.ChannelTabs.SelectedIndex = 0;
            this.ChannelTabs.Size = new System.Drawing.Size(794, 404);
            this.ChannelTabs.TabIndex = 0;
            // 
            // pbCOMState
            // 
            this.pbCOMState.Image = global::DataRadio_CFG_SW.Properties.Resources.ButtonGray;
            this.pbCOMState.Location = new System.Drawing.Point(73, 6);
            this.pbCOMState.Name = "pbCOMState";
            this.pbCOMState.Size = new System.Drawing.Size(25, 25);
            this.pbCOMState.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCOMState.TabIndex = 0;
            this.pbCOMState.TabStop = false;
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
            this.cbSector.Location = new System.Drawing.Point(517, 8);
            this.cbSector.Name = "cbSector";
            this.cbSector.Size = new System.Drawing.Size(41, 21);
            this.cbSector.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(473, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 7;
            this.label2.Text = "Sector";
            // 
            // Radio_Program
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Radio_Program";
            this.Text = "Programmer";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Radio_Program_FormClosed);
            this.Load += new System.EventHandler(this.Radio_Program_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbCOMState)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.PictureBox pbCOMState;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button FactorySettings;
        private System.Windows.Forms.Button ReadMem;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TabControl ChannelTabs;
        private System.Windows.Forms.Button bRCh;
        private System.Windows.Forms.Button bPCh;
        private System.Windows.Forms.ComboBox cbSector;
        private System.Windows.Forms.Label label2;
    }
}