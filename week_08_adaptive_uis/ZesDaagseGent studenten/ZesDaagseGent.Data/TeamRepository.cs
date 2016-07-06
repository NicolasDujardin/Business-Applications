using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZesDaagseGent.Models;

namespace ZesDaagseGent.Data
{
    public class TeamRepository : RepositoryBaseClass<Team>
    {
        public override string ApiUrl { get { return "dummy, not using webservices"; } set { } }


        private List<Team> _teams = new List<Team>();
        public async override Task<List<Team>> Get()
        {
            return _teams;
        }

        public override void Add(Team newObject)
        {
            _teams.Add(newObject);
        }
    }
}
