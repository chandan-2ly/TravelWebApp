using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using Travel.Core.Model;

namespace Travel.Core.BusinessModels
{
    public class AuthenticateResponse : ResponseModel
    {
        public IEnumerable<dynamic> ErrorList { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        [JsonIgnore]
        public string Token { get; set; }
        public Guid UserId { get; set; }
    }
}
