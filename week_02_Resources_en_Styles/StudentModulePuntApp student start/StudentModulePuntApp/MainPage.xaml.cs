using StudentModulePuntApp.Controls;
using StudentModulePuntApp.Helpers;
using StudentModulePuntApp.Models;
using StudentModulePuntApp.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StudentModulePuntApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<StudentModulePunt> _smps;
        private List<Student> _studs;
        public MainPage()
        {
            this.InitializeComponent();
            this.Loaded += MainPage_Loaded;
            cboStudenten.SelectionChanged += CboStudenten_SelectionChanged;
            ctlsmps.ListBoxModulePunten.SelectionChanged += ListBoxModulePunten_SelectionChanged;
        }

        private void ListBoxModulePunten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //JDB los dit eens op als je tijd hebt
            ToonModuleStats((sender as ListBox).SelectedItem as ctlStudentModulePunt);
        }
        private void ToonModuleStats(ctlStudentModulePunt ctl)
        {
            txbNaam.Text = txbGemiddelde.Text = txbMaximum.Text = "";
            if (ctl == null) return;    //nieuwe student gekozen
            ModuleStatistiek ms = ModuleStatistiekRepository.ModuleStatistiek(_smps, ctl.SMP.Module);
            txbNaam.Text = ms.ModuleNaam;
            txbGemiddelde.Text = "Gemiddeld: " + ms.Gemiddelde.ToString("#0.00");
            txbMaximum.Text = "Maximium: " + ms.Maximum.ToString("#0.00");
        }

        private void CboStudenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToonModules((cboStudenten.SelectedItem as ctlStudent).GetoondeStudent);
        }

        private void ToonModules(Student student)
        {
            List<StudentModulePunt> smps = StudentModulePuntRepository.StudentModulePuntVoorStudent(student,_smps);
            ctlsmps.ToonStudentModulePunten(smps);
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await InitInfo();
        }

        private async Task InitInfo()
        {
            //JDA dit is uw code, los het op
            _smps = await StudentModulePuntRepository.Entries();
            _studs = StudentRepository.Studenten(_smps);
            cboStudenten.Items.Clear();
            foreach (Student s in _studs)
            {                
                ctlStudent ctl = new ctlStudent();
                ctl.ToonStudent(s);
                cboStudenten.Items.Add(ctl);
            }
            if (cboStudenten.Items.Count > 0)
                cboStudenten.SelectedIndex = cboStudenten.Items.Count / 2;
        }
    }
}
