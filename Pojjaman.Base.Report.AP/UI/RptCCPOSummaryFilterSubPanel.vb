Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptCCPOSummaryFilterSubPanel
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
        Friend WithEvents grbDisplay As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lblPOStart As System.Windows.Forms.Label
        Friend WithEvents txtPOStart As System.Windows.Forms.TextBox
        Friend WithEvents lblPOEnd As System.Windows.Forms.Label
        Friend WithEvents ibtnPOStart As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtPOEnd As System.Windows.Forms.TextBox
        Friend WithEvents ibtnPOEnd As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblSuppliStart As System.Windows.Forms.Label
        Friend WithEvents txtSuppliCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblSuppliEnd As System.Windows.Forms.Label
        Friend WithEvents btnSuppliStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtSuppliCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents btnSuppliEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents cmbStatus As System.Windows.Forms.ComboBox
        Friend WithEvents lblDocStatus As System.Windows.Forms.Label
        Friend WithEvents cmbOrderby As System.Windows.Forms.ComboBox
        Friend WithEvents lblOrderby As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptCCPOSummaryFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.lblPOStart = New System.Windows.Forms.Label
            Me.txtPOStart = New System.Windows.Forms.TextBox
            Me.lblPOEnd = New System.Windows.Forms.Label
            Me.ibtnPOStart = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtPOEnd = New System.Windows.Forms.TextBox
            Me.ibtnPOEnd = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.lblSuppliStart = New System.Windows.Forms.Label
            Me.txtSuppliCodeStart = New System.Windows.Forms.TextBox
            Me.lblSuppliEnd = New System.Windows.Forms.Label
            Me.btnSuppliStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtSuppliCodeEnd = New System.Windows.Forms.TextBox
            Me.btnSuppliEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
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
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.grbDisplay = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.cmbStatus = New System.Windows.Forms.ComboBox
            Me.lblDocStatus = New System.Windows.Forms.Label
            Me.cmbOrderby = New System.Windows.Forms.ComboBox
            Me.lblOrderby = New System.Windows.Forms.Label
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.grbDisplay.SuspendLayout()
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
            Me.grbMaster.Controls.Add(Me.grbDisplay)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 0)
            Me.grbMaster.Name = "grbMaster"
            Me.grbMaster.Size = New System.Drawing.Size(808, 192)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "���Ѻ"
            '
            'grbDetail
            '
            Me.grbDetail.Controls.Add(Me.lblPOStart)
            Me.grbDetail.Controls.Add(Me.txtPOStart)
            Me.grbDetail.Controls.Add(Me.lblPOEnd)
            Me.grbDetail.Controls.Add(Me.ibtnPOStart)
            Me.grbDetail.Controls.Add(Me.txtPOEnd)
            Me.grbDetail.Controls.Add(Me.ibtnPOEnd)
            Me.grbDetail.Controls.Add(Me.lblSuppliStart)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeStart)
            Me.grbDetail.Controls.Add(Me.lblSuppliEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliStartFind)
            Me.grbDetail.Controls.Add(Me.txtSuppliCodeEnd)
            Me.grbDetail.Controls.Add(Me.btnSuppliEndFind)
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
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(464, 160)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "�����ŷ����"
            '
            'lblPOStart
            '
            Me.lblPOStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPOStart.ForeColor = System.Drawing.Color.Black
            Me.lblPOStart.Location = New System.Drawing.Point(8, 96)
            Me.lblPOStart.Name = "lblPOStart"
            Me.lblPOStart.Size = New System.Drawing.Size(64, 18)
            Me.lblPOStart.TabIndex = 11
            Me.lblPOStart.Text = "PO"
            Me.lblPOStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtPOStart
            '
            Me.Validator.SetDataType(Me.txtPOStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPOStart, "")
            Me.txtPOStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPOStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPOStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPOStart, System.Drawing.Color.Empty)
            Me.txtPOStart.Location = New System.Drawing.Point(80, 96)
            Me.Validator.SetMaxValue(Me.txtPOStart, "")
            Me.Validator.SetMinValue(Me.txtPOStart, "")
            Me.txtPOStart.Name = "txtPOStart"
            Me.Validator.SetRegularExpression(Me.txtPOStart, "")
            Me.Validator.SetRequired(Me.txtPOStart, False)
            Me.txtPOStart.Size = New System.Drawing.Size(144, 21)
            Me.txtPOStart.TabIndex = 12
            Me.txtPOStart.Text = ""
            '
            'lblPOEnd
            '
            Me.lblPOEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPOEnd.ForeColor = System.Drawing.Color.Black
            Me.lblPOEnd.Location = New System.Drawing.Point(256, 96)
            Me.lblPOEnd.Name = "lblPOEnd"
            Me.lblPOEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblPOEnd.TabIndex = 14
            Me.lblPOEnd.Text = "�֧"
            Me.lblPOEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ibtnPOStart
            '
            Me.ibtnPOStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnPOStart.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnPOStart.Image = CType(resources.GetObject("ibtnPOStart.Image"), System.Drawing.Image)
            Me.ibtnPOStart.Location = New System.Drawing.Point(224, 96)
            Me.ibtnPOStart.Name = "ibtnPOStart"
            Me.ibtnPOStart.Size = New System.Drawing.Size(24, 22)
            Me.ibtnPOStart.TabIndex = 13
            Me.ibtnPOStart.TabStop = False
            Me.ibtnPOStart.ThemedImage = CType(resources.GetObject("ibtnPOStart.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtPOEnd
            '
            Me.Validator.SetDataType(Me.txtPOEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtPOEnd, "")
            Me.txtPOEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtPOEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtPOEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtPOEnd, System.Drawing.Color.Empty)
            Me.txtPOEnd.Location = New System.Drawing.Point(288, 96)
            Me.Validator.SetMaxValue(Me.txtPOEnd, "")
            Me.Validator.SetMinValue(Me.txtPOEnd, "")
            Me.txtPOEnd.Name = "txtPOEnd"
            Me.Validator.SetRegularExpression(Me.txtPOEnd, "")
            Me.Validator.SetRequired(Me.txtPOEnd, False)
            Me.txtPOEnd.Size = New System.Drawing.Size(144, 21)
            Me.txtPOEnd.TabIndex = 15
            Me.txtPOEnd.Text = ""
            '
            'ibtnPOEnd
            '
            Me.ibtnPOEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnPOEnd.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnPOEnd.Image = CType(resources.GetObject("ibtnPOEnd.Image"), System.Drawing.Image)
            Me.ibtnPOEnd.Location = New System.Drawing.Point(432, 96)
            Me.ibtnPOEnd.Name = "ibtnPOEnd"
            Me.ibtnPOEnd.Size = New System.Drawing.Size(24, 22)
            Me.ibtnPOEnd.TabIndex = 16
            Me.ibtnPOEnd.TabStop = False
            Me.ibtnPOEnd.ThemedImage = CType(resources.GetObject("ibtnPOEnd.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblSuppliStart
            '
            Me.lblSuppliStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliStart.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliStart.Location = New System.Drawing.Point(8, 120)
            Me.lblSuppliStart.Name = "lblSuppliStart"
            Me.lblSuppliStart.Size = New System.Drawing.Size(64, 18)
            Me.lblSuppliStart.TabIndex = 17
            Me.lblSuppliStart.Text = "�����"
            Me.lblSuppliStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSuppliCodeStart
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeStart, System.Drawing.Color.Empty)
            Me.txtSuppliCodeStart.Location = New System.Drawing.Point(80, 120)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeStart, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeStart, "")
            Me.txtSuppliCodeStart.Name = "txtSuppliCodeStart"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeStart, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeStart, False)
            Me.txtSuppliCodeStart.Size = New System.Drawing.Size(144, 21)
            Me.txtSuppliCodeStart.TabIndex = 18
            Me.txtSuppliCodeStart.Text = ""
            '
            'lblSuppliEnd
            '
            Me.lblSuppliEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSuppliEnd.ForeColor = System.Drawing.Color.Black
            Me.lblSuppliEnd.Location = New System.Drawing.Point(256, 120)
            Me.lblSuppliEnd.Name = "lblSuppliEnd"
            Me.lblSuppliEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblSuppliEnd.TabIndex = 20
            Me.lblSuppliEnd.Text = "�֧"
            Me.lblSuppliEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnSuppliStartFind
            '
            Me.btnSuppliStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliStartFind.Image = CType(resources.GetObject("btnSuppliStartFind.Image"), System.Drawing.Image)
            Me.btnSuppliStartFind.Location = New System.Drawing.Point(224, 120)
            Me.btnSuppliStartFind.Name = "btnSuppliStartFind"
            Me.btnSuppliStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliStartFind.TabIndex = 19
            Me.btnSuppliStartFind.TabStop = False
            Me.btnSuppliStartFind.ThemedImage = CType(resources.GetObject("btnSuppliStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtSuppliCodeEnd
            '
            Me.Validator.SetDataType(Me.txtSuppliCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtSuppliCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtSuppliCodeEnd, System.Drawing.Color.Empty)
            Me.txtSuppliCodeEnd.Location = New System.Drawing.Point(288, 120)
            Me.Validator.SetMaxValue(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtSuppliCodeEnd, "")
            Me.txtSuppliCodeEnd.Name = "txtSuppliCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtSuppliCodeEnd, "")
            Me.Validator.SetRequired(Me.txtSuppliCodeEnd, False)
            Me.txtSuppliCodeEnd.Size = New System.Drawing.Size(144, 21)
            Me.txtSuppliCodeEnd.TabIndex = 21
            Me.txtSuppliCodeEnd.Text = ""
            '
            'btnSuppliEndFind
            '
            Me.btnSuppliEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSuppliEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSuppliEndFind.Image = CType(resources.GetObject("btnSuppliEndFind.Image"), System.Drawing.Image)
            Me.btnSuppliEndFind.Location = New System.Drawing.Point(432, 120)
            Me.btnSuppliEndFind.Name = "btnSuppliEndFind"
            Me.btnSuppliEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnSuppliEndFind.TabIndex = 22
            Me.btnSuppliEndFind.TabStop = False
            Me.btnSuppliEndFind.ThemedImage = CType(resources.GetObject("btnSuppliEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkIncludeChildren
            '
            Me.chkIncludeChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkIncludeChildren.Location = New System.Drawing.Point(56, 64)
            Me.chkIncludeChildren.Name = "chkIncludeChildren"
            Me.chkIncludeChildren.Size = New System.Drawing.Size(128, 24)
            Me.chkIncludeChildren.TabIndex = 10
            Me.chkIncludeChildren.Text = "��� Cost Center �١"
            '
            'btnCCCodeStart
            '
            Me.btnCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCCodeStart.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCCodeStart.Image = CType(resources.GetObject("btnCCCodeStart.Image"), System.Drawing.Image)
            Me.btnCCCodeStart.Location = New System.Drawing.Point(216, 40)
            Me.btnCCCodeStart.Name = "btnCCCodeStart"
            Me.btnCCCodeStart.Size = New System.Drawing.Size(24, 22)
            Me.btnCCCodeStart.TabIndex = 8
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
            Me.txtCCCodeStart.Location = New System.Drawing.Point(120, 40)
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
            Me.lblCCStart.Location = New System.Drawing.Point(8, 40)
            Me.lblCCStart.Name = "lblCCStart"
            Me.lblCCStart.Size = New System.Drawing.Size(104, 18)
            Me.lblCCStart.TabIndex = 6
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
            Me.txtCostCenterName.Location = New System.Drawing.Point(240, 40)
            Me.txtCostCenterName.MaxLength = 50
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.txtCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(160, 21)
            Me.txtCostCenterName.TabIndex = 9
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
            Me.txtDocDateEnd.TabIndex = 4
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
            Me.lblDocDateStart.Location = New System.Drawing.Point(56, 16)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "�����"
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
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(720, 144)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 3
            Me.btnSearch.Text = "����"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(632, 144)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 2
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "������"
            '
            'grbDisplay
            '
            Me.grbDisplay.Controls.Add(Me.cmbStatus)
            Me.grbDisplay.Controls.Add(Me.lblDocStatus)
            Me.grbDisplay.Controls.Add(Me.cmbOrderby)
            Me.grbDisplay.Controls.Add(Me.lblOrderby)
            Me.grbDisplay.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDisplay.Location = New System.Drawing.Point(480, 16)
            Me.grbDisplay.Name = "grbDisplay"
            Me.grbDisplay.Size = New System.Drawing.Size(312, 72)
            Me.grbDisplay.TabIndex = 1
            Me.grbDisplay.TabStop = False
            Me.grbDisplay.Text = "�ٻẺ����ʴ���"
            '
            'cmbStatus
            '
            Me.cmbStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbStatus.Location = New System.Drawing.Point(136, 40)
            Me.cmbStatus.Name = "cmbStatus"
            Me.cmbStatus.Size = New System.Drawing.Size(168, 21)
            Me.cmbStatus.TabIndex = 3
            '
            'lblDocStatus
            '
            Me.lblDocStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocStatus.ForeColor = System.Drawing.Color.Black
            Me.lblDocStatus.Location = New System.Drawing.Point(72, 40)
            Me.lblDocStatus.Name = "lblDocStatus"
            Me.lblDocStatus.Size = New System.Drawing.Size(56, 18)
            Me.lblDocStatus.TabIndex = 2
            Me.lblDocStatus.Text = "ʶҹ�"
            Me.lblDocStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbOrderby
            '
            Me.cmbOrderby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbOrderby.Location = New System.Drawing.Point(136, 16)
            Me.cmbOrderby.Name = "cmbOrderby"
            Me.cmbOrderby.Size = New System.Drawing.Size(168, 21)
            Me.cmbOrderby.TabIndex = 1
            '
            'lblOrderby
            '
            Me.lblOrderby.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblOrderby.ForeColor = System.Drawing.Color.Black
            Me.lblOrderby.Location = New System.Drawing.Point(8, 16)
            Me.lblOrderby.Name = "lblOrderby"
            Me.lblOrderby.Size = New System.Drawing.Size(120, 18)
            Me.lblOrderby.TabIndex = 0
            Me.lblOrderby.Text = "���§�����ŵ��"
            Me.lblOrderby.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(528, 32)
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
            'RptCCPOSummaryFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptCCPOSummaryFilterSubPanel"
            Me.Size = New System.Drawing.Size(832, 200)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDisplay.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region


#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.lblCostcenterStart}")
            Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.grbDetail}")

            ' Combobox 
            Me.lblOrderby.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.lblOrderby}") '���§�����ŵ��
            Me.cmbOrderby.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.cmbPODocCode}")) '�Ţ����͡���
            Me.cmbOrderby.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.cmbPODocdate}")) '�ѹ���ͧ�͡���
            Me.cmbOrderby.SelectedIndex = 0

            Me.lblDocStatus.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.lblStatus}") 'ʶҹ�
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.cmbDocAll}")) '�͡�����觫��ͷ�����
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.cmbDocApprove}")) '�͡�����觫��ͷ��͹��ѵ�����
            Me.cmbStatus.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.cmbDocNoApprove}")) '�͡�����觫��ͷ���ѧ���͹��ѵ�

            Me.cmbStatus.SelectedIndex = 0

            Me.grbDisplay.Text = Me.StringParserService.Parse("${res:Global.grbDisplay}")
            Me.chkIncludeChildren.Text = Me.StringParserService.Parse("${res:Global.chkIncludeChildren}")
            Me.lblPOStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptCCPOSummaryFilterSubPanel.lblPOStart}")
            Me.lblPOEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.lblSuppliStart.Text = Me.StringParserService.Parse("${res:Global.SupplierText}")
            Me.lblSuppliEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")

        End Sub
