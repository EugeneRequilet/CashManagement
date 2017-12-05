Public Class UpdateAdjustmentTransactionForm

    Public RecordId As Integer

    Dim ATDC As AdjustmentTransactionDataContext
    Dim AdjustmentTransactionRow As AdjustmentTransaction
    Dim IDC As InventoryDataContext
    Dim InventoryRow As Inventory
    Dim ADC As AdjustmentDataContext
    Dim AdjustmentRow As AdjustmentRequested
    Dim ATVDC As AdjustmentTransactionViewDataContext
    Dim AdjustmentTransactionViewRow As AdjustmentTransactionView

    Dim LocalGlobalAdjustmentLookupRecordId As Integer

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
        ATDC = New AdjustmentTransactionDataContext
        AdjustmentTransactionBindingSource.DataSource = From AdjustmentTransaction In ATDC.AdjustmentTransactions Where AdjustmentTransaction.RecordId = RecordId
        AdjustmentTransactionRow = AdjustmentTransactionBindingSource.Current
        If AdjustmentTransactionRow Is Nothing Then
            AdjustmentTransactionRow = New AdjustmentTransaction
            AdjustmentTransactionBindingSource.AddNew()
            AdjustmentTransactionRow = AdjustmentTransactionBindingSource.Current
            setDefaults()
            '            Me.dteDate.Select()
        End If
        setNumericsOnScreens()
    End Sub

    Private Sub setDefaults()
        AdjustmentTransactionRow.AdjustmentRequestedRecordId = GlobalAdjustmentLookupRecordId
        If AdjustmentTransactionRow.Quantity = Nothing Then AdjustmentTransactionRow.Quantity = 0
        If AdjustmentTransactionRow.CostPrice = Nothing Then AdjustmentTransactionRow.CostPrice = 0.0
        If AdjustmentTransactionRow.CalcAmount Is Nothing Then AdjustmentTransactionRow.CalcAmount = 0.0
        If AdjustmentTransactionRow.EmployeeRecordId = Nothing OrElse AdjustmentTransactionRow.EmployeeRecordId = 0 Then AdjustmentTransactionRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
    End Sub

    Private Sub setNumericsOnScreens()
        txtQuantity.EditValue = AdjustmentTransactionRow.Quantity
        txtCostPrice.EditValue = AdjustmentTransactionRow.CostPrice
        txtCalcAmount.EditValue = txtQuantity.EditValue * txtCostPrice.EditValue
    End Sub

    Private Sub btnInventoryItem_Click(sender As Object, e As EventArgs) Handles btnInventoryItem.Click
        GlobalInventoryLookupRecordId = -1
        GlobalHideInsertAmendDelete = True
        Using frm As New BrowseInventory
            frm.ShowDialog()
        End Using
        GlobalHideInsertAmendDelete = False
        ReadInventoryRecord()
        Try
            AdjustmentTransactionRow.InventoryDescription = InventoryRow.Description
        Catch ex As Exception
            AdjustmentTransactionRow.InventoryDescription = ""
        End Try
        txtInventoryItem.Text = AdjustmentTransactionRow.InventoryDescription
        AdjustmentTransactionRow.Quantity = 1
        txtQuantity.EditValue = AdjustmentTransactionRow.Quantity
        AdjustmentTransactionRow.CostPrice = InventoryRow.CostPrice
        txtCostPrice.EditValue = AdjustmentTransactionRow.CostPrice
        txtCalcAmount.EditValue = txtQuantity.EditValue * InventoryRow.CostPrice
        'txtQuantity.Select()
    End Sub

    Private Sub ReadInventoryRecord()
        IDC = New InventoryDataContext
        InventoryBindingSource.DataSource = From Inventory In IDC.Inventories Where Inventory.RecordId = GlobalInventoryLookupRecordId
        InventoryRow = InventoryBindingSource.Current
        If InventoryRow Is Nothing Then
            MsgBox("No Inventory Selected")
            Me.Close()
        End If
    End Sub

    Private Function ValidateData() As DialogResult
        If txtInventoryItem.Text = "" Then
            MsgBox("You must Select an Inventory Item.")
            btnInventoryItem.Select()
            Return DialogResult.Cancel
        End If

        If txtQuantity.EditValue = 0 Then
            MsgBox("You must enter an Quantity.")
            txtQuantity.Select()
            Return DialogResult.Cancel
        End If

        If txtCostPrice.EditValue = 0.0 Then
            MsgBox("You must enter an Cost Price.")
            txtCostPrice.Select()
            Return DialogResult.Cancel
        End If
        Return DialogResult.OK
    End Function

    Public Function SaveData() As DialogResult
        Try
            AdjustmentTransactionBindingSource.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            ATDC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("An Adjustment Transaction Record already Exists for:" & vbCrLf & _
                            "Adjustment Id:" & vbTab & vbTab & AdjustmentTransactionRow.AdjustmentRequestedRecordId & vbCrLf & _
                            "Adjustment Trans Id: " & vbTab & AdjustmentTransactionRow.RecordId & vbCrLf & vbCrLf & _
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        AdjustmentTransactionBindingSource.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        DialogResult = DialogResult.OK
        If LocalGlobalAdjustmentLookupRecordId <> 0 And LocalGlobalAdjustmentLookupRecordId <> GlobalAdjustmentLookupRecordId Then
            SetAdjustmentAmount()
            LocalGlobalAdjustmentLookupRecordId = GlobalAdjustmentLookupRecordId
            SetAdjustmentAmount()
        End If
        Me.Close()
    End Sub

    Private Sub txtQuantity_Validated(sender As Object, e As EventArgs) Handles txtQuantity.Validated
        AdjustmentTransactionRow.Quantity = txtQuantity.EditValue
        setNumericsOnScreens()
    End Sub

    Private Sub txtCostPrice_Validated(sender As Object, e As EventArgs) Handles txtCostPrice.Validated
        AdjustmentTransactionRow.CostPrice = txtCostPrice.EditValue
        setNumericsOnScreens()
    End Sub

    Private Sub btnNewAdjustment_Click(sender As Object, e As EventArgs) Handles btnNewAdjustment.Click
        LocalGlobalAdjustmentLookupRecordId = GlobalAdjustmentLookupRecordId
        GlobalAdjustmentLookupRecordId = -1
        Using frm As New BrowseAdjustments
            frm.ShowDialog()
        End Using
        If GlobalAdjustmentLookupRecordId > 0 Then
            AdjustmentTransactionRow.AdjustmentRequestedRecordId = GlobalAdjustmentLookupRecordId
        End If
    End Sub

    Private Sub SetAdjustmentAmount()
        ADC = New AdjustmentDataContext
        AdjustmentBindingSource.DataSource = From AdjustmentRequested In ADC.AdjustmentRequesteds Where AdjustmentRequested.RecordId = LocalGlobalAdjustmentLookupRecordId
        AdjustmentRow = AdjustmentBindingSource.Current
        AdjustmentRow.Amount = 0.0
        ' Calculate the Adjustment Request Header Amount
        Dim CurrentRecordId As Integer
        Dim SQLString As String = "Select * From AdjustmentTransactionView Where AdjustmentRequestedRecordId = " & LocalGlobalAdjustmentLookupRecordId
        Try
            Dim SQL = SQLString
            ATVDC = New AdjustmentTransactionViewDataContext
            AdjustmentTransactionViewBindingSource.DataSource = ATVDC.ExecuteQuery(Of AdjustmentTransactionView)(SQL)
        Catch ex As Exception
            MessageBox.Show("CashupView Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try
        AdjustmentTransactionViewBindingSource.MoveFirst()
        Do
            Try
                AdjustmentTransactionViewRow = AdjustmentTransactionViewBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If AdjustmentTransactionViewRow IsNot Nothing Then
                If CurrentRecordId = AdjustmentTransactionViewRow.RecordId Then Exit Do
                CurrentRecordId = AdjustmentTransactionViewRow.RecordId
                AdjustmentRow.Amount += AdjustmentTransactionViewRow.CalcAmount
            End If
            AdjustmentTransactionViewBindingSource.MoveNext()
        Loop
        AdjustmentBindingSource.EndEdit()
        ADC.SubmitChanges()
    End Sub

End Class