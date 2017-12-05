Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseLeaveTaken

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Leave " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim DC As LeaveTakenViewDataContext
    Dim LeaveTakenViewRow As LeaveTakenView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Private Sub BrowseLeaveTaken_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub BrowseLeaveTaken_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalEmployeeClocking = 0 Then
            GlobalDateFrom = (DateSerial(Year(Today), Month(Today) - 1, 26))
            GlobalDateTo = (DateSerial(Year(Today), Month(Today), 25))
        End If
        DisplayGlobalFromToDates()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            LeaveTakenGrid.DeleteRow()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        LeaveTakenGrid.ChangeRow()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateLeaveTakenForm(-1)
            frm.ShowDialog()
            LeaveTakenGrid.LoadData()
        End Using
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
        LeaveTakenGrid.LoadData()
    End Sub

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
        ProcessSpreadSheet()
    End Sub

    Private Sub ProcessSpreadSheet()
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
            .Range("A1:Z500").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20
            .Range("A2").Value = "Leave Taken From " & GlobalDateFrom & " to " & GlobalDateTo
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A4").Value = "Start Date"
            .Range("B4").Value = "End Date"
            .Range("C4").Value = "Days Leave"
            .Range("D4").Value = "Leave Type"
            .Range("E4").Value = "Employee"

            .Range("A4:E4").Font.Bold = True
            .Range("A4:E4").Font.Size = 9
            .Range("A4:E4").WrapText = True
            .Range("A4:E4").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A4:D4").ColumnWidth = 15
            .Range("E4").ColumnWidth = 40

            .Range("A4:E4").Borders.LineStyle = Excel.Constants.xlSolid
        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer

        Dim SQL = "Select * From LeaveTakenView Where StartDate >= '" & _
            DateTime.Parse(GlobalDateFrom).ToString("dd MMM yyyy") & "' and StartDate <= '" & _
            DateTime.Parse(GlobalDateTo).ToString("dd MMM yyyy") & _
            "' Order by StartDate, RecordId"
        Try
            DC = New LeaveTakenViewDataContext
            LeaveTakenViewBindingSource.DataSource = DC.ExecuteQuery(Of LeaveTakenView)(SQL)
        Catch ex As Exception
            MessageBox.Show("LeaveTakenView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        SpreadsheetLine = 4

        With xlWorkSheet
            .Range("A5:Z400").Font.Bold = False
            .Range("A5:Z400").Font.Size = 11
        End With

        ' Loop through the data and create the spreadsheet body 

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

                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = Format(LeaveTakenViewRow.StartDate, "ddd,  d MMM yy")
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = Format(LeaveTakenViewRow.EndDate, "ddd,  d MMM yy")
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = LeaveTakenViewRow.Days
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = LeaveTakenViewRow.LeaveType
                    CellString = "E" & LineNoString
                    .Range(CellString).Value = LeaveTakenViewRow.ThisLeaveTakenEmployee

                    CellString = "A" & LineNoString & ":E" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "A" & LineNoString & ":B" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlCenter
                    CellString = "C" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    .Range(CellString).NumberFormat = "#,###,##0"
                    CellString = "D" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlCenter
                    CellString = "E" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                End With
            End If
            LeaveTakenViewBindingSource.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        With xlWorkSheet
            CellString = "A4:E" & LineNoString
            .Range(CellString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)

            SpreadsheetLine += 2
            LineNoString = SpreadsheetLine

            CellString = "C" & LineNoString
            FormulaString = "=SUBTOTAL(9,C5:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C4:C11)"
            CellString = "D" & LineNoString
            .Range(CellString).Value = "Total"

            CellString = "C" & LineNoString & ":D" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "C" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0"
            CellString = "A" & LineNoString & ":E" & LineNoString
            .Range(CellString).Font.Bold = True
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        xlWorkSheetSetup()
        With xlApp
            'LineNoString = SpreadsheetLine
            'CellString = "A4:Q" & LineNoString
            'xlWorkSheet.Range(CellString).Columns.AutoFit()
            xlWorkSheet.Range("A5").Select()
            .ActiveWindow.FreezePanes = True
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