using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BAVoorbeeldLaboWPF
{
    public class WeatherInfoRepository
    {
        public static List<WeatherInfo> WeatherInfos
        {
            get
            {
                List<WeatherInfo> res = new List<WeatherInfo>();
                res.Add(new WeatherInfo() { Title = "Wevelgem info", Village = "Wevelgem", Min = 11, Max = 13 });
                res.Add(new WeatherInfo() { Title = "Kortrijk info", Village = "Kortrijk", Min = 11, Max = 13 });
                res.Add(new WeatherInfo() { Title = "Paris info", Village = "Paris", Min = 15, Max = 17 });
                res.Add(new WeatherInfo() { Title = "Rome info", Village = "Rome", Min = 16, Max = 18 });
                return res;
            }
        }
    }
}
