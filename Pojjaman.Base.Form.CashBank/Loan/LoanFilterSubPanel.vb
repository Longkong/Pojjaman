Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
    Public Class LoanFilterSubPanel
        Inherits AbstractFilterSubPanel

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
        Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents btnSearch As System.Windows.Forms.Button
        Friend WithEvents btnReset As System.Windows.Forms.Button
        Friend WithEvents grbGeneral As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
        Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
        Friend WithEvents grbDocDate As Longkong.Pojjaman.Gui.Components.FixedGroupBox
        Friend WithEvents txtDocDateStart As System.Windows.Forms.TextBox
        Friend WithEvents txtDocDateEnd As System.Windows.Forms.TextBox
        Friend WithEvents lblDocDateStart As System.Windows.Forms.Label
        Friend WithEvents lblDocDateEnd As System.Windows.Forms.Label
        Friend WithEvents dtpDocDateStart As System.Windows.Forms.DateTimePicker
        Friend WithEvents txtName As System.Windows.Forms.TextBox
        Friend WithEvents Label1 As System.Windows.Forms.Label
        Friend WithEvents cmbType As System.Windows.Forms.ComboBox
        Friend WithEvents btnBankAccountFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents txtBankAccountName As System.Windows.Forms.TextBox
        Friend WithEvents txtBankAccountCode As System.Windows.Forms.TextBox
        Friend WithEvents lblBankAccount As System.Windows.Forms.Label
        Friend WithEvents btnCCFind As Longkong.Pojjaman.Gui.Components.ImageButton
        Friend WithEvents lblCostCenter As System.Windows.Forms.Label
        Friend WithEvents txtCCName As System.Windows.Forms.TextBox
        Friend WithEvents txtCCCode As System.Windows.Forms.TextBox
        Friend WithEvents dtpDocDateEnd As System.Windows.Forms.DateTimePicker
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(LoanFilterSubPanel))
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.grbDocDate = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.txtDocDateStart = New System.Windows.Forms.TextBox()
            Me.txtDocDateEnd = New System.Windows.Forms.TextBox()
            Me.lblDocDateStart = New System.Windows.Forms.Label()
            Me.lblDocDateEnd = New System.Windows.Forms.Label()
            Me.dtpDocDateStart = New System.Windows.Forms.DateTimePicker()
            Me.dtpDocDateEnd = New System.Windows.Forms.DateTimePicker()
            Me.grbGeneral = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
            Me.btnCCFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.lblCostCenter = New System.Windows.Forms.Label()
            Me.txtCCName = New System.Windows.Forms.TextBox()
            Me.txtCCCode = New System.Windows.Forms.TextBox()
            Me.btnBankAccountFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
            Me.cmbType = New System.Windows.Forms.ComboBox()
            Me.txtBankAccountName = New System.Windows.Forms.TextBox()
            Me.txtBankAccountCode = New System.Windows.Forms.TextBox()
            Me.txtName = New System.Windows.Forms.TextBox()
            Me.Label1 = New System.Windows.Forms.Label()
            Me.lblBankAccount = New System.Windows.Forms.Label()
            Me.txtCode = New System.Windows.Forms.TextBox()
            Me.lblCode = New System.Windows.Forms.Label()
            Me.btnSearch = New System.Windows.Forms.Button()
            Me.btnReset = New System.Windows.Forms.Button()
            Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator()
            Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider()
            Me.grbDetail.SuspendLayout()
            Me.grbDocDate.SuspendLayout()
            Me.grbGeneral.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.grbDocDate)
            Me.grbDetail.Controls.Add(Me.grbGeneral)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.Controls.Add(Me.btnReset)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(624, 177)
            Me.grbDetail.TabIndex = 9
            Me.grbDetail.TabStop = False
            Me.grbDetail.Text = "�Ѵ�Ө���"
            '
            'grbDocDate
            '
            Me.grbDocDate.Controls.Add(Me.txtDocDateStart)
            Me.grbDocDate.Controls.Add(Me.txtDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.lblDocDateStart)
            Me.grbDocDate.Controls.Add(Me.lblDocDateEnd)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateStart)
            Me.grbDocDate.Controls.Add(Me.dtpDocDateEnd)
            Me.grbDocDate.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDocDate.Location = New System.Drawing.Point(416, 16)
            Me.grbDocDate.Name = "grbDocDate"
            Me.grbDocDate.Size = New System.Drawing.Size(200, 72)
            Me.grbDocDate.TabIndex = 182
            Me.grbDocDate.TabStop = False
            Me.grbDocDate.Text = "�ѹ����͡���"
            '
            'txtDocDateStart
            '
            Me.txtDocDateStart.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateStart, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateStart, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateStart, System.Drawing.Color.Empty)
            Me.txtDocDateStart.Location = New System.Drawing.Point(72, 14)
            Me.Validator.SetMinValue(Me.txtDocDateStart, "")
            Me.txtDocDateStart.Name = "txtDocDateStart"
            Me.Validator.SetRegularExpression(Me.txtDocDateStart, "")
            Me.Validator.SetRequired(Me.txtDocDateStart, False)
            Me.txtDocDateStart.Size = New System.Drawing.Size(96, 20)
            Me.txtDocDateStart.TabIndex = 6
            '
            'txtDocDateEnd
            '
            Me.txtDocDateEnd.BackColor = System.Drawing.SystemColors.Window
            Me.Validator.SetDataType(Me.txtDocDateEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.DateTimeType)
            Me.Validator.SetDisplayName(Me.txtDocDateEnd, "")
            Me.Validator.SetGotFocusBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.ErrorProvider1.SetIconPadding(Me.txtDocDateEnd, -15)
            Me.Validator.SetInvalidBackColor(Me.txtDocDateEnd, System.Drawing.Color.Empty)
            Me.txtDocDateEnd.Location = New System.Drawing.Point(72, 38)
            Me.Validator.SetMinValue(Me.txtDocDateEnd, "")
            Me.txtDocDateEnd.Name = "txtDocDateEnd"
            Me.Validator.SetRegularExpression(Me.txtDocDateEnd, "")
            Me.Validator.SetRequired(Me.txtDocDateEnd, False)
            Me.txtDocDateEnd.Size = New System.Drawing.Size(96, 20)
            Me.txtDocDateEnd.TabIndex = 7
            '
            'lblDocDateStart
            '
            Me.lblDocDateStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateStart.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateStart.Location = New System.Drawing.Point(8, 15)
            Me.lblDocDateStart.Name = "lblDocDateStart"
            Me.lblDocDateStart.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateStart.TabIndex = 8
            Me.lblDocDateStart.Text = "�����"
            Me.lblDocDateStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblDocDateEnd
            '
            Me.lblDocDateEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblDocDateEnd.ForeColor = System.Drawing.Color.Black
            Me.lblDocDateEnd.Location = New System.Drawing.Point(8, 39)
            Me.lblDocDateEnd.Name = "lblDocDateEnd"
            Me.lblDocDateEnd.Size = New System.Drawing.Size(56, 18)
            Me.lblDocDateEnd.TabIndex = 9
            Me.lblDocDateEnd.Text = "�֧"
            Me.lblDocDateEnd.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'dtpDocDateStart
            '
            Me.dtpDocDateStart.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateStart.Location = New System.Drawing.Point(72, 14)
            Me.dtpDocDateStart.Name = "dtpDocDateStart"
            Me.dtpDocDateStart.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateStart.TabIndex = 10
            Me.dtpDocDateStart.TabStop = False
            '
            'dtpDocDateEnd
            '
            Me.dtpDocDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
            Me.dtpDocDateEnd.Location = New System.Drawing.Point(72, 38)
            Me.dtpDocDateEnd.Name = "dtpDocDateEnd"
            Me.dtpDocDateEnd.Size = New System.Drawing.Size(120, 20)
            Me.dtpDocDateEnd.TabIndex = 11
            Me.dtpDocDateEnd.TabStop = False
            '
            'grbGeneral
            '
            Me.grbGeneral.Controls.Add(Me.btnCCFind)
            Me.grbGeneral.Controls.Add(Me.lblCostCenter)
            Me.grbGeneral.Controls.Add(Me.txtCCName)
            Me.grbGeneral.Controls.Add(Me.txtCCCode)
            Me.grbGeneral.Controls.Add(Me.btnBankAccountFind)
            Me.grbGeneral.Controls.Add(Me.cmbType)
            Me.grbGeneral.Controls.Add(Me.txtBankAccountName)
            Me.grbGeneral.Controls.Add(Me.txtBankAccountCode)
            Me.grbGeneral.Controls.Add(Me.txtName)
            Me.grbGeneral.Controls.Add(Me.Label1)
            Me.grbGeneral.Controls.Add(Me.lblBankAccount)
            Me.grbGeneral.Controls.Add(Me.txtCode)
            Me.grbGeneral.Controls.Add(Me.lblCode)
            Me.grbGeneral.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbGeneral.Location = New System.Drawing.Point(8, 16)
            Me.grbGeneral.Name = "grbGeneral"
            Me.grbGeneral.Size = New System.Drawing.Size(400, 152)
            Me.grbGeneral.TabIndex = 181
            Me.grbGeneral.TabStop = False
            Me.grbGeneral.Text = "��������´�����"
            '
            'btnCCFind
            '
            Me.btnCCFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnCCFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnCCFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnCCFind.Location = New System.Drawing.Point(367, 117)
            Me.btnCCFind.Name = "btnCCFind"
            Me.btnCCFind.Size = New System.Drawing.Size(24, 23)
            Me.btnCCFind.TabIndex = 183
            Me.btnCCFind.TabStop = False
            Me.btnCCFind.ThemedImage = CType(resources.GetObject("btnCCFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'lblCostCenter
            '
            Me.lblCostCenter.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCostCenter.ForeColor = System.Drawing.Color.Black
            Me.lblCostCenter.Location = New System.Drawing.Point(16, 119)
            Me.lblCostCenter.Name = "lblCostCenter"
            Me.lblCostCenter.Size = New System.Drawing.Size(80, 18)
            Me.lblCostCenter.TabIndex = 186
            Me.lblCostCenter.Text = "CostCenter:"
            Me.lblCostCenter.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCCName
            '
            Me.Validator.SetDataType(Me.txtCCName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCName, "")
            Me.txtCCName.Enabled = False
            Me.txtCCName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCCName, System.Drawing.Color.Empty)
            Me.txtCCName.Location = New System.Drawing.Point(199, 119)
            Me.Validator.SetMinValue(Me.txtCCName, "")
            Me.txtCCName.Name = "txtCCName"
            Me.txtCCName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtCCName, "")
            Me.Validator.SetRequired(Me.txtCCName, False)
            Me.txtCCName.Size = New System.Drawing.Size(162, 21)
            Me.txtCCName.TabIndex = 185
            Me.txtCCName.TabStop = False
            '
            'txtCCCode
            '
            Me.Validator.SetDataType(Me.txtCCCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCCCode, "")
            Me.txtCCCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCCCode, System.Drawing.Color.Empty)
            Me.txtCCCode.Location = New System.Drawing.Point(104, 119)
            Me.Validator.SetMinValue(Me.txtCCCode, "")
            Me.txtCCCode.Name = "txtCCCode"
            Me.Validator.SetRegularExpression(Me.txtCCCode, "")
            Me.Validator.SetRequired(Me.txtCCCode, False)
            Me.txtCCCode.Size = New System.Drawing.Size(92, 21)
            Me.txtCCCode.TabIndex = 184
            '
            'btnBankAccountFind
            '
            Me.btnBankAccountFind.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnBankAccountFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.btnBankAccountFind.ForeColor = System.Drawing.SystemColors.Control
            Me.btnBankAccountFind.Location = New System.Drawing.Point(367, 93)
            Me.btnBankAccountFind.Name = "btnBankAccountFind"
            Me.btnBankAccountFind.Size = New System.Drawing.Size(24, 23)
            Me.btnBankAccountFind.TabIndex = 20
            Me.btnBankAccountFind.TabStop = False
            Me.btnBankAccountFind.ThemedImage = CType(resources.GetObject("btnBankAccountFind.ThemedImage"), System.Drawing.Bitmap)
            '
            'cmbType
            '
            Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbType.Location = New System.Drawing.Point(104, 68)
            Me.cmbType.Name = "cmbType"
            Me.cmbType.Size = New System.Drawing.Size(128, 21)
            Me.cmbType.TabIndex = 16
            '
            'txtBankAccountName
            '
            Me.Validator.SetDataType(Me.txtBankAccountName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankAccountName, "")
            Me.txtBankAccountName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBankAccountName, System.Drawing.Color.Empty)
            Me.txtBankAccountName.Location = New System.Drawing.Point(199, 95)
            Me.txtBankAccountName.MaxLength = 255
            Me.Validator.SetMinValue(Me.txtBankAccountName, "")
            Me.txtBankAccountName.Name = "txtBankAccountName"
            Me.txtBankAccountName.ReadOnly = True
            Me.Validator.SetRegularExpression(Me.txtBankAccountName, "")
            Me.Validator.SetRequired(Me.txtBankAccountName, False)
            Me.txtBankAccountName.Size = New System.Drawing.Size(162, 21)
            Me.txtBankAccountName.TabIndex = 19
            Me.txtBankAccountName.TabStop = False
            '
            'txtBankAccountCode
            '
            Me.Validator.SetDataType(Me.txtBankAccountCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtBankAccountCode, "")
            Me.txtBankAccountCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtBankAccountCode, System.Drawing.Color.Empty)
            Me.txtBankAccountCode.Location = New System.Drawing.Point(104, 95)
            Me.txtBankAccountCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtBankAccountCode, "")
            Me.txtBankAccountCode.Name = "txtBankAccountCode"
            Me.Validator.SetRegularExpression(Me.txtBankAccountCode, "")
            Me.Validator.SetRequired(Me.txtBankAccountCode, True)
            Me.txtBankAccountCode.Size = New System.Drawing.Size(92, 21)
            Me.txtBankAccountCode.TabIndex = 18
            '
            'txtName
            '
            Me.Validator.SetDataType(Me.txtName, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtName, "")
            Me.txtName.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtName, System.Drawing.Color.Empty)
            Me.txtName.Location = New System.Drawing.Point(104, 41)
            Me.txtName.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtName, "")
            Me.txtName.Name = "txtName"
            Me.Validator.SetRegularExpression(Me.txtName, "")
            Me.Validator.SetRequired(Me.txtName, False)
            Me.txtName.Size = New System.Drawing.Size(290, 21)
            Me.txtName.TabIndex = 14
            '
            'Label1
            '
            Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Label1.ForeColor = System.Drawing.Color.Black
            Me.Label1.Location = New System.Drawing.Point(16, 41)
            Me.Label1.Name = "Label1"
            Me.Label1.Size = New System.Drawing.Size(80, 18)
            Me.Label1.TabIndex = 15
            Me.Label1.Text = "����:"
            Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'lblBankAccount
            '
            Me.lblBankAccount.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblBankAccount.ForeColor = System.Drawing.Color.Black
            Me.lblBankAccount.Location = New System.Drawing.Point(16, 95)
            Me.lblBankAccount.Name = "lblBankAccount"
            Me.lblBankAccount.Size = New System.Drawing.Size(80, 18)
            Me.lblBankAccount.TabIndex = 17
            Me.lblBankAccount.Text = "��ش�Թ�ҡ:"
            Me.lblBankAccount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'txtCode
            '
            Me.Validator.SetDataType(Me.txtCode, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
            Me.Validator.SetDisplayName(Me.txtCode, "")
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.Validator.SetGotFocusBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.Validator.SetInvalidBackColor(Me.txtCode, System.Drawing.Color.Empty)
            Me.txtCode.Location = New System.Drawing.Point(104, 16)
            Me.txtCode.MaxLength = 20
            Me.Validator.SetMinValue(Me.txtCode, "")
            Me.txtCode.Name = "txtCode"
            Me.Validator.SetRegularExpression(Me.txtCode, "")
            Me.Validator.SetRequired(Me.txtCode, False)
            Me.txtCode.Size = New System.Drawing.Size(290, 21)
            Me.txtCode.TabIndex = 7
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(80, 18)
            Me.lblCode.TabIndex = 13
            Me.lblCode.Text = "�Ţ���:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(528, 145)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(75, 23)
            Me.btnSearch.TabIndex = 7
            Me.btnSearch.Text = "����"
            '
            'btnReset
            '
            Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnReset.Location = New System.Drawing.Point(448, 145)
            Me.btnReset.Name = "btnReset"
            Me.btnReset.Size = New System.Drawing.Size(75, 23)
            Me.btnReset.TabIndex = 7
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
            'LoanFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "LoanFilterSubPanel"
            Me.Size = New System.Drawing.Size(640, 193)
            Me.grbDetail.ResumeLayout(False)
            Me.grbDocDate.ResumeLayout(False)
            Me.grbDocDate.PerformLayout()
            Me.grbGeneral.ResumeLayout(False)
            Me.grbGeneral.PerformLayout()
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region " SetLabelText "
        Public Sub SetLabelText()
            'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanFilterSubPanel.grbDetail}")
            Me.grbGeneral.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanFilterSubPanel.grbGeneral}")
            Me.grbDocDate.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanFilterSubPanel.grbDocDate}")

            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanFilterSubPanel.lblCode}")


            Me.lblDocDateStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanFilterSubPanel.lblDocDateStart}")
            Me.Validator.SetDisplayName(txtDocDateStart, lblDocDateStart.Text)

            Me.lblDocDateEnd.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.LoanFilterSubPanel.lblDocDateEnd}")
            Me.Validator.SetDisplayName(txtDocDateEnd, lblDocDateEnd.Text)
        End Sub
