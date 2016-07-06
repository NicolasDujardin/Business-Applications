using ParkerenInGent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Devices.Geolocation;

namespace ParkerenInGent.Repositories
{
    public class PointOfInterestRepository
    {
        List<Parking> Parkings;
        public async void VerzamelParkings()
        {
            
            List<Parking> parkings = await ParkingRepository.Entries();
            Parkings = parkings;
        }

        public List<PointOfInterest> FetchPOIs(BasicGeoposition center)
        {
            VerzamelParkings();
                
            List<PointOfInterest> pois = new List<PointOfInterest>();
            foreach(Parking p in Parkings)
            {
                pois.Add(new PointOfInterest()
                {
                    DisplayName = p.Description,
                    //ImageSourceUri = ,
                    Location = new Geopoint(new BasicGeoposition()
                    {
                        Latitude = p.Latitude,
                        Longitude = p.Longitude
                    })
                });
            }
            //pois.Add(new PointOfInterest()
            //{
            //    DisplayName = "Place Two",
            //    ImageSourceUri = new Uri("ms-appx:///Assets/MapPin.png", UriKind.RelativeOrAbsolute),
            //    Location = new Geopoint(new BasicGeoposition()
            //    {
            //        Latitude = center.Latitude + 0.001,
            //        Longitude = center.Longitude + 0.001
            //    })
            //});
            //pois.Add(new PointOfInterest()
            //{
            //    DisplayName = "Place Three",
            //    ImageSourceUri = new Uri("ms-appx:///Assets/MapPin.png", UriKind.RelativeOrAbsolute),
            //    Location = new Geopoint(new BasicGeoposition()
            //    {
            //        Latitude = center.Latitude - 0.001,
            //        Longitude = center.Longitude - 0.001
            //    })
            //});
            //pois.Add(new PointOfInterest()
            //{
            //    DisplayName = "Place Four",
            //    ImageSourceUri = new Uri("ms-appx:///Assets/MapPin.png", UriKind.RelativeOrAbsolute),
            //    Location = new Geopoint(new BasicGeoposition()
            //    {
            //        Latitude = center.Latitude - 0.001,
            //        Longitude = center.Longitude + 0.001
            //    })
            //});
            return pois;
        }
    }
}
