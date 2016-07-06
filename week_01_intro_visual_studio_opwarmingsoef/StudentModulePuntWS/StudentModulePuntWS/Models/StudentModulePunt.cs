using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntWS.Models
{
    public class StudentModulePunt
    {
        public String Email { get; set; }
        public String GeboortePlaats { get; set; }
        public String Module { get; set; }
        public int Punt { get; set; }
    }
}
