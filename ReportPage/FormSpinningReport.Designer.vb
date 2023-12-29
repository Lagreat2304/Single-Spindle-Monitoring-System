<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSpinningReport
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSpinningReport))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.btnGet = New System.Windows.Forms.Button()
        Me.dtptoDate = New System.Windows.Forms.DateTimePicker()
        Me.dtpFromDate = New System.Windows.Forms.DateTimePicker()
        Me.cbxReportName = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExport = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.c1tdbgInformation = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.c1tdbgReport = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.Panel1.SuspendLayout()
        CType(Me.c1tdbgInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1tdbgReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Panel1.Controls.Add(Me.btnGet)
        Me.Panel1.Controls.Add(Me.dtptoDate)
        Me.Panel1.Controls.Add(Me.dtpFromDate)
        Me.Panel1.Controls.Add(Me.cbxReportName)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1170, 101)
        Me.Panel1.TabIndex = 0
        '
        'btnGet
        '
        Me.btnGet.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnGet.Image = Global.S2MS_Desk.My.Resources.Resources.reset
        Me.btnGet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGet.Location = New System.Drawing.Point(656, 45)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(295, 44)
        Me.btnGet.TabIndex = 6
        Me.btnGet.Text = "&Get"
        Me.btnGet.UseVisualStyleBackColor = False
        '
        'dtptoDate
        '
        Me.dtptoDate.CustomFormat = "dd/MM/yyyy"
        Me.dtptoDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtptoDate.Location = New System.Drawing.Point(450, 50)
        Me.dtptoDate.Name = "dtptoDate"
        Me.dtptoDate.Size = New System.Drawing.Size(200, 30)
        Me.dtptoDate.TabIndex = 5
        '
        'dtpFromDate
        '
        Me.dtpFromDate.CustomFormat = "dd/MM/yyyy"
        Me.dtpFromDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtpFromDate.Location = New System.Drawing.Point(135, 50)
        Me.dtpFromDate.Name = "dtpFromDate"
        Me.dtpFromDate.Size = New System.Drawing.Size(200, 30)
        Me.dtpFromDate.TabIndex = 3
        '
        'cbxReportName
        '
        Me.cbxReportName.BackColor = System.Drawing.SystemColors.ButtonFace
        Me.cbxReportName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxReportName.FormattingEnabled = True
        Me.cbxReportName.Items.AddRange(New Object() {"Spinning Count wise Details", "Spinning Stoppage Machine wise / Reason wise"})
        Me.cbxReportName.Location = New System.Drawing.Point(135, 9)
        Me.cbxReportName.Name = "cbxReportName"
        Me.cbxReportName.Size = New System.Drawing.Size(515, 33)
        Me.cbxReportName.TabIndex = 1
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(339, 53)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(82, 25)
        Me.Label3.TabIndex = 4
        Me.Label3.Text = "To Date"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(26, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(103, 25)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "From Date"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(3, 13)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(126, 25)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Report Name"
        '
        'btnPrint
        '
        Me.btnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnPrint.Image = Global.S2MS_Desk.My.Resources.Resources.print
        Me.btnPrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnPrint.Location = New System.Drawing.Point(137, 675)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(295, 44)
        Me.btnPrint.TabIndex = 2
        Me.btnPrint.Text = "&Print"
        Me.btnPrint.UseVisualStyleBackColor = False
        '
        'btnExport
        '
        Me.btnExport.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnExport.Image = Global.S2MS_Desk.My.Resources.Resources.excel_icon
        Me.btnExport.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExport.Location = New System.Drawing.Point(438, 675)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(295, 44)
        Me.btnExport.TabIndex = 3
        Me.btnExport.Text = "E&xport"
        Me.btnExport.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnClose.Image = Global.S2MS_Desk.My.Resources.Resources._exit
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(739, 675)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(295, 44)
        Me.btnClose.TabIndex = 4
        Me.btnClose.Text = "C&lose"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'c1tdbgInformation
        '
        Me.c1tdbgInformation.AllowUpdate = False
        Me.c1tdbgInformation.AllowUpdateOnBlur = False
        Me.c1tdbgInformation.AlternatingRows = True
        Me.c1tdbgInformation.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.c1tdbgInformation.CaptionHeight = 25
        Me.c1tdbgInformation.FilterBar = True
        Me.c1tdbgInformation.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.c1tdbgInformation.GroupByCaption = "Drag a column header here to group by that column"
        Me.c1tdbgInformation.Images.Add(CType(resources.GetObject("c1tdbgInformation.Images"), System.Drawing.Image))
        Me.c1tdbgInformation.Location = New System.Drawing.Point(5, 105)
        Me.c1tdbgInformation.Margin = New System.Windows.Forms.Padding(4)
        Me.c1tdbgInformation.Name = "c1tdbgInformation"
        Me.c1tdbgInformation.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.c1tdbgInformation.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.c1tdbgInformation.PreviewInfo.ZoomFactor = 75.0R
        Me.c1tdbgInformation.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.c1tdbgInformation.PrintInfo.MeasurementPrinterName = Nothing
        Me.c1tdbgInformation.PrintInfo.PageSettings = CType(resources.GetObject("c1tdbgInformation.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.c1tdbgInformation.RowHeight = 20
        Me.c1tdbgInformation.Size = New System.Drawing.Size(1162, 559)
        Me.c1tdbgInformation.TabIndex = 1
        Me.c1tdbgInformation.UseCompatibleTextRendering = False
        Me.c1tdbgInformation.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Silver
        Me.c1tdbgInformation.PropBag = resources.GetString("c1tdbgInformation.PropBag")
        '
        'c1tdbgReport
        '
        Me.c1tdbgReport.AllowUpdate = False
        Me.c1tdbgReport.AllowUpdateOnBlur = False
        Me.c1tdbgReport.CaptionHeight = 17
        Me.c1tdbgReport.FilterBar = True
        Me.c1tdbgReport.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.c1tdbgReport.GroupByCaption = "Drag a column header here to group by that column"
        Me.c1tdbgReport.Images.Add(CType(resources.GetObject("c1tdbgReport.Images"), System.Drawing.Image))
        Me.c1tdbgReport.Location = New System.Drawing.Point(287, 215)
        Me.c1tdbgReport.Margin = New System.Windows.Forms.Padding(4)
        Me.c1tdbgReport.Name = "c1tdbgReport"
        Me.c1tdbgReport.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.c1tdbgReport.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.c1tdbgReport.PreviewInfo.ZoomFactor = 75.0R
        Me.c1tdbgReport.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.c1tdbgReport.PrintInfo.MeasurementPrinterName = Nothing
        Me.c1tdbgReport.PrintInfo.PageSettings = CType(resources.GetObject("c1tdbgReport.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.c1tdbgReport.RowHeight = 15
        Me.c1tdbgReport.Size = New System.Drawing.Size(597, 296)
        Me.c1tdbgReport.TabIndex = 9
        Me.c1tdbgReport.UseCompatibleTextRendering = False
        Me.c1tdbgReport.PropBag = resources.GetString("c1tdbgReport.PropBag")
        '
        'FormSpinningReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1170, 726)
        Me.Controls.Add(Me.c1tdbgInformation)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnExport)
        Me.Controls.Add(Me.btnPrint)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.c1tdbgReport)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormSpinningReport"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Spinning Report"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        CType(Me.c1tdbgInformation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1tdbgReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents dtptoDate As DateTimePicker
    Friend WithEvents dtpFromDate As DateTimePicker
    Friend WithEvents cbxReportName As ComboBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents btnGet As Button
    Friend WithEvents btnPrint As Button
    Friend WithEvents btnExport As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents c1tdbgInformation As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents c1tdbgReport As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
End Class
