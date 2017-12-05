Public Class BrowseDailyShift

    Dim DSDC As DailyShiftDataContext
    Dim DailyShiftRow As DailyShift
    Dim DSVDC As DailyShiftViewDataContext
    Dim DailyShiftViewRow As DailyShiftView
    Dim DSHDC As DailyShiftHeaderDataContext
    Dim DailyShiftHeaderRow As DailyShiftHeader

    Private Sub btnBrowseHeaderDate_Click(sender As Object, e As EventArgs) Handles btnBrowseHeaderDate.Click
        GlobalDailyShiftHeaderLookupRecordId = -1
        Using frm As New BrowseDailyShiftHeader
            frm.ShowDialog()
        End Using
        UpdateDailyShiftHeaderRequestedRecord()
        Form_Load(sender, e)
    End Sub

    Private Sub UpdateDailyShiftHeaderRequestedRecord()
        DSHDC = New DailyShiftHeaderDataContext
        DailyShiftHeaderBindingSource.DataSource = From DailyShiftHeader In DSHDC.DailyShiftHeaders Where DailyShiftHeader.RecordId = GlobalDailyShiftHeaderLookupRecordId
        DailyShiftHeaderRow = DailyShiftHeaderBindingSource.Current
        If DailyShiftHeaderRow Is Nothing Then
            'MsgBox("No Daily Shift Header Selected")
            Me.Close()
            Exit Sub
        End If

        DailyShiftHeaderRow.Shifts = 0
        ' Calculate the DailyShifts for today
        Dim CurrentRecordId As Integer
        Dim SQLString As String = "SELECT * From DailyShiftView Where DailyShiftView.Date = '" & Format(DailyShiftHeaderRow.Date, "dd MMMM yyyy") & "'"
        Try
            Dim SQL = SQLString
            DSVDC = New DailyShiftViewDataContext
            DailyShiftViewBindingSource.DataSource = DSVDC.ExecuteQuery(Of DailyShiftView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyShiftView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        DailyShiftViewBindingSource.MoveFirst()
        Do
            Try
                DailyShiftViewRow = DailyShiftViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If DailyShiftViewRow IsNot Nothing Then
                If CurrentRecordId = DailyShiftViewRow.RecordId Then Exit Do
                CurrentRecordId = DailyShiftViewRow.RecordId
                DailyShiftHeaderRow.Shifts += 1
            End If
            DailyShiftViewBindingSource.MoveNext()
        Loop
        DailyShiftHeaderBindingSource.EndEdit()
        DSHDC.SubmitChanges()
        txtHeaderShifts.EditValue = DailyShiftHeaderRow.Shifts
        txtHeaderDate.Text = DailyShiftHeaderRow.Date
        txtHeaderDayOfWeek.Text = DailyShiftHeaderRow.DayOfWeek
        Select Case DailyShiftHeaderRow.DailyRateAdjustment
            Case 0
                txtRateAdjustment.Text = "None"
            Case 1
                txtRateAdjustment.Text = "Time And A Half"
            Case 2
                txtRateAdjustment.Text = "Double Time"
        End Select
        txtHeaderMemo.Text = DailyShiftHeaderRow.Memo
        If txtHeaderDate.Text = "" Then
            CopyShiftButton.Visible = False
            NextButton.Visible = False
        Else
            CopyShiftButton.Visible = True
            NextButton.Visible = True
        End If
    End Sub

    Private Sub BrowseDailyShift_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Remember to set the browse KeyPreview to TRUE
        Select Case e.KeyCode
            Case Keys.Insert
                InsertButton_Click(Nothing, Nothing)
            Case Keys.Enter
                ChangeButton_Click(Nothing, Nothing)
            Case Keys.Delete
                DeleteButton_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DailyShiftGrid1.LoadData()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalManager Then
            MessageBox.Show("You are not the Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            DailyShiftGrid1.DeleteRow()
            UpdateDailyShiftHeaderRequestedRecord()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not the Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            DailyShiftGrid1.ChangeRow()
            UpdateDailyShiftHeaderRequestedRecord()
        End If
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not the Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New UpdateDailyShiftForm(-1)
                frm.ShowDialog()
                DailyShiftGrid1.LoadData()
                UpdateDailyShiftHeaderRequestedRecord()
            End Using
        End If
    End Sub

    Private Sub SelectButton_Click(sender As Object, e As EventArgs)
        DailyShiftGrid1.SelectRow()
        Me.Close()
    End Sub

    Private Sub CopyShiftButton_Click(sender As Object, e As EventArgs) Handles CopyShiftButton.Click
        Using frm As New SelectDateForm
            frm.ShowDialog()
        End Using
        If GlobalSelectedDate <> Nothing Then
            Dim CurrentRecordId As Integer
            Dim SQLString As String = "Select * From DailyShiftView Where Date = '" & Format(GlobalSelectedDate, "dd MMM yyyy") & "'"
            Try
                Dim SQL = SQLString
                DSVDC = New DailyShiftViewDataContext
                DailyShiftViewBindingSource.DataSource = DSVDC.ExecuteQuery(Of DailyShiftView)(SQL)
            Catch ex As Exception
                MessageBox.Show("DailyShiftView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
                Exit Sub
            End Try

            ' Loop through the data to total the appropriate fields

            DailyShiftViewBindingSource.MoveFirst()
            Do
                Try
                    DailyShiftViewRow = DailyShiftViewBindingSource.Current
                Catch ex As Exception
                    Exit Do
                End Try
                If DailyShiftViewRow IsNot Nothing Then
                    If CurrentRecordId = DailyShiftViewRow.RecordId Then Exit Do
                    CurrentRecordId = DailyShiftViewRow.RecordId

                    If DailyShiftViewRow.DefaultShiftRecordId = Nothing Or DailyShiftViewRow.DefaultShiftRecordId = 0 Then Exit Do
                    If DailyShiftViewRow.StartTime = Nothing Then Exit Do
                    If DailyShiftViewRow.EndTime = Nothing Then Exit Do

                    ' Add the Daily Shift

                    DSDC = New DailyShiftDataContext
                    DailyShiftBindingSource.DataSource = From DailyShift In DSDC.DailyShifts Where DailyShift.RecordId = -1
                    DailyShiftRow = New DailyShift
                    DailyShiftBindingSource.AddNew()
                    DailyShiftRow = DailyShiftBindingSource.Current

                    DailyShiftRow.RecordId = 0
                    DailyShiftRow.DailyShiftHeaderRecordId = DailyShiftHeaderRow.RecordId
                    DailyShiftRow.Date = DailyShiftHeaderRow.Date

                    DailyShiftRow.DefaultShiftRecordId = DailyShiftViewRow.DefaultShiftRecordId
                    DailyShiftRow.StartTime = DailyShiftViewRow.StartTime
                    DailyShiftRow.EndTime = DailyShiftViewRow.EndTime
                    If GlobalIncludeEmployees = 0 Then
                        DailyShiftRow.ThisShiftEmployeeRecordId = 0
                    Else
                        DailyShiftRow.ThisShiftEmployeeRecordId = DailyShiftViewRow.ThisShiftEmployeeRecordId
                    End If
                    DailyShiftRow.EmployeeStartTime = DailyShiftRow.StartTime
                    DailyShiftRow.EmployeeEndTime = DailyShiftRow.EndTime
                    If DailyShiftRow.ClockStartTime = Nothing Then DailyShiftRow.ClockStartTime = New DateTime(2000, 1, 1, 0, 0, 0, 0)
                    If DailyShiftRow.ClockEndTime = Nothing Then DailyShiftRow.ClockEndTime = New DateTime(2000, 1, 1, 0, 0, 0, 0)
                    DailyShiftRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

                    Try
                        DailyShiftBindingSource.EndEdit()
                        DSDC.SubmitChanges()
                    Catch ex As Exception
                        MessageBox.Show("A Daily Shift already Exists for:" & vbCrLf &
                                        "Date: " & vbTab & vbTab & DailyShiftViewRow.Date & vbCrLf &
                                        "Description: " & vbTab & DailyShiftViewRow.ShiftDescription & vbCrLf &
                                        "Please try again.", "Duplicate Key")
                    End Try
                End If
                DailyShiftViewBindingSource.MoveNext()
            Loop
            DailyShiftGrid1.LoadData()
            UpdateDailyShiftHeaderRequestedRecord()
        End If
    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click

        Dim SQLString As String = "SELECT * From DailyShiftHeader Where DailyShiftHeader.Date > '" & Format(DailyShiftHeaderRow.Date, "dd MMMM yyyy") & "' Order By Date"
        Try
            Dim SQL = SQLString
            DSHDC = New DailyShiftHeaderDataContext
            DailyShiftHeaderBindingSource.DataSource = DSHDC.ExecuteQuery(Of DailyShiftHeader)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyShiftHeader Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        DailyShiftHeaderBindingSource.MoveFirst()
        Try
            DailyShiftHeaderRow = DailyShiftHeaderBindingSource.Current
            If DailyShiftHeaderRow IsNot Nothing Then
                GlobalDailyShiftHeaderLookupRecordId = DailyShiftHeaderRow.RecordId
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        UpdateDailyShiftHeaderRequestedRecord()
        Form_Load(sender, e)
    End Sub

    'Private Sub ExcelButton_Click(sender As Object, e As EventArgs)
    '    Using frm As New PrintDailyShiftForm
    '        frm.ShowDialog()
    '    End Using
    'End Sub

End Class