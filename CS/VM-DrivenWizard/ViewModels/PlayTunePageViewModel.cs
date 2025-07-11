using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;

namespace VM_DrivenWizard.ViewModels {
    public class PlayTunePageViewModel : WizardViewModelBase, ISupportWizardNextCommand, ISupportWizardFinishCommand {
        public PlayTunePageViewModel() {
            ShowBack = true;
            ShowCancel = true;
            ShowNext = true;
            AllowBack = true;
            AllowCancel = true;
        }
        public string Header => "Step 2 - Play a tune";
        public string Description => "To make this demo more entertaining, we would like to play a tune for you. Simply choose your favorite track.";
        IMessageBoxService MessageBoxService => this.GetService<IMessageBoxService>();
        IWizardService WizardService => this.GetService<IWizardService>();

        [Command]
        public void Play() {
            var song = Model?.Song;
            var sb = new StringBuilder();
            sb.AppendLine("Sorry, but we don't have that song in our library...");
            if (!string.IsNullOrWhiteSpace(song)) {
                sb.AppendLine($@"But we agree with you that ""{song}"" is an excellent choice.");
            }
            else {
                sb.AppendLine("But we agree with you that your choice is excellent.");
            }
            MessageBoxService.ShowMessage(sb.ToString(), "Wizard", MessageButton.OK, MessageIcon.Information);
        }
        public bool CanPlay() {
            return !string.IsNullOrEmpty(Song);
        }

        protected override Model Model { 
            get { return base.Model; } 
            set {
                base.Model = value;
                Song = value?.Song;
            }
        }

        public string Song {
            get { return GetProperty(() => Song); }
            set { SetProperty(() => Song, value, OnSongChanged); }
        }

        public bool CanGoForward {
            get { return CanPlay(); }
        }

        public bool CanFinish {
            get { return true; }
        }

        void OnSongChanged() {
            Model.Song = Song;
        }

        public void OnGoForward(CancelEventArgs e) {
            WizardService.Navigate("CongratulationsPage", Model, this);
        }
        public void OnFinish(CancelEventArgs e) {
            MessageBoxService.ShowMessage("You have finished the tour.", "WPF Tour", MessageButton.OK, MessageIcon.Exclamation);
        }
    }
}
