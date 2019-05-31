using Backlog.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Backlog.Domain.DataAccess
{
    public class AppDbContext: DbContext, IAppDbContext
    {
        public virtual DbSet<AgileTeam> AgileTeams { get; set; }
        public virtual DbSet<AgileTeamMember> AgileTeamMembers { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<DigitalAsset> DigitalAssets { get; set; }
        public virtual DbSet<Epic> Epics { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<HtmlContent> HtmlContents { get; set; }
        public virtual DbSet<Ip> Ips { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<ProductBacklogItem> ProductBacklogItems { get; set; }
        public virtual DbSet<ReusableStoryGroup> ReusableStoryGroups { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<TaskStatus> TaskStatuses { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Profile> Profiles { get; set; }
        public virtual DbSet<HomePage> HomePages { get; set; }
        public virtual DbSet<Tile> Tiles { get; set; }
        public virtual DbSet<Dashboard> Dashboards { get; set; }
        public virtual DbSet<DashboardTile> DashboardTiles { get; set; }
    }
}
