using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.Models
{
    public class Url
    {
        //        public string __invalid_name__execution-start-time { get; set; }
        //    public string __invalid_name__execution-stop-time { get; set; }
        //public string __invalid_name__execution-time { get; set; }
        public string content { get; set; }
    }

    public class Diagnostics
    {
        public string publiclyCallable { get; set; }
        public Url url { get; set; }
        //    public string __invalid_name__user-time { get; set; }
        //public string __invalid_name__service-time { get; set; }
        //    public string __invalid_name__build-version { get; set; }
    }

    public class GeoResult
    {
        public string quality { get; set; }
        public string latitude { get; set; }
        public string longitude { get; set; }
        public string offsetlat { get; set; }
        public string offsetlon { get; set; }
        public string radius { get; set; }
        public string singleLineAddress { get; set; }
        public object name { get; set; }
        public object line1 { get; set; }
        public string line2 { get; set; }
        public object line3 { get; set; }
        public string line4 { get; set; }
        public object house { get; set; }
        public object street { get; set; }
        public object xstreet { get; set; }
        public object unittype { get; set; }
        public object unit { get; set; }
        public object postal { get; set; }
        public object neighborhood { get; set; }
        public string city { get; set; }
        public string county { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string countrycode { get; set; }
        public string statecode { get; set; }
        public string countycode { get; set; }
        public string uzip { get; set; }
        public object hash { get; set; }
        public string woeid { get; set; }
        public string woetype { get; set; }
    }

    public class GeoResults
    {
        public GeoResult Result { get; set; }
    }

    public class GeoQuery
    {
        public int count { get; set; }
        public string created { get; set; }
        public string lang { get; set; }
        public Diagnostics diagnostics { get; set; }
        public GeoResults results { get; set; }
    }

    public class YahooGeo
    {
        public GeoQuery query { get; set; }
    }
}
