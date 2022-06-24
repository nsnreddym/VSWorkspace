using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace DataRadio_CFG_SW
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void configPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Config_Port_Settings settings1 = new Config_Port_Settings();

            settings1.MdiParent = this;

            settings1.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {      

            try 
            {
                StreamReader ConfigFile = new StreamReader(@".\UARTConfig.txt");
                Global.PortName = ConfigFile.ReadLine();
                Global.Baudrate = Convert.ToInt32(ConfigFile.ReadLine());
                ConfigFile.Close();
            }
            catch (Exception ex)
            {
                Global.PortName = "COM1";
                Global.Baudrate = 115200;
            
                MessageBox.Show(ex.Message);
            }

            
            PortStatus.Text = Global.PortName;
            BaudValue.Text = Global.Baudrate.ToString();

            this.WindowState = FormWindowState.Maximized;
        }

        public void Update()
        {
            PortStatus.Text = Global.PortName;
            BaudValue.Text = Global.Baudrate.ToString();
        }

        public void Update_bar(int value)
        {
            Status_Pbar.Value = value;
        }

        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void programToolStripMenuItem1_Click(object sender, EventArgs e)
        {
        }

        private void programChannelsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Radio_Program radio_Program = new Radio_Program();
            radio_Program.MdiParent = this;
            radio_Program.Show();
        }
    }
}
