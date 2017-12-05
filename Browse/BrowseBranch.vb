Public Class BrowseBranch

    Private Sub BrowseBranch_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub BrowseBranch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalHideInsertAmendDelete = True Then
            InsertButton.Enabled = False
            ChangeButton.Enabled = False
            DeleteButton.Enabled = False
            SelectButton.Enabled = True
        Else
            InsertButton.Enabled = True
            ChangeButton.Enabled = True
            DeleteButton.Enabled = True
            SelectButton.Enabled = False
        End If
        BranchGrid.LoadData()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        GlobalBranchLookupBranchCode = ""
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            BranchGrid.DeleteRow()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        BranchGrid.ChangeRow()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateBranchForm(-1)
            frm.ShowDialog()
            BranchGrid.LoadData()
        End Using
    End Sub

    Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
        BranchGrid.SelectRow()
        Me.Close()
    End Sub

End Class