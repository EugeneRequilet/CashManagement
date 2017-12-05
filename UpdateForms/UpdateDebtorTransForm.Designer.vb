<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateDebtorTransForm
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
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dteDate = New System.Windows.Forms.DateTimePicker()
        Me.cboPaymentType = New System.Windows.Forms.ComboBox()
        Me.chbCashDeposited = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtPayoutReason = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCashInTillLessFloat = New CashManagement.NumericTextBox()
        Me.cboDebtorType = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(452, 137)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(365, 137)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.CashUp)
        '
        'EmployeeBindingSource
        '
        Me.EmployeeBindingSource.DataSource = GetType(CashManagement.Employee)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 106)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Date"
        '
        'dteDate
        '
        Me.dteDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "Date", True))
        Me.dteDate.Location = New System.Drawing.Point(104, 102)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.Size = New System.Drawing.Size(182, 20)
        Me.dteDate.TabIndex = 8
        '
        'cboPaymentType
        '
        Me.cboPaymentType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboPaymentType.FormattingEnabled = True
        Me.cboPaymentType.Location = New System.Drawing.Point(209, 71)
        Me.cboPaymentType.Name = "cboPaymentType"
        Me.cboPaymentType.Size = New System.Drawing.Size(88, 21)
        Me.cboPaymentType.TabIndex = 7
        '
        'chbCashDeposited
        '
        Me.chbCashDeposited.AutoSize = True
        Me.chbCashDeposited.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "CashDepReconciled", True))
        Me.chbCashDeposited.Location = New System.Drawing.Point(380, 73)
        Me.chbCashDeposited.Name = "chbCashDeposited"
        Me.chbCashDeposited.Size = New System.Drawing.Size(80, 17)
        Me.chbCashDeposited.TabIndex = 9
        Me.chbCashDeposited.Text = "Reconciled"
        Me.chbCashDeposited.UseVisualStyleBackColor = True
        Me.chbCashDeposited.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 75)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 3
        Me.Label2.Text = "Amount"
        '
        'txtPayoutReason
        '
        Me.txtPayoutReason.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PayoutReason1", True))
        Me.txtPayoutReason.Location = New System.Drawing.Point(104, 41)
        Me.txtPayoutReason.MaxLength = 30
        Me.txtPayoutReason.Name = "txtPayoutReason"
        Me.txtPayoutReason.Size = New System.Drawing.Size(422, 20)
        Me.txtPayoutReason.TabIndex = 5
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 46)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Description"
        '
        'txtCashInTillLessFloat
        '
        Me.txtCashInTillLessFloat.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashInTillLessFloat.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashInTillLessFloat.IsReadOnly = False
        Me.txtCashInTillLessFloat.Location = New System.Drawing.Point(104, 71)
        Me.txtCashInTillLessFloat.MaxLength = 32767
        Me.txtCashInTillLessFloat.Name = "txtCashInTillLessFloat"
        Me.txtCashInTillLessFloat.Size = New System.Drawing.Size(90, 20)
        Me.txtCashInTillLessFloat.TabIndex = 6
        '
        'cboDebtorType
        '
        Me.cboDebtorType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDebtorType.FormattingEnabled = True
        Me.cboDebtorType.Location = New System.Drawing.Point(104, 10)
        Me.cboDebtorType.Name = "cboDebtorType"
        Me.cboDebtorType.Size = New System.Drawing.Size(168, 21)
        Me.cboDebtorType.TabIndex = 10
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 13)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(31, 13)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "Type"
        '
        'UpdateDebtorTransForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(539, 172)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cboDebtorType)
        Me.Controls.Add(Me.txtPayoutReason)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCashInTillLessFloat)
        Me.Controls.Add(Me.chbCashDeposited)
        Me.Controls.Add(Me.cboPaymentType)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.dteDate)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Name = "UpdateDebtorTransForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Other Income / Sale"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cmdCancel As Button
    Friend WithEvents OkButton As Button
    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents EmployeeBindingSource As BindingSource
    Friend WithEvents Label1 As Label
    Friend WithEvents dteDate As DateTimePicker
    Friend WithEvents cboPaymentType As ComboBox
    Friend WithEvents chbCashDeposited As CheckBox
    Friend WithEvents txtCashInTillLessFloat As NumericTextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtPayoutReason As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents cboDebtorType As ComboBox
    Friend WithEvents Label3 As Label
End Class
