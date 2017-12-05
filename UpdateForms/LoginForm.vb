Public Class EmployeeLoginForm

    Dim DC As EmployeeDataContext
    Dim EmployeeRow As Employee

    Private Sub EmployeeLoginForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        DC = New EmployeeDataContext
    End Sub

    Private Sub CancelButton_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Close()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click, MyBase.Enter
        If CheckEmployee() <> System.Windows.Forms.DialogResult.OK Then
            Return
        Else
            Me.Close()
        End If
    End Sub

    Private Function CheckEmployee() As DialogResult
        ClearGlobals()
        Try
            BindingSource1.DataSource = From Employee In DC.Employees Where Employee.Code = txtEmployeeCode.Text
        Catch ex As Exception
            MessageBox.Show("Fatal Error on Employees: " & ex.Message & vbCrLf & vbCrLf & "Contact Programmer.", "Fatal Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
        EmployeeRow = BindingSource1.Current
        If (EmployeeRow Is Nothing) Then
            MessageBox.Show("Employee Code """ & txtEmployeeCode.Text & """ Does not Exist" & vbCrLf & vbCrLf & "Please try again.", "Employee Code Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return System.Windows.Forms.DialogResult.Cancel
        Else
            If (EmployeeRow.RecordId = 0) Then
                MessageBox.Show("Employee Code """ & txtEmployeeCode.Text & """ Does not Exist" & vbCrLf & vbCrLf & "Please try again.", "Employee Code Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Return System.Windows.Forms.DialogResult.Cancel
            Else
                If EmployeeRow.Password = txtPassword.Text Then
                    If EmployeeRow.InactiveEmployee <> 0 Then
                        MessageBox.Show("This Employee """ & EmployeeRow.FirstName & " " & EmployeeRow.Surname & """ is set as Inactive ." & vbCrLf & vbCrLf & "Please ask your Administrator for help.", "Inactive Employee", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        Return System.Windows.Forms.DialogResult.Cancel
                    End If
                    GlobalLoginEmployeeRecordId = EmployeeRow.RecordId
                    GlobalLoginEmployeeName = EmployeeRow.Description
                    GlobalEmployeeIsType = EmployeeRow.EmployeeType
                    GlobalLoginEmployeeBranchCode = EmployeeRow.BranchCode
                    Return System.Windows.Forms.DialogResult.OK
                Else
                    MessageBox.Show("The Password for """ & EmployeeRow.FirstName & " " & EmployeeRow.Surname & """ is incorrect." & vbCrLf & vbCrLf & "Please try again.", "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Return System.Windows.Forms.DialogResult.Cancel
                End If
            End If
        End If
    End Function

    Private Sub EmployeeLoginForm_FormClosed(sender As Object, e As FormClosedEventArgs) Handles MyBase.FormClosed
        Close()
    End Sub

    Private Sub ClearGlobals()
        GlobalLoginEmployeeRecordId = -1
        GlobalLoginEmployeeName = ""
        GlobalEmployeeIsType = 0
        GlobalLoginEmployeeBranchCode = ""

        GlobalAssetManager = 0
        GlobalAdjustmentLookupRecordId = 0
        GlobalInventoryLookupRecordId = 0
        GlobalDefaultShiftLookupRecordId = 0
        GlobalDailyShiftHeaderLookupRecordId = 0
        GlobalEmployeeLookupRecordId = 0
        GlobalAssetLookupRecordId = 0
        GlobalBranchLookupBranchCode = ""
        GlobalSupplierLookupRecordId = 0
        GlobalUnreconciled = 0
        GlobalBankType = 0
        GlobalFileString = ""
        GlobalFilterString = ""
        GlobalDateFrom = DateSerial(Year(Today), Month(Today), 1)
        GlobalDateTo = DateSerial(Year(Today), Month(Today) + 1, 0)
        GlobalIncludeEmployees = 0
        GlobalShowInactiveEmployees = 0
        GlobalShowInactiveSuppliers = 0
        GlobalShowInactiveInventory = 0
        GlobalEmployeeLeave = 0
        GlobalHideInsertAmendDelete = 0
        GlobalEmployeeClocking = 0
    End Sub

End Class