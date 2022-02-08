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
    public partial class DisplaySavings : UserControl
    {
        public DisplaySavings()
        {
            InitializeComponent();
        }

        public void DisplaySavingsAccount(List<AccountInfoData> accountinfo, int x, int y, int index)
        {
            Location = new Point(x, y);
            title.Text = accountinfo[index].Name;
            //title.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            title.Font = new Font("Courier New", 9, FontStyle.Bold);
            
            lBankName.Text = accountinfo[index].SAInfo.Bank;
            lAccNo.Text = accountinfo[index].SAInfo.AccNo;
            lAccType.Text = accountinfo[index].Type;
            lBalance.Text = "Rs. " + accountinfo[index].SAInfo.Balance.ToString("N");

            lBankName.Font = title.Font;
            lAccNo.Font = title.Font;
            lAccType.Font = title.Font;
            lBalance.Font = title.Font;

            Show();
        }

    }
}
