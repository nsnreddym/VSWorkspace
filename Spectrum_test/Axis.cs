using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Globalclass;

namespace Spectrum_test
{
    public partial class Axis : Form
    {
        public Axis()
        {
            InitializeComponent();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void bSave_Click(object sender, EventArgs e)
        {
            Globals.YAxismin = Convert.ToDouble(tMindB.Text);
            Globals.YAxismax = Convert.ToDouble(tMaxdB.Text);
            Globals.YAxisInterval = Convert.ToDouble(tintvldB.Text);
            this.Close();
        }

        private void Axis_Load(object sender, EventArgs e)
        {
            tMindB.Text = Globals.YAxismin.ToString();
            tMaxdB.Text = Globals.YAxismax.ToString();
            tintvldB.Text = Globals.YAxisInterval.ToString();
        }
    }
}
