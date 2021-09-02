using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Entities.Entity.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Key
            builder.HasKey(e => e.Id);
            

            //Properties
            builder.Property(e => e.FirstName);
            builder
                .HasIndex(e => e.Email)
                .IsUnique();
            builder.Property(e => e.Email).IsRequired();

            builder.Property(e => e.Password);
            builder.Property(e => e.Salt);
            builder.Property(e => e.LastName);
            builder.Property(e => e.Role);
            builder.Property(e => e.Address);
            builder.Property(e => e.CreatedOn);
            builder.Property(e => e.ModifiedOn);
            builder.Property(e => e.IsDeleted);
            builder.Property(e => e.IsDisabled);
        }
    }
}
