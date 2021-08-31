using System;

namespace Travel.Entities.Entity
{
    public class Traveller : EntityBase
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string TravellerName { get; set; }
        public string VehicleType { get; set; }
        public string VehicleNumber { get; set; }
        public string ContactNo { get; set; }
        public int AvailableSeats { get; set; }
        public int Ratings { get; set; }
        public string ComfortType { get; set; }
        public string DocumentNumebr { get; set; }
        public bool IsRemoved { get; set; }
        public bool IsDeleted { get; set; }
    }
}
