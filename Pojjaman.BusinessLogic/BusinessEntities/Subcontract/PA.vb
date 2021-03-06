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
  Public Class PAStatus
    Inherits CodeDescription

#Region "Constructors"
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region "Properties"
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "pa_status"
      End Get
    End Property
#End Region
  End Class
  Public Class PA
    Inherits SimpleBusinessEntityBase
    Implements IGLAble, IPrintableEntity, ICancelable, IDuplicable, ICheckPeriod, IAdvancePayItemAble, IHasIBillablePerson, IVatable, IWitholdingTaxable _
     , IBillAcceptable, IWBSAllocatable, IApprovAble, ICanDelayWHT, IGLCheckingBeforeRefresh, IHasToCostCenter, INewGLAble _
     , ICloseStatusAble, IApproveStatusAble, IShowStatusColorAble, IDocStatus, INewPrintableEntity, IDocumentPersonAble

#Region "Members"
    '**************
    Private m_docDate As Date
    Private m_olddocDate As Date
    Private m_sc As SC
    'Private m_Supplier As Supplier
    Private m_receiver As Employee
    Private m_note As String
    Private m_taxType As TaxType
    Private m_taxRate As Decimal

    Private m_vat As Vat
    Private m_whtcol As WitholdingTaxCollection
    Private m_payment As Payment
    Private m_je As JournalEntry

    Private m_creditPeriod As Long
    Private m_taxbase As Decimal
    Private m_aftertax As Decimal
    Private m_beforetax As Decimal
    Private m_gross As Decimal
    Private m_status As PAStatus
    Private m_discount As Discount
    Private m_advmoney As Decimal
    Private m_taxAmount As Decimal
    Private m_contactPerson As String
    Private m_otherdoccode As String
    Private m_otherdocdate As Date

    'Private m_witholdingTax As Decimal

    Private m_realTaxBase As Decimal
    Private m_realGross As Decimal
    Private m_realTaxAmount As Decimal
    Private m_closed As Boolean

    Private m_approvePerson As User
    Private m_approveDate As DateTime

    Private m_itemCollection As PAItemCollection
    Private m_hashWbsId As Hashtable

    Private m_advancePayToDoc As Decimal
    Private m_advancePayRemaining As Decimal
    Private m_retentionRemaining As Decimal
    Private m_retentionToDoc As Decimal
    Private m_retention As Decimal
    Private m_customNoteColl As CustomNoteCollection
    Private m_advancePayItemColl As AdvancePayItemCollection
    Private m_costcenter As CostCenter

    Private m_OldadvancePayItemColl As AdvancePayItemCollection
    Private m_approveDocColl As ApproveDocCollection
    Private m_oldActualDataSet As DataSet
    'Public MatActualHash As Hashtable
    'Public LabActualHash As Hashtable
    'Public EQActualHash As Hashtable
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
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
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
        .m_costcenter = New CostCenter
        .m_otherdoccode = ""
        .m_otherdocdate = Now.Date
        .m_sc = New SC
        .m_sc.SubContractor = New Supplier
        .m_sc.CostCenter = New CostCenter
        .m_receiver = New Employee
        .m_note = ""
        .m_taxType = New TaxType(CInt(Configuration.GetConfig("CompanyTaxType")))
        .m_taxRate = CDec(Configuration.GetConfig("CompanyTaxRate"))
        .m_contactPerson = ""

        '------- Tab Entities -----------------------------------------------------------
        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 1

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)

        .m_payment = New Payment(Me)
        .m_payment.DocDate = Me.m_docDate

        .m_je = New JournalEntry(Me)
        .m_je.DocDate = Me.m_docDate

        .m_advancePayItemColl = New AdvancePayItemCollection(Me)
        '------- End Tab Entities -------------------------------------------------------

        .m_taxbase = 0
        .m_aftertax = 0
        .m_beforetax = 0
        .m_gross = 0
        .m_status = New PAStatus(-1)
        .m_discount = New Discount("")
        .m_advmoney = 0
        .m_taxAmount = 0
        .m_creditPeriod = 0

        .m_realGross = 0
        .m_realTaxAmount = 0
        .m_realTaxBase = 0
        .AutoCodeFormat = New AutoCodeFormat(Me)
      End With
      m_itemCollection = New PAItemCollection(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
      m_hashWbsId = New Hashtable
      m_oldActualDataSet = New DataSet
      OnGlChanged()
    End Sub
    '------------------------------------------ GetPAList------------------------------------------
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me
        'SC Info
        If dr.Table.Columns.Contains("pa_sc") Then
          If Not dr.IsNull("pa_sc") Then
            Dim drh As New DataRowHelper(dr)
            '.m_sc = New SC(CInt(dr("pa_sc")))
            .m_sc = New SC
            .m_sc.Id = drh.GetValue(Of Integer)("sc_id")
            .m_sc.Code = drh.GetValue(Of String)("sc_code")
            .m_sc.DocDate = drh.GetValue(Of Date)("sc_docdate")
            .m_sc.SubContractor = New Supplier(drh.GetValue(Of Integer)("sc_subcontractor"))
            .m_sc.CostCenter = CostCenter.GetCCMinDataById(drh.GetValue(Of Integer)("sc_cc"))
            .m_sc.CreditPeriod = drh.GetValue(Of Long)("sc_creditperiod")
            .m_sc.ContactPerson = drh.GetValue(Of String)("sc_contactperson")
            .m_sc.TaxType = New TaxType(drh.GetValue(Of Integer)("sc_taxtype"))
            .m_sc.AdvancePay = drh.GetValue(Of Decimal)("sc_advancepay")
            .m_sc.Retention = drh.GetValue(Of Decimal)("sc_retention")
            .m_sc.StartDate = drh.GetValue(Of Date)("sc_startdate")
            .m_sc.EndDate = drh.GetValue(Of Date)("sc_enddate")

            '.m_subcontractor = New Supplier(dr, "supplier.")
          End If
        End If
        If dr.Table.Columns.Contains("pa_docdate") AndAlso Not dr.IsNull("pa_docdate") Then
          If IsDate(dr("pa_docdate")) Then
            .m_docDate = CDate(dr("pa_docdate"))
            .m_olddocDate = CDate(dr("pa_docdate"))
          End If
          '.m_subcontractor = New Supplier(dr, "supplier.")
        End If
        If dr.Table.Columns.Contains("pa_otherdoccode") AndAlso Not dr.IsNull("pa_otherdoccode") Then
          .m_otherdoccode = CStr(dr("pa_otherdoccode"))
        End If
        If dr.Table.Columns.Contains("pa_otherdocdate") AndAlso Not dr.IsNull("pa_otherdocdate") Then
          If IsDate(dr("pa_otherdocdate")) Then
            .m_otherdocdate = CDate(dr("pa_otherdocdate"))
          End If
          '.m_subcontractor = New Supplier(dr, "supplier.")
        End If
        If dr.Table.Columns.Contains("pa_note") AndAlso Not dr.IsNull("pa_note") Then
          .m_note = CStr(dr("pa_note"))
        End If
        If dr.Table.Columns.Contains("pa_creditPeriod") AndAlso Not dr.IsNull("pa_creditPeriod") Then
          .m_creditPeriod = CLng(dr("pa_creditPeriod"))
        End If
        If Not dr.IsNull("pa_contactPerson") Then
          .m_contactPerson = CStr(dr("pa_contactPerson"))
        End If
        'If dr.Table.Columns.Contains("sc_id") Then
        '    If Not dr.IsNull("sc_id") Then
        '        .m_sc = New Sc
        '        .m_sc.Id = CInt(dr(aliasPrefix & "sc_id"))
        '        .m_sc.Code = CStr(dr(aliasPrefix & "sc_code"))
        '        '.m_sc.DocDate = CDate(dr(aliasPrefix & "sc_docdate"))
        '        'If dr.Table.Columns.Contains("scCode") AndAlso Not dr.IsNull("scCode") Then
        '        '    .m_prcode = CStr(dr(aliasPrefix & "scCode"))
        '        'End If
        '    End If
        'Else
        '    If Not dr.IsNull(aliasPrefix & "scCode") Then
        '        .m_sc = New Sc
        '        .m_sc.Code = CStr(dr(aliasPrefix & "scCode"))
        '    End If
        'End If
        ' Subcontract
        'If dr.Table.Columns.Contains("supplier.supplier_id") Then
        '    If Not dr.IsNull("supplier.supplier_id") Then
        '        .m_subcontractor = New Supplier(dr, "")
        '    End If
        'Else
        '    If Not dr.IsNull(aliasPrefix & "pa_subcontractor") Then
        '        .m_subcontractor = New Supplier(CInt(dr(aliasPrefix & "pa_subcontractor")))
        '    End If
        'End If
        ''Cost Center
        'If dr.Table.Columns.Contains("cc_id") Then
        '    If Not dr.IsNull("cc_id") Then
        '        .m_cc = New CostCenter(dr, "")
        '    End If
        'Else
        '    If Not dr.IsNull(aliasPrefix & "pa_cc") Then
        '        .m_cc = New CostCenter(CInt(dr(aliasPrefix & "pa_cc")))
        '    End If
        'End If
        'Employee
        If dr.Table.Columns.Contains("employee_id") Then
          If Not dr.IsNull("employee_id") Then
            .m_receiver = New Employee(dr, "")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "pa_receiver") Then
            .m_receiver = New Employee(CInt(dr(aliasPrefix & "pa_receiver")))
          End If
        End If
        ''Note
        ''TaxType()
        If dr.Table.Columns.Contains(aliasPrefix & "pa_taxtype") AndAlso Not dr.IsNull(aliasPrefix & "pa_taxtype") Then
          .m_taxType = New TaxType(CInt(dr(aliasPrefix & "pa_taxtype")))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pa_retentiontodate") AndAlso Not dr.IsNull(aliasPrefix & "pa_retentiontodate") Then
          .m_retentionToDoc = CDec(dr(aliasPrefix & "pa_retentiontodate"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pa_retention") AndAlso Not dr.IsNull(aliasPrefix & "pa_retention") Then
          .m_retention = CDec(dr(aliasPrefix & "pa_retention"))
        End If
        If dr.Table.Columns.Contains(aliasPrefix & "pa_advancepaytodate") AndAlso Not dr.IsNull(aliasPrefix & "pa_advancepaytodate") Then
          .m_advancePayToDoc = CDec(dr(aliasPrefix & "pa_advancepaytodate"))
        End If
        ''taxrate
        If Not dr.IsNull(aliasPrefix & "pa_taxrate") Then
          .m_taxRate = CDec(dr(aliasPrefix & "pa_taxrate"))
        End If
        '' Vat
        'If dr.Table.Columns.Contains(aliasPrefix & "pa_vat") _
        'AndAlso Not dr.IsNull(aliasPrefix & "pa_vat") Then
        '  .m_vat = CDec(dr(aliasPrefix & "pa_vat"))
        'End If

        ''--------------------REAL-------------------------
        '' Tax Base
        If dr.Table.Columns.Contains(aliasPrefix & "pa_taxbase") _
        AndAlso Not dr.IsNull(aliasPrefix & "pa_taxbase") Then
          .m_realTaxBase = CDec(dr(aliasPrefix & "pa_taxbase"))
        End If
        'Gross
        If Not dr.IsNull(aliasPrefix & "pa_gross") Then
          .m_gross = CDec(dr(aliasPrefix & "pa_gross"))
        End If
        ' Tax Amount
        If dr.Table.Columns.Contains(aliasPrefix & "pa_taxamt") _
        AndAlso Not dr.IsNull(aliasPrefix & "pa_taxamt") Then
          .m_realTaxAmount = CDec(dr(aliasPrefix & "pa_taxamt"))
        End If
        '--------------------END REAL-------------------------
        'Status
        If dr.Table.Columns.Contains(aliasPrefix & "pa_status") AndAlso Not dr.IsNull(aliasPrefix & "pa_status") Then
          .m_status = New PAStatus(CInt(dr(aliasPrefix & "pa_status")))
        End If
        'discrate
        If Not dr.IsNull(aliasPrefix & "pa_discrate") Then
          .m_discount = New Discount(CStr(dr(aliasPrefix & "pa_discrate")))
        End If

        ' ApprovePerson
        If dr.Table.Columns.Contains("approvePerson.user_id") Then
          If Not dr.IsNull("approvePerson.user_id") Then
            .m_approvePerson = New User(dr, "approvePerson.")
          End If
        Else
          If Not dr.IsNull(aliasPrefix & "pa_approvePerson") Then
            .m_approvePerson = New User(CInt(dr(aliasPrefix & "pa_approvePerson")))
          End If
        End If
        ' Approved Date
        If Not dr.IsNull(aliasPrefix & "pa_approveDate") Then
          .m_approveDate = CDate(dr(aliasPrefix & "pa_approveDate"))
        End If
        '------- Tab Entities -----------------------------------------------------------
        .m_vat = New Vat(Me)
        .m_vat.Direction.Value = 1

        .m_whtcol = New WitholdingTaxCollection(Me)
        .m_whtcol.Direction = New WitholdingTaxDirection(1)

        .m_payment = New Payment(Me)

        .m_je = New JournalEntry(Me)

        .m_advancePayItemColl = New AdvancePayItemCollection(Me.Id, Me.EntityId)
        .AutoCodeFormat = New AutoCodeFormat(Me)
        '------- End Tab Entities -------------------------------------------------------

        'SetPAAdvancePayAndRetention()

        'Dim ret As Decimal = Me.GetSCRetentionRemaining
        '.m_retentionRemaining = ret
        'Dim adv As Decimal = Me.GetSCAdvancePayRemaining
        'Me.m_advancePayRemaining = adv
      End With
      m_itemCollection = New PAItemCollection(Me)
      m_approveDocColl = New ApproveDocCollection(Me)
      m_oldActualDataSet = New DataSet
      m_hashWbsId = New Hashtable
      'm_itemCollection.RefreshBudget()
    End Sub
#End Region

#Region "Properties"
    Public Property ApproveDocColl As ApproveDocCollection
      Get
        Return m_approveDocColl
      End Get
      Set(ByVal value As ApproveDocCollection)
        '
      End Set
    End Property
    Public Property Sc() As SC      Get        Return m_sc      End Get      Set(ByVal Value As SC)        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)        If Value.Status.Value = 0 OrElse Value.Closed Then
          msgServ.ShowWarningFormatted("${res:Global.Error.CanceledSC}", New String() {Value.Code})
          Return
        End If        If Value.Id > 0 AndAlso Not Me.IsValidateReceiptAmoutFist(Value.Id) Then          msgServ.ShowWarningFormatted("${res:Global.Error.SCRemainEqualOrLessThenZero}", New String() {Value.Code})
          Return
        End If        OnGlChanged()
        m_sc = Value        Me.TaxRate = m_sc.TaxRate
        Me.TaxType = New TaxType(m_sc.TaxType.Value)        ChangeSC()      End Set    End Property
    Public Property SubContractor() As Supplier Implements IAdvancePayItemAble.Supplier, IWBSAllocatable.Supplier
      Get
        Return Me.Sc.SubContractor
      End Get
      Set(ByVal Value As Supplier)
        If Me.Sc.SubContractor Is Nothing Then
          Me.Sc.SubContractor = New Supplier
        End If
        Me.Sc.SubContractor = Value

        'If Me.m_po Is Nothing Then        '  Me.m_creditPeriod = Me.m_Supplier.CreditPeriod        '  Return
        'End If        'If Value.Id <> Me.m_po.Supplier.Id Then
        '  Me.m_creditPeriod = Me.m_Supplier.CreditPeriod
        '  Me.Po = New PO
        'End If

        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property DocDate() As Date Implements ICheckPeriod.DocDate, IGLAble.Date, IAdvancePayItemAble.DocDate, IVatable.Date, IWitholdingTaxable.Date _
                    , IPayable.Date, IWBSAllocatable.DocDate
      Get
        Return m_docDate
      End Get
      Set(ByVal Value As Date)
        If Me.m_je IsNot Nothing Then
          Me.m_je.DocDate = Value
        End If
        m_docDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public ReadOnly Property OldDocDate As Date Implements ICheckPeriod.OldDocDate
      Get
        Return m_olddocDate
      End Get
    End Property
    Public Property OtherDocCode As String
      Get
        Return m_otherdoccode
      End Get
      Set(ByVal value As String)
        m_otherdoccode = value
      End Set
    End Property
    Public Property OtherDocDate As Date
      Get
        Return m_otherdocdate
      End Get
      Set(ByVal value As Date)
        m_otherdocdate = value
      End Set
    End Property
    Public Property Receiver() As Employee
      Get
        Return m_receiver
      End Get
      Set(ByVal Value As Employee)
        m_receiver = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property ApprovePerson() As User
      Get
        Return m_approvePerson
      End Get
      Set(ByVal Value As User)
        m_approvePerson = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property ApproveDate() As DateTime
      Get
        Return m_approveDate
      End Get
      Set(ByVal Value As DateTime)
        m_approveDate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Note() As String Implements IGLAble.Note, IAdvancePayItemAble.Note, IPayable.Note      Get
        Return m_note
      End Get
      Set(ByVal Value As String)
        m_note = Value
        Me.Payment.Note = m_note
        Me.JournalEntry.Note = m_note
      End Set
    End Property
    Public Property CreditPeriod() As Long      Get        Return m_creditPeriod      End Get      Set(ByVal Value As Long)        m_creditPeriod = Value      End Set    End Property
    Public Property ContactPerson As String
      Get
        Return m_contactPerson
      End Get
      Set(ByVal value As String)
        m_contactPerson = value
      End Set
    End Property
    Public ReadOnly Property BeforeTax() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0 '"�����"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetExcludeVATAmount - Me.Retention
          Case 1 '"�¡"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetExcludeVATAmount - Me.Retention
          Case 2 '"���"
            Return Me.AfterTax - Me.RealTaxAmount '- Me.Retention
        End Select
      End Get
    End Property
    Public Property TaxRate() As Decimal
      Get
        Return m_taxRate
      End Get
      Set(ByVal Value As Decimal)
        OnGlChanged()
        m_taxRate = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property TaxBase() As Decimal Implements IVatable.TaxBase
      Get
        Return m_taxbase
      End Get
      Set(ByVal Value As Decimal)
        m_taxbase = Value
      End Set
    End Property
    Public ReadOnly Property TaxAmount() As Decimal
      Get
        Select Case Me.TaxType.Value
          Case 0     '"�����"
            Return 0
          Case 2     '��� VAT
            Return Me.TaxGross - Me.DiscountWithVat - Me.RealTaxBase - Me.AdvancePay
          Case Else     '1 �¡
            Return Configuration.Format((Me.TaxRate * Me.RealTaxBase) / 100, DigitConfig.Price)
        End Select
      End Get
    End Property
    Public ReadOnly Property TaxGross() As Decimal
      Get
        Return m_taxGross
      End Get
    End Property
    Public ReadOnly Property WitholdingTax() As Decimal      Get
        Dim whtAmount As Decimal = 0
        For Each whtitm As WitholdingTax In Me.WitholdingTaxCollection
          whtAmount += whtitm.Amount
        Next
        Return whtAmount
      End Get
    End Property
    Public ReadOnly Property AdvancePay() As Decimal      Get
        Dim advpAmount As Decimal = 0
        If Me.TaxType.Value = 0 OrElse Me.TaxType.Value = 1 Then
          advpAmount = Me.AdvancePayItemCollection.GetExcludeVATAmount
        Else
          advpAmount = Me.AdvancePayItemCollection.GetAmount
        End If
        Return advpAmount
      End Get
    End Property
    Public ReadOnly Property DiscountWithVat() As Decimal
      Get
        If Me.Gross = 0 Then
          Return 0
        End If
        Return Configuration.Format(Me.Discount.Amount * Me.TaxGross / Me.Gross, DigitConfig.Price)
      End Get
    End Property
    Public Property RetentionRemaining() As Decimal
      Get
        Return m_retentionRemaining
      End Get
      Set(ByVal Value As Decimal)
        OnGlChanged()
        m_retentionRemaining = Value
      End Set
    End Property
    Public Property RetentionToDoc() As Decimal
      Get
        Return m_retentionToDoc
      End Get
      Set(ByVal Value As Decimal)
        OnGlChanged()
        m_retentionToDoc = Value
      End Set
    End Property
    Public Property Retention() As Decimal      Get
        Return m_retention
      End Get
      Set(ByVal Value As Decimal)
        If Not IsNumeric(Value) Then
          Return
        End If
        'If Me.RetentionRemaining < Value Then
        '  Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        '  msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.BusinessLogic.PA.MissingRetention}", New String() {Configuration.FormatToString(Me.RetentionRemaining, DigitConfig.Price)})
        '  Return
        'End If
        OnGlChanged()
        m_retention = Value
      End Set
    End Property
    Public Property AdvancePayToDoc() As Decimal
      Get
        Return m_advancePayToDoc
      End Get
      Set(ByVal Value As Decimal)
        OnGlChanged()
        m_advancePayToDoc = Value
      End Set
    End Property
    Public Property AdvancePayRemaining() As Decimal
      Get
        Return m_advancePayRemaining
      End Get
      Set(ByVal Value As Decimal)
        m_advancePayRemaining = Value
      End Set
    End Property
    Public Property AdvancePayItemCollection() As AdvancePayItemCollection Implements IAdvancePayItemAble.AdvancePayItemCollection
      Get
        'Me.SetCurrentAdvancePay()

        'Dim advamt As Decimal = 0
        'If Me.TaxType.Value = 0 OrElse Me.TaxType.Value = 1 Then
        '  advamt = Me.AdvancePayItemCollection.GetExcludeVATAmount
        'Else
        '  advamt = Me.AdvancePayItemCollection.GetAmount
        'End If
        'If Me.m_advancePayRemaining < advamt Then
        '  Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
        '  Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
        '  msgServ.ShowMessageFormatted("${res:Longkong.Pojjaman.BusinessLogic.PA.MissingAdvancePay}", New String() {Configuration.FormatToString(Me.AdvancePayRemaining, DigitConfig.Price)})

        '  m_advancePayItemColl.Clear()
        '  For Each advp As AdvancePayItem In m_OldadvancePayItemColl
        '    m_advancePayItemColl.Add(advp)
        '  Next
        'End If

        Return m_advancePayItemColl
      End Get
      Set(ByVal Value As AdvancePayItemCollection)
        m_advancePayItemColl = Value
      End Set
    End Property
    Public ReadOnly Property DiscountAmount() As Decimal      Get        Me.Discount.AmountBeforeDiscount = Me.RealGross        Return Configuration.Format(Me.Discount.Amount, DigitConfig.Price)      End Get    End Property
    Public ReadOnly Property AfterTax() As Decimal Implements IApprovAble.AmountToApprove
      Get
        Select Case Me.TaxType.Value
          Case 0 '"�����"
            Return Me.BeforeTax
          Case 1 '"�¡"
            Return Me.BeforeTax + Me.RealTaxAmount
          Case 2 '"���"
            Return Me.RealGross - Me.DiscountAmount - Me.AdvancePayItemCollection.GetAmount - Me.Retention
        End Select
      End Get
    End Property
    Public ReadOnly Property Gross() As Decimal
      Get
        Return m_gross
      End Get
    End Property
    Public ReadOnly Property GrossWODR() As Decimal
      Get '
        Dim ret As Decimal
        For Each i As PAItem In Me.ItemCollection
          If i.RefDocType <> 291 AndAlso i.Level = 1 Then
            ret += i.Amount
          End If
        Next
        Return ret
      End Get
    End Property
    Public Overrides Property Status() As CodeDescription
      Get
        Return m_status
      End Get
      Set(ByVal Value As CodeDescription)
        m_status = CType(Value, PAStatus)
      End Set
    End Property
    Public Property Discount() As Discount
      Get
        Return m_discount
      End Get
      Set(ByVal Value As Discount)
        OnGlChanged()
        m_discount = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    Public Property Closed() As Boolean Implements ICloseStatusAble.Closed
      Get
        Return m_closed
      End Get
      Set(ByVal Value As Boolean)
        m_closed = Value
      End Set
    End Property
    Public Property ItemCollection() As PAItemCollection
      Get
        Return m_itemCollection
      End Get
      Set(ByVal Value As PAItemCollection)
        m_itemCollection = Value
      End Set
    End Property
    Public Property TaxType() As TaxType Implements IAdvancePayItemAble.TaxType
      Get
        Return m_taxType
      End Get
      Set(ByVal Value As TaxType)
        Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)


        If Not Me.Sc Is Nothing Then
          If Value.Value <> Me.Sc.TaxType.Value Then
            msgServ.ShowMessage("${res:Longkong.Pojjaman.Gui.Panels.SC.CanNotChangeVATType}")
            Return
          End If
        End If
        OnGlChanged()
        m_taxType = Value
        OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property
    '--------------------REAL-------------------------    Public Property RealTaxBase() As Decimal
      Get
        Return m_realTaxBase
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxBase = Value
        OnGlChanged()
      End Set
    End Property
    Public Property RealGross() As Decimal
      Get
        'HACK
        If m_realGross = 0 AndAlso m_gross <> 0 Then
          m_realGross = m_gross
        End If
        Return m_realGross
      End Get
      Set(ByVal Value As Decimal)
        m_realGross = Value
        OnGlChanged()
      End Set
    End Property
    Public ReadOnly Property RealGrossWithNoDeductItem As Decimal
      Get
        Dim realgross As Decimal = 0 'Me.RealGross
        'For Each itm As PAItem In Me.ItemCollection
        '  If itm.Level = 1 Then
        '    If itm.RefDocType = 290 AndAlso itm.Amount < 0 Then
        '      'realgross -= Math.Abs(itm.Amount)
        '    ElseIf itm.RefDocType = 291 Then
        '      'realgross -= Math.Abs(itm.Amount)
        '    Else
        '      realgross += itm.Amount
        '    End If
        '  End If
        'Next
        For Each itm As PAItem In Me.ItemCollection
          If itm.Level = 1 AndAlso itm.RefEntity.Id <> 291 Then
            realgross += itm.Amount
          End If
        Next
        Return realgross
      End Get
    End Property
    Public Property RealTaxAmount() As Decimal
      Get
        Return m_realTaxAmount
      End Get
      Set(ByVal Value As Decimal)
        m_realTaxAmount = Value
        OnGlChanged()
      End Set
    End Property    '--------------------REAL-------------------------

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "PA"
      End Get
    End Property
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "pa"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PA.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.PA"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.PA"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.PA.ListLabel}"
      End Get
    End Property

    Public Overrides ReadOnly Property TabPageText() As String
      Get
        Dim tpt As String = Me.StringParserService.Parse(Me.DetailPanelTitle) & " (" & Me.Code & ")"
        Dim blankSuffix As String = "()"
        If tpt.EndsWith(blankSuffix) Then
          tpt = tpt.Remove(tpt.Length - blankSuffix.Length, blankSuffix.Length)
        End If
        Return tpt
      End Get
    End Property
    Public Property CostCenter() As CostCenter Implements IWBSAllocatable.ToCostCenter, IHasToCostCenter.ToCC
      Get
        Return Me.Sc.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        If Me.Sc.CostCenter Is Nothing Then
          Me.Sc.CostCenter = New CostCenter
        End If
        Me.Sc.CostCenter = Value
        'OnPropertyChanged(Me, New PropertyChangedEventArgs)
      End Set
    End Property

