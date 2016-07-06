using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntWS.Models
{
    public class Student
    {
        public String Email { get; set; }
        public String Voornaam
        {
            get
            {
                return Email.Split(new char[] { '.' })[0].Trim();
            }
        }
        public String Familienaam
        {
            get
            {
                return (Email.Split(new char[] { '.' })[1]).Split(new char[] { '@' })[0].Trim();
            }
        }
        public String GeboortePlaats { get; set; }

        public override bool Equals(object obj)
        {
            //twee studente zijn gelijk indien hun email EN hun geboorteplaats gelijk is
            Student ander = obj as Student;
            if (ander == null) return false;

            return this.Email.Equals(ander.Email) &&
                this.GeboortePlaats.Equals(ander.GeboortePlaats);


        }

        public override int GetHashCode()
        {
            return this.Email.GetHashCode() + this.GeboortePlaats.GetHashCode();
        }
    }
}
