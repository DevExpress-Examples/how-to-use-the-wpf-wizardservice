using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;
using System.Threading.Tasks;


namespace VM_DrivenWizard.ViewModels {
    public class MainWindowViewModel : ViewModelBase {
        public virtual string Text { get; protected set; }
        IDialogService DialogService => this.GetService<IDialogService>();

        [Command]
        public void ShowDialog() {
            var dialogWindowViewModel = new DialogWindowViewModel();
            var wizardResult = DialogService.ShowDialog(MessageButton.OKCancel, "Wizard", dialogWindowViewModel).ToString();
            string selectedSong = dialogWindowViewModel.GetSelectedSong();
            Text = $"Wizard result: {wizardResult}{(string.IsNullOrEmpty(selectedSong) ? string.Empty : $", you choose {selectedSong}")}";
        }
    }
}
