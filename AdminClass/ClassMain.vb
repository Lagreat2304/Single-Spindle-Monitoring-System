Option Explicit On
#Region "Imports"
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
#End Region
Public Class ClassMain

    Public Function AdminUserLoginValidation(ByVal mvarGetString As String) As String
        Dim mInputParam As String() = Split(mvarGetString, "||")
        Dim mvarResultString As String = "False"

        'If (mInputParam(2) = "ADMINISTRATOR" Or mInputParam(2) = "MANAGEMENT") Then
        ds = Nothing
        ds = New DataSet()
        ds = GetUserDetails_SP(mvarGetString)

        If ds.Tables(0).Rows.Count > 0 Then
            If UCase(ds.Tables(0).Rows(0)("UserID")) = UCase(mInputParam(1)) Then
                mvarResultString = "True"
            End If
        Else
            mvarResultString = "False"
        End If
        'End If
        Return mvarResultString
    End Function

    Public Function GetUserDetails_SP(ByVal mvarGetString As String) As DataSet
        Try
            Dim mInputParam As String() = Split(mvarGetString, "||")
            com = New OleDbCommand
            con = New OleDbConnection(GetConnection("CO_ADMIN", "DB_TALKER"))
            Try
                With com
                    .Parameters.Clear()
                    .Connection = con
                    .CommandText = "GetUser_Details_SP"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add("@CompID", OleDbType.VarChar, 1).Value = mInputParam(0)
                    .Parameters.Add("@UserID", OleDbType.VarChar, 100).Value = mInputParam(1)
                    .Parameters.Add("@Password", OleDbType.VarChar, 100).Value = mInputParam(2)
                    .Parameters.Add("@RoleName", OleDbType.VarChar, 100).Value = mInputParam(3)
                End With
                da = New OleDbDataAdapter(com)
                ds = Nothing
                ds = New DataSet()
                da.Fill(ds)
                da.Dispose()
                com.Dispose()
                con.Dispose()
            Catch ex As Exception
                Throw New Exception(ex.Message)
                da.Dispose()
                com.Dispose()
                con.Dispose()
            End Try
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function GetAdminUserDetails_SP(ByVal mvarGetString As String) As DataSet
        Try
            Dim mInputParam As String() = Split(mvarGetString, "||")
            com = New OleDbCommand
            con = New OleDbConnection(GetConnection("CO_ADMIN", "DB_TALKER"))
            Try
                With com
                    .Parameters.Clear()
                    .Connection = con
                    .CommandText = "GetAdminUser_Details_SP"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add("@UserID", OleDbType.VarChar, 100).Value = mInputParam(0)
                    .Parameters.Add("@Password", OleDbType.VarChar, 200).Value = mInputParam(1)
                End With
                da = New OleDbDataAdapter(com)
                ds = Nothing
                ds = New DataSet()
                da.Fill(ds)
                da.Dispose()
                com.Dispose()
                con.Dispose()
            Catch ex As Exception
                Throw New Exception(ex.Message)
                da.Dispose()
                com.Dispose()
                con.Dispose()
            End Try
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function
    Public Function AutoNumberGeneration(ByVal mTransactionID As String, ByVal mDocumentType As String) As String

        Dim mOutput As String = ""
        com = New OleDbCommand
        con = New OleDbConnection(GetConnection("co_transaction", "DB_TALKER"))
        Try
            con.Open()
            com.CommandText = "AutoNumberGeneration_SP"
            com.CommandType = CommandType.StoredProcedure
            com.Connection = con
            com.Parameters.Add("@TransactionID", OleDbType.VarChar, 255).Value = mTransactionID
            com.Parameters.Add("@DocumentType", OleDbType.VarChar, 200).Value = mDocumentType
            Dim OutParam As New OleDbParameter("@Status", OleDbType.VarChar, 500)
            OutParam.Direction = ParameterDirection.Output
            com.Parameters.Add(OutParam)
            com.ExecuteNonQuery()
            mOutput = com.Parameters("@Status").Value
            com.Dispose()
            con.Dispose()

            Dim mResult As String() = mOutput.Split("||")

            If mResult(0).Trim = "Error" Then
                mOutput = "Error"
                Return mOutput
            Else
                Return mOutput
            End If
        Catch ex As Exception
            mOutput = "Error||An error occurred. Please try again later."
            Return mOutput
            com.Dispose()
            con.Dispose()
        End Try
        Return mOutput
    End Function
    Public Function GetRoleScreen_Mapping_SP(ByVal mavrRoleName As String) As DataSet
        Try
            com = New OleDbCommand
            con = New OleDbConnection(GetConnection("CO_ADMIN", "DB_TALKER"))
            Try
                With com
                    .Parameters.Clear()
                    .Connection = con
                    .CommandText = "GetRoleScreen_Mapping_SP"
                    .CommandType = CommandType.StoredProcedure
                    .Parameters.Add("@RoleName", OleDbType.VarChar, 100).Value = mavrRoleName
                End With
                da = New OleDbDataAdapter(com)
                ds = Nothing
                ds = New DataSet()
                da.Fill(ds)
                da.Dispose()
                com.Dispose()
                con.Dispose()
            Catch ex As Exception
                Throw New Exception(ex.Message)
                da.Dispose()
                com.Dispose()
                con.Dispose()
            End Try
            Return ds
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try
    End Function

End Class
