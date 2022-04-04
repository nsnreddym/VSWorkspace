Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc
Imports System.ComponentModel

Public Class ModifyLoan
    Dim dbProvider As String
    Dim CustDbase_Conn As New OleDb.OleDbConnection
    Dim LoanDbase_Conn As New OleDb.OleDbConnection
    Dim PostDbase_Conn As New OleDb.OleDbConnection
    Dim dbSource As String
    Dim dbSource2 As String
    Dim dbSource3 As String
    Dim Date_selected As String

    Dim CustIDs(1000) As Integer
    Dim CustIDselected As Integer
    Dim LoanIDselected As Integer


    Private Sub ModifyLoan_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        Menu_selected = MENU_ENUM.NO_OPTION
        MainForm.HideOrShow_options(True)
        CustDbase_Conn.Close()
        LoanDbase_Conn.Close()
        PostDbase_Conn.Close()

    End Sub

    Private Sub ModifyLoan_Load(sender As Object, e As EventArgs) Handles Me.Load

        Me.WindowState = FormWindowState.Maximized
        Bar1.Location = New Point(0, Bar1.Location.Y)
        Bar1.Size = New Size(Me.Size.Width, Bar1.Size.Height)
        Bar3.Location = New Point(0, Bar3.Location.Y)
        Bar3.Size = New Size(Me.Size.Width, Bar4.Size.Height)
        Bar4.Location = New Point(0, Bar4.Location.Y)
        Bar3.Size = New Size(Me.Size.Width, Bar4.Size.Height)

        Date_selected = DateTimePicker1.Value.ToString("MM/dd/yyyy")

        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
                      "Jet OLEDB:Database Password=Bindu@10apr; " +
                      "Data Source =  "

        dbSource = CustPath
        dbSource2 = LoanPath
        dbSource3 = PostPath
        CustDbase_Conn.ConnectionString = dbProvider & dbSource
        CustDbase_Conn.Open()
        LoanDbase_Conn.ConnectionString = dbProvider & dbSource2
        LoanDbase_Conn.Open()
        PostDbase_Conn.ConnectionString = dbProvider & dbSource3
        PostDbase_Conn.Open()

        Select Case Menu_selected

            Case MENU_ENUM.LOAN_NEW_OPTION

                AddLoanTab.Visible = True
                EditLoanTab.Visible = False

            Case MENU_ENUM.LOAN_VIEW_OPTION

                AddLoanTab.Visible = False
                EditLoanTab.Visible = True


        End Select

    End Sub

    Private Sub ModifyLoan_SizeChanged(sender As Object, e As EventArgs) Handles Me.SizeChanged
        Bar1.Size = New Size(Me.Size.Width, Bar1.Size.Height)
        Bar3.Size = New Size(Me.Size.Width, Bar3.Size.Height)
        Bar4.Size = New Size(Me.Size.Width, Bar4.Size.Height)

    End Sub

    '---------------------------New Loan-----------------------------------------------------------

    Private Sub DateTimePicker1_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker1.CloseUp

        Date_selected = DateTimePicker1.Value.ToString("M/d/yyyy")

    End Sub

    Private Sub CustAddCancelButton_Click(sender As Object, e As EventArgs) Handles CustAddCancelButton.Click
        Me.Close()
    End Sub

    Private Sub CustID_Search_TextChanged(sender As Object, e As EventArgs) Handles CustID_Search.TextChanged

        If CustID_Search.TextLength <> 0 Then

            CustName_Search.Visible = False

        Else
            CustName_Search.Visible = True

        End If

    End Sub

    Private Sub CustName_Search_TextChanged(sender As Object, e As EventArgs) Handles CustName_Search.TextChanged

        If CustName_Search.TextLength <> 0 Then

            Dim ds As New DataSet
            Dim da As OleDb.OleDbDataAdapter
            Dim sql As String
            Dim MaxCust As Integer

            CustID_Search.Visible = False

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

            CustID_Search.Visible = True

        End If

    End Sub

    Private Sub NameList_SelectedIndexChanged(sender As Object, e As EventArgs) Handles NameList.SelectedIndexChanged

        CustIDselected = CustIDs(NameList.SelectedIndex)

        CustName_Search.Text = NameList.SelectedItem.ToString

        NameList.Visible = False

        Display_custdetails()

    End Sub

    Private Sub CustID_Search_KeyPress(sender As Object, e As KeyPressEventArgs) Handles CustID_Search.KeyPress

        If CustID_Search.TextLength <> 0 Then

            CustName_Search.Enabled = False

            If e.KeyChar = vbCr Then
                CustIDselected = CustID_Search.Text
                Display_custdetails()
            End If
        Else
            CustName_Search.Enabled = True

        End If

    End Sub

    Private Sub Display_custdetails()
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim sql As String

        sql = "SELECT * FROM Cust_Dbase WHERE CustID = " _
                  + CustIDselected.ToString

        da = New OleDb.OleDbDataAdapter(sql, CustDbase_Conn)

        Try

            da.Fill(ds, "CustdataSet")

            CustID_view.Text = CustIDselected

            CustName_view.Text = ds.Tables("Custdataset").Rows(0).Item(1)

            Phone_Search.Text = ds.Tables("Custdataset").Rows(0).Item(3)

            Address_Search.Text = ds.Tables("Custdataset").Rows(0).Item(2)

            'Allot new loan ID
            sql = "SELECT Max(LnID) FROM Loan_Details"

            da = New OleDb.OleDbDataAdapter(sql, LoanDbase_Conn)

            da.Fill(ds, "Loandataset")

            TxtLoanIDNew.Text = ds.Tables("Loandataset").Rows(0).Item(0) + 1

            LoanStatus_New.SelectedIndex = LOAN_STATUS_FLAGS.LnNew
            LoanStatus_New.Enabled = 0
            LoanPayModeNew.SelectedIndex = EMI_PAYMODE_FLAGS.EMIDaily

            'Enable loan details
            TxtLoanAmtNew.Enabled = True
            TxtComiNew.Enabled = True
            TxtTenureNew.Enabled = True
            TxtEMINew.Enabled = True
            LoanPayModeNew.Enabled = True
            DateTimePicker1.Enabled = True
            LoanAddButton.Enabled = True
            LoanMoreButton.Enabled = True

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub Add_customer_new()

        Dim sqlquery As String = "INSERT INTO Loan_Details( CustID, LnID, LnDate, LnAmt, LnCom, LnTenure, InstAmt, InstPeriod, Lnstatus ) VALUES ( '" _
                                                            & CustIDselected.ToString & "','" _
                                                            & TxtLoanIDNew.Text & "',#" _
                                                            & Date_selected & "#,'" _
                                                            & TxtLoanAmtNew.Text & "','" _
                                                            & TxtComiNew.Text & "','" _
                                                            & TxtTenureNew.Text & "','" _
                                                            & TxtEMINew.Text & "','" _
                                                            & LoanPayModeNew.SelectedIndex & "','" _
                                                            & LoanStatus_New.SelectedIndex & "');"

        Dim sqlcommand As New OleDb.OleDbCommand

        Try

            With sqlcommand
                .CommandText = sqlquery
                .Connection = LoanDbase_Conn
                .ExecuteNonQuery()
            End With

            MessageBox.Show("Loan created")

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub LoanMoreButton_Click(sender As Object, e As EventArgs) Handles LoanMoreButton.Click

        LoanStatus_New.SelectedIndex = LOAN_STATUS_FLAGS.LnOpen

        Add_customer_new()

        'Clear data
        TxtLoanIDNew.Text = ""
        TxtLoanAmtNew.Text = ""
        TxtComiNew.Text = ""
        TxtTenureNew.Text = ""
        TxtEMINew.Text = ""
        LoanPayModeNew.SelectedIndex = EMI_PAYMODE_FLAGS.EMIDaily
        LoanStatus_New.SelectedIndex = LOAN_STATUS_FLAGS.LnNew


        'Disable loan details
        TxtLoanAmtNew.Enabled = False
        TxtComiNew.Enabled = False
        TxtTenureNew.Enabled = False
        TxtEMINew.Enabled = False
        LoanPayModeNew.Enabled = False
        DateTimePicker1.Enabled = False
        LoanAddButton.Enabled = False
        LoanMoreButton.Enabled = False

    End Sub

    Private Sub LoanAddButton_Click(sender As Object, e As EventArgs) Handles LoanAddButton.Click

        LoanStatus_New.SelectedIndex = LOAN_STATUS_FLAGS.LnOpen

        Add_customer_new()

        Me.Close()

    End Sub

    '---------------------------New Loan-----------------------------------------------------------

    '---------------------------Edit Loan----------------------------------------------------------

    Private Sub CancelEditButton_Click(sender As Object, e As EventArgs) Handles CancelEditButton.Click
        Me.Close()
    End Sub

    Private Sub Display_LoanDetails()
        Dim Sql As String
        Dim ds As New DataSet
        Dim da As OleDb.OleDbDataAdapter
        Dim ds2 As New DataSet
        Dim da2 As OleDb.OleDbDataAdapter
        Dim ds3 As New DataSet
        Dim da3 As OleDb.OleDbDataAdapter

        Dim readdate As Date

        Try
            'Get loan details
            Sql = "Select * FROM Loan_Details WHERE LnID = " + TxtLoanIDEdit.Text

            da = New OleDb.OleDbDataAdapter(Sql, LoanDbase_Conn)
            da.Fill(ds, "MyLoandata")

            'Get customer details
            Sql = "Select * FROM Cust_Dbase WHERE CustID = " +
                           ds.Tables("MyLoandata").Rows(0).Item(0).ToString

            da2 = New OleDb.OleDbDataAdapter(Sql, CustDbase_Conn)
            da2.Fill(ds2, "MyCustdata")

            'Fill customer details
            TxtCustIDEdit.Text = ds2.Tables("MyCustdata").Rows(0).Item(0).ToString
            TxtCustNameEdit.Text = ds2.Tables("MyCustdata").Rows(0).Item(1).ToString
            TxtCustIDSearch.Text = ds2.Tables("MyCustdata").Rows(0).Item(0).ToString
            TxtCustNameSearch.Text = ds2.Tables("MyCustdata").Rows(0).Item(1).ToString
            TxtCustAddressEdit.Text = ds2.Tables("MyCustdata").Rows(0).Item(2).ToString
            TxtPhoneEdit.Text = ds2.Tables("MyCustdata").Rows(0).Item(3).ToString

            'Fill Loan details
            TxtLoanStatusEdit.SelectedIndex = ds.Tables("MyLoandata").Rows(0).Item(8)
            readdate = ds.Tables("MyLoandata").Rows(0).Item(2)
            TxtLoanOpenDateEdit.Text = readdate.ToShortDateString
            TxtLoanAmtEdit.Text = ds.Tables("MyLoandata").Rows(0).Item(3).ToString
            TxtLoanComEdit.Text = ds.Tables("MyLoandata").Rows(0).Item(4).ToString
            TxtLoanTenureEdit.Text = ds.Tables("MyLoandata").Rows(0).Item(5).ToString
            TxtPayModeEdit.SelectedIndex = ds.Tables("MyLoandata").Rows(0).Item(7)
            TxtEMIEdit.Text = ds.Tables("MyLoandata").Rows(0).Item(6).ToString
            TxtLoanCloseDateEdit.Text = ds.Tables("MyLoandata").Rows(0).Item(9).ToString
            DateTimePicker2.Text = ds.Tables("MyLoandata").Rows(0).Item(9).ToString


            'Get Loan Paid Amount
            Sql = "Select SUM(InstAmt) FROM Posting WHERE LnID = " + TxtLoanIDEdit.Text

            da3 = New OleDb.OleDbDataAdapter(Sql, PostDbase_Conn)
            da3.Fill(ds3, "MyPostdata")

            'Fill data
            TxtLoanPaidEdit.Text = ds3.Tables("MyPostdata").Rows(0).Item(0).ToString




        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

    End Sub

    Private Sub TxtLoanIDEdit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtLoanIDEdit.KeyPress

        If TxtLoanIDEdit.TextLength <> 0 Then

            If e.KeyChar = vbCr Then

                LoanIDselected = TxtLoanIDEdit.Text

                Display_LoanDetails()

                ChkLoanEdit.Checked = False

                UpdateEditLoanButton.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)

                TxtLoanStatusEdit.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
                TxtLoanOpenDateEdit.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
                TxtLoanAmtEdit.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
                TxtLoanComEdit.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
                TxtLoanTenureEdit.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
                TxtPayModeEdit.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
                TxtEMIEdit.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
                ChkLoanEdit.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
                TxtLoanCloseDateEdit.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
                DateTimePicker2.Enabled = CurrentUser.Perm_Write(ACTIVITY_ID.ACT_LOAN)
            Else

                ChkLoanEdit.Checked = False

                UpdateEditLoanButton.Enabled = False
                TxtLoanStatusEdit.Enabled = False
                TxtLoanOpenDateEdit.Enabled = False
                TxtLoanAmtEdit.Enabled = False
                TxtLoanComEdit.Enabled = False
                TxtLoanTenureEdit.Enabled = False
                TxtPayModeEdit.Enabled = False
                TxtEMIEdit.Enabled = False
                ChkLoanEdit.Enabled = False
                TxtLoanCloseDateEdit.Enabled = False
                DateTimePicker2.Enabled = False

            End If
        Else

        End If

    End Sub

    Private Sub ChkLoanEdit_CheckedChanged(sender As Object, e As EventArgs) Handles ChkLoanEdit.CheckedChanged

        If ChkLoanEdit.Checked = True Then

            TxtCustNameEdit.Visible = False
            TxtCustIDEdit.Visible = False
            TxtCustNameSearch.Visible = True
            TxtCustIDSearch.Visible = True


        Else

            TxtCustNameEdit.Visible = True
            TxtCustIDEdit.Visible = True
            TxtCustNameSearch.Visible = False
            TxtCustIDSearch.Visible = False


        End If

    End Sub

    Private Sub UpdateEditLoanButton_Click(sender As Object, e As EventArgs) Handles UpdateEditLoanButton.Click

        Dim query1 As String = "Update Loan_Details SET " +
                                 "CustID = " + TxtCustIDEdit.Text +
                                 ", LnDate = #" + TxtLoanOpenDateEdit.Text +
                                 "#, LnAmt = " + TxtLoanAmtEdit.Text +
                                 ", LnCom = " + TxtLoanComEdit.Text +
                                 ", LnTenure = " + TxtLoanTenureEdit.Text +
                                 ", InstAmt = " + TxtEMIEdit.Text +
                                 ", InstPeriod = " + TxtPayModeEdit.SelectedIndex.ToString +
                                 ", Lnstatus = " + TxtLoanStatusEdit.SelectedIndex.ToString

        Dim query2 As String = ", CloseDate = #" + TxtLoanCloseDateEdit.Text + "#"
        Dim query3 As String = " WHERE LnID = " + LoanIDselected.ToString


        Dim sqlquery As String

        Dim sqlcommand As New OleDb.OleDbCommand

        If TxtLoanStatusEdit.SelectedIndex = LOAN_STATUS_FLAGS.LnClose Then

            If TxtLoanCloseDateEdit.TextLength = 0 Then

                MessageBox.Show("Select Close Date")

                Return

            Else

                sqlquery = query1 + query2 + query3

            End If

        Else
            sqlquery = query1 + ", CloseDate = Null" + query3
        End If

        Try

            With sqlcommand
                .CommandText = sqlquery
                .Connection = LoanDbase_Conn
                .ExecuteNonQuery()
            End With

            MessageBox.Show("Loan details Updated")

        Catch ex As Exception

            MessageBox.Show(ex.Message)

        End Try

        Me.Close()

    End Sub

    Private Sub TxtCustIDEdit_KeyPress(sender As Object, e As KeyPressEventArgs) Handles TxtCustIDEdit.KeyPress
        If TxtCustIDEdit.TextLength <> 0 Then

            TxtCustNameEdit.Enabled = False

            If e.KeyChar = vbCr Then

                CustIDselected = TxtCustIDEdit.Text

            Else
            End If
        Else
            TxtCustNameEdit.Enabled = True

        End If

    End Sub

    Private Sub DateTimePicker2_CloseUp(sender As Object, e As EventArgs) Handles DateTimePicker2.CloseUp

        TxtLoanCloseDateEdit.Text = DateTimePicker2.Value.ToString("M/d/yyyy")

    End Sub

    Private Sub TxtLoanStatusEdit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles TxtLoanStatusEdit.SelectedIndexChanged

        If TxtLoanStatusEdit.SelectedIndex = LOAN_STATUS_FLAGS.LnClose Then

            TxtLoanCloseDateEdit.Visible = True
            DateTimePicker2.Visible = True
            LabelX31.Visible = True

        Else

            TxtLoanCloseDateEdit.Visible = False
            DateTimePicker2.Visible = False
            LabelX31.Visible = False

        End If

    End Sub

    '---------------------------Edit Loan----------------------------------------------------------

End Class