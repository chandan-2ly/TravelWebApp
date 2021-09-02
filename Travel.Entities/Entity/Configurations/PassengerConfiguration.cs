using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Entities.Entity.Configurations
{
    internal class PassengerConfiguration : IEntityTypeConfiguration<Passenger>
    {
        public void Configure(EntityTypeBuilder<Passenger> builder)
        {
            //Key
            builder.HasKey(e => e.Id);

            //Properties
            builder.Property(e => e.UserId);
            builder.Property(e => e.BookingId);
            builder.Property(e => e.FirstName);
            builder.Property(e => e.LastName);
            builder.Property(e => e.ContactNo);
            builder.Property(e => e.Email);
            builder.Property(e => e.SeatNo);
            builder.Property(e => e.IsCancelled);
            builder.Property(e => e.Status);
            builder.Property(e => e.CreatedOn);
            builder.Property(e => e.ModifiedOn);
        }
    }
}
