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
Partial Public Class AdjustmentViewDataContext
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
	
	Public ReadOnly Property AdjustmentViews() As System.Data.Linq.Table(Of AdjustmentView)
		Get
			Return Me.GetTable(Of AdjustmentView)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.AdjustmentView")>  _
Partial Public Class AdjustmentView
	
	Private _RecordId As Integer
	
	Private _Date As Date
	
	Private _InvoiceNumber As String
	
	Private _DocumentTypeDesc As String
	
	Private _Reconciled As Boolean
	
	Private _Amount As Decimal
	
	Private _InvoiceAmount As System.Nullable(Of Decimal)
	
	Private _CreditNoteAmount As System.Nullable(Of Decimal)
	
	Private _Memo As String
	
	Private _SupplierName As String
	
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Name:="Date", Storage:="_Date", DbType:="Date NOT NULL")>  _
	Public Property [Date]() As Date
		Get
			Return Me._Date
		End Get
		Set
			If ((Me._Date = value)  _
						= false) Then
				Me._Date = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_InvoiceNumber", DbType:="VarChar(20) NOT NULL", CanBeNull:=false)>  _
	Public Property InvoiceNumber() As String
		Get
			Return Me._InvoiceNumber
		End Get
		Set
			If (String.Equals(Me._InvoiceNumber, value) = false) Then
				Me._InvoiceNumber = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DocumentTypeDesc", DbType:="VarChar(11) NOT NULL", CanBeNull:=false)>  _
	Public Property DocumentTypeDesc() As String
		Get
			Return Me._DocumentTypeDesc
		End Get
		Set
			If (String.Equals(Me._DocumentTypeDesc, value) = false) Then
				Me._DocumentTypeDesc = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Reconciled", DbType:="Bit NOT NULL")>  _
	Public Property Reconciled() As Boolean
		Get
			Return Me._Reconciled
		End Get
		Set
			If ((Me._Reconciled = value)  _
						= false) Then
				Me._Reconciled = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Amount", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property Amount() As Decimal
		Get
			Return Me._Amount
		End Get
		Set
			If ((Me._Amount = value)  _
						= false) Then
				Me._Amount = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_InvoiceAmount", DbType:="Decimal(13,2)")>  _
	Public Property InvoiceAmount() As System.Nullable(Of Decimal)
		Get
			Return Me._InvoiceAmount
		End Get
		Set
			If (Me._InvoiceAmount.Equals(value) = false) Then
				Me._InvoiceAmount = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CreditNoteAmount", DbType:="Decimal(13,2)")>  _
	Public Property CreditNoteAmount() As System.Nullable(Of Decimal)
		Get
			Return Me._CreditNoteAmount
		End Get
		Set
			If (Me._CreditNoteAmount.Equals(value) = false) Then
				Me._CreditNoteAmount = value
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SupplierName", DbType:="VarChar(30) NOT NULL", CanBeNull:=false)>  _
	Public Property SupplierName() As String
		Get
			Return Me._SupplierName
		End Get
		Set
			If (String.Equals(Me._SupplierName, value) = false) Then
				Me._SupplierName = value
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
