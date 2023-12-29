Imports System.Net
Imports System.Data
Imports Newtonsoft.Json
Imports Newtonsoft.Json.Linq
Imports C1.Win.TreeView
Imports System.Reflection
Imports System
Imports System.Diagnostics


Public Class FormMain
    Private WithEvents client As MdiClient
    Private Sub FormMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.DoubleBuffered = True

        For Each ctl As Control In Me.Controls
            If TypeOf ctl Is MdiClient Then
                'ctl.BackColor = Color.FromArgb(69, 98, 104)
                'ctl.BackColor = Color.FromArgb(69, 98, 104)
                'ctl.BackColor = Color.White
                ctl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
                ctl.BackgroundImage = S2MS_Desk.My.Resources.Resources._IMG1399
                Dim method As MethodInfo = DirectCast(ctl, MdiClient).[GetType]().GetMethod("SetStyle", BindingFlags.Instance Or BindingFlags.NonPublic)
                method.Invoke(DirectCast(ctl, MdiClient), New [Object]() {ControlStyles.OptimizedDoubleBuffer, True})

            End If
        Next ctl
        Me.client = Me.Controls.OfType(Of MdiClient).First()

        LabelUserName.Text = "Welcome " + mvarUserName + " !" '+ vbNewLine
        LabelDate.Text = Format(Now, "dd/MMM/yyyy")


        C1TreeView1.CollapseAll()

        mvarServerDate = ReturnSingleValue("select format(GETDATE(),'yyyy/MM/dd')", "s2ms", "s2ms")

        Timer1.Start()
        Timer2.Start()
        Timer2.Enabled = True

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        LabelDate.Text = Format(Now, "dd-MMM-yyyy hh:mm:ss tt").ToString()
    End Sub

    Private currentForm As Form = Nothing
    Private Sub openChildForm(childForm As Form)
        If currentForm IsNot Nothing Then currentForm.Close()
        'currentForm = childForm
        'childForm.TopLevel = False
        'childForm.TopMost = True
        ''childForm.FormBorderStyle = FormBorderStyle.None
        ''childForm.Dock = DockStyle.Fill
        ''PanelChildForm.Controls.Add(childForm)
        ''PanelChildForm.Tag = childForm
        'childForm.BringToFront()
        'FormAlign(childForm)
        'childForm.Show()
        For Each currentForm As Form In Me.MdiChildren
            If childForm.GetType Is currentForm.GetType Then
                currentForm.Activate()
                Return
            End If
        Next
        childForm.MdiParent = Me
        childForm.BringToFront()
        childForm.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub FormMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        End
    End Sub
    Private Sub C1TreeView1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles C1TreeView1.MouseDoubleClick
        'Dim node = C1TreeView1.GetNodeAtPoint(e.Location)
        'Dim currentNode As C1TreeNode
        'currentNode = node

        Dim node = C1TreeView1.GetNodeAtPoint(e.Location)
        Dim nodeName As String = Trim(node.GetValue())
        Select Case nodeName
            Case "Company Master"
                openChildForm(New FormCompany())
            Case "Location Master"
                openChildForm(New FormLocation())
            Case "User Master"
                openChildForm(New FormUser())
            Case "Shift Master"
                openChildForm(New FormShift())
            Case "Count Master"
                openChildForm(New FormCount())
            Case "Stoppage Master"
                openChildForm(New FormStoppage())
            Case "Machine Master"
                openChildForm(New FormMachine())
            Case "Spinning Report"
                openChildForm(New FormSpinningReport())
            Case Else
                Exit Sub
        End Select
    End Sub

    Private Sub C1Command1_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1Command1.Click
        openChildForm(New FormChangePassword())
    End Sub

    Private Sub C1Command2_Click(sender As Object, e As C1.Win.C1Command.ClickEventArgs) Handles C1Command2.Click
        Me.Close()
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        Timer2.Stop()
        Timer2.Start()
    End Sub

    Private Sub btnSend_Click(sender As Object, e As EventArgs) Handles btnSend.Click

    End Sub

    Private Sub btnSingleSpindleView_Click(sender As Object, e As EventArgs) Handles btnSingleSpindleView.Click
        openChildForm(New FormSpindleView())
    End Sub

    Private Sub LnkLabelAbout_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LnkLabelAbout.LinkClicked
        Process.Start("https://www.fitlog.in")
    End Sub

    Private Sub PBXMinimize_Click(sender As Object, e As EventArgs) Handles PBXMinimize.Click
        Me.WindowState = FormWindowState.Minimized
    End Sub
End Class