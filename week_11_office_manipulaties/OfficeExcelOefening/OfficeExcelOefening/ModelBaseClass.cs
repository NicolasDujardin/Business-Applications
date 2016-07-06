using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace OfficeExcelOefening
{
    public class ModelBaseClass : INotifyPropertyChanged
    {
        public int ID { get; set; }

        #region "propertychanged"
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}