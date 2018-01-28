using Backlog.Data;
using Backlog.Features.Users;
using Backlog.Model;
using Backlog.Features.Security;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Collections.Generic;

namespace Backlog.Migrations
{
    public class UserConfiguration
    {
        public static void Seed(BacklogContext context) {

            var tenant = context.Tenants.Single(x => x.Name == "Default");
            var systemRole = context.Roles.First(x => x.Name == Roles.SYSTEM);
            var roles = new List<Role>() { systemRole };

            context.Users.AddOrUpdate(x => x.Username, new User()
            {
                Username = Constants.DefaultUsername,
                Firstname = "Quinntyne",
                Lastname = "Brown",
                Name = "Quinntyne Brown",
                Password = new EncryptionService().TransformPassword("P@ssw0rd"),
                Roles = roles,
                TenantId  = tenant.Id
            });

            context.SaveChanges();
        }
    }
}