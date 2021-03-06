Imports Longkong.Pojjaman.DataAccessLayer
Imports Longkong.Pojjaman.BusinessLogic
Imports System.Data
Imports System.Data.SqlClient
Imports System.IO
Imports System.Configuration
Imports System.Reflection
Imports Longkong.Pojjaman.Gui.Components
Imports Longkong.Core.Services

Namespace Longkong.Pojjaman.BusinessLogic
    Public Class ToolStockAdjustItem

#Region "Members"
        Private m_matstockadjust As ToolStockAdjust
        Private m_lineNumber As Integer
        Private m_entity As IHasName
        Private m_entitytype As Integer
        Private m_unit As Unit
        Private m_balanceqty As Decimal
        Private m_auditqty As Decimal
        Private m_diffqty As Decimal
        Private m_note As String

        Private m_conversion As Decimal = 1
#End Region

#Region "Constructors"
        Public Sub New()
            MyBase.New()
        End Sub
        Public Sub New(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Me.Construct(ds, aliasPrefix)
        End Sub
        Public Sub New(ByVal dr As DataRow, ByVal aliasPrefix As String)
            Me.Construct(dr, aliasPrefix)
        End Sub
        Public Sub New(ByVal dr As DataRow)
            Dim entitytype As Integer
            entitytype = (New Tool).EntityId
            With Me
                ' entity
                If dr.Table.Columns.Contains("tool_id") AndAlso Not dr.IsNull("tool_id") Then
                    Me.Entity = New Tool(CInt(dr("tool_id")))
                End If
                ' entity type 
                Me.EntityType = entitytype
                ' default unit
                If dr.Table.Columns.Contains("unit_id") AndAlso Not dr.IsNull("unit_id") Then
                    Me.Unit = CType(Me.Entity, Tool).Unit
                End If
                ' balance qty
                If dr.Table.Columns.Contains("remain") AndAlso Not dr.IsNull("remain") Then
                    Me.BalanceQty = CDec(dr("remain"))
                End If
            End With
        End Sub
        Protected Sub Construct(ByVal dr As DataRow, ByVal aliasPrefix As String)
            With Me
                ' Line number
                If dr.Table.Columns.Contains(aliasPrefix & Me.PreFixi & "_linenumber") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.PreFixi & "_linenumber") Then
                    .m_lineNumber = CInt(dr(aliasPrefix & Me.PreFixi & "_linenumber"))
                End If
                ' Entity
                If dr.Table.Columns.Contains(aliasPrefix & Me.PreFixi & "_entity") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.PreFixi & "_entity") Then
                    .m_entity = New Tool(CInt(dr(aliasPrefix & Me.PreFixi & "_entity")))
                End If
                ' Entity Type 
                If dr.Table.Columns.Contains(aliasPrefix & Me.PreFixi & "_entitytype") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.PreFixi & "_entitytype") Then
                    .m_entitytype = CInt(dr(aliasPrefix & Me.PreFixi & "_entitytype"))
                End If
                ' entity unit
                If dr.Table.Columns.Contains(aliasPrefix & Me.PreFixi & "_unit") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.PreFixi & "_unit") Then
                    .m_unit = New Unit(CInt(dr(aliasPrefix & Me.PreFixi & "_unit")))
                End If
                ' balance qty
                If dr.Table.Columns.Contains(aliasPrefix & Me.PreFixi & "_balanceqty") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.PreFixi & "_balanceqty") Then
                    .m_balanceqty = CDec(dr(aliasPrefix & Me.PreFixi & "_balanceqty"))
                End If
                ' audit qty
                If dr.Table.Columns.Contains(aliasPrefix & Me.PreFixi & "_auditqty") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.PreFixi & "_auditqty") Then
                    .m_auditqty = CDec(dr(aliasPrefix & Me.PreFixi & "_auditqty"))
                End If
                ' diff qty
                If dr.Table.Columns.Contains(aliasPrefix & Me.PreFixi & "_diffqty") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.PreFixi & "_diffqty") Then
                    .m_diffqty = CDec(dr(aliasPrefix & Me.PreFixi & "_diffqty"))
                End If
                ' Note 
                If dr.Table.Columns.Contains(aliasPrefix & Me.PreFixi & "_note") _
                AndAlso Not dr.IsNull(aliasPrefix & Me.PreFixi & "_note") Then
                    .m_note = CStr(dr(aliasPrefix & Me.PreFixi & "_note"))
                End If


            End With
        End Sub
        Protected Sub Construct(ByVal ds As System.Data.DataSet, ByVal aliasPrefix As String)
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            Me.Construct(dr, aliasPrefix)
        End Sub
