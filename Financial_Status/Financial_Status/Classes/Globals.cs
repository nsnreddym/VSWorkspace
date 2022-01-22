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
        static public bool IsLogged;
        static public int MaxTables;
        //static public DataBasedata dataBasedata = new DataBasedata();

        static public readonly string CreateSavingsAccount = new string("Create Table temp (UID         INTEGER      PRIMARY KEY ASC," +
                                                                         "Date        DATE         NOT NULL ON CONFLICT ABORT," +
                                                                         "Description STRING(100)," +
                                                                         "Amount      DOUBLE       NOT NULL ON CONFLICT ABORT," +
                                                                         "TranType    DECIMAL      NOT NULL ON CONFLICT ABORT," +
                                                                         "Category    DECIMAL      NOT NULL ON CONFLICT ABORT," +
                                                                         "Balance     DOUBLE       NOT NULL ON CONFLICT ABORT " +
                                                                                                  "DEFAULT(0)); ");

        static public readonly string CreateLoanAccount = new string("CREATE TABLE temp (" + 
                                                                     "UID  INTEGER PRIMARY KEY ASC AUTOINCREMENT," + 
                                                                     "Date DATE," +
                                                                     "EMI  DOUBLE);");

    }
}
