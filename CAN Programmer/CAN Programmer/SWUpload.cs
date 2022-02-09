using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CAN_Programmer
{
    public partial class SWUpload : Form
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

        private int MaxBlks;
        private int CurrBlk;

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
            if (Cmd == 1)
            {
                if (DevID == 31)
                {
                    Databuf[4] = 1;
                }
                else
                {
                    Databuf[4] = (byte)DevID;
                }
            }
            else
            {
                Databuf[4] = (byte)DevID;
            }


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

        private void SW_upload(object state)
        {
            byte[] Data = new byte[100];
            char[] FLen = new char[4];
            int returnstate = new int();

            try
            {

                DataPort.BaudRate = SysBaudrate;
                DataPort.PortName = SysPort;
                DataPort.Open();

                Data[0] = (byte)55;
                Data[1] = (byte)58;
                returnstate = 0;

                //Do health check
                Updatestatus_LBlkStatus("Waiting for Device connection");

                while (returnstate == 0)
                {
                    DataPort.DiscardInBuffer();
                    SendCmd((byte)1, Data, (byte)2);
                    DataPort.ReadTimeout = 5000;
                    returnstate = CheckReply(129);
                }

                Updatestatus_LBlkStatus("Entering into Data Mode");
                //Send data mode 
                Data[0] = (byte)3;
                for (int i = 1; i < 11; i++)
                {
                    Data[i] = (byte)0;
                }
                returnstate = 0;

                while (returnstate != 2)
                {
                    DataPort.DiscardInBuffer();
                    SendCmd((byte)4, Data, (byte)12);
                    DataPort.ReadTimeout = 5000;
                    returnstate = CheckReply(132);
                }


                SendFileinfo();

                SendFiledata();

                MessageBox.Show("Upload Successful. Resetting system");
                
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Updateclose(0);
            }

        }


        private void SendFileinfo()
        {
            byte[] Data = new byte[100];
            int NoBlks;
            int returnstate;
            byte[] result = new byte[4];

            FileInfo info = new FileInfo(OpenFile.FileName);

            NoBlks = (int)info.Length / (int)78;

            if ((int)0 != (int)info.Length % (int)78)
            {
                NoBlks = NoBlks + 1;
            }

            MaxBlks = NoBlks;
            CurrBlk = (int)0;

            Data[0] = (byte)3;

            result = BitConverter.GetBytes(info.Length);
            Data[1] = (byte)result[3];
            Data[2] = (byte)result[2];
            Data[3] = (byte)result[1];
            Data[4] = (byte)result[0];

            result = BitConverter.GetBytes(NoBlks);
            Data[5] = (byte)result[3];
            Data[6] = (byte)result[2];
            Data[7] = (byte)result[1];
            Data[8] = (byte)result[0];

            Data[9] = (byte)0;
            Data[10] = (byte)0;
            Data[11] = (byte)0;
            Data[12] = (byte)0;

            DataPort.DiscardInBuffer();
            SendCmd((byte)17, Data, (byte)13);
            DataPort.ReadTimeout = -1;
            returnstate = CheckReply((byte)145);

            if (returnstate == -1)
            {
                MessageBox.Show("Communication lost");
                Updateclose(0);
            }
        }

        private void SendFiledata()
        {
            int returnstate;
            byte[] result = new byte[4];
            char[] datachar = new char[74];
            byte[] Data = new byte[310];
            string DataStr;
            int Readbytes;

            FileStream fs = File.OpenRead(OpenFile.FileName);
            StreamReader Reader = new StreamReader(OpenFile.FileName);


            for (CurrBlk = 0; Reader.Peek() >= 0; CurrBlk++)
            {
                //Show info
                Updatestatus_LBlkStatus("Sending Rec no " + (CurrBlk + 1) + "/" + MaxBlks);

                DataStr = Reader.ReadLine();

                //Block no
                result = BitConverter.GetBytes(CurrBlk);
                Data[0] = (byte)result[3];
                Data[1] = (byte)result[2];
                Data[2] = (byte)result[1];
                Data[3] = (byte)result[0];
                Data[4] = (byte)85;
                Data[5] = (byte)85;

                datachar = DataStr.ToCharArray();

                for (int i = 0; i < 76; i++)
                {
                    Data[6 + i] = (byte)datachar[i];
                }

                Data[6 + 76] = 170;
                Data[7 + 76] = 170;

                //send data
                DataPort.DiscardInBuffer();
                SendCmd(15, Data, (byte)(6 + 76 + 2));
                DataPort.ReadTimeout = -1;
                returnstate = CheckReply(143);

                if (returnstate == -1)
                {
                    MessageBox.Show("Communication lost");
                    fs.Close();
                    this.Close();

                    return;
                }

                //Send block status query
                int state;
                state = 0;

                while (state == 0)
                {
                    Data[0] = result[3];
                    Data[1] = result[2];
                    Data[2] = result[1];
                    Data[3] = result[0];

                    DataPort.DiscardInBuffer();
                    SendCmd(16, Data, 4);
                    DataPort.ReadTimeout = -1;
                    returnstate = CheckReply(144);

                    if (returnstate != 2)
                    {
                        MessageBox.Show("Communication lost");
                        fs.Close();
                        Updateclose(0);

                        return;
                    }
                    else if (returnstate == 2)
                    {
                        if ((Databuf_rcvd[8] == 0) || (Databuf_rcvd[8] == 3))
                        {
                            state = 1;
                        }
                        else if (Databuf_rcvd[8] == 4)
                        {

                            MessageBox.Show("Upload Failed");

                            fs.Close();
                            Updateclose(1);

                            return;
                        }
                    }

                }//End While

                Update_PBAR1(100 * (CurrBlk + 1) / MaxBlks);

            }//End for

            fs.Close();

        }


        public void Updatestatus_LBlkStatus(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Updatestatus_LBlkStatus), new object[] { value });
                return;
            }
            LBlkStatus.Text = value;
        }

        public void Updateclose(int value)
        {
            byte[] Data = new byte[10];

            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(Updateclose), new object[] { value });
                return;
            }

            if (value == 1)
            {
                SendCmd(10, Data, 0);
            }
            this.Close();

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



        public SWUpload()
        {
            InitializeComponent();
        }

        private void SWUpload_Load(object sender, EventArgs e)
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

            LBlkStatus.Text = "";

            PBar1.Value = 0;

        }

        private void BCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BReboot_Click(object sender, EventArgs e)
        {
            Byte[] Data = new Byte[100];

            SendCmd(20, Data, 0);
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            DevClass = CBClass.SelectedIndex;

            if (CBID.SelectedItem.ToString() == "BroadCast")
            {
                DevID = 31;
            }
            else
            {
                DevID = CBID.SelectedIndex + 1;
            }


            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(SW_upload));

        }

        private void BBrowse_Click(object sender, EventArgs e)
        {
            OpenFile.ShowDialog();

            if (OpenFile.FileNames.Length > 0)
            {
                if (OpenFile.FileNames.Length < 2)
                {
                    TBFnames.Text = OpenFile.FileName;
                }
            }
        }
    }
}
