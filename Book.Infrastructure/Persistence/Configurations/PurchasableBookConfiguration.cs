using Book.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infrastructure.Persistence.Configurations
{
    public class PurchasableBookConfiguration : IEntityTypeConfiguration<PurchasableBook>
    {
        public void Configure(EntityTypeBuilder<PurchasableBook> builder)
        {
            builder.Property(e => e.Price).HasColumnType("decimal(5,2)");

        }
    }
}
