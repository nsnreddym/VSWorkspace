using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

using DataRadio_CFG_SW.COMM;
using DataRadio_CFG_SW.Memory;

namespace DataRadio_CFG_SW
{
    public partial class DataRadioCfgSw : Form
    {
        RadioHandler radioHandler;

        public DataRadioCfgSw()
        {
            InitializeComponent();
        }

        public void Update()
        {
            PortStatus.Text = Global.PortName;
            BaudValue.Text = Global.Baudrate.ToString();
        }
        public void Update_bcom(bool state)
        {
            if (state == false)
            {
                bComPort.Image = global::DataRadio_CFG_SW.Properties.Resources.Start;
                bComPort.Text = "Open";
                Global.PortState = false;
            }
            else
            {
                bComPort.Image = global::DataRadio_CFG_SW.Properties.Resources.Stop;
                bComPort.Text = "Close";
                Global.PortState = true;
            }
        }

        public void Update_bar(int value)
        {
            Status_Pbar.Value = value;
        }

        public void Update_Status(byte[] status)
        {
            byte[] temp = new byte[4];
            bool TxState = Convert.ToBoolean(status[0] & 0x01);
            bool RxState = Convert.ToBoolean(status[0] & 0x02);
            //rssi calculation
            /*int rssival = status[1] << 24 | status[2] << 16 | status[3] << 8 | status[4];
            double rssi = (rssival - 39.591719)/ 130168674.328253;
            rssi = 10 * Math.Log10(rssi / 1000);*/

            temp[0] = status[4];
            temp[1] = status[3];
            temp[2] = status[2];
            temp[3] = status[1];

            float rssi = System.BitConverter.ToSingle(temp, 0);

            if (double.IsNaN(rssi) || double.IsInfinity(rssi))
            {
                rssi = (float)-130.0;
            }
            
            int txpwr = status[6];

            rbRSSI.Text = "RSSI :  " + rssi.ToString("F2") + " dBm";
            rbTxPwr.Text = "Tx-Power :  " + txpwr.ToString() + " W";
            if (RxState)
            {
                rbRxSynth.LargeImage = Properties.Resources.ButtonGreen;
            }
            else
            {
                rbRxSynth.LargeImage = Properties.Resources.ButtonRed;
            }
            if (TxState)
            {
                rbTxSynth.LargeImage = Properties.Resources.ButtonGreen;
            }
            else
            {
                rbTxSynth.LargeImage = Properties.Resources.ButtonRed;
            }
        }

        public void Update_Status(byte[] status, int no)
        {
            byte[] temp = new byte[4];
            bool TxState = Convert.ToBoolean(status[0] & 0x01);
            bool RxState = Convert.ToBoolean(status[0] & 0x02);
            //rssi calculation
            /*int rssival = status[1] << 24 | status[2] << 16 | status[3] << 8 | status[4];
            double rssi = (rssival - 39.591719)/ 130168674.328253;
            rssi = 10 * Math.Log10(rssi / 1000);*/

            temp[0] = status[4];
            temp[1] = status[3];
            temp[2] = status[2];
            temp[3] = status[1];

            float rssi = System.BitConverter.ToSingle(temp, 0);

            if (double.IsNaN(rssi) || double.IsInfinity(rssi))
            {
                rssi = (float)-130.0;
            }

            int txpwr = status[6];

            if (status[5] == 0)
            {
                rbRSSI.Text = "RSSI :  " + rssi.ToString("F2") + " dBm";
            }
            else
            {
                rbTxPwr.Text = "RSSI2 :  " + rssi.ToString("F2") + " dBm";
            }
            if (RxState)
            {
                rbRxSynth.LargeImage = Properties.Resources.ButtonGreen;
            }
            else
            {
                rbRxSynth.LargeImage = Properties.Resources.ButtonRed;
            }
            if (TxState)
            {
                rbTxSynth.LargeImage = Properties.Resources.ButtonGreen;
            }
            else
            {
                rbTxSynth.LargeImage = Properties.Resources.ButtonRed;
            }
        }
        
        public void Update_Status()
        {
            rbRSSI.Text = "RSSI :  --- dBm";
            rbTxPwr.Text = "Tx-Power :  --- W";
            rbRxSynth.LargeImage = Properties.Resources.ButtonGray;
            rbTxSynth.LargeImage = Properties.Resources.ButtonGray;
            
        }
        public void Enable_program(bool state)
        {
            //Prg_ch.Enabled = state;
        }

