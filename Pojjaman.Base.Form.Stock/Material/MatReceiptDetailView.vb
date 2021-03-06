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
  Public Class MatReceiptDetailView
    'Inherits UserControl
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "
    'UserControl overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
      If disposing Then
        If Not (components Is Nothing) Then
          'Clear the memory
          Me.m_entity = Nothing
          components.Dispose()
        End If
      End If
      MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtMTDocDate As System.Windows.Forms.TextBox
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbFromCC As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtFromCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents lblFromCCPerson As System.Windows.Forms.Label
    Friend WithEvents lblFromCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtFromCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtFromCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents grbToCC As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtToCCPersonCode As System.Windows.Forms.TextBox
    Friend WithEvents lblToCCPerson As System.Windows.Forms.Label
    Friend WithEvents lbltoCC As System.Windows.Forms.Label
    Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents txtToCCPersonName As System.Windows.Forms.TextBox
    Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents txtAccount As System.Windows.Forms.TextBox
    Friend WithEvents lblAccount As System.Windows.Forms.Label
    Friend WithEvents txtAccountCode As System.Windows.Forms.TextBox
    Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtItemCount As System.Windows.Forms.TextBox
    Friend WithEvents lblItemCount As System.Windows.Forms.Label
    Friend WithEvents lblItemCountUnit As System.Windows.Forms.Label
    Friend WithEvents lblBaht As System.Windows.Forms.Label
    Friend WithEvents txtTotalAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblTotalAmount As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents chkShowCost As System.Windows.Forms.CheckBox
    Friend WithEvents ibtnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDocType As System.Windows.Forms.TextBox
    Friend WithEvents lblReceiptStatus As System.Windows.Forms.Label
    Friend WithEvents txtReceiptStatus As System.Windows.Forms.TextBox
    Friend WithEvents lblMtDocdate As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocType As System.Windows.Forms.Label

    Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MatReceiptDetailView))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtCode = New System.Windows.Forms.TextBox()
      Me.txtMTDocDate = New System.Windows.Forms.TextBox()
      Me.lblDocDate = New System.Windows.Forms.Label()
      Me.txtNote = New System.Windows.Forms.TextBox()
      Me.lblNote = New System.Windows.Forms.Label()
      Me.lblCode = New System.Windows.Forms.Label()
      Me.lblItem = New System.Windows.Forms.Label()
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      Me.ibtnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.grbFromCC = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtFromCostCenterCode = New System.Windows.Forms.TextBox()
      Me.lblFromCCPerson = New System.Windows.Forms.Label()
      Me.lblFromCostCenter = New System.Windows.Forms.Label()
      Me.txtFromCCPersonCode = New System.Windows.Forms.TextBox()
      Me.txtFromCCPersonName = New System.Windows.Forms.TextBox()
      Me.txtFromCostCenterName = New System.Windows.Forms.TextBox()
      Me.grbToCC = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtDocType = New System.Windows.Forms.TextBox()
      Me.lblDocType = New System.Windows.Forms.Label()
      Me.txtToCCPersonCode = New System.Windows.Forms.TextBox()
      Me.lblToCCPerson = New System.Windows.Forms.Label()
      Me.lbltoCC = New System.Windows.Forms.Label()
      Me.txtToCostCenterCode = New System.Windows.Forms.TextBox()
      Me.txtToCCPersonName = New System.Windows.Forms.TextBox()
      Me.txtToCostCenterName = New System.Windows.Forms.TextBox()
      Me.txtAccount = New System.Windows.Forms.TextBox()
      Me.lblAccount = New System.Windows.Forms.Label()
      Me.txtAccountCode = New System.Windows.Forms.TextBox()
      Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.txtItemCount = New System.Windows.Forms.TextBox()
      Me.lblItemCount = New System.Windows.Forms.Label()
      Me.lblItemCountUnit = New System.Windows.Forms.Label()
      Me.lblBaht = New System.Windows.Forms.Label()
      Me.txtTotalAmount = New System.Windows.Forms.TextBox()
      Me.lblTotalAmount = New System.Windows.Forms.Label()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.txtReceiptStatus = New System.Windows.Forms.TextBox()
      Me.chkShowCost = New System.Windows.Forms.CheckBox()
      Me.lblReceiptStatus = New System.Windows.Forms.Label()
      Me.lblMtDocdate = New System.Windows.Forms.Label()
      Me.txtDocDate = New System.Windows.Forms.TextBox()
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbFromCC.SuspendLayout()
      Me.grbToCC.SuspendLayout()
      Me.grbSummary.SuspendLayout()
      Me.SuspendLayout()
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.Khaki
      Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.BackColor = System.Drawing.Color.LemonChiffon
      Me.tgItem.CaptionForeColor = System.Drawing.SystemColors.Window
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.Font = New System.Drawing.Font("Tahoma", 8.25!)
      Me.tgItem.GridLineColor = System.Drawing.Color.FromArgb(CType(CType(210, Byte), Integer), CType(CType(200, Byte), Integer), CType(CType(120, Byte), Integer))
      Me.tgItem.HeaderBackColor = System.Drawing.Color.DarkGoldenrod
      Me.tgItem.HeaderForeColor = System.Drawing.Color.White
      Me.tgItem.Location = New System.Drawing.Point(8, 194)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.ParentRowsBackColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.SelectionBackColor = System.Drawing.Color.Sienna
      Me.tgItem.Size = New System.Drawing.Size(764, 257)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 3
      Me.tgItem.TreeManager = Nothing
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblMtDocdate)
      Me.grbDetail.Controls.Add(Me.txtCode)
      Me.grbDetail.Controls.Add(Me.txtMTDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbDetail.Location = New System.Drawing.Point(8, 1)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(763, 72)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "�����"
      '
      'txtCode
      '
      Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
      Me.txtCode.Location = New System.Drawing.Point(97, 16)
      Me.Validator.SetMinValue(Me.txtCode, "")
      Me.txtCode.Name = "txtCode"
      Me.txtCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCode, "")
      Me.Validator.SetRequired(Me.txtCode, False)
      Me.txtCode.Size = New System.Drawing.Size(194, 21)
      Me.txtCode.TabIndex = 1
      '
      'txtMTDocDate
      '
      Me.Validator.SetDataType(Me.txtMTDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtMTDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtMTDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtMTDocDate, System.Drawing.Color.Empty)
      Me.txtMTDocDate.Location = New System.Drawing.Point(648, 16)
      Me.Validator.SetMinValue(Me.txtMTDocDate, "")
      Me.txtMTDocDate.Name = "txtMTDocDate"
      Me.txtMTDocDate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtMTDocDate, "")
      Me.Validator.SetRequired(Me.txtMTDocDate, True)
      Me.txtMTDocDate.Size = New System.Drawing.Size(100, 21)
      Me.txtMTDocDate.TabIndex = 1
      '
      'lblDocDate
      '
      Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocDate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDocDate.Location = New System.Drawing.Point(297, 16)
      Me.lblDocDate.Name = "lblDocDate"
      Me.lblDocDate.Size = New System.Drawing.Size(96, 18)
      Me.lblDocDate.TabIndex = 6
      Me.lblDocDate.Text = "�ѹ����͡���:"
      Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtNote
      '
      Me.txtNote.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(97, 40)
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Name = "txtNote"
      Me.txtNote.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.Size = New System.Drawing.Size(611, 21)
      Me.txtNote.TabIndex = 2
      '
      'lblNote
      '
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(9, 40)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(88, 18)
      Me.lblNote.TabIndex = 4
      Me.lblNote.Text = "�����˵�:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblCode
      '
      Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblCode.Location = New System.Drawing.Point(9, 16)
      Me.lblCode.Name = "lblCode"
      Me.lblCode.Size = New System.Drawing.Size(87, 18)
      Me.lblCode.TabIndex = 3
      Me.lblCode.Text = "�Ţ����͡���:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItem
      '
      Me.lblItem.AutoSize = True
      Me.lblItem.BackColor = System.Drawing.Color.Transparent
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(9, 173)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(122, 16)
      Me.lblItem.TabIndex = 4
      Me.lblItem.Text = "��¡���Ѻ�͹��ʴ�:"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnApprove
      '
      Me.ibtnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.ibtnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ibtnApprove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnApprove.Location = New System.Drawing.Point(8, 457)
      Me.ibtnApprove.Name = "ibtnApprove"
      Me.ibtnApprove.Size = New System.Drawing.Size(72, 64)
      Me.ibtnApprove.TabIndex = 333
      Me.ibtnApprove.TabStop = False
      Me.ibtnApprove.ThemedImage = CType(resources.GetObject("ibtnApprove.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnApprove, "�׹�ѹ����Ѻ�ͧ ��кѹ�֡��èѴ���")
      '
      'ErrorProvider1
      '
      Me.ErrorProvider1.ContainerControl = Me
      '
      'grbFromCC
      '
      Me.grbFromCC.Controls.Add(Me.txtFromCostCenterCode)
      Me.grbFromCC.Controls.Add(Me.lblFromCCPerson)
      Me.grbFromCC.Controls.Add(Me.lblFromCostCenter)
      Me.grbFromCC.Controls.Add(Me.txtFromCCPersonCode)
      Me.grbFromCC.Controls.Add(Me.txtFromCCPersonName)
      Me.grbFromCC.Controls.Add(Me.txtFromCostCenterName)
      Me.grbFromCC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbFromCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbFromCC.Location = New System.Drawing.Point(8, 73)
      Me.grbFromCC.Name = "grbFromCC"
      Me.grbFromCC.Size = New System.Drawing.Size(368, 93)
      Me.grbFromCC.TabIndex = 1
      Me.grbFromCC.TabStop = False
      Me.grbFromCC.Text = "�������ԡ"
      '
      'txtFromCostCenterCode
      '
      Me.txtFromCostCenterCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtFromCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterCode, System.Drawing.Color.Empty)
      Me.txtFromCostCenterCode.Location = New System.Drawing.Point(97, 16)
      Me.Validator.SetMinValue(Me.txtFromCostCenterCode, "")
      Me.txtFromCostCenterCode.Name = "txtFromCostCenterCode"
      Me.txtFromCostCenterCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterCode, False)
      Me.txtFromCostCenterCode.Size = New System.Drawing.Size(91, 21)
      Me.txtFromCostCenterCode.TabIndex = 0
      '
      'lblFromCCPerson
      '
      Me.lblFromCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCCPerson.Location = New System.Drawing.Point(8, 40)
      Me.lblFromCCPerson.Name = "lblFromCCPerson"
      Me.lblFromCCPerson.Size = New System.Drawing.Size(88, 18)
      Me.lblFromCCPerson.TabIndex = 9
      Me.lblFromCCPerson.Text = "������:"
      Me.lblFromCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblFromCostCenter
      '
      Me.lblFromCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblFromCostCenter.Location = New System.Drawing.Point(8, 16)
      Me.lblFromCostCenter.Name = "lblFromCostCenter"
      Me.lblFromCostCenter.Size = New System.Drawing.Size(88, 18)
      Me.lblFromCostCenter.TabIndex = 8
      Me.lblFromCostCenter.Text = "�ҡ Cost Center:"
      Me.lblFromCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtFromCCPersonCode
      '
      Me.txtFromCCPersonCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtFromCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonCode, System.Drawing.Color.Empty)
      Me.txtFromCCPersonCode.Location = New System.Drawing.Point(97, 40)
      Me.Validator.SetMinValue(Me.txtFromCCPersonCode, "")
      Me.txtFromCCPersonCode.Name = "txtFromCCPersonCode"
      Me.txtFromCCPersonCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonCode, False)
      Me.txtFromCCPersonCode.Size = New System.Drawing.Size(91, 21)
      Me.txtFromCCPersonCode.TabIndex = 1
      '
      'txtFromCCPersonName
      '
      Me.Validator.SetDataType(Me.txtFromCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCCPersonName, System.Drawing.Color.Empty)
      Me.txtFromCCPersonName.Location = New System.Drawing.Point(190, 40)
      Me.Validator.SetMinValue(Me.txtFromCCPersonName, "")
      Me.txtFromCCPersonName.Name = "txtFromCCPersonName"
      Me.txtFromCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCCPersonName, "")
      Me.Validator.SetRequired(Me.txtFromCCPersonName, False)
      Me.txtFromCCPersonName.Size = New System.Drawing.Size(172, 21)
      Me.txtFromCCPersonName.TabIndex = 3
      Me.txtFromCCPersonName.TabStop = False
      '
      'txtFromCostCenterName
      '
      Me.Validator.SetDataType(Me.txtFromCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtFromCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtFromCostCenterName, System.Drawing.Color.Empty)
      Me.txtFromCostCenterName.Location = New System.Drawing.Point(190, 16)
      Me.Validator.SetMinValue(Me.txtFromCostCenterName, "")
      Me.txtFromCostCenterName.Name = "txtFromCostCenterName"
      Me.txtFromCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtFromCostCenterName, "")
      Me.Validator.SetRequired(Me.txtFromCostCenterName, False)
      Me.txtFromCostCenterName.Size = New System.Drawing.Size(172, 21)
      Me.txtFromCostCenterName.TabIndex = 2
      Me.txtFromCostCenterName.TabStop = False
      '
      'grbToCC
      '
      Me.grbToCC.Controls.Add(Me.txtDocType)
      Me.grbToCC.Controls.Add(Me.lblDocType)
      Me.grbToCC.Controls.Add(Me.txtToCCPersonCode)
      Me.grbToCC.Controls.Add(Me.lblToCCPerson)
      Me.grbToCC.Controls.Add(Me.lbltoCC)
      Me.grbToCC.Controls.Add(Me.txtToCostCenterCode)
      Me.grbToCC.Controls.Add(Me.txtToCCPersonName)
      Me.grbToCC.Controls.Add(Me.txtToCostCenterName)
      Me.grbToCC.Controls.Add(Me.txtAccount)
      Me.grbToCC.Controls.Add(Me.lblAccount)
      Me.grbToCC.Controls.Add(Me.txtAccountCode)
      Me.grbToCC.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbToCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbToCC.Location = New System.Drawing.Point(382, 73)
      Me.grbToCC.Name = "grbToCC"
      Me.grbToCC.Size = New System.Drawing.Size(389, 115)
      Me.grbToCC.TabIndex = 2
      Me.grbToCC.TabStop = False
      Me.grbToCC.Text = "�����ԡ"
      '
      'txtDocType
      '
      Me.Validator.SetDataType(Me.txtDocType, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDocType, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocType, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocType, System.Drawing.Color.Empty)
      Me.txtDocType.Location = New System.Drawing.Point(121, 65)
      Me.Validator.SetMinValue(Me.txtDocType, "")
      Me.txtDocType.Name = "txtDocType"
      Me.txtDocType.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDocType, "")
      Me.Validator.SetRequired(Me.txtDocType, False)
      Me.txtDocType.Size = New System.Drawing.Size(261, 21)
      Me.txtDocType.TabIndex = 1
      '
      'lblDocType
      '
      Me.lblDocType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDocType.Location = New System.Drawing.Point(8, 65)
      Me.lblDocType.Name = "lblDocType"
      Me.lblDocType.Size = New System.Drawing.Size(112, 18)
      Me.lblDocType.TabIndex = 14
      Me.lblDocType.Text = "�ش���ʧ�����ԡ:"
      Me.lblDocType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToCCPersonCode
      '
      Me.txtToCCPersonCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtToCCPersonCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonCode, System.Drawing.Color.Empty)
      Me.txtToCCPersonCode.Location = New System.Drawing.Point(122, 40)
      Me.Validator.SetMinValue(Me.txtToCCPersonCode, "")
      Me.txtToCCPersonCode.Name = "txtToCCPersonCode"
      Me.txtToCCPersonCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCCPersonCode, "")
      Me.Validator.SetRequired(Me.txtToCCPersonCode, False)
      Me.txtToCCPersonCode.Size = New System.Drawing.Size(90, 21)
      Me.txtToCCPersonCode.TabIndex = 1
      '
      'lblToCCPerson
      '
      Me.lblToCCPerson.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToCCPerson.Location = New System.Drawing.Point(8, 40)
      Me.lblToCCPerson.Name = "lblToCCPerson"
      Me.lblToCCPerson.Size = New System.Drawing.Size(112, 18)
      Me.lblToCCPerson.TabIndex = 5
      Me.lblToCCPerson.Text = "����ԡ:"
      Me.lblToCCPerson.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lbltoCC
      '
      Me.lbltoCC.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lbltoCC.Location = New System.Drawing.Point(8, 16)
      Me.lbltoCC.Name = "lbltoCC"
      Me.lbltoCC.Size = New System.Drawing.Size(112, 18)
      Me.lbltoCC.TabIndex = 4
      Me.lbltoCC.Text = "�ԡ��� Cost Center:"
      Me.lbltoCC.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToCostCenterCode
      '
      Me.txtToCostCenterCode.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
      Me.txtToCostCenterCode.Location = New System.Drawing.Point(121, 16)
      Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
      Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
      Me.txtToCostCenterCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtToCostCenterCode, False)
      Me.txtToCostCenterCode.Size = New System.Drawing.Size(91, 21)
      Me.txtToCostCenterCode.TabIndex = 0
      Me.txtToCostCenterCode.TabStop = False
      '
      'txtToCCPersonName
      '
      Me.Validator.SetDataType(Me.txtToCCPersonName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCCPersonName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCCPersonName, System.Drawing.Color.Empty)
      Me.txtToCCPersonName.Location = New System.Drawing.Point(214, 40)
      Me.Validator.SetMinValue(Me.txtToCCPersonName, "")
      Me.txtToCCPersonName.Name = "txtToCCPersonName"
      Me.txtToCCPersonName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCCPersonName, "")
      Me.Validator.SetRequired(Me.txtToCCPersonName, False)
      Me.txtToCCPersonName.Size = New System.Drawing.Size(168, 21)
      Me.txtToCCPersonName.TabIndex = 11
      Me.txtToCCPersonName.TabStop = False
      '
      'txtToCostCenterName
      '
      Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
      Me.txtToCostCenterName.Location = New System.Drawing.Point(214, 16)
      Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
      Me.txtToCostCenterName.Name = "txtToCostCenterName"
      Me.txtToCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
      Me.Validator.SetRequired(Me.txtToCostCenterName, False)
      Me.txtToCostCenterName.Size = New System.Drawing.Size(169, 21)
      Me.txtToCostCenterName.TabIndex = 12
      Me.txtToCostCenterName.TabStop = False
      '
      'txtAccount
      '
      Me.Validator.SetDataType(Me.txtAccount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccount, "")
      Me.txtAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccount, System.Drawing.Color.Empty)
      Me.txtAccount.Location = New System.Drawing.Point(214, 90)
      Me.Validator.SetMinValue(Me.txtAccount, "")
      Me.txtAccount.Name = "txtAccount"
      Me.txtAccount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccount, "")
      Me.Validator.SetRequired(Me.txtAccount, False)
      Me.txtAccount.Size = New System.Drawing.Size(168, 21)
      Me.txtAccount.TabIndex = 10
      Me.txtAccount.TabStop = False
      '
      'lblAccount
      '
      Me.lblAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAccount.ForeColor = System.Drawing.Color.Black
      Me.lblAccount.Location = New System.Drawing.Point(8, 90)
      Me.lblAccount.Name = "lblAccount"
      Me.lblAccount.Size = New System.Drawing.Size(112, 18)
      Me.lblAccount.TabIndex = 7
      Me.lblAccount.Text = "�ѧ�ѭ��:"
      Me.lblAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtAccountCode
      '
      Me.Validator.SetDataType(Me.txtAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAccountCode, "")
      Me.txtAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAccountCode, System.Drawing.Color.Empty)
      Me.txtAccountCode.Location = New System.Drawing.Point(122, 90)
      Me.Validator.SetMinValue(Me.txtAccountCode, "")
      Me.txtAccountCode.Name = "txtAccountCode"
      Me.txtAccountCode.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAccountCode, "")
      Me.Validator.SetRequired(Me.txtAccountCode, False)
      Me.txtAccountCode.Size = New System.Drawing.Size(90, 21)
      Me.txtAccountCode.TabIndex = 9
      Me.txtAccountCode.TabStop = False
      '
      'grbSummary
      '
      Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbSummary.Controls.Add(Me.txtItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCount)
      Me.grbSummary.Controls.Add(Me.lblItemCountUnit)
      Me.grbSummary.Controls.Add(Me.lblBaht)
      Me.grbSummary.Controls.Add(Me.txtTotalAmount)
      Me.grbSummary.Controls.Add(Me.lblTotalAmount)
      Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbSummary.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.grbSummary.Location = New System.Drawing.Point(412, 451)
      Me.grbSummary.Name = "grbSummary"
      Me.grbSummary.Size = New System.Drawing.Size(360, 70)
      Me.grbSummary.TabIndex = 9
      Me.grbSummary.TabStop = False
      Me.grbSummary.Text = "��ػ�ʹ�ԡ��ʴ�"
      '
      'txtItemCount
      '
      Me.txtItemCount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtItemCount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtItemCount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtItemCount, System.Drawing.Color.Empty)
      Me.txtItemCount.Location = New System.Drawing.Point(184, 16)
      Me.Validator.SetMinValue(Me.txtItemCount, "")
      Me.txtItemCount.Name = "txtItemCount"
      Me.txtItemCount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtItemCount, "")
      Me.Validator.SetRequired(Me.txtItemCount, False)
      Me.txtItemCount.Size = New System.Drawing.Size(112, 21)
      Me.txtItemCount.TabIndex = 1
      Me.txtItemCount.TabStop = False
      Me.txtItemCount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblItemCount
      '
      Me.lblItemCount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCount.Location = New System.Drawing.Point(8, 16)
      Me.lblItemCount.Name = "lblItemCount"
      Me.lblItemCount.Size = New System.Drawing.Size(168, 18)
      Me.lblItemCount.TabIndex = 0
      Me.lblItemCount.Text = "�ӹǹ��¡���Թ���"
      Me.lblItemCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblItemCountUnit
      '
      Me.lblItemCountUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItemCountUnit.Location = New System.Drawing.Point(304, 16)
      Me.lblItemCountUnit.Name = "lblItemCountUnit"
      Me.lblItemCountUnit.Size = New System.Drawing.Size(40, 18)
      Me.lblItemCountUnit.TabIndex = 2
      Me.lblItemCountUnit.Text = "��¡��"
      Me.lblItemCountUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblBaht
      '
      Me.lblBaht.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBaht.Location = New System.Drawing.Point(304, 40)
      Me.lblBaht.Name = "lblBaht"
      Me.lblBaht.Size = New System.Drawing.Size(40, 18)
      Me.lblBaht.TabIndex = 5
      Me.lblBaht.Text = "�ҷ"
      Me.lblBaht.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'txtTotalAmount
      '
      Me.txtTotalAmount.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
      Me.Validator.SetDataType(Me.txtTotalAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTotalAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTotalAmount, System.Drawing.Color.Empty)
      Me.txtTotalAmount.Location = New System.Drawing.Point(184, 40)
      Me.Validator.SetMinValue(Me.txtTotalAmount, "")
      Me.txtTotalAmount.Name = "txtTotalAmount"
      Me.txtTotalAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTotalAmount, "")
      Me.Validator.SetRequired(Me.txtTotalAmount, False)
      Me.txtTotalAmount.Size = New System.Drawing.Size(112, 21)
      Me.txtTotalAmount.TabIndex = 4
      Me.txtTotalAmount.TabStop = False
      Me.txtTotalAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTotalAmount
      '
      Me.lblTotalAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTotalAmount.Location = New System.Drawing.Point(8, 40)
      Me.lblTotalAmount.Name = "lblTotalAmount"
      Me.lblTotalAmount.Size = New System.Drawing.Size(168, 18)
      Me.lblTotalAmount.TabIndex = 3
      Me.lblTotalAmount.Text = "��Ť���Թ��ҷ���ԡ"
      Me.lblTotalAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      'txtReceiptStatus
      '
      Me.txtReceiptStatus.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtReceiptStatus.BackColor = System.Drawing.SystemColors.Window
      Me.Validator.SetDataType(Me.txtReceiptStatus, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtReceiptStatus, "")
      Me.Validator.SetGotFocusBackColor(Me.txtReceiptStatus, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtReceiptStatus, System.Drawing.Color.Empty)
      Me.txtReceiptStatus.Location = New System.Drawing.Point(105, 477)
      Me.Validator.SetMinValue(Me.txtReceiptStatus, "")
      Me.txtReceiptStatus.Multiline = True
      Me.txtReceiptStatus.Name = "txtReceiptStatus"
      Me.txtReceiptStatus.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtReceiptStatus, "")
      Me.Validator.SetRequired(Me.txtReceiptStatus, False)
      Me.txtReceiptStatus.Size = New System.Drawing.Size(282, 44)
      Me.txtReceiptStatus.TabIndex = 334
      '
      'chkShowCost
      '
      Me.chkShowCost.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowCost.Location = New System.Drawing.Point(142, 170)
      Me.chkShowCost.Name = "chkShowCost"
      Me.chkShowCost.Size = New System.Drawing.Size(104, 24)
      Me.chkShowCost.TabIndex = 5
      Me.chkShowCost.Text = "chkShowCost"
      '
      'lblReceiptStatus
      '
      Me.lblReceiptStatus.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblReceiptStatus.AutoSize = True
      Me.lblReceiptStatus.ForeColor = System.Drawing.SystemColors.ControlText
      Me.lblReceiptStatus.Location = New System.Drawing.Point(108, 459)
      Me.lblReceiptStatus.Name = "lblReceiptStatus"
      Me.lblReceiptStatus.Size = New System.Drawing.Size(111, 13)
      Me.lblReceiptStatus.TabIndex = 335
      Me.lblReceiptStatus.Text = "ʶҹС���׹�ѹ�Ѻ�ͧ"
      Me.lblReceiptStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblMtDocdate
      '
      Me.lblMtDocdate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblMtDocdate.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblMtDocdate.Location = New System.Drawing.Point(546, 16)
      Me.lblMtDocdate.Name = "lblMtDocdate"
      Me.lblMtDocdate.Size = New System.Drawing.Size(96, 18)
      Me.lblMtDocdate.TabIndex = 7
      Me.lblMtDocdate.Text = "�ѹ����͡����͹:"
      Me.lblMtDocdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDocDate
      '
      Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtDocDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
      Me.txtDocDate.Location = New System.Drawing.Point(394, 13)
      Me.Validator.SetMinValue(Me.txtDocDate, "")
      Me.txtDocDate.Name = "txtDocDate"
      Me.Validator.SetRegularExpression(Me.txtDocDate, "")
      Me.Validator.SetRequired(Me.txtDocDate, True)
      Me.txtDocDate.Size = New System.Drawing.Size(90, 21)
      Me.txtDocDate.TabIndex = 8
      '
      'dtpDocDate
      '
      Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
      Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
      Me.dtpDocDate.Location = New System.Drawing.Point(394, 13)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(120, 21)
      Me.dtpDocDate.TabIndex = 9
      Me.dtpDocDate.TabStop = False
      '
      'MatReceiptDetailView
      '
      Me.Controls.Add(Me.lblReceiptStatus)
      Me.Controls.Add(Me.txtReceiptStatus)
      Me.Controls.Add(Me.ibtnApprove)
      Me.Controls.Add(Me.chkShowCost)
      Me.Controls.Add(Me.grbFromCC)
      Me.Controls.Add(Me.grbToCC)
      Me.Controls.Add(Me.grbSummary)
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.grbDetail)
      Me.Controls.Add(Me.lblItem)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
      Me.Name = "MatReceiptDetailView"
      Me.Size = New System.Drawing.Size(780, 528)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
      Me.grbDetail.PerformLayout()
      CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbFromCC.ResumeLayout(False)
      Me.grbFromCC.PerformLayout()
      Me.grbToCC.ResumeLayout(False)
      Me.grbToCC.PerformLayout()
      Me.grbSummary.ResumeLayout(False)
      Me.grbSummary.PerformLayout()
      Me.ResumeLayout(False)
      Me.PerformLayout()

    End Sub
