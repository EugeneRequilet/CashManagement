<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyEmployeeShiftGrid
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShiftDescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeStartTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeEndTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeHoursDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClockStartTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ClockEndTime = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.MemoDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.DailyEmployeeShiftView)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.ShiftDescriptionDataGridViewTextBoxColumn, Me.EmployeeStartTimeDataGridViewTextBoxColumn, Me.EmployeeEndTimeDataGridViewTextBoxColumn, Me.EmployeeHoursDataGridViewTextBoxColumn, Me.EmployeeNameDataGridViewTextBoxColumn, Me.ClockStartTime, Me.ClockEndTime, Me.MemoDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(897, 560)
        Me.DataGridView1.TabIndex = 0
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.Width = 55
        '
        'ShiftDescriptionDataGridViewTextBoxColumn
        '
        Me.ShiftDescriptionDataGridViewTextBoxColumn.DataPropertyName = "ShiftDescription"
        Me.ShiftDescriptionDataGridViewTextBoxColumn.HeaderText = "Shift Description"
        Me.ShiftDescriptionDataGridViewTextBoxColumn.Name = "ShiftDescriptionDataGridViewTextBoxColumn"
        Me.ShiftDescriptionDataGridViewTextBoxColumn.ReadOnly = True
        '
        'EmployeeStartTimeDataGridViewTextBoxColumn
        '
        Me.EmployeeStartTimeDataGridViewTextBoxColumn.DataPropertyName = "EmployeeStartTime"
        DataGridViewCellStyle2.Format = "t"
        Me.EmployeeStartTimeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.EmployeeStartTimeDataGridViewTextBoxColumn.HeaderText = "Start Time"
        Me.EmployeeStartTimeDataGridViewTextBoxColumn.Name = "EmployeeStartTimeDataGridViewTextBoxColumn"
        Me.EmployeeStartTimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.EmployeeStartTimeDataGridViewTextBoxColumn.Width = 74
        '
        'EmployeeEndTimeDataGridViewTextBoxColumn
        '
        Me.EmployeeEndTimeDataGridViewTextBoxColumn.DataPropertyName = "EmployeeEndTime"
        DataGridViewCellStyle3.Format = "t"
        Me.EmployeeEndTimeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.EmployeeEndTimeDataGridViewTextBoxColumn.HeaderText = "End Time"
        Me.EmployeeEndTimeDataGridViewTextBoxColumn.Name = "EmployeeEndTimeDataGridViewTextBoxColumn"
        Me.EmployeeEndTimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.EmployeeEndTimeDataGridViewTextBoxColumn.Width = 71
        '
        'EmployeeHoursDataGridViewTextBoxColumn
        '
        Me.EmployeeHoursDataGridViewTextBoxColumn.DataPropertyName = "EmployeeHours"
        Me.EmployeeHoursDataGridViewTextBoxColumn.HeaderText = "Hours"
        Me.EmployeeHoursDataGridViewTextBoxColumn.Name = "EmployeeHoursDataGridViewTextBoxColumn"
        Me.EmployeeHoursDataGridViewTextBoxColumn.ReadOnly = True
        Me.EmployeeHoursDataGridViewTextBoxColumn.Width = 60
        '
        'EmployeeNameDataGridViewTextBoxColumn
        '
        Me.EmployeeNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeName"
        Me.EmployeeNameDataGridViewTextBoxColumn.HeaderText = "Employee"
        Me.EmployeeNameDataGridViewTextBoxColumn.Name = "EmployeeNameDataGridViewTextBoxColumn"
        Me.EmployeeNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.EmployeeNameDataGridViewTextBoxColumn.Width = 78
        '
        'ClockStartTime
        '
        Me.ClockStartTime.DataPropertyName = "ClockStartTime"
        DataGridViewCellStyle4.Format = "t"
        Me.ClockStartTime.DefaultCellStyle = DataGridViewCellStyle4
        Me.ClockStartTime.HeaderText = "Clock In"
        Me.ClockStartTime.Name = "ClockStartTime"
        Me.ClockStartTime.ReadOnly = True
        Me.ClockStartTime.Width = 66
        '
        'ClockEndTime
        '
        Me.ClockEndTime.DataPropertyName = "ClockEndTime"
        DataGridViewCellStyle5.Format = "t"
        Me.ClockEndTime.DefaultCellStyle = DataGridViewCellStyle5
        Me.ClockEndTime.HeaderText = "Clock Out"
        Me.ClockEndTime.Name = "ClockEndTime"
        Me.ClockEndTime.ReadOnly = True
        Me.ClockEndTime.Width = 73
        '
        'MemoDataGridViewTextBoxColumn
        '
        Me.MemoDataGridViewTextBoxColumn.DataPropertyName = "Memo"
        Me.MemoDataGridViewTextBoxColumn.HeaderText = "Memo"
        Me.MemoDataGridViewTextBoxColumn.Name = "MemoDataGridViewTextBoxColumn"
        Me.MemoDataGridViewTextBoxColumn.ReadOnly = True
        Me.MemoDataGridViewTextBoxColumn.Width = 61
        '
        'DailyEmployeeShiftGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "DailyEmployeeShiftGrid"
        Me.Size = New System.Drawing.Size(897, 560)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ShiftDescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeStartTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeEndTimeDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeHoursDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ClockStartTime As DataGridViewTextBoxColumn
    Friend WithEvents ClockEndTime As DataGridViewTextBoxColumn
    Friend WithEvents MemoDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
