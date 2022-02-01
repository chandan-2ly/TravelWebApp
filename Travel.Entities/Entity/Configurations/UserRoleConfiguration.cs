using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Entities.Entity.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            //Key
            builder.HasKey(e => e.RoleId);
            //Properties
            builder.HasData(
                new UserRole { RoleId = 1, RoleName = "Customer", Description = "End Customers" },
                new UserRole { RoleId = 2, RoleName = "Owner", Description = "Traveller Owners" },
                new UserRole { RoleId = 3, RoleName = "Counter", Description = "Traveller Owner Created Counters" },
                new UserRole { RoleId = 4, RoleName = "SuperAdmin", Description = "Super Admin Access" }
                );
            builder.Property(e => e.RoleName).IsRequired();
            builder.Property(e => e.Description);
            builder.Property(e => e.RoleId);
        }
    }
}
