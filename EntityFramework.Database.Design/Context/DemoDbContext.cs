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

        public DbSet<Employee> Employee { get; set; }

        public DbSet<EmployeeSalary> EmployeeSalary { get; set; }

        public DbSet<Project> Project { get; set; }

        public DbSet<EmployeeProject> EmployeeProject { get; set; }

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
