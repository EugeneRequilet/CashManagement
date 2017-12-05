Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseInvoice

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Transaction " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim IVDC As InvoiceViewDataContext
    Dim InvoiceViewRow As InvoiceView
    Dim SVDC As SupplierViewDataContext
    Dim SupplierViewRow As SupplierView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Dim InvoiceBFwdBal As Decimal
    Dim ScreenHeaderDetails As String = ""
    Dim SupplierName As String = ""

    Private Sub BrowseInvoice_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
        ButtonFiltered()
        'GlobalDateFrom = (DateSerial(Year(Today), Month(Today), 1))
        'GlobalDateTo = (DateSerial(Year(Today), Month(Today) + 1, 0)).ToString

        If GlobalSupplierLookupRecordId Then ReadSupplierHeader()

        ScreenHeaderDetails = "Transactions"
        If GlobalSupplierLookupRecordId Then ScreenHeaderDetails = SupplierName & " Transactions"
        'If GlobalFilterString <> "" Then ScreenHeaderDetails = "Invoice List Filtered by '" & GlobalFilterString & "'"
        'If GlobalSupplierLookupRecordId And GlobalFilterString <> "" Then ScreenHeaderDetails = SupplierName & " Invoice List Filtered by '" & GlobalFilterString & "'"
        Me.Text = ScreenHeaderDetails

        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If

        DisplayGlobalFromToDates()
    End Sub

    Private Sub ButtonFiltered()
        If GlobalSupplierLookupRecordId Then
            btnSelectSupplier.Text = "By &Supplier <F>"                      ' & ChrW(&H2714) & ChrW(&H2715)
        Else
            btnSelectSupplier.Text = "By &Supplier"
        End If
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        GlobalSupplierLookupRecordId = 0
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            InvoiceGrid1.DeleteRow()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        InvoiceGrid1.ChangeRow()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateInvoiceForm(-1)
            frm.ShowDialog()
            InvoiceGrid1.LoadData()
        End Using
    End Sub

    Private Sub txtDateFrom_ValueChanged(sender As Object, e As EventArgs)
        DisplayGlobalFromToDates()
    End Sub

    Private Sub DateButton_Click(sender As Object, e As EventArgs) Handles DateButton.Click
        Using frm As New SelectDateFromToForm()
            frm.ShowDialog()
            DisplayGlobalFromToDates()
        End Using
    End Sub

    Private Sub DisplayGlobalFromToDates()
        lblDateRange.Text = GlobalDateFrom.ToString("dd/MM/yyyy") & " to " & GlobalDateTo.ToString("dd/MM/yyyy")
        InvoiceGrid1.LoadData()
    End Sub

    Private Sub btnSelectSupplier_Click(sender As Object, e As EventArgs) Handles btnSelectSupplier.Click
        Dim HoldGlobalHideInsertAmendDelete = GlobalHideInsertAmendDelete
        GlobalHideInsertAmendDelete = True
        Using frm As New BrowseSupplier
            frm.ShowDialog()
        End Using
        GlobalHideInsertAmendDelete = HoldGlobalHideInsertAmendDelete
        Form_Load(sender, e)
    End Sub

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        'If GlobalSupplierLookupRecordId Then
        '    ProcessSpreadSheet()
        'Else
        '    MessageBox.Show("Please select a Supplier", "No Supplier Selected")
        'End If
        ProcessSpreadSheet()
    End Sub

    Private Sub ProcessSpreadSheet()
        CreateExcelWorkbook()
        WriteExcelHeader()
        WriteExcelBody()
        WriteExcelFooter()
        DisplayExcelWorkbook()
        'GlobalSupplierLookupRecordId = 0
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

            If GlobalSupplierLookupRecordId = 0 Then
                .Range("A2").Value = "Transactions For All Suppliers"
            Else
                .Range("A2").Value = ScreenHeaderDetails
            End If
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Transactions From " & GlobalDateFrom.ToString("dd MMM yyyy") & " to " & GlobalDateTo.ToString("dd MMM yyyy")
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 16

            .Range("A5").Value = "Day Of Week"
            .Range("B5").Value = "Date"
            .Range("C5").Value = "Type"
            .Range("D5").Value = "Document Number"
            .Range("E5").Value = "Invoice"
            .Range("F5").Value = "Credit Note / Payments"
            .Range("G5").Value = "Payment Type"
            .Range("H5").Value = "Adjustment Requested"
            .Range("I5").Value = "Running Balance"
            .Range("K5").Value = "Memo"
            .Range("L5").Value = "Supplier"

            .Range("A5:L5").Font.Bold = True
            .Range("A5:L5").Font.Size = 9
            .Range("A5:L5").WrapText = True
            .Range("A5:L5").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 6
            .Range("B5").ColumnWidth = 10
            .Range("C5").ColumnWidth = 20
            .Range("D5:I5").ColumnWidth = 11
            .Range("G5").ColumnWidth = 8
            .Range("J5").ColumnWidth = 2
            .Range("K5:L5").ColumnWidth = 30
            .Range("A5:L5").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer

        'GetBalanceBroughtForward()
        GetBalanceBFwd()


        Dim SQL = "Select * From InvoiceView Where Date >= '" & _
                    DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" & _
                    DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
                    "' Order by Date, DocumentTypeOrder"
        If GlobalSupplierLookupRecordId Then
            SQL = "Select * From InvoiceView Where Date >= '" & _
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" & _
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
                        "' And SupplierRecordId = " & GlobalSupplierLookupRecordId & _
                        " Order by Date, DocumentTypeOrder"
        End If
        Try
            IVDC = New InvoiceViewDataContext
            InvoiceViewBindingSource.DataSource = IVDC.ExecuteQuery(Of InvoiceView)(SQL)
        Catch ex As Exception
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        SpreadsheetLine = 5

        With xlWorkSheet
            .Range("A5:Z5000").Font.Bold = False
            .Range("A5:Z5000").Font.Size = 11
        End With

        If InvoiceBFwdBal <> 0.0 Then
            SpreadsheetLine += 1
            LineNoString = SpreadsheetLine
            CellString = "C" & LineNoString
            With xlWorkSheet
                CellString = "C" & LineNoString
                .Range(CellString).Value = "B/Fwd"
                If InvoiceBFwdBal > 0.0 Then
                    CellString = "E" & LineNoString
                    .Range(CellString).Value = InvoiceBFwdBal
                    CellString = "F" & LineNoString
                    .Range(CellString).Value = ""
                Else
                    CellString = "E" & LineNoString
                    .Range(CellString).Value = ""
                    CellString = "F" & LineNoString
                    .Range(CellString).Value = InvoiceBFwdBal
                End If
                CellString = "I" & LineNoString
                If SpreadsheetLine = 6 Then
                    FormulaString = "=E" & LineNoString & "+F" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=E5-F5"
                Else
                    FormulaString = "=I" & (LineNoString - 1) & "+E" & LineNoString & "+F" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=G5+E6-F6"
                End If

                CellString = "A" & LineNoString & ":L" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                CellString = "A" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "E" & LineNoString & ":I" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                .Range(CellString).NumberFormat = "#,###,##0.00"
                CellString = "G" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlCenter
            End With
        End If
        InvoiceViewBindingSource.MoveFirst()
        Do
            Try
                InvoiceViewRow = InvoiceViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If InvoiceViewRow IsNot Nothing Then
                If CurrentRecordId = InvoiceViewRow.RecordId Then Exit Do
                CurrentRecordId = InvoiceViewRow.RecordId
                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = Mid(InvoiceViewRow.Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = Format(InvoiceViewRow.Date, "dd MMM yy")
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = InvoiceViewRow.DocumentTypeDesc
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = InvoiceViewRow.DocumentNumber
                    CellString = "E" & LineNoString
                    If InvoiceViewRow.InvoiceAmount <> 0 Then .Range(CellString).Value = InvoiceViewRow.InvoiceAmount
                    CellString = "F" & LineNoString
                    If InvoiceViewRow.CreditNoteAmount <> 0 Then .Range(CellString).Value = (InvoiceViewRow.CreditNoteAmount * -1)
                    If InvoiceViewRow.PaymentAmount <> 0 Then
                        .Range(CellString).Value = (InvoiceViewRow.PaymentAmount * -1)
                        .Range(CellString).Interior.Color = Color.LightBlue
                        CellString = "G" & LineNoString
                        .Range(CellString).Value = InvoiceViewRow.PaymentTypeDesc
                        .Range(CellString).Interior.Color = Color.LightBlue
                    End If
                    CellString = "H" & LineNoString
                    If InvoiceViewRow.AdjustmentAmount <> 0.0 Then
                        .Range(CellString).Value = InvoiceViewRow.AdjustmentAmount
                        .Range(CellString).Font.Color = Color.Red
                    End If
                    CellString = "I" & LineNoString
                    If SpreadsheetLine = 6 Then
                        FormulaString = "=E" & LineNoString & "+F" & LineNoString
                        .Range(CellString).Formula = FormulaString                                                        ' "=E5-F5"
                    Else
                        FormulaString = "=I" & (LineNoString - 1) & "+E" & LineNoString & "+F" & LineNoString
                        .Range(CellString).Formula = FormulaString                                                        ' "=G5+E6-F6"
                    End If
                    CellString = "K" & LineNoString
                    .Range(CellString).Value = InvoiceViewRow.Memo
                    Try
                        If InvoiceViewRow.SupplierRecordId <> SupplierViewRow.RecordId Then ReadSupplier()
                    Catch ex As Exception
                        ReadSupplier()
                    End Try
                    CellString = "L" & LineNoString
                    .Range(CellString).Value = SupplierViewRow.Description              ' NEED TO READ AND WORK THIS OUT

                    CellString = "A" & LineNoString & ":L" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "A" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "E" & LineNoString & ":I" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                    CellString = "G" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlCenter
                End With
            End If
            InvoiceViewBindingSource.MoveNext()
            If SpreadsheetLine > 5000 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        CellString = "A5:J" & LineNoString
        xlWorkSheet.Range(CellString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)

        'Write the Footer First Line

        SpreadsheetLine += 2
        LineNoString = SpreadsheetLine

        With xlWorkSheet

            CellString = "B" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "E" & LineNoString
            FormulaString = "=SUBTOTAL(9,E5:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,E4:E34)"
            CellString = "F" & LineNoString
            FormulaString = "=SUBTOTAL(9,F5:F" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,F4:F34)"
            CellString = "H" & LineNoString
            FormulaString = "=SUBTOTAL(9,H5:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,F4:F34)"
            .Range(CellString).Font.Color = Color.Red
            CellString = "I" & LineNoString
            FormulaString = "=E" & LineNoString & "+F" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=E4-F4"

            CellString = "B" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "E" & LineNoString & ":I" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "E" & LineNoString & ":F" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "H" & LineNoString & ":I" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":I" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            LineNoString = SpreadsheetLine
            CellString = "K4:L" & LineNoString
            xlWorkSheet.Range(CellString).Columns.AutoFit()
            xlWorkSheet.Range("C6").Select()
            .ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            .Visible = True
        End With
        If GlobalSupplierLookupRecordId <> 0 Then xlWorkSheet.Range("L5").ColumnWidth = 0
        ' If 1 <> 0 Then xlWorkSheet.Range("J5").ColumnWidth = 0
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
            .Orientation = Excel.XlPageOrientation.xlLandscape                                   ' Excel.XlPageOrientation.xlLandscape               ' '1 = xlPortrait; 2 = xlLandscape
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

    Private Sub GetBalanceBFwd()
        InvoiceBFwdBal = 0
        If GlobalSupplierLookupRecordId Then
            'Dim SQL = "Select 0 AS Recordid, SUM(CASE WHEN InvoiceView.DocumentType = 'I' THEN InvoiceView.Amount ELSE (InvoiceView.Amount * -1) END) AS Amount From InvoiceView Where Date < '" &
            '                DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") &
            '                "' And SupplierRecordId = " & GlobalSupplierLookupRecordId &
            '                " Group by SupplierRecordId"
            Dim SQL = "Select 0 AS Recordid, (ISNULL(SUM(InvoiceView.InvoiceAmount),0) - " &
                            " ISNULL(SUM(InvoiceView.CreditNoteAmount),0) - " &
                            " ISNULL(SUM(InvoiceView.PaymentAmount),0)) AS Amount From InvoiceView Where Date < '" &
                            DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") &
                            "' And SupplierRecordId = " & GlobalSupplierLookupRecordId
            Try
                IVDC = New InvoiceViewDataContext
                InvoiceViewBindingSource.DataSource = IVDC.ExecuteQuery(Of InvoiceView)(SQL)
            Catch ex As Exception
                If Err.Number = 5 Then Exit Sub ' Procedure call or argument is not valid
                MessageBox.Show("InvoiceView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
                Exit Sub
            End Try
            InvoiceViewBindingSource.MoveFirst()
            Try
                InvoiceViewRow = InvoiceViewBindingSource.Current
            Catch ex As Exception
                If InvoiceViewRow Is Nothing Then Exit Try
                ' If Err.Number = 5 Then Exit Try ' Procedure call or argument is not valid
                MessageBox.Show("InvoiceView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
                Exit Sub
            End Try
            If InvoiceViewRow IsNot Nothing Then
                If InvoiceViewRow.Amount <> Nothing Then InvoiceBFwdBal = InvoiceViewRow.Amount
            End If
        End If
    End Sub

    Private Sub ReadSupplierHeader()
        Try
            SupplierViewBindingSource.DataSource = From SupplierView In (New SupplierViewDataContext).SupplierViews Where SupplierView.RecordId = GlobalSupplierLookupRecordId
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SupplierViewRow = If(SupplierViewBindingSource.Current, New SupplierView)
        SupplierName = SupplierViewRow.Description
    End Sub

    Private Sub ReadSupplier()
        SVDC = New SupplierViewDataContext
        SupplierViewBindingSource.DataSource = From SupplierView In SVDC.SupplierViews Where SupplierView.RecordId = InvoiceViewRow.SupplierRecordId
        SupplierViewRow = SupplierViewBindingSource.Current
    End Sub

End Class