Imports System.Linq

Public Class DailyShiftHeaderGrid

    Dim DC As DailyShiftHeaderDataContext

    Public Sub LoadData()
        Try
            ' Dim SQL = "Select * From DailyShiftHeaderView Order by Date Desc"
            Dim SQL = "Select * From DailyShiftHeaderView Where Date >= '" & _
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" & _
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
                        "' Order by Date"
            DC = New DailyShiftHeaderDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of DailyShiftHeaderView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyShiftHeaderGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("DailyShiftHeaderGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim DailyShiftHeaderRow As DailyShiftHeaderView = BindingSource1.Current
            Dim Message = String.Format("Deleting DailyShiftHeader {0}.{1} Are you sure?", DailyShiftHeaderRow.Date, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentDailyShiftHeader As DailyShiftHeader = (From x In DC.DailyShiftHeaders Where x.RecordId.Equals(DailyShiftHeaderRow.RecordId) Select x).FirstOrDefault()
            DC.DailyShiftHeaders.DeleteOnSubmit(CurrentDailyShiftHeader)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("DailyShiftHeaderGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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
            Dim DailyShiftHeaderRow As DailyShiftHeaderView = BindingSource1.Current
            Using frm As New UpdateDailyShiftHeaderForm(DailyShiftHeaderRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("DailyShiftHeaderGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function SelectRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim DailyShiftHeaderRow As DailyShiftHeaderView = BindingSource1.Current
            Dim CurrentDailyShiftHeader As DailyShiftHeader = (From x In DC.DailyShiftHeaders Where x.RecordId.Equals(DailyShiftHeaderRow.RecordId) Select x).FirstOrDefault()
            GlobalDailyShiftHeaderLookupRecordId = DailyShiftHeaderRow.RecordId
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("DailyShiftHeaderGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
