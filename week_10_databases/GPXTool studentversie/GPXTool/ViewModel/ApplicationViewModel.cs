using GalaSoft.MvvmLight.Command;
using GPXTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace GPXTool.ViewModel
{
    public class ApplicationViewModel : ViewModelBaseClass
    {
        public ApplicationViewModel()
        {
            CurrentPage = IocContainer.NewTrackPage;
        }
        private Page _currentPage;
        public Page CurrentPage
        {
            get { return _currentPage; }
            set
            {
                if (_currentPage == value) return;
                _currentPage = value;
                OnPropertyChanged();
            }
        }


        private RelayCommand _newTrackCMD;
        public RelayCommand NewTrackCMD
        {
            get {
                return _newTrackCMD ?? (_newTrackCMD = new RelayCommand(
              () => ToNewTrack()
              ));
            }
        }
        private void ToNewTrack()
        {
            CurrentPage = IocContainer.NewTrackPage;
        }

        private RelayCommand _viewTrackCMD;
        public RelayCommand ViewTrackCMD
        {
            get
            {
                return _viewTrackCMD ?? (_viewTrackCMD = new RelayCommand(
              () => ToViewTrack()
              ));
            }
        }
        private void ToViewTrack()
        {
            CurrentPage = IocContainer.ViewTrackPage;
        }
    }
}
