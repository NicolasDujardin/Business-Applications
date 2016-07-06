using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WorldWS.Models;
using WorldWS.Repositories;

namespace WorldWS.Controllers
{
    public class CityController : ApiController
    {
        // GET: api/City
        public IEnumerable<City> Get(String countryCode)
        {
            if (countryCode == null) return null;
            return CityRepository.VerzamelEntries().Where(c => countryCode.Equals(c.CountryCode));
        }
        //public List<City> Get()
        //{
        //    return CityRepository.VerzamelEntries();
        //}

        // GET: api/City/5
        //public City Get(int id)
        //{
        //    return CityRepository.VerzamelEntries().Where(c => c.ID == id).FirstOrDefault();
        //}

        //// POST: api/City
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/City/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/City/5
        //public void Delete(int id)
        //{
        //}
    }
}
