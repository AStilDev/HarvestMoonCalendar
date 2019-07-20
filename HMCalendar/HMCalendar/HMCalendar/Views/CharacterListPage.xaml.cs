using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMCalendar.Models;
using HMCalendar.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMCalendar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class CharacterListPage : ContentPage
	{
	    private CharacterListViewModel _viewModel;

		public CharacterListPage ()
		{
			InitializeComponent ();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            BindingContext = _viewModel = new CharacterListViewModel(); // reset
        }

        public void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
	    {
	        var chara = args.SelectedItem as Character;
	        if (chara == null)
	            return;

            Navigation.PushAsync(new CharacterPage(new CharacterViewModel(chara)));
	    }

        public async void OnOptionsClicked(object sender, EventArgs args)
        {
            // open game change selection
            await Navigation.PushModalAsync(new GameSelectionPage());
        }
    }
}