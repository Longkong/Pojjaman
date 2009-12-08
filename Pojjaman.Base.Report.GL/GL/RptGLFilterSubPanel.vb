Option Strict On
Option Explicit On 
Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class RptGLFilterSubPanel
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
        Friend WithEvents lblOrderBy As System.Windows.Forms.Label
        Friend WithEvents cmbOrderBy As System.Windows.Forms.ComboBox
        Friend WithEvents btnAccountEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAccountCodeEnd As System.Windows.Forms.TextBox
        Friend WithEvents btnAccountStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtAccountCodeStart As System.Windows.Forms.TextBox
        Friend WithEvents lblAccountEnd As System.Windows.Forms.Label
        Friend WithEvents lblAccountStart As System.Windows.Forms.Label
        Friend WithEvents chkOnlyPosted As System.Windows.Forms.CheckBox
        Friend WithEvents ChkShowSummary As System.Windows.Forms.CheckBox
        Friend WithEvents chkShowCancelDoc As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtRefDocCodePrefix As System.Windows.Forms.TextBox
    Friend WithEvents txtAcctBookCodeprefix As System.Windows.Forms.TextBox
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container
            Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(RptGLFilterSubPanel))
            Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtTemp = New System.Windows.Forms.TextBox
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
      Me.Label2 = New System.Windows.Forms.Label
      Me.Label1 = New System.Windows.Forms.Label
      Me.txtRefDocCodePrefix = New System.Windows.Forms.TextBox
      Me.txtAcctBookCodeprefix = New System.Windows.Forms.TextBox
            Me.chkOnlyPosted = New System.Windows.Forms.CheckBox
            Me.lblOrderBy = New System.Windows.Forms.Label
            Me.cmbOrderBy = New System.Windows.Forms.ComboBox
            Me.btnAccountEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtAccountCodeEnd = New System.Windows.Forms.TextBox
            Me.lblAccountEnd = New System.Windows.Forms.Label
            Me.btnAccountStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton
            Me.txtAccountCodeStart = New System.Windows.Forms.TextBox
            Me.lblAccountStart = New System.Windows.Forms.Label
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox
            Me.txtDocDateStart = New System.Windows.Forms.TextBox
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker
            Me.lblDocDateStart = New System.Windows.Forms.Label
            Me.lblDocDateEnd = New System.Windows.Forms.Label
            Me.ChkShowSummary = New System.Windows.Forms.CheckBox
      Me.chkShowCancelDoc = New System.Windows.Forms.CheckBox
            Me.btnSearch = New System.Windows.Forms.Button
            Me.btnReset = New System.Windows.Forms.Button
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
            Me.chkShowCancelDoc = New System.Windows.Forms.CheckBox
            Me.grbMaster.SuspendLayout()
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbMaster
            '
            Me.grbMaster.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbMaster.Controls.Add(Me.txtTemp)
            Me.grbMaster.Controls.Add(Me.grbDetail)
            Me.grbMaster.Controls.Add(Me.btnSearch)
            Me.grbMaster.Controls.Add(Me.btnReset)
            Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.grbMaster.Location = New System.Drawing.Point(8, 8)
            Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(432, 272)
            Me.grbMaster.TabIndex = 0
            Me.grbMaster.TabStop = False
            Me.grbMaster.Text = "���Ѻ"
            '
            'txtTemp
            '
            Me.Validator.SetDataType(Me.txtTemp, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtTemp, "")
            Me.Validator.SetGotFocusBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtTemp, System.Drawing.Color.Empty)
            Me.txtTemp.Location = New System.Drawing.Point(432, 32)
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
            'grbDetail
            '
      Me.grbDetail.Controls.Add(Me.Label2)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.txtRefDocCodePrefix)
      Me.grbDetail.Controls.Add(Me.txtAcctBookCodeprefix)
            Me.grbDetail.Controls.Add(Me.chkOnlyPosted)
            Me.grbDetail.Controls.Add(Me.lblOrderBy)
            Me.grbDetail.Controls.Add(Me.cmbOrderBy)
            Me.grbDetail.Controls.Add(Me.btnAccountEndFind)
            Me.grbDetail.Controls.Add(Me.txtAccountCodeEnd)
            Me.grbDetail.Controls.Add(Me.lblAccountEnd)
            Me.grbDetail.Controls.Add(Me.btnAccountStartFind)
            Me.grbDetail.Controls.Add(Me.txtAccountCodeStart)
            Me.grbDetail.Controls.Add(Me.lblAccountStart)
            Me.grbDetail.Controls.Add(Me.txtDocDateEnd)
            Me.grbDetail.Controls.Add(Me.txtDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateStart)
            Me.grbDetail.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDetail.Controls.Add(Me.lblDocDateStart)
            Me.grbDetail.Controls.Add(Me.lblDocDateEnd)
            Me.grbDetail.Controls.Add(Me.ChkShowSummary)
            Me.grbDetail.Controls.Add(Me.chkShowCancelDoc)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(16, 16)
            Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(400, 216)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "�����ŷ����"
            '
      'Label2
      '
      Me.Label2.Location = New System.Drawing.Point(16, 112)
      Me.Label2.Name = "Label2"
      Me.Label2.Size = New System.Drawing.Size(80, 16)
      Me.Label2.TabIndex = 33
      Me.Label2.Text = "RefCodePrefix"
      '
      'Label1
      '
      Me.Label1.Location = New System.Drawing.Point(16, 88)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(72, 16)
      Me.Label1.TabIndex = 32
      Me.Label1.Text = "GLCodePrefix"
      '
      'txtRefDocCodePrefix
      '
      Me.Validator.SetDataType(Me.txtRefDocCodePrefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetGotFocusBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtRefDocCodePrefix, System.Drawing.Color.Empty)
      Me.txtRefDocCodePrefix.Location = New System.Drawing.Point(104, 112)
      Me.Validator.SetMaxValue(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetMinValue(Me.txtRefDocCodePrefix, "")
      Me.txtRefDocCodePrefix.Name = "txtRefDocCodePrefix"
      Me.Validator.SetRegularExpression(Me.txtRefDocCodePrefix, "")
      Me.Validator.SetRequired(Me.txtRefDocCodePrefix, False)
      Me.txtRefDocCodePrefix.Size = New System.Drawing.Size(120, 21)
      Me.txtRefDocCodePrefix.TabIndex = 31
      Me.txtRefDocCodePrefix.Text = ""
      '
      'txtAcctBookCodeprefix
      '
      Me.Validator.SetDataType(Me.txtAcctBookCodeprefix, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtAcctBookCodeprefix, "")
      Me.Validator.SetGotFocusBackColor(Me.txtAcctBookCodeprefix, System.Drawing.Color.Empty)
      Me.Validator.SetInvalidBackColor(Me.txtAcctBookCodeprefix, System.Drawing.Color.Empty)
      Me.txtAcctBookCodeprefix.Location = New System.Drawing.Point(104, 88)
      Me.Validator.SetMaxValue(Me.txtAcctBookCodeprefix, "")
      Me.Validator.SetMinValue(Me.txtAcctBookCodeprefix, "")
      Me.txtAcctBookCodeprefix.Name = "txtAcctBookCodeprefix"
      Me.Validator.SetRegularExpression(Me.txtAcctBookCodeprefix, "")
      Me.Validator.SetRequired(Me.txtAcctBookCodeprefix, False)
      Me.txtAcctBookCodeprefix.Size = New System.Drawing.Size(120, 21)
      Me.txtAcctBookCodeprefix.TabIndex = 30
      Me.txtAcctBookCodeprefix.Text = ""
      '
            'chkOnlyPosted
            '
            Me.chkOnlyPosted.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkOnlyPosted.Location = New System.Drawing.Point(104, 136)
            Me.chkOnlyPosted.Name = "chkOnlyPosted"
            Me.chkOnlyPosted.Size = New System.Drawing.Size(200, 24)
            Me.chkOnlyPosted.TabIndex = 29
            Me.chkOnlyPosted.Text = "੾����¡�÷�� Post ����"
            '
            'lblOrderBy
            '
            Me.lblOrderBy.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblOrderBy.ForeColor = System.Drawing.Color.Black
            Me.lblOrderBy.Location = New System.Drawing.Point(8, 64)
            Me.lblOrderBy.Name = "lblOrderBy"
            Me.lblOrderBy.Size = New System.Drawing.Size(88, 18)
            Me.lblOrderBy.TabIndex = 13
            Me.lblOrderBy.Text = "���§���"
            Me.lblOrderBy.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbOrderBy
            '
            Me.cmbOrderBy.Location = New System.Drawing.Point(104, 64)
            Me.cmbOrderBy.Name = "cmbOrderBy"
            Me.cmbOrderBy.Size = New System.Drawing.Size(120, 21)
            Me.cmbOrderBy.TabIndex = 12
            '
            'btnAccountEndFind
            '
            Me.btnAccountEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountEndFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountEndFind.Image = CType(resources.GetObject("btnAccountEndFind.Image"), System.Drawing.Image)
            Me.btnAccountEndFind.Location = New System.Drawing.Point(360, 40)
            Me.btnAccountEndFind.Name = "btnAccountEndFind"
            Me.btnAccountEndFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAccountEndFind.TabIndex = 11
            Me.btnAccountEndFind.TabStop = False
            Me.btnAccountEndFind.ThemedImage = CType(resources.GetObject("btnAccountEndFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountCodeEnd
            '
            Me.Validator.SetDataType(Me.txtAccountCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCodeEnd, "")
            Me.txtAccountCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCodeEnd, System.Drawing.Color.Empty)
            Me.txtAccountCodeEnd.Location = New System.Drawing.Point(264, 40)
            Me.Validator.SetMaxValue(Me.txtAccountCodeEnd, "")
            Me.Validator.SetMinValue(Me.txtAccountCodeEnd, "")
            Me.txtAccountCodeEnd.Name = "txtAccountCodeEnd"
            Me.Validator.SetRegularExpression(Me.txtAccountCodeEnd, "")
            Me.Validator.SetRequired(Me.txtAccountCodeEnd, False)
            Me.txtAccountCodeEnd.Size = New System.Drawing.Size(96, 21)
            Me.txtAccountCodeEnd.TabIndex = 10
            Me.txtAccountCodeEnd.Text = ""
            '
            'lblAccountEnd
            '
            Me.lblAccountEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountEnd.ForeColor = System.Drawing.Color.Black
            Me.lblAccountEnd.Location = New System.Drawing.Point(232, 40)
            Me.lblAccountEnd.Name = "lblAccountEnd"
            Me.lblAccountEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblAccountEnd.TabIndex = 9
            Me.lblAccountEnd.Text = "�֧"
            Me.lblAccountEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'btnAccountStartFind
            '
            Me.btnAccountStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnAccountStartFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnAccountStartFind.Image = CType(resources.GetObject("btnAccountStartFind.Image"), System.Drawing.Image)
            Me.btnAccountStartFind.Location = New System.Drawing.Point(200, 40)
            Me.btnAccountStartFind.Name = "btnAccountStartFind"
            Me.btnAccountStartFind.Size = New System.Drawing.Size(24, 22)
            Me.btnAccountStartFind.TabIndex = 8
            Me.btnAccountStartFind.TabStop = False
            Me.btnAccountStartFind.ThemedImage = CType(resources.GetObject("btnAccountStartFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'txtAccountCodeStart
            '
            Me.Validator.SetDataType(Me.txtAccountCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtAccountCodeStart, "")
            Me.txtAccountCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtAccountCodeStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtAccountCodeStart, System.Drawing.Color.Empty)
            Me.txtAccountCodeStart.Location = New System.Drawing.Point(104, 40)
            Me.Validator.SetMaxValue(Me.txtAccountCodeStart, "")
            Me.Validator.SetMinValue(Me.txtAccountCodeStart, "")
            Me.txtAccountCodeStart.Name = "txtAccountCodeStart"
            Me.Validator.SetRegularExpression(Me.txtAccountCodeStart, "")
            Me.Validator.SetRequired(Me.txtAccountCodeStart, False)
            Me.txtAccountCodeStart.Size = New System.Drawing.Size(96, 21)
            Me.txtAccountCodeStart.TabIndex = 7
            Me.txtAccountCodeStart.Text = ""
            '
            'lblAccountStart
            '
            Me.lblAccountStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblAccountStart.ForeColor = System.Drawing.Color.Black
            Me.lblAccountStart.Location = New System.Drawing.Point(8, 40)
            Me.lblAccountStart.Name = "lblAccountStart"
            Me.lblAccountStart.Size = New System.Drawing.Size(88, 18)
            Me.lblAccountStart.TabIndex = 6
            Me.lblAccountStart.Text = "�������ش����ѹ"
            Me.lblAccountStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtDocDateEnd
            '
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(264, 16)
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
            Me.txtDocDateStart.Location = New System.Drawing.Point(104, 16)
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
            Me.dtpDocDateStart.Location = New System.Drawing.Point(104, 16)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateStart.TabIndex = 2
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(264, 16)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 21)
            Me.dtpDocDateEnd.TabIndex = 5
            Me.dtpDocDateEnd.TabStop = False
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 16)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(88, 18)
            Me.lblDocDateStart.TabIndex = 0
            Me.lblDocDateStart.Text = "������ѹ���"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(232, 16)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(24, 18)
            Me.lblDocDateEnd.TabIndex = 3
            Me.lblDocDateEnd.Text = "�֧"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
            '
            'ChkShowSummary
            '
            Me.ChkShowSummary.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.ChkShowSummary.Location = New System.Drawing.Point(104, 160)
            Me.ChkShowSummary.Name = "ChkShowSummary"
            Me.ChkShowSummary.Size = New System.Drawing.Size(200, 24)
            Me.ChkShowSummary.TabIndex = 29
            Me.ChkShowSummary.Text = "�ʴ������������¡������ѹ"
            '
      'chkShowCancelDoc
      '
      Me.chkShowCancelDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkShowCancelDoc.Location = New System.Drawing.Point(104, 184)
      Me.chkShowCancelDoc.Name = "chkShowCancelDoc"
      Me.chkShowCancelDoc.Size = New System.Drawing.Size(200, 24)
      Me.chkShowCancelDoc.TabIndex = 29
      Me.chkShowCancelDoc.Text = "�ʴ��͡��÷��١¡��ԡ"
      '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(344, 240)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.TabIndex = 2
            Me.btnSearch.Text = "����"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(264, 240)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.TabIndex = 1
            Me.btnReset.TabStop = False
            Me.btnReset.Text = "������"
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
            'chkShowCancelDoc
            '
            Me.chkShowCancelDoc.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.chkShowCancelDoc.Location = New System.Drawing.Point(104, 136)
            Me.chkShowCancelDoc.Name = "chkShowCancelDoc"
            Me.chkShowCancelDoc.Size = New System.Drawing.Size(200, 24)
            Me.chkShowCancelDoc.TabIndex = 29
            Me.chkShowCancelDoc.Text = "�ʴ��͡��÷��١¡��ԡ"
            '
            'RptGLFilterSubPanel
            '
            Me.Controls.Add(Me.grbMaster)
            Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Name = "RptGLFilterSubPanel"
      Me.Size = New System.Drawing.Size(448, 288)
            Me.grbMaster.ResumeLayout(False)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.lblAccountStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLFilterSubPanel.lblSuppliStart}")
            Me.Validator.SetDisplayName(txtAccountCodeStart, lblAccountStart.Text)

            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            ' Global {�֧}
            Me.lblAccountEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtAccountCodeEnd, lblAccountEnd.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
            ' Button
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            ' GroupBox
            Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLFilterSubPanel.grbMaster}")
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLFilterSubPanel.grbDetail}")

            ' ���§��� �ѹ��� ��ش����ѹ �Ţ����͡���
            Me.cmbOrderBy.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOHistoryFilterSubPanel.cmbOderByglDocdate}")) '�ѹ���
            Me.cmbOrderBy.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOHistoryFilterSubPanel.cmbOderByAccountBookName}")) '��ش����ѹ
            Me.cmbOrderBy.Items.Add(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptPOHistoryFilterSubPanel.cmbOrderByglCode}")) '�Ţ����͡���
            Me.cmbOrderBy.SelectedIndex = 0

            Me.lblOrderBy.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLFilterSubPanel.lblOrderBy}")

            'Checkbox
            Me.chkOnlyPosted.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLFilterSubPanel.chkOnlyPosted}")
            Me.ChkShowSummary.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLFilterSubPanel.ChkShowSummary}")
            Me.chkShowCancelDoc.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptGLFilterSubPanel.chkShowCancelDoc}")
        End Sub
