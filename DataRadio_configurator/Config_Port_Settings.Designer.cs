
namespace DataRadio_configurator
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
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Cursor = System.Windows.Forms.Cursors.Cross;
            this.label1.Location = new System.Drawing.Point(74, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "COM Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 105);
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
            this.label2.Location = new System.Drawing.Point(74, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "BaudRate";
            // 
            // Portsel_CB
            // 
            this.Portsel_CB.FormattingEnabled = true;
            this.Portsel_CB.Location = new System.Drawing.Point(133, 46);
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
            this.Bdsel_CB.Location = new System.Drawing.Point(135, 79);
            this.Bdsel_CB.Name = "Bdsel_CB";
            this.Bdsel_CB.Size = new System.Drawing.Size(121, 21);
            this.Bdsel_CB.TabIndex = 5;
            // 
            // Config_Port_Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 234);
            this.Controls.Add(this.Bdsel_CB);
            this.Controls.Add(this.Portsel_CB);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Name = "Config_Port_Settings";
            this.Text = "Config_Port_Settings";
            this.Load += new System.EventHandler(this.Config_Port_Settings_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox Portsel_CB;
        private System.Windows.Forms.ComboBox Bdsel_CB;
    }
}