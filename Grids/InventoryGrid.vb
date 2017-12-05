Imports System.Linq

Public Class InventoryGrid
    Dim DC As InventoryDataContext

    Public Sub LoadData()
        Dim SQL As String
        Try
            'SQL = "Select * From InventoryView  Order by Description"
            'If GlobalSupplierLookupRecordId Then SQL = "Select * From InventoryView Where SupplierId = " & GlobalSupplierLookupRecordId & "  Order by Description"
            'If GlobalFilterString <> "" Then SQL = "Select * From InventoryView Where Description like '%" & GlobalFilterString & "%'  Order by Description"
            'If GlobalSupplierLookupRecordId And GlobalFilterString <> "" Then
            '    SQL = "Select * From InventoryView Where SupplierId = " & GlobalSupplierLookupRecordId & " And Description like '%" & GlobalFilterString & "%'  Order by Description"
            'End If

            SQL = "Select * From InventoryView"
            If GlobalSupplierLookupRecordId <> 0 Or GlobalShowInactiveInventory = False Or GlobalFilterString <> "" Then SQL = SQL & " Where"
            If GlobalSupplierLookupRecordId Then
                SQL = SQL & " SupplierId = " & GlobalSupplierLookupRecordId
                If GlobalShowInactiveInventory = False Or GlobalFilterString <> "" Then SQL = SQL & " And"
            End If
            If GlobalShowInactiveInventory = False Then
                SQL = SQL & " InactiveInventory <> 1"
                If GlobalFilterString <> "" Then SQL = SQL & " And"
            End If
            If GlobalFilterString <> "" Then SQL = SQL & " Description like '%" & GlobalFilterString & "%'"
            SQL = SQL & " Order by Description"

            DC = New InventoryDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of InventoryView)(SQL)
        Catch ex As Exception
            MessageBox.Show("InventoryGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("InventoryGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim InventoryRow As InventoryView = BindingSource1.Current
            Dim Message = String.Format("Deleting Inventory {0}.{1} Are you sure?", InventoryRow.Description, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentInventory As Inventory = (From x In DC.Inventories Where x.RecordId.Equals(InventoryRow.RecordId) Select x).FirstOrDefault()
            DC.Inventories.DeleteOnSubmit(CurrentInventory)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("InventoryGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim InventoryRow As InventoryView = BindingSource1.Current
            Using frm As New UpdateInventoryForm(InventoryRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("InventoryGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function SelectRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim InventoryRow As InventoryView = BindingSource1.Current
            Dim CurrentInventory As Inventory = (From x In DC.Inventories Where x.RecordId.Equals(InventoryRow.RecordId) Select x).FirstOrDefault()
            GlobalInventoryLookupRecordId = InventoryRow.RecordId
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("InventoryGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
