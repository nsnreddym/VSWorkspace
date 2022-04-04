<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class ModifyUser
    'Inherits System.Windows.Forms.Form
    Inherits DevComponents.DotNetBar.Office2007Form


    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
        Me.UserTabControl = New DevComponents.DotNetBar.TabControl()
        Me.TabControlPanel1 = New DevComponents.DotNetBar.TabControlPanel()
        Me.TxtPhNo = New DevComponents.DotNetBar.Controls.MaskedTextBoxAdv()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.ButtonCancel = New DevComponents.DotNetBar.ButtonX()
        Me.NextButton = New DevComponents.DotNetBar.ButtonX()
        Me.TxtID = New System.Windows.Forms.TextBox()
        Me.TxtPasswd = New System.Windows.Forms.TextBox()
        Me.TxtLoginID = New System.Windows.Forms.TextBox()
        Me.TxtFullName = New System.Windows.Forms.TextBox()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.IDSel = New DevComponents.DotNetBar.Controls.ComboBoxEx()
        Me.UserTab = New DevComponents.DotNetBar.TabItem(Me.components)
        Me.TabControlPanel2 = New DevComponents.DotNetBar.TabControlPanel()
        Me.Perm_table = New System.Windows.Forms.DataGridView()
        Me.ActivityCode = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Activity = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.P_Read = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.P_Write = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.P_Exec = New DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn()
        Me.PermTab = New DevComponents.DotNetBar.TabItem(Me.components)
        CType(Me.UserTabControl, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.UserTabControl.SuspendLayout()
        Me.TabControlPanel1.SuspendLayout()
        Me.TabControlPanel2.SuspendLayout()
        CType(Me.Perm_table, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UserTabControl
        '
        Me.UserTabControl.BackColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.UserTabControl.CanReorderTabs = True
        Me.UserTabControl.Controls.Add(Me.TabControlPanel1)
        Me.UserTabControl.Controls.Add(Me.TabControlPanel2)
        Me.UserTabControl.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UserTabControl.Location = New System.Drawing.Point(0, 0)
        Me.UserTabControl.Name = "UserTabControl"
        Me.UserTabControl.SelectedTabFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold)
        Me.UserTabControl.SelectedTabIndex = 0
        Me.UserTabControl.Size = New System.Drawing.Size(647, 315)
        Me.UserTabControl.TabIndex = 0
        Me.UserTabControl.TabLayoutType = DevComponents.DotNetBar.eTabLayoutType.FixedWithNavigationBox
        Me.UserTabControl.Tabs.Add(Me.UserTab)
        Me.UserTabControl.Tabs.Add(Me.PermTab)
        Me.UserTabControl.Text = "TabControl1"
        '
        'TabControlPanel1
        '
        Me.TabControlPanel1.Controls.Add(Me.TxtPhNo)
        Me.TabControlPanel1.Controls.Add(Me.LabelX6)
        Me.TabControlPanel1.Controls.Add(Me.ButtonCancel)
        Me.TabControlPanel1.Controls.Add(Me.NextButton)
        Me.TabControlPanel1.Controls.Add(Me.TxtID)
        Me.TabControlPanel1.Controls.Add(Me.TxtPasswd)
        Me.TabControlPanel1.Controls.Add(Me.TxtLoginID)
        Me.TabControlPanel1.Controls.Add(Me.TxtFullName)
        Me.TabControlPanel1.Controls.Add(Me.LabelX5)
        Me.TabControlPanel1.Controls.Add(Me.LabelX4)
        Me.TabControlPanel1.Controls.Add(Me.LabelX3)
        Me.TabControlPanel1.Controls.Add(Me.LabelX1)
        Me.TabControlPanel1.Controls.Add(Me.IDSel)
        Me.TabControlPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel1.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel1.Name = "TabControlPanel1"
        Me.TabControlPanel1.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel1.Size = New System.Drawing.Size(647, 289)
        Me.TabControlPanel1.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel1.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel1.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel1.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel1.Style.GradientAngle = 90
        Me.TabControlPanel1.TabIndex = 1
        Me.TabControlPanel1.TabItem = Me.UserTab
        '
        'TxtPhNo
        '
        '
        '
        '
        Me.TxtPhNo.BackgroundStyle.Class = "TextBoxBorder"
        Me.TxtPhNo.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPhNo.ButtonClear.Visible = True
        Me.TxtPhNo.Location = New System.Drawing.Point(160, 73)
        Me.TxtPhNo.Mask = "9990000000"
        Me.TxtPhNo.Name = "TxtPhNo"
        Me.TxtPhNo.Size = New System.Drawing.Size(90, 20)
        Me.TxtPhNo.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.TxtPhNo.TabIndex = 29
        Me.TxtPhNo.Text = ""
        '
        'LabelX6
        '
        Me.LabelX6.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX6.BackgroundStyle.Class = ""
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(427, 35)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.SingleLineColor = System.Drawing.Color.FromArgb(CType(CType(207, Byte), Integer), CType(CType(221, Byte), Integer), CType(CType(238, Byte), Integer))
        Me.LabelX6.Size = New System.Drawing.Size(28, 23)
        Me.LabelX6.TabIndex = 27
        Me.LabelX6.Text = "ID"
        '
        'ButtonCancel
        '
        Me.ButtonCancel.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.ButtonCancel.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.ButtonCancel.Location = New System.Drawing.Point(314, 214)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.ButtonCancel.TabIndex = 26
        Me.ButtonCancel.Text = "Cancel"
        '
        'NextButton
        '
        Me.NextButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.NextButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.NextButton.Location = New System.Drawing.Point(160, 214)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(75, 23)
        Me.NextButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.NextButton.TabIndex = 25
        Me.NextButton.Text = "Next"
        '
        'TxtID
        '
        Me.TxtID.Enabled = False
        Me.TxtID.Location = New System.Drawing.Point(461, 37)
        Me.TxtID.Name = "TxtID"
        Me.TxtID.Size = New System.Drawing.Size(89, 20)
        Me.TxtID.TabIndex = 24
        '
        'TxtPasswd
        '
        Me.TxtPasswd.Location = New System.Drawing.Point(159, 161)
        Me.TxtPasswd.Name = "TxtPasswd"
        Me.TxtPasswd.Size = New System.Drawing.Size(181, 20)
        Me.TxtPasswd.TabIndex = 22
        '
        'TxtLoginID
        '
        Me.TxtLoginID.Location = New System.Drawing.Point(160, 116)
        Me.TxtLoginID.Name = "TxtLoginID"
        Me.TxtLoginID.Size = New System.Drawing.Size(181, 20)
        Me.TxtLoginID.TabIndex = 21
        '
        'TxtFullName
        '
        Me.TxtFullName.Location = New System.Drawing.Point(160, 36)
        Me.TxtFullName.Name = "TxtFullName"
        Me.TxtFullName.Size = New System.Drawing.Size(181, 20)
        Me.TxtFullName.TabIndex = 20
        '
        'LabelX5
        '
        Me.LabelX5.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX5.BackgroundStyle.Class = ""
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(91, 73)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(62, 23)
        Me.LabelX5.TabIndex = 19
        Me.LabelX5.Text = "Ph No"
        '
        'LabelX4
        '
        Me.LabelX4.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX4.BackgroundStyle.Class = ""
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(91, 159)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(62, 23)
        Me.LabelX4.TabIndex = 18
        Me.LabelX4.Text = "Password"
        '
        'LabelX3
        '
        Me.LabelX3.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(91, 113)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(62, 23)
        Me.LabelX3.TabIndex = 17
        Me.LabelX3.Text = "Login ID"
        '
        'LabelX1
        '
        Me.LabelX1.BackColor = System.Drawing.Color.Transparent
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(91, 34)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(62, 23)
        Me.LabelX1.TabIndex = 15
        Me.LabelX1.Text = "Full Name"
        '
        'IDSel
        '
        Me.IDSel.DisplayMember = "Text"
        Me.IDSel.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.IDSel.FormattingEnabled = True
        Me.IDSel.ItemHeight = 14
        Me.IDSel.Location = New System.Drawing.Point(461, 37)
        Me.IDSel.Name = "IDSel"
        Me.IDSel.Size = New System.Drawing.Size(105, 20)
        Me.IDSel.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.IDSel.TabIndex = 28
        Me.IDSel.Visible = False
        '
        'UserTab
        '
        Me.UserTab.AttachedControl = Me.TabControlPanel1
        Me.UserTab.Name = "UserTab"
        Me.UserTab.Text = "User"
        '
        'TabControlPanel2
        '
        Me.TabControlPanel2.Controls.Add(Me.Perm_table)
        Me.TabControlPanel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControlPanel2.Location = New System.Drawing.Point(0, 26)
        Me.TabControlPanel2.Name = "TabControlPanel2"
        Me.TabControlPanel2.Padding = New System.Windows.Forms.Padding(1)
        Me.TabControlPanel2.Size = New System.Drawing.Size(647, 289)
        Me.TabControlPanel2.Style.BackColor1.Color = System.Drawing.Color.FromArgb(CType(CType(142, Byte), Integer), CType(CType(179, Byte), Integer), CType(CType(231, Byte), Integer))
        Me.TabControlPanel2.Style.BackColor2.Color = System.Drawing.Color.FromArgb(CType(CType(223, Byte), Integer), CType(CType(237, Byte), Integer), CType(CType(254, Byte), Integer))
        Me.TabControlPanel2.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine
        Me.TabControlPanel2.Style.BorderColor.Color = System.Drawing.Color.FromArgb(CType(CType(59, Byte), Integer), CType(CType(97, Byte), Integer), CType(CType(156, Byte), Integer))
        Me.TabControlPanel2.Style.BorderSide = CType(((DevComponents.DotNetBar.eBorderSide.Left Or DevComponents.DotNetBar.eBorderSide.Right) _
            Or DevComponents.DotNetBar.eBorderSide.Bottom), DevComponents.DotNetBar.eBorderSide)
        Me.TabControlPanel2.Style.GradientAngle = 90
        Me.TabControlPanel2.TabIndex = 2
        Me.TabControlPanel2.TabItem = Me.PermTab
        '
        'Perm_table
        '
        Me.Perm_table.AllowUserToAddRows = False
        Me.Perm_table.AllowUserToDeleteRows = False
        Me.Perm_table.AllowUserToResizeColumns = False
        Me.Perm_table.AllowUserToResizeRows = False
        Me.Perm_table.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.Perm_table.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Perm_table.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ActivityCode, Me.Activity, Me.P_Read, Me.P_Write, Me.P_Exec})
        Me.Perm_table.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Perm_table.Location = New System.Drawing.Point(1, 1)
        Me.Perm_table.Name = "Perm_table"
        Me.Perm_table.RowHeadersVisible = False
        Me.Perm_table.Size = New System.Drawing.Size(645, 287)
        Me.Perm_table.TabIndex = 2
        '
        'ActivityCode
        '
        Me.ActivityCode.Frozen = True
        Me.ActivityCode.HeaderText = "Activity Code"
        Me.ActivityCode.Name = "ActivityCode"
        Me.ActivityCode.ReadOnly = True
        Me.ActivityCode.Width = 94
        '
        'Activity
        '
        Me.Activity.Frozen = True
        Me.Activity.HeaderText = "Activity"
        Me.Activity.Name = "Activity"
        Me.Activity.ReadOnly = True
        Me.Activity.Width = 66
        '
        'P_Read
        '
        Me.P_Read.Checked = True
        Me.P_Read.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.P_Read.CheckValue = "N"
        Me.P_Read.CheckValueChecked = "1"
        Me.P_Read.CheckValueIndeterminate = "1"
        Me.P_Read.CheckValueUnchecked = "0"
        Me.P_Read.Frozen = True
        Me.P_Read.HeaderText = "Read"
        Me.P_Read.Name = "P_Read"
        Me.P_Read.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.P_Read.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.P_Read.Width = 58
        '
        'P_Write
        '
        Me.P_Write.Checked = True
        Me.P_Write.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.P_Write.CheckValue = "N"
        Me.P_Write.CheckValueChecked = "1"
        Me.P_Write.CheckValueIndeterminate = "1"
        Me.P_Write.CheckValueUnchecked = "0"
        Me.P_Write.Frozen = True
        Me.P_Write.HeaderText = "Write"
        Me.P_Write.Name = "P_Write"
        Me.P_Write.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.P_Write.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.P_Write.Width = 57
        '
        'P_Exec
        '
        Me.P_Exec.Checked = True
        Me.P_Exec.CheckState = System.Windows.Forms.CheckState.Indeterminate
        Me.P_Exec.CheckValue = "N"
        Me.P_Exec.CheckValueChecked = "1"
        Me.P_Exec.CheckValueIndeterminate = "1"
        Me.P_Exec.CheckValueUnchecked = "0"
        Me.P_Exec.Frozen = True
        Me.P_Exec.HeaderText = "Exec"
        Me.P_Exec.Name = "P_Exec"
        Me.P_Exec.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.P_Exec.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic
        Me.P_Exec.Width = 56
        '
        'PermTab
        '
        Me.PermTab.AttachedControl = Me.TabControlPanel2
        Me.PermTab.Name = "PermTab"
        Me.PermTab.Text = "Permissions"
        '
        'ModifyUser
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 315)
        Me.Controls.Add(Me.UserTabControl)
        Me.DoubleBuffered = True
        Me.Name = "ModifyUser"
        Me.Text = "AddUser"
        CType(Me.UserTabControl, System.ComponentModel.ISupportInitialize).EndInit()
        Me.UserTabControl.ResumeLayout(False)
        Me.TabControlPanel1.ResumeLayout(False)
        Me.TabControlPanel1.PerformLayout()
        Me.TabControlPanel2.ResumeLayout(False)
        CType(Me.Perm_table, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents UserTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtFullName As TextBox
    Friend WithEvents TxtLoginID As TextBox
    Friend WithEvents TxtPasswd As TextBox
    Friend WithEvents TxtID As TextBox
    Friend WithEvents NextButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents ButtonCancel As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TabControlPanel1 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents UserTabControl As DevComponents.DotNetBar.TabControl
    Friend WithEvents TabControlPanel2 As DevComponents.DotNetBar.TabControlPanel
    Friend WithEvents PermTab As DevComponents.DotNetBar.TabItem
    Friend WithEvents Perm_table As DataGridView
    Friend WithEvents IDSel As DevComponents.DotNetBar.Controls.ComboBoxEx
    Friend WithEvents P_Exec As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents P_Write As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents P_Read As DevComponents.DotNetBar.Controls.DataGridViewCheckBoxXColumn
    Friend WithEvents Activity As DataGridViewTextBoxColumn
    Friend WithEvents ActivityCode As DataGridViewTextBoxColumn
    Friend WithEvents TxtPhNo As DevComponents.DotNetBar.Controls.MaskedTextBoxAdv
End Class
