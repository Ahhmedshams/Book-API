using Book.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Book.Infrastructure.Persistence.Configurations
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.PurchaseDate).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.AvailableForReturnUntill).IsRequired();
            builder.Property(e => e.AvailableForReturnUntill).IsRequired();
            builder.Property(e => e.TotalPrice).HasColumnType("decimal(5,2)");

            builder.HasOne(o => o.CreatedBy)
            .WithMany()
            .HasForeignKey(o => o.CreatedById)
            .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(b => b.User)
                .WithMany(u => u.orders)
                .HasForeignKey(b => b.UserId);

            builder.HasOne<ApplicationUser>(o => o.LastUpdatedBy)
            .WithMany()
            .HasForeignKey(o => o.LastUpdatedById)
            .OnDelete(DeleteBehavior.Restrict);
            builder.HasQueryFilter(e => !e.IsDeleted);



        }
    }
}