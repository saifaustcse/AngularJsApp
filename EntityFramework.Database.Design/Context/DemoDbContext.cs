using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Demo.Core.Data.Models;


namespace Demo.Core.Data.Interfaces
{
    public class DemoDbContext : DbContext
    {

        public DemoDbContext()
        {
        }

        public DemoDbContext(DbContextOptions<DemoDbContext> options) : base(options) { }

        public DbSet<Department> Department { get; set; }

        public DbSet<Course> Course { get; set; }

        public DbSet<Student> Student { get; set; }

        public DbSet<AddressType> AddressType { get; set; }

        public DbSet<Address> Address { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = "Server=.\\SQLEXPRESS;Database=DEMO_DB;Trusted_Connection=True;";

                optionsBuilder.UseSqlServer(connectionString);
            }
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }

    }
}
