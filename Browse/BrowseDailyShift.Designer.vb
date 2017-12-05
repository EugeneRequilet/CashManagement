<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseDailyShift
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ChangeButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.InsertButton = New System.Windows.Forms.Button()
        Me.HeaderGroupBox = New System.Windows.Forms.GroupBox()
        Me.txtRateAdjustment = New System.Windows.Forms.TextBox()
        Me.DailyShiftHeaderViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.btnBrowseHeaderDate = New System.Windows.Forms.Button()
        Me.txtHeaderDate = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtHeaderMemo = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtHeaderShifts = New CashManagement.NumericTextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.txtHeaderDayOfWeek = New System.Windows.Forms.TextBox()
        Me.CopyShiftButton = New System.Windows.Forms.Button()
        Me.DailyShiftHeaderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DailyShiftViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.DailyShiftBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeeShiftBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.NextButton = New System.Windows.Forms.Button()
        Me.DailyShiftGrid1 = New CashManagement.DailyShiftGrid()
        Me.HeaderGroupBox.SuspendLayout()
        CType(Me.DailyShiftHeaderViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyShiftHeaderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyShiftViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyShiftBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeShiftBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ChangeButton
        '
        Me.ChangeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeButton.Location = New System.Drawing.Point(456, 567)
        Me.ChangeButton.Name = "ChangeButton"
        Me.ChangeButton.Size = New System.Drawing.Size(75, 23)
        Me.ChangeButton.TabIndex = 30
        Me.ChangeButton.Text = "&Change"
        Me.ChangeButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Location = New System.Drawing.Point(620, 567)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 29
        Me.CloseButton.Text = "Cl&ose"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'DeleteButton
        '
        Me.DeleteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteButton.Location = New System.Drawing.Point(538, 567)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
        Me.DeleteButton.TabIndex = 28
        Me.DeleteButton.Text = "&Delete"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'InsertButton
        '
        Me.InsertButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InsertButton.Location = New System.Drawing.Point(374, 567)
        Me.InsertButton.Name = "InsertButton"
        Me.InsertButton.Size = New System.Drawing.Size(75, 23)
        Me.InsertButton.TabIndex = 27
        Me.InsertButton.Text = "&Insert"
        Me.InsertButton.UseVisualStyleBackColor = True
        '
        'HeaderGroupBox
        '
        Me.HeaderGroupBox.Controls.Add(Me.txtRateAdjustment)
        Me.HeaderGroupBox.Controls.Add(Me.btnBrowseHeaderDate)
        Me.HeaderGroupBox.Controls.Add(Me.txtHeaderDate)
        Me.HeaderGroupBox.Controls.Add(Me.Label3)
        Me.HeaderGroupBox.Controls.Add(Me.txtHeaderMemo)
        Me.HeaderGroupBox.Controls.Add(Me.Label4)
        Me.HeaderGroupBox.Controls.Add(Me.txtHeaderShifts)
        Me.HeaderGroupBox.Controls.Add(Me.Label2)
        Me.HeaderGroupBox.Controls.Add(Me.Label12)
        Me.HeaderGroupBox.Controls.Add(Me.txtHeaderDayOfWeek)
        Me.HeaderGroupBox.Location = New System.Drawing.Point(13, 12)
        Me.HeaderGroupBox.Name = "HeaderGroupBox"
        Me.HeaderGroupBox.Size = New System.Drawing.Size(679, 118)
        Me.HeaderGroupBox.TabIndex = 40
        Me.HeaderGroupBox.TabStop = False
        Me.HeaderGroupBox.Text = "Shift Header"
        '
        'txtRateAdjustment
        '
        Me.txtRateAdjustment.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DailyShiftHeaderViewBindingSource, "DayOfWeek", True))
        Me.txtRateAdjustment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtRateAdjustment.Location = New System.Drawing.Point(123, 48)
        Me.txtRateAdjustment.MaxLength = 20
        Me.txtRateAdjustment.Name = "txtRateAdjustment"
        Me.txtRateAdjustment.ReadOnly = True
        Me.txtRateAdjustment.Size = New System.Drawing.Size(123, 20)
        Me.txtRateAdjustment.TabIndex = 41
        '
        'DailyShiftHeaderViewBindingSource
        '
        Me.DailyShiftHeaderViewBindingSource.DataSource = GetType(CashManagement.DailyShiftHeaderView)
        '
        'btnBrowseHeaderDate
        '
        Me.btnBrowseHeaderDate.Location = New System.Drawing.Point(508, 16)
        Me.btnBrowseHeaderDate.Name = "btnBrowseHeaderDate"
        Me.btnBrowseHeaderDate.Size = New System.Drawing.Size(154, 23)
        Me.btnBrowseHeaderDate.TabIndex = 40
        Me.btnBrowseHeaderDate.Text = "Select Date"
        Me.btnBrowseHeaderDate.UseVisualStyleBackColor = True
        '
        'txtHeaderDate
        '
        Me.txtHeaderDate.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DailyShiftHeaderViewBindingSource, "Date", True))
        Me.txtHeaderDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderDate.Location = New System.Drawing.Point(123, 18)
        Me.txtHeaderDate.MaxLength = 30
        Me.txtHeaderDate.Name = "txtHeaderDate"
        Me.txtHeaderDate.ReadOnly = True
        Me.txtHeaderDate.Size = New System.Drawing.Size(123, 20)
        Me.txtHeaderDate.TabIndex = 37
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(16, 22)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(74, 13)
        Me.Label3.TabIndex = 25
        Me.Label3.Text = "Date for Shifts"
        '
        'txtHeaderMemo
        '
        Me.txtHeaderMemo.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DailyShiftHeaderViewBindingSource, "Memo", True))
        Me.txtHeaderMemo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderMemo.Location = New System.Drawing.Point(58, 81)
        Me.txtHeaderMemo.MaxLength = 30
        Me.txtHeaderMemo.Name = "txtHeaderMemo"
        Me.txtHeaderMemo.ReadOnly = True
        Me.txtHeaderMemo.Size = New System.Drawing.Size(604, 20)
        Me.txtHeaderMemo.TabIndex = 36
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(16, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(36, 13)
        Me.Label4.TabIndex = 30
        Me.Label4.Text = "Memo"
        '
        'txtHeaderShifts
        '
        Me.txtHeaderShifts.DataBindings.Add(New System.Windows.Forms.Binding("EditValue", Me.DailyShiftHeaderViewBindingSource, "Shifts", True, System.Windows.Forms.DataSourceUpdateMode.OnValidation, Nothing, "N0"))
        Me.txtHeaderShifts.EditValue = 0
        Me.txtHeaderShifts.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderShifts.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Integer]
        Me.txtHeaderShifts.IsReadOnly = True
        Me.txtHeaderShifts.Location = New System.Drawing.Point(572, 48)
        Me.txtHeaderShifts.MaxLength = 15
        Me.txtHeaderShifts.Name = "txtHeaderShifts"
        Me.txtHeaderShifts.Size = New System.Drawing.Size(90, 20)
        Me.txtHeaderShifts.TabIndex = 35
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(16, 52)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(85, 13)
        Me.Label2.TabIndex = 28
        Me.Label2.Text = "Rate Adjustment"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(508, 52)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(33, 13)
        Me.Label12.TabIndex = 29
        Me.Label12.Text = "Shifts"
        '
        'txtHeaderDayOfWeek
        '
        Me.txtHeaderDayOfWeek.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.DailyShiftHeaderViewBindingSource, "DayOfWeek", True))
        Me.txtHeaderDayOfWeek.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHeaderDayOfWeek.Location = New System.Drawing.Point(252, 19)
        Me.txtHeaderDayOfWeek.MaxLength = 20
        Me.txtHeaderDayOfWeek.Name = "txtHeaderDayOfWeek"
        Me.txtHeaderDayOfWeek.ReadOnly = True
        Me.txtHeaderDayOfWeek.Size = New System.Drawing.Size(123, 20)
        Me.txtHeaderDayOfWeek.TabIndex = 34
        '
        'CopyShiftButton
        '
        Me.CopyShiftButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CopyShiftButton.Location = New System.Drawing.Point(94, 567)
        Me.CopyShiftButton.Name = "CopyShiftButton"
        Me.CopyShiftButton.Size = New System.Drawing.Size(75, 23)
        Me.CopyShiftButton.TabIndex = 41
        Me.CopyShiftButton.Text = "Copy &Shifts"
        Me.CopyShiftButton.UseVisualStyleBackColor = True
        Me.CopyShiftButton.Visible = False
        '
        'DailyShiftHeaderBindingSource
        '
        Me.DailyShiftHeaderBindingSource.DataSource = GetType(CashManagement.DailyShiftHeader)
        '
        'DailyShiftViewBindingSource
        '
        Me.DailyShiftViewBindingSource.DataSource = GetType(CashManagement.DailyShiftView)
        '
        'DailyShiftBindingSource
        '
        Me.DailyShiftBindingSource.DataSource = GetType(CashManagement.DailyShift)
        '
        'NextButton
        '
        Me.NextButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.NextButton.Location = New System.Drawing.Point(13, 567)
        Me.NextButton.Name = "NextButton"
        Me.NextButton.Size = New System.Drawing.Size(75, 23)
        Me.NextButton.TabIndex = 42
        Me.NextButton.Text = "&Next Date"
        Me.NextButton.UseVisualStyleBackColor = True
        Me.NextButton.Visible = False
        '
        'DailyShiftGrid1
        '
        Me.DailyShiftGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DailyShiftGrid1.Location = New System.Drawing.Point(13, 136)
        Me.DailyShiftGrid1.Name = "DailyShiftGrid1"
        Me.DailyShiftGrid1.Size = New System.Drawing.Size(679, 414)
        Me.DailyShiftGrid1.TabIndex = 32
        '
        'BrowseDailyShift
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(707, 602)
        Me.Controls.Add(Me.NextButton)
        Me.Controls.Add(Me.CopyShiftButton)
        Me.Controls.Add(Me.HeaderGroupBox)
        Me.Controls.Add(Me.DailyShiftGrid1)
        Me.Controls.Add(Me.ChangeButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.InsertButton)
        Me.KeyPreview = True
        Me.Name = "BrowseDailyShift"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Shift"
        Me.HeaderGroupBox.ResumeLayout(False)
        Me.HeaderGroupBox.PerformLayout()
        CType(Me.DailyShiftHeaderViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyShiftHeaderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyShiftViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyShiftBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeShiftBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ChangeButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.Button
    Friend WithEvents InsertButton As System.Windows.Forms.Button
    Friend WithEvents DailyShiftGrid1 As CashManagement.DailyShiftGrid
    Friend WithEvents HeaderGroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents btnBrowseHeaderDate As System.Windows.Forms.Button
    Friend WithEvents txtHeaderDate As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtHeaderMemo As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtHeaderShifts As CashManagement.NumericTextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtHeaderDayOfWeek As System.Windows.Forms.TextBox
    Friend WithEvents DailyShiftHeaderViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DailyShiftHeaderBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents DailyShiftViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CopyShiftButton As System.Windows.Forms.Button
    Friend WithEvents DailyShiftBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents EmployeeShiftBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents txtRateAdjustment As System.Windows.Forms.TextBox
    Friend WithEvents NextButton As System.Windows.Forms.Button
End Class
