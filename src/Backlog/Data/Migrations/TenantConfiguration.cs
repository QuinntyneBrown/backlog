using System;
using System.Data.Entity.Migrations;
using Backlog.Data;
using Backlog.Model;

namespace Backlog.Data.Migrations
{
    public class TenantConfiguration
    {
        public static void Seed(BacklogContext context) {

            context.Tenants.AddOrUpdate(x => x.Name, new Tenant()
            {
                Name = "Default",
                UniqueId = new Guid("bad9a182-ede0-418d-9588-2d89cfd555bd")
            });

            context.SaveChanges();
        }
    }
}
