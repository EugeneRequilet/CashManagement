<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class DebtorGrid
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CashInTillLessFloatDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PayoutReason1 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SalesTypeDescDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentTypeDescDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeNameDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.CashInTillLessFloatDataGridViewTextBoxColumn, Me.PayoutReason1, Me.SalesTypeDescDataGridViewTextBoxColumn, Me.PaymentTypeDescDataGridViewTextBoxColumn, Me.EmployeeNameDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(884, 424)
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
        'CashInTillLessFloatDataGridViewTextBoxColumn
        '
        Me.CashInTillLessFloatDataGridViewTextBoxColumn.DataPropertyName = "CashInTillLessFloat"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "n2"
        Me.CashInTillLessFloatDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.CashInTillLessFloatDataGridViewTextBoxColumn.HeaderText = "Income Amount"
        Me.CashInTillLessFloatDataGridViewTextBoxColumn.Name = "CashInTillLessFloatDataGridViewTextBoxColumn"
        Me.CashInTillLessFloatDataGridViewTextBoxColumn.ReadOnly = True
        Me.CashInTillLessFloatDataGridViewTextBoxColumn.Width = 97
        '
        'PayoutReason1
        '
        Me.PayoutReason1.DataPropertyName = "PayoutReason1"
        Me.PayoutReason1.HeaderText = "Reason"
        Me.PayoutReason1.Name = "PayoutReason1"
        Me.PayoutReason1.ReadOnly = True
        Me.PayoutReason1.Width = 69
        '
        'SalesTypeDescDataGridViewTextBoxColumn
        '
        Me.SalesTypeDescDataGridViewTextBoxColumn.DataPropertyName = "SalesTypeDesc"
        Me.SalesTypeDescDataGridViewTextBoxColumn.HeaderText = "Sales Type"
        Me.SalesTypeDescDataGridViewTextBoxColumn.Name = "SalesTypeDescDataGridViewTextBoxColumn"
        Me.SalesTypeDescDataGridViewTextBoxColumn.ReadOnly = True
        Me.SalesTypeDescDataGridViewTextBoxColumn.Width = 78
        '
        'PaymentTypeDescDataGridViewTextBoxColumn
        '
        Me.PaymentTypeDescDataGridViewTextBoxColumn.DataPropertyName = "PaymentTypeDesc"
        Me.PaymentTypeDescDataGridViewTextBoxColumn.HeaderText = "Payment Type"
        Me.PaymentTypeDescDataGridViewTextBoxColumn.Name = "PaymentTypeDescDataGridViewTextBoxColumn"
        Me.PaymentTypeDescDataGridViewTextBoxColumn.ReadOnly = True
        Me.PaymentTypeDescDataGridViewTextBoxColumn.Width = 92
        '
        'EmployeeNameDataGridViewTextBoxColumn
        '
        Me.EmployeeNameDataGridViewTextBoxColumn.DataPropertyName = "EmployeeName"
        Me.EmployeeNameDataGridViewTextBoxColumn.HeaderText = "Employee"
        Me.EmployeeNameDataGridViewTextBoxColumn.Name = "EmployeeNameDataGridViewTextBoxColumn"
        Me.EmployeeNameDataGridViewTextBoxColumn.ReadOnly = True
        Me.EmployeeNameDataGridViewTextBoxColumn.Width = 78
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.CashupView)
        '
        'DebtorGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "DebtorGrid"
        Me.Size = New System.Drawing.Size(884, 424)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BindingSource1 As BindingSource
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CashInTillLessFloatDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PayoutReason1 As DataGridViewTextBoxColumn
    Friend WithEvents SalesTypeDescDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents PaymentTypeDescDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeNameDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
