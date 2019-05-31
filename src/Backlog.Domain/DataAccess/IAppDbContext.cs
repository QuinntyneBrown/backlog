using Backlog.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading;

namespace Backlog.Domain.DataAccess
{
    public interface IAppDbContext
    {
        DbSet<AgileTeam> AgileTeams { get; set; }
        DbSet<AgileTeamMember> AgileTeamMembers { get; set; }
        DbSet<Article> Articles { get; set; }
        DbSet<Author> Authors { get; set; }
        DbSet<Brand> Brands { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<DigitalAsset> DigitalAssets { get; set; }
        DbSet<Epic> Epics { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<Feedback> Feedbacks { get; set; }
        DbSet<HtmlContent> HtmlContents { get; set; }
        DbSet<Ip> Ips { get; set; }
        DbSet<Project> Projects { get; set; }
        DbSet<ProductBacklogItem> ProductBacklogItems { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ReusableStoryGroup> ReusableStoryGroups { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<Sprint> Sprints { get; set; }
        DbSet<Story> Stories { get; set; }
        DbSet<Tag> Tags { get; set; }
        DbSet<Task> Tasks { get; set; }
        DbSet<TaskStatus> TaskStatuses { get; set; }
        DbSet<Template> Templates { get; set; }        
        DbSet<Theme> Themes { get; set; }
        DbSet<UserSettings> UserSettings { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Profile> Profiles { get; set; }
        DbSet<HomePage> HomePages { get; set; }
        DbSet<Tile> Tiles { get; set; }
        DbSet<Dashboard> Dashboards { get; set; }
        DbSet<DashboardTile> DashboardTiles { get; set; }
        System.Threading.Tasks.Task<int> SaveChangesAsync(CancellationToken token = default);
    }
}