<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseAttachment
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
        Me.ExcelButton = New System.Windows.Forms.Button()
        Me.ChangeButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.InsertButton = New System.Windows.Forms.Button()
        Me.AssetViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AttachmentViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AttachmentBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HeaderGroupBox = New System.Windows.Forms.GroupBox()
        Me.txtBranchCode = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtSerialNumber = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.txtPurchasedDate = New System.Windows.Forms.TextBox()
        Me.txtAssetDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtAssetMemo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtPurchasedAmount = New CashManagement.NumericTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.AttachmentGrid1 = New CashManagement.AttachmentGrid()
        CType(Me.AssetViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AttachmentViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AttachmentBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HeaderGroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'ExcelButton
        '
        Me.ExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExcelButton.Location = New System.Drawing.Point(12, 504)
        Me.ExcelButton.Name = "ExcelButton"
        Me.ExcelButton.Size = New System.Drawing.Size(75, 23)
        Me.ExcelButton.TabIndex = 47
        Me.ExcelButton.Text = "&Excel Export"
        Me.ExcelButton.UseVisualStyleBackColor = True
        '
        'ChangeButton
        '
        Me.ChangeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeButton.Location = New System.Drawing.Point(576, 504)
        Me.ChangeButton.Name = "ChangeButton"
        Me.ChangeButton.Size = New System.Drawing.Size(75, 23)
        Me.ChangeButton.TabIndex = 46
        Me.ChangeButton.Text = "&Change"
        Me.ChangeButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Location = New System.Drawing.Point(742, 504)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 45
        Me.CloseButton.Text = "Cl&ose"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'DeleteButton
        '
        Me.DeleteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteButton.Location = New System.Drawing.Point(659, 504)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
        Me.DeleteButton.TabIndex = 44
        Me.DeleteButton.Text = "&Delete"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'InsertButton
        '
        Me.InsertButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InsertButton.Location = New System.Drawing.Point(492, 504)
        Me.InsertButton.Name = "InsertButton"
        Me.InsertButton.Size = New System.Drawing.Size(75, 23)
        Me.InsertButton.TabIndex = 43
        Me.InsertButton.Text = "&Insert"
        Me.InsertButton.UseVisualStyleBackColor = True
        '
        'AssetViewBindingSource
        '
        Me.AssetViewBindingSource.DataSource = GetType(CashManagement.AssetView)
        '
        'AttachmentViewBindingSource
        '
        Me.AttachmentViewBindingSource.DataSource = GetType(CashManagement.AttachmentView)
        '
        'AttachmentBindingSource
        '
        Me.AttachmentBindingSource.DataSource = GetType(CashManagement.Attachment)
        '
        'HeaderGroupBox
        '
        Me.HeaderGroupBox.Controls.Add(Me.txtBranchCode)
        Me.HeaderGroupBox.Controls.Add(Me.Label2)
        Me.HeaderGroupBox.Controls.Add(Me.txtSerialNumber)
        Me.HeaderGroupBox.Controls.Add(Me.Label5)
        Me.HeaderGroupBox.Controls.Add(Me.txtPurchasedDate)
        Me.HeaderGroupBox.Controls.Add(Me.txtAssetDescription)
        Me.HeaderGroupBox.Controls.Add(Me.Label1)
        Me.HeaderGroupBox.Controls.Add(Me.Label3)
        Me.HeaderGroupBox.Controls.Add(Me.txtAssetMemo)
        Me.HeaderGroupBox.Controls.Add(Me.Label4)
        Me.HeaderGroupBox.Controls.Add(Me.txtPurchasedAmount)
        Me.HeaderGroupBox.Controls.Add(Me.Label12)
        Me.HeaderGroupBox.Location = New System.Drawing.Point(14, 12)
        Me.HeaderGroupBox.Name = "HeaderGroupBox"
        Me.HeaderGroupBox.Size = New System.Drawing.Size(803, 168)
        Me.HeaderGroupBox.TabIndex = 48
        Me.HeaderGroupBox.TabStop = False
        Me.HeaderGroupBox.Text = "Asset Header"
        '
        'txtBranchCode
        '
        Me.txtBranchCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AssetViewBindingSource, "BranchCode", True))
        Me.txtBranchCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchCode.Location = New System.Drawing.Point(106, 15)
        Me.txtBranchCode.MaxLength = 30
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.ReadOnly = True
        Me.txtBranchCode.Size = New System.Drawing.Size(94, 20)
        Me.txtBranchCode.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(41, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Branch"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AssetViewBindingSource, "SerialNumber", True))
        Me.txtSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(106, 70)
        Me.txtSerialNumber.MaxLength = 30
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.ReadOnly = True
        Me.txtSerialNumber.Size = New System.Drawing.Size(442, 20)
        Me.txtSerialNumber.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 77)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Serial Number"
        '
        'txtPurchasedDate
        '
        Me.txtPurchasedDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AssetViewBindingSource, "PurchaseDate", True))
        Me.txtPurchasedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurchasedDate.Location = New System.Drawing.Point(106, 101)
        Me.txtPurchasedDate.MaxLength = 20
        Me.txtPurchasedDate.Name = "txtPurchasedDate"
        Me.txtPurchasedDate.ReadOnly = True
        Me.txtPurchasedDate.Size = New System.Drawing.Size(94, 20)
        Me.txtPurchasedDate.TabIndex = 38
        '
        'txtAssetDescription
        '
        Me.txtAssetDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AssetViewBindingSource, "Description", True))
        Me.txtAssetDescription.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetDescription.Location = New System.Drawing.Point(106, 41)
        Me.txtAssetDescription.MaxLength = 30
        Me.txtAssetDescription.Name = "txtAssetDescription"
        Me.txtAssetDescription.ReadOnly = True
        Me.txtAssetDescription.Size = New System.Drawing.Size(442, 20)
        Me.txtAssetDescription.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 104)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Purchased Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 47)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Asset"
        '
        'txtAssetMemo
        '
        Me.txtAssetMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AssetViewBindingSource, "Memo", True))
        Me.txtAssetMemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetMemo.Location = New System.Drawing.Point(106, 131)
        Me.txtAssetMemo.MaxLength = 30
        Me.txtAssetMemo.Name = "txtAssetMemo"
        Me.txtAssetMemo.ReadOnly = True
        Me.txtAssetMemo.Size = New System.Drawing.Size(677, 20)
        Me.txtAssetMemo.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 136)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Memo"
        '
        'txtPurchasedAmount
        '
        Me.txtPurchasedAmount.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.AssetViewBindingSource, "PurchaseAmount", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N2"))
        Me.txtPurchasedAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPurchasedAmount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurchasedAmount.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPurchasedAmount.IsReadOnly = True
        Me.txtPurchasedAmount.Location = New System.Drawing.Point(693, 104)
        Me.txtPurchasedAmount.MaxLength = 15
        Me.txtPurchasedAmount.Name = "txtPurchasedAmount"
        Me.txtPurchasedAmount.Size = New System.Drawing.Size(90, 20)
        Me.txtPurchasedAmount.TabIndex = 35
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(590, 107)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Purchased Amount"
        '
        'AttachmentGrid1
        '
        Me.AttachmentGrid1.Location = New System.Drawing.Point(14, 186)
        Me.AttachmentGrid1.Name = "AttachmentGrid1"
        Me.AttachmentGrid1.Size = New System.Drawing.Size(803, 309)
        Me.AttachmentGrid1.TabIndex = 49
        '
        'BrowseAttachment
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(833, 539)
        Me.Controls.Add(Me.AttachmentGrid1)
        Me.Controls.Add(Me.HeaderGroupBox)
        Me.Controls.Add(Me.ExcelButton)
        Me.Controls.Add(Me.ChangeButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.InsertButton)
        Me.Name = "BrowseAttachment"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Attachment"
        CType(Me.AssetViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AttachmentViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AttachmentBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HeaderGroupBox.ResumeLayout(False)
        Me.HeaderGroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents ExcelButton As Button
    Friend WithEvents ChangeButton As Button
    Friend WithEvents CloseButton As Button
    Friend WithEvents DeleteButton As Button
    Friend WithEvents InsertButton As Button
    Friend WithEvents AssetViewBindingSource As BindingSource
    Friend WithEvents AttachmentViewBindingSource As BindingSource
    Friend WithEvents AttachmentBindingSource As BindingSource
    Friend WithEvents HeaderGroupBox As GroupBox
    Friend WithEvents txtBranchCode As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtSerialNumber As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents txtPurchasedDate As TextBox
    Friend WithEvents txtAssetDescription As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents txtAssetMemo As TextBox
    Friend WithEvents Label4 As Label
    Friend WithEvents txtPurchasedAmount As NumericTextBox
    Friend WithEvents Label12 As Label
    Friend WithEvents AttachmentGrid1 As AttachmentGrid
End Class
