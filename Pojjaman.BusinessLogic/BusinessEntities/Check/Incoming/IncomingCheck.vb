Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports Longkong.Core.Services
Imports System.Collections.Generic

Namespace Longkong.Pojjaman.BusinessLogic
  Public Class IncomingCheck
    Inherits SimpleBusinessEntityBase
    Implements IHasAmount, IHasIBillablePerson, ICheckPeriod, IReceiveItem


#Region "Members"
    Private m_cqcode As String
    Private m_ReceiveDate As Date
    Private m_oldReceiveDate As Date

    Private m_amount As Decimal
    Private m_bankcharge As Decimal
    Private m_wht As Decimal

    Private m_customer As Customer

    Private m_receivePerson As Employee
    Private m_dueDate As Date
    Private m_docDate As Date

    Private m_bankacct As BankAccount
    Private m_OldBankacct As BankAccount
    Private m_depositBankAcct As BankAccount
    Private m_bank As Bank
    Private m_custbankbranch As String

    Private m_note As String
    Private m_beforecode As String

    Private m_docStatus As IncomingCheckDocStatus

#End Region

#Region "Constructors"
    Public Sub New()
      MyBase.New()
    End Sub
    Public Sub New(ByVal id As Integer)
      MyBase.New(id)
    End Sub
    Public Sub New(ByVal code As String)
      MyBase.New(code)
    End Sub
    Public Sub New(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      Me.Construct(dr, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct()
      MyBase.Construct()
      Me.m_receivePerson = New Employee
      Me.m_customer = New Customer

      Me.m_bank = New Bank
      Me.m_bankacct = New BankAccount
      Me.m_OldBankacct = New BankAccount
      Me.m_docStatus = New IncomingCheckDocStatus(-1)
      Me.Status = New CheckStatus(-1)

      Me.m_ReceiveDate = Now.Date
      Me.m_oldReceiveDate = Now.Date
      Me.m_dueDate = Now.Date
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
      MyBase.Construct(ds, aliasPrefix)
    End Sub
    Protected Overloads Overrides Sub Construct(ByVal dr As System.Data.DataRow, ByVal aliasPrefix As String)
      MyBase.Construct(dr, aliasPrefix)
      With Me

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_cqcode") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_cqcode") Then
          .m_cqcode = CStr(dr(aliasPrefix & Me.Prefix & "_cqcode"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "cust_id") Then
          If Not dr.IsNull(aliasPrefix & "cust_id") Then
            .m_customer = New Customer(dr, aliasPrefix)
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "check_customer") AndAlso Not dr.IsNull(aliasPrefix & "check_customer") Then
            .m_customer = New Customer(CInt(dr(aliasPrefix & "check_customer")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "employee_id") Then
          If Not dr.IsNull(aliasPrefix & "employee_id") Then
            .m_receivePerson = New Employee(dr, aliasPrefix)
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "check_receiveperson") AndAlso Not dr.IsNull(aliasPrefix & "check_receiveperson") Then
            .m_receivePerson = New Employee(CInt(dr(aliasPrefix & "check_receiveperson")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_ReceiveDate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_ReceiveDate") Then
          .ReceiveDate = CDate(dr(aliasPrefix & Me.Prefix & "_ReceiveDate"))
          .m_oldReceiveDate = CDate(dr(aliasPrefix & Me.Prefix & "_ReceiveDate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "bankacct_id") Then
          If Not dr.IsNull(aliasPrefix & "bankacct_id") Then
            .m_bankacct = New BankAccount(dr, aliasPrefix)
            '.m_OldBankacct = m_bankacct
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "check_bankacct") AndAlso Not dr.IsNull(aliasPrefix & "check_bankacct") Then
            .m_bankacct = New BankAccount(CInt(dr(aliasPrefix & "check_bankacct")))
            '.m_OldBankacct = m_bankacct
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "bank_id") Then
          If Not dr.IsNull(aliasPrefix & "bank_id") Then
            .m_bank = New Bank(dr, aliasPrefix)
          End If
        Else
          If dr.Table.Columns.Contains(aliasPrefix & "check_bank") AndAlso Not dr.IsNull(aliasPrefix & "check_bank") Then
            .m_bank = New Bank(CInt(dr(aliasPrefix & "check_bank")))
          End If
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_custbankbranch") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_custbankbranch") Then
          .CustBankBranch = CStr(dr(aliasPrefix & Me.Prefix & "_custbankbranch"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_duedate") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_duedate") Then
          .DueDate = CDate(dr(aliasPrefix & Me.Prefix & "_duedate"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_amt") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_amt") Then
          .m_amount = CDec(dr(aliasPrefix & Me.Prefix & "_amt"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_bankcharge") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_bankcharge") Then
          .m_bankcharge = CDec(dr(aliasPrefix & Me.Prefix & "_bankcharge"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_wht") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_wht") Then
          .m_wht = CDec(dr(aliasPrefix & Me.Prefix & "_wht"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_note") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_note") Then
          .Note = CStr(dr(aliasPrefix & Me.Prefix & "_note"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & "check_docstatus") AndAlso Not dr.IsNull(aliasPrefix & "check_docstatus") Then
          .m_docStatus.Value = CInt(dr(aliasPrefix & "check_docstatus"))
        End If

        If dr.Table.Columns.Contains(aliasPrefix & Me.Prefix & "_status") AndAlso Not dr.IsNull(aliasPrefix & Me.Prefix & "_status") Then
          .Status.Value = CInt(dr(aliasPrefix & Me.Prefix & "_status"))
        End If

      End With
      RefreshRVList()
    End Sub
#End Region

#Region "Properties"
    Private m_receiveList As List(Of ReceiveForList)
    Public ReadOnly Property ReceiveList As List(Of ReceiveForList)
      Get
        If m_receiveList Is Nothing Then
          m_receiveList = New List(Of ReceiveForList)
        End If
        Return m_receiveList
      End Get
    End Property
    Public Property CqCode() As String
      Get
        Return m_cqcode
      End Get
      Set(ByVal Value As String)
        m_cqcode = Value
      End Set
    End Property
    Public Property beforeCode() As String
      Get
        Return m_beforecode
      End Get
      Set(ByVal Value As String)
        m_beforecode = Value
      End Set
    End Property
    Public Property Amount() As Decimal Implements IHasAmount.Amount      Get        Return m_amount      End Get      Set(ByVal Value As Decimal)        m_amount = Value      End Set    End Property    Public Property BankCharge() As Decimal      Get
        Return m_bankcharge
      End Get
      Set(ByVal Value As Decimal)
        m_bankcharge = Value
      End Set
    End Property    Public Property WHT() As Decimal      Get
        Return m_wht
      End Get
      Set(ByVal Value As Decimal)
        m_wht = Value
      End Set
    End Property    Public Property Customer() As Customer      Get        Return m_customer      End Get      Set(ByVal Value As Customer)        m_customer = Value      End Set    End Property    Public Property DocStatus() As IncomingCheckDocStatus      Get        Return m_docStatus      End Get      Set(ByVal Value As IncomingCheckDocStatus)        m_docStatus = Value      End Set    End Property    Public Property ReceivePerson() As Employee      Get        Return m_receivePerson      End Get      Set(ByVal Value As Employee)        m_receivePerson = Value      End Set    End Property    Public Property DueDate() As Date      Get        Return m_dueDate      End Get      Set(ByVal Value As Date)        m_dueDate = Value      End Set    End Property    Public Property DocDate() As Date      Get        Return m_docDate      End Get      Set(ByVal Value As Date)        m_docDate = Value        m_ReceiveDate = m_docDate      End Set    End Property    Public ReadOnly Property CreateDate As Nullable(Of Date) Implements IReceiveItem.CreateDate
      Get
        Return DocDate
      End Get
    End Property	    Public Property BankAccount() As BankAccount      Get
        Return m_bankacct
      End Get
      Set(ByVal Value As BankAccount)
        m_bankacct = Value
      End Set
    End Property    Public Property OldBankAccount As BankAccount      Get
        If m_OldBankacct Is Nothing Then
          m_OldBankacct = New BankAccount
        End If
        Return m_OldBankacct
      End Get
      Set(ByVal value As BankAccount)
        m_OldBankacct = value
      End Set
    End Property    Public ReadOnly Property DepositBankAccount() As BankAccount      Get
        If m_depositBankAcct Is Nothing Then
          Dim sqlcmd As String
          sqlcmd = "select checkupdate.cqupdate_bankacct from checkupdate" _
          & " inner join checkupdateitem on checkupdate.cqupdate_id = checkupdateitem.cqupdatei_cqupdateid" _
          & " where cqupdate_checktype = 27 and cqupdate_updatedstatus = 3" _
          & " and cqupdate_canceled is null and checkupdateitem.cqupdatei_entity = " & Me.Id
          Dim BankAcctID As Object
          BankAcctID = SqlHelper.ExecuteScalar(Me.ConnectionString _
           , CommandType.Text _
           , sqlcmd _
           )
          If Not BankAcctID Is Nothing AndAlso IsNumeric(BankAcctID) Then
            m_depositBankAcct = New BankAccount(CInt(BankAcctID))
          End If
        End If
        Return m_depositBankAcct
      End Get
      'Set(ByVal Value As BankAccount)
      '	m_depositBankAcct = Value
      'End Set
    End Property    Public Property Bank() As Bank      Get        Return m_bank      End Get      Set(ByVal Value As Bank)        m_bank = Value      End Set    End Property    Public Property CustBankBranch() As String      Get        If m_custbankbranch Is Nothing Then          m_custbankbranch = ""
        End If        Return m_custbankbranch      End Get      Set(ByVal Value As String)        m_custbankbranch = Value      End Set    End Property    Public Property ReceiveDate() As Date Implements ICheckPeriod.DocDate      Get
        Return m_ReceiveDate
      End Get
      Set(ByVal Value As DateTime)
        m_ReceiveDate = Value
        m_docDate = m_ReceiveDate
      End Set
    End Property    Public ReadOnly Property OldReceiveDate As Date Implements ICheckPeriod.OldDocDate      Get
        Return m_oldReceiveDate
      End Get
    End Property    Public Property Note() As String      Get        If m_note Is Nothing Then          m_note = ""
        End If        Return m_note      End Get      Set(ByVal Value As String)        m_note = Value      End Set    End Property#End Region

#Region "Overrides"
    ''' <summary>
    ''' IsOldCheck �� �͹ Save ��ҹ��
    ''' </summary>
    ''' <value></value>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Property IsOldCheck As Boolean
    Public Overrides ReadOnly Property Prefix() As String
      Get
        Return "check"
      End Get
    End Property
    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "IncomingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property TableName() As String
      Get
        Return "IncomingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property GetSprocName() As String
      Get
        Return "GetIncomingCheck"
      End Get
    End Property

    Public Overrides ReadOnly Property DetailPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.IncomingCheck.DetailLabel}"
      End Get
    End Property
    Public Overrides ReadOnly Property DetailPanelIcon() As String
      Get
        Return "Icons.16x16.IncomingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelIcon() As String
      Get
        Return "Icons.16x16.IncomingCheck"
      End Get
    End Property
    Public Overrides ReadOnly Property ListPanelTitle() As String
      Get
        Return "${res:Longkong.Pojjaman.BusinessLogic.IncomingCheck.ListLabel}"
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

    Private Sub ResetID(ByVal oldid As Integer)
      Me.Id = oldid
    End Sub
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer) As SaveErrorException
      If Me.Amount <= 0 Then
        Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", _
        "${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblAmount}")
      End If

      saveCheckType = SaveType.Normal
      'Return New SaveErrorException("Not Yet Implemented")

      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current
      Dim paramArrayList As New ArrayList

      paramArrayList.Add(returnVal)
      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If Me.AutoGen And Me.Code.Length = 0 Then
        Me.Code = Me.GetNextCode
      End If
      Me.AutoGen = False

      If Me.Status.Value = -1 Then
        Me.Status.Value = 2
      End If
      If Me.DocStatus.Value = -1 Then
        Me.DocStatus.Value = 1 'Default = ������
      End If

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cqcode", Me.CqCode))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_ReceiveDate", ValidDateOrDBNull(Me.ReceiveDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_duedate", ValidDateOrDBNull(Me.DueDate)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_receiveperson", ValidIdOrDBNull(Me.ReceivePerson)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_customer", ValidIdOrDBNull(Me.Customer)))
      'paramArrayList.Add(New SqlParameter("@" & me.prefix & "_payer", DBNull.Value))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacct", ValidIdOrDBNull(Me.BankAccount)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bank", ValidIdOrDBNull(Me.Bank)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_custbankbranch", Me.CustBankBranch))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amt", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankcharge", Me.BankCharge))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wht", Me.WHT))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      'paramArrayList.Add(New SqlParameter("@" & me.prefix & "_payin", DBNull.Value))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docstatus", Me.DocStatus.Value))

      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      ' ���ҧ SqlParameter �ҡ ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(SimpleBusinessEntityBase.ConnectionString)

      If conn.State = ConnectionState.Open Then conn.Close()
      conn.Open()
      trans = conn.BeginTransaction
      Dim oldid As Integer = Me.Id
      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1 '�Ţ�����
              trans.Rollback()
              Me.ResetID(oldid)
              Return New SaveErrorException("${res:Global.Error.DupCheckCode}", New String() {Me.Code, Me.CqCode})
            Case -2
              trans.Rollback()
              Me.ResetID(oldid)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Me.ResetID(oldid)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If

        trans.Commit()
        ' ��Ǩ�Ѻ Error �ͧ��� Save ...
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As Exception
        trans.Rollback()
        Me.ResetID(oldid)
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        trans.Rollback()
        Me.ResetID(oldid)
        Return New SaveErrorException(returnVal.Value.ToString)
      Finally
        conn.Close()
      End Try

    End Function


    '----------------SAVING FROM OTHER DOC---------------------'
    Public Overrides Function GetLastCode(ByVal prefixPattern As String) As String
      If saveCheckType = SaveType.Normal Then
        Return MyBase.GetLastCode(prefixPattern)
      End If
      If connz Is Nothing Then
        Return ""
      End If
      Dim sql As String = "select top 1 " & Me.Prefix & "_code from [" & Me.TableName & "] where " & Me.Prefix & "_code like '" & prefixPattern & "%' " & " order by " & Me.Prefix & "_id desc"

      Dim cmd As SqlCommand = connz.CreateCommand
      cmd.CommandText = sql
      cmd.Transaction = transz

      Dim obj As Object = cmd.ExecuteScalar
      If Not IsDBNull(obj) AndAlso Not obj Is Nothing Then
        Return obj.ToString
      End If
      Return ""
    End Function
    Public Overrides Function DuplicateCode(ByVal newCode As String) As Boolean
      If saveCheckType = SaveType.Normal Then
        Return MyBase.DuplicateCode(newCode)
      End If
      If connz Is Nothing Then
        Return True
      End If
      Dim sql As String = "select count(*) from [" & Me.TableName & "] where " & Me.Prefix & "_code='" & newCode & "' and " & Me.Prefix & "_id <> " & Me.Id

      Dim cmd As SqlCommand = connz.CreateCommand
      cmd.CommandText = sql
      cmd.Transaction = transz

      Dim recordCount As Object = cmd.ExecuteScalar
      If Not IsDBNull(recordCount) AndAlso CInt(recordCount) > 0 Then
        Return True
      End If
      Return False
    End Function
    Dim connz As SqlConnection
    Dim transz As SqlTransaction
    Dim saveCheckType As SaveType
    Private Enum SaveType
      Normal
      OtherDoc
    End Enum
    Public Overloads Overrides Function Save(ByVal currentUserId As Integer, ByVal conn As System.Data.SqlClient.SqlConnection, ByVal trans As System.Data.SqlClient.SqlTransaction) As SaveErrorException
      If Me.Amount <= 0 Then
        Return New SaveErrorException("${res:Global.Error.ZeroValueMiss}", _
        "${res:Longkong.Pojjaman.Gui.Panels.IncomingCheckDetailView.lblAmount}")
      End If
      'Return New SaveErrorException("Not Yet Implemented")

      connz = conn
      transz = trans
      saveCheckType = SaveType.OtherDoc

      Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
      returnVal.ParameterName = "RETURN_VALUE"
      returnVal.DbType = DbType.Int32
      returnVal.Direction = ParameterDirection.ReturnValue
      returnVal.SourceVersion = DataRowVersion.Current
      Dim paramArrayList As New ArrayList

      paramArrayList.Add(returnVal)
      If Me.Originated Then
        paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_id", Me.Id))
      End If

      Dim theTime As Date = Now
      Dim theUser As New User(currentUserId)

      If beforeCode Is Nothing OrElse beforeCode = "" Then
        If Me.AutoGen And Me.Code.Length = 0 Then
          Me.Code = Me.GetNextCode
        End If
      Else
        Dim autoCodeFormat As String
        If Not Me.AutoCodeFormat Is Nothing Then
          If Me.AutoCodeFormat.Format.Length > 0 Then
            autoCodeFormat = Me.AutoCodeFormat.Format
          Else
            autoCodeFormat = Entity.GetAutoCodeFormat(Me.EntityId)
          End If
        Else
          autoCodeFormat = Entity.GetAutoCodeFormat(Me.EntityId)
        End If
        Me.Code = CodeGenerator.Generate(autoCodeFormat, beforeCode, Me)
      End If

      Me.AutoGen = False

      If Me.Status.Value = -1 Then
        Me.Status.Value = 2
      End If
      If Me.DocStatus.Value = -1 Then
        Me.DocStatus.Value = 1 'Default = ������
      End If

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_code", Me.Code))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_cqcode", Me.CqCode))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_ReceiveDate", ValidDateOrDBNull(Me.ReceiveDate)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_duedate", ValidDateOrDBNull(Me.DueDate)))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_receiveperson", ValidIdOrDBNull(Me.ReceivePerson)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_customer", ValidIdOrDBNull(Me.Customer)))
      'paramArrayList.Add(New SqlParameter("@" & me.prefix & "_payer", DBNull.Value))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankacct", ValidIdOrDBNull(Me.BankAccount)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bank", ValidIdOrDBNull(Me.Bank)))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_custbankbranch", Me.CustBankBranch))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_amt", Me.Amount))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_bankcharge", Me.BankCharge))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_wht", Me.WHT))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_note", Me.Note))
      'paramArrayList.Add(New SqlParameter("@" & me.prefix & "_payin", DBNull.Value))

      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_status", Me.Status.Value))
      paramArrayList.Add(New SqlParameter("@" & Me.Prefix & "_docstatus", Me.DocStatus.Value))

      SetOriginEditCancelStatus(paramArrayList, currentUserId, theTime)

      ' ���ҧ SqlParameter �ҡ ArrayList ...
      Dim sqlparams() As SqlParameter
      sqlparams = CType(paramArrayList.ToArray(GetType(SqlParameter)), SqlParameter())

      Dim oldid As Integer = Me.Id
      Try
        Me.ExecuteSaveSproc(conn, trans, returnVal, sqlparams, theTime, theUser)
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1 '�Ţ�����
              Me.ResetID(oldid)
              Return New SaveErrorException("${res:Global.Error.DupCheckCode}", New String() {Me.Code, Me.CqCode})
            Case -2
              Me.ResetID(oldid)
              Return New SaveErrorException(returnVal.Value.ToString)
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          Me.ResetID(oldid)
          Return New SaveErrorException(returnVal.Value.ToString)
        End If

        ' ��Ǩ�Ѻ Error �ͧ��� Save ...
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As Exception
        Me.ResetID(oldid)
        Return New SaveErrorException(returnVal.Value.ToString)
      Catch ex As SqlException
        Me.ResetID(oldid)
        Return New SaveErrorException(returnVal.Value.ToString)
      Finally
      End Try

    End Function
    Public Function CheckUpdateBackAccountAndCheckDeposit(ByVal currentUserId As Integer, _
                                                          ByVal conn As System.Data.SqlClient.SqlConnection, _
                                                          ByVal trans As System.Data.SqlClient.SqlTransaction, _
                                                          ByVal receiveDate As DateTime) As SaveErrorException
      Try
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, _
                           "CheckUpdateBackAccountAndCheckDeposit", _
                           New SqlParameter() {New SqlParameter("@check_id", Me.Id), _
                                               New SqlParameter("@check_bankacct", SimpleBusinessEntityBase.ValidIdOrDBNull(Me.BankAccount)), _
                                               New SqlParameter("@check_bank", SimpleBusinessEntityBase.ValidIdOrDBNull(Me.Bank)), _
                                               New SqlParameter("@check_custbankbranch", Me.CustBankBranch), _
                                               New SqlParameter("@check_receivedate", receiveDate), _
                                               New SqlParameter("@check_lasteditor", currentUserId)})

        '        If Not Me.BankAccount Is Nothing AndAlso Me.BankAccount.Originated Then
        '            If Me.BankAccount.Id <> Me.OldBankAccount.Id Then
        '                Dim upd As New UpdateCheckDeposit
        '                upd.AutoGen = True

        '                Dim cmbCode As New ComboBox
        '                BusinessLogic.Entity.NewPopulateCodeCombo(cmbCode, upd.EntityId, currentUserId)
        '                If cmbCode.Items.Count > 0 Then
        '                    upd.Code = CType(cmbCode.Items(0), AutoCodeFormat).Format
        '                    cmbCode.SelectedIndex = 0
        '                    upd.AutoCodeFormat = CType(cmbCode.Items(0), AutoCodeFormat)
        '                End If

        '                upd.DocDate = Me.DocDate
        '                upd.BankAccount = Me.BankAccount
        '                upd.TotalAmount = Me.Amount

        '                Dim upditem As New UpdateCheckDepositItem
        '                upditem.BeforeStatus = New IncomingCheckDocStatus(1)
        '                upditem.Entity = Me
        '                upditem.LineNumber = 1
        '                upd.Add(upditem)

        '                Dim saveerr As SaveErrorException = upd.Save(currentUserId, conn, trans)
        '                If Not IsNumeric(saveerr.Message) Then
        '                    Return New SaveErrorException(saveerr.Message)
        '                End If
        '            End If

        '        End If

        Return New SaveErrorException("1")
      Catch ex As SqlException
        Return New SaveErrorException(ex.Message)
      Catch ex As Exception
        Return New SaveErrorException(ex.Message)
      End Try
    End Function
