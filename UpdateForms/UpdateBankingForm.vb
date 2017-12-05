Public Class UpdateBankingForm

    Public RecordId As Integer

    Dim DC As BankingDataContext
    Dim BankingRow As Banking

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
        DC = New BankingDataContext
        BindingSource1.DataSource = From Banking In DC.Bankings Where Banking.RecordId = RecordId
        BankingRow = BindingSource1.Current
        If BankingRow Is Nothing Then
            BankingRow = New Banking
            BindingSource1.AddNew()
            BankingRow = BindingSource1.Current
            setDefaults()
            Me.dteDate.Select()
        End If
        setDropdowns()
        setNumericsOnScreens()
    End Sub

    Private Sub setDefaults()
        If BankingRow.Date = Nothing OrElse BankingRow.Date = Date.MinValue Then BankingRow.Date = Today
        If BankingRow.BankingType = Nothing Then BankingRow.BankingType = "D"
        If BankingRow.BankingType = "" Then BankingRow.BankingType = "D"
        If BankingRow.Amount = Nothing Then BankingRow.Amount = 0.0
        If BankingRow.Number Is Nothing Then BankingRow.Number = 0
        If BankingRow.Balance Is Nothing Then BankingRow.Balance = 0.0
        If BankingRow.Reconciled = Nothing Then BankingRow.Reconciled = False
        If BankingRow.EmployeeRecordId = Nothing OrElse BankingRow.EmployeeRecordId = 0 Then BankingRow.EmployeeRecordId = GlobalLoginEmployeeRecordId

        'Dim Message = String.Format("setDefaults.{0}{0}{1}{0}{2}{0}{3}{0}{4}{0}{5}", vbCrLf, EmployeeRow.Gender, EmployeeRow.MaritalStatus, EmployeeRow.DateStarted, EmployeeRow.NoOfDependants, EmployeeRow.Rate)
        'MsgBox(Message)

    End Sub

    Private Sub setDropdowns()
        cboBankingType.Items.Clear()
        cboBankingType.Items.Add("Cash")
        cboBankingType.Items.Add("Credit Card")
        cboBankingType.SelectedIndex = 0
        If BankingRow.BankingType = "C" Then
            cboBankingType.SelectedIndex = 1
        Else
            cboBankingType.SelectedIndex = 0
        End If

    End Sub

    Private Sub setNumericsOnScreens()
        txtAmount.EditValue = BankingRow.Amount
        txtNumber.EditValue = BankingRow.Number
    End Sub

    Private Function ValidateData() As DialogResult
        'BankingRow.Amount = txtAmount.EditValue
        'BankingRow.Number = txtNumber.EditValue

        Select Case cboBankingType.SelectedIndex
            Case 0 ' Cash
                BankingRow.BankingType = "D"
            Case 1 ' Credit Card
                BankingRow.BankingType = "C"
            Case Else
                BankingRow.BankingType = "D"
        End Select

        If BankingRow.Date = Nothing OrElse BankingRow.Date = Date.MinValue Then BankingRow.Date = Today

        If ckbReconciled.Checked = True Then
            BankingRow.Reconciled = True
        Else
            ckbReconciled.Checked = False
            BankingRow.Reconciled = False
        End If

        If txtAmount.EditValue = 0 Then
            MsgBox("You must enter an Amount.")
            txtAmount.Select()
            Return DialogResult.Cancel
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
            MessageBox.Show("A Banking Record already Exists for:" & vbCrLf & _
                            "Date:" & vbTab & vbTab & dteDate.Text & vbCrLf & _
                            "Type: " & vbTab & vbTab & cboBankingType.Text & vbCrLf & _
                            "Amount:" & vbTab & txtAmount.Text & vbCrLf & _
                            "Balance:" & vbTab & BankingRow.Amount.ToString & vbCrLf & _
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

    Private Sub txtAmount_Validated(sender As Object, e As EventArgs) Handles txtAmount.Validated
        BankingRow.Amount = txtAmount.EditValue
    End Sub

    Private Sub txtNumber_Validated(sender As Object, e As EventArgs) Handles txtNumber.Validated
        BankingRow.Number = txtNumber.EditValue
    End Sub

End Class