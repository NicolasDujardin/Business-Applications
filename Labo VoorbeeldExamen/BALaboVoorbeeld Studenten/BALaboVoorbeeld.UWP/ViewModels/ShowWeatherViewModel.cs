using BALaboVoorbeeld.Data;
using BALaboVoorbeeld.Models;
using BALaboVoorbeeld.UWP.Pages;
using BALaboVoorbeeld.UWP.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.UWP.ViewModels
{
    public class ShowWeatherViewModel : ViewModelBaseClass
    {
        #region "Constructor"
        //Constructor met Inversion of Control

        public YahooWeatherRepository _yahooWeatherRepository;
        public WeatherInfoRepository _weatherInfoRepository;
        public ShowWeatherViewModel(YahooWeatherRepository YahooWeatherRepository, WeatherInfoRepository WeatherInfoRepository)
        {
            _yahooWeatherRepository = YahooWeatherRepository;
            _weatherInfoRepository = WeatherInfoRepository;
        }
        #endregion

        #region "Lijst van WeatherInfo objecten"

        //Property WeatherInfo, wordt gekoppeld aan de ItemSource van de ListBox
        //Let op 'ObservableCollection' in plaats van List. Gebruik voor alle zekerheid ObservableCollection, deze soort lijst kan de binding verwittigen wanneer er een Item wordt verwijderd indien nodig
        private ObservableCollection<Item> _weatherInfo;
        public ObservableCollection<Item> WeatherInfo
        {
            get
            {
                if (_weatherInfo == null) _weatherInfo = new ObservableCollection<Item>();
                return _weatherInfo;
            }
            set
            {
                if (_weatherInfo == value) return;
                _weatherInfo = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region "Tonen van weer in ListBox"

        //Property Gemeente, wordt gekoppeld aan de text property van de textbox op de ShowWeatherPage. TwoWay binden!!!!! Anders wordt de textbox niet verwittigd dat deze leeg werdt gemaakt.
        private String _gemeente;
        public String Gemeente
        {
            get { return _gemeente; }
            set
            {
                if (value == _gemeente) return;
                _gemeente = value;
                OnPropertyChanged();
            }
        }

        //Commando voor het tonen van de weer elementen in de ListBox
        //ShoWeatherCMD wordt gekoppeld aan de button in de ShowWeatherPage (kan zelf geschreven worden of met behulp van Blend -> wat makkelijker is, zie labo 5)
        private RelayCommand _showWeatherCMD;
        public RelayCommand ShowWeatherCMD
        {
            get
            {
                return _showWeatherCMD ?? (_showWeatherCMD = new RelayCommand(
                    () => ShowWeather()
                    ));
            }
        }

        //Methode die wordt uitgevoerd in het commando
        private async Task ShowWeather()
        {
            if (String.IsNullOrEmpty(Gemeente)) return;

            //Opvragen van de informatie op basis van de gemeente.
            Item i = await _yahooWeatherRepository.Get(Gemeente);

            //Toevoegen aan lijst van het Item dat net werdt opgevraagd
            WeatherInfo.Add(i);

            //Doorgeven dat de lijst met elementen gewijzigd is, anders wordt deze niet weergegeven.
            OnPropertyChanged(nameof(WeatherInfo));

            //Opslaan van de gemeente in de DB met SQLite
            SaveInDB(i, Gemeente);

            //Leegmaken van de Gemeente property. Dit wordt doorgegeven aan de xaml door TwoWay binding.
            Gemeente = String.Empty;
        }
        #endregion

        #region "Opslaan in de SQLite DB"
        private void SaveInDB(Item i, string gemeente)
        {
            _weatherInfoRepository.InsertWeatherInfo(new WeatherInfo()
            {
                village = gemeente,
                time = DateTime.Now.ToString(),
                min = i.forecast0.low.ToString(),
                max = i.forecast0.high.ToString()
            });
        }
        #endregion

        #region "Tonen van het WeatherItem in detail"
        //Property SelectedItem, wordt gebind aan de CommandParameter van de Button in de DataTemplate, let op dat het volledige object wordt doorgeven door niet te specifieren in de Binding.
        public Item SelectedItem { get; private set; }

        //Commando voor het tonen van de weer elementen in detail
        //ShowDetailsCMD wordt gekoppeld aan de button in de de DataTemplate (kan zelf geschreven worden of met behulp van Blend -> wat makkelijker is, zie labo 5)
        private RelayCommand<Object> _showDetailsCMD;
        public RelayCommand<Object> ShowDetailsCMD
        {
            get
            {
                return _showDetailsCMD ?? (_showDetailsCMD = new RelayCommand<object>(
                    (o) => ShowDetails(o)
                    ));
            }
        }


        private void ShowDetails(object o)
        {
            //De property SelectedItem wordt ingesteld op het hele object dat wordt meegegeven via de CommandParameter.
            SelectedItem = o as Item;

            //Navigeren naar de Detailpagina met behulp van de Navigate methode in het ApplicationViewModel
            IocContainer.ApplicationViewModel.Navigate(typeof(ShowWeatherDetailPage));
        }
        #endregion
    }
}
