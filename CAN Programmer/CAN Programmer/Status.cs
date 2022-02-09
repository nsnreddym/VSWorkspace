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
    public partial class Status : Form
    {
        private int DevID;
        private int DevClass;
        public string SysPort;
        public int SysBaudrate;


        private int sofdata;
        private char bytercvd;
        private char cpstart;
        private int nbytes;
        private char[] Databuf = new char[100];

        private int rowcnt;
        private int lastrec;

        private void SendCmd(char Cmd, char[] data, char datalen)
        {
            char[] Databuf = new char[300];
            int i;

            //SOF
            Databuf[0] = (char)83;
            Databuf[1] = (char)84;
            Databuf[2] = (char)88;

            //Class
            Databuf[3] = (char)DevClass;
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

        private int CheckReply(char Cmd)
        {
            sofdata = 0;
            cpstart = (char)0;
            nbytes = (char)0;

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

        private void data_download(object state)
        {
            char[] Data = new char[100];
            char[] FLen = new char[4];
            int returnstate = new int();

            try {

                DataPort.BaudRate = SysBaudrate;
                DataPort.PortName = SysPort;
                DataPort.Open();

                Data[0] = (char)55;
                Data[1] = (char)58;
                returnstate = 0;

                //Do health check
                Updatestatus("Waiting for Device connection");


                while (returnstate == 0)
                {
                    DataPort.DiscardInBuffer();
                    SendCmd((char)1, Data, (char)2);
                    DataPort.ReadTimeout = 5000;
                    returnstate = CheckReply((char)129);
                }

                Updatestatus("Entering into Data Mode");
                //Send data mode 
                Data[0] = (char)3;
                for (int i = 1; i < 11; i++)
                {
                    Data[i] = (char)0;
                }

                while (returnstate != 2)
                {
                    DataPort.DiscardInBuffer();
                    SendCmd((char)4, Data, (char)12);
                    DataPort.ReadTimeout = 5000;
                    returnstate = CheckReply((char)132);
                }

                Updatestatus("Download Stated...");

                returnstate = 0;
                rowcnt = 0;
                lastrec = 0;

                while (lastrec != 67)
                {
                    DataPort.DiscardInBuffer();
                    SendCmd((char)18, Data, (char)0);
                    DataPort.ReadTimeout = -1;
                    returnstate = CheckReply((char)146);

                    if (returnstate == 2)
                    {
                        UpdateRecord("Hai");
                    }
                }

                Updatestatus("Download Completed");

                MessageBox.Show("Download Successful. Resetting system");
                SendCmd((char)10, Data, (char)0);

                DataPort.Close();
            }
            catch(Exception e)
            {
                MessageBox.Show(e.Message);
            }

        }






        private void UpdateRecord(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(UpdateRecord), new object[] { value });
                return;
            }

            lastrec = Databuf[4];

            DataGridView1.Rows.Add();

            DataGridView1.Rows[rowcnt].Cells[0].Value = rowcnt + 1;

            DataGridView1.Rows[rowcnt].Cells[2].Value = Databuf[21] * 256 * 256 * 256 + Databuf[22] * 256 * 256 + Databuf[23] * 256 + Databuf[24];
            DataGridView1.Rows[rowcnt].Cells[3].Value = new string(Databuf,7,4);//.ToString();//, 3, 10);)

            DataGridView1.Rows[rowcnt].Cells[4].Value = Databuf[17] * 256 + Databuf[18];
            DataGridView1.Rows[rowcnt].Cells[5].Value = Databuf[19] * 256 + Databuf[20];

            switch (Databuf[5] << 8 | Databuf[6])
            {
                case 0x5252:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Route Ref File";
                    break;
                case 0x5254:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Route File";
                    break;
                case 0x5343:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Station Coord File";
                    break;
                case 0x4346:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Config File";
                    break;
                case 0x5354:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Station File";
                    break;
                case 0x4D4D:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Manual message File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                case 0x4A4E:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Jingle message File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                case 0x4D41:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Manual Audio File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                case 0x534D:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Safety message File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                case 0x5253:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "RSF message File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                case 0x5245:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "REF message File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                case 0x5341:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "SAF message File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                case 0x5344:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "SDF message File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                case 0x444C:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Delimiter message File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                case 0x4646:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Font File";
                    DataGridView1.Rows[rowcnt].Cells[3].Value = Databuf[7] * 256 + Databuf[8];
                    break;
                default:
                    DataGridView1.Rows[rowcnt].Cells[1].Value = "Unknown File";
                    break;
            }

            rowcnt = rowcnt + 1;
        }

        public void Updatestatus(string value)
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Updatestatus), new object[] { value });
                return;
            }
            LBlkStatus.Text =  value;
        }




        public Status()
        {
            InitializeComponent();
        }

        private void Status_Load(object sender, EventArgs e)
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
        }

        public void Status_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            if (DataPort.IsOpen)
                DataPort.Close();
        }



        private void BUpdate_Click(object sender, EventArgs e)
        {
            DevClass = CBClass.SelectedIndex;
            DevID = CBID.SelectedIndex + 1;

            System.Threading.ThreadPool.QueueUserWorkItem(new System.Threading.WaitCallback(data_download));

        }
    }
}
