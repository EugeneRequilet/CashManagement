﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PrintPayoutForm
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
        Me.OpenExcelButton = New System.Windows.Forms.Button()
        Me.ExcelButton = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.cboDateRange = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDateTo = New System.Windows.Forms.DateTimePicker()
        Me.txtDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.CashupBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.EmployeeBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.CashupBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'OpenExcelButton
        '
        Me.OpenExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OpenExcelButton.Location = New System.Drawing.Point(113, 146)
        Me.OpenExcelButton.Name = "OpenExcelButton"
        Me.OpenExcelButton.Size = New System.Drawing.Size(75, 71)
        Me.OpenExcelButton.TabIndex = 31
        Me.OpenExcelButton.Text = "Open an Excel File"
        Me.OpenExcelButton.UseVisualStyleBackColor = True
        '
        'ExcelButton
        '
        Me.ExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExcelButton.Location = New System.Drawing.Point(16, 146)
        Me.ExcelButton.Name = "ExcelButton"
        Me.ExcelButton.Size = New System.Drawing.Size(75, 71)
        Me.ExcelButton.TabIndex = 30
        Me.ExcelButton.Text = "Excel Export for Payouts"
        Me.ExcelButton.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(269, 194)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 32
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboDateRange)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDateTo)
        Me.GroupBox1.Controls.Add(Me.txtDateFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(16, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(328, 114)
        Me.GroupBox1.TabIndex = 38
        Me.GroupBox1.TabStop = False
        '
        'cboDateRange
        '
        Me.cboDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDateRange.FormattingEnabled = True
        Me.cboDateRange.Location = New System.Drawing.Point(109, 19)
        Me.cboDateRange.Name = "cboDateRange"
        Me.cboDateRange.Size = New System.Drawing.Size(200, 21)
        Me.cboDateRange.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(9, 50)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 13)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Date From"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(9, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(65, 13)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Date Range"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(9, 77)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 13)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Date To"
        '
        'txtDateTo
        '
        Me.txtDateTo.Location = New System.Drawing.Point(109, 73)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(200, 20)
        Me.txtDateTo.TabIndex = 5
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Location = New System.Drawing.Point(109, 46)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(200, 20)
        Me.txtDateFrom.TabIndex = 4
        '
        'CashupBindingSource
        '
        Me.CashupBindingSource.DataSource = GetType(CashManagement.CashUp)
        '
        'EmployeeBindingSource
        '
        Me.EmployeeBindingSource.DataSource = GetType(CashManagement.Employee)
        '
        'PrintPayoutForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(361, 229)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.OpenExcelButton)
        Me.Controls.Add(Me.ExcelButton)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "PrintPayoutForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Print Payouts"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CashupBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.EmployeeBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents OpenExcelButton As System.Windows.Forms.Button
    Friend WithEvents ExcelButton As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents CashupBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents EmployeeBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDateRange As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDateFrom As System.Windows.Forms.DateTimePicker
End Class
