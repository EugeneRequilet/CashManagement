Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseTask

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Task " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Dim DC As TaskDataContext
    Dim TaskRow As TaskView

    Private Sub BrowseTask_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
        TaskGrid1.LoadData()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            TaskGrid1.DeleteRow()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        TaskGrid1.ChangeRow()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateTaskForm(-1)
            frm.ShowDialog()
            TaskGrid1.LoadData()
        End Using
    End Sub

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        ProcessSpreadSheet()
    End Sub

    Private Sub ProcessSpreadSheet()
        Dim SQLString As String
        SQLString = "Select * From TaskView Order by Groupnumber, Number"
        Try
            Dim SQL = SQLString
            DC = New TaskDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of TaskView)(SQL)
        Catch ex As Exception
            MessageBox.Show("Task Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
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

            .Range("A2").Value = "Tasks List"
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Report Dated " & Today
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 12

            .Range("A5").Value = "Group"
            .Range("B5").Value = "Task"
            .Range("C5").Value = "Description"

            .Range("A5:C5").Font.Bold = True
            .Range("A5:C5").Font.Size = 10
            .Range("A5:C5").WrapText = True
            .Range("A5:C5").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 10
            .Range("B5").ColumnWidth = 10
            .Range("C5").ColumnWidth = 180
            .Range("A5:C5").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        SpreadsheetLine = 5

        With xlWorkSheet
            .Range("A6:Z5000").Font.Bold = False
            .Range("A6:Z5000").Font.Size = 11
        End With

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
                    .Range(CellString).Value = TaskRow.GroupDescription
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = TaskRow.Number
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = TaskRow.Description
                End With
            End If
            BindingSource1.MoveNext()
            If SpreadsheetLine > 5000 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        With xlWorkSheet
            CellString = "A5:C" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A5:A" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            .Range(CellString).VerticalAlignment = Excel.Constants.xlTop
            CellString = "B5:B" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlCenter
            .Range(CellString).NumberFormat = "##0"
            .Range(CellString).VerticalAlignment = Excel.Constants.xlTop
            CellString = "C5:C" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            .Range(CellString).WrapText = True
            .Range(CellString).VerticalAlignment = Excel.Constants.xlTop
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            'LineNoString = SpreadsheetLine
            'CellString = "A4:Q" & LineNoString
            'xlWorkSheet.Range(CellString).Columns.AutoFit()
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
            .Orientation = Excel.XlPageOrientation.xlLandscape                                   ' Excel.XlPageOrientation.xlLandscape               ' '1 = xlPortrait; 2 = xlLandscape
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