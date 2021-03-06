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
Imports System.Collections.Generic
Imports System.Text.RegularExpressions
Imports Longkong.Pojjaman.Commands

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class POPanelView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable, ICanRefreshAutoComplete, IPreviewable

#Region " Windows Form Designer generated code "
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    Friend WithEvents lblReceivingDate As System.Windows.Forms.Label
    Friend WithEvents dtpReceivingDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDiscountAmount As System.Windows.Forms.Label
    Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
    Friend WithEvents txtBeforeTax As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxAmount As System.Windows.Forms.Label
    Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents lblAfterTax As System.Windows.Forms.Label
    Friend WithEvents txtAfterTax As System.Windows.Forms.TextBox
    Friend WithEvents txtDiscountRate As System.Windows.Forms.TextBox
    Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
    Friend WithEvents lblTaxType As System.Windows.Forms.Label
    Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxRate As System.Windows.Forms.Label
    Friend WithEvents lblSupplier As System.Windows.Forms.Label
    Friend WithEvents lblCreditPrd As System.Windows.Forms.Label
    Friend WithEvents txtCreditPrd As System.Windows.Forms.TextBox
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents lblDay As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents btnSupplierFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSupplierEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierCode As System.Windows.Forms.TextBox
    Friend WithEvents txtReceivingDate As System.Windows.Forms.TextBox
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxBase As System.Windows.Forms.Label
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents ibtnShowPR As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDueDate As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnGetFromBOQ As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnRequestorEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnRequestorFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRequestorName As System.Windows.Forms.TextBox
    Friend WithEvents txtRequestorCode As System.Windows.Forms.TextBox
    Friend WithEvents lblRequestor As System.Windows.Forms.Label
    Friend WithEvents grbRetention As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtRetention As System.Windows.Forms.TextBox
    Friend WithEvents lblRetention As System.Windows.Forms.Label
    Friend WithEvents txtRetentionNote As System.Windows.Forms.TextBox
    Friend WithEvents lblRetentionNote As System.Windows.Forms.Label
    Friend WithEvents chkClosed As System.Windows.Forms.CheckBox
    Friend WithEvents btnApprove As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtSupplierName As System.Windows.Forms.TextBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents cmbPOPlaceDeli As System.Windows.Forms.ComboBox
    Friend WithEvents lblPOPlaceDeli As System.Windows.Forms.Label
    Friend WithEvents cmbContact As System.Windows.Forms.ComboBox
    Friend WithEvents lblContact As System.Windows.Forms.Label
    Friend WithEvents lblLanguage As System.Windows.Forms.Label
    Friend WithEvents lblUnit2 As System.Windows.Forms.Label
    Friend WithEvents lblUnit1 As System.Windows.Forms.Label
    Friend WithEvents lblRate As System.Windows.Forms.Label
    Friend WithEvents txtLanguage As System.Windows.Forms.TextBox
    Friend WithEvents txtUnit2 As System.Windows.Forms.TextBox
    Friend WithEvents txtUnit1 As System.Windows.Forms.TextBox
    Friend WithEvents txtRate As System.Windows.Forms.TextBox
    Friend WithEvents FixedGroupBox1 As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents imAttachment As System.Windows.Forms.PictureBox
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(POPanelView))
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDate = New System.Windows.Forms.Label()
            Me.lblGross = New System.Windows.Forms.Label()
            Me.txtGross = New System.Windows.Forms.TextBox()
            Me.lblDiscountAmount = New System.Windows.Forms.Label()
            Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
            Me.lblBeforeTax = New System.Windows.Forms.Label()
            Me.txtBeforeTax = New System.Windows.Forms.TextBox()
            Me.lblReceivingDate = New System.Windows.Forms.Label()
            Me.dtpReceivingDate = New System.Windows.Forms.DateTimePicker()
            Me.lblTaxAmount = New System.Windows.Forms.Label()
            Me.txtTaxAmount = New System.Windows.Forms.TextBox()
            Me.lblAfterTax = New System.Windows.Forms.Label()
            Me.txtAfterTax = New System.Windows.Forms.TextBox()
            Me.txtDiscountRate = New System.Windows.Forms.TextBox()
            Me.cmbTaxType = New System.Windows.Forms.ComboBox()
            Me.lblTaxType = New System.Windows.Forms.Label()
            Me.txtTaxRate = New System.Windows.Forms.TextBox()
            Me.lblTaxRate = New System.Windows.Forms.Label()
            Me.lblSupplier = New System.Windows.Forms.Label()
            Me.txtSupplierCode = New System.Windows.Forms.TextBox()
            Me.txtCreditPrd = New System.Windows.Forms.TextBox()
            Me.lblCreditPrd = New System.Windows.Forms.Label()
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.lblStatus = New System.Windows.Forms.Label()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.txtDocDate = New System.Windows.Forms.TextBox()
            Me.txtReceivingDate = New System.Windows.Forms.TextBox()
            Me.txtCostCenterCode = New System.Windows.Forms.TextBox()
            Me.txtRequestorCode = New System.Windows.Forms.TextBox()
            Me.txtRetention = New System.Windows.Forms.TextBox()
            Me.txtRetentionNote = New System.Windows.Forms.TextBox()
            Me.txtSupplierName = New System.Windows.Forms.TextBox()
            Me.txtTaxBase = New System.Windows.Forms.TextBox()
            Me.txtRequestorName = New System.Windows.Forms.TextBox()
            Me.txtRealGross = New System.Windows.Forms.TextBox()
            Me.txtRealTaxAmount = New System.Windows.Forms.TextBox()
            Me.txtRealTaxBase = New System.Windows.Forms.TextBox()
            Me.txtCostCenterName = New System.Windows.Forms.TextBox()
            Me.txtRate = New System.Windows.Forms.TextBox()
            Me.txtUnit1 = New System.Windows.Forms.TextBox()
            Me.txtUnit2 = New System.Windows.Forms.TextBox()
            Me.txtLanguage = New System.Windows.Forms.TextBox()
            Me.lblItem = New System.Windows.Forms.Label()
            Me.btnSupplierFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnSupplierEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblDay = New System.Windows.Forms.Label()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.imAttachment = New System.Windows.Forms.PictureBox()
            Me.FixedGroupBox1 = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblRate = New System.Windows.Forms.Label()
            Me.lblLanguage = New System.Windows.Forms.Label()
            Me.lblUnit2 = New System.Windows.Forms.Label()
            Me.lblUnit1 = New System.Windows.Forms.Label()
            Me.cmbContact = New System.Windows.Forms.ComboBox()
            Me.lblContact = New System.Windows.Forms.Label()
            Me.cmbPOPlaceDeli = New System.Windows.Forms.ComboBox()
            Me.lblPOPlaceDeli = New System.Windows.Forms.Label()
            Me.cmbCode = New System.Windows.Forms.ComboBox()
            Me.btnApprove = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.grbRetention = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lblRetention = New System.Windows.Forms.Label()
            Me.lblRetentionNote = New System.Windows.Forms.Label()
            Me.btnRequestorEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnRequestorFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblRequestor = New System.Windows.Forms.Label()
            Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblCostCenter = New System.Windows.Forms.Label()
            Me.chkAutorun = New System.Windows.Forms.CheckBox()
            Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
            Me.ibtnShowPR = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblTaxBase = New System.Windows.Forms.Label()
            Me.lblDueDate = New System.Windows.Forms.Label()
            Me.ibtnGetFromBOQ = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.chkClosed = New System.Windows.Forms.CheckBox()
            Me.lblPercent = New System.Windows.Forms.Label()
            Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbDetail.SuspendLayout()
            CType(Me.imAttachment, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.FixedGroupBox1.SuspendLayout()
            Me.grbRetention.SuspendLayout()
            Me.SuspendLayout()
            '
            'tgItem
            '
            Me.tgItem.AllowDrop = True
            Me.tgItem.AllowNew = False
            Me.tgItem.AllowSorting = False
            Me.tgItem.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgItem.AutoColumnResize = True
            Me.tgItem.CaptionVisible = False
            Me.tgItem.Cellchanged = False
            Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer), CType(CType(0, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(128, Byte), Integer))})
            Me.tgItem.DataMember = ""
            Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
            Me.tgItem.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgItem.Location = New System.Drawing.Point(8, 203)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(867, 390)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 8
            Me.tgItem.TreeManager = Nothing
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.Location = New System.Drawing.Point(8, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(88, 18)
            Me.lblCode.TabIndex = 11
            Me.lblCode.Text = "�Ţ��� PO:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDate
            '
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDate.Location = New System.Drawing.Point(336, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(136, 21)
            Me.dtpDocDate.TabIndex = 2
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.Location = New System.Drawing.Point(272, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(64, 18)
            Me.lblDocDate.TabIndex = 14
            Me.lblDocDate.Text = "�ѹ���:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblGross
            '
            Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblGross.BackColor = System.Drawing.Color.Transparent
            Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGross.Location = New System.Drawing.Point(323, 597)
            Me.lblGross.Name = "lblGross"
            Me.lblGross.Size = New System.Drawing.Size(80, 18)
            Me.lblGross.TabIndex = 50
            Me.lblGross.Text = "�ʹ�Թ��� :"
            Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtGross
            '
            Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtGross.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGross, "")
            Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.txtGross.Location = New System.Drawing.Point(409, 597)
            Me.Validator.SetMaxValue(Me.txtGross, "")
            Me.Validator.SetMinValue(Me.txtGross, "")
            Me.txtGross.Name = "txtGross"
            Me.txtGross.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGross, "")
            Me.Validator.SetRequired(Me.txtGross, False)
            Me.txtGross.Size = New System.Drawing.Size(81, 21)
            Me.txtGross.TabIndex = 51
            Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblDiscountAmount
            '
            Me.lblDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDiscountAmount.Location = New System.Drawing.Point(354, 624)
            Me.lblDiscountAmount.Name = "lblDiscountAmount"
            Me.lblDiscountAmount.Size = New System.Drawing.Size(48, 18)
            Me.lblDiscountAmount.TabIndex = 49
            Me.lblDiscountAmount.Text = "��ǹŴ :"
            Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDiscountAmount
            '
            Me.txtDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
            Me.txtDiscountAmount.Location = New System.Drawing.Point(499, 621)
            Me.Validator.SetMaxValue(Me.txtDiscountAmount, "")
            Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
            Me.txtDiscountAmount.Name = "txtDiscountAmount"
            Me.txtDiscountAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
            Me.Validator.SetRequired(Me.txtDiscountAmount, False)
            Me.txtDiscountAmount.Size = New System.Drawing.Size(95, 21)
            Me.txtDiscountAmount.TabIndex = 52
            Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblBeforeTax
            '
            Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
            Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBeforeTax.Location = New System.Drawing.Point(296, 646)
            Me.lblBeforeTax.Name = "lblBeforeTax"
            Me.lblBeforeTax.Size = New System.Drawing.Size(106, 18)
            Me.lblBeforeTax.TabIndex = 53
            Me.lblBeforeTax.Text = "�ʹ�Թ���������� :"
            Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtBeforeTax
            '
            Me.txtBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtBeforeTax.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtBeforeTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBeforeTax, "")
            Me.Validator.SetGotFocusBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
            Me.txtBeforeTax.Location = New System.Drawing.Point(409, 646)
            Me.Validator.SetMaxValue(Me.txtBeforeTax, "")
            Me.Validator.SetMinValue(Me.txtBeforeTax, "")
            Me.txtBeforeTax.Name = "txtBeforeTax"
            Me.txtBeforeTax.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
            Me.Validator.SetRequired(Me.txtBeforeTax, False)
            Me.txtBeforeTax.Size = New System.Drawing.Size(185, 21)
            Me.txtBeforeTax.TabIndex = 54
            Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblReceivingDate
            '
            Me.lblReceivingDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblReceivingDate.Location = New System.Drawing.Point(8, 39)
            Me.lblReceivingDate.Name = "lblReceivingDate"
            Me.lblReceivingDate.Size = New System.Drawing.Size(88, 18)
            Me.lblReceivingDate.TabIndex = 15
            Me.lblReceivingDate.Text = "�ѹ����Ѻ�ͧ:"
            Me.lblReceivingDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpReceivingDate
            '
            Me.dtpReceivingDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpReceivingDate.Location = New System.Drawing.Point(96, 38)
            Me.dtpReceivingDate.Name = "dtpReceivingDate"
            Me.dtpReceivingDate.Size = New System.Drawing.Size(144, 21)
            Me.dtpReceivingDate.TabIndex = 6
            '
            'lblTaxAmount
            '
            Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxAmount.Location = New System.Drawing.Point(590, 621)
            Me.lblTaxAmount.Name = "lblTaxAmount"
            Me.lblTaxAmount.Size = New System.Drawing.Size(89, 18)
            Me.lblTaxAmount.TabIndex = 47
            Me.lblTaxAmount.Text = "������Ť������ :"
            Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTaxAmount
            '
            Me.txtTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxAmount.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
            Me.txtTaxAmount.Location = New System.Drawing.Point(682, 621)
            Me.Validator.SetMaxValue(Me.txtTaxAmount, "")
            Me.Validator.SetMinValue(Me.txtTaxAmount, "")
            Me.txtTaxAmount.Name = "txtTaxAmount"
            Me.txtTaxAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
            Me.Validator.SetRequired(Me.txtTaxAmount, False)
            Me.txtTaxAmount.Size = New System.Drawing.Size(78, 21)
            Me.txtTaxAmount.TabIndex = 57
            Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblAfterTax
            '
            Me.lblAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAfterTax.BackColor = System.Drawing.Color.Transparent
            Me.lblAfterTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAfterTax.Location = New System.Drawing.Point(593, 674)
            Me.lblAfterTax.Name = "lblAfterTax"
            Me.lblAfterTax.Size = New System.Drawing.Size(86, 18)
            Me.lblAfterTax.TabIndex = 48
            Me.lblAfterTax.Text = "�ʹ�ط�� :"
            Me.lblAfterTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAfterTax
            '
            Me.txtAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtAfterTax.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtAfterTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAfterTax, "")
            Me.txtAfterTax.ForeColor = System.Drawing.Color.Blue
            Me.Validator.SetGotFocusBackColor(Me.txtAfterTax, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAfterTax, System.Drawing.Color.Empty)
            Me.txtAfterTax.Location = New System.Drawing.Point(682, 673)
            Me.Validator.SetMaxValue(Me.txtAfterTax, "")
            Me.Validator.SetMinValue(Me.txtAfterTax, "")
            Me.txtAfterTax.Name = "txtAfterTax"
            Me.txtAfterTax.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
            Me.Validator.SetRequired(Me.txtAfterTax, False)
            Me.txtAfterTax.Size = New System.Drawing.Size(187, 21)
            Me.txtAfterTax.TabIndex = 58
            Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDiscountRate
            '
            Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
            Me.txtDiscountRate.Location = New System.Drawing.Point(409, 621)
            Me.Validator.SetMaxValue(Me.txtDiscountRate, "")
            Me.Validator.SetMinValue(Me.txtDiscountRate, "")
            Me.txtDiscountRate.Name = "txtDiscountRate"
            Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
            Me.Validator.SetRequired(Me.txtDiscountRate, False)
            Me.txtDiscountRate.Size = New System.Drawing.Size(87, 21)
            Me.txtDiscountRate.TabIndex = 9
            '
            'cmbTaxType
            '
            Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTaxType.Location = New System.Drawing.Point(682, 597)
            Me.cmbTaxType.Name = "cmbTaxType"
            Me.cmbTaxType.Size = New System.Drawing.Size(56, 21)
            Me.cmbTaxType.TabIndex = 43
            '
            'lblTaxType
            '
            Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxType.Location = New System.Drawing.Point(600, 597)
            Me.lblTaxType.Name = "lblTaxType"
            Me.lblTaxType.Size = New System.Drawing.Size(79, 18)
            Me.lblTaxType.TabIndex = 42
            Me.lblTaxType.Text = "����������:"
            Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTaxRate
            '
            Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtTaxRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.txtTaxRate.Location = New System.Drawing.Point(811, 597)
            Me.Validator.SetMaxValue(Me.txtTaxRate, "")
            Me.Validator.SetMinValue(Me.txtTaxRate, "")
            Me.txtTaxRate.Name = "txtTaxRate"
            Me.txtTaxRate.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
            Me.Validator.SetRequired(Me.txtTaxRate, True)
            Me.txtTaxRate.Size = New System.Drawing.Size(40, 21)
            Me.txtTaxRate.TabIndex = 45
            Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblTaxRate
            '
            Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxRate.Location = New System.Drawing.Point(741, 597)
            Me.lblTaxRate.Name = "lblTaxRate"
            Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
            Me.lblTaxRate.TabIndex = 44
            Me.lblTaxRate.Text = "�ѵ������ :"
            Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblSupplier
            '
            Me.lblSupplier.BackColor = System.Drawing.Color.Transparent
            Me.lblSupplier.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblSupplier.Location = New System.Drawing.Point(8, 60)
            Me.lblSupplier.Name = "lblSupplier"
            Me.lblSupplier.Size = New System.Drawing.Size(88, 18)
            Me.lblSupplier.TabIndex = 20
            Me.lblSupplier.Text = "Supplier:"
            Me.lblSupplier.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtSupplierCode
            '
            Me.Validator.SetDataType(Me.txtSupplierCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierCode, System.Drawing.Color.Empty)
            Me.txtSupplierCode.Location = New System.Drawing.Point(96, 60)
            Me.txtSupplierCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtSupplierCode, "")
            Me.Validator.SetMinValue(Me.txtSupplierCode, "")
            Me.txtSupplierCode.Name = "txtSupplierCode"
            Me.Validator.SetRegularExpression(Me.txtSupplierCode, "")
            Me.Validator.SetRequired(Me.txtSupplierCode, True)
            Me.txtSupplierCode.Size = New System.Drawing.Size(144, 21)
            Me.txtSupplierCode.TabIndex = 6
            '
            'txtCreditPrd
            '
            Me.Validator.SetDataType(Me.txtCreditPrd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
            Me.Validator.SetDisplayName(Me.txtCreditPrd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
            Me.txtCreditPrd.Location = New System.Drawing.Point(336, 38)
            Me.Validator.SetMaxValue(Me.txtCreditPrd, "")
            Me.Validator.SetMinValue(Me.txtCreditPrd, "0")
            Me.txtCreditPrd.Name = "txtCreditPrd"
            Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
            Me.Validator.SetRequired(Me.txtCreditPrd, False)
            Me.txtCreditPrd.Size = New System.Drawing.Size(40, 21)
            Me.txtCreditPrd.TabIndex = 4
            '
            'lblCreditPrd
            '
            Me.lblCreditPrd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditPrd.Location = New System.Drawing.Point(264, 39)
            Me.lblCreditPrd.Name = "lblCreditPrd"
            Me.lblCreditPrd.Size = New System.Drawing.Size(72, 18)
            Me.lblCreditPrd.TabIndex = 16
            Me.lblCreditPrd.Text = "�����ôԵ:"
            Me.lblCreditPrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtNote
            '
            Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(11, 621)
            Me.txtNote.MaxLength = 1000
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtNote.Size = New System.Drawing.Size(234, 70)
            Me.txtNote.TabIndex = 14
            Me.txtNote.WordWrap = False
            '
            'lblNote
            '
            Me.lblNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblNote.BackColor = System.Drawing.Color.Transparent
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(13, 598)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(110, 18)
            Me.lblNote.TabIndex = 23
            Me.lblNote.Text = "�����˵�:"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblStatus
            '
            Me.lblStatus.AutoSize = True
            Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark
            Me.lblStatus.Location = New System.Drawing.Point(248, 181)
            Me.lblStatus.Name = "lblStatus"
            Me.lblStatus.Size = New System.Drawing.Size(38, 13)
            Me.lblStatus.TabIndex = 38
            Me.lblStatus.Text = "Status"
            Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            'txtDocDate
            '
            Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, -13)
            Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.txtDocDate.Location = New System.Drawing.Point(336, 16)
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(107, 21)
            Me.txtDocDate.TabIndex = 1
            '
            'txtReceivingDate
            '
            Me.Validator.SetDataType(Me.txtReceivingDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtReceivingDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtReceivingDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtReceivingDate, -13)
            Me.Validator.SetInvalidBackColor(Me.txtReceivingDate, System.Drawing.Color.Empty)
            Me.txtReceivingDate.Location = New System.Drawing.Point(96, 38)
            Me.Validator.SetMaxValue(Me.txtReceivingDate, "")
            Me.Validator.SetMinValue(Me.txtReceivingDate, "")
            Me.txtReceivingDate.Name = "txtReceivingDate"
            Me.Validator.SetRegularExpression(Me.txtReceivingDate, "")
            Me.Validator.SetRequired(Me.txtReceivingDate, True)
            Me.txtReceivingDate.Size = New System.Drawing.Size(110, 21)
            Me.txtReceivingDate.TabIndex = 3
            '
            'txtCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtCostCenterCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
            Me.txtCostCenterCode.Location = New System.Drawing.Point(96, 108)
            Me.Validator.SetMaxValue(Me.txtCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
            Me.txtCostCenterCode.Name = "txtCostCenterCode"
            Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtCostCenterCode, True)
            Me.txtCostCenterCode.Size = New System.Drawing.Size(144, 21)
            Me.txtCostCenterCode.TabIndex = 9
            '
            'txtRequestorCode
            '
            Me.Validator.SetDataType(Me.txtRequestorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRequestorCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRequestorCode, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRequestorCode, System.Drawing.Color.Empty)
            Me.txtRequestorCode.Location = New System.Drawing.Point(96, 130)
            Me.Validator.SetMaxValue(Me.txtRequestorCode, "")
            Me.Validator.SetMinValue(Me.txtRequestorCode, "")
            Me.txtRequestorCode.Name = "txtRequestorCode"
            Me.Validator.SetRegularExpression(Me.txtRequestorCode, "")
            Me.Validator.SetRequired(Me.txtRequestorCode, True)
            Me.txtRequestorCode.Size = New System.Drawing.Size(144, 21)
            Me.txtRequestorCode.TabIndex = 11
            '
            'txtRetention
            '
            Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRetention, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRetention, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
            Me.txtRetention.Location = New System.Drawing.Point(72, 17)
            Me.Validator.SetMaxValue(Me.txtRetention, "")
            Me.Validator.SetMinValue(Me.txtRetention, "")
            Me.txtRetention.Name = "txtRetention"
            Me.Validator.SetRegularExpression(Me.txtRetention, "")
            Me.Validator.SetRequired(Me.txtRetention, False)
            Me.txtRetention.Size = New System.Drawing.Size(128, 21)
            Me.txtRetention.TabIndex = 0
            Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtRetentionNote
            '
            Me.Validator.SetDataType(Me.txtRetentionNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRetentionNote, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRetentionNote, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtRetentionNote, -15)
            Me.Validator.SetInvalidBackColor(Me.txtRetentionNote, System.Drawing.Color.Empty)
            Me.txtRetentionNote.Location = New System.Drawing.Point(16, 59)
            Me.txtRetentionNote.MaxLength = 1000
            Me.Validator.SetMaxValue(Me.txtRetentionNote, "")
            Me.Validator.SetMinValue(Me.txtRetentionNote, "")
            Me.txtRetentionNote.Multiline = True
            Me.txtRetentionNote.Name = "txtRetentionNote"
            Me.Validator.SetRegularExpression(Me.txtRetentionNote, "")
            Me.Validator.SetRequired(Me.txtRetentionNote, False)
            Me.txtRetentionNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtRetentionNote.Size = New System.Drawing.Size(184, 52)
            Me.txtRetentionNote.TabIndex = 1
            '
            'txtSupplierName
            '
            Me.Validator.SetDataType(Me.txtSupplierName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtSupplierName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconAlignment(Me.txtSupplierName, System.Windows.Forms.ErrorIconAlignment.MiddleLeft)
            Me.Validator.SetInvalidBackColor(Me.txtSupplierName, System.Drawing.Color.Empty)
            Me.txtSupplierName.Location = New System.Drawing.Point(240, 60)
            Me.Validator.SetMaxValue(Me.txtSupplierName, "")
            Me.Validator.SetMinValue(Me.txtSupplierName, "")
            Me.txtSupplierName.Name = "txtSupplierName"
            Me.Validator.SetRegularExpression(Me.txtSupplierName, "")
            Me.Validator.SetRequired(Me.txtSupplierName, False)
            Me.txtSupplierName.Size = New System.Drawing.Size(264, 21)
            Me.txtSupplierName.TabIndex = 7
            Me.txtSupplierName.TabStop = False
            '
            'txtTaxBase
            '
            Me.txtTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxBase, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
            Me.txtTaxBase.Location = New System.Drawing.Point(409, 671)
            Me.Validator.SetMaxValue(Me.txtTaxBase, "")
            Me.Validator.SetMinValue(Me.txtTaxBase, "")
            Me.txtTaxBase.Name = "txtTaxBase"
            Me.txtTaxBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
            Me.Validator.SetRequired(Me.txtTaxBase, False)
            Me.txtTaxBase.Size = New System.Drawing.Size(80, 21)
            Me.txtTaxBase.TabIndex = 56
            Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtRequestorName
            '
            Me.txtRequestorName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtRequestorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRequestorName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRequestorName, System.Drawing.Color.Empty)
            Me.txtRequestorName.Location = New System.Drawing.Point(240, 130)
            Me.Validator.SetMaxValue(Me.txtRequestorName, "")
            Me.Validator.SetMinValue(Me.txtRequestorName, "")
            Me.txtRequestorName.Name = "txtRequestorName"
            Me.txtRequestorName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtRequestorName, "")
            Me.Validator.SetRequired(Me.txtRequestorName, False)
            Me.txtRequestorName.Size = New System.Drawing.Size(264, 21)
            Me.txtRequestorName.TabIndex = 12
            Me.txtRequestorName.TabStop = False
            '
            'txtRealGross
            '
            Me.txtRealGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtRealGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRealGross, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
            Me.txtRealGross.Location = New System.Drawing.Point(513, 597)
            Me.Validator.SetMaxValue(Me.txtRealGross, "")
            Me.Validator.SetMinValue(Me.txtRealGross, "")
            Me.txtRealGross.Name = "txtRealGross"
            Me.Validator.SetRegularExpression(Me.txtRealGross, "")
            Me.Validator.SetRequired(Me.txtRealGross, False)
            Me.txtRealGross.Size = New System.Drawing.Size(81, 21)
            Me.txtRealGross.TabIndex = 61
            Me.txtRealGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtRealTaxAmount
            '
            Me.txtRealTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
            Me.txtRealTaxAmount.Location = New System.Drawing.Point(788, 621)
            Me.Validator.SetMaxValue(Me.txtRealTaxAmount, "")
            Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
            Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
            Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
            Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
            Me.txtRealTaxAmount.Size = New System.Drawing.Size(81, 21)
            Me.txtRealTaxAmount.TabIndex = 63
            Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtRealTaxBase
            '
            Me.txtRealTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
            Me.txtRealTaxBase.Location = New System.Drawing.Point(512, 671)
            Me.Validator.SetMaxValue(Me.txtRealTaxBase, "")
            Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
            Me.txtRealTaxBase.Name = "txtRealTaxBase"
            Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
            Me.Validator.SetRequired(Me.txtRealTaxBase, False)
            Me.txtRealTaxBase.Size = New System.Drawing.Size(82, 21)
            Me.txtRealTaxBase.TabIndex = 62
            Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtCostCenterName
            '
            Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
            Me.txtCostCenterName.Location = New System.Drawing.Point(240, 108)
            Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtCostCenterName, "")
            Me.txtCostCenterName.Name = "txtCostCenterName"
            Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
            Me.Validator.SetRequired(Me.txtCostCenterName, False)
            Me.txtCostCenterName.Size = New System.Drawing.Size(264, 21)
            Me.txtCostCenterName.TabIndex = 10
            Me.txtCostCenterName.TabStop = False
            '
            'txtRate
            '
            Me.Validator.SetDataType(Me.txtRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtRate, System.Drawing.Color.Empty)
            Me.txtRate.Location = New System.Drawing.Point(6, 34)
            Me.Validator.SetMaxValue(Me.txtRate, "")
            Me.Validator.SetMinValue(Me.txtRate, "")
            Me.txtRate.Name = "txtRate"
            Me.Validator.SetRegularExpression(Me.txtRate, "")
            Me.Validator.SetRequired(Me.txtRate, False)
            Me.txtRate.Size = New System.Drawing.Size(62, 21)
            Me.txtRate.TabIndex = 341
            Me.txtRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtUnit1
            '
            Me.Validator.SetDataType(Me.txtUnit1, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnit1, "")
            Me.Validator.SetGotFocusBackColor(Me.txtUnit1, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtUnit1, System.Drawing.Color.Empty)
            Me.txtUnit1.Location = New System.Drawing.Point(74, 35)
            Me.Validator.SetMaxValue(Me.txtUnit1, "")
            Me.Validator.SetMinValue(Me.txtUnit1, "")
            Me.txtUnit1.Name = "txtUnit1"
            Me.Validator.SetRegularExpression(Me.txtUnit1, "")
            Me.Validator.SetRequired(Me.txtUnit1, False)
            Me.txtUnit1.Size = New System.Drawing.Size(62, 21)
            Me.txtUnit1.TabIndex = 341
            '
            'txtUnit2
            '
            Me.Validator.SetDataType(Me.txtUnit2, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtUnit2, "")
            Me.Validator.SetGotFocusBackColor(Me.txtUnit2, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtUnit2, System.Drawing.Color.Empty)
            Me.txtUnit2.Location = New System.Drawing.Point(142, 35)
            Me.Validator.SetMaxValue(Me.txtUnit2, "")
            Me.Validator.SetMinValue(Me.txtUnit2, "")
            Me.txtUnit2.Name = "txtUnit2"
            Me.Validator.SetRegularExpression(Me.txtUnit2, "")
            Me.Validator.SetRequired(Me.txtUnit2, False)
            Me.txtUnit2.Size = New System.Drawing.Size(62, 21)
            Me.txtUnit2.TabIndex = 341
            '
            'txtLanguage
            '
            Me.Validator.SetDataType(Me.txtLanguage, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtLanguage, "")
            Me.Validator.SetGotFocusBackColor(Me.txtLanguage, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtLanguage, System.Drawing.Color.Empty)
            Me.txtLanguage.Location = New System.Drawing.Point(210, 35)
            Me.Validator.SetMaxValue(Me.txtLanguage, "")
            Me.Validator.SetMinValue(Me.txtLanguage, "")
            Me.txtLanguage.Name = "txtLanguage"
            Me.Validator.SetRegularExpression(Me.txtLanguage, "")
            Me.Validator.SetRequired(Me.txtLanguage, False)
            Me.txtLanguage.Size = New System.Drawing.Size(62, 21)
            Me.txtLanguage.TabIndex = 341
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 179)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(80, 18)
            Me.lblItem.TabIndex = 33
            Me.lblItem.Text = "��¡����觫���"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSupplierFind
            '
            Me.btnSupplierFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSupplierFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSupplierFind.Location = New System.Drawing.Point(504, 60)
            Me.btnSupplierFind.Name = "btnSupplierFind"
            Me.btnSupplierFind.Size = New System.Drawing.Size(24, 23)
            Me.btnSupplierFind.TabIndex = 27
            Me.btnSupplierFind.TabStop = False
            Me.btnSupplierFind.ThemedImage = CType(resources.GetObject("btnSupplierFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnSupplierEdit
            '
            Me.btnSupplierEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSupplierEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnSupplierEdit.ForeColor = System.Drawing.SystemColors.Control
            Me.btnSupplierEdit.Location = New System.Drawing.Point(528, 60)
            Me.btnSupplierEdit.Name = "btnSupplierEdit"
            Me.btnSupplierEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnSupplierEdit.TabIndex = 32
            Me.btnSupplierEdit.TabStop = False
            Me.btnSupplierEdit.ThemedImage = CType(resources.GetObject("btnSupplierEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblDay
            '
            Me.lblDay.AutoSize = True
            Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDay.Location = New System.Drawing.Point(376, 42)
            Me.lblDay.Name = "lblDay"
            Me.lblDay.Size = New System.Drawing.Size(19, 13)
            Me.lblDay.TabIndex = 17
            Me.lblDay.Text = "�ѹ"
            Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.imAttachment)
            Me.grbDetail.Controls.Add(Me.FixedGroupBox1)
            Me.grbDetail.Controls.Add(Me.cmbContact)
            Me.grbDetail.Controls.Add(Me.lblContact)
            Me.grbDetail.Controls.Add(Me.cmbPOPlaceDeli)
            Me.grbDetail.Controls.Add(Me.lblPOPlaceDeli)
            Me.grbDetail.Controls.Add(Me.txtCostCenterName)
            Me.grbDetail.Controls.Add(Me.txtSupplierName)
            Me.grbDetail.Controls.Add(Me.tgItem)
            Me.grbDetail.Controls.Add(Me.cmbCode)
            Me.grbDetail.Controls.Add(Me.btnApprove)
            Me.grbDetail.Controls.Add(Me.txtRealGross)
            Me.grbDetail.Controls.Add(Me.ibtnResetGross)
            Me.grbDetail.Controls.Add(Me.txtRealTaxAmount)
            Me.grbDetail.Controls.Add(Me.ibtnResetTaxAmount)
            Me.grbDetail.Controls.Add(Me.txtRealTaxBase)
            Me.grbDetail.Controls.Add(Me.ibtnResetTaxBase)
            Me.grbDetail.Controls.Add(Me.grbRetention)
            Me.grbDetail.Controls.Add(Me.btnRequestorEdit)
            Me.grbDetail.Controls.Add(Me.btnRequestorFind)
            Me.grbDetail.Controls.Add(Me.txtRequestorName)
            Me.grbDetail.Controls.Add(Me.txtRequestorCode)
            Me.grbDetail.Controls.Add(Me.lblRequestor)
            Me.grbDetail.Controls.Add(Me.btnCCEdit)
            Me.grbDetail.Controls.Add(Me.btnCCFind)
            Me.grbDetail.Controls.Add(Me.lblCostCenter)
            Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
            Me.grbDetail.Controls.Add(Me.chkAutorun)
            Me.grbDetail.Controls.Add(Me.dtpDueDate)
            Me.grbDetail.Controls.Add(Me.ibtnShowPR)
            Me.grbDetail.Controls.Add(Me.ibtnBlank)
            Me.grbDetail.Controls.Add(Me.ibtnDelRow)
            Me.grbDetail.Controls.Add(Me.txtReceivingDate)
            Me.grbDetail.Controls.Add(Me.txtDocDate)
            Me.grbDetail.Controls.Add(Me.txtGross)
            Me.grbDetail.Controls.Add(Me.txtCreditPrd)
            Me.grbDetail.Controls.Add(Me.lblDiscountAmount)
            Me.grbDetail.Controls.Add(Me.txtDiscountAmount)
            Me.grbDetail.Controls.Add(Me.lblBeforeTax)
            Me.grbDetail.Controls.Add(Me.lblCreditPrd)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.dtpDocDate)
            Me.grbDetail.Controls.Add(Me.lblDocDate)
            Me.grbDetail.Controls.Add(Me.lblGross)
            Me.grbDetail.Controls.Add(Me.txtNote)
            Me.grbDetail.Controls.Add(Me.lblNote)
            Me.grbDetail.Controls.Add(Me.lblStatus)
            Me.grbDetail.Controls.Add(Me.txtBeforeTax)
            Me.grbDetail.Controls.Add(Me.lblReceivingDate)
            Me.grbDetail.Controls.Add(Me.dtpReceivingDate)
            Me.grbDetail.Controls.Add(Me.lblTaxAmount)
            Me.grbDetail.Controls.Add(Me.txtTaxAmount)
            Me.grbDetail.Controls.Add(Me.lblAfterTax)
            Me.grbDetail.Controls.Add(Me.txtAfterTax)
            Me.grbDetail.Controls.Add(Me.txtDiscountRate)
            Me.grbDetail.Controls.Add(Me.lblItem)
            Me.grbDetail.Controls.Add(Me.cmbTaxType)
            Me.grbDetail.Controls.Add(Me.lblTaxType)
            Me.grbDetail.Controls.Add(Me.txtTaxRate)
            Me.grbDetail.Controls.Add(Me.lblTaxRate)
            Me.grbDetail.Controls.Add(Me.lblSupplier)
            Me.grbDetail.Controls.Add(Me.txtSupplierCode)
            Me.grbDetail.Controls.Add(Me.btnSupplierFind)
            Me.grbDetail.Controls.Add(Me.btnSupplierEdit)
            Me.grbDetail.Controls.Add(Me.lblDay)
            Me.grbDetail.Controls.Add(Me.txtTaxBase)
            Me.grbDetail.Controls.Add(Me.lblTaxBase)
            Me.grbDetail.Controls.Add(Me.lblDueDate)
            Me.grbDetail.Controls.Add(Me.ibtnGetFromBOQ)
            Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
            Me.grbDetail.Controls.Add(Me.chkClosed)
            Me.grbDetail.Controls.Add(Me.lblPercent)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(0, 0)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(883, 704)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "��������´"
            '
            'imAttachment
            '
            Me.imAttachment.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.imAttachment.Location = New System.Drawing.Point(774, 98)
            Me.imAttachment.Name = "imAttachment"
            Me.imAttachment.Size = New System.Drawing.Size(29, 31)
            Me.imAttachment.TabIndex = 346
            Me.imAttachment.TabStop = False
            '
            'FixedGroupBox1
            '
            Me.FixedGroupBox1.Controls.Add(Me.lblRate)
            Me.FixedGroupBox1.Controls.Add(Me.lblLanguage)
            Me.FixedGroupBox1.Controls.Add(Me.txtRate)
            Me.FixedGroupBox1.Controls.Add(Me.lblUnit2)
            Me.FixedGroupBox1.Controls.Add(Me.txtUnit1)
            Me.FixedGroupBox1.Controls.Add(Me.lblUnit1)
            Me.FixedGroupBox1.Controls.Add(Me.txtUnit2)
            Me.FixedGroupBox1.Controls.Add(Me.txtLanguage)
            Me.FixedGroupBox1.Location = New System.Drawing.Point(560, 130)
            Me.FixedGroupBox1.Name = "FixedGroupBox1"
            Me.FixedGroupBox1.Size = New System.Drawing.Size(280, 64)
            Me.FixedGroupBox1.TabIndex = 343
            Me.FixedGroupBox1.TabStop = False
            Me.FixedGroupBox1.Text = "Currency"
            Me.FixedGroupBox1.Visible = False
            '
            'lblRate
            '
            Me.lblRate.BackColor = System.Drawing.Color.Transparent
            Me.lblRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRate.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRate.Location = New System.Drawing.Point(6, 14)
            Me.lblRate.Name = "lblRate"
            Me.lblRate.Size = New System.Drawing.Size(62, 18)
            Me.lblRate.TabIndex = 342
            Me.lblRate.Text = "Rate"
            Me.lblRate.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblLanguage
            '
            Me.lblLanguage.BackColor = System.Drawing.Color.Transparent
            Me.lblLanguage.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblLanguage.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblLanguage.Location = New System.Drawing.Point(210, 15)
            Me.lblLanguage.Name = "lblLanguage"
            Me.lblLanguage.Size = New System.Drawing.Size(62, 18)
            Me.lblLanguage.TabIndex = 342
            Me.lblLanguage.Text = "Language"
            Me.lblLanguage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblUnit2
            '
            Me.lblUnit2.BackColor = System.Drawing.Color.Transparent
            Me.lblUnit2.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit2.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblUnit2.Location = New System.Drawing.Point(142, 15)
            Me.lblUnit2.Name = "lblUnit2"
            Me.lblUnit2.Size = New System.Drawing.Size(62, 18)
            Me.lblUnit2.TabIndex = 342
            Me.lblUnit2.Text = "Unit2"
            Me.lblUnit2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblUnit1
            '
            Me.lblUnit1.BackColor = System.Drawing.Color.Transparent
            Me.lblUnit1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblUnit1.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblUnit1.Location = New System.Drawing.Point(74, 15)
            Me.lblUnit1.Name = "lblUnit1"
            Me.lblUnit1.Size = New System.Drawing.Size(62, 18)
            Me.lblUnit1.TabIndex = 342
            Me.lblUnit1.Text = "Unit1"
            Me.lblUnit1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'cmbContact
            '
            Me.cmbContact.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbContact.Location = New System.Drawing.Point(96, 84)
            Me.cmbContact.Name = "cmbContact"
            Me.cmbContact.Size = New System.Drawing.Size(456, 21)
            Me.cmbContact.TabIndex = 8
            '
            'lblContact
            '
            Me.lblContact.BackColor = System.Drawing.Color.Transparent
            Me.lblContact.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblContact.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblContact.Location = New System.Drawing.Point(16, 84)
            Me.lblContact.Name = "lblContact"
            Me.lblContact.Size = New System.Drawing.Size(80, 18)
            Me.lblContact.TabIndex = 339
            Me.lblContact.Text = "���Դ���:"
            Me.lblContact.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbPOPlaceDeli
            '
            Me.cmbPOPlaceDeli.Location = New System.Drawing.Point(96, 153)
            Me.cmbPOPlaceDeli.Name = "cmbPOPlaceDeli"
            Me.cmbPOPlaceDeli.Size = New System.Drawing.Size(456, 21)
            Me.cmbPOPlaceDeli.TabIndex = 13
            '
            'lblPOPlaceDeli
            '
            Me.lblPOPlaceDeli.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPOPlaceDeli.Location = New System.Drawing.Point(14, 153)
            Me.lblPOPlaceDeli.Name = "lblPOPlaceDeli"
            Me.lblPOPlaceDeli.Size = New System.Drawing.Size(82, 18)
            Me.lblPOPlaceDeli.TabIndex = 336
            Me.lblPOPlaceDeli.Text = "ʶҹ����觢ͧ:"
            Me.lblPOPlaceDeli.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbCode
            '
            Me.cmbCode.Location = New System.Drawing.Point(96, 16)
            Me.cmbCode.Name = "cmbCode"
            Me.cmbCode.Size = New System.Drawing.Size(120, 21)
            Me.cmbCode.TabIndex = 0
            '
            'btnApprove
            '
            Me.btnApprove.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnApprove.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnApprove.ForeColor = System.Drawing.Color.Black
            Me.btnApprove.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.btnApprove.Location = New System.Drawing.Point(774, 17)
            Me.btnApprove.Name = "btnApprove"
            Me.btnApprove.Size = New System.Drawing.Size(104, 23)
            Me.btnApprove.TabIndex = 332
            Me.btnApprove.Text = "͹��ѵ��͡���"
            Me.btnApprove.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.btnApprove.ThemedImage = CType(resources.GetObject("btnApprove.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnResetGross
            '
            Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ibtnResetGross.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnResetGross.Location = New System.Drawing.Point(489, 597)
            Me.ibtnResetGross.Name = "ibtnResetGross"
            Me.ibtnResetGross.Size = New System.Drawing.Size(24, 20)
            Me.ibtnResetGross.TabIndex = 64
            Me.ibtnResetGross.TabStop = False
            Me.ibtnResetGross.ThemedImage = CType(resources.GetObject("ibtnResetGross.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnResetTaxAmount
            '
            Me.ibtnResetTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ibtnResetTaxAmount.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(762, 621)
            Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
            Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
            Me.ibtnResetTaxAmount.TabIndex = 66
            Me.ibtnResetTaxAmount.TabStop = False
            Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnResetTaxBase
            '
            Me.ibtnResetTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ibtnResetTaxBase.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnResetTaxBase.Location = New System.Drawing.Point(488, 671)
            Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
            Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
            Me.ibtnResetTaxBase.TabIndex = 65
            Me.ibtnResetTaxBase.TabStop = False
            Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
            '
            'grbRetention
            '
            Me.grbRetention.Controls.Add(Me.txtRetention)
            Me.grbRetention.Controls.Add(Me.lblRetention)
            Me.grbRetention.Controls.Add(Me.txtRetentionNote)
            Me.grbRetention.Controls.Add(Me.lblRetentionNote)
            Me.grbRetention.Location = New System.Drawing.Point(560, 10)
            Me.grbRetention.Name = "grbRetention"
            Me.grbRetention.Size = New System.Drawing.Size(208, 119)
            Me.grbRetention.TabIndex = 60
            Me.grbRetention.TabStop = False
            Me.grbRetention.Text = "Retention"
            '
            'lblRetention
            '
            Me.lblRetention.BackColor = System.Drawing.Color.Transparent
            Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRetention.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRetention.Location = New System.Drawing.Point(8, 17)
            Me.lblRetention.Name = "lblRetention"
            Me.lblRetention.Size = New System.Drawing.Size(64, 18)
            Me.lblRetention.TabIndex = 22
            Me.lblRetention.Text = "�ӹǹ�Թ:"
            Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblRetentionNote
            '
            Me.lblRetentionNote.BackColor = System.Drawing.Color.Transparent
            Me.lblRetentionNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRetentionNote.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRetentionNote.Location = New System.Drawing.Point(8, 41)
            Me.lblRetentionNote.Name = "lblRetentionNote"
            Me.lblRetentionNote.Size = New System.Drawing.Size(64, 18)
            Me.lblRetentionNote.TabIndex = 22
            Me.lblRetentionNote.Text = "�����˵�:"
            Me.lblRetentionNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnRequestorEdit
            '
            Me.btnRequestorEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnRequestorEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRequestorEdit.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRequestorEdit.Location = New System.Drawing.Point(528, 130)
            Me.btnRequestorEdit.Name = "btnRequestorEdit"
            Me.btnRequestorEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnRequestorEdit.TabIndex = 30
            Me.btnRequestorEdit.TabStop = False
            Me.btnRequestorEdit.ThemedImage = CType(resources.GetObject("btnRequestorEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnRequestorFind
            '
            Me.btnRequestorFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnRequestorFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnRequestorFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnRequestorFind.Location = New System.Drawing.Point(504, 130)
            Me.btnRequestorFind.Name = "btnRequestorFind"
            Me.btnRequestorFind.Size = New System.Drawing.Size(24, 23)
            Me.btnRequestorFind.TabIndex = 29
            Me.btnRequestorFind.TabStop = False
            Me.btnRequestorFind.ThemedImage = CType(resources.GetObject("btnRequestorFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblRequestor
            '
            Me.lblRequestor.BackColor = System.Drawing.Color.Transparent
            Me.lblRequestor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblRequestor.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblRequestor.Location = New System.Drawing.Point(8, 130)
            Me.lblRequestor.Name = "lblRequestor"
            Me.lblRequestor.Size = New System.Drawing.Size(88, 18)
            Me.lblRequestor.TabIndex = 22
            Me.lblRequestor.Text = "����:"
            Me.lblRequestor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnCCEdit
            '
            Me.btnCCEdit.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCEdit.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCEdit.Location = New System.Drawing.Point(528, 108)
            Me.btnCCEdit.Name = "btnCCEdit"
            Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
            Me.btnCCEdit.TabIndex = 31
            Me.btnCCEdit.TabStop = False
            Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
            '
            'btnCCFind
            '
            Me.btnCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCFind.Location = New System.Drawing.Point(504, 108)
            Me.btnCCFind.Name = "btnCCFind"
            Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnCCFind.TabIndex = 28
            Me.btnCCFind.TabStop = False
            Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCostCenter
            '
            Me.lblCostCenter.BackColor = System.Drawing.Color.Transparent
            Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCostCenter.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblCostCenter.Location = New System.Drawing.Point(8, 108)
            Me.lblCostCenter.Name = "lblCostCenter"
            Me.lblCostCenter.Size = New System.Drawing.Size(88, 18)
            Me.lblCostCenter.TabIndex = 21
            Me.lblCostCenter.Text = "CostCenter:"
            Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(216, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 12
            Me.ToolTip1.SetToolTip(Me.chkAutorun, "Autorun")
            '
            'dtpDueDate
            '
            Me.dtpDueDate.Enabled = False
            Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDueDate.Location = New System.Drawing.Point(456, 38)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpDueDate.TabIndex = 5
            '
            'ibtnShowPR
            '
            Me.ibtnShowPR.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowPR.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.ibtnShowPR.Location = New System.Drawing.Point(96, 176)
            Me.ibtnShowPR.Name = "ibtnShowPR"
            Me.ibtnShowPR.Size = New System.Drawing.Size(40, 24)
            Me.ibtnShowPR.TabIndex = 34
            Me.ibtnShowPR.TabStop = False
            Me.ibtnShowPR.Text = "PR"
            Me.ibtnShowPR.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ibtnShowPR.ThemedImage = CType(resources.GetObject("ibtnShowPR.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnShowPR, "PR")
            '
            'ibtnBlank
            '
            Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnBlank.Location = New System.Drawing.Point(192, 176)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 36
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnDelRow.Location = New System.Drawing.Point(216, 176)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 37
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
            '
            'lblTaxBase
            '
            Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxBase.Location = New System.Drawing.Point(259, 671)
            Me.lblTaxBase.Name = "lblTaxBase"
            Me.lblTaxBase.Size = New System.Drawing.Size(143, 21)
            Me.lblTaxBase.TabIndex = 55
            Me.lblTaxBase.Text = "�ҹ���� :"
            Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDueDate
            '
            Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDate.ForeColor = System.Drawing.Color.Black
            Me.lblDueDate.Location = New System.Drawing.Point(384, 39)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(72, 18)
            Me.lblDueDate.TabIndex = 18
            Me.lblDueDate.Text = "�ú��˹�:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnGetFromBOQ
            '
            Me.ibtnGetFromBOQ.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnGetFromBOQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.ibtnGetFromBOQ.Location = New System.Drawing.Point(136, 176)
            Me.ibtnGetFromBOQ.Name = "ibtnGetFromBOQ"
            Me.ibtnGetFromBOQ.Size = New System.Drawing.Size(48, 24)
            Me.ibtnGetFromBOQ.TabIndex = 35
            Me.ibtnGetFromBOQ.TabStop = False
            Me.ibtnGetFromBOQ.Text = "BOQ"
            Me.ibtnGetFromBOQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            Me.ibtnGetFromBOQ.ThemedImage = CType(resources.GetObject("ibtnGetFromBOQ.ThemedImage"), System.Drawing.Bitmap)
            Me.ToolTip1.SetToolTip(Me.ibtnGetFromBOQ, "BOQ")
            '
            'ibtnCopyMe
            '
            Me.ibtnCopyMe.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnCopyMe.Location = New System.Drawing.Point(240, 16)
            Me.ibtnCopyMe.Name = "ibtnCopyMe"
            Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
            Me.ibtnCopyMe.TabIndex = 13
            Me.ibtnCopyMe.TabStop = False
            Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkClosed
            '
            Me.chkClosed.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkClosed.Location = New System.Drawing.Point(472, 16)
            Me.chkClosed.Name = "chkClosed"
            Me.chkClosed.Size = New System.Drawing.Size(80, 21)
            Me.chkClosed.TabIndex = 12
            Me.chkClosed.Text = "�Դ PO"
            Me.chkClosed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'lblPercent
            '
            Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPercent.BackColor = System.Drawing.Color.Transparent
            Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent.Location = New System.Drawing.Point(853, 597)
            Me.lblPercent.Name = "lblPercent"
            Me.lblPercent.Size = New System.Drawing.Size(16, 18)
            Me.lblPercent.TabIndex = 46
            Me.lblPercent.Text = "%"
            Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'POPanelView
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "POPanelView"
            Me.Size = New System.Drawing.Size(891, 712)
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbDetail.ResumeLayout(False)
            Me.grbDetail.PerformLayout()
            CType(Me.imAttachment, System.ComponentModel.ISupportInitialize).EndInit()
            Me.FixedGroupBox1.ResumeLayout(False)
            Me.FixedGroupBox1.PerformLayout()
            Me.grbRetention.ResumeLayout(False)
            Me.grbRetention.PerformLayout()
            Me.ResumeLayout(False)

        End Sub
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
#End Region

#Region "Members"
    Private m_entity As PO
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    Private dummyCC As New CostCenter
    Private dummyEmployee As New Employee

    Private m_treeManager2 As TreeManager
    Private m_wbsdInitialized As Boolean

    Private m_enableState As Hashtable
    Private m_tableStyleEnable As Hashtable
    Private m_checkedCanPrint As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      Dim rs As ResourceService = CType(ServiceManager.Services.GetService(GetType(ResourceService)), ResourceService)
      Me.ibtnCopyMe.ThemedImage = rs.GetBitmap("Icons.16x16.Copy")
      Me.imAttachment.Image = My.Resources.Attachment_24

      SaveEnableState()

      Dim dt As TreeTable = PO.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf POItemDelete


      m_checkedCanPrint = New Hashtable

      EventWiring()
    End Sub
    Private Sub SaveEnableState()
      m_enableState = New Hashtable
      For Each ctrl As Control In Me.grbDetail.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
      For Each ctrl As Control In Me.Controls
        m_enableState.Add(ctrl, ctrl.Enabled)
      Next
    End Sub
#End Region

#Region "Style"
    Dim m_wbsColl As WBSCollection
    Dim m_mrkColl As MarkupCollection
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "PO"
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

      'PO Items
      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "poi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "poi_linenumber"

      Dim csBarrier As New DataGridBarrierColumn
      csBarrier.MappingName = "Barrier"
      csBarrier.HeaderText = ""
      csBarrier.NullText = ""
      csBarrier.ReadOnly = True

      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("poi_entityType" _
      , CodeDescription.GetCodeList("stocki_enitytype") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.TypeHeaderText}")
      csType.NullText = String.Empty

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.CodeHeaderText}")
      csCode.NullText = ""
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      Dim csName As New TreeTextColumn
      csName.MappingName = "poi_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "Description"
      'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
      'csDescription.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.TextBox.Name = "Unit"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csUnitButton As New DataGridButtonColumn
      csUnitButton.MappingName = "UnitButton"
      csUnitButton.HeaderText = ""
      csUnitButton.NullText = ""
      AddHandler csUnitButton.Click, AddressOf ButtonClicked


      Dim csQty As New TreeTextColumn
      csQty.MappingName = "poi_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "Qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

      Dim csOriginQty As New TreeTextColumn
      csOriginQty.MappingName = "poi_originqty"
      csOriginQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.OriginQtyHeaderText}")
      csOriginQty.NullText = ""
      csOriginQty.DataAlignment = HorizontalAlignment.Right
      csOriginQty.Format = "#,###.##"
      csOriginQty.ReadOnly = True
      csOriginQty.TextBox.Name = "OriginQty"

      Dim csReceivedQty As New TreeTextColumn
      csReceivedQty.MappingName = "ReceivedQty"
      csReceivedQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.ReceivedQtyHeaderText}")
      csReceivedQty.NullText = ""
      csReceivedQty.DataAlignment = HorizontalAlignment.Right
      csReceivedQty.Format = "#,###.##"
      csReceivedQty.ReadOnly = True

      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "poi_unitprice"
      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.poi_unitpriceHeaderText}")
      csUnitPRice.NullText = ""
      csUnitPRice.DataAlignment = HorizontalAlignment.Right
      csUnitPRice.TextBox.Name = "poi_unitprice"
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csDiscount As New TreeTextColumn
      csDiscount.MappingName = "poi_discrate"
      csDiscount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.DiscountHeaderText}")
      csDiscount.NullText = ""
      csDiscount.TextBox.Name = "poi_discrate"
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.DataAlignment = HorizontalAlignment.Right
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "poi_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "poi_note"


      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "poi_unvatable"
      csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.UnVatableHeaderText}")
      csVatable.Width = 100
      csVatable.InvisibleWhenUnspcified = True


      dst.GridColumnStyles.Add(csPRItemCode)
      dst.GridColumnStyles.Add(csPRItemName)
      dst.GridColumnStyles.Add(csPRItemUnit)
      'dst.GridColumnStyles.Add(csPRItemQty)
      'dst.GridColumnStyles.Add(csPRItemRemainingQty)

      'dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csBarrier)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csOriginQty)
      dst.GridColumnStyles.Add(csReceivedQty)
      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csDiscount)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csNote)
      dst.GridColumnStyles.Add(csVatable)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 6 Then
        Me.ItemButtonClick(e)
      Else
        Me.UnitButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentTagItem() As POItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is POItem Then
          Return Nothing
        End If
        Return CType(row.Tag, POItem)
      End Get
    End Property
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      'm_entity.SetRealGross()
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
      Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem

      'If tick checkbox that not in the current hilight row
      If e.Column.ColumnName.ToLower = "poi_unvatable" Then
        Me.m_treeManager.SelectedRow = e.Row
        doc = Me.m_entity.ItemCollection.CurrentItem
      End If

      If doc Is Nothing Then
        doc = New POItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc

      End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "poi_itemname"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.EntityName = CStr(e.ProposedValue)
          Case "unit"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            doc.Unit = myUnit
          Case "poi_originqty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.OriginQty = value
          Case "poi_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
                        Dim value As Decimal = 0       'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
                        If Not e.ProposedValue = "" Then
                            If IsNumeric(e.ProposedValue) Then
                                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
                            End If
                        End If
                        If Not doc.Pritem Is Nothing Then
                            Try
                                Dim percentPoOverPr As Object = Configuration.GetConfig("PercentPoOverPr")
                                If Not percentPoOverPr Is Nothing Then
                                    If CStr(percentPoOverPr).Length > 0 Then
                                        Dim percent As Decimal = CDec(TextParser.Evaluate(CStr(percentPoOverPr)))
                                        Dim tolerance As Decimal = (percent * doc.Pritem.Qty) / 100
                                        'MessageBox.Show(String.Format("{0}-({1}-{2}+{3})", value, doc.POitem.Qty, Math.Min(doc.POitem.ReceivedQty, doc.POitem.Qty), Math.Min(doc.POitem.ReceivedQty, doc.Qty)))
                                        If Configuration.Compare(tolerance, value - (doc.Pritem.Qty - Math.Min(doc.Pritem.OrderedQty, doc.Pritem.Qty) + Math.Min(doc.Pritem.OrderedQty, doc.Qty)), DigitConfig.Qty) < 0 Then
                                            msgServ.ShowMessageFormatted("${res:Global.Error.PercentPoOverPrExceeded}", New String() {Configuration.FormatToString(value, DigitConfig.Qty), Configuration.FormatToString(doc.Pritem.Qty, DigitConfig.Qty), Configuration.FormatToString(percent, 2)})
                                            value = Math.Min(value, doc.Pritem.Qty - Math.Min(doc.Pritem.OrderedQty, doc.Pritem.Qty) + Math.Min(doc.Pritem.OrderedQty, doc.Qty) + tolerance)
                                        End If
                                    End If
                                End If
                            Catch ex As Exception

                            End Try
                        End If
            doc.Qty = value
          Case "poi_entitytype"
            Dim value As ItemType
            If IsNumeric(e.ProposedValue) Then
              value = New ItemType(CInt(e.ProposedValue))
            End If
            doc.ItemType = value
          Case "poi_unitprice"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.UnitPrice = value
          Case "poi_discrate"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Discount = New Discount(e.ProposedValue.ToString)
          Case "poi_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
          Case "poi_unvatable"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = False
            End If
            doc.UnVatable = CBool(e.ProposedValue)
        End Select
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub POItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "CheckPJMModule"
    Private m_ApproveDocModule As New PJMModule("approvedoc")
#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      '�������Դ͹��ѵ��͡��� ����͹����
      If Not CBool(Configuration.GetConfig("ApprovePO")) Then
        Me.btnApprove.Visible = False
      Else
        Me.btnApprove.Visible = True
      End If

      '�ҡ���͹��ѵ��͡���
      '------------------ ���Է�ԡ���ͧ��繻����Դ�͡��� ---------------------
      CType(Me.Entity, PO).Closed = Me.chkClosed.Checked
      If CType(Me.Entity, PO).Closed Then
        CheckCancelClosed()
      Else
        CheckClosed()
      End If
      If CBool(Configuration.GetConfig("ApprovePO")) Then
        '�������͹��ѵ�Ẻ���� PJMModule
        If m_ApproveDocModule.Activated Then
          'Dim mySService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
          'Dim ApprovalDocLevelColl As New ApprovalDocLevelCollection(mySService.CurrentUser) '�дѺ�Է�����м����
          Dim ApproveDocColl As New ApproveDocCollection(Me.m_entity) '�дѺ�Է�Է����ӡ�� approve
          If ApproveDocColl.MaxLevel > 0 Then
            '(ApprovalDocLevelColl.GetItem(m_entity.EntityId).Level < ApproveDocColl.MaxLevel) OrElse _
            '(Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id) Then
            For Each ctrl As Control In grbDetail.Controls
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso Not ctrl.Name = "chkClosed" Then
                ctrl.Enabled = False
              End If
            Next
            tgItem.Enabled = True
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = True
            Next
            CheckFinalLine()
            Return
          Else
            For Each ctrl As Control In grbDetail.Controls
              ctrl.Enabled = CBool(m_enableState(ctrl))
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If
        Else
          '�������͹��ѵ�Ẻ���
          If Not Me.m_entity.ApproveDate.Equals(Date.MinValue) AndAlso Not Me.m_entity.ApprovePerson.Id = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id Then
            For Each ctrl As Control In grbDetail.Controls
              If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso Not ctrl.Name = "chkClosed" Then
                ctrl.Enabled = False
              End If
            Next
            tgItem.Enabled = True
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = True
            Next
            CheckFinalLine()
            Return
          Else
            For Each ctrl As Control In grbDetail.Controls
              ctrl.Enabled = CBool(m_enableState(ctrl))
            Next
            For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
              colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
            Next
          End If
        End If
      End If


      '�ҡ Status �ͧ�͡����ͧ
      If Me.m_entity.Status.Value = 0 OrElse m_entityRefed = 1 OrElse Me.m_entity.Closed Then
        For Each ctrl As Control In grbDetail.Controls
          If Not ctrl.Name = "btnApprove" AndAlso Not ctrl.Name = "ibtnCopyMe" AndAlso Not ctrl.Name = "chkClosed" Then
            ctrl.Enabled = False
          ElseIf ctrl.Name = "chkClosed" Then
            If Me.m_entity.Status.Value = 0 Then
              chkClosed.Enabled = False
            End If
          End If
        Next
        tgItem.Enabled = True
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = True
        Next
      Else
        For Each ctrl As Control In grbDetail.Controls
          ctrl.Enabled = CBool(m_enableState(ctrl))
        Next
        For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
          colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
        Next
      End If

      Me.chkClosed.Enabled = True
      CheckWBSRight()

      CheckFinalLine()

    End Sub
    Private Sub CheckFinalLine()
      Me.ibtnCopyMe.Enabled = True
      Me.btnApprove.Enabled = True
      '---Check Attachment ----
      If CType(Configuration.GetConfig("UseAttachment"), Boolean) AndAlso Me.m_entity.hasAttachment Then
        Me.imAttachment.Visible = True
        Me.imAttachment.Enabled = True
      Else
        Me.imAttachment.Visible = False
      End If
    End Sub
    Private Sub CheckClosed()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(364)            '��Ǩ�ͺ �Է�ԡ�ûԴPO
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)           '����¹����Ţ�� ���� 01 5��� �����ҵ���Ţ
      checkString = BinaryHelper.RevertString(checkString)
      If CBool(checkString.Substring(0, 1)) Then
        Me.chkClosed.Visible = True
      Else
        Me.chkClosed.Visible = False
      End If
    End Sub
    Private Sub CheckCancelClosed()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(373)            '��Ǩ�ͺ �Է�ԡ�ûԴPO
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)           '����¹����Ţ�� ���� 01 5��� �����ҵ���Ţ
      checkString = BinaryHelper.RevertString(checkString)
      If CBool(checkString.Substring(0, 1)) Then
        Me.chkClosed.Visible = True
      Else
        Me.chkClosed.Visible = False
      End If
    End Sub
    Private Sub CheckWBSRight()
      Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
      Dim level As Integer = secSrv.GetAccess(256)
      Dim checkString As String = BinaryHelper.DecToBin(level, 5)
      checkString = BinaryHelper.RevertString(checkString)
      'If Not CBool(checkString.Substring(0, 1)) Then
      '  '�������
      '  Me.lblWBS.Visible = False
      '  Me.tgWBS.Visible = False
      '  Me.ibtnAddWBS.Visible = False
      '  Me.ibtnDelWBS.Visible = False
      'ElseIf Not CBool(checkString.Substring(1, 1)) Then
      '  '������
      '  Me.lblWBS.Visible = True
      '  Me.tgWBS.Visible = True
      '  Me.ibtnAddWBS.Visible = True
      '  Me.ibtnDelWBS.Visible = True

      '  Me.tgWBS.Enabled = False
      '  Me.ibtnAddWBS.Enabled = False
      '  Me.ibtnDelWBS.Enabled = False
      'Else
      '  Me.lblWBS.Visible = True
      '  Me.tgWBS.Visible = True
      '  Me.ibtnAddWBS.Visible = True
      '  Me.ibtnDelWBS.Visible = True

      '  Me.tgWBS.Enabled = True
      '  Me.ibtnAddWBS.Enabled = True
      '  Me.ibtnDelWBS.Enabled = True
      'End If
    End Sub
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
      Me.dtpReceivingDate.Value = Now
      cmbTaxType.SelectedIndex = 1
    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblCode}")

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblGross}")

      Me.lblReceivingDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblReceivingDate}")
      Me.Validator.SetDisplayName(Me.txtReceivingDate, StringHelper.GetRidOfAtEnd(Me.lblReceivingDate.Text, ":"))

      Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblDiscountAmount}")
      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblBeforeTax}")
      Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblTaxAmount}")
      Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblAfterTax}")
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblTaxType}")
      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblTaxRate}")

      Me.lblSupplier.Text = Me.StringParserService.Parse("${res:Global.SupplierText}")
      Me.Validator.SetDisplayName(Me.txtSupplierCode, StringHelper.GetRidOfAtEnd(Me.lblSupplier.Text, ":"))
      Me.Validator.ErrorProvider.SetIconPadding(Me.txtSupplierCode, -20)

      Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Global.DueDate}")
      Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblCreditPrd}")
      Me.lblNote.Text = Me.StringParserService.Parse("${res:Global.NoteText}")

      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.grbDetail}")
      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblItem}")
      Me.lblDay.Text = Me.StringParserService.Parse("${res:Global.DayText}")
      Me.lblPercent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblPercent}")
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblTaxBase}")

      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblCostCenter}")
      Me.lblRequestor.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblRequestor}")

      Me.grbRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.grbRetention}")
      Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblRetention}")
      Me.lblRetentionNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblRetentionNote}")

      Me.btnApprove.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.btnApprove}")
      Me.lblContact.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.lblContact}")
      'Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.chkClosed}")
      '仡�˹���ҧ��ҧ
    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtSupplierCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSupplierCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtReceivingDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpReceivingDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtCreditPrd.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty 'Todo: .... ���������ͻ����
      AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler cmbPOPlaceDeli.SelectedIndexChanged, AddressOf Me.ChangeProperty
      AddHandler cmbPOPlaceDeli.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCostCenterCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtCostCenterName.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSupplierName.Validated, AddressOf Me.ChangeProperty

      AddHandler txtRequestorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtRequestorCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtRetentionNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRetention.Validated, AddressOf Me.TextHandler
      AddHandler txtRetention.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealGross.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealGross.Validated, AddressOf Me.TextHandler

      AddHandler cmbContact.SelectedIndexChanged, AddressOf Me.ChangeProperty

      '==============CURRENCY=================================
      AddHandler txtRate.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRate.Validated, AddressOf Me.TextHandler
      AddHandler txtUnit1.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtUnit2.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtLanguage.TextChanged, AddressOf Me.ChangeProperty
      '==============CURRENCY=================================
    End Sub
    Private requestorCodeChanged As Boolean = False
    Private supplierCodeChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower
        Case "txtrequestorcode"
          requestorCodeChanged = True
        Case "txtcostcentercode"
          CCCodeChanged = True
        Case "txtsuppliercode"
          supplierCodeChanged = True

          '==============CURRENCY=================================
        Case "txtrate"
          Dim txt As String = Me.txtRate.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.Currency.Conversion = 0
          Else
            Try
              Me.m_entity.Currency.Conversion = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.Currency.Conversion = 0
            End Try
          End If
          Me.txtRate.Text = Configuration.FormatToString(Me.m_entity.Currency.Conversion, DigitConfig.Price)
          '==============CURRENCY=================================

        Case "txtretention"
          Dim txt As String = Me.txtRetention.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.Retention = 0
          Else
            Try
              Me.m_entity.Retention = Math.Min(CDec(TextParser.Evaluate(txt)), Me.m_entity.AfterTax)
            Catch ex As Exception
              Me.m_entity.Retention = 0
            End Try
          End If
          Me.txtRetention.Text = Configuration.FormatToString(Me.m_entity.Retention, DigitConfig.Price)
        Case "txtrealtaxbase"
          Dim txt As String = Me.txtRealTaxBase.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealTaxBase = 0
          Else
            Try
              Me.m_entity.RealTaxBase = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.RealTaxBase = 0
            End Try
          End If
          forceUpdateTaxAmount = True
          UpdateAmount(True)
        Case "txtrealgross"
          Dim txt As String = Me.txtRealGross.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealGross = 0
          Else
            Try
              Me.m_entity.RealGross = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.RealGross = 0
            End Try
          End If
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          UpdateAmount(True)
        Case "txtrealtaxamount"
          Dim txt As String = Me.txtRealTaxAmount.Text
          txt = txt.Replace(",", "")
          If txt.Length = 0 Then
            Me.m_entity.RealTaxAmount = 0
          Else
            Try
              Me.m_entity.RealTaxAmount = CDec(TextParser.Evaluate(txt))
            Catch ex As Exception
              Me.m_entity.RealTaxAmount = 0
            End Try
          End If
          UpdateAmount(True)
      End Select
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      'cmbCode.Items.Clear()
      'cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_entity.Code
      txtCreditPrd.Text = m_entity.CreditPeriod.ToString
      Me.m_oldCode = Me.m_entity.Code
      oldCCId = Me.m_entity.CostCenter.Id
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()
      Me.InitialCombo()

      Me.chkClosed.Checked = Me.m_entity.Closed

      If Me.m_entity.Closed Then
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.chkClosedCancel}")
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.chkClosed}")
      End If

      Me.SetColumnOriginQty()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)
      dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)

      txtReceivingDate.Text = MinDateToNull(Me.m_entity.ReceivingDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpReceivingDate.Value = MinDateToNow(Me.m_entity.ReceivingDate)

      txtSupplierCode.Text = m_entity.Supplier.Code
      txtSupplierName.Text = m_entity.Supplier.Name
      txtNote.Text = m_entity.Note

      txtCostCenterCode.Text = m_entity.CostCenter.Code
      txtCostCenterName.Text = m_entity.CostCenter.Name

      txtRequestorCode.Text = m_entity.Requestor.Code
      txtRequestorName.Text = m_entity.Requestor.Name

      txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)
      txtRetentionNote.Text = m_entity.RetentionNote

      '==============CURRENCY=================================
      txtRate.Text = Configuration.FormatToString(Me.m_entity.Currency.Conversion, DigitConfig.Price)
      txtLanguage.Text = Me.m_entity.Currency.Language
      txtUnit1.Text = Me.m_entity.Currency.Unit
      txtUnit2.Text = Me.m_entity.Currency.SubUnit
      '==============CURRENCY=================================

      If Not m_entity.Supplier Is Nothing Then
        For itemIndex As Integer = 0 To Me.cmbContact.Items.Count - 1
          If Me.m_entity.Contact = Me.cmbContact.Items(itemIndex) Then
            Me.cmbContact.SelectedIndex = itemIndex
          End If
        Next
      End If

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next

      SetcmbPOPlace()
      cmbPOPlaceDeli.Text = m_entity.PlaceOfDelivery
      'If m_entity.PlaceOfDelivery.Length > 0 Then
      '  Dim deliAddress As String
      '  For i As Integer = 0 To cmbPOPlaceDeli.Items.Count - 1
      '    deliAddress = cmbPOPlaceDeli.Items(i)
      '    If m_entity.PlaceOfDelivery = deliAddress Then
      '      cmbPOPlaceDeli.SelectedIndex = i
      '      Exit For
      '    End If
      '  Next
      'End If

      RefreshDocs()
      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub SetColumnOriginQty()
      For Each colStyle As DataGridColumnStyle In Me.tgItem.TableStyles(0).GridColumnStyles
        If colStyle.MappingName.ToLower = "poi_originqty" Then
          If Not Me.m_entity.Closed Then
            colStyle.Width = 0
          Else
            colStyle.Width = 80
          End If
        End If
      Next
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount(True)
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Or e.Name = "QtyChanged" Then
        If e.Name = "QtyChanged" Then
          Me.UpdateAmount(True)
        End If
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub
    Private m_dateSetting As Boolean = False
    Private CCCodeChanged As Boolean = False
    Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    Private CCCodeBlankFlag As Boolean = False
    Private Sub SetCCCodeBlankFlag()
      If Me.txtCostCenterCode.Text.Length = 0 Then
        CCCodeBlankFlag = True
      Else
        CCCodeBlankFlag = False
      End If
    End Sub
    Private oldSupId As Integer
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        '==============CURRENCY=================================
        Case "txtrate"
          dirtyFlag = True
        Case "txtlanguage"
          Me.m_entity.Currency.Language = txtLanguage.Text
          dirtyFlag = True
        Case "txtunit1"
          Me.m_entity.Currency.Unit = txtUnit1.Text
          dirtyFlag = True
        Case "txtunit2"
          Me.m_entity.Currency.SubUnit = txtUnit2.Text
          dirtyFlag = True
          '==============CURRENCY=================================

        Case "txtrealtaxbase"
          dirtyFlag = True
        Case "txtrealtaxamount"
          dirtyFlag = True
        Case "txtrealgross"
          dirtyFlag = True
        Case "cmbcode"
          If m_entity.AutoGen Then
            '���� AutoCode
            If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
              Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
              Me.m_entity.Code = m_entity.AutoCodeFormat.Format
            End If
          Else
            Me.m_entity.Code = cmbCode.Text
          End If
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtsuppliercode"
          If supplierCodeChanged Then
            supplierCodeChanged = False
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim oldSupplier As Supplier = Me.m_entity.Supplier
            If Me.txtSupplierCode.TextLength <> 0 Then
              Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
              Me.txtCreditPrd.Text = Me.m_entity.Supplier.CreditPeriod
            Else
              Me.m_entity.Supplier = New Supplier
              txtSupplierName.Text = ""
              Me.txtCreditPrd.Text = Me.m_entity.Supplier.CreditPeriod
            End If
            InitialCombo()
            If Me.cmbContact.Items.Count > 0 Then
              Me.m_entity.Contact = Me.cmbContact.Text
            End If
            Try
              If oldSupId <> Me.m_entity.Supplier.Id Then
                If oldSupId = 0 OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeSupplier}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeSupplier}") Then
                  oldSupId = Me.m_entity.Supplier.Id
                  dirtyFlag = True
                Else
                  dirtyFlag = False
                  Me.m_entity.Supplier = oldSupplier
                  Me.txtSupplierCode.Text = oldSupplier.Code
                  Me.txtSupplierName.Text = oldSupplier.Name
                  Me.txtCreditPrd.Text = Me.m_entity.Supplier.CreditPeriod
                  supplierCodeChanged = False
                End If
              End If
            Catch ex As Exception

            End Try
          End If
        Case "txtsuppliername"
          Dim txt As String = txtSupplierName.Text
          Dim reg As New Regex("\[(.*)\]")
          If reg.IsMatch(txt) Then
            Dim sup As Supplier
            Try
              sup = New Supplier(reg.Match(txt).Groups(1).Value)
            Catch ex As Exception
              sup = New Supplier
            End Try
            Dim oldSupplier As Supplier = Me.m_entity.Supplier
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Me.m_entity.Supplier = sup
            If oldSupId <> Me.m_entity.Supplier.Id Then
              If oldSupId = 0 OrElse msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeSupplier}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeSupplier}") Then
                oldSupId = Me.m_entity.Supplier.Id
                dirtyFlag = True
              Else
                dirtyFlag = False
                Me.m_entity.Supplier = oldSupplier
              End If
            End If
          End If
          m_isInitialized = False
          Me.txtSupplierCode.Text = Me.m_entity.Supplier.Code
          Me.txtSupplierName.Text = Me.m_entity.Supplier.Name
          Me.txtCreditPrd.Text = Me.m_entity.Supplier.CreditPeriod
          InitialCombo()
          If Me.cmbContact.Items.Count > 0 Then
            Me.m_entity.Contact = Me.cmbContact.Text
          End If
          m_isInitialized = True
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
              Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
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
              Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "dtpreceivingdate"
          If Not Me.m_entity.ReceivingDate.Equals(dtpReceivingDate.Value) Then
            If Not m_dateSetting Then
              Me.txtReceivingDate.Text = MinDateToNull(dtpReceivingDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.ReceivingDate = dtpReceivingDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtreceivingdate"
          m_dateSetting = True
          If Not Me.txtReceivingDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtReceivingDate) = "" Then
            Dim theDate As Date = CDate(Me.txtReceivingDate.Text)
            If Not Me.m_entity.ReceivingDate.Equals(theDate) Then
              dtpReceivingDate.Value = theDate
              Me.m_entity.ReceivingDate = dtpReceivingDate.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpReceivingDate.Value = Date.Now
            Me.m_entity.ReceivingDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False
        Case "txtcreditprd"
          If IsNumeric(txtCreditPrd.Text) Then
            Me.m_entity.CreditPeriod = CInt(txtCreditPrd.Text)
            Me.dtpDueDate.Value = Me.m_entity.DueDate
          End If
          dirtyFlag = True
        Case "txtretentionnote"
          Me.m_entity.RetentionNote = txtRetentionNote.Text
          dirtyFlag = True
        Case "txtretention"
          dirtyFlag = True
        Case "txttaxbase"
          'Todo
        Case "txtdiscountrate"
          Me.m_entity.Discount.Rate = txtDiscountRate.Text
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount(True)
          dirtyFlag = True
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Me.m_entity.TaxType.Value = item.Id
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount(True)
          dirtyFlag = True
        Case "cmbpoplacedeli"
          Me.m_entity.PlaceOfDelivery = cmbPOPlaceDeli.Text
          dirtyFlag = True
        Case "txtrequestorcode"
          If requestorCodeChanged Then
            dirtyFlag = RunningEmployee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_entity.Requestor)
            requestorCodeChanged = False
          End If
        Case "cmbcontact"
          Me.m_entity.Contact = cmbContact.Text
          dirtyFlag = True
        Case "txtcostcentercode"
          If CCCodeChanged Then
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim config As Boolean = CBool(Configuration.GetConfig("POClearAllocationIfChangeCostCenter"))
            Dim msgChangeCC As String = ""
            If config Then
              msgChangeCC = "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}"
            Else
              msgChangeCC = "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCCNotChangeAllocate}"
            End If
            If msgServ.AskQuestion(msgChangeCC, "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
              If Me.txtCostCenterCode.TextLength <> 0 Then
                dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                If dirtyFlag Then
                  UpdateDestAdmin()
                End If
              Else
                Me.m_entity.CostCenter = New CostCenter
                txtCostCenterName.Text = ""
              End If
              Try
                If oldCCId <> Me.m_entity.CostCenter.Id Then
                  Me.WorkbenchWindow.ViewContent.IsDirty = True
                  oldCCId = Me.m_entity.CostCenter.Id
                  ChangeCC()
                  SetcmbPOPlace()
                End If
              Catch ex As Exception

              End Try
              CCCodeChanged = False
            Else
              Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
              CCCodeChanged = False
            End If
          End If
        Case "txtcostcentername"
          Dim txt As String = txtCostCenterName.Text
          Dim reg As New Regex("\[(.*)\]")
          If reg.IsMatch(txt) Then
            Dim cc As CostCenter
            Try
              cc = New CostCenter(reg.Match(txt).Groups(1).Value)
              Me.m_entity.CostCenter = cc
              dirtyFlag = True
            Catch ex As Exception
              cc = New CostCenter
            End Try
            If dirtyFlag Then
              UpdateDestAdmin()
            End If
          End If
          m_isInitialized = False
          Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
          Me.txtCostCenterName.Text = Me.m_entity.CostCenter.Name
          SetcmbPOPlace()
          m_isInitialized = True
          'Case "txtcostcentercode"
          'If toCCCodeChanged Then
          'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          'If Not CCCodeBlankFlag Then
          'If Me.txtCostCenterCode.Text.ToLower <> Me.m_entity.CostCenter.Code.ToLower Then
          'If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
          'If Me.txtCostCenterCode.TextLength <> 0 Then
          'dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          'If dirtyFlag Then
          'UpdateDestAdmin()
          'End If
          'Else
          'Me.m_entity.CostCenter = New CostCenter
          'txtCostCenterName.Text = ""
          'End If
          'Try
          'If oldCCId <> Me.m_entity.CostCenter.Id Then
          'Me.WorkbenchWindow.ViewContent.IsDirty = True
          'oldCCId = Me.m_entity.CostCenter.Id
          'ChangeCC()
          'End If
          'Catch ex As Exception

          'End Try
          'toCCCodeChanged = False
          'Else
          'Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
          'toCCCodeChanged = False
          'End If
          'End If
          'Else
          'If Me.txtCostCenterCode.TextLength <> 0 Then
          'dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          'If dirtyFlag Then
          'If Me.txtRequestorName.TextLength = 0 Then
          'UpdateDestAdmin()
          'End If
          'End If
          'Else
          'Me.m_entity.CostCenter = New CostCenter
          'txtCostCenterName.Text = ""
          'End If
          'Try
          'If oldCCId <> Me.m_entity.CostCenter.Id Then
          'Me.WorkbenchWindow.ViewContent.IsDirty = True
          'oldCCId = Me.m_entity.CostCenter.Id
          'ChangeCC()
          'End If
          'Catch ex As Exception

          'End Try
          'toCCCodeChanged = False
          'End If
          'End If
          'If toCCCodeChanged Then
          'dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          'If Me.txtRequestorName.TextLength = 0 Then
          'UpdateDestAdmin()
          'End If
          'toCCCodeChanged = False
          'End If

      End Select
      Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
      CheckFormEnable()
      SetCCCodeBlankFlag()
    End Sub
    Private Sub ibtnResetGross_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetGross.Click
      If Me.m_entity.RealGross <> Me.m_entity.Gross Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealGross = Me.m_entity.Gross
      UpdateAmount(True)
    End Sub
    Private Sub ibtnResetTaxBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxBase.Click
      If Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
      UpdateAmount(True)
    End Sub
    Private Sub ibtnResetTaxAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxAmount.Click
      If Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
      UpdateAmount(True)
    End Sub
    Private Sub UpdateNoteFromPR()
      Try
        Me.m_entity.UpdateNoteFromPR()
      Catch ex As Exception
        '�������� error ���������ҡ����ͧ��з��ҹ
      End Try

      Me.txtNote.Text = Me.m_entity.Note
    End Sub
    Private forceUpdateTaxBase As Boolean = False
    Private forceUpdateGross As Boolean = False
    Private forceUpdateTaxAmount As Boolean = False
    Private Sub UpdateAmount(ByVal refresh As Boolean)
      m_isInitialized = False
      If refresh Then
        Me.m_entity.RefreshTaxBase()
      End If

      'HACK: forceUpdateGross ��ͧ�����ѹ�á�Ш��
      If forceUpdateGross OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
        Me.m_entity.RealGross = Me.m_entity.Gross
        forceUpdateGross = False
      End If
      If forceUpdateTaxBase OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase) Then
        Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
        forceUpdateTaxBase = False
      End If
      If forceUpdateTaxAmount OrElse (Not Me.m_entity.Originated AndAlso Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount) Then
        Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
        forceUpdateTaxAmount = False
      End If

      txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
      txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
      txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
      txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
      txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
      txtDiscountRate.Text = m_entity.Discount.Rate
      txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
      txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)

      txtRealGross.Text = Configuration.FormatToString(m_entity.RealGross, DigitConfig.Price)
      txtRealTaxAmount.Text = Configuration.FormatToString(m_entity.RealTaxAmount, DigitConfig.Price)
      txtRealTaxBase.Text = Configuration.FormatToString(m_entity.RealTaxBase, DigitConfig.Price)

      m_isInitialized = True
      'RefreshWBS()
    End Sub
    Private Sub InitialCombo()
      If Not m_entity.Supplier Is Nothing Then
        Me.cmbContact.Items.Clear()
        If Not Me.m_entity.Supplier.Contact Is Nothing Then
          Me.cmbContact.Items.Add(Me.m_entity.Supplier.Contact)
        End If
        For Each citem As SupplierContact In Me.m_entity.Supplier.ContactCollection
          If Not citem Is Nothing Then
            If Not citem.Name Is Nothing AndAlso citem.Name.Length > 0 Then
              Me.cmbContact.Items.Add(citem.Name)
            End If
          End If
        Next
      End If
      If Me.cmbContact.Items.Count > 0 Then
        Me.cmbContact.SelectedIndex = 0
      End If
    End Sub
    Public Sub SetStatus()
      MyBase.SetStatusBarMessage()
    End Sub
    Private m_entityRefed As Integer = -1
    Public Overrides Property Entity() As BusinessLogic.ISimpleEntity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        If Not m_entity Is Nothing Then
          RemoveHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
          Me.m_entity = Nothing
        End If
        Me.m_entity = CType(Value, PO)
        If Me.m_entity.IsReferenced Then
          m_entityRefed = 1
        Else
          m_entityRefed = 0
        End If
        'Hack:
        Me.m_entity.OnTabPageTextChanged(m_entity, EventArgs.Empty)
        AddHandler m_entity.AttachIsChanges, AddressOf CheckFormEnable
        UpdateEntityProperties()
      End Set
    End Property
    Public Overrides Sub Initialize()
      SetTaxTypeComboBox()
      RefreshAutoComplete(10)
      RefreshAutoComplete(87)
    End Sub
    ' 
    Private Sub SetTaxTypeComboBox()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
      cmbTaxType.SelectedIndex = 1
    End Sub
    Private Sub SetcmbPOPlace()
      cmbPOPlaceDeli.Items.Clear()
      For Each address As String In Me.m_entity.DeliveryAddressCollection.Values
        If Not address Is Nothing Then
          cmbPOPlaceDeli.Items.Add(address)
        End If
      Next
      If cmbPOPlaceDeli.Items.Count > 0 Then
        cmbPOPlaceDeli.SelectedIndex = 0
      End If
      Dim stringaddr As String = ""
      If Not Me.m_entity Is Nothing Then
        If Not Me.m_entity.CostCenter Is Nothing AndAlso Me.m_entity.CostCenter.Originated Then
          For i As Integer = 0 To cmbPOPlaceDeli.Items.Count - 1
            stringaddr = cmbPOPlaceDeli.Items(i).ToString
            If String.Equals(stringaddr, Me.m_entity.CostCenter.Address) Then
              cmbPOPlaceDeli.SelectedIndex = i
              Exit For
            End If
          Next
        End If
      End If
    End Sub
