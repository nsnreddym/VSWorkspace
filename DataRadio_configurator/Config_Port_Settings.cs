using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace DataRadio_configurator
{
    public partial class Config_Port_Settings : Form
    {
        public Config_Port_Settings()
        {
            InitializeComponent();
        }

        private void Config_Port_Settings_Load(object sender, EventArgs e)
        {
            string[] ports = SerialPort.GetPortNames();
            int i;

            Bdsel_CB.SelectedIndex = 7;

            for (i = 0; i < ports.Length; i++)
            {
                Portsel_CB.Items.Add(ports[i]);                
            }

            if(Portsel_CB.Items.Count > 0)
            {
                Portsel_CB.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] Baudrateindex = new int[8];
            Baudrateindex[0] = 100;
            Baudrateindex[1] = 300;
            Baudrateindex[2] = 600;
            Baudrateindex[3] = 1200;
            Baudrateindex[4] = 4800;
            Baudrateindex[5] = 9600;
            Baudrateindex[6] = 19200;
            Baudrateindex[7] = 115200;

            Global.PortName = Portsel_CB.SelectedItem.ToString();
            Global.Baudrate = Baudrateindex[Bdsel_CB.SelectedIndex];

           ((MainForm)this.MdiParent).Update();

            this.Close();
        }
    }
}
