using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.POCO;


namespace VM_DrivenWizard.ViewModel {
    public class MainWindowViewModel {
        public static MainWindowViewModel Create() {
            return ViewModelSource.Create(() => new MainWindowViewModel());
        }

        protected MainWindowViewModel() {
            Model = new Model();
        }

        public virtual string Text { get; protected set; }

        public void ShowDialog() {
            var wizardResult = this.GetRequiredService<IDialogService>().ShowDialog(MessageButton.OKCancel, "Wizard", this).ToString();
            var song = Model.Song;
            Text = "Wizard result: " + wizardResult + (string.IsNullOrEmpty(song) ? string.Empty : ", you choose " + Model.Song);
        }

        Model Model { get; set; }
        public void ViewLoaded() {
            this.GetRequiredService<IWizardService>().Navigate("WelcomePage", null,  Model, this);
        }
    }
}
