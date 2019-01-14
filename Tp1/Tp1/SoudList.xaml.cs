using Newtonsoft.Json;
using System.Collections.Generic;
using Tp1.Implements;
using Tp1.Models;
using Tp1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SoudList : ContentPage
    {
        public SoudList()
        {
            InitializeComponent();

            var json = DependencyService.Get<IAssetFile>().GetJson_FromAssetFile("sounds.json");
            List<Sound> sounds = JsonConvert.DeserializeObject<List<Sound>>(json);
            BindingContext = new SoundListViewModel();

            MyList.ItemTapped += OnItemTapped;
        }

        private void OnItemTapped(object sander, ItemTappedEventArgs e)
        {
            Sound sound = (Sound) e.Item;
            Navigation.PushAsync(new DetailSoundPage(sound));
        }
    }
}