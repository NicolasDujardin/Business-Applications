using System.Collections.Generic;
using System.Threading.Tasks;
using ContinentLandStadFotos.Data;
using ContinentLandStadFotos.Models.Flickr;
using ContinentLandStadFotos.Models.World;
using GalaSoft.MvvmLight.Command;

namespace ContinentLandStadFotos.UWP.ViewModels
{
    public interface IPhotoOverviewViewModel
    {
        IEnumerable<City> Cities { get; }
        IEnumerable<string> Continents { get; }
        IEnumerable<Country> Countries { get; }
        IEnumerable<Photo> Photos { get; }
        Continent SelectedContinent { get; set; }
        Photo SelectedPhoto { get; }
        RelayCommand<object> ShowDetailCMD { get; }
        ICityRepository _cityRepository { get; set; }
        IContinentRepository _continentRepository { get; set; }
        ICountryRepository _countryRepository { get; set; }
        IFlickrRepository _flickrRepository { get; set; }

        Task RetrieveCities();
        Task RetrieveContinents();
        Task RetrieveCountries();
        string Tags();
        Task VerzamelPhotos();
    }
}