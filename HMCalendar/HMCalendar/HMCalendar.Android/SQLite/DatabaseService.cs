﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using HMCalendar.Droid.SQLite;
using HMCalendar.SQLite;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(DatabaseService))]
namespace HMCalendar.Droid.SQLite
{
    public class DatabaseService : IDBInterface
    {
        public DatabaseService()
        {
        }

        //public SQLiteConnection CreateConnection()
        //{
        //    var documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
        //    var path = Path.Combine(documentsPath, "harvestmoondb.db");

        //    return new SQLiteConnection(path);
        //}

        public SQLiteConnection CreateConnection()
        {
            var sqliteFilename = "harvestmoondb.db";
            string documentsDirectoryPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsDirectoryPath, sqliteFilename);

            // This is where we copy in our pre-created database
            //if (!File.Exists(path))
            //{
                using (var binaryReader = new BinaryReader(Android.App.Application.Context.Assets.Open(sqliteFilename)))
                {
                    using (var binaryWriter = new BinaryWriter(new FileStream(path, FileMode.Create)))
                    {
                        byte[] buffer = new byte[2048];
                        int length = 0;
                        while ((length = binaryReader.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            binaryWriter.Write(buffer, 0, length);
                        }
                    }
                }
            //}

            var conn = new SQLiteConnection(path);

            return conn;
        }

        void ReadWriteStream(Stream readStream, Stream writeStream)
        {
            int Length = 256;
            Byte[] buffer = new Byte[Length];
            int bytesRead = readStream.Read(buffer, 0, Length);
            while (bytesRead >= 0)
            {
                writeStream.Write(buffer, 0, bytesRead);
                bytesRead = readStream.Read(buffer, 0, Length);
            }
            readStream.Close();
            writeStream.Close();
        }
    }
}