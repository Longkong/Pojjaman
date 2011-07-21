﻿Imports Longkong.Pojjaman.DataAccessLayer
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
Namespace Longkong.Pojjaman.BusinessLogic
  Public Class ReSaveStock
    Inherits SimpleBusinessEntityBase

#Region "Member"
    Private ArrEntity As New ArrayList
    Private m_datestart As Date
    Private m_dateend As Date

#End Region
    Public Property DateStart As Date
      Get
        Return m_datestart
      End Get
      Set(ByVal value As Date)
        m_datestart = value
      End Set
    End Property
    Public Property DateEnd As Date
      Get
        Return m_dateend
      End Get
      Set(ByVal value As Date)
        m_dateend = value
      End Set
    End Property

    Public Overrides ReadOnly Property ClassName() As String
      Get
        Return "ResaveStock"
      End Get
    End Property
    Public Sub New()
      'Me.Load()
    End Sub
    Public ReadOnly Property ConnectionString() As String
      Get
        Return RecentCompanies.CurrentCompany.ConnectionString
      End Get
    End Property
    Public Sub Load()
      Dim ds As DataSet = SqlHelper.ExecuteDataset(Me.ConnectionString _
      , CommandType.StoredProcedure _
                , "GetForResaveGLDetailMiss" _
                , New SqlParameter("@DateStart", Me.DateStart) _
                , New SqlParameter("@DateEnd", Me.DateEnd) _
                )
      For Each dr As DataRow In ds.Tables(0).Rows
        ArrEntity.Add(dr)
      Next
    End Sub
    Public Sub save()
      Me.Load()
      Try
        Dim entityType As Integer
        Dim entityId As Integer
        Dim EditorId As Integer
        Dim count45 As Integer
        Dim count31 As Integer
        Dim count51 As Integer
        For Each item As DataRow In ArrEntity
          entityType = CInt(item("gl_refdoctype"))
          entityId = CInt(item("gl_refid"))
          EditorId = CInt(item("editor"))
          Select Case entityType
            Case 45
              Dim GR As New GoodsReceipt(entityId)
              GR.LastEditDate = Now
              GR.OnGlChanged()
              GR.Save(EditorId)
              count45 += 1
            Case 31
              Dim MW As New MatTransfer(entityId)
              MW.LastEditDate = Now
              MW.Save(EditorId)
              count31 += 1
            Case 51
              Dim MR As New MatReturn(entityId)
              MR.LastEditDate = Now
              MR.Save(EditorId)
              count51 += 1
            Case 83
              Dim GS As New GoodsSold(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 37
              Dim GS As New UpdateCheckPayment(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 59
              Dim GS As New AdvancePay(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 73
              Dim GS As New PaySelection(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 129
              Dim GS As New PettyCashClosed(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)
            Case 248
              Dim GS As New AdvanceMoneyClosed(entityId)
              GS.LastEditDate = Now
              GS.Save(EditorId)

          End Select
        Next
        MessageBox.Show("Save Succeed " & vbCrLf & _
                         count45.ToString & " " & count31.ToString & " " & count51.ToString)
      Catch ex As Exception
        MessageBox.Show(ex.Message)
      End Try
    End Sub
  End Class

End Namespace

