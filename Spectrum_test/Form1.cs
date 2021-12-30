using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using Equipment;

namespace Spectrum_test
{
    public partial class Form1 : Form
    {
        Instrument inst = new Instrument();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Instrument inst = new Instrument();
            string data;

            data = inst.Address;


        }

        private void button1_Click(object sender, EventArgs e)
        {           

            inst.Address = "TCPIP0::192.168.255.200::inst0::INSTR";
            txtResult.Text = inst.Query("*IDN ?");
        }

        private void button2_Click(object sender, EventArgs e)
        {           

            inst.Address = "TCPIP0::192.168.255.200::inst0::INSTR";
            inst.Write("FREQUENCY:CENTER 416.8MHz");
            inst.Write("FREQUENCY:SPAN 100kHz");

            //Activate marker 1
            inst.Write("CALC:MARK:STAT ON");

            //Set marker 1 to trace 1
            inst.Write("CALC:MARK:TRAC 1");

            //Set marker 1 to 100 MHz
            inst.Write("CALC:MARK:X 100MHz");

            //Set count resolution to 1 Hz
            inst.Write("CALC:MARK:COUNT:RES 1HZ");

            //Activate frequency counter
            inst.Write("CALC:CALC:MARKER ON;MARKER:MAX");

            timer1.Enabled = true;
        }

        private void timer_routine(object sender, EventArgs e)
        {
            //Switch to single sweep
            inst.Write("INIT:CONT OFF");

            //Perform sweep with sync
            inst.Write("INIT;*WAI");

            string power;

            //Query and read measured frequency
            power = inst.Query("CALC:MARK:X?;Y?");

            txtResult.Text = power;

        }

        private void button3_Click(object sender, EventArgs e)
        {

            timer1.Enabled = false;
            
        }
    }
}
