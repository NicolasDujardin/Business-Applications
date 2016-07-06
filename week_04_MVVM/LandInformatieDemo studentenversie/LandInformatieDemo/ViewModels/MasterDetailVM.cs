using LandInformatieDemo.Models;
using LandInformatieDemo.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LandInformatieDemo.ViewModels
{
    public class MasterDetailVM : INotifyPropertyChanged
    {
        public List<LandInfo> Landen { get { return LandInfoRepository.Landen; } }

        private LandInfo _selectedLandInfo;
        public LandInfo SelectedLandInfo
        {
            get { return _selectedLandInfo; }
            set
            {
                if (value == _selectedLandInfo) return;
                _selectedLandInfo = value;
                OnPropertyChanged();
            }
        }
        #region "property changed"
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
