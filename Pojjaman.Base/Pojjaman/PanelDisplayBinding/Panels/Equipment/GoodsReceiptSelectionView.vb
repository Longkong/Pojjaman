Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.DataAccessLayer
Namespace Longkong.Pojjaman.Gui.Panels
  Public Class GoodsReceiptSelectionView
    Inherits AbstractEntityPanelViewContent
    Implements ISimpleListPanel

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
    Friend WithEvents pnlFilter As System.Windows.Forms.Panel
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents tgItem As Longkong.Pojjaman.Gui.Components.TreeGrid
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
      Me.pnlFilter = New System.Windows.Forms.Panel()
      Me.Splitter1 = New System.Windows.Forms.Splitter()
      Me.tgItem = New Longkong.Pojjaman.Gui.Components.TreeGrid()
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).BeginInit()
      Me.SuspendLayout()
      '
      'pnlFilter
      '
      Me.pnlFilter.Dock = System.Windows.Forms.DockStyle.Top
      Me.pnlFilter.Location = New System.Drawing.Point(0, 0)
      Me.pnlFilter.Name = "pnlFilter"
      Me.pnlFilter.Size = New System.Drawing.Size(768, 152)
      Me.pnlFilter.TabIndex = 0
      '
      'Splitter1
      '
      Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
      Me.Splitter1.Location = New System.Drawing.Point(0, 152)
      Me.Splitter1.Name = "Splitter1"
      Me.Splitter1.Size = New System.Drawing.Size(768, 3)
      Me.Splitter1.TabIndex = 1
      Me.Splitter1.TabStop = False
      '
      'tgItem
      '
      Me.tgItem.AllowNew = False
      Me.tgItem.AllowSorting = False
      Me.tgItem.AlternatingBackColor = System.Drawing.Color.FromArgb(CType(CType(217, Byte), Integer), CType(CType(222, Byte), Integer), CType(CType(236, Byte), Integer))
      Me.tgItem.AutoColumnResize = True
      Me.tgItem.CaptionVisible = False
      Me.tgItem.Cellchanged = False
      Me.tgItem.DataMember = ""
      Me.tgItem.Dock = System.Windows.Forms.DockStyle.Fill
      Me.tgItem.HeaderBackColor = System.Drawing.Color.Khaki
      Me.tgItem.HeaderForeColor = System.Drawing.SystemColors.ControlText
      Me.tgItem.Location = New System.Drawing.Point(0, 155)
      Me.tgItem.Name = "tgItem"
      Me.tgItem.Size = New System.Drawing.Size(768, 328)
      Me.tgItem.SortingArrowColor = System.Drawing.Color.Red
      Me.tgItem.TabIndex = 7
      Me.tgItem.TreeManager = Nothing
      '
      'GoodsReceiptSelectionView
      '
      Me.Controls.Add(Me.tgItem)
      Me.Controls.Add(Me.Splitter1)
      Me.Controls.Add(Me.pnlFilter)
      Me.Name = "GoodsReceiptSelectionView"
      Me.Size = New System.Drawing.Size(768, 483)
      CType(Me.tgItem, System.ComponentModel.ISupportInitialize).EndInit()
      Me.ResumeLayout(False)

    End Sub

#End Region

#Region "Members"
    Private m_filterSubPanel As IFilterSubPanel
    Private m_entity As ISimpleEntity
    Private m_selectedID As Integer

    Private m_basketItems As BasketItemCollection
    'Private m_proposedBasketItems As BasketItemCollection
    Private m_treeManager As TreeManager

    Private m_selectionMode As Selection

    'Private m_oldBasket As BasketItemCollection
    Private m_fullclassname As String
    Private m_otherFilters As Filter()
    'Private m_proposedBasketItems As BasketItemCollection
    'Private m_selectedEntity As ISimpleEntity
#End Region

