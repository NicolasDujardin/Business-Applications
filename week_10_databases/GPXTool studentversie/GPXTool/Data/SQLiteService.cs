using SQLite.Net;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTool.Data
{
    public class SQLiteService
    {
        public static String DBLocation = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "GPXTool.sqlite");
        public static void InitSQLite()
        {
            String path = DBLocation; 
            using(SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path))
            {
                CreateTrkTB(conn);
                CreateTrkPtTB(conn);
            }
        }

        public static int ExecuteInsert(String sql, params object[] args)
        {
            String path = DBLocation;

            using(SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path))
            {
                conn.Execute(sql, args);
                int i = conn.ExecuteScalar<int>("select last_insert_rowid()");
                return i;
            }
        }

        private static void CreateTrkTB(SQLiteConnection conn)
        {
            //conn.Execute("drop table trk");
            string createtrk = "create table if not exists trk ("
                + "id integer primary key"
                + ", title text not null"
                + ", tijdstip text not null"
                + ")";
            SQLiteCommand cc = conn.CreateCommand(createtrk);
            cc.ExecuteNonQuery();
        }

        private static void CreateTrkPtTB(SQLiteConnection conn)
        {
            string createtrkpt = "create table if not exists trkpt ("
                + "id integer primary key"
                + ", trkid integer"
                + ", latitude double not null"
                + ", longitude double not null"
                + ", tijdstip text not null"
                + ", foreign key(trkid) references trk(id)"
                + ")";
            SQLiteCommand cc = conn.CreateCommand(createtrkpt);
            cc.ExecuteNonQuery();
        }
    }
}
