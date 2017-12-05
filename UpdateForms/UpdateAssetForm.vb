Public Class UpdateAssetForm

    Public RecordId As Integer

    Dim DC As AssetDataContext
    Dim AssetRow As Asset
    Dim BDC As BranchDataContext
    Dim BranchRow As Branch

    Sub New()
        InitializeComponent()
    End Sub
    Sub New(_RecordId As Integer)
        Me.New()
        Me.RecordId = _RecordId
    End Sub

    Private Sub UpdateAssetForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        DC = New AssetDataContext
        BindingSource1.DataSource = From Asset In DC.Assets Where Asset.RecordId = RecordId
        AssetRow = BindingSource1.Current
        If AssetRow Is Nothing Then
            AssetRow = New Asset
            BindingSource1.AddNew()
            AssetRow = BindingSource1.Current
            setDefaults()
            Me.cboBranchCode.Select()
        End If
        setNumericsOnScreens()
        LoadBranches()
    End Sub

    Private Sub setDefaults()
        If AssetRow.PurchaseDate = Nothing OrElse AssetRow.PurchaseDate = Date.MinValue Then AssetRow.PurchaseDate = Today
        If AssetRow.PurchaseAmount = Nothing Then AssetRow.PurchaseAmount = 0.0
        If AssetRow.SaleAmount = Nothing Then AssetRow.SaleAmount = 0.0
        If AssetRow.EmployeeRecordId = Nothing OrElse AssetRow.EmployeeRecordId = 0 Then AssetRow.EmployeeRecordId = GlobalLoginEmployeeRecordId
    End Sub

    Private Sub setNumericsOnScreens()
        If GlobalLoginEmployeeBranchCode <> "" Then
            GlobalBranchLookupBranchCode = GlobalLoginEmployeeBranchCode
            AssetRow.BranchCode = GlobalLoginEmployeeBranchCode
            cboBranchCode.Enabled = False
        End If
        txtQuantity.EditValue = AssetRow.Quantity
        txtPurchaseAmount.EditValue = AssetRow.PurchaseAmount
        txtTotalValue.EditValue = AssetRow.Quantity * AssetRow.PurchaseAmount
        '        txtSaleAmount.EditValue = AssetRow.SaleAmount
    End Sub

    Private Sub LoadBranches()
        Dim CurrentRecordId As Integer
        Dim SelectedIndex As Integer = 0
        Dim SQLString As String = "Select * From Branch Order By Description"
        cboBranchCode.Items.Clear()

        ' Because we want to add a blank branch in the beginning of the pull down menu we have to set up the SelectedIndex below
        cboBranchCode.Items.Add("")
        cboBranchCode.SelectedIndex = SelectedIndex
        SelectedIndex += 1
        '

        Try
            Dim SQL = SQLString
            BDC = New BranchDataContext
            BranchBindingSource.DataSource = BDC.ExecuteQuery(Of Branch)(SQL)
        Catch ex As Exception
            MessageBox.Show("Branch Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Exit Sub
        End Try

        ' Loop through the data to total the appropriate fields

        BranchBindingSource.MoveFirst()
        Do
            Try
                BranchRow = BranchBindingSource.Current
            Catch ex As Exception
                Exit Do
            End Try
            If BranchRow IsNot Nothing Then
                If CurrentRecordId = BranchRow.RecordId Then Exit Do
                CurrentRecordId = BranchRow.RecordId
                cboBranchCode.Items.Add(BranchRow.BranchCode)
                If AssetRow.BranchCode = BranchRow.BranchCode Then
                    cboBranchCode.SelectedIndex = SelectedIndex
                    txtBranchDescription.Text = BranchRow.Description
                End If
                SelectedIndex += 1
            End If
            BranchBindingSource.MoveNext()
        Loop
        '        If txtBranchDescription.Text = "" Then txtBranchDescription.Text = "None Selected"
    End Sub


    Private Sub browseButton_Click(sender As Object, e As EventArgs) Handles browseButton.Click
        txtFileAndLocation.Text = GetFileName(7, 3)            ' 1 *.rtf, 2 *.txt, 3 *.doc *.docx, 4 *.xls *.xlsx, 5 *.csv, 6 *.bmp *.jpg *.gif, 7 *.*
        If txtFileAndLocation.Text Is Nothing Or txtFileAndLocation.Text = "" Then Exit Sub
    End Sub

    Private Function ValidateData() As DialogResult
        If verifyBranchCode() <> DialogResult.OK Then
            MsgBox("The branch selected is faulty, please try again.")
            cboBranchCode.Select()
            Return DialogResult.Cancel
        End If
        If AssetRow.PurchaseDate = Nothing OrElse AssetRow.PurchaseDate = Date.MinValue Then AssetRow.PurchaseDate = Today

        If txtQuantity.EditValue = 0 Then
            MsgBox("You must enter a Quantity.")
            txtQuantity.Select()
            Return DialogResult.Cancel
        End If

        If txtPurchaseAmount.EditValue = 0 Then
            MsgBox("You must enter an Amount.")
            txtPurchaseAmount.Select()
            Return DialogResult.Cancel
        End If

        'Dim Message = String.Format("ValidateData.{0}{0}{1}{0}{2}", vbCrLf, AssetRow.BranchCode, AssetRow.Description)
        'MsgBox(Message)

        Return DialogResult.OK
    End Function

    Private Function verifyBranchCode() As DialogResult
        If cboBranchCode.SelectedItem.ToString() = "" Then
            txtBranchDescription.Text = "None Selected"
            AssetRow.BranchCode = ""
            Return DialogResult.OK
        End If
        BDC = New BranchDataContext
        BranchBindingSource.DataSource = From Branch In BDC.Branches Where Branch.BranchCode = cboBranchCode.SelectedItem.ToString()
        BranchRow = BranchBindingSource.Current
        If BranchRow IsNot Nothing Then
            AssetRow.BranchCode = BranchRow.BranchCode
            txtBranchDescription.Text = BranchRow.Description
            Return DialogResult.OK
        Else
            txtBranchDescription.Text = "Branch Code Error"
            Return DialogResult.Cancel
        End If
    End Function

    'Private Sub setBranchCode()
    '    BDC = New BranchDataContext
    '    BranchBindingSource.DataSource = From Branch In BDC.Branches Where Branch.BranchCode = cboBranchCode.SelectedItem.ToString()
    '    BranchRow = BranchBindingSource.Current
    '    If BranchRow IsNot Nothing Then
    '        AssetRow.BranchCode = BranchRow.BranchCode
    '        txtBranchDescription.Text = BranchRow.Description
    '    Else
    '        ' cboBranchCode.Text = ""
    '        txtBranchDescription.Text = "None Selected"
    '    End If
    'End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("An Asset Record already Exists for:" & vbCrLf &
                            "Branch Code:" & vbTab & vbTab & cboBranchCode.Text & vbCrLf &
                            "Description:" & vbTab & vbTab & txtDescription.Text & vbCrLf &
                            "Please try again.", "Duplicate Key")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        BindingSource1.EndEdit()
        If ValidateData() <> DialogResult.OK Then Return
        If SaveData() <> DialogResult.OK Then Return
        DialogResult = DialogResult.OK
        Me.Close()
    End Sub

    Private Sub txtQuantity_Validated(sender As Object, e As EventArgs) Handles txtQuantity.Validated
        AssetRow.Quantity = txtQuantity.EditValue
        txtTotalValue.EditValue = AssetRow.Quantity * AssetRow.PurchaseAmount
    End Sub

    Private Sub txtPurchaseAmount_Validated(sender As Object, e As EventArgs) Handles txtPurchaseAmount.Validated
        AssetRow.PurchaseAmount = txtPurchaseAmount.EditValue
        txtTotalValue.EditValue = AssetRow.Quantity * AssetRow.PurchaseAmount
    End Sub

    Private Sub OpenFileButton_Click(sender As Object, e As EventArgs) Handles OpenFileButton.Click
        If txtFileAndLocation.Text Is Nothing Or txtFileAndLocation.Text = "" Then Exit Sub
        System.Diagnostics.Process.Start(txtFileAndLocation.Text)
    End Sub

    Private Sub cboBranchCode_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cboBranchCode.SelectionChangeCommitted
        verifyBranchCode()
    End Sub

    Private Sub txtQuantity_Load(sender As Object, e As EventArgs) Handles txtQuantity.Load

    End Sub

    Private Sub txtPurchaseAmount_Load(sender As Object, e As EventArgs) Handles txtPurchaseAmount.Load

    End Sub
End Class