using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZesDaagseGent.Data
{
    public abstract class RepositoryBaseClass<T> : IRepository<T>
    {
        public abstract string ApiUrl   {  get; set;  }

        public abstract void Add(T newObject);

        public abstract Task<List<T>> Get();
    }
}
