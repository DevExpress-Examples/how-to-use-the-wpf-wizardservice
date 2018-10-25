using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using DevExpress.Mvvm.Native;
using DevExpress.Mvvm.POCO;

namespace VM_DrivenWizard.ViewModels
{
    public abstract class WizardViewModelBase : ISupportParameter, ISupportWizardCancelCommand
    {
        protected WizardViewModelBase() { }
        public bool CanCancel
        {
            get { return GetCanCancel(); }
        }
        public virtual Model Model { get; protected set; }
        object ISupportParameter.Parameter
        {
            get { return Model; }
            set { Model = (Model)value; }
        }
        public void OnCancel(CancelEventArgs e)
        {
            if (this.GetService<IMessageBoxService>().
                ShowMessage("Do you want to exit the WPF feature tour?", "WPF Tour", MessageButton.YesNo, MessageIcon.Question) == MessageResult.No)
                e.Cancel = true;
        }
        protected virtual bool GetCanCancel()
        {
            return true;
        }
        public virtual bool ShowNext { get; set; } 
        public virtual bool ShowBack { get; set; }
        public virtual bool ShowCancel { get; set; }
        public virtual bool ShowFinish { get; set; }
        public virtual bool AllowNext { get; set; }
        public virtual bool AllowBack { get; set; }
        public virtual bool AllowCancel { get; set; }
        public virtual bool AllowFinish { get; set; }
    }
}
