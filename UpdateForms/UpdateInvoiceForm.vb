Public Class UpdateInvoiceForm

    Public RecordId As Integer

    Dim IDC As InvoiceDataContext
    Dim InvoiceRow As Invoice
    Dim SDC As SupplierDataContext
    Dim SupplierRow As Supplier
    Dim InsertMode As Boolean = False

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
        IDC = New InvoiceDataContext
        InvoiceBindingSource.DataSource = From Invoice In IDC.Invoices Where Invoice.RecordId = RecordId
        InvoiceRow = InvoiceBindingSource.Current
        If InvoiceRow Is Nothing Then
            InvoiceRow = New Invoice
            InvoiceBindingSource.AddNew()
            InvoiceRow = InvoiceBindingSource.Current
            setDefaults()
            Me.cboDocumentType.Select()
            InsertMode = True
        End If
        setDropdowns()
        setNumericsOnScreens()
    End Sub

    Private Sub setDefaults()
        If InvoiceRow.Date = Nothing OrElse InvoiceRow.Date = Date.MinValue Then InvoiceRow.Date = Today
        If InvoiceRow.DocumentType = Nothing Then InvoiceRow.DocumentType = "I"
        If InvoiceRow.PaymentType = Nothing Then InvoiceRow.PaymentType = 0
        If InvoiceRow.Amount = Nothing Then InvoiceRow.Amount = 0.0
        If InvoiceRow.SupplierRecordId = Nothing OrElse InvoiceRow.SupplierRecordId = 0 Then InvoiceRow.SupplierRecordId = GlobalSupplierLookupRecordId
        If InvoiceRow.EmployeeRecordId = Nothing OrElse InvoiceRow.EmployeeRecordId = 0 Then InvoiceRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
    End Sub

    Private Sub setDropdowns()
        LoadSupplier()

        cboDocumentType.Items.Clear()
        cboDocumentType.Items.Add("Invoice")
        cboDocumentType.Items.Add("Credit Note")
        cboDocumentType.Items.Add("Payment")
        cboDocumentType.Items.Add("Invoice and Payment")
        cboDocumentType.SelectedIndex = 0
        Select Case InvoiceRow.DocumentType
            Case "B"
                cboDocumentType.SelectedIndex = 3
            Case "P"
                cboDocumentType.SelectedIndex = 2
            Case "C"
                cboDocumentType.SelectedIndex = 1
            Case Else
                cboDocumentType.SelectedIndex = 0
        End Select

        cboPaymentType.Items.Clear()
        cboPaymentType.Items.Add("Bank")
        cboPaymentType.Items.Add("Cash")
        cboPaymentType.Items.Add("Card")
        cboPaymentType.SelectedIndex = InvoiceRow.PaymentType
        If cboPaymentType.SelectedIndex > 2 Then
            cboPaymentType.SelectedIndex = 0
            InvoiceRow.PaymentType = 0
        End If
    End Sub

    Private Sub LoadSupplier()
        Dim CurrentRecordId As Integer
        Dim SelectedIndex As Integer = 0
        Dim SQLString As String = "Select * From Supplier Order By Description"
        cboSupplier.Items.Clear()
        Try
            Dim SQL = SQLString
            SDC = New SupplierDataContext
            SupplierBindingSource.DataSource = SDC.ExecuteQuery(Of Supplier)(SQL)
        Catch ex As Exception
            MessageBox.Show("Supplier Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        SupplierBindingSource.MoveFirst()
        Do
            Try
                SupplierRow = SupplierBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If SupplierRow IsNot Nothing Then
                If CurrentRecordId = SupplierRow.RecordId Then Exit Do
                CurrentRecordId = SupplierRow.RecordId
                cboSupplier.Items.Add(SupplierRow.Description)
                If InvoiceRow.SupplierRecordId = SupplierRow.RecordId Then cboSupplier.SelectedIndex = SelectedIndex
                SelectedIndex += 1
            End If
            SupplierBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub setNumericsOnScreens()
        If InsertMode = False And GlobalEmployeeIsType < GlobalAdministrator Then
            dteDate.Enabled = False
            cboSupplier.Enabled = False
        End If
        txtAmount.EditValue = InvoiceRow.Amount
        If cboDocumentType.SelectedIndex >= 2 Then
            cboPaymentType.Visible = True
        Else
            cboPaymentType.Visible = False
        End If
    End Sub

    Private Function ValidateData() As DialogResult
        setSupplierId()
        If InvoiceRow.SupplierRecordId = 0 Then Return DialogResult.Cancel
        Select Case cboDocumentType.SelectedIndex
            Case 0 ' Invoice
                InvoiceRow.DocumentType = "I"
            Case 1 ' Credit Note
                InvoiceRow.DocumentType = "C"
            Case 2 ' Payment
                InvoiceRow.DocumentType = "P"
            Case 3 ' Both Invoice and Payment
                InvoiceRow.DocumentType = "B"
            Case Else
                InvoiceRow.DocumentType = "I"
        End Select

        InvoiceRow.PaymentType = cboPaymentType.SelectedIndex
        If InvoiceRow.PaymentType > 2 Then
            InvoiceRow.PaymentType = 0
            cboPaymentType.SelectedIndex = 0
        End If

        If InvoiceRow.Date = Nothing OrElse InvoiceRow.Date = Date.MinValue Then InvoiceRow.Date = Today
        If InvoiceRow.EmployeeRecordId = Nothing OrElse InvoiceRow.EmployeeRecordId = 0 Then InvoiceRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
        If InvoiceRow.EmployeeRecordId < 1 Then Return DialogResult.Cancel

        'Dim Message = String.Format("ValidateData.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, EmployeeRow.Gender, EmployeeRow.MaritalStatus, EmployeeRow.DateStarted, EmployeeRow.NoOfDependants, EmployeeRow.Rate)
        'MsgBox(Message)

        Return DialogResult.OK
    End Function

    Private Sub setSupplierId()
        SDC = New SupplierDataContext
        SupplierBindingSource.DataSource = From Supplier In SDC.Suppliers Where Supplier.Description = cboSupplier.SelectedItem.ToString()
        SupplierRow = SupplierBindingSource.Current
        If SupplierRow IsNot Nothing Then
            InvoiceRow.SupplierRecordId = SupplierRow.RecordId
        End If
    End Sub

    Public Function SaveData() As DialogResult
        Try
            InvoiceBindingSource.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            IDC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("A Document already Exists for:" & vbCrLf &
                            "Date:" & vbTab & vbTab & dteDate.Text & vbCrLf &
                            "Document Type:" & vbTab & cboDocumentType.Text & vbCrLf &
                            "Document No:" & vbTab & txtDocumentNumber.Text & vbCrLf & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        InvoiceBindingSource.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtAmount_Validated(sender As Object, e As EventArgs) Handles txtAmount.Validated
        InvoiceRow.Amount = txtAmount.EditValue
    End Sub

    Private Sub cboDocumentType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDocumentType.SelectedIndexChanged
        setNumericsOnScreens()
    End Sub

End Class