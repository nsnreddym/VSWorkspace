namespace Financial_Status
{
    partial class Accounts_admin
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
            this.cbAccType = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbAccNo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbBank = new System.Windows.Forms.ComboBox();
            this.bAdd = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Sdate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.ROI = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbLnType = new System.Windows.Forms.ComboBox();
            this.NoEMI = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.EMI = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbLnAmt = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbAccType
            // 
            this.cbAccType.FormattingEnabled = true;
            this.cbAccType.Items.AddRange(new object[] {
            "Savings",
            "Consumer",
            "Loan"});
            this.cbAccType.Location = new System.Drawing.Point(122, 36);
            this.cbAccType.Name = "cbAccType";
            this.cbAccType.Size = new System.Drawing.Size(81, 23);
            this.cbAccType.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Account Type";
            // 
            // tbAccNo
            // 
            this.tbAccNo.Location = new System.Drawing.Point(122, 74);
            this.tbAccNo.Name = "tbAccNo";
            this.tbAccNo.Size = new System.Drawing.Size(168, 23);
            this.tbAccNo.TabIndex = 3;
            this.tbAccNo.TextChanged += new System.EventHandler(this.tbAccNo_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Account No";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(509, 39);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 15);
            this.label4.TabIndex = 7;
            this.label4.Text = "Bank/Institution";
            // 
            // cbBank
            // 
            this.cbBank.FormattingEnabled = true;
            this.cbBank.Items.AddRange(new object[] {
            "ICICI",
            "AXIS",
            "TGB",
            "SBI",
            "BajajFinserv",
            "LIC",
            "HDFC",
            "PHFL",
            "Cash"});
            this.cbBank.Location = new System.Drawing.Point(616, 36);
            this.cbBank.Name = "cbBank";
            this.cbBank.Size = new System.Drawing.Size(81, 23);
            this.cbBank.TabIndex = 8;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(227, 320);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(75, 23);
            this.bAdd.TabIndex = 9;
            this.bAdd.Text = "Add";
            this.bAdd.UseVisualStyleBackColor = true;
            this.bAdd.Click += new System.EventHandler(this.bAdd_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(323, 320);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 10;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(237, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "Nick Name";
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(314, 36);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(168, 23);
            this.tbName.TabIndex = 11;
            this.tbName.TextChanged += new System.EventHandler(this.tbName_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tbAccNo);
            this.groupBox1.Controls.Add(this.tbName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cbAccType);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cbBank);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 107);
            this.groupBox1.TabIndex = 13;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "BasicInfo";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Sdate);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.ROI);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.cbLnType);
            this.groupBox2.Controls.Add(this.NoEMI);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.EMI);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.tbLnAmt);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 179);
            this.groupBox2.TabIndex = 14;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LoanInfo";
            // 
            // Sdate
            // 
            this.Sdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Sdate.Location = new System.Drawing.Point(488, 13);
            this.Sdate.Name = "Sdate";
            this.Sdate.Size = new System.Drawing.Size(97, 23);
            this.Sdate.TabIndex = 25;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(451, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(31, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Date";
            // 
            // ROI
            // 
            this.ROI.Location = new System.Drawing.Point(367, 65);
            this.ROI.Name = "ROI";
            this.ROI.Size = new System.Drawing.Size(78, 23);
            this.ROI.TabIndex = 22;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(335, 73);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(26, 15);
            this.label10.TabIndex = 23;
            this.label10.Text = "ROI";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(275, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 15);
            this.label9.TabIndex = 21;
            this.label9.Text = "months";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(263, 19);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(60, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Loan Type";
            // 
            // cbLnType
            // 
            this.cbLnType.FormattingEnabled = true;
            this.cbLnType.Items.AddRange(new object[] {
            "PL",
            "HL",
            "CL",
            "VL"});
            this.cbLnType.Location = new System.Drawing.Point(333, 16);
            this.cbLnType.Name = "cbLnType";
            this.cbLnType.Size = new System.Drawing.Size(81, 23);
            this.cbLnType.TabIndex = 19;
            // 
            // NoEMI
            // 
            this.NoEMI.Location = new System.Drawing.Point(191, 65);
            this.NoEMI.Name = "NoEMI";
            this.NoEMI.Size = new System.Drawing.Size(78, 23);
            this.NoEMI.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(143, 73);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 15);
            this.label7.TabIndex = 18;
            this.label7.Text = "Tenure";
            // 
            // EMI
            // 
            this.EMI.Location = new System.Drawing.Point(48, 65);
            this.EMI.Name = "EMI";
            this.EMI.Size = new System.Drawing.Size(78, 23);
            this.EMI.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 73);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 15);
            this.label6.TabIndex = 16;
            this.label6.Text = "EMI";
            // 
            // tbLnAmt
            // 
            this.tbLnAmt.Location = new System.Drawing.Point(122, 16);
            this.tbLnAmt.Name = "tbLnAmt";
            this.tbLnAmt.Size = new System.Drawing.Size(120, 23);
            this.tbLnAmt.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "Loan Amount";
            // 
            // Accounts_admin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bCancel);
            this.Controls.Add(this.bAdd);
            this.Name = "Accounts_admin";
            this.Text = "Accounts_admin";
            this.Load += new System.EventHandler(this.Accounts_admin_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private ComboBox cbAccType;
        private Label label2;
        private TextBox tbAccNo;
        private Label label3;
        private Label label4;
        private ComboBox cbBank;
        private Button bAdd;
        private Button bCancel;
        private Label label1;
        private TextBox tbName;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private DateTimePicker Sdate;
        private Label label11;
        private TextBox ROI;
        private Label label10;
        private Label label9;
        private Label label8;
        private ComboBox cbLnType;
        private TextBox NoEMI;
        private Label label7;
        private TextBox EMI;
        private Label label6;
        private TextBox tbLnAmt;
        private Label label5;
    }
}