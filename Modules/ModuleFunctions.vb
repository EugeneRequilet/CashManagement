Module ModuleFunctions

    Public Sub SetGlobalFirmDetail()
        GlobalFirmDetailRow = GetFirmDetail()
    End Sub

    Public Function GetFirmDetail() As FirmDetail
        Dim DC = New FirmDetailDataContext
        Dim BS = New BindingSource
        BS.DataSource = From FirmDetail In DC.FirmDetails
        If BS.Count = 0 Then Return New FirmDetail
        Return BS.Current
    End Function

    Public Function GetFileName(Filter As Integer, Directory As Integer) As String
        Dim strFileName = ""
        Dim fileDialogBox As New OpenFileDialog()

        ' Filter options as default file type
        '
        ' Filter = 1    Rich Text Format (*.rtf)
        ' Filter = 2    Text Files (*.txt)
        ' Filter = 3    Word Documents (*.doc;*.docx)
        ' Filter = 4    Excel Documents (*.xls;*.xlsx)
        ' Filter = 5    CSV Documents (*.csv)
        ' Filter = 6    Image Files (*.bmp;*.jpg;*.gif)
        ' Filter = 7    All Files (*.*)

        fileDialogBox.Filter = "Rich Text Format (*.rtf)|*.rtf|" _
            & "Text Files (*.txt)|*.txt|" _
            & "Word Documents (*.doc;*.docx)|*.doc;*.docx|" _
            & "Excel Documents (*.xls;*.xlsx)|*.xls;*.xlsx|" _
            & "CSV Documents (*.csv)|*.csv|" _
            & "Image Files (*.bmp;*.jpg;*.gif)|*.bmp;*.jpg;*.gif|" _
            & "All Files (*.*)|"
        'this sets the default filter that we created in the line above, if you don't 
        'set a FilterIndex it will automatically default to 1
        fileDialogBox.FilterIndex = Filter          ' 4
        'this line tells the file dialog box what folder it should start off in first
        'I selected the users my document folder
        fileDialogBox.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal)
        Select Case Directory
            Case 0
                fileDialogBox.InitialDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
            Case 1
                fileDialogBox.InitialDirectory = GlobalFirmDetailRow.SQLBackupDefaultDirectory
            Case 2
                fileDialogBox.InitialDirectory = GlobalFirmDetailRow.AttachmentDirectory
        End Select

        If fileDialogBox.InitialDirectory = "" Then
            fileDialogBox.InitialDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If

        'Check to see if the user clicked the open button
        If (fileDialogBox.ShowDialog() = DialogResult.OK) Then
            strFileName = fileDialogBox.FileName
            'Else
            '   MsgBox("You did not select a file!")
        End If

        'return the name of the file
        Return strFileName
    End Function

End Module
