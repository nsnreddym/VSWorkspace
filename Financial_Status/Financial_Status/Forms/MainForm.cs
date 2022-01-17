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
        ScrollBar vScrollBar1;
        ScrollBar hScrollBar1;


        public MainForm()
        {
            InitializeComponent();
        }

        #region DataBase functions
        private void Display_Account_Pallete()
        {
            int x, y, indx;

            DisplaySavings[] displaySAs = new DisplaySavings[DataBasedata.accountinfo.Count];
            DisplayLoans[] displayLAs = new DisplayLoans[DataBasedata.accountinfo.Count];

            x = 10;
            y = 10;
            indx = 0;


            for (int i = 0; i < DataBasedata.accountinfo.Count; i++)
            {                
                switch (DataBasedata.accountinfo[i].Type)
                {
                    case "Savings":
                        displaySAs[i] = new DisplaySavings();
                                                                     
                        panel1.Controls.Add(displaySAs[i]);
                        displaySAs[i].DisplaySavingsAccount(x,y,i);

                        x = x + displaySAs[i].Size.Width + 10;

                        if((x + displaySAs[i].Size.Width) > Size.Width)
                        {
                            y = y + displaySAs[i].Size.Height + 10;
                            x = 10;
                        }

                        break;

                    case "Loan":
                        displayLAs[i] = new DisplayLoans();
                                                                     
                        panel1.Controls.Add(displayLAs[i]);
                        displayLAs[i].DisplayLoansAccount(x,y,i);

                        x = x + displayLAs[i].Size.Width + 10;

                        if((x + displayLAs[i].Size.Width) > Size.Width)
                        {
                            y = y + displayLAs[i].Size.Height + 10;
                            x = 10;
                        }

                        break;

                    default:
                    break;
                }                
            }

            GlobalVar.MaxTables = DataBasedata.accountinfo.Count;

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

            panel1.AutoScroll = false;
            vScrollBar1 = new VScrollBar();
            vScrollBar1.Dock = DockStyle.Right;
            vScrollBar1.Maximum = Size.Height;
            vScrollBar1.Minimum = 0;

            hScrollBar1 = new HScrollBar();
            hScrollBar1.Dock = DockStyle.Bottom;
            hScrollBar1.Maximum = Size.Width;
            hScrollBar1.Minimum = 0;;

            panel1.AutoScroll = true;

            panel1.Dock = DockStyle.Fill;

            GlobalVar.DataBasePath = @"E:\Git_Repositories\VSWorkspace\Financial_Status\Financial_Status\database\Satya_Financial_v2.db";

            //Read Accounts
            DataBasedata.ReadAccountInfo();

            Display_Account_Pallete();

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

        private void panel1_SizeChanged(object sender, EventArgs e)
        {            
            vScrollBar1.Maximum = Size.Height;
            
            hScrollBar1.Maximum = Size.Width;
        }
    }
}
