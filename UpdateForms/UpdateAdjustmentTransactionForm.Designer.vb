<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateAdjustmentTransactionForm
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
        Me.AdjustmentTransactionBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtInventoryItem = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.btnInventoryItem = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtCalcAmount = New CashManagement.NumericTextBox()
        Me.txtQuantity = New CashManagement.NumericTextBox()
        Me.txtCostPrice = New CashManagement.NumericTextBox()
        Me.InventoryBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnNewAdjustment = New System.Windows.Forms.Button()
        Me.AdjustmentViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AdjustmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AdjustmentTransactionViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.AdjustmentTransactionBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.InventoryBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdjustmentViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdjustmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdjustmentTransactionViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(486, 204)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(399, 204)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'AdjustmentTransactionBindingSource
        '
        Me.AdjustmentTransactionBindingSource.DataSource = GetType(CashManagement.AdjustmentTransaction)
        '
        'txtMemo
        '
        Me.txtMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdjustmentTransactionBindingSource, "Memo", True))
        Me.txtMemo.Location = New System.Drawing.Point(108, 137)
        Me.txtMemo.MaxLength = 20
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(425, 20)
        Me.txtMemo.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(26, 141)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(36, 13)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Memo"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(26, 84)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(55, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Cost Price"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(26, 57)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Quantity"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(26, 112)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(43, 13)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Amount"
        '
        'txtInventoryItem
        '
        Me.txtInventoryItem.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdjustmentTransactionBindingSource, "InventoryDescription", True))
        Me.txtInventoryItem.Location = New System.Drawing.Point(108, 24)
        Me.txtInventoryItem.MaxLength = 20
        Me.txtInventoryItem.Name = "txtInventoryItem"
        Me.txtInventoryItem.ReadOnly = True
        Me.txtInventoryItem.Size = New System.Drawing.Size(244, 20)
        Me.txtInventoryItem.TabIndex = 6
        Me.txtInventoryItem.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(26, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(74, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Inventory Item"
        '
        'btnInventoryItem
        '
        Me.btnInventoryItem.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnInventoryItem.Location = New System.Drawing.Point(376, 23)
        Me.btnInventoryItem.Name = "btnInventoryItem"
        Me.btnInventoryItem.Size = New System.Drawing.Size(154, 23)
        Me.btnInventoryItem.TabIndex = 5
        Me.btnInventoryItem.Text = "Select Inventory Item"
        Me.btnInventoryItem.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnInventoryItem)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtInventoryItem)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.txtCalcAmount)
        Me.GroupBox1.Controls.Add(Me.txtMemo)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.txtQuantity)
        Me.GroupBox1.Controls.Add(Me.txtCostPrice)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(547, 178)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Adjustment Item"
        '
        'txtCalcAmount
        '
        Me.txtCalcAmount.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.AdjustmentTransactionBindingSource, "CalcAmount", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.txtCalcAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCalcAmount.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCalcAmount.IsReadOnly = True
        Me.txtCalcAmount.Location = New System.Drawing.Point(108, 108)
        Me.txtCalcAmount.MaxLength = 15
        Me.txtCalcAmount.Name = "txtCalcAmount"
        Me.txtCalcAmount.Size = New System.Drawing.Size(100, 20)
        Me.txtCalcAmount.TabIndex = 9
        Me.txtCalcAmount.TabStop = False
        '
        'txtQuantity
        '
        Me.txtQuantity.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.AdjustmentTransactionBindingSource, "Quantity", True))
        Me.txtQuantity.EditValue = 0
        Me.txtQuantity.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtQuantity.IsReadOnly = False
        Me.txtQuantity.Location = New System.Drawing.Point(108, 53)
        Me.txtQuantity.MaxLength = 15
        Me.txtQuantity.Name = "txtQuantity"
        Me.txtQuantity.Size = New System.Drawing.Size(100, 20)
        Me.txtQuantity.TabIndex = 7
        '
        'txtCostPrice
        '
        Me.txtCostPrice.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.AdjustmentTransactionBindingSource, "CostPrice", True))
        Me.txtCostPrice.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCostPrice.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCostPrice.IsReadOnly = False
        Me.txtCostPrice.Location = New System.Drawing.Point(108, 80)
        Me.txtCostPrice.MaxLength = 15
        Me.txtCostPrice.Name = "txtCostPrice"
        Me.txtCostPrice.Size = New System.Drawing.Size(100, 20)
        Me.txtCostPrice.TabIndex = 8
        '
        'InventoryBindingSource
        '
        Me.InventoryBindingSource.DataSource = GetType(CashManagement.Inventory)
        '
        'btnNewAdjustment
        '
        Me.btnNewAdjustment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnNewAdjustment.Location = New System.Drawing.Point(12, 204)
        Me.btnNewAdjustment.Name = "btnNewAdjustment"
        Me.btnNewAdjustment.Size = New System.Drawing.Size(154, 23)
        Me.btnNewAdjustment.TabIndex = 11
        Me.btnNewAdjustment.Text = "Select New Adjustment Item"
        Me.btnNewAdjustment.UseVisualStyleBackColor = True
        '
        'AdjustmentViewBindingSource
        '
        Me.AdjustmentViewBindingSource.DataSource = GetType(CashManagement.AdjustmentView)
        '
        'AdjustmentBindingSource
        '
        Me.AdjustmentBindingSource.DataSource = GetType(CashManagement.AdjustmentRequested)
        '
        'AdjustmentTransactionViewBindingSource
        '
        Me.AdjustmentTransactionViewBindingSource.DataSource = GetType(CashManagement.AdjustmentTransactionView)
        '
        'UpdateAdjustmentTransactionForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(573, 239)
        Me.Controls.Add(Me.btnNewAdjustment)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Name = "UpdateAdjustmentTransactionForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjustment Transaction"
        CType(Me.AdjustmentTransactionBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.InventoryBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdjustmentViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdjustmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdjustmentTransactionViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents txtCostPrice As CashManagement.NumericTextBox
    Friend WithEvents txtQuantity As CashManagement.NumericTextBox
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtCalcAmount As CashManagement.NumericTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AdjustmentTransactionBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents txtInventoryItem As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnInventoryItem As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents InventoryBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents btnNewAdjustment As System.Windows.Forms.Button
    Friend WithEvents AdjustmentViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdjustmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdjustmentTransactionViewBindingSource As System.Windows.Forms.BindingSource
End Class
