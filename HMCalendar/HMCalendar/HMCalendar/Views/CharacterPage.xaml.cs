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
		}

	    public void OnFavoritesClicked(object send, TappedEventArgs args)
	    {
	        var vm = new ItemsViewModel("Favorites", _charaVM.FavoritedList);
	        Navigation.PushAsync(new ItemsPage(vm));
	    }
	    public void OnLovesClicked(object send, TappedEventArgs args)
	    {
	        var vm = new ItemsViewModel("Loves", _charaVM.LovedList);
	        Navigation.PushAsync(new ItemsPage(vm));
        }
	    public void OnLikesClicked(object send, TappedEventArgs args)
	    {
	        var vm = new ItemsViewModel("Likes", _charaVM.LikedList);
	        Navigation.PushAsync(new ItemsPage(vm));
        }
	    public void OnDislikesClicked(object send, TappedEventArgs args)
	    {
	        var vm = new ItemsViewModel("Dislikes", _charaVM.DislikedList);
	        Navigation.PushAsync(new ItemsPage(vm));
        }
    }
}