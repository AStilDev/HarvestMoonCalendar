﻿using System;
using System.Collections.Generic;
using System.Text;
using HMCalendar.Models;
using SQLite.Net;
using Xamarin.Forms;

namespace HMCalendar.SQLite
{
    public class DatabaseManager
    {
        SQLiteConnection dbConnection;
        public DatabaseManager()
        {
            dbConnection = DependencyService.Get<IDBInterface>().CreateConnection();
        }

        public List<Character> GetAllCharacters()
        {
            return dbConnection.Query<Character>("Select * From [Character]");
        }
    }
}