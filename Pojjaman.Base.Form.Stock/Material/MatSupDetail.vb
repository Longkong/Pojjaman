Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class MatSupDetail
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region " Windows Form Designer generated code "
        'UserControl overrides dispose to clean up the component list.
        Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing Then
                If Not (components Is Nothing) Then
                    components.Dispose()
                End If
            End If
            MyBase.Dispose(disposing)
        End Sub

        'Required by the Windows Form Designer
        Private components As System.ComponentModel.IContainer

        'NOTE: The following procedure is required by the Windows Form Designer
        'It can be modified using the Windows Form Designer.  
        'Do not modify it using the code editor.
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ibtnAdd As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
        Friend WithEvents grbLCI As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblAltName As System.Windows.Forms.Label
        Friend WithEvents txtAltName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtlv1 As System.Windows.Forms.TextBox
        Friend WithEvents lblLCI As System.Windows.Forms.Label
        Friend WithEvents txtlv5 As System.Windows.Forms.TextBox
        Friend WithEvents txtlv4 As System.Windows.Forms.TextBox
        Friend WithEvents txtlv3 As System.Windows.Forms.TextBox
        Friend WithEvents txtlv2 As System.Windows.Forms.TextBox
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MatSupDetail))
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.txtAltName = New System.Windows.Forms.TextBox()
            Me.txtlv1 = New System.Windows.Forms.TextBox()
            Me.txtlv5 = New System.Windows.Forms.TextBox()
            Me.txtlv4 = New System.Windows.Forms.TextBox()
            Me.txtlv3 = New System.Windows.Forms.TextBox()
            Me.txtlv2 = New System.Windows.Forms.TextBox()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.grbLCI = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblAltName = New System.Windows.Forms.Label()
            Me.lblName = New System.Windows.Forms.Label()
            Me.lblLCI = New System.Windows.Forms.Label()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblItem = New System.Windows.Forms.Label()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbLCI.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'tgItem
            '
            Me.tgItem.AllowNew = True
            Me.tgItem.AllowSorting = False
            Me.tgItem.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = True
            Me.tgItem.BackgroundColor = System.Drawing.Color.DimGray
            Me.tgItem.CaptionBackColor = System.Drawing.Color.SaddleBrown
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.GridLineColor = System.Drawing.Color.Wheat
            Me.tgItem.HeaderBackColor = System.Drawing.Color.Gold
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 152)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(736, 248)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 166
            Me.tgItem.TreeManager = Nothing
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'Validator
            '
            Me.Validator.BackcolorChanging = False
            Me.Validator.DataTable = Nothing
            Me.Validator.ErrorProvider = Me.ErrorProvider1
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer))
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(104, 40)
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(248, 21)
            Me.txtName.TabIndex = 2
            '
            'txtAltName
            '
            Me.Validator.SetDataType(Me.txtAltName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAltName, "")
            Me.txtAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAltName, System.Drawing.Color.Empty)
            Me.txtAltName.Location = New System.Drawing.Point(104, 64)
            Me.Validator.SetMaxValue(Me.txtAltName, "")
            Me.Validator.SetMinValue(Me.txtAltName, "")
            Me.txtAltName.Name = "txtAltName"
            Me.Validator.SetRegularExpression(Me.txtAltName, "")
            Me.Validator.SetRequired(Me.txtAltName, False)
            Me.txtAltName.Size = New System.Drawing.Size(248, 21)
            Me.txtAltName.TabIndex = 3
            '
            'txtlv1
            '
            Me.txtlv1.BackColor = System.Drawing.SystemColors.Info
            Me.Validator.SetDataType(Me.txtlv1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv1, "")
            Me.txtlv1.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv1, System.Drawing.Color.Empty)
            Me.txtlv1.Location = New System.Drawing.Point(104, 16)
            Me.txtlv1.MaxLength = 2
            Me.Validator.SetMaxValue(Me.txtlv1, "")
            Me.Validator.SetMinValue(Me.txtlv1, "")
            Me.txtlv1.Name = "txtlv1"
            Me.txtlv1.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtlv1, "")
            Me.Validator.SetRequired(Me.txtlv1, False)
            Me.txtlv1.Size = New System.Drawing.Size(24, 23)
            Me.txtlv1.TabIndex = 163
            '
            'txtlv5
            '
            Me.txtlv5.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtlv5, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv5, "")
            Me.txtlv5.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv5, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv5, System.Drawing.Color.Empty)
            Me.txtlv5.Location = New System.Drawing.Point(200, 16)
            Me.txtlv5.MaxLength = 15
            Me.Validator.SetMaxValue(Me.txtlv5, "")
            Me.Validator.SetMinValue(Me.txtlv5, "")
            Me.txtlv5.Name = "txtlv5"
            Me.Validator.SetRegularExpression(Me.txtlv5, "")
            Me.Validator.SetRequired(Me.txtlv5, False)
            Me.txtlv5.Size = New System.Drawing.Size(152, 23)
            Me.txtlv5.TabIndex = 167
            '
            'txtlv4
            '
            Me.txtlv4.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtlv4, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv4, "")
            Me.txtlv4.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv4, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv4, System.Drawing.Color.Empty)
            Me.txtlv4.Location = New System.Drawing.Point(176, 16)
            Me.txtlv4.MaxLength = 2
            Me.Validator.SetMaxValue(Me.txtlv4, "")
            Me.Validator.SetMinValue(Me.txtlv4, "")
            Me.txtlv4.Name = "txtlv4"
            Me.txtlv4.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtlv4, "")
            Me.Validator.SetRequired(Me.txtlv4, False)
            Me.txtlv4.Size = New System.Drawing.Size(24, 23)
            Me.txtlv4.TabIndex = 166
            '
            'txtlv3
            '
            Me.txtlv3.BackColor = System.Drawing.SystemColors.Info
            Me.Validator.SetDataType(Me.txtlv3, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv3, "")
            Me.txtlv3.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv3, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv3, System.Drawing.Color.Empty)
            Me.txtlv3.Location = New System.Drawing.Point(152, 16)
            Me.txtlv3.MaxLength = 2
            Me.Validator.SetMaxValue(Me.txtlv3, "")
            Me.Validator.SetMinValue(Me.txtlv3, "")
            Me.txtlv3.Name = "txtlv3"
            Me.txtlv3.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtlv3, "")
            Me.Validator.SetRequired(Me.txtlv3, False)
            Me.txtlv3.Size = New System.Drawing.Size(24, 23)
            Me.txtlv3.TabIndex = 165
            '
            'txtlv2
            '
            Me.txtlv2.BackColor = System.Drawing.SystemColors.Info
            Me.Validator.SetDataType(Me.txtlv2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtlv2, "")
            Me.txtlv2.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtlv2, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtlv2, System.Drawing.Color.Empty)
            Me.txtlv2.Location = New System.Drawing.Point(128, 16)
            Me.txtlv2.MaxLength = 2
            Me.Validator.SetMaxValue(Me.txtlv2, "")
            Me.Validator.SetMinValue(Me.txtlv2, "")
            Me.txtlv2.Name = "txtlv2"
            Me.txtlv2.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtlv2, "")
            Me.Validator.SetRequired(Me.txtlv2, False)
            Me.txtlv2.Size = New System.Drawing.Size(24, 23)
            Me.txtlv2.TabIndex = 164
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnBlank.Location = New System.Drawing.Point(8, 400)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(32, 32)
            Me.ibtnBlank.TabIndex = 206
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnDelRow.Location = New System.Drawing.Point(40, 400)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(32, 32)
            Me.ibtnDelRow.TabIndex = 205
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
            '
            'grbLCI
            '
            Me.grbLCI.Controls.Add(Me.txtName)
            Me.grbLCI.Controls.Add(Me.lblAltName)
            Me.grbLCI.Controls.Add(Me.txtAltName)
            Me.grbLCI.Controls.Add(Me.lblName)
            Me.grbLCI.Controls.Add(Me.txtlv1)
            Me.grbLCI.Controls.Add(Me.lblLCI)
            Me.grbLCI.Controls.Add(Me.txtlv5)
            Me.grbLCI.Controls.Add(Me.txtlv4)
            Me.grbLCI.Controls.Add(Me.txtlv3)
            Me.grbLCI.Controls.Add(Me.txtlv2)
            Me.grbLCI.Enabled = False
            Me.grbLCI.Location = New System.Drawing.Point(16, 24)
            Me.grbLCI.Name = "grbLCI"
            Me.grbLCI.Size = New System.Drawing.Size(368, 96)
            Me.grbLCI.TabIndex = 178
            Me.grbLCI.TabStop = False
            Me.grbLCI.Text = "LCI"
            '
            'lblAltName
            '
            Me.lblAltName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAltName.ForeColor = System.Drawing.Color.Black
            Me.lblAltName.Location = New System.Drawing.Point(8, 64)
            Me.lblAltName.Name = "lblAltName"
            Me.lblAltName.Size = New System.Drawing.Size(96, 18)
            Me.lblAltName.TabIndex = 8
            Me.lblAltName.Text = "�������:"
            Me.lblAltName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(8, 40)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(96, 18)
            Me.lblName.TabIndex = 11
            Me.lblName.Text = "����:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblLCI
            '
            Me.lblLCI.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLCI.ForeColor = System.Drawing.Color.Black
            Me.lblLCI.Location = New System.Drawing.Point(16, 16)
            Me.lblLCI.Name = "lblLCI"
            Me.lblLCI.Size = New System.Drawing.Size(88, 20)
            Me.lblLCI.TabIndex = 168
            Me.lblLCI.Text = "LCI Code:"
            Me.lblLCI.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.ibtnBlank)
            Me.grbDetail.Controls.Add(Me.ibtnDelRow)
            Me.grbDetail.Controls.Add(Me.tgItem)
            Me.grbDetail.Controls.Add(Me.lblItem)
            Me.grbDetail.Controls.Add(Me.grbLCI)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(752, 448)
            Me.grbDetail.TabIndex = 179
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "��������´"
            '
            'lblItem
            '
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 136)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(72, 18)
            Me.lblItem.TabIndex = 165
            Me.lblItem.Text = "Supplier:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'MatSupDetail
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "MatSupDetail"
            Me.Size = New System.Drawing.Size(776, 464)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbLCI.ResumeLayout(False)
            Me.grbLCI.PerformLayout()
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As LCIItem
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
#End Region

