using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Travel.Entities.Entity.Configurations
{
    internal class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            //Key
            builder.HasKey(e => e.Id);

            //Properties
            builder.Property(e => e.UserId);
            builder.Property(e => e.BookingId);
            builder.Property(e => e.Amount);
            builder.Property(e => e.PaymentMode);
            builder.Property(e => e.PaymentStatus);
            builder.Property(e => e.ReferenceNo);
        }
    }
}
