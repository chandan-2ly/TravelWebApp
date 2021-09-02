using System;

namespace Travel.Entities.Entity
{
    public class Booking : EntityBase
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int? CounterId { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public DateTime JourneyOn { get; set; }
        public string TimeSlot { get; set; }
        public int TravellerId { get; set; }
        public int PassengerCount { get; set; }
        public string BookingType { get; set; }
        public string Status { get; set; }
        public bool IsCancelled { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }
    }
}
