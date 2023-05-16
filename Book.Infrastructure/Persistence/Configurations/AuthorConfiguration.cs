
using Book.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Book.Infrastructure.Persistence.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(e => e.Name).IsRequired();
            builder.Property(e=> e.Biographpy).IsRequired();
            builder.HasQueryFilter(e => !e.IsDeleted);
            builder.Property(e => e.Image).HasColumnType("VarBinary");



        }
    }
}
