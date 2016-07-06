using ParkerenInGent.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Devices.Geolocation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace ParkerenInGent.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ParkingKaart : Page
    {
        PointOfInterestRepository poiRepo;

        public ParkingKaart()
        {
            this.InitializeComponent();
            myMap.Loaded += MyMap_Loaded;
        }

        private void MyMap_Loaded(object sender, RoutedEventArgs e)
        {
            myMap.Center = new Geopoint(new BasicGeoposition()
            {
                Latitude = 51.054,
                Longitude = 3.717

            });
            myMap.ZoomLevel = 15.5;
            poiRepo = new PointOfInterestRepository();
            MapItems.ItemsSource = poiRepo.FetchPOIs(myMap.Center.Position);
        }

        private void mapItemButton_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
