<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UpdateDefaultShiftForm
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
        Me.timeEndTime = New System.Windows.Forms.DateTimePicker()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.timeStartTime = New System.Windows.Forms.DateTimePicker()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtDescription = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.OkButton = New System.Windows.Forms.Button()
        Me.DailyShiftViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DailyShiftViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'timeEndTime
        '
        Me.timeEndTime.CustomFormat = "hh:mm tt"
        Me.timeEndTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "EndTime", True))
        Me.timeEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeEndTime.Location = New System.Drawing.Point(107, 79)
        Me.timeEndTime.Name = "timeEndTime"
        Me.timeEndTime.ShowUpDown = True
        Me.timeEndTime.Size = New System.Drawing.Size(97, 20)
        Me.timeEndTime.TabIndex = 22
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.DefaultShift)
        '
        'timeStartTime
        '
        Me.timeStartTime.CustomFormat = "hh:mm tt"
        Me.timeStartTime.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.BindingSource1, "StartTime", True))
        Me.timeStartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.timeStartTime.Location = New System.Drawing.Point(107, 43)
        Me.timeStartTime.MinDate = New Date(2014, 11, 25, 0, 0, 0, 0)
        Me.timeStartTime.Name = "timeStartTime"
        Me.timeStartTime.ShowUpDown = True
        Me.timeStartTime.Size = New System.Drawing.Size(97, 20)
        Me.timeStartTime.TabIndex = 21
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(12, 79)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(52, 13)
        Me.Label3.TabIndex = 20
        Me.Label3.Text = "End Time"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(12, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 18
        Me.Label2.Text = "Start Time"
        '
        'txtDescription
        '
        Me.txtDescription.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.BindingSource1, "Description", True))
        Me.txtDescription.Location = New System.Drawing.Point(107, 12)
        Me.txtDescription.MaxLength = 30
        Me.txtDescription.Name = "txtDescription"
        Me.txtDescription.Size = New System.Drawing.Size(190, 20)
        Me.txtDescription.TabIndex = 19
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Description"
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(229, 152)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 24
        Me.cmdCancel.Text = "&Cancel"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OkButton
        '
        Me.OkButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.OkButton.Location = New System.Drawing.Point(142, 152)
        Me.OkButton.Name = "OkButton"
        Me.OkButton.Size = New System.Drawing.Size(75, 23)
        Me.OkButton.TabIndex = 23
        Me.OkButton.Text = "&Ok"
        Me.OkButton.UseVisualStyleBackColor = True
        '
        'DailyShiftViewBindingSource
        '
        Me.DailyShiftViewBindingSource.DataSource = GetType(CashManagement.DailyShiftView)
        '
        'UpdateDefaultShiftForm
        '
        Me.AcceptButton = Me.OkButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(319, 187)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.OkButton)
        Me.Controls.Add(Me.timeEndTime)
        Me.Controls.Add(Me.timeStartTime)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtDescription)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UpdateDefaultShiftForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Default Shift"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DailyShiftViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents timeEndTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents timeStartTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtDescription As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents OkButton As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents DailyShiftViewBindingSource As System.Windows.Forms.BindingSource
End Class
