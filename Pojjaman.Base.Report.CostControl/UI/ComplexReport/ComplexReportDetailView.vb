Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Gui.ReportsAndDocs

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class ComplexReportDetailView
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
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents grbCompanyName As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents txtCompanyName As System.Windows.Forms.TextBox
        Friend WithEvents txtHeader As System.Windows.Forms.TextBox
        Friend WithEvents lblHeader As System.Windows.Forms.Label
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents lblName As System.Windows.Forms.Label
        Friend WithEvents txtCondition As System.Windows.Forms.TextBox
        Friend WithEvents lblCondition As System.Windows.Forms.Label
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents rdOption As System.Windows.Forms.RadioButton
        Friend WithEvents rdCustom As System.Windows.Forms.RadioButton
        Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(ComplexReportDetailView))
            Me.txtCompanyName = New System.Windows.Forms.TextBox
            Me.lblItem = New System.Windows.Forms.Label
            Me.txtHeader = New System.Windows.Forms.TextBox
            Me.lblHeader = New System.Windows.Forms.Label
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.txtName = New System.Windows.Forms.TextBox
            Me.txtCondition = New System.Windows.Forms.TextBox
            Me.txtNote = New System.Windows.Forms.TextBox
            Me.chkAutorun = New System.Windows.Forms.CheckBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.lblName = New System.Windows.Forms.Label
            Me.grbCompanyName = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.rdCustom = New System.Windows.Forms.RadioButton
            Me.rdOption = New System.Windows.Forms.RadioButton
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
            Me.lblCondition = New System.Windows.Forms.Label
            Me.lblNote = New System.Windows.Forms.Label
            Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.grbCompanyName.SuspendLayout()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'txtCompanyName
            '
            Me.Validator.SetDataType(Me.txtCompanyName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCompanyName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCompanyName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCompanyName, System.Drawing.Color.Empty)
            Me.txtCompanyName.Location = New System.Drawing.Point(80, 40)
            Me.txtCompanyName.MaxLength = 100
            Me.Validator.SetMaxValue(Me.txtCompanyName, "")
            Me.Validator.SetMinValue(Me.txtCompanyName, "")
            Me.txtCompanyName.Name = "txtCompanyName"
            Me.Validator.SetRegularExpression(Me.txtCompanyName, "")
            Me.Validator.SetRequired(Me.txtCompanyName, False)
            Me.txtCompanyName.Size = New System.Drawing.Size(208, 20)
            Me.txtCompanyName.TabIndex = 2
            Me.txtCompanyName.Text = ""
            '
            'lblItem
            '
            Me.lblItem.BackColor = System.Drawing.Color.Transparent
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 168)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(112, 18)
            Me.lblItem.TabIndex = 15
            Me.lblItem.Text = "��¡���Ѻ�ҧ���:"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtHeader
            '
            Me.txtHeader.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtHeader, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtHeader, "")
            Me.Validator.SetGotFocusBackColor(Me.txtHeader, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtHeader, System.Drawing.Color.Empty)
            Me.txtHeader.Location = New System.Drawing.Point(96, 63)
            Me.txtHeader.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtHeader, "")
            Me.Validator.SetMinValue(Me.txtHeader, "")
            Me.txtHeader.Name = "txtHeader"
            Me.Validator.SetRegularExpression(Me.txtHeader, "")
            Me.Validator.SetRequired(Me.txtHeader, False)
            Me.txtHeader.Size = New System.Drawing.Size(288, 20)
            Me.txtHeader.TabIndex = 3
            Me.txtHeader.Text = ""
            '
            'lblHeader
            '
            Me.lblHeader.BackColor = System.Drawing.Color.Transparent
            Me.lblHeader.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblHeader.Location = New System.Drawing.Point(0, 64)
            Me.lblHeader.Name = "lblHeader"
            Me.lblHeader.Size = New System.Drawing.Size(96, 18)
            Me.lblHeader.TabIndex = 12
            Me.lblHeader.Text = "���������§ҹ:"
            Me.lblHeader.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.Validator.GotFocusBackColor = System.Drawing.Color.FromArgb(CType(192, Byte), CType(255, Byte), CType(255, Byte))
            Me.Validator.HasNewRow = False
            Me.Validator.InvalidBackColor = System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte))
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(96, 15)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCode, "")
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, True)
            Me.txtCode.Size = New System.Drawing.Size(88, 21)
            Me.txtCode.TabIndex = 0
            Me.txtCode.TabStop = False
            Me.txtCode.Text = ""
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(96, 39)
            Me.txtName.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtName, "")
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(288, 21)
            Me.txtName.TabIndex = 2
            Me.txtName.TabStop = False
            Me.txtName.Text = ""
            '
            'txtCondition
            '
            Me.txtCondition.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCondition, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCondition, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCondition, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCondition, System.Drawing.Color.Empty)
            Me.txtCondition.Location = New System.Drawing.Point(96, 87)
            Me.txtCondition.MaxLength = 200
            Me.Validator.SetMaxValue(Me.txtCondition, "")
            Me.Validator.SetMinValue(Me.txtCondition, "")
            Me.txtCondition.Name = "txtCondition"
            Me.Validator.SetRegularExpression(Me.txtCondition, "")
            Me.Validator.SetRequired(Me.txtCondition, False)
            Me.txtCondition.Size = New System.Drawing.Size(288, 20)
            Me.txtCondition.TabIndex = 4
            Me.txtCondition.Text = ""
            '
            'txtNote
            '
            Me.txtNote.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(96, 111)
            Me.txtNote.MaxLength = 1000
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtNote.Size = New System.Drawing.Size(288, 42)
            Me.txtNote.TabIndex = 5
            Me.txtNote.Text = ""
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(184, 15)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 9
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(0, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(96, 18)
            Me.lblCode.TabIndex = 8
            Me.lblCode.Text = "�Ţ���:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblName
            '
            Me.lblName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblName.ForeColor = System.Drawing.Color.Black
            Me.lblName.Location = New System.Drawing.Point(0, 40)
            Me.lblName.Name = "lblName"
            Me.lblName.Size = New System.Drawing.Size(96, 18)
            Me.lblName.TabIndex = 11
            Me.lblName.Text = "������§ҹ:"
            Me.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbCompanyName
            '
            Me.grbCompanyName.Controls.Add(Me.rdCustom)
            Me.grbCompanyName.Controls.Add(Me.rdOption)
            Me.grbCompanyName.Controls.Add(Me.txtCompanyName)
            Me.grbCompanyName.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbCompanyName.Location = New System.Drawing.Point(392, 8)
            Me.grbCompanyName.Name = "grbCompanyName"
            Me.grbCompanyName.Size = New System.Drawing.Size(304, 72)
            Me.grbCompanyName.TabIndex = 6
            Me.grbCompanyName.TabStop = False
            Me.grbCompanyName.Text = "�����"
            '
            'rdCustom
            '
            Me.rdCustom.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdCustom.Location = New System.Drawing.Point(8, 40)
            Me.rdCustom.Name = "rdCustom"
            Me.rdCustom.Size = New System.Drawing.Size(72, 24)
            Me.rdCustom.TabIndex = 1
            Me.rdCustom.Text = "��˹��ͧ"
            '
            'rdOption
            '
            Me.rdOption.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.rdOption.Location = New System.Drawing.Point(8, 16)
            Me.rdOption.Name = "rdOption"
            Me.rdOption.Size = New System.Drawing.Size(176, 24)
            Me.rdOption.TabIndex = 0
            Me.rdOption.Text = "����ͨҡ��á�˹���ҷ����"
            '
            'ibtnBlank
            '
            Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
            Me.ibtnBlank.Location = New System.Drawing.Point(120, 160)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 16
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
            Me.ibtnDelRow.Location = New System.Drawing.Point(144, 160)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 17
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'tgItem
            '
            Me.tgItem.AllowNew = False
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = False
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 184)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(784, 208)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 7
            Me.tgItem.TreeManager = Nothing
            '
            'lblCondition
            '
            Me.lblCondition.BackColor = System.Drawing.Color.Transparent
            Me.lblCondition.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCondition.Location = New System.Drawing.Point(0, 88)
            Me.lblCondition.Name = "lblCondition"
            Me.lblCondition.Size = New System.Drawing.Size(96, 18)
            Me.lblCondition.TabIndex = 13
            Me.lblCondition.Text = "���͹�:"
            Me.lblCondition.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblNote
            '
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(0, 112)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(96, 18)
            Me.lblNote.TabIndex = 14
            Me.lblNote.Text = "�����˵�:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnCopyMe
            '
            Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnCopyMe.Image = CType(resources.GetObject("ibtnCopyMe.Image"), System.Drawing.Image)
            Me.ibtnCopyMe.Location = New System.Drawing.Point(208, 14)
            Me.ibtnCopyMe.Name = "ibtnCopyMe"
            Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
            Me.ibtnCopyMe.TabIndex = 328
            Me.ibtnCopyMe.TabStop = False
            Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
            '
            'ComplexReportDetailView
            '
            Me.Controls.Add(Me.ibtnCopyMe)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.grbCompanyName)
            Me.Controls.Add(Me.chkAutorun)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.txtCode)
            Me.Controls.Add(Me.lblName)
            Me.Controls.Add(Me.txtName)
            Me.Controls.Add(Me.txtHeader)
            Me.Controls.Add(Me.lblHeader)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.txtCondition)
            Me.Controls.Add(Me.lblCondition)
            Me.Controls.Add(Me.txtNote)
            Me.Controls.Add(Me.lblNote)
            Me.Name = "ComplexReportDetailView"
            Me.Size = New System.Drawing.Size(808, 400)
            Me.grbCompanyName.ResumeLayout(False)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Members"
        Private m_entity As ComplexReport
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager

        Private m_tableStyleEnable As Hashtable

        Private m_enableState As Hashtable
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            SaveEnableState()
            Dim dt As TreeTable = ComplexReport.GetColumnSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False
            tgItem.AllowNew = False

            AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete

            EventWiring()
        End Sub
        Private Sub SaveEnableState()
            m_enableState = New Hashtable
            For Each ctrl As Control In Me.grbCompanyName.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
            For Each ctrl As Control In Me.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
        End Sub
