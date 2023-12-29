Option Explicit On
#Region "Imports"
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports C1.Win.C1FlexGrid
Imports System.IO
Imports System.Globalization
Imports C1.Win.C1FlexGrid.Classic
Imports System.ComponentModel
Imports System.Threading
Imports System.Text.RegularExpressions
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Net.Mail
Imports System.Xml
#End Region
Public Class FormSpinningReport
    Dim mDS As New DataSet
    Dim mReportName As String
    Private Sub FormSpinningReport_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            cbxReportName.SelectedIndex = 0
            dtpFromDate.Value = Now
            dtptoDate.Value = Now
            mDS = New DataSet
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

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

    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click
        Try
            ' exec Esp_GetSpinningMachine_report '2023-01-01','2023-01-31','LS SPIN','3','SPINNING','ALL','II'
            c1tdbgInformation.DataSource = Nothing

            If dtpFromDate.Value >= dtptoDate.Value Then
                MessageBox.Show("Error : " & "To date should be greater than or equal to from date.", "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                dtpFromDate.Focus()
                Exit Sub
            End If

            mDS = New DataSet
            SSQL = ""

            If cbxReportName.Text = "Spinning Count wise Details" Then
                mReportName = "SpinningCountwiseDetails.rpt"
                SSQL = "exec Esp_GetSpinningCount_report '" & Format(dtpFromDate.Value, "yyyy/MM/dd") & "','" & Format(dtptoDate.Value, "yyyy/MM/dd") & "','LS SPIN','3','SPINNING','ALL' "
            ElseIf cbxReportName.Text = "Spinning Stoppage Machine wise / Reason wise" Then
                mReportName = "StoppageMcReason.rpt"
                SSQL = ""
                SSQL = "Select Machine_code As [MachineCode],upper(Stoppage1) As [StoppageReason], sum(stop_time1) As [StopMinutes],"
                SSQL = SSQL & " Case when sum(stop_time1)/60>1 then cast(sum(stop_time1)/60 as int) else 0 end  as [ApproximateHours]"
                SSQL = SSQL & " From s2ms..Esp_Spinning_Stoppage"
                SSQL = SSQL & " Where Stoppage1 <> '' and isnull(stop_time1,0) >0 "
                SSQL = SSQL & " And Convert(Date,entry_date) between '" & Format(dtpFromDate.Value, "yyyy/MM/dd") & "' and '" & Format(dtptoDate.Value, "yyyy/MM/dd") & "'"
                SSQL = SSQL & " Group By Machine_code, Stoppage1 Order By Machine_code, Stoppage1"
            End If
            mDS = ReturnMultipleValue(SSQL, "S2MS", "S2Ms")
            If mDS.Tables(0).Rows.Count > 0 Then
                Set_Information_Dataset(mDS)
            Else
                MessageBox.Show("Information : " & "No records found.", "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If

        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            Dim crysrep As New ReportDocument
            Dim crysview As New FormRepView
            Dim strFileLocation As String = mvarReportPath & "\Reports\" & mReportName

            If mDS.Tables.Count <= 0 Then Exit Sub

            If mDS.Tables(0).Rows.Count > 0 Then
                crysrep.Load(strFileLocation)
                crysrep.SetDataSource(mDS.Tables(0))
                If cbxReportName.Text = "Spinning Count wise Details" Or cbxReportName.Text = "Spinning Stoppage Machine wise / Reason wise" Then
                    crysrep.DataDefinition.FormulaFields("BetweenDates").Text = "'" + Format(dtpFromDate.Value, "dd/MM/yyyy") + " - " + Format(dtptoDate.Value, "dd/MM/yyyy") + "'"
                End If
                crysview.CrystalReportViewer1.ReportSource = crysrep
                crysview.CrystalReportViewer1.Refresh()
                crysview.CrystalReportViewer1.Zoom(105)
                crysview.Show()
            Else
                MessageBox.Show("Information : " & "No records found.", "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Exit Sub
            End If
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "S2MS", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        Try
            If mDS.Tables.Count <= 0 Then Exit Sub
            If mDS.Tables(0).Rows.Count > 0 Then
                c1tdbgReport.DataSource = Nothing
                c1tdbgReport.DataSource = mDS.Tables(0)
                SaveFileDialog1.Filter = "|*.xls"
                SaveFileDialog1.Title = "Save Excel File"
                SaveFileDialog1.ShowDialog()

                If SaveFileDialog1.FileName <> "" Then
                    c1tdbgReport.ExportToExcel(SaveFileDialog1.FileName)
                    MessageBox.Show("Successfully exported.")
                    Exit Sub
                End If
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub
End Class