#End Region

#Region "Shared"

    Public Shared Function GetSchemaTable() As TreeTable
      Dim myDatatable As New TreeTable("PA")

      myDatatable.Columns.Add(New DataColumn("pai_linenumber", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pai_level", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pai_paDesc", GetType(String))) '��������´
      myDatatable.Columns.Add(New DataColumn("pai_refDoc", GetType(String))) '��ҧ�ԧ
      myDatatable.Columns.Add(New DataColumn("pai_entity", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pai_entityType", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("pai_entityTypeDescription", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Code", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Button", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("EntityName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pai_itemName", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Unit", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pai_unit", GetType(Integer)))
      myDatatable.Columns.Add(New DataColumn("UnitButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("QtyCostAmount", GetType(String)))  '"����ҳ����ѭ��"
      myDatatable.Columns.Add(New DataColumn("CostAmount", GetType(String)))  '"��Ť�ҵ���ѭ��"
      myDatatable.Columns.Add(New DataColumn("Barrier1", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("ReceivedQty", GetType(String)))  '"�������ҳ�Ǵ��͹˹��"*************��ҡ��äӹǳ
      myDatatable.Columns.Add(New DataColumn("ReceivedAmount", GetType(String)))  '"�����Ť�ҧǴ��͹˹��" *************��ҡ��äӹǳ
      myDatatable.Columns.Add(New DataColumn("Barrier2", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pai_unitprice", GetType(String)))  '"��Ť�ҵ���ѭ��"
      myDatatable.Columns.Add(New DataColumn("pai_qty", GetType(String))) '"����ҳ"
      myDatatable.Columns.Add(New DataColumn("Amount", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Barrier3", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pai_mat", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pai_lab", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pai_eq", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pai_acct", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AccountCode", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("Account", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("AccountButton", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("pai_unvatable", GetType(Boolean)))
      myDatatable.Columns.Add(New DataColumn("pai_note", GetType(String)))
      myDatatable.Columns.Add(New DataColumn("isSummaryRow", GetType(String)))


      'myDatatable.Columns.Add(New DataColumn("PAAmount", GetType(String)))

      '��������ʴ� error ���������������ҷ���ͧ���
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      myDatatable.Columns("Code").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.CodeHeaderText}")
      myDatatable.Columns("pai_itemName").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.DescriptionHeaderText}")
      myDatatable.Columns("Unit").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.UnitHeaderText}")
      myDatatable.Columns("pai_qty").Caption = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PRPanelView.QtyHeaderText}")

      Return myDatatable
    End Function
    Public Shared Function GetPA(ByVal txtCode As TextBox, ByVal txtName As TextBox, ByRef oldPA As PA) As Boolean
      Dim newPa As New PA(txtCode.Text)
      If txtCode.Text.Length <> 0 AndAlso Not newPa.Valid Then
        MessageBox.Show(txtCode.Text & " �������к�")
        newPa = oldPA
      End If
      txtCode.Text = newPa.Code
      txtName.Text = ""
      If oldPA Is Nothing OrElse oldPA.Id <> newPa.Id Then
        oldPA = newPa
        Return True
      End If
      oldPA = newPa
      Return True
      Return False
    End Function
#End Region

#Region "Methods"
    Public Function GetOldPAWBSActual() As DataSet
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString,
                                                   CommandType.StoredProcedure,
                                                   "GetOldPAWBSActual",
                                                   New SqlParameter("@pa_id", Me.Id)
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
        " update swang_gr_wbsactual " & _
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
    Structure ContractReceiveStruct
      Dim SCContractAmount As Decimal
      Dim VOContractAmount As Decimal
      Dim SCReceivedAmount As Decimal
      Dim VOReceivedAmount As Decimal
    End Structure
    Public Function GetContractReceived() As ContractReceiveStruct
      Dim scr As New ContractReceiveStruct

      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetContractReceived", New SqlParameter("@sc_id", Me.Sc.Id))
      If ds.Tables.Count > 0 AndAlso ds.Tables(0).Rows.Count > 0 Then
        Dim drh As New DataRowHelper(ds.Tables(0).Rows(0))
        scr.SCContractAmount = drh.GetValue(Of Decimal)("sc_contract")
        scr.VOContractAmount = drh.GetValue(Of Decimal)("vo_contract")
        scr.SCReceivedAmount = drh.GetValue(Of Decimal)("sc_receievd")
        scr.VOReceivedAmount = drh.GetValue(Of Decimal)("vo_received")
      End If

      Return scr
    End Function
    Public Sub RefreshReceiveAmount()
      For Each itm As PAItem In Me.ItemCollection
        'itm.ReceiveAmount = itm.ReceiveAmount
        If Not itm.ItemType.Value = 162 AndAlso Not itm.ItemType.Value = 160 Then
          itm.RecalculateReceiveAmount()
        End If
      Next
    End Sub
    Public Sub RefreshApproveDocCollection() Implements IApproveStatusAble.RefreshApproveDocCollection
      m_approveDocColl = New ApproveDocCollection(Me)
    End Sub
    Public Function IsMeLastedPADoc() As Boolean
      If Not Me.Originated Then
        Return True
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetMaxPADoc" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 AndAlso Not ds.Tables(0).Rows(0).IsNull(0) Then
        If Me.Id < CInt(ds.Tables(0).Rows(0)(0)) Then
          Return False
        End If
      End If
      Return True
    End Function
    Public Function IshaveAdvancePayClosed() As Boolean
      Dim advpClosed As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetChkAdvancePayClosed" _
      , New SqlParameter("@pa_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        Dim row As DataRow = ds.Tables(0).Rows(0)
        Dim deh As New DataRowHelper(row)
        advpClosed = deh.GetValue(Of Decimal)("chkClosed")
      End If
      If advpClosed > 0 Then
        Return False
      Else
        Return True
      End If
    End Function
    Public Sub SetPAAdvancePayAndRetention()
      Dim sc_retention As Decimal
      Dim sc_advancepay As Decimal
      Dim vo_retention As Decimal
      Dim vo_advancepay As Decimal
      Dim pa_retention As Decimal
      Dim pa_advancepay As Decimal

      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetRetAdvpaySCVOPA" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      , New SqlParameter("@pa_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        Dim row As DataRow = ds.Tables(0).Rows(0)
        Dim deh As New DataRowHelper(row)
        sc_retention = deh.GetValue(Of Decimal)("sc_retention")
        sc_advancepay = deh.GetValue(Of Decimal)("sc_advancepay")
      End If
      If ds.Tables(1).Rows.Count <> 0 Then
        Dim row As DataRow = ds.Tables(1).Rows(0)
        Dim deh As New DataRowHelper(row)
        vo_retention = deh.GetValue(Of Decimal)("vo_retention")
        vo_advancepay = deh.GetValue(Of Decimal)("vo_advancepay")
      End If
      If ds.Tables(2).Rows.Count <> 0 Then
        Dim row As DataRow = ds.Tables(2).Rows(0)
        Dim deh As New DataRowHelper(row)
        pa_retention = deh.GetValue(Of Decimal)("pa_retention")
        pa_advancepay = deh.GetValue(Of Decimal)("pa_advancepay")
      End If

      '��������¡��� ������ʴ��Դź
      If sc_retention + vo_retention > pa_retention Then
        m_retention = (sc_retention + vo_retention) - pa_retention
        m_retentionRemaining = (sc_retention + vo_retention) - pa_retention
      Else
        m_retention = 0
        m_retentionRemaining = 0
      End If
      m_retentionToDoc = pa_retention
      If sc_advancepay + vo_advancepay < pa_advancepay Then
        m_advancePayRemaining = (sc_advancepay + vo_advancepay) - pa_advancepay
      Else
        m_advancePayRemaining = 0
      End If
      m_advancePayToDoc = pa_advancepay
    End Sub
    Public Function GetSCRetentionRemaining() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetSCRetentionRemaining" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      , New SqlParameter("@pa_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function
    Public Function GetSCAdvancePayRemaining() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetSCAdvancePayRemaining" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      , New SqlParameter("@pa_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function
    Public Function GetSCDistCountRemaining() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetSCDistCountRemaining" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      , New SqlParameter("@pa_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          If CDec(ds.Tables(0).Rows(0)(0)) <= 0 Then
            Return 0
          End If
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function
    Public Function GetContractDistCount() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetContractDistCount" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      , New SqlParameter("@pa_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          If CDec(ds.Tables(0).Rows(0)(0)) <= 0 Then
            Return 0
          End If
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function
    Public Function GetDistCountToDoc() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetDistCountToDoc" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      , New SqlParameter("@pa_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          If CDec(ds.Tables(0).Rows(0)(0)) <= 0 Then
            Return 0
          End If
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function
    Public Function GetSCVat() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetSCVat" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function
    Public Function GetSCVatOut() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetSCVatOut" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      , New SqlParameter("@pa_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function
    Public Function GetSCWhtOut() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetSCWhtOut" _
      , New SqlParameter("@sc_id", Me.Sc.Id) _
      , New SqlParameter("@pa_id", Me.Id) _
      )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function

    'Private Function Validate() As SaveErrorException
    '  ''����ѹ����͡��ù��¡����ѹ����͡����Ѻ�ҹ����ش������ѹ�֡
    '  Dim LastDate As DateTime = GetMaxPADocDate()
    '  If LastDate > Me.DocDate Then
    '    Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverDate}", New String() {Me.Sc.Code, LastDate.ToShortDateString})
    '  Else
    '    Return New SaveErrorException("0")
    '  End If
    'End Function

    Private Function ListWbsId() As String
      Dim idList As New ArrayList
      For Each itm As PAItem In Me.ItemCollection
        For Each iwbsd As WBSDistribute In itm.WBSDistributeCollection
          idList.Add(iwbsd.WBS.Id)
        Next
      Next
      If idList.Count > 0 Then
        Return String.Join(",", idList.ToArray)
      End If
    End Function
    Private Function ValidateOverBudget() As SaveErrorException
      Dim stringPar As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      If Me.CostCenter.Type.Value <> 2 Then
        Return New SaveErrorException("-1")
      End If
      If Me.CostCenter.Boq Is Nothing OrElse Me.CostCenter.Boq.Id = 0 Then
        Return New SaveErrorException("-1")
      End If

      'PROverBudgetOnlyCC
      Dim config As Object = Configuration.GetConfig("GROverBudgetOnlyCC")
      Dim onlyCC As Boolean = False
      If Not config Is Nothing Then
        onlyCC = CBool(config)
      End If

      'PROverBudgetOnlyWBSAllocate
      config = Configuration.GetConfig("GROverBudgetOnlyWBSAllocate")
      Dim onlyWBSAllocate As Boolean = False
      If Not config Is Nothing Then
        onlyWBSAllocate = CBool(config)
      End If

      '====================
      WBS.ParentBudgetHash = New Hashtable '��������索Ҵ
      '====================
      Dim idList As String = Me.ListWbsId
      Dim dsParentBudget As New DataSet
      dsParentBudget = WBS.GetParentsBudgetList(Me.EntityId, idList)
      Dim currwbsId As Integer
      Dim dt As New DataTable

      If Not onlyCC Then
        For Each item As PAItem In Me.ItemCollection
          If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 AndAlso item.ItemType.Value <> 289 Then
            Dim totalBudget As Decimal = 0
            Dim totalActual As Decimal = 0
            Dim totalCurrent As Decimal = 0
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              totalCurrent = (wbsd.Percent / 100) * item.Amount

              If onlyWBSAllocate Then
                If wbsd.OwnerBudgetAmount - totalCurrent < 0 Then
                  Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
                End If
              End If

              '����Ѻ WBS ����ѹ�ͧ =====>>
              If wbsd.BudgetRemain - totalCurrent < 0 Then
                Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
              End If
              '����Ѻ WBS ����ѹ�ͧ =====<<

              currwbsId = wbsd.WBS.Id
              Trace.WriteLine(dsParentBudget.Tables(0) Is Nothing)
              For Each drow As DataRow In dsParentBudget.Tables(0).Select("depend_wbs=" & currwbsId)
                Dim drh As New DataRowHelper(drow)

                totalBudget = 0
                totalActual = 0
                Select Case item.ItemType.Value
                  Case 88
                    totalBudget = drh.GetValue(Of Decimal)("labbudget")
                    totalActual = drh.GetValue(Of Decimal)("labactual")
                  Case 89
                    totalBudget = drh.GetValue(Of Decimal)("eqbudget")
                    totalActual = drh.GetValue(Of Decimal)("eqactual")
                  Case Else
                    totalBudget = drh.GetValue(Of Decimal)("matbudget")
                    totalActual = drh.GetValue(Of Decimal)("matactual")
                End Select
                If totalBudget < (totalActual + wbsd.Amount) Then
                  Dim myId As Integer = drh.GetValue(Of Integer)("depend_parent")
                  Dim myWBS As New WBS(myId)
                  Return New SaveErrorException(myWBS.Code & ":" & myWBS.Name)
                End If
              Next

            Next
            If item.WBSDistributeCollection.GetSumPercent = 0 Then
              '����Ѻ Auto �Ѵ���
              Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
              Dim tBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
              Dim tActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
              Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.CostCenter.Id)
              Dim cActual As Decimal = item.Amount
              Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
              If onlyWBSAllocate Then
                If oBudget < ((tActual - thisActual) + cActual) Then
                  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
                End If
              End If
              If tBudget < ((tActual - thisActual) + cActual) Then
                Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
              End If
            End If
          End If
        Next
      Else
        Dim hCC As New Hashtable
        For Each item As PAItem In Me.ItemCollection
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            If Not hCC.ContainsKey(wbsd.CostCenter.Id) Then
              hCC(wbsd.CostCenter.Id) = wbsd
            End If
          Next
          If item.WBSDistributeCollection.GetSumPercent = 0 Then
            '����Ѻ Auto �Ѵ���
            Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
            Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
            Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
            Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, Me.CostCenter.Id)
            Dim currentActual As Decimal = item.Amount
            Dim oBudget As Decimal = (rootWBS.OwnerMatBudgetAmount + rootWBS.OwnerLabBudgetAmount + rootWBS.OwnerEqBudgetAmount)
            If onlyWBSAllocate Then
              If oBudget < ((totalActual - thisActual) + currentActual) Then
                Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
              End If
            End If
            If totalBudget < ((totalActual - thisActual) + currentActual) Then
              Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
            End If
          End If
        Next
        For Each wbsd As WBSDistribute In hCC.Values
          Dim rootWBS As New WBS(wbsd.WBS.GetWBSRootId)
          Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
          Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
          Dim thisActual As Decimal = rootWBS.GetThisDocActualFromDB(Me.EntityId, Me.Id, wbsd.CostCenter.Id)
          Dim currentActual As Decimal = wbsd.Amount

          Dim tActual As Decimal = (wbsd.WBS.GetActualMat(Me, 45) + wbsd.WBS.GetActualLab(Me, 45) + wbsd.WBS.GetActualEq(Me, 45))
          Dim tcActual As Decimal = wbsd.WBS.GetThisDocActualFromDB(45, Me.Id, wbsd.CostCenter.Id)
          If onlyWBSAllocate Then
            If wbsd.OwnerBudgetAmount < ((tActual - tcActual) + currentActual) Then
              Return New SaveErrorException(wbsd.WBS.Code & ":" & wbsd.WBS.Name)
            End If
          End If
          If totalBudget < ((totalActual - thisActual) + currentActual) Then
            Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
          End If
        Next

        'Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
        'Dim totalBudget As Decimal = (rootWBS.GetTotalEQFromDB + rootWBS.GetTotalLabFromDB + rootWBS.GetTotalMatFromDB)
        'Dim totalActual As Decimal = (rootWBS.GetActualMat(Me, 45) + rootWBS.GetActualLab(Me, 45) + rootWBS.GetActualEq(Me, 45))
        'Dim totalCurrent As Decimal = Me.ItemCollection.Amount

        'If totalBudget < (totalActual + totalCurrent) Then
        '  Return New SaveErrorException(rootWBS.Code & ":" & rootWBS.Name)
        'End If
      End If

      Return New SaveErrorException("0")
    End Function
    Dim hashAutoChild As Hashtable
    Private Function ValidateItem() As SaveErrorException
      Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim key As String = ""
      ''== validate parent has no child =============================================>>>
      Dim key1 As String = ""
      Dim j As Integer = 0
      hashAutoChild = New Hashtable
      For Each pitem As PAItem In Me.ItemCollection
        If pitem.RefEntity.Id = 0 Then
          If pitem.Level = 0 Then
            If Not pitem.IsHasChild(Nothing) Then
              j += 1
              key1 = j.ToString
              hashAutoChild(key1) = pitem
            End If
          End If
        End If
      Next
      If hashAutoChild.Count > 0 Then
        If msgServ.AskQuestion("${res:Global.Question.NotChildItemAndWantToAutoCreateChild}") Then
          Return New SaveErrorException("2")
        Else
          Return New SaveErrorException("${res:Global.Error.SaveCanceled}")
        End If
      End If
      ''== validate parent has no child =============================================<<<
      For Each pitem As PAItem In Me.ItemCollection
        'If pitem.Level = 0 Then
        '  If pitem.RefEntity.Id = 0 Then
        '    If Configuration.Format(pitem.Amount, DigitConfig.Price) <> Configuration.Format(pitem.ChildAmount, DigitConfig.Price) Then
        '      Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverSCAmount}", _
        '      New String() {Configuration.FormatToString(pitem.Amount, DigitConfig.Price), Configuration.FormatToString(pitem.ChildAmount, DigitConfig.Price)})
        '    End If
        '  End If
        '  If pitem.HasChild AndAlso Not pitem.IsHasChild Then
        '    Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.HasChild}", New String() {pitem.EntityName})
        '  End If
        '  Dim m_value As Decimal = pitem.Mat + pitem.Lab + pitem.Eq
        '  If Configuration.Format(pitem.Amount, DigitConfig.Price) <> Configuration.Format(m_value, DigitConfig.Price) Then
        '    Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
        '     New String() {pitem.ItemDescription, Configuration.FormatToString(pitem.Amount, DigitConfig.Price), Configuration.FormatToString(m_value, DigitConfig.Price)})
        '  End If
        'Else
        '  Dim m_value As Decimal = pitem.Mat + pitem.Lab + pitem.Eq
        '  If Configuration.Format(pitem.Amount, DigitConfig.Price) <> Configuration.Format(m_value, DigitConfig.Price) Then
        '    Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
        '     New String() {pitem.ItemDescription, Configuration.FormatToString(pitem.Amount, DigitConfig.Price), Configuration.FormatToString(m_value, DigitConfig.Price)})
        '  End If
        'End If
        If pitem.Level = 0 Then
          'If pitem.RefEntity.Id = 0 Then
          '  If Configuration.Format(pitem.Amount, DigitConfig.Price) <> Configuration.Format(pitem.ChildAmount, DigitConfig.Price) Then
          '    Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverSCAmount}", _
          '    New String() {Configuration.FormatToString(pitem.Amount, DigitConfig.Price), Configuration.FormatToString(pitem.ChildAmount, DigitConfig.Price)})
          '  End If
          'End If
          'If pitem.HasChild AndAlso Not pitem.IsHasChild Then
          '  Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.HasChild}", New String() {pitem.EntityName})
          'End If
          ''Dim m_value As Decimal = pitem.Mat + pitem.Lab + pitem.Eq
          'Dim m_value As Decimal = pitem.GetChildCostAmount
          'Trace.WriteLine("costamt:" & pitem.CostAmount.ToString)
          'Trace.WriteLine("value:" & m_value.ToString)
          'If Configuration.Format(pitem.CostAmount, DigitConfig.Price) <> Configuration.Format(m_value, DigitConfig.Price) Then
          '  Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
          '   New String() {pitem.ItemDescription, Configuration.FormatToString(pitem.CostAmount, DigitConfig.Price), Configuration.FormatToString(m_value, DigitConfig.Price)})
          'End If
        Else
          'Dim m_value As Decimal = pitem.Mat + pitem.Lab + pitem.Eq
          'Trace.WriteLine("costamt:" & pitem.CostAmount.ToString)
          'Trace.WriteLine("value:" & m_value.ToString)
          'If Configuration.Format(pitem.CostAmount, DigitConfig.Price) <> Configuration.Format(m_value, DigitConfig.Price) Then
          '  Return New SaveErrorException("${res:Longkong.Pojjaman.Gui.Panels.SCItem.OverAmount}", _
          '   New String() {pitem.ItemDescription, Configuration.FormatToString(pitem.CostAmount, DigitConfig.Price), Configuration.FormatToString(m_value, DigitConfig.Price)})
          'End If
        End If
        Dim newHash As New Hashtable
        If pitem.WBSDistributeCollection.GetSumPercent > 100 Then
          Return New SaveErrorException("${res:Global.Error.WBSPercentExceed100}")
        End If
        For Each wbitem As WBSDistribute In pitem.WBSDistributeCollection
          key = wbitem.CostCenter.Code & ":" & wbitem.WBS.Id.ToString
          If Not newHash.Contains(key) Then
            newHash(key) = wbitem
          Else
            Return New SaveErrorException("${res:Global.Error.DupplicateWBS}", New String() {wbitem.WBS.Code})
          End If
          If (wbitem.WBS Is Nothing OrElse wbitem.WBS.Id = 0) AndAlso wbitem.CostCenter.Boq Is Nothing AndAlso wbitem.CostCenter.Boq.Id > 0 Then
            Return New SaveErrorException("${res:Global.Error.WBSMissing}")
          End If
        Next
      Next

      Return New SaveErrorException("0")
    End Function
    Private Function haveAdvancePay() As Boolean
      Dim ds As DataSet = SqlHelper.ExecuteDataset( _
               Me.ConnectionString _
               , CommandType.StoredProcedure _
               , "GethaveAdvancepayFromSupandEntity" _
               , New SqlParameter("@supplier_id", Me.SubContractor.Id) _
               , New SqlParameter("@entity_type", Me.EntityId) _
               , New SqlParameter("@taxtype", Me.TaxType.Value) _
               )
      If ds.Tables(0).Rows.Count > 0 Then
        Return True
      End If
      Return False
    End Function
    Private Sub ResetId(ByVal oldId As Integer, ByVal oldPaymentId As Integer _
, ByVal oldVatId As Integer, ByVal oldJeId As Integer)
      Me.Id = oldId
      Me.m_payment.Id = oldPaymentId
      Me.m_vat.Id = oldVatId
      Me.m_je.Id = oldJeId
      If Not Me.WitholdingTaxCollection Is Nothing Then
        Me.WitholdingTaxCollection.ResetId()
      End If
      Me.m_vat.SetRefDocToItem(Me.Id, Me.EntityId)
    End Sub
    Private Sub ResetCode(ByVal oldCode As String, ByVal oldautogen As Boolean, ByVal oldJecode As String, ByVal oldjeautogen As Boolean)
      Me.Code = oldCode
      Me.AutoGen = oldautogen
      Me.m_payment.Code = oldJecode
      Me.m_payment.AutoGen = oldjeautogen
      Me.m_je.Code = oldJecode
      Me.m_je.AutoGen = oldjeautogen
    End Sub
    Public Function BeforeSave(ByVal currentUserId As Integer) As SaveErrorException

      Dim ValidateError As SaveErrorException

      If Not Me.CostCenter Is Nothing Then
        Me.m_payment.CCId = Me.CostCenter.Id
        Me.m_whtcol.SetCCId(Me.CostCenter.Id)
        Me.m_vat.SetCCId(Me.CostCenter.Id)
      End If

      ValidateError = Me.Vat.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.WitholdingTaxCollection.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.Payment.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      ValidateError = Me.JournalEntry.BeforeSave(currentUserId)
      If Not IsNumeric(ValidateError.Message) Then
        Return ValidateError
      End If

      Return New SaveErrorException("0")

    End Function
    Private m_DocMethod As SaveDocMultiApprovalMethod
    Public Function OnlyGenGlAtom() As SaveErrorException Implements INewGLAble.OnlyGenGLAtom
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      SubSaveJeAtom(conn)
      conn.Close()
    End Function
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      With Me
        If Not Me.Originated Then
          m_DocMethod = SaveDocMultiApprovalMethod.Save
        ElseIf Me.Status.Value = 0 Then
          m_DocMethod = SaveDocMultiApprovalMethod.Cancel
        ElseIf Me.Closed Then
          m_DocMethod = SaveDocMultiApprovalMethod.Close
        Else
          m_DocMethod = SaveDocMultiApprovalMethod.Update
        End If

        Dim docValidate As Boolean = True
        If Me.Originated AndAlso Me.Status.Value = 0 Then
          docValidate = False
        End If

        Me.RefreshTaxBase()

        If docValidate Then '���¡��ԡ�͡������� ����ͧ Validate

          If Me.Originated Then
            If Not Me.SubContractor Is Nothing Then
              If Me.SubContractor.Canceled Then
                Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.CanceledSupplier}"), New String() {Me.SubContractor.Code})
              End If
            End If
          End If

          If Me.ItemCollection.Count = 0 Then   '.ItemTable.Childs.Count = 0 Then
            Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.NoItem}"))
          End If
          Dim ValidateError As SaveErrorException
          'ValidateError = Validate()
          'If Not IsNumeric(ValidateError.Message) Then
          '  Return ValidateError
          'End If
          ValidateError = ValidateItem()
          If Not IsNumeric(ValidateError.Message) Then
            Return ValidateError
          Else
            If CInt(ValidateError.Message) = 2 Then
              For Each sitem As PAItem In hashAutoChild.Values
                Dim nsitem As New PAItem
                nsitem.ItemType = New PAIItemType(88)
                nsitem.Entity = New BlankItem("")
                nsitem.Level = 1
                nsitem.EntityName = sitem.EntityName
                nsitem.SetUnit(sitem.Unit)
                nsitem.SetQty(sitem.Qty)
                nsitem.SetUnitPrice(sitem.UnitPrice)
                'nsitem.SetMat(sitem.Mat)
                nsitem.SetReceiveLab(sitem.Lab)
                nsitem.RefEntity = New RefEntity
                'nsitem.SetEq(sitem.Eq)
                nsitem.WBSDistributeCollection = sitem.WBSDistributeCollection
                AddHandler nsitem.WBSDistributeCollection.PropertyChanged, AddressOf nsitem.WBSChangedHandler

                Me.ItemCollection.Insert(Me.ItemCollection.IndexOf(sitem) + 1, nsitem)
              Next
            End If
          End If

          ''=============== Validate Over Budget ==================>>
          Dim ValidateOverBudgetError As SaveErrorException
          Dim config As Integer = CInt(Configuration.GetConfig("GROverBudget"))
          Select Case config
            Case 0   'Not allow
              ValidateOverBudgetError = Me.ValidateOverBudget
              If Not IsNumeric(ValidateOverBudgetError.Message) Then
                Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.OverBudgetCannotSaved}")
                Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                Return New SaveErrorException(msgString & vbCrLf & msgString2)
              End If
            Case 1   'Warn
              ValidateOverBudgetError = Me.ValidateOverBudget
              If Not IsNumeric(ValidateOverBudgetError.Message) Then
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                Dim msgString As String = Me.StringParserService.Parse("${res:Global.Error.AcceptOverBudget}")
                Dim msgString2 As String = Me.StringParserService.Parse("${res:Global.Error.WBSOverBudget}")
                msgString2 = String.Format(msgString2, ValidateOverBudgetError.Message)
                If Not msgServ.AskQuestion(msgString2 & vbCrLf & msgString) Then
                  Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
                End If
              End If
            Case 2   'Do Nothing
          End Select
          ''=============== Validate Over Budget ==================<<

          ''---------------------- ��������Ѵ����������ͻ��� 
          If Me.AdvancePayItemCollection Is Nothing OrElse Me.AdvancePayItemCollection.Count = 0 Then
            If haveAdvancePay() Then
              Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
              If msgServ.AskQuestion("${res:Global.Question.WantAddAdvancePay}") Then
                RaiseEvent AdvanceClick(Me, Nothing)
                'Return New SaveErrorException(Me.StringParserService.Parse("${res:Global.Error.SaveCanceled}"))
              End If
            End If
          End If
          '------------------

        End If



        '--------------����� Insert
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current

        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        If Me.Originated Then
          paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
        End If

        Dim theTime As Date = Now
        Dim theUser As New User(currentUserId)

        If Me.m_je.Status.Value = 4 Then
          Me.Status.Value = 4
          Me.m_payment.Status.Value = 4
          Me.m_whtcol.SetStatus(4)
          Me.m_vat.Status.Value = 4
        End If
        If Me.Status.Value = 0 Then
          Me.m_payment.Status.Value = 0
          Me.m_whtcol.SetStatus(0)
          Me.m_vat.Status.Value = 0
          Me.m_je.Status.Value = 0
        End If
        If Me.Status.Value = -1 Then
          Me.Status.Value = 2
        End If
        'Me.RefreshTaxBase()

        'If Me.AutoGen Then    'And Me.Code.Length = 0 Then
        'Me.Code = Me.GetNextCode
        'End If
        '---- AutoCode Format --------
        Dim oldcode As String
        Dim oldautogen As Boolean
        Dim oldjecode As String
        Dim oldjeautogen As Boolean

        oldcode = Me.Code
        oldautogen = Me.AutoGen
        oldjecode = Me.m_je.Code
        oldjeautogen = Me.m_je.AutoGen

        If Me.m_je.AccountBook Is Nothing OrElse m_je.AccountBook.CodePrefix Is Nothing Then
          Me.m_je.AccountBook = Me.GetDefaultGLFormat.AccountBook
        End If
        If Not AutoCodeFormat Is Nothing Then


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
              Me.m_je.DontSave = False
            Case 2
              '��� gl
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.Code = Me.m_je.Code
              Me.m_je.DontSave = False
            Case Else
              '�¡
              If Me.AutoGen Then 'And Me.Code.Length = 0 Then
                Me.Code = Me.GetNextCode
              End If
              If Me.m_je.AutoGen Then
                Me.m_je.Code = m_je.GetNextCode
              End If
              Me.m_je.DontSave = False
          End Select
        Else
          If Me.AutoGen Then 'And Me.Code.Length = 0 Then
            Me.Code = Me.GetNextCode
          End If
          If Me.m_je.AutoGen Then
            Me.m_je.Code = m_je.GetNextCode
          End If
        End If
        If Me.Payment.Gross <> 0 Then
          Me.m_payment.Code = m_je.Code
        End If
        Me.m_je.DocDate = Me.DocDate
        Me.m_payment.DocDate = m_je.DocDate
        If Me.AutoCodeFormat.CodeConfig.Value = 0 Then
          Me.m_payment.Code = Me.Code
          Me.m_payment.DocDate = Me.DocDate
        End If
        Me.AutoGen = False
        Me.m_je.AutoGen = False
        Me.m_payment.AutoGen = False

        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_sc", ValidIdOrDBNull(Me.Sc)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docDate", Me.DocDate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_subcontractor", ValidIdOrDBNull(Me.Sc.SubContractor)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherdoccode", Me.OtherDocCode))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_otherdocDate", Me.OtherDocDate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_receiver", ValidIdOrDBNull(Me.Receiver)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cc", ValidIdOrDBNull(Me.Sc.CostCenter)))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_creditPeriod", Me.CreditPeriod))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_contactPerson", Me.ContactPerson))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxType", Me.TaxType.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxRate", Me.TaxRate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxbase", Me.RealTaxBase))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_aftertax", Me.AfterTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_beforetax", Me.BeforeTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_gross", Me.Gross))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_closed", Me.Closed))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_witholdingtax", Me.WitholdingTax))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discrate", Me.Discount.Rate))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_discamt", Me.Discount.Amount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_taxAmt", Me.RealTaxAmount))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retentiontodate", Me.RetentionToDoc))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_retention", Me.Retention))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_advancepaytodate", Me.AdvancePayToDoc))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_advancepay", Me.AdvancePay))

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
        Dim conn As New SqlConnection(Me.ConnectionString)
        conn.Open()
        Dim oldid As Integer = Me.Id
        Dim oldPaymentId As Integer = Me.m_payment.Id
        Dim oldVatId As Integer = Me.m_vat.Id
        If Not Me.WitholdingTaxCollection Is Nothing Then
          Me.WitholdingTaxCollection.SaveOldID()
        End If
        Dim oldJeId As Integer = Me.m_je.Id

        '======����� trans ========
        trans = conn.BeginTransaction()
        Try


          Try
            Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
            If IsNumeric(returnVal.Value) Then
              Select Case CInt(returnVal.Value)
                Case -1, -5
                  trans.Rollback()
                  ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return New SaveErrorException(returnVal.Value.ToString)
                Case -2 '�͡��ö١��ҧ�ԧ����
                  If Me.IsDirty Then '����͡��ö١��� --> ������ save
                    trans.Rollback()
                    ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return New SaveErrorException(returnVal.Value.ToString)
                  End If
                Case Else
              End Select
            ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
              trans.Rollback()
              ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return New SaveErrorException(returnVal.Value.ToString)
            End If

            'If Not IsNumeric(saveDetailError.Message) Then
            '    trans.Rollback()
            '    ResetID(oldid)
            '    Return saveDetailError
            'Else
            '    Select Case CInt(saveDetailError.Message)
            '        Case -1, -2, -5
            '            trans.Rollback()
            '            ResetID(oldid)
            '            Return saveDetailError
            '        Case Else
            '    End Select
            'End If

            Dim saveDetailError As SaveErrorException = SaveDetailSp1(Me.Id, conn, trans)
            If Not IsNumeric(saveDetailError.Message) Then
              trans.Rollback()
              ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveDetailError
            Else
              If IsNumeric(returnVal.Value) Then
                Select Case CInt(returnVal.Value)
                  Case -1, -2, -5
                    trans.Rollback()
                    Me.ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return New SaveErrorException(returnVal.Value.ToString)
                  Case Else
                End Select
              End If
            End If

            'Dim saveDetailError As SaveErrorException = SaveDetail(Me.Id, conn, trans)
            'If Not IsNumeric(saveDetailError.Message) Then
            '  trans.Rollback()
            '  ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
            '  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            '  Return saveDetailError
            'Else
            '  If IsNumeric(returnVal.Value) Then
            '    Select Case CInt(returnVal.Value)
            '      Case -1, -2, -5
            '        trans.Rollback()
            '        Me.ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
            '        ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            '        Return New SaveErrorException(returnVal.Value.ToString)
            '      Case Else
            '    End Select
            '  End If
            'End If


            Me.m_vat.SetRefDocToItem(Me.Id, Me.EntityId)
            Dim savePaymentError As SaveErrorException = Me.m_payment.Save(currentUserId, conn, trans)
            If Not IsNumeric(savePaymentError.Message) Then
              Me.m_payment.Id = oldPaymentId
              trans.Rollback()
              Me.Payment.ResetDetail()
              ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return savePaymentError
            Else
              Select Case CInt(savePaymentError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.Payment.ResetDetail()
                  ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return savePaymentError
                Case Else
              End Select
            End If

            If Not Me.m_advancePayItemColl Is Nothing Then
              If Me.m_advancePayItemColl.RefDoc Is Nothing Then
                Me.m_advancePayItemColl.RefDoc = Me
              End If
              For Each advi As AdvancePayItem In Me.m_advancePayItemColl
                advi.Status = Me.Status.Value
              Next
              Dim saveAdvancePayError As SaveErrorException = Me.m_advancePayItemColl.Save(currentUserId, conn, trans)
              If Not IsNumeric(saveAdvancePayError.Message) Then
                trans.Rollback()
                Me.Payment.ResetDetail()
                ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveAdvancePayError
              Else
                Select Case CInt(saveAdvancePayError.Message)
                  Case -1, -2, -5
                    trans.Rollback()
                    Me.Payment.ResetDetail()
                    ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveAdvancePayError
                  Case Else
                End Select
              End If
            End If
            If Not Me.m_whtcol Is Nothing AndAlso Me.m_whtcol.Count >= 0 Then
              Dim saveWhtError As SaveErrorException = Me.m_whtcol.Save(currentUserId, conn, trans)
              If Not IsNumeric(saveWhtError.Message) Then
                trans.Rollback()
                Me.Payment.ResetDetail()
                ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                Return saveWhtError
              Else
                Select Case CInt(saveWhtError.Message)
                  Case -1, -2, -5
                    trans.Rollback()
                    Me.Payment.ResetDetail()
                    ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                    ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                    Return saveWhtError
                  Case Else
                End Select
              End If
            End If
            Dim saveVatError As SaveErrorException = Me.m_vat.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveVatError.Message) Then
              trans.Rollback()
              Me.Payment.ResetDetail()
              ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveVatError
            Else
              Select Case CInt(saveVatError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.Payment.ResetDetail()
                  ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveVatError
                Case Else
              End Select
            End If

            If Me.m_je.Status.Value = -1 Then
              m_je.Status.Value = 3
            End If
            Dim saveJeError As SaveErrorException = Me.m_je.Save(currentUserId, conn, trans)
            If Not IsNumeric(saveJeError.Message) Then
              trans.Rollback()
              Me.Payment.ResetDetail()
              ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveJeError
            Else
              Select Case CInt(saveJeError.Message)
                Case -1, -5
                  trans.Rollback()
                  Me.Payment.ResetDetail()
                  ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveJeError
                Case -2
                  'Post �����
                  Me.Payment.ResetDetail()
                  ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveJeError
                Case Else
              End Select
            End If





            '==============================AUTOGEN==========================================
            Dim saveAutoCodeError As SaveErrorException = SaveAutoCode(conn, trans)
            If Not IsNumeric(saveAutoCodeError.Message) Then
              trans.Rollback()
              Me.Payment.ResetDetail()
              ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
              ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
              Return saveAutoCodeError
            Else
              Select Case CInt(saveAutoCodeError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Me.Payment.ResetDetail()
                  ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
                  ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
                  Return saveAutoCodeError
                Case Else
              End Select
            End If
            '==============================AUTOGEN==========================================


            trans.Commit()

          Catch ex As SqlException
            trans.Rollback()
            Me.Payment.ResetDetail()
            Me.ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          Catch ex As Exception
            trans.Rollback()
            Me.Payment.ResetDetail()
            Me.ResetId(oldid, oldPaymentId, oldVatId, oldJeId)
            ResetCode(oldcode, oldautogen, oldjecode, oldjeautogen)
            Return New SaveErrorException(ex.ToString)
          End Try

          'Sub Save Block =======================================
          Try
            Dim subsaveerror As SaveErrorException = SubSave(conn)
            If Not IsNumeric(subsaveerror.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          Try
            Dim subsaveerror3 As SaveErrorException = SubSaveJeAtom(conn)
            If Not IsNumeric(subsaveerror3.Message) Then
              Return New SaveErrorException(" Save Incomplete Please Save Again")
            End If
          Catch ex As Exception
            Return New SaveErrorException(ex.ToString)
          End Try

          'Try
          '  Dim subsaveerror As SaveErrorException = SubSaveDocApprove(conn, currentUserId)
          '  If Not IsNumeric(subsaveerror.Message) Then
          '    Return New SaveErrorException(" Save Incomplete Please Save Again")
          '  End If
          'Catch ex As Exception
          '  Return New SaveErrorException(ex.ToString)
          'End Try
          Parallel.Invoke(Sub()
                            SaveWBSActual(conn)
                          End Sub,
                          Sub()
                            SubSaveDocApprove(conn, currentUserId)
                          End Sub,
                          Sub()
                            SaveUpdateWBSReferencedFromPA(conn)
                          End Sub)
          'Sub Save Block ========================================

          Return New SaveErrorException(returnVal.Value.ToString)
          'Complete Save
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        Finally
          conn.Close()
        End Try
      End With
    End Function
    Private Function SubSaveJeAtom(ByVal conn As SqlConnection) As SaveErrorException Implements INewGLAble.SubSaveJeAtom
      Me.JournalEntry.RefreshOnlyGLAtom()
      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        Me.JournalEntry.SaveAutoMateDetail(Me.JournalEntry.Id, conn, trans)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.ToString)
      End Try
      trans.Commit()
      Return New SaveErrorException("0")
    End Function
    Private Function SubSave(ByVal conn As SqlConnection) As SaveErrorException

      '======����� trans 2 �ͧ�Դ��� save ���� ========
      Dim trans As SqlTransaction = conn.BeginTransaction
      ' Save CustomNote �ҡ��� Copy �͡���
      If Not Me.m_customNoteColl Is Nothing AndAlso Me.m_customNoteColl.Count > 0 Then
        If Me.Originated Then
          Me.m_customNoteColl.EntityId = Me.Id
          Me.m_customNoteColl.Save()
        End If
      End If
      trans.Commit()
      Dim isCanceled As Integer = 0
      If Me.Status.Value = 0 Then
        isCanceled = 1
      End If
      Dim hashItem As New Hashtable
      Dim currentRefEntity As Integer
      For Each item As PAItem In Me.ItemCollection
        If currentRefEntity <> item.RefEntity.Id Then
          currentRefEntity = item.RefEntity.Id
          hashItem(currentRefEntity) = item
        End If
      Next
      Dim trans2 As SqlTransaction = conn.BeginTransaction

      Try
        SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "UpdateSCParent" _
                                     , New SqlParameter("@id", Me.Id) _
                                     , New SqlParameter("@docType", Me.EntityId))
        '��� cancle ��ͧ update Adv ��� Ret todate ���ç
        If Me.Status.Value = 0 Then
          SqlHelper.ExecuteNonQuery(conn, trans2, CommandType.StoredProcedure, "UpdatePAAdvRetToDate" _
                                   , New SqlParameter("@sc_id", Me.Sc.Id))
        End If


      Catch ex As Exception
        trans2.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans2.Commit()

      Dim trans3 As SqlTransaction = conn.BeginTransaction

      Try

        Me.DeleteRef(conn, trans3)

        For Each hsItem As PAItem In hashItem.Values
          SqlHelper.ExecuteNonQuery(conn, trans3, CommandType.StoredProcedure, "InsertUpdatereference" _
          , New SqlParameter("@entity_id", hsItem.RefDoc) _
          , New SqlParameter("@entity_type", hsItem.RefDocType) _
          , New SqlParameter("@refto_id", Me.Id) _
          , New SqlParameter("@refto_type", Me.EntityId) _
          , New SqlParameter("@refto_iscanceled", isCanceled) _
          )
        Next

        'SqlHelper.ExecuteNonQuery(conn, trans3, CommandType.StoredProcedure, "UpdateWBSReferencedFromPA", New SqlParameter("@refto_id", Me.Id))

        'SqlHelper.ExecuteNonQuery(conn, trans3, CommandType.StoredProcedure, "swang_UpdateGRWBSActual")
      Catch ex As Exception
        trans3.Rollback()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      trans3.Commit()
      Return New SaveErrorException("0")
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
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_OnlyUpdateGRWBSActual", New SqlParameter("@stock_id", Me.Id))

      Catch ex As Exception
        trans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function

    Private Function SaveUpdateWBSReferencedFromPA(ByVal oldconn As SqlConnection) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()

      Dim trans As SqlTransaction = conn.BeginTransaction
      Try
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateWBSReferencedFromPA", New SqlParameter("@refto_id", Me.Id))
      Catch ex As Exception
        trans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.ToString)
      End Try

      trans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function

    Private Function SubSaveDocApprove(ByVal oldconn As SqlConnection, ByVal currentUserId As Integer) As SaveErrorException
      Dim conn As New SqlConnection(oldconn.ConnectionString)
      conn.Open()

      Dim strans As SqlTransaction = conn.BeginTransaction

      Try
                'Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.AfterTax, currentUserId, m_DocMethod, Me.ApproveDocColl.GetLastedApproveDoc.Comment, Me.CostCenter.Id, Me.SubContractor.Id, Me)
                Dim mldoc As DocMultiApproval
                If Not (Me.ApproveDocColl Is Nothing) Then
                    mldoc = New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.AfterTax, currentUserId, m_DocMethod, Me.ApproveDocColl.GetLastedApproveDoc.Comment, Me.CostCenter.Id, Me.SubContractor.Id, Me)
                Else
                    mldoc = New DocMultiApproval(Me.Id, Me.EntityId, Me.Code, Me.DocDate, Me.AfterTax, currentUserId, m_DocMethod, "", Me.CostCenter.Id, Me.SubContractor.Id, Me)
                End If
                Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, strans)
        If Not IsNumeric(savemldocError.Message) Then
          strans.Rollback()
          conn.Close()
          Return savemldocError
        End If
      Catch ex As Exception
        strans.Rollback()
        conn.Close()
        Return New SaveErrorException(ex.InnerException.ToString)
      End Try

      strans.Commit()
      conn.Close()
      Return New SaveErrorException("0")
    End Function


    Public Overrides Function GetNextCode() As String
      Dim autoCodeFormat As String = Me.Code   'Entity.GetAutoCodeFormat(Me.EntityId)
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
    Private Sub ChangeOldItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      'If Not Me.Originated Then
      '	Return
      'End If
      'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateOldPRItemStatus", New SqlParameter("@po_id", Me.Id))

    End Sub
    Private Sub ChangeNewItemStatus(ByVal conn As SqlConnection, ByVal trans As SqlTransaction)
      'If Not Me.Originated Then
      '	Return
      'End If
      'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdateNewPRItemStatus", New SqlParameter("@po_id", Me.Id))
    End Sub
    Private Function SaveDetailSp1(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      Try
        Dim cmdWbs As String = "delete from paiwbs where paiw_sequence in (select pai_sequence from paitem where pai_pa=" & Me.Id & ")"
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, cmdWbs)

        Dim da As New SqlDataAdapter("Select * from paitem where pai_pa=" & Me.Id, conn)
        Dim ds As New DataSet
        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "paitem")
        da.Fill(ds, "paitem")

        Dim dt As DataTable = ds.Tables("paitem")
        For Each row As DataRow In ds.Tables("paitem").Rows
          row.Delete()
        Next
        Dim i As Integer = 0
        Dim refSequence As Decimal = 0
        Dim ItemCollectionHs As New Hashtable
        With ds.Tables("paitem")
          For Each item As PAItem In Me.ItemCollection
            i += 1
            ItemCollectionHs(i) = item

            Dim dr As DataRow = .NewRow
            dr("pai_refsequence") = item.RefSequence
            dr("pai_sc") = Me.Sc.Id
            dr("pai_pa") = Me.Id
            dr("pai_refDoc") = item.RefDoc
            dr("pai_refDocType") = item.RefDocType
            dr("pai_lineNumber") = i
            dr("pai_level") = item.Level
            dr("pai_entity") = item.Entity.Id
            dr("pai_entityType") = item.ItemType.Value
            dr("pai_itemName") = item.EntityName
            dr("pai_qty") = item.Qty
            dr("pai_unitprice") = item.UnitPrice
            dr("pai_mat") = item.Mat
            dr("pai_eq") = item.Eq
            dr("pai_lab") = item.Lab
            dr("pai_amt") = item.ReceiveAmount
            dr("pai_unitCost") = item.UnitCost
            dr("pai_note") = item.Note
            dr("pai_unit") = item.Unit.Id
            dr("pai_unvatable") = item.UnVatable
            dr("pai_status") = Me.Status.Value
            dr("pai_progressAmt") = item.TotalProgressReceive
            dr("pai_acct") = Me.ValidIdOrDBNull(item.MatAccount)
            dr("pai_eqacct") = Me.ValidIdOrDBNull(item.EqAccount)
            dr("pai_labacct") = Me.ValidIdOrDBNull(item.LabAccount)
            .Rows.Add(dr)
          Next
        End With

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        'AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        'AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

        tmpDa.Update(GetDeletedRows(dt))
        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))

        'Return New SaveErrorException("1")
        'da.Update(ds.Tables("paitem").Select("", "", DataViewRowState.ModifiedCurrent))
        'da.Update(ds.Tables("paitem").Select("", "", DataViewRowState.Added))

        '--New Fetch-- 
        Dim j As Integer = 0
        Dim cmdList As New ArrayList
        Dim cmd As String = "Select pai_sequence, pai_linenumber from paitem where pai_pa=" & Me.Id.ToString & " and pai_entityType not in (160,162,291,289)"
        Dim ds2 As DataSet = SqlHelper.ExecuteDataset(conn, trans, CommandType.Text, cmd)
        'Dim dt2 As DataTable = ds2.Tables(0)
        For Each row As DataRow In ds2.Tables(0).Rows
          j += 1
          Dim drh As New DataRowHelper(row)
          Dim lineNumber As Integer = drh.GetValue(Of Integer)("pai_linenumber")
          Dim item As PAItem = CType(ItemCollectionHs(lineNumber), PAItem)

          Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
          Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
          Dim currentSum As Decimal = wbsdColl.GetSumPercent
          For Each wbsd As WBSDistribute In wbsdColl
            Dim cmdText As String = ""
            Dim cmdTextList As New ArrayList
            If currentSum < 100 AndAlso wbsd.WBS.Id = rootWBS.Id Then
              '�ѧ������ 100 �����������
              wbsd.Percent += (100 - currentSum)
            End If
            Dim bfTax As Decimal = 0
            bfTax = item.CostAmount
            wbsd.BaseCost = bfTax
            If wbsd.CostCenter Is Nothing Then
              wbsd.CostCenter = Me.CostCenter
            End If

            cmdTextList.Add(drh.GetValue(Of String)("pai_sequence"))
            cmdTextList.Add(wbsd.WBS.Id)
            cmdTextList.Add(wbsd.Percent)
            cmdTextList.Add(IIf(wbsd.IsMarkup, 1, 0))
            cmdTextList.Add("0") 'in
            cmdTextList.Add(wbsd.BaseCost)
            cmdTextList.Add(wbsd.Amount)
            cmdTextList.Add("3")
            cmdTextList.Add(wbsd.CostCenter.Id)
            cmdTextList.Add(wbsd.CBS.Id)

            cmdText = String.Join(",", cmdTextList.ToArray)
            cmdList.Add("(" & cmdText & ")")
          Next

          currentSum = wbsdColl.GetSumPercent
          '�ѧ������ 100 ����ѧ����� root
          If currentSum < 100 AndAlso Not rootWBS Is Nothing Then
            Try
              Dim cmdText As String = ""
              Dim cmdTextList As New ArrayList
              Dim newWbsd As New WBSDistribute
              newWbsd.WBS = rootWBS
              newWbsd.CostCenter = item.Pa.CostCenter
              newWbsd.Percent = 100 - currentSum
              Dim bfTax As Decimal = 0
              bfTax = item.CostAmount
              newWbsd.BaseCost = bfTax
              If newWbsd.CostCenter Is Nothing Then
                newWbsd.CostCenter = Me.CostCenter
              End If

              cmdTextList.Add(drh.GetValue(Of String)("pai_sequence"))
              cmdTextList.Add(newWbsd.WBS.Id)
              cmdTextList.Add(newWbsd.Percent)
              cmdTextList.Add("0")
              cmdTextList.Add("0") 'in
              cmdTextList.Add(newWbsd.BaseCost)
              cmdTextList.Add(newWbsd.Amount)
              cmdTextList.Add("3")
              cmdTextList.Add(newWbsd.CostCenter.Id)
              cmdTextList.Add(newWbsd.CBS.Id)

              cmdText = String.Join(",", cmdTextList.ToArray)
              cmdList.Add("(" & cmdText & ")")
            Catch ex As Exception
              Throw New Exception(ex.Message.ToString)
            End Try
          End If
        Next

        Dim cmdAllocate As String = "insert into paiwbs (paiw_sequence,paiw_wbs,paiw_percent,paiw_isMarkup,paiw_direction,paiw_baseCost,paiw_amt,paiw_toaccttype,paiw_cc,paiw_cbs) values "
        cmdAllocate &= String.Join(",", cmdList.ToArray)

        If cmdList.Count > 0 Then
          SqlHelper.ExecuteNonQuery(conn, trans, CommandType.Text, cmdAllocate)
        End If

        Return New SaveErrorException("1")

      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      End Try
    End Function
    Private Function SaveDetail(ByVal parentID As Integer, ByVal conn As SqlConnection, ByVal trans As SqlTransaction) As SaveErrorException
      '    Dim currWBS As String
      Try
        Dim da As New SqlDataAdapter("Select * from paitem where pai_pa=" & Me.Id, conn)
        Dim daWbs As New SqlDataAdapter("Select * from paiwbs where paiw_sequence in (select pai_sequence from paitem where pai_pa=" & Me.Id & ")", conn)
        Dim ds As New DataSet

        Dim cmdBuilder As New SqlCommandBuilder(da)
        da.SelectCommand.Transaction = trans
        da.DeleteCommand = cmdBuilder.GetDeleteCommand
        da.DeleteCommand.Transaction = trans
        da.InsertCommand = cmdBuilder.GetInsertCommand
        da.InsertCommand.Transaction = trans
        da.UpdateCommand = cmdBuilder.GetUpdateCommand
        da.UpdateCommand.Transaction = trans
        da.InsertCommand.CommandText &= "; Select * From paitem Where pai_sequence = @@IDENTITY"
        da.InsertCommand.UpdatedRowSource = UpdateRowSource.FirstReturnedRecord
        cmdBuilder = Nothing
        da.FillSchema(ds, SchemaType.Mapped, "paitem")
        da.Fill(ds, "paitem")

        cmdBuilder = New SqlCommandBuilder(daWbs)
        daWbs.SelectCommand.Transaction = trans
        cmdBuilder.GetDeleteCommand.Transaction = trans
        cmdBuilder.GetInsertCommand.Transaction = trans
        cmdBuilder.GetUpdateCommand.Transaction = trans
        cmdBuilder = Nothing
        daWbs.FillSchema(ds, SchemaType.Mapped, "paiwbs")
        daWbs.Fill(ds, "paiwbs")
        ds.Relations.Add("sequence", ds.Tables!paitem.Columns!pai_sequence, ds.Tables!paiwbs.Columns!paiw_sequence)

        Dim dt As DataTable = ds.Tables("paitem")
        Dim dtWbs As DataTable = ds.Tables("paiwbs")

        For Each row As DataRow In ds.Tables("paiwbs").Rows
          row.Delete()
        Next
        For Each row As DataRow In ds.Tables("paitem").Rows
          row.Delete()
        Next

        Dim i As Integer = 0
        Dim refSequence As Decimal = 0
        With ds.Tables("paitem")
          For Each item As PAItem In Me.ItemCollection

            'Select Case item.ItemType.Value
            '  Case 42
            '    Dim lci As New LCIItem(item.Entity.Id)
            '    If Not lci.Originated Then
            '      Return New SaveErrorException("${res:Global.Error.LCIIsInvalid}", New String() {item.Entity.Name})
            '    ElseIf Not lci.ValidUnit(item.Unit) Then
            '      Return New SaveErrorException("${res:Global.Error.LCIInvalidUnit}", New String() {lci.Code, item.Unit.Name})
            '    End If
            '  Case 19
            '    Dim myTool As New Tool(item.Entity.Id)
            '    If Not myTool.Originated Then
            '      Return New SaveErrorException("${res:Global.Error.ToolIsInvalid}", New String() {item.Entity.Name})
            '    ElseIf myTool.Unit.Id <> item.Unit.Id Then
            '      Return New SaveErrorException("${res:Global.Error.ToolInvalidUnit}", New String() {myTool.Code, item.Unit.Name})
            '    End If
            'End Select

            i += 1
            Dim dr As DataRow = .NewRow

            'dr("pai_sequence") = ""
            dr("pai_refsequence") = item.RefSequence
            dr("pai_sc") = Me.Sc.Id
            dr("pai_pa") = Me.Id
            dr("pai_refDoc") = item.RefDoc
            dr("pai_refDocType") = item.RefDocType
            dr("pai_lineNumber") = i
            dr("pai_level") = item.Level
            dr("pai_entity") = item.Entity.Id
            dr("pai_entityType") = item.ItemType.Value
            dr("pai_itemName") = item.EntityName
            dr("pai_qty") = item.Qty
            dr("pai_unitprice") = item.UnitPrice
            dr("pai_mat") = item.Mat
            dr("pai_eq") = item.Eq
            dr("pai_lab") = item.Lab
            dr("pai_amt") = item.ReceiveAmount
            dr("pai_unitCost") = item.UnitCost
            dr("pai_note") = item.Note
            dr("pai_unit") = item.Unit.Id
            dr("pai_unvatable") = item.UnVatable
            'dr("pai_parent") = item.ParentPath
            dr("pai_status") = Me.Status.Value
            dr("pai_progressAmt") = item.TotalProgressReceive
            dr("pai_acct") = Me.ValidIdOrDBNull(item.MatAccount)
            dr("pai_eqacct") = Me.ValidIdOrDBNull(item.EqAccount)
            dr("pai_labacct") = Me.ValidIdOrDBNull(item.LabAccount)
            .Rows.Add(dr)

            If (item.ItemType.Value <> 160 AndAlso
             item.ItemType.Value <> 162 AndAlso
             item.ItemType.Value <> 291 AndAlso
             item.ItemType.Value <> 289) Then
              Dim wbsdColl As WBSDistributeCollection = item.WBSDistributeCollection
              Dim rootWBS As New WBS(Me.CostCenter.RootWBSId)
              Dim currentSum As Decimal = wbsdColl.GetSumPercent
              For Each wbsd As WBSDistribute In wbsdColl
                If currentSum < 100 AndAlso wbsd.WBS.Id = rootWBS.Id Then
                  '�ѧ������ 100 �����������
                  wbsd.Percent += (100 - currentSum)
                End If
                Dim bfTax As Decimal = 0
                'If item.Po.Closed Then
                '  bfTax = item.ReceivedBeforeTax
                'Else
                bfTax = item.CostAmount
                'End If
                'currWBS = wbsd.WBS.Code & ":" & wbsd.WBS.Name
                wbsd.BaseCost = bfTax
                'wbsd.TransferBaseCost = bfTax
                Dim childDr As DataRow = dtWbs.NewRow
                childDr("paiw_wbs") = wbsd.WBS.Id
                childDr("paiw_sequence") = dr("pai_sequence")
                If wbsd.CostCenter Is Nothing Then
                  wbsd.CostCenter = Me.CostCenter
                End If
                childDr("paiw_cc") = wbsd.CostCenter.Id
                childDr("paiw_percent") = wbsd.Percent
                childDr("paiw_ismarkup") = wbsd.IsMarkup
                childDr("paiw_direction") = 0        'in
                childDr("paiw_baseCost") = wbsd.BaseCost
                childDr("paiw_amt") = wbsd.Amount
                childDr("paiw_toaccttype") = 3
                childDr("paiw_cbs") = wbsd.CBS.Id
                'Add ��� paiwbs
                dtWbs.Rows.Add(childDr)
              Next

              currentSum = wbsdColl.GetSumPercent
              '�ѧ������ 100 ����ѧ����� root
              If currentSum < 100 AndAlso Not rootWBS Is Nothing Then
                Try
                  Dim newWbsd As New WBSDistribute
                  newWbsd.WBS = rootWBS
                  newWbsd.CostCenter = item.Pa.CostCenter
                  newWbsd.Percent = 100 - currentSum
                  Dim bfTax As Decimal = 0
                  'If item.Po.Closed Then
                  '  bfTax = item.ReceivedBeforeTax
                  'Else
                  bfTax = item.CostAmount
                  'End If
                  newWbsd.BaseCost = bfTax
                  'newWbsd.TransferBaseCost = bfTax
                  Dim childDr As DataRow = dtWbs.NewRow
                  childDr("paiw_wbs") = newWbsd.WBS.Id
                  childDr("paiw_sequence") = dr("pai_sequence")
                  childDr("paiw_cc") = newWbsd.CostCenter.Id
                  childDr("paiw_percent") = newWbsd.Percent
                  childDr("paiw_ismarkup") = False
                  childDr("paiw_direction") = 0         'in
                  childDr("paiw_baseCost") = newWbsd.BaseCost
                  childDr("paiw_amt") = newWbsd.Amount
                  childDr("paiw_toaccttype") = 3
                  childDr("paiw_cbs") = newWbsd.CBS.Id
                  'Add ��� paiwbs
                  dtWbs.Rows.Add(childDr)
                Catch ex As Exception
                  Throw New Exception(ex.Message.ToString)
                End Try
              End If
            End If
          Next
        End With

        Dim tmpDa As New SqlDataAdapter
        tmpDa.DeleteCommand = da.DeleteCommand
        tmpDa.InsertCommand = da.InsertCommand
        tmpDa.UpdateCommand = da.UpdateCommand

        AddHandler tmpDa.RowUpdated, AddressOf tmpDa_MyRowUpdated
        AddHandler daWbs.RowUpdated, AddressOf daWbs_MyRowUpdated

        daWbs.Update(GetDeletedRows(dtWbs))
        tmpDa.Update(GetDeletedRows(dt))

        tmpDa.Update(dt.Select("", "", DataViewRowState.ModifiedCurrent))
        daWbs.Update(dtWbs.Select("", "", DataViewRowState.ModifiedCurrent))

        tmpDa.Update(dt.Select("", "", DataViewRowState.Added))
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
        Dim currentkey As Integer = CInt(e.Row("paiw_sequence")) '.GetParentRow("sequence")("paiw_sequence", DataRowVersion.Current)
        ' This is where you get a correct original value key stored to the child row. You yank
        ' the original pseudo key value from the parent, plug it in as the child row's primary key
        ' field, and accept changes on it. Specifically, this is why you turned off EnforceConstraints.
        e.Row!paiw_sequence = e.Row.GetParentRow("sequence")("pai_sequence", DataRowVersion.Original)
        e.Row.AcceptChanges()
        ' Now store the actual primary key value back into the foreign key column of the child row.
        e.Row!paiw_sequence = currentkey
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
    Private Function IsValidateReceiptAmoutFist(ByVal id As Integer) As Boolean
      Dim obj As Object = Configuration.GetConfig("CheckRemainingReceiptAmount")
      If Not CBool(obj) Then
        Return True
      End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, _
                                                   CommandType.StoredProcedure, _
                                                   "CheckRemainingAmountForReceiptProgress", _
                                                   New SqlParameter("@sc_id", id) _
                                                   )
      If CDec(ds.Tables(0).Rows(0)(0)) > 0 Then
        Return True
      End If

      Return False
    End Function
    Private Sub ChangeSC()      If Me.Sc Is Nothing OrElse Me.Sc.Code.Length = 0 Then
        ClearSC()
        Return
      End If

      'Dim ret As Decimal = Me.GetSCRetentionRemaining
      'Me.m_retentionToDoc = Sc.Retention - ret
      'Me.m_retentionRemaining = ret
      'Me.m_retention = ret
      'Dim adv As Decimal = Me.GetSCAdvancePayRemaining
      'Me.m_advancePayToDoc = Sc.AdvancePay - adv
      SetPAAdvancePayAndRetention()

      Dim dist As Decimal = Me.GetSCDistCountRemaining
      If dist > 0 Then
        Dim distString As String = dist.ToString
        Me.m_discount = New Discount(distString)
      End If

      Me.ItemCollection.Clear()

      'If Me.Sc Is Nothing OrElse Me.Sc.Code.Length = 0 Then
      'ClearSC()
      'Return
      'End If

      Dim refDocType As Decimal = 0
      Dim sequence As String = ""
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetSCItemForPAItem" _
                , New SqlParameter("@sc_id", Me.Sc.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          For Each row As DataRow In ds.Tables(0).Rows

            refDocType = CDec(row("pai_refdoctype"))
            sequence = CStr(row("pai_refsequence"))

            Dim item As New PAItem(row, "")
            item.Pa = Me
            item.SC = Me.Sc

            item.WBSDistributeCollection = New WBSDistributeCollection
            AddHandler item.WBSDistributeCollection.PropertyChanged, AddressOf item.WBSChangedHandler

            Select Case refDocType
              Case 289 '�͡��� sc
                If ds.Tables(1).Rows.Count > 0 Then
                  For Each wbsRow As DataRow In ds.Tables(1).Select("sciw_sequence=" & sequence)
                    Dim wbsd As New WBSDistribute(wbsRow, "")
                    item.WBSDistributeCollection.Add(wbsd)

                    wbsd.BaseCost = item.ReceiveAmount

                    '--Budget Remain =========================================================
                    Dim budgetRow() As DataRow = ds.Tables(3).Select("wbs_id=" & wbsd.WBS.Id)
                    If budgetRow.Length > 0 Then
                      Dim drh As New DataRowHelper(budgetRow(0))
                      If wbsd.IsMarkup Then
                        wbsd.BudgetRemain = drh.GetValue(Of Decimal)("totalactual")
                      Else
                        Select Case item.ItemType.Value
                          Case 88, 289, 291
                            wbsd.BudgetRemain = drh.GetValue(Of Decimal)("labactual")
                          Case 89
                            wbsd.BudgetRemain = drh.GetValue(Of Decimal)("eqactual")
                          Case Else
                            wbsd.BudgetRemain = drh.GetValue(Of Decimal)("matactual")
                        End Select
                        'Trace.WriteLine(wbsd.WBS.Code & ":" & Configuration.FormatToString(wbsd.BudgetRemain, 2))
                      End If
                    End If

                    '--Qty Budget Remain =====================================================
                    Dim qtyRow() As DataRow = ds.Tables(4).Select("boqi_wbs=" & wbsd.WBS.Id)
                    If qtyRow.Length > 0 Then
                      Dim qtydrh As New DataRowHelper(qtyRow(0))
                      If wbsd.IsMarkup Then
                        wbsd.QtyRemain = 0
                      Else
                        If item.ItemType.Value = 88 OrElse item.ItemType.Value = 89 Then
                          wbsd.QtyRemain = 0
                        Else
                          wbsd.QtyRemain = qtydrh.GetValue(Of Decimal)("qtybudgetremain")
                        End If
                      End If
                    End If

                  Next
                End If
              Case 290 '�͡��� vo
                If ds.Tables(2).Rows.Count > 0 Then
                  For Each wbsRow As DataRow In ds.Tables(2).Select("voiw_sequence=" & sequence)
                    Dim wbsd As New WBSDistribute(wbsRow, "")
                    item.WBSDistributeCollection.Add(wbsd)

                    wbsd.BaseCost = item.ReceiveAmount

                    '--Budget Remain =========================================================
                    Dim budgetRow() As DataRow = ds.Tables(3).Select("wbs_id=" & wbsd.WBS.Id)
                    If budgetRow.Length > 0 Then
                      Dim drh As New DataRowHelper(budgetRow(0))
                      If wbsd.IsMarkup Then
                        wbsd.BudgetRemain = drh.GetValue(Of Decimal)("totalactual")
                      Else
                        Select Case item.ItemType.Value
                          Case 88, 289, 291
                            wbsd.BudgetRemain = drh.GetValue(Of Decimal)("labactual")
                          Case 89
                            wbsd.BudgetRemain = drh.GetValue(Of Decimal)("eqactual")
                          Case Else
                            wbsd.BudgetRemain = drh.GetValue(Of Decimal)("matactual")
                        End Select
                        'Trace.WriteLine(wbsd.WBS.Code & ":" & Configuration.FormatToString(wbsd.BudgetRemain, 2))
                      End If
                    End If

                    '--Qty Budget Remain =====================================================
                    Dim qtyRow() As DataRow = ds.Tables(4).Select("boqi_wbs=" & wbsd.WBS.Id)
                    If qtyRow.Length > 0 Then
                      Dim qtydrh As New DataRowHelper(qtyRow(0))
                      If wbsd.IsMarkup Then
                        wbsd.QtyRemain = 0
                      Else
                        If item.ItemType.Value = 88 OrElse item.ItemType.Value = 89 Then
                          wbsd.QtyRemain = 0
                        Else
                          wbsd.QtyRemain = qtydrh.GetValue(Of Decimal)("qtybudgetremain")
                        End If
                      End If
                    End If

                  Next
                End If
                'Case 291 '�͡��� dr  
                '  If ds.Tables(3).Rows.Count > 0 Then
                '    For Each wbsRow As DataRow In ds.Tables(3).Select("driw_sequence=" & sequence)
                '      Dim wbsd As New WBSDistribute(wbsRow, "")
                '      itm.WBSDistributeCollection.Add(wbsd)
                '    Next
                '  End If
            End Select


            ''�ӷ�� base ���º��������
            ''itm.Qty = itm.Qty - itm.ReceivedQty 'RemainingQty
            ''itm.Amount = itm.Amount - itm.ReceivedAmount 'RemainingAmount
            Dim oldAmount As Decimal = item.ReceiveAmount
            item.ReceiveAmount = oldAmount  '��ͧ������ MAT, LAB, EQ �ӹǳ��������������

            If item.ItemType.Value = 289 OrElse item.ItemType.Value = 160 OrElse item.ItemType.Value = 162 Then
            Else
              item.SetDefaulAccount()
            End If

            Me.ItemCollection.Add(item)
            'For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            '  Me.ItemCollection.SetBudgetRemain(wbsd, item)
            'Next

          Next
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

      Me.RefreshTaxBase()
    End Sub    Public Sub ClearSC()      Me.m_retentionRemaining = 0
      Me.m_retention = 0
      Me.m_discount = New Discount("")

      Me.ItemCollection.Clear()
    End Sub#End Region

#Region "RefreshTaxBase"
    Private m_taxGross As Decimal
    Public Sub RefreshTaxBase()
      m_gross = 0
      m_taxGross = 0
      m_taxbase = 0

      If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then        Return
      End If

      Dim sumAmountWithVat As Decimal = 0
      For Each item As PAItem In Me.ItemCollection
        If item.Level = 1 Then 'OrElse (item.Level = 0 AndAlso item.RefEntity.Id = 291) Then
          m_gross += item.Amount
          If Not item.UnVatable Then
            m_taxGross += item.Amount
            sumAmountWithVat += item.Amount
          End If
        End If
      Next      Select Case Me.TaxType.Value
        Case 0 '"�����"
          m_taxbase = 0
        Case 1 '"�¡"
          m_taxbase = sumAmountWithVat - Me.DiscountWithVat
          m_taxbase -= Me.AdvancePayItemCollection.GetExcludeVATAmountForCalculate 'CDec(IIf(Me.AdvancePay.TaxType.Value = 2, Me.AdvancePay.GetRemainExcludeVatAmount(Me.AdvancePayAmount), 0))
        Case 2 '"���"
          Dim a As Decimal = Vat.GetExcludedVatAmount(sumAmountWithVat, Me.TaxRate)
          Dim b As Decimal = Vat.GetExcludedVatAmount(Me.DiscountWithVat, Me.TaxRate)
          m_taxbase = a - b
          m_taxbase -= Me.AdvancePayItemCollection.GetExcludeVATAmountForCalculate 'CDec(IIf(Me.AdvancePay.TaxType.Value = 2, Me.AdvancePay.GetRemainExcludeVatAmount(Me.AdvancePayAmount), 0))
      End Select
    End Sub
    'Public Sub RefreshTaxBase()
    '  m_gross = 0
    '  m_taxGross = 0
    '  m_taxbase = 0

    '  If Me.ItemCollection Is Nothing OrElse Me.ItemCollection.Count = 0 Then
    '    Return
    '  End If

    '  Dim sumAmountWithVat As Decimal = 0
    '  For Each item As PAItem In Me.ItemCollection

    '    m_gross += item.TotalProgressReceive

    '    'If Not item.UnVatable Then
    '    'm_taxGross += item.Amount
    '    'sumAmountWithVat += item.Amount
    '    'End If
    '  Next
    '  Select Case Me.TaxType.Value
    '    Case 0 '"�����"
    '      m_taxbase = 0
    '    Case 1 '"�¡"
    '      m_taxbase = sumAmountWithVat - Me.DiscountWithVat
    '    Case 2 '"���"
    '      Dim a As Decimal = Vat.GetExcludedVatAmount(sumAmountWithVat, Me.TaxRate)
    '      Dim b As Decimal = Vat.GetExcludedVatAmount(Me.DiscountWithVat, Me.TaxRate)
    '      m_taxbase = a - b
    '  End Select
    'End Sub
    'Public ReadOnly Property DiscountWithVat() As Decimal
    '    Get
    '        If Me.Gross = 0 Then
    '            Return 0
    '        End If
    '        Return Configuration.Format(Me.DiscountAmount * Me.TaxGross / Me.Gross, DigitConfig.Price)
    '    End Get
    'End Property
#End Region

#Region "INewPrintableEntity"
    Public Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingColumnsEntries
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      dpiColl.RelationList.Add("general>pa_id>item>pai_pa")
      dpiColl.RelationList.Add("general>pa_id>Approve>ApprovePersonLevelNo")

      'dpiColl.RelationList.Add("item>pai_pa>allocate>pai_pa")
      dpiColl.RelationList.Add("item>pai_sequence>allocate>paiw_sequence")

      'dpiColl.RelationList.Add("item>pri_linenumber>UnitPrice>UnitPriceNo")
      'dpiColl.RelationList.Add("item>pri_linenumber>Unit>UnitNo")
      'dpiColl.RelationList.Add("item>pri_linenumber>Qty>QtyNo")
      'dpiColl.RelationList.Add("item>pri_linenumber>Name>NameNo")
      'dpiColl.RelationList.Add("item>pri_linenumber>Note>NoteNo")

      'dpiColl.RelationList.Add("Allocate>priw_linenumber>AllocateUnitPrice>UnitPriceNo")
      'dpiColl.RelationList.Add("Allocate>priw_linenumber>AllocateUnit>UnitNo")
      'dpiColl.RelationList.Add("Allocate>priw_linenumber>AllocateQty>QtyNo")
      'dpiColl.RelationList.Add("Allocate>priw_linenumber>AllocateName>NameNo")


      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pa_id", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Code", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("OtherDocCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("OtherDocDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CreditPeriod", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DueDate", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ContactPerson", "System.DateTime"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SCCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SCDocDate", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SCStartDate", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SCEndDate", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SCContractAmount", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("VOContractAmount", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SCReceivedAmount", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("VOReceivedAmount", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RequestorId", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RequestorInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RequestorCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RequestorName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorBillingAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorFax", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorPhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorMobilePhone", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorEmail", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SubContractorHomePage", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("CostCenterAddress", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceiverId", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceiverCode", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceiverName", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceiverInfo", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Note", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RealGross", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("GrossWoDR", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DiscountRate", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DiscountAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ContractDiscount", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("DiscountToDoc", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ContractAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ReceivedAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ContractAdvancePayAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("VContractAdvancePayAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AdvancePayAmountToDoc", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AdvancePayAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RealTaxBase", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("BeforeTax", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TaxBase", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TaxRate", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SCTaxAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SCTaxOutAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TaxAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("TaxType", "System.String"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SCWHTOutAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Contract Retention", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("VContract Retention", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("RetentionToDoc", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Retention", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AfterTax", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AfterTaxWithNoRetention", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("WitholdingTax", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SummarySCAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SummaryDRAmount", "System.Decimal"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("SummaryVOAmount", "System.Decimal"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonIdLevel", "System.String")) '--Last Approved--
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("AuthorizeId", "System.String")) '--Last Approved--

      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pa_id", "System.String", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonLevelNo", "System.String", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonCodeLevel", "System.String", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonNameLevel", "System.String", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonInfoLevel", "System.String", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonDateLevel", "System.DateTime", "Approve"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("ApprovePersonCommentLevel", "System.String", "Approve"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pai_pa", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pai_sequence", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ItemName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ContractAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ReceivedAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LineNumber", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.RefDocItemTypeName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.RefDocItemTypeDescription", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ItemType", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ItemCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCostCenter", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodePercent", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSCodeAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.WBSRemainQty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ContractQty", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ContractAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ReceivedQty", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ReceivedAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPrice", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Amount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.RemainingAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ProgressReceivedAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.CostAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.AllocateCCList", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.MatAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.LabAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.EqAmount", "System.Decimal", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.AccountCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.AccountName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.AccountInfo", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ItemNote", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ChildUnitCode", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ChildUnitName", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ChildQty", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ChildUnitPrice", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ChildAmount", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ChildMat", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ChildLab", "System.String", "Item"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.ChildEq", "System.String", "Item"))


      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("UnitPriceNo", "System.String", "UnitPrice"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPrice", "System.String", "UnitPrice"))

      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("UnitNo", "System.String", "Unit"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "Unit"))

      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("QtyNo", "System.String", "Qty"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "Qty"))

      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("NameNo", "System.String", "Name"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "Name"))

      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("NoteNo", "System.String", "Note"))
      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Note", "System.String", "Note"))

      dpiColl.AddRange(GetAllocateDocPrintingColumns)

      Return dpiColl
    End Function
    Public Function GetAllocateDocPrintingColumns() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection

      'dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pai_pa", "System.String", "Allocate"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("pai_wsequence", "System.String", "Allocate"))
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

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPriceNo", "System.String", "AllocateUnitPrice"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitPrice", "System.String", "AllocateUnitPrice"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.UnitNo", "System.String", "AllocateUnit"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Unit", "System.String", "AllocateUnit"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.QtyNo", "System.String", "AllocateQty"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Qty", "System.String", "AllocateQty"))

      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.NameNo", "System.String", "AllocateName"))
      dpiColl.Add(EntitySimpleSchema.NewDocPrintingItem("Item.Name", "System.String", "AllocateName"))

      Return dpiColl
    End Function
    Public Function GetDocPrintingDataEntries() As DocPrintingItemCollection Implements INewPrintableEntity.GetDocPrintingDataEntries
      Return Me.GetDocPrintingEntries
    End Function
