Option Explicit On
#Region "Imports"
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports System.IO
#End Region
Public Class ClassLocation
    Public Function SaveLocationDetails(ByVal mSaveString As String) As String
        Dim mInputParam As String() = Split(mSaveString, "||")
        Dim mOutput As String = ""
        com = New OleDbCommand
        con = New OleDbConnection(GetConnection("s2ms", "s2ms"))
        Try
            con.Open()
            com.CommandText = "SaveLocation_SP"
            com.CommandType = CommandType.StoredProcedure
            com.Connection = con
            com.Parameters.Add("@CompID", OleDbType.VarChar, 100).Value = mInputParam(0)
            com.Parameters.Add("@LocationID", OleDbType.VarChar, 100).Value = (mInputParam(1))
            com.Parameters.Add("@LocationName", OleDbType.VarChar, 200).Value = mInputParam(2)
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
End Class
