using GalaSoft.MvvmLight.Command;
using GPXTool.Data;
using GPXTool.Models;
using GPXTool.Repositories;
using GPXTool.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.Storage.Pickers;

namespace GPXTool.ViewModel
{
    public class NewTrackViewModel : ViewModelBaseClass
    {
        private RelayCommand _newTrackCMD;
        public RelayCommand NewTrackCMD
        {
            get
            {
                return _newTrackCMD ?? (_newTrackCMD = new RelayCommand(
              () => NewTrack()
              ));
            }
        }
        private void NewTrack()
        {
            Trk trk = new Trk();
            TrkRepository repo = new TrkRepository();
            trk.Title = "Trk test";
            trk.Tijdstip = DateTime.Now;
            repo.SaveTrk(trk);

            Tracker tracker = new Tracker();
            tracker.CurrentTrk = trk;
            tracker._isStarted = true;
            
        }
    }
}
