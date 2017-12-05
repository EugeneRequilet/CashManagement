Public Class CashierFloatCountForm

    Private Sub CashierFloatCountForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setNumericsOnScreens()
        FormatText()
    End Sub

    Private Sub setNumericsOnScreens()
        txtFloatR200.EditValue = 0.0
        txtFloatR200.EditValue = 0.0
        txtFloatR100.EditValue = 0.0
        txtFloatR50.EditValue = 0.0
        txtFloatR20.EditValue = 0.0
        txtFloatR10.EditValue = 0.0
        txtFloatR5.EditValue = 0.0
        txtFloatR2.EditValue = 0.0
        txtFloatR1.EditValue = 0.0
        txtFloatC50.EditValue = 0.0
        txtFloatC20.EditValue = 0.0
        txtFloatC10.EditValue = 0.0
    End Sub

    Private Sub FormatText()
        Dim SumTotal As Decimal
        txtCalcFloatR200.EditValue = txtFloatR200.EditValue * 200
        txtCalcFloatR100.EditValue = txtFloatR100.EditValue * 100
        txtCalcFloatR50.EditValue = txtFloatR50.EditValue * 50
        txtCalcFloatR20.EditValue = txtFloatR20.EditValue * 20
        txtCalcFloatR10.EditValue = txtFloatR10.EditValue * 10
        txtCalcFloatR5.EditValue = txtFloatR5.EditValue * 5
        txtCalcFloatR2.EditValue = txtFloatR2.EditValue * 2
        txtCalcFloatR1.EditValue = txtFloatR1.EditValue * 1
        txtCalcFloatC50.EditValue = txtFloatC50.EditValue * 0.5
        txtCalcFloatC20.EditValue = txtFloatC20.EditValue * 0.2
        txtCalcFloatC10.EditValue = txtFloatC10.EditValue * 0.1
        SumTotal = CDec(txtCalcFloatR200.EditValue) + CDec(txtCalcFloatR100.EditValue) + CDec(txtCalcFloatR50.EditValue) + CDec(txtCalcFloatR20.EditValue) + CDec(txtCalcFloatR10.EditValue) + _
                   CDec(txtCalcFloatR5.EditValue) + CDec(txtCalcFloatR2.EditValue) + CDec(txtCalcFloatR1.EditValue) + CDec(txtCalcFloatC50.EditValue) + CDec(txtCalcFloatC20.EditValue) + CDec(txtCalcFloatC10.EditValue)
        txtCalcFloatTotal.EditValue = SumTotal
        txtDifference.EditValue = (GlobalFirmDetailRow.FloatRequired - SumTotal)
        If txtDifference.EditValue = 0 Then
            txtDifference.TextBox1.BackColor = System.Drawing.Color.White
        Else
            txtDifference.TextBox1.BackColor = System.Drawing.Color.Yellow
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtFloatR200_Validated(sender As Object, e As EventArgs) Handles txtFloatR200.Validated
        FormatText()
    End Sub

    Private Sub txtFloatR100_Validated(sender As Object, e As EventArgs) Handles txtFloatR100.Validated
        FormatText()
    End Sub

    Private Sub txtFloatR50_Validated(sender As Object, e As EventArgs) Handles txtFloatR50.Validated
        FormatText()
    End Sub

    Private Sub txtFloatR20_Validated(sender As Object, e As EventArgs) Handles txtFloatR20.Validated
        FormatText()
    End Sub

    Private Sub txtFloatR10_Validated(sender As Object, e As EventArgs) Handles txtFloatR10.Validated
        FormatText()
    End Sub

    Private Sub txtFloatR5_Validated(sender As Object, e As EventArgs) Handles txtFloatR5.Validated
        FormatText()
    End Sub

    Private Sub txtFloatR2_Validated(sender As Object, e As EventArgs) Handles txtFloatR2.Validated
        FormatText()
    End Sub

    Private Sub txtFloatR1_Validated(sender As Object, e As EventArgs) Handles txtFloatR1.Validated
        FormatText()
    End Sub

    Private Sub txtFloatC50_Validated(sender As Object, e As EventArgs) Handles txtFloatC50.Validated
        FormatText()
    End Sub

    Private Sub txtFloatC20_Validated(sender As Object, e As EventArgs) Handles txtFloatC20.Validated
        FormatText()
    End Sub

    Private Sub txtFloatC10_Validated(sender As Object, e As EventArgs) Handles txtFloatC10.Validated
        FormatText()
    End Sub

    Private Sub ClearDataButton_Click(sender As Object, e As EventArgs) Handles ClearDataButton.Click
        CashierFloatCountForm_Load(Nothing, Nothing)
    End Sub

End Class