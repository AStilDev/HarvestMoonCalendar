using System;
using System.Collections.Generic;
using System.Text;

namespace HMCalendar.Models
{
    public class Character
    {
        public int GameId
        { get; set; }

        public int CharacterId
        { get; set; }

        public string Name
        { get; set; }

        public string Favorited
        { get; set; }

        public string Loved
        { get; set; }

        public string Liked
        { get; set; }

        public string Disliked
        { get; set; }

        public string Birthday
        { get; set; }
    }
}
