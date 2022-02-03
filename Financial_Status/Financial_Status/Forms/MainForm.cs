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
using Financial_Status.Forms.Admin;

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

        public void Settings_Read()
        {
            StreamReader sw;
            int index;
            int index2;
            string str;
            sw = File.OpenText(".\\Settings.ini");
            str = sw.ReadLine();
            index = str.IndexOf(':');
            index2 = str.Length - index - 1;
            GlobalVar.DataBasePath = str.Substring(index + 1, index2);
            sw.Close();
        }

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

            string path = @".\Settings.ini";
            if (!File.Exists(path))
            {
                MessageBox.Show("Settings File not exist");
                return;
            }
            Settings_Read();

            if (!File.Exists(GlobalVar.DataBasePath))
            {
                MessageBox.Show("Database File not exist");
                return;
            }

            financialToolStripMenuItem.Enabled = true;
            viewToolStripMenuItem.Enabled = true;
            accountsToolStripMenuItem.Enabled = true;

            GlobalVar.DataBasePath = @"E:\Git_Repositories\VSWorkspace\Financial_Status\Financial_Status\database\Satya_Financial_v2.db";    
            GlobalVar.IsLogged = false;
            if (GlobalVar.logrequired == true)
            {
                Login login = new Login();

                login.ShowDialog();

                if (false == GlobalVar.IsLogged)
                {
                    this.Close();
                }
                else
                {
                    this.Text = "Financial Status:" + GlobalVar.UserName;

                    if(GlobalVar.UserName == "Admin")
                    {
                        accountsToolStripMenuItem.Visible = true;
                    }
                    else
                    {
                        accountsToolStripMenuItem.Visible = false;
                    }
                }
                
            }
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

        private void transactionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewTran viewTran = new ViewTran();
            viewTran.MdiParent = this;
            viewTran.Show();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Settings settings = new Settings();
            settings.ShowDialog();
        }

        private void monthlyBudgetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlyBudget monthlyBudget = new MonthlyBudget();
            monthlyBudget.MdiParent = this;
            monthlyBudget.Show();
        }
    }
}
