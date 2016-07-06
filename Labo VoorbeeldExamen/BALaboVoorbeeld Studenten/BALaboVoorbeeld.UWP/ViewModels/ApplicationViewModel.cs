using BALaboVoorbeeld.UWP.Pages;
using BALaboVoorbeeld.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace BALaboVoorbeeld.UWP.ViewModels
{
    public class ApplicationViewModel : ViewModelBaseClass
    {
        private ShowWeatherPage _showWeatherPage;
        private ShowWeatherDetailPage _showWeatherDetailPage;

        public ApplicationViewModel(ShowWeatherPage ShowWeatherPage, ShowWeatherDetailPage ShowWeatherDetailPage)
        {
            _showWeatherPage = ShowWeatherPage;
            _showWeatherDetailPage = ShowWeatherDetailPage;
            CurrentPage = IocContainer.ShowWeatherPage;
        }

        private Page _currentPage;
        public Page CurrentPage
        {
            get
            {
                return _currentPage;
            }
            set
            {
                if (value == _currentPage) return;
                _currentPage = value;
                OnPropertyChanged();
            }
        }

        public void Navigate(Type navigationPageType)
        {
            if(navigationPageType.Equals(typeof(ShowWeatherDetailPage)))
            {
                //Doorgeven van het SelectedItem aan het Item in de ShowWeatherDetailsViewModel
                IocContainer.ShowWeatherDetailsViewModel.Item = IocContainer.ShowWeatherViewModel.SelectedItem;
                CurrentPage = _showWeatherDetailPage;
            }
            else if (navigationPageType.Equals(typeof(ShowWeatherPage)))
            {
                CurrentPage = _showWeatherPage;
            }
        }
    }
}
