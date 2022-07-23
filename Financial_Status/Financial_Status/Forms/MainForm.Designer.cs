namespace Financial_Status
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.financialToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addTransactionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.accountSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loanSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.transactionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlyBudgetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.expenditureSummaryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem,
            this.financialToolStripMenuItem,
            this.accountsToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // financialToolStripMenuItem
            // 
            this.financialToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addTransactionToolStripMenuItem});
            this.financialToolStripMenuItem.Enabled = false;
            this.financialToolStripMenuItem.Name = "financialToolStripMenuItem";
            this.financialToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.financialToolStripMenuItem.Text = "Financial";
            // 
            // addTransactionToolStripMenuItem
            // 
            this.addTransactionToolStripMenuItem.Name = "addTransactionToolStripMenuItem";
            this.addTransactionToolStripMenuItem.Size = new System.Drawing.Size(159, 22);
            this.addTransactionToolStripMenuItem.Text = "Add Transaction";
            this.addTransactionToolStripMenuItem.Click += new System.EventHandler(this.addTransactionToolStripMenuItem_Click);
            // 
            // accountsToolStripMenuItem
            // 
            this.accountsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addToolStripMenuItem});
            this.accountsToolStripMenuItem.Enabled = false;
            this.accountsToolStripMenuItem.Name = "accountsToolStripMenuItem";
            this.accountsToolStripMenuItem.Size = new System.Drawing.Size(69, 20);
            this.accountsToolStripMenuItem.Text = "Accounts";
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(96, 22);
            this.addToolStripMenuItem.Text = "Add";
            this.addToolStripMenuItem.Click += new System.EventHandler(this.addToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.accountSummaryToolStripMenuItem,
            this.loanSummaryToolStripMenuItem,
            this.transactionsToolStripMenuItem,
            this.monthlyBudgetToolStripMenuItem,
            this.expenditureSummaryToolStripMenuItem});
            this.viewToolStripMenuItem.Enabled = false;
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // accountSummaryToolStripMenuItem
            // 
            this.accountSummaryToolStripMenuItem.Name = "accountSummaryToolStripMenuItem";
            this.accountSummaryToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.accountSummaryToolStripMenuItem.Text = "Account Summary";
            this.accountSummaryToolStripMenuItem.Click += new System.EventHandler(this.accountSummaryToolStripMenuItem_Click);
            // 
            // loanSummaryToolStripMenuItem
            // 
            this.loanSummaryToolStripMenuItem.Name = "loanSummaryToolStripMenuItem";
            this.loanSummaryToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.loanSummaryToolStripMenuItem.Text = "Loan Summary";
            this.loanSummaryToolStripMenuItem.Click += new System.EventHandler(this.loanSummaryToolStripMenuItem_Click);
            // 
            // transactionsToolStripMenuItem
            // 
            this.transactionsToolStripMenuItem.Name = "transactionsToolStripMenuItem";
            this.transactionsToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.transactionsToolStripMenuItem.Text = "Transactions";
            this.transactionsToolStripMenuItem.Click += new System.EventHandler(this.transactionsToolStripMenuItem_Click);
            // 
            // monthlyBudgetToolStripMenuItem
            // 
            this.monthlyBudgetToolStripMenuItem.Name = "monthlyBudgetToolStripMenuItem";
            this.monthlyBudgetToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.monthlyBudgetToolStripMenuItem.Text = "Monthly Budget";
            this.monthlyBudgetToolStripMenuItem.Click += new System.EventHandler(this.monthlyBudgetToolStripMenuItem_Click);
            // 
            // expenditureSummaryToolStripMenuItem
            // 
            this.expenditureSummaryToolStripMenuItem.Name = "expenditureSummaryToolStripMenuItem";
            this.expenditureSummaryToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.expenditureSummaryToolStripMenuItem.Text = "Expenditure Summary";
            this.expenditureSummaryToolStripMenuItem.Click += new System.EventHandler(this.expenditureSummaryToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.LoginForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem financialToolStripMenuItem;
        private ToolStripMenuItem addTransactionToolStripMenuItem;
        private ToolStripMenuItem accountsToolStripMenuItem;
        private ToolStripMenuItem addToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private ToolStripMenuItem accountSummaryToolStripMenuItem;
        private ToolStripMenuItem transactionsToolStripMenuItem;
        private ToolStripMenuItem monthlyBudgetToolStripMenuItem;
        private ToolStripMenuItem expenditureSummaryToolStripMenuItem;
        private ToolStripMenuItem loanSummaryToolStripMenuItem;
    }
}