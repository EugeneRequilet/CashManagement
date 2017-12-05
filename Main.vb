Public Class frmCashManagement

    Public RecordId As Integer

    Dim DC As FirmDetailDataContext

    Private Sub frmCashManagement_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadData()
    End Sub

    Private Sub LoadData()
        GlobalHideInsertAmendDelete = False
        SetGlobalFirmDetail()
        If String.IsNullOrWhiteSpace(GlobalFirmDetailRow.FirmName) Then
            GlobalEmployeeIsType = GlobalAdministrator
            UpdateFirmDetails()
            BrowseEmployee()
        Else
            Using frm As New EmployeeLoginForm()
                frm.ShowDialog()
                If GlobalLoginEmployeeRecordId <= 0 Then
                    Close()
                End If
            End Using
        End If
        lblFirmName.Text = GlobalFirmDetailRow.FirmName
        lblEmployeeName.Text = GlobalLoginEmployeeName
    End Sub

    Private Sub ReLoginToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ReLoginToolStripMenuItem.Click
        GlobalFirmDetailRow.FirmName = ""
        LoadData()
    End Sub

    Private Sub ExitToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExitToolStripMenuItem.Click
        Close()
    End Sub

    Private Sub FirmDetailsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FirmDetailsToolStripMenuItem.Click
        UpdateFirmDetails()
    End Sub

    Private Sub EmployeesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeesToolStripMenuItem.Click
        BrowseEmployee()
    End Sub

    Private Sub SuppliersToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SuppliersToolStripMenuItem.Click
        BrowseSupplier()
    End Sub

    Private Sub DefaultShiftsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DefaultShiftsToolStripMenuItem.Click
        BrowseDefaultShift()
    End Sub

    Private Sub BranchesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BranchesToolStripMenuItem.Click
        BrowseBranches()
    End Sub

    Private Sub InventoryToolStripMenuItem2_Click(sender As Object, e As EventArgs) Handles InventoryToolStripMenuItem2.Click
        BrowseInventory()
    End Sub

    Private Sub AssetsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles AssetsToolStripMenuItem.Click
        BrowseAssets()
    End Sub

    Private Sub TasksToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TasksToolStripMenuItem.Click
        BrowseTask()
    End Sub

    Private Sub UploadInventoryCSVFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadInventoryCSVFileToolStripMenuItem.Click
        UploadInventoryCSV()
    End Sub

    Private Sub UploadTaskCSVFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadTaskCSVFileToolStripMenuItem.Click
        UploadTaskCSV()
    End Sub

    Private Sub UploadSalesCSVFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadSalesCSVFileToolStripMenuItem.Click
        UploadSalesCSV()
    End Sub

    Private Sub SalesToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles SalesToolStripMenuItem.Click
        BrowseDailySales()
    End Sub

    Private Sub CashupToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashupToolStripMenuItem.Click
        BrowseCashUp()
    End Sub

    Private Sub UploadBankingCSVFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadBankingCSVFileToolStripMenuItem.Click
        UploadBankingCSV()
    End Sub

    Private Sub BankingToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles BankingToolStripMenuItem1.Click
        BrowseBanking()
    End Sub

    Private Sub DepositReconciliationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DepositReconciliationToolStripMenuItem.Click
        DepositRecon()
    End Sub

    Private Sub SupplierEntryToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        BrowseSupplier()
    End Sub

    Private Sub SupplierTransactionsToolStripMenuItem1_Click(sender As Object, e As EventArgs)
        BrowseInvoice()
    End Sub

    Private Sub AdjustmentsRequestedToolStripMenuItem1_Click(sender As Object, e As EventArgs) Handles AdjustmentsRequestedToolStripMenuItem1.Click
        BrowseAdjustment()
    End Sub

    Private Sub DebtorTransactionsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DebtorTransactionsToolStripMenuItem.Click
        BrowseDebtorTrans()
    End Sub

    Private Sub IncomeExpenditureTransToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles IncomeExpenditureTransToolStripMenuItem.Click
        BrowseIETrans()
    End Sub

    Private Sub MonthlyIncomeExpenditureToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyIncomeExpenditureToolStripMenuItem.Click
        MonthlyIncomeExpenditure()
    End Sub

    Private Sub TransactionsToolStripMenuItem_Click(sender As Object, e As EventArgs)
        BrowseInvoice()
    End Sub

    Private Sub CashupControlSheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashupControlSheetToolStripMenuItem.Click
        CashupControlSheet()
    End Sub

    Private Sub ComparativeControlSheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ComparativeControlSheetToolStripMenuItem.Click
        ComparitiveCashupControlSheet()
    End Sub

    Private Sub MonthlyInfomationSheetToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles MonthlyInfomationSheetToolStripMenuItem.Click
        MonthlyDataSheet()
    End Sub

    Private Sub PayoutReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles PayoutReportToolStripMenuItem.Click
        PayoutReport()
    End Sub

    Private Sub CashierVarianceReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashierVarianceReportToolStripMenuItem.Click
        CashierVarianceReport()
    End Sub

    Private Sub TurnoverDeclarationToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles TurnoverDeclarationToolStripMenuItem.Click
        TurnoverDeclarationReport()
    End Sub

    Private Sub OperationCheckReportsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles OperationCheckReportsToolStripMenuItem.Click
        OperationCheckReports()
    End Sub

    Private Sub CashupReconToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CashupReconToolStripMenuItem.Click
        BrowseDailyRecon()
    End Sub

    Private Sub btnUploadBankingCSV_Click(sender As Object, e As EventArgs) Handles btnUploadBankingCSV.Click
        UploadBankingCSV()
    End Sub

    Private Sub btnFirmDetails_Click(sender As Object, e As EventArgs)
        UpdateFirmDetails()
    End Sub

    Private Sub DefaultShiftButton_Click(sender As Object, e As EventArgs) Handles btnDefaultShifts.Click
        BrowseDefaultShift()
    End Sub

    Private Sub btnBranch_Click(sender As Object, e As EventArgs) Handles btnBranch.Click
        BrowseBranches()
    End Sub

    Private Sub DailyShift_Click(sender As Object, e As EventArgs) Handles btnDailyShifts.Click
        BrowseDailyShift()
    End Sub

    Private Sub btnDailyShiftReport_Click(sender As Object, e As EventArgs) Handles btnDailyShiftReport.Click
        GlobalEmployeeClocking = 0
        DailyShiftReport()
    End Sub

    Private Sub EmployeeShiftButton_Click(sender As Object, e As EventArgs) Handles btnEmployeeShifts.Click
        GlobalEmployeeClocking = 0
        BrowseEmployeeShift()
    End Sub

    Private Sub btnEmployeeShiftReport_Click(sender As Object, e As EventArgs) Handles btnEmployeeShiftReport.Click
        GlobalEmployeeLeave = 0
        EmployeeShiftReport()
    End Sub

    Private Sub btnLeaveTaken_Click(sender As Object, e As EventArgs) Handles btnLeaveTaken.Click
        GlobalEmployeeClocking = 0
        BrowseLeaveTaken()
    End Sub

    Private Sub btnEmployeeLeaveReport_Click(sender As Object, e As EventArgs) Handles btnEmployeeLeaveReport.Click
        GlobalEmployeeLeave = 1
        EmployeeShiftReport()
    End Sub

    Private Sub FirmDetailsButton_Click(sender As Object, e As EventArgs) Handles btnFirmDetails.Click
        UpdateFirmDetails()
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployees.Click
        BrowseEmployee()
    End Sub

    Private Sub btnDailySales_Click(sender As Object, e As EventArgs) Handles btnDailySales.Click
        BrowseDailySales()
    End Sub

    Private Sub CashierFloatCountButton_Click(sender As Object, e As EventArgs) Handles CashierFloatCountButton.Click
        CashierFloatCount()
    End Sub

    Private Sub EmployeeCashupButton_Click(sender As Object, e As EventArgs) Handles EmployeeCashupButton.Click
        BrowseCashUp()
    End Sub

    Private Sub btnUploadInventoryCSV_Click(sender As Object, e As EventArgs)
        UploadInventoryCSV()
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        BrowseInventory()
    End Sub

    Private Sub btnAssets_Click(sender As Object, e As EventArgs) Handles btnAssets.Click
        BrowseAssets()
    End Sub

    Private Sub btnTask_Click(sender As Object, e As EventArgs) Handles btnTask.Click
        BrowseTask()
    End Sub

    Private Sub btnCashupCtlSheet_Click(sender As Object, e As EventArgs) Handles btnCashupCtlSheet.Click
        CashupControlSheet()
    End Sub

    Private Sub btnCompCashupCtlSheet_Click(sender As Object, e As EventArgs) Handles btnCompCashupCtlSheet.Click
        ComparitiveCashupControlSheet()
    End Sub

    Private Sub btnMonthlyInfo_Click(sender As Object, e As EventArgs) Handles btnMonthlyInfo.Click
        MonthlyDataSheet()
    End Sub

    Private Sub btnPayoutReport_Click(sender As Object, e As EventArgs) Handles btnPayoutReport.Click
        PayoutReport()
    End Sub

    Private Sub btnCashierVarianceReport_Click(sender As Object, e As EventArgs) Handles btnCashierVarianceReport.Click
        CashierVarianceReport()
    End Sub

    Private Sub btnTurnoverDeclReport_Click(sender As Object, e As EventArgs) Handles btnTurnoverDeclReport.Click
        TurnoverDeclarationReport()
    End Sub

    Private Sub btnOperationCheckReports_Click(sender As Object, e As EventArgs) Handles btnOperationCheckReports.Click
        OperationCheckReports()
    End Sub

    Private Sub DailyShiftsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyShiftsToolStripMenuItem.Click
        BrowseDailyShift()
    End Sub

    Private Sub DailyShiftReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles DailyShiftReportToolStripMenuItem.Click
        DailyShiftReport()
    End Sub

    Private Sub EmployeeShiftsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeShiftsToolStripMenuItem.Click
        BrowseEmployeeShift()
    End Sub

    Private Sub EmployeeShiftReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeShiftReportToolStripMenuItem.Click
        GlobalEmployeeLeave = 0
        EmployeeShiftReport()
    End Sub

    Private Sub LeaveTakenToolStripMenuItem_Click_1(sender As Object, e As EventArgs) Handles LeaveTakenToolStripMenuItem.Click
        BrowseLeaveTaken()
    End Sub

    Private Sub EmployeeLeaveReportToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles EmployeeLeaveReportToolStripMenuItem.Click
        GlobalEmployeeLeave = 1
        EmployeeShiftReport()
    End Sub

    Private Sub btnBanking_Click(sender As Object, e As EventArgs) Handles btnBanking.Click
        BrowseBanking()
    End Sub

    Private Sub btnReconButton_Click(sender As Object, e As EventArgs) Handles btnReconButton.Click
        BrowseDailyRecon()
    End Sub

    Private Sub btnDepositRecon_Click(sender As Object, e As EventArgs) Handles btnDepositReconciliation.Click
        DepositRecon()
    End Sub

    Private Sub btnSupplier_Click(sender As Object, e As EventArgs) Handles btnSuppliers.Click
        BrowseSupplier()
    End Sub

    Private Sub btnAdjustments_Click(sender As Object, e As EventArgs) Handles btnAdjustments.Click
        BrowseAdjustment()
    End Sub

    Private Sub btnDebtorTrans_Click(sender As Object, e As EventArgs) Handles btnDebtorTrans.Click
        BrowseDebtorTrans()
    End Sub

    Private Sub btnIETrans_Click(sender As Object, e As EventArgs) Handles btnIETrans.Click
        BrowseIETrans()
    End Sub

    Private Sub btnMonthlyIE_Click(sender As Object, e As EventArgs) Handles btnMonthlyIE.Click
        MonthlyIncomeExpenditure()
    End Sub

    Private Sub btnTransactions_Click(sender As Object, e As EventArgs) Handles btnTransactions.Click
        BrowseInvoice()
    End Sub

    Private Sub btnLogging_Click(sender As Object, e As EventArgs) Handles btnLogging.Click
        GlobalEmployeeClocking = 1
        BrowseEmployeeShift()
    End Sub

    Private Sub UpdateFirmDetails()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New UpdateFirmDetailsForm()
                If frm.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then Return
                GlobalFirmDetailRow = frm.FirmDetailRow
                lblFirmName.Text = GlobalFirmDetailRow.FirmName
                lblEmployeeName.Text = GlobalLoginEmployeeName
            End Using
        End If
    End Sub

    Private Sub BrowseEmployee()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseEmployee
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseDefaultShift()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseDefaultShift
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseBranches()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseBranch
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseDailyShift()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not the Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            GlobalDailyShiftHeaderLookupRecordId = -1
            Using frm As New BrowseDailyShift
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub DailyShiftReport()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not the Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New PrintDailyShiftForm
                frm.ShowDialog()
            End Using
        End If
    End Sub


    Private Sub BrowseEmployeeShift()
        GlobalDailyShiftHeaderLookupRecordId = -1
        Using frm As New BrowseDailyEmployeeShift
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub EmployeeShiftReport()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New PrintDailyEmployeeShiftForm()
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseDailySales()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseSales
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub CashierFloatCount()
        Using frm As New CashierFloatCountForm
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub BrowseCashUp()
        Using frm As New BrowseCashUp
            frm.ShowDialog()
        End Using
    End Sub

    Private Sub BrowseBanking()
        If GlobalEmployeeIsType < GlobalManager Then
            MessageBox.Show("You are not a Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseBanking
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub UploadInventoryCSV()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not a Adminstrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New UploadInventoryCSVForm
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub UploadTaskCSV()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not a Adminstrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New UploadTaskCSVForm
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub UploadSalesCSV()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not a Adminstrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New UploadSalesCSVForm
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseInventory()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseInventory
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseLeaveTaken()
        If GlobalEmployeeIsType < GlobalManager Then
            MessageBox.Show("You are not a Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseLeaveTaken
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseAssets()
        If GlobalEmployeeIsType = GlobalAdministrator Or GlobalEmployeeIsType <> GlobalAssetManager Then
            Using frm As New BrowseAsset
                frm.ShowDialog()
            End Using
        Else
            MessageBox.Show("You are not the Administrator or Asset Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        End If
    End Sub

    Private Sub BrowseTask()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not the Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseTask
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub CashupControlSheet()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New CashupControlSheet
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ComparitiveCashupControlSheet()
        If GlobalEmployeeIsType < GlobalManager Then
            MessageBox.Show("You are not a Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New ComparitiveCashupControlSheet
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub MonthlyDataSheet()
        If GlobalEmployeeIsType < GlobalManager Then
            MessageBox.Show("You are not a Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New MonthlyDataSheet
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub PayoutReport()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New PrintPayoutForm
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub CashierVarianceReport()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New PrintCashierVarianceForm
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub TurnoverDeclarationReport()
        If GlobalEmployeeIsType < GlobalManager Then
            MessageBox.Show("You are not a Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New TurnoverDeclarationForm
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub OperationCheckReports()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New OperationCheckForm
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub UploadBankingCSV()
        If GlobalEmployeeIsType < GlobalManager Then
            MessageBox.Show("You are not a Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New UploadBankingCSV
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseDailyRecon()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New DailyReconcForm
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub DepositRecon()
        If GlobalEmployeeIsType < GlobalManager Then
            MessageBox.Show("You are not a Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseRecon
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseSupplier()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseSupplier
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseAdjustment()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            GlobalAdjustmentLookupRecordId = -1
            Using frm As New BrowseAdjustmentTransaction
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseDebtorTrans()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            GlobalAdjustmentLookupRecordId = -1
            Using frm As New BrowseDebtorInvoices
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseIETrans()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not an Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            GlobalAdjustmentLookupRecordId = -1
            Using frm As New PrintIETrans
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub MonthlyIncomeExpenditure()
        If GlobalEmployeeIsType < GlobalAdministrator Then
            MessageBox.Show("You are not an Administrator." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            GlobalAdjustmentLookupRecordId = -1
            Using frm As New PrintMonthlyIncomeExpenditure
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BrowseInvoice()
        If GlobalEmployeeIsType < GlobalCashier Then
            MessageBox.Show("You are not a Cashier." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BrowseInvoice
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub BackupRestoreToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BackupRestoreToolStripMenuItem.Click
        If GlobalEmployeeIsType < GlobalManager Then
            MessageBox.Show("You are not a Manager." & vbCrLf & vbCrLf & "You do not have access to this feature.", "Access Denied")
        Else
            Using frm As New BackupRestoreDatabaseForm
                frm.ShowDialog()
            End Using
        End If
    End Sub

    Private Sub ExitButton_Click(sender As Object, e As EventArgs) Handles ExitButton.Click
        Close()
    End Sub

End Class
