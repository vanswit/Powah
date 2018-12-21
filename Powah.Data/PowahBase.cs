using SQLite;
using System;
using System.IO;

namespace Powah.Data
{
    public static class PowahBase
    {
        static SQLiteAsyncConnection connection;

        public static SQLiteAsyncConnection PowahBaseConnection
        {
            get
            {
                if (connection == null)
                {
                    connection = new SQLiteAsyncConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "PowahDB.db"));
                }
                return connection;
            }
        }
    }
}
