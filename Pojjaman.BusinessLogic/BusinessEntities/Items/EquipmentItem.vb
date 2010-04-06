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
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class EquipmentItem

#Region "Members"
    Private m_equipment As Equipment

    'Private m_lineNumber As Integer
    'Private m_itemType As ItemType
    'Private m_entity As IHasName
    'Private m_entityName As String
    'Private m_unit As Unit
    'Public m_qty As Decimal
    'Private m_originQty As Decimal
    'Private m_orderedQty As Decimal
    'Private m_withdrawnQty As Decimal
    'Private m_note As String
    'Private m_conversion As Decimal = 1

    'Private m_unitprice As Decimal

    'Private m_WBSDistributeCollection As WBSDistributeCollection
    Private m_id As Integer
    Private m_code As String
    Private m_name As String
    Private m_cc As CostCenter
    Private m_buydate As DateTime
    'Private m_buydoc As Decimal
    'Private m_buydoccode As String
    Private m_buydoc As ISimpleEntity
    Private m_buycost As Decimal
    Private m_buysupplier As Supplier
    Private m_asset As Asset
    Private m_acctstatus As Integer
    Private m_serailnumber As String
    Private m_brand As String
    Private m_license As String
    Private m_description As String
    Private m_unit As Unit 'Munit
    Private m_rentalrate As Decimal
    Private m_rentalunit As Unit
    Private m_lastEditDate As DateTime
    Private m_autogen As Boolean

#End Region

