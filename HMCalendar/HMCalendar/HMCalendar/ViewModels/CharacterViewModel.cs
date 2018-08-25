using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HMCalendar.Models;

namespace HMCalendar.ViewModels
{
    public class CharacterViewModel
    {
        private Character _selectedCharacter;

        public string Name
        {
            get => _selectedCharacter.Name;
        }

        public string Birthday
        {
            get => _selectedCharacter.Birthday;
        }

        public bool HasFavorites
        {
            get => !string.IsNullOrEmpty(FavoritedList);
        }

        public string FavoritedList
        {
            get => _selectedCharacter.Favorited;
        }

        public string LovedList
        {
            get => _selectedCharacter.Loved;
        }

        public string LikedList
        {
            get => _selectedCharacter.Liked;
        }

        public string DislikedList
        {
            get => _selectedCharacter.Disliked;
        }

        public List<string> ItemStatusList;

        public CharacterViewModel(Character chara)
        {
            _selectedCharacter = chara;
        }
    }
}