#End Region

#Region "Member"
        Private m_docdatestart As Date
        Private m_docdateend As Date
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
            InitializeComponent()
            Initialize()

            SetLabelText()
            LoopControl(Me)
        End Sub
#End Region

#Region "Properties"
        Private Property DocdateStart() As Date
            Get
                Return m_docdatestart
            End Get
            Set(ByVal Value As Date)
                m_docdatestart = Value
            End Set
        End Property
        Private Property DocdateEnd() As Date
            Get
                Return m_docdateend
            End Get
            Set(ByVal Value As Date)
                m_docdateend = Value
            End Set
        End Property
#End Region

#Region "Methods"
        Private Sub Initialize()
            AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
            AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
            AddHandler txtBankAccountCode.Validated, AddressOf Me.ChangeProperty
            AddHandler txtCCCode.Validated, AddressOf Me.ChangeProperty
            ClearCriterias()
            CodeDescription.ListCodeDescriptionInComboBox(cmbType, "LoanType", True)
        End Sub
        Private m_dateSetting As Boolean
        Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
            Dim dirtyFlag As Boolean = False
            Select Case CType(sender, Control).Name.ToLower
                Case "txtcccode"
                    dirtyFlag = CostCenter.GetCostCenter(txtCCCode, txtCCName, Me.m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
                Case "txtbankaccountcode"
                    dirtyFlag = BankAccount.GetBankAccountBankBranch(txtBankAccountCode, txtBankAccountName, New TextBox, Me.m_bankaccount)

                Case "dtpdocdatestart"
                    If Not Me.DocdateStart.Equals(dtpDocDateStart.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocdateStart = dtpDocDateStart.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdatestart"
                    m_dateSetting = True
                    If Not Me.txtDocDateStart.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateStart) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
                        If Not Me.DocdateStart.Equals(theDate) Then
                            dtpDocDateStart.Value = theDate
                            Me.DocdateStart = dtpDocDateStart.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateStart.Value = Date.Now
                        Me.DocdateStart = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case "dtpdocdateend"
                    If Not Me.DocdateEnd.Equals(dtpDocDateEnd.Value) Then
                        If Not m_dateSetting Then
                            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, Me.StringParserService.Parse("${res:Global.BlankDateText}"))
                            Me.DocdateEnd = dtpDocDateEnd.Value
                        End If
                        dirtyFlag = True
                    End If
                Case "txtdocdateend"
                    m_dateSetting = True
                    If Not Me.txtDocDateEnd.Text.Length = 0 AndAlso Me.Validator.GetErrorMessage(Me.txtDocDateEnd) = "" Then
                        Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
                        If Not Me.DocdateEnd.Equals(theDate) Then
                            dtpDocDateEnd.Value = theDate
                            Me.DocdateEnd = dtpDocDateEnd.Value
                            dirtyFlag = True
                        End If
                    Else
                        Me.dtpDocDateEnd.Value = Date.Now
                        Me.DocdateEnd = Date.MinValue
                        dirtyFlag = True
                    End If
                    m_dateSetting = False
                Case Else
            End Select
        End Sub
        Private Sub ClearCriterias()
            For Each ctrl As Control In grbGeneral.Controls
                If TypeOf ctrl Is TextBox Then
                    ctrl.Text = ""
                End If
            Next

            Me.m_cc = New CostCenter
            Me.m_bankaccount = New BankAccount

            Me.dtpDocDateStart.Value = Now.Date
            Me.dtpDocDateEnd.Value = Now.Date

            Me.txtDocDateStart.Text = ""
            Me.txtDocDateEnd.Text = ""

            Me.DocdateStart = Date.MinValue
            Me.DocdateEnd = Date.MinValue

            If cmbType.Items.Count > 0 Then
                cmbType.SelectedIndex = 0
            End If

            EntityRefresh()
        End Sub
        Public Overrides Function GetFilterString() As String

        End Function
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(6) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.TextLength = 0, DBNull.Value, Me.txtCode.Text))
            arr(1) = New Filter("name", IIf(Me.txtName.TextLength = 0, DBNull.Value, Me.txtName.Text))
            arr(2) = New Filter("cc_id", Me.ValidIdOrDBNull(Me.m_cc))
            arr(3) = New Filter("docdatestart", Me.ValidDateOrDBNull(Me.DocdateStart))
            arr(4) = New Filter("docdateend", Me.ValidDateOrDBNull(Me.DocdateEnd))
            arr(5) = New Filter("bankacct_id", Me.ValidIdOrDBNull(Me.m_bankaccount))
            Dim typeId As Integer = -1
            If Not Me.cmbType.SelectedItem Is Nothing AndAlso TypeOf Me.cmbType.SelectedItem Is IdValuePair Then
                typeId = CType(cmbType.SelectedItem, IdValuePair).Id
            End If
            arr(6) = New Filter("loan_type", typeId)
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

