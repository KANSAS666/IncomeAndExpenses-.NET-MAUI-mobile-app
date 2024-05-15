using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using System.IO;

namespace IncomeAndExpenses.Services
{
    public static class Constants
    {
        public const string FirebaseUrl = "https://chuguncoursework-default-rtdb.europe-west1.firebasedatabase.app/";
        public const string LocalDbName = "SQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string LocalDbPath => Path.Combine(FileSystem.AppDataDirectory, LocalDbName);
    }
}
