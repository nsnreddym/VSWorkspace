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

namespace Financial_Status
{
    public partial class MainForm : Form
    {
      
        public MainForm()
        {
            InitializeComponent();
        }

        #region DataBase functions
        private void Show_Accounts()
        {
            DisplaySavings[] displayAccounts = new DisplaySavings[GlobalVar.dataBasedata.noAccounts];

            /*DisplaySavings test = new DisplaySavings();
            test.Location = new Point(100,100);
            test.Parent = this;
            test.DisplaySavingsAccount(0); */


           for (int i = 0; i < GlobalVar.dataBasedata.noAccounts; i++)
            {
                displayAccounts[i] = new DisplaySavings();
                panel1.Controls.Add(displayAccounts[i]);
                displayAccounts[i].DisplaySavingsAccount(i);
            }

            GlobalVar.MaxTables = GlobalVar.dataBasedata.noAccounts;

        }
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
            

            //Read Accounts
            GlobalVar.dataBasedata.ReadAccounts();

            Show_Accounts();

        }

        private void addTransactionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void statementToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Accounts_admin addAccounts = new Accounts_admin();

            addAccounts.Add();
        }
    }
}
