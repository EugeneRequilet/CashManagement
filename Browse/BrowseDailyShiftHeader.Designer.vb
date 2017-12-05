<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseDailyShiftHeader
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
        Me.SelectButton = New System.Windows.Forms.Button()
        Me.ChangeButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.InsertButton = New System.Windows.Forms.Button()
        Me.DailyShiftHeaderGrid1 = New CashManagement.DailyShiftHeaderGrid()
        Me.DateButton = New System.Windows.Forms.Button()
        Me.lblDateRange = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'SelectButton
        '
        Me.SelectButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SelectButton.Location = New System.Drawing.Point(12, 421)
        Me.SelectButton.Name = "SelectButton"
        Me.SelectButton.Size = New System.Drawing.Size(75, 23)
        Me.SelectButton.TabIndex = 31
        Me.SelectButton.Text = "&Select"
        Me.SelectButton.UseVisualStyleBackColor = True
        '
        'ChangeButton
        '
        Me.ChangeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeButton.Location = New System.Drawing.Point(504, 421)
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
        Me.CloseButton.Location = New System.Drawing.Point(668, 421)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 29
        Me.CloseButton.Text = "Cl&ose"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'DeleteButton
        '
        Me.DeleteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteButton.Location = New System.Drawing.Point(586, 421)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
        Me.DeleteButton.TabIndex = 28
        Me.DeleteButton.Text = "&Delete"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'InsertButton
        '
        Me.InsertButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InsertButton.Location = New System.Drawing.Point(422, 421)
        Me.InsertButton.Name = "InsertButton"
        Me.InsertButton.Size = New System.Drawing.Size(75, 23)
        Me.InsertButton.TabIndex = 27
        Me.InsertButton.Text = "&Insert"
        Me.InsertButton.UseVisualStyleBackColor = True
        '
        'DailyShiftHeaderGrid1
        '
        Me.DailyShiftHeaderGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DailyShiftHeaderGrid1.Location = New System.Drawing.Point(13, 13)
        Me.DailyShiftHeaderGrid1.Name = "DailyShiftHeaderGrid1"
        Me.DailyShiftHeaderGrid1.Size = New System.Drawing.Size(730, 392)
        Me.DailyShiftHeaderGrid1.TabIndex = 0
        '
        'DateButton
        '
        Me.DateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DateButton.Location = New System.Drawing.Point(109, 421)
        Me.DateButton.Name = "DateButton"
        Me.DateButton.Size = New System.Drawing.Size(102, 23)
        Me.DateButton.TabIndex = 33
        Me.DateButton.Text = "Date Range"
        Me.DateButton.UseVisualStyleBackColor = True
        '
        'lblDateRange
        '
        Me.lblDateRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDateRange.AutoSize = True
        Me.lblDateRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateRange.Location = New System.Drawing.Point(214, 426)
        Me.lblDateRange.Name = "lblDateRange"
        Me.lblDateRange.Size = New System.Drawing.Size(75, 13)
        Me.lblDateRange.TabIndex = 32
        Me.lblDateRange.Text = "Date Range"
        '
        'BrowseDailyShiftHeader
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(755, 457)
        Me.Controls.Add(Me.DateButton)
        Me.Controls.Add(Me.lblDateRange)
        Me.Controls.Add(Me.SelectButton)
        Me.Controls.Add(Me.ChangeButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.InsertButton)
        Me.Controls.Add(Me.DailyShiftHeaderGrid1)
        Me.KeyPreview = True
        Me.Name = "BrowseDailyShiftHeader"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Shift"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DailyShiftHeaderGrid1 As CashManagement.DailyShiftHeaderGrid
    Friend WithEvents SelectButton As System.Windows.Forms.Button
    Friend WithEvents ChangeButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.Button
    Friend WithEvents InsertButton As System.Windows.Forms.Button
    Friend WithEvents DateButton As System.Windows.Forms.Button
    Friend WithEvents lblDateRange As System.Windows.Forms.Label
End Class
