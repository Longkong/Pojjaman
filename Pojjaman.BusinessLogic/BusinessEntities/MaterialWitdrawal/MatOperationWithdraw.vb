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
  Public Class MatOperationWithdrawType
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "MatOperationWithdraw_type"
      End Get
    End Property
#End Region

  End Class
  Public Class MatOperationWithdraw
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IPrintableEntity, IHasToCostCenter, IHasFromCostCenter, ICancelable, ICheckPeriod, IWBSAllocatable _
      , INewGLAble, INewPrintableEntity, IDocStatus, IAbleValidateItemQuantity

#Region "Members"
    Private m_docDate As Date
    Private m_olddocDate As Date
    Private m_note As String

    'Private m_costCenter As CostCenter
    Private m_CostCenter As CostCenter
    'Private m_toCostCenter As CostCenter
    Private m_CostCenterPerson As Employee
    Private m_toCostCenterPerson As Employee
    Private m_asset As Asset
    Private m_type As MatOperationWithdrawType
    Private m_diffAmountFIFO As Decimal
    Private m_isinitialized As Boolean

    Private m_je As JournalEntry

    Private m_grouping As Boolean

    Private m_itemCollection As MatOperationWithdrawItemCollection
    Private m_oldActualDataSet As DataSet

    Public MatActualHashIn As Hashtable
    Public MatActualHashOut As Hashtable
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
        .m_docDate = Now.Date
        .m_olddocDate = Now.Date
        '.m_costCenter = New CostCenter
        .m_CostCenter = New CostCenter
        .m_CostCenterPerson = New Employee
        '.m_toCostCenter = New CostCenter
        .m_toCostCenterPerson = New Employee
        .m_asset = New Asset
        .m_type = New MatOperationWithdrawType(1)
        .Status = New StockStatus(-1)
        .m_note = ""
        .m_grouping = True

        '----------------------------Tab Entities-----------------------------------------

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        '----------------------------End Tab Entities-----------------------------------------
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      m_itemCollection = New MatOperationWithdrawItemCollection(Me, m_grouping)
      m_oldActualDataSet = New DataSet
      MatActualHashIn = New Hashtable
      MatActualHashOut = New Hashtable
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        'If dr.Table.Columns.Contains(aliasPrefix & "costcenter.cc_id") Then
        '  If Not dr.IsNull(aliasPrefix & "costcenter.cc_id") Then
        '    .m_costCenter = New CostCenter(dr, "costcenter.")
        '  End If
        'Else
        '  If Not dr.IsNull(aliasPrefix & "stock_cc") Then
        '    .m_costCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_cc")))
        '  End If
        'End If

        'If dr.Table.Columns.Contains(aliasPrefix & "tocostcenter.cc_id") Then
        '  If Not dr.IsNull(aliasPrefix & "tocostcenter.cc_id") Then
        '    .m_toCostCenter = New CostCenter(dr, "tocostcenter.")
        '  End If
        'Else
        '  If dr.Table.Columns.Contains("stock_tocc") AndAlso Not dr.IsNull(aliasPrefix & "stock_tocc") Then
        '    .m_toCostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_tocc")))
        '  End If
        'End If

        If dr.Table.Columns.Contains(aliasPrefix & "fromcostcenter.cc_id") Then
          If Not dr.IsNull(aliasPrefix & "fromcostcenter.cc_id") Then
            .m_CostCenter = New CostCenter(dr, "fromcostcenter.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_fromcc") AndAlso Not dr.IsNull(aliasPrefix & "stock_fromcc") Then
            .m_CostCenter = CostCenter.GetCCMinDataById(CInt(dr(aliasPrefix & "stock_fromcc")))
            '.m_CostCenter = New CostCenter(CInt(dr(aliasPrefix & "stock_fromcc")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "fromcostcenterperson.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "fromcostcenterperson.employee_id") Then
            .m_CostCenterPerson = New Employee(dr, "fromcostcenterperson.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_fromccperson") AndAlso Not dr.IsNull(aliasPrefix & "stock_fromccperson") Then
            .m_CostCenterPerson = Employee.GetEmployeeById(CInt(dr(aliasPrefix & "stock_fromccperson")))
            '.m_CostCenterPerson = New Employee(CInt(dr(aliasPrefix & "stock_fromccperson")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "tocostcenterperson.employee_id") Then
          If Not dr.IsNull(aliasPrefix & "tocostcenterperson.employee_id") Then
            .m_toCostCenterPerson = New Employee(dr, "tocostcenterperson.")
          End If
        Else
          If dr.Table.Columns.Contains("stock_toccperson") AndAlso Not dr.IsNull(aliasPrefix & "stock_toccperson") Then
            .m_toCostCenterPerson = Employee.GetEmployeeById(CInt(dr(aliasPrefix & "stock_toccperson")))
            '.m_toCostCenterPerson = New Employee(CInt(dr(aliasPrefix & "stock_toccperson")))
          End If
        End If


        If dr.Table.Columns.Contains(aliasPrefix & "stock_tag") AndAlso Not dr.IsNull(aliasPrefix & "stock_tag") Then
          Me.m_type.Value = CInt(dr(aliasPrefix & "stock_tag"))
        End If

        If dr.Table.Columns.Contains("stock_docDate") AndAlso Not dr.IsNull(aliasPrefix & "stock_docDate") Then
          .m_docDate = CDate(dr(aliasPrefix & "stock_docDate"))
          .m_olddocDate = CDate(dr(aliasPrefix & "stock_docDate"))
        End If

        If dr.Table.Columns.Contains("stock_note") AndAlso Not dr.IsNull(aliasPrefix & "stock_note") Then
          .m_note = CStr(dr(aliasPrefix & "stock_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") _
        AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .Status = New StockStatus(CInt(dr(aliasPrefix & Me.Prefix & "_status")))
        End If


        If dr.Table.Columns.Contains(aliasPrefix & "_asset") Then
          If Not dr.IsNull(aliasPrefix & "_asset") Then
            .m_asset = New Asset(CInt(dr(aliasPrefix & "_asset")))
          End If
        Else
          If dr.Table.Columns.Contains("stock_asset") AndAlso Not dr.IsNull("stock_asset") Then
            .m_asset = New Asset(CInt(dr("stock_asset")))
          End If
        End If
        If dr.Table.Columns.Contains("stock_diffAmt") AndAlso Not dr.IsNull(aliasPrefix & "stock_diffAmt") Then
          .m_diffAmountFIFO = CDec(dr(aliasPrefix & "stock_diffAmt"))
        End If

        m_je = New JournalEntry(Me)

        m_itemCollection = New MatOperationWithdrawItemCollection(Me, m_grouping)
        m_oldActualDataSet = Me.GetOldMatOperationWithdrawWBSActual
        MatActualHashIn = New Hashtable
        MatActualHashOut = New Hashtable
      End With
      Me.AutoCodeFormat = New AutoCodeFormat(Me)
    End Sub
#End Region

#Region "Properties"
    Public Property ItemCollection() As MatOperationWithdrawItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As MatOperationWithdrawItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property DocDate() As Date Implements IGLAble.Date, ICheckPeriod.DocDate, IWBSAllocatable.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        m_docDate = Value
        Me.m_je.DocDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocDate
      End Get
    End Property
    Public Property Type() As MatOperationWithdrawType
      Get
        Return m_type
      End Get
      Set(ByVal Value As MatOperationWithdrawType)
        m_type = Value
        'ValidateCCandType()
      End Set
    End Property
    Public Property Note() As String Implements IGLAble.Note
      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    'Public Sub ValidateCCandType()
    '  If m_fromCostCenter.Id = m_toCostCenter.Id Then
    '    Me.Type.Value = 1 'WIP
    '    Me.Type.Locked = True
    '  Else
    '    Me.Type.Locked = False
    '  End If
    'End Sub
    Public Property CostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter, IHasToCostCenter.ToCC
      Get
        Return m_CostCenter '����Ѻ��èѴ���
      End Get
      Set(ByVal Value As CostCenter)
        If Not m_CostCenter Is Nothing AndAlso m_CostCenter.Valid AndAlso m_CostCenter.Id <> Value.Id Then
          m_itemCollection.Clear()
        End If
        m_CostCenter = Value
        'ValidateCCandType()
      End Set
    End Property
    Public Property ToCC() As CostCenter Implements IWBSAllocatable.FromCostCenter, IHasFromCostCenter.FromCC
      Get
        'Return m_toCostCenter
      End Get
      Set(ByVal Value As CostCenter)
        'm_toCostCenter = Value
        'ValidateCCandType()
      End Set
    End Property
    Public Property CostCenterPerson() As Employee
      Get
        Return m_CostCenterPerson
      End Get
      Set(ByVal Value As Employee)
        m_CostCenterPerson = Value
      End Set
    End Property
    Public Property ToCostCenterPerson() As Employee
      Get
        Return m_toCostCenterPerson
      End Get
      Set(ByVal Value As Employee)
        m_toCostCenterPerson = Value
      End Set
    End Property

    Public Property Asset() As Asset
      Get
        Return m_asset
      End Get
      Set(ByVal Value As Asset)
        m_asset = Value
      End Set
    End Property

    Public ReadOnly Property ToAccount() As Account
      Get
        Select Case Me.Type.Value
          Case 1 'WIP
            Return Me.CostCenter.WipAccount
          Case 2 'EXP
            Return Me.CostCenter.ExpenseAccount
          Case 3 'Store
            Return Me.CostCenter.StoreAccount
        End Select
      End Get
    End Property
    Public Overridable Property Grouping() As Boolean
      Get
        Return m_grouping
      End Get
      Set(ByVal Value As Boolean)
        m_grouping = Value
      End Set
    End Property
    'Public Property CostCenter() As CostCenter
    '  Get
    '    Return m_costCenter
    '  End Get
    '  Set(ByVal Value As CostCenter)
    '    m_costCenter = Value
    '  End Set
    'End Property
    Public ReadOnly Property Gross() As Decimal
      Get
        If Me.ItemCollection Is Nothing Then
          Return 0
        End If
        Dim ret As Decimal = 0
        For Each item As MatOperationWithdrawItem In Me.ItemCollection
          ret += item.ItemCollectionPrePareCost.CostAmount
        Next
        'If Not Me.Grouping Then
        '  For Each item As MatOperationWithdrawItem In Me.ItemCollection
        '    ret += (item.UnitCost * item.StockQty)
        '  Next
        'Else
        '  For Each item As MatOperationWithdrawItem In Me.ItemCollection
        '    ret += item.TransferAmount
        '  Next
        'End If
        Return ret
      End Get
    End Property
    Public ReadOnly Property DiffAmountFIFO As Decimal
      Get
        Return m_diffAmountFIFO
      End Get
    End Property

    Public ReadOnly Property TransferGross() As Decimal
      Get
        If Me.ItemCollection Is Nothing Then
          Return 0
        End If
        Dim ret As Decimal = 0
        For Each item As MatOperationWithdrawItem In Me.ItemCollection
          ret += item.TransferAmount
        Next
        Return ret
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "MatOperationWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "stock"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatOperationWithdraw.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.MatOperationWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.MatOperationWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.MatOperationWithdraw.ListLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        If tpt.EndsWith("()") Then
          tpt.TrimEnd("()".ToCharArray)
        End If
        Return tpt
      End Get
    End Property
#End Region

#Region "Shared"
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("MatOperationWithdraw")
      myDatatable.Columns.Add(New DataColumn("pri_pr", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pr_code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_linenumber", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("pri_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pri_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("PRItemCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PRItemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PRItemUnit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pri_qty", GetType(Decimal)))
      myDatatable.Columns.Add(New DataColumn("PRItemRemainingQty", GetType(Decimal)))

      myDatatable.Columns.Add(New DataColumn("stocki_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Barrier", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("defaultunit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_qty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("StockQty", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_unitcost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_transferUnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_transferamt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("stocki_sequence", GetType(Integer)))

      Return myDatatable
    End Function
#End Region

#Region "Methods"
    Public Function GetOldMatOperationWithdrawWBSActual() As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString,
                                                   CommandType.StoredProcedure,
                                                   "GetOldMatOperationWithdrawWBSActual",
                                                   New SqlParameter("@stock_id", Me.Id)
                                                  )
      Return ds
    End Function
    Private Function GetGRCommandActual() As String
      If Me.m_oldActualDataSet Is Nothing OrElse Me.m_oldActualDataSet.Tables.Count = 0 OrElse Me.m_oldActualDataSet.Tables(0).Rows.Count = 0 Then
        Return ""
      End If
      Dim cmd As String = ""
      Dim cmdList As New ArrayList
      For Each row As DataRow In Me.m_oldActualDataSet.Tables(0).Rows
        Dim drh As New DataRowHelper(row)
        cmd = ""
        cmd = "" & _
        " update swang_mat_wbsactual " & _
        " set wbs_matactual = isnull(wbs_matactual,0) - " & drh.GetValue(Of Decimal)("wbsmatactual").ToString() & "" & _
        " ,wbs_labactual = isnull(wbs_labactual,0) - " & drh.GetValue(Of Decimal)("wbslabactual").ToString() & "" & _
        " ,wbs_eqactual = isnull(wbs_eqactual,0) - " & drh.GetValue(Of Decimal)("wbseqactual").ToString() & "" & _
        " ,nonref_matactual = isnull(nonref_matactual,0) - " & drh.GetValue(Of Decimal)("nonrefmatactual").ToString() & "" & _
        " ,nonref_labactual = isnull(nonref_labactual,0) - " & drh.GetValue(Of Decimal)("nonreflabactual").ToString() & "" & _
        " ,nonref_eqactual = isnull(nonref_eqactual,0) - " & drh.GetValue(Of Decimal)("nonrefeqactual").ToString() & "" & _
        " where wbs_id = " & drh.GetValue(Of Long)("stockiw_wbs").ToString & "" & _
        " and isnull(wbs_ismarkup,0) = " & drh.GetValue(Of Integer)("stockiw_isMarkup").ToString
        cmdList.Add(cmd)
      Next
      If cmdList.Count > 0 Then
        Return String.Join(";", cmdList.ToArray)
      End If

      Return ""
    End Function
    Public Sub ApproveStore(ByVal UserId As Integer)
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim prCodeList As String = Me.GetPrCodeListFromCollection
      Dim prIdList As String = Me.GetPrIDListFromCollection

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "MatOperationWithdrawApproveStore", _
                                  New SqlParameter("@stock_id", Me.Id), _
                                  New SqlParameter("@pridList", prIdList), _
                                  New SqlParameter("@userId", UserId))
        trans.Commit()

        msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.ApprovePR}", prCodeList)
      Catch ex As Exception
        trans.Rollback()
        msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CannotApprove}", prCodeList)
      End Try
    End Sub
    Public Function GetPrCodeListFromCollection() As String
      Dim prCodeList As New ArrayList
      For Each itm As MatOperationWithdrawItem In Me.ItemCollection
        If (Not itm.Pritem Is Nothing AndAlso
            Not itm.Pritem.Pr Is Nothing AndAlso
            Not prCodeList.Contains(itm.Pritem.Pr.Code)) Then
          prCodeList.Add(itm.Pritem.Pr.Code)
        End If
      Next
      Return String.Join(",", prCodeList.ToArray)
    End Function
    Public Function GetPrIDListFromCollection() As String
      Dim prIDList As New ArrayList
      For Each itm As MatOperationWithdrawItem In Me.ItemCollection
        If (Not itm.Pritem Is Nothing AndAlso
            Not itm.Pritem.Pr Is Nothing AndAlso
            Not prIDList.Contains(itm.Pritem.Pr.Id)) Then
          prIDList.Add(itm.Pritem.Pr.Id)
        End If
      Next
      Return String.Join(",", prIDList.ToArray)
    End Function
    'Public Function GetDiffConversion() As Decimal
    '  Try
    '    Dim ds As DataSet = SqlHelper.ExecuteDataset( _
    '            Me.ConnectionString _
    '            , CommandType.StoredProcedure _
    '            , "GetMatwithdrawDiffConversion" _
    '            , New SqlParameter("@stock_id", Me.Id) _
    '            )
    '    If ds.Tables(0).Rows.Count > 0 Then
    '      If ds.Tables(0).Rows(0).IsNull(0) Then
    '        Return 0
    '      End If
    '      Return CDec(ds.Tables(0).Rows(0)(0))
    '    End If
    '  Catch ex As Exception
    '    MessageBox.Show(ex.ToString)
    '  End Try
    '  Return 0
    'End Function
    Public Sub SetActual(ByVal myWbs As WBS, ByVal oldVal As Decimal, ByVal newVal As Decimal, ByVal isOut As Boolean)
      If Not isOut Then
        myWbs = New WBS(myWbs.Id)
        Dim o_n As OldNew
        Dim theHash As Hashtable
        theHash = MatActualHashIn
        If Not theHash Is Nothing Then
          If theHash.Contains(myWbs.Id) Then
            o_n = CType(theHash(myWbs.Id), OldNew)
          Else
            o_n = New OldNew
            o_n.OldValue = myWbs.GetActualMat(Me, 45)
            o_n.NewValue = o_n.OldValue
            theHash(myWbs.Id) = o_n
          End If
          o_n.NewValue += (newVal - oldVal)

          '�觵����ѧ���
          If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
            SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, isOut)
          End If
        End If
      Else
        myWbs = New WBS(myWbs.Id)
        Dim o_n As OldNew
        Dim theHash As Hashtable
        theHash = MatActualHashOut
        If Not theHash Is Nothing Then
          If theHash.Contains(myWbs.Id) Then
            o_n = CType(theHash(myWbs.Id), OldNew)
          Else
            o_n = New OldNew
            o_n.OldValue = myWbs.GetActualMat(Me, 45)
            o_n.NewValue = o_n.OldValue
            theHash(myWbs.Id) = o_n
          End If
          o_n.NewValue += (newVal - oldVal)

          '�觵����ѧ���
          If Not myWbs.Parent Is Nothing AndAlso Not myWbs.Parent.Id = myWbs.Id Then
            SetActual(CType(myWbs.Parent, WBS), oldVal, newVal, isOut)
          End If
        End If
      End If
    End Sub
    Public Function GetCurrentDiffForWBS(ByVal myWbs As WBS, ByVal isOut As Boolean) As Decimal
      If Not isOut Then
        Dim theHash As Hashtable

        theHash = MatActualHashIn

        If Not theHash Is Nothing AndAlso theHash.Contains(myWbs.Id) Then
          Dim o_n As OldNew = CType(theHash(myWbs.Id), OldNew)
          Return o_n.NewValue - o_n.OldValue
        End If
        Return 0
      Else
        Dim theHash As Hashtable

        theHash = MatActualHashOut

        If Not theHash Is Nothing AndAlso theHash.Contains(myWbs.Id) Then
          Dim o_n As OldNew = CType(theHash(myWbs.Id), OldNew)
          Return o_n.NewValue - o_n.OldValue
        End If
        Return 0
      End If
    End Function
    Public Function GetRemainLCIItem(ByVal lci_id As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetRemainLCIItemForCC" _
                , New SqlParameter("@lci_id", lci_id) _
                , New SqlParameter("@cc_id", Me.ValidIdOrDBNull(Me.CostCenter)) _
                , New SqlParameter("@doc_id", Me.Id) _
                )
        Dim tableIndex As Integer = 0
        If ds.Tables.Count > tableIndex Then
          If ds.Tables(tableIndex).Rows.Count > 0 Then
            If ds.Tables(tableIndex).Rows(0).IsNull(0) Then
              Return 0
            End If
            Return CDec(ds.Tables(tableIndex).Rows(0)("remain"))
          End If
        End If
      Catch ex As Exception
        MessageBox.Show(ex.ToString)
      End Try
      Return 0
    End Function
    Public Function GetCurrentAmountForWBS(ByVal myWbs As WBS, ByVal isOut As Boolean) As Decimal
      Dim ret As Decimal = 0
      For Each item As MatOperationWithdrawItem In Me.ItemCollection
        Dim coll As WBSDistributeCollection
        Dim view As Integer = 45
        'If Not isOut Then
        '  coll = item.InWbsdColl
        '  view = 31
        'Else
        coll = item.WBSDistributeCollection
        'view = 45
        'End If
        For Each grWBSD As WBSDistribute In coll
          If Not grWBSD.IsMarkup Then
            'Dim amt As Decimal = WBSDistribute.GetUsedAmount(item.TransferAmount, item.Amount, isOut, view, Me.Type.Value)
            Dim amt As Decimal = WBSDistribute.GetUsedAmount(item.ItemCollectionPrePareCost.CostAmount, item.Amount, isOut, view, Me.Type.Value)
            If grWBSD.WBS.IsDescendantOf(myWbs) Then
              ret += (grWBSD.Percent * amt / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Public Function GetCurrentAmountForMarkup(ByVal mk As Markup, ByVal isOut As Boolean) As Decimal
      Dim ret As Decimal = 0
      For Each item As MatOperationWithdrawItem In Me.ItemCollection
        Dim coll As WBSDistributeCollection
        'If Not isOut Then
        '  coll = item.InWbsdColl
        'Else
        coll = item.WBSDistributeCollection
        'End If
        For Each grWBSD As WBSDistribute In coll
          If grWBSD.IsMarkup Then
            If grWBSD.WBS.Id = mk.Id And mk.Id <> 0 Then
              ret += (grWBSD.Percent * item.Amount / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Public Function GetCurrentQtyForWBS(ByVal myWbs As WBS, ByVal unit As Unit, ByVal isOut As Boolean) As Decimal
      Dim ret As Decimal = 0
      For Each item As MatOperationWithdrawItem In Me.ItemCollection
        Dim coll As WBSDistributeCollection
        Dim view As Integer = 45
        'If Not isOut Then
        '  coll = item.InWbsdColl
        '  view = 31
        'Else
        coll = item.WBSDistributeCollection
        view = 45
        'End If
        For Each grWBSD As WBSDistribute In coll
          If Not grWBSD.IsMarkup Then
            Dim qty As Decimal = WBSDistribute.GetUsedQty(item.StockQty, isOut, view, Me.Type.Value)
            If grWBSD.WBS.IsDescendantOf(myWbs) Then
              ret += (grWBSD.Percent * qty / 100)
            End If
          End If
        Next
      Next
      Return ret
    End Function
    Private Function OverBudget() As Boolean
      If Me.CostCenter.Type.Value <> 2 Then
        Return False
      End If
      'GROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("GROverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If
      If Not onlyCC Then
        For Each item As MatOperationWithdrawItem In Me.ItemCollection
          Dim inwsdColl As WBSDistributeCollection = item.WBSDistributeCollection
          If inwsdColl.Count = 0 Then
            Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
            Dim totalBudget As Decimal = 0
            Dim totalActual As Decimal = 0
            Dim totalCurrentDiff As Decimal = item.ItemCollectionPrePareCost.CostAmount
            totalBudget = rootWBS.GetTotalMatFromDB
            totalActual = rootWBS.GetActualMat(Me, 31)
            If totalBudget < (totalActual + totalCurrentDiff) Then
              Return True
            End If
          End If

          For Each wbsd As WBSDistribute In inwsdColl
            If wbsd.AmountOverBudget Then
              Return True
            End If
            Dim rootWBS As New WBS(wbsd.WBS.Id)
            Dim totalBudget As Decimal = 0
            Dim totalActual As Decimal = 0
            Dim totalCurrentDiff As Decimal = 0
            totalCurrentDiff = GetCurrentAmountForWBS(rootWBS, False)
            For Each row As DataRow In rootWBS.GetParentsBudget(Me.EntityId, wbsd.CostCenter.Id)
              totalBudget = 0
              totalActual = 0
              If Not row.IsNull("matbudget") Then
                totalBudget = CDec(row("matbudget"))
              End If
              If Not row.IsNull("matactual") Then
                totalActual = CDec(row("matactual"))
              End If
              If totalBudget < (totalActual + totalCurrentDiff) Then
                Return True
              End If
            Next
          Next

        Next
      Else
        Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
        Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
        Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 31) + rootWBS.GetActualLab(Me, 31) + rootWBS.GetActualEq(Me, 31))
        Dim totalCurrentDiff As Decimal = GetCurrentAmountForWBS(rootWBS, False)
        If totalBudget < (totalActual + totalCurrentDiff) Then
          Return True
        End If

      End If
      Return False
    End Function
    Private Function VerrifyCost() As String
      For Each item As MatOperationWithdrawItem In Me.ItemCollection
        Dim currCostCollection As New StockCostItemCollection(item.Entity, Me.CostCenter, item.StockQty, Me.Id)
        If item.ItemCollectionPrePareCost.Count <> currCostCollection.Count Then
          Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange}") & vbCrLf & _
               Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange2}") & vbCrLf & _
               Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange3}")
        End If
        For i As Integer = 0 To item.ItemCollectionPrePareCost.Count - 1
          If item.ItemCollectionPrePareCost(i).UnitCost = currCostCollection(i).UnitCost AndAlso _
             item.ItemCollectionPrePareCost(i).StockQty = currCostCollection(i).StockQty Then
            Return ""
          Else
            Return Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange}") & vbCrLf & _
                   Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange2}") & vbCrLf & _
                   Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdraw.CostChange3}")
          End If
        Next
      Next
      Return ""
    End Function
    Private Sub ResetId(ByVal oldid As Integer, ByVal oldjeid As Integer)
      Me.Id = oldid
      Me.m_je.Id = oldjeid
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Private Function ValidateItem() As SaveErrorException
      Dim key As String = ""
      Dim configObj As Object = Configuration.GetConfig("PRNeedStoreApprove")

      For Each item As MatOperationWithdrawItem In Me.ItemCollection

        Dim newHash As New Hashtable
        For Each wbitem As WBSDistribute In item.WBSDistributeCollection
          key = wbitem.WBS.Id.ToString
          If Not newHash.Contains(key) Then
            newHash(key) = wbitem
          Else
            Return New SaveErrorException("${res:Global.Error.DupplicateWBS}", New String() {wbitem.WBS.Code})
          End If
          If (wbitem.WBS Is Nothing OrElse wbitem.WBS.Id = 0) AndAlso wbitem.CostCenter.BoqId > 0 Then
            Return New SaveErrorException("${res:Global.Error.WBSMissing}")
          End If
        Next

        If CBool(configObj) Then
          If Not item.Pritem Is Nothing AndAlso Not item.Pritem.Pr Is Nothing Then
            If Not item.Pritem.Pr.CheckIsStoreApproved Then
              Return New SaveErrorException("${res:Global.Error.ApproveStorePersonMissing}", New String() {item.Pritem.Pr.Code})
            End If
          End If
        End If
      Next



      Return New SaveErrorException("0")
    End Function
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If



      Return New SaveErrorException("0")

    End Function

    Dim stockIdArrayList As ArrayList
    Dim prIdArrayList As ArrayList
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      With Me
        If Not Me.Grouping Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.MatWithdrawForOperation.Grouping}"))
        End If
        If Me.ItemCollection.Count = 0 Then
          Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
        End If

        Dim ValidateError As SaveErrorException = ValidateItem()
        If Not IsNumeric(ValidateError.Message) Then
          Return ValidateError
        End If

        Dim VerrifyCostErrorMessage As String = VerrifyCost()
        If VerrifyCostErrorMessage.Length > 0 Then
          If Not msgServ.AskQuestion(VerrifyCostErrorMessage) Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
          End If
        End If

        stockIdArrayList = New ArrayList
        prIdArrayList = New ArrayList
        stockIdArrayList.AddRange(Me.GetStockList)
        prIdArrayList.AddRange(Me.GetPrList)

        ''check over budget
        'Dim overbudgetconfig As Integer = CInt(Configuration.GetConfig("GROverBudget"))
        'Select Case overbudgetconfig
        '  Case 0 'Not allow
        '    If OverBudget() Then
        '      Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.GROverBudgetCannotBeSaved}"))
        '    End If
        '  Case 1 'Warn
        '    If OverBudget() Then
        '      If Not msgServ.AskQuestion("${res:Global.Question.GROverBudgetSaveAnyway}") Then
        '        Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
        '      End If
        '    End If
        '  Case 2 'Do Nothing
        'End Select

        '---------------------------
        'Dim cumWithdraw As New Hashtable
        'Dim cumCode As New Hashtable
        'Dim exCode As String


        'Dim config As Integer = CInt(Configuration.GetConfig("MWZeroStock"))
        'If config < 2 Then
        '  For Each item As MatOperationWithdrawItem In Me.ItemCollection
        '    If cumWithdraw.Contains(item.Entity.Id) Then
        '      cumWithdraw(item.Entity.Id) = CDec(cumWithdraw(item.Entity.Id)) + item.StockQty
        '    Else
        '      cumWithdraw(item.Entity.Id) = item.StockQty
        '      cumCode(item.Entity.Id) = item.Entity.Code
        '    End If
        '  Next
        '  exCode = ""
        '  For Each o As Object In cumWithdraw.Keys
        '    If GetRemainLCIItem(CInt(o)) < CDec(cumWithdraw(o)) Then
        '      If exCode.Length > 0 Then
        '        exCode = exCode & vbNewLine & CStr(cumCode(CInt(o)))
        '      Else
        '        exCode = vbNewLine & CStr(cumCode(CInt(o)))
        '      End If
        '    End If
        '  Next
        'End If

        'Select Case config
        '  Case 0 'Not allow
        '    If exCode.Length > 0 Then
        '      exCode = exCode & vbNewLine
        '      Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.ExceedStock}"), exCode)
        '    End If
        '  Case 1 'Warn
        '    If exCode.Length > 0 Then
        '      exCode = exCode & vbNewLine
        '      'Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        '      msgServ.ShowMessageFormatted("${res:Global.Error.ExceedStock}", New String() {exCode})
        '      If Not msgServ.AskQuestion("${res:Global.Question.MWExceedStockSaveAnyway}") Then
        '        Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
        '      End If
        '    End If
        '  Case 2 'Do Nothing

        'End Select
        '---------------------------
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@stock_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
        End If
        If Me.Status.Value = -1 Then
          Me.Status = New StockStatus(2)
        End If

        '---- AutoCode Format --------
        Dim oldcode As String
        Dim oldautogen As Boolean
        Dim oldjecode As String
        Dim oldjeautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
        oldjecode = Me.m_je.Code
        oldjeautogen = Me.m_je.AutoGen

        Me.m_je.RefreshGLFormat()
        If Not AutoCodeFormat Is Nothing AndAlso Not AutoCodeFormat.Format Is Nothing Then


          Select Case Me.AutoCodeFormat.CodeConfig.Value
            Case 0
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.DontSave = True
              Me.m_je.Code = ""
              Me.m_je.DocDate = Me.DocDate
            Case 1
              '��� entity
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              Me.m_je.Code = Me.Code
            Case 2
              '��� gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
            Case Else
              '�¡
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
          End Select
        Else
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        Me.m_je.DocDate = Me.DocDate
        Me.AutoGen = False
        Me.m_je.AutoGen = False
        paramArrayList.Add(New SqlParameter("@stock_docDate", IIf(Me.DocDate.Equals(Date.MinValue), DBNull.Value, Me.DocDate)))
        paramArrayList.Add(New SqlParameter("@stock_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@stock_toAcct", IIf(Me.ToAccount.Originated, Me.ToAccount.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_tocc", IIf(Me.CostCenter.Originated, Me.CostCenter.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_toccperson", IIf(Me.ToCostCenterPerson.Originated, Me.ToCostCenterPerson.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_fromcc", IIf(Me.CostCenter.Originated, Me.CostCenter.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_fromccperson", IIf(Me.CostCenterPerson.Originated, Me.CostCenterPerson.Id, DBNull.Value)))
        'paramArrayList.Add(New SqlParameter("@stock_fromcc", IIf(Me.CostCenter.Originated, Me.CostCenter.Id, DBNull.Value)))
        paramArrayList.Add(New SqlParameter("@stock_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@stock_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@stock_type", Me.EntityId))
        paramArrayList.Add(New SqlParameter("@stock_tag", Me.Type.Value))
        paramArrayList.Add(New SqlParameter("@stock_asset", IIf(Me.Asset.Originated, Me.Asset.Id, DBNull.Value)))
        SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

        '---==Validated ��÷� before save �ͧ˹���������� ====
        Dim ValidateError2 As SaveErrorException = Me.BeforeSave(currentUserId)
        If Not IsNumeric(ValidateError2.Message) Then
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return ValidateError2
        End If
        '---==Validated ��÷� before save �ͧ˹���������� ====

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())
        Dim trans As SqlTransaction
        Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)
        conn.Open()

        Dim transbefore As SqlTransaction = conn.BeginTransaction
        Try

          ''==============================DELETE STOCKCOST=========================================
          ''����͡��ù��١��ҧ�ԧ���� ������͹حҵ��������¹�ŧ Cost ���ǹ� (julawut)
          If Me.Originated AndAlso Not Me.IsReferenced Then
            SqlHelper.ExecuteNonQuery(conn, transbefore, CommandType.StoredProcedure, "DeleteStockiCost", New SqlParameter("@stock_id", Me.Id))
          End If
          ''==============================DELETE STOCKCOST=========================================
          '==============================UPDATE Old PRITEM=========================================
          If Me.Originated AndAlso Not Me.IsReferenced Then
            SqlHelper.ExecuteNonQuery(conn, transbefore, CommandType.StoredProcedure, "DeleteOldPriWithdrawQty", New SqlParameter("@stock_id", Me.Id))
          End If
          '==============================UPDATE Old PRITEM=========================================
          transbefore.Commit()
        Catch ex As Exception
          transbefore.Rollback()
          ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
          Return New SaveErrorException(ex.InnerException.ToString)
        End Try

        trans = conn.BeginTransaction()

        Dim oldid As Integer = Me.Id
        Dim oldjeid As Integer = Me.m_je.Id

        Try
          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If


            Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
            If Not IsNumeric(saveDetailError.Message) Then
              trans.Rollback()
              ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveDetailError
            Else
              Select Case CInt(saveDetailError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveDetailError
                Case Else
              End Select
            End If

            ''============================== ����ҧ�����ѧ Save AutoCodeFormat �����Դ DeadLock ========
            'Me.ItemCollection = New MatOperationWithdrawItemCollection(Me, True, conn, trans)
            ''============================== ����ҧ�����ѧ Save AutoCodeFormat �����Դ DeadLock ========

            '==============================STOCKCOSTFIFO=========================================
            '����͡��ù��١��ҧ�ԧ���� ������͹حҵ��������¹�ŧ Cost ���ǹ� (julawut)
            If Not Me.IsReferenced Then
              'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "InsertStockiCostFIFO", New SqlParameter("@stock_id", Me.Id), New SqlParameter("@stock_cc", Me.CostCenter.Id))

              Try
                CostItem.Update("InsertStockiCostFIFO_DeleteCost", conn, trans, Me.Id, Me.CostCenter.Id)
                CostItem.Update("InsertStockiCostFIFO_NewInsert", conn, trans, Me.Id, Me.CostCenter.Id)
                CostItem.Update("InsertStockiCostFIFO_UpdateStockItem", conn, trans, Me.Id, Me.CostCenter.Id)
                CostItem.Update("InsertStockiCostFIFO_UpdateStockIWBS", conn, trans, Me.Id, Me.CostCenter.Id)
              Catch ex As Exception
                Return New SaveErrorException(ex.Message)
              End Try
            End If
            '==============================STOCKCOSTFIFO=========================================
            '''����� Cost �� ��ͧ refresh GL ����
            ''==============================UPDATE PRITEM=========================================
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePriWithdrawQtyWithDefaultUnit", New SqlParameter("@stock_id", Me.Id))
            ''==============================UPDATE PRITEM=========================================

            'Me.DeleteRef(conn, trans)
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePR_MAtwRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
            ', New SqlParameter("@refto_id", Me.Id))
            'If Me.Status.Value = 0 Then
            '  Me.CancelRef(conn, trans)
            'End If
            'trans.Commit()


            'Try
            'trans = conn.BeginTransaction()
            'Dim saveWBSError As SaveErrorException = Me.SaveWBSDetail(Me.Id, conn, trans)
            'If Not IsNumeric(saveWBSError.Message) Then
            '    trans.Rollback()
            '    ResetId(oldid, oldjeid)
            '    Return saveWBSError
            'Else
            '    Select Case CInt(saveWBSError.Message)
            '        Case -1, -5
            '            trans.Rollback()
            '            ResetId(oldid, oldjeid)
            '            Return saveWBSError
            '        Case -2
            '            'Post �����
            '            Return saveWBSError
            '        Case Else
            '    End Select
            'End If


            ''--------------------------------------------------------------
            'Dim savePRItemsError As SaveErrorException = Me.SavePRItemsDetail(arr, trans, conn)
            'If Not IsNumeric(savePRItemsError.Message) Then
            '    trans.Rollback()
            '    ResetId(oldid, oldjeid)
            '    Return savePRItemsError
            'Else
            '    Select Case CInt(savePRItemsError.Message)
            '        Case -1, -5
            '            trans.Rollback()
            '            ResetId(oldid, oldjeid)
            '            Return savePRItemsError
            '        Case -2
            '            'Post �����
            '            Return savePRItemsError
            '        Case Else
            '    End Select
            'End If
            '--------------------------------------------------------------

            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_InsertStockProcedure", New SqlParameter("@stock_id", Me.Id))
            'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateMATWBSActual")

            '==============================AUTOGEN==========================================
            Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
            If Not IsNumeric(saveAutoCodeError.Message) Then
              trans.Rollback()
              ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  ResetId(oldid, oldjeid)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================


            'trans.Commit()
            'Catch ex As Exception
            '    trans.Rollback()
            '    ResetId(oldid, oldjeid)
            '    Return New SaveErrorException(ex.ToString)
            'End Try

            '-------------------------------GL----------------------------------------------------
            'Try
            '    trans = conn.BeginTransaction()
            'Me.ItemCollection = New MatOperationWithdrawItemCollection(Me, True, conn, trans)
            'If Me.m_je.Status.Value = -1 Then
            '  m_je.Status.Value = 3
            'End If
            ' ''********************************************
            'If Not Me.m_je.ManualFormat Then
            '  m_je.SetGLFormat(Me.GetDefaultGLFormat)
            'End If
            ' ''********************************************
            'Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
            'If Not IsNumeric(saveJeError.Message) Then
            '  trans.Rollback()
            '  ResetId(oldid, oldjeid)
            '  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            '  Return saveJeError
            'Else
            '  Select Case CInt(saveJeError.Message)
            '    Case -1, -5
            '      trans.Rollback()
            '      ResetId(oldid, oldjeid)
            '      ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            '      Return saveJeError
            '    Case -2
            '      'Post �����
            '      Return saveJeError
            '    Case Else
            '  End Select
            'End If

            trans.Commit()
            'Catch ex As Exception
            '    trans.Rollback()
            '    ResetId(oldid, oldjeid)
            '    Return New SaveErrorException(ex.ToString)
            'End Try
            '-------------------------------END GL----------------------------------------------------

            'Me.ItemCollection.CheckPRForStoreApprove()

            'Return New SaveErrorException(returnVal.Value.ToString)
          Catch ex As SqlException
            trans.Rollback()
            ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            ResetId(oldid, oldjeid)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
            'Finally
            '  conn.Close()
          End Try

          '--JE Save Block-- ============================================================
          If Not Me.m_je.DontSave Then
            '�֧ error �ѹ�á���ҹ�����  reset ੾�� GL ��
            oldid = Me.Id
            oldcode = Me.Code
            oldautogen = Me.AutoGen
            Try

              '��� Manual Format ������ͧ�����
              If Not Me.JournalEntry.ManualFormat Then
                '�� Cost ���� ������ҧ���� ���������� trans
                '���Ǥ����� trans �͹������
                Me.ItemCollection = New MatOperationWithdrawItemCollection(Me, True)
                '********************************************
                '��ͧ�͡����ѹ refresh gl ��� Cost �����������
                Me.OnGlChanged()

                Dim glf As GLFormat = Me.GetDefaultGLFormat
                If Not glf Is Nothing Then
                  m_je.SetGLFormat(Me.GetDefaultGLFormat)
                End If
              End If
              '********************************************
            Catch ex As Exception
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End Try

            Dim transJe As SqlTransaction = conn.BeginTransaction()
            Try


              If Me.m_je.Status.Value = -1 Then
                m_je.Status.Value = 3
              End If

              Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, transJe)
              If Not IsNumeric(saveJeError.Message) Then
                transJe.Rollback()
                Me.ResetId(oldid, oldjeid)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveJeError
              Else
                Select Case CInt(saveJeError.Message)
                  Case -1, -5
                    transJe.Rollback()
                    Me.ResetId(oldid, oldjeid)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveJeError
                  Case -2
                    'Post �����
                    Return saveJeError
                  Case Else
                End Select
              End If

              transJe.Commit()

            Catch ex As Exception
              transJe.Rollback()
              Me.ResetId(oldid, oldjeid)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(ex.ToString)
            End Try
          End If
          '--JE Save Block-- ============================================================

          '--Sub Save Block-- ============================================================
          Try
            Dim subsaveerror3 As SaveErrorException = SubSaveJeAtom(conn)
            If Not IsNumeric(subsaveerror3.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again (1)")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          'Try
          '  Dim subsaveerror As SaveErrorException = SubSave(conn)
          '  If Not IsNumeric(subsaveerror.Message) Then
          '    Return New SaveErrorException(" Save Incomplete Please Save Again (2)")
          '  End If
          '  'Complete Save
          'Catch ex As Exception
          '  Return New SaveErrorException(ex.ToString)
          'End Try

          'Try
          '  Dim subsaveerror As SaveErrorException = SaveWBSActual(conn)
          '  If Not IsNumeric(subsaveerror.Message) Then
          '    Return New SaveErrorException(" Save Incomplete Please Save Again (3)")
          '  End If
          '  'Complete Save
          'Catch ex As Exception
          '  Return New SaveErrorException(ex.ToString)
          'End Try

          Try

            Parallel.Invoke(Sub()
                              SaveWBSActual(conn)
                            End Sub,
                            Sub()
                              UpdateWBSReferencedFromStock(conn)
                            End Sub,
                            Sub()
                              SubSave(conn)
                            End Sub)

          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try
          '--Sub Save Block-- ============================================================


          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function

    Private Function SaveWBSActual(ByVal oldconn As SqlConnection) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()

      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        Dim cmd As String = Me.GetGRCommandActual
        If cmd.Length > 0 Then
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, cmd)
        End If
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_OnlyUpdateMatOperationWithdrawWBSActual", New SqlParameter("@stock_id", Me.Id))

      Catch ex As Exception
        trans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function

    Private Function UpdateWBSReferencedFromStock(ByVal oldconn As SqlConnection) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()

      Dim trans As SqlTransaction = conn.BeginTransaction
      Try

        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSReferencedFromStock", New SqlParameter("@refto_id", Me.Id), New SqlParameter("@refto_type", Me.EntityId))

      Catch ex As Exception
        trans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function

    Private Function SubSave(ByVal oldconn As SqlConnection) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()

      '======����� trans 2 �ͧ�Դ��� save ���� ========
      Dim trans As SqlTransaction = conn.BeginTransaction

      Try
        'Me.ItemCollection = New MatOperationWithdrawItemCollection(Me, True, conn, trans)


        '==============================UPDATE PRITEM=========================================
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePriWithdrawQtyWithDefaultUnitAfterSaveStockItem", New SqlParameter("@stock_id", Me.Id))
        '==============================UPDATE PRITEM=========================================

        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateStock_StockRef" _
        , New SqlParameter("@refto_id", Me.Id))
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePR_MAtwRef" _
        , New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBS_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateMarkup_StockRef" _
        ', New SqlParameter("@refto_id", Me.Id))
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSReferencedFromStock", New SqlParameter("@refto_id", Me.Id), New SqlParameter("@refto_type", Me.EntityId))
        If Me.Status.Value = 0 Then
          Me.CancelRef(conn, trans)
        End If
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateMATWBSActual")
      Catch ex As Exception
        trans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      conn.Close()

      Try

        stockIdArrayList.AddRange(Me.GetStockList)
        prIdArrayList.AddRange(Me.GetPrList)

        Dim stockIdList As String = String.Join(",", stockIdArrayList.ToArray)
        Dim prIdList As String = String.Join(",", prIdArrayList.ToArray)

        PR.UpdateReferencePRList(conn, prIdList)
        GoodsReceipt.UpdateReferenceGoodsReceiptList(conn, stockIdList)
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try

      Return New SaveErrorException("0")
    End Function

    Private Function GetPrList() As ArrayList
      Dim prIdList As New ArrayList
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetPRListForUpdateMatOperationWithdraw", New SqlParameter("@stock_id", Me.Id))
        For Each row As DataRow In ds.Tables(0).Rows
          prIdList.Add(CInt(row("stocki_refDoc")))
        Next
      Catch ex As Exception

      End Try

      Return prIdList 'String.Join(",", prIdList.ToArray)
    End Function

    Private Function GetStockList() As ArrayList
      Dim stockIdList As New ArrayList
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetStockListForUpdateGoodsReceiptList", New SqlParameter("@refto_id", Me.Id), New SqlParameter("@refto_type", Me.EntityId))
        For Each row As DataRow In ds.Tables(0).Rows
          stockIdList.Add(CInt(row("stock_id")))
        Next
      Catch ex As Exception

      End Try

      Return stockIdList 'String.Join(",", stockIdList.ToArray)
    End Function

    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String
      If Me.AutoCodeFormat.Format.Length > 0 Then
        autoCodeFormat = Me.AutoCodeFormat.Format
      Else
        autoCodeFormat = Me.Code
      End If
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
      Try
        Dim unitCost As Decimal = 0
        Dim Cost As Decimal = 0

        Dim da As New SqlDataAdapter("Select * from stockitem where stocki_stock=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ") and stockiw_direction = 0", conn)

        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From stockitem Where stocki_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "stockitem")
        da.Fill(ds, "stockitem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "stockiwbs")
        daWbs.Fill(ds, "stockiwbs")
        ds.Relations.Add("sequence", ds.Tables!stockitem.Columns!stocki_sequence, ds.Tables!stockiwbs.Columns!stockiw_sequence)

        Dim dt As DataTable = ds.Tables("stockitem")

        Dim dtWbs As DataTable = ds.Tables("stockiwbs")

        For Each row As DataRow In ds.Tables("stockiwbs").Rows
          row.Delete()
        Next

        Dim rowsToDelete As ArrayList
        '------------Checking if we have to delete some rows--------------------
        rowsToDelete = New ArrayList
        For Each dr As DataRow In dt.Rows
          Dim found As Boolean = False
          For Each testItem As MatOperationWithdrawItem In Me.ItemCollection
            If testItem.Sequence = CInt(dr("stocki_sequence")) Then
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

        Dim i As Integer = 0 'Line Running
        Dim seq As Integer = -1
        For Each item As MatOperationWithdrawItem In Me.ItemCollection
          i += 1

          '------------Checking if we have to add a new row or just update existing--------------------
          Dim dr As DataRow
          Dim drs As DataRow() = dt.Select("stocki_sequence=" & item.Sequence)
          If drs.Length = 0 Then
            dr = dt.NewRow
            'dt.Rows.Add(dr)
            seq = seq + (-1)
            dr("stocki_sequence") = seq
          Else
            dr = drs(0)
          End If
          '------------End Checking--------------------

          If item.Pritem Is Nothing Then
            dr("stocki_refdoc") = DBNull.Value
            dr("stocki_refdoclinenumber") = DBNull.Value
          Else
            dr("stocki_refdoc") = item.Pritem.Pr.Id
            dr("stocki_refdoclinenumber") = item.Pritem.LineNumber
          End If
          dr("stocki_stock") = Me.Id
          dr("stocki_cc") = DBNull.Value
          If Me.Grouping Then
            dr("stocki_linenumber") = i
          Else
            dr("stocki_linenumber") = item.LineNumber
          End If
          dr("stocki_entity") = item.Entity.Id
          If TypeOf item.Entity Is IObjectReflectable Then
            dr("stocki_entityType") = CType(item.Entity, IObjectReflectable).EntityId
          Else
            dr("stocki_entityType") = 0
          End If
          dr("stocki_itemName") = item.Entity.Name
          dr("stocki_unit") = item.Unit.Id
          dr("stocki_stockqty") = item.StockQty
          dr("stocki_toacct") = SimpleBusinessEntityBase.ValidIdOrDBNull(Me.ToAccount)
          dr("stocki_toacctType") = Me.Type.Value
          dr("stocki_qty") = item.Qty
          dr("stocki_note") = item.Note
          dr("stocki_type") = Me.EntityId
          dr("stocki_fromcc") = SimpleBusinessEntityBase.ValidIdOrDBNull(Me.CostCenter)
          dr("stocki_tocc") = SimpleBusinessEntityBase.ValidIdOrDBNull(Me.CostCenter)
          dr("stocki_status") = Me.Status.Value
          dr("stocki_refsequence") = 0  '0 仡�͹������� Query Update RefSequence �������ѧ
          If item.TransferUnitPrice = Decimal.MinValue Then
            dr("stocki_transferunitprice") = DBNull.Value
          Else
            dr("stocki_transferunitprice") = item.TransferUnitPrice
          End If
          'dt.Rows.Add(dr)

          '------------Checking if we have to add a new row or just update existing--------------------
          If drs.Length = 0 Then
            dt.Rows.Add(dr)
          End If
          '------------End Checking--------------------

          'For x As Integer = 0 To 1
          Dim rootWBS As WBS
          Dim wbsdColl As WBSDistributeCollection
          Dim currentSum As Decimal
          Dim currentCostCenter As CostCenter

          'If x = 0 Then
          'rootWBS = New WBS(Me.ToCostCenter.RootWBSId)
          'wbsdColl = item.InWbsdColl
          'currentSum = wbsdColl.GetSumPercent
          'currentCostCenter = Me.ToCostCenter
          'Else
          rootWBS = New WBS(Me.CostCenter.RootWBSId)
          wbsdColl = item.WBSDistributeCollection
          currentSum = wbsdColl.GetSumPercent
          currentCostCenter = Me.CostCenter
          'End If

          'If (x = 0 AndAlso item.AllowWBSAllocateTo) OrElse (x = 1 AndAlso item.AllowWBSAllocateFrom) Then

          Try
            For Each wbsd As WBSDistribute In wbsdColl
              If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
                '�ѧ������ 100 �����������
                wbsd.Percent += (100 - currentSum)
              End If
              'Dim bfTax As Decimal = 0
              'bfTax = item.CostAmount
              'wbsd.BaseCost = bfTax 'item.Amount
              'wbsd.TransferBaseCost = bfTax 'item.Amount
              Dim childDr As DataRow = dtWbs.NewRow
              childDr("stockiw_sequence") = dr("stocki_sequence")
              childDr("stockiw_wbs") = wbsd.WBS.Id
              childDr("stockiw_percent") = wbsd.Percent
              childDr("stockiw_ismarkup") = wbsd.IsMarkup
              childDr("stockiw_direction") = 0
              'childDr("stockiw_baseCost") = wbsd.BaseCost
              'childDr("stockiw_amt") = wbsd.Amount
              childDr("stockiw_toaccttype") = Me.Type.Value
              If wbsd.CostCenter Is Nothing Then
                wbsd.CostCenter = currentCostCenter
              End If
              childDr("stockiw_cc") = wbsd.CostCenter.Id
              childDr("stockiw_cbs") = wbsd.CBS.Id
              'Add ��� sciwbs
              dtWbs.Rows.Add(childDr)
            Next
          Catch ex As Exception
            Throw New Exception(ex.Message)
          End Try

          currentSum = wbsdColl.GetSumPercent
          '�ѧ������ 100 ����ѧ����� root
          If currentSum < 100 Then
            Try
              Dim wbsd As New WBSDistribute
              wbsd.WBS = rootWBS
              wbsd.CostCenter = currentCostCenter
              wbsd.Percent = 100 - currentSum
              'Dim bfTax As Decimal = 0
              'bfTax = item.CostAmount
              'wbsd.BaseCost = bfTax 'item.Amount
              'wbsd.TransferBaseCost = bfTax 'item.Amount
              Dim childDr As DataRow = dtWbs.NewRow

              childDr("stockiw_sequence") = dr("stocki_sequence")
              childDr("stockiw_wbs") = wbsd.WBS.Id
              childDr("stockiw_percent") = wbsd.Percent
              childDr("stockiw_ismarkup") = wbsd.IsMarkup
              childDr("stockiw_direction") = 0
              'childDr("stockiw_baseCost") = wbsd.BaseCost
              'childDr("stockiw_amt") = wbsd.Amount
              childDr("stockiw_toaccttype") = Me.Type.Value
              childDr("stockiw_cc") = wbsd.CostCenter.Id
              childDr("stockiw_cbs") = wbsd.CBS.Id

              'Add ��� sciwbs
              dtWbs.Rows.Add(childDr)
            Catch ex As Exception
              Throw New Exception(ex.Message)
            End Try
          End If

          'End If '

        Next
        'Next

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

        daWbs.Update(GetDeletedRows(dtWbs))
        'da_aux.Update(GetDeletedRows(dtAux))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        'da_aux.Update(dtAux.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
        'da_aux.Update(dtAux.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = False
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.Added))
        ds.EnforceConstraints = True
        Return New SaveErrorException("1")
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
        Dim currentkey As Integer = CInt(e.Row("stockiw_sequence")) '.GetParentRow("sequence")("stockiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!stockiw_sequence = e.Row.GetParentRow("sequence")("stocki_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!stockiw_sequence = currentkey
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
    'Private Function SaveWBSDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
    '  Try
    '    Dim da As New SqlDataAdapter("Select * from stockiwbs where stockiw_sequence in (select stocki_sequence from stockitem where stocki_stock=" & Me.Id & ")", conn)
    '    Dim cmdBuilder As New SqlCommandBuilder(da)

    '    Dim ds As New DataSet

    '    da.SelectCommand.Transaction = trans

    '    '��ͧ�����ͨҡ da.SelectCommand.Transaction = trans
    '    cmdBuilder.GetDeleteCommand.Transaction = trans
    '    cmdBuilder.GetInsertCommand.Transaction = trans
    '    cmdBuilder.GetUpdateCommand.Transaction = trans

    '    da.Fill(ds, "stockiwbs")

    '    Dim i As Integer = 0
    '    Dim dtWbs As DataTable = ds.Tables("stockiwbs")
    '    Dim rootWBS As WBS
    '    Dim currentSum As Decimal
    '    Dim Cost As Decimal = 0

    '    With dtWbs
    '      For Each row As DataRow In .Rows
    '        row.Delete()
    '      Next
    '      Dim line As Integer = 0
    '      For Each item As MatOperationWithdrawItem In Me.ItemCollection
    '        Dim seqArr As New ArrayList
    '        line = line + 1

    '        seqArr = StockItem.GetSequenceArray(Me.Id, line)
    '        For Each row As DataRow In seqArr

    '          If Not row.IsNull("stocki_amt") Then
    '            Cost = CDec(row("stocki_amt"))
    '          Else
    '            Cost = 0
    '          End If

    '          Dim wcoll As WBSDistributeCollection

    '          For x As Integer = 0 To 1 'loop Cost Center
    '            If x = 0 Then
    '              wcoll = item.InWbsdColl
    '              currentSum = wcoll.GetSumPercent
    '              rootWBS = New WBS(Me.ToCostCenter.RootWBSId)
    '            Else
    '              wcoll = item.OutWbsdColl
    '              currentSum = wcoll.GetSumPercent
    '              rootWBS = New WBS(Me.FromCostCenter.RootWBSId)
    '            End If

    '            Dim childDr As DataRow

    '            If wcoll.Count > 0 Then

    '              For Each wbsd As WBSDistribute In wcoll

    '                childDr = dtWbs.NewRow
    '                childDr("stockiw_wbs") = wbsd.WBS.Id

    '                If wbsd.CostCenter Is Nothing Then
    '                  If x = 0 Then
    '                    wbsd.CostCenter = Me.ToCostCenter
    '                  Else
    '                    wbsd.CostCenter = Me.FromCostCenter
    '                  End If
    '                End If

    '                If currentSum < 100 AndAlso (wbsd.WBS Is rootWBS OrElse wbsd.WBS.Id = rootWBS.Id) Then
    '                  '�ѧ������ 100 �����������
    '                  wbsd.Percent += (100 - currentSum)
    '                End If
    '                'wbsd.BaseCost = CDec(row("stocki_amt"))
    '                'If Not row.IsNull("stocki_amt") Then
    '                '	wbsd.BaseCost = CDec(row("stocki_amt"))								 'item.Amount
    '                'Else
    '                '	wbsd.BaseCost = 0
    '                'End If

    '                wbsd.BaseCost = Cost
    '                wbsd.TransferBaseCost = Cost

    '                childDr("stockiw_cc") = wbsd.CostCenter.Id
    '                childDr("stockiw_percent") = wbsd.Percent
    '                childDr("stockiw_sequence") = row("stocki_sequence")
    '                childDr("stockiw_ismarkup") = wbsd.IsMarkup
    '                childDr("stockiw_direction") = x
    '                childDr("stockiw_baseCost") = wbsd.BaseCost
    '                childDr("stockiw_amt") = wbsd.Amount
    '                childDr("stockiw_transferbaseCost") = wbsd.BaseCost
    '                childDr("stockiw_transferamt") = wbsd.Amount
    '                childDr("stockiw_toaccttype") = Me.Type.Value      'wbsd.Toaccttype
    '                'Add ��� stockiwbs
    '                dtWbs.Rows.Add(childDr)

    '              Next
    '            ElseIf Not (rootWBS.Id = 0) Then
    '              childDr = dtWbs.NewRow

    '              Dim newWbsd As New WBSDistribute
    '              newWbsd.WBS = rootWBS

    '              If x = 0 Then
    '                newWbsd.CostCenter = Me.ToCostCenter
    '              Else
    '                newWbsd.CostCenter = Me.FromCostCenter
    '              End If

    '              newWbsd.Percent = 100 - currentSum
    '              'If Not row.IsNull("stocki_amt") Then
    '              '  newWbsd.BaseCost = CDec(row("stocki_amt")) 'item.Amount
    '              'Else
    '              '  newWbsd.BaseCost = 0
    '              'End If

    '              newWbsd.BaseCost = Cost
    '              newWbsd.TransferBaseCost = Cost

    '              childDr("stockiw_cc") = newWbsd.CostCenter.Id
    '              childDr("stockiw_percent") = newWbsd.Percent
    '              childDr("stockiw_sequence") = row("stocki_sequence")
    '              childDr("stockiw_ismarkup") = newWbsd.IsMarkup
    '              childDr("stockiw_wbs") = newWbsd.WBS.Id
    '              childDr("stockiw_direction") = x
    '              childDr("stockiw_baseCost") = newWbsd.BaseCost
    '              childDr("stockiw_amt") = newWbsd.Amount
    '              childDr("stockiw_transferbaseCost") = newWbsd.BaseCost
    '              childDr("stockiw_transferamt") = newWbsd.Amount
    '              childDr("stockiw_toaccttype") = Me.Type.Value  'wbsd.Toaccttype

    '              'Add ��� stockiwbs
    '              dtWbs.Rows.Add(childDr)
    '              'End If
    '            End If
    '          Next
    '        Next
    '      Next
    '    End With
    '    ' First process deletes.
    '    da.Update(dtWbs.Select(Nothing, Nothing, DataViewRowState.Deleted))
    '    ' Next process updates.
    '    da.Update(dtWbs.Select(Nothing, Nothing, DataViewRowState.ModifiedCurrent))
    '    ' Finally process inserts.
    '    da.Update(dtWbs.Select(Nothing, Nothing, DataViewRowState.Added))
    '    Return New SaveErrorException("1")
    '  Catch ex As Exception
    '    Return New SaveErrorException(ex.ToString)
    '  End Try
    'End Function

    Private Function GetPritemString() As String
      Dim ret As String = "("
      For Each item As MatOperationWithdrawItem In Me.ItemCollection
        If Not item.Pritem Is Nothing Then
          ret &= "'" & item.Pritem.Pr.Id.ToString & "|" & item.Pritem.LineNumber & "',"
        End If
      Next
      ret &= "'')"
      Return ret
    End Function
    Private Function GetAmountFromSproc(ByVal sproc As String, ByVal ParamArray filters() As SqlParameter) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                RecentCompanies.CurrentCompany.SiteConnectionString _
                , CommandType.StoredProcedure _
                , sproc _
                , filters _
                )
        If ds.Tables(0).Rows(0).IsNull(0) Then
          Return 0
        End If
        Return CDec(ds.Tables(0).Rows(0)(0))
      Catch ex As Exception
      End Try
      Return 0
    End Function
    Private Function SavePRItemsDetail(ByVal arr As ArrayList, ByVal trans As SqlTransaction, ByVal conn As SqlConnection) As SaveErrorException
      Try
        For Each o As ValueDisplayPair In arr
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePRWithdrawnQty" _
          , New SqlParameter("@pri_pr", CInt(o.Value)) _
          , New SqlParameter("@pri_linenumber", CInt(o.Display)))
        Next
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
      Return New SaveErrorException("1")
    End Function

#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", Me.EntityId), New SqlParameter("@default", 1))
      Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
      Return glf
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      jiColl.AddRange(Me.GetItemJournalEntries)
      Return jiColl
    End Function
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      'Dim itemColl As New MatOperationWithdrawItemCollection(Me, False)
      'If itemColl Is Nothing Then
      '  Return jiColl
      'End If
      Dim map As String = ""
      Dim newRealAccount As Account
      Select Case Me.Type.Value
        Case 3 'Store
          map = "F1.1"
        Case 1 'WIP
          map = "F1.3"
          newRealAccount = Me.CostCenter.WipAccount
        Case 2 'Exp
          map = "F1.2"
          newRealAccount = Me.CostCenter.ExpenseAccount
      End Select
      Dim ji As New JournalEntryItem
      For Each item As MatOperationWithdrawItem In Me.ItemCollection 'itemColl
        Dim lciMatched As Boolean = False
        Dim lciNoAcctMatched As Boolean = False
        Dim originMatched As Boolean = False
        Dim newLci As LCIItem = CType(item.Entity, LCIItem)
        Dim newEntityAcct As Account
        If Not newLci.Account Is Nothing AndAlso newLci.Account.Originated Then
          newEntityAcct = newLci.Account
        End If
        If Me.Type.Value = 3 Then
          newRealAccount = newEntityAcct
        End If
        For Each addedJi As JournalEntryItem In jiColl
          If Not newRealAccount Is Nothing AndAlso newRealAccount.Originated Then
            If Not addedJi.Account Is Nothing AndAlso addedJi.Account.Id = newRealAccount.Id Then
              If addedJi.Mapping = map Then
                addedJi.Amount += item.Amount
                lciMatched = True
              End If

              '�鹷ҧ
              If addedJi.Mapping = "F1.4" Then
                addedJi.Amount += item.Amount
                originMatched = True
              End If
            End If
          ElseIf newRealAccount Is Nothing OrElse Not newRealAccount.Originated Then
            If (addedJi.Account Is Nothing OrElse Not addedJi.Account.Originated) Then
              If addedJi.Mapping = map Then
                addedJi.Amount += item.Amount
                lciNoAcctMatched = True
              End If

              '�鹷ҧ
              If addedJi.Mapping = "F1.4" Then
                addedJi.Amount += item.Amount
                originMatched = True
              End If
            End If
          End If
        Next
        Dim realAccount As Account
        Dim entityAcct As Account
        Dim lci As LCIItem = CType(item.Entity, LCIItem)
        If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
          entityAcct = lci.Account
        End If
        If Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
          '�� acct �ͧ lci
          realAccount = entityAcct
        End If
        If Not originMatched Then
          '��觵鹷ҧ
          ji = New JournalEntryItem
          ji.Mapping = "F1.4"
          ji.Amount += item.Amount
          ji.Account = realAccount
          ji.CostCenter = Me.CostCenter
          jiColl.Add(ji)

          '��觵鹷ҧ
          ji = New JournalEntryItem
          ji.Mapping = "F1.4D"
          ji.Amount += item.Amount
          ji.Account = realAccount
          ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & Configuration.FormatToString(item.StockQty, DigitConfig.Qty) & " " & item.Unit.Name & ")"
          ji.EntityItem = item.Entity.Id
          ji.EntityItemType = 42
          ji.CostCenter = Me.CostCenter
          jiColl.Add(ji)
          If item.WBSDistributeCollection Is Nothing Then
            '��觵鹷ҧ
            ji = New JournalEntryItem
            ji.Mapping = "F1.4W"
            ji.Amount += item.Amount
            ji.Account = realAccount
            ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & Configuration.FormatToString(item.StockQty, DigitConfig.Qty) & " " & item.Unit.Name & ")"
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = 42
            ji.CostCenter = Me.CostCenter
            jiColl.Add(ji)
          Else
            For Each iwbs As WBSDistribute In item.WBSDistributeCollection
              ji = New JournalEntryItem
              ji.Mapping = "F1.4W"
              ji.Amount += iwbs.Amount
              ji.Account = realAccount
              ji.Note = item.Entity.Code & ":" & item.Entity.Name & "/" & iwbs.WBS.Code & ":" & iwbs.Percent & "%"
              ' ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.Unit.Name & ")"
              ji.EntityItem = item.Entity.Id
              ji.EntityItemType = 42
              ji.CostCenter = Me.CostCenter
              jiColl.Add(ji)
            Next
          End If

        End If
        If Not newRealAccount Is Nothing AndAlso newRealAccount.Originated Then
          If Not lciMatched Then
            ji = New JournalEntryItem
            ji.Mapping = map
            ji.Amount += item.Amount
            ji.Account = newRealAccount
            ji.CostCenter = Me.CostCenter
            jiColl.Add(ji)

            ji = New JournalEntryItem
            ji.Mapping = map & "D"
            ji.Amount += item.Amount
            ji.Account = newRealAccount
            ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & Configuration.FormatToString(item.StockQty, DigitConfig.Qty) & " " & item.Unit.Name & ")"
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = 42
            ji.CostCenter = Me.CostCenter
            jiColl.Add(ji)

            If item.WBSDistributeCollection Is Nothing Then
              ji = New JournalEntryItem
              ji.Mapping = map & "W"
              ji.Amount += item.Amount
              ji.Account = newRealAccount
              ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & Configuration.FormatToString(item.StockQty, DigitConfig.Qty) & " " & item.Unit.Name & ")"
              ji.EntityItem = item.Entity.Id
              ji.EntityItemType = 42
              ji.CostCenter = Me.CostCenter
              jiColl.Add(ji)
            Else
              For Each iwbs As WBSDistribute In item.WBSDistributeCollection
                ji = New JournalEntryItem
                ji.Mapping = map & "W"
                ji.Amount += iwbs.Amount
                ji.Account = newRealAccount
                ji.Note = item.Entity.Code & ":" & item.Entity.Name & "/" & iwbs.WBS.Code & ":" & iwbs.Percent & "%"
                'ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.unit.Name & ")"
                ji.EntityItem = item.Entity.Id
                ji.EntityItemType = 42
                ji.CostCenter = Me.CostCenter
                jiColl.Add(ji)
              Next
            End If

          End If
        ElseIf newRealAccount Is Nothing OrElse Not newRealAccount.Originated Then
          If Not lciNoAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = map
            ji.Amount += item.Amount
            ji.CostCenter = Me.CostCenter
            jiColl.Add(ji)

            ji = New JournalEntryItem
            ji.Mapping = map & "D"
            ji.Amount += item.Amount
            ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & Configuration.FormatToString(item.StockQty, DigitConfig.Qty) & " " & item.Unit.Name & ")"
            ji.EntityItem = item.Entity.Id
            ji.EntityItemType = 42
            ji.CostCenter = Me.CostCenter
            jiColl.Add(ji)

            If item.WBSDistributeCollection Is Nothing Then
              ji = New JournalEntryItem
              ji.Mapping = map & "W"
              ji.Amount += item.Amount
              ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & Configuration.FormatToString(item.StockQty, DigitConfig.Qty) & " " & item.Unit.Name & ")"
              ji.EntityItem = item.Entity.Id
              ji.EntityItemType = 42
              ji.CostCenter = Me.CostCenter
              jiColl.Add(ji)
            Else
              For Each iwbs As WBSDistribute In item.WBSDistributeCollection
                ji = New JournalEntryItem
                ji.Mapping = map & "W"
                ji.Amount += iwbs.Amount
                ji.Note = item.Entity.Code & ":" & item.Entity.Name & "/" & iwbs.WBS.Code & ":" & iwbs.Percent & "%"
                'ji.Note = item.Entity.Code & ":" & item.Entity.Name & "(" & item.StockQty.ToString & " " & item.unit.Name & ")"
                ji.EntityItem = item.Entity.Id
                ji.EntityItemType = 42
                ji.CostCenter = Me.CostCenter
                jiColl.Add(ji)
              Next
            End If
          End If
        End If
      Next

      'Dim diffConversion As Decimal = 0
      'diffConversion = Me.Gross - Me.TransferGross
      'If diffConversion <> 0 Then
      '  ji = New JournalEntryItem
      '  ji.Mapping = "F1.5"
      '  ji.Amount = diffConversion
      '  ji.Account = newRealAccount
      '  ji.CostCenter = Me.FromCostCenter
      '  jiColl.Add(ji)
      'End If

      Return jiColl
    End Function
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property
#End Region

#Region "INewGLAble"
    Public Function OnlyGenGlAtom() As SaveErrorException Implements INewGLAble.OnlyGenGLAtom
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      SubSaveJeAtom(conn)
      conn.Close()
    End Function
    Private Function SubSaveJeAtom(ByVal oldconn As SqlConnection) As SaveErrorException Implements INewGLAble.SubSaveJeAtom
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()

      Me.JournalEntry.RefreshOnlyGLAtom()
      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        Me.JournalEntry.SaveAutoMateDetail(Me.JournalEntry.Id, conn, trans)
      Catch ex As Exception
        trans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.ToString)
      End Try
      trans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function
    Public Function NewGetJournalEntries() As JournalEntryItemCollection Implements INewGLAble.NewGetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      jiColl.AddRange(Me.NewGetItemJournalEntries)
      Return jiColl
    End Function
    Private Function NewGetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection
      'Dim itemColl As New MatWithdrawItemCollection(Me, False)
      'If itemColl Is Nothing Then
      '  Return jiColl
      'End If
      Dim map As String = ""
      Dim newRealAccount As Account
      Select Case Me.Type.Value
        Case 3 'Store
          map = "F1.1"
        Case 1 'WIP
          map = "F1.3"
          newRealAccount = Me.CostCenter.WipAccount
        Case 2 'Exp
          map = "F1.2"
          newRealAccount = Me.CostCenter.ExpenseAccount
      End Select
      Dim ji As New JournalEntryItem
      For Each item As MatOperationWithdrawItem In Me.ItemCollection 'itemColl
        Dim lciMatched As Boolean = False
        Dim lciNoAcctMatched As Boolean = False
        Dim originMatched As Boolean = False
        Dim newLci As LCIItem = CType(item.Entity, LCIItem)
        Dim newEntityAcct As Account
        If Not newLci.Account Is Nothing AndAlso newLci.Account.Originated Then
          newEntityAcct = newLci.Account
        End If
        If Me.Type.Value = 3 Then
          newRealAccount = newEntityAcct
        End If

        Dim realAccount As Account
        Dim entityAcct As Account
        Dim lci As LCIItem = CType(item.Entity, LCIItem)
        If Not lci.Account Is Nothing AndAlso lci.Account.Originated Then
          entityAcct = lci.Account
        End If
        If Not entityAcct Is Nothing AndAlso entityAcct.Originated Then
          '�� acct �ͧ lci
          realAccount = entityAcct
        End If
        If Not originMatched Then
          '��觵鹷ҧ
          ji = New JournalEntryItem
          ji.Mapping = "F1.4"
          ji.Amount = item.Amount
          ji.Account = realAccount
          ji.CostCenter = Me.CostCenter
          ji.EntityItem = lci.Id
          ji.EntityItemType = 42
          ji.table = Me.TableName & "item"
          ji.AtomNote = "�鹷ҧ�ԡ������ CostCenter " & Me.Type.Description
          jiColl.Add(ji)
        End If
        If Not newRealAccount Is Nothing AndAlso newRealAccount.Originated Then
          If Not lciMatched Then
            ji = New JournalEntryItem
            ji.Mapping = map
            ji.Amount = item.Amount
            ji.Account = newRealAccount
            ji.CostCenter = Me.CostCenter
            ji.EntityItem = lci.Id
            ji.EntityItemType = 42
            ji.table = Me.TableName & "item"
            ji.AtomNote = "��� CC " & Me.Type.Description
            jiColl.Add(ji)
          End If
        ElseIf newRealAccount Is Nothing OrElse Not newRealAccount.Originated Then
          If Not lciNoAcctMatched Then
            ji = New JournalEntryItem
            ji.Mapping = map
            ji.Amount = item.Amount
            ji.CostCenter = Me.CostCenter
            ji.EntityItem = lci.Id
            ji.EntityItemType = 42
            ji.table = Me.TableName & "item"
            ji.AtomNote = "��� CC " & Me.Type.Description
            jiColl.Add(ji)
          End If
        End If
      Next



      Return jiColl
    End Function
#End Region

#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "MW"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm
      Return "MW"
    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpi = New DocPrintingItem
      dpi.Mapping = "stock_id"
      dpi.Value = Me.Id
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

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

      If Not Me.ToCostCenterPerson Is Nothing AndAlso Me.ToCostCenterPerson.Originated Then
        'ToCCPersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCPersonInfo"
        dpi.Value = Me.ToCostCenterPerson.Code & ":" & Me.ToCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCPersonCode"
        dpi.Value = Me.ToCostCenterPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCPersonName"
        dpi.Value = Me.ToCostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'If Not Me.ToCostCenter Is Nothing AndAlso Me.ToCostCenter.Originated Then
      '  'ToCCInfo
      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "ToCCInfo"
      '  dpi.Value = Me.ToCostCenter.Code & ":" & Me.ToCostCenter.Name
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "ToCCCode"
      '  dpi.Value = Me.ToCostCenter.Code
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)

      '  dpi = New DocPrintingItem
      '  dpi.Mapping = "ToCCName"
      '  dpi.Value = Me.ToCostCenter.Name
      '  dpi.DataType = "System.String"
      '  dpiColl.Add(dpi)
      'End If

      If Not Me.CostCenterPerson Is Nothing AndAlso Me.CostCenterPerson.Originated Then
        'FromCCPersonInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCPersonInfo"
        dpi.Value = Me.CostCenterPerson.Code & ":" & Me.CostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCPersonCode"
        dpi.Value = Me.CostCenterPerson.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCPersonName"
        dpi.Value = Me.CostCenterPerson.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.CostCenter Is Nothing AndAlso Me.CostCenter.Originated Then
        'FromCCInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Type
      dpi = New DocPrintingItem
      dpi.Mapping = "Type"
      dpi.Value = Me.Type.Description
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim prList As String = ""
      Dim n As Integer = 0
      For Each item As MatOperationWithdrawItem In Me.ItemCollection
        dpi = New DocPrintingItem
        dpi.Mapping = "stocki_stock"
        dpi.Value = n + 1
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "stocki_sequence"
        dpi.Value = item.Sequence
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.LineNumber
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = n + 1
        dpi.DataType = "System.Int32"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        dpi.Value = item.Entity.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Unit
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Unit"
        dpi.Value = item.Unit.Name
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty"
        dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.TransferUnitPrice
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.TransferUnitPrice"
        dpi.Value = Configuration.FormatToString(item.TransferUnitPrice, DigitConfig.Qty)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.UnitCost
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UnitCost"
        dpi.Value = Configuration.FormatToString(item.UnitCost, DigitConfig.Qty)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.TransferAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.TransferAmount"
        dpi.Value = Configuration.FormatToString(item.TransferAmount, DigitConfig.Qty)
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.Note
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Note"
        dpi.Value = item.Note
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        'Item.PRCode
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.PRCode"
        If Not item.Pritem Is Nothing AndAlso Not item.Pritem.Pr Is Nothing Then
          dpi.Value = item.Pritem.Pr.Code
          If item.Pritem.Pr.Code.Length > 0 Then
            prList &= item.Pritem.Pr.Code & ","
          End If
        Else
          dpi.Value = ""
        End If
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpiColl.Add(dpi)

        n += 1
      Next

      If prList.Length > 0 Then
        prList = prList.Substring(0, prList.Length - 1)
      End If

      'PRCode
      dpi = New DocPrintingItem
      dpi.Mapping = "DescribePRCode"
      dpi.Value = prList
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Total
      dpi = New DocPrintingItem
      dpi.Mapping = "Total"
      dpi.Value = n
      dpi.DataType = "System.Int32"
      dpiColl.Add(dpi)

      'Gross
      dpi = New DocPrintingItem
      dpi.Mapping = "Gross"
      dpi.Value = Configuration.FormatToString(Me.Gross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'TransferGross
      dpi = New DocPrintingItem
      dpi.Mapping = "TransferGross"
      dpi.Value = Configuration.FormatToString(Me.TransferGross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiffConversion
      dpi = New DocPrintingItem
      dpi.Mapping = "DiffConversion"
      dpi.Value = Configuration.FormatToString(Me.Gross - Me.TransferGross, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpiColl.AddRange(GetAllocateDocPrinting)

      Return dpiColl
    End Function

    Public Function GetAllocateDocPrinting() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      For Each item As MatOperationWithdrawItem In Me.ItemCollection
        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        Dim qtyText As String = ""
        line += 1
        'Item.LineNumber
        '************** �����������ѹ��� 2
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.LineNumber"
        dpi.Value = line
        dpi.DataType = "System.Int32"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        'Item.Unit
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Unit"
        dpi.Value = item.Unit.Name
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        'Item.UnitPrice
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UnitPrice"
        If item.UnitCost = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.UnitCost, DigitConfig.UnitPrice)
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        '
        'Item.UnitPriceN
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.UnitPrice" & (i + 1).ToString
        If item.UnitCost = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.UnitCost, DigitConfig.UnitPrice)
        End If
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Item.Amount
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Amount"
        If item.Amount = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        'Item.UnitN
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Unit" & (i + 1).ToString
        dpi.Value = item.Unit.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'Item.Qty
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty"
        If item.Qty = 0 Then
          dpi.Value = ""
        Else
          dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        'Item.QtyN
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Qty" & (i + 1).ToString
        dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        qtyText = Configuration.FormatToString(item.Qty, DigitConfig.Qty) & " " & item.Unit.Name

        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"

        dpi.Value = item.Entity.Name
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        'Item.NameN
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name" & (i + 1).ToString
        dpi.Value = item.Entity.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        Dim grpAllocate As New List(Of String)
        Dim i2 As Integer = 1

        For Each dis As WBSDistribute In item.WBSDistributeCollection
          line += 1

          dpi = New DocPrintingItem
          dpi.Mapping = "stockiw_sequence"
          dpi.Value = item.Sequence
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCostCenter
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCostCenter"
          dpi.Value = dis.CostCenter.Code & ":" & dis.CostCenter.Name
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCode"
          dpi.Value = dis.WBS.Code
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSName"
          dpi.Value = dis.WBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSinfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSInfo"
          dpi.Value = dis.WBS.Code & ":" & dis.WBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSCode"
          dpi.Value = dis.CBS.Code
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSName"
          dpi.Value = dis.CBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSinfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSInfo"
          dpi.Value = dis.CBS.Code & ":" & dis.CBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCodePercent
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodePercent"
          dpi.Value = dis.WBS.Code & ":" & dis.CBS.Code & "=>" & Configuration.FormatToString(dis.Percent, DigitConfig.Price) & "%"
          grpAllocate.Add(dis.WBS.Code & ":" & dis.CBS.Code & "=>" & Configuration.FormatToString(dis.Percent, DigitConfig.Price) & "%")
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Percent
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Percent"
          dpi.Value = Configuration.FormatToString(dis.Percent, DigitConfig.Price) & "%"
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCodeAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodeAmount"
          dpi.Value = dis.WBS.Code & ":" & dis.CBS.Code & "=>" & Configuration.FormatToString(dis.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          dpi.Value = Configuration.FormatToString(dis.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.BudgetAmount"
          dpi.Value = dis.BudgetAmount
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainAmount"
          dpi.Value = dis.BudgetRemain
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          ''Item.WBSRemainAmount
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Item.AmountOverBudget"
          'dpi.Value = dis.AmountOverBudget
          'dpi.DataType = "System.String"
          'dpi.Row = i + 1
          'dpi.Table = "Allocate"
          'dpiColl.Add(dpi)

          'Item.WBSRemainQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSBudgetQty"
          dpi.Value = dis.BudgetQty
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainQty"
          dpi.Value = dis.QtyRemain
          dpi.DataType = "System.String"
          dpi.Row = i + i2 + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          ''Item.WBSRemainAmount
          'dpi = New DocPrintingItem
          'dpi.Mapping = "Item.QtyOverBudget"
          'dpi.Value = dis.QtyRemain
          'dpi.DataType = "System.String"
          'dpi.Row = i + 1
          'dpi.Table = "Allocate"
          'dpiColl.Add(dpi)
          '--------------------- WBS Section ------------------
          i2 += 1
        Next

        'Item.WBSCodePercent
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.groupWBSCodePercent"
        dpi.Value = String.Join(",", grpAllocate)
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        ''Item.Note
        'dpi = New DocPrintingItem
        'dpi.Mapping = "Item.Note"
        'dpi.Value = item.Note
        'dpi.DataType = "System.String"
        'dpi.Row = i + 1
        'dpi.Table = "Allocate"
        'dpiColl.Add(dpi)

        ''Item.LciNote
        'If TypeOf item.Entity Is IHasNote Then
        '  dpi = New DocPrintingItem
        '  dpi.Mapping = "Item.LciNote"
        '  dpi.Value = CType(item.Entity, IHasNote).Note
        '  dpi.DataType = "System.String"
        '  dpi.Row = i + 1
        '  dpi.Table = "Allocate"
        '  dpiColl.Add(dpi)
        'End If

        ''Item.NoteN
        'dpi = New DocPrintingItem
        'dpi.Mapping = "Item.Note" & (i + 1).ToString
        'dpi.Value = item.Note
        'dpi.DataType = "System.String"
        'dpiColl.Add(dpi)


        ''Item.Description '''For Sitem ��੾��
        'dpi = New DocPrintingItem
        'dpi.Mapping = "Item.Description"
        'If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
        '  dpi.Value = item.EntityName & vbCrLf & qtyText
        'Else
        '  dpi.Value = item.Entity.Name & vbCrLf & qtyText
        'End If
        'dpi.DataType = "System.String"
        'dpi.Row = i + 1
        'dpi.Table = "Allocate"
        'dpiColl.Add(dpi)

        i += 1 + i2

      Next



      Return dpiColl
    End Function
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
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteMatWithdraw}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If

      Dim prIdList As String = String.Join(",", Me.GetPrList.ToArray)
      Dim stockIdList As String = String.Join(",", Me.GetStockList.ToArray)

      '  '-------------------------------------------------------
      '  Dim pris As String = GetPritemString()
      '  Dim sql As String = "select * from pritem where convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) " & _
      '  "in (select convert(nvarchar,stocki_refdoc) + '|' +  convert(nvarchar,stocki_refdoclinenumber) from stockitem " & _
      '  "where stocki_stock=" & Me.Id & ") or convert(nvarchar,pri_pr) + '|' +  convert(nvarchar,pri_linenumber) in " & pris

      '  Dim ds As DataSet = SqlHelper.ExecuteDataset( _
      'RecentCompanies.CurrentCompany.SiteConnectionString _
      ', CommandType.Text _
      ', sql _
      ')
      '  Dim arr As New ArrayList
      '  For Each row As DataRow In ds.Tables(0).Rows
      '    Dim o As New ValueDisplayPair(row("pri_pr"), row("pri_linenumber"))
      '    arr.Add(o)
      '  Next
      '-------------------------------------------------------
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteMatOperationWithdraw", New SqlParameter() {New SqlParameter("@" & Me.Prefix & "_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.MatWithdrawIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        Me.DeleteRef(conn, trans)


        ''--------------------------------------------------------------
        'Dim oldid As Integer = Me.Id
        'Dim oldjeid As Integer = Me.m_je.Id
        'Dim savePRItemsError As SaveErrorException = Me.SavePRItemsDetail(arr, trans, conn)
        'If Not IsNumeric(savePRItemsError.Message) Then
        '  trans.Rollback()
        '  ResetId(oldid, oldjeid)
        '  Return savePRItemsError
        'Else
        '  Select Case CInt(savePRItemsError.Message)
        '    Case -1, -5
        '      trans.Rollback()
        '      ResetId(oldid, oldjeid)
        '      Return savePRItemsError
        '    Case -2
        '      'Post �����
        '      Return savePRItemsError
        '    Case Else
        '  End Select
        'End If
        ''--------------------------------------------------------------

        trans.Commit()

      Catch ex As SqlException
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Finally
        conn.Close()
      End Try

      Try
        SaveWBSActual(conn)
      Catch ex As Exception
        Return New SaveErrorException(ex.Message)
      End Try

      Try
        PR.UpdateReferencePRList(conn, prIdList)
        GoodsReceipt.UpdateReferenceGoodsReceiptList(conn, stockIdList)
      Catch ex As Exception
        Return New SaveErrorException(ex.Message)
      End Try

      Return New SaveErrorException("1")
    End Function
