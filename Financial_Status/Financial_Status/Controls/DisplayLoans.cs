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

        public void DisplayLoansAccount(List<AccountInfoData> accountinfo, int x, int y, int index)
        {
            Location = new Point(x, y);
            title.Text = accountinfo[index].Name;
            title.Font = new Font("Courier New", 9, FontStyle.Bold);

            lBankName.Text = accountinfo[index].LNInfo.Bank;
            lBankName.Font = title.Font;
            lAccNo.Text = accountinfo[index].LNInfo.AccNo;
            lAccNo.Font = title.Font;
            switch (accountinfo[index].LNInfo.LnType)
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
            lAccType.Font = title.Font;

            lAmount.Text = "Rs. " + accountinfo[index].LNInfo.LoanAmount.ToString("N");
            lAmount.Font = title.Font;
            lBalance.Text = "Rs. " + accountinfo[index].LNInfo.Balance.ToString("N");
            lBalance.Font = title.Font;
            lEMIAmount.Text = "Rs. " + accountinfo[index].LNInfo.EMI.ToString("N");
            lEMIAmount.Font = title.Font;

            lNoEMI.Text = accountinfo[index].LNInfo.Tenure.ToString();
            lNoEMI.Font = title.Font;
            lBEMIs.Text = accountinfo[index].LNInfo.BEMI.ToString();
            lBEMIs.Font = title.Font;

            Show();
        }
    }
}
