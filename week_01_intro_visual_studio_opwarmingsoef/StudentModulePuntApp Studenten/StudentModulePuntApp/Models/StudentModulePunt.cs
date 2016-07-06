using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntApp.Models
{
    public class StudentModulePunt
    {
        public string Email { get; set; }
        public String GeboortePlaats { get; set; }
        public string Module { get; set; }
        public int Punt { get; set; }

        public override string ToString()
        {
            return Module + ": " + Punt;
        }

    }
}