#End Region

#Region "Member"
        Private m_DocDateEnd As Date
        Private m_DocDateStart As Date
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            EventWiring()
            'Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"

        Public Property DocDateEnd() As Date            Get                Return m_DocDateEnd            End Get            Set(ByVal Value As Date)                m_DocDateEnd = Value            End Set        End Property        Public Property DocDateStart() As Date            Get                Return m_DocDateStart            End Get            Set(ByVal Value As Date)                m_DocDateStart = Value            End Set        End Property
#End Region

#Region "Methods"
        'Private Sub RegisterDropdown()
        '    ' ���§��� �ѹ��� ��ش����ѹ �Ţ����͡���
        '    GLFilterOrderBy.ListCodeDescriptionInComboBox(cmbOrderBy, "rpt_glfilter")
        'End Sub
        'Private Sub Initialize()
        '    RegisterDropdown()
        '    ClearCriterias()
        'End Sub

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

            Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
            Me.DocDateStart = dtStart
            Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
            Me.dtpDocDateStart.Value = Me.DocDateStart

            Me.DocDateEnd = Date.Now
            Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
            Me.dtpDocDateEnd.Value = Me.DocDateEnd

            chkOnlyPosted.Checked = False
            ChkShowSummary.Checked = False
            chkShowCancelDoc.Checked = False

            If Me.cmbOrderBy.Items.Count > 0 Then
                Me.cmbOrderBy.SelectedIndex = 0
            End If
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
      Dim arr(9) As Filter
            arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
            arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
            arr(2) = New Filter("AcctBookCodeStart", IIf(txtAccountCodeStart.TextLength > 0, txtAccountCodeStart.Text, DBNull.Value))
            arr(3) = New Filter("AcctBookCodeEnd", IIf(txtAccountCodeEnd.TextLength > 0, txtAccountCodeEnd.Text, DBNull.Value))
            arr(4) = New Filter("OderBy", Me.cmbOrderBy.SelectedIndex)
            arr(5) = New Filter("OnlyPosted", Me.chkOnlyPosted.Checked)
            arr(6) = New Filter("ShowSummary", Me.ChkShowSummary.Checked)
            arr(7) = New Filter("ShowCanceled", Me.chkShowCancelDoc.Checked)
      arr(8) = New Filter("AcctBookCodeprefix", IIf(txtAcctBookCodeprefix.TextLength > 0, txtAcctBookCodeprefix.Text, DBNull.Value))
      arr(9) = New Filter("RefDocCodePrefix", IIf(txtRefDocCodePrefix.TextLength > 0, txtRefDocCodePrefix.Text, DBNull.Value))
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property

        Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
            ClearCriterias()
            'Me.btnSearch.PerformClick()
        End Sub