#End Region

#Region "Member"
        Private m_cc As Costcenter
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
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
        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
#End Region

#Region "Methods"

        Private Sub Initialize()
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

            Me.Costcenter = New Costcenter

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(10) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("cc_id", Me.ValidIdOrDBNull(m_cc))
            arr(3) = New Filter("IncludeChildCC", Me.chkIncludeChildren.Checked)
            arr(4) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            arr(5) = New Filter("Orderby", Me.cmbOrderby.SelectedIndex)
            arr(6) = New Filter("SuppliCodeStart", IIf(txtSuppliCodeStart.TextLength > 0, txtSuppliCodeStart.Text, DBNull.Value))
            arr(7) = New Filter("SuppliCodeEnd", IIf(txtSuppliCodeEnd.TextLength > 0, txtSuppliCodeEnd.Text, DBNull.Value))
            arr(8) = New Filter("POCodeStart", IIf(txtPOStart.TextLength > 0, txtPOStart.Text, DBNull.Value))
            arr(9) = New Filter("POCodeEnd", IIf(txtPOEnd.TextLength > 0, txtPOEnd.Text, DBNull.Value))
            arr(10) = New Filter("Status", Me.cmbStatus.SelectedIndex)
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

            'CheckBox ChildInclude
            If Me.chkIncludeChildren.Checked Then
                dpi = New DocPrintingItem
                dpi.Mapping = "childincluded"
                dpi.Value = "(�����ѧ�Ѵ)"
                dpi.DataType = "System.String"
                dpiColl.Add(dpi)
            End If

            'CostCenter Start
            dpi = New DocPrintingItem
            dpi.Mapping = "CostCenterName"
            dpi.Value = Me.txtCostCenterName.Text
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

            AddHandler btnCCCodeStart.Click, AddressOf Me.btnCostcenterFind_Click
            AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler btnSuppliStartFind.Click, AddressOf Me.btnSupplierFind_Click
            AddHandler btnSuppliEndFind.Click, AddressOf Me.btnSupplierFind_Click

            AddHandler ibtnPOStart.Click, AddressOf Me.btnPOFind_Click
            AddHandler ibtnPOEnd.Click, AddressOf Me.btnPOFind_Click
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccodestart"
                    Costcenter.GetCostCenter(txtCCCodeStart, Me.txtCostCenterName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)

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
        Private Sub btnPOFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim thePO As New PO
            Select Case CType(sender, Control).Name.ToLower
                Case "ibtnpostart"
                    myEntityPanelService.OpenListDialog(thePO, AddressOf SetPOStartDialog)
                Case "ibtnpoend"
                    myEntityPanelService.OpenListDialog(thePO, AddressOf SetPOEndDialog)
            End Select
            thePO = Nothing
        End Sub
        Private Sub SetSupplierStartDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeStart.Text = e.Code
        End Sub
        Private Sub SetSupplierEndDialog(ByVal e As ISimpleEntity)
            Me.txtSuppliCodeEnd.Text = e.Code
        End Sub
        Private Sub SetPOStartDialog(ByVal e As ISimpleEntity)
            Me.txtPOStart.Text = e.Code
        End Sub
        Private Sub SetPOEndDialog(ByVal e As ISimpleEntity)
            Me.txtPOEnd.Text = e.Code
        End Sub
#End Region

    End Class
End Namespace

