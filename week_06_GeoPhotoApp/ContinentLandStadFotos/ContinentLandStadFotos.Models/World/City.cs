using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Models.World
{
    public class City : ModelBaseClass
    {
        public string CountryCode { get; set; }
        public string District { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public int Population { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
