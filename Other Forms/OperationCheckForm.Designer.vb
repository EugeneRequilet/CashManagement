<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OperationCheckForm
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
        Me.WeeklyTasksButton = New System.Windows.Forms.Button()
        Me.DailyTasksButton = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.MonthlyTasksButton = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.OtherTasksButton = New System.Windows.Forms.Button()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'WeeklyTasksButton
        '
        Me.WeeklyTasksButton.Location = New System.Drawing.Point(104, 16)
        Me.WeeklyTasksButton.Name = "WeeklyTasksButton"
        Me.WeeklyTasksButton.Size = New System.Drawing.Size(75, 71)
        Me.WeeklyTasksButton.TabIndex = 20
        Me.WeeklyTasksButton.Text = "Weekly Task Check Sheet"
        Me.WeeklyTasksButton.UseVisualStyleBackColor = True
        '
        'DailyTasksButton
        '
        Me.DailyTasksButton.Location = New System.Drawing.Point(12, 16)
        Me.DailyTasksButton.Name = "DailyTasksButton"
        Me.DailyTasksButton.Size = New System.Drawing.Size(75, 71)
        Me.DailyTasksButton.TabIndex = 19
        Me.DailyTasksButton.Text = "Daily Task Check Sheet"
        Me.DailyTasksButton.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(290, 109)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 21
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'MonthlyTasksButton
        '
        Me.MonthlyTasksButton.Location = New System.Drawing.Point(197, 16)
        Me.MonthlyTasksButton.Name = "MonthlyTasksButton"
        Me.MonthlyTasksButton.Size = New System.Drawing.Size(75, 71)
        Me.MonthlyTasksButton.TabIndex = 22
        Me.MonthlyTasksButton.Text = "Monthly Task Check Sheet"
        Me.MonthlyTasksButton.UseVisualStyleBackColor = True
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.TaskView)
        '
        'OtherTasksButton
        '
        Me.OtherTasksButton.Location = New System.Drawing.Point(290, 16)
        Me.OtherTasksButton.Name = "OtherTasksButton"
        Me.OtherTasksButton.Size = New System.Drawing.Size(75, 71)
        Me.OtherTasksButton.TabIndex = 23
        Me.OtherTasksButton.Text = "Other Task Check Sheet"
        Me.OtherTasksButton.UseVisualStyleBackColor = True
        '
        'OperationCheckForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(377, 144)
        Me.Controls.Add(Me.OtherTasksButton)
        Me.Controls.Add(Me.MonthlyTasksButton)
        Me.Controls.Add(Me.WeeklyTasksButton)
        Me.Controls.Add(Me.DailyTasksButton)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "OperationCheckForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Operation Checks"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents WeeklyTasksButton As System.Windows.Forms.Button
    Friend WithEvents DailyTasksButton As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents MonthlyTasksButton As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents OtherTasksButton As System.Windows.Forms.Button
End Class
