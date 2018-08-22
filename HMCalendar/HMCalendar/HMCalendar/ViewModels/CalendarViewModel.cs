using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

namespace HMCalendar.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private string _season;
        private string _seasonColor;
        private int _index;

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

        public int NumberOfDays
        {
            get => 30;
        }
    
        public CalendarViewModel()
        {
            Title = "Friends of Mineral Town";
            _index = 0;
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