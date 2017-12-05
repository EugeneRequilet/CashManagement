Imports System.Linq

Public Class BranchGrid

    Dim DC As BranchDataContext

    Public Sub LoadData()
        Try
            Dim SQL = "Select * From BranchView Order by Description"
            DC = New BranchDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of BranchView)(SQL)
        Catch ex As Exception
            MessageBox.Show("BranchGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("BranchGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim BranchViewRow As BranchView = BindingSource1.Current
            Dim Message = String.Format("Deleting Branch {0}.{1} Are you sure?", BranchViewRow.Description, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentBranch As Branch = (From x In DC.Branches Where x.RecordId.Equals(BranchViewRow.RecordId) Select x).FirstOrDefault()
            DC.Branches.DeleteOnSubmit(CurrentBranch)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("BranchGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If GlobalHideInsertAmendDelete = False Then
            ChangeRow()
        End If
    End Sub

    Public Function ChangeRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim BranchRow As BranchView = BindingSource1.Current
            Using frm As New UpdateBranchForm(BranchRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("BranchGrid ChangeRow() Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function SelectRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim BranchRow As BranchView = BindingSource1.Current
            Dim CurrentBranch As Branch = (From x In DC.Branches Where x.RecordId.Equals(BranchRow.RecordId) Select x).FirstOrDefault()
            GlobalBranchLookupBranchCode = BranchRow.BranchCode
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("BranchGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