#End Region

#Region "Event Handler"
    Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim view As Integer = 6
      Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      If wsdColl.GetSumPercent >= 100 Then
        msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
      ElseIf doc.ItemType.Value = 160 Or doc.ItemType.Value = 162 Then
        msgServ.ShowMessage("${res:Global.Error.NoteCannotHaveWBS}")
      Else
        Dim wbsd As New WBSDistribute
        wbsd.CostCenter = Me.m_entity.CostCenter
        wbsd.Percent = 100 - wsdColl.GetSumPercent
        wsdColl.Add(wbsd)
      End If
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view)
      m_wbsdInitialized = True
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim dt As TreeTable = Me.m_treeManager2.Treetable
      dt.Clear()
      Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      If wsdColl.Count > 0 Then
        wsdColl.Remove(wsdColl.Count - 1)
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Dim view As Integer = 6
      m_wbsdInitialized = False
      wsdColl.Populate(dt, doc, view)
      m_wbsdInitialized = True
    End Sub
    Private currentY As Integer
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      If tgItem.CurrentRowIndex <> currentY Then
        Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
        'RefreshWBS()
        currentY = tgItem.CurrentRowIndex
      End If
    End Sub
    'Private Sub RefreshWBS()
    '  Dim dt As TreeTable = Me.m_treeManager2.Treetable
    '  dt.Clear()
    '  Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
    '  If Me.m_entity.ItemCollection.CurrentItem Is Nothing Then
    '    Return
    '  End If
    '  Dim item As POItem = Me.m_entity.ItemCollection.CurrentItem
    '  Dim wsdColl As WBSDistributeCollection = item.WBSDistributeCollection
    '  Dim view As Integer = 6
    '  m_wbsdInitialized = False
    '  wsdColl.Populate(dt, item, view)
    '  m_wbsdInitialized = True
    'End Sub
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList
        Dim currentUserId As Integer = Me.SecurityService.CurrentUser.Id
        BusinessLogic.Entity.NewPopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId, currentUserId)
        If Me.m_entity.Code Is Nothing OrElse Me.m_entity.Code.Length = 0 Then
          If Me.cmbCode.Items.Count > 0 Then
            Me.m_entity.Code = CType(Me.cmbCode.Items(0), AutoCodeFormat).Format
            Me.cmbCode.SelectedIndex = 0
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.Items(0), AutoCodeFormat)
          End If
        Else
          Me.cmbCode.SelectedIndex = Me.cmbCode.FindStringExact(Me.m_entity.Code)
          If TypeOf Me.cmbCode.SelectedItem Is AutoCodeFormat Then
            Me.m_entity.AutoCodeFormat = CType(Me.cmbCode.SelectedItem, AutoCodeFormat)
          End If
        End If
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New POItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
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
    Private m_targetType As Integer
    Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
      m_targetType = -1
      If doc Is Nothing Then
        doc = New POItem
        doc.ItemType = New ItemType(0)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      If doc.ItemType.Value = 19 Or doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
        m_targetType = doc.ItemType.Value
        Dim entities(2) As ISimpleEntity
        entities(0) = New LCIItem
        entities(1) = New LCIForList
        entities(2) = New Tool
        Dim activeIndex As Integer = -1
        If Not doc.ItemType Is Nothing Then
          If doc.ItemType.Value = 19 Then
            activeIndex = 2
          ElseIf doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
            activeIndex = 0
          End If
        End If
        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, activeIndex)
      End If
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      If tgItem.CurrentRowIndex = 0 Then
        'Hack
        tgItem.CurrentRowIndex = 1
      End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items, m_targetType)

      Dim config As Object = Configuration.GetConfig("GetTopMostPRReceiveDate")
      If CBool(config) Then
        Dim dd As Nullable(Of Date) = Me.m_entity.ItemCollection.GetTopMostPRReceiveDateFromPoitemColl
        If dd.HasValue Then
          Me.m_entity.ReceivingDate = dd
        End If
      Else
        Dim dd As Nullable(Of Date) = Me.m_entity.ItemCollection.GetLessPRReceiveDateFromPoitemColl
        If dd.HasValue Then
          Me.m_entity.ReceivingDate = dd
        End If
      End If
      Me.txtReceivingDate.Text = Me.m_entity.ReceivingDate.ToShortDateString
      tgItem.CurrentRowIndex = index
      Dim cc As CostCenter = Me.m_entity.GetCCFromPR
      If Not cc Is Nothing AndAlso cc.Id <> Me.m_entity.CostCenter.Id Then
        Me.SetCostCenterDialog(cc)
      End If

      '==============CURRENCY=================================
      Dim cu As Currency = Me.m_entity.GetCurrencyFromPR
      If Not cu Is Nothing AndAlso Not Me.m_entity.Currency.Equals(cu) Then
        Me.m_entity.Currency = cu.Clone
      End If
      '==============CURRENCY=================================

      SetcmbPOPlace()
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      UpdateNoteFromPR()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      dirtyFlag = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        Return
      End If
      If Not doc.Pritem Is Nothing Then
        Return
      End If
      Dim newItem As New BlankItem("")
      Dim theItem As New POItem
      theItem.Entity = newItem
      theItem.ItemType = New ItemType(0)
      theItem.Qty = 0
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc), theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
      'Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
      'If doc Is Nothing Then
      '  Return
      'End If
      'Me.m_entity.ItemCollection.Remove(doc)

      Dim rowsCount As Integer = 0
      For Each Obj As Object In Me.m_treeManager.SelectedRows
        If Not Obj Is Nothing Then
          rowsCount += 1
          Dim row As TreeRow = CType(Obj, TreeRow)
          If Not row Is Nothing Then
            If TypeOf row.Tag Is POItem Then
              Dim doc As POItem = CType(row.Tag, POItem)
              If Not doc Is Nothing Then
                Me.m_entity.ItemCollection.Remove(doc)
              End If
            End If
          End If
        End If
      Next

      If rowsCount.Equals(0) Then
        Dim doc As POItem = Me.m_entity.ItemCollection.CurrentItem
        If doc Is Nothing Then
          Return
        End If
        Me.m_entity.ItemCollection.Remove(doc)
      End If


      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
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

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageIcon() As String
      Get
        Return (New PO).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Requestor
    Private Sub btnRequestorEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestorEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyEmployee)
    End Sub
    Private Sub btnRequestorFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestorFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New RunningEmployee, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtRequestorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtRequestorCode, txtRequestorName, Me.m_entity.Requestor)
    End Sub
    ' Costcenter
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(dummyCC, AddressOf SetCostCenterDialog)
    End Sub
    Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
      If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        Dim config As Boolean = CBool(Configuration.GetConfig("POClearAllocationIfChangeCostCenter"))
        Dim msgChangeCC As String = ""
        If config Then
          msgChangeCC = "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}"
        Else
          msgChangeCC = "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCCNotChangeAllocate}"
        End If
        If msgServ.AskQuestion(msgChangeCC, "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
          'If Me.txtCostCenterCode.TextLength = 0 Then
          '    Me.m_entity.CostCenter = New CostCenter
          'End If
          Me.txtCostCenterCode.Text = e.Code
          dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          If dirtyFlag Then
            UpdateDestAdmin()
          End If
          Try
            If oldCCId <> Me.m_entity.CostCenter.Id Then
              Me.WorkbenchWindow.ViewContent.IsDirty = True
              oldCCId = Me.m_entity.CostCenter.Id
              ChangeCC()
              SetcmbPOPlace()
            End If
          Catch ex As Exception
          End Try
          CCCodeChanged = False
        Else
          Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
          CCCodeChanged = False
        End If
      ElseIf Me.txtCostCenterCode.Text.Length = 0 Then
        Me.txtCostCenterCode.Text = e.Code
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        If dirtyFlag Then
          UpdateDestAdmin()
        End If
      End If
      SetCCCodeBlankFlag()
    End Sub
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(dummyCC)
    End Sub
    Private Sub ChangeCC()
      Dim config As Boolean = CBool(Configuration.GetConfig("POClearAllocationIfChangeCostCenter"))
      If config Then
        For Each item As POItem In Me.m_entity.ItemCollection
          item.WBSDistributeCollection.Clear()
        Next
      End If

      'RefreshWBS()
      RefreshDocs()
    End Sub
    Private Sub UpdateDestAdmin()
      If Me.m_entity Is Nothing Then
        Return
      End If
      Dim flag As Boolean = Me.m_isInitialized
      Me.m_isInitialized = False
      Try
        Me.m_entity.Requestor = Me.m_entity.CostCenter.Admin
        Me.txtRequestorCode.Text = m_entity.Requestor.Code
        txtRequestorName.Text = m_entity.Requestor.Name
      Catch ex As Exception
      Finally
        Me.m_isInitialized = flag
      End Try
    End Sub
    Private Sub ibtnShowPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowPR.Click
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
      prNeedsStoreApproval = CBool(Configuration.GetConfig("PRNeedStoreApprove"))

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
      If Not Me.m_entity.CostCenter Is Nothing AndAlso Me.m_entity.CostCenter.Originated Then
        Entities.Add(Me.m_entity.CostCenter)
      End If

      Dim view As AbstractEntityPanelViewContent = New PRSelectionView(New PR, New BasketDialog, filters, Entities)
      dlg.Lists.Add(view)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
      myDialog.ShowDialog()
    End Sub
    Private Function GetPRExcludeList() As String
      Dim ret As String = ""
      For Each item As POItem In Me.m_entity.ItemCollection
        If Not item.Pritem Is Nothing Then
          ret &= "|" & item.Pritem.Pr.Id.ToString & ":" & item.Pritem.LineNumber.ToString & "|"
        End If
      Next
      Return ret
    End Function
    Private Sub ibtnGetFromBOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnGetFromBOQ.Click
      Dim arr As New ArrayList
      arr.Add(Me.m_entity.CostCenter)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BOQForSelection, AddressOf SetItems, arr)
    End Sub

    ' Supplier
    Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    End Sub
    Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
      Me.txtSupplierCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.m_entity.Supplier, True)
      m_isInitialized = False
      Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
      InitialCombo()
      If Me.cmbContact.Items.Count > 0 Then
        Me.m_entity.Contact = Me.cmbContact.Text
      End If
      m_isInitialized = True
    End Sub
    Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnApprove.Click
      'PJMModule
      Dim x As Form
      If m_ApproveDocModule.Activated Then
        x = New AdvanceApprovalCommentForm(Me.Entity)
      Else
        x = New ApprovalCommentForm(Me.Entity)
      End If
      x.ShowDialog()
      CheckFormEnable()
    End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Try
          Dim data As IDataObject = Clipboard.GetDataObject
          If data.GetDataPresent((New Supplier).FullClassName) Then
            If Not Me.ActiveControl Is Nothing Then
              Select Case Me.ActiveControl.Name.ToLower
                Case "txtsuppliercode", "txtsuppliername"
                  Return True
              End Select
            End If
          End If
        Catch ex As Exception
          Return False
        End Try

        Return True
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
      Try
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          Dim id As Integer = CInt(data.GetData((New Supplier).FullClassName))
          Dim entity As New Supplier(id)
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercode", "txtsuppliername"
                Me.SetSupplierDialog(entity)
            End Select
          End If
        End If
      Catch ex As Exception

      End Try
    End Sub
