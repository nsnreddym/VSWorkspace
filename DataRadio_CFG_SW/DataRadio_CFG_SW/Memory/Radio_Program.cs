using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DataRadio_CFG_SW.Memory;

namespace DataRadio_CFG_SW
{
    public partial class Radio_Program : Form
    {
        private RADIO_COMM_STATES RadioCommState;
        private SYNTH_REG_t synth_default_reg = new SYNTH_REG_t();
        private SYNTH_REG_t synth_reg = new SYNTH_REG_t();

        public Radio_Program()
        {
            InitializeComponent();
        }

        private void Radio_Program_Load(object sender, EventArgs e)
        {

            RadioCommState = RADIO_COMM_STATES.IDLE;
            timer1.Interval = 2000;
            timer1.Tick += Timer1_Tick;
            timer1.Enabled = true;
            timer1.Start();
            WindowState = FormWindowState.Maximized;

            pbCOMState.Image = Properties.Resources.ButtonGray;

            SynthCalc.SetDefaultReg(ref synth_default_reg);

            string name;

            for (int i = 1; i <= 16; i++)
            {
                ChannelDisplay dis = new ChannelDisplay();
                dis.Name = "ConfigDisplay";
                name = "Channel " + i.ToString();
                ChannelTabs.TabPages.Add(name, name);
                ChannelTabs.TabPages[name].Controls.Add(dis);
            }

            cbSector.SelectedIndex = 0;

        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            Comm comm = new Comm();

            if (RadioCommState == RADIO_COMM_STATES.IDLE)
            {
                if (true == comm.HltReq())
                {
                    pbCOMState.Image = Properties.Resources.ButtonGreen;
                }
                else
                {
                    pbCOMState.Image = Properties.Resources.ButtonRed;
                }
            }
        }

        private void Radio_Program_FormClosed(object sender, FormClosedEventArgs e)
        {
            timer1.Stop();
        }

        private void FactorySettings_Click(object sender, EventArgs e)
        {
            Comm comm = new Comm();
            bool returnval;
            int MemAddr;

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
                MessageBox.Show("Erase failed");
            }

            //Program Rx values
            if (returnval)
            {                
                returnval = comm.ProgFlash(ref MemAddr, synth_default_reg, 44);
            }


            if (true == returnval)
            {
                pbCOMState.Image = Properties.Resources.ButtonGreen;

                MessageBox.Show("Program success Memaddr = " + MemAddr.ToString());
            }
            else
            {
                pbCOMState.Image = Properties.Resources.ButtonRed;

                MessageBox.Show("Program failed");
            } 
            
        }

        private void ReadMem_Click(object sender, EventArgs e)
        {
            Comm comm = new Comm();
            byte[] Mem = new byte[512];
            byte[] data = new byte[4];
            int baseaddress;
            FlashDisplay flashDisplay = new FlashDisplay();

            RadioCommState = RADIO_COMM_STATES.BUSY;
            pbCOMState.Image = Properties.Resources.ButtonYellow;

            panel1.Enabled = false;

            baseaddress = cbSector.SelectedIndex * 65536;

            for (int i = 0; i < 512; i+=4)
            {
                comm.Read_bytes(i+ baseaddress, ref data);
                Mem[i] = data[0];
                Mem[i + 1] = data[1];
                Mem[i + 2] = data[2];
                Mem[i + 3] = data[3];

                ((MainForm)this.MdiParent).Update_bar((i+1) * 100 / 512);
            }
            flashDisplay.UpdateFlashMemory(Mem);
            flashDisplay.ShowDialog();

            ((MainForm)this.MdiParent).Update_bar(0);

            panel1.Enabled = true;

            RadioCommState = RADIO_COMM_STATES.IDLE;
        }

        private void bRCh_Click(object sender, EventArgs e)
        {            
            int length_tx = new int();            
            int length_rx = new int();
            double txfreq = new double();
            double rxfreq = new double();
            int pwr = new int();
            int dummy = new int();
            byte[] data = new byte[4];
            int addr = new int();
            string name;

            SYNTH_REG_t synth_reg_tx = new SYNTH_REG_t();
            SYNTH_REG_t synth_reg_rx = new SYNTH_REG_t();
            Comm comm = new Comm();
            panel1.Enabled = false;

            RadioCommState = RADIO_COMM_STATES.BUSY;
            pbCOMState.Image = Properties.Resources.ButtonYellow;

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

                name = "Channel " + chno.ToString();
                ChannelDisplay dis = (ChannelDisplay)ChannelTabs.TabPages[name].Controls["ConfigDisplay"];
                dis.UpdateData(txfreq, rxfreq);
                ((MainForm)this.MdiParent).Update_bar((chno) * 100 / 16);
            }

            RadioCommState = RADIO_COMM_STATES.IDLE;
            panel1.Enabled = true;

            MessageBox.Show("Channels Read successfully");

            ((MainForm)this.MdiParent).Update_bar(0);

        }
        
        private void bPCh_Click(object sender, EventArgs e)
        {
            int chno;
            int addr;
            double TxFreq_input = new double();
            double RxFreq_input = new double();
            Comm comm = new Comm();
            bool returnval;
            string name;

            panel1.Enabled = false;
            RadioCommState = RADIO_COMM_STATES.BUSY;
            pbCOMState.Image = Properties.Resources.ButtonYellow;

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
                dis.ReadData(ref TxFreq_input, ref RxFreq_input);
                //TxFreq_input = Convert.ToDouble(436.8);
                length_tx = SynthCalc.SetFreqReg(ref synth_reg_tx, TxFreq_input, 0, 0);
                //RxFreq_input = Convert.ToDouble(436.8);
                length_rx = SynthCalc.SetFreqReg(ref synth_reg_rx, RxFreq_input, 1, 0);


                //Erase flash
                returnval = comm.EraseFlash(addr);

                //Program TX values
                if (returnval)
                {
                    returnval = comm.ProgFlash(ref addr, synth_reg_tx, length_tx);

                    //Program RX values
                    if (returnval)
                    {
                        returnval = comm.ProgFlash(ref addr, synth_reg_rx, length_rx);                        
                    }
                    else
                    {
                        MessageBox.Show("Tx data update failed for Channel " + chno.ToString());
                    }
                    
                }
                else
                {
                    MessageBox.Show("Erase failed for Channel " + chno.ToString());
                }
                                
                ((MainForm)this.MdiParent).Update_bar((chno)*100/16);
            }

            panel1.Enabled = true;
            RadioCommState = RADIO_COMM_STATES.IDLE;

            MessageBox.Show("Channels Programmed successfully");

            ((MainForm)this.MdiParent).Update_bar((0));
        }
    }}