#End Region

#Region " IReportFilterSubPanel "
        Public Function GetFixValueCollection() As BusinessLogic.DocPrintingItemCollection Implements IReportFilterSubPanel.GetFixValueCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            'Month
            dpi = New DocPrintingItem
            dpi.Mapping = "Month"
            dpi.Value = "" ' Me.cmbMonth.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Year
            dpi = New DocPrintingItem
            dpi.Mapping = "Year"
            dpi.Value = "" 'Me.cmbYear.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'today
            dpi = New DocPrintingItem
            dpi.Mapping = "today"
            dpi.Value = MinDateToNull(Now, "") + " " + Now.ToShortTimeString
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'SortBy
            dpi = New DocPrintingItem
            dpi.Mapping = "SortBy"
            dpi.Value = Me.cmbOrderBy.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate start
            dpi = New DocPrintingItem
            dpi.Mapping = "DocdateStart"
            dpi.Value = Me.txtDocDateStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'Docdate end
            dpi = New DocPrintingItem
            dpi.Mapping = "DocDateEnd"
            dpi.Value = Me.txtDocDateEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'account start
            dpi = New DocPrintingItem
            dpi.Mapping = "accountstart"
            dpi.Value = Me.txtAccountCodeStart.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

            'account end
            dpi = New DocPrintingItem
            dpi.Mapping = "accountend"
            dpi.Value = Me.txtAccountCodeEnd.Text
            dpi.DataType = "System.String"
            dpiColl.Add(dpi)

      'AcctBookCodeprefix
      dpi = New DocPrintingItem
      dpi.Mapping = "AcctBookCodeprefix"
      dpi.Value = Me.txtAcctBookCodeprefix.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'RefDocCodePrefix 
      dpi = New DocPrintingItem
      dpi.Mapping = "RefDocCodePrefix"
      dpi.Value = Me.txtRefDocCodePrefix.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

            Return dpiColl
        End Function
