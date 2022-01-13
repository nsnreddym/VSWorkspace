using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using FinancialDataBase;

namespace Globals
{
    static class GlobalVar
    {
        static public string DataBasePath = @".\";
        static public string UserName;
        static public int MaxTables;
        static public DataBasedata dataBasedata = new DataBasedata();
    }
}
