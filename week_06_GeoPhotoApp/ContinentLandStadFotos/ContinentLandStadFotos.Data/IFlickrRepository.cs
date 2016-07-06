using System.Collections.Generic;
using System.Threading.Tasks;
using ContinentLandStadFotos.Models.Flickr;

namespace ContinentLandStadFotos.Data
{
    public interface IFlickrRepository
    {
        Task<IEnumerable<Photo>> Get(string tags);
    }
}