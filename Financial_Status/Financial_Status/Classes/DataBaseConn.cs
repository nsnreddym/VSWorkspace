using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SQLite;
using Globals;

namespace FinancialDataBase
{
    #region DataTypes
      
    
    public struct SAInfoData
    {
        public int ID;
        public string Name;
        public string AccNo;
        public string Bank;
        public double Balance;
    }

    public struct LNInfoData
    {
        public int ID;
        public string Name;
        public string AccNo;
        public string Bank;
        public double Balance;
        public double LoanAmount;
        public double EMI;
        public DateTime StartDate;
        public int Tenure;
        public string LnType;
        public double ROI;
    }

    public struct AccountInfoData
    {
        public int ID;
        public string Type;
        public string Name;
        public string InfoTable;
        public string DataTable;
        public SAInfoData SAInfo;
        public LNInfoData LNInfo;
    }
    #endregion

    static class DataBasedata
    {
        #region Properties
        public static List <AccountInfoData> accountinfo = new List<AccountInfoData>();
        #endregion

        #region AccoutInfo database Methods
        public static void ReadAccountInfo()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");
            string infotable;
            string AccType;

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();
            SQLiteCommand cmd2 = conn.CreateCommand();

            cmd.CommandText = "Select * from Account_Info";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                AccType = datareader.GetString(1);
                infotable = datareader.GetString(3);

                switch (AccType)
                {
                    case "Savings":

                        cmd2.CommandText = "Select * from " + infotable +" where Name = '" + datareader.GetString(2) + "'";

                        SQLiteDataReader datareader2 = cmd2.ExecuteReader();

                        datareader2.Read();

                        accountinfo.Add(new AccountInfoData
                        {
                            ID = datareader.GetInt32(0),
                            Type = AccType,
                            Name = datareader.GetString(2),
                            InfoTable = infotable,
                            DataTable = datareader.GetString(4),
                            SAInfo = new SAInfoData
                            {
                                ID = datareader2.GetInt32(0),
                                Name = datareader2.GetString(1),
                                AccNo = datareader2.GetString(2),
                                Bank = datareader2.GetString(3),
                                Balance = datareader2.GetDouble(4)
                            }
                        }) ;

                        datareader2.Close();

                        break;

                    case "Loan":

                        cmd2.CommandText = "Select * from " + infotable +" where Name = '" + datareader.GetString(2) + "'";

                        SQLiteDataReader datareader3 = cmd2.ExecuteReader();

                        datareader3.Read();

                        accountinfo.Add(new AccountInfoData
                        {
                            ID = datareader.GetInt32(0),
                            Type = AccType,
                            Name = datareader.GetString(2),
                            InfoTable = infotable,
                            DataTable = datareader.GetString(4),
                            LNInfo = new LNInfoData
                            {
                                ID = datareader3.GetInt32(0),
                                Name = datareader3.GetString(1),
                                AccNo = datareader3.GetString(2),
                                Bank = datareader3.GetString(3),
                                Balance = datareader3.GetDouble(4),
                                LoanAmount = datareader3.GetDouble(5),
                                EMI = datareader3.GetDouble(6),
                                //StartDate = datareader3.GetDateTime(7),
                                Tenure = datareader3.GetInt32(8),
                                LnType = datareader3.GetString(9),
                                ROI = datareader3.GetDouble(10)
                            }
                        }) ;

                        datareader3.Close();

                        break;

                    default:
                        break;
                }                

                //noAccounts++;
            }

