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

namespace Financial_Status.Forms.Users
{
    public partial class ViewTran : Form
    {
        public ViewTran()
        {
            InitializeComponent();
        }

        private void ViewTran_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[0].SizeType = SizeType.AutoSize;
            tableLayoutPanel1.RowStyles[0].Height = panel1.Height;

            tableLayoutPanel1.RowStyles[1].Height = tableLayoutPanel1.Height - panel1.Height;

            List<string> data = DataBasedata.GetSavingsAC();

            for (int cnt = 0; cnt < data.Count; cnt++)
            {
                cbAccount.Items.Add(data[cnt]);
            }

            cbCategory.Items.Add("All");
            foreach (var item in Enum.GetValues(typeof(FinancialDataBase.Category)))
            {
                cbCategory.Items.Add(item);
            }
            

            cbAccount.SelectedIndex = 0;
            cbCategory.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<SavingsAccData> savingsdata = DataBasedata.GetSavingsData(cbAccount.SelectedItem.ToString(), cbCategory.SelectedIndex);

            dataview.Rows.Clear();
            if (savingsdata.Count > 0)
            {
                dataview.Rows.Add(savingsdata.Count);

                for (int i = 0; i < savingsdata.Count; i++)
                {
                    dataview.Rows[i].Cells[0].Value = i + 1;
                    dataview.Rows[i].Cells[1].Value = savingsdata[i].date.ToShortDateString();
                    dataview.Rows[i].Cells[2].Value = savingsdata[i].Description;
                    dataview.Rows[i].Cells[3].Value = savingsdata[i].Amount.ToString();
                    dataview.Rows[i].Cells[4].Value = savingsdata[i].TranType.ToString();
                    dataview.Rows[i].Cells[5].Value = savingsdata[i].Category.ToString();

                }
            }
        }

        private void updatedata()
        { 
            double credit, debit;

            List<SavingsAccData> savingsdata = DataBasedata.GetSavingsData(cbAccount.SelectedItem.ToString(), cbCategory.SelectedIndex);

            dataview.Rows.Clear();
            credit = 0;
            debit = 0;
            if (savingsdata.Count > 0)
            {
                dataview.Rows.Add(savingsdata.Count);

                for (int i = 0; i < savingsdata.Count; i++)
                {
                    dataview.Rows[i].Cells[0].Value = i + 1;
                    dataview.Rows[i].Cells[1].Value = savingsdata[i].date.ToShortDateString();
                    dataview.Rows[i].Cells[2].Value = savingsdata[i].Description;
                    if (savingsdata[i].TranType == TransType.Cr)
                    {
                        dataview.Rows[i].Cells[3].Value = savingsdata[i].Amount.ToString();
                        credit = credit + savingsdata[i].Amount;
                    }
                    else
                    {
                        dataview.Rows[i].Cells[4].Value = savingsdata[i].Amount.ToString();
                        debit = debit + savingsdata[i].Amount;
                    }
                    dataview.Rows[i].Cells[5].Value = savingsdata[i].TranType.ToString();
                    dataview.Rows[i].Cells[6].Value = savingsdata[i].Category.ToString();

                }
                
            }

            lbCredit.Text = credit.ToString("N");
            lbDebit.Text = debit.ToString("N");
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatedata();
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            updatedata();
        }
    }
}
