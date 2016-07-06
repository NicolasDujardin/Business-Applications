using BALaboVoorbeeld.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.Data
{
    public class WeatherInfoRepository
    {
        public int InsertWeatherInfo(WeatherInfo weatherInfo)
        {
            String query = $"insert into weatherinfo values (?,?,?,?,?)";
            object[] args = new object[] { null, weatherInfo.village, weatherInfo.time, weatherInfo.min, weatherInfo.max };
            return SQLiteService.ExecuteInsert(query, args);
        }
    }
}
