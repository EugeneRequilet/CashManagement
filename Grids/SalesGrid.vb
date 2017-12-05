Imports System.Linq

Public Class SalesGrid

    Dim DC As SalesDataContext

    Public Sub LoadData()
        Try
            ' Dim SQL = "Select * From SalesView Order by Date Desc"
            Dim SQL = "Select * From SalesView Where Date >= '" & _
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" & _
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
                        "' Order by Date"
            DC = New SalesDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of SalesView)(SQL)
        Catch ex As Exception
            MessageBox.Show("SalesGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("SalesGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim SalesRow As SalesView = BindingSource1.Current
            Dim Message = String.Format("Deleting Sales {0}.{1} Are you sure?", SalesRow.Date, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentSales As Sales = (From x In DC.Sales Where x.RecordId.Equals(SalesRow.RecordId) Select x).FirstOrDefault()
            DC.Sales.DeleteOnSubmit(CurrentSales)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("SalesGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim SaleRow As SalesView = BindingSource1.Current
            Using frm As New UpdateSalesForm(SaleRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("SalesGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
