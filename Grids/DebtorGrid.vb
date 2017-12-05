Imports System.Linq

Public Class DebtorGrid

    Dim DC As CashUpDataContext

    Public Sub LoadData()
        Try
            ' Dim SQL = "Select * From CashUpView Order by Date Desc, Time Desc, EmployeeRecordId Desc"
            Dim SQL = "Select * From CashUpView Where Date >= '" &
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" &
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") &
                        "' And SalesType <> 0 Order by Date, RecordId"
            DC = New CashUpDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of CashupView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashUpGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("CashUpGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim CashUpRow As CashupView = BindingSource1.Current
            Dim Message = String.Format("Deleting CashUp {0}.{1} Are you sure?", CashUpRow.Date, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentCashUp As CashUp = (From x In DC.CashUps Where x.RecordId.Equals(CashUpRow.RecordId) Select x).FirstOrDefault()
            DC.CashUps.DeleteOnSubmit(CurrentCashUp)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("CashUpGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim CashUpRow As CashupView = BindingSource1.Current

            If (GlobalEmployeeIsType < GlobalCashier) And (GlobalLoginEmployeeRecordId <> CashUpRow.EmployeeRecordId) Then
                MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
            Else
                Using frm As New UpdateDebtorTransForm(CashUpRow.RecordId)
                    If frm.ShowDialog() = DialogResult.OK Then
                        LoadData()
                    Else
                        LoadData()
                    End If
                End Using
            End If

        Catch ex As Exception
            MessageBox.Show("CashUpGrid ChangeRow() Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