#End Region

#Region "IKeyReceiver"
    Public Overrides Function ProcessKey(ByVal keyPressed As System.Windows.Forms.Keys) As Boolean
      Try
        Select Case keyPressed
          Case Keys.Insert
            ibtnBlank_Click(Nothing, Nothing)
            Return True
          Case Keys.Delete
            If Me.tgItem.Focused Then
              ibtnDelRow_Click(Nothing, Nothing)
              Return True
            Else
              Return False
            End If
          Case Keys.Enter
            If TypeOf Me.ActiveControl Is TextBox Then
              If Me.ActiveControl.Name.ToLower.StartsWith("txt") Then
                If CType(Me.ActiveControl, TextBox).Multiline Then
                  Dim tmpIndx As Integer = CType(Me.ActiveControl, TextBox).SelectionStart
                  CType(Me.ActiveControl, TextBox).Text = CType(Me.ActiveControl, TextBox).Text.Insert(CType(Me.ActiveControl, TextBox).SelectionStart, vbCrLf)
                  CType(Me.ActiveControl, TextBox).SelectionStart = tmpIndx + 2
                  Return True
                End If
              End If
            End If
            SendKeys.Send("{tab}")
            Return True
          Case Else
            Return False
        End Select
      Catch ex As Exception
        Throw ex
      End Try
    End Function
