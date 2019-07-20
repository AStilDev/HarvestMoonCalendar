using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HMCalendar.Models;
using HMCalendar.SQLite;
using Xamarin.Essentials;

namespace HMCalendar.ViewModels
{
    public class CharacterListViewModel : BaseViewModel
    {
        private DatabaseManager _dbManager;

        public ObservableCollection<Character> Characters { get; set; }

        public CharacterListViewModel()
        {
            // get name of game from prefs
            var gameName = Preferences.Get("Selected_Game", "Harvest Moon: Friends of Mineral Town");

            Title = gameName;

            _dbManager = new DatabaseManager();

            Characters = new ObservableCollection<Character>();

            LoadCharacters(gameName);
        }

        private void LoadCharacters(string gameName)
        {
            // pull gameid from prefs
            Game game = _dbManager.GetGameByName(gameName);

            List<Character> allCharas = _dbManager.GetAllCharacters(game.GameId).ToList();

            foreach (Character chara in allCharas)
            {
                Characters.Add(chara);
            }
        }
    }
}
