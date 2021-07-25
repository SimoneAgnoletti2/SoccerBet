using SQLite;
using LocalDataAccess.Droid;
using System.IO;
using SoccerBet.Controls;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_AndroidAsync))]
namespace LocalDataAccess.Droid
{
    public class DatabaseConnection_AndroidAsync : IDatabaseConnectionAsync
    {
        public SQLiteAsyncConnection DbConnectionAsync()
        {
            var dbName = "SB.db3";
            var path = Path.Combine(System.Environment.
              GetFolderPath(System.Environment.
              SpecialFolder.Personal), dbName);
            return new SQLiteAsyncConnection(path);
        }
    }
}