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

        [HttpGet]
        public IEnumerable<StudentModulePunt> StudentStudentModulePunten(String email)
        {
            return StudentModulePuntRepository.Entries.Where(smp => smp.Email.Equals(email));
        }



    }
}
