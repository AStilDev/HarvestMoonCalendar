using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using HMCalendar.iOS.SQLite;
using HMCalendar.SQLite;
using SQLite;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace HMCalendar.iOS.SQLite
{
    public class DatabaseService : IDBInterface
    {
        public DatabaseService()
        {
        }

        public SQLiteConnection CreateConnection()
        {
            var documentsPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var path = Path.Combine(documentsPath, "harvestmoondb.db");

            return new SQLiteConnection(path);
        }

        //public SQLiteConnection CreateConnection()
        //{
        //    var sqliteFilename = "harvestmoondb.db";

        //    string docFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
        //    string libFolder = Path.Combine(docFolder, "..", "Library", "Databases");

        //    if (!Directory.Exists(libFolder))
        //    {
        //        Directory.CreateDirectory(libFolder);
        //    }
        //    string path = Path.Combine(libFolder, sqliteFilename);

        //    // This is where we copy in the pre-created database
        //    if (!File.Exists(path))
        //    {
        //        var existingDb = NSBundle.MainBundle.PathForResource("harvestmoondb.db", "db");
        //        File.Copy(existingDb, path);
        //    }

        //    var connection = new SQLiteConnection(path);

        //    // Return the database connection 
        //    return connection;
        //}
    }
}
