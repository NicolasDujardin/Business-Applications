using ContinentLandStadFotos.Data;
using ContinentLandStadFotos.Models.Flickr;
using ContinentLandStadFotos.Models.World;
using ContinentLandStadFotos.UWP.Pages;
using ContinentLandStadFotos.UWP.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.UWP.ViewModels
{
    public class PhotoOverviewViewModel : ViewModeBaseClass, IPhotoOverviewViewModel
    {
        public IFlickrRepository _flickrRepository { get; set; }
        public IContinentRepository _continentRepository { get; set; }
        public ICountryRepository _countryRepository { get; set; }
        public ICityRepository _cityRepository { get; set; }

        public PhotoOverviewViewModel(IFlickrRepository flickrRepository, IContinentRepository continentRepository, ICountryRepository countryRepository, ICityRepository cityRepository)
        {
            _flickrRepository = flickrRepository;
            _continentRepository = continentRepository;
            _countryRepository = countryRepository;
            _cityRepository = cityRepository;
        }

        private IEnumerable<Photo> _photos;
        public IEnumerable<Photo> Photos
        {
            get
            {
                if (_photos == null) VerzamelPhotos();
                return _photos;
            }
        }

        public virtual string Tags()
        {
            return "dog";
        }

        public async Task VerzamelPhotos()
        {
            _photos = await _flickrRepository.Get(Tags());
            OnPropertyChanged("Photos");
        }

        private RelayCommand<Object> _showDetailCMD;
        public RelayCommand<object> ShowDetailCMD
        {
            get
            {
                return _showDetailCMD ?? (_showDetailCMD = new RelayCommand<object>(
                    (o) => ShowDetail(o)
                    ));
            }
        }

        public Photo SelectedPhoto { get; private set; }
        private void ShowDetail(object o)
        {
            SelectedPhoto = o as Photo;
            IoCContainer.ApplicationViewModel.Navigate(typeof(PhotoDetailPage));
        }

        private IEnumerable<String> _continents;
        public IEnumerable<String> Continents
        {
            get
            {
                if (_continents == null) RetrieveContinents();
                return _continents;
            }
        }

        public async Task RetrieveContinents()
        {
            _continents = await _continentRepository.GetContinents();
            OnPropertyChanged("Continents");
        }

        private Continent _selectedContinent;
        public Continent SelectedContinent
        {
            get { return _selectedContinent; }
            set
            {
                if (value == _selectedContinent) return;
                _selectedContinent = value;
                OnPropertyChanged("SelectedContinent");
            }
        }

        private IEnumerable<Country> _countries;
        public IEnumerable<Country> Countries
        {
            get
            {
                if (_countries == null) RetrieveCountries();
                return _countries;
            }
        }

        public async Task RetrieveCountries()
        {
            _countries = await _countryRepository.Get("Europe");
            OnPropertyChanged("Countries");
        }

        private IEnumerable<City> _cities;
        public IEnumerable<City> Cities
        {
            get
            {
                if (_continents == null) RetrieveCities();
                return _cities;
            }
        }

        public async Task RetrieveCities()
        {
            _cities = await _cityRepository.Get("BEL");
            OnPropertyChanged("Cities");
        }
    }
}
