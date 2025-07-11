using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;

namespace VM_DrivenWizard.ViewModels {
    public class DialogWindowViewModel : ViewModelBase {
        IWizardService WizardService => this.GetService<IWizardService>();
        public DialogWindowViewModel() {
            Model = new Model();
        }
        Model Model { get; set; }

        [Command]
        public void ViewLoaded() {
            WizardService.Navigate("WelcomePage", null, Model, this);
        }
        public string GetSelectedSong() {
            return Model?.Song;
        }
    }
}
