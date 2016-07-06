using ContinentLandStadFotos.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.UWP.ViewModels
{
    public class PhotoOverviewDesignViewModel : PhotoOverviewViewModel
    {
        public PhotoOverviewDesignViewModel(IFlickrRepository flickrRepository, IContinentRepository continentRepository, ICountryRepository countryRepository, ICityRepository cityRepository) : base(flickrRepository, continentRepository, countryRepository, cityRepository)
        {

        }

        public override string Tags()
        {
            return "cat";
        }
    }
}
