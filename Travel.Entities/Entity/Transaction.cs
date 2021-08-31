using System;

namespace Travel.Entities.Entity
{
    public class Transaction
    {
        public int Id { get; set; }
        public Guid UserId { get; set; }
        public int BookingId { get; set; }
        public string PaymentMode { get; set; }
        public string PaymentStatus { get; set; }
        public double Amount { get; set; }
        public string ReferenceNo { get; set; }

    }
}
