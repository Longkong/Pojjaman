Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Syncfusion.Windows.Forms.Grid
Imports Longkong.Pojjaman.Services

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptWBSMonitorAll
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
    Private m_cc As CostCenter
    Private m_hashData As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal filters As Filter(), ByVal fixValueCollection As DocPrintingItemCollection)
      MyBase.New(filters, fixValueCollection)
    End Sub
#End Region

#Region "Style"
    Public Shared Function CreateWBSMonitorTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "boqi_linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "boqi_linenumber"

      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "boqi_itemName"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DescriptionHeaderText}")
      csName.NullText = ""
      csName.Width = 240
      csName.TextBox.Name = "Description"
      csName.ReadOnly = True

      Dim csBarrier0 As New DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier0"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
      csBarrier0.ReadOnly = True

      Dim csUnitPrice As New TreeTextColumn
      csUnitPrice.MappingName = "UnitPrice"
      csUnitPrice.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitPriceHeaderText}")
      csUnitPrice.NullText = ""
      csUnitPrice.DataAlignment = HorizontalAlignment.Right
      csUnitPrice.Format = "#,###.##"
      csUnitPrice.TextBox.Name = "UnitPrice"
      csUnitPrice.ReadOnly = True

      Dim csUnit As New TreeTextColumn
      csUnit.MappingName = "Unit"
      csUnit.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.UnitHeaderText}")
      csUnit.NullText = ""
      csUnit.DataAlignment = HorizontalAlignment.Center
      csUnit.TextBox.Name = "Unit"
      csUnit.ReadOnly = True

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim csTotalQty As New TreeTextColumn
      csTotalQty.MappingName = "TotalQuantity"
      csTotalQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalQuantityHeaderText}")
      csTotalQty.NullText = ""
      csTotalQty.DataAlignment = HorizontalAlignment.Right
      csTotalQty.Format = "#,###.##"
      csTotalQty.TextBox.Name = "TotalQuantity"
      csTotalQty.ReadOnly = True

      Dim csActualQty As New TreeTextColumn
      csActualQty.MappingName = "ActualQuantity"
      csActualQty.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualQuantityHeaderText}")
      csActualQty.NullText = ""
      csActualQty.DataAlignment = HorizontalAlignment.Right
      csActualQty.Format = "#,###.##"
      csActualQty.TextBox.Name = "ActualQuantity"
      csActualQty.ReadOnly = True

      Dim csQtyDiff As New TreeTextColumn
      csQtyDiff.MappingName = "QuantityDiff"
      csQtyDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csQtyDiff.NullText = ""
      csQtyDiff.DataAlignment = HorizontalAlignment.Right
      csQtyDiff.Format = "#,###.##"
      csQtyDiff.TextBox.Name = "QuantityDiff"
      csQtyDiff.ReadOnly = True

      Dim csBarrier2 As New DataGridBarrierColumn
      csBarrier2.MappingName = "Barrier2"
      csBarrier2.HeaderText = ""
      csBarrier2.NullText = ""
      csBarrier2.ReadOnly = True

      Dim csBudget As New TreeTextColumn
      csBudget.MappingName = "BudgetCost"
      csBudget.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.BudgetCostHeaderText}")
      csBudget.NullText = ""
      csBudget.DataAlignment = HorizontalAlignment.Right
      csBudget.Format = "#,###.##"
      csBudget.TextBox.Name = "BudgetCost"
      csBudget.ReadOnly = True

      Dim csActualTotalPR As New TreeTextColumn
      csActualTotalPR.MappingName = "ActualPRCost"
      csActualTotalPR.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPRCostHeaderText}")
      csActualTotalPR.NullText = ""
      csActualTotalPR.DataAlignment = HorizontalAlignment.Right
      csActualTotalPR.Format = "#,###.##"
      csActualTotalPR.TextBox.Name = "ActualPRCost"
      csActualTotalPR.ReadOnly = True

      Dim csPRDiff As New TreeTextColumn
      csPRDiff.MappingName = "PRDiff"
      csPRDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csPRDiff.NullText = ""
      csPRDiff.DataAlignment = HorizontalAlignment.Right
      csPRDiff.Format = "#,###.##"
      csPRDiff.TextBox.Name = "PRDiff"
      csPRDiff.ReadOnly = True

      Dim csBarrier3 As New DataGridBarrierColumn
      csBarrier3.MappingName = "Barrier3"
      csBarrier3.HeaderText = ""
      csBarrier3.NullText = ""
      csBarrier3.ReadOnly = True

      'Dim csTotalLC As New TreeTextColumn
      'csTotalLC.MappingName = "TotalLaborCost"
      'csTotalLC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalLaborCostHeaderText}")
      'csTotalLC.NullText = ""
      'csTotalLC.DataAlignment = HorizontalAlignment.Right
      'csTotalLC.Format = "#,###.##"
      'csTotalLC.TextBox.Name = "TotalLaborCost"
      'csTotalLC.ReadOnly = True

      Dim csActualTotalPO As New TreeTextColumn
      csActualTotalPO.MappingName = "ActualPOCost"
      csActualTotalPO.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualPOCostHeaderText}")
      csActualTotalPO.NullText = ""
      csActualTotalPO.DataAlignment = HorizontalAlignment.Right
      csActualTotalPO.Format = "#,###.##"
      csActualTotalPO.TextBox.Name = "ActualPOCost"
      csActualTotalPO.ReadOnly = True

      Dim csPODiff As New TreeTextColumn
      csPODiff.MappingName = "PODiff"
      csPODiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csPODiff.NullText = ""
      csPODiff.DataAlignment = HorizontalAlignment.Right
      csPODiff.Format = "#,###.##"
      csPODiff.TextBox.Name = "PODiff"
      csPODiff.ReadOnly = True

      Dim csBarrier4 As New DataGridBarrierColumn
      csBarrier4.MappingName = "Barrier4"
      csBarrier4.HeaderText = ""
      csBarrier4.NullText = ""
      csBarrier4.ReadOnly = True

      'Dim csTotalEC As New TreeTextColumn
      'csTotalEC.MappingName = "TotalEquipmentCost"
      'csTotalEC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalEquipmentCostHeaderText}")
      'csTotalEC.NullText = ""
      'csTotalEC.DataAlignment = HorizontalAlignment.Right
      'csTotalEC.Format = "#,###.##"
      'csTotalEC.TextBox.Name = "TotalEquipmentCost"
      'csTotalEC.ReadOnly = True

      Dim csActualTotalGR As New TreeTextColumn
      csActualTotalGR.MappingName = "ActualGRCost"
      csActualTotalGR.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualGRCostHeaderText}")
      csActualTotalGR.NullText = ""
      csActualTotalGR.DataAlignment = HorizontalAlignment.Right
      csActualTotalGR.Format = "#,###.##"
      csActualTotalGR.TextBox.Name = "ActualGRCost"
      csActualTotalGR.ReadOnly = True

      Dim csGRDiff As New TreeTextColumn
      csGRDiff.MappingName = "GRDiff"
      csGRDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csGRDiff.NullText = ""
      csGRDiff.DataAlignment = HorizontalAlignment.Right
      csGRDiff.Format = "#,###.##"
      csGRDiff.TextBox.Name = "GRDiff"
      csGRDiff.ReadOnly = True

      Dim csBarrier5 As New DataGridBarrierColumn
      csBarrier5.MappingName = "Barrier5"
      csBarrier5.HeaderText = ""
      csBarrier5.NullText = ""
      csBarrier5.ReadOnly = True

      'Dim csTotal As New TreeTextColumn
      'csTotal.MappingName = "Total"
      'csTotal.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.TotalCostHeaderText}")
      'csTotal.NullText = ""
      'csTotal.Width = 100
      'csTotal.DataAlignment = HorizontalAlignment.Right
      'csTotal.Format = "#,###.##"
      'csTotal.TextBox.Name = "Total"
      'csTotal.ReadOnly = True

      Dim csActualTotalMW As New TreeTextColumn
      csActualTotalMW.MappingName = "ActualMWCost"
      csActualTotalMW.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.ActualMWCostHeaderText}")
      csActualTotalMW.NullText = ""
      csActualTotalMW.DataAlignment = HorizontalAlignment.Right
      csActualTotalMW.Format = "#,###.##"
      csActualTotalMW.TextBox.Name = "ActualMWCost"
      csActualTotalMW.ReadOnly = True

      Dim csMWDiff As New TreeTextColumn
      csMWDiff.MappingName = "MWDiff"
      csMWDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.DifferenceHeaderText}")
      csMWDiff.NullText = ""
      csMWDiff.Width = 110
      csMWDiff.DataAlignment = HorizontalAlignment.Right
      csMWDiff.Format = "#,###.##"
      csMWDiff.TextBox.Name = "MWDiff"
      csMWDiff.ReadOnly = True

      'Dim csTotalPercentDiff As New TreeTextColumn
      'csTotalPercentDiff.MappingName = "TotalPercentDiff"
      'csTotalPercentDiff.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.PercentDiffHeaderText}")
      'csTotalPercentDiff.NullText = ""
      ''csTotalDiff.Width = 110
      'csTotalPercentDiff.DataAlignment = HorizontalAlignment.Right
      ''csTotalDiff.Format = "#,###.##"
      'csTotalPercentDiff.TextBox.Name = "TotalPercentDiff"
      'csTotalPercentDiff.ReadOnly = True


      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.CostControlReportView.Note}")
      csNote.NullText = ""
      csNote.Width = 200
      csNote.TextBox.Name = "Note"
      csNote.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)

      dst.GridColumnStyles.Add(csBarrier0)

      dst.GridColumnStyles.Add(csUnitPrice)
      dst.GridColumnStyles.Add(csUnit)

      dst.GridColumnStyles.Add(csBarrier1)

      'dst.GridColumnStyles.Add(csTotalQty)
      dst.GridColumnStyles.Add(csActualQty)
      'dst.GridColumnStyles.Add(csQtyDiff)

      dst.GridColumnStyles.Add(csBarrier2)

      dst.GridColumnStyles.Add(csBudget)
      dst.GridColumnStyles.Add(csActualTotalPR)
      dst.GridColumnStyles.Add(csPRDiff)

      dst.GridColumnStyles.Add(csBarrier3)

      'dst.GridColumnStyles.Add(csTotalLC)
      dst.GridColumnStyles.Add(csActualTotalPO)
      dst.GridColumnStyles.Add(csPODiff)

      dst.GridColumnStyles.Add(csBarrier4)

      'dst.GridColumnStyles.Add(csTotalEC)
      dst.GridColumnStyles.Add(csActualTotalGR)
      dst.GridColumnStyles.Add(csGRDiff)

      dst.GridColumnStyles.Add(csBarrier5)

      'dst.GridColumnStyles.Add(csTotal)
      dst.GridColumnStyles.Add(csActualTotalMW)
      dst.GridColumnStyles.Add(csMWDiff)
      dst.GridColumnStyles.Add(csNote)
      'dst.GridColumnStyles.Add(csTotalPercentDiff)

      Return dst
    End Function
    Public Shared Function GetWBSMonitorSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("boqi_linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("boqi_itemName", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier0", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("UnitPrice", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))

      'myDatatable.Columns.Add(New DataColumn("TotalQuantity", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualQuantity", GetType(String)))
      'myDatatable.Columns.Add(New DataColumn("QuantityDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier2", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("BudgetCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ActualPRCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PRDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier3", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("ActualPOCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("PODiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier4", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("ActualGRCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("GRDiff", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("Barrier5", GetType(String)))

      myDatatable.Columns.Add(New DataColumn("ActualMWCost", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("MWDiff", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("DocID", GetType(Integer)))

      Return myDatatable
    End Function
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return Me.GetWBSMonitorSchemaTable 'BOQ.GetWBSMonitorSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return Me.CreateWBSMonitorTableStyle 'BOQ.CreateWBSMonitorTableStyle
    End Function
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Cols.FrozenCount = 3
      m_grid.Model.Cols.Hidden(m_grid.ColCount) = True
      lkg.HilightGroupParentText = True
      lkg.RefreshHeights()
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
      Me.m_treemanager = tm
      If m_cc Is Nothing OrElse Not m_cc.Originated Then
        Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
        dt.Clear()
        tm.Treetable = dt
        Return
      End If
      If m_cc.BoqId = 0 Then
        Dim dt As TreeTable = CType(tm.Treetable.Clone, TreeTable)
        dt.Clear()
        tm.Treetable = dt
        Return
      End If
      If TypeOf Me.Filters(1).Value Is Date Then
        Dim nodigit As Boolean = False
        If Me.Filters(3).Name.ToLower = "nodigit" Then
          nodigit = CBool(Me.Filters(3).Value)
        End If
        PopulateWBSMonitorListing(tm.Treetable, CDate(Me.Filters(1).Value), nodigit)
      End If
    End Sub
    Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)

      Dim tr As Object = m_hashData(e.RowIndex)
      If tr Is Nothing Then
        Return
      End If

      If TypeOf tr Is DataRow Then
        Dim dr As DataRow = CType(tr, DataRow)
        Dim drh As New DataRowHelper(dr)

        Dim docId As Integer = drh.GetValue(Of Integer)("DocId")
        Dim docType As Integer = drh.GetValue(Of Integer)("DocType")

        If docId > 0 AndAlso docType > 0 Then
          Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
          Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
          myEntityPanelService.OpenDetailPanel(en)
        End If
      End If


      'If IsNumeric(m_grid(e.RowIndex, m_grid.ColCount).CellValue) Then
      '  Dim docId As Integer
      '  Dim docType As Integer
      '  docType = 6
      '  docId = CInt(m_grid(e.RowIndex, m_grid.ColCount).CellValue)
      '  If docId <> 0 Then
      '    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
      '    Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
      '    myEntityPanelService.OpenDetailPanel(en)
      '  End If
      'End If
    End Sub
    Public Sub PopulateWBSMonitorListing(ByVal dt As TreeTable, ByVal toDate As Date, Optional ByVal noDigit As Boolean = False)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      dt.Clear()
      Dim dtwbs As DataTable = Me.DataSet.Tables(0)
      Dim dtMarkUp As DataTable = Me.DataSet.Tables(1)
      Dim dtDoc As DataTable = Me.DataSet.Tables(2)
      dtwbs.TableName = "Table0"
      dtMarkUp.TableName = "Table1"
      dtDoc.TableName = "Table2"
      If dtwbs.Rows.Count <= 0 Then
        Return
      End If

      Dim detail As Integer = CInt(Me.Filters(2).Value)

      Dim ValueFilter As String = ""

      If Not Me.Filters(5).Value Is Nothing AndAlso CStr(Me.Filters(5).Value).Length > 0 Then
        ValueFilter = "wbs_level = 0 Or " & CStr(Me.Filters(5).Value)
      End If

      ' WBS ##################################################################################################
      '#######################################################################################################
      Dim Nodes As New Hashtable
      Dim myParent As String
      Dim parentNode As TreeRow = Nothing
      Dim myTempId As Integer = 0
      Dim SumNetWbsBudget As Decimal = 0
      Dim SumNetWBsPRActual As Decimal = 0
      Dim SumNetWBsPRDiff As Decimal = 0
      Dim SumNetWBsPOActual As Decimal = 0
      Dim SumNetWBsPODiff As Decimal = 0
      Dim SumNetWBsGRActual As Decimal = 0
      Dim SumNetWBsGRDiff As Decimal = 0
      Dim SumNetWBsMWActual As Decimal = 0
      Dim SumNetWBsMWDiff As Decimal = 0

      Dim tr As TreeRow
      Dim stage As String = ""
      Try
        'Ẻ������͡ Option WBS 
        For Each wbsrow As DataRow In dtwbs.Select(ValueFilter)
          Dim wbh As New DataRowHelper(wbsrow)
          If CInt(wbsrow("wbs_level")) = 0 Then
            parentNode = dt.Childs.Add
            SumNetWbsBudget += CDec(wbsrow("wbs_budget"))
            SumNetWBsPRActual += CDec(wbsrow("PRactual"))
            SumNetWBsPRDiff += CDec(wbsrow("DiffPR"))
            SumNetWBsPOActual += CDec(wbsrow("POactual"))
            SumNetWBsPODiff += CDec(wbsrow("DiffPO"))
            SumNetWBsGRActual += CDec(wbsrow("GRactual"))
            SumNetWBsGRDiff += CDec(wbsrow("DiffGR"))
            SumNetWBsMWActual += CDec(wbsrow("MWactual"))
            SumNetWBsMWDiff += CDec(wbsrow("DiffMW"))
          Else
            myParent = wbsrow("Parent")
            Try
              parentNode = Nodes(myParent).Childs.Add
            Catch ex As Exception

            End Try
          End If

          If Not parentNode Is Nothing Then
            Nodes(CStr(wbsrow("wbs_path"))) = parentNode

            '�ʴ����� wbs
            tr = parentNode
            tr.Tag = wbsrow
            tr("boqi_itemname") = wbsrow("wbs_code") & "-" & wbsrow("wbs_name")
            '
            tr("BudgetCost") = Configuration.FormatToString(CDec(wbsrow("wbs_budget")), dgt)

            tr("ActualPRCost") = Configuration.FormatToString(CDec(wbsrow("PRActual")), dgt)
            tr("PRDiff") = Configuration.FormatToString(CDec(wbsrow("Diffpr")), dgt)
            '
            tr("ActualPOCost") = Configuration.FormatToString(CDec(wbsrow("POActual")), dgt)
            tr("PoDiff") = Configuration.FormatToString(CDec(wbsrow("DiffPo")), dgt)
            '
            tr("ActualGRCost") = Configuration.FormatToString(CDec(wbsrow("GRActual")), dgt)
            tr("grDiff") = Configuration.FormatToString(CDec(wbsrow("Diffgr")), dgt)
            '
            tr("ActualMWCost") = Configuration.FormatToString(CDec(wbsrow("MWactual")), dgt)
            tr("MWDiff") = Configuration.FormatToString(CDec(wbsrow("diffmw")), dgt)
            stage = "1"

            stage = "2"
            tr.State = RowExpandState.Expanded
          End If

          If detail > 0 Then
            Dim DocPRActual As Decimal = 0
            Dim DocPOActual As Decimal = 0
            Dim DocGRActual As Decimal = 0
            Dim DocMWActual As Decimal = 0
            Dim myDocId As String = ""
            Dim Doctr As TreeRow = Nothing
            Dim DocItemTr As TreeRow = Nothing
            For Each wbsDoc As DataRow In dtDoc.Select("wbsid = " & wbsrow("wbs_id") & " and ismarkup = 0")
              Dim wdoc As New DataRowHelper(wbsDoc)

              If Not myDocId = CStr(wbsDoc("DocId")) Then
                If Not Doctr Is Nothing Then
                  Doctr("actualPRCost") = Configuration.FormatToString(DocPRActual, dgt)
                  Doctr("actualPOCost") = Configuration.FormatToString(DocPOActual, dgt)
                  Doctr("actualGRCost") = Configuration.FormatToString(DocGRActual, dgt)
                  Doctr("actualMWCost") = Configuration.FormatToString(DocMWActual, dgt)
                  DocPRActual = 0
                  DocPOActual = 0
                  DocGRActual = 0
                  DocMWActual = 0
                End If

                '�ʴ��͡������е��
                tr.State = RowExpandState.Expanded
                Doctr = tr.Childs.Add
                Doctr.Tag = wbsDoc
                Doctr("boqi_itemname") = "(�͡���) " & CStr(wbsDoc("DocCode"))
                Doctr.State = RowExpandState.None
                myDocId = CStr(wbsDoc("DocId"))
                Doctr("DocId") = myDocId
                Doctr("note") = CStr(wbsDoc("Docnote"))
              End If

              If detail > 1 Then
                '�ʴ���¡��������͡���
                If Not Doctr Is Nothing Then
                  Doctr.State = RowExpandState.Expanded
                  DocItemTr = Doctr.Childs.Add
                  DocItemTr("boqi_itemname") = wbsDoc("itemName")
                  DocItemTr("UnitPrice") = Configuration.FormatToString(CDec(wbsDoc("UnitPrice")), dgt)
                  DocItemTr("Unit") = IIf(wbsDoc.IsNull("UnitName"), "", wbsDoc("UnitName"))
                  DocItemTr("ActualQuantity") = Configuration.FormatToString(CDec(wbsDoc("Qty")), dgt)
                  DocItemTr("actualPRCost") = Configuration.FormatToString(CDec(wbsDoc("PRActual")), dgt)
                  DocItemTr("actualPOCost") = Configuration.FormatToString(CDec(wbsDoc("POActual")), dgt)
                  DocItemTr("actualGRCost") = Configuration.FormatToString(CDec(wbsDoc("GRActual")), dgt)
                  DocItemTr("actualMWCost") = Configuration.FormatToString(CDec(wbsDoc("MWActual")), dgt)
                  DocItemTr.State = RowExpandState.None
                  DocItemTr("note") = CStr(wbsDoc("itemnote"))
                End If
              End If

              DocPRActual += CDec(wbsDoc("PRActual"))
              DocPOActual += CDec(wbsDoc("POActual"))
              DocGRActual += CDec(wbsDoc("GRActual"))
              DocMWActual += CDec(wbsDoc("MWActual"))
            Next
            If Not Doctr Is Nothing Then
              Doctr("actualPRCost") = Configuration.FormatToString(DocPRActual, dgt)
              Doctr("actualPOCost") = Configuration.FormatToString(DocPOActual, dgt)
              Doctr("actualGRCost") = Configuration.FormatToString(DocGRActual, dgt)
              Doctr("actualMWCost") = Configuration.FormatToString(DocMWActual, dgt)
            End If
          End If
        Next

        '#######################################################################################################

        ' OVER HEAD ############################################################################################
        '#######################################################################################################
        Dim SumMarkAmount As Decimal = 0
        Dim SumPRActualAmout As Decimal = 0
        Dim SumPRDiffAmount As Decimal = 0
        Dim SumPOActualAmout As Decimal = 0
        Dim SumPODiffAmount As Decimal = 0
        Dim SumGRActualAmout As Decimal = 0
        Dim SumGRDiffAmount As Decimal = 0
        Dim SumMWActualAmout As Decimal = 0
        Dim SumMWDiffAmount As Decimal = 0

        Dim tmpMarkAmt As Decimal = 0
        Dim tmpPRActAmt As Decimal = 0
        Dim tmpPOActAmt As Decimal = 0
        Dim tmpGRActAmt As Decimal = 0
        Dim tmpMWActAmt As Decimal = 0
        Dim tmpPRDiffAmt As Decimal = 0
        Dim tmpPODiffAmt As Decimal = 0
        Dim tmpGRDiffAmt As Decimal = 0
        Dim tmpMWDiffAmt As Decimal = 0
        Dim overheadTemp As String = ""
        Dim overheadedtr As TreeRow = Nothing
        Dim overheadtr As TreeRow = Nothing
        Dim markuptr As TreeRow = Nothing
        overheadedtr = dt.Childs.Add
        overheadedtr("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Overhead}")
        If dtMarkUp.Rows.Count > 0 Then
          For Each markuprow As DataRow In dtMarkUp.Select("code_tag = 0")
            Dim mrh As New DataRowHelper(markuprow)

            '���� Over Head
            If Not overheadTemp = CStr(markuprow("code_order")) Then
              If Not overheadtr Is Nothing Then
                overheadtr("BudgetCost") = Configuration.FormatToString(tmpMarkAmt, dgt)

                overheadtr("actualPRCost") = Configuration.FormatToString(tmpPRActAmt, dgt)
                overheadtr("PRDiff") = Configuration.FormatToString(tmpPRDiffAmt, dgt)

                overheadtr("actualPOCost") = Configuration.FormatToString(tmpPOActAmt, dgt)
                overheadtr("PODiff") = Configuration.FormatToString(tmpPODiffAmt, dgt)

                overheadtr("actualGRCost") = Configuration.FormatToString(tmpGRActAmt, dgt)
                overheadtr("GRDiff") = Configuration.FormatToString(tmpGRDiffAmt, dgt)

                overheadtr("actualMWCost") = Configuration.FormatToString(tmpMWActAmt, dgt)
                overheadtr("MWDiff") = Configuration.FormatToString(tmpMWDiffAmt, dgt)
                stage = "3"

                stage = "4"
                tmpMarkAmt = 0
                tmpPRActAmt = 0
                tmpPOActAmt = 0
                tmpGRActAmt = 0
                tmpMWActAmt = 0
                tmpPRDiffAmt = 0
                tmpPODiffAmt = 0
                tmpGRDiffAmt = 0
                tmpMWDiffAmt = 0
              End If

              overheadtr = overheadedtr.Childs.Add
              overheadtr.Tag = markuprow
              overheadtr("boqi_itemName") = markuprow("code_description")
              overheadtr.State = RowExpandState.Expanded
              overheadTemp = CStr(markuprow("code_order"))
            End If

            '������¡�� Markup
            If Not overheadtr Is Nothing Then
              markuptr = overheadtr.Childs.Add
              markuptr.Tag = markuprow
              markuptr("boqi_itemName") = markuprow("markup_name")
              markuptr("BudgetCost") = Configuration.FormatToString(CDec(markuprow("markup_totalamt")), dgt)
              markuptr("actualPRCost") = Configuration.FormatToString(CDec(markuprow("PRActual")), dgt)
              markuptr("PRDiff") = Configuration.FormatToString(CDec(markuprow("diffpr")), dgt)
              markuptr("actualMWCost") = Configuration.FormatToString(CDec(markuprow("POActual")), dgt)
              markuptr("PODiff") = Configuration.FormatToString(CDec(markuprow("diffPO")), dgt)
              markuptr("actualMWCost") = Configuration.FormatToString(CDec(markuprow("GRActual")), dgt)
              markuptr("GRDiff") = Configuration.FormatToString(CDec(markuprow("diffGR")), dgt)
              markuptr("actualMWCost") = Configuration.FormatToString(CDec(markuprow("MWActual")), dgt)
              markuptr("MWlDiff") = Configuration.FormatToString(CDec(markuprow("diffMW")), dgt)
              stage = "5"

              stage = "6"
              SumMarkAmount += CDec(markuprow("markup_totalamt"))
              SumPRActualAmout += CDec(markuprow("PRActual"))
              SumPRDiffAmount += CDec(markuprow("diffPR"))
              SumPOActualAmout += CDec(markuprow("POActual"))
              SumPODiffAmount += CDec(markuprow("diffPO"))
              SumGRActualAmout += CDec(markuprow("GRActual"))
              SumGRDiffAmount += CDec(markuprow("diffGR"))
              SumMWActualAmout += CDec(markuprow("MWActual"))
              SumMWDiffAmount += CDec(markuprow("diffMW"))

              tmpMarkAmt += CDec(markuprow("markup_totalamt"))
              tmpPRActAmt += CDec(markuprow("PRActual"))
              tmpPRDiffAmt += CDec(markuprow("diffPR"))
              tmpPOActAmt += CDec(markuprow("POActual"))
              tmpPODiffAmt += CDec(markuprow("diffPO"))
              tmpGRActAmt += CDec(markuprow("GRActual"))
              tmpGRDiffAmt += CDec(markuprow("diffGR"))
              tmpMWActAmt += CDec(markuprow("MWActual"))
              tmpMWDiffAmt += CDec(markuprow("diffMW"))
              markuptr.State = RowExpandState.Expanded
            End If

            '��¡�������͡�������� Markup
            If detail > 0 Then
              Dim DocPRActual As Decimal = 0
              Dim DocPOActual As Decimal = 0
              Dim DocGRActual As Decimal = 0
              Dim DocMWActual As Decimal = 0
              'Dim myDocId As String = ""
              Dim myTempDoc As String = ""
              Dim DocMarkuptr As TreeRow = Nothing
              Dim DocMarkupItemTr As TreeRow = Nothing

              For Each markupdocrow As DataRow In dtDoc.Select("wbsid = " & markuprow("markup_id") & " and ismarkup = 1")
                Dim mdoch As New DataRowHelper(markupdocrow)
                If Not myTempDoc = CStr(markupdocrow("DocId")) Then
                  If Not DocMarkuptr Is Nothing Then
                    DocMarkuptr("actualPRCost") = Configuration.FormatToString(DocPRActual, dgt)
                    DocMarkuptr("actualPOCost") = Configuration.FormatToString(DocPOActual, dgt)
                    DocMarkuptr("actualGRCost") = Configuration.FormatToString(DocGRActual, dgt)
                    DocMarkuptr("actualMWCost") = Configuration.FormatToString(DocMWActual, dgt)
                    DocMWActual = 0
                  End If

                  '�ʴ��͡������е��
                  DocMarkuptr = markuptr.Childs.Add
                  DocMarkuptr.Tag = markupdocrow
                  DocMarkuptr("boqi_itemname") = markupdocrow("DocCode")
                  DocMarkuptr.State = RowExpandState.Expanded
                  myTempDoc = CStr(markupdocrow("DocId"))
                End If

                If detail > 1 Then
                  If Not DocMarkuptr Is Nothing Then
                    '�ʴ���¡��������͡���
                    DocMarkupItemTr = DocMarkuptr.Childs.Add
                    DocMarkupItemTr("boqi_itemname") = markupdocrow("itemName")
                    DocMarkupItemTr("Unit") = IIf(markupdocrow.IsNull("UnitName"), "", markupdocrow("UnitName"))
                    DocMarkupItemTr("ActualQuantity") = Configuration.FormatToString(CDec(markupdocrow("Qty")), dgt)
                    DocMarkupItemTr("actualPRCost") = Configuration.FormatToString(CDec(markupdocrow("PRActual")), dgt)
                    DocMarkupItemTr("actualPOCost") = Configuration.FormatToString(CDec(markupdocrow("POActual")), dgt)
                    DocMarkupItemTr("actualGRCost") = Configuration.FormatToString(CDec(markupdocrow("GRActual")), dgt)
                    DocMarkupItemTr("actualMWCost") = Configuration.FormatToString(CDec(markupdocrow("MWActual")), dgt)
                    DocMarkupItemTr.State = RowExpandState.None
                  End If
                End If

                DocPRActual += CDec(markupdocrow("PRActual"))
                DocPOActual += CDec(markupdocrow("POActual"))
                DocGRActual += CDec(markupdocrow("GRActual"))
                DocMWActual += CDec(markupdocrow("MWActual"))
              Next
              If Not DocMarkuptr Is Nothing Then
                DocMarkuptr("actualPRCost") = Configuration.FormatToString(DocPRActual, dgt)
                DocMarkuptr("actualPOCost") = Configuration.FormatToString(DocPOActual, dgt)
                DocMarkuptr("actualGRCost") = Configuration.FormatToString(DocGRActual, dgt)
                DocMarkuptr("actualMWCost") = Configuration.FormatToString(DocMWActual, dgt)
                DocPRActual = 0
                DocMWActual = 0
                DocPOActual = 0
                DocMWActual = 0
              End If
            End If
          Next

          If Not overheadtr Is Nothing Then
            overheadtr("Total") = Configuration.FormatToString(tmpMarkAmt, dgt)
            overheadtr("actualPRCost") = Configuration.FormatToString(tmpPRActAmt, dgt)
            overheadtr("PRDiff") = Configuration.FormatToString(tmpPRDiffAmt, dgt)

            overheadtr("actualPOCost") = Configuration.FormatToString(tmpPOActAmt, dgt)
            overheadtr("PODiff") = Configuration.FormatToString(tmpPODiffAmt, dgt)

            overheadtr("actualGRCost") = Configuration.FormatToString(tmpGRActAmt, dgt)
            overheadtr("GRDiff") = Configuration.FormatToString(tmpGRDiffAmt, dgt)

            overheadtr("actualMWCost") = Configuration.FormatToString(tmpMWActAmt, dgt)
            overheadtr("MWDiff") = Configuration.FormatToString(tmpMWDiffAmt, dgt)
            stage = "7"
            'If tmpMarkAmt = 0 Then
            '  overheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
            'Else
            '  overheadtr("TotalPercentDiff") = Configuration.FormatToString((tmpMWDiffAmt / tmpMarkAmt) * 100, dgt) & " %"
            'End If
            stage = "8"
            tmpMarkAmt = 0
            tmpPRActAmt = 0
            tmpPOActAmt = 0
            tmpGRActAmt = 0
            tmpMWActAmt = 0
            tmpPRDiffAmt = 0
            tmpPODiffAmt = 0
            tmpGRDiffAmt = 0
            tmpMWDiffAmt = 0
          End If
        End If

        overheadedtr("BudgetCost") = Configuration.FormatToString(SumMarkAmount, dgt)

        overheadedtr("actualPRCost") = Configuration.FormatToString(SumPRActualAmout, dgt)
        overheadedtr("PRDiff") = Configuration.FormatToString(SumPRDiffAmount, dgt)

        overheadedtr("actualPOCost") = Configuration.FormatToString(SumPOActualAmout, dgt)
        overheadedtr("PODiff") = Configuration.FormatToString(SumPODiffAmount, dgt)

        overheadedtr("actualGRCost") = Configuration.FormatToString(SumGRActualAmout, dgt)
        overheadedtr("GRDiff") = Configuration.FormatToString(SumGRDiffAmount, dgt)

        overheadedtr("actualMWCost") = Configuration.FormatToString(SumMWActualAmout, dgt)
        overheadedtr("MWDiff") = Configuration.FormatToString(SumMWDiffAmount, dgt)
        stage = "9"
        'If SumMarkAmount = 0 Then
        '  overheadedtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        'Else
        '  overheadedtr("TotalPercentDiff") = Configuration.FormatToString((SumMWDiffAmount / SumMarkAmount) * 100, dgt) & " %"
        'End If
        stage = "10"
        overheadedtr.State = RowExpandState.Expanded
        '#######################################################################################################

        'TOTAL #################################################################################################
        '#######################################################################################################
        Dim totalNode As TreeRow = dt.Childs.Add
        totalNode("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Total}")
        totalNode("BudgetCost") = Configuration.FormatToString(SumMarkAmount + SumNetWbsBudget, dgt)

        totalNode("actualPRCost") = Configuration.FormatToString(SumPRActualAmout + SumNetWBsPRActual, dgt)
        totalNode("PRDiff") = Configuration.FormatToString(SumPRDiffAmount + SumNetWBsPRDiff, dgt)

        totalNode("actualPOCost") = Configuration.FormatToString(SumPOActualAmout + SumNetWBsPOActual, dgt)
        totalNode("PODiff") = Configuration.FormatToString(SumPODiffAmount + SumNetWBsPODiff, dgt)

        totalNode("actualGRCost") = Configuration.FormatToString(SumGRActualAmout + SumNetWBsGRActual, dgt)
        totalNode("GRDiff") = Configuration.FormatToString(SumGRDiffAmount + SumNetWBsGRDiff, dgt)

        totalNode("actualMWCost") = Configuration.FormatToString(SumMWActualAmout + SumNetWBsMWActual, dgt)
        totalNode("MWDiff") = Configuration.FormatToString(SumMWDiffAmount + SumNetWBsMWDiff, dgt)
        stage = "11"
        'If SumMarkAmount + SumNetWbsBudget = 0 Then
        '  totalNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        'Else
        '  totalNode("TotalPercentDiff") = Configuration.FormatToString(((SumMWDiffAmount + SumNetWBsDiff) / (SumMarkAmount + SumNetWbsBudget)) * 100, dgt) & " %"
        'End If
        stage = "12"
        totalNode.State = RowExpandState.Expanded
        '#######################################################################################################

        ''PROFIT ################################################################################################
        ''#######################################################################################################
        'Dim SumProfitAmt As Decimal = 0
        'Dim SumProfitActualAmt As Decimal = 0
        'Dim SumDiffProfitAmt As Decimal = 0
        'Dim profitheadedtr As TreeRow = Nothing
        'Dim profitheadtr As TreeRow = Nothing
        'Dim itemtr As TreeRow = Nothing

        'profitheadedtr = dt.Childs.Add
        'profitheadedtr("boqi_itemName") = Me.StringParserService.Parse("${res:Global.Profit}" & "<�����Թ>")

        'If dtMarkUp.Rows.Count > 0 Then
        '  For Each profitrow As DataRow In dtMarkUp.Select("code_tag = 1")

        '    profitheadtr = profitheadedtr.Childs.Add

        '    profitheadtr("boqi_itemName") = profitrow("markup_name")
        '    profitheadtr("Total") = Configuration.FormatToString(CDec(profitrow("markup_totalamt")), dgt)
        '    'profitheadtr("actualMWCost") = Configuration.FormatToString(CDec(profitrow("MWActual")), dgt)
        '    profitheadtr("TotalDiff") = Configuration.FormatToString(CDec(profitrow("diffamount")), dgt)
        '    stage = "13"
        '    'If CDec(profitrow("markup_totalamt")) = 0 Then
        '    '  profitheadtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        '    'Else
        '    '  profitheadtr("TotalPercentDiff") = Configuration.FormatToString((CDec(profitrow("diffamount")) / CDec(profitrow("markup_totalamt"))) * 100, dgt) & " %"
        '    'End If
        '    stage = "14"
        '    SumProfitAmt += CDec(profitrow("markup_totalamt"))
        '    SumProfitActualAmt += CDec(profitrow("MWActual"))
        '    SumDiffProfitAmt += CDec(profitrow("diffamount"))
        '    profitheadtr.State = RowExpandState.Expanded
        '  Next
        'End If

        'profitheadedtr("Total") = Configuration.FormatToString(SumProfitAmt, dgt)
        ''profitheadedtr("actualMWCost") = Configuration.FormatToString(SumProfitActualAmt, dgt)
        'profitheadedtr("TotalDiff") = Configuration.FormatToString(SumDiffProfitAmt, dgt)
        'stage = "15"
        ''If SumProfitAmt = 0 Then
        ''    profitheadedtr("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        ''Else
        ''    profitheadedtr("TotalPercentDiff") = Configuration.FormatToString((SumDiffProfitAmt / SumProfitAmt) * 100, dgt) & " %"
        ''End If
        'stage = "16"
        'profitheadedtr.State = RowExpandState.Expanded
        ''#######################################################################################################

        ''NET PROFIT ############################################################################################
        ''#######################################################################################################
        'Dim netNode As TreeRow = dt.Childs.Add
        'netNode("boqi_itemName") = Me.StringParserService.Parse("����(�Ҵ�ع)�ط��")
        ''netNode("Total") = Configuration.FormatToString(NetProfitTotal, dgt)
        ''netNode("actualMWCost") = Configuration.FormatToString(NetProfitActual, dgt)
        'netNode("TotalDiff") = Configuration.FormatToString(SumMWDiffAmount + SumNetWBsDiff + SumDiffProfitAmt, dgt)
        'stage = "17"
        ''If (SumTotalDiffAmount + SumNetWBsDiff) = 0 Then
        ''    netNode("TotalPercentDiff") = Configuration.FormatToString(0, dgt) & " %"
        ''Else
        ''    netNode("TotalPercentDiff") = Configuration.FormatToString(((SumTotalDiffAmount + SumNetWBsDiff - SumDiffProfitAmt) / (SumTotalDiffAmount + SumNetWBsDiff)) * 100, dgt) & " %"
        ''End If
        'stage = "18"
        'netNode.State = RowExpandState.Expanded
        ''#######################################################################################################


        Dim i As Integer = 0
        'For Each row As DataRow In dt.Rows
        '  i += 1
        '  row("boqi_linenumber") = i
        'Next
        m_hashData = New Hashtable
        For Each row As TreeRow In dt.Rows
          i += 1
          row("boqi_linenumber") = i
          If Not row.Tag Is Nothing Then
            m_hashData(i) = row.Tag
          End If
        Next
        If i > 0 Then
          dt.AcceptChanges()
        End If
      Catch ex As Exception
        MessageBox.Show(stage & vbCrLf & ex.Message)
      End Try

    End Sub
    'Private Function SumValueInDataTable(ByVal dr() As DataRow, ByVal field As String) As Decimal
    '    Dim ret As Decimal = 0
    '    For Each drtmp As DataRow In dr
    '        If Not drtmp.IsNull(field) Then
    '            ret += CDec(drtmp(field))
    '        End If
    '    Next
    '    Return ret
    'End Function
    Public Overrides Sub RefreshDataSet()
      m_cc = New CostCenter
      If TypeOf Me.Filters(0).Value Is CostCenter Then
        m_cc = CType(Me.Filters(0).Value, CostCenter)
      End If
      '����¹��ҷ������ StoredProcedure ������� Object �� ID
      If Not Me.Filters(0).Value Is DBNull.Value Then
        Me.Filters(0).Value = m_cc.Id
      End If
      If Not Me.Filters(4).Value Is Nothing AndAlso TypeOf Me.Filters(4).Value Is Employee Then
        Me.Filters(4).Value = Me.Filters(4).Value.Id
      End If
      '
      If Not m_cc Is Nothing AndAlso m_cc.Originated Then
        MyBase.RefreshDataSet()
      End If
    End Sub
#End Region

#Region "Select Distinct From DataTable"
    'Public Function SelectDistinct(ByVal SourceTable As DataTable, ByVal ParamArray FieldNames() As String) As DataTable
    '    Dim lastValues() As Object
    '    Dim newTable As DataTable

    '    If FieldNames Is Nothing OrElse FieldNames.Length = 0 Then
    '        Throw New ArgumentNullException("FieldNames")
    '    End If

    '    lastValues = New Object(FieldNames.Length - 1) {}
    '    newTable = New DataTable

    '    For Each field As String In FieldNames
    '        newTable.Columns.Add(field, SourceTable.Columns(field).DataType)
    '    Next

    '    For Each Row As DataRow In SourceTable.Select("", String.Join(", ", FieldNames))
    '        If Not fieldValuesAreEqual(lastValues, Row, FieldNames) Then
    '            newTable.Rows.Add(createRowClone(Row, newTable.NewRow(), FieldNames))

    '            setLastValues(lastValues, Row, FieldNames)
    '        End If
    '    Next

    '    Return newTable
    'End Function
    Private Function fieldValuesAreEqual(ByVal lastValues() As Object, ByVal currentRow As DataRow, ByVal fieldNames() As String) As Boolean
      Dim areEqual As Boolean = True

      For i As Integer = 0 To fieldNames.Length - 1
        If lastValues(i) Is Nothing OrElse Not lastValues(i).Equals(currentRow(fieldNames(i))) Then
          areEqual = False
          Exit For
        End If
      Next

      Return areEqual
    End Function
    Private Function createRowClone(ByVal sourceRow As DataRow, ByVal newRow As DataRow, ByVal fieldNames() As String) As DataRow
      For Each field As String In fieldNames
        newRow(field) = sourceRow(field)
      Next

      Return newRow
    End Function
    Private Sub setLastValues(ByVal lastValues() As Object, ByVal sourceRow As DataRow, ByVal fieldNames() As String)
      For i As Integer = 0 To fieldNames.Length - 1
        lastValues(i) = sourceRow(fieldNames(i))
      Next
    End Sub
#End Region

#Region "Shared"
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptWBSMonitorAll"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitorAll.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptWBSMonitor"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptWBSMonitorAll.ListLabel}"
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
    Public Property AdvanceFindCollection() As AdvanceFindCollection

#End Region

#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "RptWBSBudgetUsage"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptWBSBudgetUsage"
    End Function

    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      dpi = New DocPrintingItem
      dpi.Mapping = "CostCode"
      dpi.Value = m_cc.Code  'Me.Filters(0).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "CostCenterName"
      dpi.Value = m_cc.Name 'Me.Filters(0).Value
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "DocdateEnd"
      If Not IsDBNull(Me.Filters(1).Value) Then
        dpi.Value = CDate(Me.Filters(1).Value).ToShortDateString
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'Dim typeString As String = ""
      'Dim type As BOQ.WBSReportType
      'If TypeOf Me.Filters(3).Value Is BOQ.WBSReportType Then
      '  type = CType(Me.Filters(3).Value, BOQ.WBSReportType)
      'End If
      'Select Case type
      '  Case BOQ.WBSReportType.PR
      '    typeString = "�ͫ���"
      '  Case BOQ.WBSReportType.PO
      '    typeString = "��觫���"
      '  Case BOQ.WBSReportType.GoodsReceipt
      '    typeString = "�Ѻ�ͧ"
      '  Case BOQ.WBSReportType.MatWithdraw
      '    typeString = "�ԡ�ͧ"
      'End Select
      'dpi = New DocPrintingItem
      'dpi.Mapping = "Type"
      'dpi.Value = typeString
      'dpi.DataType = "System.String"
      'dpiColl.Add(dpi)

      dpi = New DocPrintingItem
      dpi.Mapping = "Requester"
      If Not IsDBNull(Me.Filters(4).Value) Then
        dpi.Value = New Employee(CInt(Me.Filters(4).Value)).Name
      End If
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      Dim i As Integer = 0
      Dim r As Integer = 0
      For Each itemRow As DataRow In Me.Treemanager.Treetable.Rows
        For j As Integer = 1 To Me.Treemanager.Treetable.Columns.Count - 1
          dpi = New DocPrintingItem
          dpi.Mapping = "col" & j
          dpi.Value = itemRow(Me.Treemanager.Treetable.Columns(j))
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)
        Next

        r = i + 1
        Dim dr As Object = m_hashData(r)
        If Not dr Is Nothing Then
          If TypeOf dr Is DataRow Then
            Dim row As DataRow = CType(dr, DataRow)
            If row.Table.TableName = "Table0" Then
              Dim drh As New DataRowHelper(row)

              dpi = New DocPrintingItem
              dpi.Mapping = "col1.1"
              dpi.Value = drh.GetValue(Of String)("wbs_code")
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              dpi = New DocPrintingItem
              dpi.Mapping = "col1.2"
              dpi.Value = drh.GetValue(Of String)("wbs_name")
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)
            End If
          End If
        End If

        i += 1
      Next

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

