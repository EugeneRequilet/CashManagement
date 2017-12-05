Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class PrintDailyEmployeeShiftForm

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet1 As Excel.Worksheet
    Dim xlWorkSheet2 As Excel.Worksheet
    Dim xlWorkSheet3 As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Employee Shift " & Today.ToString("yyyy-MM-dd") & " From " & Today.ToString("yyyy-MM-dd")
    Dim XLExtention As String = ".xlsx"

    Dim DSHVDC As DailyShiftHeaderViewDataContext
    Dim DailyShiftHeaderViewRow As DailyShiftHeaderView
    Dim DEVDC As DailyEmployeeShiftViewDataContext
    Dim DailyEmployeeShiftViewRow As DailyEmployeeShiftView
    Dim EDC As EmployeeDataContext
    Dim EmployeeRow As Employee
    Dim CVDC As CashUpViewDataContext
    Dim CashupViewRow As CashupView
    Dim LTVDC As LeaveTakenViewDataContext
    Dim LeaveTakenViewRow As LeaveTakenView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Dim LastColumnString As String = ""
    Dim Variance As Decimal = 0.0
    Dim LeaveDaysTaken As Integer = 0
    Dim SickLeaveDaysTaken As Integer = 0
    Dim UnpaidLeaveDaysTaken As Integer = 0


    Private Sub PrintEmployeeShiftForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setDropdowns()

        ' Set for this months wages from 26 of last month to 25 of this month

        txtDateFrom.Text = (DateSerial(Year(Today), Month(Today) - 1, 26)).ToString
        txtDateTo.Text = (DateSerial(Year(Today), Month(Today), 25)).ToString
        'If txtDateFrom.Value > txtDateTo.Value Then
        '    txtDateFrom.Text = (DateSerial(Year(Today) - 1, Month(Today) - 1, 26)).ToString
        'End If

        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
    End Sub

    Private Sub setDropdowns()
        Dim CurrentRecordId As Integer
        Dim SelectedIndex As Integer = 1
        Dim SQLString As String = "Select * From Employee Where InactiveEmployee = 0 Order By Description"
        cboEmployee.Items.Clear()
        cboEmployee.Items.Add("All")
        Try
            Dim SQL = SQLString
            EDC = New EmployeeDataContext
            EmployeeBindingSource.DataSource = EDC.ExecuteQuery(Of Employee)(SQL)
        Catch ex As Exception
            MessageBox.Show("Employee Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        EmployeeBindingSource.MoveFirst()
        Do
            Try
                EmployeeRow = EmployeeBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If EmployeeRow IsNot Nothing Then
                If CurrentRecordId = EmployeeRow.RecordId Then Exit Do
                CurrentRecordId = EmployeeRow.RecordId
                cboEmployee.Items.Add(EmployeeRow.Description)
                SelectedIndex += 1
            End If
            EmployeeBindingSource.MoveNext()
        Loop
        cboEmployee.SelectedIndex = 0

        cboDateRange.Items.Clear()
        cboDateRange.Items.Add("As Is")

        If GlobalEmployeeLeave = 0 Then
            cboDateRange.Items.Add(Format(DateSerial(Year(Today), Month(Today), 1), "MMMM yyyy"))
            cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 1), 1), "MMMM yyyy"))
            cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 2), 1), "MMMM yyyy"))
            cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 3), 1), "MMMM yyyy"))
            cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 4), 1), "MMMM yyyy"))
            cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 5), 1), "MMMM yyyy"))
        Else
            cboDateRange.Items.Add("This Year to Date")
            cboDateRange.Items.Add("This Year")
            cboDateRange.Items.Add("Last Year")
        End If
        cboDateRange.SelectedIndex = 0
        setDatesFromDropdown()
    End Sub

    Private Sub setDatesFromDropdown()
        If GlobalEmployeeLeave = 0 Then
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
        Else
            Select Case cboDateRange.SelectedIndex
                Case 0
                    txtDateFrom.Text = (GlobalDateFrom).ToString
                    txtDateTo.Text = (GlobalDateTo).ToString
                Case 1
                    If Today.Month <= 12 Then
                        txtDateFrom.Text = (DateSerial(Year(Today), 3, 1)).ToString
                        txtDateTo.Text = Today.ToString
                    Else
                        txtDateFrom.Text = (DateSerial((Year(Today) - 1), 3, 1)).ToString
                        txtDateTo.Text = Today.ToString
                    End If
                Case 2
                    If Today.Month <= 12 Then
                        txtDateFrom.Text = (DateSerial(Year(Today), 3, 1)).ToString
                        txtDateTo.Text = (DateSerial((Year(Today) + 1), 3, 0)).ToString
                    Else
                        txtDateFrom.Text = (DateSerial((Year(Today) - 1), 3, 1)).ToString
                        txtDateTo.Text = (DateSerial(Year(Today), 3, 0)).ToString
                    End If
                Case 3
                    If Today.Month <= 12 Then
                        txtDateFrom.Text = (DateSerial((Year(Today) - 1), 3, 1)).ToString
                        txtDateTo.Text = (DateSerial(Year(Today), 3, 0)).ToString
                    Else
                        txtDateFrom.Text = (DateSerial((Year(Today) - 2), 3, 1)).ToString
                        txtDateTo.Text = (DateSerial((Year(Today) - 1), 3, 0)).ToString
                    End If
            End Select
        End If
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
        If GlobalEmployeeLeave = 0 Then
            XLFileName = "Employee Wages " & Format(txtDateTo.Value, "yyyy-MM-dd") & " From " & Format(txtDateFrom.Value, "yyyy-MM-dd")
        Else
            XLFileName = "Employee Leave " & Format(txtDateTo.Value, "yyyy-MM-dd") & " From " & Format(txtDateFrom.Value, "yyyy-MM-dd")
        End If
        CreateExcelWorkbook()
        WriteExcelBasicHeader()
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

    Private Sub WriteExcelBasicHeader()
        'Add data to cells of the first worksheet in the new workbook

        'xlWorkSheet1 = xlWorkBook.Sheets("Sheet1")
        'xlWorkSheet2 = xlWorkBook.Sheets("Sheet2")
        'xlWorkSheet3 = xlWorkBook.Sheets("Sheet3")
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
        xlWorkBook.Sheets("Sheet1").Name = "Hours"
        xlWorkBook.Sheets("Sheet2").Name = "Wages"
        xlWorkBook.Sheets("Sheet3").Name = "Leave"

        With xlWorkSheet1
            .Range("A1:BZ500").Font.Name = "Calibri"
            .Range("A1:BZ500").Font.Bold = False
            .Range("A1:BZ500").Font.Size = 11

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            If cboEmployee.SelectedIndex = 0 Then
                .Range("A2").Value = "Employee Hours Worked For All Employees"
            Else
                .Range("A2").Value = "Employee Hours Worked For " & cboEmployee.SelectedItem.ToString()
            End If
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Employee Hours Worked From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 16

            .Range("A6").Value = "Day"
            .Range("B6").Value = "Date"
            .Range("C6").Value = "Shifts"

            .Range("A5:C6").Font.Bold = True
            .Range("A5:C6").Font.Size = 9
            .Range("A5:C6").WrapText = True
            .Range("A5:C6").HorizontalAlignment = Excel.Constants.xlCenter
            .Range("A5:C6").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 6
            .Range("B5").ColumnWidth = 11
            .Range("C5").ColumnWidth = 6

        End With

        With xlWorkSheet2
            .Range("A1:Z500").Font.Name = "Calibri"
            .Range("A1:Z500").Font.Bold = False
            .Range("A1:Z500").Font.Size = 11


            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            If cboEmployee.SelectedIndex = 0 Then
                .Range("A2").Value = "Employee Wages For All Employees"
            Else
                .Range("A2").Value = "Employee Wages For " & cboEmployee.SelectedItem.ToString()
            End If
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Employee Wages From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 16

            .Range("A5").Value = "Name"
            .Range("B5").Value = "Normal Hours"
            .Range("C5").Value = "Time And a Half"
            .Range("D5").Value = "Double Time"
            .Range("E5").Value = "Leave Hours"
            .Range("F5").Value = "Sick Hours"
            .Range("G5").Value = "Hourly Rate"
            .Range("H5").Value = "Normal Amt"
            .Range("I5").Value = "1.5 Amt"
            .Range("J5").Value = "Double Amt"
            .Range("K5").Value = "Leave Amt"
            .Range("L5").Value = "Sick Leave Amt"
            .Range("M5").Value = "Total"
            .Range("O5").Value = "Shortages Deducted from Salary"
            .Range("P5").Value = "Salary Paid"

            .Range("A5:Y5").Font.Bold = True
            .Range("A5:Y5").Font.Size = 9
            .Range("A5:Y5").WrapText = True
            .Range("A5:Y5").HorizontalAlignment = Excel.Constants.xlCenter

            .Range("A5:M5").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("O5:P5").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 30
            .Range("B5:G5").ColumnWidth = 9
            .Range("H5:M5").ColumnWidth = 11
            .Range("N5").ColumnWidth = 3
            .Range("O5:P5").ColumnWidth = 11

        End With

        With xlWorkSheet3
            .Range("A1:Z500").Font.Name = "Calibri"
            .Range("A1:Z500").Font.Bold = False
            .Range("A1:Z500").Font.Size = 11


            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            If cboEmployee.SelectedIndex = 0 Then
                .Range("A2").Value = "Employee Leave For All Employees"
            Else
                .Range("A2").Value = "Employee Leave For " & cboEmployee.SelectedItem.ToString()
            End If
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Employee Leave From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 16

            .Range("A5").Value = "Name"
            .Range("B5").Value = "Total Hours Worked"

            .Range("D5").Value = "Hours Leave Due"
            .Range("E5").Value = "Days Leave Calculated"
            .Range("F5").Value = "Leave Days Taken"
            .Range("G5").Value = "Days Leave Due"
            .Range("H5").Value = "Leave Pay Due"

            .Range("J5").Value = "Hours Sick Leave Due"
            .Range("K5").Value = "Sick Days Calculated"
            .Range("L5").Value = "Sick Days Taken"
            .Range("M5").Value = "Sick Days Left"

            .Range("O5").Value = "Unpaid Leave Taken"

            .Range("A5:O5").Font.Bold = True
            .Range("A5:O5").Font.Size = 9
            .Range("A5:O5").WrapText = True
            .Range("A5:O5").HorizontalAlignment = Excel.Constants.xlCenter

            .Range("A5:B5").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("D5:H5").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("J5:M5").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("O5").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 30
            .Range("B5").ColumnWidth = 11
            .Range("C5").ColumnWidth = 3
            .Range("D5:H5").ColumnWidth = 11
            .Range("I5").ColumnWidth = 3
            .Range("J5:M5").ColumnWidth = 11
            .Range("N5").ColumnWidth = 3
            .Range("O5").ColumnWidth = 11
        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        Dim SQL As String
        SQL = "Select * From DailyShiftHeaderView Where Date >= '" &
            DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' and Date <= '" &
            DateTime.Parse(txtDateTo.Text).ToString("dd MMM yyyy") &
            "' Order by Date"
        Try
            DSHVDC = New DailyShiftHeaderViewDataContext
            DailyShiftHeaderViewBindingSource.DataSource = DSHVDC.ExecuteQuery(Of DailyShiftHeaderView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyShiftHeaderView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        SpreadsheetLine = 6

        DailyShiftHeaderViewBindingSource.MoveFirst()
        Do
            Try
                DailyShiftHeaderViewRow = DailyShiftHeaderViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If DailyShiftHeaderViewRow IsNot Nothing Then
                If CurrentRecordId = DailyShiftHeaderViewRow.RecordId Then Exit Do
                CurrentRecordId = DailyShiftHeaderViewRow.RecordId
                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet1
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = Mid(DailyShiftHeaderViewRow.Date.DayOfWeek.ToString, 1, 3)                            ' Left(SalesRow.Date.DayOfWeek.ToString, 3)
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = Format(DailyShiftHeaderViewRow.Date, "dd MMM yy")
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = DailyShiftHeaderViewRow.Shifts

                    CellString = "A" & LineNoString & ":C" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    .Range(CellString).Interior.Color = Color.Lavender
                    CellString = "A" & LineNoString & ":B" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "C" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlCenter
                    .Range(CellString).NumberFormat = "##0"
                End With
                WriteExcelBodyEmployeeShift()
            End If
            DailyShiftHeaderViewBindingSource.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelBodyEmployeeShift()
        Dim CurrentRecordId As Integer
        Dim SQL As String
        SQL = "Select * From DailyEmployeeShiftView Where Date = '" &
            DateTime.Parse(DailyShiftHeaderViewRow.Date).ToString("dd MMM yyyy") &
            "' And ThisShiftEmployeeRecordId <> 0" &
            " Order by Date, ShiftDescription"

        If cboEmployee.SelectedIndex <> 0 Then
            Dim SearchEmployeeName = cboEmployee.Text.Replace("'", "''")
            SQL = "Select * From DailyEmployeeShiftView Where Date = '" &
                DateTime.Parse(DailyShiftHeaderViewRow.Date).ToString("dd MMM yyyy") &
                "' And EmployeeName = '" & SearchEmployeeName &
                "' And ThisShiftEmployeeRecordId <> 0" &
                " Order by Date, ShiftDescription"
        End If
        Try
            DEVDC = New DailyEmployeeShiftViewDataContext
            DailyEmployeeShiftViewBindingSource.DataSource = DEVDC.ExecuteQuery(Of DailyEmployeeShiftView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyEmployeeShiftView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the EmployeeShiftView file using the EmployeeShiftHeaderView date selected

        DailyEmployeeShiftViewBindingSource.MoveFirst()
        Do
            Try
                DailyEmployeeShiftViewRow = DailyEmployeeShiftViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If DailyEmployeeShiftViewRow IsNot Nothing Then
                If CurrentRecordId = DailyEmployeeShiftViewRow.RecordId Then Exit Do
                CurrentRecordId = DailyEmployeeShiftViewRow.RecordId
                If cboEmployee.SelectedIndex <> 0 And cboEmployee.Text <> DailyEmployeeShiftViewRow.EmployeeName Then Exit Do

                LineNoString = SpreadsheetLine

                SetupColumns()

            End If
            DailyEmployeeShiftViewBindingSource.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub SetupColumns()
        Dim ColumnString As String = ""
        Dim FirstChar As String = ""
        Dim SecondChar As String = "C"
        Dim Array(2) As String

        With xlWorkSheet1
            Do
                For i As Integer = 0 To 2
                    If SecondChar = "Z" Then
                        If FirstChar = "" Then
                            FirstChar = "A"
                        Else
                            FirstChar = Chr(Asc(FirstChar) + 1)
                        End If
                        SecondChar = ""
                    End If
                    If SecondChar = "" Then
                        SecondChar = "A"
                    Else
                        SecondChar = Chr(Asc(SecondChar) + 1)
                    End If
                    Array(i) = Trim(CStr(FirstChar & SecondChar))
                Next

                If .Range(Array(0) & "5").Value = "" Then
                    .Range(Array(0) & "5").Value = DailyEmployeeShiftViewRow.EmployeeName
                    .Range(Array(0) & "6").Value = "1x1"
                    .Range(Array(1) & "6").Value = "1x1.5"
                    .Range(Array(2) & "6").Value = "1x2"
                    LastColumnString = Array(2)
                    ColumnString = Array(0)
                    If DailyShiftHeaderViewRow.DailyRateAdjustmentDescription.ToUpper = "TIME AND A HALF" Then ColumnString = Array(1)
                    If DailyShiftHeaderViewRow.DailyRateAdjustmentDescription.ToUpper = "DOUBLE TIME" Then ColumnString = Array(2)
                    .Range(Array(0) & "5:" & Array(2) & "5").MergeCells = True
                    Exit Do
                End If
                If .Range(Array(0) & "5").Value = DailyEmployeeShiftViewRow.EmployeeName Then
                    ColumnString = Array(0)
                    If DailyShiftHeaderViewRow.DailyRateAdjustmentDescription.ToUpper = "TIME AND A HALF" Then ColumnString = Array(1)
                    If DailyShiftHeaderViewRow.DailyRateAdjustmentDescription.ToUpper = "DOUBLE TIME" Then ColumnString = Array(2)
                    Exit Do
                End If
            Loop

            'If LastColumnString < ColumnString Then LastColumnString = ColumnString
            If ColumnString = "" Then
                MessageBox.Show("ColumnString is blank Error" & vbCrLf & vbCrLf & "This should never happen", "Reporting Error")
            Else
                CellString = ColumnString & LineNoString

                ' Converting Timespan to Decimal

                Dim tempTimeSpan As TimeSpan
                tempTimeSpan = DailyEmployeeShiftViewRow.EmployeeHours                   ' .Range(CellString).Value = DailyEmployeeShiftViewRow.EmployeeHours
                Dim strHours As String = tempTimeSpan.Hours.ToString().PadLeft(2, "0"c)
                Dim strMinutes As String = tempTimeSpan.Minutes.ToString().PadLeft(2, "0"c)
                Dim decHours As Decimal = strHours
                Dim decMinutes As Decimal = strMinutes

                ' START - Check if the person clocked in and out and adjust accordingly.

                With DailyEmployeeShiftViewRow

                    If .ClockStartTime = #1/1/2000 12:00:00 AM# Then decHours -= 1
                    If .ClockEndTime = #1/1/2000 12:00:00 AM# Then decHours -= 1

                    If .ClockStartTime = #1/1/2000 12:00:00 AM# And .ClockEndTime = #1/1/2000 12:00:00 AM# Then
                        decHours = 0
                        decMinutes = 0
                    End If

                End With

                ' END - Check if the person clocked in and out and adjust accordingly.

                decHours += (decMinutes / 60)

                .Range(CellString).Value = (.Range(CellString).Value + decHours)
                .Range(CellString).Interior.Color = Color.Lavender

                ' START - Check if the person clocked in and out and adjust accordingly.

                Dim decHoursEmployeeHours As Decimal = decHours

                tempTimeSpan = DailyEmployeeShiftViewRow.Hours
                strHours = tempTimeSpan.Hours.ToString().PadLeft(2, "0"c)
                strMinutes = tempTimeSpan.Minutes.ToString().PadLeft(2, "0"c)
                decHours = strHours
                decMinutes = strMinutes

                decHours += (decMinutes / 60)
                Dim decHoursHours As Decimal = decHours

                If decHoursEmployeeHours < decHoursHours Then
                    .Range(CellString).Interior.Color = Color.LightPink
                ElseIf decHoursEmployeeHours > decHoursHours Then
                    .Range(CellString).Interior.Color = Color.LightGreen
                End If

                ' END - Check if the person clocked in and out and adjust accordingly.

                'If DailyEmployeeShiftViewRow.EmployeeHours < DailyEmployeeShiftViewRow.Hours Then
                '    .Range(CellString).Interior.Color = Color.LightPink
                'ElseIf DailyEmployeeShiftViewRow.EmployeeHours > DailyEmployeeShiftViewRow.Hours Then
                '    .Range(CellString).Interior.Color = Color.LightGreen
                'End If

            End If
        End With
    End Sub

    Private Sub WriteExcelFooter()
        With xlWorkSheet1

            ' Set up column widths

            If LastColumnString = "" Then LastColumnString = "D"
            CellString = "D5:" & LastColumnString & "5"
            .Range(CellString).ColumnWidth = 7

            ' Set up header formatting

            CellString = "D5:" & LastColumnString & "5"
            .Range(CellString).Font.Bold = True
            .Range(CellString).Font.Size = 9
            .Range(CellString).WrapText = True
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlCenter

            ' Set up body formatting

            If LineNoString Is Nothing Or LineNoString = "" Then LineNoString = "1"
            CellString = "D6:" & LastColumnString & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight

            ' Write the Footer Line

            SpreadsheetLine += 2
            LineNoString = SpreadsheetLine

            With xlWorkSheet1

                CellString = "B" & LineNoString
                .Range(CellString).Value = "Total"

                Dim ColumnString As String = ""
                Dim FirstChar As String = ""
                Dim SecondChar As String = "C"
                Do
                    If SecondChar = "Z" Then
                        If FirstChar = "" Then
                            FirstChar = "A"
                        Else
                            FirstChar = Chr(Asc(FirstChar) + 1)
                        End If
                        SecondChar = ""
                    End If
                    If SecondChar = "" Then
                        SecondChar = "A"
                    Else
                        SecondChar = Chr(Asc(SecondChar) + 1)
                    End If
                    CellString = Trim(CStr(FirstChar & SecondChar))
                    If .Range(CellString & "6").Value = "" Then Exit Do
                    FormulaString = "=SUM(" & CellString & "6:" & CellString & (LineNoString - 1) & ")"
                    .Range(CellString & LineNoString).Formula = FormulaString
                Loop

                CellString = "B" & LineNoString & ":B" & LineNoString
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                CellString = "D" & LineNoString & ":" & LastColumnString & LineNoString
                .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                .Range(CellString).NumberFormat = "##0.00"
                CellString = "A" & LineNoString & ":" & LastColumnString & LineNoString
                .Range(CellString).Font.Bold = True
            End With
        End With

        WriteExcelWagesPage()
        WriteExcelLeavePage()

    End Sub

    Private Sub WriteExcelWagesPage()
        LineNoString = SpreadsheetLine
        Dim LineNumber2 As Integer = 5
        Dim LineNoString2 As String = ""
        Dim HoursCellString As String = "C"

        Do
            HoursCellString = NextSpreadsheetCell(HoursCellString)
            If xlWorkSheet1.Range(HoursCellString & "6").Value = "" Then Exit Do

            LineNumber2 += 1
            LineNoString2 = LineNumber2
            CellString = "A" & LineNoString2
            FormulaString = "=Hours!" & HoursCellString & "5"
            xlWorkSheet2.Range(CellString).Formula = FormulaString

            EmployeeSickAndLeaveDays(xlWorkSheet2.Range(CellString).Value)
            ReadEmployee(xlWorkSheet2.Range(CellString).Value)
            getVarianceFigures(xlWorkSheet2.Range(CellString).Value)

            CellString = "B" & LineNoString2
            FormulaString = "=Hours!" & HoursCellString & LineNoString
            xlWorkSheet2.Range(CellString).Formula = FormulaString

            CellString = "C" & LineNoString2
            HoursCellString = NextSpreadsheetCell(HoursCellString)
            FormulaString = "=Hours!" & HoursCellString & LineNoString
            xlWorkSheet2.Range(CellString).Formula = FormulaString

            CellString = "D" & LineNoString2
            HoursCellString = NextSpreadsheetCell(HoursCellString)
            FormulaString = "=Hours!" & HoursCellString & LineNoString
            xlWorkSheet2.Range(CellString).Formula = FormulaString

            CellString = "E" & LineNoString2
            xlWorkSheet2.Range(CellString).Value = LeaveDaysTaken * GlobalFirmDetailRow.HoursPerShift
            CellString = "F" & LineNoString2
            xlWorkSheet2.Range(CellString).Value = SickLeaveDaysTaken * GlobalFirmDetailRow.HoursPerShift
            CellString = "G" & LineNoString2
            xlWorkSheet2.Range(CellString).Value = EmployeeRow.Rate
            CellString = "H" & LineNoString2
            FormulaString = "=B" & LineNoString2 & "*G" & LineNoString2
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "I" & LineNoString2
            FormulaString = "=C" & LineNoString2 & "*(G" & LineNoString2 & "*1.5)"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "J" & LineNoString2
            FormulaString = "=D" & LineNoString2 & "*(G" & LineNoString2 & "*2)"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "K" & LineNoString2
            FormulaString = "=E" & LineNoString2 & "*G" & LineNoString2
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "L" & LineNoString2
            FormulaString = "=F" & LineNoString2 & "*G" & LineNoString2
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "M" & LineNoString2
            FormulaString = "=SUM(H" & LineNoString2 & ":L" & LineNoString2 & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString

            CellString = "O" & LineNoString2
            xlWorkSheet2.Range(CellString).Value = Variance
            CellString = "P" & LineNoString2
            FormulaString = "=M" & LineNoString2 & "+O" & LineNoString2
            xlWorkSheet2.Range(CellString).Formula = FormulaString
        Loop

        With xlWorkSheet2
            If LineNoString2 Is Nothing Or LineNoString2 = "" Then LineNoString2 = "6"
            CellString = "A6:A" & LineNoString2
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            CellString = "B6:Z" & LineNoString2
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight

            CellString = "A6:M" & LineNoString2
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "O6:P" & LineNoString2
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "B6:F" & LineNoString2
            .Range(CellString).NumberFormat = "#,##0.00"
            CellString = "G6:P" & LineNoString2
            .Range(CellString).NumberFormat = "###,##0.00"
        End With

        With xlWorkSheet2
            CellString = "A6:P" & LineNoString2
            .Range(CellString).Sort(Key1:= .Range(CellString),
                        Order1:=Excel.XlSortOrder.xlAscending,
                        Orientation:=Excel.XlSortOrientation.xlSortColumns)
        End With

        LineNumber2 += 2
        LineNoString2 = LineNumber2

        With xlWorkSheet2
            CellString = "A" & LineNoString2
            xlWorkSheet2.Range(CellString).Value = "Totals"
            CellString = "B" & LineNoString2
            FormulaString = "=SUM(B6:B" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "C" & LineNoString2
            FormulaString = "=SUM(C6:C" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "D" & LineNoString2
            FormulaString = "=SUM(D6:D" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "E" & LineNoString2
            FormulaString = "=SUM(E6:E" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "F" & LineNoString2
            FormulaString = "=SUM(F6:F" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString

            CellString = "H" & LineNoString2
            FormulaString = "=SUM(H6:H" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "I" & LineNoString2
            FormulaString = "=SUM(I6:I" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "J" & LineNoString2
            FormulaString = "=SUM(J6:J" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "K" & LineNoString2
            FormulaString = "=SUM(K6:K" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "L" & LineNoString2
            FormulaString = "=SUM(L6:L" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "M" & LineNoString2
            FormulaString = "=SUM(M6:M" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString

            CellString = "O" & LineNoString2
            FormulaString = "=SUM(O6:O" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString
            CellString = "P" & LineNoString2
            FormulaString = "=SUM(P6:P" & (LineNoString2 - 1) & ")"
            xlWorkSheet2.Range(CellString).Formula = FormulaString

            CellString = "A" & LineNoString2 & ":M" & LineNoString2
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "O" & LineNoString2 & ":P" & LineNoString2
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString2
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            CellString = "B" & LineNoString2 & ":P" & LineNoString2
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            CellString = "B" & LineNoString2 & ":F" & LineNoString2
            .Range(CellString).NumberFormat = "##,##0.00"
            CellString = "G" & LineNoString2 & ":P" & LineNoString2
            .Range(CellString).NumberFormat = "###,##0.00"

            CellString = "A" & LineNoString2 & ":P" & LineNoString2
            .Range(CellString).Font.Bold = True

        End With
    End Sub

    Private Sub WriteExcelLeavePage()
        LineNoString = SpreadsheetLine
        Dim LineNumber3 As Integer = 5
        Dim LineNoString3 As String = ""
        Dim HoursCellString As String = "C"

        Do
            HoursCellString = NextSpreadsheetCell(HoursCellString)
            If xlWorkSheet1.Range(HoursCellString & "6").Value = "" Then Exit Do

            LineNumber3 += 1
            LineNoString3 = LineNumber3
            CellString = "A" & LineNoString3
            ' FormulaString = "=Hours!" & HoursCellString & "5"
            FormulaString = "=Wages!A" & LineNoString3
            xlWorkSheet3.Range(CellString).Formula = FormulaString

            EmployeeSickAndLeaveDays(xlWorkSheet3.Range(CellString).Value)

            CellString = "B" & LineNoString3
            FormulaString = "=SUM(Wages!B" & LineNoString3 & ":D" & LineNoString3 & ")"
            xlWorkSheet3.Range(CellString).Formula = FormulaString

            CellString = "D" & LineNoString3                                                                ' Hours Leave Due
            FormulaString = "=B" & LineNoString3 & "/17"
            xlWorkSheet3.Range(CellString).Formula = FormulaString
            CellString = "E" & LineNoString3                                                                ' Days Leave Calculated
            FormulaString = "=D" & LineNoString3 & "/" & GlobalFirmDetailRow.HoursPerShift
            xlWorkSheet3.Range(CellString).Formula = FormulaString
            CellString = "F" & LineNoString3                                                                ' Leave Days Taken
            'xlWorkSheet3.Range(CellString).Value = EmployeeRow.YTDLeaveDaysTaken
            xlWorkSheet3.Range(CellString).Value = LeaveDaysTaken
            CellString = "G" & LineNoString3                                                                ' Days Leave Due
            FormulaString = "=E" & LineNoString3 & "-" & "F" & LineNoString3
            xlWorkSheet3.Range(CellString).Formula = FormulaString
            CellString = "H" & LineNoString3                                                                ' Leave Pay Due
            FormulaString = "=G" & LineNoString3 & "*Wages!G" & LineNoString3 & "*" & GlobalFirmDetailRow.HoursPerShift
            xlWorkSheet3.Range(CellString).Formula = FormulaString

            CellString = "J" & LineNoString3                                                                ' Hours Sick Leave Due
            FormulaString = "=B" & LineNoString3 & "/24"
            xlWorkSheet3.Range(CellString).Formula = FormulaString
            CellString = "K" & LineNoString3                                                                ' Sick Days Calculated
            FormulaString = "=J" & LineNoString3 & "/" & GlobalFirmDetailRow.HoursPerShift
            xlWorkSheet3.Range(CellString).Formula = FormulaString
            CellString = "L" & LineNoString3                                                                ' Sick Days Taken
            'xlWorkSheet3.Range(CellString).Value = EmployeeRow.YTDSickDaysTaken
            xlWorkSheet3.Range(CellString).Value = SickLeaveDaysTaken
            CellString = "M" & LineNoString3                                                                ' Sick Days Left
            FormulaString = "=K" & LineNoString3 & "-" & "L" & LineNoString3
            xlWorkSheet3.Range(CellString).Formula = FormulaString
            HoursCellString = NextSpreadsheetCell(HoursCellString)
            HoursCellString = NextSpreadsheetCell(HoursCellString)
            CellString = "O" & LineNoString3                                                                ' Sick Days Taken
            xlWorkSheet3.Range(CellString).Value = UnpaidLeaveDaysTaken
        Loop

        With xlWorkSheet3
            If LineNoString3 Is Nothing Or LineNoString3 = "" Then LineNoString3 = "6"
            CellString = "A6:A" & LineNoString3
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            CellString = "B6:Z" & LineNoString3
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight

            CellString = "A6:B" & LineNoString3
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "D6:H" & LineNoString3
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "J6:M" & LineNoString3
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "O6:O" & LineNoString3
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid

            CellString = "B6:G" & LineNoString3
            .Range(CellString).NumberFormat = "#,##0.00"
            CellString = "H6:H" & LineNoString3
            .Range(CellString).NumberFormat = "###,##0.00"
            CellString = "J6:O" & LineNoString3
            .Range(CellString).NumberFormat = "#,##0.00"
        End With

    End Sub

    Private Sub ReadEmployee(EmployeeName As String)
        Try
            EmployeeBindingSource.DataSource = From Employee In (New EmployeeDataContext).Employees Where Employee.Description = EmployeeName
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        EmployeeRow = If(EmployeeBindingSource.Current, New Employee)
    End Sub

    Private Sub getVarianceFigures(EmployeeName As String)
        Dim CurrentRecordId As Integer
        Variance = 0.0
        EmployeeName = EmployeeName.Replace("'", "''")

        Dim SQLString As String = "Select * From CashupView Where Date  >= '" &
            DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' and Date <= '" &
            DateTime.Parse(txtDateTo.Text).ToString("dd MMM yyyy") &
            "' And EmployeeName = '" & EmployeeName & "' And SalesType = 0"
        Try
            Dim SQL = SQLString
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
                If CashupViewRow.Variance < 0 Then
                    Variance += CashupViewRow.Variance
                End If

            End If
            CashupViewBindingSource.MoveNext()
        Loop
    End Sub

    Public Function NextSpreadsheetCell(Letters As String) As String
        Dim FirstChar As String = ""
        Dim SecondChar As String = ""
        If Letters.Length = 0 Then
            FirstChar = ""
            SecondChar = "C"
        ElseIf Letters.Length = 1 Then
            FirstChar = ""
            SecondChar = Letters
        Else
            FirstChar = Letters.Substring(0, 1)
            SecondChar = Letters.Substring(1, 1)
        End If

        If SecondChar = "Z" Then
            If FirstChar = "" Then
                FirstChar = "A"
            Else
                FirstChar = Chr(Asc(FirstChar) + 1)
            End If
            SecondChar = ""
        End If
        If SecondChar = "" Then
            SecondChar = "A"
        Else
            SecondChar = Chr(Asc(SecondChar) + 1)
        End If
        Return Trim(CStr(FirstChar & SecondChar))
    End Function

    Private Sub DisplayExcelWorkbook()
        xlWorkSheetSetup()
        'With xlApp
        '    LineNoString = SpreadsheetLine
        '    'CellString = "I4:J" & LineNoString
        '    'xlWorkSheet1.Range(CellString).Columns.AutoFit()
        '    xlWorkSheet1.Range("D7").Select()
        '    .ActiveWindow.FreezePanes = True
        '    '.ActiveWindow.Zoom = 85 ' open sheet at 85%
        '    .Visible = True
        'End With
        xlWorkSheet3.Activate()
        With xlApp
            xlWorkSheet3.Range("B6").Select()
            .ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 80 ' open sheet at 80%
        End With
        xlWorkSheet2.Activate()
        With xlApp
            xlWorkSheet2.Range("B6").Select()
            .ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 80 ' open sheet at 80%
        End With
        xlWorkSheet1.Activate()
        With xlApp
            xlWorkSheet1.Range("D7").Select()
            .ActiveWindow.FreezePanes = True
            .ActiveWindow.Zoom = 95 ' open sheet at 95%
            .Visible = True
        End With
        If GlobalEmployeeLeave = 0 Then
            ' xlWorkSheet3.Visible = False
        Else
            xlWorkSheet2.Visible = False
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

    Private Sub EmployeeSickAndLeaveDays(EmployeeName As String)
        Dim CurrentRecordId As Integer
        Dim SQLString As String
        EmployeeName = EmployeeName.Replace("'", "''")

        LeaveDaysTaken = 0
        SickLeaveDaysTaken = 0
        UnpaidLeaveDaysTaken = 0

        SQLString = "Select * From LeaveTakenView Where StartDate >= '" & _
            DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' And StartDate <= '" & _
            DateTime.Parse(txtDateTo.Text).ToString("dd MMM yyyy") & _
            "' And ThisLeaveTakenEmployee = '" & EmployeeName & "'"
        Try
            Dim SQL = SQLString
            LTVDC = New LeaveTakenViewDataContext
            LeaveTakenViewBindingSource.DataSource = LTVDC.ExecuteQuery(Of LeaveTakenView)(SQL)
        Catch ex As Exception
            MessageBox.Show("LeaveTakenView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        LeaveTakenViewBindingSource.MoveFirst()
        Do
            Try
                LeaveTakenViewRow = LeaveTakenViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If LeaveTakenViewRow IsNot Nothing Then
                If CurrentRecordId = LeaveTakenViewRow.RecordId Then Exit Do
                CurrentRecordId = LeaveTakenViewRow.RecordId

                ' Every seven days they get one day off

                If LeaveTakenViewRow.Days > 6 Then
                    Dim i As Integer = Int(LeaveTakenViewRow.Days / 7)
                    LeaveTakenViewRow.Days -= i
                End If
                Select Case LeaveTakenViewRow.LeaveType
                    Case "Unpaid"
                        UnpaidLeaveDaysTaken += LeaveTakenViewRow.Days
                    Case "Sick"
                        SickLeaveDaysTaken += LeaveTakenViewRow.Days
                    Case Else
                        LeaveDaysTaken += LeaveTakenViewRow.Days
                End Select
            End If
            LeaveTakenViewBindingSource.MoveNext()
        Loop
    End Sub

End Class