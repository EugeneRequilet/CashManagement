Public Class UpdateFirmDetailsForm

    Dim DC As FirmDetailDataContext
    Public FirmDetailRow As FirmDetail

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New FirmDetailDataContext
        FirmDetailBindingSource.DataSource = From FirmDetail In DC.FirmDetails
        If FirmDetailBindingSource.Count = 0 Then FirmDetailBindingSource.AddNew()

        FirmDetailBindingSource.Position = 0
        FirmDetailRow = FirmDetailBindingSource.Current
        If String.IsNullOrWhiteSpace(FirmDetailRow.FirmName) Then
            FirmDetailRow.FirmName = "Demo Company"
            FirmDetailRow.FloatRequired = 602.0
            FirmDetailRow.GrossSalesHighlight = 5000.0
            FirmDetailRow.GrossCashupDifHighlight = 50.0
            FirmDetailRow.OverbakeHighlight = 500.0
            FirmDetailRow.DiscountHighlight = 200.0
            FirmDetailRow.StaffMealHighlight = 100.0
            FirmDetailRow.HoursPerShift = 7
        End If
        setNumericsOnScreens()
    End Sub

    Private Sub setNumericsOnScreens()
        txtFloatRequired.EditValue = FirmDetailRow.FloatRequired
        txtGrossSalesHighlight.EditValue = FirmDetailRow.GrossSalesHighlight
        txtGrossCashupDifHighlight.EditValue = FirmDetailRow.GrossCashupDifHighlight
        txtOverbakeHighlight.EditValue = FirmDetailRow.OverbakeHighlight
        txtDiscountHighlight.EditValue = FirmDetailRow.DiscountHighlight
        txtStaffMealHighlight.EditValue = FirmDetailRow.StaffMealHighlight
        txtHoursPerShift.EditValue = FirmDetailRow.HoursPerShift
    End Sub

    Private Function ValidateData() As DialogResult
        FirmDetailBindingSource.EndEdit()
        Return System.Windows.Forms.DialogResult.OK
    End Function

    Public Function SaveData() As DialogResult
        Try
            FirmDetailBindingSource.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("UpdateFirmDetailsForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub PhysicalToPostalButton_Click(sender As Object, e As EventArgs) Handles PhysicalToPostalButton.Click
        FirmDetailRow.PostalAddress1 = FirmDetailRow.PhysicalAddress1
        FirmDetailRow.PostalAddress2 = FirmDetailRow.PhysicalAddress2
        FirmDetailRow.PostalAddress3 = FirmDetailRow.PhysicalAddress3
        FirmDetailRow.PostalCode = FirmDetailRow.PhysicalCode
    End Sub

    Private Sub PostalToPhysicalButton_Click(sender As Object, e As EventArgs) Handles PostalToPhysicalButton.Click
        FirmDetailRow.PhysicalAddress1 = FirmDetailRow.PostalAddress1
        FirmDetailRow.PhysicalAddress2 = FirmDetailRow.PostalAddress2
        FirmDetailRow.PhysicalAddress3 = FirmDetailRow.PostalAddress3
        FirmDetailRow.PhysicalCode = FirmDetailRow.PostalCode
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If ValidateData() <> System.Windows.Forms.DialogResult.OK Then Return
        If SaveData() <> System.Windows.Forms.DialogResult.OK Then Return
        DialogResult = System.Windows.Forms.DialogResult.OK
        SetGlobalFirmDetail()
        Me.Close()
    End Sub

    Private Sub CmdCancelButton_Click(sender As Object, e As EventArgs) Handles CmdCancelButton.Click
        Me.Close()
    End Sub

    Private Sub txtFloatRequired_Validated(sender As Object, e As EventArgs) Handles txtFloatRequired.Validated
        FirmDetailRow.FloatRequired = txtFloatRequired.EditValue
    End Sub

    Private Sub txtGrossSalesHighlight_Validated(sender As Object, e As EventArgs) Handles txtGrossSalesHighlight.Validated
        FirmDetailRow.GrossSalesHighlight = txtGrossSalesHighlight.EditValue
    End Sub

    Private Sub txtGrossCashupDifHighlight_Validated(sender As Object, e As EventArgs) Handles txtGrossCashupDifHighlight.Validated
        FirmDetailRow.GrossCashupDifHighlight = txtGrossCashupDifHighlight.EditValue
    End Sub

    Private Sub txtOverbakeHighlight_Validated(sender As Object, e As EventArgs) Handles txtOverbakeHighlight.Validated
        FirmDetailRow.OverbakeHighlight = txtOverbakeHighlight.EditValue
    End Sub

    Private Sub txtDiscountHighlight_Validated(sender As Object, e As EventArgs) Handles txtDiscountHighlight.Validated
        FirmDetailRow.DiscountHighlight = txtDiscountHighlight.EditValue
    End Sub

    Private Sub txtStaffMealHighlight_Validated(sender As Object, e As EventArgs) Handles txtStaffMealHighlight.Validated
        FirmDetailRow.StaffMealHighlight = txtStaffMealHighlight.EditValue
    End Sub

    Private Sub txtHoursPerShift_Validated1(sender As Object, e As EventArgs) Handles txtHoursPerShift.Validated
        FirmDetailRow.HoursPerShift = txtHoursPerShift.EditValue
    End Sub

End Class