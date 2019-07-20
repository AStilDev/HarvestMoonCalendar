using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using HMCalendar.Models;
using HMCalendar.SQLite;

namespace HMCalendar.ViewModels
{
    public class GameSelectionViewModel : BaseViewModel
    {
        private DatabaseManager _dbManager;

        public ObservableCollection<Game> Games { get; set; }

        public GameSelectionViewModel()
        {
            Title = "Game Selection";

            _dbManager = new DatabaseManager();

            Games = new ObservableCollection<Game>();

            LoadGames();
        }

        private void LoadGames()
        {
            List<Game> allGames = _dbManager.GetAllGames().ToList();

            foreach (Game game in allGames)
            {
                Games.Add(game);
            }
        }
    }
}
