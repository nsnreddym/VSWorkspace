Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc
Imports System.ComponentModel

Module Globals
    Public CustPath As String
    Public LoanPath As String
    Public PostPath As String
    Public Year_sel As Integer
    Public Menu_selected As Integer

    Public CurrentUser As New User
    Public AppTitle As String

    Public Const NoOfActivities As Integer = 2

    Public DailyReportTableWidths As Single() = New Single(36) {}
    Public LoanSummaryTableWidths As Single() = New Single(6) {}
    Public DailySummaryTableWidths As Single() = New Single(3) {}
    Public ExpensesSummaryTableWidths As Single() = New Single(4) {}
    Public DepositsSummaryTableWidths As Single() = New Single(5) {}
    Public BalanceSheetTableWidths As Single() = New Single(5) {}


    Public Function InitializeTableWidths()

        For i = 1 To 36

            DailyReportTableWidths(i) = 1.0F

        Next

        DailyReportTableWidths(2) = 6.0F
        DailyReportTableWidths(3) = 2.5F
        DailyReportTableWidths(4) = 1.5F

        DailyReportTableWidths(0) = 800.0F
        DailySummaryTableWidths(0) = 200.0F
        ExpensesSummaryTableWidths(0) = 300.0F
        DepositsSummaryTableWidths(0) = 400.0F
        LoanSummaryTableWidths(0) = 400.0F
        BalanceSheetTableWidths(0) = 300.0F

        DailySummaryTableWidths(1) = 3.0F
        DailySummaryTableWidths(2) = 2.5F

        ExpensesSummaryTableWidths(1) = 3.0F
        ExpensesSummaryTableWidths(2) = 6.5F
        ExpensesSummaryTableWidths(3) = 2.5F

        DepositsSummaryTableWidths(1) = 3.0F
        DepositsSummaryTableWidths(2) = 6.5F
        DepositsSummaryTableWidths(3) = 2.5F
        DepositsSummaryTableWidths(4) = 2.5F

        LoanSummaryTableWidths(1) = 3.0F
        LoanSummaryTableWidths(2) = 1.5F
        LoanSummaryTableWidths(3) = 6.5F
        LoanSummaryTableWidths(4) = 2.5F
        LoanSummaryTableWidths(5) = 2.5F

        BalanceSheetTableWidths(1) = 3.0F
        BalanceSheetTableWidths(2) = 2.5F
        BalanceSheetTableWidths(3) = 6.5F
        BalanceSheetTableWidths(4) = 2.5F


    End Function

    Enum ACTIVITY_ID

        ACT_PATHS = 0
        ACT_USER
        ACT_CUST
        ACT_LOAN
        ACT_DAILYPOSTING
        ACT_BULKPOSTING
        ACT_EXPENSES
        ACT_BALANCESHEET
        ACT_YEARREPORT
        ACT_PARTNER
        ACT_TRANSACTION
        ACT_GENERALREPORT

    End Enum

    Enum LOAN_STATUS_FLAGS

        LnNew = 0
        LnOpen
        LnClose

    End Enum

    Enum EMI_PAYMODE_FLAGS

        EMIDaily = 0
        EMIWeekly
        EMIMonthly
        EMIYearly


    End Enum

    Enum MENU_ENUM

        NO_OPTION = 1
        SET_PATH_OPTION
        LOGIN_OPTION
        ADD_USER_OPTION
        EDIT_USER_OPTION

        CUST_NEW_OPTION
        CUST_VIEW_OPTION

        REPORTDAILY_OPTION
        REPORTBALANCE_OPTION
        REPORTGENERAL_OPTION

        LOAN_NEW_OPTION
        LOAN_VIEW_OPTION

        POSTINGDAILY_OPTION
        POSTINGBULK_OPTION

        EXPENSESADD_OPTION


        REPORTPOSTING_OPTION

        REPORTSTATUS_OPTION
        REPORTYEARLY_OPTION
        PARTNERADD_OPTION
        PARTNERVIEW_OPTION
        DEPOSITADD_OPTION
        DEPOSITVIEW_OPTION

    End Enum

    Public Function ExportTableDetails(DataTable As DevComponents.DotNetBar.Controls.DataGridViewX, WidthTable As Single())

        Dim PdfTable As New PdfPTable(DataTable.ColumnCount)
        Dim PdfPCell As PdfPCell = Nothing
        Dim widths As Single() = New Single(DataTable.ColumnCount - 1) {}

        Dim font12BoldRed As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8.0F, iTextSharp.text.Font.UNDERLINE Or iTextSharp.text.Font.BOLDITALIC, BaseColor.RED)
        Dim font12Bold As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8.0F, iTextSharp.text.Font.BOLD, BaseColor.BLACK)
        Dim font12Normal As New iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 8.0F, iTextSharp.text.Font.NORMAL, BaseColor.BLACK)

        PdfTable.TotalWidth = 0.0F
        PdfTable.LockedWidth = True
        PdfTable.HorizontalAlignment = 0
        PdfTable.SpacingBefore = 2.0F
        PdfTable.HeaderRows = 1

        Dim Colnum As Integer
        Dim rownum As Integer

        For Colnum = 0 To DataTable.ColumnCount - 1

            PdfPCell = New PdfPCell(New Phrase(New Chunk(DataTable.Columns(Colnum).HeaderText.ToString, font12Bold)))
            PdfPCell.HorizontalAlignment = PdfPCell.ALIGN_CENTER
            PdfTable.AddCell(PdfPCell)

            widths(Colnum) = WidthTable(Colnum + 1)

        Next

        PdfTable.TotalWidth = WidthTable(0)

        PdfTable.SetWidths(widths)

        PdfTable.LockedWidth = True



        For rownum = 0 To DataTable.Rows.Count - 1

            For Colnum = 0 To DataTable.ColumnCount - 1

                Try

                    PdfPCell = New PdfPCell(New Phrase(DataTable.Rows(rownum).Cells(Colnum).Value.ToString(), font12Normal))

                Catch

                    PdfPCell = New PdfPCell(New Phrase(" ", font12Normal))

                End Try

                PdfPCell.HorizontalAlignment = DataTable.Columns(Colnum).DefaultCellStyle.Alignment

                PdfTable.AddCell(PdfPCell)
            Next
        Next

        Return PdfTable

    End Function

End Module
