using System;

namespace Travel.Entities.Entity
{
    public class Driver : EntityBase
    {
        public Guid Id { get; set; }
        public int CounterId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string District { get; set; }
        public string Zone { get; set; }
        public string Province { get; set; }
        public string ContactNo { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime ValidUpto { get; set; }
    }
}
