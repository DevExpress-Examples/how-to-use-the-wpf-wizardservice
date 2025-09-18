Imports System.ComponentModel
Imports DevExpress.Mvvm

Namespace VM_DrivenWizard.ViewModels

    Public Class CongratulationsPageViewModel
        Inherits WizardViewModelBase
        Implements ISupportWizardFinishCommand

        Private ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return GetService(Of IMessageBoxService)()
            End Get
        End Property

        Public Sub New()
            ShowBack = True
            ShowCancel = True
            ShowFinish = True
            AllowBack = True
        End Sub

        Public ReadOnly Property CanFinish As Boolean Implements ISupportWizardFinishCommand.CanFinish
            Get
                Return True
            End Get
        End Property

        Public Sub OnFinish(ByVal e As CancelEventArgs) Implements ISupportWizardFinishCommand.OnFinish
            MessageBoxService.ShowMessage("Thank you for completing this WPF feature tour!", "WPF Tour", MessageButton.OK, MessageIcon.Exclamation)
        End Sub

        Protected Overrides Function GetCanCancel() As Boolean
            Return False
        End Function
    End Class
End Namespace
