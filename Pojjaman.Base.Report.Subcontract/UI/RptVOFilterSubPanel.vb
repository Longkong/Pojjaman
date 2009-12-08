Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptVOFilterSubPanel
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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtTemp As System.Windows.Forms.TextBox
        Friend WithEvents chkIncludeChildren As System.Windows.Forms.CheckBox
        Friend WithEvents btnCCCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblCCStart As System.Windows.Forms.Label
        Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
        Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
        Friend WithEvents cmbDocStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblDocStatus As System.Windows.Forms.Label
        Friend WithEvents chkIncludeChildSupplierGroup As System.Windows.Forms.CheckBox
        Friend WithEvents btnSpgCodeStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSpgCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSpgStart As System.Windows.Forms.Label
        Friend WithEvents txtSupplierGroupName As System.Windows.Forms.TextBox
        Friend WithEvents lblEmployee As System.Windows.Forms.Label
        Friend WithEvents txtEmployee As System.Windows.Forms.TextBox
        Friend WithEvents btnEmployee As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtEmployeeName As System.Windows.Forms.TextBox
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents lblSCCode As System.Windows.Forms.Label
        Friend WithEvents txtSCCode As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowSCDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptVOFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblSCCode = New System.Windows.Forms.Label
            Me.txtSCCode = New System.Windows.Forms.TextBox
            Me.ibtnShowSCDialog = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.Label1 = New System.Windows.Forms.Label
            Me.chkIncludeChildSupplierGroup = New System.Windows.Forms.CheckBox
            Me.btnSpgCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSpgCodeStart = New System.Windows.Forms.TextBox
            Me.lblSpgStart = New System.Windows.Forms.Label
            Me.txtSupplierGroupName = New System.Windows.Forms.TextBox
            Me.cmbDocStatus = New System.Windows.Forms.ComboBox
            Me.lblDocStatus = New System.Windows.Forms.Label
            Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox
            Me.lblSuppliEnd = New System.Windows.Forms.Label
            Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox
            Me.lblSuppliStart = New System.Windows.Forms.Label
            Me.chkIncludeChildren = New System.Windows.Forms.CheckBox
            Me.btnCCCodeStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtCCCodeStart = New System.Windows.Forms.TextBox
            Me.lblCCStart = New System.Windows.Forms.Label
            Me.txtCostCenterName = New System.Windows.Forms.TextBox
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.txtEmployee = New System.Windows.Forms.TextBox
            Me.btnEmployee = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtEmployeeName = New System.Windows.Forms.TextBox
            Me.lblEmployee = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 0)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(824, 224)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "���觨�ҧ"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.lblSCCode)
            Me.grbDetail.Controls.Add(Me.txtSCCode)
            Me.grbDetail.Controls.Add(Me.ibtnShowSCDialog)
            Me.grbDetail.Controls.Add(Me.cmbStatus)
            Me.grbDetail.Controls.Add(Me.Label1)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildSupplierGroup)
            Me.grbDetail.Controls.Add(Me.btnSpgCodeStart)
            Me.grbDetail.Controls.Add(Me.txtSpgCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSpgStart)
            Me.grbDetail.Controls.Add(Me.txtSupplierGroupName)
            Me.grbDetail.Controls.Add(Me.cmbDocStatus)
            Me.grbDetail.Controls.Add(Me.lblDocStatus)
            Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSuppliStart)
            Me.grbDetail.Controls.Add(Me.chkIncludeChildren)
            Me.grbDetail.Controls.Add(Me.btnCCCodeStart)
            Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
            Me.grbDetail.Controls.Add(Me.lblCCStart)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtEmployee)
            Me.grbDetail.Controls.Add(Me.btnEmployee)
            Me.grbDetail.Controls.Add(Me.txtEmployeeName)
            Me.grbDetail.Controls.Add(Me.lblEmployee)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(800, 168)
            Me.grbDetail.TabIndex = 1
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "�����ŷ����"
            '
            'lblSCCode
            '
            Me.lblSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSCCode.ForeColor = System.Drawing.Color.Black
            Me.lblSCCode.Location = New System.Drawing.Point(32, 40)
            Me.lblSCCode.Name = "lblSCCode"
            Me.lblSCCode.Size = New System.Drawing.Size(88, 18)
            Me.lblSCCode.TabIndex = 338
            Me.lblSCCode.Text = "�Ţ��� SC:"
            Me.lblSCCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSCCode
            '
            Me.Validator.SetDataType(Me.txtSCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSCCode, "")
            Me.txtSCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSCCode, System.Drawing.Color.Empty)
            Me.txtSCCode.Location = New System.Drawing.Point(120, 40)
            Me.Validator.SetMaxValue(Me.txtSCCode, "")
            Me.Validator.SetMinValue(Me.txtSCCode, "")
            Me.txtSCCode.Name = "txtSCCode"
            Me.Validator.SetRegularExpression(Me.txtSCCode, "")
            Me.Validator.SetRequired(Me.txtSCCode, True)
            Me.txtSCCode.Size = New System.Drawing.Size(96, 21)
            Me.txtSCCode.TabIndex = 337
            Me.txtSCCode.TabStop = False
            Me.txtSCCode.Text = ""
            '
            'ibtnShowSCDialog
            '
            Me.ibtnShowSCDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowSCDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowSCDialog.Image = CType(resources.GetObject("ibtnShowSCDialog.Image"), System.Drawing.Image)
            Me.ibtnShowSCDialog.Location = New System.Drawing.Point(216, 40)
            Me.ibtnShowSCDialog.Name = "ibtnShowSCDialog"
            Me.ibtnShowSCDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowSCDialog.TabIndex = 339
            Me.ibtnShowSCDialog.TabStop = False
            Me.ibtnShowSCDialog.ThemedImage = CType(resources.GetObject("ibtnShowSCDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(496, 144)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(168, 21)
            Me.cmbStatus.TabIndex = 38
            Me.cmbStatus.Visible = False
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(432, 144)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(56, 18)
            Me.Label1.TabIndex = 37
            Me.Label1.Text = "ʶҹ�"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.Label1.Visible = False
            '
            'chkIncludeChildSupplierGroup
            '
            Me.chkIncludeChildSupplierGroup.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildSupplierGroup.Location = New System.Drawing.Point(496, 40)
            Me.chkIncludeChildSupplierGroup.Name = "chkIncludeChildSupplierGroup"
            Me.chkIncludeChildSupplierGroup.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildSupplierGroup.TabIndex = 7
            Me.chkIncludeChildSupplierGroup.Text = "������������Ѻ�����١"
            '
            'btnSpgCodeStart
            '
            Me.btnSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSpgCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSpgCodeStart.Image = CType(resources.GetObject("btnSpgCodeStart.Image"), System.Drawing.Image)
            Me.btnSpgCodeStart.Location = New System.Drawing.Point(592, 16)
            Me.btnSpgCodeStart.Name = "btnSpgCodeStart"
            Me.btnSpgCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnSpgCodeStart.TabIndex = 19
            Me.btnSpgCodeStart.TabStop = False
            Me.btnSpgCodeStart.ThemedImage = CType(resources.GetObject("btnSpgCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSpgCodeStart
            '
            Me.Validator.SetDataType(Me.txtSpgCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSpgCodeStart, "")
            Me.txtSpgCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSpgCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSpgCodeStart, System.Drawing.Color.Empty)
            Me.txtSpgCodeStart.Location = New System.Drawing.Point(496, 16)
            Me.txtSpgCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtSpgCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSpgCodeStart, "")
            Me.txtSpgCodeStart.Name = "txtSpgCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSpgCodeStart, "")
            Me.Validator.SetRequired(Me.txtSpgCodeStart, False)
            Me.txtSpgCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtSpgCodeStart.TabIndex = 3
            Me.txtSpgCodeStart.Text = ""
            '
            'lblSpgStart
            '
            Me.lblSpgStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSpgStart.ForeColor = System.Drawing.Color.Black
            Me.lblSpgStart.Location = New System.Drawing.Point(400, 16)
            Me.lblSpgStart.Name = "lblSpgStart"
            Me.lblSpgStart.Size = New System.Drawing.Size(88, 18)
            Me.lblSpgStart.TabIndex = 35
            Me.lblSpgStart.Text = "���������Ѻ����"
            Me.lblSpgStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSupplierGroupName
            '
            Me.Validator.SetDataType(Me.txtSupplierGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierGroupName, "")
            Me.txtSupplierGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSupplierGroupName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierGroupName, System.Drawing.Color.Empty)
            Me.txtSupplierGroupName.Location = New System.Drawing.Point(616, 16)
            Me.txtSupplierGroupName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtSupplierGroupName, "")
            Me.Validator.SetMinValue(Me.txtSupplierGroupName, "")
            Me.txtSupplierGroupName.Name = "txtSupplierGroupName"
            Me.txtSupplierGroupName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtSupplierGroupName, "")
            Me.Validator.SetRequired(Me.txtSupplierGroupName, False)
            Me.txtSupplierGroupName.Size = New System.Drawing.Size(160, 21)
            Me.txtSupplierGroupName.TabIndex = 36
            Me.txtSupplierGroupName.Text = ""
            '
            'cmbDocStatus
            '
            Me.cmbDocStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbDocStatus.Location = New System.Drawing.Point(120, 64)
            Me.cmbDocStatus.Name = "cmbDocStatus"
            Me.cmbDocStatus.Size = New System.Drawing.Size(120, 21)
            Me.cmbDocStatus.TabIndex = 6
            '
            'lblDocStatus
            '
            Me.lblDocStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocStatus.ForeColor = System.Drawing.Color.Black
            Me.lblDocStatus.Location = New System.Drawing.Point(32, 64)
            Me.lblDocStatus.Name = "lblDocStatus"
            Me.lblDocStatus.Size = New System.Drawing.Size(80, 18)
            Me.lblDocStatus.TabIndex = 31
            Me.lblDocStatus.Text = "ʶҹ��͡���"
            Me.lblDocStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSuppliEndFind
            '
            Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliEndFind.Image = CType(resources.GetObject("btnSuppliEndFind.Image"), System.Drawing.Image)
            Me.btnSuppliEndFind.Location = New System.Drawing.Point(752, 64)
            Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
            Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliEndFind.TabIndex = 21
            Me.btnSuppliEndFind.TabStop = False
            Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeEnd
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(656, 64)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
            Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtSuppliCodeEnd.TabIndex = 5
            Me.txtSuppliCodeEnd.Text = ""
            '
            'lblSuppliEnd
            '
            Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliEnd.Location = New System.Drawing.Point(624, 64)
            Me.lblSuppliEnd.Name = "lblSuppliEnd"
            Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblSuppliEnd.TabIndex = 22
            Me.lblSuppliEnd.Text = "�֧"
            Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSuppliStartFind
            '
            Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliStartFind.Image = CType(resources.GetObject("btnSuppliStartFind.Image"), System.Drawing.Image)
            Me.btnSuppliStartFind.Location = New System.Drawing.Point(592, 64)
            Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
            Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliStartFind.TabIndex = 9
            Me.btnSuppliStartFind.TabStop = False
            Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeStart
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.txtSuppliCodeStart.Location = New System.Drawing.Point(496, 64)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
            Me.txtSuppliCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtSuppliCodeStart.TabIndex = 4
            Me.txtSuppliCodeStart.Text = ""
            '
            'lblSuppliStart
            '
            Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliStart.Location = New System.Drawing.Point(424, 64)
            Me.lblSuppliStart.Name = "lblSuppliStart"
            Me.lblSuppliStart.Size = New System.Drawing.Size(64, 18)
            Me.lblSuppliStart.TabIndex = 19
            Me.lblSuppliStart.Text = "����Ѻ����"
            Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(120, 112)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 12
            Me.chkIncludeChildren.Text = "��� Cost Center �١"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
            Me.btnCCCodeStart.Location = New System.Drawing.Point(216, 88)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 22
            Me.btnCCCodeStart.TabStop = False
            Me.btnCCCodeStart.ThemedImage = CType(resources.GetObject("btnCCCodeStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCCCodeStart
            '
            Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
            Me.txtCCCodeStart.Location = New System.Drawing.Point(120, 88)
            Me.txtCCCodeStart.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCCCodeStart, "")
            Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
            Me.txtCCCodeStart.Name = "txtCCCodeStart"
            Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
            Me.Validator.SetRequired(Me.txtCCCodeStart, False)
            Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtCCCodeStart.TabIndex = 7
            Me.txtCCCodeStart.Text = ""
            '
            'lblCCStart
            '
            Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCCStart.ForeColor = System.Drawing.Color.Black
            Me.lblCCStart.Location = New System.Drawing.Point(8, 88)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(104, 18)
            Me.lblCCStart.TabIndex = 14
            Me.lblCCStart.Text = "Cost Center"
            Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(240, 88)
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
            Me.txtDocDateEnd.Location = New System.Drawing.Point(280, 16)
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
            'txtDocDateStart
            '
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(120, 16)
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
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateStart.Location = New System.Drawing.Point(120, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(280, 16)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(16, 16)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(96, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "������ѹ���"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(248, 16)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "�֧"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'txtEmployee
            '
            Me.Validator.SetDataType(Me.txtEmployee, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmployee, "")
            Me.txtEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmployee, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEmployee, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEmployee, System.Drawing.Color.Empty)
            Me.txtEmployee.Location = New System.Drawing.Point(496, 88)
            Me.txtEmployee.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtEmployee, "")
            Me.Validator.SetMinValue(Me.txtEmployee, "")
            Me.txtEmployee.Name = "txtEmployee"
            Me.Validator.SetRegularExpression(Me.txtEmployee, "")
            Me.Validator.SetRequired(Me.txtEmployee, False)
            Me.txtEmployee.Size = New System.Drawing.Size(96, 21)
            Me.txtEmployee.TabIndex = 8
            Me.txtEmployee.Text = ""
            '
            'btnEmployee
            '
            Me.btnEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnEmployee.ForeColor = System.Drawing.SystemColors.Control
            Me.btnEmployee.Image = CType(resources.GetObject("btnEmployee.Image"), System.Drawing.Image)
            Me.btnEmployee.Location = New System.Drawing.Point(592, 88)
            Me.btnEmployee.Name = "btnEmployee"
            Me.btnEmployee.Size = New System.Drawing.Size(24, 22)
            Me.btnEmployee.TabIndex = 19
            Me.btnEmployee.TabStop = False
            Me.btnEmployee.ThemedImage = CType(resources.GetObject("btnEmployee.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtEmployeeName
            '
            Me.Validator.SetDataType(Me.txtEmployeeName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtEmployeeName, "")
            Me.txtEmployeeName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtEmployeeName, -15)
            Me.Validator.SetInvalidBackColor(Me.txtEmployeeName, System.Drawing.Color.Empty)
            Me.txtEmployeeName.Location = New System.Drawing.Point(616, 88)
            Me.txtEmployeeName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtEmployeeName, "")
            Me.Validator.SetMinValue(Me.txtEmployeeName, "")
            Me.txtEmployeeName.Name = "txtEmployeeName"
            Me.txtEmployeeName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtEmployeeName, "")
            Me.Validator.SetRequired(Me.txtEmployeeName, False)
            Me.txtEmployeeName.Size = New System.Drawing.Size(160, 21)
            Me.txtEmployeeName.TabIndex = 36
            Me.txtEmployeeName.Text = ""
            '
            'lblEmployee
            '
            Me.lblEmployee.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblEmployee.ForeColor = System.Drawing.Color.Black
            Me.lblEmployee.Location = New System.Drawing.Point(408, 88)
            Me.lblEmployee.Name = "lblEmployee"
            Me.lblEmployee.Size = New System.Drawing.Size(80, 18)
            Me.lblEmployee.TabIndex = 35
            Me.lblEmployee.Text = "�����觨�ҧ"
            Me.lblEmployee.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(732, 192)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 3
            Me.btnSearch.Text = "����"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.ForeColor = System.Drawing.SystemColors.ControlText
            Me.btnReset.Location = New System.Drawing.Point(652, 192)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 2
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "������"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(808, 32)
            Me.txtTemp.MaxLength = 255
            Me.Validator.SetMaxValue(Me.txtTemp, "")
            Me.Validator.SetMinValue(Me.txtTemp, "")
            Me.txtTemp.Name = "txtTemp"
            Me.txtTemp.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTemp, "")
            Me.Validator.SetRequired(Me.txtTemp, False)
            Me.txtTemp.Size = New System.Drawing.Size(104, 21)
            Me.txtTemp.TabIndex = 3
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
            'RptVOFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptVOFilterSubPanel"
            Me.Size = New System.Drawing.Size(848, 224)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            ''If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            'Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.lblCostcenterStart}")
            'Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            'Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.lblSuppliStart}")
            'Me.Validator.SetDisplayName(txtSuppliCodeStart, lblSuppliStart.Text)

            'Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.lblDocDateStart}")
            'Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            'Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            'Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

            'Me.lblEmployee.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.lblEmployee}")

            '' Button
            'Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            'Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            '' GroupBox
            'Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.grbMaster}")
            'Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.grbDetail}")

            'Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.lblDocStatus}")

            'Me.lblSpgStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.lblSpgStart}")
            'Me.chkIncludeChildSupplierGroup.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.chkIncludeChildSupplierGroup}")

            'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.cbAll}"))
            'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.cbCancel}"))
            'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.cbSave}")) '�ѹ�֡����
            'Me.cmbDocStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.cbClose}")) '�Դ����
            'Me.cmbDocStatus.SelectedIndex = 0

            'ʶҹ��ٻẺ����ʴ���
            'Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.lblDocStatus}")
            'Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.cmbDocAll}")) '�͡�����觫��ͷ�����
            'Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.cmbDocApprove}")) '�͡�����觫��ͷ��͹��ѵ�����
            'Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptVOFilterSubPanel.cmbDocNoApprove}")) '�͡�����觫��ͷ���ѧ���͹��ѵ�
            'Me.cmbStatus.SelectedIndex = 0
        End Sub
