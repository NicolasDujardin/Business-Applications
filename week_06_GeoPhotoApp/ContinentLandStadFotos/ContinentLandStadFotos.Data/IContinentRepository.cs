using System.Collections.Generic;
using System.Threading.Tasks;
using ContinentLandStadFotos.Models.World;

namespace ContinentLandStadFotos.Data
{
    public interface IContinentRepository
    {
        string ApiUrl { get; }
        string Controller { get; }

        Task<IEnumerable<string>> GetContinents();
    }
}