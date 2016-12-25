using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using AngularJsAppEF.Models;


namespace AngularJsAppEF
{
    public class AngularJsDbSeedData : CreateDatabaseIfNotExists<AngularJsDbContext>
    {

        //protected override void Seed(AngularJsDbContext context)
        //{
        //    //    This method will be called after migrating to the latest version.
        //    //    You can use the DbSet<T>.AddOrUpdate() helper extension method
        //    //    to avoid creating duplicate seed data.E.g.

        //    context.AddressTypes.AddOrUpdate(p => p.Value,
        //    new AddressType { Value = "1", Text = "Present" },
        //    new AddressType { Value = "2", Text = "Permanent" },
        //    new AddressType { Value = "3", Text = "Office" }
        //     );
        //}
    }
}