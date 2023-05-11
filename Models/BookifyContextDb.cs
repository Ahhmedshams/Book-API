using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace Book_API.Models
{
    public class BookifyContextDb: IdentityDbContext<ApplicationUser>
    {
        public BookifyContextDb()
        {

        }

        public BookifyContextDb(DbContextOptions<BookifyContextDb> options) : base(options) { }

        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PurchasableBook> PurchasableBooks { get; set; }
        public virtual DbSet<RentableBook> RentableBooks { get; set; }

        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<Book>().ToTable("Books");
            modelBuilder.Entity<Author>().Property(e => e.Image).HasColumnType("VarBinary");
            modelBuilder.Entity<Book>().Property(e => e.Image).HasColumnType("VarBinary");



            //change Identity Table name in Data base 
            modelBuilder.Entity<ApplicationUser>().ToTable("Users", "security");
            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");

        }

        

    }
}
