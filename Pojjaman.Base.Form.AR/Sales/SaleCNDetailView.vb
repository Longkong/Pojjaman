Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services

Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Gui.Components
Imports System.Globalization
Imports System.Reflection
Imports System.Drawing.Printing
Imports Longkong.Pojjaman.Gui.ReportsAndDocs
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class SaleCNDetailView
        Inherits AbstractEntityDetailPanelView
        Implements IValidatable

#Region " Windows Form Designer generated code "
        Friend WithEvents chkAutorun As System.Windows.Forms.CheckBox
        Friend WithEvents txtDocDate As System.Windows.Forms.TextBox
        Friend WithEvents ibtnAddWBS As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents tgWBS As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents ibtnDelWBS As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblWBS As System.Windows.Forms.Label
        Friend WithEvents dtpDocDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents lblDocDate As System.Windows.Forms.Label
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents grbDelivery As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtCustomerName As System.Windows.Forms.TextBox
        Friend WithEvents lblCustomer As System.Windows.Forms.Label
        Friend WithEvents txtCustomerCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCreditPrd As System.Windows.Forms.Label
        Friend WithEvents lblDay As System.Windows.Forms.Label
        Friend WithEvents txtCreditPrd As System.Windows.Forms.TextBox
        Friend WithEvents lblDueDate As System.Windows.Forms.Label
        Friend WithEvents txtDueDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpDueDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents ibtnBlankDoc As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelDoc As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnBlank As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnDelRow As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblPercent As System.Windows.Forms.Label
        Friend WithEvents txtTaxBase As System.Windows.Forms.TextBox
        Friend WithEvents txtBeforeTax As System.Windows.Forms.TextBox
        Friend WithEvents txtTaxAmount As System.Windows.Forms.TextBox
        Friend WithEvents lblGross As System.Windows.Forms.Label
        Friend WithEvents lblTaxAmount As System.Windows.Forms.Label
        Friend WithEvents txtGross As System.Windows.Forms.TextBox
        Friend WithEvents txtDiscountRate As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxType As System.Windows.Forms.Label
        Friend WithEvents txtAfterTax As System.Windows.Forms.TextBox
        Friend WithEvents lblAfterTax As System.Windows.Forms.Label
        Friend WithEvents lblDiscountAmount As System.Windows.Forms.Label
        Friend WithEvents lblTaxBase As System.Windows.Forms.Label
        Friend WithEvents lblBeforeTax As System.Windows.Forms.Label
        Friend WithEvents cmbTaxType As System.Windows.Forms.ComboBox
        Friend WithEvents txtDiscountAmount As System.Windows.Forms.TextBox
        Friend WithEvents txtTaxRate As System.Windows.Forms.TextBox
        Friend WithEvents lblTaxRate As System.Windows.Forms.Label
        Friend WithEvents grbSummary As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents lbOrgTotalUnit As System.Windows.Forms.Label
        Friend WithEvents lblOrgTotal As System.Windows.Forms.Label
        Friend WithEvents lblAdjValUnit As System.Windows.Forms.Label
        Friend WithEvents lblAdjVal As System.Windows.Forms.Label
        Friend WithEvents txtAdjVal As System.Windows.Forms.TextBox
        Friend WithEvents txtDiff As System.Windows.Forms.TextBox
        Friend WithEvents lblDiffUnit As System.Windows.Forms.Label
        Friend WithEvents lblDiff As System.Windows.Forms.Label
        Friend WithEvents txtOrgTotal As System.Windows.Forms.TextBox
        Friend WithEvents tgRefDoc As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents lblNote As System.Windows.Forms.Label
        Friend WithEvents lblItem As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents lblItemRf As System.Windows.Forms.Label
        Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
        Friend WithEvents txtNote As System.Windows.Forms.TextBox
        Friend WithEvents ibtnShowNote As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents chkAutoRunVat As System.Windows.Forms.CheckBox
        Friend WithEvents lblInvoiceCode As System.Windows.Forms.Label
        Friend WithEvents txtInvoiceCode As System.Windows.Forms.TextBox
        Friend WithEvents lblInvoiceDate As System.Windows.Forms.Label
        Friend WithEvents txtInvoiceDate As System.Windows.Forms.TextBox
        Friend WithEvents dtpInvoiceDate As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtToCostCenterName As System.Windows.Forms.TextBox
        Friend WithEvents txtToCostCenterCode As System.Windows.Forms.TextBox
        Friend WithEvents lblToCostCenter As System.Windows.Forms.Label
        Friend WithEvents ibtnShowCustomer As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowCustomerDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents ibtnShowToCostCenter As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents cmbCode As System.Windows.Forms.ComboBox
        Friend WithEvents ibtnShowToCostCenterDialog As Longkong.Pojjaman.Gui.Components.ImageButton
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(SaleCNDetailView))
            Me.chkAutorun = New System.Windows.Forms.CheckBox()
            Me.txtDocDate = New System.Windows.Forms.TextBox()
            Me.ibtnAddWBS = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
            Me.txtDueDate = New System.Windows.Forms.TextBox()
            Me.txtInvoiceDate = New System.Windows.Forms.TextBox()
            Me.cmbCode = New System.Windows.Forms.ComboBox()
            Me.tgWBS = New Longkong.Pojjaman.Gui.Components.TreeGrid()
            Me.ibtnDelWBS = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblWBS = New System.Windows.Forms.Label()
            Me.dtpDocDate = New System.Windows.Forms.DateTimePicker()
            Me.lblDocDate = New System.Windows.Forms.Label()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.grbDelivery = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.ibtnShowCustomer = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnShowCustomerDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.txtCustomerName = New System.Windows.Forms.TextBox()
            Me.lblCustomer = New System.Windows.Forms.Label()
            Me.txtCustomerCode = New System.Windows.Forms.TextBox()
            Me.lblCreditPrd = New System.Windows.Forms.Label()
            Me.lblDay = New System.Windows.Forms.Label()
            Me.txtCreditPrd = New System.Windows.Forms.TextBox()
            Me.lblDueDate = New System.Windows.Forms.Label()
            Me.dtpDueDate = New System.Windows.Forms.DateTimePicker()
            Me.ibtnBlankDoc = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnDelDoc = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnBlank = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnDelRow = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblPercent = New System.Windows.Forms.Label()
            Me.txtTaxBase = New System.Windows.Forms.TextBox()
            Me.txtBeforeTax = New System.Windows.Forms.TextBox()
            Me.txtTaxAmount = New System.Windows.Forms.TextBox()
            Me.lblGross = New System.Windows.Forms.Label()
            Me.lblTaxAmount = New System.Windows.Forms.Label()
            Me.txtGross = New System.Windows.Forms.TextBox()
            Me.txtDiscountRate = New System.Windows.Forms.TextBox()
            Me.lblTaxType = New System.Windows.Forms.Label()
            Me.txtAfterTax = New System.Windows.Forms.TextBox()
            Me.lblAfterTax = New System.Windows.Forms.Label()
            Me.lblDiscountAmount = New System.Windows.Forms.Label()
            Me.lblTaxBase = New System.Windows.Forms.Label()
            Me.lblBeforeTax = New System.Windows.Forms.Label()
            Me.cmbTaxType = New System.Windows.Forms.ComboBox()
            Me.txtDiscountAmount = New System.Windows.Forms.TextBox()
            Me.txtTaxRate = New System.Windows.Forms.TextBox()
            Me.lblTaxRate = New System.Windows.Forms.Label()
            Me.grbSummary = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.lbOrgTotalUnit = New System.Windows.Forms.Label()
            Me.lblOrgTotal = New System.Windows.Forms.Label()
            Me.lblAdjValUnit = New System.Windows.Forms.Label()
            Me.lblAdjVal = New System.Windows.Forms.Label()
            Me.txtAdjVal = New System.Windows.Forms.TextBox()
            Me.txtDiff = New System.Windows.Forms.TextBox()
            Me.lblDiffUnit = New System.Windows.Forms.Label()
            Me.lblDiff = New System.Windows.Forms.Label()
            Me.txtOrgTotal = New System.Windows.Forms.TextBox()
            Me.tgRefDoc = New Longkong.Pojjaman.Gui.Components.TreeGrid()
            Me.lblNote = New System.Windows.Forms.Label()
            Me.lblItem = New System.Windows.Forms.Label()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.txtNote = New System.Windows.Forms.TextBox()
            Me.txtInvoiceCode = New System.Windows.Forms.TextBox()
            Me.txtToCostCenterName = New System.Windows.Forms.TextBox()
            Me.txtToCostCenterCode = New System.Windows.Forms.TextBox()
            Me.lblItemRf = New System.Windows.Forms.Label()
            Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
            Me.ibtnShowNote = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.chkAutoRunVat = New System.Windows.Forms.CheckBox()
            Me.lblInvoiceCode = New System.Windows.Forms.Label()
            Me.lblInvoiceDate = New System.Windows.Forms.Label()
            Me.dtpInvoiceDate = New System.Windows.Forms.DateTimePicker()
            Me.lblToCostCenter = New System.Windows.Forms.Label()
            Me.ibtnShowToCostCenter = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.ibtnShowToCostCenterDialog = New Longkong.Pojjaman.Gui.Components.ImageButton()
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.grbDelivery.SuspendLayout()
            Me.grbSummary.SuspendLayout()
            CType(Me.tgRefDoc, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            '
            'chkAutorun
            '
            Me.chkAutorun.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutorun.Image = CType(resources.GetObject("chkAutorun.Image"), System.Drawing.Image)
            Me.chkAutorun.Location = New System.Drawing.Point(202, 16)
            Me.chkAutorun.Name = "chkAutorun"
            Me.chkAutorun.Size = New System.Drawing.Size(21, 21)
            Me.chkAutorun.TabIndex = 10
            '
            'txtDocDate
            '
            Me.Validator.SetDataType(Me.txtDocDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDate, 15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDate, System.Drawing.Color.Empty)
            Me.txtDocDate.Location = New System.Drawing.Point(265, 16)
            Me.Validator.SetMaxValue(Me.txtDocDate, "")
            Me.Validator.SetMinValue(Me.txtDocDate, "")
            Me.txtDocDate.Name = "txtDocDate"
            Me.Validator.SetRegularExpression(Me.txtDocDate, "")
            Me.Validator.SetRequired(Me.txtDocDate, True)
            Me.txtDocDate.Size = New System.Drawing.Size(78, 21)
            Me.txtDocDate.TabIndex = 1
            '
            'ibtnAddWBS
            '
            Me.ibtnAddWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnAddWBS.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnAddWBS.Location = New System.Drawing.Point(104, 400)
            Me.ibtnAddWBS.Name = "ibtnAddWBS"
            Me.ibtnAddWBS.Size = New System.Drawing.Size(24, 24)
            Me.ibtnAddWBS.TabIndex = 95
            Me.ibtnAddWBS.TabStop = False
            Me.ibtnAddWBS.ThemedImage = CType(resources.GetObject("ibtnAddWBS.ThemedImage"), System.Drawing.Bitmap)
            Me.ibtnAddWBS.Visible = False
            '
            'ErrorProvider1
            '
            Me.ErrorProvider1.ContainerControl = Me
            '
            'txtDueDate
            '
            Me.Validator.SetDataType(Me.txtDueDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDueDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDueDate, 15)
            Me.Validator.SetInvalidBackColor(Me.txtDueDate, System.Drawing.Color.Empty)
            Me.txtDueDate.Location = New System.Drawing.Point(272, 40)
            Me.Validator.SetMaxValue(Me.txtDueDate, "")
            Me.Validator.SetMinValue(Me.txtDueDate, "")
            Me.txtDueDate.Name = "txtDueDate"
            Me.Validator.SetRegularExpression(Me.txtDueDate, "")
            Me.Validator.SetRequired(Me.txtDueDate, False)
            Me.txtDueDate.Size = New System.Drawing.Size(78, 21)
            Me.txtDueDate.TabIndex = 6
            '
            'txtInvoiceDate
            '
            Me.Validator.SetDataType(Me.txtInvoiceDate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtInvoiceDate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtInvoiceDate, 15)
            Me.Validator.SetInvalidBackColor(Me.txtInvoiceDate, System.Drawing.Color.Empty)
            Me.txtInvoiceDate.Location = New System.Drawing.Point(265, 40)
            Me.Validator.SetMaxValue(Me.txtInvoiceDate, "")
            Me.Validator.SetMinValue(Me.txtInvoiceDate, "")
            Me.txtInvoiceDate.Name = "txtInvoiceDate"
            Me.Validator.SetRegularExpression(Me.txtInvoiceDate, "")
            Me.Validator.SetRequired(Me.txtInvoiceDate, False)
            Me.txtInvoiceDate.Size = New System.Drawing.Size(78, 21)
            Me.txtInvoiceDate.TabIndex = 3
            '
            'cmbCode
            '
            Me.cmbCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.ErrorProvider1.SetIconPadding(Me.cmbCode, -15)
            Me.cmbCode.Location = New System.Drawing.Point(96, 16)
            Me.cmbCode.Name = "cmbCode"
            Me.cmbCode.Size = New System.Drawing.Size(107, 21)
            Me.cmbCode.TabIndex = 108
            '
            'tgWBS
            '
            Me.tgWBS.AllowNew = False
            Me.tgWBS.AllowSorting = False
            Me.tgWBS.Anchor = CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgWBS.AutoColumnResize = True
            Me.tgWBS.CaptionVisible = False
            Me.tgWBS.Cellchanged = False
            Me.tgWBS.ColorList.AddRange(New System.Drawing.Color() {System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(128, Byte), Integer)), System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))})
            Me.tgWBS.DataMember = ""
            Me.tgWBS.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgWBS.Location = New System.Drawing.Point(8, 424)
            Me.tgWBS.Name = "tgWBS"
            Me.tgWBS.Size = New System.Drawing.Size(320, 128)
            Me.tgWBS.SortingArrowColor = System.Drawing.Color.Red
            Me.tgWBS.TabIndex = 93
            Me.tgWBS.TreeManager = Nothing
            Me.tgWBS.Visible = False
            '
            'ibtnDelWBS
            '
            Me.ibtnDelWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.ibtnDelWBS.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnDelWBS.Location = New System.Drawing.Point(128, 400)
            Me.ibtnDelWBS.Name = "ibtnDelWBS"
            Me.ibtnDelWBS.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelWBS.TabIndex = 96
            Me.ibtnDelWBS.TabStop = False
            Me.ibtnDelWBS.ThemedImage = CType(resources.GetObject("ibtnDelWBS.ThemedImage"), System.Drawing.Bitmap)
            Me.ibtnDelWBS.Visible = False
            '
            'lblWBS
            '
            Me.lblWBS.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.lblWBS.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblWBS.ForeColor = System.Drawing.Color.Black
            Me.lblWBS.Location = New System.Drawing.Point(8, 408)
            Me.lblWBS.Name = "lblWBS"
            Me.lblWBS.Size = New System.Drawing.Size(96, 18)
            Me.lblWBS.TabIndex = 94
            Me.lblWBS.Text = "�Ѵ��� WBS:"
            Me.lblWBS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            Me.lblWBS.Visible = False
            '
            'dtpDocDate
            '
            Me.dtpDocDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDocDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDocDate.Location = New System.Drawing.Point(265, 16)
            Me.dtpDocDate.Name = "dtpDocDate"
            Me.dtpDocDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpDocDate.TabIndex = 11
            Me.dtpDocDate.TabStop = False
            '
            'lblDocDate
            '
            Me.lblDocDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDate.ForeColor = System.Drawing.Color.Black
            Me.lblDocDate.Location = New System.Drawing.Point(225, 16)
            Me.lblDocDate.Name = "lblDocDate"
            Me.lblDocDate.Size = New System.Drawing.Size(40, 18)
            Me.lblDocDate.TabIndex = 66
            Me.lblDocDate.Text = "�ѹ���:"
            Me.lblDocDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 62
            Me.lblCode.Text = "�Ţ����Ŵ˹��:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbDelivery
            '
            Me.grbDelivery.Controls.Add(Me.ibtnShowCustomer)
            Me.grbDelivery.Controls.Add(Me.ibtnShowCustomerDialog)
            Me.grbDelivery.Controls.Add(Me.txtCustomerName)
            Me.grbDelivery.Controls.Add(Me.lblCustomer)
            Me.grbDelivery.Controls.Add(Me.txtCustomerCode)
            Me.grbDelivery.Controls.Add(Me.lblCreditPrd)
            Me.grbDelivery.Controls.Add(Me.lblDay)
            Me.grbDelivery.Controls.Add(Me.txtCreditPrd)
            Me.grbDelivery.Controls.Add(Me.lblDueDate)
            Me.grbDelivery.Controls.Add(Me.txtDueDate)
            Me.grbDelivery.Controls.Add(Me.dtpDueDate)
            Me.grbDelivery.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDelivery.Location = New System.Drawing.Point(376, 0)
            Me.grbDelivery.Name = "grbDelivery"
            Me.grbDelivery.Size = New System.Drawing.Size(384, 72)
            Me.grbDelivery.TabIndex = 56
            Me.grbDelivery.TabStop = False
            Me.grbDelivery.Text = "�����"
            '
            'ibtnShowCustomer
            '
            Me.ibtnShowCustomer.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCustomer.Location = New System.Drawing.Point(344, 16)
            Me.ibtnShowCustomer.Name = "ibtnShowCustomer"
            Me.ibtnShowCustomer.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowCustomer.TabIndex = 15
            Me.ibtnShowCustomer.TabStop = False
            Me.ibtnShowCustomer.ThemedImage = CType(resources.GetObject("ibtnShowCustomer.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowCustomerDialog
            '
            Me.ibtnShowCustomerDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowCustomerDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowCustomerDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowCustomerDialog.Location = New System.Drawing.Point(320, 16)
            Me.ibtnShowCustomerDialog.Name = "ibtnShowCustomerDialog"
            Me.ibtnShowCustomerDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowCustomerDialog.TabIndex = 14
            Me.ibtnShowCustomerDialog.TabStop = False
            Me.ibtnShowCustomerDialog.ThemedImage = CType(resources.GetObject("ibtnShowCustomerDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtCustomerName
            '
            Me.txtCustomerName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtCustomerName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerName, System.Drawing.Color.Empty)
            Me.txtCustomerName.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMaxValue(Me.txtCustomerName, "")
            Me.Validator.SetMinValue(Me.txtCustomerName, "")
            Me.txtCustomerName.Name = "txtCustomerName"
            Me.txtCustomerName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCustomerName, "")
            Me.Validator.SetRequired(Me.txtCustomerName, False)
            Me.txtCustomerName.Size = New System.Drawing.Size(168, 21)
            Me.txtCustomerName.TabIndex = 4
            Me.txtCustomerName.TabStop = False
            '
            'lblCustomer
            '
            Me.lblCustomer.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCustomer.Location = New System.Drawing.Point(8, 16)
            Me.lblCustomer.Name = "lblCustomer"
            Me.lblCustomer.Size = New System.Drawing.Size(80, 18)
            Me.lblCustomer.TabIndex = 4
            Me.lblCustomer.Text = "�����:"
            Me.lblCustomer.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCustomerCode
            '
            Me.txtCustomerCode.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCustomerCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCustomerCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCustomerCode, System.Drawing.Color.Empty)
            Me.txtCustomerCode.Location = New System.Drawing.Point(88, 16)
            Me.txtCustomerCode.MaxLength = 20
            Me.Validator.SetMaxValue(Me.txtCustomerCode, "")
            Me.Validator.SetMinValue(Me.txtCustomerCode, "")
            Me.txtCustomerCode.Name = "txtCustomerCode"
            Me.Validator.SetRegularExpression(Me.txtCustomerCode, "")
            Me.Validator.SetRequired(Me.txtCustomerCode, True)
            Me.txtCustomerCode.Size = New System.Drawing.Size(64, 21)
            Me.txtCustomerCode.TabIndex = 4
            '
            'lblCreditPrd
            '
            Me.lblCreditPrd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCreditPrd.Location = New System.Drawing.Point(8, 40)
            Me.lblCreditPrd.Name = "lblCreditPrd"
            Me.lblCreditPrd.Size = New System.Drawing.Size(80, 18)
            Me.lblCreditPrd.TabIndex = 3
            Me.lblCreditPrd.Text = "�����ôԵ:"
            Me.lblCreditPrd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDay
            '
            Me.lblDay.AutoSize = True
            Me.lblDay.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDay.Location = New System.Drawing.Point(152, 42)
            Me.lblDay.Name = "lblDay"
            Me.lblDay.Size = New System.Drawing.Size(19, 13)
            Me.lblDay.TabIndex = 5
            Me.lblDay.Text = "�ѹ"
            Me.lblDay.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'txtCreditPrd
            '
            Me.txtCreditPrd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtCreditPrd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.Int16Type)
            Me.Validator.SetDisplayName(Me.txtCreditPrd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCreditPrd, System.Drawing.Color.Empty)
            Me.txtCreditPrd.Location = New System.Drawing.Point(88, 40)
            Me.Validator.SetMaxValue(Me.txtCreditPrd, "")
            Me.Validator.SetMinValue(Me.txtCreditPrd, "0")
            Me.txtCreditPrd.Name = "txtCreditPrd"
            Me.Validator.SetRegularExpression(Me.txtCreditPrd, "")
            Me.Validator.SetRequired(Me.txtCreditPrd, False)
            Me.txtCreditPrd.Size = New System.Drawing.Size(64, 21)
            Me.txtCreditPrd.TabIndex = 5
            '
            'lblDueDate
            '
            Me.lblDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDueDate.ForeColor = System.Drawing.Color.Black
            Me.lblDueDate.Location = New System.Drawing.Point(176, 41)
            Me.lblDueDate.Name = "lblDueDate"
            Me.lblDueDate.Size = New System.Drawing.Size(88, 18)
            Me.lblDueDate.TabIndex = 6
            Me.lblDueDate.Text = "�ѹ���:"
            Me.lblDueDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDueDate
            '
            Me.dtpDueDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpDueDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpDueDate.Location = New System.Drawing.Point(272, 40)
            Me.dtpDueDate.Name = "dtpDueDate"
            Me.dtpDueDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpDueDate.TabIndex = 16
            Me.dtpDueDate.TabStop = False
            '
            'ibtnBlankDoc
            '
            Me.ibtnBlankDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnBlankDoc.Location = New System.Drawing.Point(104, 80)
            Me.ibtnBlankDoc.Name = "ibtnBlankDoc"
            Me.ibtnBlankDoc.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlankDoc.TabIndex = 71
            Me.ibtnBlankDoc.TabStop = False
            Me.ibtnBlankDoc.ThemedImage = CType(resources.GetObject("ibtnBlankDoc.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelDoc
            '
            Me.ibtnDelDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnDelDoc.Location = New System.Drawing.Point(128, 80)
            Me.ibtnDelDoc.Name = "ibtnDelDoc"
            Me.ibtnDelDoc.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelDoc.TabIndex = 72
            Me.ibtnDelDoc.TabStop = False
            Me.ibtnDelDoc.ThemedImage = CType(resources.GetObject("ibtnDelDoc.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnBlank
            '
            Me.ibtnBlank.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnBlank.Location = New System.Drawing.Point(104, 224)
            Me.ibtnBlank.Name = "ibtnBlank"
            Me.ibtnBlank.Size = New System.Drawing.Size(24, 24)
            Me.ibtnBlank.TabIndex = 75
            Me.ibtnBlank.TabStop = False
            Me.ibtnBlank.ThemedImage = CType(resources.GetObject("ibtnBlank.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnDelRow
            '
            Me.ibtnDelRow.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnDelRow.Location = New System.Drawing.Point(128, 224)
            Me.ibtnDelRow.Name = "ibtnDelRow"
            Me.ibtnDelRow.Size = New System.Drawing.Size(24, 24)
            Me.ibtnDelRow.TabIndex = 76
            Me.ibtnDelRow.TabStop = False
            Me.ibtnDelRow.ThemedImage = CType(resources.GetObject("ibtnDelRow.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblPercent
            '
            Me.lblPercent.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblPercent.BackColor = System.Drawing.Color.Transparent
            Me.lblPercent.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblPercent.Location = New System.Drawing.Point(560, 493)
            Me.lblPercent.Name = "lblPercent"
            Me.lblPercent.Size = New System.Drawing.Size(16, 18)
            Me.lblPercent.TabIndex = 84
            Me.lblPercent.Text = "%"
            Me.lblPercent.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtTaxBase
            '
            Me.txtTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxBase.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxBase, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxBase, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxBase, System.Drawing.Color.Empty)
            Me.txtTaxBase.Location = New System.Drawing.Point(656, 471)
            Me.Validator.SetMaxValue(Me.txtTaxBase, "")
            Me.Validator.SetMinValue(Me.txtTaxBase, "")
            Me.txtTaxBase.Name = "txtTaxBase"
            Me.txtTaxBase.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxBase, "")
            Me.Validator.SetRequired(Me.txtTaxBase, False)
            Me.txtTaxBase.Size = New System.Drawing.Size(144, 21)
            Me.txtTaxBase.TabIndex = 90
            Me.txtTaxBase.TabStop = False
            Me.txtTaxBase.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtBeforeTax
            '
            Me.txtBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtBeforeTax.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtBeforeTax, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBeforeTax, "")
            Me.Validator.SetGotFocusBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBeforeTax, System.Drawing.Color.Empty)
            Me.txtBeforeTax.Location = New System.Drawing.Point(656, 450)
            Me.Validator.SetMaxValue(Me.txtBeforeTax, "")
            Me.Validator.SetMinValue(Me.txtBeforeTax, "")
            Me.txtBeforeTax.Name = "txtBeforeTax"
            Me.txtBeforeTax.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBeforeTax, "")
            Me.Validator.SetRequired(Me.txtBeforeTax, False)
            Me.txtBeforeTax.Size = New System.Drawing.Size(144, 21)
            Me.txtBeforeTax.TabIndex = 89
            Me.txtBeforeTax.TabStop = False
            Me.txtBeforeTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtTaxAmount
            '
            Me.txtTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxAmount.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTaxAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxAmount, System.Drawing.Color.Empty)
            Me.txtTaxAmount.Location = New System.Drawing.Point(656, 492)
            Me.Validator.SetMaxValue(Me.txtTaxAmount, "")
            Me.Validator.SetMinValue(Me.txtTaxAmount, "")
            Me.txtTaxAmount.Name = "txtTaxAmount"
            Me.txtTaxAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtTaxAmount, "")
            Me.Validator.SetRequired(Me.txtTaxAmount, False)
            Me.txtTaxAmount.Size = New System.Drawing.Size(144, 21)
            Me.txtTaxAmount.TabIndex = 91
            Me.txtTaxAmount.TabStop = False
            Me.txtTaxAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblGross
            '
            Me.lblGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblGross.BackColor = System.Drawing.Color.Transparent
            Me.lblGross.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblGross.Location = New System.Drawing.Point(576, 409)
            Me.lblGross.Name = "lblGross"
            Me.lblGross.Size = New System.Drawing.Size(80, 18)
            Me.lblGross.TabIndex = 80
            Me.lblGross.Text = "�ʹ�Թ��� :"
            Me.lblGross.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTaxAmount
            '
            Me.lblTaxAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxAmount.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxAmount.Location = New System.Drawing.Point(576, 493)
            Me.lblTaxAmount.Name = "lblTaxAmount"
            Me.lblTaxAmount.Size = New System.Drawing.Size(80, 18)
            Me.lblTaxAmount.TabIndex = 85
            Me.lblTaxAmount.Text = "������Ť������ :"
            Me.lblTaxAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtGross
            '
            Me.txtGross.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtGross.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtGross, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtGross, "")
            Me.Validator.SetGotFocusBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtGross, System.Drawing.Color.Empty)
            Me.txtGross.Location = New System.Drawing.Point(656, 408)
            Me.Validator.SetMaxValue(Me.txtGross, "")
            Me.Validator.SetMinValue(Me.txtGross, "")
            Me.txtGross.Name = "txtGross"
            Me.txtGross.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtGross, "")
            Me.Validator.SetRequired(Me.txtGross, False)
            Me.txtGross.Size = New System.Drawing.Size(144, 21)
            Me.txtGross.TabIndex = 87
            Me.txtGross.TabStop = False
            Me.txtGross.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDiscountRate
            '
            Me.txtDiscountRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDiscountRate.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDiscountRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDiscountRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDiscountRate, System.Drawing.Color.Empty)
            Me.txtDiscountRate.Location = New System.Drawing.Point(560, 429)
            Me.Validator.SetMaxValue(Me.txtDiscountRate, "")
            Me.Validator.SetMinValue(Me.txtDiscountRate, "")
            Me.txtDiscountRate.Name = "txtDiscountRate"
            Me.Validator.SetRegularExpression(Me.txtDiscountRate, "")
            Me.Validator.SetRequired(Me.txtDiscountRate, False)
            Me.txtDiscountRate.Size = New System.Drawing.Size(88, 21)
            Me.txtDiscountRate.TabIndex = 8
            '
            'lblTaxType
            '
            Me.lblTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxType.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxType.Location = New System.Drawing.Point(328, 493)
            Me.lblTaxType.Name = "lblTaxType"
            Me.lblTaxType.Size = New System.Drawing.Size(72, 18)
            Me.lblTaxType.TabIndex = 77
            Me.lblTaxType.Text = "����������:"
            Me.lblTaxType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
            Me.txtAfterTax.Location = New System.Drawing.Point(656, 513)
            Me.Validator.SetMaxValue(Me.txtAfterTax, "")
            Me.Validator.SetMinValue(Me.txtAfterTax, "")
            Me.txtAfterTax.Name = "txtAfterTax"
            Me.txtAfterTax.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAfterTax, "")
            Me.Validator.SetRequired(Me.txtAfterTax, False)
            Me.txtAfterTax.Size = New System.Drawing.Size(144, 21)
            Me.txtAfterTax.TabIndex = 92
            Me.txtAfterTax.TabStop = False
            Me.txtAfterTax.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblAfterTax
            '
            Me.lblAfterTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblAfterTax.BackColor = System.Drawing.Color.Transparent
            Me.lblAfterTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAfterTax.Location = New System.Drawing.Point(560, 514)
            Me.lblAfterTax.Name = "lblAfterTax"
            Me.lblAfterTax.Size = New System.Drawing.Size(96, 18)
            Me.lblAfterTax.TabIndex = 86
            Me.lblAfterTax.Text = "�ʹ�ط�� :"
            Me.lblAfterTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDiscountAmount
            '
            Me.lblDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblDiscountAmount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDiscountAmount.Location = New System.Drawing.Point(504, 432)
            Me.lblDiscountAmount.Name = "lblDiscountAmount"
            Me.lblDiscountAmount.Size = New System.Drawing.Size(48, 18)
            Me.lblDiscountAmount.TabIndex = 78
            Me.lblDiscountAmount.Text = "��ǹŴ :"
            Me.lblDiscountAmount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblTaxBase
            '
            Me.lblTaxBase.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxBase.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxBase.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxBase.Location = New System.Drawing.Point(544, 472)
            Me.lblTaxBase.Name = "lblTaxBase"
            Me.lblTaxBase.Size = New System.Drawing.Size(112, 18)
            Me.lblTaxBase.TabIndex = 81
            Me.lblTaxBase.Text = "��Ť���Թ���/��ԡ��:"
            Me.lblTaxBase.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBeforeTax
            '
            Me.lblBeforeTax.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblBeforeTax.BackColor = System.Drawing.Color.Transparent
            Me.lblBeforeTax.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBeforeTax.Location = New System.Drawing.Point(536, 451)
            Me.lblBeforeTax.Name = "lblBeforeTax"
            Me.lblBeforeTax.Size = New System.Drawing.Size(120, 18)
            Me.lblBeforeTax.TabIndex = 79
            Me.lblBeforeTax.Text = "�ʹ�Թ���������� :"
            Me.lblBeforeTax.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbTaxType
            '
            Me.cmbTaxType.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.cmbTaxType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbTaxType.Location = New System.Drawing.Point(400, 492)
            Me.cmbTaxType.Name = "cmbTaxType"
            Me.cmbTaxType.Size = New System.Drawing.Size(64, 21)
            Me.cmbTaxType.TabIndex = 9
            '
            'txtDiscountAmount
            '
            Me.txtDiscountAmount.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtDiscountAmount.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtDiscountAmount, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDiscountAmount, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDiscountAmount, System.Drawing.Color.Empty)
            Me.txtDiscountAmount.Location = New System.Drawing.Point(656, 429)
            Me.Validator.SetMaxValue(Me.txtDiscountAmount, "")
            Me.Validator.SetMinValue(Me.txtDiscountAmount, "")
            Me.txtDiscountAmount.Name = "txtDiscountAmount"
            Me.txtDiscountAmount.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDiscountAmount, "")
            Me.Validator.SetRequired(Me.txtDiscountAmount, False)
            Me.txtDiscountAmount.Size = New System.Drawing.Size(144, 21)
            Me.txtDiscountAmount.TabIndex = 88
            Me.txtDiscountAmount.TabStop = False
            Me.txtDiscountAmount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtTaxRate
            '
            Me.txtTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.txtTaxRate.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtTaxRate, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DecimalType)
            Me.Validator.SetDisplayName(Me.txtTaxRate, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTaxRate, System.Drawing.Color.Empty)
            Me.txtTaxRate.Location = New System.Drawing.Point(528, 492)
            Me.Validator.SetMaxValue(Me.txtTaxRate, "")
            Me.Validator.SetMinValue(Me.txtTaxRate, "")
            Me.txtTaxRate.Name = "txtTaxRate"
            Me.Validator.SetRegularExpression(Me.txtTaxRate, "")
            Me.Validator.SetRequired(Me.txtTaxRate, True)
            Me.txtTaxRate.Size = New System.Drawing.Size(32, 21)
            Me.txtTaxRate.TabIndex = 83
            Me.txtTaxRate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblTaxRate
            '
            Me.lblTaxRate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblTaxRate.BackColor = System.Drawing.Color.Transparent
            Me.lblTaxRate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblTaxRate.Location = New System.Drawing.Point(464, 493)
            Me.lblTaxRate.Name = "lblTaxRate"
            Me.lblTaxRate.Size = New System.Drawing.Size(64, 18)
            Me.lblTaxRate.TabIndex = 82
            Me.lblTaxRate.Text = "�ѵ������ :"
            Me.lblTaxRate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'grbSummary
            '
            Me.grbSummary.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbSummary.Controls.Add(Me.lbOrgTotalUnit)
            Me.grbSummary.Controls.Add(Me.lblOrgTotal)
            Me.grbSummary.Controls.Add(Me.lblAdjValUnit)
            Me.grbSummary.Controls.Add(Me.lblAdjVal)
            Me.grbSummary.Controls.Add(Me.txtAdjVal)
            Me.grbSummary.Controls.Add(Me.txtDiff)
            Me.grbSummary.Controls.Add(Me.lblDiffUnit)
            Me.grbSummary.Controls.Add(Me.lblDiff)
            Me.grbSummary.Controls.Add(Me.txtOrgTotal)
            Me.grbSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbSummary.Location = New System.Drawing.Point(512, 104)
            Me.grbSummary.Name = "grbSummary"
            Me.grbSummary.Size = New System.Drawing.Size(304, 96)
            Me.grbSummary.TabIndex = 51
            Me.grbSummary.TabStop = False
            Me.grbSummary.Text = "��ػ��¡��Ŵ˹��"
            '
            'lbOrgTotalUnit
            '
            Me.lbOrgTotalUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lbOrgTotalUnit.Location = New System.Drawing.Point(264, 16)
            Me.lbOrgTotalUnit.Name = "lbOrgTotalUnit"
            Me.lbOrgTotalUnit.Size = New System.Drawing.Size(32, 18)
            Me.lbOrgTotalUnit.TabIndex = 2
            Me.lbOrgTotalUnit.Text = "�ҷ"
            Me.lbOrgTotalUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblOrgTotal
            '
            Me.lblOrgTotal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblOrgTotal.Location = New System.Drawing.Point(8, 16)
            Me.lblOrgTotal.Name = "lblOrgTotal"
            Me.lblOrgTotal.Size = New System.Drawing.Size(144, 18)
            Me.lblOrgTotal.TabIndex = 0
            Me.lblOrgTotal.Text = "��Ť�ҵ��㺡ӡѺ�������:"
            Me.lblOrgTotal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblAdjValUnit
            '
            Me.lblAdjValUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAdjValUnit.Location = New System.Drawing.Point(264, 40)
            Me.lblAdjValUnit.Name = "lblAdjValUnit"
            Me.lblAdjValUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblAdjValUnit.TabIndex = 5
            Me.lblAdjValUnit.Text = "�ҷ"
            Me.lblAdjValUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblAdjVal
            '
            Me.lblAdjVal.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAdjVal.Location = New System.Drawing.Point(8, 40)
            Me.lblAdjVal.Name = "lblAdjVal"
            Me.lblAdjVal.Size = New System.Drawing.Size(144, 18)
            Me.lblAdjVal.TabIndex = 3
            Me.lblAdjVal.Text = "��Ť�ҷ��١��ͧ:"
            Me.lblAdjVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtAdjVal
            '
            Me.txtAdjVal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtAdjVal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAdjVal, "")
            Me.Validator.SetGotFocusBackColor(Me.txtAdjVal, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtAdjVal, System.Drawing.Color.Empty)
            Me.txtAdjVal.Location = New System.Drawing.Point(152, 40)
            Me.Validator.SetMaxValue(Me.txtAdjVal, "")
            Me.Validator.SetMinValue(Me.txtAdjVal, "")
            Me.txtAdjVal.Name = "txtAdjVal"
            Me.txtAdjVal.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtAdjVal, "")
            Me.Validator.SetRequired(Me.txtAdjVal, False)
            Me.txtAdjVal.Size = New System.Drawing.Size(112, 21)
            Me.txtAdjVal.TabIndex = 4
            Me.txtAdjVal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'txtDiff
            '
            Me.txtDiff.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtDiff, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtDiff, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDiff, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtDiff, System.Drawing.Color.Empty)
            Me.txtDiff.Location = New System.Drawing.Point(152, 64)
            Me.Validator.SetMaxValue(Me.txtDiff, "")
            Me.Validator.SetMinValue(Me.txtDiff, "")
            Me.txtDiff.Name = "txtDiff"
            Me.txtDiff.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtDiff, "")
            Me.Validator.SetRequired(Me.txtDiff, False)
            Me.txtDiff.Size = New System.Drawing.Size(112, 21)
            Me.txtDiff.TabIndex = 7
            Me.txtDiff.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'lblDiffUnit
            '
            Me.lblDiffUnit.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDiffUnit.Location = New System.Drawing.Point(264, 64)
            Me.lblDiffUnit.Name = "lblDiffUnit"
            Me.lblDiffUnit.Size = New System.Drawing.Size(32, 18)
            Me.lblDiffUnit.TabIndex = 8
            Me.lblDiffUnit.Text = "�ҷ"
            Me.lblDiffUnit.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
            '
            'lblDiff
            '
            Me.lblDiff.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDiff.Location = New System.Drawing.Point(8, 64)
            Me.lblDiff.Name = "lblDiff"
            Me.lblDiff.Size = New System.Drawing.Size(144, 18)
            Me.lblDiff.TabIndex = 6
            Me.lblDiff.Text = "��Ť������˹�������:"
            Me.lblDiff.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtOrgTotal
            '
            Me.txtOrgTotal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
            Me.Validator.SetDataType(Me.txtOrgTotal, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtOrgTotal, "")
            Me.Validator.SetGotFocusBackColor(Me.txtOrgTotal, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtOrgTotal, System.Drawing.Color.Empty)
            Me.txtOrgTotal.Location = New System.Drawing.Point(152, 16)
            Me.Validator.SetMaxValue(Me.txtOrgTotal, "")
            Me.Validator.SetMinValue(Me.txtOrgTotal, "")
            Me.txtOrgTotal.Name = "txtOrgTotal"
            Me.txtOrgTotal.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtOrgTotal, "")
            Me.Validator.SetRequired(Me.txtOrgTotal, False)
            Me.txtOrgTotal.Size = New System.Drawing.Size(112, 21)
            Me.txtOrgTotal.TabIndex = 1
            Me.txtOrgTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
            '
            'tgRefDoc
            '
            Me.tgRefDoc.AllowNew = False
            Me.tgRefDoc.AllowSorting = False
            Me.tgRefDoc.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
                Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.tgRefDoc.AutoColumnResize = True
            Me.tgRefDoc.CaptionVisible = False
            Me.tgRefDoc.Cellchanged = False
            Me.tgRefDoc.DataMember = ""
            Me.tgRefDoc.HeaderForeColor = System.Drawing.SystemColors.ControlText
            Me.tgRefDoc.Location = New System.Drawing.Point(8, 104)
            Me.tgRefDoc.Name = "tgRefDoc"
            Me.tgRefDoc.Size = New System.Drawing.Size(504, 112)
            Me.tgRefDoc.SortingArrowColor = System.Drawing.Color.Red
            Me.tgRefDoc.TabIndex = 57
            Me.tgRefDoc.TreeManager = Nothing
            '
            'lblNote
            '
            Me.lblNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.lblNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblNote.Location = New System.Drawing.Point(424, 216)
            Me.lblNote.Name = "lblNote"
            Me.lblNote.Size = New System.Drawing.Size(88, 18)
            Me.lblNote.TabIndex = 73
            Me.lblNote.Text = "�����˵�Ŵ˹��"
            Me.lblNote.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblItem
            '
            Me.lblItem.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItem.Location = New System.Drawing.Point(8, 232)
            Me.lblItem.Name = "lblItem"
            Me.lblItem.Size = New System.Drawing.Size(96, 18)
            Me.lblItem.TabIndex = 74
            Me.lblItem.Text = "��¡��Ŵ˹��"
            Me.lblItem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            'txtNote
            '
            Me.txtNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.Validator.SetDataType(Me.txtNote, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtNote, "")
            Me.txtNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtNote, System.Drawing.Color.Empty)
            Me.txtNote.Location = New System.Drawing.Point(512, 200)
            Me.Validator.SetMaxValue(Me.txtNote, "")
            Me.Validator.SetMinValue(Me.txtNote, "")
            Me.txtNote.Multiline = True
            Me.txtNote.Name = "txtNote"
            Me.Validator.SetRegularExpression(Me.txtNote, "")
            Me.Validator.SetRequired(Me.txtNote, False)
            Me.txtNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
            Me.txtNote.Size = New System.Drawing.Size(280, 42)
            Me.txtNote.TabIndex = 7
            Me.txtNote.TabStop = False
            '
            'txtInvoiceCode
            '
            Me.Validator.SetDataType(Me.txtInvoiceCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtInvoiceCode, "")
            Me.txtInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtInvoiceCode, System.Drawing.Color.Empty)
            Me.txtInvoiceCode.Location = New System.Drawing.Point(96, 40)
            Me.Validator.SetMaxValue(Me.txtInvoiceCode, "")
            Me.Validator.SetMinValue(Me.txtInvoiceCode, "")
            Me.txtInvoiceCode.Name = "txtInvoiceCode"
            Me.Validator.SetRegularExpression(Me.txtInvoiceCode, "")
            Me.Validator.SetRequired(Me.txtInvoiceCode, False)
            Me.txtInvoiceCode.Size = New System.Drawing.Size(107, 21)
            Me.txtInvoiceCode.TabIndex = 2
            Me.txtInvoiceCode.TabStop = False
            '
            'txtToCostCenterName
            '
            Me.txtToCostCenterName.BackColor = System.Drawing.SystemColors.Control
            Me.Validator.SetDataType(Me.txtToCostCenterName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCostCenterName, "")
            Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtToCostCenterName, System.Drawing.Color.Empty)
            Me.txtToCostCenterName.Location = New System.Drawing.Point(280, 80)
            Me.Validator.SetMaxValue(Me.txtToCostCenterName, "")
            Me.Validator.SetMinValue(Me.txtToCostCenterName, "")
            Me.txtToCostCenterName.Name = "txtToCostCenterName"
            Me.txtToCostCenterName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtToCostCenterName, "")
            Me.Validator.SetRequired(Me.txtToCostCenterName, False)
            Me.txtToCostCenterName.Size = New System.Drawing.Size(176, 21)
            Me.txtToCostCenterName.TabIndex = 105
            Me.txtToCostCenterName.TabStop = False
            '
            'txtToCostCenterCode
            '
            Me.Validator.SetDataType(Me.txtToCostCenterCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtToCostCenterCode, "")
            Me.Validator.SetGotFocusBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtToCostCenterCode, System.Drawing.Color.Empty)
            Me.txtToCostCenterCode.Location = New System.Drawing.Point(216, 80)
            Me.Validator.SetMaxValue(Me.txtToCostCenterCode, "")
            Me.Validator.SetMinValue(Me.txtToCostCenterCode, "")
            Me.txtToCostCenterCode.Name = "txtToCostCenterCode"
            Me.txtToCostCenterCode.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtToCostCenterCode, "")
            Me.Validator.SetRequired(Me.txtToCostCenterCode, False)
            Me.txtToCostCenterCode.Size = New System.Drawing.Size(64, 21)
            Me.txtToCostCenterCode.TabIndex = 103
            '
            'lblItemRf
            '
            Me.lblItemRf.Font = New System.Drawing.Font("Tahoma", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblItemRf.Location = New System.Drawing.Point(8, 88)
            Me.lblItemRf.Name = "lblItemRf"
            Me.lblItemRf.Size = New System.Drawing.Size(96, 18)
            Me.lblItemRf.TabIndex = 64
            Me.lblItemRf.Text = "�͡�����ҧ�ԧ"
            Me.lblItemRf.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
            Me.tgItem.Location = New System.Drawing.Point(8, 248)
            Me.tgItem.Name = "tgItem"
            Me.tgItem.Size = New System.Drawing.Size(800, 152)
            Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
            Me.tgItem.TabIndex = 59
            Me.tgItem.TreeManager = Nothing
            '
            'ibtnShowNote
            '
            Me.ibtnShowNote.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.ibtnShowNote.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowNote.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowNote.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowNote.Location = New System.Drawing.Point(792, 208)
            Me.ibtnShowNote.Name = "ibtnShowNote"
            Me.ibtnShowNote.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowNote.TabIndex = 9
            Me.ibtnShowNote.TabStop = False
            Me.ibtnShowNote.ThemedImage = CType(resources.GetObject("ibtnShowNote.ThemedImage"), System.Drawing.Bitmap)
            '
            'chkAutoRunVat
            '
            Me.chkAutoRunVat.Appearance = System.Windows.Forms.Appearance.Button
            Me.chkAutoRunVat.Image = CType(resources.GetObject("chkAutoRunVat.Image"), System.Drawing.Image)
            Me.chkAutoRunVat.Location = New System.Drawing.Point(202, 40)
            Me.chkAutoRunVat.Name = "chkAutoRunVat"
            Me.chkAutoRunVat.Size = New System.Drawing.Size(21, 21)
            Me.chkAutoRunVat.TabIndex = 12
            '
            'lblInvoiceCode
            '
            Me.lblInvoiceCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInvoiceCode.ForeColor = System.Drawing.Color.Black
            Me.lblInvoiceCode.Location = New System.Drawing.Point(0, 40)
            Me.lblInvoiceCode.Name = "lblInvoiceCode"
            Me.lblInvoiceCode.Size = New System.Drawing.Size(96, 18)
            Me.lblInvoiceCode.TabIndex = 99
            Me.lblInvoiceCode.Text = "�Ţ���㺡ӡѺ����:"
            Me.lblInvoiceCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblInvoiceDate
            '
            Me.lblInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblInvoiceDate.ForeColor = System.Drawing.Color.Black
            Me.lblInvoiceDate.Location = New System.Drawing.Point(233, 40)
            Me.lblInvoiceDate.Name = "lblInvoiceDate"
            Me.lblInvoiceDate.Size = New System.Drawing.Size(32, 18)
            Me.lblInvoiceDate.TabIndex = 101
            Me.lblInvoiceDate.Text = "�ѹ���:"
            Me.lblInvoiceDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpInvoiceDate
            '
            Me.dtpInvoiceDate.CustomFormat = "dd/MM/yyyy"
            Me.dtpInvoiceDate.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.dtpInvoiceDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom
            Me.dtpInvoiceDate.Location = New System.Drawing.Point(265, 40)
            Me.dtpInvoiceDate.Name = "dtpInvoiceDate"
            Me.dtpInvoiceDate.Size = New System.Drawing.Size(96, 21)
            Me.dtpInvoiceDate.TabIndex = 13
            Me.dtpInvoiceDate.TabStop = False
            '
            'lblToCostCenter
            '
            Me.lblToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblToCostCenter.Location = New System.Drawing.Point(160, 80)
            Me.lblToCostCenter.Name = "lblToCostCenter"
            Me.lblToCostCenter.Size = New System.Drawing.Size(56, 18)
            Me.lblToCostCenter.TabIndex = 104
            Me.lblToCostCenter.Text = "�ҡ CC:"
            Me.lblToCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'ibtnShowToCostCenter
            '
            Me.ibtnShowToCostCenter.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowToCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowToCostCenter.Location = New System.Drawing.Point(480, 80)
            Me.ibtnShowToCostCenter.Name = "ibtnShowToCostCenter"
            Me.ibtnShowToCostCenter.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowToCostCenter.TabIndex = 107
            Me.ibtnShowToCostCenter.TabStop = False
            Me.ibtnShowToCostCenter.ThemedImage = CType(resources.GetObject("ibtnShowToCostCenter.ThemedImage"), System.Drawing.Bitmap)
            '
            'ibtnShowToCostCenterDialog
            '
            Me.ibtnShowToCostCenterDialog.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.ibtnShowToCostCenterDialog.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.ibtnShowToCostCenterDialog.ForeColor = System.Drawing.SystemColors.Control
            Me.ibtnShowToCostCenterDialog.Location = New System.Drawing.Point(456, 80)
            Me.ibtnShowToCostCenterDialog.Name = "ibtnShowToCostCenterDialog"
            Me.ibtnShowToCostCenterDialog.Size = New System.Drawing.Size(24, 23)
            Me.ibtnShowToCostCenterDialog.TabIndex = 106
            Me.ibtnShowToCostCenterDialog.TabStop = False
            Me.ibtnShowToCostCenterDialog.ThemedImage = CType(resources.GetObject("ibtnShowToCostCenterDialog.ThemedImage"), System.Drawing.Bitmap)
            '
            'SaleCNDetailView
            '
            Me.Controls.Add(Me.cmbCode)
            Me.Controls.Add(Me.ibtnShowToCostCenter)
            Me.Controls.Add(Me.ibtnShowToCostCenterDialog)
            Me.Controls.Add(Me.txtToCostCenterName)
            Me.Controls.Add(Me.txtToCostCenterCode)
            Me.Controls.Add(Me.lblToCostCenter)
            Me.Controls.Add(Me.chkAutoRunVat)
            Me.Controls.Add(Me.lblInvoiceCode)
            Me.Controls.Add(Me.txtInvoiceCode)
            Me.Controls.Add(Me.lblInvoiceDate)
            Me.Controls.Add(Me.txtInvoiceDate)
            Me.Controls.Add(Me.dtpInvoiceDate)
            Me.Controls.Add(Me.txtDocDate)
            Me.Controls.Add(Me.ibtnAddWBS)
            Me.Controls.Add(Me.tgWBS)
            Me.Controls.Add(Me.ibtnDelWBS)
            Me.Controls.Add(Me.lblWBS)
            Me.Controls.Add(Me.dtpDocDate)
            Me.Controls.Add(Me.lblCode)
            Me.Controls.Add(Me.grbDelivery)
            Me.Controls.Add(Me.ibtnBlankDoc)
            Me.Controls.Add(Me.ibtnDelDoc)
            Me.Controls.Add(Me.ibtnBlank)
            Me.Controls.Add(Me.ibtnDelRow)
            Me.Controls.Add(Me.lblPercent)
            Me.Controls.Add(Me.txtTaxBase)
            Me.Controls.Add(Me.txtBeforeTax)
            Me.Controls.Add(Me.txtTaxAmount)
            Me.Controls.Add(Me.lblGross)
            Me.Controls.Add(Me.lblTaxAmount)
            Me.Controls.Add(Me.txtGross)
            Me.Controls.Add(Me.txtDiscountRate)
            Me.Controls.Add(Me.lblTaxType)
            Me.Controls.Add(Me.txtAfterTax)
            Me.Controls.Add(Me.lblAfterTax)
            Me.Controls.Add(Me.lblDiscountAmount)
            Me.Controls.Add(Me.lblTaxBase)
            Me.Controls.Add(Me.lblBeforeTax)
            Me.Controls.Add(Me.cmbTaxType)
            Me.Controls.Add(Me.txtDiscountAmount)
            Me.Controls.Add(Me.txtTaxRate)
            Me.Controls.Add(Me.lblTaxRate)
            Me.Controls.Add(Me.grbSummary)
            Me.Controls.Add(Me.tgRefDoc)
            Me.Controls.Add(Me.lblNote)
            Me.Controls.Add(Me.lblItemRf)
            Me.Controls.Add(Me.tgItem)
            Me.Controls.Add(Me.chkAutorun)
            Me.Controls.Add(Me.lblDocDate)
            Me.Controls.Add(Me.lblItem)
            Me.Controls.Add(Me.txtNote)
            Me.Controls.Add(Me.ibtnShowNote)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "SaleCNDetailView"
            Me.Size = New System.Drawing.Size(824, 560)
            CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tgWBS, System.ComponentModel.ISupportInitialize).EndInit()
            Me.grbDelivery.ResumeLayout(False)
            Me.grbDelivery.PerformLayout()
            Me.grbSummary.ResumeLayout(False)
            Me.grbSummary.PerformLayout()
            CType(Me.tgRefDoc, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
            Me.PerformLayout()

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
        Private m_entity As SaleCN
        Private m_isInitialized As Boolean = False
        Private m_treeManager As TreeManager
        Private m_docTreeManager As TreeManager
        Private m_docCollInitialized As Boolean
        Private m_itemInitialized As Boolean

        Private m_tableStyleEnable As Hashtable

        Private m_enableState As Hashtable

        Private m_wbsTreeManager As TreeManager
        Private m_wbsdInitialized As Boolean
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            Me.InitializeComponent()
            Me.SetLabelText()
            Initialize()

            SaveEnableState()
            Dim dt As TreeTable = SaleCN.GetSchemaTable()
            Dim dst As DataGridTableStyle = Me.CreateTableStyle()
            m_treeManager = New TreeManager(dt, tgItem)
            m_treeManager.SetTableStyle(dst)
            m_treeManager.AllowSorting = False
            m_treeManager.AllowDelete = False

            AddHandler dt.ColumnChanging, AddressOf Treetable_ColumnChanging
            AddHandler dt.ColumnChanged, AddressOf Treetable_ColumnChanged
            AddHandler dt.RowDeleted, AddressOf ItemDelete

            Dim dtDoc As TreeTable = SaleCN.GetDocSchemaTable()
            Dim dstDoc As DataGridTableStyle = Me.CreateDocTableStyle()
            m_docTreeManager = New TreeManager(dtDoc, tgRefDoc)
            m_docTreeManager.SetTableStyle(dstDoc)
            m_docTreeManager.AllowSorting = False
            m_docTreeManager.AllowDelete = False

            AddHandler dtDoc.ColumnChanging, AddressOf DocTreetable_ColumnChanging
            AddHandler dtDoc.ColumnChanged, AddressOf DocTreetable_ColumnChanged
            AddHandler dtDoc.RowDeleted, AddressOf DocItemDelete

            Dim dtWBS As TreeTable = Me.GetSchemaTable()
            Dim dstWBS As DataGridTableStyle = Me.CreateWBSTableStyle()
            m_wbsTreeManager = New TreeManager(dtWBS, tgWBS)
            m_wbsTreeManager.SetTableStyle(dstWBS)
            m_wbsTreeManager.AllowSorting = False
            m_wbsTreeManager.AllowDelete = False

            AddHandler dtWBS.ColumnChanging, AddressOf WBSTreetable_ColumnChanging
            AddHandler dtWBS.ColumnChanged, AddressOf WBSTreetable_ColumnChanged
            AddHandler dtWBS.RowDeleted, AddressOf WBSItemDelete

            EventWiring()
        End Sub
        Private Sub SaveEnableState()
            m_enableState = New Hashtable
            For Each ctrl As Control In Me.grbDelivery.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
            For Each ctrl As Control In Me.grbSummary.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
            For Each ctrl As Control In Me.Controls
                m_enableState.Add(ctrl, ctrl.Enabled)
            Next
        End Sub
#End Region

#Region "Style"
        Private Function GetSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("WBS")
            myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
            myDatatable.Columns.Add(New DataColumn("WBS", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Percent", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
            Return myDatatable
        End Function
        Public Function CreateWBSTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "WBS"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "LineNumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.LineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "LineNumber"

            Dim csWBS As New TreeTextColumn
            csWBS.MappingName = "WBS"
            csWBS.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.WBSHeaderText}")
            csWBS.NullText = ""
            csWBS.Width = 100
            csWBS.ReadOnly = True
            csWBS.TextBox.Name = "WBS"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf WBSButtonClicked

            Dim csPercent As New TreeTextColumn
            csPercent.MappingName = "Percent"
            csPercent.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.PercentHeaderText}")
            csPercent.NullText = ""
            csPercent.DataAlignment = HorizontalAlignment.Right
            csPercent.Format = "#,###.##"
            csPercent.TextBox.Name = "Percent"

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "Amount"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmoluntHeaderText}")
            csAmount.NullText = ""
            csAmount.DataAlignment = HorizontalAlignment.Right
            csAmount.Format = "#,###.##"
            csAmount.TextBox.Name = "Amount"
            csAmount.ReadOnly = True

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csWBS)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csPercent)
            dst.GridColumnStyles.Add(csAmount)

            Return dst
        End Function
        Public Sub WBSButtonClicked(ByVal e As ButtonColumnEventArgs)
            'If Me.m_entity Is Nothing Then
            '    Return
            'End If
            'If Me.m_entity.ToCostCenter Is Nothing Then
            '    Return
            'End If
            'If Me.m_entity.ToCostCenter.BoqId = 0 Then
            '    Return
            'End If
            'Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            'Dim filters(0) As Filter
            'filters(0) = New Filter("boq_id", Me.m_entity.ToCostCenter.BoqId)
            'myEntityPanelService.OpenTreeDialog(New WBS, AddressOf SetWBS)
        End Sub
        Private Sub SetWBS(ByVal wbs As ISimpleEntity)
            'Dim tr As TreeRow = Me.m_treeManager.SelectedRow
            'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
            'Dim item As New SaleCNItem
            'item.CopyFromDataRow(tr)
            'Dim wsdColl As WBSDistributeCollection = CType(tr.Tag, WBSDistributeCollection)
            'Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
            'CType(row.Tag, WBSDistribute).WBS = CType(wbs, wbs)
            'Dim view As Integer = 45
            'm_wbsdInitialized = False
            'wsdColl.Populate(dt, item, view)
            'm_wbsdInitialized = True
        End Sub
        Private ReadOnly Property CurrentWsbsd() As WBSDistribute
            Get
                Dim row As TreeRow = Me.m_wbsTreeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                Return CType(row.Tag, WBSDistribute)
            End Get
        End Property
        Public Function CreateDocTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "SaleCNDoc"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "Linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetail.DocLineNumberHeaderText}")
            csLineNumber.NullText = ""
            csLineNumber.Width = 30
            csLineNumber.DataAlignment = HorizontalAlignment.Center
            csLineNumber.ReadOnly = True
            csLineNumber.TextBox.Name = "Linenumber"

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetail.DocCodeHeaderText}")
            csCode.NullText = ""
            csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""
            AddHandler csButton.Click, AddressOf DocButtonClicked

            Dim csRefDocCode As New TreeTextColumn
            csRefDocCode.MappingName = "RefDocCode"
            csRefDocCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetail.RefDocCodeHeaderText}")
            csRefDocCode.NullText = ""
            csRefDocCode.ReadOnly = True
            csRefDocCode.TextBox.Name = "RefDocCode"

            Dim csRealAmount As New TreeTextColumn
            csRealAmount.MappingName = "RealAmount"
            csRealAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetail.DocRealAmountHeaderText}")
            csRealAmount.NullText = ""
            csRealAmount.TextBox.Name = "RealAmount"
            csRealAmount.ReadOnly = True
            csRealAmount.Format = "#,###.##"

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "stockstock_amt"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetail.DocAmountHeaderText}")
            csAmount.NullText = ""
            csAmount.TextBox.Name = "stockstock_amt"
            csAmount.Format = "#,###.##"

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "stockstock_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetail.DocNoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "stockstock_note"

            dst.GridColumnStyles.Add(csLineNumber)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csRefDocCode)
            dst.GridColumnStyles.Add(csRealAmount)
            dst.GridColumnStyles.Add(csAmount)
            dst.GridColumnStyles.Add(csNote)

            Return dst
        End Function
        Public Sub DocButtonClicked(ByVal e As ButtonColumnEventArgs)
            DocButtonClick(e)
        End Sub
        Private ReadOnly Property CurrentDoc() As SaleCNRefDoc
            Get
                Dim row As TreeRow = Me.m_docTreeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                Return CType(row.Tag, SaleCNRefDoc)
            End Get
        End Property
        Public Function CreateTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "SaleCN"
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

            'Stock Items
            Dim csLineNumber As New TreeTextColumn
            csLineNumber.MappingName = "stocki_linenumber"
            csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetail.LineNumberHeaderText}")
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

            Dim csType As DataGridComboColumn
            csType = New DataGridComboColumn("stocki_entityType" _
            , CodeDescription.GetCodeList("stocki_enitytype") _
            , "code_description", "code_value")
            csType.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.TypeHeaderText}")
            csType.NullText = String.Empty

            Dim csCode As New TreeTextColumn
            csCode.MappingName = "Code"
            csCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.CodeHeaderText}")
            csCode.NullText = ""
            csCode.Width = 100
            csCode.ReadOnly = True
            csCode.TextBox.Name = "Code"

            Dim csButton As New DataGridButtonColumn
            csButton.MappingName = "Button"
            csButton.HeaderText = ""
            csButton.NullText = ""

            Dim csName As New TreeTextColumn
            csName.MappingName = "stocki_itemName"
            csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.DescriptionHeaderText}")
            csName.NullText = ""
            csName.Width = 200
            csName.TextBox.Name = "Description"
            'AddHandler csDescription.TextBox.TextChanged, AddressOf ChangeProperty
            'csDescription.ReadOnly = True

            Dim csUnit As New TreeTextColumn
            csUnit.MappingName = "Unit"
            csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnitHeaderText}")
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
            csQty.MappingName = "stocki_qty"
            csQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.QtyHeaderText}")
            csQty.NullText = ""
            csQty.DataAlignment = HorizontalAlignment.Right
            csQty.Format = "#,###.##"
            csQty.TextBox.Name = "Qty"
            'AddHandler csQty.TextBox.TextChanged, AddressOf ChangeProperty

            Dim csStockQty As New TreeTextColumn
            csStockQty.MappingName = "StockQty"
            csStockQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.StockQtyHeaderText}")
            csStockQty.NullText = ""
            csStockQty.DataAlignment = HorizontalAlignment.Right
            csStockQty.Format = "#,###.##"
            csStockQty.ReadOnly = True

            Dim csUnitPRice As New TreeTextColumn
            csUnitPRice.MappingName = "stocki_unitprice"
            csUnitPRice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnitpriceHeaderText}")
            csUnitPRice.NullText = ""
            csUnitPRice.TextBox.Name = "stocki_unitprice"
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csDiscount As New TreeTextColumn
            csDiscount.MappingName = "stocki_discrate"
            csDiscount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.DiscountHeaderText}")
            csDiscount.NullText = ""
            csDiscount.TextBox.Name = "stocki_discrate"
            'AddHandler csDiscount.TextBox.TextChanged, AddressOf ChangeProperty
            'csDiscount.DataAlignment = HorizontalAlignment.Center

            Dim csAmount As New TreeTextColumn
            csAmount.MappingName = "Amount"
            csAmount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AmountHeaderText}")
            csAmount.NullText = ""
            csAmount.TextBox.Name = "Amount"
            csAmount.ReadOnly = True
            csAmount.Format = "#,###.##"
            'AddHandler csUnit.TextBox.TextChanged, AddressOf ChangeProperty
            'csUnit.DataAlignment = HorizontalAlignment.Center

            Dim csAccountCode As New TreeTextColumn
            csAccountCode.MappingName = "AccountCode"
            csAccountCode.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountCodeHeaderText}")
            csAccountCode.NullText = ""
            csAccountCode.TextBox.Name = "AccountCode"

            Dim csAccount As New TreeTextColumn
            csAccount.MappingName = "Account"
            csAccount.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.AccountHeaderText}")
            csAccount.NullText = ""
            csAccount.ReadOnly = True
            csAccount.TextBox.Name = "Account"

            Dim csAccountButton As New DataGridButtonColumn
            csAccountButton.MappingName = "AccountButton"
            csAccountButton.HeaderText = ""
            csAccountButton.NullText = ""

            Dim csVatable As New DataGridCheckBoxColumn
            csVatable.MappingName = "stocki_unvatable"
            csVatable.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.UnVatableHeaderText}")
            csVatable.Width = 100
            csVatable.InvisibleWhenUnspcified = True

            Dim csNote As New TreeTextColumn
            csNote.MappingName = "stocki_note"
            csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptDetail.NoteHeaderText}")
            csNote.NullText = ""
            csNote.Width = 180
            csNote.TextBox.Name = "stocki_note"

            'dst.GridColumnStyles.Add(csBarrier)
            dst.GridColumnStyles.Add(csType)
            dst.GridColumnStyles.Add(csCode)
            dst.GridColumnStyles.Add(csButton)
            dst.GridColumnStyles.Add(csName)
            dst.GridColumnStyles.Add(csUnit)
            dst.GridColumnStyles.Add(csUnitButton)
            dst.GridColumnStyles.Add(csQty)
            dst.GridColumnStyles.Add(csUnitPRice)
            dst.GridColumnStyles.Add(csDiscount)
            dst.GridColumnStyles.Add(csAmount)
            dst.GridColumnStyles.Add(csAccountCode)
            dst.GridColumnStyles.Add(csAccountButton)
            dst.GridColumnStyles.Add(csAccount)
            dst.GridColumnStyles.Add(csVatable)
            dst.GridColumnStyles.Add(csNote)

            m_tableStyleEnable = New Hashtable
            For Each colStyle As DataGridColumnStyle In dst.GridColumnStyles
                m_tableStyleEnable.Add(colStyle, colStyle.ReadOnly)
            Next
            Return dst
        End Function
        Public Sub ButtonClicked(ByVal e As ButtonColumnEventArgs)
            If e.Column = 5 Then
                Me.UnitButtonClick(e)
            ElseIf e.Column = 2 Then
                Me.ItemButtonClick(e)
            Else
                Me.AcctButtonClick(e)
            End If
        End Sub
        Private ReadOnly Property CurrentItem() As SaleCNItem
            Get
                Dim row As TreeRow = Me.m_treeManager.SelectedRow
                If row Is Nothing Then
                    Return Nothing
                End If
                If Not TypeOf row.Tag Is SaleCNItem Then
                    Return Nothing
                End If
                Return CType(row.Tag, SaleCNItem)
            End Get
        End Property