#End Region

#Region "Properties"
        Private ReadOnly Property PreFixi() As String
            Get
                Return "toolci"
            End Get
        End Property
        Public Property ToolStockAdjust() As ToolStockAdjust            Get                Return m_matstockadjust            End Get            Set(ByVal Value As ToolStockAdjust)                m_matstockadjust = Value            End Set        End Property        Public Property LineNumber() As Integer            Get                Return m_lineNumber            End Get            Set(ByVal Value As Integer)                m_lineNumber = Value            End Set        End Property        Public Property Entity() As IHasName            Get                Return m_entity            End Get            Set(ByVal Value As IHasName)                m_entity = Value            End Set        End Property        Public Property EntityType() As Integer            Get                Return m_entitytype            End Get            Set(ByVal Value As Integer)                m_entitytype = Value            End Set        End Property        Public Property Unit() As Unit            Get                Return m_unit            End Get            Set(ByVal Value As Unit)                m_unit = Value            End Set        End Property        Public Property BalanceQty() As Decimal            Get                Return m_balanceqty            End Get            Set(ByVal Value As Decimal)                m_balanceqty = Value            End Set        End Property        Public Property AuditQty() As Decimal            Get                Return m_auditqty            End Get            Set(ByVal Value As Decimal)                m_auditqty = Value            End Set        End Property        Public Property DiffQty() As Decimal            Get                Return m_diffqty            End Get            Set(ByVal Value As Decimal)                m_diffqty = Value            End Set        End Property        Public Property Note() As String            Get                Return m_note            End Get            Set(ByVal Value As String)                m_note = Value            End Set        End Property
#End Region

#Region "Methods"
        Public Sub CopyToDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If

            Me.ToolStockAdjust.IsInitialized = False
            row("toolci_linenumber") = Me.LineNumber
            If Not Me.Entity Is Nothing Then
                row("code") = Me.Entity.Code
                row("name") = Me.Entity.Name
                row("toolci_entity") = Me.Entity.Id
            End If
            If Not Me.Unit Is Nothing Then
                row("toolci_unit") = Me.Unit.Id
                row("Unitcode") = Me.Unit.Code
                row("Unitname") = Me.Unit.Name
            End If
            row("toolci_entitytype") = Me.EntityType
            If Me.ToolStockAdjust.ValidateRow(row) Then
                row("toolci_balanceqty") = Me.BalanceQty
                row("toolci_auditqty") = Me.AuditQty
                row("toolci_diffqty") = Me.DiffQty
            Else
                row("toolci_balanceqty") = DBNull.Value
                row("toolci_auditqty") = DBNull.Value
                row("toolci_diffqty") = DBNull.Value
            End If
            row("toolci_note") = Me.Note
            Me.ToolStockAdjust.IsInitialized = True
        End Sub
        Public Sub CopyFromDataRow(ByVal row As TreeRow)
            If row Is Nothing Then
                Return
            End If
            Try
                ' line number
                If Not row.IsNull(("toolci_linenumber")) Then
                    Me.LineNumber = CInt(row("toolci_linenumber"))
                End If
                ' entity
                If Not row.IsNull(("toolci_entity")) Then
                    Me.Entity = New Tool(CInt(row("toolci_entity")))
                End If
                ' entity type
                If Not row.IsNull(("toolci_entitytype")) Then
                    Me.EntityType = (New Tool).EntityId
                End If
                ' entity unit
                If Not Me.Entity Is Nothing AndAlso CType(Me.Entity, Tool).Originated Then
                    Me.Unit = CType(Entity, Tool).Unit
                End If

                GetNumericFromRow(row)

                If Not row.IsNull(("toolci_note")) Then
                    Me.Note = CStr(row("toolci_note"))
                End If
            Catch ex As Exception
                MessageBox.Show(ex.Message & "::" & ex.StackTrace)
            End Try

        End Sub
        Public Sub GetNumericFromRow(ByVal row As TreeRow)
            ' Balance Qty
            If Not row.IsNull("toolci_balanceqty") Then
                Me.BalanceQty = CDec(row("toolci_balanceqty"))
            Else
                Me.BalanceQty = 0
            End If
            ' Audit Qty
            If Not row.IsNull("toolci_auditqty") Then
                Me.AuditQty = CDec(row("toolci_auditqty"))
            Else
                Me.AuditQty = 0
            End If
            ' Diff Qty
            If Not row.IsNull("toolci_diffqty") Then
                Me.DiffQty = CDec(row("toolci_diffqty"))
            Else
                Me.DiffQty = 0
            End If
        End Sub
#End Region

    End Class

End Namespace

