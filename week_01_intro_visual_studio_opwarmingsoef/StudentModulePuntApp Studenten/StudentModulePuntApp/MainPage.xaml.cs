using StudentModulePuntApp.Models;
using StudentModulePuntApp.Repositories;
using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using System;
using System.Linq;
using StudentModulePuntApp.Controls;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace StudentModulePuntApp
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<StudentModulePunt> Punten;
        List<StudentModulePunt> GeselecteerdeStudent;
        List<Student> Studenten;

        public MainPage()
        {
            this.InitializeComponent();
        }

        async void Page_Loaded(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {
            Punten = await StudentModulePuntRepository.Entries();
            Studenten = (from smp in Punten
                         group smp by new Student { Email = smp.Email, GeboortePlaats = smp.GeboortePlaats } into emails
                         select emails.Key).ToList<Student>();

            foreach(Student s in Studenten)
            {
                ctlStudent ctl = new ctlStudent();
                ctl.ToonStudent(s);
                cboStudenten.Items.Add(ctl);

            }
            if (cboStudenten.Items.Count > 0)
                cboStudenten.SelectedIndex = cboStudenten.Items.Count / 2;
            //cboStudenten.ItemsSource = DistileerEmails(Punten);
        }

        public static List<string> DistileerEmails(List<StudentModulePunt> lijst)
        {
            

            List<string> emails = new List<string>();
            foreach (StudentModulePunt p in lijst)
                VoegEmailToeIndienNogNietAanwezig(p.Email, emails);

            return emails;
        }

        private static void VoegEmailToeIndienNogNietAanwezig(string email, List<string> emails)
        {
            if (!emails.Contains(email)) emails.Add(email);
        }

        public static List<StudentModulePunt> StudentMetEmail(string email, List<StudentModulePunt> lijst)
        {
            List<StudentModulePunt> resultaat = new List<StudentModulePunt>();
            foreach (StudentModulePunt smp in (from s in lijst where s.Email.Equals(email) select s))
                resultaat.Add(smp);
            //foreach (StudentModulePunt p in lijst)
            //    AppendIndienGepasteEmail(email, p, resultaat);

            return resultaat;
        }

        private static void AppendIndienGepasteEmail(string email, StudentModulePunt p, List<StudentModulePunt> resultaat)
        {
            if (p.Email.Equals(email, StringComparison.CurrentCultureIgnoreCase))
                resultaat.Add(p);
        }

        private void cboStudenten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //lstPunten.Items.Clear();
            //GeselecteerdeStudent = StudentMetEmail((string)cboStudenten.SelectedItem, Punten);
            //foreach (StudentModulePunt p in GeselecteerdeStudent)
            //    lstPunten.Items.Add(p);
        }

        private void lstPunten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ToonModuleStats((lstPunten.SelectedItem)as StudentModulePunt);
        }

        private void ToonModuleStats(StudentModulePunt selectedItem)
        {
            ModuleStatistiek ms = ModuleStatistiekRepository.ModuleStatistiek(Punten, selectedItem.Module);
            txbGemiddelde.Text = "Gemiddeld: " + ms.Gemiddelde.ToString("#0.00");
            txbMaximum.Text = "Maximum : " + ms.Maximum.ToString("#0.00");
            txbAantal.Text = "Aantal : " + ms.Aantal;
        }
    }
}