#End Region

#Region "Style"
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "ComplexReportColumn"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "crptc_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "crptc_linenumber"

            Dim csName As New TreeTextColumn
            csName.MappingName = "crptc_name"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.NameHeaderText}")
            csName.NullText = ""
            csName.TextBox.Name = "crptc_name"

            Dim csWidthPercent As New TreeTextColumn
            csWidthPercent.MappingName = "crptc_widthpercent"
            csWidthPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.WidthPercentHeaderText}")
            csWidthPercent.NullText = ""
            csWidthPercent.DataAlignment = HorizontalAlignment.Right
            csWidthPercent.Format = "#,###.##"
            csWidthPercent.TextBox.Name = "RealAmount"

            Dim csAlignment As DataGridComboColumn
            csAlignment = New DataGridComboColumn("crptc_alignment", CodeDescription.GetCodeList("HAlignment"), "code_description", "code_value")
            csAlignment.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.AlignmentHeaderText}")
            csAlignment.Width = 70
            csAlignment.NullText = String.Empty

            Dim csStartDate As New DataGridTimePickerColumn
            csStartDate.MappingName = "crptc_startdate"
            csStartDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.StartDateHeaderText}")
            csStartDate.NullText = ""
            'csStartDate.ReadOnly = True

            Dim csEndDate As New DataGridTimePickerColumn
            csEndDate.MappingName = "crptc_enddate"
            csEndDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.EndDateHeaderText}")
            csEndDate.NullText = ""
            'csEndDate.ReadOnly = True

            Dim csCCCode As New TreeTextColumn
            csCCCode.MappingName = "CCCode"
            csCCCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.CCCodeHeaderText}")
            csCCCode.NullText = ""
            csCCCode.TextBox.Name = "CCCode"
            csCCCode.Width = 60
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csCCButton As New DataGridButtonColumn
            csCCButton.MappingName = "CCButton"
            csCCButton.HeaderText = ""
            csCCButton.NullText = ""
            AddHandler csCCButton.Click, AddressOf CCClicked

            Dim csCCName As New TreeTextColumn
            csCCName.MappingName = "CCName"
            csCCName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.CCNameHeaderText}")
            csCCName.NullText = ""
            csCCName.TextBox.Name = "CCName"
            csCCName.ReadOnly = True
            csCCName.Width = 100

            Dim csIncludeChildCC As New DataGridCheckBoxColumn(9)
            csIncludeChildCC.MappingName = "crptc_includechildcc"
            csIncludeChildCC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.IncludeChildCCHeaderText}")
            csIncludeChildCC.Width = 50
            csIncludeChildCC.InvisibleWhenUnspcified = True

            Dim csLCICode As New TreeTextColumn
            csLCICode.MappingName = "LCICode"
            csLCICode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.LCICodeHeaderText}")
            csLCICode.NullText = ""
            csLCICode.Width = 60
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csLCIButton As New DataGridButtonColumn
            csLCIButton.MappingName = "LCIButton"
            csLCIButton.HeaderText = ""
            csLCIButton.NullText = ""

            Dim csLCIName As New TreeTextColumn
            csLCIName.MappingName = "LCIName"
            csLCIName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.LCINameHeaderText}")
            csLCIName.NullText = ""
            csLCIName.TextBox.Name = "LCIName"
            csLCIName.ReadOnly = True
            csLCIName.Width = 100

            Dim csOther As New DataGridCheckBoxColumn(13)
            csOther.MappingName = "crptc_isnotlci"
            csOther.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.IsNotLCIHeaderText}")
            csOther.Width = 50
            csOther.InvisibleWhenUnspcified = True

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csWidthPercent)
            dst.GridColumnStyles.Add(csAlignment)
            dst.GridColumnStyles.Add(csStartDate)
            dst.GridColumnStyles.Add(csEndDate)
            dst.GridColumnStyles.Add(csCCCode)
            dst.GridColumnStyles.Add(csCCButton)
            dst.GridColumnStyles.Add(csCCName)
            dst.GridColumnStyles.Add(csIncludeChildCC)
            dst.GridColumnStyles.Add(csLCICode)
            dst.GridColumnStyles.Add(csLCIButton)
            dst.GridColumnStyles.Add(csLCIName)
            dst.GridColumnStyles.Add(csOther)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
        Public Sub CCClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 7 Then
                CCButtonClick(e)
            ElseIf e.Column = 11 Then
                LCIButtonClick(e)
            End If
        End Sub
        Public Sub CCButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCC)
        End Sub
        Private Sub SetCC(ByVal cc As ISimpleEntity)
            Me.m_treeManager.SelectedRow("CCCode") = cc.Code
        End Sub
        Public Sub LCIButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetLCI)
        End Sub
        Private Sub SetLCI(ByVal cc As ISimpleEntity)
            Me.m_treeManager.SelectedRow("LCICode") = cc.Code
        End Sub
