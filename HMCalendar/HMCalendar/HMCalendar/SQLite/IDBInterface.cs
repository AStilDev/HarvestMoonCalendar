using System;
using System.Collections.Generic;
using System.Text;
using SQLite.Net;

namespace HMCalendar.SQLite
{
    public interface IDBInterface
    {
        SQLiteConnection CreateConnection();
    }
}
