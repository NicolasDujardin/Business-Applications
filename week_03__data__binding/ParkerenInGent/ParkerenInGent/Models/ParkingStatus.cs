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
        public string CapacityWeergave
        {
            get
            {
                return AvailableCapacity + " / " + TotalCapacity;
            }
        }
        public ParkingCapacityLevel ParkingStatusExtra
        {
            get
            {
                if (AvailableCapacity < 1)
                    return ParkingCapacityLevel.FULL;
                else if (AvailableCapacity < (TotalCapacity * 0.30))
                    return ParkingCapacityLevel.SWARMING;
                else
                    return ParkingCapacityLevel.AVAILABLE;
            }
        }
    }
}
