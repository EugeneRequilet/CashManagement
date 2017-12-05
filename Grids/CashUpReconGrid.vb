Imports System.Linq

Public Class CashUpReconGrid

    Dim DC As CashupReconViewDataContext

    Public Sub LoadData()
        Try
            'Dim SQL = "Select * From CashUpReconView where CreditCardReconciled = 0 or CashDepReconciled = 0 or Skims1Reconciled = 0 or Skims2Reconciled = 0 or Skims3Reconciled = 0 Order by Date"
            'If GlobalUnreconciled = 1 Then SQL = "Select * From CashUpReconView  Order by Date"
            Dim SQL As String
            Dim StartDate As String = DateSerial(Year(Today), (Month(Today) - 2), 1).ToString("dd MMM yyyy")
            Select Case GlobalBankType
                Case 1
                    If GlobalUnreconciled = 0 Then
                        SQL = "Select * From CashUpReconView Where (CashDepReconciled = 0 And CashDeposited <> 0.0) " &
                                  " Or (Skims1Reconciled = 0 And DepositedSkim1 <> 0.0) " &
                                  " Or (Skims2Reconciled = 0 And DepositedSkim2 <> 0.0) " &
                                  " Or (Skims3Reconciled = 0 And DepositedSkim3 <> 0.0) " &
                                  " Order by Date"
                    Else
                        SQL = "Select * From CashUpReconView Where (Date >= '" & StartDate & "') And (CashDeposited <> 0.0 Or DepositedSkim1 <> 0.0 " &
                                  " Or DepositedSkim2 <> 0.0 Or DepositedSkim3 <> 0.0) Order by Date"
                    End If
                Case 2
                    If GlobalUnreconciled = 0 Then
                        SQL = "Select * From CashUpReconView Where (CreditCardReconciled = 0 And CreditCardDeposited <> 0.0) Order by Date"
                    Else
                        SQL = "Select * From CashUpReconView Where (Date >= '" & StartDate & "') And (CreditCardDeposited <> 0.0) Order by Date"
                    End If
                Case Else
                    If GlobalUnreconciled = 0 Then
                        SQL = "Select * From CashUpReconView Where CreditCardReconciled = 0 Or CashDepReconciled = 0" &
                                  " Or Skims1Reconciled = 0 Or Skims2Reconciled = 0 Or Skims3Reconciled = 0" &
                                  " Order by Date"
                    Else
                        SQL = "Select * From CashUpReconView Where (Date >= '" & StartDate & "') Order by Date"
                    End If
            End Select

            DC = New CashupReconViewDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of CashupReconView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashUpReconGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("CashUpReconGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim CashUpReconViewRow As CashupReconView = BindingSource1.Current
            Dim Message = String.Format("Deleting CashUpReconView {0}.{1} Are you sure?", CashUpReconViewRow.Date, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentCashUpReconView As CashupReconView = (From x In DC.CashupReconViews Where x.RecordId.Equals(CashUpReconViewRow.RecordId) Select x).FirstOrDefault()
            DC.CashupReconViews.DeleteOnSubmit(CurrentCashUpReconView)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("CashUpReconGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim CashUpReconViewRow As CashupReconView = BindingSource1.Current
            Using frm As New UpdateCashUpReconForm(CashUpReconViewRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
                LoadData()                      ' Added this because it is not refreshing the browse screen even though DialogResult = OK
            End Using
        Catch ex As Exception
            MessageBox.Show("CashUpReconGrid ChangeRow() Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
