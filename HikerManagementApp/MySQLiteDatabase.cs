using SQLite;
using System.Collections.ObjectModel;

namespace HikerManagementApp
{
    class MySQLiteDatase
    {
        private SQLiteConnection dbConnection;
        public const string DB_FILENAME = "MyDB.db03";
        public const SQLiteOpenFlags FLAGS = SQLiteOpenFlags.ReadOnly | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache;

        public string dbPath = "";
        public const string HIKE_TABLE = "Hike";
        public const string ID_COL = "ID";
        public const string NAME_COL = "Name";
        public const string LOCATION_COL = "Location";
        public const string DATE_COL = "Date";
        public const string TIME_COL = "Time";
        public const string DAY_COL = "Day";
        public const string LENGTH_COL = "Length";
        public const string PARKING_COL = "Parking";
        public const string LEVEL_COL = "Level";
        public const string DESCRIPTION_COL = "Description";
        public const string GEAR_COL = "Gear";

        public MySQLiteDatase()
        {
            init();
        }
        public void init()
        {
            dbPath = System.IO.Path.Combine(FileSystem.AppDataDirectory, DB_FILENAME);
            dbConnection = new SQLiteConnection(dbPath);
            dbConnection.CreateTable<Hike>();
        }
        public int insertHike(Hike h)
        {
            return dbConnection.Insert(h);
        }
        public ObservableCollection<Hike> loadHike()
        {
            return (new ObservableCollection<Hike>(dbConnection.Table<Hike>().ToList()));
        }

    }
}