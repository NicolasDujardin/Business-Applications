using Newtonsoft.Json;
using ParkerenInGent.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace ParkerenInGent.Repositories
{
    public class ParkingRepository
    {
        static string url = Application.Current.Resources["parkingUrl"] as string;
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
    }
}
