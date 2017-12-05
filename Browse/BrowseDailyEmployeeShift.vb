Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseDailyEmployeeShift

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Shifts " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Dim DESVDC As DailyEmployeeShiftViewDataContext
    Dim DailyEmployeeShiftViewRow As DailyEmployeeShiftView

    Private Sub BrowseDailyEmployeeShift_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalEmployeeClocking = 0 Then
            GlobalDateFrom = (DateSerial(Year(Today), Month(Today) - 1, 26))
            GlobalDateTo = (DateSerial(Year(Today), Month(Today), 25))
        Else
            GlobalDateFrom = Today()
            GlobalDateTo = Today()
        End If
        DisplayGlobalFromToDates()
        If GlobalEmployeeIsType < GlobalCashier Then
            DateButton.Enabled = False
        Else
            DateButton.Enabled = True
        End If
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            DailyEmployeeShiftGrid1.DeleteRow()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        DailyEmployeeShiftGrid1.ChangeRow()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateDailyEmployeeShiftForm(-1)
            frm.ShowDialog()
            DailyEmployeeShiftGrid1.LoadData()
        End Using
    End Sub

    Private Sub SelectButton_Click(sender As Object, e As EventArgs)
        DailyEmployeeShiftGrid1.SelectRow()
        Me.Close()
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
        DailyEmployeeShiftGrid1.LoadData()
    End Sub

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        ProcessSpreadSheet()
    End Sub

    Private Sub ProcessSpreadSheet()
        CreateExcelWorkbook()
        WriteExcelHeader()
        WriteExcelBody()
        WriteExcelFooter()
        DisplayExcelWorkbook()
        '        Me.Close()
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

            .Range("A2").Value = "Daily Employee Shifts"
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Report Dated " & Today
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 12

            .Range("A5").Value = "Date"
            .Range("B5").Value = "Shift Description"
            .Range("C5").Value = "Shift Start Time"
            .Range("D5").Value = "Shift End Time"
            .Range("E5").Value = "Hours"

            .Range("G5").Value = "Employee Start Time"
            .Range("H5").Value = "Employee End Time"
            .Range("I5").Value = "Hours"

            .Range("K5").Value = "Clock In Time"
            .Range("L5").Value = "Clock Out Time"
            .Range("M5").Value = "Allocated Employee"

            .Range("A5:M5").Font.Bold = True
            .Range("A5:M5").Font.Size = 10
            .Range("A5:M5").WrapText = True
            .Range("A5:M5").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 12
            .Range("B5").ColumnWidth = 30
            .Range("C5:L5").ColumnWidth = 10
            .Range("F5").ColumnWidth = 3
            .Range("J5").ColumnWidth = 3
            .Range("M5").ColumnWidth = 30
            .Range("A5:E5").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("G5:I5").Borders.LineStyle = Excel.Constants.xlSolid
            .Range("K5:M5").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer

        SpreadsheetLine = 5

        With xlWorkSheet
            .Range("A6:Z5000").Font.Bold = False
            .Range("A6:Z5000").Font.Size = 11
        End With

        Dim SQL = "Select * From DailyEmployeeShiftView Where Date >= '" &
                        DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" &
                        DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") &
                        "' And ThisShiftEmployeeRecordId <> 0" &
                        " Order by Date, ShiftDescription"
        Try
            DESVDC = New DailyEmployeeShiftViewDataContext
            BindingSource1.DataSource = DESVDC.ExecuteQuery(Of DailyEmployeeShiftView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyEmployeeShiftView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
        BindingSource1.MoveFirst()
        Do
            Try
                DailyEmployeeShiftViewRow = BindingSource1.Current
            Catch ex As Exception
                Exit Do
            End Try
            If DailyEmployeeShiftViewRow IsNot Nothing Then
                If CurrentRecordId = DailyEmployeeShiftViewRow.RecordId Then Exit Do
                CurrentRecordId = DailyEmployeeShiftViewRow.RecordId
                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With DailyEmployeeShiftViewRow
                    If .ClockStartTime = #1/1/2000 12:00:00 AM# Then .EmployeeStartTime = .EmployeeStartTime.AddHours(1)
                    If .ClockEndTime = #1/1/2000 12:00:00 AM# Then .EmployeeEndTime = .EmployeeEndTime.AddHours(-1)
                    If .ClockStartTime = #1/1/2000 12:00:00 AM# And .ClockEndTime = #1/1/2000 12:00:00 AM# Then
                        .EmployeeStartTime = #1/1/2000 12:00:00 AM#
                        .EmployeeEndTime = #1/1/2000 12:00:00 AM#
                    End If
                End With

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = DailyEmployeeShiftViewRow.Date
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = DailyEmployeeShiftViewRow.ShiftDescription
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = DailyEmployeeShiftViewRow.StartTime.ToString("t")
                    If DailyEmployeeShiftViewRow.EmployeeStartTime.TimeOfDay <> DailyEmployeeShiftViewRow.StartTime.TimeOfDay Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = DailyEmployeeShiftViewRow.EndTime.ToString("t")
                    If DailyEmployeeShiftViewRow.EmployeeEndTime.TimeOfDay <> DailyEmployeeShiftViewRow.EndTime.TimeOfDay Then .Range(CellString).Interior.Color = Color.LightCoral

                    Dim tempTimeSpan As TimeSpan
                    tempTimeSpan = DailyEmployeeShiftViewRow.EndTime.TimeOfDay.Subtract(DailyEmployeeShiftViewRow.StartTime.TimeOfDay)
                    Dim strHours As String = tempTimeSpan.Hours.ToString().PadLeft(2, "0"c)
                    Dim strMinutes As String = tempTimeSpan.Minutes.ToString().PadLeft(2, "0"c)
                    Dim decHours As Decimal = strHours
                    Dim decMinutes As Decimal = strMinutes
                    CellString = "E" & LineNoString
                    .Range(CellString).Value = (decHours + (decMinutes / 60))

                    CellString = "G" & LineNoString
                    If DailyEmployeeShiftViewRow.EmployeeStartTime <> #1/1/2000 12:00:00 AM# Then .Range(CellString).Value = DailyEmployeeShiftViewRow.EmployeeStartTime.ToString("t")
                    If DailyEmployeeShiftViewRow.EmployeeStartTime.TimeOfDay <> DailyEmployeeShiftViewRow.StartTime.TimeOfDay Then .Range(CellString).Interior.Color = Color.LightPink
                    CellString = "H" & LineNoString
                    If DailyEmployeeShiftViewRow.EmployeeEndTime <> #1/1/2000 12:00:00 AM# Then .Range(CellString).Value = DailyEmployeeShiftViewRow.EmployeeEndTime.ToString("t")
                    If DailyEmployeeShiftViewRow.EmployeeEndTime.TimeOfDay <> DailyEmployeeShiftViewRow.EndTime.TimeOfDay Then .Range(CellString).Interior.Color = Color.LightCoral

                    tempTimeSpan = DailyEmployeeShiftViewRow.EmployeeEndTime.TimeOfDay.Subtract(DailyEmployeeShiftViewRow.EmployeeStartTime.TimeOfDay)
                    strHours = tempTimeSpan.Hours.ToString().PadLeft(2, "0"c)
                    strMinutes = tempTimeSpan.Minutes.ToString().PadLeft(2, "0"c)
                    decHours = strHours
                    decMinutes = strMinutes

                    CellString = "I" & LineNoString
                    .Range(CellString).Value = (decHours + (decMinutes / 60))

                    If .Range("E" & LineNoString).Value <> .Range("I" & LineNoString).Value Then
                        .Range("E" & LineNoString).Interior.Color = Color.LightBlue
                        .Range("I" & LineNoString).Interior.Color = Color.LightBlue
                    End If

                    CellString = "K" & LineNoString
                    If DailyEmployeeShiftViewRow.ClockStartTime <> #1/1/2000 12:00:00 AM# Then .Range(CellString).Value = DailyEmployeeShiftViewRow.ClockStartTime.ToString("t")
                    If DailyEmployeeShiftViewRow.ClockStartTime = #1/1/2000 12:00:00 AM# Or DailyEmployeeShiftViewRow.StartTime.TimeOfDay <> DailyEmployeeShiftViewRow.EmployeeStartTime.TimeOfDay Then
                        .Range(CellString).Interior.Color = Color.LightPink
                    End If
                    CellString = "L" & LineNoString
                    If DailyEmployeeShiftViewRow.ClockEndTime <> #1/1/2000 12:00:00 AM# Then .Range(CellString).Value = DailyEmployeeShiftViewRow.ClockEndTime.ToString("t")
                    If DailyEmployeeShiftViewRow.ClockEndTime = #1/1/2000 12:00:00 AM# Or DailyEmployeeShiftViewRow.EndTime.TimeOfDay <> DailyEmployeeShiftViewRow.EmployeeEndTime.TimeOfDay Then
                        .Range(CellString).Interior.Color = Color.LightCoral
                    End If
                    CellString = "M" & LineNoString
                    .Range(CellString).Value = DailyEmployeeShiftViewRow.EmployeeName

                    CellString = "A" & LineNoString & ":M" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "E" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "I" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "A" & LineNoString & ":E" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "G" & LineNoString & ":I" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "K" & LineNoString & ":M" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                End With
            End If
            BindingSource1.MoveNext()
            If SpreadsheetLine > 1000 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    'Private Sub WriteExcelBodyOld()
    '    Dim CurrentRecordId As Integer

    '    SpreadsheetLine = 5

    '    With xlWorkSheet
    '        .Range("A6:Z5000").Font.Bold = False
    '        .Range("A6:Z5000").Font.Size = 11
    '    End With

    '    Dim SQL = "Select * From DailyEmployeeShiftView Where Date >= '" &
    '                    DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and Date <= '" &
    '                    DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") &
    '                    "' And ThisShiftEmployeeRecordId <> 0" &
    '                    " Order by Date, ShiftDescription"
    '    Try
    '        DESVDC = New DailyEmployeeShiftViewDataContext
    '        BindingSource1.DataSource = DESVDC.ExecuteQuery(Of DailyEmployeeShiftView)(SQL)
    '    Catch ex As Exception
    '        MessageBox.Show("DailyEmployeeShiftView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
    '    End Try
    '    BindingSource1.MoveFirst()
    '    Do
    '        Try
    '            DailyEmployeeShiftViewRow = BindingSource1.Current
    '        Catch ex As Exception
    '            Exit Do
    '        End Try
    '        If DailyEmployeeShiftViewRow IsNot Nothing Then
    '            If CurrentRecordId = DailyEmployeeShiftViewRow.RecordId Then Exit Do
    '            CurrentRecordId = DailyEmployeeShiftViewRow.RecordId
    '            SpreadsheetLine += 1
    '            LineNoString = SpreadsheetLine

    '            Dim difShiftStart As TimeSpan = DailyEmployeeShiftViewRow.EmployeeStartTime.Subtract(DailyEmployeeShiftViewRow.StartTime)
    '            Dim difShiftStartHr As Integer = difShiftStart.Hours
    '            Dim difShiftStartMin As Integer = difShiftStart.Minutes

    '            Dim difShiftEnd As TimeSpan = DailyEmployeeShiftViewRow.EmployeeEndTime.Subtract(DailyEmployeeShiftViewRow.EndTime)
    '            Dim difShiftEndHr As Integer = difShiftEnd.Hours
    '            Dim difShiftEndMin As Integer = difShiftEnd.Minutes

    '            Dim difClockStart As TimeSpan = DailyEmployeeShiftViewRow.ClockStartTime.Subtract(DailyEmployeeShiftViewRow.EmployeeStartTime)
    '            Dim difClockStartHr As Integer = difClockStart.Hours
    '            Dim difClockStartMin As Integer = difClockStart.Minutes

    '            Dim difClockEnd As TimeSpan = DailyEmployeeShiftViewRow.ClockEndTime.Subtract(DailyEmployeeShiftViewRow.EmployeeEndTime)
    '            Dim difClockEndHr As Integer = difClockEnd.Hours
    '            Dim difClockEndMin As Integer = difClockEnd.Minutes

    '            With xlWorkSheet
    '                CellString = "A" & LineNoString
    '                .Range(CellString).Value = DailyEmployeeShiftViewRow.Date
    '                CellString = "B" & LineNoString
    '                .Range(CellString).Value = DailyEmployeeShiftViewRow.ShiftDescription
    '                CellString = "C" & LineNoString
    '                .Range(CellString).Value = DailyEmployeeShiftViewRow.StartTime.ToString("t")
    '                If DailyEmployeeShiftViewRow.EmployeeStartTime.TimeOfDay > DailyEmployeeShiftViewRow.StartTime.TimeOfDay Then
    '                    If difShiftStartHr <> 0 Or difShiftStartMin <> 0 Then .Range(CellString).Interior.Color = Color.LightPink
    '                End If
    '                CellString = "D" & LineNoString
    '                .Range(CellString).Value = DailyEmployeeShiftViewRow.EndTime.ToString("t")
    '                If DailyEmployeeShiftViewRow.EmployeeEndTime.TimeOfDay < DailyEmployeeShiftViewRow.EndTime.TimeOfDay Then
    '                    If difShiftEndHr <> 0 Or difShiftEndMin <> 0 Then .Range(CellString).Interior.Color = Color.LightPink
    '                End If
    '                CellString = "E" & LineNoString
    '                .Range(CellString).Value = DailyEmployeeShiftViewRow.Hours.ToString

    '                CellString = "G" & LineNoString
    '                .Range(CellString).Value = DailyEmployeeShiftViewRow.EmployeeStartTime.ToString("t")
    '                If DailyEmployeeShiftViewRow.EmployeeStartTime.TimeOfDay > DailyEmployeeShiftViewRow.StartTime.TimeOfDay Then
    '                    If difShiftStartHr <> 0 Or difShiftStartMin <> 0 Then .Range(CellString).Interior.Color = Color.LightPink
    '                End If
    '                If DailyEmployeeShiftViewRow.ClockStartTime = #1/1/2000 12:00:00 AM# Or DailyEmployeeShiftViewRow.ClockStartTime.TimeOfDay > DailyEmployeeShiftViewRow.EmployeeStartTime.TimeOfDay Then
    '                    If difClockStartHr <> 0 Or difClockStartMin > 15 Then .Range(CellString).Interior.Color = Color.LightPink
    '                End If
    '                CellString = "H" & LineNoString
    '                .Range(CellString).Value = DailyEmployeeShiftViewRow.EmployeeEndTime.ToString("t")
    '                If DailyEmployeeShiftViewRow.EmployeeEndTime.TimeOfDay < DailyEmployeeShiftViewRow.EndTime.TimeOfDay Then
    '                    If difShiftEndHr <> 0 Or difShiftEndMin <> 0 Then .Range(CellString).Interior.Color = Color.LightPink
    '                End If
    '                If DailyEmployeeShiftViewRow.ClockEndTime = #1/1/2000 12:00:00 AM# Or DailyEmployeeShiftViewRow.ClockEndTime.TimeOfDay < DailyEmployeeShiftViewRow.EmployeeEndTime.TimeOfDay Then
    '                    If difClockEndHr <> 0 Or difClockEndMin > 15 Then .Range(CellString).Interior.Color = Color.LightPink
    '                End If
    '                CellString = "I" & LineNoString
    '                .Range(CellString).Value = DailyEmployeeShiftViewRow.EmployeeHours.ToString

    '                CellString = "K" & LineNoString
    '                If DailyEmployeeShiftViewRow.ClockStartTime <> #1/1/2000 12:00:00 AM# Then
    '                    .Range(CellString).Value = DailyEmployeeShiftViewRow.ClockStartTime.ToString("t")
    '                End If
    '                If DailyEmployeeShiftViewRow.ClockStartTime = #1/1/2000 12:00:00 AM# Or DailyEmployeeShiftViewRow.ClockStartTime.TimeOfDay > DailyEmployeeShiftViewRow.EmployeeStartTime.TimeOfDay Then
    '                    If difClockStartHr <> 0 Or difClockStartMin > 15 Then .Range(CellString).Interior.Color = Color.LightPink
    '                End If
    '                CellString = "L" & LineNoString
    '                If DailyEmployeeShiftViewRow.ClockEndTime <> #1/1/2000 12:00:00 AM# Then
    '                    .Range(CellString).Value = DailyEmployeeShiftViewRow.ClockEndTime.ToString("t")
    '                End If
    '                If DailyEmployeeShiftViewRow.ClockEndTime = #1/1/2000 12:00:00 AM# Or DailyEmployeeShiftViewRow.ClockEndTime.TimeOfDay < DailyEmployeeShiftViewRow.EmployeeEndTime.TimeOfDay Then
    '                    If difClockEndHr <> 0 Or difClockEndMin > 15 Then .Range(CellString).Interior.Color = Color.LightPink
    '                End If
    '                CellString = "M" & LineNoString
    '                .Range(CellString).Value = DailyEmployeeShiftViewRow.EmployeeName
    '                CellString = "A" & LineNoString & ":M" & LineNoString
    '                .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
    '                CellString = "A" & LineNoString & ":E" & LineNoString
    '                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
    '                CellString = "G" & LineNoString & ":I" & LineNoString
    '                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
    '                CellString = "K" & LineNoString & ":M" & LineNoString
    '                .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
    '            End With
    '        End If
    '        BindingSource1.MoveNext()
    '        If SpreadsheetLine > 1000 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
    '    Loop
    'End Sub

    Private Sub WriteExcelFooter()
        With xlWorkSheet
            CellString = "A5:M" & LineNoString
            .Range(CellString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            'LineNoString = SpreadsheetLine
            '    'CellString = "I4:J" & LineNoString
            '    'xlWorkSheet1.Range(CellString).Columns.AutoFit()
            xlWorkSheet.Range("A6").Select()
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
            .Orientation = Excel.XlPageOrientation.xlPortrait                                   ' Excel.XlPageOrientation.xlLandscape               ' '1 = xlPortrait; 2 = xlLandscape
            '.Draft = True
            .PaperSize = Excel.XlPaperSize.xlPaperA4
            .FirstPageNumber = Excel.Constants.xlAutomatic
            .Order = Excel.XlOrder.xlDownThenOver
            .BlackAndWhite = True
            .PrintErrors = Excel.XlPrintErrors.xlPrintErrorsDisplayed
            .OddAndEvenPagesHeaderFooter = False
            .DifferentFirstPageHeaderFooter = False
            .ScaleWithDocHeaderFooter = False
            .AlignMarginsHeaderFooter = False

            '~~> More settings that you can set
            .Zoom = False
            '.FitToPagesWide = 1
            '.FitToPagesTall = 1
        End With
    End Sub

End Class