#End Region

#Region "Members"
    Private m_entity As MatReceipt
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private m_tableStyleEnable As Hashtable

    Private m_enableState As Hashtable

    Private m_treeManager2 As TreeManager
    Private m_wbsdInitialized As Boolean
    Private m_combocodeindex As Integer
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      SaveEnableState()
      m_tableStyleEnable = New Hashtable

      Dim dt As TreeTable = MatReceipt.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf MWItemDelete

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbFromCC.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbSummary.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.grbToCC.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
    Private Sub CheckRoleToChangDocumnentDate()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(387)       '��Ǩ�ͺ �Է��㹡������¹�ѹ����͡���
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)      '����¹����Ţ�� ���� 01 5��� �����ҵ���Ţ
      checkString = BinaryHelper.RevertString(checkString)
      If CBool(checkString.Substring(0, 1)) Then
        Me.txtDocDate.ReadOnly = False
        Me.dtpDocDate.Enabled = True
      Else
        Me.txtDocDate.Text = Now.ToShortDateString
        'Me.dtpDocDate.Value = Now
        Me.txtDocDate.ReadOnly = True
        Me.dtpDocDate.Enabled = False
      End If
    End Sub
#End Region

#Region "Style"
    Dim m_wbsColl As WBSCollection
    Dim m_mrkColl As MarkupCollection
    Private ReadOnly Property CurrentWsbsd() As WBSDistribute
      Get
        Dim row As TreeRow = Me.m_treeManager2.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        Return CType(row.Tag, WBSDistribute)
      End Get
    End Property
    Public Function CreateTableStyle() As DataGridTableStyle
      Return CreateTableStyle(True)
    End Function
    Public Function CreateTableStyle(ByVal group As Boolean) As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "MatReceipt"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csPRItemCode As New TreeTextColumn
      csPRItemCode.MappingName = "PRItemCode"
      csPRItemCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemCodeHeaderText}")
      csPRItemCode.NullText = ""
      csPRItemCode.ReadOnly = True
      csPRItemCode.TextBox.Name = "PRItemCode"

      Dim csPRItemName As New TreeTextColumn
      csPRItemName.MappingName = "PRItemName"
      csPRItemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemNameHeaderText}")
      csPRItemName.NullText = ""
      csPRItemName.ReadOnly = True
      csPRItemName.TextBox.Name = "PRItemName"

      Dim csPRItemUnit As New TreeTextColumn
      csPRItemUnit.MappingName = "PRItemUnit"
      csPRItemUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemUnitHeaderText}")
      csPRItemUnit.NullText = ""
      csPRItemUnit.ReadOnly = True
      csPRItemUnit.Width = 50
      csPRItemUnit.TextBox.Name = "PRItemUnit"

      Dim csPRItemQty As New TreeTextColumn
      csPRItemQty.MappingName = "pri_qty"
      csPRItemQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemQtyHeaderText}")
      csPRItemQty.NullText = ""
      csPRItemQty.ReadOnly = True
      csPRItemQty.TextBox.Name = "pri_qty"

      Dim csPRItemRemainingQty As New TreeTextColumn
      csPRItemRemainingQty.MappingName = "PRItemRemainingQty"
      csPRItemRemainingQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.PRItemRemainingQtyHeaderText}")
      csPRItemRemainingQty.NullText = ""
      csPRItemRemainingQty.DataAlignment = HorizontalAlignment.Right
      csPRItemRemainingQty.Format = "#,###.##"
      csPRItemRemainingQty.TextBox.Name = "PRItemRemainingQty"

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "stocki_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "stocki_linenumber"

      Dim csBarrier As New DataGridBarrierColumn
      csBarrier.MappingName = "Barrier"
      csBarrier.HeaderText = ""
      csBarrier.NullText = ""
      csBarrier.ReadOnly = True

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 70
      csCode.ReadOnly = Not group
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""


      Dim csstocki_itemName As New TreeTextColumn
      csstocki_itemName.MappingName = "stocki_itemName"
      csstocki_itemName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.DescriptionHeaderText}")
      csstocki_itemName.NullText = ""
      csstocki_itemName.Width = 180
      csstocki_itemName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      csstocki_itemName.ReadOnly = True

      Dim csDefaultUnit As New TreeTextColumn
      csDefaultUnit.MappingName = "DefaultUnit"
      csDefaultUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.DefaultUnitHeaderText}")
      csDefaultUnit.NullText = ""
      csDefaultUnit.ReadOnly = True
      If group Then
        csDefaultUnit.Width = 0
      Else
        csDefaultUnit.Width = 90
      End If

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      csUnit.Width = 50
      csUnit.ReadOnly = Not group

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClicked

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "stocki_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      csQty.Width = 60
      csQty.ReadOnly = Not group

      Dim csStockQty As New TreeTextColumn
      csStockQty.MappingName = "StockQty"
      csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.StockQtyHeaderText}")
      csStockQty.NullText = ""
      csStockQty.DataAlignment = HorizontalAlignment.Right
      csStockQty.Format = "#,###.##"
      csStockQty.ReadOnly = True
      If group Then
        csStockQty.Width = 0
      Else
        csStockQty.Width = 90
      End If

      Dim csTransferUnitPrice As New TreeTextColumn
      csTransferUnitPrice.MappingName = "stocki_transferunitprice"
      csTransferUnitPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.TransferUnitPriceHeaderText}")
      csTransferUnitPrice.NullText = ""
      csTransferUnitPrice.DataAlignment = HorizontalAlignment.Right
      csTransferUnitPrice.Format = "#,###.##"
      csTransferUnitPrice.ReadOnly = Not group
      'Dim config As Object = Configuration.GetConfig("DisableTransferUnitCost")
      'If config Then
      csTransferUnitPrice.Width = 0
      'End If

      Dim csTransferAmount As New TreeTextColumn
      csTransferAmount.MappingName = "stocki_transferamt"
      csTransferAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.TransferAmountHeaderText}")
      csTransferAmount.NullText = ""
      csTransferAmount.DataAlignment = HorizontalAlignment.Right
      csTransferAmount.Format = "#,###.##"
      csTransferAmount.Width = 60
      csTransferAmount.ReadOnly = True

      Dim csUnitCost As New TreeTextColumn
      csUnitCost.MappingName = "stocki_unitcost"
      csUnitCost.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.UnitCostHeaderText}")
      csUnitCost.NullText = ""
      csUnitCost.TextBox.Name = "stocki_unitcost"
      csUnitCost.DataAlignment = HorizontalAlignment.Right
      csUnitCost.ReadOnly = True
      If group Then
        csUnitCost.Width = 0
      Else
        csUnitCost.Width = 90
      End If

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "stocki_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 150
      csNote.TextBox.Name = "stocki_note"
      csNote.ReadOnly = Not group

      dst.GridColumnStyles.Add(csPRItemCode)
      dst.GridColumnStyles.Add(csPRItemName)
      dst.GridColumnStyles.Add(csPRItemUnit)
      'dst.GridColumnStyles.Add(csPRItemQty)
      'dst.GridColumnStyles.Add(csPRItemRemainingQty)

      'dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csBarrier)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csstocki_itemName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csDefaultUnit)
      dst.GridColumnStyles.Add(csStockQty)
      dst.GridColumnStyles.Add(csUnitCost)
      dst.GridColumnStyles.Add(csTransferUnitPrice)
      dst.GridColumnStyles.Add(csTransferAmount)
      dst.GridColumnStyles.Add(csNote)

      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next

      Return dst
    End Function
    Private Sub ToggleStyle(ByVal dst As DataGridTableStyle)
      For Each col As DataGridColumnStyle In dst.GridColumnStyles
        Select Case col.MappingName.ToLower
          Case "code", "unit", "stocki_qty", "stocki_note"
            If Me.m_entity.Grouping Then
              col.ReadOnly = CBool(Me.m_tableStyleEnable(col))
            Else
              col.ReadOnly = True
            End If
          Case "stocki_unitcost", "defaultunit", "stockqty"
            If Me.m_entity.Grouping Then
              col.Width = 0
            Else
              col.Width = 90
            End If
        End Select
      Next
    End Sub
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 8 Then
        Me.UnitClicked(e)
      ElseIf e.Column = 5 Then
        Me.LCIClicked(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentItem() As MatReceiptItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is MatReceiptItem Then
          Return Nothing
        End If
        Return CType(row.Tag, MatReceiptItem)
      End Get
    End Property

    'Private Property ComboCodeIndex() As Integer
    '  Get
    '    If m_combocodeindex = -1 Then
    '      If cmbCode.Items.Count > 0 Then
    '        m_combocodeindex = 0
    '      End If
    '    End If
    '    Return m_combocodeindex
    '  End Get
    '  Set(ByVal Value As Integer)
    '    m_combocodeindex = Value
    '  End Set
    'End Property
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Private Sub ItemTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
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
      Dim doc As MatReceiptItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New MatReceiptItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue), Me.m_entity.FromCC.Id)
          Case "unit"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            doc.Unit = myUnit
          Case "stocki_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            If IsNumeric(e.ProposedValue.ToString) Then
              Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              Dim remaining As Decimal = 0

              If Not (doc.Pritem Is Nothing) Then
                remaining = doc.AllowWithdrawFromPR
              Else
                remaining = doc.GetAmountFromSproc(doc.Entity.Id, Me.m_entity.FromCC.Id)
              End If

              Dim config As Boolean = CBool(Configuration.GetConfig("AllowOverWithdrawStock"))

              Dim xCompare As String = Configuration.FormatToString(value, DigitConfig.Price)
              Dim yCompare As String = Configuration.FormatToString((remaining / doc.Conversion), DigitConfig.Price)
              'MessageBox.Show(doc.OldRemainingQty.ToString & vbCrLf & doc.Conversion.ToString)
              If value > (remaining / doc.Conversion) Then
                If Not config Then
                  Dim str As String = My.Resources.MatWithdrawDetailView_WidrawOverStock
                  str = String.Format(str, xCompare, yCompare)
                  msgServ.ShowWarning(str)
                  e.ProposedValue = (remaining / doc.Conversion)
                  doc.Qty = e.ProposedValue
                  Return
                Else
                  If Not msgServ.AskQuestionFormatted("", "${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.InvalidQty}", New String() {xCompare, yCompare}) Then
                    e.ProposedValue = (remaining / doc.Conversion)
                    doc.Qty = e.ProposedValue
                    Return
                  End If
                End If
              End If
                'If (value * doc.Conversion) > (doc.OldQty Or doc.OldQty2) Then
                '  If doc.OldQty > 0 Then
                '    '෨ҡ�С���
                '    msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Error.MatReturnDetailView.Remain}", New String() {(doc.OldQty / doc.Conversion).ToString})
                '  Else
                '    '�������ͧ���� enter
                '    msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.Error.MatReturnDetailView.Remain}", New String() {(doc.OldQty2 / doc.Conversion).ToString})
                '  End If
                '  Return
                'End If

                'If Not (doc.Pritem Is Nothing) Then
                'If value > (((doc.Pritem.Qty - doc.Pritem.WithdrawnQty) * doc.Pritem.Conversion) / doc.Conversion) Then
                'doc.Qty = ((doc.Pritem.Qty - doc.Pritem.WithdrawnQty) * doc.Pritem.Conversion) / doc.Conversion
                'Else
                'doc.Qty = value
                'End If
                'Else
                doc.Qty = value
                'End If
              End If
          Case "stocki_transferunitprice"
            'If IsDBNull(e.ProposedValue) Then
            '  e.ProposedValue = ""
            'End If
            'If IsNumeric(e.ProposedValue.ToString) Then
            '  Dim value As Decimal = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            '  doc.TransferUnitPrice = value
            'End If
          Case "stocki_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub MWItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      ''CheckApproveStore()
     
      '  For Each ctrl As Control In Me.grbDetail.Controls
      '    ctrl.Enabled = False
      '  Next
      '  For Each ctrl As Control In Me.grbFromCC.Controls
      '    ctrl.Enabled = False
      '  Next
      '  For Each ctrl As Control In Me.grbSummary.Controls
      '    ctrl.Enabled = False
      '  Next
      '  For Each ctrl As Control In Me.grbToCC.Controls
      '    ctrl.Enabled = False
      '  Next
      '  For Each ctrl As Control In Me.Controls
      '    ctrl.Enabled = False
      '  Next
      '  tgItem.Enabled = True
      '  For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '    colStyle.ReadOnly = True
      '  Next
      'Else
      For Each ctrl As Control In Me.grbDetail.Controls
        If TypeOf ctrl Is TextBox Then
          CType(ctrl, TextBox).ReadOnly = True
        Else
          ctrl.Enabled = False
        End If
      Next

      txtDocDate.Enabled = True
      txtDocDate.ReadOnly = False
      dtpDocDate.Enabled = True
      If Me.m_entity.Canceled _
     OrElse Me.m_entity.Status.Value = 0 _
     OrElse m_entityRefed = 1 _
     Then
        txtDocDate.Enabled = False
        txtDocDate.ReadOnly = True
        dtpDocDate.Enabled = False
      End If
      '  For Each ctrl As Control In Me.grbFromCC.Controls
      '    ctrl.Enabled = CBool(m_enableState(ctrl))
      '  Next
      '  For Each ctrl As Control In Me.grbSummary.Controls
      '    ctrl.Enabled = CBool(m_enableState(ctrl))
      '  Next
      '  For Each ctrl As Control In Me.grbToCC.Controls
      '    ctrl.Enabled = CBool(m_enableState(ctrl))
      '  Next
      '  For Each ctrl As Control In Me.Controls
      '    ctrl.Enabled = CBool(m_enableState(ctrl))
      '  Next
      '  For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
      '    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
      '  Next

      '  If CBool(Configuration.GetConfig("PRNeedStoreApprove")) Then
      '    Me.btnApprove.Visible = True
      '  End If
      'End If
      tgItem.Enabled = True
      For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
        colStyle.ReadOnly = True
      Next

      ibtnApprove.Enabled = True
      'chkShowCost.Enabled = True
      If Me.m_entity.ApprovalCollection.Count > 0 Then
        Me.chkShowCost.Enabled = True
      Else
        Me.chkShowCost.Enabled = False
      End If

      'ToggleStyle(Me.m_treeManager.GridTableStyle)
      'Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
      CheckWBSRight()
      CheckRoleToChangDocumnentDate()
    End Sub
    Private Sub CheckWBSRight()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(256)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
    End Sub
    Public Overrides Sub ClearDetail()
      For Each grb As Control In Me.Controls
        If TypeOf grb Is FixedGroupBox Then
          For Each crlt As Control In grb.Controls
            If TypeOf crlt Is TextBox Then
              crlt.Text = ""
            End If
          Next
        ElseIf TypeOf grb Is TextBox Then
          grb.Text = ""
        End If
      Next
      'Me.dtpDocDate.Value = Now

    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.grbDetail}")
      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      'Me.Validator.SetDisplayName(Me.txtDocDate, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblNote}")

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblCode}")
      'Me.Validator.SetDisplayName(Me.cmbCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblItem}")
      Me.grbFromCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.grbFromCC}")

      Me.lblFromCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblFromCCPerson}")
      'Me.Validator.SetDisplayName(Me.txtFromCCPersonCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblFromCCPerson.Text, ":"))

      Me.lblFromCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblFromCostCenter}")
      'Me.Validator.SetDisplayName(Me.txtFromCostCenterCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblFromCostCenter.Text, ":"))

      Me.grbToCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.grbToCC}")
      Me.lblToCCPerson.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblToCCPerson}")
      'Me.Validator.SetDisplayName(Me.txtToCCPersonCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lblToCCPerson.Text, ":"))

      Me.lbltoCC.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lbltoCC}")
      'Me.Validator.SetDisplayName(Me.txtToCostCenterCode, TextHelper.StringHelper.GetRidOfAtEnd(Me.lbltoCC.Text, ":"))

      Me.lblAccount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblAccount}")
      Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.grbSummary}")
      Me.lblItemCount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblItemCount}")
      Me.lblItemCountUnit.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblItemCountUnit}")
      Me.lblBaht.Text = Me.StringParserService.Parse("${res:Global.BahtText}")
      Me.lblTotalAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.lblTotalAmount}")
      Me.chkShowCost.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.chkShowCost}")

    End Sub
    Protected Overrides Sub EventWiring()
      'AddHandler txtCode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      'AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty
      'AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      'AddHandler txtToCostCenterCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtToCCPersonCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtFromCostCenterCode.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtFromCCPersonCode.Validated, AddressOf Me.ChangeProperty

      'AddHandler txtToCostCenterCode.TextChanged, AddressOf Me.TextHandler
      'AddHandler txtToCCPersonCode.TextChanged, AddressOf Me.TextHandler
      'AddHandler txtFromCostCenterCode.TextChanged, AddressOf Me.TextHandler
      'AddHandler txtFromCCPersonCode.TextChanged, AddressOf Me.TextHandler

    End Sub

    Private toCCCodeChanged As Boolean = False
    Private toCCPersonCodeChanged As Boolean = False
    Private fromCCCodeChanged As Boolean = False
    Private fromCCPersonCodeChanged As Boolean = False
    Private toAssetCodeChanged As Boolean = False

    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txttoccpersoncode"
          toCCPersonCodeChanged = True
        Case "txttocostcentercode"
          toCCCodeChanged = True
        Case "txtfromccpersoncode"
          fromCCPersonCodeChanged = True
        Case "txtfromcostcentercode"
          fromCCCodeChanged = True
        Case "txtequipmentcode"
          toAssetCodeChanged = True
      End Select
    End Sub
    ' �ʴ���Ң����Ţͧ�١���ŧ� control ������躹�����
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      oldCCId = Me.m_entity.ToCostCenter.Id
      ' txtCode.Text = m_entity.Code

      'cmbCode.Items.Clear()
      'cmbCode.DropDownStyle = ComboBoxStyle.Simple
      'cmbCode.Text = m_entity.Code

      txtCode.Text = m_entity.Code
      'BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
      m_oldCode = m_entity.Code
      'UpdateAutogen ��᷹����
      Me.UpdateAutogenStatus()

      txtNote.Text = Me.m_entity.Note

      txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
      txtToCostCenterName.Text = m_entity.ToCostCenter.Name
      txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
      txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name

      txtFromCostCenterCode.Text = m_entity.FromCostCenter.Code
      txtFromCostCenterName.Text = m_entity.FromCostCenter.Name
      txtFromCCPersonCode.Text = m_entity.FromCostCenterPerson.Code
      txtFromCCPersonName.Text = m_entity.FromCostCenterPerson.Name
      'Me.chkShowCost.Checked = Me.m_entity.Grouping
      UpdateAccount()

      'dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
      txtMTDocDate.Text = MinDateToNull(Me.m_entity.MatTransferDocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      'CodeDescription.ComboSelect(Me.cmbDocType, Me.m_entity.Type)
      txtDocType.Text = Me.m_entity.Type.Description

      Me.chkShowCost.Checked = Not Me.m_entity.Grouping

      If Not Me.m_entity.ApprovalCollection Is Nothing Then
        If Me.m_entity.ApprovalCollection.Count > 0 Then
          Dim approvalComment As ApprovalStoreComment = Me.m_entity.ApprovalCollection(Me.m_entity.ApprovalCollection.Count - 1)
          Dim newUser As New User(approvalComment.Originator)
          Dim approveText As String = ""
          If approvalComment.Type = ApproveType.approved Then
            approveText = Me.StringParserService.Parse("${res:Global.Receipt}")
            If m_dateSetting2 Then
              m_entity.DocDate = approvalComment.LastEditDate
            End If
          ElseIf approvalComment.Type = ApproveType.reject Then
            approveText = Me.StringParserService.Parse("${res:Global.Reject}")
          End If
          txtReceiptStatus.Text = approveText & " : " & approvalComment.Comment & vbCrLf & _
                                  "(" & approvalComment.LastEditDate.ToShortDateString & " : " & newUser.Name & ")"
        Else
          txtReceiptStatus.Text = Me.StringParserService.Parse("${res:Global.NotConfirm}")
        End If
      End If

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))

      RefreshDocs()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    'Private Sub RefreshApprove()
    '  If Not Me.m_entity.ApprovalCollection Is Nothing Then
    '    If Me.m_entity.ApprovalCollection.Count > 0 Then
    '      Dim approvalComment As ApprovalStoreComment = Me.m_entity.ApprovalCollection(Me.m_entity.ApprovalCollection.Count - 1)
    '      Dim newUser As New User(approvalComment.Originator)
    '      Dim approveText As String = ""
    '      If approvalComment.Type = ApproveType.approved Then
    '        approveText = Me.StringParserService.Parse("${res:Global.Receipt}")
    '      ElseIf approvalComment.Type = ApproveType.reject Then
    '        approveText = Me.StringParserService.Parse("${res:Global.Reject}")
    '      End If
    '      txtReceiptStatus.Text = approveText & " : " & approvalComment.Comment & vbCrLf & _
    '                              "(" & approvalComment.LastEditDate.ToShortDateString & " : " & newUser.Name & ")"
    '    Else
    '      txtReceiptStatus.Text = Me.StringParserService.Parse("${res:Global.NotConfirm}")
    '    End If
    '  End If
    'End Sub
    Private Sub UpdateAccount()
      If m_entity.ToAccount Is Nothing Then
        Return
      End If
      Me.txtAccountCode.Text = m_entity.ToAccount.Code
      Me.txtAccount.Text = m_entity.ToAccount.Name
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable, tgItem)
      ReIndex()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True
      'Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
      If Me.m_entity.ApprovalCollection.Count > 0 Then
        Me.chkShowCost.Enabled = True
      Else
        Me.chkShowCost.Enabled = False
      End If
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Then
        UpdateAmount()
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private Sub StoreApprove(ByVal sender As Object, ByVal e As MatTransferItemCollection.StoreApproveEventArgs)
      Dim approvehash As Hashtable = e.ApproveHash
      Dim str As String
      Dim ApprovePr As New StoreApprovePR
      ApprovePr.Person = Me.SecurityService.CurrentUser.Id
      For Each oPr As PR In approvehash.Values
        ApprovePr.lstvPR.Items.Add(oPr.Code).Tag = oPr
      Next
      If ApprovePr.lstvPR.Items.Count > 0 Then
        ApprovePr.ShowDialog()
      Else
        ApprovePr.Dispose()
        ApprovePr = Nothing
      End If
    End Sub
    Private Sub UpdateAmount()
      Me.txtItemCount.Text = Configuration.FormatToString(Me.m_entity.ItemCollection.Count, DigitConfig.Int)
      Me.txtTotalAmount.Text = Configuration.FormatToString(Me.m_entity.Gross, DigitConfig.Price)
    End Sub
    Private Sub ReIndex()
      Dim i As Integer = 0
      For Each row As DataRow In Me.m_treeManager.Treetable.Rows
        row("stocki_linenumber") = i + 1
        i += 1
      Next
    End Sub
    Private m_dateSetting As Boolean = False
    Private m_dateSetting2 As Boolean = True  'set �ҡ˹�Ҩ� 
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
      '  Case "cmbcode"
      '    If m_entity.AutoGen Then
      '      '���� AutoCode
      '      If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
      '        Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
      '        Me.m_entity.Code = m_entity.AutoCodeFormat.Format
      '        Me.m_entity.OnGlChanged()
      '      End If
      '    Else
      '      Me.m_entity.Code = cmbCode.Text
      '    End If
      '    dirtyFlag = True
      '  Case "txtnote"
      '    Me.m_entity.Note = txtNote.Text
      '    dirtyFlag = True
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
              m_dateSetting2 = False
            End If
            dirtyFlag = True
          End If
        Case "txtdocdate"
          m_dateSetting = True
          If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
            Dim theDate As Date = CDate(Me.txtDocDate.Text)
            If Not Me.m_entity.DocDate.Equals(theDate) Then
              dtpDocDate.Value = theDate
              Me.m_entity.DocDate = dtpDocDate.Value
              m_dateSetting2 = False
              dirtyFlag = True
            End If
          Else
            Me.m_entity.DocDate = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            m_dateSetting2 = True
            dirtyFlag = True
          End If
          m_dateSetting = False

      '  Case "txttoccpersoncode"
      '    If toCCPersonCodeChanged Then
      '      dirtyFlag = Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_entity.ToCostCenterPerson)
      '      toCCPersonCodeChanged = False
      '    End If
      '  Case "txttocostcentercode"
      '    If toCCCodeChanged Then
      '      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      '      If Me.txtToCostCenterCode.TextLength <> 0 Then
      '        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Caption.ChangeCC}") Then
      '          dirtyFlag = CostCenter.GetCostCenterWithoutRight(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter)
      '          UpdateDestAdmin()
      '          UpdateAccount()
      '          Try
      '            If oldCCId <> Me.m_entity.ToCostCenter.Id Then
      '              oldCCId = Me.m_entity.ToCostCenter.Id
      '              ChangeCC()
      '            End If
      '          Catch ex As Exception

      '          End Try
      '          toCCCodeChanged = False
      '        Else
      '          Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
      '          toCCCodeChanged = False
      '        End If
      '      Else
      '        Me.m_entity.ToCostCenter = New CostCenter
      '        txtToCostCenterName.Text = ""
      '        If oldCCId <> Me.m_entity.ToCostCenter.Id Then
      '          oldCCId = Me.m_entity.ToCostCenter.Id
      '          ChangeCC()
      '        End If
      '      End If
      '    End If
      '  Case "txtfromccpersoncode"
      '    If fromCCPersonCodeChanged Then
      '      dirtyFlag = Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromCostCenterPerson)
      '      fromCCPersonCodeChanged = False
      '    End If
      '  Case "txtfromcostcentercode"
      '    If fromCCCodeChanged Then
      '      dirtyFlag = CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      '      UpdateOriginAdmin()
      '      ListType()
      '      fromCCCodeChanged = False
      '    End If
      '  Case "cmbdoctype"
      '    Dim item As IdValuePair = CType(Me.cmbDocType.SelectedItem, IdValuePair)
      '    Me.m_entity.Type.Value = item.Id
      '    dirtyFlag = True
      '    UpdateAccount()
      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
      CheckFormEnable()
    End Sub
    Private oldCCId As Integer
    Private Sub ChangeCC()
      oldCCId = Me.m_entity.ToCostCenter.Id
    End Sub
    Private Sub UpdateDestAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Me.m_entity.ToCostCenterPerson = Me.m_entity.ToCostCenter.Admin
      Me.txtToCCPersonCode.Text = m_entity.ToCostCenterPerson.Code
      txtToCCPersonName.Text = m_entity.ToCostCenterPerson.Name
      Me.m_isInitialized = flag
    End Sub
    Private Sub UpdateOriginAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      'If Me.m_entity.FromCostCenterPerson.Originated Then
      '    Me.m_isInitialized = flag
      '    Return
      'End If
      Me.m_entity.FromCostCenterPerson = Me.m_entity.FromCostCenter.Admin
      txtFromCCPersonCode.Text = m_entity.FromCostCenterPerson.Code
      txtFromCCPersonName.Text = m_entity.FromCostCenterPerson.Name
      Me.m_isInitialized = flag
    End Sub
    Public Sub SetStatus()
   MyBase.SetStatusBarMessage()
    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        If TypeOf Value Is MatReceipt OrElse Value Is Nothing Then
          If CType(Value, MatReceipt).Id = 0 Then
            Return
          End If
        End If
        If Not m_entity Is Nothing Then

          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          'RemoveHandler Me.m_entity.ItemCollection.StoreApprove, AddressOf StoreApprove
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, MatReceipt)
        'AddHandler Me.m_entity.ItemCollection.StoreApprove, AddressOf StoreApprove

        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
      ListType()
    End Sub
    Private Sub ListType()
      '  Dim oldType As New MatWithdrawType(-1)
      '  If Not Me.m_entity Is Nothing Then
      '    oldType = Me.m_entity.Type()
      '    If Me.m_entity.ToCostCenter.Originated Then
      '      If Me.m_entity.FromCostCenter.Originated Then
      '        If Me.m_entity.ToCostCenter.Id = Me.m_entity.FromCostCenter.Id Then
      '          'CostCenter ���ǡѹ ����੾���ԡ��� WIP ������ Expense
      '          CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocType, "matwithdraw_type", "code_value <> 3")
      '          If oldType.Value = 3 Then
      '            oldType.Value = 1
      '          End If
      '          CodeDescription.ComboSelect(Me.cmbDocType, oldType)
      '          Return
      '        End If
      '      End If
      '    End If
      '  End If
      '  CodeDescription.ListCodeDescriptionInComboBox(Me.cmbDocType, "matwithdraw_type")
      '  If oldType.Value = -1 Then
      '    oldType.Value = 1
      '  End If
      '  CodeDescription.ComboSelect(Me.cmbDocType, oldType)
    End Sub
