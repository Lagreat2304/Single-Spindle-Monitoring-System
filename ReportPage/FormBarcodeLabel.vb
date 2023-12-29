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
Public Class FormBarcodeLabel
    Private Sub FormBarcodeLabel_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            Call FillLocationCombo()
            Call FillGridDetails()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "OneConnect", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
    Private Sub FillLocationCombo()
        SSQL = ""
        SSQL = "select -1 as [LocationID],'ALL' as [LocationName]"
        SSQL = SSQL & " union"
        SSQL = SSQL & " select distinct LocationID,LocationName from co_master..asset_master"
        SSQL = SSQL & " where  AssetCurrentStatus in ('OPEN','PURCHASE') and CompID = " & mvarOrgCode
        SSQL = SSQL & " and ItemCode  in ( select ItemCode from co_master..Item_Master where  ItemCategoryName ='Non-Inventory' and CompID = " & mvarOrgCode & ")"

        ds = Nothing
        ds = ReturnMultipleValue(SSQL, "co_master", "DB_TALKER")

        If ds.Tables(0).Rows.Count > 0 Then
            cbxLocation.Items.Clear()
            cbxLocation.DataSource = ds.Tables(0)
            cbxLocation.ValueMember = "LocationID"
            cbxLocation.DisplayMember = "LocationName"
            cbxLocation.SelectedIndex = 0
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            Call FillGridDetails()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "OneConnect", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub FillGridDetails()
        SSQL = ""
        SSQL = " select distinct LocationName,SubLocationName,AssetCode, AssetDesc,Make,Model,LegacyAssetCode,AssetCurrentStatus from co_master..asset_master"
        SSQL = SSQL & " where  AssetCurrentStatus in('OPEN','PURCHASE') and CompID = " & mvarOrgCode & " and LocationName like '" & IIf(cbxLocation.Text = "ALL", "%", cbxLocation.Text) & "'"
        SSQL = SSQL & " and ItemCode  in ( select ItemCode from co_master..Item_Master where  ItemCategoryName ='Non-Inventory' and CompID = " & mvarOrgCode & ")"

        ds = Nothing
        ds = ReturnMultipleValue(SSQL, "co_master", "DB_TALKER")
        If ds.Tables(0).Rows.Count > 0 Then
            With c1fgAssetDetails
                .FixedCols = 0
                .FixedRows = 1
                .Rows = ds.Tables(0).Rows.Count + 1
                .Cols = 9
                .set_TextMatrix(0, 0, "Select")
                .set_TextMatrix(0, 1, "LocationName")
                .set_TextMatrix(0, 2, "SubLocationName")
                .set_TextMatrix(0, 3, "AssetCode")
                .set_TextMatrix(0, 4, "AssetDesc")
                .set_TextMatrix(0, 5, "Make")
                .set_TextMatrix(0, 6, "Model")
                .set_TextMatrix(0, 7, "LegacyAssetCode")
                .set_TextMatrix(0, 8, "AssetCurrentStatus")
            End With

            For iRow = 0 To ds.Tables(0).Rows.Count - 1
                c1fgAssetDetails.SetCellCheck(iRow + 1, 0, C1.Win.C1FlexGrid.CheckEnum.Checked)
                c1fgAssetDetails.set_TextMatrix(iRow + 1, 1, ds.Tables(0).Rows(iRow)("LocationName"))
                c1fgAssetDetails.set_TextMatrix(iRow + 1, 2, ds.Tables(0).Rows(iRow)("SubLocationName"))
                c1fgAssetDetails.set_TextMatrix(iRow + 1, 3, ds.Tables(0).Rows(iRow)("AssetCode"))
                c1fgAssetDetails.set_TextMatrix(iRow + 1, 4, ds.Tables(0).Rows(iRow)("AssetDesc"))
                c1fgAssetDetails.set_TextMatrix(iRow + 1, 5, ds.Tables(0).Rows(iRow)("Make"))
                c1fgAssetDetails.set_TextMatrix(iRow + 1, 6, ds.Tables(0).Rows(iRow)("Model"))
                c1fgAssetDetails.set_TextMatrix(iRow + 1, 7, ds.Tables(0).Rows(iRow)("LegacyAssetCode"))
                c1fgAssetDetails.set_TextMatrix(iRow + 1, 8, ds.Tables(0).Rows(iRow)("AssetCurrentStatus"))
            Next

        End If
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            Call FillLocationCombo()
            Call FillGridDetails()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "OneConnect", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnAssetDetails_Click(sender As Object, e As EventArgs) Handles btnAssetDetails.Click
        Try
            Dim crysrep As New ReportDocument
            Dim crysview As New FormRepView
            Dim strFileLocation As String = ""

            SSQL = ""
            SSQL = mvarOrgCode + "||" + "DETAILS" + "||" + cbxLocation.SelectedValue.ToString() + "||"

            'Dim clsAsset As New ClassAsset


            'ds = Nothing
            'ds = New DataSet
            'ds = clsAsset.GetAssetDetailsReport(SSQL)

            If ds.Tables(0).Rows.Count <= 0 Then MessageBox.Show("Error : " & "No records found.", "OneConnect", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            strFileLocation = mvarReportPath & "\Reports\AssetDetailsReport.rpt"

            crysrep.Load(strFileLocation)
            crysrep.SetDataSource(ds.Tables(0))
            crysview.CrystalReportViewer1.ReportSource = crysrep
            crysview.CrystalReportViewer1.Refresh()
            crysview.CrystalReportViewer1.Zoom(105)
            crysview.Show()


            'crysrep.Load(mvarReportName)
            'crysrep.SetDataSource(ds.Tables(0))
            'crysrep.DataDefinition.FormulaFields("Tdate").Text = "'" + Format(DtpTodate.Value, "dd/MM/yyyy") + "'"
            'crysrep.DataDefinition.FormulaFields("Fdate").Text = "'" + Format(dtpFromDate.Value, "dd/MM/yyyy") + "'"
            'crysview.CrystalReportViewer1.ReportSource = crysrep
            'crysview.CrystalReportViewer1.Refresh()
            'crysview.CrystalReportViewer1.Zoom(100)
            crysview.Show()

        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "OneConnect", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub

    Private Sub btnBarcodePrint_Click(sender As Object, e As EventArgs) Handles btnBarcodePrint.Click
        Try
            Dim crysrep As New ReportDocument
            Dim crysview As New FormRepView
            Dim strFileLocation As String = ""
            Dim mStr As String = ""

            For iRow As Integer = 1 To c1fgAssetDetails.Rows - 1
                If c1fgAssetDetails.GetCellCheck(iRow, 0) = "1" Then
                    If mStr = "" Then
                        mStr = c1fgAssetDetails.get_TextMatrix(iRow, 3) + ","
                    Else
                        mStr = mStr + c1fgAssetDetails.get_TextMatrix(iRow, 3) + ","
                    End If
                End If
            Next

            SSQL = ""
            SSQL = mvarOrgCode + "||" + mStr + "||" + cbxLocation.SelectedValue.ToString() + "||"

            'Dim clsAsset As New ClassAsset


            'ds = Nothing
            'ds = New DataSet
            'ds = clsAsset.GetAssetDetailsReport(SSQL)

            If ds.Tables(0).Rows.Count <= 0 Then MessageBox.Show("Error : " & "No records found.", "OneConnect", MessageBoxButtons.OK, MessageBoxIcon.Information) : Exit Sub

            If rbtnPortrait.Checked = True Then
                strFileLocation = mvarReportPath & "\Reports\PortraitAssetBarcodePrint.rpt"
            Else
                strFileLocation = mvarReportPath & "\Reports\LandscapeAssetBarcodePrint.rpt"
            End If

            crysrep.Load(strFileLocation)
            crysrep.SetDataSource(ds.Tables(0))
            crysview.CrystalReportViewer1.ReportSource = crysrep
            crysview.CrystalReportViewer1.Refresh()
            crysview.CrystalReportViewer1.Zoom(105)
            crysview.Show()
        Catch ex As Exception
            MessageBox.Show("Error : " & ex.Message.ToString, "OneConnect", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End Try
    End Sub
End Class