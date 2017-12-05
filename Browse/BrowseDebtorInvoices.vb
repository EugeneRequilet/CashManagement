Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseDebtorInvoices

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "IncomeTrans " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim CVDC As CashUpViewDataContext
    Dim CashupViewRow As CashupView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Dim CashupBFwdBal As Decimal

    Private Sub BrowseDebtorInvoices_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub BrowseDebtorInvoices_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'GlobalDateFrom = (DateSerial(Year(Today), Month(Today), 1))
        'GlobalDateTo = (DateSerial(Year(Today), Month(Today) + 1, 0)).ToString
        DisplayGlobalFromToDates()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            DebtorGrid1.DeleteRow()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        DebtorGrid1.ChangeRow()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateDebtorTransForm(-1)
            frm.ShowDialog()
            DebtorGrid1.LoadData()
        End Using
    End Sub

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        ProcessSpreadSheet()
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
        DebtorGrid1.LoadData()
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

            .Range("A2").Value = "Income Transactions"
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Transactions From " & GlobalDateFrom.ToString("dd MMM yyyy") & " to " & GlobalDateTo.ToString("dd MMM yyyy")
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 16

            .Range("A5").Value = "Day Of Week"
            .Range("B5").Value = "Date"
            .Range("C5").Value = "Type"
            .Range("D5").Value = "Invoice / Payment"
            .Range("E5").Value = "Payment Type"
            .Range("F5").Value = "Memo"
            .Range("G5").Value = "Employee"

            .Range("A5:F5").Font.Bold = True
            .Range("A5:F5").Font.Size = 9
            .Range("A5:F5").WrapText = True
            .Range("A5:F5").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 6
            .Range("B5").ColumnWidth = 10
            .Range("C5").ColumnWidth = 20
            .Range("D5").ColumnWidth = 11
            .Range("E5").ColumnWidth = 12
            .Range("F5").ColumnWidth = 30
            .Range("G5").ColumnWidth = 20
            .Range("A5:G5").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer

        '        GetBalanceBFwd()

        Dim SQL = "Select * From CashUpView Where Date >= '" &
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" &
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") &
                        "' And SalesType = 1 Order by date, RecordId"
        Try
            CVDC = New CashUpViewDataContext
            CashupViewBindingSource.DataSource = CVDC.ExecuteQuery(Of CashupView)(SQL)
        Catch ex As Exception
            MessageBox.Show("Cashup Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        SpreadsheetLine = 5

        With xlWorkSheet
            .Range("A5:Z5000").Font.Bold = False
            .Range("A5:Z5000").Font.Size = 11
        End With

        If CashupBFwdBal <> 0.0 Then
            SpreadsheetLine += 1
            LineNoString = SpreadsheetLine
            CellString = "C" & LineNoString
            With xlWorkSheet
                CellString = "C" & LineNoString
                .Range(CellString).Value = "B/Fwd"
                CellString = "D" & LineNoString
                .Range(CellString).Value = CashupBFwdBal

                CellString = "A" & LineNoString & ":G" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                CellString = "A" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "D" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With
        End If
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
                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = Mid(CashupViewRow.Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = Format(CashupViewRow.Date, "dd MMM yy")
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = CashupViewRow.SalesTypeDesc
                    CellString = "D" & LineNoString
                    If CashupViewRow.CashInTillLessFloat <> 0 Then .Range(CellString).Value = CashupViewRow.CashInTillLessFloat
                    CellString = "E" & LineNoString
                    .Range(CellString).Value = CashupViewRow.PaymentTypeDesc
                    CellString = "F" & LineNoString
                    .Range(CellString).Value = CashupViewRow.PayoutReason1
                    CellString = "G" & LineNoString
                    .Range(CellString).Value = CashupViewRow.EmployeeName

                    CellString = "A" & LineNoString & ":G" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "A" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "D" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                End With
            End If
            CashupViewBindingSource.MoveNext()
            If SpreadsheetLine > 5000 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        CellString = "A5:G" & LineNoString
        xlWorkSheet.Range(CellString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)

        'Write the Footer First Line

        SpreadsheetLine += 2
        LineNoString = SpreadsheetLine

        With xlWorkSheet

            CellString = "B" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "D" & LineNoString
            FormulaString = "=SUBTOTAL(9,D5:D" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,E4:E34)"

            CellString = "B" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "D" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":G" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            LineNoString = SpreadsheetLine
            CellString = "F4:G" & LineNoString
            xlWorkSheet.Range(CellString).Columns.AutoFit()
            xlWorkSheet.Range("C6").Select()
            .ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            .Visible = True
        End With
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
        CashupBFwdBal = 0
        'Dim SQL = "Select 0 AS Recordid, SUM(CASE WHEN InvoiceView.DocumentType = 'I' THEN InvoiceView.Amount ELSE (InvoiceView.Amount * -1) END) AS Amount From InvoiceView Where Date < '" &
        '                DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") &
        '                "' And SupplierRecordId = " & GlobalSupplierLookupRecordId &
        '                " Group by SupplierRecordId"
        Dim SQL = "Select 0 AS Recordid, (ISNULL(SUM(CashInTillLessFloat),0)) From CashupView Where Date < '" &
                            DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "'"
        Try
            CVDC = New CashUpViewDataContext
            CashupViewBindingSource.DataSource = CVDC.ExecuteQuery(Of CashupView)(SQL)
        Catch ex As Exception
            If Err.Number = 5 Then Exit Sub ' Procedure call or argument is not valid
            MessageBox.Show("InvoiceView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        CashupViewBindingSource.MoveFirst()
        Try
            CashupViewRow = CashupViewBindingSource.Current
        Catch ex As Exception
            If CashupViewRow Is Nothing Then Exit Try
            ' If Err.Number = 5 Then Exit Try ' Procedure call or argument is not valid
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        If CashupViewRow IsNot Nothing Then
            If CashupViewRow.CashInTillLessFloat IsNot Nothing Then CashupBFwdBal = CashupViewRow.CashInTillLessFloat
        End If
    End Sub

End Class