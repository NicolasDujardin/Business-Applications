using StudentModulePuntApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntApp.Helpers
{
    public class StudentModulePuntPuntSorter : IComparer<StudentModulePunt>
    {
        public int Compare(StudentModulePunt x, StudentModulePunt y)
        {
            return x.Punt.CompareTo(y.Punt);
        }
    }
}
