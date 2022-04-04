Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc
Imports System.ComponentModel

Public Class BalanceReport
    Dim dbProvider As String
    Dim CustDbase_Conn As New OleDb.OleDbConnection
    Dim LoanDbase_Conn As New OleDb.OleDbConnection
    Dim PostDbase_Conn As New OleDb.OleDbConnection
    Dim dbSource As String
    Dim dbSource2 As String
    Dim dbSource3 As String

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

    End Sub

    Private Sub BalanceReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        Report_Balance_Display()
        MainForm.ExportRibbonBar.Enabled = True

    End Sub

    Private Sub BalanceReport_FormClosed(sender As Object, e As FormClosedEventArgs) Handles Me.FormClosed
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

    Private Sub Report_Balance_Display()
        Dim sql As String
        Dim Date_Sel As New Date
        Dim LeapYear As Integer
        Dim NoOfDays As Integer

        ReportBalanceSheet.Rows.Add()
        Dim Startdate As Date
        Dim EndDate As Date

        Startdate = New Date(Year_sel, 01, 01)
        EndDate = New Date(Year_sel + 1, 02, 29)

        Dim today = Startdate


        NoOfDays = DateDiff(DateInterval.Day, Startdate, EndDate)


        Dim y As Integer
        Dim i As Integer
        Dim Rownum As Integer

        Rownum = 0

        ReportBalanceSheet.Rows(0).Cells(3).Value = 0
        ReportBalanceSheet.Rows(Rownum).Cells(2).Value = "Balance"
        ReportBalanceSheet.Rows(0).Cells(1).Value = 0

        Rownum = Rownum + 1

        For i = 1 To NoOfDays
            Dim ds_loan As New DataSet
            Dim da_loan As OleDb.OleDbDataAdapter
            Dim ds_cust As New DataSet
            Dim da_cust As OleDb.OleDbDataAdapter
            Dim ds_post As New DataSet
            Dim da_post As OleDb.OleDbDataAdapter
            Dim ds_exp As New DataSet
            Dim da_exp As OleDb.OleDbDataAdapter
            Dim ds_dep As New DataSet
            Dim da_dep As OleDb.OleDbDataAdapter
            Dim ds_part As New DataSet
            Dim da_part As OleDb.OleDbDataAdapter

            Dim Debit_total As Integer
            Dim Crebit_total As Integer

            Dim Dateadded As Boolean

            Debit_total = ReportBalanceSheet.Rows(Rownum - 1).Cells(3).Value
            Crebit_total = ReportBalanceSheet.Rows(Rownum - 1).Cells(1).Value
            Dateadded = False

            today = today.AddDays(1)

            sql = "SELECT * FROM Loan_Details WHERE LnDate = #" + today.ToString("M/d/yyyy") + "#"
            da_loan = New OleDb.OleDbDataAdapter(sql, LoanDbase_Conn)


            da_loan.Fill(ds_loan, "Loan_data")

            y = ds_loan.Tables("Loan_data").Rows.Count
            'y = 0

            If (y > 0) Then

                ReportBalanceSheet.Rows.Add()

                ReportBalanceSheet.Rows(Rownum).Cells(0).Value = today.ToString("M/d/yyyy") + "#"

                Dateadded = True

                Rownum = Rownum + 1

                For k = 0 To y - 1

                    Dim j As Integer

                    ReportBalanceSheet.Rows.Add()

                    j = ds_loan.Tables("Loan_data").Rows(k).Item(0)

                    sql = "SELECT * FROM Cust_Dbase WHERE CustID = " + j.ToString

                    da_cust = New OleDb.OleDbDataAdapter(sql, CustDbase_Conn)
                    da_cust.Fill(ds_cust, "Cust_data")

                    ReportBalanceSheet.Rows(Rownum).Cells(2).Value = ds_cust.Tables("Cust_data").Rows(k).Item(1)
                    ReportBalanceSheet.Rows(Rownum).Cells(3).Value = ds_loan.Tables("Loan_data").Rows(k).Item(3)
                    ReportBalanceSheet.Rows(Rownum).Cells(1).Value = ds_loan.Tables("Loan_data").Rows(k).Item(4)

                    Crebit_total = Crebit_total + ReportBalanceSheet.Rows(Rownum).Cells(1).Value
                    Debit_total = Debit_total + ReportBalanceSheet.Rows(Rownum).Cells(3).Value

                    Rownum = Rownum + 1


                Next


            End If

            sql = "SELECT * FROM Expenses WHERE ExpDate = #" + today.ToString("M/d/yyyy") + "#"
            da_exp = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)

            da_exp.Fill(ds_exp, "Exp_data")

            y = ds_exp.Tables("Exp_data").Rows.Count
            'y = 0

            If (y > 0) Then

                If Dateadded = False Then

                    ReportBalanceSheet.Rows.Add()

                    ReportBalanceSheet.Rows(Rownum).Cells(0).Value = today.ToString("M/d/yyyy")

                    Dateadded = True

                    Rownum = Rownum + 1

                End If


                For k = 0 To y - 1
                    ReportBalanceSheet.Rows.Add()

                    ReportBalanceSheet.Rows(Rownum).Cells(2).Value = ds_exp.Tables("Exp_data").Rows(k).Item(1)
                    ReportBalanceSheet.Rows(Rownum).Cells(3).Value = ds_exp.Tables("Exp_data").Rows(k).Item(2)

                    Debit_total = Debit_total + ReportBalanceSheet.Rows(Rownum).Cells(3).Value

                    Rownum = Rownum + 1

                Next


            End If

            sql = "Select SUM(InstAmt) FROM Posting Where DOP = #" + today.ToString("M/d/yyyy") + "#"
            da_post = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)

            da_post.Fill(ds_post, "Post_data")

            y = ds_post.Tables("Post_data").Rows.Count
            'y = 0

            If (y > 0) Then

                Try
                    If ds_post.Tables("Post_data").Rows(0).Item(0) > 0 Then
                        If Dateadded = False Then

                            ReportBalanceSheet.Rows.Add()

                            ReportBalanceSheet.Rows(Rownum).Cells(0).Value = today.ToString("M/d/yyyy")

                            Dateadded = True

                            Rownum = Rownum + 1

                        End If

                        ReportBalanceSheet.Rows.Add()

                        ReportBalanceSheet.Rows(Rownum).Cells(2).Value = "Daily"
                        ReportBalanceSheet.Rows(Rownum).Cells(1).Value = ds_post.Tables("Post_data").Rows(0).Item(0)

                        Crebit_total = Crebit_total + ReportBalanceSheet.Rows(Rownum).Cells(1).Value

                        Rownum = Rownum + 1


                    End If
                Catch ex As Exception
                End Try


            End If

            sql = "SELECT * FROM Deposits WHERE PDate = #" + today.ToString("M/d/yyyy") + "#"
            da_dep = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)

            da_dep.Fill(ds_dep, "Dep_data")

            y = ds_dep.Tables("Dep_data").Rows.Count
            'y = 0
            If (y > 0) Then

                If Dateadded = False Then

                    ReportBalanceSheet.Rows.Add()

                    ReportBalanceSheet.Rows(Rownum).Cells(0).Value = today.ToString("M/d/yyyy")

                    Dateadded = True

                    Rownum = Rownum + 1

                End If

                For k = 0 To y - 1

                    Dim j As Integer

                    ReportBalanceSheet.Rows.Add()

                    j = ds_dep.Tables("Dep_data").Rows(k).Item(0)

                    sql = "SELECT * FROM Partners WHERE PID = " + j.ToString

                    da_part = New OleDb.OleDbDataAdapter(sql, PostDbase_Conn)
                    da_part.Fill(ds_part, "Part_data")

                    ReportBalanceSheet.Rows(Rownum).Cells(2).Value = ds_part.Tables("Part_data").Rows(k).Item(1)

                    If ds_dep.Tables("Dep_data").Rows(k).Item(3) = "Cr" Then

                        ReportBalanceSheet.Rows(Rownum).Cells(1).Value = ds_dep.Tables("Dep_data").Rows(k).Item(1)

                        Crebit_total = Crebit_total + ReportBalanceSheet.Rows(Rownum).Cells(1).Value

                    Else
                        ReportBalanceSheet.Rows(Rownum).Cells(3).Value = ds_dep.Tables("Dep_data").Rows(k).Item(1)

                        Debit_total = Debit_total + ReportBalanceSheet.Rows(Rownum).Cells(3).Value

                    End If

                    Rownum = Rownum + 1

                Next

            End If

            'If False Then

            If Dateadded = True Then

                ReportBalanceSheet.Rows.Add()

                ReportBalanceSheet.Rows(Rownum).Cells(2).Value = "Balance"
                ReportBalanceSheet.Rows(Rownum).Cells(2).Style.ForeColor = Color.Red
                'ReportBalanceSheet.Rows(Rownum).Cells(2).Style.Font = New Font(ReportBalanceSheet.Font, FontStyle.Bold)
                If Crebit_total > Debit_total Then

                    ReportBalanceSheet.Rows(Rownum).Cells(1).Style.ForeColor = Color.Red
                    'ReportBalanceSheet.Rows(Rownum).Cells(1).Style.Font = New Font(ReportBalanceSheet.Font, FontStyle.Bold)
                    ReportBalanceSheet.Rows(Rownum).Cells(1).Value = Crebit_total - Debit_total

                ElseIf Debit_total > Crebit_total Then

                    ReportBalanceSheet.Rows(Rownum).Cells(3).Value = Debit_total - Crebit_total
                    ReportBalanceSheet.Rows(Rownum).Cells(3).Style.ForeColor = Color.Red
                    'ReportBalanceSheet.Rows(Rownum).Cells(3).Style.Font = New Font(ReportBalanceSheet.Font, FontStyle.Bold)

                Else

                    ReportBalanceSheet.Rows(Rownum).Cells(3).Value = 0
                    ReportBalanceSheet.Rows(Rownum).Cells(3).Style.ForeColor = Color.Red
                    'ReportBalanceSheet.Rows(Rownum).Cells(3).Style.Font = New Font(ReportBalanceSheet.Font, FontStyle.Bold)
                    ReportBalanceSheet.Rows(Rownum).Cells(1).Value = 0
                    ReportBalanceSheet.Rows(Rownum).Cells(1).Style.ForeColor = Color.Red
                    'ReportBalanceSheet.Rows(Rownum).Cells(1).Style.Font = New Font(ReportBalanceSheet.Font, FontStyle.Bold)

                End If

                Rownum = Rownum + 1

            End If
            'End If

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


        doc.Add(ExportTableDetails(ReportBalanceSheet, BalanceSheetTableWidths))

        doc.Close()
    End Sub

End Class