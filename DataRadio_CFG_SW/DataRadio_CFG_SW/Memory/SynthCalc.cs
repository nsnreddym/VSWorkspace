using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace DataRadio_CFG_SW.Memory
{
    public class SYNTH_REG_t
    {
        public byte[] RegAddr = new byte[44];
        public byte[] RegData_hi = new byte[44];
        public byte[] RegData_low = new byte[44];

        public void reg_update(int indx, byte x, byte y, byte z)
        {
            RegAddr[indx] = x;
            RegData_hi[indx] = y;
            RegData_low[indx] = z;
        }

        public bool reg_read(byte addr, int len, ref int Reg)
        {
            for(int i = 0; i < len; i++)
            {
                if(RegAddr[i] == addr)
                {
                    Reg = RegData_hi[i] << 8 | RegData_low[i];
                    return true;
                }
            }
            return false;
        }

    }

    static class SynthCalc
    {
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

        static Int16 fdev0;
        static Int16 fdev1;
        static UInt16 N_int;
        static UInt32 N_frac_num;
        static UInt32 N_frac_den;
        static int Chdiv1;
        static int Chdiv2;

        private static bool Frequency_calc(double freq)
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
                    VCO_freq = freq * (Chdiv1 + 4) * Math.Pow(2, Chdiv2);

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
                /*if (rbEOT.Checked == true)
                {
                    FSKPosDev = ((fdev0_EOT * DEN / fpd) * ((Chdiv1 + 4) * Math.Pow(2, Chdiv2) / prescaler));
                    FSKNegDev = ((fdev1_EOT * DEN / fpd) * ((Chdiv1 + 4) * Math.Pow(2, Chdiv2) / prescaler));
                }
                else*/
                {
                    FSKPosDev = ((fdev_TCAS * DEN / fpd) * ((Chdiv1 + 4) * Math.Pow(2, Chdiv2) / prescaler));
                    FSKNegDev = -FSKPosDev;
                }

                Ndivider = VCO_freq * 1e6 / (fpd * prescaler);
                N_int = (UInt16)(Ndivider);
                Nfrac = Ndivider - N_int;
                N_frac_num = Convert.ToUInt32(Nfrac * DEN);
                N_frac_den = Convert.ToUInt32(DEN);
                fdev0 = Convert.ToInt16(FSKPosDev);
                fdev1 = Convert.ToInt16(FSKNegDev);

            }

            return VCOtuned;
        }

        public static void SetDefaultReg(ref SYNTH_REG_t defaultReg)
        {
            defaultReg.reg_update(0, 0x3c, 0xa0, 0x00);
            defaultReg.reg_update(1, 0x3a, 0x8c, 0x00);
            defaultReg.reg_update(2, 0x35, 0x78, 0x06);
            defaultReg.reg_update(3, 0x2f, 0x60, 0x00);
            defaultReg.reg_update(4, 0x2a, 0x02, 0x10);
            defaultReg.reg_update(5, 0x29, 0x08, 0x10);
            defaultReg.reg_update(6, 0x28, 0x10, 0x1c);
            defaultReg.reg_update(7, 0x27, 0x11, 0xfB);
            defaultReg.reg_update(8, 0x23, 0x0c, 0x83);
            defaultReg.reg_update(9, 0x22, 0x10, 0x00);
            defaultReg.reg_update(10, 0x21, 0x00, 0x00);
            defaultReg.reg_update(11, 0x20, 0x00, 0x00);
            defaultReg.reg_update(12, 0x1F, 0x00, 0x00);
            defaultReg.reg_update(13, 0x1e, 0x00, 0x00);
            defaultReg.reg_update(14, 0x1d, 0x00, 0x00);
            defaultReg.reg_update(15, 0x1c, 0x00, 0x00);
            defaultReg.reg_update(16, 0x1b, 0x00, 0x00);
            defaultReg.reg_update(17, 0x1a, 0x00, 0x00);
            defaultReg.reg_update(18, 0x19, 0x00, 0x00);
            defaultReg.reg_update(19, 0x18, 0x00, 0x00);
            defaultReg.reg_update(20, 0x17, 0x00, 0x00);
            defaultReg.reg_update(21, 0x16, 0x00, 0x00);
            defaultReg.reg_update(22, 0x15, 0x00, 0x00);
            defaultReg.reg_update(23, 0x14, 0x00, 0x00);
            defaultReg.reg_update(24, 0x13, 0x00, 0x00);
            defaultReg.reg_update(25, 0x12, 0x00, 0x00);
            defaultReg.reg_update(26, 0x11, 0x00, 0x00);
            defaultReg.reg_update(27, 0x10, 0x00, 0x00);
            defaultReg.reg_update(28, 0x0f, 0x00, 0x00);
            defaultReg.reg_update(29, 0x0e, 0x00, 0x00);
            defaultReg.reg_update(30, 0x0d, 0x00, 0x00);
            defaultReg.reg_update(31, 0x0c, 0x00, 0x00);
            defaultReg.reg_update(32, 0x0b, 0x00, 0x00);
            defaultReg.reg_update(33, 0x0a, 0x00, 0x00);
            defaultReg.reg_update(34, 0x09, 0x00, 0x00);
            defaultReg.reg_update(35, 0x08, 0x00, 0x00);
            defaultReg.reg_update(36, 0x07, 0x0E, 0x44);
            defaultReg.reg_update(37, 0x06, 0x86, 0x84);
            defaultReg.reg_update(38, 0x05, 0x01, 0x01);
            defaultReg.reg_update(39, 0x04, 0x20, 0x1f);
            defaultReg.reg_update(40, 0x03, 0x12, 0x00);
            defaultReg.reg_update(41, 0x02, 0xa1, 0x00);
            defaultReg.reg_update(42, 0x01, 0x7a, 0x77);
            defaultReg.reg_update(43, 0x00, 0x00, 0x83);

        }

        public static int SetFreqReg(ref SYNTH_REG_t synth_reg, double Freq, int mode, int pwr)
        {
            byte[] bytedata = new byte[4];
            byte[] tmpdata = new byte[4];
            int indx;
            int reg;
            string[] pwrdata = new string[10];
            byte pwrvalue = new byte();

            //StreamReader Pwrfile = new StreamReader(@".\PwrConfig.txt");
            StreamReader Pwrfile = new StreamReader(Global.pwrcfgfname);

            for (int i = 0; i < 10; i++)
            {
                pwrdata[i] = Pwrfile.ReadLine();
            }
            Pwrfile.Close();

            indx = 0;

            Frequency_calc(Freq);

            //If Tx mode
            if (mode == 0)
            {
                //Reg 0x22--> 2FSK, PIN mode
                synth_reg.reg_update(0, 0x22, 0x10, 0x20);

                //Reg 0x09--> FSK deviation 
                bytedata = BitConverter.GetBytes(fdev0);
                synth_reg.reg_update(1, 0x09, bytedata[1], bytedata[0]);

                //Reg 0x0A--> FSK deviation
                bytedata = BitConverter.GetBytes(fdev1);
                synth_reg.reg_update(2, 0x0A, bytedata[1], bytedata[0]);

                //Reg 0x08-->  FSK enable, tx power
                synth_reg.reg_update(3, 0x08, 0x04, 0x0E);

                //Reg 0x07-->  rx power
                //synth_reg.reg_update(4, 0x07, 0x00, 0x87);
                synth_reg.reg_update(4, 0x07, 0x00, 0x07);

                indx = 5;
            }

            //Reg 0x06-->  CH div
            reg = (LF_R3_F1 << 13) | (Chdiv2 << 10) | (Chdiv1 << 8) | (PFD_Delay_F1 << 5) | (MULT_F1);
            bytedata = BitConverter.GetBytes(reg);
            synth_reg.reg_update(indx + 0, 0x06, bytedata[1], bytedata[0]);

            //Reg 0x04-->  N int
            reg = (0x04 << 12) | (N_int & 0x0FFF);
            bytedata = BitConverter.GetBytes(reg);
            synth_reg.reg_update(indx + 1, 0x04, bytedata[1], bytedata[0]);

            //Reg 0x03-->  N frac_DEN
            bytedata = BitConverter.GetBytes(N_frac_den);
            synth_reg.reg_update(indx + 2, 0x03, bytedata[1], bytedata[0]);
            tmpdata = bytedata;

            //Reg 0x02-->  N frac_NUM
            bytedata = BitConverter.GetBytes(N_frac_num);
            synth_reg.reg_update(indx + 3, 0x02, bytedata[1], bytedata[0]);

            //Reg 0x01-->  N frac_NUM, N_frac_den
            synth_reg.reg_update(indx + 4, 0x01, tmpdata[2], bytedata[2]);

            //Reg 0x00-->  Reset
            synth_reg.reg_update(indx + 5, 0x00, 0x00, 0x83);

            pwrvalue = Convert.ToByte(pwrdata[pwr], 16);

            if (mode == 0)
            {
                //Reg 0xFE-->  PWR
                synth_reg.reg_update(indx + 6, 0xFE, 0x00, pwrvalue);

                return indx + 7;
            }
            else
            {
                return indx + 6;
            }

        }

        public static bool GetFreqReg(SYNTH_REG_t synth_reg, int len, ref double Freq, ref int pwr)
        {
            int reg = new int();
            bool status;
            bool overallstatus;

            int div2 = 0;
            int div1 = 0;
            int nInt = 0;
            double nFrac;
            UInt32 nFrac_num = 0;
            UInt32 nFrac_den = 0;
            string[] pwrdata = new string[10];

            //StreamReader Pwrfile = new StreamReader(@".\PwrConfig.txt");
            StreamReader Pwrfile = new StreamReader(Global.pwrcfgfname);

            for (int i = 0; i < 10; i++)
            {
                pwrdata[i] = Pwrfile.ReadLine();
            }
            Pwrfile.Close();

            //Read Power
            status = synth_reg.reg_read(0xFE, len, ref reg);
            pwr = 0;
            if (status == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    if(reg == Convert.ToByte(pwrdata[i], 16))
                    {
                        pwr = i + 1;
                    }
                }
            }

            //Read chdiv
            status = synth_reg.reg_read(0x06, len, ref reg);
            if (status == true)
            {
                div2 = (reg >> 10) & 0x0007;
                div1 = (reg >> 8) & 0x0003;
            }
            overallstatus = status;

            //Read N int
            status = synth_reg.reg_read(0x04, len, ref reg);
            if (status == true)
            {
                nInt = reg & 0x0FFF;
            }
            overallstatus = overallstatus && status;

            //Read nFrac_den
            status = synth_reg.reg_read(0x03, len, ref reg);
            if (status == true)
            {
                nFrac_den = (UInt32)reg;
            }
            overallstatus = overallstatus && status;

            //Read nFrac_num
            status = synth_reg.reg_read(0x02, len, ref reg);
            if (status == true)
            {
                nFrac_num = (UInt32)reg;
            }
            overallstatus = overallstatus && status;

            //Read nFrac_num, nFrac_den
            status = synth_reg.reg_read(0x01, len, ref reg);
            if (status == true)
            {
                nFrac_num = ((UInt32)(reg & 0xFF)) << 16 | ((UInt32)nFrac_num);
                nFrac_den = ((UInt32)(reg & 0xFF00)) << 8 | (UInt32)nFrac_den;
            }
            overallstatus = overallstatus && status;

            if ((overallstatus == true) && (nFrac_den != 0))
            {
                nFrac = (double)nFrac_num / (double)nFrac_den;
                nFrac = nInt + nFrac;

                /* Calculate VCO frequency
                 *  fPD = 80MHz,
                 *  prescalar 2 */
                Freq = nFrac * 80 * 2;

                Freq = Freq / ((div1 + 4) * Math.Pow(2, div2));

                return true;
            }
            return false;
        }


    }
}
