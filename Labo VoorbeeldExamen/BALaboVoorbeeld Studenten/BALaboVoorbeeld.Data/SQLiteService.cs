using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.Data
{
    public class SQLiteService
    {
        //Vergeet niet het NuGet Package 'SQLite.Net-PCL te installeren'
        //Alsook een referentie te leggen naar 'SQLite for Universal App Platform'
        //EN ZEKER NIET VERGETEN -> in de App.xaml.cs de InitSQLite methode op te roepen in de constructor
        public static String DBLocation = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "WeatherInfo.sqlite");

        public static void InitSQLite()
        {            
            using(SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBLocation))
            {
                CreateWeatherInfoTB(conn);
            }
        }

        private static void CreateWeatherInfoTB(SQLiteConnection conn)
        {
            String query = "create table if not exists weatherinfo ("
                + "id integer primary key"
                + ", village text not null"
                + ", time text not null"
                + ", min text not null"
                + ", max text not null"
                + ")";
            SQLiteCommand cc = conn.CreateCommand(query);
            cc.ExecuteNonQuery();
        }

        public static int ExecuteInsert(String sql, params object[] args)
        {
            using (SQLiteConnection con = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), DBLocation))
            {
                con.Execute(sql, args);
                int i = con.ExecuteScalar<int>("select last_insert_rowid()");
                return i;
            }
        }
    }
}