#Region "Constructors"
    Public Sub New(ByVal entity As ISimpleEntity, ByVal mode As Selection, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
      'Public Sub New(ByVal entity As ISimpleEntity, ByVal mode As Selection, ByVal filters As Filter(), ByVal entities As ArrayList)
      MyBase.New()

      InitializeComponent()
      m_entity = entity
      Me.SetLabelText()
      Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      Me.PanelName = Me.Name

      'Hack
      m_filterSubPanel = New GoodsReceiptForSelectFilterSubPanel
      m_filterSubPanel.Entities = entities

      Dim filterControl As UserControl = CType(Me.m_filterSubPanel, UserControl)
      Me.pnlFilter.Controls.Add(filterControl)
      Me.pnlFilter.Height = filterControl.Height
      m_otherFilters = filters

      AddHandler Me.m_filterSubPanel.SearchButton.Click, AddressOf btnSearch_Click
      Me.m_filterSubPanel.SearchButton.PerformClick()

      m_basketItems = New BasketItemCollection
      'm_proposedBasketItems = New BasketItemCollection
      'm_oldBasket = New BasketItemCollection

      m_selectionMode = mode
    End Sub
    'Public Sub New(ByVal entity As ISimpleEntity, ByVal basket As BasketDialog, ByVal filters As Filter(), ByVal entities As ArrayList)
    '  Me.new(entity, Selection.MultiSelect, basket, filters, entities)
    'End Sub
#End Region

#Region "Properties"
    Public Enum Selection
      None
      MultiSelect
      SingleSelect
    End Enum
    Public ReadOnly Property SelectionMode() As Selection
      Get
        Return Me.m_selectionMode
      End Get
    End Property
#End Region

#Region "Methods"
    Private Sub RowIcon_Click(ByVal e As ButtonColumnEventArgs)
      Dim myTable As TreeTable = Me.m_treeManager.Treetable
      Dim clickedRow As TreeRow = CType(myTable.Rows(e.Row), TreeRow)
      For Each row As TreeRow In myTable.Childs
        Dim checkCount As Integer = 0
        For Each childRow As TreeRow In row.Childs
          If e.Row = row.Index Then
            '��ԡⴹ���
            childRow("Selected") = row("Selected")
          End If
          If CBool(childRow("Selected")) Then
            checkCount += 1
          End If
        Next
        If checkCount = row.Childs.Count Then
          row("Selected") = True
        ElseIf checkCount = 0 Then
          row("Selected") = False
        Else
          row("Selected") = DBNull.Value
        End If
      Next
    End Sub
    Public Sub ChangeTitle(ByVal sender As Object, ByVal e As EventArgs) Implements ISimpleListPanel.ChangeTitle
      If Me.WorkbenchWindow.ActiveViewContent Is Me Then
        Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
        Return
      End If
      'If Not m_selectedEntity Is Nothing Then
      '    Me.TitleName = m_selectedEntity.TabPageText
      'End If
    End Sub
    Public Sub SearchData(ByVal order As String)

      Dim filters As Filter() = Me.m_filterSubPanel.GetFilterArray
      Dim otherLength As Integer = 0
      If Not m_otherFilters Is Nothing AndAlso m_otherFilters.Length > 0 Then
        otherLength = m_otherFilters.Length
      End If

      Dim newfilters((filters.Length + 1) + otherLength - 1) As Filter
      For i As Integer = 0 To filters.Length - 1
        newfilters(i) = filters(i)
      Next
      If otherLength > 0 Then
        For i As Integer = 0 To otherLength - 1
          newfilters(i + filters.Length) = m_otherFilters(i)
        Next
      End If

      newfilters(newfilters.Length - 1) = New Filter("tool_id", IIf(Me.Entity Is Nothing, DBNull.Value, Me.Entity.Id))

      'If TypeOf m_entity Is PRForMatTransfer OrElse TypeOf m_entity Is PRForMatOperationWithdraw Then
      '  Dim filterdt As DataTable = Nothing
      '  Dim procName As String = "Get" & m_entity.ClassName & "List"
      '  filterdt = PRItem.GetListDatatableForMatWithDraw(procName, newfilters)
      '  PopDataStyle2(filterdt)
      'Else
      Dim filterdt As DataTable
      Dim tagisdatarow As Boolean = False
      If TypeOf Me.Entity Is Equipment Then
        filterdt = GoodsReceipt.GetListDatatableForEquipment(newfilters)
        m_fullclassname = "Longkong.Pojjaman.BusinessLogic.EquipmentItem"
      ElseIf TypeOf Me.Entity Is Tool Then
        filterdt = GoodsReceipt.GetListDatatableForTool(newfilters)
        m_fullclassname = "Longkong.Pojjaman.BusinessLogic.Toollot"
      ElseIf TypeOf Me.Entity Is EquipmentToolChangeStatus Then
        filterdt = Stock.GetListDatatableForEquipmenttoolChangestatus(newfilters)
        m_fullclassname = "Longkong.Pojjaman.BusinessLogic.StockItem"
        tagisdatarow = True
      End If



      PopDataStyle1(filterdt, tagisdatarow)
      'End If

    End Sub
    Private Sub PopDataStyle1(ByVal filterdt As DataTable, ByVal tagisdatarow As Boolean)
      Dim dt As TreeTable = GetSchemaTable()

      dt.Clear()

      Dim hashGR As New Hashtable
      Dim currGR As String = ""
      Dim row As TreeRow = Nothing

      For Each drow As DataRow In filterdt.Rows
        Dim drh As New DataRowHelper(drow)
        currGR = drh.GetValue(Of String)("stock_code")

        If Not hashGR.Contains(currGR) Then
          row = dt.Childs.Add
          row.State = RowExpandState.None
          row("Selected") = False
          row("LineNumber") = drh.GetValue(Of String)("stocki_linenumber")
          row("Id") = drh.GetValue(Of String)("stock_id")
          row("Code") = drh.GetValue(Of String)("stock_code")
          row("DocDate") = drh.GetValue(Of String)("stock_docdate")
          row("Code1") = drh.GetValue(Of String)("stock_code")
          row("DocDate1") = drh.GetValue(Of String)("stock_docdate")
          row("Description") = drh.GetValue(Of String)("ccinfo")

          row.Tag = row
          hashGR(currGR) = currGR
        End If

        If Not row Is Nothing Then
          Dim crow As TreeRow = row.Childs.Add
          crow.State = RowExpandState.None
          crow("Selected") = False
          crow("LineNumber") = drh.GetValue(Of String)("stocki_linenumber")
          crow("Id") = drh.GetValue(Of String)("stock_id")
          crow("Code") = drh.GetValue(Of String)("stock_code")
          crow("DocDate") = drh.GetValue(Of String)("stock_docdate")
          crow("Code1") = ""
          crow("DocDate1") = ""
          crow("Description") = drh.GetValue(Of String)("stocki_itemname")
          crow("UnitCost") = drh.GetValue(Of Decimal)("stocki_unitcost")
          crow("CCId") = drh.GetValue(Of Integer)("stock_tocc")
          crow("UnitId") = drh.GetValue(Of Integer)("stocki_unit")
          crow("QtyRemaining") = Configuration.FormatToString(drh.GetValue(Of Decimal)("qtyremaining"), DigitConfig.Price)
          crow("Sequence") = drh.GetValue(Of Decimal)("stocki_sequence")

          Trace.WriteLine(drh.GetValue(Of String)("stock_code").ToString)
          Trace.WriteLine(drh.GetValue(Of String)("stock_docdate").ToString)
          If tagisdatarow Then
            crow.Tag = drow
          Else
            crow.Tag = crow
          End If
        End If

      Next

      dt.AcceptChanges()

      Dim dst As DataGridTableStyle = CreateListTableStyle()
      m_treeManager = New TreeManager(dt, tgItem)
      m_treeManager.SetTableStyle(dst)
      m_treeManager.AllowSorting = False
      m_treeManager.AllowDelete = False
    End Sub
    'Private Sub PopDataStyle2(ByVal filterdt As DataTable)
    '  Dim dt As TreeTable = GetSchemaTable2()
    '  dt.Clear()
    '  Dim parRow As TreeRow
    '  Dim currentPR As Integer = -1

    '  For Each filteredRow As DataRow In filterdt.Rows
    '    Dim drh As New DataRowHelper(filteredRow)
    '    Dim prId As Integer = drh.GetValue(Of Integer)("pr_id")
    '    Dim prCode As String = drh.GetValue(Of String)("pr_code")
    '    Dim Material As String = drh.GetValue(Of String)("lciinfo")
    '    Dim Unit As String = drh.GetValue(Of String)("unit_name")
    '    Dim PRQty As Decimal = drh.GetValue(Of Decimal)("PRQty")
    '    Dim StockQty As Decimal = drh.GetValue(Of Decimal)("StockQty")
    '    Dim WithdrawQty As Decimal = drh.GetValue(Of Decimal)("WithdrawQty")
    '    Dim RemainingQty As Decimal = drh.GetValue(Of Decimal)("RemainingQty")
    '    Dim LineNumber As Integer = drh.GetValue(Of Integer)("pri_linenumber")

    '    If currentPR <> prId Then
    '      parRow = dt.Childs.Add
    '      parRow("Selected") = False
    '      parRow("Code") = prCode
    '      parRow("Material") = prCode
    '      parRow("Qty") = ""
    '      parRow("StockQty") = ""
    '      parRow("WithdrawQty") = ""
    '      parRow("RemainingQty") = ""
    '      currentPR = prId
    '    End If
    '    If Not parRow Is Nothing Then
    '      Dim childRow As TreeRow = parRow.Childs.Add
    '      childRow("Selected") = False
    '      childRow("Code") = prCode
    '      childRow("Material") = Space(3) & Material
    '      childRow("Unit") = Unit
    '      childRow("Qty") = Configuration.FormatToString(PRQty, DigitConfig.Price)
    '      childRow("StockQty") = Configuration.FormatToString(StockQty, DigitConfig.Price)
    '      childRow("WithdrawQty") = Configuration.FormatToString(WithdrawQty, DigitConfig.Price)
    '      childRow("RemainingQty") = Configuration.FormatToString(RemainingQty, DigitConfig.Price)
    '      childRow("Linenumber") = Configuration.FormatToString(LineNumber, DigitConfig.Int)
    '      Dim pritem As New PRItem
    '      pritem.Pr = New PR
    '      pritem.Pr.Id = prId
    '      pritem.LineNumber = LineNumber
    '      childRow.Tag = pritem
    '    End If
    '  Next
    '  dt.AcceptChanges()

    '  Dim dst As DataGridTableStyle = CreateListTableStyle2()
    '  m_treeManager = New TreeManager(dt, tgItem)
    '  m_treeManager.SetTableStyle(dst)
    '  m_treeManager.AllowSorting = False
    '  m_treeManager.AllowDelete = False
    'End Sub
    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("GoodsReceiptItems")

      myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("LineNumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Id", GetType(Integer)))

      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocDate", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocDate1", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("UnitCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("QtyRemaining", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("CCId", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("UnitId", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("Sequence", GetType(Integer)))


      Return myDatatable
    End Function
    'Public Shared Function GetSchemaTable2() As TreeTable
    '  Dim myDatatable As New TreeTable("PRItems2")

    '  myDatatable.Columns.Add(New DataColumn("Selected", GetType(Boolean)))
    '  myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Material", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("CostCenter", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Qty", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("StockQty", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("WithdrawQty", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("RemainingQty", GetType(String)))
    '  myDatatable.Columns.Add(New DataColumn("Linenumber", GetType(Integer)))
    '  Return myDatatable
    'End Function
#End Region

#Region "Style"
    Public Function CreateListTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "GoodsReceiptItems"

      'Dim csDocdate As New TreeTextColumn
      'csDocdate.MappingName = "Id"
      'csDocdate.HeaderText = "Id"
      'csDocdate.NullText = ""
      'csDocdate.Width = 0
      'csDocdate.ReadOnly = True


      Dim csSelected As New DataGridCheckBoxColumn
      csSelected.MappingName = "Selected"
      csSelected.HeaderText = ""
      AddHandler csSelected.Click, AddressOf RowIcon_Click

      Dim csCode As New TreeTextColumn
      csCode.MappingName = "Code1"
      csCode.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptSelectionView.Code1}")
      csCode.NullText = ""
      csCode.Width = 120
      csCode.ReadOnly = True

      Dim csDocdate As New TreeTextColumn
      csDocdate.MappingName = "Docdate1"
      csDocdate.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptSelectionView.Docdate1}")
      csDocdate.NullText = ""
      csDocdate.Width = 100
      csDocdate.ReadOnly = True

      Dim csDescription As New TreeTextColumn
      csDescription.MappingName = "Description"
      csDescription.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptSelectionView.Description}")
      csDescription.NullText = ""
      csDescription.Width = 190
      csDescription.ReadOnly = True

      Dim csQty As New TreeTextColumn
      csQty.MappingName = "QtyRemaining"
      csQty.HeaderText = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.GoodsReceiptSelectionView.QtyRemaining}")
      csQty.NullText = ""
      csQty.ReadOnly = True

      dst.GridColumnStyles.Add(csSelected)
      dst.GridColumnStyles.Add(csCode)
      dst.GridColumnStyles.Add(csDocdate)
      dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csQty)

      Return dst
    End Function
    'Public Function CreateListTableStyle2() As DataGridTableStyle
    '  Dim dst As New DataGridTableStyle
    '  dst.MappingName = "PRItems2"

    '  Dim csSelected As New DataGridCheckBoxColumn
    '  csSelected.MappingName = "Selected"
    '  csSelected.HeaderText = ""
    '  AddHandler csSelected.Click, AddressOf RowIcon_Click

    '  Dim csDescription As New TreeTextColumn
    '  csDescription.MappingName = "Material"
    '  csDescription.HeaderText = "�Ţ����͡���/��ʴ�"
    '  csDescription.NullText = ""
    '  csDescription.Width = 190
    '  csDescription.ReadOnly = True

    '  Dim csUnit As New TreeTextColumn
    '  csUnit.MappingName = "Unit"
    '  csUnit.HeaderText = "˹����ҵðҹ"
    '  csUnit.NullText = ""
    '  csUnit.Width = 70
    '  csUnit.DataAlignment = HorizontalAlignment.Center
    '  csUnit.ReadOnly = True

    '  Dim csPRQty As New TreeTextColumn
    '  csPRQty.MappingName = "Qty"
    '  csPRQty.HeaderText = "����ҳ PR"
    '  csPRQty.DataAlignment = HorizontalAlignment.Right
    '  csPRQty.NullText = ""
    '  csPRQty.Width = 90
    '  csPRQty.ReadOnly = True

    '  Dim csStockQty As New TreeTextColumn
    '  csStockQty.MappingName = "StockQty"
    '  csStockQty.HeaderText = "����ҳ㹤�ѧ"
    '  csStockQty.DataAlignment = HorizontalAlignment.Right
    '  csStockQty.NullText = ""
    '  csStockQty.Width = 90
    '  csStockQty.ReadOnly = True

    '  Dim csWithdrawQty As New TreeTextColumn
    '  csWithdrawQty.MappingName = "WithdrawQty"
    '  csWithdrawQty.HeaderText = "�ԡ����"
    '  csWithdrawQty.DataAlignment = HorizontalAlignment.Right
    '  csWithdrawQty.NullText = ""
    '  csWithdrawQty.Width = 90
    '  csWithdrawQty.ReadOnly = True

    '  Dim csRemainingQty As New TreeTextColumn
    '  csRemainingQty.MappingName = "RemainingQty"
    '  csRemainingQty.HeaderText = "�ԡ��"
    '  csRemainingQty.DataAlignment = HorizontalAlignment.Right
    '  csRemainingQty.NullText = ""
    '  csRemainingQty.Width = 90
    '  csRemainingQty.ReadOnly = True

    '  dst.GridColumnStyles.Add(csSelected)
    '  dst.GridColumnStyles.Add(csDescription)
    '  dst.GridColumnStyles.Add(csUnit)
    '  dst.GridColumnStyles.Add(csPRQty)
    '  dst.GridColumnStyles.Add(csStockQty)
    '  dst.GridColumnStyles.Add(csWithdrawQty)
    '  dst.GridColumnStyles.Add(csRemainingQty)
    '  Return dst
    'End Function
