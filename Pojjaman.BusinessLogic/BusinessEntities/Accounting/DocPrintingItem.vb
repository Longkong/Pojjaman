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
  Public Interface INewPrintableEntity
    Function GetDocPrintingColumnsEntries() As DocPrintingItemCollection
    Function GetDocPrintingDataEntries() As DocPrintingItemCollection
  End Interface
  Public Interface IPrintableEntity
    Inherits IIdentifiable
    Function GetDefaultFormPath() As String
    Function GetDefaultForm() As String
    Function GetDocPrintingEntries() As DocPrintingItemCollection
  End Interface
  Public Interface IHasCustomNote
    Function GetCustomNoteCollection() As CustomNoteCollection
  End Interface
  Public Interface IHasPrintItem
    Function GetDocPrintingEntries() As DocPrintingItemCollection
  End Interface

  Public Interface IHasMainDoc
    ReadOnly Property MainDoc() As ISimpleEntity
  End Interface
  Public Enum SignatureType
    Non
    User
    Person
    CommentPerson
    ApprovePerson
    AuthorizedPerson
    RejectPerson
  End Enum
  Public Class DocPrintingItem
    Public Enum Frequency
      FirstPage
      EveryPage
      LastPage
    End Enum
#Region "Members"
    Private m_dataType As String
    Private m_value As Object
    Private m_mapping As String
    Private m_row As Integer
    Private m_table As String
    Private m_font As Font = Nothing
    Private m_level As Integer
    Private m_printingFrequency As Frequency = Frequency.EveryPage
    Private m_linestyle As Integer
    Private m_lines As Integer = 1
    Private m_signatureType As SignatureType
#End Region

#Region "Properties"
    Public Property SignatureType As SignatureType
      Get
        Return m_signatureType
      End Get
      Set(ByVal value As SignatureType)
        m_signatureType = value
      End Set
    End Property
    Public Property PrintingFrequency() As Frequency      Get        Return m_printingFrequency      End Get      Set(ByVal Value As Frequency)        m_printingFrequency = Value      End Set    End Property
    Public Property DataType() As String      Get        Return m_dataType      End Get      Set(ByVal Value As String)        m_dataType = Value      End Set    End Property    Public Property Value() As Object      Get        If Not m_value Is Nothing Then          If Not Me.DataType Is Nothing AndAlso Me.DataType.ToLower = "system.string" Then
            Dim myStringParserService As StringParserService = CType(ServiceManager.Services.GetService(GetType(StringParserService)), StringParserService)
            Return myStringParserService.Parse(m_value.ToString)
          End If
        End If        Return m_value      End Get      Set(ByVal Value As Object)        m_value = Value      End Set    End Property    Public Property Mapping() As String      Get        Return m_mapping      End Get      Set(ByVal Value As String)        m_mapping = Value      End Set    End Property    Public Property Lines() As Integer      Get        Return m_lines      End Get      Set(ByVal Value As Integer)        m_lines = Value      End Set    End Property    Public Property Row() As Integer      Get        Return m_row      End Get      Set(ByVal Value As Integer)        m_row = Value      End Set    End Property    Public Property Table() As String      Get        Return m_table      End Get      Set(ByVal Value As String)        m_table = Value      End Set    End Property    Public Property Font() As Font      Get        Return m_font      End Get      Set(ByVal Value As Font)        m_font = Value      End Set    End Property    Public Property Level() As Integer      Get        Return m_level      End Get      Set(ByVal Value As Integer)        m_level = Value      End Set    End Property    Public Property LineStyle() As Integer      Get
        Return m_linestyle
      End Get
      Set(ByVal Value As Integer)
        m_linestyle = Value
      End Set
    End Property#End Region

#Region "Clone"
    Public Function Clone() As DocPrintingItem
      Dim cloneItem As New DocPrintingItem
      cloneItem.m_dataType = Me.m_dataType
      cloneItem.m_value = Me.m_value
      cloneItem.m_mapping = Me.m_mapping
      cloneItem.m_row = Me.m_row
      cloneItem.m_table = Me.m_table
      cloneItem.m_font = Me.m_font
      cloneItem.m_level = Me.m_level
      cloneItem.m_printingFrequency = Me.m_printingFrequency
      cloneItem.m_linestyle = Me.m_linestyle
      cloneItem.m_lines = Me.m_lines
      Return cloneItem
    End Function
