<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateSalesForm
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
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.dteDate = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.txtTurnoverCreditCard = New CashManagement.NumericTextBox()
        Me.txtTurnoverCash = New CashManagement.NumericTextBox()
        Me.txtPayout = New CashManagement.NumericTextBox()
        Me.txtGrossSales = New CashManagement.NumericTextBox()
        Me.txtTurnoverOther = New CashManagement.NumericTextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtSamplePercent100 = New CashManagement.NumericTextBox()
        Me.txtDamagePercent100 = New CashManagement.NumericTextBox()
        Me.txtOverbakePercent100 = New CashManagement.NumericTextBox()
        Me.txtPromoPercent100 = New CashManagement.NumericTextBox()
        Me.txtWastagePercent100 = New CashManagement.NumericTextBox()
        Me.txtDiscountPercent20 = New CashManagement.NumericTextBox()
        Me.txtStaffPercent100 = New CashManagement.NumericTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.txtMemo = New System.Windows.Forms.TextBox()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtVoidsValue = New CashManagement.NumericTextBox()
        Me.txtStockVarianceValue = New CashManagement.NumericTextBox()
        Me.txtVoid = New CashManagement.NumericTextBox()
        Me.txtErrorCorrectsValue = New CashManagement.NumericTextBox()
        Me.txtErrorCorrects = New CashManagement.NumericTextBox()
        Me.txtChecksPaid = New CashManagement.NumericTextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.Label20 = New System.Windows.Forms.Label()
        Me.Label21 = New System.Windows.Forms.Label()
        Me.Label22 = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(555, 288)
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
        Me.cmdCancel.Location = New System.Drawing.Point(642, 288)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 1
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Sales)
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(24, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Date"
        '
        'dteDate
        '
        Me.dteDate.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "Date", True))
        Me.dteDate.Location = New System.Drawing.Point(110, 9)
        Me.dteDate.Name = "dteDate"
        Me.dteDate.Size = New System.Drawing.Size(182, 20)
        Me.dteDate.TabIndex = 2
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTurnoverCreditCard)
        Me.GroupBox1.Controls.Add(Me.txtTurnoverCash)
        Me.GroupBox1.Controls.Add(Me.txtPayout)
        Me.GroupBox1.Controls.Add(Me.txtGrossSales)
        Me.GroupBox1.Controls.Add(Me.txtTurnoverOther)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(18, 41)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(221, 171)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Sales And Revenue"
        '
        'txtTurnoverCreditCard
        '
        Me.txtTurnoverCreditCard.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "TurnoverCreditCard", True))
        Me.txtTurnoverCreditCard.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTurnoverCreditCard.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtTurnoverCreditCard.IsReadOnly = False
        Me.txtTurnoverCreditCard.Location = New System.Drawing.Point(98, 108)
        Me.txtTurnoverCreditCard.MaxLength = 15
        Me.txtTurnoverCreditCard.Name = "txtTurnoverCreditCard"
        Me.txtTurnoverCreditCard.Size = New System.Drawing.Size(100, 20)
        Me.txtTurnoverCreditCard.TabIndex = 3
        '
        'txtTurnoverCash
        '
        Me.txtTurnoverCash.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "TurnoverCash", True))
        Me.txtTurnoverCash.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTurnoverCash.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtTurnoverCash.IsReadOnly = False
        Me.txtTurnoverCash.Location = New System.Drawing.Point(98, 79)
        Me.txtTurnoverCash.MaxLength = 15
        Me.txtTurnoverCash.Name = "txtTurnoverCash"
        Me.txtTurnoverCash.Size = New System.Drawing.Size(100, 20)
        Me.txtTurnoverCash.TabIndex = 2
        '
        'txtPayout
        '
        Me.txtPayout.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "Payout", True))
        Me.txtPayout.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPayout.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPayout.IsReadOnly = False
        Me.txtPayout.Location = New System.Drawing.Point(98, 50)
        Me.txtPayout.MaxLength = 15
        Me.txtPayout.Name = "txtPayout"
        Me.txtPayout.Size = New System.Drawing.Size(100, 20)
        Me.txtPayout.TabIndex = 1
        '
        'txtGrossSales
        '
        Me.txtGrossSales.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "GrossSales", True))
        Me.txtGrossSales.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtGrossSales.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtGrossSales.IsReadOnly = False
        Me.txtGrossSales.Location = New System.Drawing.Point(98, 21)
        Me.txtGrossSales.MaxLength = 15
        Me.txtGrossSales.Name = "txtGrossSales"
        Me.txtGrossSales.Size = New System.Drawing.Size(100, 20)
        Me.txtGrossSales.TabIndex = 0
        '
        'txtTurnoverOther
        '
        Me.txtTurnoverOther.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "TurnoverOther", True))
        Me.txtTurnoverOther.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTurnoverOther.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtTurnoverOther.IsReadOnly = False
        Me.txtTurnoverOther.Location = New System.Drawing.Point(98, 137)
        Me.txtTurnoverOther.MaxLength = 15
        Me.txtTurnoverOther.Name = "txtTurnoverOther"
        Me.txtTurnoverOther.Size = New System.Drawing.Size(100, 20)
        Me.txtTurnoverOther.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 141)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(47, 13)
        Me.Label6.TabIndex = 8
        Me.Label6.Text = "Account"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(16, 112)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(59, 13)
        Me.Label5.TabIndex = 6
        Me.Label5.Text = "Credit Card"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 83)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(31, 13)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Cash"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 54)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(45, 13)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Pay Out"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(63, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Gross Sales"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtSamplePercent100)
        Me.GroupBox2.Controls.Add(Me.txtDamagePercent100)
        Me.GroupBox2.Controls.Add(Me.txtOverbakePercent100)
        Me.GroupBox2.Controls.Add(Me.txtPromoPercent100)
        Me.GroupBox2.Controls.Add(Me.txtWastagePercent100)
        Me.GroupBox2.Controls.Add(Me.txtDiscountPercent20)
        Me.GroupBox2.Controls.Add(Me.txtStaffPercent100)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(256, 41)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(221, 232)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Discounts"
        '
        'txtSamplePercent100
        '
        Me.txtSamplePercent100.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "SamplePercent100", True))
        Me.txtSamplePercent100.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSamplePercent100.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtSamplePercent100.IsReadOnly = False
        Me.txtSamplePercent100.Location = New System.Drawing.Point(99, 195)
        Me.txtSamplePercent100.MaxLength = 15
        Me.txtSamplePercent100.Name = "txtSamplePercent100"
        Me.txtSamplePercent100.Size = New System.Drawing.Size(100, 20)
        Me.txtSamplePercent100.TabIndex = 6
        '
        'txtDamagePercent100
        '
        Me.txtDamagePercent100.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "DamagePercent100", True))
        Me.txtDamagePercent100.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDamagePercent100.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDamagePercent100.IsReadOnly = False
        Me.txtDamagePercent100.Location = New System.Drawing.Point(99, 165)
        Me.txtDamagePercent100.MaxLength = 15
        Me.txtDamagePercent100.Name = "txtDamagePercent100"
        Me.txtDamagePercent100.Size = New System.Drawing.Size(100, 20)
        Me.txtDamagePercent100.TabIndex = 5
        '
        'txtOverbakePercent100
        '
        Me.txtOverbakePercent100.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "OverbakePercent100", True))
        Me.txtOverbakePercent100.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtOverbakePercent100.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtOverbakePercent100.IsReadOnly = False
        Me.txtOverbakePercent100.Location = New System.Drawing.Point(99, 137)
        Me.txtOverbakePercent100.MaxLength = 15
        Me.txtOverbakePercent100.Name = "txtOverbakePercent100"
        Me.txtOverbakePercent100.Size = New System.Drawing.Size(100, 20)
        Me.txtOverbakePercent100.TabIndex = 4
        '
        'txtPromoPercent100
        '
        Me.txtPromoPercent100.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "PromoPercent100", True))
        Me.txtPromoPercent100.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPromoPercent100.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPromoPercent100.IsReadOnly = False
        Me.txtPromoPercent100.Location = New System.Drawing.Point(99, 108)
        Me.txtPromoPercent100.MaxLength = 15
        Me.txtPromoPercent100.Name = "txtPromoPercent100"
        Me.txtPromoPercent100.Size = New System.Drawing.Size(100, 20)
        Me.txtPromoPercent100.TabIndex = 3
        '
        'txtWastagePercent100
        '
        Me.txtWastagePercent100.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "WastagePercent100", True))
        Me.txtWastagePercent100.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtWastagePercent100.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtWastagePercent100.IsReadOnly = False
        Me.txtWastagePercent100.Location = New System.Drawing.Point(99, 79)
        Me.txtWastagePercent100.MaxLength = 15
        Me.txtWastagePercent100.Name = "txtWastagePercent100"
        Me.txtWastagePercent100.Size = New System.Drawing.Size(100, 20)
        Me.txtWastagePercent100.TabIndex = 2
        '
        'txtDiscountPercent20
        '
        Me.txtDiscountPercent20.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "DiscountPercent20", True))
        Me.txtDiscountPercent20.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDiscountPercent20.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDiscountPercent20.IsReadOnly = False
        Me.txtDiscountPercent20.Location = New System.Drawing.Point(99, 50)
        Me.txtDiscountPercent20.MaxLength = 15
        Me.txtDiscountPercent20.Name = "txtDiscountPercent20"
        Me.txtDiscountPercent20.Size = New System.Drawing.Size(100, 20)
        Me.txtDiscountPercent20.TabIndex = 1
        '
        'txtStaffPercent100
        '
        Me.txtStaffPercent100.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "StaffPercent100", True))
        Me.txtStaffPercent100.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtStaffPercent100.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtStaffPercent100.IsReadOnly = False
        Me.txtStaffPercent100.Location = New System.Drawing.Point(99, 21)
        Me.txtStaffPercent100.MaxLength = 15
        Me.txtStaffPercent100.Name = "txtStaffPercent100"
        Me.txtStaffPercent100.Size = New System.Drawing.Size(100, 20)
        Me.txtStaffPercent100.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(9, 199)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(71, 13)
        Me.Label13.TabIndex = 6
        Me.Label13.Text = "Sample 100%"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 169)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(76, 13)
        Me.Label12.TabIndex = 5
        Me.Label12.Text = "Damage 100%"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(9, 141)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 4
        Me.Label11.Text = "Overbake 100%"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(9, 112)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(66, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Promo 100%"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(9, 83)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(79, 13)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Wastage 100%"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(9, 54)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 13)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "Discount 20%"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(9, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 13)
        Me.Label7.TabIndex = 0
        Me.Label7.Text = "Staff 100%"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(10, 199)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(80, 13)
        Me.Label14.TabIndex = 6
        Me.Label14.Text = "Stock Variance"
        '
        'txtMemo
        '
        Me.txtMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Memo", True))
        Me.txtMemo.Location = New System.Drawing.Point(66, 227)
        Me.txtMemo.Multiline = True
        Me.txtMemo.Name = "txtMemo"
        Me.txtMemo.Size = New System.Drawing.Size(173, 77)
        Me.txtMemo.TabIndex = 6
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(18, 231)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(36, 13)
        Me.Label15.TabIndex = 9
        Me.Label15.Text = "Memo"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtVoidsValue)
        Me.GroupBox3.Controls.Add(Me.txtStockVarianceValue)
        Me.GroupBox3.Controls.Add(Me.txtVoid)
        Me.GroupBox3.Controls.Add(Me.txtErrorCorrectsValue)
        Me.GroupBox3.Controls.Add(Me.Label14)
        Me.GroupBox3.Controls.Add(Me.txtErrorCorrects)
        Me.GroupBox3.Controls.Add(Me.txtChecksPaid)
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label19)
        Me.GroupBox3.Controls.Add(Me.Label20)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.Label22)
        Me.GroupBox3.Location = New System.Drawing.Point(496, 41)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(221, 232)
        Me.GroupBox3.TabIndex = 10
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Checks And Balances"
        '
        'txtVoidsValue
        '
        Me.txtVoidsValue.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "VoidsValue", True))
        Me.txtVoidsValue.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVoidsValue.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtVoidsValue.IsReadOnly = False
        Me.txtVoidsValue.Location = New System.Drawing.Point(99, 137)
        Me.txtVoidsValue.MaxLength = 15
        Me.txtVoidsValue.Name = "txtVoidsValue"
        Me.txtVoidsValue.Size = New System.Drawing.Size(100, 20)
        Me.txtVoidsValue.TabIndex = 4
        '
        'txtStockVarianceValue
        '
        Me.txtStockVarianceValue.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "StockVarianceValue", True))
        Me.txtStockVarianceValue.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtStockVarianceValue.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtStockVarianceValue.IsReadOnly = False
        Me.txtStockVarianceValue.Location = New System.Drawing.Point(99, 195)
        Me.txtStockVarianceValue.MaxLength = 15
        Me.txtStockVarianceValue.Name = "txtStockVarianceValue"
        Me.txtStockVarianceValue.Size = New System.Drawing.Size(100, 20)
        Me.txtStockVarianceValue.TabIndex = 5
        '
        'txtVoid
        '
        Me.txtVoid.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "Void", True))
        Me.txtVoid.EditValue = 0
        Me.txtVoid.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtVoid.IsReadOnly = False
        Me.txtVoid.Location = New System.Drawing.Point(99, 108)
        Me.txtVoid.MaxLength = 15
        Me.txtVoid.Name = "txtVoid"
        Me.txtVoid.Size = New System.Drawing.Size(100, 20)
        Me.txtVoid.TabIndex = 3
        '
        'txtErrorCorrectsValue
        '
        Me.txtErrorCorrectsValue.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "ErrorCorrectsValue", True))
        Me.txtErrorCorrectsValue.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtErrorCorrectsValue.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtErrorCorrectsValue.IsReadOnly = False
        Me.txtErrorCorrectsValue.Location = New System.Drawing.Point(99, 79)
        Me.txtErrorCorrectsValue.MaxLength = 15
        Me.txtErrorCorrectsValue.Name = "txtErrorCorrectsValue"
        Me.txtErrorCorrectsValue.Size = New System.Drawing.Size(100, 20)
        Me.txtErrorCorrectsValue.TabIndex = 2
        '
        'txtErrorCorrects
        '
        Me.txtErrorCorrects.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "ErrorCorrects", True))
        Me.txtErrorCorrects.EditValue = 0
        Me.txtErrorCorrects.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtErrorCorrects.IsReadOnly = False
        Me.txtErrorCorrects.Location = New System.Drawing.Point(99, 50)
        Me.txtErrorCorrects.MaxLength = 15
        Me.txtErrorCorrects.Name = "txtErrorCorrects"
        Me.txtErrorCorrects.Size = New System.Drawing.Size(100, 20)
        Me.txtErrorCorrects.TabIndex = 1
        '
        'txtChecksPaid
        '
        Me.txtChecksPaid.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.BindingSource1, "ChecksPaid", True))
        Me.txtChecksPaid.EditValue = 0
        Me.txtChecksPaid.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtChecksPaid.IsReadOnly = False
        Me.txtChecksPaid.Location = New System.Drawing.Point(99, 21)
        Me.txtChecksPaid.MaxLength = 15
        Me.txtChecksPaid.Name = "txtChecksPaid"
        Me.txtChecksPaid.Size = New System.Drawing.Size(100, 20)
        Me.txtChecksPaid.TabIndex = 0
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(9, 141)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(72, 13)
        Me.Label18.TabIndex = 4
        Me.Label18.Text = "Voids Amount"
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(9, 112)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(33, 13)
        Me.Label19.TabIndex = 3
        Me.Label19.Text = "Voids"
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(9, 83)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(92, 13)
        Me.Label20.TabIndex = 2
        Me.Label20.Text = "Error Corrects Amt"
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(9, 54)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(71, 13)
        Me.Label21.TabIndex = 1
        Me.Label21.Text = "Error Corrects"
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(9, 25)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 13)
        Me.Label22.TabIndex = 0
        Me.Label22.Text = "Checks Paid"
        '
        'UpdateSalesForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(740, 323)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.txtMemo)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.dteDate)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "UpdateSalesForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Sales"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents dteDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTurnoverOther As CashManagement.NumericTextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents txtMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents txtGrossSales As CashManagement.NumericTextBox
    Friend WithEvents txtPayout As CashManagement.NumericTextBox
    Friend WithEvents txtTurnoverCreditCard As CashManagement.NumericTextBox
    Friend WithEvents txtTurnoverCash As CashManagement.NumericTextBox
    Friend WithEvents txtSamplePercent100 As CashManagement.NumericTextBox
    Friend WithEvents txtDamagePercent100 As CashManagement.NumericTextBox
    Friend WithEvents txtOverbakePercent100 As CashManagement.NumericTextBox
    Friend WithEvents txtPromoPercent100 As CashManagement.NumericTextBox
    Friend WithEvents txtWastagePercent100 As CashManagement.NumericTextBox
    Friend WithEvents txtDiscountPercent20 As CashManagement.NumericTextBox
    Friend WithEvents txtStaffPercent100 As CashManagement.NumericTextBox
    Friend WithEvents txtStockVarianceValue As CashManagement.NumericTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVoidsValue As CashManagement.NumericTextBox
    Friend WithEvents txtVoid As CashManagement.NumericTextBox
    Friend WithEvents txtErrorCorrectsValue As CashManagement.NumericTextBox
    Friend WithEvents txtErrorCorrects As CashManagement.NumericTextBox
    Friend WithEvents txtChecksPaid As CashManagement.NumericTextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
End Class
