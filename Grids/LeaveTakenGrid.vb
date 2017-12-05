Imports System.Linq

Public Class LeaveTakenGrid

    Dim DC As LeaveTakenDataContext

    Public Sub LoadData()
        Try
            Dim SQL = "Select * From LeaveTakenView Where StartDate >= '" & _
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and StartDate <= '" & _
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
                        "' Order by StartDate, RecordId"
            DC = New LeaveTakenDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of LeaveTakenView)(SQL)
        Catch ex As Exception
            MessageBox.Show("LeaveTakenGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("LeaveTakenGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim LeaveTakenRow As LeaveTakenView = BindingSource1.Current
            Dim Message = String.Format("Deleting LeaveTaken {0}.{1} Are you sure?", LeaveTakenRow.StartDate & " " & LeaveTakenRow.EndDate & " " & LeaveTakenRow.LeaveType, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentLeaveTaken As LeaveTaken = (From x In DC.LeaveTakens Where x.RecordId.Equals(LeaveTakenRow.RecordId) Select x).FirstOrDefault()
            DC.LeaveTakens.DeleteOnSubmit(CurrentLeaveTaken)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("LeaveTakenGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim LeaveTakenRow As LeaveTakenView = BindingSource1.Current
            Using frm As New UpdateLeaveTakenForm(LeaveTakenRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("LeaveTakenGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function SelectRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim LeaveTakenRow As LeaveTakenView = BindingSource1.Current
            Dim CurrentLeaveTaken As LeaveTaken = (From x In DC.LeaveTakens Where x.RecordId.Equals(LeaveTakenRow.RecordId) Select x).FirstOrDefault()
            'GlobalLeaveTakenLookupRecordId = LeaveTakenRow.RecordId
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("LeaveTakenGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
