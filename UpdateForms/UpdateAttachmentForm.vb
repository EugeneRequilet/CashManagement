Public Class UpdateAttachmentForm

    Public RecordId As Integer

    Dim DC As AttachmentDataContext
    Dim AttachmentRow As Attachment

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub UpdateAttachmentForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New AttachmentDataContext
        BindingSource1.DataSource = From Attachment In DC.Attachments Where Attachment.RecordId = RecordId
        AttachmentRow = BindingSource1.Current
        If AttachmentRow Is Nothing Then
            AttachmentRow = New Attachment
            BindingSource1.AddNew()
            AttachmentRow = BindingSource1.Current
            setDefaults()
            Me.dteDate.Select()
        End If
    End Sub

    Private Sub setDefaults()
        If AttachmentRow.Date = Nothing OrElse AttachmentRow.Date = Date.MinValue Then AttachmentRow.Date = Today
        If AttachmentRow.EmployeeRecordId = Nothing OrElse AttachmentRow.EmployeeRecordId = 0 Then AttachmentRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
        If AttachmentRow.AssetRecordId = Nothing OrElse AttachmentRow.AssetRecordId = 0 Then AttachmentRow.AssetRecordId = GlobalAssetLookupRecordId

        'Dim Message = String.Format("setDefaults.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, AttachmentRow.Gender, AttachmentRow.MaritalStatus, AttachmentRow.DateStarted, AttachmentRow.NoOfDependants, AttachmentRow.Rate)
        'MsgBox(Message)

    End Sub

    Private Sub browseButton_Click(sender As Object, e As EventArgs) Handles browseButton.Click
        txtFileAndLocation.Text = GetFileName(7, 3)            ' 1 *.rtf, 2 *.txt, 3 *.doc *.docx, 4 *.xls *.xlsx, 5 *.csv, 6 *.bmp *.jpg *.gif, 7 *.*
        If txtFileAndLocation.Text Is Nothing Or txtFileAndLocation.Text = "" Then Exit Sub
    End Sub

    Private Function ValidateData() As DialogResult

        If dteDate.Text = "" Then
            dteDate.Text = FormatDateTime(Today)
            AttachmentRow.Date = Today
        End If

        If AttachmentRow.Description Is Nothing Or AttachmentRow.Description = "" Then
            txtDescription.Select()
            MsgBox("You must enter a Description.")
            Return DialogResult.Cancel
        End If

        If AttachmentRow.FileAndLocation Is Nothing Or AttachmentRow.FileAndLocation = "" Then
            txtFileAndLocation.Select()
            MsgBox("You must select the File and Location.")
            Return DialogResult.Cancel
        End If

        'Dim Message = String.Format("ValidateData.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, AttachmentRow.Gender, AttachmentRow.MaritalStatus, AttachmentRow.DateStarted, AttachmentRow.NoOfDependants, AttachmentRow.Rate)
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
            'MessageBox.Show("UpdateAttachmentForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("An Attachment Record already Exists for:" & vbCrLf &
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

    Private Sub OpenExcelButton_Click(sender As Object, e As EventArgs) Handles OpenFileButton.Click
        If txtFileAndLocation.Text Is Nothing Or txtFileAndLocation.Text = "" Then Exit Sub

        'Dim sr As New System.IO.StreamReader(txtFileAndLocation.Text)
        'MessageBox.Show(sr.ReadToEnd)
        'sr.Close()

        System.Diagnostics.Process.Start(txtFileAndLocation.Text)

    End Sub

End Class