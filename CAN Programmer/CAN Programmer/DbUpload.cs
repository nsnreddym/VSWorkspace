using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CAN_Programmer
{
    public partial class DbUpload : Form
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

        private int MaxFileIndx;
        private int CurFileIndx;


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
            if(Cmd == 1)
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

        private void data_upload(object state)
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

                for (CurFileIndx = 0; CurFileIndx < MaxFileIndx; CurFileIndx++)
                {
                    Updatestatus_LBlkStatus("Sending File Information");

                    SendFileinfo(CurFileIndx);

                    SendFiledata(CurFileIndx);

                    Updatestatus_LFilesState(CurFileIndx + " of " + MaxFileIndx + " Files Uploaded");

                    Update_PBAR2(100 * (CurFileIndx + 1) / OpenFile.FileNames.Length);
                }

                MessageBox.Show("Upload Successful. Resetting system");
                Updateclose(1);


            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                Updateclose(0);
            }

        }

        private void SendFileinfo(int i)
        {
            byte[] Data = new byte[100];
            int NoBlks;
            int returnstate;
            byte[] result = new byte[4];

            FileInfo info = new FileInfo(OpenFile.FileNames[i]);

            NoBlks = (int)info.Length / (int)224;

            if ((int)0 != (int)info.Length % (int)224)
            {
                NoBlks = NoBlks + 1;
            }

            MaxBlks = NoBlks;
            CurrBlk = (int)0;

            Data[0] = (byte)1;

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

        private void SendFiledata(int i)
        {
            int returnstate;
            byte[] result = new byte[4];

            byte[] Data = new byte[310];
            int Readbytes;

            //Display file name
            Updatestatus_LFname(Path.GetFileName(OpenFile.FileNames[i]));

            FileStream fs = File.OpenRead(OpenFile.FileNames[i]);

            for(CurrBlk = 0; CurrBlk < MaxBlks; CurrBlk++)
            {
                //Show info
                Updatestatus_LBlkStatus("Sending block no " + (CurrBlk + 1) + "/" + MaxBlks);

                //Block no
                result = BitConverter.GetBytes(CurrBlk);
                Data[0] = (byte)result[3];
                Data[1] = (byte)result[2];
                Data[2] = (byte)result[1];
                Data[3] = (byte)result[0];

                //Read data
                Readbytes = fs.Read(Data , 4, 224);

                //send data
                DataPort.DiscardInBuffer();
                SendCmd(13, Data, (byte)(4 + Readbytes));
                DataPort.ReadTimeout = -1;
                returnstate = CheckReply(145);

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




        public void Updatestatus_LFname(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Updatestatus_LFname), new object[] { value });
                return;
            }
            LFname.Text = value;
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

        public void Updatestatus_LFilesState(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Updatestatus_LFilesState), new object[] { value });
                return;
            }
            LFilesState.Text = value;
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

        public void Update_PBAR2(int value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<int>(Update_PBAR2), new object[] { value });
                return;
            }
            PBar2.Value = value;
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



        public void DbUpload_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (DataPort.IsOpen)
                DataPort.Close();

        }

        public DbUpload()
        {
            InitializeComponent();
        }

        private void DbUpload_Load(object sender, EventArgs e)
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

            LFname.Text = "";
            LBlkStatus.Text = "";

            PBar1.Value = 0;
            PBar2.Value = 0;


        }




        private void BCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            DevClass = CBClass.SelectedIndex;

            if(CBID.SelectedItem.ToString() == "BroadCast")
            {
                DevID = 31;
            }
            else
            {
                DevID = CBID.SelectedIndex + 1;
            }
            

            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(data_upload));


        }

        private void BBrowse_Click(object sender, EventArgs e)
        {
            OpenFile.ShowDialog();

            if(OpenFile.FileNames.Length > 0)
            {
                if(OpenFile.FileNames.Length < 2)
                {
                    TBFnames.Text = OpenFile.FileName;
                }
                else
                {
                    TBFnames.Text = "Multiple Files";
                }

                MaxFileIndx = OpenFile.FileNames.Length;
                CurFileIndx = 0;

            }
        }

        private void CBClass_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
