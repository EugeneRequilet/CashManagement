<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateDailyShiftForm
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
        Me.txtDate = New System.Windows.Forms.TextBox()
        Me.DailyShiftBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.timeEndTime = New System.Windows.Forms.DateTimePicker()
        Me.timeStartTime = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.DailyShiftHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnDefaultShift = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DefaultShiftBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSelectEmployee = New System.Windows.Forms.Button()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.EmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DailyShiftBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyShiftHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DefaultShiftBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(335, 298)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 26
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(248, 298)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 25
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'txtDate
        '
        Me.txtDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DailyShiftBindingSource, "Date", True))
        Me.txtDate.Location = New System.Drawing.Point(60, 12)
        Me.txtDate.MaxLength = 20
        Me.txtDate.Name = "txtDate"
        Me.txtDate.ReadOnly = True
        Me.txtDate.Size = New System.Drawing.Size(190, 20)
        Me.txtDate.TabIndex = 28
        '
        'DailyShiftBindingSource
        '
        Me.DailyShiftBindingSource.DataSource = GetType(CashManagement.DailyShift)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 27
        Me.Label1.Text = "Date"
        '
        'txtDescription
        '
        Me.txtDescription.Location = New System.Drawing.Point(98, 40)
        Me.txtDescription.MaxLength = 30
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.ReadOnly = True
        Me.txtDescription.Size = New System.Drawing.Size(267, 20)
        Me.txtDescription.TabIndex = 30
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(23, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(60, 13)
        Me.Label2.TabIndex = 29
        Me.Label2.Text = "Description"
        '
        'timeEndTime
        '
        Me.timeEndTime.CustomFormat = "hh:mm tt"
        Me.timeEndTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DailyShiftBindingSource, "EndTime", True))
        Me.timeEndTime.Enabled = False
        Me.timeEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeEndTime.Location = New System.Drawing.Point(99, 96)
        Me.timeEndTime.Name = "timeEndTime"
        Me.timeEndTime.ShowUpDown = True
        Me.timeEndTime.Size = New System.Drawing.Size(97, 20)
        Me.timeEndTime.TabIndex = 34
        '
        'timeStartTime
        '
        Me.timeStartTime.CustomFormat = "hh:mm tt"
        Me.timeStartTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.DailyShiftBindingSource, "StartTime", True))
        Me.timeStartTime.Enabled = False
        Me.timeStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeStartTime.Location = New System.Drawing.Point(99, 66)
        Me.timeStartTime.MinDate = New Date(2014, 11, 25, 0, 0, 0, 0)
        Me.timeStartTime.Name = "timeStartTime"
        Me.timeStartTime.ShowUpDown = True
        Me.timeStartTime.Size = New System.Drawing.Size(97, 20)
        Me.timeStartTime.TabIndex = 33
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(23, 96)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 32
        Me.Label3.Text = "End Time"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(23, 70)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 31
        Me.Label4.Text = "Start Time"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(137, 13)
        Me.Label5.TabIndex = 35
        Me.Label5.Text = "Employee Selected for Shift"
        '
        'DailyShiftHeaderBindingSource
        '
        Me.DailyShiftHeaderBindingSource.DataSource = GetType(CashManagement.DailyShiftHeader)
        '
        'btnDefaultShift
        '
        Me.btnDefaultShift.Location = New System.Drawing.Point(6, 0)
        Me.btnDefaultShift.Name = "btnDefaultShift"
        Me.btnDefaultShift.Size = New System.Drawing.Size(106, 23)
        Me.btnDefaultShift.TabIndex = 37
        Me.btnDefaultShift.Text = "Select Shift"
        Me.btnDefaultShift.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.timeStartTime)
        Me.GroupBox1.Controls.Add(Me.btnDefaultShift)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.txtDescription)
        Me.GroupBox1.Controls.Add(Me.timeEndTime)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 47)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(390, 135)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Shift Selection"
        '
        'DefaultShiftBindingSource
        '
        Me.DefaultShiftBindingSource.DataSource = GetType(CashManagement.DefaultShift)
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSelectEmployee)
        Me.GroupBox2.Controls.Add(Me.txtEmployeeName)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(16, 197)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(390, 84)
        Me.GroupBox2.TabIndex = 39
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Employee Selection"
        '
        'btnSelectEmployee
        '
        Me.btnSelectEmployee.Location = New System.Drawing.Point(6, 0)
        Me.btnSelectEmployee.Name = "btnSelectEmployee"
        Me.btnSelectEmployee.Size = New System.Drawing.Size(106, 23)
        Me.btnSelectEmployee.TabIndex = 37
        Me.btnSelectEmployee.Text = "Select Employee"
        Me.btnSelectEmployee.UseVisualStyleBackColor = True
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.Location = New System.Drawing.Point(149, 40)
        Me.txtEmployeeName.MaxLength = 20
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(217, 20)
        Me.txtEmployeeName.TabIndex = 30
        '
        'EmployeeBindingSource
        '
        Me.EmployeeBindingSource.DataSource = GetType(CashManagement.Employee)
        '
        'UpdateDailyShiftForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(422, 333)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Name = "UpdateDailyShiftForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Shift"
        CType(Me.DailyShiftBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyShiftHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DefaultShiftBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents txtDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DailyShiftBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents timeEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents timeStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DailyShiftHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnDefaultShift As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DefaultShiftBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelectEmployee As System.Windows.Forms.Button
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents EmployeeBindingSource As System.Windows.Forms.BindingSource
End Class
