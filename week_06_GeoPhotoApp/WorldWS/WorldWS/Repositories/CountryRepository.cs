using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using WorldWS.Models;
using WorldWS.helpers;

namespace WorldWS.Repositories
{
    public class CountryRepository
    {
        private static List<Country> _entries;
        private static object _verzamelEntriesLock = new object();
        public static IEnumerable<Country> VerzamelLanden()
        {
            lock (_verzamelEntriesLock)
            {
                if (_entries != null) return _entries; //reeds ingevuld door een andere call
                _entries = new List<Country>();   //je kan niet locken op null
                string appdatafolder = Path.Combine(HttpContext.Current.Request.PhysicalApplicationPath, "App_Data");


                using (StreamReader sr = new StreamReader(appdatafolder + @"/landen.csv"))
                {
                    String lijn = sr.ReadLine(); //kolomhoofdingen
                    lijn = sr.ReadLine();

                    while (lijn != null)
                    {
                        Country ent = MaakCountry(lijn);
                        if (ent != null) _entries.Add(ent);

                        lijn = sr.ReadLine();
                    }
                }
            }
            _entries.Sort();
            return _entries;
        }
        private static Country MaakCountry(string lijn)
        {
            try
            {
                String[] stukken = lijn.Split(new char[] { ';' });
                if (stukken.Length != 16) return null;

                Country c = new Country()
                {
                    Code = stukken[0].Trim(),
                    Name = stukken[1].Trim(),
                    Continent = stukken[2].Trim(),
                    Region = stukken[3].Trim(),
                    SurfaceArea = stukken[4].ToNDouble().Value
                   , IndepYear= stukken[4].ToNInt()
                   , Population = stukken[6].ToNInt().Value
                   , LifeExpectancy = stukken[7].ToNDouble()
                   , GNP = stukken[8].ToNDouble().Value
                   , GNPOld = stukken[9].ToNDouble()
                   , LocalName = stukken[10].Trim()
                   , GovernmentForm = stukken[11].Trim()
                   , HeadOfState = stukken[12].Trim()
                   , Capital = stukken[13].ToNInt()
                   , Code2 = stukken[14].Trim()
                };
                return c;
            }
            catch (Exception ex) { return null; }
        }

        public static IEnumerable<String> VerzamelContinenten()
        {
            IEnumerable<Country> landen = VerzamelLanden();
            IEnumerable<String> continenten =
                (from l in landen
                 group l by l.Continent into conts
                 select conts.Key);
            return continenten.OrderBy(s => s);
        }
    }
}
