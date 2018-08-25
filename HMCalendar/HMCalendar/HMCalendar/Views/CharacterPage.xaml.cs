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
	public partial class CharacterPage : ContentPage
	{
	    private CharacterViewModel _charaVM;

		public CharacterPage (CharacterViewModel vm)
		{
			InitializeComponent ();

		    BindingContext = _charaVM = vm;

		    if (!string.IsNullOrEmpty(vm.FavoritedList))
		    {
                // add favorites
		        var favBtn = new Button()
		        {

		        };

		        MainLayout.Children.Add(favBtn);
		    }
		}

	    public void OnExitClicked(object sender, EventArgs args)
	    {
	        Navigation.PopModalAsync();
	    }
    }
}