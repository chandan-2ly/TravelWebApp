using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Travel.Entities.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }
    }
}
