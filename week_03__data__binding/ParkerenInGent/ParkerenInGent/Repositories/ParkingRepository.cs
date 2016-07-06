using Newtonsoft.Json;
using ParkerenInGent.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ParkerenInGent.Repositories
{
    public class ParkingRepository : INotifyPropertyChanged
    {
        static string url = Application.Current.Resources["parkingUrl"] as string;

        private static List<Parking> _parkings;
        public List<Parking> Parkings
        {
            get
            {
                if (_parkings == null) VerzamelParkings();
                return _parkings;
            }
        }

        private async void VerzamelParkings()
        {
            List<Parking> parkings = await Entries();
            _parkings = parkings;
            OnPropertyChanged("Parkings");
        }

        #region Ophalen Data
        public async static Task<List<Parking>> Entries()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("");
                if (response.IsSuccessStatusCode)
                {
                    String s = await response.Content.ReadAsStringAsync();
                    List<Parking> resultaat = JsonConvert.DeserializeObject<List<Parking>>(s);
                    //resultaat.Sort();
                    return resultaat;
                }
                else
                    return null;
            }
        }
        #endregion

        #region INPC
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}
