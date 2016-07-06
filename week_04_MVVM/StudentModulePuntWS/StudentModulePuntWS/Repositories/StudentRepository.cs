using StudentModulePuntWS.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntWS.Repositories
{
    public class StudentRepository : INotifyPropertyChanged
    {
        public static List<Student> MaakStudenten(List<StudentModulePunt> smps)
        {
            return (from smp in smps
                    group smp by new Student { Email = smp.Email, GeboortePlaats = smp.GeboortePlaats } into emails
                    select emails.Key).ToList<Student>();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChangedEvent([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        private static List<Student> _studs;
        public List<Student> StudentenLijst
        {
            get
            {
                if (_studs == null) VerzamelStudenten();
                return _studs;
            }
        }
        private void VerzamelStudenten()
        {
            List<StudentModulePunt> smps = StudentModulePuntRepository.Entries;
            _studs = MaakStudenten(smps);
            OnPropertyChangedEvent("StudentenLijst");
        }
    }
}
