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
    public partial class ExpenditureSummary : Form
    {
        double credit, debit;
        List<string> SQLTableNames;
        int trtype;
        List<int> Groupstrtindx = new List<int>();
        List<int> Groupendindx = new List<int>();

        public ExpenditureSummary()
        {
            InitializeComponent();
        }

        private void ExpenditureSummary_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[0].SizeType = SizeType.AutoSize;
            tableLayoutPanel1.RowStyles[0].Height = panel1.Height;

            tableLayoutPanel1.RowStyles[1].Height = tableLayoutPanel1.Height - panel1.Height;

            button1.Enabled = false;
            comboBox1.Enabled = false;

            //Read table names
            SQLTableNames = DataBasedata.GetSavingsAC();

            comboBox1.SelectedIndex = 0;

            button1.Enabled = true;
            comboBox1.Enabled = true;
            cbMonth.SelectedIndex = 0;  

            dataview.CellMouseClick += Dataview_CellMouseClick;

        }

        private int updateRecord(string tablename, int category, int indx)
        {
            int j;
            int k;

            List<SavingsAccData> savingsdata = DataBasedata.GetSavingsData(tablename, category, cbMonth.SelectedIndex, 2022);

            j = indx;

            if (savingsdata.Count > 0)
            {

                for (int i = 0; i < savingsdata.Count; i++)
                {
                    if ((int)savingsdata[i].TranType == trtype)
                    {
                        dataview.Rows.Add();
                        k = dataview.Rows.Count - 1;

                        dataview.Rows[k].Cells["Sno"].Value = j + 1;
                        dataview.Rows[k].Cells["Account"].Value = tablename;
                        dataview.Rows[k].Cells["date"].Value = savingsdata[i].date.ToShortDateString();
                        dataview.Rows[k].Cells["desc"].Value = savingsdata[i].Description;
                        if (savingsdata[i].TranType == TransType.Cr)
                        {
                            dataview.Rows[k].Cells["Credit"].Value = savingsdata[i].Amount.ToString("N");
                            credit = credit + savingsdata[i].Amount;
                        }
                        else
                        {
                            dataview.Rows[k].Cells["Debit"].Value = savingsdata[i].Amount.ToString("N");
                            debit = debit + savingsdata[i].Amount;
                        }
                        /*dataview.Rows[j + i].Cells[5].Value = savingsdata[i].TranType.ToString();
                        dataview.Rows[j + i].Cells[6].Value = savingsdata[i].Category.ToString();*/

                        j++;
                    }
                    

                }

            }

            return j;
        }

        private void PrepareTable()
        {
            DataGridViewCellStyle datacellstyle = new DataGridViewCellStyle();
            DataGridViewCellStyle groupcellstyle = new DataGridViewCellStyle();

            datacellstyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datacellstyle.BackColor = Color.White;
            datacellstyle.ForeColor = Color.Black;
            datacellstyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

            groupcellstyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            groupcellstyle.BackColor = Color.White;
            if (comboBox1.SelectedIndex == 0)
            {
                groupcellstyle.ForeColor = Color.Red;
            }
            else
            {
                groupcellstyle.ForeColor = Color.Green;
            }
            groupcellstyle.Font = new Font("Microsoft Sans Serif", 10,FontStyle.Bold);
            

            dataview.Columns.Clear();

            dataview.Columns.Add("Group", "Group");
            dataview.Columns["Group"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["Group"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["Group"].ReadOnly = true;
            dataview.Columns["Group"].DefaultCellStyle = groupcellstyle;

            dataview.Columns.Add("SNo", "S No");
            dataview.Columns["SNo"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["SNo"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 
            dataview.Columns["SNo"].ReadOnly = true;
            dataview.Columns["SNo"].DefaultCellStyle = datacellstyle;

            dataview.Columns.Add("Account", "Account");
            dataview.Columns["Account"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["Account"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; 
            dataview.Columns["Account"].ReadOnly = true;
            dataview.Columns["Account"].DefaultCellStyle = datacellstyle;


            dataview.Columns.Add("date", "Date");
            dataview.Columns["date"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["date"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["date"].ReadOnly = true;
            dataview.Columns["date"].DefaultCellStyle = datacellstyle;


            dataview.Columns.Add("desc", "Description");
            dataview.Columns["desc"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["desc"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["desc"].ReadOnly = true;
            dataview.Columns["desc"].DefaultCellStyle = datacellstyle;


            dataview.Columns.Add("Credit", "Credit");
            dataview.Columns["Credit"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["Credit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["Credit"].ReadOnly = true;
            dataview.Columns["Credit"].DefaultCellStyle = datacellstyle;

            dataview.Columns.Add("Debit", "Debit");
            dataview.Columns["Debit"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["Debit"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["Debit"].ReadOnly = true;
            dataview.Columns["Debit"].DefaultCellStyle = datacellstyle;

            dataview.Columns.Add("Total", "Total");
            dataview.Columns["Total"].DefaultCellStyle = dataview.DefaultCellStyle;
            dataview.Columns["Total"].SortMode = DataGridViewColumnSortMode.NotSortable;
            dataview.Columns["Total"].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataview.Columns["Total"].ReadOnly = true;
            dataview.Columns["Total"].DefaultCellStyle = groupcellstyle;            

        }

        private void Dataview_CellMouseClick(object? sender, DataGridViewCellMouseEventArgs e)
        {           
            if (e.ColumnIndex == 0)
            {
                for (int i = 0; i < Groupstrtindx.Count; i++)
                {
                    if (Groupstrtindx[i] == e.RowIndex)
                    {
                        for(int j = Groupstrtindx[i]; j < Groupendindx[i]; j++)
                        {                            
                            dataview.Rows[j + 1].Visible = !(dataview.Rows[j + 1].Visible);
                        }
                    }
                }
            }
            //throw new NotImplementedException();
        }

        private void UpdateTable()
        {
            int indx;
            int groupindx;

            credit = 0;
            debit = 0;


            PrepareTable();
            dataview.Rows.Clear();
            indx = 0;
            Groupstrtindx.Clear();
            Groupendindx.Clear();

            foreach (var item in Enum.GetValues(typeof(FinancialDataBase.Category)))
            {

                dataview.Rows.Add();
                groupindx = dataview.Rows.Count - 1;
                dataview.Rows[groupindx].Cells["Group"].Value = "-" + item.ToString();
                Groupstrtindx.Add(groupindx);
                indx = 0;
                credit = 0;
                debit = 0;

                for (int i = 0; i < SQLTableNames.Count; i++)
                {
                    indx = updateRecord(SQLTableNames[i].ToString(), item.GetHashCode() + 1, indx);
                }
                Groupendindx.Add(groupindx+indx);

                if (trtype == 0)
                {

                    dataview.Rows[groupindx].Cells["Total"].Value = (debit).ToString("N");
                    dataview.Columns["Credit"].Visible = false;
                    dataview.Columns["Debit"].Visible = true;
                }
                else
                {
                    dataview.Rows[groupindx].Cells["Total"].Value = (credit).ToString("N");
                    dataview.Columns["Credit"].Visible = true;
                    dataview.Columns["Debit"].Visible = false;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Enabled == true)
            {
                comboBox1.Enabled = false;
                button1.Enabled = false;

                trtype = comboBox1.SelectedIndex;

                UpdateTable();

                comboBox1.Enabled = true;
                button1.Enabled = true;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Enabled == true)
            {
                comboBox1.Enabled = false;
                button1.Enabled = false;

                trtype = comboBox1.SelectedIndex;

                UpdateTable();

                comboBox1.Enabled = true;
                button1.Enabled = true;
            }
            
        }
    }
}
