using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Entities.Entity.Configurations
{
    internal class SlotConfiguration : IEntityTypeConfiguration<Slot>
    {
        public void Configure(EntityTypeBuilder<Slot> builder)
        {
            //Key
            builder.HasKey(e => e.Id);

            //Properties
            builder.Property(e => e.CounterId);
            builder.Property(e => e.Date);
            builder.Property(e => e.Source);
            builder.Property(e => e.Destination);
            builder.Property(e => e.DriverId);
            builder.Property(e => e.IsAvailable);
            builder.Property(e => e.Time);
            builder.Property(e => e.TravellerId);
            builder.Property(e => e.CreatedOn);
            builder.Property(e => e.ModifiedOn);
            builder.Property(e => e.CreatedBy);
            builder.Property(e => e.ModifiedBy);
        }
    }
}
