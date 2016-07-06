using System;

namespace WorldWS.Models
{
    public class Country : IComparable<Country>
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public double SurfaceArea { get; set; }
        public int? IndepYear { get; set; }
        public int Population { get; set; }
        public double? LifeExpectancy { get; set; }
        public double GNP { get; set; }
        public double? GNPOld { get; set; }
        public string LocalName { get; set; }
        public string GovernmentForm { get; set; }
        public string HeadOfState { get; set; }
        public int? Capital { get; set; }
        public string  Code2{get;set;}

        public int CompareTo(Country other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}













