Imports System.Linq

Public Class AttachmentGrid

    Dim DC As AttachmentDataContext

    Public Sub LoadData()
        Try
            Dim SQL = "Select * From AttachmentView Order by Description"
            If GlobalAssetLookupRecordId Then
                SQL = "Select * From AttachmentView Where AssetRecordId = " & GlobalAssetLookupRecordId & " Order by Description"
            End If
            DC = New AttachmentDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of AttachmentView)(SQL)
        Catch ex As Exception
            MessageBox.Show("AttachmentGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("AttachmentGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim AttachmentRow As AttachmentView = BindingSource1.Current
            Dim Message = String.Format("Deleting Attachment {0}.{1} Are you sure?", AttachmentRow.Description, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentAttachment As Attachment = (From x In DC.Attachments Where x.RecordId.Equals(AttachmentRow.RecordId) Select x).FirstOrDefault()
            DC.Attachments.DeleteOnSubmit(CurrentAttachment)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("AttachmentGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim AttachmentRow As AttachmentView = BindingSource1.Current
            Using frm As New UpdateAttachmentForm(AttachmentRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("AttachmentGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
