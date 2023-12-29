Option Explicit On
#Region "Imports"
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports C1.Win.C1FlexGrid
Imports System.IO
#End Region
Public Class FormSearch
    Dim mDS As New DataSet
    Public Sub Set_Information_Dataset(ByVal mDataset As DataSet)
        Try
            Me.c1tdbgInformation.FilterBar = True
            Me.c1tdbgInformation.AllowFilter = False
            mDS = New DataSet
            mDS = mDataset
            c1tdbgInformation.DataSource = mDS.Tables(0)
            For Each col In c1tdbgInformation.Splits(0).DisplayColumns
                col.AutoSize()
            Next
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub c1tdbgInformation_FilterChange(ByVal sender As Object, ByVal e As System.EventArgs) Handles c1tdbgInformation.FilterChange
        Dim sb As New System.Text.StringBuilder()
        Dim dc As C1.Win.C1TrueDBGrid.C1DataColumn
        Try
            For Each dc In Me.c1tdbgInformation.Columns
                If dc.FilterText.Length > 0 Then
                    If sb.Length > 0 Then
                        sb.Append(" AND ")
                    End If
                    sb.Append("Convert([" & dc.DataField & "], 'System.String') LIKE '*" & dc.FilterText & "*'")
                End If
            Next dc
            mDS.Tables(0).DefaultView.RowFilter = sb.ToString
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub c1tdbgInformation_KeyDown(sender As Object, e As KeyEventArgs) Handles c1tdbgInformation.KeyDown
        Try
            If e.KeyCode = Keys.Space AndAlso (e.Alt) Then
                Dim temp As New DataTable
                Dim row As DataRow
                Dim intColCount As Integer
                Dim value As String = ""
                value = c1tdbgInformation(c1tdbgInformation.Row, c1tdbgInformation.Col).ToString
                If Trim(value) = "" Then
                    dtPickList = Nothing
                    Me.Close()
                    Exit Sub
                End If
                temp = mDS.Tables(0).Clone()
                row = temp.NewRow()
                For intColCount = 0 To c1tdbgInformation.Columns.Count - 1
                    row(intColCount) = c1tdbgInformation(c1tdbgInformation.Row, intColCount).ToString
                Next
                temp.Rows.Add(row)
                dtPickList = Nothing
                dtPickList = temp
                Me.Close()
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub c1tdbgInformation_MouseDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles c1tdbgInformation.MouseDoubleClick
        Dim temp As New DataTable
        Dim row As DataRow
        Dim intColCount As Integer

        If c1tdbgInformation.PointAt(e.X, e.Y) = C1.Win.C1TrueDBGrid.PointAtEnum.AtDataArea Then

            Dim value As String = ""
            If c1tdbgInformation.Row < 0 Then Exit Sub
            value = c1tdbgInformation(c1tdbgInformation.Row, c1tdbgInformation.Col).ToString

            If Trim(value) = "" Then
                dtPickList = Nothing
                Me.Close()
                Exit Sub
            End If

            temp = mDS.Tables(0).Clone()
            row = temp.NewRow()

            For intColCount = 0 To c1tdbgInformation.Columns.Count - 1
                row(intColCount) = c1tdbgInformation(c1tdbgInformation.Row, intColCount).ToString()
            Next
            temp.Rows.Add(row)

            dtPickList = Nothing
            dtPickList = temp
            Me.Close()
        End If
    End Sub
    Private Sub FormSearch_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FormAlign(Me)
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs)
        Try
            SaveFileDialog1.Filter = "|*.xls"
            SaveFileDialog1.Title = "Save Excel File"
            SaveFileDialog1.ShowDialog()

            If SaveFileDialog1.FileName <> "" Then
                c1tdbgInformation.ExportToExcel(SaveFileDialog1.FileName)
                MessageBox.Show("Successfully exported.")
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class