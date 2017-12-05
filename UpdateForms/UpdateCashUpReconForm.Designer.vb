<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateCashUpReconForm
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
        Me.lblCreditCardDeposited = New System.Windows.Forms.Label()
        Me.lblCashDeposited = New System.Windows.Forms.Label()
        Me.lblDepositSkim1 = New System.Windows.Forms.Label()
        Me.lblDepositSkim2 = New System.Windows.Forms.Label()
        Me.lblDepositSkim3 = New System.Windows.Forms.Label()
        Me.txtCashupDate = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.chbCreditCardDeposited = New System.Windows.Forms.CheckBox()
        Me.chbCashDeposited = New System.Windows.Forms.CheckBox()
        Me.chbDepositSkim1 = New System.Windows.Forms.CheckBox()
        Me.chbDepositSkim2 = New System.Windows.Forms.CheckBox()
        Me.chbDepositSkim3 = New System.Windows.Forms.CheckBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.txtDepositSkim3 = New CashManagement.NumericTextBox()
        Me.txtDepositSkim2 = New CashManagement.NumericTextBox()
        Me.txtDepositSkim1 = New CashManagement.NumericTextBox()
        Me.txtCashDeposited = New CashManagement.NumericTextBox()
        Me.txtCreditCardDeposited = New CashManagement.NumericTextBox()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Date"
        '
        'lblCreditCardDeposited
        '
        Me.lblCreditCardDeposited.AutoSize = True
        Me.lblCreditCardDeposited.Location = New System.Drawing.Point(26, 49)
        Me.lblCreditCardDeposited.Name = "lblCreditCardDeposited"
        Me.lblCreditCardDeposited.Size = New System.Drawing.Size(110, 13)
        Me.lblCreditCardDeposited.TabIndex = 1
        Me.lblCreditCardDeposited.Text = "Credit Card Deposited"
        '
        'lblCashDeposited
        '
        Me.lblCashDeposited.AutoSize = True
        Me.lblCashDeposited.Location = New System.Drawing.Point(26, 79)
        Me.lblCashDeposited.Name = "lblCashDeposited"
        Me.lblCashDeposited.Size = New System.Drawing.Size(82, 13)
        Me.lblCashDeposited.TabIndex = 2
        Me.lblCashDeposited.Text = "Cash Deposited"
        '
        'lblDepositSkim1
        '
        Me.lblDepositSkim1.AutoSize = True
        Me.lblDepositSkim1.Location = New System.Drawing.Point(26, 109)
        Me.lblDepositSkim1.Name = "lblDepositSkim1"
        Me.lblDepositSkim1.Size = New System.Drawing.Size(78, 13)
        Me.lblDepositSkim1.TabIndex = 3
        Me.lblDepositSkim1.Text = "Deposit Skim 1"
        '
        'lblDepositSkim2
        '
        Me.lblDepositSkim2.AutoSize = True
        Me.lblDepositSkim2.Location = New System.Drawing.Point(26, 139)
        Me.lblDepositSkim2.Name = "lblDepositSkim2"
        Me.lblDepositSkim2.Size = New System.Drawing.Size(78, 13)
        Me.lblDepositSkim2.TabIndex = 4
        Me.lblDepositSkim2.Text = "Deposit Skim 2"
        '
        'lblDepositSkim3
        '
        Me.lblDepositSkim3.AutoSize = True
        Me.lblDepositSkim3.Location = New System.Drawing.Point(26, 169)
        Me.lblDepositSkim3.Name = "lblDepositSkim3"
        Me.lblDepositSkim3.Size = New System.Drawing.Size(78, 13)
        Me.lblDepositSkim3.TabIndex = 5
        Me.lblDepositSkim3.Text = "Deposit Skim 3"
        '
        'txtCashupDate
        '
        Me.txtCashupDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Date", True))
        Me.txtCashupDate.Location = New System.Drawing.Point(156, 15)
        Me.txtCashupDate.Name = "txtCashupDate"
        Me.txtCashupDate.ReadOnly = True
        Me.txtCashupDate.Size = New System.Drawing.Size(100, 20)
        Me.txtCashupDate.TabIndex = 52
        Me.txtCashupDate.TabStop = False
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.CashUp)
        '
        'chbCreditCardDeposited
        '
        Me.chbCreditCardDeposited.AutoSize = True
        Me.chbCreditCardDeposited.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "CreditCardReconciled", True))
        Me.chbCreditCardDeposited.Location = New System.Drawing.Point(277, 47)
        Me.chbCreditCardDeposited.Name = "chbCreditCardDeposited"
        Me.chbCreditCardDeposited.Size = New System.Drawing.Size(129, 17)
        Me.chbCreditCardDeposited.TabIndex = 58
        Me.chbCreditCardDeposited.Text = "Reconcile Credit Card"
        Me.chbCreditCardDeposited.UseVisualStyleBackColor = True
        '
        'chbCashDeposited
        '
        Me.chbCashDeposited.AutoSize = True
        Me.chbCashDeposited.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "CashDepReconciled", True))
        Me.chbCashDeposited.Location = New System.Drawing.Point(277, 77)
        Me.chbCashDeposited.Name = "chbCashDeposited"
        Me.chbCashDeposited.Size = New System.Drawing.Size(101, 17)
        Me.chbCashDeposited.TabIndex = 59
        Me.chbCashDeposited.Text = "Reconcile Cash"
        Me.chbCashDeposited.UseVisualStyleBackColor = True
        '
        'chbDepositSkim1
        '
        Me.chbDepositSkim1.AutoSize = True
        Me.chbDepositSkim1.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "Skims1Reconciled", True))
        Me.chbDepositSkim1.Location = New System.Drawing.Point(277, 107)
        Me.chbDepositSkim1.Name = "chbDepositSkim1"
        Me.chbDepositSkim1.Size = New System.Drawing.Size(148, 17)
        Me.chbDepositSkim1.TabIndex = 60
        Me.chbDepositSkim1.Text = "Reconcile Deposit Skim 1"
        Me.chbDepositSkim1.UseVisualStyleBackColor = True
        '
        'chbDepositSkim2
        '
        Me.chbDepositSkim2.AutoSize = True
        Me.chbDepositSkim2.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "Skims2Reconciled", True))
        Me.chbDepositSkim2.Location = New System.Drawing.Point(277, 137)
        Me.chbDepositSkim2.Name = "chbDepositSkim2"
        Me.chbDepositSkim2.Size = New System.Drawing.Size(148, 17)
        Me.chbDepositSkim2.TabIndex = 61
        Me.chbDepositSkim2.Text = "Reconcile Deposit Skim 2"
        Me.chbDepositSkim2.UseVisualStyleBackColor = True
        '
        'chbDepositSkim3
        '
        Me.chbDepositSkim3.AutoSize = True
        Me.chbDepositSkim3.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "Skims3Reconciled", True))
        Me.chbDepositSkim3.Location = New System.Drawing.Point(277, 167)
        Me.chbDepositSkim3.Name = "chbDepositSkim3"
        Me.chbDepositSkim3.Size = New System.Drawing.Size(148, 17)
        Me.chbDepositSkim3.TabIndex = 62
        Me.chbDepositSkim3.Text = "Reconcile Deposit Skim 3"
        Me.chbDepositSkim3.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(367, 223)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 64
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(284, 223)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 63
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'txtDepositSkim3
        '
        Me.txtDepositSkim3.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "DepositedSkim3", True))
        Me.txtDepositSkim3.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDepositSkim3.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDepositSkim3.IsReadOnly = True
        Me.txtDepositSkim3.Location = New System.Drawing.Point(156, 165)
        Me.txtDepositSkim3.MaxLength = 32767
        Me.txtDepositSkim3.Name = "txtDepositSkim3"
        Me.txtDepositSkim3.Size = New System.Drawing.Size(100, 20)
        Me.txtDepositSkim3.TabIndex = 57
        Me.txtDepositSkim3.TabStop = False
        '
        'txtDepositSkim2
        '
        Me.txtDepositSkim2.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "DepositedSkim2", True))
        Me.txtDepositSkim2.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDepositSkim2.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDepositSkim2.IsReadOnly = True
        Me.txtDepositSkim2.Location = New System.Drawing.Point(156, 135)
        Me.txtDepositSkim2.MaxLength = 32767
        Me.txtDepositSkim2.Name = "txtDepositSkim2"
        Me.txtDepositSkim2.Size = New System.Drawing.Size(100, 20)
        Me.txtDepositSkim2.TabIndex = 56
        Me.txtDepositSkim2.TabStop = False
        '
        'txtDepositSkim1
        '
        Me.txtDepositSkim1.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "DepositedSkim1", True))
        Me.txtDepositSkim1.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDepositSkim1.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDepositSkim1.IsReadOnly = True
        Me.txtDepositSkim1.Location = New System.Drawing.Point(156, 105)
        Me.txtDepositSkim1.MaxLength = 32767
        Me.txtDepositSkim1.Name = "txtDepositSkim1"
        Me.txtDepositSkim1.Size = New System.Drawing.Size(100, 20)
        Me.txtDepositSkim1.TabIndex = 55
        Me.txtDepositSkim1.TabStop = False
        '
        'txtCashDeposited
        '
        Me.txtCashDeposited.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashDeposited.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashDeposited.IsReadOnly = True
        Me.txtCashDeposited.Location = New System.Drawing.Point(156, 75)
        Me.txtCashDeposited.MaxLength = 32767
        Me.txtCashDeposited.Name = "txtCashDeposited"
        Me.txtCashDeposited.Size = New System.Drawing.Size(100, 20)
        Me.txtCashDeposited.TabIndex = 54
        Me.txtCashDeposited.TabStop = False
        '
        'txtCreditCardDeposited
        '
        Me.txtCreditCardDeposited.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "TotalCreditCard", True))
        Me.txtCreditCardDeposited.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCreditCardDeposited.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCreditCardDeposited.IsReadOnly = True
        Me.txtCreditCardDeposited.Location = New System.Drawing.Point(156, 45)
        Me.txtCreditCardDeposited.MaxLength = 32767
        Me.txtCreditCardDeposited.Name = "txtCreditCardDeposited"
        Me.txtCreditCardDeposited.Size = New System.Drawing.Size(100, 20)
        Me.txtCreditCardDeposited.TabIndex = 53
        Me.txtCreditCardDeposited.TabStop = False
        '
        'UpdateCashUpReconForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(454, 258)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.chbDepositSkim3)
        Me.Controls.Add(Me.chbDepositSkim2)
        Me.Controls.Add(Me.chbDepositSkim1)
        Me.Controls.Add(Me.chbCashDeposited)
        Me.Controls.Add(Me.chbCreditCardDeposited)
        Me.Controls.Add(Me.txtDepositSkim3)
        Me.Controls.Add(Me.txtDepositSkim2)
        Me.Controls.Add(Me.txtDepositSkim1)
        Me.Controls.Add(Me.txtCashDeposited)
        Me.Controls.Add(Me.txtCreditCardDeposited)
        Me.Controls.Add(Me.txtCashupDate)
        Me.Controls.Add(Me.lblDepositSkim3)
        Me.Controls.Add(Me.lblDepositSkim2)
        Me.Controls.Add(Me.lblDepositSkim1)
        Me.Controls.Add(Me.lblCashDeposited)
        Me.Controls.Add(Me.lblCreditCardDeposited)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UpdateCashUpReconForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Reconcile Cash-up"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblCreditCardDeposited As System.Windows.Forms.Label
    Friend WithEvents lblCashDeposited As System.Windows.Forms.Label
    Friend WithEvents lblDepositSkim1 As System.Windows.Forms.Label
    Friend WithEvents lblDepositSkim2 As System.Windows.Forms.Label
    Friend WithEvents lblDepositSkim3 As System.Windows.Forms.Label
    Friend WithEvents txtCashupDate As System.Windows.Forms.TextBox
    Friend WithEvents txtCreditCardDeposited As CashManagement.NumericTextBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtCashDeposited As CashManagement.NumericTextBox
    Friend WithEvents txtDepositSkim1 As CashManagement.NumericTextBox
    Friend WithEvents txtDepositSkim2 As CashManagement.NumericTextBox
    Friend WithEvents txtDepositSkim3 As CashManagement.NumericTextBox
    Friend WithEvents chbCreditCardDeposited As System.Windows.Forms.CheckBox
    Friend WithEvents chbCashDeposited As System.Windows.Forms.CheckBox
    Friend WithEvents chbDepositSkim1 As System.Windows.Forms.CheckBox
    Friend WithEvents chbDepositSkim2 As System.Windows.Forms.CheckBox
    Friend WithEvents chbDepositSkim3 As System.Windows.Forms.CheckBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
End Class
