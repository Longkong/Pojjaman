﻿Imports Telerik.WinControls.UI
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Collections.Generic
Imports Longkong.Pojjaman.Services

Public Class PaymentList

#Region "Properties"
  Private Property docDateStart As Date
  Private Property docDateEnd As Date
  Property Supplier As Supplier
  Property BankAcct As BankAccount
#End Region

#Region "Methods"
  Public Sub SetSupplier(ByVal s As Supplier)
    If Not s Is Nothing AndAlso s.Originated Then
      Me.Supplier = s
    Else
      Me.Supplier = New Supplier
    End If
    Me.txtSupplierCode.Text = Me.Supplier.Code
    Me.txtSupplierName.Text = Me.Supplier.Name
  End Sub
  Public Sub SetBankAccount(ByVal b As BankAccount)
    If Not b Is Nothing AndAlso b.Originated Then
      Me.BankAcct = b
    Else
      Me.BankAcct = New BankAccount
    End If
    Me.txtBankAccountCode.Text = Me.BankAcct.Code
    Me.txtBankAccountName.Text = Me.BankAcct.Name
  End Sub
  Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
    RefreshItems()
  End Sub
  Private Sub txtSupplierCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtSupplierCode.Validated
    Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.Supplier)
  End Sub
  Private Sub btnSupplierFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSupplierFind.Click
    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    myEntityPanelService.OpenListDialog(New Customer, AddressOf SetSupplier)
  End Sub
  Private Sub SetSupplier(ByVal e As ISimpleEntity)
    Me.txtSupplierCode.Text = e.Code
    Supplier.GetSupplier(txtSupplierCode, txtSupplierName, Me.Supplier)
  End Sub

  Private Sub txtBankAccountCode_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBankAccountCode.Validated
    BankAccount.GetBankAccount(txtBankAccountCode, txtBankAccountName, Me.BankAcct)
  End Sub

  Private Sub btnBankAccountFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBankAccountFind.Click
    Dim myEntityPanelService As IEntityPanelService = CType(ServiceManager.Services.GetService(GetType(IEntityPanelService)), IEntityPanelService)
    myEntityPanelService.OpenListDialog(New BankAccount, AddressOf SetBankAccountDialog)
  End Sub

  Private Sub SetBankAccountDialog(ByVal e As ISimpleEntity)
    Me.txtBankAccountCode.Text = e.Code
    BankAccount.GetBankAccount(txtBankAccountCode, txtBankAccountName, Me.BankAcct)
  End Sub

  Private Sub PaymentList_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    Me.RadGridView1.MasterGridViewTemplate.AllowAddNewRow = False
    Me.RadGridView2.MasterGridViewTemplate.AllowAddNewRow = False
    Me.RadGridView2.MasterGridViewTemplate.AllowDragToGroup = False
    GetColumns(RadGridView1, True)
    GetColumns(RadGridView2, False)
    RefreshItems()

    ClearCriterias()

    AddHandler txtDocDateStart.Validated, AddressOf Me.ChangeProperty
    AddHandler dtpDocDateStart.ValueChanged, AddressOf Me.ChangeProperty
    AddHandler txtDocDateEnd.Validated, AddressOf Me.ChangeProperty
    AddHandler dtpDocDateEnd.ValueChanged, AddressOf Me.ChangeProperty

  End Sub

  Private Sub ClearCriterias()
    If Me.Supplier Is Nothing Then
      Me.Supplier = New Supplier
    End If

    If Me.BankAcct Is Nothing Then
      Me.BankAcct = New BankAccount
    End If

    Me.txtPVCode.Text = ""

    Me.dtpDocDateStart.Value = DateAdd(DateInterval.Day, -7, Now.Date)
    Me.dtpDocDateEnd.Value = DateAdd(DateInterval.Day, 0, Now.Date)

    Me.txtDocDateStart.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, -7, Now.Date), "")
    Me.txtDocDateEnd.Text = Me.MinDateToNull(DateAdd(DateInterval.Day, 0, Now.Date), "")

    Me.docDateStart = DateAdd(DateInterval.Day, -7, Now.Date)
    Me.docDateEnd = DateAdd(DateInterval.Day, 0, Now.Date)

  End Sub

  Public Sub PopulateRow(ByVal p As PaymentForList, ByVal tr As GridViewDataRowInfo)
    If tr Is Nothing Then
      Return
    End If

    If tr.ViewTemplate.Columns.Contains("SelectedForDeleted") Then
      tr.Cells("SelectedForDeleted").Value = p.SelectedForDeleted
    End If
    If tr.ViewTemplate.Columns.Contains("Selected") Then
      tr.Cells("Selected").Value = p.Selected
    End If
    tr.Cells("PaymentCode").Value = p.Code
    tr.Cells("RefCode").Value = p.RefCode
    tr.Cells("RefType").Value = p.RefType
    tr.Cells("RefDueDate").Value = p.RefDueDate.ToShortDateString
    tr.Cells("BankAccount").Value = p.bankacct
    tr.Cells("Amount").Value = Configuration.FormatToString(p.RefAmount, DigitConfig.Price)
    tr.Cells("Remain").Value = Configuration.FormatToString(p.RefRemain, DigitConfig.Price)

    tr.Tag = p

  End Sub
  Private m_type As Integer = -1
  Public Sub SetType(ByVal t As Integer)
    m_type = t
  End Sub

