using ContinentLandStadFotos.UWP.Pages;
using ContinentLandStadFotos.UWP.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace ContinentLandStadFotos.UWP.ViewModels
{
    public class ApplicationViewModel : ViewModeBaseClass
    {
        private PhotoOverviewPage _photoOverviewPage;
        private PhotoDetailPage _photoDetailPage;

        public ApplicationViewModel(PhotoOverviewPage photoOverviewPage, PhotoDetailPage photoDetailPage)
        {
            _photoOverviewPage = photoOverviewPage;
            _photoDetailPage = photoDetailPage;
            CurrentPage = IoCContainer.PhotoOverviewPage;
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
                OnPropertyChanged(nameof(CurrentPage));
            }
        }

        public void Navigate(Type navigationPageType)
        {
            if (navigationPageType.Equals(typeof(PhotoDetailPage)))
            {
                IoCContainer.PhotoDetailViewModel.Photo = IoCContainer.PhotoOverviewViewModel.SelectedPhoto;
                CurrentPage = _photoDetailPage;
            }
            else if (navigationPageType.Equals(typeof(PhotoOverviewPage)))
            {
                CurrentPage = _photoOverviewPage;
            }
        }
    }
}
