<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyShiftGrid
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.ShiftDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.StartTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EndTimeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HoursDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ThisShiftEmployee = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.ShiftDescription, Me.StartTimeDataGridViewTextBoxColumn, Me.EndTimeDataGridViewTextBoxColumn, Me.HoursDataGridViewTextBoxColumn, Me.ThisShiftEmployee})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(613, 447)
        Me.DataGridView1.TabIndex = 0
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.DailyShiftView)
        '
        'ShiftDescription
        '
        Me.ShiftDescription.DataPropertyName = "ShiftDescription"
        Me.ShiftDescription.HeaderText = "Shift Description"
        Me.ShiftDescription.Name = "ShiftDescription"
        Me.ShiftDescription.ReadOnly = True
        '
        'StartTimeDataGridViewTextBoxColumn
        '
        Me.StartTimeDataGridViewTextBoxColumn.DataPropertyName = "StartTime"
        DataGridViewCellStyle2.Format = "t"
        Me.StartTimeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.StartTimeDataGridViewTextBoxColumn.HeaderText = "Start Time"
        Me.StartTimeDataGridViewTextBoxColumn.Name = "StartTimeDataGridViewTextBoxColumn"
        Me.StartTimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.StartTimeDataGridViewTextBoxColumn.Width = 74
        '
        'EndTimeDataGridViewTextBoxColumn
        '
        Me.EndTimeDataGridViewTextBoxColumn.DataPropertyName = "EndTime"
        DataGridViewCellStyle3.Format = "t"
        Me.EndTimeDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.EndTimeDataGridViewTextBoxColumn.HeaderText = "End Time"
        Me.EndTimeDataGridViewTextBoxColumn.Name = "EndTimeDataGridViewTextBoxColumn"
        Me.EndTimeDataGridViewTextBoxColumn.ReadOnly = True
        Me.EndTimeDataGridViewTextBoxColumn.Width = 71
        '
        'HoursDataGridViewTextBoxColumn
        '
        Me.HoursDataGridViewTextBoxColumn.DataPropertyName = "Hours"
        Me.HoursDataGridViewTextBoxColumn.HeaderText = "Hours"
        Me.HoursDataGridViewTextBoxColumn.Name = "HoursDataGridViewTextBoxColumn"
        Me.HoursDataGridViewTextBoxColumn.ReadOnly = True
        Me.HoursDataGridViewTextBoxColumn.Width = 60
        '
        'ThisShiftEmployee
        '
        Me.ThisShiftEmployee.DataPropertyName = "ThisShiftEmployee"
        Me.ThisShiftEmployee.HeaderText = "This Shift Employee"
        Me.ThisShiftEmployee.Name = "ThisShiftEmployee"
        Me.ThisShiftEmployee.ReadOnly = True
        Me.ThisShiftEmployee.Width = 114
        '
        'DailyShiftGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "DailyShiftGrid"
        Me.Size = New System.Drawing.Size(613, 447)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ShiftDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StartTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EndTimeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HoursDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents ThisShiftEmployee As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
