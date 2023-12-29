Public Class FormShift
    Private Sub FormShift_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Try
            txtShiftID.Clear()
            txtShiftCode.Clear()
            txtShiftDesc.Clear()
            btnSave.Enabled = True
            btnSearch.Enabled = True
            txtShiftCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        Try
            txtShiftID.Clear()
            txtShiftCode.Clear()
            txtShiftDesc.Clear()
            btnSave.Enabled = True
            btnSearch.Enabled = True
            txtShiftCode.Focus()
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub FormShift_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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
    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Try
            ds = Nothing
            ds = New DataSet
            dt = Nothing
            dt = New DataTable
            dtPickList = Nothing

            SSQL = ""
            SSQL = "select Shift_ID as [ShiftID], Shift as [ShiftCode], Shift_Code as [ShiftDesc] from Esp_Shift_Details Where Comp_Code ='" & mvarOrgCode & "'"

            ds = ReturnMultipleValue(SSQL, "s2ms", "s2ms")
            dt = ds.Tables(0)
            Dim frmPickList1 As New FormSearch
            frmPickList1.Text = "Shift Search"
            frmPickList1.Set_Information_Dataset(ds)
            frmPickList1.ShowInTaskbar = False
            frmPickList1.ShowDialog()
            frmPickList1.StartPosition = FormStartPosition.CenterScreen
            frmPickList1.BringToFront()
            If dtPickList Is Nothing OrElse dtPickList.Rows.Count <= 0 Then Exit Sub
            txtShiftID.Text = dtPickList.Rows(0)("ShiftID")
            txtShiftCode.Text = dtPickList.Rows(0)("ShiftCode")
            txtShiftDesc.Text = dtPickList.Rows(0)("ShiftDesc")
            txtShiftCode.Focus()
            Exit Sub
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Try
            Dim mvarDataCount As Integer = 1

            If Trim(txtShiftID.Text) = "" Then
                mvarDataCount = 0
                SSQL = ""
                SSQL = "Select isnull(max(Shift_ID),0) +1 from Esp_Shift_Details Where Comp_Code ='" & mvarOrgCode & "'"
                txtShiftID.Text = ReturnSingleValue(SSQL, "s2ms", "s2ms")
            End If

            If Trim(txtShiftCode.Text) = "" Then
                Show_Message("Error : " & "Please enter shft code.", "S2MS")
                txtShiftCode.Focus()
                Exit Sub
            End If

            If Trim(txtShiftDesc.Text) = "" Then
                Show_Message("Error : " & "Please enter shift description..", "S2MS")
                txtShiftDesc.Focus()
                Exit Sub
            End If

            If mvarDataCount > 0 Then
                SSQL = ""
                SSQL = "update S2MS..Esp_Shift_Details set"
                SSQL = SSQL & " Shift='" & Trim(txtShiftCode.Text) & "',"
                SSQL = SSQL & " Shift_Code='" & Trim(txtShiftDesc.Text) & "'"
                SSQL = SSQL & " where Comp_Code='" & mvarOrgCode & "' and Shift_ID='" & Trim(txtShiftID.Text) & "'"
            Else
                SSQL = ""
                SSQL = "insert into S2MS..Esp_Shift_Details (Comp_Code,Shift_Id,Shift,Shift_Code)"
                SSQL = SSQL & " select '" & mvarOrgCode & "',"
                SSQL = SSQL & "'" & Trim(txtShiftID.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtShiftCode.Text) & "',"
                SSQL = SSQL & "'" & Trim(txtShiftDesc.Text) & "'"
            End If

            Dim i As Integer = InsertDeleteUpdate(SSQL, "S2MS", "S2MS")

            If i >= 1 Then
                Show_Message("Information : " & "Successfully saved.", "S2MS")
                txtShiftCode.Focus()
                Exit Sub
            Else
                Show_Message("Error : " & "Please try again.", "S2MS")
                txtShiftCode.Focus()
                Exit Sub
            End If
        Catch ex As Exception
            Show_Message("Error : " & ex.Message.ToString, "S2MS")
        End Try
    End Sub
End Class