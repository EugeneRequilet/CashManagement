﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MonthlyDataSheet
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.cboDateRange = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.txtDateTo = New System.Windows.Forms.DateTimePicker()
        Me.txtDateFrom = New System.Windows.Forms.DateTimePicker()
        Me.OpenExcelButton = New System.Windows.Forms.Button()
        Me.ExportExcelButton = New System.Windows.Forms.Button()
        Me.cmdCancel = New System.Windows.Forms.Button()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.SalesViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.InvoiceBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboVATIndicator = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtAdjustmentAmount = New CashManagement.NumericTextBox()
        Me.SalesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.GroupBox1.SuspendLayout()
        CType(Me.SalesViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.InvoiceBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SalesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cboVATIndicator)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.txtAdjustmentAmount)
        Me.GroupBox1.Controls.Add(Me.cboDateRange)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.txtDateTo)
        Me.GroupBox1.Controls.Add(Me.txtDateFrom)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 12)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(355, 169)
        Me.GroupBox1.TabIndex = 41
        Me.GroupBox1.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(9, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(110, 13)
        Me.Label12.TabIndex = 37
        Me.Label12.Text = "Increase L/Year By %"
        '
        'cboDateRange
        '
        Me.cboDateRange.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboDateRange.FormattingEnabled = True
        Me.cboDateRange.Location = New System.Drawing.Point(139, 19)
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
        Me.txtDateTo.Enabled = False
        Me.txtDateTo.Location = New System.Drawing.Point(139, 73)
        Me.txtDateTo.Name = "txtDateTo"
        Me.txtDateTo.Size = New System.Drawing.Size(200, 20)
        Me.txtDateTo.TabIndex = 5
        '
        'txtDateFrom
        '
        Me.txtDateFrom.Enabled = False
        Me.txtDateFrom.Location = New System.Drawing.Point(139, 46)
        Me.txtDateFrom.Name = "txtDateFrom"
        Me.txtDateFrom.Size = New System.Drawing.Size(200, 20)
        Me.txtDateFrom.TabIndex = 4
        '
        'OpenExcelButton
        '
        Me.OpenExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.OpenExcelButton.Location = New System.Drawing.Point(105, 187)
        Me.OpenExcelButton.Name = "OpenExcelButton"
        Me.OpenExcelButton.Size = New System.Drawing.Size(75, 71)
        Me.OpenExcelButton.TabIndex = 39
        Me.OpenExcelButton.Text = "Open an Excel File"
        Me.OpenExcelButton.UseVisualStyleBackColor = True
        '
        'ExportExcelButton
        '
        Me.ExportExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ExportExcelButton.Location = New System.Drawing.Point(12, 187)
        Me.ExportExcelButton.Name = "ExportExcelButton"
        Me.ExportExcelButton.Size = New System.Drawing.Size(75, 71)
        Me.ExportExcelButton.TabIndex = 38
        Me.ExportExcelButton.Text = "Excel Export for Monthly Data"
        Me.ExportExcelButton.UseVisualStyleBackColor = True
        '
        'cmdCancel
        '
        Me.cmdCancel.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cmdCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.cmdCancel.Location = New System.Drawing.Point(292, 235)
        Me.cmdCancel.Name = "cmdCancel"
        Me.cmdCancel.Size = New System.Drawing.Size(75, 23)
        Me.cmdCancel.TabIndex = 40
        Me.cmdCancel.Text = "&Exit"
        Me.cmdCancel.UseVisualStyleBackColor = True
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'SalesViewBindingSource
        '
        Me.SalesViewBindingSource.DataSource = GetType(CashManagement.SalesView)
        '
        'InvoiceBindingSource
        '
        Me.InvoiceBindingSource.DataSource = GetType(CashManagement.Invoice)
        '
        'cboVATIndicator
        '
        Me.cboVATIndicator.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboVATIndicator.FormattingEnabled = True
        Me.cboVATIndicator.Location = New System.Drawing.Point(139, 130)
        Me.cboVATIndicator.Name = "cboVATIndicator"
        Me.cboVATIndicator.Size = New System.Drawing.Size(200, 21)
        Me.cboVATIndicator.TabIndex = 40
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(9, 133)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(75, 13)
        Me.Label4.TabIndex = 39
        Me.Label4.Text = "VAT Selection"
        '
        'txtAdjustmentAmount
        '
        Me.txtAdjustmentAmount.EditValue = New Decimal(New Integer() {0, 0, 0, 131072})
        Me.txtAdjustmentAmount.FormatType = CashManagement.NumericTextBox.FormatTypeEnum.[Decimal]
        Me.txtAdjustmentAmount.IsReadOnly = False
        Me.txtAdjustmentAmount.Location = New System.Drawing.Point(139, 101)
        Me.txtAdjustmentAmount.MaxLength = 15
        Me.txtAdjustmentAmount.Name = "txtAdjustmentAmount"
        Me.txtAdjustmentAmount.Size = New System.Drawing.Size(90, 20)
        Me.txtAdjustmentAmount.TabIndex = 38
        '
        'SalesBindingSource
        '
        Me.SalesBindingSource.DataSource = GetType(CashManagement.BrowseSales)
        '
        'MonthlyDataSheet
        '
        Me.AcceptButton = Me.ExportExcelButton
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.cmdCancel
        Me.ClientSize = New System.Drawing.Size(379, 270)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.OpenExcelButton)
        Me.Controls.Add(Me.ExportExcelButton)
        Me.Controls.Add(Me.cmdCancel)
        Me.Name = "MonthlyDataSheet"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Monthly Data Excel Sheet"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.SalesViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.InvoiceBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SalesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cboDateRange As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtDateTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents txtDateFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents OpenExcelButton As System.Windows.Forms.Button
    Friend WithEvents ExportExcelButton As System.Windows.Forms.Button
    Friend WithEvents cmdCancel As System.Windows.Forms.Button
    Friend WithEvents FolderBrowserDialog1 As System.Windows.Forms.FolderBrowserDialog
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents SalesViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents InvoiceBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents SalesBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents txtAdjustmentAmount As CashManagement.NumericTextBox
    Friend WithEvents cboVATIndicator As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
End Class