#End Region

#Region "Properties"
        Private ReadOnly Property CurrentItem() As ComplexReportColumn
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is ComplexReportColumn Then
                    Return Nothing
                End If
                Return CType(row.Tag, ComplexReportColumn)
            End Get
        End Property
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                Me.m_treeManager.Treetable.AcceptChanges()
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_isInitialized Then
                Return
            End If
            If Me.m_treeManager.SelectedRow Is Nothing Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.CurrentItem Is Nothing Then
                Dim doc As New ComplexReportColumn
                Me.m_entity.ColumnCollection.Add(doc)
                Me.m_treeManager.SelectedRow.Tag = doc
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "crptc_name"
                        SetName(e)
                    Case "crptc_widthpercent"
                        SetWidthPercent(e)
                    Case "crptc_alignment"
                        SetAlignment(e)
                    Case "crptc_startdate"
                        SetStartDate(e)
                    Case "crptc_enddate"
                        SetEndDate(e)
                    Case "cccode"
                        SetCostCenterValue(e)
                    Case "crptc_includechildcc"
                        Me.CurrentItem.IncludeChildCostCenter = CBool(e.ProposedValue)
                    Case "lcicode"
                        SetLCIValue(e)
                    Case "crptc_isnotlci"
                        Me.CurrentItem.IsNotLci = CBool(e.ProposedValue)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim crptc_name As Object = e.Row("crptc_name")
            Dim crptc_alignment As Object = e.Row("crptc_alignment")
            Dim crptc_widthpercent As Object = e.Row("crptc_widthpercent")
            Dim crptc_startdate As Object = e.Row("crptc_startdate")
            Dim crptc_enddate As Object = e.Row("crptc_enddate")

            Select Case e.Column.ColumnName.ToLower
                Case "crptc_name"
                    crptc_name = e.ProposedValue
                Case "crptc_alignment"
                    crptc_alignment = e.ProposedValue
                Case "crptc_widthpercent"
                    crptc_widthpercent = e.ProposedValue
                Case "crptc_startdate"
                    crptc_startdate = e.ProposedValue
                Case "crptc_enddate"
                    crptc_enddate = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If IsDBNull(crptc_alignment) _
            AndAlso IsDBNull(crptc_name) _
            AndAlso IsDBNull(crptc_widthpercent) _
            AndAlso IsDBNull(crptc_startdate) _
            AndAlso IsDBNull(crptc_enddate) Then
                isBlankRow = True
            End If
            If Not isBlankRow Then
                If Not IsNumeric(crptc_widthpercent) OrElse CDec(crptc_widthpercent) <= 0 Then
                    e.Row.SetColumnError("crptc_widthpercent", Me.StringParserService.Parse("${res:Global.Error.FFCWidthMissing}"))
                Else
                    e.Row.SetColumnError("crptc_widthpercent", "")
                End If
                If Not IsNumeric(crptc_alignment) Then
                    e.Row.SetColumnError("crptc_alignment", Me.StringParserService.Parse("${res:Global.Error.FFCAlignmentMissing}"))
                Else
                    e.Row.SetColumnError("crptc_alignment", "")
                End If
                If Not IsDate(crptc_enddate) OrElse CDate(crptc_enddate).Equals(Date.MinValue) Then
                    e.Row.SetColumnError("crptc_enddate", Me.StringParserService.Parse("${res:Global.Error.FFCEndDateMissing}"))
                Else
                    e.Row.SetColumnError("crptc_enddate", "")
                End If
            End If
        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            If row.Tag Is Nothing Then
                Return False
            End If
            Return True
        End Function
        Private m_updating As Boolean = False
        Public Sub SetLCIValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim entity As New LCIItem(e.ProposedValue.ToString)
            If entity.Originated Then
                e.ProposedValue = entity.Code
                e.Row("lciName") = entity.Name
            Else
                e.ProposedValue = DBNull.Value
                e.Row("lciName") = DBNull.Value
            End If
            Dim doc As ComplexReportColumn = Me.CurrentItem
            doc.LCI = entity
            m_updating = False
        End Sub
        Public Sub SetCostCenterValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim entity As New CostCenter(e.ProposedValue.ToString)
            If entity.Originated Then
                e.ProposedValue = entity.Code
                e.Row("CCName") = entity.Name
            Else
                e.ProposedValue = DBNull.Value
                e.Row("CCName") = DBNull.Value
            End If
            Dim doc As ComplexReportColumn = Me.CurrentItem
            doc.CostCenter = entity
            m_updating = False
        End Sub
        Public Sub SetName(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As ComplexReportColumn = Me.CurrentItem
            m_updating = True
            doc.Name = e.ProposedValue.ToString
            m_updating = False
        End Sub
        Public Sub SetWidthPercent(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As ComplexReportColumn = Me.CurrentItem
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)
            If Configuration.Compare(Me.m_entity.ColumnCollection.AllWidthPercent - doc.WidthPercent + value, 100, DigitConfig.Price) > 0 Then
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                msgServ.ShowMessage("${res:Global.Error.WidthPercentExceed100}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            m_updating = True
            doc.WidthPercent = value
            m_updating = False
        End Sub
        Public Sub SetAlignment(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim doc As ComplexReportColumn = Me.CurrentItem
            doc.Alignment = CType(CInt(e.ProposedValue), HorizontalAlignment)
            m_updating = False
        End Sub
        Public Sub SetStartDate(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As ComplexReportColumn = Me.CurrentItem
            If Not IsDate(e.ProposedValue) Then
                e.ProposedValue = Date.MinValue
            End If
            m_updating = True
            doc.StartDate = CDate(e.ProposedValue)
            m_updating = False
        End Sub
        Public Sub SetEndDate(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim doc As ComplexReportColumn = Me.CurrentItem
            If Not IsDate(e.ProposedValue) Then
                e.ProposedValue = Date.MinValue
            End If
            m_updating = True
            doc.EndDate = CDate(e.ProposedValue)
            m_updating = False
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Status.Value = 0 _
            OrElse Me.m_entity.Status.Value >= 3 _
            Then
                Me.Enabled = False
            Else
                Me.Enabled = True
            End If
        End Sub
        Public Overrides Sub ClearDetail()
            For Each crlt As Control In Me.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
            For Each crlt As Control In grbCompanyName.Controls
                If crlt.Name.StartsWith("txt") Then
                    crlt.Text = ""
                End If
            Next
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.lblItem}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.lblCode}")
            Me.lblHeader.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.lblHeader}")
            Me.lblName.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.lblName}")
            Me.lblCondition.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.lblCondition}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.lblNote}")
            Me.rdOption.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.rdOption}")
            Me.rdCustom.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ComplexReportDetailView.rdCustom}")
            Me.grbCompanyName.Text = Me.StringParserService.Parse("${res:Global.SupplierText}")
        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtName.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtHeader.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtCondition.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler rdOption.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler rdCustom.CheckedChanged, AddressOf Me.ChangeProperty
            AddHandler txtCompanyName.TextChanged, AddressOf Me.ChangeProperty
        End Sub
        ' �ʴ���Ң����Ţͧ�١���ŧ� control ������躹�����
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                Return
            End If

            txtCode.Text = m_entity.Code
            txtName.Text = m_entity.Name
            txtHeader.Text = m_entity.Header
            txtCondition.Text = m_entity.Condition
            txtNote.Text = m_entity.Note

            If Me.m_entity.UseCompanyNameInOption Then
                rdOption.PerformClick()
                Me.txtCompanyName.ReadOnly = True
            Else
                rdCustom.PerformClick()
                Me.txtCompanyName.ReadOnly = False
            End If
            Me.txtCompanyName.Text = m_entity.Companyname


            Me.m_oldCode = Me.m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            RefreshDocs()

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Private Sub RefreshDocs()
            Me.m_isInitialized = False
            Me.m_entity.ColumnCollection.Populate(m_treeManager.Treetable)
            RefreshBlankGrid()
            ReIndex()
            Me.m_isInitialized = True
        End Sub
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If e.Name = "ItemChanged" Then
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Private m_optionsetting As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcode"
                    Me.m_entity.Code = txtCode.Text
                    dirtyFlag = True
                Case "txtname"
                    Me.m_entity.Name = txtName.Text
                    dirtyFlag = True
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True
                Case "txtheader"
                    Me.m_entity.Header = txtHeader.Text
                    dirtyFlag = True
                Case "txtcondition"
                    Me.m_entity.Condition = txtCondition.Text
                    dirtyFlag = True
                Case "txtcompanyname"
                    If Not m_optionsetting Then
                        Me.m_entity.Companyname = txtCompanyName.Text
                        dirtyFlag = True
                    End If
                Case "rdoption", "rdcustom"
                    m_optionsetting = True
                    If rdOption.Checked Then
                        Me.m_entity.UseCompanyNameInOption = True
                    Else
                        Me.m_entity.UseCompanyNameInOption = False
                    End If
                    If Me.m_entity.UseCompanyNameInOption Then
                        Me.txtCompanyName.ReadOnly = True
                    Else
                        Me.txtCompanyName.ReadOnly = False
                    End If
                    Me.txtCompanyName.Text = m_entity.Companyname
                    m_optionsetting = False
                    dirtyFlag = True
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Public Sub SetStatus()
            'If m_entity.Canceled Then
            '    Me.StatusBarService.SetMessage("¡��ԡ: " & m_entity.CancelDate.ToShortDateString & _
            '    " " & m_entity.CancelDate.ToShortTimeString & _
            '    "  ��:" & m_entity.CancelPerson.Name)
            'ElseIf m_entity.Edited Then
            '    Me.StatusBarService.SetMessage("�������ش: " & m_entity.LastEditDate.ToShortDateString & _
            '    " " & m_entity.LastEditDate.ToShortTimeString & _
            '    "  ��:" & m_entity.LastEditor.Name)
            'ElseIf m_entity.Originated Then
            '    Me.StatusBarService.SetMessage("�����������к�: " & m_entity.OriginDate.ToShortDateString & _
            '    " " & m_entity.OriginDate.ToShortTimeString & _
            '    "  ��:" & m_entity.Originator.Name)
            'Else
            '    Me.StatusBarService.SetMessage("")
            'End If
        End Sub
        Public Overrides Property Entity() As ISimpleEntity
            Get
                Return Me.m_entity
            End Get
            Set(ByVal Value As ISimpleEntity)
                If Not m_entity Is Nothing Then
                    RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
                    Me.m_entity = Nothing
                End If
                Me.m_entity = CType(Value, ComplexReport)
                'Hack:
                If Not m_entity Is Nothing Then
                    Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
                End If
                UpdateEntityProperties()
            End Set
        End Property

        Public Overrides Sub Initialize()
        End Sub
