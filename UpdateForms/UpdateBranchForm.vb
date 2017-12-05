Public Class UpdateBranchForm

    Public RecordId As Integer

    Dim DC As BranchDataContext
    Dim BranchRow As Branch

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub UpdateBranchForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New BranchDataContext
        BindingSource1.DataSource = From Branch In DC.Branches Where Branch.RecordId = RecordId
        BranchRow = BindingSource1.Current
        If BranchRow Is Nothing Then
            BranchRow = New Branch
            BindingSource1.AddNew()
            BranchRow = BindingSource1.Current
            setDefaults()
            Me.txtBranch.Select()
        End If
    End Sub

    Private Sub setDefaults()
        If BranchRow.EmployeeRecordId = Nothing OrElse BranchRow.EmployeeRecordId = 0 Then BranchRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        'Dim Message = String.Format("setDefaults.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, EmployeeRow.Gender, EmployeeRow.MaritalStatus, EmployeeRow.DateStarted, EmployeeRow.NoOfDependants, EmployeeRow.Rate)
        'MsgBox(Message)

    End Sub

    Private Function ValidateData() As DialogResult

        If txtBranch.Text = "" Then
            MsgBox("You must enter a Code.")
            txtBranch.Select()
            Return DialogResult.Cancel
        End If

        If txtDescription.Text = "" Then
            MsgBox("You must enter a Description.")
            txtDescription.Select()
            Return DialogResult.Cancel
        End If

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
            'MessageBox.Show("UpdateEmployeeForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("A Branch Record already Exists for:" & vbCrLf & vbCrLf &
                            "Branch Code:" & vbTab & txtBranch.Text & vbCrLf &
                            "Description:" & vbTab & txtDescription.Text & vbCrLf & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        BindingSource1.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

End Class