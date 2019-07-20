using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Xamarin.Forms;

using HMCalendar.Models;
using HMCalendar.SQLite;
using HMCalendar.Views;

namespace HMCalendar.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private string _itemListType;
        private List<string> _items;
        //private Item _currentItem;

        public ObservableCollection<Item> Items { get; set; }

        //public Item CurrentItem
        //{
        //    get => _currentItem;
        //    set
        //    {
        //        _currentItem = value;
        //        OnPropertyChanged();
        //    }
        //}

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel(string itemListType, string favlist)
        {
            Title = itemListType;
            _itemListType = itemListType;
            _items = favlist.Split(',').ToList();
            Items = new ObservableCollection<Item>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());

            /*MessagingCenter.Subscribe<NewItemPage, Item>(this, "AddItem", async (obj, item) =>
            {
                var _item = item as Item;
                Items.Add(_item);
                await DataStore.AddItemAsync(_item);
            });*/
        }

        async Task ExecuteLoadItemsCommand()
        {
            // todo want to get user prefs from Settings.cs

            if (IsBusy)
                return;

            IsBusy = true;

            try
            {
                Items.Clear();

                foreach (var item in _items)
                {
                    Items.Add(new Item
                    {
                        Text = item
                    });
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }

        public void FavoriteSelectedItem(Item item)
        {
            // todo add to favorites list and store
            //CurrentItem.Favorited = !CurrentItem.Favorited;
            //OnPropertyChanged(nameof(CurrentItem));
        }
    }
}