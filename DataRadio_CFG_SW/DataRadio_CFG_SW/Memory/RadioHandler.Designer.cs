namespace DataRadio_CFG_SW.Memory
{
    partial class RadioHandler
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
            this.FlashMemView = new System.Windows.Forms.DataGridView();
            this.ChannelTabs = new System.Windows.Forms.TabControl();
            ((System.ComponentModel.ISupportInitialize)(this.FlashMemView)).BeginInit();
            this.SuspendLayout();
            // 
            // FlashMemView
            // 
            this.FlashMemView.AllowUserToAddRows = false;
            this.FlashMemView.AllowUserToDeleteRows = false;
            this.FlashMemView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FlashMemView.Location = new System.Drawing.Point(233, 129);
            this.FlashMemView.Name = "FlashMemView";
            this.FlashMemView.ReadOnly = true;
            this.FlashMemView.RowHeadersVisible = false;
            this.FlashMemView.Size = new System.Drawing.Size(575, 329);
            this.FlashMemView.TabIndex = 1;
            // 
            // ChannelTabs
            // 
            this.ChannelTabs.Location = new System.Drawing.Point(12, 34);
            this.ChannelTabs.Name = "ChannelTabs";
            this.ChannelTabs.SelectedIndex = 0;
            this.ChannelTabs.Size = new System.Drawing.Size(457, 252);
            this.ChannelTabs.TabIndex = 2;
            this.ChannelTabs.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ChannelTabs_KeyDown);
            // 
            // RadioHandler
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChannelTabs);
            this.Controls.Add(this.FlashMemView);
            this.Name = "RadioHandler";
            this.Text = "RadioHandler";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RadioHandler_FormClosing);
            this.Load += new System.EventHandler(this.RadioHandler_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.RadioHandler_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.FlashMemView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FlashMemView;
        private System.Windows.Forms.TabControl ChannelTabs;
    }
}