#End Region

#Region "Event Handlers"
    Public Sub LCIClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.FromCostCenter Is Nothing OrElse Not Me.m_entity.FromCostCenter.Originated Then
        msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.MatWithdrawDetailView.Message.InputFromCC}")
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New LCIForSelection
      If TypeOf Me.m_entity Is IAbleValidateItemQuantity Then
        entity.ItemEntity = CType(Me.m_entity, IAbleValidateItemQuantity).ItemEntityHashTable
      End If
      entity.CC = Me.m_entity.FromCostCenter
      entity.FromWip = False
      entity.refEntityId = Me.Entity.EntityId
      myEntityPanelService.OpenListDialog(entity, AddressOf SetLCIItems)
    End Sub
    Private Sub SetLCIItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      For i As Integer = 0 To items.Count - 1 Step 1
        Dim itemEntityLevel As Integer
        Dim item As BasketItem = CType(items(i), BasketItem)
        Dim newItem As IHasName
        Dim newType As Integer = -1
        Select Case item.FullClassName.ToLower
          Case "longkong.pojjaman.businesslogic.lciitem"
            newItem = New LCIItem(item.Id)
            newType = 42
            itemEntityLevel = CType(newItem, LCIItem).Level
          Case "longkong.pojjaman.businesslogic.tool"
            newItem = New Tool(item.Id)
            newType = 19
            itemEntityLevel = 5
        End Select
        If itemEntityLevel = 5 Then
          'If i = items.Count - 1 Then
          If Me.m_entity.ItemCollection.Count = 0 Then
            Dim doc As New MatReceiptItem
            'doc.Qty = Me.m_entity.GetRemainLCIItem(newItem.Id) / doc.Conversion
            Me.m_entity.ItemCollection.Add(doc)
            If newType = 42 Then
              doc.Qty = doc.GetAmountFromSproc(item.Id, Me.m_entity.FromCC.Id)
              doc.OldQty = doc.Qty
            End If
            doc.Entity = newItem
          Else
            Dim doc As New MatReceiptItem
            If Not Me.CurrentItem Is Nothing Then
              doc = Me.CurrentItem
            Else
              'doc.Qty = Me.m_entity.GetRemainLCIItem(newItem.Id) / doc.Conversion
              Me.m_entity.ItemCollection.Add(doc)
            End If
            If newType = 42 Then
              doc.Qty = doc.GetAmountFromSproc(item.Id, Me.m_entity.FromCC.Id)
              doc.OldQty = doc.Qty
            End If
            doc.Entity = newItem
          End If
          'Else
          '  Dim doc As New MatWithdrawItem
          '  Me.m_entity.ItemCollection.Insert(index, doc)
          '  doc.Entity = newItem
          'End If
        End If
      Next
      RefreshDocs()
      tgItem.CurrentRowIndex = index
    End Sub
    Public Sub UnitClicked(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As MatReceiptItem = Me.CurrentItem
      If doc Is Nothing Then
        doc = New MatReceiptItem
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_treeManager.SelectedRow.Tag = doc
      End If
      Dim includeFilter As Boolean = False
      If TypeOf doc.Entity Is Tool Then
        Dim mytool As Tool = CType(doc.Entity, Tool)
        If Not mytool.Unit Is Nothing AndAlso mytool.Unit.Originated Then
          filters(0) = New Filter("includedId", mytool.Unit.Id)
          includeFilter = True
        End If
      ElseIf TypeOf doc.Entity Is LCIItem Then
        Dim idList As String = CType(doc.Entity, LCIItem).GetUnitIdList
        If idList.Length > 0 Then
          filters(0) = New Filter("includedId", idList)
          includeFilter = True
        End If
      End If
      If includeFilter Then
        myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit, filters)
      Else
        myEntityPanelService.OpenListDialog(New Unit, AddressOf SetUnit)
      End If
    End Sub
    Private Sub SetUnit(ByVal unit As ISimpleEntity)
      Me.m_treeManager.SelectedRow("Unit") = unit.Code
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As MatReceiptItem = Me.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim theItem As New MatReceiptItem
      theItem.Entity = newItem
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc), theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim doc As MatReceiptItem = Me.CurrentItem
      Dim index As Integer = tgItem.CurrentRowIndex
      If doc Is Nothing Then
        Return
      End If
      Me.m_entity.ItemCollection.Remove(doc)
      RefreshDocs()
      tgItem.CurrentRowIndex = index - 1
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
#End Region

