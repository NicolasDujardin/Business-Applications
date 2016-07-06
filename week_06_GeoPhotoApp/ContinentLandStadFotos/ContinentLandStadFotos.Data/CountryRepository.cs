using ContinentLandStadFotos.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Data
{
    public class CountryRepository : RepositoryRestBaseClass<Country>, ICountryRepository
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
                return "Country";
            }
        }

        public async Task<IEnumerable<Country>> Get(string continent)
        {
            return await GetRESTPRM("?continent=" + continent);
        }
    }
}