#End Region

#Region "Methods"
    Public Sub RefreshRVList()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
      , "GetInComingCheckReceives" _
      , New SqlParameter("@check_id", Me.Id) _
      , New SqlParameter("@cust_id", Me.ValidIdOrDBNull(Me.Customer)) _
      )

      m_receiveList = New List(Of ReceiveForList)
      For Each row As DataRow In ds.Tables(0).Rows
        Dim deh As New DataRowHelper(row)
        Dim p As New ReceiveForList
        p.Id = deh.GetValue(Of Integer)("Id")
        p.Code = deh.GetValue(Of String)("Code")
        p.RefId = deh.GetValue(Of Integer)("RefId")
        p.RefCode = deh.GetValue(Of String)("RefCode")
        p.RefType = deh.GetValue(Of String)("RefType")
        p.RefTypeId = deh.GetValue(Of Integer)("RefTypeId")
        p.RefDocDate = deh.GetValue(Of Date)("RefDocDate")
        p.RefDueDate = deh.GetValue(Of Date)("RefDueDate")
        p.RefAmount = deh.GetValue(Of Decimal)("RefAmount")
        p.Amount = deh.GetValue(Of Decimal)("Amount")
        p.RefPaid = deh.GetValue(Of Decimal)("RefPaid")
        p.Note = deh.GetValue(Of String)("Note")
        p.JustAdded = False

        ''===========================================================
        'p.PayeeFax = deh.GetValue(Of String)("PayeeFax")
        'p.PayeeID = deh.GetValue(Of String)("PayeeID")
        'p.PayeeName = deh.GetValue(Of String)("PayeeName")
        'p.PayeeTaxID = deh.GetValue(Of String)("PayeeTaxID")
        'p.PersonalID = deh.GetValue(Of String)("PersonalID")

        'p.KbankDCAccount = deh.GetValue(Of String)("KbankDCAccount")
        'p.KbankDCBank = deh.GetValue(Of String)("KbankDCBank")
        'p.KbankMCAccount = deh.GetValue(Of String)("KbankMCAccount")
        'p.KbankMCBank = deh.GetValue(Of String)("KbankMCBank")
        '===========================================================

        ''===========================================================
        'Dim drs As DataRow() = ds.Tables(1).Select("ID=" & p.Id.ToString)
        'If Not drs Is Nothing AndAlso drs.Length > 0 Then
        '  Dim currentTaxInfo As New TaxInfo
        '  For Each r As DataRow In drs
        '    Dim deh2 As New DataRowHelper(r)
        '    Dim wid As Integer = deh2.GetValue(Of Integer)("whtid")
        '    If currentTaxInfo.ID <> wid Then
        '      currentTaxInfo = New TaxInfo
        '      currentTaxInfo.ID = wid
        '      currentTaxInfo.TaxCondition = deh2.GetValue(Of String)("TaxCondition")
        '      currentTaxInfo.TaxForm = deh2.GetValue(Of String)("TaxForm")
        '      p.TaxInfos.Add(currentTaxInfo)
        '    End If
        '    Dim ti As New TaxInfoItem
        '    ti.Description = deh2.GetValue(Of String)("Description")
        '    ti.BeforeVAT = deh2.GetValue(Of Decimal)("BeforeVAT")
        '    ti.TaxRate = deh2.GetValue(Of Decimal)("TaxRate")
        '    ti.AfterVat = ti.BeforeVAT + Vat.GetVatAmount(ti.BeforeVAT)
        '    ti.WHT = deh2.GetValue(Of Decimal)("TaxAmount")
        '    currentTaxInfo.TaxInfoItems.Add(ti)
        '  Next
        'End If
        ''===========================================================
        m_receiveList.Add(p)
      Next
    End Sub
    Public Function GetRemainingAmount() As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetIncomingCheckAmount" _
                , New SqlParameter("@check_id", Me.Id) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try

    End Function
    Public Function GetRemainingAmount(ByVal receiveId As Integer) As Decimal
      Try
        Dim ds As DataSet = SqlHelper.ExecuteDataset( _
                Me.ConnectionString _
                , CommandType.StoredProcedure _
                , "GetIncomingCheckAmount" _
                , New SqlParameter("@check_id", Me.Id) _
                , New SqlParameter("@receivei_receive", receiveId) _
                )
        If ds.Tables(0).Rows.Count > 0 Then
          Return CDec(ds.Tables(0).Rows(0)(0))
        End If
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Function
    'Public Function GetUpdateCheckDepositRight() As Boolean
    '  Dim ds As DataSet = SqlHelper.ExecuteDataset(SimpleBusinessEntityBase.ConnectionString, CommandType.StoredProcedure, "GetUpdateCheckDepositRight", New SqlParameter("@check_id", Me.Id))
    '  If ds.Tables.Count > 0 AndAlso Not ds.Tables(0).Rows(0).IsNull(0) Then
    '    Return CBool(ds.Tables(0).Rows(0)(0))
    '  End If
    '  Return False
    'End Function
