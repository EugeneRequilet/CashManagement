Public Class SelectDateForm

    Private Sub SelectDateForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtDate.Text = Today.ToString ' (DateSerial(Year(Today), Month(Today), 1)).ToString
        GlobalSelectedDate = txtDate.Value
        ckbIncludeEmployee.CheckState = GlobalIncludeEmployees
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        GlobalSelectedDate = txtDate.Value
        GlobalIncludeEmployees = ckbIncludeEmployee.CheckState
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        GlobalSelectedDate = Nothing
        Me.Close()
    End Sub

End Class