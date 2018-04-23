using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace VM_DrivenWizard.ViewModels
{
    public class WelcomePageViewModel : WizardViewModelBase, ISupportWizardNextCommand
    {
        protected WelcomePageViewModel()
        {
            ShowCancel = true;
            ShowNext = true;
        }
        public static WelcomePageViewModel Create()
        {
            return ViewModelSource.Create(() => new WelcomePageViewModel());
        }
        public bool CanGoForward
        {
            get { return true; }
        }
        public void OnGoForward(CancelEventArgs e)
        {
            GoForward();
        }
        protected void GoForward()
        {
            this.GetRequiredService<IWizardService>().Navigate("PlayTunePage", Model, this);
        }
    }
}