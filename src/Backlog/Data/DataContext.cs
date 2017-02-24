using Backlog.Data.Models;
using Backlog.Data.Models;
using System.Data.Entity;

namespace Backlog.Data
{
    public interface IDbContext
    {

    }

    public class DataContext: DbContext, IDbContext
    {
        public DataContext()
            : base(nameOrConnectionString: "BacklogDataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

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
        public DbSet<Task> Tasks { get; set; }
        public DbSet<AgileTeamMember> AgileTeamMembers { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<UserSettings> UserSettings { get; set; }
        public DbSet<TaskStatus> TaskStatuses { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Template> Templates { get; set; }
        public DbSet<Ip> Ips { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<User>().
                HasMany(u => u.Roles).
                WithMany(r => r.Users).
                Map(
                    m =>
                    {
                        m.MapLeftKey("User_Id");
                        m.MapRightKey("Role_Id");
                        m.ToTable("UserRoles");
                    });
        } 
    }
}
