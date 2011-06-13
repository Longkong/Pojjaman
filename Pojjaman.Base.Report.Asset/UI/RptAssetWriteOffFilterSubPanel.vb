Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptAssetWriteOffFilterSubPanel
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
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents btnCCStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkIncludeTGChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents btnAssetStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAssetEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtAssetCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblAssetEnd As System.Windows.Forms.Label
    Friend WithEvents txtAssetCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAssetStart As System.Windows.Forms.Label
    Friend WithEvents txtAssetTypeCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents btnAssetTypeEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnAssetTypeStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblAssetTypeEnd As System.Windows.Forms.Label
    Friend WithEvents txtAssetTypeCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblAssetTypeStart As System.Windows.Forms.Label
    Friend WithEvents txttmp As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptAssetWriteOffFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnCCStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
      Me.txtDocDateStart = New System.Windows.Forms.TextBox()
      Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
      Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
      Me.lblDocDateStart = New System.Windows.Forms.Label()
      Me.lblDocDateEnd = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txttmp = New System.Windows.Forms.TextBox()
      Me.chkIncludeTGChildren = New System.Windows.Forms.CheckBox()
      Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtGroupCode = New System.Windows.Forms.TextBox()
      Me.lblGroup = New System.Windows.Forms.Label()
      Me.txtGroupName = New System.Windows.Forms.TextBox()
      Me.btnAssetStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAssetEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtAssetCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblAssetEnd = New System.Windows.Forms.Label()
      Me.txtAssetCodeStart = New System.Windows.Forms.TextBox()
      Me.lblAssetStart = New System.Windows.Forms.Label()
      Me.txtAssetTypeCodeEnd = New System.Windows.Forms.TextBox()
      Me.btnAssetTypeEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnAssetTypeStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.lblAssetTypeEnd = New System.Windows.Forms.Label()
      Me.txtAssetTypeCodeStart = New System.Windows.Forms.TextBox()
      Me.lblAssetTypeStart = New System.Windows.Forms.Label()
      Me.grbMaster.SuspendLayout()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
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
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(12, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(449, 224)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "����"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.btnAssetStartFind)
      Me.grbDetail.Controls.Add(Me.chkIncludeTGChildren)
      Me.grbDetail.Controls.Add(Me.btnAssetEndFind)
      Me.grbDetail.Controls.Add(Me.btnGroupFind)
      Me.grbDetail.Controls.Add(Me.txtAssetCodeEnd)
      Me.grbDetail.Controls.Add(Me.txtGroupCode)
      Me.grbDetail.Controls.Add(Me.lblAssetEnd)
      Me.grbDetail.Controls.Add(Me.lblGroup)
      Me.grbDetail.Controls.Add(Me.txtAssetCodeStart)
      Me.grbDetail.Controls.Add(Me.txtGroupName)
      Me.grbDetail.Controls.Add(Me.lblAssetStart)
      Me.grbDetail.Controls.Add(Me.btnCCStartFind)
      Me.grbDetail.Controls.Add(Me.txtAssetTypeCodeEnd)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.btnAssetTypeEndFind)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.btnAssetTypeStartFind)
      Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblAssetTypeEnd)
      Me.grbDetail.Controls.Add(Me.txtDocDateStart)
      Me.grbDetail.Controls.Add(Me.txtAssetTypeCodeStart)
      Me.grbDetail.Controls.Add(Me.lblAssetTypeStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
      Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
      Me.grbDetail.Controls.Add(Me.lblDocDateStart)
      Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(6, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(435, 170)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "�����ŷ����"
      '
      'btnCCStartFind
      '
      Me.btnCCStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCStartFind.Location = New System.Drawing.Point(208, 40)
      Me.btnCCStartFind.Name = "btnCCStartFind"
      Me.btnCCStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCStartFind.TabIndex = 31
      Me.btnCCStartFind.TabStop = False
      Me.btnCCStartFind.ThemedImage = CType(resources.GetObject("btnCCStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(112, 41)
      Me.Validator.SetMinValue(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Name = "txtCCCodeStart"
      Me.Validator.SetRegularExpression(Me.txtCCCodeStart, "")
      Me.Validator.SetRequired(Me.txtCCCodeStart, False)
      Me.txtCCCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtCCCodeStart.TabIndex = 6
      '
      'lblCCStart
      '
      Me.lblCCStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCCStart.ForeColor = System.Drawing.Color.Black
      Me.lblCCStart.Location = New System.Drawing.Point(6, 41)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(104, 18)
      Me.lblCCStart.TabIndex = 26
      Me.lblCCStart.Text = "CostCenter ��Ңͧ"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDateEnd
      '
      Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
      Me.txtDocDateEnd.Location = New System.Drawing.Point(277, 16)
      Me.txtDocDateEnd.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
      Me.txtDocDateEnd.Name = "txtDocDateEnd"
      Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
      Me.Validator.SetRequired(Me.txtDocDateEnd, False)
      Me.txtDocDateEnd.Size = New System.Drawing.Size(102, 21)
      Me.txtDocDateEnd.TabIndex = 1
      '
      'txtDocDateStart
      '
      Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
      Me.txtDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.txtDocDateStart.MaxLength = 10
      Me.Validator.SetMinValue(Me.txtDocDateStart, "")
      Me.txtDocDateStart.Name = "txtDocDateStart"
      Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
      Me.Validator.SetRequired(Me.txtDocDateStart, False)
      Me.txtDocDateStart.Size = New System.Drawing.Size(96, 21)
      Me.txtDocDateStart.TabIndex = 0
      '
      'dtpDocDateStart
      '
      Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateStart.Location = New System.Drawing.Point(112, 16)
      Me.dtpDocDateStart.Name = "dtpDocDateStart"
      Me.dtpDocDateStart.Size = New System.Drawing.Size(129, 21)
      Me.dtpDocDateStart.TabIndex = 2
      Me.dtpDocDateStart.TabStop = False
      '
      'dtpDocDateEnd
      '
      Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
      Me.dtpDocDateEnd.Location = New System.Drawing.Point(292, 16)
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
      Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
      Me.lblDocDateStart.TabIndex = 0
      Me.lblDocDateStart.Text = "�����"
      Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblDocDateEnd
      '
      Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
      Me.lblDocDateEnd.Location = New System.Drawing.Point(247, 16)
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
      Me.btnSearch.Location = New System.Drawing.Point(361, 192)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "����"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(281, 192)
      Me.btnReset.Name = "btnReset"
      Me.btnReset.Size = New System.Drawing.Size(75, 23)
      Me.btnReset.TabIndex = 1
      Me.btnReset.TabStop = False
      Me.btnReset.Text = "������"
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
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'txttmp
      '
      Me.Validator.SetDataType(Me.txttmp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txttmp, "")
      Me.txttmp.Enabled = False
      Me.Validator.SetGotFocusBackColor(Me.txttmp, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txttmp, -15)
      Me.Validator.SetInvalidBackColor(Me.txttmp, System.Drawing.Color.Empty)
      Me.txttmp.Location = New System.Drawing.Point(521, 88)
      Me.txttmp.MaxLength = 10
      Me.Validator.SetMinValue(Me.txttmp, "")
      Me.txttmp.Name = "txttmp"
      Me.Validator.SetRegularExpression(Me.txttmp, "")
      Me.Validator.SetRequired(Me.txttmp, False)
      Me.txttmp.Size = New System.Drawing.Size(102, 21)
      Me.txttmp.TabIndex = 6
      Me.txttmp.Visible = False
      '
      'chkIncludeTGChildren
      '
      Me.chkIncludeTGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeTGChildren.Location = New System.Drawing.Point(112, 141)
      Me.chkIncludeTGChildren.Name = "chkIncludeTGChildren"
      Me.chkIncludeTGChildren.Size = New System.Drawing.Size(128, 21)
      Me.chkIncludeTGChildren.TabIndex = 65
      Me.chkIncludeTGChildren.Text = "������������ͧ���"
      '
      'btnGroupFind
      '
      Me.btnGroupFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnGroupFind.Location = New System.Drawing.Point(352, 115)
      Me.btnGroupFind.Name = "btnGroupFind"
      Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupFind.TabIndex = 64
      Me.btnGroupFind.TabStop = False
      Me.btnGroupFind.ThemedImage = CType(resources.GetObject("btnGroupFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtGroupCode
      '
      Me.Validator.SetDataType(Me.txtGroupCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGroupCode, "")
      Me.txtGroupCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGroupCode, System.Drawing.Color.Empty)
      Me.txtGroupCode.Location = New System.Drawing.Point(112, 115)
      Me.txtGroupCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtGroupCode, "")
      Me.txtGroupCode.Name = "txtGroupCode"
      Me.Validator.SetRegularExpression(Me.txtGroupCode, "")
      Me.Validator.SetRequired(Me.txtGroupCode, False)
      Me.txtGroupCode.Size = New System.Drawing.Size(96, 21)
      Me.txtGroupCode.TabIndex = 62
      '
      'lblGroup
      '
      Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGroup.ForeColor = System.Drawing.Color.Black
      Me.lblGroup.Location = New System.Drawing.Point(32, 115)
      Me.lblGroup.Name = "lblGroup"
      Me.lblGroup.Size = New System.Drawing.Size(72, 18)
      Me.lblGroup.TabIndex = 61
      Me.lblGroup.Text = "���������ͧ���:"
      Me.lblGroup.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtGroupName
      '
      Me.txtGroupName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtGroupName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtGroupName, "")
      Me.txtGroupName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtGroupName, System.Drawing.Color.Empty)
      Me.txtGroupName.Location = New System.Drawing.Point(208, 115)
      Me.Validator.SetMinValue(Me.txtGroupName, "")
      Me.txtGroupName.Name = "txtGroupName"
      Me.txtGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGroupName, "")
      Me.Validator.SetRequired(Me.txtGroupName, False)
      Me.txtGroupName.Size = New System.Drawing.Size(144, 21)
      Me.txtGroupName.TabIndex = 63
      Me.txtGroupName.TabStop = False
      '
      'btnAssetStartFind
      '
      Me.btnAssetStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetStartFind.Location = New System.Drawing.Point(208, 90)
      Me.btnAssetStartFind.Name = "btnAssetStartFind"
      Me.btnAssetStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetStartFind.TabIndex = 35
      Me.btnAssetStartFind.TabStop = False
      Me.btnAssetStartFind.ThemedImage = CType(resources.GetObject("btnAssetStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAssetEndFind
      '
      Me.btnAssetEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetEndFind.Location = New System.Drawing.Point(368, 90)
      Me.btnAssetEndFind.Name = "btnAssetEndFind"
      Me.btnAssetEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetEndFind.TabIndex = 33
      Me.btnAssetEndFind.TabStop = False
      Me.btnAssetEndFind.ThemedImage = CType(resources.GetObject("btnAssetEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtAssetCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAssetCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetCodeEnd, "")
      Me.txtAssetCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAssetCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAssetCodeEnd, System.Drawing.Color.Empty)
      Me.txtAssetCodeEnd.Location = New System.Drawing.Point(272, 90)
      Me.Validator.SetMinValue(Me.txtAssetCodeEnd, "")
      Me.txtAssetCodeEnd.Name = "txtAssetCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAssetCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAssetCodeEnd, False)
      Me.txtAssetCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetCodeEnd.TabIndex = 32
      '
      'lblAssetEnd
      '
      Me.lblAssetEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAssetEnd.Location = New System.Drawing.Point(240, 90)
      Me.lblAssetEnd.Name = "lblAssetEnd"
      Me.lblAssetEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAssetEnd.TabIndex = 30
      Me.lblAssetEnd.Text = "�֧"
      Me.lblAssetEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtAssetCodeStart
      '
      Me.Validator.SetDataType(Me.txtAssetCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetCodeStart, "")
      Me.txtAssetCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAssetCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAssetCodeStart, System.Drawing.Color.Empty)
      Me.txtAssetCodeStart.Location = New System.Drawing.Point(112, 90)
      Me.Validator.SetMinValue(Me.txtAssetCodeStart, "")
      Me.txtAssetCodeStart.Name = "txtAssetCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAssetCodeStart, "")
      Me.Validator.SetRequired(Me.txtAssetCodeStart, False)
      Me.txtAssetCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetCodeStart.TabIndex = 31
      '
      'lblAssetStart
      '
      Me.lblAssetStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetStart.ForeColor = System.Drawing.Color.Black
      Me.lblAssetStart.Location = New System.Drawing.Point(16, 90)
      Me.lblAssetStart.Name = "lblAssetStart"
      Me.lblAssetStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAssetStart.TabIndex = 26
      Me.lblAssetStart.Text = "�����Թ��Ѿ��:"
      Me.lblAssetStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAssetTypeCodeEnd
      '
      Me.Validator.SetDataType(Me.txtAssetTypeCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetTypeCodeEnd, "")
      Me.txtAssetTypeCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetTypeCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAssetTypeCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAssetTypeCodeEnd, System.Drawing.Color.Empty)
      Me.txtAssetTypeCodeEnd.Location = New System.Drawing.Point(272, 66)
      Me.Validator.SetMinValue(Me.txtAssetTypeCodeEnd, "")
      Me.txtAssetTypeCodeEnd.Name = "txtAssetTypeCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtAssetTypeCodeEnd, "")
      Me.Validator.SetRequired(Me.txtAssetTypeCodeEnd, False)
      Me.txtAssetTypeCodeEnd.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetTypeCodeEnd.TabIndex = 29
      '
      'btnAssetTypeEndFind
      '
      Me.btnAssetTypeEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetTypeEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetTypeEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetTypeEndFind.Location = New System.Drawing.Point(368, 66)
      Me.btnAssetTypeEndFind.Name = "btnAssetTypeEndFind"
      Me.btnAssetTypeEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetTypeEndFind.TabIndex = 34
      Me.btnAssetTypeEndFind.TabStop = False
      Me.btnAssetTypeEndFind.ThemedImage = CType(resources.GetObject("btnAssetTypeEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnAssetTypeStartFind
      '
      Me.btnAssetTypeStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnAssetTypeStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnAssetTypeStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnAssetTypeStartFind.Location = New System.Drawing.Point(208, 66)
      Me.btnAssetTypeStartFind.Name = "btnAssetTypeStartFind"
      Me.btnAssetTypeStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnAssetTypeStartFind.TabIndex = 36
      Me.btnAssetTypeStartFind.TabStop = False
      Me.btnAssetTypeStartFind.ThemedImage = CType(resources.GetObject("btnAssetTypeStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblAssetTypeEnd
      '
      Me.lblAssetTypeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetTypeEnd.ForeColor = System.Drawing.Color.Black
      Me.lblAssetTypeEnd.Location = New System.Drawing.Point(240, 66)
      Me.lblAssetTypeEnd.Name = "lblAssetTypeEnd"
      Me.lblAssetTypeEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblAssetTypeEnd.TabIndex = 28
      Me.lblAssetTypeEnd.Text = "�֧"
      Me.lblAssetTypeEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtAssetTypeCodeStart
      '
      Me.Validator.SetDataType(Me.txtAssetTypeCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAssetTypeCodeStart, "")
      Me.txtAssetTypeCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAssetTypeCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtAssetTypeCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtAssetTypeCodeStart, System.Drawing.Color.Empty)
      Me.txtAssetTypeCodeStart.Location = New System.Drawing.Point(112, 66)
      Me.Validator.SetMinValue(Me.txtAssetTypeCodeStart, "")
      Me.txtAssetTypeCodeStart.Name = "txtAssetTypeCodeStart"
      Me.Validator.SetRegularExpression(Me.txtAssetTypeCodeStart, "")
      Me.Validator.SetRequired(Me.txtAssetTypeCodeStart, False)
      Me.txtAssetTypeCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtAssetTypeCodeStart.TabIndex = 27
      '
      'lblAssetTypeStart
      '
      Me.lblAssetTypeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAssetTypeStart.ForeColor = System.Drawing.Color.Black
      Me.lblAssetTypeStart.Location = New System.Drawing.Point(16, 66)
      Me.lblAssetTypeStart.Name = "lblAssetTypeStart"
      Me.lblAssetTypeStart.Size = New System.Drawing.Size(88, 18)
      Me.lblAssetTypeStart.TabIndex = 25
      Me.lblAssetTypeStart.Text = "�������Թ��Ѿ��:"
      Me.lblAssetTypeStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'RptAssetWriteOffFilterSubPanel
      '
      Me.Controls.Add(Me.txttmp)
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptAssetWriteOffFilterSubPanel"
      Me.Size = New System.Drawing.Size(677, 246)
      Me.grbMaster.ResumeLayout(False)
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub

#End Region

#Region " SetLabelText "
    Public Sub SetLabelText()
      ''If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      'Me.lblEQCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptEquipmentStatus.EquipmentCode}")
      'Me.Validator.SetDisplayName(txtEQCodeStart, lblEQCode.Text)

      Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.lblDocDateStart}")
      Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptEquipmentStatusFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      '' Global {�֧}
      'Me.lblEQEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      'Me.Validator.SetDisplayName(txtEQCodeEnd, lblEQEnd.Text)

      Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.grbDetail}")
    End Sub
#End Region

#Region "Member"
    Private m_equipmentstart As EquipmentItem
    Private m_equipmentend As EquipmentItem

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_cc As CostCenter
    Dim m_toolgroup As New ToolGroup
    Private m_assetstart As Asset
    Private m_assetend As Asset

    Private m_assettypestart As AssetType
    Private m_assettypeend As AssetType
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
    Public Property equipmentstart() As EquipmentItem
      Get
        Return m_equipmentstart
      End Get
      Set(ByVal Value As EquipmentItem)
        m_equipmentstart = Value
      End Set
    End Property
    Public Property EquipmentEnd() As EquipmentItem
      Get
        Return m_equipmentend
      End Get
      Set(ByVal Value As EquipmentItem)
        m_equipmentend = Value
      End Set
    End Property
    Public Property AssetStart() As Asset
      Get
        Return m_assetstart
      End Get
      Set(ByVal Value As Asset)
        m_assetstart = Value
      End Set
    End Property
    Public Property AssetEnd() As Asset
      Get
        Return m_assetend
      End Get
      Set(ByVal Value As Asset)
        m_assetend = Value
      End Set
    End Property
    Public Property AssetTypeStart() As AssetType
      Get
        Return m_assettypestart
      End Get
      Set(ByVal Value As AssetType)
        m_assettypestart = Value
      End Set
    End Property
    Public Property AssetTypeEnd() As AssetType
      Get
        Return m_assettypeend
      End Get
      Set(ByVal Value As AssetType)
        m_assettypeend = Value
      End Set
    End Property
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property

    Public Property CostCenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
      End Set
    End Property
    Private Property Group() As ToolGroup
      Get
        Return m_toolgroup
      End Get
      Set(ByVal Value As ToolGroup)
        m_toolgroup = Value
      End Set
    End Property
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

      Me.CostCenter = New CostCenter

      Me.equipmentstart = New EquipmentItem
      Me.EquipmentEnd = New EquipmentItem

      Me.AssetStart = New Asset
      Me.AssetEnd = New Asset
      Me.AssetTypeStart = New AssetType
      Me.AssetTypeEnd = New AssetType

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.Group = New ToolGroup
      Me.chkIncludeTGChildren.Checked = False
      'Me.ChkCancel.Checked = False

    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(9) As Filter
      arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      'arr(2) = New Filter("EquipmentCodeStart", IIf(txtEQCodeStart.TextLength > 0, txtEQCodeStart.Text, DBNull.Value))
      'arr(3) = New Filter("EquipmentCodeEnd", IIf(txtEQCodeEnd.TextLength > 0, txtEQCodeEnd.Text, DBNull.Value))
      arr(2) = New Filter("CostCenter", IIf(txtCCCodeStart.TextLength > 0, txtCCCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(4) = New Filter("ToolGroup", IIf(Me.Group.Valid, Me.Group.Id, DBNull.Value))
      arr(5) = New Filter("includeChildtg", Me.chkIncludeTGChildren.Checked)
      arr(6) = New Filter("AssetCodeStart", IIf(txtAssetCodeStart.TextLength > 0, txtAssetCodeStart.Text, DBNull.Value))
      arr(7) = New Filter("AssetCodeEnd", IIf(txtAssetCodeEnd.TextLength > 0, txtAssetCodeEnd.Text, DBNull.Value))
      arr(8) = New Filter("AssetTypeCodeStart", IIf(txtAssetTypeCodeStart.TextLength > 0, txtAssetTypeCodeStart.Text, DBNull.Value))
      arr(9) = New Filter("AssetTypeCodeEnd", IIf(txtAssetTypeCodeEnd.TextLength > 0, txtAssetTypeCodeEnd.Text, DBNull.Value))
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

#Region " IReportFilterSubPanel "
    Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

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

      ''EquipmentCodeStart 
      'dpi = New DocPrintingItem
      'dpi.Mapping = "EquipmentCodeStart"
      'dpi.Value = Me.txtEQCodeStart.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      ''EquipmentCodeEnd
      'dpi = New DocPrintingItem
      'dpi.Mapping = "EquipmentCodeEnd"
      'dpi.Value = Me.txtEQCodeEnd.Text
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      'CostCenterStart
      dpi = New DocPrintingItem
      dpi.Mapping = "Costcenter"
      dpi.Value = Me.txtCCCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'today
      dpi = New DocPrintingItem
      dpi.Mapping = "today"
      dpi.Value = MinDateToNull(Now, "") + " : " + Now.ToShortTimeString
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

#Region " ChangeProperty "
    Private Sub EventWiring()
      'AddHandler btnEQStartFind.Click, AddressOf Me.btnEQFind_Click
      'AddHandler btnEQEndFind.Click, AddressOf Me.btnEQFind_Click

      AddHandler btnCCStartFind.Click, AddressOf Me.btnCCFind_Click
      'AddHandler btnCCEndFind.Click, AddressOf Me.btnCCFind_Click

      AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty

      AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    'Private m_ccSetting As Boolean = False

    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txtcccodestart"
          'If Not m_ccSetting Then
          CostCenter.GetCostCenter(txtCCCodeStart, txttmp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          'Else
          'm_ccSetting = False
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
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtEQcodestart", "txtEQcodeend"
                Return True
            End Select
          End If
        End If
        ' CostCenter
        If data.GetDataPresent((New CostCenter).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtcccodestart"
                Return True
            End Select
          End If
        End If
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Dim data As IDataObject = Clipboard.GetDataObject
      If data.GetDataPresent((New Supplier).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
        Dim entity As New Supplier(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtEQcodestart"
              'Me.SetEQStartDialog(entity)

            Case "txtEQcodeend"
              'Me.SetEQEndDialog(entity)

          End Select
        End If
      End If
      ' CostCenter
      If data.GetDataPresent((New CostCenter).FullClassName) Then
        Dim id As Integer = CInt(data.GetData((New CostCenter).FullClassName))
        Dim entity As New CostCenter(id)
        If Not Me.ActiveControl Is Nothing Then
          Select Case Me.ActiveControl.Name.ToLower
            Case "txtcccodestart"
              Me.SetCCCodeStartDialog(entity)

            Case "txtcccodestart"
              Me.SetCCCodeStartDialog(entity)
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    'Private Sub btnEQFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Select Case CType(sender, Control).Name.ToLower
    '    Case "btneqstartfind"
    '      myEntityPanelService.OpenListDialog(New EquipmentItem, AddressOf SetEQStartDialog)

    '    Case "btneqendfind"
    '      myEntityPanelService.OpenListDialog(New EquipmentItem, AddressOf SetEQEndDialog)
    '  End Select
    'End Sub
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnccstartfind"

          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)

      End Select
    End Sub
    'Private Sub SetEQStartDialog(ByVal e As ISimpleEntity)
    '  Me.txtEQCodeStart.Text = e.Code
    '  EquipmentItem.GetEquipmentItem(txtEQCodeStart, txttmp, Me.equipmentstart)
    'End Sub
    'Private Sub SetEQEndDialog(ByVal e As ISimpleEntity)
    '  Me.txtEQCodeEnd.Text = e.Code
    '  EquipmentItem.GetEquipmentItem(txtEQCodeEnd, txttmp, Me.EquipmentEnd)
    'End Sub
    Private Sub SetCCCodeStartDialog(ByVal e As ISimpleEntity)
      'm_ccSetting = True
      Me.txtCCCodeStart.Text = e.Code
      CostCenter.GetCostCenter(txtCCCodeStart, txttmp, Me.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
    End Sub
    Private Sub txtGroupCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtGroupCode.Validated
      ToolGroup.GetToolGroup(txtGroupCode, txtGroupName, Me.Group)
    End Sub

    Private Sub btnGroupFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroupFind.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New ToolGroup, AddressOf SetToolGroup)
    End Sub
    Private Sub SetToolGroup(ByVal e As ISimpleEntity)
      Me.txtGroupCode.Text = e.Code
      ToolGroup.GetToolGroup(txtGroupCode, txtGroupName, Me.Group)
    End Sub
    Private Sub btnAssetFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnassetstartfind"
          myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetStartDialog)

        Case "btnassetendfind"
          myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAssetEndDialog)
      End Select
    End Sub
    Private Sub btnAssetTypeFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnassettypestartfind"
          myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeStartDialog)

        Case "btnassettypeendfind"
          myEntityPanelService.OpenTreeDialog(New AssetType, AddressOf SetAssetTypeEndDialog)
      End Select
    End Sub
    Private Sub SetAssetStartDialog(ByVal e As ISimpleEntity)
      Me.txtAssetCodeStart.Text = e.Code
      Asset.GetAsset(txtAssetCodeStart, txttmp, Me.AssetStart)
    End Sub
    Private Sub SetAssetEndDialog(ByVal e As ISimpleEntity)
      Me.txtAssetCodeEnd.Text = e.Code
      Asset.GetAsset(txtAssetCodeEnd, txttmp, Me.AssetEnd)
    End Sub
    Private Sub SetAssetTypeStartDialog(ByVal e As ISimpleEntity)
      Me.txtAssetTypeCodeStart.Text = e.Code
      AssetType.GetAssetType(txtAssetTypeCodeStart, txttmp, Me.AssetTypeStart)
    End Sub
    Private Sub SetAssetTypeEndDialog(ByVal e As ISimpleEntity)
      Me.txtAssetTypeCodeEnd.Text = e.Code
      AssetType.GetAssetType(txtAssetTypeCodeEnd, txttmp, Me.AssetTypeEnd)
    End Sub
   
#End Region

    Private Function settingsPanel() As Object
      Throw New NotImplementedException
    End Function

  End Class
End Namespace

