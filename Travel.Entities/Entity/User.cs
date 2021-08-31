using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Travel.Entities.Entity
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string Password { get; set; }
        [JsonIgnore]
        public string Salt { get; set; }
        public int Role { get; set; }
        public string Address { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime ModifiedOn { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsDisabled { get; set; }
    }
}
