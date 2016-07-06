using System.Collections.Generic;
using System.Threading.Tasks;
using ContinentLandStadFotos.Models.World;

namespace ContinentLandStadFotos.Data
{
    public interface ICountryRepository
    {
        string ApiUrl { get; }
        string Controller { get; }

        Task<IEnumerable<Country>> Get(string continent);
    }
}