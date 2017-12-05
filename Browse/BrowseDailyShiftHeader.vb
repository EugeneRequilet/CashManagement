Public Class BrowseDailyShiftHeader

    Private Sub BrowseDailyShiftHeader_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Remember to set the browse KeyPreview to TRUE
        Select Case e.KeyCode
            Case Keys.Insert
                InsertButton_Click(Nothing, Nothing)
            Case Keys.Enter
                ChangeButton_Click(Nothing, Nothing)
            Case Keys.Delete
                DeleteButton_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalDateFrom = (DateSerial(Year(Today), Month(Today) - 1, 26))
        GlobalDateTo = (DateSerial(Year(Today), Month(Today), 25))
        DisplayGlobalFromToDates()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        GlobalDailyShiftHeaderLookupRecordId = 0
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            DailyShiftHeaderGrid1.DeleteRow()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        DailyShiftHeaderGrid1.ChangeRow()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateDailyShiftHeaderForm(-1)
            frm.ShowDialog()
            DailyShiftHeaderGrid1.LoadData()
        End Using
    End Sub

    Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
        DailyShiftHeaderGrid1.SelectRow()
        Me.Close()
    End Sub

    Private Sub txtDateFrom_ValueChanged(sender As Object, e As EventArgs)
        DisplayGlobalFromToDates()
    End Sub

    Private Sub DateButton_Click(sender As Object, e As EventArgs) Handles DateButton.Click
        Using frm As New SelectDateFromToForm()
            frm.ShowDialog()
            DisplayGlobalFromToDates()
        End Using
    End Sub

    Private Sub DisplayGlobalFromToDates()
        lblDateRange.Text = GlobalDateFrom.ToString("dd/MM/yyyy") & " to " & GlobalDateTo.ToString("dd/MM/yyyy")
        DailyShiftHeaderGrid1.LoadData()
    End Sub

End Class