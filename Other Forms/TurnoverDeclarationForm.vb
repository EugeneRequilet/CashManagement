Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class TurnoverDeclarationForm

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Turnover " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SDC As SalesDataContext
    Dim SalesRow As Sales

    Dim TotalTurnover As Decimal
    Dim TradingDays As Integer

    Private Sub TurnoverDeclarationForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setDropdowns()
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
        txtDateFrom.Text = (DateSerial(Year(Today), Month(Today), 1)).ToString
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

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        CheckForFileAndContinue()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub CheckForFileAndContinue()
        XLFileName = "Turnover " & Format(txtDateTo.Value, "yyyy-MM")
        CreateExcelWorkbook()
        SetupData()
        WriteReport()
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

    Private Sub WriteReport()
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

            .Range("A2").Value = "Turnover Declaration From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A4").Value = "No"
            .Range("B4").Value = "Details"
            .Range("C4").Value = "Excl VAT"
            .Range("D4").Value = "Incl VAT"

            .Range("A4:D4").Font.Bold = True
            .Range("A4:D4").Font.Size = 9
            .Range("A4:D4").HorizontalAlignment = Excel.Constants.xlCenter

            .Range("A5").Value = "1"
            .Range("B5").Value = "Gross Sales"
            .Range("C5").Value = (TotalTurnover / 1.14)
            .Range("D5").Value = TotalTurnover
            .Range("A6").Value = "2"
            .Range("B6").Value = "Trading Days"
            .Range("C6").Value = TradingDays
            .Range("A7").Value = "3"
            .Range("B7").Value = "Daily Average on Turnover"
            .Range("C7").Formula = "=IF(C6<>0,C5/C6,0)"
            .Range("D7").Formula = "=IF(C6<>0,D5/C6,0)"
            .Range("A9").Value = "4"
            .Range("B9").Value = "Royalties payable on above at 2%:"
            .Range("C9").Formula = "=C5*0.02"
            .Range("D9").Formula = "=C9*1.14"
            .Range("A10").Value = "5"
            .Range("B10").Value = "Advertising payable on above at 1%:"
            .Range("C10").Formula = "=C5*0.01"
            .Range("D10").Formula = "=C10*1.14"

            .Range("B12").Value = "The above sales figures are certified by me to be correct."
            .Range("A15").Value = "Name:"
            .Range("B15").Value = "___________________________________________"
            .Range("A16").Value = "Date:"
            .Range("B16").Value = DateTime.Now.ToString("D")
            .Range("A12:B16").HorizontalAlignment = Excel.Constants.xlLeft
            .Range("A12:B16").Font.Bold = True

            .Range("A5:D16").Font.Size = 11
            .Range("A5:A16").HorizontalAlignment = Excel.Constants.xlCenter
            .Range("C5:D10").NumberFormat = "#,###,##0.00"
            .Range("C6:D6").NumberFormat = "#,###,##0"
            .Range("C5:C10").HorizontalAlignment = Excel.Constants.xlRight

            .Range("A4:A4").ColumnWidth = 6
            .Range("B4:B4").ColumnWidth = 50
            .Range("C4:D4").ColumnWidth = 11

            .Range("A4:D10").Borders.LineStyle = Excel.Constants.xlSolid
        End With
    End Sub

    Private Sub SetupData()
        Dim CurrentRecordId As Integer

        TotalTurnover = 0.0
        TradingDays = 0

        Dim SQLString As String = "Select * From Sales Where Date >= '" & DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' and Date <= '" & DateTime.Parse(txtDateTo.Text).ToString("dd MMM yyyy") & "' Order by Date"
        Try
            Dim SQL = SQLString
            SDC = New SalesDataContext
            SalesBindingSource.DataSource = SDC.ExecuteQuery(Of Sales)(SQL)
        Catch ex As Exception
            MessageBox.Show("Sales Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        SalesBindingSource.MoveFirst()
        Do
            Try
                SalesRow = SalesBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If SalesRow IsNot Nothing Then
                If CurrentRecordId = SalesRow.RecordId Then Exit Do
                CurrentRecordId = SalesRow.RecordId
                TotalTurnover += SalesRow.GrossSales
                TradingDays += 1
            End If
            SalesBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            'xlWorkSheet.Range("C4").Select()
            '.ActiveWindow.FreezePanes = True
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
            .Orientation = Excel.XlPageOrientation.xlPortrait                                   ' .xlPortrait .xlLandscape               ' '1 = xlPortrait; 2 = xlLandscape
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
            '.FitToPagesWide = 1
            '.FitToPagesTall = 1
        End With
    End Sub

End Class