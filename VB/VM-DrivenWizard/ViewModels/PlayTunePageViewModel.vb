Imports System
Imports System.ComponentModel
Imports System.Text
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations

Namespace VM_DrivenWizard.ViewModels

    Public Class PlayTunePageViewModel
        Inherits WizardViewModelBase
        Implements ISupportWizardNextCommand, ISupportWizardFinishCommand

        Public Sub New()
            ShowBack = True
            ShowCancel = True
            ShowNext = True
            AllowBack = True
            AllowCancel = True
        End Sub

        Public ReadOnly Property Header As String
            Get
                Return "Step 2 - Play a tune"
            End Get
        End Property

        Public ReadOnly Property Description As String
            Get
                Return "To make this demo more entertaining, we would like to play a tune for you. Simply choose your favorite track."
            End Get
        End Property

        Private ReadOnly Property MessageBoxService As IMessageBoxService
            Get
                Return GetService(Of IMessageBoxService)()
            End Get
        End Property

        Private ReadOnly Property WizardService As IWizardService
            Get
                Return GetService(Of IWizardService)()
            End Get
        End Property

        <Command>
        Public Sub Play()
            Dim song = Model?.Song
            Dim sb = New StringBuilder()
            sb.AppendLine("Sorry, but we don't have that song in our library...")
            If Not String.IsNullOrWhiteSpace(song) Then
                sb.AppendLine($"But we agree with you that ""{song}"" is an excellent choice.")
            Else
                sb.AppendLine("But we agree with you that your choice is excellent.")
            End If

            MessageBoxService.ShowMessage(sb.ToString(), "Wizard", MessageButton.OK, MessageIcon.Information)
        End Sub

        Public Function CanPlay() As Boolean
            Return Not String.IsNullOrEmpty(Song)
        End Function

        Protected Overrides Property Model As Model
            Get
                Return MyBase.Model
            End Get

            Set(ByVal value As Model)
                MyBase.Model = value
                Song = value?.Song
            End Set
        End Property

        Public Property Song As String
            Get
                Return GetProperty(Function() Me.Song)
            End Get

            Set(ByVal value As String)
                SetProperty(Function() Song, value, New Action(AddressOf OnSongChanged))
            End Set
        End Property

        Public ReadOnly Property CanGoForward As Boolean Implements ISupportWizardNextCommand.CanGoForward
            Get
                Return CanPlay()
            End Get
        End Property

        Public ReadOnly Property CanFinish As Boolean Implements ISupportWizardFinishCommand.CanFinish
            Get
                Return True
            End Get
        End Property

        Private Sub OnSongChanged()
            Model.Song = Song
        End Sub

        Public Sub OnGoForward(ByVal e As CancelEventArgs) Implements ISupportWizardNextCommand.OnGoForward
            WizardService.Navigate("CongratulationsPage", Model, Me)
        End Sub

        Public Sub OnFinish(ByVal e As CancelEventArgs) Implements ISupportWizardFinishCommand.OnFinish
            MessageBoxService.ShowMessage("You have finished the tour.", "WPF Tour", MessageButton.OK, MessageIcon.Exclamation)
        End Sub
    End Class
End Namespace
