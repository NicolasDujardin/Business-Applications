using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZesDaagseGent.Models;

namespace ZesDaagseGent.Data
{
    public class CyclistRepository : RepositoryBaseClass<Cyclist>
    {
        public override string ApiUrl { get { return "dummy, not using webservices"; } set { } }

        private static object _staticctorlock = new object();
        static CyclistRepository()
        {
            lock (_staticctorlock)
            {
                FillCyclists();
            }
        }

        public override void Add(Cyclist newObject)
        {
            throw new NotImplementedException();
        }

        private static List<Cyclist> _cyclists;
        internal static List<Cyclist> CyclistsInternalUseOnly { get { return _cyclists; } }
        public async override Task<List<Cyclist>> Get()
        {
            return _cyclists;
        }

        private static void FillCyclists()
        {
            _cyclists = new List<Cyclist>();

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
