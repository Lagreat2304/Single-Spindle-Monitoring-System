Public Class FormStoppage
    Private Sub FormStoppage_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtStopCode.Clear()
            txtStopName.Clear()
            txtStopDesc.Clear()
            cbxDepartment.SelectedIndex = 0
            cbxActive.SelectedIndex = 0
            txtStopCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            txtStopCode.Clear()
            txtStopName.Clear()
            txtStopDesc.Clear()
            cbxDepartment.SelectedIndex = 0
            cbxActive.SelectedIndex = 0
            txtStopCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If txtStopCode.Text.Trim = "" Then
                Show_Message("Error : " & "Please enter Stoppage code.", "S2MS")
                txtStopCode.Focus()
                Exit Sub
            End If

            If txtStopName.Text.Trim = "" Then
                Show_Message("Error : " & "Please enter Stoppage name.", "S2MS")
                txtStopName.Focus()
                Exit Sub
            End If


            If txtStopDesc.Text.Trim = "" Then
                Show_Message("Error : " & "Please enter Stoppage description.", "S2MS")
                txtStopDesc.Focus()
                Exit Sub
            End If

            Dim mvarDataStop As Integer = 0
            SSQL = ""
            SSQL = "select count('x') from S2MS..Esp_Stopage_Details where Comp_Code='" & mvarOrgCode & "' and Stopage_Code ='" & txtStopCode.Text & "'"
            mvarDataStop = ReturnSingleValue(SSQL, "S2MS", "S2MS")

            If mvarDataStop > 0 Then
                SSQL = ""
                SSQL = "update S2MS..Esp_Stopage_Details set"
                SSQL = SSQL & " Stopage_Name='" & Trim(txtStopName.Text) & "',"
                SSQL = SSQL & " Stopage_Desc='" & Trim(txtStopDesc.Text) & "',"
                SSQL = SSQL & " Stopage_By_Dept='" & Trim(cbxDepartment.Text) & "',"
                SSQL = SSQL & " IsActive='" & IIf(cbxActive.Text = "YES", 1, 0) & "',"
                SSQL = SSQL & " Modified_By='" & mvarUserID & "',"
                SSQL = SSQL & " Modified_Date=getdate()"
                SSQL = SSQL & " where Comp_Code='" & mvarOrgCode & "' and Stopage_Code='" & Trim(txtStopCode.Text) & "'"
            Else
                SSQL = ""
                SSQL = "insert into S2MS..Esp_Stopage_Details (Comp_Code,Location_Code,Fin_Year_Code,"
                SSQL = SSQL & " Stopage_Code,Stopage_Name,Stopage_By_Dept,"
                SSQL = SSQL & " Stopage_Desc,IsActive,Created_By,Created_Date)"
                SSQL = SSQL & " select '" & mvarOrgCode & "',"
                SSQL = SSQL & " 'SPINNING','1',"
                SSQL = SSQL & "'" & Trim(txtStopCode.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtStopName.Text) & "',"
                SSQL = SSQL & "'" & Trim(cbxDepartment.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtStopDesc.Text) & "',"
                SSQL = SSQL & "'" & IIf(cbxActive.Text = "YES", 1, 0) & "',"
                SSQL = SSQL & "'" & mvarUserID & "',"
                SSQL = SSQL & "getdate()"
            End If

            Dim i As Integer = InsertDeleteUpdate(SSQL, "S2MS", "S2MS")

            If i >= 1 Then
                Show_Message("Information : " & "Successfully saved.", "S2MS")
                txtStopDesc.Focus()
                Exit Sub
            Else
                Show_Message("Error : " & "Please try again.", "S2MS")
                txtStopDesc.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub pbxMainClose_Click(sender As Object, e As EventArgs)
        Me.Close()
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
            SSQL = "select Comp_Code,Location_Code,Fin_Year_Code,Stopage_Code,Stopage_Name,Stopage_By_Dept,Stopage_Desc,IsActive,Created_By,Created_Date"
            SSQL = SSQL & " from Esp_Stopage_Details"
            SSQL = SSQL & " where Comp_Code='" & mvarOrgCode & "'"
            ds = ReturnMultipleValue(SSQL, "S2MS", "S2MS")

            dt = ds.Tables(0)
            Dim frmPickList1 As New FormSearch
            frmPickList1.Text = "Stop Search"
            frmPickList1.Set_Information_Dataset(ds)
            frmPickList1.ShowInTaskbar = False
            frmPickList1.ShowDialog()
            frmPickList1.StartPosition = FormStartPosition.CenterScreen
            frmPickList1.BringToFront()
            If dtPickList Is Nothing OrElse dtPickList.Rows.Count <= 0 Then Exit Sub
            txtStopCode.Text = dtPickList.Rows(0)("Stopage_Code")
            txtStopName.Text = dtPickList.Rows(0)("Stopage_Name")
            txtStopDesc.Text = dtPickList.Rows(0)("Stopage_Desc")
            cbxDepartment.Text = dtPickList.Rows(0)("Stopage_By_Dept")
            cbxActive.Text = IIf(dtPickList.Rows(0)("IsActive") = "1", "YES", "NO")
            txtStopDesc.Focus()
            Exit Sub
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub txtStopCode_LostFocus(sender As Object, e As EventArgs) Handles txtStopCode.LostFocus
        Try

            If txtStopCode.Text.Trim = "" Then
                txtStopDesc.Focus()
                Exit Sub
            End If


            ds = Nothing
            SSQL = ""
            SSQL = "select Comp_Code,Location_Code,Fin_Year_Code,Stopage_Code,Stopage_Name,Stopage_By_Dept,Stopage_Desc,IsActive,Created_By,Created_Date"
            SSQL = SSQL & " from Esp_Stopage_Details"
            SSQL = SSQL & " where Comp_Code='" & mvarOrgCode & "' and Stopage_Code='" & Trim(txtStopCode.Text) & "'"

            ds = ReturnMultipleValue(SSQL, "S2MS", "S2MS")

            If ds.Tables(0).Rows.Count > 0 Then
                txtStopName.Text = ds.Tables(0).Rows(0)("Stopage_Name")
                txtStopDesc.Text = ds.Tables(0).Rows(0)("Stopage_Desc")
                cbxDepartment.Text = ds.Tables(0).Rows(0)("Stopage_By_Dept")
                cbxActive.Text = IIf(ds.Tables(0).Rows(0)("IsActive") = "1", "YES", "NO")
                txtStopDesc.Focus()
            Else
                txtStopDesc.Focus()
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub FormStoppage_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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