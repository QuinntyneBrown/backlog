using Backlog.Model;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Data.Entity;

namespace Backlog.Data.Migrations
{
    public class ProfileConfiguration
    {
        public static void Seed(BacklogContext context) {

            var tenant = context.Tenants.Single(x => x.Name == "Default");
            var user = context.Users.Include(x => x.Profile).Single(x => x.Username == Constants.DefaultUsername);

            context.Profiles.AddOrUpdate(x => x.Name, new Profile()
            {
                Name = "Kirk Brown",
                AvatarImageUrl = "https://media.licdn.com/mpr/mpr/shrinknp_400_400/AAIABADGAAAAAQAAAAAAAA1IAAAAJGRmMzVhMjBjLTcxYjQtNGYwNy1hZWI3LWY5MWE3ZGE4NTdmOQ.jpg",
                TenantId = tenant.Id,
                User = user
            });

            context.SaveChanges(Constants.DefaultUsername);
        }
    }
}
