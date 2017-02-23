using System.Data.Entity.Migrations;
using Backlog.Data;
using Backlog.Infrastructure;
using Backlog.Models;
using Backlog.Services;

namespace Backlog.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(DataContext context) {
            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.SYSTEM
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.PRODUCT
            });

            context.Roles.AddOrUpdate(x => x.Name, new Role()
            {
                Name = Roles.DEVELOPMENT
            });

            context.SaveChanges();
        }
    }
}
