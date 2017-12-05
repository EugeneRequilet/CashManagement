Public Module ModuleProperties

    Public GlobalFirmDetailRow As FirmDetail
    Public GlobalLoginEmployeeRecordId As Integer
    Public GlobalLoginEmployeeName As String
    Public GlobalEmployeeIsType As Integer
    Public GlobalLoginEmployeeBranchCode As String
    Public GlobalAssetManager As Integer = 0
    Public GlobalServer As Integer = 1
    Public GlobalCashier As Integer = 2
    Public GlobalManager As Integer = 3
    Public GlobalAdministrator As Integer = 4
    Public GlobalAdjustmentLookupRecordId As Integer
    Public GlobalInventoryLookupRecordId As Integer
    Public GlobalDefaultShiftLookupRecordId As Integer
    Public GlobalDailyShiftHeaderLookupRecordId As Integer
    Public GlobalEmployeeLookupRecordId As Integer
    Public GlobalAssetLookupRecordId As Integer
    Public GlobalBranchLookupBranchCode As String
    Public GlobalSupplierLookupRecordId As Integer
    Public GlobalUnreconciled As Byte
    Public GlobalBankType As Byte
    Public GlobalFileString As String = ""
    Public GlobalFilterString As String = ""
    Public GlobalSelectedDate As Date
    Public GlobalDateFrom As Date = DateSerial(Year(Today), Month(Today), 1)
    Public GlobalDateTo As Date = DateSerial(Year(Today), Month(Today) + 1, 0)
    Public GlobalIncludeEmployees As Integer
    Public GlobalShowInactiveEmployees As Integer
    Public GlobalShowInactiveSuppliers As Integer
    Public GlobalShowInactiveInventory As Integer
    Public GlobalEmployeeLeave As Integer
    Public GlobalHideInsertAmendDelete As Boolean
    Public GlobalEmployeeClocking As Boolean = 0
End Module
