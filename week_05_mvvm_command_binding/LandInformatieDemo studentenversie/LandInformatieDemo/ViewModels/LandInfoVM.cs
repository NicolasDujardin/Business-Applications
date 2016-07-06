using GalaSoft.MvvmLight.Command;
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
    public class LandInfoVM : INotifyPropertyChanged
    {
        public INestedPropertyChangedListener OnNestedPropertyChangedListener { get; set; }
        public FilteringVM FilteringVM { get; set; }
        public LandInfo LandInfo { get; set; }
        public LandInfoVM(LandInfo landInfo)
        {
            LandInfo = landInfo;
        }

        public string LandNaam
        {
            get { return LandInfo.LandNaam; }
            set
            {
                if (value.Equals(LandNaam)) return;
                LandInfo.LandNaam = value;
                OnPropertyChanged();
            }
        }

        public String VlagURL
        {
            get { return LandInfo.VlagURL; }
            set
            {
                if (value.Equals(VlagURL)) return;
                LandInfo.VlagURL = value;
                OnPropertyChanged();
            }
        }

        public Boolean IsEuropees
        {
            get { return LandInfo.IsEuropees; }
            set
            {
                if (IsEuropees == value) return;
                LandInfo.IsEuropees = value;
                OnPropertyChanged();
                
                if(OnNestedPropertyChangedListener != null)
                    OnNestedPropertyChangedListener.OnNestedPropertyChanged("GefilterdeLijst");
            }
        }

        public RelayCommand<object> Delete
        {
            get
            {
                return new RelayCommand<object>((o) => DeleteMij(o));
            }
        }

        private void DeleteMij(object o)
        {
            LandInfoRepository.DeleteLandInfo(LandInfo);
            if (OnNestedPropertyChangedListener != null)
                OnNestedPropertyChangedListener.OnNestedPropertyChanged("GefilterdeLijst");
        }

        #region "property changed"
        public event PropertyChangedEventHandler PropertyChanged;
        public virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
