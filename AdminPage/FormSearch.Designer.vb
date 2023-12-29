<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormSearch
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormSearch))
        Me.c1tdbgInformation = New C1.Win.C1TrueDBGrid.C1TrueDBGrid()
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.C1SizerLight1 = New C1.Win.C1Sizer.C1SizerLight(Me.components)
        CType(Me.c1tdbgInformation, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1SizerLight1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'c1tdbgInformation
        '
        Me.c1tdbgInformation.AllowUpdate = False
        Me.c1tdbgInformation.AllowUpdateOnBlur = False
        Me.c1tdbgInformation.AlternatingRows = True
        Me.c1tdbgInformation.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.c1tdbgInformation.CaptionHeight = 20
        Me.c1tdbgInformation.Dock = System.Windows.Forms.DockStyle.Fill
        Me.c1tdbgInformation.FilterBar = True
        Me.c1tdbgInformation.FlatStyle = C1.Win.C1TrueDBGrid.FlatModeEnum.Flat
        Me.c1tdbgInformation.GroupByCaption = "Drag a column header here to group by that column"
        Me.c1tdbgInformation.Images.Add(CType(resources.GetObject("c1tdbgInformation.Images"), System.Drawing.Image))
        Me.c1tdbgInformation.Location = New System.Drawing.Point(0, 0)
        Me.c1tdbgInformation.Margin = New System.Windows.Forms.Padding(4)
        Me.c1tdbgInformation.Name = "c1tdbgInformation"
        Me.c1tdbgInformation.PreviewInfo.Location = New System.Drawing.Point(0, 0)
        Me.c1tdbgInformation.PreviewInfo.Size = New System.Drawing.Size(0, 0)
        Me.c1tdbgInformation.PreviewInfo.ZoomFactor = 75.0R
        Me.c1tdbgInformation.PrintInfo.MeasurementDevice = C1.Win.C1TrueDBGrid.PrintInfo.MeasurementDeviceEnum.Screen
        Me.c1tdbgInformation.PrintInfo.MeasurementPrinterName = Nothing
        Me.c1tdbgInformation.PrintInfo.PageSettings = CType(resources.GetObject("c1tdbgInformation.PrintInfo.PageSettings"), System.Drawing.Printing.PageSettings)
        Me.c1tdbgInformation.RowHeight = 20
        Me.c1tdbgInformation.Size = New System.Drawing.Size(879, 559)
        Me.c1tdbgInformation.TabIndex = 1
        Me.c1tdbgInformation.UseCompatibleTextRendering = False
        Me.c1tdbgInformation.VisualStyle = C1.Win.C1TrueDBGrid.VisualStyle.Office2007Silver
        Me.c1tdbgInformation.PropBag = resources.GetString("c1tdbgInformation.PropBag")
        '
        'FormSearch
        '
        Me.C1SizerLight1.SetAutoResize(Me, True)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(879, 559)
        Me.Controls.Add(Me.c1tdbgInformation)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MinimizeBox = False
        Me.Name = "FormSearch"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Search List"
        CType(Me.c1tdbgInformation, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1SizerLight1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents c1tdbgInformation As C1.Win.C1TrueDBGrid.C1TrueDBGrid
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents C1SizerLight1 As C1.Win.C1Sizer.C1SizerLight
End Class
