Imports System.ComponentModel
Imports DevExpress.Mvvm

Namespace VM_DrivenWizard.ViewModels

    Public Class WelcomePageViewModel
        Inherits WizardViewModelBase
        Implements ISupportWizardNextCommand

        Private ReadOnly Property WizardService As IWizardService
            Get
                Return GetService(Of IWizardService)()
            End Get
        End Property

        Public Sub New()
            ShowCancel = True
            ShowNext = True
        End Sub

        Public ReadOnly Property CanGoForward As Boolean Implements ISupportWizardNextCommand.CanGoForward
            Get
                Return True
            End Get
        End Property

        Public Sub OnGoForward(ByVal e As CancelEventArgs) Implements ISupportWizardNextCommand.OnGoForward
            GoForward()
        End Sub

        Protected Sub GoForward()
            WizardService.Navigate("PlayTunePage", Model, Me)
        End Sub
    End Class
End Namespace
