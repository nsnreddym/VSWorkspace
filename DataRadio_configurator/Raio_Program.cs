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

namespace DataRadio_configurator
{
    public partial class Radio_Program : Form
    {        
        SYNTH_REG_t synth_default_reg = new SYNTH_REG_t();
        SYNTH_REG_t synth_reg = new SYNTH_REG_t();

        const double DEN = 8000000;
        const double fpd = 20e6 * 1 * 1 * 4;
        const double fdev_TCAS = 4e3;
        const double fdev0_EOT = 1.8e3;
        const double fdev1_EOT = 1.2e3;
        const double prescaler = 2;
        //const int LF_R3_F1 = 4;
        const int LF_R3_F1 = 7;
        const int PFD_Delay_F1 = 4;
        const int MULT_F1 = 4;

        Int16 fdev0;
        Int16 fdev1;
        UInt16 N_int;
        UInt32 N_frac_num;
        UInt32 N_frac_den;
        int Chdiv1;
        int Chdiv2;

        public Radio_Program()
        {
            InitializeComponent();
        }

        private void tbWrite(string s)
        {
            tbStatus.Text += s;
            tbStatus.Text += Environment.NewLine;
        }
        private void tbclear()
        {
            tbStatus.Clear();
        }
        private bool Frequency_calc(double freq)
        {
            double VCO_freq;
            double Ndivider;
            double Nfrac;
            const double VCO_min = 4300;
            const double VCO_max = 5376;

            const int Chdiv1Max = 3;
            const int Chdiv1Min = 0;
            const int Chdiv2Max = 6;
            const int Chdiv2Min = 0;
            
            bool VCOtuned;

            double FSKPosDev;
            double FSKNegDev;

            VCOtuned = false;
            VCO_freq = 0;
            Chdiv2 = Chdiv2Min;
            Chdiv1 = Chdiv1Min;

            for (Chdiv1 = Chdiv1Min; Chdiv1Max >= Chdiv1; Chdiv1++)
            {
                for (Chdiv2 = Chdiv2Min; Chdiv2Max >= Chdiv2; Chdiv2++)
                {
                    VCO_freq = freq * (Chdiv1 + 4) * Math.Pow(2,Chdiv2);

                    if ((VCO_freq <= VCO_max) && (VCO_freq >= VCO_min))
                    {
                        VCOtuned = true;
                        break;
                    }
                }

                if ((VCO_freq <= VCO_max) && (VCO_freq >= VCO_min))
                {
                    VCOtuned = true;
                    break;
                }
            }

                    
            if (VCOtuned == true)
            {
                //calculate +ve swing
                if (rbEOT.Checked == true)
                {
                    FSKPosDev = ((fdev0_EOT * DEN / fpd) * ((Chdiv1 + 4) * Math.Pow(2, Chdiv2) / prescaler));
                    FSKNegDev = ((fdev1_EOT * DEN / fpd) * ((Chdiv1 + 4) * Math.Pow(2, Chdiv2) / prescaler));
                }
                else
                {
                    FSKPosDev = ((fdev_TCAS * DEN / fpd) * ((Chdiv1 + 4) * Math.Pow(2, Chdiv2) / prescaler));
                    FSKNegDev = -FSKPosDev;
                }
                
                Ndivider = VCO_freq*1e6 / (fpd * prescaler);
                N_int = (UInt16)(Ndivider);
                Nfrac = Ndivider - N_int;
                N_frac_num = Convert.ToUInt32(Nfrac * DEN);
                N_frac_den = Convert.ToUInt32(DEN);
                fdev0 = Convert.ToInt16(FSKPosDev);
                fdev1 = Convert.ToInt16(FSKNegDev);

            }

            return VCOtuned;
        }

