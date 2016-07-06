using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Models.World
{
    public class Continent : ModelBaseClass
    {
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
