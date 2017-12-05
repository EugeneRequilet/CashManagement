Imports System.Linq

Public Class ServicedGrid

    Dim DC As ServicedDataContext

    Public Sub LoadData()
        Try
            Dim SQL = "Select * From ServicedView Order by Description"
            If GlobalAssetLookupRecordId Then
                SQL = "Select * From ServicedView Where AssetRecordId = " & GlobalAssetLookupRecordId & " Order by Description"
            End If
            DC = New ServicedDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of ServicedView)(SQL)
        Catch ex As Exception
            MessageBox.Show("ServicedGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("ServicedGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim ServicedRow As ServicedView = BindingSource1.Current
            Dim Message = String.Format("Deleting Serviced {0}.{1} Are you sure?", ServicedRow.Description, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentServiced As Serviced = (From x In DC.Serviceds Where x.RecordId.Equals(ServicedRow.RecordId) Select x).FirstOrDefault()
            DC.Serviceds.DeleteOnSubmit(CurrentServiced)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("ServicedGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim ServicedRow As ServicedView = BindingSource1.Current
            Using frm As New UpdateServicedForm(ServicedRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("ServicedGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
