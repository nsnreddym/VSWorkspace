﻿using System;
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
    public partial class AddTran : Form
    {
        public AddTran()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ResetControls()
        {
            cbAccount.SelectedIndex = 0;

            cbTranType.Enabled = true;
            cbTranType.SelectedIndex = 0;

            cbCreditAC.Enabled = false;

            tbAmount.Enabled = true;
            tbAmount.Text = "";

            cbCategory.Enabled = true;
            cbCategory.SelectedIndex = 0;

            tbDesc.Enabled = true;

            bSave.Enabled = true;
            bCancel.Enabled = true;
        }

        private void AddTran_Load(object sender, EventArgs e)
        {
            
            //Get Savings Account details
            List <string> data = DataBasedata.GetSavingsAC();

            for(int cnt = 0; cnt < data.Count; cnt++)
            {
                cbAccount.Items.Add(data[cnt]);
            }

            

            foreach (var item in Enum.GetValues(typeof(FinancialDataBase.Category)))
            {
                cbCategory.Items.Add(item);
            }

            ResetControls();

        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            SavingsAccData savingsdata = new SavingsAccData();

            savingsdata.date = cbDate.Value;
            savingsdata.Amount = Convert.ToDouble(tbAmount.Text);            
            savingsdata.Category = (Category)cbCategory.SelectedItem;


            if (cbTranType.SelectedItem.ToString() == "Tr_LN")
            {
                //Update in loan account
                DataBasedata.AddLoanRecord(cbCreditAC.SelectedItem.ToString(), cbDate.Value.ToString("yyyy-0:mm-dd"), tbAmount.Text);
                DataBasedata.UpdateBudget(cbCreditAC.SelectedItem.ToString());

                //Update in debit savings account
                savingsdata.TranType = TransType.Dr; 
                savingsdata.Description = "Transfer to Loan Account: " + cbCreditAC.SelectedItem.ToString();
                DataBasedata.AddSavingsRecord(cbAccount.SelectedItem.ToString(), savingsdata);
            }
            else if (cbTranType.SelectedItem.ToString() == "Tr_SA")
            {
                //Update in credit savings account
                savingsdata.TranType = TransType.Cr;
                savingsdata.Description = "Transfer from Savings Account: " + cbAccount.SelectedItem.ToString();
                DataBasedata.AddSavingsRecord(cbCreditAC.SelectedItem.ToString(), savingsdata);

                //Update in debit savings account
                savingsdata.TranType = TransType.Dr;
                savingsdata.Description = "Transfer to Savings Account: " + cbCreditAC.SelectedItem.ToString();
                DataBasedata.AddSavingsRecord(cbAccount.SelectedItem.ToString(), savingsdata);
            }
            else
            {
                //Update in debit savings account
                savingsdata.TranType = (TransType)cbTranType.SelectedIndex;
                savingsdata.Description = tbDesc.Text;
                DataBasedata.AddSavingsRecord(cbAccount.SelectedItem.ToString(), savingsdata);
            }
            MessageBox.Show("Transaction Added");
        }

        private void cbTranType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTranType.SelectedItem.ToString() == "Tr_LN")
            {
                cbCreditAC.Enabled = true;
                cbCategory.Enabled = false;
                tbDesc.Enabled = false;
                tbAmount.Enabled = false;

                //Get all Account details
                List<string> data2 = DataBasedata.GetallLNAC(true);
                cbCreditAC.Items.Clear();

                for (int cnt = 0; cnt < data2.Count; cnt++)
                {
                    cbCreditAC.Items.Add(data2[cnt]);
                }
                cbCreditAC.SelectedIndex = 0;
                cbCategory.SelectedIndex = (int)Category.Loan;
            }
            else if(cbTranType.SelectedItem.ToString() == "Tr_SA")
            {
                cbCreditAC.Enabled = true;
                cbCategory.Enabled = false;
                tbDesc.Enabled = true;
                tbAmount.Enabled = true;

                //Get all Account details
                List<string> data2 = DataBasedata.GetSavingsAC();
                cbCreditAC.Items.Clear();

                for (int cnt = 0; cnt < data2.Count; cnt++)
                {
                    cbCreditAC.Items.Add(data2[cnt]);
                }
                cbCreditAC.SelectedIndex = 0;
                cbCategory.SelectedIndex = (int)Category.Transfer;
            }
            else
            {
                cbCreditAC.Enabled = false;
                cbCategory.Enabled = true;
                tbDesc.Enabled = true;
                tbAmount.Enabled = true;                
            }
        }

        private void cbCreditAC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTranType.SelectedItem.ToString() == "Tr_LN")
            {
                tbAmount.Text = DataBasedata.GetEMIinfo(cbCreditAC.SelectedItem.ToString()).ToString();
            }
        }
    }
}
