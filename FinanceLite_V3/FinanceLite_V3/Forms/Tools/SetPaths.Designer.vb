<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SetPaths
    'Inherits System.Windows.Forms.Form
    Inherits DevComponents.DotNetBar.Office2007RibbonForm

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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.TxtCustDbasePath = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX1 = New DevComponents.DotNetBar.LabelX()
        Me.CustDbasePathButton = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX2 = New DevComponents.DotNetBar.LabelX()
        Me.UpdateButton = New DevComponents.DotNetBar.ButtonX()
        Me.Cancel_Button = New DevComponents.DotNetBar.ButtonX()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.LabelX3 = New DevComponents.DotNetBar.LabelX()
        Me.LoanDbasePathButton = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX4 = New DevComponents.DotNetBar.LabelX()
        Me.TxtLoanDbasePath = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.LabelX5 = New DevComponents.DotNetBar.LabelX()
        Me.PostDbasePathButton = New DevComponents.DotNetBar.ButtonX()
        Me.LabelX6 = New DevComponents.DotNetBar.LabelX()
        Me.TxtPostDbasePath = New DevComponents.DotNetBar.Controls.TextBoxX()
        Me.SuspendLayout()
        '
        'TxtCustDbasePath
        '
        '
        '
        '
        Me.TxtCustDbasePath.Border.Class = "TextBoxBorder"
        Me.TxtCustDbasePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtCustDbasePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtCustDbasePath.Location = New System.Drawing.Point(133, 65)
        Me.TxtCustDbasePath.Name = "TxtCustDbasePath"
        Me.TxtCustDbasePath.Size = New System.Drawing.Size(300, 23)
        Me.TxtCustDbasePath.TabIndex = 0
        '
        'LabelX1
        '
        '
        '
        '
        Me.LabelX1.BackgroundStyle.Class = ""
        Me.LabelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX1.Location = New System.Drawing.Point(97, 64)
        Me.LabelX1.Name = "LabelX1"
        Me.LabelX1.Size = New System.Drawing.Size(30, 23)
        Me.LabelX1.TabIndex = 1
        Me.LabelX1.Text = "Path:"
        '
        'CustDbasePathButton
        '
        Me.CustDbasePathButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.CustDbasePathButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.CustDbasePathButton.Location = New System.Drawing.Point(439, 64)
        Me.CustDbasePathButton.Name = "CustDbasePathButton"
        Me.CustDbasePathButton.Size = New System.Drawing.Size(75, 23)
        Me.CustDbasePathButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.CustDbasePathButton.TabIndex = 2
        Me.CustDbasePathButton.Text = "Browse"
        '
        'LabelX2
        '
        '
        '
        '
        Me.LabelX2.BackgroundStyle.Class = ""
        Me.LabelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX2.Location = New System.Drawing.Point(133, 35)
        Me.LabelX2.Name = "LabelX2"
        Me.LabelX2.Size = New System.Drawing.Size(121, 23)
        Me.LabelX2.TabIndex = 3
        Me.LabelX2.Text = "Customer Database"
        '
        'UpdateButton
        '
        Me.UpdateButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.UpdateButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.UpdateButton.Enabled = False
        Me.UpdateButton.Location = New System.Drawing.Point(331, 232)
        Me.UpdateButton.Name = "UpdateButton"
        Me.UpdateButton.Size = New System.Drawing.Size(75, 23)
        Me.UpdateButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.UpdateButton.TabIndex = 12
        Me.UpdateButton.Text = "Update"
        '
        'Cancel_Button
        '
        Me.Cancel_Button.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.Cancel_Button.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.Cancel_Button.Location = New System.Drawing.Point(439, 232)
        Me.Cancel_Button.Name = "Cancel_Button"
        Me.Cancel_Button.Size = New System.Drawing.Size(75, 23)
        Me.Cancel_Button.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.Cancel_Button.TabIndex = 13
        Me.Cancel_Button.Text = "Cancel"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'LabelX3
        '
        '
        '
        '
        Me.LabelX3.BackgroundStyle.Class = ""
        Me.LabelX3.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX3.Location = New System.Drawing.Point(133, 94)
        Me.LabelX3.Name = "LabelX3"
        Me.LabelX3.Size = New System.Drawing.Size(121, 23)
        Me.LabelX3.TabIndex = 17
        Me.LabelX3.Text = "Loan Database"
        '
        'LoanDbasePathButton
        '
        Me.LoanDbasePathButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.LoanDbasePathButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.LoanDbasePathButton.Location = New System.Drawing.Point(439, 123)
        Me.LoanDbasePathButton.Name = "LoanDbasePathButton"
        Me.LoanDbasePathButton.Size = New System.Drawing.Size(75, 23)
        Me.LoanDbasePathButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.LoanDbasePathButton.TabIndex = 16
        Me.LoanDbasePathButton.Text = "Browse"
        '
        'LabelX4
        '
        '
        '
        '
        Me.LabelX4.BackgroundStyle.Class = ""
        Me.LabelX4.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX4.Location = New System.Drawing.Point(97, 123)
        Me.LabelX4.Name = "LabelX4"
        Me.LabelX4.Size = New System.Drawing.Size(30, 23)
        Me.LabelX4.TabIndex = 15
        Me.LabelX4.Text = "Path:"
        '
        'TxtLoanDbasePath
        '
        '
        '
        '
        Me.TxtLoanDbasePath.Border.Class = "TextBoxBorder"
        Me.TxtLoanDbasePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtLoanDbasePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtLoanDbasePath.Location = New System.Drawing.Point(133, 124)
        Me.TxtLoanDbasePath.Name = "TxtLoanDbasePath"
        Me.TxtLoanDbasePath.Size = New System.Drawing.Size(300, 23)
        Me.TxtLoanDbasePath.TabIndex = 14
        '
        'LabelX5
        '
        '
        '
        '
        Me.LabelX5.BackgroundStyle.Class = ""
        Me.LabelX5.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX5.Location = New System.Drawing.Point(133, 153)
        Me.LabelX5.Name = "LabelX5"
        Me.LabelX5.Size = New System.Drawing.Size(121, 23)
        Me.LabelX5.TabIndex = 21
        Me.LabelX5.Text = "Posting Database"
        '
        'PostDbasePathButton
        '
        Me.PostDbasePathButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton
        Me.PostDbasePathButton.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground
        Me.PostDbasePathButton.Location = New System.Drawing.Point(439, 182)
        Me.PostDbasePathButton.Name = "PostDbasePathButton"
        Me.PostDbasePathButton.Size = New System.Drawing.Size(75, 23)
        Me.PostDbasePathButton.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled
        Me.PostDbasePathButton.TabIndex = 20
        Me.PostDbasePathButton.Text = "Browse"
        '
        'LabelX6
        '
        '
        '
        '
        Me.LabelX6.BackgroundStyle.Class = ""
        Me.LabelX6.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.LabelX6.Location = New System.Drawing.Point(97, 182)
        Me.LabelX6.Name = "LabelX6"
        Me.LabelX6.Size = New System.Drawing.Size(30, 23)
        Me.LabelX6.TabIndex = 19
        Me.LabelX6.Text = "Path:"
        '
        'TxtPostDbasePath
        '
        '
        '
        '
        Me.TxtPostDbasePath.Border.Class = "TextBoxBorder"
        Me.TxtPostDbasePath.Border.CornerType = DevComponents.DotNetBar.eCornerType.Square
        Me.TxtPostDbasePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TxtPostDbasePath.Location = New System.Drawing.Point(133, 183)
        Me.TxtPostDbasePath.Name = "TxtPostDbasePath"
        Me.TxtPostDbasePath.Size = New System.Drawing.Size(300, 23)
        Me.TxtPostDbasePath.TabIndex = 18
        '
        'SetPaths
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.ClientSize = New System.Drawing.Size(634, 363)
        Me.Controls.Add(Me.LabelX5)
        Me.Controls.Add(Me.PostDbasePathButton)
        Me.Controls.Add(Me.LabelX6)
        Me.Controls.Add(Me.TxtPostDbasePath)
        Me.Controls.Add(Me.LabelX3)
        Me.Controls.Add(Me.LoanDbasePathButton)
        Me.Controls.Add(Me.LabelX4)
        Me.Controls.Add(Me.TxtLoanDbasePath)
        Me.Controls.Add(Me.Cancel_Button)
        Me.Controls.Add(Me.UpdateButton)
        Me.Controls.Add(Me.LabelX2)
        Me.Controls.Add(Me.CustDbasePathButton)
        Me.Controls.Add(Me.LabelX1)
        Me.Controls.Add(Me.TxtCustDbasePath)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SetPaths"
        Me.Text = "SetPaths"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents TxtCustDbasePath As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX1 As DevComponents.DotNetBar.LabelX
    Friend WithEvents CustDbasePathButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX2 As DevComponents.DotNetBar.LabelX
    Friend WithEvents UpdateButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents Cancel_Button As DevComponents.DotNetBar.ButtonX
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
    Friend WithEvents LabelX3 As DevComponents.DotNetBar.LabelX
    Friend WithEvents LoanDbasePathButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX4 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtLoanDbasePath As DevComponents.DotNetBar.Controls.TextBoxX
    Friend WithEvents LabelX5 As DevComponents.DotNetBar.LabelX
    Friend WithEvents PostDbasePathButton As DevComponents.DotNetBar.ButtonX
    Friend WithEvents LabelX6 As DevComponents.DotNetBar.LabelX
    Friend WithEvents TxtPostDbasePath As DevComponents.DotNetBar.Controls.TextBoxX
End Class
