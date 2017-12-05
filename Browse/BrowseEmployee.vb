Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseEmployee

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Employees " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim EVDC As EmployeeViewDataContext
    Dim EmployeeViewRow As EmployeeView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Private Sub BrowseEmployee_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
        If GlobalHideInsertAmendDelete = True Then
            InsertButton.Enabled = False
            ChangeButton.Enabled = False
            DeleteButton.Enabled = False
            SelectButton.Enabled = True
        Else
            InsertButton.Enabled = True
            ChangeButton.Enabled = True
            DeleteButton.Enabled = True
            SelectButton.Enabled = False
        End If
        ckbShowInactive.CheckState = GlobalShowInactiveEmployees
        EmployeeGrid1.LoadData()
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        GlobalEmployeeLookupRecordId = 0
        Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalHideInsertAmendDelete = False Then
            If GlobalEmployeeIsType < GlobalAdministrator Then
                MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
            Else
                EmployeeGrid1.DeleteRow()
            End If
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        If GlobalHideInsertAmendDelete = False Then
            If GlobalEmployeeIsType < GlobalAdministrator Then
                MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
            Else
                EmployeeGrid1.ChangeRow()
            End If
        End If
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        If GlobalHideInsertAmendDelete = False Then
            If GlobalEmployeeIsType < GlobalAdministrator Then
                MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
            Else
                Using frm As New UpdateEmployeeForm(-1)
                    frm.ShowDialog()
                    EmployeeGrid1.LoadData()
                End Using
            End If
        End If
    End Sub

    Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
        EmployeeGrid1.SelectRow()
        Close()
    End Sub

    Private Sub ckbShowInactiveEmployee_CheckedChanged(sender As Object, e As EventArgs) Handles ckbShowInactive.CheckedChanged
        GlobalShowInactiveEmployees = ckbShowInactive.CheckState
        EmployeeGrid1.LoadData()
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
        Close()
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
            .Range("A1:Z3").Font.Name = "Calibri"

            'Add Headings
            .Range("A1").Value = GlobalFirmDetailRow.FirmName
            .Range("A1").Font.Bold = True
            .Range("A1").Font.Size = 20

            .Range("A2").Value = "Employees"
            If GlobalShowInactiveEmployees = 1 Then .Range("A2").Value = "Employees Including Inactive"
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A4").Value = "Code"
            .Range("B4").Value = "Full Name"
            .Range("C4").Value = "Type"
            .Range("D4").Value = "Date Started"
            .Range("E4").Value = "Home Phone"
            .Range("F4").Value = "Cell"
            .Range("G4").Value = "Status"

            .Range("A4:G4").Font.Bold = True
            .Range("A4:G4").Font.Size = 9
            .Range("A4:G4").WrapText = True
            .Range("A4:G4").HorizontalAlignment = Excel.Constants.xlCenter
            .Range("A4:G4").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A4").ColumnWidth = 8
            .Range("B4").ColumnWidth = 30
            .Range("C4:G4").ColumnWidth = 15

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        Dim SQL = "Select * From EmployeeView where InactiveEmployee <> 1 Order by Code"
        If GlobalShowInactiveEmployees = 1 Then
            SQL = "Select * From EmployeeView Order by Code"
        End If
        Try
            EVDC = New EmployeeViewDataContext
            BindingSource1.DataSource = EVDC.ExecuteQuery(Of EmployeeView)(SQL)
        Catch ex As Exception
            MessageBox.Show("EmployeeView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        SpreadsheetLine = 4

        With xlWorkSheet
            .Range("A5:Z400").Font.Bold = False
            .Range("A5:Z400").Font.Size = 11
        End With

        ' Loop through the data and create the spreadsheet body 

        BindingSource1.MoveFirst()
        Do
            Try
                EmployeeViewRow = BindingSource1.Current
            Catch ex As Exception
                Exit Do
            End Try
            If EmployeeViewRow IsNot Nothing Then
                If CurrentRecordId = EmployeeViewRow.RecordId Then Exit Do
                CurrentRecordId = EmployeeViewRow.RecordId

                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = EmployeeViewRow.Code
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = EmployeeViewRow.Description
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = EmployeeViewRow.EmployeeTypeDescription
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = Format(EmployeeViewRow.DateStarted, "dd/MM/yyyy")
                    CellString = "E" & LineNoString
                    .Range(CellString).Value = EmployeeViewRow.HomeTelephone
                    CellString = "F" & LineNoString
                    .Range(CellString).Value = EmployeeViewRow.CellNumber
                    CellString = "G" & LineNoString
                    .Range(CellString).Value = EmployeeViewRow.InactiveEmployeeDescription
                    'If EmployeeViewRow.InactiveEmployee = 0 Then
                    '    .Range(CellString).Value = "Active"
                    'Else
                    '    .Range(CellString).Value = "Inactive"
                    'End If

                    CellString = "A" & LineNoString & ":G" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                End With
            End If
            BindingSource1.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()
        CellString = "A4:G" & LineNoString
        xlWorkSheet.Range(CellString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
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
        Close()
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