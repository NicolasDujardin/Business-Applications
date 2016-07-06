using StudentModulePuntApp.Helpers;
using StudentModulePuntApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntApp.Repositories
{
    public class StudentRepository : INotifyPropertyChanged
    {
        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

        private static List<Student> _studs;
        public List<Student> StudentenLijst
        {
            get
            {
                if (_studs == null) VerzamelStudenten();
                return _studs;
            }
        }

        private async void VerzamelStudenten()
        {
            List<StudentModulePunt> smps = await StudentModulePuntRepository.Entries();
            _studs = Studenten(smps);
            OnPropertyChanged("StudentenLijst");
        }

        public static List<Student> Studenten(List<StudentModulePunt> smps)
        {
            return (from smp in smps
                    group smp by new Student { Email = smp.Email, GeboortePlaats = smp.GeboortePlaats } into emails
                    select emails.Key)
.ToList<Student>();
            //    return (from smp in smps
            //            group smp by new Student { Email = smp.Email, GeboortePlaats = smp.GeboortePlaats } into emails
            //            select new Student() { Email = emails.Key.Email, GeboortePlaats = emails.Key.GeboortePlaats })
            //.ToList<Student>();
            //return (from smp in smps
            //        group smp by new { smp.Email, smp.GeboortePlaats } into emails
            //        select new Student() { Email = emails.Key.Email, GeboortePlaats = emails.Key.GeboortePlaats })
            //        .ToList<Student>();
            //return (from smp in smps
            //        group smp by smp.Email into emails
            //        select new Student() { Email = emails.Key, GeboortePlaats = emails.First().GeboortePlaats })
            //        .ToList<Student>();
        }
    }
}
