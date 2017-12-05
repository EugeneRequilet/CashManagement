<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateAdjustmentForm
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
        Me.cboSupplier = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.AdjustmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtOriginalInvoiceNumber = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboDocumentType = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.dteDate = New System.Windows.Forms.DateTimePicker()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SupplierBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtAdjustmentAmount = New CashManagement.NumericTextBox()
        Me.HeaderGroupBox = New System.Windows.Forms.GroupBox()
        Me.ckbReconciled = New System.Windows.Forms.CheckBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        CType(Me.AdjustmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SupplierBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderGroupBox.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(511, 329)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(93, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(407, 329)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(93, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'cboSupplier
        '
        Me.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplier.FormattingEnabled = True
        Me.cboSupplier.Location = New System.Drawing.Point(145, 29)
        Me.cboSupplier.Name = "cboSupplier"
        Me.cboSupplier.Size = New System.Drawing.Size(223, 21)
        Me.cboSupplier.TabIndex = 6
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Supplier"
        '
        'txtMemo
        '
        Me.txtMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdjustmentBindingSource, "Memo", True))
        Me.txtMemo.Location = New System.Drawing.Point(155, 66)
        Me.txtMemo.MaxLength = 30
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(422, 20)
        Me.txtMemo.TabIndex = 10
        '
        'AdjustmentBindingSource
        '
        Me.AdjustmentBindingSource.DataSource = GetType(CashManagement.AdjustmentView)
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 72)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Memo"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(13, 101)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(98, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Adjustment Amount"
        '
        'txtOriginalInvoiceNumber
        '
        Me.txtOriginalInvoiceNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdjustmentBindingSource, "InvoiceNumber", True))
        Me.txtOriginalInvoiceNumber.Location = New System.Drawing.Point(145, 92)
        Me.txtOriginalInvoiceNumber.MaxLength = 20
        Me.txtOriginalInvoiceNumber.Name = "txtOriginalInvoiceNumber"
        Me.txtOriginalInvoiceNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtOriginalInvoiceNumber.TabIndex = 8
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(14, 96)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(120, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "Original Invoice Number"
        '
        'cboDocumentType
        '
        Me.cboDocumentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDocumentType.FormattingEnabled = True
        Me.cboDocumentType.Location = New System.Drawing.Point(155, 34)
        Me.cboDocumentType.Name = "cboDocumentType"
        Me.cboDocumentType.Size = New System.Drawing.Size(89, 21)
        Me.cboDocumentType.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(13, 38)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(138, 13)
        Me.Label8.TabIndex = 3
        Me.Label8.Text = "Adjustment Document Type"
        '
        'dteDate
        '
        Me.dteDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.AdjustmentBindingSource, "Date", True))
        Me.dteDate.Location = New System.Drawing.Point(145, 61)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.Size = New System.Drawing.Size(182, 20)
        Me.dteDate.TabIndex = 7
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 65)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "Date"
        '
        'SupplierBindingSource
        '
        Me.SupplierBindingSource.DataSource = GetType(CashManagement.Supplier)
        '
        'txtAdjustmentAmount
        '
        Me.txtAdjustmentAmount.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.AdjustmentBindingSource, "Amount", True))
        Me.txtAdjustmentAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtAdjustmentAmount.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtAdjustmentAmount.IsReadOnly = True
        Me.txtAdjustmentAmount.Location = New System.Drawing.Point(155, 97)
        Me.txtAdjustmentAmount.MaxLength = 15
        Me.txtAdjustmentAmount.Name = "txtAdjustmentAmount"
        Me.txtAdjustmentAmount.Size = New System.Drawing.Size(90, 20)
        Me.txtAdjustmentAmount.TabIndex = 11
        Me.txtAdjustmentAmount.TabStop = False
        '
        'HeaderGroupBox
        '
        Me.HeaderGroupBox.Controls.Add(Me.cboSupplier)
        Me.HeaderGroupBox.Controls.Add(Me.Label1)
        Me.HeaderGroupBox.Controls.Add(Me.Label3)
        Me.HeaderGroupBox.Controls.Add(Me.Label2)
        Me.HeaderGroupBox.Controls.Add(Me.dteDate)
        Me.HeaderGroupBox.Controls.Add(Me.txtOriginalInvoiceNumber)
        Me.HeaderGroupBox.Location = New System.Drawing.Point(12, 10)
        Me.HeaderGroupBox.Name = "HeaderGroupBox"
        Me.HeaderGroupBox.Size = New System.Drawing.Size(588, 135)
        Me.HeaderGroupBox.TabIndex = 2
        Me.HeaderGroupBox.TabStop = False
        Me.HeaderGroupBox.Text = "Original Invoice Header"
        '
        'ckbReconciled
        '
        Me.ckbReconciled.Anchor = System.Windows.Forms.AnchorStyles.Right
        Me.ckbReconciled.AutoSize = True
        Me.ckbReconciled.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.AdjustmentBindingSource, "Reconciled", True))
        Me.ckbReconciled.Location = New System.Drawing.Point(497, 99)
        Me.ckbReconciled.Name = "ckbReconciled"
        Me.ckbReconciled.Size = New System.Drawing.Size(80, 17)
        Me.ckbReconciled.TabIndex = 13
        Me.ckbReconciled.TabStop = False
        Me.ckbReconciled.Text = "Reconciled"
        Me.ckbReconciled.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.ckbReconciled)
        Me.GroupBox1.Controls.Add(Me.cboDocumentType)
        Me.GroupBox1.Controls.Add(Me.txtMemo)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.txtAdjustmentAmount)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 163)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(588, 139)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Adjustment Required For the Above Invoice"
        '
        'UpdateAdjustmentForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(613, 362)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.HeaderGroupBox)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Name = "UpdateAdjustmentForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier Invoice Adjustment"
        CType(Me.AdjustmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SupplierBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderGroupBox.ResumeLayout(False)
        Me.HeaderGroupBox.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents cboSupplier As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtAdjustmentAmount As CashManagement.NumericTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtOriginalInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cboDocumentType As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents dteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AdjustmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SupplierBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeaderGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents ckbReconciled As System.Windows.Forms.CheckBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
