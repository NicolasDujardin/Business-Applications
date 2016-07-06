using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WorldWS.Models
{
    //ID;Name;CountryCode;District;Population
    public class City : IComparable<City>
    {
        public int ID { get; set; }
        public String Name { get; set; }
        public String CountryCode { get; set; }
        public String District { get; set; }
        public int Population { get; set; }

        public int CompareTo(City other)
        {
            return this.Name.CompareTo(other.Name);
        }
    }
}
