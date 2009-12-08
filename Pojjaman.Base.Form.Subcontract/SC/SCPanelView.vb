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
  Public Class SCPanelView
    Inherits AbstractEntityDetailPanelView
    Implements IValidatable

#Region " Windows Form Designer generated code "
    Friend WithEvents lblCode As System.Windows.Forms.Label
    Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblDocDate As System.Windows.Forms.Label
    Friend WithEvents lblGross As System.Windows.Forms.Label
    Friend WithEvents txtGross As System.Windows.Forms.TextBox
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
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
    Friend WithEvents txtNote As System.Windows.Forms.TextBox
    Friend WithEvents lblNote As System.Windows.Forms.Label
    Friend WithEvents lblStatus As System.Windows.Forms.Label
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents lblItem As System.Windows.Forms.Label
    Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents lblTaxBase As System.Windows.Forms.Label
    Friend WithEvents lblPercent As System.Windows.Forms.Label
    Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
    Friend WithEvents txtCostCenterName As System.Windows.Forms.TextBox
    Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblCostCenter As System.Windows.Forms.Label
    Friend WithEvents txtCostCenterCode As System.Windows.Forms.TextBox
    Friend WithEvents ibtnGetFromBOQ As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ibtnCopyMe As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents chkClosed As System.Windows.Forms.CheckBox
    Friend WithEvents txtRealGross As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetGross As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxAmount As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxAmount As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRealTaxBase As System.Windows.Forms.TextBox
    Friend WithEvents ibtnResetTaxBase As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
    Friend WithEvents btnCCEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtRetention As System.Windows.Forms.TextBox
    Friend WithEvents txtStartDate As System.Windows.Forms.TextBox
    Friend WithEvents txtEndDate As System.Windows.Forms.TextBox
    Friend WithEvents dtpEndDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents dtpStartDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents lblSubContractor As System.Windows.Forms.Label
    Friend WithEvents txtSubContractorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtSubContractorName As System.Windows.Forms.TextBox
    Friend WithEvents btnSubContractorFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnSubContractorEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDirectorCode As System.Windows.Forms.TextBox
    Friend WithEvents txtDirectorName As System.Windows.Forms.TextBox
    Friend WithEvents btnDirectorEdit As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnDirectorFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents lblDirector As System.Windows.Forms.Label
    Friend WithEvents txtWitholdingTax As System.Windows.Forms.TextBox
    Friend WithEvents lblWitholdingTax As System.Windows.Forms.Label
    Friend WithEvents lblRetention As System.Windows.Forms.Label
    Friend WithEvents lblEndDate As System.Windows.Forms.Label
    Friend WithEvents lblStartDate As System.Windows.Forms.Label
    Friend WithEvents lblDiscount As System.Windows.Forms.Label
        Friend WithEvents lblAdvancePay As System.Windows.Forms.Label
    Friend WithEvents txtAdvancePay As System.Windows.Forms.TextBox
        Friend WithEvents ibtnBlankSubItem As Longkong.Pojjaman.Gui.Components.ImageButton
        <System.Diagnostics.DebuggerStepThrough()> Protected Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container
      Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(SCPanelView))
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid
      Me.lblCode = New System.Windows.Forms.Label
      Me.dtpDocDate = New System.Windows.Forms.DateTimePicker
      Me.lblDocDate = New System.Windows.Forms.Label
      Me.lblGross = New System.Windows.Forms.Label
      Me.txtGross = New System.Windows.Forms.TextBox
      Me.lblDiscount = New System.Windows.Forms.Label
      Me.txtDiscountAmount = New System.Windows.Forms.TextBox
      Me.lblBeforeTax = New System.Windows.Forms.Label
      Me.txtBeforeTax = New System.Windows.Forms.TextBox
      Me.lblTaxAmount = New System.Windows.Forms.Label
      Me.txtTaxAmount = New System.Windows.Forms.TextBox
      Me.lblAfterTax = New System.Windows.Forms.Label
      Me.txtAfterTax = New System.Windows.Forms.TextBox
      Me.txtDiscountRate = New System.Windows.Forms.TextBox
      Me.cmbTaxType = New System.Windows.Forms.ComboBox
      Me.lblTaxType = New System.Windows.Forms.Label
      Me.txtTaxRate = New System.Windows.Forms.TextBox
      Me.lblTaxRate = New System.Windows.Forms.Label
      Me.lblSubContractor = New System.Windows.Forms.Label
      Me.txtSubContractorCode = New System.Windows.Forms.TextBox
      Me.txtSubContractorName = New System.Windows.Forms.TextBox
      Me.txtNote = New System.Windows.Forms.TextBox
      Me.lblNote = New System.Windows.Forms.Label
      Me.lblStatus = New System.Windows.Forms.Label
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
      Me.txtDocDate = New System.Windows.Forms.TextBox
      Me.txtStartDate = New System.Windows.Forms.TextBox
      Me.txtEndDate = New System.Windows.Forms.TextBox
      Me.txtCostCenterCode = New System.Windows.Forms.TextBox
      Me.txtDirectorCode = New System.Windows.Forms.TextBox
      Me.txtRetention = New System.Windows.Forms.TextBox
      Me.txtWitholdingTax = New System.Windows.Forms.TextBox
      Me.txtTaxBase = New System.Windows.Forms.TextBox
      Me.txtCostCenterName = New System.Windows.Forms.TextBox
      Me.txtDirectorName = New System.Windows.Forms.TextBox
      Me.txtRealGross = New System.Windows.Forms.TextBox
      Me.txtRealTaxAmount = New System.Windows.Forms.TextBox
      Me.txtRealTaxBase = New System.Windows.Forms.TextBox
      Me.txtAdvancePay = New System.Windows.Forms.TextBox
      Me.lblItem = New System.Windows.Forms.Label
      Me.btnSubContractorFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.ibtnBlankSubItem = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblWitholdingTax = New System.Windows.Forms.Label
      Me.lblRetention = New System.Windows.Forms.Label
      Me.lblEndDate = New System.Windows.Forms.Label
      Me.dtpEndDate = New System.Windows.Forms.DateTimePicker
      Me.dtpStartDate = New System.Windows.Forms.DateTimePicker
      Me.lblStartDate = New System.Windows.Forms.Label
      Me.cmbCode = New System.Windows.Forms.ComboBox
      Me.ibtnResetGross = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnResetTaxAmount = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnResetTaxBase = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnDirectorEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnDirectorFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblDirector = New System.Windows.Forms.Label
      Me.btnCCEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblCostCenter = New System.Windows.Forms.Label
      Me.chkAutorun = New System.Windows.Forms.CheckBox
      Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.btnSubContractorEdit = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.lblTaxBase = New System.Windows.Forms.Label
      Me.ibtnGetFromBOQ = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.ibtnCopyMe = New Longkong.Pojjaman.Gui.Components.ImageButton
      Me.chkClosed = New System.Windows.Forms.CheckBox
      Me.lblPercent = New System.Windows.Forms.Label
      Me.lblAdvancePay = New System.Windows.Forms.Label
      Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.grbDetail.SuspendLayout()
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
      Me.tgItem.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(255, Byte), CType(128, Byte), CType(0, Byte)), System.Drawing.Color.FromArgb(CType(255, Byte), CType(255, Byte), CType(128, Byte))})
      Me.tgItem.DataMember = ""
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(8, 142)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(760, 294)
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
      Me.lblCode.Text = "����:"
      Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpDocDate
      '
      Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpDocDate.Location = New System.Drawing.Point(336, 16)
      Me.dtpDocDate.Name = "dtpDocDate"
      Me.dtpDocDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpDocDate.TabIndex = 59
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
      Me.lblGross.Location = New System.Drawing.Point(200, 440)
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
      Me.txtGross.Location = New System.Drawing.Point(280, 440)
      Me.Validator.SetMaxValue(Me.txtGross, "")
      Me.Validator.SetMinValue(Me.txtGross, "")
      Me.txtGross.Name = "txtGross"
      Me.txtGross.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGross, "")
      Me.Validator.SetRequired(Me.txtGross, False)
      Me.txtGross.Size = New System.Drawing.Size(88, 21)
      Me.txtGross.TabIndex = 51
      Me.txtGross.Text = ""
      Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblDiscount
      '
      Me.lblDiscount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblDiscount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDiscount.Location = New System.Drawing.Point(232, 464)
      Me.lblDiscount.Name = "lblDiscount"
      Me.lblDiscount.Size = New System.Drawing.Size(48, 18)
      Me.lblDiscount.TabIndex = 49
      Me.lblDiscount.Text = "��ǹŴ :"
      Me.lblDiscount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtDiscountAmount
      '
      Me.txtDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
      Me.txtDiscountAmount.Location = New System.Drawing.Point(392, 464)
      Me.Validator.SetMaxValue(Me.txtDiscountAmount, "")
      Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
      Me.txtDiscountAmount.Name = "txtDiscountAmount"
      Me.txtDiscountAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
      Me.Validator.SetRequired(Me.txtDiscountAmount, False)
      Me.txtDiscountAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtDiscountAmount.TabIndex = 52
      Me.txtDiscountAmount.Text = ""
      Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblBeforeTax
      '
      Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
      Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblBeforeTax.Location = New System.Drawing.Point(176, 488)
      Me.lblBeforeTax.Name = "lblBeforeTax"
      Me.lblBeforeTax.Size = New System.Drawing.Size(104, 18)
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
      Me.txtBeforeTax.Location = New System.Drawing.Point(280, 488)
      Me.Validator.SetMaxValue(Me.txtBeforeTax, "")
      Me.Validator.SetMinValue(Me.txtBeforeTax, "")
      Me.txtBeforeTax.Name = "txtBeforeTax"
      Me.txtBeforeTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
      Me.Validator.SetRequired(Me.txtBeforeTax, False)
      Me.txtBeforeTax.Size = New System.Drawing.Size(200, 21)
      Me.txtBeforeTax.TabIndex = 54
      Me.txtBeforeTax.Text = ""
      Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxAmount
      '
      Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxAmount.Location = New System.Drawing.Point(480, 464)
      Me.lblTaxAmount.Name = "lblTaxAmount"
      Me.lblTaxAmount.Size = New System.Drawing.Size(88, 18)
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
      Me.txtTaxAmount.Location = New System.Drawing.Point(568, 464)
      Me.Validator.SetMaxValue(Me.txtTaxAmount, "")
      Me.Validator.SetMinValue(Me.txtTaxAmount, "")
      Me.txtTaxAmount.Name = "txtTaxAmount"
      Me.txtTaxAmount.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
      Me.Validator.SetRequired(Me.txtTaxAmount, False)
      Me.txtTaxAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtTaxAmount.TabIndex = 57
      Me.txtTaxAmount.Text = ""
      Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblAfterTax
      '
      Me.lblAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblAfterTax.BackColor = System.Drawing.Color.Transparent
      Me.lblAfterTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAfterTax.Location = New System.Drawing.Point(496, 512)
      Me.lblAfterTax.Name = "lblAfterTax"
      Me.lblAfterTax.Size = New System.Drawing.Size(72, 18)
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
      Me.txtAfterTax.Location = New System.Drawing.Point(568, 512)
      Me.Validator.SetMaxValue(Me.txtAfterTax, "")
      Me.Validator.SetMinValue(Me.txtAfterTax, "")
      Me.txtAfterTax.Name = "txtAfterTax"
      Me.txtAfterTax.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
      Me.Validator.SetRequired(Me.txtAfterTax, False)
      Me.txtAfterTax.Size = New System.Drawing.Size(200, 21)
      Me.txtAfterTax.TabIndex = 58
      Me.txtAfterTax.Text = ""
      Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtDiscountRate
      '
      Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
      Me.txtDiscountRate.Location = New System.Drawing.Point(280, 464)
      Me.Validator.SetMaxValue(Me.txtDiscountRate, "")
      Me.Validator.SetMinValue(Me.txtDiscountRate, "")
      Me.txtDiscountRate.Name = "txtDiscountRate"
      Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
      Me.Validator.SetRequired(Me.txtDiscountRate, False)
      Me.txtDiscountRate.Size = New System.Drawing.Size(112, 21)
      Me.txtDiscountRate.TabIndex = 9
      Me.txtDiscountRate.Text = ""
      '
      'cmbTaxType
      '
      Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
      Me.cmbTaxType.Location = New System.Drawing.Point(568, 440)
      Me.cmbTaxType.Name = "cmbTaxType"
      Me.cmbTaxType.Size = New System.Drawing.Size(88, 21)
      Me.cmbTaxType.TabIndex = 43
      '
      'lblTaxType
      '
      Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxType.Location = New System.Drawing.Point(488, 440)
      Me.lblTaxType.Name = "lblTaxType"
      Me.lblTaxType.Size = New System.Drawing.Size(80, 18)
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
      Me.txtTaxRate.Location = New System.Drawing.Point(720, 440)
      Me.Validator.SetMaxValue(Me.txtTaxRate, "")
      Me.Validator.SetMinValue(Me.txtTaxRate, "")
      Me.txtTaxRate.Name = "txtTaxRate"
      Me.txtTaxRate.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
      Me.Validator.SetRequired(Me.txtTaxRate, True)
      Me.txtTaxRate.Size = New System.Drawing.Size(32, 21)
      Me.txtTaxRate.TabIndex = 45
      Me.txtTaxRate.Text = ""
      Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblTaxRate
      '
      Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxRate.Location = New System.Drawing.Point(652, 440)
      Me.lblTaxRate.Name = "lblTaxRate"
      Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
      Me.lblTaxRate.TabIndex = 44
      Me.lblTaxRate.Text = "�ѵ������ :"
      Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblSubContractor
      '
      Me.lblSubContractor.BackColor = System.Drawing.Color.Transparent
      Me.lblSubContractor.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblSubContractor.Location = New System.Drawing.Point(8, 40)
      Me.lblSubContractor.Name = "lblSubContractor"
      Me.lblSubContractor.Size = New System.Drawing.Size(88, 18)
      Me.lblSubContractor.TabIndex = 20
      Me.lblSubContractor.Text = "����Ѻ����:"
      Me.lblSubContractor.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtSubContractorCode
      '
      Me.Validator.SetDataType(Me.txtSubContractorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorCode, System.Drawing.Color.Empty)
      Me.txtSubContractorCode.Location = New System.Drawing.Point(96, 40)
      Me.txtSubContractorCode.MaxLength = 20
      Me.Validator.SetMaxValue(Me.txtSubContractorCode, "")
      Me.Validator.SetMinValue(Me.txtSubContractorCode, "")
      Me.txtSubContractorCode.Name = "txtSubContractorCode"
      Me.Validator.SetRegularExpression(Me.txtSubContractorCode, "")
      Me.Validator.SetRequired(Me.txtSubContractorCode, True)
      Me.txtSubContractorCode.Size = New System.Drawing.Size(72, 21)
      Me.txtSubContractorCode.TabIndex = 4
      Me.txtSubContractorCode.Text = ""
      '
      'txtSubContractorName
      '
      Me.txtSubContractorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtSubContractorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtSubContractorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtSubContractorName, System.Drawing.Color.Empty)
      Me.txtSubContractorName.Location = New System.Drawing.Point(168, 40)
      Me.Validator.SetMaxValue(Me.txtSubContractorName, "")
      Me.Validator.SetMinValue(Me.txtSubContractorName, "")
      Me.txtSubContractorName.Name = "txtSubContractorName"
      Me.txtSubContractorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtSubContractorName, "")
      Me.Validator.SetRequired(Me.txtSubContractorName, False)
      Me.txtSubContractorName.Size = New System.Drawing.Size(224, 21)
      Me.txtSubContractorName.TabIndex = 24
      Me.txtSubContractorName.TabStop = False
      Me.txtSubContractorName.Text = ""
      '
      'txtNote
      '
      Me.txtNote.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtNote, "")
      Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
      Me.txtNote.Location = New System.Drawing.Point(8, 464)
      Me.txtNote.MaxLength = 1000
      Me.Validator.SetMaxValue(Me.txtNote, "")
      Me.Validator.SetMinValue(Me.txtNote, "")
      Me.txtNote.Multiline = True
      Me.txtNote.Name = "txtNote"
      Me.Validator.SetRegularExpression(Me.txtNote, "")
      Me.Validator.SetRequired(Me.txtNote, False)
      Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
      Me.txtNote.Size = New System.Drawing.Size(96, 72)
      Me.txtNote.TabIndex = 7
      Me.txtNote.Text = ""
      Me.txtNote.WordWrap = False
      '
      'lblNote
      '
      Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
      Me.lblNote.BackColor = System.Drawing.Color.Transparent
      Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblNote.Location = New System.Drawing.Point(16, 440)
      Me.lblNote.Name = "lblNote"
      Me.lblNote.Size = New System.Drawing.Size(88, 18)
      Me.lblNote.TabIndex = 23
      Me.lblNote.Text = "�����˵�:"
      Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
      '
      'lblStatus
      '
      Me.lblStatus.AutoSize = True
      Me.lblStatus.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStatus.ForeColor = System.Drawing.SystemColors.ControlDarkDark
      Me.lblStatus.Location = New System.Drawing.Point(255, 115)
      Me.lblStatus.Name = "lblStatus"
      Me.lblStatus.Size = New System.Drawing.Size(35, 17)
      Me.lblStatus.TabIndex = 38
      Me.lblStatus.Text = "Status"
      Me.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
      Me.txtDocDate.Size = New System.Drawing.Size(112, 21)
      Me.txtDocDate.TabIndex = 1
      Me.txtDocDate.Text = ""
      '
      'txtStartDate
      '
      Me.Validator.SetDataType(Me.txtStartDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtStartDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtStartDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtStartDate, -13)
      Me.Validator.SetInvalidBackColor(Me.txtStartDate, System.Drawing.Color.Empty)
      Me.txtStartDate.Location = New System.Drawing.Point(544, 16)
      Me.Validator.SetMaxValue(Me.txtStartDate, "")
      Me.Validator.SetMinValue(Me.txtStartDate, "")
      Me.txtStartDate.Name = "txtStartDate"
      Me.Validator.SetRegularExpression(Me.txtStartDate, "")
      Me.Validator.SetRequired(Me.txtStartDate, True)
      Me.txtStartDate.Size = New System.Drawing.Size(112, 21)
      Me.txtStartDate.TabIndex = 334
      Me.txtStartDate.Text = ""
      '
      'txtEndDate
      '
      Me.Validator.SetDataType(Me.txtEndDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
      Me.Validator.SetDisplayName(Me.txtEndDate, "")
      Me.Validator.SetGotFocusBackColor(Me.txtEndDate, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtEndDate, -13)
      Me.Validator.SetInvalidBackColor(Me.txtEndDate, System.Drawing.Color.Empty)
      Me.txtEndDate.Location = New System.Drawing.Point(544, 40)
      Me.Validator.SetMaxValue(Me.txtEndDate, "")
      Me.Validator.SetMinValue(Me.txtEndDate, "")
      Me.txtEndDate.Name = "txtEndDate"
      Me.Validator.SetRegularExpression(Me.txtEndDate, "")
      Me.Validator.SetRequired(Me.txtEndDate, True)
      Me.txtEndDate.Size = New System.Drawing.Size(112, 21)
      Me.txtEndDate.TabIndex = 337
      Me.txtEndDate.Text = ""
      '
      'txtCostCenterCode
      '
      Me.Validator.SetDataType(Me.txtCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterCode, System.Drawing.Color.Empty)
      Me.txtCostCenterCode.Location = New System.Drawing.Point(96, 64)
      Me.Validator.SetMaxValue(Me.txtCostCenterCode, "")
      Me.Validator.SetMinValue(Me.txtCostCenterCode, "")
      Me.txtCostCenterCode.Name = "txtCostCenterCode"
      Me.Validator.SetRegularExpression(Me.txtCostCenterCode, "")
      Me.Validator.SetRequired(Me.txtCostCenterCode, True)
      Me.txtCostCenterCode.Size = New System.Drawing.Size(72, 21)
      Me.txtCostCenterCode.TabIndex = 5
      Me.txtCostCenterCode.Text = ""
      '
      'txtDirectorCode
      '
      Me.Validator.SetDataType(Me.txtDirectorCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDirectorCode, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDirectorCode, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDirectorCode, System.Drawing.Color.Empty)
      Me.txtDirectorCode.Location = New System.Drawing.Point(96, 88)
      Me.Validator.SetMaxValue(Me.txtDirectorCode, "")
      Me.Validator.SetMinValue(Me.txtDirectorCode, "")
      Me.txtDirectorCode.Name = "txtDirectorCode"
      Me.Validator.SetRegularExpression(Me.txtDirectorCode, "")
      Me.Validator.SetRequired(Me.txtDirectorCode, True)
      Me.txtDirectorCode.Size = New System.Drawing.Size(72, 21)
      Me.txtDirectorCode.TabIndex = 6
      Me.txtDirectorCode.Text = ""
      '
      'txtRetention
      '
      Me.Validator.SetDataType(Me.txtRetention, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRetention, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRetention, System.Drawing.Color.Empty)
      Me.txtRetention.Location = New System.Drawing.Point(544, 64)
      Me.Validator.SetMaxValue(Me.txtRetention, "")
      Me.Validator.SetMinValue(Me.txtRetention, "")
      Me.txtRetention.Name = "txtRetention"
      Me.Validator.SetRegularExpression(Me.txtRetention, "")
      Me.Validator.SetRequired(Me.txtRetention, False)
      Me.txtRetention.Size = New System.Drawing.Size(136, 21)
      Me.txtRetention.TabIndex = 340
      Me.txtRetention.Text = ""
      Me.txtRetention.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtWitholdingTax
      '
      Me.Validator.SetDataType(Me.txtWitholdingTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtWitholdingTax, "")
      Me.Validator.SetGotFocusBackColor(Me.txtWitholdingTax, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtWitholdingTax, System.Drawing.Color.Empty)
      Me.txtWitholdingTax.Location = New System.Drawing.Point(544, 112)
      Me.Validator.SetMaxValue(Me.txtWitholdingTax, "")
      Me.Validator.SetMinValue(Me.txtWitholdingTax, "")
      Me.txtWitholdingTax.Name = "txtWitholdingTax"
      Me.Validator.SetRegularExpression(Me.txtWitholdingTax, "")
      Me.Validator.SetRequired(Me.txtWitholdingTax, False)
      Me.txtWitholdingTax.Size = New System.Drawing.Size(136, 21)
      Me.txtWitholdingTax.TabIndex = 342
      Me.txtWitholdingTax.Text = ""
      Me.txtWitholdingTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      Me.txtWitholdingTax.Visible = False
      '
      'txtTaxBase
      '
      Me.txtTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
      Me.txtTaxBase.Location = New System.Drawing.Point(280, 512)
      Me.Validator.SetMaxValue(Me.txtTaxBase, "")
      Me.Validator.SetMinValue(Me.txtTaxBase, "")
      Me.txtTaxBase.Name = "txtTaxBase"
      Me.txtTaxBase.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
      Me.Validator.SetRequired(Me.txtTaxBase, False)
      Me.txtTaxBase.Size = New System.Drawing.Size(88, 21)
      Me.txtTaxBase.TabIndex = 56
      Me.txtTaxBase.Text = ""
      Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtCostCenterName
      '
      Me.txtCostCenterName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCostCenterName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtCostCenterName, System.Drawing.Color.Empty)
      Me.txtCostCenterName.Location = New System.Drawing.Point(168, 64)
      Me.Validator.SetMaxValue(Me.txtCostCenterName, "")
      Me.Validator.SetMinValue(Me.txtCostCenterName, "")
      Me.txtCostCenterName.Name = "txtCostCenterName"
      Me.txtCostCenterName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtCostCenterName, "")
      Me.Validator.SetRequired(Me.txtCostCenterName, False)
      Me.txtCostCenterName.Size = New System.Drawing.Size(224, 21)
      Me.txtCostCenterName.TabIndex = 25
      Me.txtCostCenterName.TabStop = False
      Me.txtCostCenterName.Text = ""
      '
      'txtDirectorName
      '
      Me.txtDirectorName.BackColor = System.Drawing.SystemColors.Control
      Me.Validator.SetDataType(Me.txtDirectorName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDirectorName, "")
      Me.Validator.SetGotFocusBackColor(Me.txtDirectorName, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtDirectorName, System.Drawing.Color.Empty)
      Me.txtDirectorName.Location = New System.Drawing.Point(168, 88)
      Me.Validator.SetMaxValue(Me.txtDirectorName, "")
      Me.Validator.SetMinValue(Me.txtDirectorName, "")
      Me.txtDirectorName.Name = "txtDirectorName"
      Me.txtDirectorName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDirectorName, "")
      Me.Validator.SetRequired(Me.txtDirectorName, False)
      Me.txtDirectorName.Size = New System.Drawing.Size(224, 21)
      Me.txtDirectorName.TabIndex = 26
      Me.txtDirectorName.TabStop = False
      Me.txtDirectorName.Text = ""
      '
      'txtRealGross
      '
      Me.txtRealGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealGross, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealGross, System.Drawing.Color.Empty)
      Me.txtRealGross.Location = New System.Drawing.Point(392, 440)
      Me.Validator.SetMaxValue(Me.txtRealGross, "")
      Me.Validator.SetMinValue(Me.txtRealGross, "")
      Me.txtRealGross.Name = "txtRealGross"
      Me.Validator.SetRegularExpression(Me.txtRealGross, "")
      Me.Validator.SetRequired(Me.txtRealGross, False)
      Me.txtRealGross.Size = New System.Drawing.Size(88, 21)
      Me.txtRealGross.TabIndex = 61
      Me.txtRealGross.Text = ""
      Me.txtRealGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxAmount
      '
      Me.txtRealTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxAmount, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxAmount, System.Drawing.Color.Empty)
      Me.txtRealTaxAmount.Location = New System.Drawing.Point(680, 464)
      Me.Validator.SetMaxValue(Me.txtRealTaxAmount, "")
      Me.Validator.SetMinValue(Me.txtRealTaxAmount, "")
      Me.txtRealTaxAmount.Name = "txtRealTaxAmount"
      Me.Validator.SetRegularExpression(Me.txtRealTaxAmount, "")
      Me.Validator.SetRequired(Me.txtRealTaxAmount, False)
      Me.txtRealTaxAmount.Size = New System.Drawing.Size(88, 21)
      Me.txtRealTaxAmount.TabIndex = 63
      Me.txtRealTaxAmount.Text = ""
      Me.txtRealTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtRealTaxBase
      '
      Me.txtRealTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.Validator.SetDataType(Me.txtRealTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRealTaxBase, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRealTaxBase, System.Drawing.Color.Empty)
      Me.txtRealTaxBase.Location = New System.Drawing.Point(392, 512)
      Me.Validator.SetMaxValue(Me.txtRealTaxBase, "")
      Me.Validator.SetMinValue(Me.txtRealTaxBase, "")
      Me.txtRealTaxBase.Name = "txtRealTaxBase"
      Me.Validator.SetRegularExpression(Me.txtRealTaxBase, "")
      Me.Validator.SetRequired(Me.txtRealTaxBase, False)
      Me.txtRealTaxBase.Size = New System.Drawing.Size(88, 21)
      Me.txtRealTaxBase.TabIndex = 62
      Me.txtRealTaxBase.Text = ""
      Me.txtRealTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'txtAdvancePay
      '
      Me.Validator.SetDataType(Me.txtAdvancePay, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAdvancePay, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAdvancePay, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAdvancePay, System.Drawing.Color.Empty)
      Me.txtAdvancePay.Location = New System.Drawing.Point(544, 88)
      Me.Validator.SetMaxValue(Me.txtAdvancePay, "")
      Me.Validator.SetMinValue(Me.txtAdvancePay, "")
      Me.txtAdvancePay.Name = "txtAdvancePay"
      Me.Validator.SetRegularExpression(Me.txtAdvancePay, "")
      Me.Validator.SetRequired(Me.txtAdvancePay, False)
      Me.txtAdvancePay.Size = New System.Drawing.Size(136, 21)
      Me.txtAdvancePay.TabIndex = 342
      Me.txtAdvancePay.Text = ""
      Me.txtAdvancePay.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
      '
      'lblItem
      '
      Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblItem.Location = New System.Drawing.Point(8, 116)
      Me.lblItem.Name = "lblItem"
      Me.lblItem.Size = New System.Drawing.Size(96, 18)
      Me.lblItem.TabIndex = 33
      Me.lblItem.Text = "��¡����觨�ҧ"
      Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSubContractorFind
      '
      Me.btnSubContractorFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSubContractorFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSubContractorFind.Image = CType(resources.GetObject("btnSubContractorFind.Image"), System.Drawing.Image)
      Me.btnSubContractorFind.Location = New System.Drawing.Point(392, 40)
      Me.btnSubContractorFind.Name = "btnSubContractorFind"
      Me.btnSubContractorFind.Size = New System.Drawing.Size(24, 23)
      Me.btnSubContractorFind.TabIndex = 27
      Me.btnSubContractorFind.TabStop = False
      Me.btnSubContractorFind.ThemedImage = CType(resources.GetObject("btnSubContractorFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'grbDetail
      '
      Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                  Or System.Windows.Forms.AnchorStyles.Left) _
                  Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.grbDetail.Controls.Add(Me.ibtnBlankSubItem)
      Me.grbDetail.Controls.Add(Me.lblWitholdingTax)
      Me.grbDetail.Controls.Add(Me.lblRetention)
      Me.grbDetail.Controls.Add(Me.lblEndDate)
      Me.grbDetail.Controls.Add(Me.txtWitholdingTax)
      Me.grbDetail.Controls.Add(Me.txtRetention)
      Me.grbDetail.Controls.Add(Me.txtEndDate)
      Me.grbDetail.Controls.Add(Me.dtpEndDate)
      Me.grbDetail.Controls.Add(Me.txtStartDate)
      Me.grbDetail.Controls.Add(Me.dtpStartDate)
      Me.grbDetail.Controls.Add(Me.lblStartDate)
      Me.grbDetail.Controls.Add(Me.cmbCode)
      Me.grbDetail.Controls.Add(Me.txtRealGross)
      Me.grbDetail.Controls.Add(Me.ibtnResetGross)
      Me.grbDetail.Controls.Add(Me.txtRealTaxAmount)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxAmount)
      Me.grbDetail.Controls.Add(Me.txtRealTaxBase)
      Me.grbDetail.Controls.Add(Me.ibtnResetTaxBase)
      Me.grbDetail.Controls.Add(Me.btnDirectorEdit)
      Me.grbDetail.Controls.Add(Me.btnDirectorFind)
      Me.grbDetail.Controls.Add(Me.txtDirectorName)
      Me.grbDetail.Controls.Add(Me.txtDirectorCode)
      Me.grbDetail.Controls.Add(Me.lblDirector)
      Me.grbDetail.Controls.Add(Me.txtCostCenterName)
      Me.grbDetail.Controls.Add(Me.btnCCEdit)
      Me.grbDetail.Controls.Add(Me.btnCCFind)
      Me.grbDetail.Controls.Add(Me.lblCostCenter)
      Me.grbDetail.Controls.Add(Me.txtCostCenterCode)
      Me.grbDetail.Controls.Add(Me.chkAutorun)
      Me.grbDetail.Controls.Add(Me.ibtnBlank)
      Me.grbDetail.Controls.Add(Me.ibtnDelRow)
      Me.grbDetail.Controls.Add(Me.txtDocDate)
      Me.grbDetail.Controls.Add(Me.txtGross)
      Me.grbDetail.Controls.Add(Me.lblDiscount)
      Me.grbDetail.Controls.Add(Me.txtDiscountAmount)
      Me.grbDetail.Controls.Add(Me.lblBeforeTax)
      Me.grbDetail.Controls.Add(Me.txtSubContractorName)
      Me.grbDetail.Controls.Add(Me.tgItem)
      Me.grbDetail.Controls.Add(Me.lblCode)
      Me.grbDetail.Controls.Add(Me.dtpDocDate)
      Me.grbDetail.Controls.Add(Me.lblDocDate)
      Me.grbDetail.Controls.Add(Me.lblGross)
      Me.grbDetail.Controls.Add(Me.txtNote)
      Me.grbDetail.Controls.Add(Me.lblNote)
      Me.grbDetail.Controls.Add(Me.lblStatus)
      Me.grbDetail.Controls.Add(Me.txtBeforeTax)
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
      Me.grbDetail.Controls.Add(Me.lblSubContractor)
      Me.grbDetail.Controls.Add(Me.txtSubContractorCode)
      Me.grbDetail.Controls.Add(Me.btnSubContractorFind)
      Me.grbDetail.Controls.Add(Me.btnSubContractorEdit)
      Me.grbDetail.Controls.Add(Me.txtTaxBase)
      Me.grbDetail.Controls.Add(Me.lblTaxBase)
      Me.grbDetail.Controls.Add(Me.ibtnGetFromBOQ)
      Me.grbDetail.Controls.Add(Me.ibtnCopyMe)
      Me.grbDetail.Controls.Add(Me.chkClosed)
      Me.grbDetail.Controls.Add(Me.lblPercent)
      Me.grbDetail.Controls.Add(Me.lblAdvancePay)
      Me.grbDetail.Controls.Add(Me.txtAdvancePay)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(0, 0)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(776, 544)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "��������´"
      '
      'ibtnBlankSubItem
      '
      Me.ibtnBlankSubItem.Image = CType(resources.GetObject("ibtnBlankSubItem.Image"), System.Drawing.Image)
      Me.ibtnBlankSubItem.Location = New System.Drawing.Point(195, 113)
      Me.ibtnBlankSubItem.Name = "ibtnBlankSubItem"
      Me.ibtnBlankSubItem.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlankSubItem.TabIndex = 346
      Me.ibtnBlankSubItem.TabStop = False
      Me.ibtnBlankSubItem.ThemedImage = CType(resources.GetObject("ibtnBlankSubItem.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblWitholdingTax
      '
      Me.lblWitholdingTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblWitholdingTax.Location = New System.Drawing.Point(448, 112)
      Me.lblWitholdingTax.Name = "lblWitholdingTax"
      Me.lblWitholdingTax.Size = New System.Drawing.Size(96, 18)
      Me.lblWitholdingTax.TabIndex = 345
      Me.lblWitholdingTax.Text = "�ѡ���� � ������:"
      Me.lblWitholdingTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      Me.lblWitholdingTax.Visible = False
      '
      'lblRetention
      '
      Me.lblRetention.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblRetention.Location = New System.Drawing.Point(448, 64)
      Me.lblRetention.Name = "lblRetention"
      Me.lblRetention.Size = New System.Drawing.Size(96, 18)
      Me.lblRetention.TabIndex = 344
      Me.lblRetention.Text = "Retention:"
      Me.lblRetention.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblEndDate
      '
      Me.lblEndDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblEndDate.Location = New System.Drawing.Point(448, 40)
      Me.lblEndDate.Name = "lblEndDate"
      Me.lblEndDate.Size = New System.Drawing.Size(96, 18)
      Me.lblEndDate.TabIndex = 343
      Me.lblEndDate.Text = "�ѹ������稧ҹ:"
      Me.lblEndDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'dtpEndDate
      '
      Me.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpEndDate.Location = New System.Drawing.Point(544, 40)
      Me.dtpEndDate.Name = "dtpEndDate"
      Me.dtpEndDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpEndDate.TabIndex = 339
      '
      'dtpStartDate
      '
      Me.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Short
      Me.dtpStartDate.Location = New System.Drawing.Point(544, 16)
      Me.dtpStartDate.Name = "dtpStartDate"
      Me.dtpStartDate.Size = New System.Drawing.Size(136, 21)
      Me.dtpStartDate.TabIndex = 336
      '
      'lblStartDate
      '
      Me.lblStartDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblStartDate.Location = New System.Drawing.Point(472, 16)
      Me.lblStartDate.Name = "lblStartDate"
      Me.lblStartDate.Size = New System.Drawing.Size(72, 18)
      Me.lblStartDate.TabIndex = 335
      Me.lblStartDate.Text = "�ѹ���������ҹ:"
      Me.lblStartDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'cmbCode
      '
      Me.cmbCode.Location = New System.Drawing.Point(96, 16)
      Me.cmbCode.Name = "cmbCode"
      Me.cmbCode.Size = New System.Drawing.Size(120, 21)
      Me.cmbCode.TabIndex = 333
      '
      'ibtnResetGross
      '
      Me.ibtnResetGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetGross.Image = CType(resources.GetObject("ibtnResetGross.Image"), System.Drawing.Image)
      Me.ibtnResetGross.Location = New System.Drawing.Point(368, 440)
      Me.ibtnResetGross.Name = "ibtnResetGross"
      Me.ibtnResetGross.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetGross.TabIndex = 64
      Me.ibtnResetGross.TabStop = False
      Me.ibtnResetGross.ThemedImage = CType(resources.GetObject("ibtnResetGross.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxAmount
      '
      Me.ibtnResetTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxAmount.Image = CType(resources.GetObject("ibtnResetTaxAmount.Image"), System.Drawing.Image)
      Me.ibtnResetTaxAmount.Location = New System.Drawing.Point(656, 464)
      Me.ibtnResetTaxAmount.Name = "ibtnResetTaxAmount"
      Me.ibtnResetTaxAmount.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxAmount.TabIndex = 66
      Me.ibtnResetTaxAmount.TabStop = False
      Me.ibtnResetTaxAmount.ThemedImage = CType(resources.GetObject("ibtnResetTaxAmount.ThemedImage"), System.Drawing.Bitmap)
      '
      'ibtnResetTaxBase
      '
      Me.ibtnResetTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.ibtnResetTaxBase.Image = CType(resources.GetObject("ibtnResetTaxBase.Image"), System.Drawing.Image)
      Me.ibtnResetTaxBase.Location = New System.Drawing.Point(368, 512)
      Me.ibtnResetTaxBase.Name = "ibtnResetTaxBase"
      Me.ibtnResetTaxBase.Size = New System.Drawing.Size(24, 20)
      Me.ibtnResetTaxBase.TabIndex = 65
      Me.ibtnResetTaxBase.TabStop = False
      Me.ibtnResetTaxBase.ThemedImage = CType(resources.GetObject("ibtnResetTaxBase.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnDirectorEdit
      '
      Me.btnDirectorEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDirectorEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDirectorEdit.Image = CType(resources.GetObject("btnDirectorEdit.Image"), System.Drawing.Image)
      Me.btnDirectorEdit.Location = New System.Drawing.Point(416, 88)
      Me.btnDirectorEdit.Name = "btnDirectorEdit"
      Me.btnDirectorEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnDirectorEdit.TabIndex = 30
      Me.btnDirectorEdit.TabStop = False
      Me.btnDirectorEdit.ThemedImage = CType(resources.GetObject("btnDirectorEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnDirectorFind
      '
      Me.btnDirectorFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDirectorFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnDirectorFind.Image = CType(resources.GetObject("btnDirectorFind.Image"), System.Drawing.Image)
      Me.btnDirectorFind.Location = New System.Drawing.Point(392, 88)
      Me.btnDirectorFind.Name = "btnDirectorFind"
      Me.btnDirectorFind.Size = New System.Drawing.Size(24, 23)
      Me.btnDirectorFind.TabIndex = 29
      Me.btnDirectorFind.TabStop = False
      Me.btnDirectorFind.ThemedImage = CType(resources.GetObject("btnDirectorFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblDirector
      '
      Me.lblDirector.BackColor = System.Drawing.Color.Transparent
      Me.lblDirector.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblDirector.ForeColor = System.Drawing.SystemColors.WindowText
      Me.lblDirector.Location = New System.Drawing.Point(8, 88)
      Me.lblDirector.Name = "lblDirector"
      Me.lblDirector.Size = New System.Drawing.Size(88, 18)
      Me.lblDirector.TabIndex = 22
      Me.lblDirector.Text = "�����觨�ҧ:"
      Me.lblDirector.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnCCEdit
      '
      Me.btnCCEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCEdit.Image = CType(resources.GetObject("btnCCEdit.Image"), System.Drawing.Image)
      Me.btnCCEdit.Location = New System.Drawing.Point(416, 64)
      Me.btnCCEdit.Name = "btnCCEdit"
      Me.btnCCEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnCCEdit.TabIndex = 31
      Me.btnCCEdit.TabStop = False
      Me.btnCCEdit.ThemedImage = CType(resources.GetObject("btnCCEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnCCFind
      '
      Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCFind.Image = CType(resources.GetObject("btnCCFind.Image"), System.Drawing.Image)
      Me.btnCCFind.Location = New System.Drawing.Point(392, 64)
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
      Me.lblCostCenter.Location = New System.Drawing.Point(8, 64)
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
      'ibtnBlank
      '
      Me.ibtnBlank.Image = CType(resources.GetObject("ibtnBlank.Image"), System.Drawing.Image)
      Me.ibtnBlank.Location = New System.Drawing.Point(170, 113)
      Me.ibtnBlank.Name = "ibtnBlank"
      Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
      Me.ibtnBlank.TabIndex = 36
      Me.ibtnBlank.TabStop = False
      Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnBlank, "Blank")
      '
      'ibtnDelRow
      '
      Me.ibtnDelRow.Image = CType(resources.GetObject("ibtnDelRow.Image"), System.Drawing.Image)
      Me.ibtnDelRow.Location = New System.Drawing.Point(220, 113)
      Me.ibtnDelRow.Name = "ibtnDelRow"
      Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
      Me.ibtnDelRow.TabIndex = 37
      Me.ibtnDelRow.TabStop = False
      Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
      Me.ToolTip1.SetToolTip(Me.ibtnDelRow, "Delete")
      '
      'btnSubContractorEdit
      '
      Me.btnSubContractorEdit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnSubContractorEdit.ForeColor = System.Drawing.SystemColors.Control
      Me.btnSubContractorEdit.Image = CType(resources.GetObject("btnSubContractorEdit.Image"), System.Drawing.Image)
      Me.btnSubContractorEdit.Location = New System.Drawing.Point(416, 40)
      Me.btnSubContractorEdit.Name = "btnSubContractorEdit"
      Me.btnSubContractorEdit.Size = New System.Drawing.Size(24, 23)
      Me.btnSubContractorEdit.TabIndex = 32
      Me.btnSubContractorEdit.TabStop = False
      Me.btnSubContractorEdit.ThemedImage = CType(resources.GetObject("btnSubContractorEdit.ThemedImage"), System.Drawing.Bitmap)
      '
      'lblTaxBase
      '
      Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
      Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblTaxBase.Location = New System.Drawing.Point(176, 512)
      Me.lblTaxBase.Name = "lblTaxBase"
      Me.lblTaxBase.Size = New System.Drawing.Size(104, 18)
      Me.lblTaxBase.TabIndex = 55
      Me.lblTaxBase.Text = "��Ť���Թ���Һ�ԡ�� :"
      Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'ibtnGetFromBOQ
      '
      Me.ibtnGetFromBOQ.Image = CType(resources.GetObject("ibtnGetFromBOQ.Image"), System.Drawing.Image)
      Me.ibtnGetFromBOQ.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
      Me.ibtnGetFromBOQ.Location = New System.Drawing.Point(114, 113)
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
      Me.ibtnCopyMe.Enabled = False
      Me.ibtnCopyMe.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.ibtnCopyMe.ForeColor = System.Drawing.SystemColors.Control
      Me.ibtnCopyMe.Image = CType(resources.GetObject("ibtnCopyMe.Image"), System.Drawing.Image)
      Me.ibtnCopyMe.Location = New System.Drawing.Point(240, 16)
      Me.ibtnCopyMe.Name = "ibtnCopyMe"
      Me.ibtnCopyMe.Size = New System.Drawing.Size(24, 23)
      Me.ibtnCopyMe.TabIndex = 13
      Me.ibtnCopyMe.TabStop = False
      Me.ibtnCopyMe.ThemedImage = CType(resources.GetObject("ibtnCopyMe.ThemedImage"), System.Drawing.Bitmap)
      Me.ibtnCopyMe.Visible = False
      '
      'chkClosed
      '
      Me.chkClosed.Appearance = System.Windows.Forms.Appearance.Button
      Me.chkClosed.Location = New System.Drawing.Point(688, 16)
      Me.chkClosed.Name = "chkClosed"
      Me.chkClosed.Size = New System.Drawing.Size(80, 21)
      Me.chkClosed.TabIndex = 12
      Me.chkClosed.Text = "�Դ SC"
      Me.chkClosed.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'lblPercent
      '
      Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.lblPercent.BackColor = System.Drawing.Color.Transparent
      Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblPercent.Location = New System.Drawing.Point(752, 440)
      Me.lblPercent.Name = "lblPercent"
      Me.lblPercent.Size = New System.Drawing.Size(16, 18)
      Me.lblPercent.TabIndex = 46
      Me.lblPercent.Text = "%"
      Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'lblAdvancePay
      '
      Me.lblAdvancePay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblAdvancePay.Location = New System.Drawing.Point(448, 88)
      Me.lblAdvancePay.Name = "lblAdvancePay"
      Me.lblAdvancePay.Size = New System.Drawing.Size(96, 18)
      Me.lblAdvancePay.TabIndex = 345
      Me.lblAdvancePay.Text = "�Ѵ��:"
      Me.lblAdvancePay.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'SCPanelView
      '
      Me.Controls.Add(Me.grbDetail)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "SCPanelView"
      Me.Size = New System.Drawing.Size(784, 552)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.grbDetail.ResumeLayout(False)
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
    Private m_entity As SC
    Private m_isInitialized As Boolean = False
    Private m_treeManager As TreeManager

    'Private dummyCC As New CostCenter
    'Private dummyEmployee As New Employee

    '        Private m_treeManager2 As TreeManager
    '        Private m_wbsdInitialized As Boolean

    Private m_enableState As Hashtable
    Private m_tableStyleEnable As Hashtable

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
      Me.InitializeComponent()
      Me.SetLabelText()
      Initialize()

      '            'Dim rs As ResourceService = CType(ServiceManager.Services.GetService(GetType(ResourceService)), ResourceService)
      '            'Me.ibtnCopyMe.ThemedImage = rs.GetBitmap("Icons.16x16.Copy")

      SaveEnableState()

      Dim dt As TreeTable = SC.GetSchemaTable()
      Dim dst As DataGridTableStyle = Me.CreateTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
      Me.Validator.DataTable = m_treeManager.Treetable

      AddHandler dt.ColumnChanging, AddressOf ItemTreetable_ColumnChanging
      AddHandler dt.ColumnChanged, AddressOf ItemTreetable_ColumnChanged
      AddHandler dt.RowDeleted, AddressOf SCItemDelete
      AddHandler dt.RowExpandStateChanged, AddressOf RowExpandCollapseHandler

      '            'Dim dt2 As TreeTable = WBSDistribute.GetSchemaTable()
      '            'Dim dst2 As DataGridTableStyle = Me.CreateTableStyle2()
      '            ''m_treeManager2 = New TreeManager(dt2, tgWBS)
      '            'm_treeManager2.SetTableStyle(dst2)
      '            'm_treeManager2.AllowSorting = False
      '            'm_treeManager2.AllowDelete = False

      '            'AddHandler dt2.ColumnChanging, AddressOf Treetable_ColumnChanging
      '            'AddHandler dt2.ColumnChanged, AddressOf Treetable_ColumnChanged
      '            'AddHandler dt2.RowDeleted, AddressOf ItemDelete

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

    Public Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
      'e.HilightValue = False
      'e.RedText = False
      'Dim i As Integer = 0
      'For Each row As DataRow In Me.m_treeManager2.Treetable.Rows
      '    For Each col As DataColumn In Me.m_treeManager2.Treetable.Columns
      '        If col.Ordinal > 0 Then
      '            If Not row.IsNull(col) AndAlso IsNumeric(row(col)) Then
      '                If CDec(row(col)) < 0 Then
      '                    If e.Column = col.Ordinal And e.Row = i Then
      '                        'e.HilightValue = True
      '                        e.RedText = True
      '                    End If
      '                End If
      '            End If
      '        End If
      '    Next
      '    i += 1
      'Next
    End Sub
    Public Sub CCButtonClicked(ByVal e As ButtonColumnEventArgs)
      If Me.m_entity Is Nothing Then
        Return
      End If
      If Me.m_entity.CostCenter Is Nothing Then
        Return
      End If
      If Me.m_entity.CostCenter.BoqId = 0 Then
        Return
      End If
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim entity As New CostCenter
      Dim entities As New ArrayList
      myEntityPanelService.OpenListDialog(entity, AddressOf SetCostCenter)
    End Sub
    Private Sub SetCostCenter(ByVal myEntity As ISimpleEntity)
      'Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      'If doc Is Nothing Then
      '    Return
      'End If
      'Dim dt As TreeTable = Me.m_treeManager2.Treetable
      'Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
      'Dim row As TreeRow = Me.m_treeManager2.SelectedRow
      'If TypeOf myEntity Is CostCenter Then
      '    CType(row.Tag, WBSDistribute).CostCenter = CType(myEntity, CostCenter)
      '    CType(row.Tag, WBSDistribute).WBS = New WBS
      'End If
      'Dim view As Integer = 6
      'm_wbsdInitialized = False
      'wsdColl.Populate(dt, doc, view)
      'm_wbsdInitialized = True
      'Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
    Private Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "SC"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)


      Dim csType As DataGridComboColumn
      csType = New DataGridComboColumn("sci_entityType" _
      , CodeDescription.GetCodeList("sci_entitytype") _
      , "code_description", "code_value")
      csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.TypeHeaderText}")
      csType.NullText = String.Empty
      csType.Width = 80

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code"
      csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.CodeHeaderText}")
      csCode.NullText = ""
      csCode.Width = 100
      'csCode.ReadOnly = True
      csCode.TextBox.Name = "Code"

      Dim csButton As New DataGridButtonColumn
      csButton.MappingName = "Button"
      csButton.HeaderText = ""
      csButton.NullText = ""

      Dim csName As New TreeTextColumn
      csName.MappingName = "sci_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 180
      csName.TextBox.Name = "sci_itemName"

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.UnitHeaderText}")
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
      csQty.MappingName = "sci_qty"
      csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.QtyHeaderText}")
      csQty.NullText = ""
      csQty.DataAlignment = HorizontalAlignment.Right
      csQty.Format = "#,###.##"
      csQty.TextBox.Name = "sci_qty"
      'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty


      Dim csUnitPRice As New TreeTextColumn
      csUnitPRice.MappingName = "sci_unitprice"
      csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.poi_unitpriceHeaderText}")
      csUnitPRice.NullText = ""
      csUnitPRice.TextBox.Name = "sci_unitprice"
      csUnitPRice.DataAlignment = HorizontalAlignment.Right
      AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csMat As New TreeTextColumn
      csMat.MappingName = "sci_mat"
      csMat.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.MatAmountHeaderText}")
      csMat.NullText = ""
      csMat.TextBox.Name = "sci_mat"
      csMat.DataAlignment = HorizontalAlignment.Right
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim csLab As New TreeTextColumn
      csLab.MappingName = "sci_lab"
      csLab.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.LabAmountHeaderText}")
      csLab.NullText = ""
      csLab.TextBox.Name = "sci_lab"
      csLab.DataAlignment = HorizontalAlignment.Right
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csEq As New TreeTextColumn
      csEq.MappingName = "sci_eq"
      csEq.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.EQAmountHeaderText}")
      csEq.NullText = ""
      csEq.TextBox.Name = "sci_eq"
      csEq.DataAlignment = HorizontalAlignment.Right
      'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
      'csDiscount.DataAlignment = HorizontalAlignment.Center

      Dim csAmount As New TreeTextColumn
      csAmount.MappingName = "Amount"
      csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.AmountHeaderText}")
      csAmount.NullText = ""
      csAmount.TextBox.Name = "Amount"
      csAmount.ReadOnly = True
      csAmount.DataAlignment = HorizontalAlignment.Right
      'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
      'csUnit.DataAlignment = HorizontalAlignment.Center

      Dim csPAAmount As New TreeTextColumn
      csPAAmount.MappingName = "PAAmount"
      csPAAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.PAAmountHeaderText}")
      csPAAmount.NullText = ""
      csPAAmount.DataAlignment = HorizontalAlignment.Right
      csPAAmount.Format = "#,###.##"
      csPAAmount.ReadOnly = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "sci_note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.NoteHeaderText}")
      csNote.NullText = ""
      csNote.Width = 180
      csNote.TextBox.Name = "sci_note"

      Dim csVatable As New DataGridCheckBoxColumn
      csVatable.MappingName = "sci_unvatable"
      csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.UnVatableHeaderText}")
      csVatable.Width = 100
      csVatable.InvisibleWhenUnspcified = True

      'dst.GridColumnStyles.Add(csLineNumber)
      'dst.GridColumnStyles.Add(csSCDesc)
      dst.GridColumnStyles.Add(csType)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csButton)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csUnit)
      dst.GridColumnStyles.Add(csUnitButton)
      dst.GridColumnStyles.Add(csQty)
      'dst.GridColumnStyles.Add(csOriginQty)

      dst.GridColumnStyles.Add(csUnitPRice)
      dst.GridColumnStyles.Add(csAmount)
      dst.GridColumnStyles.Add(csBarrier1)
      dst.GridColumnStyles.Add(csMat)
      dst.GridColumnStyles.Add(csLab)
      dst.GridColumnStyles.Add(csEq)
      dst.GridColumnStyles.Add(csPAAmount)
      dst.GridColumnStyles.Add(csNote)
      'dst.GridColumnStyles.Add(csVatable)

      m_tableStyleEnable = New Hashtable
      For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
        m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
      Next
      Return dst
    End Function
    Private Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
      If e.Column = 2 Then
        Me.ItemButtonClick(e)
      Else
        Me.UnitButtonClick(e)
      End If
    End Sub
