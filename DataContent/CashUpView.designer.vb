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
Partial Public Class CashUpViewDataContext
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
	
	Public ReadOnly Property CashupViews() As System.Data.Linq.Table(Of CashupView)
		Get
			Return Me.GetTable(Of CashupView)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.CashupView")>  _
Partial Public Class CashupView
	
	Private _RecordId As Integer
	
	Private _Date As Date
	
	Private _Time As Integer
	
	Private _TimeDesc As String
	
	Private _EmployeeRecordId As Integer
	
	Private _CashInTill As System.Nullable(Of Decimal)
	
	Private _Float As System.Nullable(Of Decimal)
	
	Private _CashInTillLessFloat As System.Nullable(Of Decimal)
	
	Private _DepReducedBy As System.Nullable(Of Decimal)
	
	Private _DepIncreasedBy As System.Nullable(Of Decimal)
	
	Private _CashDeposited As System.Nullable(Of Decimal)
	
	Private _CreditCardDeposited As Decimal
	
	Private _DepositSkims As System.Nullable(Of Decimal)
	
	Private _Payouts As System.Nullable(Of Decimal)
	
	Private _Variance As Decimal
	
	Private _SalesType As Integer
	
	Private _SalesTypeDesc As String
	
	Private _PaymentType As Integer
	
	Private _PaymentTypeDesc As String
	
	Private _PayoutReason1 As String
	
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Time", DbType:="Int NOT NULL")>  _
	Public Property Time() As Integer
		Get
			Return Me._Time
		End Get
		Set
			If ((Me._Time = value)  _
						= false) Then
				Me._Time = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_TimeDesc", DbType:="VarChar(7) NOT NULL", CanBeNull:=false)>  _
	Public Property TimeDesc() As String
		Get
			Return Me._TimeDesc
		End Get
		Set
			If (String.Equals(Me._TimeDesc, value) = false) Then
				Me._TimeDesc = value
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CashInTill", DbType:="Decimal(13,2)")>  _
	Public Property CashInTill() As System.Nullable(Of Decimal)
		Get
			Return Me._CashInTill
		End Get
		Set
			If (Me._CashInTill.Equals(value) = false) Then
				Me._CashInTill = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Float", DbType:="Decimal(13,2)")>  _
	Public Property Float() As System.Nullable(Of Decimal)
		Get
			Return Me._Float
		End Get
		Set
			If (Me._Float.Equals(value) = false) Then
				Me._Float = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CashInTillLessFloat", DbType:="Decimal(14,2)")>  _
	Public Property CashInTillLessFloat() As System.Nullable(Of Decimal)
		Get
			Return Me._CashInTillLessFloat
		End Get
		Set
			If (Me._CashInTillLessFloat.Equals(value) = false) Then
				Me._CashInTillLessFloat = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DepReducedBy", DbType:="Decimal(13,2)")>  _
	Public Property DepReducedBy() As System.Nullable(Of Decimal)
		Get
			Return Me._DepReducedBy
		End Get
		Set
			If (Me._DepReducedBy.Equals(value) = false) Then
				Me._DepReducedBy = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DepIncreasedBy", DbType:="Decimal(13,2)")>  _
	Public Property DepIncreasedBy() As System.Nullable(Of Decimal)
		Get
			Return Me._DepIncreasedBy
		End Get
		Set
			If (Me._DepIncreasedBy.Equals(value) = false) Then
				Me._DepIncreasedBy = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CashDeposited", DbType:="Decimal(16,2)")>  _
	Public Property CashDeposited() As System.Nullable(Of Decimal)
		Get
			Return Me._CashDeposited
		End Get
		Set
			If (Me._CashDeposited.Equals(value) = false) Then
				Me._CashDeposited = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CreditCardDeposited", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property CreditCardDeposited() As Decimal
		Get
			Return Me._CreditCardDeposited
		End Get
		Set
			If ((Me._CreditCardDeposited = value)  _
						= false) Then
				Me._CreditCardDeposited = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DepositSkims", DbType:="Decimal(13,2)")>  _
	Public Property DepositSkims() As System.Nullable(Of Decimal)
		Get
			Return Me._DepositSkims
		End Get
		Set
			If (Me._DepositSkims.Equals(value) = false) Then
				Me._DepositSkims = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Payouts", DbType:="Decimal(13,2)")>  _
	Public Property Payouts() As System.Nullable(Of Decimal)
		Get
			Return Me._Payouts
		End Get
		Set
			If (Me._Payouts.Equals(value) = false) Then
				Me._Payouts = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Variance", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property Variance() As Decimal
		Get
			Return Me._Variance
		End Get
		Set
			If ((Me._Variance = value)  _
						= false) Then
				Me._Variance = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SalesType", DbType:="Int NOT NULL")>  _
	Public Property SalesType() As Integer
		Get
			Return Me._SalesType
		End Get
		Set
			If ((Me._SalesType = value)  _
						= false) Then
				Me._SalesType = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_SalesTypeDesc", DbType:="VarChar(13) NOT NULL", CanBeNull:=false)>  _
	Public Property SalesTypeDesc() As String
		Get
			Return Me._SalesTypeDesc
		End Get
		Set
			If (String.Equals(Me._SalesTypeDesc, value) = false) Then
				Me._SalesTypeDesc = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PaymentType", DbType:="Int NOT NULL")>  _
	Public Property PaymentType() As Integer
		Get
			Return Me._PaymentType
		End Get
		Set
			If ((Me._PaymentType = value)  _
						= false) Then
				Me._PaymentType = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PaymentTypeDesc", DbType:="VarChar(12) NOT NULL", CanBeNull:=false)>  _
	Public Property PaymentTypeDesc() As String
		Get
			Return Me._PaymentTypeDesc
		End Get
		Set
			If (String.Equals(Me._PaymentTypeDesc, value) = false) Then
				Me._PaymentTypeDesc = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_PayoutReason1", DbType:="VarChar(30)")>  _
	Public Property PayoutReason1() As String
		Get
			Return Me._PayoutReason1
		End Get
		Set
			If (String.Equals(Me._PayoutReason1, value) = false) Then
				Me._PayoutReason1 = value
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
