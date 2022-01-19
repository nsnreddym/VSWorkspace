namespace Spectrum_test
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsConnect = new System.Windows.Forms.ToolStripMenuItem();
            this.tsStart_Stop = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAxis = new System.Windows.Forms.ToolStripMenuItem();
            this.tsChart = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrint = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSave = new System.Windows.Forms.ToolStripMenuItem();
            this.tsUpload = new System.Windows.Forms.ToolStripMenuItem();
            this.tsAnalyze = new System.Windows.Forms.ToolStripMenuItem();
            this.tsSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.ssConnect = new System.Windows.Forms.ToolStripStatusLabel();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1 = new System.Windows.Forms.Panel();
            this.UserArea = new System.Windows.Forms.SplitContainer();
            this.Fbox = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bFLoad = new System.Windows.Forms.Button();
            this.tFreq = new System.Windows.Forms.TextBox();
            this.cbPol = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFreq = new System.Windows.Forms.ComboBox();
            this.bReset = new System.Windows.Forms.Button();
            this.MyPrintDocument = new System.Drawing.Printing.PrintDocument();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserArea)).BeginInit();
            this.UserArea.Panel1.SuspendLayout();
            this.UserArea.Panel2.SuspendLayout();
            this.UserArea.SuspendLayout();
            this.Fbox.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsConnect,
            this.tsStart_Stop,
            this.tsAxis,
            this.tsChart,
            this.tsPrint,
            this.tsSave,
            this.tsUpload,
            this.tsAnalyze,
            this.tsSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 1, 0, 1);
            this.menuStrip1.Size = new System.Drawing.Size(1133, 72);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsConnect
            // 
            this.tsConnect.AutoSize = false;
            this.tsConnect.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsConnect.Image = global::Spectrum_test.Properties.Resources.disconnect_icon;
            this.tsConnect.Name = "tsConnect";
            this.tsConnect.Size = new System.Drawing.Size(70, 70);
            this.tsConnect.Text = "DisConnect";
            this.tsConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsConnect.Click += new System.EventHandler(this.tsConnect_Click);
            // 
            // tsStart_Stop
            // 
            this.tsStart_Stop.AutoSize = false;
            this.tsStart_Stop.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsStart_Stop.Image = global::Spectrum_test.Properties.Resources.start;
            this.tsStart_Stop.Name = "tsStart_Stop";
            this.tsStart_Stop.Size = new System.Drawing.Size(64, 70);
            this.tsStart_Stop.Text = "Start";
            this.tsStart_Stop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsStart_Stop.Click += new System.EventHandler(this.tsStart_Stop_Click);
            // 
            // tsAxis
            // 
            this.tsAxis.AutoSize = false;
            this.tsAxis.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAxis.Image = global::Spectrum_test.Properties.Resources.Axes;
            this.tsAxis.Name = "tsAxis";
            this.tsAxis.Size = new System.Drawing.Size(70, 70);
            this.tsAxis.Text = "Axis";
            this.tsAxis.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsAxis.Click += new System.EventHandler(this.tsAxis_Click);
            // 
            // tsChart
            // 
            this.tsChart.AutoSize = false;
            this.tsChart.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsChart.Image = global::Spectrum_test.Properties.Resources.chart;
            this.tsChart.Name = "tsChart";
            this.tsChart.Size = new System.Drawing.Size(70, 70);
            this.tsChart.Text = "Rectangle";
            this.tsChart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsChart.Click += new System.EventHandler(this.tsChart_Click);
            // 
            // tsPrint
            // 
            this.tsPrint.AutoSize = false;
            this.tsPrint.Image = global::Spectrum_test.Properties.Resources.print_icon;
            this.tsPrint.Name = "tsPrint";
            this.tsPrint.Size = new System.Drawing.Size(70, 70);
            this.tsPrint.Text = "print";
            this.tsPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsPrint.Click += new System.EventHandler(this.tsPrint_Click);
            // 
            // tsSave
            // 
            this.tsSave.AutoSize = false;
            this.tsSave.Image = global::Spectrum_test.Properties.Resources.Save;
            this.tsSave.Name = "tsSave";
            this.tsSave.Size = new System.Drawing.Size(70, 70);
            this.tsSave.Text = "Save";
            this.tsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSave.Click += new System.EventHandler(this.tsSave_Click);
            // 
            // tsUpload
            // 
            this.tsUpload.AutoSize = false;
            this.tsUpload.Image = global::Spectrum_test.Properties.Resources.Upload;
            this.tsUpload.Name = "tsUpload";
            this.tsUpload.Size = new System.Drawing.Size(70, 70);
            this.tsUpload.Text = "Load";
            this.tsUpload.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsUpload.Click += new System.EventHandler(this.tsUpload_Click);
            // 
            // tsAnalyze
            // 
            this.tsAnalyze.AutoSize = false;
            this.tsAnalyze.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsAnalyze.Image = global::Spectrum_test.Properties.Resources.analyze;
            this.tsAnalyze.Name = "tsAnalyze";
            this.tsAnalyze.Size = new System.Drawing.Size(70, 70);
            this.tsAnalyze.Text = "Analyze";
            this.tsAnalyze.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsAnalyze.Click += new System.EventHandler(this.tsAnalyze_Click);
            // 
            // tsSettings
            // 
            this.tsSettings.AutoSize = false;
            this.tsSettings.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsSettings.Image = global::Spectrum_test.Properties.Resources.settings_icon;
            this.tsSettings.Name = "tsSettings";
            this.tsSettings.Size = new System.Drawing.Size(70, 70);
            this.tsSettings.Text = "Settings";
            this.tsSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsSettings.Click += new System.EventHandler(this.tsSettings_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ssConnect});
            this.statusStrip1.Location = new System.Drawing.Point(0, 329);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 9, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1133, 29);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // ssConnect
            // 
            this.ssConnect.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.ssConnect.Image = global::Spectrum_test.Properties.Resources.ButtonRed;
            this.ssConnect.Name = "ssConnect";
            this.ssConnect.Size = new System.Drawing.Size(144, 24);
            this.ssConnect.Text = "Status : DisConnected";
            this.ssConnect.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            this.chart1.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(0, 0);
            this.chart1.Margin = new System.Windows.Forms.Padding(2);
            this.chart1.Name = "chart1";
            this.chart1.Size = new System.Drawing.Size(804, 257);
            this.chart1.TabIndex = 4;
            this.chart1.Text = "chart1";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer_routine);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.UserArea);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 72);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1133, 257);
            this.panel1.TabIndex = 5;
            // 
            // UserArea
            // 
            this.UserArea.Dock = System.Windows.Forms.DockStyle.Fill;
            this.UserArea.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.UserArea.Location = new System.Drawing.Point(0, 0);
            this.UserArea.Name = "UserArea";
            // 
            // UserArea.Panel1
            // 
            this.UserArea.Panel1.Controls.Add(this.chart1);
            // 
            // UserArea.Panel2
            // 
            this.UserArea.Panel2.Controls.Add(this.Fbox);
            this.UserArea.Panel2.Controls.Add(this.bReset);
            this.UserArea.Size = new System.Drawing.Size(1133, 257);
            this.UserArea.SplitterDistance = 804;
            this.UserArea.TabIndex = 5;
            // 
            // Fbox
            // 
            this.Fbox.AutoSize = true;
            this.Fbox.Controls.Add(this.label3);
            this.Fbox.Controls.Add(this.textBox1);
            this.Fbox.Controls.Add(this.label2);
            this.Fbox.Controls.Add(this.bFLoad);
            this.Fbox.Controls.Add(this.tFreq);
            this.Fbox.Controls.Add(this.cbPol);
            this.Fbox.Controls.Add(this.label10);
            this.Fbox.Controls.Add(this.label1);
            this.Fbox.Controls.Add(this.cbFreq);
            this.Fbox.Location = new System.Drawing.Point(13, 55);
            this.Fbox.Name = "Fbox";
            this.Fbox.Size = new System.Drawing.Size(309, 99);
            this.Fbox.TabIndex = 33;
            this.Fbox.TabStop = false;
            this.Fbox.Text = "Test Parameters";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(272, 21);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 13);
            this.label3.TabIndex = 36;
            this.label3.Text = "dBm";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(234, 17);
            this.textBox1.Margin = new System.Windows.Forms.Padding(2);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(34, 20);
            this.textBox1.TabIndex = 35;
            this.textBox1.Text = "-10";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(182, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 34;
            this.label2.Text = "RF Input";
            // 
            // bFLoad
            // 
            this.bFLoad.Location = new System.Drawing.Point(145, 51);
            this.bFLoad.Name = "bFLoad";
            this.bFLoad.Size = new System.Drawing.Size(75, 23);
            this.bFLoad.TabIndex = 33;
            this.bFLoad.Text = "Update";
            this.bFLoad.UseVisualStyleBackColor = true;
            this.bFLoad.Click += new System.EventHandler(this.bFLoad_Click);
            // 
            // tFreq
            // 
            this.tFreq.Location = new System.Drawing.Point(58, 18);
            this.tFreq.Margin = new System.Windows.Forms.Padding(2);
            this.tFreq.Name = "tFreq";
            this.tFreq.Size = new System.Drawing.Size(60, 20);
            this.tFreq.TabIndex = 29;
            this.tFreq.Text = "416.8";
            // 
            // cbPol
            // 
            this.cbPol.FormattingEnabled = true;
            this.cbPol.Items.AddRange(new object[] {
            "H/H",
            "V/V",
            "H/V",
            "V/H"});
            this.cbPol.Location = new System.Drawing.Point(58, 51);
            this.cbPol.Margin = new System.Windows.Forms.Padding(2);
            this.cbPol.Name = "cbPol";
            this.cbPol.Size = new System.Drawing.Size(47, 21);
            this.cbPol.TabIndex = 32;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(23, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 28;
            this.label10.Text = "Freq";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(23, 54);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "Pol";
            // 
            // cbFreq
            // 
            this.cbFreq.FormattingEnabled = true;
            this.cbFreq.Items.AddRange(new object[] {
            "MHz",
            "KHz",
            "Hz"});
            this.cbFreq.Location = new System.Drawing.Point(121, 18);
            this.cbFreq.Margin = new System.Windows.Forms.Padding(2);
            this.cbFreq.Name = "cbFreq";
            this.cbFreq.Size = new System.Drawing.Size(47, 21);
            this.cbFreq.TabIndex = 30;
            // 
            // bReset
            // 
            this.bReset.Location = new System.Drawing.Point(13, 13);
            this.bReset.Name = "bReset";
            this.bReset.Size = new System.Drawing.Size(75, 23);
            this.bReset.TabIndex = 0;
            this.bReset.Text = "Reset";
            this.bReset.UseVisualStyleBackColor = true;
            this.bReset.Click += new System.EventHandler(this.bReset_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1133, 358);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Range Test V 0.1";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.UserArea.Panel1.ResumeLayout(false);
            this.UserArea.Panel2.ResumeLayout(false);
            this.UserArea.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.UserArea)).EndInit();
            this.UserArea.ResumeLayout(false);
            this.Fbox.ResumeLayout(false);
            this.Fbox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsAnalyze;
        private System.Windows.Forms.ToolStripMenuItem tsConnect;
        private System.Windows.Forms.ToolStripMenuItem tsAxis;
        private System.Windows.Forms.ToolStripMenuItem tsSettings;
        private System.Windows.Forms.ToolStripMenuItem tsChart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel ssConnect;
        private System.Windows.Forms.ToolStripMenuItem tsStart_Stop;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Panel panel1;
        private System.Drawing.Printing.PrintDocument MyPrintDocument;
        private System.Windows.Forms.ToolStripMenuItem tsPrint;
        private System.Windows.Forms.SplitContainer UserArea;
        private System.Windows.Forms.ToolStripMenuItem tsSave;
        private System.Windows.Forms.ToolStripMenuItem tsUpload;
        private System.Windows.Forms.Button bReset;
        private System.Windows.Forms.ComboBox cbPol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbFreq;
        private System.Windows.Forms.TextBox tFreq;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox Fbox;
        private System.Windows.Forms.Button bFLoad;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}