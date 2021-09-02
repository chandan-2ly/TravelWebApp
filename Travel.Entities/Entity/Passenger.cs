using System;

namespace Travel.Entities.Entity
{
    public class Passenger : EntityBase
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int BookingId { get; set; }
        public string ContactNo { get; set; }
        public string SeatNo { get; set; }
        public string Status { get; set; }
        public bool IsCancelled { get; set; }
    }
}
