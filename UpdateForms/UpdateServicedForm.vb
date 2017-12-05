Public Class UpdateServicedForm

    Public RecordId As Integer

    Dim DC As ServicedDataContext
    Dim ServicedRow As Serviced

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub UpdateServicedForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New ServicedDataContext
        BindingSource1.DataSource = From Serviced In DC.Serviceds Where Serviced.RecordId = RecordId
        ServicedRow = BindingSource1.Current
        If ServicedRow Is Nothing Then
            ServicedRow = New Serviced
            BindingSource1.AddNew()
            ServicedRow = BindingSource1.Current
            setDefaults()
            Me.dteDate.Select()
        End If
        setNumericsOnScreens()
    End Sub

    Private Sub setDefaults()
        If ServicedRow.Date = Nothing OrElse ServicedRow.Date = Date.MinValue Then ServicedRow.Date = Today
        If ServicedRow.Amount = Nothing Then ServicedRow.Amount = 0.0
        If ServicedRow.EmployeeRecordId = Nothing OrElse ServicedRow.EmployeeRecordId = 0 Then ServicedRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
        If ServicedRow.AssetRecordId = Nothing OrElse ServicedRow.AssetRecordId = 0 Then ServicedRow.AssetRecordId = GlobalAssetLookupRecordId

        'Dim Message = String.Format("setDefaults.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, ServicedRow.Gender, ServicedRow.MaritalStatus, ServicedRow.DateStarted, ServicedRow.NoOfDependants, ServicedRow.Rate)
        'MsgBox(Message)

    End Sub

    Private Sub setNumericsOnScreens()
        txtServiceAmount.EditValue = ServicedRow.Amount
    End Sub

    Private Sub browseButton_Click(sender As Object, e As EventArgs) Handles browseButton.Click
        txtFileAndLocation.Text = GetFileName(7, 3)            ' 1 *.rtf, 2 *.txt, 3 *.doc *.docx, 4 *.xls *.xlsx, 5 *.csv, 6 *.bmp *.jpg *.gif, 7 *.*
        If txtFileAndLocation.Text Is Nothing Or txtFileAndLocation.Text = "" Then Exit Sub
    End Sub

    Private Function ValidateData() As DialogResult

        If dteDate.Text = "" Then
            dteDate.Text = FormatDateTime(Today)
            ServicedRow.Date = Today
        End If

        If ServicedRow.Description Is Nothing Or ServicedRow.Description = "" Then
            txtDescription.Select()
            MsgBox("You must enter a Description.")
            Return DialogResult.Cancel
        End If

        'Dim Message = String.Format("ValidateData.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, ServicedRow.Gender, ServicedRow.MaritalStatus, ServicedRow.DateStarted, ServicedRow.NoOfDependants, ServicedRow.Rate)
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
            'MessageBox.Show("UpdateServicedForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("A Serviced Record already Exists for:" & vbCrLf &
                            "Date: " & vbTab & dteDate.Text & vbCrLf &
                            "Description: " & txtDescription.Text & vbCrLf & vbCrLf &
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

    Private Sub txtServiceAmount_Validated(sender As Object, e As EventArgs) Handles txtServiceAmount.Validated
        ServicedRow.Amount = txtServiceAmount.EditValue
    End Sub

    Private Sub OpenFileButton_Click(sender As Object, e As EventArgs) Handles OpenFileButton.Click
        If txtFileAndLocation.Text Is Nothing Or txtFileAndLocation.Text = "" Then Exit Sub
        System.Diagnostics.Process.Start(txtFileAndLocation.Text)
    End Sub

End Class