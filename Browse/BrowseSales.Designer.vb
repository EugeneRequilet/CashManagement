<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseSales
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
        Me.InsertButton = New System.Windows.Forms.Button()
        Me.DeleteButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.ChangeButton = New System.Windows.Forms.Button()
        Me.SalesGrid1 = New CashManagement.SalesGrid()
        Me.ExcelButton = New System.Windows.Forms.Button()
        Me.DateButton = New System.Windows.Forms.Button()
        Me.lblDateRange = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'InsertButton
        '
        Me.InsertButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.InsertButton.Location = New System.Drawing.Point(850, 539)
        Me.InsertButton.Name = "InsertButton"
        Me.InsertButton.Size = New System.Drawing.Size(75, 23)
        Me.InsertButton.TabIndex = 1
        Me.InsertButton.Text = "&Insert"
        Me.InsertButton.UseVisualStyleBackColor = True
        '
        'DeleteButton
        '
        Me.DeleteButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DeleteButton.Location = New System.Drawing.Point(1017, 539)
        Me.DeleteButton.Name = "DeleteButton"
        Me.DeleteButton.Size = New System.Drawing.Size(75, 23)
        Me.DeleteButton.TabIndex = 3
        Me.DeleteButton.Text = "&Delete"
        Me.DeleteButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Location = New System.Drawing.Point(1100, 539)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 4
        Me.CloseButton.Text = "Cl&ose"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'ChangeButton
        '
        Me.ChangeButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ChangeButton.Location = New System.Drawing.Point(934, 539)
        Me.ChangeButton.Name = "ChangeButton"
        Me.ChangeButton.Size = New System.Drawing.Size(75, 23)
        Me.ChangeButton.TabIndex = 5
        Me.ChangeButton.Text = "&Change"
        Me.ChangeButton.UseVisualStyleBackColor = True
        '
        'SalesGrid1
        '
        Me.SalesGrid1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.SalesGrid1.Location = New System.Drawing.Point(11, 12)
        Me.SalesGrid1.Name = "SalesGrid1"
        Me.SalesGrid1.Size = New System.Drawing.Size(1166, 509)
        Me.SalesGrid1.TabIndex = 0
        '
        'ExcelButton
        '
        Me.ExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExcelButton.Location = New System.Drawing.Point(12, 539)
        Me.ExcelButton.Name = "ExcelButton"
        Me.ExcelButton.Size = New System.Drawing.Size(75, 23)
        Me.ExcelButton.TabIndex = 19
        Me.ExcelButton.Text = "&Excel Export"
        Me.ExcelButton.UseVisualStyleBackColor = True
        '
        'DateButton
        '
        Me.DateButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.DateButton.Location = New System.Drawing.Point(107, 539)
        Me.DateButton.Name = "DateButton"
        Me.DateButton.Size = New System.Drawing.Size(102, 23)
        Me.DateButton.TabIndex = 21
        Me.DateButton.Text = "Date Range"
        Me.DateButton.UseVisualStyleBackColor = True
        '
        'lblDateRange
        '
        Me.lblDateRange.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lblDateRange.AutoSize = True
        Me.lblDateRange.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblDateRange.Location = New System.Drawing.Point(212, 544)
        Me.lblDateRange.Name = "lblDateRange"
        Me.lblDateRange.Size = New System.Drawing.Size(75, 13)
        Me.lblDateRange.TabIndex = 20
        Me.lblDateRange.Text = "Date Range"
        '
        'BrowseSales
        '
        Me.AcceptButton = Me.ChangeButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(1189, 576)
        Me.Controls.Add(Me.DateButton)
        Me.Controls.Add(Me.lblDateRange)
        Me.Controls.Add(Me.ExcelButton)
        Me.Controls.Add(Me.ChangeButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.DeleteButton)
        Me.Controls.Add(Me.InsertButton)
        Me.Controls.Add(Me.SalesGrid1)
        Me.KeyPreview = True
        Me.Name = "BrowseSales"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Daily Sales"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents SalesGrid1 As CashManagement.SalesGrid
    Friend WithEvents InsertButton As System.Windows.Forms.Button
    Friend WithEvents DeleteButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents ChangeButton As System.Windows.Forms.Button
    Friend WithEvents ExcelButton As System.Windows.Forms.Button
    Friend WithEvents DateButton As System.Windows.Forms.Button
    Friend WithEvents lblDateRange As System.Windows.Forms.Label
End Class
