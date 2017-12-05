Public Class UpdateDebtorTransForm
    Public RecordId As Integer

    Dim DC As CashUpDataContext
    Dim CashUpRow As CashUp
    Dim InsertMode As Boolean = False

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub UpdateDebtorTransForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
            Me.txtPayoutReason.Select()
            InsertMode = True
        End If
        ReadEmployee()
        setDropdowns()
        setNumericsOnScreens()
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

        If CashUpRow.SalesType = Nothing Then CashUpRow.SalesType = 1
        If CashUpRow.PaymentType = Nothing Then CashUpRow.PaymentType = 0

        If CashUpRow.EmployeeRecordId = Nothing OrElse CashUpRow.EmployeeRecordId = 0 Then CashUpRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        'Dim Message = String.Format("setDefaults.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, CashUpRow.Gender, CashUpRow.MaritalStatus, CashUpRow.DateStarted, CashUpRow.NoOfDependants, CashUpRow.Rate)
        'MsgBox(Message)

    End Sub

    Private Sub setDropdowns()
        cboDebtorType.Items.Clear()
        cboDebtorType.Items.Add("Accommodation")
        cboDebtorType.Items.Add("Other")
        cboDebtorType.SelectedIndex = (CashUpRow.SalesType - 1)
        If cboDebtorType.SelectedIndex > 2 Then
            cboDebtorType.SelectedIndex = 0
            CashUpRow.PaymentType = 1
        End If
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
    End Sub

    Private Sub setNumericsOnScreens()
        If InsertMode = False And GlobalEmployeeIsType < GlobalAdministrator Then
            dteDate.Enabled = False
            If CashUpRow.CashDepReconciled = True Then
                OkButton.Enabled = False
            End If
        End If

        If GlobalEmployeeIsType = GlobalAdministrator Then
            chbCashDeposited.Visible = True
        End If

        With CashUpRow
            txtCashInTillLessFloat.EditValue = CDec(.R200 * 200) + CDec(.R100 * 100) + CDec(.R50 * 50) + CDec(.R20 * 20) + CDec(.R10 * 10) +
                                                CDec(.R5 * 5) + CDec(.R2 * 2) + CDec(.R1 * 1) + CDec(.C50 * 0.5) + CDec(.C20 * 0.2) + CDec(.C10 * 0.1)
        End With
        If CashUpRow.CashDepReconciled Then chbCashDeposited.CheckState = 1

        If chbCashDeposited.CheckState = 1 Then
            txtCashInTillLessFloat.IsReadOnly = True
        Else
            txtCashInTillLessFloat.IsReadOnly = False
        End If
    End Sub

    Private Function SaveRecord() As DialogResult
        BindingSource1.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return DialogResult.Cancel
        If SaveData() <> DialogResult.OK Then Return DialogResult.Cancel
        Return DialogResult.OK
    End Function

    Private Function ValidateData() As DialogResult
        If CashUpRow.Date = Nothing OrElse CashUpRow.Date = Date.MinValue Then CashUpRow.Date = Today
        If CashUpRow.Time = Nothing OrElse CashUpRow.Time = 0 Then CashUpRow.Time = CInt(DateTime.Now.Second)

        CashUpRow.SalesType = (cboDebtorType.SelectedIndex + 1)
        If CashUpRow.SalesType > 2 Then
            CashUpRow.SalesType = 1
            cboDebtorType.SelectedIndex = 0
        End If

        CashUpRow.PaymentType = cboPaymentType.SelectedIndex
        If CashUpRow.PaymentType > 1 Then
            CashUpRow.PaymentType = 0
            cboPaymentType.SelectedIndex = 0
        End If

        Return DialogResult.OK
    End Function

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            DC.SubmitChanges()
        Catch ex As Exception
            'MessageBox.Show("UpdateCashUpForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("A Cash-Up Record already Exists for:" & vbCrLf &
                            "Date: " & vbTab & vbTab & dteDate.Text & vbCrLf &
                            "Time: " & vbTab & vbTab & CashUpRow.Time.ToString & vbCrLf & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If SaveRecord() <> DialogResult.OK Then Return
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtCashInTillLessFloat_Validated(sender As Object, e As EventArgs) Handles txtCashInTillLessFloat.Validated
        Dim WorkAmount = txtCashInTillLessFloat.EditValue
        With CashUpRow
            .R100 = CInt(WorkAmount / 100)
            WorkAmount = WorkAmount - (.R100 * 100)
            .R1 = CInt(WorkAmount / 1)
            WorkAmount = WorkAmount - (.R1 * 1)
            .C10 = CInt(WorkAmount / 0.1)
        End With
    End Sub

End Class