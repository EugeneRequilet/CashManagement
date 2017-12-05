Imports System.Linq

Public Class AdjustmentTransactionGrid

    Dim DC As AdjustmentTransactionDataContext

    Public Sub LoadData()
        Try
            Dim SQL = "Select * From AdjustmentTransactionView Order By InventoryDescription"
            If GlobalAdjustmentLookupRecordId <> 0 Then SQL = "Select * From AdjustmentTransactionView Where AdjustmentRequestedRecordId = " & GlobalAdjustmentLookupRecordId & " Order By InventoryDescription"
            DC = New AdjustmentTransactionDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of AdjustmentTransactionView)(SQL)
        Catch ex As Exception
            MessageBox.Show("AdjustmentTransactionGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("AdjustmentTransactionGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim AdjustmentTransactionRow As AdjustmentTransactionView = BindingSource1.Current
            Dim Message = String.Format("Deleting AdjustmentTransaction {0}.{1} Are you sure?", AdjustmentTransactionRow.InventoryDescription, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentAdjustmentTransaction As AdjustmentTransaction = (From x In DC.AdjustmentTransactions Where x.RecordId.Equals(AdjustmentTransactionRow.RecordId) Select x).FirstOrDefault()
            DC.AdjustmentTransactions.DeleteOnSubmit(CurrentAdjustmentTransaction)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("AdjustmentTransactionGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim AdjustmentTransactionRow As AdjustmentTransactionView = BindingSource1.Current
            Using frm As New UpdateAdjustmentTransactionForm(AdjustmentTransactionRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("AdjustmentTransactionGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
