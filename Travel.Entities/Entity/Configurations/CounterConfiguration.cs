using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Entities.Entity.Configurations
{
    internal class CounterConfiguration : IEntityTypeConfiguration<Counter>
    {
        public void Configure(EntityTypeBuilder<Counter> builder)
        {
            //Key
            builder.HasKey(e => e.Id);

            //Properties
            builder.Property(e => e.AdminUserId);
            builder.Property(e => e.ContactNo);
            builder.Property(e => e.CounterName);
            builder.Property(e => e.Address);
            builder.Property(e => e.District);
            builder.Property(e => e.Province);
            builder.Property(e => e.Zone);
            builder.Property(e => e.IsDeleted);
            builder.Property(e => e.IsDisabled);
            builder.Property(e => e.CreatedOn);
            builder.Property(e => e.ModifiedOn);
        }
    }
}
