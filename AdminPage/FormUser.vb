Imports C1.Win.C1FlexGrid

Public Class FormUser
    Private Sub btnGeneratePassword_Click(sender As Object, e As EventArgs) Handles btnGeneratePassword.Click
        Try
            txtPassword.Clear()
            txtPassword.Text = CreateRandomPassword(10)
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Public Shared Function CreateRandomPassword(ByVal PasswordLength As Integer) As String
        Dim _allowedChars As String = "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789*$-+?_&=!%{}/"
        Dim randomNumber As New Random()
        Dim chars(PasswordLength - 1) As Char
        Dim allowedCharCount As Integer = _allowedChars.Length
        For i As Integer = 0 To PasswordLength - 1
            chars(i) = _allowedChars.Chars(CInt(Fix((_allowedChars.Length) * randomNumber.NextDouble())))
        Next i
        Return New String(chars)
    End Function

    Private Sub SaveScreenDetails()
        Try
            If Trim(txtUserID.Text) = "" Then
                Show_Message("Error : " & "Please enter user ID.", "S2MS")
                txtUserID.Focus()
                Exit Sub
            End If

            If Trim(txtUserName.Text) = "" Then
                Show_Message("Error : " & "Please enter user name.", "S2MS")
                txtUserName.Focus()
                Exit Sub
            End If

            If Trim(txtPassword.Text) = "" Then
                Show_Message("Error : " & "Please generate password.", "S2MS")
                txtPassword.Focus()
                Exit Sub
            End If

            SSQL = ""
            SSQL = "select isnull(count('x'),0) from S2MS..User_Master where CompCode='" & mvarOrgCode & "' and UserID='" & Trim(txtUserID.Text) & "'"

            Dim mvarDataCount As Integer = ReturnSingleValue(SSQL, "S2MS", "S2MS")

            If mvarDataCount > 0 Then
                SSQL = ""
                SSQL = "update S2MS..User_Master set"
                SSQL = SSQL & " UserName='" & Trim(txtUserName.Text) & "',"
                SSQL = SSQL & " UserPwd='" & Trim(txtPassword.Text) & "',"
                SSQL = SSQL & " IsActive='" & Trim(cbxActive.Text) & "'"
                SSQL = SSQL & " where CompCode='" & mvarOrgCode & "' and UserID='" & Trim(txtUserID.Text) & "'"
            Else
                SSQL = ""
                SSQL = "insert into S2MS..User_Master (CompCode,UserID,UserName,UserPwd,IsActive)"
                SSQL = SSQL & " select '" & mvarOrgCode & "',"
                SSQL = SSQL & "'" & Trim(txtUserID.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtUserName.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtPassword.Text) & "',"
                SSQL = SSQL & "'" & Trim(cbxActive.Text) & "'"
            End If

            Dim i As Integer = InsertDeleteUpdate(SSQL, "S2MS", "S2MS")

            If i >= 1 Then
                Show_Message("Information : " & "Successfully saved.", "S2MS")
                txtPassword.Clear()
                txtUserID.Focus()
                Exit Sub
            Else
                Show_Message("Error : " & "Please try again.", "S2MS")
                txtPassword.Clear()
                txtUserID.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Trim(txtUserID.Text) = "" Then
                Show_Message("Error : " & "Please enter user ID.", "S2MS")
                txtUserID.Focus()
                Exit Sub
            End If

            If Trim(txtUserName.Text) = "" Then
                Show_Message("Error : " & "Please enter user name.", "S2MS")
                txtUserName.Focus()
                Exit Sub
            End If

            If Trim(txtPassword.Text) = "" Then
                Show_Message("Error : " & "Please generate password.", "S2MS")
                txtPassword.Focus()
                Exit Sub
            End If

            SSQL = ""
            SSQL = "select isnull(count('x'),0) from S2MS..User_Master where CompCode='" & mvarOrgCode & "' and UserID='" & Trim(txtUserID.Text) & "'"

            Dim mvarDataCount As Integer = ReturnSingleValue(SSQL, "S2MS", "S2MS")


            If mvarDataCount > 0 Then
                Show_Message("Information : " & "User is already exists, please modify the details.", "S2MS")
                btnModify.Focus()
                Exit Sub
            End If

            Call SaveScreenDetails()


        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub FormUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtUserID.Clear()
            txtUserName.Clear()
            txtPassword.Clear()
            cbxActive.SelectedIndex = 0
            txtUserName.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            txtUserID.Clear()
            txtUserName.Clear()
            txtPassword.Clear()
            cbxActive.SelectedIndex = 0
            txtUserName.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub txtUserID_LostFocus(sender As Object, e As EventArgs) Handles txtUserID.LostFocus
        Try
            If Trim(txtUserID.Text) = "" Then Exit Sub
            ds = Nothing
            ds = New DataSet
            SSQL = ""
            SSQL = "select *  from S2MS..User_Master where CompCode ='" & mvarOrgCode & "' and UserID='" & Trim(txtUserID.Text) & "'"
            ds = ReturnMultipleValue(SSQL, "S2MS", "DB_TAKER")

            If ds.Tables(0).Rows.Count > 0 Then
                txtUserName.Text = ds.Tables(0).Rows(0)("UserName")
                cbxActive.SelectedValue = ds.Tables(0).Rows(0)("IsActive")
            End If

            txtUserName.Focus()
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

            SSQL = ""
            SSQL = "select UserID, UserName,IsActive from s2ms..User_Master where CompCode='" & mvarOrgCode & "'"

            ds = ReturnMultipleValue(SSQL, "S2MS", "DB_TAKER")
            dt = ds.Tables(0)
            Dim frmPickList1 As New FormSearch
            frmPickList1.Text = "User Details Search"
            frmPickList1.Set_Information_Dataset(ds)
            frmPickList1.ShowInTaskbar = False
            frmPickList1.ShowDialog()
            frmPickList1.StartPosition = FormStartPosition.CenterScreen
            frmPickList1.BringToFront()
            If dtPickList Is Nothing OrElse dtPickList.Rows.Count <= 0 Then Exit Sub
            txtUserID.Text = dtPickList.Rows(0)("UserID")
            txtUserName.Text = dtPickList.Rows(0)("UserName")
            cbxActive.SelectedValue = dtPickList.Rows(0)("IsActive")

            txtUserName.Focus()
            Exit Sub
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub btnModify_Click(sender As Object, e As EventArgs) Handles btnModify.Click
        Try
            If Trim(txtUserID.Text) = "" Then
                Show_Message("Error : " & "Please enter user ID.", "S2MS")
                txtUserID.Focus()
                Exit Sub
            End If

            If Trim(txtUserName.Text) = "" Then
                Show_Message("Error : " & "Please enter user name.", "S2MS")
                txtUserName.Focus()
                Exit Sub
            End If

            If Trim(txtPassword.Text) = "" Then
                Show_Message("Error : " & "Please generate password.", "S2MS")
                txtPassword.Focus()
                Exit Sub
            End If

            SSQL = ""
            SSQL = "select isnull(count('x'),0) from S2MS..User_Master where CompCode='" & mvarOrgCode & "' and UserID='" & Trim(txtUserID.Text) & "'"

            Dim mvarDataCount As Integer = ReturnSingleValue(SSQL, "S2MS", "S2MS")

            If mvarDataCount <= 0 Then
                Show_Message("Information : " & "New user information, please save the details.", "S2MS")
                btnModify.Focus()
                Exit Sub
            End If

            Call SaveScreenDetails()

        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub


    Private Sub c1fgRoles_BeforeEdit(sender As Object, e As RowColEventArgs)
        If e.Col = 1 Then
            e.Cancel = True
        End If
    End Sub
End Class