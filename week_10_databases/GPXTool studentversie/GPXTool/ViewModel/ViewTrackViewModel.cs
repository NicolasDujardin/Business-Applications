using GalaSoft.MvvmLight.Command;
using GPXTool.Data;
using GPXTool.Models;
using GPXTool.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GPXTool.ViewModel
{
    public class ViewTrackViewModel : ViewModelBaseClass
    {
        private ObservableCollection<Trk> _trks;
        public ObservableCollection<Trk> Trks
        {
            get
            {
                if (null == _trks) CollectTrks();
                return _trks;
            }
        }
        private void CollectTrks()
        {
            _trks = IocContainer.TrkRepository.AllTrk;
            OnPropertyChanged(nameof(Trks));
        }

        private Trk _selectedTrk;
        public Trk SelectedTrk
        {
            get { return _selectedTrk; }
            set
            {
                if (_selectedTrk == value) return;
                _selectedTrk = value;
                OnPropertyChanged();
            }
        }



        private RelayCommand _showTrackCMD;
        public RelayCommand ShowTrackCMD
        {
            get {
                return _showTrackCMD ?? (_showTrackCMD = new RelayCommand(
              () => ShowTrack()
              ));
            }
        }
        private void ShowTrack()
        {
            ObservableCollection<TrkPt> pts = SelectedTrk.TrkPts;
        }
    }
}
