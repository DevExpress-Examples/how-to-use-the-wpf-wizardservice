using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;

namespace VM_DrivenWizard.ViewModels {
    public class CongratulationsPageViewModel : WizardViewModelBase, ISupportWizardFinishCommand {
        protected CongratulationsPageViewModel() {
        }

        public bool CanFinish {
            get { return true; }
        }

        public void OnFinish(CancelEventArgs e) {
            this.GetService<IMessageBoxService>().ShowMessage("Thank you for completing this WPF feature tour!", "WPF Tour", MessageButton.OK, MessageIcon.Exclamation);
        }
        protected override bool GetCanCancel() {
            return false;
        }
    }
}
