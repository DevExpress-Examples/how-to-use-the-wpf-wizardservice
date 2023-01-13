Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO

Namespace VM_DrivenWizard.ViewModels

    Public Class WelcomePageViewModel
        Inherits WizardViewModelBase
        Implements ISupportWizardNextCommand

        Protected Sub New()
            ShowCancel = True
            ShowNext = True
        End Sub

        Public Shared Function Create() As WelcomePageViewModel
            Return ViewModelSource.Create(Function() New WelcomePageViewModel())
        End Function

        Public ReadOnly Property CanGoForward As Boolean Implements ISupportWizardNextCommand.CanGoForward
            Get
                Return True
            End Get
        End Property

        Public Sub OnGoForward(ByVal e As CancelEventArgs) Implements ISupportWizardNextCommand.OnGoForward
            GoForward()
        End Sub

        Protected Sub GoForward()
            GetRequiredService(Of IWizardService).Navigate("PlayTunePage", Model, Me)
        End Sub
    End Class
End Namespace
