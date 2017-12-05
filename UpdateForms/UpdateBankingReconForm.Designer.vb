<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateBankingReconForm
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.ckbReconciled = New System.Windows.Forms.CheckBox()
        Me.txtNumber = New CashManagement.NumericTextBox()
        Me.txtAmount = New CashManagement.NumericTextBox()
        Me.dteDate = New System.Windows.Forms.TextBox()
        Me.txtBankingType = New System.Windows.Forms.TextBox()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(19, 30)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(19, 57)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(31, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Type"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(19, 85)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(43, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Amount"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(19, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(44, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(19, 139)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Memo"
        '
        'txtMemo
        '
        Me.txtMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Memo", True))
        Me.txtMemo.Location = New System.Drawing.Point(88, 135)
        Me.txtMemo.MaxLength = 20
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.ReadOnly = True
        Me.txtMemo.Size = New System.Drawing.Size(470, 20)
        Me.txtMemo.TabIndex = 9
        Me.txtMemo.TabStop = False
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Banking)
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(481, 188)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 12
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(394, 188)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 11
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'ckbReconciled
        '
        Me.ckbReconciled.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckbReconciled.AutoSize = True
        Me.ckbReconciled.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "Reconciled", True))
        Me.ckbReconciled.Location = New System.Drawing.Point(422, 83)
        Me.ckbReconciled.Name = "ckbReconciled"
        Me.ckbReconciled.Size = New System.Drawing.Size(136, 17)
        Me.ckbReconciled.TabIndex = 10
        Me.ckbReconciled.TabStop = False
        Me.ckbReconciled.Text = "Reconcile This Amount"
        Me.ckbReconciled.UseVisualStyleBackColor = True
        '
        'txtNumber
        '
        Me.txtNumber.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "Number", True))
        Me.txtNumber.EditValue = 0
        Me.txtNumber.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtNumber.IsReadOnly = True
        Me.txtNumber.Location = New System.Drawing.Point(88, 108)
        Me.txtNumber.MaxLength = 15
        Me.txtNumber.Name = "txtNumber"
        Me.txtNumber.Size = New System.Drawing.Size(100, 20)
        Me.txtNumber.TabIndex = 8
        Me.txtNumber.TabStop = False
        '
        'txtAmount
        '
        Me.txtAmount.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "Amount", True))
        Me.txtAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtAmount.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtAmount.IsReadOnly = True
        Me.txtAmount.Location = New System.Drawing.Point(88, 81)
        Me.txtAmount.MaxLength = 15
        Me.txtAmount.Name = "txtAmount"
        Me.txtAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtAmount.TabIndex = 7
        Me.txtAmount.TabStop = False
        '
        'dteDate
        '
        Me.dteDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Date", True))
        Me.dteDate.Location = New System.Drawing.Point(88, 27)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.ReadOnly = True
        Me.dteDate.Size = New System.Drawing.Size(100, 20)
        Me.dteDate.TabIndex = 53
        Me.dteDate.TabStop = False
        '
        'txtBankingType
        '
        Me.txtBankingType.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Date", True))
        Me.txtBankingType.Location = New System.Drawing.Point(88, 54)
        Me.txtBankingType.Name = "txtBankingType"
        Me.txtBankingType.ReadOnly = True
        Me.txtBankingType.Size = New System.Drawing.Size(100, 20)
        Me.txtBankingType.TabIndex = 54
        Me.txtBankingType.TabStop = False
        '
        'UpdateBankingReconForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(571, 223)
        Me.Controls.Add(Me.txtBankingType)
        Me.Controls.Add(Me.dteDate)
        Me.Controls.Add(Me.txtNumber)
        Me.Controls.Add(Me.txtAmount)
        Me.Controls.Add(Me.ckbReconciled)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UpdateBankingReconForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Banking Reconciliation"
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
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents ckbReconciled As System.Windows.Forms.CheckBox
    Friend WithEvents txtAmount As CashManagement.NumericTextBox
    Friend WithEvents txtNumber As CashManagement.NumericTextBox
    Friend WithEvents dteDate As System.Windows.Forms.TextBox
    Friend WithEvents txtBankingType As System.Windows.Forms.TextBox
End Class
