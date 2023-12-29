Public Class ClassInputBox
    Public Function Show(ByVal title As String, ByVal promptText As String, ByRef value As String) As DialogResult
        Dim form As Form = New Form()
        Dim label As Label = New Label()
        Dim textBox As TextBox = New TextBox()
        Dim buttonOk As Button = New Button()
        Dim buttonCancel As Button = New Button()

        form.Text = title
        label.Text = promptText
        textBox.Text = value

        buttonOk.Text = "OK"
        buttonCancel.Text = "Cancel"
        buttonOk.BackColor = Color.FromArgb(42, 62, 67)
        buttonCancel.BackColor = Color.FromArgb(42, 62, 67)
        buttonOk.ForeColor = Color.White
        buttonCancel.ForeColor = Color.White
        buttonOk.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
        buttonCancel.Font = New Font("Microsoft Sans Serif", 8, FontStyle.Regular)
        buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK
        buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel

        label.SetBounds(9, 20, 372, 13)
        textBox.SetBounds(12, 36, 372, 20)
        buttonOk.SetBounds(228, 72, 75, 23)
        buttonCancel.SetBounds(309, 72, 75, 23)

        label.AutoSize = True
        textBox.Anchor = textBox.Anchor Or AnchorStyles.Right
        buttonOk.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right
        buttonCancel.Anchor = AnchorStyles.Bottom Or AnchorStyles.Right

        'form.BackColor = Color.FromArgb(69, 98, 104)
        form.ShowIcon = False
        Form2.ShowInTaskbar = False
        form.ClientSize = New Size(396, 110)
        form.Controls.AddRange(New Control() {label, textBox, buttonOk, buttonCancel})
        form.ClientSize = New Size(Math.Max(300, label.Right + 10), form.ClientSize.Height)
        form.FormBorderStyle = FormBorderStyle.FixedDialog
        form.StartPosition = FormStartPosition.CenterScreen
        form.MinimizeBox = False
        form.MaximizeBox = False
        form.AcceptButton = buttonOk
        form.CancelButton = buttonCancel

        Dim dialogResult As DialogResult = form.ShowDialog()
        value = textBox.Text
        Return dialogResult
    End Function
End Class
