Public Class NumericTextBox

    Public Event EditValueChanged()
    Public Shadows Event Validated As EventHandler

    Public Enum FormatTypeEnum
        [Decimal]
        [Float]
        [Integer]
    End Enum

    Public Property FormatType As FormatTypeEnum = FormatTypeEnum.Decimal

    Public Property EditValue As Object
        Get
            If TextBox1.Text Is Nothing OrElse IsDBNull(TextBox1.Text) Then Return 0
            If IsNumeric(TextBox1.Text) = False Then Return 0
            '            Return CDec(TextBox1.Text)
            Select Case FormatType
                Case FormatTypeEnum.Decimal
                    Return CDec(TextBox1.Text)
                Case FormatTypeEnum.Integer
                    Return CInt(TextBox1.Text)
                Case Else
                    Return CDec(TextBox1.Text)
            End Select
        End Get
        Set(value As Object)
            SetFormatText(value)
        End Set
    End Property

    Public Property MaxLength As Integer
        Get
            Return TextBox1.MaxLength
        End Get
        Set(value As Integer)
            TextBox1.MaxLength = value
        End Set
    End Property

    Public Property IsReadOnly As Boolean
        Get
            Return TextBox1.ReadOnly
        End Get
        Set(value As Boolean)
            TextBox1.ReadOnly = value
        End Set
    End Property

    Private Sub TextBox1_Validated(sender As Object, e As EventArgs) Handles TextBox1.Validated
        SetFormatText(TextBox1.Text)
        RaiseEvent Validated(sender, e)
    End Sub

    Public Sub SetFormatText(value As Object)
        If value Is Nothing OrElse IsDBNull(value) Then value = 0
        If IsNumeric(value) = False Then value = 0
        Select Case FormatType
            Case FormatTypeEnum.Decimal
                TextBox1.Text = FormatNumber(value, 2, TriState.True, TriState.False, TriState.True)
            Case FormatTypeEnum.Integer
                TextBox1.Text = CInt(value)
            Case Else
                TextBox1.Text = value
        End Select
    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBox1.TextChanged
        RaiseEvent EditValueChanged()
    End Sub

End Class

