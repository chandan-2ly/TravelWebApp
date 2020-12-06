using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Travel.Entities.Entity.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Key
            builder.HasKey(e => e.Id);
            

            //Properties
            builder.Property(e => e.FullName);
            builder
                .HasIndex(e => e.Email)
                .IsUnique();
            builder.Property(e => e.Email).IsRequired();

            builder.Property(e => e.Password);
            builder.Property(e => e.Salt);
        }
    }
}
