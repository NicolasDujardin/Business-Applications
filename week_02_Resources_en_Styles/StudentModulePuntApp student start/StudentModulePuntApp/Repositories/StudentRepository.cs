using StudentModulePuntApp.Helpers;
using StudentModulePuntApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntApp.Repositories
{
    public class StudentRepository
    {
        public static List<Student> Studenten(List<StudentModulePunt> smps)
        {
            return (from smp in smps
                    group smp by new Student { Email = smp.Email, GeboortePlaats = smp.GeboortePlaats } into emails
                    select emails.Key)
.ToList<Student>();
            //    return (from smp in smps
            //            group smp by new Student { Email = smp.Email, GeboortePlaats = smp.GeboortePlaats } into emails
            //            select new Student() { Email = emails.Key.Email, GeboortePlaats = emails.Key.GeboortePlaats })
            //.ToList<Student>();
            //return (from smp in smps
            //        group smp by new { smp.Email, smp.GeboortePlaats } into emails
            //        select new Student() { Email = emails.Key.Email, GeboortePlaats = emails.Key.GeboortePlaats })
            //        .ToList<Student>();
            //return (from smp in smps
            //        group smp by smp.Email into emails
            //        select new Student() { Email = emails.Key, GeboortePlaats = emails.First().GeboortePlaats })
            //        .ToList<Student>();
        }
    }
}
