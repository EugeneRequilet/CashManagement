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
Partial Public Class TaskDataContext
	Inherits System.Data.Linq.DataContext
	
	Private Shared mappingSource As System.Data.Linq.Mapping.MappingSource = New AttributeMappingSource()
	
  #Region "Extensibility Method Definitions"
  Partial Private Sub OnCreated()
  End Sub
  Partial Private Sub InsertTask(instance As Task)
    End Sub
  Partial Private Sub UpdateTask(instance As Task)
    End Sub
  Partial Private Sub DeleteTask(instance As Task)
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
	
	Public ReadOnly Property Tasks() As System.Data.Linq.Table(Of Task)
		Get
			Return Me.GetTable(Of Task)
		End Get
	End Property
End Class

<Global.System.Data.Linq.Mapping.TableAttribute(Name:="dbo.Task")>  _
Partial Public Class Task
	Implements System.ComponentModel.INotifyPropertyChanging, System.ComponentModel.INotifyPropertyChanged
	
	Private Shared emptyChangingEventArgs As PropertyChangingEventArgs = New PropertyChangingEventArgs(String.Empty)
	
	Private _RecordId As Integer
	
	Private _GroupNumber As Integer
	
	Private _Number As Integer
	
	Private _Description As String
	
	Private _EmployeeRecordId As Integer
	
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
    Partial Private Sub OnGroupNumberChanging(value As Integer)
    End Sub
    Partial Private Sub OnGroupNumberChanged()
    End Sub
    Partial Private Sub OnNumberChanging(value As Integer)
    End Sub
    Partial Private Sub OnNumberChanged()
    End Sub
    Partial Private Sub OnDescriptionChanging(value As String)
    End Sub
    Partial Private Sub OnDescriptionChanged()
    End Sub
    Partial Private Sub OnEmployeeRecordIdChanging(value As Integer)
    End Sub
    Partial Private Sub OnEmployeeRecordIdChanged()
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
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_GroupNumber", DbType:="Int NOT NULL")>  _
	Public Property GroupNumber() As Integer
		Get
			Return Me._GroupNumber
		End Get
		Set
			If ((Me._GroupNumber = value)  _
						= false) Then
				Me.OnGroupNumberChanging(value)
				Me.SendPropertyChanging
				Me._GroupNumber = value
				Me.SendPropertyChanged("GroupNumber")
				Me.OnGroupNumberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Number", DbType:="Int NOT NULL")>  _
	Public Property Number() As Integer
		Get
			Return Me._Number
		End Get
		Set
			If ((Me._Number = value)  _
						= false) Then
				Me.OnNumberChanging(value)
				Me.SendPropertyChanging
				Me._Number = value
				Me.SendPropertyChanged("Number")
				Me.OnNumberChanged
			End If
		End Set
	End Property
	
	<Global.System.Data.Linq.Mapping.ColumnAttribute(Storage:="_Description", DbType:="VarChar(255) NOT NULL", CanBeNull:=false)>  _
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
