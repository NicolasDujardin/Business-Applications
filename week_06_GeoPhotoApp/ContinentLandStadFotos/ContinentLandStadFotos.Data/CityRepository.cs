using ContinentLandStadFotos.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Data
{
    public class CityRepository : RepositoryRestBaseClass<City>, ICityRepository
    {
        public override string ApiUrl
        {
            get
            {
                return "http://localhost:57757/api/";
            }
        }

        public override string Controller
        {
            get
            {
                return "City";
            }
        }

        public async Task<IEnumerable<City>> Get(string country)
        {
            return await GetRESTPRM("?countrycode=" + country);
        }
    }
}
