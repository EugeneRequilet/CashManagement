<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateFirmDetailsForm
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
        Me.Label = New System.Windows.Forms.Label()
        Me.FirmNameTextBox = New System.Windows.Forms.TextBox()
        Me.FirmDetailBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBox11 = New System.Windows.Forms.TextBox()
        Me.TextBox10 = New System.Windows.Forms.TextBox()
        Me.TextBox9 = New System.Windows.Forms.TextBox()
        Me.TextBox8 = New System.Windows.Forms.TextBox()
        Me.PhysicalToPostalButton = New System.Windows.Forms.Button()
        Me.PostalToPhysicalButton = New System.Windows.Forms.Button()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox16 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox15 = New System.Windows.Forms.TextBox()
        Me.TextBox14 = New System.Windows.Forms.TextBox()
        Me.TextBox13 = New System.Windows.Forms.TextBox()
        Me.TextBox12 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.CmdCancelButton = New System.Windows.Forms.Button()
        Me.txtFloatRequired = New CashManagement.NumericTextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.txtAttachmentDirectory = New System.Windows.Forms.TextBox()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.txtHoursPerShift = New CashManagement.NumericTextBox()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtSQLDefaultDirectory = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.txtGeneralDefaultDirectory = New System.Windows.Forms.TextBox()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtStaffMealHighlight = New CashManagement.NumericTextBox()
        Me.txtDiscountHighlight = New CashManagement.NumericTextBox()
        Me.txtOverbakeHighlight = New CashManagement.NumericTextBox()
        Me.txtGrossCashupDifHighlight = New CashManagement.NumericTextBox()
        Me.txtGrossSalesHighlight = New CashManagement.NumericTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        CType(Me.FirmDetailBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label
        '
        Me.Label.AutoSize = True
        Me.Label.Location = New System.Drawing.Point(13, 12)
        Me.Label.Name = "Label"
        Me.Label.Size = New System.Drawing.Size(57, 13)
        Me.Label.TabIndex = 0
        Me.Label.Text = "Firm Name"
        '
        'FirmNameTextBox
        '
        Me.FirmNameTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "FirmName", True))
        Me.FirmNameTextBox.Location = New System.Drawing.Point(134, 8)
        Me.FirmNameTextBox.MaxLength = 50
        Me.FirmNameTextBox.Name = "FirmNameTextBox"
        Me.FirmNameTextBox.Size = New System.Drawing.Size(442, 20)
        Me.FirmNameTextBox.TabIndex = 1
        '
        'FirmDetailBindingSource
        '
        Me.FirmDetailBindingSource.DataSource = GetType(CashManagement.FirmDetail)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 38)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Telephone"
        '
        'TextBox2
        '
        Me.TextBox2.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "Telephone", True))
        Me.TextBox2.Location = New System.Drawing.Point(134, 34)
        Me.TextBox2.MaxLength = 15
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(151, 20)
        Me.TextBox2.TabIndex = 3
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 67)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 13)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "Cell Number"
        '
        'TextBox3
        '
        Me.TextBox3.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "CellNumber", True))
        Me.TextBox3.Location = New System.Drawing.Point(134, 63)
        Me.TextBox3.MaxLength = 15
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(151, 20)
        Me.TextBox3.TabIndex = 5
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBox7)
        Me.GroupBox1.Controls.Add(Me.TextBox6)
        Me.GroupBox1.Controls.Add(Me.TextBox5)
        Me.GroupBox1.Controls.Add(Me.TextBox4)
        Me.GroupBox1.Location = New System.Drawing.Point(17, 99)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(264, 155)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Physical Address"
        '
        'TextBox7
        '
        Me.TextBox7.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "PhysicalCode", True))
        Me.TextBox7.Location = New System.Drawing.Point(9, 119)
        Me.TextBox7.MaxLength = 4
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(100, 20)
        Me.TextBox7.TabIndex = 3
        '
        'TextBox6
        '
        Me.TextBox6.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "PhysicalAddress3", True))
        Me.TextBox6.Location = New System.Drawing.Point(9, 86)
        Me.TextBox6.MaxLength = 30
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(246, 20)
        Me.TextBox6.TabIndex = 2
        '
        'TextBox5
        '
        Me.TextBox5.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "PhysicalAddress2", True))
        Me.TextBox5.Location = New System.Drawing.Point(9, 53)
        Me.TextBox5.MaxLength = 30
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(246, 20)
        Me.TextBox5.TabIndex = 1
        '
        'TextBox4
        '
        Me.TextBox4.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "PhysicalAddress1", True))
        Me.TextBox4.Location = New System.Drawing.Point(9, 20)
        Me.TextBox4.MaxLength = 30
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(246, 20)
        Me.TextBox4.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBox11)
        Me.GroupBox2.Controls.Add(Me.TextBox10)
        Me.GroupBox2.Controls.Add(Me.TextBox9)
        Me.GroupBox2.Controls.Add(Me.TextBox8)
        Me.GroupBox2.Location = New System.Drawing.Point(312, 99)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(264, 155)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Postal Address"
        '
        'TextBox11
        '
        Me.TextBox11.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "PostalCode", True))
        Me.TextBox11.Location = New System.Drawing.Point(10, 127)
        Me.TextBox11.MaxLength = 4
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(100, 20)
        Me.TextBox11.TabIndex = 3
        '
        'TextBox10
        '
        Me.TextBox10.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "PostalAddress3", True))
        Me.TextBox10.Location = New System.Drawing.Point(10, 88)
        Me.TextBox10.MaxLength = 30
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(246, 20)
        Me.TextBox10.TabIndex = 2
        '
        'TextBox9
        '
        Me.TextBox9.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "PostalAddress2", True))
        Me.TextBox9.Location = New System.Drawing.Point(10, 51)
        Me.TextBox9.MaxLength = 30
        Me.TextBox9.Name = "TextBox9"
        Me.TextBox9.Size = New System.Drawing.Size(246, 20)
        Me.TextBox9.TabIndex = 1
        '
        'TextBox8
        '
        Me.TextBox8.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "PostalAddress1", True))
        Me.TextBox8.Location = New System.Drawing.Point(10, 20)
        Me.TextBox8.MaxLength = 30
        Me.TextBox8.Name = "TextBox8"
        Me.TextBox8.Size = New System.Drawing.Size(246, 20)
        Me.TextBox8.TabIndex = 0
        '
        'PhysicalToPostalButton
        '
        Me.PhysicalToPostalButton.Location = New System.Drawing.Point(287, 147)
        Me.PhysicalToPostalButton.Name = "PhysicalToPostalButton"
        Me.PhysicalToPostalButton.Size = New System.Drawing.Size(19, 23)
        Me.PhysicalToPostalButton.TabIndex = 7
        Me.PhysicalToPostalButton.Text = ">"
        Me.PhysicalToPostalButton.UseVisualStyleBackColor = True
        '
        'PostalToPhysicalButton
        '
        Me.PostalToPhysicalButton.Location = New System.Drawing.Point(287, 188)
        Me.PostalToPhysicalButton.Name = "PostalToPhysicalButton"
        Me.PostalToPhysicalButton.Size = New System.Drawing.Size(19, 23)
        Me.PostalToPhysicalButton.TabIndex = 8
        Me.PostalToPhysicalButton.Text = "<"
        Me.PostalToPhysicalButton.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.TextBox16)
        Me.GroupBox3.Controls.Add(Me.Label7)
        Me.GroupBox3.Controls.Add(Me.TextBox15)
        Me.GroupBox3.Controls.Add(Me.TextBox14)
        Me.GroupBox3.Controls.Add(Me.TextBox13)
        Me.GroupBox3.Controls.Add(Me.TextBox12)
        Me.GroupBox3.Controls.Add(Me.Label6)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(17, 271)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(559, 113)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Banking Details"
        '
        'TextBox16
        '
        Me.TextBox16.Location = New System.Drawing.Point(87, 79)
        Me.TextBox16.MaxLength = 30
        Me.TextBox16.Name = "TextBox16"
        Me.TextBox16.Size = New System.Drawing.Size(221, 20)
        Me.TextBox16.TabIndex = 9
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(6, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(74, 13)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Account Type"
        '
        'TextBox15
        '
        Me.TextBox15.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "BranchNumber", True))
        Me.TextBox15.Location = New System.Drawing.Point(420, 48)
        Me.TextBox15.MaxLength = 20
        Me.TextBox15.Name = "TextBox15"
        Me.TextBox15.Size = New System.Drawing.Size(131, 20)
        Me.TextBox15.TabIndex = 7
        '
        'TextBox14
        '
        Me.TextBox14.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "AccountNumber", True))
        Me.TextBox14.Location = New System.Drawing.Point(420, 21)
        Me.TextBox14.MaxLength = 20
        Me.TextBox14.Name = "TextBox14"
        Me.TextBox14.Size = New System.Drawing.Size(131, 20)
        Me.TextBox14.TabIndex = 3
        '
        'TextBox13
        '
        Me.TextBox13.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "BranchName", True))
        Me.TextBox13.Location = New System.Drawing.Point(87, 48)
        Me.TextBox13.MaxLength = 30
        Me.TextBox13.Name = "TextBox13"
        Me.TextBox13.Size = New System.Drawing.Size(221, 20)
        Me.TextBox13.TabIndex = 5
        '
        'TextBox12
        '
        Me.TextBox12.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "BankName", True))
        Me.TextBox12.Location = New System.Drawing.Point(87, 21)
        Me.TextBox12.MaxLength = 30
        Me.TextBox12.Name = "TextBox12"
        Me.TextBox12.Size = New System.Drawing.Size(221, 20)
        Me.TextBox12.TabIndex = 1
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(324, 52)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(81, 13)
        Me.Label6.TabIndex = 6
        Me.Label6.Text = "Branch Number"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(324, 25)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 13)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Account Number"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 52)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(72, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Branch Name"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 25)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(63, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Bank Name"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(11, 21)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(76, 13)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Float Required"
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(451, 441)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 0
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'CmdCancelButton
        '
        Me.CmdCancelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CmdCancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CmdCancelButton.Location = New System.Drawing.Point(542, 441)
        Me.CmdCancelButton.Name = "CmdCancelButton"
        Me.CmdCancelButton.Size = New System.Drawing.Size(75, 23)
        Me.CmdCancelButton.TabIndex = 1
        Me.CmdCancelButton.Text = "&Cancel"
        Me.CmdCancelButton.UseVisualStyleBackColor = True
        '
        'txtFloatRequired
        '
        Me.txtFloatRequired.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.txtFloatRequired.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.FirmDetailBindingSource, "FloatRequired", True, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged))
        Me.txtFloatRequired.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtFloatRequired.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtFloatRequired.IsReadOnly = False
        Me.txtFloatRequired.Location = New System.Drawing.Point(215, 17)
        Me.txtFloatRequired.MaxLength = 32767
        Me.txtFloatRequired.Name = "txtFloatRequired"
        Me.txtFloatRequired.Size = New System.Drawing.Size(100, 20)
        Me.txtFloatRequired.TabIndex = 10
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(14, 11)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(605, 416)
        Me.TabControl1.TabIndex = 2
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.FirmNameTextBox)
        Me.TabPage1.Controls.Add(Me.Label)
        Me.TabPage1.Controls.Add(Me.Label1)
        Me.TabPage1.Controls.Add(Me.TextBox2)
        Me.TabPage1.Controls.Add(Me.Label2)
        Me.TabPage1.Controls.Add(Me.GroupBox3)
        Me.TabPage1.Controls.Add(Me.TextBox3)
        Me.TabPage1.Controls.Add(Me.PostalToPhysicalButton)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Controls.Add(Me.PhysicalToPostalButton)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(597, 390)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "General"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.txtAttachmentDirectory)
        Me.TabPage2.Controls.Add(Me.Label17)
        Me.TabPage2.Controls.Add(Me.txtHoursPerShift)
        Me.TabPage2.Controls.Add(Me.Label16)
        Me.TabPage2.Controls.Add(Me.txtSQLDefaultDirectory)
        Me.TabPage2.Controls.Add(Me.Label15)
        Me.TabPage2.Controls.Add(Me.txtGeneralDefaultDirectory)
        Me.TabPage2.Controls.Add(Me.Label14)
        Me.TabPage2.Controls.Add(Me.txtStaffMealHighlight)
        Me.TabPage2.Controls.Add(Me.txtDiscountHighlight)
        Me.TabPage2.Controls.Add(Me.txtOverbakeHighlight)
        Me.TabPage2.Controls.Add(Me.txtGrossCashupDifHighlight)
        Me.TabPage2.Controls.Add(Me.txtGrossSalesHighlight)
        Me.TabPage2.Controls.Add(Me.Label13)
        Me.TabPage2.Controls.Add(Me.Label12)
        Me.TabPage2.Controls.Add(Me.Label11)
        Me.TabPage2.Controls.Add(Me.Label10)
        Me.TabPage2.Controls.Add(Me.Label9)
        Me.TabPage2.Controls.Add(Me.txtFloatRequired)
        Me.TabPage2.Controls.Add(Me.Label8)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(597, 390)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Other"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'txtAttachmentDirectory
        '
        Me.txtAttachmentDirectory.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "AttachmentDirectory", True))
        Me.txtAttachmentDirectory.Location = New System.Drawing.Point(134, 255)
        Me.txtAttachmentDirectory.MaxLength = 255
        Me.txtAttachmentDirectory.Name = "txtAttachmentDirectory"
        Me.txtAttachmentDirectory.Size = New System.Drawing.Size(445, 20)
        Me.txtAttachmentDirectory.TabIndex = 18
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(11, 259)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(93, 13)
        Me.Label17.TabIndex = 8
        Me.Label17.Text = "Attachment Folder"
        '
        'txtHoursPerShift
        '
        Me.txtHoursPerShift.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.txtHoursPerShift.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.FirmDetailBindingSource, "HoursPerShift", True))
        Me.txtHoursPerShift.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtHoursPerShift.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtHoursPerShift.IsReadOnly = False
        Me.txtHoursPerShift.Location = New System.Drawing.Point(215, 283)
        Me.txtHoursPerShift.MaxLength = 32767
        Me.txtHoursPerShift.Name = "txtHoursPerShift"
        Me.txtHoursPerShift.Size = New System.Drawing.Size(100, 20)
        Me.txtHoursPerShift.TabIndex = 19
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(11, 287)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(127, 13)
        Me.Label16.TabIndex = 9
        Me.Label16.Text = "Hours Per Employee Shift"
        '
        'txtSQLDefaultDirectory
        '
        Me.txtSQLDefaultDirectory.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "SQLBackupDefaultDirectory", True))
        Me.txtSQLDefaultDirectory.Location = New System.Drawing.Point(134, 225)
        Me.txtSQLDefaultDirectory.MaxLength = 255
        Me.txtSQLDefaultDirectory.Name = "txtSQLDefaultDirectory"
        Me.txtSQLDefaultDirectory.Size = New System.Drawing.Size(445, 20)
        Me.txtSQLDefaultDirectory.TabIndex = 17
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 229)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(116, 13)
        Me.Label15.TabIndex = 7
        Me.Label15.Text = "MSSQL Backup Folder"
        '
        'txtGeneralDefaultDirectory
        '
        Me.txtGeneralDefaultDirectory.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.FirmDetailBindingSource, "GeneralDefaultDirectory", True))
        Me.txtGeneralDefaultDirectory.Location = New System.Drawing.Point(134, 195)
        Me.txtGeneralDefaultDirectory.MaxLength = 255
        Me.txtGeneralDefaultDirectory.Name = "txtGeneralDefaultDirectory"
        Me.txtGeneralDefaultDirectory.Size = New System.Drawing.Size(445, 20)
        Me.txtGeneralDefaultDirectory.TabIndex = 16
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(11, 199)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(113, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "General Default Folder"
        '
        'txtStaffMealHighlight
        '
        Me.txtStaffMealHighlight.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.txtStaffMealHighlight.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.FirmDetailBindingSource, "StaffMealHighlight", True))
        Me.txtStaffMealHighlight.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtStaffMealHighlight.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtStaffMealHighlight.IsReadOnly = False
        Me.txtStaffMealHighlight.Location = New System.Drawing.Point(215, 167)
        Me.txtStaffMealHighlight.MaxLength = 32767
        Me.txtStaffMealHighlight.Name = "txtStaffMealHighlight"
        Me.txtStaffMealHighlight.Size = New System.Drawing.Size(100, 20)
        Me.txtStaffMealHighlight.TabIndex = 15
        '
        'txtDiscountHighlight
        '
        Me.txtDiscountHighlight.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.txtDiscountHighlight.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.FirmDetailBindingSource, "DiscountHighlight", True))
        Me.txtDiscountHighlight.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDiscountHighlight.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDiscountHighlight.IsReadOnly = False
        Me.txtDiscountHighlight.Location = New System.Drawing.Point(215, 137)
        Me.txtDiscountHighlight.MaxLength = 32767
        Me.txtDiscountHighlight.Name = "txtDiscountHighlight"
        Me.txtDiscountHighlight.Size = New System.Drawing.Size(100, 20)
        Me.txtDiscountHighlight.TabIndex = 14
        '
        'txtOverbakeHighlight
        '
        Me.txtOverbakeHighlight.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.txtOverbakeHighlight.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.FirmDetailBindingSource, "OverbakeHighlight", True))
        Me.txtOverbakeHighlight.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtOverbakeHighlight.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtOverbakeHighlight.IsReadOnly = False
        Me.txtOverbakeHighlight.Location = New System.Drawing.Point(215, 107)
        Me.txtOverbakeHighlight.MaxLength = 32767
        Me.txtOverbakeHighlight.Name = "txtOverbakeHighlight"
        Me.txtOverbakeHighlight.Size = New System.Drawing.Size(100, 20)
        Me.txtOverbakeHighlight.TabIndex = 13
        '
        'txtGrossCashupDifHighlight
        '
        Me.txtGrossCashupDifHighlight.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.txtGrossCashupDifHighlight.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.FirmDetailBindingSource, "GrossCashupDifHighlight", True))
        Me.txtGrossCashupDifHighlight.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrossCashupDifHighlight.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtGrossCashupDifHighlight.IsReadOnly = False
        Me.txtGrossCashupDifHighlight.Location = New System.Drawing.Point(215, 77)
        Me.txtGrossCashupDifHighlight.MaxLength = 32767
        Me.txtGrossCashupDifHighlight.Name = "txtGrossCashupDifHighlight"
        Me.txtGrossCashupDifHighlight.Size = New System.Drawing.Size(100, 20)
        Me.txtGrossCashupDifHighlight.TabIndex = 12
        '
        'txtGrossSalesHighlight
        '
        Me.txtGrossSalesHighlight.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange
        Me.txtGrossSalesHighlight.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.FirmDetailBindingSource, "GrossSalesHighlight", True))
        Me.txtGrossSalesHighlight.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrossSalesHighlight.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtGrossSalesHighlight.IsReadOnly = False
        Me.txtGrossSalesHighlight.Location = New System.Drawing.Point(215, 47)
        Me.txtGrossSalesHighlight.MaxLength = 32767
        Me.txtGrossSalesHighlight.Name = "txtGrossSalesHighlight"
        Me.txtGrossSalesHighlight.Size = New System.Drawing.Size(100, 20)
        Me.txtGrossSalesHighlight.TabIndex = 11
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(11, 171)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(121, 13)
        Me.Label13.TabIndex = 5
        Me.Label13.Text = "Highlight if Staff Meals >"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(11, 141)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 4
        Me.Label12.Text = "Highlight if Discount >"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(11, 111)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(115, 13)
        Me.Label11.TabIndex = 3
        Me.Label11.Text = "Highlight if Overbake >"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(11, 81)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(194, 13)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Highlight if Gross Sales less Cashup is <"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(11, 51)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(124, 13)
        Me.Label9.TabIndex = 1
        Me.Label9.Text = "Highlight if Gross Sales <"
        '
        'UpdateFirmDetailsForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CmdCancelButton
        Me.ClientSize = New System.Drawing.Size(635, 473)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.CmdCancelButton)
        Me.Controls.Add(Me.OkButton)
        Me.Name = "UpdateFirmDetailsForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Firm Details"
        CType(Me.FirmDetailBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage1.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.TabPage2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Label As System.Windows.Forms.Label
    Friend WithEvents FirmNameTextBox As System.Windows.Forms.TextBox
    Friend WithEvents FirmDetailBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox11 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox10 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox9 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox8 As System.Windows.Forms.TextBox
    Friend WithEvents PhysicalToPostalButton As System.Windows.Forms.Button
    Friend WithEvents PostalToPhysicalButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox16 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox15 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox14 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox13 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox12 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents CmdCancelButton As System.Windows.Forms.Button
    Friend WithEvents txtFloatRequired As CashManagement.NumericTextBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents txtStaffMealHighlight As CashManagement.NumericTextBox
    Friend WithEvents txtDiscountHighlight As CashManagement.NumericTextBox
    Friend WithEvents txtOverbakeHighlight As CashManagement.NumericTextBox
    Friend WithEvents txtGrossCashupDifHighlight As CashManagement.NumericTextBox
    Friend WithEvents txtGrossSalesHighlight As CashManagement.NumericTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtSQLDefaultDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtGeneralDefaultDirectory As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtHoursPerShift As CashManagement.NumericTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtAttachmentDirectory As TextBox
    Friend WithEvents Label17 As Label
End Class
