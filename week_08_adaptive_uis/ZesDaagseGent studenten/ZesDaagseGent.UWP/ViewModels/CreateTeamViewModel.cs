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
    public class CreateTeamViewModel : ModelBaseClass
    {
        private IRepository<Cyclist> CyclistRepository { get; set; }
        private IRepository<Team> TeamRepository { get; set; }


        public CreateTeamViewModel(IRepository<Cyclist> cyclistRepository, IRepository<Team> teamRepository)
        {
            CyclistRepository = cyclistRepository;
            TeamRepository = teamRepository;
        }

        private ObservableCollectionSorted<Team> _teams;
        public ObservableCollectionSorted<Team> Teams
        {
            get
            {
                if (_teams == null) CollectTeams();
                return _teams;
            }
        }
        private async void CollectTeams()
        {
                List<Team> ts = await TeamRepository.Get();
                _teams = new ObservableCollectionSorted<Team>(ts);

            OnPropertyChanged(nameof(Teams));
            OnPropertyChanged(nameof(UnteamedCyclists));
        }
        private ObservableCollection<Cyclist> _cyclists;
        public ObservableCollection<Cyclist> Cyclists
        {
            get
            {
                if (_cyclists == null) CollectCyclists();
                return _cyclists;
            }
        }

        private async void CollectCyclists()
        {
            List<Cyclist> cs = await CyclistRepository.Get();
            _cyclists = new ObservableCollection<Cyclist>(cs);
            OnPropertyChanged(nameof(Cyclists));
            OnPropertyChanged(nameof(UnteamedCyclists));
        }

        public ObservableCollection<Cyclist> UnteamedCyclists
        {
            get
            {
                if (_cyclists == null) CollectCyclists();
                if (_teams == null) CollectTeams();
                if (Cyclists == null || Teams == null) return null;
                List<Cyclist> cs = _cyclists.Where(c => !(Teams.Select(t => t.Cyclist1).Contains(c)
                    || Teams.Select(t => t.Cyclist2).Contains(c))
                ).ToList<Cyclist>();
                ObservableCollection<Cyclist> utc = new ObservableCollection<Cyclist>(cs);
                return utc;
            }
        }

        #region "creating teams"
        public Boolean IsValidTeamChoice
        {
            get
            {
                if (Cyclist1 == Cyclist2) return false;
                if (Cyclist1?.Sponsor == null) return false;
                return (Cyclist1?.Sponsor.Equals(Cyclist2?.Sponsor)).Value;
            }
        }

        private Cyclist _cyclist1;
        public Cyclist Cyclist1
        {
            get { return _cyclist1; }
            set
            {
                if (value == Cyclist1) return;
                _cyclist1 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsValidTeamChoice));
            }
        }
        private Cyclist _cyclist2;
        public Cyclist Cyclist2
        {
            get { return _cyclist2; }
            set
            {
                if (value == Cyclist2) return;
                _cyclist2 = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(IsValidTeamChoice));
            }
        }

        private RelayCommand _createTeamCMD;
        public RelayCommand CreateTeamCMD
        {
            get
            {
                return _createTeamCMD ?? (_createTeamCMD = new RelayCommand(
              () => CreateTeam()
              ));
            }
        }
        private void CreateTeam()
        {
            //defensive: those conditions shouldn't occur
            if (Cyclist1 == null) return;
            if (Cyclist2 == null) return;
            if (!Cyclist1.Sponsor.Equals(Cyclist2.Sponsor)) return;

            Team newT = new Team() { Cyclist1 = this.Cyclist1, Cyclist2 = this.Cyclist2 };
            TeamRepository.Add(newT);
            CollectTeams(); //triggers UnteamedCyclists as well
        }
        #endregion

    }
}
