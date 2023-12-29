Public Class FormLocation
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ds = Nothing
            ds = New DataSet
            dt = Nothing
            dt = New DataTable
            dtPickList = Nothing

            SSQL = ""
            SSQL = "select Production_Location_code	as [LocationID],Production_Location_Desc as [LocationName],IsActive "
            SSQL = SSQL & " from s2ms..Esp_Location_Details where Comp_Code='" & mvarOrgCode & "'"

            ds = ReturnMultipleValue(SSQL, "s2ms", "s2ms")
            dt = ds.Tables(0)
            Dim frmPickList1 As New FormSearch
            frmPickList1.Text = "Location Search"
            frmPickList1.Set_Information_Dataset(ds)
            frmPickList1.ShowInTaskbar = False
            frmPickList1.ShowDialog()
            frmPickList1.StartPosition = FormStartPosition.CenterScreen
            frmPickList1.BringToFront()
            If dtPickList Is Nothing OrElse dtPickList.Rows.Count <= 0 Then Exit Sub
            txtLocationID.Text = dtPickList.Rows(0)("LocationID")
            txtLocationName.Text = dtPickList.Rows(0)("LocationName")
            cbxActive.Text = IIf(dtPickList.Rows(0)("IsActive") = "1", "YES", "NO")
            txtLocationName.Focus()
            Exit Sub
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub FormLocation_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtLocationID.Clear()
            txtLocationName.Clear()
            cbxActive.SelectedIndex = 0
            btnSave.Enabled = True
            btnSearch.Enabled = True
            txtLocationID.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            txtLocationID.Clear()
            txtLocationName.Clear()
            cbxActive.SelectedIndex = 0
            btnSave.Enabled = True
            btnSearch.Enabled = True
            txtLocationID.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub SaveScreenDetails()
        Try
            Dim mvarGetString As String = mvarOrgCode + "||" +
                                   txtLocationID.Text.Trim + "||" +
                                   txtLocationName.Text.Trim + "||" +
                                   IIf(cbxActive.Text = "YES", "1", "0") + "||"

            Dim clsLocation As New ClassLocation

            Dim LoginValidationString As String = clsLocation.SaveLocationDetails(mvarGetString)

            Dim mSplitString() As String = Split(LoginValidationString, "||")

            If mSplitString(0) <> "Success" Then
                Show_Message("Error : " & "Please try again.", "S2MS")
                txtLocationName.Focus()
                Exit Sub
            Else
                Show_Message("Information : " & "Successfully saved.", "S2MS")
                txtLocationID.Text = mSplitString(3)
                txtLocationID.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            If Trim(txtLocationID.Text) = "" Then
                Show_Message("Information : " & "Please enter the location ID.", "S2MS")
                txtLocationID.Focus()
                Exit Sub
            End If
            If Trim(txtLocationName.Text) = "" Then
                Show_Message("Information : " & "Please enter the location Name.", "S2MS")
                txtLocationName.Focus()
                Exit Sub
            End If
            Call SaveScreenDetails()

        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub FormLocation_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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