#End Region

#Region "Delete"
    Public Overrides ReadOnly Property CanDelete() As Boolean
      Get
        If Me.Originated Then
          Return Me.DocStatus.Value = 1
        End If
        Return False
      End Get
    End Property
    Public Overrides Function Delete() As SaveErrorException
      If Not Me.Originated Then
        Return New SaveErrorException("${res:Global.Error.NoIdError}")
      End If
      Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
      Dim format(0) As String
      format(0) = Me.Code
      If Not myMessage.AskQuestionFormatted("${res:Global.ConfirmDeleteIncomingCheck}", format) Then
        Return New SaveErrorException("${res:Global.CencelDelete}")
      End If
      Dim trans As SqlTransaction
      Dim conn As New SqlConnection(Me.ConnectionString)
      conn.Open()
      trans = conn.BeginTransaction()
      Try
        Dim returnVal As System.Data.SqlClient.SqlParameter = New SqlParameter
        returnVal.ParameterName = "RETURN_VALUE"
        returnVal.DbType = DbType.Int32
        returnVal.Direction = ParameterDirection.ReturnValue
        returnVal.SourceVersion = DataRowVersion.Current
        SqlHelper.ExecuteNonQuery(conn, trans, CommandType.StoredProcedure, "DeleteIncomingCheck", New SqlParameter() {New SqlParameter("@check_id", Me.Id), returnVal})
        If IsNumeric(returnVal.Value) Then
          Select Case CInt(returnVal.Value)
            Case -1
              trans.Rollback()
              Return New SaveErrorException("${res:Global.IncomingCheckIsReferencedCannotBeDeleted}")
            Case Else
          End Select
        ElseIf IsDBNull(returnVal.Value) OrElse Not IsNumeric(returnVal.Value) Then
          trans.Rollback()
          Return New SaveErrorException(returnVal.Value.ToString)
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

