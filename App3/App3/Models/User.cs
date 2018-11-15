using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace App3.Models
{
    public class User
    {
        [JsonProperty("name")]
        public string Name { get; set; }


        [JsonProperty("username")]
        public string Username { get; set; }


        [JsonProperty("email")]
        public string Email { get; set; }
    }
}
