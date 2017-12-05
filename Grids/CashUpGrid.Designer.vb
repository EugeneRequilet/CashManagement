<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashUpGrid
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
        Dim DataGridViewCellStyle6 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle7 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle8 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.TimeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CashInTillLessFloat = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepReducedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepIncreasedBy = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CashDeposited = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentTypeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreditCardDeposited = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DepositSkims = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Payouts = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Variance = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.TimeDesc, Me.EmployeeName, Me.CashInTillLessFloat, Me.DepReducedBy, Me.DepIncreasedBy, Me.CashDeposited, Me.PaymentTypeDesc, Me.CreditCardDeposited, Me.DepositSkims, Me.Payouts, Me.Variance})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1055, 426)
        Me.DataGridView1.TabIndex = 3
        '
        'TimeDesc
        '
        Me.TimeDesc.DataPropertyName = "TimeDesc"
        Me.TimeDesc.HeaderText = "Time"
        Me.TimeDesc.Name = "TimeDesc"
        Me.TimeDesc.ReadOnly = True
        Me.TimeDesc.Width = 55
        '
        'EmployeeName
        '
        Me.EmployeeName.DataPropertyName = "EmployeeName"
        Me.EmployeeName.HeaderText = "Employee"
        Me.EmployeeName.Name = "EmployeeName"
        Me.EmployeeName.ReadOnly = True
        Me.EmployeeName.Width = 78
        '
        'CashInTillLessFloat
        '
        Me.CashInTillLessFloat.DataPropertyName = "CashInTillLessFloat"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.CashInTillLessFloat.DefaultCellStyle = DataGridViewCellStyle2
        Me.CashInTillLessFloat.HeaderText = "Cash Less Float"
        Me.CashInTillLessFloat.Name = "CashInTillLessFloat"
        Me.CashInTillLessFloat.ReadOnly = True
        Me.CashInTillLessFloat.Width = 98
        '
        'DepReducedBy
        '
        Me.DepReducedBy.DataPropertyName = "DepReducedBy"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.DepReducedBy.DefaultCellStyle = DataGridViewCellStyle3
        Me.DepReducedBy.HeaderText = "Deposit Reduced By"
        Me.DepReducedBy.Name = "DepReducedBy"
        Me.DepReducedBy.ReadOnly = True
        Me.DepReducedBy.Width = 108
        '
        'DepIncreasedBy
        '
        Me.DepIncreasedBy.DataPropertyName = "DepIncreasedBy"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DepIncreasedBy.DefaultCellStyle = DataGridViewCellStyle4
        Me.DepIncreasedBy.HeaderText = "Deposit Increased By"
        Me.DepIncreasedBy.Name = "DepIncreasedBy"
        Me.DepIncreasedBy.ReadOnly = True
        Me.DepIncreasedBy.Width = 111
        '
        'CashDeposited
        '
        Me.CashDeposited.DataPropertyName = "CashDeposited"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.CashDeposited.DefaultCellStyle = DataGridViewCellStyle5
        Me.CashDeposited.HeaderText = "Cash"
        Me.CashDeposited.Name = "CashDeposited"
        Me.CashDeposited.ReadOnly = True
        Me.CashDeposited.Width = 56
        '
        'PaymentTypeDesc
        '
        Me.PaymentTypeDesc.DataPropertyName = "PaymentTypeDesc"
        Me.PaymentTypeDesc.HeaderText = "Where Held"
        Me.PaymentTypeDesc.Name = "PaymentTypeDesc"
        Me.PaymentTypeDesc.ReadOnly = True
        Me.PaymentTypeDesc.Width = 82
        '
        'CreditCardDeposited
        '
        Me.CreditCardDeposited.DataPropertyName = "CreditCardDeposited"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.CreditCardDeposited.DefaultCellStyle = DataGridViewCellStyle6
        Me.CreditCardDeposited.HeaderText = "C/C Deposited"
        Me.CreditCardDeposited.Name = "CreditCardDeposited"
        Me.CreditCardDeposited.ReadOnly = True
        Me.CreditCardDeposited.Width = 94
        '
        'DepositSkims
        '
        Me.DepositSkims.DataPropertyName = "DepositSkims"
        DataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle7.Format = "N2"
        DataGridViewCellStyle7.NullValue = Nothing
        Me.DepositSkims.DefaultCellStyle = DataGridViewCellStyle7
        Me.DepositSkims.HeaderText = "Skims"
        Me.DepositSkims.Name = "DepositSkims"
        Me.DepositSkims.ReadOnly = True
        Me.DepositSkims.Width = 60
        '
        'Payouts
        '
        Me.Payouts.DataPropertyName = "Payouts"
        DataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle8.Format = "N2"
        DataGridViewCellStyle8.NullValue = Nothing
        Me.Payouts.DefaultCellStyle = DataGridViewCellStyle8
        Me.Payouts.HeaderText = "Payouts"
        Me.Payouts.Name = "Payouts"
        Me.Payouts.ReadOnly = True
        Me.Payouts.Width = 70
        '
        'Variance
        '
        Me.Variance.DataPropertyName = "Variance"
        DataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle9.Format = "N2"
        DataGridViewCellStyle9.NullValue = Nothing
        Me.Variance.DefaultCellStyle = DataGridViewCellStyle9
        Me.Variance.HeaderText = "Variance"
        Me.Variance.Name = "Variance"
        Me.Variance.ReadOnly = True
        Me.Variance.Width = 74
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.Width = 55
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.CashupView)
        '
        'CashUpGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "CashUpGrid"
        Me.Size = New System.Drawing.Size(1055, 426)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DataGridViewTextBoxColumn1 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PayoutDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn2 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn3 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn4 As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents OverbakePercent100DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents WastagePercent100DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DamagePercent100DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StaffPercent100DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DiscountPercent20DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SamplePercent100DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents StockVarianceValueDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TimeDesc As DataGridViewTextBoxColumn
    Friend WithEvents EmployeeName As DataGridViewTextBoxColumn
    Friend WithEvents CashInTillLessFloat As DataGridViewTextBoxColumn
    Friend WithEvents DepReducedBy As DataGridViewTextBoxColumn
    Friend WithEvents DepIncreasedBy As DataGridViewTextBoxColumn
    Friend WithEvents CashDeposited As DataGridViewTextBoxColumn
    Friend WithEvents PaymentTypeDesc As DataGridViewTextBoxColumn
    Friend WithEvents CreditCardDeposited As DataGridViewTextBoxColumn
    Friend WithEvents DepositSkims As DataGridViewTextBoxColumn
    Friend WithEvents Payouts As DataGridViewTextBoxColumn
    Friend WithEvents Variance As DataGridViewTextBoxColumn
End Class