#End Region


#Region "IPrintableEntity"
    Public Function GetDefaultFormPath() As String Implements IPrintableEntity.GetDefaultFormPath
      Return "C:\Documents and Settings\Administrator\Desktop\Forms\Documents\PA.dfm"
    End Function
    Public Function GetDefaultForm() As String Implements IPrintableEntity.GetDefaultForm

    End Function
    Public Function GetDocPrintingEntries() As DocPrintingItemCollection Implements IPrintableEntity.GetDocPrintingEntries
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem
      Me.RefreshTaxBase()

      'pa_id
      dpi = New DocPrintingItem
      dpi.Mapping = "pa_id"
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

      'OtherDocCode
      dpi = New DocPrintingItem
      dpi.Mapping = "OtherDocCode"
      dpi.Value = Me.OtherDocCode
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'OtherDocDate
      dpi = New DocPrintingItem
      dpi.Mapping = "OtherDocDate"
      dpi.Value = Me.OtherDocDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'CreditPeriod
      dpi = New DocPrintingItem
      dpi.Mapping = "CreditPeriod"
      dpi.Value = Configuration.FormatToString(Me.CreditPeriod, DigitConfig.Int)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DueDate
      dpi = New DocPrintingItem
      dpi.Mapping = "DueDate"
      dpi.Value = Me.DueDate.ToShortDateString
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      'ContactPerson
      dpi = New DocPrintingItem
      dpi.Mapping = "ContactPerson"
      dpi.Value = Me.ContactPerson
      dpi.DataType = "System.DateTime"
      dpiColl.Add(dpi)

      If Not Me.Sc Is Nothing Then
        'SCCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SCCode"
        dpi.Value = Me.Sc.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SCDocDate
        dpi = New DocPrintingItem
        dpi.Mapping = "SCDocDate"
        dpi.Value = Me.Sc.DocDate.ToShortDateString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SCStartDate
        dpi = New DocPrintingItem
        dpi.Mapping = "SCStartDate"
        dpi.Value = Me.Sc.StartDate.ToShortDateString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SCEndDate
        dpi = New DocPrintingItem
        dpi.Mapping = "SCEndDate"
        dpi.Value = Me.Sc.EndDate.ToShortDateString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        Dim scr As ContractReceiveStruct = Me.GetContractReceived '--Contract Receieved-- ============
        'SCContractAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "SCContractAmount"
        dpi.Value = Configuration.FormatToString(scr.SCContractAmount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'VOContractAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "VOContractAmount"
        dpi.Value = Configuration.FormatToString(scr.VOContractAmount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SCReceivedAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "SCReceivedAmount"
        dpi.Value = Configuration.FormatToString(scr.SCReceivedAmount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'VOReceivedAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "VOReceivedAmount"
        dpi.Value = Configuration.FormatToString(scr.VOReceivedAmount, DigitConfig.Price)
        dpi.DataType = "System.String"
        dpiColl.Add(dpi) '--Contract Receieved-- =======================================================

        If Not Me.Sc.Director Is Nothing AndAlso Me.Sc.Director.Originated Then
          'RequestorId
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorId"
          dpi.Value = Me.Sc.Director.Id
          dpi.DataType = "System.String"
          dpi.SignatureType = SignatureType.Person
          dpiColl.Add(dpi)

          'RequestorInfo
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorInfo"
          dpi.Value = Me.Sc.Director.Code & ":" & Me.Sc.Director.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RequestorCode
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorCode"
          dpi.Value = Me.Sc.Director.Code
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          'RequestorName
          dpi = New DocPrintingItem
          dpi.Mapping = "RequestorName"
          dpi.Value = Me.Sc.Director.Name
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)
        End If
      End If

      If Not Me.SubContractor Is Nothing Then
        'SubContractorCode
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorCode"
        dpi.Value = Me.SubContractor.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorName
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorName"
        dpi.Value = Me.SubContractor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorInfo"
        dpi.Value = Me.SubContractor.Code & ":" & Me.SubContractor.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorAddredss
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorAddress"
        dpi.Value = Me.SubContractor.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorBillingAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorBillingAddress"
        dpi.Value = Me.SubContractor.BillingAddress
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorFax
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorFax"
        dpi.Value = Me.SubContractor.Fax
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorPhone
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorPhone"
        dpi.Value = Me.SubContractor.Phone
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorMobile
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorMobilePhone"
        dpi.Value = Me.SubContractor.Mobile.ToString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorEmail
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorEmail"
        dpi.Value = Me.SubContractor.EmailAddress.ToString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'SubContractorHomePage
        dpi = New DocPrintingItem
        dpi.Mapping = "SubContractorHomePage"
        dpi.Value = Me.SubContractor.HomePage.ToString
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.CostCenter Is Nothing Then
        'CostCenterCode
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterCode"
        dpi.Value = Me.CostCenter.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterName
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterName"
        dpi.Value = Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterInfo"
        dpi.Value = Me.CostCenter.Code & ":" & Me.CostCenter.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'CostCenterAddress
        dpi = New DocPrintingItem
        dpi.Mapping = "CostCenterAddress"
        dpi.Value = Me.CostCenter.Address
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      If Not Me.Receiver Is Nothing Then
        'ReceiverId
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceiverId"
        dpi.Value = Me.Receiver.Id
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.Person
        dpiColl.Add(dpi)

        'ReceiverCode
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceiverCode"
        dpi.Value = Me.Receiver.Code
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReceiverName
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceiverName"
        dpi.Value = Me.Receiver.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'ReceiverInfo
        dpi = New DocPrintingItem
        dpi.Mapping = "ReceiverInfo"
        dpi.Value = Me.Receiver.Code & ":" & Me.Receiver.Name
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)
      End If

      'Note
      dpi = New DocPrintingItem
      dpi.Mapping = "Note"
      dpi.Value = Me.Note
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)


      'Mapping ���͹��ѵ� #917
      Dim appIdLevelHs1 As New Hashtable
      Dim appIdLevelHs2 As New Hashtable
      Dim appTable As DataTable = BusinessEntity.GetApprovePersonListfromDoc(Me.Id, Me.EntityId)
      If appTable.Rows.Count > 0 Then
        For Each row As DataRow In appTable.Rows
          Dim deh As New DataRowHelper(row)
          If Not appIdLevelHs1.ContainsKey(deh.GetValue(Of Integer)("apvdoc_level").ToString) Then
            appIdLevelHs1.Add(deh.GetValue(Of Integer)("apvdoc_level").ToString, row)
          Else
            appIdLevelHs1(deh.GetValue(Of Integer)("apvdoc_level").ToString) = row
          End If
        Next

        For Each row As DataRow In appIdLevelHs1.Values 'appTable.Rows
          Dim deh As New DataRowHelper(row)
          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonNameLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_name")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonCodeLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_code")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonInfoLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of String)("user_name") & ":" & deh.GetValue(Of String)("user_code")
          dpi.DataType = "System.String"
          dpiColl.Add(dpi)

          dpi = New DocPrintingItem
          dpi.Mapping = "ApprovePersonDateLevel " & deh.GetValue(Of Integer)("apvdoc_level").ToString
          dpi.Value = deh.GetValue(Of Date)("apvdate").ToShortDateString
          dpi.DataType = "System.DateTime"
          dpiColl.Add(dpi)
        Next

      End If

      Dim LastLevelApprove As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        'If ap.Level > 0 AndAlso Not ap.Reject Then
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso Not LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        For Each ap As ApproveDoc In LastLevelApprove
          If Not ap.Reject Then
            If Not appIdLevelHs2.ContainsKey(ap.Level.ToString) Then
              appIdLevelHs2.Add(ap.Level.ToString, ap)
            Else
              appIdLevelHs2(ap.Level.ToString) = ap
            End If
          End If
        Next
        For Each ap As ApproveDoc In appIdLevelHs2.Values 'LastLevelApprove
          If Not ap.Reject Then
            dpi = New DocPrintingItem
            dpi.Mapping = "ApprovePersonIdLevel " & ap.Level.ToString
            dpi.Value = ap.Originator
            dpi.DataType = "System.String"
            dpi.SignatureType = SignatureType.ApprovePerson
            dpiColl.Add(dpi)
          End If
        Next

        'Authorizeid
        dpi = New DocPrintingItem
        dpi.Mapping = "AuthorizeId"
        If Me.IsApproved Then
          dpi.Value = Me.ApprovePerson.Id
        Else
          dpi.Value = 0
        End If
        dpi.DataType = "System.String"
        dpi.SignatureType = SignatureType.AuthorizedPerson
        dpiColl.Add(dpi)
      End If

      'RealGross
      dpi = New DocPrintingItem
      dpi.Mapping = "RealGross"
      dpi.Value = Configuration.FormatToString(Me.RealGross, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'GrossWoDR
      dpi = New DocPrintingItem
      dpi.Mapping = "GrossWoDR"
      dpi.Value = Configuration.FormatToString(Me.GrossWODR, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      If Not Me.Discount Is Nothing Then
        'DiscountRate
        dpi = New DocPrintingItem
        dpi.Mapping = "DiscountRate"
        dpi.Value = Me.Discount.Rate
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        'DiscountAmount
        dpi = New DocPrintingItem
        dpi.Mapping = "DiscountAmount"
        dpi.Value = Configuration.FormatToString(Me.Discount.Amount, DigitConfig.Price)
        dpi.DataType = "System.Decimal"
        dpiColl.Add(dpi)
      End If

      'ContractDiscount
      dpi = New DocPrintingItem
      dpi.Mapping = "ContractDiscount"
      dpi.Value = Configuration.FormatToString(Me.GetContractDistCount, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'DiscounttoDoc
      dpi = New DocPrintingItem
      dpi.Mapping = "DiscountToDoc"
      dpi.Value = Configuration.FormatToString(Me.GetDistCountToDoc, DigitConfig.Price)
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      ''Contract QTY  
      'dpi = New DocPrintingItem
      'dpi.Mapping = "ContractQty"
      'dpi.Value = Configuration.FormatToString(Me.ItemCollection.SumQtyContractAmount, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpiColl.Add(dpi)

      'Contract Amount 
      dpi = New DocPrintingItem
      dpi.Mapping = "ContractAmount"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.SumContractAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      ''Received QTY  
      'dpi = New DocPrintingItem
      'dpi.Mapping = "ReceivedQty"
      'dpi.Value = Configuration.FormatToString(Me.ItemCollection.SumQtyReceived, DigitConfig.Price)
      'dpi.DataType = "System.Decimal"
      'dpiColl.Add(dpi)

      'Received Amount 
      dpi = New DocPrintingItem
      dpi.Mapping = "ReceivedAmount"
      dpi.Value = Configuration.FormatToString(Me.ItemCollection.SumReceivedAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'ContractAdvancePayAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "ContractAdvancePayAmount"
      dpi.Value = Configuration.FormatToString(Me.Sc.AdvancePay, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'VContractAdvancePayAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "VContractAdvancePayAmount"
      dpi.Value = Configuration.FormatToString(Me.GetVOAdvancePayAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AdvancePayAmountTodate
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvancePayAmountToDoc"
      dpi.Value = Configuration.FormatToString(Me.AdvancePayToDoc, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AdvancePayAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "AdvancePayAmount"
      dpi.Value = Configuration.FormatToString(Me.AdvancePay, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'RealTaxBase
      dpi = New DocPrintingItem
      dpi.Mapping = "RealTaxBase"
      dpi.Value = Configuration.FormatToString(Me.RealTaxBase, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'BeforeTax
      dpi = New DocPrintingItem
      dpi.Mapping = "BeforeTax"
      dpi.Value = Configuration.FormatToString(Me.BeforeTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxBase
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxBase"
      dpi.Value = Configuration.FormatToString(Me.TaxBase, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxRate
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxRate"
      dpi.Value = Configuration.FormatToString(Me.TaxRate, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'SCTaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SCTaxAmount"
      dpi.Value = Configuration.FormatToString(Me.GetSCVat, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'SCTaxOutAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SCTaxOutAmount"
      dpi.Value = Configuration.FormatToString(Me.GetSCVatOut, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxAmount"
      dpi.Value = Configuration.FormatToString(Me.TaxAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'TaxType
      dpi = New DocPrintingItem
      dpi.Mapping = "TaxType"
      dpi.Value = Me.TaxType.Description
      dpi.DataType = "System.String"
      dpiColl.Add(dpi)

      'SCWithHoldingTaxOutAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SCWHTOutAmount"
      dpi.Value = Configuration.FormatToString(Me.GetSCWhtOut, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'Contract Retention
      dpi = New DocPrintingItem
      dpi.Mapping = "Contract Retention"
      dpi.Value = Configuration.FormatToString(Me.Sc.Retention, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'VContract Retention
      dpi = New DocPrintingItem
      dpi.Mapping = "VContract Retention"
      dpi.Value = Configuration.FormatToString(Me.GetVORetention, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'Retentiontodate
      dpi = New DocPrintingItem
      dpi.Mapping = "RetentionToDoc"
      dpi.Value = Configuration.FormatToString(Me.RetentionToDoc, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'Retention
      dpi = New DocPrintingItem
      dpi.Mapping = "Retention"
      dpi.Value = Configuration.FormatToString(Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AfterTax
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTax"
      dpi.Value = Configuration.FormatToString(Me.AfterTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'AfterTaxWithNoRetention
      dpi = New DocPrintingItem
      dpi.Mapping = "AfterTaxWithNoRetention"
      dpi.Value = Configuration.FormatToString(Me.AfterTax - Me.Retention, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'WitholdingTax
      dpi = New DocPrintingItem
      dpi.Mapping = "WitholdingTax"
      dpi.Value = Configuration.FormatToString(Me.WitholdingTax, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'Dim ScRefItem As New ArrayList
      'Dim DrRefItem As New ArrayList
      'Dim VoRefItem As New ArrayList
      'Dim NotRefItem As New ArrayList

      Dim scAmount As Decimal
      Dim drAmount As Decimal
      Dim voAmount As Decimal
      For Each item As PAItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
          If item.Level <> 0 Then
            If item.RefEntity.Id = 0 Then

            ElseIf item.RefEntity.Id = 291 Then
              drAmount += item.Amount
            ElseIf item.RefEntity.Id = 290 Then
              voAmount += item.Amount
            ElseIf item.RefEntity.Id = 289 Then
              scAmount += item.Amount
            End If
          End If
        End If
      Next

      'SummarySCAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SummarySCAmount"
      dpi.Value = Configuration.FormatToString(scAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'SummaryDRAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryDRAmount"
      dpi.Value = Configuration.FormatToString(drAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      'SummaryVOAmount
      dpi = New DocPrintingItem
      dpi.Mapping = "SummaryVOAmount"
      dpi.Value = Configuration.FormatToString(voAmount, DigitConfig.Price)
      dpi.DataType = "System.Decimal"
      dpiColl.Add(dpi)

      dpiColl.AddRange(GetDocPrintingItemsEntries)
      dpiColl.AddRange(GetAllocateDocPrinting)

      Return dpiColl
    End Function
    Public Function GetDocPrintingItemsEntries() As DocPrintingItemCollection
      Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Dim RefItem As New ArrayList
      Dim DrRefItem As New ArrayList
      Dim NotRefItem As New ArrayList
      For Each item As PAItem In Me.ItemCollection
        If item.RefEntity.Id = 0 Then
          NotRefItem.Add(item)
        ElseIf item.RefEntity.Id = 291 Then
          DrRefItem.Add(item)
        Else
          RefItem.Add(item)
        End If
      Next

      Dim RefDocItemType As String
      Dim LineNumber As Integer = 0
      Dim RowNumber As Integer = 0
      Dim ParentLineNumber As Integer = 0
      Dim ChildLineNumber As Integer = 0
      Dim newItem As PAItem = Nothing
      Dim newDRItem As PAItem = Nothing
      Dim RealItems As New ArrayList
      Dim fn As Font '= New System.Drawing.Font("Tahoma", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim fnBold As Font = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
      Dim indent As String = ""

      For i As Integer = 0 To 2
        RealItems.Clear()
        If i = 0 Then
          For Each x As PAItem In RefItem
            RealItems.Add(x)
          Next
        ElseIf i = 1 Then
          For Each x As PAItem In DrRefItem
            RealItems.Add(x)
          Next
        ElseIf i = 2 Then
          For Each x As PAItem In NotRefItem
            RealItems.Add(x)
          Next
        End If

        For Each item As PAItem In RealItems
          If item.ItemType.Value = 289 Then
            fn = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            indent = Space(0)
          Else
            fn = New System.Drawing.Font("CordiaUPC", 13.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(222, Byte))
            indent = Space(2)
          End If
          If item.RefEntity.Id = 291 Then
            If newDRItem Is Nothing Then
              newDRItem = New PAItem
              newDRItem.RefEntity = New RefEntity
              newDRItem.RefEntity.Id = 291
              newDRItem.TotalBudget = item.ContractCostAmount
              newDRItem.TotalReceived = item.ReceivedAmount
              newDRItem.TotalProgressReceive = item.Amount
            Else
              newDRItem.TotalBudget += item.ContractCostAmount
              newDRItem.TotalReceived += item.ReceivedAmount
              newDRItem.TotalProgressReceive += item.Amount
            End If
          End If

          'RowNumber += 1

          ''pa
          'dpi = New DocPrintingItem
          'dpi.Mapping = "pa_id"
          'dpi.Value = Me.Id
          'dpi.DataType = "System.String"
          'dpi.Table = "Item"
          'dpi.Font = fnBold
          'dpi.Row = RowNumber
          'dpiColl.Add(dpi)

          If item.Level = 0 OrElse (item.Level = 1 AndAlso item.RefEntity.Id = 291) Then
            If Not newItem Is Nothing AndAlso newItem.RefEntity.Id <> 291 Then
              RowNumber += 1

              dpi = New DocPrintingItem
              dpi.Mapping = "pai_pa"
              dpi.Value = Me.Id
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              dpi = New DocPrintingItem
              dpi.Mapping = "pai_sequence"
              dpi.Value = item.Sequence
              dpi.DataType = "System.String"
              dpi.Row = i + 1
              dpi.Table = "Item"
              dpiColl.Add(dpi)


              'ItemName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.ItemName"
              dpi.Value = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCItemAmount}")  '"���" 
              dpi.DataType = "System.String"
              dpi.Table = "Item"
              dpi.Font = fnBold
              dpi.Row = RowNumber
              dpiColl.Add(dpi)

              'ContractAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.ContractAmount"
              dpi.Value = Configuration.FormatToString(newItem.TotalBudget, DigitConfig.Price)
              dpi.DataType = "System.Decimal"
              dpi.Table = "Item"
              dpi.Font = fnBold
              dpi.Row = RowNumber
              dpiColl.Add(dpi)

              'ReceivedAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.ReceivedAmount"
              dpi.Value = Configuration.FormatToString(newItem.TotalReceived, DigitConfig.Price)
              dpi.DataType = "System.Decimal"
              dpi.Table = "Item"
              dpi.Font = fnBold
              dpi.Row = RowNumber
              dpiColl.Add(dpi)

              'Amount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.Amount"
              dpi.Value = Configuration.FormatToString(newItem.TotalProgressReceive, DigitConfig.Price)
              dpi.DataType = "System.Decimal"
              dpi.Table = "Item"
              dpi.Font = fnBold
              dpi.Row = RowNumber
              dpiColl.Add(dpi)

            End If

            newItem = item
          End If

          LineNumber += 1
          RowNumber += 1
          If item.ItemType.Value = 289 Then
            ParentLineNumber += 1
            ChildLineNumber = 0
          Else
            If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
              ChildLineNumber += 1
            End If
          End If

          'LineNumber
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LineNumber"
          If item.ItemType.Value = 289 Then
            dpi.Value = ParentLineNumber
          Else
            If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 Then
              dpi.Value = ParentLineNumber.ToString & "." & ChildLineNumber.ToString
            Else
              dpi.Value = ""
            End If
          End If
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'RefDocItemTypeName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.RefDocItemTypeName"
          dpi.Value = item.RefEntity.Name
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'RefDocItemTypeDescription
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.RefDocItemTypeDescription"
          Select Case item.RefEntity.Id
            Case 289
              dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.SC.DetailLabel}")
            Case 290
              dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.VO.DetailLabel}")
            Case 291
              dpi.Value = Me.StringParserService.Parse("${res:Longkong.Pojjaman.BusinessLogic.DR.DetailLabel}")
          End Select
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'ItemType
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ItemType"
          dpi.Value = item.ItemType.Description
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          If item.ItemType.Value = 289 Then
            'ItemCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ItemCode"
            dpi.Value = ""
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'ItemName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ItemName"
            dpi.Value = indent & item.EntityName.Trim
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)
          Else
            'ItemCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ItemCode"
            dpi.Value = item.Entity.Code
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'ItemName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ItemName"
            If Not item.Entity Is Nothing Then
              If item.ItemType.Value = 0 Then
                dpi.Value = indent & item.EntityName.Trim
              Else
                If item.EntityName IsNot Nothing AndAlso item.EntityName.Length > 0 Then
                  dpi.Value = indent & item.EntityName.Trim
                Else
                  dpi.Value = indent & item.Entity.Name.Trim
                End If
              End If
            Else
              dpi.Value = indent & item.EntityName.Trim
            End If
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            If item.Level = 1 Then
              '--------------------- WBS Section ------------------
              Dim WBSCostCenter As String = ""
              Dim WBSCode As String = ""
              Dim WBSName As String = ""
              Dim WBSCodePercent As String = ""
              Dim WBSCodeAmount As String = ""
              Dim WBSRemainAmount As String = ""
              Dim WBSRemainQty As String = ""

              Dim hashWBS As New Hashtable
              Dim hashWBSItem As New Hashtable
              Dim key As String = ""
              Dim itemKey As String = ""

              If item.WBSDistributeCollection.Count > 0 Then
                'Populate ���ӹǳ�������Ẻ��͡�
                'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)


                If item.WBSDistributeCollection.Count = 1 Then

                  key = item.WBSDistributeCollection.Item(0).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Id.ToString & ":" & item.AllocationType
                  itemKey = item.WBSDistributeCollection.Item(0).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(0).CostCenter.Id.ToString & ":" & item.Description & ":" & item.AllocationType

                  'Amount -----------------------------------------------------
                  If Not hashWBS.Contains(key) Then
                    item.WBSDistributeCollection.Item(0).RemainSummary = item.WBSDistributeCollection.Item(0).BudgetRemain - (item.WBSDistributeCollection.Item(0).Amount + item.WBSDistributeCollection.Item(0).ChildAmount)
                    hashWBS(key) = item.WBSDistributeCollection.Item(0)
                  Else
                    Dim parWBS As WBSDistribute = CType(hashWBS(key), WBSDistribute)
                    item.WBSDistributeCollection.Item(0).RemainSummary = parWBS.RemainSummary - (item.WBSDistributeCollection.Item(0).Amount + item.WBSDistributeCollection.Item(0).ChildAmount)
                    CType(hashWBS(key), WBSDistribute).RemainSummary = item.WBSDistributeCollection.Item(0).RemainSummary
                  End If
                  'Qty --------------------------------------------------------
                  If Not hashWBSItem.Contains(itemKey) Then
                    item.WBSDistributeCollection.Item(0).QtyRemainSummary = item.WBSDistributeCollection.Item(0).QtyRemain - item.WBSDistributeCollection.Item(0).Qty
                    hashWBSItem(itemKey) = item.WBSDistributeCollection.Item(0)
                  Else
                    Dim parWBS As WBSDistribute = CType(hashWBSItem(itemKey), WBSDistribute)
                    item.WBSDistributeCollection.Item(0).QtyRemainSummary = parWBS.QtyRemainSummary - item.WBSDistributeCollection.Item(0).Qty
                    CType(hashWBSItem(itemKey), WBSDistribute).QtyRemainSummary = item.WBSDistributeCollection.Item(0).QtyRemainSummary
                  End If

                  WBSCostCenter = item.WBSDistributeCollection.Item(0).CostCenter.Code & ":" & _
                  item.WBSDistributeCollection.Item(0).CostCenter.Name 'Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
                  WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
                  WBSName = item.WBSDistributeCollection.Item(0).WBS.Name
                  WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%"
                  WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price)
                                    WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).RemainSummary, DigitConfig.Price)
                                    WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemainSummary, DigitConfig.Price)
                Else
                  Dim j As Integer
                  For j = 0 To item.WBSDistributeCollection.Count - 1

                    key = item.WBSDistributeCollection.Item(j).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(j).CostCenter.Id.ToString & ":" & item.AllocationType
                    itemKey = item.WBSDistributeCollection.Item(j).WBS.Id.ToString & ":" & item.WBSDistributeCollection.Item(j).CostCenter.Id.ToString & ":" & item.Description & ":" & item.AllocationType

                    'Amount -----------------------------------------------------
                    If Not hashWBS.Contains(key) Then
                      item.WBSDistributeCollection.Item(j).RemainSummary = item.WBSDistributeCollection.Item(j).BudgetRemain - (item.WBSDistributeCollection.Item(j).Amount + item.WBSDistributeCollection.Item(j).ChildAmount)
                      hashWBS(key) = item.WBSDistributeCollection.Item(j)
                    Else
                      Dim parWBS As WBSDistribute = CType(hashWBS(key), WBSDistribute)
                      item.WBSDistributeCollection.Item(j).RemainSummary = parWBS.RemainSummary - (item.WBSDistributeCollection.Item(j).Amount + item.WBSDistributeCollection.Item(j).ChildAmount)
                      CType(hashWBS(key), WBSDistribute).RemainSummary = item.WBSDistributeCollection.Item(j).RemainSummary
                    End If
                    'Qty --------------------------------------------------------
                    If Not hashWBSItem.Contains(itemKey) Then
                      item.WBSDistributeCollection.Item(j).QtyRemainSummary = item.WBSDistributeCollection.Item(j).QtyRemain - item.WBSDistributeCollection.Item(j).Qty
                      hashWBSItem(itemKey) = item.WBSDistributeCollection.Item(j)
                    Else
                      Dim parWBS As WBSDistribute = CType(hashWBSItem(itemKey), WBSDistribute)
                      item.WBSDistributeCollection.Item(j).QtyRemainSummary = parWBS.QtyRemainSummary - item.WBSDistributeCollection.Item(j).Qty
                      CType(hashWBSItem(itemKey), WBSDistribute).QtyRemainSummary = item.WBSDistributeCollection.Item(j).QtyRemainSummary
                    End If

                    WBSCostCenter &= item.WBSDistributeCollection.Item(j).CostCenter.Code & ":" & _
                    item.WBSDistributeCollection.Item(j).CostCenter.Name ' & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
                    WBSCode &= item.WBSDistributeCollection.Item(j).WBS.Code
                    WBSName &= item.WBSDistributeCollection.Item(j).WBS.Name
                    WBSCodePercent &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Percent, DigitConfig.Price)
                    WBSCodeAmount &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Amount, DigitConfig.Price)
                    WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).RemainSummary, DigitConfig.Price)
                    WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).QtyRemainSummary, DigitConfig.Price)
                    If j < item.WBSDistributeCollection.Count - 1 Then
                      WBSCostCenter &= ", "
                      'WBSCostCentern &= ", "
                      WBSCode &= ", "
                      WBSName &= ", "
                      WBSCodePercent &= ", "
                      WBSCodeAmount &= ", "
                      WBSRemainAmount &= ", "
                      WBSRemainQty &= ", "
                    End If
                  Next
                End If
              End If

              'Item.WBSCostCenter
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.WBSCostCenter"
              dpi.Value = WBSCostCenter
              dpi.DataType = "System.String"
              dpi.Row = RowNumber
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.WBSCode
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.WBSCode"
              dpi.Value = WBSCode
              dpi.DataType = "System.String"
              dpi.Row = RowNumber
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.WBSName
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.WBSName"
              dpi.Value = WBSName
              dpi.DataType = "System.String"
              dpi.Row = RowNumber
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.WBSCodePercent
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.WBSCodePercent"
              dpi.Value = WBSCodePercent
              dpi.DataType = "System.String"
              dpi.Row = RowNumber
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.WBSCodeAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.WBSCodeAmount"
              dpi.Value = WBSCodeAmount
              dpi.DataType = "System.String"
              dpi.Row = RowNumber
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.WBSRemainAmount
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.WBSRemainAmount"
              dpi.Value = WBSRemainAmount
              dpi.DataType = "System.String"
              dpi.Row = RowNumber
              dpi.Table = "Item"
              dpiColl.Add(dpi)

              'Item.WBSRemainQty
              dpi = New DocPrintingItem
              dpi.Mapping = "Item.WBSRemainQty"
              dpi.Value = WBSRemainQty
              dpi.DataType = "System.String"
              dpi.Row = RowNumber
              dpi.Table = "Item"
              dpiColl.Add(dpi)
              '--------------------- WBS Section ------------------
            End If
          End If

          'UnitCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitCode"
          dpi.Value = item.Unit.Code
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'UnitName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitName"
          dpi.Value = item.Unit.Name
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)
          If item.ItemType.Value <> 289 Then
            'ContractQty
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ContractQty"
            dpi.Value = Configuration.FormatToString(item.ContractQtyCostAmount, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'ContractAmount
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ContractAmount"
            dpi.Value = Configuration.FormatToString(item.ContractCostAmount, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'ReceivedQty
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ReceivedQty"
            dpi.Value = Configuration.FormatToString(item.ReceivedQty, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'ReceivedAmount
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ReceivedAmount"
            dpi.Value = Configuration.FormatToString(item.ReceivedAmount, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'Qty
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Qty"
            dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'UnitPrice
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.UnitPrice"
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'Amount
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.Amount"
            dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'RemainingAmount
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.RemainingAmount"
            dpi.Value = Configuration.FormatToString(item.ContractCostAmount - item.ReceivedAmount - item.Amount, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'ProgressReceivedAmount
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ProgressReceivedAmount"
            dpi.Value = Configuration.FormatToString(item.TotalProgressReceive, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'CostAmount
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.CostAmount"
            dpi.Value = Configuration.FormatToString(item.CostAmount, DigitConfig.Price)
            dpi.Font = fn
            dpi.DataType = "System.Decimal"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)
          End If


          Dim ccList As String = ""
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            ccList &= wbsd.CostCenter.Code & " " & Configuration.FormatToString(wbsd.Percent, DigitConfig.Price) & "%, "
          Next
          If ccList.Length > 2 Then
            ccList = ccList.Substring(0, ccList.Length - 2)
          End If
          If ccList.Length > 0 Then
            'AllocateCostCenterList
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.AllocateCCList"
            dpi.Value = ccList
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)
          End If

          'MatAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.MatAmount"
          dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'LabAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.LabAmount"
          dpi.Value = Configuration.FormatToString(item.Lab, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'EqAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.EqAmount"
          dpi.Value = Configuration.FormatToString(item.Eq, DigitConfig.Price)
          dpi.Font = fn
          dpi.DataType = "System.Decimal"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          If Not item.MatAccount Is Nothing Then
            'AccountCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.AccountCode"
            dpi.Value = item.MatAccount.Code
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'AccountName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.AccountName"
            dpi.Value = item.MatAccount.Name
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)

            'AccountInfo
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.AccountInfo"
            dpi.Value = item.MatAccount.Code & ":" & item.MatAccount.Name
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Table = "Item"
            dpi.Row = RowNumber
            dpiColl.Add(dpi)
          End If

          'ItemNote
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ItemNote"
          dpi.Value = item.Note
          dpi.Font = fn
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'Ẻ����ʴ�����ҳ �Ҥ� ��Ť�� MAT LAB EQ Receipt �����¡����觨�ҧ =========================================================================
          If item.Level = 1 Then

            'Item.ChildUnitCode
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ChildUnitCode"
            If item.Unit Is Nothing Then
              dpi.Value = ""
            Else
              dpi.Value = item.Unit.Code
            End If
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Row = RowNumber
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.ChildUnitName
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ChildUnitName"
            If item.Unit Is Nothing Then
              dpi.Value = ""
            Else
              dpi.Value = item.Unit.Name
            End If
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Row = RowNumber
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.ChildQty
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ChildQty"
            If item.Qty = 0 Then
              dpi.Value = ""
            Else
              dpi.Value = Configuration.FormatToString(item.Qty, DigitConfig.Qty)
            End If
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Row = RowNumber
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.ChildUnitPrice
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ChildUnitPrice"
            If item.UnitPrice = 0 Then
              dpi.Value = ""
            Else
              dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
            End If
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Row = RowNumber
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.ChildAmount
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ChildAmount"
            If item.Amount = 0 Then
              dpi.Value = ""
            Else
              dpi.Value = Configuration.FormatToString(item.Amount, DigitConfig.Price)
            End If
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Row = RowNumber
            dpi.Table = "Item"
            dpiColl.Add(dpi)
            'End If

            'Item.ChildMat
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ChildMat"
            If item.Amount = 0 Then
              dpi.Value = ""
            Else
              dpi.Value = Configuration.FormatToString(item.Mat, DigitConfig.Price)
            End If
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Row = RowNumber
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.ChildLab
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ChildLab"
            If item.Amount = 0 Then
              dpi.Value = ""
            Else
              dpi.Value = Configuration.FormatToString(item.Lab, DigitConfig.Price)
            End If
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Row = RowNumber
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            'Item.ChildEq
            dpi = New DocPrintingItem
            dpi.Mapping = "Item.ChildEq"
            If item.Amount = 0 Then
              dpi.Value = ""
            Else
              dpi.Value = Configuration.FormatToString(item.Eq, DigitConfig.Price)
            End If
            dpi.Font = fn
            dpi.DataType = "System.String"
            dpi.Row = RowNumber
            dpi.Table = "Item"
            dpiColl.Add(dpi)

            ''Item.ChildOrderedAmount
            'dpi = New DocPrintingItem
            'dpi.Mapping = "Item.ChildOrderedAmount"
            'If item.Amount = 0 Then
            '  dpi.Value = ""
            'Else
            '  dpi.Value = Configuration.FormatToString(item.OrderedAmount, DigitConfig.Price)
            'End If
            'dpi.Font = fn
            'dpi.DataType = "System.String"
            'dpi.Row = i + 1
            'dpi.Table = "Item"
            'dpiColl.Add(dpi)

          End If
          'Ẻ����ʴ�����ҳ �Ҥ� ��Ť�� MAT LAB EQ Receipt �����¡����觨�ҧ =========================================================================

        Next

        If Not newDRItem Is Nothing Then
          RowNumber += 1

          'ItemName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ItemName"
          dpi.Value = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCItemAmount}")  '"���" 
          dpi.Font = fnBold
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'ContractAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ContractAmount"
          dpi.Value = Configuration.FormatToString(newDRItem.TotalBudget, DigitConfig.Price)
          dpi.Font = fnBold
          dpi.DataType = "System.Decimal"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'ReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ReceivedAmount"
          dpi.Value = Configuration.FormatToString(newDRItem.TotalReceived, DigitConfig.Price)
          dpi.Font = fnBold
          dpi.DataType = "System.Decimal"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          dpi.Value = Configuration.FormatToString(newDRItem.TotalProgressReceive, DigitConfig.Price)
          dpi.Font = fnBold
          dpi.DataType = "System.Decimal"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          newDRItem = Nothing
        End If

      Next

      If Not newItem Is Nothing Then
        If Not (Not DrRefItem Is Nothing AndAlso DrRefItem.Count > 0) OrElse (Not NotRefItem Is Nothing AndAlso NotRefItem.Count > 0) Then
          '����������¡�� DR ��������¡�� ����������ҧ�ԧ SC ����� Collection ���Ǥ��·����ǹ��� 
          RowNumber += 1

          'ItemName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ItemName"
          dpi.Value = myStringParserService.Parse("${res:Longkong.Pojjaman.Gui.Panels.PAPanelView.SCItemAmount}")  '"���" 
          dpi.Font = fnBold
          dpi.DataType = "System.String"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'ContractAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ContractAmount"
          dpi.Value = Configuration.FormatToString(newItem.TotalBudget, DigitConfig.Price)
          dpi.Font = fnBold
          dpi.DataType = "System.Decimal"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'ReceivedAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.ReceivedAmount"
          dpi.Value = Configuration.FormatToString(newItem.TotalReceived, DigitConfig.Price)
          dpi.Font = fnBold
          dpi.DataType = "System.Decimal"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

          'Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          dpi.Value = Configuration.FormatToString(newItem.TotalProgressReceive, DigitConfig.Price)
          dpi.Font = fnBold
          dpi.DataType = "System.Decimal"
          dpi.Table = "Item"
          dpi.Row = RowNumber
          dpiColl.Add(dpi)

        End If
      End If

      Return dpiColl
    End Function
    Public Function GetAllocateDocPrinting() As DocPrintingItemCollection
      Dim dpiColl As New DocPrintingItemCollection
      Dim dpi As DocPrintingItem

      Dim line As Integer = 0
      Dim counter As Integer = 0
      Dim i As Integer = 0
      For Each item As PAItem In Me.ItemCollection

        dpi = New DocPrintingItem
        dpi.Mapping = "pai_pa"
        dpi.Value = Me.Id
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        dpi = New DocPrintingItem
        dpi.Mapping = "paiw_sequence"
        dpi.Value = item.Sequence
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        'Item.Code
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Code"
        dpi.Value = item.Entity.Code
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        Dim qtyText As String = ""
        If (item.ItemType.Value <> 160 And item.ItemType.Value <> 162) Then
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
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
          End If
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.UnitPriceN
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.UnitPrice" & (i + 1).ToString
          If item.UnitPrice = 0 Then
            dpi.Value = ""
          Else
            dpi.Value = Configuration.FormatToString(item.UnitPrice, DigitConfig.UnitPrice)
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
        End If



        'Item.Name
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name"
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpi.Row = i + 1
        dpi.Table = "Allocate"
        dpiColl.Add(dpi)

        'Item.NameN
        dpi = New DocPrintingItem
        dpi.Mapping = "Item.Name" & (i + 1).ToString
        If Not item.EntityName Is Nothing AndAlso item.EntityName.Length > 0 Then
          dpi.Value = item.EntityName
        Else
          dpi.Value = item.Entity.Name
        End If
        dpi.DataType = "System.String"
        dpiColl.Add(dpi)

        '--------------------- WBS Section ------------------
        'Dim WBSCostCenter As String = ""
        'Dim WBSCode As String = ""
        'Dim WBSName As String = ""
        'Dim WBSCodePercent As String = ""
        'Dim WBSCodeAmount As String = ""
        'Dim WBSRemainAmount As String = ""
        'Dim WBSRemainQty As String = ""
        'If item.WBSDistributeCollection.Count > 0 Then
        '  'Populate ���ӹǳ�������Ẻ��͡�
        '  'item.WBSDistributeCollection.Populate(WBSDistribute.GetSchemaTable, item, Me.EntityId)
        '  If item.WBSDistributeCollection.Count = 1 Then
        '    WBSCostCenter = item.WBSDistributeCollection.Item(0).CostCenter.Code & ":" & _
        '    item.WBSDistributeCollection.Item(0).CostCenter.Name 'Code & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
        '    WBSCode = item.WBSDistributeCollection.Item(0).WBS.Code
        '    WBSName = item.WBSDistributeCollection.Item(0).WBS.Name
        '    WBSCodePercent = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%"
        '    WBSCodeAmount = item.WBSDistributeCollection.Item(0).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Amount, DigitConfig.Price)
        '    WBSRemainAmount = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).BudgetRemain, DigitConfig.Price)
        '    WBSRemainQty = Configuration.FormatToString(item.WBSDistributeCollection.Item(0).QtyRemain, DigitConfig.Price)
        '  Else
        '    Dim j As Integer
        '    For j = 0 To item.WBSDistributeCollection.Count - 1
        '      WBSCostCenter &= item.WBSDistributeCollection.Item(j).CostCenter.Code & ":" & _
        '      item.WBSDistributeCollection.Item(j).CostCenter.Name ' & "(" & Configuration.FormatToString(item.WBSDistributeCollection.Item(0).Percent, DigitConfig.Price) & "%)"
        '      WBSCode &= item.WBSDistributeCollection.Item(j).WBS.Code
        '      WBSName &= item.WBSDistributeCollection.Item(j).WBS.Name
        '      WBSCodePercent &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Percent, DigitConfig.Price)
        '      WBSCodeAmount &= item.WBSDistributeCollection.Item(j).WBS.Code & "=>" & Configuration.FormatToString(item.WBSDistributeCollection.Item(j).Amount, DigitConfig.Price)
        '      WBSRemainAmount &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).BudgetRemain, DigitConfig.Price)
        '      WBSRemainQty &= Configuration.FormatToString(item.WBSDistributeCollection.Item(j).QtyRemain, DigitConfig.Price)
        '      If j < item.WBSDistributeCollection.Count - 1 Then
        '        WBSCostCenter &= ", "
        '        'WBSCostCentern &= ", "
        '        WBSCode &= ", "
        '        WBSName &= ", "
        '        WBSCodePercent &= ", "
        '        WBSCodeAmount &= ", "
        '        WBSRemainAmount &= ", "
        '        WBSRemainQty &= ", "
        '      End If
        '    Next
        '  End If
        'End If

        For Each dis As WBSDistribute In item.WBSDistributeCollection
          line += 1

          '--����Ѻ������ҧ relation � schema--=============
          'sci_sc
          dpi = New DocPrintingItem
          dpi.Mapping = "sci_sc"
          dpi.Value = Me.Id
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'sci_Sequence
          dpi = New DocPrintingItem
          dpi.Mapping = "sci_sequence"
          dpi.Value = item.Sequence
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)
          '--����Ѻ������ҧ relation � schema--=============

          'Item.WBSCostCenter
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCostCenter"
          dpi.Value = dis.CostCenter.Code & ":" & dis.CostCenter.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCode"
          dpi.Value = dis.WBS.Code
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSName"
          dpi.Value = dis.WBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSinfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSInfo"
          dpi.Value = dis.WBS.Code & ":" & dis.WBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSCode
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSCode"
          dpi.Value = dis.CBS.Code
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSName
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSName"
          dpi.Value = dis.CBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.CBSinfo
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.CBSInfo"
          dpi.Value = dis.CBS.Code & ":" & dis.CBS.Name
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCodePercent
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodePercent"
          dpi.Value = dis.WBS.Code & ":" & dis.CBS.Code & "=>" & Configuration.FormatToString(dis.Percent, DigitConfig.Price) & "%"
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Percent
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Percent"
          dpi.Value = Configuration.FormatToString(dis.Percent, DigitConfig.Price) & "%"
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSCodeAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSCodeAmount"
          dpi.Value = dis.WBS.Code & ":" & dis.CBS.Code & "=>" & Configuration.FormatToString(dis.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.Amount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.Amount"
          dpi.Value = Configuration.FormatToString(dis.Amount, DigitConfig.Price)
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.BudgetAmount"
          dpi.Value = dis.BudgetAmount
          dpi.DataType = "System.String"
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainAmount
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainAmount"
                    dpi.Value = dis.RemainSummary
          dpi.DataType = "System.String"
          dpi.Row = i + 1
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
          dpi.Row = i + 1
          dpi.Table = "Allocate"
          dpiColl.Add(dpi)

          'Item.WBSRemainQty
          dpi = New DocPrintingItem
          dpi.Mapping = "Item.WBSRemainQty"
                    dpi.Value = dis.QtyRemainSummary
          dpi.DataType = "System.String"
          dpi.Row = i + 1
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
        Next


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

        i += 1

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
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeletePO}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        For Each extender As Object In Me.Extenders
          If TypeOf extender Is IExtender Then
            Dim delDocError As SaveErrorException = CType(extender, IExtender).Delete(conn, trans)
            If Not IsNumeric(delDocError.Message) Then
              trans.Rollback()
              Return delDocError
            Else
              Select Case CInt(delDocError.Message)
                Case -1, -2, -5
                  trans.Rollback()
                  Return delDocError
                Case Else
              End Select
            End If
          End If
        Next

        'Update PROrderedQty
        'SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "UpdatePROrderedQtyDeletePO" _
        ', New SqlParameter("@po_id", Me.Id))

        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeletePA", New SqlParameter() {New SqlParameter("@pa_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.POIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
        End If
        If Not Me.Payment Is Nothing Then
          Me.Payment.UpdateItemEntityStatus(conn, trans)
        End If
        Me.DeleteRef(conn, trans)
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "swang_UpdateGRWBSActual")

        Dim mldoc As New DocMultiApproval(Me.Id, Me.EntityId)
        mldoc.DocMethod = SaveDocMultiApprovalMethod.Delete
        Dim savemldocError As SaveErrorException = mldoc.UpdateApprove(0, conn, trans)
        If Not IsNumeric(savemldocError.Message) Then
          trans.Rollback()
          Return savemldocError
        End If

        trans.Commit()
        Return New SaveErrorException("1")
      Catch ex As SqlException
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Catch ex As Exception
        trans.Rollback()
        Return New SaveErrorException(ex.Message)
      Finally
        conn.Close()
      End Try
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

#Region "IHasIBillablePerson"
    Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
      Get
        Return Me.SubContractor
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Supplier Then
          Me.SubContractor = CType(Value, Supplier)
        End If
      End Set
    End Property
#End Region

#Region "IDuplicable"
    Public Function GetNewEntity() As Object Implements IDuplicable.GetNewEntity
      '���� Copy ������ CustomNote �ҡ�ѹ�Ѩ�غѹ��������͹
      Me.m_customNoteColl = New CustomNoteCollection(Me)

      Me.Status.Value = -1
      If Not Me.Originated Then
        Return Me
      End If
      Me.Id = 0
      Me.Code = "Copy of " & Me.Code
      Me.ApproveDate = Date.MinValue
            Me.ApprovePerson = New User
            Me.ApproveDocColl = Nothing
      Me.Canceled = False
      Me.CancelPerson = New User
      'Me.Closing = False
      Me.Closed = False
      Me.ClearReference()
      Dim wbsdummy As WBS
      For Each item As PAItem In Me.ItemCollection
        If item.ItemType.Value <> 160 Or item.ItemType.Value <> 162 Then
          For Each wbsd As WBSDistribute In item.WBSDistributeCollection
            wbsdummy = wbsd.WBS
            wbsd.WBS = wbsdummy
          Next
        End If
      Next
      Return Me
    End Function
#End Region

#Region "IVatable"
    Public Function GetAfterTax() As Decimal Implements IVatable.GetAfterTax
      Return Me.AfterTax()
    End Function

    Public Function GetBeforeTax() As Decimal Implements IVatable.GetBeforeTax
      Return Me.BeforeTax()
    End Function
    Public Property Person() As IBillablePerson Implements IVatable.Person, IWitholdingTaxable.Person
      Get
        Return Me.Sc.SubContractor
      End Get
      Set(ByVal Value As IBillablePerson)
        If Me.Sc.SubContractor Is Nothing Then
          Me.Sc.SubContractor = New Supplier
        End If
        Dim oldPerson As IBillablePerson = Me.Sc.SubContractor
        If (oldPerson Is Nothing AndAlso Not Value Is Nothing) _          OrElse (Not oldPerson Is Nothing AndAlso Not Value Is Nothing AndAlso oldPerson.Id <> Value.Id) Then          If Not Me.m_whtcol Is Nothing Then
            For Each wht As WitholdingTax In m_whtcol
              wht.UpdateRefDoc(Value, True)
            Next
          End If
        End If
        Me.Sc.SubContractor = CType(Value, Supplier)
      End Set
    End Property
    Public Function GetMaximumTaxBase(Optional ByVal conn As SqlConnection = Nothing, Optional ByVal trans As SqlTransaction = Nothing) As Decimal Implements IVatable.GetMaximumTaxBase
      Return Me.RealTaxBase
    End Function

    Public ReadOnly Property NoVat() As Boolean Implements IVatable.NoVat
      Get
        Return Me.TaxType.Value = 0
      End Get
    End Property
    Public Property Vat() As Vat Implements IVatable.Vat
      Get        Return m_vat      End Get      Set(ByVal Value As Vat)        m_vat = Value      End Set
    End Property

#End Region

#Region "WitholdingTax"
    Public Function GetMaximumWitholdingTaxBase() As Decimal Implements IWitholdingTaxable.GetMaximumWitholdingTaxBase
      Return Me.RealTaxBase
    End Function

    Public Property WitholdingTaxCollection() As WitholdingTaxCollection Implements IWitholdingTaxable.WitholdingTaxCollection
      Get
        Return m_whtcol
      End Get
      Set(ByVal Value As WitholdingTaxCollection)
        m_whtcol = Value
      End Set
    End Property
#End Region

#Region "IBillAcceptable"
    Public Function GetRemainingAmountWithBillAcceptance(ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountWithBillAcceptance
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidPAAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@billai_billa", billa_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    Public Function GetRemainingAmountPayselection(ByVal pays_id As Integer, ByVal billa_id As Integer) As Decimal Implements IBillAcceptable.GetRemainingAmountPayselection
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetUnpaidStockAmount" _
                , New SqlParameter("@stock_id", Me.Id) _
                , New SqlParameter("@paysi_pays", pays_id) _
                , New SqlParameter("@billai_billa", billa_id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return Configuration.Format(CDec(ds.Tables(0).Rows(0)(0)), DigitConfig.Price)
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function

    Public Function AmountToPay() As Decimal Implements IPayable.AmountToPay
      RefreshTaxBase()

      Return Configuration.Format(Me.AfterTax, DigitConfig.Price)
    End Function

    Public Property DueDate() As Date Implements IPayable.DueDate
      Get
        Try
          Return Me.DocDate.AddDays(Me.CreditPeriod)
        Catch ex As Exception
          Return Me.DocDate
        End Try
      End Get
      Set(ByVal Value As Date)
        Try
          m_creditPeriod = DateDiff(DateInterval.Day, DocDate, Value)
        Catch ex As Exception

        End Try
      End Set
    End Property

    Public Property Payment() As Payment Implements IPayable.Payment
      Get
        Return m_payment
      End Get
      Set(ByVal Value As Payment)
        m_payment = Value
      End Set
    End Property

    Public ReadOnly Property Recipient() As IBillablePerson Implements IPayable.Recipient
      Get
        Return Me.SubContractor()
      End Get
    End Property

    Public Function RemainingAmount() As Decimal Implements IPayable.RemainingAmount
      Return AmountToPay()
    End Function
#End Region

#Region "IGLAble"
    Public Function GetDefaultGLFormat() As GLFormat Implements IGLAble.GetDefaultGLFormat
      If Not Me.AutoCodeFormat.GLFormat Is Nothing AndAlso Me.AutoCodeFormat.GLFormat.Originated Then
        Return Me.AutoCodeFormat.GLFormat
      End If
      Dim entId As Integer = Me.EntityId
      'If Not Me.Asset Is Nothing AndAlso Me.Asset.Originated Then
      '	entId = 50
      'End If
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetGLFormatForEntity" _
      , New SqlParameter("@entity_id", entId), New SqlParameter("@default", 1) _
      , New SqlParameter("@inventoryType", CInt(Configuration.GetConfig("CompanyInventoryMethod"))))
      If ds.Tables(0).Rows.Count > 0 Then
        Dim glf As New GLFormat(ds.Tables(0).Rows(0), "")
        Return glf
      End If
      Return New GLFormat
    End Function
    Public Function GetJournalEntries() As JournalEntryItemCollection Implements IGLAble.GetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem
      Dim tmp As Object = Configuration.GetConfig("APRetentionPoint")
      Dim apRetentionPoint As Integer = 0
      If IsNumeric(tmp) Then
        apRetentionPoint = CInt(tmp)
      End If
      Dim retentionHere As Boolean = (apRetentionPoint = 0)


      'Retention
      If (Me.Payment.Amount - Me.Payment.Gross = 0 OrElse retentionHere) AndAlso Me.Retention > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.16"
        ji.Amount = Me.Retention
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.Note = Me.Recipient.Name
        jiColl.Add(ji)
      End If

      '���ի���
      If Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.5"
        ji.Amount = Configuration.Format(Me.Vat.Amount, DigitConfig.Price)
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.Note = Me.Recipient.Name
        jiColl.Add(ji)
        For Each vi As VatItem In Me.Vat.ItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "E3.5D"
          ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = vi.Code & "/" & vi.PrintName
          jiColl.Add(ji)
        Next


      End If

      '���ի������֧��˹�
      If Me.RealTaxAmount - Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.5.1"
        ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        jiColl.Add(ji)


      End If

      '�����ѡ � ������
      If Not Me.WitholdingTaxCollection.IsBeforePay Then
        If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.15"
          ji.Amount = Me.WitholdingTaxCollection.Amount
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            ji = New JournalEntryItem
            ji.Mapping = "E3.15D"
            ji.Amount = wht.Amount
            If Me.CostCenter.Originated Then
              ji.CostCenter = Me.CostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = wht.PrintName & "(" & wht.Code & ")"
            jiColl.Add(ji)
          Next
          Dim WHTTypeSum As New Hashtable

          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            If WHTTypeSum.Contains(wht.Type.Value) Then
              WHTTypeSum(wht.Type.Value) = CDec(WHTTypeSum(wht.Type.Value)) + wht.Amount
            Else
              WHTTypeSum(wht.Type.Value) = wht.Amount
            End If
          Next
          Dim typeNum As String
          For Each obj As Object In WHTTypeSum.Keys
            typeNum = CStr(obj)
            If Not (typeNum.Length > 1) Then
              typeNum = "0" & typeNum
            End If
            If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
              ji = New JournalEntryItem
              ji.Mapping = "E3.18"
              ji.Amount = CDec(WHTTypeSum(obj))
              ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
              If Me.CostCenter.Originated Then
                ji.CostCenter = Me.CostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              ji.Note = Me.Recipient.Name
              jiColl.Add(ji)
            End If
          Next
          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            typeNum = CStr(wht.Type.Value)
            If Not (typeNum.Length > 1) Then
              typeNum = "0" & typeNum
            End If
            If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
              ji = New JournalEntryItem
              ji.Mapping = "E3.18D"
              ji.Amount = wht.Amount
              ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
              If Me.CostCenter.Originated Then
                ji.CostCenter = Me.CostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              ji.Note = Me.Recipient.Name
              jiColl.Add(ji)
            End If
          Next
          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            typeNum = CStr(wht.Type.Value)
            If Not (typeNum.Length > 1) Then
              typeNum = "0" & typeNum
            End If
            If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
              ji = New JournalEntryItem
              ji.Mapping = "E3.18W"
              ji.Amount = wht.Amount
              ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
              If Me.CostCenter.Originated Then
                ji.CostCenter = Me.CostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If
              ji.Note = Me.Recipient.Name
              jiColl.Add(ji)
            End If
          Next


        End If
      End If

      '-------------------------------------HACK------------------------------------
      '��ǹŴ��ä��
      'If Me.DiscountAmount > 0 Then
      'ji = New JournalEntryItem
      'ji.Mapping = "Through"
      'ji.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.TradeDiscount).Account
      'ji.Note = Me.StringParserService.Parse("${res:Global.TradeDiscount}")
      'ji.Amount = Me.DiscountAmount
      'If Me.CostCenter.Originated Then
      'ji.CostCenter = Me.CostCenter
      'Else
      'ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      'End If
      'jiColl.Add(ji)
      'End If
      '-------------------------------------HACK------------------------------------

      '�Թ�Ѵ�Ө�����ǧ˹��
      If Me.AdvancePayItemCollection.GetExcludeVATAmount > 0 Then
        Dim pm110note As String = ""
        For Each avpi As AdvancePayItem In Me.AdvancePayItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "PM1.10D"
          ji.Amount = avpi.AdvancePay.GetRemainExcludeVatAmount(avpi.Amount)
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = avpi.AdvancePay.Code & "/" & Me.Recipient.Name
          jiColl.Add(ji)
          If pm110note = "" Then
            pm110note = "�Ѵ�Ѵ�Ӣͧ " & Me.Recipient.Code & "(" & avpi.AdvancePay.Code & ")"

          Else
            pm110note = pm110note & "," & Me.Recipient.Code & "(" & avpi.AdvancePay.Code & ")"
          End If

        Next
        ji = New JournalEntryItem
        ji.Mapping = "PM1.10"
        ji.Amount = Me.AdvancePayItemCollection.GetExcludeVATAmount
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.Note = pm110note
        jiColl.Add(ji)
      End If

      If Not Me.Payment Is Nothing Then
        '��ǹ��ҧ�����ҧ�ʹ���¡Ѻ�ʹ��ԧ ---> ���˹��
        Dim pmGross As Decimal = Me.Payment.Gross
        If Configuration.Compare(pmGross, Me.Payment.Amount) < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.8"
          If retentionHere Then
            ji.Amount = Me.Payment.Amount - pmGross
          Else
            ji.Amount = (Me.Payment.Amount + Me.Retention) - pmGross
          End If
          If Not Me.SubContractor.Account Is Nothing AndAlso Me.SubContractor.Account.Originated Then
            ji.Account = Me.SubContractor.Account
          End If
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Recipient.Name
          jiColl.Add(ji)
        End If



        jiColl.AddRange(Me.Payment.GetJournalEntries)
      End If
      jiColl.AddRange(Me.GetItemJournalEntries)
      Return jiColl
    End Function
    Private Function ThereIsUnvatableItems() As Boolean
      For Each item As PAItem In Me.ItemCollection
        If item.UnVatable Then
          Return True
        End If
      Next
      Return False
    End Function
    Private Function GetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      Dim ji As New JournalEntryItem
      For Each item As PAItem In Me.ItemCollection
        If Not item.IsHasChild Then
          Dim itemType As Integer
          Dim blankMatched As Boolean = False
          Dim blankNoAcctMatched As Boolean = False
          Dim lciToolMatched As Boolean = False
          Dim lciToolNoAcctMatched As Boolean = False
          Dim assetMatched As Boolean = False
          Dim assetNoacctMatched As Boolean = False

          Dim withdrawMatched As Boolean = False
          Dim withdrawNoAcctMatched As Boolean = False
          Dim originMatched As Boolean = False

          Dim itemRemainAmount As Decimal

          If ThereIsUnvatableItems() Then
            Dim itemAmountPerGross As Decimal
            If Me.TaxGross = 0 Then
              itemAmountPerGross = 0
            Else
              itemAmountPerGross = item.Amount / Me.TaxGross
            End If
            itemRemainAmount = (Me.TaxGross - Me.RealTaxAmount) * itemAmountPerGross
          Else
            itemRemainAmount = item.TaxBase
          End If

          'Dim discountRate As Decimal = 1

          'If Me.TaxType.Value = 2 Then
          '  itemRemainAmount -= Vat.GetExcludedVatAmount(item.DiscountFromParent, Me.TaxRate)
          '  'itemRemainAmount -= (item.DiscountFromParent - Vat.GetExcludedVatAmount(item.DiscountFromParent, Me.TaxRate))
          'ElseIf Me.Gross <> 0 Then
          '  discountRate = (Me.Gross - Me.DiscountAmount) / Me.Gross
          'End If

          Dim itemAmount As Decimal = item.CostAmount ' item.Amount



          'Dim itemMat As Decimal = item.Mat * discountRate
          'Dim itemLab As Decimal = item.Lab * discountRate
          'Dim itemEQ As Decimal = item.Eq * discountRate

          'Dim itemRemainMat As Decimal = 0
          'Dim itemRemainLab As Decimal = 0
          'Dim itemRemainEQ As Decimal = 0

          'If itemAmount <> 0 Then
          '  itemRemainMat = itemMat * (itemRemainAmount / itemAmount)
          '  itemRemainLab = itemLab * (itemRemainAmount / itemAmount)
          '  itemRemainEQ = itemEQ * (itemRemainAmount / itemAmount)
          'End If

          Dim note As String = ""
          Dim realAccount As Account
          'Dim realAmount As Decimal
          If Not item.ItemType Is Nothing Then
            Select Case item.ItemType.Value
              Case 289
                '==========================MAT==============================================================
                If Not item.MatAccount Is Nothing AndAlso item.MatAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.MatAccount
                End If
                'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                '  realAmount = itemMat
                'Else
                '  realAmount = itemRemainMat
                'End If
                note = item.ItemDescription & ":" & item.ItemType.Description
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4")
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4D", note)

                For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                  itemAmount = wbsd.Amount
                  SetJournalEntryItem(jiColl, realAccount, itemAmount, wbsd.CostCenter, "E4.4W", note)


                Next

                '==========================LAB==============================================================
                realAccount = Nothing
                If Not item.LabAccount Is Nothing AndAlso item.LabAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.LabAccount
                End If
                'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                '  realAmount = itemLab
                'Else
                '  realAmount = itemRemainLab
                'End If
                note = item.ItemDescription & ":" & item.ItemType.Description
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4")
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4D", note)

                For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                  itemAmount = wbsd.Amount
                  SetJournalEntryItem(jiColl, realAccount, itemAmount, wbsd.CostCenter, "E4.4W", note)


                Next
                '==========================EQ==============================================================
                realAccount = Nothing
                If Not item.EqAccount Is Nothing AndAlso item.EqAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.EqAccount
                End If
                'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                '  realAmount = itemEQ
                'Else
                '  realAmount = itemRemainEQ
                'End If
                note = item.ItemDescription & ":" & item.ItemType.Description
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4")
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4D", note)

                For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                  itemAmount = wbsd.Amount
                  SetJournalEntryItem(jiColl, realAccount, itemAmount, wbsd.CostCenter, "E4.4W", note)


                Next
              Case 291


                '==========================Penalty==============================================================
                realAccount = Nothing
                If Not item.LabAccount Is Nothing AndAlso item.LabAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.LabAccount
                End If
                'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                '  realAmount = itemLab
                'Else
                '  realAmount = itemRemainLab
                'End If
                note = item.ItemDescription & ":" & item.ItemType.Description
                SetJournalEntryItem(jiColl, realAccount, -itemAmount, Me.CostCenter, "E4.9")
                SetJournalEntryItem(jiColl, realAccount, -itemAmount, Me.CostCenter, "E4.9D", note)
                For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                  itemAmount = wbsd.Amount
                  SetJournalEntryItem(jiColl, realAccount, -itemAmount, wbsd.CostCenter, "E4.9W", note)

                Next

              Case 0  'Blank  
                If Not item.MatAccount Is Nothing AndAlso item.MatAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.MatAccount
                End If
                'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                '  realAmount = itemMat
                'Else
                '  realAmount = itemRemainMat
                'End If
                note = item.ItemDescription & ":" & item.ItemType.Description
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4")
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4D", note)

                For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                  itemAmount = wbsd.Amount
                  SetJournalEntryItem(jiColl, realAccount, itemAmount, wbsd.CostCenter, "E4.4W", note)

                Next
              Case 88 'lab 
                realAccount = Nothing
                If Not item.LabAccount Is Nothing AndAlso item.LabAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.LabAccount
                End If
                'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                '  realAmount = itemLab
                'Else
                '  realAmount = itemRemainLab
                'End If
                note = item.ItemDescription & ":" & item.ItemType.Description
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4")
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4D", note)

                For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                  itemAmount = wbsd.Amount
                  SetJournalEntryItem(jiColl, realAccount, itemAmount, wbsd.CostCenter, "E4.4W", note)


                Next
              Case 89    ' eq
                realAccount = Nothing
                If Not item.EqAccount Is Nothing AndAlso item.EqAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.EqAccount
                End If
                'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                '  realAmount = itemEQ
                'Else
                '  realAmount = itemRemainEQ
                'End If
                note = item.ItemDescription & ":" & item.ItemType.Description
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4")
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.4D", note)


                For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                  itemAmount = wbsd.Amount
                  SetJournalEntryItem(jiColl, realAccount, itemAmount, wbsd.CostCenter, "E4.4W", note)


                Next
              Case 42 ' LCI
                If Not item.MatAccount Is Nothing AndAlso item.MatAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.MatAccount
                End If
                'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                '  realAmount = itemMat
                'Else
                '  realAmount = itemRemainMat
                'End If
                note = item.ItemDescription & ":" & item.ItemType.Description
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.1")
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.1D", note)


                For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                  itemAmount = wbsd.Amount
                  SetJournalEntryItem(jiColl, realAccount, itemAmount, wbsd.CostCenter, "E4.4W", note)


                Next
              Case 19 'Tool
                If Not item.MatAccount Is Nothing AndAlso item.MatAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.MatAccount
                End If
                'If Me.TaxType.Value = 0 Or Me.TaxType.Value = 1 Or item.UnVatable Then
                '  realAmount = itemMat
                'Else
                '  realAmount = itemRemainMat
                'End If
                note = item.ItemDescription & ":" & item.ItemType.Description
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.2")
                SetJournalEntryItem(jiColl, realAccount, itemAmount, Me.CostCenter, "E4.2D", note)


                For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                  itemAmount = wbsd.Amount
                  SetJournalEntryItem(jiColl, realAccount, itemAmount, wbsd.CostCenter, "E4.2W", note)


                Next
            End Select
          End If
        End If '----------------------������١
      Next

      For Each tmpJi As JournalEntryItem In jiColl
        tmpJi.Amount = Configuration.Format(tmpJi.Amount, DigitConfig.Price)
      Next

      Return jiColl
    End Function
    Private Sub SetJournalEntryItem(ByRef jiColl As JournalEntryItemCollection, ByRef realAccount As Account, ByVal realAmount As Decimal, ByRef jiCoscenter As CostCenter, ByVal map As String, Optional ByVal note As String = "")
      Dim ji As New JournalEntryItem
      ji.Mapping = map
      ji.Amount = realAmount
      ji.Account = realAccount
      If note.Length > 0 Then
        ji.Note = note
      End If
      If jiCoscenter.Originated Then
        ji.CostCenter = jiCoscenter
      Else
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      jiColl.Add(ji)
    End Sub
    Public Property JournalEntry() As JournalEntry Implements IGLAble.JournalEntry
      Get
        Return Me.m_je
      End Get
      Set(ByVal Value As JournalEntry)
        m_je = Value
      End Set
    End Property
#End Region

#Region "INewGLAble"

    Public Function NewGetJournalEntries() As JournalEntryItemCollection Implements INewGLAble.NewGetJournalEntries
      Dim jiColl As New JournalEntryItemCollection
      Dim ji As JournalEntryItem
      Dim tmp As Object = Configuration.GetConfig("APRetentionPoint")
      Dim apRetentionPoint As Integer = 0
      If IsNumeric(tmp) Then
        apRetentionPoint = CInt(tmp)
      End If
      Dim retentionHere As Boolean = (apRetentionPoint = 0)


      'Retention
      If (Me.Payment.Amount - Me.Payment.Gross = 0 OrElse retentionHere) AndAlso Me.Retention > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.16"
        ji.Amount = Me.Retention
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.Note = Me.Recipient.Name
        ji.EntityItem = Me.Id
        ji.EntityItemType = Entity.GetIdFromClassName("PurchaseRetention")
        ji.table = Me.TableName
        ji.AtomNote = "PA ��� Retention"
        jiColl.Add(ji)
      End If

      '���ի���
      If Me.Vat.Amount > 0 Then

        For Each vi As VatItem In Me.Vat.ItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "E3.5"
          ji.Amount = Configuration.Format(vi.Amount, DigitConfig.Price)
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = vi.Code & "/" & vi.PrintName
          ji.EntityItem = Me.Vat.Id
          ji.EntityItemType = 97 '�� Incomingvat 
          ji.table = Me.Vat.TableName & "item"
          ji.CustomRefstr = vi.LineNumber.ToString
          ji.CustomRefType = "vati_linenumber"
          ji.AtomNote = "���ի��� �� tax Invoice"
          jiColl.Add(ji)
        Next


      End If

      '���ի������֧��˹�
      If Me.RealTaxAmount - Me.Vat.Amount > 0 Then
        ji = New JournalEntryItem
        ji.Mapping = "E3.5.1"
        ji.Amount = Configuration.Format(Me.RealTaxAmount - Me.Vat.Amount, DigitConfig.Price)
        If Me.CostCenter.Originated Then
          ji.CostCenter = Me.CostCenter
        Else
          ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
        End If
        ji.Note = Me.Code & ":�Ѻ�ҹ:" & Me.SubContractor.Name
        '�͹��駡Ѻ��ҧ��ҧ�ѹ���ǡѹ
        ji.EntityItem = Me.Id
        ji.EntityItemType = Entity.GetIdFromFullClassName("Longkong.Pojjaman.BusinessLogic.VatInNotDue")
        ji.table = Me.TableName
        ji.CustomRefstr = Me.EntityId.ToString
        ji.CustomRefType = "entity"
        ji.AtomNote = "��� vat not due PA"
        jiColl.Add(ji)


      End If

      '�����ѡ � ������
      If Not Me.WitholdingTaxCollection.IsBeforePay Then
        If Not Me.WitholdingTaxCollection Is Nothing AndAlso Me.WitholdingTaxCollection.Amount > 0 Then

          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            ji = New JournalEntryItem
            ji.Mapping = "E3.15"
            ji.Amount = wht.Amount
            If Me.CostCenter.Originated Then
              ji.CostCenter = Me.CostCenter
            Else
              ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
            End If
            ji.Note = wht.PrintName & "(" & wht.Code & ")"
            ji.EntityItem = wht.Id
            ji.EntityItemType = Entity.GetIdFromClassName("WitholdingTax")
            ji.table = wht.TableName
            jiColl.Add(ji)
          Next
          Dim WHTTypeSum As New Hashtable

          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            If WHTTypeSum.Contains(wht.Type.Value) Then
              WHTTypeSum(wht.Type.Value) = CDec(WHTTypeSum(wht.Type.Value)) + wht.Amount
            Else
              WHTTypeSum(wht.Type.Value) = wht.Amount
            End If
          Next
          Dim typeNum As String

          For Each wht As WitholdingTax In Me.WitholdingTaxCollection
            typeNum = CStr(wht.Type.Value)
            If Not (typeNum.Length > 1) Then
              typeNum = "0" & typeNum
            End If
            If Not IsDBNull(Configuration.GetConfig("WHTAcc" & typeNum)) Then
              ji = New JournalEntryItem
              ji.Mapping = "E3.18"
              ji.Amount = wht.Amount
              ji.Account = New Account(CStr(Configuration.GetConfig("WHTAcc" & typeNum)))
              If Me.CostCenter.Originated Then
                ji.CostCenter = Me.CostCenter
              Else
                ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
              End If

              ji.Note = wht.PrintName & "(" & wht.Code & ")" & wht.Type.Description
              ji.EntityItem = wht.Id
              ji.EntityItemType = Entity.GetIdFromClassName("WitholdingTax")
              ji.table = wht.TableName
              ji.AtomNote = " WHT"

              jiColl.Add(ji)
            End If
          Next



        End If
      End If

      '-------------------------------------HACK------------------------------------
      '��ǹŴ��ä��
      'If Me.DiscountAmount > 0 Then
      'ji = New JournalEntryItem
      'ji.Mapping = "Through"
      'ji.Account = GeneralAccount.GetDefaultGA(GeneralAccount.DefaultGAType.TradeDiscount).Account
      'ji.Note = Me.StringParserService.Parse("${res:Global.TradeDiscount}")
      'ji.Amount = Me.DiscountAmount
      'If Me.CostCenter.Originated Then
      'ji.CostCenter = Me.CostCenter
      'Else
      'ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      'End If
      'jiColl.Add(ji)
      'End If
      '-------------------------------------HACK------------------------------------

      '�Թ�Ѵ�Ө�����ǧ˹��
      If Me.AdvancePayItemCollection.GetExcludeVATAmount > 0 Then
        Dim pm110note As String = ""
        For Each avpi As AdvancePayItem In Me.AdvancePayItemCollection
          ji = New JournalEntryItem
          ji.Mapping = "PM1.10"
          ji.Amount = avpi.AdvancePay.GetRemainExcludeVatAmount(avpi.Amount)
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = avpi.AdvancePay.Code & "/" & Me.Recipient.Name

          ji.EntityItem = avpi.AdvancePay.Id
          ji.EntityItemType = avpi.AdvancePay.EntityId
          ji.table = avpi.AdvancePay.TableName
          ji.AtomNote = "��ҧ�Ѵ�Ӵ��� PA"

          jiColl.Add(ji)
          If pm110note = "" Then
            pm110note = "�Ѵ�Ѵ�Ӣͧ " & Me.Recipient.Code & "(" & avpi.AdvancePay.Code & ")"

          Else
            pm110note = pm110note & "," & Me.Recipient.Code & "(" & avpi.AdvancePay.Code & ")"
          End If

        Next

      End If

      If Not Me.Payment Is Nothing Then
        '��ǹ��ҧ�����ҧ�ʹ���¡Ѻ�ʹ��ԧ ---> ���˹��
        Dim pmGross As Decimal = Me.Payment.Gross
        If Configuration.Compare(pmGross, Me.Payment.Amount) < 0 Then
          ji = New JournalEntryItem
          ji.Mapping = "E3.8"
          If retentionHere Then
            ji.Amount = Me.Payment.Amount - pmGross
          Else
            ji.Amount = (Me.Payment.Amount + Me.Retention) - pmGross
          End If
          If Not Me.SubContractor.Account Is Nothing AndAlso Me.SubContractor.Account.Originated Then
            ji.Account = Me.SubContractor.Account
          End If
          If Me.CostCenter.Originated Then
            ji.CostCenter = Me.CostCenter
          Else
            ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
          End If
          ji.Note = Me.Recipient.Name
          ''===== ����˹�� ���ҧ�Ѻ��ҧ˹�� =====
          ji.EntityItem = Me.Id
          ji.EntityItemType = Me.EntityId
          ji.table = Me.TableName
          ji.AtomNote = "PA ���˹��"
          jiColl.Add(ji)
        End If



        jiColl.AddRange(Me.Payment.GetNewJournalEntries)
      End If
      jiColl.AddRange(Me.NewGetItemJournalEntries)
      Return jiColl
    End Function

    Private Function NewGetItemJournalEntries() As JournalEntryItemCollection
      Dim jiColl As New JournalEntryItemCollection

      Dim ji As New JournalEntryItem
      For Each item As PAItem In Me.ItemCollection
        If Not item.IsHasChild Then
          Dim itemType As Integer
          Dim blankMatched As Boolean = False
          Dim blankNoAcctMatched As Boolean = False
          Dim lciToolMatched As Boolean = False
          Dim lciToolNoAcctMatched As Boolean = False
          Dim assetMatched As Boolean = False
          Dim assetNoacctMatched As Boolean = False

          Dim withdrawMatched As Boolean = False
          Dim withdrawNoAcctMatched As Boolean = False
          Dim originMatched As Boolean = False

          Dim itemRemainAmount As Decimal

          If ThereIsUnvatableItems() Then
            Dim itemAmountPerGross As Decimal
            If Me.TaxGross = 0 Then
              itemAmountPerGross = 0
            Else
              itemAmountPerGross = item.Amount / Me.TaxGross
            End If
            itemRemainAmount = (Me.TaxGross - Me.RealTaxAmount) * itemAmountPerGross
          Else
            itemRemainAmount = item.TaxBase
          End If

          Dim discountRate As Decimal = 1

          'If Me.TaxType.Value = 2 Then
          '  itemRemainAmount -= Vat.GetExcludedVatAmount(item.DiscountFromParent, Me.TaxRate)
          '  'itemRemainAmount -= (item.DiscountFromParent - Vat.GetExcludedVatAmount(item.DiscountFromParent, Me.TaxRate))
          'ElseIf Me.Gross <> 0 Then
          '  discountRate = (Me.Gross - Me.DiscountAmount) / Me.Gross
          'End If

          Dim itemAmount As Decimal = item.CostAmount



          'Dim itemMat As Decimal = item.Mat * discountRate
          'Dim itemLab As Decimal = item.Lab * discountRate
          'Dim itemEQ As Decimal = item.Eq * discountRate

          'Dim itemRemainMat As Decimal = 0
          'Dim itemRemainLab As Decimal = 0
          'Dim itemRemainEQ As Decimal = 0

          'If itemAmount <> 0 Then
          '  itemRemainMat = itemMat * (itemRemainAmount / itemAmount)
          '  itemRemainLab = itemLab * (itemRemainAmount / itemAmount)
          '  itemRemainEQ = itemEQ * (itemRemainAmount / itemAmount)
          'End If

          Dim note As String = ""
          Dim realAccount As Account
          'Dim realAmount As Decimal
          If Not item.ItemType Is Nothing Then
            Select Case item.ItemType.Value
              Case 289
                '==========================MAT==============================================================
                If Not item.MatAccount Is Nothing AndAlso item.MatAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.MatAccount
                End If

                note = item.ItemDescription & ":" & item.ItemType.Description
                'NewSetJournalEntryItem(jiColl, realAccount, realAmount, Me.CostCenter, "E3.4")
                If item.WBSDistributeCollection.Count > 0 Then
                  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                    itemAmount = wbsd.Amount
                    NewSetJournalEntryItem(jiColl, item, wbsd, realAccount, itemAmount, wbsd.CostCenter, "E4.4", note)
                  Next
                Else
                  NewSetJournalEntryItem(jiColl, item, Nothing, realAccount, itemAmount, Me.CostCenter, "E4.4", note)

                End If


                '==========================LAB==============================================================
                realAccount = Nothing
                If Not item.LabAccount Is Nothing AndAlso item.LabAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.LabAccount
                End If

                note = item.ItemDescription & ":" & item.ItemType.Description
                If item.WBSDistributeCollection.Count > 0 Then
                  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                    itemAmount = wbsd.Amount
                    NewSetJournalEntryItem(jiColl, item, wbsd, realAccount, itemAmount, wbsd.CostCenter, "E4.4", note)
                  Next
                Else
                  NewSetJournalEntryItem(jiColl, item, Nothing, realAccount, itemAmount, Me.CostCenter, "E4.4", note)

                End If
                '==========================EQ==============================================================
                realAccount = Nothing
                If Not item.EqAccount Is Nothing AndAlso item.EqAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.EqAccount
                End If

                note = item.ItemDescription & ":" & item.ItemType.Description
                If item.WBSDistributeCollection.Count > 0 Then
                  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                    itemAmount = wbsd.Amount
                    NewSetJournalEntryItem(jiColl, item, wbsd, realAccount, itemAmount, wbsd.CostCenter, "E4.4", note)
                  Next
                Else
                  NewSetJournalEntryItem(jiColl, item, Nothing, realAccount, itemAmount, Me.CostCenter, "E4.4", note)

                End If
              Case 291


                '==========================Penalty==============================================================
                realAccount = Nothing
                If Not item.LabAccount Is Nothing AndAlso item.LabAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.LabAccount
                End If

                note = item.ItemDescription & ":" & item.ItemType.Description
                If item.WBSDistributeCollection.Count > 0 Then
                  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                    itemAmount = wbsd.Amount
                    NewSetJournalEntryItem(jiColl, item, wbsd, realAccount, itemAmount, wbsd.CostCenter, "E4.4", note)
                  Next
                Else
                  NewSetJournalEntryItem(jiColl, item, Nothing, realAccount, itemAmount, Me.CostCenter, "E4.4", note)

                End If

              Case 0  'Blank  
                If Not item.MatAccount Is Nothing AndAlso item.MatAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.MatAccount
                End If

                note = item.ItemDescription & ":" & item.ItemType.Description
                If item.WBSDistributeCollection.Count > 0 Then
                  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                    itemAmount = wbsd.Amount
                    NewSetJournalEntryItem(jiColl, item, wbsd, realAccount, itemAmount, wbsd.CostCenter, "E4.4", note)
                  Next
                Else
                  NewSetJournalEntryItem(jiColl, item, Nothing, realAccount, itemAmount, Me.CostCenter, "E4.4", note)

                End If
              Case 88 'lab 
                realAccount = Nothing
                If Not item.LabAccount Is Nothing AndAlso item.LabAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.LabAccount
                End If

                note = item.ItemDescription & ":" & item.ItemType.Description
                If item.WBSDistributeCollection.Count > 0 Then
                  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                    itemAmount = wbsd.Amount
                    NewSetJournalEntryItem(jiColl, item, wbsd, realAccount, itemAmount, wbsd.CostCenter, "E4.4", note)
                  Next
                Else
                  NewSetJournalEntryItem(jiColl, item, Nothing, realAccount, itemAmount, Me.CostCenter, "E4.4", note)

                End If
              Case 89    ' eq
                realAccount = Nothing
                If Not item.EqAccount Is Nothing AndAlso item.EqAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.EqAccount
                End If

                note = item.ItemDescription & ":" & item.ItemType.Description
                If item.WBSDistributeCollection.Count > 0 Then
                  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                    itemAmount = wbsd.Amount
                    NewSetJournalEntryItem(jiColl, item, wbsd, realAccount, itemAmount, wbsd.CostCenter, "E4.4", note)
                  Next
                Else
                  NewSetJournalEntryItem(jiColl, item, Nothing, realAccount, itemAmount, Me.CostCenter, "E4.4", note)

                End If
              Case 42 ' LCI
                If Not item.MatAccount Is Nothing AndAlso item.MatAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.MatAccount
                End If

                note = item.ItemDescription & ":" & item.ItemType.Description
                If item.WBSDistributeCollection.Count > 0 Then
                  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                    itemAmount = wbsd.Amount
                    NewSetJournalEntryItem(jiColl, item, wbsd, realAccount, itemAmount, wbsd.CostCenter, "E4.1", note)
                  Next
                Else
                  NewSetJournalEntryItem(jiColl, item, Nothing, realAccount, itemAmount, Me.CostCenter, "E4.1", note)
                End If
              Case 19 'Tool
                If Not item.MatAccount Is Nothing AndAlso item.MatAccount.Originated Then
                  '�� acct ���¡��
                  realAccount = item.MatAccount
                End If

                note = item.ItemDescription & ":" & item.ItemType.Description
                If item.WBSDistributeCollection.Count > 0 Then
                  For Each wbsd As WBSDistribute In item.WBSDistributeCollection
                    itemAmount = wbsd.Amount
                    NewSetJournalEntryItem(jiColl, item, wbsd, realAccount, itemAmount, wbsd.CostCenter, "E3.2", note)
                  Next
                Else
                  NewSetJournalEntryItem(jiColl, item, Nothing, realAccount, itemAmount, Me.CostCenter, "E3.2", note)
                End If
            End Select
          End If
        End If '----------------------������١
      Next

      For Each tmpJi As JournalEntryItem In jiColl
        tmpJi.Amount = Configuration.Format(tmpJi.Amount, DigitConfig.Price)
      Next

      Return jiColl
    End Function
    Private Sub NewSetJournalEntryItem(ByRef jiColl As JournalEntryItemCollection, ByVal item As PAItem, ByVal wbsd As WBSDistribute, ByRef realAccount As Account, ByVal realAmount As Decimal, ByRef jiCoscenter As CostCenter, ByVal map As String, Optional ByVal note As String = "")
      Dim ji As New JournalEntryItem
      ji.Mapping = map
      ji.Amount = realAmount
      ji.Account = realAccount
      If note.Length > 0 Then
        ji.Note = note
      End If
      If jiCoscenter.Originated Then
        ji.CostCenter = jiCoscenter
      Else
        ji.CostCenter = CostCenter.GetDefaultCostCenter(CostCenter.DefaultCostCenterType.HQ)
      End If
      ji.EntityItem = CInt(item.Sequence)
      ji.EntityItemType = item.ItemType.Value
      ji.table = Me.TableName & "item"

      If wbsd Is Nothing Then
        ji.AtomNote = "���Ţ sequence ����� WBS"
      Else
        ji.CustomRefstr = wbsd.WBS.Id.ToString
        ji.CustomRefType = "WBS"
        ji.AtomNote = "���Ţ sequence ����ҧ件֧ WBS ��"
      End If

      jiColl.Add(ji)
    End Sub

#End Region

#Region "IWBSAllocatable"

    Public Function GetWBSAllocatableItemCollection() As WBSAllocatableItemCollection Implements IWBSAllocatable.GetWBSAllocatableItemCollection
      Dim coll As New WBSAllocatableItemCollection
      For Each item As PAItem In Me.ItemCollection
        If item.ItemType.Value <> 160 AndAlso item.ItemType.Value <> 162 AndAlso item.RefDocType <> 291 Then
          'If Not item.IsHasChild Then
          item.UpdateWBSQty()

          If Not Me.Originated Then
            For Each wbsd As WBSDistribute In item.WBSDistributeCollection
              wbsd.ChildAmount = 0

              If m_hashWbsId Is Nothing Then
                m_hashWbsId = New Hashtable
              Else
                If Not m_hashWbsId.Contains(wbsd.WBS.Id) Then
                  m_hashWbsId.Add(wbsd.WBS.Id, wbsd)
                  wbsd.GetChildIdList()
                End If
              End If

              For Each allItem As PAItem In Me.ItemCollection
                For Each childWbsd As WBSDistribute In allItem.WBSDistributeCollection
                  If wbsd.ChildIdList.Contains(childWbsd.WBS.Id) Then
                    wbsd.ChildAmount += childWbsd.Amount
                  End If
                Next
              Next
            Next
          End If

          coll.Add(item)
          'End If
        End If
      Next
      Return coll
    End Function

    Public Property FromCostCenter() As CostCenter Implements IWBSAllocatable.FromCostCenter
      Get

      End Get
      Set(ByVal Value As CostCenter)

      End Set
    End Property

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

#Region " IApprovAble "
    Public Function ApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.ApproveData
      '����¹��� Trigger ᷹
      Return New SaveErrorException("0")

      With Me
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        ' ���ҧ ArrayList �ҡ Item �ͧ  SqlParameter ...
        Dim paramArrayList As New ArrayList

        paramArrayList.Add(returnVal)
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", DocID))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approveperson", currentUserId))
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_approvedate", theTime))

        ' ���ҧ SqlParameter �ҡ ArrayList ...
        Dim sqlparams() As SqlParameter
        sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

        ' ��� Transaction �Ǻ��������ǹ�ͧ Client �����Ҩ������ loop ��
        Try
          SqlHelper.ExecuteNonQuery(Me.ConnectionString, CommandType.StoredProcedure, "Approve" & Me.TableName, sqlparams)
          Return New SaveErrorException(returnVal.Value.ToString)
        Catch ex As SqlException
          Return New SaveErrorException(ex.ToString)
        Catch ex As Exception
          Return New SaveErrorException(ex.ToString)
        End Try
      End With
    End Function
    Dim m As CostCenter
    Public Property ToCC() As CostCenter 'Implements IHasToCostCenter.ToCC
      Get
        Return m 'Me.CostCenter
      End Get
      Set(ByVal Value As CostCenter)
        Me.m = Value
      End Set
    End Property
    Public ReadOnly Property IsApproved() As Boolean Implements IApprovAble.IsApproved
      Get
        If Not (Me.ApprovePerson Is Nothing) AndAlso Me.ApprovePerson.Originated Then
          Return True
        End If
        Return False
      End Get
    End Property

    Public ReadOnly Property ApproveIcon() As String Implements IApprovAble.ApproveIcon
      Get
        Return "Icons.16x16.Approve"
      End Get
    End Property

    Public ReadOnly Property ShowUnApproveButton() As Boolean Implements IApprovAble.ShowUnApproveButton
      Get
        Return Not Me.Status.Value = 0
      End Get
    End Property

    Public Function UnApproveData(ByVal DocID As Integer, ByVal currentUserId As Integer, ByVal theTime As Date) As SaveErrorException Implements IApprovAble.UnApproveData

    End Function

    Public ReadOnly Property UnApproveIcon() As String Implements IApprovAble.UnApproveIcon
      Get

      End Get
    End Property
#End Region

#Region "IDocStatus"
    Public ReadOnly Property DocStatus As String Implements IDocStatus.DocStatus
      Get
        If Me.Status.Value = 0 Then
          Return "Canceled"
        Else
          Dim obj As Object = Configuration.GetConfig("ApprovePA")
          If CBool(obj) Then
            If Me.IsAuthorized Then
              Return "Authorized"
            ElseIf Me.IsLevelApproved Then
              Return "Approved"
            ElseIf Me.IsReject Then
              Return "Reject"
            End If
          End If
        End If
        Return ""
      End Get
    End Property
#End Region

#Region "Event"
    Public Event AdvanceClick(ByVal sender As Object, ByVal e As System.EventArgs)
#End Region

    Private Function GetVORetention() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
     , CommandType.StoredProcedure _
     , "GetVORetention" _
     , New SqlParameter("@sc_id", Me.Sc.Id) _
     )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function

    Private Function GetVOAdvancePayAmount() As Decimal
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
     , CommandType.StoredProcedure _
     , "GetVOAdvancePayAmount" _
     , New SqlParameter("@sc_id", Me.Sc.Id) _
     )
      If ds.Tables(0).Rows.Count <> 0 Then
        If IsNumeric(ds.Tables(0).Rows(0)(0)) Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      End If
      Return 0
    End Function

#Region "IApproveStatusAble"
    Public ReadOnly Property IsAuthorized As Boolean Implements IApproveStatusAble.IsAuthorized
      Get
        Return Me.IsApproved
      End Get
    End Property

    Public ReadOnly Property IsLevelApproved As Boolean Implements IApproveStatusAble.IsLevelApproved
      Get
        If Not Me.ApproveDocColl Is Nothing AndAlso Me.ApproveDocColl.Count > 0 Then
          Dim approveDoc As ApproveDoc = m_approveDocColl(ApproveDocColl.Count - 1)
          If Not approveDoc Is Nothing Then
            If Not approveDoc.Reject AndAlso approveDoc.Level > 0 Then
              Return True
            End If
          End If
        End If

        Return False
      End Get
    End Property

    Public ReadOnly Property IsReject As Boolean Implements IApproveStatusAble.IsReject
      Get
        If Not Me.ApproveDocColl Is Nothing AndAlso Me.ApproveDocColl.Count > 0 Then
          Dim approveDoc As ApproveDoc = m_approveDocColl(ApproveDocColl.Count - 1)
          If Not approveDoc Is Nothing Then
            Return approveDoc.Reject
          End If
        End If

        Return False
      End Get
    End Property
#End Region

#Region "IDocumentPersonAble"

    ReadOnly Property DocumentEditedUser As DocumentEditedUser Implements IDocumentPersonAble.DocumentEditedUser
      Get
        Dim m_documentEditedUser As New DocumentEditedUser

        m_documentEditedUser.ApprovedUserList = Me.GetApprovedUserList
        m_documentEditedUser.ApprovedUser = Me.GetApprovedUser
        m_documentEditedUser.AuthorizedUser = Me.GetAutherizedUser
        m_documentEditedUser.CanceledUser = Me.GetCanceledUser
        m_documentEditedUser.CreatedUser = Me.GetCreatedUser
        m_documentEditedUser.EditedUser = Me.GetEditedUser
        m_documentEditedUser.EditedUser = Me.GetRejectUser
        m_documentEditedUser.Employee = Me.Receiver

        Return m_documentEditedUser
      End Get
    End Property

    Private Function GetApprovedUserList() As List(Of ApproveDoc)
      Dim LastLevelApprove As New List(Of ApproveDoc)
      Dim aProvePerson As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso Not LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        For Each ap As ApproveDoc In LastLevelApprove
          If Not ap.Reject Then
            aProvePerson.Add(ap)
          End If
        Next
      End If

      Return aProvePerson
    End Function

    Public Function GetApprovedUser() As EditedUser
      Dim aplist As List(Of ApproveDoc) = Me.GetApprovedUserList
      Dim editeduser As New EditedUser
      If aplist.Count > 1 Then
        Dim userHs As New Hashtable
        Dim maxLevel As Integer = 0
        For Each doc As ApproveDoc In aplist
          userHs(doc.Level) = doc
          maxLevel = Math.Max(maxLevel, doc.Level)
        Next
        'Return New User(CType(userHs(maxLevel - 1), ApproveDoc).Originator)
        If Not userHs(maxLevel - 1) Is Nothing Then
          editeduser.UserId = CType(userHs(maxLevel - 1), ApproveDoc).Originator
          editeduser.UserName = New User(CType(userHs(maxLevel - 1), ApproveDoc).Originator).Name
          editeduser.EditedDate = CType(userHs(maxLevel - 1), ApproveDoc).OriginDate
          Return editeduser
        End If

      End If
      If aplist.Count > 0 Then
        'Return New User(aplist.Item(aplist.Count - 1).Originator)
        editeduser.UserId = aplist.Item(aplist.Count - 1).Originator
        editeduser.UserName = New User(aplist.Item(aplist.Count - 1).Originator).Name
        editeduser.EditedDate = aplist.Item(aplist.Count - 1).OriginDate
      End If
      Return editeduser
    End Function

    Public Function GetAutherizedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Me.ApprovePerson Is Nothing Then
        editeduser.UserId = Me.ApprovePerson.Id
        editeduser.UserName = Me.ApprovePerson.Name
        editeduser.EditedDate = Me.ApproveDate
      End If
      Return editeduser
    End Function

    Public Function GetCanceledUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Me.CancelPerson Is Nothing Then
        editeduser.UserId = Me.CancelPerson.Id
        editeduser.UserName = Me.CancelPerson.Name
        editeduser.EditedDate = Me.CancelDate
      End If
      Return editeduser
    End Function

    Public Function GetCreatedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not Originator Is Nothing Then
        editeduser.UserId = Me.Originator.Id
        editeduser.UserName = Me.Originator.Name
        editeduser.EditedDate = Me.OriginDate
      End If
      Return editeduser
    End Function

    Public Function GetEditedUser() As EditedUser
      Dim editeduser As New EditedUser
      If Not LastEditor Is Nothing Then
        editeduser.UserId = Me.LastEditor.Id
        editeduser.UserName = Me.LastEditor.Name
        editeduser.EditedDate = Me.LastEditDate
      End If
      Return editeduser
    End Function

    Public Function GetRejectUser() As EditedUser
      Dim editeduser As New EditedUser
      Dim LastLevelApprove As New List(Of ApproveDoc)
      Dim aProvePerson As New List(Of ApproveDoc)
      For Each ap As ApproveDoc In Me.ApproveDocColl
        If ap.Level > 0 Then
          LastLevelApprove.Add(ap)
        End If
      Next
      If LastLevelApprove.Count > 0 AndAlso LastLevelApprove.Item(LastLevelApprove.Count - 1).Reject Then
        editeduser.UserId = LastLevelApprove.Item(LastLevelApprove.Count - 1).Originator
        editeduser.UserName = New User(LastLevelApprove.Item(LastLevelApprove.Count - 1).Originator).Name
        editeduser.EditedDate = LastLevelApprove.Item(LastLevelApprove.Count - 1).OriginDate
      End If
      Return editeduser
    End Function

#End Region
  End Class

  Public Class PAForApprove
    Inherits PA
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property CodonName() As String
      Get
        Return "PAForApprove"
      End Get
    End Property
  End Class

  Public Class SCForPA
    Inherits SC
    Implements IVisibleButtonShowColorListAble
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "SCForPA"
      End Get
    End Property
    Public Overrides ReadOnly Property Columns() As ColumnCollection
      Get
        Return New ColumnCollection(Me.ClassName, 0)
      End Get
    End Property

    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Me.Construct(ds, aliasPrefix)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String, Optional ByVal noItem As Boolean = False)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      Dim dr As DataRow = ds.Tables(0).Rows(0)
      Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      'MyBase.Construct(dr, aliasPrefix)

      Dim drh As New DataRowHelper(dr)
      Me.Id = drh.GetValue(Of Integer)("sc_id")
      Me.Code = drh.GetValue(Of String)("sc_code")

      Me.DocDate = drh.GetValue(Of Date)("sc_docdate")

      Me.CreditPeriod = drh.GetValue(Of Integer)("sc_creditperiod")
      Me.ContactPerson = drh.GetValue(Of String)("sc_contactPerson")
      Me.StartDate = drh.GetValue(Of Date)("sc_startdate")
      Me.EndDate = drh.GetValue(Of Date)("sc_enddate")
      Me.SubContractor = New Supplier
      Me.SubContractor = New Supplier(CInt(dr("sc_subcontractor"))) 'Supplier.GetSupplierbyDataRow(dr)
      'Me.CostCenter = CostCenter.GetCCMinDataById(drh.GetValue(Of Integer)("sc_cc"))
      Me.Director = New Employee(dr, "")
      Me.TaxRate = drh.GetValue(Of Decimal)("sc_taxrate")

    End Sub
  End Class
End Namespace
