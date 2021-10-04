Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO

Namespace VM_DrivenWizard.ViewModels

    Public Class WelcomePageViewModel
        Inherits WizardViewModelBase
        Implements ISupportWizardNextCommand

        Protected Sub New()
            MyBase.ShowCancel = True
            MyBase.ShowNext = True
        End Sub

        Public Shared Function Create() As WelcomePageViewModel
            Return ViewModelSource.Create(Function() New WelcomePageViewModel())
        End Function

        Public ReadOnly Property CanGoForward As Boolean
            Get
                Return True
            End Get
        End Property

        Public Sub OnGoForward(ByVal e As CancelEventArgs)
            GoForward()
        End Sub

        Protected Sub GoForward()
            Me.GetRequiredService(Of IWizardService)().Navigate("PlayTunePage", MyBase.Model, Me)
        End Sub
    End Class
End Namespace
