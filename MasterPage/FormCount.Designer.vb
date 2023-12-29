<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormCount
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormCount))
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtCountDesc = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCountCode = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cbxActive = New System.Windows.Forms.ComboBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.btnClose = New System.Windows.Forms.Button()
        Me.btnClear = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.txtCountName = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbxProductType = New System.Windows.Forms.ComboBox()
        Me.cbxSalesType = New System.Windows.Forms.ComboBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.cbxUOM = New System.Windows.Forms.ComboBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtBarcode = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtCommodity = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.White
        Me.Label19.Location = New System.Drawing.Point(32, 159)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(116, 24)
        Me.Label19.TabIndex = 17
        Me.Label19.Text = "Active Status"
        '
        'txtCountDesc
        '
        Me.txtCountDesc.Location = New System.Drawing.Point(151, 45)
        Me.txtCountDesc.Name = "txtCountDesc"
        Me.txtCountDesc.Size = New System.Drawing.Size(864, 30)
        Me.txtCountDesc.TabIndex = 6
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.White
        Me.Label2.Location = New System.Drawing.Point(44, 47)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(104, 24)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "Description"
        '
        'txtCountCode
        '
        Me.txtCountCode.Location = New System.Drawing.Point(151, 9)
        Me.txtCountCode.Name = "txtCountCode"
        Me.txtCountCode.Size = New System.Drawing.Size(237, 30)
        Me.txtCountCode.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.White
        Me.Label1.Location = New System.Drawing.Point(37, 11)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(111, 24)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Count Code"
        '
        'cbxActive
        '
        Me.cbxActive.BackColor = System.Drawing.Color.White
        Me.cbxActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxActive.ForeColor = System.Drawing.Color.Black
        Me.cbxActive.FormattingEnabled = True
        Me.cbxActive.Items.AddRange(New Object() {"YES", "NO"})
        Me.cbxActive.Location = New System.Drawing.Point(151, 156)
        Me.cbxActive.Name = "cbxActive"
        Me.cbxActive.Size = New System.Drawing.Size(237, 33)
        Me.cbxActive.TabIndex = 18
        '
        'btnSearch
        '
        Me.btnSearch.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnSearch.BackgroundImage = Global.S2MS_Desk.My.Resources.Resources.magnify_search_zoom_icon
        Me.btnSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center
        Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSearch.ForeColor = System.Drawing.Color.Black
        Me.btnSearch.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSearch.Location = New System.Drawing.Point(390, 8)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(36, 31)
        Me.btnSearch.TabIndex = 2
        Me.btnSearch.UseVisualStyleBackColor = False
        '
        'btnClose
        '
        Me.btnClose.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClose.ForeColor = System.Drawing.Color.Black
        Me.btnClose.Image = Global.S2MS_Desk.My.Resources.Resources._exit
        Me.btnClose.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClose.Location = New System.Drawing.Point(578, 215)
        Me.btnClose.Name = "btnClose"
        Me.btnClose.Size = New System.Drawing.Size(114, 67)
        Me.btnClose.TabIndex = 21
        Me.btnClose.Text = "C&lose"
        Me.btnClose.UseVisualStyleBackColor = False
        '
        'btnClear
        '
        Me.btnClear.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClear.ForeColor = System.Drawing.Color.Black
        Me.btnClear.Image = Global.S2MS_Desk.My.Resources.Resources._erase
        Me.btnClear.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnClear.Location = New System.Drawing.Point(458, 215)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(114, 67)
        Me.btnClear.TabIndex = 20
        Me.btnClear.Text = "&Clear"
        Me.btnClear.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.FromArgb(CType(CType(214, Byte), Integer), CType(CType(115, Byte), Integer), CType(CType(124, Byte), Integer))
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.ForeColor = System.Drawing.Color.Black
        Me.btnSave.Image = Global.S2MS_Desk.My.Resources.Resources.save_fill_data_icon
        Me.btnSave.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.btnSave.Location = New System.Drawing.Point(338, 215)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(114, 67)
        Me.btnSave.TabIndex = 19
        Me.btnSave.Text = "&Save"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'txtCountName
        '
        Me.txtCountName.Location = New System.Drawing.Point(548, 9)
        Me.txtCountName.Name = "txtCountName"
        Me.txtCountName.Size = New System.Drawing.Size(467, 30)
        Me.txtCountName.TabIndex = 4
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.White
        Me.Label3.Location = New System.Drawing.Point(430, 11)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(116, 24)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Count Name"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.ForeColor = System.Drawing.Color.White
        Me.Label4.Location = New System.Drawing.Point(25, 85)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(123, 24)
        Me.Label4.TabIndex = 7
        Me.Label4.Text = "Product Type"
        '
        'cbxProductType
        '
        Me.cbxProductType.BackColor = System.Drawing.Color.White
        Me.cbxProductType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxProductType.ForeColor = System.Drawing.Color.Black
        Me.cbxProductType.FormattingEnabled = True
        Me.cbxProductType.Items.AddRange(New Object() {"FINISHED", "WASTE", "YARN"})
        Me.cbxProductType.Location = New System.Drawing.Point(151, 81)
        Me.cbxProductType.Name = "cbxProductType"
        Me.cbxProductType.Size = New System.Drawing.Size(237, 33)
        Me.cbxProductType.TabIndex = 8
        '
        'cbxSalesType
        '
        Me.cbxSalesType.BackColor = System.Drawing.Color.White
        Me.cbxSalesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxSalesType.ForeColor = System.Drawing.Color.Black
        Me.cbxSalesType.FormattingEnabled = True
        Me.cbxSalesType.Items.AddRange(New Object() {"FINISHED", "SEMI FINISHED", "YARN"})
        Me.cbxSalesType.Location = New System.Drawing.Point(504, 81)
        Me.cbxSalesType.Name = "cbxSalesType"
        Me.cbxSalesType.Size = New System.Drawing.Size(237, 33)
        Me.cbxSalesType.TabIndex = 10
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.White
        Me.Label5.Location = New System.Drawing.Point(395, 85)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(104, 24)
        Me.Label5.TabIndex = 9
        Me.Label5.Text = "Sales Type"
        '
        'cbxUOM
        '
        Me.cbxUOM.BackColor = System.Drawing.Color.White
        Me.cbxUOM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cbxUOM.ForeColor = System.Drawing.Color.Black
        Me.cbxUOM.FormattingEnabled = True
        Me.cbxUOM.Items.AddRange(New Object() {"10 LBS", "BAGS", "BOXES", "KGS"})
        Me.cbxUOM.Location = New System.Drawing.Point(807, 81)
        Me.cbxUOM.Name = "cbxUOM"
        Me.cbxUOM.Size = New System.Drawing.Size(208, 33)
        Me.cbxUOM.TabIndex = 12
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.White
        Me.Label6.Location = New System.Drawing.Point(747, 85)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(54, 24)
        Me.Label6.TabIndex = 11
        Me.Label6.Text = "UOM"
        '
        'txtBarcode
        '
        Me.txtBarcode.Location = New System.Drawing.Point(504, 120)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(511, 30)
        Me.txtBarcode.TabIndex = 16
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.White
        Me.Label7.Location = New System.Drawing.Point(418, 122)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(81, 24)
        Me.Label7.TabIndex = 15
        Me.Label7.Text = "Barcode"
        '
        'txtCommodity
        '
        Me.txtCommodity.Location = New System.Drawing.Point(151, 120)
        Me.txtCommodity.Name = "txtCommodity"
        Me.txtCommodity.Size = New System.Drawing.Size(237, 30)
        Me.txtCommodity.TabIndex = 14
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.ForeColor = System.Drawing.Color.White
        Me.Label8.Location = New System.Drawing.Point(43, 122)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(105, 24)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "Commodity"
        '
        'FormCount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(190, Byte), Integer), CType(CType(30, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(1031, 292)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.txtCommodity)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.cbxUOM)
        Me.Controls.Add(Me.cbxSalesType)
        Me.Controls.Add(Me.cbxProductType)
        Me.Controls.Add(Me.txtCountName)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.btnSearch)
        Me.Controls.Add(Me.btnClose)
        Me.Controls.Add(Me.btnClear)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.Label19)
        Me.Controls.Add(Me.cbxActive)
        Me.Controls.Add(Me.txtCountDesc)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.txtCountCode)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.White
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormCount"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Count Master"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnSearch As Button
    Friend WithEvents btnClose As Button
    Friend WithEvents btnClear As Button
    Friend WithEvents btnSave As Button
    Friend WithEvents Label19 As Label
    Friend WithEvents txtCountDesc As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents txtCountCode As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cbxActive As ComboBox
    Friend WithEvents txtCountName As TextBox
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents cbxProductType As ComboBox
    Friend WithEvents cbxSalesType As ComboBox
    Friend WithEvents Label5 As Label
    Friend WithEvents cbxUOM As ComboBox
    Friend WithEvents Label6 As Label
    Friend WithEvents txtBarcode As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents txtCommodity As TextBox
    Friend WithEvents Label8 As Label
End Class
