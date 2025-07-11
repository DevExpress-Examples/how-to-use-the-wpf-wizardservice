Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations

Namespace VM_DrivenWizard.ViewModels

    Public Class MainWindowViewModel
        Inherits ViewModelBase

        Public Overridable Property Text As String

        Private ReadOnly Property DialogService As IDialogService
            Get
                Return GetService(Of IDialogService)()
            End Get
        End Property

        <Command>
        Public Sub ShowDialog()
            Dim dialogWindowViewModel = New DialogWindowViewModel()
            Dim wizardResult = DialogService.ShowDialog(MessageButton.OKCancel, "Wizard", dialogWindowViewModel).ToString()
            Dim selectedSong As String = dialogWindowViewModel.GetSelectedSong()
            Text = $"Wizard result: {wizardResult} {If(String.IsNullOrEmpty(selectedSong), String.Empty, $", you choose {selectedSong}")}"
        End Sub
    End Class
End Namespace
