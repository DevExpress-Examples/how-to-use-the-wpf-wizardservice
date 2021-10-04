Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.POCO

Namespace VM_DrivenWizard.ViewModel

    Public Class MainWindowViewModel

        Public Shared Function Create() As MainWindowViewModel
            Return ViewModelSource.Create(Function() New MainWindowViewModel())
        End Function

        Protected Sub New()
            Model = New Model()
        End Sub

        Public Overridable Property Text As String

        Public Sub ShowDialog()
            Dim wizardResult = Me.GetRequiredService(Of IDialogService)().ShowDialog(MessageButton.OKCancel, "Wizard", Me).ToString()
            Dim song = Model.Song
            Text = "Wizard result: " & wizardResult & If(String.IsNullOrEmpty(song), String.Empty, ", you choose " & Model.Song)
        End Sub

        Private Property Model As Model

        Public Sub ViewLoaded()
            Me.GetRequiredService(Of IWizardService)().Navigate("WelcomePage", Nothing, Model, Me)
        End Sub
    End Class
End Namespace
