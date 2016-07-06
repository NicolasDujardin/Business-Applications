using StudentModulePuntWS.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace StudentModulePuntWS.Repositories
{
    public class StudentModulePuntRepository
    {
        private static List<StudentModulePunt> _entries;

        public static List<StudentModulePunt> Entries
        {
            get
            {

                if (_entries == null) VerzamelEntries();
                return _entries;
            }
        }

        private static object _verzamelEntriesLock = new object();
        public static void VerzamelEntries()
        {
            lock (_verzamelEntriesLock)
            {
                if (_entries != null) return; //reeds ingevuld door een andere call
                _entries = new List<StudentModulePunt>();   //je kan niet locken op null
                string appdatafolder = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");


                using (StreamReader sr = new StreamReader(appdatafolder + @"\studentmodulepunt.csv"))
                {
                    String lijn = sr.ReadLine(); //kolomhoofdingen
                    lijn = sr.ReadLine();

                    while (lijn != null)
                    {
                        StudentModulePunt ent = MaakPostCode(lijn);
                        if (ent != null) _entries.Add(ent);

                        lijn = sr.ReadLine();
                    }
                }
            }
        }
        private static StudentModulePunt MaakPostCode(string lijn)
        {
            try {
                string[] stukken = lijn.Split(new char[] { ';' });
                if (stukken.Length != 4) return null;
                StudentModulePunt smp = new StudentModulePunt()
                {
                    Email = stukken[0].Trim(),
                    GeboortePlaats = stukken[1].Trim(),
                    Module = stukken[2].Trim(),
                    Punt = int.Parse(stukken[3])
                };
                return smp;
            }
            catch { return null; }
        }

    }
}
