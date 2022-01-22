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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Errors error;

            error = DataBasedata.CheckLoginCredentials(tbUserName.Text, tbPasswd.Text);

            if((int)error != 0)
            {
                MessageBox.Show(error.ToString());
                GlobalVar.IsLogged = false;
            }
            else
            {
                GlobalVar.UserName = tbUserName.Text;
                GlobalVar.IsLogged = true;
                Close();
            }         
        }

        private void Login_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
        }

        private void tbPasswd_MouseClick(object sender, MouseEventArgs e)
        {
            tbPasswd.Clear();
        }
    }
}