#Region "Constructor"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            Dim dt As TreeTable = LCISupplierCostLink.GetSchemaTable
            Dim dst As DataGridTableStyle = Me.CreateTableStyle
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            EventWiring()
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "SupplierCost"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "lcis_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "lcis_linenumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.CodeHeaderText}")
            csCode.NullText = ""
            'csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"
            csCode.Width = 200

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""

            Dim csName As New TreeTextColumn
            csName.MappingName = "Name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.NameHeaderText}")
            csName.NullText = ""
            csName.Width = 180
            csName.TextBox.Name = "Name"
            'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
            csName.ReadOnly = True

            Dim csContact As New TreeTextColumn
            csContact.MappingName = "Contact"
            csContact.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.ContactHeaderText}")
            csContact.NullText = ""
            csContact.Width = 180
            csContact.TextBox.Name = "Contact"
            'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
            csContact.ReadOnly = True

            Dim csPhone As New TreeTextColumn
            csPhone.MappingName = "Phone"
            csPhone.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.PhoneHeaderText}")
            csPhone.NullText = ""
            csPhone.Width = 180
            csPhone.TextBox.Name = "Phone"
            'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
            csPhone.ReadOnly = True

            Dim csCost As New TreeTextColumn
            csCost.MappingName = "lcis_cost"
            csCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.CostHeaderText}")
            csCost.NullText = ""
            csCost.DataAlignment = HorizontalAlignment.Right
            csCost.Format = "#,###.##"
            csCost.TextBox.Name = "lcis_cost"
            'AddHandler csCost.TextBox.TextChanged, AddressOf ChangeProperty

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.UnitHeaderText}")
            csUnit.NullText = ""
            csUnit.TextBox.Name = "Unit"
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csUnitButton As New DataGridButtonColumn
            csUnitButton.MappingName = "UnitButton"
            csUnitButton.HeaderText = ""
            csUnitButton.NullText = ""
            AddHandler csUnitButton.Click, AddressOf ButtonClicked

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "lcis_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.DataAlignment = HorizontalAlignment.Right
            csNote.Format = "#,###.##"
            csNote.TextBox.Name = "lcis_note"
            'AddHandler csCost.TextBox.TextChanged, AddressOf ChangeProperty

            Dim csLeadTime As New TreeTextColumn
            csLeadTime.MappingName = "lcis_leadtime"
            csLeadTime.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.LeadTimeHeaderText}")
            csLeadTime.NullText = ""
            csLeadTime.DataAlignment = HorizontalAlignment.Right
            csLeadTime.Format = "0"
            csLeadTime.TextBox.Name = "lcis_leadtime"
            'AddHandler csCost.TextBox.TextChanged, AddressOf ChangeProperty

            Dim csCostDate As New DataGridTimePickerColumn
            csCostDate.MappingName = "lcis_costdate"
            csCostDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.CostDateHeaderText}")
            csCostDate.NullText = ""


            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csContact)
            dst.GridColumnStyles.Add(csPhone)
            dst.GridColumnStyles.Add(csCost)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csUnitButton)
            dst.GridColumnStyles.Add(csNote)
            dst.GridColumnStyles.Add(csLeadTime)
            dst.GridColumnStyles.Add(csCostDate)
            Return dst
        End Function
        Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 2 Then
                Me.SupplierButtonClick(e)
            Else
                Me.UnitButtonClick(e)
            End If
        End Sub