#Region "IValidatable"
    Public ReadOnly Property FormValidator() As Components.PJMTextboxValidator Implements IValidatable.FormValidator
      Get
        Return Me.Validator
      End Get
    End Property
#End Region

#Region "Button Events"
    'Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  UpdateAutogenStatus()
    'End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      '  If Me.chkAutorun.Checked Then
      '    'Me.Validator.SetRequired(Me.txtCode, False)
      '    'Me.ErrorProvider1.SetError(Me.txtCode, "")
      '    'Me.txtCode.ReadOnly = True
      '    Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
      Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
      Me.m_entity.SetAutoCodeFormat(currentUserId)
      '    BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
      '    If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
      '      If Me.cmbCode.Items.Count > 0 Then
      '        Me.m_entity.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
      '        Me.cmbCode.SelectedIndex = 0
      '        Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
      '      End If
      '    Else
      '      Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(Me.m_entity.Code)
      '      If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
      '        Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
      '      End If
      '    End If
      '    m_oldCode = Me.cmbCode.Text
      '    'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
      '    'Hack: set Code �� "" �ͧ
      '    'Me.m_entity.Code = ""
      '    Me.m_entity.Code = m_oldCode
      '    Me.m_entity.AutoGen = True
      '  Else
      '    ' Me.Validator.SetRequired(Me.txtCode, True)
      '    Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
      '    Me.cmbCode.Text = m_oldCode
      '    'Me.txtCode.ReadOnly = False
      '    Me.m_entity.AutoGen = False
      '  End If
    End Sub
    Private Sub chkShowCost_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowCost.CheckedChanged
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Not Me.m_isInitialized Then
        Return
      End If
      Me.m_entity.Grouping = Not Me.chkShowCost.Checked
      'Me.m_entity.ItemCollection = New MatReceiptItemCollection(Me.m_entity, Me.m_entity.Grouping)
      Me.ToggleStyle(Me.tgItem.TableStyles(0))
      RefreshDocs()
      'tgItem.Width += 1
      'tgItem.Width -= 1
      Me.Entity = m_entity
    End Sub
    Private Sub ibtnShowPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      If Me.m_entity.ValidIdOrDBNull(Me.m_entity.ToCostCenter) Is DBNull.Value Then     '_
        'OrElse Me.m_entity.ValidIdOrDBNull(Me.m_entity.FromCostCenter) Is DBNull.Value Then
        Return
      End If
      Dim dlg As New BasketDialog
      AddHandler dlg.EmptyBasket, AddressOf SetItems

      Dim filters(5) As Filter
      Dim excludeList As Object = ""
      excludeList = GetPRExcludeList()
      If excludeList.ToString.Length = 0 Then
        excludeList = DBNull.Value
      End If
      Dim prNeedsApproval As Boolean = False
      Dim prNeedsStoreApproval As Boolean = False

      Dim tmp As Object
      Dim tmp2 As Object
      tmp = Configuration.GetConfig("MWPRFull")
      tmp2 = Configuration.GetConfig("MWPRremainPO")

      prNeedsApproval = CBool(Configuration.GetConfig("ApprovePR"))
      'prNeedsStoreApproval = CBool(Configuration.GetConfig("PRNeedStoreApprove"))
      filters(0) = New Filter("excludeList", excludeList)
      filters(1) = New Filter("prNeedsApproval", prNeedsApproval)
      filters(2) = New Filter("excludeCanceled", True)
      filters(3) = New Filter("PRNeedStoreApprove", prNeedsStoreApproval)
      filters(4) = New Filter("formEntity", Me.m_entity.EntityId)
      If CBool(tmp) Then
        filters(5) = New Filter("MWPRMode", 1)
      ElseIf CBool(tmp2) Then
        filters(5) = New Filter("MWPRMode", 2)
      Else
        filters(5) = New Filter("MWPRMode", 0)
      End If
      Dim Entities As New ArrayList
      If Not Me.m_entity.ToCostCenter Is Nothing AndAlso Me.m_entity.ToCostCenter.Originated Then
        Entities.Add(Me.m_entity.ToCostCenter)
      End If

      Dim view As AbstractEntityPanelViewContent = New PRSelectionView(New PR, New BasketDialog, filters, Entities)
      dlg.Lists.Add(view)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
      myDialog.ShowDialog()
    End Sub
    Private Function GetPRExcludeList() As String
      Dim ret As String = ""
      For Each item As MatTransferItem In Me.m_entity.ItemCollection
        If Not item.Pritem Is Nothing Then
          ret &= "|" & item.Pritem.Pr.Id.ToString & ":" & item.Pritem.LineNumber.ToString & "|"
        End If
      Next
      Return ret
    End Function
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnShowToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity.ToCostCenter Is Nothing OrElse Not Me.m_entity.ToCostCenter.Originated OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Caption.ChangeCC}") Then
        Dim myEntityPanelService As IEntityPanelService = _
                    CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
        myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetToCostCenter, New Filter() {New Filter("checkright", False)})
      End If
    End Sub
    Private Sub SetToCostCenter(ByVal e As ISimpleEntity)
      Me.txtToCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenterWithoutRight(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter)
      ListType()
      UpdateDestAdmin()
      Try
        If oldCCId <> Me.m_entity.ToCostCenter.Id Then
          oldCCId = Me.m_entity.ToCostCenter.Id
          ChangeCC()
        End If
      Catch ex As Exception

      End Try
      Me.toCCCodeChanged = False
      'Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ibtnShowToCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetToPerson)
    End Sub
    Private Sub SetToPerson(ByVal e As ISimpleEntity)
      Me.txtToCCPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtToCCPersonCode, txtToCCPersonName, Me.m_entity.ToCostCenterPerson)
      toCCPersonCodeChanged = False
      'Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ibtnShowFromCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetFromCostCenter)
    End Sub
    Private Sub SetFromCostCenter(ByVal e As ISimpleEntity)
      Me.txtFromCostCenterCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or CostCenter.GetCostCenter(txtFromCostCenterCode, txtFromCostCenterName, Me.m_entity.FromCostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      ListType()
      UpdateAccount()
      UpdateOriginAdmin()
      fromCCCodeChanged = False
      'Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ibtnShowFromCCPersonDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Employee, AddressOf SetFromPerson)
    End Sub
    Private Sub SetFromPerson(ByVal e As ISimpleEntity)
      Me.txtFromCCPersonCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtFromCCPersonCode, txtFromCCPersonName, Me.m_entity.FromCostCenterPerson)
      fromCCPersonCodeChanged = False
      'Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
    End Sub
    Private Sub ShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New CostCenter)
    End Sub
    Private Sub ShowCCPerson_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Employee)
    End Sub
    'Private Sub ibtnShowAssetDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '  Dim myEntityPanelService As IEntityPanelService = _
    '              CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    '  Dim entities As New ArrayList
    '  Dim eq As New Asset
    '  entities.Add(eq)
    '  myEntityPanelService.OpenListDialog(New Asset, AddressOf SetAsset, entities)
    'End Sub
    'Private Sub SetAsset(ByVal e As ISimpleEntity)
    '  Me.txtEquipmentCode.Text = e.Code
    '  Dim flag As Boolean = Asset.GetAsset(txtEquipmentCode, txtEquipmentName, Me.m_entity.Asset)
    '  If flag Then
    '    Me.ChangeEq()
    '  End If
    '  Me.WorkbenchWindow.ViewContent.IsDirty = _
    '      Me.WorkbenchWindow.ViewContent.IsDirty _
    '      Or flag
    'End Sub
    Private Sub ChangeEq()

      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
      txtToCostCenterName.Text = m_entity.ToCostCenter.Name
      Me.m_isInitialized = flag
    End Sub

