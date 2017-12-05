Public Class UpdateSalesForm

    Public RecordId As Integer

    Dim DC As SalesDataContext
    Dim SalesRow As Sales
    Dim InsertMode As Boolean = False

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
        DC = New SalesDataContext
        BindingSource1.DataSource = From Sales In DC.Sales Where Sales.RecordId = RecordId
        SalesRow = BindingSource1.Current
        If SalesRow Is Nothing Then
            SalesRow = New Sales
            BindingSource1.AddNew()
            SalesRow = BindingSource1.Current
            setDefaults()
            Me.dteDate.Select()
            InsertMode = True
        End If
        setNumericsOnScreens()
    End Sub

    Private Sub setDefaults()
        If SalesRow.Date = Nothing OrElse SalesRow.Date = Date.MinValue Then SalesRow.Date = Today
        If SalesRow.GrossSales = Nothing Then SalesRow.GrossSales = 0.0
        If SalesRow.Payout = Nothing Then SalesRow.Payout = 0.0
        If SalesRow.TurnoverCash = Nothing Then SalesRow.TurnoverCash = 0.0
        If SalesRow.TurnoverCreditCard = Nothing Then SalesRow.TurnoverCreditCard = 0.0
        If SalesRow.TurnoverOther = Nothing Then SalesRow.TurnoverOther = 0.0
        If SalesRow.StaffPercent100 = Nothing Then SalesRow.StaffPercent100 = 0.0
        If SalesRow.DiscountPercent20 = Nothing Then SalesRow.DiscountPercent20 = 0.0
        If SalesRow.WastagePercent100 = Nothing Then SalesRow.WastagePercent100 = 0.0
        If SalesRow.PromoPercent100 = Nothing Then SalesRow.PromoPercent100 = 0.0
        If SalesRow.OverbakePercent100 = Nothing Then SalesRow.OverbakePercent100 = 0.0
        If SalesRow.DamagePercent100 = Nothing Then SalesRow.DamagePercent100 = 0.0
        If SalesRow.SamplePercent100 = Nothing Then SalesRow.SamplePercent100 = 0.0
        If SalesRow.StockVarianceValue = Nothing Then SalesRow.StockVarianceValue = 0.0
        If SalesRow.EmployeeRecordId = Nothing OrElse SalesRow.EmployeeRecordId = 0 Then SalesRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        'Dim Message = String.Format("setDefaults.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, SalesRow.Gender, SalesRow.MaritalStatus, SalesRow.DateStarted, SalesRow.NoOfDependants, SalesRow.Rate)
        'MsgBox(Message)

    End Sub

    Private Sub setNumericsOnScreens()
        If InsertMode = False And GlobalEmployeeIsType < GlobalAdministrator Then
            dteDate.Enabled = False
        End If
        txtGrossSales.EditValue = SalesRow.GrossSales
        txtPayout.EditValue = SalesRow.Payout
        txtTurnoverCash.EditValue = SalesRow.TurnoverCash
        txtTurnoverCreditCard.EditValue = SalesRow.TurnoverCreditCard
        txtTurnoverOther.EditValue = SalesRow.TurnoverOther
        txtStaffPercent100.EditValue = SalesRow.StaffPercent100
        txtDiscountPercent20.EditValue = SalesRow.DiscountPercent20
        txtWastagePercent100.EditValue = SalesRow.WastagePercent100
        txtPromoPercent100.EditValue = SalesRow.PromoPercent100
        txtOverbakePercent100.EditValue = SalesRow.OverbakePercent100
        txtDamagePercent100.EditValue = SalesRow.DamagePercent100
        txtSamplePercent100.EditValue = SalesRow.SamplePercent100
        txtStockVarianceValue.EditValue = SalesRow.StockVarianceValue
        txtChecksPaid.EditValue = SalesRow.ChecksPaid
        txtErrorCorrects.EditValue = SalesRow.ErrorCorrects
        txtErrorCorrectsValue.EditValue = SalesRow.ErrorCorrectsValue
        txtVoid.EditValue = SalesRow.Void
        txtVoidsValue.EditValue = SalesRow.VoidsValue
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            DC.SubmitChanges()
        Catch ex As Exception
            'MessageBox.Show("UpdateSalesForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("A Sales Record already Exists for:" & vbCrLf &
                            "Date: " & vbTab & dteDate.Text & vbCrLf & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Function ValidateData() As DialogResult
        'SalesRow.GrossSales = txtGrossSales.EditValue
        'SalesRow.Payout = txtPayout.EditValue
        'SalesRow.TurnoverCash = txtTurnoverCash.EditValue
        'SalesRow.TurnoverCreditCard = txtTurnoverCreditCard.EditValue
        'SalesRow.TurnoverOther = txtTurnoverOther.EditValue
        'SalesRow.StaffPercent100 = txtStaffPercent100.EditValue
        'SalesRow.DiscountPercent20 = txtDiscountPercent20.EditValue
        'SalesRow.WastagePercent100 = txtWastagePercent100.EditValue
        'SalesRow.PromoPercent100 = txtPromoPercent100.EditValue
        'SalesRow.OverbakePercent100 = txtOverbakePercent100.EditValue
        'SalesRow.DamagePercent100 = txtDamagePercent100.EditValue
        'SalesRow.SamplePercent100 = txtSamplePercent100.EditValue
        'SalesRow.StockVarianceValue = txtStockVarianceValue.EditValue
        'SalesRow.ChecksPaid = txtChecksPaid.EditValue
        'SalesRow.ErrorCorrects = txtErrorCorrects.EditValue
        'SalesRow.ErrorCorrectsValue = txtErrorCorrectsValue.EditValue
        'SalesRow.Void = txtVoid.EditValue
        'SalesRow.VoidsValue = txtVoidsValue.EditValue
        'SalesRow.StockVarianceValue = txtStockVarianceValue.EditValue

        If (SalesRow.GrossSales - SalesRow.Payout) <> (SalesRow.TurnoverCash + SalesRow.TurnoverCreditCard + SalesRow.TurnoverOther) Then
            Dim GrossSaleslessPayout As String = Format((SalesRow.GrossSales - SalesRow.Payout), "N2")
            Dim TurnoverCashPlusCCPlusOther As String = Format((SalesRow.TurnoverCash + SalesRow.TurnoverCreditCard + SalesRow.TurnoverOther), "N2")
            MessageBox.Show("Gross Sales less Payouts = " & GrossSaleslessPayout & vbCrLf & vbCrLf & "Does Not Equal" & vbCrLf & vbCrLf & "Cash plus Credit Cards plus Other = " & TurnoverCashPlusCCPlusOther, "Entry Error")
            Return DialogResult.Cancel
        End If

        If dteDate.Text = "" Then
            dteDate.Text = FormatDateTime(Today)
            SalesRow.Date = Today
        End If

        If SalesRow.ErrorCorrects <> 0 Then
            If SalesRow.ErrorCorrectsValue = 0.0 Then
                MessageBox.Show("Please enter a Value for your Error Corrects", "Entry Error")
                txtErrorCorrectsValue.Focus()
                Return DialogResult.Cancel
            End If
        End If
        If SalesRow.ErrorCorrectsValue <> 0.0 Then
            If SalesRow.ErrorCorrects = 0 Then
                MessageBox.Show("Please enter the Number of Error Corrects", "Entry Error")
                txtErrorCorrects.Focus()
                Return DialogResult.Cancel
            End If
        End If

        If SalesRow.Void <> 0 Then
            If SalesRow.VoidsValue = 0.0 Then
                MessageBox.Show("Please enter a Value for your Voids", "Entry Error")
                txtVoidsValue.Focus()
                Return DialogResult.Cancel
            End If
        End If
        If SalesRow.VoidsValue <> 0.0 Then
            If SalesRow.Void = 0 Then
                MessageBox.Show("Please enter the Number of Voids", "Entry Error")
                txtVoid.Focus()
                Return DialogResult.Cancel
            End If
        End If

        'Dim Message = String.Format("ValidateData.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, SalesRow.Gender, SalesRow.MaritalStatus, SalesRow.DateStarted, SalesRow.NoOfDependants, SalesRow.Rate)
        'MsgBox(Message)

        Return DialogResult.OK
    End Function

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        BindingSource1.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtGrossSales_Validated(sender As Object, e As EventArgs) Handles txtGrossSales.Validated
        SalesRow.GrossSales = txtGrossSales.EditValue
    End Sub

    Private Sub txtPayout_Validated(sender As Object, e As EventArgs) Handles txtPayout.Validated
        SalesRow.Payout = txtPayout.EditValue
    End Sub

    Private Sub txtTurnoverCash_Validated(sender As Object, e As EventArgs) Handles txtTurnoverCash.Validated
        SalesRow.TurnoverCash = txtTurnoverCash.EditValue
    End Sub

    Private Sub txtTurnoverCreditCard_Validated(sender As Object, e As EventArgs) Handles txtTurnoverCreditCard.Validated
        SalesRow.TurnoverCreditCard = txtTurnoverCreditCard.EditValue
    End Sub

    Private Sub txtTurnoverOther_Validated(sender As Object, e As EventArgs) Handles txtTurnoverOther.Validated
        SalesRow.TurnoverOther = txtTurnoverOther.EditValue
    End Sub

    Private Sub txtStaffPercent100_Validated(sender As Object, e As EventArgs) Handles txtStaffPercent100.Validated
        SalesRow.StaffPercent100 = txtStaffPercent100.EditValue
    End Sub

    Private Sub txtDiscountPercent20_Validated(sender As Object, e As EventArgs) Handles txtDiscountPercent20.Validated
        SalesRow.DiscountPercent20 = txtDiscountPercent20.EditValue
    End Sub

    Private Sub txtWastagePercent100_Validated(sender As Object, e As EventArgs) Handles txtWastagePercent100.Validated
        SalesRow.WastagePercent100 = txtWastagePercent100.EditValue
    End Sub

    Private Sub txtPromoPercent100_Validated(sender As Object, e As EventArgs) Handles txtPromoPercent100.Validated
        SalesRow.PromoPercent100 = txtPromoPercent100.EditValue
    End Sub

    Private Sub txtOverbakePercent100_Validated(sender As Object, e As EventArgs) Handles txtOverbakePercent100.Validated
        SalesRow.OverbakePercent100 = txtOverbakePercent100.EditValue
    End Sub

    Private Sub txtDamagePercent100_Validated(sender As Object, e As EventArgs) Handles txtDamagePercent100.Validated
        SalesRow.DamagePercent100 = txtDamagePercent100.EditValue
    End Sub

    Private Sub txtSamplePercent100_Validated(sender As Object, e As EventArgs) Handles txtSamplePercent100.Validated
        SalesRow.SamplePercent100 = txtSamplePercent100.EditValue
    End Sub

    Private Sub txtChecksPaid_Validated(sender As Object, e As EventArgs) Handles txtChecksPaid.Validated
        SalesRow.ChecksPaid = txtChecksPaid.EditValue
    End Sub

    Private Sub txtErrorCorrects_Validated(sender As Object, e As EventArgs) Handles txtErrorCorrects.Validated
        SalesRow.ErrorCorrects = txtErrorCorrects.EditValue
    End Sub

    Private Sub txtErrorCorrectsValue_Validated(sender As Object, e As EventArgs) Handles txtErrorCorrectsValue.Validated
        SalesRow.ErrorCorrectsValue = txtErrorCorrectsValue.EditValue
    End Sub

    Private Sub txtVoid_Validated(sender As Object, e As EventArgs) Handles txtVoid.Validated
        SalesRow.Void = txtVoid.EditValue
    End Sub

    Private Sub txtVoidsValue_Validated(sender As Object, e As EventArgs) Handles txtVoidsValue.Validated
        SalesRow.VoidsValue = txtVoidsValue.EditValue
    End Sub

    Private Sub txtStockVarianceValue_Validated(sender As Object, e As EventArgs) Handles txtStockVarianceValue.Validated
        SalesRow.StockVarianceValue = txtStockVarianceValue.EditValue
    End Sub
End Class