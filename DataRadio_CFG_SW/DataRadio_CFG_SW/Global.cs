using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataRadio_CFG_SW
{ 
    

    public enum RADIO_COMM_STATES
    {
        IDLE,
        BUSY
    }
    static class Global
    {
        
        public static string PortName;
        public static int Baudrate;
        public static string DBPortName;
        public static int DBBaudrate;
        public static bool PortState;
        public static bool rawflashaccess;
        public static bool rssilatchen;
        public static string pwrcfgfname;
        public static bool cfgvalid;
    }
}
