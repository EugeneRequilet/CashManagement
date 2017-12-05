Imports Excel = Microsoft.Office.Interop.Excel
Imports System.IO

Public Class UpdateEmployeeForm

    Public RecordId As Integer

    Dim xlApp As New Excel.Application
    Dim xlWorkBook As Excel.Workbook
    Dim xlWorkSheet As Excel.Worksheet

    Dim XLDirectory As String = System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) & "\"
    Dim XLFileName As String = "Employee Form"
    Dim XLExtention As String = ".xlsx"

    Dim DC As EmployeeDataContext
    Dim EmployeeRow As Employee

    Dim SpreadsheetLine As Integer
    Dim LineNoString As String
    Dim CellString As String
    Dim FormulaString As String

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub Form_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New EmployeeDataContext
        BindingSource1.DataSource = From Employee In DC.Employees Where Employee.RecordId = RecordId
        EmployeeRow = BindingSource1.Current
        If EmployeeRow Is Nothing Then
            EmployeeRow = New Employee
            BindingSource1.AddNew()
            EmployeeRow = BindingSource1.Current
            setDefaults()
            Me.txtCode.Select()
        End If
        setDropdowns()
        setNumericsOnScreens()
    End Sub

    Private Sub setDefaults()
        If EmployeeRow.Gender Is Nothing Then EmployeeRow.Gender = "M"
        If EmployeeRow.MaritalStatus Is Nothing Then EmployeeRow.MaritalStatus = "S"
        If EmployeeRow.DateStarted Is Nothing OrElse EmployeeRow.DateStarted = Date.MinValue Then EmployeeRow.DateStarted = Today
        If EmployeeRow.Password Is Nothing Then EmployeeRow.Password = ""
        If EmployeeRow.FirstName Is Nothing Then EmployeeRow.FirstName = ""
        If EmployeeRow.Surname Is Nothing Then EmployeeRow.Surname = ""
        If EmployeeRow.BranchCode Is Nothing Then EmployeeRow.BranchCode = ""

        If EmployeeRow.NoOfDependants Is Nothing Then EmployeeRow.NoOfDependants = 0
        If EmployeeRow.Rate Is Nothing Then EmployeeRow.Rate = 0.0
        EmployeeRow.InactiveEmployee = False
        EmployeeRow.EmployeeType = 0

        'Dim Message = String.Format("setDefaults.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, EmployeeRow.Gender, EmployeeRow.MaritalStatus, EmployeeRow.DateStarted, EmployeeRow.NoOfDependants, EmployeeRow.Rate)
        'MsgBox(Message)

    End Sub

    Private Sub setDropdowns()
        cboEmployeeType.Items.Clear()
        cboEmployeeType.Items.Add("Asset Manager")                  ' GlobalAssetManager = 0
        cboEmployeeType.Items.Add("Server")                         ' GlobalServer = 1
        cboEmployeeType.Items.Add("Cashier")                        ' GlobalCashier = 2
        cboEmployeeType.Items.Add("Manager")                        ' GlobalManager = 3
        cboEmployeeType.Items.Add("Administrator")                  ' GlobalAdministrater = 4
        cboEmployeeType.SelectedIndex = EmployeeRow.EmployeeType

        cboGender.Items.Clear()
        cboGender.Items.Add("Male")
        cboGender.Items.Add("Female")
        cboGender.SelectedIndex = 0
        If EmployeeRow.Gender = "F" Then
            cboGender.SelectedIndex = 1
        Else
            cboGender.SelectedIndex = 0
        End If

        cboMaritalStatus.Items.Clear()
        cboMaritalStatus.Items.Add("Single")
        cboMaritalStatus.Items.Add("Married")
        cboMaritalStatus.Items.Add("Divorced")
        cboMaritalStatus.Items.Add("Widowed")
        Select Case EmployeeRow.MaritalStatus
            Case "S" ' Single
                cboMaritalStatus.SelectedIndex = 0
            Case "M" ' Married
                cboMaritalStatus.SelectedIndex = 1
            Case "D" ' Divorced
                cboMaritalStatus.SelectedIndex = 2
            Case "W" ' Widowed
                cboMaritalStatus.SelectedIndex = 3
            Case Else
                cboMaritalStatus.SelectedIndex = 0
        End Select
    End Sub

    Private Sub setNumericsOnScreens()
        txtNoOfDependants.EditValue = EmployeeRow.NoOfDependants
        txtRate.EditValue = EmployeeRow.Rate
    End Sub

    Private Function ValidateData() As DialogResult
        EmployeeRow.EmployeeType = cboEmployeeType.SelectedIndex

        Select Case cboGender.SelectedIndex
            Case 0 ' Male
                EmployeeRow.Gender = "M"
            Case 1 ' Female
                EmployeeRow.Gender = "F"
            Case Else
                EmployeeRow.Gender = "M"
        End Select

        Select Case cboMaritalStatus.SelectedIndex
            Case 0 ' Single
                EmployeeRow.MaritalStatus = "S"
            Case 1 ' Married
                EmployeeRow.MaritalStatus = "M"
            Case 2 ' Divorced
                EmployeeRow.MaritalStatus = "D"
            Case 3 ' Widowed
                EmployeeRow.MaritalStatus = "W"
            Case Else
                EmployeeRow.MaritalStatus = "S"
        End Select
        If txtFirstName.Text = "" Then
            txtFirstName.Select()
            MsgBox("You must enter a First Name.")
            Return DialogResult.Cancel
        End If
        If EmployeeRow.DateStarted Is Nothing OrElse EmployeeRow.DateStarted = Date.MinValue Then EmployeeRow.DateStarted = Today
        If ckbInactiveEmployee.Text = "" Then
            ckbInactiveEmployee.Text = False
            EmployeeRow.InactiveEmployee = False
        End If

        'Dim Message = String.Format("ValidateData.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, EmployeeRow.Gender, EmployeeRow.MaritalStatus, EmployeeRow.DateStarted, EmployeeRow.NoOfDependants, EmployeeRow.Rate)
        'MsgBox(Message)

        Return DialogResult.OK
    End Function

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            DC.SubmitChanges()
        Catch ex As Exception
            'MessageBox.Show("UpdateEmployeeForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("An Employee already Exists for:" & vbCrLf &
                            "Code: " & vbTab & vbTab & txtCode.Text & vbCrLf &
                            "Firstname: " & vbTab & txtFirstName.Text & vbCrLf &
                            "Surname: " & vbTab & txtSurname.Text & vbCrLf & vbCrLf &
                            "Error: " & vbTab & ex.Message & vbCrLf & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub PhysicalToPostalButton_Click(sender As Object, e As EventArgs) Handles PhysicalToPostalButton.Click
        EmployeeRow.PostalAddress1 = EmployeeRow.ResdentialAddress1
        EmployeeRow.PostalAddress2 = EmployeeRow.ResdentialAddress2
        EmployeeRow.PostalAddress3 = EmployeeRow.ResdentialAddress3
        EmployeeRow.PostalCode = EmployeeRow.ResdentialCode
    End Sub

    Private Sub PostalToPhysicalButton_Click(sender As Object, e As EventArgs) Handles PostalToPhysicalButton.Click
        EmployeeRow.ResdentialAddress1 = EmployeeRow.PostalAddress1
        EmployeeRow.ResdentialAddress2 = EmployeeRow.PostalAddress2
        EmployeeRow.ResdentialAddress3 = EmployeeRow.PostalAddress3
        EmployeeRow.ResdentialCode = EmployeeRow.PostalCode
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        BindingSource1.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtNoOfDependants_Validated(sender As Object, e As EventArgs) Handles txtNoOfDependants.Validated
        EmployeeRow.NoOfDependants = txtNoOfDependants.EditValue
    End Sub

    Private Sub txtRate_Validated(sender As Object, e As EventArgs) Handles txtRate.Validated
        EmployeeRow.Rate = txtRate.EditValue
    End Sub

    Private Sub ExcelButton_Click(sender As Object, e As EventArgs) Handles ExcelButton.Click
        CheckForFileAndContinue()
    End Sub

    Private Sub CheckForFileAndContinue()
        CreateExcelWorkbook()
        WriteExcelForm()
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

    Private Sub WriteExcelForm()
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

            .Range("A2").Value = "Employee Detail Form"
            .Range("A2").Font.Bold = True
            .Range("A2").Font.Size = 14

            .Range("A4").Value = "Code"
            .Range("B4").Value = EmployeeRow.Code
            .Range("A5").Value = "Type"
            Select Case EmployeeRow.EmployeeType
                Case 0
                    .Range("B5").Value = "Server"
                Case 1
                    .Range("B5").Value = "Cashier"
                Case 2
                    .Range("B5").Value = "Manager"
                Case 3
                    .Range("B5").Value = "Administrator"
            End Select
            .Range("A6").Value = "First Name"
            .Range("B6").Value = EmployeeRow.FirstName
            .Range("A7").Value = "Surname"
            .Range("B7").Value = EmployeeRow.Surname
            .Range("A8").Value = "Home"
            .Range("B8").Value = "'" & EmployeeRow.HomeTelephone
            .Range("A9").Value = "Cell"
            .Range("B9").Value = "'" & EmployeeRow.CellNumber
            .Range("A10").Value = "Identity No"
            .Range("B10").Value = "'" & EmployeeRow.IDNumber
            .Range("A11").Value = "Tax No"
            .Range("B11").Value = "'" & EmployeeRow.TaxNumber
            .Range("A12").Value = "Gender"
            If EmployeeRow.Gender = "M" Then
                .Range("B12").Value = "Male"
            Else
                .Range("B12").Value = "Female"
            End If
            .Range("A13").Value = "Marital Status"
            Select Case EmployeeRow.MaritalStatus
                Case "M"
                    .Range("B13").Value = "Married"
                Case "D"
                    .Range("B13").Value = "Divorced"
                Case "W"
                    .Range("B13").Value = "Widowed"
                Case Else
                    .Range("B13").Value = "Single"
            End Select
            .Range("A14").Value = "No Of Dependants"
            .Range("B14").Value = EmployeeRow.NoOfDependants
            .Range("A15").Value = "Date Started"
            .Range("B15").Value = "'" & EmployeeRow.DateStarted
            .Range("A16").Value = "Rate"
            .Range("B16").Value = "'R " & Format(EmployeeRow.Rate, "##0.00")

            .Range("A18").Value = "Bank Name"
            .Range("B18").Value = EmployeeRow.BankName
            .Range("A19").Value = "Branch Name"
            .Range("B19").Value = EmployeeRow.BranchName
            .Range("A20").Value = "Branch Number"
            .Range("B20").Value = "'" & EmployeeRow.BranchNumber
            .Range("A21").Value = "Account Number"
            .Range("B21").Value = "'" & EmployeeRow.AccountNumber
            .Range("A22").Value = "Account Type"
            .Range("B22").Value = EmployeeRow.AccountType

            .Range("A24").Value = "Residential Address"
            .Range("B24").Value = EmployeeRow.ResdentialAddress1 & ", " & EmployeeRow.ResdentialAddress2 & ", " & EmployeeRow.ResdentialAddress3 & ", " & EmployeeRow.ResdentialCode
            .Range("A25").Value = "Postal Address"
            .Range("B25").Value = EmployeeRow.PostalAddress1 & ", " & EmployeeRow.PostalAddress2 & ", " & EmployeeRow.PostalAddress3 & ", " & EmployeeRow.PostalCode

            .Range("A27").Value = "Contact Name"
            .Range("B27").Value = EmployeeRow.ContactName
            .Range("A28").Value = "Relationship"
            .Range("B28").Value = EmployeeRow.ContactRelationship
            .Range("A29").Value = "Contact No"
            .Range("B29").Value = "'" & EmployeeRow.ContactPhone

            .Range("A4:A29").Font.Bold = True
            .Range("A4:B29").Font.Size = 12
            .Range("A4:B29").HorizontalAlignment = Excel.Constants.xlLeft
            '.Range("A4:D25").Borders.LineStyle = Excel.Constants.xlSolid

            ' Setup Column Widths

            .Range("A4").ColumnWidth = 20
            .Range("B4").ColumnWidth = 60

        End With
    End Sub

    Private Sub DisplayExcelWorkbook()
        XLWorkSheetSetup()
        With xlApp
            'LineNoString = SpreadsheetLine
            'CellString = "E11:E" & LineNoString
            'xlWorkSheet.Range(CellString).Columns.AutoFit()
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