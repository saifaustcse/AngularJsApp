namespace AngularJsAppEF.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AngularJsDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(AngularJsDbContext context)
        {
            //    This method will be called after migrating to the latest version.
            //    You can use the DbSet<T>.AddOrUpdate() helper extension method
            //    to avoid creating duplicate seed data.E.g.

            context.AddressTypes.AddOrUpdate(p => p.Value,

            new Models.AddressType { Value = "1", Text = "Present" },
            new Models.AddressType { Value = "2", Text = "Permanent" },
            new Models.AddressType { Value = "3", Text = "Office" }
             );
        }
    }
}
