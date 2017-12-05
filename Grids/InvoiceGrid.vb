Imports System.Linq

Public Class InvoiceGrid

    Dim DC As InvoiceDataContext

    Public Sub LoadData()
        Try
            ' Dim SQL = "Select * From InvoiceView Order by Date Desc"
            Dim SQL = "Select * From InvoiceView Where Date >= '" & _
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" & _
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
                        "' Order by Date, DocumentTypeOrder"
            If GlobalSupplierLookupRecordId Then
                SQL = "Select * From InvoiceView Where Date >= '" & _
                            DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" & _
                            DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
                            "' And SupplierRecordId = " & GlobalSupplierLookupRecordId & _
                            " Order by Date, DocumentTypeOrder"
            End If
            DC = New InvoiceDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of InvoiceView)(SQL)
        Catch ex As Exception
            MessageBox.Show("InvoiceGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("InvoiceGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim InvoiceRow As InvoiceView = BindingSource1.Current
            Dim Message = String.Format("Deleting Invoice {0}.{1} Are you sure?", InvoiceRow.Date, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentInvoice As Invoice = (From x In DC.Invoices Where x.RecordId.Equals(InvoiceRow.RecordId) Select x).FirstOrDefault()
            DC.Invoices.DeleteOnSubmit(CurrentInvoice)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("InvoiceGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim InvoiceRow As InvoiceView = BindingSource1.Current
            Using frm As New UpdateInvoiceForm(InvoiceRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("InvoiceGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
