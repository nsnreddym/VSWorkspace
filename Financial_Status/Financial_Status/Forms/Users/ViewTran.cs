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
        double credit, debit;

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

            cbAccount.Items.Add("All");
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

        

        private void updatedata(string tablename, int category)
        {
            int j;

            List<SavingsAccData> savingsdata = DataBasedata.GetSavingsData(tablename, category);

            j = dataview.RowCount;

            if (savingsdata.Count > 0)
            {

                for (int i = 0; i < savingsdata.Count; i++)
                {
                    dataview.Rows.Add();

                    dataview.Rows[j+i].Cells[0].Value = j + i + 1;
                    dataview.Rows[j+i].Cells[1].Value = savingsdata[i].date.ToShortDateString();
                    dataview.Rows[j+i].Cells[2].Value = savingsdata[i].Description;
                    if (savingsdata[i].TranType == TransType.Cr)
                    {
                        dataview.Rows[j+i].Cells[3].Value = savingsdata[i].Amount.ToString("N");
                        credit = credit + savingsdata[i].Amount;
                    }
                    else
                    {
                        dataview.Rows[j+i].Cells[4].Value = savingsdata[i].Amount.ToString("N");
                        debit = debit + savingsdata[i].Amount;
                    }
                    dataview.Rows[j+i].Cells[5].Value = savingsdata[i].TranType.ToString();
                    dataview.Rows[j+i].Cells[6].Value = savingsdata[i].Category.ToString();
                    dataview.Rows[j+i].Cells[7].Value = tablename;

                }

            }

            lbCredit.Text = credit.ToString("N");
            lbDebit.Text = debit.ToString("N");
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            credit = 0;
            debit = 0;
            dataview.Rows.Clear();

            if (cbAccount.SelectedIndex == 0)
            {
                for (int i = 1; i < cbAccount.Items.Count; i++)
                {
                    updatedata(cbAccount.Items[i].ToString(), cbCategory.SelectedIndex);
                }
            }
            else
            {
                updatedata(cbAccount.SelectedItem.ToString(), cbCategory.SelectedIndex);
            }
        }

        private void cbAccount_SelectedIndexChanged(object sender, EventArgs e)
        {
            credit = 0;
            debit = 0;
            dataview.Rows.Clear();

            if (cbAccount.SelectedIndex == 0)
            {
                for(int i = 1; i < cbAccount.Items.Count; i++)
                {
                    updatedata(cbAccount.Items[i].ToString(), cbCategory.SelectedIndex);
                }
            }
            else
            {
                updatedata(cbAccount.SelectedItem.ToString(), cbCategory.SelectedIndex);
            }
        }
    }
}