#End Region

#Region "Properties"
    Private ReadOnly Property CurrentTagItem() As SCItem
      Get
        Dim row As TreeRow = Me.m_treeManager.SelectedRow
        If row Is Nothing Then
          Return Nothing
        End If
        If Not TypeOf row.Tag Is SCItem Then
          Return Nothing
        End If
        Return CType(row.Tag, SCItem)
      End Get
    End Property
    Private ReadOnly Property CurrentRealTagItem() As SCItem
      Get
        'Return CType(childRow.Tag, SCItem)
        Dim row As TreeRow = Me.m_treeManager.SelectedRow

        Try
          Dim lastIndex As Integer = row.Index
          Dim startIndex As Integer = row.Index

          For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
            If i > startIndex Then
              If CType(Me.m_treeManager.Treetable.Childs(i).Tag, SCItem).Level = 0 Then
                Exit For
              End If
              lastIndex = i
            End If
          Next

          Dim parentRow As TreeRow = Me.m_treeManager.Treetable.Childs(lastIndex)

          Return CType(parentRow.Tag, SCItem)
        Catch ex As Exception
          Return Nothing
        End Try

        'Dim childRow As TreeRow = row.LastChild '�١������͡���ش���� ������͡�������
        'Dim lastChild As TreeRow = row.Parent.LastChild '�١������͡���ش���� ������͡�١��������

        '''���͡�١ � �������� ���� ������͡����������١ � (�Ҩ����� ���������١ ���� �١����)
        'If Not lastChild Is Nothing And childRow Is Nothing Then
        '  If TypeOf lastChild.Tag Is SCItem Then
        '    If CType(lastChild.Tag, SCItem).Level = 0 Then
        '      Return CType(row.Tag, SCItem)
        '    End If
        '    Return CType(lastChild.Tag, SCItem)
        '  End If
        'End If

        '''���͡��������١ � ����
        'If Not childRow Is Nothing Then
        '  If TypeOf childRow.Tag Is SCItem Then
        '    Return CType(childRow.Tag, SCItem)
        '  End If
        'End If



      End Get
    End Property
