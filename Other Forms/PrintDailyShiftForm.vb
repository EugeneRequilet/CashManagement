Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class PrintDailyShiftForm

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Daily Shift " & Today.ToString("yyyy-MM-dd") & " From " & Today.ToString("yyyy-MM-dd")
    Dim XLExtention As String = ".xlsx"

    Dim DSHVDC As DailyShiftHeaderViewDataContext
    Dim DailyShiftHeaderViewRow As DailyShiftHeaderView
    Dim DSVDC As DailyShiftViewDataContext
    Dim DailyShiftViewRow As DailyShiftView
    Dim EDC As EmployeeDataContext
    Dim EmployeeRow As Employee

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Dim LastColumnString As String = ""

    Private Sub PrintDailyShiftForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setDropdowns()

        ' Set for this months wages from 26 of last month to 25 of this month

        txtDateFrom.Text = (DateSerial(Year(Today), Month(Today) - 1, 26)).ToString
        txtDateTo.Text = (DateSerial(Year(Today), Month(Today), 25)).ToString

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
        XLFileName = "Daily Shift " & Format(txtDateTo.Value, "yyyy-MM-dd") & " From " & Format(txtDateFrom.Value, "yyyy-MM-dd")
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

        'xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        Try
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")
        Catch ex As Exception
            xlWorkSheet = xlWorkBook.Sheets.Add(After:=xlWorkBook.Sheets(xlWorkBook.Sheets.Count))
        End Try

        With xlWorkSheet
            .Range("A1:BZ3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            If cboEmployee.SelectedIndex = 0 Then
                .Range("A2").Value = "Daily Shifts For All Employees"
            Else
                .Range("A2").Value = "Daily Shifts For " & cboEmployee.SelectedItem.ToString()
            End If
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Daily Shifts From " & txtDateFrom.Text & " to " & txtDateTo.Text
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 16

            .Range("A6").Value = "Day"
            .Range("B6").Value = "Date"
            .Range("C6").Value = "Shifts"

            .Range("A5:C6").Font.Bold = True
            .Range("A5:C6").Font.Size = 9
            .Range("A5:C6").WrapText = True
            .Range("A5:C6").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 6
            .Range("B5").ColumnWidth = 11
            .Range("C5").ColumnWidth = 6
            .Range("A6:C6").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        Dim SQL As String
        SQL = "Select * From DailyShiftHeaderView Where Date >= '" & _
            DateTime.Parse(txtDateFrom.Text).ToString("dd MMM yyyy") & "' and Date <= '" & _
            DateTime.Parse(txtDateTo.Text).ToString("dd MMM yyyy") & _
            "' Order by Date"
        Try
            DSHVDC = New DailyShiftHeaderViewDataContext
            DailyShiftHeaderViewBindingSource.DataSource = DSHVDC.ExecuteQuery(Of DailyShiftHeaderView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyShiftHeaderView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        SpreadsheetLine = 6

        With xlWorkSheet
            .Range("A7:BZ200").Font.Bold = False
            .Range("A7:BZ200").Font.Size = 11
        End With

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

                With xlWorkSheet
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
                WriteExcelBodyDailyShifts()
            End If
            DailyShiftHeaderViewBindingSource.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelBodyDailyShifts()
        Dim CurrentRecordId As Integer
        Dim SQL As String
        SQL = "Select * From DailyShiftView Where Date = '" & _
            DateTime.Parse(DailyShiftHeaderViewRow.Date).ToString("dd MMM yyyy") & _
            "' Order by Date, ShiftDescription"

        If cboEmployee.SelectedIndex <> 0 Then
            SQL = "Select * From DailyShiftView Where Date = '" & _
                DateTime.Parse(DailyShiftHeaderViewRow.Date).ToString("dd MMM yyyy") & _
                "' And ThisShiftEmployee = '" & cboEmployee.Text & _
                "' Order by Date, ShiftDescription"
        End If

        Try
            DSVDC = New DailyShiftViewDataContext
            DailyShiftViewBindingSource.DataSource = DSVDC.ExecuteQuery(Of DailyShiftView)(SQL)
        Catch ex As Exception
            MessageBox.Show("DailyShiftView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the DailyShiftView file using the DailyShiftHeaderView date selected

        DailyShiftViewBindingSource.MoveFirst()
        Do
            Try
                DailyShiftViewRow = DailyShiftViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If DailyShiftViewRow IsNot Nothing Then
                If CurrentRecordId = DailyShiftViewRow.RecordId Then Exit Do
                CurrentRecordId = DailyShiftViewRow.RecordId
                If cboEmployee.SelectedIndex <> 0 And cboEmployee.Text <> DailyShiftViewRow.ThisShiftEmployee Then Exit Do

                LineNoString = SpreadsheetLine
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
                    With xlWorkSheet
                        If .Range(CellString & "5").Value = "" Then
                            .Range(CellString & "5").Value = DailyShiftViewRow.ShiftDescription
                            .Range(CellString & "6").Value = Format(DailyShiftViewRow.StartTime, "hh:mm") & " to " & Format(DailyShiftViewRow.EndTime, "hh:mm")
                            ColumnString = CellString
                            Exit Do
                        End If
                        If .Range(CellString & "5").Value = DailyShiftViewRow.ShiftDescription Then
                            ColumnString = CellString
                            Exit Do
                        End If
                    End With
                Loop

                ' Another method of doing the code above. 

                'Dim Count As Integer = 0
                'Dim literal As String = "D E F G H I J K L M N O P Q R S T U V W X Y Z AAABACADAEAFAGAHAIAJAKALAMANAOAPAQARASATAUAVAWAXAYAZBABBBCBDBEBFBGBHBIBJBKBLBMBNBOBPBQBRBSBTBUBVBWBXBYBZ"
                'Do
                '    CellString = Trim(literal.Substring(Count, 2))
                '    With xlWorkSheet
                '        If .Range(CellString & "5").Value = "" Then
                '            .Range(CellString & "5").Value = DailyShiftViewRow.Description
                '            .Range(CellString & "6").Value = Format(DailyShiftViewRow.StartTime, "hh:mm") & " to " & Format(DailyShiftViewRow.EndTime, "hh:mm")
                '            ColumnString = CellString
                '            Exit Do
                '        End If
                '        If .Range(CellString & "5").Value = DailyShiftViewRow.Description Then
                '            ColumnString = CellString
                '            Exit Do
                '        End If
                '    End With
                '    Count += 2
                '    If Count >= literal.Length Then
                '        MessageBox.Show("The Count is greater than the Literal" & vbCrLf & vbCrLf & "This should never happen" & vbCrLf & vbCrLf & "This means that there is more data than columns", "Reporting Error")
                '        Exit Do
                '    End If
                'Loop

                If LastColumnString < ColumnString Then LastColumnString = ColumnString
                If ColumnString = "" Then
                    MessageBox.Show("ColumnString is blank Error" & vbCrLf & vbCrLf & "This should never happen" & vbCrLf & vbCrLf & "This means that there is more data than columns", "Reporting Error")
                Else
                    CellString = ColumnString & LineNoString
                    With xlWorkSheet
                        .Range(CellString).Value = Mid(DailyShiftViewRow.ThisShiftEmployee, 1, 14)
                        .Range(CellString).Interior.Color = Color.Lavender
                    End With
                End If
            End If
            DailyShiftViewBindingSource.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()
        With xlWorkSheet

            ' Set up column widths

            If LastColumnString = "" Then LastColumnString = "D"
            CellString = "D5:" & LastColumnString & "5"
            .Range(CellString).ColumnWidth = 15

            ' Set up header formatting

            CellString = "D5:" & LastColumnString & "6"
            .Range(CellString).Font.Bold = True
            .Range(CellString).Font.Size = 9
            .Range(CellString).WrapText = True
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlCenter

            ' Set up body formatting

            LineNoString = SpreadsheetLine
            CellString = "D7:" & LastColumnString & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft

        End With
    End Sub

    Private Sub DisplayExcelWorkbook()

        XLWorkSheetSetup()
        With xlApp
            LineNoString = SpreadsheetLine
            'CellString = "I4:J" & LineNoString
            'xlWorkSheet.Range(CellString).Columns.AutoFit()
            xlWorkSheet.Range("D7").Select()
            .ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 85 ' open sheet at 85%
            .Visible = True
        End With
        'If cboSupplier.SelectedIndex <> 0 Then xlWorkSheet.Range("J5").ColumnWidth = 0
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