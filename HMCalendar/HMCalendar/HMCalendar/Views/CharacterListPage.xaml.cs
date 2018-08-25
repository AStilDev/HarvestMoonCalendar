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

		    BindingContext = _viewModel = new CharacterListViewModel();
        }

	    public void OnCharacterSelected(object sender, SelectedItemChangedEventArgs args)
	    {
	        var chara = args.SelectedItem as Character;
	        if (chara == null)
	            return;

            Navigation.PushAsync(new CharacterPage(new CharacterViewModel(chara)));
	    }
    }
}