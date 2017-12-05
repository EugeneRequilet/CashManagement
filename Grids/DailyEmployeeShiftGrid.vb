Imports System.Linq

Public Class DailyEmployeeShiftGrid

    Dim DC As DailyShiftDataContext

    Public Sub LoadData()
        Try
            Dim SQL = "Select * From DailyEmployeeShiftView Where Date >= '" & _
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" & _
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
                        "' And ThisShiftEmployeeRecordId <> 0" & _
                        " Order by Date, ShiftDescription"
            DC = New DailyShiftDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of DailyEmployeeShiftView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyEmployeeShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("DailyEmployeeShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim DailyShiftRow As DailyEmployeeShiftView = BindingSource1.Current
            Dim Message = String.Format("Deleting DailyShift {0}.{1} Are you sure?", DailyShiftRow.Date & " " & DailyShiftRow.ShiftDescription, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentDailyShift As DailyShift = (From x In DC.DailyShifts Where x.RecordId.Equals(DailyShiftRow.RecordId) Select x).FirstOrDefault()
            DC.DailyShifts.DeleteOnSubmit(CurrentDailyShift)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("DailyEmployeeShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim DailyShiftRow As DailyEmployeeShiftView = BindingSource1.Current
            Using frm As New UpdateDailyEmployeeShiftForm(DailyShiftRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("DailyEmployeeShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function SelectRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim DailyShiftRow As DailyShiftView = BindingSource1.Current
            Dim CurrentDailyShift As DailyShift = (From x In DC.DailyShifts Where x.RecordId.Equals(DailyShiftRow.RecordId) Select x).FirstOrDefault()
            'GlobalDailyShiftLookupRecordId = DailyShiftRow.RecordId
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("DailyEmployeeShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
