Imports Longkong.Core.AddIns.Codons
Imports Longkong.Pojjaman.Services
Imports Longkong.Core.Services
Imports Longkong.Pojjaman.Gui
Imports Longkong.Pojjaman.Gui.Panels
Imports Longkong.Pojjaman.Gui.Pads
Imports Longkong.Pojjaman.Gui.Dialogs
Imports Longkong.Core.Properties
Imports Longkong.Pojjaman.BusinessLogic
Imports Longkong.Pojjaman.PanelDisplayBinding
Imports System.Data.SqlClient
Namespace Longkong.Pojjaman.Commands
    Public Class CancelEntity
        Inherits AbstractEntityAccessCommand

#Region "Constructors"
        Public Sub New()
        End Sub
#End Region

#Region "Methods"
        Public Overrides Sub Run()
            If TypeOf CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity Is ICancelable Then
                Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
                If msgServ.AskQuestion("${res:Global.Question.ConfirmCancel}") Then
                    Dim delErr As SaveErrorException = Cancel()
                    If IsNumeric(delErr.Message) Then
                        msgServ.ShowMessage("${res:Global.Canceled}")
                        WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.SwitchView(0)
                    End If
                End If
            End If
        End Sub
        Private Function Cancel() As SaveErrorException
            Dim msgServ As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
            Try
                Dim newEntity As ICancelable = CType(CType(WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ActiveViewContent, ISimpleEntityPanel).Entity, ICancelable)
        Dim myService As SecurityService = CType(ServiceManager.Services.GetService(GetType(SecurityService)), SecurityService)

        '*************************************��ͧ�ѹ LEVEL***************************************
        If TypeOf newEntity Is ISimpleEntity Then
          Dim theEntity As ISimpleEntity = CType(newEntity, ISimpleEntity)
          Dim ApprovalDocLevel As New ApprovalDocLevelCollection(myService.CurrentUser)
          Dim approveDocColl As New ApproveDocCollection(theEntity)
          'Dim currentApproveId As Integer = Me.ApprovePerson.Id
          Dim myMessage As IMessageService = CType(ServiceManager.Services.GetService(GetType(IMessageService)), IMessageService)
          If ApprovalDocLevel.GetItem(theEntity.EntityId).Level <= approveDocColl.MaxLevel AndAlso approveDocColl.MaxLevelPersonId <> 0 AndAlso myService.CurrentUser.Id <> approveDocColl.MaxLevelPersonId Then
            msgServ.ShowMessage("${res:Global.NotEnoughLevelToCancel}")
            Return New SaveErrorException("${res:Global.NotEnoughLevelToCancel}")
          End If
        End If
        '*************************************END ��ͧ�ѹ LEVEL***************************************

        '-------------------Check AccountPeriod -------------------
        If TypeOf newEntity Is ICheckPeriod AndAlso Not Longkong.Pojjaman.BusinessLogic.Configuration.CheckGigaSiteRight Then
          Dim oldDocDate As Date = CType(newEntity, ICheckPeriod).OldDocDate

          If TypeOf newEntity Is IGLAble Then
            '�� GL
            Dim glAble As IGLAble = CType(newEntity, IGLAble)
            Dim docDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(oldDocDate)
            If docDateLocking <> AccountPeriodLock.NoLock Then
              msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
              'Me.OnSaved(New SaveEventArgs(False))
              'SecurityService.UpdateAccessTable()
              'WorkbenchSingleton.Workbench.RedrawEditComponents()
              Return New SaveErrorException(" ")
            ElseIf Not glAble.JournalEntry Is Nothing Then
              Dim glDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(glAble.JournalEntry.DocDate)
              If glDateLocking <> AccountPeriodLock.NoLock Then
                msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
                'Me.OnSaved(New SaveEventArgs(False))
                'SecurityService.UpdateAccessTable()
                'WorkbenchSingleton.Workbench.RedrawEditComponents()
                Return New SaveErrorException(" ")
              End If
            End If
          ElseIf TypeOf newEntity Is JournalEntry Then
            'JV
            Dim jv As JournalEntry = CType(newEntity, JournalEntry)
            Dim docDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(jv.DocDate)
            If docDateLocking <> AccountPeriodLock.NoLock Then
              msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
              'Me.OnSaved(New SaveEventArgs(False))
              'SecurityService.UpdateAccessTable()
              'WorkbenchSingleton.Workbench.RedrawEditComponents()
              Return New SaveErrorException(" ")
            Else
              Dim glDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(jv.DocDate)
              If glDateLocking <> AccountPeriodLock.NoLock Then
                msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
                'Me.OnSaved(New SaveEventArgs(False))
                'SecurityService.UpdateAccessTable()
                'WorkbenchSingleton.Workbench.RedrawEditComponents()
                Return New SaveErrorException(" ")
              End If
            End If
          Else
            ''����� GL
            'Dim ty As Type = CType(newEntity, Object).GetType
            'Dim pi As PropertyInfo = ty.GetProperty("DocDate")
            'Dim docDate As Date = Date.MinValue
            'If Not pi Is Nothing Then
            '  Dim d As Object = pi.GetValue(newEntity, Nothing)
            '  If IsDate(d) Then
            '    docDate = CDate(d)
            '  End If
            'End If

            'HACK by Pla <--- Good!
            If TypeOf newEntity Is Banking Then
              oldDocDate = CType(newEntity, Banking).Docdate
            End If

            If Not oldDocDate.Equals(Date.MinValue) Then
              Dim docDateLocking As AccountPeriodLock = AccountPeriod.GetLockingForDate(oldDocDate)
              If docDateLocking = AccountPeriodLock.AllLock Then
                msgServ.ShowMessage("${res:Global.Error.AccountPeriodIsLocked}")
                'Me.OnSaved(New SaveEventArgs(False))
                'SecurityService.UpdateAccessTable()
                'WorkbenchSingleton.Workbench.RedrawEditComponents()
                Return New SaveErrorException(" ")
              End If
            End If

          End If
        End If
        '-------------------End Check AccountPeriod-------------------

        Dim saveError As SaveErrorException = newEntity.CancelEntity(myService.CurrentUser.Id, Now)
        If Not IsNumeric(saveError.Message) Then
          If Not saveError.Params Is Nothing AndAlso saveError.Params.Length > 0 Then
            msgServ.ShowMessageFormatted(saveError.Message, saveError.Params)
          Else
            msgServ.ShowMessage(saveError.Message)
          End If
        End If
        Return saveError
      Catch ex As SqlException
        Return New SaveErrorException(ex.ToString)
      Catch ex As Exception
        Return New SaveErrorException(ex.ToString)
      Finally

      End Try
        End Function
        Public Overrides Property IsEnabled() As Boolean
            Get
                If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow Is Nothing Then
                    Return MyBase.IsEnabled
                End If
                If WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is Nothing Then
                    Return MyBase.IsEnabled
                End If
                If Not TypeOf WorkbenchSingleton.Workbench.ActiveWorkbenchWindow.ViewContent Is ISimpleListPanel Then
                    Return MyBase.IsEnabled
                End If
                Return MyBase.IsEnabledWithChecking
            End Get
            Set(ByVal Value As Boolean)
                MyBase.IsEnabled = Value
            End Set
        End Property
        Public Overrides ReadOnly Property ValidLevel() As Integer
            Get
                Return 1
            End Get
        End Property
#End Region


    End Class
End Namespace

