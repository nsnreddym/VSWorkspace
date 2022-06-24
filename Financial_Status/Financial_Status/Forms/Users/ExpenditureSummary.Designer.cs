namespace Financial_Status.Forms.Users
{
    partial class ExpenditureSummary
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
            this.Account = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.Debit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Credit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Desc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.Sno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Date = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ControlBox2 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.ControlBox = new System.Windows.Forms.GroupBox();
            this.bExpand = new System.Windows.Forms.Button();
            this.bCollapse = new System.Windows.Forms.Button();
            this.tbYear = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.cbMonth = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataview = new System.Windows.Forms.DataGridView();
            this.DetailView = new System.Windows.Forms.DataGridView();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ControlBox2.SuspendLayout();
            this.ControlBox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailView)).BeginInit();
            this.SuspendLayout();
            // 
            // Account
            // 
            this.Account.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Account.HeaderText = "Account";
            this.Account.Name = "Account";
            this.Account.ReadOnly = true;
            this.Account.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Account.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Ttype
            // 
            this.Ttype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Ttype.HeaderText = "Transaction";
            this.Ttype.Name = "Ttype";
            this.Ttype.ReadOnly = true;
            this.Ttype.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Ttype.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(184, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 15);
            this.label3.TabIndex = 9;
            this.label3.Text = "Credit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(184, 99);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 15);
            this.label5.TabIndex = 7;
            this.label5.Text = "Debit";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(340, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Category";
            // 
            // Debit
            // 
            this.Debit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Debit.HeaderText = "Debit";
            this.Debit.Name = "Debit";
            this.Debit.ReadOnly = true;
            this.Debit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Debit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Credit
            // 
            this.Credit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Credit.HeaderText = "Credit";
            this.Credit.Name = "Credit";
            this.Credit.ReadOnly = true;
            this.Credit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Credit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Desc
            // 
            this.Desc.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Desc.HeaderText = "Description";
            this.Desc.Name = "Desc";
            this.Desc.ReadOnly = true;
            this.Desc.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Desc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Savings A/C";
            // 
            // Sno
            // 
            this.Sno.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Sno.HeaderText = "SNo";
            this.Sno.Name = "Sno";
            this.Sno.ReadOnly = true;
            this.Sno.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Sno.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Date
            // 
            this.Date.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Date.HeaderText = "Date";
            this.Date.Name = "Date";
            this.Date.ReadOnly = true;
            this.Date.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Date.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Category
            // 
            this.Category.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.Category.HeaderText = "Category";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Category.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // panel2
            // 
            this.panel2.AutoSize = true;
            this.panel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(398, 14);
            this.panel2.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 100);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.AutoSize = true;
            this.panel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.panel1.Controls.Add(this.ControlBox2);
            this.panel1.Controls.Add(this.ControlBox);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(794, 200);
            this.panel1.TabIndex = 0;
            // 
            // ControlBox2
            // 
            this.ControlBox2.Controls.Add(this.checkBox1);
            this.ControlBox2.Location = new System.Drawing.Point(453, 9);
            this.ControlBox2.Name = "ControlBox2";
            this.ControlBox2.Size = new System.Drawing.Size(245, 182);
            this.ControlBox2.TabIndex = 14;
            this.ControlBox2.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 22);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(113, 19);
            this.checkBox1.TabIndex = 0;
            this.checkBox1.Text = "Compare Report";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // ControlBox
            // 
            this.ControlBox.Controls.Add(this.bExpand);
            this.ControlBox.Controls.Add(this.bCollapse);
            this.ControlBox.Controls.Add(this.tbYear);
            this.ControlBox.Controls.Add(this.button1);
            this.ControlBox.Controls.Add(this.label8);
            this.ControlBox.Controls.Add(this.comboBox1);
            this.ControlBox.Controls.Add(this.cbMonth);
            this.ControlBox.Controls.Add(this.label6);
            this.ControlBox.Controls.Add(this.label7);
            this.ControlBox.Location = new System.Drawing.Point(9, 9);
            this.ControlBox.Name = "ControlBox";
            this.ControlBox.Size = new System.Drawing.Size(438, 182);
            this.ControlBox.TabIndex = 13;
            this.ControlBox.TabStop = false;
            // 
            // bExpand
            // 
            this.bExpand.Location = new System.Drawing.Point(301, 149);
            this.bExpand.Name = "bExpand";
            this.bExpand.Size = new System.Drawing.Size(95, 23);
            this.bExpand.TabIndex = 12;
            this.bExpand.Text = "Expand All";
            this.bExpand.UseVisualStyleBackColor = true;
            this.bExpand.Click += new System.EventHandler(this.bExpand_Click);
            // 
            // bCollapse
            // 
            this.bCollapse.Location = new System.Drawing.Point(191, 149);
            this.bCollapse.Name = "bCollapse";
            this.bCollapse.Size = new System.Drawing.Size(95, 23);
            this.bCollapse.TabIndex = 11;
            this.bCollapse.Text = "Collapse All";
            this.bCollapse.UseVisualStyleBackColor = true;
            this.bCollapse.Click += new System.EventHandler(this.bCollapse_Click);
            // 
            // tbYear
            // 
            this.tbYear.Location = new System.Drawing.Point(257, 62);
            this.tbYear.Name = "tbYear";
            this.tbYear.Size = new System.Drawing.Size(88, 23);
            this.tbYear.TabIndex = 10;
            this.tbYear.Text = "2022";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(84, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Show";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(208, 65);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 15);
            this.label8.TabIndex = 9;
            this.label8.Text = "Year";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Debit",
            "Credit",
            "All"});
            this.comboBox1.Location = new System.Drawing.Point(84, 101);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(99, 23);
            this.comboBox1.TabIndex = 5;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // cbMonth
            // 
            this.cbMonth.FormattingEnabled = true;
            this.cbMonth.Items.AddRange(new object[] {
            "Jan",
            "Feb",
            "Mar",
            "Apr",
            "May",
            "Jun",
            "Jul",
            "Aug",
            "Sep",
            "Oct",
            "Nov",
            "Dec"});
            this.cbMonth.Location = new System.Drawing.Point(84, 62);
            this.cbMonth.Name = "cbMonth";
            this.cbMonth.Size = new System.Drawing.Size(99, 23);
            this.cbMonth.TabIndex = 8;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(11, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(67, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Transaction";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 65);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(43, 15);
            this.label7.TabIndex = 7;
            this.label7.Text = "Month";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 45.77778F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 54.22222F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 64.9874F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35.0126F));
            this.tableLayoutPanel3.Controls.Add(this.dataview, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.DetailView, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 209);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(794, 238);
            this.tableLayoutPanel3.TabIndex = 1;
            // 
            // dataview
            // 
            this.dataview.AllowUserToAddRows = false;
            this.dataview.AllowUserToDeleteRows = false;
            this.dataview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataview.Location = new System.Drawing.Point(3, 3);
            this.dataview.Name = "dataview";
            this.dataview.ReadOnly = true;
            this.dataview.RowHeadersVisible = false;
            this.dataview.RowTemplate.Height = 25;
            this.dataview.Size = new System.Drawing.Size(509, 232);
            this.dataview.TabIndex = 2;
            // 
            // DetailView
            // 
            this.DetailView.AllowUserToAddRows = false;
            this.DetailView.AllowUserToDeleteRows = false;
            this.DetailView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DetailView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DetailView.Location = new System.Drawing.Point(518, 3);
            this.DetailView.Name = "DetailView";
            this.DetailView.ReadOnly = true;
            this.DetailView.RowHeadersVisible = false;
            this.DetailView.RowTemplate.Height = 25;
            this.DetailView.Size = new System.Drawing.Size(273, 232);
            this.DetailView.TabIndex = 3;
            // 
            // ExpenditureSummary
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "ExpenditureSummary";
            this.Text = "ExpenditureSummary";
            this.Load += new System.EventHandler(this.ExpenditureSummary_Load);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ControlBox2.ResumeLayout(false);
            this.ControlBox2.PerformLayout();
            this.ControlBox.ResumeLayout(false);
            this.ControlBox.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DetailView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DataGridViewTextBoxColumn Account;
        private DataGridViewTextBoxColumn Ttype;
        private Label label3;
        private Label label5;
        private Label label2;
        private DataGridViewTextBoxColumn Debit;
        private DataGridViewTextBoxColumn Credit;
        private DataGridViewTextBoxColumn Desc;
        private Label label1;
        private DataGridViewTextBoxColumn Sno;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Category;
        private Panel panel2;
        private TableLayoutPanel tableLayoutPanel2;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
        private Button button1;
        private DataGridView dataview;
        private Label label6;
        private ComboBox comboBox1;
        private ComboBox cbMonth;
        private Label label7;
        private TextBox tbYear;
        private Label label8;
        private Button bExpand;
        private Button bCollapse;
        private GroupBox ControlBox;
        private GroupBox ControlBox2;
        private CheckBox checkBox1;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView DetailView;
    }
}