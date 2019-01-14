using System.Threading;
using System.Threading.Tasks;
using Tp1.Implements;
using Tp1.Models;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Tp1.ViewModels
{
    public class DetailSoundPageViewModel : BaseViewModel
    {
        private Command _shareSampleCommand;

        public Command ShareSample
        {
            get { return _shareSampleCommand; }
            set { _shareSampleCommand = value; }
        }

        public Command SayTitleCommand;

        private async Task SayTitle()
        {
            var languages = await TextToSpeech.GetLocalesAsync();

            var locale = languages.GetEnumerator().Current;

            var settings = new SpeechOptions()
            {
                Volume = 1,
                Pitch = 1,
                Locale = locale
            };

            await TextToSpeech.SpeakAsync(_sound.Title, settings);
        }

        private bool canShare()
        {
            return _sound != null;
        }

        private async Task ShareSound()
        {
            IsBusy = true;

            await Share.RequestAsync(new ShareTextRequest
            {
                Title = _sound.Title,
                Subject = _sound.Character + " - " + _sound.Title,
                Text = "Texte ?",
                Uri = "www.google.fr"
            });

            IsBusy = false;
        }

        private Sound _sound;

        public Sound Sound
        {
            get { return _sound; }
            set { _sound = value; }
        }

        public Command PlaySampleCommand { get; set; }

        private async Task PlaySong()
        {
            IsBusy = true;
            DependencyService.Get<IMediaPlayer>().Play(_sound.File);
            await Task.Factory.StartNew( () => { Thread.Sleep(5000); });
            IsBusy = false;
        }

        private bool canPlaySong()
        {
            return !IsBusy;
        }


        public DetailSoundPageViewModel(Sound current)
        {
            _sound = current;
            PlaySampleCommand = new Command(async () => { await PlaySong();}, canPlaySong);
            _shareSampleCommand = new Command(async () => { await ShareSound();}, canShare);
            SayTitleCommand  = new Command(async () => { await SayTitle();});
            IsBusy = false;
        }
    }
}