#Region "Constructors"
    'Public Sub New()
    '  MyBase.New()
    '  m_WBSDistributeCollection = New WBSDistributeCollection
    '  AddHandler m_WBSDistributeCollection.PropertyChanged, AddressOf Me.WBSChangedHandler
    'End Sub
    'Public Sub New(ByVal id As Integer, ByVal line As Integer)
    '  Dim connString As String = RecentCompanies.CurrentCompany.ConnectionString
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(connString _
    '  , CommandType.StoredProcedure _
    '  , "GetEquipmentItems" _
    '  , New SqlParameter("@pr_id", id) _
    '  , New SqlParameter("@pri_linenumber", line) _
    '  )
    '  Me.Construct(ds.Tables(0).Rows(0), "")
    '  Dim wbsdColl As WBSDistributeCollection = New WBSDistributeCollection
    '  AddHandler wbsdColl.PropertyChanged, AddressOf Me.WBSChangedHandler
    '  m_WBSDistributeCollection = wbsdColl
    '  If ds.Tables.Count > 1 Then
    '    For Each wbsRow As DataRow In ds.Tables(1).Select("priw_prilinenumber=" & Me.LineNumber)
    '      Dim wbsd As New WBSDistribute(wbsRow, "")
    '      wbsdColl.Add(wbsd)
    '    Next
    '  End If
    'End Sub
    Public Sub New()

    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
      With Me
        Dim drh As New DataRowHelper(dr)

        'Dim eqid As Integer = drh.GetValue(Of Integer)("eqi_id")
        'm_equipment = New Equipment(eqid)

        m_id = drh.GetValue(Of Integer)("eqi_id")
        m_code = drh.GetValue(Of String)("eqi_code")
        m_name = drh.GetValue(Of String)("eqi_name")

        Dim ccid As Integer = drh.GetValue(Of Integer)("eqi_cc")
        m_cc = New CostCenter(ccid)

        m_buydate = drh.GetValue(Of DateTime)("eqi_buydate")
        m_lastEditDate = drh.GetValue(Of DateTime)("eqi_lastEditDate")
        m_buydoc = New SimpleBusinessEntityBase
        m_buydoc.Id = drh.GetValue(Of Integer)("eqi_buydoc")
        m_buydoc.Code = drh.GetValue(Of String)("eqi_buydoccode")

        m_buycost = drh.GetValue(Of Decimal)("eqi_buycost")

        Dim supplierid As Integer = drh.GetValue(Of Integer)("eqi_buysupplier")
        m_buysupplier = New Supplier(supplierid)

        Dim assetid As Integer = drh.GetValue(Of Integer)("eqi_asset")
        m_asset = New Asset(assetid)

        m_acctstatus = drh.GetValue(Of Integer)("eqi_acctstatus")

        m_serailnumber = drh.GetValue(Of String)("eqi_serialnumber")

        m_brand = drh.GetValue(Of String)("eqi_brand")

        m_license = drh.GetValue(Of String)("eqi_license")

        m_description = drh.GetValue(Of String)("eqi_description")

        Dim unitid As Integer = drh.GetValue(Of Integer)("eqi_unit")
        m_unit = New Unit(unitid)

        m_rentalrate = drh.GetValue(Of Decimal)("eqi_rentalrate")

        Dim unitid2 As Integer = drh.GetValue(Of Integer)("eqi_rentalunit")
        m_rentalunit = New Unit(unitid2)


      End With
    End Sub
    Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Me.Construct(dr, aliasPrefix)
    End Sub
#End Region

#Region "Properties"
    Public Property Equipment As Equipment
      Get
        Return m_equipment
      End Get
      Set(ByVal value As Equipment)
        m_equipment = value
      End Set
    End Property
    Public Property Id As Integer
      Get
        Return m_id
      End Get
      Set(ByVal value As Integer)
        m_id = value
      End Set
    End Property
    Public Property Autogen As Boolean
      Get
        Return m_autogen
      End Get
      Set(ByVal value As Boolean)
        m_autogen = value
      End Set
    End Property
    Public Property Code As String
      Get
        Return m_code
      End Get
      Set(ByVal value As String)
        m_code = value
      End Set
    End Property
    Public Property Name As String
      Get
        Return m_name
      End Get
      Set(ByVal value As String)
        m_name = value
      End Set
    End Property
    Public Property Costcenter As CostCenter
      Get
        Return m_cc
      End Get
      Set(ByVal value As CostCenter)
        m_cc = value
      End Set
    End Property
    Public Property Buydate As DateTime
      Get
        Return m_buydate
      End Get
      Set(ByVal value As DateTime)
        m_buydate = value
      End Set
    End Property
    Public Property LastEditDate As DateTime
      Get
        Return m_lastEditDate
      End Get
      Set(ByVal value As DateTime)
        m_lastEditDate = value
      End Set
    End Property
    Public Property Buydoc As ISimpleEntity
      Get
        Return m_buydoc
      End Get
      Set(ByVal value As ISimpleEntity)
        m_buydoc = value
      End Set
    End Property
   
    Public Property Buycost As Decimal
      Get
        Return m_buycost
      End Get
      Set(ByVal value As Decimal)
        m_buycost = value
      End Set
    End Property
    Public Property Supplier As Supplier
      Get
        Return m_buysupplier
      End Get
      Set(ByVal value As Supplier)
        m_buysupplier = value
      End Set
    End Property
    Public Property Asset As Asset
      Get
        Return m_asset
      End Get
      Set(ByVal value As Asset)
        m_asset = value
      End Set
    End Property

    Public Property Acctstatus As Integer
      Get
        Return m_acctstatus
      End Get
      Set(ByVal value As Integer)
        m_acctstatus = value
      End Set
    End Property
    Public Property Serailnumber As String
      Get
        Return m_serailnumber
      End Get
      Set(ByVal value As String)
        m_serailnumber = value
      End Set
    End Property
    Public Property Brand As String
      Get
        Return m_brand
      End Get
      Set(ByVal value As String)
        m_brand = value
      End Set
    End Property
    Public Property License As String
      Get
        Return m_license
      End Get
      Set(ByVal value As String)
        m_license = value
      End Set
    End Property
    Public Property Description As String
      Get
        Return m_description
      End Get
      Set(ByVal value As String)
        m_description = value
      End Set
    End Property
    Public Property Unit As Unit
      Get
        Return m_unit
      End Get
      Set(ByVal value As Unit)
        m_unit = value
      End Set
    End Property
    Public Property Rentalrate As Decimal
      Get
        Return m_rentalrate
      End Get
      Set(ByVal value As Decimal)
        m_rentalrate = value
      End Set
    End Property
    Public Property Rentalunit As Unit
      Get
        Return m_rentalunit
      End Get
      Set(ByVal value As Unit)
        m_rentalunit = value
      End Set
    End Property

#End Region

    Public Sub Clear()
      'Me.m_entity = New BlankItem("")
      'Me.m_entityName = ""
      'Me.m_qty = 0
      'Me.m_originQty = 0
      'Me.m_orderedQty = 0
      'Me.m_unit = New Unit
      'Me.m_unitprice = 0
      'Me.m_note = ""
    End Sub
    Public Sub CopyToDataRow(ByVal row As TreeRow)
      If row Is Nothing Then
        Return
      End If

      Try
        '    Me.Pr.IsInitialized = False
        row("code") = Me.Code
        row("name") = Me.Name
        row("status") = "��ҧ����"
        row("costcenter") = Me.Costcenter.Code
        '    Me.Pr.IsInitialized = True
      Catch ex As Exception
        MessageBox.Show(ex.Message & "::" & ex.StackTrace)
      End Try

    End Sub

  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class EquipmentItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_equipment As Equipment
    Private m_currentItem As EquipmentItem
#End Region

#Region "Constructors"
    Public Sub New(ByVal owner As Equipment)
      Me.m_equipment = owner
      If Not Me.m_equipment.Originated Then
        Return
      End If

      Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString

      Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString _
      , CommandType.StoredProcedure _
      , "GetEquipmentItems" _
      , New SqlParameter("@equipment_id", Me.m_equipment.Id) _
      )

      For Each row As DataRow In ds.Tables(0).Rows
        Dim item As New EquipmentItem(row, "")
        item.equipment = m_equipment
        Me.Add(item)
      Next
    End Sub
