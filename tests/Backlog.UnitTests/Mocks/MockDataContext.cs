using Backlog.Data;
using Backlog.Model;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Backlog.UnitTests.Mocks
{
    public class MockDataContext: IBacklogContext
    {
        public DbSet<Epic> Epics { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Story> Stories { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Sprint> Sprints { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<AgileTeam> AgileTeams { get; set; }
        public DbSet<Theme> Themes { get; set; }
        public DbSet<DigitalAsset> DigitalAssets { get; set; }
        public DbSet<HtmlContent> HtmlContents { get; set; }
        public DbSet<ReusableStoryGroup> ReusableStoryGroups { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Model.Task> Tasks { get; set; }
        public DbSet<AgileTeamMember> AgileTeamMembers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<Model.TaskStatus> TaskStatuses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Ip> Ips { get; set; }
        public DbSet<Tenant> Tenants { get; set; }
        public DbSet<Category> Categories { get; set; }

        public Task<int> SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }
    }
}
