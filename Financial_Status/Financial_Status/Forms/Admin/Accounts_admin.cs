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
using FinancialDataBase;
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
            #endregion

        #region ADD functions

        public void Add()
        {
            this.Text = "Add Account";
            bAdd.Enabled = false;
            cbAccType.SelectedIndex = 0;
            cbBank.SelectedIndex = 0;
            gbLoanInfo.Enabled = false;
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
            bool status;
            status = DataBasedata.AddAccountInfo(cbAccType.Text.ToString(), tbName.Text);

            if (status == true)
            {

                switch (cbAccType.Text.ToString())
                {
                    case "Savings":
                        DataBasedata.AddSavingsInfo(tbName.Text, tbAccNo.Text, cbBank.Text);
                        DataBasedata.CreateNewSavingsAccount(tbName.Text);
                        break;

                    case "FDCard":
                        DataBasedata.AddFoodInfo(tbName.Text, tbAccNo.Text, cbBank.Text);
                        DataBasedata.CreateNewSavingsAccount(tbName.Text);
                        break;

                    case "Loan":
                        DataBasedata.AddLoanInfo(tbName.Text, tbAccNo.Text, cbBank.Text, tbLnAmt.Text, EMI.Text, Sdate.Value,NoEMI.Text, cbLnType.Text, ROI.Text);
                        DataBasedata.CreateNewLoanAccount(tbName.Text);
                        break;

                    default:
                        status = false;
                        break;
                }
            }

            if(status == false)
            {
                MessageBox.Show("Unable to create account");
            }
            else
            {
                MessageBox.Show("Account:" + tbName.Text + " Created.");
            }

        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        private void cbAccType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if( cbAccType.SelectedItem.ToString() == "Loan")
            {
                gbLoanInfo.Enabled = true;
            }
            else
            {
                gbLoanInfo.Enabled = false;
            }
        }
    }
}
