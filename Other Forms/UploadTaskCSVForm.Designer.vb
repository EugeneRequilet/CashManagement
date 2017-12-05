<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadTaskCSVForm
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
        Me.txtRecordsIgnored = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtRecordsAdded = New System.Windows.Forms.TextBox()
        Me.label100 = New System.Windows.Forms.Label()
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.browseButton = New System.Windows.Forms.Button()
        Me.txtDOSFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtRecordsIgnored
        '
        Me.txtRecordsIgnored.Location = New System.Drawing.Point(398, 114)
        Me.txtRecordsIgnored.Name = "txtRecordsIgnored"
        Me.txtRecordsIgnored.ReadOnly = True
        Me.txtRecordsIgnored.Size = New System.Drawing.Size(38, 20)
        Me.txtRecordsIgnored.TabIndex = 25
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(345, 117)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 24
        Me.Label2.Text = "Ignored"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRecordsAdded
        '
        Me.txtRecordsAdded.Location = New System.Drawing.Point(499, 114)
        Me.txtRecordsAdded.Name = "txtRecordsAdded"
        Me.txtRecordsAdded.ReadOnly = True
        Me.txtRecordsAdded.Size = New System.Drawing.Size(38, 20)
        Me.txtRecordsAdded.TabIndex = 23
        '
        'label100
        '
        Me.label100.AutoSize = True
        Me.label100.Location = New System.Drawing.Point(446, 117)
        Me.label100.Name = "label100"
        Me.label100.Size = New System.Drawing.Size(48, 13)
        Me.label100.TabIndex = 22
        Me.label100.Text = "Imported"
        Me.label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ImportButton
        '
        Me.ImportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImportButton.Location = New System.Drawing.Point(30, 64)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(75, 71)
        Me.ImportButton.TabIndex = 21
        Me.ImportButton.Text = "Import Selected CSV file into Inventory"
        Me.ImportButton.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(783, 112)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 20
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(831, 18)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(27, 23)
        Me.browseButton.TabIndex = 19
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'txtDOSFile
        '
        Me.txtDOSFile.Location = New System.Drawing.Point(123, 19)
        Me.txtDOSFile.Name = "txtDOSFile"
        Me.txtDOSFile.Size = New System.Drawing.Size(702, 20)
        Me.txtDOSFile.TabIndex = 18
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 17
        Me.Label1.Text = "Select File On Disk"
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Task)
        '
        'UploadTaskCSVForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 152)
        Me.Controls.Add(Me.txtRecordsIgnored)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRecordsAdded)
        Me.Controls.Add(Me.label100)
        Me.Controls.Add(Me.ImportButton)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.txtDOSFile)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UploadTaskCSVForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload Task CSV"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents txtRecordsIgnored As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRecordsAdded As System.Windows.Forms.TextBox
    Friend WithEvents label100 As System.Windows.Forms.Label
    Friend WithEvents ImportButton As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents txtDOSFile As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
End Class
