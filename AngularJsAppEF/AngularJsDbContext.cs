using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using AngularJsAppModel;

namespace AngularJsAppEntityFramework
{
    public  class AngularJsDbContext : DbContext
    {
        public AngularJsDbContext()
            //  : base(nameOrConnectionString: @"AngularJsAppEntities")
           : base(nameOrConnectionString: @"Data Source=SAIFUL-PC\SQLEXPRESS;initial Catalog=AngularJsAppDB;integrated security=true")
          
            {
            //Database.SetInitializer<RelationDbContext>(new DropCreateDatabaseAlways<RelationDbContext>());
            }


        public DbSet<Student> Students { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Course> Courses { get; set; }
      
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //  modelBuilder.Properties<DateTime>().Configure(c => c.HasColumnType("datetime2"));
            
            //modelBuilder.Entity<Interest>()
            //    .HasMany(c => c.Customers)
            //    .WithMany(i => i.Interests)
            //    .Map(x => x.MapLeftKey("InterestId")
            //    .MapRightKey("CustomerId")
            //    .ToTable("CustomerInterest", Schemas.Person));

            //modelBuilder.Entity<CommunicationType>()
            //    .HasMany(e => e.Communications)
            //    .WithRequired(e => e.CommunicationType)
            //    .WillCascadeOnDelete(false);
        }
    }
}
