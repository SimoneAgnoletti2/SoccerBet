using SoccerBet.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SoccerBet.Controls
{
    public class DatabaseLeghe
    {
        public async Task<bool> CreateTableLega()
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();

                await Database.CreateTableAsync(typeof(Lega));
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool TableExist(String tableName)
        {
            try
            {
                SQLiteConnection Database = DependencyService.Get<IDatabaseConnection>().DbConnection();
                var tableInfo = Database.GetTableInfo(tableName);
                if (tableInfo.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public async Task<bool> DropTableLega()
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                List<Utente> v = await Database.QueryAsync<Utente>("DROP TABLE Lega");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<List<Lega>> getLeghe()
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                List<Lega> v = await Database.QueryAsync<Lega>("SELECT * FROM Lega ORDER BY Nome");
                {
                    return v;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<bool> InsLega(Lega p)
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                int numero = await Database.InsertOrReplaceAsync(p);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
