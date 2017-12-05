<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class UpdateDailyEmployeeShiftForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Me.dteDate = New System.Windows.Forms.DateTimePicker()
        Me.DailyShiftBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSelectEmployee = New System.Windows.Forms.Button()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnClockOut = New System.Windows.Forms.Button()
        Me.btnClockIn = New System.Windows.Forms.Button()
        Me.timeEmployeeStartTime = New System.Windows.Forms.DateTimePicker()
        Me.timeClockStartTime = New System.Windows.Forms.DateTimePicker()
        Me.timeClockEndTime = New System.Windows.Forms.DateTimePicker()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Memo = New System.Windows.Forms.TextBox()
        Me.Label = New System.Windows.Forms.Label()
        Me.btnDefaultShift = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.timeEmployeeEndTime = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.DefaultShiftBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DailyShiftHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.timeShiftStartTime = New System.Windows.Forms.DateTimePicker()
        Me.timeShiftEndTime = New System.Windows.Forms.DateTimePicker()
        Me.lblShiftStartTime = New System.Windows.Forms.Label()
        Me.lblShiftEndTime = New System.Windows.Forms.Label()
        CType(Me.DailyShiftBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DefaultShiftBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyShiftHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'dteDate
        '
        Me.dteDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DailyShiftBindingSource, "Date", True))
        Me.dteDate.Location = New System.Drawing.Point(80, 12)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.Size = New System.Drawing.Size(182, 20)
        Me.dteDate.TabIndex = 3
        '
        'DailyShiftBindingSource
        '
        Me.DailyShiftBindingSource.DataSource = GetType(CashManagement.DailyShift)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSelectEmployee)
        Me.GroupBox2.Controls.Add(Me.txtEmployeeName)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(601, 84)
        Me.GroupBox2.TabIndex = 32
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Employee Selection"
        '
        'btnSelectEmployee
        '
        Me.btnSelectEmployee.Location = New System.Drawing.Point(6, 0)
        Me.btnSelectEmployee.Name = "btnSelectEmployee"
        Me.btnSelectEmployee.Size = New System.Drawing.Size(106, 23)
        Me.btnSelectEmployee.TabIndex = 0
        Me.btnSelectEmployee.Text = "Select Employee"
        Me.btnSelectEmployee.UseVisualStyleBackColor = True
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Location = New System.Drawing.Point(168, 40)
        Me.txtEmployeeName.MaxLength = 20
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(392, 20)
        Me.txtEmployeeName.TabIndex = 2
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 13)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Employee Selected for Shift"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnClockOut)
        Me.GroupBox1.Controls.Add(Me.btnClockIn)
        Me.GroupBox1.Controls.Add(Me.timeEmployeeStartTime)
        Me.GroupBox1.Controls.Add(Me.timeClockStartTime)
        Me.GroupBox1.Controls.Add(Me.timeClockEndTime)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.Memo)
        Me.GroupBox1.Controls.Add(Me.Label)
        Me.GroupBox1.Controls.Add(Me.btnDefaultShift)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.timeEmployeeEndTime)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(15, 148)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(601, 156)
        Me.GroupBox1.TabIndex = 33
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shift Selection"
        '
        'btnClockOut
        '
        Me.btnClockOut.Location = New System.Drawing.Point(499, 94)
        Me.btnClockOut.Name = "btnClockOut"
        Me.btnClockOut.Size = New System.Drawing.Size(75, 23)
        Me.btnClockOut.TabIndex = 14
        Me.btnClockOut.Text = "Clock Out"
        Me.btnClockOut.UseVisualStyleBackColor = True
        '
        'btnClockIn
        '
        Me.btnClockIn.Location = New System.Drawing.Point(499, 67)
        Me.btnClockIn.Name = "btnClockIn"
        Me.btnClockIn.Size = New System.Drawing.Size(75, 23)
        Me.btnClockIn.TabIndex = 13
        Me.btnClockIn.Text = "Clock In"
        Me.btnClockIn.UseVisualStyleBackColor = True
        '
        'timeEmployeeStartTime
        '
        Me.timeEmployeeStartTime.CustomFormat = "hh:mm tt"
        Me.timeEmployeeStartTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DailyShiftBindingSource, "EmployeeStartTime", True))
        Me.timeEmployeeStartTime.Enabled = False
        Me.timeEmployeeStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeEmployeeStartTime.Location = New System.Drawing.Point(135, 69)
        Me.timeEmployeeStartTime.Name = "timeEmployeeStartTime"
        Me.timeEmployeeStartTime.ShowUpDown = True
        Me.timeEmployeeStartTime.Size = New System.Drawing.Size(97, 20)
        Me.timeEmployeeStartTime.TabIndex = 6
        '
        'timeClockStartTime
        '
        Me.timeClockStartTime.CustomFormat = "hh:mm tt"
        Me.timeClockStartTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DailyShiftBindingSource, "ClockStartTime", True))
        Me.timeClockStartTime.Enabled = False
        Me.timeClockStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeClockStartTime.Location = New System.Drawing.Point(381, 69)
        Me.timeClockStartTime.Name = "timeClockStartTime"
        Me.timeClockStartTime.ShowUpDown = True
        Me.timeClockStartTime.Size = New System.Drawing.Size(97, 20)
        Me.timeClockStartTime.TabIndex = 11
        '
        'timeClockEndTime
        '
        Me.timeClockEndTime.CustomFormat = "hh:mm tt"
        Me.timeClockEndTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DailyShiftBindingSource, "ClockEndTime", True))
        Me.timeClockEndTime.Enabled = False
        Me.timeClockEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeClockEndTime.Location = New System.Drawing.Point(381, 96)
        Me.timeClockEndTime.Name = "timeClockEndTime"
        Me.timeClockEndTime.ShowUpDown = True
        Me.timeClockEndTime.Size = New System.Drawing.Size(97, 20)
        Me.timeClockEndTime.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(293, 73)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Clock In Time"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(293, 100)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 13)
        Me.Label7.TabIndex = 10
        Me.Label7.Text = "Clock Out Time"
        '
        'Memo
        '
        Me.Memo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DailyShiftBindingSource, "Memo", True))
        Me.Memo.Location = New System.Drawing.Point(135, 124)
        Me.Memo.MaxLength = 50
        Me.Memo.Name = "Memo"
        Me.Memo.Size = New System.Drawing.Size(442, 20)
        Me.Memo.TabIndex = 8
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(23, 128)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(36, 13)
        Me.Label.TabIndex = 4
        Me.Label.Text = "Memo"
        '
        'btnDefaultShift
        '
        Me.btnDefaultShift.Location = New System.Drawing.Point(6, 0)
        Me.btnDefaultShift.Name = "btnDefaultShift"
        Me.btnDefaultShift.Size = New System.Drawing.Size(106, 23)
        Me.btnDefaultShift.TabIndex = 0
        Me.btnDefaultShift.Text = "Select Shift"
        Me.btnDefaultShift.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Description"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(135, 40)
        Me.txtDescription.MaxLength = 30
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(267, 20)
        Me.txtDescription.TabIndex = 5
        '
        'timeEmployeeEndTime
        '
        Me.timeEmployeeEndTime.CustomFormat = "hh:mm tt"
        Me.timeEmployeeEndTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DailyShiftBindingSource, "EmployeeEndTime", True))
        Me.timeEmployeeEndTime.Enabled = False
        Me.timeEmployeeEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeEmployeeEndTime.Location = New System.Drawing.Point(135, 96)
        Me.timeEmployeeEndTime.Name = "timeEmployeeEndTime"
        Me.timeEmployeeEndTime.ShowUpDown = True
        Me.timeEmployeeEndTime.Size = New System.Drawing.Size(97, 20)
        Me.timeEmployeeEndTime.TabIndex = 7
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 73)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(104, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Employee Start Time"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 100)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(101, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Employee End Time"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(541, 329)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(454, 329)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'DefaultShiftBindingSource
        '
        Me.DefaultShiftBindingSource.DataSource = GetType(CashManagement.DefaultShift)
        '
        'EmployeeBindingSource
        '
        Me.EmployeeBindingSource.DataSource = GetType(CashManagement.Employee)
        '
        'DailyShiftHeaderBindingSource
        '
        Me.DailyShiftHeaderBindingSource.DataSource = GetType(CashManagement.DailyShiftHeader)
        '
        'timeShiftStartTime
        '
        Me.timeShiftStartTime.CustomFormat = "hh:mm tt"
        Me.timeShiftStartTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DailyShiftBindingSource, "StartTime", True))
        Me.timeShiftStartTime.Enabled = False
        Me.timeShiftStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeShiftStartTime.Location = New System.Drawing.Point(150, 310)
        Me.timeShiftStartTime.Name = "timeShiftStartTime"
        Me.timeShiftStartTime.ShowUpDown = True
        Me.timeShiftStartTime.Size = New System.Drawing.Size(97, 20)
        Me.timeShiftStartTime.TabIndex = 6
        Me.timeShiftStartTime.Visible = False
        '
        'timeShiftEndTime
        '
        Me.timeShiftEndTime.CustomFormat = "hh:mm tt"
        Me.timeShiftEndTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DailyShiftBindingSource, "EndTime", True))
        Me.timeShiftEndTime.Enabled = False
        Me.timeShiftEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeShiftEndTime.Location = New System.Drawing.Point(150, 337)
        Me.timeShiftEndTime.Name = "timeShiftEndTime"
        Me.timeShiftEndTime.ShowUpDown = True
        Me.timeShiftEndTime.Size = New System.Drawing.Size(97, 20)
        Me.timeShiftEndTime.TabIndex = 7
        Me.timeShiftEndTime.Visible = False
        '
        'lblShiftStartTime
        '
        Me.lblShiftStartTime.AutoSize = True
        Me.lblShiftStartTime.Location = New System.Drawing.Point(64, 313)
        Me.lblShiftStartTime.Name = "lblShiftStartTime"
        Me.lblShiftStartTime.Size = New System.Drawing.Size(79, 13)
        Me.lblShiftStartTime.TabIndex = 4
        Me.lblShiftStartTime.Text = "Shift Start Time"
        Me.lblShiftStartTime.Visible = False
        '
        'lblShiftEndTime
        '
        Me.lblShiftEndTime.AutoSize = True
        Me.lblShiftEndTime.Location = New System.Drawing.Point(64, 343)
        Me.lblShiftEndTime.Name = "lblShiftEndTime"
        Me.lblShiftEndTime.Size = New System.Drawing.Size(76, 13)
        Me.lblShiftEndTime.TabIndex = 5
        Me.lblShiftEndTime.Text = "Shift End Time"
        Me.lblShiftEndTime.Visible = False
        '
        'UpdateDailyEmployeeShiftForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(629, 365)
        Me.Controls.Add(Me.timeShiftStartTime)
        Me.Controls.Add(Me.timeShiftEndTime)
        Me.Controls.Add(Me.dteDate)
        Me.Controls.Add(Me.lblShiftStartTime)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblShiftEndTime)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Name = "UpdateDailyEmployeeShiftForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Employee Shift"
        CType(Me.DailyShiftBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DefaultShiftBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyShiftHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents dteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelectEmployee As System.Windows.Forms.Button
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Memo As System.Windows.Forms.TextBox
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents btnDefaultShift As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents timeEmployeeEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents DailyShiftBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DefaultShiftBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DailyShiftHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents timeClockEndTime As DateTimePicker
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents timeClockStartTime As DateTimePicker
    Friend WithEvents timeEmployeeStartTime As DateTimePicker
    Friend WithEvents btnClockIn As Button
    Friend WithEvents btnClockOut As Button
    Friend WithEvents timeShiftStartTime As DateTimePicker
    Friend WithEvents timeShiftEndTime As DateTimePicker
    Friend WithEvents lblShiftStartTime As Label
    Friend WithEvents lblShiftEndTime As Label
End Class
