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
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptSCManagement
    Inherits Report
    Implements INewReport

#Region "Members"
    Private m_reportColumns As ReportColumnCollection
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
    Public Shared Function CreateWBSTableStyle() As DataGridTableStyle
      Dim dst As New DataGridTableStyle
      dst.MappingName = "BOQ"
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)

      Dim csLineNumber As New TreeTextColumn
      csLineNumber.MappingName = "linenumber"
      csLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.LineNumberHeaderText}")
      csLineNumber.NullText = ""
      csLineNumber.Width = 30
      csLineNumber.DataAlignment = HorizontalAlignment.Center
      csLineNumber.ReadOnly = True
      csLineNumber.TextBox.Name = "linenumber"

      Dim csName As New PlusMinusTreeTextColumn
      csName.MappingName = "Name"
      csName.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.NameHeaderText}")
      csName.NullText = ""
      csName.Width = 329
      csName.TextBox.Name = "Name"
      csName.ReadOnly = True

      Dim csBarrier0 As New DataGridBarrierColumn
      csBarrier0.MappingName = "Barrier0"
      csBarrier0.HeaderText = ""
      csBarrier0.NullText = ""
      csBarrier0.ReadOnly = True

      'Dim csDescription As New TreeTextColumn
      'csDescription.MappingName = "Description"
      'csDescription.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.DescriptionHeaderText}")
      'csDescription.NullText = ""
      'csDescription.Width = 190
      'csDescription.TextBox.Name = "Description"
      'csDescription.ReadOnly = True

      Dim csDate As New TreeTextColumn
      csDate.MappingName = "Date"
      csDate.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.DateHeaderText}")
      csDate.NullText = ""
      csDate.DataAlignment = HorizontalAlignment.Center
      csDate.TextBox.Name = "Date"
      csDate.ReadOnly = True

      Dim csBarrier1 As New DataGridBarrierColumn
      csBarrier1.MappingName = "Barrier1"
      csBarrier1.HeaderText = ""
      csBarrier1.NullText = ""
      csBarrier1.ReadOnly = True

      Dim csWBSBudget As New TreeTextColumn
      csWBSBudget.MappingName = "WBSBudget"
      csWBSBudget.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.WBSBudgetHeaderText}")
      csWBSBudget.NullText = ""
      csWBSBudget.Width = 120
      csWBSBudget.DataAlignment = HorizontalAlignment.Right
      csWBSBudget.Format = "#,###.##"
      csWBSBudget.TextBox.Name = "WBSBudget"
      csWBSBudget.ReadOnly = True

      Dim csBarrier2 As New DataGridBarrierColumn
      csBarrier2.MappingName = "Barrier2"
      csBarrier2.HeaderText = ""
      csBarrier2.NullText = ""
      csBarrier2.ReadOnly = True

      Dim csTotalSC As New TreeTextColumn
      csTotalSC.MappingName = "TotalSC"
      csTotalSC.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.TotalSCHeaderText}")
      csTotalSC.NullText = ""
      csTotalSC.DataAlignment = HorizontalAlignment.Right
      csTotalSC.Format = "#,###.##"
      csTotalSC.TextBox.Name = "TotalSC"
      csTotalSC.ReadOnly = True

      Dim csTotalRetention As New TreeTextColumn
      csTotalRetention.MappingName = "TotalRetention"
      csTotalRetention.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.TotalRetentionHeaderText}")
      csTotalRetention.NullText = ""
      csTotalRetention.Width = 120
      csTotalRetention.DataAlignment = HorizontalAlignment.Right
      csTotalRetention.Format = "#,###.##"
      csTotalRetention.TextBox.Name = "TotalRetention"
      csTotalRetention.ReadOnly = True

      Dim csTotalPA As New TreeTextColumn
      csTotalPA.MappingName = "TotalPA"
      csTotalPA.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.TotalGoodsReceiptHeaderText}")
      csTotalPA.NullText = ""
      csTotalPA.DataAlignment = HorizontalAlignment.Right
      csTotalPA.Format = "#,###.##"
      csTotalPA.TextBox.Name = "TotalPA"
      csTotalPA.ReadOnly = True

      Dim csTotalReceiptRemain As New TreeTextColumn
      csTotalReceiptRemain.MappingName = "TotalReceiptRemain"
      csTotalReceiptRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.TotalReceiptRemainHeaderText}")
      csTotalReceiptRemain.NullText = ""
      csTotalReceiptRemain.DataAlignment = HorizontalAlignment.Right
      csTotalReceiptRemain.Format = "#,###.##"
      csTotalReceiptRemain.TextBox.Name = "TotalReceiptRemain"
      csTotalReceiptRemain.ReadOnly = True

      Dim csTotalPayment As New TreeTextColumn
      csTotalPayment.MappingName = "TotalPayment"
      csTotalPayment.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.TotalPaymentHeaderText}")
      csTotalPayment.NullText = ""
      csTotalPayment.DataAlignment = HorizontalAlignment.Right
      csTotalPayment.Format = "#,###.##"
      csTotalPayment.TextBox.Name = "TotalPayment"
      csTotalPayment.ReadOnly = True

      Dim csTotalRetentionPayment As New TreeTextColumn
      csTotalRetentionPayment.MappingName = "TotalRetentionPayment"
      csTotalRetentionPayment.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.TotalRetentionPaymentHeaderText}")
      csTotalRetentionPayment.NullText = ""
      csTotalRetentionPayment.Width = 120
      csTotalRetentionPayment.DataAlignment = HorizontalAlignment.Right
      csTotalRetentionPayment.Format = "#,###.##"
      csTotalRetentionPayment.TextBox.Name = "TotalRetentionPayment"
      csTotalRetentionPayment.ReadOnly = True

      Dim csTotalPaymentRemain As New TreeTextColumn
      csTotalPaymentRemain.MappingName = "TotalPaymentRemain"
      csTotalPaymentRemain.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.TotalPaymentRemainHeaderText}")
      csTotalPaymentRemain.NullText = ""
      csTotalPaymentRemain.DataAlignment = HorizontalAlignment.Right
      csTotalPaymentRemain.Format = "#,###.##"
      csTotalPaymentRemain.TextBox.Name = "TotalPaymentRemain"
      csTotalPaymentRemain.ReadOnly = True

      Dim csNote As New TreeTextColumn
      csNote.MappingName = "Note"
      csNote.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.NoteHeaderText}")
      csNote.NullText = ""
      csNote.DataAlignment = HorizontalAlignment.Left
      csNote.TextBox.Name = "Note"
      csNote.Width = 190
      csNote.ReadOnly = True

      Dim csIsBold As New TreeTextColumn
      csIsBold.MappingName = "IsBold"
      csIsBold.HeaderText = ""
      csIsBold.NullText = ""
      csIsBold.Width = 0
      csIsBold.DataAlignment = HorizontalAlignment.Right
      csIsBold.TextBox.Name = "IsBold"
      csIsBold.ReadOnly = True

      Dim csWbsLevel As New TreeTextColumn
      csIsBold.MappingName = "Level"
      csIsBold.HeaderText = ""
      csIsBold.NullText = ""
      csIsBold.Width = 0
      csIsBold.DataAlignment = HorizontalAlignment.Right
      csIsBold.TextBox.Name = "Level"
      csIsBold.ReadOnly = True

      dst.GridColumnStyles.Add(csLineNumber)
      dst.GridColumnStyles.Add(csName)
      dst.GridColumnStyles.Add(csBarrier0)
      'dst.GridColumnStyles.Add(csDescription)
      dst.GridColumnStyles.Add(csDate)
      dst.GridColumnStyles.Add(csBarrier1)
      dst.GridColumnStyles.Add(csWBSBudget)
      dst.GridColumnStyles.Add(csBarrier2)
      dst.GridColumnStyles.Add(csTotalSC)
      dst.GridColumnStyles.Add(csTotalRetention)
      dst.GridColumnStyles.Add(csTotalPA)
      dst.GridColumnStyles.Add(csTotalReceiptRemain)
      dst.GridColumnStyles.Add(csTotalPayment)
      dst.GridColumnStyles.Add(csTotalRetentionPayment)
      dst.GridColumnStyles.Add(csTotalPaymentRemain)
      dst.GridColumnStyles.Add(csIsBold)
      dst.GridColumnStyles.Add(csWbsLevel)
      dst.GridColumnStyles.Add(csNote)

      Return dst
    End Function
    Public Shared Function GetWBSSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("BOQ")
      Dim selectedCol As New DataColumn("Selected", GetType(Boolean))
      selectedCol.DefaultValue = False
      myDatatable.Columns.Add(selectedCol)
      myDatatable.Columns.Add(New DataColumn("linenumber", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Name", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Barrier0", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Description", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Date", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("WBSBudget", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Barrier2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalSC", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalRetention", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalPA", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalGoodsReceipt", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalReceiptRemain", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalPayment", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalRetentionPayment", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("TotalPaymentRemain", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("IsBold", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("Level", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Note", GetType(String)))

      Return myDatatable
    End Function
#End Region

#Region "Overrides"
    Public Overrides Function GetSimpleSchemaTable() As Gui.Components.TreeTable
      Return Me.GetWBSSchemaTable
    End Function
    Public Overrides Function CreateSimpleTableStyle() As System.Windows.Forms.DataGridTableStyle
      Return Me.CreateWBSTableStyle
    End Function
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid

      Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
      lkg.DefaultBehavior = False
      lkg.HilightWhenMinus = True
      lkg.Init()
      lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      Dim tm As New Treemanager(GetSimpleSchemaTable, New TreeGrid)
      ListInGrid(tm)
      lkg.TreeTableStyle = CreateSimpleTableStyle()
      lkg.TreeTable = tm.Treetable
      lkg.Cols.FrozenCount = 3
      lkg.HilightGroupParentText = True
      lkg.Refresh()
    End Sub
    Public Overrides Sub ListInGrid(ByVal tm As Gui.Components.TreeManager)
      Me.m_treemanager = tm
      Dim nodigit As Boolean = False
      If Me.Filters(9).Name.ToLower = "nodigit" Then
        nodigit = CBool(Me.Filters(9).Value)
      End If
      PopulateListing(tm.Treetable, nodigit)
    End Sub
    Public Sub PopulateListing(ByVal dtp As TreeTable, Optional ByVal noDigit As Boolean = False)
      Dim dgt As DigitConfig = DigitConfig.Price
      If noDigit Then
        dgt = DigitConfig.Int
      End If
      dtp.Clear()
      Dim dt As DataTable = Me.DataSet.Tables(0) ''Cost Center & WBS
      Dim dt1 As DataTable = Me.DataSet.Tables(1) ''Supplier
      Dim dt2 As DataTable = Me.DataSet.Tables(2) ''SC
      Dim dt3 As DataTable = Me.DataSet.Tables(3) ''PA
      If dt.Rows.Count <= 0 Then
        Return
      End If

      ' WBS ##################################################################################################
      '#######################################################################################################
      Dim Nodes As New Hashtable
      Dim myParent As String
      Dim parentNode As TreeRow = Nothing
      Dim myTempId As Integer = 0

      Dim SumWBSBudget As Decimal = 0
      Dim SumNetWbsBudget As Decimal = 0

      Dim SumSCAmt As Decimal = 0
      Dim SumSCAmtByCostCenter As Decimal = 0
      Dim SumNetSCAmt As Decimal = 0

      'Dim SumStockAmt As Decimal = 0
      'Dim SumStockAmtBySupplier As Decimal = 0
      'Dim SumStockAmtBycostCenter As Decimal = 0
      'Dim SumNetStockAmt As Decimal = 0

      Dim SumRetentionAmt As Decimal = 0
      Dim SumRetentionBySupplier As Decimal = 0
      Dim SumRetentionByCostCenter As Decimal = 0
      Dim SumNetRetentionAmt As Decimal = 0

      Dim SumPaymentAmt As Decimal = 0
      Dim SumPaymentBySupplier As Decimal = 0
      Dim SumPaymentByCostCenter As Decimal = 0
      Dim SumNetPaymentAmt As Decimal = 0

      Dim SumPayRetentionAmt As Decimal = 0
      Dim SumPayRetentionBySupplier As Decimal = 0
      Dim SumPayRetentionByCostCenter As Decimal = 0
      Dim SumNetPayRetentionAmt As Decimal = 0

      Dim tr As TreeRow
      Dim trCC As TreeRow = Nothing
      Dim currCostCenter As String = ""
      Dim currLevel As Integer

      For Each ccRow As DataRow In dt.Rows
        For Each ccBoq As DataRow In dt1.Select("wbs_boq = " & ccRow("cc_boq"))

          If Not currCostCenter.Equals(CStr(ccRow("cc_code"))) Then
            If Not trCC Is Nothing Then
              trCC("WBSBudget") = Configuration.FormatToString(SumWBSBudget, dgt)
              trCC("TotalSC") = Configuration.FormatToString(SumSCAmtByCostCenter, dgt)
              'trCC("TotalRetention") = Configuration.FormatToString(SumRetentionByCostCenter, dgt)

              'trCC("TotalGoodsReceipt") = Configuration.FormatToString(SumStockAmtBycostCenter, dgt)

              'trCC("TotalReceiptRemain") = Configuration.FormatToString(SumSCAmtByCostCenter - SumStockAmtBycostCenter - SumRetentionByCostCenter, dgt)
              trCC("TotalPayment") = Configuration.FormatToString(SumPaymentByCostCenter, dgt)
              'trCC("TotalRetentionPayment") = Configuration.FormatToString(SumPayRetentionByCostCenter, dgt)
              'trCC("TotalPaymentRemain") = Configuration.FormatToString(SumStockAmtBycostCenter - SumPaymentByCostCenter - SumPayRetentionByCostCenter, dgt)
              trCC("IsBold") = True
            End If

            ''CostCenter List
            trCC = dtp.Childs.Add
            trCC("Name") = "(" & StringParserService.Parse("${res:Global.CostCenterText}") & ") " & _
                        ccRow("cc_code") & " : " & ccRow("cc_name")
            trCC("IsBold") = True
            trCC("Level") = 0
            trCC.State = RowExpandState.Expanded

            SumWBSBudget = 0
            SumSCAmtByCostCenter = 0
            'SumStockAmtBycostCenter = 0
            'SumRetentionByCostCenter = 0
            SumPaymentByCostCenter = 0
            'SumPayRetentionByCostCenter = 0
            currCostCenter = CStr(ccRow("cc_code"))
          End If

          If CInt(ccBoq("wbs_level")) = 0 Then
            parentNode = trCC.Childs.Add
            SumNetWbsBudget += CDec(ccBoq("wbs_budget"))
            SumWBSBudget += CDec(ccBoq("wbs_budget"))
            'SumRetentionByCostCenter += CDec(ccBoq("sc_retention"))

            'SumSCAmtByCostCenter += CDec(ccBoq("wbs_SCamt"))
            'SumNetSCAmt += CDec(ccBoq("sc_aftertax"))
            'SumStockAmtBycostCenter += CDec(ccBoq("wbs_stockamt"))
            'SumNetStockAmt += CDec(ccBoq("wbs_stockamt"))

            'SumNetRetentionAmt += CDec(ccBoq("wbs_retention"))
            'SumPaymentByCostCenter += CDec(ccBoq("wbs_payamt"))
            'SumNetPaymentAmt += CDec(ccBoq("wbs_payamt"))
            'SumPayRetentionByCostCenter += CDec(ccBoq("wbs_payretentionamt"))
            'SumNetPayRetentionAmt += CDec(ccBoq("wbs_payretentionamt"))
          Else
            myParent = CStr(ccBoq("Parent"))
            parentNode = Nodes(myParent).Childs.Add
          End If
          If Not parentNode Is Nothing Then
            Nodes(CStr(ccBoq("wbs_path"))) = parentNode
            '�ʴ����� wbs
            tr = parentNode
            If CInt(ccBoq("wbs_level")) = 0 Then
              tr("Name") = "(" & Me.StringParserService.Parse("${res:Global.ProjectText}") & ") " & _
                          ccBoq("wbs_code") & " : " & ccBoq("wbs_name")
            Else
              tr("Name") = ccBoq("wbs_code") & " : " & ccBoq("wbs_name")
            End If
            '
            tr("WBSBudget") = Configuration.FormatToString(CDec(ccBoq("wbs_budget")), dgt)
            'tr("TotalSC") = Configuration.FormatToString(CDec(ccBoq("sc_aftertax")), dgt)
            'tr("TotalGoodsReceipt") = Configuration.FormatToString(CDec(ccBoq("wbs_stockamt")), dgt)

            'tr("TotalRetention") = Configuration.FormatToString(CDec(ccBoq("wbs_retention")), dgt)
            'tr("TotalReceiptRemain") = Configuration.FormatToString(CDec(ccBoq("wbs_poamt")) - CDec(ccBoq("wbs_stockamt")) - CDec(ccBoq("wbs_retention")), dgt)
            'tr("TotalPayment") = Configuration.FormatToString(CDec(ccBoq("wbs_payamt")), dgt)
            'tr("TotalRetentionPayment") = Configuration.FormatToString(CDec(ccBoq("wbs_payretentionamt")), dgt)
            'tr("TotalPaymentRemain") = Configuration.FormatToString(CDec(ccBoq("wbs_stockamt")) - CDec(ccBoq("wbs_payamt")) - CDec(ccBoq("wbs_payretentionamt")), dgt)
            'tr("IsBold") = True
            If Not ccBoq.IsNull("wbs_level") Then
              tr("Level") = CInt(ccBoq("wbs_level")) + 1
              currLevel = CInt(ccBoq("wbs_level")) + 1
            End If

            tr.State = RowExpandState.Expanded
          End If

          If Me.Filters(7).Value > 0 Then
            'MessageBox.Show(Me.Filters(7).Value)

            ''Show Detail

            Dim trSupplier As TreeRow = Nothing
            Dim currSupplier As String = ""
            Dim trSC As TreeRow = Nothing
            Dim trPA As TreeRow = Nothing
            'SC List
            For Each scRow As DataRow In dt2.Select("sciw_cc =" & ccRow("cc_id") & " and sciw_wbs = " & ccBoq("wbs_id"))
              If Not currSupplier.Equals(CStr(scRow("wbs_boq")) & CStr(scRow("sciw_wbs")) & CStr(scRow("sc_subcontractor"))) Then

                If Not trSupplier Is Nothing Then
                  trSupplier("TotalSC") = Configuration.FormatToString(SumSCAmt, dgt)
                  trSupplier("TotalRetention") = Configuration.FormatToString(SumRetentionBySupplier, dgt)

                  'trSupplier("TotalGoodsReceipt") = Configuration.FormatToString(SumStockAmtBySupplier, dgt)
                  'trSupplier("TotalRetention") = Configuration.FormatToString(CDec(scRow("sc_retention")), dgt)

                  'trSupplier("TotalRetention") = Configuration.FormatToString(SumRetentionBySupplier, dgt)
                  'trSupplier("TotalReceiptRemain") = Configuration.FormatToString(SumSCAmt - SumStockAmtBySupplier - SumRetentionBySupplier, dgt)
                  trSupplier("TotalPayment") = Configuration.FormatToString(SumPaymentBySupplier, dgt)
                  'trSupplier("TotalRetentionPayment") = Configuration.FormatToString(SumPayRetentionBySupplier, dgt)
                  'trSupplier("TotalPaymentRemain") = Configuration.FormatToString(SumStockAmtBySupplier - SumPaymentBySupplier - SumPayRetentionBySupplier, dgt)
                End If

                trSupplier = tr.Childs.Add
                trSupplier("Name") = "(" & Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSCManagement.SupplierinColumnText}") & ") " & _
                scRow("supplier_code") & " : " & scRow("supplier_name")
                'trSupplier("TotalReceiptRemain") = Configuration.FormatToString(CDec(scRow("sc_aftertax")) - SumStockAmt, dgt)
                trSupplier("Level") = currLevel + 1
                trSupplier.State = RowExpandState.Expanded

                SumSCAmt = 0
                'SumStockAmtBySupplier = 0
                SumRetentionBySupplier = 0
                'SumPaymentBySupplier = 0
                'SumPayRetentionBySupplier = 0
                currSupplier = CStr(scRow("wbs_boq")) & CStr(scRow("sciw_wbs")) & CStr(scRow("sc_subcontractor"))
              End If

              SumSCAmt += CDec(scRow("scCost"))
              SumNetSCAmt += CDec(scRow("scCost"))
              SumRetentionBySupplier += CDec(scRow("sc_retention"))

              trSC = trSupplier.Childs.Add
              trSC("Name") = scRow("sc_code")
              'trSC("Description") = scRow("sc_note")
              trSC("TotalRetention") = Configuration.FormatToString(CDec(scRow("sc_retention")), dgt)
              If Not scRow.IsNull("sc_docdate") Then
                If IsDate(scRow("sc_docdate")) Then
                  trSC("Date") = CDate(scRow("sc_docdate")).ToShortDateString
                End If
              End If
              trSC("TotalSC") = Configuration.FormatToString(CDec(scRow("SCCost")), dgt)
              trSC("Note") = scRow("sc_note")

              trSC("Level") = currLevel + 2

              trSC.State = RowExpandState.Expanded
              'SumStockAmt = 0
              Dim trPAtb As TreeRow = Nothing
              For Each paRow As DataRow In dt3.Select("pa_subcontractor = " & scRow("sc_subcontractor") & " and pa_sc = " & scRow("sc_id") & _
                                                 " and paiw_cc =" & ccRow("cc_id") & _
                                                 " and paiw_wbs = " & ccBoq("wbs_id"))            ' & " and stock_tocc = " & poRow("po_cc"))
                trPA = trSC.Childs.Add
                trPA("Name") = paRow("pa_code")
                'trPA("Description") = paRow("pa_note")
                If Not paRow.IsNull("pa_docdate") Then
                  If IsDate(paRow("pa_docdate")) Then
                    trPA("Date") = CDate(paRow("pa_docdate")).ToShortDateString
                  End If
                End If
                trPA("TotalPA") = Configuration.FormatToString(CDec(paRow("PAAmount")), dgt)
                trPA("Note") = paRow("pa_note")

                'trPA("TotalGoodsReceipt") = Configuration.FormatToString(CDec(PAtRow("pa_aftertax")), dgt)
                'trPA("TotalRetention") = Configuration.FormatToString(CDec(PAtRow("pa_retention")), dgt)
                'trPA("TotalReceiptRemain") = Configuration.FormatToString(CDec(PAtRow("stock_aftertax")), dgt)
                'trPA("TotalPayment") = Configuration.FormatToString(CDec(PAtRow("pays_amt")), dgt)
                'trPA("TotalRetentionPayment") = Configuration.FormatToString(CDec(PAtRow("pays_retentionamt")), dgt)

                'trPA("TotalPaymentRemain") = Configuration.FormatToString(CDec(PAtRow("stock_aftertax")) - CDec(PAtRow("pays_amt")) - CDec(PAtRow("pays_retentionamt")), dgt)
                trPA("Level") = currLevel + 3

                'SumStockAmt += CDec(PAtRow("stock_aftertax"))
                'SumStockAmtBySupplier += CDec(PAtRow("stock_aftertax"))
                'SumRetentionAmt += CDec(PAtRow("stock_retention"))
                'SumRetentionBySupplier += CDec(PAtRow("stock_retention"))
                'SumPaymentAmt += CDec(PAtRow("pays_amt"))
                'SumPaymentBySupplier += CDec(PAtRow("pays_amt"))
                'SumPayRetentionAmt += CDec(PAtRow("pays_retentionamt"))
                'SumPayRetentionBySupplier += CDec(PAtRow("pays_retentionamt"))

                trPA.State = RowExpandState.Expanded
              Next
              'trSC("TotalGoodsReceipt") = Configuration.FormatToString(SumStockAmt, dgt)
              'trSC("TotalRetention") = Configuration.FormatToString(SumRetentionAmt, dgt)
              'trSC("TotalReceiptRemain") = Configuration.FormatToString(CDec(scRow("sc_aftertax")) - SumStockAmt - SumRetentionAmt, dgt)
              'trSC("TotalPayment") = Configuration.FormatToString(SumPaymentAmt, dgt)
              'trSC("TotalRetentionPayment") = Configuration.FormatToString(SumPayRetentionAmt, dgt)
              'trSC("TotalPaymentRemain") = Configuration.FormatToString(SumStockAmt - SumPaymentAmt - SumPayRetentionAmt, dgt)
              'SumStockAmt = 0
              'SumRetentionAmt = 0
              'SumPaymentAmt = 0
              'SumPayRetentionAmt = 0
            Next
            '����Ѻ sc �ش����
            If Not trSupplier Is Nothing Then
              trSupplier("TotalSC") = Configuration.FormatToString(SumSCAmt, dgt)
              trSupplier("TotalRetention") = Configuration.FormatToString(SumRetentionBySupplier, dgt)
              'trSupplier("TotalGoodsReceipt") = Configuration.FormatToString(SumStockAmtBySupplier, dgt)
              'trSupplier("TotalReceiptRemain") = Configuration.FormatToString(SumSCAmt - SumStockAmtBySupplier - SumRetentionBySupplier, dgt)
              trSupplier("TotalPayment") = Configuration.FormatToString(SumPaymentBySupplier, dgt)
              'trSupplier("TotalRetentionPayment") = Configuration.FormatToString(SumPayRetentionBySupplier, dgt)
              'trSupplier("TotalPaymentRemain") = Configuration.FormatToString(SumStockAmtBySupplier - SumPaymentBySupplier - SumPayRetentionBySupplier, dgt)
              trSupplier.State = RowExpandState.Expanded
            End If
          End If
        Next

        '�����Һ Cost Center �ش����
        If Not trCC Is Nothing Then
          trCC("WBSBudget") = Configuration.FormatToString(SumWBSBudget, dgt)
          trCC("TotalSC") = Configuration.FormatToString(SumSCAmtByCostCenter, dgt)
          trCC("TotalRetention") = Configuration.FormatToString(SumRetentionBySupplier, dgt)
          'trCC("TotalGoodsReceipt") = Configuration.FormatToString(SumStockAmtBycostCenter, dgt)

          'trCC("TotalReceiptRemain") = Configuration.FormatToString(SumscAmtByCostCenter - SumStockAmtBycostCenter - SumRetentionByCostCenter, dgt)
          trCC("TotalPayment") = Configuration.FormatToString(SumPaymentByCostCenter, dgt)
          'trCC("TotalRetentionPayment") = Configuration.FormatToString(SumPayRetentionByCostCenter, dgt)
          'trCC("TotalPaymentRemain") = Configuration.FormatToString(SumStockAmtBycostCenter - SumPaymentByCostCenter - SumPayRetentionByCostCenter, dgt)
          trCC("IsBold") = True
          trCC.State = RowExpandState.Expanded
        End If
      Next

      '��������� �Ƿ����ش
      trCC = dtp.Childs.Add
      trCC("Description") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.RptSubContractManagement.SumNetWbsBudget}")  ''���������
      trCC("WBSBudget") = Configuration.FormatToString(SumNetWbsBudget, dgt)
      trCC("TotalSC") = Configuration.FormatToString(SumNetSCAmt, dgt)
      'trCC("TotalGoodsReceipt") = Configuration.FormatToString(SumNetStockAmt, dgt)

      'trCC("TotalRetention") = Configuration.FormatToString(SumNetRetentionAmt, dgt)
      'trCC("TotalReceiptRemain") = Configuration.FormatToString(SumNetscAmt - SumNetStockAmt - SumNetRetentionAmt, dgt)
      trCC("TotalPayment") = Configuration.FormatToString(SumNetPaymentAmt, dgt)
      'trCC("TotalRetentionPayment") = Configuration.FormatToString(SumNetPayRetentionAmt, dgt)
      'trCC("TotalPaymentRemain") = Configuration.FormatToString(SumNetStockAmt - SumNetPaymentAmt - SumNetPayRetentionAmt, dgt)
      trCC("IsBold") = True
      trCC("Level") = 0
      trCC.State = RowExpandState.Expanded

      Dim i As Integer = 0
      For Each row As DataRow In dtp.Rows
        i += 1
        row("linenumber") = i
      Next
      If i > 0 Then
        dtp.AcceptChanges()
      End If
    End Sub
