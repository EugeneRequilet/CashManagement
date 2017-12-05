Imports System.Linq

Public Class BankingGrid

    Dim DC As BankingDataContext

    Public Sub LoadData()
        Try
            ' Dim SQL = "Select * From BankingView Order by Date Desc"
            Dim SQL = "Select * From BankingView Where Date >= '" &
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" &
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") &
                        "' Order by date"
            DC = New BankingDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of BankingView)(SQL)
        Catch ex As Exception
            MessageBox.Show("BankingGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("BankingGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim BankingViewRow As BankingView = BindingSource1.Current
            Dim Message = String.Format("Deleting Banking {0}.{1} Are you sure?", BankingViewRow.Date, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentBanking As Banking = (From x In DC.Bankings Where x.RecordId.Equals(BankingViewRow.RecordId) Select x).FirstOrDefault()
            DC.Bankings.DeleteOnSubmit(CurrentBanking)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("BankingGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim BankingRow As BankingView = BindingSource1.Current
            Using frm As New UpdateBankingForm(BankingRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("BankingGrid ChangeRow() Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
