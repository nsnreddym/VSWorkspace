Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc
Imports System.ComponentModel

Public Class ModifyCustomer
    Dim dbProvider As String
    Dim CustDbase_Conn As New OleDb.OleDbConnection
    Dim LoanDbase_Conn As New OleDb.OleDbConnection
    Dim dbSource As String
    Dim dbSource2 As String
    Dim Date_selected As String

    Dim CustIDs(1000) As Integer
    Dim CustIDselected As Integer


    Private Sub ModifyCustomer_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Menu_selected = MENU_ENUM.NO_OPTION
        MainForm.HideOrShow_options(True)
        CustDbase_Conn.Close()
        LoanDbase_Conn.Close()

    End Sub

    Private Sub ModifyCustomer_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
                      "Jet OLEDB:Database Password=Bindu@10apr; " +
                      "Data Source =  "

        dbSource = CustPath
        dbSource2 = LoanPath
        CustDbase_Conn.ConnectionString = dbProvider & dbSource
        CustDbase_Conn.Open()
        LoanDbase_Conn.ConnectionString = dbProvider & dbSource2
        LoanDbase_Conn.Open()

        Bar1.Location = New Point(0, Bar1.Location.Y)
        Bar1.Size = New Size(Me.Size.Width, Bar1.Size.Height)
        Me.WindowState = FormWindowState.Maximized


        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim sql As String
        Dim CustIDAlloted As Integer

        Date_selected = DateTimePicker1.Value.ToString("MM/dd/yyyy")

        Select Case Menu_selected

            Case MENU_ENUM.CUST_NEW_OPTION

                AddCustTabItem.Visible = True
                EditCustTabItem.Visible = False

                sql = "SELECT Max(CustID) FROM Cust_Dbase"

                da = New OleDb.OleDbDataAdapter(sql, CustDbase_Conn)

                da.Fill(ds, "Mydataset")

                CustIDAlloted = ds.Tables("Mydataset").Rows(0).Item(0)

                CustID.Text = CustIDAlloted + 1


            Case MENU_ENUM.CUST_VIEW_OPTION

                AddCustTabItem.Visible = False
                EditCustTabItem.Visible = True

                CustDate.Enabled = False
                CustID_View.Enabled = False

                CustUpdate.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_CUST)

        End Select

    End Sub

    Private Sub ModifyCustomer_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged

        Bar1.Size = New Size(Me.Size.Width, Bar1.Size.Height)

    End Sub

    Private Sub Cancel_edit_Click(sender As Object, e As EventArgs) Handles Cancel_edit.Click
        Me.Close()
    End Sub

    '----------------------Add Customer--------------------------------------

    Private Sub CustAddCancelButton_Click(sender As Object, e As EventArgs) Handles CustAddCancelButton.Click
        Me.Close()
    End Sub

    Private Sub CustAddButton_Click(sender As Object, e As EventArgs) Handles CustAddButton.Click
        Dim sqlcommand As New OleDb.OleDbCommand
        Dim sqlquery As String = "INSERT INTO Cust_Dbase( CustID, CustName, CustAddress, CustMobile, DOJ  ) VALUES ( " _
                                   & CustID.Text & ",'" _
                                   & CustName.Text & "','" _
                                   & CustAddress.Text & "'," _
                                   & CustPhone.Text & ",#" _
                                   & Date_selected & "#);"

        Try
            With SqlCommand
                .CommandText = sqlquery
                .Connection = CustDbase_Conn
                .ExecuteNonQuery()
            End With

            MessageBox.Show("New Customer added")
        Catch ex As Exception

            MessageBox.Show(ex.Message + vbCrLf + "Unable create New Customer")

        End Try

        Me.Close()

    End Sub

    Private Sub CustMoreButton_Click(sender As Object, e As EventArgs) Handles CustMoreButton.Click

        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim CustIDAlloted As Integer
        Dim sqlcommand As New OleDb.OleDbCommand
        Dim sqlquery As String = "INSERT INTO Cust_Dbase( CustID, CustName, CustAddress, CustMobile, DOJ  ) VALUES ( " _
                                   & CustID.Text & ",'" _
                                   & CustName.Text & "','" _
                                   & CustAddress.Text & "'," _
                                   & CustPhone.Text & ",#" _
                                   & Date_selected & "#);"

        Try
            With sqlcommand
                .CommandText = sqlquery
                .Connection = CustDbase_Conn
                .ExecuteNonQuery()
            End With

            MessageBox.Show("New Customer added")

            sqlquery = "SELECT Max(CustID) FROM Cust_Dbase"

            da = New OleDb.OleDbDataAdapter(sqlquery, CustDbase_Conn)

            da.Fill(ds, "Mydataset")

            CustIDAlloted = ds.Tables("Mydataset").Rows(0).Item(0)

            CustID.Text = CustIDAlloted + 1
            CustName.Text = ""

        Catch ex As Exception

            MessageBox.Show(ex.Message + vbCrLf + "Unable create New Customer")

        End Try

    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles DateTimePicker1.ValueChanged
        Date_selected = DateTimePicker1.Value.ToString("M/d/yyyy")
    End Sub

    '----------------------Add Customer--------------------------------------

    '-----------------------Edit Customer-------------------------------------
    Private Sub Search_Edit_Click(sender As Object, e As EventArgs) Handles Search_Edit.Click

        Dim Sql As String
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim ds2 As New DataSet
        Dim da2 As OleDb.OleDbDataAdapter

        If CustID_Search.TextLength <> 0 Then
            Sql = "SELECT * FROM Cust_Dbase Where CustID = " + CustID_Search.Text
        Else
            If CustName_Search.TextLength <> 0 Then
                Sql = "SELECT * FROM Cust_Dbase Where CustID = " + CustIDselected.ToString

            Else
                If LoanID_Search.TextLength <> 0 Then

                    Sql = "SELECT CustID FROM Loan_Details Where LnID = " + LoanID_Search.Text
                    da2 = New OleDb.OleDbDataAdapter(Sql, LoanDbase_Conn)
                    da2.Fill(ds2, "MyLoandata")

                    Try

                        Sql = "SELECT * FROM Cust_Dbase Where CustID = " +
                              ds2.Tables("MyLoandata").Rows(0).Item(0).ToString

                    Catch ex As Exception

                        MessageBox.Show(ex.Message)

                    End Try


                End If


            End If
        End If


        da = New OleDb.OleDbDataAdapter(Sql, CustDbase_Conn)

        da.Fill(ds, "Mydataset")

        Try

            CustID_View.Text = ds.Tables("Mydataset").Rows(0).Item(0)
            CustName_Edit.Text = ds.Tables("Mydataset").Rows(0).Item(1)
            CustAddress_Edit.Text = ds.Tables("Mydataset").Rows(0).Item(2)
            CustPhone_Edit.Text = ds.Tables("Mydataset").Rows(0).Item(3)
            CustDate.Text = ds.Tables("Mydataset").Rows(0).Item(4)


        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub CustID_Search_TextChanged(sender As Object, e As EventArgs) Handles CustID_Search.TextChanged

        If CustID_Search.TextLength <> 0 Then

            CustName_Search.Enabled = False
            LoanID_Search.Enabled = False

        Else
            CustName_Search.Enabled = True
            LoanID_Search.Enabled = True

        End If

    End Sub

    Private Sub CustName_Search_TextChanged(sender As Object, e As EventArgs) Handles CustName_Search.TextChanged

        If CustName_Search.TextLength <> 0 Then

            Dim ds As New DataSet
            Dim da As OleDb.OleDbDataAdapter
            Dim sql As String
            Dim MaxCust As Integer

            CustID_Search.Enabled = False
            LoanID_Search.Enabled = False

            NameList.Items.Clear()
            NameList.Visible = False

            sql = "SELECT CustID,CustName FROM Cust_Dbase WHERE CustName LIKE '%" _
                  + CustName_Search.Text + "%'"

            da = New OleDb.OleDbDataAdapter(sql, CustDbase_Conn)

            da.Fill(ds, "CustNameSet")

            MaxCust = ds.Tables("CustNameSet").Rows.Count

            For i = 0 To MaxCust - 1

                NameList.Items.Add(ds.Tables("CustNameSet").Rows(i).Item(1))

                CustIDs(i) = ds.Tables("CustNameSet").Rows(i).Item(0)

            Next
            NameList.Visible = True


        Else
            NameList.Items.Clear()
            NameList.Visible = False

            CustID_Search.Enabled = True
            LoanID_Search.Enabled = True

        End If

    End Sub

    Private Sub LoanID_Search_TextChanged(sender As Object, e As EventArgs) Handles LoanID_Search.TextChanged

        If LoanID_Search.TextLength <> 0 Then

            CustID_Search.Enabled = False
            CustName_Search.Enabled = False

        Else
            CustID_Search.Enabled = True
            CustName_Search.Enabled = True

        End If

    End Sub

    Private Sub NameList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NameList.SelectedIndexChanged

        CustIDselected = CustIDs(NameList.SelectedIndex)

        CustName_Search.Text = NameList.SelectedItem.ToString

        NameList.Visible = False

    End Sub

    Private Sub CustUpdate_Click(sender As Object, e As EventArgs) Handles CustUpdate.Click
        Dim sqlcommand As New OleDb.OleDbCommand
        Dim sqlquery As String = "UPDATE Cust_Dbase SET " +
                                 "CustName = '" + CustName_Edit.Text +
                                 "', CustAddress = '" + CustAddress_Edit.Text +
                                 "', CustMobile = " + CustPhone_Edit.Text +
                                 " Where CustID = " + CustID_View.Text

        Try
            With sqlcommand
                .CommandText = sqlquery
                .Connection = CustDbase_Conn
                .ExecuteNonQuery()
            End With

            MessageBox.Show("Customer Updated")
        Catch ex As Exception

            MessageBox.Show(ex.Message + vbCrLf + "Unable create New Customer")

        End Try

        Me.Close()

    End Sub

    '-----------------------Edit Customer-------------------------------------

End Class