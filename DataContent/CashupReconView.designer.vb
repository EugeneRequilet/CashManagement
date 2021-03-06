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
Partial Public Class CashupReconViewDataContext
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
	
	Public ReadOnly Property CashupReconViews() As System.Data.Linq.Table(Of CashupReconView)
		Get
			Return Me.GetTable(Of CashupReconView)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.CashupReconView")>  _
Partial Public Class CashupReconView
	
	Private _RecordId As Integer
	
	Private _Date As Date
	
	Private _CreditCardDeposited As Decimal
	
	Private _CreditCardReconciled As Boolean
	
	Private _CashDeposited As System.Nullable(Of Decimal)
	
	Private _CashDepReconciled As Boolean
	
	Private _DepositedSkim1 As Decimal
	
	Private _Skims1Reconciled As Boolean
	
	Private _DepositedSkim2 As Decimal
	
	Private _Skims2Reconciled As Boolean
	
	Private _DepositedSkim3 As Decimal
	
	Private _Skims3Reconciled As Boolean
	
	Private _PaymentType As Integer
	
	Public Sub New()
		MyBase.New
	End Sub
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_RecordId", AutoSync:=AutoSync.Always, DbType:="Int NOT NULL IDENTITY", IsDbGenerated:=true)>  _
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CreditCardReconciled", DbType:="Bit NOT NULL")>  _
	Public Property CreditCardReconciled() As Boolean
		Get
			Return Me._CreditCardReconciled
		End Get
		Set
			If ((Me._CreditCardReconciled = value)  _
						= false) Then
				Me._CreditCardReconciled = value
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_CashDepReconciled", DbType:="Bit NOT NULL")>  _
	Public Property CashDepReconciled() As Boolean
		Get
			Return Me._CashDepReconciled
		End Get
		Set
			If ((Me._CashDepReconciled = value)  _
						= false) Then
				Me._CashDepReconciled = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DepositedSkim1", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property DepositedSkim1() As Decimal
		Get
			Return Me._DepositedSkim1
		End Get
		Set
			If ((Me._DepositedSkim1 = value)  _
						= false) Then
				Me._DepositedSkim1 = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Skims1Reconciled", DbType:="Bit NOT NULL")>  _
	Public Property Skims1Reconciled() As Boolean
		Get
			Return Me._Skims1Reconciled
		End Get
		Set
			If ((Me._Skims1Reconciled = value)  _
						= false) Then
				Me._Skims1Reconciled = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DepositedSkim2", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property DepositedSkim2() As Decimal
		Get
			Return Me._DepositedSkim2
		End Get
		Set
			If ((Me._DepositedSkim2 = value)  _
						= false) Then
				Me._DepositedSkim2 = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Skims2Reconciled", DbType:="Bit NOT NULL")>  _
	Public Property Skims2Reconciled() As Boolean
		Get
			Return Me._Skims2Reconciled
		End Get
		Set
			If ((Me._Skims2Reconciled = value)  _
						= false) Then
				Me._Skims2Reconciled = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_DepositedSkim3", DbType:="Decimal(13,2) NOT NULL")>  _
	Public Property DepositedSkim3() As Decimal
		Get
			Return Me._DepositedSkim3
		End Get
		Set
			If ((Me._DepositedSkim3 = value)  _
						= false) Then
				Me._DepositedSkim3 = value
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Skims3Reconciled", DbType:="Bit NOT NULL")>  _
	Public Property Skims3Reconciled() As Boolean
		Get
			Return Me._Skims3Reconciled
		End Get
		Set
			If ((Me._Skims3Reconciled = value)  _
						= false) Then
				Me._Skims3Reconciled = value
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
End Class
