Public Class UpdateBankingReconForm

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

        'If BankingRow.Reconciled = True Then
        '    BankingRow.Reconciled = False
        'Else
        '    BankingRow.Reconciled = True
        'End If

        Select Case GlobalBankType
            Case 1          ' Cash
                If BankingRow.BankingType = "D" Then BankingRow.Reconciled = True
            Case 2          ' Credit Card
                If BankingRow.BankingType = "C" Then BankingRow.Reconciled = True
        End Select

    End Sub

    Private Sub LoadData()
        DC = New BankingDataContext
         BindingSource1.DataSource = From Banking In DC.Bankings Where Banking.RecordId = RecordId
        BankingRow = BindingSource1.Current
        If BankingRow Is Nothing Then
            MessageBox.Show("Record Not Found" & vbCrLf & vbCrLf & "Please Try Again", "Reconciliation Error")
            Me.Close()
        End If
        setNumericsOnScreens()
    End Sub

    Private Sub setNumericsOnScreens()
        If BankingRow.BankingType = "D" Then
            txtBankingType.Text = "Cash"
        Else
            txtBankingType.Text = "Credit Card"
        End If

        txtAmount.EditValue = BankingRow.Amount
        txtNumber.EditValue = BankingRow.Number
    End Sub

    Private Function ValidateData() As DialogResult
        If ckbReconciled.Checked = True Then
            BankingRow.Reconciled = True
        Else
            ckbReconciled.Checked = False
            BankingRow.Reconciled = False
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
            'MessageBox.Show("UpdateEmployeeForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("A Banking Record already Exists for:" & vbCrLf & _
                            "Date:" & vbTab & vbTab & dteDate.Text & vbCrLf & _
                            "Type: " & vbTab & vbTab & txtBankingType.Text & vbCrLf & _
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

End Class