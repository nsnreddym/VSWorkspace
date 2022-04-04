Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc
Imports System.ComponentModel

Public Class Posting

    Dim dbProvider As String
    Dim CustDbase_Conn As New OleDb.OleDbConnection
    Dim LoanDbase_Conn As New OleDb.OleDbConnection
    Dim PostDbase_Conn As New OleDb.OleDbConnection
    Dim dbSource As String
    Dim dbSource2 As String
    Dim dbSource3 As String

    Private Sub Posting_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Me.WindowState = FormWindowState.Maximized

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

            Case MENU_ENUM.POSTINGDAILY_OPTION
                DailyPostingTab.Visible = True
                BulkPostingTab.Visible = False
                ExpensesTab.Visible = False

                MainForm.DailyPostingControlTab.Visible = True
                MainForm.BulkPostingControlTab.Visible = False
                MainForm.DailyReportControlTab.Visible = False


            Case MENU_ENUM.POSTINGBULK_OPTION
                DailyPostingTab.Visible = False
                BulkPostingTab.Visible = True
                ExpensesTab.Visible = False

                MainForm.DailyPostingControlTab.Visible = False
                MainForm.BulkPostingControlTab.Visible = True
                MainForm.DailyReportControlTab.Visible = False

                BulkPostingTab.Text = "Bulk Posting"


            Case MENU_ENUM.REPORTDAILY_OPTION
                DailyPostingTab.Visible = False
                BulkPostingTab.Visible = True
                ExpensesTab.Visible = False

                MainForm.DailyPostingControlTab.Visible = False
                MainForm.BulkPostingControlTab.Visible = False
                MainForm.DailyReportControlTab.Visible = True

                BulkPostingTab.Text = "Daily Report"

            Case MENU_ENUM.EXPENSESADD_OPTION
                DailyPostingTab.Visible = False
                BulkPostingTab.Visible = False
                ExpensesTab.Visible = True

                MainForm.DailyPostingControlTab.Visible = True
                MainForm.BulkPostingControlTab.Visible = False
                MainForm.DailyReportControlTab.Visible = False

        End Select

    End Sub

    Private Sub Posting_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed


        Menu_selected = MENU_ENUM.NO_OPTION
        MainForm.HideOrShow_options(True)
        CustDbase_Conn.Close()
        LoanDbase_Conn.Close()
        PostDbase_Conn.Close()

        MainForm.BulkPostingControlTab.Visible = False
        MainForm.DailyReportControlTab.Visible = False
        MainForm.DailyPostingControlTab.Visible = False

        MainForm.PostData_Total.Text = 0

    End Sub


    '-----------------------------Daily Posting Tab---------------------------------------------
    Public Sub DailyPostingDateChanged(Date_sel As Date)

        Dim sqlcommand As New OleDb.OleDbCommand
        Dim sql As String
        Dim NoofRows As Integer
        Dim i As Integer
        Dim Date_dsp As String
        Dim Total As Integer

        Date_dsp = Date_sel.ToString("M/d/yyyy")

        sql = "SELECT * FROM Posting  WHERE DOP = #" + Date_dsp + "#"
        Dim ds_post As New DataSet
        Dim da_post As OleDb.OleDbDataAdapter

        da_post = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)
        da_post.Fill(ds_post, "Post_data")
        NoofRows = ds_post.Tables("Post_data").Rows.Count

        ReportBalanceSheet.Rows.Clear()

        For i = 0 To NoofRows - 1
            ReportBalanceSheet.Rows.Add()

            ReportBalanceSheet.Rows(i).Cells(0).Value = ds_post.Tables("Post_data").Rows(i).Item(1).ToString
            ReportBalanceSheet.Rows(i).Cells(2).Value = ds_post.Tables("Post_data").Rows(i).Item(2).ToString


        Next

        Total = 0

        For i = 0 To NoofRows - 1
            Total = Total + ReportBalanceSheet.Rows.Item(i).Cells(2).Value
        Next i

        MainForm.PostData_Total.Text = Total
        verifyName()


    End Sub

    Public Sub verifyName()
        Dim sqlcmd1 As String
        Dim sqlcmd2 As String

        Dim loop1 As Integer
        Dim CustID As String
        Dim LoanID As String

        Dim maxrows As Integer

        maxrows = ReportBalanceSheet.Rows.Count

        For loop1 = 1 To maxrows - 1

            Dim ds_loan As New DataSet
            Dim da_loan As OleDb.OleDbDataAdapter
            Dim ds_cust As New DataSet
            Dim da_cust As OleDb.OleDbDataAdapter

            Try

                LoanID = ReportBalanceSheet.Rows.Item(loop1 - 1).Cells(0).Value.ToString
                sqlcmd1 = "SELECT * FROM Loan_Details WHERE LnID = " + LoanID

                da_loan = New OleDb.OleDbDataAdapter(sqlcmd1, LoanDbase_Conn)
                da_loan.Fill(ds_loan, "Loan_data")

                CustID = ds_loan.Tables("Loan_data").Rows(0).Item(0).ToString

                sqlcmd2 = "SELECT * FROM Cust_Dbase WHERE CustID = " + CustID

                da_cust = New OleDb.OleDbDataAdapter(sqlcmd2, CustDbase_Conn)
                da_cust.Fill(ds_cust, "Cust_data")

                ReportBalanceSheet.Rows.Item(loop1 - 1).Cells(1).Value = ds_cust.Tables("Cust_data").Rows(0).Item(1).ToString
            Catch
            End Try

        Next

    End Sub

    Public Sub DailyPostingSaveData(Date_sel As Date)
        Dim sqlcommand As New OleDb.OleDbCommand
        Dim sql As String
        Dim sql2 As String
        Dim NoofRows As Integer
        Dim Date_dsp As String

        Date_dsp = Date_sel.ToString("MM/dd/yyyy")

        NoofRows = ReportBalanceSheet.Rows.Count

        For i = 1 To NoofRows - 1

            If ReportBalanceSheet.Rows.Item(i - 1).Cells(0).Value _
                       Is Nothing Then
                MessageBox.Show("Please Verify data")
                Return
            End If
            If ReportBalanceSheet.Rows.Item(i - 1).Cells(1).Value _
                       Is Nothing Then
                MessageBox.Show("Please Verify data")
                Return
            End If
            If ReportBalanceSheet.Rows.Item(i - 1).Cells(2).Value _
                       Is Nothing Then
                MessageBox.Show("Please Verify data")
                Return
            End If
        Next

        sql = "DELETE FROM Posting WHERE DOP = #" + Date_dsp + "#"

        With sqlcommand
            .CommandText = sql
            .Connection = PostDbase_Conn
            .ExecuteNonQuery()
        End With

        For i = 1 To NoofRows - 1

            sql = "INSERT INTO Posting( DOP, LnID, InstAmt ) VALUES ( #" _
                                         & Date_dsp & "#,'" _
                                         & ReportBalanceSheet.Rows.Item(i - 1).Cells(0).Value & "','" _
                                         & ReportBalanceSheet.Rows.Item(i - 1).Cells(2).Value & "');"
            With sqlcommand
                .CommandText = sql
                .Connection = PostDbase_Conn
                .ExecuteNonQuery()
            End With

        Next i

        MessageBox.Show("Updated Sucessfully...")

        ReportBalanceSheet.Rows.Clear()

    End Sub

    Private Sub DailyPosting_table_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles ReportBalanceSheet.CellEndEdit

        Dim NoofRows As Integer
        Dim Total As Integer

        NoofRows = ReportBalanceSheet.Rows.GetLastRow(DataGridViewElementStates.Visible)

        Total = 0

        For i = 0 To NoofRows - 1
            Total = Total + ReportBalanceSheet.Rows.Item(i).Cells(2).Value
        Next i

        MainForm.PostData_Total.Text = Total

        verifyName()

    End Sub

    '-----------------------------Bulk Posting Tab----------------------------------------------
    Public Sub viewdata(MonthSel As Integer)
        Dim sql As String
        Dim ds_loan As New DataSet
        Dim da_loan As OleDb.OleDbDataAdapter
        Dim ds_cust As New DataSet
        Dim da_cust As OleDb.OleDbDataAdapter

        Dim Max_loans As Integer
        Dim Date_sel As String

        Dim Start_Date As Date
        Dim End_Date As Date
        Dim NoOfDays As Integer
        Dim YearSel As Integer

        If MonthSel < 3 Then

            YearSel = Year_sel + 1
        Else

            YearSel = Year_sel
        End If

        MonthSel = MonthSel + 1

        NoOfDays = System.DateTime.DaysInMonth(YearSel, MonthSel)
        Start_Date = DateValue(MonthSel & "/01/" & YearSel)
        End_Date = DateValue(MonthSel & "/" & NoOfDays & "/" & YearSel)

        sql = "Select * FROM Loan_Details  WHERE LnDate <= #" & End_Date.ToString("M/d/yyyy") &
                     "# And ((CloseDate >= #" & Start_Date.ToString("M/d/yyyy") &
                     "# ) Or (LnStatus = 1)) Order by LnID"
        da_loan = New OleDb.OleDbDataAdapter(sql, LoanDbase_Conn)
        da_loan.Fill(ds_loan, "Loan_data")

        Max_loans = ds_loan.Tables("Loan_data").Rows.Count

        Dim i As Integer
        Dim j As Integer
        Dim x As Integer
        Dim y As Integer
        Dim total(1000) As Integer

        BulkPostingTable.ColumnCount = 4
        BulkPostingTable.Rows.Clear()

        For x = 1 To NoOfDays

            BulkPostingTable.Columns.Add("Col" + x.ToString, x.ToString(String.Format("00")))
            BulkPostingTable.Columns(x + 3).ReadOnly = True
            BulkPostingTable.Columns(x + 3).Resizable = False
            BulkPostingTable.Columns(x + 3).SortMode = DataGridViewColumnSortMode.Programmatic

        Next x

        For i = 0 To Max_loans - 1

            BulkPostingTable.Rows.Add()
        Next i

        For x = 1 To NoOfDays


            total(x) = 0

            For i = 0 To Max_loans - 1
                Dim ds_post As New DataSet
                Dim da_post As OleDb.OleDbDataAdapter



                j = ds_loan.Tables("Loan_data").Rows(i).Item(0)

                sql = "Select * FROM Cust_Dbase WHERE CustID = " + j.ToString

                da_cust = New OleDb.OleDbDataAdapter(sql, CustDbase_Conn)
                da_cust.Fill(ds_cust, "Cust_data")

                BulkPostingTable.Rows.Item(i).Cells(0).Value = ds_loan.Tables("Loan_data").Rows(i).Item(1)
                BulkPostingTable.Rows.Item(i).Cells(1).Value = ds_cust.Tables("Cust_data").Rows(i).Item(1)
                BulkPostingTable.Rows.Item(i).Cells(2).Value = ds_loan.Tables("Loan_data").Rows(i).Item(3)
                BulkPostingTable.Rows.Item(i).Cells(3).Value = ds_loan.Tables("Loan_data").Rows(i).Item(4)


                Date_sel = MonthSel.ToString + "/" +
                           x.ToString() + "/" +
                           YearSel.ToString

                sql = "Select * FROM Posting WHERE DOP = " + "#" + Date_sel.ToString +
                                                           "# AND LnID = " +
                                                           ds_loan.Tables("Loan_data").Rows(i).Item(1).ToString
                da_post = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)
                da_post.Fill(ds_post, "Post_data")

                y = ds_post.Tables("Post_data").Rows.Count

                If (y > 0) Then

                    BulkPostingTable.Rows.Item(i).Cells(3 + x).Value = ds_post.Tables("Post_data").Rows(0).Item(2)

                    total(x) = total(x) + ds_post.Tables("Post_data").Rows(0).Item(2)
                End If

            Next i

        Next x

        BulkPostingTable.Rows.Add()

        BulkPostingTable.Rows.Item(Max_loans).Cells(1).Value = "Total"

        For x = 1 To NoOfDays

            BulkPostingTable.Rows.Item(i).Cells(3 + x).Value = total(x)

        Next


        MessageBox.Show("Completed")

        MainForm.ExportRibbonBar.Enabled = True


    End Sub

    Private Sub BulkPostingTable_ColumnHeaderMouseDoubleClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles BulkPostingTable.ColumnHeaderMouseDoubleClick

        Select Case Menu_selected

            Case MENU_ENUM.POSTINGBULK_OPTION
                BulkPostingTable.Columns(e.ColumnIndex).ReadOnly = False
                BulkPostingTable.Columns(e.ColumnIndex).DefaultCellStyle.BackColor = Color.SpringGreen

        End Select

    End Sub

    Public Sub BulkPostingSaveData()

        MessageBox.Show("Data updated")

    End Sub

    '-----------------------------Expenses Add Tab----------------------------------------------
    Public Sub ExpensesAddDateChanged(Date_sel As Date)

        Dim sqlcommand As New OleDb.OleDbCommand
        Dim sql As String
        Dim NoofRows As Integer
        Dim i As Integer
        Dim Date_dsp As String
        Dim Total As Integer

        Date_dsp = Date_sel.ToString("M/d/yyyy")

        sql = "SELECT * FROM Expenses  WHERE ExpDate = #" + Date_dsp + "#"
        Dim ds_post As New DataSet
        Dim da_post As OleDb.OleDbDataAdapter

        da_post = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)
        da_post.Fill(ds_post, "Exp_data")
        NoofRows = ds_post.Tables("Exp_data").Rows.Count

        ExpensesTable.Rows.Clear()

        For i = 0 To NoofRows - 1
            ExpensesTable.Rows.Add()

            ExpensesTable.Rows(i).Cells(0).Value = ds_post.Tables("Exp_data").Rows(i).Item(1).ToString
            ExpensesTable.Rows(i).Cells(1).Value = ds_post.Tables("Exp_data").Rows(i).Item(2).ToString


        Next

        Total = 0

        For i = 0 To NoofRows - 1
            Total = Total + ExpensesTable.Rows.Item(i).Cells(1).Value
        Next i

        MainForm.PostData_Total.Text = Total

    End Sub

    Public Sub ExpensesSaveData(Date_sel As Date)

        Dim sqlcommand As New OleDb.OleDbCommand
        Dim sql As String
        Dim sql2 As String
        Dim NoofRows As Integer
        Dim Date_dsp As String

        Date_dsp = Date_sel.ToString("M/d/yyyy")

        NoofRows = ExpensesTable.Rows.Count

        For i = 1 To NoofRows - 1

            If ExpensesTable.Rows.Item(i - 1).Cells(0).Value _
                       Is Nothing Then
                MessageBox.Show("Please Verify data")
                Return
            End If

            If ExpensesTable.Rows.Item(i - 1).Cells(1).Value _
                       Is Nothing Then
                MessageBox.Show("Please Verify data")
                Return
            End If

        Next

        sql = "DELETE FROM Expenses WHERE ExpDate = #" + Date_dsp + "#"

        With sqlcommand
            .CommandText = sql
            .Connection = PostDbase_Conn
            .ExecuteNonQuery()
        End With

        For i = 1 To NoofRows - 1

            sql = "INSERT INTO Expenses( ExpDate, ExpDes, ExpAmount ) VALUES ( #" _
                                         & Date_dsp & "#,'" _
                                         & ExpensesTable.Rows.Item(i - 1).Cells(0).Value & "','" _
                                         & ExpensesTable.Rows.Item(i - 1).Cells(1).Value & "');"
            With sqlcommand
                .CommandText = sql
                .Connection = PostDbase_Conn
                .ExecuteNonQuery()
            End With

        Next i

        MessageBox.Show("Updated Sucessfully...")

        ExpensesTable.Rows.Clear()

    End Sub

    Private Sub ExpensesTable_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles ExpensesTable.CellEndEdit

        Dim NoofRows As Integer
        Dim Total As Integer

        NoofRows = ExpensesTable.Rows.GetLastRow(DataGridViewElementStates.Visible)

        Total = 0

        For i = 0 To NoofRows - 1

            Total = Total + ExpensesTable.Rows.Item(i).Cells(1).Value

        Next i

        MainForm.PostData_Total.Text = Total

    End Sub



    Private Sub releaseObject(ByVal obj As Object)
        Try
            System.Runtime.InteropServices.Marshal.ReleaseComObject(obj)
            obj = Nothing
        Catch ex As Exception
            obj = Nothing
            MessageBox.Show("Exception Occured while releasing object " + ex.ToString())
        Finally
            GC.Collect()
        End Try
    End Sub

    Public Sub BulkPostingTable_export(Filename As String)

        Dim paragraph As New Paragraph
        Dim myPageFormat As New RectangleReadOnly(842, 595)
        Dim doc As New Document(myPageFormat, 10, 10, 10, 10)
        Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(Filename + ".pdf", FileMode.Create))

        doc.Open()

        Dim PdfTable As New PdfPTable(6)
        Dim PdfPCell As PdfPCell = Nothing
        Dim widths As Single() = New Single(5) {}
        Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)



        doc.Add(ExportTableDetails(BulkPostingTable, DailyReportTableWidths))

        doc.Close()

    End Sub

End Class