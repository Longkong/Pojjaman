Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptDRFilterSubPanel
        Inherits AbstractFilterSubPanel
        Implements IReportFilterSubPanel

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
        Friend WithEvents grbMaster As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents grbItem As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
        Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
        Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
        Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
        Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents grbMainDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblSubcontractorStart As System.Windows.Forms.Label
        Friend WithEvents lblSubcontractorEnd As System.Windows.Forms.Label
        Friend WithEvents lbltoCCStart As System.Windows.Forms.Label
        Friend WithEvents txttoCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblStatus As System.Windows.Forms.Label
        Friend WithEvents txtSuContractCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents btntoCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnSubcontractEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnSubcontractStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnfromCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents btnfromCCPersoneStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents txtSuContractCodeStart As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptDRFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbMainDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txttoCCCodeStart = New System.Windows.Forms.TextBox
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblStatus = New System.Windows.Forms.Label
            Me.lbltoCCStart = New System.Windows.Forms.Label
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.btntoCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.btnSubcontractEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuContractCodeEnd = New System.Windows.Forms.TextBox
            Me.lblSubcontractorEnd = New System.Windows.Forms.Label
            Me.btnSubcontractStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuContractCodeStart = New System.Windows.Forms.TextBox
            Me.lblSubcontractorStart = New System.Windows.Forms.Label
            Me.grbItem = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblFromCostCenter = New System.Windows.Forms.Label
            Me.lblFromCCPerson = New System.Windows.Forms.Label
            Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox
            Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox
            Me.txtFromCCPersonName = New System.Windows.Forms.TextBox
            Me.txtFromCostCenterName = New System.Windows.Forms.TextBox
            Me.btnfromCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.btnfromCCPersoneStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbMaster.SuspendLayout()
            Me.grbMainDetail.SuspendLayout()
            Me.grbItem.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.Controls.Add(Me.grbMainDetail)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(840, 232)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "��ѡ��������"
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(752, 200)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 3
            Me.btnSearch.Text = "����"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnReset.Location = New System.Drawing.Point(672, 200)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 2
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "������"
            '
            'grbMainDetail
            '
            Me.grbMainDetail.Controls.Add(Me.txttoCCCodeStart)
            Me.grbMainDetail.Controls.Add(Me.cmbStatus)
            Me.grbMainDetail.Controls.Add(Me.lblStatus)
            Me.grbMainDetail.Controls.Add(Me.lbltoCCStart)
            Me.grbMainDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbMainDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbMainDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbMainDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbMainDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbMainDetail.Controls.Add(Me.btntoCCCodeStart)
            Me.grbMainDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbMainDetail.Controls.Add(Me.btnSubcontractEndFind)
            Me.grbMainDetail.Controls.Add(Me.txtSuContractCodeEnd)
            Me.grbMainDetail.Controls.Add(Me.lblSubcontractorEnd)
            Me.grbMainDetail.Controls.Add(Me.btnSubcontractStartFind)
            Me.grbMainDetail.Controls.Add(Me.txtSuContractCodeStart)
            Me.grbMainDetail.Controls.Add(Me.lblSubcontractorStart)
            Me.grbMainDetail.Controls.Add(Me.grbItem)
            Me.grbMainDetail.Controls.Add(Me.txtTemp)
            Me.grbMainDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMainDetail.Location = New System.Drawing.Point(8, 24)
            Me.grbMainDetail.Name = "grbMainDetail"
            Me.grbMainDetail.Size = New System.Drawing.Size(824, 160)
            Me.grbMainDetail.TabIndex = 0
            Me.grbMainDetail.TabStop = False
            Me.grbMainDetail.Text = "��������´�����"
            '
            'txttoCCCodeStart
            '
            Me.Validator.SetDataType(Me.txttoCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txttoCCCodeStart, "")
            Me.txttoCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txttoCCCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txttoCCCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txttoCCCodeStart, System.Drawing.Color.Empty)
            Me.txttoCCCodeStart.Location = New System.Drawing.Point(128, 80)
            Me.txttoCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txttoCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txttoCCCodeStart, "")
            Me.txttoCCCodeStart.Name = "txttoCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txttoCCCodeStart, "")
            Me.Validator.SetRequired(Me.txttoCCCodeStart, False)
            Me.txttoCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txttoCCCodeStart.TabIndex = 7
            Me.txttoCCCodeStart.Text = ""
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(128, 128)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(120, 21)
            Me.cmbStatus.TabIndex = 38
            Me.cmbStatus.Visible = False
            '
            'lblStatus
            '
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.Color.Black
            Me.lblStatus.Location = New System.Drawing.Point(80, 128)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(40, 18)
            Me.lblStatus.TabIndex = 37
            Me.lblStatus.Text = "ʶҹ�"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.lblStatus.Visible = False
            '
            'lbltoCCStart
            '
            Me.lbltoCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lbltoCCStart.ForeColor = System.Drawing.Color.Black
            Me.lbltoCCStart.Location = New System.Drawing.Point(48, 80)
            Me.lbltoCCStart.Name = "lbltoCCStart"
            Me.lbltoCCStart.Size = New System.Drawing.Size(72, 18)
            Me.lbltoCCStart.TabIndex = 14
            Me.lbltoCCStart.Text = "Cost Center"
            Me.lbltoCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(248, 80)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 15
            Me.txtCostCenterName.Text = ""
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(288, 32)
            Me.txtDocDateEnd.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateEnd, "")
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateEnd.TabIndex = 2
            Me.txtDocDateEnd.Text = ""
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(64, 32)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "������ѹ���"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(288, 32)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(256, 32)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "�֧"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(128, 32)
            Me.txtDocDateStart.MaxLength = 10
            Me.Validator.SetMaxValue(Me.txtDocDateStart, "")
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(99, 21)
            Me.txtDocDateStart.TabIndex = 1
            Me.txtDocDateStart.Text = ""
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(128, 104)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 12
            Me.chkIncludeChildren.Text = "��� Cost Center �١"
            '
            'btntoCCCodeStart
            '
            Me.btntoCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btntoCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btntoCCCodeStart.Image = CType(resources.GetObject("btntoCCCodeStart.Image"), System.Drawing.Image)
            Me.btntoCCCodeStart.Location = New System.Drawing.Point(224, 80)
            Me.btntoCCCodeStart.Name = "btntoCCCodeStart"
            Me.btntoCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btntoCCCodeStart.TabIndex = 22
            Me.btntoCCCodeStart.TabStop = False
            Me.btntoCCCodeStart.ThemedImage = CType(resources.GetObject("btntoCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(128, 32)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'btnSubcontractEndFind
            '
            Me.btnSubcontractEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSubcontractEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSubcontractEndFind.Image = CType(resources.GetObject("btnSubcontractEndFind.Image"), System.Drawing.Image)
            Me.btnSubcontractEndFind.Location = New System.Drawing.Point(384, 56)
            Me.btnSubcontractEndFind.Name = "btnSubcontractEndFind"
            Me.btnSubcontractEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSubcontractEndFind.TabIndex = 21
            Me.btnSubcontractEndFind.TabStop = False
            Me.btnSubcontractEndFind.ThemedImage = CType(resources.GetObject("btnSubcontractEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuContractCodeEnd
            '
            Me.Validator.SetDataType(Me.txtSuContractCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuContractCodeEnd, "")
            Me.txtSuContractCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuContractCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuContractCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuContractCodeEnd, System.Drawing.Color.Empty)
            Me.txtSuContractCodeEnd.Location = New System.Drawing.Point(288, 56)
            Me.Validator.SetMaxValue(Me.txtSuContractCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtSuContractCodeEnd, "")
            Me.txtSuContractCodeEnd.Name = "txtSuContractCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtSuContractCodeEnd, "")
            Me.Validator.SetRequired(Me.txtSuContractCodeEnd, False)
            Me.txtSuContractCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtSuContractCodeEnd.TabIndex = 5
            Me.txtSuContractCodeEnd.Text = ""
            '
            'lblSubcontractorEnd
            '
            Me.lblSubcontractorEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSubcontractorEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSubcontractorEnd.Location = New System.Drawing.Point(256, 56)
            Me.lblSubcontractorEnd.Name = "lblSubcontractorEnd"
            Me.lblSubcontractorEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblSubcontractorEnd.TabIndex = 22
            Me.lblSubcontractorEnd.Text = "�֧"
            Me.lblSubcontractorEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSubcontractStartFind
            '
            Me.btnSubcontractStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSubcontractStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSubcontractStartFind.Image = CType(resources.GetObject("btnSubcontractStartFind.Image"), System.Drawing.Image)
            Me.btnSubcontractStartFind.Location = New System.Drawing.Point(224, 56)
            Me.btnSubcontractStartFind.Name = "btnSubcontractStartFind"
            Me.btnSubcontractStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSubcontractStartFind.TabIndex = 9
            Me.btnSubcontractStartFind.TabStop = False
            Me.btnSubcontractStartFind.ThemedImage = CType(resources.GetObject("btnSubcontractStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuContractCodeStart
            '
            Me.Validator.SetDataType(Me.txtSuContractCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuContractCodeStart, "")
            Me.txtSuContractCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuContractCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuContractCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuContractCodeStart, System.Drawing.Color.Empty)
            Me.txtSuContractCodeStart.Location = New System.Drawing.Point(128, 56)
            Me.Validator.SetMaxValue(Me.txtSuContractCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSuContractCodeStart, "")
            Me.txtSuContractCodeStart.Name = "txtSuContractCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuContractCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuContractCodeStart, False)
            Me.txtSuContractCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtSuContractCodeStart.TabIndex = 4
            Me.txtSuContractCodeStart.Text = ""
            '
            'lblSubcontractorStart
            '
            Me.lblSubcontractorStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSubcontractorStart.ForeColor = System.Drawing.Color.Black
            Me.lblSubcontractorStart.Location = New System.Drawing.Point(48, 56)
            Me.lblSubcontractorStart.Name = "lblSubcontractorStart"
            Me.lblSubcontractorStart.Size = New System.Drawing.Size(72, 18)
            Me.lblSubcontractorStart.TabIndex = 19
            Me.lblSubcontractorStart.Text = "����Ѻ����"
            Me.lblSubcontractorStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbItem
            '
            Me.grbItem.Controls.Add(Me.lblFromCostCenter)
            Me.grbItem.Controls.Add(Me.lblFromCCPerson)
            Me.grbItem.Controls.Add(Me.txtFromCostCenterCode)
            Me.grbItem.Controls.Add(Me.txtFromCCPersonCode)
            Me.grbItem.Controls.Add(Me.txtFromCCPersonName)
            Me.grbItem.Controls.Add(Me.txtFromCostCenterName)
            Me.grbItem.Controls.Add(Me.btnfromCCCodeStart)
            Me.grbItem.Controls.Add(Me.btnfromCCPersoneStart)
            Me.grbItem.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbItem.Location = New System.Drawing.Point(424, 24)
            Me.grbItem.Name = "grbItem"
            Me.grbItem.Size = New System.Drawing.Size(384, 88)
            Me.grbItem.TabIndex = 1
            Me.grbItem.TabStop = False
            Me.grbItem.Text = "�����ż������ԡ"
            '
            'lblFromCostCenter
            '
            Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFromCostCenter.Location = New System.Drawing.Point(8, 24)
            Me.lblFromCostCenter.Name = "lblFromCostCenter"
            Me.lblFromCostCenter.Size = New System.Drawing.Size(112, 18)
            Me.lblFromCostCenter.TabIndex = 18
            Me.lblFromCostCenter.Text = "Cost Center �������ԡ:"
            Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblFromCCPerson
            '
            Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblFromCCPerson.Location = New System.Drawing.Point(56, 48)
            Me.lblFromCCPerson.Name = "lblFromCCPerson"
            Me.lblFromCCPerson.Size = New System.Drawing.Size(64, 18)
            Me.lblFromCCPerson.TabIndex = 19
            Me.lblFromCCPerson.Text = "�������ԡ:"
            Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtFromCostCenterCode
            '
            Me.txtFromCostCenterCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
            Me.txtFromCostCenterCode.Location = New System.Drawing.Point(120, 24)
            Me.Validator.SetMaxValue(Me.txtFromCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
            Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtFromCostCenterCode, False)
            Me.txtFromCostCenterCode.Size = New System.Drawing.Size(72, 21)
            Me.txtFromCostCenterCode.TabIndex = 10
            Me.txtFromCostCenterCode.Text = ""
            '
            'txtFromCCPersonCode
            '
            Me.txtFromCCPersonCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtFromCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
            Me.txtFromCCPersonCode.Location = New System.Drawing.Point(120, 48)
            Me.Validator.SetMaxValue(Me.txtFromCCPersonCode, "")
            Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
            Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
            Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
            Me.Validator.SetRequired(Me.txtFromCCPersonCode, False)
            Me.txtFromCCPersonCode.Size = New System.Drawing.Size(72, 21)
            Me.txtFromCCPersonCode.TabIndex = 11
            Me.txtFromCCPersonCode.Text = ""
            '
            'txtFromCCPersonName
            '
            Me.Validator.SetDataType(Me.txtFromCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFromCCPersonName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
            Me.txtFromCCPersonName.Location = New System.Drawing.Point(216, 48)
            Me.Validator.SetMaxValue(Me.txtFromCCPersonName, "")
            Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
            Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
            Me.txtFromCCPersonName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
            Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
            Me.txtFromCCPersonName.Size = New System.Drawing.Size(160, 21)
            Me.txtFromCCPersonName.TabIndex = 13
            Me.txtFromCCPersonName.TabStop = False
            Me.txtFromCCPersonName.Text = ""
            '
            'txtFromCostCenterName
            '
            Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
            Me.txtFromCostCenterName.Location = New System.Drawing.Point(216, 24)
            Me.Validator.SetMaxValue(Me.txtFromCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
            Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
            Me.txtFromCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
            Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
            Me.txtFromCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtFromCostCenterName.TabIndex = 12
            Me.txtFromCostCenterName.TabStop = False
            Me.txtFromCostCenterName.Text = ""
            '
            'btnfromCCCodeStart
            '
            Me.btnfromCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnfromCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnfromCCCodeStart.Image = CType(resources.GetObject("btnfromCCCodeStart.Image"), System.Drawing.Image)
            Me.btnfromCCCodeStart.Location = New System.Drawing.Point(192, 24)
            Me.btnfromCCCodeStart.Name = "btnfromCCCodeStart"
            Me.btnfromCCCodeStart.Size = New System.Drawing.Size(24, 23)
            Me.btnfromCCCodeStart.TabIndex = 14
            Me.btnfromCCCodeStart.TabStop = False
            Me.btnfromCCCodeStart.ThemedImage = CType(resources.GetObject("btnfromCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnfromCCPersoneStart
            '
            Me.btnfromCCPersoneStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnfromCCPersoneStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnfromCCPersoneStart.Image = CType(resources.GetObject("btnfromCCPersoneStart.Image"), System.Drawing.Image)
            Me.btnfromCCPersoneStart.Location = New System.Drawing.Point(192, 48)
            Me.btnfromCCPersoneStart.Name = "btnfromCCPersoneStart"
            Me.btnfromCCPersoneStart.Size = New System.Drawing.Size(24, 23)
            Me.btnfromCCPersoneStart.TabIndex = 15
            Me.btnfromCCPersoneStart.TabStop = False
            Me.btnfromCCPersoneStart.ThemedImage = CType(resources.GetObject("btnfromCCPersoneStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(288, 56)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtTemp, "")
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(104, 21)
            Me.txtTemp.TabIndex = 4
            Me.txtTemp.Text = ""
            Me.txtTemp.Visible = False
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
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'RptDRFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptDRFilterSubPanel"
            Me.Size = New System.Drawing.Size(864, 256)
            Me.grbMaster.ResumeLayout(False)
            Me.grbMainDetail.ResumeLayout(False)
            Me.grbItem.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()

            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.grbMaster}")
            Me.grbMainDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.grbMainDetail}")
            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lblDocDateStart}")
            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblSubcontractorStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lblSubcontractorStart}")
            Me.lblSubcontractorEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.chkIncludeChildren}")
            Me.lblStatus.Text = StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lblStatus}")

            Me.grbItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.grbItem}")
            Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lblFromCostCenter}")

            ''If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lbltoCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptDRFilterSubPanel.lbltoCCStart}")
            Me.Validator.SetDisplayName(txttoCCCodeStart, lbltoCCStart.Text)

            Me.Validator.SetDisplayName(txtSuContractCodeStart, lblSubcontractorStart.Text)

            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            'Me.lblEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCFilterSubPanel.lblEmployee}")

            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")


        End Sub
#End Region

#Region "Member"
        Private m_tocc As CostCenter
        Private m_fromcc As CostCenter
        Private m_subcontractor As Supplier
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        'Private m_DueDateEnd As Date
        'Private m_DueDateStart As Date
        Private m_subcontractorgroup As SupplierGroup
        Private m_frompersone As Employee
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Public Property toCostcenter() As CostCenter
            Get
                Return m_tocc
            End Get
            Set(ByVal Value As CostCenter)
                m_tocc = Value
            End Set
        End Property
        Public Property fromCostcenter() As CostCenter
            Get
                Return m_fromcc
            End Get
            Set(ByVal Value As CostCenter)
                m_fromcc = Value
            End Set
        End Property
        Public Property Subcontractor() As Supplier
            Get
                Return m_subcontractor
            End Get
            Set(ByVal Value As Supplier)
                m_subcontractor = Value
            End Set
        End Property
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
        'Public Property DueDateEnd() As Date        '    Get        '        Return m_DocDateEnd        '    End Get        '    Set(ByVal Value As Date)        '        m_DocDateEnd = Value        '    End Set        'End Property        'Public Property DueDateStart() As Date        '    Get        '        Return m_DocDateStart        '    End Get        '    Set(ByVal Value As Date)        '        m_DocDateStart = Value        '    End Set        'End Property
        Public Property SubcontractorGroup() As SupplierGroup
            Get
                Return m_subcontractorgroup
            End Get
            Set(ByVal Value As SupplierGroup)
                m_subcontractorgroup = Value
            End Set
        End Property
        Public Property frompersone() As Employee
            Get
                Return m_frompersone
            End Get
            Set(ByVal Value As Employee)
                m_frompersone = Value
            End Set
        End Property
#End Region

#Region "Methods"
        'Private Sub RegisterDropdown()
        '  CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocStatus, "goodsreceipt_status", True)
        '  cmbDocStatus.SelectedIndex = 0
        'End Sub
        Private Sub Initialize()
            'RegisterDropdown()
            ClearCriterias()
        End Sub

        Private Sub ClearCriterias()
            For Each grbCtrl As Control In grbMaster.Controls
                If TypeOf grbCtrl Is Longkong.Pojjaman.Gui.Components.FixedGroupBox Then
                    For Each Ctrl As Control In grbCtrl.Controls
                        If TypeOf Ctrl Is TextBox Then
                            Ctrl.Text = ""
                        End If
                    Next
                End If
            Next

            Me.Subcontractor = New Supplier
            Me.toCostcenter = New CostCenter
            Me.fromCostcenter = New CostCenter

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))

            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.SubcontractorGroup = New SupplierGroup
            Me.frompersone = New Employee

            Me.txtFromCostCenterCode.Text = ""
            Me.txtFromCostCenterName.Clear()
            Me.txtFromCCPersonCode.Clear()

            Me.txtFromCCPersonName.Text = ""
            If chkIncludeChildren.Checked Then
                chkIncludeChildren.Checked = False
            End If

        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(8) As Filter
            arr(0) = New Filter("docdatestart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("docdateend", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("SubcontractorCodeStart", IIf(txtSuContractCodeStart.TextLength > 0, txtSuContractCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("SubcontractorCodeEnd", IIf(txtSuContractCodeEnd.TextLength > 0, txtSuContractCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("Tocc", Me.ValidIdOrDBNull(m_tocc))
            arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(6) = New Filter("status", cmbStatus.SelectedIndex) ' IIf(cmbDocStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbDocStatus.SelectedItem, IdValuePair).Id))
            arr(7) = New Filter("Fromcc", Me.ValidIdOrDBNull(m_fromcc))
            arr(8) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            'arr(8) = New Filter("SubcontractorGroupID", Me.ValidIdOrDBNull(m_subcontractorgroup))
            'arr(9) = New Filter("IncludeChildSubcontractorGroup", Me.chkIncludeChildSupplierGroup.Checked)
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region "IReportFilterSubPanel"
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'Month
            dpi = New DocPrintingItem
            dpi.Mapping = "Month"
            dpi.Value = "" 'Me.cmbMonth.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Year
            dpi = New DocPrintingItem
            dpi.Mapping = "Year"
            dpi.Value = "" 'Me.cmbYear.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate Start
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateStart"
            dpi.Value = Me.txtDocDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate End
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateEnd"
            dpi.Value = Me.txtDocDateEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Subcontractor Code
            dpi = New DocPrintingItem
            dpi.Mapping = "SubcontractorCode"
            dpi.Value = Me.txtSuContractCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Subcontractor Name
            dpi = New DocPrintingItem
            dpi.Mapping = "SubcontractorName"
            dpi.Value = Me.txtSuContractCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'to CostCenter Code
            dpi = New DocPrintingItem
            dpi.Mapping = "ToCostCenterCode"
            dpi.Value = Me.txttoCCCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'to CostCenter Name
            dpi = New DocPrintingItem
            dpi.Mapping = "ToCostCenterName"
            dpi.Value = Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'To CostCenter Info
            dpi = New DocPrintingItem
            dpi.Mapping = "ToCostCenterInfo"
            dpi.Value = Me.txttoCCCodeStart.Text & ":" & Me.txtCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Include CCChildren
            If Me.chkIncludeChildren.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "IncludeCCChildren"
                dpi.Value = "(�����ѧ�Ѵ)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'Status
            dpi = New DocPrintingItem
            dpi.Mapping = "Status"
            dpi.Value = Me.cmbStatus.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'from CostCenter Code
            dpi = New DocPrintingItem
            dpi.Mapping = "FromCostCenterName"
            dpi.Value = Me.txtFromCostCenterCode.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'from CostCenter Name
            dpi = New DocPrintingItem
            dpi.Mapping = "FromCostCenterName"
            dpi.Value = Me.txtFromCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'from CostCenter Info
            dpi = New DocPrintingItem
            dpi.Mapping = "FromCostCenterInfo"
            dpi.Value = Me.txtFromCostCenterCode.Text & ":" & Me.txtFromCostCenterName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Employee Code
            dpi = New DocPrintingItem
            dpi.Mapping = "FromCCPersonCode"
            dpi.Value = Me.txtFromCCPersonCode.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Employee Name
            dpi = New DocPrintingItem
            dpi.Mapping = "FromCCPersonName"
            dpi.Value = Me.txtFromCCPersonName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'from CostCenter Persone Info
            dpi = New DocPrintingItem
            dpi.Mapping = "FromCCPersonInfo"
            dpi.Value = Me.txtFromCCPersonCode.Text & ":" & Me.txtFromCCPersonName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSubcontractStartFind.Click, AddressOf Me.btnSubcontractStartFind_Click
            AddHandler txttoCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnSubcontractEndFind.Click, AddressOf Me.btnSubcontractEndFind_Click
            AddHandler txtSuContractCodeEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler btntoCCCodeStart.Click, AddressOf Me.btntoCCCodeStart_Click
            AddHandler txttoCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler btnfromCCCodeStart.Click, AddressOf Me.btnfromCCCodeStart_Click
            AddHandler txtFromCostCenterCode.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler btnfromCCPersoneStart.Click, AddressOf Me.btnfromCCPersoneStart_Click
            AddHandler txtFromCCPersonCode.Validated, AddressOf Me.ChangeProperty

            'AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click

        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txttocccodestart"
                    CostCenter.GetCostCenter(txttoCCCodeStart, Me.txtCostCenterName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                Case "txtfromcostcentercode"
                    CostCenter.GetCostCenter(txtFromCostCenterCode, Me.txtFromCostCenterName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                Case "txtfromccpersoncode"
                    CostCenter.GetCostCenter(txtFromCCPersonCode, Me.txtFromCCPersonName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

                    'Case "txtemployee"
                    '    Employee.GetEmployee(txtEmployee, Me.txtEmployeeName, Director)
                Case "dtpdocdatestart"
                    If Not Me.DocDateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.DocDateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.DocDateStart = dtpDocDateStart.Value
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.DocDateStart = Date.MinValue
                    End If
                    m_dateSetting = False

                Case "dtpdocdateend"
                    If Not Me.DocDateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.DocDateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.DocDateEnd = dtpDocDateEnd.Value
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.DocDateEnd = Date.MinValue
                    End If
                    m_dateSetting = False


                Case Else

            End Select
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' Supplier
                If data.GetDataPresent((New Supplier).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtsupplicodestart", "txtsupplicodeend"
                                Return True
                        End Select
                    End If
                End If
                ' Costcenter
                If data.GetDataPresent((New CostCenter).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtcccodestart", "txtcccodeend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            ' Supplier
            If data.GetDataPresent((New Supplier).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
                Dim entity As New Supplier(id)
                'If Not Me.ActiveControl Is Nothing Then
                '    Select Case Me.ActiveControl.Name.ToLower
                '        Case "txtsupplicodestart"
                '            Me.SetSupplierStartDialog(entity)

                '        Case "txtsupplicodeend"
                '            Me.SetSupplierEndDialog(entity)

                '    End Select
                'End If
            End If
            ' Costcenter
            'If data.GetDataPresent((New Costcenter).FullClassName) Then
            '    Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
            '    Dim entity As New Costcenter(id)
            '    If Not Me.ActiveControl Is Nothing Then
            '        Select Case Me.ActiveControl.Name.ToLower
            '            Case "txtcostcentercodestart"
            '                Me.SetCCCodeStartDialog(entity)

            '            Case "txtcostcentercodeend"
            '                Me.SetCCCodeStartDialog(entity)

            '        End Select
            '    End If
            'End If
        End Sub
#End Region

#Region " Event Handlers "
        ' Subcontractor
        Private Sub btnSubcontractStartFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsubcontractstartfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

                    'Case "btnsubcontractendfind"
                    '    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

            End Select
        End Sub
        Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuContractCodeStart.Text = e.Code
            Supplier.GetSupplier(txtSuContractCodeStart, txtTemp, Me.Subcontractor)
        End Sub
        Private Sub btnSubcontractEndFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                'Case "btnsubcontractendfind"
                '    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

            Case "btnsubcontractendfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

            End Select
        End Sub
        Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
            Me.txtSuContractCodeEnd.Text = e.Code
            Supplier.GetSupplier(txtSuContractCodeEnd, txtTemp, Me.Subcontractor)
        End Sub
        ' To Costcenter
        Private Sub btntoCCCodeStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btntocccodestart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetToCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txttoCCCodeStart.Text = e.Code
            CostCenter.GetCostCenter(txttoCCCodeStart, txtCostCenterName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        ' From Cost Center
        Private Sub btnfromCCCodeStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnfromcccodestart"
                    myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetFromCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtFromCostCenterCode.Text = e.Code
            CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, m_tocc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        ' From Persone
        Private Sub btnfromCCPersoneStart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnfromccpersonestart"
                    myEntityPanelService.OpenListDialog(New Employee, AddressOf SetfromCCPersoneStartDialog)

            End Select
        End Sub
        Private Sub SetfromCCPersoneStartDialog(ByVal e As ISimpleEntity)
            Me.txtFromCCPersonCode.Text = e.Code
            Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.frompersone)
        End Sub


#End Region

        Private Sub txtSuContractCodeStart_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSuContractCodeStart.TextChanged

        End Sub

    
    End Class
End Namespace

