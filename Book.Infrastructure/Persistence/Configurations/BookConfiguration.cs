using Book.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Book.Infrastructure.Persistence.Configurations
{
    public class BookConfiguration : IEntityTypeConfiguration<Book.Domain.Entity.Book>
    {
        public void Configure(EntityTypeBuilder<Domain.Entity.Book> builder)
        {

            builder.Property(e => e.Title).HasMaxLength(500).IsRequired();
            builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.Property(e => e.Image).HasColumnType("VarBinary");

        }
    }
}