#End Region


  End Class

  <Serializable(), DefaultMember("Item")> _
  Public Class DocPrintingItemCollection
    Inherits CollectionBase

#Region "Members"
    Private m_level As Integer
    Private m_mappingHash As Hashtable
    Private m_relationilist As Generic.List(Of String)
    Private m_tableHash As Hashtable
    Private m_tableList As ArrayList
    Private m_columnHash As Hashtable
#End Region

#Region "Constructors"
    Public Sub New()
      m_mappingHash = New Hashtable
    End Sub
    Public Sub New(ByVal level As Integer)
      Me.New()
      m_level = level
    End Sub
#End Region

#Region "Properties"
    Public ReadOnly Property ColumnsTableHashOf(ByVal name As String) As ArrayList
      Get
        If m_tableHash Is Nothing Then
          RefreshTableList()
        End If
        Dim m_columnTableHash As New Hashtable
        Dim m_arrList As New ArrayList
        For Each dpi As DocPrintingItem In TableListOf(name)
          If Not m_columnTableHash.ContainsKey(dpi.Mapping.ToLower) Then
            m_arrList.Add(dpi)
            m_columnTableHash(dpi.Mapping.ToLower) = dpi
          End If
        Next
        Return m_arrList
      End Get
    End Property
    Public ReadOnly Property RowsTableHashOf(ByVal name As String) As ArrayList
      Get
        If m_tableHash Is Nothing Then
          RefreshTableList()
        End If
        Dim m_rowsTableHash As New Hashtable
        Dim m_arrList As New ArrayList
        For Each dpi As DocPrintingItem In TableListOf(name)
          If Not m_rowsTableHash.ContainsKey(dpi.Row) Then
            m_arrList.Add(dpi.Row)
            m_rowsTableHash(dpi.Row) = dpi.Row
          End If
        Next
        Return m_arrList
      End Get
    End Property
    Public ReadOnly Property ColumnHashOf(ByVal key As String) As DocPrintingItem
      Get
        If m_tableHash Is Nothing Then
          RefreshTableList()
        End If
        If m_columnHash Is Nothing Then
          Return Nothing
        End If
        Return CType(m_columnHash(key), DocPrintingItem)
      End Get
    End Property
    Public ReadOnly Property TableHash As Hashtable
      Get
        If m_tableHash Is Nothing Then
          RefreshTableList()
        End If

        Return m_tableHash
      End Get
    End Property
    Public ReadOnly Property TableList As ArrayList
      Get
        If m_tableHash Is Nothing Then
          RefreshTableList()
        End If

        Return m_tableList
      End Get
    End Property
    Public ReadOnly Property TableListOf(ByVal _name As String) As ArrayList
      Get
        If m_tableHash Is Nothing Then
          RefreshTableList()
        End If

        Dim arr As ArrayList
        arr = CType(m_tableHash(_name.Trim.ToLower), ArrayList)
        If arr Is Nothing Then
          Return New ArrayList
        End If

        Return arr
      End Get
    End Property
    Public Property RelationList As Generic.List(Of String)
      Get
        If m_relationilist Is Nothing Then
          m_relationilist = New Generic.List(Of String)
        End If
        Return m_relationilist
      End Get
      Set(ByVal value As Generic.List(Of String))
        If m_relationilist Is Nothing Then
          m_relationilist = New Generic.List(Of String)
        End If
        m_relationilist = value
      End Set
    End Property

    Default Public Property Item(ByVal index As Integer) As DocPrintingItem
      Get
        Return CType(MyBase.List.Item(index), DocPrintingItem)
      End Get
      Set(ByVal value As DocPrintingItem)
        MyBase.List.Item(index) = value
      End Set
    End Property
    Public Property Level() As Integer      Get        Return m_level      End Get      Set(ByVal Value As Integer)        m_level = Value      End Set    End Property
#End Region

