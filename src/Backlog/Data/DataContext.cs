using Backlog.Data.Helpers;
using Backlog.Data.Models;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Threading.Tasks;

namespace Backlog.Data
{    

    public interface IDataContext
    {
        DbSet<Epic> Epics { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Story> Stories { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Sprint> Sprints { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<AgileTeam> AgileTeams { get; set; }
        DbSet<Theme> Themes { get; set; }
        DbSet<DigitalAsset> DigitalAssets { get; set; }
        DbSet<HtmlContent> HtmlContents { get; set; }
        DbSet<ReusableStoryGroup> ReusableStoryGroups { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Data.Models.Task> Tasks { get; set; }
        DbSet<AgileTeamMember> AgileTeamMembers { get; set; }
        DbSet<Feedback> Feedbacks { get; set; }
        DbSet<UserSettings> UserSettings { get; set; }
        DbSet<Data.Models.TaskStatus> TaskStatuses { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Template> Templates { get; set; }
        DbSet<Ip> Ips { get; set; }

        Task<int> SaveChangesAsync();
    }

    public class DataContext: DbContext, IDataContext
    {
        public DataContext()
            : base(nameOrConnectionString: "DataContext")
        {
            Configuration.ProxyCreationEnabled = false;
            Configuration.LazyLoadingEnabled = false;
            Configuration.AutoDetectChangesEnabled = true;
        }

        public virtual DbSet<Epic> Epics { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Story> Stories { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<Sprint> Sprints { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<AgileTeam> AgileTeams { get; set; }
        public virtual DbSet<Theme> Themes { get; set; }
        public virtual DbSet<DigitalAsset> DigitalAssets { get; set; }
        public virtual DbSet<HtmlContent> HtmlContents { get; set; }
        public virtual DbSet<ReusableStoryGroup> ReusableStoryGroups { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Data.Models.Task> Tasks { get; set; }
        public virtual DbSet<AgileTeamMember> AgileTeamMembers { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<UserSettings> UserSettings { get; set; }
        public virtual DbSet<Data.Models.TaskStatus> TaskStatuses { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Feature> Features { get; set; }
        public virtual DbSet<Template> Templates { get; set; }
        public virtual DbSet<Ip> Ips { get; set; }

        public override int SaveChanges()
        {
            foreach (var entity in ChangeTracker.Entries()
                .Where(e => e.Entity is ILoggable && ((e.State == EntityState.Added || (e.State == EntityState.Modified))))
                .Select(x=>x.Entity as ILoggable)) {
                entity.CreatedOn = entity.CreatedOn == default(DateTime) ? DateTime.UtcNow : entity.CreatedOn;
                entity.LastModifiedOn = DateTime.UtcNow;
            }
            return base.SaveChanges();
        }

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

            var conv = new AttributeToTableAnnotationConvention<SoftDeleteAttribute, string>(
                "SoftDeleteColumnName",
                (type, attributes) => attributes.Single().ColumnName);

            modelBuilder.Conventions.Add(conv);
        } 
    }
}
