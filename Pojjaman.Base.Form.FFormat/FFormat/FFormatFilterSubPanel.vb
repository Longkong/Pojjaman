Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Namespace Longkong.Pojjaman.Gui.Panels
    Public Class FFormatFilterSubPanel
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
        Friend WithEvents txtCode As System.Windows.Forms.TextBox
        Friend WithEvents lblCode As System.Windows.Forms.Label
        Friend WithEvents cmbType As System.Windows.Forms.ComboBox
        Friend WithEvents lblType As System.Windows.Forms.Label
        <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
            Me.grbDetail = New Longkong.Pojjaman.Gui.Components.FixedGroupBox
            Me.txtCode = New System.Windows.Forms.TextBox
            Me.lblCode = New System.Windows.Forms.Label
            Me.cmbType = New System.Windows.Forms.ComboBox
            Me.lblType = New System.Windows.Forms.Label
            Me.btnSearch = New System.Windows.Forms.Button
            Me.grbDetail.SuspendLayout()
            Me.SuspendLayout()
            '
            'grbDetail
            '
            Me.grbDetail.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                        Or System.Windows.Forms.AnchorStyles.Left) _
                        Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
            Me.grbDetail.Controls.Add(Me.txtCode)
            Me.grbDetail.Controls.Add(Me.lblCode)
            Me.grbDetail.Controls.Add(Me.cmbType)
            Me.grbDetail.Controls.Add(Me.lblType)
            Me.grbDetail.Controls.Add(Me.btnSearch)
            Me.grbDetail.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.grbDetail.Location = New System.Drawing.Point(8, 8)
            Me.grbDetail.Name = "grbDetail"
            Me.grbDetail.Size = New System.Drawing.Size(808, 88)
            Me.grbDetail.TabIndex = 0
            Me.grbDetail.TabStop = False
            '
            'txtCode
            '
            Me.txtCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.txtCode.Location = New System.Drawing.Point(120, 16)
            Me.txtCode.Name = "txtCode"
            Me.txtCode.Size = New System.Drawing.Size(176, 21)
            Me.txtCode.TabIndex = 198
            Me.txtCode.Text = ""
            '
            'lblCode
            '
            Me.lblCode.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblCode.ForeColor = System.Drawing.Color.Black
            Me.lblCode.Location = New System.Drawing.Point(16, 16)
            Me.lblCode.Name = "lblCode"
            Me.lblCode.Size = New System.Drawing.Size(104, 18)
            Me.lblCode.TabIndex = 199
            Me.lblCode.Text = "����/����:"
            Me.lblCode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'cmbType
            '
            Me.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
            Me.cmbType.Location = New System.Drawing.Point(120, 40)
            Me.cmbType.Name = "cmbType"
            Me.cmbType.Size = New System.Drawing.Size(104, 21)
            Me.cmbType.TabIndex = 3
            '
            'lblType
            '
            Me.lblType.BackColor = System.Drawing.Color.Transparent
            Me.lblType.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            Me.lblType.ForeColor = System.Drawing.SystemColors.WindowText
            Me.lblType.Location = New System.Drawing.Point(16, 40)
            Me.lblType.Name = "lblType"
            Me.lblType.Size = New System.Drawing.Size(104, 18)
            Me.lblType.TabIndex = 197
            Me.lblType.Text = "������:"
            Me.lblType.TextAlign = System.Drawing.ContentAlignment.MiddleRight
            '
            'btnSearch
            '
            Me.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System
            Me.btnSearch.Location = New System.Drawing.Point(224, 40)
            Me.btnSearch.Name = "btnSearch"
            Me.btnSearch.Size = New System.Drawing.Size(72, 24)
            Me.btnSearch.TabIndex = 5
            Me.btnSearch.TabStop = False
            Me.btnSearch.Text = "Search"
            '
            'FFormatFilterSubPanel
            '
            Me.Controls.Add(Me.grbDetail)
            Me.Name = "FFormatFilterSubPanel"
            Me.Size = New System.Drawing.Size(832, 104)
            Me.grbDetail.ResumeLayout(False)
            Me.ResumeLayout(False)

        End Sub

#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()

            InitializeComponent()
            Initialize()
            SetLabelText()

        End Sub
#End Region

#Region "Members"
#End Region

#Region "Methods"
        Public Sub Initialize()
            PopulateType()
            ClearCriterias()
        End Sub
        Private Sub ClearCriterias()

        End Sub
        Private Sub PopulateType()
            CodeDescription.ListCodeDescriptionInComboBox(Me.cmbType, "financialstatement_type", True)
            Me.cmbType.SelectedIndex = 0
        End Sub
        Public Sub SetLabelText()
            Me.grbDetail.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatFilterSubPanel.grbDetail}")
            Me.lblCode.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatFilterSubPanel.lblCode}")
            Me.btnSearch.Text = Me.StringParserService.Parse("${res:Global.SearchButtonText}")
            Me.lblType.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.FFormatFilterSubPanel.lblType}")
        End Sub
        Public Overrides Function GetFilterArray() As Filter()
            Dim arr(1) As Filter
            arr(0) = New Filter("code", IIf(Me.txtCode.Text.Length = 0, DBNull.Value, Me.txtCode.Text))
            Dim type As Object
            If Me.cmbType.SelectedIndex <= 0 Then
                type = DBNull.Value
            Else
                type = CType(Me.cmbType.SelectedItem, IdValuePair).Id
            End If
            arr(1) = New Filter("ff_reporttype", type)
            Return arr
        End Function
        Public Overrides ReadOnly Property SearchButton() As System.Windows.Forms.Button
            Get
                Return Me.btnSearch
            End Get
        End Property
#End Region

#Region "Entities"
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
                If TypeOf entity Is FFormat Then
                    Me.cmbType.Enabled = False
                    CodeDescription.ComboSelect(Me.cmbType, CType(entity, FFormat).ReportType)
                End If
            Next
        End Sub
#End Region

    End Class
End Namespace

