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
using System.Data.SQLite;
using Globals;

namespace Financial_Status
{
    public partial class Accounts_admin : Form
    {
        public Accounts_admin()
        {
            InitializeComponent();
        }

        private void Accounts_admin_Load(object sender, EventArgs e)
        {

        }

        #region DataBase functions
        private void CreateNewAccount(string ACCType, String Name, string ACCNo, string Bank)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath  + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();
            SQLiteCommand cmd2 = conn.CreateCommand();

            if (ACCType == "Savings")
            {
                cmd.CommandText = @"Create Table " + Name + " as select * from SavingsType";
                cmd2.CommandText = @"Insert into Account_Info (Type, Name, AccountNo, Bank, DataTable) Values (" + " '" +
                                     ACCType + "', '" +
                                     Name    + "', " +
                                     ACCNo   +", '" +
                                     Bank    + "', '" + 
                                     Name    + "');";
            }

            cmd.ExecuteNonQuery();
            cmd2.ExecuteNonQuery();

            conn.Close();

        }
        #endregion

        #region ADD functions

        public void Add()
        {
            this.Text = "Add Account";
            bAdd.Enabled = false;
            cbAccType.SelectedIndex = 0;
            cbBank.SelectedIndex = 0;
            this.ShowDialog();
        }

        private void tbAccNo_TextChanged(object sender, EventArgs e)
        {
            if((tbAccNo.Text != String.Empty) && (tbName.Text != String.Empty))
            {
                bAdd.Enabled = true;
            }
            else
            {
                bAdd.Enabled = false;
            }
        }

        private void tbName_TextChanged(object sender, EventArgs e)
        {
            if ((tbAccNo.Text != String.Empty) && (tbName.Text != String.Empty))
            {
                bAdd.Enabled = true;
            }
            else
            {
                bAdd.Enabled = false;
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            CreateNewAccount(cbAccType.Text.ToString(), tbName.Text, tbAccNo.Text, cbBank.Text);
        }

        #endregion



        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
