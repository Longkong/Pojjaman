Option Explicit On 
Option Strict On

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
	Public Class RptAREnumerate
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
			m_grid.RowCount = 2
			m_grid.ColCount = 22

			Dim GridRangeStyle1 As GridRangeStyle = New GridRangeStyle
			m_grid.CoveredRanges.AddRange(New GridRangeInfo() {GridRangeInfo.Cells(0, 11, 0, 13)})

			m_grid.ColWidths(1) = 100
			m_grid.ColWidths(2) = 200
			m_grid.ColWidths(3) = 120
			m_grid.ColWidths(4) = 120
			m_grid.ColWidths(5) = 120
			m_grid.ColWidths(6) = 100
			m_grid.ColWidths(7) = 100
			m_grid.ColWidths(8) = 100
			m_grid.ColWidths(9) = 100
			m_grid.ColWidths(10) = 100
			m_grid.ColWidths(11) = 100
			m_grid.ColWidths(12) = 100
			m_grid.ColWidths(13) = 100
			m_grid.ColWidths(14) = 100
			m_grid.ColWidths(15) = 100
			m_grid.ColWidths(16) = 100
			m_grid.ColWidths(17) = 100
			m_grid.ColWidths(18) = 100
			m_grid.ColWidths(19) = 100
			m_grid.ColWidths(20) = 100
			m_grid.ColWidths(21) = 100
			m_grid.ColWidths(22) = 100

			m_grid.ColStyles(1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid.ColStyles(2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid.ColStyles(3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid.ColStyles(4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid.ColStyles(5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid.ColStyles(6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(19).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(20).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(21).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid.ColStyles(22).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

			m_grid.Rows.HeaderCount = 2
			m_grid.Rows.FrozenCount = 2

			Dim indent As String = Space(3)
			m_grid(0, 1).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.PrID}")				 '"�����١˹��"
			m_grid(0, 2).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.PrName}")			 '"�����١˹��"
			m_grid(0, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.CreditAmount}")		'"ǧ�Թ�ôԵ"
			m_grid(0, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.RemainingCreditAmount}")		'"ǧ�Թ�ôԵ�������"
			m_grid(0, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.PrStatus}")		 '"ʶҹ��١˹��"

			GridRangeStyle1.Range = GridRangeInfo.Cell(0, 11)
			GridRangeStyle1.StyleInfo.Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Retention}")				'"Retention"
			GridRangeStyle1.StyleInfo.HorizontalAlignment = GridHorizontalAlignment.Center
			m_grid.RangeStyles.AddRange(New GridRangeStyle() {GridRangeStyle1})

			''tr = Me.m_treemanager.Treetable.Childs.Add
			m_grid(1, 1).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.DocDate}")		 '"�ѹ����͡���"
			m_grid(1, 2).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.DocCode}")		 '"�Ţ����͡���"
			m_grid(1, 3).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.InVoid}")				'"�Ţ���㺡ӡѺ"
			m_grid(1, 4).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.DocType}")			 '"�������͡���"
			m_grid(1, 5).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.PrCode}")			 '"�Ţ�����Ӥѭ����"
			m_grid(1, 6).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Sold}")				'"�������"
			m_grid(1, 7).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.SaleSCN}")				'"Ŵ˹��"
			m_grid(1, 8).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Receive}")			 '"�Ѻ����˹��"
			m_grid(1, 9).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Status}")			 '"�������"
			m_grid(1, 10).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Term}")				 '"���"
			m_grid(1, 11).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.MileStoneRetention}")				'"�١�ѡ"
			m_grid(1, 12).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.ReceiveRetention}")				'"�Ѻ�׹"
			m_grid(1, 13).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.RetentionBalance}")				'"�������"
			m_grid(1, 14).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Cash}")				 '"�Ѻ�Թʴ"
			m_grid(1, 15).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Check}")				 '"���Ѻ"
			m_grid(1, 16).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.AdvancePay}")				 '"�ѡ�Թ�Ѵ��"
			m_grid(1, 17).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Interest}")				 '"�͡�����Ѻ"
			m_grid(1, 18).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.AmtIncrease}")				 '"�ʹ�Ѻ����"
			m_grid(1, 19).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Discount}")				 '"��ǹŴ"
			m_grid(1, 20).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.WHT}")				 '"���� � ������"
			m_grid(1, 21).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.AmtDeduct}")					'"�ʹ�ѡ�Ѻ"
			m_grid(1, 22).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Note}")				 '"�����˵�"

			m_grid(2, 3).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.RefDocCode}")				 '"�͡��õ鹷ҧ"
			m_grid(2, 4).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.RefDocDate}")				'"�ѹ����͡��õ鹷ҧ"
			m_grid(2, 5).Text = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.RefDocPayAmt}")				 '"�ʹ�Թ�������ҧ���"
			m_grid(2, 15).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.CheckCode}")				 '"�Ţ�����"
			m_grid(2, 16).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.CheckDueDate}")				 '"�ѹ��躹��"
			m_grid(2, 17).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.CheckBankAcct}")				 '"�ѭ�ո�Ҥ��"
			m_grid(2, 18).Text = indent & Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.CheckStatus}")				 '"ʶҹ���"

			m_grid(0, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(0, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(0, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(0, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(0, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left

			''tr = Me.m_treemanager.Treetable.Childs.Add
			m_grid(1, 1).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(1, 2).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(1, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(1, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(1, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(1, 6).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 7).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 8).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 9).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 10).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 11).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 12).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 13).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 14).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 19).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 20).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			m_grid(1, 21).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

			m_grid(1, 22).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

			m_grid(2, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(2, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(2, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

			m_grid(2, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(2, 16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(2, 17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
			m_grid(2, 18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
		End Sub

		Private Sub PopulateData()
			Dim dt As DataTable = Me.DataSet.Tables(0)
			Dim dt2 As DataTable = Me.DataSet.Tables(1)
			Dim currentCustomerCode As String = ""
			Dim currentDocCode As String = ""

			Dim indent As String = Space(3)
			Dim tmpRemain As Decimal = 0
			Dim tmpSold As Decimal = 0
			Dim tmpSaleSCN As Decimal = 0

			Dim tmpReceiveSelection As Decimal = 0
			Dim tmpSold2 As Decimal = 0
			Dim tmpReceiveSelection2 As Decimal = 0
			Dim SumCustomer As Int32 = 0
			Dim SumOpnBalance As Decimal = 0
			Dim SumSold As Decimal = 0
			Dim SumSaleSCN As Decimal = 0
			Dim SumReceiveSelection As Decimal = 0
			Dim SumWHT As Decimal = 0
			Dim LastCustomerCrAmtRecord As Decimal = 0
			Dim tmpRet As Decimal = 0
			Dim tmpReceiveRet As Decimal = 0
			Dim tmpRetRemain As Decimal = 0
			Dim sumRet As Decimal = 0
			Dim sumReceiveRet As Decimal = 0
			Dim SumRetOpnBalance As Decimal = 0

			Dim currentCustomerIndex As Integer = -1
			Dim currentDocIndex As Integer = -1

			For Each row As DataRow In dt2.Rows
				If row("CustomerCode").ToString <> currentCustomerCode Then
					SumCustomer += 1

					If SumCustomer > 1 Then
						'ǧ�Թ�ôԵ�������
						m_grid(currentCustomerIndex, 4).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")) - tmpRemain, DigitConfig.Price)
						m_grid(currentCustomerIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
						m_grid.RowCount += 1
						currentDocIndex = m_grid.RowCount
						m_grid.RowStyles(currentDocIndex).BackColor = Color.Khaki
						m_grid.RowStyles(currentDocIndex).ReadOnly = True
						m_grid(currentDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Total}")			 '"����Թ"
						m_grid(currentDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
						m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(tmpSold, DigitConfig.Price)
						m_grid(currentDocIndex, 7).CellValue = Configuration.FormatToString(tmpSaleSCN, DigitConfig.Price)
						m_grid(currentDocIndex, 8).CellValue = Configuration.FormatToString(tmpReceiveSelection, DigitConfig.Price)
						m_grid(currentDocIndex, 11).CellValue = Configuration.FormatToString(tmpRet, DigitConfig.Price)
						m_grid(currentDocIndex, 12).CellValue = Configuration.FormatToString(tmpReceiveRet, DigitConfig.Price)
						tmpSold = 0
						tmpSaleSCN = 0
						tmpReceiveSelection = 0
						tmpRemain = 0


						tmpRet = 0
						tmpReceiveRet = 0
						tmpRetRemain = 0
					End If
					m_grid.RowCount += 1
					currentCustomerIndex = m_grid.RowCount
					m_grid.RowStyles(currentCustomerIndex).BackColor = Color.FromArgb(128, 255, 128)
					m_grid.RowStyles(currentCustomerIndex).Font.Bold = True
					m_grid.RowStyles(currentCustomerIndex).ReadOnly = True

					m_grid(currentCustomerIndex, 1).CellValue = row("CustomerCode")
					m_grid(currentCustomerIndex, 2).CellValue = row("CustomerName")
					m_grid(currentCustomerIndex, 3).CellValue = Configuration.FormatToString(CDec(row("CreditAmount")), DigitConfig.Price)
					m_grid(currentCustomerIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

					m_grid(currentCustomerIndex, 5).CellValue = row("Status")
					currentCustomerCode = row("CustomerCode").ToString
					LastCustomerCrAmtRecord = CDec(row("CreditAmount"))
					Dim supRows As DataRow() = Me.DataSet.Tables(0).Select("CustomerCode ='" & currentCustomerCode & "'")
					If supRows.Length = 1 Then
						m_grid.RowCount += 1
						currentDocIndex = m_grid.RowCount
						m_grid.RowStyles(currentDocIndex).BackColor = Color.Khaki
						m_grid.RowStyles(currentDocIndex).ReadOnly = True
						m_grid(currentDocIndex, 4).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.OpeningBalance}")			 '"�ʹ¡��"
						m_grid(currentDocIndex, 9).CellValue = Configuration.FormatToString(CDec(supRows(0)("OpenningBalance")), DigitConfig.Price)
						SumOpnBalance += CDec(supRows(0)("OpenningBalance"))
						tmpRemain = CDec(supRows(0)("OpenningBalance"))
						SumRetOpnBalance += CDec(supRows(0)("RetentionOpenningBalance"))
						tmpRetRemain = CDec(supRows(0)("RetentionOpenningBalance"))
					End If
					currentDocCode = ""
				End If
        If row("DocCode").ToString <> currentDocCode Then
          m_grid.RowCount += 1
          currentDocIndex = m_grid.RowCount
          m_grid.RowStyles(currentDocIndex).BackColor = Color.Khaki     'Color.FromArgb(128, 255, 128)
          m_grid.RowStyles(currentDocIndex).ReadOnly = True
          If IsDate(row("DocDate")) Then
            m_grid(currentDocIndex, 1).CellValue = indent & CDate(row("DocDate")).ToShortDateString
          End If
          If Not row.IsNull("DocCode") Then
            m_grid(currentDocIndex, 2).CellValue = indent & row("DocCode").ToString
          End If
          If Not row.IsNull("RefCode") Then
            m_grid(currentDocIndex, 3).CellValue = indent & row("RefCode").ToString
          End If
          If Not row.IsNull("Type") Then
            m_grid(currentDocIndex, 4).CellValue = indent & row("Type").ToString
          End If
          If Not row.IsNull("RVCode") Then
            m_grid(currentDocIndex, 5).CellValue = indent & row("RVCode").ToString
          End If
          If IsNumeric(row("Sold")) Then
            m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(CDec(row("Sold")), DigitConfig.Price)
            tmpRemain += CDec(row("Sold"))
            tmpSold += CDec(row("Sold"))
            SumSold += CDec(row("Sold"))
          End If
          If IsNumeric(row("SaleSCN")) Then
            m_grid(currentDocIndex, 7).CellValue = Configuration.FormatToString(CDec(row("SaleSCN")), DigitConfig.Price)
            tmpRemain -= CDec(row("SaleSCN"))
            tmpSaleSCN += CDec(row("SaleSCN"))
            SumSaleSCN += CDec(row("SaleSCN"))
          End If
          If IsNumeric(row("ReceiveSelection")) Then
            m_grid(currentDocIndex, 8).CellValue = Configuration.FormatToString(CDec(row("ReceiveSelection")), DigitConfig.Price)
            tmpRemain -= CDec(row("ReceiveSelection"))
            tmpReceiveSelection += CDec(row("ReceiveSelection"))
            SumReceiveSelection += CDec(row("ReceiveSelection"))
          End If
          m_grid(currentDocIndex, 9).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
          If Not row.IsNull("CreditTerm") Then
            m_grid(currentDocIndex, 10).CellValue = Configuration.FormatToString(CInt(row("CreditTerm")), DigitConfig.Int)
          End If
          If Not row.IsNull("SoldRetention") Then
            m_grid(currentDocIndex, 11).CellValue = Configuration.FormatToString(CDec(row("SoldRetention")), DigitConfig.Price)
            tmpRetRemain += CDec(row("SoldRetention"))
            tmpRet += CDec(row("SoldRetention"))
            sumRet += CDec(row("SoldRetention"))
          End If
          If Not row.IsNull("ReceiveRetention") Then
            m_grid(currentDocIndex, 12).CellValue = Configuration.FormatToString(CDec(row("ReceiveRetention")), DigitConfig.Price)
            tmpRetRemain -= CDec(row("ReceiveRetention"))
            tmpReceiveRet += CDec(row("ReceiveRetention"))
            sumReceiveRet += CDec(row("ReceiveRetention"))
          End If
          m_grid(currentDocIndex, 13).CellValue = Configuration.FormatToString(tmpRetRemain, DigitConfig.Price)
          If Not row.IsNull("Cash") Then
            m_grid(currentDocIndex, 14).CellValue = Configuration.FormatToString(CDec(row("Cash")), DigitConfig.Price)
          End If
          If Not row.IsNull("Check") Then
            m_grid(currentDocIndex, 15).CellValue = Configuration.FormatToString(CDec(row("Check")), DigitConfig.Price)
          End If
          If Not row.IsNull("Advance") Then
            m_grid(currentDocIndex, 16).CellValue = Configuration.FormatToString(CDec(row("Advance")), DigitConfig.Price)
          End If

          If Not row.IsNull("interest") Then
            m_grid(currentDocIndex, 17).CellValue = Configuration.FormatToString(CDec(row("interest")), DigitConfig.Price)
          End If
          If Not row.IsNull("Revenue") Then
            m_grid(currentDocIndex, 18).CellValue = Configuration.FormatToString(CDec(row("Revenue")), DigitConfig.Price)
          End If
          If Not row.IsNull("discount") Then
            m_grid(currentDocIndex, 19).CellValue = Configuration.FormatToString(CDec(row("discount")), DigitConfig.Price)
          End If
          If Not row.IsNull("witholdingtax") Then
            m_grid(currentDocIndex, 20).CellValue = Configuration.FormatToString(CDec(row("witholdingtax")), DigitConfig.Price)
            'tmpRemain = tmpRemain - CDec(row("witholdingtax"))
            SumWHT = CDec(row("witholdingtax"))
            'm_grid(currentDocIndex, 9).CellValue = Configuration.FormatToString(tmpRemain, DigitConfig.Price)
          End If
          If Not row.IsNull("Expend") Then
            m_grid(currentDocIndex, 21).CellValue = Configuration.FormatToString(CDec(row("Expend")), DigitConfig.Price)
          End If
          If Not row.IsNull("note") Then
            m_grid(currentDocIndex, 22).CellValue = CStr(row("note"))
          End If

          currentDocCode = row("DocCode").ToString
        End If

        If Not row.IsNull("refDocCode") Then
          m_grid.RowCount += 1
          currentDocIndex = m_grid.RowCount
          m_grid.RowStyles(currentDocIndex).ReadOnly = True
          If Not row.IsNull("RefDocCode") Then
            m_grid(currentDocIndex, 3).CellValue = indent & indent & row("RefDocCode").ToString
          End If
          If Not row.IsNull("RefDocDate") Then
            If IsDate(row("RefDocDate")) Then
              m_grid(currentDocIndex, 4).CellValue = indent & indent & CDate(row("RefDocDate")).ToShortDateString
            End If
          End If
          If Not row.IsNull("ReceiveAmount") Then
            m_grid(currentDocIndex, 5).CellValue = Configuration.FormatToString(CDec(row("ReceiveAmount")), DigitConfig.Price)
            m_grid(currentDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
          End If
          If Not row.IsNull("checkCode") Then
            m_grid(currentDocIndex, 15).CellValue = indent & row("checkCode").ToString
            m_grid(currentDocIndex, 15).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
          End If
          If Not row.IsNull("checkDueDate") Then
            If IsDate(row("checkDueDate")) Then
              m_grid(currentDocIndex, 16).CellValue = indent & CDate(row("checkDueDate")).ToShortDateString
              m_grid(currentDocIndex, 16).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
            End If
          End If
          If Not row.IsNull("BankAccount") Then
            m_grid(currentDocIndex, 17).CellValue = indent & row("BankAccount").ToString
            m_grid(currentDocIndex, 17).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
          End If
          If Not row.IsNull("CheckStatus") Then
            m_grid(currentDocIndex, 18).CellValue = indent & row("CheckStatus").ToString
            m_grid(currentDocIndex, 18).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Left
          End If
        End If
      Next

			If dt2.Rows.Count > 0 Then
				'ǧ�Թ�ôԵ�������
				m_grid(currentCustomerIndex, 4).CellValue = Configuration.FormatToString(LastCustomerCrAmtRecord - tmpRemain, DigitConfig.Price)
				m_grid(currentCustomerIndex, 4).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
				m_grid.RowCount += 1
				currentDocIndex = m_grid.RowCount
				m_grid.RowStyles(currentDocIndex).BackColor = Color.Khaki
				m_grid.RowStyles(currentDocIndex).ReadOnly = True
				m_grid(currentDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Total}")				'"����Թ"
				m_grid(currentDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
				m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(tmpSold, DigitConfig.Price)
				m_grid(currentDocIndex, 7).CellValue = Configuration.FormatToString(tmpSaleSCN, DigitConfig.Price)
				m_grid(currentDocIndex, 8).CellValue = Configuration.FormatToString(tmpReceiveSelection, DigitConfig.Price)
				m_grid(currentDocIndex, 11).CellValue = Configuration.FormatToString(tmpRet, DigitConfig.Price)
				m_grid(currentDocIndex, 12).CellValue = Configuration.FormatToString(tmpReceiveRet, DigitConfig.Price)

				m_grid.RowCount += 1
				currentDocIndex = m_grid.RowCount
				m_grid.RowStyles(currentDocIndex).BackColor = Color.FromArgb(128, 255, 128)
				m_grid.RowStyles(currentDocIndex).Font.Bold = True
				m_grid.RowStyles(currentDocIndex).ReadOnly = True

				m_grid(currentDocIndex, 3).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.PrTotal}")				'"����١˹��(���)"
				m_grid(currentDocIndex, 5).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.OpeningBalance}")		 '"�ʹ¡��"
				m_grid(currentDocIndex, 6).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Sold}")				 '"�������"
				m_grid(currentDocIndex, 7).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.SaleSCN}")				 '"Ŵ˹��"
				m_grid(currentDocIndex, 8).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.Receive}")				'"�Ѻ����˹��"
				m_grid(currentDocIndex, 9).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Status}")				 '"�������"
				m_grid(currentDocIndex, 11).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.MileStoneRetention}")				 '"�١�ѡ"
				m_grid(currentDocIndex, 12).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.ReceiveRetention}")				 '"�Ѻ�׹"
				m_grid(currentDocIndex, 13).CellValue = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.RptAR.Status}")				 '"�������"
				m_grid(currentDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
				m_grid(currentDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right

				m_grid.RowCount += 1
				currentDocIndex = m_grid.RowCount
				m_grid.RowStyles(currentDocIndex).BackColor = Color.FromArgb(128, 255, 128)
				m_grid.RowStyles(currentDocIndex).Font.Bold = True
				m_grid.RowStyles(currentDocIndex).ReadOnly = True
				m_grid(currentDocIndex, 3).CellValue = SumCustomer
				m_grid(currentDocIndex, 5).CellValue = Configuration.FormatToString(SumOpnBalance, DigitConfig.Price)
				m_grid(currentDocIndex, 6).CellValue = Configuration.FormatToString(SumSold, DigitConfig.Price)
				m_grid(currentDocIndex, 7).CellValue = Configuration.FormatToString(SumSaleSCN, DigitConfig.Price)
				m_grid(currentDocIndex, 8).CellValue = Configuration.FormatToString(SumReceiveSelection, DigitConfig.Price)
        m_grid(currentDocIndex, 9).CellValue = Configuration.FormatToString(SumOpnBalance + SumSold - SumSaleSCN - SumReceiveSelection, DigitConfig.Price)

				m_grid(currentDocIndex, 11).CellValue = Configuration.FormatToString(sumRet, DigitConfig.Price)
				m_grid(currentDocIndex, 12).CellValue = Configuration.FormatToString(sumReceiveRet, DigitConfig.Price)
				m_grid(currentDocIndex, 13).CellValue = Configuration.FormatToString(SumRetOpnBalance + sumRet - sumReceiveRet, DigitConfig.Price)

				m_grid(currentDocIndex, 3).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
				m_grid(currentDocIndex, 5).HorizontalAlignment = Syncfusion.Windows.Forms.Grid.GridHorizontalAlignment.Right
			End If
		End Sub

#End Region#Region "Shared"
#End Region#Region "Properties"		Public Overrides ReadOnly Property ClassName() As String
			Get
				Return "RptAREnumerate"
			End Get
		End Property
		Public Overrides ReadOnly Property DetailPanelTitle() As String
			Get
				Return "${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.DetailLabel}"
			End Get
		End Property
		Public Overrides ReadOnly Property DetailPanelIcon() As String
			Get
				Return "Icons.16x16.RptAREnumerate"
			End Get
		End Property
		Public Overrides ReadOnly Property ListPanelIcon() As String
			Get
				Return "Icons.16x16.RptAREnumerate"
			End Get
		End Property
		Public Overrides ReadOnly Property ListPanelTitle() As String
			Get
				Return "${res:Longkong.Pojjaman.BusinessLogic.RptAREnumerate.ListLabel}"
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
			Return "RptAREnumerate"
		End Function
		Public Overrides Function GetDefaultForm() As String
			Return "RptAREnumerate"
		End Function
		Public Overrides Function GetDocPrintingEntries() As DocPrintingItemCollection
			Dim dpiColl As New DocPrintingItemCollection
			Dim dpi As DocPrintingItem

			For Each fixDpi As DocPrintingItem In Me.FixValueCollection
				dpiColl.Add(fixDpi)
			Next

			Dim n As Integer = 0
			For rowIndex As Integer = 3 To m_grid.RowCount
				For colindex As Integer = 1 To m_grid.ColCount
					dpi = New DocPrintingItem
					dpi.Mapping = "col" & (colindex - 1).ToString
					dpi.Value = m_grid(rowIndex, colindex).CellValue
					dpi.DataType = "System.String"
					dpi.Row = n + 1
					dpi.Table = "Item"
					dpiColl.Add(dpi)
				Next

				n += 1
			Next

			Return dpiColl
		End Function
#End Region
	End Class
End Namespace

