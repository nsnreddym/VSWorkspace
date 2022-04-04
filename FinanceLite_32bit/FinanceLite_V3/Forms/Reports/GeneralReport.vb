Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc
Imports System.ComponentModel

Public Class GeneralReport
    Dim CustDbase_Conn As New OleDb.OleDbConnection
    Dim LoanDbase_Conn As New OleDb.OleDbConnection
    Dim PostDbase_Conn As New OleDb.OleDbConnection
    Dim dbProvider As String
    Dim dbSource As String
    Dim dbSource2 As String
    Dim dbSource3 As String

    Private Sub GeneralReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed

        CustDbase_Conn.Close()
        LoanDbase_Conn.Close()
        PostDbase_Conn.Close()


        MainForm.HideOrShow_options(True)
        Menu_selected = MENU_ENUM.NO_OPTION

    End Sub

    Private Sub GeneralReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        dbProvider = "PROVIDER=Microsoft.Jet.OLEDB.4.0;" +
                      "Jet OLEDB:Database Password=Bindu@10apr; " +
                      "Data Source =  "
        dbSource = CustPath
        dbSource2 = LoanPath
        dbSource3 = PostPath

        CustDbase_Conn.ConnectionString = dbProvider & dbSource
        LoanDbase_Conn.ConnectionString = dbProvider & dbSource2
        PostDbase_Conn.ConnectionString = dbProvider & dbSource3

        CustDbase_Conn.Open()
        LoanDbase_Conn.Open()
        PostDbase_Conn.Open()

        Me.WindowState = FormWindowState.Maximized

        'WaitBar.MdiParent = MainForm
        WaitBar.Show()

        GetLoanDetails()

        GetDailyDetails()

        GetExpenses()

        GetDeposits()

        WaitBar.Close()

        MainForm.ExportRibbonBar.Enabled = True


    End Sub

    Private Sub GetLoanDetails()
        Dim sql As String
        Dim ds_loan As New DataSet
        Dim da_loan As OleDb.OleDbDataAdapter

        Dim readdate As Date

        Dim Max_loans As Integer

        sql = "Select CustID, LnID, LnDate, LnAmt, LnCom From Loan_details"
        da_loan = New OleDb.OleDbDataAdapter(sql, LoanDbase_Conn)
        da_loan.Fill(ds_loan, "Loan_data")

        Max_loans = ds_loan.Tables("Loan_data").Rows.Count

        Dim i As Integer

        For i = 0 To Max_loans - 1

            Dim ds_cust As New DataSet
            Dim da_cust As OleDb.OleDbDataAdapter

            Dim ds_post As New DataSet
            Dim da_post As OleDb.OleDbDataAdapter

            LoanTableView.Rows.Add()

            readdate = ds_loan.Tables("Loan_data").Rows(i).Item(2)

            LoanTableView.Rows(i).Cells(0).Value = readdate.ToString("dd-MMM-yyyy")
            LoanTableView.Rows(i).Cells(1).Value = ds_loan.Tables("Loan_data").Rows(i).Item(1)
            LoanTableView.Rows(i).Cells(3).Value = ds_loan.Tables("Loan_data").Rows(i).Item(3)
            LoanTableView.Rows(i).Cells(4).Value = ds_loan.Tables("Loan_data").Rows(i).Item(4)

            sql = "Select CustName From Cust_Dbase Where CustId = " + ds_loan.Tables("Loan_data").Rows(i).Item(0).ToString
            da_cust = New OleDb.OleDbDataAdapter(sql, CustDbase_Conn)
            da_cust.Fill(ds_cust, "Cust_data")

            LoanTableView.Rows(i).Cells(2).Value = ds_cust.Tables("Cust_data").Rows(0).Item(0).ToString

            sql = "Select SUM(InstAmt) from Posting Where LnID = " + ds_loan.Tables("Loan_data").Rows(i).Item(1).ToString
            da_post = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)
            da_post.Fill(ds_post, "Post_data")

            LoanTableView.Rows(i).Cells(5).Value = ds_post.Tables("Post_data").Rows(0).Item(0)

        Next

        LoanTableView.Sort(LoanID, System.ComponentModel.ListSortDirection.Ascending)

    End Sub

    Private Sub GetDailyDetails()
        Dim sql As String
        Dim today = New Date(Year_sel - 1, 12, 31)
        Dim LeapYear As Integer
        Dim NoOfDays As Integer

        LeapYear = System.DateTime.IsLeapYear(Year_sel)

        If LeapYear Then

            NoOfDays = 366

        Else

            NoOfDays = 365

        End If

        NoOfDays = 700

        Dim i As Integer
        Dim y As Integer
        Dim rno As Integer
        rno = 0
        For i = 1 To NoOfDays
            Dim ds_post As New DataSet
            Dim da_post As OleDb.OleDbDataAdapter


            today = today.AddDays(1)

            sql = "Select SUM(InstAmt) FROM Posting Where DOP = #" + today.ToString("M/d/yyyy") + "#"
            da_post = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)
            da_post.Fill(ds_post, "Post_data")

            Try

                y = ds_post.Tables("Post_data").Rows.Count

                If (ds_post.Tables("Post_data").Rows(0).Item(0)) Then

                    DailyTableView.Rows.Add()

                    DailyTableView.Rows(rno).Cells(0).Value = today.ToString("dd-MMM-yyyy")
                    DailyTableView.Rows(rno).Cells(1).Value = ds_post.Tables("Post_data").Rows(0).Item(0)

                    rno = rno + 1
                End If

            Catch ex As Exception

                'MessageBox.Show(ex.Message)

            End Try

        Next


    End Sub

    Private Sub GetExpenses()
        Dim sql As String
        Dim today = New Date(Year_sel - 1, 12, 31)
        Dim LeapYear As Integer
        Dim NoOfDays As Integer

        LeapYear = System.DateTime.IsLeapYear(Year_sel)

        If LeapYear Then

            NoOfDays = 366

        Else

            NoOfDays = 365

        End If

        NoOfDays = 700

        Dim i As Integer
        Dim y As Integer
        Dim rno As Integer
        Dim j As Integer
        rno = 0
        For i = 1 To NoOfDays
            Dim ds_post As New DataSet
            Dim da_post As OleDb.OleDbDataAdapter


            today = today.AddDays(1)

            sql = "Select * FROM Expenses Where ExpDate = #" + today.ToString("M/d/yyyy") + "#"
            da_post = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)
            da_post.Fill(ds_post, "EXP_data")

            Try

                y = ds_post.Tables("EXP_data").Rows.Count

                If y > 0 Then

                    For j = 0 To y - 1

                        ExpensesTableView.Rows.Add()

                        ExpensesTableView.Rows(rno).Cells(0).Value = today.ToString("dd-MMM-yyyy")
                        ExpensesTableView.Rows(rno).Cells(1).Value = ds_post.Tables("EXP_data").Rows(j).Item(1)
                        ExpensesTableView.Rows(rno).Cells(2).Value = ds_post.Tables("EXP_data").Rows(j).Item(2)

                        rno = rno + 1
                    Next

                End If

            Catch ex As Exception

                MessageBox.Show(ex.Message)

            End Try

        Next



    End Sub

    Private Sub GetDeposits()
        Dim sql As String
        Dim today = New Date(Year_sel - 1, 12, 31)
        Dim LeapYear As Integer
        Dim NoOfDays As Integer

        LeapYear = System.DateTime.IsLeapYear(Year_sel)

        If LeapYear Then

            NoOfDays = 366

        Else

            NoOfDays = 365

        End If

        NoOfDays = 700

        Dim i As Integer
        Dim y As Integer
        Dim rno As Integer
        Dim j As Integer
        rno = 0
        For i = 1 To NoOfDays
            Dim ds_post As New DataSet
            Dim da_post As OleDb.OleDbDataAdapter


            today = today.AddDays(1)

            sql = "Select * FROM Deposits Where PDate = #" + today.ToString("M/d/yyyy") + "#"
            da_post = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)
            da_post.Fill(ds_post, "DPST_data")

            Try

                y = ds_post.Tables("DPST_data").Rows.Count

                If y > 0 Then

                    For j = 0 To y - 1

                        Dim ds_part As New DataSet
                        Dim da_part As OleDb.OleDbDataAdapter
                        Dim sql2 As String

                        DepositsTableView.Rows.Add()

                        DepositsTableView.Rows(rno).Cells(0).Value = today.ToString("dd-MMM-yyyy")

                        sql2 = "Select PNAME FROM Partners Where PID = " + ds_post.Tables("DPST_data").Rows(j).Item(0).ToString

                        da_part = New OleDb.OleDbDataAdapter(sql2, PostDbase_Conn)
                        da_part.Fill(ds_part, "Part_data")

                        DepositsTableView.Rows(rno).Cells(1).Value = ds_part.Tables("Part_data").Rows(0).Item(0)

                        If ds_post.Tables("DPST_data").Rows(j).Item(3) = "Cr" Then

                            DepositsTableView.Rows(rno).Cells(2).Value = ds_post.Tables("DPST_data").Rows(j).Item(1)

                        Else

                            DepositsTableView.Rows(rno).Cells(3).Value = ds_post.Tables("DPST_data").Rows(j).Item(1)

                        End If

                        rno = rno + 1
                    Next

                End If

            Catch ex As Exception

                MessageBox.Show(ex.Message)

            End Try

        Next



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

    Public Sub ExportDataToPDFTable(Filename As String)
        Dim paragraph As New Paragraph
        Dim doc As New Document(iTextSharp.text.PageSize.A4, 10, 10, 10, 10)
        Dim wri As PdfWriter = PdfWriter.GetInstance(doc, New FileStream(Filename + ".pdf", FileMode.Create))

        doc.Open()

        Dim PdfTable As New PdfPTable(6)
        Dim PdfPCell As PdfPCell = Nothing
        Dim widths As Single() = New Single(5) {}
        Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)



        doc.Add(ExportTableDetails(LoanTableView, LoanSummaryTableWidths))
        doc.NewPage()
        doc.Add(ExportTableDetails(DailyTableView, DailySummaryTableWidths))
        doc.NewPage()
        doc.Add(ExportTableDetails(ExpensesTableView, ExpensesSummaryTableWidths))
        doc.NewPage()
        doc.Add(ExportTableDetails(DepositsTableView, DepositsSummaryTableWidths))

        doc.Close()
    End Sub

End Class