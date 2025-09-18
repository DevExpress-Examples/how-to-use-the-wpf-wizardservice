Imports System.ComponentModel
Imports DevExpress.Mvvm

Namespace VM_DrivenWizard.ViewModels

    Public MustInherit Class WizardViewModelBase
        Inherits ViewModelBase
        Implements ISupportParameter, ISupportWizardCancelCommand

        Private ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return GetService(Of IMessageBoxService)()
            End Get
        End Property

        Public ReadOnly Property CanCancel As Boolean Implements ISupportWizardCancelCommand.CanCancel
            Get
                Return GetCanCancel()
            End Get
        End Property

        Protected Overridable Property Model As Model

        Private Property ISupportParameter_Parameter As Object Implements ISupportParameter.Parameter
            Get
                Return Model
            End Get

            Set(ByVal value As Object)
                Model = CType(value, Model)
            End Set
        End Property

        Public Sub OnCancel(ByVal e As CancelEventArgs) Implements ISupportWizardCancelCommand.OnCancel
            If MessageBoxService.ShowMessage("Do you want to exit the WPF feature tour?", "WPF Tour", MessageButton.YesNo, MessageIcon.Question) = MessageResult.No Then e.Cancel = True
        End Sub

        Protected Overridable Function GetCanCancel() As Boolean
            Return True
        End Function

        Public Overridable Property ShowNext As Boolean
            Get
                Return GetProperty(Function() Me.ShowNext)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() ShowNext, value)
            End Set
        End Property

        Public Overridable Property ShowBack As Boolean
            Get
                Return GetProperty(Function() Me.ShowBack)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() ShowBack, value)
            End Set
        End Property

        Public Overridable Property ShowCancel As Boolean
            Get
                Return GetProperty(Function() Me.ShowCancel)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() ShowCancel, value)
            End Set
        End Property

        Public Overridable Property ShowFinish As Boolean
            Get
                Return GetProperty(Function() Me.ShowFinish)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() ShowFinish, value)
            End Set
        End Property

        Public Overridable Property AllowNext As Boolean
            Get
                Return GetProperty(Function() Me.AllowNext)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() AllowNext, value)
            End Set
        End Property

        Public Overridable Property AllowBack As Boolean
            Get
                Return GetProperty(Function() Me.AllowBack)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() AllowBack, value)
            End Set
        End Property

        Public Overridable Property AllowCancel As Boolean
            Get
                Return GetProperty(Function() Me.AllowCancel)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() AllowCancel, value)
            End Set
        End Property

        Public Overridable Property AllowFinish As Boolean
            Get
                Return GetProperty(Function() Me.AllowFinish)
            End Get

            Set(ByVal value As Boolean)
                SetProperty(Function() AllowFinish, value)
            End Set
        End Property
    End Class
End Namespace
