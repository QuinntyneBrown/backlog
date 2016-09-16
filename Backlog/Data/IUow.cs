using Backlog.Models;

namespace Backlog.Data
{
    public interface IUow
    {
        IRepository<Epic> Epics { get; }
        IRepository<Story> Stories { get; }
        IRepository<User> Users { get; }
        IRepository<Role> Roles { get; }

        void SaveChanges();
    }
}
