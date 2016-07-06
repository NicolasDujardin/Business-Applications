using StudentModulePuntWS.Models;
using StudentModulePuntWS.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace StudentModulePuntWS.Controllers
{
    public class StudentModulePuntController : ApiController
    {
        // GET: api/StudentModulePunt
        public IEnumerable<StudentModulePunt> Get()
        {
            return StudentModulePuntRepository.Entries;
        }

        // GET: api/StudentModulePunt/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/StudentModulePunt
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/StudentModulePunt/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/StudentModulePunt/5
        public void Delete(int id)
        {
        }
    }
}
