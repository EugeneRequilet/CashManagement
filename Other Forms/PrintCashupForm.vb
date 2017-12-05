Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class PrintCashupForm
    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    'Dim XLFileName As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Cash-up " & Format(Now, "yyyy-MM-dd")
    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Cash-up " & Format(Now, "yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Public RecordId As Integer

    Dim DC As CashUpDataContext
    Dim CashUpRow As CashUp
    Dim EDC As EmployeeDataContext
    Dim EmployeeRow As Employee

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub PrintCashupForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New CashUpDataContext
        BindingSource1.DataSource = From CashUp In DC.CashUps Where CashUp.RecordId = RecordId
        CashUpRow = BindingSource1.Current
        If CashUpRow Is Nothing Then
            MsgBox("Nothing to Print")
            Me.Close()
        End If
        ReadEmployee()
        FormatText()
        CloseButton.Select()
    End Sub

    Private Sub ReadEmployee()
        Try
            EmployeeBindingSource.DataSource = From Employee In (New EmployeeDataContext).Employees Where Employee.RecordId = CashUpRow.EmployeeRecordId
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        EmployeeRow = If(EmployeeBindingSource.Current, New Employee)
    End Sub

    Private Sub FormatText()

        ' Cash-Up Printing Defaults

        txtCashupDate.Text = CashUpRow.Date
        txtTimeOfCashup.Text = "Shift " & (CashUpRow.Time + 1)

        ' Cash Details Group 

        txtCashInTill.EditValue = CashUpRow.CalculatedTillTotal
        txtFloatInTill.EditValue = CashUpRow.CalculatedFloatTotal
        txtCashInTillLessFloat.EditValue = CashUpRow.CalculatedTillTotal - CashUpRow.CalculatedFloatTotal
        txtCashAdjBy.EditValue = CashUpRow.CalDepIncreasedByTotal - CashUpRow.CalDepReducedByTotal

        ' Deposit Details Group 

        txtCalcDepositCashTotal.EditValue = txtCashInTillLessFloat.EditValue + txtCashAdjBy.EditValue
        txtTotalCreditCard.EditValue = CashUpRow.TotalCreditCard

        ' Payouts Group

        txtPayout1.EditValue = CashUpRow.Payout1
        txtPayoutReason1.Text = CashUpRow.PayoutReason1
        txtPayout2.EditValue = CashUpRow.Payout2
        txtPayoutReason2.Text = CashUpRow.PayoutReason2
        txtPayout3.EditValue = CashUpRow.Payout3
        txtPayoutReason3.Text = CashUpRow.PayoutReason3
        txtPayout4.EditValue = CashUpRow.Payout4
        txtPayoutReason4.Text = CashUpRow.PayoutReason4
        txtPayout5.EditValue = CashUpRow.Payout5
        txtPayoutReason5.Text = CashUpRow.PayoutReason5
        txtPayout6.EditValue = CashUpRow.Payout6
        txtPayoutReason6.Text = CashUpRow.PayoutReason6
        txtPayoutTotal.EditValue = CashUpRow.Payout1 + CashUpRow.Payout2 + CashUpRow.Payout3 + CashUpRow.Payout4 + CashUpRow.Payout5 + CashUpRow.Payout6

        ' Other Details Group

        txtCalcDepRedByTotal.EditValue = (CashUpRow.DepRedByR200 * 200) + (CashUpRow.DepRedByR100 * 100) + _
                                (CashUpRow.DepRedByR50 * 50) + (CashUpRow.DepRedByR20 * 20) + (CashUpRow.DepRedByR10 * 10) + _
                                (CashUpRow.DepRedByR5 * 5) + (CashUpRow.DepRedByR2 * 2) + (CashUpRow.DepRedByR1 * 1) + _
                                (CashUpRow.DepRedByC50 * 0.5) + (CashUpRow.DepRedByC20 * 0.2) + (CashUpRow.DepRedByC10 * 0.1)

        txtCalcDepIncByTotal.EditValue = (CashUpRow.DepIncByR200 * 200) + (CashUpRow.DepIncByR100 * 100) + _
                                (CashUpRow.DepIncByR50 * 50) + (CashUpRow.DepIncByR20 * 20) + (CashUpRow.DepIncByR10 * 10) + _
                                (CashUpRow.DepIncByR5 * 5) + (CashUpRow.DepIncByR2 * 2) + (CashUpRow.DepIncByR1 * 1) + _
                                (CashUpRow.DepIncByC50 * 0.5) + (CashUpRow.DepIncByC20 * 0.2) + (CashUpRow.DepIncByC10 * 0.1)

        txtCashUpVariance.EditValue = CashUpRow.CashupVariance

        ' Deposit Skims Group

        txtDepositSkim1.EditValue = CashUpRow.DepositedSkim1
        txtDepositSkim2.EditValue = CashUpRow.DepositedSkim2
        txtDepositSkim3.EditValue = CashUpRow.DepositedSkim3
        txtDepositSkimTotal.EditValue = CashUpRow.DepositedSkim1 + CashUpRow.DepositedSkim2 + CashUpRow.DepositedSkim3

        txtCashupGrossSales.EditValue = txtCashInTillLessFloat.EditValue + txtPayoutTotal.EditValue + txtDepositSkimTotal.EditValue + txtTotalCreditCard.EditValue

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub PrintExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        CreateExcelWorkbook()
        WriteExcelHeadings()
        WriteExcelData()
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

    Private Sub WriteExcelHeadings()
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

            .Range("A2").Value = "Report Printed On: " & Today.ToLongDateString
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 11

            .Range("A3").Value = "Cash-up Sheet For " & txtEmployeeName.Text & " On " & txtCashupDate.Text & " Shift " & txtTimeOfCashup.Text
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 12

        End With
    End Sub

    Private Sub WriteExcelData()
        With xlWorkSheet
            .Range("A5").Value = "Cash in Till "
            .Range("B5").Value = txtCashInTill.EditValue
            .Range("A6").Value = "Float in Till"
            .Range("B6").Value = txtFloatInTill.EditValue
            .Range("A7").Value = "Cash In Till less Float"
            .Range("B7").Value = txtCashInTillLessFloat.EditValue
            .Range("A8").Value = "Cash Deposit Adjusted By"
            .Range("B8").Value = txtCashAdjBy.EditValue

            .Range("A10").Value = "Cash Deposited"
            .Range("B10").Value = txtCalcDepositCashTotal.EditValue
            .Range("A11").Value = "Credit Cards"
            .Range("B11").Value = txtTotalCreditCard.EditValue
            .Range("A12").Value = "Banked"
            .Range("B12").Formula = "=SUM(B10:B11)"

            .Range("A14").Value = "Cash Added to Deposit"
            .Range("B14").Value = txtCalcDepIncByTotal.EditValue
            .Range("D14").Value = "Cash Removed From Deposit"
            .Range("E14").Value = txtCalcDepRedByTotal.EditValue
            .Range("A15").Value = "Cash-up Variance"
            .Range("B15").Value = txtCashUpVariance.EditValue

            .Range("A17").Value = "Total Payouts"
            .Range("B17").Formula = "=SUM(B18:B23)"
            .Range("A18").Value = "Payout 1"
            .Range("B18").Value = txtPayout1.EditValue
            .Range("D18").Value = txtPayoutReason1.Text
            .Range("A19").Value = "Payout 2"
            .Range("B19").Value = txtPayout2.EditValue
            .Range("D19").Value = txtPayoutReason2.Text
            .Range("A20").Value = "Payout 3"
            .Range("B20").Value = txtPayout3.EditValue
            .Range("D20").Value = txtPayoutReason3.Text
            .Range("A21").Value = "Payout 4"
            .Range("B21").Value = txtPayout4.EditValue
            .Range("D21").Value = txtPayoutReason4.Text
            .Range("A22").Value = "Payout 5"
            .Range("B22").Value = txtPayout5.EditValue
            .Range("D22").Value = txtPayoutReason5.Text
            .Range("A23").Value = "Payout 6"
            .Range("B23").Value = txtPayout6.EditValue
            .Range("D23").Value = txtPayoutReason6.Text

            .Range("D5").Value = "Total Deposit Skims"
            .Range("E5").Formula = "=SUM(E6:E8)"
            .Range("D6").Value = "Deposit Skim 1"
            .Range("E6").Value = txtDepositSkim1.EditValue
            .Range("D7").Value = "Deposit Skim 2"
            .Range("E7").Value = txtDepositSkim2.EditValue
            .Range("D8").Value = "Deposit Skim 3"
            .Range("E8").Value = txtDepositSkim3.EditValue
            .Range("D10").Value = "Cash-up Gross Sales"
            .Range("E10").Value = txtCashupGrossSales.EditValue

            .Range("A31").Value = "Signature " & txtEmployeeName.Text
            .Range("A32").Value = "_________________________________________________________________________________________________________"
            .Range("A31").Font.Bold = True
            .Range("A31").Font.Size = 16
            .Range("A31:A32").HorizontalAlignment = Excel.Constants.xlLeft

            .Range("A33").Value = "I " & txtEmployeeName.Text & " have attached deposit slips to the value of R " & Format(txtCalcDepositCashTotal.EditValue, "N2")
            .Range("A34").Value = "I " & txtEmployeeName.Text & " have attached Credit Card slips to the value of R " & Format(txtTotalCreditCard.EditValue, "N2")
            If .Range("B17").Value = 0 Then
                .Range("A35").Value = "I " & txtEmployeeName.Text & " have had no Payouts for this shift"
            Else
                .Range("A35").Value = "I " & txtEmployeeName.Text & " have attached Payout slips for the total value of R " & Format(.Range("B17").Value, "N2")
            End If
            If txtCashUpVariance.EditValue = 0 Then
                .Range("A36").Value = "I " & txtEmployeeName.Text & " have checked my variance and it has a value of Zero"
            End If
            If txtCashUpVariance.EditValue > 0 Then
                .Range("A36").Value = "I " & txtEmployeeName.Text & " have checked my variance and it is over by R " & Format(txtCashUpVariance.EditValue, "N2")
            End If
            If txtCashUpVariance.EditValue < 0 Then
                .Range("A36").Value = "I " & txtEmployeeName.Text & " have checked my variance and it is short by R " & Format(txtCashUpVariance.EditValue, "N2")
            End If
            If txtCashUpVariance.EditValue < 0 Then
                .Range("A36").Value = "I " & txtEmployeeName.Text & " have checked my variance and it is short by R " & Format(txtCashUpVariance.EditValue, "N2")
            End If
            If txtCalcDepRedByTotal.EditValue <> 0 Then
                .Range("A37").Value = "I " & txtEmployeeName.Text & " have removed R " & Format(txtCalcDepRedByTotal.EditValue, "N2") & " from the deposit and added it to funny money"
                .Range("H37").Borders.LineStyle = Excel.Constants.xlSolid
            End If
            If txtCalcDepIncByTotal.EditValue <> 0 Then
                .Range("A38").Value = "I " & txtEmployeeName.Text & " have taken R " & Format(txtCalcDepIncByTotal.EditValue, "N2") & " from the funny money and added it to this deposit"
                .Range("H38").Borders.LineStyle = Excel.Constants.xlSolid
            End If

            .Range("A5:A23").Font.Bold = True
            .Range("A5:A23").Font.Size = 11
            .Range("A5:A23").HorizontalAlignment = Excel.Constants.xlRight

            .Range("D5:D14").Font.Bold = True
            .Range("D5:D14").Font.Size = 11
            .Range("D5:D14").HorizontalAlignment = Excel.Constants.xlRight

            .Range("B5:B23").Font.Bold = False
            .Range("E5:E23").Font.Bold = False
            .Range("B5:F23").Font.Size = 11
            .Range("E5:E23").Font.Size = 11
            .Range("B5:B23").NumberFormat = "#,###,##0.00"
            .Range("E5:E23").NumberFormat = "#,###,##0.00"
            .Range("B5:B23").HorizontalAlignment = Excel.Constants.xlRight
            .Range("E5:E23").HorizontalAlignment = Excel.Constants.xlRight

            .Range("B12").Font.Bold = True
            .Range("B17").Font.Bold = True
            .Range("E5").Font.Bold = True
            .Range("E10").Font.Bold = True

            ' Setup Column Widths

            .Range("A5:A5").ColumnWidth = 25
            .Range("B5:F5").ColumnWidth = 11
            .Range("C5:C5").ColumnWidth = 2
            .Range("D5:D5").ColumnWidth = 25
            .Range("E5:E5").ColumnWidth = 11

            .Range("B5:B8").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("B10:B12").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("B14:B15").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("E14:E14").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("B17:B23").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("D18:D23").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("E5:E8").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("E10:E10").Borders.LineStyle = Excel.Constants.xlSolid

            .Range("H33:H36").Borders.LineStyle = Excel.Constants.xlSolid

        End With
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

    Private Sub XLWorkSheetSetup()
        xlWorkSheet.Protect("Admin", DrawingObjects:=True, Contents:=True, Scenarios:= _
                            True, AllowFormattingCells:=False, AllowFormattingColumns:=False, _
                            AllowFormattingRows:=False, AllowInsertingColumns:=False, AllowInsertingRows _
                            :=False, AllowInsertingHyperlinks:=False, AllowDeletingColumns:=False, _
                            AllowDeletingRows:=True, AllowSorting:=False, AllowFiltering:=False, _
                            AllowUsingPivotTables:=False)
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

End Class