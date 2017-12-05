Public Class UpdateCashUpForm

    Public RecordId As Integer

    Dim DC As CashUpDataContext
    Dim CashUpRow As CashUp
    Dim InsertMode As Boolean = False

    ' Float Calculation Variables Start

    Dim ReducingFloat As Decimal = 0.0
    Dim C10 As Integer = 0
    Dim C20 As Integer = 0
    Dim C50 As Integer = 0
    Dim R1 As Integer = 0
    Dim R2 As Integer = 0
    Dim R5 As Integer = 0
    Dim R10 As Integer = 0
    Dim R20 As Integer = 0
    Dim R50 As Integer = 0
    Dim R100 As Integer = 0
    Dim R200 As Integer = 0

    Dim FloatC10 As Integer = 0
    Dim FloatC20 As Integer = 0
    Dim FloatC50 As Integer = 0
    Dim FloatR1 As Integer = 0
    Dim FloatR2 As Integer = 0
    Dim FloatR5 As Integer = 0
    Dim FloatR10 As Integer = 0
    Dim FloatR20 As Integer = 0
    Dim FloatR50 As Integer = 0
    Dim FloatR100 As Integer = 0
    Dim FloatR200 As Integer = 0

    ' Dim Number As Integer = 0
    Dim Amount As Decimal = 0

    ' Float Calculation Variables End

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New CashUpDataContext
        BindingSource1.DataSource = From CashUp In DC.CashUps Where CashUp.RecordId = RecordId
        CashUpRow = BindingSource1.Current
        If CashUpRow Is Nothing Then
            CashUpRow = New CashUp
            BindingSource1.AddNew()
            CashUpRow = BindingSource1.Current
            setDefaults()
            Me.dteDate.Select()
            InsertMode = True
        End If
        ReadEmployee()
        setDropdowns()
        setNumericsOnScreens()
        FormatText()
    End Sub

    Private Sub setDefaults()
        If CashUpRow.Date = Nothing OrElse CashUpRow.Date = Date.MinValue Then CashUpRow.Date = Today
        If CashUpRow.Time = Nothing Then CashUpRow.Time = 0

        If CashUpRow.R200 = Nothing Then CashUpRow.R200 = 0
        If CashUpRow.R100 = Nothing Then CashUpRow.R100 = 0
        If CashUpRow.R50 = Nothing Then CashUpRow.R50 = 0
        If CashUpRow.R20 = Nothing Then CashUpRow.R20 = 0
        If CashUpRow.R10 = Nothing Then CashUpRow.R10 = 0
        If CashUpRow.R5 = Nothing Then CashUpRow.R5 = 0
        If CashUpRow.R1 = Nothing Then CashUpRow.R1 = 0
        If CashUpRow.C50 = Nothing Then CashUpRow.C50 = 0
        If CashUpRow.C20 = Nothing Then CashUpRow.C20 = 0
        If CashUpRow.C10 = Nothing Then CashUpRow.C10 = 0

        If CashUpRow.FloatR200 = Nothing Then CashUpRow.FloatR200 = 0
        If CashUpRow.FloatR100 = Nothing Then CashUpRow.FloatR100 = 0
        If CashUpRow.FloatR50 = Nothing Then CashUpRow.FloatR50 = 0
        If CashUpRow.FloatR20 = Nothing Then CashUpRow.FloatR20 = 0
        If CashUpRow.FloatR10 = Nothing Then CashUpRow.FloatR10 = 0
        If CashUpRow.FloatR5 = Nothing Then CashUpRow.FloatR5 = 0
        If CashUpRow.FloatR1 = Nothing Then CashUpRow.FloatR1 = 0
        If CashUpRow.FloatC50 = Nothing Then CashUpRow.FloatC50 = 0
        If CashUpRow.FloatC20 = Nothing Then CashUpRow.FloatC20 = 0
        If CashUpRow.FloatC10 = Nothing Then CashUpRow.FloatC10 = 0

        If CashUpRow.DepositedSkim1 = Nothing Then CashUpRow.DepositedSkim1 = 0.0
        If CashUpRow.DepositedSkim2 = Nothing Then CashUpRow.DepositedSkim2 = 0.0
        If CashUpRow.DepositedSkim3 = Nothing Then CashUpRow.DepositedSkim3 = 0.0

        If CashUpRow.Payout1 = Nothing Then CashUpRow.Payout1 = 0.0
        If CashUpRow.Payout2 = Nothing Then CashUpRow.Payout2 = 0.0
        If CashUpRow.Payout3 = Nothing Then CashUpRow.Payout3 = 0.0
        If CashUpRow.Payout4 = Nothing Then CashUpRow.Payout4 = 0.0
        If CashUpRow.Payout5 = Nothing Then CashUpRow.Payout5 = 0.0
        If CashUpRow.Payout6 = Nothing Then CashUpRow.Payout6 = 0.0

        If CashUpRow.TotalCreditCard = Nothing Then CashUpRow.TotalCreditCard = 0.0
        If CashUpRow.CashupVariance = Nothing Then CashUpRow.CashupVariance = 0.0

        If CashUpRow.DepRedByR200 = Nothing Then CashUpRow.DepRedByR200 = 0
        If CashUpRow.DepRedByR100 = Nothing Then CashUpRow.DepRedByR100 = 0
        If CashUpRow.DepRedByR50 = Nothing Then CashUpRow.DepRedByR50 = 0
        If CashUpRow.DepRedByR20 = Nothing Then CashUpRow.DepRedByR20 = 0
        If CashUpRow.DepRedByR10 = Nothing Then CashUpRow.DepRedByR10 = 0
        If CashUpRow.DepRedByR5 = Nothing Then CashUpRow.DepRedByR5 = 0
        If CashUpRow.DepRedByR1 = Nothing Then CashUpRow.DepRedByR1 = 0
        If CashUpRow.DepRedByC50 = Nothing Then CashUpRow.DepRedByC50 = 0
        If CashUpRow.DepRedByC20 = Nothing Then CashUpRow.DepRedByC20 = 0
        If CashUpRow.DepRedByC10 = Nothing Then CashUpRow.DepRedByC10 = 0

        If CashUpRow.DepIncByR200 = Nothing Then CashUpRow.DepIncByR200 = 0
        If CashUpRow.DepIncByR100 = Nothing Then CashUpRow.DepIncByR100 = 0
        If CashUpRow.DepIncByR50 = Nothing Then CashUpRow.DepIncByR50 = 0
        If CashUpRow.DepIncByR20 = Nothing Then CashUpRow.DepIncByR20 = 0
        If CashUpRow.DepIncByR10 = Nothing Then CashUpRow.DepIncByR10 = 0
        If CashUpRow.DepIncByR5 = Nothing Then CashUpRow.DepIncByR5 = 0
        If CashUpRow.DepIncByR1 = Nothing Then CashUpRow.DepIncByR1 = 0
        If CashUpRow.DepIncByC50 = Nothing Then CashUpRow.DepIncByC50 = 0
        If CashUpRow.DepIncByC20 = Nothing Then CashUpRow.DepIncByC20 = 0
        If CashUpRow.DepIncByC10 = Nothing Then CashUpRow.DepIncByC10 = 0

        If CashUpRow.TotalCreditCard = Nothing Then CashUpRow.TotalCreditCard = 0.0
        If CashUpRow.DepositedSkim1 = Nothing Then CashUpRow.DepositedSkim1 = 0.0
        If CashUpRow.DepositedSkim2 = Nothing Then CashUpRow.DepositedSkim2 = 0.0
        If CashUpRow.DepositedSkim3 = Nothing Then CashUpRow.DepositedSkim3 = 0.0
        If CashUpRow.Payout1 = Nothing Then CashUpRow.Payout1 = 0.0
        If CashUpRow.Payout2 = Nothing Then CashUpRow.Payout2 = 0.0
        If CashUpRow.Payout3 = Nothing Then CashUpRow.Payout3 = 0.0
        If CashUpRow.Payout4 = Nothing Then CashUpRow.Payout4 = 0.0
        If CashUpRow.Payout5 = Nothing Then CashUpRow.Payout5 = 0.0
        If CashUpRow.Payout6 = Nothing Then CashUpRow.Payout6 = 0.0

        If CashUpRow.SalesType = Nothing Then CashUpRow.SalesType = 0
        If CashUpRow.PaymentType = Nothing Then CashUpRow.PaymentType = 0

        If CashUpRow.EmployeeRecordId = Nothing OrElse CashUpRow.EmployeeRecordId = 0 Then CashUpRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        'Dim Message = String.Format("setDefaults.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, CashUpRow.Gender, CashUpRow.MaritalStatus, CashUpRow.DateStarted, CashUpRow.NoOfDependants, CashUpRow.Rate)
        'MsgBox(Message)

    End Sub

    Private Sub setDropdowns()
        cboShift.Items.Clear()
        For i = 1 To 10
            If GlobalFirmDetailRow.FirmName.ToUpper.Contains("BREAD AHEAD") And i > 2 Then Exit For
            cboShift.Items.Add("Shift " & i)
        Next
        cboShift.SelectedIndex = 0
        cboShift.SelectedIndex = CashUpRow.Time

        cboPaymentType.Items.Clear()
        cboPaymentType.Items.Add("Banked")
        cboPaymentType.Items.Add("Held as Cash")
        cboPaymentType.SelectedIndex = CashUpRow.PaymentType
        If cboPaymentType.SelectedIndex > 1 Then
            cboPaymentType.SelectedIndex = 0
            CashUpRow.PaymentType = 0
        End If
    End Sub

    Private Sub ReadEmployee()
        Try
            EmployeeBindingSource.DataSource = From Employee In (New EmployeeDataContext).Employees Where Employee.RecordId = CashUpRow.EmployeeRecordId
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        '        Dim EmployeeRow As Employee = If(EmployeeBindingSource.Current, New Employee)
    End Sub

    Private Sub setNumericsOnScreens()
        If InsertMode = False And GlobalEmployeeIsType < GlobalAdministrator Then
            dteDate.Enabled = False
            cboShift.Enabled = False
            With CashUpRow
                If .CashDepReconciled = True Or .CreditCardReconciled = True Or .Skims1Reconciled = True Or .Skims2Reconciled = True Or .Skims3Reconciled = True Then
                    OkButton.Enabled = False
                End If
            End With
        End If

        If GlobalEmployeeIsType > GlobalCashier Then
            chbCashDeposited.Visible = True
            chbCreditCardDeposited.Visible = True
            chbDepositSkim1.Visible = True
            chbDepositSkim2.Visible = True
            chbDepositSkim3.Visible = True
        End If

        ' Cash-Up Tab - Cash In Till Group

        txtR200.EditValue = CashUpRow.R200
        txtR200.EditValue = CashUpRow.R200
        txtR100.EditValue = CashUpRow.R100
        txtR50.EditValue = CashUpRow.R50
        txtR20.EditValue = CashUpRow.R20
        txtR10.EditValue = CashUpRow.R10
        txtR5.EditValue = CashUpRow.R5
        txtR2.EditValue = CashUpRow.R2
        txtR1.EditValue = CashUpRow.R1
        txtC50.EditValue = CashUpRow.C50
        txtC20.EditValue = CashUpRow.C20
        txtC10.EditValue = CashUpRow.C10

        ' Cash-Up Tab - Float In Till Group

        txtFloatR200.EditValue = CashUpRow.FloatR200
        txtFloatR200.EditValue = CashUpRow.FloatR200
        txtFloatR100.EditValue = CashUpRow.FloatR100
        txtFloatR50.EditValue = CashUpRow.FloatR50
        txtFloatR20.EditValue = CashUpRow.FloatR20
        txtFloatR10.EditValue = CashUpRow.FloatR10
        txtFloatR5.EditValue = CashUpRow.FloatR5
        txtFloatR2.EditValue = CashUpRow.FloatR2
        txtFloatR1.EditValue = CashUpRow.FloatR1
        txtFloatC50.EditValue = CashUpRow.FloatC50
        txtFloatC20.EditValue = CashUpRow.FloatC20
        txtFloatC10.EditValue = CashUpRow.FloatC10

        ' Cash-Up Tab - Deposit C/Card and Variance By - Group

        txtTotalCreditCard.EditValue = CashUpRow.TotalCreditCard

        ' Cash-Up Tab - Deposit Skims By - Group

        txtDepositSkim1.EditValue = CashUpRow.DepositedSkim1
        txtDepositSkim2.EditValue = CashUpRow.DepositedSkim2
        txtDepositSkim3.EditValue = CashUpRow.DepositedSkim3

        ' Cash-Up Tab - Deposit Payouts By - Group

        txtPayout1.EditValue = CashUpRow.Payout1
        txtPayout2.EditValue = CashUpRow.Payout2
        txtPayout3.EditValue = CashUpRow.Payout3
        txtPayout4.EditValue = CashUpRow.Payout4
        txtPayout5.EditValue = CashUpRow.Payout5
        txtPayout6.EditValue = CashUpRow.Payout6

        ' Micros Cash-up Tab

        txtCashUpVariance.EditValue = CashUpRow.CashupVariance

        ' Deposit Tab - Deposit Increased By - Group

        txtDepIncByR200.EditValue = CashUpRow.DepIncByR200
        txtDepIncByR100.EditValue = CashUpRow.DepIncByR100
        txtDepIncByR50.EditValue = CashUpRow.DepIncByR50
        txtDepIncByR20.EditValue = CashUpRow.DepIncByR20
        txtDepIncByR10.EditValue = CashUpRow.DepIncByR10
        txtDepIncByR5.EditValue = CashUpRow.DepIncByR5
        txtDepIncByR2.EditValue = CashUpRow.DepIncByR2
        txtDepIncByR1.EditValue = CashUpRow.DepIncByR1
        txtDepIncByC50.EditValue = CashUpRow.DepIncByC50
        txtDepIncByC20.EditValue = CashUpRow.DepIncByC20
        txtDepIncByC10.EditValue = CashUpRow.DepIncByC10

        ' Deposit Tab - Deposit Reduced By - Group

        txtDepRedByR200.EditValue = CashUpRow.DepRedByR200
        txtDepRedByR100.EditValue = CashUpRow.DepRedByR100
        txtDepRedByR50.EditValue = CashUpRow.DepRedByR50
        txtDepRedByR20.EditValue = CashUpRow.DepRedByR20
        txtDepRedByR10.EditValue = CashUpRow.DepRedByR10
        txtDepRedByR5.EditValue = CashUpRow.DepRedByR5
        txtDepRedByR2.EditValue = CashUpRow.DepRedByR2
        txtDepRedByR1.EditValue = CashUpRow.DepRedByR1
        txtDepRedByC50.EditValue = CashUpRow.DepRedByC50
        txtDepRedByC20.EditValue = CashUpRow.DepRedByC20
        txtDepRedByC10.EditValue = CashUpRow.DepRedByC10

        ' Set up Recon Variables because they are not on the first TAB

        If CashUpRow.CashDepReconciled Then chbCashDeposited.CheckState = 1
        If CashUpRow.CreditCardReconciled Then chbCreditCardDeposited.CheckState = 1
        If CashUpRow.Skims1Reconciled Then chbDepositSkim1.CheckState = 1
        If CashUpRow.Skims2Reconciled Then chbDepositSkim2.CheckState = 1
        If CashUpRow.Skims3Reconciled Then chbDepositSkim3.CheckState = 1

    End Sub

    Private Sub FormatText()
        'BindingSource1.ResetBindings(True)

        If chbCashDeposited.CheckState = 1 Then
            txtR200.IsReadOnly = True
            txtR100.IsReadOnly = True
            txtR50.IsReadOnly = True
            txtR20.IsReadOnly = True
            txtR10.IsReadOnly = True
            txtR5.IsReadOnly = True
            txtR2.IsReadOnly = True
            txtR1.IsReadOnly = True
            txtC50.IsReadOnly = True
            txtC20.IsReadOnly = True
            txtC10.IsReadOnly = True

            txtFloatR200.IsReadOnly = True
            txtFloatR200.IsReadOnly = True
            txtFloatR100.IsReadOnly = True
            txtFloatR50.IsReadOnly = True
            txtFloatR20.IsReadOnly = True
            txtFloatR10.IsReadOnly = True
            txtFloatR5.IsReadOnly = True
            txtFloatR2.IsReadOnly = True
            txtFloatR1.IsReadOnly = True
            txtFloatC50.IsReadOnly = True
            txtFloatC20.IsReadOnly = True
            txtFloatC10.IsReadOnly = True

            txtDepIncByR200.IsReadOnly = True
            txtDepIncByR100.IsReadOnly = True
            txtDepIncByR50.IsReadOnly = True
            txtDepIncByR20.IsReadOnly = True
            txtDepIncByR10.IsReadOnly = True
            txtDepIncByR5.IsReadOnly = True
            txtDepIncByR2.IsReadOnly = True
            txtDepIncByR1.IsReadOnly = True
            txtDepIncByC50.IsReadOnly = True
            txtDepIncByC20.IsReadOnly = True
            txtDepIncByC10.IsReadOnly = True

            txtDepRedByR200.IsReadOnly = True
            txtDepRedByR100.IsReadOnly = True
            txtDepRedByR50.IsReadOnly = True
            txtDepRedByR20.IsReadOnly = True
            txtDepRedByR10.IsReadOnly = True
            txtDepRedByR5.IsReadOnly = True
            txtDepRedByR2.IsReadOnly = True
            txtDepRedByR1.IsReadOnly = True
            txtDepRedByC50.IsReadOnly = True
            txtDepRedByC20.IsReadOnly = True
            txtDepRedByC10.IsReadOnly = True
        Else
            txtR200.IsReadOnly = False
            txtR100.IsReadOnly = False
            txtR50.IsReadOnly = False
            txtR20.IsReadOnly = False
            txtR10.IsReadOnly = False
            txtR5.IsReadOnly = False
            txtR2.IsReadOnly = False
            txtR1.IsReadOnly = False
            txtC50.IsReadOnly = False
            txtC20.IsReadOnly = False
            txtC10.IsReadOnly = False

            txtFloatR200.IsReadOnly = False
            txtFloatR200.IsReadOnly = False
            txtFloatR100.IsReadOnly = False
            txtFloatR50.IsReadOnly = False
            txtFloatR20.IsReadOnly = False
            txtFloatR10.IsReadOnly = False
            txtFloatR5.IsReadOnly = False
            txtFloatR2.IsReadOnly = False
            txtFloatR1.IsReadOnly = False
            txtFloatC50.IsReadOnly = False
            txtFloatC20.IsReadOnly = False
            txtFloatC10.IsReadOnly = False

            txtDepIncByR200.IsReadOnly = False
            txtDepIncByR100.IsReadOnly = False
            txtDepIncByR50.IsReadOnly = False
            txtDepIncByR20.IsReadOnly = False
            txtDepIncByR10.IsReadOnly = False
            txtDepIncByR5.IsReadOnly = False
            txtDepIncByR2.IsReadOnly = False
            txtDepIncByR1.IsReadOnly = False
            txtDepIncByC50.IsReadOnly = False
            txtDepIncByC20.IsReadOnly = False
            txtDepIncByC10.IsReadOnly = False

            txtDepRedByR200.IsReadOnly = False
            txtDepRedByR100.IsReadOnly = False
            txtDepRedByR50.IsReadOnly = False
            txtDepRedByR20.IsReadOnly = False
            txtDepRedByR10.IsReadOnly = False
            txtDepRedByR5.IsReadOnly = False
            txtDepRedByR2.IsReadOnly = False
            txtDepRedByR1.IsReadOnly = False
            txtDepRedByC50.IsReadOnly = False
            txtDepRedByC20.IsReadOnly = False
            txtDepRedByC10.IsReadOnly = False
        End If

        If chbCreditCardDeposited.CheckState = 1 Then
            txtTotalCreditCard.IsReadOnly = True
        Else
            txtTotalCreditCard.IsReadOnly = False
        End If
        If chbDepositSkim1.CheckState = 1 Then
            txtDepositSkim1.IsReadOnly = True
        Else
            txtDepositSkim1.IsReadOnly = False
        End If
        If chbDepositSkim2.CheckState = 1 Then
            txtDepositSkim2.IsReadOnly = True
        Else
            txtDepositSkim2.IsReadOnly = False
        End If
        If chbDepositSkim3.CheckState = 1 Then
            txtDepositSkim3.IsReadOnly = True
        Else
            txtDepositSkim3.IsReadOnly = False
        End If

        Dim R200 As Integer
        Dim R100 As Integer
        Dim R50 As Integer
        Dim R20 As Integer
        Dim R10 As Integer
        Dim R5 As Integer
        Dim R2 As Integer
        Dim R1 As Integer
        Dim C50 As Integer
        Dim C20 As Integer
        Dim C10 As Integer
        Dim SumTotal As Decimal

        ' Cash-Up Tab - Cash In Till Group

        txtCalcR200.EditValue = CashUpRow.R200 * 200
        txtCalcR100.EditValue = CashUpRow.R100 * 100
        txtCalcR50.EditValue = CashUpRow.R50 * 50
        txtCalcR20.EditValue = CashUpRow.R20 * 20
        txtCalcR10.EditValue = CashUpRow.R10 * 10
        txtCalcR5.EditValue = CashUpRow.R5 * 5
        txtCalcR2.EditValue = CashUpRow.R2 * 2
        txtCalcR1.EditValue = CashUpRow.R1 * 1
        txtCalcC50.EditValue = CashUpRow.C50 * 0.5
        txtCalcC20.EditValue = CashUpRow.C20 * 0.2
        txtCalcC10.EditValue = CashUpRow.C10 * 0.1
        SumTotal = CDec(txtCalcR200.EditValue) + CDec(txtCalcR100.EditValue) + CDec(txtCalcR50.EditValue) + CDec(txtCalcR20.EditValue) + CDec(txtCalcR10.EditValue) + _
                   CDec(txtCalcR5.EditValue) + CDec(txtCalcR2.EditValue) + CDec(txtCalcR1.EditValue) + CDec(txtCalcC50.EditValue) + CDec(txtCalcC20.EditValue) + CDec(txtCalcC10.EditValue)
        txtCalcCashUpTotal.EditValue = SumTotal

        ' Cash-Up Tab - Float In Till Group

        txtCalcFloatR200.EditValue = CashUpRow.FloatR200 * 200
        txtCalcFloatR100.EditValue = CashUpRow.FloatR100 * 100
        txtCalcFloatR50.EditValue = CashUpRow.FloatR50 * 50
        txtCalcFloatR20.EditValue = CashUpRow.FloatR20 * 20
        txtCalcFloatR10.EditValue = CashUpRow.FloatR10 * 10
        txtCalcFloatR5.EditValue = CashUpRow.FloatR5 * 5
        txtCalcFloatR2.EditValue = CashUpRow.FloatR2 * 2
        txtCalcFloatR1.EditValue = CashUpRow.FloatR1 * 1
        txtCalcFloatC50.EditValue = CashUpRow.FloatC50 * 0.5
        txtCalcFloatC20.EditValue = CashUpRow.FloatC20 * 0.2
        txtCalcFloatC10.EditValue = CashUpRow.FloatC10 * 0.1
        SumTotal = CDec(txtCalcFloatR200.EditValue) + CDec(txtCalcFloatR100.EditValue) + CDec(txtCalcFloatR50.EditValue) + CDec(txtCalcFloatR20.EditValue) + CDec(txtCalcFloatR10.EditValue) + _
                   CDec(txtCalcFloatR5.EditValue) + CDec(txtCalcFloatR2.EditValue) + CDec(txtCalcFloatR1.EditValue) + CDec(txtCalcFloatC50.EditValue) + CDec(txtCalcFloatC20.EditValue) + CDec(txtCalcFloatC10.EditValue)
        txtCalcFloatTotal.EditValue = SumTotal
        txtDifference.EditValue = (GlobalFirmDetailRow.FloatRequired - SumTotal)
        If txtDifference.EditValue = 0 Then
            txtDifference.TextBox1.BackColor = System.Drawing.Color.White
        Else
            txtDifference.TextBox1.BackColor = System.Drawing.Color.Yellow
        End If

        ' Micros Tab - Micros Entry

        R200 = CInt(txtR200.EditValue) - CInt(txtFloatR200.EditValue)
        R100 = CInt(txtR100.EditValue) - CInt(txtFloatR100.EditValue)
        R50 = CInt(txtR50.EditValue) - CInt(txtFloatR50.EditValue)
        R20 = CInt(txtR20.EditValue) - CInt(txtFloatR20.EditValue)
        R10 = CInt(txtR10.EditValue) - CInt(txtFloatR10.EditValue)
        R5 = CInt(txtR5.EditValue) - CInt(txtFloatR5.EditValue)
        R2 = CInt(txtR2.EditValue) - CInt(txtFloatR2.EditValue)
        R1 = CInt(txtR1.EditValue) - CInt(txtFloatR1.EditValue)
        C50 = CInt(txtC50.EditValue) - CInt(txtFloatC50.EditValue)
        C20 = CInt(txtC20.EditValue) - CInt(txtFloatC20.EditValue)
        C10 = CInt(txtC10.EditValue) - CInt(txtFloatC10.EditValue)

        txtMicrosR200.EditValue = R200
        txtMicrosR100.EditValue = R100
        txtMicrosR50.EditValue = R50
        txtMicrosR20.EditValue = R20
        txtMicrosR10.EditValue = R10
        txtMicrosR5.EditValue = R5
        txtMicrosR2.EditValue = R2
        txtMicrosR1.EditValue = R1
        txtMicrosC50.EditValue = C50
        txtMicrosC20.EditValue = C20
        txtMicrosC10.EditValue = C10

        txtCalcMicrosR200.EditValue = R200 * 200
        txtCalcMicrosR100.EditValue = R100 * 100
        txtCalcMicrosR50.EditValue = R50 * 50
        txtCalcMicrosR20.EditValue = R20 * 20
        txtCalcMicrosR10.EditValue = R10 * 10
        txtCalcMicrosR5.EditValue = R5 * 5
        txtCalcMicrosR2.EditValue = R2 * 2
        txtCalcMicrosR1.EditValue = R1 * 1
        txtCalcMicrosC50.EditValue = C50 * 0.5
        txtCalcMicrosC20.EditValue = C20 * 0.2
        txtCalcMicrosC10.EditValue = C10 * 0.1

        SumTotal = CDec(txtCalcMicrosR200.EditValue) + CDec(txtCalcMicrosR100.EditValue) + CDec(txtCalcMicrosR50.EditValue) + CDec(txtCalcMicrosR20.EditValue) + CDec(txtCalcMicrosR10.EditValue) + _
                   CDec(txtCalcMicrosR5.EditValue) + CDec(txtCalcMicrosR2.EditValue) + CDec(txtCalcMicrosR1.EditValue) + CDec(txtCalcMicrosC50.EditValue) + CDec(txtCalcMicrosC20.EditValue) + CDec(txtCalcMicrosC10.EditValue)
        txtCalcMicrosCashTotal.EditValue = SumTotal
        txtMicrosCCDep.EditValue = txtTotalCreditCard.EditValue
        txtCashUpVariance.EditValue = CashUpRow.CashupVariance

        ' Deposit Tab - Deposit Increased By - Group

        txtCalcDepIncByR200.EditValue = CashUpRow.DepIncByR200 * 200
        txtCalcDepIncByR100.EditValue = CashUpRow.DepIncByR100 * 100
        txtCalcDepIncByR50.EditValue = CashUpRow.DepIncByR50 * 50
        txtCalcDepIncByR20.EditValue = CashUpRow.DepIncByR20 * 20
        txtCalcDepIncByR10.EditValue = CashUpRow.DepIncByR10 * 10
        txtCalcDepIncByR5.EditValue = CashUpRow.DepIncByR5 * 5
        txtCalcDepIncByR2.EditValue = CashUpRow.DepIncByR2 * 2
        txtCalcDepIncByR1.EditValue = CashUpRow.DepIncByR1 * 1
        txtCalcDepIncByC50.EditValue = CashUpRow.DepIncByC50 * 0.5
        txtCalcDepIncByC20.EditValue = CashUpRow.DepIncByC20 * 0.2
        txtCalcDepIncByC10.EditValue = CashUpRow.DepIncByC10 * 0.1
        SumTotal = CDec(txtCalcDepIncByR200.EditValue) + CDec(txtCalcDepIncByR100.EditValue) + CDec(txtCalcDepIncByR50.EditValue) + CDec(txtCalcDepIncByR20.EditValue) + CDec(txtCalcDepIncByR10.EditValue) + _
                   CDec(txtCalcDepIncByR5.EditValue) + CDec(txtCalcDepIncByR2.EditValue) + CDec(txtCalcDepIncByR1.EditValue) + CDec(txtCalcDepIncByC50.EditValue) + CDec(txtCalcDepIncByC20.EditValue) + CDec(txtCalcDepIncByC10.EditValue)
        txtCalcDepIncByTotal.EditValue = SumTotal
        If SumTotal = 0 Then
            txtCalcDepIncByTotal.TextBox1.BackColor = System.Drawing.Color.White
        Else
            txtCalcDepIncByTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
        End If

        ' Deposit Tab - Deposit Reduced By - Group

        txtCalcDepRedByR200.EditValue = CashUpRow.DepRedByR200 * 200
        txtCalcDepRedByR100.EditValue = CashUpRow.DepRedByR100 * 100
        txtCalcDepRedByR50.EditValue = CashUpRow.DepRedByR50 * 50
        txtCalcDepRedByR20.EditValue = CashUpRow.DepRedByR20 * 20
        txtCalcDepRedByR10.EditValue = CashUpRow.DepRedByR10 * 10
        txtCalcDepRedByR5.EditValue = CashUpRow.DepRedByR5 * 5
        txtCalcDepRedByR2.EditValue = CashUpRow.DepRedByR2 * 2
        txtCalcDepRedByR1.EditValue = CashUpRow.DepRedByR1 * 1
        txtCalcDepRedByC50.EditValue = CashUpRow.DepRedByC50 * 0.5
        txtCalcDepRedByC20.EditValue = CashUpRow.DepRedByC20 * 0.2
        txtCalcDepRedByC10.EditValue = CashUpRow.DepRedByC10 * 0.1
        SumTotal = CDec(txtCalcDepRedByR200.EditValue) + CDec(txtCalcDepRedByR100.EditValue) + CDec(txtCalcDepRedByR50.EditValue) + CDec(txtCalcDepRedByR20.EditValue) + CDec(txtCalcDepRedByR10.EditValue) + _
                   CDec(txtCalcDepRedByR5.EditValue) + CDec(txtCalcDepRedByR2.EditValue) + CDec(txtCalcDepRedByR1.EditValue) + CDec(txtCalcDepRedByC50.EditValue) + CDec(txtCalcDepRedByC20.EditValue) + CDec(txtCalcDepRedByC10.EditValue)
        txtCalcDepRedByTotal.EditValue = SumTotal
        If SumTotal = 0 Then
            txtCalcDepRedByTotal.TextBox1.BackColor = System.Drawing.Color.White
        Else
            txtCalcDepRedByTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
        End If

        ' Deposit Tab - Calculated Deposit

        R200 = CInt(txtR200.EditValue) - CInt(txtFloatR200.EditValue) + CInt(txtDepIncByR200.EditValue) - CInt(txtDepRedByR200.EditValue)
        R100 = CInt(txtR100.EditValue) - CInt(txtFloatR100.EditValue) + CInt(txtDepIncByR100.EditValue) - CInt(txtDepRedByR100.EditValue)
        R50 = CInt(txtR50.EditValue) - CInt(txtFloatR50.EditValue) + CInt(txtDepIncByR50.EditValue) - CInt(txtDepRedByR50.EditValue)
        R20 = CInt(txtR20.EditValue) - CInt(txtFloatR20.EditValue) + CInt(txtDepIncByR20.EditValue) - CInt(txtDepRedByR20.EditValue)
        R10 = CInt(txtR10.EditValue) - CInt(txtFloatR10.EditValue) + CInt(txtDepIncByR10.EditValue) - CInt(txtDepRedByR10.EditValue)
        R5 = CInt(txtR5.EditValue) - CInt(txtFloatR5.EditValue) + CInt(txtDepIncByR5.EditValue) - CInt(txtDepRedByR5.EditValue)
        R2 = CInt(txtR2.EditValue) - CInt(txtFloatR2.EditValue) + CInt(txtDepIncByR2.EditValue) - CInt(txtDepRedByR2.EditValue)
        R1 = CInt(txtR1.EditValue) - CInt(txtFloatR1.EditValue) + CInt(txtDepIncByR1.EditValue) - CInt(txtDepRedByR1.EditValue)
        C50 = CInt(txtC50.EditValue) - CInt(txtFloatC50.EditValue) + CInt(txtDepIncByC50.EditValue) - CInt(txtDepRedByC50.EditValue)
        C20 = CInt(txtC20.EditValue) - CInt(txtFloatC20.EditValue) + CInt(txtDepIncByC20.EditValue) - CInt(txtDepRedByC20.EditValue)
        C10 = CInt(txtC10.EditValue) - CInt(txtFloatC10.EditValue) + CInt(txtDepIncByC10.EditValue) - CInt(txtDepRedByC10.EditValue)

        txtDepositR200.EditValue = R200
        txtDepositR100.EditValue = R100
        txtDepositR50.EditValue = R50
        txtDepositR20.EditValue = R20
        txtDepositR10.EditValue = R10
        txtDepositR5.EditValue = R5
        txtDepositR2.EditValue = R2
        txtDepositR1.EditValue = R1
        txtDepositC50.EditValue = C50
        txtDepositC20.EditValue = C20
        txtDepositC10.EditValue = C10

        txtCalcDepositR200.EditValue = R200 * 200
        txtCalcDepositR100.EditValue = R100 * 100
        txtCalcDepositR50.EditValue = R50 * 50
        txtCalcDepositR20.EditValue = R20 * 20
        txtCalcDepositR10.EditValue = R10 * 10
        txtCalcDepositR5.EditValue = R5 * 5
        txtCalcDepositR2.EditValue = R2 * 2
        txtCalcDepositR1.EditValue = R1 * 1
        txtCalcDepositC50.EditValue = C50 * 0.5
        txtCalcDepositC20.EditValue = C20 * 0.2
        txtCalcDepositC10.EditValue = C10 * 0.1
        SumTotal = CDec(txtCalcDepositR200.EditValue) + CDec(txtCalcDepositR100.EditValue) + CDec(txtCalcDepositR50.EditValue) + CDec(txtCalcDepositR20.EditValue) + CDec(txtCalcDepositR10.EditValue) + _
                   CDec(txtCalcDepositR5.EditValue) + CDec(txtCalcDepositR2.EditValue) + CDec(txtCalcDepositR1.EditValue) + CDec(txtCalcDepositC50.EditValue) + CDec(txtCalcDepositC20.EditValue) + CDec(txtCalcDepositC10.EditValue)
        txtCalcDepositCashTotal.EditValue = SumTotal
        txtTotalCCDep.EditValue = txtTotalCreditCard.EditValue

        If txtDepositR200.EditValue < 0 Then
            txtDepositR200.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositR200.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositR200.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositR200.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositR100.EditValue < 0 Then
            txtDepositR100.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositR100.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositR100.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositR100.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositR50.EditValue < 0 Then
            txtDepositR50.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositR50.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositR50.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositR50.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositR20.EditValue < 0 Then
            txtDepositR20.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositR20.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositR20.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositR20.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositR10.EditValue < 0 Then
            txtDepositR10.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositR10.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositR10.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositR10.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositR5.EditValue < 0 Then
            txtDepositR5.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositR5.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositR5.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositR5.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositR2.EditValue < 0 Then
            txtDepositR2.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositR2.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositR2.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositR2.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositR1.EditValue < 0 Then
            txtDepositR1.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositR1.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositR1.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositR1.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositC50.EditValue < 0 Then
            txtDepositC50.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositC50.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositC50.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositC50.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositC20.EditValue < 0 Then
            txtDepositC20.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositC20.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositC20.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositC20.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtDepositC10.EditValue < 0 Then
            txtDepositC10.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositC10.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtDepositC10.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositC10.TextBox1.BackColor = System.Drawing.Color.White
        End If

        If txtCalcDepositCashTotal.EditValue < 0 Then
            txtCalcDepositCashTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCalcDepositCashTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
        Else
            txtCalcDepositCashTotal.TextBox1.BackColor = System.Drawing.Color.White
            txtCalcDepositCashTotal.TextBox1.BackColor = System.Drawing.Color.White
        End If

    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            DC.SubmitChanges()
        Catch ex As Exception
            'MessageBox.Show("UpdateCashUpForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("A Cash-Up Record already Exists for:" & vbCrLf & _
                            "Date: " & vbTab & vbTab & dteDate.Text & vbCrLf & _
                            "Time: " & vbTab & vbTab & cboShift.Text & vbCrLf & _
                            "Employee: " & vbTab & txtEmployeeName.Text & vbCrLf & vbCrLf & _
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Function ValidateData() As DialogResult
        If CashUpRow.Date = Nothing OrElse CashUpRow.Date = Date.MinValue Then CashUpRow.Date = Today

        CashUpRow.Time = cboShift.SelectedIndex

        ' Check if the units are all zero or positive

        If CheckIfUnitsArePositive() = DialogResult.Cancel Then
            Dim Message = String.Format("You must enter a positive number.{0}{0}Please correct this to continue", vbCrLf)
            MessageBox.Show(Message, "Unit Error")
            Return DialogResult.Cancel
        End If

        ' Check if the Float units are higher than cash-up units

        If CheckFloatUnits() = DialogResult.Cancel Then
            Dim Message = String.Format("The units that you have selected for the Float{0}are more than the Cash-Up units.{0}{0}Please correct this to continue", vbCrLf)
            MessageBox.Show(Message, "Float Units Error")
            Return DialogResult.Cancel
        End If

        ' Check if the Credit Card is Zero

        If txtTotalCCDep.EditValue = 0.0 Then
            Dim Message = String.Format("The Credit Card Amount is Zero.{0}{0}Please select Ok to continue or Cancel to change the Credit Card Amount", vbCrLf)
            If MessageBox.Show(Message, "Credit Card Amount Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabCashUp
                Me.txtTotalCCDep.Select()
                Return DialogResult.Cancel
            End If
        End If

        ' Check if the Cash-up Variance is Zero

        If txtCashUpVariance.EditValue = 0.0 Then
            Dim Message = String.Format("The Cash-up Variance Amount is Zero.{0}{0}Please select Ok to continue or Cancel to change the Cash-up Variance Amount", vbCrLf)
            If MessageBox.Show(Message, "Cash-up Variance Amount Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabMicrosCashup
                Me.txtCashUpVariance.Select()
                Return DialogResult.Cancel
            End If
        End If

        ' Check if the Payout1 is Zero

        If txtPayout1.EditValue = 0.0 Then
            Dim Message = String.Format("There are no Payout Amounts for this Cash-up.{0}{0}Please select Ok to continue or Cancel to change the Payout Amounts", vbCrLf)
            If MessageBox.Show(Message, "Payout Amount Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabCashUp
                Me.txtPayout1.Select()
                Return DialogResult.Cancel
            End If
        End If

        ' Check if the Payout1 has a Value but the Reason is Blank

        If txtPayout1.EditValue <> 0.0 And txtPayoutReason1.Text = "" Then
            Dim Message = String.Format("Payout 1 has an Amount but no Reason.{0}{0}Please select Ok to continue or Cancel to change the Payout Reason", vbCrLf)
            If MessageBox.Show(Message, "Payout Reason Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabCashUp
                Me.txtPayoutReason1.Select()
                Return DialogResult.Cancel
            End If
        End If

        ' Check if the Payout2 has a Value but the Reason is Blank

        If txtPayout2.EditValue <> 0.0 And txtPayoutReason2.Text = "" Then
            Dim Message = String.Format("Payout 2 has an Amount but no Reason.{0}{0}Please select Ok to continue or Cancel to change the Payout Reason", vbCrLf)
            If MessageBox.Show(Message, "Payout Reason Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabCashUp
                Me.txtPayoutReason2.Select()
                Return DialogResult.Cancel
            End If
        End If

        ' Check if the Payout3 has a Value but the Reason is Blank

        If txtPayout3.EditValue <> 0.0 And txtPayoutReason3.Text = "" Then
            Dim Message = String.Format("Payout 3 has an Amount but no Reason.{0}{0}Please select Ok to continue or Cancel to change the Payout Reason", vbCrLf)
            If MessageBox.Show(Message, "Payout Reason Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabCashUp
                Me.txtPayoutReason3.Select()
                Return DialogResult.Cancel
            End If
        End If

        ' Check if the Payout4 has a Value but the Reason is Blank

        If txtPayout4.EditValue <> 0.0 And txtPayoutReason4.Text = "" Then
            Dim Message = String.Format("Payout 4 has an Amount but no Reason.{0}{0}Please select Ok to continue or Cancel to change the Payout Reason", vbCrLf)
            If MessageBox.Show(Message, "Payout Reason Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabCashUp
                Me.txtPayoutReason4.Select()
                Return DialogResult.Cancel
            End If
        End If

        ' Check if the Payout5 has a Value but the Reason is Blank

        If txtPayout5.EditValue <> 0.0 And txtPayoutReason5.Text = "" Then
            Dim Message = String.Format("Payout 5 has an Amount but no Reason.{0}{0}Please select Ok to continue or Cancel to change the Payout Reason", vbCrLf)
            If MessageBox.Show(Message, "Payout Reason Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabCashUp
                Me.txtPayoutReason5.Select()
                Return DialogResult.Cancel
            End If
        End If

        ' Check if the Payout1 has a Value but the Reason is Blank

        If txtPayout6.EditValue <> 0.0 And txtPayoutReason6.Text = "" Then
            Dim Message = String.Format("Payout 6 has an Amount but no Reason.{0}{0}Please select Ok to continue or Cancel to change the Payout Reason", vbCrLf)
            If MessageBox.Show(Message, "Payout Reason Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabCashUp
                Me.txtPayoutReason6.Select()
                Return DialogResult.Cancel
            End If
        End If

        ' Check if the float balances with the amount in the FirmDetails File

        Dim FloatTotal As Decimal = txtCalcFloatTotal.EditValue
        If GlobalFirmDetailRow.FloatRequired <> FloatTotal Then
            Dim Message = String.Format("Required Float:{1}{2}{0}Cash-Up Float:{1}{3}{0}{0}Please select Ok to continue or Cancel to correct your Float", vbCrLf, vbTab, GlobalFirmDetailRow.FloatRequired.ToString("N2"), FloatTotal.ToString("N2"))
            If MessageBox.Show(Message, "Float Does Not Balance Warning.", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then
                Me.CashUpTabControl.SelectedTab = tabCashUp
                Me.txtFloatR200.Select()
                Return DialogResult.Cancel
            End If
        End If

        If CheckReducedDepositByUnits() = DialogResult.Cancel Then
            Dim Message = String.Format("The units that you have reduced the deposit by{0}are more than is available.{0}{0}Please correct this to continue", vbCrLf)
            MessageBox.Show(Message, "Deposit Reduced By Units Error")
            Return DialogResult.Cancel
        End If

        CashUpRow.PaymentType = cboPaymentType.SelectedIndex
        If CashUpRow.PaymentType > 2 Then
            CashUpRow.PaymentType = 0
            cboPaymentType.SelectedIndex = 0
        End If

        Return DialogResult.OK
    End Function

    Private Function CheckIfUnitsArePositive() As DialogResult

        ' Check if the "Cash in Till" units entered are positive

        If txtR200.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtR200.Select()
            Return DialogResult.Cancel
        End If
        If txtR100.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtR100.Select()
            Return DialogResult.Cancel
        End If
        If txtR50.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtR50.Select()
            Return DialogResult.Cancel
        End If
        If txtR20.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtR20.Select()
            Return DialogResult.Cancel
        End If
        If txtR10.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtR10.Select()
            Return DialogResult.Cancel
        End If
        If txtR5.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtR5.Select()
            Return DialogResult.Cancel
        End If
        If txtR2.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtR2.Select()
            Return DialogResult.Cancel
        End If
        If txtR1.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtR1.Select()
            Return DialogResult.Cancel
        End If
        If txtC50.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtR50.Select()
            Return DialogResult.Cancel
        End If
        If txtC20.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtC20.Select()
            Return DialogResult.Cancel
        End If
        If txtC10.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtC10.Select()
            Return DialogResult.Cancel
        End If

        ' Check if the "Float In Till" units entered are positive

        If txtFloatR200.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR200.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatR100.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR100.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatR50.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR50.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatR20.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR20.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatR10.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR10.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatR5.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR5.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatR2.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR2.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatR1.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR1.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatC50.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR50.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatC20.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatC20.Select()
            Return DialogResult.Cancel
        End If
        If txtFloatC10.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatC10.Select()
            Return DialogResult.Cancel
        End If

        ' Check if the "Credit Cards" Amount entered is positive

        If txtTotalCreditCard.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtTotalCreditCard.Select()
            Return DialogResult.Cancel
        End If

        ' Check if the "Deposit Skims" Amount entered are positive

        If txtDepositSkim1.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtDepositSkim1.Select()
            Return DialogResult.Cancel
        End If
        If txtDepositSkim2.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtDepositSkim2.Select()
            Return DialogResult.Cancel
        End If
        If txtDepositSkim3.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtDepositSkim3.Select()
            Return DialogResult.Cancel
        End If

        ' Check if the "Payout" Amounts entered are positive

        If txtPayout1.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtPayout1.Select()
            Return DialogResult.Cancel
        End If
        If txtPayout2.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtPayout2.Select()
            Return DialogResult.Cancel
        End If
        If txtPayout3.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtPayout3.Select()
            Return DialogResult.Cancel
        End If
        If txtPayout4.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtPayout4.Select()
            Return DialogResult.Cancel
        End If
        If txtPayout5.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtPayout5.Select()
            Return DialogResult.Cancel
        End If
        If txtPayout6.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtPayout6.Select()
            Return DialogResult.Cancel
        End If

        ' Check if the "Deposit Increased By" units entered are positive

        If txtDepIncByR200.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByR200.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByR100.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByR100.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByR50.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByR50.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByR20.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByR20.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByR10.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByR10.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByR5.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByR5.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByR2.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByR2.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByR1.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByR1.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByC50.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByR50.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByC20.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByC20.Select()
            Return DialogResult.Cancel
        End If
        If txtDepIncByC10.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepIncByC10.Select()
            Return DialogResult.Cancel
        End If

        ' Check if the "Deposit Reduced By" units entered are positive

        If txtDepRedByR200.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR200.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByR100.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR100.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByR50.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR50.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByR20.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR20.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByR10.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR10.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByR5.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR5.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByR2.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR2.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByR1.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR1.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByC50.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR50.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByC20.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByC20.Select()
            Return DialogResult.Cancel
        End If
        If txtDepRedByC10.EditValue < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByC10.Select()
            Return DialogResult.Cancel
        End If

        Return DialogResult.OK
    End Function

    Private Function CheckFloatUnits() As DialogResult
        Dim C10 As Integer = CashUpRow.C10 - CashUpRow.FloatC10
        Dim C20 As Integer = CashUpRow.C20 - CashUpRow.FloatC20
        Dim C50 As Integer = CashUpRow.C50 - CashUpRow.FloatC50
        Dim R1 As Integer = CashUpRow.R1 - CashUpRow.FloatR1
        Dim R2 As Integer = CashUpRow.R2 - CashUpRow.FloatR2
        Dim R5 As Integer = CashUpRow.R5 - CashUpRow.FloatR5
        Dim R10 As Integer = CashUpRow.R10 - CashUpRow.FloatR10
        Dim R20 As Integer = CashUpRow.R20 - CashUpRow.FloatR20
        Dim R50 As Integer = CashUpRow.R50 - CashUpRow.FloatR50
        Dim R100 As Integer = CashUpRow.R100 - CashUpRow.FloatR100
        Dim R200 As Integer = CashUpRow.R200 - CashUpRow.FloatR200

        ' Check if the float units are bigger than the Cash-Up units

        If C10 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatC10.Select()
            Return DialogResult.Cancel
        End If
        If C20 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatC20.Select()
            Return DialogResult.Cancel
        End If
        If C50 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatC50.Select()
            Return DialogResult.Cancel
        End If
        If R1 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR1.Select()
            Return DialogResult.Cancel
        End If
        If R2 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR2.Select()
            Return DialogResult.Cancel
        End If
        If R5 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR5.Select()
            Return DialogResult.Cancel
        End If
        If R10 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR10.Select()
            Return DialogResult.Cancel
        End If
        If R20 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR20.Select()
            Return DialogResult.Cancel
        End If
        If R50 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR50.Select()
            Return DialogResult.Cancel
        End If
        If R100 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR100.Select()
            Return DialogResult.Cancel
        End If
        If R200 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabCashUp
            Me.txtFloatR200.Select()
            Return DialogResult.Cancel
        End If

        Return DialogResult.OK
    End Function

    Private Function CheckReducedDepositByUnits() As DialogResult

        ' Check if the reduced by units is greater than the Cash-up less the float plus the deposit increased by units

        Dim C10 As Integer = CashUpRow.C10 - CashUpRow.FloatC10 + CashUpRow.DepIncByC10 - CashUpRow.DepRedByC10
        Dim C20 As Integer = CashUpRow.C20 - CashUpRow.FloatC20 + CashUpRow.DepIncByC20 - CashUpRow.DepRedByC20
        Dim C50 As Integer = CashUpRow.C50 - CashUpRow.FloatC50 + CashUpRow.DepIncByC50 - CashUpRow.DepRedByC50
        Dim R1 As Integer = CashUpRow.R1 - CashUpRow.FloatR1 + CashUpRow.DepIncByR1 - CashUpRow.DepRedByR1
        Dim R2 As Integer = CashUpRow.R2 - CashUpRow.FloatR2 + CashUpRow.DepIncByR2 - CashUpRow.DepRedByR2
        Dim R5 As Integer = CashUpRow.R5 - CashUpRow.FloatR5 + CashUpRow.DepIncByR5 - CashUpRow.DepRedByR5
        Dim R10 As Integer = CashUpRow.R10 - CashUpRow.FloatR10 + CashUpRow.DepIncByR10 - CashUpRow.DepRedByR10
        Dim R20 As Integer = CashUpRow.R20 - CashUpRow.FloatR20 + CashUpRow.DepIncByR20 - CashUpRow.DepRedByR20
        Dim R50 As Integer = CashUpRow.R50 - CashUpRow.FloatR50 + CashUpRow.DepIncByR50 - CashUpRow.DepRedByR50
        Dim R100 As Integer = CashUpRow.R100 - CashUpRow.FloatR100 + CashUpRow.DepIncByR100 - CashUpRow.DepRedByR100
        Dim R200 As Integer = CashUpRow.R200 - CashUpRow.FloatR200 + CashUpRow.DepIncByR200 - CashUpRow.DepRedByR200

        If C10 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByC10.Select()
            Return DialogResult.Cancel
        End If
        If C20 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByC20.Select()
            Return DialogResult.Cancel
        End If
        If C50 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByC50.Select()
            Return DialogResult.Cancel
        End If
        If R1 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR1.Select()
            Return DialogResult.Cancel
        End If
        If R2 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR2.Select()
            Return DialogResult.Cancel
        End If
        If R5 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR5.Select()
            Return DialogResult.Cancel
        End If
        If R10 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR10.Select()
            Return DialogResult.Cancel
        End If
        If R20 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR20.Select()
            Return DialogResult.Cancel
        End If
        If R50 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR50.Select()
            Return DialogResult.Cancel
        End If
        If R100 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR100.Select()
            Return DialogResult.Cancel
        End If
        If R200 < 0 Then
            Me.CashUpTabControl.SelectedTab = tabDeposit
            Me.txtDepRedByR200.Select()
            Return DialogResult.Cancel
        End If

        Return DialogResult.OK
    End Function

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If SaveRecord() <> DialogResult.OK Then Return
        Me.Close()
    End Sub

    Private Function SaveRecord() As DialogResult
        BindingSource1.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return DialogResult.Cancel
        If SaveData() <> DialogResult.OK Then Return DialogResult.Cancel
        Return DialogResult.OK
    End Function

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub btnExtractFloat_Click(sender As Object, e As EventArgs) Handles btnExtractFloat.Click
        CalculateFloat()
    End Sub

    Private Sub btnRemCoinsFromDep_Click(sender As Object, e As EventArgs) Handles btnRemCoinsFromDep.Click
        btnRemoveCoinsFromDeposit_Click()
    End Sub


    Private Sub CalculateFloat()

        ReducingFloat = GlobalFirmDetailRow.FloatRequired
        C10 = CashUpRow.C10
        C20 = CashUpRow.C20
        C50 = CashUpRow.C50
        R1 = CashUpRow.R1
        R2 = CashUpRow.R2
        R5 = CashUpRow.R5
        R10 = CashUpRow.R10
        R20 = CashUpRow.R20
        R50 = CashUpRow.R50
        R100 = CashUpRow.R100
        R200 = CashUpRow.R200

        FloatC10 = 0
        FloatC20 = 0
        FloatC50 = 0
        FloatR1 = 0
        FloatR2 = 0
        FloatR5 = 0
        FloatR10 = 0
        FloatR20 = 0
        FloatR50 = 0
        FloatR100 = 0
        FloatR200 = 0

        ' Put at least 1 x R 100 and at least 1 x R 50

        If R100 > 0 Then
            Amount = 100
            R100 -= 1
            FloatR100 = 1
            ReducingFloat -= Amount
        End If
        If R50 > 0 Then
            Amount = 50
            R50 -= 1
            FloatR50 = 1
            ReducingFloat -= Amount
        End If

        AllocateAllUnits()
        AllocateSomeUnits()
        AddOneBack()
        ReduceSomeUnits()

        CashUpRow.FloatC10 = FloatC10
        CashUpRow.FloatC20 = FloatC20
        CashUpRow.FloatC50 = FloatC50
        CashUpRow.FloatR1 = FloatR1
        CashUpRow.FloatR2 = FloatR2
        CashUpRow.FloatR5 = FloatR5
        CashUpRow.FloatR10 = FloatR10
        CashUpRow.FloatR20 = FloatR20
        CashUpRow.FloatR50 = FloatR50
        CashUpRow.FloatR100 = FloatR100
        CashUpRow.FloatR200 = FloatR200

        txtFloatC10.EditValue = FloatC10
        txtFloatC20.EditValue = FloatC20
        txtFloatC50.EditValue = FloatC50
        txtFloatR1.EditValue = FloatR1
        txtFloatR2.EditValue = FloatR2
        txtFloatR5.EditValue = FloatR5
        txtFloatR10.EditValue = FloatR10
        txtFloatR20.EditValue = FloatR20
        txtFloatR50.EditValue = FloatR50
        txtFloatR100.EditValue = FloatR100
        txtFloatR200.EditValue = FloatR200
        txtDifference.EditValue = ReducingFloat

        FormatText()
    End Sub

    Private Sub AllocateAllUnits()

        Dim Number As Integer = 0

        While ReducingFloat > 0
            Select Case Number
                Case 0      ' 10 Cents
                    Amount = (C10 * 0.1)
                    If Amount < ReducingFloat Then
                        FloatC10 += C10
                        C10 = 0
                        ReducingFloat -= Amount
                    End If
                Case 1      ' 20 Cents
                    Amount = (C20 * 0.2)
                    If Amount < ReducingFloat Then
                        FloatC20 += C20
                        C20 = 0
                        ReducingFloat -= Amount
                    End If
                Case 2      ' 50 Cents
                    Amount = (C50 * 0.5)
                    If Amount < ReducingFloat Then
                        FloatC50 += C50
                        C50 = 0
                        ReducingFloat -= Amount
                    End If
                Case 3      ' R 1
                    Amount = (R1 * 1)
                    If Amount < ReducingFloat Then
                        FloatR1 += R1
                        R1 = 0
                        ReducingFloat -= Amount
                    End If
                Case 4      ' R 2
                    Amount = (R2 * 2)
                    If Amount < ReducingFloat Then
                        FloatR2 += R2
                        R2 = 0
                        ReducingFloat -= Amount
                    End If
                Case 5      ' R 5
                    Amount = (R5 * 5)
                    If Amount < ReducingFloat Then
                        FloatR5 += R5
                        R5 = 0
                        ReducingFloat -= Amount
                    End If
                Case 6      ' R 10
                    Amount = (R10 * 10)
                    If Amount < ReducingFloat Then
                        FloatR10 += R10
                        R10 = 0
                        ReducingFloat -= Amount
                    End If
                Case 7      ' R 20
                    Amount = (R20 * 20)
                    If Amount < ReducingFloat Then
                        FloatR20 += R20
                        R20 = 0
                        ReducingFloat -= Amount
                    End If
                Case 8      ' R 50
                    Amount = (R50 * 50)
                    If Amount < ReducingFloat Then
                        FloatR50 += R50
                        R50 = 0
                        ReducingFloat -= Amount
                    End If
                Case 9      ' R 100
                    Amount = (R100 * 100)
                    If Amount < ReducingFloat Then
                        FloatR100 += R100
                        R100 = 0
                        ReducingFloat -= Amount
                    End If
                Case 10     ' R 200
                    Amount = (R200 * 200)
                    If Amount < ReducingFloat Then
                        FloatR200 += R200
                        R200 = 0
                        ReducingFloat -= Amount
                    End If
            End Select
            Number += 1
            If Number > 10 Then Exit While
        End While
    End Sub

    Private Sub AllocateSomeUnits()

        Dim Number As Integer = 0

        While ReducingFloat > 0
            Select Case Number
                Case 0      ' 10 Cents
                    While C10 > 1
                        C10 -= 1
                        Amount = (C10 * 0.1)
                        If Amount < ReducingFloat Then
                            FloatC10 += C10
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 1      ' 20 Cents
                    While C20 > 1
                        C20 -= 1
                        Amount = (C20 * 0.2)
                        If Amount < ReducingFloat Then
                            FloatC20 += C20
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 2      ' 50 Cents
                    While C50 > 1
                        C50 -= 1
                        Amount = (C50 * 0.5)
                        If Amount < ReducingFloat Then
                            FloatC50 += C50
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 3      ' R 1
                    While R1 > 1
                        R1 -= 1
                        Amount = (R1 * 1)
                        If Amount < ReducingFloat Then
                            FloatR1 += R1
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 4      ' R 2
                    While R2 > 1
                        R2 -= 1
                        Amount = (R2 * 2)
                        If Amount < ReducingFloat Then
                            FloatR2 += R2
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 5      ' R 5
                    While R5 > 1
                        R5 -= 1
                        Amount = (R5 * 5)
                        If Amount < ReducingFloat Then
                            FloatR5 += R5
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 6      ' R 10
                    While R10 > 1
                        R10 -= 1
                        Amount = (R10 * 10)
                        If Amount < ReducingFloat Then
                            FloatR10 += R10
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 7      ' R 20
                    While R20 > 1
                        R20 -= 1
                        Amount = (R20 * 20)
                        If Amount < ReducingFloat Then
                            FloatR20 += R20
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 8      ' R 50
                    While R50 > 1
                        R50 -= 1
                        Amount = (R50 * 50)
                        If Amount < ReducingFloat Then
                            FloatR50 += R50
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 9      ' R 100
                    While R100 > 1
                        R100 -= 1
                        Amount = (R100 * 100)
                        If Amount < ReducingFloat Then
                            FloatR100 += R100
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
                Case 10     ' R 200
                    While R200 > 1
                        R200 -= 1
                        Amount = (R200 * 200)
                        If Amount < ReducingFloat Then
                            FloatR200 += R200
                            ReducingFloat -= Amount
                            Exit While
                        End If
                    End While
            End Select
            Number += 1
            If Number > 10 Then Exit While
        End While
        DenominationLeftAfterFloatRemoved()
    End Sub

    Private Sub AddOneBack()
        Dim CurrentDenomination As Decimal = 0.0

        If ReducingFloat < 200 Then CurrentDenomination = 200
        If ReducingFloat < 100 Then CurrentDenomination = 100
        If ReducingFloat < 50 Then CurrentDenomination = 50
        If ReducingFloat < 20 Then CurrentDenomination = 20
        If ReducingFloat < 10 Then CurrentDenomination = 10
        If ReducingFloat < 5 Then CurrentDenomination = 5
        If ReducingFloat < 2 Then CurrentDenomination = 2
        If ReducingFloat < 1 Then CurrentDenomination = 1
        If ReducingFloat < 0.5 Then CurrentDenomination = 0.5
        If ReducingFloat < 0.2 Then CurrentDenomination = 0.2
        If ReducingFloat < 0.1 Then CurrentDenomination = 0.1

        If CurrentDenomination = 0.1 Then
            If C10 = 0 Then
                CurrentDenomination = 0.2
            Else
                Amount = 0.1
                FloatC10 += 1
                C10 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 0.2 Then
            If C20 = 0 Then
                CurrentDenomination = 0.5
            Else
                Amount = 0.2
                FloatC20 += 1
                C20 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 0.5 Then
            If C50 = 0 Then
                CurrentDenomination = 1
            Else
                Amount = 0.5
                FloatC50 += 1
                C50 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 1 Then
            If R1 = 0 Then
                CurrentDenomination = 2
            Else
                Amount = 1
                FloatR1 += 1
                R1 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 2 Then
            If R2 = 0 Then
                CurrentDenomination = 5
            Else
                Amount = 2
                FloatR2 += 1
                R2 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 5 Then
            If R5 = 0 Then
                CurrentDenomination = 10
            Else
                Amount = 5
                FloatR5 += 1
                R5 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 10 Then
            If R10 = 0 Then
                CurrentDenomination = 20
            Else
                Amount = 10
                FloatR10 += 1
                R10 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 20 Then
            If R20 = 0 Then
                CurrentDenomination = 50
            Else
                Amount = 20
                FloatR20 += 1
                R20 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 50 Then
            If R50 = 0 Then
                CurrentDenomination = 100
            Else
                Amount = 50
                FloatR50 += 1
                R50 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 100 Then
            If R100 = 0 Then
                CurrentDenomination = 200
            Else
                Amount = 100
                FloatR100 += 1
                R100 -= 1
                ReducingFloat -= Amount
            End If
        End If
        If CurrentDenomination = 200 Then
            If R200 <> 0 Then
                Amount = 200
                FloatR200 += 1
                R200 -= 1
                ReducingFloat -= Amount
            End If
        End If
    End Sub

    Private Sub ReduceSomeUnits()
        Dim Number As Integer = 0

        While ReducingFloat < 0
            Select Case Number
                Case 0     ' R 200
                    While FloatR200 > 0
                        Amount = 200.0
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatR200 -= 1
                            R200 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 1      ' R 100
                    While FloatR100 > 0
                        Amount = 100.0
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatR100 -= 1
                            R100 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 2      ' R 50
                    While FloatR50 > 0
                        Amount = 50.0
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatR50 -= 1
                            R50 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 3      ' R 20
                    While FloatR20 > 0
                        Amount = 20.0
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatR20 -= 1
                            R20 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 4      ' R 10
                    While FloatR10 > 0
                        Amount = 10
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatR10 -= 1
                            R10 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 5      ' R 5
                    While FloatR5 > 0
                        Amount = 5
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatR5 -= 1
                            R5 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 6      ' R 2
                    While FloatR2 > 0
                        Amount = 2
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatR2 -= 1
                            R2 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 7      ' R 1
                    While FloatR1 > 0
                        Amount = 1
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatR1 -= 1
                            R1 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 8      ' 50 Cents
                    While FloatC50 > 0
                        Amount = 0.5
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatC50 -= 1
                            C50 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 9      ' 20 Cents
                    While FloatC20 > 0
                        Amount = 0.2
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatC20 -= 1
                            C20 += 1
                            ReducingFloat += Amount
                        End If
                    End While
                Case 10      ' 10 Cents
                    While FloatC10 > 0
                        Amount = 0.1
                        If (Amount + ReducingFloat > 0.0) Then
                            Exit While
                        Else
                            FloatC10 -= 1
                            C10 += 1
                            ReducingFloat += Amount
                        End If
                    End While
            End Select
            Number += 1
            If Number > 10 Then Exit While
        End While
        DenominationLeftAfterFloatRemoved()
    End Sub

    Private Sub DenominationLeftAfterFloatRemoved()

        C10 = CashUpRow.C10 - FloatC10
        C20 = CashUpRow.C20 - FloatC20
        C50 = CashUpRow.C50 - FloatC50
        R1 = CashUpRow.R1 - FloatR1
        R2 = CashUpRow.R2 - FloatR2
        R5 = CashUpRow.R5 - FloatR5
        R10 = CashUpRow.R10 - FloatR10
        R20 = CashUpRow.R20 - FloatR20
        R50 = CashUpRow.R50 - FloatR50
        R100 = CashUpRow.R100 - FloatR100
        R200 = CashUpRow.R200 - FloatR200
    End Sub

    Private Sub btnRemoveCoinsFromDeposit_Click()

        ' Remove Coins from the deposit

        Dim C10 As Integer = CashUpRow.C10 - CashUpRow.FloatC10 + CashUpRow.DepIncByC10
        Dim C20 As Integer = CashUpRow.C20 - CashUpRow.FloatC20 + CashUpRow.DepIncByC20
        Dim C50 As Integer = CashUpRow.C50 - CashUpRow.FloatC50 + CashUpRow.DepIncByC50
        Dim R1 As Integer = CashUpRow.R1 - CashUpRow.FloatR1 + CashUpRow.DepIncByR1
        Dim R2 As Integer = CashUpRow.R2 - CashUpRow.FloatR2 + CashUpRow.DepIncByR2
        Dim R5 As Integer = CashUpRow.R5 - CashUpRow.FloatR5 + CashUpRow.DepIncByR5

        txtDepRedByC10.Text = C10.ToString
        txtDepRedByC20.Text = C20.ToString
        txtDepRedByC50.Text = C50.ToString
        txtDepRedByR1.Text = R1.ToString
        txtDepRedByR2.Text = R2.ToString
        txtDepRedByR5.Text = R5.ToString
        txtDepRedByR10.Text = "0.00"
        txtDepRedByR20.Text = "0.00"
        txtDepRedByR50.Text = "0.00"
        txtDepRedByR100.Text = "0.00"
        txtDepRedByR200.Text = "0.00"

        CashUpRow.DepRedByC10 = C10
        CashUpRow.DepRedByC20 = C20
        CashUpRow.DepRedByC50 = C50
        CashUpRow.DepRedByR1 = R1
        CashUpRow.DepRedByR2 = R2
        CashUpRow.DepRedByR5 = R5
        CashUpRow.DepRedByR10 = 0.0
        CashUpRow.DepRedByR20 = 0.0
        CashUpRow.DepRedByR50 = 0.0
        CashUpRow.DepRedByR100 = 0.0
        CashUpRow.DepRedByR200 = 0.0

        FormatText()
    End Sub

    Private Sub CashupTabNextButton_Click(sender As Object, e As EventArgs) Handles CashupTabNextButton.Click
        CashUpTabControl.SelectedTab = tabMicrosCashup
        FormatText()
    End Sub

    Private Sub MicrosTabPreviousButton_Click(sender As Object, e As EventArgs) Handles MicrosTabPreviousButton.Click
        CashUpTabControl.SelectedTab = tabCashUp
        FormatText()
    End Sub

    Private Sub MicrosTabNextButton_Click(sender As Object, e As EventArgs) Handles MicrosTabNextButton.Click
        CashUpTabControl.SelectedTab = tabDeposit
        FormatText()
    End Sub

    Private Sub DepositTabPreviousButton_Click(sender As Object, e As EventArgs) Handles DepositTabPreviousButton.Click
        CashUpTabControl.SelectedTab = tabMicrosCashup
        FormatText()
    End Sub

    Private Sub txtR200_Validated(sender As Object, e As EventArgs) Handles txtR200.Validated
        CashUpRow.R200 = txtR200.EditValue
        FormatText()
    End Sub
    Private Sub txtR100_Validated(sender As Object, e As EventArgs) Handles txtR100.Validated
        CashUpRow.R100 = txtR100.EditValue
        FormatText()
    End Sub
    Private Sub txtR50_Validated(sender As Object, e As EventArgs) Handles txtR50.Validated
        CashUpRow.R50 = txtR50.EditValue
        FormatText()
    End Sub
    Private Sub txtR20_Validated(sender As Object, e As EventArgs) Handles txtR20.Validated
        CashUpRow.R20 = txtR20.EditValue
        FormatText()
    End Sub
    Private Sub txtR10_Validated(sender As Object, e As EventArgs) Handles txtR10.Validated
        CashUpRow.R10 = txtR10.EditValue
        FormatText()
    End Sub
    Private Sub txtR5_Validated(sender As Object, e As EventArgs) Handles txtR5.Validated
        CashUpRow.R5 = txtR5.EditValue
        FormatText()
    End Sub
    Private Sub txtR2_Validated(sender As Object, e As EventArgs) Handles txtR2.Validated
        CashUpRow.R2 = txtR2.EditValue
        FormatText()
    End Sub
    Private Sub txtR1_Validated(sender As Object, e As EventArgs) Handles txtR1.Validated
        CashUpRow.R1 = txtR1.EditValue
        FormatText()
    End Sub
    Private Sub txtC50_Validated(sender As Object, e As EventArgs) Handles txtC50.Validated
        CashUpRow.C50 = txtC50.EditValue
        FormatText()
    End Sub
    Private Sub txtC20_Validated(sender As Object, e As EventArgs) Handles txtC20.Validated
        CashUpRow.C20 = txtC20.EditValue
        FormatText()
    End Sub
    Private Sub txtC10_Validated(sender As Object, e As EventArgs) Handles txtC10.Validated
        CashUpRow.C10 = txtC10.EditValue
        FormatText()
    End Sub

    Private Sub txtFloatR200_Validated(sender As Object, e As EventArgs) Handles txtFloatR200.Validated
        CashUpRow.FloatR200 = txtFloatR200.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatR100_Validated(sender As Object, e As EventArgs) Handles txtFloatR100.Validated
        CashUpRow.FloatR100 = txtFloatR100.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatR50_Validated(sender As Object, e As EventArgs) Handles txtFloatR50.Validated
        CashUpRow.FloatR50 = txtFloatR50.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatR20_Validated(sender As Object, e As EventArgs) Handles txtFloatR20.Validated
        CashUpRow.FloatR20 = txtFloatR20.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatR10_Validated(sender As Object, e As EventArgs) Handles txtFloatR10.Validated
        CashUpRow.FloatR10 = txtFloatR10.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatR5_Validated(sender As Object, e As EventArgs) Handles txtFloatR5.Validated
        CashUpRow.FloatR5 = txtFloatR5.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatR2_Validated(sender As Object, e As EventArgs) Handles txtFloatR2.Validated
        CashUpRow.FloatR2 = txtFloatR2.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatR1_Validated(sender As Object, e As EventArgs) Handles txtFloatR1.Validated
        CashUpRow.FloatR1 = txtFloatR1.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatC50_Validated(sender As Object, e As EventArgs) Handles txtFloatC50.Validated
        CashUpRow.FloatC50 = txtFloatC50.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatC20_Validated(sender As Object, e As EventArgs) Handles txtFloatC20.Validated
        CashUpRow.FloatC20 = txtFloatC20.EditValue
        FormatText()
    End Sub
    Private Sub txtFloatC10_Validated(sender As Object, e As EventArgs) Handles txtFloatC10.Validated
        CashUpRow.FloatC10 = txtFloatC10.EditValue
        FormatText()
    End Sub

    Private Sub txtDepositSkim1_Validated(sender As Object, e As EventArgs) Handles txtDepositSkim1.Validated
        CashUpRow.DepositedSkim1 = txtDepositSkim1.EditValue
    End Sub
    Private Sub txtDepositSkim2_Validated(sender As Object, e As EventArgs) Handles txtDepositSkim2.Validated
        CashUpRow.DepositedSkim2 = txtDepositSkim2.EditValue
    End Sub
    Private Sub txtDepositSkim3_Validated(sender As Object, e As EventArgs) Handles txtDepositSkim3.Validated
        CashUpRow.DepositedSkim3 = txtDepositSkim3.EditValue
    End Sub
    Private Sub txtPayout1_Validated(sender As Object, e As EventArgs) Handles txtPayout1.Validated
        CashUpRow.Payout1 = txtPayout1.EditValue
    End Sub
    Private Sub txtPayout2_Validated(sender As Object, e As EventArgs) Handles txtPayout2.Validated
        CashUpRow.Payout2 = txtPayout2.EditValue
    End Sub
    Private Sub txtPayout3_Validated(sender As Object, e As EventArgs) Handles txtPayout3.Validated
        CashUpRow.Payout3 = txtPayout3.EditValue
    End Sub
    Private Sub txtPayout4_Validated(sender As Object, e As EventArgs) Handles txtPayout4.Validated
        CashUpRow.Payout4 = txtPayout4.EditValue
    End Sub
    Private Sub txtPayout5_Validated(sender As Object, e As EventArgs) Handles txtPayout5.Validated
        CashUpRow.Payout5 = txtPayout5.EditValue
    End Sub
    Private Sub txtPayout6_Validated(sender As Object, e As EventArgs) Handles txtPayout6.Validated
        CashUpRow.Payout6 = txtPayout6.EditValue
    End Sub
    Private Sub txtTotalCreditCard_Validated(sender As Object, e As EventArgs) Handles txtTotalCreditCard.Validated
        CashUpRow.TotalCreditCard = txtTotalCreditCard.EditValue
    End Sub
    Private Sub txtCashUpVariance_Validated(sender As Object, e As EventArgs) Handles txtCashUpVariance.Validated
        CashUpRow.CashupVariance = txtCashUpVariance.EditValue
        FormatText()
    End Sub

    Private Sub txtDepIncByR200_Validated(sender As Object, e As EventArgs) Handles txtDepIncByR200.Validated
        CashUpRow.DepIncByR200 = txtDepIncByR200.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByR100_Validated(sender As Object, e As EventArgs) Handles txtDepIncByR100.Validated
        CashUpRow.DepIncByR100 = txtDepIncByR100.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByR50_Validated(sender As Object, e As EventArgs) Handles txtDepIncByR50.Validated
        CashUpRow.DepIncByR50 = txtDepIncByR50.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByR20_Validated(sender As Object, e As EventArgs) Handles txtDepIncByR20.Validated
        CashUpRow.DepIncByR20 = txtDepIncByR20.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByR10_Validated(sender As Object, e As EventArgs) Handles txtDepIncByR10.Validated
        CashUpRow.DepIncByR10 = txtDepIncByR10.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByR5_Validated(sender As Object, e As EventArgs) Handles txtDepIncByR5.Validated
        CashUpRow.DepIncByR5 = txtDepIncByR5.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByR2_Validated(sender As Object, e As EventArgs) Handles txtDepIncByR2.Validated
        CashUpRow.DepIncByR2 = txtDepIncByR2.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByR1_Validated(sender As Object, e As EventArgs) Handles txtDepIncByR1.Validated
        CashUpRow.DepIncByR1 = txtDepIncByR1.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByC50_Validated(sender As Object, e As EventArgs) Handles txtDepIncByC50.Validated
        CashUpRow.DepIncByC50 = txtDepIncByC50.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByC20_Validated(sender As Object, e As EventArgs) Handles txtDepIncByC20.Validated
        CashUpRow.DepIncByC20 = txtDepIncByC20.EditValue
        FormatText()
    End Sub
    Private Sub txtDepIncByC10_Validated(sender As Object, e As EventArgs) Handles txtDepIncByC10.Validated
        CashUpRow.DepIncByC10 = txtDepIncByC10.EditValue
        FormatText()
    End Sub

    Private Sub txtDepRedByR200_Validated(sender As Object, e As EventArgs) Handles txtDepRedByR200.Validated
        CashUpRow.DepRedByR200 = txtDepRedByR200.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByR100_Validated(sender As Object, e As EventArgs) Handles txtDepRedByR100.Validated
        CashUpRow.DepRedByR100 = txtDepRedByR100.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByR50_Validated(sender As Object, e As EventArgs) Handles txtDepRedByR50.Validated
        CashUpRow.DepRedByR50 = txtDepRedByR50.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByR20_Validated(sender As Object, e As EventArgs) Handles txtDepRedByR20.Validated
        CashUpRow.DepRedByR20 = txtDepRedByR20.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByR10_Validated(sender As Object, e As EventArgs) Handles txtDepRedByR10.Validated
        CashUpRow.DepRedByR10 = txtDepRedByR10.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByR5_Validated(sender As Object, e As EventArgs) Handles txtDepRedByR5.Validated
        CashUpRow.DepRedByR5 = txtDepRedByR5.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByR2_Validated(sender As Object, e As EventArgs) Handles txtDepRedByR2.Validated
        CashUpRow.DepRedByR2 = txtDepRedByR2.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByR1_Validated(sender As Object, e As EventArgs) Handles txtDepRedByR1.Validated
        CashUpRow.DepRedByR1 = txtDepRedByR1.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByC50_Validated(sender As Object, e As EventArgs) Handles txtDepRedByC50.Validated
        CashUpRow.DepRedByC50 = txtDepRedByC50.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByC20_Validated(sender As Object, e As EventArgs) Handles txtDepRedByC20.Validated
        CashUpRow.DepRedByC20 = txtDepRedByC20.EditValue
        FormatText()
    End Sub
    Private Sub txtDepRedByC10_Validated(sender As Object, e As EventArgs) Handles txtDepRedByC10.Validated
        CashUpRow.DepRedByC10 = txtDepRedByC10.EditValue
        FormatText()
    End Sub

    Private Sub CashUpTabControl_Click(sender As Object, e As EventArgs) Handles CashUpTabControl.Click
        FormatText()
    End Sub

    Private Sub btnPrintCashUp_Click(sender As Object, e As EventArgs) Handles SummaryButton.Click
        If SaveRecord() <> DialogResult.OK Then Return
        Using frm As New PrintCashupForm(CashUpRow.RecordId)
            BindingSource1.EndEdit()
            frm.ShowDialog()
        End Using
    End Sub

End Class