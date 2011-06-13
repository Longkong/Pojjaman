Imports Longkong.Pojjaman.BusinessLogic
Imports longkong.Pojjaman.Services
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.Gui.Panels
  Public Class RptToolStatusFilterSubPanel
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
    Friend WithEvents Validator As Longkong.Pojjaman.Gui.Components.PJMTextboxValidator
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents grbDetail As Longkong.Pojjaman.Gui.Components.FixedGroupBox
    Friend WithEvents txtCCCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblCCStart As System.Windows.Forms.Label
    Friend WithEvents txtToolCodeEnd As System.Windows.Forms.TextBox
    Friend WithEvents lblToolEnd As System.Windows.Forms.Label
    Friend WithEvents txtToolCodeStart As System.Windows.Forms.TextBox
    Friend WithEvents lblToolCode As System.Windows.Forms.Label
    Friend WithEvents btnToolStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnToolEndFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents btnCCStartFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents ChkCancel As System.Windows.Forms.CheckBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnDocTypeList As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtDoctypeList As System.Windows.Forms.TextBox
    Friend WithEvents chkIncludeTGChildren As System.Windows.Forms.CheckBox
    Friend WithEvents btnGroupFind As Longkong.Pojjaman.Gui.Components.ImageButton
    Friend WithEvents txtGroupCode As System.Windows.Forms.TextBox
    Friend WithEvents lblGroup As System.Windows.Forms.Label
    Friend WithEvents txtGroupName As System.Windows.Forms.TextBox
    Friend WithEvents txttmp As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.components = New System.ComponentModel.Container()
      Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(RptToolStatusFilterSubPanel))
      Me.grbMaster = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.ChkCancel = New System.Windows.Forms.CheckBox()
      Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox()
      Me.btnCCStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnToolEndFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.btnToolStartFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtCCCodeStart = New System.Windows.Forms.TextBox()
      Me.lblCCStart = New System.Windows.Forms.Label()
      Me.txtToolCodeEnd = New System.Windows.Forms.TextBox()
      Me.lblToolEnd = New System.Windows.Forms.Label()
      Me.txtToolCodeStart = New System.Windows.Forms.TextBox()
      Me.lblToolCode = New System.Windows.Forms.Label()
      Me.btnSearch = New System.Windows.Forms.Button()
      Me.btnReset = New System.Windows.Forms.Button()
      Me.Validator = New Longkong.Pojjaman.Gui.Components.PJMTextboxValidator(Me.components)
      Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
      Me.txttmp = New System.Windows.Forms.TextBox()
      Me.btnDocTypeList = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtDoctypeList = New System.Windows.Forms.TextBox()
      Me.Label1 = New System.Windows.Forms.Label()
      Me.btnGroupFind = New Longkong.Pojjaman.Gui.Components.ImageButton()
      Me.txtGroupCode = New System.Windows.Forms.TextBox()
      Me.lblGroup = New System.Windows.Forms.Label()
      Me.txtGroupName = New System.Windows.Forms.TextBox()
      Me.chkIncludeTGChildren = New System.Windows.Forms.CheckBox()
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
      Me.grbMaster.Controls.Add(Me.ChkCancel)
      Me.grbMaster.Controls.Add(Me.grbDetail)
      Me.grbMaster.Controls.Add(Me.btnSearch)
      Me.grbMaster.Controls.Add(Me.btnReset)
      Me.grbMaster.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbMaster.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.grbMaster.Location = New System.Drawing.Point(12, 8)
      Me.grbMaster.Name = "grbMaster"
      Me.grbMaster.Size = New System.Drawing.Size(451, 210)
      Me.grbMaster.TabIndex = 0
      Me.grbMaster.TabStop = False
      Me.grbMaster.Text = "����"
      '
      'ChkCancel
      '
      Me.ChkCancel.Location = New System.Drawing.Point(15, 182)
      Me.ChkCancel.Name = "ChkCancel"
      Me.ChkCancel.Size = New System.Drawing.Size(240, 24)
      Me.ChkCancel.TabIndex = 4
      Me.ChkCancel.Text = "�ʴ��Թ��Ѿ��¡��ԡʶҹ� ��� Write off"
      '
      'grbDetail
      '
      Me.grbDetail.Controls.Add(Me.chkIncludeTGChildren)
      Me.grbDetail.Controls.Add(Me.btnGroupFind)
      Me.grbDetail.Controls.Add(Me.txtGroupCode)
      Me.grbDetail.Controls.Add(Me.lblGroup)
      Me.grbDetail.Controls.Add(Me.txtGroupName)
      Me.grbDetail.Controls.Add(Me.Label1)
      Me.grbDetail.Controls.Add(Me.btnDocTypeList)
      Me.grbDetail.Controls.Add(Me.txtDoctypeList)
      Me.grbDetail.Controls.Add(Me.btnCCStartFind)
      Me.grbDetail.Controls.Add(Me.btnToolEndFind)
      Me.grbDetail.Controls.Add(Me.btnToolStartFind)
      Me.grbDetail.Controls.Add(Me.txtCCCodeStart)
      Me.grbDetail.Controls.Add(Me.lblCCStart)
      Me.grbDetail.Controls.Add(Me.txtToolCodeEnd)
      Me.grbDetail.Controls.Add(Me.lblToolEnd)
      Me.grbDetail.Controls.Add(Me.txtToolCodeStart)
      Me.grbDetail.Controls.Add(Me.lblToolCode)
      Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.grbDetail.Location = New System.Drawing.Point(6, 16)
      Me.grbDetail.Name = "grbDetail"
      Me.grbDetail.Size = New System.Drawing.Size(435, 160)
      Me.grbDetail.TabIndex = 0
      Me.grbDetail.TabStop = False
      Me.grbDetail.Text = "�����ŷ����"
      '
      'btnCCStartFind
      '
      Me.btnCCStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnCCStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnCCStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnCCStartFind.Location = New System.Drawing.Point(209, 40)
      Me.btnCCStartFind.Name = "btnCCStartFind"
      Me.btnCCStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnCCStartFind.TabIndex = 31
      Me.btnCCStartFind.TabStop = False
      Me.btnCCStartFind.ThemedImage = CType(resources.GetObject("btnCCStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnToolEndFind
      '
      Me.btnToolEndFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolEndFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolEndFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolEndFind.Location = New System.Drawing.Point(381, 17)
      Me.btnToolEndFind.Name = "btnToolEndFind"
      Me.btnToolEndFind.Size = New System.Drawing.Size(24, 22)
      Me.btnToolEndFind.TabIndex = 30
      Me.btnToolEndFind.TabStop = False
      Me.btnToolEndFind.ThemedImage = CType(resources.GetObject("btnToolEndFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'btnToolStartFind
      '
      Me.btnToolStartFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnToolStartFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnToolStartFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnToolStartFind.Location = New System.Drawing.Point(209, 17)
      Me.btnToolStartFind.Name = "btnToolStartFind"
      Me.btnToolStartFind.Size = New System.Drawing.Size(24, 22)
      Me.btnToolStartFind.TabIndex = 29
      Me.btnToolStartFind.TabStop = False
      Me.btnToolStartFind.ThemedImage = CType(resources.GetObject("btnToolStartFind.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtCCCodeStart
      '
      Me.Validator.SetDataType(Me.txtCCCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtCCCodeStart, "")
      Me.txtCCCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtCCCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtCCCodeStart, System.Drawing.Color.Empty)
      Me.txtCCCodeStart.Location = New System.Drawing.Point(113, 41)
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
      Me.lblCCStart.Location = New System.Drawing.Point(7, 41)
      Me.lblCCStart.Name = "lblCCStart"
      Me.lblCCStart.Size = New System.Drawing.Size(104, 18)
      Me.lblCCStart.TabIndex = 26
      Me.lblCCStart.Text = "CostCenter ��Ңͧ"
      Me.lblCCStart.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'txtToolCodeEnd
      '
      Me.Validator.SetDataType(Me.txtToolCodeEnd, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolCodeEnd, "")
      Me.txtToolCodeEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToolCodeEnd, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToolCodeEnd, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToolCodeEnd, System.Drawing.Color.Empty)
      Me.txtToolCodeEnd.Location = New System.Drawing.Point(278, 17)
      Me.Validator.SetMinValue(Me.txtToolCodeEnd, "")
      Me.txtToolCodeEnd.Name = "txtToolCodeEnd"
      Me.Validator.SetRegularExpression(Me.txtToolCodeEnd, "")
      Me.Validator.SetRequired(Me.txtToolCodeEnd, False)
      Me.txtToolCodeEnd.Size = New System.Drawing.Size(102, 21)
      Me.txtToolCodeEnd.TabIndex = 5
      '
      'lblToolEnd
      '
      Me.lblToolEnd.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolEnd.ForeColor = System.Drawing.Color.Black
      Me.lblToolEnd.Location = New System.Drawing.Point(248, 17)
      Me.lblToolEnd.Name = "lblToolEnd"
      Me.lblToolEnd.Size = New System.Drawing.Size(24, 18)
      Me.lblToolEnd.TabIndex = 9
      Me.lblToolEnd.Text = "�֧"
      Me.lblToolEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
      '
      'txtToolCodeStart
      '
      Me.Validator.SetDataType(Me.txtToolCodeStart, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtToolCodeStart, "")
      Me.txtToolCodeStart.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtToolCodeStart, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtToolCodeStart, -15)
      Me.Validator.SetInvalidBackColor(Me.txtToolCodeStart, System.Drawing.Color.Empty)
      Me.txtToolCodeStart.Location = New System.Drawing.Point(113, 17)
      Me.Validator.SetMinValue(Me.txtToolCodeStart, "")
      Me.txtToolCodeStart.Name = "txtToolCodeStart"
      Me.Validator.SetRegularExpression(Me.txtToolCodeStart, "")
      Me.Validator.SetRequired(Me.txtToolCodeStart, False)
      Me.txtToolCodeStart.Size = New System.Drawing.Size(96, 21)
      Me.txtToolCodeStart.TabIndex = 4
      '
      'lblToolCode
      '
      Me.lblToolCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblToolCode.ForeColor = System.Drawing.Color.Black
      Me.lblToolCode.Location = New System.Drawing.Point(17, 17)
      Me.lblToolCode.Name = "lblToolCode"
      Me.lblToolCode.Size = New System.Drawing.Size(88, 18)
      Me.lblToolCode.TabIndex = 6
      Me.lblToolCode.Text = "��������ͧ���:"
      Me.lblToolCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnSearch
      '
      Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnSearch.Location = New System.Drawing.Point(363, 178)
      Me.btnSearch.Name = "btnSearch"
      Me.btnSearch.Size = New System.Drawing.Size(75, 23)
      Me.btnSearch.TabIndex = 2
      Me.btnSearch.Text = "����"
      '
      'btnReset
      '
      Me.btnReset.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
      Me.btnReset.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnReset.Location = New System.Drawing.Point(283, 178)
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
      'btnDocTypeList
      '
      Me.btnDocTypeList.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnDocTypeList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnDocTypeList.Location = New System.Drawing.Point(381, 113)
      Me.btnDocTypeList.Name = "btnDocTypeList"
      Me.btnDocTypeList.Size = New System.Drawing.Size(24, 23)
      Me.btnDocTypeList.TabIndex = 32
      Me.btnDocTypeList.TabStop = False
      Me.btnDocTypeList.ThemedImage = CType(resources.GetObject("btnDocTypeList.ThemedImage"), System.Drawing.Bitmap)
      '
      'txtDoctypeList
      '
      Me.Validator.SetDataType(Me.txtDoctypeList, Longkong.Pojjaman.Gui.Components.DataTypeConstants.StringType)
      Me.Validator.SetDisplayName(Me.txtDoctypeList, "")
      Me.txtDoctypeList.Enabled = False
      Me.txtDoctypeList.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Validator.SetGotFocusBackColor(Me.txtDoctypeList, System.Drawing.Color.Empty)
      Me.ErrorProvider1.SetIconPadding(Me.txtDoctypeList, -15)
      Me.Validator.SetInvalidBackColor(Me.txtDoctypeList, System.Drawing.Color.Empty)
      Me.txtDoctypeList.Location = New System.Drawing.Point(113, 115)
      Me.Validator.SetMinValue(Me.txtDoctypeList, "")
      Me.txtDoctypeList.Multiline = True
      Me.txtDoctypeList.Name = "txtDoctypeList"
      Me.txtDoctypeList.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtDoctypeList, "")
      Me.Validator.SetRequired(Me.txtDoctypeList, False)
      Me.txtDoctypeList.Size = New System.Drawing.Size(262, 37)
      Me.txtDoctypeList.TabIndex = 33
      Me.txtDoctypeList.TabStop = False
      Me.txtDoctypeList.Text = "�ءʶҹ�"
      '
      'Label1
      '
      Me.Label1.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Label1.ForeColor = System.Drawing.Color.Black
      Me.Label1.Location = New System.Drawing.Point(6, 115)
      Me.Label1.Name = "Label1"
      Me.Label1.Size = New System.Drawing.Size(104, 18)
      Me.Label1.TabIndex = 34
      Me.Label1.Text = "��ͧʶҹ�"
      Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
      '
      'btnGroupFind
      '
      Me.btnGroupFind.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.btnGroupFind.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.btnGroupFind.ForeColor = System.Drawing.SystemColors.Control
      Me.btnGroupFind.Location = New System.Drawing.Point(353, 64)
      Me.btnGroupFind.Name = "btnGroupFind"
      Me.btnGroupFind.Size = New System.Drawing.Size(24, 23)
      Me.btnGroupFind.TabIndex = 38
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
      Me.txtGroupCode.Location = New System.Drawing.Point(113, 64)
      Me.txtGroupCode.MaxLength = 20
      Me.Validator.SetMinValue(Me.txtGroupCode, "")
      Me.txtGroupCode.Name = "txtGroupCode"
      Me.Validator.SetRegularExpression(Me.txtGroupCode, "")
      Me.Validator.SetRequired(Me.txtGroupCode, False)
      Me.txtGroupCode.Size = New System.Drawing.Size(96, 21)
      Me.txtGroupCode.TabIndex = 36
      '
      'lblGroup
      '
      Me.lblGroup.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.lblGroup.ForeColor = System.Drawing.Color.Black
      Me.lblGroup.Location = New System.Drawing.Point(33, 64)
      Me.lblGroup.Name = "lblGroup"
      Me.lblGroup.Size = New System.Drawing.Size(72, 18)
      Me.lblGroup.TabIndex = 35
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
      Me.txtGroupName.Location = New System.Drawing.Point(209, 64)
      Me.Validator.SetMinValue(Me.txtGroupName, "")
      Me.txtGroupName.Name = "txtGroupName"
      Me.txtGroupName.ReadOnly = True
      Me.Validator.SetRegularExpression(Me.txtGroupName, "")
      Me.Validator.SetRequired(Me.txtGroupName, False)
      Me.txtGroupName.Size = New System.Drawing.Size(144, 21)
      Me.txtGroupName.TabIndex = 37
      Me.txtGroupName.TabStop = False
      '
      'chkIncludeTGChildren
      '
      Me.chkIncludeTGChildren.FlatStyle = System.Windows.Forms.FlatStyle.System
      Me.chkIncludeTGChildren.Location = New System.Drawing.Point(113, 90)
      Me.chkIncludeTGChildren.Name = "chkIncludeTGChildren"
      Me.chkIncludeTGChildren.Size = New System.Drawing.Size(128, 21)
      Me.chkIncludeTGChildren.TabIndex = 60
      Me.chkIncludeTGChildren.Text = "������������ͧ���"
      '
      'RptToolStatusFilterSubPanel
      '
      Me.Controls.Add(Me.txttmp)
      Me.Controls.Add(Me.grbMaster)
      Me.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Me.Name = "RptToolStatusFilterSubPanel"
      Me.Size = New System.Drawing.Size(679, 221)
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
      'If Not m_entity Is Nothing Then Me.Text = Me.StringParserService.Parse(Me.m_entity.TabPageText)
      Me.lblToolCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptToolStatusFilterSubPanel.lblToolCode}")
      Me.Validator.SetDisplayName(txtToolCodeStart, lblToolCode.Text)

      Me.lblCCStart.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptToolStatusFilterSubPanel.lblCCStart}")
      Me.Validator.SetDisplayName(txtCCCodeStart, lblCCStart.Text)

      ' Global {�֧}
      Me.lblToolEnd.Text = Me.StringParserService.Parse("${res:Global.FilterPanelTo}")
      Me.Validator.SetDisplayName(txtToolCodeEnd, lblToolEnd.Text)

      ' Button
      Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
      Me.btnReset.Text = Me.StringParserService.Parse("${res:Global.ResetButtonText}")

      ' GroupBox
      Me.grbMaster.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.grbMaster}")
      Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.Rpt271FilterSubPanel.grbDetail}")
    End Sub
