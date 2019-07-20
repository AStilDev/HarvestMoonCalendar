using System;
using System.Collections.Generic;
using System.Text;
using HMCalendar.Models;
using SQLite;
using Xamarin.Forms;

namespace HMCalendar.SQLite
{
    public class DatabaseManager
    {
        private readonly SQLiteConnection dbConnection;
        public DatabaseManager()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<Game> GetAllGames()
        {
            return dbConnection.Query<Game>("Select * From [Games]");
        }

        public Game GetGameByName(string name)
        {
            var games = dbConnection.Query<Game>("Select * From [Games]" +
                                            "Where name like '%" + name + "%'");

            return games[0];
        }

        public List<Character> GetAllCharacters(int gameId)
        {
            return dbConnection.Query<Character>("Select * From [Characters]" +
                                                 "Where gameId like '%" + gameId + "%'");
        }

        public List<Character> GetCharactersByBirthday(string season, int gameId)
        {
            return dbConnection.Query<Character>("Select * From [Characters]" +
                                                 "Where birthday like '%" + season + "%'" +
                                                 "and gameId like '%" + gameId + "%'");
        }
    }
}
