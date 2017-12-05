Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class DailyReconcForm
    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    'Dim XLFileName As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\Daily " & Format(Now, "yyyy-MM-dd")
    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Daily " & Format(Now, "yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SDC As SalesDataContext
    Dim SalesRow As Sales
    Dim CUVDC As CashUpViewDataContext
    Dim CashupRow As CashupView

    Private Sub DailyReconcForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
        Me.dteSelectDate.Select()
    End Sub

    Private Sub dteSelectDate_ValueChanged(sender As Object, e As EventArgs) Handles dteSelectDate.ValueChanged
        ClearScreenFields()
        LoadData()
        Me.dteSelectDate.Select()
    End Sub

    Private Sub LoadData()

        'Load the sales data first

        SDC = New SalesDataContext
        SalesBindingSource.DataSource = From Sales In SDC.Sales Where Sales.Date = CDate(dteSelectDate.Text)
        SalesRow = SalesBindingSource.Current
        If SalesRow Is Nothing Then
            MsgBox("Nothing to Display for the " & dteSelectDate.Text & vbCrLf & "Please select another Date")
        Else
            Cashup1Group.Visible = False
            Cashup2Group.Visible = False
            Cashup3Group.Visible = False
            Cashup4Group.Visible = False

            'Loop and Load the CashupView data next

            CUVDC = New CashUpViewDataContext
            CashupBindingSource.DataSource = From CashupView In CUVDC.CashupViews Where CashupView.Date = CDate(dteSelectDate.Text) Order By CashupView.Date, CashupView.Time, CashupView.EmployeeRecordId
            Dim RecordCount As Integer = CashupBindingSource.Count
            If RecordCount > 0 Then
                Dim Count As Integer
                For Count = 1 To RecordCount
                    CashupBindingSource.Position = Count - 1
                    CashupRow = CashupBindingSource.Current
                    If CashupRow Is Nothing Then
                        'MsgBox("Nothing to Display")
                    Else
                        FormatCashupText(Count)
                    End If
                Next
            End If
            FormatSalesText()
            CheckBalances()

            'MsgBox("Display: " & dteSelectDate.Text)

        End If
    End Sub

    Private Sub ClearScreenFields()
        txtCashup1Employee.Text = ""
        txtCashup1CreditCard.EditValue = 0.0
        txtCashup1Payout.EditValue = 0.0
        txtCashup1Skims.EditValue = 0.0
        txtCashup1Cash.EditValue = 0.0
        txtCashup1Adjustment.EditValue = 0.0
        txtCashup1Deposit.EditValue = 0.0
        txtCashup1Variance.EditValue = 0.0

        txtCashup2Employee.Text = ""
        txtCashup2CreditCard.EditValue = 0.0
        txtCashup2Payout.EditValue = 0.0
        txtCashup2Skims.EditValue = 0.0
        txtCashup2Cash.EditValue = 0.0
        txtCashup2Adjustment.EditValue = 0.0
        txtCashup2Deposit.EditValue = 0.0
        txtCashup2Variance.EditValue = 0.0

        txtCashup3Employee.Text = ""
        txtCashup3CreditCard.EditValue = 0.0
        txtCashup3Payout.EditValue = 0.0
        txtCashup3Skims.EditValue = 0.0
        txtCashup3Cash.EditValue = 0.0
        txtCashup3Adjustment.EditValue = 0.0
        txtCashup3Deposit.EditValue = 0.0
        txtCashup3Variance.EditValue = 0.0

        txtCashup4Employee.Text = ""
        txtCashup4CreditCard.EditValue = 0.0
        txtCashup4Payout.EditValue = 0.0
        txtCashup4Skims.EditValue = 0.0
        txtCashup4Cash.EditValue = 0.0
        txtCashup4Adjustment.EditValue = 0.0
        txtCashup4Deposit.EditValue = 0.0
        txtCashup4Variance.EditValue = 0.0

        txtCashupSalesGross.EditValue = 0.0
        txtCashupCreditCardTotal.EditValue = 0.0
        txtCashupPayoutTotal.EditValue = 0.0
        txtCashupCashTotal.EditValue = 0.0
        txtCashupAdjustmentTotal.EditValue = 0.0
        txtCashupDepositTotal.EditValue = 0.0
        txtCashupVarianceTotal.EditValue = 0.0

        txtSalesGross.EditValue = 0.0
        txtSalesCreditCard.EditValue = 0.0
        txtSalesPayout.EditValue = 0.0
        txtSalesCash.EditValue = 0.0

        txtVarianceSalesGross.EditValue = 0.0
        txtVarianceCreditCardTotal.EditValue = 0.0
        txtVariancePayoutTotal.EditValue = 0.0
        txtVarianceCashTotal.EditValue = 0.0
    End Sub
    Private Sub FormatSalesText()

        ' Sales Detail Group 

        txtSalesGross.EditValue = SalesRow.GrossSales
        txtSalesCreditCard.EditValue = SalesRow.TurnoverCreditCard
        'txtSalesOther.EditValue = SalesRow.TurnoverOther
        txtSalesCash.EditValue = SalesRow.TurnoverCash
        txtSalesPayout.EditValue = SalesRow.Payout

    End Sub
    Private Sub FormatCashupText(Counter As Integer)

        ' CashupView Detail Group in a loop.

        Select Case Counter
            Case 1
                Cashup1Group.Visible = True
                Cashup1Group.Text = "Shift " & (CashupRow.Time + 1)
                txtCashup1Employee.Text = CashupRow.EmployeeName
                txtCashup1CreditCard.EditValue = CashupRow.CreditCardDeposited
                txtCashup1Payout.EditValue = CashupRow.Payouts
                txtCashup1Skims.EditValue = CashupRow.DepositSkims
                txtCashup1Cash.EditValue = CashupRow.CashInTillLessFloat
                txtCashup1Adjustment.EditValue = CashupRow.DepIncreasedBy - CashupRow.DepReducedBy
                txtCashup1Deposit.EditValue = CashupRow.CashDeposited
                txtCashup1Variance.EditValue = CashupRow.Variance
            Case 2
                Cashup2Group.Visible = True
                Cashup2Group.Text = "Shift " & (CashupRow.Time + 1)
                txtCashup2Employee.Text = CashupRow.EmployeeName
                txtCashup2CreditCard.EditValue = CashupRow.CreditCardDeposited
                txtCashup2Payout.EditValue = CashupRow.Payouts
                txtCashup2Skims.EditValue = CashupRow.DepositSkims
                txtCashup2Cash.EditValue = CashupRow.CashInTillLessFloat
                txtCashup2Adjustment.EditValue = CashupRow.DepIncreasedBy - CashupRow.DepReducedBy
                txtCashup2Deposit.EditValue = CashupRow.CashDeposited
                txtCashup2Variance.EditValue = CashupRow.Variance
            Case 3
                Cashup3Group.Visible = True
                Cashup3Group.Text = "Shift " & (CashupRow.Time + 1)
                txtCashup3Employee.Text = CashupRow.EmployeeName
                txtCashup3CreditCard.EditValue = CashupRow.CreditCardDeposited
                txtCashup3Payout.EditValue = CashupRow.Payouts
                txtCashup3Skims.EditValue = CashupRow.DepositSkims
                txtCashup3Cash.EditValue = CashupRow.CashInTillLessFloat
                txtCashup3Adjustment.EditValue = CashupRow.DepIncreasedBy - CashupRow.DepReducedBy
                txtCashup3Deposit.EditValue = CashupRow.CashDeposited
                txtCashup3Variance.EditValue = CashupRow.Variance
            Case 4
                Cashup4Group.Visible = True
                Cashup4Group.Text = "Shift " & (CashupRow.Time + 1)
                txtCashup4Employee.Text = CashupRow.EmployeeName
                txtCashup4CreditCard.EditValue = CashupRow.CreditCardDeposited
                txtCashup4Payout.EditValue = CashupRow.Payouts
                txtCashup4Skims.EditValue = CashupRow.DepositSkims
                txtCashup4Cash.EditValue = CashupRow.CashInTillLessFloat
                txtCashup4Adjustment.EditValue = CashupRow.DepIncreasedBy - CashupRow.DepReducedBy
                txtCashup4Deposit.EditValue = CashupRow.CashDeposited
                txtCashup4Variance.EditValue = CashupRow.Variance
        End Select
        txtCashupCreditCardTotal.EditValue += CashupRow.CreditCardDeposited
        txtCashupPayoutTotal.EditValue += CashupRow.Payouts
        txtCashupAdjustmentTotal.EditValue += CashupRow.DepIncreasedBy - CashupRow.DepReducedBy
        txtCashupCashTotal.EditValue += (CashupRow.CashInTillLessFloat + CashupRow.DepositSkims)
        txtCashupDepositTotal.EditValue += CashupRow.CashDeposited
        txtCashupSalesGross.EditValue += (CashupRow.CreditCardDeposited + CashupRow.CashInTillLessFloat + CashupRow.Payouts + CashupRow.DepositSkims)
        txtCashupVarianceTotal.EditValue += CashupRow.Variance

    End Sub
    Private Sub CheckBalances()
        txtVarianceSalesGross.EditValue = txtCashupSalesGross.EditValue - txtSalesGross.EditValue
        txtVarianceCreditCardTotal.EditValue = txtCashupCreditCardTotal.EditValue - txtSalesCreditCard.EditValue
        txtVarianceCashTotal.EditValue = txtCashupCashTotal.EditValue - txtSalesCash.EditValue
        txtVariancePayoutTotal.EditValue = txtCashupPayoutTotal.EditValue - txtSalesPayout.EditValue
        If txtSalesGross.EditValue = txtCashupSalesGross.EditValue Then
            txtSalesGross.TextBox1.BackColor = System.Drawing.Color.White
            txtCashupSalesGross.TextBox1.BackColor = System.Drawing.Color.White
        Else
            txtSalesGross.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCashupSalesGross.TextBox1.BackColor = System.Drawing.Color.Yellow
        End If
        If txtSalesCreditCard.EditValue = txtCashupCreditCardTotal.EditValue Then
            txtSalesCreditCard.TextBox1.BackColor = System.Drawing.Color.White
            txtCashupCreditCardTotal.TextBox1.BackColor = System.Drawing.Color.White
        Else
            txtSalesCreditCard.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCashupCreditCardTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
        End If
        If txtSalesCash.EditValue = txtCashupCashTotal.EditValue Then
            txtSalesCash.TextBox1.BackColor = System.Drawing.Color.White
            txtCashupCashTotal.TextBox1.BackColor = System.Drawing.Color.White
        Else
            txtSalesCash.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCashupCashTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
        End If
        If txtSalesPayout.EditValue = txtCashupPayoutTotal.EditValue Then
            txtSalesPayout.TextBox1.BackColor = System.Drawing.Color.White
            txtCashupPayoutTotal.TextBox1.BackColor = System.Drawing.Color.White
        Else
            txtSalesPayout.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCashupPayoutTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
        End If
        If txtVarianceCreditCardTotal.EditValue = 0.0 Then
            txtVarianceCreditCardTotal.TextBox1.BackColor = System.Drawing.Color.White
            txtCreditCardTotalQuestion.Visible = False
        Else
            txtVarianceCreditCardTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCreditCardTotalQuestion.Visible = True
        End If
        If txtVariancePayoutTotal.EditValue = 0.0 Then
            txtVariancePayoutTotal.TextBox1.BackColor = System.Drawing.Color.White
            txtPayoutTotalQuestion.Visible = False
        Else
            txtVariancePayoutTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtPayoutTotalQuestion.Visible = True
        End If
        If txtVarianceCashTotal.EditValue = 0.0 Then
            txtVarianceCashTotal.TextBox1.BackColor = System.Drawing.Color.White
            txtCashTotalQuestion.Visible = False
        Else
            txtVarianceCashTotal.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtCashTotalQuestion.Visible = True
        End If
        If txtVarianceSalesGross.EditValue = 0.0 Then
            txtVarianceSalesGross.TextBox1.BackColor = System.Drawing.Color.White
            txtSalesGrossQuestion.Visible = False
        Else
            txtVarianceSalesGross.TextBox1.BackColor = System.Drawing.Color.Yellow
            txtSalesGrossQuestion.Visible = True
        End If
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub PrintExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        XLFileName = "Daily " & Format(dteSelectDate.Value, "yyyy-MM")
        CreateExcelWorkbook()
        WriteExcelHeadings()
        WriteExcelData()
        DisplayExcelWorkbook()
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

            .Range("A3").Value = "Reconciliation Sheet For " & dteSelectDate.Text
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 16

        End With
    End Sub

    Private Sub WriteExcelData()
        With xlWorkSheet
            .Range("B4").Value = "Cash-up Totals"
            .Range("C4").Value = "Cash-up 1"
            .Range("D4").Value = "Cash-up 2"
            .Range("E4").Value = "Cash-up 3"
            .Range("F4").Value = "Cash-up 4"

            ' Cash-ups

            .Range("C4").Value = Cashup1Group.Text
            .Range("D4").Value = Cashup2Group.Text
            .Range("E4").Value = Cashup3Group.Text
            .Range("F4").Value = Cashup4Group.Text

            .Range("A6").Value = "Employee"
            .Range("C6").Value = txtCashup1Employee.Text
            .Range("D6").Value = txtCashup2Employee.Text
            .Range("E6").Value = txtCashup3Employee.Text
            .Range("F6").Value = txtCashup4Employee.Text
            .Range("C6:F6").WrapText = True
            .Range("C6:F6").HorizontalAlignment = Excel.Constants.xlCenter
            .Range("C6:F6").Borders.LineStyle = Excel.Constants.xlSolid

            ' Cash-up 1

            .Range("C8").Value = txtCashup1CreditCard.EditValue
            .Range("C9").Value = txtCashup1Payout.EditValue
            .Range("C10").Value = txtCashup1Skims.EditValue
            .Range("C11").Value = txtCashup1Cash.EditValue
            .Range("C12").Value = txtCashup1Adjustment.EditValue
            .Range("C13").Value = txtCashup1Deposit.EditValue
            .Range("C14").Value = txtCashup1Variance.EditValue

            ' Cash-up 2

            .Range("D8").Value = txtCashup2CreditCard.EditValue
            .Range("D9").Value = txtCashup2Payout.EditValue
            .Range("D10").Value = txtCashup2Skims.EditValue
            .Range("D11").Value = txtCashup2Cash.EditValue
            .Range("D12").Value = txtCashup2Adjustment.EditValue
            .Range("D13").Value = txtCashup2Deposit.EditValue
            .Range("D14").Value = txtCashup2Variance.EditValue

            ' Cash-up 3

            .Range("E8").Value = txtCashup3CreditCard.EditValue
            .Range("E9").Value = txtCashup3Payout.EditValue
            .Range("E10").Value = txtCashup3Skims.EditValue
            .Range("E11").Value = txtCashup3Cash.EditValue
            .Range("E12").Value = txtCashup3Adjustment.EditValue
            .Range("E13").Value = txtCashup3Deposit.EditValue
            .Range("E14").Value = txtCashup3Variance.EditValue

            ' Cash-up 4

            .Range("F8").Value = txtCashup4CreditCard.EditValue
            .Range("F9").Value = txtCashup4Payout.EditValue
            .Range("F10").Value = txtCashup4Skims.EditValue
            .Range("F11").Value = txtCashup4Cash.EditValue
            .Range("F12").Value = txtCashup4Adjustment.EditValue
            .Range("F13").Value = txtCashup4Deposit.EditValue
            .Range("F14").Value = txtCashup4Variance.EditValue

            ' Sales 

            .Range("C18").Value = txtSalesGross.EditValue
            .Range("C19").Value = txtSalesCreditCard.EditValue
            .Range("C20").Value = txtSalesPayout.EditValue
            .Range("C21").Value = txtSalesCash.EditValue

            ' Set up totals

            .Range("A7").Value = "Gross Sales"
            .Range("B7").Formula = "=SUM(C7:F7)"
            .Range("C7").Formula = "=SUM(C8:C11)"
            .Range("D7").Formula = "=SUM(D8:D11)"
            .Range("E7").Formula = "=SUM(E8:E11)"
            .Range("F7").Formula = "=SUM(F8:F11)"
            .Range("A8").Value = "Credit Cards"
            .Range("B8").Formula = "=SUM(C8:F8)"
            .Range("A9").Value = "Payouts"
            .Range("B9").Formula = "=SUM(C9:F9)"
            .Range("A10").Value = "Deposit Skims"
            .Range("B10").Formula = "=SUM(C10:F10)"
            .Range("A11").Value = "Cash"
            .Range("B11").Formula = "=SUM(C11:F11)"
            .Range("A12").Value = "Deposit Adjusted By"
            .Range("B12").Formula = "=SUM(C12:F12)"
            .Range("A13").Value = "Cash Deposited"
            .Range("B13").Formula = "=SUM(C13:F13)"
            .Range("A14").Value = "Cashier Variance"
            .Range("B14").Formula = "=SUM(C14:F14)"

            .Range("A6:A14").Font.Bold = True
            .Range("A6:A14").Font.Size = 11
            .Range("A6:A14").HorizontalAlignment = Excel.Constants.xlRight

            .Range("B16").Value = "Cash-up Totals"
            .Range("C16").Value = "Daily Sales"
            .Range("D16").Value = "Cash-up Variance"
            .Range("E16").Value = "Errors"

            .Range("B16:E16").Font.Bold = True
            .Range("B16:E16").Font.Size = 11
            .Range("B16:E16").WrapText = True
            .Range("B16:E16").HorizontalAlignment = Excel.Constants.xlCenter

            .Range("A18").Value = "Gross Sales"
            .Range("B18").Value = txtCashupSalesGross.EditValue
            .Range("D18").Formula = "=B18-C18"
            .Range("E18").Formula = "=IF(D18<>0,""Gross Sales and Till do not balance"","""")"
            .Range("A19").Value = "Credit Cards"
            .Range("B19").Formula = "=B8"
            .Range("D19").Formula = "=B19-C19"
            .Range("E19").Formula = "=IF(D19<>0,""Credit Card amounts do not balance"","""")"
            .Range("A20").Value = "Payouts"
            .Range("B20").Formula = "=B9"
            .Range("D20").Formula = "=B20-C20"
            .Range("E20").Formula = "=IF(D20<>0,""Payouts do not balance"","""")"
            .Range("A21").Value = "Cash including Skims"
            .Range("B21").Formula = "=B11+B10"
            .Range("D21").Formula = "=B21-C21"
            .Range("E21").Formula = "=IF(D21<>0,""Cash amounts do not balance"","""")"

            .Range("A22").Value = "Cashier Variance"
            .Range("B22").Formula = "=B14"
            .Range("E22").Formula = "=IF(B22<>0,""The Cashier has a Variance"","""")"

            .Range("A32").Value = "Signature " & GlobalLoginEmployeeName
            .Range("A33").Value = "_______________________________________________________________________________________________________"

            .Range("A34").Value = "I " & GlobalLoginEmployeeName & " have attached the Total Credit Card slip and it has a value R " & Format(.Range("B8").Value, "N2")

            ' Setup Column Widths

            .Range("A4:A4").ColumnWidth = 18
            .Range("B4:F4").ColumnWidth = 11
            .Range("B4:F4").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("B6:F14").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("B16:E16").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("B18:D21").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("B22:B22").Borders.LineStyle = Excel.Constants.xlSolid

            .Range("H34:H34").Borders.LineStyle = Excel.Constants.xlSolid

            .Range("B4:F4").Font.Size = 11
            .Range("B4:F4").WrapText = True
            .Range("B4:F4").HorizontalAlignment = Excel.Constants.xlCenter
            .Range("B4:F4").Font.Bold = True

            .Range("A18:A22").Font.Bold = True
            .Range("A18:A22").Font.Size = 11
            .Range("A18:A22").HorizontalAlignment = Excel.Constants.xlRight

            .Range("A32").Font.Bold = True
            .Range("A32").Font.Size = 16
            .Range("A32:A33").HorizontalAlignment = Excel.Constants.xlLeft

            .Range("B6:F14").Font.Bold = False
            .Range("B6:F14").Font.Size = 11
            .Range("B6:F14").NumberFormat = "#,###,##0.00"
            .Range("B6:F14").HorizontalAlignment = Excel.Constants.xlRight
            .Range("B18:D22").Font.Bold = False
            .Range("B18:D22").Font.Size = 11
            .Range("B18:D22").NumberFormat = "#,###,##0.00"
            .Range("B18:D22").HorizontalAlignment = Excel.Constants.xlRight

            .Range("E18:E22").Font.Bold = True

            If .Range("D18").Value <> 0.0 Then .Range("D18").Interior.Color = Color.Yellow
            If .Range("D19").Value <> 0.0 Then .Range("D19").Interior.Color = Color.Yellow
            If .Range("D20").Value <> 0.0 Then .Range("D20").Interior.Color = Color.Yellow
            If .Range("D21").Value <> 0.0 Then .Range("D21").Interior.Color = Color.Yellow
            If .Range("B22").Value <> 0.0 Then .Range("B22").Interior.Color = Color.Yellow

        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            xlWorkSheet.Protect("Admin", DrawingObjects:=True, Contents:=True, Scenarios:= _
                                True, AllowFormattingCells:=False, AllowFormattingColumns:=False, _
                                AllowFormattingRows:=False, AllowInsertingColumns:=False, AllowInsertingRows _
                                :=False, AllowInsertingHyperlinks:=False, AllowDeletingColumns:=False, _
                                AllowDeletingRows:=True, AllowSorting:=False, AllowFiltering:=False, _
                                AllowUsingPivotTables:=False)
            'xlWorkSheet.Range("C4").Select()
            '.ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            .Visible = True
        End With
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