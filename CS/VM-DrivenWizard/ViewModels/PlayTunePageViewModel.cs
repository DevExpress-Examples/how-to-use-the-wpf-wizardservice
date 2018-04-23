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
    public class PlayTunePageViewModel : WizardViewModelBase, ISupportWizardNextCommand, ISupportWizardFinishCommand
    {
        public static PlayTunePageViewModel Create()
        {
            return ViewModelSource.Create(() => new PlayTunePageViewModel());
        }
        protected PlayTunePageViewModel()
        {
            ShowBack = true;
            ShowCancel = true;
            ShowNext = true;
            AllowBack = true;
            AllowCancel = true;
        }
        public string Header { get { return "Step 2 - Play a tune"; } }
        public string Description { get { return "To make this demo more entertaining, we would like to play a tune for you. Simple choose your favorite track."; } }

        public void Play()
        {
            string text = @"Sorry, but we don't have that song in our library..." + Environment.NewLine;
            text += @"But we are agree with you that ""{0}"" is an exellent choice.";
            text = string.Format(text, Model.Song);
            this.GetService<IMessageBoxService>().ShowMessage(text, "Wizard", MessageButton.OK, MessageIcon.Information);
        }
        public bool CanPlay()
        {
            return Model != null && !string.IsNullOrEmpty(Model.Song);
        }
        public virtual string Song { get; set; }

        public bool CanGoForward
        {
            get { return CanPlay(); }
        }

        public bool CanFinish
        {
            get
            {
                return true;
            }
        }

        protected virtual void OnSongChanged()
        {
            Model.Song = Song;
        }

        public void OnGoForward(CancelEventArgs e)
        {
            this.GetRequiredService<IWizardService>().Navigate("CongratulationsPage", Model, this);
        }
        public void OnFinish(CancelEventArgs e)
        {
            this.GetService<IMessageBoxService>().ShowMessage("You have finished the tour.", "WPF Tour", MessageButton.OK, MessageIcon.Exclamation);
        }
    }
}
