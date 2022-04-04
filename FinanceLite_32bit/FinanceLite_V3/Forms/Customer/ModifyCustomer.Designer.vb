<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class ModifyCustomer
    'Inherits System.Windows.Forms.Form
    Inherits DevComponents.DotNetBar.Office2007Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.TabControl1 = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.CustName_Search = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.NameList = New System.Windows.Forms.ComboBox()
        Me.CustID_View = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.Cancel_edit = New DevComponents.DotNetBar.ButtonX()
        Me.CustUpdate = New DevComponents.DotNetBar.ButtonX()
        Me.CustDate = New System.Windows.Forms.DateTimePicker()
        Me.CustPhone_Edit = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.CustAddress_Edit = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CustName_Edit = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX9 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX10 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX11 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX12 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX13 = New DevComponents.DotNetBar.LabelX()
        Me.Search_Edit = New DevComponents.DotNetBar.ButtonX()
        Me.Bar1 = New DevComponents.DotNetBar.Bar()
        Me.LoanID_Search = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX8 = New DevComponents.DotNetBar.LabelX()
        Me.CustID_Search = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX7 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.EditCustTabItem = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.CustID = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CustAddCancelButton = New DevComponents.DotNetBar.ButtonX()
        Me.CustMoreButton = New DevComponents.DotNetBar.ButtonX()
        Me.CustAddButton = New DevComponents.DotNetBar.ButtonX()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.CustPhone = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.CustAddress = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.CustName = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.AddCustTabItem = New DevComponents.DotNetBar.TabItem(Me.components)
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControlPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'TabControl1
        '
        Me.TabControl1.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.TabControl1.CanReorderTabs = True
        Me.TabControl1.Controls.Add(Me.TabControlPanel1)
        Me.TabControl1.Controls.Add(Me.TabControlPanel2)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Location = New System.Drawing.Point(0, 0)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.TabControl1.SelectedTabIndex = 1
        Me.TabControl1.Size = New System.Drawing.Size(714, 498)
        Me.TabControl1.TabIndex = 1
        Me.TabControl1.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.TabControl1.Tabs.Add(Me.AddCustTabItem)
        Me.TabControl1.Tabs.Add(Me.EditCustTabItem)
        Me.TabControl1.Text = "TabControl1"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.CustName_Search)
        Me.TabControlPanel2.Controls.Add(Me.NameList)
        Me.TabControlPanel2.Controls.Add(Me.CustID_View)
        Me.TabControlPanel2.Controls.Add(Me.Cancel_edit)
        Me.TabControlPanel2.Controls.Add(Me.CustUpdate)
        Me.TabControlPanel2.Controls.Add(Me.CustDate)
        Me.TabControlPanel2.Controls.Add(Me.CustPhone_Edit)
        Me.TabControlPanel2.Controls.Add(Me.CustAddress_Edit)
        Me.TabControlPanel2.Controls.Add(Me.CustName_Edit)
        Me.TabControlPanel2.Controls.Add(Me.LabelX9)
        Me.TabControlPanel2.Controls.Add(Me.LabelX10)
        Me.TabControlPanel2.Controls.Add(Me.LabelX11)
        Me.TabControlPanel2.Controls.Add(Me.LabelX12)
        Me.TabControlPanel2.Controls.Add(Me.LabelX13)
        Me.TabControlPanel2.Controls.Add(Me.Search_Edit)
        Me.TabControlPanel2.Controls.Add(Me.Bar1)
        Me.TabControlPanel2.Controls.Add(Me.LoanID_Search)
        Me.TabControlPanel2.Controls.Add(Me.LabelX8)
        Me.TabControlPanel2.Controls.Add(Me.CustID_Search)
        Me.TabControlPanel2.Controls.Add(Me.LabelX7)
        Me.TabControlPanel2.Controls.Add(Me.LabelX6)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(714, 472)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.EditCustTabItem
        '
        'CustName_Search
        '
        '
        '
        '
        Me.CustName_Search.Border.Class = ""
        Me.CustName_Search.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustName_Search.Location = New System.Drawing.Point(108, 21)
        Me.CustName_Search.Name = "CustName_Search"
        Me.CustName_Search.Size = New System.Drawing.Size(195, 20)
        Me.CustName_Search.TabIndex = 9
        '
        'NameList
        '
        Me.NameList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest
        Me.NameList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.NameList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple
        Me.NameList.FormattingEnabled = True
        Me.NameList.Location = New System.Drawing.Point(108, 21)
        Me.NameList.MaxDropDownItems = 2
        Me.NameList.Name = "NameList"
        Me.NameList.Size = New System.Drawing.Size(195, 112)
        Me.NameList.TabIndex = 86
        Me.NameList.Visible = False
        '
        'CustID_View
        '
        '
        '
        '
        Me.CustID_View.Border.Class = "TextBoxBorder"
        Me.CustID_View.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustID_View.Location = New System.Drawing.Point(108, 191)
        Me.CustID_View.Name = "CustID_View"
        Me.CustID_View.Size = New System.Drawing.Size(104, 20)
        Me.CustID_View.TabIndex = 50
        '
        'Cancel_edit
        '
        Me.Cancel_edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Cancel_edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Cancel_edit.Location = New System.Drawing.Point(338, 390)
        Me.Cancel_edit.Name = "Cancel_edit"
        Me.Cancel_edit.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cancel_edit.TabIndex = 49
        Me.Cancel_edit.Text = "Cancel"
        '
        'CustUpdate
        '
        Me.CustUpdate.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CustUpdate.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CustUpdate.Location = New System.Drawing.Point(183, 390)
        Me.CustUpdate.Name = "CustUpdate"
        Me.CustUpdate.Size = New System.Drawing.Size(75, 23)
        Me.CustUpdate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CustUpdate.TabIndex = 47
        Me.CustUpdate.Text = "Update"
        '
        'CustDate
        '
        Me.CustDate.CustomFormat = "MM/dd/yyyy"
        Me.CustDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.CustDate.Location = New System.Drawing.Point(398, 151)
        Me.CustDate.Name = "CustDate"
        Me.CustDate.Size = New System.Drawing.Size(87, 20)
        Me.CustDate.TabIndex = 46
        '
        'CustPhone_Edit
        '
        '
        '
        '
        Me.CustPhone_Edit.BackgroundStyle.Class = "TextBoxBorder"
        Me.CustPhone_Edit.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustPhone_Edit.ButtonClear.Visible = True
        Me.CustPhone_Edit.Location = New System.Drawing.Point(398, 267)
        Me.CustPhone_Edit.Mask = "9990000000"
        Me.CustPhone_Edit.Name = "CustPhone_Edit"
        Me.CustPhone_Edit.Size = New System.Drawing.Size(90, 20)
        Me.CustPhone_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CustPhone_Edit.TabIndex = 45
        Me.CustPhone_Edit.Text = ""
        '
        'CustAddress_Edit
        '
        '
        '
        '
        Me.CustAddress_Edit.Border.Class = "TextBoxBorder"
        Me.CustAddress_Edit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustAddress_Edit.Location = New System.Drawing.Point(108, 267)
        Me.CustAddress_Edit.Multiline = True
        Me.CustAddress_Edit.Name = "CustAddress_Edit"
        Me.CustAddress_Edit.Size = New System.Drawing.Size(195, 100)
        Me.CustAddress_Edit.TabIndex = 44
        '
        'CustName_Edit
        '
        '
        '
        '
        Me.CustName_Edit.Border.Class = "TextBoxBorder"
        Me.CustName_Edit.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustName_Edit.Location = New System.Drawing.Point(108, 227)
        Me.CustName_Edit.Name = "CustName_Edit"
        Me.CustName_Edit.Size = New System.Drawing.Size(195, 20)
        Me.CustName_Edit.TabIndex = 43
        '
        'LabelX9
        '
        Me.LabelX9.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX9.BackgroundStyle.Class = ""
        Me.LabelX9.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX9.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.LabelX9.Location = New System.Drawing.Point(338, 156)
        Me.LabelX9.Name = "LabelX9"
        Me.LabelX9.Size = New System.Drawing.Size(75, 16)
        Me.LabelX9.TabIndex = 42
        Me.LabelX9.Text = "Date"
        '
        'LabelX10
        '
        Me.LabelX10.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX10.BackgroundStyle.Class = ""
        Me.LabelX10.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX10.Location = New System.Drawing.Point(338, 271)
        Me.LabelX10.Name = "LabelX10"
        Me.LabelX10.Size = New System.Drawing.Size(75, 16)
        Me.LabelX10.TabIndex = 41
        Me.LabelX10.Text = "Phone"
        '
        'LabelX11
        '
        Me.LabelX11.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX11.BackgroundStyle.Class = ""
        Me.LabelX11.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX11.Location = New System.Drawing.Point(48, 271)
        Me.LabelX11.Name = "LabelX11"
        Me.LabelX11.Size = New System.Drawing.Size(75, 16)
        Me.LabelX11.TabIndex = 40
        Me.LabelX11.Text = "Address"
        '
        'LabelX12
        '
        Me.LabelX12.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX12.BackgroundStyle.Class = ""
        Me.LabelX12.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX12.Location = New System.Drawing.Point(48, 231)
        Me.LabelX12.Name = "LabelX12"
        Me.LabelX12.Size = New System.Drawing.Size(75, 16)
        Me.LabelX12.TabIndex = 39
        Me.LabelX12.Text = "Name"
        '
        'LabelX13
        '
        Me.LabelX13.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX13.BackgroundStyle.Class = ""
        Me.LabelX13.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX13.Location = New System.Drawing.Point(48, 191)
        Me.LabelX13.Name = "LabelX13"
        Me.LabelX13.Size = New System.Drawing.Size(75, 16)
        Me.LabelX13.TabIndex = 38
        Me.LabelX13.Text = "Cust ID"
        '
        'Search_Edit
        '
        Me.Search_Edit.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Search_Edit.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Search_Edit.Location = New System.Drawing.Point(108, 100)
        Me.Search_Edit.Name = "Search_Edit"
        Me.Search_Edit.Size = New System.Drawing.Size(75, 23)
        Me.Search_Edit.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Search_Edit.TabIndex = 37
        Me.Search_Edit.Text = "Search"
        '
        'Bar1
        '
        Me.Bar1.AntiAlias = True
        Me.Bar1.DockSide = DevComponents.DotNetBar.eDockSide.Document
        Me.Bar1.Location = New System.Drawing.Point(48, 138)
        Me.Bar1.Name = "Bar1"
        Me.Bar1.Size = New System.Drawing.Size(524, 2)
        Me.Bar1.Stretch = True
        Me.Bar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Bar1.TabIndex = 36
        Me.Bar1.TabStop = False
        Me.Bar1.Text = "Bar1"
        '
        'LoanID_Search
        '
        '
        '
        '
        Me.LoanID_Search.Border.Class = "TextBoxBorder"
        Me.LoanID_Search.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LoanID_Search.Location = New System.Drawing.Point(307, 60)
        Me.LoanID_Search.Name = "LoanID_Search"
        Me.LoanID_Search.Size = New System.Drawing.Size(104, 20)
        Me.LoanID_Search.TabIndex = 35
        '
        'LabelX8
        '
        Me.LabelX8.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX8.BackgroundStyle.Class = ""
        Me.LabelX8.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX8.Location = New System.Drawing.Point(247, 64)
        Me.LabelX8.Name = "LabelX8"
        Me.LabelX8.Size = New System.Drawing.Size(75, 16)
        Me.LabelX8.TabIndex = 34
        Me.LabelX8.Text = "Loan ID"
        '
        'CustID_Search
        '
        '
        '
        '
        Me.CustID_Search.Border.Class = "TextBoxBorder"
        Me.CustID_Search.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustID_Search.Location = New System.Drawing.Point(108, 60)
        Me.CustID_Search.Name = "CustID_Search"
        Me.CustID_Search.Size = New System.Drawing.Size(104, 20)
        Me.CustID_Search.TabIndex = 33
        '
        'LabelX7
        '
        Me.LabelX7.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX7.BackgroundStyle.Class = ""
        Me.LabelX7.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX7.Location = New System.Drawing.Point(48, 64)
        Me.LabelX7.Name = "LabelX7"
        Me.LabelX7.Size = New System.Drawing.Size(75, 16)
        Me.LabelX7.TabIndex = 32
        Me.LabelX7.Text = "Cust ID"
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.Class = ""
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(48, 25)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(75, 16)
        Me.LabelX6.TabIndex = 8
        Me.LabelX6.Text = "Name"
        '
        'EditCustTabItem
        '
        Me.EditCustTabItem.AttachedControl = Me.TabControlPanel2
        Me.EditCustTabItem.Name = "EditCustTabItem"
        Me.EditCustTabItem.Text = "Edit Customer"
        Me.EditCustTabItem.Visible = False
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.CustID)
        Me.TabControlPanel1.Controls.Add(Me.CustAddCancelButton)
        Me.TabControlPanel1.Controls.Add(Me.CustMoreButton)
        Me.TabControlPanel1.Controls.Add(Me.CustAddButton)
        Me.TabControlPanel1.Controls.Add(Me.DateTimePicker1)
        Me.TabControlPanel1.Controls.Add(Me.CustPhone)
        Me.TabControlPanel1.Controls.Add(Me.CustAddress)
        Me.TabControlPanel1.Controls.Add(Me.CustName)
        Me.TabControlPanel1.Controls.Add(Me.LabelX5)
        Me.TabControlPanel1.Controls.Add(Me.LabelX4)
        Me.TabControlPanel1.Controls.Add(Me.LabelX3)
        Me.TabControlPanel1.Controls.Add(Me.LabelX2)
        Me.TabControlPanel1.Controls.Add(Me.LabelX1)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(714, 472)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.AddCustTabItem
        '
        'CustID
        '
        '
        '
        '
        Me.CustID.Border.Class = "TextBoxBorder"
        Me.CustID.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustID.Enabled = False
        Me.CustID.Location = New System.Drawing.Point(120, 46)
        Me.CustID.Name = "CustID"
        Me.CustID.Size = New System.Drawing.Size(104, 20)
        Me.CustID.TabIndex = 31
        '
        'CustAddCancelButton
        '
        Me.CustAddCancelButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CustAddCancelButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CustAddCancelButton.Location = New System.Drawing.Point(350, 249)
        Me.CustAddCancelButton.Name = "CustAddCancelButton"
        Me.CustAddCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CustAddCancelButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CustAddCancelButton.TabIndex = 30
        Me.CustAddCancelButton.Text = "Cancel"
        '
        'CustMoreButton
        '
        Me.CustMoreButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CustMoreButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CustMoreButton.Location = New System.Drawing.Point(240, 249)
        Me.CustMoreButton.Name = "CustMoreButton"
        Me.CustMoreButton.Size = New System.Drawing.Size(75, 23)
        Me.CustMoreButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CustMoreButton.TabIndex = 29
        Me.CustMoreButton.Text = "More"
        '
        'CustAddButton
        '
        Me.CustAddButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CustAddButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CustAddButton.Location = New System.Drawing.Point(120, 249)
        Me.CustAddButton.Name = "CustAddButton"
        Me.CustAddButton.Size = New System.Drawing.Size(75, 23)
        Me.CustAddButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CustAddButton.TabIndex = 28
        Me.CustAddButton.Text = "Add"
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.CustomFormat = "MM/dd/yyyy"
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DateTimePicker1.Location = New System.Drawing.Point(410, 10)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(87, 20)
        Me.DateTimePicker1.TabIndex = 27
        '
        'CustPhone
        '
        '
        '
        '
        Me.CustPhone.BackgroundStyle.Class = "TextBoxBorder"
        Me.CustPhone.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustPhone.ButtonClear.Visible = True
        Me.CustPhone.Location = New System.Drawing.Point(410, 126)
        Me.CustPhone.Mask = "9990000000"
        Me.CustPhone.Name = "CustPhone"
        Me.CustPhone.Size = New System.Drawing.Size(90, 20)
        Me.CustPhone.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CustPhone.TabIndex = 9
        Me.CustPhone.Text = ""
        '
        'CustAddress
        '
        '
        '
        '
        Me.CustAddress.Border.Class = "TextBoxBorder"
        Me.CustAddress.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustAddress.Location = New System.Drawing.Point(120, 126)
        Me.CustAddress.Multiline = True
        Me.CustAddress.Name = "CustAddress"
        Me.CustAddress.Size = New System.Drawing.Size(195, 100)
        Me.CustAddress.TabIndex = 8
        '
        'CustName
        '
        '
        '
        '
        Me.CustName.Border.Class = "TextBoxBorder"
        Me.CustName.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.CustName.Location = New System.Drawing.Point(120, 86)
        Me.CustName.Name = "CustName"
        Me.CustName.Size = New System.Drawing.Size(195, 20)
        Me.CustName.TabIndex = 7
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.Class = ""
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.ImagePosition = DevComponents.DotNetBar.eImagePosition.Top
        Me.LabelX5.Location = New System.Drawing.Point(350, 15)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(75, 16)
        Me.LabelX5.TabIndex = 5
        Me.LabelX5.Text = "Date"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.Class = ""
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(350, 130)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(75, 16)
        Me.LabelX4.TabIndex = 4
        Me.LabelX4.Text = "Phone"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(60, 130)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(75, 16)
        Me.LabelX3.TabIndex = 3
        Me.LabelX3.Text = "Address"
        '
        'LabelX2
        '
        Me.LabelX2.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(60, 90)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(75, 16)
        Me.LabelX2.TabIndex = 2
        Me.LabelX2.Text = "Name"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(60, 50)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(75, 16)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Cust ID"
        '
        'AddCustTabItem
        '
        Me.AddCustTabItem.AttachedControl = Me.TabControlPanel1
        Me.AddCustTabItem.Name = "AddCustTabItem"
        Me.AddCustTabItem.Text = "Add Customer"
        Me.AddCustTabItem.Visible = False
        '
        'ModifyCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(714, 498)
        Me.Controls.Add(Me.TabControl1)
        Me.DoubleBuffered = True
        Me.Name = "ModifyCustomer"
        Me.Text = "ModifyCustomer"
        CType(Me.TabControl1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.TabControlPanel2.ResumeLayout(False)
        CType(Me.Bar1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControlPanel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TabControl1 As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents AddCustTabItem As DevComponents.DotNetBar.TabItem
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents EditCustTabItem As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CustPhone As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents CustAddress As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CustName As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents CustAddButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CustAddCancelButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CustMoreButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CustID As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LoanID_Search As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX8 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CustID_Search As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX7 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CustName_Search As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents Search_Edit As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Bar1 As DevComponents.DotNetBar.Bar
    Friend WithEvents CustID_View As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents Cancel_edit As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CustUpdate As DevComponents.DotNetBar.ButtonX
    Friend WithEvents CustDate As DateTimePicker
    Friend WithEvents CustPhone_Edit As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
    Friend WithEvents CustAddress_Edit As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents CustName_Edit As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX9 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX10 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX11 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX12 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX13 As DevComponents.DotNetBar.LabelX
    Friend WithEvents NameList As ComboBox
End Class
