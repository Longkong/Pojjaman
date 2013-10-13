Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.TextHelper
Imports Longkong.Pojjaman.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class RptARRemain
        Inherits Report
        Implements INewReport

#Region "Members"
        Private m_reportColumns As ReportColumnCollection
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

#Region "Methods"
        Private m_grid As Syncfusion.Windows.Forms.Grid.GridControl
        Public Overrides Sub ListInNewGrid(ByVal grid As Syncfusion.Windows.Forms.Grid.GridControl)
            m_grid = grid
            RemoveHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            AddHandler m_grid.CellDoubleClick, AddressOf CellDblClick
            Dim lkg As Longkong.Pojjaman.Gui.Components.LKGrid = CType(m_grid, Longkong.Pojjaman.Gui.Components.LKGrid)
            lkg.DefaultBehavior = False
            lkg.HilightWhenMinus = True
            lkg.Init()
            lkg.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.SystemTheme
            Dim tm As New TreeManager(GetSimpleSchemaTable, New TreeGrid)
            ListInGrid(tm)
            lkg.TreeTableStyle = CreateSimpleTableStyle()
            lkg.TreeTable = tm.Treetable
            If Me.Filters(7).Value = 0 Then
                lkg.Rows.HeaderCount = 1
                lkg.Rows.FrozenCount = 1
            Else
                lkg.Rows.HeaderCount = 2
                lkg.Rows.FrozenCount = 2
            End If

            lkg.Refresh()
        End Sub
        Private Sub CellDblClick(ByVal sender As Object, ByVal e As Syncfusion.Windows.Forms.Grid.GridCellClickEventArgs)
            Dim tr As Object = m_hashData(e.RowIndex)
            If tr Is Nothing Then
                Return
            End If

            If TypeOf tr Is ARDocument Then
                Dim doc As ARDocument = CType(tr, ARDocument)
                If doc Is Nothing Then
                    Return
                End If

                Dim docId As Integer = doc.DocId
                Dim docType As Integer = doc.DocType

                'Debug.Print(docId.ToString)
                'Debug.Print(docType.ToString)

                If docId > 0 AndAlso docType > 0 Then
                    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
                    Dim en As SimpleBusinessEntityBase = SimpleBusinessEntityBase.GetEntity(Entity.GetFullClassName(docType), docId)
                    myEntityPanelService.OpenDetailPanel(en)
                End If
            End If
        End Sub
        Public Overrides Sub ListInGrid(ByVal tm As TreeManager)
            Me.m_treemanager = tm
            Me.m_treemanager.Treetable.Clear()
            CreateHeader()
            PopulateData()
        End Sub
        Private Sub CreateHeader()
            If Me.m_treemanager Is Nothing Then
                Return
            End If

            Dim indent As String = Space(3)

            Dim tr As TreeRow = Me.m_treemanager.Treetable.Childs.Add
            If CInt(Me.Filters(7).Value) = 0 Then
                ' Level 1.
                tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerCode}") '"�����١˹��"
                tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerName}") '"�����١˹��"
                tr("col4") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpenningBalance}") '"�ʹ¡��"
                tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Debt}") '"�ʹ��������"
                tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.SCN}") '"�ʹŴ˹��"
                tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Receive}") '"�ʹ�Ѻ����"
                tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalance}") '"�ʹ¡�"

                tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpeningBalanceRetention}") '"�ʹ Retention ¡��"
                tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Retention}") '"�ʹ Retention"
                tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.ReceiveRetention}") '"�ʹ�Ѻ���� Retention"
                tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalanceRetention}") '"�ʹ Retention ¡�"
                tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.BillRetention}") '"�ҧ��� RetentionŴ"   ${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DecreaseRetention}

                'tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"�����˵�"

            Else
                ' Level 1.
                tr("col0") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerCode}") '"�����١˹��"
                tr("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.CustomerName}") '"�����١˹��"

                tr("col5") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpenningBalance}") '"�ʹ¡��"
                tr("col6") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Debt}") '"�ʹ��������"
                tr("col7") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.SCN}") '"�ʹŴ˹��"
                tr("col8") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Receive}") '"�ʹ�Ѻ����"
                tr("col9") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalance}") '"�ʹ¡�"

                tr("col10") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.OpeningBalanceRetention}") '"�ʹ Retention ¡��"
                tr("col11") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Retention}") '"�ʹ Retention"
                tr("col12") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.ReceiveRetention}") '"�ʹ�Ѻ���� Retention"
                tr("col13") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.EndingBalanceRetention}") '"�ʹ Retention ¡�"
                tr("col14") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.BillRetention}") '"�ҧ��� RetentionŴ"   ${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DecreaseRetention}


                ' Level 2.
                tr = Me.m_treemanager.Treetable.Childs.Add
                tr("col0") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DocType}") '"�������͡���"
                tr("col1") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAPRemain.DNDocNo}") '"�Ţ����͡���"
                tr("col2") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DocDate}") '"�ѹ����͡���"
                tr("col3") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.PrCode}") '"�Ţ�����Ӥѭ"
                tr("col4") = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.CostCenter}") '"�Ţ�����Ӥѭ"
                tr("col15") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.GLNote}") '"�����˵�"
                tr("col16") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.Global.VatCode}") '"㺡ӡѺ����"

            End If
        End Sub
        Private Sub PopulateData_OLD()

            Dim ShowDetail As Boolean = False
            Dim ShowAll As Boolean = False
            Dim ShowAR As Boolean = False
            Dim ShowRetention As Boolean = False

            ShowDetail = CBool(Me.Filters(7).Value)
            ShowAll = CBool(Me.Filters(8).Value)
            ShowAR = CBool(Me.Filters(15).Value)
            ShowRetention = CBool(Me.Filters(16).Value)

            Dim dt As DataTable = Me.DataSet.Tables(0)
            Dim dt2 As DataTable

            If ShowDetail Then
                dt2 = Me.DataSet.Tables(1)
                CalRetentionBalance()
            End If

            If dt.Rows.Count = 0 Then
                Return
            End If


            Dim indent As String = Space(3)

            Dim trCustomer As TreeRow
            Dim trDetail As TreeRow

            Dim sumOpenningBalance As Decimal = 0
            Dim sumAmount As Decimal = 0
            Dim sumSCNAmount As Decimal = 0
            Dim sumReceiveAmount As Decimal = 0
            Dim sumEndingBalance As Decimal = 0
            Dim sumOPBRetention As Decimal = 0
            Dim sumRetention As Decimal = 0
            Dim sumDecreaseRetention As Decimal = 0
            Dim sumEndingBalanceRetention As Decimal = 0
            Dim sumReceiveRetention As Decimal = 0
            Dim sumBillRetention As Decimal = 0

            Dim totalOpenningBalance As Decimal = 0
            Dim totalAmount As Decimal = 0
            Dim totalSCNAmount As Decimal = 0
            Dim totalReceiveAmount As Decimal = 0
            Dim totalEndingBalance As Decimal = 0
            Dim totalOPBRetention As Decimal = 0
            Dim totalRetention As Decimal = 0
            Dim totalDecreaseRetention As Decimal = 0
            Dim totalEndingBalanceRetention As Decimal = 0
            Dim totalReceiveRetention As Decimal = 0
            Dim totalBillRetention As Decimal = 0

            Dim DocKey As String = ""
            Dim DocBal As DocumentBalance
            Dim HasARMove As Boolean = False
            Dim HasRetentionMove As Boolean = False
            Dim DocEndBalance As Decimal = 0
            Dim DocOpenRetentionBalance As Decimal = 0
            Dim DocEndRetentionBalance As Decimal = 0

            Dim rowIndex As Integer = 0
            m_hashData = New Hashtable

            Dim HasCustMove As Boolean = False

            For Each CustomerRow As DataRow In dt.Rows



                If ShowDetail Then
                    If CustomerBalanceList.ContainsKey(CustomerRow("Cust_ID").ToString) Then
                        HasCustMove = CustomerBalanceList(CustomerRow("Cust_ID").ToString).HasARMove Or CustomerBalanceList(CustomerRow("Cust_ID").ToString).HasRetentionMove
                    Else
                        HasCustMove = False
                    End If
                End If

                If (ShowDetail AndAlso HasCustMove) OrElse Not (ShowDetail) Then

                    trCustomer = Me.Treemanager.Treetable.Childs.Add

                    If ShowDetail Then
                        trCustomer.Tag = "Font.Bold"
                    End If

                    If Not CustomerRow.IsNull("cust_code") Then
                        trCustomer("col0") = CustomerRow("cust_code").ToString
                    End If
                    If Not CustomerRow.IsNull("cust_name") Then
                        trCustomer("col1") = CustomerRow("cust_name").ToString
                    End If

                    If Not ShowDetail Then
                        If Not CustomerRow.IsNull("OpeningBalance") Then
                            trCustomer("col4") = Configuration.FormatToString(CDec(CustomerRow("OpeningBalance")), DigitConfig.Price)
                            totalOpenningBalance += CDec(CustomerRow("OpeningBalance"))
                        End If
                        If Not CustomerRow.IsNull("Amount") Then
                            If CDec(CustomerRow("Amount")) > 0 Then
                                trCustomer("col5") = Configuration.FormatToString(CDec(CustomerRow("Amount")), DigitConfig.Price)
                                totalAmount += CDec(CustomerRow("Amount"))
                            End If
                        End If
                        If Not CustomerRow.IsNull("SCN") Then
                            If CDec(CustomerRow("SCN")) > 0 Then
                                trCustomer("col6") = Configuration.FormatToString(CDec(CustomerRow("SCN")), DigitConfig.Price)
                                totalSCNAmount += CDec(CustomerRow("SCN"))
                            End If
                        End If
                        If Not CustomerRow.IsNull("ReceiveSelection") Then
                            If CDec(CustomerRow("ReceiveSelection")) > 0 Then
                                trCustomer("col7") = Configuration.FormatToString(CDec(CustomerRow("ReceiveSelection")), DigitConfig.Price)
                                totalReceiveAmount += CDec(CustomerRow("ReceiveSelection"))
                            End If
                        End If
                        If Not CustomerRow.IsNull("EndingBalance") Then
                            trCustomer("col8") = Configuration.FormatToString(CDec(CustomerRow("EndingBalance")), DigitConfig.Price)
                            totalEndingBalance += CDec(CustomerRow("EndingBalance"))
                        End If

                        '============================================-Retention===================================================

                        If Not CustomerRow.IsNull("OPBRetention") Then
                            trCustomer("col9") = Configuration.FormatToString(CDec(CustomerRow("OPBRetention")), DigitConfig.Price)
                            totalOPBRetention += CDec(CustomerRow("OPBRetention"))
                        End If

                        If Not CustomerRow.IsNull("Retention") Then
                            trCustomer("col10") = Configuration.FormatToString(CDec(CustomerRow("Retention")), DigitConfig.Price)
                            totalRetention += CDec(CustomerRow("Retention"))
                        End If

                        If Not CustomerRow.IsNull("DecreaseRetention") Then
                            trCustomer("col11") = Configuration.FormatToString(CDec(CustomerRow("DecreaseRetention")), DigitConfig.Price)
                            totalDecreaseRetention += CDec(CustomerRow("DecreaseRetention"))
                        End If

                        If Not CustomerRow.IsNull("EndingBalanceRetention") Then
                            trCustomer("col12") = Configuration.FormatToString(CDec(CustomerRow("EndingBalanceRetention")), DigitConfig.Price)
                            totalEndingBalanceRetention += CDec(CustomerRow("EndingBalanceRetention"))
                        End If

                        If Not CustomerRow.IsNull("BillRetention") Then
                            trCustomer("col13") = Configuration.FormatToString(CDec(CustomerRow("BillRetention")), DigitConfig.Price)
                            totalBillRetention += CDec(CustomerRow("BillRetention"))
                        End If

                        '=========================================================================================================


                    End If

                    If ShowDetail Then

                        trCustomer.State = RowExpandState.Expanded

                        sumOpenningBalance = 0
                        sumAmount = 0
                        sumSCNAmount = 0
                        sumReceiveAmount = 0
                        sumEndingBalance = 0
                        sumOPBRetention = 0
                        sumRetention = 0
                        sumDecreaseRetention = 0
                        sumEndingBalanceRetention = 0
                        sumReceiveRetention = 0
                        sumBillRetention = 0

                        For Each detailRow As DataRow In dt2.Select("Customer = " & CustomerRow("Cust_ID").ToString)
                            Dim deh As New DataRowHelper(detailRow)

                            DocKey = deh.GetValue(Of String)("ID", "-") & "|" & deh.GetValue(Of String)("DocType", "-") & "|" & deh.GetValue(Of String)("CCID", "-") & "|" & deh.GetValue(Of String)("Customer", "-")
                            DocBal = Nothing
                            If DocumentBalanceList.ContainsKey(DocKey) Then
                                DocBal = DocumentBalanceList(DocKey)
                                DocEndBalance = DocBal.EndingBalance
                                DocOpenRetentionBalance = DocBal.OBalanceRetention
                                DocEndRetentionBalance = DocBal.BalanceRetention
                                HasARMove = DocBal.HasARMove
                                HasRetentionMove = DocBal.HasRetentionMove
                            Else
                                DocEndBalance = 0
                                DocOpenRetentionBalance = 0
                                DocEndRetentionBalance = 0
                                HasARMove = False
                                HasRetentionMove = False
                            End If

                            If _
                                (((ShowAll) And (ShowAR) And (ShowRetention)) And ((HasARMove) Or (HasRetentionMove))) _
                                OrElse
                                (((ShowAll) And (ShowAR) And Not (ShowRetention)) And ((DocEndBalance <> 0) Or (HasRetentionMove))) _
                                OrElse
                                (((ShowAll) And Not (ShowAR) And (ShowRetention)) And ((HasARMove) Or (DocEndRetentionBalance <> 0))) _
                                OrElse
                                ((Not (ShowAll) And (ShowAR) And Not (ShowRetention)) And (DocEndBalance <> 0)) _
                                OrElse
                                ((Not (ShowAll) And Not (ShowAR) And (ShowRetention)) And (DocEndRetentionBalance <> 0)) _
                                OrElse
                                ((Not (ShowAll) And (ShowAR) And (ShowRetention)) And ((DocEndBalance <> 0) Or (DocEndRetentionBalance <> 0))) _
                            Then

                                If Not trCustomer Is Nothing Then
                                    trDetail = trCustomer.Childs.Add

                                    rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trDetail) + 1
                                    m_hashData(rowIndex) = detailRow

                                    trDetail("col0") = indent & deh.GetValue(Of String)("entity_description", "-")
                                    trDetail("col1") = indent & deh.GetValue(Of String)("doccode", "-")
                                    trDetail("col2") = indent & deh.GetValue(Of Date)("docdate", Now.Date).ToShortDateString
                                    trDetail("col3") = indent & deh.GetValue(Of String)("glcode", "-")
                                    trDetail("col4") = indent & deh.GetValue(Of String)("CostCenter")
                                    trDetail("col5") = Configuration.FormatToString(deh.GetValue(Of Decimal)("OpeningBalance"), DigitConfig.Price)

                                    If DocBal.OpeningBalance <> 0 Then
                                        sumOpenningBalance += DocBal.OpeningBalance
                                        totalOpenningBalance += DocBal.OpeningBalance
                                    End If

                                    If DocBal.Amount <> 0 Then
                                        trDetail("col6") = Configuration.FormatToString(DocBal.Amount, DigitConfig.Price)
                                        sumAmount += DocBal.Amount
                                        totalAmount += DocBal.Amount
                                    End If

                                    If DocBal.SCN <> 0 Then
                                        trDetail("col7") = Configuration.FormatToString(DocBal.SCN, DigitConfig.Price)
                                        sumSCNAmount += DocBal.SCN
                                        totalSCNAmount += DocBal.SCN
                                    End If

                                    If DocBal.ReceiveSelection <> 0 Then
                                        trDetail("col8") = Configuration.FormatToString(DocBal.ReceiveSelection, DigitConfig.Price)
                                        sumReceiveAmount += DocBal.ReceiveSelection
                                        totalReceiveAmount += DocBal.ReceiveSelection
                                    End If

                                    If DocBal.EndingBalance <> 0 Then
                                        trDetail("col9") = Configuration.FormatToString(DocBal.EndingBalance, DigitConfig.Price)
                                        sumEndingBalance += DocBal.EndingBalance
                                        totalEndingBalance += DocBal.EndingBalance
                                    End If

                                    '============================================-Retention===================================================


                                    trDetail("col10") = Configuration.FormatToString(DocBal.OBalanceRetention, DigitConfig.Price)
                                    sumOPBRetention += DocBal.OBalanceRetention
                                    totalOPBRetention += DocBal.OBalanceRetention

                                    trDetail("col11") = Configuration.FormatToString(DocBal.Retention, DigitConfig.Price)
                                    sumRetention += DocBal.Retention
                                    totalRetention += DocBal.Retention

                                    trDetail("col12") = Configuration.FormatToString(DocBal.DecreaseRetention, DigitConfig.Price)
                                    sumDecreaseRetention += DocBal.DecreaseRetention
                                    totalDecreaseRetention += DocBal.DecreaseRetention

                                    trDetail("col13") = Configuration.FormatToString(DocBal.BalanceRetention, DigitConfig.Price)
                                    sumEndingBalanceRetention += DocBal.BalanceRetention
                                    totalEndingBalanceRetention += DocBal.BalanceRetention

                                    trDetail("col14") = Configuration.FormatToString(DocBal.BillRetention, DigitConfig.Price)
                                    sumBillRetention += DocBal.BillRetention
                                    totalBillRetention += DocBal.BillRetention

                                    '=========================================================================================================

                                    trDetail("col15") = detailRow("Glnote").ToString

                                    trDetail("col16") = detailRow("vatcode").ToString

                                End If

                            End If


                        Next

                        If sumOpenningBalance <> 0 Then
                            trCustomer("col5") = Configuration.FormatToString(sumOpenningBalance, DigitConfig.Price)
                        End If

                        If sumAmount <> 0 Then
                            trCustomer("col6") = Configuration.FormatToString(sumAmount, DigitConfig.Price)
                        End If

                        If sumSCNAmount <> 0 Then
                            trCustomer("col7") = Configuration.FormatToString(sumSCNAmount, DigitConfig.Price)
                        End If

                        If sumReceiveAmount <> 0 Then
                            trCustomer("col8") = Configuration.FormatToString(sumReceiveAmount, DigitConfig.Price)
                        End If

                        trCustomer("col9") = Configuration.FormatToString(sumEndingBalance, DigitConfig.Price)

                        '=============================================Retention===================================================

                        trCustomer("col10") = Configuration.FormatToString(sumOPBRetention, DigitConfig.Price)

                        trCustomer("col11") = Configuration.FormatToString(sumRetention, DigitConfig.Price)

                        trCustomer("col12") = Configuration.FormatToString(sumDecreaseRetention, DigitConfig.Price)

                        trCustomer("col13") = Configuration.FormatToString(sumEndingBalanceRetention, DigitConfig.Price)

                        trCustomer("col14") = Configuration.FormatToString(sumBillRetention, DigitConfig.Price)

                        '=========================================================================================================


                    End If

                End If

            Next

            trCustomer = Me.Treemanager.Treetable.Childs.Add

            If Not ShowDetail Then

                trCustomer("col4") = Configuration.FormatToString(totalOpenningBalance, DigitConfig.Price)

                If totalAmount <> 0 Then
                    trCustomer("col5") = Configuration.FormatToString(totalAmount, DigitConfig.Price)
                End If

                If totalSCNAmount <> 0 Then
                    trCustomer("col6") = Configuration.FormatToString(totalSCNAmount, DigitConfig.Price)
                End If

                If totalReceiveAmount <> 0 Then
                    trCustomer("col7") = Configuration.FormatToString(totalReceiveAmount, DigitConfig.Price)
                End If

                trCustomer("col8") = Configuration.FormatToString(totalEndingBalance, DigitConfig.Price)


                '============================================-Retention===================================================

                If totalOPBRetention <> 0 Then
                    trCustomer("col9") = Configuration.FormatToString(totalOPBRetention, DigitConfig.Price)
                End If

                If totalRetention <> 0 Then
                    trCustomer("col10") = Configuration.FormatToString(totalRetention, DigitConfig.Price)
                End If

                If totalDecreaseRetention <> 0 Then
                    trCustomer("col11") = Configuration.FormatToString(totalDecreaseRetention, DigitConfig.Price)
                End If

                trCustomer("col12") = Configuration.FormatToString(totalEndingBalanceRetention, DigitConfig.Price)

                If totalBillRetention <> 0 Then
                    trCustomer("col13") = Configuration.FormatToString(totalBillRetention, DigitConfig.Price)
                End If

                '=========================================================================================================


            Else


                trCustomer.Tag = "Font.Bold"

                trCustomer("col1") = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.Total}")  '���

                trCustomer("col5") = Configuration.FormatToString(totalOpenningBalance, DigitConfig.Price)

                If totalAmount <> 0 Then
                    trCustomer("col6") = Configuration.FormatToString(totalAmount, DigitConfig.Price)
                End If

                If totalSCNAmount <> 0 Then
                    trCustomer("col7") = Configuration.FormatToString(totalSCNAmount, DigitConfig.Price)
                End If

                If totalReceiveAmount <> 0 Then
                    trCustomer("col8") = Configuration.FormatToString(totalReceiveAmount, DigitConfig.Price)
                End If

                trCustomer("col9") = Configuration.FormatToString(totalEndingBalance, DigitConfig.Price)


                '============================================-Retention===================================================

                If totalOPBRetention <> 0 Then
                    trCustomer("col10") = Configuration.FormatToString(totalOPBRetention, DigitConfig.Price)
                End If

                If totalRetention <> 0 Then
                    trCustomer("col11") = Configuration.FormatToString(totalRetention, DigitConfig.Price)
                End If

                If totalDecreaseRetention <> 0 Then
                    trCustomer("col12") = Configuration.FormatToString(totalDecreaseRetention, DigitConfig.Price)
                End If

                trCustomer("col13") = Configuration.FormatToString(totalEndingBalanceRetention, DigitConfig.Price)

                If totalBillRetention <> 0 Then
                    trCustomer("col14") = Configuration.FormatToString(totalBillRetention, DigitConfig.Price)
                End If

                '=========================================================================================================


            End If

        End Sub
        Private Function SearchTag(ByVal id As Integer) As TreeRow
            If Me.m_treemanager Is Nothing Then
                Return Nothing
            End If
            Dim dt As TreeTable = m_treemanager.Treetable
            For Each row As TreeRow In dt.Rows
                If IsNumeric(row.Tag) AndAlso CInt(row.Tag) = id Then
                    Return row
                End If
            Next
        End Function
        Public Overrides Function GetSimpleSchemaTable() As TreeTable
            Dim myDatatable As New TreeTable("Report")
            myDatatable.Columns.Add(New DataColumn("col0", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col1", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col2", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col3", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col4", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col5", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col6", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col7", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col8", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col9", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col10", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col11", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col12", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col13", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col14", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col15", GetType(String)))
            myDatatable.Columns.Add(New DataColumn("col16", GetType(String)))

            Return myDatatable
        End Function
        Public Overrides Function CreateSimpleTableStyle() As DataGridTableStyle
            Dim dst As New DataGridTableStyle
            dst.MappingName = "Report"
            Dim widths As New ArrayList
            Dim iCol As Integer = 16 'IIf(Me.ShowDetailInGrid = 0, 6, 7)

            widths.Add(90)
            widths.Add(180)
            widths.Add(80 * CInt(Me.Filters(7).Value))
            widths.Add(95 * CInt(Me.Filters(7).Value))
            widths.Add(150)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(95)
            widths.Add(105 * CInt(Me.Filters(7).Value))
            widths.Add(180 * CInt(Me.Filters(7).Value))
            widths.Add(180 * CInt(Me.Filters(7).Value))

            For i As Integer = 0 To iCol
                If i = 1 Then
                    If CInt(Me.Filters(7).Value) <> 0 Then
                        Dim cs As New PlusMinusTreeTextColumn
                        cs.MappingName = "col" & i
                        cs.HeaderText = ""
                        cs.Width = CInt(widths(i))
                        cs.NullText = ""
                        cs.Alignment = HorizontalAlignment.Left
                        cs.ReadOnly = True
                        cs.Format = "s"
                        AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
                        dst.GridColumnStyles.Add(cs)
                    Else
                        Dim cs As New TreeTextColumn(1, True, Color.White)
                        cs.MappingName = "col" & i
                        cs.HeaderText = ""
                        cs.Width = CInt(widths(i))
                        cs.NullText = ""
                        cs.Alignment = HorizontalAlignment.Left
                        cs.ReadOnly = True
                        cs.Format = "s"
                        AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
                        dst.GridColumnStyles.Add(cs)
                    End If
                Else
                    Dim cs As New TreeTextColumn(i, True, Color.Khaki)
                    cs.MappingName = "col" & i
                    cs.HeaderText = ""
                    cs.Width = CInt(widths(i))
                    cs.NullText = ""
                    cs.Alignment = HorizontalAlignment.Left
                    If CInt(Me.Filters(7).Value) <> 0 Then
                        Select Case i
                            Case 0, 1, 2, 3, 4, 15, 16
                                cs.Alignment = HorizontalAlignment.Left
                                cs.DataAlignment = HorizontalAlignment.Left
                                cs.Format = "s"
                            Case Else
                                cs.Alignment = HorizontalAlignment.Right
                                cs.DataAlignment = HorizontalAlignment.Right
                                cs.Format = "d"
                        End Select
                    Else
                        Select Case i
                            Case 0, 1
                                cs.Alignment = HorizontalAlignment.Left
                                cs.DataAlignment = HorizontalAlignment.Left
                                cs.Format = "s"
                            Case Else
                                cs.Alignment = HorizontalAlignment.Right
                                cs.DataAlignment = HorizontalAlignment.Right
                                cs.Format = "d"
                        End Select
                    End If

                    cs.ReadOnly = True

                    AddHandler cs.CheckCellHilighted, AddressOf Me.SetHilightValues
                    dst.GridColumnStyles.Add(cs)
                End If
            Next

            Return dst
        End Function
        Public Overrides Sub SetHilightValues(ByVal sender As Object, ByVal e As DataGridHilightEventArgs)
            e.HilightValue = False
            If e.Row <= 1 Then
                e.HilightValue = True
            End If
        End Sub

        Private RetentionPMAList As Dictionary(Of String, RetentionPMA)
        Private RetentionBalanceList As Dictionary(Of String, RetentionBalance)
        Private DocumentBalanceList As Dictionary(Of String, DocumentBalance)
        Private CustomerBalanceList As Dictionary(Of String, CustomerBalance)

        Private Sub CalRetentionBalance()

            Dim ShowDetail As Boolean = False
            Dim ShowAll As Boolean = False
            Dim ShowAR As Boolean = False
            Dim ShowRetention As Boolean = False

            ShowDetail = CBool(Me.Filters(7).Value)
            ShowAll = CBool(Me.Filters(8).Value)
            ShowAR = CBool(Me.Filters(15).Value)
            ShowRetention = CBool(Me.Filters(16).Value)

            Dim RPMA As RetentionPMA
            Dim RBalance As RetentionBalance
            Dim DocBalance As DocumentBalance
            Dim CustBalance As CustomerBalance
            Dim dt As DataTable

            RetentionPMAList = New Dictionary(Of String, RetentionPMA)
            RetentionBalanceList = New Dictionary(Of String, RetentionBalance)
            DocumentBalanceList = New Dictionary(Of String, DocumentBalance)
            CustomerBalanceList = New Dictionary(Of String, CustomerBalance)

            dt = Me.DataSet.Tables(2)

            For Each PMARow As DataRow In dt.Rows
                RPMA = New RetentionPMA(PMARow)
                RetentionPMAList.Add(RPMA.pma.ToString & "|" & RPMA.CCID.ToString & "|" & RPMA.CustID.ToString, RPMA)
            Next

            dt = Me.DataSet.Tables(3)

            For Each DocRow As DataRow In dt.Rows
                RBalance = New RetentionBalance(DocRow)
                RetentionBalanceList.Add(RBalance.ID.ToString & "|" & RBalance.DocType.ToString & "|" & RBalance.pma.ToString & "|" & RBalance.CCID.ToString & "|" & RBalance.CustID.ToString, RBalance)
            Next

            Dim Currentpma As String

            Currentpma = "0|0|0"

            For Each DocRetention As KeyValuePair(Of String, RetentionBalance) In RetentionBalanceList
                If RetentionPMAList.ContainsKey(DocRetention.Value.pma.ToString & "|" & DocRetention.Value.CCID.ToString & "|" & DocRetention.Value.CustID.ToString) Then

                    If Currentpma <> (DocRetention.Value.pma.ToString & "|" & DocRetention.Value.CCID.ToString & "|" & DocRetention.Value.CustID.ToString) Then
                        Currentpma = DocRetention.Value.pma.ToString & "|" & DocRetention.Value.CCID.ToString & "|" & DocRetention.Value.CustID.ToString
                        RPMA = RetentionPMAList(Currentpma)
                    End If


                    If RPMA.EndingBalanceRetention = 0 Then

                        DocRetention.Value.OBalanceRetention = 0
                        DocRetention.Value.Retention = 0
                        DocRetention.Value.DecreaseRetention = 0
                        DocRetention.Value.BalanceRetention = 0

                    End If

                End If
            Next

            For Each DocRetention As KeyValuePair(Of String, RetentionBalance) In RetentionBalanceList
                If DocumentBalanceList.ContainsKey(DocRetention.Value.ID.ToString & "|" & DocRetention.Value.DocType.ToString & "|" & DocRetention.Value.CCID.ToString & "|" & DocRetention.Value.CustID.ToString) Then

                    DocBalance = DocumentBalanceList(DocRetention.Value.ID.ToString & "|" & DocRetention.Value.DocType.ToString & "|" & DocRetention.Value.CCID.ToString & "|" & DocRetention.Value.CustID.ToString)

                    DocBalance.OpeningBalance += DocRetention.Value.OpeningBalance
                    DocBalance.Amount += DocRetention.Value.Amount
                    DocBalance.SCN += DocRetention.Value.SCN
                    DocBalance.ReceiveSelection += DocRetention.Value.ReceiveSelection
                    DocBalance.EndingBalance += DocRetention.Value.EndingBalance

                    DocBalance.OBalanceRetention += DocRetention.Value.OBalanceRetention

                    DocBalance.Retention += DocRetention.Value.Retention
                    DocBalance.DecreaseRetention += DocRetention.Value.DecreaseRetention
                    DocBalance.BalanceRetention += DocRetention.Value.BalanceRetention
                    DocBalance.BillRetention += DocRetention.Value.BillRetention

                Else

                    DocBalance = New DocumentBalance
                    DocBalance.ID = DocRetention.Value.ID
                    DocBalance.DocType = DocRetention.Value.DocType
                    DocBalance.CCID = DocRetention.Value.CCID
                    DocBalance.CustID = DocRetention.Value.CustID

                    DocBalance.OpeningBalance = DocRetention.Value.OpeningBalance
                    DocBalance.Amount = DocRetention.Value.Amount
                    DocBalance.SCN = DocRetention.Value.SCN
                    DocBalance.ReceiveSelection = DocRetention.Value.ReceiveSelection
                    DocBalance.EndingBalance = DocRetention.Value.EndingBalance

                    DocBalance.OBalanceRetention = DocRetention.Value.OBalanceRetention

                    DocBalance.Retention = DocRetention.Value.Retention
                    DocBalance.DecreaseRetention = DocRetention.Value.DecreaseRetention
                    DocBalance.BalanceRetention = DocRetention.Value.BalanceRetention
                    DocBalance.BillRetention = DocRetention.Value.BillRetention

                    DocumentBalanceList.Add(DocRetention.Value.ID.ToString & "|" & DocRetention.Value.DocType.ToString & "|" & DocRetention.Value.CCID.ToString & "|" & DocRetention.Value.CustID.ToString, DocBalance)

                End If
            Next

            Dim HasARMove As Boolean = False
            Dim HasRetentionMove As Boolean = False
            Dim DocEndBalance As Decimal = 0
            Dim DocOpenRetentionBalance As Decimal = 0
            Dim DocEndRetentionBalance As Decimal = 0

            For Each CustDoc As KeyValuePair(Of String, DocumentBalance) In DocumentBalanceList

                DocEndBalance = CustDoc.Value.EndingBalance
                DocOpenRetentionBalance = CustDoc.Value.OBalanceRetention
                DocEndRetentionBalance = CustDoc.Value.BalanceRetention
                HasARMove = CustDoc.Value.HasARMove
                HasRetentionMove = CustDoc.Value.HasRetentionMove

                If _
                    (((ShowAll) And (ShowAR) And (ShowRetention)) And ((HasARMove) Or (HasRetentionMove))) _
                    OrElse
                    (((ShowAll) And (ShowAR) And Not (ShowRetention)) And ((DocEndBalance <> 0) Or (HasRetentionMove))) _
                    OrElse
                    (((ShowAll) And Not (ShowAR) And (ShowRetention)) And ((HasARMove) Or (DocEndRetentionBalance <> 0))) _
                    OrElse
                    ((Not (ShowAll) And (ShowAR) And Not (ShowRetention)) And (DocEndBalance <> 0)) _
                    OrElse
                    ((Not (ShowAll) And Not (ShowAR) And (ShowRetention)) And (DocEndRetentionBalance <> 0)) _
                    OrElse
                    ((Not (ShowAll) And (ShowAR) And (ShowRetention)) And ((DocEndBalance <> 0) Or (DocEndRetentionBalance <> 0))) _
                Then

                    If CustomerBalanceList.ContainsKey(CustDoc.Value.CustID.ToString) Then

                        CustBalance = CustomerBalanceList(CustDoc.Value.CustID.ToString)

                        CustBalance.OpeningBalance += CustDoc.Value.OpeningBalance
                        CustBalance.Amount += CustDoc.Value.Amount
                        CustBalance.SCN += CustDoc.Value.SCN
                        CustBalance.ReceiveSelection += CustDoc.Value.ReceiveSelection
                        CustBalance.EndingBalance += CustDoc.Value.EndingBalance

                        CustBalance.OBalanceRetention += CustDoc.Value.OBalanceRetention

                        CustBalance.Retention += CustDoc.Value.Retention
                        CustBalance.DecreaseRetention += CustDoc.Value.DecreaseRetention
                        CustBalance.BalanceRetention += CustDoc.Value.BalanceRetention
                        CustBalance.BillRetention += CustDoc.Value.BillRetention

                    Else

                        CustBalance = New CustomerBalance()

                        CustBalance.CustID = CustDoc.Value.CustID

                        CustBalance.OpeningBalance = CustDoc.Value.OpeningBalance
                        CustBalance.Amount = CustDoc.Value.Amount
                        CustBalance.SCN = CustDoc.Value.SCN
                        CustBalance.ReceiveSelection = CustDoc.Value.ReceiveSelection
                        CustBalance.EndingBalance = CustDoc.Value.EndingBalance

                        CustBalance.OBalanceRetention = CustDoc.Value.OBalanceRetention

                        CustBalance.Retention = CustDoc.Value.Retention
                        CustBalance.DecreaseRetention = CustDoc.Value.DecreaseRetention
                        CustBalance.BalanceRetention = CustDoc.Value.BalanceRetention
                        CustBalance.BillRetention = CustDoc.Value.BillRetention

                        CustomerBalanceList.Add(CustBalance.CustID.ToString, CustBalance)

                    End If

                End If


            Next

        End Sub

        Private Sub PopulateData()

            Dim ShowDetail As Boolean = False
            Dim ShowAll As Boolean = False
            Dim ShowAR As Boolean = False
            Dim ShowRetention As Boolean = False

            ShowDetail = CBool(Me.Filters(7).Value)
            ShowAll = CBool(Me.Filters(8).Value)
            ShowAR = CBool(Me.Filters(15).Value)
            ShowRetention = CBool(Me.Filters(16).Value)

            CalData()

            Dim totalOpeningBalance As Decimal = 0
            Dim totalAmount As Decimal = 0
            Dim totalSCN As Decimal = 0
            Dim totalReceive As Decimal = 0
            Dim totalEndingBalance As Decimal = 0

            Dim totalOpeningBalanceRetention As Decimal = 0
            Dim totalRetention As Decimal = 0
            Dim totalDecreaseRetention As Decimal = 0
            Dim totalEndingBalanceRetention As Decimal = 0

            Dim totalRetentionBill As Decimal = 0

            Dim trCustomer As TreeRow
            Dim trDetail As TreeRow

            Dim _ARCustomer As ARCustomer

            Dim indent As String = Space(3)
            Dim rowIndex As Integer
            m_hashData = New Hashtable

            Dim colShift As Integer = 0

            If ShowDetail Then
                colShift = 1
            End If

            For Each KV As KeyValuePair(Of String, ARCustomer) In ARCustomerList

                _ARCustomer = KV.Value

                If _ARCustomer.DocumentList.Count > 0 Then

                    trCustomer = Me.Treemanager.Treetable.Childs.Add

                    If ShowDetail Then
                        trCustomer.Tag = "Font.Bold"
                    End If


                    trCustomer("col0") = _ARCustomer.CustomerCode

                    trCustomer("col1") = _ARCustomer.CustomerName


                    trCustomer("col" & 4 + colShift) = Configuration.FormatToString(_ARCustomer.OpeningBalance, DigitConfig.Price)
                    totalOpeningBalance += _ARCustomer.OpeningBalance

                    trCustomer("col" & 5 + colShift) = Configuration.FormatToString(_ARCustomer.Amount, DigitConfig.Price)
                    totalAmount += _ARCustomer.Amount

                    trCustomer("col" & 6 + colShift) = Configuration.FormatToString(_ARCustomer.SCN, DigitConfig.Price)
                    totalSCN += _ARCustomer.SCN

                    trCustomer("col" & 7 + colShift) = Configuration.FormatToString(_ARCustomer.Receive, DigitConfig.Price)
                    totalReceive += _ARCustomer.Receive

                    trCustomer("col" & 8 + colShift) = Configuration.FormatToString(_ARCustomer.EndingBalance, DigitConfig.Price)
                    totalEndingBalance += _ARCustomer.EndingBalance

                    '============================================-Retention===================================================

                    trCustomer("col" & 9 + colShift) = Configuration.FormatToString(_ARCustomer.OpeningBalanceRetention, DigitConfig.Price)
                    totalOpeningBalanceRetention += _ARCustomer.OpeningBalanceRetention

                    trCustomer("col" & 10 + colShift) = Configuration.FormatToString(_ARCustomer.Retention, DigitConfig.Price)
                    totalRetention += _ARCustomer.Retention

                    trCustomer("col" & 11 + colShift) = Configuration.FormatToString(_ARCustomer.DecreaseRetention, DigitConfig.Price)
                    totalDecreaseRetention += _ARCustomer.DecreaseRetention

                    trCustomer("col" & 12 + colShift) = Configuration.FormatToString(_ARCustomer.EndingBalanceRetention, DigitConfig.Price)
                    totalEndingBalanceRetention += _ARCustomer.EndingBalanceRetention

                    trCustomer("col" & 13 + colShift) = Configuration.FormatToString(_ARCustomer.RetentionBill, DigitConfig.Price)
                    totalRetentionBill += _ARCustomer.RetentionBill

                    '=========================================================================================================



                    If ShowDetail Then

                        For Each Doc As ARDocument In _ARCustomer.DocumentList

                            trDetail = trCustomer.Childs.Add

                            rowIndex = Me.m_treemanager.Treetable.Rows.IndexOf(trDetail) + 1
                            m_hashData(rowIndex) = Doc

                            trDetail("col0") = indent & Doc.DocTypeDescription
                            trDetail("col1") = indent & Doc.DocCode
                            trDetail("col2") = indent & Doc.DocDate.ToShortDateString
                            trDetail("col3") = indent & Doc.GlCode
                            trDetail("col4") = indent & Doc.CostCenter

                            trDetail("col5") = Configuration.FormatToString(Doc.OpeningBalance, DigitConfig.Price)

                            trDetail("col6") = Configuration.FormatToString(Doc.Amount, DigitConfig.Price)

                            trDetail("col7") = Configuration.FormatToString(Doc.SCN, DigitConfig.Price)

                            trDetail("col8") = Configuration.FormatToString(Doc.Receive, DigitConfig.Price)

                            trDetail("col9") = Configuration.FormatToString(Doc.EndingBalance, DigitConfig.Price)


                            '============================================-Retention===================================================


                            trDetail("col10") = Configuration.FormatToString(Doc.OpeningRetention - Doc.OpeningDecreaseRetention, DigitConfig.Price)

                            trDetail("col11") = Configuration.FormatToString(Doc.Retention, DigitConfig.Price)

                            trDetail("col12") = Configuration.FormatToString(Doc.DecreaseRetention, DigitConfig.Price)

                            trDetail("col13") = Configuration.FormatToString(Doc.EndingBalanceRetention, DigitConfig.Price)

                            trDetail("col14") = Configuration.FormatToString(Doc.RetentionBill, DigitConfig.Price)

                            '=========================================================================================================

                            trDetail("col15") = Doc.GlNote

                            trDetail("col16") = Doc.VatCode

                        Next

                    End If

                End If
            Next

            trCustomer = Me.Treemanager.Treetable.Childs.Add

            trCustomer("col" & 4 + colShift) = Configuration.FormatToString(totalOpeningBalance, DigitConfig.Price)

            trCustomer("col" & 5 + colShift) = Configuration.FormatToString(totalAmount, DigitConfig.Price)

            trCustomer("col" & 6 + colShift) = Configuration.FormatToString(totalSCN, DigitConfig.Price)

            trCustomer("col" & 7 + colShift) = Configuration.FormatToString(totalReceive, DigitConfig.Price)

            trCustomer("col" & 8 + colShift) = Configuration.FormatToString(totalEndingBalance, DigitConfig.Price)

            '============================================-Retention===================================================

            trCustomer("col" & 9 + colShift) = Configuration.FormatToString(totalOpeningBalanceRetention, DigitConfig.Price)

            trCustomer("col" & 10 + colShift) = Configuration.FormatToString(totalRetention, DigitConfig.Price)

            trCustomer("col" & 11 + colShift) = Configuration.FormatToString(totalDecreaseRetention, DigitConfig.Price)

            trCustomer("col" & 12 + colShift) = Configuration.FormatToString(totalEndingBalanceRetention, DigitConfig.Price)

            trCustomer("col" & 13 + colShift) = Configuration.FormatToString(totalRetentionBill, DigitConfig.Price)

            '=========================================================================================================








        End Sub

        Private ARCustomerList As Dictionary(Of String, ARCustomer)
        Private ARDocumentList As List(Of ARDocument)
        Private ARRetentionCCList As Dictionary(Of String, ARRetentionCC)

        Private Sub CalData()

            Dim ShowDetail As Boolean = False
            Dim ShowAll As Boolean = False
            Dim ShowAR As Boolean = False
            Dim ShowRetention As Boolean = False

            ShowDetail = CBool(Me.Filters(7).Value)
            ShowAll = CBool(Me.Filters(8).Value)
            ShowAR = CBool(Me.Filters(15).Value)
            ShowRetention = CBool(Me.Filters(16).Value)

            Dim dtARCustomer As DataTable
            Dim dtARDocument As DataTable
            Dim dtARRetentionCC As DataTable

            Dim objARCustomer As ARCustomer
            Dim objARDocument As ARDocument
            Dim objARRetentionCC As ARRetentionCC

            dtARCustomer = Me.DataSet.Tables(0)
            ARCustomerList = New Dictionary(Of String, ARCustomer)
            For Each ARRow As DataRow In dtARCustomer.Rows
                objARCustomer = New ARCustomer(ARRow)
                ARCustomerList.Add("|" & objARCustomer.CustomerId.ToString & "|", objARCustomer)
            Next

            dtARDocument = Me.DataSet.Tables(1)
            ARDocumentList = New List(Of ARDocument)
            For Each ARRow As DataRow In dtARDocument.Rows
                objARDocument = New ARDocument(ARRow)
                ARDocumentList.Add(objARDocument)
            Next

            dtARRetentionCC = Me.DataSet.Tables(2)
            ARRetentionCCList = New Dictionary(Of String, ARRetentionCC)
            For Each ARRow As DataRow In dtARRetentionCC.Rows
                objARRetentionCC = New ARRetentionCC(ARRow)
                ARRetentionCCList.Add("|" & objARRetentionCC.CustomerId.ToString & "|" & objARRetentionCC.CostCenterId.ToString & "|", objARRetentionCC)
            Next

            For Each KV As KeyValuePair(Of String, ARRetentionCC) In ARRetentionCCList
                objARRetentionCC = KV.Value

                If objARRetentionCC.EndingBalanceRetention > 0 Then
                    objARRetentionCC.EndingRetention = objARRetentionCC.EndingDecreaseRetention
                    objARRetentionCC.RetentionBill = objARRetentionCC.EndingDecreaseRetention
                ElseIf objARRetentionCC.EndingBalanceRetention < 0 Then
                    objARRetentionCC.EndingDecreaseRetention = objARRetentionCC.EndingRetention
                End If


            Next

            For Each Doc As ARDocument In ARDocumentList

                objARRetentionCC = ARRetentionCCList("|" & Doc.CustomerId.ToString & "|" & Doc.CostCenterId.ToString & "|")

                If objARRetentionCC.EndingBalanceRetention > 0 Then

                    Doc.OpeningDecreaseRetention = 0
                    Doc.DecreaseRetention = 0



                    If Doc.RetentionBill <> 0 Then
                        If Doc.RetentionBill <= objARRetentionCC.RetentionBill Then
                            objARRetentionCC.RetentionBill = objARRetentionCC.RetentionBill - Doc.OpeningRetention
                            Doc.RetentionBill = 0
                        Else
                            Doc.RetentionBill = Doc.RetentionBill - objARRetentionCC.RetentionBill
                            objARRetentionCC.RetentionBill = 0
                        End If
                    End If

                    If Doc.OpeningRetention <> 0 Then
                        If Doc.OpeningRetention <= objARRetentionCC.EndingRetention Then
                            objARRetentionCC.EndingRetention = objARRetentionCC.EndingRetention - Doc.OpeningRetention
                            Doc.OpeningRetention = 0
                        Else
                            Doc.OpeningRetention = Doc.OpeningRetention - objARRetentionCC.EndingRetention
                            objARRetentionCC.EndingRetention = 0
                        End If
                    End If

                    If Doc.Retention <> 0 Then
                        If Doc.Retention <= objARRetentionCC.EndingRetention Then
                            objARRetentionCC.EndingRetention = objARRetentionCC.EndingRetention - Doc.Retention
                            Doc.Retention = 0
                        Else
                            Doc.Retention = Doc.Retention - objARRetentionCC.EndingRetention
                            objARRetentionCC.EndingRetention = 0
                        End If
                    End If

                    Doc.EndingBalanceRetention = Doc.OpeningRetention + Doc.Retention

                ElseIf objARRetentionCC.EndingBalanceRetention < 0 Then

                    Doc.OpeningRetention = 0
                    Doc.Retention = 0
                    Doc.RetentionBill = 0

                    If Doc.OpeningDecreaseRetention <> 0 Then
                        If Doc.OpeningDecreaseRetention <= objARRetentionCC.EndingDecreaseRetention Then
                            objARRetentionCC.EndingDecreaseRetention = objARRetentionCC.EndingDecreaseRetention - Doc.OpeningDecreaseRetention
                            Doc.OpeningDecreaseRetention = 0
                        Else
                            Doc.OpeningDecreaseRetention = Doc.OpeningDecreaseRetention - objARRetentionCC.EndingDecreaseRetention
                            objARRetentionCC.EndingDecreaseRetention = 0
                        End If
                    End If

                    If Doc.DecreaseRetention <> 0 Then
                        If Doc.DecreaseRetention <= objARRetentionCC.EndingDecreaseRetention Then
                            objARRetentionCC.EndingDecreaseRetention = objARRetentionCC.EndingRetention - Doc.DecreaseRetention
                            Doc.DecreaseRetention = 0
                        Else
                            Doc.DecreaseRetention = Doc.DecreaseRetention - objARRetentionCC.EndingDecreaseRetention
                            objARRetentionCC.EndingDecreaseRetention = 0
                        End If
                    End If

                    Doc.EndingBalanceRetention = -(Doc.OpeningDecreaseRetention + Doc.DecreaseRetention)
                Else

                    Doc.OpeningRetention = 0
                    Doc.OpeningDecreaseRetention = 0
                    Doc.Retention = 0
                    Doc.DecreaseRetention = 0

                    Doc.EndingBalanceRetention = 0

                    Doc.RetentionBill = 0

                End If

            Next

            For Each Doc As ARDocument In ARDocumentList

                objARCustomer = ARCustomerList("|" & Doc.CustomerId.ToString & "|")

                If _
                    (((ShowAll) And (ShowAR) And (ShowRetention)) And ((Doc.HasARMove) Or (Doc.HasRetentionMove))) _
                    OrElse
                    (((ShowAll) And (ShowAR) And Not (ShowRetention)) And ((Doc.EndingBalance <> 0) Or (Doc.HasRetentionMove))) _
                    OrElse
                    (((ShowAll) And Not (ShowAR) And (ShowRetention)) And ((Doc.HasARMove) Or (Doc.EndingBalanceRetention <> 0))) _
                    OrElse
                    ((Not (ShowAll) And (ShowAR) And Not (ShowRetention)) And (Doc.EndingBalance <> 0)) _
                    OrElse
                    ((Not (ShowAll) And Not (ShowAR) And (ShowRetention)) And (Doc.EndingBalanceRetention <> 0)) _
                    OrElse
                    ((Not (ShowAll) And (ShowAR) And (ShowRetention)) And ((Doc.EndingBalance <> 0) Or (Doc.EndingBalanceRetention <> 0))) _
                    OrElse
                    ((Not (ShowAll) And Not (ShowAR) And Not (ShowRetention)) And ((Doc.EndingBalance <> 0) Or (Doc.EndingBalanceRetention <> 0))) _
                Then

                    If Doc.DocType <> 82 Then

                        objARCustomer.OpeningBalance += Doc.OpeningBalance
                        objARCustomer.Amount += Doc.Amount
                        objARCustomer.SCN += Doc.SCN
                        objARCustomer.Receive += Doc.Receive
                        objARCustomer.EndingBalance += Doc.EndingBalance

                    End If


                    objARCustomer.OpeningBalanceRetention += Doc.OpeningRetention - Doc.OpeningDecreaseRetention
                    objARCustomer.Retention += Doc.Retention
                    objARCustomer.DecreaseRetention += Doc.DecreaseRetention
                    objARCustomer.EndingBalanceRetention += Doc.EndingBalanceRetention

                    objARCustomer.RetentionBill += Doc.RetentionBill

                    objARCustomer.DocumentList.Add(Doc)

                End If

            Next

        End Sub

        Private Class ARCustomer

            Public Sub New(ARRow As DataRow)

                _CustomerId = CInt(ARRow("CustomerId"))
                _CustomerCode = CStr(ARRow("CustomerCode"))
                _CustomerName = CStr(ARRow("CustomerName"))
                _CustomerGroupCode = CStr(ARRow("CustomerGroupCode"))

                DocumentList = New List(Of ARDocument)

            End Sub

            Public DocumentList As List(Of ARDocument)

            Private _CustomerId As Integer
            Public Property CustomerId As Integer
                Get
                    Return _CustomerId
                End Get
                Set(value As Integer)
                    _CustomerId = value
                End Set
            End Property

            Private _CustomerCode As String
            Public Property CustomerCode As String
                Get
                    Return _CustomerCode
                End Get
                Set(value As String)
                    _CustomerCode = value
                End Set
            End Property

            Private _CustomerName As String
            Public Property CustomerName As String
                Get
                    Return _CustomerName
                End Get
                Set(value As String)
                    _CustomerName = value
                End Set
            End Property

            Private _CustomerGroupCode As String
            Public Property CustomerGroupCode As String
                Get
                    Return _CustomerGroupCode
                End Get
                Set(value As String)
                    _CustomerGroupCode = value
                End Set
            End Property

            Private _OpeningBalance As Decimal
            Public Property OpeningBalance As Decimal
                Get
                    Return _OpeningBalance
                End Get
                Set(value As Decimal)
                    _OpeningBalance = value
                End Set
            End Property

            Private _Amount As Decimal
            Public Property Amount As Decimal
                Get
                    Return _Amount
                End Get
                Set(value As Decimal)
                    _Amount = value
                End Set
            End Property

            Private _SCN As Decimal
            Public Property SCN As Decimal
                Get
                    Return _SCN
                End Get
                Set(value As Decimal)
                    _SCN = value
                End Set
            End Property

            Private _Receive As Decimal
            Public Property Receive As Decimal
                Get
                    Return _Receive
                End Get
                Set(value As Decimal)
                    _Receive = value
                End Set
            End Property

            Private _EndingBalance As Decimal
            Public Property EndingBalance As Decimal
                Get
                    Return _EndingBalance
                End Get
                Set(value As Decimal)
                    _EndingBalance = value
                End Set
            End Property

            Private _OpeningBalanceRetention As Decimal
            Public Property OpeningBalanceRetention As Decimal
                Get
                    Return _OpeningBalanceRetention
                End Get
                Set(value As Decimal)
                    _OpeningBalanceRetention = value
                End Set
            End Property

            Private _Retention As Decimal
            Public Property Retention As Decimal
                Get
                    Return _Retention
                End Get
                Set(value As Decimal)
                    _Retention = value
                End Set
            End Property

            Private _DecreaseRetention As Decimal
            Public Property DecreaseRetention As Decimal
                Get
                    Return _DecreaseRetention
                End Get
                Set(value As Decimal)
                    _DecreaseRetention = value
                End Set
            End Property

            Private _EndingBalanceRetention As Decimal
            Public Property EndingBalanceRetention As Decimal
                Get
                    Return _EndingBalanceRetention
                End Get
                Set(value As Decimal)
                    _EndingBalanceRetention = value
                End Set
            End Property

            Private _RetentionBill As Decimal
            Public Property RetentionBill As Decimal
                Get
                    Return _RetentionBill
                End Get
                Set(value As Decimal)
                    _RetentionBill = value
                End Set
            End Property

        End Class

        Private Class ARDocument

            Public Sub New(ARRow As DataRow)

                _CustomerId = CInt(ARRow("CustomerId"))

                _DocId = CInt(ARRow("DocID"))
                _DocType = CInt(ARRow("DocType"))
                _DocTypeDescription = CStr(ARRow("DocTypeDescription"))
                _DocCode = CStr(ARRow("DocCode"))

                If Not ARRow.IsNull("DocDate") Then
                    _DocDate = CDate(ARRow("DocDate"))
                End If

                _CostCenterId = CInt(ARRow("CostCenterId"))
                _CostCenter = CStr(ARRow("CostCenter"))

                _OpeningBalance = CDec(ARRow("OpeningBalance"))

                _Amount = CDec(ARRow("Amount"))
                _SCN = CDec(ARRow("SCN"))
                _Receive = CDec(ARRow("Receive"))

                _EndingBalance = CDec(ARRow("EndingBalance"))

                _OpeningRetention = CDec(ARRow("OpeningRetention"))
                _OpeningDecreaseRetention = CDec(ARRow("OpeningDecreaseRetention"))

                _Retention = CDec(ARRow("Retention"))
                _DecreaseRetention = CDec(ARRow("DecreaseRetention"))
                _RetentionBill = CDec(ARRow("RetentionBill"))

                _GlCode = CStr(ARRow("GlCode"))
                _GlNote = CStr(ARRow("GlNote"))
                _VatCode = CStr(ARRow("VatCode"))

            End Sub

            Private _CustomerId As Integer
            Public Property CustomerId As Integer
                Get
                    Return _CustomerId
                End Get
                Set(value As Integer)
                    _CustomerId = value
                End Set
            End Property

            Private _DocId As Integer
            Public Property DocId As Integer
                Get
                    Return _DocId
                End Get
                Set(value As Integer)
                    _DocId = value
                End Set
            End Property

            Private _DocType As Integer
            Public Property DocType As Integer
                Get
                    Return _DocType
                End Get
                Set(value As Integer)
                    _DocType = value
                End Set
            End Property


            Private _DocTypeDescription As String
            Public Property DocTypeDescription As String
                Get
                    Return _DocTypeDescription
                End Get
                Set(value As String)
                    _DocTypeDescription = value
                End Set
            End Property

            Private _DocCode As String
            Public Property DocCode As String
                Get
                    Return _DocCode
                End Get
                Set(value As String)
                    _DocCode = value
                End Set
            End Property

            Private _DocDate As Date
            Public Property DocDate As Date
                Get
                    Return _DocDate
                End Get
                Set(value As Date)
                    _DocDate = value
                End Set
            End Property

            Private _CostCenterId As Integer
            Public Property CostCenterId As Integer
                Get
                    Return _CostCenterId
                End Get
                Set(value As Integer)
                    _CostCenterId = value
                End Set
            End Property

            Private _CostCenter As String
            Public Property CostCenter As String
                Get
                    Return _CostCenter
                End Get
                Set(value As String)
                    _CostCenter = value
                End Set
            End Property

            Private _OpeningBalance As Decimal
            Public Property OpeningBalance As Decimal
                Get
                    Return _OpeningBalance
                End Get
                Set(value As Decimal)
                    _OpeningBalance = value
                End Set
            End Property

            Private _Amount As Decimal
            Public Property Amount As Decimal
                Get
                    Return _Amount
                End Get
                Set(value As Decimal)
                    _Amount = value
                End Set
            End Property

            Private _SCN As Decimal
            Public Property SCN As Decimal
                Get
                    Return _SCN
                End Get
                Set(value As Decimal)
                    _SCN = value
                End Set
            End Property

            Private _Receive As Decimal
            Public Property Receive As Decimal
                Get
                    Return _Receive
                End Get
                Set(value As Decimal)
                    _Receive = value
                End Set
            End Property

            Private _EndingBalance As Decimal
            Public Property EndingBalance As Decimal
                Get
                    Return _EndingBalance
                End Get
                Set(value As Decimal)
                    _EndingBalance = value
                End Set
            End Property

            Private _OpeningRetention As Decimal
            Public Property OpeningRetention As Decimal
                Get
                    Return _OpeningRetention
                End Get
                Set(value As Decimal)
                    _OpeningRetention = value
                End Set
            End Property

            Private _OpeningDecreaseRetention As Decimal
            Public Property OpeningDecreaseRetention As Decimal
                Get
                    Return _OpeningDecreaseRetention
                End Get
                Set(value As Decimal)
                    _OpeningDecreaseRetention = value
                End Set
            End Property

            Private _Retention As Decimal
            Public Property Retention As Decimal
                Get
                    Return _Retention
                End Get
                Set(value As Decimal)
                    _Retention = value
                End Set
            End Property

            Private _DecreaseRetention As Decimal
            Public Property DecreaseRetention As Decimal
                Get
                    Return _DecreaseRetention
                End Get
                Set(value As Decimal)
                    _DecreaseRetention = value
                End Set
            End Property

            Private _EndingBalanceRetention As Decimal
            Public Property EndingBalanceRetention As Decimal
                Get
                    Return _EndingBalanceRetention
                End Get
                Set(value As Decimal)
                    _EndingBalanceRetention = value
                End Set
            End Property

            Private _RetentionBill As Decimal
            Public Property RetentionBill As Decimal
                Get
                    Return _RetentionBill
                End Get
                Set(value As Decimal)
                    _RetentionBill = value
                End Set
            End Property

            Private _GlCode As String
            Public Property GlCode As String
                Get
                    Return _GlCode
                End Get
                Set(value As String)
                    _GlCode = value
                End Set
            End Property

            Private _GlNote As String
            Public Property GlNote As String
                Get
                    Return _GlNote
                End Get
                Set(value As String)
                    _GlNote = value
                End Set
            End Property

            Private _VatCode As String
            Public Property VatCode As String
                Get
                    Return _VatCode
                End Get
                Set(value As String)
                    _VatCode = value
                End Set
            End Property

            Public ReadOnly Property HasARMove As Boolean
                Get

                    If (Math.Abs(_OpeningBalance) + Math.Abs(_Amount) + Math.Abs(_SCN) + Math.Abs(_Receive)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property

            Public ReadOnly Property HasRetentionMove As Boolean
                Get

                    If (Math.Abs(_OpeningRetention - _OpeningDecreaseRetention) + Math.Abs(_Retention) + Math.Abs(_DecreaseRetention) + Math.Abs(_RetentionBill)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property

        End Class

        Private Class ARRetentionCC

            Public Sub New(ARRow As DataRow)

                _CustomerId = CInt(ARRow("CustomerId"))
                _CostCenterId = CInt(ARRow("CostCenterId"))

                _OpeningRetention = CDec(ARRow("OpeningRetention"))
                _OpeningDecreaseRetention = CDec(ARRow("OpeningDecreaseRetention"))

                _Retention = CDec(ARRow("Retention"))
                _DecreaseRetention = CDec(ARRow("DecreaseRetention"))

                _EndingRetention = CDec(ARRow("EndingRetention"))
                _EndingDecreaseRetention = CDec(ARRow("EndingDecreaseRetention"))
                _EndingBalanceRetention = CDec(ARRow("EndingBalanceRetention"))

                _RetentionBill = CDec(ARRow("RetentionBill"))

            End Sub

            Private _CustomerId As Integer
            Public Property CustomerId As Integer
                Get
                    Return _CustomerId
                End Get
                Set(value As Integer)
                    _CustomerId = value
                End Set
            End Property

            Private _CostCenterId As Integer
            Public Property CostCenterId As Integer
                Get
                    Return _CostCenterId
                End Get
                Set(value As Integer)
                    _CostCenterId = value
                End Set
            End Property

            Private _OpeningRetention As Decimal
            Public Property OpeningRetention As Decimal
                Get
                    Return _OpeningRetention
                End Get
                Set(value As Decimal)
                    _OpeningRetention = value
                End Set
            End Property

            Private _OpeningDecreaseRetention As Decimal
            Public Property OpeningDecreaseRetention As Decimal
                Get
                    Return _OpeningDecreaseRetention
                End Get
                Set(value As Decimal)
                    _OpeningDecreaseRetention = value
                End Set
            End Property

            Private _Retention As Decimal
            Public Property Retention As Decimal
                Get
                    Return _Retention
                End Get
                Set(value As Decimal)
                    _Retention = value
                End Set
            End Property

            Private _DecreaseRetention As Decimal
            Public Property DecreaseRetention As Decimal
                Get
                    Return _DecreaseRetention
                End Get
                Set(value As Decimal)
                    _DecreaseRetention = value
                End Set
            End Property

            Private _EndingRetention As Decimal
            Public Property EndingRetention As Decimal
                Get
                    Return _EndingRetention
                End Get
                Set(value As Decimal)
                    _EndingRetention = value
                End Set
            End Property

            Private _EndingDecreaseRetention As Decimal
            Public Property EndingDecreaseRetention As Decimal
                Get
                    Return _EndingDecreaseRetention
                End Get
                Set(value As Decimal)
                    _EndingDecreaseRetention = value
                End Set
            End Property

            Private _EndingBalanceRetention As Decimal
            Public Property EndingBalanceRetention As Decimal
                Get
                    Return _EndingBalanceRetention
                End Get
                Set(value As Decimal)
                    _EndingBalanceRetention = value
                End Set
            End Property

            Private _RetentionBill As Decimal
            Public Property RetentionBill As Decimal
                Get
                    Return _RetentionBill
                End Get
                Set(value As Decimal)
                    _RetentionBill = value
                End Set
            End Property

        End Class

#End Region

#Region "Shared"
#End Region

#Region "Properties"
        Public Overrides ReadOnly Property ClassName() As String
            Get
                Return "RptARRemain"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.DetailLabel}"
            End Get
        End Property
        Public Overrides ReadOnly Property DetailPanelIcon() As String
            Get
                Return "Icons.16x16.RptARRemain"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelIcon() As String
            Get
                Return "Icons.16x16.RptARRemain"
            End Get
        End Property
        Public Overrides ReadOnly Property ListPanelTitle() As String
            Get
                Return "${res:Longkong.Pojjaman.BusinessLogic.RptARRemain.ListLabel}"
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
                    Case "month", "year", "today"
                        dpiColl.Add(fixDpi)
                    Case "docdatestart", "docdateend"
                        dpiColl.Add(fixDpi)
                    Case "customerstart", "customerend"
                        dpiColl.Add(fixDpi)
                    Case "costcenterstart", "costcenterend"
                        dpiColl.Add(fixDpi)
                End Select
            Next

            Dim startRow As Integer = 2
            Dim i As Integer = 0
            Dim fn As Font

            If CInt(Me.Filters(7).Value) <> 0 Then
                startRow = 3
            End If

            For rowIndex As Integer = startRow To m_grid.RowCount
                If CType(Me.Treemanager.Treetable.Rows(i), TreeRow) Is Nothing Then
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                Else
                    fn = New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
                End If
                For colIndex As Integer = 1 To m_grid.ColCount

                    dpi = New DocPrintingItem
                    dpi.Mapping = "col" & (colIndex - 1).ToString
                    dpi.Value = m_grid(rowIndex, colIndex).CellValue
                    dpi.DataType = "System.String"
                    dpi.Row = i + 1
                    dpi.Table = "Item"
                    dpi.Font = fn
                    dpiColl.Add(dpi)
                Next
                i += 1
            Next

            Return dpiColl
        End Function
#End Region

        Private Class CustomerBalance

            Private _CustID As Integer
            Public Property CustID As Integer
                Get
                    Return _CustID
                End Get
                Set(value As Integer)
                    _CustID = value
                End Set
            End Property

#Region "AR Property"

            Private _OpeningBalance As Decimal
            Public Property OpeningBalance As Decimal
                Get
                    Return _OpeningBalance
                End Get
                Set(value As Decimal)
                    _OpeningBalance = value
                End Set
            End Property

            Private _Amount As Decimal
            Public Property Amount As Decimal
                Get
                    Return _Amount
                End Get
                Set(value As Decimal)
                    _Amount = value
                End Set
            End Property

            Private _SCN As Decimal
            Public Property SCN As Decimal
                Get
                    Return _SCN
                End Get
                Set(value As Decimal)
                    _SCN = value
                End Set
            End Property

            Private _ReceiveSelection As Decimal
            Public Property ReceiveSelection As Decimal
                Get
                    Return _ReceiveSelection
                End Get
                Set(value As Decimal)
                    _ReceiveSelection = value
                End Set
            End Property

            Private _EndingBalance As Decimal
            Public Property EndingBalance As Decimal
                Get
                    Return _EndingBalance
                End Get
                Set(value As Decimal)
                    _EndingBalance = value
                End Set
            End Property

            Public ReadOnly Property HasARMove As Boolean
                Get

                    If (Math.Abs(_OpeningBalance) + Math.Abs(_Amount) + Math.Abs(_SCN) + Math.Abs(_ReceiveSelection)) <> 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property
#End Region

#Region "Retention Property"


            Private _ODecreaseRetention As Decimal
            Public Property ODecreaseRetention As Decimal
                Get
                    Return _ODecreaseRetention
                End Get
                Set(value As Decimal)
                    _ODecreaseRetention = value
                End Set
            End Property

            Private _OBalanceRetention As Decimal
            Public Property OBalanceRetention As Decimal
                Get
                    Return _OBalanceRetention
                End Get
                Set(value As Decimal)
                    _OBalanceRetention = value
                End Set
            End Property

            Private _Retention As Decimal
            Public Property Retention As Decimal
                Get
                    Return _Retention
                End Get
                Set(value As Decimal)
                    _Retention = value
                End Set
            End Property

            Private _DecreaseRetention As Decimal
            Public Property DecreaseRetention As Decimal
                Get
                    Return _DecreaseRetention
                End Get
                Set(value As Decimal)
                    _DecreaseRetention = value
                End Set
            End Property

            Private _BalanceRetention As Decimal
            Public Property BalanceRetention As Decimal
                Get
                    Return _BalanceRetention
                End Get
                Set(value As Decimal)
                    _BalanceRetention = value
                End Set
            End Property

            Private _BillRetention As Decimal
            Public Property BillRetention As Decimal
                Get
                    Return _BillRetention
                End Get
                Set(value As Decimal)
                    _BillRetention = value
                End Set
            End Property


            Public ReadOnly Property HasRetentionMove As Boolean
                Get

                    If (Math.Abs(_OBalanceRetention) + Math.Abs(_Retention) + Math.Abs(_DecreaseRetention) + Math.Abs(_BillRetention)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property

#End Region

        End Class

        Private Class DocumentBalance

            Private _ID As Integer
            Public Property ID As Integer
                Get
                    Return _ID
                End Get
                Set(value As Integer)
                    _ID = value
                End Set
            End Property

            Private _DocType As Integer
            Public Property DocType As Integer
                Get
                    Return _DocType
                End Get
                Set(value As Integer)
                    _DocType = value
                End Set
            End Property

            Private _CCID As Integer
            Public Property CCID As Integer
                Get
                    Return _CCID
                End Get
                Set(value As Integer)
                    _CCID = value
                End Set
            End Property

            Private _CustID As Integer
            Public Property CustID As Integer
                Get
                    Return _CustID
                End Get
                Set(value As Integer)
                    _CustID = value
                End Set
            End Property

#Region "AR Property"

            Private _OpeningBalance As Decimal
            Public Property OpeningBalance As Decimal
                Get
                    Return _OpeningBalance
                End Get
                Set(value As Decimal)
                    _OpeningBalance = value
                End Set
            End Property

            Private _Amount As Decimal
            Public Property Amount As Decimal
                Get
                    Return _Amount
                End Get
                Set(value As Decimal)
                    _Amount = value
                End Set
            End Property

            Private _SCN As Decimal
            Public Property SCN As Decimal
                Get
                    Return _SCN
                End Get
                Set(value As Decimal)
                    _SCN = value
                End Set
            End Property

            Private _ReceiveSelection As Decimal
            Public Property ReceiveSelection As Decimal
                Get
                    Return _ReceiveSelection
                End Get
                Set(value As Decimal)
                    _ReceiveSelection = value
                End Set
            End Property

            Private _EndingBalance As Decimal
            Public Property EndingBalance As Decimal
                Get
                    Return _EndingBalance
                End Get
                Set(value As Decimal)
                    _EndingBalance = value
                End Set
            End Property

            Public ReadOnly Property HasARMove As Boolean
                Get

                    If (Math.Abs(_OpeningBalance) + Math.Abs(_Amount) + Math.Abs(_SCN) + Math.Abs(_ReceiveSelection)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property
#End Region

#Region "Retention Property"

            Private _OBalanceRetention As Decimal
            Public Property OBalanceRetention As Decimal
                Get
                    Return _OBalanceRetention
                End Get
                Set(value As Decimal)
                    _OBalanceRetention = value
                End Set
            End Property

            Private _Retention As Decimal
            Public Property Retention As Decimal
                Get
                    Return _Retention
                End Get
                Set(value As Decimal)
                    _Retention = value
                End Set
            End Property

            Private _DecreaseRetention As Decimal
            Public Property DecreaseRetention As Decimal
                Get
                    Return _DecreaseRetention
                End Get
                Set(value As Decimal)
                    _DecreaseRetention = value
                End Set
            End Property

            Private _BalanceRetention As Decimal
            Public Property BalanceRetention As Decimal
                Get
                    Return _BalanceRetention
                End Get
                Set(value As Decimal)
                    _BalanceRetention = value
                End Set
            End Property

            Private _BillRetention As Decimal
            Public Property BillRetention As Decimal
                Get
                    Return _BillRetention
                End Get
                Set(value As Decimal)
                    _BillRetention = value
                End Set
            End Property


            Public ReadOnly Property HasRetentionMove As Boolean
                Get

                    If (Math.Abs(_OBalanceRetention) + Math.Abs(_Retention) + Math.Abs(_DecreaseRetention) + Math.Abs(_BillRetention)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property

#End Region

        End Class

        Private Class RetentionBalance

            Public Sub New(DocRow As DataRow)

                _ID = CInt(DocRow("ID"))
                _DocType = CInt(DocRow("DocType"))
                _pma = CInt(DocRow("pma"))
                _CCID = CInt(DocRow("CCID"))
                _CustID = CInt(DocRow("Customer"))

                If Not DocRow.IsNull("OpeningBalance") Then
                    _OpeningBalance = CDec(DocRow("OpeningBalance"))
                Else
                    _OpeningBalance = 0
                End If

                If Not DocRow.IsNull("Amount") Then
                    _Amount = CDec(DocRow("Amount"))
                Else
                    _Amount = 0
                End If

                If Not DocRow.IsNull("SCN") Then
                    _SCN = CDec(DocRow("SCN"))
                Else
                    _SCN = 0
                End If

                If Not DocRow.IsNull("ReceiveSelection") Then
                    _ReceiveSelection = CDec(DocRow("ReceiveSelection"))
                Else
                    _ReceiveSelection = 0
                End If

                If Not DocRow.IsNull("EndingBalance") Then
                    _EndingBalance = CDec(DocRow("EndingBalance"))
                Else
                    _EndingBalance = 0
                End If


                If Not DocRow.IsNull("OPBRetention") Then
                    _OBalanceRetention = CDec(DocRow("OPBRetention"))
                Else
                    _OBalanceRetention = 0
                End If

                If Not DocRow.IsNull("Retention") Then
                    _Retention = CDec(DocRow("Retention"))
                Else
                    _Retention = 0
                End If

                If Not DocRow.IsNull("DecreaseRetention") Then
                    _DecreaseRetention = CDec(DocRow("DecreaseRetention"))
                Else
                    _DecreaseRetention = 0
                End If

                If Not DocRow.IsNull("EndingBalanceRetention") Then
                    _BalanceRetention = CDec(DocRow("EndingBalanceRetention"))
                Else
                    _BalanceRetention = 0
                End If

                If Not DocRow.IsNull("BillRetention") Then
                    _BillRetention = CDec(DocRow("BillRetention"))
                Else
                    _BillRetention = 0
                End If

            End Sub

            Private _ID As Integer
            Public Property ID As Integer
                Get
                    Return _ID
                End Get
                Set(value As Integer)
                    _ID = value
                End Set
            End Property

            Private _DocType As Integer
            Public Property DocType As Integer
                Get
                    Return _DocType
                End Get
                Set(value As Integer)
                    _DocType = value
                End Set
            End Property

            Private _pma As Integer
            Public Property pma As Integer
                Get
                    Return _pma
                End Get
                Set(value As Integer)
                    _pma = value
                End Set
            End Property

            Private _CCID As Integer
            Public Property CCID As Integer
                Get
                    Return _CCID
                End Get
                Set(value As Integer)
                    _CCID = value
                End Set
            End Property

            Private _CustID As Integer
            Public Property CustID As Integer
                Get
                    Return _CustID
                End Get
                Set(value As Integer)
                    _CustID = value
                End Set
            End Property

#Region "AR Property"

            Private _OpeningBalance As Decimal
            Public Property OpeningBalance As Decimal
                Get
                    Return _OpeningBalance
                End Get
                Set(value As Decimal)
                    _OpeningBalance = value
                End Set
            End Property

            Private _Amount As Decimal
            Public Property Amount As Decimal
                Get
                    Return _Amount
                End Get
                Set(value As Decimal)
                    _Amount = value
                End Set
            End Property

            Private _SCN As Decimal
            Public Property SCN As Decimal
                Get
                    Return _SCN
                End Get
                Set(value As Decimal)
                    _SCN = value
                End Set
            End Property

            Private _ReceiveSelection As Decimal
            Public Property ReceiveSelection As Decimal
                Get
                    Return _ReceiveSelection
                End Get
                Set(value As Decimal)
                    _ReceiveSelection = value
                End Set
            End Property

            Private _EndingBalance As Decimal
            Public Property EndingBalance As Decimal
                Get
                    Return _EndingBalance
                End Get
                Set(value As Decimal)
                    _EndingBalance = value
                End Set
            End Property

            Public ReadOnly Property HasARMove As Boolean
                Get

                    If (Math.Abs(_OpeningBalance) + Math.Abs(_Amount) + Math.Abs(_SCN) + Math.Abs(_ReceiveSelection)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property
#End Region

#Region "Retention Property"

            Private _OBalanceRetention As Decimal
            Public Property OBalanceRetention As Decimal
                Get
                    Return _OBalanceRetention
                End Get
                Set(value As Decimal)
                    _OBalanceRetention = value
                End Set
            End Property

            Private _Retention As Decimal
            Public Property Retention As Decimal
                Get
                    Return _Retention
                End Get
                Set(value As Decimal)
                    _Retention = value
                End Set
            End Property

            Private _DecreaseRetention As Decimal
            Public Property DecreaseRetention As Decimal
                Get
                    Return _DecreaseRetention
                End Get
                Set(value As Decimal)
                    _DecreaseRetention = value
                End Set
            End Property

            Private _BalanceRetention As Decimal
            Public Property BalanceRetention As Decimal
                Get
                    Return _BalanceRetention
                End Get
                Set(value As Decimal)
                    _BalanceRetention = value
                End Set
            End Property

            Private _BillRetention As Decimal
            Public Property BillRetention As Decimal
                Get
                    Return _BillRetention
                End Get
                Set(value As Decimal)
                    _BillRetention = value
                End Set
            End Property

            Public ReadOnly Property HasRetentionMove As Boolean
                Get

                    If (Math.Abs(_OBalanceRetention) + Math.Abs(_Retention) + Math.Abs(_DecreaseRetention) + Math.Abs(_BillRetention)) > 0 Then
                        Return True
                    Else
                        Return False
                    End If

                    Return False

                End Get
            End Property

#End Region



        End Class

        Private Class RetentionPMA

            Public Sub New(PMARow As DataRow)

                _pma = CInt(PMARow("pma"))
                _CCID = CInt(PMARow("CCID"))
                _CustID = CInt(PMARow("Customer"))


                _EndingBalanceRetention = CDec(PMARow("EndingBalanceRetention"))

            End Sub

            Private _pma As Integer
            Public Property pma As Integer
                Get
                    Return _pma
                End Get
                Set(value As Integer)
                    _pma = value
                End Set
            End Property

            Private _CCID As Integer
            Public Property CCID As Integer
                Get
                    Return _CCID
                End Get
                Set(value As Integer)
                    _CCID = value
                End Set
            End Property

            Private _CustID As Integer
            Public Property CustID As Integer
                Get
                    Return _CustID
                End Get
                Set(value As Integer)
                    _CustID = value
                End Set
            End Property

            'Private _BalanceRetention As Decimal
            'Public Property BalanceRetention As Decimal
            '    Get
            '        Return _BalanceRetention
            '    End Get
            '    Set(value As Decimal)
            '        _BalanceRetention = value
            '    End Set
            'End Property

            Private _EndingBalanceRetention As Decimal
            Public Property EndingBalanceRetention As Decimal
                Get
                    Return _EndingBalanceRetention
                End Get
                Set(value As Decimal)
                    _EndingBalanceRetention = value
                End Set
            End Property

        End Class

    End Class
End Namespace

