using SoccerBet.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SoccerBet.Controls
{
    public class DatabasePaesi
    {
        public async Task<bool> CreateTablePaese()
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();

                await Database.CreateTableAsync(typeof(Paese));
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
        public async Task<bool> DropTablePaese()
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                List<Utente> v = await Database.QueryAsync<Utente>("DROP TABLE Paese");
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public async Task<List<Paese>> getPaesi()
        {
            try
            {
                SQLiteAsyncConnection Database = DependencyService.Get<IDatabaseConnectionAsync>().DbConnectionAsync();
                List<Paese> v = await Database.QueryAsync<Paese>("SELECT * FROM Paese ORDER BY Valida, Nome ");
                {
                    return v;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public async Task<bool> InsPaese(Paese p)
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
