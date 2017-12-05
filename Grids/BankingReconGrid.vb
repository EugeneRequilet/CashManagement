Imports System.Linq

Public Class BankingReconGrid

    Dim DC As BankingViewDataContext

    Public Sub LoadData()
        Try
            ' Dim SQL = "Select * From BankingView Where Reconciled = " & GlobalUnreconciled & " Order by Date desc, BankingTypeDesc, Number"

            Dim SQL As String
            Dim StartDate As String = DateSerial(Year(Today), (Month(Today) - 2), 1).ToString("dd MMM yyyy")
            Select Case GlobalBankType
                Case 1
                    If GlobalUnreconciled = 0 Then
                        SQL = "Select * From BankingView Where (Reconciled = 0 And BankingTypeDesc = 'Cash') Order by Date, BankingTypeDesc, Number"
                    Else
                        SQL = "Select * From BankingView Where (Date >= '" & StartDate & "') And (" &
                                "BankingTypeDesc = 'Cash') Order by Date, BankingTypeDesc, Number"
                    End If
                Case 2
                    If GlobalUnreconciled = 0 Then
                        SQL = "Select * From BankingView Where (Reconciled = 0 And BankingTypeDesc = 'Credit Card') Order by Date, BankingTypeDesc, Number"
                    Else
                        SQL = "Select * From BankingView Where (Date >= '" & StartDate & "') And (" &
                                "BankingTypeDesc = 'Credit Card') Order by Date, BankingTypeDesc, Number"
                    End If
                Case Else
                    If GlobalUnreconciled = 0 Then
                        SQL = "Select * From BankingView Where (Reconciled = 0) Order by Date, BankingTypeDesc, Number"
                    Else
                        SQL = "Select * From BankingView Where (Date >= '" & StartDate & "') Order by Date, BankingTypeDesc, Number"
                    End If
            End Select

            DC = New BankingViewDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of BankingView)(SQL)
        Catch ex As Exception
            MessageBox.Show("BankingReconGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("BankingReconGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim CurrentBankingView As BankingView = (From x In DC.BankingViews Where x.RecordId.Equals(BankingViewRow.RecordId) Select x).FirstOrDefault()
            DC.BankingViews.DeleteOnSubmit(CurrentBankingView)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("BankingReconGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim BankingViewRow As BankingView = BindingSource1.Current
            Using frm As New UpdateBankingReconForm(BankingViewRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("BankingReconGrid ChangeRow() Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
