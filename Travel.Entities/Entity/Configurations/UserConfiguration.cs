using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Travel.Entities.Entity.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Key
            builder.HasKey(e => e.Id);

            //Insert SuperAdmin by default
            builder.HasData(
                new User
                {
                    Id = new Guid("E2953775-6486-461C-BE87-F24FC00BEEA9"),
                    FirstName = "SuperAdmin",
                    Email = "SuperAdmin@gmail.com",
                    Password = "hDgKGKX9eSfEED4wsKaklLxBsVAQC8CUncZ0xtnUf4A=",
                    Salt = "f3IogiZxpV+LU97WNPoiZBiUawb802oXyD4Y8b84j8M=",
                    Role = 4,
                    CreatedOn = DateTime.UtcNow
                });

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
