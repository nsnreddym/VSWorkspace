Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc

Module Security
    Dim Dbase_Conn As New OleDb.OleDbConnection
    Dim dbProvider As String

    Public Class User

        Public Name As String
        Public Pswd As String
        Public ID As Integer
        Public Perm_Read(50) As Integer
        Public Perm_Write(50) As Integer
        Public Perm_Exec(50) As Integer

        Public Sub User()
            ID = 0000
        End Sub

        Public Sub CheckPermissions()

            MainForm.ItemToolsEditPath.Enabled = Perm_Read(ACTIVITY_ID.ACT_PATHS)

            MainForm.ItemUsersPerms.Enabled = Perm_Read(ACTIVITY_ID.ACT_USER)
            MainForm.ItemUsersAdd.Enabled = Perm_Write(ACTIVITY_ID.ACT_USER)

            MainForm.ItemCustNew.Enabled = Perm_Write(ACTIVITY_ID.ACT_CUST)
            MainForm.ItemCustOpen.Enabled = Perm_Read(ACTIVITY_ID.ACT_CUST)

            MainForm.ItemLoanNew.Enabled = Perm_Write(ACTIVITY_ID.ACT_LOAN)
            MainForm.ItemLoanSearch.Enabled = Perm_Read(ACTIVITY_ID.ACT_LOAN)

            MainForm.ItemPostDaily.Enabled = Perm_Write(ACTIVITY_ID.ACT_DAILYPOSTING)
            MainForm.ItemPostBulk.Enabled = Perm_Write(ACTIVITY_ID.ACT_BULKPOSTING)
            MainForm.ItemPostExpadd.Enabled = Perm_Write(ACTIVITY_ID.ACT_EXPENSES)

            MainForm.ItemRepDaily.Enabled = Perm_Read(ACTIVITY_ID.ACT_DAILYPOSTING)
            MainForm.ItemBalanceSheet.Enabled = Perm_Read(ACTIVITY_ID.ACT_BALANCESHEET)
            MainForm.ItemYearly.Enabled = Perm_Read(ACTIVITY_ID.ACT_YEARREPORT)
            MainForm.ItemGeneral.Enabled = Perm_Read(ACTIVITY_ID.ACT_GENERALREPORT)

            MainForm.ItemPartNew.Enabled = Perm_Write(ACTIVITY_ID.ACT_PARTNER)
            MainForm.ItemPartView.Enabled = Perm_Read(ACTIVITY_ID.ACT_PARTNER)
            MainForm.ItemPartCredit.Enabled = Perm_Write(ACTIVITY_ID.ACT_TRANSACTION)
            MainForm.ItemPartDebit.Enabled = Perm_Write(ACTIVITY_ID.ACT_TRANSACTION)



        End Sub



    End Class


End Module
