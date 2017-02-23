using System.Data.Entity.Migrations;
using Backlog.Data;
using Backlog.Models;
using Backlog.Services;
using System.Linq;
using System.Collections.Generic;
using Backlog.Infrastructure;

namespace Backlog.Migrations
{
    public class UserConfiguration
    {
        public static void Seed(DataContext context) {

            var systemRole = context.Roles.First(x => x.Name == Roles.SYSTEM);
            var roles = new List<Role>();
            roles.Add(systemRole);
            context.Users.AddOrUpdate(x => x.Username, new User()
            {
                Username = "system",
                Password = new EncryptionService().TransformPassword("system"),
                Roles = roles
            });
            context.SaveChanges();
        }
    }
}
