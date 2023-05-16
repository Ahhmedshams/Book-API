using Book.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infrastructure.Persistence.Configurations
{
    public class OrderItemConfigurations : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");

            builder.Property(e => e.TotalPrice).HasColumnType("decimal(5,2)");
            builder.Property(e => e.Unitprice).HasColumnType("decimal(5,2)");

            builder.HasQueryFilter(e => !e.IsDeleted);


            builder.HasOne(b => b.Order)
                .WithMany(o => o.Items)
                .HasForeignKey(b => b.OrderId);

            builder.HasOne(b => b.Book)
                .WithMany()
                .HasForeignKey(b => b.BookId);
        }
    }
}

