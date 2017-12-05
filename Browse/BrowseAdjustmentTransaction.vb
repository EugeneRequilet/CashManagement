Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseAdjustmentTransaction

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Adjustment Request " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim ADC As AdjustmentDataContext
    Dim AdjustmentRow As AdjustmentRequested
    Dim AVDC As AdjustmentViewDataContext
    Dim AdjustmentViewRow As AdjustmentView
    Dim ATVDC As AdjustmentTransactionViewDataContext
    Dim AdjustmentTransactionViewRow As AdjustmentTransactionView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Private Sub btnBrowseAdjustment_Click(sender As Object, e As EventArgs) Handles btnBrowseAdjustment.Click
        GlobalAdjustmentLookupRecordId = -1
        GlobalHideInsertAmendDelete = True
        Using frm As New BrowseAdjustments
            frm.ShowDialog()
        End Using
        GlobalHideInsertAmendDelete = False
        UpdateAdjustmentRequestedRecord()
        Form_Load(sender, e)
    End Sub

    Private Sub BrowseAdjustmentTransaction_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        ' Remember to set the browse KeyPreview to TRUE
        Select Case e.KeyCode
            Case Keys.Insert
                InsertButton_Click(Nothing, Nothing)
            Case Keys.Enter
                ChangeButton_Click(Nothing, Nothing)
            Case Keys.Delete
                DeleteButton_Click(Nothing, Nothing)
        End Select
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
        AdjustmentTransactionGrid1.LoadData()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            AdjustmentTransactionGrid1.DeleteRow()
        End If
        SetAdjustmentAmount()
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        AdjustmentTransactionGrid1.ChangeRow()
        SetAdjustmentAmount()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateAdjustmentTransactionForm(-1)
            frm.ShowDialog()
            AdjustmentTransactionGrid1.LoadData()
        End Using
        SetAdjustmentAmount()
    End Sub

    Private Sub PrintButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        CheckForFileAndContinue()
    End Sub

    Private Sub CheckForFileAndContinue()
        CreateExcelWorkbook()
        WriteExcelHeader()
        WriteExcelBody()
        WriteExcelFooter()
        DisplayExcelWorkbook()
        'Me.Close()
    End Sub

    Private Sub CreateExcelWorkbook()
        'Start a new workbook in Excel
        xlApp = New Excel.Application
        xlApp.WindowState = Excel.XlWindowState.xlMaximized
        'Start a new workbook in Excel
        xlWorkBook = xlApp.Workbooks.Add
        SaveExcelWorkbook()
    End Sub

    Private Sub SaveExcelWorkbook()
        ' Name and Save the Workbook
        Dim Saved As Boolean = False
        Dim Number As Integer = 0
        Dim FileName As String = XLDirectory & XLFileName & XLExtention
        Do While Saved = False
            Try
                xlApp.DisplayAlerts = False
                xlWorkBook.SaveAs(FileName)
                Saved = True
            Catch ex As Exception
                Number += 1
                If Number > 10 Then
                    MessageBox.Show("We could not Overwrite the file." & vbCrLf & vbCrLf & "File: " & FileName & vbCrLf & vbCrLf & "Please close the Above Excel File and try again")
                End If
                FileName = XLDirectory & XLFileName & " " & Number & XLExtention
            End Try
        Loop
    End Sub

    Private Sub WriteExcelHeader()
        'Add data to cells of the first worksheet in the new workbook
        'xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        Try
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        Catch ex As Exception
            xlWorkSheet = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        End Try

        With xlWorkSheet
            .Range("A1:AB3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Adjustment Request dated: " & Today.ToLongDateString
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 14

            .Range("A4").Value = "Supplier"
            .Range("A5").Value = "Date"
            .Range("A6").Value = "Original Invoice"
            .Range("A7").Value = "Document Requested"
            .Range("A8").Value = "Memo"

            .Range("C4").Value = txtSupplierDescription.Text
            .Range("C5").Value = txtHeaderDate.Text
            .Range("C6").Value = txtHeaderInvoiceNumber.Text
            .Range("C7").Value = txtHeaderDoucmentType.Text
            .Range("C8").Value = txtHeaderMemo.Text

            .Range("A4:E8").Font.Bold = True
            .Range("A4:E8").Font.Size = 12
            .Range("A4:E8").HorizontalAlignment = Excel.Constants.xlLeft
            .Range("A4:E8").Borders.LineStyle = Excel.Constants.xlSolid

            .Range("A4:B4").Merge()
            .Range("A5:B5").Merge()
            .Range("A6:B6").Merge()
            .Range("A7:B7").Merge()
            .Range("A8:B8").Merge()

            .Range("C4:E4").Merge()
            .Range("C5:E5").Merge()
            .Range("C6:E6").Merge()
            .Range("C7:E7").Merge()
            .Range("C8:E8").Merge()

            .Range("A10").Value = "Inventory Item"
            .Range("B10").Value = "Quantity"
            .Range("C10").Value = "Cost Price"
            .Range("D10").Value = "Amount"
            .Range("E10").Value = "Memo"

            .Range("A10:E10").Font.Bold = True
            .Range("A10:E10").Font.Size = 9
            .Range("A10:E10").WrapText = True
            .Range("A10:E10").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A10").ColumnWidth = 20
            .Range("B10:D10").ColumnWidth = 10
            .Range("E10").ColumnWidth = 40
            .Range("A10:E10").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        SpreadsheetLine = 10

        With xlWorkSheet
            .Range("A11:Z500").Font.Bold = False
            .Range("A11:Z500").Font.Size = 11
        End With

        Dim SQLString As String = "Select * From AdjustmentTransactionView Where AdjustmentRequestedRecordId = " & GlobalAdjustmentLookupRecordId
        Try
            Dim SQL = SQLString
            ATVDC = New AdjustmentTransactionViewDataContext
            AdjustmentTransactionViewBindingSource.DataSource = ATVDC.ExecuteQuery(Of AdjustmentTransactionView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        AdjustmentTransactionViewBindingSource.MoveFirst()
        Do
            Try
                AdjustmentTransactionViewRow = AdjustmentTransactionViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If AdjustmentTransactionViewRow IsNot Nothing Then
                If CurrentRecordId = AdjustmentTransactionViewRow.RecordId Then Exit Do
                CurrentRecordId = AdjustmentTransactionViewRow.RecordId

                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = AdjustmentTransactionViewRow.InventoryDescription
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = AdjustmentTransactionViewRow.Quantity
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = AdjustmentTransactionViewRow.CostPrice
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = AdjustmentTransactionViewRow.CalcAmount
                    CellString = "E" & LineNoString
                    .Range(CellString).Value = AdjustmentTransactionViewRow.Memo


                    CellString = "A" & LineNoString & ":E" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "A" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "B" & LineNoString & ":D" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "E" & LineNoString & ":F" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "B" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0"
                    CellString = "C" & LineNoString & ":D" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                End With
            End If
            AdjustmentTransactionViewBindingSource.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        SpreadsheetLine += 2
        LineNoString = SpreadsheetLine

        With xlWorkSheet

            CellString = "C" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "D" & LineNoString
            FormulaString = "=SUM(D11:D" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D11:D34)"
            CellString = "E" & LineNoString
            .Range(CellString).Value = txtHeaderDoucmentType.Text & " Requested"

            CellString = "C" & LineNoString & ":D" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "D" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "E" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            CellString = "C" & LineNoString & ":E" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).Font.Bold = True
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            LineNoString = SpreadsheetLine
            CellString = "E11:E" & LineNoString
            xlWorkSheet.Range(CellString).Columns.AutoFit()
            'xlWorkSheet.Range("C4").Select()
            '.ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            .Visible = True
        End With
        'If cboSupplier.SelectedIndex <> 0 Then xlWorkSheet.Range("J5").ColumnWidth = 0
        'xlWorkBook.Worksheets(1).PageSetup.PrintOut()                                                                        ' Immediate printout does work.
    End Sub

    Private Sub XLWorkSheetSetup()
        With xlWorkBook.Worksheets(1).PageSetup
            '~~> In this section, you can define where and what your header and footer should look like
            '.LeftHeader = ""
            '.CenterHeader = "Sample Header"
            '.RightHeader = ""
            '.LeftFooter = ""
            '.CenterFooter = "Sample Footer"
            '.RightFooter = ""

            '~~> In this section, you can set the margins
            .LeftMargin = xlApp.CentimetersToPoints(1)
            .RightMargin = xlApp.CentimetersToPoints(1)
            .TopMargin = xlApp.CentimetersToPoints(1)
            .BottomMargin = xlApp.CentimetersToPoints(1)
            .HeaderMargin = xlApp.CentimetersToPoints(0.5)
            .FooterMargin = xlApp.CentimetersToPoints(0.5)

            '~~> Other settings that you can set
            .PrintHeadings = False
            .PrintGridlines = False
            .PrintComments = Excel.XlPrintLocation.xlPrintNoComments
            .CenterHorizontally = False
            .CenterVertically = False
            .Orientation = Excel.XlPageOrientation.xlPortrait                                   ' Excel.XlPageOrientation.xlLandscape               ' '1 = xlPortrait; 2 = xlLandscape
            '.Draft = True
            .PaperSize = Excel.XlPaperSize.xlPaperA4
            .FirstPageNumber = Excel.Constants.xlAutomatic
            .Order = Excel.XlOrder.xlDownThenOver
            .BlackAndWhite = True
            .PrintErrors = Excel.XlPrintErrors.xlPrintErrorsDisplayed
            .OddAndEvenPagesHeaderFooter = False
            .DifferentFirstPageHeaderFooter = False
            .ScaleWithDocHeaderFooter = True
            .AlignMarginsHeaderFooter = True

            '~~> More settings that you can set
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = 1
        End With
    End Sub

    Private Sub NextButton_Click(sender As Object, e As EventArgs) Handles NextButton.Click
        Dim SQLString As String = "SELECT * From AdjustmentRequested Where AdjustmentRequested.Date >= '" & Format(AdjustmentRow.Date, "dd MMMM yyyy") & "'" &
            " And SupplierRecordId >= " & AdjustmentRow.SupplierRecordId & " And InvoiceNumber >= '" & AdjustmentRow.InvoiceNumber & "'" &
            " And DocumentType >= '" & AdjustmentRow.DocumentType & "' Order By Date, SupplierRecordId, InvoiceNumber, DocumentType"
        Try
            Dim SQL = SQLString
            ADC = New AdjustmentDataContext
            AdjustmentBindingSource.DataSource = ADC.ExecuteQuery(Of AdjustmentRequested)(SQL)
        Catch ex As Exception
            MessageBox.Show("AdjustmentRequested Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        AdjustmentBindingSource.MoveFirst()
        AdjustmentBindingSource.MoveNext()
        Try
            AdjustmentRow = AdjustmentBindingSource.Current
            If AdjustmentRow IsNot Nothing Then
                GlobalAdjustmentLookupRecordId = AdjustmentRow.RecordId
            End If
        Catch ex As Exception
            Exit Sub
        End Try

        UpdateAdjustmentRequestedRecord()
        Form_Load(sender, e)
    End Sub

    Private Sub UpdateAdjustmentRequestedRecord()
        AVDC = New AdjustmentViewDataContext
        AdjustmentViewBindingSource.DataSource = From AdjustmentView In AVDC.AdjustmentViews Where AdjustmentView.RecordId = GlobalAdjustmentLookupRecordId
        AdjustmentViewRow = AdjustmentViewBindingSource.Current
        If AdjustmentViewRow Is Nothing Then
            'MsgBox("No Adjustment Selected")
            Me.Close()
        End If
        SetAdjustmentAmount()
        If txtHeaderDate.Text = "" Then
            NextButton.Visible = False
        Else
            NextButton.Visible = True
        End If
    End Sub

    Private Sub SetAdjustmentAmount()
        ADC = New AdjustmentDataContext
        AdjustmentBindingSource.DataSource = From AdjustmentRequested In ADC.AdjustmentRequesteds Where AdjustmentRequested.RecordId = GlobalAdjustmentLookupRecordId
        AdjustmentRow = AdjustmentBindingSource.Current
        If AdjustmentViewRow Is Nothing Then Exit Sub
        AdjustmentRow.Amount = 0.0
        ' Calculate the Adjustment Request Header Amount
        Dim CurrentRecordId As Integer
        Dim SQLString As String = "Select * From AdjustmentTransactionView Where AdjustmentRequestedRecordId = " & GlobalAdjustmentLookupRecordId
        Try
            Dim SQL = SQLString
            ATVDC = New AdjustmentTransactionViewDataContext
            AdjustmentTransactionViewBindingSource.DataSource = ATVDC.ExecuteQuery(Of AdjustmentTransactionView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        AdjustmentTransactionViewBindingSource.MoveFirst()
        Do
            Try
                AdjustmentTransactionViewRow = AdjustmentTransactionViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If AdjustmentTransactionViewRow IsNot Nothing Then
                If CurrentRecordId = AdjustmentTransactionViewRow.RecordId Then Exit Do
                CurrentRecordId = AdjustmentTransactionViewRow.RecordId
                AdjustmentRow.Amount += AdjustmentTransactionViewRow.CalcAmount
                AdjustmentViewRow.Amount = AdjustmentRow.Amount
            End If
            AdjustmentTransactionViewBindingSource.MoveNext()
        Loop
        AdjustmentBindingSource.EndEdit()
        ADC.SubmitChanges()
        txtHeaderAdjustmentAmount.EditValue = AdjustmentViewRow.Amount
    End Sub

End Class