using Book.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book.Infrastructure.Persistence.Configurations
{
    internal class SubscriberConfigurations : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.Property(e => e.StartDate).HasDefaultValueSql("GETDATE()");
            builder.HasOne(b => b.subscriptionType)
                .WithMany(u => u.subscribers)
                .HasForeignKey(b => b.TypeId);
            builder.HasQueryFilter(e => !e.IsDeleted);


        }
    }
}

