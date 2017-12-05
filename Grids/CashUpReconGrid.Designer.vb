<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class CashUpReconGrid
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
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreditCardDepositedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreditCardReconciled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.CashDepositedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CashDepReconciled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DepositedSkim1DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Skims1Reconciled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DepositedSkim2DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Skims2Reconciled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        Me.DepositedSkim3DataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Skims3Reconciled = New System.Windows.Forms.DataGridViewCheckBoxColumn()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.CashupReconView)
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToOrderColumns = True
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.DataGridView1.AlternatingRowsDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.CreditCardDepositedDataGridViewTextBoxColumn, Me.CreditCardReconciled, Me.CashDepositedDataGridViewTextBoxColumn, Me.CashDepReconciled, Me.DepositedSkim1DataGridViewTextBoxColumn, Me.Skims1Reconciled, Me.DepositedSkim2DataGridViewTextBoxColumn, Me.Skims2Reconciled, Me.DepositedSkim3DataGridViewTextBoxColumn, Me.Skims3Reconciled})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(550, 426)
        Me.DataGridView1.TabIndex = 3
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.Width = 55
        '
        'CreditCardDepositedDataGridViewTextBoxColumn
        '
        Me.CreditCardDepositedDataGridViewTextBoxColumn.DataPropertyName = "CreditCardDeposited"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.CreditCardDepositedDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle2
        Me.CreditCardDepositedDataGridViewTextBoxColumn.HeaderText = "Credit Card"
        Me.CreditCardDepositedDataGridViewTextBoxColumn.Name = "CreditCardDepositedDataGridViewTextBoxColumn"
        Me.CreditCardDepositedDataGridViewTextBoxColumn.ReadOnly = True
        Me.CreditCardDepositedDataGridViewTextBoxColumn.Width = 84
        '
        'CreditCardReconciled
        '
        Me.CreditCardReconciled.DataPropertyName = "CreditCardReconciled"
        Me.CreditCardReconciled.HeaderText = "CC"
        Me.CreditCardReconciled.Name = "CreditCardReconciled"
        Me.CreditCardReconciled.ReadOnly = True
        Me.CreditCardReconciled.Width = 27
        '
        'CashDepositedDataGridViewTextBoxColumn
        '
        Me.CashDepositedDataGridViewTextBoxColumn.DataPropertyName = "CashDeposited"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CashDepositedDataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle3
        Me.CashDepositedDataGridViewTextBoxColumn.HeaderText = "Cash"
        Me.CashDepositedDataGridViewTextBoxColumn.Name = "CashDepositedDataGridViewTextBoxColumn"
        Me.CashDepositedDataGridViewTextBoxColumn.ReadOnly = True
        Me.CashDepositedDataGridViewTextBoxColumn.Width = 56
        '
        'CashDepReconciled
        '
        Me.CashDepReconciled.DataPropertyName = "CashDepReconciled"
        Me.CashDepReconciled.HeaderText = "C"
        Me.CashDepReconciled.Name = "CashDepReconciled"
        Me.CashDepReconciled.ReadOnly = True
        Me.CashDepReconciled.Width = 21
        '
        'DepositedSkim1DataGridViewTextBoxColumn
        '
        Me.DepositedSkim1DataGridViewTextBoxColumn.DataPropertyName = "DepositedSkim1"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.DepositedSkim1DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle4
        Me.DepositedSkim1DataGridViewTextBoxColumn.HeaderText = "Skim 1"
        Me.DepositedSkim1DataGridViewTextBoxColumn.Name = "DepositedSkim1DataGridViewTextBoxColumn"
        Me.DepositedSkim1DataGridViewTextBoxColumn.ReadOnly = True
        Me.DepositedSkim1DataGridViewTextBoxColumn.Width = 64
        '
        'Skims1Reconciled
        '
        Me.Skims1Reconciled.DataPropertyName = "Skims1Reconciled"
        Me.Skims1Reconciled.HeaderText = "1"
        Me.Skims1Reconciled.Name = "Skims1Reconciled"
        Me.Skims1Reconciled.ReadOnly = True
        Me.Skims1Reconciled.Width = 21
        '
        'DepositedSkim2DataGridViewTextBoxColumn
        '
        Me.DepositedSkim2DataGridViewTextBoxColumn.DataPropertyName = "DepositedSkim2"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        Me.DepositedSkim2DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle5
        Me.DepositedSkim2DataGridViewTextBoxColumn.HeaderText = "Skim 2"
        Me.DepositedSkim2DataGridViewTextBoxColumn.Name = "DepositedSkim2DataGridViewTextBoxColumn"
        Me.DepositedSkim2DataGridViewTextBoxColumn.ReadOnly = True
        Me.DepositedSkim2DataGridViewTextBoxColumn.Width = 64
        '
        'Skims2Reconciled
        '
        Me.Skims2Reconciled.DataPropertyName = "Skims2Reconciled"
        Me.Skims2Reconciled.HeaderText = "2"
        Me.Skims2Reconciled.Name = "Skims2Reconciled"
        Me.Skims2Reconciled.ReadOnly = True
        Me.Skims2Reconciled.Width = 21
        '
        'DepositedSkim3DataGridViewTextBoxColumn
        '
        Me.DepositedSkim3DataGridViewTextBoxColumn.DataPropertyName = "DepositedSkim3"
        DataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle6.Format = "N2"
        DataGridViewCellStyle6.NullValue = Nothing
        Me.DepositedSkim3DataGridViewTextBoxColumn.DefaultCellStyle = DataGridViewCellStyle6
        Me.DepositedSkim3DataGridViewTextBoxColumn.HeaderText = "Skim 3"
        Me.DepositedSkim3DataGridViewTextBoxColumn.Name = "DepositedSkim3DataGridViewTextBoxColumn"
        Me.DepositedSkim3DataGridViewTextBoxColumn.ReadOnly = True
        Me.DepositedSkim3DataGridViewTextBoxColumn.Width = 64
        '
        'Skims3Reconciled
        '
        Me.Skims3Reconciled.DataPropertyName = "Skims3Reconciled"
        Me.Skims3Reconciled.HeaderText = "3"
        Me.Skims3Reconciled.Name = "Skims3Reconciled"
        Me.Skims3Reconciled.ReadOnly = True
        Me.Skims3Reconciled.Width = 21
        '
        'CashUpReconGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "CashUpReconGrid"
        Me.Size = New System.Drawing.Size(550, 426)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
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
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditCardDepositedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditCardReconciled As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents CashDepositedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CashDepReconciled As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DepositedSkim1DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Skims1Reconciled As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DepositedSkim2DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Skims2Reconciled As System.Windows.Forms.DataGridViewCheckBoxColumn
    Friend WithEvents DepositedSkim3DataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Skims3Reconciled As System.Windows.Forms.DataGridViewCheckBoxColumn

End Class
