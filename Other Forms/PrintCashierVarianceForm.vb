Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class PrintCashierVarianceForm

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    'Dim XLFileName As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\" & "Control " & Today.ToString("yyyy MMMMMM")
    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Variance " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SDC As SalesDataContext
    Dim SalesRow As Sales
    Dim CVDC As CashUpViewDataContext
    Dim CashupViewRow As CashupView
    Dim BDC As BankingDataContext
    Dim BankingRow As Banking
    Dim IDC As InvoiceDataContext
    Dim InvoiceRow As Invoice

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Dim CashierDE As String = ""
    Dim CashierFG As String = ""
    Dim CashierHI As String = ""
    Dim CashierJK As String = ""
    Dim CashierLM As String = ""
    Dim CashierNO As String = ""
    Dim CashierPQ As String = ""
    Dim CashierRS As String = ""
    Dim CashierTU As String = ""
    Dim CashierVW As String = ""
    Dim VarianceDE As Decimal
    Dim VarianceFG As Decimal
    Dim VarianceHI As Decimal
    Dim VarianceJK As Decimal
    Dim VarianceLM As Decimal
    Dim VarianceNO As Decimal
    Dim VariancePQ As Decimal
    Dim VarianceRS As Decimal
    Dim VarianceTU As Decimal
    Dim VarianceVW As Decimal



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
        getCashiers()
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
        Dim SQLString As String = "Select * From Sales Where Date >= '" & DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' and Date <= '" & DateTime.Parse(txtDateTo.Text).ToString("dd MMM yyyy") & "' Order by Date"
        Try
            Dim SQL = SQLString
            SDC = New SalesDataContext
            SalesBindingSource.DataSource = SDC.ExecuteQuery(Of Sales)(SQL)
        Catch ex As Exception
            MessageBox.Show("Sales Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        XLFileName = "Variance " & Format(txtDateTo.Value, "yyyy-MM")
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
            .Range("A1:AB3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Cashier Variance Control Sheet From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("D4").Value = CashierDE
            .Range("F4").Value = CashierFG
            .Range("H4").Value = CashierHI
            .Range("J4").Value = CashierJK
            .Range("L4").Value = CashierLM
            .Range("N4").Value = CashierNO
            .Range("P4").Value = CashierPQ
            .Range("R4").Value = CashierRS
            .Range("T4").Value = CashierTU
            .Range("V4").Value = CashierVW

            .Range("D4:E4").Merge()
            .Range("F4:G4").Merge()
            .Range("H4:I4").Merge()
            .Range("J4:K4").Merge()
            .Range("L4:M4").Merge()
            .Range("N4:O4").Merge()
            .Range("P4:Q4").Merge()
            .Range("R4:S4").Merge()
            .Range("T4:U4").Merge()
            .Range("V4:W4").Merge()

            .Range("A5").Value = "Day"
            .Range("B5").Value = "Date"
            .Range("C5").Value = "Memo"
            .Range("D5").Value = "Short"
            .Range("E5").Value = "Over"

            .Range("F5").Value = "Short"
            .Range("G5").Value = "Over"
            .Range("H5").Value = "Short"
            .Range("I5").Value = "Over"
            .Range("J5").Value = "Short"
            .Range("K5").Value = "Over"
            .Range("L5").Value = "Short"
            .Range("M5").Value = "Over"
            .Range("N5").Value = "Short"
            .Range("O5").Value = "Over"
            .Range("P5").Value = "Short"
            .Range("Q5").Value = "Over"
            .Range("R5").Value = "Short"
            .Range("S5").Value = "Over"
            .Range("T5").Value = "Short"
            .Range("U5").Value = "Over"
            .Range("V5").Value = "Short"
            .Range("W5").Value = "Over"

            .Range("A4:W5").Font.Bold = True
            .Range("A4:W5").Font.Size = 9
            .Range("A4:W5").WrapText = True
            .Range("A4:W5").RowHeight = 30
            .Range("A4:W5").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A4").ColumnWidth = 5
            .Range("B4").ColumnWidth = 10
            .Range("C4").ColumnWidth = 40
            .Range("D4:W4").ColumnWidth = 8
            .Range("D4:W4").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("A5:W5").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        SpreadsheetLine = 5

        With xlWorkSheet
            .Range("A6:Z50").Font.Bold = False
            .Range("A6:Z50").Font.Size = 11
        End With

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

                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = Mid(SalesRow.Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = Format(SalesRow.Date, "dd MMM yy")
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = SalesRow.Memo

                    If VarianceDE <> 0.0 Then
                        If VarianceDE < 0 Then
                            CellString = "D" & LineNoString
                        Else
                            CellString = "E" & LineNoString
                        End If
                        .Range(CellString).Value = VarianceDE
                        If VarianceDE < -10.0 Or VarianceDE > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    If VarianceFG <> 0.0 Then
                        If VarianceFG < 0 Then
                            CellString = "F" & LineNoString
                        Else
                            CellString = "G" & LineNoString
                        End If
                        .Range(CellString).Value = VarianceFG
                        If VarianceFG < -10.0 Or VarianceFG > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    If VarianceHI <> 0.0 Then
                        If VarianceHI < 0 Then
                            CellString = "H" & LineNoString
                        Else
                            CellString = "I" & LineNoString
                        End If
                        .Range(CellString).Value = VarianceHI
                        If VarianceHI < -10.0 Or VarianceHI > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    If VarianceJK <> 0.0 Then
                        If VarianceJK < 0 Then
                            CellString = "J" & LineNoString
                        Else
                            CellString = "K" & LineNoString
                        End If
                        .Range(CellString).Value = VarianceJK
                        If VarianceJK < -10.0 Or VarianceJK > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    If VarianceLM <> 0.0 Then
                        If VarianceLM < 0 Then
                            CellString = "L" & LineNoString
                        Else
                            CellString = "M" & LineNoString
                        End If
                        .Range(CellString).Value = VarianceLM
                        If VarianceLM < -10.0 Or VarianceLM > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    If VarianceNO <> 0.0 Then
                        If VarianceNO < 0 Then
                            CellString = "N" & LineNoString
                        Else
                            CellString = "O" & LineNoString
                        End If
                        .Range(CellString).Value = VarianceLM
                        If VarianceNO < -10.0 Or VarianceNO > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    If VariancePQ <> 0.0 Then
                        If VariancePQ < 0 Then
                            CellString = "P" & LineNoString
                        Else
                            CellString = "Q" & LineNoString
                        End If
                        .Range(CellString).Value = VariancePQ
                        If VariancePQ < -10.0 Or VariancePQ > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    If VarianceRS <> 0.0 Then
                        If VarianceRS < 0 Then
                            CellString = "R" & LineNoString
                        Else
                            CellString = "S" & LineNoString
                        End If
                        .Range(CellString).Value = VarianceRS
                        If VarianceRS < -10.0 Or VarianceRS > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    If VarianceTU <> 0.0 Then
                        If VarianceTU < 0 Then
                            CellString = "T" & LineNoString
                        Else
                            CellString = "U" & LineNoString
                        End If
                        .Range(CellString).Value = VarianceTU
                        If VarianceTU < -10.0 Or VarianceTU > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If
                    If VarianceVW <> 0.0 Then
                        If VarianceVW < 0 Then
                            CellString = "V" & LineNoString
                        Else
                            CellString = "W" & LineNoString
                        End If
                        .Range(CellString).Value = VarianceVW
                        If VarianceVW < -10.0 Or VarianceVW > 10.0 Then .Range(CellString).Interior.Color = Color.Yellow
                    End If

                    CellString = "A" & LineNoString & ":W" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "A" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "B" & LineNoString & ":C" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "D" & LineNoString & ":W" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    .Range(CellString).NumberFormat = "#,###,##0.00"

                    CellString = "C" & LineNoString
                    .Range(CellString).Font.Size = 9
                    .Range(CellString).WrapText = True

                End With
            End If
            SalesBindingSource.MoveNext()
            If SpreadsheetLine > 120 Then Exit Do ' Four months of data on spreadsheet
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        SpreadsheetLine += 1
        LineNoString = SpreadsheetLine

        With xlWorkSheet
            CellString = "C" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "D" & LineNoString
            FormulaString = "=SUM(D4:D" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "E" & LineNoString
            FormulaString = "=SUM(E4:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(E4:E34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "F" & LineNoString
            FormulaString = "=SUM(F4:F" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "G" & LineNoString
            FormulaString = "=SUM(G4:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "H" & LineNoString
            FormulaString = "=SUM(H4:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "I" & LineNoString
            FormulaString = "=SUM(I4:I" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(I4:I34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "J" & LineNoString
            FormulaString = "=SUM(J4:J" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(J4:J34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "K" & LineNoString
            FormulaString = "=SUM(K4:K" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(K4:K34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "L" & LineNoString
            FormulaString = "=SUM(L4:L" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(L4:L34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "M" & LineNoString
            FormulaString = "=SUM(M4:M" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(M4:M34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "N" & LineNoString
            FormulaString = "=SUM(N4:N" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(N4:N34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "O" & LineNoString
            FormulaString = "=SUM(O4:O" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(O4:O34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "P" & LineNoString
            FormulaString = "=SUM(P4:P" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(P4:P34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "Q" & LineNoString
            FormulaString = "=SUM(Q4:Q" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(Q4:Q34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "R" & LineNoString
            FormulaString = "=SUM(R4:R" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(R4:R34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "S" & LineNoString
            FormulaString = "=SUM(S4:S" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(S4:S34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "T" & LineNoString
            FormulaString = "=SUM(T4:T" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(T4:T34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "U" & LineNoString
            FormulaString = "=SUM(U4:U" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(U4:U34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "V" & LineNoString
            FormulaString = "=SUM(V4:V" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(V4:V34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow
            CellString = "W" & LineNoString
            FormulaString = "=SUM(W4:W" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(W4:W34)"
            If .Range(CellString).Value < -50.0 Or .Range(CellString).Value > 50.0 Then .Range(CellString).Interior.Color = Color.Yellow

            CellString = "D" & LineNoString & ":W" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "D" & LineNoString & ":W" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "D" & LineNoString & ":W" & LineNoString
            .Range(CellString).NumberFormat = "#,###,##0.00"
            CellString = "A" & LineNoString & ":W" & LineNoString
            .Range(CellString).Font.Bold = True
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            xlWorkSheet.Range("D6").Select()
            .ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            .Visible = True
        End With
        If CashierVW = "" Then xlWorkSheet.Range("V4:W4").ColumnWidth = 0
        If CashierTU = "" Then xlWorkSheet.Range("T4:U4").ColumnWidth = 0
        If CashierRS = "" Then xlWorkSheet.Range("R4:S4").ColumnWidth = 0
        If CashierPQ = "" Then xlWorkSheet.Range("P4:Q4").ColumnWidth = 0
        If CashierNO = "" Then xlWorkSheet.Range("N4:O4").ColumnWidth = 0
        If CashierLM = "" Then xlWorkSheet.Range("L4:M4").ColumnWidth = 0
        If CashierJK = "" Then xlWorkSheet.Range("J4:K4").ColumnWidth = 0
        If CashierHI = "" Then xlWorkSheet.Range("H4:I4").ColumnWidth = 0
        If CashierFG = "" Then xlWorkSheet.Range("F4:G4").ColumnWidth = 0
        If CashierDE = "" Then xlWorkSheet.Range("D4:E4").ColumnWidth = 0

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

    Private Sub getCashiers()
        Dim CurrentRecordId As Integer
        Dim SQLString As String = "Select * From CashupView Where Date >= '" & DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' and Date <= '" & DateTime.Parse(txtDateTo.Text).ToString("dd MMM yyyy") & "' And SalesType = 0 Order by Date"
        Try
            Dim SQL = SQLString
            CVDC = New CashUpViewDataContext
            CashupViewBindingSource.DataSource = CVDC.ExecuteQuery(Of CashupView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
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
                Do
                    If CashierDE = "" Then CashierDE = CashupViewRow.EmployeeName
                    If CashierDE = CashupViewRow.EmployeeName Then Exit Do
                    If CashierFG = "" Then CashierFG = CashupViewRow.EmployeeName
                    If CashierFG = CashupViewRow.EmployeeName Then Exit Do
                    If CashierHI = "" Then CashierHI = CashupViewRow.EmployeeName
                    If CashierHI = CashupViewRow.EmployeeName Then Exit Do
                    If CashierJK = "" Then CashierJK = CashupViewRow.EmployeeName
                    If CashierJK = CashupViewRow.EmployeeName Then Exit Do
                    If CashierLM = "" Then CashierLM = CashupViewRow.EmployeeName
                    If CashierLM = CashupViewRow.EmployeeName Then Exit Do
                    If CashierNO = "" Then CashierNO = CashupViewRow.EmployeeName
                    If CashierNO = CashupViewRow.EmployeeName Then Exit Do
                    If CashierPQ = "" Then CashierPQ = CashupViewRow.EmployeeName
                    If CashierPQ = CashupViewRow.EmployeeName Then Exit Do
                    If CashierRS = "" Then CashierRS = CashupViewRow.EmployeeName
                    If CashierRS = CashupViewRow.EmployeeName Then Exit Do
                    If CashierTU = "" Then CashierTU = CashupViewRow.EmployeeName
                    If CashierTU = CashupViewRow.EmployeeName Then Exit Do
                    If CashierVW = "" Then CashierVW = CashupViewRow.EmployeeName
                    Exit Do
                Loop
            End If
            CashupViewBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub getCashupFigures()
        Dim CurrentRecordId As Integer

        Dim SQLString As String = "Select * From CashupView Where Date = '" & DateTime.Parse(SalesRow.Date).ToString("dd MMM yyyy") & "' And SalesType = 0"
        Try
            Dim SQL = SQLString
            CVDC = New CashUpViewDataContext
            CashupViewBindingSource.DataSource = CVDC.ExecuteQuery(Of CashupView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        VarianceDE = 0.0
        VarianceFG = 0.0
        VarianceHI = 0.0
        VarianceJK = 0.0
        VarianceLM = 0.0
        VarianceNO = 0.0
        VariancePQ = 0.0
        VarianceRS = 0.0
        VarianceTU = 0.0
        VarianceVW = 0.0
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

                If CashierDE = CashupViewRow.EmployeeName Then VarianceDE += CashupViewRow.Variance
                If CashierFG = CashupViewRow.EmployeeName Then VarianceFG += CashupViewRow.Variance
                If CashierHI = CashupViewRow.EmployeeName Then VarianceHI += CashupViewRow.Variance
                If CashierJK = CashupViewRow.EmployeeName Then VarianceJK += CashupViewRow.Variance
                If CashierLM = CashupViewRow.EmployeeName Then VarianceLM += CashupViewRow.Variance
                If CashierNO = CashupViewRow.EmployeeName Then VarianceNO += CashupViewRow.Variance
                If CashierPQ = CashupViewRow.EmployeeName Then VariancePQ += CashupViewRow.Variance
                If CashierRS = CashupViewRow.EmployeeName Then VarianceRS += CashupViewRow.Variance
                If CashierTU = CashupViewRow.EmployeeName Then VarianceTU += CashupViewRow.Variance
            End If
            CashupViewBindingSource.MoveNext()
        Loop
    End Sub

End Class