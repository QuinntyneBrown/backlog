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
                Name = "Quinntyne Brown",
                AvatarImageUrl = "https://avatars0.githubusercontent.com/u/1749159?s=400&u=b36e138431ef4f0a383e51eef90248ad07066b28&v=4",
                TenantId = tenant.Id,
                User = user
            });

            context.SaveChanges(Constants.DefaultUsername);
        }
    }
}
