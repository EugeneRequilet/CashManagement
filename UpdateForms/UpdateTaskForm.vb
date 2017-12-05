Public Class UpdateTaskForm

    Public RecordId As Integer

    Dim DC As TaskDataContext
    Dim TaskRow As Task

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub UpdateTaskForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New TaskDataContext
        BindingSource1.DataSource = From Task In DC.Tasks Where Task.RecordId = RecordId
        TaskRow = BindingSource1.Current
        If TaskRow Is Nothing Then
            TaskRow = New Task
            BindingSource1.AddNew()
            TaskRow = BindingSource1.Current
            setDefaults()
            Me.cboGroup.Select()
        End If
        setDropdowns()
        setNumericsOnScreens()
    End Sub

    Private Sub setDefaults()
        If TaskRow.GroupNumber = Nothing Then TaskRow.GroupNumber = 0
        If TaskRow.Number = Nothing Then TaskRow.Number = 0
        If TaskRow.EmployeeRecordId = Nothing OrElse TaskRow.EmployeeRecordId = 0 Then TaskRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
    End Sub

    Private Sub setDropdowns()
        cboGroup.Items.Clear()
        cboGroup.Items.Add("Daily")
        cboGroup.Items.Add("Weekly")
        cboGroup.Items.Add("Monthly")
        cboGroup.Items.Add("Other")
        cboGroup.SelectedIndex = TaskRow.GroupNumber
    End Sub

    Private Sub setNumericsOnScreens()
        txtNumber.EditValue = TaskRow.Number
    End Sub

    Private Function ValidateData() As DialogResult
        TaskRow.GroupNumber = cboGroup.SelectedIndex
        If TaskRow.EmployeeRecordId = Nothing OrElse TaskRow.EmployeeRecordId = 0 Then TaskRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
        If TaskRow.EmployeeRecordId < 1 Then Return DialogResult.Cancel

        'Dim Message = String.Format("ValidateData.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, EmployeeRow.Gender, EmployeeRow.MaritalStatus, EmployeeRow.DateStarted, EmployeeRow.NoOfDependants, EmployeeRow.Rate)
        'MsgBox(Message)

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
            MessageBox.Show("A Task Record already Exists for:" & vbCrLf & _
                            "Group:" & vbTab & vbTab & cboGroup.Text & vbCrLf & _
                            "Number:" & vbTab & vbTab & txtNumber.Text & vbCrLf & _
                            "Description:" & vbTab & txtDescription.Text & vbCrLf & vbCrLf & _
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

    Private Sub txtNumber_Load(sender As Object, e As EventArgs) Handles txtNumber.Validated
        TaskRow.Number = txtNumber.EditValue
    End Sub

End Class