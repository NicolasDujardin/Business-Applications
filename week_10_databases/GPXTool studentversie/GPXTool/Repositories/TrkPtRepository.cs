using GPXTool.Data;
using GPXTool.Models;
using GPXTool.Services;
using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTool.Repositories
{
    public class TrkPtRepository
    {
        public void SaveTrkPt(TrkPt trkPt)
        {
            string ins = $"insert into trkpt values(?,?,?,?,?)";
            object[] args = new object[] { null, trkPt.TrackId, trkPt.Latitude, trkPt.Longitude,trkPt.Tijdstip.ToString("yyy MM dd HH:mm:ss") };
            int id = SQLiteService.ExecuteInsert(ins, args);
        }

        public ObservableCollection<TrkPt> TrkPts(Trk trk)
        {
            String sql = "select * from trkpt where (trkid = ?)";
            object[] args = new object[] { trk.ID };
            var l = Select(sql);
            ObservableCollection<TrkPt> oc = new ObservableCollection<TrkPt>(l);
            return oc;
        }

        private static List<TrkPt> Select(String sql, params object[] args)
        {
            String path = SQLiteService.DBLocation;

            using (SQLiteConnection conn = new SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path))
            {
                var res = conn.Query<TrkPt>(sql, args);
                return res;
            }
        }
    }
}
