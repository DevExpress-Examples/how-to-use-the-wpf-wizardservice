Imports System.ComponentModel
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO

Namespace VM_DrivenWizard.ViewModels

    Public Class CongratulationsPageViewModel
        Inherits WizardViewModelBase
        Implements ISupportWizardFinishCommand

        Protected Sub New()
            MyBase.ShowBack = True
            MyBase.ShowCancel = True
            MyBase.ShowFinish = True
            MyBase.AllowBack = True
        End Sub

        Public ReadOnly Property CanFinish As Boolean
            Get
                Return True
            End Get
        End Property

        Public Sub OnFinish(ByVal e As CancelEventArgs)
            Me.GetService(Of IMessageBoxService)().ShowMessage("Thank you for completing this WPF feature tour!", "WPF Tour", MessageButton.OK, MessageIcon.Exclamation)
        End Sub

        Protected Overrides Function GetCanCancel() As Boolean
            Return False
        End Function
    End Class
End Namespace
