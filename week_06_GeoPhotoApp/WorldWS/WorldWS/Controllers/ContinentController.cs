using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorldWS.Repositories;

namespace WorldWS.Controllers
{
    public class ContinentController : ApiController
    {
        // GET: api/Continent
        public IEnumerable<string> Get()
        {
            return CountryRepository.VerzamelContinenten();
        }

        //// GET: api/Continent/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Continent
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Continent/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Continent/5
        //public void Delete(int id)
        //{
        //}
    }
}
