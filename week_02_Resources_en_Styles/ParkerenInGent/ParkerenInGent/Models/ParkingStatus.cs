using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkerenInGent.Models
{
    public class ParkingStatus
    {
        public int AvailableCapacity { get; set; }
        public int TotalCapacity { get; set; }
        public bool Open { get; set; }
    }
}
