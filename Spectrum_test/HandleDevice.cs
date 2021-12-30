using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Equipment;
using GraphClass;

namespace Spectrum_test
{
    public partial class HandleDevice : Form
    {
        Instrument Spectrum; //= new Instrument();
        MyGraph Graph;
        double Axismin;
        double Axismax;
        double AxisInterval;
        int points;
        double[] digits = new double[5000];
        int strtindx;
        int P3dbindx;
        int N3dbindx;
        double angle;

        public HandleDevice()
        {
            InitializeComponent();
        }

        private void ProgramDevice()
        {
            //string reply;

            Spectrum.ConnState = true;

            Spectrum.Address = "TCPIP0::" + ip1.Text + "::inst0::INSTR";

            Spectrum.Reset();            

        }
        private void HandleDevice_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;

            tableLayoutPanel1.RowStyles[1].Height = IPadd.Height + 4;
            tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;

            cbRBW.SelectedIndex = 1;
            cbVBW.SelectedIndex = 2;
            cbSpan.SelectedIndex = 0;
            cbFreq.SelectedIndex = 0;
            cbSWT.SelectedIndex = 1;

            Spectrum = new Instrument();
            
            Graph = new MyGraph(chart1);
            points = 3601;
            strtindx = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Spectrum.ConnState == true)
            {
                button1.Text = "Connect";
                Spectrum.ConnState = false;
                ip1.Enabled = true;
            }
            else
            {
                button1.Text = "DisConnect";                
                ip1.Enabled = false;

                ProgramDevice();
            }

        }

        private void bUpdate_Click(object sender, EventArgs e)
        {
            Spectrum.Write("*CLS");

            //Set frequency
            Spectrum.Write("FREQUENCY:CENTER " + tFreq.Text + cbFreq.Text);

            Spectrum.Write("FREQUENCY:SPAN " + tSpan.Text + cbSpan.Text);

            //RBW
            Spectrum.Write("BAND:RES " + tRBW.Text + cbRBW.Text);
            Spectrum.Write("BAND:VID:AUTO OFF");

            Spectrum.Write("BAND:VID " + tVBW.Text + cbVBW.Text);
            //Spectrum.Write("BAND:VID:RAT " + tVBW.Text);
            

            //Sweep time
            Spectrum.Write("SWE:TIME " + tSWT.Text + cbSWT.Text);
            MyConsole.Text = Spectrum.Query("SYST:ERR?");

            Spectrum.Write("DISP:TRAC:Y:RLEV " + tREF.Text + "dBm");

            Spectrum.Write("SWE:POIN " + points.ToString());
            MyConsole.Text = Spectrum.Query("SYST:ERR?");

            timer1.Enabled = true;


        }

        private void timer_routine(object sender, EventArgs e)
        {
            string data;

            data = Spectrum.Query("TRAC? TRACE1");
            digits = data.Split(',').Select(r => Convert.ToDouble(r)).ToArray();

            //MyConsole.Text = Spectrum.Query("SYST:ERR?");
            Graph.RefreshGraph(digits, strtindx, points);

        }


        private void HandleDevice_SizeChanged(object sender, EventArgs e)
        {
            tableLayoutPanel1.RowStyles[1].Height = IPadd.Height + 4;
            tableLayoutPanel1.RowStyles[1].SizeType = SizeType.AutoSize;

            tableLayoutPanel1.RowStyles[2].Height = 120;
            tableLayoutPanel1.RowStyles[2].SizeType = SizeType.AutoSize;

            tableLayoutPanel1.RowStyles[0].Height = this.Height - (IPadd.Height + 4 + 120 + 20);
            tableLayoutPanel1.RowStyles[0].SizeType = SizeType.Absolute;
        }

        private void HandleDevice_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Graph.CloseGraph();

            base.OnClosing(e);
        }

        private void bRefresh_Click(object sender, EventArgs e)
        {
            string data;

            data = Spectrum.Query("TRAC? TRACE1");
            var digits = data.Split(',').Select(r => Convert.ToDouble(r)).ToArray();

            //MyConsole.Text = Spectrum.Query("SYST:ERR?");
            Graph.RefreshGraph(digits, strtindx, points);
        }
        
        private void bStop_Click(object sender, EventArgs e)
        {
            Spectrum.Write("INIT:CONT OFF");
            MyConsole.Text = Spectrum.Query("SYST:ERR?");
            timer1.Enabled = false; 
        }

        private void bstart_Click(object sender, EventArgs e)
        {
            Spectrum.Write("INIT:CONT ON");
            MyConsole.Text = Spectrum.Query("SYST:ERR?"); 
            timer1.Enabled = true;
            BW_3db.Text = "";
        }

        private void GUpdate_Click(object sender, EventArgs e)
        {
            Axismin = Convert.ToDouble(tMindB.Text);
            Axismax = Convert.ToDouble(tMaxdB.Text);
            AxisInterval = Convert.ToDouble(tintvldB.Text);
            Graph.UpdateAxis(Axismin, Axismax, AxisInterval);
        }

        private void Calc_Click(object sender, EventArgs e)
        {
            int i;
            double max;
            int indx1;
            max = digits[0];

            //Finding Max
            for(i = 0; i < points-1; i++)
            {
                if (digits[i] > max)
                {
                    max = digits[i];
                    strtindx = i;    
                }
            }

            //finding +3db point
            indx1 = strtindx;
            angle = 0;
            for (i = 0; i < points - 1; i++)
            {
                if (digits[indx1] <= max - 3)
                {
                    P3dbindx = indx1;
                    break;
                }
                else
                {
                    indx1++;
                    angle = angle + 0.1;
                    if(indx1 >= points)
                    {
                        indx1 = 0;
                    }
                }
            }

            //finding -3db point
            indx1 = strtindx;
            for (i = 0; i < points - 1; i++)
            {
                if (digits[indx1] <= max - 3)
                {
                    N3dbindx = indx1;
                    break;
                }
                else
                {
                    indx1--;
                    angle = angle + 0.1;
                    if (indx1 < 0)
                    {
                        indx1 = points - 1;
                    }
                }
            }
            BW_3db.Text = angle.ToString(); 
            Graph.RefreshGraph(digits, strtindx, points);
        }
    }

}
