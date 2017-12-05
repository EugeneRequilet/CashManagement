<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateEmployeeForm
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
        Me.OkButton = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtFirstName = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtPassword = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtSurname = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.GeneralTab = New System.Windows.Forms.TabPage()
        Me.txtContactPhone = New System.Windows.Forms.TextBox()
        Me.Label22 = New System.Windows.Forms.Label()
        Me.txtContactRelationship = New System.Windows.Forms.TextBox()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.txtContactName = New System.Windows.Forms.TextBox()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.cboEmployeeType = New System.Windows.Forms.ComboBox()
        Me.txtCellNumber = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtHomeTelephone = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.ckbInactiveEmployee = New System.Windows.Forms.CheckBox()
        Me.AddressTab = New System.Windows.Forms.TabPage()
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
        Me.SalaryTab = New System.Windows.Forms.TabPage()
        Me.txtTaxNumber = New System.Windows.Forms.TextBox()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.dteDateStarted = New System.Windows.Forms.DateTimePicker()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cboMaritalStatus = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cboGender = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.txtIDNumber = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtNoOfDependants = New CashManagement.NumericTextBox()
        Me.txtRate = New CashManagement.NumericTextBox()
        Me.BankingTab = New System.Windows.Forms.TabPage()
        Me.txtAccountType = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtAccountNumber = New System.Windows.Forms.TextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtBranchNumber = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtBranchName = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtBankName = New System.Windows.Forms.TextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.ExcelButton = New System.Windows.Forms.Button()
        Me.txtBranchCode = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabControl1.SuspendLayout()
        Me.GeneralTab.SuspendLayout()
        Me.AddressTab.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.SalaryTab.SuspendLayout()
        Me.BankingTab.SuspendLayout()
        Me.SuspendLayout()
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(324, 314)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(411, 314)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(10, 48)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(57, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "First Name"
        '
        'txtFirstName
        '
        Me.txtFirstName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "FirstName", True))
        Me.txtFirstName.Location = New System.Drawing.Point(105, 44)
        Me.txtFirstName.MaxLength = 20
        Me.txtFirstName.Name = "txtFirstName"
        Me.txtFirstName.Size = New System.Drawing.Size(341, 20)
        Me.txtFirstName.TabIndex = 13
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Employee)
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(32, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Code"
        '
        'txtCode
        '
        Me.txtCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Code", True))
        Me.txtCode.Location = New System.Drawing.Point(105, 15)
        Me.txtCode.MaxLength = 5
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(100, 20)
        Me.txtCode.TabIndex = 11
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(230, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Password:"
        '
        'txtPassword
        '
        Me.txtPassword.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Password", True))
        Me.txtPassword.Location = New System.Drawing.Point(303, 16)
        Me.txtPassword.MaxLength = 20
        Me.txtPassword.Name = "txtPassword"
        Me.txtPassword.Size = New System.Drawing.Size(143, 20)
        Me.txtPassword.TabIndex = 12
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(10, 78)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(49, 13)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Surname"
        '
        'txtSurname
        '
        Me.txtSurname.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Surname", True))
        Me.txtSurname.Location = New System.Drawing.Point(105, 74)
        Me.txtSurname.MaxLength = 30
        Me.txtSurname.Name = "txtSurname"
        Me.txtSurname.Size = New System.Drawing.Size(341, 20)
        Me.txtSurname.TabIndex = 14
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.GeneralTab)
        Me.TabControl1.Controls.Add(Me.AddressTab)
        Me.TabControl1.Controls.Add(Me.SalaryTab)
        Me.TabControl1.Controls.Add(Me.BankingTab)
        Me.TabControl1.Location = New System.Drawing.Point(12, 10)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(473, 293)
        Me.TabControl1.TabIndex = 2
        '
        'GeneralTab
        '
        Me.GeneralTab.Controls.Add(Me.txtBranchCode)
        Me.GeneralTab.Controls.Add(Me.Label23)
        Me.GeneralTab.Controls.Add(Me.txtContactPhone)
        Me.GeneralTab.Controls.Add(Me.Label22)
        Me.GeneralTab.Controls.Add(Me.txtContactRelationship)
        Me.GeneralTab.Controls.Add(Me.Label21)
        Me.GeneralTab.Controls.Add(Me.txtContactName)
        Me.GeneralTab.Controls.Add(Me.Label20)
        Me.GeneralTab.Controls.Add(Me.Label18)
        Me.GeneralTab.Controls.Add(Me.cboEmployeeType)
        Me.GeneralTab.Controls.Add(Me.txtCellNumber)
        Me.GeneralTab.Controls.Add(Me.Label6)
        Me.GeneralTab.Controls.Add(Me.txtHomeTelephone)
        Me.GeneralTab.Controls.Add(Me.Label5)
        Me.GeneralTab.Controls.Add(Me.ckbInactiveEmployee)
        Me.GeneralTab.Controls.Add(Me.txtFirstName)
        Me.GeneralTab.Controls.Add(Me.txtSurname)
        Me.GeneralTab.Controls.Add(Me.Label1)
        Me.GeneralTab.Controls.Add(Me.Label4)
        Me.GeneralTab.Controls.Add(Me.Label2)
        Me.GeneralTab.Controls.Add(Me.txtPassword)
        Me.GeneralTab.Controls.Add(Me.txtCode)
        Me.GeneralTab.Controls.Add(Me.Label3)
        Me.GeneralTab.Location = New System.Drawing.Point(4, 22)
        Me.GeneralTab.Name = "GeneralTab"
        Me.GeneralTab.Padding = New System.Windows.Forms.Padding(3)
        Me.GeneralTab.Size = New System.Drawing.Size(465, 267)
        Me.GeneralTab.TabIndex = 0
        Me.GeneralTab.Text = "General"
        Me.GeneralTab.UseVisualStyleBackColor = True
        '
        'txtContactPhone
        '
        Me.txtContactPhone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ContactPhone", True))
        Me.txtContactPhone.Location = New System.Drawing.Point(105, 200)
        Me.txtContactPhone.MaxLength = 15
        Me.txtContactPhone.Name = "txtContactPhone"
        Me.txtContactPhone.Size = New System.Drawing.Size(120, 20)
        Me.txtContactPhone.TabIndex = 19
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(10, 204)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(78, 13)
        Me.Label22.TabIndex = 6
        Me.Label22.Text = "Contact Phone"
        '
        'txtContactRelationship
        '
        Me.txtContactRelationship.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ContactRelationship", True))
        Me.txtContactRelationship.Location = New System.Drawing.Point(105, 169)
        Me.txtContactRelationship.MaxLength = 20
        Me.txtContactRelationship.Name = "txtContactRelationship"
        Me.txtContactRelationship.Size = New System.Drawing.Size(341, 20)
        Me.txtContactRelationship.TabIndex = 18
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(10, 173)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(65, 13)
        Me.Label21.TabIndex = 5
        Me.Label21.Text = "Relationship"
        '
        'txtContactName
        '
        Me.txtContactName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ContactName", True))
        Me.txtContactName.Location = New System.Drawing.Point(105, 138)
        Me.txtContactName.MaxLength = 20
        Me.txtContactName.Name = "txtContactName"
        Me.txtContactName.Size = New System.Drawing.Size(341, 20)
        Me.txtContactName.TabIndex = 17
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(10, 142)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(75, 13)
        Me.Label20.TabIndex = 4
        Me.Label20.Text = "Contact Name"
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(10, 237)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 13)
        Me.Label18.TabIndex = 7
        Me.Label18.Text = "Employee Type"
        '
        'cboEmployeeType
        '
        Me.cboEmployeeType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboEmployeeType.FormattingEnabled = True
        Me.cboEmployeeType.Location = New System.Drawing.Point(105, 233)
        Me.cboEmployeeType.Name = "cboEmployeeType"
        Me.cboEmployeeType.Size = New System.Drawing.Size(151, 21)
        Me.cboEmployeeType.TabIndex = 21
        '
        'txtCellNumber
        '
        Me.txtCellNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "CellNumber", True))
        Me.txtCellNumber.Location = New System.Drawing.Point(325, 105)
        Me.txtCellNumber.MaxLength = 15
        Me.txtCellNumber.Name = "txtCellNumber"
        Me.txtCellNumber.Size = New System.Drawing.Size(120, 20)
        Me.txtCellNumber.TabIndex = 16
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(252, 109)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 13)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Cell Number"
        '
        'txtHomeTelephone
        '
        Me.txtHomeTelephone.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "HomeTelephone", True))
        Me.txtHomeTelephone.Location = New System.Drawing.Point(105, 105)
        Me.txtHomeTelephone.MaxLength = 15
        Me.txtHomeTelephone.Name = "txtHomeTelephone"
        Me.txtHomeTelephone.Size = New System.Drawing.Size(120, 20)
        Me.txtHomeTelephone.TabIndex = 15
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(10, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(89, 13)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Home Telephone"
        '
        'ckbInactiveEmployee
        '
        Me.ckbInactiveEmployee.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ckbInactiveEmployee.AutoSize = True
        Me.ckbInactiveEmployee.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.BindingSource1, "InactiveEmployee", True))
        Me.ckbInactiveEmployee.Location = New System.Drawing.Point(345, 235)
        Me.ckbInactiveEmployee.Name = "ckbInactiveEmployee"
        Me.ckbInactiveEmployee.Size = New System.Drawing.Size(113, 17)
        Me.ckbInactiveEmployee.TabIndex = 22
        Me.ckbInactiveEmployee.Text = "Inactive Employee"
        Me.ckbInactiveEmployee.UseVisualStyleBackColor = True
        '
        'AddressTab
        '
        Me.AddressTab.Controls.Add(Me.PhysicalToPostalButton)
        Me.AddressTab.Controls.Add(Me.PostalToPhysicalButton)
        Me.AddressTab.Controls.Add(Me.GroupBox2)
        Me.AddressTab.Controls.Add(Me.GroupBox1)
        Me.AddressTab.Location = New System.Drawing.Point(4, 22)
        Me.AddressTab.Name = "AddressTab"
        Me.AddressTab.Padding = New System.Windows.Forms.Padding(3)
        Me.AddressTab.Size = New System.Drawing.Size(465, 267)
        Me.AddressTab.TabIndex = 1
        Me.AddressTab.Text = "Address"
        Me.AddressTab.UseVisualStyleBackColor = True
        '
        'PhysicalToPostalButton
        '
        Me.PhysicalToPostalButton.Location = New System.Drawing.Point(187, 126)
        Me.PhysicalToPostalButton.Name = "PhysicalToPostalButton"
        Me.PhysicalToPostalButton.Size = New System.Drawing.Size(26, 23)
        Me.PhysicalToPostalButton.TabIndex = 3
        Me.PhysicalToPostalButton.Text = ">"
        Me.PhysicalToPostalButton.UseVisualStyleBackColor = True
        '
        'PostalToPhysicalButton
        '
        Me.PostalToPhysicalButton.Location = New System.Drawing.Point(237, 126)
        Me.PostalToPhysicalButton.Name = "PostalToPhysicalButton"
        Me.PostalToPhysicalButton.Size = New System.Drawing.Size(26, 23)
        Me.PostalToPhysicalButton.TabIndex = 2
        Me.PostalToPhysicalButton.Text = "<"
        Me.PostalToPhysicalButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtPostalAddressPostalCode)
        Me.GroupBox2.Controls.Add(Me.txtPostalAddress3)
        Me.GroupBox2.Controls.Add(Me.txtPostalAddress2)
        Me.GroupBox2.Controls.Add(Me.txtPostalAddress1)
        Me.GroupBox2.Location = New System.Drawing.Point(14, 150)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(432, 103)
        Me.GroupBox2.TabIndex = 1
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
        Me.GroupBox1.Location = New System.Drawing.Point(14, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(432, 109)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Physical Address"
        '
        'txtPhysicalAddressPostalCode
        '
        Me.txtPhysicalAddressPostalCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ResdentialCode", True))
        Me.txtPhysicalAddressPostalCode.Location = New System.Drawing.Point(313, 83)
        Me.txtPhysicalAddressPostalCode.MaxLength = 4
        Me.txtPhysicalAddressPostalCode.Name = "txtPhysicalAddressPostalCode"
        Me.txtPhysicalAddressPostalCode.Size = New System.Drawing.Size(100, 20)
        Me.txtPhysicalAddressPostalCode.TabIndex = 3
        '
        'txtPhysicalAddress3
        '
        Me.txtPhysicalAddress3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ResdentialAddress3", True))
        Me.txtPhysicalAddress3.Location = New System.Drawing.Point(18, 83)
        Me.txtPhysicalAddress3.MaxLength = 30
        Me.txtPhysicalAddress3.Name = "txtPhysicalAddress3"
        Me.txtPhysicalAddress3.Size = New System.Drawing.Size(280, 20)
        Me.txtPhysicalAddress3.TabIndex = 2
        '
        'txtPhysicalAddress2
        '
        Me.txtPhysicalAddress2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ResdentialAddress2", True))
        Me.txtPhysicalAddress2.Location = New System.Drawing.Point(18, 50)
        Me.txtPhysicalAddress2.MaxLength = 30
        Me.txtPhysicalAddress2.Name = "txtPhysicalAddress2"
        Me.txtPhysicalAddress2.Size = New System.Drawing.Size(395, 20)
        Me.txtPhysicalAddress2.TabIndex = 1
        '
        'txtPhysicalAddress1
        '
        Me.txtPhysicalAddress1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "ResdentialAddress1", True))
        Me.txtPhysicalAddress1.Location = New System.Drawing.Point(18, 18)
        Me.txtPhysicalAddress1.MaxLength = 30
        Me.txtPhysicalAddress1.Name = "txtPhysicalAddress1"
        Me.txtPhysicalAddress1.Size = New System.Drawing.Size(395, 20)
        Me.txtPhysicalAddress1.TabIndex = 0
        '
        'SalaryTab
        '
        Me.SalaryTab.Controls.Add(Me.txtTaxNumber)
        Me.SalaryTab.Controls.Add(Me.Label19)
        Me.SalaryTab.Controls.Add(Me.Label12)
        Me.SalaryTab.Controls.Add(Me.dteDateStarted)
        Me.SalaryTab.Controls.Add(Me.Label11)
        Me.SalaryTab.Controls.Add(Me.Label10)
        Me.SalaryTab.Controls.Add(Me.cboMaritalStatus)
        Me.SalaryTab.Controls.Add(Me.Label9)
        Me.SalaryTab.Controls.Add(Me.cboGender)
        Me.SalaryTab.Controls.Add(Me.Label8)
        Me.SalaryTab.Controls.Add(Me.txtIDNumber)
        Me.SalaryTab.Controls.Add(Me.Label7)
        Me.SalaryTab.Controls.Add(Me.txtNoOfDependants)
        Me.SalaryTab.Controls.Add(Me.txtRate)
        Me.SalaryTab.Location = New System.Drawing.Point(4, 22)
        Me.SalaryTab.Name = "SalaryTab"
        Me.SalaryTab.Size = New System.Drawing.Size(465, 267)
        Me.SalaryTab.TabIndex = 2
        Me.SalaryTab.Text = "Salary"
        Me.SalaryTab.UseVisualStyleBackColor = True
        '
        'txtTaxNumber
        '
        Me.txtTaxNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "TaxNumber", True))
        Me.txtTaxNumber.Location = New System.Drawing.Point(128, 45)
        Me.txtTaxNumber.MaxLength = 20
        Me.txtTaxNumber.Name = "txtTaxNumber"
        Me.txtTaxNumber.Size = New System.Drawing.Size(230, 20)
        Me.txtTaxNumber.TabIndex = 8
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(17, 47)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(65, 13)
        Me.Label19.TabIndex = 1
        Me.Label19.Text = "Tax Number"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 214)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(30, 13)
        Me.Label12.TabIndex = 6
        Me.Label12.Text = "Rate"
        '
        'dteDateStarted
        '
        Me.dteDateStarted.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "DateStarted", True))
        Me.dteDateStarted.Location = New System.Drawing.Point(128, 179)
        Me.dteDateStarted.Name = "dteDateStarted"
        Me.dteDateStarted.Size = New System.Drawing.Size(149, 20)
        Me.dteDateStarted.TabIndex = 12
        Me.dteDateStarted.Value = New Date(2014, 9, 22, 14, 10, 42, 0)
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(17, 181)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(67, 13)
        Me.Label11.TabIndex = 5
        Me.Label11.Text = "Date Started"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(17, 148)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(96, 13)
        Me.Label10.TabIndex = 4
        Me.Label10.Text = "No Of Dependants"
        '
        'cboMaritalStatus
        '
        Me.cboMaritalStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMaritalStatus.FormattingEnabled = True
        Me.cboMaritalStatus.Location = New System.Drawing.Point(128, 112)
        Me.cboMaritalStatus.Name = "cboMaritalStatus"
        Me.cboMaritalStatus.Size = New System.Drawing.Size(89, 21)
        Me.cboMaritalStatus.TabIndex = 10
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(17, 115)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(71, 13)
        Me.Label9.TabIndex = 3
        Me.Label9.Text = "Marital Status"
        '
        'cboGender
        '
        Me.cboGender.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboGender.FormattingEnabled = True
        Me.cboGender.Location = New System.Drawing.Point(128, 78)
        Me.cboGender.Name = "cboGender"
        Me.cboGender.Size = New System.Drawing.Size(89, 21)
        Me.cboGender.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 81)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(42, 13)
        Me.Label8.TabIndex = 2
        Me.Label8.Text = "Gender"
        '
        'txtIDNumber
        '
        Me.txtIDNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "IDNumber", True))
        Me.txtIDNumber.Location = New System.Drawing.Point(128, 12)
        Me.txtIDNumber.MaxLength = 20
        Me.txtIDNumber.Name = "txtIDNumber"
        Me.txtIDNumber.Size = New System.Drawing.Size(230, 20)
        Me.txtIDNumber.TabIndex = 7
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(17, 14)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "ID Number"
        '
        'txtNoOfDependants
        '
        Me.txtNoOfDependants.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "NoOfDependants", True))
        Me.txtNoOfDependants.EditValue = 0
        Me.txtNoOfDependants.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtNoOfDependants.IsReadOnly = False
        Me.txtNoOfDependants.Location = New System.Drawing.Point(128, 146)
        Me.txtNoOfDependants.MaxLength = 32767
        Me.txtNoOfDependants.Name = "txtNoOfDependants"
        Me.txtNoOfDependants.Size = New System.Drawing.Size(46, 20)
        Me.txtNoOfDependants.TabIndex = 11
        '
        'txtRate
        '
        Me.txtRate.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "Rate", True))
        Me.txtRate.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtRate.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtRate.IsReadOnly = False
        Me.txtRate.Location = New System.Drawing.Point(128, 212)
        Me.txtRate.MaxLength = 15
        Me.txtRate.Name = "txtRate"
        Me.txtRate.Size = New System.Drawing.Size(90, 20)
        Me.txtRate.TabIndex = 13
        '
        'BankingTab
        '
        Me.BankingTab.Controls.Add(Me.txtAccountType)
        Me.BankingTab.Controls.Add(Me.Label17)
        Me.BankingTab.Controls.Add(Me.txtAccountNumber)
        Me.BankingTab.Controls.Add(Me.Label16)
        Me.BankingTab.Controls.Add(Me.txtBranchNumber)
        Me.BankingTab.Controls.Add(Me.Label15)
        Me.BankingTab.Controls.Add(Me.txtBranchName)
        Me.BankingTab.Controls.Add(Me.Label14)
        Me.BankingTab.Controls.Add(Me.txtBankName)
        Me.BankingTab.Controls.Add(Me.Label13)
        Me.BankingTab.Location = New System.Drawing.Point(4, 22)
        Me.BankingTab.Name = "BankingTab"
        Me.BankingTab.Size = New System.Drawing.Size(465, 267)
        Me.BankingTab.TabIndex = 3
        Me.BankingTab.Text = "Banking"
        Me.BankingTab.UseVisualStyleBackColor = True
        '
        'txtAccountType
        '
        Me.txtAccountType.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "AccountType", True))
        Me.txtAccountType.Location = New System.Drawing.Point(110, 151)
        Me.txtAccountType.MaxLength = 20
        Me.txtAccountType.Name = "txtAccountType"
        Me.txtAccountType.Size = New System.Drawing.Size(334, 20)
        Me.txtAccountType.TabIndex = 9
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(14, 155)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(74, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Account Type"
        '
        'txtAccountNumber
        '
        Me.txtAccountNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "AccountNumber", True))
        Me.txtAccountNumber.Location = New System.Drawing.Point(110, 117)
        Me.txtAccountNumber.MaxLength = 20
        Me.txtAccountNumber.Name = "txtAccountNumber"
        Me.txtAccountNumber.Size = New System.Drawing.Size(334, 20)
        Me.txtAccountNumber.TabIndex = 7
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(14, 121)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 13)
        Me.Label16.TabIndex = 6
        Me.Label16.Text = "Account Number"
        '
        'txtBranchNumber
        '
        Me.txtBranchNumber.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "BranchNumber", True))
        Me.txtBranchNumber.Location = New System.Drawing.Point(110, 82)
        Me.txtBranchNumber.MaxLength = 20
        Me.txtBranchNumber.Name = "txtBranchNumber"
        Me.txtBranchNumber.Size = New System.Drawing.Size(334, 20)
        Me.txtBranchNumber.TabIndex = 5
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(14, 86)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(81, 13)
        Me.Label15.TabIndex = 4
        Me.Label15.Text = "Branch Number"
        '
        'txtBranchName
        '
        Me.txtBranchName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "BranchName", True))
        Me.txtBranchName.Location = New System.Drawing.Point(110, 47)
        Me.txtBranchName.MaxLength = 20
        Me.txtBranchName.Name = "txtBranchName"
        Me.txtBranchName.Size = New System.Drawing.Size(334, 20)
        Me.txtBranchName.TabIndex = 3
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(14, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(72, 13)
        Me.Label14.TabIndex = 2
        Me.Label14.Text = "Branch Name"
        '
        'txtBankName
        '
        Me.txtBankName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "BankName", True))
        Me.txtBankName.Location = New System.Drawing.Point(110, 13)
        Me.txtBankName.MaxLength = 20
        Me.txtBankName.Name = "txtBankName"
        Me.txtBankName.Size = New System.Drawing.Size(334, 20)
        Me.txtBankName.TabIndex = 1
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(14, 17)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(63, 13)
        Me.Label13.TabIndex = 0
        Me.Label13.Text = "Bank Name"
        '
        'ExcelButton
        '
        Me.ExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExcelButton.Location = New System.Drawing.Point(12, 314)
        Me.ExcelButton.Name = "ExcelButton"
        Me.ExcelButton.Size = New System.Drawing.Size(75, 23)
        Me.ExcelButton.TabIndex = 20
        Me.ExcelButton.Text = "&Excel Export"
        Me.ExcelButton.UseVisualStyleBackColor = True
        '
        'txtBranchCode
        '
        Me.txtBranchCode.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "BranchCode", True))
        Me.txtBranchCode.Location = New System.Drawing.Point(345, 201)
        Me.txtBranchCode.MaxLength = 5
        Me.txtBranchCode.Name = "txtBranchCode"
        Me.txtBranchCode.Size = New System.Drawing.Size(100, 20)
        Me.txtBranchCode.TabIndex = 20
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(252, 205)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(78, 13)
        Me.Label23.TabIndex = 10
        Me.Label23.Text = "Default Branch"
        '
        'UpdateEmployeeForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(498, 351)
        Me.Controls.Add(Me.ExcelButton)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "UpdateEmployeeForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Employee"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabControl1.ResumeLayout(False)
        Me.GeneralTab.ResumeLayout(False)
        Me.GeneralTab.PerformLayout()
        Me.AddressTab.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.SalaryTab.ResumeLayout(False)
        Me.SalaryTab.PerformLayout()
        Me.BankingTab.ResumeLayout(False)
        Me.BankingTab.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtFirstName As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtPassword As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtSurname As System.Windows.Forms.TextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents GeneralTab As System.Windows.Forms.TabPage
    Friend WithEvents AddressTab As System.Windows.Forms.TabPage
    Friend WithEvents ckbInactiveEmployee As System.Windows.Forms.CheckBox
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
    Friend WithEvents txtCellNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtHomeTelephone As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents SalaryTab As System.Windows.Forms.TabPage
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents dteDateStarted As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cboMaritalStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboGender As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents txtIDNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents BankingTab As System.Windows.Forms.TabPage
    Friend WithEvents txtAccountType As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtAccountNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtBranchNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtBranchName As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtBankName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtRate As CashManagement.NumericTextBox
    Friend WithEvents txtNoOfDependants As CashManagement.NumericTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents cboEmployeeType As System.Windows.Forms.ComboBox
    Friend WithEvents txtTaxNumber As System.Windows.Forms.TextBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtContactPhone As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents txtContactRelationship As System.Windows.Forms.TextBox
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtContactName As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents ExcelButton As System.Windows.Forms.Button
    Friend WithEvents txtBranchCode As TextBox
    Friend WithEvents Label23 As Label
End Class
