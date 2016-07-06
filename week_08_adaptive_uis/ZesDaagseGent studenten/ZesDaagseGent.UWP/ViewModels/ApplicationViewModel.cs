using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using ZesDaagseGent.UWP.Pages;
using ZesDaagseGent.UWP.Services;

namespace ZesDaagseGent.UWP.ViewModels
{
    public class ApplicationViewModel : ViewModelBaseClass
    {
        private CreateTeamPage _createTeamPage;
        private DernysPage _dernysPage;
        private LandingPage _landingPage;
        private EditCyclistPage _editCyclistPage;
        public ApplicationViewModel(CreateTeamPage createTeamPage, DernysPage dernysPage, LandingPage landingPage, EditCyclistPage editCyclistPage)
        {
            _createTeamPage = createTeamPage;
            _dernysPage = dernysPage;
            _landingPage = landingPage;
            _editCyclistPage = editCyclistPage;
            Navigate(typeof(LandingPage));
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
        public void Navigate(Type navigationPageType)
        {
            if (navigationPageType.Equals(typeof(LandingPage)))
                CurrentPage = _landingPage;
            if (navigationPageType.Equals(typeof(EditCyclistPage)))
                CurrentPage = _editCyclistPage;
            if (navigationPageType.Equals(typeof(CreateTeamPage)))
                CurrentPage = (Page)_createTeamPage;
            else if (navigationPageType.Equals(typeof(DernysPage)))
            {
                //we suppose the teams have been made 
                IocContainer.DernysViewModel.Teams = IocContainer.CreateTeamViewModel.Teams;
                IocContainer.DernysViewModel.ResetDernys();
                CurrentPage = _dernysPage;
            }
        }

        #region tocreateteam
        private RelayCommand _toCreateTeamCMD;
        public RelayCommand ToCreateTeamCMD
        {
            get
            {
                return _toCreateTeamCMD ?? (_toCreateTeamCMD = new RelayCommand(
                  () => ToCreateTeam()

                  ));
            }
        }
        private void ToCreateTeam()
        {
            IocContainer.ApplicationViewModel.Navigate(typeof(CreateTeamPage));
        }
        #endregion
        #region todernys
        private RelayCommand _toDernysCMD;
        public RelayCommand ToDernysCMD
        {
            get
            {
                return _toDernysCMD ?? (_toDernysCMD = new RelayCommand(
                  () => ToDernys()

                  ));
            }
        }
        private void ToDernys()
        {
            IocContainer.ApplicationViewModel.Navigate(typeof(DernysPage));
        }
        #endregion
        #region tohome
        private RelayCommand _toHomeCMD;
        public RelayCommand ToHomeCMD
        {
            get
            {
                return _toHomeCMD ?? (_toHomeCMD = new RelayCommand(
                  () => ToHome()

                  ));
            }
        }
        private void ToHome()
        {
            IocContainer.ApplicationViewModel.Navigate(typeof(LandingPage));
        }
        #endregion
        #region tohome
        private RelayCommand _toEditCyclistCMD;
        public RelayCommand ToEditCyclistCMD
        {
            get
            {
                return _toEditCyclistCMD ?? (_toEditCyclistCMD = new RelayCommand(
                  () => ToEditCyclist()

                  ));
            }
        }
        private void ToEditCyclist()
        {
            IocContainer.ApplicationViewModel.Navigate(typeof(EditCyclistPage));
        }
        #endregion
    }
}
