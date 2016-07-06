using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ContinentLandStadFotos.Data
{
    public abstract class RepositoryRestBaseClass<T>
    {
        public abstract String ApiUrl { get; }
        public abstract String Controller { get; }

        public async Task<List<T>> Get()
        {
            return await GetRESTPRM("");
        }

        public async Task<List<T>> GetRESTPRM(String urlprm)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(ApiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync(Controller + urlprm);
                if (response.IsSuccessStatusCode)
                {
                    String s = await response.Content.ReadAsStringAsync();
                    List<T> resultaat = JsonConvert.DeserializeObject<List<T>>(s);
                    return resultaat;
                }
                else
                    return null;
            }
        }
    }
}
