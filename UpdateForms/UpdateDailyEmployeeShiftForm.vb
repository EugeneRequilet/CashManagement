Public Class UpdateDailyEmployeeShiftForm

    Public RecordId As Integer

    Dim DSDC As DailyShiftDataContext
    Dim DailyShiftRow As DailyShift
    Dim DSHDC As DailyShiftHeaderDataContext
    Dim DailyShiftHeaderRow As DailyShiftHeader
    Dim SDC As DefaultShiftDataContext
    Dim DefaultShiftRow As DefaultShift
    Dim EDC As EmployeeDataContext
    Dim EmployeeRow As Employee

    Dim TimeTest As Date

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
        Setrights()
    End Sub

    Private Sub Setrights()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            dteDate.Enabled = False
            btnSelectEmployee.Enabled = False
            btnDefaultShift.Enabled = False
        Else
            dteDate.Enabled = True
            btnSelectEmployee.Enabled = True
            btnDefaultShift.Enabled = True
            timeClockStartTime.Enabled = True
            timeClockEndTime.Enabled = True
            lblShiftStartTime.Visible = True
            timeShiftStartTime.Visible = True
            lblShiftEndTime.Visible = True
            timeShiftEndTime.Visible = True
        End If
        If GlobalEmployeeIsType < GlobalCashier Then
            ' timeEmployeeStartTime.Enabled = False
            ' timeEmployeeEndTime.Enabled = False
        Else
            ' timeEmployeeStartTime.Enabled = True
            ' timeEmployeeEndTime.Enabled = True
        End If
    End Sub

    Private Sub LoadData()
        DSDC = New DailyShiftDataContext
        DailyShiftBindingSource.DataSource = From DailyShift In DSDC.DailyShifts Where DailyShift.RecordId = RecordId
        DailyShiftRow = DailyShiftBindingSource.Current
        If DailyShiftRow Is Nothing Then
            DailyShiftRow = New DailyShift
            DailyShiftBindingSource.AddNew()
            DailyShiftRow = DailyShiftBindingSource.Current
            setDefaults()
            ' Me.timeStartTime.Select()
        End If
        setNumericsOnScreens()
        If DailyShiftRow.ClockStartTime = New DateTime(2000, 1, 1, 0, 0, 0, 0) Then
            btnClockIn.Visible = True
            btnClockOut.Visible = False
        Else
            btnClockIn.Visible = False
            If DailyShiftRow.ClockEndTime = New DateTime(2000, 1, 1, 0, 0, 0, 0) Then
                btnClockOut.Visible = True
            Else
                btnClockOut.Visible = False
            End If
        End If
    End Sub

    Private Sub setDefaults()
        GetDailyShiftHeader()
        If DailyShiftRow.DailyShiftHeaderRecordId = Nothing OrElse DailyShiftRow.DailyShiftHeaderRecordId = 0 Then DailyShiftRow.DailyShiftHeaderRecordId = DailyShiftHeaderRow.RecordId
        If DailyShiftRow.Date = Nothing OrElse DailyShiftRow.Date = "" Then DailyShiftRow.Date = DailyShiftHeaderRow.Date
        If DailyShiftRow.EmployeeRecordId = Nothing OrElse DailyShiftRow.EmployeeRecordId = 0 Then DailyShiftRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        If DailyShiftRow.DefaultShiftRecordId = Nothing Then DailyShiftRow.DefaultShiftRecordId = 0 ' DefaultShift Selected Description
        If DailyShiftRow.StartTime = Nothing Then DailyShiftRow.StartTime = DateTime.Now ' DefaultShift Selected start time
        If DailyShiftRow.EndTime = Nothing Then DailyShiftRow.EndTime = DailyShiftRow.StartTime ' DefaultShift Selected end time

        If DailyShiftRow.ThisShiftEmployeeRecordId = Nothing Then DailyShiftRow.ThisShiftEmployeeRecordId = 0
        If DailyShiftRow.EmployeeStartTime = Nothing Then DailyShiftRow.EmployeeStartTime = DailyShiftRow.StartTime
        If DailyShiftRow.EmployeeEndTime = Nothing Then DailyShiftRow.EmployeeEndTime = DailyShiftRow.EndTime
        If DailyShiftRow.ClockStartTime = Nothing Then DailyShiftRow.ClockStartTime = New DateTime(2000, 1, 1, 0, 0, 0, 0)
        If DailyShiftRow.ClockEndTime = Nothing Then DailyShiftRow.ClockEndTime = New DateTime(2000, 1, 1, 0, 0, 0, 0)
    End Sub

    Private Sub GetDailyShiftHeader()
        Dim SQLString As String = "Select * From DailyShiftHeader Where RecordId = " & GlobalDailyShiftHeaderLookupRecordId
        Try
            Dim SQL = SQLString
            DSHDC = New DailyShiftHeaderDataContext
            DailyShiftHeaderBindingSource.DataSource = DSHDC.ExecuteQuery(Of DailyShiftHeader)(SQL)
            DailyShiftHeaderRow = DailyShiftHeaderBindingSource.Current
        Catch ex As Exception
            MessageBox.Show("Retrieving DailyShiftHeader Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Me.Close()
        End Try
    End Sub

    Private Sub setNumericsOnScreens()
        If DailyShiftRow.ThisShiftEmployeeRecordId > 0 Then
            GlobalEmployeeLookupRecordId = DailyShiftRow.ThisShiftEmployeeRecordId
            ReadEmployeeRecord()
        End If
        If DailyShiftRow.DefaultShiftRecordId > 0 Then
            GlobalDefaultShiftLookupRecordId = DailyShiftRow.DefaultShiftRecordId
            ReadDefaultShiftRecord()
        End If
        ' txtQuantity.EditValue = AdjustmentTransactionRow.Quantity
    End Sub

    Private Sub btnSelectEmployee_Click(sender As Object, e As EventArgs) Handles btnSelectEmployee.Click
        GlobalEmployeeLookupRecordId = -1
        GlobalHideInsertAmendDelete = True
        Using frm As New BrowseEmployee
            frm.ShowDialog()
        End Using
        GlobalHideInsertAmendDelete = False
        ReadEmployeeRecord()
        DailyShiftRow.ThisShiftEmployeeRecordId = EmployeeRow.RecordId
        DailyShiftRow.EmployeeStartTime = DailyShiftRow.StartTime
        DailyShiftRow.EmployeeEndTime = DailyShiftRow.EndTime
        If DailyShiftRow.ClockStartTime = Nothing Then DailyShiftRow.ClockStartTime = New DateTime(2000, 1, 1, 0, 0, 0, 0)
        If DailyShiftRow.ClockEndTime = Nothing Then DailyShiftRow.ClockEndTime = New DateTime(2000, 1, 1, 0, 0, 0, 0)
    End Sub

    Private Sub ReadEmployeeRecord()
        EDC = New EmployeeDataContext
        EmployeeBindingSource.DataSource = From Employee In EDC.Employees Where Employee.RecordId = GlobalEmployeeLookupRecordId
        EmployeeRow = EmployeeBindingSource.Current
        If EmployeeRow Is Nothing Then
            MsgBox("No Employee Selected")
            Me.Close()
        End If
        txtEmployeeName.Text = LTrim(EmployeeRow.FirstName & " " & EmployeeRow.Surname)
    End Sub

    Private Sub btnDefaultShift_Click(sender As Object, e As EventArgs) Handles btnDefaultShift.Click
        GlobalDefaultShiftLookupRecordId = -1
        GlobalHideInsertAmendDelete = True
        Using frm As New BrowseDefaultShift
            frm.ShowDialog()
        End Using
        GlobalHideInsertAmendDelete = False
        ReadDefaultShiftRecord()
        DailyShiftRow.DefaultShiftRecordId = DefaultShiftRow.RecordId
        DailyShiftRow.StartTime = DefaultShiftRow.StartTime
        DailyShiftRow.EndTime = DefaultShiftRow.EndTime

        DailyShiftRow.EmployeeStartTime = DailyShiftRow.StartTime
        DailyShiftRow.EmployeeEndTime = DailyShiftRow.EndTime
        If DailyShiftRow.ClockStartTime = Nothing Then DailyShiftRow.ClockStartTime = New DateTime(2000, 1, 1, 0, 0, 0, 0)
        If DailyShiftRow.ClockEndTime = Nothing Then DailyShiftRow.ClockEndTime = New DateTime(2000, 1, 1, 0, 0, 0, 0)
    End Sub

    Private Sub ReadDefaultShiftRecord()
        SDC = New DefaultShiftDataContext
        DefaultShiftBindingSource.DataSource = From DefaultShift In SDC.DefaultShifts Where DefaultShift.RecordId = GlobalDefaultShiftLookupRecordId
        DefaultShiftRow = DefaultShiftBindingSource.Current
        If DefaultShiftRow Is Nothing Then
            MsgBox("No Default Shift Selected")
            Me.Close()
        End If
        txtDescription.Text = DefaultShiftRow.Description
    End Sub

    Private Function ValidateData() As DialogResult
        If DailyShiftRow.ThisShiftEmployeeRecordId = Nothing Or DailyShiftRow.ThisShiftEmployeeRecordId = 0 Then
            txtEmployeeName.Select()
            MsgBox("You must Select an Employee.")
            Return DialogResult.Cancel
        End If
        If DailyShiftRow.DefaultShiftRecordId = Nothing Or DailyShiftRow.DefaultShiftRecordId = 0 Then
            txtDescription.Select()
            MsgBox("You must Select a Shift.")
            Return DialogResult.Cancel
        End If
        If DailyShiftRow.EmployeeStartTime = Nothing Then
            timeEmployeeStartTime.Select()
            MsgBox("You must enter a Start Time for the Default Shift.")
            Return DialogResult.Cancel
        End If
        If DailyShiftRow.EmployeeEndTime = Nothing Then
            timeEmployeeEndTime.Select()
            MsgBox("You must enter an End Time for the Default Shift.")
            Return DialogResult.Cancel
        End If

        SetClockInTime()
        SetClockOutTime()

        If DailyShiftRow.EmployeeStartTime.TimeOfDay < DailyShiftRow.StartTime.TimeOfDay Then
            DailyShiftRow.EmployeeStartTime = DailyShiftRow.StartTime
        End If
        If DailyShiftRow.EmployeeEndTime.TimeOfDay > DailyShiftRow.EndTime.TimeOfDay Then
            DailyShiftRow.EmployeeEndTime = DailyShiftRow.EndTime
        End If
        If DailyShiftRow.EmployeeStartTime.TimeOfDay > DailyShiftRow.EndTime.TimeOfDay Then
            DailyShiftRow.EmployeeStartTime = DailyShiftRow.EndTime
        End If
        If DailyShiftRow.EmployeeEndTime.TimeOfDay < DailyShiftRow.StartTime.TimeOfDay Then
            DailyShiftRow.EmployeeEndTime = DailyShiftRow.StartTime
        End If

        'Dim Hours As TimeSpan = DailyShiftRow.EndTime - DailyShiftRow.StartTime

        'DailyShiftRow.Hours = Convert.ToDecimal(DailyShiftRow.EndTime - DailyShiftRow.StartTime)

        Return DialogResult.OK
    End Function

    Public Function SaveData() As DialogResult
        Try
            DailyShiftBindingSource.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            DSDC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("A Daily Employee Shift already Exists for:" & vbCrLf &
                            "Date: " & vbTab & vbTab & dteDate.Text & vbCrLf &
                            "Description: " & vbTab & txtDescription.Text & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        DailyShiftBindingSource.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub btnClockIn_Click(sender As Object, e As EventArgs) Handles btnClockIn.Click
        If GlobalLoginEmployeeRecordId = DailyShiftRow.ThisShiftEmployeeRecordId Then
            If DailyShiftRow.ClockStartTime = New DateTime(2000, 1, 1, 0, 0, 0, 0) Then
                DailyShiftRow.ClockStartTime = DateTime.Now
                SetClockInTime()
            End If
        Else
            MessageBox.Show("You have to Login under your own name in order to Clock In" & vbCrLf & vbCrLf &
                        "Press OK to Continue.", "Incorrect User")
        End If
        btnClockIn.Visible = False
        Setrights()
    End Sub

    Private Sub SetClockInTime()
        If DailyShiftRow.ClockStartTime <> New DateTime(2000, 1, 1, 0, 0, 0, 0) Then
            DailyShiftRow.EmployeeStartTime = DailyShiftRow.StartTime
            Dim TempYear = DailyShiftRow.ClockStartTime.Year
            Dim TempMonth = DailyShiftRow.ClockStartTime.Month
            Dim TempDay = DailyShiftRow.ClockStartTime.Day
            Dim TempHours = DailyShiftRow.ClockStartTime.Hour
            Dim TempMinutes = DailyShiftRow.ClockStartTime.Minute
            DailyShiftRow.ClockStartTime = New DateTime(TempYear, TempMonth, TempDay, TempHours, TempMinutes, 0, 0)
            If DailyShiftRow.ClockStartTime.TimeOfDay > DailyShiftRow.EmployeeStartTime.TimeOfDay Then
                If TempMinutes <= 15 Then TempMinutes = 15
                If TempMinutes > 15 And TempMinutes <= 30 Then TempMinutes = 30
                If TempMinutes > 30 And TempMinutes <= 45 Then TempMinutes = 45
                If TempMinutes > 45 Then
                    TempHours += 1
                    TempMinutes = 0
                End If
                DailyShiftRow.EmployeeStartTime = New DateTime(TempYear, TempMonth, TempDay, TempHours, TempMinutes, 0, 0)
            End If
        End If
    End Sub

    Private Sub btnClockOut_Click(sender As Object, e As EventArgs) Handles btnClockOut.Click
        If GlobalLoginEmployeeRecordId = DailyShiftRow.ThisShiftEmployeeRecordId Then
            If DailyShiftRow.ClockEndTime = New DateTime(2000, 1, 1, 0, 0, 0, 0) Then
                DailyShiftRow.ClockEndTime = DateTime.Now
                SetClockOutTime()
            End If
        Else
            MessageBox.Show("You have to Login under your own name in order to Clock Out" & vbCrLf & vbCrLf &
                        "Press OK to Continue.", "Incorrect User")
        End If
        btnClockOut.Visible = False
        Setrights()
    End Sub

    Private Sub SetClockOutTime()
        If DailyShiftRow.ClockEndTime <> New DateTime(2000, 1, 1, 0, 0, 0, 0) Then
            DailyShiftRow.EmployeeEndTime = DailyShiftRow.EndTime
            Dim TempYear = DailyShiftRow.ClockEndTime.Year
            Dim TempMonth = DailyShiftRow.ClockEndTime.Month
            Dim TempDay = DailyShiftRow.ClockEndTime.Day
            Dim TempHours = DailyShiftRow.ClockEndTime.Hour
            Dim TempMinutes = DailyShiftRow.ClockEndTime.Minute
            DailyShiftRow.ClockEndTime = New DateTime(TempYear, TempMonth, TempDay, TempHours, TempMinutes, 0, 0)
            If DailyShiftRow.ClockEndTime.TimeOfDay < DailyShiftRow.EmployeeEndTime.TimeOfDay Then
                If TempMinutes < 15 Then TempMinutes = 0
                If TempMinutes >= 15 And TempMinutes < 30 Then TempMinutes = 15
                If TempMinutes >= 30 And TempMinutes < 45 Then TempMinutes = 30
                If TempMinutes >= 45 Then TempMinutes = 45
                DailyShiftRow.EmployeeEndTime = New DateTime(TempYear, TempMonth, TempDay, TempHours, TempMinutes, 0, 0)
            End If
        End If
    End Sub

End Class