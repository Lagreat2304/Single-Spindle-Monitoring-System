Option Explicit On

#Region "Imports"
Imports System
Imports System.Data
Imports System.Data.OleDb
#End Region
Module ModuleVariables
    Public mvarLanguageID As Integer

    Public mBibleDS As New DataSet
    Public mDSMenu As New DataSet

    Public mvarLanguageCode As String
    Public mvarLanguageDesc As String
    Public mvarOrgCode As String
    Public mvarOrgName As String
    Public mvarBranchCode As String
    Public mvarBranchName As String
    Public mvarUserID As String
    Public mvarUserName As String
    Public mvarOldUserID As String
    Public mvarOldUserName As String
    Public mvarFinYearCode As String
    Public mvarFinStartDate As String
    Public mvarFinEndDate As String
    Public mvarVersion As String
    Public mvarMessageType As String
    Public mvarMessageText As String
    Public mvarPassword As String
    Public mvarModuleName As String
    Public mvarServerDate As String
    Public SSQL As String
    Public mvarProdLocation As String
    Public mvarProductCode As String
    Public mvarApplicationType As String
    Public mvardFormat As String
    Public mvarServLocation As String

    Public mvarIsAdmin As Boolean
    Public mvarIsPOS As Boolean

    Public mvarFinYearStartDate As Date
    Public mvarFinYearEndDate As Date

    Public con As New OleDbConnection
    Public da As New OleDbDataAdapter
    Public com As New OleDbCommand
    Public ds As New DataSet
    Public dt As New DataTable
    Public dtPickList As New DataTable
    Public thisConnnection As New OleDbConnection
    Public thisDataAdapter As New OleDbDataAdapter
    Public thisCommand As New OleDbCommand
    Public thisTransaction As OleDbTransaction
    Public mDataRow As DataRow

    Public mRowCount As Double

    Public Declare Unicode Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringW" _
        (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String,
         ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32

    Public mvarReportPath As String = Application.StartupPath
    Public mvarFolderPath As String

    Public CreatedDate As DateTime
    Public ModifiedDate As DateTime
    Public Createdby As String = mvarUserID
    Public Modifiedby As String = mvarUserID
    Public mvarAddress As String = " "


    Public FormEventNo As Integer = 0
    Public FormNoEventFetch As Integer = 0
    Public FormTransType As String = ""
    Public FormEventFetchNo As Integer = 0
    Public RetRow As Integer = 0
End Module
