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
    public class StudentModulePuntRepository 
    {
        public async static Task<List<StudentModulePunt>> VerzamelStudentStudentModulePunten(Student student)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"http://localhost:56608/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("StudentModulePunt/StudentStudentModulePunten?email=" + student.Email);
                
                if (response.IsSuccessStatusCode)
                {
                    String s = await response.Content.ReadAsStringAsync();
                    List<StudentModulePunt> studentsmps = JsonConvert.DeserializeObject<List<StudentModulePunt>>(s);
                    studentsmps.Sort(new StudentModulePuntPuntSorter());
                    studentsmps.Reverse();
                    return studentsmps;
                }
                else
                    return null;
            }
        }


        public async static Task<List<StudentModulePunt>> VerzamelEntries()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(@"http://localhost:56608/api/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(
                    new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("StudentModulePunt");
                if (response.IsSuccessStatusCode)
                {
                    String s = await response.Content.ReadAsStringAsync();
                    List<StudentModulePunt> entries = JsonConvert.DeserializeObject<List<StudentModulePunt>>(s);
                    entries.Sort();
                    return entries;
                    
                }
                else
                    return null;
            }
        }


    }
}
