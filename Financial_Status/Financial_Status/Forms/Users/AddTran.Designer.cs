namespace Financial_Status
{
    partial class AddTran
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAccount = new System.Windows.Forms.ComboBox();
            this.tbAmount = new System.Windows.Forms.TextBox();
            this.tbDesc = new System.Windows.Forms.TextBox();
            this.bSave = new System.Windows.Forms.Button();
            this.bCancel = new System.Windows.Forms.Button();
            this.cbTranType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbDate = new System.Windows.Forms.DateTimePicker();
            this.cbCategory = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.cbCreditAC = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lbBal = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Account No";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Amount";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(52, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "Description";
            // 
            // cbAccount
            // 
            this.cbAccount.FormattingEnabled = true;
            this.cbAccount.Location = new System.Drawing.Point(89, 23);
            this.cbAccount.Name = "cbAccount";
            this.cbAccount.Size = new System.Drawing.Size(121, 23);
            this.cbAccount.TabIndex = 4;
            this.cbAccount.TabStop = false;
            this.cbAccount.SelectedIndexChanged += new System.EventHandler(this.cbAccount_SelectedIndexChanged);
            // 
            // tbAmount
            // 
            this.tbAmount.Location = new System.Drawing.Point(89, 106);
            this.tbAmount.Name = "tbAmount";
            this.tbAmount.Size = new System.Drawing.Size(100, 23);
            this.tbAmount.TabIndex = 5;
            // 
            // tbDesc
            // 
            this.tbDesc.Location = new System.Drawing.Point(89, 151);
            this.tbDesc.Multiline = true;
            this.tbDesc.Name = "tbDesc";
            this.tbDesc.Size = new System.Drawing.Size(190, 61);
            this.tbDesc.TabIndex = 7;
            // 
            // bSave
            // 
            this.bSave.Location = new System.Drawing.Point(91, 238);
            this.bSave.Name = "bSave";
            this.bSave.Size = new System.Drawing.Size(75, 23);
            this.bSave.TabIndex = 8;
            this.bSave.Text = "Save";
            this.bSave.UseVisualStyleBackColor = true;
            this.bSave.Click += new System.EventHandler(this.bSave_Click);
            // 
            // bCancel
            // 
            this.bCancel.Location = new System.Drawing.Point(183, 238);
            this.bCancel.Name = "bCancel";
            this.bCancel.Size = new System.Drawing.Size(75, 23);
            this.bCancel.TabIndex = 9;
            this.bCancel.Text = "Cancel";
            this.bCancel.UseVisualStyleBackColor = true;
            this.bCancel.Click += new System.EventHandler(this.bCancel_Click);
            // 
            // cbTranType
            // 
            this.cbTranType.FormattingEnabled = true;
            this.cbTranType.Items.AddRange(new object[] {
            "Dr",
            "Cr",
            "Tr_SA",
            "Tr_LN"});
            this.cbTranType.Location = new System.Drawing.Point(90, 66);
            this.cbTranType.Name = "cbTranType";
            this.cbTranType.Size = new System.Drawing.Size(48, 23);
            this.cbTranType.TabIndex = 10;
            this.cbTranType.SelectedIndexChanged += new System.EventHandler(this.cbTranType_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(280, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 15);
            this.label5.TabIndex = 11;
            this.label5.Text = "Date";
            // 
            // cbDate
            // 
            this.cbDate.CustomFormat = "DD/MMM/YY";
            this.cbDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.cbDate.Location = new System.Drawing.Point(317, 20);
            this.cbDate.Name = "cbDate";
            this.cbDate.Size = new System.Drawing.Size(113, 23);
            this.cbDate.TabIndex = 12;
            // 
            // cbCategory
            // 
            this.cbCategory.FormattingEnabled = true;
            this.cbCategory.Location = new System.Drawing.Point(264, 107);
            this.cbCategory.Name = "cbCategory";
            this.cbCategory.Size = new System.Drawing.Size(82, 23);
            this.cbCategory.TabIndex = 14;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(203, 112);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 15);
            this.label6.TabIndex = 13;
            this.label6.Text = "Category";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.lbBal);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.bCancel);
            this.panel1.Controls.Add(this.bSave);
            this.panel1.Controls.Add(this.cbCategory);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.tbDesc);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbCreditAC);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbAccount);
            this.panel1.Controls.Add(this.cbDate);
            this.panel1.Controls.Add(this.cbTranType);
            this.panel1.Controls.Add(this.tbAmount);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 280);
            this.panel1.TabIndex = 15;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(187, 69);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 15);
            this.label7.TabIndex = 13;
            this.label7.Text = "Transfer to";
            // 
            // cbCreditAC
            // 
            this.cbCreditAC.FormattingEnabled = true;
            this.cbCreditAC.Location = new System.Drawing.Point(264, 66);
            this.cbCreditAC.Name = "cbCreditAC";
            this.cbCreditAC.Size = new System.Drawing.Size(121, 23);
            this.cbCreditAC.TabIndex = 14;
            this.cbCreditAC.TabStop = false;
            this.cbCreditAC.SelectedIndexChanged += new System.EventHandler(this.cbCreditAC_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(285, 197);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 15);
            this.label8.TabIndex = 15;
            this.label8.Text = "Balance";
            // 
            // lbBal
            // 
            this.lbBal.AutoSize = true;
            this.lbBal.Location = new System.Drawing.Point(339, 197);
            this.lbBal.Name = "lbBal";
            this.lbBal.Size = new System.Drawing.Size(0, 15);
            this.lbBal.TabIndex = 16;
            // 
            // AddTran
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(454, 280);
            this.Controls.Add(this.panel1);
            this.Name = "AddTran";
            this.Text = "AddTran";
            this.Load += new System.EventHandler(this.AddTran_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private ComboBox cbAccount;
        private TextBox tbAmount;
        private TextBox tbDesc;
        private Button bSave;
        private Button bCancel;
        private ComboBox cbTranType;
        private Label label5;
        private DateTimePicker cbDate;
        private ComboBox cbCategory;
        private Label label6;
        private Panel panel1;
        private Label label7;
        private ComboBox cbCreditAC;
        private Label lbBal;
        private Label label8;
    }
}