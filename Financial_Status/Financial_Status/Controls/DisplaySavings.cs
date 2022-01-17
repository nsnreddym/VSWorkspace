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

        public void DisplaySavingsAccount(int x, int y, int index)
        {
            Location = new Point(x, y);
            groupBox1.Text = DataBasedata.accountinfo[index].Name;
            
            lBankName.Text = DataBasedata.accountinfo[index].SAInfo.Bank;
            lAccNo.Text = DataBasedata.accountinfo[index].SAInfo.AccNo;
            lAccType.Text = DataBasedata.accountinfo[index].Type;
            lBalance.Text = DataBasedata.accountinfo[index].SAInfo.Balance.ToString();

            Show();
        }

    }
}
