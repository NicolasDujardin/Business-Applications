using GPXTool.Data;
using GPXTool.Models;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTool.Repositories
{
    public class TrkRepository
    {
        public void SaveTrk(Trk trk)
        {
            string ins = $"insert into trk values(?,?,?)";
            object[] args = new object[] { null, trk.Title, trk.Tijdstip.ToString("yyy MM dd HH:mm:ss") };
            int id = SQLiteService.ExecuteInsert(ins, args);
            trk.ID = id;
        }

        public ObservableCollection<Trk> AllTrk
        {
            get
            {
                String sql = "select * from trk";
                var l = Select(sql);
                ObservableCollection<Trk> oc = new ObservableCollection<Trk>(l);
                return oc;
            }
        }

        private static List<Trk> Select(String sql, params object[] args)
        {
            String path = SQLiteService.DBLocation;

            using (SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path))
            {
                var res = conn.Query<Trk>(sql, args);
                return res;
            }
        }
    }
}
