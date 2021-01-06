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
    public class SearchViewModel : BaseViewModel
    {
        private DatabaseManager _dbManager;
        private Game _currentGame;

        public string Keyword { get; set; }

        public List<string> Columns => new List<string> {"Favorited", "Loved", "Liked", "Disliked"};

        public string Column { get; set; }

        public SearchViewModel()
        {
            // get name of game from prefs
            var gameName = Preferences.Get("Selected_Game", "Harvest Moon: Friends of Mineral Town");

            Title = gameName;

            _dbManager = new DatabaseManager();

            LoadGame(gameName);
        }

        public List<Character> FindCharaByKeyword()
        {
            return _dbManager.GetCharactersByKeyword(_currentGame.GameId, Column, Keyword);
        }

        private void LoadGame(string gameName)
        {
            // pull gameid from prefs
            _currentGame = _dbManager.GetGameByName(gameName);
        }
    }
}
