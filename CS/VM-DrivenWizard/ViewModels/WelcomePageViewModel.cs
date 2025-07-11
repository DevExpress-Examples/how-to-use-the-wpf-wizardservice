using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;

namespace VM_DrivenWizard.ViewModels {
    public class WelcomePageViewModel : WizardViewModelBase, ISupportWizardNextCommand {
        IWizardService WizardService => this.GetService<IWizardService>();
        public WelcomePageViewModel() {
            ShowCancel = true;
            ShowNext = true;
        }
        public bool CanGoForward {
            get { return true; }
        }
        public void OnGoForward(CancelEventArgs e) {
            GoForward();
        }
        protected void GoForward() {
            WizardService.Navigate("PlayTunePage", Model, this);
        }
    }
}