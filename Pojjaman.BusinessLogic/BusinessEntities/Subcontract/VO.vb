Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Services
Imports Longkong.Pojjaman.TextHelper
Imports System.Collections.Generic
Imports System.Threading.Tasks

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class VO
    Inherits SimpleBusinessEntityBase
    Implements IPrintableEntity, ICancelable, IHasToCostCenter, IDuplicable,  _
      ICheckPeriod, IWBSAllocatable, IApprovAble, IAbleExceptAccountPeriod _
   , ICloseStatusAble, IApproveStatusAble, IShowStatusColorAble, IDocStatus, IDocumentPersonAble

#Region "Members"
    Private m_docDate As Date
    Private m_olddocDate As Date
    Private m_VO As VO
    Private m_note As String
    Private m_gross As Decimal
    Private m_discount As Discount
    Private m_beforeTax As Decimal
    Private m_taxGross As Decimal
    Private m_taxBase As Decimal
    Private m_taxRate As Decimal
    Private m_taxType As TaxType
    Private m_taxAmount As Decimal
    Private m_realTaxBase As Decimal
    Private m_afterTax As Decimal
    Private m_realGross As Decimal
    Private m_realTaxAmount As Decimal
    Private m_customNoteColl As CustomNoteCollection
    Private m_status As VOStatus
    Private m_sc As SC
    Private m_itemCollection As VOItemCollection
    Private m_subcontractor As Supplier
    Private m_cc As CostCenter
    Private m_approvePerson As User
    Private m_approveDate As DateTime

    Private m_retention As Decimal
    Private m_advancepay As Decimal

    Private m_closed As Boolean
    Private m_closing As Boolean
    Private m_approveDocColl As ApproveDocCollection
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      With Me
        .m_cc = New CostCenter
        .DocDate = Now.Date
        .m_olddocDate = Now.Date
        .m_subcontractor = New Supplier

        .m_sc = New SC
        .m_note = ""
        .m_gross = 0
        .m_discount = New Discount("")
        .m_beforeTax = 0
        .m_taxBase = 0
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        .m_taxGross = 0
        .m_taxAmount = 0
        .m_afterTax = 0
        .m_realTaxBase = 0
        .m_realGross = 0
        .m_realTaxAmount = 0
        .m_status = New VOStatus(-1)
        .AutoCodeFormat = New AutoCodeFormat(Me)

      End With

      m_itemCollection = New VOItemCollection(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        '' sc
        If dr.Table.Columns.Contains("vo_sc") Then
          If Not dr.IsNull("vo_sc") Then
            .m_sc = New SC(CInt(dr("vo_sc")))
            '.m_subcontractor = New Supplier(dr, "supplier.")
          End If
        End If
        If dr.Table.Columns.Contains("vo_docdate") AndAlso Not dr.IsNull("vo_docdate") Then
          If IsDate(dr("vo_docdate")) Then
            .m_docDate = CDate(dr("vo_docdate"))
            .m_olddocDate = CDate(dr("vo_docdate"))
          End If
          '.m_subcontractor = New Supplier(dr, "supplier.")
        End If
        If dr.Table.Columns.Contains("vo_note") AndAlso Not dr.IsNull("vo_note") Then
          .m_note = CStr(dr("vo_note"))
        End If
        If dr.Table.Columns.Contains("vo_status") AndAlso Not dr.IsNull("vo_status") Then
          .m_status = New VOStatus(CInt(dr("vo_status")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vo_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "vo_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "vo_taxtype")))
        End If
        If Not dr.IsNull(aliasPrefix & "vo_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "vo_taxrate"))
        End If
        '--------------------REAL-------------------------
        ' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "vo_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "vo_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "vo_taxbase"))
        End If

        ' Gross
        If dr.Table.Columns.Contains(aliasPrefix & "vo_gross") _
        AndAlso Not dr.IsNull(aliasPrefix & "vo_gross") Then
          .m_realGross = CDec(dr(aliasPrefix & "vo_gross"))
        End If

        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "vo_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "vo_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "vo_taxamt"))
        End If
        '--------------------END REAL-------------------------

        If dr.Table.Columns.Contains(aliasPrefix & "vo_closed") AndAlso Not dr.IsNull(aliasPrefix & "vo_closed") Then
          .m_closed = CBool(dr(aliasPrefix & "vo_closed"))
          .m_closing = CBool(dr(aliasPrefix & "vo_closed"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vo_retention") AndAlso Not dr.IsNull(aliasPrefix & "vo_retention") Then
          .m_retention = CDec(dr(aliasPrefix & "vo_retention"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "vo_advancepay") AndAlso Not dr.IsNull(aliasPrefix & "vo_advancepay") Then
          .m_advancepay = CDec(dr(aliasPrefix & "vo_advancepay"))
        End If
        ' ApprovePerson
        If dr.Table.Columns.Contains("approvePerson.user_id") Then
          If Not dr.IsNull("approvePerson.user_id") Then
            .m_approvePerson = New User(dr, "approvePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "vo_approvePerson") Then
            .m_approvePerson = New User(CInt(dr(aliasPrefix & "vo_approvePerson")))
          End If
        End If
        ' Approved Date
        If Not dr.IsNull(aliasPrefix & "vo_approveDate") Then
          .m_approveDate = CDate(dr(aliasPrefix & "vo_approveDate"))
        End If

        m_itemCollection = New VOItemCollection(Me)
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property ApproveDocColl As ApproveDocCollection
      Get
        Return m_approveDocColl
      End Get
      Set(ByVal value As ApproveDocCollection)
        '
      End Set
    End Property
    Public ReadOnly Property ExceptAccountPeriod As Boolean Implements IAbleExceptAccountPeriod.ExceptAccountPeriod
      Get
        Return Me.Closed
      End Get
    End Property
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate, IWBSAllocatable.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        'OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocDate
      End Get
    End Property
    Public Property VO() As VO
      Get
        Return m_VO
      End Get
      Set(ByVal Value As VO)
        m_VO = Value
        If m_VO.Code <> Value.Code Then
          m_VO = New VO(Value.Code)
        End If
      End Set
    End Property

    Public Property Note() As String
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
      End Set
    End Property
    Public Property ItemCollection() As VOItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As VOItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property SubContractor() As Supplier Implements IWBSAllocatable.Supplier
      Get
        Return Me.SC.SubContractor
      End Get
      Set(ByVal Value As Supplier)
        If Me.SC.SubContractor Is Nothing Then
          Me.SC.SubContractor = New Supplier
        End If
        Me.SC.SubContractor = Value
        'OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property CostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter, IHasToCostCenter.ToCC
      Get
        Return Me.SC.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        If Me.SC.CostCenter Is Nothing Then
          Me.SC.CostCenter = New CostCenter
        End If
        Me.SC.CostCenter = Value
        'OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property Gross() As Decimal
      Get
        Return m_gross
      End Get
    End Property
    Public ReadOnly Property BeforeTax() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0     '"�����"
            Return Me.RealGross - Me.Discount.Amount
          Case 1     '"�¡"
            Return Me.RealGross - Me.Discount.Amount
          Case 2     '"���"
            Return Me.AfterTax - Me.RealTaxAmount
        End Select
      End Get
    End Property    Public ReadOnly Property TaxGross() As Decimal
      Get
        Return m_taxGross
      End Get
    End Property    Public Property TaxBase() As Decimal
      Get
        Return m_taxBase
      End Get
      Set(ByVal Value As Decimal)
        m_taxBase = Value
      End Set
    End Property    Public Property TaxRate() As Decimal
      Get
        Return m_taxRate
      End Get
      Set(ByVal Value As Decimal)
        m_taxRate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property TaxType() As TaxType
      Get
        Return m_taxType
      End Get
      Set(ByVal Value As TaxType)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        If Not Me.SC Is Nothing Then
          If Value.Value <> Me.SC.TaxType.Value Then
            msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.SC.CanNotChangeVATType}")
            Return
          End If
        End If
        m_taxType = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property TaxAmount() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0     '"�����"
            Return 0
          Case 2     '��� VAT
            Return Me.TaxGross - Me.DiscountWithVat - Me.RealTaxBase
          Case Else     '1 �¡
            Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)
        End Select
      End Get
    End Property
    Public ReadOnly Property AfterTax() As Decimal Implements IApprovAble.AmountToApprove
      Get
        Select Case Me.TaxType.Value
          Case 0     '"�����"
            Return Me.BeforeTax
          Case 1     '"�¡"
            Return Me.BeforeTax + Me.RealTaxAmount
          Case 2     '"���"
            Return Me.RealGross - Me.Discount.Amount
        End Select
      End Get
    End Property
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, VOStatus)
      End Set
    End Property
    Public Property AdvancePay() As Decimal      Get
        Return m_advancepay
      End Get
      Set(ByVal Value As Decimal)
        m_advancepay = Value
      End Set
    End Property
    Public Property Retention() As Decimal
      Get
        Return m_retention
      End Get
      Set(ByVal Value As Decimal)
        m_retention = Value
      End Set
    End Property
    'Public ReadOnly Property DiscountWithVat() As Decimal
    '    Get
    '        If Me.Gross = 0 Then
    '            Return 0
    '        End If
    '        Return Configuration.Format(Me.Discount.Amount * Me.TaxGross / Me.Gross, DigitConfig.Price)
    '    End Get
    'End Property
    '--------------------REAL-------------------------    Public Property RealTaxBase() As Decimal
      Get
        Return m_realTaxBase
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxBase = Value
      End Set
    End Property
    Public Property Closed() As Boolean Implements ICloseStatusAble.Closed      Get
        Return m_closed
      End Get
      Set(ByVal Value As Boolean)
        m_closed = Value
      End Set
    End Property
    Public Property Closing() As Boolean      Get
        Return m_closing
      End Get
      Set(ByVal Value As Boolean)
        m_closing = Value
        If m_closing Then '���ѧ�лԴ
          For Each item As VOItem In Me.ItemCollection
            If item.Level = 1 Then
              item.SetMat(item.ReceivedMat)
              item.SetLab(item.ReceivedLab)
              item.SetEq(item.ReceivedEq)
              item.SetQty(item.ReceivedQty)
            End If
          Next
        Else '¡��ԡ��ûԴ
          For Each item As VOItem In Me.ItemCollection
            If item.Level = 1 Then
              item.SetMat(item.OldMat)
              item.SetLab(item.OldLab)
              item.SetEq(item.OldEq)
              item.SetQty(item.OldQty)
            End If
          Next
        End If
        Me.RefreshTaxBase()
      End Set
    End Property
    Public Property RealGross() As Decimal
      Get
        'HACK
        If m_realGross = 0 AndAlso m_gross <> 0 Then
          m_realGross = m_gross
        End If
        Return m_realGross
      End Get
      Set(ByVal Value As Decimal)
        m_realGross = Value
      End Set
    End Property
    Public Property RealTaxAmount() As Decimal
      Get
        Return m_realTaxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxAmount = Value
      End Set
    End Property
    Public Property Discount() As Discount
      Get
        Return m_discount
      End Get
      Set(ByVal Value As Discount)
        m_discount = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property DiscountAmount() As Decimal
      Get
        Me.Discount.AmountBeforeDiscount = Me.RealGross
        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)
      End Get
    End Property
    Public Property ApprovePerson() As User
      Get
        Return m_approvePerson
      End Get
      Set(ByVal Value As User)
        m_approvePerson = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property ApproveDate() As DateTime
      Get
        Return m_approveDate
      End Get
      Set(ByVal Value As DateTime)
        m_approveDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property SC() As SC      Get        Return m_sc      End Get      Set(ByVal Value As SC)        If Value.Status.Value = 0 OrElse Value.Closed Then          Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          msgServ.ShowWarningFormatted("${res:Global.Error.CanceledSC}", New String() {Value.Code})
          Return
        End If        m_sc = Value        Me.TaxRate = m_sc.TaxRate
        Me.TaxType = New TaxType(m_sc.TaxType.Value)        ChangeSC()      End Set    End Property    Private Sub ChangeSC()      '--------------------------------------ź��¡��----------------------------------
      'Dim itemsToRemove As New ArrayList
      'For Each item As VOItem In Me.ItemCollection
      '    If Not item.scitem Is Nothing Then
      '        If Not item.scitem.sc Is Nothing Then
      '            If item.scitem.sc.Originated Then
      '                itemsToRemove.Add(item)
      '            End If
      '        End If
      '    End If
      'Next      'For Each item As VOItem In Me.ItemCollection      '    Me.ItemCollection.Remove(item)
      'Next      Me.ItemCollection.Clear()      '-------------------------------------------------------------------------------      If Not Me.m_sc Is Nothing AndAlso Me.m_sc.Originated Then
        Me.SubContractor = Me.m_sc.SubContractor
        Me.TaxType = Me.m_sc.TaxType
        Me.TaxRate = Me.SC.TaxRate
        Me.CostCenter = Me.m_sc.CostCenter
        For Each newScitem As SCItem In Me.m_sc.ItemCollection
          If newScitem.ItemType.Value = 289 Then
            Dim item As New VOItem
            item.CopyFromscitem(newScitem)
            item.IsNotVoItem = True
            Me.ItemCollection.Add(item)
            Me.ItemCollection.CurrentItem = item
            Me.ItemCollection.CurrentRealItem = item
          End If
        Next
        'Me.RefreshTaxBase()
      End If
    End Sub
    Private Function GetOldItemTable(ByVal sc As SC) As DataTable
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetVOItemFromSC" _
      , New SqlParameter("@vo_id", Me.Id) _
      , New SqlParameter("@sci_sc", sc.Id) _
      )
      Return ds.Tables(0)
    End Function
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "VO"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VO.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.VO"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.VO"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.VO.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "vo"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property

#End Region

#Region "Shared"
    Public Shared Function GetVO(ByVal txtCode As TextBox, ByRef oldVO As VO) As Boolean
      Dim newVo As New VO(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not newVo.Valid Then
        MessageBox.Show(txtCode.Text & " �������к�")
        newVo = oldVO
        Return False
      End If
      txtCode.Text = newVo.Code
      oldVO = newVo
      Return True
    End Function
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("VO")
      myDatatable.Columns.Add(New DataColumn("sci_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("sci_sc", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("sci_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("sci_itemName", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("voi_code", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("voi_level", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("voi_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("voi_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("voi_unitName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_unitprice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_mat", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_lab", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_eq", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedAmount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("voi_unvatable", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("voi_billingAmount", GetType(Decimal)))

      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Sub RefreshApproveDocCollection() Implements IApproveStatusAble.RefreshApproveDocCollection
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Private Sub RecalculateAmount()
      Dim newUnitPrice As Decimal = 0
      For Each item As VOItem In Me.ItemCollection
        If item.Level = 0 AndAlso item.IsNotRefSC Then
          newUnitPrice = 0
          If item.Qty = 0 Then
            item.SetQty(1)
            item.SetUnitPrice((item.Mat + item.Lab + item.Eq))
          Else
            item.SetUnitPrice((item.Mat + item.Lab + item.Eq) / item.Qty)
          End If
        End If
      Next
    End Sub
    Private Function ListWbsId() As String
      Dim idList As New ArrayList
      For Each itm As VOItem In Me.ItemCollection
        For Each iwbsd As WBSDistribute In itm.WBSDistributeCollection
          idList.Add(iwbsd.WBS.Id)
        Next
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
    End Function
    Private Function ValidateOverBudget() As SaveErrorException
      Dim stringPar As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Me.CostCenter.Type.Value <> 2 Then
        Return New SaveErrorException("-1")
      End If
      If Me.CostCenter.Boq Is Nothing OrElse Me.CostCenter.Boq.Id = 0 Then
        Return New SaveErrorException("-1")
      End If

      'PROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("POOverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If

      'POOverBudgetOnlyWBSAllocate
      config = Configuration.GetConfig("POOverBudgetOnlyWBSAllocate")
      Dim onlyWBSAllocate As Boolean = False
      If Not config Is Nothing Then
        onlyWBSAllocate = CBool(config)
      End If

      '====================
      WBS.ParentBudgetHash = New Hashtable '��������索Ҵ
      '====================
      Dim idList As String = Me.ListWbsId
      Dim dsParentBudget As New DataSet
      dsParentBudget = WBS.GetParentsBudgetList(Me.EntityId, idList)
      Dim currwbsId As Integer
      Dim dt As New DataTable
      If Not onlyCC Then
        For Each item As VOItem In Me.ItemCollection
          If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 AndAlso item.ItemType.Value <> 289 Then

            Dim totalBudget As Decimal = 0
            Dim totalActual As Decimal = 0
            Dim totalCurrent As Decimal = 0
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              totalCurrent = (wbsd.Percent / 100) * item.Amount

              If onlyWBSAllocate Then
                If wbsd.OwnerBudgetAmount - totalCurrent < 0 Then
                  Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
                End If
              End If

              '����Ѻ WBS ����ѹ�ͧ =====>>
              If wbsd.BudgetRemain - totalCurrent < 0 Then
                Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
              End If
              '����Ѻ WBS ����ѹ�ͧ =====<<

              '����Ѻ WBS ���������Ƿ��Ѵ������� =====>>
              currwbsId = wbsd.WBS.Id
              For Each drow As DataRow In dsParentBudget.Tables(0).Select("depend_wbs=" & currwbsId)
                Dim drh As New DataRowHelper(drow)
                totalBudget = 0
                totalActual = 0
                Select Case item.ItemType.Value
                  Case 88
                    totalBudget = drh.GetValue(Of Decimal)("labbudget")
                    totalActual = drh.GetValue(Of Decimal)("labactual")
                  Case 89
                    totalBudget = drh.GetValue(Of Decimal)("eqbudget")
                    totalActual = drh.GetValue(Of Decimal)("eqactual")
                  Case Else
                    totalBudget = drh.GetValue(Of Decimal)("matbudget")
                    totalActual = drh.GetValue(Of Decimal)("matactual")
                End Select
                If totalBudget < (totalActual + wbsd.Amount) Then
                  Dim myId As Integer = drh.GetValue(Of Integer)("depend_parent")
                  Dim myWBS As New WBS(myId)
                  Return New SaveErrorException(myWBS.Code & ":" & myWBS.Name)
                End If
              Next
              '����Ѻ WBS ���������Ƿ��Ѵ������� =====<<

            Next
            If item.WBSDistributeCollection.GetSumPercent = 0 Then
              '����Ѻ Auto �Ѵ���
              Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
              Dim tBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
              Dim tActual As Decimal = (rootWBS.GetActualMat(Me, 6) + rootWBS.GetActualLab(Me, 6) + rootWBS.GetActualEq(Me, 6))
              Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.CostCenter.Id)
              Dim cActual As Decimal = item.Amount
              Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
              If onlyWBSAllocate Then
                If oBudget < ((tActual - thisActual) + cActual) Then
                  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
                End If
              End If
              If tBudget < ((tActual - thisActual) + cActual) Then
                Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
              End If
            End If
          End If
        Next
      Else
        Dim hCC As New Hashtable
        For Each item As VOItem In Me.ItemCollection
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            If Not hCC.ContainsKey(wbsd.CostCenter.Id) Then
              hCC(wbsd.CostCenter.Id) = wbsd
            End If
          Next
          If item.WBSDistributeCollection.GetSumPercent = 0 Then
            '����Ѻ Auto �Ѵ���
            Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
            Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
            Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 6) + rootWBS.GetActualLab(Me, 6) + rootWBS.GetActualEq(Me, 6))
            Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.CostCenter.Id)
            Dim currentActual As Decimal = item.Amount
            Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
            If onlyWBSAllocate Then
              If oBudget < ((totalActual - thisActual) + currentActual) Then
                Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
              End If
            End If
            If totalBudget < ((totalActual - thisActual) + currentActual) Then
              Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
            End If
          End If
        Next
        For Each wbsd As WBSDistribute In hCC.Values
          Dim rootWBS As New WBS(wbsd.WBS.GetWBSRootId)
          Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
          Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 6) + rootWBS.GetActualLab(Me, 6) + rootWBS.GetActualEq(Me, 6))
          Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
          Dim currentActual As Decimal = wbsd.Amount

          Dim tActual As Decimal = (wbsd.WBS.GetActualMat(Me, 6) + wbsd.WBS.GetActualLab(Me, 6) + wbsd.WBS.GetActualEq(Me, 6))
          Dim tcActual As Decimal = wbsd.WBS.GetThisDocActualFromDB(6, Me.Id, wbsd.CostCenter.Id)
          If onlyWBSAllocate Then
            If wbsd.OwnerBudgetAmount < ((tActual - tcActual) + currentActual) Then
              Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
            End If
          End If
          If totalBudget < ((totalActual - thisActual) + currentActual) Then
            Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
          End If
        Next

      End If

      Return New SaveErrorException("0")
    End Function
    Private Function ValidateItem() As SaveErrorException
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim key As String = ""
      Dim c As Integer = 0
      Dim i As Integer = 0
      For Each sitem As VOItem In Me.ItemCollection
        i += 1
        If sitem.Level = 0 Then
          If i > 1 Then
            If c = 0 Then
              Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.vo.NoItem}"))
            End If
          End If
          c = 0
        Else
          c += 1
        End If
      Next
      If i > 0 And c = 0 Then
        Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.vo.NoItem}"))
      End If
      For Each vitem As VOItem In Me.ItemCollection
        If vitem.Level = 0 Then
          If vitem.Amount <> vitem.ChildAmount Then
            If vitem.RefSequence = 0 Then
              If msgServ.AskQuestion("${res:Global.Question.SCAmountNotEqualAllocateAndReCalUnitPrice}") Then
                Me.RecalculateAmount()
                Me.RefreshTaxBase()
                Me.RealTaxBase = Me.TaxBase
                Me.RealTaxAmount = Me.TaxAmount
              Else
                Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
              End If
              'Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverSCAmount}", _
              '      New String() {Configuration.FormatToString(vitem.Amount, DigitConfig.Price), Configuration.FormatToString(vitem.ChildAmount, DigitConfig.Price)})
            End If
          End If
        Else
          Dim m_value As Decimal = vitem.Mat + vitem.Lab + vitem.Eq
          If vitem.Amount <> m_value Then
            Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
New String() {vitem.ItemDescription, Configuration.FormatToString(vitem.Amount, DigitConfig.Price), Configuration.FormatToString(m_value, DigitConfig.Price)})
          End If
        End If
        Dim newHash As New Hashtable
        For Each wbitem As WBSDistribute In vitem.WBSDistributeCollection
          key = wbitem.CostCenter.Code & ":" & wbitem.WBS.Id.ToString
          If Not newHash.Contains(key) Then
            newHash(key) = wbitem
          Else
            Return New SaveErrorException("${res:Global.Error.DupplicateWBS}", New String() {wbitem.WBS.Code})
          End If
          If (wbitem.WBS Is Nothing OrElse wbitem.WBS.Id = 0) AndAlso wbitem.CostCenter.BoqId > 0 Then
            Return New SaveErrorException("${res:Global.Error.WBSMissing}")
          End If
        Next
      Next

      Return New SaveErrorException("0")
    End Function
    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
    End Sub
    Private m_DocMethod As SaveDocMultiApprovalMethod
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Not Me.Originated Then
          m_DocMethod = SaveDocMultiApprovalMethod.Save
        ElseIf Me.Status.Value = 0 Then
          m_DocMethod = SaveDocMultiApprovalMethod.Cancel
        ElseIf Me.Closed Then
          m_DocMethod = SaveDocMultiApprovalMethod.Close
        Else
          m_DocMethod = SaveDocMultiApprovalMethod.Update
        End If

        Dim docValidate As Boolean = True
        If (Me.Originated AndAlso Me.Status.Value = 0) OrElse Me.Closed Then
          docValidate = False
        End If

        If docValidate Then
          If Me.Originated Then
            If Not Me.SubContractor Is Nothing Then
              If Me.SubContractor.Canceled Then
                Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Me.SubContractor.Code})
              End If
            End If
          End If

          If Me.ItemCollection.Count = 0 Then   '.ItemTable.Childs.Count = 0 Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.vo.NoItem}"))
          End If
          Dim ValidateError As SaveErrorException = ValidateItem()
          If Not IsNumeric(ValidateError.Message) Then
            Return ValidateError
          End If

          ''=============== Validate Over Budget ==================>>
          Dim ValidateOverBudgetError As SaveErrorException
          Dim config As Integer = CInt(Configuration.GetConfig("PROverBudget"))
          Select Case config
            Case 0   'Not allow
              ValidateOverBudgetError = Me.ValidateOverBudget
              If Not IsNumeric(ValidateOverBudgetError.Message) Then
                Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.OverBudgetCannotSaved}")
                Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                Return New SaveErrorException(msgString & vbCrLf & msgString2)
              End If
            Case 1   'Warn
              ValidateOverBudgetError = Me.ValidateOverBudget
              If Not IsNumeric(ValidateOverBudgetError.Message) Then
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.AcceptOverBudget}")
                Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                If Not msgServ.AskQuestion(msgString2 & vbCrLf & msgString) Then
                  Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
                End If
              End If
            Case 2   'Do Nothing
          End Select
          ''=============== Validate Over Budget ==================<<
        End If


        Me.RefreshTaxBase()
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)


        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If
        Me.RefreshTaxBase()

        Dim oldcode As String
        Dim oldautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen

        If Me.AutoGen Then 'And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
        Me.AutoGen = False
        Dim willClose As Boolean = False
        If Me.Closing Then
          willClose = True
        ElseIf Not Me.Closing AndAlso Not Me.Closed Then
          willClose = False
        End If

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docDate", Me.ValidDateOrDBNull(Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_sc", Me.ValidIdOrDBNull(Me.SC)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_subcontractor", ValidIdOrDBNull(Me.SC.SubContractor)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ValidIdOrDBNull(Me.SC.CostCenter)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_startdate", Me.ValidDateOrDBNull(Me.StartDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_enddate", Me.ValidDateOrDBNull(Me.EndDate)))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Configuration.GetConfig("CompanyTaxRate"))) 'Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.TaxAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_aftertax", Me.AfterTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforetax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        'paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_closed", Me.Closed))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_closed", willClose))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_advancepay", Me.AdvancePay))

        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        trans = conn.BeginTransaction()
        Dim oldid As Integer = Me.Id

        Try
          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            Select Case CInt(returnVal.Value)
              Case -1, -5
                trans.Rollback()
                ResetID(oldid)
                ResetCode(oldcode, oldautogen)
                Return New SaveErrorException(returnVal.Value.ToString)
            End Select

            Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
            If Not IsNumeric(saveDetailError.Message) Then
              trans.Rollback()
              ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return saveDetailError
            Else
              Select Case CInt(saveDetailError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetID(oldid)
                  ResetCode(oldcode, oldautogen)
                  Return saveDetailError
                Case Else
              End Select
            End If

            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.ResetID(oldid)
                  ResetCode(oldcode, oldautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              Me.ResetID(oldid)
              ResetCode(oldcode, oldautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If

            trans.Commit()

          Catch ex As SqlException
            trans.Rollback()
            Me.ResetID(oldid)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.ResetID(oldid)
            Return New SaveErrorException(ex.ToString)
          End Try

          'Sub Save Block ======================================
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              trans.Rollback()
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          'Try
          '  Dim subsaveerror As SaveErrorException = SubSaveDocApprove(conn, currentUserId)
          '  If Not IsNumeric(subsaveerror.Message) Then
          '    Return New SaveErrorException(" Save Incomplete Please Save Again")
          '  End If
          'Catch ex As Exception
          '  Return New SaveErrorException(ex.ToString)
          'End Try

          Try
            Parallel.Invoke(Sub()
                              SubSaveDocApprove(conn, currentUserId)
                            End Sub,
                            Sub()
                              WBSActual.SummaryPOWBSActual(conn)
                            End Sub,
                            Sub()
                              WBSActual.SummarySCWBSActual(conn)
                            End Sub,
                            Sub()
                              WBSActual.SummaryVOWBSActual(conn)
                            End Sub,
                            Sub()
                              WBSActual.SummaryPOAdjWBSActual(conn)
                            End Sub,
                            Sub()
                              WBSActual.SummaryDRWBSActual(conn)
                            End Sub
                 )
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          Try
            Dim subsaveerror As SaveErrorException = WBSActual.SummaryChildActual(conn, "po")
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again (2)")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try
          'Sub Save Block ======================================

          Return New SaveErrorException(returnVal.Value.ToString)
          'Complete Save
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      '======����� trans 2 �ͧ�Դ��� save ���� ========
      Dim trans As SqlTransaction = conn.BeginTransaction
      'Save CustomNote �ҡ��� Copy �͡���
      If Not Me.m_customNoteColl Is Nothing AndAlso Me.m_customNoteColl.Count > 0 Then
        If Me.Originated Then
          Me.m_customNoteColl.EntityId = Me.Id
          Me.m_customNoteColl.Save()
        End If
      End If

      For Each extender As Object In Me.Extenders
        If TypeOf extender Is IExtender Then
          Dim saveDocError As SaveErrorException = CType(extender, IExtender).Save(conn, trans)
          If Not IsNumeric(saveDocError.Message) Then
            trans.Rollback()
            Return saveDocError
          Else
            Select Case CInt(saveDocError.Message)
              Case -1, -2, -5
                trans.Rollback()
                Return saveDocError
              Case Else
            End Select
          End If
        End If
      Next


      trans.Commit()

      Dim trans2 As SqlTransaction = conn.BeginTransaction
      Try


        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "UpdateSCParent" _
                                      , New SqlParameter("@id", Me.Id) _
                                      , New SqlParameter("@docType", Me.EntityId))
        Me.DeleteRef(conn, trans2)
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_PORef" _
        ', New SqlParameter("@refto_id", Me.Id))

        Dim isCanceled As Integer = 0
        If Me.Status.Value = 0 Then
          isCanceled = 1
        End If
        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "InsertUpdatereference" _
        , New SqlParameter("@entity_id", Me.SC.Id) _
        , New SqlParameter("@entity_type", Me.SC.EntityId) _
        , New SqlParameter("@refto_id", Me.Id) _
        , New SqlParameter("@refto_type", Me.EntityId) _
        , New SqlParameter("@refto_iscanceled", isCanceled) _
        )

        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "UpdateWBSReferencedFromVO", New SqlParameter("@refto_id", Me.Id))

        'SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")
        trans2.Commit()
      Catch ex As Exception
        trans2.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try


      Return New SaveErrorException("0")
    End Function
    Private Function SubSaveDocApprove(ByVal oldconn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()

      Dim strans As SqlTransaction = conn.BeginTransaction

      Try
                'Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.AfterTax, currentUserId, m_DocMethod, Me.ApproveDocColl.GetLastedApproveDoc.Comment, Me.CostCenter.Id, Me.SubContractor.Id, Me)
                Dim mldoc As DocMultiApproval
                If Not (Me.ApproveDocColl Is Nothing) Then
                    mldoc = New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.AfterTax, currentUserId, m_DocMethod, Me.ApproveDocColl.GetLastedApproveDoc.Comment, Me.CostCenter.Id, Me.SubContractor.Id, Me)
                Else
                    mldoc = New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.AfterTax, currentUserId, m_DocMethod, "", Me.CostCenter.Id, Me.SubContractor.Id, Me)
                End If
                Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, strans)
        If Not IsNumeric(savemldocError.Message) Then
          strans.Rollback()
          conn.Close()
          Return savemldocError
        End If
      Catch ex As Exception
        strans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      strans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function
    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code 'Entity.GetAutoCodeFormat(Me.EntityId)
      Dim pattern As String = CodeGenerator.GetPattern(autoCodeFormat, Me)

      pattern = CodeGenerator.GetPattern(pattern)

      Dim lastCode As String = Me.GetLastCode(pattern)
      Dim newCode As String = _
      CodeGenerator.Generate(autoCodeFormat, lastCode, Me)
      While DuplicateCode(newCode)
        newCode = CodeGenerator.Generate(autoCodeFormat, newCode, Me)
      End While
      Return newCode
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Dim currWBS As String
      Try
        Dim da As New SqlDataAdapter("Select * from voitem where voi_vo=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from voiwbs where voiw_sequence in (select voi_sequence from voitem where voi_vo=" & Me.Id & ")", conn)
        Dim daOld As New SqlDataAdapter("Select * from voolditem where voio_sequence in (select voi_sequence from voitem where voi_vo=" & Me.Id & ")", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From voitem Where voi_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "voitem")
        da.Fill(ds, "voitem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "voiwbs")
        daWbs.Fill(ds, "voiwbs")
        ds.Relations.Add("sequence", ds.Tables!voitem.Columns!voi_sequence, ds.Tables!voiwbs.Columns!voiw_sequence)

        cmdBuilder = New SqlCommandBuilder(daOld)
        daOld.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daOld.FillSchema(ds, SchemaType.Mapped, "voolditem")
        daOld.Fill(ds, "voolditem")
        ds.Relations.Add("sequence2", ds.Tables!voitem.Columns!voi_sequence, ds.Tables!voolditem.Columns!voio_sequence)

        Dim dt As DataTable = ds.Tables("voitem")
        Dim dtWbs As DataTable = ds.Tables("voiwbs")
        Dim dtOld As DataTable = ds.Tables("voolditem")

        For Each row As DataRow In ds.Tables("voolditem").Rows
          row.Delete()
        Next
        For Each row As DataRow In ds.Tables("voiwbs").Rows
          row.Delete()
        Next

        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As VOItem In Me.ItemCollection
            If testItem.Sequence = CInt(dr("voi_sequence")) Then
              found = True
              Exit For
            End If
          Next
          If Not found Then
            If Not rowsToDelete.Contains(dr) Then
              rowsToDelete.Add(dr)
            End If
          End If
        Next
        For Each dr As DataRow In rowsToDelete
          dr.Delete()
        Next
        '------------End Checking--------------------
        'For Each row As DataRow In ds.Tables("voitem").Rows
        '  row.Delete()
        'Next

        Dim i As Integer = 0
        Dim refSequence As Decimal = 0
        With ds.Tables("voitem")
          For Each item As VOItem In Me.ItemCollection
            If item.Level = 0 Then
              refSequence = item.RefSequence
            End If
            If (Not item.IsNotVoItem) Then

              i += 1
              Select Case item.ItemType.Value
                Case 42
                  Dim lci As New LCIItem(item.Entity.Id)
                  If Not lci.Originated Then
                    Return New SaveErrorException("${res:Global.Error.LCIIsInvalid}", New String() {item.Entity.Name})
                  ElseIf Not lci.ValidUnit(item.Unit) Then
                    Return New SaveErrorException("${res:Global.Error.LCIInvalidUnit}", New String() {lci.Code, item.Unit.Name})
                  End If
                Case 19
                  Dim myTool As New Tool(item.Entity.Id)
                  If Not myTool.Originated Then
                    Return New SaveErrorException("${res:Global.Error.ToolIsInvalid}", New String() {item.Entity.Name})
                  ElseIf myTool.Unit.Id <> item.Unit.Id Then
                    Return New SaveErrorException("${res:Global.Error.ToolInvalidUnit}", New String() {myTool.Code, item.Unit.Name})
                  End If
              End Select

              '------------Checking if we have to add a new row or just update existing--------------------
              Dim dr As DataRow
              Dim drs As DataRow() = ds.Tables("voitem").Select("voi_sequence=" & item.Sequence)
              If drs.Length = 0 Then
                dr = .NewRow
                dr("voi_sequence") = (-1) * i
                .Rows.Add(dr)
              Else
                dr = drs(0)
              End If
              '------------End Checking--------------------

              'Dim dr As DataRow = .NewRow
              dr("voi_vo") = Me.Id
              dr("voi_lineNumber") = i
              dr("voi_entity") = item.Entity.Id
              dr("voi_entityType") = item.ItemType.Value
              dr("voi_itemName") = item.EntityName
              dr("voi_unit") = item.Unit.Id
              dr("voi_qty") = item.Qty
              dr("voi_unitprice") = item.UnitPrice
              dr("voi_mat") = item.Mat
              dr("voi_lab") = item.Lab
              dr("voi_eq") = item.Eq
              dr("voi_amt") = item.Amount
              dr("voi_note") = item.Note
              dr("voi_refsequence") = refSequence
              dr("voi_sc") = Me.SC.Id
              dr("voi_unvatable") = item.UnVatable
              'dr("voi_parent") = item.ParentPath
              dr("voi_level") = item.Level
              dr("voi_status") = Me.Status.Value
              dr("voi_unitCost") = item.UnitCost
              '.Rows.Add(dr)

              Dim dr2 As DataRow = dtOld.NewRow
              dr2("voio_sequence") = dr("voi_sequence")
              If Me.Closed AndAlso Not Me.Closing Then '¡��ԡ�Դ SC
                dr2("voio_qty") = item.OldQty
                dr2("voio_mat") = item.OldMat
                dr2("voio_lab") = item.OldLab
                dr2("voio_eq") = item.OldEq
                dr2("voio_amt") = item.OldAmount
              ElseIf Not Me.Closed AndAlso Me.Closing Then '���ѧ�лԴ SC
                dr2("voio_qty") = item.OldQty
                dr2("voio_mat") = item.OldMat
                dr2("voio_lab") = item.OldLab
                dr2("voio_eq") = item.OldEq
                dr2("voio_amt") = item.OldAmount
              ElseIf Not Me.Closed AndAlso Not Me.Closing Then '�ѧ����»Դ ����ѧ���Դ �������Դ������
                dr2("voio_qty") = item.Qty
                dr2("voio_mat") = item.Mat
                dr2("voio_lab") = item.Lab
                dr2("voio_eq") = item.Eq
                dr2("voio_amt") = item.Amount
              End If
              dtOld.Rows.Add(dr2)

              If item.ItemType.Value <> 160 _
              AndAlso item.ItemType.Value <> 162 Then
                Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
                Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
                Dim currentSum As Decimal = wbsdColl.GetSumPercent
                For Each wbsd As WBSDistribute In wbsdColl
                  If currentSum < 100 AndAlso wbsd.WBS.Id = rootWBS.Id Then
                    '�ѧ������ 100 �����������
                    wbsd.Percent += (100 - currentSum)
                  End If
                  Dim bfTax As Decimal = 0
                  'If item.VO.Closed Then
                  '    bfTax = item.ReceivedBeforeTax
                  'Else
                  bfTax = item.CostAmount
                  'End If
                  currWBS = wbsd.WBS.Code & ":" & wbsd.WBS.Name
                  wbsd.BaseCost = bfTax
                  'wbsd.TransferBaseCost = bfTax
                  Dim childDr As DataRow = dtWbs.NewRow
                  childDr("voiw_wbs") = wbsd.WBS.Id
                  childDr("voiw_sequence") = dr("voi_sequence")
                  If wbsd.CostCenter Is Nothing Then
                    wbsd.CostCenter = Me.CostCenter
                  End If
                  childDr("voiw_cc") = wbsd.CostCenter.Id
                  childDr("voiw_percent") = wbsd.Percent
                  childDr("voiw_ismarkup") = wbsd.IsMarkup
                  childDr("voiw_direction") = 0        'in
                  childDr("voiw_baseCost") = wbsd.BaseCost
                  childDr("voiw_amt") = wbsd.Amount
                  childDr("voiw_cbs") = wbsd.CBS.Id
                  'childDr("voiw_toaccttype") = 3
                  'Add ��� voiwbs
                  dtWbs.Rows.Add(childDr)
                Next

                currentSum = wbsdColl.GetSumPercent
                '�ѧ������ 100 ����ѧ����� root
                If currentSum < 100 AndAlso Not rootWBS Is Nothing Then
                  Try
                    Dim newWbsd As New WBSDistribute
                    newWbsd.WBS = rootWBS
                    newWbsd.CostCenter = item.VO.CostCenter
                    newWbsd.Percent = 100 - currentSum
                    Dim bfTax As Decimal = 0
                    'If item.VO.Closed Then
                    '    bfTax = item.ReceivedBeforeTax
                    'Else
                    bfTax = item.CostAmount
                    'End If
                    newWbsd.BaseCost = bfTax
                    'newWbsd.TransferBaseCost = bfTax
                    Dim childDr As DataRow = dtWbs.NewRow
                    childDr("voiw_wbs") = newWbsd.WBS.Id
                    childDr("voiw_sequence") = dr("voi_sequence")
                    childDr("voiw_cc") = newWbsd.CostCenter.Id
                    childDr("voiw_percent") = newWbsd.Percent
                    childDr("voiw_ismarkup") = False
                    childDr("voiw_direction") = 0         'in
                    childDr("voiw_baseCost") = newWbsd.BaseCost
                    childDr("voiw_amt") = newWbsd.Amount
                    childDr("voiw_cbs") = newWbsd.CBS.Id
                    'childDr("voiw_toaccttype") = 3
                    'Add ��� voiwbs
                    dtWbs.Rows.Add(childDr)
                  Catch ex As Exception
                    Throw New Exception(ex.Message.ToString)
                  End Try
                End If
              End If
            End If
          Next
        End With

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated
        AddHandler daOld.RowUpdated, AddressOf daOld_MyRowUpdated

        daOld.Update(GetDeletedRows(dtOld))
        daWbs.Update(GetDeletedRows(dtWbs))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))
        daOld.Update(dtOld.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daOld.Update(dtOld.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True

        Return New SaveErrorException("1")

      Catch ex2 As ConstraintException
        Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.DupplicateWBS}"), New String() {currWBS})

      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Sub tmpDa_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      If e.StatementType = StatementType.Insert Then e.Status = UpdateStatus.SkipCurrentRow
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daWbs_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        Dim currentkey As Integer = CInt(e.Row("voiw_sequence")) '.GetParentRow("sequence")("sciw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!voiw_sequence = e.Row.GetParentRow("sequence")("voi_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!voiw_sequence = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Sub daOld_MyRowUpdated(ByVal sender As Object, ByVal e As System.Data.SqlClient.SqlRowUpdatedEventArgs)
      ' When the primary key propagates down to the child row's foreign key field, the field
      ' does not receive an OriginalValue with pseudo key value and a CurrentValue with the
      ' actual key value. Therefore, when the merge occurs, this row is  appended to the DataSet
      ' on the client tier, instead of being merged with the original row that was added.
      If e.StatementType = StatementType.Insert Then
        'Don't allow the AcceptChanges to occur on this row.
        e.Status = UpdateStatus.SkipCurrentRow
        ' Get the Current actual primary key value, so you can plug it back
        ' in after you get the correct original value that was generated for the child row.
        Dim currentkey As Integer = CInt(e.Row("voio_sequence")) '.GetParentRow("sequence")("voiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!voio_sequence = e.Row.GetParentRow("sequence2")("voi_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!voio_sequence = currentkey
      End If
      If e.StatementType = StatementType.Delete Then e.Status = UpdateStatus.SkipCurrentRow
    End Sub
    Private Function GetDeletedRows(ByVal dt As DataTable) As DataRow()
      Dim Rows() As DataRow
      If dt Is Nothing Then Return Rows
      Rows = dt.Select("", "", DataViewRowState.Deleted)
      If Rows.Length = 0 OrElse Not (Rows(0) Is Nothing) Then Return Rows
      '
      ' Workaround:
      ' With a remoted DataSet, Select returns the array elements
      ' filled with Nothing/null, instead of DataRow objects.
      '
      Dim r As DataRow, I As Integer = 0
      For Each r In dt.Rows
        If r.RowState = DataRowState.Deleted Then
          Rows(I) = r
          I += 1
        End If
      Next
      Return Rows
    End Function
    Private Function GetPritemString() As String
    End Function
    Private Function SavePRItemsDetail(ByVal arr As ArrayList, ByVal trans As SqlTransaction, ByVal conn As SqlConnection) As SaveErrorException
    End Function
#End Region

#Region "RefreshTaxBase"
    'Private m_taxGross As Decimal
    Public Sub RefreshTaxBase()
      m_gross = 0
      m_taxGross = 0
      m_taxBase = 0

      If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then
        Return
      End If

      Dim sumAmountWithVat As Decimal = 0
      For Each item As VOItem In Me.ItemCollection
        If item.Level = 1 Then
          m_gross += item.Amount
          If Not item.UnVatable Then
            m_taxGross += item.Amount
            sumAmountWithVat += item.Amount
          End If
        End If
      Next
      Select Case Me.TaxType.Value
        Case 0 '"�����"
          m_taxBase = 0
        Case 1 '"�¡"
          m_taxBase = sumAmountWithVat - Me.DiscountWithVat
        Case 2 '"���"
          Dim a As Decimal = Vat.GetExcludedVatAmount(sumAmountWithVat, Me.TaxRate)
          Dim b As Decimal = Vat.GetExcludedVatAmount(Me.DiscountWithVat, Me.TaxRate)
          m_taxBase = a - b
      End Select
    End Sub
    Public ReadOnly Property DiscountWithVat() As Decimal
      Get
        If Me.Gross = 0 Then
          Return 0
        End If
        Return Configuration.Format(Me.DiscountAmount * Me.TaxGross / Me.Gross, DigitConfig.Price)
      End Get
    End Property
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PO.dfm"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Me.RefreshTaxBase()
      'Code
      dpi = New DocPrintingItem
      dpi.Mapping = "Code"
      dpi.Value = Me.Code
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DocDate"
      dpi.Value = Me.DocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)


      If Not Me.SC Is Nothing Then

        'SCCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SCCode"
        dpi.Value = Me.SC.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SCDate
        dpi = New DocPrintingItem
        dpi.Mapping = "SCDate"
        dpi.Value = Me.SC.DocDate
        dpi.DataType = "System.DateTime"
        dpiColl.Add(dpi)

        If Not Me.SC.Director Is Nothing AndAlso Me.SC.Director.Originated Then
          'RequestorId
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorId"
          dpi.Value = Me.SC.Director.Id
          dpi.DataType = "System.String"
          dpi.SignatureType = SignatureType.Person
          dpiColl.Add(dpi)

          'RequestorInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorInfo"
          dpi.Value = Me.SC.Director.Code & ":" & Me.SC.Director.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RequestorCode
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorCode"
          dpi.Value = Me.SC.Director.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RequestorName
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorName"
          dpi.Value = Me.SC.Director.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        End If
      End If

      If Not Me.SubContractor Is Nothing AndAlso Me.SubContractor.Originated Then
        'SubcontractorInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "SubcontractorInfo"
        dpi.Value = Me.SubContractor.Code & ":" & Me.SubContractor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorCode"
        dpi.Value = Me.SubContractor.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorName
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorName"
        dpi.Value = Me.SubContractor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorAddredss
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorAddress"
        dpi.Value = Me.SubContractor.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorBillingAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorBillingAddress"
        dpi.Value = Me.SubContractor.BillingAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorPhone"
        dpi.Value = Me.SubContractor.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorFax
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorFax"
        dpi.Value = Me.SubContractor.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractoreMail
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractoreMail"
        dpi.Value = Me.SubContractor.EmailAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then
        'CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAddress"
        dpi.Value = Me.CostCenter.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Retention
      dpi = New DocPrintingItem
      dpi.Mapping = "Retention"
      dpi.Value = Configuration.FormatToString(Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AdvancePayAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvancePayAmount"
      dpi.Value = Configuration.FormatToString(Me.AdvancePay, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)
      '------------------�����͡���------------------------------
      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.RealGross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'DiscountRate
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountRate"
      dpi.Value = Me.Discount.Rate
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscountAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountAmount"
      dpi.Value = Configuration.FormatToString(Me.DiscountAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      dpi.Value = Configuration.FormatToString(Me.RealTaxAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      '�ѵ������
      'TaxRate
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxRate"
      dpi.Value = Configuration.FormatToString(Me.TaxRate, DigitConfig.Int)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'Mapping ���͹��ѵ� #917
      Dim appIdLevelHs1 As New Hashtable
      Dim appIdLevelHs2 As New Hashtable
      Dim appTable As DataTable = BusinessEntity.GetApprovePersonListfromDoc(Me.Id, Me.EntityId)
      If appTable.Rows.Count > 0 Then
        For Each row As DataRow In appTable.Rows
          Dim deh As New DataRowHelper(row)
          If Not appIdLevelHs1.ContainsKey(deh.GetValue(Of Integer)("apvdoc_level").ToString) Then
            appIdLevelHs1.Add(deh.GetValue(Of Integer)("apvdoc_level").ToString, row)
          Else
            appIdLevelHs1(deh.GetValue(Of Integer)("apvdoc_level").ToString) = row
          End If
        Next

        For Each row As DataRow In appIdLevelHs1.Values 'appTable.Rows
          Dim deh As New DataRowHelper(row)
          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonNameLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_name")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonCodeLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_code")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonInfoLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_name") & ":" & deh.GetValue(Of String)("user_code")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonDateLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of Date)("apvdate").ToShortDateString
          dpi.DataType = "System.DateTime"
          dpiColl.Add(dpi)
        Next

      End If

      Dim LastLevelApprove As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        'If ap.Level > 0 AndAlso Not ap.Reject Then
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso Not LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        For Each ap As ApproveDoc In LastLevelApprove
          If Not ap.Reject Then
            If Not appIdLevelHs2.ContainsKey(ap.Level.ToString) Then
              appIdLevelHs2.Add(ap.Level.ToString, ap)
            Else
              appIdLevelHs2(ap.Level.ToString) = ap
            End If
          End If
        Next
        For Each ap As ApproveDoc In appIdLevelHs2.Values 'LastLevelApprove
          If Not ap.Reject Then
            dpi = New DocPrintingItem
            dpi.Mapping = "ApprovePersonIdLevel " & ap.Level.ToString
            dpi.Value = ap.Originator
            dpi.DataType = "System.String"
            dpi.SignatureType = SignatureType.ApprovePerson
            dpiColl.Add(dpi)
          End If
        Next

        'Authorizeid
        dpi = New DocPrintingItem
        dpi.Mapping = "AuthorizeId"
        If Me.IsApproved Then
          dpi.Value = Me.ApprovePerson.Id
        Else
          dpi.Value = 0
        End If
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.AuthorizedPerson
        dpiColl.Add(dpi)
      End If

      dpiColl.AddRange(GetRealItemCollDocPrintingEntries)
      dpiColl.AddRange(GetRealParentCollDocPrintingEntries)
      dpiColl.AddRange(GetRealChildCollDocPrintingEntries)

      dpiColl.AddRange(GetItemCollDocPrintingEntries)
      dpiColl.AddRange(GetParentCollDocPrintingEntries)
      dpiColl.AddRange(GetChildCollDocPrintingEntries)
      Return dpiColl
    End Function
    Public Function GetRealItemCollDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      '------------------�����͡���------------------------------
      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font
      Dim indent As String = ""
      For Each item As VOItem In Me.ItemCollection
        line += 1
        If item.Level = 0 Then
          parentLine += 1
          childLine = 0
          fn = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          indent = Space(0)
        Else
          If item.ItemType.Value <> 162 Then
            childLine += 1
          End If
          fn = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          indent = Space(3)
        End If
        'Item.LineNumber
        '************** �����������ѹ��� 2
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.LineNumber"
        If item.Level = 0 Then
          dpi.Value = parentLine
        Else
          If item.ItemType.Value <> 162 Then
            dpi.Value = parentLine.ToString & "." & childLine.ToString
          End If
        End If
        dpi.Font = fn
        dpi.DataType = "System.string"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Code"
        dpi.Value = item.Entity.Code
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = indent & item.EntityName.Trim
        Else
          dpi.Value = indent & item.Entity.Name.Trim
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'If item.Level = 1 Then
        'Item.Unit
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Unit"
        dpi.Value = item.Unit.Name
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Qty"
        If item.OldQty = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldQty, DigitConfig.Qty)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)
        'End If

        'Item.UnitPrice
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.UnitPrice"
        If item.UnitPrice = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.TaxBase
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.TaxBase"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          If Me.TaxType.Value = 2 Then
            dpi.Value = Configuration.FormatToString(item.OldAmount * (100 / (Me.TaxRate + 100)), DigitConfig.Price)
          Else
            dpi.Value = Configuration.FormatToString(item.OldAmount, DigitConfig.Price)
          End If
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Amount"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldAmount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ReceivedAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ReceivedAmount"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.ReceivedAmount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Mat
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Mat"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldMat, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Lab
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Lab"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldLab, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Eq
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Eq"
        If item.OldAmount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.OldEq, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.Note"
        dpi.Value = item.Note
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ParentSummaryUnitPrice
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ParentSummaryUnitPrice"
        dpi.Value = Configuration.FormatToString(item.SummaryUnitPrice, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ParentSummaryUnitCost
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ParentSummaryUnitCost"
        dpi.Value = Configuration.FormatToString(item.SummaryUnitCost, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ParentSummaryAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ParentSummaryAmount"
        dpi.Value = Configuration.FormatToString(item.SummaryOldAmount, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ParentSummaryMat
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ParentSummaryMat"
        dpi.Value = Configuration.FormatToString(item.SummaryOldMat, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ParentSummaryLab
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ParentSummaryLab"
        dpi.Value = Configuration.FormatToString(item.SummaryOldLab, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ParentSummaryEq
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ParentSummaryEq"
        dpi.Value = Configuration.FormatToString(item.SummaryOldEq, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Item.ParentSummaryReceipt
        dpi = New DocPrintingItem
        dpi.Mapping = "RealItem.ParentSummaryReceipt"
        dpi.Value = Configuration.FormatToString(item.SummaryReceipt, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "RealItem"
        dpiColl.Add(dpi)

        'Ẻ����ʴ�����ҳ �Ҥ� ��Ť�� MAT LAB EQ Receipt �����¡����觨�ҧ =========================================================================
        If item.Level = 1 Then

          'Item.ChildUnitCode
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildUnitCode"
          If item.Unit Is Nothing Then
            dpi.Value = ""
          Else
            dpi.Value = item.Unit.Code
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildUnitName
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildUnitName"
          If item.Unit Is Nothing Then
            dpi.Value = ""
          Else
            dpi.Value = item.Unit.Name
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildQty
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildQty"
          If item.OldQty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldQty, DigitConfig.Qty)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildUnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildUnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildAmount"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)
          'End If

          'Item.ChildMat
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildMat"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldMat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildLab
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildLab"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldLab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildEq
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildEq"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldEq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

          'Item.ChildReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealItem.ChildReceivedAmount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceivedAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealItem"
          dpiColl.Add(dpi)

        End If
        'Ẻ����ʴ�����ҳ �Ҥ� ��Ť�� MAT LAB EQ Receipt �����¡����觨�ҧ =========================================================================

        i += 1
      Next
      Return dpiColl
    End Function
    Public Function GetRealParentCollDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      '------------------�����͡���------------------------------
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As VOItem In Me.ItemCollection
        If item.Level = 0 Then

          'Item.LineNumber
          '************** �����������ѹ��� 2
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.LineNumber"
          dpi.Value = i + 1
          dpi.Font = fn
          dpi.DataType = "System.string"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.Code
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Code"
          dpi.Value = item.Entity.Code
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Name"
          If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
            dpi.Value = indent & item.EntityName.Trim
          Else
            dpi.Value = indent & item.Entity.Name.Trim
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.Note"
          dpi.Value = item.Note
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryUnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.ParentSummaryUnitPrice"
          dpi.Value = Configuration.FormatToString(item.SummaryUnitPrice, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryUnitCost
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.ParentSummaryUnitCost"
          dpi.Value = Configuration.FormatToString(item.SummaryUnitCost, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.ParentSummaryAmount"
          dpi.Value = Configuration.FormatToString(item.SummaryOldAmount, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryMat
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.ParentSummaryMat"
          dpi.Value = Configuration.FormatToString(item.SummaryOldMat, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryLab
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.ParentSummaryLab"
          dpi.Value = Configuration.FormatToString(item.SummaryOldLab, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryEq
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.ParentSummaryEq"
          dpi.Value = Configuration.FormatToString(item.SummaryOldEq, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryReceipt
          dpi = New DocPrintingItem
          dpi.Mapping = "RealParentItem.ParentSummaryReceipt"
          dpi.Value = Configuration.FormatToString(item.SummaryReceipt, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealParentItem"
          dpiColl.Add(dpi)

          i += 1
        End If
      Next
      Return dpiColl
    End Function
    Public Function GetRealChildCollDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      '------------------�����͡���------------------------------
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As VOItem In Me.ItemCollection
        If item.Level = 1 Then

          'Item.LineNumber
          '************** �����������ѹ��� 2
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.LineNumber"
          dpi.Value = i + 1
          dpi.Font = fn
          dpi.DataType = "System.string"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.Code
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Code"
          dpi.Value = item.Entity.Code
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Name"
          If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
            dpi.Value = indent & item.EntityName.Trim
          Else
            dpi.Value = indent & item.Entity.Name.Trim
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Unit"
          dpi.Value = item.Unit.Name
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Qty"
          If item.OldQty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldQty, DigitConfig.Qty)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Amount"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.ReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.ReceivedAmount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceivedAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.Mat
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Mat"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldMat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.Lab
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Lab"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldLab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.Eq
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Eq"
          If item.OldAmount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.OldEq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          'Item.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "RealChildItem.Note"
          dpi.Value = item.Note
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "RealChildItem"
          dpiColl.Add(dpi)

          i += 1
        End If
      Next
      Return dpiColl
    End Function

    Public Function GetItemCollDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      '------------------�����͡���------------------------------
      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font
      Dim indent As String = ""
      For Each item As VOItem In Me.ItemCollection
        line += 1
        If item.Level = 0 Then
          parentLine += 1
          childLine = 0
          fn = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          indent = Space(0)
        Else
          If item.ItemType.Value <> 162 Then
            childLine += 1
          End If
          fn = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          indent = Space(3)
        End If
        'Item.LineNumber
        '************** �����������ѹ��� 2
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        If item.Level = 0 Then
          dpi.Value = parentLine
        Else
          If item.ItemType.Value <> 162 Then
            dpi.Value = parentLine.ToString & "." & childLine.ToString
          End If
        End If
        dpi.Font = fn
        dpi.DataType = "System.string"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = indent & item.EntityName.Trim
        Else
          dpi.Value = indent & item.Entity.Name.Trim
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        If item.Level = 1 Then
          '--------------------- WBS Section ------------------
          Dim WBSCostCenter As String = ""
          Dim WBSCode As String = ""
          Dim WBSName As String = ""
          Dim WBSCodePercent As String = ""
          Dim WBSCodeAmount As String = ""
          Dim WBSRemainAmount As String = ""
          Dim WBSRemainQty As String = ""

          Dim hashWBS As New Hashtable
          Dim hashWBSItem As New Hashtable
          Dim key As String = ""
          Dim itemKey As String = ""

          If item.WBSDistributeCollection.Count > 0 Then
            'Populate ���ӹǳ�������Ẻ��͡�
            'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)


            If item.WBSDistributeCollection.Count = 1 Then

              key = item.WBSDistributeCollection.Item(0).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Id.ToString & ":" & item.AllocationType
              itemKey = item.WBSDistributeCollection.Item(0).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Id.ToString & ":" & item.Description & ":" & item.AllocationType

              'Amount -----------------------------------------------------
              If Not hashWBS.Contains(key) Then
                item.WBSDistributeCollection.Item(0).RemainSummary = item.WBSDistributeCollection.Item(0).BudgetRemain - (item.WBSDistributeCollection.Item(0).Amount + item.WBSDistributeCollection.Item(0).ChildAmount)
                hashWBS(key) = item.WBSDistributeCollection.Item(0)
              Else
                Dim parWBS As WBSDistribute = CType(hashWBS(key), WBSDistribute)
                item.WBSDistributeCollection.Item(0).RemainSummary = parWBS.RemainSummary - (item.WBSDistributeCollection.Item(0).Amount + item.WBSDistributeCollection.Item(0).ChildAmount)
                CType(hashWBS(key), WBSDistribute).RemainSummary = item.WBSDistributeCollection.Item(0).RemainSummary
              End If
              'Qty --------------------------------------------------------
              If Not hashWBSItem.Contains(itemKey) Then
                item.WBSDistributeCollection.Item(0).QtyRemainSummary = item.WBSDistributeCollection.Item(0).QtyRemain - item.WBSDistributeCollection.Item(0).Qty
                hashWBSItem(itemKey) = item.WBSDistributeCollection.Item(0)
              Else
                Dim parWBS As WBSDistribute = CType(hashWBSItem(itemKey), WBSDistribute)
                item.WBSDistributeCollection.Item(0).QtyRemainSummary = parWBS.QtyRemainSummary - item.WBSDistributeCollection.Item(0).Qty
                CType(hashWBSItem(itemKey), WBSDistribute).QtyRemainSummary = item.WBSDistributeCollection.Item(0).QtyRemainSummary
              End If

              WBSCostCenter = item.WBSDistributeCollection.Item(0).CostCenter.Code & ":" & _
              item.WBSDistributeCollection.Item(0).CostCenter.Name 'Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
              WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
              WBSName = item.WBSDistributeCollection.Item(0).WBS.Name
              WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%"
              WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price)
              WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
              WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
            Else
              Dim j As Integer
              For j = 0 To item.WBSDistributeCollection.Count - 1

                key = item.WBSDistributeCollection.Item(j).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(j).CostCenter.Id.ToString & ":" & item.AllocationType
                itemKey = item.WBSDistributeCollection.Item(j).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(j).CostCenter.Id.ToString & ":" & item.Description & ":" & item.AllocationType

                'Amount -----------------------------------------------------
                If Not hashWBS.Contains(key) Then
                  item.WBSDistributeCollection.Item(j).RemainSummary = item.WBSDistributeCollection.Item(j).BudgetRemain - (item.WBSDistributeCollection.Item(j).Amount + item.WBSDistributeCollection.Item(j).ChildAmount)
                  hashWBS(key) = item.WBSDistributeCollection.Item(j)
                Else
                  Dim parWBS As WBSDistribute = CType(hashWBS(key), WBSDistribute)
                  item.WBSDistributeCollection.Item(j).RemainSummary = parWBS.RemainSummary - (item.WBSDistributeCollection.Item(j).Amount + item.WBSDistributeCollection.Item(j).ChildAmount)
                  CType(hashWBS(key), WBSDistribute).RemainSummary = item.WBSDistributeCollection.Item(j).RemainSummary
                End If
                'Qty --------------------------------------------------------
                If Not hashWBSItem.Contains(itemKey) Then
                  item.WBSDistributeCollection.Item(j).QtyRemainSummary = item.WBSDistributeCollection.Item(j).QtyRemain - item.WBSDistributeCollection.Item(j).Qty
                  hashWBSItem(itemKey) = item.WBSDistributeCollection.Item(j)
                Else
                  Dim parWBS As WBSDistribute = CType(hashWBSItem(itemKey), WBSDistribute)
                  item.WBSDistributeCollection.Item(j).QtyRemainSummary = parWBS.QtyRemainSummary - item.WBSDistributeCollection.Item(j).Qty
                  CType(hashWBSItem(itemKey), WBSDistribute).QtyRemainSummary = item.WBSDistributeCollection.Item(j).QtyRemainSummary
                End If

                WBSCostCenter &= item.WBSDistributeCollection.Item(j).CostCenter.Code & ":" & _
                item.WBSDistributeCollection.Item(j).CostCenter.Name ' & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
                WBSCode &= item.WBSDistributeCollection.Item(j).WBS.Code
                WBSName &= item.WBSDistributeCollection.Item(j).WBS.Name
                WBSCodePercent &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Percent, DigitConfig.Price)
                WBSCodeAmount &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Amount, DigitConfig.Price)
                WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).RemainSummary, DigitConfig.Price)
                WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).QtyRemainSummary, DigitConfig.Price)
                If j < item.WBSDistributeCollection.Count - 1 Then
                  WBSCostCenter &= ", "
                  'WBSCostCentern &= ", "
                  WBSCode &= ", "
                  WBSName &= ", "
                  WBSCodePercent &= ", "
                  WBSCodeAmount &= ", "
                  WBSRemainAmount &= ", "
                  WBSRemainQty &= ", "
                End If
              Next
            End If
          End If

          'Item.WBSCostCenter
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCostCenter"
          dpi.Value = WBSCostCenter
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.WBSCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCode"
          dpi.Value = WBSCode
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.WBSName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSName"
          dpi.Value = WBSName
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.WBSCodePercent
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodePercent"
          dpi.Value = WBSCodePercent
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.WBSCodeAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodeAmount"
          dpi.Value = WBSCodeAmount
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.WBSRemainAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainAmount"
          dpi.Value = WBSRemainAmount
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.WBSRemainQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainQty"
          dpi.Value = WBSRemainQty
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
          '--------------------- WBS Section ------------------
        End If

        'If item.Level = 1 Then
        'Item.Unit
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Unit"
        dpi.Value = item.Unit.Name
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty"
        If item.Qty = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)
        'End If

        'Item.UnitPrice
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UnitPrice"
        If item.UnitPrice = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.TaxBase
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.TaxBase"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          If Me.TaxType.Value = 2 Then
            dpi.Value = Configuration.FormatToString(item.Amount * (100 / (Me.TaxRate + 100)), DigitConfig.Price)
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Amount"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ReceivedAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ReceivedAmount"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.ReceivedAmount, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Mat
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Mat"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Lab
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Lab"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Lab, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Eq
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Eq"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Eq, DigitConfig.Price)
        End If
        dpi.Font = fn
        dpi.DataType = "System.Decimal"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ParentSummaryUnitPrice
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ParentSummaryUnitPrice"
        dpi.Value = Configuration.FormatToString(item.SummaryUnitPrice, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ParentSummaryUnitCost
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ParentSummaryUnitCost"
        dpi.Value = Configuration.FormatToString(item.SummaryUnitCost, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ParentSummaryAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ParentSummaryAmount"
        dpi.Value = Configuration.FormatToString(item.SummaryAmount, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ParentSummaryMat
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ParentSummaryMat"
        dpi.Value = Configuration.FormatToString(item.SummaryMat, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ParentSummaryLab
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ParentSummaryLab"
        dpi.Value = Configuration.FormatToString(item.SummaryLab, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ParentSummaryEq
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ParentSummaryEq"
        dpi.Value = Configuration.FormatToString(item.SummaryEq, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.ParentSummaryReceipt
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.ParentSummaryReceipt"
        dpi.Value = Configuration.FormatToString(item.SummaryReceipt, DigitConfig.Price)
        dpi.Font = fn
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Ẻ����ʴ�����ҳ �Ҥ� ��Ť�� MAT LAB EQ Receipt �����¡����觨�ҧ =========================================================================
        If item.Level = 1 Then

          'Item.ChildUnitCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildUnitCode"
          If item.Unit Is Nothing Then
            dpi.Value = ""
          Else
            dpi.Value = item.Unit.Code
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildUnitName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildUnitName"
          If item.Unit Is Nothing Then
            dpi.Value = ""
          Else
            dpi.Value = item.Unit.Name
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildQty"
          If item.Qty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildUnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildUnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildAmount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
          'End If

          'Item.ChildMat
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildMat"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildLab
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildLab"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Lab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildEq
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildEq"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Eq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          'Item.ChildReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ChildReceivedAmount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceivedAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

        End If
        'Ẻ����ʴ�����ҳ �Ҥ� ��Ť�� MAT LAB EQ Receipt �����¡����觨�ҧ =========================================================================

        i += 1
      Next
      Return dpiColl
    End Function
    Public Function GetParentCollDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      '------------------�����͡���------------------------------
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As VOItem In Me.ItemCollection
        If item.Level = 0 Then

          'Item.LineNumber
          '************** �����������ѹ��� 2
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.LineNumber"
          dpi.Value = i + 1
          dpi.Font = fn
          dpi.DataType = "System.string"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.Code
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Code"
          dpi.Value = item.Entity.Code
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Name"
          If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
            dpi.Value = indent & item.EntityName.Trim
          Else
            dpi.Value = indent & item.Entity.Name.Trim
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.Note"
          dpi.Value = item.Note
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryUnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.ParentSummaryUnitPrice"
          dpi.Value = Configuration.FormatToString(item.SummaryUnitPrice, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryUnitCost
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.ParentSummaryUnitCost"
          dpi.Value = Configuration.FormatToString(item.SummaryUnitCost, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.ParentSummaryAmount"
          dpi.Value = Configuration.FormatToString(item.SummaryAmount, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryMat
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.ParentSummaryMat"
          dpi.Value = Configuration.FormatToString(item.SummaryMat, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryLab
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.ParentSummaryLab"
          dpi.Value = Configuration.FormatToString(item.SummaryLab, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryEq
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.ParentSummaryEq"
          dpi.Value = Configuration.FormatToString(item.SummaryEq, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          'Item.ParentSummaryReceipt
          dpi = New DocPrintingItem
          dpi.Mapping = "ParentItem.ParentSummaryReceipt"
          dpi.Value = Configuration.FormatToString(item.SummaryReceipt, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ParentItem"
          dpiColl.Add(dpi)

          i += 1
        End If
      Next
      Return dpiColl
    End Function
    Public Function GetChildCollDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      '------------------�����͡���------------------------------
      Dim counter As Integer = 0
      Dim i As Integer = 0
      Dim parentLine As Integer = 0
      Dim childLine As Integer = 0
      Dim fn As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""
      For Each item As VOItem In Me.ItemCollection
        If item.Level = 1 Then

          'Item.LineNumber
          '************** �����������ѹ��� 2
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.LineNumber"
          dpi.Value = i + 1
          dpi.Font = fn
          dpi.DataType = "System.string"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.Code
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Code"
          dpi.Value = item.Entity.Code
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.Name
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Name"
          If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
            dpi.Value = indent & item.EntityName.Trim
          Else
            dpi.Value = indent & item.Entity.Name.Trim
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.Unit
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Unit"
          dpi.Value = item.Unit.Name
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.Qty
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Qty"
          If item.Qty = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.UnitPrice
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.UnitPrice"
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Amount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.ReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.ReceivedAmount"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.ReceivedAmount, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.Mat
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Mat"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.Lab
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Lab"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Lab, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.Eq
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Eq"
          If item.Amount = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.Eq, DigitConfig.Price)
          End If
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          'Item.Note
          dpi = New DocPrintingItem
          dpi.Mapping = "ChildItem.Note"
          dpi.Value = item.Note
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "ChildItem"
          dpiColl.Add(dpi)

          i += 1
        End If
      Next
      Return dpiColl
    End Function

#End Region

#Region " IApprovAble "
    Public Function ApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.ApproveData
      '����¹��� Trigger ᷹
      Return New SaveErrorException("0")

      With Me
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", DocID))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approveperson", currentUserId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approvedate", theTime))

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        ' ��� Transaction �Ǻ��������ǹ�ͧ Client �����Ҩ������ loop ��
        Try
          SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Approve" & Me.TableName, sqlparams)
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
    'Dim m As CostCenter
    'Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
    '  Get
    '    Return m 'Me.CostCenter
    '  End Get
    '  Set(ByVal Value As CostCenter)
    '    Me.m = Value
    '  End Set
    'End Property
    Public ReadOnly Property IsApproved() As Boolean Implements IApprovAble.IsApproved
      Get
        If Not (Me.ApprovePerson Is Nothing) AndAlso Me.ApprovePerson.Originated Then
          Return True
        End If
        Return False
      End Get
    End Property

    Public ReadOnly Property ApproveIcon() As String Implements IApprovAble.ApproveIcon
      Get
        Return "Icons.16x16.Approve"
      End Get
    End Property

    Public ReadOnly Property ShowUnApproveButton() As Boolean Implements IApprovAble.ShowUnApproveButton
      Get
        Return Not (Me.Status.Value = 0 OrElse Me.IsClosed)
      End Get
    End Property

    Public Function UnApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.UnApproveData

    End Function

    Public ReadOnly Property UnApproveIcon() As String Implements IApprovAble.UnApproveIcon
      Get

      End Get
    End Property

    Public ReadOnly Property IsClosed As Boolean
      Get
        Dim ds As DataSet _
          = SqlHelper.ExecuteDataset(Me.ConnectionString, _
            CommandType.Text, _
            "select isnull(vo_closed,0) from vo where vo_id=" & Me.Id)
        If ds.Tables(0).Rows.Count > 0 Then
          If CInt(ds.Tables(0).Rows(0)(0)) = 1 OrElse CBool(ds.Tables(0).Rows(0)(0)) Then
            Return True
          End If
        End If
        Return False
      End Get
    End Property
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.Status.Value <= 2 AndAlso Not Me.IsReferenced
        Else
          Return False
        End If
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      'If Me.SC.Status.Value = 0 OrElse Me.SC.Closed Then
      '  Return New SaveErrorException("${res:Global.Error.CanceledSC}", New String() {Me.SC.Code})
      'End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePO}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        For Each extender As Object In Me.Extenders
          If TypeOf extender Is IExtender Then
            Dim delDocError As SaveErrorException = CType(extender, IExtender).Delete(conn, trans)
            If Not IsNumeric(delDocError.Message) Then
              trans.Rollback()
              Return delDocError
            Else
              Select Case CInt(delDocError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Return delDocError
                Case Else
              End Select
            End If
          End If
        Next

        'Update PROrderedQty
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePROrderedQtyDeletePO" _
        ', New SqlParameter("@po_id", Me.Id))

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteVO", New SqlParameter() {New SqlParameter("@vo_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.POIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePRWBSActual")
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdatePOWBSActual")

        Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId)
        mldoc.DocMethod = SaveDocMultiApprovalMethod.Delete
        Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, trans)
        If Not IsNumeric(savemldocError.Message) Then
          trans.Rollback()
          Return savemldocError
        End If

        trans.Commit()

        Try
          Parallel.Invoke(Sub()
                            WBSActual.SummaryPOWBSActual(conn)
                          End Sub,
                          Sub()
                            WBSActual.SummarySCWBSActual(conn)
                          End Sub,
                          Sub()
                            WBSActual.SummaryVOWBSActual(conn)
                          End Sub,
                          Sub()
                            WBSActual.SummaryPOAdjWBSActual(conn)
                          End Sub,
                          Sub()
                            WBSActual.SummaryDRWBSActual(conn)
                          End Sub
               )
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try

        Try
          Dim subsaveerror As SaveErrorException = WBSActual.SummaryChildActual(conn, "po")
          If Not IsNumeric(subsaveerror.Message) Then
            Return New SaveErrorException(" Save Incomplete Please Save Again (2)")
          End If
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try

        Return New SaveErrorException("1")
      Catch ex As SqlException
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Finally
        conn.Close()
      End Try
    End Function
#End Region

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable
        'Return True
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region



#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      '���� Copy ������ CustomNote �ҡ�ѹ�Ѩ�غѹ��������͹
      Me.m_customNoteColl = New CustomNoteCollection(Me)

      Me.Status.Value = -1
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Code = "Copy of " & Me.Code
      Me.ApproveDate = Date.MinValue
            Me.ApprovePerson = New User
            Me.ApproveDocColl = Nothing
      Me.Canceled = False
      Me.CancelPerson = New User
      Me.Closing = False
      Me.Closed = False
      Me.ClearReference()
      Dim wbsdummy As WBS
      For Each item As VOItem In Me.ItemCollection
        If item.ItemType.Value <> 160 Or item.ItemType.Value <> 162 Then
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsdummy = wbsd.WBS
            wbsd.WBS = wbsdummy
          Next
        End If
      Next
      Return Me
    End Function
#End Region

#Region "IWBSAllocatable"
    Public Property FromCostCenter() As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get

      End Get
      Set(ByVal Value As CostCenter)

      End Set
    End Property

    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As VOItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0
              wbsd.GetChildIdList()
              For Each allItem As VOItem In Me.ItemCollection
                For Each childWbsd As WBSDistribute In allItem.WBSDistributeCollection
                  If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                    wbsd.ChildAmount += childWbsd.Amount
                  End If
                Next
              Next
            Next
          End If

          coll.Add(item)
        End If
      Next
      Return coll
    End Function
    Public ReadOnly Property AllowWBSAllocateFrom As Boolean Implements IWBSAllocatable.AllowWBSAllocateFrom
      Get
        Return False
      End Get
    End Property
    Public ReadOnly Property AllowWBSAllocateTo As Boolean Implements IWBSAllocatable.AllowWBSAllocateTo
      Get
        Return True
      End Get
    End Property
#End Region

#Region "IApproveStatusAble"
    Public ReadOnly Property IsAuthorized As Boolean Implements IApproveStatusAble.IsAuthorized
      Get
        Return Me.IsApproved
      End Get
    End Property

    Public ReadOnly Property IsLevelApproved As Boolean Implements IApproveStatusAble.IsLevelApproved
      Get
        If Not Me.ApproveDocColl Is Nothing AndAlso Me.ApproveDocColl.Count > 0 Then
          Dim approveDoc As ApproveDoc = m_approveDocColl(ApproveDocColl.Count - 1)
          If Not approveDoc Is Nothing Then
            If Not approveDoc.Reject AndAlso approveDoc.Level > 0 Then
              Return True
            End If
          End If
        End If

        Return False
      End Get
    End Property

    Public ReadOnly Property IsReject As Boolean Implements IApproveStatusAble.IsReject
      Get
        If Not Me.ApproveDocColl Is Nothing AndAlso Me.ApproveDocColl.Count > 0 Then
          Dim approveDoc As ApproveDoc = m_approveDocColl(ApproveDocColl.Count - 1)
          If Not approveDoc Is Nothing Then
            Return approveDoc.Reject
          End If
        End If

        Return False
      End Get
    End Property
#End Region

#Region "IDocStatus"
    Public ReadOnly Property DocStatus As String Implements IDocStatus.DocStatus
      Get
        If Me.Status.Value = 0 Then
          Return "Canceled"
        Else
          Dim obj As Object = Configuration.GetConfig("ApproveSC")
          If CBool(obj) Then
            If Me.IsAuthorized Then
              Return "Authorized"
            ElseIf Me.IsLevelApproved Then
              Return "Approved"
            ElseIf Me.IsReject Then
              Return "Reject"
            End If
          End If
        End If
        Return ""
      End Get
    End Property
#End Region

#Region "IDocumentPersonAble"

    ReadOnly Property DocumentEditedUser As DocumentEditedUser Implements IDocumentPersonAble.DocumentEditedUser
      Get
        Dim m_documentEditedUser As New DocumentEditedUser

        m_documentEditedUser.ApprovedUserList = Me.GetApprovedUserList
        m_documentEditedUser.ApprovedUser = Me.GetApprovedUser
        m_documentEditedUser.AuthorizedUser = Me.GetAutherizedUser
        m_documentEditedUser.CanceledUser = Me.GetCanceledUser
        m_documentEditedUser.CreatedUser = Me.GetCreatedUser
        m_documentEditedUser.EditedUser = Me.GetEditedUser
        m_documentEditedUser.EditedUser = Me.GetRejectUser
        If Not Me.SC Is Nothing AndAlso Not Me.SC.Director Is Nothing Then
          m_documentEditedUser.Employee = Me.SC.Director
        Else
          m_documentEditedUser.Employee = New Employee
        End If

        Return m_documentEditedUser
      End Get
    End Property

    Private Function GetApprovedUserList() As List(Of ApproveDoc)
      Dim LastLevelApprove As New List(Of ApproveDoc)
      Dim aProvePerson As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso Not LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        For Each ap As ApproveDoc In LastLevelApprove
          If Not ap.Reject Then
            aProvePerson.Add(ap)
          End If
        Next
      End If

      Return aProvePerson
    End Function

    Public Function GetApprovedUser() As EditedUser
      Dim aplist As List(Of ApproveDoc) = Me.GetApprovedUserList
      Dim editeduser As New EditedUser
      If aplist.Count > 1 Then
        Dim userHs As New Hashtable
        Dim maxLevel As Integer = 0
        For Each doc As ApproveDoc In aplist
          userHs(doc.Level) = doc
          maxLevel = Math.Max(maxLevel, doc.Level)
        Next
        'Return New User(CType(userHs(maxLevel - 1), ApproveDoc).Originator)
        If Not userHs(maxLevel - 1) Is Nothing Then
          editeduser.UserId = CType(userHs(maxLevel - 1), ApproveDoc).Originator
          editeduser.UserName = New User(CType(userHs(maxLevel - 1), ApproveDoc).Originator).Name
          editeduser.EditedDate = CType(userHs(maxLevel - 1), ApproveDoc).OriginDate
          Return editeduser
        End If

      End If
      If aplist.Count > 0 Then
        'Return New User(aplist.Item(aplist.Count - 1).Originator)
        editeduser.UserId = aplist.Item(aplist.Count - 1).Originator
        editeduser.UserName = New User(aplist.Item(aplist.Count - 1).Originator).Name
        editeduser.EditedDate = aplist.Item(aplist.Count - 1).OriginDate
      End If
      Return editeduser
    End Function

    Public Function GetAutherizedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Me.ApprovePerson Is Nothing Then
        editeduser.UserId = Me.ApprovePerson.Id
        editeduser.UserName = Me.ApprovePerson.Name
        editeduser.EditedDate = Me.ApproveDate
      End If
      Return editeduser
    End Function

    Public Function GetCanceledUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Me.CancelPerson Is Nothing Then
        editeduser.UserId = Me.CancelPerson.Id
        editeduser.UserName = Me.CancelPerson.Name
        editeduser.EditedDate = Me.CancelDate
      End If
      Return editeduser
    End Function

    Public Function GetCreatedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Originator Is Nothing Then
        editeduser.UserId = Me.Originator.Id
        editeduser.UserName = Me.Originator.Name
        editeduser.EditedDate = Me.OriginDate
      End If
      Return editeduser
    End Function

    Public Function GetEditedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not LastEditor Is Nothing Then
        editeduser.UserId = Me.LastEditor.Id
        editeduser.UserName = Me.LastEditor.Name
        editeduser.EditedDate = Me.LastEditDate
      End If
      Return editeduser
    End Function

    Public Function GetRejectUser() As EditedUser
      Dim editeduser As New EditedUser
      Dim LastLevelApprove As New List(Of ApproveDoc)
      Dim aProvePerson As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        editeduser.UserId = LastLevelApprove.Item(LastLevelApprove.Count - 1).Originator
        editeduser.UserName = New User(LastLevelApprove.Item(LastLevelApprove.Count - 1).Originator).Name
        editeduser.EditedDate = LastLevelApprove.Item(LastLevelApprove.Count - 1).OriginDate
      End If
      Return editeduser
    End Function

#End Region
  End Class


  Public Class VOStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "vo_status"
      End Get
    End Property
#End Region

  End Class

  Public Class VOForApprove
    Inherits VO
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "VOForApprove"
      End Get
    End Property
  End Class
End Namespace