#End Region

#Region "ICancelable"
    Public ReadOnly Property CanCancel() As Boolean Implements ICancelable.CanCancel
      Get
        Return Me.Status.Value > 1 AndAlso Me.IsCancelable
      End Get
    End Property
    Public Function CancelEntity(ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements ICancelable.CancelEntity
      Me.Status.Value = 0
      Return Me.Save(currentUserId)
    End Function
#End Region

    'Public Property FromCC() As CostCenter Implements IHasFromCostCenter.FromCC
    '  Get
    '    '  Return Me.FromCostCenter
    '  End Get
    '  Set(ByVal Value As CostCenter)
    '    '  Me.FromCostCenter = Value
    '  End Set
    'End Property

    'Public Property ToCC() As CostCenter Implements IHasToCostCenter.ToCC
    '  Get
    '    Return Me.ToCostCenter
    '  End Get
    '  Set(ByVal Value As CostCenter)
    '    Me.ToCostCenter = Value
    '  End Set
    'End Property

#Region "IWBSAllocatable"
    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As MatOperationWithdrawItem In Me.ItemCollection
        'If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
        item.UpdateWBSQty()

        If Not Me.Originated Then
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsd.ChildAmount = 0
            wbsd.GetChildIdList()
            For Each allItem As MatOperationWithdrawItem In Me.ItemCollection
              For Each childWbsd As WBSDistribute In allItem.WBSDistributeCollection
                If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                  wbsd.ChildAmount += childWbsd.Amount
                End If
              Next
            Next
          Next
          'For Each wbsd As WBSDistribute In item.InWbsdColl
          '  wbsd.ChildAmount = 0
          '  wbsd.GetChildIdList()
          '  For Each allItem As MatOperationWithdrawItem In Me.ItemCollection
          '    For Each childWbsd As WBSDistribute In allItem.InWbsdColl
          '      If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
          '        wbsd.ChildAmount += childWbsd.Amount
          '      End If
          '    Next
          '  Next
          'Next
        End If

        coll.Add(item)
        'End If
      Next
      Return coll
    End Function

    Public Property Supplier As Supplier Implements IWBSAllocatable.Supplier
      Get

      End Get
      Set(ByVal value As Supplier)

      End Set
    End Property
#End Region

#Region "AllowWBSAllocateFrom"
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

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      dpiColl.RelationList.Add("general>stock_id>Item>stocki_stock")
      dpiColl.RelationList.Add("Item>stocki_sequence>Allocate>stockiw_sequence")

      'Allocate

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stock_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCCPersonInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCCPersonCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ToCCPersonName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCPersonInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCPersonCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCPersonName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("FromCCName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Type", "System.String"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stocki_stock", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stocki_sequence", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.TransferUnitPrice", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitCost", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.TransferAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.PRCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.DescribePRCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Item"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Total", "System.Int32"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Gross", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TransferGross", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DiffConversion", "System.String"))

      dpiColl.AddRange(GetAllocateDocPrintingColumns)

      Return dpiColl
    End Function

    Public Function GetAllocateDocPrintingColumns() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("stockiw_sequence", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Code", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.Int32", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPrice", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCostCenter", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCode", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSName", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSInfo", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.CBSCode", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.CBSName", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.CBSInfo", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodePercent", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Percent", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodeAmount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.BudgetAmount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainAmount", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSBudgetQty", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainQty", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.groupWBSCodePercent", "System.String", "Allocate"))

      Return dpiColl
    End Function

    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region

#Region "IDocStatus"
    Public ReadOnly Property DocStatus As String Implements IDocStatus.DocStatus
      Get
        If Me.Status.Value = 0 Then
          Return "Canceled"
        Else
          'Dim obj As Object = Configuration.GetConfig("ApprovePR")
          'If CBool(obj) Then
          '  If Me.IsAuthorized Then
          '    Return "Authorized"
          '  ElseIf Me.IsLevelApproved Then
          '    Return "Approved"
          '  End If
          'End If
        End If
        Return ""
      End Get
    End Property
#End Region

#Region "IAbleValidateItemQuantity"
    Public ReadOnly Property ItemEntityHashTable As System.Collections.Hashtable Implements IAbleValidateItemQuantity.ItemEntityHashTable
      Get
        Dim newhs As New Hashtable
        Dim entityId As Integer
        For Each item As MatOperationWithdrawItem In ItemCollection
          entityId = item.Entity.Id
          If Not newhs.ContainsKey(entityId) Then
            newhs(entityId) = item.StockQty
          Else
            newhs(entityId) = CDec(newhs(entityId)) + item.StockQty
          End If
        Next
        Return newhs
      End Get
    End Property
#End Region

  End Class

End Namespace
