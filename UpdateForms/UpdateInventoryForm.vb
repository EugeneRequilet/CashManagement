Public Class UpdateInventoryForm

    Public RecordId As Integer

    Dim DC As InventoryDataContext
    Dim InventoryRow As Inventory
    Dim SVDC As SupplierViewDataContext
    Dim SupplierViewRow As SupplierView

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
        DC = New InventoryDataContext
        BindingSource1.DataSource = From Inventory In DC.Inventories Where Inventory.RecordId = RecordId
        InventoryRow = BindingSource1.Current
        If InventoryRow Is Nothing Then
            InventoryRow = New Inventory
            BindingSource1.AddNew()
            InventoryRow = BindingSource1.Current
            setDefaults()
            Me.txtDescription.Select()
        End If
        GlobalSupplierLookupRecordId = InventoryRow.SupplierId
        If GlobalSupplierLookupRecordId Then ReadSupplierViewRecord()
    End Sub

    Private Sub setDefaults()
        If InventoryRow.CostPrice = Nothing Then InventoryRow.CostPrice = 0.0
        If InventoryRow.SellingPrice = Nothing Then InventoryRow.SellingPrice = 0.0
        If InventoryRow.SupplierId = Nothing Then InventoryRow.SupplierId = 0
        If InventoryRow.Dated = Nothing Then InventoryRow.Dated = DateTime.Now
    End Sub

    Private Function ValidateData() As DialogResult
        If InventoryRow.Description Is Nothing Or InventoryRow.Description = "" Then
            txtDescription.Select()
            MsgBox("You must enter a Description.")
            Return DialogResult.Cancel
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
            If InventoryRow.SupplierId Then
                MessageBox.Show("An Inventory already Exists for:" & vbCrLf &
                                "Description: " & vbTab & vbTab & txtDescription.Text & vbCrLf &
                                "Supplier: " & vbTab & vbTab & txtSupplierName.Text & vbCrLf & vbCrLf &
                                "Please try again.", "Duplicate Key")
            Else
                MessageBox.Show("No Supplier Selected" & vbCrLf & vbCrLf &
                                "Please try again.", "Key Error")
            End If
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

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

    Private Sub txtCostPrice_Validated(sender As Object, e As EventArgs) Handles txtCostPrice.Validated
        InventoryRow.CostPrice = txtCostPrice.EditValue
    End Sub

    Private Sub txtSellingPrice_Validated(sender As Object, e As EventArgs) Handles txtSellingPrice.Validated
        InventoryRow.SellingPrice = txtSellingPrice.EditValue
    End Sub

    Private Sub btnSelectSupplier_Click(sender As Object, e As EventArgs) Handles btnSelectSupplier.Click
        GlobalSupplierLookupRecordId = -1
        GlobalHideInsertAmendDelete = True
        Using frm As New BrowseSupplier
            frm.ShowDialog()
        End Using
        GlobalHideInsertAmendDelete = False
        ReadSupplierViewRecord()
    End Sub

    Private Sub ReadSupplierViewRecord()
        SVDC = New SupplierViewDataContext
        SupplierViewBindingSource.DataSource = From SupplierView In SVDC.SupplierViews Where SupplierView.RecordId = GlobalSupplierLookupRecordId
        SupplierViewRow = SupplierViewBindingSource.Current
        If SupplierViewRow Is Nothing Then
            InventoryRow.SupplierId = 0
            txtSupplierName.Text = ""
            MsgBox("No Supplier Selected")
        Else
            InventoryRow.SupplierId = SupplierViewRow.RecordId
            txtSupplierName.Text = SupplierViewRow.Description
        End If
    End Sub

End Class