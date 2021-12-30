using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRadio_configurator
{
    public class SYNTH_REG_t
    {
        public byte[] RegAddr = new byte[44];
        public byte[] RegData_hi = new byte[44];
        public byte[] RegData_low = new byte[44];

        public void SYNTH_REG_t_update(int indx, byte x, byte y, byte z)
        {
            RegAddr[indx] = x;
            RegData_hi[indx] = y;
            RegData_low[indx] = z;
        }

    }
    static class Global
    {
        
        public static string PortName;
        public static int Baudrate;        
    }
}
