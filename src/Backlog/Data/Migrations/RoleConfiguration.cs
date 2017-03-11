using System.Data.Entity.Migrations;
using Backlog.Data;
using Backlog.Features.Users;
using Backlog.Data.Model;

namespace Backlog.Migrations
{
    public class RoleConfiguration
    {
        public static void Seed(BacklogContext context) {
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
