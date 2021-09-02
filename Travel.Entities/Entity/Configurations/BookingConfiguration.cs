using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Entities.Entity.Configurations
{
    internal class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            //Key
            builder.HasKey(e => e.Id);

            //Properties
            builder.Property(e => e.UserId);
            builder.Property(e => e.TravellerId);
            builder.Property(e => e.CounterId);
            builder.Property(e => e.TimeSlot);
            builder.Property(e => e.Status);
            builder.Property(e => e.Source);
            builder.Property(e => e.Destination);
            builder.Property(e => e.BookingType);
            builder.Property(e => e.IsCancelled);
            builder.Property(e => e.JourneyOn);
            builder.Property(e => e.PassengerCount);
            builder.Property(e => e.CreatedOn);
            builder.Property(e => e.ModifiedOn);
            builder.Property(e => e.CreatedBy);
            builder.Property(e => e.ModifiedBy);
        }
    }
}
