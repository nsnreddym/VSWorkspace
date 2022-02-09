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
    public partial class MDIParent1 : Form
    {
        public string SysPort;
        public int SysBaudrate;

        private int dispteststate;
        private int audteststate;

        public static MDIParent1 Self;

        private void SendCmd(char Cmd, char[] data, char datalen)
        {
            char[] Databuf = new char[300];
            int i;

            //SOF
            Databuf[0] = (char)83;
            Databuf[1] = (char)84;
            Databuf[2] = (char)88;

            //Class
            Databuf[3] = (char)3;
            //ID
            Databuf[4] = (char)0;

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

        public MDIParent1()
        {
            InitializeComponent();

            Self = this;
        }

        private void MDIParent1_Load(object sender, EventArgs e)
        {
            string path;
            string temp;

            this.WindowState = FormWindowState.Maximized;

            path = Application.StartupPath + "\\" + "Config.dat";

            System.IO.StreamReader reader = new System.IO.StreamReader(path);

            SysPort = reader.ReadLine();
            temp = reader.ReadLine();
            SysBaudrate = Convert.ToInt32(temp);


            StripStatusBaud.Text = SysBaudrate.ToString();
            StripStatusPort.Text = SysPort;

            reader.Close();

        }   

 


        private void deviceResetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] Data = new char[2];        

            DataPort.BaudRate = SysBaudrate;
    
            DataPort.PortName = SysPort;

            DataPort.Open();
    
            MessageBox.Show("Resetting system successful");


            SendCmd((char)10, Data, (char)0);
    
            DataPort.Close();

        }

        private void TsRst_Click(object sender, EventArgs e)
        {
            deviceResetToolStripMenuItem_Click(sender, e);
        }


        private void networkTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Networktest Networktest1 = new Networktest();

            Networktest1.MdiParent = this;

            Networktest1.Show();
           /* Form1 Networktest1 = new Form1();

            Networktest1.MdiParent = this;

            Networktest1.Show();*/

        }

        private void TsNWTst_Click(object sender, EventArgs e)
        {
            networkTestToolStripMenuItem_Click(sender, e);
        }


        private void displayTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] Data = new char[2];

            DataPort.BaudRate = SysBaudrate;

            DataPort.PortName = SysPort;

            DataPort.Open();

            if (dispteststate == 1)
            {

                MessageBox.Show("Display test End");
                Data[0] = (char)2;
                dispteststate = 0;
                SendCmd((char)6, Data, (char)1);
            }
            else
            {

                MessageBox.Show("Display test Start");
                Data[0] = (char)1;
                dispteststate = 1;
                SendCmd((char)6, Data, (char)1);
            }

            DataPort.Close();


        }

        private void TsDspTst_Click(object sender, EventArgs e)
        {
            displayTestToolStripMenuItem_Click(sender, e);
        }


        private void audioTestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            char[] Data = new char[2];

            DataPort.BaudRate = SysBaudrate;

            DataPort.PortName = SysPort;

            DataPort.Open();

            if (audteststate == 1)
            {

                MessageBox.Show("Audio test End");
                Data[0] = (char)4;
                audteststate = 0;
                SendCmd((char)6, Data, (char)1);
            }
            else
            {

                MessageBox.Show("Audio test Start");
                Data[0] = (char)3;
                audteststate = 1;
                SendCmd((char)6, Data, (char)1);
            }

            DataPort.Close();


        }

        private void TsAudTst_Click(object sender, EventArgs e)
        {
            audioTestToolStripMenuItem_Click(sender, e);
        }


        private void uploadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DbUpload DbUpload1 = new DbUpload();

            DbUpload1.MdiParent = this;

            DbUpload1.Show();

        }

        private void TsUpld_Click(object sender, EventArgs e)
        {
            uploadToolStripMenuItem_Click(sender, e);

        }


        private void comPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Comm Comm1 = new Comm();

            Comm1.MdiParent = this;

            Comm1.Show();

        }


        private void statusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Status Status1 = new Status();

            Status1.MdiParent = this;

            TsExprtExcel.Visible = true;
            TsExprtPDF.Visible = true;

            Status1.Show();

        }

        private void TsStatus_Click(object sender, EventArgs e)
        {
            statusToolStripMenuItem_Click(sender, e);
        }


        private void eraseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FlashErase FlashErase1 = new FlashErase();

            FlashErase1.MdiParent = this;

            FlashErase1.Show();


        }

        private void TsErase_Click(object sender, EventArgs e)
        {
            eraseToolStripMenuItem_Click(sender, e);
        }

        private void uploadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            SWUpload SWUpload1 = new SWUpload();

            SWUpload1.MdiParent = this;

            SWUpload1.Show();



        }
    }
}
