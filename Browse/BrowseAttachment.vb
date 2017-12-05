Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseAttachment

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Asset Attachments " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim ASVDC As AssetViewDataContext
    Dim AssetViewRow As AssetView
    Dim AVDC As AttachmentViewDataContext
    Dim AttachmentViewRow As AttachmentView

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Private Sub BrowseAttachment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
        If GlobalAssetLookupRecordId Then ReadAssetRecord()
        AttachmentGrid1.LoadData()
    End Sub

    Private Sub ReadAssetRecord()
        ASVDC = New AssetViewDataContext
        AssetViewBindingSource.DataSource = From AssetView In ASVDC.AssetViews Where AssetView.RecordId = GlobalAssetLookupRecordId
        AssetViewRow = AssetViewBindingSource.Current
        If AssetViewRow Is Nothing Then
            'MsgBox("No Asset Selected")
            Me.Close()
        End If
    End Sub

    Private Sub BrowseAttachment_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
            AttachmentGrid1.DeleteRow()
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        AttachmentGrid1.ChangeRow()
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        Using frm As New UpdateAttachmentForm(-1)
            frm.ShowDialog()
            AttachmentGrid1.LoadData()
        End Using
    End Sub

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        CheckForFileAndContinue()
    End Sub

    Private Sub CheckForFileAndContinue()
        CreateExcelWorkbook()
        WriteExcelHeader()
        WriteExcelBody()
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

            .Range("A2").Value = "Asset Attachment dated: " & Today.ToLongDateString
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

            .Range("A4:C9").Font.Bold = True
            .Range("A4:C9").Font.Size = 12
            .Range("A4:C9").HorizontalAlignment = Excel.Constants.xlLeft
            .Range("A4:C9").Borders.LineStyle = Excel.Constants.xlSolid

            .Range("A4:B4").Merge()
            .Range("A5:B5").Merge()
            .Range("A6:B6").Merge()
            .Range("A7:B7").Merge()
            .Range("A8:B8").Merge()
            .Range("A9:B9").Merge()

            .Range("A11").Value = "Date"
            .Range("B11").Value = "Description"
            .Range("C11").Value = "File Location And Name"

            .Range("A11:C11").Font.Bold = True
            .Range("A11:C11").Font.Size = 12
            .Range("A11:C11").WrapText = True
            .Range("A11:C11").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A11").ColumnWidth = 11
            .Range("B11").ColumnWidth = 50
            .Range("C11").ColumnWidth = 100
            .Range("A11:C11").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim CurrentRecordId As Integer
        SpreadsheetLine = 11

        With xlWorkSheet
            .Range("A12:Z500").Font.Bold = False
            .Range("A12:Z500").Font.Size = 11
        End With

        Dim SQLString As String = "Select * From AttachmentView Where AssetRecordid = " & AssetViewRow.RecordId & " Order by Date"
        Try
            Dim SQL = SQLString
            AVDC = New AttachmentViewDataContext
            AttachmentViewBindingSource.DataSource = AVDC.ExecuteQuery(Of AttachmentView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        AttachmentViewBindingSource.MoveFirst()
        Do
            Try
                AttachmentViewRow = AttachmentViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If AttachmentViewRow IsNot Nothing Then
                If CurrentRecordId = AttachmentViewRow.RecordId Then Exit Do
                CurrentRecordId = AttachmentViewRow.RecordId

                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = AttachmentViewRow.Date
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = AttachmentViewRow.Description
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = AttachmentViewRow.FileAndLocation

                    CellString = "A" & LineNoString & ":C" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                End With
            End If
            AttachmentViewBindingSource.MoveNext()
            If SpreadsheetLine > 200 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
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