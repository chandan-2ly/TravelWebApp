using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Entities.Entity.Configurations
{
    internal class DriverConfigration : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            //Key
            builder.HasKey(e => e.Id);

            //Properties
            builder.Property(e => e.CounterId);
            builder.Property(e => e.FirstName);
            builder.Property(e => e.LastName);
            builder.Property(e => e.Address);
            builder.Property(e => e.District);
            builder.Property(e => e.Province);
            builder.Property(e => e.Zone);
            builder.Property(e => e.ContactNo);
            builder.Property(e => e.LicenseNumber);
            builder.Property(e => e.LicenseValidity);
            builder.Property(e => e.CreatedOn);
            builder.Property(e => e.ModifiedOn);
            builder.Property(e => e.CreatedBy);
            builder.Property(e => e.ModifiedBy);
        }
    }
}
