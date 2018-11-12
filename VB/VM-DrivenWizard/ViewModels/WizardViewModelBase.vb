Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports DevExpress.Mvvm.Native
Imports DevExpress.Mvvm.POCO

Namespace VM_DrivenWizard.ViewModels
    Public MustInherit Class WizardViewModelBase
        Implements ISupportParameter, ISupportWizardCancelCommand

        Protected Sub New()
        End Sub
        Public ReadOnly Property CanCancel() As Boolean Implements ISupportWizardCancelCommand.CanCancel
            Get
                Return GetCanCancel()
            End Get
        End Property
        Private privateModel As Model
        Public Overridable Property Model() As Model
            Get
                Return privateModel
            End Get
            Protected Set(ByVal value As Model)
                privateModel = value
            End Set
        End Property
        Private Property ISupportParameter_Parameter() As Object Implements ISupportParameter.Parameter
            Get
                Return Model
            End Get
            Set(ByVal value As Object)
                Model = DirectCast(value, Model)
            End Set
        End Property
        Public Sub OnCancel(ByVal e As CancelEventArgs) Implements ISupportWizardCancelCommand.OnCancel
            If Me.GetService(Of IMessageBoxService)().ShowMessage("Do you want to exit the WPF feature tour?", "WPF Tour", MessageButton.YesNo, MessageIcon.Question) = MessageResult.No Then
                e.Cancel = True
            End If
        End Sub
        Protected Overridable Function GetCanCancel() As Boolean
            Return True
        End Function
        Public Overridable Property ShowNext() As Boolean
        Public Overridable Property ShowBack() As Boolean
        Public Overridable Property ShowCancel() As Boolean
        Public Overridable Property ShowFinish() As Boolean
        Public Overridable Property AllowNext() As Boolean
        Public Overridable Property AllowBack() As Boolean
        Public Overridable Property AllowCancel() As Boolean
        Public Overridable Property AllowFinish() As Boolean
    End Class
End Namespace