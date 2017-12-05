<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyShiftHeaderGrid
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
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DayOfWeekDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ShiftsDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DailyRateAdjustmentDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Memo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.DailyShiftHeaderView)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.DayOfWeekDataGridViewTextBoxColumn, Me.ShiftsDataGridViewTextBoxColumn, Me.DailyRateAdjustmentDescription, Me.Memo, Me.EmployeeName})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(735, 314)
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
        'DayOfWeekDataGridViewTextBoxColumn
        '
        Me.DayOfWeekDataGridViewTextBoxColumn.DataPropertyName = "DayOfWeek"
        Me.DayOfWeekDataGridViewTextBoxColumn.HeaderText = "Day Of Week"
        Me.DayOfWeekDataGridViewTextBoxColumn.Name = "DayOfWeekDataGridViewTextBoxColumn"
        Me.DayOfWeekDataGridViewTextBoxColumn.ReadOnly = True
        Me.DayOfWeekDataGridViewTextBoxColumn.Width = 97
        '
        'ShiftsDataGridViewTextBoxColumn
        '
        Me.ShiftsDataGridViewTextBoxColumn.DataPropertyName = "Shifts"
        Me.ShiftsDataGridViewTextBoxColumn.HeaderText = "Shifts"
        Me.ShiftsDataGridViewTextBoxColumn.Name = "ShiftsDataGridViewTextBoxColumn"
        Me.ShiftsDataGridViewTextBoxColumn.ReadOnly = True
        Me.ShiftsDataGridViewTextBoxColumn.Width = 58
        '
        'DailyRateAdjustmentDescription
        '
        Me.DailyRateAdjustmentDescription.DataPropertyName = "DailyRateAdjustmentDescription"
        Me.DailyRateAdjustmentDescription.HeaderText = "Rate"
        Me.DailyRateAdjustmentDescription.Name = "DailyRateAdjustmentDescription"
        Me.DailyRateAdjustmentDescription.ReadOnly = True
        Me.DailyRateAdjustmentDescription.Width = 55
        '
        'Memo
        '
        Me.Memo.DataPropertyName = "Memo"
        Me.Memo.HeaderText = "Memo"
        Me.Memo.MinimumWidth = 200
        Me.Memo.Name = "Memo"
        Me.Memo.ReadOnly = True
        Me.Memo.Width = 200
        '
        'EmployeeName
        '
        Me.EmployeeName.DataPropertyName = "EmployeeName"
        Me.EmployeeName.HeaderText = "Employee"
        Me.EmployeeName.Name = "EmployeeName"
        Me.EmployeeName.ReadOnly = True
        Me.EmployeeName.Width = 78
        '
        'DailyShiftHeaderGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "DailyShiftHeaderGrid"
        Me.Size = New System.Drawing.Size(735, 314)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DayOfWeekDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftsDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DailyRateAdjustmentDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Memo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeName As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
