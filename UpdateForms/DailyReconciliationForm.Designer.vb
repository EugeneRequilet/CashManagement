<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DailyReconcForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.dteSelectDate = New System.Windows.Forms.DateTimePicker()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Cashup1Group = New System.Windows.Forms.GroupBox()
        Me.txtCashup1Employee = New System.Windows.Forms.TextBox()
        Me.EmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Cashup2Group = New System.Windows.Forms.GroupBox()
        Me.txtCashup2Employee = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Cashup3Group = New System.Windows.Forms.GroupBox()
        Me.txtCashup3Employee = New System.Windows.Forms.TextBox()
        Me.Cashup4Group = New System.Windows.Forms.GroupBox()
        Me.txtCashup4Employee = New System.Windows.Forms.TextBox()
        Me.CashupBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.txtCashTotalQuestion = New System.Windows.Forms.Label()
        Me.txtPayoutTotalQuestion = New System.Windows.Forms.Label()
        Me.txtCreditCardTotalQuestion = New System.Windows.Forms.Label()
        Me.txtSalesGrossQuestion = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.ExcelButton = New System.Windows.Forms.Button()
        Me.txtVarianceSalesGross = New CashManagement.NumericTextBox()
        Me.txtVariancePayoutTotal = New CashManagement.NumericTextBox()
        Me.txtVarianceCashTotal = New CashManagement.NumericTextBox()
        Me.txtVarianceCreditCardTotal = New CashManagement.NumericTextBox()
        Me.txtCashup4Variance = New CashManagement.NumericTextBox()
        Me.txtCashup4Adjustment = New CashManagement.NumericTextBox()
        Me.txtCashup4Deposit = New CashManagement.NumericTextBox()
        Me.txtCashup4Skims = New CashManagement.NumericTextBox()
        Me.txtCashup4Payout = New CashManagement.NumericTextBox()
        Me.txtCashup4Cash = New CashManagement.NumericTextBox()
        Me.txtCashup4CreditCard = New CashManagement.NumericTextBox()
        Me.txtCashup3Variance = New CashManagement.NumericTextBox()
        Me.txtCashup3Adjustment = New CashManagement.NumericTextBox()
        Me.txtCashup3Deposit = New CashManagement.NumericTextBox()
        Me.txtCashup3Skims = New CashManagement.NumericTextBox()
        Me.txtCashup3Payout = New CashManagement.NumericTextBox()
        Me.txtCashup3Cash = New CashManagement.NumericTextBox()
        Me.txtCashup3CreditCard = New CashManagement.NumericTextBox()
        Me.txtCashupVarianceTotal = New CashManagement.NumericTextBox()
        Me.txtCashupAdjustmentTotal = New CashManagement.NumericTextBox()
        Me.txtCashupSalesGross = New CashManagement.NumericTextBox()
        Me.txtCashupDepositTotal = New CashManagement.NumericTextBox()
        Me.txtCashupPayoutTotal = New CashManagement.NumericTextBox()
        Me.txtCashupCashTotal = New CashManagement.NumericTextBox()
        Me.txtCashupCreditCardTotal = New CashManagement.NumericTextBox()
        Me.txtCashup2Variance = New CashManagement.NumericTextBox()
        Me.txtCashup2Adjustment = New CashManagement.NumericTextBox()
        Me.txtCashup2Deposit = New CashManagement.NumericTextBox()
        Me.txtCashup2Skims = New CashManagement.NumericTextBox()
        Me.txtCashup2Payout = New CashManagement.NumericTextBox()
        Me.txtCashup2Cash = New CashManagement.NumericTextBox()
        Me.txtCashup2CreditCard = New CashManagement.NumericTextBox()
        Me.txtCashup1Variance = New CashManagement.NumericTextBox()
        Me.txtCashup1Adjustment = New CashManagement.NumericTextBox()
        Me.txtCashup1Deposit = New CashManagement.NumericTextBox()
        Me.txtCashup1Skims = New CashManagement.NumericTextBox()
        Me.txtCashup1Payout = New CashManagement.NumericTextBox()
        Me.txtCashup1Cash = New CashManagement.NumericTextBox()
        Me.txtCashup1CreditCard = New CashManagement.NumericTextBox()
        Me.txtSalesCreditCard = New CashManagement.NumericTextBox()
        Me.txtSalesCash = New CashManagement.NumericTextBox()
        Me.txtSalesPayout = New CashManagement.NumericTextBox()
        Me.txtSalesGross = New CashManagement.NumericTextBox()
        Me.SalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        Me.Cashup1Group.SuspendLayout()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Cashup2Group.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Cashup3Group.SuspendLayout()
        Me.Cashup4Group.SuspendLayout()
        CType(Me.CashupBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.SalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtSalesCreditCard)
        Me.GroupBox1.Controls.Add(Me.txtSalesCash)
        Me.GroupBox1.Controls.Add(Me.txtSalesPayout)
        Me.GroupBox1.Controls.Add(Me.txtSalesGross)
        Me.GroupBox1.Location = New System.Drawing.Point(268, 283)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(136, 135)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Daily Sales"
        '
        'dteSelectDate
        '
        Me.dteSelectDate.Location = New System.Drawing.Point(122, 13)
        Me.dteSelectDate.Name = "dteSelectDate"
        Me.dteSelectDate.Size = New System.Drawing.Size(182, 20)
        Me.dteSelectDate.TabIndex = 5
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 17)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(101, 13)
        Me.Label8.TabIndex = 6
        Me.Label8.Text = "Select Date to View"
        '
        'Cashup1Group
        '
        Me.Cashup1Group.Controls.Add(Me.txtCashup1Variance)
        Me.Cashup1Group.Controls.Add(Me.txtCashup1Adjustment)
        Me.Cashup1Group.Controls.Add(Me.txtCashup1Employee)
        Me.Cashup1Group.Controls.Add(Me.txtCashup1Deposit)
        Me.Cashup1Group.Controls.Add(Me.txtCashup1Skims)
        Me.Cashup1Group.Controls.Add(Me.txtCashup1Payout)
        Me.Cashup1Group.Controls.Add(Me.txtCashup1Cash)
        Me.Cashup1Group.Controls.Add(Me.txtCashup1CreditCard)
        Me.Cashup1Group.Location = New System.Drawing.Point(122, 39)
        Me.Cashup1Group.Name = "Cashup1Group"
        Me.Cashup1Group.Size = New System.Drawing.Size(136, 238)
        Me.Cashup1Group.TabIndex = 7
        Me.Cashup1Group.TabStop = False
        Me.Cashup1Group.Text = "Cash-up 1"
        Me.Cashup1Group.Visible = False
        '
        'txtCashup1Employee
        '
        Me.txtCashup1Employee.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "Description", True))
        Me.txtCashup1Employee.Location = New System.Drawing.Point(21, 21)
        Me.txtCashup1Employee.Name = "txtCashup1Employee"
        Me.txtCashup1Employee.ReadOnly = True
        Me.txtCashup1Employee.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup1Employee.TabIndex = 23
        Me.txtCashup1Employee.TabStop = False
        '
        'EmployeeBindingSource
        '
        Me.EmployeeBindingSource.DataSource = GetType(CashManagement.Employee)
        '
        'Cashup2Group
        '
        Me.Cashup2Group.Controls.Add(Me.txtCashup2Variance)
        Me.Cashup2Group.Controls.Add(Me.txtCashup2Adjustment)
        Me.Cashup2Group.Controls.Add(Me.txtCashup2Employee)
        Me.Cashup2Group.Controls.Add(Me.txtCashup2Deposit)
        Me.Cashup2Group.Controls.Add(Me.txtCashup2Skims)
        Me.Cashup2Group.Controls.Add(Me.txtCashup2Payout)
        Me.Cashup2Group.Controls.Add(Me.txtCashup2Cash)
        Me.Cashup2Group.Controls.Add(Me.txtCashup2CreditCard)
        Me.Cashup2Group.Location = New System.Drawing.Point(268, 39)
        Me.Cashup2Group.Name = "Cashup2Group"
        Me.Cashup2Group.Size = New System.Drawing.Size(136, 238)
        Me.Cashup2Group.TabIndex = 8
        Me.Cashup2Group.TabStop = False
        Me.Cashup2Group.Text = "Cash-up 2"
        Me.Cashup2Group.Visible = False
        '
        'txtCashup2Employee
        '
        Me.txtCashup2Employee.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "Description", True))
        Me.txtCashup2Employee.Location = New System.Drawing.Point(21, 21)
        Me.txtCashup2Employee.Name = "txtCashup2Employee"
        Me.txtCashup2Employee.ReadOnly = True
        Me.txtCashup2Employee.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup2Employee.TabIndex = 24
        Me.txtCashup2Employee.TabStop = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.txtCashupVarianceTotal)
        Me.GroupBox2.Controls.Add(Me.txtCashupAdjustmentTotal)
        Me.GroupBox2.Controls.Add(Me.txtCashupSalesGross)
        Me.GroupBox2.Controls.Add(Me.txtCashupDepositTotal)
        Me.GroupBox2.Controls.Add(Me.txtCashupPayoutTotal)
        Me.GroupBox2.Controls.Add(Me.txtCashupCashTotal)
        Me.GroupBox2.Controls.Add(Me.txtCashupCreditCardTotal)
        Me.GroupBox2.Location = New System.Drawing.Point(122, 283)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(136, 218)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Daily Cashup Totals"
        '
        'Cashup3Group
        '
        Me.Cashup3Group.Controls.Add(Me.txtCashup3Variance)
        Me.Cashup3Group.Controls.Add(Me.txtCashup3Adjustment)
        Me.Cashup3Group.Controls.Add(Me.txtCashup3Employee)
        Me.Cashup3Group.Controls.Add(Me.txtCashup3Deposit)
        Me.Cashup3Group.Controls.Add(Me.txtCashup3Skims)
        Me.Cashup3Group.Controls.Add(Me.txtCashup3Payout)
        Me.Cashup3Group.Controls.Add(Me.txtCashup3Cash)
        Me.Cashup3Group.Controls.Add(Me.txtCashup3CreditCard)
        Me.Cashup3Group.Location = New System.Drawing.Point(415, 39)
        Me.Cashup3Group.Name = "Cashup3Group"
        Me.Cashup3Group.Size = New System.Drawing.Size(136, 238)
        Me.Cashup3Group.TabIndex = 18
        Me.Cashup3Group.TabStop = False
        Me.Cashup3Group.Text = "Cash-up 3"
        Me.Cashup3Group.Visible = False
        '
        'txtCashup3Employee
        '
        Me.txtCashup3Employee.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "Description", True))
        Me.txtCashup3Employee.Location = New System.Drawing.Point(21, 21)
        Me.txtCashup3Employee.Name = "txtCashup3Employee"
        Me.txtCashup3Employee.ReadOnly = True
        Me.txtCashup3Employee.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup3Employee.TabIndex = 25
        Me.txtCashup3Employee.TabStop = False
        '
        'Cashup4Group
        '
        Me.Cashup4Group.Controls.Add(Me.txtCashup4Variance)
        Me.Cashup4Group.Controls.Add(Me.txtCashup4Adjustment)
        Me.Cashup4Group.Controls.Add(Me.txtCashup4Employee)
        Me.Cashup4Group.Controls.Add(Me.txtCashup4Deposit)
        Me.Cashup4Group.Controls.Add(Me.txtCashup4Skims)
        Me.Cashup4Group.Controls.Add(Me.txtCashup4Payout)
        Me.Cashup4Group.Controls.Add(Me.txtCashup4Cash)
        Me.Cashup4Group.Controls.Add(Me.txtCashup4CreditCard)
        Me.Cashup4Group.Location = New System.Drawing.Point(562, 39)
        Me.Cashup4Group.Name = "Cashup4Group"
        Me.Cashup4Group.Size = New System.Drawing.Size(136, 238)
        Me.Cashup4Group.TabIndex = 19
        Me.Cashup4Group.TabStop = False
        Me.Cashup4Group.Text = "Cash-up 4"
        Me.Cashup4Group.Visible = False
        '
        'txtCashup4Employee
        '
        Me.txtCashup4Employee.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "Description", True))
        Me.txtCashup4Employee.Location = New System.Drawing.Point(21, 21)
        Me.txtCashup4Employee.Name = "txtCashup4Employee"
        Me.txtCashup4Employee.ReadOnly = True
        Me.txtCashup4Employee.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup4Employee.TabIndex = 26
        Me.txtCashup4Employee.TabStop = False
        '
        'CashupBindingSource
        '
        Me.CashupBindingSource.DataSource = GetType(CashManagement.CashUp)
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Location = New System.Drawing.Point(627, 480)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 21
        Me.CloseButton.Text = "&Exit"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(12, 216)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(82, 13)
        Me.Label9.TabIndex = 29
        Me.Label9.Text = "Cash Deposited"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(12, 138)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(74, 13)
        Me.Label10.TabIndex = 28
        Me.Label10.Text = "Deposit Skims"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(12, 86)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(59, 13)
        Me.Label12.TabIndex = 26
        Me.Label12.Text = "Credit Card"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(12, 164)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(31, 13)
        Me.Label13.TabIndex = 25
        Me.Label13.Text = "Cash"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(12, 112)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(45, 13)
        Me.Label14.TabIndex = 24
        Me.Label14.Text = "Pay Out"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(12, 60)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(53, 13)
        Me.Label15.TabIndex = 23
        Me.Label15.Text = "Employee"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 441)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(82, 13)
        Me.Label1.TabIndex = 36
        Me.Label1.Text = "Cash Deposited"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(14, 333)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(59, 13)
        Me.Label4.TabIndex = 33
        Me.Label4.Text = "Credit Card"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(14, 388)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(108, 13)
        Me.Label5.TabIndex = 32
        Me.Label5.Text = "Cash Including Skims"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 360)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(45, 13)
        Me.Label6.TabIndex = 31
        Me.Label6.Text = "Pay Out"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 306)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(63, 13)
        Me.Label7.TabIndex = 30
        Me.Label7.Text = "Gross Sales"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtCashTotalQuestion)
        Me.GroupBox3.Controls.Add(Me.txtPayoutTotalQuestion)
        Me.GroupBox3.Controls.Add(Me.txtCreditCardTotalQuestion)
        Me.GroupBox3.Controls.Add(Me.txtSalesGrossQuestion)
        Me.GroupBox3.Controls.Add(Me.txtVarianceSalesGross)
        Me.GroupBox3.Controls.Add(Me.txtVariancePayoutTotal)
        Me.GroupBox3.Controls.Add(Me.txtVarianceCashTotal)
        Me.GroupBox3.Controls.Add(Me.txtVarianceCreditCardTotal)
        Me.GroupBox3.Location = New System.Drawing.Point(415, 283)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(283, 135)
        Me.GroupBox3.TabIndex = 19
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Daily Cashup Variance"
        '
        'txtCashTotalQuestion
        '
        Me.txtCashTotalQuestion.AutoSize = True
        Me.txtCashTotalQuestion.Location = New System.Drawing.Point(134, 107)
        Me.txtCashTotalQuestion.Name = "txtCashTotalQuestion"
        Me.txtCashTotalQuestion.Size = New System.Drawing.Size(110, 13)
        Me.txtCashTotalQuestion.TabIndex = 22
        Me.txtCashTotalQuestion.Text = "This is a problem here"
        Me.txtCashTotalQuestion.Visible = False
        '
        'txtPayoutTotalQuestion
        '
        Me.txtPayoutTotalQuestion.AutoSize = True
        Me.txtPayoutTotalQuestion.Location = New System.Drawing.Point(134, 80)
        Me.txtPayoutTotalQuestion.Name = "txtPayoutTotalQuestion"
        Me.txtPayoutTotalQuestion.Size = New System.Drawing.Size(110, 13)
        Me.txtPayoutTotalQuestion.TabIndex = 21
        Me.txtPayoutTotalQuestion.Text = "This is a problem here"
        Me.txtPayoutTotalQuestion.Visible = False
        '
        'txtCreditCardTotalQuestion
        '
        Me.txtCreditCardTotalQuestion.AutoSize = True
        Me.txtCreditCardTotalQuestion.Location = New System.Drawing.Point(134, 53)
        Me.txtCreditCardTotalQuestion.Name = "txtCreditCardTotalQuestion"
        Me.txtCreditCardTotalQuestion.Size = New System.Drawing.Size(110, 13)
        Me.txtCreditCardTotalQuestion.TabIndex = 20
        Me.txtCreditCardTotalQuestion.Text = "This is a problem here"
        Me.txtCreditCardTotalQuestion.Visible = False
        '
        'txtSalesGrossQuestion
        '
        Me.txtSalesGrossQuestion.AutoSize = True
        Me.txtSalesGrossQuestion.Location = New System.Drawing.Point(134, 25)
        Me.txtSalesGrossQuestion.Name = "txtSalesGrossQuestion"
        Me.txtSalesGrossQuestion.Size = New System.Drawing.Size(110, 13)
        Me.txtSalesGrossQuestion.TabIndex = 19
        Me.txtSalesGrossQuestion.Text = "This is a problem here"
        Me.txtSalesGrossQuestion.Visible = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(14, 414)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(102, 13)
        Me.Label3.TabIndex = 37
        Me.Label3.Text = "Deposit Adjusted By"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(12, 190)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(102, 13)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "Deposit Adjusted By"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(12, 242)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(87, 13)
        Me.Label16.TabIndex = 39
        Me.Label16.Text = "Cashier Variance"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(14, 468)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(87, 13)
        Me.Label17.TabIndex = 40
        Me.Label17.Text = "Cashier Variance"
        '
        'ExcelButton
        '
        Me.ExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExcelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ExcelButton.Location = New System.Drawing.Point(541, 481)
        Me.ExcelButton.Name = "ExcelButton"
        Me.ExcelButton.Size = New System.Drawing.Size(75, 23)
        Me.ExcelButton.TabIndex = 66
        Me.ExcelButton.Text = "&Excel Export"
        Me.ExcelButton.UseVisualStyleBackColor = True
        '
        'txtVarianceSalesGross
        '
        Me.txtVarianceSalesGross.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVarianceSalesGross.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtVarianceSalesGross.IsReadOnly = True
        Me.txtVarianceSalesGross.Location = New System.Drawing.Point(21, 21)
        Me.txtVarianceSalesGross.MaxLength = 15
        Me.txtVarianceSalesGross.Name = "txtVarianceSalesGross"
        Me.txtVarianceSalesGross.Size = New System.Drawing.Size(100, 20)
        Me.txtVarianceSalesGross.TabIndex = 18
        Me.txtVarianceSalesGross.TabStop = False
        '
        'txtVariancePayoutTotal
        '
        Me.txtVariancePayoutTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVariancePayoutTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtVariancePayoutTotal.IsReadOnly = True
        Me.txtVariancePayoutTotal.Location = New System.Drawing.Point(21, 76)
        Me.txtVariancePayoutTotal.MaxLength = 15
        Me.txtVariancePayoutTotal.Name = "txtVariancePayoutTotal"
        Me.txtVariancePayoutTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtVariancePayoutTotal.TabIndex = 15
        Me.txtVariancePayoutTotal.TabStop = False
        '
        'txtVarianceCashTotal
        '
        Me.txtVarianceCashTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVarianceCashTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtVarianceCashTotal.IsReadOnly = True
        Me.txtVarianceCashTotal.Location = New System.Drawing.Point(21, 103)
        Me.txtVarianceCashTotal.MaxLength = 15
        Me.txtVarianceCashTotal.Name = "txtVarianceCashTotal"
        Me.txtVarianceCashTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtVarianceCashTotal.TabIndex = 14
        Me.txtVarianceCashTotal.TabStop = False
        '
        'txtVarianceCreditCardTotal
        '
        Me.txtVarianceCreditCardTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtVarianceCreditCardTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtVarianceCreditCardTotal.IsReadOnly = True
        Me.txtVarianceCreditCardTotal.Location = New System.Drawing.Point(21, 49)
        Me.txtVarianceCreditCardTotal.MaxLength = 15
        Me.txtVarianceCreditCardTotal.Name = "txtVarianceCreditCardTotal"
        Me.txtVarianceCreditCardTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtVarianceCreditCardTotal.TabIndex = 13
        Me.txtVarianceCreditCardTotal.TabStop = False
        '
        'txtCashup4Variance
        '
        Me.txtCashup4Variance.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup4Variance.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup4Variance.IsReadOnly = True
        Me.txtCashup4Variance.Location = New System.Drawing.Point(21, 203)
        Me.txtCashup4Variance.MaxLength = 15
        Me.txtCashup4Variance.Name = "txtCashup4Variance"
        Me.txtCashup4Variance.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup4Variance.TabIndex = 28
        Me.txtCashup4Variance.TabStop = False
        '
        'txtCashup4Adjustment
        '
        Me.txtCashup4Adjustment.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup4Adjustment.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup4Adjustment.IsReadOnly = True
        Me.txtCashup4Adjustment.Location = New System.Drawing.Point(21, 151)
        Me.txtCashup4Adjustment.MaxLength = 15
        Me.txtCashup4Adjustment.Name = "txtCashup4Adjustment"
        Me.txtCashup4Adjustment.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup4Adjustment.TabIndex = 27
        Me.txtCashup4Adjustment.TabStop = False
        '
        'txtCashup4Deposit
        '
        Me.txtCashup4Deposit.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup4Deposit.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup4Deposit.IsReadOnly = True
        Me.txtCashup4Deposit.Location = New System.Drawing.Point(21, 177)
        Me.txtCashup4Deposit.MaxLength = 15
        Me.txtCashup4Deposit.Name = "txtCashup4Deposit"
        Me.txtCashup4Deposit.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup4Deposit.TabIndex = 17
        Me.txtCashup4Deposit.TabStop = False
        '
        'txtCashup4Skims
        '
        Me.txtCashup4Skims.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup4Skims.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup4Skims.IsReadOnly = True
        Me.txtCashup4Skims.Location = New System.Drawing.Point(21, 99)
        Me.txtCashup4Skims.MaxLength = 15
        Me.txtCashup4Skims.Name = "txtCashup4Skims"
        Me.txtCashup4Skims.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup4Skims.TabIndex = 16
        Me.txtCashup4Skims.TabStop = False
        '
        'txtCashup4Payout
        '
        Me.txtCashup4Payout.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup4Payout.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup4Payout.IsReadOnly = True
        Me.txtCashup4Payout.Location = New System.Drawing.Point(21, 73)
        Me.txtCashup4Payout.MaxLength = 15
        Me.txtCashup4Payout.Name = "txtCashup4Payout"
        Me.txtCashup4Payout.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup4Payout.TabIndex = 15
        Me.txtCashup4Payout.TabStop = False
        '
        'txtCashup4Cash
        '
        Me.txtCashup4Cash.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup4Cash.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup4Cash.IsReadOnly = True
        Me.txtCashup4Cash.Location = New System.Drawing.Point(21, 125)
        Me.txtCashup4Cash.MaxLength = 15
        Me.txtCashup4Cash.Name = "txtCashup4Cash"
        Me.txtCashup4Cash.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup4Cash.TabIndex = 14
        Me.txtCashup4Cash.TabStop = False
        '
        'txtCashup4CreditCard
        '
        Me.txtCashup4CreditCard.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup4CreditCard.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup4CreditCard.IsReadOnly = True
        Me.txtCashup4CreditCard.Location = New System.Drawing.Point(21, 47)
        Me.txtCashup4CreditCard.MaxLength = 15
        Me.txtCashup4CreditCard.Name = "txtCashup4CreditCard"
        Me.txtCashup4CreditCard.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup4CreditCard.TabIndex = 13
        Me.txtCashup4CreditCard.TabStop = False
        '
        'txtCashup3Variance
        '
        Me.txtCashup3Variance.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup3Variance.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup3Variance.IsReadOnly = True
        Me.txtCashup3Variance.Location = New System.Drawing.Point(21, 203)
        Me.txtCashup3Variance.MaxLength = 15
        Me.txtCashup3Variance.Name = "txtCashup3Variance"
        Me.txtCashup3Variance.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup3Variance.TabIndex = 27
        Me.txtCashup3Variance.TabStop = False
        '
        'txtCashup3Adjustment
        '
        Me.txtCashup3Adjustment.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup3Adjustment.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup3Adjustment.IsReadOnly = True
        Me.txtCashup3Adjustment.Location = New System.Drawing.Point(21, 151)
        Me.txtCashup3Adjustment.MaxLength = 15
        Me.txtCashup3Adjustment.Name = "txtCashup3Adjustment"
        Me.txtCashup3Adjustment.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup3Adjustment.TabIndex = 26
        Me.txtCashup3Adjustment.TabStop = False
        '
        'txtCashup3Deposit
        '
        Me.txtCashup3Deposit.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup3Deposit.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup3Deposit.IsReadOnly = True
        Me.txtCashup3Deposit.Location = New System.Drawing.Point(21, 177)
        Me.txtCashup3Deposit.MaxLength = 15
        Me.txtCashup3Deposit.Name = "txtCashup3Deposit"
        Me.txtCashup3Deposit.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup3Deposit.TabIndex = 17
        Me.txtCashup3Deposit.TabStop = False
        '
        'txtCashup3Skims
        '
        Me.txtCashup3Skims.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup3Skims.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup3Skims.IsReadOnly = True
        Me.txtCashup3Skims.Location = New System.Drawing.Point(21, 99)
        Me.txtCashup3Skims.MaxLength = 15
        Me.txtCashup3Skims.Name = "txtCashup3Skims"
        Me.txtCashup3Skims.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup3Skims.TabIndex = 16
        Me.txtCashup3Skims.TabStop = False
        '
        'txtCashup3Payout
        '
        Me.txtCashup3Payout.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup3Payout.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup3Payout.IsReadOnly = True
        Me.txtCashup3Payout.Location = New System.Drawing.Point(21, 73)
        Me.txtCashup3Payout.MaxLength = 15
        Me.txtCashup3Payout.Name = "txtCashup3Payout"
        Me.txtCashup3Payout.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup3Payout.TabIndex = 15
        Me.txtCashup3Payout.TabStop = False
        '
        'txtCashup3Cash
        '
        Me.txtCashup3Cash.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup3Cash.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup3Cash.IsReadOnly = True
        Me.txtCashup3Cash.Location = New System.Drawing.Point(21, 125)
        Me.txtCashup3Cash.MaxLength = 15
        Me.txtCashup3Cash.Name = "txtCashup3Cash"
        Me.txtCashup3Cash.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup3Cash.TabIndex = 14
        Me.txtCashup3Cash.TabStop = False
        '
        'txtCashup3CreditCard
        '
        Me.txtCashup3CreditCard.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup3CreditCard.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup3CreditCard.IsReadOnly = True
        Me.txtCashup3CreditCard.Location = New System.Drawing.Point(21, 47)
        Me.txtCashup3CreditCard.MaxLength = 15
        Me.txtCashup3CreditCard.Name = "txtCashup3CreditCard"
        Me.txtCashup3CreditCard.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup3CreditCard.TabIndex = 13
        Me.txtCashup3CreditCard.TabStop = False
        '
        'txtCashupVarianceTotal
        '
        Me.txtCashupVarianceTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashupVarianceTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashupVarianceTotal.IsReadOnly = True
        Me.txtCashupVarianceTotal.Location = New System.Drawing.Point(21, 181)
        Me.txtCashupVarianceTotal.MaxLength = 15
        Me.txtCashupVarianceTotal.Name = "txtCashupVarianceTotal"
        Me.txtCashupVarianceTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtCashupVarianceTotal.TabIndex = 40
        Me.txtCashupVarianceTotal.TabStop = False
        '
        'txtCashupAdjustmentTotal
        '
        Me.txtCashupAdjustmentTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashupAdjustmentTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashupAdjustmentTotal.IsReadOnly = True
        Me.txtCashupAdjustmentTotal.Location = New System.Drawing.Point(21, 128)
        Me.txtCashupAdjustmentTotal.MaxLength = 15
        Me.txtCashupAdjustmentTotal.Name = "txtCashupAdjustmentTotal"
        Me.txtCashupAdjustmentTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtCashupAdjustmentTotal.TabIndex = 19
        Me.txtCashupAdjustmentTotal.TabStop = False
        '
        'txtCashupSalesGross
        '
        Me.txtCashupSalesGross.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashupSalesGross.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashupSalesGross.IsReadOnly = True
        Me.txtCashupSalesGross.Location = New System.Drawing.Point(21, 21)
        Me.txtCashupSalesGross.MaxLength = 15
        Me.txtCashupSalesGross.Name = "txtCashupSalesGross"
        Me.txtCashupSalesGross.Size = New System.Drawing.Size(100, 20)
        Me.txtCashupSalesGross.TabIndex = 18
        Me.txtCashupSalesGross.TabStop = False
        '
        'txtCashupDepositTotal
        '
        Me.txtCashupDepositTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashupDepositTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashupDepositTotal.IsReadOnly = True
        Me.txtCashupDepositTotal.Location = New System.Drawing.Point(21, 155)
        Me.txtCashupDepositTotal.MaxLength = 15
        Me.txtCashupDepositTotal.Name = "txtCashupDepositTotal"
        Me.txtCashupDepositTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtCashupDepositTotal.TabIndex = 17
        Me.txtCashupDepositTotal.TabStop = False
        '
        'txtCashupPayoutTotal
        '
        Me.txtCashupPayoutTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashupPayoutTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashupPayoutTotal.IsReadOnly = True
        Me.txtCashupPayoutTotal.Location = New System.Drawing.Point(21, 76)
        Me.txtCashupPayoutTotal.MaxLength = 15
        Me.txtCashupPayoutTotal.Name = "txtCashupPayoutTotal"
        Me.txtCashupPayoutTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtCashupPayoutTotal.TabIndex = 15
        Me.txtCashupPayoutTotal.TabStop = False
        '
        'txtCashupCashTotal
        '
        Me.txtCashupCashTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashupCashTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashupCashTotal.IsReadOnly = True
        Me.txtCashupCashTotal.Location = New System.Drawing.Point(21, 103)
        Me.txtCashupCashTotal.MaxLength = 15
        Me.txtCashupCashTotal.Name = "txtCashupCashTotal"
        Me.txtCashupCashTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtCashupCashTotal.TabIndex = 14
        Me.txtCashupCashTotal.TabStop = False
        '
        'txtCashupCreditCardTotal
        '
        Me.txtCashupCreditCardTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashupCreditCardTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashupCreditCardTotal.IsReadOnly = True
        Me.txtCashupCreditCardTotal.Location = New System.Drawing.Point(21, 49)
        Me.txtCashupCreditCardTotal.MaxLength = 15
        Me.txtCashupCreditCardTotal.Name = "txtCashupCreditCardTotal"
        Me.txtCashupCreditCardTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtCashupCreditCardTotal.TabIndex = 13
        Me.txtCashupCreditCardTotal.TabStop = False
        '
        'txtCashup2Variance
        '
        Me.txtCashup2Variance.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup2Variance.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup2Variance.IsReadOnly = True
        Me.txtCashup2Variance.Location = New System.Drawing.Point(21, 203)
        Me.txtCashup2Variance.MaxLength = 15
        Me.txtCashup2Variance.Name = "txtCashup2Variance"
        Me.txtCashup2Variance.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup2Variance.TabIndex = 26
        Me.txtCashup2Variance.TabStop = False
        '
        'txtCashup2Adjustment
        '
        Me.txtCashup2Adjustment.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup2Adjustment.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup2Adjustment.IsReadOnly = True
        Me.txtCashup2Adjustment.Location = New System.Drawing.Point(21, 151)
        Me.txtCashup2Adjustment.MaxLength = 15
        Me.txtCashup2Adjustment.Name = "txtCashup2Adjustment"
        Me.txtCashup2Adjustment.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup2Adjustment.TabIndex = 25
        Me.txtCashup2Adjustment.TabStop = False
        '
        'txtCashup2Deposit
        '
        Me.txtCashup2Deposit.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup2Deposit.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup2Deposit.IsReadOnly = True
        Me.txtCashup2Deposit.Location = New System.Drawing.Point(21, 177)
        Me.txtCashup2Deposit.MaxLength = 15
        Me.txtCashup2Deposit.Name = "txtCashup2Deposit"
        Me.txtCashup2Deposit.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup2Deposit.TabIndex = 17
        Me.txtCashup2Deposit.TabStop = False
        '
        'txtCashup2Skims
        '
        Me.txtCashup2Skims.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup2Skims.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup2Skims.IsReadOnly = True
        Me.txtCashup2Skims.Location = New System.Drawing.Point(21, 99)
        Me.txtCashup2Skims.MaxLength = 15
        Me.txtCashup2Skims.Name = "txtCashup2Skims"
        Me.txtCashup2Skims.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup2Skims.TabIndex = 16
        Me.txtCashup2Skims.TabStop = False
        '
        'txtCashup2Payout
        '
        Me.txtCashup2Payout.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup2Payout.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup2Payout.IsReadOnly = True
        Me.txtCashup2Payout.Location = New System.Drawing.Point(21, 73)
        Me.txtCashup2Payout.MaxLength = 15
        Me.txtCashup2Payout.Name = "txtCashup2Payout"
        Me.txtCashup2Payout.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup2Payout.TabIndex = 15
        Me.txtCashup2Payout.TabStop = False
        '
        'txtCashup2Cash
        '
        Me.txtCashup2Cash.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup2Cash.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup2Cash.IsReadOnly = True
        Me.txtCashup2Cash.Location = New System.Drawing.Point(21, 125)
        Me.txtCashup2Cash.MaxLength = 15
        Me.txtCashup2Cash.Name = "txtCashup2Cash"
        Me.txtCashup2Cash.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup2Cash.TabIndex = 14
        Me.txtCashup2Cash.TabStop = False
        '
        'txtCashup2CreditCard
        '
        Me.txtCashup2CreditCard.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup2CreditCard.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup2CreditCard.IsReadOnly = True
        Me.txtCashup2CreditCard.Location = New System.Drawing.Point(21, 47)
        Me.txtCashup2CreditCard.MaxLength = 15
        Me.txtCashup2CreditCard.Name = "txtCashup2CreditCard"
        Me.txtCashup2CreditCard.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup2CreditCard.TabIndex = 13
        Me.txtCashup2CreditCard.TabStop = False
        '
        'txtCashup1Variance
        '
        Me.txtCashup1Variance.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup1Variance.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup1Variance.IsReadOnly = True
        Me.txtCashup1Variance.Location = New System.Drawing.Point(21, 203)
        Me.txtCashup1Variance.MaxLength = 15
        Me.txtCashup1Variance.Name = "txtCashup1Variance"
        Me.txtCashup1Variance.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup1Variance.TabIndex = 25
        Me.txtCashup1Variance.TabStop = False
        '
        'txtCashup1Adjustment
        '
        Me.txtCashup1Adjustment.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup1Adjustment.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup1Adjustment.IsReadOnly = True
        Me.txtCashup1Adjustment.Location = New System.Drawing.Point(21, 151)
        Me.txtCashup1Adjustment.MaxLength = 15
        Me.txtCashup1Adjustment.Name = "txtCashup1Adjustment"
        Me.txtCashup1Adjustment.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup1Adjustment.TabIndex = 24
        Me.txtCashup1Adjustment.TabStop = False
        '
        'txtCashup1Deposit
        '
        Me.txtCashup1Deposit.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup1Deposit.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup1Deposit.IsReadOnly = True
        Me.txtCashup1Deposit.Location = New System.Drawing.Point(21, 177)
        Me.txtCashup1Deposit.MaxLength = 15
        Me.txtCashup1Deposit.Name = "txtCashup1Deposit"
        Me.txtCashup1Deposit.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup1Deposit.TabIndex = 17
        Me.txtCashup1Deposit.TabStop = False
        '
        'txtCashup1Skims
        '
        Me.txtCashup1Skims.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup1Skims.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup1Skims.IsReadOnly = True
        Me.txtCashup1Skims.Location = New System.Drawing.Point(21, 99)
        Me.txtCashup1Skims.MaxLength = 15
        Me.txtCashup1Skims.Name = "txtCashup1Skims"
        Me.txtCashup1Skims.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup1Skims.TabIndex = 16
        Me.txtCashup1Skims.TabStop = False
        '
        'txtCashup1Payout
        '
        Me.txtCashup1Payout.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup1Payout.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup1Payout.IsReadOnly = True
        Me.txtCashup1Payout.Location = New System.Drawing.Point(21, 73)
        Me.txtCashup1Payout.MaxLength = 15
        Me.txtCashup1Payout.Name = "txtCashup1Payout"
        Me.txtCashup1Payout.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup1Payout.TabIndex = 15
        Me.txtCashup1Payout.TabStop = False
        '
        'txtCashup1Cash
        '
        Me.txtCashup1Cash.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup1Cash.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup1Cash.IsReadOnly = True
        Me.txtCashup1Cash.Location = New System.Drawing.Point(21, 125)
        Me.txtCashup1Cash.MaxLength = 15
        Me.txtCashup1Cash.Name = "txtCashup1Cash"
        Me.txtCashup1Cash.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup1Cash.TabIndex = 14
        Me.txtCashup1Cash.TabStop = False
        '
        'txtCashup1CreditCard
        '
        Me.txtCashup1CreditCard.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashup1CreditCard.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashup1CreditCard.IsReadOnly = True
        Me.txtCashup1CreditCard.Location = New System.Drawing.Point(21, 47)
        Me.txtCashup1CreditCard.MaxLength = 15
        Me.txtCashup1CreditCard.Name = "txtCashup1CreditCard"
        Me.txtCashup1CreditCard.Size = New System.Drawing.Size(100, 20)
        Me.txtCashup1CreditCard.TabIndex = 13
        Me.txtCashup1CreditCard.TabStop = False
        '
        'txtSalesCreditCard
        '
        Me.txtSalesCreditCard.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSalesCreditCard.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtSalesCreditCard.IsReadOnly = True
        Me.txtSalesCreditCard.Location = New System.Drawing.Point(21, 49)
        Me.txtSalesCreditCard.MaxLength = 15
        Me.txtSalesCreditCard.Name = "txtSalesCreditCard"
        Me.txtSalesCreditCard.Size = New System.Drawing.Size(100, 20)
        Me.txtSalesCreditCard.TabIndex = 3
        Me.txtSalesCreditCard.TabStop = False
        '
        'txtSalesCash
        '
        Me.txtSalesCash.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSalesCash.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtSalesCash.IsReadOnly = True
        Me.txtSalesCash.Location = New System.Drawing.Point(21, 103)
        Me.txtSalesCash.MaxLength = 15
        Me.txtSalesCash.Name = "txtSalesCash"
        Me.txtSalesCash.Size = New System.Drawing.Size(100, 20)
        Me.txtSalesCash.TabIndex = 2
        Me.txtSalesCash.TabStop = False
        '
        'txtSalesPayout
        '
        Me.txtSalesPayout.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSalesPayout.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtSalesPayout.IsReadOnly = True
        Me.txtSalesPayout.Location = New System.Drawing.Point(21, 76)
        Me.txtSalesPayout.MaxLength = 15
        Me.txtSalesPayout.Name = "txtSalesPayout"
        Me.txtSalesPayout.Size = New System.Drawing.Size(100, 20)
        Me.txtSalesPayout.TabIndex = 1
        Me.txtSalesPayout.TabStop = False
        '
        'txtSalesGross
        '
        Me.txtSalesGross.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtSalesGross.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtSalesGross.IsReadOnly = True
        Me.txtSalesGross.Location = New System.Drawing.Point(21, 21)
        Me.txtSalesGross.MaxLength = 15
        Me.txtSalesGross.Name = "txtSalesGross"
        Me.txtSalesGross.Size = New System.Drawing.Size(100, 20)
        Me.txtSalesGross.TabIndex = 0
        Me.txtSalesGross.TabStop = False
        '
        'SalesBindingSource
        '
        Me.SalesBindingSource.DataSource = GetType(CashManagement.Sales)
        '
        'DailyReconcForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(716, 517)
        Me.Controls.Add(Me.ExcelButton)
        Me.Controls.Add(Me.Label17)
        Me.Controls.Add(Me.Label16)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label12)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.Label15)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.Cashup4Group)
        Me.Controls.Add(Me.Cashup3Group)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Cashup2Group)
        Me.Controls.Add(Me.Cashup1Group)
        Me.Controls.Add(Me.dteSelectDate)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "DailyReconcForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Reconcilliation"
        Me.GroupBox1.ResumeLayout(False)
        Me.Cashup1Group.ResumeLayout(False)
        Me.Cashup1Group.PerformLayout()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Cashup2Group.ResumeLayout(False)
        Me.Cashup2Group.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.Cashup3Group.ResumeLayout(False)
        Me.Cashup3Group.PerformLayout()
        Me.Cashup4Group.ResumeLayout(False)
        Me.Cashup4Group.PerformLayout()
        CType(Me.CashupBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.SalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtSalesCreditCard As CashManagement.NumericTextBox
    Friend WithEvents txtSalesCash As CashManagement.NumericTextBox
    Friend WithEvents txtSalesPayout As CashManagement.NumericTextBox
    Friend WithEvents txtSalesGross As CashManagement.NumericTextBox
    Friend WithEvents dteSelectDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Cashup1Group As System.Windows.Forms.GroupBox
    Friend WithEvents txtCashup1CreditCard As CashManagement.NumericTextBox
    Friend WithEvents txtCashup1Deposit As CashManagement.NumericTextBox
    Friend WithEvents txtCashup1Skims As CashManagement.NumericTextBox
    Friend WithEvents txtCashup1Payout As CashManagement.NumericTextBox
    Friend WithEvents txtCashup1Cash As CashManagement.NumericTextBox
    Friend WithEvents Cashup2Group As System.Windows.Forms.GroupBox
    Friend WithEvents txtCashup2Deposit As CashManagement.NumericTextBox
    Friend WithEvents txtCashup2Skims As CashManagement.NumericTextBox
    Friend WithEvents txtCashup2Payout As CashManagement.NumericTextBox
    Friend WithEvents txtCashup2Cash As CashManagement.NumericTextBox
    Friend WithEvents txtCashup2CreditCard As CashManagement.NumericTextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCashupDepositTotal As CashManagement.NumericTextBox
    Friend WithEvents txtCashupPayoutTotal As CashManagement.NumericTextBox
    Friend WithEvents txtCashupCashTotal As CashManagement.NumericTextBox
    Friend WithEvents txtCashupCreditCardTotal As CashManagement.NumericTextBox
    Friend WithEvents Cashup3Group As System.Windows.Forms.GroupBox
    Friend WithEvents txtCashup3Deposit As CashManagement.NumericTextBox
    Friend WithEvents txtCashup3Skims As CashManagement.NumericTextBox
    Friend WithEvents txtCashup3Payout As CashManagement.NumericTextBox
    Friend WithEvents txtCashup3Cash As CashManagement.NumericTextBox
    Friend WithEvents txtCashup3CreditCard As CashManagement.NumericTextBox
    Friend WithEvents Cashup4Group As System.Windows.Forms.GroupBox
    Friend WithEvents txtCashup4Deposit As CashManagement.NumericTextBox
    Friend WithEvents txtCashup4Skims As CashManagement.NumericTextBox
    Friend WithEvents txtCashup4Payout As CashManagement.NumericTextBox
    Friend WithEvents txtCashup4Cash As CashManagement.NumericTextBox
    Friend WithEvents txtCashup4CreditCard As CashManagement.NumericTextBox
    Friend WithEvents SalesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CashupBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents txtCashup1Employee As System.Windows.Forms.TextBox
    Friend WithEvents txtCashup2Employee As System.Windows.Forms.TextBox
    Friend WithEvents txtCashup3Employee As System.Windows.Forms.TextBox
    Friend WithEvents txtCashup4Employee As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtCashupSalesGross As CashManagement.NumericTextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents txtVarianceSalesGross As CashManagement.NumericTextBox
    Friend WithEvents txtVariancePayoutTotal As CashManagement.NumericTextBox
    Friend WithEvents txtVarianceCashTotal As CashManagement.NumericTextBox
    Friend WithEvents txtVarianceCreditCardTotal As CashManagement.NumericTextBox
    Friend WithEvents txtCashup1Adjustment As CashManagement.NumericTextBox
    Friend WithEvents txtCashup2Adjustment As CashManagement.NumericTextBox
    Friend WithEvents txtCashupAdjustmentTotal As CashManagement.NumericTextBox
    Friend WithEvents txtCashup3Adjustment As CashManagement.NumericTextBox
    Friend WithEvents txtCashup4Adjustment As CashManagement.NumericTextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCashup1Variance As CashManagement.NumericTextBox
    Friend WithEvents txtCashup2Variance As CashManagement.NumericTextBox
    Friend WithEvents txtCashup3Variance As CashManagement.NumericTextBox
    Friend WithEvents txtCashup4Variance As CashManagement.NumericTextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents txtCashupVarianceTotal As CashManagement.NumericTextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents txtCashTotalQuestion As System.Windows.Forms.Label
    Friend WithEvents txtPayoutTotalQuestion As System.Windows.Forms.Label
    Friend WithEvents txtCreditCardTotalQuestion As System.Windows.Forms.Label
    Friend WithEvents txtSalesGrossQuestion As System.Windows.Forms.Label
    Friend WithEvents ExcelButton As System.Windows.Forms.Button
End Class
