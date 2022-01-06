using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQLLiteConn_namespace
{
#if false
    class SQLLiteConn
    {
#region Properties
        private SQLiteConnection Conn;
#endregion

#region Constructor
        public SQLLiteConn(string dbName)
        {
            Conn = new SQLiteConnection("Data Source = " + dbName + "; Version = 3;");
        }
#endregion

#region Methods
        public bool OpenDataBase()
        {
            try
            {
                Conn.Open();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool Chk_login(string usrname)
        {

        }

        public string ReadDataBase()
        {
            
            
            while ()
            {
                
                Console.WriteLine(myreader);
            }
            Conn.Close();
            return myreader;
        }

#endregion
    }
#endif
}
