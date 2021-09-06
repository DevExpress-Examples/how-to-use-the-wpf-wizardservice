Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO

Namespace VM_DrivenWizard.ViewModels
	Public Class PlayTunePageViewModel
		Inherits WizardViewModelBase
		Implements ISupportWizardNextCommand, ISupportWizardFinishCommand

		Public Shared Function Create() As PlayTunePageViewModel
			Return ViewModelSource.Create(Function() New PlayTunePageViewModel())
		End Function
		Protected Sub New()
			ShowBack = True
			ShowCancel = True
			ShowNext = True
			AllowBack = True
			AllowCancel = True
		End Sub
		Public ReadOnly Property Header() As String
			Get
				Return "Step 2 - Play a tune"
			End Get
		End Property
		Public ReadOnly Property Description() As String
			Get
				Return "To make this demo more entertaining, we would like to play a tune for you. Simple choose your favorite track."
			End Get
		End Property

		Public Sub Play()
			Dim text As String = "Sorry, but we don't have that song in our library..." & Environment.NewLine
			text &= "But we are agree with you that ""{0}"" is an exellent choice."
			text = String.Format(text, Model.Song)
			Me.GetService(Of IMessageBoxService)().ShowMessage(text, "Wizard", MessageButton.OK, MessageIcon.Information)
		End Sub
		Public Function CanPlay() As Boolean
			Return Model IsNot Nothing AndAlso Not String.IsNullOrEmpty(Model.Song)
		End Function
		Public Overridable Property Song() As String

		Public ReadOnly Property CanGoForward() As Boolean
			Get
				Return CanPlay()
			End Get
		End Property

		Public ReadOnly Property CanFinish() As Boolean
			Get
				Return True
			End Get
		End Property

		Protected Overridable Sub OnSongChanged()
			Model.Song = Song
		End Sub

		Public Sub OnGoForward(ByVal e As CancelEventArgs)
			Me.GetRequiredService(Of IWizardService)().Navigate("CongratulationsPage", Model, Me)
		End Sub
		Public Sub OnFinish(ByVal e As CancelEventArgs)
			Me.GetService(Of IMessageBoxService)().ShowMessage("You have finished the tour.", "WPF Tour", MessageButton.OK, MessageIcon.Exclamation)
		End Sub
	End Class
End Namespace
