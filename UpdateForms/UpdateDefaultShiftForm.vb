Public Class UpdateDefaultShiftForm

    Public RecordId As Integer

    Dim DC As DefaultShiftDataContext
    Dim DefaultShiftRow As DefaultShift
    Dim DSVDC As DailyShiftViewDataContext
    Dim DailyShiftViewRow As DailyShiftView

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
    End Sub

    Private Function CheckIfDefaultInUse() As DialogResult
        Dim SQL As String
        SQL = "Select * From DailyShiftView Where Description = '" & DefaultShiftRow.Description & "'"
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

    Private Sub LoadData()
        DC = New DefaultShiftDataContext
        BindingSource1.DataSource = From DefaultShift In DC.DefaultShifts Where DefaultShift.RecordId = RecordId
        DefaultShiftRow = BindingSource1.Current
        If DefaultShiftRow Is Nothing Then
            DefaultShiftRow = New DefaultShift
            BindingSource1.AddNew()
            DefaultShiftRow = BindingSource1.Current
            setDefaults()
            Me.txtDescription.Select()
        End If
    End Sub

    Private Sub setDefaults()
        'If DefaultShiftRow.Hours = Nothing Then DefaultShiftRow.Hours = 0.0
        If DefaultShiftRow.StartTime = Nothing Then DefaultShiftRow.StartTime = "06:00"
        If DefaultShiftRow.EndTime = Nothing Then DefaultShiftRow.EndTime = "21:00"
        If DefaultShiftRow.EmployeeRecordId = Nothing OrElse DefaultShiftRow.EmployeeRecordId = 0 Then DefaultShiftRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        timeStartTime.Text = DefaultShiftRow.StartTime
        timeEndTime.Text = DefaultShiftRow.EndTime
    End Sub

    Private Function ValidateData() As DialogResult
        If DefaultShiftRow.Description Is Nothing Or DefaultShiftRow.Description = "" Then
            txtDescription.Select()
            MsgBox("You must enter a Description.")
            Return DialogResult.Cancel
        End If
        If DefaultShiftRow.StartTime = Nothing Then
            timeStartTime.Select()
            MsgBox("You must enter a Start Time for the Default Shift.")
            Return DialogResult.Cancel
        End If
        If DefaultShiftRow.EndTime = Nothing Then
            timeEndTime.Select()
            MsgBox("You must enter an End Time for the Default Shift.")
            Return DialogResult.Cancel
        End If

        'Dim Hours As TimeSpan = DefaultShiftRow.EndTime - DefaultShiftRow.StartTime

        'DefaultShiftRow.Hours = Convert.ToDecimal(DefaultShiftRow.EndTime - DefaultShiftRow.StartTime)

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
            MessageBox.Show("An Default Shift already Exists for:" & vbCrLf &
                            "Description: " & vbTab & vbTab & txtDescription.Text & vbCrLf & vbCrLf &
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

    'Private Sub timeStartTime_Validating(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles timeStartTime.Validating
    '    DefaultShiftRow.StartTime = timeStartTime.Value
    'End Sub

End Class