#End Region

#Region "Properties"

#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            'If Me.m_entity.Canceled Then
            '    For Each ctrl As Control In grbLCI.Controls
            '        ctrl.Enabled = False
            '    Next
            'Else
            '    For Each ctrl As Control In grbLCI.Controls
            '        ctrl.Enabled = True
            '    Next
            'End If
        End Sub

        Public Overrides Sub ClearDetail()
            'Todo:
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.lblItem}")
            Me.lblAltName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.lblAltName}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.lblName}")
            Me.grbLCI.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.grbLCI}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatSupDetail.grbDetail}")
        End Sub
        Protected Overrides Sub EventWiring()
            '����ա�ü١��������ͧ���
        End Sub
        ' �ʴ���Ң����Ţͧ�١���ŧ� control ������躹�����
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If
            If m_entity.LCISupplierCostLink Is Nothing Then
                Return
            End If

            txtName.Text = m_entity.Name
            txtAltName.Text = m_entity.AlternateName
            txtlv1.Text = m_entity.Lv1
            txtlv2.Text = m_entity.Lv2
            txtlv3.Text = m_entity.Lv3
            txtlv4.Text = m_entity.Lv4
            txtlv5.Text = m_entity.Lv5

            'Load Items**********************************************************
            Me.m_treeManager.Treetable = Nothing
            Me.m_treeManager.Treetable = Me.m_entity.LCISupplierCostLink.ItemTable
            AddHandler Me.m_entity.LCISupplierCostLink.PropertyChanged, AddressOf PropChanged
            Me.Validator.DataTable = m_treeManager.Treetable
            '********************************************************************

            RefreshBlankGrid()

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If e.Name = "ItemChanged" Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Private m_dateSetting As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetStatus()

        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not Object.ReferenceEquals(Me.m_entity, Value) Then
                    Me.m_entity = Nothing
                    Me.m_entity = CType(Value, LCIItem)
                    If Not Me.m_entity.LCISupplierCostLink Is Nothing Then
                        RemoveHandler Me.m_entity.LCISupplierCostLink.PropertyChanged, AddressOf PropChanged
                    End If
                End If
                If Not Me.m_entity.LCISupplierCostLink Is Nothing Then
                    Me.m_entity.LCISupplierCostLink.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                End If
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()
            'PopulateRequestor()
            'PopulateCostCenter()
        End Sub