#End Region

#Region "Event Handlers"
    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
      Me.SearchData("")
    End Sub
    'Private Sub tgItem_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles tgItem.DoubleClick
    '  If CurrentTagItem Is Nothing Then
    '    Return
    '  End If

    '  Me.OnEntitySelected(Me.SelectedEntity)
    '  Me.FindForm.Close()
    'End Sub
    'Private ReadOnly Property CurrentTagItem As DataRowHelper
    '  Get
    '    Dim row As TreeRow = Me.m_treeManager.SelectedRow
    '    If row Is Nothing OrElse Not TypeOf row.Tag Is DataRowHelper Then
    '      Return Nothing
    '    End If

    '    Return CType(row.Tag, DataRowHelper)

    '  End Get
    'End Property
#End Region

#Region "ISimpleListPanel"
    Public Event EntitySelected(ByVal e As ISimpleEntity) Implements ISimpleListPanel.EntitySelected
    Public Sub OnEntitySelected(ByVal e As ISimpleEntity)
      RaiseEvent EntitySelected(e)
    End Sub
    Public Event EntityPropertyChanged(ByVal sender As Object, ByVal e As System.EventArgs) Implements ISimpleEntityPanel.EntityPropertyChanged

    Public Sub CheckFormEnable() Implements ISimpleEntityPanel.CheckFormEnable

    End Sub
    Public Sub ClearDetail() Implements ISimpleEntityPanel.ClearDetail

    End Sub
    Public Property Entity() As BusinessLogic.ISimpleEntity Implements ISimpleEntityPanel.Entity
      Get
        Return Me.m_entity
      End Get
      Set(ByVal Value As ISimpleEntity)
        Me.m_entity = Value
      End Set
    End Property
    Public Sub Initialize() Implements ISimpleEntityPanel.Initialize

    End Sub
    Public Sub SetLabelText() Implements ISimpleEntityPanel.SetLabelText
      If Not m_entity Is Nothing Then
        Me.Text = Me.StringParserService.Parse(m_entity.ListPanelTitle)
      End If
    End Sub
    Public Sub UpdateEntityProperties() Implements ISimpleEntityPanel.UpdateEntityProperties

    End Sub
    Public Sub AddNew() Implements ISimpleListPanel.AddNew

    End Sub
    Public Sub RefreshData(ByVal id As String) Implements ISimpleListPanel.RefreshData
      SearchData("")
    End Sub
    Public Property SelectedEntity() As BusinessLogic.ISimpleEntity Implements ISimpleListPanel.SelectedEntity
      Get
        'Return m_selectedEntity
      End Get
      Set(ByVal Value As BusinessLogic.ISimpleEntity)
        'If CType(m_selectedEntity, Object).Equals(Value) Then
        '    Return
        'End If
        'Me.m_selectedEntity = Value
        'If Not m_selectedEntity Is Nothing Then
        '    Me.RefreshData(m_selectedEntity.Id.ToString)
        'End If
      End Set
    End Property
    Public ReadOnly Property Icon() As String Implements ISimplePanel.Icon
      Get
        Return Me.m_entity.ListPanelIcon
      End Get
    End Property
    Public Sub ShowInPad() Implements ISimplePanel.ShowInPad
      Return
    End Sub
    Public ReadOnly Property Title() As String Implements ISimplePanel.Title
      Get
        Return Me.m_entity.ListPanelTitle
      End Get
    End Property
