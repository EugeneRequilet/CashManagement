Imports System.Linq

Public Class EmployeeGrid

    Dim DC As EmployeeDataContext

    Public Sub LoadData()
        Try
            Dim SQL = "Select * From EmployeeView where InactiveEmployee <> 1 Order by Code"
            If GlobalShowInactiveEmployees = 1 Then
                SQL = "Select * From EmployeeView Order by Code"
            End If
            DC = New EmployeeDataContext
            BindingSource1.DataSource = DC.ExecuteQuery(Of EmployeeView)(SQL)
        Catch ex As Exception
            MessageBox.Show("EmployeeGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
        End Try
    End Sub

    Public Function SaveData() As DialogResult
        Try
            BindingSource1.EndEdit()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("EmployeeGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function DeleteRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim EmployeeRow As EmployeeView = BindingSource1.Current
            Dim Message = String.Format("Deleting Employee {0}.{1} Are you sure?", EmployeeRow.FirstName, vbCrLf)
            If MessageBox.Show(Message, "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.Cancel Then Return DialogResult.Cancel
            Dim CurrentEmployee As Employee = (From x In DC.Employees Where x.RecordId.Equals(EmployeeRow.RecordId) Select x).FirstOrDefault()
            DC.Employees.DeleteOnSubmit(CurrentEmployee)
            BindingSource1.RemoveCurrent()
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("EmployeeGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Private Sub DataGridView1_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellDoubleClick
        If GlobalHideInsertAmendDelete = False Then
            If GlobalEmployeeIsType < GlobalAdministrator Then
                MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
            Else
                ChangeRow()
            End If
        End If
    End Sub

    Public Function ChangeRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim EmployeeRow As EmployeeView = BindingSource1.Current
            Using frm As New UpdateEmployeeForm(EmployeeRow.RecordId)
                If frm.ShowDialog() = DialogResult.OK Then LoadData()
            End Using
        Catch ex As Exception
            MessageBox.Show("EmployeeGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

    Public Function SelectRow() As DialogResult
        Try
            BindingSource1.EndEdit()
            If BindingSource1.Position < 0 Then Return DialogResult.OK
            Dim EmployeeRow As EmployeeView = BindingSource1.Current
            Dim CurrentEmployee As Employee = (From x In DC.Employees Where x.RecordId.Equals(EmployeeRow.RecordId) Select x).FirstOrDefault()
            GlobalEmployeeLookupRecordId = EmployeeRow.RecordId
            DC.SubmitChanges()
        Catch ex As Exception
            MessageBox.Show("InventoryGrid Exception Error: " & vbCrLf & ex.Message, "Reporting Error")
            Return DialogResult.Cancel
        End Try
        Return DialogResult.OK
    End Function

End Class
