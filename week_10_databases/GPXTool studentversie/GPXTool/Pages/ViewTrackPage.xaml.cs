using GPXTool.Models;
using GPXTool.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Maps;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace GPXTool.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ViewTrackPage : Page
    {
        public ViewTrackPage()
        {
            this.InitializeComponent();
            btnShow.Click += (s, e) => DrawTrk();
        }


        private void DrawTrk()
        {
            Trk trk = IocContainer.ViewTrackViewModel.SelectedTrk;
            if (null == trk) return ;
            //if (null ==trk.TrkPts) return;
            //if (0 == trk.TrkPts.Count) return;
            MapPolyline polyline = MakePolyline(trk);

            myMap.MapElements.Clear();
            myMap.MapElements.Add(polyline);

            myMap.ZoomLevel = 14.5;

            myMap.Center =
               new Geopoint(new BasicGeoposition()
               {
                   Latitude = trk.TrkPts[0].Latitude,
                   Longitude = trk.TrkPts[0].Longitude
               });
        }

        private MapPolyline MakePolyline(Trk trk)
        {
            if (trk == null) return null;

            MapPolyline polyline = new MapPolyline();
            polyline.StrokeColor = Colors.Red;
            polyline.StrokeThickness = 2;
            List<BasicGeoposition> pos = new List<BasicGeoposition>();
            BasicGeoposition bpos;

            foreach (TrkPt pt in trk.TrkPts)
            {
                bpos = new BasicGeoposition();
                bpos.Latitude = pt.Latitude;
                bpos.Longitude = pt.Longitude;
                pos.Add(bpos);
            }

            Geopath p = new Geopath(pos);
            polyline.Path = p;

            return polyline;
        }
    }
}
