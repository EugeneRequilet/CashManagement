<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UploadInventoryCSVForm
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
        Me.ImportButton = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.browseButton = New System.Windows.Forms.Button()
        Me.txtDOSFile = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtAddedRecords = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtChangedRecords = New System.Windows.Forms.TextBox()
        Me.label100 = New System.Windows.Forms.Label()
        Me.BindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboSupplier = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.SupplierViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SupplierViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImportButton
        '
        Me.ImportButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ImportButton.Location = New System.Drawing.Point(30, 90)
        Me.ImportButton.Name = "ImportButton"
        Me.ImportButton.Size = New System.Drawing.Size(75, 71)
        Me.ImportButton.TabIndex = 12
        Me.ImportButton.Text = "Import Selected CSV file into Inventory"
        Me.ImportButton.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(786, 137)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 11
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'browseButton
        '
        Me.browseButton.Location = New System.Drawing.Point(834, 18)
        Me.browseButton.Name = "browseButton"
        Me.browseButton.Size = New System.Drawing.Size(27, 23)
        Me.browseButton.TabIndex = 10
        Me.browseButton.Text = "..."
        Me.browseButton.UseVisualStyleBackColor = True
        '
        'txtDOSFile
        '
        Me.txtDOSFile.Location = New System.Drawing.Point(126, 19)
        Me.txtDOSFile.Name = "txtDOSFile"
        Me.txtDOSFile.Size = New System.Drawing.Size(702, 20)
        Me.txtDOSFile.TabIndex = 9
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(97, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Select File On Disk"
        '
        'txtAddedRecords
        '
        Me.txtAddedRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtAddedRecords.Location = New System.Drawing.Point(398, 140)
        Me.txtAddedRecords.Name = "txtAddedRecords"
        Me.txtAddedRecords.ReadOnly = True
        Me.txtAddedRecords.Size = New System.Drawing.Size(38, 20)
        Me.txtAddedRecords.TabIndex = 16
        '
        'Label2
        '
        Me.Label2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(345, 143)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(38, 13)
        Me.Label2.TabIndex = 15
        Me.Label2.Text = "Added"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtChangedRecords
        '
        Me.txtChangedRecords.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.txtChangedRecords.Location = New System.Drawing.Point(499, 140)
        Me.txtChangedRecords.Name = "txtChangedRecords"
        Me.txtChangedRecords.ReadOnly = True
        Me.txtChangedRecords.Size = New System.Drawing.Size(38, 20)
        Me.txtChangedRecords.TabIndex = 14
        '
        'label100
        '
        Me.label100.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.label100.AutoSize = True
        Me.label100.Location = New System.Drawing.Point(446, 143)
        Me.label100.Name = "label100"
        Me.label100.Size = New System.Drawing.Size(50, 13)
        Me.label100.TabIndex = 13
        Me.label100.Text = "Changed"
        Me.label100.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BindingSource1
        '
        Me.BindingSource1.DataSource = GetType(CashManagement.Inventory)
        '
        'cboSupplier
        '
        Me.cboSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboSupplier.FormattingEnabled = True
        Me.cboSupplier.Location = New System.Drawing.Point(126, 47)
        Me.cboSupplier.Name = "cboSupplier"
        Me.cboSupplier.Size = New System.Drawing.Size(336, 21)
        Me.cboSupplier.TabIndex = 29
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(22, 50)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(98, 13)
        Me.Label3.TabIndex = 28
        Me.Label3.Text = "Allocate to Supplier"
        '
        'SupplierViewBindingSource
        '
        Me.SupplierViewBindingSource.DataSource = GetType(CashManagement.SupplierView)
        '
        'UploadInventoryCSVForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(880, 178)
        Me.Controls.Add(Me.cboSupplier)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.txtAddedRecords)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtChangedRecords)
        Me.Controls.Add(Me.label100)
        Me.Controls.Add(Me.ImportButton)
        Me.Controls.Add(Me.cmdCancel)
        Me.Controls.Add(Me.browseButton)
        Me.Controls.Add(Me.txtDOSFile)
        Me.Controls.Add(Me.Label1)
        Me.Name = "UploadInventoryCSVForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Upload Inventory CSV File"
        CType(Me.BindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SupplierViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents ImportButton As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents browseButton As System.Windows.Forms.Button
    Friend WithEvents txtDOSFile As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents txtAddedRecords As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtChangedRecords As System.Windows.Forms.TextBox
    Friend WithEvents label100 As System.Windows.Forms.Label
    Friend WithEvents BindingSource1 As System.Windows.Forms.BindingSource
    Friend WithEvents cboSupplier As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents SupplierViewBindingSource As BindingSource
End Class
