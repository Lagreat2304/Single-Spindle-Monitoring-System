Option Explicit On
#Region "Imports"
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
#End Region
Public Class ClassPayTerm
    Public Function SavePayTermDetails(ByVal mSaveString As String) As String
        Dim mInputParam As String() = Split(mSaveString, "||")
        Dim mOutput As String = ""
        com = New OleDbCommand
        con = New OleDbConnection(GetConnection("co_master", "DB_TALKER"))
        Try
            con.Open()
            com.CommandText = "SavePayTerm_SP"
            com.CommandType = CommandType.StoredProcedure
            com.Connection = con
            com.Parameters.Add("@CompID", OleDbType.Integer).Value = mInputParam(0)
            com.Parameters.Add("@PayTermID", OleDbType.VarChar, 50).Value = mInputParam(1)
            com.Parameters.Add("@PayTermDesc", OleDbType.VarChar, 200).Value = mInputParam(2)
            com.Parameters.Add("@IsActive", OleDbType.VarChar, 3).Value = mInputParam(3)
            com.Parameters.Add("@CreatedBy", OleDbType.VarChar, 100).Value = mvarUserID
            Dim OutParam As New OleDbParameter("@Status", OleDbType.VarChar, 500)
            OutParam.Direction = ParameterDirection.Output
            com.Parameters.Add(OutParam)
            com.ExecuteNonQuery()
            mOutput = com.Parameters("@Status").Value
            com.Dispose()
            con.Dispose()

            Dim mResult As String() = mOutput.Split("||")

            If mResult(0).Trim = "Error" Then
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

    Public Function GetPayTermDetails(ByVal mGetString As String) As DataSet
        Try
            Dim mInputParam As String() = Split(mGetString, "||")
            com = New OleDbCommand
            con = New OleDbConnection(GetConnection("co_master", "DB_TALKER"))
            Try
                com.Parameters.Clear()
                com.Connection = con
                com.CommandText = "GetPayTerm_SP"
                com.Parameters.Add(" @CompID", OleDbType.Integer).Value = mInputParam(0)
                com.Parameters.Add("@PayTermID", OleDbType.VarChar, 100).Value = mInputParam(1)
                com.CommandType = CommandType.StoredProcedure

                da = New OleDbDataAdapter(com)
                ds = Nothing
                ds = New DataSet()
                da.Fill(ds)
                da.Dispose()
                com.Dispose()
                con.Dispose()
            Catch ex As Exception
                GetPayTermDetails = Nothing
                da.Dispose()
                com.Dispose()
                con.Dispose()
            End Try
            Return ds
        Catch ex As Exception
            GetPayTermDetails = Nothing
        End Try
    End Function
End Class
