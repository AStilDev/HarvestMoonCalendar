using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using HMCalendar.Models;
using HMCalendar.Views;
using HMCalendar.ViewModels;

namespace HMCalendar.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class ItemsPage : ContentPage
	{
        private readonly ItemsViewModel _viewModel;

        public ItemsPage(ItemsViewModel vm)
        {
            InitializeComponent();

            BindingContext = _viewModel = vm;
        }

        public void OnItemSelected(object sender, SelectedItemChangedEventArgs args)
        {
            var item = args.SelectedItem as Item;
            if (item == null)
                return;

            // toggle heart
            item.Favorited = !item.Favorited;
            _viewModel.FavoriteSelectedItem(item);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_viewModel.Items.Count == 0)
                _viewModel.LoadItemsCommand.Execute(null);
        }

        public void OnOptionsClicked(object sender, EventArgs args)
        {
            // todo Hearted Items filter
        }
    }
}