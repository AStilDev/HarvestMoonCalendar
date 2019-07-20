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

        public List<Character> GetAllCharacters()
        {
            return dbConnection.Query<Character>("Select * From [Characters]");
        }

        public List<Character> GetCharactersByBirthday(string season)
        {
            return dbConnection.Query<Character>("Select * From [Characters]" +
                                                 "Where birthday like '%" + season + "%'");
        }
    }
}
