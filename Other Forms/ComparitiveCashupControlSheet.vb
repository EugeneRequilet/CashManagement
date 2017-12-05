Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class ComparitiveCashupControlSheet

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet1 As Excel.Worksheet
    Dim xlWorkSheet2 As Excel.Worksheet
    Dim xlWorkSheet3 As Excel.Worksheet
    Dim xlWorkSheet4 As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Comparison " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SDC As SalesDataContext
    Dim SalesRow As Sales
    Dim IDC As InvoiceDataContext
    Dim InvoiceRow As Invoice

    Dim CashupTotalSales As Decimal
    Dim CostOfSales As Decimal
    Dim ChecksPaid As Integer
    Dim Voids As Integer
    Dim VoidsValue As Decimal
    Dim ErrorCorrects As Integer
    Dim ErrorCorrectsValue As Decimal
    Dim LastYearCashupTotalSales As Decimal
    Dim LastYearCostOfSales As Decimal
    Dim LastYearChecksPaid As Integer
    Dim LastYearVoids As Integer
    Dim LastYearVoidsValue As Decimal
    Dim LastYearErrorCorrects As Integer
    Dim LastYearErrorCorrectsValue As Decimal
    Dim DaysToAdjust As Integer

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Private Sub ComparitiveCashupControlSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

    Private Sub ExportExcelButton_Click(sender As Object, e As EventArgs) Handles ExportExcelButton.Click
        If ckbMatchWeekday.Checked = False Then
            DaysToAdjust = 0
        Else
            setMatchWeekday()
        End If
        CheckForFileAndContinue()
    End Sub

    Private Sub setMatchWeekday()
        Dim DayOfWeekThisYear As String
        Dim DayOfWeekLastYear As String

        DayOfWeekThisYear = Mid(Today.Date.DayOfWeek.ToString, 1, 3)
        For i As Integer = 0 To 6
            DaysToAdjust = i
            DayOfWeekLastYear = Mid(DateSerial((Today.Year - 1), Today.Month, (Today.Day + DaysToAdjust)).Date.DayOfWeek.ToString, 1, 3)
            If DayOfWeekThisYear = DayOfWeekLastYear Then Exit For
        Next
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
        XLFileName = "Comparison " & Format(txtDateTo.Value, "yyyy-MM")
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

        'xlWorkSheet1 = xlWorkBook.Sheets("Sheet1")
        'xlWorkSheet2 = xlWorkBook.Sheets("Sheet2")
        'xlWorkSheet3 = xlWorkBook.Sheets("Sheet3")
        'xlWorkSheet4 = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        'xlWorkSheet4 = xlWorkBook.Sheets("Sheet4")
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

            Dim HeadingText As String = "Comparison Gross Income And Expenditure From " & txtDateFrom.Text & " to " & txtDateTo.Text
            If txtAdjustmentAmount.EditValue Then
                HeadingText = HeadingText & " - Last year Plus " & txtAdjustmentAmount.EditValue.ToString & "%"
            End If
            .Range("A2").Value = HeadingText
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Date"
            .Range("B3").Value = "Day"
            .Range("C3").Value = "Gross Sales Incl VAT"
            .Range("D3").Value = "Day"
            If txtAdjustmentAmount.EditValue Then
                .Range("E3").Value = "Gross Sales L/Y Adjusted"
            Else
                .Range("E3").Value = "Gross Sales Last Year"
            End If
            .Range("F3").Value = "Difference"
            .Range("G3").Value = "Difference %"

            .Range("I3").Value = "Day"
            .Range("J3").Value = "Cost Of Sales"
            .Range("K3").Value = "Day"
            If txtAdjustmentAmount.EditValue Then
                .Range("L3").Value = "COS L/Y Adjusted"
            Else
                .Range("L3").Value = "COS Last Year"
            End If
            .Range("M3").Value = "Difference"
            .Range("N3").Value = "Difference %"

            .Range("P3").Value = "Day"
            .Range("Q3").Value = "Gross Profit"
            .Range("R3").Value = "Day"
            If txtAdjustmentAmount.EditValue Then
                .Range("S3").Value = "Gross Profit L/Y Adj"
            Else
                .Range("S3").Value = "Gross Profit Last Year"
            End If
            .Range("T3").Value = "Difference"
            .Range("U3").Value = "Difference %"

            .Range("A3:U3").Font.Bold = True
            .Range("A3:U3").Font.Size = 9
            .Range("A3:U3").WrapText = True
            .Range("A3:U3").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 8
            .Range("B3").ColumnWidth = 5
            .Range("C3").ColumnWidth = 12
            .Range("D3").ColumnWidth = 5
            .Range("E3:F3").ColumnWidth = 12
            .Range("G3").ColumnWidth = 10
            .Range("H3").ColumnWidth = 3
            .Range("I3").ColumnWidth = 5
            .Range("J3").ColumnWidth = 12
            .Range("K3").ColumnWidth = 5
            .Range("L3:M3").ColumnWidth = 12
            .Range("N3").ColumnWidth = 10
            .Range("O3").ColumnWidth = 3
            .Range("P3").ColumnWidth = 5
            .Range("Q3").ColumnWidth = 12
            .Range("R3").ColumnWidth = 5
            .Range("S3:T3").ColumnWidth = 12
            .Range("U3").ColumnWidth = 10

            .Range("A3:G3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("I3:N3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("P3:U3").Borders.LineStyle = Excel.Constants.xlSolid
        End With

        With xlWorkSheet2
            .Range("A1:Z500").Font.Name = "Calibri"
            .Range("A1:Z500").Font.Bold = False
            .Range("A1:Z500").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Comparison Monthly Transactions From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Date"
            .Range("B3").Value = "Day"
            .Range("C3").Value = "Trans Count"
            .Range("D3").Value = "Day"
            If txtAdjustmentAmount.EditValue Then
                .Range("E3").Value = "Trans Count L/Y Adjusted"
            Else
                .Range("E3").Value = "Trans Count L/Y"
            End If
            .Range("F3").Value = "Difference"
            .Range("G3").Value = "Difference %"

            .Range("I3").Value = "Day"
            .Range("J3").Value = "Spend Per Head"
            .Range("K3").Value = "Day"
            If txtAdjustmentAmount.EditValue Then
                .Range("L3").Value = "Spend Per Head L/Y Adjusted"
            Else
                .Range("L3").Value = "Spend Per Head L/Y"
            End If
            .Range("M3").Value = "Difference"
            .Range("N3").Value = "Difference %"

            .Range("A3:N3").Font.Bold = True
            .Range("A3:N3").Font.Size = 9
            .Range("A3:N3").WrapText = True
            .Range("A3:N3").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 8
            .Range("B3").ColumnWidth = 5
            .Range("C3").ColumnWidth = 12
            .Range("D3").ColumnWidth = 5
            .Range("E3:F3").ColumnWidth = 12
            .Range("G3").ColumnWidth = 10
            .Range("H3").ColumnWidth = 3
            .Range("I3").ColumnWidth = 5
            .Range("J3").ColumnWidth = 12
            .Range("K3").ColumnWidth = 5
            .Range("L3:M3").ColumnWidth = 12
            .Range("N3").ColumnWidth = 10

            .Range("A3:G3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("I3:N3").Borders.LineStyle = Excel.Constants.xlSolid
        End With

        With xlWorkSheet3
            .Range("A1:Z500").Font.Name = "Calibri"
            .Range("A1:Z500").Font.Bold = False
            .Range("A1:Z500").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Comparison Monthly Voids From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Date"
            .Range("B3").Value = "Day"
            .Range("C3").Value = "No Of Voids"
            .Range("D3").Value = "Day"
            If txtAdjustmentAmount.EditValue Then
                .Range("E3").Value = "No Of Voids L/Y Adjusted"
            Else
                .Range("E3").Value = "No Of Voids L/Y"
            End If
            .Range("F3").Value = "Difference"
            .Range("G3").Value = "Difference %"

            .Range("I3").Value = "Day"
            .Range("J3").Value = "Voids Value"
            .Range("K3").Value = "Day"
            If txtAdjustmentAmount.EditValue Then
                .Range("L3").Value = "Voids Value L/Y Adjusted"
            Else
                .Range("L3").Value = "Voids Value L/Y"
            End If
            .Range("M3").Value = "Difference"
            .Range("N3").Value = "Difference %"

            .Range("A3:N3").Font.Bold = True
            .Range("A3:N3").Font.Size = 9
            .Range("A3:N3").WrapText = True
            .Range("A3:N3").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 8
            .Range("B3").ColumnWidth = 5
            .Range("C3").ColumnWidth = 12
            .Range("D3").ColumnWidth = 5
            .Range("E3:F3").ColumnWidth = 12
            .Range("G3").ColumnWidth = 10
            .Range("H3").ColumnWidth = 3
            .Range("I3").ColumnWidth = 5
            .Range("J3").ColumnWidth = 12
            .Range("K3").ColumnWidth = 5
            .Range("L3:M3").ColumnWidth = 12
            .Range("N3").ColumnWidth = 10

            .Range("A3:G3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("I3:N3").Borders.LineStyle = Excel.Constants.xlSolid
        End With

        With xlWorkSheet4
            .Range("A1:Z500").Font.Name = "Calibri"
            .Range("A1:Z500").Font.Bold = False
            .Range("A1:Z500").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Comparison Monthly Errors From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Date"
            .Range("B3").Value = "Day"
            .Range("C3").Value = "No Of Error Corrects"
            .Range("D3").Value = "Day"
            If txtAdjustmentAmount.EditValue Then
                .Range("E3").Value = "Error Corrects L/Y Adjusted"
            Else
                .Range("E3").Value = "Error Corrects L/Y"
            End If
            .Range("F3").Value = "Difference"
            .Range("G3").Value = "Difference %"

            .Range("I3").Value = "Day"
            .Range("J3").Value = "Error Corrects Value"
            .Range("K3").Value = "Day"
            If txtAdjustmentAmount.EditValue Then
                .Range("L3").Value = "Error Corrects Value L/Y Adjusted"
            Else
                .Range("L3").Value = "Error Corrects Value L/Y"
            End If
            .Range("M3").Value = "Difference"
            .Range("N3").Value = "Difference %"

            .Range("A3:N3").Font.Bold = True
            .Range("A3:N3").Font.Size = 9
            .Range("A3:N3").WrapText = True
            .Range("A3:N3").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 8
            .Range("B3").ColumnWidth = 5
            .Range("C3").ColumnWidth = 12
            .Range("D3").ColumnWidth = 5
            .Range("E3:F3").ColumnWidth = 12
            .Range("G3").ColumnWidth = 10
            .Range("H3").ColumnWidth = 3
            .Range("I3").ColumnWidth = 5
            .Range("J3").ColumnWidth = 12
            .Range("K3").ColumnWidth = 5
            .Range("L3:M3").ColumnWidth = 12
            .Range("N3").ColumnWidth = 10

            .Range("A3:G3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("I3:N3").Borders.LineStyle = Excel.Constants.xlSolid
        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim isZeroSales As Boolean
        Dim isZeroCOS As Boolean
        Dim ThisYearDayOfWeek As String
        Dim LastYearDayOfWeek As String

        SpreadsheetLine = 3

        Dim DateLoop As Date = CDate(txtDateFrom.Text)

        Do Until DateLoop > CDate(txtDateTo.Text)
            getSalesFigures(DateLoop)
            getCOSFigures(DateLoop)
            ThisYearDayOfWeek = Mid(DateLoop.Date.DayOfWeek.ToString, 1, 3)
            LastYearDayOfWeek = Mid((DateSerial((DateLoop.Year - 1), DateLoop.Month, (DateLoop.Day + DaysToAdjust))).Date.DayOfWeek.ToString, 1, 3)

            SpreadsheetLine += 1
            LineNoString = SpreadsheetLine

            With xlWorkSheet1
                CellString = "A" & LineNoString
                .Range(CellString).Value = Format(DateLoop, "dd MMM")
                CellString = "B" & LineNoString
                .Range(CellString).Value = ThisYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red

                isZeroSales = False
                CellString = "C" & LineNoString
                If CashupTotalSales Then .Range(CellString).Value = CashupTotalSales
                If .Range(CellString).Value <> 0.0 And .Range(CellString).Value < GlobalFirmDetailRow.GrossSalesHighlight Then .Range(CellString).Interior.Color = Color.Yellow
                If .Range(CellString).Value = 0.0 Then isZeroSales = True
                CellString = "D" & LineNoString
                .Range(CellString).Value = LastYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "E" & LineNoString
                .Range(CellString).Value = (LastYearCashupTotalSales + Math.Round((LastYearCashupTotalSales * txtAdjustmentAmount.EditValue / 100), 2))
                If .Range(CellString).Value = 0.0 Then isZeroSales = True
                If .Range(CellString).Value <> 0.0 And .Range(CellString).Value < GlobalFirmDetailRow.GrossSalesHighlight Then .Range(CellString).Interior.Color = Color.Yellow
                If isZeroSales = False Then
                    CellString = "F" & LineNoString
                    FormulaString = "=C" & LineNoString & "-E" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "G" & LineNoString
                    FormulaString = "=IF(E" & LineNoString & "<>0,F" & LineNoString & "/E" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                isZeroCOS = False
                CellString = "I" & LineNoString
                .Range(CellString).Value = ThisYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "J" & LineNoString
                If CostOfSales Then .Range(CellString).Value = CostOfSales
                If .Range(CellString).Value = 0.0 Then isZeroCOS = True
                If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
                CellString = "K" & LineNoString
                .Range(CellString).Value = LastYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "L" & LineNoString
                .Range(CellString).Value = (LastYearCostOfSales + Math.Round((LastYearCostOfSales * txtAdjustmentAmount.EditValue / 100), 2))
                If .Range(CellString).Value = 0.0 Then isZeroCOS = True
                If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
                If isZeroCOS = False Then
                    CellString = "M" & LineNoString
                    FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "N" & LineNoString
                    FormulaString = "=IF(L" & LineNoString & "<>0,M" & LineNoString & "/L" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                CellString = "P" & LineNoString
                .Range(CellString).Value = ThisYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                If isZeroSales = False Then
                    CellString = "Q" & LineNoString
                    FormulaString = "=C" & LineNoString & "-J" & LineNoString                                               ' "=B4-F4"
                    .Range(CellString).Formula = FormulaString
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
                End If
                CellString = "R" & LineNoString
                .Range(CellString).Value = LastYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                If isZeroCOS = False Then
                    CellString = "S" & LineNoString
                    FormulaString = "=E" & LineNoString & "-L" & LineNoString                                               ' "=C4-G4"
                    .Range(CellString).Formula = FormulaString
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
                End If
                If isZeroSales = False And isZeroCOS = False Then
                    CellString = "T" & LineNoString
                    FormulaString = "=Q" & LineNoString & "-S" & LineNoString                                               ' "=J4-K4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "U" & LineNoString
                    FormulaString = "=IF(S" & LineNoString & "<>0,T" & LineNoString & "/S" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                CellString = "A" & LineNoString & ":G" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "I" & LineNoString & ":N" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "P" & LineNoString & ":U" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "A" & LineNoString & ":U" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "C" & LineNoString & ":U" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With

            With xlWorkSheet2
                CellString = "A" & LineNoString
                .Range(CellString).Value = Format(DateLoop, "dd MMM")
                CellString = "B" & LineNoString
                .Range(CellString).Value = ThisYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red

                isZeroSales = False
                CellString = "C" & LineNoString
                If CashupTotalSales Then .Range(CellString).Value = ChecksPaid
                If .Range(CellString).Value = 0.0 Then isZeroSales = True
                CellString = "D" & LineNoString
                .Range(CellString).Value = LastYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "E" & LineNoString
                If LastYearChecksPaid Then .Range(CellString).Value = (LastYearChecksPaid + Math.Round((LastYearChecksPaid * txtAdjustmentAmount.EditValue / 100), 0))
                If .Range(CellString).Value = 0.0 Then isZeroSales = True
                If isZeroSales = False Then
                    CellString = "F" & LineNoString
                    FormulaString = "=C" & LineNoString & "-E" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "G" & LineNoString
                    FormulaString = "=IF(E" & LineNoString & "<>0,F" & LineNoString & "/E" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                isZeroCOS = False
                CellString = "I" & LineNoString
                .Range(CellString).Value = ThisYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "J" & LineNoString
                If CashupTotalSales Then
                    If ChecksPaid Then
                        .Range(CellString).Value = (CashupTotalSales / ChecksPaid)
                    Else
                        .Range(CellString).Value = 0.0
                    End If
                End If
                If .Range(CellString).Value = 0.0 Then isZeroCOS = True
                CellString = "K" & LineNoString
                .Range(CellString).Value = LastYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "L" & LineNoString
                If LastYearChecksPaid Then .Range(CellString).Value = ((LastYearCashupTotalSales / LastYearChecksPaid) + Math.Round(((LastYearCashupTotalSales / LastYearChecksPaid) * txtAdjustmentAmount.EditValue / 100), 2))
                If .Range(CellString).Value = 0.0 Then isZeroCOS = True
                If isZeroCOS = False Then
                    CellString = "M" & LineNoString
                    FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "N" & LineNoString
                    FormulaString = "=IF(L" & LineNoString & "<>0,M" & LineNoString & "/L" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                CellString = "A" & LineNoString & ":G" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "I" & LineNoString & ":N" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "A" & LineNoString & ":N" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "C" & LineNoString & ":F" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0"
                CellString = "G" & LineNoString & ":N" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With

            With xlWorkSheet3
                CellString = "A" & LineNoString
                .Range(CellString).Value = Format(DateLoop, "dd MMM")
                CellString = "B" & LineNoString
                .Range(CellString).Value = ThisYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red

                isZeroSales = False
                CellString = "C" & LineNoString
                If CashupTotalSales Then .Range(CellString).Value = Voids
                If .Range(CellString).Value = 0.0 Then isZeroSales = True
                CellString = "D" & LineNoString
                .Range(CellString).Value = LastYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "E" & LineNoString
                If LastYearVoids Then .Range(CellString).Value = (LastYearVoids + Math.Round((LastYearVoids * txtAdjustmentAmount.EditValue / 100), 0))
                If .Range(CellString).Value = 0.0 Then isZeroSales = True
                If isZeroSales = False Then
                    CellString = "F" & LineNoString
                    FormulaString = "=C" & LineNoString & "-E" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "G" & LineNoString
                    FormulaString = "=IF(E" & LineNoString & "<>0,F" & LineNoString & "/E" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                isZeroCOS = False
                CellString = "I" & LineNoString
                .Range(CellString).Value = ThisYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "J" & LineNoString
                If CashupTotalSales Then .Range(CellString).Value = VoidsValue
                If .Range(CellString).Value = 0.0 Then isZeroCOS = True
                CellString = "K" & LineNoString
                .Range(CellString).Value = LastYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "L" & LineNoString
                If LastYearVoidsValue Then .Range(CellString).Value = (LastYearVoidsValue + Math.Round((LastYearVoidsValue * txtAdjustmentAmount.EditValue / 100), 2))
                If .Range(CellString).Value = 0.0 Then isZeroCOS = True
                If isZeroCOS = False Then
                    CellString = "M" & LineNoString
                    FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "N" & LineNoString
                    FormulaString = "=IF(L" & LineNoString & "<>0,M" & LineNoString & "/L" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                CellString = "A" & LineNoString & ":G" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "I" & LineNoString & ":N" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "A" & LineNoString & ":N" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "C" & LineNoString & ":F" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0"
                CellString = "G" & LineNoString & ":N" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With

            With xlWorkSheet4
                CellString = "A" & LineNoString
                .Range(CellString).Value = Format(DateLoop, "dd MMM")
                CellString = "B" & LineNoString
                .Range(CellString).Value = ThisYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red

                isZeroSales = False
                CellString = "C" & LineNoString
                If CashupTotalSales Then .Range(CellString).Value = ErrorCorrects
                If .Range(CellString).Value = 0.0 Then isZeroSales = True
                CellString = "D" & LineNoString
                .Range(CellString).Value = LastYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "E" & LineNoString
                If LastYearErrorCorrects Then .Range(CellString).Value = (LastYearErrorCorrects + Math.Round((LastYearErrorCorrects * txtAdjustmentAmount.EditValue / 100), 0))
                If .Range(CellString).Value = 0.0 Then isZeroSales = True
                If isZeroSales = False Then
                    CellString = "F" & LineNoString
                    FormulaString = "=C" & LineNoString & "-E" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "G" & LineNoString
                    FormulaString = "=IF(E" & LineNoString & "<>0,F" & LineNoString & "/E" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                isZeroCOS = False
                CellString = "I" & LineNoString
                .Range(CellString).Value = ThisYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "J" & LineNoString
                If CashupTotalSales Then .Range(CellString).Value = ErrorCorrectsValue
                If .Range(CellString).Value = 0.0 Then isZeroCOS = True
                CellString = "K" & LineNoString
                .Range(CellString).Value = LastYearDayOfWeek
                If .Range(CellString).Value = "Sat" Or .Range(CellString).Value = "Sun" Then .Range(CellString).Font.Color = Color.Red
                CellString = "L" & LineNoString
                If LastYearErrorCorrectsValue Then .Range(CellString).Value = (LastYearErrorCorrectsValue + Math.Round((LastYearErrorCorrectsValue * txtAdjustmentAmount.EditValue / 100), 2))
                If .Range(CellString).Value = 0.0 Then isZeroCOS = True
                If isZeroCOS = False Then
                    CellString = "M" & LineNoString
                    FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "N" & LineNoString
                    FormulaString = "=IF(L" & LineNoString & "<>0,M" & LineNoString & "/L" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightGreen
                    If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
                End If

                CellString = "A" & LineNoString & ":G" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "I" & LineNoString & ":N" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "A" & LineNoString & ":N" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "C" & LineNoString & ":F" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0"
                CellString = "G" & LineNoString & ":N" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With

            DateLoop = DateLoop.AddDays(1)
            If SpreadsheetLine > 120 Then Exit Do ' Four months of data on spreadsheet
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        SpreadsheetLine += 2
        LineNoString = SpreadsheetLine

        With xlWorkSheet1
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Total"

            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(B4:B34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "E" & LineNoString
            FormulaString = "=SUM(E4:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "F" & LineNoString
            FormulaString = "=C" & LineNoString & "-E" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "J" & LineNoString
            FormulaString = "=SUM(J4:J" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "L" & LineNoString
            FormulaString = "=SUM(L4:L" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "M" & LineNoString
            FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "Q" & LineNoString
            FormulaString = "=SUM(Q4:Q" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(J4:HJ4)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "S" & LineNoString
            FormulaString = "=SUM(S4:S" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(K4:K34)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "T" & LineNoString
            FormulaString = "=Q" & LineNoString & "-S" & LineNoString                                               ' "=J4-K4"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(L4:L34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":F" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "P" & LineNoString & ":T" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":U" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet2
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Total"

            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(B4:B34)"
            CellString = "E" & LineNoString
            FormulaString = "=SUM(E4:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            CellString = "F" & LineNoString
            FormulaString = "=C" & LineNoString & "-E" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "J" & LineNoString
            FormulaString = "=SUM(J4:J" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "L" & LineNoString
            FormulaString = "=SUM(L4:L" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"
            CellString = "M" & LineNoString
            FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":F" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":M" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "C" & LineNoString & ":F" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "G" & LineNoString & ":M" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":M" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet3
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Total"

            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(B4:B34)"
            CellString = "E" & LineNoString
            FormulaString = "=SUM(E4:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            CellString = "F" & LineNoString
            FormulaString = "=C" & LineNoString & "-E" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "J" & LineNoString
            FormulaString = "=SUM(J4:J" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "L" & LineNoString
            FormulaString = "=SUM(L4:L" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"
            CellString = "M" & LineNoString
            FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":F" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":M" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "C" & LineNoString & ":F" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "G" & LineNoString & ":M" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":M" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet4
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Total"

            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(B4:B34)"
            CellString = "E" & LineNoString
            FormulaString = "=SUM(E4:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            CellString = "F" & LineNoString
            FormulaString = "=C" & LineNoString & "-E" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "J" & LineNoString
            FormulaString = "=SUM(J4:J" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "L" & LineNoString
            FormulaString = "=SUM(L4:L" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"
            CellString = "M" & LineNoString
            FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":F" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":M" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "C" & LineNoString & ":F" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "G" & LineNoString & ":M" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":M" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        'Write the Footer Second Line

        SpreadsheetLine += 1
        LineNoString = SpreadsheetLine

        With xlWorkSheet1
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Average"

            CellString = "C" & LineNoString
            ' FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTA(C4:C" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTIFS(C4:C" & (SpreadsheetLine - 3) & ",""<>0"",C4:C" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=If(B35<>0,B35/COUNTIF(B4:B34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "E" & LineNoString
            ' FormulaString = "=IF(E" & (LineNoString - 1) & "<>0,E" & (LineNoString - 1) & "/COUNTA(E4:E" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(E" & (LineNoString - 1) & "<>0,E" & (LineNoString - 1) & "/COUNTIFS(E4:E" & (SpreadsheetLine - 3) & ",""<>0"",E4:E" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "F" & LineNoString
            FormulaString = "=C" & LineNoString & "-E" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "G" & LineNoString
            FormulaString = "=IF(E" & LineNoString & "<>0,F" & LineNoString & "/E" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "J" & LineNoString
            ' FormulaString = "=IF(J" & (LineNoString - 1) & "<>0,J" & (LineNoString - 1) & "/COUNTA(J4:J" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(J" & (LineNoString - 1) & "<>0,J" & (LineNoString - 1) & "/COUNTIFS(J4:J" & (SpreadsheetLine - 3) & ",""<>0"",J4:J" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "L" & LineNoString
            ' FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTA(L4:L" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTIFS(L4:L" & (SpreadsheetLine - 3) & ",""<>0"",L4:L" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "M" & LineNoString
            FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "N" & LineNoString
            FormulaString = "=IF(L" & LineNoString & "<>0,M" & LineNoString & "/L" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "Q" & LineNoString
            ' FormulaString = "=IF(Q" & (LineNoString - 1) & "<>0,Q" & (LineNoString - 1) & "/COUNTA(Q4:Q" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(Q" & (LineNoString - 1) & "<>0,Q" & (LineNoString - 1) & "/COUNTIFS(Q4:Q" & (SpreadsheetLine - 3) & ",""<>0"",Q4:Q" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(J35<>0,J35/COUNTIF(J4:J34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "S" & LineNoString
            ' FormulaString = "=IF(S" & (LineNoString - 1) & "<>0,S" & (LineNoString - 1) & "/COUNTA(S4:S" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(S" & (LineNoString - 1) & "<>0,S" & (LineNoString - 1) & "/COUNTIFS(S4:S" & (SpreadsheetLine - 3) & ",""<>0"",S4:S" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(K35<>0,K35/COUNTIF(K4:K34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "T" & LineNoString
            FormulaString = "=Q" & LineNoString & "-S" & LineNoString                                               ' "=J4-K4"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(L35<>0,L35/COUNTIF(L4:L34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "U" & LineNoString
            FormulaString = "=IF(S" & LineNoString & "<>0,T" & LineNoString & "/S" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":G" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":N" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "P" & LineNoString & ":U" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":U" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":U" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet2
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Average"

            CellString = "C" & LineNoString
            ' FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTA(C4:C" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTIFS(C4:C" & (SpreadsheetLine - 3) & ",""<>0"",C4:C" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(B35<>0,B35/COUNTIF(B4:B34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "E" & LineNoString
            ' FormulaString = "=IF(E" & (LineNoString - 1) & "<>0,E" & (LineNoString - 1) & "/COUNTA(E4:E" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(E" & (LineNoString - 1) & "<>0,E" & (LineNoString - 1) & "/COUNTIFS(E4:E" & (SpreadsheetLine - 3) & ",""<>0"",E4:E" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "F" & LineNoString
            FormulaString = "=C" & LineNoString & "-E" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "G" & LineNoString
            FormulaString = "=IF(E" & LineNoString & "<>0,F" & LineNoString & "/E" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "J" & LineNoString
            ' FormulaString = "=IF(J" & (LineNoString - 1) & "<>0,J" & (LineNoString - 1) & "/COUNTA(J4:J" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(J" & (LineNoString - 1) & "<>0,J" & (LineNoString - 1) & "/COUNTIFS(J4:J" & (SpreadsheetLine - 3) & ",""<>0"",J4:J" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "L" & LineNoString
            ' FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTA(L4:L" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTIFS(L4:L" & (SpreadsheetLine - 3) & ",""<>0"",L4:L" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "M" & LineNoString
            FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "N" & LineNoString
            FormulaString = "=IF(L" & LineNoString & "<>0,M" & LineNoString & "/L" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":G" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":N" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":N" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":F" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "G" & LineNoString & ":N" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":N" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet3
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Average"

            CellString = "C" & LineNoString
            ' FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTA(C4:C" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTIFS(C4:C" & (SpreadsheetLine - 3) & ",""<>0"",C4:C" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(B35<>0,B35/COUNTIF(B4:B34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "E" & LineNoString
            ' FormulaString = "=IF(E" & (LineNoString - 1) & "<>0,E" & (LineNoString - 1) & "/COUNTA(E4:E" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(E" & (LineNoString - 1) & "<>0,E" & (LineNoString - 1) & "/COUNTIFS(E4:E" & (SpreadsheetLine - 3) & ",""<>0"",E4:E" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "F" & LineNoString
            FormulaString = "=C" & LineNoString & "-E" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "G" & LineNoString
            FormulaString = "=IF(E" & LineNoString & "<>0,F" & LineNoString & "/E" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "J" & LineNoString
            ' FormulaString = "=IF(J" & (LineNoString - 1) & "<>0,J" & (LineNoString - 1) & "/COUNTA(J4:J" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(J" & (LineNoString - 1) & "<>0,J" & (LineNoString - 1) & "/COUNTIFS(J4:J" & (SpreadsheetLine - 3) & ",""<>0"",J4:J" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "L" & LineNoString
            ' FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTA(L4:L" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTIFS(L4:L" & (SpreadsheetLine - 3) & ",""<>0"",L4:L" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "M" & LineNoString
            FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "N" & LineNoString
            FormulaString = "=IF(L" & LineNoString & "<>0,M" & LineNoString & "/L" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":G" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":N" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":N" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":F" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "G" & LineNoString & ":N" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":N" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet4
            CellString = "A" & LineNoString
            .Range(CellString).Value = "Average"

            CellString = "C" & LineNoString
            ' FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTA(C4:C" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/COUNTIFS(C4:C" & (SpreadsheetLine - 3) & ",""<>0"",C4:C" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(B35<>0,B35/COUNTIF(B4:B34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "E" & LineNoString
            ' FormulaString = "=IF(E" & (LineNoString - 1) & "<>0,E" & (LineNoString - 1) & "/COUNTA(E4:E" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(E" & (LineNoString - 1) & "<>0,E" & (LineNoString - 1) & "/COUNTIFS(E4:E" & (SpreadsheetLine - 3) & ",""<>0"",E4:E" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "F" & LineNoString
            FormulaString = "=C" & LineNoString & "-E" & LineNoString
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "G" & LineNoString
            FormulaString = "=IF(E" & LineNoString & "<>0,F" & LineNoString & "/E" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "J" & LineNoString
            ' FormulaString = "=IF(J" & (LineNoString - 1) & "<>0,J" & (LineNoString - 1) & "/COUNTA(J4:J" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(J" & (LineNoString - 1) & "<>0,J" & (LineNoString - 1) & "/COUNTIFS(J4:J" & (SpreadsheetLine - 3) & ",""<>0"",J4:J" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "L" & LineNoString
            ' FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTA(L4:L" & (SpreadsheetLine - 3) & "),0)"
            FormulaString = "=IF(L" & (LineNoString - 1) & "<>0,L" & (LineNoString - 1) & "/COUNTIFS(L4:L" & (SpreadsheetLine - 3) & ",""<>0"",L4:L" & (SpreadsheetLine - 3) & ",""<>""&""""),0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            If .Range(CellString).Value < 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "M" & LineNoString
            FormulaString = "=J" & LineNoString & "-L" & LineNoString                                               ' "=F4-G4"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink
            CellString = "N" & LineNoString
            FormulaString = "=IF(L" & LineNoString & "<>0,M" & LineNoString & "/L" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            .Range(CellString).Interior.Color = Color.LightGreen
            If .Range(CellString).Value > 0.0 Then .Range(CellString).Interior.Color = Color.LightPink

            CellString = "A" & LineNoString & ":G" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":N" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":N" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString & ":F" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "G" & LineNoString & ":N" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":N" & LineNoString
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
        If ckbShowCosts.Checked = False Then
            xlWorkSheet1.Range("I3:U3").ColumnWidth = 0
        End If
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

    Private Sub getSalesFigures(ByVal DateLoop)
        Dim CurrentRecordId As Integer

        CashupTotalSales = 0.0
        ChecksPaid = 0
        Voids = 0
        VoidsValue = 0.0
        ErrorCorrects = 0
        ErrorCorrectsValue = 0.0
        LastYearCashupTotalSales = 0.0
        LastYearChecksPaid = 0
        LastYearVoids = 0
        LastYearVoidsValue = 0.0
        LastYearErrorCorrects = 0
        LastYearErrorCorrectsValue = 0.0

        ' This Year

        Dim ThisYearDate As String = DateSerial(DateLoop.Year, DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        Dim SQL As String = "Select * From Sales Where Date = '" & ThisYearDate & "'"
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
                CashupTotalSales += SalesRow.GrossSales
                ChecksPaid += SalesRow.ChecksPaid
                Voids += SalesRow.Void
                VoidsValue += SalesRow.VoidsValue
                ErrorCorrects += SalesRow.ErrorCorrects
                ErrorCorrectsValue += SalesRow.ErrorCorrectsValue
            End If
            SalesBindingSource.MoveNext()
        Loop

        ' Last Year

        Dim LastYearDate As String = DateSerial((DateLoop.Year - 1), DateLoop.Month, (DateLoop.Day + DaysToAdjust)).ToString("dd MMM yyyy")
        SQL = "Select * From Sales Where Date = '" & LastYearDate & "'"
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
                LastYearCashupTotalSales += SalesRow.GrossSales
                LastYearChecksPaid += SalesRow.ChecksPaid
                LastYearVoids += SalesRow.Void
                LastYearVoidsValue += SalesRow.VoidsValue
                LastYearErrorCorrects += SalesRow.ErrorCorrects
                LastYearErrorCorrectsValue += SalesRow.ErrorCorrectsValue
            End If
            SalesBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub getCOSFigures(ByVal DateLoop)
        CostOfSales = 0.0
        LastYearCostOfSales = 0.0

        ' This Year

        Dim ThisYearDate As String = DateSerial(DateLoop.Year, DateLoop.Month, DateLoop.Day).ToString("dd MMM yyyy")
        'Dim SQL As String = "Select 0 AS RecordId, SUM(CASE WHEN Invoice.DocumentType = 'I' THEN Invoice.Amount WHEN Invoice.DocumentType = 'C' THEN (0 - Invoice.Amount) ELSE 0 END) AS Amount " & _
        '                            "From Invoice Where Date = '" & ThisYearDate & "'"
        Dim SQL As String = "Select 0 AS RecordId, SUM(CASE WHEN Invoice.DocumentType = 'I' THEN Invoice.Amount WHEN Invoice.DocumentType = 'C' THEN (0 - Invoice.Amount) ELSE 0 END) AS Amount " &
                                    "From Invoice Left Join Supplier ON Invoice.SupplierRecordId = Supplier.RecordId " &
                                    "Where Date = '" & ThisYearDate & "' And Supplier.COS = 1"
        Try
            IDC = New InvoiceDataContext
            InvoiceBindingSource.DataSource = IDC.ExecuteQuery(Of Invoice)(SQL)
        Catch ex As Exception
            If Err.Number = 5 Then Exit Sub ' Procedure call or argument is not valid
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        InvoiceBindingSource.MoveFirst()
        Try
            InvoiceRow = InvoiceBindingSource.Current
        Catch ex As Exception
            'If Err.Number = 5 Then Exit Try ' Procedure call or argument is not valid
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            'Exit Sub
        End Try
        If InvoiceRow IsNot Nothing Then
            If InvoiceRow.Amount <> Nothing Then CostOfSales = InvoiceRow.Amount
        End If

        ' Last Year

        Dim LastYearDate As String = DateSerial((DateLoop.Year - 1), DateLoop.Month, (DateLoop.Day + DaysToAdjust)).ToString("dd MMM yyyy")
        'SQL = "Select 0 AS RecordId, SUM(CASE WHEN Invoice.DocumentType = 'I' THEN Invoice.Amount WHEN Invoice.DocumentType = 'C' THEN (0 - Invoice.Amount) ELSE 0 END) AS Amount " & _
        '                            "From Invoice Where Date = '" & LastYearDate & "'"
        SQL = "Select 0 AS RecordId, SUM(CASE WHEN Invoice.DocumentType = 'I' THEN Invoice.Amount WHEN Invoice.DocumentType = 'C' THEN (0 - Invoice.Amount) ELSE 0 END) AS Amount " &
                                    "From Invoice Left Join Supplier ON Invoice.SupplierRecordId = Supplier.RecordId " &
                                    "Where Date = '" & LastYearDate & "' And Supplier.COS = 1"
        Try
            IDC = New InvoiceDataContext
            InvoiceBindingSource.DataSource = IDC.ExecuteQuery(Of Invoice)(SQL)
        Catch ex As Exception
            If Err.Number = 5 Then Exit Sub ' Procedure call or argument is not valid
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        InvoiceBindingSource.MoveFirst()
        Try
            InvoiceRow = InvoiceBindingSource.Current
        Catch ex As Exception
            'If Err.Number = 5 Then Exit Try ' Procedure call or argument is not valid
            MessageBox.Show("Invoice Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            'Exit Sub
        End Try
        If InvoiceRow IsNot Nothing Then
            If InvoiceRow.Amount <> Nothing Then LastYearCostOfSales = InvoiceRow.Amount
        End If
    End Sub

    Private Sub txtAdjustmentAmount_Validated(sender As Object, e As EventArgs) Handles txtAdjustmentAmount.Validated
        If txtAdjustmentAmount.EditValue Then
            ckbShowCosts.Checked = False
        Else
            ckbShowCosts.Checked = True
        End If
    End Sub
End Class