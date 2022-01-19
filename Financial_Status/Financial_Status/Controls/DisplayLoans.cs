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
            title.Text = DataBasedata.accountinfo[index].Name;
            title.Font = new Font("Courier New", 9, FontStyle.Bold);

            lBankName.Text = DataBasedata.accountinfo[index].LNInfo.Bank;
            lBankName.Font = title.Font;
            lAccNo.Text = DataBasedata.accountinfo[index].LNInfo.AccNo;
            lAccNo.Font = title.Font;
            switch (DataBasedata.accountinfo[index].LNInfo.LnType)
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

            lAmount.Text = DataBasedata.accountinfo[index].LNInfo.LoanAmount.ToString();
            lAmount.Font = title.Font;
            lBalance.Text = DataBasedata.accountinfo[index].LNInfo.Balance.ToString();
            lBalance.Font = title.Font;
            lEMIAmount.Text = DataBasedata.accountinfo[index].LNInfo.EMI.ToString();
            lEMIAmount.Font = title.Font;

            lNoEMI.Text = DataBasedata.accountinfo[index].LNInfo.Tenure.ToString();
            lNoEMI.Font = title.Font;
            lBEMIs.Text = DataBasedata.accountinfo[index].LNInfo.BEMI.ToString();
            lBEMIs.Font = title.Font;

            Show();
        }
    }
}