        public void Update_ComState(COMM_STATES value)
        {
            switch(value)
            {
                case COMM_STATES.IDLE:
                    bComStatus.LargeImage = Properties.Resources.ButtonGray;
                    bComStatus.Text = "IDLE";
                    bComPort.Enabled = true;
                    rpChannel.Enabled = false;
                    rpMemory.Enabled = false && Global.rawflashaccess;
                    cbSector.Enabled = false && Global.rawflashaccess;
                    break;
                case COMM_STATES.BUSY:
                    bComPort.Enabled = false;
                    bComStatus.LargeImage = Properties.Resources.ButtonYellow;
                    bComStatus.Text = "BUSY";
                    rpChannel.Enabled = false;
                    rpMemory.Enabled = false && Global.rawflashaccess;
                    cbSector.Enabled = false && Global.rawflashaccess;
                    break;
                case COMM_STATES.OK:
                    bComPort.Enabled = true;
                    bComStatus.LargeImage = Properties.Resources.ButtonGreen;
                    bComStatus.Text = "OK";
                    rpChannel.Enabled = true;
                    rpMemory.Enabled = true && Global.rawflashaccess;
                    cbSector.Enabled = true && Global.rawflashaccess;
                    break;
                case COMM_STATES.FAIL:
                    bComPort.Enabled = true;
                    bComStatus.LargeImage = Properties.Resources.ButtonRed;
                    bComStatus.Text = "FAIL";
                    rpChannel.Enabled = false;
                    rpMemory.Enabled = false && Global.rawflashaccess;
                    cbSector.Enabled = false && Global.rawflashaccess;
                    break;
            }
        }

        private void DataRadioCfgSw_Load(object sender, EventArgs e)
        {            
            try
            {
                StreamReader ConfigFile = new StreamReader(@".\UARTConfig.txt");
                Global.PortName = ConfigFile.ReadLine();
                Global.Baudrate = Convert.ToInt32(ConfigFile.ReadLine());
                Global.rawflashaccess = Convert.ToBoolean(ConfigFile.ReadLine());
                ConfigFile.Close();
            }
            catch (Exception ex)
            {
                Global.PortName = "COM1";
                Global.Baudrate = 57600;

                MessageBox.Show(ex.Message);
            }

            rpChannel.Enabled = false;
            rpMemory.Enabled = false;

            PortStatus.Text = Global.PortName;
            BaudValue.Text = Global.Baudrate.ToString();
            Global.PortState = false;

            cbSector.Enabled = false;
            cbSector.SelectedIndex = 0;

            Update_Status();

            this.WindowState = FormWindowState.Maximized;
        }

        private void bComPort_Click(object sender, EventArgs e)
        {
            if (Global.PortState)
            {
                bComPort.Image = global::DataRadio_CFG_SW.Properties.Resources.Start;
                bComPort.Text = "Open";
                Global.PortState = false;
                bComPort.Enabled = false;
                rpChannel.Enabled = false;
                rpMemory.Enabled = false;
                cbSector.Enabled = false;
                SettingsTab.Enabled = true;
            }
            else
            {
                bComPort.Image = global::DataRadio_CFG_SW.Properties.Resources.Stop;
                bComPort.Text = "Close";
                Global.PortState = true;
                rpChannel.Enabled = false;
                rpMemory.Enabled = false;
                cbSector.Enabled = false;
                SettingsTab.Enabled = false;
                radioHandler = new RadioHandler();
                radioHandler.MdiParent = this;
                radioHandler.Show();
            }
        }


        private void Settings_Click(object sender, EventArgs e)
        {
            Config_Port_Settings settings1 = new Config_Port_Settings();

            settings1.MdiParent = this;

            settings1.Show();
        }

        private void FlashRead_Click(object sender, EventArgs e)
        {
            radioHandler.ReadFlashMemory(cbSector.SelectedIndex);
        }
                     
        private void Prg_ch_Click(object sender, EventArgs e)
        {
            radioHandler.Program_Channel();
        }

        private void Factory_Reset_Click(object sender, EventArgs e)
        {
            radioHandler.Factory_default();
        }

        private void Read_Ch_Click(object sender, EventArgs e)
        {
            radioHandler.Read_Channel();
        }

        private void bComPort_DoubleClick(object sender, EventArgs e)
        {

        }
    }
}
