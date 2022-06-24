namespace DataRadio_CFG_SW
{
    partial class FlashDisplay
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
            ((System.ComponentModel.ISupportInitialize)(this.FlashMemView)).BeginInit();
            this.SuspendLayout();
            // 
            // FlashMemView
            // 
            this.FlashMemView.AllowUserToAddRows = false;
            this.FlashMemView.AllowUserToDeleteRows = false;
            this.FlashMemView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.FlashMemView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.FlashMemView.Location = new System.Drawing.Point(0, 0);
            this.FlashMemView.Name = "FlashMemView";
            this.FlashMemView.ReadOnly = true;
            this.FlashMemView.RowHeadersVisible = false;
            this.FlashMemView.Size = new System.Drawing.Size(800, 450);
            this.FlashMemView.TabIndex = 0;
            // 
            // FlashDisplay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.FlashMemView);
            this.Name = "FlashDisplay";
            this.Text = "FlashDisplay";
            this.Load += new System.EventHandler(this.FlashDisplay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.FlashMemView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView FlashMemView;
    }
}