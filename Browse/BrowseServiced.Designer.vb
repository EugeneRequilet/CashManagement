<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseServiced
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
        Me.txtBranchCode = New System.Windows.Forms.TextBox()
        Me.AssetViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtServicedValue = New CashManagement.NumericTextBox()
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
        Me.ServicedGrid1 = New CashManagement.ServicedGrid()
        Me.ExcelButton = New System.Windows.Forms.Button()
        Me.ServicedViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.ServicedBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.HeaderGroupBox.SuspendLayout()
        CType(Me.AssetViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServicedViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ServicedBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.HeaderGroupBox.Controls.Add(Me.txtBranchCode)
        Me.HeaderGroupBox.Controls.Add(Me.Label6)
        Me.HeaderGroupBox.Controls.Add(Me.txtServicedValue)
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
        Me.HeaderGroupBox.Location = New System.Drawing.Point(12, 12)
        Me.HeaderGroupBox.Name = "HeaderGroupBox"
        Me.HeaderGroupBox.Size = New System.Drawing.Size(720, 173)
        Me.HeaderGroupBox.TabIndex = 40
        Me.HeaderGroupBox.TabStop = False
        Me.HeaderGroupBox.Text = "Asset Header"
        '
        'txtBranchCode
        '
        Me.txtBranchCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AssetViewBindingSource, "BranchCode", True))
        Me.txtBranchCode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBranchCode.Location = New System.Drawing.Point(106, 16)
        Me.txtBranchCode.MaxLength = 30
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.ReadOnly = True
        Me.txtBranchCode.Size = New System.Drawing.Size(94, 20)
        Me.txtBranchCode.TabIndex = 45
        '
        'AssetViewBindingSource
        '
        Me.AssetViewBindingSource.DataSource = GetType(CashManagement.AssetView)
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(41, 13)
        Me.Label6.TabIndex = 44
        Me.Label6.Text = "Branch"
        '
        'txtServicedValue
        '
        Me.txtServicedValue.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtServicedValue.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtServicedValue.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtServicedValue.IsReadOnly = True
        Me.txtServicedValue.Location = New System.Drawing.Point(612, 105)
        Me.txtServicedValue.MaxLength = 15
        Me.txtServicedValue.Name = "txtServicedValue"
        Me.txtServicedValue.Size = New System.Drawing.Size(90, 20)
        Me.txtServicedValue.TabIndex = 43
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(533, 108)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 42
        Me.Label2.Text = "Service Value"
        '
        'txtSerialNumber
        '
        Me.txtSerialNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AssetViewBindingSource, "SerialNumber", True))
        Me.txtSerialNumber.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSerialNumber.Location = New System.Drawing.Point(106, 75)
        Me.txtSerialNumber.MaxLength = 30
        Me.txtSerialNumber.Name = "txtSerialNumber"
        Me.txtSerialNumber.ReadOnly = True
        Me.txtSerialNumber.Size = New System.Drawing.Size(442, 20)
        Me.txtSerialNumber.TabIndex = 41
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 78)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(73, 13)
        Me.Label5.TabIndex = 40
        Me.Label5.Text = "Serial Number"
        '
        'txtPurchasedDate
        '
        Me.txtPurchasedDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AssetViewBindingSource, "PurchaseDate", True))
        Me.txtPurchasedDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPurchasedDate.Location = New System.Drawing.Point(106, 105)
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
        Me.txtAssetDescription.Location = New System.Drawing.Point(106, 45)
        Me.txtAssetDescription.MaxLength = 30
        Me.txtAssetDescription.Name = "txtAssetDescription"
        Me.txtAssetDescription.ReadOnly = True
        Me.txtAssetDescription.Size = New System.Drawing.Size(442, 20)
        Me.txtAssetDescription.TabIndex = 37
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 108)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 26
        Me.Label1.Text = "Purchased Date"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(33, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Asset"
        '
        'txtAssetMemo
        '
        Me.txtAssetMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AssetViewBindingSource, "Memo", True))
        Me.txtAssetMemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAssetMemo.Location = New System.Drawing.Point(106, 135)
        Me.txtAssetMemo.MaxLength = 30
        Me.txtAssetMemo.Name = "txtAssetMemo"
        Me.txtAssetMemo.ReadOnly = True
        Me.txtAssetMemo.Size = New System.Drawing.Size(596, 20)
        Me.txtAssetMemo.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 140)
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
        Me.txtPurchasedAmount.Location = New System.Drawing.Point(327, 105)
        Me.txtPurchasedAmount.MaxLength = 15
        Me.txtPurchasedAmount.Name = "txtPurchasedAmount"
        Me.txtPurchasedAmount.Size = New System.Drawing.Size(90, 20)
        Me.txtPurchasedAmount.TabIndex = 35
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(224, 108)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(97, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Purchased Amount"
        '
        'ServicedGrid1
        '
        Me.ServicedGrid1.Location = New System.Drawing.Point(13, 191)
        Me.ServicedGrid1.Name = "ServicedGrid1"
        Me.ServicedGrid1.Size = New System.Drawing.Size(719, 351)
        Me.ServicedGrid1.TabIndex = 41
        '
        'ExcelButton
        '
        Me.ExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExcelButton.Location = New System.Drawing.Point(12, 556)
        Me.ExcelButton.Name = "ExcelButton"
        Me.ExcelButton.Size = New System.Drawing.Size(75, 23)
        Me.ExcelButton.TabIndex = 42
        Me.ExcelButton.Text = "&Excel Export"
        Me.ExcelButton.UseVisualStyleBackColor = True
        '
        'ServicedViewBindingSource
        '
        Me.ServicedViewBindingSource.DataSource = GetType(CashManagement.ServicedView)
        '
        'ServicedBindingSource
        '
        Me.ServicedBindingSource.DataSource = GetType(CashManagement.Serviced)
        '
        'BrowseServiced
        '
        Me.AcceptButton = Me.ChangeButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(750, 591)
        Me.Controls.Add(Me.ExcelButton)
        Me.Controls.Add(Me.ServicedGrid1)
        Me.Controls.Add(Me.HeaderGroupBox)
        Me.Controls.Add(Me.ChangeButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.InsertButton)
        Me.KeyPreview = True
        Me.Name = "BrowseServiced"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Serviced"
        Me.HeaderGroupBox.ResumeLayout(False)
        Me.HeaderGroupBox.PerformLayout()
        CType(Me.AssetViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServicedViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ServicedBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChangeButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.Button
    Friend WithEvents InsertButton As System.Windows.Forms.Button
    Friend WithEvents AssetViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ServicedViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents HeaderGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents txtPurchasedDate As System.Windows.Forms.TextBox
    Friend WithEvents txtAssetDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtAssetMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPurchasedAmount As CashManagement.NumericTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtSerialNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents ServicedGrid1 As CashManagement.ServicedGrid
    Friend WithEvents txtServicedValue As CashManagement.NumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ServicedBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents ExcelButton As System.Windows.Forms.Button
    Friend WithEvents txtBranchCode As TextBox
    Friend WithEvents Label6 As Label
End Class
