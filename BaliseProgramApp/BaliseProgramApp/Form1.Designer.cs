namespace BaliseProgramApp
{
    partial class Form1
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
            this.COMPortSel = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ComPort_dev = new System.IO.Ports.SerialPort(this.components);
            this.pBar = new System.Windows.Forms.ProgressBar();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Filepath = new System.Windows.Forms.TextBox();
            this.bOpen = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // COMPortSel
            // 
            this.COMPortSel.FormattingEnabled = true;
            this.COMPortSel.Location = new System.Drawing.Point(478, 12);
            this.COMPortSel.Name = "COMPortSel";
            this.COMPortSel.Size = new System.Drawing.Size(121, 21);
            this.COMPortSel.TabIndex = 0;
            this.COMPortSel.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(417, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Com Port";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(93, 104);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Upload";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pBar
            // 
            this.pBar.Location = new System.Drawing.Point(93, 220);
            this.pBar.Name = "pBar";
            this.pBar.Size = new System.Drawing.Size(488, 23);
            this.pBar.TabIndex = 3;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "\"Bin files (*.bin)|*.bin";
            // 
            // Filepath
            // 
            this.Filepath.Location = new System.Drawing.Point(93, 61);
            this.Filepath.Name = "Filepath";
            this.Filepath.ReadOnly = true;
            this.Filepath.Size = new System.Drawing.Size(425, 20);
            this.Filepath.TabIndex = 4;
            // 
            // bOpen
            // 
            this.bOpen.Location = new System.Drawing.Point(524, 59);
            this.bOpen.Name = "bOpen";
            this.bOpen.Size = new System.Drawing.Size(75, 23);
            this.bOpen.TabIndex = 5;
            this.bOpen.Text = "Browse";
            this.bOpen.UseVisualStyleBackColor = true;
            this.bOpen.Click += new System.EventHandler(this.bOpen_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 328);
            this.Controls.Add(this.bOpen);
            this.Controls.Add(this.Filepath);
            this.Controls.Add(this.pBar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.COMPortSel);
            this.Name = "Form1";
            this.Text = "Balise Programmer V1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox COMPortSel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.IO.Ports.SerialPort ComPort_dev;
        private System.Windows.Forms.ProgressBar pBar;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox Filepath;
        private System.Windows.Forms.Button bOpen;
    }
}