#End Region
 

  
  Private m_dateSetting As Boolean
  Public Sub ChangeProperty(ByVal sender As Object, ByVal e As EventArgs)
    Dim dirtyFlag As Boolean = False
    Select Case CType(sender, Control).Name.ToLower
      Case "dtpdocdatestart"
        If Not Me.docDateStart.Equals(dtpDocDateStart.Value) Then
          If Not m_dateSetting Then
            Me.txtDocDateStart.Text = MinDateToNull(dtpDocDateStart.Value, "")
            Me.docDateStart = dtpDocDateStart.Value
          End If
          dirtyFlag = True
        End If
      Case "txtdocdatestart"
        m_dateSetting = True
        If Me.txtDocDateStart.Text.Length <> 0 AndAlso IsDate(Me.txtDocDateStart.Text) = "" Then
          Dim theDate As Date = CDate(Me.txtDocDateStart.Text)
          If Not Me.docDateStart.Equals(theDate) Then
            dtpDocDateStart.Value = theDate
            Me.docDateStart = dtpDocDateStart.Value
            dirtyFlag = True
          End If
        Else
          Me.dtpDocDateStart.Value = Date.Now
          Me.docDateStart = Date.MinValue
          dirtyFlag = True
        End If
        m_dateSetting = False
      Case "dtpdocdateend"
        If Not Me.docDateEnd.Equals(dtpDocDateEnd.Value) Then
          If Not m_dateSetting Then
            Me.txtDocDateEnd.Text = MinDateToNull(dtpDocDateEnd.Value, "")
            Me.docDateEnd = dtpDocDateEnd.Value
          End If
          dirtyFlag = True
        End If
      Case "txtdocdateend"
        m_dateSetting = True
        If Me.txtDocDateEnd.Text.Length <> 0 AndAlso IsDate(Me.txtDocDateEnd.Text) Then
          Dim theDate As Date = CDate(Me.txtDocDateEnd.Text)
          If Not Me.docDateEnd.Equals(theDate) Then
            dtpDocDateEnd.Value = theDate
            Me.docDateEnd = dtpDocDateEnd.Value
            dirtyFlag = True
          End If
        Else
          Me.dtpDocDateEnd.Value = Date.Now
          Me.docDateEnd = Date.MinValue
          dirtyFlag = True
        End If
        m_dateSetting = False
    End Select
  End Sub
  
  Private m_tableInitialized As Boolean = False
  Private m_updating As Boolean = False

  Private Sub RadGridView1_CellDoubleClick(ByVal sender As Object, ByVal e As Telerik.WinControls.UI.GridViewCellEventArgs) Handles RadGridView1.CellDoubleClick
    If e.ColumnIndex = 1 Then
      If e.RowIndex = -1 Then
        ToggleSelectAll()
      End If
    End If
  End Sub
  Private m_allSelected As Boolean = False
  Private Sub ToggleSelectAll()
    m_allSelected = Not m_allSelected
    For Each row As GridViewDataRowInfo In RadGridView1.Rows
      row.Cells("Selected").Value = m_allSelected
      CType(row.Tag, PaymentForList).Selected = m_allSelected
    Next
  End Sub
  Private Sub RadGridView1_CellValidating(ByVal sender As Object, ByVal e As CellValidatingEventArgs) Handles RadGridView1.CellValidating
    Dim column As GridViewDataColumn = TryCast(e.Column, GridViewDataColumn)
    If e.Row Is Nothing Then
      Return
    End If
    If Not TypeOf e.Row Is GridViewDataRowInfo OrElse column Is Nothing Then
      Return
    End If
    If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
      Return
    End If
    If Not Me.m_tableInitialized Then
      Return
    End If
    Dim p As PaymentForList = CType(e.Row.Tag, PaymentForList)
    If m_updating Then
      Return
    End If
    m_updating = True
    If Not e.Value Is Nothing Then
      Select Case column.FieldName.ToLower
        Case "selected"
          p.Selected = e.Value
        Case Else
      End Select
    End If
    m_updating = False
  End Sub
  Private m_tableInitialized2 As Boolean = False
  Private m_updating2 As Boolean = False
  Private Sub RadGridView2_CellValidating(ByVal sender As Object, ByVal e As CellValidatingEventArgs) Handles RadGridView2.CellValidating
    Dim column As GridViewDataColumn = TryCast(e.Column, GridViewDataColumn)
    If e.Row Is Nothing Then
      Return
    End If
    If Not TypeOf e.Row Is GridViewDataRowInfo OrElse column Is Nothing Then
      Return
    End If
    If e.RowIndex < 0 OrElse e.ColumnIndex < 0 Then
      Return
    End If
    If Not Me.m_tableInitialized2 Then
      Return
    End If
    Dim p As PaymentForList = CType(e.Row.Tag, PaymentForList)
    If m_updating2 Then
      Return
    End If
    m_updating2 = True
    If Not e.Value Is Nothing Then
      Select Case column.FieldName.ToLower
        Case "selectedfordeleted"
          p.SelectedForDeleted = e.Value
        Case Else
      End Select
    End If
    m_updating2 = False
  End Sub
  Private Function GetFilterArray() As Filter()
    Dim arr(5) As Filter
    arr(0) = New Filter("supplier_id", Supplier.ValidIdOrDBNull(Supplier))
    arr(1) = New Filter("startdate", ValidDateOrDBNull(docDateStart))
    arr(2) = New Filter("enddate", ValidDateOrDBNull(docDateEnd))
    arr(3) = New Filter("type", m_type)
    arr(4) = New Filter("bankacct_id", BankAccount.ValidIdOrDBNull(BankAcct))
    arr(5) = New Filter("pvcode", txtPVCode.Text)
    Return arr
  End Function
  Private Function ValidDateOrDBNull(ByVal myDate As Date) As Object
    If myDate.Equals(Date.MinValue) Then
      Return DBNull.Value
    End If
    Return myDate
  End Function
  Private Function MinDateToNull(ByVal dt As Date, ByVal nullString As String) As String
    If dt.Equals(Date.MinValue) Then
      Return nullString
    End If
    Return dt.ToShortDateString
  End Function
  Private m_currentList As List(Of PaymentForList)
  Private Sub RefreshItems()
    m_tableInitialized = False
    Me.RadGridView1.GridElement.BeginUpdate()
    Me.RadGridView1.Rows.Clear()
    m_currentList = PaymentForList.GetPaymentList(GetFilterArray())
    For Each p As PaymentForList In m_currentList
      Dim row As GridViewDataRowInfo = Me.RadGridView1.Rows.AddNew()
      PopulateRow(p, row)
    Next
    Dim i As Integer = 1
    For Each row As GridViewDataRowInfo In Me.RadGridView1.Rows
      row.Cells("Linenumber").Value = i
      i += 1
    Next
    Me.RadGridView1.GridElement.EndUpdate(True)
    m_tableInitialized = True
  End Sub
  Dim viewDef As ColumnGroupsViewDefinition
  Private Sub GetColumns(ByVal grid As RadGridView, ByVal istop As Boolean)

    viewDef = New ColumnGroupsViewDefinition
    Dim colNum As Integer = 0
    Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
    Dim gcLineNumber As New GridViewDecimalColumn("Linenumber")
    gcLineNumber.HeaderText = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.LineNumberHeaderText}")
    gcLineNumber.Width = 45
    gcLineNumber.ReadOnly = True
    gcLineNumber.DecimalPlaces = 0
    gcLineNumber.TextAlignment = ContentAlignment.MiddleCenter
    grid.Columns.Add(gcLineNumber)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcLineNumber)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim colName As String
    If istop Then
      colName = "Selected"
    Else
      colName = "SelectedForDeleted"
    End If
    Dim gcSelected As New GridViewCheckBoxColumn(colName)
    gcSelected.HeaderText = "" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
    gcSelected.Width = 30
    gcSelected.ReadOnly = False
    gcSelected.AllowSort = False
    grid.Columns.Add(gcSelected)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcSelected)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcPaymentCode As New GridViewTextBoxColumn("PaymentCode")
    gcPaymentCode.HeaderText = "เลขที่ PV" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.CBSHeaderText}")
    gcPaymentCode.Width = 100
    gcPaymentCode.ReadOnly = True
    grid.Columns.Add(gcPaymentCode)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcPaymentCode)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcRefCode As New GridViewTextBoxColumn("RefCode")
    gcRefCode.HeaderText = "เอกสารอ้างอิง" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
    gcRefCode.Width = 100
    gcRefCode.ReadOnly = True
    grid.Columns.Add(gcRefCode)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefCode)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcRefType As New GridViewTextBoxColumn("RefType")
    gcRefType.HeaderText = "ประเภท" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
    gcRefType.Width = 100
    gcRefType.ReadOnly = True
    grid.Columns.Add(gcRefType)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefType)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcRefDueDate As New GridViewTextBoxColumn("RefDueDate")
    gcRefDueDate.HeaderText = "วันที่ครบกำหนด" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
    gcRefDueDate.Width = 100
    gcRefDueDate.ReadOnly = True
    grid.Columns.Add(gcRefDueDate)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcRefDueDate)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim gcBankAccount As New GridViewTextBoxColumn("BankAccount")
    gcBankAccount.HeaderText = "บัญชีธนาคาร" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.DescriptionHeaderText}")
    gcBankAccount.Width = 150
    gcBankAccount.ReadOnly = True
    grid.Columns.Add(gcBankAccount)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(gcBankAccount)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim csAmount As New GridViewTextBoxColumn("Amount")
    csAmount.HeaderText = "จำนวนเงินที่ต้องจ่าย" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.AmountHeaderText}")
    csAmount.Width = 150
    csAmount.TextAlignment = ContentAlignment.MiddleRight
    csAmount.ReadOnly = True
    grid.Columns.Add(csAmount)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csAmount)
    viewDef.ColumnGroups(colNum).IsPinned = True
    colNum += 1

    Dim csRemain As New GridViewTextBoxColumn("Remain")
    csRemain.HeaderText = "คงเหลือ" 'myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.ItemListing.BudgetHeaderText}")
    csRemain.ReadOnly = True
    csRemain.Width = 150
    csRemain.TextAlignment = ContentAlignment.MiddleRight
    csRemain.ReadOnly = True
    grid.Columns.Add(csRemain)
    viewDef.ColumnGroups.Add(New GridViewColumnGroup)
    viewDef.ColumnGroups(colNum).Rows.Add(New GridViewColumnGroupRow())
    viewDef.ColumnGroups(colNum).Rows(0).Columns.Add(csRemain)
    viewDef.ColumnGroups(colNum).IsPinned = True

  End Sub
  Private Sub RefreshSelectedItems()
    m_tableInitialized2 = False
    Me.RadGridView2.GridElement.BeginUpdate()
    Me.RadGridView2.Rows.Clear()
    For Each p As PaymentForList In m_selected
      Dim row As GridViewDataRowInfo = Me.RadGridView2.Rows.AddNew()
      PopulateRow(p, row)
    Next
    Dim i As Integer = 1
    For Each row As GridViewDataRowInfo In Me.RadGridView2.Rows
      row.Cells("Linenumber").Value = i
      i += 1
    Next
    Me.RadGridView2.GridElement.EndUpdate(True)
    m_tableInitialized2 = True
  End Sub
  Private m_selected As New List(Of PaymentForList)
  Public ReadOnly Property Selected As List(Of PaymentForList)
    Get
      Return m_selected
    End Get
  End Property

  Private Sub ibtnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnAdd.Click
    For Each p As PaymentForList In m_currentList
      If p.Selected AndAlso Not m_selected.Contains(p) Then
        m_selected.Add(p)
      End If
    Next
    RefreshSelectedItems()
  End Sub
  Private Sub ibtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnDelete.Click
    Dim deleted As New List(Of PaymentForList)
    For Each p As PaymentForList In m_selected
      If p.SelectedForDeleted Then
        deleted.Add(p)
      End If
    Next
    For Each p As PaymentForList In deleted
      p.SelectedForDeleted = False
      m_selected.Remove(p)
    Next
    RefreshSelectedItems()
  End Sub
  Private Sub ibtnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ibtnClear.Click
    Me.DialogResult = Windows.Forms.DialogResult.OK
    Me.Close()
  End Sub
 

 
End Class