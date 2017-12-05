<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateDailyShiftHeaderForm
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
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtDayOfWeek = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label37 = New System.Windows.Forms.Label()
        Me.txtShifts = New CashManagement.NumericTextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboRateAdjustment = New System.Windows.Forms.ComboBox()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(514, 159)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 26
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(427, 159)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 25
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'dteDate
        '
        Me.dteDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "Date", True))
        Me.dteDate.Location = New System.Drawing.Point(117, 12)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.Size = New System.Drawing.Size(182, 20)
        Me.dteDate.TabIndex = 27
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.DailyShiftHeader)
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(12, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(30, 13)
        Me.Label8.TabIndex = 28
        Me.Label8.Text = "Date"
        '
        'txtDayOfWeek
        '
        Me.txtDayOfWeek.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "DayOfWeek", True))
        Me.txtDayOfWeek.Location = New System.Drawing.Point(117, 41)
        Me.txtDayOfWeek.Name = "txtDayOfWeek"
        Me.txtDayOfWeek.ReadOnly = True
        Me.txtDayOfWeek.Size = New System.Drawing.Size(157, 20)
        Me.txtDayOfWeek.TabIndex = 29
        Me.txtDayOfWeek.TabStop = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 13)
        Me.Label1.TabIndex = 30
        Me.Label1.Text = "Day Of Week"
        '
        'Label37
        '
        Me.Label37.AutoSize = True
        Me.Label37.Location = New System.Drawing.Point(12, 135)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(81, 13)
        Me.Label37.TabIndex = 46
        Me.Label37.Text = "Shifts for Today"
        '
        'txtShifts
        '
        Me.txtShifts.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "Shifts", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N0"))
        Me.txtShifts.EditValue = 0
        Me.txtShifts.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtShifts.IsReadOnly = True
        Me.txtShifts.Location = New System.Drawing.Point(117, 131)
        Me.txtShifts.MaxLength = 4
        Me.txtShifts.Name = "txtShifts"
        Me.txtShifts.Size = New System.Drawing.Size(65, 20)
        Me.txtShifts.TabIndex = 47
        Me.txtShifts.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(-43, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 48
        Me.Label5.Text = "Memo"
        '
        'txtMemo
        '
        Me.txtMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Memo", True))
        Me.txtMemo.Location = New System.Drawing.Point(117, 102)
        Me.txtMemo.MaxLength = 20
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(470, 20)
        Me.txtMemo.TabIndex = 50
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(36, 13)
        Me.Label2.TabIndex = 49
        Me.Label2.Text = "Memo"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(12, 73)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(85, 13)
        Me.Label18.TabIndex = 51
        Me.Label18.Text = "Rate Adjustment"
        '
        'cboRateAdjustment
        '
        Me.cboRateAdjustment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboRateAdjustment.FormattingEnabled = True
        Me.cboRateAdjustment.Location = New System.Drawing.Point(117, 69)
        Me.cboRateAdjustment.Name = "cboRateAdjustment"
        Me.cboRateAdjustment.Size = New System.Drawing.Size(151, 21)
        Me.cboRateAdjustment.TabIndex = 52
        '
        'UpdateDailyShiftHeaderForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(601, 194)
        Me.Controls.Add(Me.Label18)
        Me.Controls.Add(Me.cboRateAdjustment)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtShifts)
        Me.Controls.Add(Me.Label37)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.txtDayOfWeek)
        Me.Controls.Add(Me.dteDate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Name = "UpdateDailyShiftHeaderForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Shift Header"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents dteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtDayOfWeek As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtShifts As CashManagement.NumericTextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboRateAdjustment As System.Windows.Forms.ComboBox
End Class
