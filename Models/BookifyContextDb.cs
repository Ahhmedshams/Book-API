﻿using Microsoft.EntityFrameworkCore;

namespace Book_API.Models
{
    public class BookifyContextDb:DbContext
    {
        public BookifyContextDb()
        {

        }

        public BookifyContextDb(DbContextOptions<BookifyContextDb> options) : base(options) { }

       // public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Rent> Rents { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<OrderItem> OrderItems { get; set; }


        public virtual DbSet<PurchasableBook> PurchasableBooks { get; set; }

        public virtual DbSet<RentableBook> RentableBooks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(e => e.Image).HasColumnType("MediumBlob");

            base.OnModelCreating(modelBuilder);
        }

    }
}