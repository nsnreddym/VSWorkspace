
namespace DataRadio_configurator
{
    partial class MainForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.configPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataPortToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataRadioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.programToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectChannelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readMemoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.COM_SL = new System.Windows.Forms.ToolStripStatusLabel();
            this.PortStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.Baudrate_SL = new System.Windows.Forms.ToolStripStatusLabel();
            this.BaudValue = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.dataRadioToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.configPortToolStripMenuItem,
            this.dataPortToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // configPortToolStripMenuItem
            // 
            this.configPortToolStripMenuItem.Name = "configPortToolStripMenuItem";
            this.configPortToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.configPortToolStripMenuItem.Text = "Config Port";
            this.configPortToolStripMenuItem.Click += new System.EventHandler(this.configPortToolStripMenuItem_Click);
            // 
            // dataPortToolStripMenuItem
            // 
            this.dataPortToolStripMenuItem.Name = "dataPortToolStripMenuItem";
            this.dataPortToolStripMenuItem.Size = new System.Drawing.Size(135, 22);
            this.dataPortToolStripMenuItem.Text = "Data Port";
            // 
            // dataRadioToolStripMenuItem
            // 
            this.dataRadioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.programToolStripMenuItem,
            this.selectChannelToolStripMenuItem,
            this.readMemoryToolStripMenuItem});
            this.dataRadioToolStripMenuItem.Name = "dataRadioToolStripMenuItem";
            this.dataRadioToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.dataRadioToolStripMenuItem.Text = "DataRadio";
            // 
            // programToolStripMenuItem
            // 
            this.programToolStripMenuItem.Name = "programToolStripMenuItem";
            this.programToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.L)));
            this.programToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.programToolStripMenuItem.Text = "Program";
            this.programToolStripMenuItem.Click += new System.EventHandler(this.programToolStripMenuItem_Click);
            // 
            // selectChannelToolStripMenuItem
            // 
            this.selectChannelToolStripMenuItem.Enabled = false;
            this.selectChannelToolStripMenuItem.Name = "selectChannelToolStripMenuItem";
            this.selectChannelToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.selectChannelToolStripMenuItem.Text = "Select Channel";
            this.selectChannelToolStripMenuItem.Click += new System.EventHandler(this.selectChannelToolStripMenuItem_Click);
            // 
            // readMemoryToolStripMenuItem
            // 
            this.readMemoryToolStripMenuItem.Name = "readMemoryToolStripMenuItem";
            this.readMemoryToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.readMemoryToolStripMenuItem.Size = new System.Drawing.Size(189, 22);
            this.readMemoryToolStripMenuItem.Text = "Read Memory";
            this.readMemoryToolStripMenuItem.Click += new System.EventHandler(this.readMemoryToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.COM_SL,
            this.PortStatus,
            this.Baudrate_SL,
            this.BaudValue});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "DataRadio Configuration Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataRadioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem programToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem configPortToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataPortToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel COM_SL;
        private System.Windows.Forms.ToolStripStatusLabel PortStatus;
        private System.Windows.Forms.ToolStripStatusLabel BaudValue;
        private System.Windows.Forms.ToolStripStatusLabel Baudrate_SL;
        private System.Windows.Forms.ToolStripMenuItem selectChannelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readMemoryToolStripMenuItem;
    }
}