#Region "Event of Button Handlers"
        ' Bank Account
        Private Sub btnBankAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAccountFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
             CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountDialog)
        End Sub
        Private m_bankaccount As BankAccount
        Private Sub SetBankAccountDialog(ByVal e As ISimpleEntity)
            Me.txtBankAccountCode.Text = e.Code
            BankAccount.GetBankAccountBankBranch(txtBankAccountCode, txtBankAccountName, New TextBox, m_bankaccount)
        End Sub

        'CostCenter
        Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCCFind.Click
            Dim myEntityPanelService As IEntityPanelService = _
            CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
            myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCostcenterDialog)
        End Sub
        Private m_cc As CostCenter
        Private Sub SetCostcenterDialog(ByVal e As ISimpleEntity)
            CostCenter.GetCostCenter(txtCCCode, txtCCName, m_cc, CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
        End Sub
#End Region

#Region "IClipboardHandler Overrides"
        Public Overrides ReadOnly Property EnablePaste() As Boolean
            Get
                Dim data As IDataObject = Clipboard.GetDataObject
                ' PettyCash
                If data.GetDataPresent((New PettyCash).FullClassName) Then
                    If Not Me.ActiveControl Is Nothing Then
                        Select Case Me.ActiveControl.Name.ToLower
                            Case "txtpettycashcode", "txtpettycashname"
                                Return True
                        End Select
                    End If
                End If
            End Get
        End Property
        Public Overrides Sub Paste(ByVal sender As Object, ByVal e As System.EventArgs)
            Dim data As IDataObject = Clipboard.GetDataObject
            If data.GetDataPresent((New PettyCash).FullClassName) Then
                Dim id As Integer = CInt(data.GetData((New PettyCash).FullClassName))
                Dim entity As New PettyCash(id)
                If Not Me.ActiveControl Is Nothing Then
                    Select Case Me.ActiveControl.Name.ToLower
                        Case "txtpettycashcode", "txtpettycashname"
                    End Select
                End If
            End If
        End Sub
#End Region

        Public Overrides Property Entities() As System.Collections.ArrayList
            Get
                Return MyBase.Entities
            End Get
            Set(ByVal Value As System.Collections.ArrayList)
                MyBase.Entities = Value
                EntityRefresh()
            End Set
        End Property
        Private Sub EntityRefresh()
            If Entities Is Nothing Then
                Return
            End If

            For Each entity As ISimpleEntity In Entities
                'If TypeOf entity Is PettyCashClaim Then
                'Dim obj As PettyCashClaim = CType(entity, PettyCashClaim)
                '' PettyCash
                'If obj.PettyCash.Originated Then
                'Me.SetPettyCash(obj.PettyCash)
                'Me.txtPettyCashCode.Enabled = False
                'Me.txtPettyCashName.Enabled = False
                'Me.btnPettyCashFind.Enabled = False
                'End If
                'End If
                'If TypeOf entity Is PettyCash Then
                'Me.SetPettyCash(CType(entity, PettyCash))
                'Me.txtPettyCashCode.Enabled = False
                'Me.txtPettyCashName.Enabled = False
                'Me.btnPettyCashFind.Enabled = False
                'End If
            Next
        End Sub

    End Class
End Namespace

