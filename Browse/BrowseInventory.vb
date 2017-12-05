Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class BrowseInventory

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Inventory " & Today.ToString("yyyy-MM")
    Dim XLExtention As String = ".xlsx"

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Dim DC As InventoryViewDataContext
    Dim InventoryViewRow As InventoryView
    Dim SVDC As SupplierViewDataContext
    Dim SupplierViewRow As SupplierView

    Dim ScreenHeaderDetails As String = ""
    Dim SupplierName As String = ""

    Private Sub BrowseInventory_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
        ButtonFiltered()
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
        ckbShowInactive.CheckState = GlobalShowInactiveInventory
        If GlobalSupplierLookupRecordId Then ReadSupplier()
        GlobalFilterString = txtFilter.Text

        ScreenHeaderDetails = "Inventory List"
        If GlobalSupplierLookupRecordId Then ScreenHeaderDetails = SupplierName & " Inventory List"
        If GlobalFilterString <> "" Then ScreenHeaderDetails = "Inventory List Filtered by '" & GlobalFilterString & "'"
        If GlobalSupplierLookupRecordId And GlobalFilterString <> "" Then ScreenHeaderDetails = SupplierName & " Inventory List Filtered by '" & GlobalFilterString & "'"
        Me.Text = ScreenHeaderDetails

        If GlobalFirmDetailRow.GeneralDefaultDirectory <> "" Then
            XLDirectory = GlobalFirmDetailRow.GeneralDefaultDirectory
        End If
        If Directory.Exists(XLDirectory) = False Then
            MessageBox.Show("Invalid Folder set in the Firm Details Control:" & vbCrLf & XLDirectory & vbCrLf & vbCrLf & "Changing the Default folder to MyDocuments.", "Reporting Error")
            XLDirectory = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
        End If
        InventoryGrid1.LoadData()
    End Sub

    Private Sub ButtonFiltered()
        If GlobalSupplierLookupRecordId Then
            btnSelectSupplier.Text = "By &Supplier <F>"                      ' & ChrW(&H2714) & ChrW(&H2715)
        Else
            btnSelectSupplier.Text = "By &Supplier"
        End If
    End Sub

    Private Sub ReadSupplier()
        Try
            SupplierViewBindingSource.DataSource = From SupplierView In (New SupplierViewDataContext).SupplierViews Where SupplierView.RecordId = GlobalSupplierLookupRecordId
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        SupplierViewRow = If(SupplierViewBindingSource.Current, New SupplierView)
        SupplierName = SupplierViewRow.Description
    End Sub

    Private Sub CloseButton_Click(sender As Object, e As EventArgs) Handles CloseButton.Click
        GlobalSupplierLookupRecordId = 0
        Me.Close()
    End Sub

    Private Sub DeleteButton_Click(sender As Object, e As EventArgs) Handles DeleteButton.Click
        If GlobalHideInsertAmendDelete = False Then
            If GlobalEmployeeIsType < GlobalAdministrator Then
                MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
            Else
                InventoryGrid1.DeleteRow()
            End If
        End If
    End Sub

    Private Sub ChangeButton_Click(sender As Object, e As EventArgs) Handles ChangeButton.Click
        If GlobalHideInsertAmendDelete = False Then
            InventoryGrid1.ChangeRow()
        End If
    End Sub

    Private Sub InsertButton_Click(sender As Object, e As EventArgs) Handles InsertButton.Click
        If GlobalHideInsertAmendDelete = False Then
            Using frm As New UpdateInventoryForm(-1)
                frm.ShowDialog()
                InventoryGrid1.LoadData()
            End Using
        End If
    End Sub

    Private Sub SelectButton_Click(sender As Object, e As EventArgs) Handles SelectButton.Click
        InventoryGrid1.SelectRow()
        Me.Close()
    End Sub

    Private Sub ckbShowInactive_CheckedChanged(sender As Object, e As EventArgs) Handles ckbShowInactive.CheckedChanged
        GlobalShowInactiveInventory = ckbShowInactive.CheckState
        InventoryGrid1.LoadData()
    End Sub

    Private Sub txtFilter_Leave(sender As Object, e As EventArgs) Handles txtFilter.Leave
        Form_Load(sender, e)
    End Sub

    Private Sub btnSelectSupplier_Click(sender As Object, e As EventArgs) Handles btnSelectSupplier.Click
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Dim HoldGlobalHideInsertAmendDelete = GlobalHideInsertAmendDelete
            GlobalHideInsertAmendDelete = True
            Using frm As New BrowseSupplier
                frm.ShowDialog()
            End Using
            GlobalHideInsertAmendDelete = HoldGlobalHideInsertAmendDelete
        End If
        Form_Load(sender, e)
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

            .Range("A2").Value = ScreenHeaderDetails
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 16

            .Range("A3").Value = "Report Dated " & Today
            .Range("A3").Font.Bold = True
            .Range("A3").Font.Size = 12

            .Range("A5").Value = "Description"
            .Range("B5").Value = "Cost Price"
            .Range("C5").Value = "Selling Price"
            .Range("D5").Value = "Gross Profit"
            .Range("E5").Value = "Gross Profit %"

            .Range("A5:E5").Font.Bold = True
            .Range("A5:E5").Font.Size = 10
            .Range("A5:E5").WrapText = True
            .Range("A5:E5").HorizontalAlignment = Excel.Constants.xlCenter

            ' Setup Column Widths

            .Range("A5").ColumnWidth = 40
            .Range("B5:E5").ColumnWidth = 11
            .Range("A5:E5").Borders.LineStyle = Excel.Constants.xlSolid

        End With
    End Sub

    Private Sub WriteExcelBody()
        Dim SQL As String
        Dim CurrentRecordId As Integer

        SpreadsheetLine = 5

        With xlWorkSheet
            .Range("A6:Z5000").Font.Bold = False
            .Range("A6:Z5000").Font.Size = 11
        End With

        'SQLString = "Select * From InventoryView  Order by Description"
        'If GlobalSupplierLookupRecordId Then SQLString = "Select * From InventoryView Where SupplierId = " & GlobalSupplierLookupRecordId & "  Order by Description"
        'If GlobalFilterString <> "" Then SQLString = "Select * From InventoryView Where Description like '%" & GlobalFilterString & "%'  Order by Description"
        'If GlobalSupplierLookupRecordId And GlobalFilterString <> "" Then
        '    SQLString = "Select * From InventoryView Where SupplierId = " & GlobalSupplierLookupRecordId & " And Description like '%" & GlobalFilterString & "%'  Order by Description"
        'End If

        SQL = "Select * From InventoryView"
        If GlobalSupplierLookupRecordId <> 0 Or GlobalShowInactiveInventory = False Or GlobalFilterString <> "" Then SQL = SQL & " Where"
        If GlobalSupplierLookupRecordId Then
            SQL = SQL & " SupplierId = " & GlobalSupplierLookupRecordId
            If GlobalShowInactiveInventory = False Or GlobalFilterString <> "" Then SQL = SQL & " And"
        End If
        If GlobalShowInactiveInventory = False Then
            SQL = SQL & " InactiveInventory <> 1"
            If GlobalFilterString <> "" Then SQL = SQL & " And"
        End If
        If GlobalFilterString <> "" Then SQL = SQL & " Description like '%" & GlobalFilterString & "%'"
        SQL = SQL & " Order by Description"

        Try
            DC = New InventoryViewDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of InventoryView)(SQL)
        Catch ex As Exception
            MessageBox.Show("InventoryView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
        BindingSource1.MoveFirst()
        Do
            Try
                InventoryViewRow = BindingSource1.Current
            Catch ex As Exception
                Exit Do
            End Try
            If InventoryViewRow IsNot Nothing Then
                If CurrentRecordId = InventoryViewRow.RecordId Then Exit Do
                CurrentRecordId = InventoryViewRow.RecordId
                SpreadsheetLine += 1
                LineNoString = SpreadsheetLine

                With xlWorkSheet
                    CellString = "A" & LineNoString
                    .Range(CellString).Value = InventoryViewRow.Description
                    CellString = "B" & LineNoString
                    .Range(CellString).Value = InventoryViewRow.CostPrice
                    CellString = "C" & LineNoString
                    .Range(CellString).Value = InventoryViewRow.SellingPrice
                    CellString = "D" & LineNoString
                    FormulaString = "=C" & LineNoString & "-B" & LineNoString
                    .Range(CellString).Formula = FormulaString
                    CellString = "E" & LineNoString
                    FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100.0,0)"
                    .Range(CellString).Formula = FormulaString

                    CellString = "A" & LineNoString & ":E" & LineNoString
                    .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
                    CellString = "A" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
                    CellString = "B" & LineNoString & ":E" & LineNoString
                    .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
                    .Range(CellString).NumberFormat = "#,###,##0.00"
                End With
            End If
            BindingSource1.MoveNext()
            If SpreadsheetLine > 5000 Then Exit Do ' Lots of lines of data on spreadsheet - Break out
        Loop
    End Sub

    Private Sub WriteExcelFooter()

        'Write the Footer First Line

        With xlWorkSheet
            CellString = "A5:E" & LineNoString
            .Range(CellString).AutoFilter(Field:=1, Operator:=Excel.XlAutoFilterOperator.xlFilterValues)

            SpreadsheetLine += 2
            LineNoString = SpreadsheetLine

            CellString = "A" & LineNoString
            .Range(CellString).Value = "Total"
            CellString = "B" & LineNoString
            FormulaString = "=SUBTOTAL(9,B6:B" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,B6:B123)"
            CellString = "C" & LineNoString
            FormulaString = "=SUBTOTAL(9,C6:C" & (LineNoString - 1) & ")"
            .Range(CellString).Formula = FormulaString                                                        ' "=SUBTOTAL(9,C6:C123)"
            CellString = "D" & LineNoString
            FormulaString = "=C" & LineNoString & "-B" & LineNoString
            .Range(CellString).Formula = FormulaString
            CellString = "E" & LineNoString
            FormulaString = "=IF(C" & LineNoString & "<>0,D" & LineNoString & "/C" & LineNoString & "*100.0,0)"
            .Range(CellString).Formula = FormulaString

            CellString = "A" & LineNoString & ":E" & LineNoString
            .Range(CellString).Font.Bold = True
            .Range(CellString).Borders.LineStyle = Excel.Constants.xlSolid
            CellString = "A" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlLeft
            CellString = "B" & LineNoString & ":E" & LineNoString
            .Range(CellString).HorizontalAlignment = Excel.Constants.xlRight
            .Range(CellString).NumberFormat = "#,###,##0.00"
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