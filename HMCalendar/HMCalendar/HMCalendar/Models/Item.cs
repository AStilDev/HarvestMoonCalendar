using System;
using System.ComponentModel;

namespace HMCalendar.Models
{
    public class Item : INotifyPropertyChanged
    {
        private bool _favorited;

        public string Id { get; set; }
        public string Text { get; set; }
        public string Description { get; set; }

        public bool Favorited
        {
            get => _favorited;
            set
            {
                _favorited = value;
                OnPropertyChanged(nameof(Favorited));
            }
        }

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}