<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BrowseRecon
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
        Me.ReconcileBankingButton = New System.Windows.Forms.Button()
        Me.CloseButton = New System.Windows.Forms.Button()
        Me.ReconcileCashupButton = New System.Windows.Forms.Button()
        Me.ckbDisplayReconciledItems = New System.Windows.Forms.CheckBox()
        Me.MyApplicationBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.PrintExcelButton = New System.Windows.Forms.Button()
        Me.CashupReconViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.BankingViewBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.cboBankingType = New System.Windows.Forms.ComboBox()
        Me.BankingReconGrid1 = New CashManagement.BankingReconGrid()
        Me.CashUpReconGrid1 = New CashManagement.CashUpReconGrid()
        CType(Me.MyApplicationBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CashupReconViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankingViewBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ReconcileBankingButton
        '
        Me.ReconcileBankingButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ReconcileBankingButton.Location = New System.Drawing.Point(570, 551)
        Me.ReconcileBankingButton.Name = "ReconcileBankingButton"
        Me.ReconcileBankingButton.Size = New System.Drawing.Size(108, 23)
        Me.ReconcileBankingButton.TabIndex = 9
        Me.ReconcileBankingButton.Text = "Reconcile &Banking"
        Me.ReconcileBankingButton.UseVisualStyleBackColor = True
        '
        'CloseButton
        '
        Me.CloseButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.CloseButton.Location = New System.Drawing.Point(1007, 551)
        Me.CloseButton.Name = "CloseButton"
        Me.CloseButton.Size = New System.Drawing.Size(75, 23)
        Me.CloseButton.TabIndex = 8
        Me.CloseButton.Text = "E&xit"
        Me.CloseButton.UseVisualStyleBackColor = True
        '
        'ReconcileCashupButton
        '
        Me.ReconcileCashupButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ReconcileCashupButton.Location = New System.Drawing.Point(433, 551)
        Me.ReconcileCashupButton.Name = "ReconcileCashupButton"
        Me.ReconcileCashupButton.Size = New System.Drawing.Size(121, 23)
        Me.ReconcileCashupButton.TabIndex = 10
        Me.ReconcileCashupButton.Text = "Reconcile &Cashup"
        Me.ReconcileCashupButton.UseVisualStyleBackColor = True
        '
        'ckbDisplayReconciledItems
        '
        Me.ckbDisplayReconciledItems.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ckbDisplayReconciledItems.AutoSize = True
        Me.ckbDisplayReconciledItems.Location = New System.Drawing.Point(232, 555)
        Me.ckbDisplayReconciledItems.Name = "ckbDisplayReconciledItems"
        Me.ckbDisplayReconciledItems.Size = New System.Drawing.Size(145, 17)
        Me.ckbDisplayReconciledItems.TabIndex = 13
        Me.ckbDisplayReconciledItems.TabStop = False
        Me.ckbDisplayReconciledItems.Text = "Display Reconciled Items"
        Me.ckbDisplayReconciledItems.UseVisualStyleBackColor = True
        '
        'MyApplicationBindingSource
        '
        Me.MyApplicationBindingSource.DataSource = GetType(CashManagement.My.MyApplication)
        '
        'PrintExcelButton
        '
        Me.PrintExcelButton.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PrintExcelButton.Location = New System.Drawing.Point(12, 551)
        Me.PrintExcelButton.Name = "PrintExcelButton"
        Me.PrintExcelButton.Size = New System.Drawing.Size(92, 23)
        Me.PrintExcelButton.TabIndex = 62
        Me.PrintExcelButton.Text = "&Excel Export"
        Me.PrintExcelButton.UseVisualStyleBackColor = True
        '
        'CashupReconViewBindingSource
        '
        Me.CashupReconViewBindingSource.DataSource = GetType(CashManagement.CashupReconView)
        '
        'BankingViewBindingSource
        '
        Me.BankingViewBindingSource.DataSource = GetType(CashManagement.BankingView)
        '
        'cboBankingType
        '
        Me.cboBankingType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.cboBankingType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBankingType.FormattingEnabled = True
        Me.cboBankingType.Location = New System.Drawing.Point(127, 553)
        Me.cboBankingType.Name = "cboBankingType"
        Me.cboBankingType.Size = New System.Drawing.Size(89, 21)
        Me.cboBankingType.TabIndex = 64
        '
        'BankingReconGrid1
        '
        Me.BankingReconGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.BankingReconGrid1.Location = New System.Drawing.Point(565, 1)
        Me.BankingReconGrid1.Name = "BankingReconGrid1"
        Me.BankingReconGrid1.Size = New System.Drawing.Size(513, 532)
        Me.BankingReconGrid1.TabIndex = 11
        '
        'CashUpReconGrid1
        '
        Me.CashUpReconGrid1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CashUpReconGrid1.Location = New System.Drawing.Point(11, 1)
        Me.CashUpReconGrid1.Name = "CashUpReconGrid1"
        Me.CashUpReconGrid1.Size = New System.Drawing.Size(548, 532)
        Me.CashUpReconGrid1.TabIndex = 0
        '
        'BrowseRecon
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.CloseButton
        Me.ClientSize = New System.Drawing.Size(1090, 586)
        Me.Controls.Add(Me.cboBankingType)
        Me.Controls.Add(Me.PrintExcelButton)
        Me.Controls.Add(Me.ckbDisplayReconciledItems)
        Me.Controls.Add(Me.BankingReconGrid1)
        Me.Controls.Add(Me.ReconcileCashupButton)
        Me.Controls.Add(Me.ReconcileBankingButton)
        Me.Controls.Add(Me.CloseButton)
        Me.Controls.Add(Me.CashUpReconGrid1)
        Me.KeyPreview = True
        Me.Name = "BrowseRecon"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Deposit Reconciliation"
        CType(Me.MyApplicationBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CashupReconViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankingViewBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents CashUpReconGrid1 As CashManagement.CashUpReconGrid
    Friend WithEvents BankingReconGrid1 As CashManagement.BankingReconGrid
    Friend WithEvents ReconcileBankingButton As System.Windows.Forms.Button
    Friend WithEvents CloseButton As System.Windows.Forms.Button
    Friend WithEvents ReconcileCashupButton As System.Windows.Forms.Button
    Friend WithEvents ckbDisplayReconciledItems As System.Windows.Forms.CheckBox
    Friend WithEvents MyApplicationBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents PrintExcelButton As System.Windows.Forms.Button
    Friend WithEvents CashupReconViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents BankingViewBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents cboBankingType As System.Windows.Forms.ComboBox
End Class
