using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


using FinancialDataBase;
using Globals;

namespace Financial_Status
{
    public partial class DisplayLoans : UserControl
    {
        public DisplayLoans()
        {
            InitializeComponent();
        }

        public void DisplayLoansAccount(int x, int y, int index)
        {
            Location = new Point(x, y);
            groupBox1.Text = DataBasedata.accountinfo[index].Name;

            lBankName.Text = DataBasedata.accountinfo[index].LNInfo.Bank;
            lAccNo.Text = DataBasedata.accountinfo[index].LNInfo.AccNo;
            switch(DataBasedata.accountinfo[index].LNInfo.LnType)
            {
                case "PL":
                    lAccType.Text = "Personal Loan";
                    break;

                case "HL":
                    lAccType.Text = "Housing Loan";
                    break;

                case "CL":
                    lAccType.Text = "Consumer Loan";
                    break;
            }
            


            lAmount.Text = DataBasedata.accountinfo[index].LNInfo.LoanAmount.ToString();
            lBalance.Text = DataBasedata.accountinfo[index].LNInfo.Balance.ToString();
            lEMIAmount.Text = DataBasedata.accountinfo[index].LNInfo.EMI.ToString();

            lNoEMI.Text = DataBasedata.accountinfo[index].LNInfo.Tenure.ToString();
            lBEMIs.Text = DataBasedata.accountinfo[index].LNInfo.Tenure.ToString();

            Show();
        }
    }
}
