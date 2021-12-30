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
            Global.PortName = "COM1";
            Global.Baudrate = 115200;
            PortStatus.Text = Global.PortName;
            BaudValue.Text = Global.Baudrate.ToString();

            this.WindowState = FormWindowState.Maximized;

        }

        public void Update()
        {
            PortStatus.Text = Global.PortName;
            BaudValue.Text = Global.Baudrate.ToString();
        }

        private void programToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Radio_Program a = new Radio_Program();

            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();

        }

        private void selectChannelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelCh a = new SelCh();

            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
        }

        private void readMemoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Read_Flash a = new Read_Flash();

            a.MdiParent = this;
            a.WindowState = FormWindowState.Maximized;
            a.Show();
        }
    }
}
