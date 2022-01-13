using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using SQLLiteConn_namespace;
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
#if false
            DataBaseConn d = new();
            DataBaseConn.Errors error;

            error = d.CheckLoginCredentials(tbUserName.Text, tbPasswd.Text);

            if((int)error != 0)
            {
                MessageBox.Show(error.ToString());
            }
            else
            {
                GlobalVar.UserName = tbUserName.Text;
                this.Close();
            }         
#endif
        }

        private void Login_Load(object sender, EventArgs e)
        {
            
        }
    }
}
