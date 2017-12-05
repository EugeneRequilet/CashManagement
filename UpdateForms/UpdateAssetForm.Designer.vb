<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateAssetForm
    Inherits System.Windows.Forms.Form

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
        Me.components = New System.ComponentModel.Container()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.dtePurchaseDate = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TxtSerialNumber = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.browseButton = New System.Windows.Forms.Button()
        Me.txtFileAndLocation = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.OpenFileButton = New System.Windows.Forms.Button()
        Me.cboBranchCode = New System.Windows.Forms.ComboBox()
        Me.BranchBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtBranchDescription = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtTotalValue = New CashManagement.NumericTextBox()
        Me.txtQuantity = New CashManagement.NumericTextBox()
        Me.txtPurchaseAmount = New CashManagement.NumericTextBox()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BranchBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(622, 367)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(535, 367)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'txtMemo
        '
        Me.txtMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Memo", True))
        Me.txtMemo.Location = New System.Drawing.Point(121, 241)
        Me.txtMemo.MaxLength = 255
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(539, 20)
        Me.txtMemo.TabIndex = 19
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Asset)
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(12, 244)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Memo"
        '
        'txtDescription
        '
        Me.txtDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Description", True))
        Me.txtDescription.Location = New System.Drawing.Point(121, 41)
        Me.txtDescription.MaxLength = 50
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(539, 20)
        Me.txtDescription.TabIndex = 13
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 44)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Description"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 175)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(91, 13)
        Me.Label3.TabIndex = 7
        Me.Label3.Text = "Purchase Amount"
        '
        'dtePurchaseDate
        '
        Me.dtePurchaseDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "PurchaseDate", True))
        Me.dtePurchaseDate.Location = New System.Drawing.Point(121, 109)
        Me.dtePurchaseDate.Name = "dtePurchaseDate"
        Me.dtePurchaseDate.Size = New System.Drawing.Size(182, 20)
        Me.dtePurchaseDate.TabIndex = 15
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 112)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(78, 13)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Purchase Date"
        '
        'TxtSerialNumber
        '
        Me.TxtSerialNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "SerialNumber", True))
        Me.TxtSerialNumber.Location = New System.Drawing.Point(121, 75)
        Me.TxtSerialNumber.MaxLength = 50
        Me.TxtSerialNumber.Name = "TxtSerialNumber"
        Me.TxtSerialNumber.Size = New System.Drawing.Size(341, 20)
        Me.TxtSerialNumber.TabIndex = 14
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(12, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Serial Number"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(12, 9)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Branch"
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(668, 276)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(27, 23)
        Me.browseButton.TabIndex = 21
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'txtFileAndLocation
        '
        Me.txtFileAndLocation.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "AttachmentAndLocation", True))
        Me.txtFileAndLocation.Location = New System.Drawing.Point(121, 277)
        Me.txtFileAndLocation.Name = "txtFileAndLocation"
        Me.txtFileAndLocation.Size = New System.Drawing.Size(539, 20)
        Me.txtFileAndLocation.TabIndex = 20
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(12, 280)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(73, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Select Picture"
        '
        'OpenFileButton
        '
        Me.OpenFileButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OpenFileButton.Location = New System.Drawing.Point(15, 319)
        Me.OpenFileButton.Name = "OpenFileButton"
        Me.OpenFileButton.Size = New System.Drawing.Size(75, 71)
        Me.OpenFileButton.TabIndex = 22
        Me.OpenFileButton.Text = "Open the Picture"
        Me.OpenFileButton.UseVisualStyleBackColor = True
        '
        'cboBranchCode
        '
        Me.cboBranchCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBranchCode.FormattingEnabled = True
        Me.cboBranchCode.Location = New System.Drawing.Point(121, 6)
        Me.cboBranchCode.Name = "cboBranchCode"
        Me.cboBranchCode.Size = New System.Drawing.Size(100, 21)
        Me.cboBranchCode.TabIndex = 11
        '
        'BranchBindingSource
        '
        Me.BranchBindingSource.DataSource = GetType(CashManagement.Branch)
        '
        'txtBranchDescription
        '
        Me.txtBranchDescription.AutoSize = True
        Me.txtBranchDescription.Location = New System.Drawing.Point(242, 9)
        Me.txtBranchDescription.Name = "txtBranchDescription"
        Me.txtBranchDescription.Size = New System.Drawing.Size(78, 13)
        Me.txtBranchDescription.TabIndex = 12
        Me.txtBranchDescription.Text = "None Selected"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 143)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Quantity"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 210)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(61, 13)
        Me.Label9.TabIndex = 8
        Me.Label9.Text = "Total Value"
        '
        'txtTotalValue
        '
        Me.txtTotalValue.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalValue.Enabled = False
        Me.txtTotalValue.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtTotalValue.IsReadOnly = True
        Me.txtTotalValue.Location = New System.Drawing.Point(121, 207)
        Me.txtTotalValue.MaxLength = 15
        Me.txtTotalValue.Name = "txtTotalValue"
        Me.txtTotalValue.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalValue.TabIndex = 18
        '
        'txtQuantity
        '
        Me.txtQuantity.EditValue = 0
        Me.txtQuantity.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtQuantity.IsReadOnly = False
        Me.txtQuantity.Location = New System.Drawing.Point(121, 140)
        Me.txtQuantity.MaxLength = 15
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(100, 20)
        Me.txtQuantity.TabIndex = 16
        '
        'txtPurchaseAmount
        '
        Me.txtPurchaseAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPurchaseAmount.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPurchaseAmount.IsReadOnly = False
        Me.txtPurchaseAmount.Location = New System.Drawing.Point(121, 172)
        Me.txtPurchaseAmount.MaxLength = 15
        Me.txtPurchaseAmount.Name = "txtPurchaseAmount"
        Me.txtPurchaseAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtPurchaseAmount.TabIndex = 17
        '
        'UpdateAssetForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(709, 402)
        Me.Controls.Add(Me.txtTotalValue)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.txtQuantity)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.txtBranchDescription)
        Me.Controls.Add(Me.cboBranchCode)
        Me.Controls.Add(Me.OpenFileButton)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.txtFileAndLocation)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.TxtSerialNumber)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.dtePurchaseDate)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtPurchaseAmount)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Name = "UpdateAssetForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Asset"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BranchBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtPurchaseAmount As CashManagement.NumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dtePurchaseDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents TxtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As Label
    Friend WithEvents browseButton As Button
    Friend WithEvents txtFileAndLocation As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents OpenFileButton As Button
    Friend WithEvents cboBranchCode As ComboBox
    Friend WithEvents BranchBindingSource As BindingSource
    Friend WithEvents txtBranchDescription As Label
    Friend WithEvents txtQuantity As NumericTextBox
    Friend WithEvents Label8 As Label
    Friend WithEvents txtTotalValue As NumericTextBox
    Friend WithEvents Label9 As Label
End Class
