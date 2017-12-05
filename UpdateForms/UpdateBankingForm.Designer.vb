<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateBankingForm
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
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dteDate = New System.Windows.Forms.DateTimePicker()
        Me.cboBankingType = New System.Windows.Forms.ComboBox()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.ckbReconciled = New System.Windows.Forms.CheckBox()
        Me.txtNumber = New CashManagement.NumericTextBox()
        Me.txtAmount = New CashManagement.NumericTextBox()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Banking)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "Amount"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 5
        Me.Label4.Text = "Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Memo"
        '
        'dteDate
        '
        Me.dteDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "Date", True))
        Me.dteDate.Location = New System.Drawing.Point(88, 26)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.Size = New System.Drawing.Size(182, 20)
        Me.dteDate.TabIndex = 7
        '
        'cboBankingType
        '
        Me.cboBankingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankingType.FormattingEnabled = True
        Me.cboBankingType.Location = New System.Drawing.Point(88, 53)
        Me.cboBankingType.Name = "cboBankingType"
        Me.cboBankingType.Size = New System.Drawing.Size(89, 21)
        Me.cboBankingType.TabIndex = 8
        '
        'txtMemo
        '
        Me.txtMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Memo", True))
        Me.txtMemo.Location = New System.Drawing.Point(88, 135)
        Me.txtMemo.MaxLength = 20
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(470, 20)
        Me.txtMemo.TabIndex = 11
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(481, 188)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(394, 188)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'ckbReconciled
        '
        Me.ckbReconciled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckbReconciled.AutoSize = True
        Me.ckbReconciled.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "Reconciled", True))
        Me.ckbReconciled.Location = New System.Drawing.Point(478, 85)
        Me.ckbReconciled.Name = "ckbReconciled"
        Me.ckbReconciled.Size = New System.Drawing.Size(80, 17)
        Me.ckbReconciled.TabIndex = 12
        Me.ckbReconciled.TabStop = False
        Me.ckbReconciled.Text = "Reconciled"
        Me.ckbReconciled.UseVisualStyleBackColor = True
        '
        'txtNumber
        '
        Me.txtNumber.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "Number", True))
        Me.txtNumber.EditValue = 0
        Me.txtNumber.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtNumber.IsReadOnly = False
        Me.txtNumber.Location = New System.Drawing.Point(88, 108)
        Me.txtNumber.MaxLength = 15
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtNumber.TabIndex = 10
        '
        'txtAmount
        '
        Me.txtAmount.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "Amount", True))
        Me.txtAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtAmount.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtAmount.IsReadOnly = False
        Me.txtAmount.Location = New System.Drawing.Point(88, 81)
        Me.txtAmount.MaxLength = 15
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtAmount.TabIndex = 9
        '
        'UpdateBankingForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(571, 223)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.ckbReconciled)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.cboBankingType)
        Me.Controls.Add(Me.dteDate)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UpdateBankingForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Banking Deposit"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents cboBankingType As System.Windows.Forms.ComboBox
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents ckbReconciled As System.Windows.Forms.CheckBox
    Friend WithEvents txtAmount As CashManagement.NumericTextBox
    Friend WithEvents txtNumber As CashManagement.NumericTextBox
End Class