#End Region

#Region "Event Handlers"
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_oldCode As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
                Me.Validator.SetRequired(Me.txtCode, False)
                Me.ErrorProvider1.SetError(Me.txtCode, "")
                Me.txtCode.ReadOnly = True
                m_oldCode = Me.txtCode.Text
                Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
                'Hack: set Code �� "" �ͧ
                Me.m_entity.Code = ""
                Me.m_entity.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtCode, True)
                Me.txtCode.Text = m_oldCode
                Me.txtCode.ReadOnly = False
                Me.m_entity.AutoGen = False
            End If
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            If index > Me.m_entity.ColumnCollection.Count - 1 Then
                Return
            End If
            Me.m_entity.ColumnCollection.Insert(index, New ComplexReportColumn)
            RefreshDocs()
            tgItem.CurrentRowIndex = index
            Dim re As New DataColumnChangeEventArgs(Me.m_treeManager.Treetable.Rows(index) _
            , Me.m_treeManager.Treetable.Columns("crptc_widthpercent") _
            , Me.CurrentItem.WidthPercent)
            Me.ValidateRow(re)
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            Dim row As TreeRow = Me.m_treeManager.SelectedRow
            If row Is Nothing Then
                Return
            End If
            Dim doc As ComplexReportColumn = Me.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            Me.m_entity.ColumnCollection.Remove(doc)
            RefreshDocs()
            Me.tgItem.CurrentRowIndex = index
        End Sub
        Private Sub ReIndex()
            Dim i As Integer = 0
            For Each row As TreeRow In Me.m_treeManager.Treetable.Rows
                row("crptc_linenumber") = i + 1
                If TypeOf row.Tag Is ComplexReportColumn Then
                    CType(row.Tag, ComplexReportColumn).LineNumber = i + 1
                End If
                i += 1
            Next
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
        Public Overrides Sub NotifyBeforeSave()

        End Sub
        Public Overrides ReadOnly Property TabPageIcon() As String
            Get
                Return (New PR).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "After the main entity has been saved"
        Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
            If Not successful Then
                Return
            End If
            Me.Entity = CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity
        End Sub