        private int Upload_freq(int mode, int pwr)
        {
            byte[] bytedata = new byte[4];
            byte[] tmpdata = new byte[4];
            int indx;
            int reg;
            string[] pwrdata = new string[10];
            byte pwrvalue = new byte();

            StreamReader Pwrfile = new StreamReader(@".\PwrConfig.txt");

            for (int i= 0; i< 10; i++)
            {
                pwrdata[i] = Pwrfile.ReadLine();
            }
            Pwrfile.Close();
            indx = 0;

            //If Tx mode
            if (mode == 0)
            {
                //Reg 0x22--> 2FSK, PIN mode
                synth_reg.SYNTH_REG_t_update(0,0x22,0x10,0x20);

                //Reg 0x09--> FSK deviation 
                bytedata = BitConverter.GetBytes(fdev0);
                synth_reg.SYNTH_REG_t_update(1,0x09, bytedata[1], bytedata[0]);

                //Reg 0x0A--> FSK deviation
                bytedata = BitConverter.GetBytes(fdev1);
                synth_reg.SYNTH_REG_t_update(2,0x0A, bytedata[1], bytedata[0]);

                //Reg 0x08-->  FSK enable, tx power
                synth_reg.SYNTH_REG_t_update(3, 0x08, 0x04, 0x0E);

                //Reg 0x07-->  rx power
                //synth_reg.SYNTH_REG_t_update(4, 0x07, 0x00, 0x84);
                synth_reg.SYNTH_REG_t_update(4, 0x07, 0x00, 0x07);

                indx = 5;
            }

            //Reg 0x06-->  CH div
            reg = (LF_R3_F1 << 13) | (Chdiv2 << 10) | (Chdiv1 << 8) | (PFD_Delay_F1 << 5) | (MULT_F1);
            bytedata = BitConverter.GetBytes(reg);
            synth_reg.SYNTH_REG_t_update(indx + 0, 0x06, bytedata[1], bytedata[0]);

            //Reg 0x04-->  N int
            reg = (0x04 << 12) | (N_int & 0x0FFF);
            bytedata = BitConverter.GetBytes(reg);
            synth_reg.SYNTH_REG_t_update(indx + 1, 0x04, bytedata[1], bytedata[0]);

            //Reg 0x03-->  N frac_DEN
            bytedata = BitConverter.GetBytes(N_frac_den);
            synth_reg.SYNTH_REG_t_update(indx + 2, 0x03, bytedata[1], bytedata[0]);
            tmpdata = bytedata;

            //Reg 0x02-->  N frac_NUM
            bytedata = BitConverter.GetBytes(N_frac_num);
            synth_reg.SYNTH_REG_t_update(indx + 3, 0x02, bytedata[1], bytedata[0]);

            //Reg 0x01-->  N frac_NUM, N_frac_den
            synth_reg.SYNTH_REG_t_update(indx + 4, 0x01, tmpdata[2], bytedata[2]);

            //Reg 0x00-->  Reset
            synth_reg.SYNTH_REG_t_update(indx + 5, 0x00, 0x00, 0x83);

            pwrvalue = Convert.ToByte(pwrdata[pwr],16);

            if (mode == 0)
            {
                //Reg 0xFE-->  PWR
                synth_reg.SYNTH_REG_t_update(indx + 6, 0xFE, 0x00, pwrvalue);

                return indx + 7;
            }
            else
            {
                return indx + 6;
            }

        }

