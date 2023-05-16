using Book.Domain.Entity;
using Book.Infrastructure.Persistence.Configurations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Reflection;
using System.Xml;

namespace Book_API.Models
{
    public class BookifyContextDb : IdentityDbContext<ApplicationUser>
    {
        public BookifyContextDb()
        {

        }

        public BookifyContextDb(DbContextOptions<BookifyContextDb> options) : base(options) { }

        #region Models DbSet
        public virtual DbSet<Book.Domain.Entity.Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderItem> OrderItems { get; set; }
        public virtual DbSet<PurchasableBook> PurchasableBooks { get; set; }
        public virtual DbSet<RentableBook> RentableBooks { get; set; }
        #endregion

        public virtual DbSet<Subscriber> Subscribers { get; set; }
        public virtual DbSet<SubscriptionType> SubscriptionTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            modelBuilder.Entity<IdentityRole>().ToTable("Roles");
            modelBuilder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            modelBuilder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            modelBuilder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            modelBuilder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaims", "security");
            modelBuilder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");


            base.OnModelCreating(modelBuilder);
        }
    }

    //    public override int SaveChanges()
    //    {
    //        foreach (var entry in ChangeTracker.Entries())
    //        {
    //            if (entry.Entity is IEntity)
    //            {
    //                switch (entry.State)
    //                {
    //                    case EntityState.Added:
    //                        {
    //                            entry.CurrentValues["TimeCreated"] = new DateTime();
    //                            //entry.CurrentValues["CreatedBy"]=
    //                            break;
    //                        }
    //                    case EntityState.Deleted:
    //                        {
    //                            entry.State = EntityState.Modified;
    //                            entry.CurrentValues["IsDeleted"] = true;
    //                            entry.CurrentValues["TimeModified"] = new DateTime();
    //                            break;
    //                        }
    //                    case EntityState.Modified:
    //                        {
    //                            entry.CurrentValues["TimeModified"] = new DateTime();
    //                            break;
    //                        }
    //                }
    //            }
    //        }
    //        return base.SaveChanges();
    //    }

    //}
}
