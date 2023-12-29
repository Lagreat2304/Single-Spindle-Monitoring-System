Public Class FormCount
    Private Sub FormCount_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtCountCode.Clear()
            txtCountName.Clear()
            txtCountDesc.Clear()
            cbxProductType.SelectedIndex = 0
            cbxSalesType.SelectedIndex = 0
            cbxUOM.SelectedIndex = 0
            txtCommodity.Clear()
            txtBarcode.Clear()
            cbxActive.SelectedIndex = 0
            txtCountCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            txtCountCode.Clear()
            txtCountName.Clear()
            txtCountDesc.Clear()
            cbxProductType.SelectedIndex = 0
            cbxSalesType.SelectedIndex = 0
            cbxUOM.SelectedIndex = 0
            txtCommodity.Clear()
            txtBarcode.Clear()
            cbxActive.SelectedIndex = 0
            txtCountCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtCountCode.Text.Trim = "" Then
                Show_Message("Error : " & "Please enter count code.", "S2MS")
                txtCountCode.Focus()
                Exit Sub
            End If

            If txtCountName.Text.Trim = "" Then
                Show_Message("Error : " & "Please entercount name.", "S2MS")
                txtCountName.Focus()
                Exit Sub
            End If


            If txtCountDesc.Text.Trim = "" Then
                Show_Message("Error : " & "Please enter count description.", "S2MS")
                txtCountDesc.Focus()
                Exit Sub
            End If

            Dim mvarDataCount As Integer = 0
            SSQL = ""
            SSQL = "select count('x') from S2MS..Esp_Count_Details where Comp_Code='" & mvarOrgCode & "' and Count_Code ='" & txtCountCode.Text & "'"
            mvarDataCount = ReturnSingleValue(SSQL, "S2MS", "S2MS")

            If mvarDataCount > 0 Then
                SSQL = ""
                SSQL = "update S2MS..Esp_Count_Details set"
                SSQL = SSQL & " Count_Name='" & Trim(txtCountName.Text) & "',"
                SSQL = SSQL & " Count_Desc='" & Trim(txtCountDesc.Text) & "',"
                SSQL = SSQL & " Product_Type='" & Trim(cbxProductType.Text) & "',"
                SSQL = SSQL & " Product_Sales_Type='" & Trim(cbxSalesType.Text) & "',"
                SSQL = SSQL & " UOM_Code='" & Trim(cbxUOM.Text) & "',"
                SSQL = SSQL & " Commodity_code='" & Trim(txtCommodity.Text) & "',"
                SSQL = SSQL & " BarCode='" & Trim(txtBarcode.Text) & "',"
                SSQL = SSQL & " IsActive='" & IIf(cbxActive.Text = "YES", 1, 0) & "',"
                SSQL = SSQL & " Modified_By='" & mvarUserID & "',"
                SSQL = SSQL & " Modified_Date=getdate()"
                SSQL = SSQL & " where Comp_Code='" & mvarOrgCode & "' and Count_Code='" & Trim(txtCountCode.Text) & "'"
            Else
                SSQL = ""
                SSQL = "insert into S2MS..Esp_Count_Details (Comp_Code,Count_Code,Count_Name,"
                SSQL = SSQL & " Count_Desc, Product_Type, Product_Sales_Type,"
                SSQL = SSQL & " UOM_Code, Commodity_code, BarCode, IsActive, Created_By, Created_Date)"
                SSQL = SSQL & " select '" & mvarOrgCode & "',"
                SSQL = SSQL & "'" & Trim(txtCountCode.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtCountName.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtCountDesc.Text) & "',"
                SSQL = SSQL & "'" & Trim(cbxProductType.Text) & "',"
                SSQL = SSQL & "'" & Trim(cbxSalesType.Text) & "',"
                SSQL = SSQL & "'" & Trim(cbxUOM.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtCommodity.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtBarcode.Text) & "',"
                SSQL = SSQL & "'" & IIf(cbxActive.Text = "YES", 1, 0) & "',"
                SSQL = SSQL & "'" & mvarUserID & "',"
                SSQL = SSQL & "getdate()"
            End If

            Dim i As Integer = InsertDeleteUpdate(SSQL, "S2MS", "S2MS")

            If i >= 1 Then
                Show_Message("Information : " & "Successfully saved.", "S2MS")
                txtCountDesc.Focus()
                Exit Sub
            Else
                Show_Message("Error : " & "Please try again.", "S2MS")
                txtCountDesc.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ds = Nothing
            ds = New DataSet
            dt = Nothing
            dt = New DataTable
            dtPickList = Nothing

            ds = Nothing
            SSQL = ""
            SSQL = "select Count_Code,Count_Name,Count_Desc,Product_Type,Product_Sales_Type,UOM_Code,Commodity_code,BarCode,IsActive,Created_By,Created_Date"
            SSQL = SSQL & " from Esp_Count_Details"
            SSQL = SSQL & " where Comp_Code='" & mvarOrgCode & "'"
            ds = ReturnMultipleValue(SSQL, "S2MS", "S2MS")

            dt = ds.Tables(0)
            Dim frmPickList1 As New FormSearch
            frmPickList1.Text = "Count Search"
            frmPickList1.Set_Information_Dataset(ds)
            frmPickList1.ShowInTaskbar = False
            frmPickList1.ShowDialog()
            frmPickList1.StartPosition = FormStartPosition.CenterScreen
            frmPickList1.BringToFront()
            If dtPickList Is Nothing OrElse dtPickList.Rows.Count <= 0 Then Exit Sub
            txtCountCode.Text = dtPickList.Rows(0)("Count_Code")
            txtCountName.Text = dtPickList.Rows(0)("Count_Name")
            txtCountDesc.Text = dtPickList.Rows(0)("Count_Desc")
            cbxProductType.Text = dtPickList.Rows(0)("Product_Type")
            cbxSalesType.Text = dtPickList.Rows(0)("Product_Sales_Type")
            cbxUOM.Text = dtPickList.Rows(0)("UOM_Code")
            txtCommodity.Text = dtPickList.Rows(0)("Commodity_code")
            txtBarcode.Text = dtPickList.Rows(0)("BarCode")
            cbxActive.Text = IIf(dtPickList.Rows(0)("IsActive") = "1", "YES", "NO")
            txtCountDesc.Focus()
            Exit Sub
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub txtCountCode_LostFocus(sender As Object, e As EventArgs) Handles txtCountCode.LostFocus
        Try

            If txtCountCode.Text.Trim = "" Then
                txtCountDesc.Focus()
                Exit Sub
            End If


            ds = Nothing
            SSQL = ""
            SSQL = "select Count_Name,Count_Desc,Product_Type,Product_Sales_Type,UOM_Code,Commodity_code,BarCode,IsActive,Created_By,Created_Date"
            SSQL = SSQL & " from Esp_Count_Details"
            SSQL = SSQL & " where Comp_Code='" & mvarOrgCode & "' and Count_Code='" & Trim(txtCountCode.Text) & "'"

            ds = ReturnMultipleValue(SSQL, "S2MS", "S2MS")

            If ds.Tables(0).Rows.Count > 0 Then
                txtCountName.Text = ds.Tables(0).Rows(0)("Count_Name")
                txtCountDesc.Text = ds.Tables(0).Rows(0)("Count_Desc")
                cbxProductType.Text = ds.Tables(0).Rows(0)("Product_Type")
                cbxSalesType.Text = ds.Tables(0).Rows(0)("Product_Sales_Type")
                cbxUOM.Text = ds.Tables(0).Rows(0)("UOM_Code")
                txtCommodity.Text = ds.Tables(0).Rows(0)("Commodity_code")
                txtBarcode.Text = ds.Tables(0).Rows(0)("BarCode")
                cbxActive.Text = IIf(ds.Tables(0).Rows(0)("IsActive") = "1", "YES", "NO")
                txtCountDesc.Focus()
            Else
                txtCountDesc.Focus()
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub FormCount_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Try
            If e.KeyCode = Keys.Escape Then
                e.SuppressKeyPress = True
                Dim ctl As Control
                ctl = Me.ActiveControl
                Dim isATextBox As Boolean = TypeOf Me.ActiveControl Is TextBox
                If isATextBox Then
                    ctl.Text = ""
                    ctl.Focus()
                End If
                e.Handled = True
                Exit Sub
            End If

            If e.KeyCode = Keys.Enter Then
                e.SuppressKeyPress = True
                SendKeys.Send("{TAB}")
                e.Handled = True
                Exit Sub
            End If

        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
End Class