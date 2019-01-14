using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Tp1.Models;
using Tp1.Service;
using Xamarin.Forms;

namespace Tp1.ViewModels
{
    public class SoundListViewModel : BaseViewModel
    {
        private List<Sound> _sounds;
        private List<Sound> _defaultSounds;

        private async Task SynchronizedDB()
        {
            try
            {
                using (var context = new KaamDBContext())
                {
                    //context.RemoveRange(context.SoundTable);
                    _defaultSounds = await KaamlotWebService.GetSoundList();
                    // var dataList = await KaamlotWebService.GetSoundList();
                    /*
                    foreach (var data in dataList)
                    {
                        if (!context.SoundTable.Any(w => w.Title == data.Title))
                        {
                            context.SoundTable.Add(data);
                        }
                    }*/
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public SoundListViewModel()
        {
            Title = "List de Meme";
            GetSoundList = new Command(async () => { await getData(); });
            GetSoundList.Execute(null);
        }

        public Command GetSoundList { get; set; }

        private bool canGetData()
        {
            return !IsBusy;
        }

        private async Task getData()
        {
            try
            {
                IsBusy = true;
                _defaultSounds = await KaamlotWebService.GetSoundList();
                if (_defaultSounds != null)
                {
                    await SynchronizedDB();
                }
                else
                {
                    using (var context = new KaamDBContext())
                    {
                        _defaultSounds = context.SoundTable.ToList();
                    }
                }

                SearchText = "";
                IsBusy = false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private string _searchText;

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
                FilterList(value);
            }
        }

        private void FilterList(string research)
        {
            if (string.IsNullOrEmpty(_searchText))
            {
                Sounds = _defaultSounds;
            }
            else
            {
                Sounds = _defaultSounds.Where(w =>
                    w.Title.ToLower().Contains(research.ToLower()) ||
                    w.Character.ToLower().Contains(research.ToLower())).ToList();
            }
        }


        public List<Sound> Sounds
        {
            get { return _sounds; }
            set
            {
                OnPropertyChanged();
                _sounds = value;
            }
        }

        private Sound _seletedSound;

        public Sound SelectedSound
        {
            get { return _seletedSound; }
            set
            {
                _seletedSound = value;
                OnPropertyChanged();
            }
        }
    }
}