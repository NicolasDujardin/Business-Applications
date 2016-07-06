using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.Models
{
    public class Location
    {
        public string city { get; set; }
        public string country { get; set; }
        public string region { get; set; }
    }

    public class Units
    {
        public string distance { get; set; }
        public string pressure { get; set; }
        public string speed { get; set; }
        public string temperature { get; set; }
    }

    public class Wind
    {
        public string chill { get; set; }
        public string direction { get; set; }
        public string speed { get; set; }
    }

    public class Atmosphere
    {
        public string humidity { get; set; }
        public string pressure { get; set; }
        public string rising { get; set; }
        public string visibility { get; set; }
    }

    public class Astronomy
    {
        public string sunrise { get; set; }
        public string sunset { get; set; }
    }

    public class Image
    {
        public string title { get; set; }
        public string width { get; set; }
        public string height { get; set; }
        public string link { get; set; }
        public string url { get; set; }
    }

    public class Condition
    {
        public string code { get; set; }
        public string date { get; set; }
        public string temp { get; set; }
        public string text { get; set; }
        public string ImgURL { get { return $"http://l.yimg.com/a/i/us/we/52/{code}.gif"; } }

    }

    public class Forecast
    {
        public string code { get; set; }
        public string date { get; set; }
        public string day { get; set; }
        public string high { get; set; }
        public string low { get; set; }
        public string text { get; set; }

        public string MinAndMax { get { return "Min: " + low + " Max: " + high; } }
    }


    public class Item
    {
        public string title { get; set; }
        public string lat { get; set; }
        public string @long { get; set; }
        public string link { get; set; }
        public string pubDate { get; set; }
        public Condition condition { get; set; }
        public string description { get; set; }
        public List<Forecast> forecast { get; set; }
        public Forecast forecast0 { get { return forecast[0]; } }
    }

    public class Channel
    {
        public Item item { get; set; }
    }

    public class WeatherResults
    {
        public Channel channel { get; set; }
    }

    public class WeatherQuery
    {
        //public int count { get; set; }
        //public string created { get; set; }
        //public string lang { get; set; }
        public WeatherResults results { get; set; }
    }

    public class YahooWeather
    {
        public WeatherQuery query { get; set; }
    }
}
