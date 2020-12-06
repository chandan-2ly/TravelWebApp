using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Entity.Configurations
{
    internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            //Key
            builder.HasKey(e => e.Id);


            //Properties
            builder.Property(e => e.RoleName).IsRequired();
            builder.Property(e => e.Description);
        }
    }
}
