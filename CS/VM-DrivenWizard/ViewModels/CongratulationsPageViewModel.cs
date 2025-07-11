using System.ComponentModel;
using DevExpress.Mvvm;

namespace VM_DrivenWizard.ViewModels {
    public class CongratulationsPageViewModel : WizardViewModelBase, ISupportWizardFinishCommand {
        IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();
        public CongratulationsPageViewModel() {
            ShowBack = true;
            ShowCancel = true;
            ShowFinish = true;
            AllowBack = true;
        }
        public bool CanFinish {
            get { return true; }
        }
        public void OnFinish(CancelEventArgs e) {
            MessageBoxService.ShowMessage("Thank you for completing this WPF feature tour!", "WPF Tour", MessageButton.OK, MessageIcon.Exclamation);
        }
        protected override bool GetCanCancel() {
            return false;
        }
    }
}
