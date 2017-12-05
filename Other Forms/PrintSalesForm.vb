Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class PrintSalesForm

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Sales " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim DC As SalesViewDataContext
    Dim SalesViewRow As SalesView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Private Sub PrintSalesForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim SQLString As String
        SQLString = "Select * From SalesView Where Date >= '" &
            DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' and Date <= '" &
            DateTime.Parse(txtDateTo.Text).ToString("dd MMM yyyy") &
            "' And SalesType = 0 Order by date"
        Try
            Dim SQL = SQLString
            DC = New SalesViewDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of SalesView)(SQL)
        Catch ex As Exception
            MessageBox.Show("SalesView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        XLFileName = "Sales " & Format(txtDateTo.Value, "yyyy-MM")
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
        'Add data to cells of the first worksheet in the new workbook

        'xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        Try
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        Catch ex As Exception
            xlWorkSheet = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        End Try

        With xlWorkSheet
            .Range("A1:Z3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20
            .Range("A2").Value = "Daily Cash-up From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A4").Value = "Day"
            .Range("B4").Value = "Date"
            .Range("C4").Value = "Gross Sales"
            .Range("D4").Value = "Payout"
            .Range("E4").Value = "Turnover Cash"
            .Range("F4").Value = "Turnover Credit Card"
            .Range("G4").Value = "Overbake"
            .Range("H4").Value = "Wastage"
            .Range("I4").Value = "Damage"
            .Range("J4").Value = "Staff"
            .Range("K4").Value = "Discount @ 20%"
            .Range("L4").Value = "Sample"
            .Range("M4").Value = "Stock Variance"
            .Range("N4").Value = "Employee"

            .Range("A4:N4").Font.Bold = True
            .Range("A4:N4").Font.Size = 9
            .Range("A4:N4").WrapText = True
            .Range("A4:N4").HorizontalAlignment = Excel.Constants.xlCenter
            .Range("A4:N4").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A4").ColumnWidth = 6
            .Range("B4").ColumnWidth = 10
            .Range("C4:M4").ColumnWidth = 11
            .Range("N4").ColumnWidth = 30

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        SpreadsheetLine = 4

        With xlWorkSheet
            .Range("A5:Z400").Font.Bold = False
            .Range("A5:Z400").Font.Size = 11
        End With

        ' Loop through the data and create the spreadsheet body 

        BindingSource1.MoveFirst()
        Do
            Try
                SalesViewRow = BindingSource1.Current
            Catch ex As Exception
                Exit Do
            End Try
            If SalesViewRow IsNot Nothing Then
                If CurrentRecordId = SalesViewRow.RecordId Then Exit Do
                CurrentRecordId = SalesViewRow.RecordId

                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = Mid(SalesViewRow.Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = Format(SalesViewRow.Date, "dd MMM yy")
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = SalesViewRow.GrossSales
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = SalesViewRow.Payout
                    CellString = "E" & LineNoString
                    .Range(CellString).Value = SalesViewRow.TurnoverCash
                    CellString = "F" & LineNoString
                    .Range(CellString).Value = SalesViewRow.TurnoverCreditCard
                    CellString = "G" & LineNoString
                    .Range(CellString).Value = SalesViewRow.OverbakePercent100
                    CellString = "H" & LineNoString
                    .Range(CellString).Value = SalesViewRow.WastagePercent100
                    CellString = "I" & LineNoString
                    .Range(CellString).Value = SalesViewRow.DamagePercent100
                    CellString = "J" & LineNoString
                    .Range(CellString).Value = SalesViewRow.StaffPercent100
                    CellString = "K" & LineNoString
                    .Range(CellString).Value = SalesViewRow.DiscountPercent20
                    CellString = "L" & LineNoString
                    .Range(CellString).Value = SalesViewRow.SamplePercent100
                    CellString = "M" & LineNoString
                    .Range(CellString).Value = SalesViewRow.StockVarianceValue
                    CellString = "N" & LineNoString
                    .Range(CellString).Value = SalesViewRow.EmployeeName

                    CellString = "A" & LineNoString & ":N" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "C" & LineNoString & ":M" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                    CellString = "N" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                End With
            End If
            BindingSource1.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        SpreadsheetLine += 2
        LineNoString = SpreadsheetLine

        With xlWorkSheet

            CellString = "B" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C5:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "D" & LineNoString
            FormulaString = "=SUM(D5:D" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "E" & LineNoString
            FormulaString = "=SUM(E5:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "F" & LineNoString
            FormulaString = "=SUM(F5:F" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "G" & LineNoString
            FormulaString = "=SUM(G5:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "H" & LineNoString
            FormulaString = "=SUM(H5:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "I" & LineNoString
            FormulaString = "=SUM(I5:I" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "J" & LineNoString
            FormulaString = "=SUM(J5:J" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "K" & LineNoString
            FormulaString = "=SUM(K5:K" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "L" & LineNoString
            FormulaString = "=SUM(L5:L" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "M" & LineNoString
            FormulaString = "=SUM(M5:M" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"

            CellString = "B" & LineNoString & ":M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Font.Bold = True
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            'LineNoString = SpreadsheetLine
            'CellString = "A4:Q" & LineNoString
            'xlWorkSheet.Range(CellString).Columns.AutoFit()
            xlWorkSheet.Range("C5").Select()
            .ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            .Visible = True
        End With
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

End Class