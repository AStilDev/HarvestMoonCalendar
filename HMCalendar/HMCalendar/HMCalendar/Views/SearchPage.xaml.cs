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
	public partial class SearchPage : ContentPage
    {
        private List<Character> _searchResults;
        private SearchViewModel _searchViewModel;

		public SearchPage ()
		{
			InitializeComponent ();
            BindingContext = _searchViewModel = new SearchViewModel();
            MessagingCenter.Subscribe<GameSelectionPage>(this, "GameSelected", SourceCallback);
        }

        private void SourceCallback(GameSelectionPage obj)
        {
            BindingContext = _searchViewModel = new SearchViewModel();
        }

        public async void OnSearchClicked(object sender, EventArgs args)
        {
            _searchResults = _searchViewModel.FindCharaByKeyword();

            if (_searchResults.Any())
            {
                NoResultsLabel.IsVisible = false;
                await Navigation.PushAsync(new CharacterListPage(_searchResults));
            }
            else
            {
                NoResultsLabel.IsVisible = true;
            }
        }

        public async void OnOptionsClicked(object sender, EventArgs args)
        {
            // open game change selection
            await Navigation.PushModalAsync(new GameSelectionPage());
        }
    }
}