#End Region

#Region "ItemTreeTable Handlers"
    Private Sub RowExpandCollapseHandler(ByVal e As RowExpandCollapseEventArgs)
      'If TypeOf e.Row.Tag Is SCItem Then
      '  If Not m_isInitialized Then
      '    Return
      '  End If
      '  If Me.m_treeManager.SelectedRow Is Nothing Then
      '    Return
      '  End If
      '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      '  If Me.m_entity Is Nothing Then
      '    Return
      '  End If
      '  Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      '  doc.State = e.Row.State
      '  RefreshDocs()
      'End If
    End Sub
    Private Sub ItemTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
      If Not m_isInitialized Then
        Return
      End If
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      Dim index As Integer = Me.tgItem.CurrentRowIndex
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
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
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      ''If tick checkbox that not in the current hilight row

      'If e.Column.ColumnName.ToLower = "sci_unvatable" Then
      '  Me.m_treeManager.SelectedRow = e.Row
      '  doc = Me.m_entity.ItemCollection.CurrentItem
      'End If
      If doc Is Nothing Then
        doc = New SCItem
        doc.Level = 0
        doc.ItemType = New SCIItemType(289)
        Me.m_entity.ItemCollection.Add(doc)
        Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      'If doc.ItemType Is Nothing Then
      '  doc.ItemType = New SCIItemType(289)
      'End If
      Try
        Select Case e.Column.ColumnName.ToLower
          Case "code"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.SetItemCode(CStr(e.ProposedValue))
          Case "sci_itemname"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing Then
              e.ProposedValue = ""
            End If
            doc.EntityName = CStr(e.ProposedValue)
          Case "unit"
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue Is Nothing OrElse e.ProposedValue.ToString.Trim.Length = 0 Then
              e.ProposedValue = ""
            End If
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            doc.Unit = myUnit
          Case "sci_qty"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Qty = value
          Case "sci_entitytype"
            Dim value As SCIItemType
            If IsNumeric(e.ProposedValue) Then
              value = New SCIItemType(CInt(e.ProposedValue))
            End If
            doc.ItemType = value
          Case "sci_unitprice"
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
          Case "sci_mat"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Mat = value
          Case "sci_lab"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Lab = value
          Case "sci_eq"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            Dim value As Decimal = 0 'CDec(TextParser.Evaluate(e.ProposedValue.ToString))
            If Not e.ProposedValue = "" Then
              If IsNumeric(e.ProposedValue) Then
                value = CDec(TextParser.Evaluate(e.ProposedValue.ToString))
              End If
            End If
            doc.Eq = value
          Case "sci_note"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = ""
            End If
            doc.Note = e.ProposedValue.ToString
          Case "sci_unvatable"
            If IsDBNull(e.ProposedValue) Then
              e.ProposedValue = False
            End If
            doc.Unvatable = CBool(e.ProposedValue)
        End Select
        'End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
    End Sub
    Private Sub SCItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
    End Sub
