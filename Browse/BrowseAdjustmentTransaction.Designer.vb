<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseAdjustmentTransaction
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
        Me.ChangeButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.InsertButton = New System.Windows.Forms.Button()
        Me.HeaderGroupBox = New System.Windows.Forms.GroupBox()
        Me.btnBrowseAdjustment = New System.Windows.Forms.Button()
        Me.txtHeaderDoucmentType = New System.Windows.Forms.TextBox()
        Me.AdjustmentViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.txtHeaderDate = New System.Windows.Forms.TextBox()
        Me.txtSupplierDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHeaderMemo = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHeaderAdjustmentAmount = New CashManagement.NumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHeaderInvoiceNumber = New System.Windows.Forms.TextBox()
        Me.AdjustmentTransactionViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AdjustmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ExcelButton = New System.Windows.Forms.Button()
        Me.NextButton = New System.Windows.Forms.Button()
        Me.AdjustmentTransactionGrid1 = New CashManagement.AdjustmentTransactionGrid()
        Me.HeaderGroupBox.SuspendLayout()
        CType(Me.AdjustmentViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdjustmentTransactionViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdjustmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChangeButton
        '
        Me.ChangeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeButton.Location = New System.Drawing.Point(497, 556)
        Me.ChangeButton.Name = "ChangeButton"
        Me.ChangeButton.Size = New System.Drawing.Size(75, 23)
        Me.ChangeButton.TabIndex = 13
        Me.ChangeButton.Text = "&Change"
        Me.ChangeButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Location = New System.Drawing.Point(663, 556)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 12
        Me.CloseButton.Text = "Cl&ose"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'DeleteButton
        '
        Me.DeleteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteButton.Location = New System.Drawing.Point(580, 556)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
        Me.DeleteButton.TabIndex = 11
        Me.DeleteButton.Text = "&Delete"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'InsertButton
        '
        Me.InsertButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InsertButton.Location = New System.Drawing.Point(413, 556)
        Me.InsertButton.Name = "InsertButton"
        Me.InsertButton.Size = New System.Drawing.Size(75, 23)
        Me.InsertButton.TabIndex = 10
        Me.InsertButton.Text = "&Insert"
        Me.InsertButton.UseVisualStyleBackColor = True
        '
        'HeaderGroupBox
        '
        Me.HeaderGroupBox.Controls.Add(Me.btnBrowseAdjustment)
        Me.HeaderGroupBox.Controls.Add(Me.txtHeaderDoucmentType)
        Me.HeaderGroupBox.Controls.Add(Me.txtHeaderDate)
        Me.HeaderGroupBox.Controls.Add(Me.txtSupplierDescription)
        Me.HeaderGroupBox.Controls.Add(Me.Label1)
        Me.HeaderGroupBox.Controls.Add(Me.Label3)
        Me.HeaderGroupBox.Controls.Add(Me.txtHeaderMemo)
        Me.HeaderGroupBox.Controls.Add(Me.Label8)
        Me.HeaderGroupBox.Controls.Add(Me.Label4)
        Me.HeaderGroupBox.Controls.Add(Me.txtHeaderAdjustmentAmount)
        Me.HeaderGroupBox.Controls.Add(Me.Label2)
        Me.HeaderGroupBox.Controls.Add(Me.Label12)
        Me.HeaderGroupBox.Controls.Add(Me.txtHeaderInvoiceNumber)
        Me.HeaderGroupBox.Location = New System.Drawing.Point(14, 12)
        Me.HeaderGroupBox.Name = "HeaderGroupBox"
        Me.HeaderGroupBox.Size = New System.Drawing.Size(720, 118)
        Me.HeaderGroupBox.TabIndex = 39
        Me.HeaderGroupBox.TabStop = False
        Me.HeaderGroupBox.Text = "Adjustment Header"
        '
        'btnBrowseAdjustment
        '
        Me.btnBrowseAdjustment.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBrowseAdjustment.Location = New System.Drawing.Point(545, 17)
        Me.btnBrowseAdjustment.Name = "btnBrowseAdjustment"
        Me.btnBrowseAdjustment.Size = New System.Drawing.Size(154, 23)
        Me.btnBrowseAdjustment.TabIndex = 40
        Me.btnBrowseAdjustment.Text = "Select Adjustment"
        Me.btnBrowseAdjustment.UseVisualStyleBackColor = True
        '
        'txtHeaderDoucmentType
        '
        Me.txtHeaderDoucmentType.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdjustmentViewBindingSource, "DocumentTypeDesc", True))
        Me.txtHeaderDoucmentType.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderDoucmentType.Location = New System.Drawing.Point(446, 48)
        Me.txtHeaderDoucmentType.MaxLength = 20
        Me.txtHeaderDoucmentType.Name = "txtHeaderDoucmentType"
        Me.txtHeaderDoucmentType.ReadOnly = True
        Me.txtHeaderDoucmentType.Size = New System.Drawing.Size(87, 20)
        Me.txtHeaderDoucmentType.TabIndex = 39
        '
        'AdjustmentViewBindingSource
        '
        Me.AdjustmentViewBindingSource.DataSource = GetType(CashManagement.AdjustmentView)
        '
        'txtHeaderDate
        '
        Me.txtHeaderDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdjustmentViewBindingSource, "Date", True))
        Me.txtHeaderDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderDate.Location = New System.Drawing.Point(54, 48)
        Me.txtHeaderDate.MaxLength = 20
        Me.txtHeaderDate.Name = "txtHeaderDate"
        Me.txtHeaderDate.ReadOnly = True
        Me.txtHeaderDate.Size = New System.Drawing.Size(94, 20)
        Me.txtHeaderDate.TabIndex = 38
        '
        'txtSupplierDescription
        '
        Me.txtSupplierDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdjustmentViewBindingSource, "SupplierName", True))
        Me.txtSupplierDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSupplierDescription.Location = New System.Drawing.Point(91, 18)
        Me.txtSupplierDescription.MaxLength = 30
        Me.txtSupplierDescription.Name = "txtSupplierDescription"
        Me.txtSupplierDescription.ReadOnly = True
        Me.txtSupplierDescription.Size = New System.Drawing.Size(442, 20)
        Me.txtSupplierDescription.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 51)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Supplier"
        '
        'txtHeaderMemo
        '
        Me.txtHeaderMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdjustmentViewBindingSource, "Memo", True))
        Me.txtHeaderMemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderMemo.Location = New System.Drawing.Point(54, 81)
        Me.txtHeaderMemo.MaxLength = 30
        Me.txtHeaderMemo.Name = "txtHeaderMemo"
        Me.txtHeaderMemo.ReadOnly = True
        Me.txtHeaderMemo.Size = New System.Drawing.Size(643, 20)
        Me.txtHeaderMemo.TabIndex = 36
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(349, 52)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(83, 13)
        Me.Label8.TabIndex = 27
        Me.Label8.Text = "Document Type"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Memo"
        '
        'txtHeaderAdjustmentAmount
        '
        Me.txtHeaderAdjustmentAmount.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.AdjustmentViewBindingSource, "Amount", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.txtHeaderAdjustmentAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHeaderAdjustmentAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderAdjustmentAmount.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtHeaderAdjustmentAmount.IsReadOnly = True
        Me.txtHeaderAdjustmentAmount.Location = New System.Drawing.Point(607, 48)
        Me.txtHeaderAdjustmentAmount.MaxLength = 15
        Me.txtHeaderAdjustmentAmount.Name = "txtHeaderAdjustmentAmount"
        Me.txtHeaderAdjustmentAmount.Size = New System.Drawing.Size(90, 20)
        Me.txtHeaderAdjustmentAmount.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(157, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Original Invoice"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(537, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Adjustment"
        '
        'txtHeaderInvoiceNumber
        '
        Me.txtHeaderInvoiceNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdjustmentViewBindingSource, "InvoiceNumber", True))
        Me.txtHeaderInvoiceNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderInvoiceNumber.Location = New System.Drawing.Point(245, 48)
        Me.txtHeaderInvoiceNumber.MaxLength = 20
        Me.txtHeaderInvoiceNumber.Name = "txtHeaderInvoiceNumber"
        Me.txtHeaderInvoiceNumber.ReadOnly = True
        Me.txtHeaderInvoiceNumber.Size = New System.Drawing.Size(89, 20)
        Me.txtHeaderInvoiceNumber.TabIndex = 34
        '
        'AdjustmentTransactionViewBindingSource
        '
        Me.AdjustmentTransactionViewBindingSource.DataSource = GetType(CashManagement.AdjustmentTransactionView)
        '
        'AdjustmentBindingSource
        '
        Me.AdjustmentBindingSource.DataSource = GetType(CashManagement.AdjustmentRequested)
        '
        'ExcelButton
        '
        Me.ExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExcelButton.Location = New System.Drawing.Point(12, 556)
        Me.ExcelButton.Name = "ExcelButton"
        Me.ExcelButton.Size = New System.Drawing.Size(75, 23)
        Me.ExcelButton.TabIndex = 40
        Me.ExcelButton.Text = "&Excel Export"
        Me.ExcelButton.UseVisualStyleBackColor = True
        '
        'NextButton
        '
        Me.NextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NextButton.Location = New System.Drawing.Point(93, 556)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(75, 23)
        Me.NextButton.TabIndex = 43
        Me.NextButton.Text = "&Next"
        Me.NextButton.UseVisualStyleBackColor = True
        Me.NextButton.Visible = False
        '
        'AdjustmentTransactionGrid1
        '
        Me.AdjustmentTransactionGrid1.Location = New System.Drawing.Point(12, 136)
        Me.AdjustmentTransactionGrid1.Name = "AdjustmentTransactionGrid1"
        Me.AdjustmentTransactionGrid1.Size = New System.Drawing.Size(722, 404)
        Me.AdjustmentTransactionGrid1.TabIndex = 14
        '
        'BrowseAdjustmentTransaction
        '
        Me.AcceptButton = Me.ChangeButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(750, 591)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.ExcelButton)
        Me.Controls.Add(Me.HeaderGroupBox)
        Me.Controls.Add(Me.AdjustmentTransactionGrid1)
        Me.Controls.Add(Me.ChangeButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.InsertButton)
        Me.KeyPreview = True
        Me.Name = "BrowseAdjustmentTransaction"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Adjustment Transaction"
        Me.HeaderGroupBox.ResumeLayout(False)
        Me.HeaderGroupBox.PerformLayout()
        CType(Me.AdjustmentViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdjustmentTransactionViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdjustmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChangeButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.Button
    Friend WithEvents InsertButton As System.Windows.Forms.Button
    Friend WithEvents AdjustmentTransactionGrid1 As CashManagement.AdjustmentTransactionGrid
    Friend WithEvents HeaderGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents txtHeaderDoucmentType As System.Windows.Forms.TextBox
    Friend WithEvents txtHeaderDate As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHeaderMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHeaderAdjustmentAmount As CashManagement.NumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtHeaderInvoiceNumber As System.Windows.Forms.TextBox
    Friend WithEvents btnBrowseAdjustment As System.Windows.Forms.Button
    Friend WithEvents AdjustmentViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents txtSupplierDescription As System.Windows.Forms.TextBox
    Friend WithEvents AdjustmentTransactionViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents AdjustmentBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ExcelButton As System.Windows.Forms.Button
    Friend WithEvents NextButton As System.Windows.Forms.Button
End Class
