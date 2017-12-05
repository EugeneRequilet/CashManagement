Imports System.Linq

Public Class SupplierGrid

    Dim DC As SupplierDataContext

    Public Sub LoadData()
        Try
            Dim SQL = "Select * From SupplierView where InactiveSupplier <> 1 Order by Description"
            If GlobalShowInactiveSuppliers = 1 Then
                SQL = "Select * From SupplierView Order by Description"
            End If
            DC = New SupplierDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of SupplierView)(SQL)
        Catch ex As Exception
            MessageBox.Show("SupplierGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("SupplierGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim SupplierRow As SupplierView = BindingSource1.Current
            Dim Message = String.Format("Deleting Supplier {0}.{1} Are you sure?", SupplierRow.Description, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentSupplier As Supplier = (From x In DC.Suppliers Where x.RecordId.Equals(SupplierRow.RecordId) Select x).FirstOrDefault()
            DC.Suppliers.DeleteOnSubmit(CurrentSupplier)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("SupplierGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim SupplierRow As SupplierView = BindingSource1.Current
            Using frm As New UpdateSupplierForm(SupplierRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("SupplierGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function SelectRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim SupplierRow As SupplierView = BindingSource1.Current
            Dim CurrentSupplier As Supplier = (From x In DC.Suppliers Where x.RecordId.Equals(SupplierRow.RecordId) Select x).FirstOrDefault()
            GlobalSupplierLookupRecordId = SupplierRow.RecordId
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("SupplierGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
