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

        public void DisplaySavingsAccount(int index)
        {
            int x;
            int y;

            x = 10 + index* (Size.Width + 50);
            y = 20;

            Location = new Point(x, y);
            groupBox1.Text = GlobalVar.dataBasedata.accountinfo[index].Name;
            lBankName.Text = GlobalVar.dataBasedata.accountinfo[index].Bank;
            lAccNo.Text = GlobalVar.dataBasedata.accountinfo[index].AccountNo;
            lAccType.Text = GlobalVar.dataBasedata.accountinfo[index].Type;
            lNickName.Text = GlobalVar.dataBasedata.accountinfo[index].Name;


            lBalance.Text = "0";

            Show();
        }

        private void lBankName_Click(object sender, EventArgs e)
        {

        }
    }
}
