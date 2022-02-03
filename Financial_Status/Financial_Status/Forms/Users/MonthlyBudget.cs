using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Globals;
using FinancialDataBase;

namespace Financial_Status
{
    public partial class MonthlyBudget : Form
    {
        public MonthlyBudget()
        {
            InitializeComponent();
        }

        private void MonthlyBudget_Load(object sender, EventArgs e)
        {
            int sno;
            double credit;
            double debit;
            WindowState = FormWindowState.Maximized;

            //Read Accounts
            DataBasedata.ReadAccountInfo();
            dataView.Rows.Clear();

            sno = 0;
            debit = 0;
            credit = 0;
            for (int i = 0; i < DataBasedata.accountinfo.Count; i++)
            {
                switch (DataBasedata.accountinfo[i].Type)
                {
                    case "Savings":

                        if (DataBasedata.accountinfo[i].SAInfo.Balance != 0)
                        {
                            dataView.Rows.Add();
                            dataView.Rows[sno].Cells[0].Value = sno + 1;
                            dataView.Rows[sno].Cells[1].Value = DataBasedata.accountinfo[i].Name;
                            dataView.Rows[sno].Cells[3].Value = DataBasedata.accountinfo[i].SAInfo.Balance.ToString();
                            credit = credit +  DataBasedata.accountinfo[i].SAInfo.Balance;
                            sno++;
                        }

                        break;

                    case "Loan":

                        if (DataBasedata.accountinfo[i].LNInfo.Balance != 0)
                        {
                            dataView.Rows.Add();
                            dataView.Rows[sno].Cells[0].Value = sno + 1;
                            dataView.Rows[sno].Cells[1].Value = DataBasedata.accountinfo[i].Name;
                            dataView.Rows[sno].Cells[2].Value = DataBasedata.accountinfo[i].LNInfo.EMI.ToString();
                            debit = debit + DataBasedata.accountinfo[i].LNInfo.EMI;
                            sno++;
                        }

                        break;

                    default:
                        break;
                }
            }

            lbBalance.Text = "Rs. " + (credit - debit).ToString("N");
            lbDebit.Text = "Rs. " + (debit).ToString("N");
            lbCredit.Text = "Rs. " + (credit).ToString("N");
        }


    }
}
