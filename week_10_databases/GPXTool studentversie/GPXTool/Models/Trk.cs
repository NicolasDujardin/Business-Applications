using GPXTool.Services;
using SQLite.Net.Attributes;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTool.Models
{
    public class Trk : ModelBaseClass
    {
        public int ID { get; set; }
        [Column("title")]
        public String Title { get; set; }
        private DateTime _tijdstipdt;
        public DateTime Tijdstip { get; set; }
        public string tijdstip
        {
            get { return Tijdstip.ToString("yyyy MM dd HH:mm:ss"); }
            set { Tijdstip = DateTime.ParseExact(value, "yyyy MM dd HH:mm:ss", null); }
        }

        private ObservableCollection<TrkPt> _trkPts;
        public ObservableCollection<TrkPt> TrkPts
        {
            get
            {
                if (null == _trkPts) CollectTrkPts();
                return _trkPts;
            }
        }

        private void CollectTrkPts()
        {
            _trkPts = IocContainer.TrkPtRepository.TrkPts(this);
            OnPropertyChanged(nameof(TrkPts));
        }
    }
}
