using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZesDaagseGent.Data
{
    public interface IRepository<T>
    {
        string ApiUrl { get; }
        Task<List<T>> Get();
        void Add(T newObject);
    }
}