#End Region

#Region "TreeTable Handlers"
        Private Sub Treetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_itemInitialized Then
                Return
            End If
            If CType(e.Row, TreeRow).Level = 0 Then
                Return
            End If
            Dim index As Integer = Me.m_treeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If ValidateRow(CType(e.Row, TreeRow)) Then
                If index = Me.m_treeManager.Treetable.Childs.Count - 1 Then
                    Me.m_treeManager.Treetable.Childs.Add()
                End If
                Select Case e.Column.ColumnName.ToLower
                    Case "stocki_unitprice", "stocki_unvatable", "stocki_discrate", "stocki_qty", "unit"
                        UpdateAmount(e)
                End Select
                Me.m_treeManager.Treetable.AcceptChanges()
            End If
        End Sub
        Private Sub UpdateAmount(ByVal e As DataColumnChangeEventArgs)
            'Dim item As New SaleCNItem
            'item.CopyFromDataRow(CType(e.Row, TreeRow))
            'e.Row("Amount") = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            'e.Row("StockQty") = Configuration.FormatToString(item.StockQty, DigitConfig.Qty)
            'RefreshTaxBase()
        End Sub
        Private Sub Treetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_itemInitialized Then
                Return
            End If
            If CType(e.Row, TreeRow).Level = 0 Then
                e.ProposedValue = e.Row(e.Column)
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetCode(e)
                    Case "stocki_itemname"
                        SetName(e)
                    Case "unit"
                        SetUnitValue(e)
                    Case "stocki_qty"
                        SetQty(e)
                    Case "stocki_unitprice"
                        SetUnitPrice(e)
                    Case "accountcode"
                        SetAccount(e)
                    Case "stocki_entitytype"
                        SetEntityType(e)
                End Select
                ValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub ValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim code As Object = e.Row("code")
            Dim stocki_itemname As Object = e.Row("stocki_itemname")
            Dim stocki_entitytype As Object = e.Row("stocki_entitytype")
            Dim accountcode As Object = e.Row("accountcode")
            Dim unit As Object = e.Row("unit")
            Dim stocki_unitprice As Object = e.Row("stocki_unitprice")
            Dim stocki_qty As Object = e.Row("stocki_qty")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    code = e.ProposedValue
                Case "stocki_itemname"
                    stocki_itemname = e.ProposedValue
                Case "stocki_entitytype"
                    stocki_entitytype = e.ProposedValue
                Case "accountcode"
                    accountcode = e.ProposedValue
                Case "unit"
                    unit = e.ProposedValue
                Case "stocki_unitprice"
                    stocki_unitprice = e.ProposedValue
                Case "stocki_qty"
                    stocki_qty = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If IsDBNull(stocki_entitytype) Then
                isBlankRow = True
            End If

            If Not isBlankRow Then
                Select Case CInt(stocki_entitytype)
                    Case 0, 88, 89 'blank item /����ç/����ͧ�ѡ�
                        If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                            e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_itemname", "")
                        End If
                        If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                            e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_qty", "")
                        End If
                        If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                            e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_unitprice", "")
                        End If
                        If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                            e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                        Else
                            e.Row.SetColumnError("accountcode", "")
                        End If
                        e.Row.SetColumnError("code", "")
                    Case 19 '����ͧ���
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                        If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                            e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_itemname", "")
                        End If
                        If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                            e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_qty", "")
                        End If
                        If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                            e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_unitprice", "")
                        End If
                        If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                            e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                        Else
                            e.Row.SetColumnError("accountcode", "")
                        End If
                    Case 28 'F/A
                        If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                            e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_itemname", "")
                        End If
                        If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                            e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_qty", "")
                        End If
                        If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                            e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_unitprice", "")
                        End If
                        If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                            e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                        Else
                            e.Row.SetColumnError("accountcode", "")
                        End If
                        e.Row.SetColumnError("code", "")
                    Case 42 'LCI
                        If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                            e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.ItemCodeMissing}"))
                        Else
                            e.Row.SetColumnError("code", "")
                        End If
                        If IsDBNull(stocki_itemname) OrElse stocki_itemname.ToString.Length = 0 Then
                            e.Row.SetColumnError("stocki_itemname", Me.StringParserService.Parse("${res:Global.Error.ItemNameMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_itemname", "")
                        End If
                        If IsDBNull(stocki_qty) OrElse CDec(stocki_qty) <= 0 Then
                            e.Row.SetColumnError("stocki_qty", Me.StringParserService.Parse("${res:Global.Error.ItemQtyMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_qty", "")
                        End If
                        If IsDBNull(stocki_unitprice) OrElse CDec(stocki_unitprice) <= 0 Then
                            e.Row.SetColumnError("stocki_unitprice", Me.StringParserService.Parse("${res:Global.Error.ItemUnitPriceMissing}"))
                        Else
                            e.Row.SetColumnError("stocki_unitprice", "")
                        End If
                        If IsDBNull(accountcode) OrElse accountcode.ToString.Length = 0 Then
                            e.Row.SetColumnError("accountcode", Me.StringParserService.Parse("${res:Global.Error.ItemAccountMissing}"))
                        Else
                            e.Row.SetColumnError("accountcode", "")
                        End If
                    Case Else
                        Return
                End Select
            End If

        End Sub
        Public Function ValidateRow(ByVal row As TreeRow) As Boolean
            If row.IsNull("stocki_entitytype") Then
                Return False
            End If
            Return True
        End Function
        Private m_updating As Boolean = False
        Public Sub SetQty(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Qty)
            Dim value As Decimal = CDec(e.ProposedValue)
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("stocki_entityType"))
                Case 0, 19, 28, 42, 88, 89
                    '��ҹ
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            m_updating = False
        End Sub
        Public Sub SetUnitPrice(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.UnitPrice)
            Dim value As Decimal = CDec(e.ProposedValue)
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("stocki_entityType"))
                Case 0, 19, 28, 42, 88, 89
                    '��ҹ
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            m_updating = False
        End Sub
        Public Sub SetEntityType(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull(e.Column) Then
                e.Row("stocki_entity") = DBNull.Value
                e.Row("stocki_itemname") = DBNull.Value
                e.Row("Amount") = DBNull.Value
                e.Row("stocki_qty") = DBNull.Value
                e.Row("StockQty") = DBNull.Value
                e.Row("stocki_unit") = DBNull.Value
                e.Row("stocki_unitprice") = DBNull.Value
                e.Row("stocki_discrate") = DBNull.Value
                e.Row("Unit") = DBNull.Value
                e.Row("UnitButton") = DBNull.Value
                e.Row("stocki_unvatable") = False
                e.Row("stocki_note") = DBNull.Value
                e.Row("Amount") = DBNull.Value
                e.Row("code") = DBNull.Value
                e.Row("stocki_acct") = DBNull.Value
                e.Row("AccountCode") = DBNull.Value
                e.Row("AccountButton") = ""
                e.Row("Account") = DBNull.Value
                If IsNumeric(e.ProposedValue) AndAlso (CInt(e.ProposedValue) = 0 Or CInt(e.ProposedValue) = 28) Then
                    e.Row("Button") = "invisible"
                Else
                    e.Row("Button") = ""
                End If
                m_updating = False
                Return
            End If

            If CInt(e.ProposedValue) = CInt(e.Row(e.Column)) Then
                '��ҹ�Ŵ
                m_updating = False
                Return
            End If
            If msgServ.AskQuestion("${res:Global.Question.ChangeSaleCNEntityType}") Then
                ClearRow(e)
            Else
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            m_updating = False
        End Sub
        Private Sub ClearRow(ByVal e As DataColumnChangeEventArgs)
            e.Row("stocki_entity") = DBNull.Value
            e.Row("stocki_itemname") = DBNull.Value
            e.Row("Amount") = DBNull.Value
            e.Row("stocki_qty") = DBNull.Value
            e.Row("StockQty") = DBNull.Value
            e.Row("stocki_unit") = DBNull.Value
            e.Row("stocki_unitprice") = DBNull.Value
            e.Row("stocki_discrate") = DBNull.Value
            e.Row("Unit") = DBNull.Value
            e.Row("UnitButton") = DBNull.Value
            e.Row("stocki_unvatable") = False
            e.Row("stocki_note") = DBNull.Value
            e.Row("Amount") = DBNull.Value
            e.Row("code") = DBNull.Value
            e.Row("stocki_acct") = DBNull.Value
            e.Row("AccountCode") = DBNull.Value
            e.Row("AccountButton") = ""
            e.Row("Account") = DBNull.Value
            If IsNumeric(e.ProposedValue) AndAlso (CInt(e.ProposedValue) = 0 Or CInt(e.ProposedValue) = 28) Then
                e.Row("Button") = "invisible"
            Else
                e.Row("Button") = ""
            End If
        End Sub
        Public Sub SetAccount(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Dim entity As New Account(e.ProposedValue.ToString)
            If entity.Originated Then
                e.Row("stocki_acct") = entity.Id
                e.ProposedValue = entity.Code
                e.Row("Account") = entity.Name
                m_updating = False
                Return
            Else
                Select Case CInt(e.Row("stocki_entityType"))
                    Case 0, 28, 88, 89
                        e.Row("stocki_acct") = DBNull.Value
                        e.ProposedValue = DBNull.Value
                        e.Row("Account") = DBNull.Value
                        m_updating = False
                        Return
                    Case 19 'Tool
                        'Dim item As New SaleCNItem
                        'item.CopyFromDataRow(CType(e.Row, TreeRow))
                        'If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 Then
                        '    Dim myTool As Tool = CType(item.Entity, Tool)
                        '    Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
                        '    If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
                        '        e.Row("stocki_acct") = ga.Account.Id
                        '        e.ProposedValue = ga.Account.Code
                        '        e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                        '        m_updating = False
                        '        Return
                        '    End If
                        'End If
                        'e.Row("stocki_acct") = DBNull.Value
                        'e.ProposedValue = DBNull.Value
                        'e.Row("Account") = DBNull.Value
                        'm_updating = False
                        'Return
                    Case 42 ' Lci
                        Dim item As New SaleCNItem
                        item.CopyFromDataRow(CType(e.Row, TreeRow))
                        If Not item.Entity Is Nothing AndAlso item.Entity.Id <> 0 Then
                            Dim lci As LCIItem = CType(item.Entity, LCIItem)
                            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                                e.Row("stocki_acct") = lci.Account.Id
                                e.ProposedValue = lci.Account.Code
                                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                                m_updating = False
                                Return
                            End If
                        End If
                        e.Row("stocki_acct") = DBNull.Value
                        e.ProposedValue = DBNull.Value
                        e.Row("Account") = DBNull.Value
                        m_updating = False
                        Return
                    Case Else
                        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                End Select
            End If
            m_updating = False
        End Sub
        Public Sub SetName(ByVal e As DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("stocki_entityType"))
                Case 0, 28, 88, 89
                    '��ҹ
                    'Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(CInt(e.Row("stocki_entityType")), Me.EntityId)
                    'If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
                    '    e.Row("stocki_acct") = ga.Account.Id
                    '    e.Row("AccountCode") = ga.Account.Code
                    '    e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                    'Else
                    '    e.Row("stocki_acct") = DBNull.Value
                    '    e.Row("AccountCode") = DBNull.Value
                    '    e.Row("Account") = DBNull.Value
                    'End If
                Case 19, 42
                    If Not e.Row.IsNull("Code") AndAlso e.Row("Code").ToString.Length > 0 Then
                        '�� Code ���� ---> 
                        If Not IsDBNull(e.ProposedValue) AndAlso Not e.ProposedValue.ToString.Length = 0 Then
                            Dim item As New SaleCNItem
                            item.CopyFromDataRow(CType(e.Row, TreeRow))
                            Dim suffix As String = "<" & item.Entity.Name & ">"
                            If e.ProposedValue.ToString <> suffix Then
                                If e.ProposedValue.ToString.EndsWith(suffix) Then
                                    Dim s As String = e.ProposedValue.ToString
                                    e.ProposedValue = s.Remove(s.Length - suffix.Length, suffix.Length)
                                End If
                            End If
                            If e.ProposedValue.ToString <> item.Entity.Name Then
                                e.ProposedValue = e.ProposedValue.ToString & suffix
                            End If
                        End If
                    Else
                        msgServ.ShowMessage("${res:Global.Error.ItemCodeMissing}")
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    End If
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            m_updating = False
        End Sub
        Private Function DupCode(ByVal e As DataColumnChangeEventArgs) As Boolean
            If e.Row.IsNull("stocki_entityType") Then
                Return False
            End If
            If IsDBNull(e.ProposedValue) Then
                Return False
            End If
            'For Each row As TreeRow In Me.ItemTable.Childs
            '    If Not row Is e.Row Then
            '        If Not row.IsNull("stocki_entityType") Then
            '            If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
            '                If Not row.IsNull("code") Then
            '                    If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
            '                        Return True
            '                    End If
            '                End If
            '            End If
            '        End If
            '    End If
            'Next
            Return False
        End Function
        Public Sub SetCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            If Me.CurrentItem Is Nothing Then
                Return
            End If
            Dim pdnItem As SaleCNItem = Me.CurrentItem
            m_updating = True
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If e.Row.IsNull("stocki_entityType") Then
                msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            If DupCode(e) Then
                msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {pdnItem.ItemType.Description, e.ProposedValue.ToString})
                e.ProposedValue = e.Row(e.Column)
                m_updating = False
                Return
            End If
            Select Case CInt(e.Row("stocki_entityType"))
                Case 0, 88, 89 'Blank
                    msgServ.ShowMessage("${res:Global.Error.BlankItemORLaborOrEQCannotHaveCode}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
                Case 28 'F/A
                    msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
                Case 19 'Tool
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
                                ClearRow(e)
                                pdnItem.CopyFromDataRow(CType(e.Row, TreeRow))
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim myTool As New Tool(e.ProposedValue.ToString)
                    If Not myTool.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        Dim myUnit As Unit = myTool.Unit
                        e.Row("stocki_entity") = myTool.Id
                        e.ProposedValue = myTool.Code
                        e.Row("stocki_itemName") = myTool.Name
                        If Not myUnit Is Nothing AndAlso myUnit.Originated Then
                            e.Row("stocki_unit") = myUnit.Id
                            e.Row("Unit") = myUnit.Name
                        Else
                            e.Row("stocki_unit") = DBNull.Value
                            e.Row("Unit") = DBNull.Value
                        End If
                        Dim ga As GeneralAccount = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.ToolAndOtherIncome)
                        'If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
                        '    e.Row("stocki_acct") = ga.Account.Id
                        '    e.Row("AccountCode") = ga.Account.Code
                        '    e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                        'Else
                        '    e.Row("stocki_acct") = DBNull.Value
                        '    e.Row("AccountCode") = DBNull.Value
                        '    e.Row("Account") = DBNull.Value
                        'End If
                        pdnItem.CopyFromDataRow(CType(e.Row, TreeRow))
                    End If
                Case 42 'LCI
                    If e.ProposedValue.ToString.Length = 0 Then
                        If e.Row(e.Column).ToString.Length <> 0 Then
                            If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
                                ClearRow(e)
                            Else
                                e.ProposedValue = e.Row(e.Column)
                            End If
                        End If
                        m_updating = False
                        Return
                    End If
                    Dim lci As New LCIItem(e.ProposedValue.ToString)
                    If Not lci.Originated Then
                        msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
                        e.ProposedValue = e.Row(e.Column)
                        m_updating = False
                        Return
                    Else
                        Dim myUnit As Unit = lci.DefaultUnit
                        e.Row("stocki_entity") = lci.Id
                        e.ProposedValue = lci.Code
                        e.Row("stocki_itemName") = lci.Name
                        If Not myUnit Is Nothing AndAlso myUnit.Originated Then
                            e.Row("stocki_unit") = myUnit.Id
                            e.Row("Unit") = myUnit.Name
                        Else
                            e.Row("stocki_unit") = DBNull.Value
                            e.Row("Unit") = DBNull.Value
                        End If
                        If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
                            e.Row("stocki_acct") = lci.Account.Id
                            e.Row("AccountCode") = lci.Account.Code
                            e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
                        Else
                            e.Row("stocki_acct") = DBNull.Value
                            e.Row("AccountCode") = DBNull.Value
                            e.Row("Account") = DBNull.Value
                        End If
                    End If
                Case Else
                    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
                    e.ProposedValue = e.Row(e.Column)
                    m_updating = False
                    Return
            End Select
            e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
            m_updating = False
        End Sub
        Public Sub SetUnitValue(ByVal e As System.Data.DataColumnChangeEventArgs)
            If m_updating Then
                Return
            End If
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Dim item As New SaleCNItem
            item.CopyFromDataRow(CType(e.Row, TreeRow))
            Dim oldConversion As Decimal = item.Conversion
            Dim newConversion As Decimal = 1
            Dim myUnit As New Unit(e.ProposedValue.ToString)
            Dim err As String = ""
            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
                If TypeOf item.Entity Is LCIItem Then
                    If Not CType(item.Entity, LCIItem).ValidUnit(myUnit) Then
                        err = "${res:Global.Error.NoUnitConversion}"
                    Else
                        newConversion = CType(item.Entity, LCIItem).GetConversion(myUnit)
                    End If
                ElseIf TypeOf item.Entity Is Tool Then
                    If Not (Not CType(item.Entity, Tool).Unit Is Nothing AndAlso CType(item.Entity, Tool).Unit.Id = myUnit.Id) Then
                        err = "${res:Global.Error.NoUnitConversion}"
                    End If
                End If
            Else
                err = "${res:Global.Error.InvalidUnit}"
            End If
            If err.Length = 0 Then
                If Not e.Row.IsNull("stocki_qty") AndAlso e.Row("stocki_qty").ToString.Length > 0 Then
                    e.Row("stocki_qty") = (oldConversion / newConversion) * CDec(e.Row("stocki_qty"))
                End If
                If Not e.Row.IsNull("stocki_unitprice") AndAlso e.Row("stocki_unitprice").ToString.Length > 0 Then
                    e.Row("stocki_unitprice") = (newConversion / oldConversion) * CDec(e.Row("stocki_unitprice"))
                End If
                e.Row("stocki_unit") = myUnit.Id
                e.ProposedValue = myUnit.Name
            Else
                e.ProposedValue = e.Row(e.Column)
                msgServ.ShowMessage(err)
            End If
        End Sub
        Private Sub ItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)
            'Dim row As DataRow = e.Row
            'Me.m_treeManager.Treetable.Childs.Remove(CType(row, TreeRow))
            'Try
            '    If Not Me.m_isInitialized Then
            '        Return
            '    End If

            '    Dim index As TreeRow = CType(e.Row, TreeRow)
            '    Me.m_treeManager.Treetable.Childs.Remove(index)
            'Catch ex As Exception
            '    MessageBox.Show(ex.ToString)
            'End Try
        End Sub
