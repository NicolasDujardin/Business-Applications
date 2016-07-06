using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZesDaagseGent.Data;
using ZesDaagseGent.Models;
using ZesDaagseGent.UWP.Helpers;
using ZesDaagseGent.UWP.Pages;
using ZesDaagseGent.UWP.Services;

namespace ZesDaagseGent.UWP.ViewModels
{
    public class DernysViewModel : ViewModelBaseClass
    {
        private IRepository<Cyclist> CyclistRepository { get; set; }
        private IRepository<Team> TeamRepository { get; set; }

        public DernysViewModel(IRepository<Cyclist> cyclistRepository, IRepository<Team> teamRepository)
        {
            CyclistRepository = cyclistRepository;
            TeamRepository = teamRepository;
        }

        private ObservableCollectionSorted<Team> _teams;
        public ObservableCollectionSorted<Team> Teams
        {
            get { return _teams; }
            set
            {
                if (_teams == value) return;
                _teams = value;
                OnPropertyChanged();
            }
        }

            private Team _selectedTeam;
            public Team SelectedTeam
            {
                get { return _selectedTeam; }
                set
                {
                    if (_selectedTeam == value) return;
                    _selectedTeam = value;
                    OnPropertyChanged();
                    OnPropertyChanged(nameof(IsDernisNextPointEnabled));
                }
            }

            private RelayCommand _dernysNextPointCMD;
            public RelayCommand DernysNextPoint
            {
                get
                {
                    return _dernysNextPointCMD ?? (_dernysNextPointCMD = new RelayCommand(
                  () => DernisNextPointToSelectedTeam()
                  ));
                }

            }
            public void ResetDernys() { _thisDernysNextPoint = 5; _ThisDernysTeamsWithPoints.Clear(); }
        private int _thisDernysNextPoint { get; set; } = 5;
        private List<Team> _ThisDernysTeamsWithPoints = new List<Team>();
        private void DernisNextPointToSelectedTeam()//per te geven dernys wedstrijd: 5 4 3 2 1, een team mag maar 1 keer punten krijgen
        {
            if (!IsDernisNextPointEnabled) return; //defensive programming: don't trust the ui
            SelectedTeam.AddPoint(_thisDernysNextPoint);
            _thisDernysNextPoint -= 1;
            _ThisDernysTeamsWithPoints.Add(SelectedTeam);

            OnPropertyChanged(nameof(IsDernisNextPointEnabled));
            if (_thisDernysNextPoint <= 0)  //sort teams and return to home page
            {
                Teams.Sort();
                IocContainer.ApplicationViewModel.Navigate(typeof(LandingPage));
            }

        }
        public Boolean IsDernisNextPointEnabled
        {
            get
            {
                if (SelectedTeam == null) return false;
                if (_ThisDernysTeamsWithPoints.Contains(SelectedTeam)) return false;
                if (_thisDernysNextPoint <= 0) return false;
                return true;
            }
        }
    }
}
