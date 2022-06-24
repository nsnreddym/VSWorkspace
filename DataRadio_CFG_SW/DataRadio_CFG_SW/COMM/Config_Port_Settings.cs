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
using System.IO;

namespace DataRadio_CFG_SW.COMM
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

            StreamReader ConfigFile = new StreamReader(@".\UARTConfig.txt");
            ConfigFile.ReadLine();
            ConfigFile.ReadLine();
            RawFlashAccess.Checked = Convert.ToBoolean(ConfigFile.ReadLine());
            ConfigFile.Close();

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
            StreamWriter ConfigFile = new StreamWriter(@".\UARTConfig.txt");
            string baudrate;
            int[] Baudrateindex = new int[9];
            Baudrateindex[0] = 100;
            Baudrateindex[1] = 300;
            Baudrateindex[2] = 600;
            Baudrateindex[3] = 1200;
            Baudrateindex[4] = 4800;
            Baudrateindex[5] = 9600;
            Baudrateindex[6] = 19200;
            Baudrateindex[7] = 57600;
            Baudrateindex[8] = 115200;

            Global.PortName = Portsel_CB.SelectedItem.ToString();
            baudrate = Bdsel_CB.SelectedItem.ToString();
            Global.Baudrate = Convert.ToInt32(baudrate);

            try 
            {
                ConfigFile.WriteLine(Global.PortName);
                ConfigFile.WriteLine(Global.Baudrate.ToString());
                ConfigFile.WriteLine((bool)RawFlashAccess.Checked);
                ConfigFile.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }            

           ((DataRadioCfgSw)this.MdiParent).Update();

            this.Close();
        }

        private void RawFlashAccess_CheckedChanged(object sender, EventArgs e)
        {
            Global.rawflashaccess = (bool)RawFlashAccess.Checked;
        }
    }
}
