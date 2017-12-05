Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseRecon

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet1 As Excel.Worksheet
    Dim xlWorkSheet2 As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Deposit " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim CURVDC As CashupReconViewDataContext
    Dim CashupReconViewRow As CashupReconView
    Dim BRVDC As BankingViewDataContext
    Dim BankingReconViewRow As BankingView

    Dim Worksheet1Line As Integer
    Dim Worksheet2Line As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String
    Dim ws1Date As Date
    Dim ws1Column(19) As Decimal
    Dim ws2Date As Date
    Dim ws2Column(19) As Decimal

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        GlobalUnreconciled = 0
        GlobalBankType = 0
        setDropdowns()
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
        LoadGrid()
    End Sub

    Private Sub setDropdowns()
        cboBankingType.Items.Clear()
        cboBankingType.Items.Add("All")
        cboBankingType.Items.Add("Cash")
        cboBankingType.Items.Add("Credit Card")
        cboBankingType.SelectedIndex = 0
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub Form_FormClosing(sender As Object, e As FormClosingEventArgs) Handles MyBase.FormClosing
        ' This is because I want to reset these variables when the "X" is pressed as well as the "Exit" button
        GlobalUnreconciled = 0
        GlobalBankType = 0
    End Sub

    Private Sub ReconcileCashupButton_Click(sender As Object, e As EventArgs) Handles ReconcileCashupButton.Click
        CashUpReconGrid1.ChangeRow()
    End Sub

    Private Sub ReconcileBankingButton_Click(sender As Object, e As EventArgs) Handles ReconcileBankingButton.Click
        BankingReconGrid1.ChangeRow()
    End Sub

    Private Sub ckbUnReconciledItems_CheckedChanged(sender As Object, e As EventArgs) Handles ckbDisplayReconciledItems.CheckedChanged
        Select Case ckbDisplayReconciledItems.CheckState
            Case 0
                GlobalUnreconciled = 0
            Case 1
                GlobalUnreconciled = 1
        End Select
        LoadGrid()
    End Sub

    Private Sub cboBankingType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBankingType.SelectedIndexChanged
        Select Case cboBankingType.SelectedIndex
            Case 1 ' Cash
                GlobalBankType = 1
            Case 2 ' Credit Card
                GlobalBankType = 2
            Case Else ' Both
                GlobalBankType = 0
        End Select
        LoadGrid()
    End Sub

    Private Sub LoadGrid()
        CashUpReconGrid1.LoadData()
        BankingReconGrid1.LoadData()
    End Sub

    Private Sub PrintExcelButton_Click(sender As Object, e As EventArgs) Handles PrintExcelButton.Click
        CheckForFileAndContinue()
    End Sub

    Private Sub CheckForFileAndContinue()
        CreateExcelWorkbook()
        WriteExcelHeader()
        WriteExcelBody()
        WriteExcelFooter()
        SortExcelBody()
        DisplayExcelWorkbook()
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
        xlWorkBook.Sheets("Sheet1").Name = "Cash"
        xlWorkBook.Sheets("Sheet2").Name = "Credit Card"

        With xlWorkSheet1
            .Range("A1:AB3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Cash Control Sheet dated: " & Today.ToLongDateString
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 14

            .Range("C4").Value = "Cash-up Skim 1"
            .Range("D4").Value = "Cash-up Skim 2"
            .Range("E4").Value = "Cash-up Skim 3"
            .Range("F4").Value = "Cash-up Skim Total"
            .Range("G4").Value = "Cash-up Cash 1"
            .Range("H4").Value = "Cash-up Cash 2"
            .Range("I4").Value = "Cash-up Cash 3"
            .Range("J4").Value = "Cash-up Cash 4"
            .Range("K4").Value = "Cash-up Cash Total"
            .Range("L4").Value = "Cash-up Cash & Skims"

            .Range("N4").Value = "Bank Cash Total"
            .Range("O4").Value = "Bank Dep 1"
            .Range("P4").Value = "Bank Dep 2"
            .Range("Q4").Value = "Bank Dep 3"
            .Range("R4").Value = "Bank Dep 4"
            .Range("S4").Value = "Bank Dep 5"
            .Range("T4").Value = "Bank Dep 6"
            .Range("U4").Value = "Bank Dep 7"
            .Range("V4").Value = "Bank Dep 8"
            .Range("W4").Value = "Bank Dep 9"
            .Range("X4").Value = "Bank Dep 10"
            .Range("Y4").Value = "Bank Dep 11"
            .Range("Z4").Value = "Bank Dep 12"

            .Range("C4:Z4").Font.Bold = True
            .Range("C4:Z4").Font.Size = 10
            .Range("C4:Z4").WrapText = True
            .Range("C4:Z4").HorizontalAlignment = Excel.Constants.xlCenter
            .Range("C4:L4").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("N4:Z4").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A4").ColumnWidth = 5
            .Range("B4").ColumnWidth = 10
            .Range("C4:E4").ColumnWidth = 10
            .Range("F4").ColumnWidth = 12
            .Range("G4:J4").ColumnWidth = 10
            .Range("K4:L4").ColumnWidth = 12
            .Range("M4").ColumnWidth = 2
            .Range("N4").ColumnWidth = 12
            .Range("O4:Z4").ColumnWidth = 10
        End With

        With xlWorkSheet2
            .Range("A1:AB3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Credit Card Control Sheet dated: " & Today.ToLongDateString
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 14

            .Range("C4").Value = "Cash-up C/C 1"
            .Range("D4").Value = "Cash-up C/C 2"
            .Range("E4").Value = "Cash-up C/C 3"
            .Range("F4").Value = "Cash-up C/C 4"
            .Range("G4").Value = "Cash-up C/C Total"

            .Range("I4").Value = "Bank C/C Total"
            .Range("J4").Value = "Bank C/C 1"
            .Range("K4").Value = "Bank C/C 2"
            .Range("L4").Value = "Bank C/C 3"
            .Range("M4").Value = "Bank C/C 4"
            .Range("N4").Value = "Bank C/C 5"
            .Range("O4").Value = "Bank C/C 6"
            .Range("P4").Value = "Bank C/C 7"
            .Range("Q4").Value = "Bank C/C 8"
            .Range("R4").Value = "Bank C/C 9"
            .Range("S4").Value = "Bank C/C 10"
            .Range("T4").Value = "Bank C/C 11"
            .Range("U4").Value = "Bank C/C 12"

            .Range("C4:U4").Font.Bold = True
            .Range("C4:U4").Font.Size = 10
            .Range("C4:U4").WrapText = True
            .Range("C4:U4").HorizontalAlignment = Excel.Constants.xlCenter
            .Range("C4:G4").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("I4:U4").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A4").ColumnWidth = 5
            .Range("B4").ColumnWidth = 10
            .Range("C4:F4").ColumnWidth = 8
            .Range("G4").ColumnWidth = 10
            .Range("H4").ColumnWidth = 2
            .Range("I4").ColumnWidth = 10
            .Range("J4:U4").ColumnWidth = 8
        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        Worksheet1Line = 4
        Worksheet2Line = 4
        With xlWorkSheet1
            .Range("A5:Z500").Font.Bold = False
            .Range("A5:Z500").Font.Size = 11
        End With

        With xlWorkSheet2
            .Range("A5:Z500").Font.Bold = False
            .Range("A5:Z500").Font.Size = 11
        End With

        Dim SQL = "Select * From CashUpReconView where CreditCardReconciled = 0 or CashDepReconciled = 0 or Skims1Reconciled = 0 or Skims2Reconciled = 0 or Skims3Reconciled = 0 Order by Date"
        'If GlobalUnreconciled = 1 Then SQL = "Select * From CashUpReconView Order by Date"
        Try
            CURVDC = New CashupReconViewDataContext
            CashupReconViewBindingSource.DataSource = CURVDC.ExecuteQuery(Of CashupReconView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupReconView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        CashupReconViewBindingSource.MoveFirst()
        Do
            Try
                CashupReconViewRow = CashupReconViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If CashupReconViewRow IsNot Nothing Then
                If CurrentRecordId = CashupReconViewRow.RecordId Then Exit Do
                CurrentRecordId = CashupReconViewRow.RecordId

                With CashupReconViewRow
                    ws1Date = .Date
                    'ws2Column.Clear()
                    For i = 1 To 19
                        ws1Column(i) = 0.0
                    Next
                    If .Skims1Reconciled = 0 Then ws1Column(1) = .DepositedSkim1
                    If .Skims2Reconciled = 0 Then ws1Column(2) = .DepositedSkim2
                    If .Skims3Reconciled = 0 Then ws1Column(3) = .DepositedSkim3
                    If .CashDepReconciled = 0 Then ws1Column(4) = .CashDeposited
                    If ws1Column(1) <> 0.0 Or ws1Column(2) <> 0.0 Or ws1Column(3) <> 0.0 Or ws1Column(4) <> 0.0 Then CashWorksheetLine()

                    ws2Date = .Date
                    'ws2Column.Clear()
                    For i = 1 To 16
                        ws2Column(i) = 0.0
                    Next
                    If .CreditCardReconciled = 0 Then ws2Column(1) = .CreditCardDeposited
                    If ws2Column(1) <> 0.0 Then CreditCardWorksheetLine()
                End With
            End If
            CashupReconViewBindingSource.MoveNext()
        Loop

        SQL = "Select * From BankingView Where Reconciled = 0 Order by Date, BankingTypeDesc, Number"
        'If GlobalUnreconciled = 1 Then SQL = "Select * From BankingView Order by Date, BankingTypeDesc, Number"
        Try
            BRVDC = New BankingViewDataContext
            BankingViewBindingSource.DataSource = BRVDC.ExecuteQuery(Of BankingView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupReconView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        BankingViewBindingSource.MoveFirst()
        Do
            Try
                BankingReconViewRow = BankingViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If BankingReconViewRow IsNot Nothing Then
                If CurrentRecordId = BankingReconViewRow.RecordId Then Exit Do
                CurrentRecordId = BankingReconViewRow.RecordId

                With BankingReconViewRow
                    If .BankingTypeDesc = "Credit Card" Then
                        'ws2Column.Clear()
                        For i = 1 To 16
                            ws2Column(i) = 0.0
                        Next
                        ws2Date = .Date
                        ws2Column(5) = .Amount
                        CreditCardWorksheetLine()
                    Else
                        'ws2Column.Clear()
                        For i = 1 To 16
                            ws1Column(i) = 0.0
                        Next
                        ws1Date = .Date
                        ws1Column(8) = .Amount
                        CashWorksheetLine()
                    End If
                End With
            End If
            BankingViewBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub CashWorksheetLine()

        Dim LoopLine As Integer
        Dim DateExists As Boolean = False

        For LoopLine = 5 To 100
            LineNoString = LoopLine
            CellString = "B" & LineNoString
            With xlWorkSheet1
                'If .Range(CellString).Value = "" Or .Range(CellString).Value = 0.0 Then Exit For
                If .Range(CellString).Value Is Nothing Then Exit For
                If .Range(CellString).Value = Format(ws1Date, "dd MMM yy") Then
                    DateExists = True
                    Exit For
                End If
            End With
        Next
        If DateExists = False Then
            Worksheet1Line += 1
            LineNoString = Worksheet1Line

            With xlWorkSheet1
                CellString = "A" & LineNoString
                .Range(CellString).Value = Mid(ws1Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                CellString = "B" & LineNoString
                .Range(CellString).Value = Format(ws1Date, "dd MMM yy")
                CellString = "C" & LineNoString
                .Range(CellString).Value = ws1Column(1)
                CellString = "D" & LineNoString
                .Range(CellString).Value = ws1Column(2)
                CellString = "E" & LineNoString
                .Range(CellString).Value = ws1Column(3)
                CellString = "F" & LineNoString
                FormulaString = "=SUM(C" & LineNoString & ":E" & LineNoString & ")"
                .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:E4)"
                .Range(CellString).Interior.Color = Color.LightBlue

                CellString = "G" & LineNoString
                .Range(CellString).Value = ws1Column(4)
                CellString = "H" & LineNoString
                .Range(CellString).Value = ws1Column(5)
                CellString = "I" & LineNoString
                .Range(CellString).Value = ws1Column(6)
                CellString = "J" & LineNoString
                .Range(CellString).Value = ws1Column(7)
                CellString = "K" & LineNoString
                FormulaString = "=SUM(G" & LineNoString & ":J" & LineNoString & ")"
                .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:J4)"
                .Range(CellString).Interior.Color = Color.LightBlue
                CellString = "L" & LineNoString
                FormulaString = "=K" & LineNoString & "+F" & LineNoString
                .Range(CellString).Formula = FormulaString                                                        ' "=K4+F4"
                .Range(CellString).Interior.Color = Color.Bisque

                CellString = "N" & LineNoString
                FormulaString = "=SUM(O" & LineNoString & ":Z" & LineNoString & ")"
                .Range(CellString).Interior.Color = Color.Bisque
                .Range(CellString).Formula = FormulaString                                                        ' "=SUM(O4:Z4)"
                CellString = "O" & LineNoString
                .Range(CellString).Value = ws1Column(8)
                CellString = "P" & LineNoString
                .Range(CellString).Value = ws1Column(9)
                CellString = "Q" & LineNoString
                .Range(CellString).Value = ws1Column(10)
                CellString = "R" & LineNoString
                .Range(CellString).Value = ws1Column(11)
                CellString = "S" & LineNoString
                .Range(CellString).Value = ws1Column(12)
                CellString = "T" & LineNoString
                .Range(CellString).Value = ws1Column(13)
                CellString = "U" & LineNoString
                .Range(CellString).Value = ws1Column(14)
                CellString = "V" & LineNoString
                .Range(CellString).Value = ws1Column(15)
                CellString = "W" & LineNoString
                .Range(CellString).Value = ws1Column(16)
                CellString = "X" & LineNoString
                .Range(CellString).Value = ws1Column(17)
                CellString = "Y" & LineNoString
                .Range(CellString).Value = ws1Column(18)
                CellString = "Z" & LineNoString
                .Range(CellString).Value = ws1Column(19)

                CellString = "A" & LineNoString & ":Z" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "A" & LineNoString & ":L" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "N" & LineNoString & ":Z" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "C" & LineNoString & ":Z" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With
        Else
            ' LineNoString = LoopLine
            With xlWorkSheet1
                CellString = "C" & LineNoString
                .Range(CellString).Value = .Range(CellString).Value + ws1Column(1)
                CellString = "D" & LineNoString
                .Range(CellString).Value = .Range(CellString).Value + ws1Column(2)
                CellString = "E" & LineNoString
                .Range(CellString).Value = .Range(CellString).Value + ws1Column(3)

                CellString = "G" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(4)
                Else
                    ws1Column(5) = ws1Column(4)
                    ws1Column(4) = 0.0
                End If
                CellString = "H" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(5)
                Else
                    ws1Column(6) = ws1Column(5)
                    ws1Column(5) = 0.0
                End If
                CellString = "I" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(6)
                Else
                    ws1Column(7) = ws1Column(6)
                    ws1Column(6) = 0.0
                End If
                CellString = "J" & LineNoString
                .Range(CellString).Value = .Range(CellString).Value + ws1Column(7)

                CellString = "O" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(8)
                Else
                    ws1Column(9) = ws1Column(8)
                    ws1Column(8) = 0.0
                End If
                CellString = "P" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(9)
                Else
                    ws1Column(10) = ws1Column(9)
                    ws1Column(9) = 0.0
                End If
                CellString = "Q" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(10)
                Else
                    ws1Column(11) = ws1Column(10)
                    ws1Column(10) = 0.0
                End If
                CellString = "R" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(11)
                Else
                    ws1Column(12) = ws1Column(11)
                    ws1Column(11) = 0.0
                End If
                CellString = "S" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(12)
                Else
                    ws1Column(13) = ws1Column(12)
                    ws1Column(12) = 0.0
                End If
                CellString = "T" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(13)
                Else
                    ws1Column(14) = ws1Column(13)
                    ws1Column(13) = 0.0
                End If
                CellString = "U" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(14)
                Else
                    ws1Column(15) = ws1Column(14)
                    ws1Column(14) = 0.0
                End If
                CellString = "V" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(15)
                Else
                    ws1Column(16) = ws1Column(15)
                    ws1Column(15) = 0.0
                End If
                CellString = "W" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(16)
                Else
                    ws1Column(17) = ws1Column(16)
                    ws1Column(16) = 0.0
                End If
                CellString = "X" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(17)
                Else
                    ws1Column(18) = ws1Column(17)
                    ws1Column(17) = 0.0
                End If
                CellString = "Y" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws1Column(18)
                Else
                    ws1Column(19) = ws1Column(18)
                    ws1Column(18) = 0.0
                End If
                CellString = "Z" & LineNoString
                .Range(CellString).Value = .Range(CellString).Value + ws1Column(19)
            End With
        End If

        'If Worksheet1Line > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
    End Sub

    Private Sub CreditCardWorksheetLine()
        Dim LoopLine As Integer
        Dim DateExists As Boolean = False

        For LoopLine = 5 To 100
            LineNoString = LoopLine
            CellString = "B" & LineNoString
            With xlWorkSheet2
                If .Range(CellString).Value Is Nothing Then Exit For
                If .Range(CellString).Value = Format(ws2Date, "dd MMM yy") Then
                    DateExists = True
                    Exit For
                End If
            End With
        Next
        If DateExists = False Then
            Worksheet2Line += 1
            LineNoString = Worksheet2Line

            With xlWorkSheet2
                CellString = "A" & LineNoString
                .Range(CellString).Value = Mid(ws2Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                CellString = "B" & LineNoString
                .Range(CellString).Value = Format(ws2Date, "dd MMM yy")
                CellString = "C" & LineNoString
                .Range(CellString).Value = ws2Column(1)
                CellString = "D" & LineNoString
                .Range(CellString).Value = ws2Column(2)
                CellString = "E" & LineNoString
                .Range(CellString).Value = ws2Column(3)
                CellString = "F" & LineNoString
                .Range(CellString).Value = ws2Column(4)
                CellString = "G" & LineNoString
                FormulaString = "=SUM(C" & LineNoString & ":F" & LineNoString & ")"
                .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:F4)"
                .Range(CellString).Interior.Color = Color.Bisque

                CellString = "I" & LineNoString
                FormulaString = "=SUM(J" & LineNoString & ":U" & LineNoString & ")"
                .Range(CellString).Formula = FormulaString                                                        ' "=SUM(J4:U4)"
                .Range(CellString).Interior.Color = Color.Bisque
                CellString = "J" & LineNoString
                .Range(CellString).Value = ws2Column(5)
                CellString = "K" & LineNoString
                .Range(CellString).Value = ws2Column(6)
                CellString = "L" & LineNoString
                .Range(CellString).Value = ws2Column(7)
                CellString = "M" & LineNoString
                .Range(CellString).Value = ws2Column(8)
                CellString = "N" & LineNoString
                .Range(CellString).Value = ws2Column(9)
                CellString = "O" & LineNoString
                .Range(CellString).Value = ws2Column(10)
                CellString = "P" & LineNoString
                .Range(CellString).Value = ws2Column(11)
                CellString = "Q" & LineNoString
                .Range(CellString).Value = ws2Column(12)
                CellString = "R" & LineNoString
                .Range(CellString).Value = ws2Column(13)
                CellString = "S" & LineNoString
                .Range(CellString).Value = ws2Column(14)
                CellString = "T" & LineNoString
                .Range(CellString).Value = ws2Column(15)
                CellString = "U" & LineNoString
                .Range(CellString).Value = ws2Column(16)

                CellString = "A" & LineNoString & ":U" & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                CellString = "A" & LineNoString & ":G" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "I" & LineNoString & ":U" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "C" & LineNoString & ":U" & LineNoString
                .Range(CellString).NumberFormat = "#,###,##0.00"
            End With
        Else
            ' LineNoString = LoopLine
            With xlWorkSheet2
                CellString = "C" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(1)
                Else
                    ws2Column(2) = ws2Column(1)
                    ws2Column(1) = 0.0
                End If
                CellString = "D" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(2)
                Else
                    ws2Column(3) = ws2Column(2)
                    ws2Column(2) = 0.0
                End If
                CellString = "E" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(3)
                Else
                    ws2Column(4) = ws2Column(3)
                    ws2Column(3) = 0.0
                End If
                CellString = "F" & LineNoString
                .Range(CellString).Value = .Range(CellString).Value + ws2Column(4)

                CellString = "J" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(5)
                Else
                    ws2Column(6) = ws2Column(5)
                    ws2Column(5) = 0.0
                End If
                CellString = "K" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(6)
                Else
                    ws2Column(7) = ws2Column(6)
                    ws2Column(6) = 0.0
                End If
                CellString = "L" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(7)
                Else
                    ws2Column(8) = ws2Column(7)
                    ws2Column(7) = 0.0
                End If
                CellString = "M" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(8)
                Else
                    ws2Column(9) = ws2Column(8)
                    ws2Column(8) = 0.0
                End If
                CellString = "N" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(9)
                Else
                    ws2Column(10) = ws2Column(9)
                    ws2Column(9) = 0.0
                End If
                CellString = "O" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(10)
                Else
                    ws2Column(11) = ws2Column(10)
                    ws2Column(10) = 0.0
                End If
                CellString = "P" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(11)
                Else
                    ws2Column(12) = ws2Column(11)
                    ws2Column(11) = 0.0
                End If
                CellString = "Q" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(12)
                Else
                    ws2Column(13) = ws2Column(12)
                    ws2Column(12) = 0.0
                End If
                CellString = "R" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(13)
                Else
                    ws2Column(14) = ws2Column(13)
                    ws2Column(13) = 0.0
                End If
                CellString = "S" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(14)
                Else
                    ws2Column(15) = ws2Column(14)
                    ws2Column(14) = 0.0
                End If
                CellString = "T" & LineNoString
                If .Range(CellString).Value = 0.0 Then
                    .Range(CellString).Value = ws2Column(15)
                Else
                    ws2Column(16) = ws2Column(15)
                    ws2Column(15) = 0.0
                End If
                CellString = "U" & LineNoString
                .Range(CellString).Value = .Range(CellString).Value + ws2Column(16)
            End With
        End If

        'If Worksheet2Line > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out

    End Sub

    Private Sub SortExcelBody()
        Dim BodyString As String
        Dim SortString As String

        With xlWorkSheet1
            BodyString = "A5:Z" & Worksheet1Line
            SortString = "B5"
            .Range(BodyString).Sort(Key1:=.Range(SortString), Order1:=Excel.XlSortOrder.xlAscending, Header:=Excel.XlYesNoGuess.xlNo, _
            OrderCustom:=1, MatchCase:=False, Orientation:=Excel.XlSortOrientation.xlSortColumns, DataOption1:=Excel.XlSortDataOption.xlSortNormal)
        End With

        With xlWorkSheet2
            BodyString = "A5:U" & Worksheet2Line
            SortString = "B5"
            .Range(BodyString).Sort(Key1:=.Range(SortString), Order1:=Excel.XlSortOrder.xlAscending, Header:=Excel.XlYesNoGuess.xlNo, _
            OrderCustom:=1, MatchCase:=False, Orientation:=Excel.XlSortOrientation.xlSortColumns, DataOption1:=Excel.XlSortDataOption.xlSortNormal)
        End With
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        Worksheet1Line += 1
        LineNoString = Worksheet1Line

        With xlWorkSheet1
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            CellString = "D" & LineNoString
            FormulaString = "=SUM(D4:D" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            CellString = "E" & LineNoString
            FormulaString = "=SUM(E4:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(E4:E34)"
            CellString = "F" & LineNoString
            FormulaString = "=SUM(F4:F" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "G" & LineNoString
            FormulaString = "=SUM(G4:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"
            CellString = "H" & LineNoString
            FormulaString = "=SUM(H4:H" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(H4:H34)"
            CellString = "I" & LineNoString
            FormulaString = "=SUM(I4:I" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(I4:I34)"
            CellString = "J" & LineNoString
            FormulaString = "=SUM(J4:J" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(J4:J34)"
            CellString = "K" & LineNoString
            FormulaString = "=SUM(K4:K" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(K4:K34)"
            CellString = "L" & LineNoString
            FormulaString = "=SUM(L4:L" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(L4:L34)"

            CellString = "N" & LineNoString
            FormulaString = "=SUM(N4:N" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(N4:N34)"
            CellString = "O" & LineNoString
            FormulaString = "=SUM(O4:O" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(O4:O34)"
            CellString = "P" & LineNoString
            FormulaString = "=SUM(P4:P" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(P4:P34)"
            CellString = "Q" & LineNoString
            FormulaString = "=SUM(Q4:Q" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(Q4:Q34)"
            CellString = "R" & LineNoString
            FormulaString = "=SUM(R4:R" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(R4:R34)"
            CellString = "S" & LineNoString
            FormulaString = "=SUM(S4:S" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(S4:S34)"
            CellString = "T" & LineNoString
            FormulaString = "=SUM(T4:T" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(T4:T34)"
            CellString = "U" & LineNoString
            FormulaString = "=SUM(U4:U" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(U4:U34)"
            CellString = "V" & LineNoString
            FormulaString = "=SUM(V4:V" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(V4:V34)"
            CellString = "W" & LineNoString
            FormulaString = "=SUM(W4:W" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(W4:W34)"
            CellString = "X" & LineNoString
            FormulaString = "=SUM(X4:X" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(X4:X34)"
            CellString = "Y" & LineNoString
            FormulaString = "=SUM(Y4:Y" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(Y4:Y34)"
            CellString = "Z" & LineNoString
            FormulaString = "=SUM(Z4:Z" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(Z4:Z34)"

            CellString = "C" & LineNoString & ":Z" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Font.Bold = True
            CellString = "C" & LineNoString & ":L" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "N" & LineNoString & ":Z" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            'Write the Footer Second Line TOTALS SUBTRACTED

            CellString = "K" & (LineNoString + 2)
            FormulaString = "=SUM(K" & LineNoString & "-N" & LineNoString & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Font.Bold = True
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "N" & (LineNoString + 2)
            .Range(CellString).Value = "Difference"
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            .Range(CellString).Font.Bold = True
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            ' Hide rows that have a total of zero

            CellString = "C" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "D" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "E" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "F" & LineNoString
            If .Range(CellString).Value = 0.0 Then
                .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
                .Columns("L").EntireColumn.Hidden = True
            End If
            CellString = "G" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "H" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "I" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "J" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True

            CellString = "O" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "P" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "Q" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "R" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "S" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "T" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "U" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "V" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "W" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "X" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "Y" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "Z" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
        End With

        Worksheet2Line += 1
        LineNoString = Worksheet2Line

        With xlWorkSheet2
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C4:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            CellString = "D" & LineNoString
            FormulaString = "=SUM(D4:D" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D4:D34)"
            CellString = "E" & LineNoString
            FormulaString = "=SUM(E4:E" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(E4:E34)"
            CellString = "F" & LineNoString
            FormulaString = "=SUM(F4:F" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(F4:F34)"
            CellString = "G" & LineNoString
            FormulaString = "=SUM(G4:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(G4:G34)"

            CellString = "I" & LineNoString
            FormulaString = "=SUM(I4:I" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(I4:I34)"
            CellString = "J" & LineNoString
            FormulaString = "=SUM(J4:J" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(J4:J34)"
            CellString = "K" & LineNoString
            FormulaString = "=SUM(K4:K" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(K4:K34)"
            CellString = "L" & LineNoString
            FormulaString = "=SUM(L4:L" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(L4:L34)"
            CellString = "M" & LineNoString
            FormulaString = "=SUM(M4:M" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(M4:M34)"
            CellString = "N" & LineNoString
            FormulaString = "=SUM(N4:N" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(N4:N34)"
            CellString = "O" & LineNoString
            FormulaString = "=SUM(O4:O" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(O4:O34)"
            CellString = "P" & LineNoString
            FormulaString = "=SUM(P4:P" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(P4:P34)"
            CellString = "Q" & LineNoString
            FormulaString = "=SUM(Q4:Q" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(Q4:Q34)"
            CellString = "R" & LineNoString
            FormulaString = "=SUM(R4:R" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(R4:R34)"
            CellString = "S" & LineNoString
            FormulaString = "=SUM(S4:S" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(S4:S34)"
            CellString = "T" & LineNoString
            FormulaString = "=SUM(T4:T" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(T4:T34)"
            CellString = "U" & LineNoString
            FormulaString = "=SUM(U4:U" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(U4:U34)"

            CellString = "C" & LineNoString & ":U" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Font.Bold = True
            CellString = "C" & LineNoString & ":G" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString & ":U" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            'Write the Footer Second Line TOTALS SUBTRACTED

            CellString = "G" & (LineNoString + 2)
            FormulaString = "=SUM(G" & LineNoString & "-I" & LineNoString & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(C4:C34)"
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Font.Bold = True
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "I" & (LineNoString + 2)
            .Range(CellString).Value = "Difference"
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            .Range(CellString).Font.Bold = True
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            ' Hide rows that have a total of zero

            CellString = "C" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "D" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "E" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "F" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True

            CellString = "J" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "K" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "L" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "M" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "N" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "O" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "P" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "Q" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "R" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "S" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "T" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
            CellString = "U" & LineNoString
            If .Range(CellString).Value = 0.0 Then .Columns(Mid(CellString, 1, 1)).EntireColumn.Hidden = True
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        xlWorkSheet2.Activate()
        With xlApp
            xlWorkSheet2.Range("C5").Select()
            .ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 80 ' open sheet at 80%
            'xlWorkSheet2.Range("N3").ColumnWidth = 0
        End With
        xlWorkSheet1.Activate()
        With xlApp
            xlWorkSheet1.Range("C5").Select()
            .ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            .Visible = True
        End With
        'If cboSupplier.SelectedIndex <> 0 Then xlWorkSheet.Range("J5").ColumnWidth = 0
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

End Class