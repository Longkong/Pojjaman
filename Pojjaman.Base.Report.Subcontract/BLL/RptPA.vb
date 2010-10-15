
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
    Public Class RptPA
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
        Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
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
            m_grid.RowCount = 1
            m_grid.ColCount = 10

            m_grid.ColWidths(1) = 100
            m_grid.ColWidths(2) = 100
            m_grid.ColWidths(3) = 100
            m_grid.ColWidths(4) = 200
            m_grid.ColWidths(5) = 200
            m_grid.ColWidths(6) = 120
            m_grid.ColWidths(7) = 120
            m_grid.ColWidths(8) = 120
            m_grid.ColWidths(9) = 150
            m_grid.ColWidths(10) = 100

            m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            Dim indent As String = Space(3)
            m_grid.Rows.HeaderCount = 1
            m_grid.Rows.FrozenCount = 1

            m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.DocNumber}")      '"�Ţ����͡���"
            m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.DocDate}")       '"�ѹ����͡���"
            m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.scDocCode}")    '"�Ţ������觨�ҧ"    
            m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.subcontractor}")    '"����Ѻ����"    
            m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.CC}")          '"Cost Center"
            m_grid(0, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.beforetax}")       '"�ʹ�Թ����������"
            m_grid(0, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.taxamt}")      '"��Ť������"
            m_grid(0, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.aftertax}")             '"�ʹ�Թ�ط��"
            m_grid(0, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.note}")    '"�����˵�"
            m_grid(0, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.refstatus}")    '"ʶҹТͧ�͡���"

            m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.DocTYpe}")      '"�Ţ����͡���"
            m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.PAitemName}")       '"�ѹ����͡���"
            m_grid(1, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.Qty}")    '"�Ţ������觨�ҧ"    
            m_grid(1, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.UnitName}")    '"����Ѻ����"    
            m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.UnitPrice}")          '"Cost Center"
            m_grid(1, 6).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.amt}")          '"Cost Center"

            m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(0, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(0, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

            m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
            m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

        End Sub
        Private Sub PopulateData()
            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim dt1 As DataTable = Me.DataSet.Tables(1)

            Dim currTrIndex As Integer = -1
            Dim currItemIndex As Integer = -1
            Dim currPAItem As Integer = -1
            Dim currPA As Integer = 0
            Dim indent As String = Space(3)

            Dim SumBeforeTax As Decimal = 0
            Dim SumTaxAmt As Decimal = 0
            Dim SumAfterTax As Decimal = 0


            Dim n As Int32 = 0

            For Each row As DataRow In dt.Rows
                m_grid.RowCount += 1
                currItemIndex = m_grid.RowCount
                m_grid.RowStyles(currItemIndex).BackColor = Color.FromArgb(128, 255, 128)
                m_grid.RowStyles(currItemIndex).ReadOnly = True
                If Not row.IsNull("Code") Then
                    m_grid(currItemIndex, 1).CellValue = row("Code")
                End If
                If Not row.IsNull("DocDate") Then
                    m_grid(currItemIndex, 2).CellValue = CDate(row("DocDate")).ToShortDateString
                End If
                If Not row.IsNull("SC") Then
                    m_grid(currItemIndex, 3).CellValue = row("SC").ToString
                End If

                If Not row.IsNull("subcontractor") Then
                    m_grid(currItemIndex, 4).CellValue = row("subcontractor").ToString
                End If

                If Not row.IsNull("CC") Then
                    m_grid(currItemIndex, 5).CellValue = row("CC").ToString
                End If
                If Not row.IsNull("beforetax") Then
                    m_grid(currItemIndex, 6).CellValue = Configuration.FormatToString(CDec(row("beforetax")), DigitConfig.Price)
                    SumBeforeTax += CDec(row("beforetax"))
                End If
                If Not row.IsNull("taxamt") Then
                    m_grid(currItemIndex, 7).CellValue = Configuration.FormatToString(CDec(row("taxamt")), DigitConfig.Price)
                    SumTaxAmt += CDec(row("taxamt"))
                End If
                If Not row.IsNull("aftertax") Then
                    m_grid(currItemIndex, 8).CellValue = Configuration.FormatToString(CDec(row("aftertax")), DigitConfig.Price)
                    SumAfterTax += CDec(row("aftertax"))
                End If
                If Not row.IsNull("note") Then
                    m_grid(currItemIndex, 9).CellValue = row("note").ToString
                End If

                If Not row.IsNull("refstatus") Then
                    m_grid(currItemIndex, 10).CellValue = row("refstatus").ToString
                End If
                currPA = row("pa_id").ToString

                For Each pairow As DataRow In dt1.Rows
                    If currPA = pairow("pai_pa").ToString Then
                        If Not pairow.IsNull("pai_pa") Then
                            m_grid.RowCount += 1
                            currPAItem = m_grid.RowCount
                            m_grid.RowStyles(currPAItem).ReadOnly = True
                            If Not pairow.IsNull("code_description") Then
                                m_grid(currPAItem, 1).CellValue = indent & pairow("code_description").ToString
                            End If
                            If Not pairow.IsNull("pai_itemName") Then
                                m_grid(currPAItem, 2).CellValue = indent & pairow("pai_itemName").ToString
                            End If
                            If Not pairow.IsNull("pai_qty") Then
                                m_grid(currPAItem, 3).CellValue = indent & Configuration.FormatToString(CDec(pairow("pai_qty")), DigitConfig.Price)
                            End If
                            If Not pairow.IsNull("unit_name") Then
                                m_grid(currPAItem, 4).CellValue = indent & pairow("unit_name").ToString
                            End If
                            If Not pairow.IsNull("pai_unitprice") Then
                                m_grid(currPAItem, 5).CellValue = indent & Configuration.FormatToString(CDec(pairow("pai_unitprice")), DigitConfig.Price)
                            End If
                            If Not pairow.IsNull("pai_amt") Then
                                m_grid(currPAItem, 6).CellValue = indent & Configuration.FormatToString(CDec(pairow("pai_amt")), DigitConfig.Price)
                            End If
                        End If
                    End If
                Next

            Next
            m_grid.RowCount += 1
            currTrIndex = m_grid.RowCount
            m_grid.RowStyles(currTrIndex).BackColor = Color.FromArgb(255, 255, 128)
            m_grid.RowStyles(currTrIndex).Font.Bold = True
            m_grid.RowStyles(currTrIndex).ReadOnly = True
            m_grid(currTrIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptPA.SumAll}") '���
            m_grid(currTrIndex, 6).CellValue = Configuration.FormatToString(SumBeforeTax, DigitConfig.Price) '�ʹ�Թ
            m_grid(currTrIndex, 7).CellValue = Configuration.FormatToString(SumTaxAmt, DigitConfig.Price) '�ʹ����
            m_grid(currTrIndex, 8).CellValue = Configuration.FormatToString(SumAfterTax, DigitConfig.Price) '�ʹ������� 

        End Sub
#End Region#Region "Shared"
#End Region#Region "Properties"        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptPA"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPA.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptPA"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptPA"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptPA.ListLabel}"
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
            Return "RptPA"
        End Function
        Public Overrides Function GetDefaultForm() As String
            Return "RptPA"
        End Function
        Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
            Dim dpiColl As New DocPrintingItemCollection
            Dim dpi As DocPrintingItem

            For Each fixDpi As DocPrintingItem In Me.FixValueCollection
                dpiColl.Add(fixDpi)
            Next

            Dim LineNumber As Integer = 0

            Dim n As Integer = 0
            Dim i As Integer = 0
            For rowIndex As Integer = 1 To m_grid.RowCount
                i += 1
                dpi = New DocPrintingItem
                dpi.Mapping = "Item.LineNumber"
                dpi.Value = i
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                dpi = New DocPrintingItem
                dpi.Mapping = "col0"
                dpi.Value = m_grid(rowIndex, 1).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

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
                dpi.Mapping = "col3"
                dpi.Value = m_grid(rowIndex, 4).CellValue
                dpi.DataType = "System.String"
                dpi.Row = n + 1
                dpi.Table = "Item"
                dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col4"
                'dpi.Value = m_grid(rowIndex, 5).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col5"
                'dpi.Value = m_grid(rowIndex, 6).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col6"
                'dpi.Value = m_grid(rowIndex, 7).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col7"
                'dpi.Value = m_grid(rowIndex, 8).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col8"
                'dpi.Value = m_grid(rowIndex, 9).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col9"
                'dpi.Value = m_grid(rowIndex, 10).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col10"
                'dpi.Value = m_grid(rowIndex, 11).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col11"
                'dpi.Value = m_grid(rowIndex, 12).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col12"
                'dpi.Value = m_grid(rowIndex, 13).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col13"
                'dpi.Value = m_grid(rowIndex, 14).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col14"
                'dpi.Value = m_grid(rowIndex, 15).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)

                'dpi = New DocPrintingItem
                'dpi.Mapping = "col15"
                'dpi.Value = m_grid(rowIndex, 16).CellValue
                'dpi.DataType = "System.String"
                'dpi.Row = n + 1
                'dpi.Table = "Item"
                'dpiColl.Add(dpi)


                n += 1
            Next

            Return dpiColl
        End Function
#End Region
    End Class
End Namespace
