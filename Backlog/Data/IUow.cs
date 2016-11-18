using Backlog.Models;

namespace Backlog.Data
{
    public interface IUow
    {
        IRepository<Article> Articles { get; }
        IRepository<Epic> Epics { get; }
        IRepository<Story> Stories { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }
        IRepository<Tag> Tags { get; }
        IRepository<Sprint> Sprints { get; }
        IRepository<AgileTeam> AgileTeams { get; }
        IRepository<Theme> Themes { get; }
        IRepository<DigitalAsset> DigitalAssets { get; }
        IRepository<HtmlContent> HtmlContents { get; }
        IRepository<ReusableStoryGroup> ReusableStoryGroups { get; }
        IRepository<Project> Projects { get; }
        IRepository<Product> Products { get; }
        IRepository<AgileTeamMember> AgileTeamMembers { get; }
        IRepository<Feedback> Feedbacks { get; }

        void SaveChanges();
    }
}