#End Region

#Region "Grid Resizing"
    Private Sub tgItem_Resize(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tgItem.Resize
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

      'If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
      '    '�����ա 1 �� ����բ����Ũ��֧���ش����
      '    Me.m_treeManager.Treetable.Childs.Add()
      'End If

      Me.m_treeManager.Treetable.AcceptChanges()
      tgItem.CurrentRowIndex = Math.Max(0, index)
      Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
    End Sub
#End Region

    Private Sub ibtnCopyMe_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnCopyMe.Click
      Dim newEntity As ISimpleEntity = CType(Me.m_entity.GetNewEntity, ISimpleEntity)
      CType(Me.WorkbenchWindow.ViewContent, ISimpleListPanel).SelectedEntity = newEntity
      Me.Entity = newEntity
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

    Private Sub chkClosed_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkClosed.CheckedChanged
      If Not m_isInitialized Then
        Return
      End If
      Me.m_entity.Closed = Me.chkClosed.Checked
      If Me.m_entity.Closed Then
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.chkClosedCancel}")
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.POPanelView.chkClosed}")
      End If
      'Me.SetColumnOriginQty()
      'Me.RefreshDocs()
      'Me.RefreshWBS()
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub

#Region "Customization"
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Try
          If m_checkedCanPrint Is Nothing Then
            m_checkedCanPrint = New Hashtable
          End If

          If m_checkedCanPrint.Contains(m_entity.Id) Then

            Dim approveDocColl As ApproveDocCollection = CType(m_checkedCanPrint(m_entity.Id), ApproveDocCollection)
            Dim poNeedsApproval As Boolean = CBool(Configuration.GetConfig("POApproveBeforePrint"))
            If poNeedsApproval Then
              If Not approveDocColl.IsApproved Then
                Return False
              End If
            End If
          Else

            Dim approveDocColl As New ApproveDocCollection(m_entity)
            Dim poNeedsApproval As Boolean = CBool(Configuration.GetConfig("POApproveBeforePrint"))
            If poNeedsApproval Then
              If Not approveDocColl.IsApproved Then
                Return False
              End If
            End If

            m_checkedCanPrint(m_entity.Id) = approveDocColl
          End If
        Catch ex As Exception
        End Try
        Return MyBase.CanPrint
      End Get
    End Property
