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

namespace CAN_Programmer
{
    public partial class Comm : Form
    {

        public string SysPort;
        public int SysBaudrate;



        public Comm()
        {
            InitializeComponent();
        }

        private void Comm_Load(object sender, EventArgs e)
        {
            string path;
            string temp;

            this.WindowState = FormWindowState.Maximized;

            path = Application.StartupPath + "\\" + "Baudrates.txt";

            try
            {
                string[] ports = SerialPort.GetPortNames();
                foreach (string port in ports)
                {
                    CBPorts.Items.Add(port);
                }

                System.IO.StreamReader reader = new System.IO.StreamReader(path);

                for (; !reader.EndOfStream;)
                {
                    temp = reader.ReadLine();

                    CBaudRates.Items.Add(temp);

                }

                reader.Close();
                CBPorts.SelectedIndex = 0;
                CBaudRates.SelectedIndex = 0;
                CStopBits.SelectedIndex = 0;
                CParity.SelectedIndex = 0;
                CDataBits.SelectedIndex = 0;

            }
            catch(Exception ex )
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void BSave_Click(object sender, EventArgs e)
        {
            string path;
            string temp;

            path = Application.StartupPath + "\\" + "Config.dat";

            try
            {
                System.IO.StreamWriter Writer = new System.IO.StreamWriter(path);

                Writer.WriteLine(CBPorts.SelectedItem);
                Writer.WriteLine(CBaudRates.SelectedItem);

                Writer.Close();

                SysPort = CBPorts.SelectedItem.ToString();
                temp = CBaudRates.SelectedItem.ToString();
                SysBaudrate = Convert.ToInt32(temp);

                MessageBox.Show(SysPort + "   " + SysBaudrate);

                MDIParent1.Self.StripStatusBaud.Text = SysBaudrate.ToString();
                MDIParent1.Self.StripStatusPort.Text = SysPort;


                this.Close();

            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
