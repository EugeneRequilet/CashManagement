<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateSupplierForm
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
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtCellNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHomeTelephone = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.PhysicalToPostalButton = New System.Windows.Forms.Button()
        Me.PostalToPhysicalButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtPostalAddressPostalCode = New System.Windows.Forms.TextBox()
        Me.txtPostalAddress3 = New System.Windows.Forms.TextBox()
        Me.txtPostalAddress2 = New System.Windows.Forms.TextBox()
        Me.txtPostalAddress1 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtPhysicalAddressPostalCode = New System.Windows.Forms.TextBox()
        Me.txtPhysicalAddress3 = New System.Windows.Forms.TextBox()
        Me.txtPhysicalAddress2 = New System.Windows.Forms.TextBox()
        Me.txtPhysicalAddress1 = New System.Windows.Forms.TextBox()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.ckbInactiveSupplier = New System.Windows.Forms.CheckBox()
        Me.ckbCOS = New System.Windows.Forms.CheckBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'txtDescription
        '
        Me.txtDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Description", True))
        Me.txtDescription.Location = New System.Drawing.Point(113, 12)
        Me.txtDescription.MaxLength = 30
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(341, 20)
        Me.txtDescription.TabIndex = 11
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Supplier)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(18, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(45, 13)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Supplier"
        '
        'txtCellNumber
        '
        Me.txtCellNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "CellNumber", True))
        Me.txtCellNumber.Location = New System.Drawing.Point(113, 102)
        Me.txtCellNumber.MaxLength = 15
        Me.txtCellNumber.Name = "txtCellNumber"
        Me.txtCellNumber.Size = New System.Drawing.Size(151, 20)
        Me.txtCellNumber.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(18, 106)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 14
        Me.Label6.Text = "Cell Number"
        '
        'txtHomeTelephone
        '
        Me.txtHomeTelephone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Telephone", True))
        Me.txtHomeTelephone.Location = New System.Drawing.Point(113, 71)
        Me.txtHomeTelephone.MaxLength = 15
        Me.txtHomeTelephone.Name = "txtHomeTelephone"
        Me.txtHomeTelephone.Size = New System.Drawing.Size(151, 20)
        Me.txtHomeTelephone.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(18, 75)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(58, 13)
        Me.Label5.TabIndex = 13
        Me.Label5.Text = "Telephone"
        '
        'PhysicalToPostalButton
        '
        Me.PhysicalToPostalButton.Location = New System.Drawing.Point(194, 256)
        Me.PhysicalToPostalButton.Name = "PhysicalToPostalButton"
        Me.PhysicalToPostalButton.Size = New System.Drawing.Size(26, 23)
        Me.PhysicalToPostalButton.TabIndex = 20
        Me.PhysicalToPostalButton.Text = ">"
        Me.PhysicalToPostalButton.UseVisualStyleBackColor = True
        '
        'PostalToPhysicalButton
        '
        Me.PostalToPhysicalButton.Location = New System.Drawing.Point(244, 256)
        Me.PostalToPhysicalButton.Name = "PostalToPhysicalButton"
        Me.PostalToPhysicalButton.Size = New System.Drawing.Size(26, 23)
        Me.PostalToPhysicalButton.TabIndex = 19
        Me.PostalToPhysicalButton.Text = "<"
        Me.PostalToPhysicalButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPostalAddressPostalCode)
        Me.GroupBox2.Controls.Add(Me.txtPostalAddress3)
        Me.GroupBox2.Controls.Add(Me.txtPostalAddress2)
        Me.GroupBox2.Controls.Add(Me.txtPostalAddress1)
        Me.GroupBox2.Location = New System.Drawing.Point(21, 280)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(432, 103)
        Me.GroupBox2.TabIndex = 18
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Postal Address"
        '
        'txtPostalAddressPostalCode
        '
        Me.txtPostalAddressPostalCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PostalCode", True))
        Me.txtPostalAddressPostalCode.Location = New System.Drawing.Point(316, 77)
        Me.txtPostalAddressPostalCode.MaxLength = 4
        Me.txtPostalAddressPostalCode.Name = "txtPostalAddressPostalCode"
        Me.txtPostalAddressPostalCode.Size = New System.Drawing.Size(100, 20)
        Me.txtPostalAddressPostalCode.TabIndex = 7
        '
        'txtPostalAddress3
        '
        Me.txtPostalAddress3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PostalAddress3", True))
        Me.txtPostalAddress3.Location = New System.Drawing.Point(18, 77)
        Me.txtPostalAddress3.MaxLength = 30
        Me.txtPostalAddress3.Name = "txtPostalAddress3"
        Me.txtPostalAddress3.Size = New System.Drawing.Size(280, 20)
        Me.txtPostalAddress3.TabIndex = 6
        '
        'txtPostalAddress2
        '
        Me.txtPostalAddress2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PostalAddress2", True))
        Me.txtPostalAddress2.Location = New System.Drawing.Point(18, 45)
        Me.txtPostalAddress2.MaxLength = 30
        Me.txtPostalAddress2.Name = "txtPostalAddress2"
        Me.txtPostalAddress2.Size = New System.Drawing.Size(395, 20)
        Me.txtPostalAddress2.TabIndex = 5
        '
        'txtPostalAddress1
        '
        Me.txtPostalAddress1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PostalAddress1", True))
        Me.txtPostalAddress1.Location = New System.Drawing.Point(18, 19)
        Me.txtPostalAddress1.MaxLength = 30
        Me.txtPostalAddress1.Name = "txtPostalAddress1"
        Me.txtPostalAddress1.Size = New System.Drawing.Size(395, 20)
        Me.txtPostalAddress1.TabIndex = 4
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtPhysicalAddressPostalCode)
        Me.GroupBox1.Controls.Add(Me.txtPhysicalAddress3)
        Me.GroupBox1.Controls.Add(Me.txtPhysicalAddress2)
        Me.GroupBox1.Controls.Add(Me.txtPhysicalAddress1)
        Me.GroupBox1.Location = New System.Drawing.Point(21, 141)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 109)
        Me.GroupBox1.TabIndex = 17
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Physical Address"
        '
        'txtPhysicalAddressPostalCode
        '
        Me.txtPhysicalAddressPostalCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PhysicalCode", True))
        Me.txtPhysicalAddressPostalCode.Location = New System.Drawing.Point(313, 83)
        Me.txtPhysicalAddressPostalCode.MaxLength = 4
        Me.txtPhysicalAddressPostalCode.Name = "txtPhysicalAddressPostalCode"
        Me.txtPhysicalAddressPostalCode.Size = New System.Drawing.Size(100, 20)
        Me.txtPhysicalAddressPostalCode.TabIndex = 3
        '
        'txtPhysicalAddress3
        '
        Me.txtPhysicalAddress3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PhysicalAddress3", True))
        Me.txtPhysicalAddress3.Location = New System.Drawing.Point(18, 83)
        Me.txtPhysicalAddress3.MaxLength = 30
        Me.txtPhysicalAddress3.Name = "txtPhysicalAddress3"
        Me.txtPhysicalAddress3.Size = New System.Drawing.Size(280, 20)
        Me.txtPhysicalAddress3.TabIndex = 2
        '
        'txtPhysicalAddress2
        '
        Me.txtPhysicalAddress2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PhysicalAddress2", True))
        Me.txtPhysicalAddress2.Location = New System.Drawing.Point(18, 50)
        Me.txtPhysicalAddress2.MaxLength = 30
        Me.txtPhysicalAddress2.Name = "txtPhysicalAddress2"
        Me.txtPhysicalAddress2.Size = New System.Drawing.Size(395, 20)
        Me.txtPhysicalAddress2.TabIndex = 1
        '
        'txtPhysicalAddress1
        '
        Me.txtPhysicalAddress1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "PhysicalAddress1", True))
        Me.txtPhysicalAddress1.Location = New System.Drawing.Point(18, 18)
        Me.txtPhysicalAddress1.MaxLength = 30
        Me.txtPhysicalAddress1.Name = "txtPhysicalAddress1"
        Me.txtPhysicalAddress1.Size = New System.Drawing.Size(395, 20)
        Me.txtPhysicalAddress1.TabIndex = 0
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(390, 395)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 22
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(303, 395)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 21
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'ckbInactiveSupplier
        '
        Me.ckbInactiveSupplier.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckbInactiveSupplier.AutoSize = True
        Me.ckbInactiveSupplier.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "InactiveSupplier", True))
        Me.ckbInactiveSupplier.Location = New System.Drawing.Point(18, 399)
        Me.ckbInactiveSupplier.Name = "ckbInactiveSupplier"
        Me.ckbInactiveSupplier.Size = New System.Drawing.Size(105, 17)
        Me.ckbInactiveSupplier.TabIndex = 23
        Me.ckbInactiveSupplier.Text = "Inactive Supplier"
        Me.ckbInactiveSupplier.UseVisualStyleBackColor = True
        '
        'ckbCOS
        '
        Me.ckbCOS.AutoSize = True
        Me.ckbCOS.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "COS", True))
        Me.ckbCOS.Location = New System.Drawing.Point(114, 43)
        Me.ckbCOS.Name = "ckbCOS"
        Me.ckbCOS.Size = New System.Drawing.Size(86, 17)
        Me.ckbCOS.TabIndex = 24
        Me.ckbCOS.Text = "Select If Yes"
        Me.ckbCOS.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(18, 44)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(71, 13)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Cost Of Sales"
        '
        'UpdateSupplierForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(480, 430)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ckbCOS)
        Me.Controls.Add(Me.ckbInactiveSupplier)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.PhysicalToPostalButton)
        Me.Controls.Add(Me.PostalToPhysicalButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.txtCellNumber)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtHomeTelephone)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UpdateSupplierForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Supplier"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents txtCellNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHomeTelephone As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents PhysicalToPostalButton As System.Windows.Forms.Button
    Friend WithEvents PostalToPhysicalButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPostalAddressPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPostalAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPostalAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPostalAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPhysicalAddressPostalCode As System.Windows.Forms.TextBox
    Friend WithEvents txtPhysicalAddress3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPhysicalAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPhysicalAddress1 As System.Windows.Forms.TextBox
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents ckbInactiveSupplier As System.Windows.Forms.CheckBox
    Friend WithEvents ckbCOS As CheckBox
    Friend WithEvents Label2 As Label
End Class
