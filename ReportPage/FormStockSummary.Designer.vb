<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormStockSummary
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormStockSummary))
        Me.txtItemCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.btnGet = New System.Windows.Forms.Button()
        Me.c1fgItem = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.btnExcel = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.c1tdbgReport = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        CType(Me.c1fgItem, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.c1tdbgReport, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'txtItemCode
        '
        Me.txtItemCode.Location = New System.Drawing.Point(118, 14)
        Me.txtItemCode.Name = "txtItemCode"
        Me.txtItemCode.Size = New System.Drawing.Size(417, 30)
        Me.txtItemCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(12, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Item Code"
        '
        'btnGet
        '
        Me.btnGet.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnGet.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.btnGet.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGet.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGet.ForeColor = System.Drawing.Color.Black
        Me.btnGet.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnGet.Location = New System.Drawing.Point(603, 13)
        Me.btnGet.Name = "btnGet"
        Me.btnGet.Size = New System.Drawing.Size(117, 33)
        Me.btnGet.TabIndex = 3
        Me.btnGet.Text = "Get"
        Me.btnGet.UseVisualStyleBackColor = False
        '
        'c1fgItem
        '
        Me.c1fgItem.AllowFiltering = True
        Me.c1fgItem.BackColorSel = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.c1fgItem.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.c1fgItem.ColumnInfo = "10,1,0,0,0,-1,Columns:"
        Me.c1fgItem.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse
        Me.c1fgItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.c1fgItem.ForeColorSel = System.Drawing.SystemColors.ControlText
        Me.c1fgItem.GridColorFixed = System.Drawing.SystemColors.ControlDark
        Me.c1fgItem.Location = New System.Drawing.Point(11, 63)
        Me.c1fgItem.Margin = New System.Windows.Forms.Padding(2)
        Me.c1fgItem.Name = "c1fgItem"
        Me.c1fgItem.NodeClosedPicture = Nothing
        Me.c1fgItem.NodeOpenPicture = Nothing
        Me.c1fgItem.OutlineCol = -1
        Me.c1fgItem.Size = New System.Drawing.Size(863, 569)
        Me.c1fgItem.StyleInfo = resources.GetString("c1fgItem.StyleInfo")
        Me.c1fgItem.TabIndex = 4
        Me.c1fgItem.TreeColor = System.Drawing.Color.DarkGray
        Me.c1fgItem.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'btnExcel
        '
        Me.btnExcel.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnExcel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnExcel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnExcel.ForeColor = System.Drawing.Color.Black
        Me.btnExcel.Image = Global.S2MS_Desk.My.Resources.Resources.excel_icon
        Me.btnExcel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnExcel.Location = New System.Drawing.Point(198, 646)
        Me.btnExcel.Margin = New System.Windows.Forms.Padding(2)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(158, 68)
        Me.btnExcel.TabIndex = 5
        Me.btnExcel.Text = "&Excel"
        Me.btnExcel.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Image = Global.S2MS_Desk.My.Resources.Resources._exit
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(528, 646)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(158, 68)
        Me.btnClose.TabIndex = 7
        Me.btnClose.Text = "C&lose"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Image = Global.S2MS_Desk.My.Resources.Resources._erase
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(363, 646)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(158, 68)
        Me.btnClear.TabIndex = 6
        Me.btnClear.Text = "&Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnSearch.BackgroundImage = Global.S2MS_Desk.My.Resources.Resources.magnify_search_zoom_icon
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(554, 14)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(36, 31)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.UseVisualStyleBackColor = False
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
        Me.c1tdbgReport.Location = New System.Drawing.Point(227, 224)
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
        Me.c1tdbgReport.TabIndex = 8
        Me.c1tdbgReport.UseCompatibleTextRendering = False
        Me.c1tdbgReport.PropBag = resources.GetString("c1tdbgReport.PropBag")
        '
        'FormStockSummary
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(884, 725)
        Me.Controls.Add(Me.btnExcel)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.c1fgItem)
        Me.Controls.Add(Me.btnGet)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.txtItemCode)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.c1tdbgReport)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormStockSummary"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Stock Summary"
        CType(Me.c1fgItem, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.c1tdbgReport, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnSearch As Button
    Friend WithEvents txtItemCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents btnGet As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents c1fgItem As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic
    Friend WithEvents btnExcel As Button
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents c1tdbgReport As C1.Win.C1TrueDBGrid.C1TrueDBGrid
End Class
