Public Class UpdateLeaveTakenForm

    Public RecordId As Integer

    Dim LTC As LeaveTakenDataContext
    Dim LeaveTakenRow As LeaveTaken
    Dim EDC As EmployeeDataContext
    Dim EmployeeRow As Employee

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub UpdateLeaveTakenForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        LTC = New LeaveTakenDataContext
        LeaveTakenBindingSource.DataSource = From LeaveTaken In LTC.LeaveTakens Where LeaveTaken.RecordId = RecordId
        LeaveTakenRow = LeaveTakenBindingSource.Current
        If LeaveTakenRow Is Nothing Then
            LeaveTakenRow = New LeaveTaken
            LeaveTakenBindingSource.AddNew()
            LeaveTakenRow = LeaveTakenBindingSource.Current
            setDefaults()
            ' Me.timeStartTime.Select()
        End If
        setDropdowns()
        txtDaysLeave.EditValue = LeaveTakenRow.Days
        setNumericsOnScreens()
        If LeaveTakenRow.LeaveTakenEmployeeRecordId > 0 Then
            GlobalEmployeeLookupRecordId = LeaveTakenRow.LeaveTakenEmployeeRecordId
            ReadEmployeeRecord()
        End If
    End Sub

    Private Sub setDefaults()
        If LeaveTakenRow.StartDate = Nothing OrElse LeaveTakenRow.StartDate = "" Then LeaveTakenRow.StartDate = Today()
        If LeaveTakenRow.EndDate = Nothing OrElse LeaveTakenRow.EndDate = "" Then LeaveTakenRow.EndDate = Today()
        If LeaveTakenRow.EmployeeRecordId = Nothing OrElse LeaveTakenRow.EmployeeRecordId = 0 Then LeaveTakenRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        If LeaveTakenRow.LeaveTakenEmployeeRecordId = Nothing Then LeaveTakenRow.LeaveTakenEmployeeRecordId = 0 ' LeaveEmployeeRecordId Selected RecordID
        If LeaveTakenRow.LeaveType = Nothing Then LeaveTakenRow.LeaveType = "Normal" ' LeaveType Selected Description
    End Sub

    Private Sub setDropdowns()
        cboLeaveType.Items.Clear()
        cboLeaveType.Items.Add("Normal")
        cboLeaveType.Items.Add("Sick")
        cboLeaveType.Items.Add("Unpaid")
        cboLeaveType.SelectedIndex = 0
        Select Case LeaveTakenRow.LeaveType
            Case "Unpaid"
                cboLeaveType.SelectedIndex = 2
            Case "Sick"
                cboLeaveType.SelectedIndex = 1
            Case Else
                cboLeaveType.SelectedIndex = 0
        End Select
    End Sub

    Private Sub setNumericsOnScreens()
        txtDaysLeave.EditValue = DateDiff(DateInterval.Day, LeaveTakenRow.StartDate, LeaveTakenRow.EndDate) + 1
    End Sub

    Private Sub btnSelectEmployee_Click(sender As Object, e As EventArgs) Handles btnSelectEmployee.Click
        GlobalEmployeeLookupRecordId = -1
        GlobalHideInsertAmendDelete = True
        Using frm As New BrowseEmployee
            frm.ShowDialog()
        End Using
        GlobalHideInsertAmendDelete = False
        ReadEmployeeRecord()
        LeaveTakenRow.LeaveTakenEmployeeRecordId = EmployeeRow.RecordId
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

    Private Function ValidateData() As DialogResult
        If LeaveTakenRow.StartDate = Nothing Then
            txtStartDate.Select()
            MsgBox("You must enter a Start Date for the Leave Taken.")
            Return DialogResult.Cancel
        End If
        If LeaveTakenRow.EndDate = Nothing Then
            txtEndDate.Select()
            MsgBox("You must enter an End Date for the Leave Taken.")
            Return DialogResult.Cancel
        End If
        If LeaveTakenRow.LeaveType Is Nothing Or LeaveTakenRow.LeaveType = "" Then
            cboLeaveType.Select()
            MsgBox("You must enter a Leave Type.")
            Return DialogResult.Cancel
        End If

        If LeaveTakenRow.LeaveTakenEmployeeRecordId = Nothing Or LeaveTakenRow.LeaveTakenEmployeeRecordId = 0 Then
            btnSelectEmployee.Select()
            MsgBox("You must enter an Employee for this Leave.")
            Return DialogResult.Cancel
        End If

        'Dim Hours As TimeSpan = LeaveTakenRow.EndTime - LeaveTakenRow.StartTime

        'LeaveTakenRow.Hours = Convert.ToDecimal(LeaveTakenRow.EndTime - LeaveTakenRow.StartTime)

        Return DialogResult.OK
    End Function

    Public Function SaveData() As DialogResult
        Try
            LeaveTakenBindingSource.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            LTC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("This Leave Taken already Exists for:" & vbCrLf &
                            "Start Date: " & vbTab & vbTab & txtStartDate.Text & vbCrLf &
                            "End Time: " & vbTab & txtEndDate.Text & vbCrLf & vbCrLf &
                            "Leave Type: " & vbTab & cboLeaveType.Text & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        LeaveTakenBindingSource.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtStartDate_Validated(sender As Object, e As EventArgs) Handles txtStartDate.Validated
        setNumericsOnScreens()
    End Sub

    Private Sub txtEndDate_Validated(sender As Object, e As EventArgs) Handles txtEndDate.Validated
        setNumericsOnScreens()
    End Sub

End Class