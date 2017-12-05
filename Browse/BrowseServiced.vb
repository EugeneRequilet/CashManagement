Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseServiced

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Asset Serviced " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim ASVDC As AssetViewDataContext
    Dim AssetViewRow As AssetView
    Dim SVDC As ServicedViewDataContext
    Dim ServicedViewRow As ServicedView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Private Sub BrowseServiced_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
        If GlobalAssetLookupRecordId Then ReadAssetRecord()
        ServicedGrid1.LoadData()
    End Sub

    Private Sub ReadAssetRecord()
        ASVDC = New AssetViewDataContext
        AssetViewBindingSource.DataSource = From AssetView In ASVDC.AssetViews Where AssetView.RecordId = GlobalAssetLookupRecordId
        AssetViewRow = AssetViewBindingSource.Current
        If AssetViewRow Is Nothing Then
            'MsgBox("No Asset Selected")
            Me.Close()
        End If
        SetAssetRepairAmount()
    End Sub

    Private Sub SetAssetRepairAmount()
        Dim CurrentRecordId As Integer
        Dim SQLString As String = "Select * From ServicedView Where AssetRecordId = " & GlobalAssetLookupRecordId
        txtServicedValue.EditValue = 0
        Try
            Dim SQL = SQLString
            SVDC = New ServicedViewDataContext
            ServicedViewBindingSource.DataSource = SVDC.ExecuteQuery(Of ServicedView)(SQL)
        Catch ex As Exception
            MessageBox.Show("ServicedView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
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
                txtServicedValue.EditValue += ServicedViewRow.Amount
            End If
            ServicedViewBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub BrowseServiced_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            ServicedGrid1.DeleteRow()
        End If
        SetAssetRepairAmount()
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        ServicedGrid1.ChangeRow()
        SetAssetRepairAmount()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateServicedForm(-1)
            frm.ShowDialog()
            ServicedGrid1.LoadData()
        End Using
        SetAssetRepairAmount()
    End Sub

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        CheckForFileAndContinue()
    End Sub

    Private Sub CheckForFileAndContinue()
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

            .Range("A2").Value = "Asset Serviced dated: " & Today.ToLongDateString
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 14

            .Range("A4").Value = "Branch"
            .Range("A5").Value = "Asset"
            .Range("A6").Value = "Serial Number"
            .Range("A7").Value = "Purchase Date"
            .Range("A8").Value = "Purchase Amount"
            .Range("A9").Value = "Memo"

            .Range("C4").Value = txtBranchCode.Text
            .Range("C5").Value = txtAssetDescription.Text
            .Range("C6").Value = txtSerialNumber.Text
            .Range("C7").Value = txtPurchasedDate.Text
            .Range("C8").Value = txtPurchasedAmount.EditValue
            .Range("C9").Value = txtAssetMemo.Text

            .Range("A4:D9").Font.Bold = True
            .Range("A4:D9").Font.Size = 12
            .Range("A4:D9").HorizontalAlignment = Excel.Constants.xlLeft
            .Range("A4:D9").Borders.LineStyle = Excel.Constants.xlSolid

            .Range("A4:B4").Merge()
            .Range("A5:B5").Merge()
            .Range("A6:B6").Merge()
            .Range("A7:B7").Merge()
            .Range("A8:B8").Merge()
            .Range("A9:B9").Merge()

            .Range("C4:D4").Merge()
            .Range("C5:D5").Merge()
            .Range("C6:D6").Merge()
            .Range("C7:D7").Merge()
            .Range("C8:D8").Merge()
            .Range("C9:D9").Merge()

            .Range("A11").Value = "Date"
            .Range("B11").Value = "Description"
            .Range("C11").Value = "Service Amount"
            .Range("D11").Value = "Memo"

            .Range("A11:D11").Font.Bold = True
            .Range("A11:D11").Font.Size = 9
            .Range("A11:D11").WrapText = True
            .Range("A11:D11").HorizontalAlignment = Excel.Constants.xlCenter

            .Range("C8").NumberFormat = "#,###,##0.00"

            ' Setup Column Widths

            .Range("A11").ColumnWidth = 11
            .Range("B11").ColumnWidth = 50
            .Range("C11").ColumnWidth = 11
            .Range("D11").ColumnWidth = 100
            .Range("A11:D11").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        SpreadsheetLine = 11

        With xlWorkSheet
            .Range("A12:Z500").Font.Bold = False
            .Range("A12:Z500").Font.Size = 11
        End With

        Dim SQLString As String = "Select * From ServicedView Where AssetRecordid = " & AssetViewRow.RecordId & " Order by Date"
        Try
            Dim SQL = SQLString
            SVDC = New ServicedViewDataContext
            ServicedViewBindingSource.DataSource = SVDC.ExecuteQuery(Of ServicedView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
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

                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = ServicedViewRow.Date
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = ServicedViewRow.Description
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = ServicedViewRow.Amount
                    CellString = "D" & LineNoString
                    .Range(CellString).Value = ServicedViewRow.Memo

                    CellString = "A" & LineNoString & ":D" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "A" & LineNoString & ":D" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "C" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                End With
            End If
            ServicedViewBindingSource.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        SpreadsheetLine += 2
        LineNoString = SpreadsheetLine

        With xlWorkSheet

            CellString = "B" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "C" & LineNoString
            FormulaString = "=SUM(C12:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUM(D11:D34)"

            CellString = "B" & LineNoString & ":C" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            .Range(CellString).Font.Bold = True
        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            LineNoString = SpreadsheetLine
            CellString = "E12:E" & LineNoString
            xlWorkSheet.Range(CellString).Columns.AutoFit()
            'xlWorkSheet.Range("C4").Select()
            '.ActiveWindow.FreezePanes = True
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
            .ScaleWithDocHeaderFooter = True
            .AlignMarginsHeaderFooter = True

            '~~> More settings that you can set
            .Zoom = False
            .FitToPagesWide = 1
            .FitToPagesTall = 1
        End With
    End Sub

End Class