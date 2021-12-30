using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataRadio_configurator
{
    public partial class Read_Flash : Form
    {
        Comm ReadComm = new Comm();
        public Read_Flash()
        {
            InitializeComponent();
        }

        private void Read_Flash_Load(object sender, EventArgs e)
        {
            Chno_CB.SelectedIndex = 0;
        }

        private void bRead_Click(object sender, EventArgs e)
        {
            byte[] chno = new byte[4];
            byte[] Read_data = new byte[1000];
            byte[] Indx = new byte[3];
            byte[] datatemp = new byte[4];
            int loop;

            int maxloop;
            string hex;
            int ReadAddr;
            int ReadAddr_updated;

            ReadAddr = Chno_CB.SelectedIndex;
            bRead.Enabled = false;
            ReadAddr = ReadAddr * 65536;

            //Tx reg
            ReadAddr_updated = ReadComm.Read_bytes(ReadAddr, ref Read_data);
            maxloop = (Read_data[3] + 1)*4;

            for (loop = 0; loop < maxloop; loop= loop+ 4)
            {
                datatemp = BitConverter.GetBytes(loop + ReadAddr);
                Indx[0] = datatemp[2];
                Indx[1] = datatemp[1];
                Indx[2] = datatemp[0];
                hex = BitConverter.ToString(Indx);
                hex = hex.Replace('-', ' ');
                if (loop == 0)
                {
                    Memory_data.Text = "0x" + hex + ": ";
                }
                else
                {
                    Memory_data.Text += "0x" + hex + ": ";
                }
                datatemp[0] = Read_data[loop];
                datatemp[1] = Read_data[loop + 1];
                datatemp[2] = Read_data[loop + 2];
                datatemp[3] = Read_data[loop + 3];
                hex = BitConverter.ToString(datatemp);
                hex = hex.Replace('-', ' ');
                Memory_data.Text += hex;
                Memory_data.Text += Environment.NewLine;
                
            }

            Memory_data.Text += Environment.NewLine;
            Memory_data.Text += Environment.NewLine;
            ReadAddr = ReadAddr_updated;

            //Rx reg
            ReadAddr_updated = ReadComm.Read_bytes(ReadAddr, ref Read_data);
            maxloop = (Read_data[3] + 1) * 4;

            for (loop = 0; loop < maxloop; loop = loop + 4)
            {
                datatemp = BitConverter.GetBytes(loop + ReadAddr);
                Indx[0] = datatemp[2];
                Indx[1] = datatemp[1];
                Indx[2] = datatemp[0];
                hex = BitConverter.ToString(Indx);
                hex = hex.Replace('-', ' ');

                Memory_data.Text += "0x" + hex + ": ";
                datatemp[0] = Read_data[loop];
                datatemp[1] = Read_data[loop + 1];
                datatemp[2] = Read_data[loop + 2];
                datatemp[3] = Read_data[loop + 3];
                hex = BitConverter.ToString(datatemp);
                hex = hex.Replace('-', ' ');
                Memory_data.Text += hex;
                Memory_data.Text += Environment.NewLine;

            }

            MessageBox.Show("Read Completed"); 
            bRead.Enabled = true;
            
        }
    }
}
