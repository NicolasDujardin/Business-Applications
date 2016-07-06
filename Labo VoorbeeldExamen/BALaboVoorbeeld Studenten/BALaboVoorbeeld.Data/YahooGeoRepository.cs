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
    public class YahooGeoRepository
    {
        public virtual async Task<string> Get(String placeName)
        {
            try
            {
                HttpClient client = new HttpClient();
                String url = @"https://query.yahooapis.com/v1/public/yql?q=select%20*%20from%20geo.placefinder%20where%20text%3D%22" + placeName + @"%22&format=json&callback=";

                string yahooGeoJSON = await client.GetStringAsync(url);

                YahooGeo rootObject = JsonConvert.DeserializeObject<YahooGeo>(yahooGeoJSON);

                return rootObject.query.results.Result.woeid;
            }
            catch
                { return null; }
        }
    }
}
