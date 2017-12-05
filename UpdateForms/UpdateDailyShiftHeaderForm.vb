Public Class UpdateDailyShiftHeaderForm

    Public RecordId As Integer

    Dim DC As DailyShiftHeaderDataContext
    Dim DailyShiftHeaderRow As DailyShiftHeader
    Dim InsertMode As Boolean = False

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New DailyShiftHeaderDataContext
        BindingSource1.DataSource = From DailyShiftHeader In DC.DailyShiftHeaders Where DailyShiftHeader.RecordId = RecordId
        DailyShiftHeaderRow = BindingSource1.Current
        If DailyShiftHeaderRow Is Nothing Then
            DailyShiftHeaderRow = New DailyShiftHeader
            BindingSource1.AddNew()
            DailyShiftHeaderRow = BindingSource1.Current
            setDefaults()
            Me.dteDate.Select()
            InsertMode = True
        End If
        setDropdowns()
        setNumericsOnScreens()
    End Sub

    Private Sub setDefaults()
        If DailyShiftHeaderRow.Date = Nothing OrElse DailyShiftHeaderRow.Date = Date.MinValue Then DailyShiftHeaderRow.Date = Today
        If DailyShiftHeaderRow.Shifts = Nothing Then DailyShiftHeaderRow.Shifts = 0
        If DailyShiftHeaderRow.DailyRateAdjustment = Nothing Then DailyShiftHeaderRow.DailyRateAdjustment = 0
        If DailyShiftHeaderRow.EmployeeRecordId = Nothing OrElse DailyShiftHeaderRow.EmployeeRecordId = 0 Then DailyShiftHeaderRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
    End Sub

    Private Sub setDropdowns()
        cboRateAdjustment.Items.Clear()
        cboRateAdjustment.Items.Add("None")
        cboRateAdjustment.Items.Add("Time And A Half")
        cboRateAdjustment.Items.Add("Double Time")
        cboRateAdjustment.SelectedIndex = DailyShiftHeaderRow.DailyRateAdjustment
    End Sub

    Private Sub setNumericsOnScreens()
        If InsertMode = False And GlobalEmployeeIsType < GlobalAdministrator Then dteDate.Enabled = False
        txtShifts.EditValue = DailyShiftHeaderRow.Shifts

        DailyShiftHeaderRow.DayOfWeek = DailyShiftHeaderRow.Date.DayOfWeek.ToString
        txtDayOfWeek.Text = DailyShiftHeaderRow.DayOfWeek
        txtShifts.Text = DailyShiftHeaderRow.Shifts
        If DailyShiftHeaderRow.DailyRateAdjustment = 0 And DailyShiftHeaderRow.DayOfWeek.ToUpper = "SUNDAY" Then
            DailyShiftHeaderRow.DailyRateAdjustment = 1
            cboRateAdjustment.SelectedIndex = DailyShiftHeaderRow.DailyRateAdjustment
        End If
    End Sub

    Private Function ValidateData() As DialogResult
        DailyShiftHeaderRow.DailyRateAdjustment = cboRateAdjustment.SelectedIndex
        If DailyShiftHeaderRow.Date = Nothing OrElse DailyShiftHeaderRow.Date = Date.MinValue Then DailyShiftHeaderRow.Date = Today
        DailyShiftHeaderRow.DayOfWeek = DailyShiftHeaderRow.Date.DayOfWeek.ToString
        DailyShiftHeaderRow.Shifts = 0

        If DailyShiftHeaderRow.DailyRateAdjustment = 0 And DailyShiftHeaderRow.DayOfWeek.ToUpper = "SUNDAY" Then
            DailyShiftHeaderRow.DailyRateAdjustment = 1
        End If

        'Dim Hours As TimeSpan = DailyShiftHeaderRow.EndTime - DailyShiftHeaderRow.StartTime

        'DailyShiftHeaderRow.Hours = Convert.ToDecimal(DailyShiftHeaderRow.EndTime - DailyShiftHeaderRow.StartTime)

        Return DialogResult.OK
    End Function

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("A Header for this Date already Exists: " & dteDate.Text & vbCrLf & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        BindingSource1.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub dteDate_Validated(sender As Object, e As EventArgs) Handles dteDate.Validated
        setNumericsOnScreens()
    End Sub

End Class