Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class RptMatWithdraw
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

#Region "Methods"
    Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
    Public Overrides Sub ListInnewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
      m_grid = grid
      m_grid.BeginUpdate()
      m_grid.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
      m_grid.Model.Options.NumberedColHeaders = False
      m_grid.Model.Options.WrapCellBehavior = Syncfusion.Windows.Forms.Grid.GridWrapCellBehavior.WrapRow
      CreateHeader()
      PopulateData()
      m_grid.EndUpdate()
    End Sub
    Private Sub CreateHeader()
      Dim indent As String = Space(3)
      m_grid.RowCount = 1
      m_grid.ColCount = 8

      m_grid.ColWidths(1) = 100
      m_grid.ColWidths(2) = 120
      m_grid.ColWidths(3) = 200
      m_grid.ColWidths(4) = 200
      m_grid.ColWidths(5) = 100
      m_grid.ColWidths(6) = 100
      m_grid.ColWidths(7) = 0
      m_grid.ColWidths(8) = 100

      m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid.Rows.HeaderCount = 1
      m_grid.Rows.FrozenCount = 1

      m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.DocDate}") '"�ѹ����͡���"
      m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.DocCode}") '"�Ţ����͡���"
      m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.FromCCname}") '"Cost Center ����ԡ"
      m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.ToCCname}") '"Cost Center ���ԡ"
      m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.SumQty}") '"�ʹ����ӹǹ"
      'm_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.SumCostUnit}") '"�ʹ����鹷ع/˹���"
      m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.SumEntityamt}") '"�ʹ����ӹǹ�Թ"

      m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.EntityCode}")  '"������ʴ�"
      m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.EntityName}")  '"������ʴ�"
      m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.EntityUnitName}")  '"˹���"
      m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.Qty}")  '"�ӹǹ"
      m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.UnitCost}")  '"����µ鹷ع/˹���"
      m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.Entityamt}")  '"�ӹǹ�Թ"

      m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      ''m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

      m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
      m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
      m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
    End Sub
    Private Sub PopulateData()
      Dim dt As DataTable = Me.DataSet.Tables(0)
      Dim currentDocCode As String = ""
      Dim currentEntityCode As String = ""
      Dim currCostCenterIndex As Integer = -1
      Dim currItemIndex As Integer = -1
      Dim indent As String = Space(3)
      Dim sumQty As Decimal
      'Dim sumCostUnit As Decimal = 0
      Dim sumEntityamt As Decimal = 0
      Dim countDoc As Decimal = 0
      Dim sumAmount As Decimal = 0
      For Each row As DataRow In dt.Rows
        If row("DocCode").ToString <> currentDocCode Then
          m_grid.RowCount += 1
          currCostCenterIndex = m_grid.RowCount
          m_grid.RowStyles(currCostCenterIndex).BackColor = Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currCostCenterIndex).Font.Bold = True
          m_grid.RowStyles(currCostCenterIndex).ReadOnly = True

          m_grid(currCostCenterIndex, 1).CellValue = CDate(row("DocDate")).ToShortDateString
          m_grid(currCostCenterIndex, 2).CellValue = row("DocCode")
          m_grid(currCostCenterIndex, 3).CellValue = row("FromCCname")
          m_grid(currCostCenterIndex, 4).CellValue = row("ToCCname")
          m_grid(currCostCenterIndex, 1).Tag = "Groupping"

          currentDocCode = row("DocCode").ToString
          currentEntityCode = ""
          sumQty = 0
          'sumCostUnit = 0
          sumEntityamt = 0
          countDoc += 1
        End If
        'If row("EntityCode").ToString <> currentEntityCode Then
        m_grid.RowCount += 1
        currItemIndex = m_grid.RowCount
        m_grid.RowStyles(currItemIndex).ReadOnly = True

        m_grid(currItemIndex, 1).CellValue = DBNull.Value
        If Not row.IsNull("EntityCode") Then
          m_grid(currItemIndex, 2).CellValue = indent & row("EntityCode").ToString
        End If
        If Not row.IsNull("EntityName") Then
          m_grid(currItemIndex, 3).CellValue = indent & row("EntityName").ToString
        End If
        m_grid(currItemIndex, 4).CellValue = DBNull.Value
        If Not row.IsNull("EntityUnitName") Then
          m_grid(currItemIndex, 5).CellValue = indent & row("EntityUnitName").ToString
        End If
        If IsNumeric(row("Qty")) Then
          m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Qty")), DigitConfig.Qty)
          sumQty += CDec(row("Qty"))
        End If
        If IsNumeric(row("AvgUnitCost")) Then
          m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("AvgUnitCost")), DigitConfig.Price)
          'sumCostUnit += CDec(row("UnitCost"))
        End If
        If IsNumeric(row("Amount")) Then
          m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("Amount")), DigitConfig.Price)
          sumEntityamt += CDec(row("Amount"))
          sumAmount += CDec(row("Amount"))
        End If
        'currentEntityCode = row("EntityCode").ToString
        'End If
        If sumQty <> 0 Then
          m_grid(currCostCenterIndex, 6).CellValue = Configuration.FormatToString(sumQty, DigitConfig.Price)
        End If
        'If sumCostUnit <> 0 Then
        '  m_grid(currCostCenterIndex, 7).CellValue = Configuration.FormatToString(sumCostUnit, DigitConfig.Price)
        'End If
        If sumEntityamt <> 0 Then
          m_grid(currCostCenterIndex, 8).CellValue = Configuration.FormatToString(sumEntityamt, DigitConfig.Price)
        End If
      Next

      m_grid.RowCount += 1
      currItemIndex = m_grid.RowCount
      m_grid.RowStyles(currItemIndex).ReadOnly = True
      m_grid(currItemIndex, 1).CellValue = DBNull.Value
      m_grid(currItemIndex, 5).CellValue = "���������"
      m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(countDoc, DigitConfig.Int) & " ��¡��"
      m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(sumAmount, DigitConfig.Price)
    End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "RptMatWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.RptMatWithdraw"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.RptMatWithdraw.ListLabel}"
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
#Region "IPrintableEntity"
    Public Overrides Function GetDefaultFormPath() As String
      Return "C:\Documents and Settings\Administrator\Desktop\Report.dfm"
    End Function
    Public Overrides Function GetDefaultForm() As String

    End Function
    Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      For Each fixDpi As DocPrintingItem In Me.FixValueCollection
        Select Case fixDpi.Mapping.ToLower
          Case "month", "year", "type"
            dpiColl.Add(fixDpi)
          Case "docdatestart", "docdateend"
            dpiColl.Add(fixDpi)
          Case "fromccstart", "fromccend"
            dpiColl.Add(fixDpi)
          Case "toccstart", "toccend"
            dpiColl.Add(fixDpi)
        End Select
      Next
      If Not Me.Filters(2).Value Is DBNull.Value Then
        'FromCCStart
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCStart"
        dpi.Value = CStr(Me.Filters(2).Value)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Filters(3).Value Is DBNull.Value Then
        'FromCCEnd
        dpi = New DocPrintingItem
        dpi.Mapping = "FromCCEnd"
        dpi.Value = CStr(Me.Filters(3).Value)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Filters(4).Value Is DBNull.Value Then
        'ToCCStart
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCStart"
        dpi.Value = CStr(Me.Filters(4).Value)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Filters(5).Value Is DBNull.Value Then
        'ToCCEnd
        dpi = New DocPrintingItem
        dpi.Mapping = "ToCCEnd"
        dpi.Value = CStr(Me.Filters(5).Value)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      Dim n As Integer = 0
      Dim countDoc As Decimal = 0
      Dim sumAmount As Decimal = 0
      For rowIndex As Integer = 2 To m_grid.RowCount - 1
        If Not m_grid(rowIndex, 1).Tag Is Nothing Then
          dpi = New DocPrintingItem
          dpi.Mapping = "col0"
          dpi.Value = m_grid(rowIndex, 1).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.DateTime"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          dpi.Value = m_grid(rowIndex, 2).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col2"
          dpi.Value = m_grid(rowIndex, 3).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col3"
          dpi.Value = m_grid(rowIndex, 4).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col5"
          dpi.Value = m_grid(rowIndex, 6).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col6"
          dpi.Value = m_grid(rowIndex, 7).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col7"
          dpi.Value = m_grid(rowIndex, 8).CellValue
          dpi.Font = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          countDoc += 1
          sumAmount += CDec(m_grid(rowIndex, 8).CellValue)
        Else
          dpi = New DocPrintingItem
          dpi.Mapping = "col1"
          dpi.Value = m_grid(rowIndex, 2).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col2"
          dpi.Value = m_grid(rowIndex, 3).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col4"
          dpi.Value = m_grid(rowIndex, 5).CellValue
          dpi.DataType = "System.String"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col5"
          dpi.Value = m_grid(rowIndex, 6).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col6"
          dpi.Value = m_grid(rowIndex, 7).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "col7"
          dpi.Value = m_grid(rowIndex, 8).CellValue
          dpi.DataType = "System.Decimal"
          dpi.Row = n + 1
          dpi.Table = "Item"
          dpiColl.Add(dpi)

        End If
        n += 1
      Next

      'SumCol5
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol5"
      dpi.Value = Configuration.FormatToString(countDoc, DigitConfig.Int)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      'SumCol7
      dpi = New DocPrintingItem
      dpi.Mapping = "SumCol7"
      dpi.Value = Configuration.FormatToString(sumAmount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpi.PrintingFrequency = DocPrintingItem.Frequency.LastPage
      dpiColl.Add(dpi)

      Return dpiColl
    End Function
#End Region

  End Class
End Namespace

