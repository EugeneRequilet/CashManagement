<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintCashupForm
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
        Me.GroupBox5 = New System.Windows.Forms.GroupBox()
        Me.Label97 = New System.Windows.Forms.Label()
        Me.txtTotalCreditCard = New CashManagement.NumericTextBox()
        Me.txtCalcDepositCashTotal = New CashManagement.NumericTextBox()
        Me.Label120 = New System.Windows.Forms.Label()
        Me.txtEmployeeName = New System.Windows.Forms.TextBox()
        Me.EmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label74 = New System.Windows.Forms.Label()
        Me.GroupBox8 = New System.Windows.Forms.GroupBox()
        Me.txtCashupGrossSales = New CashManagement.NumericTextBox()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.txtCashUpVariance = New CashManagement.NumericTextBox()
        Me.Label121 = New System.Windows.Forms.Label()
        Me.txtCalcDepRedByTotal = New CashManagement.NumericTextBox()
        Me.GroupBox7 = New System.Windows.Forms.GroupBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtPayoutTotal = New CashManagement.NumericTextBox()
        Me.txtPayoutReason6 = New System.Windows.Forms.TextBox()
        Me.txtPayoutReason5 = New System.Windows.Forms.TextBox()
        Me.txtPayoutReason4 = New System.Windows.Forms.TextBox()
        Me.txtPayoutReason3 = New System.Windows.Forms.TextBox()
        Me.txtPayoutReason2 = New System.Windows.Forms.TextBox()
        Me.txtPayoutReason1 = New System.Windows.Forms.TextBox()
        Me.txtPayout6 = New CashManagement.NumericTextBox()
        Me.txtPayout5 = New CashManagement.NumericTextBox()
        Me.txtPayout4 = New CashManagement.NumericTextBox()
        Me.txtPayout3 = New CashManagement.NumericTextBox()
        Me.txtPayout2 = New CashManagement.NumericTextBox()
        Me.txtPayout1 = New CashManagement.NumericTextBox()
        Me.GroupBox6 = New System.Windows.Forms.GroupBox()
        Me.Label124 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label123 = New System.Windows.Forms.Label()
        Me.txtDepositSkimTotal = New CashManagement.NumericTextBox()
        Me.Label122 = New System.Windows.Forms.Label()
        Me.txtDepositSkim3 = New CashManagement.NumericTextBox()
        Me.txtDepositSkim2 = New CashManagement.NumericTextBox()
        Me.txtDepositSkim1 = New CashManagement.NumericTextBox()
        Me.txtCashupDate = New System.Windows.Forms.TextBox()
        Me.txtTimeOfCashup = New System.Windows.Forms.TextBox()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.txtFloatInTill = New CashManagement.NumericTextBox()
        Me.txtCashInTill = New CashManagement.NumericTextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.txtCashAdjBy = New CashManagement.NumericTextBox()
        Me.txtCashInTillLessFloat = New CashManagement.NumericTextBox()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.ExcelButton = New System.Windows.Forms.Button()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtCalcDepIncByTotal = New CashManagement.NumericTextBox()
        Me.GroupBox5.SuspendLayout()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox5.Controls.Add(Me.Label97)
        Me.GroupBox5.Controls.Add(Me.txtTotalCreditCard)
        Me.GroupBox5.Controls.Add(Me.txtCalcDepositCashTotal)
        Me.GroupBox5.Controls.Add(Me.Label120)
        Me.GroupBox5.Location = New System.Drawing.Point(17, 233)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(271, 91)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Deposit Details"
        '
        'Label97
        '
        Me.Label97.AutoSize = True
        Me.Label97.Location = New System.Drawing.Point(16, 26)
        Me.Label97.Name = "Label97"
        Me.Label97.Size = New System.Drawing.Size(82, 13)
        Me.Label97.TabIndex = 45
        Me.Label97.Text = "Cash Deposited"
        '
        'txtTotalCreditCard
        '
        Me.txtTotalCreditCard.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtTotalCreditCard.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtTotalCreditCard.IsReadOnly = True
        Me.txtTotalCreditCard.Location = New System.Drawing.Point(158, 51)
        Me.txtTotalCreditCard.MaxLength = 15
        Me.txtTotalCreditCard.Name = "txtTotalCreditCard"
        Me.txtTotalCreditCard.Size = New System.Drawing.Size(100, 20)
        Me.txtTotalCreditCard.TabIndex = 0
        '
        'txtCalcDepositCashTotal
        '
        Me.txtCalcDepositCashTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCalcDepositCashTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCalcDepositCashTotal.IsReadOnly = True
        Me.txtCalcDepositCashTotal.Location = New System.Drawing.Point(158, 22)
        Me.txtCalcDepositCashTotal.MaxLength = 32767
        Me.txtCalcDepositCashTotal.Name = "txtCalcDepositCashTotal"
        Me.txtCalcDepositCashTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtCalcDepositCashTotal.TabIndex = 44
        Me.txtCalcDepositCashTotal.TabStop = False
        '
        'Label120
        '
        Me.Label120.AutoSize = True
        Me.Label120.Location = New System.Drawing.Point(16, 55)
        Me.Label120.Name = "Label120"
        Me.Label120.Size = New System.Drawing.Size(64, 13)
        Me.Label120.TabIndex = 0
        Me.Label120.Text = "Credit Cards"
        '
        'txtEmployeeName
        '
        Me.txtEmployeeName.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.EmployeeBindingSource, "Description", True))
        Me.txtEmployeeName.Location = New System.Drawing.Point(366, 24)
        Me.txtEmployeeName.Name = "txtEmployeeName"
        Me.txtEmployeeName.ReadOnly = True
        Me.txtEmployeeName.Size = New System.Drawing.Size(193, 20)
        Me.txtEmployeeName.TabIndex = 15
        '
        'EmployeeBindingSource
        '
        Me.EmployeeBindingSource.DataSource = GetType(CashManagement.Employee)
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(307, 28)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(53, 13)
        Me.Label3.TabIndex = 14
        Me.Label3.Text = "Employee"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(177, 28)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Time"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(27, 28)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Date"
        '
        'Label74
        '
        Me.Label74.AutoSize = True
        Me.Label74.Location = New System.Drawing.Point(16, 78)
        Me.Label74.Name = "Label74"
        Me.Label74.Size = New System.Drawing.Size(142, 13)
        Me.Label74.TabIndex = 47
        Me.Label74.Text = "Cash Removed from Deposit"
        '
        'GroupBox8
        '
        Me.GroupBox8.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox8.Controls.Add(Me.Label4)
        Me.GroupBox8.Controls.Add(Me.txtCalcDepIncByTotal)
        Me.GroupBox8.Controls.Add(Me.txtCashupGrossSales)
        Me.GroupBox8.Controls.Add(Me.Label13)
        Me.GroupBox8.Controls.Add(Me.txtCashUpVariance)
        Me.GroupBox8.Controls.Add(Me.Label121)
        Me.GroupBox8.Controls.Add(Me.Label74)
        Me.GroupBox8.Controls.Add(Me.txtCalcDepRedByTotal)
        Me.GroupBox8.Location = New System.Drawing.Point(317, 316)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(271, 138)
        Me.GroupBox8.TabIndex = 48
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Other Details"
        '
        'txtCashupGrossSales
        '
        Me.txtCashupGrossSales.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashupGrossSales.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashupGrossSales.IsReadOnly = True
        Me.txtCashupGrossSales.Location = New System.Drawing.Point(164, 19)
        Me.txtCashupGrossSales.MaxLength = 32767
        Me.txtCashupGrossSales.Name = "txtCashupGrossSales"
        Me.txtCashupGrossSales.Size = New System.Drawing.Size(92, 20)
        Me.txtCashupGrossSales.TabIndex = 49
        Me.txtCashupGrossSales.TabStop = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(16, 23)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(105, 13)
        Me.Label13.TabIndex = 48
        Me.Label13.Text = "Cash-up Gross Sales"
        '
        'txtCashUpVariance
        '
        Me.txtCashUpVariance.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashUpVariance.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashUpVariance.IsReadOnly = True
        Me.txtCashUpVariance.Location = New System.Drawing.Point(164, 102)
        Me.txtCashUpVariance.MaxLength = 15
        Me.txtCashUpVariance.Name = "txtCashUpVariance"
        Me.txtCashUpVariance.Size = New System.Drawing.Size(92, 20)
        Me.txtCashUpVariance.TabIndex = 1
        '
        'Label121
        '
        Me.Label121.AutoSize = True
        Me.Label121.Location = New System.Drawing.Point(16, 106)
        Me.Label121.Name = "Label121"
        Me.Label121.Size = New System.Drawing.Size(93, 13)
        Me.Label121.TabIndex = 1
        Me.Label121.Text = "Cash-Up Variance"
        '
        'txtCalcDepRedByTotal
        '
        Me.txtCalcDepRedByTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCalcDepRedByTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCalcDepRedByTotal.IsReadOnly = True
        Me.txtCalcDepRedByTotal.Location = New System.Drawing.Point(164, 74)
        Me.txtCalcDepRedByTotal.MaxLength = 32767
        Me.txtCalcDepRedByTotal.Name = "txtCalcDepRedByTotal"
        Me.txtCalcDepRedByTotal.Size = New System.Drawing.Size(92, 20)
        Me.txtCalcDepRedByTotal.TabIndex = 46
        Me.txtCalcDepRedByTotal.TabStop = False
        '
        'GroupBox7
        '
        Me.GroupBox7.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox7.Controls.Add(Me.Label7)
        Me.GroupBox7.Controls.Add(Me.txtPayoutTotal)
        Me.GroupBox7.Controls.Add(Me.txtPayoutReason6)
        Me.GroupBox7.Controls.Add(Me.txtPayoutReason5)
        Me.GroupBox7.Controls.Add(Me.txtPayoutReason4)
        Me.GroupBox7.Controls.Add(Me.txtPayoutReason3)
        Me.GroupBox7.Controls.Add(Me.txtPayoutReason2)
        Me.GroupBox7.Controls.Add(Me.txtPayoutReason1)
        Me.GroupBox7.Controls.Add(Me.txtPayout6)
        Me.GroupBox7.Controls.Add(Me.txtPayout5)
        Me.GroupBox7.Controls.Add(Me.txtPayout4)
        Me.GroupBox7.Controls.Add(Me.txtPayout3)
        Me.GroupBox7.Controls.Add(Me.txtPayout2)
        Me.GroupBox7.Controls.Add(Me.txtPayout1)
        Me.GroupBox7.Location = New System.Drawing.Point(317, 84)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(271, 216)
        Me.GroupBox7.TabIndex = 50
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "Payouts With Reason"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(14, 23)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Total Payouts"
        '
        'txtPayoutTotal
        '
        Me.txtPayoutTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPayoutTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPayoutTotal.IsReadOnly = True
        Me.txtPayoutTotal.Location = New System.Drawing.Point(183, 19)
        Me.txtPayoutTotal.MaxLength = 15
        Me.txtPayoutTotal.Name = "txtPayoutTotal"
        Me.txtPayoutTotal.Size = New System.Drawing.Size(73, 20)
        Me.txtPayoutTotal.TabIndex = 12
        '
        'txtPayoutReason6
        '
        Me.txtPayoutReason6.Location = New System.Drawing.Point(14, 183)
        Me.txtPayoutReason6.Name = "txtPayoutReason6"
        Me.txtPayoutReason6.ReadOnly = True
        Me.txtPayoutReason6.Size = New System.Drawing.Size(157, 20)
        Me.txtPayoutReason6.TabIndex = 11
        '
        'txtPayoutReason5
        '
        Me.txtPayoutReason5.Location = New System.Drawing.Point(14, 157)
        Me.txtPayoutReason5.Name = "txtPayoutReason5"
        Me.txtPayoutReason5.ReadOnly = True
        Me.txtPayoutReason5.Size = New System.Drawing.Size(157, 20)
        Me.txtPayoutReason5.TabIndex = 9
        '
        'txtPayoutReason4
        '
        Me.txtPayoutReason4.Location = New System.Drawing.Point(14, 131)
        Me.txtPayoutReason4.Name = "txtPayoutReason4"
        Me.txtPayoutReason4.ReadOnly = True
        Me.txtPayoutReason4.Size = New System.Drawing.Size(157, 20)
        Me.txtPayoutReason4.TabIndex = 7
        '
        'txtPayoutReason3
        '
        Me.txtPayoutReason3.Location = New System.Drawing.Point(14, 105)
        Me.txtPayoutReason3.Name = "txtPayoutReason3"
        Me.txtPayoutReason3.ReadOnly = True
        Me.txtPayoutReason3.Size = New System.Drawing.Size(157, 20)
        Me.txtPayoutReason3.TabIndex = 5
        '
        'txtPayoutReason2
        '
        Me.txtPayoutReason2.Location = New System.Drawing.Point(14, 79)
        Me.txtPayoutReason2.Name = "txtPayoutReason2"
        Me.txtPayoutReason2.ReadOnly = True
        Me.txtPayoutReason2.Size = New System.Drawing.Size(157, 20)
        Me.txtPayoutReason2.TabIndex = 3
        '
        'txtPayoutReason1
        '
        Me.txtPayoutReason1.Location = New System.Drawing.Point(14, 53)
        Me.txtPayoutReason1.Name = "txtPayoutReason1"
        Me.txtPayoutReason1.ReadOnly = True
        Me.txtPayoutReason1.Size = New System.Drawing.Size(157, 20)
        Me.txtPayoutReason1.TabIndex = 1
        '
        'txtPayout6
        '
        Me.txtPayout6.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPayout6.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPayout6.IsReadOnly = True
        Me.txtPayout6.Location = New System.Drawing.Point(183, 183)
        Me.txtPayout6.MaxLength = 15
        Me.txtPayout6.Name = "txtPayout6"
        Me.txtPayout6.Size = New System.Drawing.Size(73, 20)
        Me.txtPayout6.TabIndex = 10
        '
        'txtPayout5
        '
        Me.txtPayout5.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPayout5.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPayout5.IsReadOnly = True
        Me.txtPayout5.Location = New System.Drawing.Point(183, 157)
        Me.txtPayout5.MaxLength = 15
        Me.txtPayout5.Name = "txtPayout5"
        Me.txtPayout5.Size = New System.Drawing.Size(73, 20)
        Me.txtPayout5.TabIndex = 8
        '
        'txtPayout4
        '
        Me.txtPayout4.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPayout4.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPayout4.IsReadOnly = True
        Me.txtPayout4.Location = New System.Drawing.Point(183, 131)
        Me.txtPayout4.MaxLength = 15
        Me.txtPayout4.Name = "txtPayout4"
        Me.txtPayout4.Size = New System.Drawing.Size(73, 20)
        Me.txtPayout4.TabIndex = 6
        '
        'txtPayout3
        '
        Me.txtPayout3.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPayout3.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPayout3.IsReadOnly = True
        Me.txtPayout3.Location = New System.Drawing.Point(183, 105)
        Me.txtPayout3.MaxLength = 15
        Me.txtPayout3.Name = "txtPayout3"
        Me.txtPayout3.Size = New System.Drawing.Size(73, 20)
        Me.txtPayout3.TabIndex = 4
        '
        'txtPayout2
        '
        Me.txtPayout2.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPayout2.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPayout2.IsReadOnly = True
        Me.txtPayout2.Location = New System.Drawing.Point(183, 79)
        Me.txtPayout2.MaxLength = 15
        Me.txtPayout2.Name = "txtPayout2"
        Me.txtPayout2.Size = New System.Drawing.Size(73, 20)
        Me.txtPayout2.TabIndex = 2
        '
        'txtPayout1
        '
        Me.txtPayout1.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtPayout1.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtPayout1.IsReadOnly = True
        Me.txtPayout1.Location = New System.Drawing.Point(183, 53)
        Me.txtPayout1.MaxLength = 15
        Me.txtPayout1.Name = "txtPayout1"
        Me.txtPayout1.Size = New System.Drawing.Size(73, 20)
        Me.txtPayout1.TabIndex = 0
        '
        'GroupBox6
        '
        Me.GroupBox6.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox6.Controls.Add(Me.Label124)
        Me.GroupBox6.Controls.Add(Me.Label6)
        Me.GroupBox6.Controls.Add(Me.Label123)
        Me.GroupBox6.Controls.Add(Me.txtDepositSkimTotal)
        Me.GroupBox6.Controls.Add(Me.Label122)
        Me.GroupBox6.Controls.Add(Me.txtDepositSkim3)
        Me.GroupBox6.Controls.Add(Me.txtDepositSkim2)
        Me.GroupBox6.Controls.Add(Me.txtDepositSkim1)
        Me.GroupBox6.Location = New System.Drawing.Point(17, 339)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(271, 139)
        Me.GroupBox6.TabIndex = 49
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "Skims"
        '
        'Label124
        '
        Me.Label124.AutoSize = True
        Me.Label124.Location = New System.Drawing.Point(16, 108)
        Me.Label124.Name = "Label124"
        Me.Label124.Size = New System.Drawing.Size(78, 13)
        Me.Label124.TabIndex = 5
        Me.Label124.Text = "Deposit Skim 3"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(16, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(101, 13)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Total Deposit Skims"
        '
        'Label123
        '
        Me.Label123.AutoSize = True
        Me.Label123.Location = New System.Drawing.Point(16, 83)
        Me.Label123.Name = "Label123"
        Me.Label123.Size = New System.Drawing.Size(78, 13)
        Me.Label123.TabIndex = 4
        Me.Label123.Text = "Deposit Skim 2"
        '
        'txtDepositSkimTotal
        '
        Me.txtDepositSkimTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDepositSkimTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDepositSkimTotal.IsReadOnly = True
        Me.txtDepositSkimTotal.Location = New System.Drawing.Point(156, 22)
        Me.txtDepositSkimTotal.MaxLength = 15
        Me.txtDepositSkimTotal.Name = "txtDepositSkimTotal"
        Me.txtDepositSkimTotal.Size = New System.Drawing.Size(100, 20)
        Me.txtDepositSkimTotal.TabIndex = 6
        '
        'Label122
        '
        Me.Label122.AutoSize = True
        Me.Label122.Location = New System.Drawing.Point(16, 58)
        Me.Label122.Name = "Label122"
        Me.Label122.Size = New System.Drawing.Size(78, 13)
        Me.Label122.TabIndex = 3
        Me.Label122.Text = "Deposit Skim 1"
        '
        'txtDepositSkim3
        '
        Me.txtDepositSkim3.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDepositSkim3.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDepositSkim3.IsReadOnly = True
        Me.txtDepositSkim3.Location = New System.Drawing.Point(156, 104)
        Me.txtDepositSkim3.MaxLength = 15
        Me.txtDepositSkim3.Name = "txtDepositSkim3"
        Me.txtDepositSkim3.Size = New System.Drawing.Size(100, 20)
        Me.txtDepositSkim3.TabIndex = 2
        '
        'txtDepositSkim2
        '
        Me.txtDepositSkim2.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDepositSkim2.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDepositSkim2.IsReadOnly = True
        Me.txtDepositSkim2.Location = New System.Drawing.Point(156, 79)
        Me.txtDepositSkim2.MaxLength = 15
        Me.txtDepositSkim2.Name = "txtDepositSkim2"
        Me.txtDepositSkim2.Size = New System.Drawing.Size(100, 20)
        Me.txtDepositSkim2.TabIndex = 1
        '
        'txtDepositSkim1
        '
        Me.txtDepositSkim1.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtDepositSkim1.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtDepositSkim1.IsReadOnly = True
        Me.txtDepositSkim1.Location = New System.Drawing.Point(156, 54)
        Me.txtDepositSkim1.MaxLength = 15
        Me.txtDepositSkim1.Name = "txtDepositSkim1"
        Me.txtDepositSkim1.Size = New System.Drawing.Size(100, 20)
        Me.txtDepositSkim1.TabIndex = 0
        '
        'txtCashupDate
        '
        Me.txtCashupDate.Location = New System.Drawing.Point(74, 24)
        Me.txtCashupDate.Name = "txtCashupDate"
        Me.txtCashupDate.ReadOnly = True
        Me.txtCashupDate.Size = New System.Drawing.Size(80, 20)
        Me.txtCashupDate.TabIndex = 51
        '
        'txtTimeOfCashup
        '
        Me.txtTimeOfCashup.Location = New System.Drawing.Point(218, 24)
        Me.txtTimeOfCashup.Name = "txtTimeOfCashup"
        Me.txtTimeOfCashup.ReadOnly = True
        Me.txtTimeOfCashup.Size = New System.Drawing.Size(68, 20)
        Me.txtTimeOfCashup.TabIndex = 52
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.CashUp)
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.txtTimeOfCashup)
        Me.GroupBox1.Controls.Add(Me.txtCashupDate)
        Me.GroupBox1.Controls.Add(Me.txtEmployeeName)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(11, 9)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(576, 60)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Cash-up"
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Location = New System.Drawing.Point(512, 460)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 59
        Me.CloseButton.Text = "&Close"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Transparent
        Me.GroupBox2.Controls.Add(Me.txtFloatInTill)
        Me.GroupBox2.Controls.Add(Me.txtCashInTill)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txtCashAdjBy)
        Me.GroupBox2.Controls.Add(Me.txtCashInTillLessFloat)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Location = New System.Drawing.Point(17, 84)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(271, 134)
        Me.GroupBox2.TabIndex = 46
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Cash Details"
        '
        'txtFloatInTill
        '
        Me.txtFloatInTill.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtFloatInTill.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtFloatInTill.IsReadOnly = True
        Me.txtFloatInTill.Location = New System.Drawing.Point(158, 46)
        Me.txtFloatInTill.MaxLength = 32767
        Me.txtFloatInTill.Name = "txtFloatInTill"
        Me.txtFloatInTill.Size = New System.Drawing.Size(100, 20)
        Me.txtFloatInTill.TabIndex = 49
        Me.txtFloatInTill.TabStop = False
        '
        'txtCashInTill
        '
        Me.txtCashInTill.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashInTill.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashInTill.IsReadOnly = True
        Me.txtCashInTill.Location = New System.Drawing.Point(158, 19)
        Me.txtCashInTill.MaxLength = 32767
        Me.txtCashInTill.Name = "txtCashInTill"
        Me.txtCashInTill.Size = New System.Drawing.Size(100, 20)
        Me.txtCashInTill.TabIndex = 48
        Me.txtCashInTill.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(16, 50)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(57, 13)
        Me.Label12.TabIndex = 47
        Me.Label12.Text = "Float in Till"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(16, 23)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(58, 13)
        Me.Label11.TabIndex = 46
        Me.Label11.Text = "Cash in Till"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(16, 79)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(105, 13)
        Me.Label9.TabIndex = 45
        Me.Label9.Text = "Cash in Till less Float"
        '
        'txtCashAdjBy
        '
        Me.txtCashAdjBy.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashAdjBy.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashAdjBy.IsReadOnly = True
        Me.txtCashAdjBy.Location = New System.Drawing.Point(158, 104)
        Me.txtCashAdjBy.MaxLength = 15
        Me.txtCashAdjBy.Name = "txtCashAdjBy"
        Me.txtCashAdjBy.Size = New System.Drawing.Size(100, 20)
        Me.txtCashAdjBy.TabIndex = 0
        '
        'txtCashInTillLessFloat
        '
        Me.txtCashInTillLessFloat.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCashInTillLessFloat.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCashInTillLessFloat.IsReadOnly = True
        Me.txtCashInTillLessFloat.Location = New System.Drawing.Point(158, 75)
        Me.txtCashInTillLessFloat.MaxLength = 32767
        Me.txtCashInTillLessFloat.Name = "txtCashInTillLessFloat"
        Me.txtCashInTillLessFloat.Size = New System.Drawing.Size(100, 20)
        Me.txtCashInTillLessFloat.TabIndex = 44
        Me.txtCashInTillLessFloat.TabStop = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(16, 108)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(128, 13)
        Me.Label10.TabIndex = 0
        Me.Label10.Text = "Cash Deposit Adjusted by"
        '
        'ExcelButton
        '
        Me.ExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ExcelButton.Location = New System.Drawing.Point(424, 460)
        Me.ExcelButton.Name = "ExcelButton"
        Me.ExcelButton.Size = New System.Drawing.Size(75, 23)
        Me.ExcelButton.TabIndex = 61
        Me.ExcelButton.Text = "&Excel Export"
        Me.ExcelButton.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 49)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(116, 13)
        Me.Label4.TabIndex = 51
        Me.Label4.Text = "Cash Added to Deposit"
        '
        'txtCalcDepIncByTotal
        '
        Me.txtCalcDepIncByTotal.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtCalcDepIncByTotal.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtCalcDepIncByTotal.IsReadOnly = True
        Me.txtCalcDepIncByTotal.Location = New System.Drawing.Point(164, 45)
        Me.txtCalcDepIncByTotal.MaxLength = 32767
        Me.txtCalcDepIncByTotal.Name = "txtCalcDepIncByTotal"
        Me.txtCalcDepIncByTotal.Size = New System.Drawing.Size(92, 20)
        Me.txtCalcDepIncByTotal.TabIndex = 50
        Me.txtCalcDepIncByTotal.TabStop = False
        '
        'PrintCashupForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(604, 493)
        Me.Controls.Add(Me.ExcelButton)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox8)
        Me.Controls.Add(Me.GroupBox7)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox5)
        Me.Name = "PrintCashupForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Cash-up Print Form"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        Me.GroupBox8.PerformLayout()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label97 As System.Windows.Forms.Label
    Friend WithEvents txtCalcDepositCashTotal As CashManagement.NumericTextBox
    Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label74 As System.Windows.Forms.Label
    Friend WithEvents txtCalcDepRedByTotal As CashManagement.NumericTextBox
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCashUpVariance As CashManagement.NumericTextBox
    Friend WithEvents txtTotalCreditCard As CashManagement.NumericTextBox
    Friend WithEvents Label121 As System.Windows.Forms.Label
    Friend WithEvents Label120 As System.Windows.Forms.Label
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtPayoutTotal As CashManagement.NumericTextBox
    Friend WithEvents txtPayoutReason6 As System.Windows.Forms.TextBox
    Friend WithEvents txtPayoutReason5 As System.Windows.Forms.TextBox
    Friend WithEvents txtPayoutReason4 As System.Windows.Forms.TextBox
    Friend WithEvents txtPayoutReason3 As System.Windows.Forms.TextBox
    Friend WithEvents txtPayoutReason2 As System.Windows.Forms.TextBox
    Friend WithEvents txtPayoutReason1 As System.Windows.Forms.TextBox
    Friend WithEvents txtPayout6 As CashManagement.NumericTextBox
    Friend WithEvents txtPayout5 As CashManagement.NumericTextBox
    Friend WithEvents txtPayout4 As CashManagement.NumericTextBox
    Friend WithEvents txtPayout3 As CashManagement.NumericTextBox
    Friend WithEvents txtPayout2 As CashManagement.NumericTextBox
    Friend WithEvents txtPayout1 As CashManagement.NumericTextBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtDepositSkimTotal As CashManagement.NumericTextBox
    Friend WithEvents Label124 As System.Windows.Forms.Label
    Friend WithEvents Label123 As System.Windows.Forms.Label
    Friend WithEvents Label122 As System.Windows.Forms.Label
    Friend WithEvents txtDepositSkim3 As CashManagement.NumericTextBox
    Friend WithEvents txtDepositSkim2 As CashManagement.NumericTextBox
    Friend WithEvents txtDepositSkim1 As CashManagement.NumericTextBox
    Friend WithEvents txtCashupDate As System.Windows.Forms.TextBox
    Friend WithEvents txtTimeOfCashup As System.Windows.Forms.TextBox
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtCashAdjBy As CashManagement.NumericTextBox
    Friend WithEvents txtCashInTillLessFloat As CashManagement.NumericTextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents ExcelButton As System.Windows.Forms.Button
    Friend WithEvents txtFloatInTill As CashManagement.NumericTextBox
    Friend WithEvents txtCashInTill As CashManagement.NumericTextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtCashupGrossSales As CashManagement.NumericTextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtCalcDepIncByTotal As CashManagement.NumericTextBox
End Class
