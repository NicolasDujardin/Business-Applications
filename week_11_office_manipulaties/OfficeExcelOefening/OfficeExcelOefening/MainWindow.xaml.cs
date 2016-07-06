using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using OpenXMLDemo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OfficeExcelOefening
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        List<Cyclist> _cyclists = new List<Cyclist>();
        List<Team> _teams = new List<Team>();
        string doc = "C:\\Users\\Nicolas\\Documents\\NMCT\\2NMCT\\Semester 1\\Examen BA\\week_11_office_manipulaties\\Teams.xlsx";
        public MainWindow()
        {
            InitializeComponent();
            FillCyclists();
            FillTeams(_cyclists);
            uint i = 1;
            foreach(Team team in _teams)
            {
                string text = team.Cyclist1.FirstName + " " + team.Cyclist1.LastName + " - " + team.Cyclist2.FirstName + " " + team.Cyclist2.LastName;
                OpenXMLExcel.XLInsertText(doc, "Blad1","A",i, text);
                i += 1;
            }
            
        }

        

        private void FillTeams(List<Cyclist> _cyclists)
        {
            foreach(Cyclist c in _cyclists)
            {
                var teams = _teams.Find(x => x.Cyclist1.Sponsor.Equals(c.Sponsor));
                if(teams == null)
                {
                    string sponsor = c.Sponsor;
                    for (int i = 1; i < _cyclists.Count; i++)
                    {
                        if (_cyclists[i].Sponsor == sponsor)
                        {

                            Team team = new Team();
                            team.Cyclist1 = c;
                            team.Cyclist2 = _cyclists[i];
                            _teams.Add(team);
                        }
                    }
                }
            }      
        }
        private void FillCyclists()
        {
            _cyclists.Add(new Cyclist() { ID = 0, FirstName = "Jasper", LastName = "De Buyst", Sponsor = "Lotto", Nationality = "BEL" });
            _cyclists.Add(new Cyclist() { ID = 1, FirstName = "Otto", LastName = "Vergaerde", Sponsor = "Lotto", Nationality = "BEL" });
            _cyclists.Add(new Cyclist() { ID = 2, FirstName = "Kenny", LastName = "De Ketele", Sponsor = "Baloise Insurance", Nationality = "BEL" });
            _cyclists.Add(new Cyclist() { ID = 3, FirstName = "Gijs", LastName = "Van Hoecke", Sponsor = "Baloise Insurance", Nationality = "BEL" });
            _cyclists.Add(new Cyclist() { ID = 4, FirstName = "Yoeri", LastName = "Havik", Sponsor = "3M", Nationality = "NED" });
            _cyclists.Add(new Cyclist() { ID = 5, FirstName = "Melvin", LastName = "Van Zijl", Sponsor = "3M", Nationality = "NED" });
            _cyclists.Add(new Cyclist() { ID = 6, FirstName = "Iljo", LastName = "Keisse", Sponsor = "Etixx-QuickStep", Nationality = "BEL" });
            _cyclists.Add(new Cyclist() { ID = 7, FirstName = "Michael", LastName = "Morkov", Sponsor = "Etixx-QuickStep", Nationality = "DEN" });
            _cyclists.Add(new Cyclist() { ID = 8, FirstName = "Alex", LastName = "Rasmussen", Sponsor = "John Saey - Lecot-Raedschelders", Nationality = "DEN" });
            _cyclists.Add(new Cyclist() { ID = 9, FirstName = "Marc", LastName = "Hester", Sponsor = "John Saey - Lecot-Raedschelders", Nationality = "DEN" });
            _cyclists.Add(new Cyclist() { ID = 10, FirstName = "Andreas", LastName = "Muller", Sponsor = "Topsport Vlaanderen", Nationality = "GER" });
            _cyclists.Add(new Cyclist() { ID = 11, FirstName = "Stijn", LastName = "Beels", Sponsor = "Topsport Vlaanderen", Nationality = "BEL" });
            _cyclists.Add(new Cyclist() { ID = 12, FirstName = "Marcel", LastName = "Kalz", Sponsor = "Primus Haacht", Nationality = "GER" });
            _cyclists.Add(new Cyclist() { ID = 13, FirstName = "Christian", LastName = "Grasmann", Sponsor = "Primus Haacht", Nationality = "GER" });
            _cyclists.Add(new Cyclist() { ID = 14, FirstName = "Morgan", LastName = "Kneisky", Sponsor = "Provincy Oost-Vlaanderen", Nationality = "FRA" });
            _cyclists.Add(new Cyclist() { ID = 15, FirstName = "Moreno", LastName = "De Pauw", Sponsor = "Provincy Oost-Vlaanderen", Nationality = "BEL" });
            _cyclists.Add(new Cyclist() { ID = 16, FirstName = "Tristan", LastName = "Marguet", Sponsor = "Callant - Upgrade Estate", Nationality = "SUI" });
            _cyclists.Add(new Cyclist() { ID = 17, FirstName = "Benjamin", LastName = "Thomas", Sponsor = "Callant - Upgrade Estate", Nationality = "FRA" });
            _cyclists.Add(new Cyclist() { ID = 18, FirstName = "Lindsay", LastName = "De Vylder", Sponsor = "T-interim", Nationality = "BEL" });
            _cyclists.Add(new Cyclist() { ID = 19, FirstName = "David", LastName = "Muntaner", Sponsor = "T-interim", Nationality = "ESP" });
            _cyclists.Add(new Cyclist() { ID = 20, FirstName = "Roy", LastName = "Pieters", Sponsor = "Vanresule Snacks", Nationality = "NED" });
            _cyclists.Add(new Cyclist() { ID = 21, FirstName = "Christopher", LastName = "Lawless", Sponsor = "Vanresule Snacks", Nationality = "GBR" });
            _cyclists.Add(new Cyclist() { ID = 22, FirstName = "Nick", LastName = "Stöpler", Sponsor = "Caruur", Nationality = "NED" });
            _cyclists.Add(new Cyclist() { ID = 23, FirstName = "Jesper", LastName = "Morkov", Sponsor = "Caruur", Nationality = "DEN" });
        }
    }
}