#End Region

#Region "Member"
    Private m_toolstart As Tool
    Private m_toolend As Tool

    Private m_DocDateEnd As Date
    Private m_DocDateStart As Date

    Private m_cc As CostCenter

    Private m_systemIndexList As String
    Private m_systemIdList As String
    Private m_systemCodeList As String
    Private m_systemIncNull As Boolean
    Dim m_toolgroup As New ToolGroup
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
    Public Property Toolstart() As Tool
      Get
        Return m_toolstart
      End Get
      Set(ByVal Value As Tool)
        m_toolstart = Value
      End Set
    End Property
    Public Property ToolEnd() As Tool
      Get
        Return m_toolend
      End Get
      Set(ByVal Value As Tool)
        m_toolend = Value
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
    Public Property DocDateEnd() As Date      Get        Return m_DocDateEnd      End Get      Set(ByVal Value As Date)        m_DocDateEnd = Value      End Set    End Property    Public Property DocDateStart() As Date      Get        Return m_DocDateStart      End Get      Set(ByVal Value As Date)        m_DocDateStart = Value      End Set    End Property

    Public Property CostCenter() As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal Value As CostCenter)
        m_cc = Value
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

      Me.Toolstart = New Tool
      Me.ToolEnd = New Tool

      Dim dtStart As Date = Date.Now.Subtract(New TimeSpan(7, 0, 0, 0))
      Me.DocDateStart = dtStart
      'Me.txtDocDateStart.Text = MinDateToNull(Me.DocDateStart, "")
      'Me.dtpDocDateStart.Value = Me.DocDateStart

      Me.DocDateEnd = Date.Now
      'Me.txtDocDateEnd.Text = MinDateToNull(Me.DocDateEnd, "")
      'Me.dtpDocDateEnd.Value = Me.DocDateEnd

      Me.ChkCancel.Checked = False
      Me.Group = New ToolGroup

      m_systemIdList = ""
      m_systemCodeList = ""
      m_systemIndexList = ""
      m_systemIncNull = False
      Me.txtDoctypeList.Text = "����к�"
    End Sub
    Public Overrides Function GetFilterString() As String

    End Function
    Public Overrides Function GetFilterArray() As Filter()
      Dim arr(6) As Filter
      'arr(0) = New Filter("DocDateStart", IIf(Me.DocDateStart.Equals(Date.MinValue), DBNull.Value, Me.DocDateStart))
      'arr(1) = New Filter("DocDateEnd", IIf(Me.DocDateEnd.Equals(Date.MinValue), DBNull.Value, Me.DocDateEnd))
      arr(0) = New Filter("ToolCodeStart", IIf(txtToolCodeStart.TextLength > 0, txtToolCodeStart.Text, DBNull.Value))
      arr(1) = New Filter("ToolCodeEnd", IIf(txtToolCodeEnd.TextLength > 0, txtToolCodeEnd.Text, DBNull.Value))
      arr(2) = New Filter("CostCenter", IIf(txtCCCodeStart.TextLength > 0, txtCCCodeStart.Text, DBNull.Value))
      arr(3) = New Filter("ToolGroup", IIf(Me.Group.Valid, Me.Group.Id, DBNull.Value))
      arr(4) = New Filter("includeChildtg", Me.chkIncludeTGChildren.Checked)
      arr(5) = New Filter("userRight", CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService).CurrentUser.Id)
      arr(6) = New Filter("HaveStatus", IIf(m_systemIdList.Length > 0, m_systemIdList, DBNull.Value))
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

      'Tool Start
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolCodeStart"
      dpi.Value = Me.txtToolCodeStart.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Tool End
      dpi = New DocPrintingItem
      dpi.Mapping = "ToolCodeEnd"
      dpi.Value = Me.txtToolCodeEnd.Text
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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
      AddHandler btnToolStartFind.Click, AddressOf Me.btnToolFind_Click
      AddHandler btnToolEndFind.Click, AddressOf Me.btnToolFind_Click

      AddHandler btnCCStartFind.Click, AddressOf Me.btnCCFind_Click
      'AddHandler btnCCEndFind.Click, AddressOf Me.btnCCFind_Click

      AddHandler txtToolCodeStart.Validated, AddressOf Me.ChangeProperty
      AddHandler txtToolCodeEnd.Validated, AddressOf Me.ChangeProperty

      AddHandler txtCCCodeStart.Validated, AddressOf Me.ChangeProperty
      'AddHandler txtCCCodeEnd.Validated, AddressOf Me.ChangeProperty

      'AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
      'AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty
    End Sub

    Private m_dateSetting As Boolean
    Private Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)

      Select Case CType(sender, Control).Name.ToLower
        Case "txttoolcodestart"
          Tool.GetTool(txtToolCodeStart, txttmp, Me.Toolstart)

        Case "txttoolcodeend"
          Tool.GetTool(txtToolCodeEnd, txttmp, Me.ToolEnd)

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
              Case "txtToolcodestart", "txtToolcodeend"
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
            Case "txtToolcodestart"
              Me.SetToolStartDialog(entity)

            Case "txtToolcodeend"
              Me.SetToolEndDialog(entity)

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
          End Select
        End If
      End If
    End Sub
