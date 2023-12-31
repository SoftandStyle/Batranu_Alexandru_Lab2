﻿using Microsoft.EntityFrameworkCore;
using Batranu_Alexandru_Lab2.Models;

namespace Batranu_Alexandru_Lab2.Data
{
    public class LibraryContext:DbContext

    {
        public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
            modelBuilder.Entity<Book>().ToTable("Book");
            modelBuilder.Entity<Author>().ToTable("Author");
        }

    }
}
    