#End Region

    Public Sub RefreshAutoComplete(ByVal entityId As Integer) Implements ICanRefreshAutoComplete.RefreshAutoComplete
      Dim a As AutoCompleteStringCollection
      Select Case entityId
        Case 10
          Me.txtSupplierName.AutoCompleteSource = AutoCompleteSource.CustomSource
          Me.txtSupplierName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
          a = New AutoCompleteStringCollection
          For Each kv As KeyValuePair(Of String, String) In Supplier.InfoList
            a.Add(kv.Value & " [" & kv.Key & "]")
          Next
          For Each kv As KeyValuePair(Of String, String) In Supplier.InfoList
            a.Add("[" & kv.Key & "] " & kv.Value)
          Next
          Me.txtSupplierName.AutoCompleteCustomSource = a
        Case 87
          Me.txtCostCenterName.AutoCompleteSource = AutoCompleteSource.CustomSource
          Me.txtCostCenterName.AutoCompleteMode = AutoCompleteMode.SuggestAppend
          a = New AutoCompleteStringCollection
          For Each kv As KeyValuePair(Of String, String) In CostCenter.InfoList
            a.Add(kv.Value & " [" & kv.Key & "]")
          Next
          For Each kv As KeyValuePair(Of String, String) In CostCenter.InfoList
            a.Add("[" & kv.Key & "] " & kv.Value)
          Next
          Me.txtCostCenterName.AutoCompleteCustomSource = a
      End Select
    End Sub

    Private Sub grbDetail_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles grbDetail.Enter

    End Sub

    Private Sub txtSupplierName_TextAlignChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSupplierName.TextAlignChanged

    End Sub

#Region "IPreviewable"
    Public ReadOnly Property CanPreview As Boolean Implements Commands.IPreviewable.CanPreview
      Get
        Return True
      End Get
    End Property
#End Region

    Private Sub imAttachment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles imAttachment.Click
      If m_entity Is Nothing OrElse Not m_entity.Originated Then
        Return
      End If
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim frm As New AttachmentForm(Me.m_entity)
      Select Case frm.ShowDialog
        Case DialogResult.OK
          If Not frm.AttachmentColl Is Nothing Then
            frm.AttachmentColl.Save()
          End If
        Case Else

      End Select
      Dim tmp As Boolean = Me.m_entity.hasAttachment(True)
      'CheckFormEnable()
    End Sub
  End Class
End Namespace

