Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc

Public Class LoginForm1
    Dim Dbase_Conn As New OleDb.OleDbConnection
    Dim dbProvider As String


    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click

        Dim sql As String
        Dim ds_user As New DataSet
        Dim da_user As OleDb.OleDbDataAdapter

        If UsernameTextBox.TextLength <> 0 Then

            If PasswordTextBox.TextLength <> 0 Then

                sql = "SELECT * FROM UserDetails WHERE LoginName = '" &
                      UsernameTextBox.Text & "' AND Pswd = '" &
                      PasswordTextBox.Text & "'"
                Try
                    '------------------Update user information------------------ 
                    da_user = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
                    da_user.Fill(ds_user, "User_data")

                    CurrentUser.Name = ds_user.Tables("User_data").Rows(0).Item(2)
                    CurrentUser.Pswd = ds_user.Tables("User_data").Rows(0).Item(1)
                    CurrentUser.ID = ds_user.Tables("User_data").Rows(0).Item(4)

                    MainForm.Text = AppTitle + "-" + CurrentUser.Name


                    '------------------Update user information------------------ 

                    '------------------Read user Permissions------------------ 
                    ReadUserPermissions(ACTIVITY_ID.ACT_PATHS)
                    ReadUserPermissions(ACTIVITY_ID.ACT_USER)

                    ReadUserPermissions(ACTIVITY_ID.ACT_CUST)
                    ReadUserPermissions(ACTIVITY_ID.ACT_LOAN)
                    ReadUserPermissions(ACTIVITY_ID.ACT_DAILYPOSTING)
                    ReadUserPermissions(ACTIVITY_ID.ACT_BULKPOSTING)
                    ReadUserPermissions(ACTIVITY_ID.ACT_EXPENSES)

                    ReadUserPermissions(ACTIVITY_ID.ACT_BALANCESHEET)
                    ReadUserPermissions(ACTIVITY_ID.ACT_GENERALREPORT)
                    ReadUserPermissions(ACTIVITY_ID.ACT_YEARREPORT)

                    ReadUserPermissions(ACTIVITY_ID.ACT_PARTNER)
                    ReadUserPermissions(ACTIVITY_ID.ACT_TRANSACTION)


                    '------------------Read user Permissions------------------ 
                    CurrentUser.CheckPermissions()

                    '-----------------Read Database Paths---------------------
                    ReadDatabasePaths()

                    Year_sel = 2015

                    Dbase_Conn.Close()
                    Me.Close()

                Catch ex As Exception

                    MessageBox.Show(ex.Message + "Unable to Login" + vbCrLf +
                                    "Contact Administrator")

                End Try

            End If

        End If

    End Sub

    Private Sub Cancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel.Click
        Dbase_Conn.Close()
        Me.Close()
    End Sub

    Private Sub LoginForm1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
                     "Jet OLEDB:Database Password=Bindu@10apr; " +
                     "Data Source =  .\LoginInfo.mdb"

        Dbase_Conn.ConnectionString = dbProvider

        Try
            Dbase_Conn.Open()

        Catch ex As Exception

            MessageBox.Show(ex.Message + vbCrLf + "System Error: Contact Software Provider")

            Me.Close()
            MainForm.Close()

        End Try

    End Sub

    Private Sub ReadUserPermissions(ActivityNo As Integer)

        Dim sql As String
        Dim ds_user As New DataSet
        Dim da_user As OleDb.OleDbDataAdapter

        sql = "Select * From Permissions Where UID = " + CurrentUser.ID.ToString +
         " AND ActivityID = " + (ActivityNo + 1001).ToString

        Try

            da_user = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
            da_user.Fill(ds_user, "Permis_data")

            CurrentUser.Perm_Read(ActivityNo) = ds_user.Tables("Permis_data").Rows(0).Item(3)
            CurrentUser.Perm_Write(ActivityNo) = ds_user.Tables("Permis_data").Rows(0).Item(4)
            CurrentUser.Perm_Exec(ActivityNo) = ds_user.Tables("Permis_data").Rows(0).Item(5)

        Catch ex As Exception

            MessageBox.Show(ex.Message + vbCrLf + "System Error: Contact Software Provider")

        End Try


    End Sub

    Private Sub LoginForm1_Closed(sender As Object, e As EventArgs) Handles Me.Closed
        Menu_selected = MENU_ENUM.NO_OPTION
        MainForm.HideOrShow_options(True)

    End Sub

    Private Sub ReadDatabasePaths()
        Dim sql As String
        Dim ds_path1 As New DataSet
        Dim da_path1 As OleDb.OleDbDataAdapter
        Dim ds_path2 As New DataSet
        Dim da_path2 As OleDb.OleDbDataAdapter
        Dim ds_path3 As New DataSet
        Dim da_path3 As OleDb.OleDbDataAdapter

        Try

            sql = "Select Path from AppPaths WHERE Property = 'CustDbase'"
            da_path1 = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
            da_path1.Fill(ds_path1, "Cust_Path")
            CustPath = ds_path1.Tables("Cust_Path").Rows(0).Item(0)

            sql = "Select Path from AppPaths WHERE Property = 'LoanDbase'"
            da_path2 = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
            da_path2.Fill(ds_path2, "Loan_Path")
            LoanPath = ds_path2.Tables("Loan_Path").Rows(0).Item(0)

            sql = "Select Path from AppPaths WHERE Property = 'PostDbase'"
            da_path3 = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
            da_path3.Fill(ds_path3, "Post_Path")
            PostPath = ds_path3.Tables("Post_Path").Rows(0).Item(0)

        Catch ex As Exception

            MessageBox.Show("Update Database Paths...")

        End Try

    End Sub
End Class
