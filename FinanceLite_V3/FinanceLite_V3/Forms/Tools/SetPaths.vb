Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc

Public Class SetPaths
    Dim Dbase_Conn As New OleDb.OleDbConnection
    Dim dbProvider As String

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles Cancel_Button.Click
        Me.Close()
    End Sub

    Private Sub SetPaths_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim sql As String
        Dim ds_path1 As New DataSet
        Dim da_path1 As OleDb.OleDbDataAdapter
        Dim ds_path2 As New DataSet
        Dim da_path2 As OleDb.OleDbDataAdapter
        Dim ds_path3 As New DataSet
        Dim da_path3 As OleDb.OleDbDataAdapter

        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
                     "Jet OLEDB:Database Password=Bindu@10apr; " +
                     "Data Source =  .\LoginInfo.mdb"

        Dbase_Conn.ConnectionString = dbProvider

        Try
            Dbase_Conn.Open()

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

            TxtCustDbasePath.Text = CustPath
            TxtLoanDbasePath.Text = LoanPath
            TxtPostDbasePath.Text = PostPath

            UpdateButton.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_PATHS)

            Dbase_Conn.Close()

        Catch ex As Exception

            MessageBox.Show(ex.Message + vbCrLf + "System Error: Contact Software Provider")

            Me.Close()
            MainForm.Close()

        End Try


    End Sub

    Private Sub UpdateButton_Click(sender As Object, e As EventArgs) Handles UpdateButton.Click
        Dim sql As String
        Dim sqlcommand As New OleDb.OleDbCommand

        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
                     "Jet OLEDB:Database Password=Bindu@10apr; " +
                     "Data Source =  .\LoginInfo.mdb"

        Dbase_Conn.ConnectionString = dbProvider


        Try

            Dbase_Conn.Open()

            sql = "Update AppPaths SET Path = '" + TxtCustDbasePath.Text +
                 "' WHERE Property = 'CustDbase'"

            With sqlcommand
                .CommandText = sql
                .Connection = Dbase_Conn
                .ExecuteNonQuery()
            End With

            sql = "Update AppPaths SET Path = '" + TxtLoanDbasePath.Text +
                 "' WHERE Property = 'LoanDbase'"

            With sqlcommand
                .CommandText = sql
                .Connection = Dbase_Conn
                .ExecuteNonQuery()
            End With

            sql = "Update AppPaths SET Path = '" + TxtPostDbasePath.Text +
                 "' WHERE Property = 'PostDbase'"

            With sqlcommand
                .CommandText = sql
                .Connection = Dbase_Conn
                .ExecuteNonQuery()
            End With

        Catch ex As Exception

            MessageBox.Show(ex.Message + vbCrLf + "System Error: Contact Software Provider")

            Me.Close()

        End Try

        Year_sel = 2015

        Dbase_Conn.Close()

        Me.Close()

    End Sub

    Private Sub DbasePathButton_Click(sender As Object, e As EventArgs) Handles CustDbasePathButton.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim res As Integer

        fd.Title = "Open Datbase File"
        fd.Filter = "mdb files (*.mdb)|*.mdb"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        res = fd.ShowDialog()

        If res = DialogResult.OK Then
            CustPath = fd.FileName
            TxtCustDbasePath.Text = CustPath
        End If

    End Sub

    Private Sub LoanDbasePathButton_Click(sender As Object, e As EventArgs) Handles LoanDbasePathButton.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim res As Integer

        fd.Title = "Open Datbase File"
        fd.Filter = "mdb files (*.mdb)|*.mdb"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        res = fd.ShowDialog()

        If res = DialogResult.OK Then
            LoanPath = fd.FileName
            TxtLoanDbasePath.Text = LoanPath
        End If

    End Sub

    Private Sub PostDbasePathButton_Click(sender As Object, e As EventArgs) Handles PostDbasePathButton.Click
        Dim fd As OpenFileDialog = New OpenFileDialog()
        Dim res As Integer

        fd.Title = "Open Datbase File"
        fd.Filter = "mdb files (*.mdb)|*.mdb"
        fd.FilterIndex = 1
        fd.RestoreDirectory = True

        res = fd.ShowDialog()

        If res = DialogResult.OK Then
            PostPath = fd.FileName
            TxtPostDbasePath.Text = PostPath
        End If

    End Sub

    Private Sub SetPaths_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        Menu_selected = MENU_ENUM.NO_OPTION
        MainForm.HideOrShow_options(True)

    End Sub
End Class