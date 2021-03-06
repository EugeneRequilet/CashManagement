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
Partial Public Class ServicedViewDataContext
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
	
	Public ReadOnly Property ServicedViews() As System.Data.Linq.Table(Of ServicedView)
		Get
			Return Me.GetTable(Of ServicedView)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.ServicedView")>  _
Partial Public Class ServicedView
	
	Private _RecordId As Integer
	
	Private _Date As Date
	
	Private _Description As String
	
	Private _Amount As Decimal
	
	Private _AssetRecordId As Integer
	
	Private _EmployeeRecordId As Integer
	
	Private _Memo As String
	
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_AssetRecordId", DbType:="Int NOT NULL")>  _
	Public Property AssetRecordId() As Integer
		Get
			Return Me._AssetRecordId
		End Get
		Set
			If ((Me._AssetRecordId = value)  _
						= false) Then
				Me._AssetRecordId = value
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
