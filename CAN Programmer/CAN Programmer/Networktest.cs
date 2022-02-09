using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAN_Programmer
{
    public partial class Networktest : Form
    {
        private int DevID;
        private int Devclass;
        public string SysPort;
        public int SysBaudrate;


        private int sofdata;
        private char bytercvd;
        private char cpstart;
        private int nbytes;
        private char[] Databuf = new char[100];

        private void SendCmd(char Cmd, char[] data, char datalen)
        {
            char[] Databuf = new char[300];
            int i;

            //SOF
            Databuf[0] = (char)83;
            Databuf[1] = (char)84;
            Databuf[2] = (char)88;

            //Class
            Databuf[3] = (char)Devclass;
            //ID
            Databuf[4] = (char)DevID;

            //CMD
            Databuf[5] = Cmd;

            //Datalen
            Databuf[6] = datalen;

            //data
            for (i = 0; i < datalen; i++)
                Databuf[7 + i] = data[i];

            //CRC
            Databuf[7 + i] = (char)0;

            //EOF
            Databuf[7 + i + 1] = (char)69;
            Databuf[7 + i + 2] = (char)84;
            Databuf[7 + i + 3] = (char)88;

            //DataPort.DiscardInBuffer[]
            DataPort.Write(Databuf, 0, datalen + 11);

        }

        private int CheckReply(char Cmd)
        {
            if (Databuf[2] != Cmd)
            {
                return 0;
            }
            if ((Databuf[0] != (char)0) || (Databuf[1] != (char)30))
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }
        
        


        public Networktest()
        {
            InitializeComponent();
        }

        private void Networktest_Load(object sender, EventArgs e)
        {
            string path;
            string temp;

            this.WindowState = FormWindowState.Maximized;

            path = Application.StartupPath + "\\" + "Config.dat";

            System.IO.StreamReader reader = new System.IO.StreamReader(path);

            SysPort = reader.ReadLine();
            temp = reader.ReadLine();
            SysBaudrate = Convert.ToInt32(temp);

            reader.Close();
            MDIParent1.Self.StripStatusBaud.Text = SysBaudrate.ToString();
            MDIParent1.Self.StripStatusPort.Text = SysPort;

        }

        private void Networktest_FormClosing(object sender, FormClosingEventArgs e)
        {
            MessageBox.Show("Form closing");
        }


        private void Update_Picbox(int State, int ID)
        {
            string Str;

            if (State == 0)
                Str = "Red.png";
            else
                Str = "Green.png";


            if (ID == 1)
                PictureBox1.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 2)
                PictureBox2.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 3)
                PictureBox3.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 4)
                PictureBox4.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 5)
                PictureBox5.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 6)
                PictureBox6.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 7)
                PictureBox7.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 8)
                PictureBox8.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 9)
                PictureBox9.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 10)
                PictureBox10.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 11)
                PictureBox11.ImageLocation = Application.StartupPath + "\\" + Str;

            else if (ID == 12)
                PictureBox12.ImageLocation = Application.StartupPath + "\\" + Str;

        }

        private void Check_Click(object sender, EventArgs e)
        {
            char[] Data = new char[100];
            int returnstate = new int();

            DataPort.BaudRate = SysBaudrate;
            DataPort.PortName = SysPort;
            DataPort.ReadTimeout = 1000;
            //DataPort.DataReceived += DataPort_DataReceived;

            DataPort.Open();

            Data[0] = (char)55;
            Data[1] = (char)58;

            Devclass = 1;
            
            for (DevID = 1; DevID <= 12; DevID++)
            {
                DataPort.DiscardInBuffer();
                //DataPort.ReceivedBytesThreshold = 13;

                sofdata = 0;
                cpstart = (char)0;
                nbytes = (char)0;
                returnstate = 0;

                timer1.Interval = 1000;
                timer1.Tick += Timer1_Tick;
                SendCmd((char)1, Data, (char)2);
                timer1.Start();

                while (cpstart < 2)
                {
                    Application.DoEvents();
                    try
                    {
                        
                        DataPortread();
                    }
                    catch
                    { }

                    if (cpstart == 2)
                    {
                        returnstate = CheckReply((char)129);
                    }
                    else
                    {
                        returnstate = 0;
                    }
                };

                timer1.Stop();

                Update_Picbox(returnstate, DevID);

                PBar1.Value = 100 * DevID / 12;

            }


            DataPort.Close();

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            cpstart = (char)3;
            timer1.Stop();
            
        }

        private void DataPort_DataReceived(object sender, System.IO.Ports.SerialDataReceivedEventArgs e)
        {
        }

        private void DataPortread()
        {
            bytercvd = (char)DataPort.ReadByte();
            sofdata = sofdata / 256 + bytercvd * 65536;
            if (cpstart == 0)
            {
                if (5788755 == sofdata)
                {
                    cpstart = (char)1;
                    sofdata = 0;
                }
            }
            else if (cpstart == 1)
            {
                if (5788741 == sofdata)
                {
                    cpstart = (char)2;
                    sofdata = 0;
                }

                Databuf[nbytes] = bytercvd;

                nbytes = nbytes + 1;

            }

        }

    }
}

