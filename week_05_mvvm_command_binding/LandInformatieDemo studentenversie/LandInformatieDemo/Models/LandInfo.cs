using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LandInformatieDemo.Models
{
    //    public class LandInfo
    //    {
    //        public String LandNaam { get; set; }
    //        public String VlagURL { get; set; }
    //        private Boolean _isEuropees;
    //        public Boolean IsEuropees
    //        {
    //            get { return _isEuropees; }
    //            set
    //            {
    //                if (value == _isEuropees) return;   //geen wijziging
    //                _isEuropees = value;
    //            }
    //        }

    //        public override string ToString()
    //        {
    //            return LandNaam + " (Europees: " + IsEuropees + ")";
    //        }
    //    }
    //}


    public class LandInfo : INotifyPropertyChanged
    {
        private String _landNaam;
        public String LandNaam
        {
            get { return _landNaam; }
            set { if (value.Equals(_landNaam)) return ;
                _landNaam = value;
                OnPropertyChanged();
            }
        }
        public String VlagURL { get; set; }
        private Boolean _isEuropees;
        public Boolean IsEuropees
        {
            get { return _isEuropees; }
            set
            {
                if (value == _isEuropees) return;   //geen wijziging
                _isEuropees = value;
                OnPropertyChanged();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