#Region "Class Methods"
    Public Sub RefreshTableList()
      m_tableHash = New Hashtable
      m_columnHash = New Hashtable
      m_tableList = New ArrayList
      Dim key As String

      '--�������§�ӴѺ ��� table General �ҡ�͹--
      For Each dpi As DocPrintingItem In Me
        If dpi.Table Is Nothing OrElse dpi.Table.Trim.Length = 0 Then
          dpi.Table = "General"
        End If

        If dpi.Table.ToLower.Equals("general") Then
          key = String.Format("{0}>{1}>{2}", dpi.Table.ToLower, dpi.Mapping.ToLower, dpi.Row.ToString)
          If Not m_columnHash.ContainsKey(key) Then
            m_columnHash(key) = dpi
          End If

          If Not m_tableHash.ContainsKey(dpi.Table.Trim.ToLower) Then
            Dim newTableList As New ArrayList
            newTableList.Add(dpi)
            m_tableHash(dpi.Table.Trim.ToLower) = newTableList
            m_tableList.Add(dpi.Table.Trim.ToLower)
          Else
            CType(m_tableHash(dpi.Table.Trim.ToLower), ArrayList).Add(dpi)
          End If
        End If
      Next
      '--�������§�ӴѺ ��� table General �ҡ�͹--

      For Each dpi As DocPrintingItem In Me
        If dpi.Table Is Nothing OrElse dpi.Table.Trim.Length = 0 Then
          dpi.Table = "General"
        End If

        If Not dpi.Table.ToLower.Equals("general") Then
          key = String.Format("{0}>{1}>{2}", dpi.Table.ToLower, dpi.Mapping.ToLower, dpi.Row.ToString)
          If Not m_columnHash.ContainsKey(key) Then
            m_columnHash(key) = dpi
          End If

          If Not m_tableHash.ContainsKey(dpi.Table.Trim.ToLower) Then
            Dim newTableList As New ArrayList
            newTableList.Add(dpi)
            m_tableHash(dpi.Table.Trim.ToLower) = newTableList
            m_tableList.Add(dpi.Table.Trim.ToLower)
          Else
            CType(m_tableHash(dpi.Table.Trim.ToLower), ArrayList).Add(dpi)
          End If
        End If
      Next
    End Sub
    Private m_rowCount As Integer
    Public Function GetRowCount(ByVal table As String) As Integer
      Dim maxRow As Integer = 0
      For Each item As DocPrintingItem In Me.GetTableItems(table)
        If item.Row > maxRow Then
          maxRow = item.Row
        End If
      Next
      m_rowCount = maxRow
      Return m_rowCount
    End Function
    Public Function GetMappingItem(ByVal mapping As String) As DocPrintingItem
      Try
        Dim item As DocPrintingItem = CType(m_mappingHash("|" & mapping.ToLower & "|"), DocPrintingItem)
        Return item
      Catch ex As Exception
        For Each item As DocPrintingItem In Me
          If item.Mapping.ToLower = mapping.ToLower Then
            Return item
          End If
        Next
      End Try
    End Function
    Public Function GetMappingItem(ByVal table As String, ByVal mapping As String, ByVal row As Integer) As DocPrintingItem
      If table Is Nothing Then
        Return Nothing
      End If
      If mapping Is Nothing Then
        Return Nothing
      End If
      Try
        Dim ht As Hashtable = CType(m_mappingHash(table.ToLower & "|" & mapping.ToLower), Hashtable)
        If ht Is Nothing Then
          Return Nothing
        End If
        Return CType(ht(row), DocPrintingItem)
      Catch ex As Exception
        For Each item As DocPrintingItem In Me
          If item.Mapping.ToLower = mapping.ToLower AndAlso item.Table.ToLower = table.ToLower AndAlso item.Row = row Then
            Return item
          End If
        Next
      End Try
    End Function
    Public Function GetTableItems(ByVal table As String) As DocPrintingItemCollection
      If table Is Nothing Then
        Return Nothing
      End If
      Dim ret As New DocPrintingItemCollection
      Try
        Dim tbHash As Hashtable = CType(m_mappingHash("|" & table.ToLower & "|"), Hashtable)
        For Each item As DocPrintingItem In tbHash.Values
          ret.Add(item)
          If item.Value Is Nothing Then
            item.Value = "Nothing"
          End If
        Next
      Catch ex As Exception
        For Each item As DocPrintingItem In Me
          If Not item.Table Is Nothing AndAlso item.Table.ToLower = table.ToLower Then
            ret.Add(item)
            If item.Value Is Nothing Then
              item.Value = "Nothing"
            End If
          End If
        Next
      End Try
      Return ret
    End Function
