<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateInventoryForm
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
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtSellingPrice = New CashManagement.NumericTextBox()
        Me.txtCostPrice = New CashManagement.NumericTextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnSelectSupplier = New System.Windows.Forms.Button()
        Me.txtSupplierName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.SupplierViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.SupplierViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(383, 220)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 5
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(296, 220)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 4
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Inventory)
        '
        'txtDescription
        '
        Me.txtDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Description", True))
        Me.txtDescription.Location = New System.Drawing.Point(107, 12)
        Me.txtDescription.MaxLength = 50
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(341, 20)
        Me.txtDescription.TabIndex = 2
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Description"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Cost Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 13)
        Me.Label3.TabIndex = 6
        Me.Label3.Text = "Selling Price"
        '
        'txtSellingPrice
        '
        Me.txtSellingPrice.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "SellingPrice", True))
        Me.txtSellingPrice.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSellingPrice.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtSellingPrice.IsReadOnly = False
        Me.txtSellingPrice.Location = New System.Drawing.Point(107, 75)
        Me.txtSellingPrice.MaxLength = 15
        Me.txtSellingPrice.Name = "txtSellingPrice"
        Me.txtSellingPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtSellingPrice.TabIndex = 7
        '
        'txtCostPrice
        '
        Me.txtCostPrice.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "CostPrice", True))
        Me.txtCostPrice.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostPrice.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCostPrice.IsReadOnly = False
        Me.txtCostPrice.Location = New System.Drawing.Point(107, 43)
        Me.txtCostPrice.MaxLength = 15
        Me.txtCostPrice.Name = "txtCostPrice"
        Me.txtCostPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtCostPrice.TabIndex = 3
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSelectSupplier)
        Me.GroupBox2.Controls.Add(Me.txtSupplierName)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Location = New System.Drawing.Point(15, 112)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(441, 84)
        Me.GroupBox2.TabIndex = 8
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Supplier Selection"
        '
        'btnSelectSupplier
        '
        Me.btnSelectSupplier.Location = New System.Drawing.Point(6, 0)
        Me.btnSelectSupplier.Name = "btnSelectSupplier"
        Me.btnSelectSupplier.Size = New System.Drawing.Size(106, 23)
        Me.btnSelectSupplier.TabIndex = 1
        Me.btnSelectSupplier.Text = "Select Supplier"
        Me.btnSelectSupplier.UseVisualStyleBackColor = True
        '
        'txtSupplierName
        '
        Me.txtSupplierName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.SupplierViewBindingSource, "Description", True))
        Me.txtSupplierName.Location = New System.Drawing.Point(92, 40)
        Me.txtSupplierName.MaxLength = 20
        Me.txtSupplierName.Name = "txtSupplierName"
        Me.txtSupplierName.ReadOnly = True
        Me.txtSupplierName.Size = New System.Drawing.Size(341, 20)
        Me.txtSupplierName.TabIndex = 0
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(6, 43)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(45, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Supplier"
        '
        'SupplierViewBindingSource
        '
        Me.SupplierViewBindingSource.DataSource = GetType(CashManagement.SupplierView)
        '
        'UpdateInventoryForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(470, 255)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.txtSellingPrice)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtCostPrice)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Name = "UpdateInventoryForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Inventory"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.SupplierViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtCostPrice As CashManagement.NumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtSellingPrice As CashManagement.NumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelectSupplier As System.Windows.Forms.Button
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SupplierViewBindingSource As System.Windows.Forms.BindingSource
End Class
