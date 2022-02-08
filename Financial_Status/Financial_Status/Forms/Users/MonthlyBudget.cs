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
            List<BDGInfoData> bDGInfoData;
            List<AccountInfoData> accountinfo;
            WindowState = FormWindowState.Maximized;

            //Read Accounts
            bDGInfoData = DataBasedata.ReadBudget();
            accountinfo = DataBasedata.ReadAccountInfo();
            dataView.Rows.Clear();

            sno = 0;
            debit = 0;
            credit = 0;
            for (int i = 0; i < accountinfo.Count; i++)
            {
                switch (accountinfo[i].Type)
                {
                    case "Savings":

                        if (accountinfo[i].SAInfo.Balance != 0)
                        {
                            dataView.Rows.Add();
                            dataView.Rows[sno].Cells[0].Value = sno + 1;
                            dataView.Rows[sno].Cells[1].Value = accountinfo[i].Name;
                            dataView.Rows[sno].Cells[3].Value = accountinfo[i].SAInfo.Balance.ToString();
                            credit = credit +  accountinfo[i].SAInfo.Balance;
                            sno++;
                        }

                        break;

                    case "Loan":
                        
                        break;

                    default:
                        break;
                }
            }

            for (int i = 0; i < bDGInfoData.Count; i++)
            {
                dataView.Rows.Add();
                dataView.Rows[sno].Cells[0].Value = sno + 1;
                dataView.Rows[sno].Cells[1].Value = bDGInfoData[i].Name;
                dataView.Rows[sno].Cells[2].Value = bDGInfoData[i].EMI.ToString();
                debit = debit + bDGInfoData[i].EMI;
                sno++;
            }



            lbBalance.Text = "Rs. " + (credit - debit).ToString("N");
            lbDebit.Text = "Rs. " + (debit).ToString("N");
            lbCredit.Text = "Rs. " + (credit).ToString("N");
        }
    }
}
