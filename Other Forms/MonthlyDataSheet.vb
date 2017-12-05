Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class MonthlyDataSheet

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet1 As Excel.Worksheet
    Dim xlWorkSheet2 As Excel.Worksheet
    Dim xlWorkSheet3 As Excel.Worksheet
    Dim xlWorkSheet4 As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Monthly " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SDC As SalesDataContext
    Dim SalesRow As Sales
    Dim IDC As InvoiceDataContext
    Dim InvoiceRow As Invoice

    Dim CashupTotalSales(0 To 11) As Decimal
    Dim CostOfSales(0 To 11) As Decimal
    Dim Expenses(0 To 11) As Decimal
    Dim TransCount(0 To 11) As Integer
    Dim VoidCount(0 To 11) As Integer
    Dim VoidValue(0 To 11) As Decimal
    Dim ErrorCount(0 To 11) As Integer
    Dim ErrorValue(0 To 11) As Decimal

    Dim LastYearCashupTotalSales(0 To 11) As Decimal
    Dim LastYearCostOfSales(0 To 11) As Decimal
    Dim LastYearExpenses(0 To 11) As Decimal
    Dim LastYearTransCount(0 To 11) As Integer
    Dim LastYearVoidCount(0 To 11) As Integer
    Dim LastYearVoidValue(0 To 11) As Decimal
    Dim LastYearErrorCount(0 To 11) As Integer
    Dim LastYearErrorValue(0 To 11) As Decimal

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Private Sub MonthlyDataSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtAdjustmentAmount.EditValue = 15.0
        setDropdowns()

        ' Set the default directory of the folder browser to the current directory.
        ' txtXLDirectory.Text = My.Computer.FileSystem.CurrentDirectory
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
        cboDateRange.Items.Add("This Year")
        cboDateRange.Items.Add("Last Year")
        cboDateRange.SelectedIndex = 0
        cboVATIndicator.Items.Clear()
        cboVATIndicator.Items.Add("VAT Included")
        cboVATIndicator.Items.Add("VAT Excluded")
        cboVATIndicator.SelectedIndex = 0
        setDatesFromDropdown()
    End Sub

    Private Sub setDatesFromDropdown()
        Select Case cboDateRange.SelectedIndex
            Case 0
                If Today.Month <= 12 Then
                    txtDateFrom.Text = (DateSerial(Year(Today), 3, 1)).ToString
                    txtDateTo.Text = (DateSerial(Year(Today) + 1, 3, 0)).ToString
                Else
                    txtDateFrom.Text = (DateSerial((Year(Today) - 1), 3, 1)).ToString
                    txtDateTo.Text = (DateSerial(Year(Today), 3, 0)).ToString
                End If
            Case 1
                If Today.Month <= 12 Then
                    txtDateFrom.Text = (DateSerial((Year(Today) - 1), 3, 1)).ToString
                    txtDateTo.Text = (DateSerial(Year(Today), 3, 0)).ToString
                Else
                    txtDateFrom.Text = (DateSerial((Year(Today) - 2), 3, 1)).ToString
                    txtDateTo.Text = (DateSerial((Year(Today) - 1), 3, 0)).ToString
                End If
        End Select
    End Sub

    Private Sub cboDateRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDateRange.SelectedIndexChanged
        setDatesFromDropdown()
    End Sub

    Private Sub ExportExcelButton_Click(sender As Object, e As EventArgs) Handles ExportExcelButton.Click
        CheckForFileAndContinue()
    End Sub

    Private Sub OpenExcelButton_Click(sender As Object, e As EventArgs) Handles OpenExcelButton.Click
        XLFileName = GetFileName(4, 0)
        If XLFileName Is Nothing Or XLFileName = "" Then Exit Sub
        OpenExcelSpreadsheet()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub CheckForFileAndContinue()
        XLFileName = "Monthly " & Format(txtDateTo.Value, "yyyy-MM")
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

        'xlWorkSheet1 = xlWorkBook.Sheets("Sheet1")
        'xlWorkSheet2 = xlWorkBook.Sheets("Sheet2")
        'xlWorkSheet3 = xlWorkBook.Sheets("Sheet3")
        'xlWorkSheet4 = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        'xlWorkSheet4 = xlWorkBook.Sheets("Sheet4")
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
        Try
            xlWorkSheet4 = xlWorkBook.Sheets("Sheet4")
        Catch ex As Exception
            xlWorkSheet4 = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        End Try
        xlWorkBook.Sheets("Sheet1").Name = "Gross"
        xlWorkBook.Sheets("Sheet2").Name = "Transactions"
        xlWorkBook.Sheets("Sheet3").Name = "Voids"
        xlWorkBook.Sheets("Sheet4").Name = "Error Corrects"

        With xlWorkSheet1
            .Range("A1:Z500").Font.Name = "Calibri"
            .Range("A1:Z500").Font.Bold = False
            .Range("A1:Z500").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            Dim HeadingText As String = "Monthly Gross Information From " & txtDateFrom.Text & " to " & txtDateTo.Text
            If txtAdjustmentAmount.EditValue Then
                HeadingText = HeadingText & " - Last year Plus " & txtAdjustmentAmount.EditValue.ToString & "%"
            End If
            If cboVATIndicator.SelectedIndex = 0 Then
                HeadingText = HeadingText & " - Including VAT"
            Else
                HeadingText = HeadingText & " - Excluding VAT"
            End If
            .Range("A2").Value = HeadingText
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Month"
            .Range("B3").Value = "Gross Sales"
            If txtAdjustmentAmount.EditValue Then
                .Range("C3").Value = "Gross Sales L/Y Adjusted"
            Else
                .Range("C3").Value = "Gross Sales Last Year"
            End If
            .Range("D3").Value = "Difference"
            .Range("E3").Value = "Difference %"

            .Range("G3").Value = "Cost Of Sales"
            If txtAdjustmentAmount.EditValue Then
                .Range("H3").Value = "COS L/Y Adjusted"
            Else
                .Range("H3").Value = "COS Last Year"
            End If
            .Range("I3").Value = "Difference"
            .Range("J3").Value = "Difference %"

            .Range("L3").Value = "Gross Profit"
            If txtAdjustmentAmount.EditValue Then
                .Range("M3").Value = "Gross Profit L/Y Adj"
            Else
                .Range("M3").Value = "Gross Profit Last Year"
            End If
            .Range("N3").Value = "Difference"
            .Range("O3").Value = "Difference %"

            .Range("Q3").Value = "GP %"
            .Range("R3").Value = "GP % Last Year"

            .Range("T3").Value = "Expenses"
            If txtAdjustmentAmount.EditValue Then
                .Range("U3").Value = "Expenses L/Y Adjusted"
            Else
                .Range("U3").Value = "Expenses Last Year"
            End If
            .Range("V3").Value = "Difference"
            .Range("W3").Value = "Difference %"

            .Range("Y3").Value = "Nett Profit"
            If txtAdjustmentAmount.EditValue Then
                .Range("Z3").Value = "Nett Profit L/Y Adj"
            Else
                .Range("Z3").Value = "Nett Profit Last Year"
            End If
            .Range("AA3").Value = "Difference"
            .Range("AB3").Value = "Difference %"

            .Range("A3:AB3").Font.Bold = True
            .Range("A3:AB3").Font.Size = 9
            .Range("A3:AB3").WrapText = True
            .Range("A3:AB3").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 11
            .Range("B3:D3").ColumnWidth = 12
            .Range("E3").ColumnWidth = 10
            .Range("F3").ColumnWidth = 3
            .Range("G3:I3").ColumnWidth = 12
            .Range("J3").ColumnWidth = 10
            .Range("K3").ColumnWidth = 3
            .Range("L3:N3").ColumnWidth = 12
            .Range("O3").ColumnWidth = 10
            .Range("P3").ColumnWidth = 3
            .Range("Q3:R3").ColumnWidth = 8

            .Range("S3").ColumnWidth = 3
            .Range("T3:V3").ColumnWidth = 12
            .Range("W3").ColumnWidth = 10
            .Range("X3").ColumnWidth = 3
            .Range("Y3:AA3").ColumnWidth = 12
            .Range("AB3").ColumnWidth = 10

            .Range("A3:E3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("G3:J3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("L3:O3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("Q3:R3").Borders.LineStyle = Excel.Constants.xlSolid

            .Range("T3:W3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("Y3:AB3").Borders.LineStyle = Excel.Constants.xlSolid
        End With

        With xlWorkSheet2
            .Range("A1:Z500").Font.Name = "Calibri"
            .Range("A1:Z500").Font.Bold = False
            .Range("A1:Z500").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Monthly Transaction Counts From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Month"
            .Range("B3").Value = "Trans Count"
            If txtAdjustmentAmount.EditValue Then
                .Range("C3").Value = "Trans Count L/Y Adjusted"
            Else
                .Range("C3").Value = "Trans Count L/Y"
            End If
            .Range("D3").Value = "Difference"
            .Range("E3").Value = "Difference %"

            .Range("G3").Value = "Spend Per Head"
            If txtAdjustmentAmount.EditValue Then
                .Range("H3").Value = "Spend Per Head L/Y Adjusted"
            Else
                .Range("H3").Value = "Spend Per Head L/Y"
            End If
            .Range("I3").Value = "Difference"
            .Range("J3").Value = "Difference %"

            .Range("A3:Z3").Font.Bold = True
            .Range("A3:Z3").Font.Size = 9
            .Range("A3:Z3").WrapText = True
            .Range("A3:Z3").HorizontalAlignment = Excel.Constants.xlCenter

            .Range("A3:E3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("G3:J3").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 11
            .Range("D3:E3").ColumnWidth = 12
            .Range("F3").ColumnWidth = 3
            .Range("G3:J3").ColumnWidth = 12
        End With

        With xlWorkSheet3
            .Range("A1:Z500").Font.Name = "Calibri"
            .Range("A1:Z500").Font.Bold = False
            .Range("A1:Z500").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Monthly Void Counts From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Month"
            .Range("B3").Value = "No Of Voids"
            If txtAdjustmentAmount.EditValue Then
                .Range("C3").Value = "No Of Voids L/Y Adjusted"
            Else
                .Range("C3").Value = "No Of Voids L/Y"
            End If
            .Range("D3").Value = "Difference"
            .Range("E3").Value = "Difference %"

            .Range("G3").Value = "Voids Value"
            If txtAdjustmentAmount.EditValue Then
                .Range("H3").Value = "Voids Value L/Y Adjusted"
            Else
                .Range("H3").Value = "Voids Value L/Y"
            End If
            .Range("I3").Value = "Difference"
            .Range("J3").Value = "Difference %"

            .Range("A3:Z3").Font.Bold = True
            .Range("A3:Z3").Font.Size = 9
            .Range("A3:Z3").WrapText = True
            .Range("A3:Z3").HorizontalAlignment = Excel.Constants.xlCenter

            .Range("A3:E3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("G3:J3").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 11
            .Range("D3:E3").ColumnWidth = 12
            .Range("F3").ColumnWidth = 3
            .Range("G3:J3").ColumnWidth = 12
        End With

        With xlWorkSheet4
            .Range("A1:Z500").Font.Name = "Calibri"
            .Range("A1:Z500").Font.Bold = False
            .Range("A1:Z500").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Monthly Error Corrects Count From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Month"
            .Range("B3").Value = "No Of Error Corrects"
            If txtAdjustmentAmount.EditValue Then
                .Range("C3").Value = "Error Corrects L/Y Adjusted"
            Else
                .Range("C3").Value = "Error Corrects L/Y"
            End If
            .Range("D3").Value = "Difference"
            .Range("E3").Value = "Difference %"

            .Range("G3").Value = "Error Corrects Value"
            If txtAdjustmentAmount.EditValue Then
                .Range("H3").Value = "Error Corrects Value L/Y Adjusted"
            Else
                .Range("H3").Value = "Error Corrects Value L/Y"
            End If
            .Range("I3").Value = "Difference"
            .Range("J3").Value = "Difference %"

            .Range("A3:Z3").Font.Bold = True
            .Range("A3:Z3").Font.Size = 9
            .Range("A3:Z3").WrapText = True
            .Range("A3:Z3").HorizontalAlignment = Excel.Constants.xlCenter

            .Range("A3:E3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("G3:J3").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 11
            .Range("D3:E3").ColumnWidth = 12
            .Range("F3").ColumnWidth = 3
            .Range("G3:J3").ColumnWidth = 12
        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim isZeroSales As Boolean
        Dim isZeroCOS As Boolean
        Dim isZeroExpenses As Boolean
        Dim MonthName As String
        Dim Amount1 As Decimal
        Dim Amount2 As Decimal

        getSalesFigures()
        getCOSFigures()
        getExpenseFigures()

        SpreadsheetLine = 3

        For MonthLoop As Integer = 0 To 11
            SpreadsheetLine += 1
            LineNoString = SpreadsheetLine

            Select Case MonthLoop
                Case 0
                    MonthName = "March"
                Case 1
                    MonthName = "April"
                Case 2
                    MonthName = "May"
                Case 3
                    MonthName = "June"
                Case 4
                    MonthName = "July"
                Case 5
                    MonthName = "August"
                Case 6
                    MonthName = "September"
                Case 7
                    MonthName = "October"
                Case 8
                    MonthName = "November"
                Case 9
                    MonthName = "December"
                Case 10
                    MonthName = "January"
                Case 11
                    MonthName = "February"
                Case Else
                    MonthName = "Month Error"
            End Select

            With xlWorkSheet1
                CellString = "A" & LineNoString
                .Range(CellString).Value = MonthName
                isZeroSales = False
                CellString = "B" & LineNoString
                If CashupTotalSales(MonthLoop) Then
                    .Range(CellString).Value = CashupTotalSales(MonthLoop)
                Else
                    isZeroSales = True
                End If
                CellString = "C" & LineNoString
                If LastYearCashupTotalSales(MonthLoop) Then
                    .Range(CellString).Value = (LastYearCashupTotalSales(MonthLoop) + Math.Round((LastYearCashupTotalSales(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                Else
                    isZeroSales = True
                End If
                If isZeroSales = False Then
                    CellString = "D" & LineNoString
                    FormulaString = "=B" & LineNoString & "-C" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "E" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                isZeroCOS = False
                CellString = "G" & LineNoString
                If CostOfSales(MonthLoop) Then
                    .Range(CellString).Value = CostOfSales(MonthLoop)
                Else
                    isZeroCOS = True
                End If
                CellString = "H" & LineNoString
                If LastYearCostOfSales(MonthLoop) Then
                    .Range(CellString).Value = (LastYearCostOfSales(MonthLoop) + Math.Round((LastYearCostOfSales(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                Else
                    isZeroCOS = True
                End If
                If isZeroCOS = False Then
                    CellString = "I" & LineNoString
                    FormulaString = "=G" & LineNoString & "-H" & LineNoString                                               ' "=F4-G4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "J" & LineNoString
                    FormulaString = "=IF(H" & LineNoString & "<>0,I" & LineNoString & "/H" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                If isZeroSales = False And isZeroCOS = False Then
                    CellString = "L" & LineNoString
                    FormulaString = "=B" & LineNoString & "-G" & LineNoString                                               ' "=B4-F4"
                    .Range(CellString).Formula = FormulaString
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
                End If
                If isZeroSales = False And isZeroCOS = False Then
                    CellString = "M" & LineNoString
                    FormulaString = "=C" & LineNoString & "-H" & LineNoString                                               ' "=C4-G4"
                    .Range(CellString).Formula = FormulaString
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
                End If
                If isZeroSales = False And isZeroCOS = False Then
                    CellString = "N" & LineNoString
                    FormulaString = "=L" & LineNoString & "-M" & LineNoString                                               ' "=J4-K4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "O" & LineNoString
                    FormulaString = "=If(M" & LineNoString & "<>0,N" & LineNoString & "/M" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

                    CellString = "Q" & LineNoString
                    FormulaString = "=IF(B" & LineNoString & "<>0,(100-ROUND(G" & LineNoString & "/B" & LineNoString & "*100,2)),0)"
                    .Range(CellString).Formula = FormulaString
                    CellString = "R" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,(100-ROUND(H" & LineNoString & "/C" & LineNoString & "*100,2)),0)"
                    .Range(CellString).Formula = FormulaString
                    CellString = "Q" & LineNoString & ":R" & LineNoString
                    If .Range("Q" & LineNoString).Value < .Range("R" & LineNoString).Value Then
                        .Range(CellString).Interior.Color = Color.LightPink
                    Else
                        .Range(CellString).Interior.Color = Color.LightGreen
                    End If
                End If

                isZeroExpenses = False
                CellString = "T" & LineNoString
                If Expenses(MonthLoop) Then
                    .Range(CellString).Value = Expenses(MonthLoop)
                Else
                    isZeroExpenses = True
                End If
                CellString = "U" & LineNoString
                If LastYearExpenses(MonthLoop) Then
                    .Range(CellString).Value = (LastYearExpenses(MonthLoop) + Math.Round((LastYearExpenses(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                Else
                    isZeroExpenses = True
                End If
                If isZeroExpenses = False Then
                    CellString = "V" & LineNoString
                    FormulaString = "=T" & LineNoString & "-U" & LineNoString                                               ' "=F4-G4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "W" & LineNoString
                    FormulaString = "=IF(U" & LineNoString & "<>0,V" & LineNoString & "/U" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                If isZeroSales = False Then
                    CellString = "Y" & LineNoString
                    FormulaString = "=L" & LineNoString & "-T" & LineNoString                                               ' "=J4-K4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "Z" & LineNoString
                    FormulaString = "=M" & LineNoString & "-U" & LineNoString                                               ' "=J4-K4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

                    CellString = "AA" & LineNoString
                    FormulaString = "=Y" & LineNoString & "-Z" & LineNoString                                               ' "=J4-K4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

                    CellString = "AB" & LineNoString
                    FormulaString = "=IF(Z" & LineNoString & "<>0,AA" & LineNoString & "/Z" & LineNoString & "*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                CellString = "A" & LineNoString & ":E" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "G" & LineNoString & ":J" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "L" & LineNoString & ":O" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "Q" & LineNoString & ":R" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "T" & LineNoString & ":W" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "Y" & LineNoString & ":AB" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid


                CellString = "A" & LineNoString & ":AB" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "B" & LineNoString & ":AB" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With

            With xlWorkSheet2

                ' Transaction Count And Transaction Value

                CellString = "A" & LineNoString
                .Range(CellString).Value = MonthName
                isZeroSales = False
                CellString = "B" & LineNoString
                If TransCount(MonthLoop) Then
                    .Range(CellString).Value = TransCount(MonthLoop)
                Else
                    isZeroSales = True
                End If
                CellString = "C" & LineNoString
                If LastYearTransCount(MonthLoop) Then
                    .Range(CellString).Value = (LastYearTransCount(MonthLoop) + Math.Round((LastYearTransCount(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                Else
                    isZeroSales = True
                End If
                If isZeroSales = False Then
                    CellString = "D" & LineNoString
                    FormulaString = "=B" & LineNoString & "-C" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "E" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                isZeroSales = False
                CellString = "G" & LineNoString
                If (TransCount(MonthLoop) <> 0.0) And (CashupTotalSales(MonthLoop) <> 0.0) Then
                    .Range(CellString).Value = (CashupTotalSales(MonthLoop) / TransCount(MonthLoop))
                Else
                    isZeroSales = True
                End If
                CellString = "H" & LineNoString
                Amount1 = (LastYearTransCount(MonthLoop) + Math.Round((LastYearTransCount(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                Amount2 = (LastYearCashupTotalSales(MonthLoop) + Math.Round((LastYearCashupTotalSales(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                If (Amount1 <> 0.0) And (Amount2 <> 0.0) Then
                    .Range(CellString).Value = ((Amount2 / Amount1) + Math.Round(((Amount2 / Amount1) * txtAdjustmentAmount.EditValue / 100), 2))
                Else
                    isZeroSales = True
                End If
                If isZeroSales = False Then
                    CellString = "I" & LineNoString
                    FormulaString = "=G" & LineNoString & "-H" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "J" & LineNoString
                    FormulaString = "=IF(H" & LineNoString & "<>0,I" & LineNoString & "/H" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                CellString = "A" & LineNoString & ":E" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "G" & LineNoString & ":J" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "A" & LineNoString & ":Z" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "B" & LineNoString & ":D" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0"
                CellString = "E" & LineNoString & ":J" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With

            With xlWorkSheet3

                ' Void count and Values

                CellString = "A" & LineNoString
                .Range(CellString).Value = MonthName
                isZeroSales = False
                CellString = "B" & LineNoString
                If VoidCount(MonthLoop) Then
                    .Range(CellString).Value = VoidCount(MonthLoop)
                Else
                    isZeroSales = True
                End If
                CellString = "C" & LineNoString
                If LastYearVoidCount(MonthLoop) Then
                    .Range(CellString).Value = (LastYearVoidCount(MonthLoop) + Math.Round((LastYearVoidCount(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                Else
                    isZeroSales = True
                End If
                If isZeroSales = False Then
                    CellString = "D" & LineNoString
                    FormulaString = "=B" & LineNoString & "-C" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "E" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                isZeroSales = False
                CellString = "G" & LineNoString
                If (VoidValue(MonthLoop) <> 0.0) Then
                    .Range(CellString).Value = VoidValue(MonthLoop)
                Else
                    isZeroSales = True
                End If
                CellString = "H" & LineNoString
                If (LastYearVoidValue(MonthLoop) <> 0.0) Then
                    .Range(CellString).Value = (LastYearVoidValue(MonthLoop) + Math.Round((LastYearVoidValue(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                Else
                    isZeroSales = True
                End If
                If isZeroSales = False Then
                    CellString = "I" & LineNoString
                    FormulaString = "=G" & LineNoString & "-H" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "J" & LineNoString
                    FormulaString = "=IF(H" & LineNoString & "<>0,I" & LineNoString & "/H" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                CellString = "A" & LineNoString & ":E" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "G" & LineNoString & ":J" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "A" & LineNoString & ":Z" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "B" & LineNoString & ":D" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0"
                CellString = "E" & LineNoString & ":J" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With

            With xlWorkSheet4

                ' Error Count and Value

                CellString = "A" & LineNoString
                .Range(CellString).Value = MonthName
                isZeroSales = False
                CellString = "B" & LineNoString
                If ErrorCount(MonthLoop) Then
                    .Range(CellString).Value = ErrorCount(MonthLoop)
                Else
                    isZeroSales = True
                End If
                CellString = "C" & LineNoString
                If LastYearErrorCount(MonthLoop) Then
                    .Range(CellString).Value = (LastYearErrorCount(MonthLoop) + Math.Round((LastYearErrorCount(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                Else
                    isZeroSales = True
                End If
                If isZeroSales = False Then
                    CellString = "D" & LineNoString
                    FormulaString = "=B" & LineNoString & "-C" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "E" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                isZeroSales = False
                CellString = "G" & LineNoString
                If (ErrorValue(MonthLoop) <> 0.0) Then
                    .Range(CellString).Value = ErrorValue(MonthLoop)
                Else
                    isZeroSales = True
                End If
                CellString = "H" & LineNoString
                If (LastYearErrorValue(MonthLoop) <> 0.0) Then
                    .Range(CellString).Value = (LastYearErrorValue(MonthLoop) + Math.Round((LastYearErrorValue(MonthLoop) * txtAdjustmentAmount.EditValue / 100), 2))
                Else
                    isZeroSales = True
                End If
                If isZeroSales = False Then
                    CellString = "I" & LineNoString
                    FormulaString = "=G" & LineNoString & "-H" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "J" & LineNoString
                    FormulaString = "=IF(H" & LineNoString & "<>0,I" & LineNoString & "/H" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                CellString = "A" & LineNoString & ":E" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "G" & LineNoString & ":J" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "A" & LineNoString & ":Z" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "B" & LineNoString & ":D" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0"
                CellString = "E" & LineNoString & ":J" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With
        Next
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        SpreadsheetLine += 2
        LineNoString = SpreadsheetLine

        With xlWorkSheet1
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Total"

            CellString = "B" & LineNoString
            FormulaString = "=SUM(B4:B" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(B4:B34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "D" & LineNoString
            FormulaString = "=B" & LineNoString & "-C" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "G" & LineNoString
            FormulaString = "=SUM(G4:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "H" & LineNoString
            FormulaString = "=SUM(H4:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "I" & LineNoString
            FormulaString = "=G" & LineNoString & "-H" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "L" & LineNoString
            FormulaString = "=SUM(L4:L" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(J4:HJ4)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "M" & LineNoString
            FormulaString = "=SUM(M4:M" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(K4:K34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "N" & LineNoString
            FormulaString = "=L" & LineNoString & "-M" & LineNoString                                               ' "=J4-K4"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(L4:L34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "T" & LineNoString
            FormulaString = "=SUM(T4:T" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(J4:HJ4)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "U" & LineNoString
            FormulaString = "=SUM(U4:U" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(K4:K34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "V" & LineNoString
            FormulaString = "=T" & LineNoString & "-U" & LineNoString                                               ' "=J4-K4"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(L4:L34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "Y" & LineNoString
            FormulaString = "=SUM(Y4:Y" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(J4:HJ4)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "Z" & LineNoString
            FormulaString = "=SUM(Z4:Z" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(K4:K34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "AA" & LineNoString
            FormulaString = "=Y" & LineNoString & "-Z" & LineNoString                                               ' "=J4-K4"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(L4:L34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":D" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":I" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "L" & LineNoString & ":N" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "T" & LineNoString & ":V" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "Y" & LineNoString & ":AA" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "A" & LineNoString & ":AB" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet2
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "B" & LineNoString
            FormulaString = "=SUM(B4:B" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(B4:B34)"
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(B4:B34)"
            CellString = "D" & LineNoString
            FormulaString = "=B" & LineNoString & "-C" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "G" & LineNoString
            FormulaString = "=SUM(G4:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "H" & LineNoString
            FormulaString = "=SUM(H4:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "I" & LineNoString
            FormulaString = "=G" & LineNoString & "-H" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":D" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":I" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":D" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "E" & LineNoString & ":U" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet3
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "B" & LineNoString
            FormulaString = "=SUM(B4:B" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(B4:B34)"
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            CellString = "D" & LineNoString
            FormulaString = "=B" & LineNoString & "-C" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "G" & LineNoString
            FormulaString = "=SUM(G4:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "H" & LineNoString
            FormulaString = "=SUM(H4:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "I" & LineNoString
            FormulaString = "=G" & LineNoString & "-H" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":D" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":I" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":D" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "E" & LineNoString & ":U" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet4
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "B" & LineNoString
            FormulaString = "=SUM(B4:B" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(B4:B34)"
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            CellString = "D" & LineNoString
            FormulaString = "=B" & LineNoString & "-C" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "G" & LineNoString
            FormulaString = "=SUM(G4:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "H" & LineNoString
            FormulaString = "=SUM(H4:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "I" & LineNoString
            FormulaString = "=G" & LineNoString & "-H" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":D" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":I" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":D" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "E" & LineNoString & ":U" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        'Write the Footer Second Line

        SpreadsheetLine += 1
        LineNoString = SpreadsheetLine

        With xlWorkSheet1
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Average"

            CellString = "B" & LineNoString
            ' FormulaString = "=IF(B" & (LineNoString - 1) & "<>0,B" & (LineNoString - 1) & "/COUNTA(B4:B" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(B" & (LineNoString - 1) & "<>0,B" & (LineNoString - 1) & "/COUNTIFS(B4:B" & (SpreadsheetLine - 3) & ",""<>0"",B4:B" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(B35<>0,B35/COUNTIF(B4:B34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "C" & LineNoString
            ' FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTA(C4:C" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTIFS(C4:C" & (SpreadsheetLine - 3) & ",""<>0"",C4:C" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "D" & LineNoString
            FormulaString = "=B" & LineNoString & "-C" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "E" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "G" & LineNoString
            ' FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/COUNTA(G4:G" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/COUNTIFS(G4:G" & (SpreadsheetLine - 3) & ",""<>0"",G4:G" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "H" & LineNoString
            ' FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/COUNTA(H4:H" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/COUNTIFS(H4:H" & (SpreadsheetLine - 3) & ",""<>0"",H4:H" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "I" & LineNoString
            FormulaString = "=G" & LineNoString & "-H" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "J" & LineNoString
            FormulaString = "=IF(H" & LineNoString & "<>0,I" & LineNoString & "/H" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "L" & LineNoString
            ' FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTA(L4:L" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTIFS(L4:L" & (SpreadsheetLine - 3) & ",""<>0"",L4:L" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(J35<>0,J35/COUNTIF(J4:J34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "M" & LineNoString
            ' FormulaString = "=IF(M" & (LineNoString - 1) & "<>0,M" & (LineNoString - 1) & "/COUNTA(M4:M" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(M" & (LineNoString - 1) & "<>0,M" & (LineNoString - 1) & "/COUNTIFS(M4:M" & (SpreadsheetLine - 3) & ",""<>0"",M4:M" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(K35<>0,K35/COUNTIF(K4:K34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "N" & LineNoString
            FormulaString = "=L" & LineNoString & "-M" & LineNoString                                               ' "=J4-K4"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(L35<>0,L35/COUNTIF(L4:L34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "O" & LineNoString
            FormulaString = "=If(M" & LineNoString & "<>0,N" & LineNoString & "/M" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "Q" & LineNoString
            FormulaString = "=IF(B" & LineNoString & "<>0,(100-ROUND(G" & LineNoString & "/B" & LineNoString & "*100,2)),0)"
            .Range(CellString).Formula = FormulaString
            CellString = "R" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,(100-ROUND(H" & LineNoString & "/C" & LineNoString & "*100,2)),0)"
            .Range(CellString).Formula = FormulaString
            CellString = "Q" & LineNoString & ":R" & LineNoString
            If .Range("Q" & LineNoString).Value < .Range("R" & LineNoString).Value Then
                .Range(CellString).Interior.Color = Color.LightPink
            Else
                .Range(CellString).Interior.Color = Color.LightGreen
            End If

            CellString = "T" & LineNoString
            FormulaString = "=IF(T" & (LineNoString - 1) & "<>0,T" & (LineNoString - 1) & "/COUNTIFS(T4:T" & (SpreadsheetLine - 3) & ",""<>0"",T4:T" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(J35<>0,J35/COUNTIF(J4:J34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "U" & LineNoString
            FormulaString = "=IF(U" & (LineNoString - 1) & "<>0,U" & (LineNoString - 1) & "/COUNTIFS(U4:U" & (SpreadsheetLine - 3) & ",""<>0"",U4:U" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(K35<>0,K35/COUNTIF(K4:K34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "V" & LineNoString
            FormulaString = "=T" & LineNoString & "-U" & LineNoString                                               ' "=J4-K4"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(L35<>0,L35/COUNTIF(L4:L34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "W" & LineNoString
            FormulaString = "=If(U" & LineNoString & "<>0,V" & LineNoString & "/U" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "Y" & LineNoString
            FormulaString = "=IF(Y" & (LineNoString - 1) & "<>0,Y" & (LineNoString - 1) & "/COUNTIFS(Y4:Y" & (SpreadsheetLine - 3) & ",""<>0"",Y4:Y" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(J35<>0,J35/COUNTIF(J4:J34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "Z" & LineNoString
            FormulaString = "=IF(Z" & (LineNoString - 1) & "<>0,Z" & (LineNoString - 1) & "/COUNTIFS(Z4:Z" & (SpreadsheetLine - 3) & ",""<>0"",Z4:Z" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(K35<>0,K35/COUNTIF(K4:K34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "AA" & LineNoString
            FormulaString = "=Y" & LineNoString & "-Z" & LineNoString                                               ' "=J4-K4"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(L35<>0,L35/COUNTIF(L4:L34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "AB" & LineNoString
            FormulaString = "=If(Z" & LineNoString & "<>0,AA" & LineNoString & "/Z" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":E" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":J" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "L" & LineNoString & ":O" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "Q" & LineNoString & ":R" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "T" & LineNoString & ":W" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "Y" & LineNoString & ":AB" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "A" & LineNoString & ":AB" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet2
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Average"
            CellString = "B" & LineNoString
            ' FormulaString = "=IF(B" & (LineNoString - 1) & "<>0,B" & (LineNoString - 1) & "/COUNTA(B4:B" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(B" & (LineNoString - 1) & "<>0,B" & (LineNoString - 1) & "/COUNTIFS(B4:B" & (SpreadsheetLine - 3) & ",""<>0"",B4:B" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(B35<>0,B35/COUNTIF(B4:B34,"<>0"),0)"
            CellString = "C" & LineNoString
            ' FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTA(C4:C" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTIFS(C4:C" & (SpreadsheetLine - 3) & ",""<>0"",C4:C" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            CellString = "D" & LineNoString
            FormulaString = "=B" & LineNoString & "-C" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "E" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "G" & LineNoString
            ' FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/COUNTA(G4:G" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/COUNTIFS(G4:G" & (SpreadsheetLine - 3) & ",""<>0"",G4:G" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            CellString = "H" & LineNoString
            ' FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/COUNTA(H4:H" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/COUNTIFS(H4:H" & (SpreadsheetLine - 3) & ",""<>0"",H4:H" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            CellString = "I" & LineNoString
            FormulaString = "=G" & LineNoString & "-H" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "J" & LineNoString
            FormulaString = "=IF(H" & LineNoString & "<>0,I" & LineNoString & "/H" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":E" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":J" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":D" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "E" & LineNoString & ":U" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet3
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Average"
            CellString = "B" & LineNoString
            ' FormulaString = "=IF(B" & (LineNoString - 1) & "<>0,B" & (LineNoString - 1) & "/COUNTA(B4:B" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(B" & (LineNoString - 1) & "<>0,B" & (LineNoString - 1) & "/COUNTIFS(B4:B" & (SpreadsheetLine - 3) & ",""<>0"",B4:B" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(B35<>0,B35/COUNTIF(B4:B34,"<>0"),0)"
            CellString = "C" & LineNoString
            'FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTA(C4:C" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTIFS(C4:C" & (SpreadsheetLine - 3) & ",""<>0"",C4:C" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            CellString = "D" & LineNoString
            FormulaString = "=B" & LineNoString & "-C" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "E" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "G" & LineNoString
            ' FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/COUNTA(G4:G" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/COUNTIFS(G4:G" & (SpreadsheetLine - 3) & ",""<>0"",G4:G" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            CellString = "H" & LineNoString
            ' FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/COUNTA(H4:H" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/COUNTIFS(H4:H" & (SpreadsheetLine - 3) & ",""<>0"",H4:H" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            CellString = "I" & LineNoString
            FormulaString = "=G" & LineNoString & "-H" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "J" & LineNoString
            FormulaString = "=IF(H" & LineNoString & "<>0,I" & LineNoString & "/H" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":E" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":J" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":D" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "E" & LineNoString & ":U" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet4
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Average"
            CellString = "B" & LineNoString
            ' FormulaString = "=IF(B" & (LineNoString - 1) & "<>0,B" & (LineNoString - 1) & "/COUNTA(B4:B" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(B" & (LineNoString - 1) & "<>0,B" & (LineNoString - 1) & "/COUNTIFS(B4:B" & (SpreadsheetLine - 3) & ",""<>0"",B4:B" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(B35<>0,B35/COUNTIF(B4:B34,"<>0"),0)"
            CellString = "C" & LineNoString
            ' FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTA(C4:C" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTIFS(C4:C" & (SpreadsheetLine - 3) & ",""<>0"",C4:C" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            CellString = "D" & LineNoString
            FormulaString = "=B" & LineNoString & "-C" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "E" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "G" & LineNoString
            ' FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/COUNTA(G4:G" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/COUNTIFS(G4:G" & (SpreadsheetLine - 3) & ",""<>0"",G4:G" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            CellString = "H" & LineNoString
            ' FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/COUNTA(H4:H" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/COUNTIFS(H4:H" & (SpreadsheetLine - 3) & ",""<>0"",H4:H" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            CellString = "I" & LineNoString
            FormulaString = "=G" & LineNoString & "-H" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "J" & LineNoString
            FormulaString = "=IF(H" & LineNoString & "<>0,I" & LineNoString & "/H" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":E" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":J" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":D" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "E" & LineNoString & ":U" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

    End Sub

    Private Sub DisplayExcelWorkbook()
        xlWorkSheetSetup()
        xlWorkSheet4.Activate()
        With xlApp
            xlWorkSheet4.Range("B4").Select()
            .ActiveWindow.FreezePanes = True
            .ActiveWindow.Zoom = 85 ' open sheet at 85%
        End With
        xlWorkSheet3.Activate()
        With xlApp
            xlWorkSheet3.Range("B4").Select()
            .ActiveWindow.FreezePanes = True
            .ActiveWindow.Zoom = 85 ' open sheet at 85%
        End With
        xlWorkSheet2.Activate()
        With xlApp
            xlWorkSheet2.Range("B4").Select()
            .ActiveWindow.FreezePanes = True
            .ActiveWindow.Zoom = 85 ' open sheet at 85%
        End With
        xlWorkSheet1.Activate()
        With xlApp
            xlWorkSheet1.Range("B4").Select()
            .ActiveWindow.FreezePanes = True
            .ActiveWindow.Zoom = 85 ' open sheet at 85%
            .Visible = True
        End With
        'xlWorkSheet1.Range("I3:U3").ColumnWidth = 0
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

    Private Sub xlWorkSheetSetup()
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
            .Orientation = Excel.XlPageOrientation.xlLandscape                                   ' .xlPortrait .xlLandscape               ' '1 = xlPortrait; 2 = xlLandscape
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

    Private Sub getSalesFigures()
        Dim CurrentRecordId As Integer
        Dim DateLoop As Date
        Dim FromDate As String
        Dim ToDate As String
        Dim SQL As String
        Dim Month As Integer

        For i As Integer = 0 To 11
            CashupTotalSales(i) = 0.0
            LastYearCashupTotalSales(i) = 0.0
            TransCount(i) = 0.0
            VoidCount(i) = 0.0
            VoidValue(i) = 0.0
            ErrorCount(i) = 0.0
            ErrorValue(i) = 0.0
        Next

        ' This Year

        DateLoop = CDate(txtDateFrom.Text)
        FromDate = DateSerial(DateLoop.Year, DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        DateLoop = CDate(txtDateTo.Text)
        ToDate = DateSerial(DateLoop.Year, DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        SQL = "Select * From Sales Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "'"
        Try
            SDC = New SalesDataContext
            SalesBindingSource.DataSource = SDC.ExecuteQuery(Of Sales)(SQL)
        Catch ex As Exception
            MessageBox.Show("Sales Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        CurrentRecordId = 0
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
                Select Case SalesRow.Date.Month
                    Case 1
                        Month = 10
                    Case 2
                        Month = 11
                    Case 3
                        Month = 0
                    Case 4
                        Month = 1
                    Case 5
                        Month = 2
                    Case 6
                        Month = 3
                    Case 7
                        Month = 4
                    Case 8
                        Month = 5
                    Case 9
                        Month = 6
                    Case 10
                        Month = 7
                    Case 11
                        Month = 8
                    Case 12
                        Month = 9
                    Case Else
                        MessageBox.Show("Month number is invalid, this should never happen" & vbCrLf & vbCrLf & "Month Number: " & SalesRow.Date.Month, "Reporting Error")
                        Month = 0
                End Select
                TransCount(Month) += SalesRow.ChecksPaid
                VoidCount(Month) += SalesRow.Void
                ErrorCount(Month) += SalesRow.ErrorCorrects
                If cboVATIndicator.SelectedIndex = 0 Then
                    CashupTotalSales(Month) += SalesRow.GrossSales
                    VoidValue(Month) += SalesRow.VoidsValue
                    ErrorValue(Month) += SalesRow.ErrorCorrectsValue
                Else
                    CashupTotalSales(Month) += Math.Round((SalesRow.GrossSales / 1.14), 2)
                    VoidValue(Month) += Math.Round((SalesRow.VoidsValue / 1.14), 2)
                    ErrorValue(Month) += Math.Round((SalesRow.ErrorCorrectsValue / 1.14), 2)
                End If
            End If
            SalesBindingSource.MoveNext()
        Loop

        ' Last Year

        DateLoop = CDate(txtDateFrom.Text)
        FromDate = DateSerial((DateLoop.Year - 1), DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        DateLoop = CDate(txtDateTo.Text)
        ToDate = DateSerial((DateLoop.Year - 1), DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        SQL = "Select * From Sales Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "'"
        Try
            SDC = New SalesDataContext
            SalesBindingSource.DataSource = SDC.ExecuteQuery(Of Sales)(SQL)
        Catch ex As Exception
            MessageBox.Show("Sales Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        CurrentRecordId = 0
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
                Select Case SalesRow.Date.Month
                    Case 1
                        Month = 10
                    Case 2
                        Month = 11
                    Case 3
                        Month = 0
                    Case 4
                        Month = 1
                    Case 5
                        Month = 2
                    Case 6
                        Month = 3
                    Case 7
                        Month = 4
                    Case 8
                        Month = 5
                    Case 9
                        Month = 6
                    Case 10
                        Month = 7
                    Case 11
                        Month = 8
                    Case 12
                        Month = 9
                    Case Else
                        MessageBox.Show("Month number is invalid, this should never happen" & vbCrLf & vbCrLf & "Month Number: " & SalesRow.Date.Month, "Reporting Error")
                        Month = 0
                End Select
                LastYearTransCount(Month) += SalesRow.ChecksPaid
                LastYearVoidCount(Month) += SalesRow.Void
                LastYearErrorCount(Month) += SalesRow.ErrorCorrects
                If cboVATIndicator.SelectedIndex = 0 Then
                    LastYearCashupTotalSales(Month) += SalesRow.GrossSales
                    LastYearVoidValue(Month) += SalesRow.VoidsValue
                    LastYearErrorValue(Month) += SalesRow.ErrorCorrectsValue
                Else
                    LastYearCashupTotalSales(Month) += Math.Round((SalesRow.GrossSales / 1.14), 2)
                    LastYearVoidValue(Month) += Math.Round((SalesRow.VoidsValue / 1.14), 2)
                    LastYearErrorValue(Month) += Math.Round((SalesRow.ErrorCorrectsValue / 1.14), 2)
                End If
            End If
            SalesBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub getCOSFigures()
        Dim CurrentRecordId As Integer
        Dim DateLoop As Date
        Dim FromDate As String
        Dim ToDate As String
        Dim SQL As String
        Dim Month As Integer

        For i As Integer = 0 To 11
            CostOfSales(i) = 0.0
            LastYearCostOfSales(i) = 0.0
        Next

        ' This Year

        DateLoop = CDate(txtDateFrom.Text)
        FromDate = DateSerial(DateLoop.Year, DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        DateLoop = CDate(txtDateTo.Text)
        ToDate = DateSerial(DateLoop.Year, DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        ' SQL = "Select * From Invoice Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "'"
        SQL = "Select Invoice.RecordId, Invoice.Date, Invoice.DocumentType, Invoice.DocumentNumber, Invoice.Amount, Invoice.Memo, Invoice.EmployeeRecordId, Invoice.SupplierRecordId " &
                    " From Invoice Inner Join Supplier On Invoice.SupplierRecordId = Supplier.RecordId " &
                    "Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "' And Supplier.COS = 1"
        Try
            IDC = New InvoiceDataContext
            InvoiceBindingSource.DataSource = IDC.ExecuteQuery(Of Invoice)(SQL)
        Catch ex As Exception
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        CurrentRecordId = 0
        InvoiceBindingSource.MoveFirst()
        Do
            Try
                InvoiceRow = InvoiceBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If InvoiceRow IsNot Nothing Then
                If CurrentRecordId = InvoiceRow.RecordId Then Exit Do
                CurrentRecordId = InvoiceRow.RecordId
                Select Case InvoiceRow.Date.Month
                    Case 1
                        Month = 10
                    Case 2
                        Month = 11
                    Case 3
                        Month = 0
                    Case 4
                        Month = 1
                    Case 5
                        Month = 2
                    Case 6
                        Month = 3
                    Case 7
                        Month = 4
                    Case 8
                        Month = 5
                    Case 9
                        Month = 6
                    Case 10
                        Month = 7
                    Case 11
                        Month = 8
                    Case 12
                        Month = 9
                    Case Else
                        MessageBox.Show("Month number is invalid, this should never happen" & vbCrLf & vbCrLf & "Month Number: " & InvoiceRow.Date.Month, "Reporting Error")
                        Month = 0
                End Select
                Select Case InvoiceRow.DocumentType
                    Case "I"
                        If cboVATIndicator.SelectedIndex = 0 Then
                            CostOfSales(Month) += InvoiceRow.Amount
                        Else
                            CostOfSales(Month) += Math.Round((InvoiceRow.Amount / 1.14), 2)
                        End If
                    Case "C"
                        If cboVATIndicator.SelectedIndex = 0 Then
                            CostOfSales(Month) -= InvoiceRow.Amount
                        Else
                            CostOfSales(Month) -= Math.Round((InvoiceRow.Amount / 1.14), 2)
                        End If
                End Select
            End If
            InvoiceBindingSource.MoveNext()
        Loop

        ' Last Year

        DateLoop = CDate(txtDateFrom.Text)
        FromDate = DateSerial((DateLoop.Year - 1), DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        DateLoop = CDate(txtDateTo.Text)
        ToDate = DateSerial((DateLoop.Year - 1), DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        ' SQL = "Select * From Invoice Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "'"
        SQL = "Select Invoice.RecordId, Invoice.Date, Invoice.DocumentType, Invoice.DocumentNumber, Invoice.Amount, Invoice.Memo, Invoice.EmployeeRecordId, Invoice.SupplierRecordId " &
                    " From Invoice Inner Join Supplier On Invoice.SupplierRecordId = Supplier.RecordId " &
                    "Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "' And Supplier.COS = 1"
        Try
            IDC = New InvoiceDataContext
            InvoiceBindingSource.DataSource = IDC.ExecuteQuery(Of Invoice)(SQL)
        Catch ex As Exception
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        CurrentRecordId = 0
        InvoiceBindingSource.MoveFirst()
        Do
            Try
                InvoiceRow = InvoiceBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If InvoiceRow IsNot Nothing Then
                If CurrentRecordId = InvoiceRow.RecordId Then Exit Do
                CurrentRecordId = InvoiceRow.RecordId
                Select Case InvoiceRow.Date.Month
                    Case 1
                        Month = 10
                    Case 2
                        Month = 11
                    Case 3
                        Month = 0
                    Case 4
                        Month = 1
                    Case 5
                        Month = 2
                    Case 6
                        Month = 3
                    Case 7
                        Month = 4
                    Case 8
                        Month = 5
                    Case 9
                        Month = 6
                    Case 10
                        Month = 7
                    Case 11
                        Month = 8
                    Case 12
                        Month = 9
                    Case Else
                        MessageBox.Show("Month number is invalid, this should never happen" & vbCrLf & vbCrLf & "Month Number: " & InvoiceRow.Date.Month, "Reporting Error")
                        Month = 0
                End Select
                Select Case InvoiceRow.DocumentType
                    Case "I"
                        If cboVATIndicator.SelectedIndex = 0 Then
                            LastYearCostOfSales(Month) += InvoiceRow.Amount
                        Else
                            LastYearCostOfSales(Month) += Math.Round((InvoiceRow.Amount / 1.14), 2)
                        End If
                    Case "C"
                        If cboVATIndicator.SelectedIndex = 0 Then
                            LastYearCostOfSales(Month) -= InvoiceRow.Amount
                        Else
                            LastYearCostOfSales(Month) -= Math.Round((InvoiceRow.Amount / 1.14), 2)
                        End If
                End Select
            End If
            InvoiceBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub getExpenseFigures()
        Dim CurrentRecordId As Integer
        Dim DateLoop As Date
        Dim FromDate As String
        Dim ToDate As String
        Dim SQL As String
        Dim Month As Integer

        For i As Integer = 0 To 11
            Expenses(i) = 0.0
            LastYearExpenses(i) = 0.0
        Next

        ' This Year

        DateLoop = CDate(txtDateFrom.Text)
        FromDate = DateSerial(DateLoop.Year, DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        DateLoop = CDate(txtDateTo.Text)
        ToDate = DateSerial(DateLoop.Year, DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        ' SQL = "Select * From Invoice Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "'"
        SQL = "Select Invoice.RecordId, Invoice.Date, Invoice.DocumentType, Invoice.DocumentNumber, Invoice.Amount, Invoice.Memo, Invoice.EmployeeRecordId, Invoice.SupplierRecordId " &
                    " From Invoice Inner Join Supplier On Invoice.SupplierRecordId = Supplier.RecordId " &
                    "Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "' And Supplier.COS = 0"
        Try
            IDC = New InvoiceDataContext
            InvoiceBindingSource.DataSource = IDC.ExecuteQuery(Of Invoice)(SQL)
        Catch ex As Exception
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        CurrentRecordId = 0
        InvoiceBindingSource.MoveFirst()
        Do
            Try
                InvoiceRow = InvoiceBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If InvoiceRow IsNot Nothing Then
                If CurrentRecordId = InvoiceRow.RecordId Then Exit Do
                CurrentRecordId = InvoiceRow.RecordId
                Select Case InvoiceRow.Date.Month
                    Case 1
                        Month = 10
                    Case 2
                        Month = 11
                    Case 3
                        Month = 0
                    Case 4
                        Month = 1
                    Case 5
                        Month = 2
                    Case 6
                        Month = 3
                    Case 7
                        Month = 4
                    Case 8
                        Month = 5
                    Case 9
                        Month = 6
                    Case 10
                        Month = 7
                    Case 11
                        Month = 8
                    Case 12
                        Month = 9
                    Case Else
                        MessageBox.Show("Month number is invalid, this should never happen" & vbCrLf & vbCrLf & "Month Number: " & InvoiceRow.Date.Month, "Reporting Error")
                        Month = 0
                End Select
                Select Case InvoiceRow.DocumentType
                    Case "I"
                        If cboVATIndicator.SelectedIndex = 0 Then
                            Expenses(Month) += InvoiceRow.Amount
                        Else
                            Expenses(Month) += Math.Round((InvoiceRow.Amount / 1.14), 2)
                        End If
                    Case "C"
                        If cboVATIndicator.SelectedIndex = 0 Then
                            Expenses(Month) -= InvoiceRow.Amount
                        Else
                            Expenses(Month) -= Math.Round((InvoiceRow.Amount / 1.14), 2)
                        End If
                End Select
            End If
            InvoiceBindingSource.MoveNext()
        Loop

        ' Last Year

        DateLoop = CDate(txtDateFrom.Text)
        FromDate = DateSerial((DateLoop.Year - 1), DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        DateLoop = CDate(txtDateTo.Text)
        ToDate = DateSerial((DateLoop.Year - 1), DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        ' SQL = "Select * From Invoice Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "'"
        SQL = "Select Invoice.RecordId, Invoice.Date, Invoice.DocumentType, Invoice.DocumentNumber, Invoice.Amount, Invoice.Memo, Invoice.EmployeeRecordId, Invoice.SupplierRecordId " &
                    " From Invoice Inner Join Supplier On Invoice.SupplierRecordId = Supplier.RecordId " &
                    "Where Date >= '" & FromDate & "' And Date <= '" & ToDate & "' And Supplier.COS = 0"
        Try
            IDC = New InvoiceDataContext
            InvoiceBindingSource.DataSource = IDC.ExecuteQuery(Of Invoice)(SQL)
        Catch ex As Exception
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        CurrentRecordId = 0
        InvoiceBindingSource.MoveFirst()
        Do
            Try
                InvoiceRow = InvoiceBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If InvoiceRow IsNot Nothing Then
                If CurrentRecordId = InvoiceRow.RecordId Then Exit Do
                CurrentRecordId = InvoiceRow.RecordId
                Select Case InvoiceRow.Date.Month
                    Case 1
                        Month = 10
                    Case 2
                        Month = 11
                    Case 3
                        Month = 0
                    Case 4
                        Month = 1
                    Case 5
                        Month = 2
                    Case 6
                        Month = 3
                    Case 7
                        Month = 4
                    Case 8
                        Month = 5
                    Case 9
                        Month = 6
                    Case 10
                        Month = 7
                    Case 11
                        Month = 8
                    Case 12
                        Month = 9
                    Case Else
                        MessageBox.Show("Month number is invalid, this should never happen" & vbCrLf & vbCrLf & "Month Number: " & InvoiceRow.Date.Month, "Reporting Error")
                        Month = 0
                End Select
                Select Case InvoiceRow.DocumentType
                    Case "I"
                        If cboVATIndicator.SelectedIndex = 0 Then
                            LastYearExpenses(Month) += InvoiceRow.Amount
                        Else
                            LastYearExpenses(Month) += Math.Round((InvoiceRow.Amount / 1.14), 2)
                        End If
                    Case "C"
                        If cboVATIndicator.SelectedIndex = 0 Then
                            LastYearExpenses(Month) -= InvoiceRow.Amount
                        Else
                            LastYearExpenses(Month) -= Math.Round((InvoiceRow.Amount / 1.14), 2)
                        End If
                End Select
            End If
            InvoiceBindingSource.MoveNext()
        Loop
    End Sub

End Class