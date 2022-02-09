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
    public partial class FlashErase : Form
    {
        private int DevID;
        private int DevClass;
        public string SysPort;
        public int SysBaudrate;


        private int sofdata;
        private byte bytercvd;
        private byte cpstart;
        private int nbytes;
        private byte[] Databuf_rcvd = new byte[100];


        private void SendCmd(byte Cmd, byte[] data, byte datalen)
        {
            byte[] Databuf = new byte[300];
            int i;

            //SOF
            Databuf[0] = (byte)83;
            Databuf[1] = (byte)84;
            Databuf[2] = (byte)88;

            //Class
            Databuf[3] = (byte)DevClass;
            //ID
            Databuf[4] = (byte)DevID;

            //CMD
            Databuf[5] = Cmd;

            //Datalen
            Databuf[6] = datalen;

            //data
            for (i = 0; i < datalen; i++)
                Databuf[7 + i] = data[i];

            //CRC
            Databuf[7 + i] = (byte)0;

            //EOF
            Databuf[7 + i + 1] = (byte)69;
            Databuf[7 + i + 2] = (byte)84;
            Databuf[7 + i + 3] = (byte)88;

            //DataPort.DiscardInBuffer[]
            DataPort.Write(Databuf, 0, datalen + 11);

        }

        private void DataPortread()
        {
            bytercvd = (byte)DataPort.ReadByte();
            sofdata = sofdata / 256 + bytercvd * 65536;
            if (cpstart == 0)
            {
                if (5788755 == sofdata)
                {
                    cpstart = (byte)1;
                    sofdata = 0;
                }
            }
            else if (cpstart == 1)
            {
                if (5788741 == sofdata)
                {
                    cpstart = (byte)2;
                    sofdata = 0;
                }

                Databuf_rcvd[nbytes] = bytercvd;

                nbytes = nbytes + 1;

            }

        }

        private int CheckReply(byte Cmd)
        {
            sofdata = 0;
            cpstart = (byte)0;
            nbytes = (byte)0;

            while (cpstart < 2)
            {
                try
                {

                    DataPortread();
                }
                catch
                {
                    return -1;
                }

            }

            if (Databuf_rcvd[2] != Cmd)
            {
                return 0;
            }
            if ((Databuf_rcvd[0] != (char)0) || (Databuf_rcvd[1] != (char)30))
            {
                return 1;
            }
            else
            {
                return 2;
            }

        }

        private void data_erase(object state)
        {
            byte[] Data = new byte[100];
            char[] FLen = new char[4];
            byte[] result = new byte[4];
            int returnstate;
            int State;


            try
            {

                DataPort.BaudRate = SysBaudrate;
                DataPort.PortName = SysPort;
                DataPort.Open();

                Data[0] = (byte)55;
                Data[1] = (byte)58;
                returnstate = 0;

                //Do health check
                Updatestatus_LStatus("Waiting for Device connection");

                while (returnstate == 0)
                {
                    DataPort.DiscardInBuffer();
                    SendCmd((byte)1, Data, (byte)2);
                    DataPort.ReadTimeout = 5000;
                    returnstate = CheckReply(129);
                }

                Updatestatus_LStatus("Entering into Data Mode");
                //Send data mode 
                Data[0] = (byte)3;
                for (int i = 1; i < 11; i++)
                {
                    Data[i] = (byte)0;
                }

                while (returnstate != 2)
                {
                    DataPort.DiscardInBuffer();
                    SendCmd((byte)4, Data, (byte)12);
                    DataPort.ReadTimeout = 5000;
                    returnstate = CheckReply(132);
                }

                returnstate = 0;

                Updatestatus_LStatus("Erasing Please Wait...");

                while(returnstate != 2)
                {
                    DataPort.DiscardInBuffer();
                    SendCmd((byte)19, Data, (byte)0);
                    DataPort.ReadTimeout = -1;
                    returnstate = CheckReply(147);

                }

                returnstate = 0;

                State = 0;

                while (State == 0)
                {
                    Data[0] = 0;
                    Data[1] = 0;
                    Data[2] = 0;
                    Data[3] = 0;

                    DataPort.DiscardInBuffer();
                    SendCmd(16, Data, 4);
                    DataPort.ReadTimeout = -1;
                    returnstate = CheckReply(144);

                    if (returnstate != 2)
                    {
                        MessageBox.Show("Communication lost");
                        Updateclose(0);

                        return;
                    }
                    else if (returnstate == 2)
                    {
                        if ((Databuf_rcvd[8] == 0) || (Databuf_rcvd[8] == 10))
                        {
                            state = 1;
                            MessageBox.Show("Erase Completed .... Resetting system");
                            Updateclose(1);
                            return;

                        }
                        else if (Databuf_rcvd[8] == 8)
                        {

                            MessageBox.Show("Erase Failed... Resetting system");
                            SendCmd(10, Data, 0);
                            Updateclose(1);

                            return;
                        }
                    }

                    Update_PBAR1(100 * (Databuf_rcvd[6] * 256 + Databuf_rcvd[7]) / 1023);


                }//End While

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                //this.Close();
            }
        }



        public void Update_PBAR1(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(Update_PBAR1), new object[] { value });
                return;
            }
            PBar1.Value = value;
        }

        public void Updatestatus_LStatus(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Updatestatus_LStatus), new object[] { value });
                return;
            }
            LStatus.Text = value;
        }

        public void Updateclose(int value)
        {
            byte[] Data = new byte[10];

            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(Updateclose), new object[] { value });
                return;
            }

            if(value == 1)
            {
                SendCmd(10, Data, 0);
            }
            this.Close();

        }




        public FlashErase()
        {
            InitializeComponent();
        }

        public void FlashErase_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (DataPort.IsOpen)
                DataPort.Close();

        }

        private void FlashErase_Load(object sender, EventArgs e)
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
            CBClass.SelectedIndex = 0;
            CBID.SelectedIndex = 0;

            LStatus.Text = "";
            PBar1.Value = 0;

        }





        private void BUpdate_Click(object sender, EventArgs e)
        {
            DevClass = CBClass.SelectedIndex;
            DevID = CBID.SelectedIndex + 1;

            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(data_erase));

        }
    }
}
