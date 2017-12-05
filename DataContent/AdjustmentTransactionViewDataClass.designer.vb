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


<Global.System.Data.Linq.Mapping.DatabaseAttribute(Name:="CM")>  _
Partial Public Class AdjustmentTransactionViewDataContext
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
	
	Public ReadOnly Property AdjustmentTransactionViews() As System.Data.Linq.Table(Of AdjustmentTransactionView)
		Get
			Return Me.GetTable(Of AdjustmentTransactionView)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.AdjustmentTransactionView")>  _
Partial Public Class AdjustmentTransactionView
	
	Private _RecordId As Integer
	
	Private _InventoryDescription As String
	
	Private _Quantity As Decimal
	
	Private _CostPrice As Decimal
	
	Private _CalcAmount As System.Nullable(Of Decimal)
	
	Private _Memo As String
	
	Private _AdjustmentRequestedRecordId As Integer
	
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_InventoryDescription", DbType:="VarChar(50)")>  _
	Public Property InventoryDescription() As String
		Get
			Return Me._InventoryDescription
		End Get
		Set
			If (String.Equals(Me._InventoryDescription, value) = false) Then
				Me._InventoryDescription = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Quantity", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property Quantity() As Decimal
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CostPrice", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property CostPrice() As Decimal
		Get
			Return Me._CostPrice
		End Get
		Set
			If ((Me._CostPrice = value)  _
						= false) Then
				Me._CostPrice = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CalcAmount", DbType:="Decimal(13,2)")>  _
	Public Property CalcAmount() As System.Nullable(Of Decimal)
		Get
			Return Me._CalcAmount
		End Get
		Set
			If (Me._CalcAmount.Equals(value) = false) Then
				Me._CalcAmount = value
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_AdjustmentRequestedRecordId", DbType:="Int NOT NULL")>  _
	Public Property AdjustmentRequestedRecordId() As Integer
		Get
			Return Me._AdjustmentRequestedRecordId
		End Get
		Set
			If ((Me._AdjustmentRequestedRecordId = value)  _
						= false) Then
				Me._AdjustmentRequestedRecordId = value
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