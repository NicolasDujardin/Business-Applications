using BALaboVoorbeeld.Models;
using BALaboVoorbeeld.UWP.Pages;
using BALaboVoorbeeld.UWP.Services;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BALaboVoorbeeld.UWP.ViewModels
{
    public class ShowWeatherDetailsViewModel : ViewModelBaseClass
    {
        //Property Item bevat de gegevens die moeten worden gevisualiseerd in de detail pagina
        private Item _item;
        public Item Item
        {
            get
            {
                return _item;
            }
            set
            {
                if (value == _item) return;
                _item = value;
                OnPropertyChanged(nameof(Item));
            }
        }

        //BackCMD om terug te keren naar de ShowWeatherPage, wordt gebind aan de knope op de ShowWeatherDetailsPage
        private RelayCommand _backCMD;
        public RelayCommand BackCMD
        {
            get
            {
                return _backCMD ?? (_backCMD = new RelayCommand(
                    () => Back()
                    ));
            }
        }

        private void Back()
        {
            //Navigeren naar de ShowWeatherPage met behulp van de Navigate methode in het ApplicationViewModel
            IocContainer.ApplicationViewModel.Navigate(typeof(ShowWeatherPage));
        }
    }
}
