<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateInvoiceForm
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
        Me.dteDate = New System.Windows.Forms.DateTimePicker()
        Me.InvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboDocumentType = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDocumentNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cboSupplier = New System.Windows.Forms.ComboBox()
        Me.SupplierBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboPaymentType = New System.Windows.Forms.ComboBox()
        Me.txtAmount = New CashManagement.NumericTextBox()
        CType(Me.InvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SupplierBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(416, 206)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(329, 206)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'dteDate
        '
        Me.dteDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.InvoiceBindingSource, "Date", True))
        Me.dteDate.Location = New System.Drawing.Point(124, 164)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.Size = New System.Drawing.Size(182, 20)
        Me.dteDate.TabIndex = 14
        '
        'InvoiceBindingSource
        '
        Me.InvoiceBindingSource.DataSource = GetType(CashManagement.Invoice)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Date"
        '
        'cboDocumentType
        '
        Me.cboDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocumentType.FormattingEnabled = True
        Me.cboDocumentType.Location = New System.Drawing.Point(124, 48)
        Me.cboDocumentType.Name = "cboDocumentType"
        Me.cboDocumentType.Size = New System.Drawing.Size(166, 21)
        Me.cboDocumentType.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Document Type"
        '
        'txtDocumentNumber
        '
        Me.txtDocumentNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceBindingSource, "DocumentNumber", True))
        Me.txtDocumentNumber.Location = New System.Drawing.Point(124, 78)
        Me.txtDocumentNumber.MaxLength = 20
        Me.txtDocumentNumber.Name = "txtDocumentNumber"
        Me.txtDocumentNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtDocumentNumber.TabIndex = 10
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 82)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Document Number"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 111)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(43, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Amount"
        '
        'txtMemo
        '
        Me.txtMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.InvoiceBindingSource, "Memo", True))
        Me.txtMemo.Location = New System.Drawing.Point(124, 136)
        Me.txtMemo.MaxLength = 30
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(367, 20)
        Me.txtMemo.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 140)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 6
        Me.Label4.Text = "Memo"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Supplier"
        '
        'cboSupplier
        '
        Me.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplier.FormattingEnabled = True
        Me.cboSupplier.Location = New System.Drawing.Point(124, 19)
        Me.cboSupplier.Name = "cboSupplier"
        Me.cboSupplier.Size = New System.Drawing.Size(223, 21)
        Me.cboSupplier.TabIndex = 8
        '
        'SupplierBindingSource
        '
        Me.SupplierBindingSource.DataSource = GetType(CashManagement.Supplier)
        '
        'cboPaymentType
        '
        Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Location = New System.Drawing.Point(220, 108)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(70, 21)
        Me.cboPaymentType.TabIndex = 12
        '
        'txtAmount
        '
        Me.txtAmount.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.InvoiceBindingSource, "Amount", True))
        Me.txtAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtAmount.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtAmount.IsReadOnly = False
        Me.txtAmount.Location = New System.Drawing.Point(124, 107)
        Me.txtAmount.MaxLength = 15
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(90, 20)
        Me.txtAmount.TabIndex = 11
        '
        'UpdateInvoiceForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(503, 241)
        Me.Controls.Add(Me.cboPaymentType)
        Me.Controls.Add(Me.cboSupplier)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.txtDocumentNumber)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.cboDocumentType)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.dteDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "UpdateInvoiceForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Document"
        CType(Me.InvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SupplierBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents InvoiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents dteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboDocumentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtDocumentNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtAmount As CashManagement.NumericTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents SupplierBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cboPaymentType As ComboBox
End Class
