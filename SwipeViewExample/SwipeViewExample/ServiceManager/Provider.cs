using Newtonsoft.Json;
using SwipeViewExample.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SwipeViewExample.ServiceManager
{
    public class Provider
    {
        public async Task<Person> GetPersons()
        {
            var client = new HttpClient();

            return JsonConvert.DeserializeObject<Person>(await client.GetStringAsync("https://randomuser.me/api/?results=20")); 
        }
    }
}
