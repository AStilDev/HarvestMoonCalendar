using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        private List<Character> _inputCharacters;

		public CharacterListPage ()
		{
			InitializeComponent ();
            BindingContext = _viewModel = new CharacterListViewModel();
            MessagingCenter.Subscribe<GameSelectionPage>(this, "GameSelected", SourceCallback);
        }

        public CharacterListPage(List<Character> inputCharacters)
        {
            InitializeComponent();
            BindingContext = _viewModel = new CharacterListViewModel
            {
                Characters = new ObservableCollection<Character>(inputCharacters)
            };

            MessagingCenter.Subscribe<GameSelectionPage>(this, "GameSelected", SourceCallback);
        }

        private void SourceCallback(GameSelectionPage obj)
        {
            BindingContext = _viewModel = new CharacterListViewModel();
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