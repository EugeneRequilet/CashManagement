Public Class UploadSalesCSVForm

    Dim SDC As SalesDataContext
    Dim SalesRow As Sales
    Dim IDC As InvoiceDataContext
    Dim InvoiceRow As Invoice

    Dim csvDate As Date
    Dim csvExclusiveGross As Decimal
    Dim csvExclusiveCostOfSales As Decimal

    Private Sub btnBrowseFilesOnDisk_Click(sender As Object, e As EventArgs) Handles browseButton.Click
        txtDOSFile.Text = GetFileName(5, 0)            ' 5 = "*.csv"
        If txtDOSFile.Text Is Nothing Or txtDOSFile.Text = "" Then Exit Sub
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ImportButton.Click
        ImportFileintoTask()
    End Sub

    Private Sub ImportFileintoTask()

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
                        Select Case fieldNo
                            Case 1
                                Try
                                    csvDate = CDate(currentField)
                                    ImportLineCorrect = True
                                Catch ex As Exception
                                    ImportLineCorrect = False
                                    Exit For
                                End Try
                            Case 2
                                Try
                                    csvExclusiveGross = CDec(currentField)
                                    ImportLineCorrect = True
                                Catch ex As Exception
                                    ImportLineCorrect = False
                                    Exit For
                                End Try
                            Case 3
                                Try
                                    csvExclusiveCostOfSales = CDec(currentField)
                                    ImportLineCorrect = True
                                Catch ex As Exception
                                    ImportLineCorrect = False
                                    Exit For
                                End Try
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
                                '       "Description:" & vbTab & SalesRow.Description & vbCrLf & _
                                '       "Cost Price:" & vbTab & SalesRow.CostPrice & vbCrLf)
                            Else
                                IgnoredRecords += 1
                                txtRecordsIgnored.Text = IgnoredRecords
                                'MsgBox("Record Not Added:" & vbCrLf & vbCrLf & _
                                '       "Description:" & vbTab & SalesRow.Description & vbCrLf & _
                                '       "Cost Price:" & vbTab & SalesRow.CostPrice & vbCrLf)
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
        SDC = New SalesDataContext
        SalesRow = New Sales
        SalesBindingSource.AddNew()
        SalesRow = SalesBindingSource.Current

        IDC = New InvoiceDataContext
        InvoiceRow = New Invoice
        InvoiceBindingSource.AddNew()
        InvoiceRow = InvoiceBindingSource.Current

        setRecord()
    End Sub

    Private Sub setRecord()
        ' Allocate CSV to Task Record

        SalesRow.Date = csvDate
        SalesRow.TurnoverCash = csvExclusiveGross * 1.14
        SalesRow.GrossSales = SalesRow.TurnoverCash
        SalesRow.Memo = "Imported"
        SalesRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        InvoiceRow.Date = SalesRow.Date
        InvoiceRow.DocumentType = "I"
        InvoiceRow.DocumentNumber = "IMP-" & InvoiceRow.Date.ToString("yyyymmdd")
        InvoiceRow.Amount = csvExclusiveCostOfSales * 1.14
        InvoiceRow.Memo = "Imported"
        InvoiceRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
        InvoiceRow.SupplierRecordId = 1
    End Sub

    Private Function ValidateData() As DialogResult
        If SalesRow.Date = Nothing OrElse SalesRow.Date = Date.MinValue Then Return DialogResult.Cancel
        Return DialogResult.OK
    End Function

    Public Function SaveData() As DialogResult
        Try
            SalesBindingSource.EndEdit()
            SDC.Sales.InsertOnSubmit(SalesRow)
            SDC.SubmitChanges()
        Catch ex As Exception
            'MessageBox.Show("A Task Record already Exists for:" & SalesRow.Description, "Duplicate Key")
            Return DialogResult.Cancel
        End Try

        Try
            InvoiceBindingSource.EndEdit()
            IDC.Invoices.InsertOnSubmit(InvoiceRow)
            IDC.SubmitChanges()
        Catch ex As Exception
            'MessageBox.Show("A Task Record already Exists for:" & SalesRow.Description, "Duplicate Key")
            Return DialogResult.Cancel
        End Try

        Return DialogResult.OK
    End Function

    Private Sub UploadSalesCSVForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the default directory of the folder browser to the current directory.
        txtDOSFile.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
    End Sub

End Class