<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadBankingCSV
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtDOSFile = New System.Windows.Forms.TextBox()
        Me.browseButton = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.label100 = New System.Windows.Forms.Label()
        Me.txtRecordsAdded = New System.Windows.Forms.TextBox()
        Me.txtRecordsIgnored = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(20, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Select File On Disk"
        '
        'txtDOSFile
        '
        Me.txtDOSFile.Location = New System.Drawing.Point(120, 20)
        Me.txtDOSFile.Name = "txtDOSFile"
        Me.txtDOSFile.Size = New System.Drawing.Size(702, 20)
        Me.txtDOSFile.TabIndex = 1
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(828, 19)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(27, 23)
        Me.browseButton.TabIndex = 2
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(780, 113)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 4
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'ImportButton
        '
        Me.ImportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImportButton.Location = New System.Drawing.Point(27, 65)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(75, 71)
        Me.ImportButton.TabIndex = 5
        Me.ImportButton.Text = "Import Selected CSV file into Banking"
        Me.ImportButton.UseVisualStyleBackColor = True
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Banking)
        '
        'label100
        '
        Me.label100.AutoSize = True
        Me.label100.Location = New System.Drawing.Point(433, 118)
        Me.label100.Name = "label100"
        Me.label100.Size = New System.Drawing.Size(48, 13)
        Me.label100.TabIndex = 6
        Me.label100.Text = "Imported"
        Me.label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtRecordsAdded
        '
        Me.txtRecordsAdded.Location = New System.Drawing.Point(486, 115)
        Me.txtRecordsAdded.Name = "txtRecordsAdded"
        Me.txtRecordsAdded.ReadOnly = True
        Me.txtRecordsAdded.Size = New System.Drawing.Size(38, 20)
        Me.txtRecordsAdded.TabIndex = 7
        '
        'txtRecordsIgnored
        '
        Me.txtRecordsIgnored.Location = New System.Drawing.Point(385, 115)
        Me.txtRecordsIgnored.Name = "txtRecordsIgnored"
        Me.txtRecordsIgnored.ReadOnly = True
        Me.txtRecordsIgnored.Size = New System.Drawing.Size(38, 20)
        Me.txtRecordsIgnored.TabIndex = 9
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(332, 118)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(43, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "Ignored"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'UploadBankingCSV
        '
        Me.AcceptButton = Me.ImportButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(878, 148)
        Me.Controls.Add(Me.txtRecordsIgnored)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtRecordsAdded)
        Me.Controls.Add(Me.label100)
        Me.Controls.Add(Me.ImportButton)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.txtDOSFile)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UploadBankingCSV"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload Banking from a CSV file"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtDOSFile As System.Windows.Forms.TextBox
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents ImportButton As System.Windows.Forms.Button
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents label100 As System.Windows.Forms.Label
    Friend WithEvents txtRecordsAdded As System.Windows.Forms.TextBox
    Friend WithEvents txtRecordsIgnored As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
