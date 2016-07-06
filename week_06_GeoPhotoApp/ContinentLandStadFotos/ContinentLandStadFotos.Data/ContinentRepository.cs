using ContinentLandStadFotos.Models.World;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Data
{
    public class ContinentRepository : RepositoryRestBaseClass<String>, IContinentRepository
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
                return "Continent";
            }
        }

        public async Task<IEnumerable<String>> GetContinents()
        {
            return await GetRESTPRM("");
        }
    }
}