#End Region

#Region "Overrides"
    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Return "��¡��"
      End Get
    End Property
    Public Overrides Sub Deselected()
      If Not Me.WorkbenchWindow.SubViewContents Is Nothing Then
        'If Not m_selectedEntity Is Nothing Then
        '    AddHandler m_selectedEntity.TabPageTextChanged, AddressOf Me.ChangeTitle
        'End If
        'CType(Me.WorkbenchWindow.SubViewContents(1), ISimpleEntityPanel).Entity = m_selectedEntity
      End If
    End Sub
    Public Overrides Sub Selected()
      Me.RefreshData(Me.SelectedEntity.Id.ToString)
      Me.TitleName = Me.StringParserService.Parse(m_entity.ListPanelTitle)
    End Sub
#End Region

#Region "IBasketCollectable"
    '    'Private dlg As BasketDialog
    Public Overrides ReadOnly Property BasketItems() As BusinessLogic.BasketItemCollection
      Get
        m_basketItems.Clear()
        Dim myTable As TreeTable = Me.m_treeManager.Treetable ' CType(tgItem.DataSource, TreeTable)
        For Each row As TreeRow In myTable.Childs
          For Each childRow As TreeRow In row.Childs
            If Not IsDBNull(childRow("Selected")) Then
              If CBool(childRow("Selected")) Then
                Dim id As Integer = CInt(childRow("Id"))
                Dim stockCode As String = CStr(childRow("Code"))
                Dim fullClassName As String = m_fullclassname
                Dim entityName As String = CStr(childRow("Description"))
                Dim lineNumber As Integer = CInt(childRow("LineNumber"))

                Dim qty As Decimal = 0
                'If myTable.TableName.ToLower = "pritems2" Then
                qty = CDec(childRow("QtyRemaining"))
                'Else
                '  qty = CDec(childRow("Qty"))
                'End If

                Dim textInBasket As String = entityName & ":" & qty.ToString
                If TypeOf childRow.Tag Is DataRow Then
                  'Dim pri As PRItem = CType(childRow.Tag, PRItem)
                  'Dim thePR As PR = pri.Pr
                  'pri = New PRItem(pri.Pr.Id, pri.LineNumber)
                  'pri.Pr = thePR
                  'id = thePR.Id
                  Dim bi As New StockBasketItem(id, stockCode, fullClassName, textInBasket, lineNumber, qty, entityName)
                  bi.Tag = childRow.Tag

                  'Dim d As String = entityName & "xx " & CType(childRow.Tag, TreeRow)("Code").ToString

                  'For Each drow As TreeRow In Me.m_treeManager.Treetable.Rows
                  '  d = CType(drow.Tag, DataRow)("Id").ToString
                  'Next

                  'MessageBox.Show(d)

                  m_basketItems.Add(bi)
                End If
              End If
            End If
          Next
        Next
        Return m_basketItems
      End Get
    End Property
    'Public Overrides ReadOnly Property ProposedBasketItems() As BusinessLogic.BasketItemCollection
    '  Get
    '    Return m_proposedBasketItems
    '  End Get
    'End Property

#End Region

  End Class
End Namespace

