using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;
using HMCalendar.Models;
using HMCalendar.SQLite;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace HMCalendar.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private string _season;
        private string _seasonColor;
        private List<Character> _seasonCharacters;
        private int _index;
        private int _gameId;
        private readonly DatabaseManager _dbManager;

        // seasons
        public Dictionary<string, string> SeasonColors = new Dictionary<string, string>
            { { "Spring", "#ed9abe"}, {"Summer", "#f9f398"}, {"Fall", "#e2945d"}, {"Winter", "#96d1ff"} };

        public List<string> Seasons = new List<string> {"Spring", "Summer", "Fall", "Winter"};

        public string Season
        {
            get
            {
                if (_season == null)
                {
                    return Seasons.First();
                }
                else
                {
                    return _season;
                }
            }
            set
            {
                _season = value;
                SeasonColor = SeasonColors[_season];
                SeasonCharacters = _dbManager.GetCharactersByBirthday(Season, _gameId);
                OnPropertyChanged();
            }
        }

        public string SeasonColor
        {
            get
            {
                if (_seasonColor == null)
                {
                    return SeasonColors[Seasons.First()];
                }
                else
                {
                    return _seasonColor;
                }
            }

            set
            {
                _seasonColor = value;
                OnPropertyChanged();
            }
        }

        public List<Character> SeasonCharacters
        {
            get
            {
                if (_seasonCharacters == null)
                {
                    _seasonCharacters = _dbManager.GetCharactersByBirthday(Season, _gameId);
                }
                return _seasonCharacters;
            }

            set
            {
                _seasonCharacters = value;
                OnPropertyChanged();
            }
        }

        public int NumberOfDays
        {
            get => 30; // todo different in AWL
        }
    
        public CalendarViewModel()
        {
            string gameName = Preferences.Get("Selected_Game", "Harvest Moon: Friends of Mineral Town");

            Title = gameName;
            _index = 0;
            _dbManager = new DatabaseManager();

            // pull gameid from prefs
            var game = _dbManager.GetGameByName(gameName);
            _gameId = game.GameId;

            //_seasonCharacters = _dbManager.GetCharactersByBirthday(Season);
        }
        
        public void OnLeftClicked()
        {
            Season = PreviousSeason();
        }

        public void OnRightClicked()
        {
            Season = NextSeason();
        }

        private string NextSeason()
        {
            _index++;

            if (_index >= Seasons.Count)
            {
                _index = 0; // return to first
            }

            return Seasons[_index];
        }

        private string PreviousSeason()
        {
            _index--;

            if (_index < 0)
            {
                _index = Seasons.Count - 1; // return to last
            }

            return Seasons[_index];
        }
    }
}