#End Region

#Region "Doc TreeTable Handlers"
        Private Sub DocTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_docCollInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_docTreeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            UpdateAmount()

            If DocValidateRow(CType(e.Row, TreeRow)) Then
                If index = Me.m_docTreeManager.Treetable.Childs.Count - 1 Then
                    Me.m_docTreeManager.Treetable.Childs.Add()
                End If
                DocUpdateAmount(e)
                Me.m_docTreeManager.Treetable.AcceptChanges()
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub DocUpdateAmount(ByVal e As DataColumnChangeEventArgs)
            Dim doc As SaleCNRefDoc = Me.CurrentDoc
            If doc Is Nothing Then
                Return
            End If
            UpdateAmount()
        End Sub
        Private Sub DocTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not Me.m_docCollInitialized Then
                Return
            End If
            If Me.m_docTreeManager.SelectedRow Is Nothing Then
                Return
            End If
            If Me.CurrentDoc Is Nothing Then
                Dim doc As New SaleCNRefDoc
                Me.m_entity.RefDocCollection.Add(doc)
                Me.m_docTreeManager.SelectedRow.Tag = doc
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "code"
                        SetDocCode(e)
                    Case "stockstock_amt"
                        SetDocAmount(e)
                    Case "stockstock_note"
                        SetDocNote(e)
                End Select
                DocValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub DocValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim code As Object = e.Row("code")
            Dim amount As Object = e.Row("stockstock_amt")

            Select Case e.Column.ColumnName.ToLower
                Case "code"
                    code = e.ProposedValue
                Case "stockstock_amt"
                    amount = e.ProposedValue
            End Select

            'If IsDBNull(amount) OrElse CDec(amount) <= 0 Then
            '    e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.AmountMissing}"))
            'Else
            '    e.Row.SetColumnError("percent", "")
            'End If
            If IsDBNull(code) OrElse code.ToString.Length = 0 Then
                e.Row.SetColumnError("code", Me.StringParserService.Parse("${res:Global.Error.CNRefDocMissing}"))
            Else
                e.Row.SetColumnError("code", "")
            End If

        End Sub
        Public Function DocValidateRow(ByVal row As TreeRow) As Boolean
            If row.Tag Is Nothing Then
                Return False
            End If
            Return True
        End Function
        Private m_DocUpdating As Boolean = False
        Public Sub SetDocAmount(ByVal e As DataColumnChangeEventArgs)
            If m_DocUpdating Then
                Return
            End If
            Dim doc As SaleCNRefDoc = Me.CurrentDoc
            If doc Is Nothing Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)
            m_DocUpdating = True
            If doc.Vatitem.TaxBase < value Then
                value = doc.Vatitem.TaxBase
            End If
            doc.Amount = value
            e.ProposedValue = Configuration.FormatToString(value, DigitConfig.Price)
            m_DocUpdating = False
        End Sub
        Public Sub SetDocNote(ByVal e As DataColumnChangeEventArgs)
            If m_DocUpdating Then
                Return
            End If
            Dim doc As SaleCNRefDoc = Me.CurrentDoc
            If doc Is Nothing Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            m_DocUpdating = True
            doc.Note = e.ProposedValue.ToString
            m_DocUpdating = False
        End Sub
        Private Function DupDocCode(ByVal e As DataColumnChangeEventArgs) As Boolean
            If CType(e.Row, TreeRow).Tag Is Nothing Then
                Return False
            End If
            If IsDBNull(e.ProposedValue) Then
                Return False
            End If
            Dim tr As TreeRow = CType(e.Row, TreeRow)
            For Each doc As SaleCNRefDoc In Me.m_entity.RefDocCollection
                If Not tr.Tag Is doc Then
                    If e.ProposedValue.ToString = doc.RefDocCode Then
                        Return True
                    End If
                End If
            Next
            Return False
        End Function
        Public Sub SetDocCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            'If m_DocUpdating Then
            '    Return
            'End If
            'If Me.CurrentDoc Is Nothing Then
            '    Return
            'End If
            'Dim doc As SaleCNRefDoc = Me.CurrentDoc
            'm_DocUpdating = True
            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'If DupDocCode(e) Then
            '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {"��Ѻ�Թ���", e.ProposedValue.ToString})
            '    e.ProposedValue = e.Row(e.Column)
            '    m_DocUpdating = False
            '    Return
            'End If
            'If e.ProposedValue.ToString.Length = 0 Then
            '    If e.Row(e.Column).ToString.Length <> 0 Then
            '        If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteDocDetail}", New String() {e.Row(e.Column).ToString}) Then
            '            ClearDocRow(e)
            '        Else
            '            e.ProposedValue = e.Row(e.Column)
            '        End If
            '    End If
            '    m_DocUpdating = False
            '    Return
            'End If
            'Dim myGR As New GoodsReceipt(e.ProposedValue.ToString)
            'If Not myGR.Originated Then
            '    msgServ.ShowMessageFormatted("${res:Global.Error.NoGoodsReceipt}", New String() {e.ProposedValue.ToString})
            '    e.ProposedValue = e.Row(e.Column)
            '    m_DocUpdating = False
            '    Return
            'Else
            '    myGR.RefreshTaxBase()
            '    doc.Amount = myGR.AfterTax
            '    doc.Code = myGR.Code
            '    doc.Id = myGR.Id
            '    e.Row("realamount") = doc.Amount
            'End If
            'm_DocUpdating = False
        End Sub
        Private Sub DocItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

        End Sub
        Private Sub ClearDocRow(ByVal e As DataColumnChangeEventArgs)
            e.Row("Linenumber") = DBNull.Value
            e.Row("Code") = DBNull.Value
            e.Row("RealAmount") = DBNull.Value
            e.Row("stockstock_amt") = DBNull.Value
            e.Row("stockstock_note") = DBNull.Value
        End Sub
