using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HMCalendar.Models;
using HMCalendar.ViewModels;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace HMCalendar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GameSelectionPage : ContentPage
	{
	    private GameSelectionViewModel _viewModel;

		public GameSelectionPage()
		{
			InitializeComponent ();

		    BindingContext = _viewModel = new GameSelectionViewModel();
        }

	    public void OnGameSelected(object sender, SelectedItemChangedEventArgs args)
	    {
	        var game = args.SelectedItem as Game;
            if (game == null)
                return;

            // store new game id
            Preferences.Set("Selected_Game", game.Name);

            Navigation.PopModalAsync();
        }

        protected override bool OnBackButtonPressed()
        {
            MessagingCenter.Send(this, "GameSelected");
            return base.OnBackButtonPressed();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            MessagingCenter.Send(this, "GameSelected");
        }
    }
}