#End Region

#Region "Event Handlers"
        Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
            If m_entity Is Nothing Then
                Return
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filters(0) As Filter
            Dim includeFilter As Boolean = False
            Dim idList As String = Me.m_entity.GetUnitIdList
            If idList.Length > 0 Then
                filters(0) = New Filter("includedId", idList)
            Else
                filters(0) = New Filter("includedId", "-1")
            End If
            myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
        End Sub
        Private Sub SetUnit(ByVal unit As ISimpleEntity)
            Me.m_treeManager.SelectedRow("Unit") = unit.Code
        End Sub
        Public Sub SupplierButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filters(0) As Filter
            filters(0) = New Filter("IDList", GenIDListFromDataTable())
            myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetItems, filters)
        End Sub
        Private Function GenIDListFromDataTable() As String
            Dim idlist As String = ""
            For Each row As TreeRow In Me.m_entity.LCISupplierCostLink.ItemTable.Rows
                If Not IsDBNull(row("lcis_supplier")) Then
                    idlist &= CStr(row("lcis_supplier")) & ","
                End If
            Next
            If idlist.EndsWith(",") Then
                idlist = idlist.Remove(idlist.Length - 1, 1)
            End If
            Return idlist
        End Function
        Private Sub SetItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As BasketItem = CType(items(i), BasketItem)
                If i = items.Count - 1 Then
                    If Me.m_entity.LCISupplierCostLink.ItemTable.Childs.Count = 0 Then
                        Me.m_entity.LCISupplierCostLink.AddBlankRow(1)
                        Me.m_entity.LCISupplierCostLink.ItemTable.Childs(0)("Code") = item.Code
                    Else
                        Me.m_entity.LCISupplierCostLink.ItemTable.Childs(index)("Code") = item.Code
                    End If
                Else
                    Me.m_entity.LCISupplierCostLink.Insert(index, New LCISupplierCostLinkItem)
                    Me.m_entity.LCISupplierCostLink.ItemTable.Childs(index)("Code") = item.Code
                End If
                Me.m_entity.LCISupplierCostLink.ItemTable.AcceptChanges()
            Next
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim myItem As New LCISupplierCostLinkItem
            myItem.Supplier = New Supplier
            myItem.Cost = 0
            Me.m_entity.LCISupplierCostLink.Insert(index, myItem)
            Me.m_entity.LCISupplierCostLink.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Me.m_entity.LCISupplierCostLink.Remove(index)
            Me.tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
