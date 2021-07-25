﻿using SQLite;
using Xamarin.Forms;
using LocalDataAccess.UWP;
using Windows.Storage;
using System.IO;
using SoccerBet.Controls;

[assembly: Dependency(typeof(DatabaseConnection_UWPAsync))]
namespace LocalDataAccess.UWP
{
    public class DatabaseConnection_UWPAsync : IDatabaseConnectionAsync
    {
        public SQLiteAsyncConnection DbConnectionAsync()
        {
            var dbName = "SB.db3";
            var path = Path.Combine(ApplicationData.
              Current.LocalFolder.Path, dbName);
            return new SQLiteAsyncConnection(path);
        }
    }
}
