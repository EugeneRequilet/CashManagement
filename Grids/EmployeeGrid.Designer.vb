<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class EmployeeGrid
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
        Me.CodeDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Description = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EmployeeTypeDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IDNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DateStartedDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HomeTelephoneDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CellNumberDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.InactiveEmployeeDescription = New System.Windows.Forms.DataGridViewTextBoxColumn()
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
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CodeDataGridViewTextBoxColumn, Me.Description, Me.EmployeeTypeDescription, Me.IDNumberDataGridViewTextBoxColumn, Me.DateStartedDataGridViewTextBoxColumn, Me.HomeTelephoneDataGridViewTextBoxColumn, Me.CellNumberDataGridViewTextBoxColumn, Me.InactiveEmployeeDescription})
        Me.DataGridView1.DataSource = Me.BindingSource1
        Me.DataGridView1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DataGridView1.Location = New System.Drawing.Point(0, 0)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.Size = New System.Drawing.Size(859, 254)
        Me.DataGridView1.TabIndex = 1
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.EmployeeView)
        '
        'CodeDataGridViewTextBoxColumn
        '
        Me.CodeDataGridViewTextBoxColumn.DataPropertyName = "Code"
        Me.CodeDataGridViewTextBoxColumn.HeaderText = "Code"
        Me.CodeDataGridViewTextBoxColumn.MaxInputLength = 5
        Me.CodeDataGridViewTextBoxColumn.MinimumWidth = 60
        Me.CodeDataGridViewTextBoxColumn.Name = "CodeDataGridViewTextBoxColumn"
        Me.CodeDataGridViewTextBoxColumn.ReadOnly = True
        Me.CodeDataGridViewTextBoxColumn.Width = 60
        '
        'Description
        '
        Me.Description.DataPropertyName = "Description"
        Me.Description.HeaderText = "Full Name"
        Me.Description.Name = "Description"
        Me.Description.ReadOnly = True
        Me.Description.Width = 79
        '
        'EmployeeTypeDescription
        '
        Me.EmployeeTypeDescription.DataPropertyName = "EmployeeTypeDescription"
        Me.EmployeeTypeDescription.HeaderText = "Type"
        Me.EmployeeTypeDescription.Name = "EmployeeTypeDescription"
        Me.EmployeeTypeDescription.ReadOnly = True
        Me.EmployeeTypeDescription.Width = 56
        '
        'IDNumberDataGridViewTextBoxColumn
        '
        Me.IDNumberDataGridViewTextBoxColumn.DataPropertyName = "IDNumber"
        Me.IDNumberDataGridViewTextBoxColumn.HeaderText = "ID Number"
        Me.IDNumberDataGridViewTextBoxColumn.MaxInputLength = 20
        Me.IDNumberDataGridViewTextBoxColumn.Name = "IDNumberDataGridViewTextBoxColumn"
        Me.IDNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.IDNumberDataGridViewTextBoxColumn.Width = 83
        '
        'DateStartedDataGridViewTextBoxColumn
        '
        Me.DateStartedDataGridViewTextBoxColumn.DataPropertyName = "DateStarted"
        Me.DateStartedDataGridViewTextBoxColumn.HeaderText = "Date Started"
        Me.DateStartedDataGridViewTextBoxColumn.MaxInputLength = 15
        Me.DateStartedDataGridViewTextBoxColumn.Name = "DateStartedDataGridViewTextBoxColumn"
        Me.DateStartedDataGridViewTextBoxColumn.ReadOnly = True
        Me.DateStartedDataGridViewTextBoxColumn.Width = 92
        '
        'HomeTelephoneDataGridViewTextBoxColumn
        '
        Me.HomeTelephoneDataGridViewTextBoxColumn.DataPropertyName = "HomeTelephone"
        Me.HomeTelephoneDataGridViewTextBoxColumn.HeaderText = "Home Telephone"
        Me.HomeTelephoneDataGridViewTextBoxColumn.MaxInputLength = 15
        Me.HomeTelephoneDataGridViewTextBoxColumn.Name = "HomeTelephoneDataGridViewTextBoxColumn"
        Me.HomeTelephoneDataGridViewTextBoxColumn.ReadOnly = True
        Me.HomeTelephoneDataGridViewTextBoxColumn.Width = 105
        '
        'CellNumberDataGridViewTextBoxColumn
        '
        Me.CellNumberDataGridViewTextBoxColumn.DataPropertyName = "CellNumber"
        Me.CellNumberDataGridViewTextBoxColumn.HeaderText = "Cell Number"
        Me.CellNumberDataGridViewTextBoxColumn.MaxInputLength = 15
        Me.CellNumberDataGridViewTextBoxColumn.Name = "CellNumberDataGridViewTextBoxColumn"
        Me.CellNumberDataGridViewTextBoxColumn.ReadOnly = True
        Me.CellNumberDataGridViewTextBoxColumn.Width = 82
        '
        'InactiveEmployeeDescription
        '
        Me.InactiveEmployeeDescription.DataPropertyName = "InactiveEmployeeDescription"
        Me.InactiveEmployeeDescription.HeaderText = "Status"
        Me.InactiveEmployeeDescription.Name = "InactiveEmployeeDescription"
        Me.InactiveEmployeeDescription.ReadOnly = True
        Me.InactiveEmployeeDescription.Width = 62
        '
        'EmployeeGrid
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.DataGridView1)
        Me.Name = "EmployeeGrid"
        Me.Size = New System.Drawing.Size(859, 254)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents DataGridView1 As System.Windows.Forms.DataGridView
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents CodeDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents Description As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents EmployeeTypeDescription As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents IDNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents DateStartedDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents HomeTelephoneDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents CellNumberDataGridViewTextBoxColumn As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents InactiveEmployeeDescription As System.Windows.Forms.DataGridViewTextBoxColumn

End Class
