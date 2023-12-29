Imports System.Drawing.Drawing2D

Public Class FormChangePassword
    Private Sub FormChangePassword_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtUserID.Text = mvarUserID
            txtNewPassword.Clear()
            txtConfirmPassword.Clear()
            PictureBox1.Visible = False
            lblStrength.Text = ""
            lblStrength.Visible = False
            txtUserID.Focus()
            btnApply.Enabled = False
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub FormChangePassword_KeyDown(sender As Object, e As KeyEventArgs) Handles MyBase.KeyDown
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

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtUserID.Text = mvarUserID
        txtNewPassword.Clear()
        txtConfirmPassword.Clear()
        PictureBox1.Visible = False
        lblStrength.Text = ""
        lblStrength.Visible = False
        btnApply.Enabled = False
        txtUserID.Focus()
    End Sub
    Private Sub formfeatures(ByVal pwf1 As TextBox, ByVal pwf2 As TextBox)
        lblStrength.Visible = pwf1.Text.Length > 0 AndAlso pwf2.Text.Equals(pwf1.Text)
        PictureBox1.Visible = pwf1.Text.Length > 0 AndAlso pwf2.Text.Equals(pwf1.Text)
        btnApply.Enabled = pwf1.Text.Length > 0 OrElse pwf2.Text.Length > 0
    End Sub
    Private Sub txtNewPassword_TextChanged(sender As Object, e As EventArgs) Handles txtNewPassword.TextChanged
        formfeatures(txtNewPassword, txtConfirmPassword)
        'Stop
        Dim passwordStrength As Decimal = txtNewPassword.Text.Length * 2.5

        Dim count As New Dictionary(Of String, Integer)
        count.Add("lowercase", 0)
        count.Add("uppercase", 0)
        count.Add("numbers", 0)
        count.Add("symbols", 0)

        For x As Integer = 0 To txtNewPassword.Text.Length - 1
            If Char.IsLetter(txtNewPassword.Text(x)) And Char.IsLower(txtNewPassword.Text(x)) Then
                count("lowercase") += 1
            End If
            If Char.IsLetter(txtNewPassword.Text(x)) And Char.IsUpper(txtNewPassword.Text(x)) Then
                count("uppercase") += 1
            End If
            If Char.IsDigit(txtNewPassword.Text(x)) Then
                count("numbers") += 1
            End If
            If Char.IsSymbol(txtNewPassword.Text(x)) Or Char.IsPunctuation(txtNewPassword.Text(x)) Then
                count("symbols") += 1
            End If
        Next

        Dim c As Integer = 0
        For Each kvp As KeyValuePair(Of String, Integer) In count
            c += If(kvp.Value > 0, 1, 0)
        Next

        passwordStrength += (If(c = 2, 20, (If(c = 3, 30, (If(c = 4, 50, 0))))))

        If passwordStrength > 0 Then

            Dim img As New Bitmap(300, 20)
            Dim gr As Graphics = Graphics.FromImage(img)
            gr.Clear(SystemColors.Control)

            Dim color As Color = (If(passwordStrength < 50, Color.IndianRed, (If(passwordStrength < 85, Color.GreenYellow, Color.Gold))))
            Dim brush As New LinearGradientBrush(New Rectangle(Point.Empty, New Size(passwordStrength * 3 + 50, 20)), color, SystemColors.Control, LinearGradientMode.Horizontal)
            gr.FillRectangle(brush, New Rectangle(Point.Empty, New Size(passwordStrength * 3 + 50, 20)))
            gr.DrawString((If(passwordStrength < 50, "Poor", (If(passwordStrength < 85, "Sufficient", "Excellent")))), Me.Font, Brushes.Black, 6, 3)

            lblStrength.Image = img
        Else
            lblStrength.Image = Nothing
        End If
    End Sub

    Private Sub txtConfirmPassword_TextChanged(sender As Object, e As EventArgs) Handles txtConfirmPassword.TextChanged
        formfeatures(txtNewPassword, txtConfirmPassword)
    End Sub

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnApply.Click
        Try
            If (txtNewPassword.Text) = "" Then
                Show_Message("Information : " & "Please enter new password.", "S2MS")
                txtNewPassword.Focus()
                Exit Sub
            End If
            If (txtConfirmPassword.Text) = "" Then
                Show_Message("Information : " & "Please enter confirm passowrd.", "S2MS")
                txtConfirmPassword.Focus()
                Exit Sub
            End If
            If (txtNewPassword.Text) <> (txtConfirmPassword.Text) Then
                Show_Message("Information : " & "The new password and confirm password values should be the same. Please check and correct.", "S2MS")
                txtNewPassword.Focus()
                Exit Sub
            End If

            SSQL = ""
            Dim mvarSaveStatus As Integer = 0

            SSQL = "update s2ms..User_Master set E23bRW8Ouv='" & txtNewPassword.Text.Trim() & "'"
            SSQL = SSQL & " where CompCode=" & mvarOrgCode & " and UserID='" & txtUserID.Text.Trim() & "'"

            mvarSaveStatus = InsertDeleteUpdate(SSQL, "s2ms", "s2ms")
            If mvarSaveStatus > 0 Then
                Show_Message("Information : " & "Successfully updated.", "S2MS")
                txtNewPassword.Focus()
                Exit Sub
            Else
                Show_Message("Error : " & "Not updated.", "S2MS")
                txtNewPassword.Focus()
                Exit Sub
            End If

        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
End Class