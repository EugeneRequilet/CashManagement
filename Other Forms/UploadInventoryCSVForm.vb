Public Class UploadInventoryCSVForm

    Dim DC As InventoryDataContext
    Dim InventoryRow As Inventory
    Dim SVDC As SupplierViewDataContext
    Dim SupplierViewRow As SupplierView

    Dim csvDescription As String
    Dim csvQtySold As Integer
    Dim csvNetSalesAmount As Decimal
    Dim csvPrepCostAmount As Decimal
    Dim csvSellingPrice As Decimal

    Dim AddedRecords As Integer = 0
    Dim ChangedRecords As Integer = 0

    Private Sub UploadInventoryCSV_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Set the default directory of the folder browser to the current directory.
        txtDOSFile.Text = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            txtDOSFile.Text = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        LoadSupplier()
    End Sub

    Private Sub LoadSupplier()
        Dim CurrentRecordId As Integer
        Dim SelectedIndex As Integer = 0
        Dim SQLString As String = "Select * From Supplier Order By Description"
        cboSupplier.Items.Clear()
        cboSupplier.Items.Add("None")
        Try
            Dim SQL = SQLString
            SVDC = New SupplierViewDataContext
            SupplierViewBindingSource.DataSource = SVDC.ExecuteQuery(Of SupplierView)(SQL)
        Catch ex As Exception
            MessageBox.Show("SupplierView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        SupplierViewBindingSource.MoveFirst()
        Do
            Try
                SupplierViewRow = SupplierViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If SupplierViewRow IsNot Nothing Then
                If CurrentRecordId = SupplierViewRow.RecordId Then Exit Do
                CurrentRecordId = SupplierViewRow.RecordId
                cboSupplier.Items.Add(SupplierViewRow.Description)
                ' If InvoiceRow.SupplierRecordId = SupplierViewRow.RecordId Then cboSupplier.SelectedIndex = SelectedIndex
                ' SelectedIndex += 1
            End If
            SupplierViewBindingSource.MoveNext()
        Loop
        cboSupplier.SelectedIndex = 0
        SupplierViewRow.RecordId = 0
    End Sub

    Private Sub btnBrowseFilesOnDisk_Click(sender As Object, e As EventArgs) Handles browseButton.Click
        txtDOSFile.Text = GetFileName(5, 0)            ' 5 = "*.csv"
        If txtDOSFile.Text Is Nothing Or txtDOSFile.Text = "" Then Exit Sub
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub ImportButton_Click(sender As Object, e As EventArgs) Handles ImportButton.Click
        If SupplierViewRow.RecordId = 0 Then
            MessageBox.Show("Please select a Supplier.")
            cboSupplier.Select()
            Exit Sub
        End If
        SetInventoryItemsToInactive()
        ImportFileintoInventory()
    End Sub

    Private Sub SetInventoryItemsToInactive()

        Dim CurrentRecordId As Integer
        Dim SQL = "Select * From Inventory Where InactiveInventory = 0 And SupplierId = " & SupplierViewRow.RecordId

        Try
            DC = New InventoryDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of Inventory)(SQL)
        Catch ex As Exception
            MessageBox.Show("Inventory Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
        BindingSource1.MoveFirst()
        Do
            Try
                InventoryRow = BindingSource1.Current
            Catch ex As Exception
                Exit Do
            End Try
            If InventoryRow IsNot Nothing Then
                If CurrentRecordId = InventoryRow.RecordId Then Exit Do
                CurrentRecordId = InventoryRow.RecordId
                InventoryRow.InactiveInventory = 1
            End If
            BindingSource1.MoveNext()
        Loop
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("A Inventory Record could not be changed For:" & InventoryRow.Description, "Error")
        End Try
    End Sub

    Private Sub ImportFileintoInventory()

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
                            csvDescription = currentField
                            If csvDescription Is Nothing Or csvDescription = "" Then
                                ImportLineCorrect = False
                                Exit For
                            Else
                                ImportLineCorrect = True
                            End If
                        End If
                        Select Case fieldNo
                            Case 1
                                ' Done earlier
                            Case 2
                                Try
                                    csvQtySold = CInt(currentField)
                                Catch ex As Exception
                                    csvQtySold = 0.0
                                End Try
                            Case 3
                                Try
                                    csvNetSalesAmount = CDec(currentField)
                                Catch ex As Exception
                                    csvNetSalesAmount = 0.0
                                End Try
                            Case 4
                                Try
                                    csvPrepCostAmount = CDec(currentField)
                                Catch ex As Exception
                                    csvPrepCostAmount = 0.0
                                End Try
                            Case 5
                                Try
                                    csvSellingPrice = CDec(currentField)
                                Catch ex As Exception
                                    csvSellingPrice = 0.0
                                End Try
                        End Select
                        'MsgBox(currentField)
                    Next
                    If ImportLineCorrect = True Then getInventory()
                Catch ex As Microsoft.VisualBasic.FileIO.MalformedLineException
                    MsgBox("Line " & ex.Message & "is not valid and will be skipped.")
                End Try
            End While
        End Using
    End Sub

    Private Sub getInventory()
        If csvDescription <> "" Then
            DC = New InventoryDataContext
            BindingSource1.DataSource = From Inventory In DC.Inventories Where Inventory.Description = csvDescription
            InventoryRow = BindingSource1.Current
            If InventoryRow Is Nothing Then
                AddInventory()
            Else
                ChangeInventory()
            End If
        End If
    End Sub

    Private Sub AddInventory()
        DC = New InventoryDataContext
        InventoryRow = New Inventory
        BindingSource1.AddNew()
        InventoryRow = BindingSource1.Current

        ' Allocate CSV to Inventory Record

        InventoryRow.Description = csvDescription
        If csvQtySold = 0 Then
            InventoryRow.CostPrice = csvPrepCostAmount
        Else
            InventoryRow.CostPrice = csvPrepCostAmount / csvQtySold
        End If
        InventoryRow.SellingPrice = csvSellingPrice
        InventoryRow.SupplierId = SupplierViewRow.RecordId
        InventoryRow.Dated = DateTime.Now
        InventoryRow.InactiveInventory = 0

        Try
            BindingSource1.EndEdit()
            DC.Inventories.InsertOnSubmit(InventoryRow)
            DC.SubmitChanges()
            AddedRecords += 1
            txtAddedRecords.Text = AddedRecords
        Catch ex As Exception
            MessageBox.Show("A Inventory Record already Exists for:" & InventoryRow.Description, "Duplicate Key")
        End Try
    End Sub

    Private Sub ChangeInventory()

        ' Allocate CSV to Inventory Record

        If csvQtySold = 0 Then
            InventoryRow.CostPrice = csvPrepCostAmount
        Else
            InventoryRow.CostPrice = csvPrepCostAmount / csvQtySold
        End If
        InventoryRow.SellingPrice = csvSellingPrice
        InventoryRow.Dated = DateTime.Now
        InventoryRow.InactiveInventory = 0

        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
            ChangedRecords += 1
            txtChangedRecords.Text = ChangedRecords
        Catch ex As Exception
            MessageBox.Show("A Inventory Record could not be changed For:" & InventoryRow.Description, "Error")
        End Try
    End Sub

    Private Sub cboSupplier_Validated(sender As Object, e As EventArgs) Handles cboSupplier.Validated
        getSupplier()
    End Sub

    Private Sub getSupplier()
        SupplierViewRow.RecordId = 0
        If cboSupplier.SelectedItem.ToString() <> "" Then
            SVDC = New SupplierViewDataContext
            SupplierViewBindingSource.DataSource = From SupplierView In SVDC.SupplierViews Where SupplierView.Description = cboSupplier.SelectedItem.ToString()
            SupplierViewRow = SupplierViewBindingSource.Current
            'If SupplierViewRow Is Nothing Then
            '    SupplierViewRow.RecordId = 0
            'End If
        End If
    End Sub
End Class