'Imports Longkong.Pojjaman.Services
'Imports Longkong.Core.Services
'Imports Longkong.Core.AddIns.Codons
'Imports Longkong.Pojjaman.BrowserDisplayBinding
'Imports Longkong.Pojjaman.Gui.Components
'Imports Longkong.Pojjaman.Gui.Panels
'Imports Longkong.Pojjaman.BusinessLogic
'Imports Longkong.Core.AddIns
'Imports Longkong.Pojjaman.Gui
'Namespace Longkong.Pojjaman.PanelDisplayBinding
'    Public Class ListDetailDisplayBinding
'        Implements IEntityDisplayBinding

'#Region "IEntityDisplayBinding"
'        Public Function CanCreateContentForEntity(ByVal entity As BusinessLogic.ISimpleEntity) As Boolean Implements Core.AddIns.Codons.IEntityDisplayBinding.CanCreateContentForEntity
'            Select Case entity.ClassName.ToLower
'                Case "customer", "material", "labor", "supplier" _
'                , "asset", "bank", "tool", "department", "employee" _
'                , "equipment", "user", "site", "po", "pr", "purchase" _
'                , "accountperiod", "bankaccount"
'                    Return True
'                Case Else
'                    Return True
'            End Select
'        End Function
'        Public Function CreateContentForEntity(ByVal entity As BusinessLogic.ISimpleEntity) As Gui.IViewContent Implements Core.AddIns.Codons.IEntityDisplayBinding.CreateContentForEntity
'            Dim myControl As New SimpleListPanelView(entity)
'            Return myControl
'        End Function
'        Public ReadOnly Property PanelType() As Core.AddIns.Codons.PanelType Implements Core.AddIns.Codons.IEntityDisplayBinding.PanelType
'            Get
'                Return PanelType.ListDetail
'            End Get
'        End Property

'#End Region

'    End Class
'End Namespace

