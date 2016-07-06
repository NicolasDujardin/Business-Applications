using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Data;

namespace StudentModulePuntApp.Helpers
{
    public class StudentModulePuntStyleSelector : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {
            int score = (int)value;
            return App.Current.Resources[(score >= 10) ? "Geslaagd" : "Gebuisd"] as Style;
        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}