#End Region

#Region "Member"
        Private m_cc As CostCenter
        Private m_subcontractor As Supplier
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
        'Private m_DueDateEnd As Date
        'Private m_DueDateStart As Date
        Private m_subcontractorgroup As SupplierGroup
        Private m_director As Employee
        Private m_entity As VO

        Private m_scstart As SC
        'Private m_sc As SC
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
        Public Property Costcenter() As Costcenter
            Get
                Return m_cc
            End Get
            Set(ByVal Value As Costcenter)
                m_cc = Value
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
        Public Property Director() As Employee
            Get
                Return m_director
            End Get
            Set(ByVal Value As Employee)
                m_director = Value
            End Set
        End Property
        Public Property SCStart() As SC
            Get
                Return m_scstart
            End Get
            Set(ByVal Value As SC)
                m_scstart = Value
            End Set
        End Property


#End Region

#Region "Methods"
        Private Sub RegisterDropdown()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocStatus, "vo_status", True)
            cmbDocStatus.SelectedIndex = 0
        End Sub
        Private Sub Initialize()
            RegisterDropdown()
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
            Me.Costcenter = New Costcenter

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))

            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            Me.SubcontractorGroup = New SupplierGroup
            Me.Director = New Employee
            If chkIncludeChildSupplierGroup.Checked Then
                chkIncludeChildSupplierGroup.Checked = False
            End If
            If chkIncludeChildren.Checked Then
                chkIncludeChildren.Checked = False
            End If

        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(11) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            'arr(2) = New Filter("DueDateStart", IIf(Me.DueDateStart.Equals(Date.MinValue), DBNull.Value, Me.DueDateStart))
            'arr(3) = New Filter("DueDateEnd", IIf(Me.DueDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DueDateEnd))
            arr(2) = New Filter("SubcontractorCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("SubcontractorCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(5) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(6) = New Filter("Docstatus", cmbDocStatus.SelectedIndex) ' IIf(cmbDocStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbDocStatus.SelectedItem, IdValuePair).Id))
            arr(7) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(8) = New Filter("SubcontractorGroupID", Me.ValidIdOrDBNull(m_subcontractorgroup))
            arr(9) = New Filter("IncludeChildSubcontractorGroup", Me.chkIncludeChildSupplierGroup.Checked)
            arr(10) = New Filter("Director", Me.ValidIdOrDBNull(Me.Director))
            'arr(11) = New Filter("sc", Me.ValidIdOrDBNull(Me.SCStart))
            arr(11) = New Filter("sc", IIf(Me.txtSCCode.TextLength > 0, Me.txtSCCode.Text, DBNull.Value))
            'arr(11) = New Filter("status", cmbStatus.SelectedIndex) ' IIf(cmbDocStatus.SelectedItem Is Nothing, DBNull.Value, CType(cmbDocStatus.SelectedItem, IdValuePair).Id))
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

            'Subcontract Start Group Code
            dpi = New DocPrintingItem
            dpi.Mapping = "SubcontractStartGroup"
            dpi.Value = Me.txtSpgCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Subcontract Start Group Name
            dpi = New DocPrintingItem
            dpi.Mapping = "SubcontractStartGroup"
            dpi.Value = Me.txtSupplierGroupName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Include ChildSupplierGroup
            If Me.chkIncludeChildSupplierGroup.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "IncludeChildSubcontractGroup"
                dpi.Value = "(�����ѧ�Ѵ����������)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CostCenter Start
            dpi = New DocPrintingItem
            dpi.Mapping = "CostcenterStart"
            dpi.Value = Me.txtCCCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'CostCenter Name
            dpi = New DocPrintingItem
            dpi.Mapping = "CostcenterStart"
            dpi.Value = Me.txtCostCenterName.Text
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


            'Subcontract Start
            dpi = New DocPrintingItem
            dpi.Mapping = "SubcontractStart"
            dpi.Value = Me.txtSuppliCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Subcontract End
            dpi = New DocPrintingItem
            dpi.Mapping = "SubcontractEnd"
            dpi.Value = Me.txtSuppliCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Employee Code
            dpi = New DocPrintingItem
            dpi.Mapping = "EmployeeCode"
            dpi.Value = Me.txtEmployee.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Employee Name
            dpi = New DocPrintingItem
            dpi.Mapping = "EmployeeName"
            dpi.Value = Me.txtEmployeeName.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)


            'DocStatus
            dpi = New DocPrintingItem
            dpi.Mapping = "DocStatus"
            dpi.Value = Me.cmbDocStatus.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)


            'Status
            dpi = New DocPrintingItem
            dpi.Mapping = "Status"
            dpi.Value = Me.cmbStatus.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)


            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtEmployee.Validated, AddressOf Me.ChangeProperty
            AddHandler btnEmployee.Click, AddressOf Me.btnEmployee_Click

            AddHandler btnSpgCodeStart.Click, AddressOf Me.btnSupplierGroupFind_Click
            AddHandler txtSpgCodeStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtSCCode.Validated, AddressOf Me.ChangeProperty
            'AddHandler txtSCCode.TextChanged, AddressOf Me.TextHandler

            AddHandler ibtnShowSCDialog.Click, AddressOf Me.btnSCFind_Click
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                Case "txtemployee"
                    Employee.GetEmployee(txtEmployee, Me.txtEmployeeName, Director)
                Case "txtspgcodestart"
                    SupplierGroup.GetSupplierGroup(txtSpgCodeStart, Me.txtSupplierGroupName, m_subcontractorgroup)
                Case "txtsccode"
                    'If scCodeChanged Then
                    If Me.m_entity.SC Is Nothing Then
                        Me.m_entity.SC = New SC
                    End If
                    'Dim txtName As TextBox
                    'dirtyFlag = SC.GetSC(txtSCCode, Me.m_entity.SC)
                    'm_isInitialized = True
                    'End If
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
                If data.GetDataPresent((New Costcenter).FullClassName) Then
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
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtsupplicodestart"
                            Me.SetSupplierStartDialog(entity)

                        Case "txtsupplicodeend"
                            Me.SetSupplierEndDialog(entity)

                    End Select
                End If
            End If
            ' Costcenter
            If data.GetDataPresent((New Costcenter).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Costcenter).FullClassName))
                Dim entity As New Costcenter(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtcostcentercodestart"
                            Me.SetCCCodeStartDialog(entity)

                        Case "txtcostcentercodeend"
                            Me.SetCCCodeStartDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        ' Supplier
        Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnsupplistartfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierStartDialog)

                Case "btnsuppliendfind"
                    myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierEndDialog)

            End Select
        End Sub
        Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeStart.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.Subcontractor)
        End Sub
        Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeEnd.Text = e.Code
            Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.Subcontractor)
        End Sub
        'Employee 
        Private Sub btnEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnemployee"
                    myEntityPanelService.OpenListDialog(New Employee, AddressOf SetEmployeeDialog)

            End Select
        End Sub
        Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
            Me.txtEmployee.Text = e.Code
            Employee.GetEmployee(txtEmployee, txtEmployeeName, Me.Director)
        End Sub
        ' Costcenter
        Private Sub btnCostcenterFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btncccodestart"
                    myEntityPanelService.OpenTreeDialog(New Costcenter, AddressOf SetCCCodeStartDialog)
            End Select
        End Sub
        Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtCCCodeStart.Text = e.Code
            Costcenter.GetCostCenter(txtCCCodeStart, txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
        ' SupplierGroup
        Private Sub btnSupplierGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnspgcodestart"
                    myEntityPanelService.OpenTreeDialog(New SupplierGroup, AddressOf SetSpgCodeStartDialog)
            End Select
        End Sub
        Private Sub SetSpgCodeStartDialog(ByVal e As ISimpleEntity)
            Me.txtSpgCodeStart.Text = e.Code
            SupplierGroup.GetSupplierGroup(txtSpgCodeStart, txtSupplierGroupName, m_subcontractorgroup, True)
        End Sub
        Private Sub btnSCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "ibtnshowscdialog"
                    myEntityPanelService.OpenListDialog(New SC, AddressOf SetSCDialog)
            End Select
        End Sub
        Private Sub SetSCDialog(ByVal e As ISimpleEntity)
            Me.txtSCCode.Text = e.Code
        End Sub
#End Region


       
    End Class
End Namespace

