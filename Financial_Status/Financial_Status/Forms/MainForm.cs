using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using FinancialDataBase;
using Globals;
using Financial_Status.Forms.Users;

namespace Financial_Status
{
    public partial class MainForm : Form
    {
        ScrollBar vScrollBar1;
        ScrollBar hScrollBar1;


        public MainForm()
        {
            InitializeComponent();
        }

        #region DataBase functions
        
        #endregion

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Login login = new Login();

            //login.ShowDialog();

            //this.Text = "Financial Status: " + GlobalVar.UserName;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            this.Text = "Financial Status: Not Logged";            

            GlobalVar.DataBasePath = @"E:\Git_Repositories\VSWorkspace\Financial_Status\Financial_Status\database\Satya_Financial_v2.db";           

        }

        private void addTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTran addTran = new AddTran();
            addTran.Text = "ADD Transactions";
            addTran.Show();
        }

        private void statementToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts_admin addAccounts = new Accounts_admin();

            addAccounts.Add();
        }

        private void accountSummaryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccSummary accSummary = new AccSummary();
            accSummary.MdiParent = this;
            accSummary.Show();
        }
    }
}