#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New MatReceipt).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.Resize
      If Me.m_entity Is Nothing Then
        Return
      End If
    End Sub
#End Region

    'Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
    '  Me.m_entity.ItemCollection.CheckPRForStoreApprove()
    'End Sub

    'Private Sub CheckApproveStore()
    '  If CBool(Configuration.GetConfig("PRNeedStoreApprove")) Then
    '    Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
    '    Dim level As Integer = secSrv.GetAccess(290)
    '    Dim checkString As String = BinaryHelper.DecToBin(level, 5)
    '    checkString = BinaryHelper.RevertString(checkString)
    '    If Not CBool(checkString.Substring(0, 1)) Then
    '      '�������
    '      Me.btnApprove.Visible = False
    '    Else
    '      Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.btnStoreApprove}")
    '      Me.btnApprove.Visible = True
    '    End If
    '  Else
    '    Me.btnApprove.Visible = False
    '  End If
    'End Sub

    'Public Overrides Sub NotifyAfterSave(ByVal successful As Boolean)
    '  MyBase.NotifyAfterSave(successful)
    'End Sub

    Private Sub ibtnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnApprove.Click
      If Me.m_entity Is Nothing OrElse Me.m_entity.Id = 0 Then
        Return
      End If
      Try
        Dim old_aprvType As ApproveType = m_entity.ApprovalCollection.Approved
        Dim x As New AdvanceStoreApprovalCommentForm(Me.Entity)
        x.ShowDialog()
        If Not x.ApproveDoc Is Nothing Then
          Dim aprvType As ApproveType = x.ApproveDoc.Type
          'Dim aprvType As ApproveType = m_entity.ApprovalCollection.Approved
          Select Case aprvType
            Case ApproveType.approved
              'Me.m_entity.Save(CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
              'Me.m_entity.RefreshApproveCommentList()
              ' Me.NotifyAfterSave(True)
              m_dateSetting2 = True
              UpdateEntityProperties()
            Case ApproveType.reject, -1
              'Me.m_entity.Delete()
              'Me.m_entity.RefreshApproveCommentList()
              '  Me.NotifyAfterSave(True)
              m_dateSetting2 = True
              UpdateEntityProperties()
          End Select
          If old_aprvType <> aprvType Then
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            Me.chkShowCost.Enabled = Not Me.WorkbenchWindow.ViewContent.IsDirty
          End If
        End If

      Catch ex As Exception
        MessageBox.Show(ex.Message & vbCrLf & ex.InnerException.ToString)
      End Try

      'UpdateEntityProperties()
      'CheckFormEnable()
    End Sub
  End Class


End Namespace