#End Region

#Region "TreeTable Handlers"
    '        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '            If Not m_wbsdInitialized Then
    '                Return
    '            End If
    '            Dim index As Integer = Me.m_treeManager2.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
    '            If ValidateRow(CType(e.Row, TreeRow)) Then
    '                'UpdateAmount(e)
    '                Me.m_treeManager2.Treetable.AcceptChanges()
    '            End If
    '            RefreshWBS()
    '            Me.WorkbenchWindow.ViewContent.IsDirty = True
    '        End Sub
    'Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
    '    'Dim item As WBSDistribute = Me.CurrentWsbsd
    '    'If item Is Nothing Then
    '    '    Return
    '    'End If
    '    Dim view As Integer = 6
    '    Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
    '    If doc Is Nothing Then
    '        Return
    '    End If
    '    e.Row("Amount") = Configuration.FormatToString(item.Percent * doc.BeforeTax / 100, DigitConfig.Price)
    '    If Not item.IsMarkup Then
    '        e.Row("BudgetRemain") = Configuration.FormatToString(item.WBS.GetTotal - item.WBS.GetActualTotal(Me.m_entity, view) + Me.m_entity.GetCurrentAmountForWBS(item.WBS, doc.ItemType), DigitConfig.Price)
    '        e.Row("QtyRemain") = Configuration.FormatToString(0 - item.WBS.GetActualTotalQty(Me.m_entity, view) - 0, DigitConfig.Price)
    '    Else
    '        Dim mk As Markup = Me.m_entity.CostCenter.Boq.MarkupCollection.GetMarkupFromId(item.WBS.Id)
    '        If Not mk Is Nothing Then
    '            e.Row("BudgetRemain") = Configuration.FormatToString(mk.TotalAmount - mk.GetActualTotal(Me.m_entity, view) - Me.m_entity.GetCurrentAmountForMarkup(mk), DigitConfig.Price)
    '        End If
    '    End If
    'End Sub
    '        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
    '            If Not m_wbsdInitialized Then
    '                Return
    '            End If
    '            Try
    '                Select Case e.Column.ColumnName.ToLower
    '                    Case "wbs"
    '                        SetCode(e)
    '                    Case "percent"
    '                        SetPercent(e)
    '                End Select
    '                ValidateRow(e)
    '            Catch ex As Exception
    '                MessageBox.Show(ex.ToString)
    '            End Try
    '        End Sub
    '        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
    '            Dim wbs As Object = e.Row("wbs")
    '            Dim percent As Object = e.Row("percent")

    '            Select Case e.Column.ColumnName.ToLower
    '                Case "wbs"
    '                    wbs = e.ProposedValue
    '                Case "percent"
    '                    percent = e.ProposedValue
    '                Case Else
    '                    Return
    '            End Select

    '            Dim isBlankRow As Boolean = False
    '            If IsDBNull(wbs) Then
    '                isBlankRow = True
    '            End If

    '            If Not isBlankRow Then
    '                If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
    '                    e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
    '                Else
    '                    e.Row.SetColumnError("percent", "")
    '                End If
    '                If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
    '                    e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
    '                Else
    '                    e.Row.SetColumnError("wbs", "")
    '                End If
    '            End If

    '        End Sub
    '        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
    '            If row.IsNull("WBS") Then
    '                Return False
    '            End If
    '            Return True
    '        End Function
    '        Private m_updating As Boolean = False
    '        Public Sub SetPercent(ByVal e As DataColumnChangeEventArgs)
    '            If m_updating Then
    '                Return
    '            End If
    '            Dim item As WBSDistribute = Me.CurrentWsbsd
    '            If item Is Nothing Then
    '                Return
    '            End If
    '            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
    '                e.ProposedValue = ""
    '                Return
    '            End If
    '            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
    '            Dim value As Decimal = CDec(e.ProposedValue)
    '            Dim oldvalue As Decimal = 0
    '            If Not e.Row.IsNull(e.Column) Then
    '                oldvalue = CDec(e.Row(e.Column))
    '            End If
    '            Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
    '            If doc Is Nothing Then
    '                Return
    '            End If
    '            Dim wsdColl As WBSDistributeCollection = doc.WBSDistributeCollection
    '            If wsdColl.GetSumPercent - oldvalue + value > 100 Then
    '                e.ProposedValue = e.Row(e.Column)
    '                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '                msgServ.ShowMessage("${res:Global.Error.WBSPercentExceed100}")
    '                Return
    '            End If

    '            m_updating = True
    '            item.Percent = value
    '            m_updating = False
    '        End Sub

    '        'Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
    '        '    If e.Row.IsNull("stocki_entityType") Then
    '        '        Return False
    '        '    End If
    '        '    If IsDBNull(e.ProposedValue) Then
    '        '        Return False
    '        '    End If
    '        '    For Each row As TreeRow In Me.ItemTable.Childs
    '        '        If Not row Is e.Row Then
    '        '            If Not row.IsNull("stocki_entityType") Then
    '        '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
    '        '                    If Not row.IsNull("code") Then
    '        '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
    '        '                            Return True
    '        '                        End If
    '        '                    End If
    '        '                End If
    '        '            End If
    '        '        End If
    '        '    Next
    '        '    Return False
    '        'End Function
    '        Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
    '            'If m_updating Then
    '            '    Return
    '            'End If
    '            'm_updating = True
    '            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
    '            'If e.Row.IsNull("stocki_entityType") Then
    '            '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '            '    e.ProposedValue = e.Row(e.Column)
    '            '    m_updating = False
    '            '    Return
    '            'End If
    '            'If DupCode(e) Then
    '            '    Dim item As New GoodsReceiptItem
    '            '    item.CopyFromDataRow(CType(e.Row, TreeRow))
    '            '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
    '            '    e.ProposedValue = e.Row(e.Column)
    '            '    m_updating = False
    '            '    Return
    '            'End If
    '            'Select Case CInt(e.Row("stocki_entityType"))
    '            '    Case 0 'Blank
    '            '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
    '            '        e.ProposedValue = e.Row(e.Column)
    '            '        m_updating = False
    '            '        Return
    '            '    Case 28 'F/A
    '            '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
    '            '        e.ProposedValue = e.Row(e.Column)
    '            '        m_updating = False
    '            '        Return
    '            '    Case 19 'Tool
    '            '        If e.ProposedValue.ToString.Length = 0 Then
    '            '            If e.Row(e.Column).ToString.Length <> 0 Then
    '            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
    '            '                    ClearRow(e)
    '            '                Else
    '            '                    e.ProposedValue = e.Row(e.Column)
    '            '                End If
    '            '            End If
    '            '            m_updating = False
    '            '            Return
    '            '        End If
    '            '        Dim myTool As New Tool(e.ProposedValue.ToString)
    '            '        If Not myTool.Originated Then
    '            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
    '            '            e.ProposedValue = e.Row(e.Column)
    '            '            m_updating = False
    '            '            Return
    '            '        Else
    '            '            Dim myUnit As Unit = myTool.Unit
    '            '            e.Row("stocki_entity") = myTool.Id
    '            '            e.ProposedValue = myTool.Code
    '            '            e.Row("stocki_itemName") = myTool.Name
    '            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '            '                e.Row("stocki_unit") = myUnit.Id
    '            '                e.Row("Unit") = myUnit.Name
    '            '            Else
    '            '                e.Row("stocki_unit") = DBNull.Value
    '            '                e.Row("Unit") = DBNull.Value
    '            '            End If
    '            '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
    '            '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
    '            '                e.Row("stocki_acct") = ga.Account.Id
    '            '                e.Row("AccountCode") = ga.Account.Code
    '            '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '            '            Else
    '            '                e.Row("stocki_acct") = DBNull.Value
    '            '                e.Row("AccountCode") = DBNull.Value
    '            '                e.Row("Account") = DBNull.Value
    '            '            End If
    '            '        End If
    '            '    Case 42 'LCI
    '            '        If e.ProposedValue.ToString.Length = 0 Then
    '            '            If e.Row(e.Column).ToString.Length <> 0 Then
    '            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
    '            '                    ClearRow(e)
    '            '                Else
    '            '                    e.ProposedValue = e.Row(e.Column)
    '            '                End If
    '            '            End If
    '            '            m_updating = False
    '            '            Return
    '            '        End If
    '            '        Dim lci As New LCIItem(e.ProposedValue.ToString)
    '            '        If Not lci.Originated Then
    '            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
    '            '            e.ProposedValue = e.Row(e.Column)
    '            '            m_updating = False
    '            '            Return
    '            '        Else
    '            '            Dim myUnit As Unit = lci.DefaultUnit
    '            '            e.Row("stocki_entity") = lci.Id
    '            '            e.ProposedValue = lci.Code
    '            '            e.Row("stocki_itemName") = lci.Name
    '            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
    '            '                e.Row("stocki_unit") = myUnit.Id
    '            '                e.Row("Unit") = myUnit.Name
    '            '            Else
    '            '                e.Row("stocki_unit") = DBNull.Value
    '            '                e.Row("Unit") = DBNull.Value
    '            '            End If
    '            '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
    '            '                e.Row("stocki_acct") = lci.Account.Id
    '            '                e.Row("AccountCode") = lci.Account.Code
    '            '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
    '            '            Else
    '            '                e.Row("stocki_acct") = DBNull.Value
    '            '                e.Row("AccountCode") = DBNull.Value
    '            '                e.Row("Account") = DBNull.Value
    '            '            End If
    '            '        End If
    '            '    Case Else
    '            '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
    '            '        e.ProposedValue = e.Row(e.Column)
    '            '        m_updating = False
    '            '        Return
    '            'End Select
    '            'e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
    '            'm_updating = False
    '        End Sub
    '        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

    '        End Sub
