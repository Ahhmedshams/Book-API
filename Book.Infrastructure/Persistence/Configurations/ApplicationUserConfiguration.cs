using Book.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace Book.Infrastructure.Persistence.Configurations
{
    public class ApplicationUserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            builder.HasIndex(e => e.Email).IsUnique();
            builder.HasIndex(e => e.UserName).IsUnique();
            builder.Property(e => e.CreatedOn).HasDefaultValueSql("GETDATE()");
            builder.ToTable("Users", "security");
            //builder.Property(e => e.ProfilePicture).HasColumnType("VarBinary").IsRequired(false);




        }
    }
}