        private void Radio_Program_Load(object sender, EventArgs e)
        {
            synth_default_reg.SYNTH_REG_t_update(0, 0x3c, 0xa0, 0x00);
            synth_default_reg.SYNTH_REG_t_update(1, 0x3a, 0x8c, 0x00);
            synth_default_reg.SYNTH_REG_t_update(2, 0x35, 0x78, 0x06);
            synth_default_reg.SYNTH_REG_t_update(3, 0x2f, 0x60, 0x00);
            synth_default_reg.SYNTH_REG_t_update(4, 0x2a, 0x02, 0x10);
            synth_default_reg.SYNTH_REG_t_update(5, 0x29, 0x08, 0x10);
            synth_default_reg.SYNTH_REG_t_update(6, 0x28, 0x10, 0x1c);
            synth_default_reg.SYNTH_REG_t_update(7, 0x27, 0x11, 0xf2);
            synth_default_reg.SYNTH_REG_t_update(8, 0x23, 0x0c, 0x83);
            synth_default_reg.SYNTH_REG_t_update(9, 0x22, 0x10, 0x00);
            synth_default_reg.SYNTH_REG_t_update(10, 0x21, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(11, 0x20, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(12, 0x1F, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(13, 0x1e, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(14, 0x1d, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(15, 0x1c, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(16, 0x1b, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(17, 0x1a, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(18, 0x19, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(19, 0x18, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(20, 0x17, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(21, 0x16, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(22, 0x15, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(23, 0x14, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(24, 0x13, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(25, 0x12, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(26, 0x11, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(27, 0x10, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(28, 0x0f, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(29, 0x0e, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(30, 0x0d, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(31, 0x0c, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(32, 0x0b, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(33, 0x0a, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(34, 0x09, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(35, 0x08, 0x00, 0x00);
            synth_default_reg.SYNTH_REG_t_update(36, 0x07, 0x0E, 0x44);
            synth_default_reg.SYNTH_REG_t_update(37, 0x06, 0x86, 0x84);
            synth_default_reg.SYNTH_REG_t_update(38, 0x05, 0x01, 0x01);
            synth_default_reg.SYNTH_REG_t_update(39, 0x04, 0x20, 0x1f);
            synth_default_reg.SYNTH_REG_t_update(40, 0x03, 0x12, 0x00);
            synth_default_reg.SYNTH_REG_t_update(41, 0x02, 0xa1, 0x00);
            synth_default_reg.SYNTH_REG_t_update(42, 0x01, 0x7a, 0x77);
            synth_default_reg.SYNTH_REG_t_update(43, 0x00, 0x00, 0x83);

            cbTxPwr.SelectedIndex = 0;
            cbWrDefault.Checked = false;
            cbChannel.SelectedIndex = 0;
            lbDefault.Enabled = false;
            bWrite.Enabled = false;
            bErase.Enabled = false;
            Ch_no_CB.SelectedIndex = 0;

            rbTCAS.Checked = true;

        }

        private void Radio_Program_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void bWrite_Click(object sender, EventArgs e)
        {
            Comm ProgComm = new Comm();
            int returnval;

            returnval = ProgComm.EraseFlash(0);

            if (returnval == 1)
            {
                MessageBox.Show("Erase Success");
            }
            else
            {
                MessageBox.Show("Erase Fail");
            }

            returnval = 0;

            returnval = ProgComm.ProgDefault(returnval, synth_default_reg, 44);
            returnval = ProgComm.ProgDefault(returnval, synth_default_reg, 44);

            if (returnval == 360)
            {
                MessageBox.Show("Program Success " + returnval.ToString());
            }
            else
            {
                MessageBox.Show("Program Fail "+ returnval.ToString());
            }



        }

        private void bFErase_Click(object sender, EventArgs e)
        {
            Comm EraseComm = new Comm();
            int returnval;

            returnval = EraseComm.EraseFlash(0);

            if(returnval ==1)
            {
                MessageBox.Show("Erase Success");
            }
            else
            {
                MessageBox.Show("Erase Fail");
            }
        }

        private void bLoad_Click(object sender, EventArgs e)
        {
            double TxFreq_input;
            double RxFreq_input;
            int addr;
            Comm ProgComm = new Comm();
            int returnval_tx;
            int returnval_rx;

            UsrChannel.Enabled = false;

            tbclear();

            addr = (cbChannel.SelectedIndex + 1) * 65536;
            tbWrite("Erase Initiated");
            returnval_tx = ProgComm.EraseFlash(addr);
            tbWrite("Erase Success");

            TxFreq_input = Convert.ToDouble(TxFreq.Text);
            Frequency_calc(TxFreq_input);
            
            returnval_tx = Upload_freq(0, cbTxPwr.SelectedIndex);

            tbWrite("Tx channel address:" + addr.ToString("x"));
            addr = ProgComm.ProgChannel(addr, synth_reg, returnval_tx);
            tbWrite("Tx channel " + returnval_tx.ToString()+" Written");

            RxFreq_input = Convert.ToDouble(RxFreq.Text);
            Frequency_calc(RxFreq_input);
            
            returnval_rx = Upload_freq(1,cbTxPwr.SelectedIndex);

            tbWrite("Rx channel address:" + addr.ToString("x"));
            addr = ProgComm.ProgChannel(addr, synth_reg, returnval_rx);
            tbWrite("Rx channel " + returnval_rx.ToString() + " Written");

            UsrChannel.Enabled = true;
        }

        private void cbWrDefault_CheckedChanged(object sender, EventArgs e)
        {
            if (cbWrDefault.Checked == true)
            {
                lbDefault.Enabled = true;
                bWrite.Enabled = true;
                bErase.Enabled = true;
            }
            else
            {
                lbDefault.Enabled = false;
                bWrite.Enabled = false;
                bErase.Enabled = false;
            }
        }


        private void bSubmit_Click(object sender, EventArgs e)
        {
            byte[] chno = new byte[4];
            Comm CfgComm = new Comm();
            int returnval;

            chno = BitConverter.GetBytes(Ch_no_CB.SelectedIndex + 1);
            returnval = CfgComm.selch(chno[0]);

            tbclear();
            if (returnval == 1)
            {
                tbWrite(" Channel " + (Ch_no_CB.SelectedIndex + 1).ToString() + " Selected");
            }
            else
            {
                tbWrite("CMD failed");
            }
        }

        private void cbTxEN_CheckedChanged(object sender, EventArgs e)
        {
            byte[] chno = new byte[4];
            Comm CfgComm = new Comm();
            int returnval;

            returnval = CfgComm.TxEnable(cbTxEN.Checked, cbBit.SelectedIndex);

            
            if (returnval == 1)
            {
                tbWrite(" CMD success");
            }
            else
            {
                tbWrite("CMD failed");
            }
        }

        private void cbRxEN_CheckedChanged(object sender, EventArgs e)
        {
            byte[] chno = new byte[4];
            Comm CfgComm = new Comm();
            int returnval;

            returnval = CfgComm.RxEnable(cbRxEN.Checked);


            if (returnval == 1)
            {
                tbWrite(" CMD success");
            }
            else
            {
                tbWrite("CMD failed");
            }
        }

        private void cbTstMode_CheckedChanged(object sender, EventArgs e)
        {
            
            byte[] chno = new byte[4];
            Comm CfgComm = new Comm();
            int returnval;

            returnval = CfgComm.TstMode(cbTstMode.Checked);


            if (returnval == 1)
            {
                tbWrite(" CMD success");
            }
            else
            {
                tbWrite("CMD failed");
            }
        }
    }
}
