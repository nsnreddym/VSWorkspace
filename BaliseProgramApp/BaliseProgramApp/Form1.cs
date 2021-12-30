using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace BaliseProgramApp
{
    public partial class Form1 : Form
    {
        String ComPortName;
        byte[] Rxbuf = new byte[12];
        byte[] Txbuf = new byte[12];
        string FileName;

        public Form1()
        {
            InitializeComponent();
        }




        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {


            try
            {
                ComPort_dev.Close();

                ComPort_dev.PortName = COMPortSel.SelectedItem.ToString();
                ComPort_dev.BaudRate = 4800;
                ComPort_dev.Open();
                ComPort_dev.DtrEnable = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<String> portlist = new List<String>();

            pBar.Enabled = false;
            button1.Enabled = false;

            foreach (string s in System.IO.Ports.SerialPort.GetPortNames())
            {
                portlist.Add(s);
            }

            COMPortSel.Items.AddRange(portlist.ToArray());
            COMPortSel.SelectedIndex = 0;

            ComPort_dev.Close();
            try
            {
                ComPort_dev.BaudRate = 4800;
                ComPort_dev.Open();
                ComPort_dev.DtrEnable = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }


        }

        private void ReadResponse()
        {
            bool loop;
            int byte_rcvd;
            UInt32 hdr;
            bool hdrok;
            int byteindx;

            loop = true;
            hdr = 0;
            hdrok = false;
            byteindx = 0;
            while (loop)
            {
                byte_rcvd = ComPort_dev.ReadByte();
                if (hdrok == true)
                {
                    Rxbuf[byteindx] = (byte)byte_rcvd;
                    byteindx = byteindx + 1;

                    if (byteindx == 12)
                    {
                        loop = false;
                    }
                }
                else
                {
                    hdr = hdr << 8;
                    hdr = hdr | (UInt32)byte_rcvd;
                    hdr = hdr & 0x0000FFFF;
                    if(hdr == 0x0000A5BB)
                    {
                        hdrok = true;
                        Rxbuf[0] = 0xA5;
                        Rxbuf[1] = 0xBB;
                        byteindx = 2;
                    }
                }

            }

        }

        private void SendDataPacket()
        {
            ComPort_dev.Write(Txbuf, 0, 12);

            while (ComPort_dev.BytesToWrite != 0) ;

        }


        private void button1_Click(object sender, EventArgs e)
        {
            int byte_rcvd;
            bool loop;
            byte[] Data = new byte[256];
            int Readbytes;
            int sendbytes;
            byte[] result = new byte[4];

            FileStream fs = File.OpenRead(FileName);

            Readbytes = fs.Read(Data, 0, 256);

            COMPortSel.Enabled = false;
            button1.Enabled = false;

            ComPort_dev.DtrEnable = false;
            Thread.Sleep(1000);
            //Wait for Balise  Ready
            loop = true;
            Rxbuf[3] = 0x00;
            while (loop)
            {
                ReadResponse();
                if((Rxbuf[2] == 0x00) && (Rxbuf[3] == 0x01))
                {
                    loop = false;
                }
            }

            //Send write enable
            Txbuf[0] = 0xA5;
            Txbuf[1] = 0xBB;
            Txbuf[2] = 0x00;
            Txbuf[3] = 0x03;
            Txbuf[4] = 0x00;
            Txbuf[5] = 0x00;
            Txbuf[6] = 0x00;
            Txbuf[7] = 0x00;
            Txbuf[8] = 0x00;
            Txbuf[9] = 0x03;
            Txbuf[10] = 0xCC;
            Txbuf[11] = 0x5A;
            SendDataPacket();

            //Wait for reply
            loop = true;
            while (loop)
            {
                ReadResponse();
                if ((Rxbuf[2] == 0x00) && (Rxbuf[3] == 0x04))
                {
                    loop = false;
                }
            }

            pBar.Enabled = true;

            sendbytes = 0;
            while(sendbytes < Readbytes)
            {
                result = BitConverter.GetBytes(sendbytes/2);
                //Send write enable
                Txbuf[0] = 0xA5;
                Txbuf[1] = 0xBB;
                Txbuf[2] = 0x00;
                Txbuf[3] = 0x02;
                Txbuf[4] = result[1];
                Txbuf[5] = result[0];
                Txbuf[6] = Data[sendbytes];
                Txbuf[7] = Data[sendbytes+1];
                Txbuf[8] = 0x00;
                Txbuf[9] = 0x00;
                Txbuf[10] = 0xCC;
                Txbuf[11] = 0x5A;
                SendDataPacket();

                sendbytes = sendbytes + 2;

                //Wait for reply
                loop = true;
                while (loop)
                {
                    ReadResponse();
                    if ((Rxbuf[2] == 0x00) && (Rxbuf[3] == 0x04))
                    {
                        loop = false;
                    }
                }

                pBar.Value = sendbytes * 100 / 256;
            }

            MessageBox.Show("Programming successful");

            ComPort_dev.DtrEnable = true;

        }

        private void bOpen_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            FileName = openFileDialog1.FileName;
            button1.Enabled = true;
            Filepath.Text = FileName;

        }
    }
}
