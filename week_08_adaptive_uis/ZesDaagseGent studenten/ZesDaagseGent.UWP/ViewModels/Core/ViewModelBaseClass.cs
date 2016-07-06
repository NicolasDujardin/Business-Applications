using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ZesDaagseGent.UWP.ViewModels
{
    public class ViewModelBaseClass : INotifyPropertyChanged
    {
        #region "propertychanged"
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}