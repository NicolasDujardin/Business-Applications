using GPXTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace GPXTool.Models
{
    public class Tracker : ModelBaseClass
    {
        public bool _isStarted = false;
        public Trk CurrentTrk { get; set; }

        private Geolocator _locator = new Geolocator();
        public Tracker()
        {
            _locator.DesiredAccuracyInMeters = 1;
            _locator.PositionChanged += _locator_PositionChanged;
        }

        private async void _locator_PositionChanged(Geolocator sender, PositionChangedEventArgs args)
        {
            await IocContainer.ViewTrackPage.Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, BewaarPositie);
        }

        private async void BewaarPositie()
        {
            try
            {
                if (!_isStarted) return;
                if (null == CurrentTrk) return;
                Geoposition pos = await _locator.GetGeopositionAsync();
                TrkPt trkpt = new TrkPt(pos.Coordinate.Point);
                trkpt.TrackId = CurrentTrk.ID;
                IocContainer.TrkPtRepository.SaveTrkPt(trkpt);
                CurrentTrk.TrkPts.Add(trkpt);
            }
            catch(Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
        }
    }
}
