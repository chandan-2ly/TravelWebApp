using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Entities.Entity.Configurations
{
    internal class TravellerConfiguration : IEntityTypeConfiguration<Traveller>
    {
        public void Configure(EntityTypeBuilder<Traveller> builder)
        {
            //Key
            builder.HasKey(e => e.Id);


            //Properties
            builder.Property(e => e.AdminUserId);
            builder.Property(e => e.TravellerName);
            builder
                .HasIndex(e => e.VehicleNumber)
                .IsUnique();
            builder.Property(e => e.VehicleNumber).IsRequired();

            builder.Property(e => e.VehicleType);
            builder.Property(e => e.Ratings);
            builder.Property(e => e.AvailableSeats);
            builder.Property(e => e.ComfortType);
            builder.Property(e => e.ContactNo);
            builder.Property(e => e.IsRemoved);
            builder.Property(e => e.DocumentNumebr);
            builder.Property(e => e.CreatedOn);
            builder.Property(e => e.ModifiedOn);
        }
    }
}
