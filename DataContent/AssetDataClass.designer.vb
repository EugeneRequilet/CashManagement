﻿'------------------------------------------------------------------------------
' <auto-generated>
'     This code was generated by a tool.
'     Runtime Version:4.0.30319.42000
'
'     Changes to this file may cause incorrect behavior and will be lost if
'     the code is regenerated.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On

Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Data.Linq
Imports System.Data.Linq.Mapping
Imports System.Linq
Imports System.Linq.Expressions
Imports System.Reflection


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="PC")>  _
Partial Public Class AssetDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertAsset(instance As Asset)
    End Sub
  Partial Private Sub UpdateAsset(instance As Asset)
    End Sub
  Partial Private Sub DeleteAsset(instance As Asset)
    End Sub
  #End Region
	
	Public Sub New()
		MyBase.New(Global.CashManagement.My.MySettings.Default.CMConnectionString, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As String, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public Sub New(ByVal connection As System.Data.IDbConnection, ByVal mappingSource As System.Data.Linq.Mapping.MappingSource)
		MyBase.New(connection, mappingSource)
		OnCreated
	End Sub
	
	Public ReadOnly Property Assets() As System.Data.Linq.Table(Of Asset)
		Get
			Return Me.GetTable(Of Asset)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Asset")>  _
Partial Public Class Asset
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _RecordId As Integer
	
	Private _Description As String
	
	Private _SerialNumber As String
	
	Private _PurchaseDate As Date
	
	Private _PurchaseAmount As Decimal
	
	Private _SaleDate As Date
	
	Private _SaleAmount As Decimal
	
	Private _Memo As String
	
	Private _EmployeeRecordId As Integer
	
	Private _BranchCode As String
	
	Private _AttachmentAndLocation As String
	
	Private _Quantity As Integer
	
    #Region "Extensibility Method Definitions"
    Partial Private Sub OnLoaded()
    End Sub
    Partial Private Sub OnValidate(action As System.Data.Linq.ChangeAction)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnRecordIdChanging(value As Integer)
    End Sub
    Partial Private Sub OnRecordIdChanged()
    End Sub
    Partial Private Sub OnDescriptionChanging(value As String)
    End Sub
    Partial Private Sub OnDescriptionChanged()
    End Sub
    Partial Private Sub OnSerialNumberChanging(value As String)
    End Sub
    Partial Private Sub OnSerialNumberChanged()
    End Sub
    Partial Private Sub OnPurchaseDateChanging(value As Date)
    End Sub
    Partial Private Sub OnPurchaseDateChanged()
    End Sub
    Partial Private Sub OnPurchaseAmountChanging(value As Decimal)
    End Sub
    Partial Private Sub OnPurchaseAmountChanged()
    End Sub
    Partial Private Sub OnSaleDateChanging(value As Date)
    End Sub
    Partial Private Sub OnSaleDateChanged()
    End Sub
    Partial Private Sub OnSaleAmountChanging(value As Decimal)
    End Sub
    Partial Private Sub OnSaleAmountChanged()
    End Sub
    Partial Private Sub OnMemoChanging(value As String)
    End Sub
    Partial Private Sub OnMemoChanged()
    End Sub
    Partial Private Sub OnEmployeeRecordIdChanging(value As Integer)
    End Sub
    Partial Private Sub OnEmployeeRecordIdChanged()
    End Sub
    Partial Private Sub OnBranchCodeChanging(value As String)
    End Sub
    Partial Private Sub OnBranchCodeChanged()
    End Sub
    Partial Private Sub OnAttachmentAndLocationChanging(value As String)
    End Sub
    Partial Private Sub OnAttachmentAndLocationChanged()
    End Sub
    Partial Private Sub OnQuantityChanging(value As Integer)
    End Sub
    Partial Private Sub OnQuantityChanged()
    End Sub
    #End Region
	
	Public Sub New()
		MyBase.New
		OnCreated
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RecordId", AutoSync:=AutoSync.OnInsert, DbType:="Int NOT NULL IDENTITY", IsPrimaryKey:=true, IsDbGenerated:=true)>  _
	Public Property RecordId() As Integer
		Get
			Return Me._RecordId
		End Get
		Set
			If ((Me._RecordId = value)  _
						= false) Then
				Me.OnRecordIdChanging(value)
				Me.SendPropertyChanging
				Me._RecordId = value
				Me.SendPropertyChanged("RecordId")
				Me.OnRecordIdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Description", DbType:="VarChar(50) NOT NULL", CanBeNull:=false)>  _
	Public Property Description() As String
		Get
			Return Me._Description
		End Get
		Set
			If (String.Equals(Me._Description, value) = false) Then
				Me.OnDescriptionChanging(value)
				Me.SendPropertyChanging
				Me._Description = value
				Me.SendPropertyChanged("Description")
				Me.OnDescriptionChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SerialNumber", DbType:="VarChar(50)")>  _
	Public Property SerialNumber() As String
		Get
			Return Me._SerialNumber
		End Get
		Set
			If (String.Equals(Me._SerialNumber, value) = false) Then
				Me.OnSerialNumberChanging(value)
				Me.SendPropertyChanging
				Me._SerialNumber = value
				Me.SendPropertyChanged("SerialNumber")
				Me.OnSerialNumberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PurchaseDate", DbType:="Date NOT NULL")>  _
	Public Property PurchaseDate() As Date
		Get
			Return Me._PurchaseDate
		End Get
		Set
			If ((Me._PurchaseDate = value)  _
						= false) Then
				Me.OnPurchaseDateChanging(value)
				Me.SendPropertyChanging
				Me._PurchaseDate = value
				Me.SendPropertyChanged("PurchaseDate")
				Me.OnPurchaseDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PurchaseAmount", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property PurchaseAmount() As Decimal
		Get
			Return Me._PurchaseAmount
		End Get
		Set
			If ((Me._PurchaseAmount = value)  _
						= false) Then
				Me.OnPurchaseAmountChanging(value)
				Me.SendPropertyChanging
				Me._PurchaseAmount = value
				Me.SendPropertyChanged("PurchaseAmount")
				Me.OnPurchaseAmountChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SaleDate", DbType:="Date NOT NULL")>  _
	Public Property SaleDate() As Date
		Get
			Return Me._SaleDate
		End Get
		Set
			If ((Me._SaleDate = value)  _
						= false) Then
				Me.OnSaleDateChanging(value)
				Me.SendPropertyChanging
				Me._SaleDate = value
				Me.SendPropertyChanged("SaleDate")
				Me.OnSaleDateChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SaleAmount", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property SaleAmount() As Decimal
		Get
			Return Me._SaleAmount
		End Get
		Set
			If ((Me._SaleAmount = value)  _
						= false) Then
				Me.OnSaleAmountChanging(value)
				Me.SendPropertyChanging
				Me._SaleAmount = value
				Me.SendPropertyChanged("SaleAmount")
				Me.OnSaleAmountChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Memo", DbType:="VarChar(255)")>  _
	Public Property Memo() As String
		Get
			Return Me._Memo
		End Get
		Set
			If (String.Equals(Me._Memo, value) = false) Then
				Me.OnMemoChanging(value)
				Me.SendPropertyChanging
				Me._Memo = value
				Me.SendPropertyChanged("Memo")
				Me.OnMemoChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_EmployeeRecordId", DbType:="Int NOT NULL")>  _
	Public Property EmployeeRecordId() As Integer
		Get
			Return Me._EmployeeRecordId
		End Get
		Set
			If ((Me._EmployeeRecordId = value)  _
						= false) Then
				Me.OnEmployeeRecordIdChanging(value)
				Me.SendPropertyChanging
				Me._EmployeeRecordId = value
				Me.SendPropertyChanged("EmployeeRecordId")
				Me.OnEmployeeRecordIdChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_BranchCode", DbType:="VarChar(5) NOT NULL", CanBeNull:=false)>  _
	Public Property BranchCode() As String
		Get
			Return Me._BranchCode
		End Get
		Set
			If (String.Equals(Me._BranchCode, value) = false) Then
				Me.OnBranchCodeChanging(value)
				Me.SendPropertyChanging
				Me._BranchCode = value
				Me.SendPropertyChanged("BranchCode")
				Me.OnBranchCodeChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_AttachmentAndLocation", DbType:="VarChar(255)")>  _
	Public Property AttachmentAndLocation() As String
		Get
			Return Me._AttachmentAndLocation
		End Get
		Set
			If (String.Equals(Me._AttachmentAndLocation, value) = false) Then
				Me.OnAttachmentAndLocationChanging(value)
				Me.SendPropertyChanging
				Me._AttachmentAndLocation = value
				Me.SendPropertyChanged("AttachmentAndLocation")
				Me.OnAttachmentAndLocationChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Quantity", DbType:="Int NOT NULL")>  _
	Public Property Quantity() As Integer
		Get
			Return Me._Quantity
		End Get
		Set
			If ((Me._Quantity = value)  _
						= false) Then
				Me.OnQuantityChanging(value)
				Me.SendPropertyChanging
				Me._Quantity = value
				Me.SendPropertyChanged("Quantity")
				Me.OnQuantityChanged
			End If
		End Set
	End Property
	
	Public Event PropertyChanging As PropertyChangingEventHandler Implements System.ComponentModel.INotifyPropertyChanging.PropertyChanging
	
	Public Event PropertyChanged As PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
	
	Protected Overridable Sub SendPropertyChanging()
		If ((Me.PropertyChangingEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanging(Me, emptyChangingEventArgs)
		End If
	End Sub
	
	Protected Overridable Sub SendPropertyChanged(ByVal propertyName As [String])
		If ((Me.PropertyChangedEvent Is Nothing)  _
					= false) Then
			RaiseEvent PropertyChanged(Me, New PropertyChangedEventArgs(propertyName))
		End If
	End Sub
End Class