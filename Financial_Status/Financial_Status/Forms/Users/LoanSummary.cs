using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using FinancialDataBase;
using Globals;


namespace Financial_Status.Forms.Users
{
    public partial class LoanSummary : Form
    {

        DataGridViewCellStyle datacellstyle = new DataGridViewCellStyle();
        DataGridViewCellStyle groupcellstyle = new DataGridViewCellStyle();
        DataGridViewCellStyle Totalcellstyle = new DataGridViewCellStyle();
        DataGridViewCellStyle Totalcellstyle_max = new DataGridViewCellStyle();

        public LoanSummary()
        {
            InitializeComponent();
        }

        private void PrepareTable()
        {
            datacellstyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datacellstyle.BackColor = Color.White;
            datacellstyle.ForeColor = Color.Black;
            datacellstyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

            groupcellstyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            groupcellstyle.BackColor = Color.White;
            groupcellstyle.ForeColor = Color.Black;
            groupcellstyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);

            Totalcellstyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Totalcellstyle.BackColor = Color.LightGoldenrodYellow;
            Totalcellstyle.ForeColor = Color.Red;
            Totalcellstyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);

            Totalcellstyle_max.Alignment = DataGridViewContentAlignment.MiddleLeft;
            Totalcellstyle_max.BackColor = Color.LightGoldenrodYellow;
            Totalcellstyle_max.ForeColor = Color.Green;
            Totalcellstyle_max.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Bold);


            dataview.Columns.Clear();
            

            dataview.Columns.Add("SNO", "SNo");
            dataview.Columns["SNO"].DefaultCellStyle = dataview.DefaultCellStyle;
            dataview.Columns["SNO"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["SNO"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            //data
            dataview.Columns["SNO"].ReadOnly = true;
            dataview.Columns["SNO"].DefaultCellStyle = datacellstyle;
            

            dataview.Columns.Add("Loan", "Loan");
            dataview.Columns["Loan"].DefaultCellStyle = dataview.DefaultCellStyle;
            dataview.Columns["Loan"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["Loan"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["Loan"].ReadOnly = true;
            dataview.Columns["Loan"].DefaultCellStyle = datacellstyle;

            dataview.Columns.Add("LoanAC", "Loan A/C");
            dataview.Columns["LoanAC"].DefaultCellStyle = dataview.DefaultCellStyle;
            dataview.Columns["LoanAC"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["LoanAC"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["LoanAC"].ReadOnly = true;
            dataview.Columns["LoanAC"].DefaultCellStyle = datacellstyle;

            dataview.Columns.Add("EMI", "EMI");
            dataview.Columns["EMI"].DefaultCellStyle = dataview.DefaultCellStyle;
            dataview.Columns["EMI"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["EMI"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["EMI"].ReadOnly = true;
            dataview.Columns["EMI"].DefaultCellStyle = datacellstyle;

            dataview.Columns.Add("BEMI", "Bal EMI");
            dataview.Columns["BEMI"].DefaultCellStyle = dataview.DefaultCellStyle;
            dataview.Columns["BEMI"].SortMode = DataGridViewColumnSortMode.Programmatic;
            dataview.Columns["BEMI"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["BEMI"].ReadOnly = true;
            dataview.Columns["BEMI"].DefaultCellStyle = datacellstyle;

            dataview.Columns.Add("EDate", "End Date");
            dataview.Columns["EDate"].DefaultCellStyle = dataview.DefaultCellStyle;
            dataview.Columns["EDate"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["EDate"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["EDate"].ReadOnly = true;
            dataview.Columns["EDate"].DefaultCellStyle = groupcellstyle;

            dataview.Columns.Add("Amount", "Sanction Amount");
            dataview.Columns["Amount"].DefaultCellStyle = dataview.DefaultCellStyle;
            dataview.Columns["Amount"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["Amount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["Amount"].ReadOnly = true;
            dataview.Columns["Amount"].DefaultCellStyle = datacellstyle;

            dataview.Columns.Add("BAmount", "Balance Amount");
            dataview.Columns["BAmount"].DefaultCellStyle = dataview.DefaultCellStyle;
            dataview.Columns["BAmount"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["BAmount"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["BAmount"].ReadOnly = true;
            dataview.Columns["BAmount"].DefaultCellStyle = groupcellstyle;

            dataview.ColumnHeadersDefaultCellStyle = groupcellstyle;
        }

        private void LoadTable()
        {
            List<AccountInfoData> accountinfo; 
            accountinfo = DataBasedata.ReadAccountInfo();
            Int32 indx;
            double total;
            double total2;
            DateTime dt = DateTime.Now;


            dataview.Rows.Clear();
            indx = 0;
            total = 0;
            total2 = 0;
            for (int i = 0 ; i < accountinfo.Count; i++)
            {
                if((accountinfo[i].Type == "Loan") && (accountinfo[i].LNInfo.Balance > 0))
                {
                    dataview.Rows.Add();
                    dataview.Rows[indx].Cells["SNO"].Value = (indx + 1).ToString();
                    dataview.Rows[indx].Cells["Loan"].Value = accountinfo[i].LNInfo.Name;
                    dataview.Rows[indx].Cells["LoanAC"].Value = accountinfo[i].LNInfo.AccNo;
                    dataview.Rows[indx].Cells["EMI"].Value = accountinfo[i].LNInfo.EMI.ToString("N");
                    dataview.Rows[indx].Cells["BEMI"].Value = accountinfo[i].LNInfo.BEMI;
                    dataview.Rows[indx].Cells["Amount"].Value = accountinfo[i].LNInfo.LoanAmount.ToString("N");
                    dataview.Rows[indx].Cells["BAmount"].Value = accountinfo[i].LNInfo.Balance.ToString("N");
                    dataview.Rows[indx].Cells["EDate"].Value = (dt.AddMonths((int)accountinfo[i].LNInfo.BEMI)).ToString("MMM-yy");

                    total = total + accountinfo[i].LNInfo.Balance;
                    total2 = total2 + accountinfo[i].LNInfo.LoanAmount;

                    indx++;
                }

            }


            dataview.Sort(dataview.Columns["BEMI"], ListSortDirection.Ascending);

            indx = 0;
            for (int i = 0; i < accountinfo.Count; i++)
            {
                if ((accountinfo[i].Type == "Loan") && (accountinfo[i].LNInfo.Balance > 0))
                {
                    dataview.Rows[indx].Cells["SNO"].Value = (indx+1).ToString();
                    indx++;
                }

            }

            dataview.Rows.Add();
            dataview.Rows[indx].Cells["EDate"].Value = "Total";
            dataview.Rows[indx].Cells["EDate"].Style = Totalcellstyle_max;

            dataview.Rows[indx].Cells["Amount"].Value = total2.ToString("N");
            dataview.Rows[indx].Cells["BAmount"].Value = total.ToString("N");
            dataview.Rows[indx].Cells["Amount"].Style = Totalcellstyle;
            dataview.Rows[indx].Cells["BAmount"].Style = Totalcellstyle;


        }

        private void LoanSummary_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            PrepareTable();

            LoadTable();

        }
    }
}
