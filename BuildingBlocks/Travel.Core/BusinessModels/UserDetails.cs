using System;

namespace Travel.Core.BusinessModels
{
    public class UserDetails
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string ContactNo { get; set; }
        public string Email { get; set; }
        public int Role { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Zone { get; set; }
        public string Province { get; set; }
    }
}
