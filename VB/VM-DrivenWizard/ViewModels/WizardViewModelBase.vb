Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Native
Imports DevExpress.Mvvm.POCO

Namespace VM_DrivenWizard.ViewModels

    Public MustInherit Class WizardViewModelBase
        Inherits ISupportParameter
        Implements ISupportWizardCancelCommand

        Protected Sub New()
        End Sub

        Public ReadOnly Property CanCancel As Boolean
            Get
                Return GetCanCancel()
            End Get
        End Property

        Public Overridable Property Model As Model

        Private Property Parameter As Object
            Get
                Return Model
            End Get

            Set(ByVal value As Object)
                Model = CType(value, Model)
            End Set
        End Property

        Public Sub OnCancel(ByVal e As CancelEventArgs)
            If Me.GetService(Of IMessageBoxService)().ShowMessage("Do you want to exit the WPF feature tour?", "WPF Tour", MessageButton.YesNo, MessageIcon.Question) Is MessageResult.No Then e.Cancel = True
        End Sub

        Protected Overridable Function GetCanCancel() As Boolean
            Return True
        End Function

        Public Overridable Property ShowNext As Boolean

        Public Overridable Property ShowBack As Boolean

        Public Overridable Property ShowCancel As Boolean

        Public Overridable Property ShowFinish As Boolean

        Public Overridable Property AllowNext As Boolean

        Public Overridable Property AllowBack As Boolean

        Public Overridable Property AllowCancel As Boolean

        Public Overridable Property AllowFinish As Boolean
    End Class
End Namespace
