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
using Newtonsoft.Json;
using Xamarin.Essentials;

namespace HMCalendar.ViewModels
{
    public class ItemsViewModel : BaseViewModel
    {
        private string _itemListType;
        private List<string> _items;

        private bool _heartedFilterOn;
        //private Item _currentItem;

        public ObservableCollection<Item> Items { get; set; }

        public ObservableCollection<Item> HeartedItems { get; set; }

        public bool HeartedFilterOn
        {
            get => _heartedFilterOn;
            set
            {
                _heartedFilterOn = value;
                OnPropertyChanged();
                ExecuteLoadItemsCommand();
            }
        }

        public Command LoadItemsCommand { get; set; }

        public ItemsViewModel(string itemListType, string favlist)
        {
            Title = itemListType;
            _itemListType = itemListType;
            _items = favlist.Split(',').ToList();
            Items = new ObservableCollection<Item>();
            HeartedItems = new ObservableCollection<Item>();

            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        async Task ExecuteLoadItemsCommand()
        {
            try
            {
                Items.Clear();

                if (HeartedFilterOn)
                {
                    foreach (var heartItem in HeartedItems)
                    {
                        Items.Add(heartItem);
                    }
                }
                else
                {
                    foreach (var item in _items)
                    {
                        Items.Add(new Item
                        {
                            Text = item
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
        }

        public void FavoriteSelectedItem(Item item)
        {
            // add to favorites list and store
            if (item != null && item.Favorited)
            {
                HeartedItems.Add(item);
            }
            else
            {
                HeartedItems.Remove(item);
            }

            Preferences.Set("Hearted_Items", JsonConvert.SerializeObject(HeartedItems));
        }
    }
}