            conn.Close();            
        }

        public static bool AddAccountInfo(string AccType, string NickName)
        {
            string infotable;
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            switch(AccType)
            {
                case "Savings":
                    infotable = new string("SavingAccount_Info");
                    break;

                case "Loan":
                    infotable = new string("LoanAccount_Info");
                    break;

                default:
                    conn.Close();
                    return false;
            }

            cmd.CommandText = @"Insert into Account_Info (Type, Name, InfoTable, DataTable) Values (" + " '" +
                                     AccType + "', '" +
                                     NickName + "', '" +
                                     infotable + "', '" +
                                     NickName + "');";

            cmd.ExecuteNonQuery(); 
            
            conn.Close();

            return true;
        }
        #endregion

        #region Savings Account Methods
        public static void UpdateSavingsInfo(String Name, string ACCNo, string Bank)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Insert into SavingAccount_Info (Name, AccountNo, Bank) Values (" + " '" +
                                Name + "', '" +
                                ACCNo + "', '" +
                                Bank + "');";

            cmd.ExecuteNonQuery(); 
            
            conn.Close();
        }

        public static void CreateNewSavingsAccount(String Name)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = GlobalVar.CreateSavingsAccount;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "Alter Table temp rename to " + Name;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion

        #region Loan Account Methods
        public static void UpdateLoanInfo(string Name, string ACCNo, string Bank, string LnAmt, string EMI, DateTime startdate, string NoEMI, 
                                          string LnType, string ROI)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Insert into LoanAccount_Info (Name, AccountNo, Bank, Balance, LoanAmount, EMI, StartDate, NoEMI, LoanType, ROI) Values (" + " '" +
                                Name + "', '" +
                                ACCNo + "', '" +
                                Bank + "', " +
                                LnAmt + ", " +
                                LnAmt + ", " +
                                EMI + ", " +
                                startdate.ToShortDateString() + ", " +
                                NoEMI + ", '" +
                                LnType + "', " +
                                ROI + ");";

            cmd.ExecuteNonQuery();

            conn.Close();
        }


        public static void CreateNewLoanAccount(String Name)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = GlobalVar.CreateLoanAccount;
            cmd.ExecuteNonQuery();

            cmd.CommandText = "Alter Table temp rename to " + Name;
            cmd.ExecuteNonQuery();

            conn.Close();
        }
        #endregion

        #region dummy

        public enum Errors
        {
            NO_ERROR = 0,
            LOGIN_FAILED,

            DATABASE_NOTFOUND = -1
        }

        public enum Category
        {
            MISC = 0,
            LOAN,
            SALARY,
            CHIT,
            FOOD,
            MAINTANANCE,
            BF
        }

        public struct Savings_ICICI_data
        {
            public DateTime date;
            public string Description;
            public double Amount;
            public int TranType;
            public int Category;
            public double Balance;
        }
        #endregion

        #region Properties

        #endregion

    }
}

#if false

#region Login Methods
        public Errors CheckLoginCredentials(string UsrName, string Passwd)
        {
            SQLiteConnection LoginConn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "Satya_Financial.db" + "; Version = 3;");
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

                LoginConn.Close();

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

#region Transactions
        public int LoadTableNames(string[] tableNames)
        {
            int count = 0;

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "Satya_Financial.db" + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"SELECT name FROM sqlite_schema WHERE type='table' ORDER BY name;";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            while(datareader.Read())
            {
                tableNames[count] = datareader.GetString(0);
                count++;
            }

            conn.Close();

            return count;
        }

        public int UpdateTransaction(string TableName, Savings_ICICI_data data, int datalen)
        {
            int noRecords;

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "Satya_Financial_v2.db" + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Insert into " + TableName + "(date, Description, Amount, TranType, Category, Balance)" +  " values ('" + data.date.ToShortDateString() + "', '"
                               + data.Description + "', "
                               + data.Amount.ToString() + ", "
                               + (data.TranType + 1).ToString() + ", "
                               + data.Category.ToString() + ", "
                               + data.Balance.ToString() + ");";

            noRecords = cmd.ExecuteNonQuery();

            conn.Close();

            return noRecords;

        }

        public List<Savings_ICICI_data> GetTransaction(string TableName)
        {
            int count;
            DataBaseConn.Savings_ICICI_data data = new Savings_ICICI_data(); ;
            List< Savings_ICICI_data> ts = new List<Savings_ICICI_data>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "Satya_Financial.db" + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Select * from " + TableName  + ";";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            count = 0;

            while (datareader.Read())
            {
                data.date = Convert.ToDateTime(datareader.GetString(0));
                data.Description = datareader.GetString(1);
                data.Amount = datareader.GetDouble(2);
                data.TranType = datareader.GetInt32(3);
                data.Category = datareader.GetInt32(4);
                data.Balance = datareader.GetDouble(5);
                ts.Add(data);   
                count++;
            }

            conn.Close();
            return ts;
        }

        public Savings_ICICI_data GetLastTransaction(string TableName)
        {
            DataBaseConn.Savings_ICICI_data data = new Savings_ICICI_data();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "Satya_Financial.db" + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Select * from " + TableName + " desc limit 1;";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            datareader.Read();

            data.date = Convert.ToDateTime(datareader.GetString(0));
            data.Description = datareader.GetString(1);
            data.Amount = datareader.GetDouble(2);
            data.TranType = datareader.GetInt32(3);
            data.Category = datareader.GetInt32(4);
            data.Balance = datareader.GetDouble(5);

            conn.Close();

            return data;
        }
#endregion
    


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