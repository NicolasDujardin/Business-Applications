using ParkerenInGent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace ParkerenInGent.Helpers
{
    public class ParkingStyleSelector : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            ParkingCapacityLevel lvl = (ParkingCapacityLevel)value;
            switch(lvl)
            {
                case ParkingCapacityLevel.SWARMING:
                    return Application.Current.Resources["Swarming"] as Style;
                case ParkingCapacityLevel.FULL:
                    return Application.Current.Resources["Full"] as Style;
                default:
                    return Application.Current.Resources["Parking"] as Style;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
