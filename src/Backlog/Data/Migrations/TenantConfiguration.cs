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
                UniqueId = new Guid("196ce9e2-3107-475f-9c1c-7fa13b534eb1")
            });

            context.SaveChanges();
        }
    }
}
