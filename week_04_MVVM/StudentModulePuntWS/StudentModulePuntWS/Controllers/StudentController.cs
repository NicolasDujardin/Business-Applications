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
    public class StudentController : ApiController
    {
        private StudentRepository _studrep;
        // GET: api/Student
        public IEnumerable<Student> Get()
        {
            if (_studrep == null) _studrep = new StudentRepository();
            return _studrep.StudentenLijst;
        }

        // GET: api/Student/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Student
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Student/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Student/5
        public void Delete(int id)
        {
        }
    }
}
