using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntApp.Models
{
    public class StudentModulePunt : IComparable<StudentModulePunt>
    {
        public String Email { get; set; }
        public String GeboortePlaats { get; set; }
        public String Module { get; set; }
        public int Punt { get; set; }


        //eerst op email, daarbinnen op module
        public int CompareTo(StudentModulePunt other)
        {
            return this.Email.Equals(other.Email) ? this.Module.CompareTo(other.Module) : 
                this.Email.CompareTo(other.Email);
        }
    }
}