#End Region

#Region "WBS TreeTable Handlers"
        Private Sub WBSTreetable_ColumnChanged(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_wbsdInitialized Then
                Return
            End If
            Dim index As Integer = Me.m_wbsTreeManager.Treetable.Childs.IndexOf(CType(e.Row, TreeRow))
            If WBSValidateRow(CType(e.Row, TreeRow)) Then
                'UpdateAmount(e)
                Me.m_wbsTreeManager.Treetable.AcceptChanges()
            End If
            Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub WBSUpdateAmount(ByVal e As DataColumnChangeEventArgs)
            Dim item As WBSDistribute = Me.CurrentWsbsd
            If item Is Nothing Then
                Return
            End If
            'Dim tr As TreeRow = Me.m_treeManager.SelectedRow
            'Dim gitem As New SaleCNItem
            'gitem.CopyFromDataRow(tr)
            'e.Row("Amount") = Configuration.FormatToString(item.Percent * gitem.Amount / 100, DigitConfig.Price)
        End Sub
        Private Sub WBSTreetable_ColumnChanging(ByVal sender As Object, ByVal e As System.Data.DataColumnChangeEventArgs)
            If Not m_wbsdInitialized Then
                Return
            End If
            Try
                Select Case e.Column.ColumnName.ToLower
                    Case "wbs"
                        SetWBSCode(e)
                    Case "percent"
                        SetWBSPercent(e)
                End Select
                WBSValidateRow(e)
            Catch ex As Exception
                MessageBox.Show(ex.ToString)
            End Try
        End Sub
        Public Sub WBSValidateRow(ByVal e As DataColumnChangeEventArgs)
            Dim wbs As Object = e.Row("wbs")
            Dim percent As Object = e.Row("percent")

            Select Case e.Column.ColumnName.ToLower
                Case "wbs"
                    wbs = e.ProposedValue
                Case "percent"
                    percent = e.ProposedValue
                Case Else
                    Return
            End Select

            Dim isBlankRow As Boolean = False
            If IsDBNull(wbs) Then
                isBlankRow = True
            End If

            If Not isBlankRow Then
                If IsDBNull(percent) OrElse CDec(percent) <= 0 Then
                    e.Row.SetColumnError("percent", Me.StringParserService.Parse("${res:Global.Error.PercentMissing}"))
                Else
                    e.Row.SetColumnError("percent", "")
                End If
                If IsDBNull(wbs) OrElse wbs.ToString.Length = 0 Then
                    e.Row.SetColumnError("wbs", Me.StringParserService.Parse("${res:Global.Error.WBSMissing}"))
                Else
                    e.Row.SetColumnError("wbs", "")
                End If
            End If

        End Sub
        Public Function WBSValidateRow(ByVal row As TreeRow) As Boolean
            If row.IsNull("WBS") Then
                Return False
            End If
            Return True
        End Function
        Private m_wbsUpdating As Boolean = False
        Public Sub SetWBSPercent(ByVal e As DataColumnChangeEventArgs)
            If m_wbsUpdating Then
                Return
            End If
            Dim item As WBSDistribute = Me.CurrentWsbsd
            If item Is Nothing Then
                Return
            End If
            If IsDBNull(e.ProposedValue) OrElse e.ProposedValue.ToString.Length = 0 Then
                e.ProposedValue = ""
                Return
            End If
            e.ProposedValue = Configuration.FormatToString(CDec(TextParser.Evaluate(e.ProposedValue.ToString)), DigitConfig.Price)
            Dim value As Decimal = CDec(e.ProposedValue)
            m_wbsUpdating = True
            item.Percent = value
            m_wbsUpdating = False
        End Sub

        'Private Function DupWBSCode(ByVal e As DataColumnChangeEventArgs) As Boolean
        '    If e.Row.IsNull("stocki_entityType") Then
        '        Return False
        '    End If
        '    If IsDBNull(e.ProposedValue) Then
        '        Return False
        '    End If
        '    For Each row As TreeRow In Me.ItemTable.Childs
        '        If Not row Is e.Row Then
        '            If Not row.IsNull("stocki_entityType") Then
        '                If CInt(row("stocki_entityType")) = CInt(e.Row("stocki_entityType")) Then
        '                    If Not row.IsNull("code") Then
        '                        If e.ProposedValue.ToString.ToLower = row("code").ToString.ToLower Then
        '                            Return True
        '                        End If
        '                    End If
        '                End If
        '            End If
        '        End If
        '    Next
        '    Return False
        'End Function
        Public Sub SetWBSCode(ByVal e As System.Data.DataColumnChangeEventArgs)
            'If m_wbsUpdating Then
            '    Return
            'End If
            'm_wbsUpdating = True
            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'If e.Row.IsNull("stocki_entityType") Then
            '    msgServ.ShowMessage("${res:Global.Error.NoItemType}")
            '    e.ProposedValue = e.Row(e.Column)
            '    m_wbsUpdating = False
            '    Return
            'End If
            'If DupCode(e) Then
            '    Dim item As New SaleCNItem
            '    item.CopyFromDataRow(CType(e.Row, TreeRow))
            '    msgServ.ShowMessageFormatted("${res:Global.Error.AlreadyHasCode}", New String() {item.ItemType.Description, e.ProposedValue.ToString})
            '    e.ProposedValue = e.Row(e.Column)
            '    m_wbsUpdating = False
            '    Return
            'End If
            'Select Case CInt(e.Row("stocki_entityType"))
            '    Case 0 'Blank
            '        msgServ.ShowMessage("${res:Global.Error.BlankItemCannotHaveCode}")
            '        e.ProposedValue = e.Row(e.Column)
            '        m_wbsUpdating = False
            '        Return
            '    Case 28 'F/A
            '        msgServ.ShowMessage("${res:Global.Error.FACannotHaveCode}")
            '        e.ProposedValue = e.Row(e.Column)
            '        m_wbsUpdating = False
            '        Return
            '    Case 19 'Tool
            '        If e.ProposedValue.ToString.Length = 0 Then
            '            If e.Row(e.Column).ToString.Length <> 0 Then
            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteToolDetail}", New String() {e.Row(e.Column).ToString}) Then
            '                    ClearRow(e)
            '                Else
            '                    e.ProposedValue = e.Row(e.Column)
            '                End If
            '            End If
            '            m_wbsUpdating = False
            '            Return
            '        End If
            '        Dim myTool As New Tool(e.ProposedValue.ToString)
            '        If Not myTool.Originated Then
            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoTool}", New String() {e.ProposedValue.ToString})
            '            e.ProposedValue = e.Row(e.Column)
            '            m_wbsUpdating = False
            '            Return
            '        Else
            '            Dim myUnit As Unit = myTool.Unit
            '            e.Row("stocki_entity") = myTool.Id
            '            e.ProposedValue = myTool.Code
            '            e.Row("stocki_itemName") = myTool.Name
            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
            '                e.Row("stocki_unit") = myUnit.Id
            '                e.Row("Unit") = myUnit.Name
            '            Else
            '                e.Row("stocki_unit") = DBNull.Value
            '                e.Row("Unit") = DBNull.Value
            '            End If
            '            Dim ga As GeneralAccount = GeneralAccount.GetGAForEntity(myTool.EntityId, Me.EntityId)
            '            If Not ga.Account Is Nothing AndAlso ga.Account.Originated Then
            '                e.Row("stocki_acct") = ga.Account.Id
            '                e.Row("AccountCode") = ga.Account.Code
            '                e.Row("Account") = ga.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            '            Else
            '                e.Row("stocki_acct") = DBNull.Value
            '                e.Row("AccountCode") = DBNull.Value
            '                e.Row("Account") = DBNull.Value
            '            End If
            '        End If
            '    Case 42 'LCI
            '        If e.ProposedValue.ToString.Length = 0 Then
            '            If e.Row(e.Column).ToString.Length <> 0 Then
            '                If msgServ.AskQuestionFormatted("${res:Global.Question.DeleteLCIDetail}", New String() {e.Row(e.Column).ToString}) Then
            '                    ClearRow(e)
            '                Else
            '                    e.ProposedValue = e.Row(e.Column)
            '                End If
            '            End If
            '            m_wbsUpdating = False
            '            Return
            '        End If
            '        Dim lci As New LCIItem(e.ProposedValue.ToString)
            '        If Not lci.Originated Then
            '            msgServ.ShowMessageFormatted("${res:Global.Error.NoLCI}", New String() {e.ProposedValue.ToString})
            '            e.ProposedValue = e.Row(e.Column)
            '            m_wbsUpdating = False
            '            Return
            '        Else
            '            Dim myUnit As Unit = lci.DefaultUnit
            '            e.Row("stocki_entity") = lci.Id
            '            e.ProposedValue = lci.Code
            '            e.Row("stocki_itemName") = lci.Name
            '            If Not myUnit Is Nothing AndAlso myUnit.Originated Then
            '                e.Row("stocki_unit") = myUnit.Id
            '                e.Row("Unit") = myUnit.Name
            '            Else
            '                e.Row("stocki_unit") = DBNull.Value
            '                e.Row("Unit") = DBNull.Value
            '            End If
            '            If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
            '                e.Row("stocki_acct") = lci.Account.Id
            '                e.Row("AccountCode") = lci.Account.Code
            '                e.Row("Account") = lci.Account.Name & "<" & Me.StringParserService.Parse("${res:Global.Default}") & ">"
            '            Else
            '                e.Row("stocki_acct") = DBNull.Value
            '                e.Row("AccountCode") = DBNull.Value
            '                e.Row("Account") = DBNull.Value
            '            End If
            '        End If
            '    Case Else
            '        msgServ.ShowMessage("${res:Global.Error.NoItemType}")
            '        e.ProposedValue = e.Row(e.Column)
            '        m_wbsUpdating = False
            '        Return
            'End Select
            'e.Row("stocki_qty") = Configuration.FormatToString(1D, DigitConfig.Qty)
            'm_wbsUpdating = False
        End Sub
        Private Sub WBSItemDelete(ByVal sender As Object, ByVal e As System.Data.DataRowChangeEventArgs)

        End Sub
