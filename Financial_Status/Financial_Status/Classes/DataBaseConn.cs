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
        public double BEMI;
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

    public struct SavingsAccData
    {
        public DateTime date;
        public string Description;
        public double Amount;
        public TransType TranType;
        public Category Category;
        public string CreditAc;
    }

    public enum Category
    {
        Misc = 0,
        Loan,
        Salary,
        Chit,
        Food,
        Maintanance,
        Transfer,
        Incentivies,
        BF
    }

    public enum TransType
    {
        Dr = 0,
        Cr,
        Tr_SA,
        Tr_LN
    }

    public enum Errors
    {
        NO_ERROR = 0,
        LOGIN_FAILED,

        DATABASE_NOTFOUND = -1
    }

    #endregion

    static class DataBasedata
    {
        #region Properties
        public static List <AccountInfoData> accountinfo = new List<AccountInfoData>();
        #endregion

        #region Login

        public static Errors CheckLoginCredentials(string UsrName, string Passwd)
        {
            SQLiteConnection LoginConn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath  + "; Version = 3;");
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
                if (sqlite_datareader.Read())
                {

                    //Check data
                    myreader = sqlite_datareader.GetString(0);

                    LoginConn.Close();

                    if (myreader == Passwd)
                    {
                        return Errors.NO_ERROR;
                    }
                    else
                    {
                        return Errors.LOGIN_FAILED;
                    }
                }

                return Errors.LOGIN_FAILED;
            }
            catch (Exception ex)
            {
                return Errors.DATABASE_NOTFOUND;
            }
        }

        #endregion

        #region AccoutInfo database Methods
        public static void ReadAccountInfo()
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");
            string infotable;
            string AccName;

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();
            SQLiteCommand cmd2 = conn.CreateCommand();

            accountinfo.Clear();

            //Read Savings accounts information
            cmd.CommandText = "Select * from Account_Info where Type = 'Savings'";
            SQLiteDataReader datareader1 = cmd.ExecuteReader();
            while (datareader1.Read())
            {
                AccName = datareader1.GetString(2);
                infotable = datareader1.GetString(3);

                cmd2.CommandText = "Select * from " + infotable + " where Name = '" + AccName + "'";
                SQLiteDataReader datareader2 = cmd2.ExecuteReader();
                datareader2.Read();

                accountinfo.Add(new AccountInfoData
                {
                    ID = datareader1.GetInt32(0),
                    Type = datareader1.GetString(1),
                    Name = AccName,
                    InfoTable = infotable,
                    DataTable = datareader1.GetString(4),
                    SAInfo = new SAInfoData
                    {
                        ID = datareader2.GetInt32(0),
                        Name = datareader2.GetString(1),
                        AccNo = datareader2.GetString(2),
                        Bank = datareader2.GetString(3),
                        Balance = datareader2.GetDouble(4)
                    }
                });

                datareader2.Close();

            }
            datareader1.Close();

            cmd.CommandText = "Select * from Account_Info where Type = 'Loan'";
            SQLiteDataReader datareader3 = cmd.ExecuteReader();
            while (datareader3.Read())
            {
                AccName = datareader3.GetString(2);
                infotable = datareader3.GetString(3);

                cmd2.CommandText = "Select * from " + infotable + " where Name = '" + AccName + "'";
                SQLiteDataReader datareader4 = cmd2.ExecuteReader();
                datareader4.Read();

                accountinfo.Add(new AccountInfoData
                {
                    ID = datareader3.GetInt32(0),
                    Type = datareader3.GetString(1),
                    Name = AccName,
                    InfoTable = infotable,
                    DataTable = datareader3.GetString(4),
                    LNInfo = new LNInfoData
                    {
                        ID = datareader4.GetInt32(0),
                        Name = datareader4.GetString(1),
                        AccNo = datareader4.GetString(2),
                        Bank = datareader4.GetString(3),
                        Balance = datareader4.GetDouble(4),
                        LoanAmount = datareader4.GetDouble(5),
                        EMI = datareader4.GetDouble(6),
                        //StartDate = datareader3.GetDateTime(7),
                        Tenure = datareader4.GetInt32(8),
                        LnType = datareader4.GetString(9),
                        ROI = datareader4.GetDouble(10),
                        BEMI = datareader4.GetDouble(11)
                    }
                });

                datareader4.Close();
            }
            datareader3.Close();

           conn.Close();            
        }

        public static List<string> GetallAC()
        {
            List<string> All_Names = new List<string>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Select Name from Account_Info;";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                All_Names.Add(datareader.GetString(0));
            }

            conn.Close();

            return All_Names;

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
        public static void AddSavingsInfo(String Name, string ACCNo, string Bank)
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

        public static List<string> GetSavingsAC()
        {
            List <string> SA_Names = new List<string>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Select Name from SavingAccount_Info;";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            while(datareader.Read())
            {
                SA_Names.Add(datareader.GetString(0));
            }

            conn.Close();

            return SA_Names;
            
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

        public static void AddSavingsRecord(string TableName, SavingsAccData savingdata)
        {
            double balance;
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();

            //get the balance
            cmd.CommandText = @"Select Balance from SavingAccount_Info where Name = '" + TableName + "';";
            SQLiteDataReader datareader = cmd.ExecuteReader();
            datareader.Read();
            balance = datareader.GetDouble(0);
            datareader.Close();

            //Update Balance
            if (savingdata.TranType == TransType.Cr)
            {
                balance = balance + savingdata.Amount;
            }
            else
            {
                balance = balance - savingdata.Amount;
            }
            cmd.CommandText = @"Update SavingAccount_Info set Balance = " + balance.ToString() + " where Name = '" + TableName + "';";
            cmd.ExecuteNonQuery();

            //Add record
            cmd.CommandText = @"Insert into " + TableName + "(Date, Description, Amount, TranType, Category, Balance) values(" + "'" +
                                savingdata.date.ToShortDateString() + "', '" +
                                savingdata.Description + "', " +
                                savingdata.Amount.ToString() + ", " +
                                ((int)savingdata.TranType).ToString() + ", " +
                                ((int)savingdata.Category).ToString() + ", " +
                                balance.ToString() + ");";
            cmd.ExecuteNonQuery();

        }

        public static List<SavingsAccData> GetSavingsData(string TableName, int Category)
        {
            List<SavingsAccData> savingsdata = new List<SavingsAccData>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            if(Category == 0)
            {
                cmd.CommandText = @"Select * from " + TableName + ";";
            }
            else
            {
                cmd.CommandText = @"Select * from " + TableName + " where Category = " + (Category - 1).ToString() + ";";
            }

            

            SQLiteDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                savingsdata.Add(new SavingsAccData
                {
                    date = Convert.ToDateTime(datareader.GetString(1)),
                    Description = datareader.GetString(2),
                    Amount = datareader.GetDouble(3),
                    TranType = (TransType)datareader.GetInt32(4),
                    Category = (Category)datareader.GetInt32(5)
                });
            }

            conn.Close();

            return savingsdata;

        }
        #endregion

        #region Loan Account Methods
        public static void AddLoanInfo(string Name, string ACCNo, string Bank, string LnAmt, string EMI, DateTime startdate, string NoEMI, 
                                          string LnType, string ROI)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Insert into LoanAccount_Info (Name, AccountNo, Bank, Balance, LoanAmount, EMI, StartDate, NoEMI, LoanType, ROI, BEMI) Values (" + " '" +
                                Name + "', '" +
                                ACCNo + "', '" +
                                Bank + "', " +
                                LnAmt + ", " +
                                LnAmt + ", " +
                                EMI + ", '" +
                                startdate.ToShortDateString() + "', " +
                                NoEMI + ", '" +
                                LnType + "', " +
                                ROI + ", " +
                                NoEMI + ");";

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

        public static void AddLoanRecord(string TableName, string date, string EMI)
        {
            double ROI, Bal, BEMI;
            double interest;
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            //Read balance 
            cmd.CommandText = @"Select Balance, ROI, BEMI from LoanAccount_Info where Name = '" + TableName + "';";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            datareader.Read();

            Bal = datareader.GetDouble(0);
            ROI = datareader.GetDouble(1);
            BEMI = datareader.GetDouble(2);

            datareader.Close();

            //Update balance
            BEMI = BEMI - 1;
            interest = ROI * Bal / 12/100;
            Bal = Bal - (int)(Convert.ToDouble(EMI) - interest);

            cmd.CommandText = @"Update LoanAccount_Info set "  + 
                               "Balance = " + Bal.ToString() + "," +
                               "BEMI = " + BEMI.ToString() + " " +
                               "where Name = '" + TableName + "'; ";

            cmd.ExecuteNonQuery();

            cmd.CommandText = @"Insert into " + TableName + "(Date, EMI) Values (" + " '" +
                                date + "', " +
                                EMI +  ");";

            cmd.ExecuteNonQuery();
            
            conn.Close();
        }

        public static List<string> GetallLNAC()
        {
            List<string> All_Names = new List<string>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Select Name from LoanAccount_Info;";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                All_Names.Add(datareader.GetString(0));
            }

            conn.Close();

            return All_Names;

        }


        public static double GetTotalDebt()
        {
            double totalDebt = 0;

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            //Read balance 
            cmd.CommandText = @"Select sum(Balance) from LoanAccount_Info;";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            datareader.Read();

            totalDebt = datareader.GetDouble(0);

            return totalDebt;
        }

        public static double GetEMIinfo(string TableName)
        {
            double EMI;

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            //Read balance 
            cmd.CommandText = @"Select EMI from LoanAccount_Info where Name = '" + TableName + "';";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            datareader.Read();

            EMI = datareader.GetDouble(0);

            datareader.Close();

            return EMI;
        }
        #endregion

        #region dummy


        
        #endregion

        #region Properties

        #endregion

    }
}

#if false

#region Login Methods
        
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