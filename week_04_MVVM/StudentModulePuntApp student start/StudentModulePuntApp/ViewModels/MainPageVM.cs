using StudentModulePuntApp.Models;
using StudentModulePuntApp.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntApp.ViewModels
{
    public class MainPageVM : INotifyPropertyChanged
    {
        private List<Student> _studenten;
        public List<Student> Studenten
        {
            get
            {
                if (_studenten == null) VerzamelStudenten();
                return _studenten;
            }
        }

        public async Task VerzamelStudenten()
        {
            _studenten = await StudentRepository.VerzamelStudenten();
            OnPropertyChanged("Studenten");
        }

        private Student _geselecteerdeStudent;
        public Student GeselecteerdeStudent
        {
            get { return _geselecteerdeStudent; }
            set
            {
                if (_geselecteerdeStudent == value) return;
                _geselecteerdeStudent = value;
                OnPropertyChanged("GeselecteerdeStudent");
                VerzamelStudentModules(GeselecteerdeStudent);
            }
        }

        public List<StudentModulePunt> GeselecteerdeStudentModules { get; set; }

        private async void VerzamelStudentModules(Student stud)
        {
            GeselecteerdeStudentModules = await StudentModulePuntRepository.VerzamelStudentStudentModulePunten(stud);
            OnPropertyChanged("GeselecteerdeStudentModules");
        }


        private StudentModulePunt _geselecteerdeModule;
        public StudentModulePunt GeselecteerdeModule
        {
            get { return _geselecteerdeModule; }
            set
            {
                if (_geselecteerdeModule == value) return;
                _geselecteerdeModule = value;
                OnPropertyChanged();
                VerzamelGeselecteerdeModuleStatistiek();
            }
        }

        public ModuleStatistiek GeselecteerdeModuleStatistiek { get; set; }
        private void VerzamelGeselecteerdeModuleStatistiek()
        {
            if (GeselecteerdeModule == null)
                GeselecteerdeModuleStatistiek = null;
            else
                GeselecteerdeModuleStatistiek = ModuleStatistiekRepository.ModuleStatistiek(GeselecteerdeStudentModules,GeselecteerdeModule.Module);
            OnPropertyChanged("GeselecteerdeModuleStatistiek");
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
