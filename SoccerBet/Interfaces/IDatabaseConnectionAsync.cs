using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerBet.Controls
{
    public interface IDatabaseConnectionAsync
    {
        SQLite.SQLiteAsyncConnection DbConnectionAsync();
    }
}