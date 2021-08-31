using System;
using System.Text.Json.Serialization;

namespace Travel.Entities.Entity
{
    public class User : EntityBase
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }
        public int Role { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Zone { get; set; }
        public string Province { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDisabled { get; set; }
    }
}
