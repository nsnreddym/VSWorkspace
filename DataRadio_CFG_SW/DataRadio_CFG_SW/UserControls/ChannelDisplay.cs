using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataRadio_CFG_SW.Memory;

namespace DataRadio_CFG_SW.UserControls
{
    public partial class ChannelDisplay : UserControl
    {
        public ChannelDisplay()
        {
            InitializeComponent();
            Initialize_default();
        }


        private void Initialize_default()
        {
            TxPwr.SelectedIndex = 0;

            cbAirBaud.SelectedIndex = 2;
            cbBW.SelectedIndex = 1;

            cbComBaud.SelectedIndex = 3;
            cbComStopbits.SelectedIndex = 0;
            cbComMode.SelectedIndex = 1;
            cbComParity.SelectedIndex = 0;
        }

        public void UpdateData(double txfreq, double rxfreq, int pwr)
        {
            TxFreq.Text = txfreq.ToString();
            RxFreq.Text = rxfreq.ToString();
            if (pwr > 0)
            {
                TxPwr.SelectedIndex = (pwr - 1);
            }
            else
            {
                TxPwr.Text = pwr.ToString();
            }
        }
        public void UpdateBaudData(byte[] data)
        {
            cbAirBaud.SelectedIndex = data[0];
            cbBW.SelectedIndex = data[1];
            cbComBaud.SelectedIndex = data[2];
            cbComStopbits.SelectedIndex = data[3];
            cbComMode.SelectedIndex = data[4];
            cbComParity.SelectedIndex = data[5];
        }

        public void ReadData(ref double txfreq, ref double rxfreq, ref int txpwr)
        {
            txfreq = Convert.ToDouble(TxFreq.Text);
            rxfreq = Convert.ToDouble(RxFreq.Text);
            txpwr = TxPwr.SelectedIndex;

        }
        public byte[] ReadBaudData()
        {
            byte[] data = new byte[8];

            data[0] = Convert.ToByte(cbAirBaud.SelectedIndex);
            data[1] = Convert.ToByte(cbBW.SelectedIndex);
            data[2] = Convert.ToByte(cbComBaud.SelectedIndex);
            data[3] = Convert.ToByte(cbComStopbits.SelectedIndex);
            data[4] = Convert.ToByte(cbComMode.SelectedIndex);
            data[5] = Convert.ToByte(cbComParity.SelectedIndex);

            return data;
        }


        private void ChannelDisplay_Load(object sender, EventArgs e)
        {
            HorizontalScroll.Enabled = true;
            VerticalScroll.Enabled = true;
        }

        private void cbFSKDisable_CheckedChanged(object sender, EventArgs e)
        {
            RadioHandler.FSKstateChg(cbFSKDisable.Checked);
        }
    }
}