#End Region

#Region "Methods"
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptSCManagement"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCManagement.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptSCManagement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptSCManagement"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptSCManagement.ListLabel}"
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
#End Region#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "RptSCManagement"
    End Function
    Public Overrides Function GetDefaultForm() As String
      Return "RptSCManagement"
    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        dpiColl.Add(fixDpi)
      Next

      Dim n As Integer = 0
      For rowIndex As Integer = 1 To m_grid.RowCount

        Dim fn As System.Drawing.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
        If Me.Filters(8).Value > 0 Then
          If Not m_grid(rowIndex, 17).CellValue Is DBNull.Value Then
            If CType(m_grid(rowIndex, 17).CellValue, Boolean) = True Then
              fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            End If
          End If
        End If
        Dim indent As String = ""
        If Not m_grid(rowIndex, 18).CellValue Is DBNull.Value Then
          indent = Space(CInt(m_grid(rowIndex, 18).CellValue) * 3)
          If CInt(m_grid(rowIndex, 18).CellValue) = 0 Then
            fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          End If
        End If

        dpi = New DocPrintingItem
        dpi.Mapping = "col0"
        dpi.Value = m_grid(rowIndex, 2).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col1"
        dpi.Value = indent & m_grid(rowIndex, 3).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col2"
        dpi.Value = m_grid(rowIndex, 5).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col3"
        dpi.Value = m_grid(rowIndex, 6).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col4"
        dpi.Value = m_grid(rowIndex, 8).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col5"
        dpi.Value = m_grid(rowIndex, 10).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col6"
        dpi.Value = m_grid(rowIndex, 11).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col7"
        dpi.Value = m_grid(rowIndex, 12).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col8"
        dpi.Value = m_grid(rowIndex, 13).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col9"
        dpi.Value = m_grid(rowIndex, 14).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col10"
        dpi.Value = m_grid(rowIndex, 15).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "col11"
        dpi.Value = m_grid(rowIndex, 16).CellValue
        dpi.DataType = "System.String"
        dpi.Row = n + 1
        dpi.Table = "Item"
        dpi.Font = fn
        dpiColl.Add(dpi)

        n += 1
      Next

      Return dpiColl
    End Function
#End Region
  End Class
End Namespace

