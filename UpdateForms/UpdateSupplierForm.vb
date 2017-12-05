Public Class UpdateSupplierForm

    Public RecordId As Integer

    Dim DC As SupplierDataContext
    Dim SupplierRow As Supplier

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
        DC = New SupplierDataContext
        BindingSource1.DataSource = From Supplier In DC.Suppliers Where Supplier.RecordId = RecordId
        SupplierRow = BindingSource1.Current
        If SupplierRow Is Nothing Then
            SupplierRow = New Supplier
            BindingSource1.AddNew()
            SupplierRow = BindingSource1.Current
            setDefaults()
            Me.txtDescription.Select()
        End If
    End Sub

    Private Sub setDefaults()
        SupplierRow.InactiveSupplier = False
    End Sub

    Private Function ValidateData() As DialogResult
        If SupplierRow.Description Is Nothing Or SupplierRow.Description = "" Then
            txtDescription.Select()
            MsgBox("You must enter a Description.")
            Return DialogResult.Cancel
        End If

        If ckbInactiveSupplier.Text = "" Then
            ckbInactiveSupplier.Text = False
            SupplierRow.InactiveSupplier = False
        End If
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
            'MessageBox.Show("UpdateSupplierForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("An Supplier already Exists for:" & vbCrLf & _
                            "Description:" & vbTab & txtDescription.Text & vbCrLf & vbCrLf & _
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub PhysicalToPostalButton_Click(sender As Object, e As EventArgs) Handles PhysicalToPostalButton.Click
        SupplierRow.PostalAddress1 = SupplierRow.PhysicalAddress1
        SupplierRow.PostalAddress2 = SupplierRow.PhysicalAddress2
        SupplierRow.PostalAddress3 = SupplierRow.PhysicalAddress3
        SupplierRow.PostalCode = SupplierRow.PhysicalCode
    End Sub

    Private Sub PostalToPhysicalButton_Click(sender As Object, e As EventArgs) Handles PostalToPhysicalButton.Click
        SupplierRow.PhysicalAddress1 = SupplierRow.PostalAddress1
        SupplierRow.PhysicalAddress2 = SupplierRow.PostalAddress2
        SupplierRow.PhysicalAddress3 = SupplierRow.PostalAddress3
        SupplierRow.PhysicalCode = SupplierRow.PostalCode
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

End Class