#End Region

    '#Region "CheckPJMModule"
    '        Private m_ApproveDocModule As New PJMModule("approvedoc")
    '#End Region

#Region "IListDetail"
    Public Overrides Sub CheckFormEnable()
      If Me.m_entity Is Nothing Then
        Return
      End If

      '�ҡ Status �ͧ�͡����ͧ
      If Me.m_entity.Status.Value = 0 OrElse m_entityRefed = 1 OrElse Me.m_entity.Closed Then
        For Each ctrl As Control In grbDetail.Controls
          If Not ctrl.Name = "chkClosed" Then
            ctrl.Enabled = False
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

    End Sub
    Public Overrides Sub ClearDetail()
      lblStatus.Text = ""
      For Each crlt As Control In grbDetail.Controls
        If crlt.Name.StartsWith("txt") Then
          crlt.Text = ""
        End If
      Next
      For Each ctrl As Control In Me.Controls
        If ctrl.Name.StartsWith("txt") Then
          ctrl.Text = ""
        End If
      Next
      Me.dtpDocDate.Value = Now
      Me.dtpStartDate.Value = Now

      Me.dtpEndDate.Value = Now
      'Me.dtpReceivingDate.Value = Now
      If cmbTaxType.Items.Count >= 1 Then
        cmbTaxType.SelectedIndex = 1
      End If

    End Sub
    Public Overrides Sub SetLabelText()
      If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)

      Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblCode}")
      Me.Validator.SetDisplayName(Me.lblCode, StringHelper.GetRidOfAtEnd(Me.lblCode.Text, ":"))

      Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Global.DocDateText}")
      Me.Validator.SetDisplayName(Me.txtDocDate, StringHelper.GetRidOfAtEnd(Me.lblDocDate.Text, ":"))

      Me.lblStartDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblstartDate}")
      Me.Validator.SetDisplayName(Me.txtStartDate, StringHelper.GetRidOfAtEnd(Me.lblStartDate.Text, ":"))

      Me.lblEndDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblEndDate}")
      Me.Validator.SetDisplayName(Me.txtEndDate, StringHelper.GetRidOfAtEnd(Me.lblEndDate.Text, ":"))

      Me.lblSubContractor.Text = Me.StringParserService.Parse("${res:Global.SubContractorText}")
      Me.Validator.SetDisplayName(Me.txtSubContractorCode, StringHelper.GetRidOfAtEnd(Me.lblSubContractor.Text, ":"))

      Me.lblCostCenter.Text = Me.StringParserService.Parse("${res:Global.CostCenterText}")
      Me.Validator.SetDisplayName(Me.txtCostCenterCode, StringHelper.GetRidOfAtEnd(Me.lblCostCenter.Text, ":"))

      Me.lblDirector.Text = Me.StringParserService.Parse("${res:Global.DirectorText}")
      Me.Validator.SetDisplayName(Me.txtDirectorCode, StringHelper.GetRidOfAtEnd(Me.lblDirector.Text, ":"))

      Me.lblRetention.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblRetention}")
      Me.lblWitholdingTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblAdvancePay}")
      Me.lblWitholdingTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblWitholdingTax}")

      'Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosed}")

      Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblItem}")

      Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblNote}")
      Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblGross}")
      Me.lblDiscount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblDiscount}")
      Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblBeforeTax}")
      Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblTaxBase}")
      Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblTaxType}")
      Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblTaxRate}")
      Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblTaxAmount}")
      Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.lblAfterTax}")

    End Sub
    Protected Overrides Sub EventWiring()
      AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
      AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

      AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtStartDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpStartDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtEndDate.Validated, AddressOf Me.ChangeProperty
      AddHandler dtpEndDate.ValueChanged, AddressOf Me.ChangeProperty

      AddHandler txtSubContractorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtSubContractorCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtCostCenterCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtCostCenterCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtDirectorCode.Validated, AddressOf Me.ChangeProperty
      AddHandler txtDirectorCode.TextChanged, AddressOf Me.TextHandler

      AddHandler txtRetention.Validated, AddressOf Me.ChangeProperty
      AddHandler txtRetention.TextChanged, AddressOf Me.TextHandler

      AddHandler txtWitholdingTax.Validated, AddressOf Me.ChangeProperty
      AddHandler txtWitholdingTax.TextChanged, AddressOf Me.TextHandler

      AddHandler txtAdvancePay.Validated, AddressOf Me.ChangeProperty
      AddHandler txtAdvancePay.TextChanged, AddressOf Me.TextHandler

      '            ''AddHandler txtReceivingDate.Validated, AddressOf Me.ChangeProperty
      '            ''AddHandler dtpReceivingDate.ValueChanged, AddressOf Me.ChangeProperty

      '            ''AddHandler txtCreditPrd.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty 'Todo: .... ���������ͻ����
      AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

      AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

      '            ''AddHandler txtRetentionNote.TextChanged, AddressOf Me.ChangeProperty
      '            ''AddHandler txtRetention.Validated, AddressOf Me.TextHandler
      '            ''AddHandler txtRetention.TextChanged, AddressOf Me.ChangeProperty

      AddHandler txtRealTaxBase.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxBase.Validated, AddressOf Me.TextHandler

      AddHandler txtRealTaxAmount.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealTaxAmount.Validated, AddressOf Me.TextHandler

      AddHandler txtRealGross.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtRealGross.Validated, AddressOf Me.TextHandler

      AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty
      AddHandler txtNote.TextChanged, AddressOf Me.TextHandler
    End Sub
    Private m_dateSetting As Boolean = False
    Private m_startDateSetting As Boolean = False
    Private m_endDateSetting As Boolean = False

    Private oldCCId As Integer
    Private dirtyFlag As Boolean = False
    Private CCCodeBlankFlag As Boolean = False

    Private ccCodeChanged As Boolean = False
    Private subContractorChanged As Boolean = False
    Private directorCodeChanged As Boolean = False
    Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Select Case CType(sender, Control).Name.ToLower

        Case "txtrequestorcode"
          directorCodeChanged = True
        Case "txtcostcentercode"
          ccCodeChanged = True
        Case "txtsubcontractorcode"
          subContractorChanged = True
        Case "txtcostcentercode"
          ccCodeChanged = True

      End Select
    End Sub
    Public Overrides Sub UpdateEntityProperties()
      m_isInitialized = False
      ClearDetail()
      If m_entity Is Nothing Then
        Return
      End If
      cmbCode.Items.Clear()
      cmbCode.DropDownStyle = ComboBoxStyle.Simple
      cmbCode.Text = m_entity.Code
      Me.m_oldCode = Me.m_entity.Code
      oldCCId = Me.m_entity.CostCenter.Id
      Me.chkAutorun.Checked = Me.m_entity.AutoGen
      Me.UpdateAutogenStatus()

      Me.chkClosed.Checked = Me.m_entity.Closed

      If Me.m_entity.Closed Then
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosedCancel}")
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosed}")
      End If

      'Me.SetColumnOriginQty()

      txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

      txtStartDate.Text = MinDateToNull(Me.m_entity.StartDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpStartDate.Value = MinDateToNow(Me.m_entity.StartDate)
      txtEndDate.Text = MinDateToNull(Me.m_entity.EndDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
      dtpEndDate.Value = MinDateToNow(Me.m_entity.EndDate)


      txtSubContractorCode.Text = m_entity.SubContractor.Code
      txtSubContractorName.Text = m_entity.SubContractor.Name

      txtCostCenterCode.Text = m_entity.CostCenter.Code
      txtCostCenterName.Text = m_entity.CostCenter.Name

      txtDirectorCode.Text = m_entity.Director.Code
      txtDirectorName.Text = m_entity.Director.Name
      txtNote.Text = m_entity.Note

      For Each item As IdValuePair In Me.cmbTaxType.Items
        If Me.m_entity.TaxType.Value = item.Id Then
          Me.cmbTaxType.SelectedItem = item
        End If
      Next

      txtRetention.Text = Configuration.FormatToString(m_entity.Retention, DigitConfig.Price)
      txtAdvancePay.Text = Configuration.FormatToString(m_entity.AdvancePay, DigitConfig.Price)
      txtWitholdingTax.Text = Configuration.FormatToString(m_entity.WitholdingTax, DigitConfig.Price)

      RefreshDocs()

      SetStatus()
      SetLabelText()
      CheckFormEnable()
      m_isInitialized = True
    End Sub
    Private Sub RefreshDocs()
      Me.m_isInitialized = False
      Me.m_entity.ItemCollection.Populate(m_treeManager.Treetable)
      RefreshBlankGrid()
      Me.m_treeManager.Treetable.AcceptChanges()
      Me.UpdateAmount()
      Me.m_isInitialized = True
    End Sub
    Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
      If e.Name = "ItemChanged" Or e.Name = "QtyChanged" Then
        If e.Name = "QtyChanged" Then
          Me.UpdateAmount()
        End If
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
    End Sub

    Private Sub SetCCCodeBlankFlag()
      If Me.txtCostCenterCode.Text.Length = 0 Then
        CCCodeBlankFlag = True
      Else
        CCCodeBlankFlag = False
      End If
    End Sub
    Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
      If Me.m_entity Is Nothing Or Not m_isInitialized Then
        Return
      End If
      Dim dirtyFlag As Boolean = False
      Select Case CType(sender, Control).Name.ToLower
        Case "txtrealtaxbase"
          dirtyFlag = True
        Case "txtrealtaxamount"
          dirtyFlag = True
        Case "txtrealgross"
          dirtyFlag = True
        Case "cmbcode"
          Me.m_entity.Code = cmbCode.Text
          dirtyFlag = True
        Case "txtnote"
          Me.m_entity.Note = txtNote.Text
          dirtyFlag = True
        Case "txtsubcontractorcode"
          dirtyFlag = Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.SubContractor, True)
          'm_isInitialized = False
          'Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
          'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
          'm_isInitialized = True
        Case "dtpdocdate"
          If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
            If Not m_dateSetting Then
              Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.DocDate = dtpDocDate.Value
              ' Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
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
              'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
              dirtyFlag = True
            End If
          Else
            Me.dtpDocDate.Value = Date.Now
            Me.m_entity.DocDate = Date.MinValue
            dirtyFlag = True
          End If
          m_dateSetting = False

        Case "dtpstartdate"
          If Not Me.m_entity.StartDate.Equals(dtpStartDate.Value) Then
            If Not m_startDateSetting Then
              Me.txtStartDate.Text = MinDateToNull(dtpStartDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.StartDate = dtpStartDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtstartdate"
          m_startDateSetting = True
          If Not Me.txtStartDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtStartDate) = "" Then
            Dim theDate As Date = CDate(Me.txtStartDate.Text)
            If Not Me.m_entity.StartDate.Equals(theDate) Then
              dtpStartDate.Value = theDate
              Me.m_entity.StartDate = dtpStartDate.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpStartDate.Value = Date.Now
            Me.m_entity.StartDate = Date.MinValue
            dirtyFlag = True
          End If
          m_startDateSetting = False
        Case "dtpenddate"
          If Not Me.m_entity.EndDate.Equals(dtpEndDate.Value) Then
            If Not m_endDateSetting Then
              Me.txtEndDate.Text = MinDateToNull(dtpEndDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
              Me.m_entity.EndDate = dtpEndDate.Value
            End If
            dirtyFlag = True
          End If
        Case "txtenddate"
          m_endDateSetting = True
          If Not Me.txtEndDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtEndDate) = "" Then
            Dim theDate As Date = CDate(Me.txtEndDate.Text)
            If Not Me.m_entity.EndDate.Equals(theDate) Then
              dtpEndDate.Value = theDate
              Me.m_entity.EndDate = dtpEndDate.Value
              dirtyFlag = True
            End If
          Else
            Me.dtpEndDate.Value = Date.Now
            Me.m_entity.EndDate = Date.MinValue
            dirtyFlag = True
          End If
          m_endDateSetting = False
        Case "txtretention"
          dirtyFlag = True
          m_entity.Retention = txtRetention.Text
        Case "txtadvancepay"
          dirtyFlag = True
          m_entity.AdvancePay = txtAdvancePay.Text
        Case "txtwitholdingtax"
          dirtyFlag = True
          m_entity.WitholdingTax = txtWitholdingTax.Text
        Case "txttaxbase"
          '                    'Todo
        Case "txtdiscountrate"
          Me.m_entity.Discount.Rate = txtDiscountRate.Text
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount()
          dirtyFlag = True
        Case "cmbtaxtype"
          Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
          Me.m_entity.TaxType.Value = item.Id
          forceUpdateTaxBase = True
          forceUpdateTaxAmount = True
          forceUpdateGross = True
          UpdateAmount()
          dirtyFlag = True
        Case "txtdirectorcode"
          If directorCodeChanged Then
            dirtyFlag = Employee.GetEmployee(txtDirectorCode, txtDirectorName, Me.m_entity.Director)
            directorCodeChanged = False
          End If
        Case "txtcostcentercode"
          If ccCodeChanged Then
            dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
            'If Me.txtRequestorName.TextLength = 0 Then
            '  UpdateDestAdmin()
            'End If
            ccCodeChanged = False
          End If
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
      UpdateAmount()
    End Sub
    Private Sub ibtnResetTaxBase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxBase.Click
      If Me.m_entity.RealTaxBase <> Me.m_entity.TaxBase Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxBase = Me.m_entity.TaxBase
      UpdateAmount()
    End Sub
    Private Sub ibtnResetTaxAmount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnResetTaxAmount.Click
      If Me.m_entity.RealTaxAmount <> Me.m_entity.TaxAmount Then
        Me.WorkbenchWindow.ViewContent.IsDirty = True
      End If
      Me.m_entity.RealTaxAmount = Me.m_entity.TaxAmount
      UpdateAmount()
    End Sub
    Private forceUpdateTaxBase As Boolean = False
    Private forceUpdateGross As Boolean = False
    Private forceUpdateTaxAmount As Boolean = False
    Private Sub UpdateAmount()
      '��Ť������ͧ�͡���
      m_isInitialized = False
      Me.m_entity.RefreshTaxBase()

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
    Public Sub SetStatus()
      If m_entity.Canceled Then
        lblStatus.Text = "¡��ԡ: " & m_entity.CancelDate.ToShortDateString & _
        " " & m_entity.CancelDate.ToShortTimeString & _
        "  ��:" & m_entity.CancelPerson.Name
      ElseIf m_entity.Edited Then
        lblStatus.Text = "�����������к�: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  ��:" & m_entity.Originator.Name
        lblStatus.Text &= ",�������ش: " & m_entity.LastEditDate.ToShortDateString & _
        " " & m_entity.LastEditDate.ToShortTimeString & _
        "  ��:" & m_entity.LastEditor.Name
      ElseIf Me.m_entity.Originated Then
        lblStatus.Text = "�����������к�: " & m_entity.OriginDate.ToShortDateString & _
        " " & m_entity.OriginDate.ToShortTimeString & _
        "  ��:" & m_entity.Originator.Name
      Else
        lblStatus.Text = ""
      End If
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
        Me.m_entity = CType(Value, SC)
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
      SetTaxTypeComboBox()
    End Sub
    ' 
    Private Sub SetTaxTypeComboBox()
      CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType")
      If cmbTaxType.Items.Count > 0 Then
        Dim Vattype As Object = Configuration.GetConfig("CompanyTaxType")
        If IsNumeric(Vattype) Then
          cmbTaxType.SelectedIndex = CInt(Vattype)
        End If
        'cmbTaxType.Items.RemoveAt(1)
      End If
    End Sub
#End Region

#Region "Event Handler"
    'Private currentY As Integer = -1
    Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
      ' If tgItem.CurrentRowIndex <> currentY Then
      Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
      Me.m_entity.ItemCollection.CurrentRealItem = Me.CurrentRealTagItem
      'RefreshWBS()
      ' currentY = tgItem.CurrentRowIndex
      ' End If
    End Sub
    'Private Sub tgItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.Click
    '  Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
    '  Me.m_entity.ItemCollection.CurrentRealItem = Me.CurrentRealTagItem
    'End Sub

    'Private Sub tgItem_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.MouseEnter
    '  Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
    '  Me.m_entity.ItemCollection.CurrentRealItem = Me.CurrentRealTagItem
    'End Sub
    '        Private Sub RefreshWBS()
    '            Dim dt As TreeTable = Me.m_treeManager2.Treetable
    '            dt.Clear()
    '            Me.m_entity.ItemCollection.CurrentItem = Me.CurrentTagItem
    '            If Me.m_entity.ItemCollection.CurrentItem Is Nothing Then
    '                Return
    '            End If
    '            Dim item As SCItem = Me.m_entity.ItemCollection.CurrentItem
    '            Dim wsdColl As WBSDistributeCollection = item.WBSDistributeCollection
    '            Dim view As Integer = 6
    '            m_wbsdInitialized = False
    '            wsdColl.Populate(dt, item, view)
    '            m_wbsdInitialized = True
    '        End Sub
    Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
      UpdateAutogenStatus()
    End Sub
    Private m_oldCode As String = ""
    Private Sub UpdateAutogenStatus()
      If Me.chkAutorun.Checked Then
        'Me.Validator.SetRequired(Me.txtCode, False)
        'Me.ErrorProvider1.SetError(Me.txtCode, "")
        Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDown
        BusinessLogic.Entity.PopulateCodeCombo(Me.cmbCode, Me.m_entity.EntityId)
        m_oldCode = Me.cmbCode.Text
        Me.m_entity.Code = m_oldCode
        Me.m_entity.AutoGen = True
      Else
        'Me.Validator.SetRequired(Me.txtCode, True)
        Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
        Me.cmbCode.Items.Clear()
        Me.cmbCode.Text = m_oldCode
        Me.m_entity.AutoGen = False
      End If
    End Sub
    Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Dim filters(0) As Filter
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      If doc Is Nothing Then
        doc = New SCItem
        'doc.ItemType = New ItemType(0)
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
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
      m_targetType = -1
      If doc Is Nothing Then
        Return
        'doc = New SCItem
        ''doc.ItemType = New ItemType(0)
        'Me.m_entity.ItemCollection.Add(doc)
        'Me.m_entity.ItemCollection.CurrentItem = doc
      End If
      If doc.ItemType.Value = 19 Or doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
        m_targetType = doc.ItemType.Value
        Dim entities(1) As ISimpleEntity
        entities(0) = New LCIItem
        entities(1) = New Tool
        Dim activeIndex As Integer = -1
        If Not doc.ItemType Is Nothing Then
          If doc.ItemType.Value = 19 Then
            activeIndex = 1
          ElseIf doc.ItemType.Value = 42 Or doc.ItemType.Value = 88 Or doc.ItemType.Value = 89 Then
            activeIndex = 0
          End If
        End If
        myEntityPanelService.OpenListDialog(entities, AddressOf SetItems, activeIndex)
      End If
    End Sub
    Private Sub SetItems(ByVal items As BasketItemCollection)
      'If tgItem.CurrentRowIndex = 0 Then
      '  'Hack
      '  tgItem.CurrentRowIndex = 1
      'End If
      Dim index As Integer = tgItem.CurrentRowIndex
      Me.m_entity.ItemCollection.SetItems(items, m_targetType)
      'Me.txtReceivingDate.Text = Me.m_entity.ReceivingDate.ToShortDateString
      tgItem.CurrentRowIndex = index
      'Dim cc As CostCenter = Me.m_entity.GetCCFromPR
      'If Not cc Is Nothing AndAlso cc.Id <> Me.m_entity.CostCenter.Id Then
      '    Me.SetCostCenterDialog(cc)
      'End If
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      RefreshDocs()
      tgItem.CurrentRowIndex = index
      Me.WorkbenchWindow.ViewContent.IsDirty = True
      dirtyFlag = True
    End Sub
    Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
      'Dim index As Integer = tgItem.CurrentRowIndex
      Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentRealItem
      If doc Is Nothing Then
        Return
      End If
      'If Not doc.SCItem Is Nothing Then
      '    Return
      'End If
      'Dim newItem As New BlankItem("")
      Dim theItem As New SCItem
      'theItem.Entity = newItem
      theItem.Level = 0
      theItem.ItemType = New SCIItemType(289)
      theItem.Qty = 0
      Dim index As Integer = Me.m_entity.ItemCollection.IndexOf(doc)
      Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      RefreshDocs()
      tgItem.CurrentRowIndex = index + 1
      Me.WorkbenchWindow.ViewContent.IsDirty = True
    End Sub
        Private Sub ibtnBlankSubItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlankSubItem.Click
            Dim index As Integer = tgItem.CurrentRowIndex
            Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            'If Not doc.SCItem Is Nothing Then
            '    Return
            'End If
            Dim newItem As New BlankItem("")
            Dim theItem As New SCItem
            theItem.Level = 1
            theItem.Entity = newItem
            theItem.ItemType = New SCIItemType(0)
            theItem.Qty = 0
            Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
            RefreshDocs()
            tgItem.CurrentRowIndex = index + 1
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
            If doc Is Nothing Then
                Return
            End If
            If Not Me.m_entity.ItemCollection.Contains(doc) Then
                Return
            End If

            'Me.m_entity.ItemCollection.Remove(doc)

            Dim index As Integer = tgItem.CurrentRowIndex
            Dim isSetIndex As Boolean = False

            Dim hashParent As New Hashtable

            Dim rowIndex As Integer = 0
            Dim key As String = ""

            For Each Obj As Object In Me.m_treeManager.SelectedRows
                If Not Obj Is Nothing Then
                    Dim row As TreeRow = CType(Obj, TreeRow)
                    If Not row Is Nothing Then
                        If Not isSetIndex Then
                            index = row.Index
                            isSetIndex = True
                        End If
                        Dim sitem As SCItem = CType(row.Tag, SCItem)
                        If sitem.Level = 0 Then
                            rowIndex += 1
                            key = rowIndex.ToString
                            hashParent.Add(key, sitem)

                            Dim startIndex As Integer = row.Index
                            Dim lastIndex As Integer = row.Index
                            For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
                                If i > startIndex Then
                                    Dim sitem2 As SCItem = Me.m_entity.ItemCollection(i)
                                    If sitem2.Level = 0 Then
                                        Exit For
                                    End If
                                    rowIndex += 1
                                    key = rowIndex.ToString
                                    hashParent.Add(key, sitem2)
                                End If
                            Next
                        Else
                            rowIndex += 1
                            key = rowIndex.ToString
                            hashParent.Add(key, sitem)
                        End If
                    End If
                End If
            Next

            For i As Integer = 1 To hashParent.Count
                key = CStr(i)
                Dim sitem As SCItem = CType(hashParent(key), SCItem)
                If Not sitem Is Nothing Then
                    If Me.m_entity.ItemCollection.Contains(sitem) Then
                        Me.m_entity.ItemCollection.Remove(sitem)
                        Me.WorkbenchWindow.ViewContent.IsDirty = True
                    End If
                End If
            Next

            'Dim row As TreeRow = Me.m_treeManager.SelectedRow

            'Dim lastIndex As Integer = row.Index
            'Dim startIndex As Integer = row.Index

            'For i As Integer = startIndex To Me.m_entity.ItemCollection.Count - 1
            '  If i > startIndex Then
            '    If CType(Me.m_treeManager.Treetable.Childs(i).Tag, SCItem).Level = 0 Then
            '      Exit For
            '    End If
            '    lastIndex = i
            '  End If
            'Next

            'If lastIndex = startIndex Then
            '  Me.m_entity.ItemCollection.Remove(doc)
            'Else
            '  For i As Integer = startIndex To lastIndex
            '    Me.m_entity.ItemCollection.Remove(i)
            '  Next
            'End If

            'Dim rowsCount As Integer = 0
            'For Each Obj As Object In Me.m_treeManager.SelectedRows
            '  If Not Obj Is Nothing Then
            '    rowsCount += 1
            '    Dim row As TreeRow = CType(Obj, TreeRow)
            '    If row.Childs.Count > 0 Then
            '      For Each childRow As TreeRow In row.Childs
            '        If Not childRow Is Nothing Then
            '          Dim doc As SCItem = CType(childRow.Tag, SCItem)
            '          If Not doc Is Nothing Then
            '            Me.m_entity.ItemCollection.Remove(doc) 'ź�١ �
            '          End If
            '        End If
            '      Next
            '    End If
            '    If Not row Is Nothing Then
            '      If TypeOf row.Tag Is SCItem Then
            '        Dim doc As SCItem = CType(row.Tag, SCItem)
            '        If Not doc Is Nothing Then
            '          If Me.m_entity.ItemCollection.Contains(doc) Then
            '            Me.m_entity.ItemCollection.Remove(doc) 'ź��� �
            '          End If
            '        End If
            '      End If
            '    End If
            '  End If
            'Next

            'If rowsCount.Equals(0) Then
            '  Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentItem
            '  If doc Is Nothing Then
            '    Return
            '  End If
            '  Me.m_entity.ItemCollection.Remove(doc)
            'End If


            forceUpdateTaxBase = True
            forceUpdateTaxAmount = True
            forceUpdateGross = True
            RefreshDocs()


            If index > 0 Then
                If index > Me.m_entity.ItemCollection.Count Then
                    tgItem.CurrentRowIndex = Me.m_entity.ItemCollection.Count - 1
                Else
                    tgItem.CurrentRowIndex = index - 1
                End If
            Else
                tgItem.CurrentRowIndex = 0
            End If

            'Me.WorkbenchWindow.ViewContent.IsDirty = True
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
        Return (New SC).DetailPanelIcon
      End Get
    End Property
#End Region

#Region "Event of Button controls"
    ' Requestor
    Private Sub btnDirectorEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectorEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(Me.m_entity.Director)
    End Sub
    Private Sub btnRequestorFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDirectorFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(Me.m_entity.Director, AddressOf SetEmployeeDialog)
    End Sub

    Private Sub SetEmployeeDialog(ByVal e As ISimpleEntity)
      Me.txtDirectorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Employee.GetEmployee(txtDirectorCode, txtDirectorName, Me.m_entity.Director)
    End Sub
    ' Costcenter
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenTreeDialog(Me.m_entity.CostCenter, AddressOf SetCostCenterDialog)
    End Sub
    Private Sub SetCostCenterDialog(ByVal e As ISimpleEntity)
      If Me.txtCostCenterCode.Text <> e.Code AndAlso Me.txtCostCenterCode.Text.Length > 0 Then
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.Caption.ChangeCC}") Then
          If Me.txtCostCenterCode.TextLength = 0 Then
            Me.m_entity.CostCenter = New CostCenter
          End If
          Me.txtCostCenterCode.Text = e.Code
          dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
          If dirtyFlag Then
            'UpdateDestAdmin()
          End If
          Try
            If oldCCId <> Me.m_entity.CostCenter.Id Then
              Me.WorkbenchWindow.ViewContent.IsDirty = True
              oldCCId = Me.m_entity.CostCenter.Id
              ChangeCC()
            End If
          Catch ex As Exception
          End Try
          ccCodeChanged = False
        Else
          Me.txtCostCenterCode.Text = Me.m_entity.CostCenter.Code
          ccCodeChanged = False
        End If
      ElseIf Me.txtCostCenterCode.Text.Length = 0 Then
        Me.txtCostCenterCode.Text = e.Code
        Me.WorkbenchWindow.ViewContent.IsDirty = True
        dirtyFlag = CostCenter.GetCostCenter(txtCostCenterCode, txtCostCenterName, Me.m_entity.CostCenter, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        If dirtyFlag Then
          'UpdateDestAdmin()
        End If
      End If
      SetCCCodeBlankFlag()
    End Sub
    Private Sub btnCCEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(Me.m_entity.CostCenter)
    End Sub
    Private Sub ChangeCC()
      'For Each item As SCItem In Me.m_entity.ItemCollection
      '    item.WBSDistributeCollection.Clear()
      'Next
      'RefreshWBS()

    End Sub
    'Private Sub UpdateDestAdmin()
    '  If Me.m_entity Is Nothing Then
    '    Return
    '  End If
    '  Dim flag As Boolean = Me.m_isInitialized
    '  Me.m_isInitialized = False
    '  Try
    '            Me.m_entity.Director = Me.m_entity.CostCenter.Admin
    '            Me.txtDirectorCode.Text = m_entity.Director.Code
    '            txtDirectorName.Text = m_entity.Director.Name
    '  Catch ex As Exception
    '  Finally
    '    Me.m_isInitialized = flag
    '  End Try
    'End Sub
    '        Private Sub ibtnShowPR_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '            Dim dlg As New BasketDialog
    '            AddHandler dlg.EmptyBasket, AddressOf SetItems

    '            Dim filters(4) As Filter
    '            Dim excludeList As Object = ""
    '            excludeList = GetPRExcludeList()
    '            If excludeList.ToString.Length = 0 Then
    '                excludeList = DBNull.Value
    '            End If
    '            Dim prNeedsApproval As Boolean = False
    '            Dim prNeedsStoreApproval As Boolean = False
    '            prNeedsApproval = CBool(Configuration.GetConfig("ApprovePR"))
    '            prNeedsStoreApproval = CBool(Configuration.GetConfig("PRNeedStoreApprove"))
    '            filters(0) = New Filter("excludeList", excludeList)
    '            filters(1) = New Filter("prNeedsApproval", prNeedsApproval)
    '            filters(2) = New Filter("excludeCanceled", True)
    '            filters(3) = New Filter("PRNeedStoreApprove", prNeedsStoreApproval)
    '            filters(4) = New Filter("formEntity", Me.m_entity.EntityId)

    '            Dim Entities As New ArrayList
    '            If Not Me.m_entity.CostCenter Is Nothing AndAlso Me.m_entity.CostCenter.Originated Then
    '                Entities.Add(Me.m_entity.CostCenter)
    '            End If

    '            Dim view As AbstractEntityPanelViewContent = New PRSelectionView(New PR, New BasketDialog, filters, Entities)
    '            dlg.Lists.Add(view)
    '            Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDockingDialog(view, dlg)
    '            myDialog.ShowDialog()
    '        End Sub
    '        Private Function GetPRExcludeList() As String
    '            Dim ret As String = ""
    '            For Each item As SCItem In Me.m_entity.ItemCollection
    '                If Not item.SCItem Is Nothing Then
    '                    ret &= "|" & item.SCItem.Pr.Id.ToString & ":" & item.SCItem.LineNumber.ToString & "|"
    '                End If
    '            Next
    '            Return ret
    '        End Function
    Private Sub ibtnGetFromBOQ_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnGetFromBOQ.Click
      Dim arr As New ArrayList
      arr.Add(Me.m_entity.CostCenter)
      Dim myEntityPanelService As IEntityPanelService = _
                  CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New BOQWBSForSelection, AddressOf SetItems, arr)
    End Sub

    ' Supplier
    Private Sub btnSupplierEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubContractorEdit.Click
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenPanel(New Supplier)
    End Sub
    Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSubContractorFind.Click
      Dim myEntityPanelService As IEntityPanelService = _
      CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      myEntityPanelService.OpenListDialog(New Supplier, AddressOf SetSupplierDialog)
    End Sub
    Private Sub SetSupplierDialog(ByVal e As ISimpleEntity)
      Me.txtSubContractorCode.Text = e.Code
      Me.WorkbenchWindow.ViewContent.IsDirty = _
          Me.WorkbenchWindow.ViewContent.IsDirty _
          Or Supplier.GetSupplier(txtSubContractorCode, txtSubContractorName, Me.m_entity.SubContractor, True)
      'm_isInitialized = False
      'Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
      'Me.dtpDueDate.Value = MaxDtpDate(Me.m_entity.DueDate)
      'm_isInitialized = True
    End Sub
    '        Private Sub btnApprove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '            ''PJMModule
    '            'Dim x As Form
    '            '   If m_ApproveDocModule.Activated Then
    '            '	x = New AdvanceApprovalCommentForm(Me.Entity)
    '            '   Else
    '            '	x = New ApprovalCommentForm(Me.Entity)
    '            'End If
    '            'x.ShowDialog()
    '            'CheckFormEnable()
    '        End Sub
