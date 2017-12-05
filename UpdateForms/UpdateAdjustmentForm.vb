Public Class UpdateAdjustmentForm

    Public RecordId As Integer

    Dim ADC As AdjustmentDataContext
    Dim AdjustmentRow As AdjustmentRequested
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
        ADC = New AdjustmentDataContext
        AdjustmentBindingSource.DataSource = From Adjustment In ADC.AdjustmentRequesteds Where Adjustment.RecordId = RecordId
        AdjustmentRow = AdjustmentBindingSource.Current
        If AdjustmentRow Is Nothing Then
            AdjustmentRow = New AdjustmentRequested
            AdjustmentBindingSource.AddNew()
            AdjustmentRow = AdjustmentBindingSource.Current
            setDefaults()
            Me.cboSupplier.Select()
            InsertMode = True
        End If
        setDropdowns()
        setNumericsOnScreens()
    End Sub

    Private Sub setDefaults()
        If AdjustmentRow.Date = Nothing OrElse AdjustmentRow.Date = Date.MinValue Then AdjustmentRow.Date = Today
        If AdjustmentRow.DocumentType = Nothing Then AdjustmentRow.DocumentType = "I"
        If AdjustmentRow.Amount = Nothing Then AdjustmentRow.Amount = 0.0
        If AdjustmentRow.EmployeeRecordId = Nothing OrElse AdjustmentRow.EmployeeRecordId = 0 Then AdjustmentRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
    End Sub

    Private Sub setDropdowns()
        LoadSupplier()
        cboDocumentType.Items.Clear()
        cboDocumentType.Items.Add("Invoice")
        cboDocumentType.Items.Add("Credit Note")
        cboDocumentType.SelectedIndex = 0
        Select Case AdjustmentRow.DocumentType
            Case "C"
                cboDocumentType.SelectedIndex = 1
            Case Else
                cboDocumentType.SelectedIndex = 0
        End Select
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
                If AdjustmentRow.SupplierRecordId = SupplierRow.RecordId Then cboSupplier.SelectedIndex = SelectedIndex
                SelectedIndex += 1
            End If
            SupplierBindingSource.MoveNext()
        Loop
    End Sub

    Private Sub setNumericsOnScreens()
        If InsertMode = False And GlobalEmployeeIsType < GlobalAdministrator Then
            cboSupplier.Enabled = False
            dteDate.Enabled = False
            txtOriginalInvoiceNumber.Enabled = False
            cboDocumentType.Enabled = False
        End If
        txtAdjustmentAmount.EditValue = AdjustmentRow.Amount
    End Sub

    Private Function ValidateData() As DialogResult
        setSupplierId()
        If AdjustmentRow.SupplierRecordId = 0 Then Return DialogResult.Cancel
        Select Case cboDocumentType.SelectedIndex
            Case 0 ' Adjustment
                AdjustmentRow.DocumentType = "I"
            Case 1 ' Credit Note
                AdjustmentRow.DocumentType = "C"
            Case Else
                AdjustmentRow.DocumentType = "I"
        End Select
        If AdjustmentRow.Date = Nothing OrElse AdjustmentRow.Date = Date.MinValue Then AdjustmentRow.Date = Today
        If AdjustmentRow.EmployeeRecordId = Nothing OrElse AdjustmentRow.EmployeeRecordId = 0 Then AdjustmentRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
        If AdjustmentRow.EmployeeRecordId < 1 Then Return DialogResult.Cancel

        'Dim Message = String.Format("ValidateData.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, EmployeeRow.Gender, EmployeeRow.MaritalStatus, EmployeeRow.DateStarted, EmployeeRow.NoOfDependants, EmployeeRow.Rate)
        'MsgBox(Message)

        Return DialogResult.OK
    End Function

    Private Sub setSupplierId()
        SDC = New SupplierDataContext
        SupplierBindingSource.DataSource = From Supplier In SDC.Suppliers Where Supplier.Description = cboSupplier.SelectedItem.ToString()
        SupplierRow = SupplierBindingSource.Current
        If SupplierRow IsNot Nothing Then
            AdjustmentRow.SupplierRecordId = SupplierRow.RecordId
        End If
    End Sub

    Public Function SaveData() As DialogResult
        Try
            AdjustmentBindingSource.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            ADC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("An Adjustment Record already Exists for:" & vbCrLf &
                            "Date:" & vbTab & vbTab & dteDate.Text & vbCrLf &
                            "Supplier:" & vbTab & vbTab & SupplierRow.Description & vbCrLf &
                            "Original Invoice:" & vbTab & txtOriginalInvoiceNumber.Text & vbCrLf &
                            "Type:" & vbTab & vbTab & cboDocumentType.Text & vbCrLf & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        AdjustmentBindingSource.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        InsertMode = False
        setNumericsOnScreens()
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub txtAmount_Validated(sender As Object, e As EventArgs) Handles txtAdjustmentAmount.Validated
        AdjustmentRow.Amount = txtAdjustmentAmount.EditValue
    End Sub

End Class