Option Explicit On
#Region "Imports"
Imports System
Imports System.Data
Imports System.Data.OleDb
Imports C1.Win.C1FlexGrid
Imports System.IO
#End Region

Public Class FormStockSummary
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ds = Nothing
            ds = New DataSet
            dt = Nothing
            dt = New DataTable
            dtPickList = Nothing

            'Dim clsItem As New ClassItem

            'Dim mvarGetString As String = mvarOrgCode & "||" &
            '                       "ALL" & "||"

            'ds = clsItem.GetItemDetails(mvarGetString)
            dt = ds.Tables(0)
            Dim frmPickList1 As New FormSearch
            frmPickList1.Text = "Item Details Search"
            frmPickList1.Set_Information_Dataset(ds)
            frmPickList1.ShowInTaskbar = False
            frmPickList1.ShowDialog()
            frmPickList1.StartPosition = FormStartPosition.CenterScreen
            frmPickList1.BringToFront()
            If dtPickList Is Nothing OrElse dtPickList.Rows.Count <= 0 Then Exit Sub
            txtItemCode.Text = dtPickList.Rows(0)("ItemCode")
            btnGet.Focus()
            Exit Sub
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub

    Private Sub FormStockSummary_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FillGridTitle()
            txtItemCode.Clear()
            txtItemCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub
    Private Sub FillGridTitle()
        Try
            With c1fgItem
                .Clear()
                .Rows = 1
                .Cols = 7
                .set_TextMatrix(0, 0, "ItemGroupName")
                .set_TextMatrix(0, 1, "ItemSubGroupName")
                .set_TextMatrix(0, 2, "ItemCategoryName")
                .set_TextMatrix(0, 3, "ItemCode")
                .set_TextMatrix(0, 4, "ItemName")
                .set_TextMatrix(0, 5, "IsFixedAsset")
                .set_TextMatrix(0, 6, "AvailableQty")

                .set_ColWidth(0, 100)
                .set_ColWidth(1, 100)
                .set_ColWidth(2, 100)
                .set_ColWidth(3, 100)
                .set_ColWidth(4, 100)
                .set_ColWidth(5, 100)
                .set_ColWidth(6, 100)
            End With
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            FillGridTitle()
            txtItemCode.Clear()
            txtItemCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnGet_Click(sender As Object, e As EventArgs) Handles btnGet.Click
        Try
            SSQL = ""
            SSQL = "select ItemGroupName,ItemSubGroupName,ItemCategoryName,ItemCode,ItemName,IsFixedAsset,AvailableQty"
            SSQL = SSQL & " from co_master..Item_Master where CompID = " & mvarOrgCode & ""
            If txtItemCode.Text.Trim <> "" Then
                SSQL = SSQL & " and ItemCode='" & txtItemCode.Text.Trim & "'"
            End If
            SSQL = SSQL & " order by ItemGroupName"

            ds = Nothing
            ds = New DataSet
            ds = ReturnMultipleValue(SSQL, "co_master", "DB_TALKER")

            If ds.Tables(0).Rows.Count > 0 Then
                c1fgItem.Rows = ds.Tables(0).Rows.Count + 1
                For iRow As Integer = 0 To ds.Tables(0).Rows.Count - 1
                    With c1fgItem
                        .set_TextMatrix(iRow + 1, 0, ds.Tables(0).Rows(iRow)("ItemGroupName"))
                        .set_TextMatrix(iRow + 1, 1, ds.Tables(0).Rows(iRow)("ItemSubGroupName"))
                        .set_TextMatrix(iRow + 1, 2, ds.Tables(0).Rows(iRow)("ItemCategoryName"))
                        .set_TextMatrix(iRow + 1, 3, ds.Tables(0).Rows(iRow)("ItemCode"))
                        .set_TextMatrix(iRow + 1, 4, ds.Tables(0).Rows(iRow)("ItemName"))
                        .set_TextMatrix(iRow + 1, 5, ds.Tables(0).Rows(iRow)("IsFixedAsset"))
                        .set_TextMatrix(iRow + 1, 6, ds.Tables(0).Rows(iRow)("AvailableQty"))
                    End With
                Next
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub

    Private Sub btnExcel_Click(sender As Object, e As EventArgs) Handles btnExcel.Click
        Try
            If ds.Tables(0).Rows.Count > 0 Then
                c1tdbgReport.DataSource = Nothing
                c1tdbgReport.DataSource = ds.Tables(0)
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