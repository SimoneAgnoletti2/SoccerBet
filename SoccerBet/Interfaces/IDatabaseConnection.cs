using System;
using System.Collections.Generic;
using System.Text;

namespace SoccerBet.Controls
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}