#End Region

#Region "IListDetail"
        Public Overrides Sub CheckFormEnable()
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Status.Value = 0 _
            OrElse m_entityRefed = 1 _
            OrElse Me.m_entity.Payment.Status.Value = 0 _
            OrElse Me.m_entity.Payment.Status.Value >= 3 _
            Then
                For Each ctrl As Control In Me.grbDelivery.Controls
                    ctrl.Enabled = False
                Next
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = False
                Next
                'tgItem.Enabled = True
                'For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                '    colStyle.ReadOnly = True
                'Next
            Else
                For Each ctrl As Control In Me.grbDelivery.Controls
                    ctrl.Enabled = CBool(m_enableState(ctrl))
                Next
                For Each ctrl As Control In Me.Controls
                    ctrl.Enabled = CBool(m_enableState(ctrl))
                Next
                'For Each colStyle As DataGridColumnStyle In Me.m_treeManager.GridTableStyle.GridColumnStyles
                '    colStyle.ReadOnly = CBool(m_tableStyleEnable(colStyle))
                'Next
            End If
            CheckWBSRight()
        End Sub
        Private Sub CheckWBSRight()
            Dim secSrv As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)
            Dim level As Integer = secSrv.GetAccess(256)
            Dim checkString As String = BinaryHelper.DecToBin(level, 5)
            checkString = BinaryHelper.RevertString(checkString)
            If Not CBool(checkString.Substring(0, 1)) Then
                '�������
                Me.lblWBS.Visible = False
                Me.tgWBS.Visible = False
                Me.ibtnAddWBS.Visible = False
                Me.ibtnDelWBS.Visible = False
            ElseIf Not CBool(checkString.Substring(1, 1)) Then
                '������
                Me.lblWBS.Visible = True
                Me.tgWBS.Visible = True
                Me.ibtnAddWBS.Visible = True
                Me.ibtnDelWBS.Visible = True

                Me.tgWBS.Enabled = False
                Me.ibtnAddWBS.Enabled = False
                Me.ibtnDelWBS.Enabled = False
            Else
                Me.lblWBS.Visible = True
                Me.tgWBS.Visible = True
                Me.ibtnAddWBS.Visible = True
                Me.ibtnDelWBS.Visible = True

                Me.tgWBS.Enabled = True
                Me.ibtnAddWBS.Enabled = True
                Me.ibtnDelWBS.Enabled = True
            End If
        End Sub
        Public Overrides Sub ClearDetail()
            Me.StatusBarService.SetMessage("")
            For Each ctrl As Control In Me.grbDelivery.Controls
                If ctrl.Name.StartsWith("txt") Then
                    ctrl.Text = ""
                End If
            Next
            For Each ctrl As Control In Me.grbSummary.Controls
                If ctrl.Name.StartsWith("txt") Then
                    ctrl.Text = ""
                End If
            Next
            For Each ctrl As Control In Me.Controls
                If ctrl.Name.StartsWith("txt") Then
                    ctrl.Text = ""
                End If
            Next
            Me.dtpDocDate.Value = Now
            cmbTaxType.SelectedIndex = 1
        End Sub
        Public Overrides Sub SetLabelText()
            If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.grbSummary}")
            Me.lblAdjVal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblAdjVal}")
            Me.lblDiff.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblDiff}")
            Me.lblNote.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblNote}")
            Me.lblItemRf.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblItemRf}")
            Me.lblItem.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblItem}")
            Me.lbOrgTotalUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblAdjValUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblDiffUnit.Text = Me.StringParserService.Parse("${res:Global.CurrencyUnit}")
            Me.lblOrgTotal.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblOrgTotal}")
            Me.grbDelivery.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.grbDelivery}")

            Me.lblCustomer.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblCustomer}")
            Me.Validator.SetDisplayName(Me.txtCustomerCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.txtCustomerCodeAlert}"))

            Me.lblCreditPrd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblCreditPrd}")
            Me.lblDay.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblDay}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblCode}")
            Me.lblDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblDocDate}")

            Me.lblInvoiceCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblInvoiceCode}")
            Me.Validator.SetDisplayName(Me.txtInvoiceCode, Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.txtInvoiceCodeAlert}"))

            Me.lblInvoiceDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblInvoiceDate}")
            Me.lblPercent.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblPercent}")
            Me.lblDiscountAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblDiscountAmount}")
            Me.lblBeforeTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblBeforeTax}")
            Me.lblGross.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblGross}")
            Me.lblTaxType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblTaxType}")
            Me.lblTaxRate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblTaxRate}")
            Me.lblTaxBase.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblTaxBase}")
            Me.lblAfterTax.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblAfterTax}")
            Me.lblTaxAmount.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblTaxAmount}")
            Me.lblDueDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblDueDate}")
            Me.lblToCostCenter.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.SaleCNDetailView.lblToCostCenter}")
        End Sub
        Protected Overrides Sub EventWiring()
            AddHandler cmbCode.TextChanged, AddressOf Me.ChangeProperty
            AddHandler cmbCode.SelectedIndexChanged, AddressOf Me.ChangeProperty

            AddHandler txtNote.TextChanged, AddressOf Me.ChangeProperty

            AddHandler txtCustomerCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtCustomerCode.TextChanged, AddressOf Me.TextHandler

            AddHandler txtDocDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtDueDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDueDate.ValueChanged, AddressOf Me.ChangeProperty

            AddHandler txtCreditPrd.Validated, AddressOf Me.ChangeProperty
            AddHandler txtCreditPrd.TextChanged, AddressOf Me.TextHandler

            AddHandler txtTaxBase.TextChanged, AddressOf Me.ChangeProperty
            AddHandler txtDiscountRate.TextChanged, AddressOf Me.ChangeProperty

            AddHandler cmbTaxType.SelectedIndexChanged, AddressOf Me.ChangeProperty

            AddHandler txtInvoiceCode.TextChanged, AddressOf Me.TextHandler
            AddHandler txtInvoiceCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtInvoiceDate.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpInvoiceDate.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtToCostCenterCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtToCostCenterCode.TextChanged, AddressOf Me.TextHandler
            AddHandler txtTaxRate.TextChanged, AddressOf Me.TextHandler
            AddHandler txtTaxRate.Validated, AddressOf Me.ChangeProperty

        End Sub
        Private supplierCodeChanged As Boolean = False
        Private txtcreditprdChanged As Boolean = False
        Private toCCCodeChanged As Boolean = False
        Private txtTaxRateChanged As Boolean = False
        Private Sub TextHandler(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcustomercode"
                    supplierCodeChanged = True
                Case "txtcreditprd"
                    txtcreditprdChanged = True
                Case "txtinvoicecode"
                    m_invoicecodechange = True
                Case "txttocostcentercode"
                    toCCCodeChanged = True
                Case "txttaxrate"
                    txtTaxRateChanged = True
            End Select
        End Sub
        Private m_oldInvoiceCode As String = ""
        Public Overrides Sub UpdateEntityProperties()
            m_isInitialized = False
            ClearDetail()
            If m_entity Is Nothing Then
                m_isInitialized = True
                Return
            End If

            'txtCode.Text = m_entity.Code
            txtCreditPrd.Text = m_entity.CreditPeriod.ToString
            m_oldCode = m_entity.Code
            Me.chkAutorun.Checked = Me.m_entity.AutoGen
            Me.UpdateAutogenStatus()

            txtDocDate.Text = MinDateToNull(Me.m_entity.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDocDate.Value = MinDateToNow(Me.m_entity.DocDate)

            txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)

            Dim myVat As Vat = Me.m_entity.Vat
            If Not myVat Is Nothing Then
                Dim myVatitem As VatItem
                If myVat.ItemCollection.Count <= 0 Then
                    Me.m_entity.Vat.ItemCollection.Add(New VatItem)
                End If
                VatInputEnabled(True)
                myVatitem = myVat.ItemCollection(0)
                If myVat.AutoGen Then
                    Me.txtInvoiceCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(myVatitem.EntityId)
                Else
                    Me.txtInvoiceCode.Text = myVatitem.Code
                End If
                If Me.txtInvoiceCode.Text.Length = 0 Then
                    VatInputEnabled(False)
                End If
                'Me.txtInvoiceDate.Text = MinDateToNull(myVatitem.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                'Me.dtpInvoiceDate.Value = MinDateToNow(myVatitem.DocDate)
                Me.txtInvoiceDate.Text = MinDateToNull(myVatitem.DocDate, "")
                Me.dtpInvoiceDate.Value = MinDateToNow(myVatitem.DocDate)
            End If
            '�ͧ���
            'If Not myVat Is Nothing Then
            '    If myVat.MaxRowIndex = -1 Then
            '        VatInputEnabled(True)
            '        Me.txtInvoiceCode.Text = ""
            '        Me.txtInvoiceDate.Text = ""
            '        Me.dtpInvoiceDate.Value = Now
            '    ElseIf myVat.MaxRowIndex = 0 Then
            '        VatInputEnabled(True)
            '        Dim myVatitem As New VatItem
            '        myVatitem.CopyFromDataRow(myVat.ItemTable.Childs(0))
            '        Me.txtInvoiceCode.Text = myVatitem.Code
            '        Me.txtInvoiceDate.Text = MinDateToNull(myVatitem.DocDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            '        Me.dtpInvoiceDate.Value = MinDateToNow(myVatitem.DocDate)
            '    Else
            '        VatInputEnabled(False)
            '        Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
            '        Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.MultipleInvoiceText}")
            '        Me.dtpInvoiceDate.Value = Now
            '    End If
            'End If
            m_oldInvoiceCode = Me.txtInvoiceCode.Text
            Me.chkAutoRunVat.Checked = Me.m_entity.Vat.AutoGen
            'Me.UpdateVatAutogenStatus()

            txtCustomerCode.Text = m_entity.Customer.Code
            txtCustomerName.Text = m_entity.Customer.Name

            txtNote.Text = m_entity.Note
            txtToCostCenterCode.Text = m_entity.ToCostCenter.Code
            txtToCostCenterName.Text = m_entity.ToCostCenter.Name
            UpdateCC()

            For Each item As IdValuePair In Me.cmbTaxType.Items
                If Me.m_entity.TaxType.Value = item.Id Then
                    Me.cmbTaxType.SelectedItem = item
                End If
            Next

            'Load Items**********************************************************
            Me.m_treeManager.Treetable = Me.m_entity.ItemTable
            AddHandler Me.m_entity.PropertyChanged, AddressOf PropChanged
            Me.Validator.DataTable = m_treeManager.Treetable
            '********************************************************************

            RefreshDocs()


            UpdateAmount()

            RefreshBlankGrid()
            RefreshBlankDocGrid()

            SetStatus()
            SetLabelText()
            CheckFormEnable()
            m_isInitialized = True
        End Sub
        Private Sub UpdateCC()
            Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
            Me.txtToCostCenterName.Text = Me.m_entity.ToCostCenter.Name
        End Sub
        Private Sub VatInputEnabled(ByVal enable As Boolean)
            Me.txtInvoiceCode.Enabled = enable
            Me.txtInvoiceDate.Enabled = enable
            Me.dtpInvoiceDate.Enabled = enable
            Me.chkAutoRunVat.Enabled = enable
            If enable Then
                Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.DateTimeType)
                Me.Validator.SetRequired(Me.txtInvoiceCode, False)
                If Me.m_isInitialized Then
                    SetVatToOneDoc()
                End If
            Else
                Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.StringType)
                Me.Validator.SetRequired(Me.txtInvoiceCode, False)
            End If
        End Sub
        Private Sub PropChanged(ByVal sender As Object, ByVal e As PropertyChangedEventArgs)
            If Me.m_isInitialized AndAlso (e.Name = "ItemChanged" Or e.Name = "QtyChanged") Then
                If e.Name = "QtyChanged" Then
                    Me.UpdateAmount()
                End If
                Me.WorkbenchWindow.ViewContent.IsDirty = True
            End If
        End Sub
        Private m_dateSetting As Boolean = False
        Private m_invoicecodechange As Boolean = False
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            If Me.m_entity Is Nothing Or Not m_isInitialized Then
                Return
            End If
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "cmbcode"
                    '���� AutoCode
                    If TypeOf cmbCode.SelectedItem Is AutoCodeFormat Then
                        Me.m_entity.AutoCodeFormat = CType(cmbCode.SelectedItem, AutoCodeFormat)
                        m_entity.Code = m_entity.AutoCodeFormat.Format
                        Me.m_entity.OnGlChanged()
                    Else
                        Me.m_entity.Code = cmbCode.Text
                    End If
                    dirtyFlag = True
                Case "txtnote"
                    Me.m_entity.Note = txtNote.Text
                    dirtyFlag = True
                Case "txtcustomercode"
                    If supplierCodeChanged Then
                        supplierCodeChanged = False
                        dirtyFlag = ContactCustomer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
                        If dirtyFlag Then
                            For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
                                vitem.PrintName = Me.m_entity.Customer.Name
                                vitem.PrintAddress = Me.m_entity.Customer.BillingAddress
                                vitem.TaxId = Me.m_entity.Customer.TaxId
                                vitem.BranchId = Me.m_entity.Customer.BranchId

                            Next
                            Me.m_entity.CreditPeriod = Me.m_entity.Customer.CreditPeriod
                            Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
                            txtcreditprdChanged = False
                        End If
                        Me.RefreshBlankGrid()
                        RefreshBlankDocGrid()
                    End If
                Case "dtpdocdate"
                    If Not Me.m_entity.DocDate.Equals(dtpDocDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDate.Text = MinDateToNull(dtpDocDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.DocDate = dtpDocDate.Value
                            If Not Me.m_entity.Receive Is Nothing Then
                                Me.m_entity.Receive.DocDate = dtpDocDate.Value
                            End If
                            dirtyFlag = True
                        End If
                    End If
                    txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                    dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
                Case "txtdocdate"
                    m_dateSetting = True
                    If Not Me.txtDocDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDate.Text)
                        If Not Me.m_entity.DocDate.Equals(theDate) Then
                            dtpDocDate.Value = theDate
                            Me.m_entity.DocDate = dtpDocDate.Value
                            If Not Me.m_entity.Receive Is Nothing Then
                                Me.m_entity.Receive.DocDate = dtpDocDate.Value
                            End If
                            dirtyFlag = True
                        End If
                    Else
                        dtpDocDate.Value = Date.Now
                        Me.m_entity.DocDate = Date.MinValue
                        If Not Me.m_entity.Payment Is Nothing Then
                            Me.m_entity.Payment.DocDate = Date.MinValue
                        End If
                    End If
                    txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                    dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
                    m_dateSetting = False
                Case "dtpduedate"
                    If Not Me.m_entity.DueDate.Equals(dtpDueDate.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDueDate.Text = MinDateToNull(dtpDueDate.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.m_entity.DueDate = dtpDueDate.Value
                            dirtyFlag = True
                        End If
                    End If
                    Me.txtCreditPrd.Text = Me.m_entity.CreditPeriod
                Case "txtduedate"
                    m_dateSetting = True
                    If Not Me.txtDueDate.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDueDate) = "" Then
                        Dim theDate As Date = CDate(Me.txtDueDate.Text)
                        If Not Me.m_entity.DueDate.Equals(theDate) Then
                            dtpDueDate.Value = theDate
                            Me.m_entity.DueDate = dtpDueDate.Value
                            dirtyFlag = True
                        End If
                    Else
                        dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
                    End If
                    Me.txtCreditPrd.Text = Me.m_entity.CreditPeriod
                    m_dateSetting = False
                Case "txtcreditprd"
                    If txtcreditprdChanged Then
                        txtcreditprdChanged = False
                        Dim txt As String = Me.txtCreditPrd.Text
                        If txt.Length > 0 AndAlso IsNumeric(txt) Then
                            Me.m_entity.CreditPeriod = CInt(txt)
                        Else
                            Me.m_entity.CreditPeriod = 0
                        End If
                        txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
                        txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                        dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
                        dirtyFlag = True
                    End If
                Case "txttocostcentercode"
                    If toCCCodeChanged Then
                        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                        If Me.txtToCostCenterCode.TextLength <> 0 Then
                            If msgServ.AskQuestion("${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Message.ChangeCC}", "${res:Longkong.Pojjaman.Gui.Panels.MatwithdrawDetail.Caption.ChangeCC}") Then
                                dirtyFlag = CostCenter.GetCostCenterWithoutRight(txtToCostCenterCode, txtToCostCenterName, Me.m_entity.ToCostCenter)
                                'UpdateDestAdmin()
                                'UpdateAccount()
                                Try
                                    If oldCCId <> Me.m_entity.ToCostCenter.Id Then
                                        oldCCId = Me.m_entity.ToCostCenter.Id
                                        ChangeCC()
                                    End If
                                Catch ex As Exception

                                End Try
                                toCCCodeChanged = False
                            Else
                                Me.txtToCostCenterCode.Text = Me.m_entity.ToCostCenter.Code
                                toCCCodeChanged = False
                            End If
                        Else
                            Me.m_entity.ToCostCenter = New CostCenter
                            txtToCostCenterName.Text = ""
                            If oldCCId <> Me.m_entity.ToCostCenter.Id Then
                                oldCCId = Me.m_entity.ToCostCenter.Id
                                ChangeCC()
                            End If
                        End If
                    End If
                Case "txttaxbase"
                    'Todo
                Case "txtdiscountrate"
                    Me.m_entity.Discount.Rate = txtDiscountRate.Text
                    UpdateAmount()
                    dirtyFlag = True
                Case "cmbtaxtype"
                    Dim item As IdValuePair = CType(Me.cmbTaxType.SelectedItem, IdValuePair)
                    Me.m_entity.TaxType.Value = item.Id
                    UpdateAmount()
                    RefreshDocs()
                    dirtyFlag = True
                Case "txttaxrate"
                    If txtTaxRate.Text.Trim.Length > 0 AndAlso IsNumeric(txtTaxRate.Text) Then
                        If txtTaxRateChanged Then
                            Me.m_entity.TaxRate = CDbl(txtTaxRate.Text)
                            UpdateAmount()
                            dirtyFlag = True
                            txtTaxRateChanged = False
                        End If
                    End If
                Case "txtinvoicecode"
                    If m_oldInvoiceCode <> Me.txtInvoiceCode.Text Then
                        Me.m_entity.Vat.CodeChanged(Me.txtInvoiceCode.Text)
                        m_oldInvoiceCode = Me.txtInvoiceCode.Text
                        If Me.txtInvoiceCode.Text.Trim.Length = 0 Then
                            Me.m_entity.SetNoVat(True)
                            Me.VatInputSetRequireDate(False)
                            Me.txtInvoiceDate.Text = ""
                            Me.dtpInvoiceDate.Value = Now
                        Else
                            Me.VatInputSetRequireDate(True)
                            Me.m_entity.SetNoVat()
                        End If

                        dirtyFlag = True
                    End If
                    If Me.txtInvoiceCode.Text.Length = 0 Then
                        VatInputEnabled(False)
                    End If
                Case "txtinvoicedate"
                    m_dateSetting = True
                    dirtyFlag = Me.m_entity.Vat.DateTextChanged(txtInvoiceDate, dtpInvoiceDate, Me.Validator)
                    m_dateSetting = False
                Case "dtpinvoicedate"
                    dirtyFlag = Me.m_entity.Vat.DatePickerChanged(dtpInvoiceDate, txtInvoiceDate, m_dateSetting)
                Case Else
            End Select
            Me.WorkbenchWindow.ViewContent.IsDirty = Me.WorkbenchWindow.ViewContent.IsDirty Or dirtyFlag
            CheckFormEnable()
        End Sub
        Private Sub VatInputSetRequireDate(ByVal require As Boolean)
            If require Then
                Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.DateTimeType)
                Me.Validator.SetRequired(Me.txtInvoiceDate, True)
            Else
                Me.Validator.SetDataType(Me.txtInvoiceDate, DataTypeConstants.StringType)
                Me.Validator.SetRequired(Me.txtInvoiceDate, False)
            End If
        End Sub
        Private oldCCId As Integer
        Private Sub ChangeCC()
            oldCCId = Me.m_entity.ToCostCenter.Id
        End Sub
        'Private Sub SetVatToNoDoc()
        '  Dim flag As Boolean = Me.m_isInitialized
        '  Me.m_isInitialized = False
        '  Me.m_entity.Vat.ItemCollection.Clear()
        '  Me.txtInvoiceCode.Text = ""
        '  Me.txtInvoiceDate.Text = ""
        '  Me.dtpInvoiceDate.Value = Now
        '  Me.m_isInitialized = flag
        'End Sub
        Private Sub SetVatToOneDoc()
            Dim flag As Boolean = Me.m_isInitialized
            Me.m_isInitialized = False
            Me.m_entity.Vat.SetVatToOneDoc(txtInvoiceCode _
            , txtInvoiceDate _
            , dtpInvoiceDate _
            , AddressOf UpdateVatAutogenStatus)
            Me.m_isInitialized = flag
        End Sub
        Private Sub UpdateAmount()
            m_isInitialized = False
            m_entity.RefreshTaxBase()

            txtGross.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)
            txtDiscountAmount.Text = Configuration.FormatToString(m_entity.DiscountAmount, DigitConfig.Price)
            txtBeforeTax.Text = Configuration.FormatToString(m_entity.BeforeTax, DigitConfig.Price)
            txtAfterTax.Text = Configuration.FormatToString(m_entity.AfterTax, DigitConfig.Price)
            txtTaxAmount.Text = Configuration.FormatToString(m_entity.TaxAmount, DigitConfig.Price)
            txtDiscountRate.Text = m_entity.Discount.Rate
            txtTaxRate.Text = Configuration.FormatToString(m_entity.TaxRate, DigitConfig.Price)
            txtTaxBase.Text = Configuration.FormatToString(m_entity.TaxBase, DigitConfig.Price)

            Dim realAmt As Decimal = m_entity.RefDocCollection.RealAmount
            txtOrgTotal.Text = Configuration.FormatToString(realAmt, DigitConfig.Price)
            txtAdjVal.Text = Configuration.FormatToString(realAmt - m_entity.Gross, DigitConfig.Price)
            txtDiff.Text = Configuration.FormatToString(m_entity.Gross, DigitConfig.Price)

            m_isInitialized = True
            SetVatInputAfterAmountChange()
            'SetVatToOneDoc()
            RefreshWBS()
        End Sub
        Private Sub SetVatInputAfterAmountChange()
            Dim temp As Boolean = m_isInitialized
            Me.m_isInitialized = False
            If Me.m_entity.TaxType.Value = 0 Then
                '����� Vat
                'SetVatToNoDoc()
                Me.VatInputEnabled(False)

                Me.txtInvoiceCode.Text = Me.StringParserService.Parse("${res:Global.NoTaxText}")
                Me.txtInvoiceDate.Text = Me.StringParserService.Parse("${res:Global.NoTaxText}")
                Me.dtpInvoiceDate.Value = Now

            ElseIf Me.m_entity.Vat.ItemCollection.Count <= 0 Then
                '����� Vatitem
                Me.m_entity.Vat.ItemCollection().Add(New VatItem)
                Dim myVatitem As VatItem
                myVatitem = Me.m_entity.Vat.ItemCollection(0)
                myVatitem.TaxBase = Me.m_entity.Vat.RefDoc.TaxBase * Me.m_entity.Vat.GetCurrencyConversion()
                Me.VatInputEnabled(True)
            Else
                '�� Vatitem �����
                Dim myVatitem As VatItem
                myVatitem = Me.m_entity.Vat.ItemCollection(0)
                myVatitem.TaxBase = Me.m_entity.Vat.RefDoc.TaxBase * Me.m_entity.Vat.GetCurrencyConversion()
                Me.VatInputEnabled(True)
            End If
            Me.m_isInitialized = temp
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
                End If
                If Not Object.ReferenceEquals(Me.m_entity, Value) Then
                    Me.m_entity = Nothing
                    Me.m_entity = CType(Value, SaleCN)
                End If
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
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbTaxType, "taxType", "code_Value <> 0")
            If cmbTaxType.Items.Count > 0 Then
                cmbTaxType.SelectedIndex = 1
            End If
        End Sub
