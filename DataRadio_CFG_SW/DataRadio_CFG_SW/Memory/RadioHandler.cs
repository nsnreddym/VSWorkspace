using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataRadio_CFG_SW.COMM;
using DataRadio_CFG_SW.UserControls;

namespace DataRadio_CFG_SW.Memory
{
    public partial class RadioHandler : Form
    {
        private RADIO_COMM_STATES RadioCommState;
        private Timer timer1 = new Timer();
        byte[] flashData = new byte[512];
        private SYNTH_REG_t synth_default_reg = new SYNTH_REG_t();

        public RadioHandler()
        {
            InitializeComponent();
        }
        private void Timer1_Tick(object sender, EventArgs e)
        {
            Comm comm = new Comm();
            byte[] status = new byte[16];

            if(Global.PortState == false)
            {
                timer1.Stop();                
                Close();
            }

            else if (RadioCommState == RADIO_COMM_STATES.IDLE)
            {
                if (true == comm.HltReq(ref status))
                {
                    ((DataRadioCfgSw)MdiParent).Update_Status(status);
                    ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.OK);
                }
                else
                {
                    ((DataRadioCfgSw)MdiParent).Update_Status();
                    ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.FAIL);
                }
            }
        }

        private void RadioHandler_Load(object sender, EventArgs e)
        {
            FlashReadReady();

            RadioCommState = RADIO_COMM_STATES.IDLE;

            timer1.Interval = 1000;
            timer1.Tick += Timer1_Tick;            

            SynthCalc.SetDefaultReg(ref synth_default_reg);

            string name;

            for (int i = 1; i <= 16; i++)
            {
                ChannelDisplay dis = new ChannelDisplay();
                dis.Name = "ConfigDisplay";
                name = "Channel " + i.ToString();
                ChannelTabs.TabPages.Add(name, name);
                //ChannelTabs.TabPages[name].Font = new Font(FontFamily.GenericSerif, (float)9.75, FontStyle.Bold);
                ChannelTabs.Font = new Font(FontFamily.GenericSerif, (float)9.75, FontStyle.Bold);
                ChannelTabs.TabPages[name].Controls.Add(dis);
                ChannelTabs.TabPages[name].AutoScroll = true;
            }
            
            Read_Channel();            
            WindowState = FormWindowState.Maximized;

            timer1.Enabled = true;
            timer1.Start();
        }

        
        #region Flash Display Routines ----------------------------

        private void FlashReadReady()
        {
            DataGridViewCellStyle datacellstyle = new DataGridViewCellStyle();
            DataGridViewCellStyle groupcellstyle = new DataGridViewCellStyle();
            string name;

            datacellstyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            datacellstyle.BackColor = Color.White;
            datacellstyle.ForeColor = Color.Black;
            datacellstyle.Font = new Font("Microsoft Sans Serif", 8, FontStyle.Regular);

            groupcellstyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            groupcellstyle.BackColor = Color.White;
            groupcellstyle.ForeColor = Color.Black;
            groupcellstyle.Font = new Font("Microsoft Sans Serif", 9, FontStyle.Bold);

            name = "Addr";
            FlashMemView.Columns.Add(name, name);
            FlashMemView.Columns[name].DefaultCellStyle = FlashMemView.DefaultCellStyle;
            FlashMemView.Columns[name].SortMode = DataGridViewColumnSortMode.NotSortable;
            FlashMemView.Columns[name].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            FlashMemView.Columns[name].ReadOnly = true;
            FlashMemView.Columns[name].DefaultCellStyle = groupcellstyle;

            for (int i = 0; i < 16; i++)
            {
                name = "Col" + i.ToString("X2");
                FlashMemView.Columns.Add(name, i.ToString("X2"));
                FlashMemView.Columns[name].DefaultCellStyle = FlashMemView.DefaultCellStyle;
                FlashMemView.Columns[name].SortMode = DataGridViewColumnSortMode.NotSortable;
                FlashMemView.Columns[name].AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                FlashMemView.Columns[name].ReadOnly = true;
                FlashMemView.Columns[name].DefaultCellStyle = datacellstyle;
            }

            FlashMemView.Dock = DockStyle.Fill;

            FlashMemView.Enabled = false;
            FlashMemView.Visible = false;
            ChannelTabs.Enabled = false;
            ChannelTabs.Visible = false;

        }

        public void ReadFlashMemory(int sector)
        {
            Comm comm = new Comm();
            byte[] Mem = new byte[512];
            byte[] data = new byte[4];
            int baseaddress;

            baseaddress = sector * 65536;

            RadioCommState = RADIO_COMM_STATES.BUSY;
            ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.BUSY);

            for (int i = 0; i < 512; i += 4)
            {
                comm.Read_bytes(i + baseaddress, ref data);
                flashData[i] = data[0];
                flashData[i + 1] = data[1];
                flashData[i + 2] = data[2];
                flashData[i + 3] = data[3];

                ((DataRadioCfgSw)MdiParent).Update_bar((i + 1) * 100 / 512);
            }

            ShowFlashMemory();

            RadioCommState = RADIO_COMM_STATES.IDLE;
            ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.OK);
            ((DataRadioCfgSw)MdiParent).Update_bar(0);

        }

        private void ShowFlashMemory()
        {
            string name;

            for (int i = 0; i < 32; i++)
            {
                FlashMemView.Rows.Add();

                FlashMemView.Rows[i].Cells["Addr"].Value = i.ToString("X6");

                for (int j = 0; j < 16; j++)
                {
                    name = "Col" + j.ToString("X2");
                    FlashMemView.Rows[i].Cells[name].Value = flashData[i * 16 + j].ToString("X2");
                }
            }

            FlashMemView.Enabled = true;
            FlashMemView.Visible = true;
            ChannelTabs.Enabled = false;
            ChannelTabs.Visible = false;
        }

        #endregion

        #region Channel Handling Routines -----------------------
        public void Program_Channel()
        {
            int chno;
            int addr;
            double TxFreq_input = new double();
            double RxFreq_input = new double();
            int Txpwr = new int();
            Comm comm = new Comm();
            bool returnval;
            string name;

            FlashMemView.Enabled = false;
            FlashMemView.Visible = false;
            
            ChannelTabs.Dock = DockStyle.Fill;


            RadioCommState = RADIO_COMM_STATES.BUSY;
            ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.BUSY);

            SYNTH_REG_t synth_reg_tx = new SYNTH_REG_t();
            int length_tx = new int();
            SYNTH_REG_t synth_reg_rx = new SYNTH_REG_t();
            int length_rx = new int();

            for (chno = 1; chno <= 16; chno++)
            {
                //Calculate address
                addr = (chno) * 65536;

                //Calculate Frequencies
                name = "Channel " + chno.ToString();
                ChannelDisplay dis = (ChannelDisplay)ChannelTabs.TabPages[name].Controls["ConfigDisplay"];
                dis.ReadData(ref TxFreq_input, ref RxFreq_input, ref Txpwr);
                //TxFreq_input = Convert.ToDouble(436.8);
                length_tx = SynthCalc.SetFreqReg(ref synth_reg_tx, TxFreq_input, 0, Txpwr);
                //RxFreq_input = Convert.ToDouble(436.8);
                length_rx = SynthCalc.SetFreqReg(ref synth_reg_rx, RxFreq_input, 1, 0);


                //Erase flash
                returnval = comm.EraseFlash(addr);

                //Program TX values
                if (returnval)
                {
                    returnval = comm.ProgFlash(ref addr, synth_reg_tx, length_tx);
                }
                else
                {
                    MessageBox.Show("Erase failed for Channel " + chno.ToString());
                }
                //Program RX values
                if (returnval)
                {
                    returnval = comm.ProgFlash(ref addr, synth_reg_rx, length_rx);
                }
                else
                {
                    MessageBox.Show("Tx data update failed for Channel " + chno.ToString());
                }
                //Program Baudrate data
                if (returnval)
                {
                    byte[] data = dis.ReadBaudData();
                    returnval = comm.ProgBauddata(ref addr, data, 6);
                }
                else
                {
                    MessageBox.Show("Rx data update failed for Channel " + chno.ToString());
                }

                ((DataRadioCfgSw)MdiParent).Update_bar((chno) * 100 / 16);
            }

            RadioCommState = RADIO_COMM_STATES.IDLE;
            ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.OK);
            MessageBox.Show("Channels Programmed successfully");

            ChannelTabs.Enabled = true;
            ChannelTabs.Visible = true;
            ChannelTabs.SelectedIndex = 0;

            ((DataRadioCfgSw)MdiParent).Update_bar(0);
        }

        public void Read_Channel()
        {
            int length_tx = new int();
            int length_rx = new int();
            double txfreq = new double();
            double rxfreq = new double();
            int pwr = new int();
            int dummy = new int();
            byte[] data = new byte[4];
            byte[] bauddata = new byte[6];
            int addr = new int();
            string name;
            

            SYNTH_REG_t synth_reg_tx = new SYNTH_REG_t();
            SYNTH_REG_t synth_reg_rx = new SYNTH_REG_t();
            Comm comm = new Comm();

            FlashMemView.Enabled = false;
            FlashMemView.Visible = false;
            
            ChannelTabs.Dock = DockStyle.Fill;

            RadioCommState = RADIO_COMM_STATES.BUSY;
            ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.BUSY);

            //Read data from flash
            int chno;
            txfreq = 416.8;
            rxfreq = 416.8;

            for (chno = 1; chno <= 16; chno++)
            {
                addr = chno * 65536;

                //Read Tx data
                comm.Read_bytes(addr, ref data);
                addr += 4;
                name = "Channel " + chno.ToString();


                if ((data[0] == 0xAA) && (data[1] == 0xAA))
                {
                    length_tx = data[3];

                    for (int i = 0; i < length_tx; i++)
                    {
                        comm.Read_bytes(addr, ref data);
                        synth_reg_tx.reg_update(i, data[1], data[2], data[3]);

                        addr += 4;
                    }
                    
                    SynthCalc.GetFreqReg(synth_reg_tx, length_tx, ref txfreq, ref pwr);

                }

                //Read Rx data            
                comm.Read_bytes(addr, ref data);
                addr += 4;

                if ((data[0] == 0xAA) && (data[1] == 0xAA))
                {
                    length_rx = data[3];

                    for (int i = 0; i < length_rx; i++)
                    {
                        comm.Read_bytes(addr, ref data);
                        synth_reg_rx.reg_update(i, data[1], data[2], data[3]);

                        addr += 4;
                    }

                    SynthCalc.GetFreqReg(synth_reg_rx, length_rx, ref rxfreq, ref dummy);
                }

                //Read Baud data            
                comm.Read_bytes(addr, ref data);
                addr += 4;

                if ((data[0] == 0xAA) && (data[1] == 0xAA))
                {
                    comm.Read_bytes(addr, ref data);
                    addr += 4;
                    bauddata[0] = data[0];
                    bauddata[1] = data[1];
                    bauddata[2] = data[2];
                    bauddata[3] = data[3];

                    comm.Read_bytes(addr, ref data);
                    addr += 4;
                    bauddata[4] = data[0];
                    bauddata[5] = data[1];                    
                }

                name = "Channel " + chno.ToString();
                ChannelDisplay dis = (ChannelDisplay)ChannelTabs.TabPages[name].Controls["ConfigDisplay"];
                dis.UpdateData(txfreq, rxfreq,pwr);
                dis.UpdateBaudData(bauddata);
                ((DataRadioCfgSw)MdiParent).Update_bar((chno) * 100 / 16);

                
            }

            RadioCommState = RADIO_COMM_STATES.IDLE;
            ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.OK);
            MessageBox.Show("Channels Read successfully");

            ChannelTabs.Enabled = true;
            ChannelTabs.Visible = true;

            ((DataRadioCfgSw)MdiParent).Update_bar(0);            

        }
        
        public void Factory_default()
        {
            Comm comm = new Comm();
            bool returnval;
            int MemAddr;

            FlashMemView.Enabled = false;
            FlashMemView.Visible = false;
            ChannelTabs.Enabled = false;
            ChannelTabs.Visible = false;

            RadioCommState = RADIO_COMM_STATES.BUSY;
            ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.BUSY);

            //Erase flash
            returnval = comm.EraseFlash(0);

            MemAddr = 0;

            //Program TX values
            if (returnval)
            {
                returnval = comm.ProgFlash(ref MemAddr, synth_default_reg, 44);
            }
            else
            {
                ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.FAIL);
                MessageBox.Show("Erase failed");
            }

            //Program Rx values
            if (returnval)
            {
                returnval = comm.ProgFlash(ref MemAddr, synth_default_reg, 44);
            }


            if (true == returnval)
            {
                ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.OK);
                MessageBox.Show("Program success Memaddr = " + MemAddr.ToString());
            }
            else
            {
                ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.FAIL);
                MessageBox.Show("Program failed");
            }

            RadioCommState = RADIO_COMM_STATES.IDLE;
            ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.IDLE);
        }
        #endregion

        private void RadioHandler_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((DataRadioCfgSw)MdiParent).Update_ComState(COMM_STATES.IDLE);
            ((DataRadioCfgSw)MdiParent).Update_bcom(false);
            Global.PortState = false;
            //while (timer1.Enabled) ;
        }

        private void RadioHandler_KeyDown(object sender, KeyEventArgs e)
        {
            fnKey_handler(e.KeyCode);
            e.Handled = true;
        }

        private void ChannelTabs_KeyDown(object sender, KeyEventArgs e)
        {
            fnKey_handler(e.KeyCode);
            e.Handled = true;
        }

        private void fnKey_handler(Keys KeyCode)
        {
            Comm comm = new Comm();
            bool returnval;
            returnval = false;

            if (ChannelTabs.Visible == true)
            {
                switch (KeyCode)
                {
                    case Keys.F9:
                        returnval = comm.selch(Convert.ToByte(ChannelTabs.SelectedIndex + 1));
                        break;
                    case Keys.F5:
                        returnval = comm.TxEnable(true,0);
                        break;
                    case Keys.F6:
                        returnval = comm.TxEnable(false,0);
                        break;
                }
                /*if (returnval)
                {
                    MessageBox.Show("Channel Selected: " + (ChannelTabs.SelectedIndex + 1).ToString());
                }
                else
                {
                    MessageBox.Show("Channel Select failed");
                }*/
            }
        }

        private void ChannelTabs_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
