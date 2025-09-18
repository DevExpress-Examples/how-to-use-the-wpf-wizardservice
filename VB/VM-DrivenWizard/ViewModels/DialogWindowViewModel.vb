Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations

Namespace VM_DrivenWizard.ViewModels

    Public Class DialogWindowViewModel
        Inherits ViewModelBase

        Private ReadOnly Property WizardService As IWizardService
            Get
                Return GetService(Of IWizardService)()
            End Get
        End Property

        Public Sub New()
            Model = New Model()
        End Sub

        Private Property Model As Model

        <Command>
        Public Sub ViewLoaded()
            WizardService.Navigate("WelcomePage", Nothing, Model, Me)
        End Sub

        Public Function GetSelectedSong() As String
            Return Model?.Song
        End Function
    End Class
End Namespace