#End Region

#Region "Event Handler"
        Private Sub ibtnAddWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAddWBS.Click
            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'If Me.m_entity Is Nothing Then
            '    Return
            'End If
            'Dim tr As TreeRow = Me.m_treeManager.SelectedRow
            'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
            'dt.Clear()
            'If tr Is Nothing Then
            '    Return
            'End If
            'If tr.Tag Is Nothing Then
            '    Return
            'End If
            'Dim item As New SaleCNItem
            'item.CopyFromDataRow(tr)
            'Dim wsdColl As WBSDistributeCollection = CType(tr.Tag, WBSDistributeCollection)
            'wsdColl.Add(New WBSDistribute)
            'Dim view As Integer = 45
            'm_wbsdInitialized = False
            'wsdColl.Populate(dt, item, view)
            'm_wbsdInitialized = True
            'Me.WorkbenchWindow.ViewContent.IsDirty = True
        End Sub
        Private Sub ibtnDelWBS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelWBS.Click
            'Dim tr As TreeRow = Me.m_treeManager.SelectedRow
            'Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
            'dt.Clear()
            'If tr Is Nothing Then
            '    Return
            'End If
            'If tr.Tag Is Nothing Then
            '    Return
            'End If
            'Dim item As New SaleCNItem
            'item.CopyFromDataRow(tr)
            'Dim wsdColl As WBSDistributeCollection = CType(tr.Tag, WBSDistributeCollection)
            'If wsdColl.Count > 0 Then
            '    wsdColl.Remove(wsdColl.Count - 1)
            '    Me.WorkbenchWindow.ViewContent.IsDirty = True
            'End If
            'Dim view As Integer = 45
            'm_wbsdInitialized = False
            'wsdColl.Populate(dt, item, view)
            'm_wbsdInitialized = True
        End Sub
        Private Sub tgItem_CurrentCellChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.CurrentCellChanged
            RefreshWBS()
        End Sub
        Private Sub RefreshWBS()
            Dim tr As TreeRow = Me.m_treeManager.SelectedRow
            Dim dt As TreeTable = Me.m_wbsTreeManager.Treetable
            dt.Clear()
            If tr Is Nothing Then
                Return
            End If
            If tr.Tag Is Nothing Then
                Return
            End If
            'Dim item As New SaleCNItem
            'item.CopyFromDataRow(tr)
            'Dim wsdColl As WBSDistributeCollection = CType(tr.Tag, WBSDistributeCollection)
            'm_wbsdInitialized = False
            'wsdColl.Populate(dt, item)
            'm_wbsdInitialized = True
        End Sub
        Private Sub chkAutorun_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutorun.CheckedChanged
            UpdateAutogenStatus()
        End Sub
        Private m_oldCode As String = ""
        Private Sub UpdateAutogenStatus()
            If Me.chkAutorun.Checked Then
                'Me.Validator.SetRequired(Me.txtCode, False)
                'Me.ErrorProvider1.SetError(Me.txtCode, "")
                'Me.txtCode.ReadOnly = True
                Me.cmbCode.DropDownStyle = ComboBoxStyle.DropDownList 'ComboBoxStyle.DropDown
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
                'Me.txtCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(Me.m_entity.EntityId)
                'Hack: set Code �� "" �ͧ
                'Me.m_entity.Code = ""
                Me.m_entity.Code = m_oldCode
                Me.m_entity.AutoGen = True
            Else
                ' Me.Validator.SetRequired(Me.txtCode, True)
                Me.cmbCode.DropDownStyle = ComboBoxStyle.Simple
                Me.cmbCode.Text = m_oldCode
                'Me.txtCode.ReadOnly = False
                Me.m_entity.AutoGen = False
            End If
        End Sub
        Private Sub chkAutoRunVat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkAutoRunVat.CheckedChanged
            If m_isInitialized Then
                'SetVatToOneDoc()
                UpdateVatAutogenStatus()
            End If
        End Sub
        Private Sub UpdateVatAutogenStatus()
            If Me.m_entity.Vat Is Nothing Then
                Return
            End If
            Dim vi As VatItem
            If Me.m_entity.Vat.ItemCollection.Count <= 0 Then
                Me.m_entity.Vat.ItemCollection.Add(New VatItem)
            End If

            vi = Me.m_entity.Vat.ItemCollection(0)
            If Me.chkAutoRunVat.Checked Then
                Me.Validator.SetRequired(Me.txtInvoiceCode, False)
                Me.ErrorProvider1.SetError(Me.txtInvoiceCode, "")
                Me.txtInvoiceCode.ReadOnly = True
                m_oldInvoiceCode = Me.txtInvoiceCode.Text
                Me.txtInvoiceCode.Text = BusinessLogic.Entity.GetAutoCodeFormat(vi.EntityId)
                'Hack: set Code �� "" �ͧ
                'vi.Code = ""
                vi.Code = Me.txtInvoiceCode.Text
                If Me.txtInvoiceDate.Text.Trim.Length = 0 Then
                    Me.txtInvoiceDate.Text = Now.ToShortDateString
                    Me.dtpInvoiceDate.Value = Now
                    vi.DocDate = Now
                Else
                    vi.DocDate = Me.dtpInvoiceDate.Value
                End If
                Me.m_entity.Vat.AutoGen = True
            Else
                Me.Validator.SetRequired(Me.txtInvoiceCode, False)
                Dim autoCodeFormat As String = ""
                If BusinessLogic.Entity.GetAutoCodeFormat(vi.EntityId) IsNot Nothing Then
                    autoCodeFormat = BusinessLogic.Entity.GetAutoCodeFormat(vi.EntityId)
                End If
                If autoCodeFormat.Equals(m_oldInvoiceCode) Then
                    Me.txtInvoiceCode.Text = ""
                Else
                    Me.txtInvoiceCode.Text = m_oldInvoiceCode
                End If
                Me.txtInvoiceCode.ReadOnly = False
                Me.m_entity.Vat.AutoGen = False
                'no vat
                Me.m_entity.Vat.CodeChanged(Me.txtInvoiceCode.Text)
                If Me.txtInvoiceCode.Text.Trim.Length = 0 Then
                    Me.m_entity.SetNoVat(True)
                    Me.VatInputSetRequireDate(False)
                    Me.txtInvoiceDate.Text = ""
                    Me.dtpInvoiceDate.Value = Now
                Else
                    Me.VatInputSetRequireDate(True)
                    Me.m_entity.SetNoVat()
                End If

            End If
        End Sub
        Public Sub AcctButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New Account, AddressOf SetAcct)
        End Sub
        Private Sub SetAcct(ByVal acct As ISimpleEntity)
            Me.m_treeManager.SelectedRow("AccountCode") = acct.Code
        End Sub
        Public Sub UnitButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim filters(0) As Filter
            Dim item As New SaleCNItem
            item.CopyFromDataRow(Me.m_treeManager.SelectedRow)
            Dim includeFilter As Boolean = False
            If TypeOf item.Entity Is Tool Then
                Dim mytool As Tool = CType(item.Entity, Tool)
                If Not mytool.Unit Is Nothing AndAlso mytool.Unit.Originated Then
                    filters(0) = New Filter("includedId", mytool.Unit.Id)
                    includeFilter = True
                End If
            ElseIf TypeOf item.Entity Is LCIItem Then
                Dim idList As String = CType(item.Entity, LCIItem).GetUnitIdList
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
        Public Sub ItemButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            If Me.m_entity.ItemTable.Rows(e.Row).IsNull("stocki_entityType") Then
                Dim entities(1) As ISimpleEntity
                entities(0) = New LCIItem
                entities(1) = New Tool
                myEntityPanelService.OpenListDialog(entities, AddressOf SetItems)
            Else
                Select Case CInt(Me.m_entity.ItemTable.Rows(e.Row)("stocki_entityType"))
                    Case 0, 28 'Blank
                        Return
                    Case 19 'Tool
                        myEntityPanelService.OpenListDialog(New Tool, AddressOf SetItems)
                    Case 42 'LCI
                        myEntityPanelService.OpenListDialog(New LCIItem, AddressOf SetItems)
                    Case Else

                End Select
            End If
        End Sub
        Private Function GetExcludeList() As String
            Dim ret As String = ""
            'For Each parentRow As TreeRow In Me.m_entity.ItemTable.Childs
            '    If Not parentRow.IsNull("pri_pr") AndAlso CInt(parentRow("pri_pr")) <> 0 Then
            '        For Each itemRow As TreeRow In parentRow.Childs
            '            If Not itemRow.IsNull("pri_linenumber") Then
            '                ret &= "|" & parentRow("pri_pr").ToString & ":" & itemRow("pri_linenumber").ToString & "|"
            '            End If
            '        Next
            '    End If
            'Next
            Return ret
        End Function
        Private Sub SetItems(ByVal items As BasketItemCollection)
            Dim index As Integer = tgItem.CurrentRowIndex
            For i As Integer = items.Count - 1 To 0 Step -1
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
                    If i = items.Count - 1 Then
                        If Me.m_entity.ItemTable.Childs.Count = 0 Then
                            Me.m_entity.AddBlankRow(1)
                            Me.m_entity.ItemTable.Rows(index)("stocki_entityType") = newType
                            Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
                        Else
                            Me.m_entity.ItemTable.Rows(index)("stocki_entityType") = newType
                            Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
                        End If
                    Else
                        Me.m_entity.Insert(index, New SaleCNItem)
                        Me.m_entity.ItemTable.Rows(index)("stocki_entityType") = newType
                        Me.m_entity.ItemTable.Rows(index)("Code") = newItem.Code
                    End If
                End If

                Me.m_entity.ItemTable.AcceptChanges()
            Next
            tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
        End Sub
        Private Sub ibtnBlank_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlank.Click
            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'If Me.m_entity Is Nothing Then
            '    Return
            'End If
            'Dim index As Integer = tgItem.CurrentRowIndex
            'If index = -1 Then
            '    Return
            'End If
            'If index > Me.m_entity.MaxRowIndex Then
            '    Return
            'End If
            'Dim row As TreeRow = CType(Me.m_entity.ItemTable.Rows(index), TreeRow)
            'If row.Level = 0 Then
            '    Return
            'End If
            'Dim parRow As TreeRow = CType(row.Parent, TreeRow)
            'If Not IsDBNull(parRow("poi_po")) AndAlso CStr(parRow("poi_po")).Length > 0 AndAlso CInt(parRow("poi_po")) > 0 Then
            '    Return
            'End If
            'Dim theItem As New SaleCNItem
            'Me.m_entity.Insert(index, theItem)
            'Me.m_entity.ItemTable.AcceptChanges()
            'tgItem.CurrentRowIndex = index
            'RefreshBlankGrid()
            'Me.WorkbenchWindow.ViewContent.IsDirty = True
            'UpdateAmount()
        End Sub
        Private Sub ibtnDelRow_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelRow.Click
            Dim index As Integer = Me.tgItem.CurrentRowIndex
            If index = -1 Then
                Return
            End If
            Dim row As TreeRow = CType(Me.m_entity.ItemTable.Rows(index), TreeRow)
            'If row.Level = 0 Then
            '    Return
            'End If
            If index > Me.m_entity.MaxRowIndex Then
                Return
            End If
            Me.m_entity.Remove(index)
            Me.tgItem.CurrentRowIndex = index
            RefreshBlankGrid()
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            UpdateAmount()
        End Sub
        Public Sub DocButtonClick(ByVal e As ButtonColumnEventArgs)
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            If Me.m_entity Is Nothing Then
                Return
            End If
            If Me.m_entity.Customer Is Nothing OrElse Not Me.m_entity.Customer.Originated Then
                msgServ.ShowMessage("${res:Global.Error.SpecifyCustomer}")
                Return
            End If
            Dim dlg As New BasketDialog
            AddHandler dlg.EmptyBasket, AddressOf SetDocs
            'Dim filters(2) As Filter
            'Dim excludeList As Object = ""
            'excludeList = GetExcludeList()
            'If excludeList.ToString.Length = 0 Then
            '    excludeList = DBNull.Value
            'End If
            'Dim prNeedsApproval As Boolean = False
            'prNeedsApproval = CBool(Configuration.GetConfig("ApprovePR"))
            'filters(0) = New Filter("excludeList", excludeList)
            'filters(1) = New Filter("prNeedsApproval", prNeedsApproval)
            'filters(2) = New Filter("excludeCanceled", True)
            Dim entities As New ArrayList
            If Me.m_entity.Customer.Originated Then
                entities.Add(m_entity.Customer)
            End If
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Dim v As New VatForSelection
            v.Direction = New VatDirection(0)
            entities.Add(v)
            myEntityPanelService.OpenListDialog(v, AddressOf SetDocs, entities)
        End Sub
        Private Function GetDocIDList() As String
            Dim ret As String = ""
            For Each doc As SaleCNRefDoc In Me.m_entity.RefDocCollection
                'If doc.RefDocId Then
                '    ret &= doc.Id.ToString & ","
                'End If
            Next
            If ret.EndsWith(",") Then
                ret = ret.Substring(0, ret.Length - 1)
            End If
            Return ret
        End Function
        Private Sub SetDocs(ByVal items As BasketItemCollection)
            Dim index As Integer = tgRefDoc.CurrentRowIndex
            For i As Integer = items.Count - 1 To 0 Step -1
                Dim item As StockBasketItem = CType(items(i), StockBasketItem)
                Dim newItem As SaleCNRefDoc
                If TypeOf item.Tag Is DataRow Then
                    newItem = New SaleCNRefDoc(CType(item.Tag, DataRow), "")
                End If
                If i = items.Count - 1 Then
                    '����á -- update old item
                    If Me.m_entity.RefDocCollection.Count = 0 Then
                        Me.m_entity.RefDocCollection.Add(newItem)
                    Else
                        Dim theDoc As SaleCNRefDoc = Me.CurrentDoc
                        If Me.CurrentDoc Is Nothing Then
                            Me.m_entity.RefDocCollection.Insert(index, newItem)
                            theDoc = Me.m_entity.RefDocCollection(index)
                        End If
                        theDoc.RefDocId = newItem.RefDocId
                        theDoc.RefDocCode = newItem.RefDocCode
                        theDoc.Vatitem = newItem.Vatitem
                    End If
                Else
                    Me.m_entity.RefDocCollection.Insert(index, newItem)
                End If
            Next
            RefreshDocs()
            tgRefDoc.CurrentRowIndex = index
            RefreshBlankDocGrid()
            UpdateAmount()
        End Sub
        Private Sub RefreshDocs()
            Dim flag As Boolean = Me.m_docCollInitialized
            Me.m_docCollInitialized = False
            Me.m_entity.RefDocCollection.Populate(m_docTreeManager.Treetable)
            Me.RefreshBlankDocGrid()
            Me.m_docCollInitialized = flag
        End Sub
        Private Sub ibtnBlankDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnBlankDoc.Click
            Dim row As TreeRow = Me.m_docTreeManager.SelectedRow
            If row Is Nothing Then
                Return
            End If

            Dim index As Integer = Me.m_docTreeManager.Treetable.Childs.IndexOf(row)
            If DocValidateRow(row) Then
                If index = Me.m_docTreeManager.Treetable.Childs.Count - 1 Then
                    Me.m_docTreeManager.Treetable.Childs.Add()
                End If
                Me.m_docTreeManager.Treetable.AcceptChanges()
            End If

            'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            'If Me.m_entity Is Nothing Then
            '    Return
            'End If
            'Dim index As Integer = Me.tgRefDoc.CurrentRowIndex
            'If index = -1 Then
            '    Return
            'End If
            'If index > Me.m_entity.MaxRowIndex Then
            '    Return
            'End If
            'Dim row As TreeRow = CType(Me.m_entity.ItemTable.Rows(index), TreeRow)
            'If row.Level = 0 Then
            '    Return
            'End If
            'Dim parRow As TreeRow = CType(row.Parent, TreeRow)
            'If Not IsDBNull(parRow("poi_po")) AndAlso CStr(parRow("poi_po")).Length > 0 AndAlso CInt(parRow("poi_po")) > 0 Then
            '    Return
            'End If
            'Dim theItem As New SaleCNItem
            'Me.m_entity.Insert(index, theItem)
            'Me.m_entity.ItemTable.AcceptChanges()
            'Me.tgRefDoc.CurrentRowIndex = index
            'RefreshBlankGrid()
            'Me.WorkbenchWindow.ViewContent.IsDirty = True
            'UpdateAmount()
        End Sub
        Private Sub ibtnDelDoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelDoc.Click
            Dim index As Integer = Me.tgRefDoc.CurrentRowIndex
            If index = -1 Then
                Return
            End If
            Dim doc As SaleCNRefDoc = Me.CurrentDoc
            If doc Is Nothing Then
                Return
            End If
            Me.m_entity.RefDocCollection.Remove(doc)
            Dim flag As Boolean = m_docCollInitialized
            m_docCollInitialized = False
            RefreshDocs()
            m_docCollInitialized = flag
            RefreshBlankDocGrid()
            Me.tgRefDoc.CurrentRowIndex = index
            Me.WorkbenchWindow.ViewContent.IsDirty = True
            UpdateAmount()
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
                Return (New SaleCN).DetailPanelIcon
            End Get
        End Property
