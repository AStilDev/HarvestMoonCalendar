using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HMCalendar.Models;
using HMCalendar.SQLite;

namespace HMCalendar.ViewModels
{
    public class CharacterListViewModel : BaseViewModel
    {
        private DatabaseManager _dbManager;

        public ObservableCollection<Character> Items { get; set; }

        public CharacterListViewModel()
        {
            Title = "Friends of Mineral Town"; // todo

            _dbManager = new DatabaseManager();

            Items = new ObservableCollection<Character>();

            LoadItems();
        }

        private void LoadItems()
        {
            List<Character> allCharas = _dbManager.GetAllCharacters().ToList();

            foreach (Character chara in allCharas)
            {
                Items.Add(chara);
            }
        }
    }
}
