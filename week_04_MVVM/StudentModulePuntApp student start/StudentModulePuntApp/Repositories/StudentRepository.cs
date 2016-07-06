using Newtonsoft.Json;
using StudentModulePuntApp.Helpers;
using StudentModulePuntApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentModulePuntApp.Repositories
{
    public class StudentRepository
    {
        public static async Task<List<Student>> VerzamelStudenten()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"http://localhost:56608/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("Student");
                if (response.IsSuccessStatusCode)
                {
                    String s = await response.Content.ReadAsStringAsync();
                    List<Student> resultaat = JsonConvert.DeserializeObject<List<Student>>(s);
                    //resultaat.Sort();
                    return resultaat;
                }
                else
                    return null;
            }
        }

    }
}
