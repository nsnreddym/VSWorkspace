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
    public partial class AddTran : Form
    {
        public AddTran()
        {
            InitializeComponent();
        }
#if false
        private void AddTran_Load_1(object sender, EventArgs e)
        {
            DataBaseConn dataBaseConn = new();
            int count;
            string[] tables = new string[GlobalVar.MaxTables];

            count = dataBaseConn.LoadTableNames(tables); 

            for (int i = 0; i < count; i++)
            {
                if (tables[i] != "Login")
                {
                    cbAccount.Items.Add(tables[i]);
                }
            }

            foreach (var item in Enum.GetValues(typeof(DataBaseConn.Category)))
            {
                cbCategory.Items.Add(item);
            }

            cbAccount.SelectedIndex = 0;
            cbCategory.SelectedIndex = 0;
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            DataBaseConn.Savings_ICICI_data data = new DataBaseConn.Savings_ICICI_data();

            DataBaseConn dataBaseConn = new();

            //Read last transaction
            data = dataBaseConn.GetLastTransaction(cbAccount.Text);

            //Update data
            data.date = cbDate.Value;
            data.Description = tbDesc.Text;
            data.Amount = Convert.ToDouble(tbAmount.Text);
            data.TranType = cbTranType.SelectedIndex;            
            data.Category = cbCategory.SelectedIndex;

            if (data.TranType == 0)
            {
                data.Balance = data.Balance - data.Amount;
            }
            else
            {
                data.Balance = data.Balance + data.Amount;
            }
            
            int count = dataBaseConn.UpdateTransaction(cbAccount.Text, data, 4);

            MessageBox.Show(count.ToString() + "Records Addeed");
        }
#endif
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

            //Get all Account details
            List <string> data2 = DataBasedata.GetallAC();

            for(int cnt = 0; cnt < data2.Count; cnt++)
            {
                cbCreditAC.Items.Add(data2[cnt]);
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
            if (cbTranType.SelectedItem.ToString() == "Tr")
            {
                DataBasedata.AddLoanRecord(cbCreditAC.SelectedItem.ToString(), cbDate.Value.ToShortDateString(), tbAmount.Text);

                MessageBox.Show("Transaction Added");
            }
        }

        private void cbTranType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbTranType.SelectedItem.ToString() == "Tr")
            {
                cbCreditAC.Enabled = true;
                cbCategory.Enabled = false;
                tbDesc.Enabled = false;
            }
            else
            {
                cbCreditAC.Enabled = false;
                cbCategory.Enabled = true;
                tbDesc.Enabled = true;
            }
        }
    }
}
