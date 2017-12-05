Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseAsset

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Asset " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Dim LastServicedDateString As String
    Dim TotalServiceValue As Decimal

    Dim DC As AssetDataContext
    Dim AssetRow As Asset
    Dim SVDC As ServicedViewDataContext
    Dim ServicedViewRow As ServicedView

    Private Sub BrowseAsset_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub AssetGrid_Load(sender As Object, e As EventArgs) Handles AssetGrid.Load
        ButtonFiltered()
        If GlobalHideInsertAmendDelete = True Then
            InsertButton.Enabled = False
            ChangeButton.Enabled = False
            DeleteButton.Enabled = False
            '            SelectButton.Enabled = True
        Else
            InsertButton.Enabled = True
            ChangeButton.Enabled = True
            DeleteButton.Enabled = True
            '            SelectButton.Enabled = False
        End If
        AssetGrid.LoadData()
    End Sub

    Private Sub ButtonFiltered()
        If GlobalLoginEmployeeBranchCode <> "" Then
            GlobalBranchLookupBranchCode = GlobalLoginEmployeeBranchCode
            btnSelectBranch.Enabled = False
        End If
        If GlobalBranchLookupBranchCode = "" Then
            btnSelectBranch.Text = "By &Branch"
        Else
            btnSelectBranch.Text = "By &Branch <F>"                      ' & ChrW(&H2714) & ChrW(&H2715)
        End If
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            AssetGrid.DeleteRow()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        AssetGrid.ChangeRow()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateAssetForm(-1)
            frm.ShowDialog()
            AssetGrid.LoadData()
        End Using
    End Sub

    Private Sub btnServiced_Click(sender As Object, e As EventArgs) Handles btnServiced.Click
        AssetGrid.ServicedRecord()
    End Sub

    Private Sub btnAttachment_Click(sender As Object, e As EventArgs) Handles btnAttachment.Click
        AssetGrid.AttachmentRecord()
    End Sub

    Private Sub btnSelectBranch_Click(sender As Object, e As EventArgs) Handles btnSelectBranch.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not a Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Dim HoldGlobalHideInsertAmendDelete = GlobalHideInsertAmendDelete
            GlobalHideInsertAmendDelete = True
            Using frm As New BrowseBranch
                frm.ShowDialog()
            End Using
            GlobalHideInsertAmendDelete = HoldGlobalHideInsertAmendDelete
        End If
        AssetGrid_Load(sender, e)
    End Sub

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        ProcessSpreadSheet()
    End Sub

    Private Sub ProcessSpreadSheet()
        Dim SQLString As String
        '        SQLString = "Select * From Asset Order by BranchCode, Description"

        SQLString = "Select * From Asset"
        If GlobalBranchLookupBranchCode <> "" Then
            SQLString = SQLString & " Where BranchCode = '" & GlobalBranchLookupBranchCode & "'"
        End If
        SQLString = SQLString & " Order by BranchCode, Description"

        Try
            Dim SQL = SQLString
            DC = New AssetDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of Asset)(SQL)
        Catch ex As Exception
            MessageBox.Show("Asset Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        CreateExcelWorkbook()
        WriteExcelHeader()
        WriteExcelBody()
        WriteExcelFooter()
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

            .Range("A2").Value = "Asset List"
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Report Dated " & Today
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 12

            .Range("A5").Value = "Branch Code"
            .Range("B5").Value = "Description"
            .Range("C5").Value = "Serial Number"
            .Range("D5").Value = "Purchase Date"
            .Range("E5").Value = "Quantity"
            .Range("F5").Value = "Purchase Price"
            .Range("G5").Value = "Total Amount"
            .Range("H5").Value = "Last Serviced"
            .Range("I5").Value = "Serviced Value"
            .Range("J5").Value = "Memo"

            .Range("A5:J5").Font.Bold = True
            .Range("A5:J5").Font.Size = 10
            .Range("A5:J5").WrapText = True
            .Range("A5:J5").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 10
            .Range("B5").ColumnWidth = 40
            .Range("C5").ColumnWidth = 20
            .Range("D5:I5").ColumnWidth = 12
            .Range("J5").ColumnWidth = 100
            .Range("A5:J5").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        SpreadsheetLine = 5

        With xlWorkSheet
            .Range("A6:Z500").Font.Bold = False
            .Range("A6:Z500").Font.Size = 11
        End With

        BindingSource1.MoveFirst()
        Do
            Try
                AssetRow = BindingSource1.Current
            Catch ex As Exception
                Exit Do
            End Try
            If AssetRow IsNot Nothing Then
                If CurrentRecordId = AssetRow.RecordId Then Exit Do
                CurrentRecordId = AssetRow.RecordId
                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                GetLastServiced()

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = AssetRow.BranchCode
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = AssetRow.Description
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = AssetRow.SerialNumber
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = AssetRow.PurchaseDate
                    CellString = "E" & LineNoString
                    .Range(CellString).Value = AssetRow.Quantity
                    CellString = "F" & LineNoString
                    .Range(CellString).Value = AssetRow.PurchaseAmount
                    CellString = "G" & LineNoString
                    FormulaString = "=(E" & LineNoString & "*F" & LineNoString & ")"
                    .Range(CellString).Formula = FormulaString                                       ' "=(E" & LineNoString & "*F" & LineNoString & ")"
                    CellString = "H" & LineNoString
                    .Range(CellString).Value = LastServicedDateString
                    CellString = "I" & LineNoString
                    .Range(CellString).Value = TotalServiceValue
                    CellString = "J" & LineNoString
                    .Range(CellString).Value = AssetRow.Memo

                    CellString = "A" & LineNoString & ":J" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "A" & LineNoString & ":C" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "D" & LineNoString & ":I" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    CellString = "E" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0"
                    CellString = "F" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                    CellString = "G" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                    CellString = "I" & LineNoString
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                    CellString = "J" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                End With
            End If
            BindingSource1.MoveNext()
            If SpreadsheetLine > 2000 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
            lblCounter.Text = SpreadsheetLine
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        With xlWorkSheet
            CellString = "A5:H" & LineNoString
            .Range(CellString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)

            SpreadsheetLine += 2
            LineNoString = SpreadsheetLine

            CellString = "D" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "G" & LineNoString
            FormulaString = "=SUBTOTAL(9,G6:G" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,B6:B123)"
            CellString = "I" & LineNoString
            FormulaString = "=SUBTOTAL(9,I6:I" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,B6:B123)"
            CellString = "D" & LineNoString & ":I" & LineNoString
            .Range(CellString).Font.Bold = True
            CellString = "D" & LineNoString & ":I" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "I" & LineNoString
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "D" & LineNoString & ":I" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            LineNoString = SpreadsheetLine
            CellString = "A4:Q" & LineNoString
            xlWorkSheet.Range(CellString).Columns.AutoFit()
            xlWorkSheet.Range("C6").Select()
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

    Private Sub GetLastServiced()
        Dim CurrentRecordId As Integer

        LastServicedDateString = ""
        TotalServiceValue = 0.0

        Dim SQLString As String = "Select * From ServicedView Where AssetRecordid = " & AssetRow.RecordId & " Order by Date"
        Try
            Dim SQL = SQLString
            SVDC = New ServicedViewDataContext
            ServicedViewBindingSource.DataSource = SVDC.ExecuteQuery(Of ServicedView)(SQL)
        Catch ex As Exception
            MessageBox.Show("ServicedView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        CurrentRecordId = 0
        ServicedViewBindingSource.MoveFirst()
        Do
            Try
                ServicedViewRow = ServicedViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If ServicedViewRow IsNot Nothing Then
                If CurrentRecordId = ServicedViewRow.RecordId Then Exit Do
                CurrentRecordId = ServicedViewRow.RecordId
                LastServicedDateString = ServicedViewRow.Date.ToString("dd/MM/yyyy")
                TotalServiceValue += ServicedViewRow.Amount
            End If
            ServicedViewBindingSource.MoveNext()
        Loop
    End Sub

End Class