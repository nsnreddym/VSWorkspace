using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using GraphClass;

namespace Spectrum_test
{
    public partial class DataAnalysis : Form
    {
        public DataAnalysis()
        {
            InitializeComponent();
        }

        public void DataAnalysis_update(Graph.AnalysisData[] analysisData, int NoSeries)
        {
            DataTable.Rows.Clear();
            DataTable.Rows.Add(NoSeries);

            for (int i = 0; i < NoSeries; i++)
            {
                DataTable.Rows[i].Cells[0].Value = i.ToString();
                DataTable.Rows[i].Cells[1].Value = analysisData[i].Freq;
                DataTable.Rows[i].Cells[2].Value = analysisData[i].Pol;
                DataTable.Rows[i].Cells[3].Value = analysisData[i].Max;
                DataTable.Rows[i].Cells[4].Value = analysisData[i].BW3dB;
                DataTable.Rows[i].Cells[5].Style.BackColor = analysisData[i].color;
            }
        }

        private void DataAnalysis_Load(object sender, EventArgs e)
        {
            DateTime date = new DateTime();

            date = DateTime.Now;

            lbDate.Text = date.ToShortDateString();

            //splitContainer1.Panel1.Height = panel1.Height;
        }
    }
}
