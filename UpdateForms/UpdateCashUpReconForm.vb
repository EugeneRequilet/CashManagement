Public Class UpdateCashUpReconForm

    Public RecordId As Integer

    Dim DC As CashUpDataContext
    Dim CashUpRow As CashUp

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
        DC = New CashUpDataContext
        '       DC.Log = Console.Out
        BindingSource1.DataSource = From Cashup In DC.CashUps Where Cashup.RecordId = RecordId
        CashUpRow = BindingSource1.Current
        If CashUpRow Is Nothing Then
            MessageBox.Show("Record Not Found" & vbCrLf & vbCrLf & "Please Try Again", "Reconciliation Error")
            Me.Close()
        End If
        setAutoReconFields()
        setNumericsOnScreens()
        setHideFields()
    End Sub

    Private Sub setAutoReconFields()
        If CashUpRow.DepositedSkim3 = 0.0 Then
            CashUpRow.Skims3Reconciled = True
        End If
        If CashUpRow.DepositedSkim2 = 0.0 Then
            CashUpRow.Skims2Reconciled = True
        End If
        If CashUpRow.DepositedSkim1 = 0.0 Then
            CashUpRow.Skims1Reconciled = True
        End If
        If (CashUpRow.CalculatedTillTotal - CashUpRow.CalculatedFloatTotal + CashUpRow.CalDepIncreasedByTotal - CashUpRow.CalDepReducedByTotal) = 0.0 Then
            CashUpRow.CashDepReconciled = True
        End If
        If CashUpRow.TotalCreditCard = 0.0 Then
            CashUpRow.CreditCardReconciled = True
        End If

        'If CashUpRow.Skims3Reconciled = True Then
        '    If CashUpRow.Skims2Reconciled = True Then
        '        If CashUpRow.Skims1Reconciled = True Then
        '            If CashUpRow.CashDepReconciled = True Then
        '                If CashUpRow.CreditCardReconciled = False Then
        '                    CashUpRow.CreditCardReconciled = True
        '                End If
        '            Else
        '                CashUpRow.CashDepReconciled = True
        '            End If
        '        Else
        '            CashUpRow.Skims1Reconciled = True
        '        End If
        '    Else
        '        CashUpRow.Skims2Reconciled = True
        '    End If
        'Else
        '    CashUpRow.Skims3Reconciled = True
        'End If

        Select Case GlobalBankType
            Case 1          ' Cash
                If CashUpRow.Skims3Reconciled = True Then
                    If CashUpRow.Skims2Reconciled = True Then
                        If CashUpRow.Skims1Reconciled = True Then
                            If CashUpRow.CashDepReconciled = False Then
                                CashUpRow.CashDepReconciled = True
                            End If
                        Else
                            CashUpRow.Skims1Reconciled = True
                        End If
                    Else
                        CashUpRow.Skims2Reconciled = True
                    End If
                Else
                    CashUpRow.Skims3Reconciled = True
                End If
            Case 2          ' Credit Card
                If CashUpRow.CreditCardReconciled = False Then CashUpRow.CreditCardReconciled = True
        End Select

    End Sub

    Private Sub setNumericsOnScreens()
        txtCreditCardDeposited.EditValue = CashUpRow.TotalCreditCard
        txtCashDeposited.EditValue = (CashUpRow.CalculatedTillTotal - CashUpRow.CalculatedFloatTotal + CashUpRow.CalDepIncreasedByTotal - CashUpRow.CalDepReducedByTotal)
        txtDepositSkim1.EditValue = CashUpRow.DepositedSkim1
        txtDepositSkim2.EditValue = CashUpRow.DepositedSkim2
        txtDepositSkim3.EditValue = CashUpRow.DepositedSkim3
    End Sub

    Private Sub setHideFields()

        ' Hide zero value fields

        If txtCreditCardDeposited.EditValue = 0 Then
            lblCreditCardDeposited.Visible = False
            txtCreditCardDeposited.Visible = False
            chbCreditCardDeposited.Visible = False
        Else
            lblCreditCardDeposited.Visible = True
            txtCreditCardDeposited.Visible = True
            chbCreditCardDeposited.Visible = True
        End If
        If txtCashDeposited.EditValue = 0 Then
            lblCashDeposited.Visible = False
            txtCashDeposited.Visible = False
            chbCashDeposited.Visible = False
        Else
            lblCashDeposited.Visible = True
            txtCashDeposited.Visible = True
            chbCashDeposited.Visible = True
        End If
        If txtDepositSkim1.EditValue = 0 Then
            lblDepositSkim1.Visible = False
            txtDepositSkim1.Visible = False
            chbDepositSkim1.Visible = False
        Else
            lblDepositSkim1.Visible = True
            txtDepositSkim1.Visible = True
            chbDepositSkim1.Visible = True
        End If
        If txtDepositSkim2.EditValue = 0 Then
            lblDepositSkim2.Visible = False
            txtDepositSkim2.Visible = False
            chbDepositSkim2.Visible = False
        Else
            lblDepositSkim2.Visible = True
            txtDepositSkim2.Visible = True
            chbDepositSkim2.Visible = True

        End If
        If txtDepositSkim3.EditValue = 0 Then
            lblDepositSkim3.Visible = False
            txtDepositSkim3.Visible = False
            chbDepositSkim3.Visible = False
        Else
            lblDepositSkim3.Visible = True
            txtDepositSkim3.Visible = True
            chbDepositSkim3.Visible = True
        End If

        ' Hide Others depending on selection from ban recon

        Select Case GlobalBankType
            Case 1  ' Cash Selected
                lblCreditCardDeposited.Visible = False
                txtCreditCardDeposited.Visible = False
                chbCreditCardDeposited.Visible = False
            Case 2  ' Credit Card Selected
                lblCashDeposited.Visible = False
                txtCashDeposited.Visible = False
                chbCashDeposited.Visible = False

                lblDepositSkim1.Visible = False
                txtDepositSkim1.Visible = False
                chbDepositSkim1.Visible = False

                lblDepositSkim2.Visible = False
                txtDepositSkim2.Visible = False
                chbDepositSkim2.Visible = False

                lblDepositSkim3.Visible = False
                txtDepositSkim3.Visible = False
                chbDepositSkim3.Visible = False
        End Select

    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            If (RecordId < 0) Then
                RecordId = 0
            End If
            DC.SubmitChanges()
        Catch ex As Exception
            'MessageBox.Show("UpdateCash-UpForm Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            MessageBox.Show("A Cash-Up Record already Exists for:" & vbCrLf & _
                            "Date: " & vbTab & vbTab & txtCashupDate.Text & vbCrLf & _
                            "Time: " & vbTab & vbTab & CashUpRow.Time & vbCrLf & _
                            "Employee: " & vbTab & CashUpRow.EmployeeRecordId & vbCrLf & vbCrLf & _
                            "Please try again.", "Duplicate Key")

            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub cmdCancel_Click(sender As Object, e As EventArgs) Handles cmdCancel.Click
        Me.Close()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        If SaveData() <> DialogResult.OK Then Return
        Me.Close()
    End Sub

End Class