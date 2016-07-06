using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using WorldWS.Models;
using WorldWS.Repositories;

namespace WorldWS.Controllers
{
    public class CountryController : ApiController
    {
        //door aanpassingen in App_Start/WebApiConfig.cs is het een RPC like omgeving, en niet langer REST
        //(je moet de verb nu ook vermelden)
            // GET: api/Country
        public IEnumerable<Country> Get()
        {
            return CountryRepository.VerzamelLanden();
        }

        //[Route("api/countries")]
        [HttpGet]
        public IEnumerable<Country> Get(String continent)
        {
            return CountryRepository.VerzamelLanden().Where(l => l.Continent.Equals(continent, StringComparison.CurrentCultureIgnoreCase));
        }


        //// GET: api/Country/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Country
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Country/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Country/5
        //public void Delete(int id)
        //{
        //}
    }
}
