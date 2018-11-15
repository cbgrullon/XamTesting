using App3.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace App3.Services
{
    public class JsonPlaceHolderService
    {
        HttpClient httpClient = null;
        public JsonPlaceHolderService()
        {
            httpClient = new HttpClient() {
                BaseAddress=new Uri("https://jsonplaceholder.typicode.com/")
            };
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<List<User>> GetUsersAsync()
        {
            List<User> _result = new List<User>();

            var response = await httpClient.GetAsync("users");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                if (!string.IsNullOrEmpty(json))
                {
                    _result = JsonConvert.DeserializeObject<List<User>>(json);
                }
            }
            return _result;
        }
    }
}
