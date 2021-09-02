using System;

namespace Travel.Entities.Entity
{
    public class Slot : EntityBase
    {
        public int Id { get; set; }
        public int CounterId { get; set; }
        public int TravellerId { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
        public Guid DriverId { get; set; }
        public bool IsAvailable { get; set; }
        public string Source { get; set; }
        public string Destination { get; set; }
        public Guid CreatedBy { get; set; }
        public Guid ModifiedBy { get; set; }

    }
}