#End Region

#Region "Properties"
    Default Public Property Item(ByVal index As Integer) As EquipmentItem
      Get
        Return CType(MyBase.List.Item(index), EquipmentItem)
      End Get
      Set(ByVal value As EquipmentItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    'Public ReadOnly Property Amount() As Decimal
    '  Get
    '    Dim amt As Decimal = 0
    '      amt += Configuration.Format(item.Amount, DigitConfig.Price)
    '    Next
    '    Return amt
    '  End Get
    'End Property
    Public Property CurrentItem() As EquipmentItem
      Get
        Return m_currentItem
      End Get
      Set(ByVal Value As EquipmentItem)
        m_currentItem = Value
      End Set
    End Property
#End Region

#Region "Shared"
    'Public Shared Function CreateListTableStyle() As DataGridTableStyle
    '  Dim dst As New DataGridTableStyle
    '  dst.MappingName = "EquipmentItems"

    '  Dim csSelected As New DataGridCheckBoxColumn
    '  csSelected.MappingName = "Selected"
    '  csSelected.HeaderText = ""

    '  Dim csDescription As New PlusMinusTreeTextColumn
    '  csDescription.MappingName = "Entity"
    '  csDescription.HeaderText = "Entity"
    '  csDescription.NullText = ""
    '  csDescription.Width = 180
    '  csDescription.ReadOnly = True

    '  Dim csQty As New TreeTextColumn
    '  csQty.MappingName = "Qty"
    '  csQty.HeaderText = "Qty"
    '  csQty.NullText = ""
    '  csQty.ReadOnly = True

    '  Dim csOrderedQty As New TreeTextColumn
    '  csOrderedQty.MappingName = "OrderedQty"
    '  csOrderedQty.HeaderText = "OrderedQty"
    '  csOrderedQty.NullText = ""
    '  csOrderedQty.ReadOnly = True

    '  Dim csDate As New TreeTextColumn
    '  csDate.MappingName = "DummyDate"
    '  csDate.HeaderText = "Date"
    '  csDate.NullText = ""
    '  csDate.DataAlignment = HorizontalAlignment.Center
    '  csDate.Width = 100
    '  csDate.Format = "d"
    '  csDate.ReadOnly = True

    '  Dim csReceivingDate As New TreeTextColumn
    '  csReceivingDate.MappingName = "DummyReceivingDate"
    '  csReceivingDate.HeaderText = "ReceivingDate"
    '  csReceivingDate.NullText = ""
    '  csReceivingDate.DataAlignment = HorizontalAlignment.Center
    '  csReceivingDate.Width = 100
    '  csReceivingDate.Format = "d"
    '  csReceivingDate.ReadOnly = True

    '  Dim csRequestor As New TreeTextColumn
    '  csRequestor.MappingName = "Requestor"
    '  csRequestor.HeaderText = "Requestor"
    '  csRequestor.NullText = ""
    '  csRequestor.DataAlignment = HorizontalAlignment.Center
    '  csRequestor.Width = 100
    '  csRequestor.ReadOnly = True

    '  Dim csCostCenter As New TreeTextColumn
    '  csCostCenter.MappingName = "CostCenter"
    '  csCostCenter.HeaderText = "CostCenter"
    '  csCostCenter.NullText = ""
    '  csCostCenter.DataAlignment = HorizontalAlignment.Center
    '  csCostCenter.Width = 100
    '  csCostCenter.ReadOnly = True

    '  dst.GridColumnStyles.Add(csSelected)
    '  dst.GridColumnStyles.Add(csDescription)
    '  dst.GridColumnStyles.Add(csQty)
    '  dst.GridColumnStyles.Add(csOrderedQty)
    '  dst.GridColumnStyles.Add(csDate)
    '  dst.GridColumnStyles.Add(csReceivingDate)
    '  'dst.GridColumnStyles.Add(csRequestor)
    '  'dst.GridColumnStyles.Add(csCostCenter)
    '  Return dst
    'End Function
    'Public Shared Function GetListDatatable(ByVal ParamArray filters() As Filter) As TreeTable

    '  Dim sqlConString As String = RecentCompanies.CurrentCompany.ConnectionString
    '  Dim params() As SqlParameter
    '  If Not filters Is Nothing AndAlso filters.Length > 0 Then
    '    ReDim params(filters.Length - 1)
    '    For i As Integer = 0 To filters.Length - 1
    '      params(i) = New SqlParameter("@" & filters(i).Name, filters(i).Value)
    '    Next
    '  End If
    '  Dim dt As DataTable
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(sqlConString, CommandType.StoredProcedure, "GetEquipmentItemsList", params)
    '  dt = ds.Tables(0)

    '  Dim myDatatable As New TreeTable("EquipmentItems")
    '  myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
    '  myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("m_pr", GetType(Integer)))
    '  myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("OrderedQty", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("DummyDate", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("ReceivingDate", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("DummyReceivingDate", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("Requestor", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))

    '  For Each tableRow As DataRow In dt.Rows
    '    Dim pri As New EquipmentItem(tableRow, "")
    '    Dim row As TreeRow = myDatatable.Childs.Add
    '    row("Selected") = False
    '    row("Code") = tableRow("pr_code")
    '    row("m_pr") = tableRow("pri_pr")
    '    row("Linenumber") = tableRow("pri_linenumber")
    '    row("Date") = tableRow("pr_docdate")
    '    row("ReceivingDate") = tableRow("pr_receivingdate")

    '    Dim entityText As String = ""
    '    If Not pri.ItemType Is Nothing Then
    '      entityText &= pri.ItemType.Description & ":"
    '    End If
    '    If Not pri.Entity.Code Is Nothing AndAlso pri.Entity.Code.Length > 0 Then
    '      entityText &= pri.Entity.Code & ":"
    '    End If
    '    If Not pri.Entity.Name Is Nothing AndAlso pri.Entity.Name.Length > 0 Then
    '      entityText &= pri.Entity.Name
    '    End If
    '    row("Entity") = entityText
    '    row("Qty") = pri.Qty
    '    row("OrderedQty") = pri.OrderedQty
    '    row("Requestor") = tableRow("requestorinfo")
    '    row("CostCenter") = tableRow("ccinfo")
    '    row.State = RowExpandState.None
    '  Next
    '  Return myDatatable
    'End Function
#End Region

#Region "Class Methods"

    'Public Sub SetItems(ByVal items As BasketItemCollection, Optional ByVal targetType As Integer = -1)
    '  For i As Integer = 0 To items.Count - 1
    '    If Not TypeOf items(i) Is StockBasketItem Then
    '      '-----------------LCI Items--------------------

    '      Dim item As BasketItem = CType(items(i), BasketItem)
    '      Dim newItem As IHasName
    '      Dim newType As Integer = -1
    '      Select Case item.FullClassName.ToLower
    '        Case "longkong.pojjaman.businesslogic.lciitem"
    '          newItem = New LCIItem(item.Id)
    '          If targetType > -1 Then
    '            newType = targetType
    '          Else
    '            newType = 42
    '          End If

    '        Case "longkong.pojjaman.businesslogic.tool"
    '          newItem = New Tool(item.Id)
    '          newType = 19

    '      End Select

    '      Dim doc As New EquipmentItem
    '      If Not Me.CurrentItem Is Nothing Then
    '        doc = Me.CurrentItem
    '        doc.ItemType.Value = newType
    '        Me.CurrentItem = Nothing
    '      Else
    '        Me.Add(doc)
    '        doc.ItemType = New ItemType(newType)
    '      End If
    '      doc.SetItemPrice(newItem.Code)
    '      doc.SetItemCode(newItem.Code)
    '    ElseIf TypeOf items(i).Tag Is BoqItem Then
    '      '-----------------BOQ Items--------------------
    '      Dim bitem As BoqItem = CType(items(i).Tag, BoqItem)
    '      If bitem.ItemType.Value = 18 Then         '����ç
    '        bitem.ItemType.Value = 88
    '        bitem.Entity.Id = 0
    '      End If
    '      If bitem.ItemType.Value = 20 Then         '�������ͧ�ѡ�
    '        bitem.ItemType.Value = 89
    '        bitem.Entity.Id = 0
    '      End If

    '      Dim matWbsd As New WBSDistribute
    '      Dim labWbsd As New WBSDistribute
    '      Dim eqWbsd As New WBSDistribute

    '      Dim matDoc As EquipmentItem
    '      Dim labDoc As EquipmentItem
    '      Dim eqDoc As EquipmentItem
    '      Dim itemType As Integer
    '      itemType = bitem.ItemType.Value
    '      Select Case bitem.ItemType.Value
    '        Case 42, 0
    '          If bitem.UMC <> 0 Then              'mat
    '            matDoc = New EquipmentItem
    '            If Me.Count = 0 Then
    '              Me.Add(matDoc)
    '            Else
    '              If Not Me.CurrentItem Is Nothing Then
    '                matDoc = Me.CurrentItem
    '              Else
    '                Me.Add(matDoc)
    '              End If
    '            End If
    '            matDoc.ItemType = New ItemType(bitem.ItemType.Value)
    '            If bitem.ItemType.Value = 0 Then
    '              matDoc.EntityName = bitem.EntityName
    '            Else
    '              matDoc.Entity = bitem.Entity
    '            End If
    '            matDoc.Unit = bitem.Unit
    '            matDoc.Qty = bitem.Qty
    '            matDoc.UnitPrice = bitem.UMC

    '            If Not bitem.WBS Is Nothing Then
    '              matWbsd.IsMarkup = False
    '              matWbsd.CostCenter = Me.m_pr.CostCenter
    '              matWbsd.WBS = bitem.WBS
    '              matWbsd.Percent = 100
    '              matWbsd.BaseCost = bitem.TotalMaterialCost
    '              matWbsd.TransferBaseCost = bitem.TotalMaterialCost
    '              matWbsd.IsOutWard = False
    '              matWbsd.Toaccttype = 3
    '            End If
    '          End If
    '          If bitem.ULC <> 0 Then              '88 -> Lab
    '            labDoc = New EquipmentItem
    '            If Me.Count = 0 Then
    '              Me.Add(labDoc)
    '            Else
    '              If Not Me.CurrentItem Is Nothing Then
    '                labDoc = Me.CurrentItem
    '              Else
    '                Me.Add(labDoc)
    '              End If
    '            End If
    '            labDoc.ItemType = New ItemType(88)
    '            If itemType = 42 Then
    '              labDoc.Entity = bitem.Entity
    '              labDoc.EntityName = bitem.Entity.Name
    '            Else
    '              labDoc.EntityName = bitem.Entity.Name
    '            End If
    '            labDoc.Unit = bitem.Unit
    '            labDoc.Qty = bitem.Qty
    '            labDoc.UnitPrice = bitem.ULC
    '            If Not bitem.WBS Is Nothing Then
    '              labWbsd.IsMarkup = False
    '              labWbsd.CostCenter = Me.m_pr.CostCenter
    '              labWbsd.WBS = bitem.WBS
    '              labWbsd.Percent = 100
    '              labWbsd.BaseCost = bitem.TotalLaborCost
    '              labWbsd.TransferBaseCost = bitem.TotalLaborCost
    '              labWbsd.IsOutWard = False
    '              labWbsd.Toaccttype = 3
    '            End If
    '          End If
    '          If bitem.UEC <> 0 Then              '89 -> EQ
    '            eqDoc = New EquipmentItem
    '            If Me.Count = 0 Then
    '              Me.Add(eqDoc)
    '            Else
    '              If Not Me.CurrentItem Is Nothing Then
    '                eqDoc = Me.CurrentItem
    '              Else
    '                Me.Add(eqDoc)
    '              End If
    '            End If
    '            eqDoc.ItemType = New ItemType(89)
    '            If itemType = 42 Then
    '              eqDoc.Entity = bitem.Entity
    '              eqDoc.EntityName = bitem.Entity.Name
    '            Else
    '              eqDoc.EntityName = bitem.Entity.Name
    '            End If
    '            eqDoc.Unit = bitem.Unit
    '            eqDoc.Qty = bitem.Qty
    '            eqDoc.UnitPrice = bitem.UEC
    '            If Not bitem.WBS Is Nothing Then
    '              eqWbsd.IsMarkup = False
    '              eqWbsd.CostCenter = Me.m_pr.CostCenter
    '              eqWbsd.WBS = bitem.WBS
    '              eqWbsd.Percent = 100
    '              eqWbsd.BaseCost = bitem.TotalEquipmentCost
    '              eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
    '              eqWbsd.IsOutWard = False
    '              eqWbsd.Toaccttype = 3
    '            End If
    '          End If
    '        Case 88, 89
    '          Dim doc As EquipmentItem
    '          Dim tempUnitPrice As Decimal
    '          If Me.Count = 0 Then
    '            If bitem.ItemType.Value = 88 Then
    '              labDoc = New EquipmentItem
    '              doc = labDoc
    '              tempUnitPrice = bitem.ULC
    '            End If
    '            If bitem.ItemType.Value = 89 Then
    '              eqDoc = New EquipmentItem
    '              doc = eqDoc
    '              tempUnitPrice = bitem.UEC
    '            End If
    '            Me.Add(doc)
    '          Else
    '            If bitem.ItemType.Value = 88 Then
    '              labDoc = New EquipmentItem
    '              If Not Me.CurrentItem Is Nothing Then
    '                labDoc = Me.CurrentItem
    '              Else
    '                Me.Add(labDoc)
    '              End If
    '              doc = labDoc
    '              tempUnitPrice = bitem.ULC
    '            End If
    '            If bitem.ItemType.Value = 89 Then
    '              eqDoc = New EquipmentItem
    '              If Not Me.CurrentItem Is Nothing Then
    '                eqDoc = Me.CurrentItem
    '              Else
    '                Me.Add(eqDoc)
    '              End If
    '              doc = eqDoc
    '              tempUnitPrice = bitem.UEC
    '            End If
    '          End If

    '          doc.ItemType = New ItemType(bitem.ItemType.Value)
    '          doc.Entity = bitem.Entity
    '          doc.EntityName = bitem.Entity.Name
    '          doc.Unit = bitem.Unit
    '          doc.Qty = bitem.Qty
    '          doc.UnitPrice = tempUnitPrice
    '          If bitem.ItemType.Value = 88 Then
    '            If Not bitem.WBS Is Nothing Then
    '              labWbsd.IsMarkup = False
    '              labWbsd.CostCenter = Me.m_pr.CostCenter
    '              labWbsd.WBS = bitem.WBS
    '              labWbsd.Percent = 100
    '              labWbsd.BaseCost = bitem.TotalLaborCost
    '              labWbsd.TransferBaseCost = bitem.TotalLaborCost
    '              labWbsd.IsOutWard = False
    '              labWbsd.Toaccttype = 3
    '            End If
    '          End If
    '          If bitem.ItemType.Value = 89 Then
    '            If Not bitem.WBS Is Nothing Then
    '              eqWbsd.IsMarkup = False
    '              eqWbsd.CostCenter = Me.m_pr.CostCenter
    '              eqWbsd.WBS = bitem.WBS
    '              eqWbsd.Percent = 100
    '              eqWbsd.BaseCost = bitem.TotalEquipmentCost
    '              eqWbsd.TransferBaseCost = bitem.TotalEquipmentCost
    '              eqWbsd.IsOutWard = False
    '              eqWbsd.Toaccttype = 3
    '            End If
    '          End If
    '      End Select

    '      If matWbsd.Percent = 100 Then
    '        If Not matDoc Is Nothing Then
    '          matDoc.WBSDistributeCollection.Add(matWbsd)
    '          matDoc.Pr.SetActual(matWbsd.WBS, 0, matDoc.Amount, matDoc.ItemType.Value)
    '        End If
    '      End If
    '      If labWbsd.Percent = 100 Then
    '        If Not labDoc Is Nothing Then
    '          labDoc.WBSDistributeCollection.Add(labWbsd)
    '          labDoc.Pr.SetActual(labWbsd.WBS, 0, labDoc.Amount, labDoc.ItemType.Value)
    '        End If
    '      End If
    '      If eqWbsd.Percent = 100 Then
    '        If Not eqDoc Is Nothing Then
    '          eqDoc.WBSDistributeCollection.Add(eqWbsd)
    '          eqDoc.Pr.SetActual(eqWbsd.WBS, 0, eqDoc.Amount, eqDoc.ItemType.Value)
    '        End If
    '      End If

    '    End If
    '  Next
    '  RefreshBudget()
    'End Sub

    Public Sub Populate(ByVal dt As TreeTable)
      dt.Clear()
      Dim i As Integer = 0
      For Each eqi As EquipmentItem In Me
        i += 1
        Dim newRow As TreeRow = dt.Childs.Add()
        eqi.CopyToDataRow(newRow)
        'eqi.ItemValidateRow(newRow)
        newRow.Tag = eqi
      Next
    End Sub
    Public Function CreateTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "EquipmentItems"

      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Selected"
      csSelected.HeaderText = ""

      Dim csDescription As New PlusMinusColumn
      csDescription.MappingName = "Entity"
      csDescription.HeaderText = "Entity"
      csDescription.NullText = ""
      csDescription.Width = 180

      Dim csQty As New HeaderAndDataAlignColumn
      csQty.MappingName = "Qty"
      csQty.HeaderText = "Qty"
      csQty.NullText = ""

      Dim csDate As New HeaderAndDataAlignColumn
      csDate.MappingName = "Date"
      csDate.HeaderText = "Date"
      csDate.NullText = ""
      csDate.DataAlignment = HorizontalAlignment.Center
      csDate.Width = 100
      csDate.Format = "d"


      Dim csRequestor As New HeaderAndDataAlignColumn
      csRequestor.MappingName = "Requestor"
      csRequestor.HeaderText = "Requestor"
      csRequestor.NullText = ""
      csRequestor.DataAlignment = HorizontalAlignment.Center
      csRequestor.Width = 100

      Dim csCostCenter As New HeaderAndDataAlignColumn
      csCostCenter.MappingName = "CostCenter"
      csCostCenter.HeaderText = "CostCenter"
      csCostCenter.NullText = ""
      csCostCenter.DataAlignment = HorizontalAlignment.Center
      csCostCenter.Width = 100


      dst.GridColumnStyles.Add(csSelected)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csQty)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(csRequestor)
      dst.GridColumnStyles.Add(csCostCenter)
      Return dst
    End Function
    'Public Function GetDataTable() As ExpandableRowDataTable
    '  Dim myDatatable As New ExpandableRowDataTable("EquipmentItems")
    '  myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
    '  myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("m_pr", GetType(Integer)))
    '  myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Entity", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Qty", GetType(Decimal)))
    '  myDatatable.Columns.Add(New DataColumn("Date", GetType(Date)))
    '  myDatatable.Columns.Add(New DataColumn("Requestor", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("SortIndex", GetType(Decimal)))

    '  For Each item As EquipmentItem In Me.List
    '    Dim row As ExpandableDataRow = myDatatable.Add(item.Pr.Code & item.LineNumber)
    '    row("Selected") = False
    '    row("Code") = item.Pr.Code
    '    row("m_pr") = item.Pr.Id
    '    row("Linenumber") = item.LineNumber
    '    row("Date") = item.Pr.DocDate
    '    Dim entityText As String = ""
    '    If Not item.ItemType Is Nothing Then
    '      entityText &= item.ItemType.Description & ":"
    '    End If
    '    If Not item.Entity.Code Is Nothing AndAlso item.Entity.Code.Length > 0 Then
    '      entityText &= item.Entity.Code & ":"
    '    End If
    '    If Not item.Entity.Name Is Nothing AndAlso item.Entity.Name.Length > 0 Then
    '      entityText &= item.Entity.Name
    '    End If
    '    row("Entity") = entityText
    '    row("Qty") = item.Qty
    '    row("Requestor") = item.Pr.Requestor.Code & ":" & item.Pr.Requestor.Name
    '    row("CostCenter") = item.Pr.CostCenter.Code & ":" & item.Pr.CostCenter.Name
    '    row.State = PlusMinusState.UnderParent
    '  Next
    '  Return myDatatable
    'End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As EquipmentItem) As Integer
      If Not m_equipment Is Nothing Then
        value.Equipment = m_equipment
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As EquipmentItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As EquipmentItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As EquipmentItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As EquipmentItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    'Public Shadows Function GetEnumerator() As PRItemEnumerator
    '  Return New PRItemEnumerator(Me)
    'End Function
    Public Function IndexOf(ByVal value As EquipmentItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As EquipmentItem)
      If Not m_equipment Is Nothing Then
        value.Equipment = m_equipment
      End If
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As EquipmentItem)
      'For Each wbsd As WBSDistribute In value.WBSDistributeCollection
      '  value.WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      'Next
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      'For Each wbsd As WBSDistribute In Me(index).WBSDistributeCollection
      '  Me(index).WBSChangedHandler(wbsd, New PropertyChangedEventArgs("WBS", New WBS, wbsd.WBS))
      'Next
      MyBase.List.RemoveAt(index)
    End Sub
    Public Function Count() As Integer
      Dim i As Integer
      For Each Item As EquipmentItem In Me
        i += 1
      Next
      Return i
    End Function
#End Region


    Public Class PRItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As PRItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, PRItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub

    End Class
  End Class

End Namespace