#End Region

#Region "Event of Button controls"

#End Region

#Region "Grid Resizing"
        Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs)
            If Me.m_entity Is Nothing Then
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

            Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
                '�����Ǩ����
                Me.m_treeManager.Treetable.Childs.Add()
            Loop

            If Me.m_entity.ColumnCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
                '�����ա 1 �� ����բ����Ũ��֧���ش����
                Me.m_treeManager.Treetable.Childs.Add()
            End If
            Me.m_treeManager.Treetable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag

            'If Me.tgItem.Height = 0 Then
            '    Return
            'End If
            'Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            'Dim index As Integer = tgItem.CurrentRowIndex
            'Dim maxVisibleCount As Integer
            'Dim tgRowHeight As Integer = 17
            'maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
            'Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
            '    '�����Ǩ����
            '    Me.m_treeManager.Treetable.Childs.Add()
            'Loop
            ''If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
            ''    If Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
            ''        '�����ա 1 �� ����բ����Ũ��֧���ش����
            ''        Me.m_treeManager.Treetable.Childs.Add()
            ''    End If
            ''End If
            'Me.m_treeManager.Treetable.AcceptChanges()
            'tgItem.CurrentRowIndex = Math.Max(0, index)
            'Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
#End Region

        Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
            Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
            CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
            Me.Entity = newEntity
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub

    End Class
End Namespace