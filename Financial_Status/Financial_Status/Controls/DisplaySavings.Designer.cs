namespace Financial_Status
{
    partial class DisplaySavings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.title = new System.Windows.Forms.GroupBox();
            this.lAccType = new System.Windows.Forms.Label();
            this.lBalance = new System.Windows.Forms.Label();
            this.lAccNo = new System.Windows.Forms.Label();
            this.lBankName = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.title.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.Controls.Add(this.splitter1);
            this.title.Controls.Add(this.lAccType);
            this.title.Controls.Add(this.lBalance);
            this.title.Controls.Add(this.lAccNo);
            this.title.Controls.Add(this.lBankName);
            this.title.Controls.Add(this.label5);
            this.title.Controls.Add(this.label4);
            this.title.Controls.Add(this.label3);
            this.title.Controls.Add(this.label2);
            this.title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.title.ForeColor = System.Drawing.Color.Red;
            this.title.Location = new System.Drawing.Point(0, 0);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(389, 186);
            this.title.TabIndex = 0;
            this.title.TabStop = false;
            this.title.Text = "groupBox1";
            // 
            // lAccType
            // 
            this.lAccType.AutoSize = true;
            this.lAccType.ForeColor = System.Drawing.Color.Blue;
            this.lAccType.Location = new System.Drawing.Point(288, 56);
            this.lAccType.Name = "lAccType";
            this.lAccType.Size = new System.Drawing.Size(33, 15);
            this.lAccType.TabIndex = 9;
            this.lAccType.Text = "Bank";
            // 
            // lBalance
            // 
            this.lBalance.AutoSize = true;
            this.lBalance.ForeColor = System.Drawing.Color.Blue;
            this.lBalance.Location = new System.Drawing.Point(138, 130);
            this.lBalance.Name = "lBalance";
            this.lBalance.Size = new System.Drawing.Size(33, 15);
            this.lBalance.TabIndex = 8;
            this.lBalance.Text = "Bank";
            // 
            // lAccNo
            // 
            this.lAccNo.AutoSize = true;
            this.lAccNo.ForeColor = System.Drawing.Color.Blue;
            this.lAccNo.Location = new System.Drawing.Point(138, 94);
            this.lAccNo.Name = "lAccNo";
            this.lAccNo.Size = new System.Drawing.Size(33, 15);
            this.lAccNo.TabIndex = 7;
            this.lAccNo.Text = "Bank";
            // 
            // lBankName
            // 
            this.lBankName.AutoSize = true;
            this.lBankName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lBankName.ForeColor = System.Drawing.Color.Blue;
            this.lBankName.Location = new System.Drawing.Point(138, 56);
            this.lBankName.Name = "lBankName";
            this.lBankName.Size = new System.Drawing.Size(33, 15);
            this.lBankName.TabIndex = 5;
            this.lBankName.Text = "Bank";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(228, 56);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 15);
            this.label5.TabIndex = 4;
            this.label5.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(43, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Bank";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(43, 130);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Balance";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(43, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Account No";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(3, 19);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 164);
            this.splitter1.TabIndex = 10;
            this.splitter1.TabStop = false;
            // 
            // DisplaySavings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.title);
            this.Name = "DisplaySavings";
            this.Size = new System.Drawing.Size(389, 186);
            this.title.ResumeLayout(false);
            this.title.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private GroupBox title;
        private Label lAccType;
        private Label lBalance;
        private Label lAccNo;
        private Label lBankName;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Splitter splitter1;
    }
}
