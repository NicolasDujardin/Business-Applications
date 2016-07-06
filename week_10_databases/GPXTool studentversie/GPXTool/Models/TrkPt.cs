using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;
using Windows.Foundation;

namespace GPXTool.Models
{
    public class TrkPt : ModelBaseClass
    {
        public TrkPt(Geopoint gp)
        {
            Latitude = gp.Position.Latitude;
            Longitude = gp.Position.Longitude;
        }
        public int TrackId { get; set; }
        public int MyProperty { get; set; }
        private DateTime _tijdstipdt;
        public DateTime Tijdstip { get; set; }
        public string tijdstip
        {
            get { return Tijdstip.ToString("yyyy MM dd HH:mm:ss"); }
            set { Tijdstip = DateTime.ParseExact(value, "yyyy MM dd HH:mm:ss", null); }
        }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
