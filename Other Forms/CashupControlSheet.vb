Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class CashupControlSheet
    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet1 As Excel.Worksheet
    Dim xlWorkSheet2 As Excel.Worksheet

    'Dim XLFileName As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "Control " & Today.ToString("yyyy MMMMMM")
    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Control " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SDC As SalesDataContext
    Dim SalesRow As Sales
    Dim CVDC As CashUpViewDataContext
    Dim CashupViewRow As CashupView
    Dim BDC As BankingDataContext
    Dim BankingRow As Banking
    Dim IDC As InvoiceDataContext
    Dim InvoiceRow As Invoice

    Dim ActualBanking As Decimal
    Dim CostOfSales As Decimal
    Dim FunnyMoneyBFwd As Decimal = 0
    Dim FunnyMoneyIncrease As Decimal
    Dim FunnyMoneyDecrease As Decimal
    Dim CashCheck As Decimal
    Dim CreditCardCheck As Decimal
    Dim PayoutCheck As Decimal
    Dim VarianceCheck As Decimal

    Dim CashupFunnyMoneyIncrease As Decimal
    Dim CashupFunnyMoneyDecrease As Decimal
    Dim CashupCashCheck As Decimal
    Dim CashupCreditCardCheck As Decimal
    Dim CashupPayoutCheck As Decimal
    Dim CashupVarianceCheck As Decimal
    Dim CashupTotalSales As Decimal

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Private Sub CashupControlSheet_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        CheckForFileAndContinue()
    End Sub

    Private Sub OpenExcelButton_Click(sender As Object, e As EventArgs) Handles OpenExcelButton.Click

        ' METHOD 1
        'OpenFileDialog1.DefaultExt = "*.xlsx"
        'If OpenFileDialog1.ShowDialog() = DialogResult.OK Then
        '    XLFileName = OpenFileDialog1.FileName
        '    OpenExcelSpreadsheet()
        'End If

        ' METHOD 2
        XLFileName = GetFileName(4, 0)
        If XLFileName Is Nothing Or XLFileName = "" Then Exit Sub
        OpenExcelSpreadsheet()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub CheckForFileAndContinue()
        XLFileName = "Control " & Format(txtDateTo.Value, "yyyy-MM")
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
        xlWorkBook.Sheets("Sheet1").Name = "Control"
        xlWorkBook.Sheets("Sheet2").Name = "Counts-Errors"

        With xlWorkSheet1
            .Range("A1:Z5000").Font.Name = "Calibri"
            .Range("A1:Z5000").Font.Bold = False
            .Range("A1:Z5000").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Cash-Up Control Sheet From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("C3").Value = "Gross Sales Incl VAT"
            .Range("D3").Value = "Cash Up Total Sales"
            .Range("E3").Value = "Variance"
            .Range("F3").Value = "Payouts"
            .Range("G3").Value = "Actual Banking"
            .Range("H3").Value = "Actual Banking Variance"
            .Range("I3").Value = "Cost Of Sales"
            .Range("J3").Value = "Food Cost %"
            .Range("K3").Value = "Gross Profit"
            .Range("L3").Value = "Gross Profit %"
            .Range("M3").Value = "Overbake Value"
            .Range("N3").Value = "Over-bake %"
            .Range("O3").Value = "Discount Value"
            .Range("P3").Value = "Disc %"
            .Range("Q3").Value = "Staff Meals"
            .Range("R3").Value = "Staff Meals %"
            .Range("S3").Value = "Stock Take Variance"
            .Range("T3").Value = "Stock Take Var %"

            .Range("C3:T3").Font.Bold = True
            .Range("C3:T3").Font.Size = 9
            .Range("C3:T3").WrapText = True
            .Range("C3:T3").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 6
            .Range("B3").ColumnWidth = 10
            .Range("C3:D3").ColumnWidth = 10
            .Range("E3").ColumnWidth = 8
            .Range("F3:I3").ColumnWidth = 10
            .Range("J3").ColumnWidth = 8
            .Range("K3").ColumnWidth = 10
            .Range("L3").ColumnWidth = 8
            .Range("M3").ColumnWidth = 10
            .Range("N3").ColumnWidth = 8
            .Range("O3").ColumnWidth = 10
            .Range("P3").ColumnWidth = 8
            .Range("Q3").ColumnWidth = 10
            .Range("R3").ColumnWidth = 8
            .Range("S3").ColumnWidth = 10
            .Range("T3").ColumnWidth = 8
            .Range("C3:T3").Borders.LineStyle = Excel.Constants.xlSolid
        End With

        With xlWorkSheet2
            .Range("A1:Z5000").Font.Name = "Calibri"
            .Range("A1:Z5000").Font.Bold = False
            .Range("A1:Z5000").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Cash-Up Counts / Errors From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("C3").Value = "Gross Sales Incl VAT"
            .Range("D3").Value = "Trans Count"
            .Range("E3").Value = "Spend Per Head"

            .Range("G3").Value = "Voids"
            .Range("H3").Value = "Void Value"

            .Range("J3").Value = "Error Corrects"
            .Range("K3").Value = "Error Corrects Value"

            .Range("M3").Value = "Stock Take Variance"
            .Range("N3").Value = "Stock Take Var %"

            .Range("P3").Value = "Xtra Deposited"
            .Range("Q3").Value = "Non Dep Money"

            .Range("S3").Value = "Cash Check"
            .Range("T3").Value = "C/C Check"
            .Range("U3").Value = "Payout Check"
            .Range("V3").Value = "Cashier Variance Check"
            .Range("W3").Value = "Total Variance Check"

            .Range("A3:W3").Font.Bold = True
            .Range("A3:W3").Font.Size = 9
            .Range("A3:W3").WrapText = True
            .Range("A3:W3").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A3").ColumnWidth = 6
            .Range("B3").ColumnWidth = 10
            .Range("C3:E3").ColumnWidth = 10
            .Range("F3").ColumnWidth = 2
            .Range("G3:H3").ColumnWidth = 10
            .Range("I3").ColumnWidth = 2
            .Range("J3:K3").ColumnWidth = 10
            .Range("L3").ColumnWidth = 2
            .Range("M3:N3").ColumnWidth = 10
            .Range("O3").ColumnWidth = 2
            .Range("P3:Q3").ColumnWidth = 10
            .Range("R3").ColumnWidth = 2
            .Range("S3:W3").ColumnWidth = 10
            .Range("C3:E3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("G3:H3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("J3:K3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("M3:N3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("P3:Q3").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("S3:W3").Borders.LineStyle = Excel.Constants.xlSolid
        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        SpreadsheetLine = 3

        'better way of parsing 
        'Dim from = DateTime.Now.ToShortDateString()
        'DateTime.TryParse(txtDateFrom.Text, from)

        Dim SQLString As String = "Select * From Sales Where Date >= '" & DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' and Date <= '" & DateTime.Parse(txtDateTo.Text).ToString("dd MMM yyyy") & "' Order by Date"
        Try
            Dim SQL = SQLString
            SDC = New SalesDataContext
            SalesBindingSource.DataSource = SDC.ExecuteQuery(Of Sales)(SQL)
        Catch ex As Exception
            MessageBox.Show("Sales Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data and create the spreadsheet body 

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
                getCashupFigures()
                getCOSFigures()
                getBankingFigures()

                FunnyMoneyIncrease = CashupFunnyMoneyIncrease
                FunnyMoneyDecrease = CashupFunnyMoneyDecrease
                CashCheck = CashupCashCheck - SalesRow.TurnoverCash
                CreditCardCheck = CashupCreditCardCheck - SalesRow.TurnoverCreditCard
                PayoutCheck = CashupPayoutCheck - SalesRow.Payout
                VarianceCheck = (CashCheck + CreditCardCheck + PayoutCheck) - CashupVarianceCheck

                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet1
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = Mid(SalesRow.Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = Format(SalesRow.Date, "dd MMM yy")
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = SalesRow.GrossSales
                    If SalesRow.GrossSales < GlobalFirmDetailRow.GrossSalesHighlight Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = CashupTotalSales                                                           ' Cash up totals
                    CellString = "E" & LineNoString
                    FormulaString = "=D" & LineNoString & "-C" & LineNoString
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"
                    .Range(CellString).Interior.Color = Color.LightBlue
                    If (((SalesRow.GrossSales - CashupTotalSales) < (0 - GlobalFirmDetailRow.GrossCashupDifHighlight)) Or ((SalesRow.GrossSales - CashupTotalSales) > GlobalFirmDetailRow.GrossCashupDifHighlight)) Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "F" & LineNoString
                    .Range(CellString).Value = SalesRow.Payout
                    CellString = "G" & LineNoString
                    .Range(CellString).Value = ActualBanking                                                          ' Actual Banking
                    If ActualBanking = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed
                    CellString = "H" & LineNoString
                    FormulaString = "=G" & LineNoString & "-(D" & LineNoString & "-F" & LineNoString & ")"                  ' "=G4-(D4-F4)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightBlue
                    CellString = "I" & LineNoString
                    .Range(CellString).Value = CostOfSales                                                            ' Cost of Sales
                    If CostOfSales = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed
                    CellString = "J" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,I" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,I4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.Lavender
                    If .Range(CellString).Value > 67.0 Then
                        CellString = "I" & LineNoString & ":J" & LineNoString
                        .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    CellString = "K" & LineNoString
                    FormulaString = "=C" & LineNoString & "-I" & LineNoString                                               ' "=C4-I4"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.LightBlue
                    CellString = "L" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,K" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,K4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.Lavender
                    CellString = "M" & LineNoString
                    .Range(CellString).Value = SalesRow.OverbakePercent100
                    If SalesRow.OverbakePercent100 = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed
                    If SalesRow.OverbakePercent100 > GlobalFirmDetailRow.OverbakeHighlight Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "N" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,M" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,M4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.Lavender
                    CellString = "O" & LineNoString
                    .Range(CellString).Value = (SalesRow.DiscountPercent20 + SalesRow.PromoPercent100 + SalesRow.SamplePercent100)
                    If (SalesRow.DiscountPercent20 + SalesRow.PromoPercent100 + SalesRow.SamplePercent100) = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed
                    If (SalesRow.DiscountPercent20 + SalesRow.PromoPercent100 + SalesRow.SamplePercent100) > GlobalFirmDetailRow.DiscountHighlight Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "P" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,O" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,O4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.Lavender
                    CellString = "Q" & LineNoString
                    .Range(CellString).Value = SalesRow.StaffPercent100
                    If SalesRow.StaffPercent100 = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed
                    If SalesRow.StaffPercent100 > GlobalFirmDetailRow.StaffMealHighlight Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "R" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,Q" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,Q4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.Lavender
                    CellString = "S" & LineNoString
                    .Range(CellString).Value = SalesRow.StockVarianceValue
                    .Range(CellString).Interior.Color = Color.Lavender
                    If .Range(CellString).Value < -50 Or .Range(CellString).Value > 50 Then .Range(CellString).Interior.Color = Color.Yellow
                    If .Range(CellString).Value = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed
                    CellString = "T" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,S" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,S4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.Lavender
                    If .Range(CellString).Value < -1 Or .Range(CellString).Value > 1 Then .Range(CellString).Interior.Color = Color.Yellow
                    If .Range(CellString).Value = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed

                    CellString = "A" & LineNoString & ":T" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "A" & LineNoString & ":T" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "C" & LineNoString & ":T" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                End With

                With xlWorkSheet2
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = Mid(SalesRow.Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = Format(SalesRow.Date, "dd MMM yy")
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = SalesRow.GrossSales
                    If SalesRow.GrossSales < GlobalFirmDetailRow.GrossSalesHighlight Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = SalesRow.ChecksPaid
                    CellString = "E" & LineNoString
                    FormulaString = "=IF(D" & LineNoString & "<>0,C" & LineNoString & "/D" & LineNoString & ",0)"
                    .Range(CellString).Formula = FormulaString                                                        ' "=D4-C4"

                    CellString = "G" & LineNoString
                    .Range(CellString).Value = SalesRow.Void
                    CellString = "H" & LineNoString
                    .Range(CellString).Value = SalesRow.VoidsValue

                    CellString = "J" & LineNoString
                    .Range(CellString).Value = SalesRow.ErrorCorrects
                    CellString = "K" & LineNoString
                    .Range(CellString).Value = SalesRow.ErrorCorrectsValue

                    CellString = "M" & LineNoString
                    .Range(CellString).Value = SalesRow.StockVarianceValue
                    .Range(CellString).Interior.Color = Color.Lavender
                    If .Range(CellString).Value < -50 Or .Range(CellString).Value > 50 Then .Range(CellString).Interior.Color = Color.Yellow
                    If .Range(CellString).Value = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed
                    CellString = "N" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,M" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,S4/C4*100,0)"
                    .Range(CellString).Formula = FormulaString
                    .Range(CellString).Interior.Color = Color.Lavender

                    CellString = "P" & LineNoString
                    .Range(CellString).Value = FunnyMoneyIncrease                                                            ' Deposit more using "Funny Money"
                    CellString = "Q" & LineNoString
                    .Range(CellString).Value = FunnyMoneyDecrease                                                            ' Deposit less removing change and puting it into "Funny Money"

                    CellString = "S" & LineNoString
                    .Range(CellString).Value = CashCheck                                                              ' Cash Check
                    If .Range(CellString).Value <> 0.0 Then .Range(CellString).Interior.Color = Color.Lavender
                    If .Range(CellString).Value < -10 Or .Range(CellString).Value > 10 Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "T" & LineNoString
                    .Range(CellString).Value = CreditCardCheck                                                        ' C/C Check
                    If CreditCardCheck <> 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "U" & LineNoString
                    .Range(CellString).Value = PayoutCheck                                                            ' PayoutCheck Check
                    If PayoutCheck <> 0.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "V" & LineNoString
                    .Range(CellString).Value = CashupVarianceCheck                                                    ' Cash-up Variance Check
                    If .Range(CellString).Value <> 0.0 Then .Range(CellString).Interior.Color = Color.Lavender
                    If .Range(CellString).Value < -10 Or .Range(CellString).Value > 10 Then .Range(CellString).Interior.Color = Color.Yellow
                    CellString = "W" & LineNoString
                    .Range(CellString).Value = VarianceCheck                                                          ' Total Variance check
                    If VarianceCheck <> 0.0 Then .Range(CellString).Interior.Color = Color.Yellow

                    CellString = "X" & LineNoString
                    .Range(CellString).Value = SalesRow.Memo

                    CellString = "A" & LineNoString & ":E" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "G" & LineNoString & ":H" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "J" & LineNoString & ":K" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "M" & LineNoString & ":N" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "P" & LineNoString & ":Q" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "S" & LineNoString & ":W" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

                    CellString = "A" & LineNoString & ":W" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "C" & LineNoString & ":W" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                    CellString = "D" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0"
                    CellString = "G" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0"
                    CellString = "J" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0"
                End With
            End If
            SalesBindingSource.MoveNext()
            If SpreadsheetLine > 120 Then Exit Do ' Four months of data on spreadsheet
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        SpreadsheetLine += 2
        LineNoString = SpreadsheetLine

        With xlWorkSheet1
            CellString = "B" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            CellString = "D" & LineNoString
            FormulaString = "=SUM(D4:D" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            CellString = "E" & LineNoString
            FormulaString = "=SUM(E4:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(E4:E34)"
            .Range(CellString).Interior.Color = Color.LightBlue
            CellString = "F" & LineNoString
            FormulaString = "=SUM(F4:F" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "G" & LineNoString
            FormulaString = "=SUM(G4:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"
            CellString = "H" & LineNoString
            FormulaString = "=SUM(H4:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            .Range(CellString).Interior.Color = Color.LightBlue
            CellString = "I" & LineNoString
            FormulaString = "=SUM(I4:I" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(I4:I34)"
            CellString = "J" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,I" & LineNoString & "/C" & LineNoString & "*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,I35/C35*100,0)"
            .Range(CellString).Interior.Color = Color.Lavender
            CellString = "K" & LineNoString
            FormulaString = "=SUM(K4:K" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            .Range(CellString).Interior.Color = Color.LightBlue
            CellString = "L" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,K" & LineNoString & "/C" & LineNoString & "*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,K35/C35*100,0)"
            .Range(CellString).Interior.Color = Color.Lavender
            CellString = "M" & LineNoString
            FormulaString = "=SUM(M4:M" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(M4:M34)"
            CellString = "N" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,M" & LineNoString & "/C" & LineNoString & "*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,M35/C35*100,0)"
            .Range(CellString).Interior.Color = Color.Lavender
            CellString = "O" & LineNoString
            FormulaString = "=SUM(O4:O" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(M4:M34)"
            CellString = "P" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,O" & LineNoString & "/C" & LineNoString & "*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,O35/C35*100,0)"
            .Range(CellString).Interior.Color = Color.Lavender
            CellString = "Q" & LineNoString
            FormulaString = "=SUM(Q4:Q" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(M4:M34)"
            CellString = "R" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,Q" & LineNoString & "/C" & LineNoString & "*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,Q35/C35*100,0)"
            .Range(CellString).Interior.Color = Color.Lavender
            CellString = "S" & LineNoString
            FormulaString = "=SUM(S4:S" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(M4:M34)"
            .Range(CellString).Interior.Color = Color.Lavender
            If .Range(CellString).Value < -500 Or .Range(CellString).Value > 5000 Then .Range(CellString).Interior.Color = Color.Yellow
            If .Range(CellString).Value = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed
            CellString = "T" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,S" & LineNoString & "/C" & LineNoString & "*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,S35/C35*100,0)"
            .Range(CellString).Interior.Color = Color.Lavender
            If .Range(CellString).Value < -1 Or .Range(CellString).Value > 1 Then .Range(CellString).Interior.Color = Color.Yellow
            If .Range(CellString).Value = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed

            CellString = "C" & LineNoString & ":T" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString & ":T" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "C" & LineNoString & ":T" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":T" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet2
            CellString = "B" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            CellString = "D" & LineNoString
            FormulaString = "=SUM(D4:D" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"

            CellString = "G" & LineNoString
            FormulaString = "=SUM(G4:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"
            CellString = "H" & LineNoString
            FormulaString = "=SUM(H4:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"

            CellString = "J" & LineNoString
            FormulaString = "=SUM(J4:J" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,I35/C35*100,0)"
            CellString = "K" & LineNoString
            FormulaString = "=SUM(K4:K" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"

            CellString = "M" & LineNoString
            FormulaString = "=SUM(M4:M" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(M4:M34)"
            .Range(CellString).Interior.Color = Color.Lavender
            If .Range(CellString).Value < -500 Or .Range(CellString).Value > 5000 Then .Range(CellString).Interior.Color = Color.Yellow
            If .Range(CellString).Value = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed

            CellString = "P" & LineNoString
            FormulaString = "=SUM(P4:P" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,O35/C35*100,0)"
            CellString = "Q" & LineNoString
            FormulaString = "=SUM(Q4:Q" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(M4:M34)"

            CellString = "S" & LineNoString
            FormulaString = "=SUM(S4:S" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(M4:M34)"
            If .Range(CellString).Value <> 0.0 Then .Range(CellString).Interior.Color = Color.Lavender
            If .Range(CellString).Value < -250 Or .Range(CellString).Value > 250 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "T" & LineNoString
            FormulaString = "=SUM(T4:T" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString
            CellString = "U" & LineNoString
            FormulaString = "=SUM(U4:U" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(V4:V34)"
            CellString = "V" & LineNoString
            FormulaString = "=SUM(V4:V" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(V4:V34)"
            If .Range(CellString).Value <> 0.0 Then .Range(CellString).Interior.Color = Color.Lavender
            If .Range(CellString).Value < -50 Or .Range(CellString).Value > 50 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "W" & LineNoString
            FormulaString = "=SUM(W4:W" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(V4:V34)"

            CellString = "C" & LineNoString & ":D" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":H" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "J" & LineNoString & ":K" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "P" & LineNoString & ":Q" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "S" & LineNoString & ":W" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "A" & LineNoString & ":W" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "C" & LineNoString & ":W" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "D" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "G" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "J" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "A" & LineNoString & ":AC" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        'Write the Footer Second Line

        SpreadsheetLine += 1
        LineNoString = SpreadsheetLine

        With xlWorkSheet1
            CellString = "B" & LineNoString
            .Range(CellString).Value = "Daily Average"
            CellString = "C" & LineNoString
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            CellString = "D" & LineNoString
            FormulaString = "=IF(D" & (LineNoString - 1) & "<>0,D" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            CellString = "E" & LineNoString
            FormulaString = "=IF(E" & (LineNoString - 1) & "<>0,E" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(E35<>0,E35/COUNTIF(E4:E34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightBlue
            CellString = "F" & LineNoString
            FormulaString = "=IF(F" & (LineNoString - 1) & "<>0,F" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(F35<>0,F35/COUNTIF(F4:F34,"<>0"),0)"
            CellString = "G" & LineNoString
            FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            CellString = "H" & LineNoString
            FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightBlue
            CellString = "I" & LineNoString
            FormulaString = "=IF(I" & (LineNoString - 1) & "<>0,I" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(I35<>0,I35/COUNTIF(I4:I34,"<>0"),0)"
            CellString = "K" & LineNoString
            FormulaString = "=IF(K" & (LineNoString - 1) & "<>0,K" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(K35<>0,K35/COUNTIF(K4:K34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.LightBlue
            CellString = "M" & LineNoString
            FormulaString = "=IF(M" & (LineNoString - 1) & "<>0,M" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(M35<>0,M35/COUNTIF(M4:M34,"<>0"),0)"
            CellString = "O" & LineNoString
            FormulaString = "=IF(O" & (LineNoString - 1) & "<>0,O" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(O35<>0,O35/COUNTIF(O4:O34,"<>0"),0)"
            CellString = "Q" & LineNoString
            FormulaString = "=IF(Q" & (LineNoString - 1) & "<>0,Q" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(Q35<>0,Q35/COUNTIF(Q4:Q34,"<>0"),0)"
            CellString = "S" & LineNoString
            FormulaString = "=IF(S" & (LineNoString - 1) & "<>0,S" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(S35<>0,S35/COUNTIF(S4:S34,"<>0"),0)"

            CellString = "A" & LineNoString & ":T" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "C" & LineNoString & ":T" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "C" & LineNoString & ":T" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":T" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet2
            CellString = "B" & LineNoString
            .Range(CellString).Value = "Daily Average"
            CellString = "C" & LineNoString
            FormulaString = "=IF(C" & (LineNoString - 1) & "<>0,C" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(C35<>0,C35/COUNTIF(C4:C34,"<>0"),0)"
            CellString = "D" & LineNoString
            FormulaString = "=IF(D" & (LineNoString - 1) & "<>0,D" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(D35<>0,D35/COUNTIF(D4:D34,"<>0"),0)"
            CellString = "E" & LineNoString
            FormulaString = "=IF(D" & LineNoString & "<>0,C" & LineNoString & "/D" & LineNoString & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(E35<>0,E35/COUNTIF(E4:E34,"<>0"),0)"

            CellString = "G" & LineNoString
            FormulaString = "=IF(G" & (LineNoString - 1) & "<>0,G" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(G35<>0,G35/COUNTIF(G4:G34,"<>0"),0)"
            CellString = "H" & LineNoString
            FormulaString = "=IF(H" & (LineNoString - 1) & "<>0,H" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(H35<>0,H35/COUNTIF(H4:H34,"<>0"),0)"

            CellString = "J" & LineNoString
            FormulaString = "=IF(J" & (LineNoString - 1) & "<>0,J" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(I35<>0,I35/COUNTIF(I4:I34,"<>0"),0)"
            CellString = "K" & LineNoString
            FormulaString = "=IF(K" & (LineNoString - 1) & "<>0,K" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(K35<>0,K35/COUNTIF(K4:K34,"<>0"),0)"

            CellString = "M" & LineNoString
            FormulaString = "=IF(M" & (LineNoString - 1) & "<>0,M" & (LineNoString - 1) & "/" & (SpreadsheetLine - 6) & ",0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(M35<>0,M35/COUNTIF(M4:M34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.Lavender
            If .Range(CellString).Value < -50 Or .Range(CellString).Value > 50 Then .Range(CellString).Interior.Color = Color.Yellow
            If .Range(CellString).Value = 0.0 Then .Range(CellString).Interior.Color = Color.MediumVioletRed
            CellString = "N" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,M" & LineNoString & "/C" & LineNoString & "*100,0)"       ' "=IF(C4<>0,M4/C4*100,0)"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(O35<>0,O35/COUNTIF(O4:O34,"<>0"),0)"
            .Range(CellString).Interior.Color = Color.Lavender

            GetBalanceBFwd()
            CellString = "P" & LineNoString
            .Range(CellString).Value = "BFwd"
            CellString = "Q" & LineNoString
            .Range(CellString).Value = FunnyMoneyBFwd

            CellString = "A" & LineNoString & ":W" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "C" & LineNoString & ":E" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "G" & LineNoString & ":H" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "J" & LineNoString & ":K" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "M" & LineNoString & ":N" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "Q" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "C" & LineNoString & ":W" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "D" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "G" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "J" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0"

            CellString = "A" & LineNoString & ":W" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        ' Write the Footer Third "Ninth" Line

        SpreadsheetLine += 1
        LineNoString = SpreadsheetLine

        With xlWorkSheet1
            Dim thisDate As Date = txtDateFrom.Text
            Dim DaysThisMonth As Integer = System.DateTime.DaysInMonth(Year(thisDate), Month(thisDate))

            'Dim thisYear As Integer = Year(thisDate)
            'Dim thisMonth As Integer = Month(thisDate)
            'Dim DaysThisMonth As Integer = System.DateTime.DaysInMonth(thisYear, thisMonth)

            CellString = "B" & LineNoString
            .Range(CellString).Value = "Monthly Projection"
            CellString = "C" & LineNoString
            FormulaString = "=C" & (LineNoString - 1) & "*" & DaysThisMonth
            .Range(CellString).Formula = FormulaString                                                        ' "=C17*30"
            .Range(CellString).Interior.Color = Color.PaleVioletRed
            CellString = "F" & LineNoString
            FormulaString = "=F" & (LineNoString - 1) & "*" & DaysThisMonth
            .Range(CellString).Formula = FormulaString                                                        ' "=F17*30"
            .Range(CellString).Interior.Color = Color.PaleVioletRed
            CellString = "I" & LineNoString
            FormulaString = "=I" & (LineNoString - 1) & "*" & DaysThisMonth
            .Range(CellString).Formula = FormulaString                                                        ' "=I17*30"
            .Range(CellString).Interior.Color = Color.PaleVioletRed
            CellString = "K" & LineNoString
            FormulaString = "=K" & (LineNoString - 1) & "*" & DaysThisMonth
            .Range(CellString).Formula = FormulaString                                                        ' "=K17*30"
            .Range(CellString).Interior.Color = Color.PaleVioletRed
            CellString = "M" & LineNoString
            FormulaString = "=M" & (LineNoString - 1) & "*" & DaysThisMonth
            .Range(CellString).Formula = FormulaString                                                        ' "=M17*30"
            CellString = "O" & LineNoString
            FormulaString = "=O" & (LineNoString - 1) & "*" & DaysThisMonth
            .Range(CellString).Formula = FormulaString                                                        ' "=O17*30"
            CellString = "Q" & LineNoString
            FormulaString = "=Q" & (LineNoString - 1) & "*" & DaysThisMonth
            .Range(CellString).Formula = FormulaString                                                        ' "=Q17*30"
            CellString = "S" & LineNoString
            FormulaString = "=S" & (LineNoString - 1) & "*" & DaysThisMonth
            .Range(CellString).Formula = FormulaString                                                        ' "=S17*30"

            CellString = "A" & LineNoString & ":T" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "C" & LineNoString & ":C" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "F" & LineNoString & ":F" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":I" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "K" & LineNoString & ":K" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "M" & LineNoString & ":M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "O" & LineNoString & ":O" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "Q" & LineNoString & ":Q" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "S" & LineNoString & ":S" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "C" & LineNoString & ":T" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":T" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet2
            CellString = "P" & LineNoString
            .Range(CellString).Value = "Current"
            CellString = "Q" & LineNoString
            FormulaString = "=SUM(P" & (LineNoString - 2) & "+Q" & (LineNoString - 2) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(V34+W34)"
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).NumberFormat = "#,###,##0.00"

            CellString = "P" & LineNoString & ":Q" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).Font.Bold = True

        End With

        SpreadsheetLine += 1
        LineNoString = SpreadsheetLine

        With xlWorkSheet2
            CellString = "P" & LineNoString
            .Range(CellString).Value = "Funny Money"
            CellString = "Q" & LineNoString
            FormulaString = "=SUM(Q" & (LineNoString - 2) & "+Q" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(V34+W34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).NumberFormat = "#,###,##0.00"

            CellString = "P" & LineNoString & ":Q" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).Font.Bold = True
        End With

        With xlWorkSheet1
            ' Skip a line and Write the Footer Fifth Line

            SpreadsheetLine += 1
            LineNoString = SpreadsheetLine

            CellString = "B" & LineNoString
            .Range(CellString).Value = "Total Excl VAT"
            CellString = "C" & LineNoString
            FormulaString = "=C" & (LineNoString - 4) & "/1.14"
            .Range(CellString).Formula = FormulaString                                                        ' "=C8/1.14"
            CellString = "I" & LineNoString
            FormulaString = "=I" & (LineNoString - 4) & "/1.14"
            .Range(CellString).Formula = FormulaString                                                        ' "=I8/1.14"
            CellString = "K" & LineNoString
            FormulaString = "=K" & (LineNoString - 4) & "/1.14"
            .Range(CellString).Formula = FormulaString                                                        ' "=K8/1.14"
            CellString = "P" & LineNoString
            CellString = "P" & LineNoString
            .Range(CellString).Value = "Cost Of Discounts In Total"
            CellString = "Q" & LineNoString
            FormulaString = "=SUM(Q" & (LineNoString - 4) & "+O" & (LineNoString - 4) & "+M" & (LineNoString - 4) & ")*J" & (LineNoString - 4) & "/100"
            .Range(CellString).Formula = FormulaString                                                        ' "=Q8+O8+M8"

            CellString = "A" & LineNoString & ":Q" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "C" & LineNoString & ":C" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":I" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "K" & LineNoString & ":K" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "Q" & LineNoString & ":Q" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "C" & LineNoString & ":K" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "Q" & LineNoString & ":Q" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":Q" & LineNoString
            .Range(CellString).Font.Bold = True

            ' Write the Footer Sixth Line

            SpreadsheetLine += 1
            LineNoString = SpreadsheetLine

            CellString = "L" & LineNoString
            .Range(CellString).Value = "GP %"
            CellString = "M" & LineNoString
            FormulaString = "=100-M" & (LineNoString + 1)
            .Range(CellString).Formula = FormulaString                                                        ' "=J8"

            CellString = "P" & LineNoString
            .Range(CellString).Value = "Cost Of Discounts Daily Ave"
            CellString = "Q" & LineNoString
            FormulaString = "=Q" & (LineNoString - 1) & "/" & (SpreadsheetLine - 10) & "*J" & (LineNoString - 5) & "/100"
            .Range(CellString).Formula = FormulaString                                                        ' "=IF(Q10<>0,Q10/COUNTIF(C4:C6,"<>0"),0)"

            CellString = "L" & LineNoString & ":M" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).Font.Size = 18
            .Range(CellString).Font.Bold = True
            CellString = "M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).NumberFormat = "#,###,##0.00"

            CellString = "P" & LineNoString & ":Q" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "Q" & LineNoString & ":Q" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "Q" & LineNoString & ":Q" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "P" & LineNoString & ":Q" & LineNoString
            .Range(CellString).Font.Bold = True

            ' Write the Footer Seventh Line

            SpreadsheetLine += 1
            LineNoString = SpreadsheetLine

            CellString = "L" & LineNoString
            .Range(CellString).Value = "Food Cost %"
            CellString = "M" & LineNoString
            FormulaString = "=J" & (LineNoString - 6)
            .Range(CellString).Formula = FormulaString                                                        ' "=J8"

            CellString = "L" & LineNoString & ":M" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "M" & LineNoString & ":M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "M" & LineNoString & ":M" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "L" & LineNoString & ":M" & LineNoString
            .Range(CellString).Font.Bold = True

            ' Write the Footer Eighth Line

            SpreadsheetLine += 1
            LineNoString = SpreadsheetLine

            CellString = "L" & LineNoString
            .Range(CellString).Value = "Food Cost Target %"
            CellString = "M" & LineNoString
            .Range(CellString).Value = 57.0

            CellString = "L" & LineNoString & ":M" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "M" & LineNoString & ":M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "M" & LineNoString & ":M" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "L" & LineNoString & ":M" & LineNoString
            .Range(CellString).Font.Bold = True

            ' Write the Footer Ninth Line

            SpreadsheetLine += 1
            LineNoString = SpreadsheetLine

            CellString = "L" & LineNoString
            .Range(CellString).Value = "Cost of Food Overspend"
            CellString = "M" & LineNoString
            FormulaString = "=(M" & (LineNoString - 2) & "-M" & (LineNoString - 1) & ")*C" & (LineNoString - 8) & "/100"
            .Range(CellString).Formula = FormulaString                                                        ' "=(+M13-M14)*C8/100"

            CellString = "L" & LineNoString & ":M" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "M" & LineNoString & ":M" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "M" & LineNoString & ":M" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "L" & LineNoString & ":M" & LineNoString
            .Range(CellString).Font.Bold = True
        End With

    End Sub

    Private Sub DisplayExcelWorkbook()
        xlWorkSheetSetup()
        xlWorkSheet2.Activate()
        With xlApp
            xlWorkSheet2.Range("C4").Select()
            .ActiveWindow.FreezePanes = True
            .ActiveWindow.Zoom = 80 ' open sheet at 80%
            xlWorkSheet2.Range("N3").ColumnWidth = 0
        End With
        xlWorkSheet1.Activate()
        With xlApp
            xlWorkSheet1.Range("C4").Select()
            .ActiveWindow.FreezePanes = True
            .ActiveWindow.Zoom = 85 ' open sheet at 85%
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

    Private Sub getCashupFigures()
        Dim CurrentRecordId As Integer

        CashupTotalSales = 0.0
        CostOfSales = 0.0
        CashupFunnyMoneyIncrease = 0.0
        CashupFunnyMoneyDecrease = 0.0
        CashupCashCheck = 0.0
        CashupCreditCardCheck = 0.0
        CashupPayoutCheck = 0.0
        CashupVarianceCheck = 0.0

        Dim SQL As String = "Select * From CashupView Where Date = '" & DateTime.Parse(SalesRow.Date).ToString("dd MMM yyyy") & "' And SalesType = 0"
        Try
            CVDC = New CashUpViewDataContext
            CashupViewBindingSource.DataSource = CVDC.ExecuteQuery(Of CashupView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

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

                CashupFunnyMoneyIncrease += CashupViewRow.DepIncreasedBy
                CashupFunnyMoneyDecrease -= CashupViewRow.DepReducedBy
                CashupTotalSales += (CashupViewRow.CashInTillLessFloat + CashupViewRow.CreditCardDeposited + CashupViewRow.DepositSkims + CashupViewRow.Payouts)
                CashupCashCheck += (CashupViewRow.CashInTillLessFloat + CashupViewRow.DepositSkims)
                CashupCreditCardCheck += CashupViewRow.CreditCardDeposited
                CashupPayoutCheck += CashupViewRow.Payouts
                CashupVarianceCheck += CashupViewRow.Variance
            End If
            CashupViewBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub getCOSFigures()
        CostOfSales = 0.0
        Dim SQL As String = "Select 0 AS RecordId, SUM(CASE WHEN Invoice.DocumentType = 'I' THEN Invoice.Amount WHEN Invoice.DocumentType = 'C' THEN (0 - Invoice.Amount) ELSE 0 END) AS Amount " &
                                    "From Invoice Left Join Supplier ON Invoice.SupplierRecordId = Supplier.RecordId " &
                                    "Where Date = '" & DateTime.Parse(SalesRow.Date).ToString("dd MMM yyyy") & "' And Supplier.COS = 1"
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
            Exit Sub
        End Try
        If InvoiceRow IsNot Nothing Then
            If InvoiceRow.Amount <> Nothing Then CostOfSales = InvoiceRow.Amount
        End If
    End Sub

    Private Sub getBankingFigures()
        ActualBanking = 0.0
        Dim SQL As String = "Select 0 AS RecordId, ISNULL(SUM(Banking.Amount),0) AS Amount From Banking Where Date = '" & DateTime.Parse(SalesRow.Date).ToString("dd MMM yyyy") & "'"
        Try
            BDC = New BankingDataContext
            BankingBindingSource.DataSource = BDC.ExecuteQuery(Of Banking)(SQL)
        Catch ex As Exception
            If Err.Number = 5 Then Exit Sub ' Procedure call or argument is not valid
            MessageBox.Show("Banking Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        BankingBindingSource.MoveFirst()
        Try
            BankingRow = BankingBindingSource.Current
        Catch ex As Exception
            'If Err.Number = 5 Then Exit Sub ' Procedure call or argument is not valid
            MessageBox.Show("Banking Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        If BankingRow IsNot Nothing Then
            If BankingRow.Amount <> Nothing Then ActualBanking = BankingRow.Amount
        End If
    End Sub

    Private Sub GetBalanceBFwd()
        FunnyMoneyBFwd = 0
        Dim SQL = "Select 0 AS RecordId, ISNULL(SUM(CashupView.DepIncreasedBy - CashupView.DepReducedBy),0) AS DepIncreasedBy From CashupView Where Date < '" &
                        DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' And SalesType = 0"
        Try
            CVDC = New CashUpViewDataContext
            CashupViewBindingSource.DataSource = CVDC.ExecuteQuery(Of CashupView)(SQL)
        Catch ex As Exception
            If Err.Number = 5 Then Exit Sub ' Procedure call or argument is not valid
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        CashupViewBindingSource.MoveFirst()
        Try
            CashupViewRow = CashupViewBindingSource.Current
        Catch ex As Exception
            'If Err.Number = 5 Then Exit Try ' Procedure call or argument is not valid
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        If CashupViewRow IsNot Nothing Then
            If CashupViewRow.DepIncreasedBy IsNot Nothing Then FunnyMoneyBFwd = CashupViewRow.DepIncreasedBy
        End If
    End Sub

End Class