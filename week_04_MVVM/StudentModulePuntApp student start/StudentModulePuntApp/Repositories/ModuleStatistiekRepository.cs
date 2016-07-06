using StudentModulePuntApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntApp.Repositories
{
    public class ModuleStatistiekRepository
    {
        public static ModuleStatistiek ModuleStatistiek(List<StudentModulePunt> smps, String moduleNaam)
        {
            ModuleStatistiek ms = new ModuleStatistiek();
            ms.ModuleNaam = moduleNaam;
            List<StudentModulePunt> gefilterd = (from smp in smps where smp.Module.Equals(moduleNaam) select smp).ToList();
            ms.Maximum = gefilterd.Max<StudentModulePunt>(smp => smp.Punt);
            //ms.Aantal = gefilterd.Count();
            ms.Gemiddelde = gefilterd.Average(smp => smp.Punt);
            return ms;
        }
    }
}