#End Region

#Region "IClipboardHandler Overrides"
    Public Overrides ReadOnly Property EnablePaste() As Boolean
      Get
        Dim data As IDataObject = Clipboard.GetDataObject
        If data.GetDataPresent((New Supplier).FullClassName) Then
          If Not Me.ActiveControl Is Nothing Then
            Select Case Me.ActiveControl.Name.ToLower
              Case "txtsuppliercode", "txtsuppliername"
                Return True
            End Select
          End If
        End If
        Return False
      End Get
    End Property
    Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
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

      'Dim index As Integer = tgItem.CurrentRowIndex
      'Dim doc As SCItem = Me.m_entity.ItemCollection.CurrentRealItem
      'If doc Is Nothing Then
      '  Return
      'End If
      ''If Not doc.SCItem Is Nothing Then
      ''    Return
      ''End If
      ''Dim newItem As New BlankItem("")
      'Dim theItem As New SCItem
      ''theItem.Entity = newItem
      'theItem.Level = 0
      ''theItem.ItemType = New ItemType(0)
      'theItem.Qty = 0
      'Me.m_entity.ItemCollection.Insert(Me.m_entity.ItemCollection.IndexOf(doc) + 1, theItem)
      'RefreshDocs()
      'tgItem.CurrentRowIndex = index + 1
      'Me.WorkbenchWindow.ViewContent.IsDirty = True

      Do Until Me.m_treeManager.Treetable.Rows.Count > tgItem.VisibleRowCount
        '�����Ǩ����
        'Me.m_treeManager.Treetable.Childs.Add()
        Dim newRow As TreeRow
        newRow = Me.m_treeManager.Treetable.Childs.Add()
        newRow("sci_level") = 0
        newRow("Button") = "invisible"
      Loop

      If Me.m_entity.ItemCollection.Count = Me.m_treeManager.Treetable.Childs.Count Then
        '�����ա 1 �� ����բ����Ũ��֧���ش����
        'Me.m_treeManager.Treetable.Childs.Add()
        Dim newRow As TreeRow
        newRow = Me.m_treeManager.Treetable.Childs.Add()
        newRow("sci_level") = 0
        newRow("Button") = "invisible"
      End If

      'For rowIndex As Integer = 0 To Me.m_treeManager.Treetable.Rows.Count
      '  Dim n As TreeRow = Me.m_treeManager.Treetable.Childs(rowIndex)
      '  If n("sci_level") = 0 Then
      '    Me.tgItem.TableStyles(0).GridColumnStyles(0).c()
      '  End If
      'Next

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
      Me.m_entity.Closing = Me.chkClosed.Checked
      If Me.m_entity.Closing Then
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosedCancel}")
        If Not Me.m_entity.Closed Then
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        Else
          Me.WorkbenchWindow.ViewContent.IsDirty = False
        End If
      Else
        Me.chkClosed.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SCPanelView.chkClosed}")
        If Not Me.m_entity.Closed Then
          Me.WorkbenchWindow.ViewContent.IsDirty = False
        Else
          Me.WorkbenchWindow.ViewContent.IsDirty = True
        End If
      End If
      'Me.SetColumnOriginQty()
      forceUpdateTaxBase = True
      forceUpdateTaxAmount = True
      forceUpdateGross = True
      Me.RefreshDocs()
      'Me.RefreshWBS()


    End Sub

#Region "Customization"
    Public Overrides ReadOnly Property CanPrint() As Boolean
      Get
        Try
          Dim approveDocColl As New ApproveDocCollection(m_entity)
          Dim poNeedsApproval As Boolean = CBool(Configuration.GetConfig("POApproveBeforePrint"))
          If poNeedsApproval Then
            If Not approveDocColl.IsApproved Then
              Return False
            End If
          End If
        Catch ex As Exception
        End Try
        Return MyBase.CanPrint
      End Get
    End Property
#End Region

  End Class
End Namespace

