Option Explicit On

#Region "Imports"
Imports System
Imports System.Data
Imports System.Data.OleDb
#End Region
Module ModuleDBConnection
    Public mvarKeyName(5) As String
    Public mvarKeyValues(5) As String
    Public mvarINISectionName As String
    Public mvarServerName As String
    Public mvarConnectionString As String = ""
    Public Function GetConnection(ByVal mvarDatabaseName As String, ByVal mvarINIFileSectionName As String) As String
        Try
            Dim mvarINIPath As String = mvarReportPath & "\s2ms.ini"

            If (mvarINISectionName = "" Or mvarINISectionName <> mvarINIFileSectionName) Then
                mvarKeyName(1) = "UserName"
                mvarKeyName(2) = "Password"
                mvarKeyName(3) = "Local"
                mvarKeyName(4) = mvarDatabaseName

                mvarINISectionName = mvarINIFileSectionName
                ReadINIFile(mvarINIPath, mvarINISectionName, mvarKeyName, mvarKeyValues)
            End If

            mvarConnectionString = "Provider=sqloledb;"
            mvarConnectionString &= "Data Source=" & mvarKeyValues(3) & ";"
            mvarConnectionString &= "Initial Catalog= " & mvarDatabaseName & ";" 'mvarDatabaseName
            mvarConnectionString &= "User ID= " & Trim(mvarKeyValues(1)) & ";"  'Decryption(Trim(mvarKeyValues(1)), "600091") 
            mvarConnectionString &= "Password= " & Trim(mvarKeyValues(2)) & ";" 'Decryption(Trim(mvarKeyValues(2)), "600091") 
            mvarServLocation = mvarKeyValues(5)
            Return mvarConnectionString
        Catch ex As Exception
            Throw New Exception("Error : " & ex.Message.ToString.ToString)
        End Try
        Return mvarConnectionString
    End Function

    Public Sub ReadINIFile(ByVal mvarINIPath As String, ByVal mvarSectionName As String, ByVal mvarKeyName As String(), ByRef mvarKeyValue As String())
        Try
            Dim mvarLength As Integer
            Dim mvarStrData As String
            mvarStrData = Space$(1024)
            For i As Integer = 1 To mvarKeyName.Length - 1
                If mvarKeyName(i) <> "" Then
                    mvarLength = GetPrivateProfileString(mvarSectionName, mvarKeyName(i), mvarKeyValue(i), mvarStrData, mvarStrData.Length, LTrim(RTrim((mvarINIPath))))
                    If mvarLength > 0 Then
                        mvarKeyValue(i) = mvarStrData.Substring(0, mvarLength)
                    Else
                        mvarKeyValue(i) = ""
                    End If
                End If
            Next
        Catch ex As Exception
            Throw New Exception("Error : " & ex.Message.ToString.ToString)
        End Try
    End Sub

    Public Function ReturnSingleValue(ByVal MyQuery As String,
                                         ByVal mvarDatabaseName As String,
                                         ByVal mvarINIFileSectionName As String) As Object
        Try
            If mvarConnectionString = "" Then
                thisConnnection = New OleDbConnection(GetConnection(mvarDatabaseName, mvarINIFileSectionName))
            Else
                thisConnnection = New OleDbConnection(mvarConnectionString)
            End If

            thisCommand = New OleDbCommand(MyQuery, thisConnnection)
            thisConnnection.Open()
            Dim result As Object = thisCommand.ExecuteScalar
            thisConnnection.Close()
            If IsDBNull(result) Then
                Return Nothing
            End If

            Return result
        Catch ex As Exception
            Throw New Exception("Error : " & ex.Message.ToString)
            If thisConnnection.State = ConnectionState.Open Then
                thisConnnection.Close()
            End If
        End Try
        Return Nothing
    End Function

    Public Function InsertDeleteUpdate(ByVal MyQuery As String,
                                         ByVal mvarDatabaseName As String,
                                         ByVal mvarINIFileSectionName As String) As Long
        Try
            If mvarConnectionString = "" Then
                thisConnnection = New OleDbConnection(GetConnection(mvarDatabaseName, mvarINIFileSectionName))
            Else
                thisConnnection = New OleDbConnection(mvarConnectionString)
            End If

            thisCommand = New OleDbCommand(MyQuery, thisConnnection)
            thisConnnection.Open()
            Dim RowsAffected As Long
            RowsAffected = thisCommand.ExecuteNonQuery()
            thisConnnection.Close()
            Return RowsAffected
        Catch ex As Exception
            Throw New Exception("Error : " & ex.Message.ToString)
            If thisConnnection.State = ConnectionState.Open Then
                thisConnnection.Close()
            End If
        End Try
        Return Nothing
    End Function

    Public Function ReturnMultipleValue(ByVal MyQuery As String,
                                         ByVal mvarDatabaseName As String,
                                         ByVal mvarINIFileSectionName As String) As DataSet
        Dim ds As New DataSet
        Try
            If mvarConnectionString = "" Then
                thisConnnection = New OleDbConnection(GetConnection(mvarDatabaseName, mvarINIFileSectionName))
            Else
                thisConnnection = New OleDbConnection(mvarConnectionString)
            End If

            thisDataAdapter = New OleDbDataAdapter(MyQuery, thisConnnection)
            ds = New DataSet
            thisConnnection.Open()
            thisDataAdapter.Fill(ds)
            thisConnnection.Close()
            Return ds
        Catch ex As Exception
            Throw New Exception("Error : " & ex.Message.ToString)
            If thisConnnection.State = ConnectionState.Open Then
                thisConnnection.Close()
            End If
        End Try
        Return ds
    End Function

    Public Sub ExecuteCommAndQuery(ByVal comm As OleDbCommand, ByVal mvarDatabaseName As String, ByVal mvarINIFileSectionName As String)
        Try
            If mvarConnectionString = "" Then
                thisConnnection = New OleDbConnection(GetConnection(mvarDatabaseName, mvarINIFileSectionName))
            Else
                thisConnnection = New OleDbConnection(mvarConnectionString)
            End If

            comm.Connection = thisConnnection
            thisConnnection.Open()
            comm.ExecuteNonQuery()
            thisConnnection.Close()
        Catch ex As Exception
            Throw New Exception("Error : " & ex.Message.ToString)
            If thisConnnection.State = ConnectionState.Open Then
                thisConnnection.Close()
            End If
        End Try
    End Sub
End Module