#End Region

#Region "Collection Methods"
    Public Function Add(ByVal value As DocPrintingItem) As Integer
      If Not value.Mapping Is Nothing AndAlso value.Mapping.Length <> 0 Then
        If Not value.Table Is Nothing AndAlso value.Table.Length <> 0 Then
          '�� table/row
          If Not m_mappingHash.Contains(value.Table.ToLower & "|" & value.Mapping.ToLower) Then
            m_mappingHash(value.Table.ToLower & "|" & value.Mapping.ToLower) = New Hashtable
          End If
          Dim ht As Hashtable = CType(m_mappingHash(value.Table.ToLower & "|" & value.Mapping.ToLower), Hashtable)
          ht(value.Row) = value
          '�� table
          If Not m_mappingHash.Contains("|" & value.Table.ToLower & "|") Then
            m_mappingHash("|" & value.Table.ToLower & "|") = New Hashtable
          End If
          ht = CType(m_mappingHash("|" & value.Table.ToLower & "|"), Hashtable)
          ht(value.Row) = value
        Else
          '�� Mapping
          If Not m_mappingHash.Contains("|" & value.Mapping.ToLower & "|") Then
            m_mappingHash("|" & value.Mapping.ToLower & "|") = value
          End If
        End If
      End If
      Return MyBase.List.Add(value)
    End Function
    Public Sub AddRange(ByVal value As DocPrintingItemCollection)
      For i As Integer = 0 To value.Count - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Sub AddRange(ByVal value As DocPrintingItem())
      For i As Integer = 0 To value.Length - 1
        Me.Add(value(i))
      Next
    End Sub
    Public Function Contains(ByVal value As DocPrintingItem) As Boolean
      Return MyBase.List.Contains(value)
    End Function
    Public Sub CopyTo(ByVal array As DocPrintingItem(), ByVal index As Integer)
      MyBase.List.CopyTo(array, index)
    End Sub
    Public Shadows Function GetEnumerator() As DocPrintingItemEnumerator
      Return New DocPrintingItemEnumerator(Me)
    End Function
    Public Function IndexOf(ByVal value As DocPrintingItem) As Integer
      Return MyBase.List.IndexOf(value)
    End Function
    Public Sub Insert(ByVal index As Integer, ByVal value As DocPrintingItem)
      MyBase.List.Insert(index, value)
    End Sub
    Public Sub Remove(ByVal value As DocPrintingItem)
      MyBase.List.Remove(value)
    End Sub
    Public Sub Remove(ByVal index As Integer)
      MyBase.List.RemoveAt(index)
    End Sub
#End Region

    Public Class DocPrintingItemEnumerator
      Implements IEnumerator

#Region "Members"
      Private m_baseEnumerator As IEnumerator
      Private m_temp As IEnumerable
#End Region

#Region "Construtor"
      Public Sub New(ByVal mappings As DocPrintingItemCollection)
        Me.m_temp = mappings
        Me.m_baseEnumerator = Me.m_temp.GetEnumerator
      End Sub
#End Region

      Public ReadOnly Property Current() As Object Implements System.Collections.IEnumerator.Current
        Get
          Return CType(Me.m_baseEnumerator.Current, DocPrintingItem)
        End Get
      End Property

      Public Function MoveNext() As Boolean Implements System.Collections.IEnumerator.MoveNext
        Return Me.m_baseEnumerator.MoveNext
      End Function

      Public Sub Reset() Implements System.Collections.IEnumerator.Reset
        Me.m_baseEnumerator.Reset()
      End Sub
    End Class
  End Class

End Namespace

