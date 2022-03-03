using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PacketSender
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serialPort1.PortName = port.Text;
            serialPort1.Open();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            serialPort1.Write(seq.Text);
            console.Text += DateTime.Now.ToString() + ": " + seq.Text + Environment.NewLine;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked)
            {
                
                timer1.Interval = Convert.ToInt32(Repeat.Text);
                timer1.Enabled = true;
                timer1.Start();
            }
            else
            {
                timer1.Stop();
                timer1.Enabled=false;   
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            serialPort1.Write(seq.Text);
            console.Text += DateTime.Now.ToString() + ": " + seq.Text + Environment.NewLine;
        }
    }
}
