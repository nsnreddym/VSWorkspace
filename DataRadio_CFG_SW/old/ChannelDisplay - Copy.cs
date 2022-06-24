using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataRadio_CFG_SW
{
    public partial class ChannelDisplay : UserControl
    {
        public ChannelDisplay()
        {
            InitializeComponent();
        }


        private void ChannelDisplay_Load(object sender, EventArgs e)
        {
            TxPwr.SelectedIndex = 0;
        }

        public void UpdateData(double txfreq, double rxfreq)
        {
            TxFreq.Text = txfreq.ToString();
            RxFreq.Text = rxfreq.ToString();
        }

        public void ReadData(ref double txfreq, ref double rxfreq)
        {
            txfreq = Convert.ToDouble(TxFreq.Text);
            rxfreq = Convert.ToDouble(RxFreq.Text);
        }
    }
}
