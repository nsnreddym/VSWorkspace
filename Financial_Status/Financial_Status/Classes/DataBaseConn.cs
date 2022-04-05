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
    public struct BDGInfoData
    {
        public int ID;
        public string Name;
        public double EMI;
        public int paidstatus;
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
        public double Balance;
    }

    public enum Category
    {
        Misc = 0,
        Loan = 1,
        Salary = 2,
        Chit = 3,
        Food = 4,
        Maintanance = 5,
        Transfer = 6,
        Incentivies = 7,
        BF = 8,
        Groceries = 9,
        NONVeg = 10,
        Petrol = 11 ,
        Invest = 12,
        Medical = 13,
        Travel = 14,
        Education = 15
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
        
        #endregion

        #region Login

        public static Errors CheckLoginCredentials(string UsrName, string Passwd)
        {
            
            SQLiteDataReader sqlite_datareader;
            SQLiteCommand sqlite_cmd;
            string myreader = "";
            Errors ret;

            try
            {
                SQLiteConnection LoginConn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");
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

                    if (myreader == Passwd)
                    {
                        ret = Errors.NO_ERROR;
                    }
                    else
                    {
                        ret = Errors.LOGIN_FAILED;
                    }
                }
                else
                {
                    ret = Errors.LOGIN_FAILED;
                }

                sqlite_datareader.Close();

                LoginConn.Close();

                
            }
            catch (Exception ex)
            {
                ret = Errors.DATABASE_NOTFOUND;
            }

            return ret;
        }

        #endregion

        #region AccoutInfo database Methods
        public static List<AccountInfoData> ReadAccountInfo()
        {
            List<AccountInfoData> accountinfo = new List<AccountInfoData>();
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");
            string infotable;
            string AccName;

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();
            SQLiteCommand cmd2 = conn.CreateCommand();

            accountinfo.Clear();

            //Read Savings accounts information
            cmd.CommandText = "Select * from Info_All_Account where Type = 'Savings'";
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

            cmd.CommandText = "Select * from Info_All_Account where Type = 'FDCard'";
            SQLiteDataReader datareader5 = cmd.ExecuteReader();
            while (datareader5.Read())
            {
                AccName = datareader5.GetString(2);
                infotable = datareader5.GetString(3);

                cmd2.CommandText = "Select * from " + infotable + " where Name = '" + AccName + "'";
                SQLiteDataReader datareader6 = cmd2.ExecuteReader();
                datareader6.Read();

                accountinfo.Add(new AccountInfoData
                {
                    ID = datareader5.GetInt32(0),
                    Type = datareader5.GetString(1),
                    Name = AccName,
                    InfoTable = infotable,
                    DataTable = datareader5.GetString(4),
                    SAInfo = new SAInfoData
                    {
                        ID = datareader6.GetInt32(0),
                        Name = datareader6.GetString(1),
                        AccNo = datareader6.GetString(2),
                        Bank = datareader6.GetString(3),
                        Balance = datareader6.GetDouble(4)
                    }
                });

                datareader6.Close();

            }
            datareader5.Close();

            cmd.CommandText = "Select * from Info_All_Account where Type = 'Loan'";
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

            return accountinfo;
                      
        }

        public static List<string> GetallAC()
        {
            List<string> All_Names = new List<string>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Select Name from Info_All_Account;";

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
                    infotable = new string("Info_SavingAccount");
                    break;

                case "Loan":
                    infotable = new string("Info_LoanAccount");
                    break;

                case "FDCard":
                    infotable = new string("Info_FoodAccount");
                    break;

                default:
                    conn.Close();
                    return false;
            }

            cmd.CommandText = @"Insert into Info_All_Account (Type, Name, InfoTable, DataTable) Values (" + " '" +
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

            cmd.CommandText = @"Insert into Info_SavingAccount (Name, AccountNo, Bank) Values (" + " '" +
                                Name + "', '" +
                                ACCNo + "', '" +
                                Bank + "');";

            cmd.ExecuteNonQuery(); 
            
            conn.Close();
        }

        public static void AddFoodInfo(String Name, string ACCNo, string Bank)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Insert into Info_FoodAccount (Name, AccountNo, Bank) Values (" + " '" +
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

            cmd.CommandText = @"Select Name from Info_SavingAccount;";

            SQLiteDataReader datareader1 = cmd.ExecuteReader();

            while(datareader1.Read())
            {
                SA_Names.Add(datareader1.GetString(0));
            }
            datareader1.Close();

            cmd.CommandText = @"Select Name from Info_FoodAccount;";

            SQLiteDataReader datareader2 = cmd.ExecuteReader();

            while(datareader2.Read())
            {
                SA_Names.Add(datareader2.GetString(0));
            }
            datareader2.Close();

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

        public static double AddSavingsRecord(string TableName, SavingsAccData savingdata)
        {
            double balance;
            string infotable;
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();
            SQLiteCommand cmd = conn.CreateCommand();

            //get info_ac
            cmd.CommandText = @"Select InfoTable from Info_All_Account where Name = '" + TableName + "';";

            SQLiteDataReader datareader1 = cmd.ExecuteReader();
            datareader1.Read();
            infotable = datareader1.GetString(0);
            datareader1.Close();

            //get the balance
            cmd.CommandText = @"Select Balance from " +  infotable + " where Name = '" + TableName + "';";
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
            cmd.CommandText = @"Update " + infotable + " set Balance = " + balance.ToString() + " where Name = '" + TableName + "';";
            cmd.ExecuteNonQuery();

            //Add record
            cmd.CommandText = @"Insert into " + TableName + "(Date, Description, Amount, TranType, Category, Balance) values(" + "'" +
                                savingdata.date.ToString("yyyy-MM-dd") + "', '" +
                                savingdata.Description + "', " +
                                savingdata.Amount.ToString() + ", " +
                                ((int)savingdata.TranType).ToString() + ", " +
                                ((int)savingdata.Category).ToString() + ", " +
                                balance.ToString() + ");";
            cmd.ExecuteNonQuery();

            conn.Close();

            return balance;

        }

        public static List<SavingsAccData> GetSavingsData(string TableName, int Category, DateTime startdate, DateTime Enddate)
        {
            List<SavingsAccData> savingsdata = new List<SavingsAccData>();

            int syear, smonth, sdate;

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            syear = startdate.Year;

            if(Category == 0)
            {
                cmd.CommandText = @"Select * from " + TableName + " where (Date between '" +
                                             startdate.Year + "-" + startdate.Month.ToString("D2") + "-" + startdate.Day.ToString("D2") + "' and '" +
                                             Enddate.Year + "-" + Enddate.Month.ToString("D2") + "-" + Enddate.Day.ToString("D2") + "');";
            }
            else
            {
                //cmd.CommandText = @"Select * from " + TableName + " where Category = " + (Category - 1).ToString() + ";";
                cmd.CommandText = @"Select * from " + TableName + " where Category = " + (Category - 1).ToString() + " and (Date between '" + 
                                             startdate.Year + "-" + startdate.Month.ToString("D2") + "-" + startdate.Day.ToString("D2") + "' and '" + 
                                             Enddate.Year + "-" + Enddate.Month.ToString("D2") + "-" + Enddate.Day.ToString("D2") + "'); ";
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
                    Category = (Category)datareader.GetInt32(5),
                    Balance = datareader.GetDouble(6)
                });
            }

            conn.Close();

            return savingsdata;

        }

        public static List<SavingsAccData> GetSavingsData(string TableName, int Category, int month, int year)
        {
            int days = DateTime.DaysInMonth(year, month);

            List<SavingsAccData> savingsdata = new List<SavingsAccData>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            if(Category == 0)
            {
                cmd.CommandText = @"Select * from " + TableName + " where (Date between '" + year + "-" + month.ToString("D2") + "-01' and '" + year + "-" + month.ToString("D2") + "-" + days.ToString("D2") + "');";
            }
            else
            {
                cmd.CommandText = @"Select * from " + TableName + " where Category = " + (Category - 1).ToString() + " and (Date between '" + year + "-" + month.ToString("D2") + "-01' and '" + year + "-" + month.ToString("D2") + "-" + days.ToString("D2") +"'); ";
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
                    Category = (Category)datareader.GetInt32(5),
                    Balance = datareader.GetDouble(6)
                });
            }

            conn.Close();

            return savingsdata;

        }

        public static double Getbalance(string TableName, int Category, int TranType, int month, int year)
        {
            double balance;
            int days = DateTime.DaysInMonth(year, month);
            string cmdstr1;

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmdstr1 = @"Select sum(Amount) from " + TableName + 
                       " where (TranType = " + TranType.ToString() + " and " +
                                "Category = " + Category.ToString() + " and " +
                                "(Date between '" + year + "-" + month.ToString("D2") + "-01' and '" +
                                                    year + "-" + month.ToString("D2") + "-" + days.ToString("D2") + "'));";

            cmd.CommandText = cmdstr1;

            SQLiteDataReader datareader = cmd.ExecuteReader();

            balance = 0;

            datareader.Read();

            try
            {
                balance = datareader.GetDouble(0);
            }
            catch (Exception ex)
            {
                balance = 0;
            }
            

            conn.Close();

            return balance;
        }
        public static double GetTotalSavings()
        {
            double totalDebt = 0;

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            //Read balance 
            cmd.CommandText = @"Select sum(Balance) from Info_SavingAccount;";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            datareader.Read();

            totalDebt = datareader.GetDouble(0);

            conn.Close();

            return totalDebt;
        }
        #endregion

        #region Loan Account Methods
        public static void AddLoanInfo(string Name, string ACCNo, string Bank, string LnAmt, string EMI, DateTime startdate, string NoEMI, 
                                          string LnType, string ROI)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd.CommandText = @"Insert into Info_LoanAccount (Name, AccountNo, Bank, Balance, LoanAmount, EMI, StartDate, NoEMI, LoanType, ROI, BEMI) Values (" + " '" +
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

        public static void AddLoanRecord(string TableName, string date, string EMI, TransType transType)
        {
            double ROI, Bal, BEMI;
            double interest;
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            //Read balance 
            cmd.CommandText = @"Select Balance, ROI, BEMI from Info_LoanAccount where Name = '" + TableName + "';";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            datareader.Read();

            Bal = datareader.GetDouble(0);
            ROI = datareader.GetDouble(1);
            BEMI = datareader.GetDouble(2);

            datareader.Close();

            if(transType == TransType.Cr)
            {
                //Update balance
                BEMI = BEMI + 1;
                Bal = Bal + (int)(Convert.ToDouble(EMI));

                cmd.CommandText = @"Update Info_LoanAccount set " +
                                   "Balance = " + Bal.ToString() + "," +
                                   "BEMI = " + BEMI.ToString() + " " +
                                   "where Name = '" + TableName + "'; ";

            }
            else
            {
                //Update balance
                BEMI = BEMI - 1;
                interest = ROI * Bal / 12 / 100;
                Bal = Bal - (int)(Convert.ToDouble(EMI) - interest);

                cmd.CommandText = @"Update Info_LoanAccount set " +
                                   "Balance = " + Bal.ToString() + "," +
                                   "BEMI = " + BEMI.ToString() + " " +
                                   "where Name = '" + TableName + "'; ";
            }
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"Insert into " + TableName + "(Date, EMI) Values (" + " '" +
                                date + "', " +
                                EMI +  ");";

            cmd.ExecuteNonQuery();
            
            conn.Close();
        }

        public static List<string> GetallLNAC(bool condition)
        {
            List<string> All_Names = new List<string>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            if (condition)
            {
                cmd.CommandText = @"Select Name from Info_LoanAccount where Balance > 0;";
            }
            else
            {
                cmd.CommandText = @"Select Name from Info_LoanAccount;";
            }
            

            SQLiteDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                All_Names.Add(datareader.GetString(0));
            }

            conn.Close();

            return All_Names;

        }

        public static List<string> GetallLNAC(string LnType, bool condition)
        {
            List<string> All_Names = new List<string>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            if (condition)
            {
                cmd.CommandText = @"Select Name from Info_LoanAccount where Balance > 0 and LoanType = '" + LnType + "'; ";
            }
            else
            {
                cmd.CommandText = @"Select Name from Info_LoanAccount where LoanType = '" + LnType + "';";
            }


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
            cmd.CommandText = @"Select sum(Balance) from Info_LoanAccount;";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            datareader.Read();

            totalDebt = datareader.GetDouble(0);

            conn.Close();

            return totalDebt;
        }

        public static double GetEMIinfo(string TableName)
        {
            double EMI;

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            //Read balance 
            cmd.CommandText = @"Select EMI from Info_LoanAccount where Name = '" + TableName + "';";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            datareader.Read();

            EMI = datareader.GetDouble(0);

            datareader.Close();

            return EMI;
        }
        #endregion

        #region MonthlyBudget
        public static List<BDGInfoData> ReadBudget()
        {
            List <BDGInfoData> bDGInfoData = new List<BDGInfoData>();

            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd = conn.CreateCommand();

            cmd.CommandText = @"Select * from ME_MonthlyExpenses where PaidStatus = 0;";

            SQLiteDataReader datareader = cmd.ExecuteReader();

            while (datareader.Read())
            {
                bDGInfoData.Add(new BDGInfoData
                {
                    ID = datareader.GetInt32(0),
                    Name = datareader.GetString(1),
                    EMI = datareader.GetDouble(2)
                });
            }

            conn.Close();

            return bDGInfoData;
        }

        public static void UpdateBudget(string name)
        {
            SQLiteConnection conn = new SQLiteConnection("Data Source = " + GlobalVar.DataBasePath + "; Version = 3;");

            conn.Open();

            SQLiteCommand cmd = conn.CreateCommand();

            cmd = conn.CreateCommand();

            cmd.CommandText = "Update ME_MonthlyExpenses SET PaidStatus = 1 where Name = '" + name + "';";

            cmd.ExecuteNonQuery();

            conn.Close();
        }
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