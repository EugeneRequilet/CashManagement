Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class PrintIETrans

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet1 As Excel.Worksheet
    Dim xlWorkSheet2 As Excel.Worksheet
    Dim xlWorkSheet3 As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "IETrans " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim CVDC As CashUpViewDataContext
    Dim CashupViewRow As CashupView
    Dim IVDC As InvoiceViewDataContext
    Dim InvoiceViewRow As InvoiceView
    Dim SVDC As SupplierViewDataContext
    Dim SupplierViewRow As SupplierView

    Dim SpreadsheetLine1 As Integer
    Dim SpreadsheetLine2 As Integer
    Dim SpreadsheetLine3 As Integer
    Dim LineNoString1 As String
    Dim LineNoString2 As String
    Dim LineNoString3 As String
    Dim CellString As String
    Dim FormulaString As String

    Dim TotalReceiptsCell As String
    Dim TotalPaymentsCell As String

    Private Sub PrintIETrans_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setDropdowns()
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
    End Sub

    Private Sub setDropdowns()
        cboDateRange.Items.Clear()
        cboDateRange.Items.Add("As Is")
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), Month(Today), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 1), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 2), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 3), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 4), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 5), 1), "MMMM yyyy"))
        cboDateRange.SelectedIndex = 0
        setDatesFromDropdown()
    End Sub

    Private Sub setDatesFromDropdown()
        Select Case cboDateRange.SelectedIndex
            Case 0
                txtDateFrom.Text = (GlobalDateFrom).ToString
                txtDateTo.Text = (GlobalDateTo).ToString
            Case 1
                txtDateFrom.Text = (DateSerial(Year(Today), Month(Today), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), Month(Today) + 1, 0)).ToString
            Case 2
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 1), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), Month(Today), 0)).ToString
            Case 3
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 2), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), (Month(Today) - 1), 0)).ToString
            Case 4
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 3), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), (Month(Today) - 2), 0)).ToString
            Case 5
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 4), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), (Month(Today) - 3), 0)).ToString
            Case 6
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 5), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), (Month(Today) - 4), 0)).ToString
        End Select
    End Sub

    Private Sub cboDateRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDateRange.SelectedIndexChanged
        setDatesFromDropdown()
    End Sub

    Private Sub ExportExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        ProcessSpreadSheet()
    End Sub

    Private Sub OpenExcelButton_Click(sender As Object, e As EventArgs) Handles OpenExcelButton.Click
        XLFileName = GetFileName(4, 0)
        If XLFileName Is Nothing Or XLFileName = "" Then Exit Sub
        OpenExcelSpreadsheet()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub ProcessSpreadSheet()
        CreateExcelWorkbook()
        WriteExcelHeader()
        WriteExcelBody()
        WriteExcelFooter()
        DisplayExcelWorkbook()
        Me.Close()
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
        Try
            xlWorkSheet1 = xlWorkBook.Sheets("Sheet1")
        Catch ex As Exception
            xlWorkSheet1 = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        End Try
        Try
            xlWorkSheet2 = xlWorkBook.Sheets("Sheet2")
        Catch ex As Exception
            xlWorkSheet2 = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        End Try
        Try
            xlWorkSheet3 = xlWorkBook.Sheets("Sheet3")
        Catch ex As Exception
            xlWorkSheet3 = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        End Try
        xlWorkBook.Sheets("Sheet1").Name = "Summary"
        xlWorkBook.Sheets("Sheet2").Name = "Receipts"
        xlWorkBook.Sheets("Sheet3").Name = "Payments"

        With xlWorkSheet1
            .Range("A1:AB3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Receipts And Payments From " & GlobalDateFrom.ToString("dd MMM yyyy") & " to " & GlobalDateTo.ToString("dd MMM yyyy")
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A4").Value = "Receipts"
            .Range("A5").Value = "Payments"
            .Range("A7").Value = "Receipts Less Payments"
            .Range("B7").Formula = "=B4+B5"

            .Range("A4:A7").Font.Bold = True
            .Range("A4:B7").Font.Size = 11

            ' Setup Column Widths

            .Range("A4").ColumnWidth = 25
            .Range("B4").ColumnWidth = 12
            .Range("A4:B5").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("A7:B7").Borders.LineStyle = Excel.Constants.xlSolid

        End With

        With xlWorkSheet2
            .Range("A1:AB3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Debtor Transactions"
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Transactions From " & GlobalDateFrom.ToString("dd MMM yyyy") & " to " & GlobalDateTo.ToString("dd MMM yyyy")
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 16

            .Range("A5").Value = "Day Of Week"
            .Range("B5").Value = "Date"
            .Range("C5").Value = "Sales Type"
            .Range("D5").Value = "Amount"
            .Range("E5").Value = "Payment Type"
            .Range("F5").Value = "Credit Card"
            .Range("G5").Value = "Skims"
            .Range("H5").Value = "Payouts"
            .Range("I5").Value = "Reason"

            .Range("A5:I5").Font.Bold = True
            .Range("A5:I5").Font.Size = 9
            .Range("A5:I5").WrapText = True
            .Range("A5:I5").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 6
            .Range("B5").ColumnWidth = 10
            .Range("C5").ColumnWidth = 15
            .Range("D5").ColumnWidth = 11
            .Range("E5").ColumnWidth = 12
            .Range("F5:H5").ColumnWidth = 11
            .Range("I5").ColumnWidth = 30
            .Range("A5:I5").Borders.LineStyle = Excel.Constants.xlSolid

        End With

        With xlWorkSheet3
            .Range("A1:AB3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Supplier Transactions"
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Transactions From " & GlobalDateFrom.ToString("dd MMM yyyy") & " to " & GlobalDateTo.ToString("dd MMM yyyy")
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 16

            .Range("A5").Value = "Day Of Week"
            .Range("B5").Value = "Date"
            .Range("C5").Value = "Document"
            .Range("D5").Value = "Document Number"
            .Range("E5").Value = "Invoice / Credit Notes"
            .Range("F5").Value = "Payments"
            .Range("G5").Value = "Payment Type"
            .Range("H5").Value = "Supplier"
            .Range("I5").Value = "Type"
            .Range("J5").Value = "Memo"

            .Range("A5:J5").Font.Bold = True
            .Range("A5:J5").Font.Size = 9
            .Range("A5:J5").WrapText = True
            .Range("A5:J5").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 6
            .Range("B5").ColumnWidth = 10
            .Range("C5").ColumnWidth = 20
            .Range("D5").ColumnWidth = 15
            .Range("E5:G5").ColumnWidth = 11
            .Range("H5:J5").ColumnWidth = 30
            .Range("A5:J5").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer = 0

        Dim SQL = "Select * From CashUpView Where Date >= '" &
                    DateTime.Parse(txtDateFrom.Value).ToString("dd MMM yyyy") & "' and Date <= '" &
                    DateTime.Parse(txtDateTo.Value).ToString("dd MMM yyyy") &
                    "' Order by Date, RecordId"
        Try
            CVDC = New CashUpViewDataContext
            CashupViewBindingSource.DataSource = CVDC.ExecuteQuery(Of CashupView)(SQL)
        Catch ex As Exception
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        SpreadsheetLine2 = 5

        With xlWorkSheet2
            .Range("A5:Z5000").Font.Bold = False
            .Range("A5:Z5000").Font.Size = 11
        End With

        CashupViewBindingSource.MoveFirst()
        Do
            Try
                CashupViewRow = CashupViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If CashupViewRow IsNot Nothing Then
                If CurrentRecordId = CashupViewRow.RecordId Then Exit Do
                CurrentRecordId = CashupViewRow.RecordId
                SpreadsheetLine2 += 1
                LineNoString2 = SpreadsheetLine2

                With xlWorkSheet2
                    CellString = "A" & LineNoString2
                    .Range(CellString).Value = Mid(CashupViewRow.Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                    CellString = "B" & LineNoString2
                    .Range(CellString).Value = Format(CashupViewRow.Date, "dd MMM yy")
                    CellString = "C" & LineNoString2
                    .Range(CellString).Value = CashupViewRow.SalesTypeDesc
                    CellString = "D" & LineNoString2
                    .Range(CellString).Value = CashupViewRow.CashInTillLessFloat
                    CellString = "E" & LineNoString2
                    .Range(CellString).Value = CashupViewRow.PaymentTypeDesc
                    CellString = "F" & LineNoString2
                    .Range(CellString).Value = CashupViewRow.CreditCardDeposited
                    CellString = "G" & LineNoString2
                    .Range(CellString).Value = CashupViewRow.DepositSkims
                    CellString = "H" & LineNoString2
                    .Range(CellString).Value = CashupViewRow.Payouts
                    CellString = "I" & LineNoString2
                    If CashupViewRow.SalesType = 0 Then
                        .Range(CellString).Value = "Restraunt / Bar"
                    Else
                        .Range(CellString).Value = CashupViewRow.PayoutReason1
                    End If

                    CellString = "A" & LineNoString2 & ":I" & LineNoString2
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "A" & LineNoString2
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "D" & LineNoString2
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                    CellString = "F" & LineNoString2 & ":H" & LineNoString2
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                End With
            End If
            CashupViewBindingSource.MoveNext()
            If SpreadsheetLine2 > 5000 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop

        CurrentRecordId = 0

        SQL = "Select * From InvoiceView Where Date >= '" &
                    DateTime.Parse(txtDateFrom.Value).ToString("dd MMM yyyy") & "' and Date <= '" &
                    DateTime.Parse(txtDateTo.Value).ToString("dd MMM yyyy") &
                    "' Order by Date, DocumentTypeOrder"
        Try
            IVDC = New InvoiceViewDataContext
            InvoiceViewBindingSource.DataSource = IVDC.ExecuteQuery(Of InvoiceView)(SQL)
        Catch ex As Exception
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        SpreadsheetLine3 = 5

        With xlWorkSheet3
            .Range("A5:Z5000").Font.Bold = False
            .Range("A5:Z5000").Font.Size = 11
        End With

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
                SpreadsheetLine3 += 1
                LineNoString3 = SpreadsheetLine3

                With xlWorkSheet3
                    CellString = "A" & LineNoString3
                    .Range(CellString).Value = Mid(InvoiceViewRow.Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                    CellString = "B" & LineNoString3
                    .Range(CellString).Value = Format(InvoiceViewRow.Date, "dd MMM yy")
                    CellString = "C" & LineNoString3
                    .Range(CellString).Value = InvoiceViewRow.DocumentTypeDesc
                    CellString = "D" & LineNoString3
                    .Range(CellString).Value = InvoiceViewRow.DocumentNumber
                    CellString = "E" & LineNoString3
                    If InvoiceViewRow.InvoiceAmount <> 0 Then .Range(CellString).Value = InvoiceViewRow.InvoiceAmount
                    If InvoiceViewRow.CreditNoteAmount <> 0 Then .Range(CellString).Value = (InvoiceViewRow.CreditNoteAmount * -1)
                    CellString = "F" & LineNoString3
                    If InvoiceViewRow.PaymentAmount <> 0 Then
                        .Range(CellString).Value = (InvoiceViewRow.PaymentAmount * -1)
                        CellString = "G" & LineNoString3
                        .Range(CellString).Value = InvoiceViewRow.PaymentTypeDesc
                        CellString = "A" & LineNoString3 & ":J" & LineNoString3
                        .Range(CellString).Interior.Color = Color.LightBlue
                    End If
                    Try
                        If InvoiceViewRow.SupplierRecordId <> SupplierViewRow.RecordId Then ReadSupplier()
                    Catch ex As Exception
                        ReadSupplier()
                    End Try
                    CellString = "H" & LineNoString3
                    .Range(CellString).Value = SupplierViewRow.Description              ' NEED TO READ AND WORK THIS OUT
                    CellString = "I" & LineNoString3
                    Select Case SupplierViewRow.COS
                        Case 0
                            .Range(CellString).Value = "COS"
                        Case 1
                            .Range(CellString).Value = "Expense"
                    End Select
                    CellString = "J" & LineNoString3
                    .Range(CellString).Value = InvoiceViewRow.Memo

                    CellString = "A" & LineNoString3 & ":J" & LineNoString3
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "A" & LineNoString3
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "E" & LineNoString3 & ":G" & LineNoString3
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                    CellString = "G" & LineNoString3
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                End With
            End If
            InvoiceViewBindingSource.MoveNext()
            If SpreadsheetLine3 > 5000 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        LineNoString2 = SpreadsheetLine2
        CellString = "A5:I" & LineNoString2
        xlWorkSheet2.Range(CellString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)

        'Write the Footer First Line

        SpreadsheetLine2 += 2
        LineNoString2 = SpreadsheetLine2

        With xlWorkSheet2

            CellString = "C" & LineNoString2
            .Range(CellString).Value = "Totals"
            CellString = "D" & LineNoString2
            FormulaString = "=SUBTOTAL(9,D5:D" & (LineNoString2 - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,E4:E34)"
            CellString = "F" & LineNoString2
            FormulaString = "=SUBTOTAL(9,F5:F" & (LineNoString2 - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,E4:E34)"
            CellString = "G" & LineNoString2
            FormulaString = "=SUBTOTAL(9,G5:G" & (LineNoString2 - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,E4:E34)"
            CellString = "H" & LineNoString2
            FormulaString = "=SUBTOTAL(9,H5:H" & (LineNoString2 - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,E4:E34)"

            TotalReceiptsCell = "D" & LineNoString2 & ":H" & LineNoString2

            CellString = "C" & LineNoString2
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "D" & LineNoString2
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "F" & LineNoString2 & ":H" & LineNoString2
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString2 & ":J" & LineNoString2
            .Range(CellString).Font.Bold = True
        End With

        SpreadsheetLine2 += 2
        LineNoString2 = SpreadsheetLine2

        With xlWorkSheet2

            CellString = "C" & LineNoString2
            .Range(CellString).Value = "Total Receipts"
            CellString = "D" & LineNoString2
            FormulaString = "=SUM(" & TotalReceiptsCell & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,E4:E34)"

            TotalReceiptsCell = CellString

            CellString = "C" & LineNoString2
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "D" & LineNoString2
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString2 & ":J" & LineNoString2
            .Range(CellString).Font.Bold = True
        End With

        LineNoString3 = SpreadsheetLine3
        CellString = "A5:J" & LineNoString3
        xlWorkSheet3.Range(CellString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)

        'Write the Footer First Line

        SpreadsheetLine3 += 2
        LineNoString3 = SpreadsheetLine3

        With xlWorkSheet3

            CellString = "C" & LineNoString3
            .Range(CellString).Value = "Totals"
            CellString = "E" & LineNoString3
            FormulaString = "=SUBTOTAL(9,E5:E" & (LineNoString3 - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,E4:E34)"
            CellString = "F" & LineNoString3
            FormulaString = "=SUBTOTAL(9,F5:F" & (LineNoString3 - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,F4:F34)"

            TotalPaymentsCell = CellString

            CellString = "C" & LineNoString3
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "E" & LineNoString3 & ":F" & LineNoString3
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString3 & ":I" & LineNoString3
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet1
            .Range("B4").Value = "=Receipts!" & TotalReceiptsCell
            .Range("B5").Value = "=Payments!" & TotalPaymentsCell
            .Range("B4:B7").HorizontalAlignment = Excel.Constants.xlRight
            .Range("B4:B7").NumberFormat = "#,###,##0.00"
        End With

    End Sub

    Private Sub DisplayExcelWorkbook()
        xlWorkSheet3Setup()
        With xlApp
            xlWorkSheet3.Activate()
            With xlApp
                LineNoString3 = SpreadsheetLine3
                CellString = "I4:J" & LineNoString3
                xlWorkSheet3.Range(CellString).Columns.AutoFit()
                xlWorkSheet3.Range("C6").Select()
                .ActiveWindow.FreezePanes = True
                '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            End With
            xlWorkSheet2.Activate()
            With xlApp
                LineNoString2 = SpreadsheetLine2
                CellString = "I4:I" & LineNoString2
                xlWorkSheet2.Range(CellString).Columns.AutoFit()
                xlWorkSheet2.Range("C6").Select()
                .ActiveWindow.FreezePanes = True
                '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            End With
            xlWorkSheet1.Activate()
            With xlApp
                'LineNoString2 = SpreadsheetLine2
                'CellString = "G4:G" & LineNoString2
                'xlWorkSheet2.Range(CellString).Columns.AutoFit()
                'xlWorkSheet2.Range("C6").Select()
                '.ActiveWindow.FreezePanes = True
                '.ActiveWindow.Zoom = 85 ' open sheet at 85%
                .Visible = True
            End With
        End With
        ' If 1 <> 0 Then xlWorkSheet3.Range("J5").ColumnWidth = 0
        'xlWorkBook.Worksheets(1).PageSetup.PrintOut()                                                                        ' Immediate printout does work.
    End Sub

    Private Sub OpenExcelSpreadsheet()
        Dim xlApp As Excel.Application
        'Set to new instance of excel
        xlApp = New Excel.Application
        xlApp.Visible = True
        xlApp.WindowState = Excel.XlWindowState.xlMaximized
        Dim xlWorkBook As Excel.Workbook = xlApp.Workbooks.Open(XLFileName)
        Me.Close()
    End Sub

    Private Sub xlWorkSheet3Setup()
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

    Private Sub ReadSupplier()
        SVDC = New SupplierViewDataContext
        SupplierViewBindingSource.DataSource = From SupplierView In SVDC.SupplierViews Where SupplierView.RecordId = InvoiceViewRow.SupplierRecordId
        SupplierViewRow = SupplierViewBindingSource.Current
    End Sub

End Class