Public Class FormMachine
    Private Sub FormMachine_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtEqpNo.Clear()
            cbxEqpGroup.SelectedIndex = 1
            cbxDepartment.SelectedIndex = 0
            txtMCCode.Clear()
            txtMCName.Clear()
            txtMake.Clear()
            txtModel.Clear()
            txtSerialNo.Clear()
            dtpInstalDate.Value = Now
            dtpExpDate.Value = Now
            cbxActive.SelectedIndex = 0
            txtMCCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            txtEqpNo.Clear()
            cbxEqpGroup.SelectedIndex = 1
            cbxDepartment.SelectedIndex = 0
            txtMCCode.Clear()
            txtMCName.Clear()
            txtMake.Clear()
            txtModel.Clear()
            txtSerialNo.Clear()
            dtpInstalDate.Value = Now
            dtpExpDate.Value = Now
            cbxActive.SelectedIndex = 0
            txtMCCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtMCCode.Text.Trim = "" Then
                Show_Message("Error : " & "Please enter machine code.", "S2MS")
                txtMCCode.Focus()
                Exit Sub
            End If

            If txtMCName.Text.Trim = "" Then
                Show_Message("Error : " & "Please enter machine name.", "S2MS")
                txtMCName.Focus()
                Exit Sub
            End If


            Dim mvarDataCount As Integer = 0
            Dim mvarEqpNo As Integer = 0

            SSQL = ""
            SSQL = "select count('x') from S2MS..Esp_Machine_Master where Comp_Code='" & mvarOrgCode & "' and Machine_Code ='" & txtMCCode.Text & "'"
            mvarDataCount = ReturnSingleValue(SSQL, "S2MS", "S2MS")

            SSQL = ""
            SSQL = "select isnull(max(Equipment_No),0) + 1 from S2MS..Esp_Machine_Master where Comp_Code='" & mvarOrgCode & "'"
            mvarEqpNo = ReturnSingleValue(SSQL, "S2MS", "S2MS")



            If mvarDataCount > 0 Then
                SSQL = ""
                SSQL = "update S2MS..Esp_Machine_Master set"
                SSQL = SSQL & " Machine_Name='" & Trim(txtMCName.Text) & "',"
                SSQL = SSQL & " Dept_Code='" & Trim(cbxDepartment.Text) & "',"
                SSQL = SSQL & " Equipment_Group='" & Trim(cbxEqpGroup.Text) & "',"
                SSQL = SSQL & " Make='" & Trim(txtMake.Text) & "',"
                SSQL = SSQL & " Model='" & Trim(txtModel.Text) & "',"
                SSQL = SSQL & " Sno='" & Trim(txtSerialNo.Text) & "',"
                SSQL = SSQL & " Installed_Date='" & Format(dtpInstalDate.Value, "yyyy/MM/dd") & "',"
                SSQL = SSQL & " Expiry_Date='" & Format(dtpExpDate.Value, "yyyy/MM/dd") & "',"
                SSQL = SSQL & " IsActive='" & IIf(cbxActive.Text = "YES", 1, 0) & "',"
                SSQL = SSQL & " Modified_By='" & mvarUserID & "',"
                SSQL = SSQL & " Modified_Date=getdate()"
                SSQL = SSQL & " where Comp_Code='" & mvarOrgCode & "' and Machine_Code='" & Trim(txtMCCode.Text) & "'"
            Else
                SSQL = ""
                SSQL = "insert into S2MS..Esp_Machine_Master (Comp_Code,Location_Code,Equipment_No,Machine_Code,Machine_Name,Dept_Code,"
                SSQL = SSQL & " Equipment_Group, Make, Model, Sno, Installed_Date, Expiry_Date, IsActive, Created_by, Created_Date)"
                SSQL = SSQL & " select '" & mvarOrgCode & "',"
                SSQL = SSQL & "'" & "SPINNING" & "',"
                SSQL = SSQL & "'" & Trim(mvarEqpNo) & "',"
                SSQL = SSQL & "'" & Trim(txtMCCode.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtMCName.Text) & "',"
                SSQL = SSQL & "'" & Trim(cbxDepartment.Text) & "',"
                SSQL = SSQL & "'" & Trim(cbxEqpGroup.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtMake.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtModel.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtSerialNo.Text) & "',"
                SSQL = SSQL & "'" & Format(dtpInstalDate.Value, "yyyy/MM/dd") & "',"
                SSQL = SSQL & "'" & Format(dtpExpDate.Value, "yyyy/MM/dd") & "',"
                SSQL = SSQL & "'" & IIf(cbxActive.Text = "YES", 1, 0) & "',"
                SSQL = SSQL & "'" & mvarUserID & "',"
                SSQL = SSQL & "getdate()"
            End If

            Dim i As Integer = InsertDeleteUpdate(SSQL, "S2MS", "S2MS")

            If i > 0 Then
                Show_Message("Information : " & "Successfully saved.", "S2MS")
                txtMCName.Focus()
                Exit Sub
            Else
                Show_Message("Error : " & "Please try again.", "S2MS")
                txtMCName.Focus()
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
            SSQL = "select Equipment_No,Machine_Code,Machine_Name,Dept_Code,Equipment_Group,Make,Model,Sno,Installed_Date,Expiry_Date,IsActive"
            SSQL = SSQL & " from Esp_Machine_Master"
            SSQL = SSQL & " where Comp_Code='" & mvarOrgCode & "'"
            ds = ReturnMultipleValue(SSQL, "S2MS", "S2MS")

            dt = ds.Tables(0)
            Dim frmPickList1 As New FormSearch
            frmPickList1.Text = "Machine Search"
            frmPickList1.Set_Information_Dataset(ds)
            frmPickList1.ShowInTaskbar = False
            frmPickList1.ShowDialog()
            frmPickList1.StartPosition = FormStartPosition.CenterScreen
            frmPickList1.BringToFront()
            If dtPickList Is Nothing OrElse dtPickList.Rows.Count <= 0 Then Exit Sub
            txtEqpNo.Text = dtPickList.Rows(0)("Equipment_No")
            txtMCCode.Text = dtPickList.Rows(0)("Machine_Code")
            txtMCName.Text = dtPickList.Rows(0)("Machine_Name")
            cbxDepartment.Text = dtPickList.Rows(0)("Dept_Code")
            cbxEqpGroup.Text = dtPickList.Rows(0)("Equipment_Group")
            txtMake.Text = dtPickList.Rows(0)("Make")
            txtModel.Text = dtPickList.Rows(0)("Model")
            txtSerialNo.Text = dtPickList.Rows(0)("Sno")
            dtpInstalDate.Value = dtPickList.Rows(0)("Installed_Date")
            dtpExpDate.Value = dtPickList.Rows(0)("Expiry_Date")
            cbxActive.Text = IIf(dtPickList.Rows(0)("IsActive") = "1", "YES", "NO")
            txtMCName.Focus()
            Exit Sub
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub FormMachine_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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