#End Region

#Region " ChangeProperty "
        Private Sub EventWiring()
            AddHandler btnAccountStartFind.Click, AddressOf Me.btnAccountFind_Click
            AddHandler btnAccountEndFind.Click, AddressOf Me.btnAccountFind_Click

            'AddHandler txtSuppliCodeStart.Validated, AddressOf Me.ChangeProperty
            'AddHandler txtSuppliCodeEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty

            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
        End Sub

        Private m_dateSetting As Boolean
        Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

            Select Case CType(sender, Control).Name.ToLower
                'Case "txtsupplicodestart"
                '    Supplier.GetSupplier(txtSuppliCodeStart, txtTemp, Me.SupplierStart)

                'Case "txtsupplicodeend"
                '    Supplier.GetSupplier(txtSuppliCodeEnd, txtTemp, Me.SupplierEnd)

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
                If data.GetDataPresent((New AccountBook).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtaccountcodestart", "txtaccountcodeend"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New AccountBook).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New AccountBook).FullClassName))
                Dim entity As New AccountBook(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtaccountcodestart"
                            Me.SetAcctBookStartDialog(entity)

                        Case "txtaccountcodeend"
                            Me.SetAcctBookEndDialog(entity)

                    End Select
                End If
            End If
        End Sub
#End Region

#Region " Event Handlers "
        Private Sub btnAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
            Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            Select Case CType(sender, Control).Name.ToLower
                Case "btnaccountstartfind"
                    myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookStartDialog)

                Case "btnaccountendfind"
                    myEntityPanelService.OpenListDialog(New AccountBook, AddressOf SetAcctBookEndDialog)

            End Select
        End Sub
        Private Sub SetAcctBookStartDialog(ByVal e As ISimpleEntity)
            Me.txtAccountCodeStart.Text = e.Code
        End Sub
        Private Sub SetAcctBookEndDialog(ByVal e As ISimpleEntity)
            Me.txtAccountCodeEnd.Text = e.Code
        End Sub
#End Region

    End Class

    ' ���§��� 
    Public Class GLFilterOrderBy
        Inherits CodeDescription

#Region "Construtors"
        Public Sub New(ByVal value As Integer)
            MyBase.New(value)
        End Sub
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property CodeName() As String
            Get
                Return "rpt_glfilter"
            End Get
        End Property
#End Region

    End Class
End Namespace