#End Region

#Region " Event Handlers "
    Private Sub btnToolFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btntoolstartfind"

          myEntityPanelService.OpenListDialog(New Tool, AddressOf SetToolStartDialog)

        Case "btntoolendfind"
          myEntityPanelService.OpenListDialog(New Tool, AddressOf SetToolEndDialog)
      End Select
    End Sub
    Private Sub btnCCFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      Select Case CType(sender, Control).Name.ToLower
        Case "btnccstartfind"
          myEntityPanelService.OpenTreeDialog(New CostCenter, AddressOf SetCCCodeStartDialog)
      End Select
    End Sub
    Private Sub SetToolStartDialog(ByVal e As ISimpleEntity)
      Me.txtToolCodeStart.Text = e.Code
      Tool.GetTool(txtToolCodeStart, txttmp, Me.Toolstart)
    End Sub
    Private Sub SetToolEndDialog(ByVal e As ISimpleEntity)
      Me.txtToolCodeEnd.Text = e.Code
      Tool.GetTool(txtToolCodeEnd, txttmp, Me.ToolEnd)
      Me.txtToolCodeEnd.Text = Me.ToolEnd.Code
    End Sub
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

   


#End Region

#Region "Filter Document"

    ' Ple System
    Private Sub btnPleSystem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDocTypeList.Click

      Dim ls As Generic.List(Of CodeDescription) = CodeDescription.GetCodeListOf("eqtstatus", " code_value not in (0,1,10)")

      Dim chkdlg As New Longkong.Pojjaman.Gui.Panels.CheckListDialog(ls, m_systemIndexList)
      Dim myDialog As New Longkong.Pojjaman.Gui.Dialogs.PanelDialog(chkdlg)
      If myDialog.ShowDialog() = DialogResult.OK Then
        Me.txtDoctypeList.Text = chkdlg.CheckedCodeString
        m_systemCodeList = chkdlg.CheckedCodeString
        m_systemIndexList = chkdlg.CheckedValuesString
        m_systemIdList = chkdlg.CheckedIdString
        m_systemIncNull = chkdlg.CheckedNull

      End If
    End Sub
#End Region
  End Class
End Namespace

