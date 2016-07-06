using ContinentLandStadFotos.Models.Flickr;
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
    public class PhotoDetailViewModel : ViewModeBaseClass, IPhotoDetailViewModel
    {
        public PhotoDetailViewModel()
        {
            BackCMD = new RelayCommand<object>(o => Back());
        }

        private Photo _photo;
        public Photo Photo
        {
            get
            {
                return _photo;
            }
            set
            {
                if (value == _photo) return;
                _photo = value;
                OnPropertyChanged(nameof(Photo));
            }
        }

        public RelayCommand<object> BackCMD { get; private set; }

        private void Back()
        {
            IoCContainer.ApplicationViewModel.Navigate(typeof(PhotoOverviewPage));
        }
    }
}
