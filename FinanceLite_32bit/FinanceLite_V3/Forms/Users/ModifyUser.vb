Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc
Imports System.ComponentModel

Public Class ModifyUser
    Dim Dbase_Conn As New OleDb.OleDbConnection
    Dim dbProvider As String

    Private Sub ModifyUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
                     "Jet OLEDB:Database Password=Bindu@10apr; " +
                     "Data Source =  .\LoginInfo.mdb"

        Dbase_Conn.ConnectionString = dbProvider

        Me.WindowState = FormWindowState.Maximized

        Try
            Dbase_Conn.Open()

            Select Case Menu_selected

                Case MENU_ENUM.ADD_USER_OPTION

                    Me.Text = "AddUser"

                    AddUser_New()

                Case MENU_ENUM.EDIT_USER_OPTION

                    Me.Text = "EditUser"

                    TxtLoginID.Enabled = False
                    TxtPasswd.Enabled = False
                    GetUserID()
                    DisplayUser_Data()

            End Select


        Catch ex As Exception

            MessageBox.Show(ex.Message + vbCrLf + "System Error: Contact Software Provider")

            Me.Close()

        End Try

    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click

        UserTabControl.SelectedTab = PermTab

    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click

        Me.Close()

    End Sub

    Private Sub ModifyUser_Closed(sender As Object, e As EventArgs) Handles Me.Closed

        MainForm.ItemUserSave.Enabled = False
        Menu_selected = MENU_ENUM.NO_OPTION

        Dbase_Conn.Close()
        MainForm.HideOrShow_options(True)


    End Sub

    Private Sub AddUser_New()
        Dim sql As String
        Dim ds_user As New DataSet
        Dim da_user As OleDb.OleDbDataAdapter
        Dim count As Integer
        Dim i As Integer

        TxtID.Visible = True
        IDSel.Visible = False

        '----------------Allot User ID ----------------------
        sql = "SELECT Max(UID) FROM UserDetails"
        da_user = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
        da_user.Fill(ds_user, "UID_data")

        TxtID.Text = ds_user.Tables("UID_data").Rows(0).Item(0) + 1

        '---------------Get Permission data------------------
        sql = "Select ActivityID,Activity from Permissions Where UID = 1001"

        da_user = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
        da_user.Fill(ds_user, "Perm_data")

        count = ds_user.Tables("Perm_data").Rows.Count

        Perm_table.Rows.Clear()

        For i = 0 To count - 1

            Perm_table.Rows.Add()
            Perm_table.Rows(i).Cells(0).Value = ds_user.Tables("Perm_data").Rows(i).Item(0)
            Perm_table.Rows(i).Cells(1).Value = ds_user.Tables("Perm_data").Rows(i).Item(1)
            Perm_table.Rows(i).Cells(2).Value = 1
            Perm_table.Rows(i).Cells(3).Value = 0
            Perm_table.Rows(i).Cells(4).Value = 0

        Next

    End Sub

    Private Sub GetUserID()

        Dim sql As String
        Dim ds_user As New DataSet
        Dim da_user As OleDb.OleDbDataAdapter
        Dim count As Integer
        Dim i As Integer

        TxtID.Visible = False
        IDSel.Visible = True

        sql = "Select UID, LoginName From UserDetails"

        da_user = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
        da_user.Fill(ds_user, "User_data")

        count = ds_user.Tables("User_data").Rows.Count

        IDSel.Items.Clear()

        For i = 0 To count - 1

            IDSel.Items.Add(ds_user.Tables("User_data").Rows(i).Item(0))

        Next

        IDSel.SelectedIndex = 0

    End Sub

    Private Sub DisplayUser_Data()

        Dim sql As String
        Dim ds_user As New DataSet
        Dim da_user As OleDb.OleDbDataAdapter
        Dim count As Integer
        Dim i As Integer

        sql = "Select * From UserDetails Where UID = " + IDSel.SelectedItem.ToString

        da_user = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
        da_user.Fill(ds_user, "User_details")

        TxtFullName.Text = ds_user.Tables("User_Details").Rows(0).Item(0)
        TxtLoginID.Text = ds_user.Tables("User_Details").Rows(0).Item(2)
        TxtPhNo.Text = ds_user.Tables("User_Details").Rows(0).Item(3)

        sql = "Select * From Permissions Where UID = " + IDSel.SelectedItem.ToString

        da_user = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
        da_user.Fill(ds_user, "Perm_details")

        count = ds_user.Tables("Perm_details").Rows.Count

        Perm_table.Rows.Clear()

        For i = 0 To count - 1

            Perm_table.Rows.Add()
            Perm_table.Rows(i).Cells(0).Value = ds_user.Tables("Perm_details").Rows(i).Item(2)
            Perm_table.Rows(i).Cells(1).Value = ds_user.Tables("Perm_details").Rows(i).Item(1)
            Perm_table.Rows(i).Cells(2).Value = ds_user.Tables("Perm_details").Rows(i).Item(3)
            Perm_table.Rows(i).Cells(3).Value = ds_user.Tables("Perm_details").Rows(i).Item(4)
            Perm_table.Rows(i).Cells(4).Value = ds_user.Tables("Perm_details").Rows(i).Item(5)
        Next

    End Sub

    Private Sub IDSel_TextChanged(sender As Object, e As EventArgs) Handles IDSel.TextChanged
        DisplayUser_Data()
    End Sub

    Public Sub SaveUser_Data()
        Dim sql As String
        Dim sqlcommand As New OleDb.OleDbCommand
        Dim ds_user As New DataSet
        Dim da_user As OleDb.OleDbDataAdapter
        Dim count As Integer
        Dim i As Integer

        Select Case Menu_selected

            Case MENU_ENUM.ADD_USER_OPTION

                '------------------Check Login name availability-----------
                sql = "SELECT * FROM UserDetails WHERE LoginName = '" _
                      + TxtLoginID.Text + "'"
                da_user = New OleDb.OleDbDataAdapter(sql, Dbase_Conn)
                da_user.Fill(ds_user, "UID_data")

                count = ds_user.Tables("UID_data").Rows.Count

                If count = 0 Then

                    sql = "Insert into UserDetails (FullName,Pswd,LoginName,Phone,UID) VALUES ( '" _
                      + TxtFullName.Text + "','" _
                      + TxtPasswd.Text + "','" _
                      + TxtLoginID.Text + "'," _
                      + TxtPhNo.Text + "," _
                      + TxtID.Text + ")"

                    With sqlcommand
                        .CommandText = sql
                        .Connection = Dbase_Conn
                        .ExecuteNonQuery()
                    End With

                    count = Perm_table.RowCount

                    For i = 0 To count - 1

                        sql = "Insert into Permissions (UID,Activity,ActivityID,Rd,Wr,Ex) VALUES ( " _
                          + TxtID.Text + ",'" _
                          + Perm_table.Rows(i).Cells(1).Value.ToString + "'," _
                          + Perm_table.Rows(i).Cells(0).Value.ToString + "," _
                          + Perm_table.Rows(i).Cells(2).Value.ToString + "," _
                          + Perm_table.Rows(i).Cells(3).Value.ToString + "," _
                          + Perm_table.Rows(i).Cells(4).Value.ToString + ")"

                        With sqlcommand
                            .CommandText = sql
                            .Connection = Dbase_Conn
                            .ExecuteNonQuery()
                        End With

                    Next

                    MessageBox.Show("User Created...")

                    Me.Close()

                Else
                    MessageBox.Show("Login Name Exists..")
                End If

            Case MENU_ENUM.EDIT_USER_OPTION

                sql = "UPDATE UserDetails SET FullName = '" + TxtFullName.Text +
                                              "', Phone = " + TxtPhNo.Text +
                                              " WHERE UID = " + IDSel.SelectedItem.ToString
                With sqlcommand
                    .CommandText = sql
                    .Connection = Dbase_Conn
                    .ExecuteNonQuery()
                End With
                count = Perm_table.RowCount

                For i = 0 To count - 1

                    sql = "Update Permissions SET " +
                          "Rd = " + Perm_table.Rows(i).Cells(2).Value.ToString +
                          ",Wr = " + Perm_table.Rows(i).Cells(3).Value.ToString +
                          ",Ex = " + Perm_table.Rows(i).Cells(4).Value.ToString +
                          " WHERE UID = " + IDSel.SelectedItem.ToString +
                          "AND ActivityID = " + Perm_table.Rows(i).Cells(0).Value.ToString

                    With sqlcommand
                        .CommandText = sql
                        .Connection = Dbase_Conn
                        .ExecuteNonQuery()
                    End With

                Next

                MessageBox.Show("Permissions Updated..")

                Me.Close()

        End Select

    End Sub

End Class