#End Region

#Region "IValidatable"
        Public ReadOnly Property FormValidator() As components.PJMTextboxValidator Implements IValidatable.FormValidator
            Get
                Return Me.Validator
            End Get
        End Property
#End Region

#Region "Overrides"
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
        Return "Icons.16x16.MatSupDetail"
            End Get
        End Property
#End Region

#Region "Grid Resizing"
        Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Me.m_entity.LCISupplierCostLink Is Nothing Then
                Return
            End If
            RefreshBlankGrid()
        End Sub
        Private Sub RefreshBlankGrid()
            If Me.tgItem.Height = 0 Then
                Return
            End If
            Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            Dim index As Integer = tgItem.CurrentRowIndex

            Do Until Me.m_entity.LCISupplierCostLink.ItemTable.Rows.Count > tgItem.VisibleRowCount
                '�����Ǩ����
                Me.m_entity.LCISupplierCostLink.AddBlankRow(1)
            Loop

            'MessageBox.Show(tgItem.VisibleRowCount.ToString & ":" & Me.m_entity.ItemTable.Childs.Count.ToString)

            If Me.m_entity.LCISupplierCostLink.MaxRowIndex = Me.m_entity.LCISupplierCostLink.ItemTable.Childs.Count - 1 Then
                '�����ա 1 �� ����բ����Ũ��֧���ش����
                Me.m_entity.LCISupplierCostLink.AddBlankRow(1)
            End If
            Me.m_entity.LCISupplierCostLink.ItemTable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

#Region "After the main entity has been saved"
        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            'If Not successful Then
            '    Return
            'End If
            'Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
        Public Overrides Sub NotifyBeforeSave()
            '    MyBase.NotifyBeforeSave()
            '    Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
#End Region

  End Class
End Namespace