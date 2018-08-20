using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;

using Xamarin.Forms;

namespace HMCalendar.ViewModels
{
    public class CalendarViewModel : BaseViewModel
    {
        private string _season;

        // seasons
        public Dictionary<string, string> Seasons = new Dictionary<string, string>
            { { "Spring", "#ed9abe"}, {"Summer", "#f9f398"}, {"Fall", "#e2945d"}, {"Winter", "#96d1ff"} };

        public string Season
        {
            get
            {
                if (_season == null)
                {
                    return Seasons.First().Key;
                }
                else
                {
                    return _season;
                }
            }
            set
            {
                _season = value;
                OnPropertyChanged();
            }
        }

        public string SeasonColor => Seasons[Season];

        public CalendarViewModel()
        {
            Title = "Friends of Mineral Town";
        }
    }
}