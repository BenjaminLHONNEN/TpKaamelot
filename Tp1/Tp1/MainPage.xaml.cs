using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Tp1.Implements;
using Tp1.Models;
using Xamarin.Forms;

namespace Tp1
{
    public partial class MainPage : ContentPage
    {
        public List<Sound> Sounds;

        public MainPage()
        {
            BindingContext = this;
            InitializeComponent();


            var json = DependencyService.Get<IAssetFile>().GetJson_FromAssetFile("sounds.json");
            Sounds = JsonConvert.DeserializeObject<List<Sound>>(json);
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            OnPropertyChanged(nameof(Sounds));
        }
    }
}