Imports System.Linq

Public Class AdjustmentGrid

    Dim DC As AdjustmentDataContext

    Public Sub LoadData()
        Try
            ' Dim SQL = "Select * From AdjustmentView Order by Date Desc"
            Dim SQL = "Select * From AdjustmentView Where Date >= '" & _
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" & _
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
                        "' Order by date"
            DC = New AdjustmentDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of AdjustmentView)(SQL)
        Catch ex As Exception
            MessageBox.Show("AdjustmentGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("AdjustmentGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim AdjustmentRow As AdjustmentView = BindingSource1.Current
            Dim Message = String.Format("Deleting Adjustment {0}.{1} Are you sure?", AdjustmentRow.Date, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentAdjustment As AdjustmentRequested = (From x In DC.AdjustmentRequesteds Where x.RecordId.Equals(AdjustmentRow.RecordId) Select x).FirstOrDefault()
            DC.AdjustmentRequesteds.DeleteOnSubmit(CurrentAdjustment)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("Delete the Adjustment Items before deleting the Adjustment", "Reporting Error")
            ' MessageBox.Show("AdjustmentGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim AdjustmentRow As AdjustmentView = BindingSource1.Current
            Using frm As New UpdateAdjustmentForm(AdjustmentRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("AdjustmentGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function SelectRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim AdjustmentRow As AdjustmentView = BindingSource1.Current
            Dim CurrentAdjustment As AdjustmentRequested = (From x In DC.AdjustmentRequesteds Where x.RecordId.Equals(AdjustmentRow.RecordId) Select x).FirstOrDefault()
            GlobalAdjustmentLookupRecordId = AdjustmentRow.RecordId
            DC.SubmitChanges()

        Catch ex As Exception
            MessageBox.Show("AdjustmentGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
