Public Class FormLogin
    Dim TimerCount As Integer
    Private Sub FormLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            tbUserId.Clear()
            tbPassword.Clear()
            tbUserId.Text = "rkvcit@gmail.com"
            tbPassword.Text = "rkv@2304"
            TimerCount = 1
            Timer1.Enabled = True
            Timer1.Start()
            FillComboBox()
            tbUserId.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub

    Private Sub FillComboBox()

        cbxUserType.SelectedIndex = 0

        Dim comboSourceOrganisation As New Dictionary(Of String, String)()
        comboSourceOrganisation.Add("LS SPIN", "L.S.SPINNING MILLS PRIVATE LIMITED")
        cbxOrganisation.Items.Clear()
        cbxOrganisation.DataSource = New BindingSource(comboSourceOrganisation, Nothing)
        cbxOrganisation.DisplayMember = "Value"
        cbxOrganisation.ValueMember = "Key"
        cbxOrganisation.SelectedIndex = 0
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Try
            Application.Exit()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Try
            If tbUserId.Text.Trim = "" Then
                Show_Message("Error : " & "Please enter user id.", "OneConnect")
                tbUserId.Focus()
                Exit Sub
            End If
            If tbPassword.Text.Trim = "" Then
                Show_Message("Error : " & "Please enter password.", "OneConnect")
                tbPassword.Focus()
                Exit Sub
            End If
            If cbxUserType.Text.Trim = "" Then
                Show_Message("Error : " & "Please select user type.", "OneConnect")
                cbxUserType.Focus()
                Exit Sub
            End If

            SSQL = ""
            SSQL = "select UserName from User_Master where CompCode='" & cbxOrganisation.SelectedValue & "'"
            SSQL = SSQL & " and UserID='" & Trim(tbUserId.Text) & "' and UserPwd='" & Trim(tbPassword.Text) & "' and IsActive='YES'"


            Dim LoginValidationString As String = ReturnSingleValue(SSQL, "s2ms", "s2ms")

            If LoginValidationString = "False" Then
                Show_Message("Error : " & "Please check your user id and password.", "OneConnect")
                tbUserId.Focus()
                Exit Sub
            End If
            mvarUserID = UCase(tbUserId.Text)
            mvarUserName = UCase(LoginValidationString)
            mvarOrgCode = cbxOrganisation.SelectedValue
            mvarOrgName = cbxOrganisation.Text

            FormMain.Show()
            Me.Hide()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "OneConnect")
        End Try
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If TimerCount = 1 Then
            LabelOne.Text = "Red Lamps on both sides of the machine for higher breaks. Green Lamp for indicating machine doff status."
            LabelTwo.Text = "Very useful for operator to pay attention on machines immediately with higher breaks user configurable limits for No. Of end breaks limit for each machine."
            TimerCount = TimerCount + 1
        ElseIf TimerCount = 2 Then
            LabelOne.Text = "Draft Monitoring sensors on both sides of the Ring frame to continuously monitor the draft rations."
            LabelTwo.Text = "1. Effectively monitor draft variations." & vbNewLine & "2. Easier to find out machines with wrong draft wheels."
            TimerCount = TimerCount + 1
        ElseIf TimerCount = 3 Then
            LabelOne.Text = "Monitors the total power consumption by the ring frame along with other key parameters."
            LabelTwo.Text = "1. Measures active power (kW), Energy (kWh)and the power factor (Cos)." & vbNewLine & "2. Very effective module to measure power related differences between machines."
            TimerCount = 1
        End If
    End Sub
End Class
