using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Models.World
{
    public class Country : ModelBaseClass
    {
        public int Capital { get; set; }
        public string Code { get; set; }
        public string Code2 { get; set; }
        public string Continent { get; set; }
        public double GNP { get; set; }
        public double? GNPOld { get; set; }
        public string GovernmentForm { get; set; }
        public string HeadOfState { get; set; }
        public int IndepYear { get; set; }
        public double? LifeExpectancy { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }
        public string Region { get; set; }
        public double SurfaceArea { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
