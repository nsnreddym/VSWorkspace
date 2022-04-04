Imports System
Imports System.IO
Imports System.Collections

Imports System.Data.SqlClient
Imports iTextSharp
Imports iTextSharp.text.pdf
Imports iTextSharp.text
Imports System.Data.Odbc
Imports System.ComponentModel

Public Class MainForm
    Public Property GeneralR As Object
    '-------------------Home Tab---------------------------
    '-------------------Tools Ribbon Tab---------------------------
    Private Sub MainForm_Load(sender As Object, e As EventArgs) Handles Me.Load

        AppTitle = "FinanceLiteV3"

        Menu_selected = MENU_ENUM.LOGIN_OPTION
        LoginForm1.MdiParent = Me

        HideOrShow_options(False)

        InitializeTableWidths()

        LoginForm1.Show()

        Menu_selected = MENU_ENUM.NO_OPTION

    End Sub

    Private Sub ItemToolsEditPath_Click(sender As Object, e As EventArgs) Handles ItemToolsEditPath.Click

        Menu_selected = MENU_ENUM.SET_PATH_OPTION
        SetPaths.MdiParent = Me
        HideOrShow_options(False)
        SetPaths.Show()

    End Sub

    Private Sub ItemToolLogin_Click(sender As Object, e As EventArgs) Handles ItemToolLogin.Click

        Menu_selected = MENU_ENUM.LOGIN_OPTION
        LoginForm1.MdiParent = Me
        HideOrShow_options(False)
        LoginForm1.Show()

    End Sub

    '-------------------Users Ribbon Tab---------------------------
    Private Sub ItemUsersAdd_Click(sender As Object, e As EventArgs) Handles ItemUsersAdd.Click

        If CurrentUser.Perm_Write(ACTIVITY_ID.ACT_USER) = 1 Then

            ItemUserSave.Enabled = True

        End If

        Menu_selected = MENU_ENUM.ADD_USER_OPTION
        ModifyUser.MdiParent = Me
        HideOrShow_options(False)
        ModifyUser.Show()

    End Sub

    Private Sub ItemUsersPerms_Click(sender As Object, e As EventArgs) Handles ItemUsersPerms.Click

        If CurrentUser.Perm_Write(ACTIVITY_ID.ACT_USER) = 1 Then

            ItemUserSave.Enabled = True

        End If

        Menu_selected = MENU_ENUM.EDIT_USER_OPTION
        ModifyUser.MdiParent = Me
        HideOrShow_options(False)
        ModifyUser.Show()

    End Sub

    Private Sub ItemUserSave_Click_1(sender As Object, e As EventArgs) Handles ItemUserSave.Click
        ModifyUser.SaveUser_Data()

    End Sub

    Public Sub HideOrShow_options(Status As Integer)
        RibbonBar1.Enabled = Status
        RibbonBar2.Enabled = Status
        RibbonBar3.Enabled = Status
        RibbonBar4.Enabled = Status
        RibbonBar5.Enabled = Status
        RibbonBar6.Enabled = Status
        RibbonBar8.Enabled = Status
        RibbonBar9.Enabled = Status
        RibbonBar10.Enabled = Status

    End Sub

    '-------------------Customer Tab---------------------------
    '-------------------Customers Ribbon Tab---------------------------
    Private Sub ItemCustNew_Click(sender As Object, e As EventArgs) Handles ItemCustNew.Click

        Menu_selected = MENU_ENUM.CUST_NEW_OPTION
        HideOrShow_options(False)
        ModifyCustomer.MdiParent = Me
        ModifyCustomer.Show()

    End Sub

    Private Sub ItemCustOpen_Click(sender As Object, e As EventArgs) Handles ItemCustOpen.Click

        Menu_selected = MENU_ENUM.CUST_VIEW_OPTION
        HideOrShow_options(False)
        ModifyCustomer.MdiParent = Me
        ModifyCustomer.Show()


    End Sub

    '-------------------Loan Ribbon Tab---------------------------
    Private Sub ItemLoanNew_Click(sender As Object, e As EventArgs) Handles ItemLoanNew.Click

        Menu_selected = MENU_ENUM.LOAN_NEW_OPTION
        HideOrShow_options(False)
        ModifyLoan.MdiParent = Me
        ModifyLoan.Show()

    End Sub

    Private Sub ItemLoanSearch_Click(sender As Object, e As EventArgs) Handles ItemLoanSearch.Click

        Menu_selected = MENU_ENUM.LOAN_VIEW_OPTION
        HideOrShow_options(False)
        ModifyLoan.MdiParent = Me
        ModifyLoan.Show()


    End Sub

    '-------------------Posting Ribbon Tab--------------------------------
    Private Sub ItemPostDaily_Click(sender As Object, e As EventArgs) Handles ItemPostDaily.Click

        Menu_selected = MENU_ENUM.POSTINGDAILY_OPTION
        HideOrShow_options(False)
        Posting.MdiParent = Me
        Posting.Show()

    End Sub

    Private Sub PostingDateSel_ValueChanged(sender As Object, e As EventArgs) Handles PostingDateSel.ValueChanged

        Select Case Menu_selected

            Case MENU_ENUM.POSTINGDAILY_OPTION

                Posting.DailyPostingDateChanged(PostingDateSel.Value)

            Case MENU_ENUM.EXPENSESADD_OPTION

                Posting.ExpensesAddDateChanged(PostingDateSel.Value)

        End Select

    End Sub

    Private Sub DailyPostingSaveButton_Click(sender As Object, e As EventArgs) Handles DailyPostingSaveButton.Click

        Select Case Menu_selected

            Case MENU_ENUM.POSTINGDAILY_OPTION

                Posting.DailyPostingSaveData(PostingDateSel.Value)

            Case MENU_ENUM.EXPENSESADD_OPTION

                Posting.ExpensesSaveData(PostingDateSel.Value)

        End Select


    End Sub

    Private Sub BulkPostingSaveButton_Click(sender As Object, e As EventArgs) Handles BulkPostingSaveButton.Click

        Select Case Menu_selected

            Case MENU_ENUM.POSTINGBULK_OPTION
                Posting.BulkPostingSaveData()

        End Select

    End Sub




    Private Sub ItemMonthSel_Click(sender As Object, e As EventArgs) Handles ItemMonthSelBulk.Click

        Menu_selected = MENU_ENUM.POSTINGBULK_OPTION
        Posting.viewdata(ItemMonthSelBulk.SelectedIndex)

    End Sub

    Private Sub ItemPostBulk_Click(sender As Object, e As EventArgs) Handles ItemPostBulk.Click

        Menu_selected = MENU_ENUM.POSTINGBULK_OPTION
        HideOrShow_options(False)
        Posting.MdiParent = Me
        Posting.Show()

    End Sub


    Private Sub ItemPostExpadd_Click(sender As Object, e As EventArgs) Handles ItemPostExpadd.Click

        Menu_selected = MENU_ENUM.EXPENSESADD_OPTION
        HideOrShow_options(False)
        Posting.MdiParent = Me
        Posting.Show()

    End Sub


    '-------------------Reports Tab---------------------------
    '-------------------Reports Ribbon Tab---------------------------
    Private Sub ItemRepDaily_Click(sender As Object, e As EventArgs) Handles ItemRepDaily.Click

        Menu_selected = MENU_ENUM.REPORTDAILY_OPTION
        Posting.MdiParent = Me
        HideOrShow_options(False)
        Posting.Show()
        DailyReportControlTab.Visible = True

    End Sub

    '-------------------Export Ribbon Tab---------------------------
    Private Sub ItemExportPDF_Click(sender As Object, e As EventArgs) Handles ItemExportPDF.Click
        Select Case Menu_selected

            Case MENU_ENUM.REPORTDAILY_OPTION
                SaveFileDialog1.ShowDialog()
                If SaveFileDialog1.FileName = "" Then
                    MsgBox("Enter Filename to create PDF")
                    Exit Sub
                Else
                    Posting.BulkPostingTable_export(SaveFileDialog1.FileName)
                    MsgBox("File Created Successfully")
                End If

            Case MENU_ENUM.REPORTGENERAL_OPTION
                SaveFileDialog1.ShowDialog()
                If SaveFileDialog1.FileName = "" Then
                    MsgBox("Enter Filename to create PDF")
                    Exit Sub
                Else
                    GeneralReport.ExportDataToPDFTable(SaveFileDialog1.FileName)
                    MsgBox("File Created Successfully")
                End If


            Case MENU_ENUM.REPORTBALANCE_OPTION
                SaveFileDialog1.ShowDialog()
                If SaveFileDialog1.FileName = "" Then
                    MsgBox("Enter Filename to create PDF")
                    Exit Sub
                Else
                    BalanceReport.ExportDataToPDFTable(SaveFileDialog1.FileName)
                    MsgBox("File Created Successfully")
                End If


        End Select
    End Sub

    Private Sub ItemYearly_Click(sender As Object, e As EventArgs) Handles ItemYearly.Click

    End Sub

    Private Sub ItemGeneral_Click(sender As Object, e As EventArgs) Handles ItemGeneral.Click
        Menu_selected = MENU_ENUM.REPORTGENERAL_OPTION
        HideOrShow_options(False)
        GeneralReport.MdiParent = Me
        GeneralReport.Show()

    End Sub

    Private Sub ItemMonthSelDailyRpt_Click(sender As Object, e As EventArgs) Handles ItemMonthSelDailyRpt.Click
        Menu_selected = MENU_ENUM.REPORTDAILY_OPTION
        Posting.viewdata(ItemMonthSelDailyRpt.SelectedIndex)

    End Sub

    Private Sub ItemBalanceSheet_Click(sender As Object, e As EventArgs) Handles ItemBalanceSheet.Click
        Menu_selected = MENU_ENUM.REPORTBALANCE_OPTION
        HideOrShow_options(False)
        BalanceReport.MdiParent = Me
        BalanceReport.Show()

    End Sub
End Class