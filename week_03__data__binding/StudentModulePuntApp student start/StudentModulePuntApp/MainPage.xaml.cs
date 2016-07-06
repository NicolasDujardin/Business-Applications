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
            lstStudentModulePunten.SelectionChanged += LstStudentModulePunten_SelectionChanged;
        }

        private void LstStudentModulePunten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToonModuleStats((StudentModulePunt)lstStudentModulePunten.SelectedItem);
        }

        private void ToonModuleStats(StudentModulePunt Module)
        {
            txbNaam.Text = txbGemiddelde.Text = txbMaximum.Text = "";
            if (Module == null) return;    //nieuwe student gekozen
            ModuleStatistiek ms = ModuleStatistiekRepository.ModuleStatistiek(_smps, Module.Module);
            txbNaam.Text = ms.ModuleNaam;
            txbGemiddelde.Text = "Gemiddeld: " + ms.Gemiddelde.ToString("#0.00");
            txbMaximum.Text = "Maximium: " + ms.Maximum.ToString("#0.00");
        }

        private void CboStudenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToonModules((Student)cboStudenten.SelectedItem);
        }

        private void ToonModules(Student student)
        {
            List<StudentModulePunt> smps = StudentModulePuntRepository.StudentModulePuntVoorStudent(student,_smps);
            lstStudentModulePunten.ItemsSource = smps;
        }

        private async void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            await InitInfo();
        }

        private async Task InitInfo()
        {
            //JDA dit is uw code, los het op
            _smps = await StudentModulePuntRepository.Entries();
        }
    }
}
