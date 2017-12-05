Imports System.Linq

Public Class TaskGrid
    Dim DC As TaskDataContext

    Public Sub LoadData()
        Dim SQL As String
        Try
            SQL = "Select * From TaskView Order by Groupnumber, Number"
            'If GlobalFilterString <> "" Then SQL = "Select * From TaskView where Description like '%" & GlobalFilterString & "%' Order by Description"
            DC = New TaskDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of TaskView)(SQL)
        Catch ex As Exception
            MessageBox.Show("TaskGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("TaskGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim TaskRow As TaskView = BindingSource1.Current
            Dim Message = String.Format("Deleting Task {0}.{1} Are you sure?", TaskRow.Description, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentTask As Task = (From x In DC.Tasks Where x.RecordId.Equals(TaskRow.RecordId) Select x).FirstOrDefault()
            DC.Tasks.DeleteOnSubmit(CurrentTask)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("TaskGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim TaskRow As TaskView = BindingSource1.Current
            Using frm As New UpdateTaskForm(TaskRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("TaskGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
