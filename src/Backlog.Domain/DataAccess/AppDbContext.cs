using Backlog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Domain.DataAccess
{
    public class AppDbContext: DbContext, IAppDbContext
    {
        public DbSet<AgileTeam> AgileTeams { get; private set; }
        public DbSet<AgileTeamMember> AgileTeamMembers { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<ArticleSnapShot> ArticleSnapShots { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<BrandFeature> BrandFeatures { get; set; }
        public DbSet<BrandOwner> BrandOwners { get; set; }
        public DbSet<BrandTemplate> BrandTemplates { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Dashboard> Dashboards { get; set; }
    }
}
