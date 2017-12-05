Public Class SelectDateFromToForm

    Private Sub SelectDateFromToForm_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        setDropdowns()
    End Sub

    Private Sub setDropdowns()
        cboDateRange.Items.Clear()
        cboDateRange.Items.Add("As Is")
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), Month(Today), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 1), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 2), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 3), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 4), 1), "MMMM yyyy"))
        cboDateRange.Items.Add(Format(DateSerial(Year(Today), (Month(Today) - 5), 1), "MMMM yyyy"))
        cboDateRange.Items.Add("This Year to Date")
        cboDateRange.Items.Add("This Year")
        cboDateRange.Items.Add("Last Year")
        cboDateRange.SelectedIndex = 0
        setDatesFromDropdown()
    End Sub

    Private Sub setDatesFromDropdown()
        Select Case cboDateRange.SelectedIndex
            Case 0
                txtDateFrom.Text = (GlobalDateFrom).ToString
                txtDateTo.Text = (GlobalDateTo).ToString
            Case 1
                txtDateFrom.Text = (DateSerial(Year(Today), Month(Today), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), Month(Today) + 1, 0)).ToString
            Case 2
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 1), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), Month(Today), 0)).ToString
            Case 3
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 2), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), (Month(Today) - 1), 0)).ToString
            Case 4
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 3), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), (Month(Today) - 2), 0)).ToString
            Case 5
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 4), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), (Month(Today) - 3), 0)).ToString
            Case 6
                txtDateFrom.Text = (DateSerial(Year(Today), (Month(Today) - 5), 1)).ToString
                txtDateTo.Text = (DateSerial(Year(Today), (Month(Today) - 4), 0)).ToString
            Case 7
                If Today.Month <= 12 Then
                    txtDateFrom.Text = (DateSerial(Year(Today), 3, 1)).ToString
                    txtDateTo.Text = Today.ToString.ToString
                Else
                    txtDateFrom.Text = (DateSerial((Year(Today) - 1), 3, 1)).ToString
                    txtDateTo.Text = Today.ToString.ToString
                End If
            Case 8
                If Today.Month <= 12 Then
                    txtDateFrom.Text = (DateSerial(Year(Today), 3, 1)).ToString
                    txtDateTo.Text = (DateSerial((Year(Today) + 1), 3, 0)).ToString
                Else
                    txtDateFrom.Text = (DateSerial((Year(Today) - 1), 3, 1)).ToString
                    txtDateTo.Text = (DateSerial(Year(Today), 3, 0)).ToString
                End If
            Case 9
                If Today.Month <= 12 Then
                    txtDateFrom.Text = (DateSerial((Year(Today) - 1), 3, 1)).ToString
                    txtDateTo.Text = (DateSerial(Year(Today), 3, 0)).ToString
                Else
                    txtDateFrom.Text = (DateSerial((Year(Today) - 2), 3, 1)).ToString
                    txtDateTo.Text = (DateSerial((Year(Today) - 1), 3, 0)).ToString
                End If
        End Select
        GlobalDateFrom = CDate(txtDateFrom.Text)
        GlobalDateTo = CDate(txtDateTo.Text)
    End Sub

    Private Sub cboDateRange_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboDateRange.SelectedIndexChanged
        setDatesFromDropdown()
    End Sub

    Private Sub OkButton_Click(sender As Object, e As EventArgs) Handles OkButton.Click
        GlobalDateFrom = CDate(txtDateFrom.Text)
        GlobalDateTo = CDate(txtDateTo.Text)
        Me.Close()
    End Sub

End Class