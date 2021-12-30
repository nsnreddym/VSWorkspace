using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataRadio_configurator
{
    public partial class SelCh : Form
    {
        Comm CfgComm = new Comm();


        public SelCh()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] chno = new byte[4];

            chno = BitConverter.GetBytes(Ch_no_CB.SelectedIndex + 1);

            int r = CfgComm.selch(chno[0]);

            if (r == 1)
            {
                MessageBox.Show("Data ok");
            }
            else
            {
                MessageBox.Show("CMD failed");
            }
        }

        private void SelCh_Load(object sender, EventArgs e)
        {
            
        }
    }
}
