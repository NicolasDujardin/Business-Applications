using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WorldWS.helpers;
using WorldWS.Models;

namespace WorldWS.Repositories
{
    public class CityRepository
    {
        private static List<City> _entries;
        private static object _verzamelEntriesLock = new object();
        public static List<City> VerzamelEntries()
        {
            lock (_verzamelEntriesLock)
            {
                if (_entries != null) return _entries; //reeds ingevuld door een andere call
                _entries = new List<City>();   //je kan niet locken op null
                string appdatafolder = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");


                using (StreamReader sr = new StreamReader(appdatafolder + @"/cities.csv"))
                {
                    String lijn = sr.ReadLine(); //kolomhoofdingen
                    lijn = sr.ReadLine();

                    while (lijn != null)
                    {
                        City ent = MaakCountry(lijn);
                        if (ent != null) _entries.Add(ent);

                        lijn = sr.ReadLine();
                    }
                }
            }
            _entries.Sort();
            return _entries;
        }
        private static City MaakCountry(string lijn)
        {
            try
            {
                String[] stukken = lijn.Split(new char[] { ';' });
                if (stukken.Length != 6) return null;

                City c = new City()
                {
                    ID = stukken[0].ToNInt().Value
                  , Name = stukken[1].Trim()
                  , CountryCode = stukken[2].Trim()
                  , District = stukken[3].Trim()
                  , Population = stukken[4].ToNInt().Value
                };
                return c;
            }
            catch (Exception ex) { return null; }
        }

    }
}
