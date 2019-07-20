using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace HMCalendar.SQLite
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