#End Region

#Region "Event of Button controls"
        ' Customer
        Private Sub ibtnShowCustomer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomer.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New Customer)
        End Sub
        Private Sub ibtnShowCustomerDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowCustomerDialog.Click
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New ContactCustomer, AddressOf SetCustomer)
        End Sub
        Private Sub SetCustomer(ByVal e As ISimpleEntity)
            Me.txtCustomerCode.Text = e.Code
            Me.WorkbenchWindow.ViewContent.IsDirty = _
                Me.WorkbenchWindow.ViewContent.IsDirty _
                Or Customer.GetCustomer(txtCustomerCode, txtCustomerName, Me.m_entity.Customer)
            VatInputEnabled(True)
            For Each vitem As VatItem In Me.m_entity.Vat.ItemCollection
                vitem.PrintName = Me.m_entity.Customer.Name
                vitem.PrintAddress = Me.m_entity.Customer.BillingAddress
                vitem.TaxId = Me.m_entity.Customer.TaxId
                vitem.BranchId = Me.m_entity.Customer.BranchId
            Next
            Me.RefreshBlankGrid()
            RefreshBlankDocGrid()
            supplierCodeChanged = False
            Me.m_entity.CreditPeriod = Me.m_entity.Customer.CreditPeriod
            Me.txtCreditPrd.Text = Configuration.FormatToString(Me.m_entity.CreditPeriod, DigitConfig.Int)
            txtDueDate.Text = MinDateToNull(Me.m_entity.DueDate, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
            dtpDueDate.Value = MinDateToNow(Me.m_entity.DueDate)
            txtcreditprdChanged = False
        End Sub
        Private Sub ibtnShowToCostCenterDialog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCostCenterDialog.Click
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
            'ListType()
            'UpdateDestAdmin()
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
        Private Sub ShowCostCenter_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnShowToCostCenter.Click
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenPanel(New CostCenter)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Try
                    If Clipboard.GetDataObject Is Nothing Then
                        Return False
                    End If
                Catch ex As Exception
                    Return False
                End Try
                Dim data As IDataObject = Clipboard.GetDataObject
                If data.GetDataPresent((New Customer).FullClassName) Then
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
            Try
                If Clipboard.GetDataObject Is Nothing Then
                    Return
                End If
            Catch ex As Exception
                Return
            End Try
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New Customer).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New Customer).FullClassName))
                Dim entity As New Customer(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtsuppliercode", "txtsuppliername"
                            Me.SetCustomer(entity)
                    End Select
                End If
            End If
        End Sub
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
            Dim maxVisibleCount As Integer
            Dim tgRowHeight As Integer = 17
            maxVisibleCount = CInt(Math.Floor((Me.tgItem.Height - tgRowHeight) / tgRowHeight))
            Do While Me.m_treeManager.Treetable.Rows.Count < maxVisibleCount - 1
                '�����Ǩ����
                Me.m_treeManager.Treetable.Childs.Add()
            Loop
            'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
            '    If Me.m_entity.ItemTable.Rows.Count < maxVisibleCount - 1 Then
            '        '�����ա 1 �� ����բ����Ũ��֧���ش����
            '        Me.m_entity.ItemTable.Childs.Add()
            '    End If
            'End If
            Me.m_treeManager.Treetable.AcceptChanges()
            tgItem.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub
        Private Sub tgRefDoc_Resize(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgRefDoc.Resize
            If Me.m_entity Is Nothing Then
                Return
            End If
            RefreshBlankDocGrid()
        End Sub
        Private Sub RefreshBlankDocGrid()
            If Me.tgRefDoc.Height = 0 Then
                Return
            End If
            Dim dirtyFlag As Boolean = Me.WorkbenchWindow.ViewContent.IsDirty
            Dim index As Integer = tgRefDoc.CurrentRowIndex
            Dim maxVisibleCount As Integer
            Dim tgRowHeight As Integer = 17
            maxVisibleCount = CInt(Math.Floor((Me.tgRefDoc.Height - tgRowHeight) / tgRowHeight))
            Do While Me.m_docTreeManager.Treetable.Rows.Count < maxVisibleCount - 1
                '�����Ǩ����
                Me.m_docTreeManager.Treetable.Childs.Add()
            Loop
            'If Me.m_entity.MaxRowIndex = maxVisibleCount - 2 Then
            '    If Me.m_docTreeManager.Treetable.Rows.Count < maxVisibleCount - 1 Then
            '        '�����ա 1 �� ����բ����Ũ��֧���ش����
            '        Me.m_docTreeManager.Treetable.Childs.Add()
            '    End If
            'End If
            Me.m_docTreeManager.Treetable.AcceptChanges()
            tgRefDoc.CurrentRowIndex = Math.Max(0, index)
            Me.WorkbenchWindow.ViewContent.IsDirty = dirtyFlag
        End Sub

#End Region

    End Class
End Namespace

