Public Class FormCompany
    Private Sub btnClose_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub FormCompany_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            FillScreenDetails()
            btnSave.Enabled = True
            txtCompID.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub FillScreenDetails()
        Try
            SSQL = ""
            SSQL = "select * from s2ms..company_master where CompCode ='" & mvarOrgCode & "'"
            ds = Nothing
            ds = ReturnMultipleValue(SSQL, "s2ms", "s2ms")

            If ds.Tables(0).Rows.Count > 0 Then
                txtCompID.Text = ds.Tables(0).Rows(0)("CompCode")
                txtCompName.Text = ds.Tables(0).Rows(0)("CompName")
                txtCompGroupName.Text = ds.Tables(0).Rows(0)("CompGroupName")
                txtMobileNo.Text = ds.Tables(0).Rows(0)("MobileNo")
                txtEmailID.Text = ds.Tables(0).Rows(0)("EmailID")
                txtURL.Text = ds.Tables(0).Rows(0)("URL")
                txtRegNo.Text = ds.Tables(0).Rows(0)("RegNo")
                txtPANNo.Text = ds.Tables(0).Rows(0)("PANNo")
                txtGSTNo.Text = ds.Tables(0).Rows(0)("GSTNo")
                txtAddressLine1.Text = ds.Tables(0).Rows(0)("AddressLine1")
                txtAddressLine2.Text = ds.Tables(0).Rows(0)("AddressLine2")
                txtAddressLine3.Text = ds.Tables(0).Rows(0)("AddressLine3")
                txtArea.Text = ds.Tables(0).Rows(0)("Area")
                txtCity.Text = ds.Tables(0).Rows(0)("City")
                txtPincode.Text = ds.Tables(0).Rows(0)("Pincode")
                txtState.Text = ds.Tables(0).Rows(0)("State")
                txtCounty.Text = ds.Tables(0).Rows(0)("County")
                txtContactPersonName.Text = ds.Tables(0).Rows(0)("ContactPersonName")
                txtAlternateMobileNo.Text = ds.Tables(0).Rows(0)("AlternateMobileNo")
                cbxActive.Text = ds.Tables(0).Rows(0)("IsActive")
                txtCompID.Focus()
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        Try
            FillScreenDetails()
            btnSave.Enabled = False
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        Try
            Me.Close()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtMobileNo.Clear()
        txtEmailID.Clear()
        txtURL.Clear()
        txtRegNo.Clear()
        txtPANNo.Clear()
        txtGSTNo.Clear()
        txtAddressLine1.Clear()
        txtAddressLine2.Clear()
        txtAddressLine3.Clear()
        txtArea.Clear()
        txtCity.Clear()
        txtPincode.Clear()
        txtState.Clear()
        txtCounty.Clear()
        txtContactPersonName.Clear()
        txtAlternateMobileNo.Clear()
        cbxActive.SelectedIndex = 0
        FillScreenDetails()
        txtCompID.Focus()
    End Sub

    Private Sub FormCompany_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

    Private Sub btnApply_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Trim(txtCompID.Text) = "" Then
                Show_Message("Error : " & "Company ID is mandatory.", "S2MS")
                btnReset.Focus()
                Exit Sub
            End If

            SSQL = ""
            SSQL = "Update s2ms..Company_Master set "
            SSQL = SSQL & "  MobileNo = '" + txtMobileNo.Text & "'"
            SSQL = SSQL & " ,EmailID= '" + txtEmailID.Text & "'"
            SSQL = SSQL & " ,URL= '" + txtURL.Text & "'"
            SSQL = SSQL & " ,RegNo= '" + txtRegNo.Text & "'"
            SSQL = SSQL & " ,PANNo= '" + txtPANNo.Text & "'"
            SSQL = SSQL & " ,GSTNo= '" + txtGSTNo.Text & "'"
            SSQL = SSQL & " ,AddressLine1= '" + txtAddressLine1.Text & "'"
            SSQL = SSQL & " ,AddressLine2= '" + txtAddressLine2.Text & "'"
            SSQL = SSQL & " ,AddressLine3= '" + txtAddressLine3.Text & "'"
            SSQL = SSQL & " ,Area= '" + txtArea.Text & "'"
            SSQL = SSQL & " ,City= '" + txtCity.Text & "'"
            SSQL = SSQL & " ,Pincode= '" + txtPincode.Text & "'"
            SSQL = SSQL & " ,State= '" + txtState.Text & "'"
            SSQL = SSQL & " ,County= '" + txtCounty.Text & "'"
            SSQL = SSQL & " ,ContactPersonName= '" + txtContactPersonName.Text & "'"
            SSQL = SSQL & " ,AlternateMobileNo= '" + txtAlternateMobileNo.Text & "'"
            SSQL = SSQL + " where CompCode ='" & mvarOrgCode & "'"
            Dim i As Integer = InsertDeleteUpdate(SSQL, "s2ms", "s2ms")

            If i >= 1 Then
                Show_Message("Information : " & "Successfully update.", "S2MS")
                txtAddressLine1.Focus()
                Exit Sub
            Else
                Show_Message("Error : " & "Please try again.", "S2MS")
                txtCompID.Focus()
                Exit Sub
            End If
            Exit Sub
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
End Class