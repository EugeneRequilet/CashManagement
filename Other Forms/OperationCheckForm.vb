Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class OperationCheckForm

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Tasks " & Today.ToString("yyyy-MM")            ' change this when selection of task button
    Dim XLExtention As String = ".xlsx"

    Dim DC As TaskViewDataContext
    Dim TaskRow As TaskView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String
    Dim SelectedGroupButton As Byte

    Private Sub OperationCheckForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub DailyTasksButton_Click(sender As Object, e As EventArgs) Handles DailyTasksButton.Click
        XLFileName = "Daily Tasks " & Today.ToString("yyyy-MM")
        SelectedGroupButton = 0
        ProcessSpreadSheet()
    End Sub

    Private Sub WeeklyTasksButton_Click(sender As Object, e As EventArgs) Handles WeeklyTasksButton.Click
        XLFileName = "Weekly Tasks " & Today.ToString("yyyy-MM")
        SelectedGroupButton = 1
        ProcessSpreadSheet()
    End Sub

    Private Sub MonthlyTasksButton_Click(sender As Object, e As EventArgs) Handles MonthlyTasksButton.Click
        XLFileName = "Monthly Tasks " & Today.ToString("yyyy-MM")
        SelectedGroupButton = 2
        ProcessSpreadSheet()
    End Sub

    Private Sub OtherTasksButton_Click(sender As Object, e As EventArgs) Handles OtherTasksButton.Click
        XLFileName = "Other Tasks " & Today.ToString("yyyy-MM")
        SelectedGroupButton = 3
        ProcessSpreadSheet()
    End Sub

    Private Sub ProcessSpreadSheet()
        Dim SQLString As String
        SQLString = "Select * From TaskView Where Groupnumber = " & SelectedGroupButton & " Order by Groupnumber, Number"
        Try
            Dim SQL = SQLString
            DC = New TaskViewDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of TaskView)(SQL)
        Catch ex As Exception
            MessageBox.Show("TaskView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

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
            .Range("A2").Value = XLFileName
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A4").Value = "No"
            .Range("B4").Value = "Task"
            .Range("C4").Value = "Done"

            .Range("A4:C4").Font.Bold = True
            .Range("A4:C4").Font.Size = 9
            .Range("A4:C4").WrapText = True
            .Range("A4:C4").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A4").ColumnWidth = 5
            .Range("B4").ColumnWidth = 90
            .Range("C4").ColumnWidth = 10

            .Range("A4:C4").Borders.LineStyle = Excel.Constants.xlSolid
        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        SpreadsheetLine = 4

        With xlWorkSheet
            .Range("A5:Z400").Font.Bold = False
            .Range("A5:Z400").Font.Size = 11
        End With

        ' Loop through the data and create the spreadsheet body 

        BindingSource1.MoveFirst()
        Do
            Try
                TaskRow = BindingSource1.Current
            Catch ex As Exception
                Exit Do
            End Try
            If TaskRow IsNot Nothing Then
                If CurrentRecordId = TaskRow.RecordId Then Exit Do
                CurrentRecordId = TaskRow.RecordId

                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = TaskRow.Number
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = TaskRow.Description
                End With
            End If
            BindingSource1.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        With xlWorkSheet
            CellString = "A5:A" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlCenter
            .Range(CellString).NumberFormat = "##0"
            .Range(CellString).VerticalAlignment = Excel.Constants.xlTop
            CellString = "B5:C" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            .Range(CellString).WrapText = True
            CellString = "A5:C" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).VerticalAlignment = Excel.Constants.xlTop
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        xlWorkSheetSetup()
        With xlApp
            'LineNoString = SpreadsheetLine
            'CellString = "A4:Q" & LineNoString
            'xlWorkSheet.Range(CellString).Columns.AutoFit()
            'xlWorkSheet.Range("B5").Select()
            '.ActiveWindow.FreezePanes = True
            '.ActiveWindow.Zoom = 85 ' open sheet at 85%
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