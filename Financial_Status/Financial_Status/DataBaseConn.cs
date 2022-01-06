using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLLiteConn_namespace;
using System.Data.SQLite;
using Globals;

namespace Financial_Status
{
    class DataBaseConn
    {
        #region DataTypes
        public enum Errors
        {
            NO_ERROR = 0,
            LOGIN_FAILED,

            DATABASE_NOTFOUND = -1
        }
        #endregion

        #region Properties
        private SQLiteConnection LoginConn;
        #endregion

        #region Login Methods
        public Errors CheckLoginCredentials(string UsrName, string Passwd)
        {
            //Create connection
            LoginConn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "Satya_Financial.db" + "; Version = 3;");
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            string myreader = "";
            
            try 
            {
                //Open connection
                LoginConn.Open();

                //Execute command
                sqlite_cmd = LoginConn.CreateCommand();
                sqlite_cmd.CommandText = @"SELECT Passwd FROM Login where LoginId = '" + UsrName + "'";
                sqlite_datareader = sqlite_cmd.ExecuteReader();

                //Read data
                sqlite_datareader.Read();

                //Check data
                myreader = sqlite_datareader.GetString(0);

                if(myreader == Passwd)
                {
                    return Errors.NO_ERROR;
                }

                return Errors.LOGIN_FAILED;
            }
            catch (Exception ex)
            {
                return Errors.DATABASE_NOTFOUND;
            }
        }
        #endregion
    }
}

#if false

public static SQLiteConnection CreateConnection()
{

    SQLiteConnection sqlite_conn;
    // Create a new database connection:
    sqlite_conn = new SQLiteConnection("Data Source = LoginInfo.db; Version = 3; New = True; Compress = True; ");
    // Open the connection:
    try
    {
        sqlite_conn.Open();
    }
    catch (Exception ex)
    {

    }
    return sqlite_conn;
}

public static void CreateTable(SQLiteConnection conn)
{

    SQLiteCommand sqlite_cmd;
    string Createsql = "CREATE TABLE SampleTable(Col1 VARCHAR(20), Col2 INT)";
    sqlite_cmd = conn.CreateCommand();
    sqlite_cmd.CommandText = Createsql;
    sqlite_cmd.ExecuteNonQuery();

}

public static void InsertData(SQLiteConnection conn)
{
    SQLiteCommand sqlite_cmd;
    sqlite_cmd = conn.CreateCommand();
    sqlite_cmd.CommandText = "INSERT INTO SampleTable(Col1, Col2) VALUES('Test Text ', 1); ";
    sqlite_cmd.ExecuteNonQuery();
}

public static string ReadData(SQLiteConnection conn)
{
    SQLiteDataReader sqlite_datareader;
    SQLiteCommand sqlite_cmd;
    string myreader = "";
    sqlite_cmd = conn.CreateCommand();
    sqlite_cmd.CommandText = "SELECT * FROM SampleTable";
    sqlite_datareader = sqlite_cmd.ExecuteReader();
    while (sqlite_datareader.Read())
    {
        myreader = sqlite_datareader.GetString(0);
        Console.WriteLine(myreader);
    }
    conn.Close();
    return myreader;
}

#endif