using Book.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Book.Infrastructure.Persistence.Configurations
{
    internal class SubscriptionTypeConfigr : IEntityTypeConfiguration<SubscriptionType>
    {
        public void Configure(EntityTypeBuilder<SubscriptionType> builder)
        {
            builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.Price).HasColumnType("decimal(5,2)");
            builder.HasQueryFilter(e => !e.IsDeleted);

        }
    }
}
