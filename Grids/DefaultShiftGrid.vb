Imports System.Linq

Public Class DefaultShiftGrid

    Dim DC As DefaultShiftDataContext
    Dim DSVDC As DailyShiftViewDataContext
    Dim DailyShiftViewRow As DailyShiftView
    Dim SearchDefaultShiftDescription As String

    Public Sub LoadData()
        Try
            Dim SQL = "Select * From DefaultShiftView Order by Description"
            DC = New DefaultShiftDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of DefaultShiftView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DefaultShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("DefaultShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim DefaultShiftRow As DefaultShiftView = BindingSource1.Current

            SearchDefaultShiftDescription = DefaultShiftRow.Description
            If CheckIfDefaultInUse() = DialogResult.OK Then
                MessageBox.Show("'" & DefaultShiftRow.Description & "'" & " is used in a Daily Shift" & vbCrLf & vbCrLf & "This Default Shift will not be deleted", "In Use Error")
                Return DialogResult.Cancel
            End If

            Dim Message = String.Format("Deleting DefaultShift {0}.{1} Are you sure?", DefaultShiftRow.Description, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentDefaultShift As DefaultShift = (From x In DC.DefaultShifts Where x.RecordId.Equals(DefaultShiftRow.RecordId) Select x).FirstOrDefault()
            DC.DefaultShifts.DeleteOnSubmit(CurrentDefaultShift)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("DefaultShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If GlobalHideInsertAmendDelete = False Then
            If GlobalEmployeeIsType < GlobalAdministrator Then
                MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
            Else
                ChangeRow()
            End If
        End If
    End Sub

    Public Function ChangeRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim DefaultShiftRow As DefaultShiftView = BindingSource1.Current
            Using frm As New UpdateDefaultShiftForm(DefaultShiftRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("DefaultShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function SelectRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim DefaultShiftRow As DefaultShiftView = BindingSource1.Current
            Dim CurrentDefaultShift As DefaultShift = (From x In DC.DefaultShifts Where x.RecordId.Equals(DefaultShiftRow.RecordId) Select x).FirstOrDefault()
            GlobalDefaultShiftLookupRecordId = DefaultShiftRow.RecordId
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("DefaultShiftGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Function CheckIfDefaultInUse() As DialogResult
        Dim SQL As String
        SQL = "Select * From DailyShiftView Where Description = '" & SearchDefaultShiftDescription & "'"
        Try
            DSVDC = New DailyShiftViewDataContext
            DailyShiftViewBindingSource.DataSource = DSVDC.ExecuteQuery(Of DailyShiftView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyShiftView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        DailyShiftViewBindingSource.MoveFirst()
        Try
            DailyShiftViewRow = DailyShiftViewBindingSource.Current
        Catch ex As Exception
            'MessageBox.Show("DailyShiftView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        If DailyShiftViewRow Is Nothing Then Return DialogResult.Cancel
        Return DialogResult.OK
    End Function

End Class
