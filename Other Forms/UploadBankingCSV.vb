Imports System.IO

Public Class UploadBankingCSV

    Dim DC As BankingDataContext
    Dim BankingRow As Banking

    Dim csvDate As Date
    Dim csvServiceFee As Decimal
    Dim csvAmount As Decimal
    Dim csvDescription As String
    Dim csvChqNo As Decimal
    Dim csvBalance As Decimal

    Private Sub btnBrowseFilesOnDisk_Click(sender As Object, e As EventArgs) Handles browseButton.Click
        txtDOSFile.Text = GetFileName(5, 0)            ' 5 = "*.csv"
        If txtDOSFile.Text Is Nothing Or txtDOSFile.Text = "" Then Exit Sub
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ImportButton.Click
        ImportFileintoBanking()
    End Sub

    Private Sub ImportFileintoBanking()

        If txtDOSFile.Text Is Nothing Then
            MessageBox.Show("Please select a file.")
            Exit Sub
        End If
        If My.Computer.FileSystem.FileExists(txtDOSFile.Text) = False Then
            MessageBox.Show("File Not Found: " & txtDOSFile.Text)
            Exit Sub
        End If

        Using MyReader As New Microsoft.VisualBasic.FileIO.TextFieldParser(txtDOSFile.Text)
            MyReader.TextFieldType = FileIO.FieldType.Delimited
            MyReader.SetDelimiters(",")
            Dim RecordsAdded As Integer = 0
            Dim IgnoredRecords As Integer = 0
            Dim currentRow As String()
            While Not MyReader.EndOfData
                Try
                    currentRow = MyReader.ReadFields()
                    Dim currentField As String
                    Dim fieldNo As Integer = 0
                    Dim ImportLineCorrect As Boolean = False
                    For Each currentField In currentRow
                        fieldNo += 1
                        If fieldNo = 1 Then
                            Try
                                csvDate = CDate(currentField)
                                ImportLineCorrect = True
                            Catch ex As Exception
                                ImportLineCorrect = False
                                Exit For
                            End Try
                        End If
                        Select Case fieldNo
                            Case 1
                                ' Done earlier
                            Case 2
                                csvServiceFee = currentField
                            Case 3
                                Try
                                    csvAmount = currentField
                                    If csvAmount < 0 Then
                                        ImportLineCorrect = False
                                        Exit For
                                    End If
                                Catch ex As Exception
                                    ImportLineCorrect = False
                                    Exit For
                                End Try
                            Case 4
                                csvDescription = currentField
                            Case 5
                                csvChqNo = currentField
                            Case 6
                                csvBalance = currentField
                        End Select
                        'MsgBox(currentField)
                    Next
                    If ImportLineCorrect = True Then
                        LoadData()
                        If ValidateData() = DialogResult.OK Then
                            If SaveData() = DialogResult.OK Then
                                RecordsAdded += 1
                                txtRecordsAdded.Text = RecordsAdded
                                'MsgBox("Record Added:" & vbCrLf & vbCrLf & _
                                '       "Date:" & vbTab & BankingRow.Date & vbCrLf & _
                                '       "Type:" & vbTab & BankingRow.BankingType & vbCrLf & _
                                '       "Amount:" & vbTab & BankingRow.Amount & vbCrLf & _
                                '       "Desc:" & vbTab & BankingRow.Memo & vbCrLf & _
                                '       "Row No:" & vbTab & BankingRow.Number & vbCrLf & _
                                '       "Balance:" & vbTab & BankingRow.Balance)
                            Else
                                IgnoredRecords += 1
                                txtRecordsIgnored.Text = IgnoredRecords
                                'MsgBox("Record Not Added:" & vbCrLf & vbCrLf & _
                                '       "Date:" & vbTab & csvDate & vbCrLf & _
                                '       "Fee:" & vbTab & csvServiceFee & vbCrLf & _
                                '       "Amount:" & vbTab & csvAmount & vbCrLf & _
                                '       "Desc:" & vbTab & csvDescription & vbCrLf & _
                                '       "Chq No:" & vbTab & csvChqNo & vbCrLf & _
                                '       "Balance:" & vbTab & csvBalance)
                            End If
                        Else
                            IgnoredRecords += 1
                            txtRecordsIgnored.Text = IgnoredRecords
                        End If
                    End If
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
        End Using
    End Sub

    Private Sub LoadData()
        DC = New BankingDataContext
        BankingRow = New Banking
        BindingSource1.AddNew()
        BankingRow = BindingSource1.Current
        setRecord()

    End Sub

    Private Sub setRecord()
        Dim Position As Integer = 0
        Dim TempString As String = ""

        ' Set Default values for Banking Record

        BankingRow.Date = Today
        BankingRow.BankingType = "D"    ' Set as Cash Deposit
        BankingRow.Amount = 0.0
        BankingRow.Number = 0
        BankingRow.Balance = 0.0
        BankingRow.Reconciled = False
        BankingRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        ' Allocate CSV to Banking Record

        BankingRow.Date = csvDate
        BankingRow.Amount = csvAmount
        BankingRow.Balance = csvBalance
        BankingRow.Memo = csvDescription

        ' Check to see if this is a Credit Card transaction

        Position = InStr(1, csvDescription, "CC", CompareMethod.Text)
        If Position = 0 Then
            Position = InStr(1, csvDescription, "DD", CompareMethod.Text)
        End If
        If Position <> 0 Then
            If GetChar(csvDescription, (Position - 1)) <> " " Then Position = 0
            If Position <> 0 Then TempString = csvDescription.Substring((Position - 9), 5)
        End If

        If Position = 0 Then
            ' Check to see if this is a SURESWIPE transaction and make it a Credit Card

            Position = InStr(1, csvDescription, "SURESWIPE", CompareMethod.Text)
            TempString = csvDescription.Substring((Len(csvDescription) - 4), 4)
        End If

        If Position <> 0 Then
            BankingRow.BankingType = "C"    ' Set as Credit Card Deposit
            Try
                BankingRow.Number = Trim(TempString)
            Catch ex As Exception
                BankingRow.Number = 0
            End Try
        End If
    End Sub

    Private Function ValidateData() As DialogResult
        If BankingRow.Date = Nothing OrElse BankingRow.Date = Date.MinValue Then Return DialogResult.Cancel
        If InStr(1, "DC", BankingRow.BankingType, CompareMethod.Text) = 0 Then Return DialogResult.Cancel
        If BankingRow.Amount = 0 Then Return DialogResult.Cancel
        Return DialogResult.OK
    End Function

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.Bankings.InsertOnSubmit(BankingRow)
            DC.SubmitChanges()
        Catch ex As Exception
            'MessageBox.Show("A Banking Record already Exists for:" & vbCrLf & "Date: " & vbTab & vbTab & BankingRow.Date & vbCrLf & "Amount: " & vbTab & BankingRow.Amount & vbCrLf & "Type: " & vbTab & BankingRow.BankingType, "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub UploadBankingCSV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the default directory of the folder browser to the current directory.
        txtDOSFile.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            txtDOSFile.Text = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(txtDOSFile.Text) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & txtDOSFile.Text & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            txtDOSFile.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
    End Sub

End Class