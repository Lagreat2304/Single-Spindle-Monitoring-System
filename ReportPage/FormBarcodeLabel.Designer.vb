<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormBarcodeLabel
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormBarcodeLabel))
        Me.cbxLocation = New System.Windows.Forms.ComboBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.c1fgAssetDetails = New C1.Win.C1FlexGrid.Classic.C1FlexGridClassic()
        Me.rbtnLandscape = New System.Windows.Forms.RadioButton()
        Me.rbtnPortrait = New System.Windows.Forms.RadioButton()
        Me.btnAssetDetails = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnBarcodePrint = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        CType(Me.c1fgAssetDetails, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'cbxLocation
        '
        Me.cbxLocation.BackColor = System.Drawing.Color.White
        Me.cbxLocation.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxLocation.ForeColor = System.Drawing.Color.Black
        Me.cbxLocation.FormattingEnabled = True
        Me.cbxLocation.Items.AddRange(New Object() {"AD HOC PO", "STANDARD PO"})
        Me.cbxLocation.Location = New System.Drawing.Point(98, 11)
        Me.cbxLocation.Margin = New System.Windows.Forms.Padding(2)
        Me.cbxLocation.Name = "cbxLocation"
        Me.cbxLocation.Size = New System.Drawing.Size(390, 33)
        Me.cbxLocation.TabIndex = 1
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(10, 18)
        Me.Label4.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(81, 24)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Location"
        '
        'c1fgAssetDetails
        '
        Me.c1fgAssetDetails.AllowFiltering = True
        Me.c1fgAssetDetails.BackColorSel = System.Drawing.Color.FromArgb(CType(CType(183, Byte), Integer), CType(CType(219, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.c1fgAssetDetails.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.XpThemes
        Me.c1fgAssetDetails.ColumnInfo = "10,1,0,0,0,-1,Columns:"
        Me.c1fgAssetDetails.Editable = C1.Win.C1FlexGrid.Classic.EditableSettings.flexEDKbdMouse
        Me.c1fgAssetDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.c1fgAssetDetails.ForeColorSel = System.Drawing.SystemColors.ControlText
        Me.c1fgAssetDetails.GridColorFixed = System.Drawing.SystemColors.ControlDark
        Me.c1fgAssetDetails.Location = New System.Drawing.Point(1, 62)
        Me.c1fgAssetDetails.Margin = New System.Windows.Forms.Padding(2)
        Me.c1fgAssetDetails.Name = "c1fgAssetDetails"
        Me.c1fgAssetDetails.NodeClosedPicture = Nothing
        Me.c1fgAssetDetails.NodeOpenPicture = Nothing
        Me.c1fgAssetDetails.OutlineCol = -1
        Me.c1fgAssetDetails.Size = New System.Drawing.Size(908, 391)
        Me.c1fgAssetDetails.StyleInfo = resources.GetString("c1fgAssetDetails.StyleInfo")
        Me.c1fgAssetDetails.TabIndex = 3
        Me.c1fgAssetDetails.TreeColor = System.Drawing.Color.DarkGray
        Me.c1fgAssetDetails.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2010Blue
        '
        'rbtnLandscape
        '
        Me.rbtnLandscape.BackColor = System.Drawing.Color.Aqua
        Me.rbtnLandscape.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnLandscape.ForeColor = System.Drawing.Color.Black
        Me.rbtnLandscape.Location = New System.Drawing.Point(14, 515)
        Me.rbtnLandscape.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnLandscape.Name = "rbtnLandscape"
        Me.rbtnLandscape.Size = New System.Drawing.Size(118, 31)
        Me.rbtnLandscape.TabIndex = 6
        Me.rbtnLandscape.Text = "Landscape"
        Me.rbtnLandscape.UseVisualStyleBackColor = False
        '
        'rbtnPortrait
        '
        Me.rbtnPortrait.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(128, Byte), Integer))
        Me.rbtnPortrait.Checked = True
        Me.rbtnPortrait.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.rbtnPortrait.ForeColor = System.Drawing.Color.Black
        Me.rbtnPortrait.Location = New System.Drawing.Point(14, 476)
        Me.rbtnPortrait.Margin = New System.Windows.Forms.Padding(4)
        Me.rbtnPortrait.Name = "rbtnPortrait"
        Me.rbtnPortrait.Size = New System.Drawing.Size(118, 31)
        Me.rbtnPortrait.TabIndex = 5
        Me.rbtnPortrait.TabStop = True
        Me.rbtnPortrait.Text = "Portrait"
        Me.rbtnPortrait.UseVisualStyleBackColor = False
        '
        'btnAssetDetails
        '
        Me.btnAssetDetails.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnAssetDetails.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnAssetDetails.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnAssetDetails.ForeColor = System.Drawing.Color.Black
        Me.btnAssetDetails.Image = Global.S2MS_Desk.My.Resources.Resources.print
        Me.btnAssetDetails.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnAssetDetails.Location = New System.Drawing.Point(351, 476)
        Me.btnAssetDetails.Margin = New System.Windows.Forms.Padding(2)
        Me.btnAssetDetails.Name = "btnAssetDetails"
        Me.btnAssetDetails.Size = New System.Drawing.Size(158, 68)
        Me.btnAssetDetails.TabIndex = 8
        Me.btnAssetDetails.Text = "&Asset"
        Me.btnAssetDetails.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Image = Global.S2MS_Desk.My.Resources.Resources._exit
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(681, 476)
        Me.btnClose.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(158, 68)
        Me.btnClose.TabIndex = 4
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
        Me.btnClear.Location = New System.Drawing.Point(516, 476)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(158, 68)
        Me.btnClear.TabIndex = 9
        Me.btnClear.Text = "&Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnBarcodePrint
        '
        Me.btnBarcodePrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(163, Byte), Integer), CType(CType(220, Byte), Integer))
        Me.btnBarcodePrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBarcodePrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBarcodePrint.ForeColor = System.Drawing.Color.Black
        Me.btnBarcodePrint.Image = Global.S2MS_Desk.My.Resources.Resources.barcode_box_line_icon
        Me.btnBarcodePrint.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnBarcodePrint.Location = New System.Drawing.Point(186, 476)
        Me.btnBarcodePrint.Margin = New System.Windows.Forms.Padding(2)
        Me.btnBarcodePrint.Name = "btnBarcodePrint"
        Me.btnBarcodePrint.Size = New System.Drawing.Size(158, 68)
        Me.btnBarcodePrint.TabIndex = 7
        Me.btnBarcodePrint.Text = "&Barcode"
        Me.btnBarcodePrint.UseVisualStyleBackColor = False
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
        Me.btnSearch.Location = New System.Drawing.Point(494, 11)
        Me.btnSearch.Margin = New System.Windows.Forms.Padding(2)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(36, 35)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'FormBarcodeLabel
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(113, Byte), Integer), CType(CType(188, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(924, 562)
        Me.Controls.Add(Me.btnAssetDetails)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnBarcodePrint)
        Me.Controls.Add(Me.rbtnLandscape)
        Me.Controls.Add(Me.rbtnPortrait)
        Me.Controls.Add(Me.c1fgAssetDetails)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.cbxLocation)
        Me.Controls.Add(Me.Label4)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormBarcodeLabel"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Barcode Label View & Print"
        CType(Me.c1fgAssetDetails, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents cbxLocation As ComboBox
    Friend WithEvents Label4 As Label
    Friend WithEvents btnSearch As Button
    Friend WithEvents c1fgAssetDetails As C1.Win.C1FlexGrid.Classic.C1FlexGridClassic
    Friend WithEvents rbtnLandscape As RadioButton
    Friend WithEvents rbtnPortrait As RadioButton
    Friend WithEvents btnAssetDetails As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnBarcodePrint As Button
End Class
