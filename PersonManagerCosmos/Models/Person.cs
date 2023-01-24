using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PersonManagerCosmos.Models
{
    public class Person
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [Required]
        [JsonProperty(PropertyName = "firstname")]
        public string FirstName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "lastname")]
        public string LastName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "nickname")]
        public string NickName { get; set; }

        [Required]
        [JsonProperty(PropertyName = "email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty(PropertyName = "phonenumber")]
        public string PhoneNumber { get; set; }

        [Required]
        [JsonProperty(PropertyName = "age")]
        public int Age { get; set; }

        [Required]
        [JsonProperty(PropertyName = "profession")]
        public string Profession { get; set; }
    }
}