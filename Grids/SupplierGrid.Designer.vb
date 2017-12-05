<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class SupplierGrid
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
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.DescriptionDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TelephoneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CellNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ExpenseType = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InactiveSupplierDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DescriptionDataGridViewTextBoxColumn, Me.TelephoneDataGridViewTextBoxColumn, Me.CellNumberDataGridViewTextBoxColumn, Me.ExpenseType, Me.InactiveSupplierDescription})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(618, 326)
        Me.DataGridView1.TabIndex = 2
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.SupplierView)
        '
        'DescriptionDataGridViewTextBoxColumn
        '
        Me.DescriptionDataGridViewTextBoxColumn.DataPropertyName = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.HeaderText = "Description"
        Me.DescriptionDataGridViewTextBoxColumn.Name = "DescriptionDataGridViewTextBoxColumn"
        Me.DescriptionDataGridViewTextBoxColumn.ReadOnly = True
        Me.DescriptionDataGridViewTextBoxColumn.Width = 85
        '
        'TelephoneDataGridViewTextBoxColumn
        '
        Me.TelephoneDataGridViewTextBoxColumn.DataPropertyName = "Telephone"
        Me.TelephoneDataGridViewTextBoxColumn.HeaderText = "Telephone"
        Me.TelephoneDataGridViewTextBoxColumn.Name = "TelephoneDataGridViewTextBoxColumn"
        Me.TelephoneDataGridViewTextBoxColumn.ReadOnly = True
        Me.TelephoneDataGridViewTextBoxColumn.Width = 83
        '
        'CellNumberDataGridViewTextBoxColumn
        '
        Me.CellNumberDataGridViewTextBoxColumn.DataPropertyName = "CellNumber"
        Me.CellNumberDataGridViewTextBoxColumn.HeaderText = "Cell Number"
        Me.CellNumberDataGridViewTextBoxColumn.Name = "CellNumberDataGridViewTextBoxColumn"
        Me.CellNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.CellNumberDataGridViewTextBoxColumn.Width = 89
        '
        'ExpenseType
        '
        Me.ExpenseType.DataPropertyName = "ExpenseType"
        Me.ExpenseType.HeaderText = "Expense Type"
        Me.ExpenseType.Name = "ExpenseType"
        Me.ExpenseType.ReadOnly = True
        '
        'InactiveSupplierDescription
        '
        Me.InactiveSupplierDescription.DataPropertyName = "InactiveSupplierDescription"
        Me.InactiveSupplierDescription.HeaderText = "Status"
        Me.InactiveSupplierDescription.Name = "InactiveSupplierDescription"
        Me.InactiveSupplierDescription.ReadOnly = True
        Me.InactiveSupplierDescription.Width = 62
        '
        'SupplierGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "SupplierGrid"
        Me.Size = New System.Drawing.Size(618, 326)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents DateDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DescriptionDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TelephoneDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CellNumberDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ExpenseType As DataGridViewTextBoxColumn
    Friend WithEvents InactiveSupplierDescription As DataGridViewTextBoxColumn
End Class
