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
Partial Public Class AssetViewDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
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
	
	Public ReadOnly Property AssetViews() As System.Data.Linq.Table(Of AssetView)
		Get
			Return Me.GetTable(Of AssetView)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.AssetView")>  _
Partial Public Class AssetView
	
	Private _RecordId As Integer
	
	Private _BranchCode As String
	
	Private _Description As String
	
	Private _SerialNumber As String
	
	Private _PurchaseDate As Date
	
	Private _Quantity As Integer
	
	Private _PurchaseAmount As Decimal
	
	Private _TotalAmount As System.Nullable(Of Decimal)
	
	Private _SaleDate As Date
	
	Private _SaleAmount As Decimal
	
	Private _Memo As String
	
	Private _EmployeeRecordId As Integer
	
	Private _EmployeeName As String
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RecordId", DbType:="Int NOT NULL")>  _
	Public Property RecordId() As Integer
		Get
			Return Me._RecordId
		End Get
		Set
			If ((Me._RecordId = value)  _
						= false) Then
				Me._RecordId = value
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
				Me._BranchCode = value
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
				Me._Description = value
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
				Me._SerialNumber = value
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
				Me._PurchaseDate = value
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
				Me._Quantity = value
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
				Me._PurchaseAmount = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TotalAmount", DbType:="Decimal(24,2)")>  _
	Public Property TotalAmount() As System.Nullable(Of Decimal)
		Get
			Return Me._TotalAmount
		End Get
		Set
			If (Me._TotalAmount.Equals(value) = false) Then
				Me._TotalAmount = value
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
				Me._SaleDate = value
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
				Me._SaleAmount = value
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
				Me._Memo = value
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
				Me._EmployeeRecordId = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_EmployeeName", DbType:="VarChar(51)")>  _
	Public Property EmployeeName() As String
		Get
			Return Me._EmployeeName
		End Get
		Set
			If (String.Equals(Me._EmployeeName, value) = false) Then
				Me._EmployeeName = value
			End If
		End Set
	End Property
End Class
