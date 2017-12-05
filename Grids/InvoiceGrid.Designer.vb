<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class InvoiceGrid
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.DateDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocumentTypeDesc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DocumentNumber = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InvoiceAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CreditNoteAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PaymentAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdjustmentAmount = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Memo = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierName = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeName = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DateDataGridViewTextBoxColumn, Me.DocumentTypeDesc, Me.DocumentNumber, Me.InvoiceAmount, Me.CreditNoteAmount, Me.PaymentAmount, Me.AdjustmentAmount, Me.Memo, Me.SupplierName, Me.EmployeeName})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(1023, 326)
        Me.DataGridView1.TabIndex = 2
        '
        'DateDataGridViewTextBoxColumn
        '
        Me.DateDataGridViewTextBoxColumn.DataPropertyName = "Date"
        Me.DateDataGridViewTextBoxColumn.HeaderText = "Date"
        Me.DateDataGridViewTextBoxColumn.MinimumWidth = 65
        Me.DateDataGridViewTextBoxColumn.Name = "DateDataGridViewTextBoxColumn"
        Me.DateDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateDataGridViewTextBoxColumn.Width = 65
        '
        'DocumentTypeDesc
        '
        Me.DocumentTypeDesc.DataPropertyName = "DocumentTypeDesc"
        Me.DocumentTypeDesc.HeaderText = "Type"
        Me.DocumentTypeDesc.Name = "DocumentTypeDesc"
        Me.DocumentTypeDesc.ReadOnly = True
        Me.DocumentTypeDesc.Width = 56
        '
        'DocumentNumber
        '
        Me.DocumentNumber.DataPropertyName = "DocumentNumber"
        Me.DocumentNumber.HeaderText = "Document Number"
        Me.DocumentNumber.Name = "DocumentNumber"
        Me.DocumentNumber.ReadOnly = True
        Me.DocumentNumber.Width = 111
        '
        'InvoiceAmount
        '
        Me.InvoiceAmount.DataPropertyName = "InvoiceAmount"
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle2.Format = "N2"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.InvoiceAmount.DefaultCellStyle = DataGridViewCellStyle2
        Me.InvoiceAmount.HeaderText = "Invoice"
        Me.InvoiceAmount.Name = "InvoiceAmount"
        Me.InvoiceAmount.ReadOnly = True
        Me.InvoiceAmount.Width = 67
        '
        'CreditNoteAmount
        '
        Me.CreditNoteAmount.DataPropertyName = "CreditNoteAmount"
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.Format = "N2"
        DataGridViewCellStyle3.NullValue = Nothing
        Me.CreditNoteAmount.DefaultCellStyle = DataGridViewCellStyle3
        Me.CreditNoteAmount.HeaderText = "Credit Note"
        Me.CreditNoteAmount.Name = "CreditNoteAmount"
        Me.CreditNoteAmount.ReadOnly = True
        Me.CreditNoteAmount.Width = 78
        '
        'PaymentAmount
        '
        Me.PaymentAmount.DataPropertyName = "PaymentAmount"
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle4.Format = "N2"
        DataGridViewCellStyle4.NullValue = Nothing
        Me.PaymentAmount.DefaultCellStyle = DataGridViewCellStyle4
        Me.PaymentAmount.HeaderText = "Payment"
        Me.PaymentAmount.Name = "PaymentAmount"
        Me.PaymentAmount.ReadOnly = True
        Me.PaymentAmount.Width = 73
        '
        'AdjustmentAmount
        '
        Me.AdjustmentAmount.DataPropertyName = "AdjustmentAmount"
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle5.ForeColor = System.Drawing.Color.Red
        DataGridViewCellStyle5.Format = "N2"
        DataGridViewCellStyle5.NullValue = Nothing
        DataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Red
        Me.AdjustmentAmount.DefaultCellStyle = DataGridViewCellStyle5
        Me.AdjustmentAmount.HeaderText = "Adjustment"
        Me.AdjustmentAmount.Name = "AdjustmentAmount"
        Me.AdjustmentAmount.ReadOnly = True
        Me.AdjustmentAmount.Width = 84
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
        'SupplierName
        '
        Me.SupplierName.DataPropertyName = "SupplierName"
        Me.SupplierName.HeaderText = "Supplier"
        Me.SupplierName.Name = "SupplierName"
        Me.SupplierName.ReadOnly = True
        Me.SupplierName.Width = 70
        '
        'EmployeeName
        '
        Me.EmployeeName.DataPropertyName = "EmployeeName"
        Me.EmployeeName.HeaderText = "Employee"
        Me.EmployeeName.Name = "EmployeeName"
        Me.EmployeeName.ReadOnly = True
        Me.EmployeeName.Width = 78
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.InvoiceView)
        '
        'InvoiceGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "InvoiceGrid"
        Me.Size = New System.Drawing.Size(1023, 326)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocumentTypeDesc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DocumentNumber As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InvoiceAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CreditNoteAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PaymentAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents AdjustmentAmount As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Memo As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents SupplierName As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeName As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
