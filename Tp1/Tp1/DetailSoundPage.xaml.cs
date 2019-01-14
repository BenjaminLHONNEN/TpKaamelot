using Tp1.Models;
using Tp1.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Tp1
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class DetailSoundPage : ContentPage
	{
		public DetailSoundPage (Sound sound)
		{
			InitializeComponent ();
		    BindingContext = new DetailSoundPageViewModel(sound);
            Title = "Son : " + sound.Title;
        }
	}
}