Public Class AssetGrid

    Dim DC As AssetDataContext

    Public Sub LoadData()
        Try
            ' Dim SQL = "Select * From AssetView Order by BranchCode, Description"

            Dim SQL = "Select * From AssetView"
            If GlobalBranchLookupBranchCode <> "" Then
                SQL = SQL & " Where BranchCode = '" & GlobalBranchLookupBranchCode & "'"
            End If
            SQL = SQL & " Order by BranchCode, Description"

            DC = New AssetDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of AssetView)(SQL)
        Catch ex As Exception
            MessageBox.Show("AssetGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("AssetGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim AssetViewRow As AssetView = BindingSource1.Current
            Dim Message = String.Format("Deleting Asset {0}.{1} Are you sure?", AssetViewRow.Description, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentAsset As Asset = (From x In DC.Assets Where x.RecordId.Equals(AssetViewRow.RecordId) Select x).FirstOrDefault()
            DC.Assets.DeleteOnSubmit(CurrentAsset)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("AssetGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim AssetRow As AssetView = BindingSource1.Current
            Using frm As New UpdateAssetForm(AssetRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("AssetGrid ChangeRow() Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function


    Public Function ServicedRecord() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim AssetRow As AssetView = BindingSource1.Current
            GlobalAssetLookupRecordId = AssetRow.RecordId
            Using frm As New BrowseServiced()
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
            GlobalAssetLookupRecordId = 0
        Catch ex As Exception
            MessageBox.Show("AssetGrid ServicedRecord() Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function AttachmentRecord() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim AssetRow As AssetView = BindingSource1.Current
            GlobalAssetLookupRecordId = AssetRow.RecordId
            Using frm As New BrowseAttachment()
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
            GlobalAssetLookupRecordId = 0
        Catch ex As Exception
            MessageBox.Show("AssetGrid AttachedRecord() Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
