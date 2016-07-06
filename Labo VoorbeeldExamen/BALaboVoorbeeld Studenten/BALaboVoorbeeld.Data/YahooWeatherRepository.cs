using BALaboVoorbeeld.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.Data
{
    public class YahooWeatherRepository
    {
        public virtual async Task<Item> Get(String gemeente)
        {
            try
            {
                YahooGeoRepository repo = new YahooGeoRepository();
                string woeid = await repo.Get(gemeente);


                HttpClient client = new HttpClient();
                String url = @"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20weather.forecast%20where%20woeid%3D" + woeid + @"%20and%20u%3D'c'&format=json&callback=";                    

                string yahooWeatherJSON = await client.GetStringAsync(url);

                YahooWeather rootObject = JsonConvert.DeserializeObject<YahooWeather>(yahooWeatherJSON);

                return rootObject.query.results.channel.item;
            }
            catch
            { return null; }
        }
    }
}
