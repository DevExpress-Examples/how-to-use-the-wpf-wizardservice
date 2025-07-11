using System.ComponentModel;
using DevExpress.Mvvm;

namespace VM_DrivenWizard.ViewModels {
    public abstract class WizardViewModelBase : ViewModelBase, ISupportParameter, ISupportWizardCancelCommand {
        IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();
        public bool CanCancel {
            get { return GetCanCancel(); }
        }
        protected virtual Model Model { get; set; }
        object ISupportParameter.Parameter {
            get { return Model; }
            set { Model = (Model)value; }
        }
        public void OnCancel(CancelEventArgs e) {
            if (MessageBoxService.ShowMessage("Do you want to exit the WPF feature tour?", "WPF Tour", MessageButton.YesNo, MessageIcon.Question) == MessageResult.No)
                e.Cancel = true;
        }
        protected virtual bool GetCanCancel() {
            return true;
        }
        public virtual bool ShowNext {
            get { return GetProperty(() => ShowNext); }
            set { SetProperty(() => ShowNext, value); }
        }
        public virtual bool ShowBack {
            get { return GetProperty(() => ShowBack); }
            set { SetProperty(() => ShowBack, value); }
        }
        public virtual bool ShowCancel {
            get { return GetProperty(() => ShowCancel); }
            set { SetProperty(() => ShowCancel, value); }
        }
        public virtual bool ShowFinish {
            get { return GetProperty(() => ShowFinish); }
            set { SetProperty(() => ShowFinish, value); }
        }
        public virtual bool AllowNext {
            get { return GetProperty(() => AllowNext); }
            set { SetProperty(() => AllowNext, value); }
        }
        public virtual bool AllowBack {
            get { return GetProperty(() => AllowBack); }
            set { SetProperty(() => AllowBack, value); }
        }
        public virtual bool AllowCancel {
            get { return GetProperty(() => AllowCancel); }
            set { SetProperty(() => AllowCancel, value); }
        }
        public virtual bool AllowFinish {
            get { return GetProperty(() => AllowFinish); }
            set { SetProperty(() => AllowFinish, value); }
        }
    }
}