#Region "IHasIBillablePerson"
    Public Property BillablePerson() As IBillablePerson Implements IHasIBillablePerson.BillablePerson
      Get
        Return Me.Customer
      End Get
      Set(ByVal Value As IBillablePerson)
        If TypeOf Value Is Customer Then
          Me.Customer = CType(Value, Customer)
        End If
      End Set
    End Property
#End Region

  End Class

  Public Class IncomingCheckDocStatus
    Inherits CodeDescription

#Region " Construtors "
    Public Sub New(ByVal description As String)
      MyBase.New(description)
    End Sub
    Public Sub New(ByVal value As Integer)
      MyBase.New(value)
    End Sub
#End Region

#Region " Properties "
    Public Overrides ReadOnly Property CodeName() As String
      Get
        Return "incomingCheck_docstatus"
      End Get
    End Property
#End Region

  End Class

  Public Class IncomingCheckForCheckUpdateSelection
    Inherits IncomingCheck
    Public Sub New()
      MyBase.New()
    End Sub
    Public Overrides ReadOnly Property ClassName As String
      Get
        Return "IncomingCheckForCheckUpdateSelection"
      End Get
    End Property
    'Public Overrides ReadOnly Property CodonName As String
    '  Get
    '    Return "IncomingCheckForCheckUpdateSelection"
    '  End Get
    'End Property
  End Class

End Namespace
